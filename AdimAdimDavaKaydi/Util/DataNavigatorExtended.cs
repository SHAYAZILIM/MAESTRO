using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AdimAdimDavaKaydi.Properties;
using AvukatProLib2.Entities;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraVerticalGrid;

namespace AdimAdimDavaKaydi.Util
{
    [System.Drawing.ToolboxBitmap(typeof(DataNavigator))]
    public class DataNavigatorExtended : DataNavigator
    {
        // Added by e
        private bool selectButtonVisible;

        [Browsable(true), Category("Xtended Properties")]
        public bool SelectButtonVisible
        {
            get { return selectButtonVisible; }
            set { selectButtonVisible = value; }
        }

        private Control cntNormal;
        private DockStyle dstyleEski;
        private bool isTamEkran;
        private GridControl myGridControl;
        private VGridControl myVGridControl;
        private LayoutViewStyle viewStyleEski;
        private PivotGridControl myPivotGridControl;
        private ChartControl mychartControl;

        public DataNavigatorExtended()
        {
            this.ParentChanged += DataNavigatorExtended_ParentChanged;
        }

        private void DataNavigatorExtended_ParentChanged(object sender, EventArgs e)
        {
            initMe();
        }

        public void initMe()
        {
            SelectClick += DataNavigatorExtended_SelectClick;
            this.CustomButtons.Clear();
            if (DesignMode || !EntityBase.BagliKullaniciId.HasValue)
                return;
            this.Buttons.CancelEdit.Visible = false;
            this.Buttons.NextPage.Visible = false;
            this.Buttons.PrevPage.Visible = false;

            #region buton Resimleri

            ImageList imgList = new ImageList();
            imgList.ColorDepth = ColorDepth.Depth32Bit;
            imgList.ImageSize = new Size(16, 16);
            int index = imgList.Images.Add(Resources.dnext_16x16_getir, Color.Transparent);
            int index2 = imgList.Images.Add(Resources.dnext_16x16_cevir, Color.Transparent);
            int index3 = imgList.Images.Add(Resources.tam_ekran11, Color.Transparent);
            int index4 = imgList.Images.Add(Resources.dnext_16x16_printer, Color.Transparent);
            int index5 = imgList.Images.Add(Resources.dnext_16x16_excel, Color.Transparent);
            int index6 = imgList.Images.Add(Resources.dnext_16x16_email, Color.Transparent);
            int index7 = imgList.Images.Add(Resources.dnext_16x16_add, Color.Transparent);
            int index8 = imgList.Images.Add(Resources.dnext_16x16_tick, Color.Transparent);
            int index9 = imgList.Images.Add(Resources.dnext_16x16_next, Color.Transparent);
            int index10 = imgList.Images.Add(Resources.dnext_16x16_previous, Color.Transparent);
            int index11 = imgList.Images.Add(Resources.dnext_16x16_last, Color.Transparent);
            int index12 = imgList.Images.Add(Resources.dnext_16x16_first, Color.Transparent);
            int index122 = imgList.Images.Add(Resources.dnext_16x16_delete, Color.Transparent);
            //ADded by e
            int index13 = imgList.Images.Add(Resources.dnext_16x16_editor, Color.Transparent);
            //ADded by e
            int index14 = imgList.Images.Add(Resources.dnext_16x16_cevir, Color.Transparent);

            #endregion

            this.Validated += DataNavigatorExtended_Validated;

            #region system tarafýndan ekli olan default butonlarýn resim ve hintleri

            this.Buttons.ImageList = imgList;
            this.Buttons.Append.ImageIndex = index7;
            this.Buttons.Append.Hint = "Yeni bir kayýt ekler";
            this.Buttons.EndEdit.ImageIndex = index8;
            this.Buttons.EndEdit.Hint = "Geçerli kaydý tamamlar";
            this.Buttons.Next.ImageIndex = index9;
            this.Buttons.Next.Hint = "Bir sonraki kayýt";
            this.Buttons.Prev.ImageIndex = index10;
            this.Buttons.Prev.Hint = "Bir önceki kayýt";
            this.Buttons.NextPage.ImageIndex = index11;
            this.Buttons.NextPage.Hint = "Bir sonraki kayýt dizisi";
            this.Buttons.First.ImageIndex = index12;
            this.Buttons.First.Hint = "Ýlk kayýt";
            this.Buttons.Last.ImageIndex = index11;
            this.Buttons.Last.Hint = "Son kayýt";
            this.Buttons.PrevPage.ImageIndex = index12;
            this.Buttons.PrevPage.Hint = "Bir önceki kayýt dizisi";
            this.Buttons.Remove.ImageIndex = index122;
            this.Buttons.Remove.Hint = "Geçerli kaydý siler";

            #endregion

            this.ShowToolTips = true;

            bool varmiGetir = false;
            bool varmiCevir = false;
            bool varmiTamEkr = false;
            bool varmiYazdir = false;
            bool varmiExcel = false;
            bool varmiMail = false;

            bool varmiExportToEditor = false;

            bool varmiKabulEt = false;
            bool varmiDigerIslemMenu = false;

            for (int i = 0; i < CustomButtons.Count; i++)
            {
                if (CustomButtons[i].Tag != null && CustomButtons[i].Tag.ToString() == "Getir")
                {
                    varmiGetir = true;
                    CustomButtons[i].ImageIndex = index;
                    CustomButtons[i].Hint = "Varolan kayýtlar arasýndan getir";
                }
                else if (CustomButtons[i].Tag != null && CustomButtons[i].Tag.ToString() == "Cevir")
                {
                    varmiCevir = true;
                    CustomButtons[i].ImageIndex = index2;
                    CustomButtons[i].Hint = "Liste / Form Görünüm";
                }
                else if (CustomButtons[i].Tag != null && CustomButtons[i].Tag.ToString() == "TamEkr")
                {
                    varmiTamEkr = true;
                    CustomButtons[i].ImageIndex = index3;
                    CustomButtons[i].Hint = "Tam Ekran";
                }
                else if (CustomButtons[i].Tag != null && CustomButtons[i].Tag.ToString() == "Yazdir")
                {
                    varmiYazdir = true;
                    CustomButtons[i].ImageIndex = index4;
                    CustomButtons[i].Hint = "Yazdýr";
                }
                else if (CustomButtons[i].Tag != null && CustomButtons[i].Tag.ToString() == "Excel")
                {
                    varmiExcel = true;
                    CustomButtons[i].ImageIndex = index5;
                    CustomButtons[i].Hint = "Baþka bir programa gönder (Export)";
                }
                else if (CustomButtons[i].Tag != null && CustomButtons[i].Tag.ToString() == "Mail")
                {
                    varmiMail = true;
                    CustomButtons[i].ImageIndex = index6;
                    CustomButtons[i].Hint = "E-Posta olarak gönder";
                }
                //ADded by e
                else if (CustomButtons[i].Tag != null && CustomButtons[i].Tag.ToString() == "Editor")
                {
                    varmiExportToEditor = true;
                    CustomButtons[i].ImageIndex = index13;
                    CustomButtons[i].Hint = "Editör'e gönder";
                }
                //ADded by e
                else if (CustomButtons[i].Tag != null && CustomButtons[i].Tag.ToString() == "KabulEt")
                {
                    varmiKabulEt = true;
                    CustomButtons[i].ImageIndex = index14;
                    CustomButtons[i].Hint = "Kabul Et";
                }
                else if (CustomButtons[i].Tag != null && CustomButtons[i].Tag.ToString() == "DigerMenu")
                {
                    varmiDigerIslemMenu = true;
                    CustomButtons[i].ImageIndex = index14;
                    CustomButtons[i].Hint = "Diðer Ýþlemler";
                }
            }
            if (!varmiGetir)
            {
                NavigatorCustomButton btn = this.CustomButtons.Add();
                btn.Enabled = false;
                btn.Visible = false;
                btn.Tag = "Getir";
                btn.Hint = "Listeden Getir";
                btn.ImageIndex = index;
            }
            if (!varmiCevir)
            {
                NavigatorCustomButton cevir = this.CustomButtons.Add();
                cevir.Enabled = false;
                cevir.Visible = false;
                cevir.Tag = "Cevir";
                cevir.Hint = "Liste/Form Görünümü";
                cevir.ImageIndex = index2;
            }
            if (!varmiTamEkr)
            {
                NavigatorCustomButton tamekr = this.CustomButtons.Add();
                tamekr.Tag = "TamEkr";
                tamekr.Hint = "Tam Ekran";
                tamekr.ImageIndex = index3;
            }
            if (!varmiYazdir)
            {
                NavigatorCustomButton print = this.CustomButtons.Add();
                print.Tag = "Yazdir";
                print.Hint = "Yazdýr";
                print.ImageIndex = index4;
            }
            if (!varmiExcel)
            {
                NavigatorCustomButton print = this.CustomButtons.Add();
                print.Tag = "Excel";
                print.Hint = "Baþka bir programa gönder (Export)";
                print.ImageIndex = index5;
            }
            if (!varmiMail)
            {
                NavigatorCustomButton print = this.CustomButtons.Add();
                print.Tag = "Mail";
                print.Hint = "Email Olarak Gönder";
                print.ImageIndex = index6;
            }
            //ADded by e
            if (!varmiExportToEditor)
            {
                //NavigatorCustomButton exportToEditor = this.CustomButtons.Add();
                //exportToEditor.Tag = "Editor";
                //exportToEditor.Hint = "Editöre Gönder";
                //exportToEditor.ImageIndex = index13;
            }

            //ADded by e
            if (!varmiKabulEt)
            {
                if (selectButtonVisible)
                {
                    NavigatorCustomButton kabulEt = this.CustomButtons.Add();
                    kabulEt.Tag = "KabulEt";
                    kabulEt.Hint = "Kabul Et";
                    kabulEt.ImageIndex = index14;
                }
            }
            if (!varmiDigerIslemMenu)
            {
                NavigatorCustomButton btnDiger = this.CustomButtons.Add();
                btnDiger.Tag = "DigerMenu";
                btnDiger.Hint = "Diðer Ýþlemler";
                btnDiger.ImageIndex = index14;
            }

            this.ButtonClick += DataNavigatorExtended_ButtonClick;

            this.TextLocation = NavigatorButtonsTextLocation.Center;
            this.TextStringFormat = "Kayýt {0} / {1}";

            #region <ZK - 20090606>

            //Navigator Bar menudeki butonlarý database ekleyip pakete gore gorunurlugunu duzenlemek için eklendi

            //TODO: [PAKET] Bar Menu DataNavigatorExtended

            //CS_KOD_FORM_LISTESI csKodFormListesi = AvukatProLib.Util.AuthHelperBase.ApplyAuthorization(nameSpace, "Root", 0, "Navigator Bar Menu");
            //int tmpRootID = csKodFormListesi.ID;

            foreach (NavigatorCustomButton itemButon in CustomButtons)
            {
                //AvukatProLib.Util.AuthHelperBase.ApplyAuthorization(nameSpace, itemButon.Tag.ToString(), tmpRootID, itemButon.Hint);

                #region <cc-20090714>

                // desanýrlar açýlýrken hata alýnýyordu  tarafgýmdan kapatýlmýþtýr
                //itemButon.Visible = AvukatProLib.Util.AuthHelperBase.PaketeDahilmi(nameSpace, itemButon.Tag.ToString());

                #endregion
            }

            #endregion </ZK - 20090606>
        }

