using DevExpress.XtraEditors;

namespace AvukatPro.IcraTakipWin.UserControls
{
    [System.Drawing.ToolboxBitmap(typeof(DataNavigator))]
    public class DataNavigatorExtended : AdimAdimDavaKaydi.Util.DataNavigatorExtended
    {
        //private Control cntNormal;
        //private DockStyle dstyleEski;
        //private bool isTamEkran = false;
        //private ExtendedGridControl myGridControl;
        //private VGridControl myVGridControl;
        //private LayoutViewStyle viewStyleEski;
        //public DataNavigatorExtended()
        //{
        //    this.ParentChanged += new EventHandler(DataNavigatorExtended_ParentChanged);
        //}

        //void DataNavigatorExtended_ParentChanged(object sender, EventArgs e)
        //{
        //    initMe();
        //}

        //public void initMe()
        //{
        //    this.CustomButtons.Clear();
        //    if (DesignMode)
        //        return;
        //    this.Buttons.CancelEdit.Visible = false;
        //    this.Buttons.NextPage.Visible = false;
        //    this.Buttons.PrevPage.Visible = false;

        //    ImageList imgList = new ImageList();
        //    imgList.ColorDepth = ColorDepth.Depth32Bit;
        //    imgList.ImageSize = new Size(22,22);
        //    int index = imgList.Images.Add(Resources.kod, Color.Transparent);
        //    int index2 = imgList.Images.Add(Resources.OZEL01_mavi, Color.Transparent);
        //    int index3 = imgList.Images.Add(Resources.tam_ekran1, Color.Transparent);
        //    int index4 = imgList.Images.Add(Resources.print_printer, Color.Transparent);
        //    int index5 = imgList.Images.Add(Resources.page_excel, Color.Transparent);
        //    int index6 = imgList.Images.Add(Resources.message2, Color.Transparent);
        //    int index7 = imgList.Images.Add(Resources.yeni_kayit, Color.Transparent);
        //    this.Validated += new EventHandler(DataNavigatorExtended_Validated);
        //    this.Buttons.ImageList = imgList;
        //    this.Buttons.Append.ImageIndex = index7;
        //    bool varmiGetir = false;
        //    bool varmiCevir = false;
        //    bool varmiTamEkr = false;
        //    bool varmiYazdir = false;
        //    bool varmiExcel = false;
        //    bool varmiMail = false;
        //    for (int i = 0; i < CustomButtons.Count; i++)
        //    {
        //        if(CustomButtons[i].Tag != null && CustomButtons[i].Tag.ToString() == "Getir")
        //        {
        //            varmiGetir = true;
        //        }
        //        else if (CustomButtons[i].Tag != null && CustomButtons[i].Tag.ToString() == "Cevir")
        //        {
        //            varmiCevir = true;
        //        }
        //        else if (CustomButtons[i].Tag != null && CustomButtons[i].Tag.ToString() == "TamEkr")
        //        {
        //            varmiTamEkr= true;
        //        }
        //        else if (CustomButtons[i].Tag != null && CustomButtons[i].Tag.ToString() == "Yazdir")
        //        {
        //            varmiYazdir = true;
        //        }
        //        else if (CustomButtons[i].Tag != null && CustomButtons[i].Tag.ToString() == "Excel")
        //        {
        //            varmiExcel = true;
        //        }
        //        else if (CustomButtons[i].Tag != null && CustomButtons[i].Tag.ToString() == "Mail")
        //        {
        //            varmiMail = true;
        //        }
        //    }
        //    if (!varmiGetir)
        //    {
        //        NavigatorCustomButton btn = this.CustomButtons.Add();
        //        btn.Enabled = false;
        //        btn.Visible = false;
        //        btn.Tag = "Getir";
        //        btn.Hint = "Listeden Getir";
        //        btn.ImageIndex = index;
        //    }
        //    if(!varmiCevir)
        //    {
        //        NavigatorCustomButton cevir = this.CustomButtons.Add();
        //        cevir.Enabled = false;
        //        cevir.Visible = false;
        //        cevir.Tag = "Cevir";
        //        cevir.Hint = "Liste/Form Görünümü";
        //        cevir.ImageIndex = index2;

        //    }
        //    if (!varmiTamEkr)
        //    {
        //        NavigatorCustomButton tamekr = this.CustomButtons.Add();
        //        tamekr.Tag = "TamEkr";
        //        tamekr.Hint = "Tam Ekran";
        //        tamekr.ImageIndex = index3;
        //    }
        //    if (!varmiYazdir)
        //    {
        //        NavigatorCustomButton print = this.CustomButtons.Add();
        //        print.Tag = "Yazdir";
        //        print.Hint = "Yazdýr";
        //        print.ImageIndex = index4;
        //    }
        //    if (!varmiExcel)
        //    {
        //        NavigatorCustomButton print = this.CustomButtons.Add();
        //        print.Tag = "Excel";
        //        print.Hint = "Export";
        //        print.ImageIndex = index5;
        //    }
        //    if (!varmiMail)
        //    {
        //        NavigatorCustomButton print = this.CustomButtons.Add();
        //        print.Tag = "Mail";
        //        print.Hint = "Email Olarak Gönder";
        //        print.ImageIndex = index6;
        //    }

