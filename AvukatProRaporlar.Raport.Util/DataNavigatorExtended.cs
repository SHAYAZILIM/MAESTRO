//using AvukatProRaporlar.Raport.Util.Properties;
using AvukatProRaporlar.Raport.Util.Properties;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

//using AvukatProRaporlar.Properties;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraVerticalGrid;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AvukatProRaporlar.Raport.Util
{
    public delegate void ListedenGetirEventHandler(object sender, ListedenGetirEventArgs e);

    [System.Drawing.ToolboxBitmap(typeof(DataNavigator))]
    public class DataNavigatorExtended : DataNavigator
    {
        public DataNavigatorExtended()
        {
            this.ParentChanged += new EventHandler(DataNavigatorExtended_ParentChanged);
        }

        private Control cntNormal;

        private DockStyle dstyleEski;

        private DockStyle gridDStyleEski;

        private bool isTamEkran = false;

        private GridControl myGridControl;

        private PivotGridControl myPivotGridControl;

        private VGridControl myVGridControl;

        // Added by e
        private bool selectButtonVisible = false;

        private LayoutViewStyle viewStyleEski;

        //Added By E
        public delegate void OnSelectClick(object sender, object id, object selected);

        public event EventHandler OnCevirClick;

        public event ListedenGetirEventHandler OnListedenGetirClick;

        /// <summary>
        /// Occurs When Grid Controls Item Select Button Click ...
        /// </summary>
        public event OnSelectClick SelectClick;

        [Browsable(true), Category("Xtended Properties")]
        public GridControl MyGridControl
        {
            get { return myGridControl; }
            set
            {
                if (!DesignMode && value != null)
                {
                    value.DataSourceChanged += new EventHandler(gridcontrol_DataSourceChanged);
                }
                myGridControl = value;
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
                    value.DataSourceChanged += new EventHandler(value_DataSourceChanged);
                }
                myPivotGridControl = value;
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
                    value.DataSourceChanged += new EventHandler(verticalgrid_DataSourceChanged);
                }
                myVGridControl = value;
            }
        }

        public bool SelectButtonVisible
        {
            get { return selectButtonVisible; }
            set { selectButtonVisible = value; }
        }

        public void initMe()
        {
            SelectClick += new OnSelectClick(DataNavigatorExtended_SelectClick);
            this.CustomButtons.Clear();
            if (DesignMode)
                return;
            this.Buttons.CancelEdit.Visible = false;
            this.Buttons.NextPage.Visible = false;
            this.Buttons.PrevPage.Visible = false;

            #region buton Resimleri

            ImageList imgList = new ImageList();
            imgList.ColorDepth = ColorDepth.Depth32Bit;

            imgList.ImageSize = new Size(16, 16);

            int index = imgList.Images.Add(Resource1.tarihce, Color.Transparent);
            int index2 = imgList.Images.Add(Resource1.tarihce, Color.Transparent);
            int index3 = imgList.Images.Add(Resource1.tarihce, Color.Transparent);
            int index4 = imgList.Images.Add(Resource1.tarihce, Color.Transparent);
            int index5 = imgList.Images.Add(Resource1.tarihce, Color.Transparent);
            int index6 = imgList.Images.Add(Resource1.tarihce, Color.Transparent);
            int index7 = imgList.Images.Add(Resource1.tarihce, Color.Transparent);
            int index8 = imgList.Images.Add(Resource1.tarihce, Color.Transparent);
            int index9 = imgList.Images.Add(Resource1.tarihce, Color.Transparent);
            int index10 = imgList.Images.Add(Resource1.tarihce, Color.Transparent);
            int index11 = imgList.Images.Add(Resource1.tarihce, Color.Transparent);
            int index12 = imgList.Images.Add(Resource1.tarihce, Color.Transparent);
            int index122 = imgList.Images.Add(Resource1.tarihce, Color.Transparent);

            //ADded by e
            int index13 = imgList.Images.Add(Resource1.tarihce, Color.Transparent);

            //ADded by e
            int index14 = imgList.Images.Add(Resource1.tarihce, Color.Transparent);

            #endregion buton Resimleri

            this.Validated += new EventHandler(DataNavigatorExtended_Validated);

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

            #endregion system tarafýndan ekli olan default butonlarýn resim ve hintleri

            this.ShowToolTips = true;

            bool varmiGetir = false;
            bool varmiCevir = false;
            bool varmiTamEkr = false;
            bool varmiYazdir = false;
            bool varmiExcel = false;
            bool varmiMail = false;

            bool varmiExportToEditor = false;

            bool varmiKabulEt = false;

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
                NavigatorCustomButton exportToEditor = this.CustomButtons.Add();
                exportToEditor.Tag = "Editor";
                exportToEditor.Hint = "Editöre Gönder";
                exportToEditor.ImageIndex = index13;
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

            this.ButtonClick += new NavigatorButtonClickEventHandler(DataNavigatorExtended_ButtonClick);

            this.TextLocation = NavigatorButtonsTextLocation.Center;
            this.TextStringFormat = "Kayýt {0} / {1}";
        }

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
                        arg.IsVerticalGrid = true;
                        arg.MyVGridControl = myVGridControl;
                    }
                    else if (myGridControl != null)
                    {
                        arg.IsVerticalGrid = false;
                        arg.MyGridControl = myGridControl;
                    }
                    else if (myPivotGridControl != null)
                    {
                        arg.IsVerticalGrid = false;
                        arg.MyPivotGridControl = myPivotGridControl;
                        arg.IsPivotgrid = true;
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
                        myGridControl.ShowPrintPreview();
                    }
                    else if (myPivotGridControl != null)
                    {
                        myPivotGridControl.ShowPrintPreview();
                    }
                }
                else if (e.Button.Tag.ToString() == "Excel")
                {
                    if (myVGridControl != null)
                    {
                        SaveFileDialog sv = new SaveFileDialog();
                        sv.Filter = "Excel Dosya Türü|*.xls|Word Dosya Türü|*.doc|PDF (E-Book) Dosya Türü|*.pdf";
                        if (sv.ShowDialog() == DialogResult.OK)
                        {
                            if (sv.FileName.EndsWith("xls"))
                                myVGridControl.ExportToXls(sv.FileName);
                            else if (sv.FileName.EndsWith("doc"))
                            {
                                myVGridControl.ExportToRtf(sv.FileName);
                            }
                            else if (sv.FileName.EndsWith("pdf"))
                            {
                                myVGridControl.ExportToPdf(sv.FileName);
                            }
                        }
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
                            Tools.OpenProgram(sv.FileName);
                            MessageBox.Show("Seçtiðiniz alana HTML formatýnda kaydedilmiþtir.Email gönderebilirsiniz.");
                        }
                    }
                    else if (myPivotGridControl != null)
                    {
                        SaveFileDialog sv = new SaveFileDialog();
                        sv.Filter = "HTML Dosya Türü|*.htm";
                        if (sv.ShowDialog() == DialogResult.OK)
                        {
                            myPivotGridControl.ExportToHtml(sv.FileName);
                            MessageBox.Show("Seçtiðiniz alana HTML formatýnda kaydedilmiþtir. Email gönderebilirsiniz.");
                        }
                    }
                }

                    //Added By e
                else if (e.Button.Tag.ToString() == "Editor")
                {
                    if (myGridControl != null)
                    {
                        //TODO : editor de ;Aç ...
                    }
                }

                    //Added By e
                else if (e.Button.Tag.ToString() == "KabulEt")
                {
                    if (myGridControl != null)
                    {
                        if (((GridView)myGridControl.MainView).FocusedRowHandle >= 0)
                        {
                            object o = ((GridView)myGridControl.MainView).GetRow(((GridView)myGridControl.MainView).FocusedRowHandle);

                            // TODO : Tip Kontrol
                            if (o is object)
                            {
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
                            object o = ((GridView)myVGridControl.GetRecordObject(myVGridControl.FocusedRecord));
                            if (o is object)
                            {
                                object IdValue = o; //(((object)o)["ID"]);

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
                        //TODO : Pivoty Grid için Yazzýlacak
                        //if (myPivotGridControl. >= 0)
                        //{
                        //    object o = ((GridView)myPivotGridControl.GetFieldValue(myPivotGridControl.foc myVGridControl.FocusedRecord));
                        //    if (o is object)
                        //    {
                        //        object IdValue = o; //(((object)o)["ID"]);

                        // SelectClick(myVGridControl, IdValue, o);

                        // } else if (o is System.Data.DataRow) { object IdValue =
                        // (((System.Data.DataRow)o)["ID"]);

                        // SelectClick(myVGridControl, IdValue, o);

                        // }

                        //}
                    }
                }
            }
        }

        private void DataNavigatorExtended_ParentChanged(object sender, EventArgs e)
        {
            initMe();
        }

        private void DataNavigatorExtended_SelectClick(object sender, object id, object selected)
        {
        }

        private void DataNavigatorExtended_Validated(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

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

        private void TamEkranYap()
        {
            if (this.Parent is UserControl || this.Parent is XtraUserControl || this.Parent is PanelControl || this.Parent is Panel)
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

        private void value_DataSourceChanged(object sender, EventArgs e)
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
    }

    public class ListedenGetirEventArgs : EventArgs
    {
        public ListedenGetirEventArgs()
        {
        }

        private bool isPivot;
        private bool isVertical;
        private GridControl myGridControl;
        private PivotGridControl myPivotGridControl;
        private VGridControl myVGridControl;

        public bool IsPivotgrid
        {
            get { return isPivot; }
            set { isPivot = value; }
        }

        public bool IsVerticalGrid
        {
            get { return isVertical; }
            set { isVertical = value; }
        }

        public GridControl MyGridControl
        {
            get { return myGridControl; }
            set { myGridControl = value; }
        }

        public PivotGridControl MyPivotGridControl
        {
            get { return myPivotGridControl; }
            set { myPivotGridControl = value; }
        }

        public VGridControl MyVGridControl
        {
            get { return myVGridControl; }
            set { myVGridControl = value; }
        }
    }
}