        private void DataNavigatorExtended_SelectClick(object sender, object id, object selected)
        {
        }

        private void DataNavigatorExtended_Validated(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        [Browsable(true), Category("Xtended Properties")]
        public GridControl MyGridControl
        {
            get { return myGridControl; }
            set
            {
                if (!DesignMode && value != null)
                {
                    value.DataSourceChanged += gridcontrol_DataSourceChanged;
                }
                myGridControl = value;
            }
        }

        [Browsable(true), Category("Xtended Properties")]
        public VGridControl MyVGridControl
        {
            get { return myVGridControl; }
            set
            {
                if (!DesignMode && value != null)
                {
                    value.DataSourceChanged += verticalgrid_DataSourceChanged;
                }
                myVGridControl = value;
            }
        }

        [Browsable(true), Category("Xtended Properties")]
        public PivotGridControl MyPivotGridControl
        {
            get { return myPivotGridControl; }
            set
            {
                if (!DesignMode && value != null)
                {
                    value.DataSourceChanged += pivotvalue_DataSourceChanged;
                }
                myPivotGridControl = value;
            }
        }

        private void pivotvalue_DataSourceChanged(object sender, EventArgs e)
        {
            this.DataSource = ((PivotGridControl)sender).DataSource;
            //this.DataSource = ((VGridControl)sender).DataSource;
            if (this.CustomButtons.Count > 1)
            {
                if (OnListedenGetirClick != null)
                {
                    this.CustomButtons[0].Enabled = true;
                    this.CustomButtons[0].Visible = true;
                }
                if (OnCevirClick != null)
                {
                    this.CustomButtons[1].Enabled = true;
                    this.CustomButtons[1].Visible = true;
                }
            }
        }

        [Browsable(true), Category("Xtended Properties")]
        public ChartControl MyChartControl
        {
            get { return mychartControl; }
            set
            {
                if (!DesignMode && value != null)
                {
                    //value.BoundDataChanged += new BoundDataChangedEventHandler(value_BoundDataChanged);
                }
                mychartControl = value;
            }
        }

        [Browsable(true), Category("Xtended Properties")]
        public event ListedenGetirEventHandler OnListedenGetirClick;

        [Browsable(true), Category("Xtended Properties")]
        public event EventHandler OnCevirClick;

        private void DataNavigatorExtended_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                if (e.Button.Tag.ToString() == "Getir")
                {
                    if (OnListedenGetirClick == null)
                        return;

                    ListedenGetirEventArgs arg = new ListedenGetirEventArgs();
                    if (myVGridControl != null)
                    {
                        arg.IsChart = false;
                        arg.IsPivot = false;
                        arg.IsVerticalGrid = true;
                        arg.MyVGridControl = MyVGridControl;
                    }
                    else if (myGridControl != null)
                    {
                        arg.IsChart = false;
                        arg.IsPivot = false;
                        arg.IsVerticalGrid = false;
                        arg.MyGridControl = myGridControl;
                    }
                    else if (myPivotGridControl != null)
                    {
                        arg.IsVerticalGrid = false;
                        arg.IsPivot = true;
                        arg.IsChart = false;
                        arg.MyPivotGridControl = myPivotGridControl;
                    }
                    else if (mychartControl != null)
                    {
                        arg.IsChart = true;
                        arg.IsPivot = false;
                        arg.IsVerticalGrid = false;
                        arg.MyChartControl = mychartControl;
                    }
                    OnListedenGetirClick(this, arg);
                }
                else if (e.Button.Tag.ToString() == "Cevir")
                {
                    if (OnCevirClick != null)
                        OnCevirClick(this, new EventArgs());
                }
                else if (e.Button.Tag.ToString() == "TamEkr")
                {
                    if (!isTamEkran)
                    {
                        if (cntNormal == null && this.Parent != null && this.Parent.Parent != null)
                        {
                            cntNormal = this.Parent.Parent;
                        }
                        TamEkranYap();
                    }
                    else
                        EskiHaleGetir();
                }
                else if (e.Button.Tag.ToString() == "Yazdir")
                {
                    if (myVGridControl != null)
                    {
                        myVGridControl.ShowPrintPreview();
                    }
                    else if (myGridControl != null)
                    {
                        if (myGridControl.DataSource is ListBase<EntityBase>)
                        {
                            //GridPrintReport.PrintMyGridstatic(((ListBase<EntityBase>)myGridControl.DataSource).ToDataSet(true), ((GridView)myGridControl.MainView));
                            //TODO : Grid Print
                        }
                    }
                    else if (myPivotGridControl != null)
                    {
                        myPivotGridControl.ShowPrintPreview();
                    }
                    else if (mychartControl != null)
                    {
                        mychartControl.ShowPrintPreview();
                    }
                }
                else if (e.Button.Tag.ToString() == "Excel")
                {
                    if (myVGridControl != null)
                    {
                        //SaveFileDialog sv = new SaveFileDialog();
                        //sv.Filter = "Excel Dosya Türü|*.xls|Word Dosya Türü|*.doc|PDF (E-Book) Dosya Türü|*.pdf";
                        //if (sv.ShowDialog() == DialogResult.OK)
                        //{
                        //    if (sv.FileName.EndsWith("xls"))
                        //        myVGridControl.ExportToXls(sv.FileName);
                        //    else if (sv.FileName.EndsWith("doc"))
                        //    {
                        //        myVGridControl.ExportToRtf(sv.FileName);
                        //    }
                        //    else if (sv.FileName.EndsWith("pdf"))
                        //    {
                        //        myVGridControl.ExportToPdf(sv.FileName);
                        //    }
                        //}
                    }
                    else if (myGridControl != null)
                    {
                        SaveFileDialog sv = new SaveFileDialog();
                        sv.Filter = "Excel Dosya Türü|*.xls|Word Dosya Türü|*.doc|PDF (E-Book) Dosya Türü|*.pdf";
                        if (sv.ShowDialog() == DialogResult.OK)
                        {
                            if (sv.FileName.EndsWith("xls"))
                                myGridControl.ExportToXls(sv.FileName);
                            else if (sv.FileName.EndsWith("doc"))
                            {
                                myGridControl.ExportToRtf(sv.FileName);
                            }
                            else if (sv.FileName.EndsWith("pdf"))
                            {
                                myGridControl.ExportToPdf(sv.FileName);
                            }
                        }
                    }
                    else if (myPivotGridControl != null)
                    {
                        SaveFileDialog sv = new SaveFileDialog();
                        sv.Filter = "Excel Dosya Türü|*.xls|Word Dosya Türü|*.doc|PDF (E-Book) Dosya Türü|*.pdf";
                        if (sv.ShowDialog() == DialogResult.OK)
                        {
                            if (sv.FileName.EndsWith("xls"))
                                myPivotGridControl.ExportToXls(sv.FileName);
                            else if (sv.FileName.EndsWith("doc"))
                            {
                                myPivotGridControl.ExportToRtf(sv.FileName);
                            }
                            else if (sv.FileName.EndsWith("pdf"))
                            {
                                myPivotGridControl.ExportToPdf(sv.FileName);
                            }
                        }
                    }
                    else if (mychartControl != null)
                    {
                        SaveFileDialog sv = new SaveFileDialog();
                        sv.Filter = "Excel Dosya Türü|*.xls|Word Dosya Türü|*.doc|PDF (E-Book) Dosya Türü|*.pdf";
                        if (sv.ShowDialog() == DialogResult.OK)
                        {
                            if (sv.FileName.EndsWith("xls"))
                                mychartControl.ExportToXls(sv.FileName);
                            else if (sv.FileName.EndsWith("doc"))
                            {
                                mychartControl.ExportToHtml(sv.FileName);
                            }
                            else if (sv.FileName.EndsWith("pdf"))
                            {
                                mychartControl.ExportToPdf(sv.FileName);
                            }
                        }
                    }
                }
                else if (e.Button.Tag.ToString() == "Mail")
                {
                    if (myVGridControl != null)
                    {
                        SaveFileDialog sv = new SaveFileDialog();
                        sv.Filter = "HTML Dosya Türü|*.htm";
                        if (sv.ShowDialog() == DialogResult.OK)
                        {
                            //myVGridControl.ExportToXls(sv.FileName);
                            myVGridControl.ExportToHtml(sv.FileName);
                            MessageBox.Show("Seçtiðiniz alana HTML formatýnda kaydedilmiþtir. Email gönderebilirsiniz.");
                        }
                    }
                    else if (myGridControl != null)
                    {
                        SaveFileDialog sv = new SaveFileDialog();
                        sv.Filter = "HTML Dosya Türü|*.htm";
                        if (sv.ShowDialog() == DialogResult.OK)
                        {
                            //myGridControl.ExportToXls(sv.FileName);
                            myGridControl.ExportToHtml(sv.FileName);
                            MessageBox.Show("Seçtiðiniz alana HTML formatýnda kaydedilmiþtir.Email gönderebilirsiniz.");
                        }
                    }
                    else if (myPivotGridControl != null)
                    {
                        SaveFileDialog sv = new SaveFileDialog();
                        sv.Filter = "HTML Dosya Türü|*.htm";
                        if (sv.ShowDialog() == DialogResult.OK)
                        {
                            //myGridControl.ExportToXls(sv.FileName);
                            myPivotGridControl.ExportToHtml(sv.FileName);
                            MessageBox.Show("Seçtiðiniz alana HTML formatýnda kaydedilmiþtir.Email gönderebilirsiniz.");
                        }
                    }
                    else if (mychartControl != null)
                    {
                        SaveFileDialog sv = new SaveFileDialog();
                        sv.Filter = "HTML Dosya Türü|*.htm";
                        if (sv.ShowDialog() == DialogResult.OK)
                        {
                            //myGridControl.ExportToXls(sv.FileName);
                            mychartControl.ExportToHtml(sv.FileName);
                            MessageBox.Show("Seçtiðiniz alana HTML formatýnda kaydedilmiþtir.Email gönderebilirsiniz.");
                        }
                    }
                }
                else if (e.Button.Tag.ToString() == "Editor")
                {
                    if (myGridControl != null)
                    {
                        frmEditor editor = new frmEditor();
                        editor.MdiParent = mdiAvukatPro.MainForm;
                        string yol = Tools.TempFilesPath + DateTime.Now.Ticks + ".html";
                        myGridControl.ExportToHtml(yol);
                        editor.OpenFile(yol);
                    }
                    if (myVGridControl != null)
                    {
                        frmEditor editor = new frmEditor();
                        editor.MdiParent = mdiAvukatPro.MainForm;
                        string yol = Tools.TempFilesPath + DateTime.Now.Ticks + ".html";
                        myVGridControl.ExportToHtml(yol);
                        editor.OpenFile(yol);
                    }
                    if (MyPivotGridControl != null)
                    {
                        frmEditor editor = new frmEditor();
                        editor.MdiParent = mdiAvukatPro.MainForm;
                        string yol = Tools.TempFilesPath + DateTime.Now.Ticks + ".html";
                        MyPivotGridControl.ExportToHtml(yol);
                        editor.OpenFile(yol);
                    }
                    if (mychartControl != null)
                    {
                        frmEditor editor = new frmEditor();
                        editor.MdiParent = mdiAvukatPro.MainForm;
                        string yol = Tools.TempFilesPath + DateTime.Now.Ticks + ".html";
                        mychartControl.ExportToHtml(yol);
                        editor.OpenFile(yol);
                    }
                }
                else if (e.Button.Tag.ToString() == "KabulEt")
                {
                    if (myGridControl != null)
                    {
                        if (((GridView)myGridControl.MainView).FocusedRowHandle >= 0)
                        {
                            object o =
                                (myGridControl.MainView).GetRow(((GridView)myGridControl.MainView).FocusedRowHandle);
                            if (o is EntityBase)
                            {
                                object IdValue = AvukatProLib2.Entities.EntityUtil.GetProperty(o, "ID").GetValue(o, null);
                                SelectClick(myGridControl, IdValue, o);
                            }
                            else if (o is System.Data.DataRow)
                            {
                                object IdValue = ((System.Data.DataRow)o)["ID"];
                                SelectClick(myGridControl, IdValue, o);
                            }
                        }
                    }
                    // Added By e
                    else if (myVGridControl != null)
                    {
                        if (myVGridControl.FocusedRecord >= 0)
                        {
                            object o = (myVGridControl.GetRecordObject(myVGridControl.FocusedRecord));
                            if (o is EntityBase)
                            {
                                object IdValue = (((EntityBase)o)["ID"]);
                                SelectClick(myVGridControl, IdValue, o);
                            }
                            else if (o is System.Data.DataRow)
                            {
                                object IdValue = (((System.Data.DataRow)o)["ID"]);
                                SelectClick(myVGridControl, IdValue, o);
                            }
                        }
                    }
                    else if (myPivotGridControl != null)
                    {
                        if (myPivotGridControl.GetFieldList().Length >= 0)
                        {
                            object o = myPivotGridControl.GetFieldList()[0];
                            if (o is EntityBase)
                            {
                                object IdValue = (((EntityBase)o)["ID"]);

                                SelectClick(myPivotGridControl, IdValue, o);
                            }
                            else if (o is System.Data.DataRow)
                            {
                                object IdValue = (((System.Data.DataRow)o)["ID"]);

                                SelectClick(myPivotGridControl, IdValue, o);
                            }
                        }
                    }
                    else if (mychartControl != null)
                    {
                    }
                }
                else if (e.Button.Tag.ToString() == "DigerMenu" && this.MyVGridControl != null)
                {
                    this.MyVGridControl.RowsCustomization();
                }
            }
        }