        //        this.ButtonClick += new NavigatorButtonClickEventHandler(DataNavigatorExtended_ButtonClick);

        //    this.TextLocation = NavigatorButtonsTextLocation.Center;
        //    this.TextStringFormat = "Kayýt {0} / {1}";
        //}

        //void DataNavigatorExtended_Validated(object sender, EventArgs e)
        //{
        //    //throw new Exception("The method or operation is not implemented.");
        //}

        //[Browsable(true), Category("Xtended Properties")]
        //public ExtendedGridControl MyGridControl
        //{
        //    get { return myGridControl; }
        //    set
        //    {
        //        if (!DesignMode && value != null)
        //        {
        //            value.DataSourceChanged += new EventHandler(gridcontrol_DataSourceChanged);
        //        }
        //        myGridControl = value;
        //    }
        //}

        //[Browsable(true), Category("Xtended Properties")]
        //public VGridControl MyVGridControl
        //{
        //    get { return myVGridControl; }
        //    set
        //    {
        //        if (!DesignMode && value != null)
        //        {
        //            value.DataSourceChanged += new EventHandler(verticalgrid_DataSourceChanged);
        //        }
        //        myVGridControl = value;
        //    }
        //}

        //public event ListedenGetirEventHandler OnListedenGetirClick;
        //public event EventHandler OnCevirClick;

        //private void DataNavigatorExtended_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Custom)
        //    {
        //        if (e.Button.Tag.ToString() == "Getir")
        //        {
        //            if (OnListedenGetirClick == null)
        //                return;

        //            ListedenGetirEventArgs arg = new ListedenGetirEventArgs();
        //            if (myVGridControl != null)
        //            {
        //                arg.IsVerticalGrid = true;
        //                arg.MyVGridControl = myVGridControl;
        //            }
        //            else if (myGridControl != null)
        //            {
        //                arg.IsVerticalGrid = false;
        //                arg.MyGridControl = myGridControl;
        //            }
        //            OnListedenGetirClick(this, arg);
        //        }
        //        else if (e.Button.Tag.ToString() == "Cevir")
        //        {
        //            if (OnCevirClick != null)
        //                OnCevirClick(this, new EventArgs());
        //        }
        //        else if (e.Button.Tag.ToString() == "TamEkr")
        //        {
        //            if (!isTamEkran)
        //            {
        //                if (cntNormal == null && this.Parent != null && this.Parent.Parent != null)
        //                {
        //                    cntNormal = this.Parent.Parent;
        //                }
        //                TamEkranYap();
        //            }
        //            else
        //                EskiHaleGetir();
        //        }
        //        else if (e.Button.Tag.ToString() == "Yazdir")
        //        {
        //            if(myVGridControl !=null)
        //            {
        //                myVGridControl.ShowPrintPreview();
        //                //TList<AV001_TD_BIL_FOY> fd = new TList<AV001_TD_BIL_FOY>();
        //                //fd.ToDataSet(false);
        //                //TList<EntityBase> tmpdd = (TList<EntityBase>) myVGridControl.DataSource;
        //                //GridPrintReport.PrintMyGridstatic(myVGridControl,tmpdd.);
        //                //GridPrintReport.PrintMyGrid()
        //            }else if (myGridControl != null)
        //            {
        //                myGridControl.ShowPrintPreview();
        //            }
        //        }
        //        else if (e.Button.Tag.ToString() == "Excel")
        //        {
        //            if (myVGridControl != null)
        //            {
        //                SaveFileDialog sv = new SaveFileDialog();
        //                sv.Filter = "Excel Dosya Türü|*.xls|Word Dosya Türü|*.doc|PDF (E-Book) Dosya Türü|*.pdf";
        //                if(sv.ShowDialog() == DialogResult.OK)
        //                {
        //                    if (sv.FileName.EndsWith("xls"))
        //                        myVGridControl.ExportToXls(sv.FileName);
        //                    else if(sv.FileName.EndsWith("doc"))
        //                    {
        //                        myVGridControl.ExportToRtf(sv.FileName);
        //                    }
        //                    else if(sv.FileName.EndsWith("pdf"))
        //                    {
        //                        myVGridControl.ExportToPdf(sv.FileName);

        //                    }

