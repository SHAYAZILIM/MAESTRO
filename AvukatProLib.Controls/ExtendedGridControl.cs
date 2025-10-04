using AvukatProLib.Controls.Grid.CustomFiltering;
using DevExpress.Utils;

//using AdimAdimDavaKaydi.Properties;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.FilterEditor;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

//using GridRapor;
//using AvukatProLib2.Entities;
//using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
//using AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

//using AvukatProLib2.Data;

namespace AvukatProLib.Controls
{
    public enum NavImages
    {
        Getir,
        Cevir,
        TamEkran,
        Yazdir,
        Export,
        Email,
        Ekle,
        Tamamla,
        Ileri,
        Geri,
        Son,
        Ilk,
        Sil,
        Editor,
        Kisisellestir,
        Html,
        Doc,
        Pdf,
        KolayKayit,
    }

    public static class Cast<T>
    {
        public static T It(object o)
        {
            return (T)o;
        }
    }

    ///<summary>
    ///
    ///</summary>
    //[ToolboxBitmap(typeof(AvukatProLib.Controls.ExtendedGridControl))]
    public class ExtendedGridControl : GridControl, IExtendedGridControl
    {
        ///<summary>
        ///
        ///</summary>
        public ExtendedGridControl()
        {
            this.ViewRepository.Changed += ViewRepository_Changed;
            this.Load += ExtendedGridControl_Load;
            this.MouseDown += ExtendedGridControl_MouseDown;
            this.DataSourceChanged += ExtendedGridControl_DataSourceChanged;

            //this.RightClickPopup.MyGridControl = this;
        }

        public PopupMenu popupMenu1;
        public PopupMenu popupMenu2;
        private bool _DoNotExtendEmbedNavigator;
        private string _MyGridStyle;

        private bool _showRowNumbers;

        private string _UniqueId;

        private BarManager barMen;

        public bool ShowRowNumbers
        {
            get { return _showRowNumbers; }
            set
            {
                _showRowNumbers = value;
                if (value)
                {
                    if (this.MainView is GridView)
                    {
                        GridView gvMain = ((GridView)this.MainView);
                        gvMain.IndicatorWidth = gvMain.RowCount.ToString().Length * 10 + 8;
                    }
                }
                else
                {
                    if (this.MainView is GridView)
                    {
                        GridView gvMain = ((GridView)this.MainView);
                        gvMain.IndicatorWidth = 20;
                    }
                }
            }
        }

        public string UniqueId
        {
            get
            {
                if (String.IsNullOrEmpty(_UniqueId))
                    _UniqueId = Guid.NewGuid().ToString();
                return _UniqueId;
            }
            set
            {
                if (String.IsNullOrEmpty(_UniqueId))
                {
                    _UniqueId = value;
                }
            }
        }

        /// <summary>
        /// Grid renklendirme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                throw new InvalidAsynchronousStateException("Olmadý");
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
            Form1 frm = new Form1();
            if (this.MainView is GridView)
            {
                frm.Grid = (GridView)this.MainView;
                frm.ShowDialog();
            }
            else
            {
                frm.Dispose();
                XtraMessageBox.Show("Bu özellik sadece liste grid ile kullanýlabilir");//TODO:Resx den okunacak.
            }
        }