        //Added By E
        public delegate void OnSelectClick(object sender, object id, object selected);

        /// <summary>
        /// Occurs When Grid Controls Item Select Button Click ...
        /// </summary>
        public event OnSelectClick SelectClick;

        private void EskiHaleGetir()
        {
            Form frm = this.Parent.FindForm();
            this.Parent.Dock = dstyleEski;
            if (this.myVGridControl != null)
                this.myVGridControl.LayoutStyle = viewStyleEski;
            if (this.myGridControl != null)
                this.myGridControl.Dock = gridDStyleEski;

            cntNormal.Controls.Add(this.Parent);
            foreach (Control c in frm.Controls)
            {
                if (!c.Visible && c.Tag != null && c.Tag.ToString() == "[FullScreen]")
                {
                    c.Visible = true;
                }
            }
            isTamEkran = false;
        }

        private void TamEkranYap()
        {
            if (this.Parent is UserControl || this.Parent is XtraUserControl || this.Parent is PanelControl ||
                this.Parent is Panel)
            {
                Form frm = this.FindForm();
                foreach (Control c in frm.Controls)
                {
                    if (c.Visible)
                    {
                        c.Tag = "[FullScreen]";
                        c.Visible = false;
                    }
                }
                frm.Controls.Add(this.Parent);
                dstyleEski = this.Parent.Dock;
                this.Parent.Dock = DockStyle.Fill;
                if (myVGridControl != null)
                {
                    viewStyleEski = this.myVGridControl.LayoutStyle;
                    this.myVGridControl.LayoutStyle = LayoutViewStyle.MultiRecordView;
                }
                if (myGridControl != null)
                {
                    gridDStyleEski = myGridControl.Dock;
                    myGridControl.Dock = DockStyle.Fill;
                }
                isTamEkran = true;
            }
        }