        //                }
        //            }
        //            else if (myGridControl != null)
        //            {
        //                SaveFileDialog sv = new SaveFileDialog();
        //                sv.Filter = "Excel Dosya Türü|*.xls|Word Dosya Türü|*.doc|PDF (E-Book) Dosya Türü|*.pdf";
        //                if (sv.ShowDialog() == DialogResult.OK)
        //                {
        //                    if (sv.FileName.EndsWith("xls"))
        //                        myGridControl.ExportToXls(sv.FileName);
        //                    else if (sv.FileName.EndsWith("doc"))
        //                    {
        //                        myGridControl.ExportToRtf(sv.FileName);
        //                    }
        //                    else if (sv.FileName.EndsWith("pdf"))
        //                    {
        //                        myGridControl.ExportToPdf(sv.FileName);

        //                    }

        //                }
        //            }
        //        }
        //        else if (e.Button.Tag.ToString() == "Mail")
        //        {
        //            if (myVGridControl != null)
        //            {
        //                SaveFileDialog sv = new SaveFileDialog();
        //                sv.Filter = "HTML Dosya Türü|*.htm";
        //                if (sv.ShowDialog() == DialogResult.OK)
        //                {
        //                   //myVGridControl.ExportToXls(sv.FileName);
        //                    myVGridControl.ExportToHtml(sv.FileName);
        //                    MessageBox.Show("Seçtiðiniz alana HTML formatýnda kaydedilmiþtir. Email gönderebilirsiniz.");
        //                }
        //            }
        //            else if (myGridControl != null)
        //            {
        //                SaveFileDialog sv = new SaveFileDialog();
        //                sv.Filter = "HTML Dosya Türü|*.htm";
        //                if (sv.ShowDialog() == DialogResult.OK)
        //                {
        //                    //myGridControl.ExportToXls(sv.FileName);
        //                    myGridControl.ExportToHtml(sv.FileName);
        //                    MessageBox.Show("Seçtiðiniz alana HTML formatýnda kaydedilmiþtir.Email gönderebilirsiniz.");
        //                }
        //            }
        //        }
        //    }
        //}

        //private void EskiHaleGetir()
        //{
        //    Form frm = FormuGetir(this.Parent);
        //    this.Parent.Dock = dstyleEski;
        //    this.myVGridControl.LayoutStyle = viewStyleEski;
        //    cntNormal.Controls.Add(this.Parent);
        //    foreach (Control c in frm.Controls)
        //    {
        //        if (!c.Visible && c.Tag != null && c.Tag.ToString() == "[FullScreen]")
        //        {
        //            c.Visible = true;
        //        }
        //    }
        //    isTamEkran = false;
        //}

        //private void TamEkranYap()
        //{
        //    if (this.Parent is UserControl || this.Parent is XtraUserControl)
        //    {
        //        Form frm = FormuGetir(this.Parent);
        //        foreach (Control c in frm.Controls)
        //        {
        //            if (c.Visible)
        //            {
        //                c.Tag = "[FullScreen]";
        //                c.Visible = false;
        //            }
        //        }
        //        frm.Controls.Add(this.Parent);
        //        dstyleEski = this.Parent.Dock;
        //        this.Parent.Dock = DockStyle.Fill;
        //        if (myVGridControl != null)
        //        {
        //            viewStyleEski = this.myVGridControl.LayoutStyle;
        //            this.myVGridControl.LayoutStyle = LayoutViewStyle.MultiRecordView;
        //        }
        //        isTamEkran = true;
        //    }
        //}

        //private Form FormuGetir(Control c)
        //{
        //    if (c is Form || c is XtraForm)
        //    {
        //        return (Form) c;
        //    }
        //    else
        //    {
        //        return FormuGetir(c.Parent);
        //    }
        //}

        //private void verticalgrid_DataSourceChanged(object sender, EventArgs e)
        //{
        //    //this.DataSource = ((GridControl)sender).DataSource;
        //    this.DataSource = ((VGridControl) sender).DataSource;
        //    if (this.CustomButtons.Count > 1)
        //    {
        //        if (OnListedenGetirClick != null)
        //        {
        //            this.CustomButtons[0].Enabled = true;
        //            this.CustomButtons[0].Visible = true;
        //        }
        //        if (OnCevirClick != null)
        //        {
        //            this.CustomButtons[1].Enabled = true;
        //            this.CustomButtons[1].Visible = true;
        //        }
        //    }
        //}

        //private void gridcontrol_DataSourceChanged(object sender, EventArgs e)
        //{
        //    this.DataSource = ((GridControl) sender).DataSource;
        //    //this.DataSource = ((VGridControl)sender).DataSource;
        //    if (this.CustomButtons.Count > 1)
        //    {
        //        if (OnListedenGetirClick != null)
        //        {
        //            this.CustomButtons[0].Enabled = true;
        //            this.CustomButtons[0].Visible = true;
        //        }
        //        if (OnCevirClick != null)
        //        {
        //            this.CustomButtons[1].Enabled = true;
        //            this.CustomButtons[1].Visible = true;
        //        }
        //    }
        //}
    }
}