        /// <summary>
        /// Email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                GridControl gc = Cast<GridControl>.It(Cast<ControlNavigator>.It(sender).NavigatableControl);

                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "HTML Dosya Türü|*.htm";
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    //myVGridControl.ExportToXls(sv.FileName);
                    gc.ExportToHtml(sv.FileName);
                    MessageBox.Show("Seçtiðiniz alana HTML formatýnda kaydedilmiþtir. Email gönderebilirsiniz.");
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        /// <summary>
        /// Seçimli biçimlendirme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmXGridStyleChooser frm = new frmXGridStyleChooser();
            //frm.ShowMe(this);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.FocusedView is GridView)
            {
                GridView gridView = (GridView)this.FocusedView;
                gridView.ShowCustomization();
            }
        }

        private void barCheckGruplananiGoster_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ((GridView)this.MainView).OptionsView.ShowGroupedColumns = ((BarCheckItem)e.Item).Checked;
        }

        private void barCheckHucreBirlestir_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ((GridView)this.MainView).OptionsView.AllowCellMerge = ((BarCheckItem)e.Item).Checked;
            ((GridView)this.MainView).OptionsView.ShowPreview = !((BarCheckItem)e.Item).Checked;
            for (int i = 0; i < popupMenu1.ItemLinks.Count; i++)
            {
                if (popupMenu1.ItemLinks[i].Item.Caption == "Önizleme Göster")
                    if (popupMenu1.ItemLinks[i].Item is BarCheckItem)
                        ((BarCheckItem)popupMenu1.ItemLinks[i].Item).Checked = !((BarCheckItem)e.Item).Checked;
            }
        }

        private void barCheckOnIzlemeGoster_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ((GridView)this.MainView).OptionsView.ShowPreview = ((BarCheckItem)e.Item).Checked;
        }

        /// <summary>
        /// Satir numaralarýný Gosterecek olan buton týklandýgýnda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbItmSatirSayisi_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Satir numaralarýný gosterme  seçeneði ayarlandý .
            this.ShowRowNumbers = !this.ShowRowNumbers;
        }

        private void btnexpExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExportIt(1);
        }

        private void btnexpHtml_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExportIt(4);
        }

        private void btnexpPdf_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExportIt(3);
        }

        private void btnexpWord_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExportIt(2);
        }

        private void btnFilterFormAc_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmFiltreYonetim frm = new frmFiltreYonetim();
            // frm.Show(this);
        }

        private void btnGonder1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //GridControl gc = Cast<GridControl>.It(Cast<ControlNavigator>.It(sender).NavigatableControl);
            //uctxEditor editor = new uctxEditor();
            //RibbonControl rc = new RibbonControl();
            //RibbonForm rf = new RibbonForm();
            //rc.ApplicationIcon = Resources.avukatpro7_40x40;
            //rc.Dock = DockStyle.Top;
            //rf.Controls.Add(editor);
            //rf.Controls.Add(rc);
            //editor.Dock = DockStyle.Fill;
            //editor.BringToFront();
            //rf.Show();

            //frmEditor editorum = new frmEditor();
            //editorum.Show();
            //editorum.CurrentEditor.LoadFromGridControl(this);

            //editor.LoadFromGridControl(this);
        }

        /// <summary>
        /// Report Designer a Gönder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGonder2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //GridPrintReport.Raporla(this);;
        }

        /// <summary>
        /// Mail Olarak Gönder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGonder3_ItemClick(object sender, ItemClickEventArgs e)
        {
            //GridPrintReport.MailIt(this);
        }

        /// <summary>
        /// Print Preview (Önizleme) Rapor Öznizleme ile Karýþtýrýlmamamlý farklý bir pencere
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGonder4_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowPrintPreview();
        }

        private void btnSaveLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string _path = Application.StartupPath + "\\layouts\\" + _UniqueId + "\\";
                if (!Directory.Exists(_path))
                {
                    Directory.CreateDirectory(_path);
                }
                foreach (BaseView view in this.ViewCollection)
                {
                    string filePath = _path + view.Name + ".yyl";
                    view.SaveLayoutToXml(filePath, OptionsLayoutBase.FullLayout);

                    string stylePath = _path + view.Name + ".yys";
                    GridAyar ayarim = new GridAyar();
                    if (view is GridView)
                    {
                        GridView gv = (GridView)view;

                        ayarim.StyleConditions = new List<Bilgi>();
                        foreach (StyleFormatCondition cnd in gv.FormatConditions)
                        {
                            ayarim.StyleConditions.Add(cnd.Tag as Bilgi);
                        }
                    }
                    if (view.Tag is string)
                        ayarim.MyCustomStyle = view.Tag.ToString();

                    //System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new BinaryFormatter();
                    XmlSerializer xm = new XmlSerializer(typeof(GridAyar));

                    FileStream fs = new FileStream(stylePath, FileMode.Create);

                    //bf.Serialize(fs,ayarim);
                    xm.Serialize(fs, ayarim);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index">0 Excel - 1 Word -2 Pdf -3 html</param>
        private void ExportIt(int index)
        {
            try
            {
                ExtendedGridControl gc = this;
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "Excel Dosya Türü|*.xls|Word Dosya Türü|*.doc|PDF (E-Book) Dosya Türü|*.pdf|HTML Web Sayfasý|*.html";
                sv.FilterIndex = index;
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    if (sv.FileName.EndsWith("xls"))
                    {
                        gc.ExportToXls(sv.FileName);
                    }
                    else if (sv.FileName.EndsWith("doc"))
                    {
                        gc.ExportToRtf(sv.FileName);
                    }
                    else if (sv.FileName.EndsWith("pdf"))
                    {
                        gc.ExportToPdf(sv.FileName);
                    }
                    else if (sv.FileName.EndsWith("html"))
                    {
                        gc.ExportToHtml(sv.FileName);
                    }
                    System.Diagnostics.Process.Start(sv.FileName);
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void ExtendedGridControl_ButtonEditorClick(object sender, NavigatorButtonClickEventArgs e)
        {
            GridControlNavigator nav = (GridControlNavigator)sender;
            Form frm = nav.FindForm();

            Point pnt = Control.MousePosition;
            int k = (popupMenu1.ItemLinks.Count * 25) + 20;
            pnt.Y = pnt.Y - k;
            if (popupMenu2.Opened)
            {
                popupMenu2.HidePopup();
            }
            else
            {
                popupMenu2.ShowPopup(pnt);
            }
        }

        private void ExtendedGridControl_ButtontakipiSil(object sender, NavigatorButtonClickEventArgs e)
        {
            ((sender as ExtendedGridControl).MainView as GridView).DeleteSelectedRows();
        }

        private void ExtendedGridControl_ButtonYeniEkle(object sender, NavigatorButtonClickEventArgs e)
        {
            ((sender as ExtendedGridControl).MainView as GridView).AddNewRow();
        }

        private void ExtendedGridControl_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView gonderen = (GridView)sender;
            ColumnView view = gonderen;

            for (int i = 0; i < view.ActiveFilter.Count; i++)
            {
                ViewColumnFilterInfo flt = view.ActiveFilter[i];
                if (flt.Filter.Type == ColumnFilterType.AutoFilter && flt.Filter.Kind == ColumnFilterKind.User && !flt.Filter.FilterString.Contains("Like '%"))
                    flt.Filter = new ColumnFilterInfo(ColumnFilterType.AutoFilter, flt.Filter.Value, flt.Filter.FilterString.Replace("Like '", "Like '%"));
            }
        }

        /// <summary>
        ///  Satir numaralarýný GHosteren  Event tir . Burada Ýndicator draw olacaktýr ve her satýr için Draw iþleminde o satýrýn numarasý yazýlacaktýr.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtendedGridControl_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            ///Satir numaralý gosterilsin iþaretlenmiþ ise
            if (_showRowNumbers)
            {
                //Satýr numarasý 0 dan kucukse bu en ust satýr yani Kolonlarýn bulunduðu satýrdýr.
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
            }
        }

        private void ExtendedGridControl_DataSourceChanged(object sender, EventArgs e)
        {
            //if (this.MainView is GridView)
            //{
            //    foreach (GridColumn column in (this.MainView as GridView).Columns)
            //    {
            //        // Null Referans hatasý Patlattý -  Gökhan
            //       // column.BestFit();
            //    }

            //}
        }

        #region GridMenu

        //protected UserControls.compGridRightClickMenu _rightClickPopup; // = new AdimAdimDavaKaydi.UserControls.compGridRightClickMenu();

        //public UserControls.compGridRightClickMenu RightClickPopup
        //{
        //    get
        //    {
        //        if (_rightClickPopup != null)
        //            return _rightClickPopup;
        //        else
        //        {
        //            _rightClickPopup = new AdimAdimDavaKaydi.UserControls.compGridRightClickMenu();
        //            return _rightClickPopup;
        //        }

        //    }
        //    set
        //    {
        //        _rightClickPopup = value;
        //    }

        //}

        private void DoShowMenu(DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi)
        {
            DevExpress.XtraGrid.Menu.GridViewMenu menu = null;
            if (hi.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.ColumnButton)
            {
                menu = new GridViewColumnButtonMenu(((GridView)this.MainView));
                menu.Init(hi);
                menu.Show(hi.HitPoint);
            }
        }

        private void ExtendedGridControl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this.MainView is GridView)
                DoShowMenu(((GridView)this.MainView).CalcHitInfo(new Point(e.X, e.Y)));
        }

        #endregion GridMenu

        private void ExtendedGridControl_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            initOncekiAyarlar();
            initPopupMenu();
            initPopupMenu2();
            this.ButtonYazdirClick += EmbedDataNavigatorExtender_ButtonYazdirClick;
            this.ButtonTamEkranClick += EmbedDataNavigatorExtender_ButtonTamEkranClick;
            this.ButtonExportClick += EmbedDataNavigatorExtender_ButtonExportClick;
            this.ButtonEditorClick += ExtendedGridControl_ButtonEditorClick;
            this.ButtonMailClick += EmbedDataNavigatorExtender_ButtonMailClick;
            this.ButtonYeniEkle += ExtendedGridControl_ButtonYeniEkle;
            this.ButtontakipiSil += ExtendedGridControl_ButtontakipiSil;

            initHyperDragDrop();
            initMe(this);

            GridsFilterSettings.SetViewFilter(this);
            GridsFilterSettings filterSet = new GridsFilterSettings();
            filterSet.SetGridControlsFilterEvents(this);

            ///gridView Baþlýgýnýn Geniþliðini ayrladýk ki orada satýr numaralarý için yeterli yer olsun
            if (this.MainView is GridView)
            {
                GridView gvMain = ((GridView)this.MainView);

                ///Satir Numaralarýný Eklemek için Indicator draw da Row Count lar grafiðe çiziliyor.
                gvMain.CustomDrawRowIndicator += ExtendedGridControl_CustomDrawRowIndicator;
            }
        }

        #region IExtendedGridControl Members

        private GridFilterControl _filterControl;
        private string _filterText;
        private string _filterValue;

        public string FilterText
        {
            get { return _filterText; }
            set { _filterText = value; }
        }

        public string FilterValue
        {
            get { return _filterValue; }
            set { _filterValue = value; }
        }

        public GridFilterControl GridsFilterControl
        {
            get { return _filterControl; }
            set { _filterControl = value; }
        }

        #endregion IExtendedGridControl Members

        private void ExtendedGridControl_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;
                if (menu.Column != null)
                {
                    //TODO:Resources dan string olarak çek
                    menu.Items.Add(CreateCheckItem("Kilitsiz", menu.Column, FixedStyle.None, GridResimleri.lock_open));
                    menu.Items.Add(CreateCheckItem("Sola Kilitle", menu.Column, FixedStyle.Left, GridResimleri.gridex_SolaKilitle_16x16));
                    menu.Items.Add(CreateCheckItem("Saða Kilitle", menu.Column, FixedStyle.Right, GridResimleri.gridex_SagaKilitle_16x16));

                    //Group Interval
                    if (menu.Column.ColumnType == typeof(DateTime) || menu.Column.ColumnType == typeof(DateTime?))
                    {
                        DXMenuItem baslangic = CreateMenuItem("Tarih'e göre grupla", menu.Column, ColumnGroupInterval.Date);
                        baslangic.BeginGroup = true;
                        menu.Items.Add(baslangic);
                        menu.Items.Add(CreateMenuItem("Tarih(Ay)'e göre grupla", menu.Column, ColumnGroupInterval.DateMonth));
                        menu.Items.Add(CreateMenuItem("Tarih(Aralýk)'e göre grupla", menu.Column, ColumnGroupInterval.DateRange));
                        menu.Items.Add(CreateMenuItem("Tarih(Yýl)'e göre grupla", menu.Column, ColumnGroupInterval.DateYear));
                    }
                    else
                    {
                        DXMenuItem baslangic = CreateMenuItem("Alfabetik grupla", menu.Column, ColumnGroupInterval.Alphabetical);
                        baslangic.BeginGroup = true;
                        menu.Items.Add(baslangic);
                    }
                    menu.Items.Add(CreateMenuItem("Varsayýlan grupla", menu.Column, ColumnGroupInterval.Default));
                    menu.Items.Add(CreateMenuItem("Ýçeriðe göre grupla", menu.Column, ColumnGroupInterval.DisplayText));
                    menu.Items.Add(CreateMenuItem("Deðer'e göre grupla", menu.Column, ColumnGroupInterval.Value));
                }
            }
        }

        private void initGridStyleCon(GridView gv, GridAyar ayarVer)
        {
            foreach (Bilgi bilgi in ayarVer.StyleConditions)
            {
                gv.FormatConditions.Add(Form1.ConvertBilgiToSFC(bilgi, gv));
            }
            if (!String.IsNullOrEmpty(ayarVer.MyCustomStyle))
                frmXGridStyleChooser.xs.LoadScheme(ayarVer.MyCustomStyle, gv);
        }

        private void initGridStyleCon(BaseView vw, GridAyar ayarVer)
        {
            if (!String.IsNullOrEmpty(ayarVer.MyCustomStyle))
                frmXGridStyleChooser.xs.LoadScheme(ayarVer.MyCustomStyle, vw);
        }

        private void initOncekiAyarlar()
        {
            if (DesignMode)
                return;
            try
            {
                string _path = Application.StartupPath + "\\layouts\\" + _UniqueId + "\\";
                if (Directory.Exists(_path))
                {
                    foreach (BaseView view in this.ViewCollection)
                    {
                        string filePath = _path + view.Name + ".yyl";
                        string stylePath = _path + view.Name + ".yys";
                        if (File.Exists(filePath))
                            view.RestoreLayoutFromXml(filePath);
                        if (File.Exists(stylePath))
                        {
                            //BinaryFormatter bf = new BinaryFormatter();
                            XmlSerializer xm = new XmlSerializer(typeof(GridAyar));
                            FileStream fs = File.OpenRead(stylePath);
                            GridAyar ayar = xm.Deserialize(fs) as GridAyar;
                            if (ayar != null)
                                if (view is GridView)
                                    initGridStyleCon((GridView)view, ayar);
                                else
                                    initGridStyleCon(view, ayar);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void initPopupMenu()
        {
            if (barMen == null)
                barMen = new BarManager();
            barMen.Images = MyImageList;
            popupMenu1 = new PopupMenu(barMen);
            BarButtonItem barButtonItem1 = new BarButtonItem(barMen, "Koþullu biçimlendirme", MyImageIndexes[NavImages.Kisisellestir]);

            barButtonItem1.ItemClick += barButtonItem1_ItemClick;
            popupMenu1.AddItem(barButtonItem1);

            BarCheckItem bbItmSatirSayisi = new BarCheckItem(barMen, false);
            bbItmSatirSayisi.Caption = "Satýr Sayýsý Göster";
            bbItmSatirSayisi.ItemClick += bbItmSatirSayisi_ItemClick;
            popupMenu1.AddItem(bbItmSatirSayisi);

            BarButtonItem barButtonItem2 = new BarButtonItem(barMen, "Email Olarak Gönder", MyImageIndexes[NavImages.Email]);
            barButtonItem2.ItemClick += barButtonItem2_ItemClick;
            popupMenu1.AddItem(barButtonItem2);
            BarButtonItem barButtonItem3 = new BarButtonItem(barMen, "Seçimli biçimlendirme", MyImageIndexes[NavImages.Kisisellestir]);
            barButtonItem3.ItemClick += barButtonItem3_ItemClick;
            popupMenu1.AddItem(barButtonItem3);
            BarButtonItem barButtonItem4 = new BarButtonItem(barMen, "Alan Seçimi", MyImageIndexes[NavImages.Kisisellestir]);
            barButtonItem4.ItemClick += barButtonItem4_ItemClick;
            popupMenu1.AddItem(barButtonItem4);

            BarSubItem bbtnExport = new BarSubItem(barMen, "Export (Baþka Programda Aç)", MyImageIndexes[NavImages.Export]);  //new BarButtonItem(barMen, "", MyImageIndexes[NavImages.Kisisellestir]);

            //barButtonItem4.ItemClick += new ItemClickEventHandler(barButtonItem4_ItemClick);

            #region Export

            BarButtonItem btnexpExcel = new BarButtonItem(barMen, "Excel (.xls)", MyImageIndexes[NavImages.Export]);
            btnexpExcel.ItemClick += new ItemClickEventHandler(btnexpExcel_ItemClick);
            bbtnExport.AddItem(btnexpExcel);
            BarButtonItem btnexpWord = new BarButtonItem(barMen, "Word (.doc)", MyImageIndexes[NavImages.Doc]);
            btnexpWord.ItemClick += new ItemClickEventHandler(btnexpWord_ItemClick);
            bbtnExport.AddItem(btnexpWord);
            BarButtonItem btnexpPdf = new BarButtonItem(barMen, "E-Book (.pdf)", MyImageIndexes[NavImages.Pdf]);
            btnexpPdf.ItemClick += new ItemClickEventHandler(btnexpPdf_ItemClick);
            bbtnExport.AddItem(btnexpPdf);
            BarButtonItem btnexpHtml = new BarButtonItem(barMen, "Web Sayfasý (.html)", MyImageIndexes[NavImages.Html]);
            btnexpHtml.ItemClick += new ItemClickEventHandler(btnexpHtml_ItemClick);
            bbtnExport.AddItem(btnexpHtml);

            #endregion Export

            popupMenu1.AddItem(bbtnExport);
            BarButtonItem btnSaveLayout = new BarButtonItem(barMen, "Görünümü Kaydet", MyImageIndexes[NavImages.Kisisellestir]);
            btnSaveLayout.ItemClick += btnSaveLayout_ItemClick;
            popupMenu1.AddItem(btnSaveLayout);
            BarButtonItem btnFilterFormAc = new BarButtonItem(barMen, "Filtre Düzenleme", MyImageIndexes[NavImages.Kisisellestir]);
            btnFilterFormAc.ItemClick += btnFilterFormAc_ItemClick;
            popupMenu1.AddItem(btnFilterFormAc);

            #region Hücre birleþtir

            bool allwCellMerge = false;
            bool showGrpClm = false;
            bool allwEnabled = false;
            bool showPreview = false;
            if (this.MainView is GridView)
            {
                GridView gv = ((GridView)this.MainView);
                allwCellMerge = gv.OptionsView.AllowCellMerge;
                showGrpClm = gv.OptionsView.ShowGroupedColumns;
                showPreview = gv.OptionsView.ShowPreview;
                allwEnabled = true;
            }
            BarCheckItem barCheckHucreBirlestir = new BarCheckItem(barMen, allwCellMerge);
            barCheckHucreBirlestir.Caption = "Tekrarlayaný Birleþtir";
            barCheckHucreBirlestir.Enabled = allwEnabled;
            barCheckHucreBirlestir.CheckedChanged += new ItemClickEventHandler(barCheckHucreBirlestir_CheckedChanged);

            BarCheckItem barCheckGruplananiGoster = new BarCheckItem(barMen, showGrpClm);
            barCheckGruplananiGoster.Caption = "Gruplananý Göster";
            barCheckGruplananiGoster.Enabled = allwEnabled;
            barCheckGruplananiGoster.CheckedChanged += new ItemClickEventHandler(barCheckGruplananiGoster_CheckedChanged);

            BarCheckItem barCheckOnIzlemeGoster = new BarCheckItem(barMen, showPreview);
            barCheckOnIzlemeGoster.Caption = "Önizleme Göster";
            barCheckOnIzlemeGoster.Enabled = allwEnabled;
            barCheckOnIzlemeGoster.CheckedChanged += new ItemClickEventHandler(barCheckOnIzlemeGoster_CheckedChanged);

            popupMenu1.AddItems(new BarItem[]
                                            {
                                                barCheckGruplananiGoster,
                                                barCheckOnIzlemeGoster,
                                                barCheckHucreBirlestir
                                            });

            #endregion Hücre birleþtir
        }

        private void initPopupMenu2()
        {
            //TODO:Burdaki menü yazýlarý özelleþtirilecek(Gönderme Menüsü) [YY]
            if (barMen == null)
                barMen = new BarManager();
            barMen.Images = MyImageList;
            popupMenu2 = new PopupMenu(barMen);
            BarButtonItem btnGonder1 = new BarButtonItem(barMen, "Editore Gönder", MyImageIndexes[NavImages.Kisisellestir]);
            btnGonder1.ItemClick += btnGonder1_ItemClick;
            popupMenu2.AddItem(btnGonder1);
            BarButtonItem btnGonder2 = new BarButtonItem(barMen, "Rapora Gönder", MyImageIndexes[NavImages.Kisisellestir]);
            btnGonder2.ItemClick += btnGonder2_ItemClick;
            popupMenu2.AddItem(btnGonder2);
            BarButtonItem btnGonder3 = new BarButtonItem(barMen, "Mail olarak Gönder", MyImageIndexes[NavImages.Kisisellestir]);
            btnGonder3.ItemClick += btnGonder3_ItemClick;
            popupMenu2.AddItem(btnGonder3);
            BarButtonItem btnGonder4 = new BarButtonItem(barMen, "Önizlemeye Gönder", MyImageIndexes[NavImages.Kisisellestir]);
            btnGonder4.ItemClick += btnGonder4_ItemClick;
            popupMenu2.AddItem(btnGonder4);
        }

        private void ViewRepository_Changed(object sender, CollectionChangeEventArgs e)
        {
            if (e.Element is GridView && e.Action == CollectionChangeAction.Add)
            {
                ((GridView)e.Element).ShowGridMenu += ExtendedGridControl_ShowGridMenu;
                ((GridView)e.Element).ColumnFilterChanged += ExtendedGridControl_ColumnFilterChanged;
            }
        }

        #region New column menu

        private DXMenuCheckItem CreateCheckItem(string caption, GridColumn column, FixedStyle style, Image image)
        {
            DXMenuCheckItem item = new DXMenuCheckItem(caption, column.Fixed == style, image, new EventHandler(OnFixedClick));
            item.Tag = new MenuInfo(column, style);
            return item;
        }

        private DXMenuItem CreateMenuItem(string caption, GridColumn column, ColumnGroupInterval interval)
        {
            DXMenuItem item = new DXMenuItem(caption, new EventHandler(OnClmGroupInterval));
            item.Tag = new ColumnGrpItervalInfo(column, interval);
            return item;
        }

        private void OnClmGroupInterval(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            ColumnGrpItervalInfo info = item.Tag as ColumnGrpItervalInfo;
            if (info == null) return;
            info.Column.GroupInterval = info.Interval;
        }

        private void OnFixedClick(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            MenuInfo info = item.Tag as MenuInfo;
            if (info == null) return;
            info.Column.Fixed = info.Style;
        }

        private class ColumnGrpItervalInfo
        {
            public ColumnGrpItervalInfo(GridColumn column, ColumnGroupInterval interval)
            {
                Column = column;
                Interval = interval;
            }

            public GridColumn Column;
            public ColumnGroupInterval Interval;
        }

        private class MenuInfo
        {
            public MenuInfo(GridColumn column, FixedStyle style)
            {
                this.Column = column;
                this.Style = style;
            }

            public GridColumn Column;

            public FixedStyle Style;
        }

        #endregion New column menu

        #region DataNavigatorExtended

        private static Dictionary<NavImages, int> _MyImageIndexes = new Dictionary<NavImages, int>();
        private static ImageList _MyImageList;

        private Control _cntNormal;

        private ExtendedGridControl _tamEkran;

        private bool customButtonlarGorunmesin = false;

        private bool temizleKaldirGorunsun = false;

        public event EventHandler<NavigatorButtonClickEventArgs> ButtonCevirClick;

        public event EventHandler<NavigatorButtonClickEventArgs> ButtonClick;

        public event EventHandler<NavigatorButtonClickEventArgs> ButtonEditorClick;

        public event EventHandler<NavigatorButtonClickEventArgs> ButtonExportClick;

        public event EventHandler<NavigatorButtonClickEventArgs> ButtonGetirClick;

        public event EventHandler<NavigatorButtonClickEventArgs> ButtonMailClick;

        public event EventHandler<NavigatorButtonClickEventArgs> ButtontakipiSil;

        public event EventHandler<NavigatorButtonClickEventArgs> ButtonTamEkranClick;

        public event EventHandler<NavigatorButtonClickEventArgs> ButtonTumunuKaldir;

        public event EventHandler<NavigatorButtonClickEventArgs> ButtonTumunuSec;

        public event EventHandler<NavigatorButtonClickEventArgs> ButtonYazdirClick;

        public event EventHandler<NavigatorButtonClickEventArgs> ButtonYeniEkle;

        [Browsable(false)]
        public static Dictionary<NavImages, int> MyImageIndexes
        {
            get { return _MyImageIndexes; }
            set { _MyImageIndexes = value; }
        }

        [Browsable(false)]
        public static ImageList MyImageList
        {
            get
            {
                if (_MyImageList == null)
                {
                    ImageList imgList = new ImageList();
                    imgList.ColorDepth = ColorDepth.Depth32Bit;
                    imgList.ImageSize = new Size(12, 12);
                    if (MyImageIndexes == null)
                    {
                        MyImageIndexes = new Dictionary<NavImages, int>();
                    }
                    int index = imgList.Images.Add(GridResimleri.dnext_12x12_getir, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Getir, index);
                    int index2 = imgList.Images.Add(GridResimleri.dnext_12x12_cevir, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Cevir, index2);
                    int index3 = imgList.Images.Add(GridResimleri.dnext_12x12_fscreen, Color.Transparent);
                    MyImageIndexes.Add(NavImages.TamEkran, index3);
                    int index4 = imgList.Images.Add(GridResimleri.dnext_12x12_printer, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Yazdir, index4);
                    int index5 = imgList.Images.Add(GridResimleri.dnext_12x12_excel, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Export, index5);
                    int index6 = imgList.Images.Add(GridResimleri.dnext_12x12_email, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Email, index6);
                    int index7 = imgList.Images.Add(GridResimleri.dnext_12x12_add, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Ekle, index7);
                    int index8 = imgList.Images.Add(GridResimleri.dnext_12x12_tick, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Tamamla, index8);
                    int index9 = imgList.Images.Add(GridResimleri.dnext_12x12_next, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Ileri, index9);
                    int index10 = imgList.Images.Add(GridResimleri.dnext_12x12_previous, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Geri, index10);
                    int index11 = imgList.Images.Add(GridResimleri.dnext_12x12_last, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Son, index11);
                    int index12 = imgList.Images.Add(GridResimleri.dnext_12x12_first, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Ilk, index12);
                    int index122 = imgList.Images.Add(GridResimleri.dnext_12x12_delete, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Sil, index122);
                    int index13 = imgList.Images.Add(GridResimleri.dnext_12x12_editor, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Editor, index13);
                    int index14 = imgList.Images.Add(GridResimleri.favorite_22x221, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Kisisellestir, index14);
                    int index15 = imgList.Images.Add(GridResimleri.html, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Html, index15);
                    int index16 = imgList.Images.Add(GridResimleri.doc, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Doc, index16);
                    int index17 = imgList.Images.Add(GridResimleri.pdf, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Pdf, index17);
                    _MyImageList = imgList;
                    int index18 = imgList.Images.Add(GridResimleri.sihirbaz1_16x16, Color.Transparent);
                    MyImageIndexes.Add(NavImages.KolayKayit, index18);

                    return _MyImageList;
                }
                else
                {
                    return _MyImageList;
                }
            }
        }

        [Category("Extended Properties")]
        public bool CustomButtonlarGorunmesin
        {
            get { return customButtonlarGorunmesin; }
            set { customButtonlarGorunmesin = value; }
        }

        /// <summary>
        /// Embeded Navigator u extend etmek istemediðinizde true yapabilirsiniz.
        /// </summary>
        [Category("Extended Properties")]
        public bool DoNotExtendEmbedNavigator
        {
            get { return _DoNotExtendEmbedNavigator; }
            set { _DoNotExtendEmbedNavigator = value; }
        }

        public string MyGridStyle
        {
            get { return _MyGridStyle; }
            set { _MyGridStyle = value; }
        }

        [Category("Extended Properties")]
        public bool TemizleKaldirGorunsunmu
        {
            get { return temizleKaldirGorunsun; }
            set { temizleKaldirGorunsun = value; }
        }

        /// <summary>
        /// HyperDragdrop özelliðini açar ve nesne tipinden sürüklemeyi etkin kýlar.
        /// </summary>
        [Category("Extended Properties")]
        public bool UseHyperDragDrop
        {
            get { return _UseHyperDragDrop; }
            set { _UseHyperDragDrop = value; }
        }

        private void EmbedDataNavigatorExtender_ButtonExportClick(object sender, NavigatorButtonClickEventArgs e)
        {
            try
            {
                GridControl gc = Cast<GridControl>.It(Cast<ControlNavigator>.It(sender).NavigatableControl);
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "Excel Dosya Türü|*.xls|Word Dosya Türü|*.doc|PDF (E-Book) Dosya Türü|*.pdf";

                if (sv.ShowDialog() == DialogResult.OK)
                {
                    if (sv.FileName.EndsWith("xls"))
                    {
                        gc.ExportToXls(sv.FileName);
                    }
                    else if (sv.FileName.EndsWith("doc"))
                    {
                        gc.ExportToRtf(sv.FileName);
                    }
                    else if (sv.FileName.EndsWith("pdf"))
                    {
                        gc.ExportToPdf(sv.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        //private void MsgKayitBulunamadi()
        //{
        //    XtraMessageBox.Show("Ýlgili Kayýt Bulunamadý");
        //}
        private void EmbedDataNavigatorExtender_ButtonMailClick(object sender, NavigatorButtonClickEventArgs e)
        {
            GridControlNavigator nav = (GridControlNavigator)sender;
            Form frm = nav.FindForm();
            Point pnt = Control.MousePosition;
            int k = (popupMenu1.ItemLinks.Count * 25) + 20;
            pnt.Y = pnt.Y - k;
            if (popupMenu1.Opened)
            {
                popupMenu1.HidePopup();
            }
            else
            {
                popupMenu1.ShowPopup(pnt);
            }
        }

        //public void ClickEmbededNavigatorButton(R_BIRLESIK_TAKIPLER_TARAFLI_SORUMLULU takip)
        //{
        //    TakipEkraninaGonder(takip.Tipi, takip.ID);
        //}
        private void EmbedDataNavigatorExtender_ButtonTamEkranClick(object sender, NavigatorButtonClickEventArgs e)
        {
            try
            {
                ExtendedGridControl gc = this;
                if (_tamEkran == gc)
                {
                    EskiHaleGetir(gc);
                    _tamEkran = null;
                }
                else if (_tamEkran == null)
                {
                    TamEkranYap(gc);

                    _tamEkran = gc;
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void EmbedDataNavigatorExtender_ButtonYazdirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            try
            {
                GridControl gc = Cast<GridControl>.It(Cast<ControlNavigator>.It(sender).NavigatableControl);

                //GridPrintReport.Raporla(gc);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
                switch (e.Button.Tag.ToString())
                {
                    case "Editor":
                        if (ButtonEditorClick != null)
                        {
                            ButtonEditorClick(sender, e);
                        }
                        break;

                    case "Mail":
                        if (ButtonMailClick != null)
                        {
                            ButtonMailClick(sender, e);
                        }
                        break;

                    case "Excel":
                        if (ButtonExportClick != null)
                        {
                            ButtonExportClick(sender, e);
                        }
                        break;

                    case "Yazdir":
                        if (ButtonYazdirClick != null)
                        {
                            ButtonYazdirClick(sender, e);
                        }
                        break;

                    case "Cevir":
                        if (ButtonCevirClick != null)
                        {
                            ButtonCevirClick(sender, e);
                        }
                        break;

                    case "Getir":
                        if (ButtonGetirClick != null)
                        {
                            ButtonGetirClick(sender, e);
                        }
                        break;

                    case "TamEkr":
                        if (ButtonTamEkranClick != null)
                        {
                            ButtonTamEkranClick(sender, e);
                        }
                        break;

                    case "TumunuSec":
                        if (ButtonTumunuSec != null)
                        {
                            ButtonTumunuSec(sender, e);
                        }
                        break;

                    case "TumunuKaldir":
                        if (ButtonTumunuKaldir != null)
                        {
                            ButtonTumunuKaldir(sender, e);
                        }
                        break;

                    case "YeniEkle":
                        if (ButtonYeniEkle != null)
                        {
                            ButtonYeniEkle(sender, e);
                        }
                        break;

                    case "takipiSil":
                        if (ButtontakipiSil != null)
                        {
                            ButtontakipiSil(sender, e);
                        }
                        break;
                }
            if (ButtonClick != null)
            {
                ButtonClick(sender, e);
            }
        }

        private void EskiHaleGetir(GridControl gc)
        {
            Form frm = gc.FindForm();
            gc.Dock = (DockStyle)gc.Tag;
            Control gz = gc.Parent;
            _cntNormal.Controls.Add(gc);
            gz.Dispose();
            foreach (Control c in frm.Controls)
            {
                if (!c.Visible && c.Tag != null && c.Tag.ToString() == "[FullScreen]")
                {
                    c.Visible = true;
                }
            }
        }

        private void initMe(GridControl gridControl)
        {
            if (DesignMode)
                return;
            if (gridControl == null)
                return;
            //gridControl.UseEmbeddedNavigator = true;
            gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            gridControl.EmbeddedNavigator.ShowToolTips = true;
            gridControl.EmbeddedNavigator.Buttons.BeginUpdate();
            gridControl.EmbeddedNavigator.Buttons.ImageList = MyImageList;

            //gridControl.FindForm().Controls.Add(MyImageList);
            gridControl.EmbeddedNavigator.Buttons.Append.ImageIndex = MyImageIndexes[NavImages.Ekle];
            gridControl.EmbeddedNavigator.Buttons.Append.Hint = "Yeni bir kayýt ekler";
            gridControl.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = MyImageIndexes[NavImages.Tamamla];
            gridControl.EmbeddedNavigator.Buttons.EndEdit.Hint = "Geçerli kaydý tamamlar";
            gridControl.EmbeddedNavigator.Buttons.Next.ImageIndex = MyImageIndexes[NavImages.Ileri];
            gridControl.EmbeddedNavigator.Buttons.Next.Hint = "Bir sonraki kayýt";
            gridControl.EmbeddedNavigator.Buttons.Prev.ImageIndex = MyImageIndexes[NavImages.Geri];
            gridControl.EmbeddedNavigator.Buttons.Prev.Hint = "Bir önceki kayýt";
            gridControl.EmbeddedNavigator.Buttons.NextPage.ImageIndex = MyImageIndexes[NavImages.Son];
            gridControl.EmbeddedNavigator.Buttons.NextPage.Hint = "Bir sonraki kayýt dizisi";
            gridControl.EmbeddedNavigator.Buttons.First.ImageIndex = MyImageIndexes[NavImages.Ilk];
            gridControl.EmbeddedNavigator.Buttons.First.Hint = "Ýlk kayýt";
            gridControl.EmbeddedNavigator.Buttons.Last.ImageIndex = MyImageIndexes[NavImages.Son];
            gridControl.EmbeddedNavigator.Buttons.Last.Hint = "Son kayýt";
            gridControl.EmbeddedNavigator.Buttons.PrevPage.ImageIndex = MyImageIndexes[NavImages.Ilk];
            gridControl.EmbeddedNavigator.Buttons.PrevPage.Hint = "Bir önceki kayýt dizisi";
            gridControl.EmbeddedNavigator.Buttons.Remove.ImageIndex = MyImageIndexes[NavImages.Sil];
            gridControl.EmbeddedNavigator.Buttons.Remove.Hint = "Geçerli kaydý siler";

            //for (int i = 0; i < gridControl.EmbeddedNavigator.CustomButtons.Count; i++)
            //{
            //    if (gridControl.EmbeddedNavigator.CustomButtons[i].Tag != null && gridControl.EmbeddedNavigator.CustomButtons[i].Tag.ToString() == "Getir")
            //    {
            //        varmiGetir = true;
            //        gridControl.EmbeddedNavigator.CustomButtons[i].ImageIndex = index;
            //        gridControl.EmbeddedNavigator.CustomButtons[i].Hint = "Varolan kayýtlar arasýndan getir";
            //    }
            //    else if (gridControl.EmbeddedNavigator.CustomButtons[i].Tag != null && gridControl.EmbeddedNavigator.CustomButtons[i].Tag.ToString() == "Cevir")
            //    {
            //        varmiCevir = true;
            //        gridControl.EmbeddedNavigator.CustomButtons[i].ImageIndex = index2;
            //        gridControl.EmbeddedNavigator.CustomButtons[i].Hint = "Liste / Form Görünüm";
            //    }
            //    else if (gridControl.EmbeddedNavigator.CustomButtons[i].Tag != null && gridControl.EmbeddedNavigator.CustomButtons[i].Tag.ToString() == "TamEkr")
            //    {
            //        varmiTamEkr = true;
            //        gridControl.EmbeddedNavigator.CustomButtons[i].ImageIndex = index3;
            //        gridControl.EmbeddedNavigator.CustomButtons[i].Hint = "Tam Ekran";
            //    }
            //    else if (gridControl.EmbeddedNavigator.CustomButtons[i].Tag != null && gridControl.EmbeddedNavigator.CustomButtons[i].Tag.ToString() == "Yazdir")
            //    {
            //        varmiYazdir = true;
            //        gridControl.EmbeddedNavigator.CustomButtons[i].ImageIndex = index4;
            //        gridControl.EmbeddedNavigator.CustomButtons[i].Hint = "Yazdýr";
            //    }

            //}
            //gridControl.EmbeddedNavigator.CustomButtons.Clear();
            //NavigatorCustomButton btn = gridControl.EmbeddedNavigator.CustomButtons.Add();
            //btn.Enabled = false;
            //btn.Visible = false;
            //btn.Tag = "Getir";
            //btn.Hint = "Listeden Getir";
            //btn.ImageIndex = MyImageIndexes[NavImages.Getir];
            if (!customButtonlarGorunmesin)
            {
                NavigatorCustomButton cevir = gridControl.EmbeddedNavigator.CustomButtons.Add();
                cevir.Enabled = true;
                cevir.Visible = true;
                cevir.Tag = "Cevir";
                cevir.Hint = "Görünüm Deðiþtir";
                cevir.ImageIndex = MyImageIndexes[NavImages.Cevir];

                NavigatorCustomButton tamekr = gridControl.EmbeddedNavigator.CustomButtons.Add();
                tamekr.Tag = "TamEkr";
                tamekr.Hint = "Tam Ekran";
                tamekr.ImageIndex = MyImageIndexes[NavImages.TamEkran];

                NavigatorCustomButton print = gridControl.EmbeddedNavigator.CustomButtons.Add();
                print.Tag = "Yazdir";
                print.Hint = "Yazdýr";
                print.ImageIndex = MyImageIndexes[NavImages.Yazdir];

                //NavigatorCustomButton excel = gridControl.EmbeddedNavigator.CustomButtons.Add();
                //excel.Tag = "Excel";
                //excel.Hint = "Baþka bir programa gönder (Export)";
                //excel.ImageIndex = MyImageIndexes[NavImages.Export];

                NavigatorCustomButton mail = gridControl.EmbeddedNavigator.CustomButtons.Add();
                mail.Tag = "Mail";
                mail.Hint = "Diðer Seçenekler";
                mail.ImageIndex = MyImageIndexes[NavImages.Kisisellestir];

                NavigatorCustomButton exportToEditor = gridControl.EmbeddedNavigator.CustomButtons.Add();
                exportToEditor.Tag = "Editor";
                exportToEditor.Hint = "Editöre Gönder";
                exportToEditor.ImageIndex = MyImageIndexes[NavImages.Editor];
            }
            if (temizleKaldirGorunsun)
            {
                NavigatorCustomButton btnTemizle = gridControl.EmbeddedNavigator.CustomButtons.Add();
                btnTemizle.Tag = "TumunuSec";
                btnTemizle.Hint = "Tümünü Seç";
                btnTemizle.ImageIndex = MyImageIndexes[NavImages.Tamamla];

                NavigatorCustomButton btnKaldir = gridControl.EmbeddedNavigator.CustomButtons.Add();
                btnKaldir.Tag = "TumunuKaldir";
                btnKaldir.Hint = "Tümünü Kaldýr";
                btnKaldir.ImageIndex = MyImageIndexes[NavImages.Sil];
            }
            gridControl.EmbeddedNavigator.ButtonClick += new NavigatorButtonClickEventHandler(EmbeddedNavigator_ButtonClick);
            gridControl.EmbeddedNavigator.Buttons.EndUpdate();
        }

        //public void TakipEkraninaGonder(string takipTipi, int? foyId)
        //{
        //    switch (takipTipi)
        //    {
        //        case "Icra":

        //            if (!foyId.HasValue)
        //            {
        //                MsgKayitBulunamadi();
        //                break;
        //            }

        //            AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip frmIcra = new AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip();
        //            AV001_TI_BIL_FOY icraFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(foyId.Value);
        //            TList<AV001_TI_BIL_FOY> icraFoyListesi = new TList<AV001_TI_BIL_FOY>();
        //            icraFoyListesi.Add(icraFoy);
        //            frmIcra.Show(icraFoyListesi);
        //            break;
        //        case "Dava":

        //            if (!foyId.HasValue)
        //            {
        //                MsgKayitBulunamadi();
        //                break;
        //            }
        //            AV001_TD_BIL_FOY davaFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(foyId.Value);
        //            TList<AV001_TD_BIL_FOY> davaFoyListesi = new TList<AV001_TD_BIL_FOY>();
        //            davaFoyListesi.Add(davaFoy);
        //            AdimAdimDavaKaydi.DavaTakip.frmDavaTakip frmDava = new AdimAdimDavaKaydi.DavaTakip.frmDavaTakip();
        //            frmDava.Show(davaFoyListesi);
        //            break;
        //        case "Soruþturma":
        //            if (!foyId.HasValue)
        //            {
        //                MsgKayitBulunamadi();
        //                break;
        //            }
        //            AV001_TD_BIL_HAZIRLIK hazirlik = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(foyId.Value);
        //            TList<AV001_TD_BIL_HAZIRLIK> hazirlikListesi = new TList<AV001_TD_BIL_HAZIRLIK>();
        //            hazirlikListesi.Add(hazirlik);
        //            AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip frmSorusturma = new AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip();
        //            frmSorusturma.Show(hazirlikListesi);
        //            break;
        //        default:
        //            XtraMessageBox.Show(string.Format("{0} Takip Ekranýna Gönderme Yapým Aþamasýnda", takipTipi));
        //            break;
        //    }

        //}

        private void sbtn_Click(object sender, EventArgs e)
        {
            EmbedDataNavigatorExtender_ButtonTamEkranClick(this, null);
        }

        //public void ClickEmbededNavigatorButton(R_BIRLESIK_TAKIPLER_TUMU_TEXT takip)
        //{
        //    TakipEkraninaGonder(takip.Tipi, takip.ID);
        //}
        //public void ClickEmbededNavigatorButton(ICRA_PRATIK_ARAMA takip)
        //{
        //    TakipEkraninaGonder("Icra", takip.ID);
        //}
        private void TamEkranYap(GridControl gc)
        {
            Form frm = gc.FindForm();
            if (frm != null)
            {
                foreach (Control c in frm.Controls)
                {
                    if (c.Visible)
                    {
                        c.Tag = "[FullScreen]";
                        c.Visible = false;
                    }
                }
                _cntNormal = gc.Parent;

                //frm.Controls.Add(gc);
                PanelControl panelControl = new PanelControl();
                SimpleButton sbtn = new SimpleButton();
                panelControl.Controls.Add(sbtn);
                sbtn.Dock = DockStyle.Top;
                sbtn.Image = MyImageList.Images[MyImageIndexes[NavImages.TamEkran]];
                sbtn.Text = "Tam Ekraný Kapat";
                sbtn.Click += new EventHandler(sbtn_Click);
                panelControl.Controls.Add(gc);
                panelControl.Dock = DockStyle.Fill;
                gc.BringToFront();
                gc.Visible = true;
                gc.Tag = gc.Dock;

                gc.Dock = DockStyle.Fill;
                frm.Controls.Add(panelControl);
            }
        }

        #endregion DataNavigatorExtended

        #region HyperDragDrop

        private bool _UseHyperDragDrop;

        private void ExtendedGridControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (this.MainView is GridView)
                {
                    GridView gv = (GridView)this.MainView;
                    GridHitInfo hi = gv.CalcHitInfo(e.Location);
                    if (hi.IsValid && hi.InRow)
                    {
                        object toDrag = gv.GetRow(hi.RowHandle);
                        if (toDrag != null)
                        {
                            this.DoDragDrop(toDrag, DragDropEffects.Copy);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        private void initHyperDragDrop()
        {
            if (_UseHyperDragDrop)
            {
                this.MouseMove += new MouseEventHandler(ExtendedGridControl_MouseMove);
            }
        }

        #endregion HyperDragDrop
    }

    public class GridViewColumnButtonMenu : GridViewMenu
    {
        public GridViewColumnButtonMenu(DevExpress.XtraGrid.Views.Grid.GridView view)
            : base(view)
        {
        }

        protected override void CreateItems()
        {
            Items.Clear();
            DXSubMenuItem columnsItem = new DXSubMenuItem("Alan Seçimi");
            Items.Add(columnsItem);
            Items.Add(CreateMenuItem("Alan Düzenleme", GridMenuImages.Column.Images[3], "Customization", true));
            foreach (GridColumn column in View.Columns)
            {
                if (column.OptionsColumn.ShowInCustomizationForm)
                    columnsItem.Items.Add(CreateMenuCheckItem(column.Caption, column.VisibleIndex >= 0, null, column, true));
            }
        }

        protected override void OnMenuItemClick(object sender, EventArgs e)
        {
            if (RaiseClickEvent(sender, null)) return;
            DXMenuItem item = sender as DXMenuItem;
            if (item.Tag == null) return;
            if (item.Tag is GridColumn)
            {
                GridColumn column = item.Tag as GridColumn;
                column.VisibleIndex = column.VisibleIndex >= 0 ? -1 : View.VisibleColumns.Count;
            }
            else if (item.Tag.ToString() == "Customization") View.ColumnsCustomization();
        }
    }
}