        private DockStyle gridDStyleEski;

        private void verticalgrid_DataSourceChanged(object sender, EventArgs e)
        {
            //this.DataSource = ((GridControl)sender).DataSource;
            this.DataSource = ((VGridControl)sender).DataSource;
            if (this.CustomButtons.Count > 1)
            {
                if (OnListedenGetirClick != null)
                {
                    this.CustomButtons[0].Enabled = true;
                    this.CustomButtons[0].Visible = true;
                }
                if (OnCevirClick != null)
                {
                    this.CustomButtons[1].Enabled = true;
                    this.CustomButtons[1].Visible = true;
                }
            }
        }

        private void gridcontrol_DataSourceChanged(object sender, EventArgs e)
        {
            this.DataSource = ((GridControl)sender).DataSource;
            //this.DataSource = ((VGridControl)sender).DataSource;
            if (this.CustomButtons.Count > 1)
            {
                if (OnListedenGetirClick != null)
                {
                    this.CustomButtons[0].Enabled = true;
                    this.CustomButtons[0].Visible = true;
                }
                if (OnCevirClick != null)
                {
                    this.CustomButtons[1].Enabled = true;
                    this.CustomButtons[1].Visible = true;
                }
            }
        }
    }

    public delegate void ListedenGetirEventHandler(object sender, ListedenGetirEventArgs e);

    public class ListedenGetirEventArgs : EventArgs
    {
        public VGridControl MyVGridControl { get; set; }

        public GridControl MyGridControl { get; set; }

        public PivotGridControl MyPivotGridControl { get; set; }

        public ChartControl MyChartControl { get; set; }

        public bool IsPivot { get; set; }

        public bool IsVerticalGrid { get; set; }

        public bool IsChart { get; set; }
    }
}