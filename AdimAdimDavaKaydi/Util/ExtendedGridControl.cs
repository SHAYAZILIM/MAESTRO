using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.FilterEditor;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;

namespace AdimAdimDavaKaydi.Util
{
    ///<summary>
    ///
    ///</summary>
    [ToolboxBitmap(typeof(AdimAdimDavaKaydi.Util.ExtendedGridControl))]
    public class ExtendedGridControl : GridControl, AdimAdimDavaKaydi.Util.Grid.CustomFiltering.IExtendedGridControl
    {
        ///<summary>
        ///
        ///</summary>
        public ExtendedGridControl()
        {
            this.ViewRepository.Changed += ViewRepository_Changed;
            this.Load += ExtendedGridControl_Load;

            #region <GKN-20090721>

            //Bug : Hata Oluþturuyor

            this.MouseDown += ExtendedGridControl_MouseDown;

            #endregion </GKN-20090721>

            this.DataSourceChanged += ExtendedGridControl_DataSourceChanged;
            this.RightClickPopup.MyGridControl = this;
            this.RightClickPopup.PopupOpening += new EventHandler<AdimAdimDavaKaydi.UserControls.PopupOpeningEventArgs>(RightClickPopup_PopupOpening);
            this.RightClickPopup.PopupButtonClick += new EventHandler<ItemClickEventArgs>(RightClickPopup_PopupButtonClick);
        }

        private void RightClickPopup_PopupButtonClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Name == "bButonTarafIletisimBilgileri")
            {
                frmCariGenelGiris cariForms = new frmCariGenelGiris();
                switch (e.Item.Tag.GetType().Name)
                {
                    case "AV001_TI_BIL_FOY_TARAF":
                        var tarafIcra = e.Item.Tag as AV001_TI_BIL_FOY_TARAF;
                        AV001_TDI_BIL_CARI cari = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(tarafIcra.CARI_ID.Value);
                        cariForms.YeniKayitMi = false;
                        cariForms.MyCari = cari;
                        cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        cariForms.Show();
                        break;
                    case "AV001_TD_BIL_FOY_TARAF":
                        var tarafDava = e.Item.Tag as AV001_TD_BIL_FOY_TARAF;
                        AV001_TDI_BIL_CARI cariDava = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(tarafDava.CARI_ID.Value);
                        cariForms.YeniKayitMi = false;
                        cariForms.MyCari = cariDava;
                        cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        cariForms.Show();
                        break;
                    default:
                        break;
                }
            }
            else if (e.Item.Name == "bButonTarafKimlikBilgileri")
            {
                frmCariGenelGiris cariForms = new frmCariGenelGiris();
                switch (e.Item.Tag.GetType().Name)
                {
                    case "AV001_TI_BIL_FOY_TARAF":
                        var tarafIcra = e.Item.Tag as AV001_TI_BIL_FOY_TARAF;
                        AV001_TDI_BIL_CARI cari = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(tarafIcra.CARI_ID.Value);
                        cariForms.YeniKayitMi = false;
                        cariForms.SeciliPage = 1;
                        cariForms.MyCari = cari;
                        cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        cariForms.Show();
                        break;
                    case "AV001_TD_BIL_FOY_TARAF":
                        var tarafDava = e.Item.Tag as AV001_TD_BIL_FOY_TARAF;
                        AV001_TDI_BIL_CARI cariDava = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(tarafDava.CARI_ID.Value);
                        cariForms.YeniKayitMi = false;
                        cariForms.SeciliPage = 1;
                        cariForms.MyCari = cariDava;
                        cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        cariForms.Show();
                        break;
                    default:
                        break;
                }
            }
            else if (e.Item.Name == "bButonTarafGelismeBilgileri")
            {
                switch (e.Item.Tag.GetType().Name)
                {
                    case "AV001_TI_BIL_FOY_TARAF":
                        IcraTakipForms.frmIcraTarafGelismeler gelisme = new AdimAdimDavaKaydi.IcraTakipForms.frmIcraTarafGelismeler();
                        var tarafIcra = e.Item.Tag as AV001_TI_BIL_FOY_TARAF;
                        gelisme.CurrentCariID = tarafIcra.CARI_ID;
                        if (tarafIcra.ICRA_FOY_ID.HasValue)
                            gelisme.MyFoy = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.GetByID(tarafIcra.ICRA_FOY_ID.Value);
                        gelisme.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        gelisme.Show();
                        break;
                    default:
                        break;
                }
            }
        }

        private void RightClickPopup_PopupOpening(object sender, AdimAdimDavaKaydi.UserControls.PopupOpeningEventArgs e)
        {
            switch (e.Rows.GetType().Name)
            {
                case "AV001_TI_BIL_FOY_TARAF":
                    BarButtonItem bus2 = new BarButtonItem(e.Manager, "Taraf Adres ve Ýletiþim Bilgileri Getir");
                    bus2.Tag = e.Rows;
                    bus2.Name = "bButonTarafIletisimBilgileri";
                    bus2.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Administrator_3_22x221;
                    e.MyPopupMenu.ItemLinks.Insert(1, bus2);
                    BarButtonItem bus3 = new BarButtonItem(e.Manager, "Taraf Kimlik Bilgileri Getir");
                    bus3.Tag = e.Rows;
                    bus3.Name = "bButonTarafKimlikBilgileri";
                    bus3.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Administrator_3_22x221;
                    e.MyPopupMenu.ItemLinks.Insert(1, bus3);
                    BarButtonItem bus4 = new BarButtonItem(e.Manager, "Kesinleþme Süreci Getir");
                    bus4.Tag = e.Rows;
                    bus4.Name = "bButonTarafGelismeBilgileri";
                    bus4.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Administrator_3_22x221;
                    e.MyPopupMenu.ItemLinks.Insert(1, bus4);
                    break;
                case "AV001_TD_BIL_FOY_TARAF":
                    BarButtonItem bus5 = new BarButtonItem(e.Manager, "Taraf Adres ve Ýletiþim Bilgileri Getir");
                    bus5.Tag = e.Rows;
                    bus5.Name = "bButonTarafIletisimBilgileri";
                    bus5.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Administrator_3_22x221;
                    e.MyPopupMenu.ItemLinks.Insert(1, bus5);
                    BarButtonItem bus6 = new BarButtonItem(e.Manager, "Taraf Kimlik Bilgileri Getir");
                    bus6.Tag = e.Rows;
                    bus6.Name = "bButonTarafKimlikBilgileri";
                    bus6.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Administrator_3_22x221;
                    e.MyPopupMenu.ItemLinks.Insert(1, bus6);
                    break;
            }
        }

        private void ExtendedGridControl_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.MainView == null)
                    return;

                if (this.MainView is GridView)
                {
                    foreach (GridColumn column in (this.MainView as GridView).Columns)
                    {
                        //column.BestFit();
                        if (column.FieldName.Contains("DOVIZ_ID"))
                        {
                            column.CustomizationCaption = column.FieldName;
                            column.ToolTip = column.FieldName.Replace("DOVIZ_ID", "Birim").Replace('_', ' ');
                            column.Width = 30;
                        }
                        else if (column.FieldName.Contains("TARIH"))
                        {
                            if (column.OptionsFilter.FilterPopupMode != FilterPopupMode.DateSmart)
                            {
                                try
                                {
                                    column.OptionsFilter.FilterPopupMode =
                                        DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
                                }
                                catch (Exception ex)
                                {
                                    BelgeUtil.ErrorHandler.Logger.ErrorException(
                                        "ExtendedGridControl_DataSourceChange", ex);
                                }
                            }
                        }
                    }
                }
            }
            catch 
            {
                throw;
            }
        }

        #region GridMenu

        protected UserControls.compGridRightClickMenu _rightClickPopup =
            new AdimAdimDavaKaydi.UserControls.compGridRightClickMenu();

        public UserControls.compGridRightClickMenu RightClickPopup
        {
            get
            {
                if (_rightClickPopup != null)
                    return _rightClickPopup;
                else
                {
                    _rightClickPopup = new AdimAdimDavaKaydi.UserControls.compGridRightClickMenu();
                    return _rightClickPopup;
                }
            }
            set { _rightClickPopup = value; }
        }

        private void ExtendedGridControl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this.MainView is GridView)
                DoShowMenu(((GridView)this.MainView).CalcHitInfo(new Point(e.X, e.Y)));
        }

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

        #endregion GridMenu

        private BarManager barMen;
        public PopupMenu popupMenu1;
        public PopupMenu popupMenu2;

        private void ExtendedGridControl_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            initOncekiAyarlar();
            initPopupMenu();
            //initPopupMenu2();
            //InitHidePanel();

            this.ButtonYazdirClick += EmbedDataNavigatorExtender_ButtonYazdirClick;
            this.ButtonTamEkranClick += EmbedDataNavigatorExtender_ButtonTamEkranClick;
            this.ButtonExportClick += EmbedDataNavigatorExtender_ButtonExportClick;
            this.ButtonEditorClick += ExtendedGridControl_ButtonEditorClick;
            this.ButtonHizliRaporClick += EmbedDataNavigatorExtender_ButtonHizliRaporClick;
            this.ButtonWordClick += EmbedDataNavigatorExtender_ButtonWordClick;
            this.ButtonPdfClick += EmbedDataNavigatorExtender_ButtonPdfClick;
            this.ButtonMailClick += EmbedDataNavigatorExtender_ButtonMailClick;
            this.ButtonBicimlendirClick += EmbedDataNavigatorExtender_ButtonBicimlendirClick;
            this.ButtonYeniEkle += ExtendedGridControl_ButtonYeniEkle;
            this.ButtontakipiSil += ExtendedGridControl_ButtontakipiSil;
            this.ButtonOtoYukseklik += ExtendedGridControl_ButtonOtoYukseklik;
            this.MouseClick += new MouseEventHandler(ExtendedGridControl_MouseClick);

            // initHyperDragDrop(); Kapatýldý
            initMe(this);

            //GridsFilterSettings.SetViewFilter(this);
            //GridsFilterSettings filterSet = new GridsFilterSettings();

            //filterSet.SetGridControlsFilterEvents(this);

            try
            {
                ///gridView Baþlýgýnýn Geniþliðini ayrladýk ki orada satýr numaralarý için yeterli yer olsun
                if (this.MainView is GridView)
                {
                    GridView gvMain = ((GridView)this.MainView);
                    ///Satir Numaralarýný Eklemek için Indicator draw da Row Count lar grafiðe çiziliyor.
                    //gvMain.CustomDrawRowIndicator += ExtendedGridControl_CustomDrawRowIndicator;
                    gvMain.ActiveFilter.Clear();
                    for (int i = 0; i < gvMain.Columns.Count; i++)
                    {
                        var column = gvMain.Columns[i];

                        if (column.ColumnEdit == null)
                            column.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                        else
                            column.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Like;
                    }

                    gvMain.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[]
                                                     {
                                                         new DevExpress.XtraGrid.GridGroupSummaryItem(
                                                             DevExpress.Data.SummaryItemType.Count, "ID", null, "")
                                                     });
                    gvMain.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(RowWorks);
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Logger.ErrorException("ExtendedGrid üzerinde Filter Ayarlarken", ex);
            }

            //TODO: [PAKET] ExtendedGridControl
        }

        private void ExtendedGridControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (popupMenu1 != null && popupMenu1.Opened)
                {
                    popupMenu1.HidePopup();
                }
                if (popupMenu2 != null && popupMenu2.Opened)
                {
                    popupMenu2.HidePopup();
                }
            }
        }

        private void ExtendedGridControl_ButtonOtoYukseklik(object sender, NavigatorButtonClickEventArgs e)
        {
            if (this.MainView is GridView)
            {
                GridView gvMain = ((GridView)this.MainView);
                ///Satir Numaralarýný Eklemek için Indicator draw da Row Count lar grafiðe çiziliyor.
                gvMain.OptionsView.RowAutoHeight = !gvMain.OptionsView.RowAutoHeight;
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

        #region IExtendedGridControl Members

        public string FilterValue { get; set; }

        public string FilterText { get; set; }

        public GridFilterControl GridsFilterControl { get; set; }

        #endregion

        private bool _showRowNumbers;

        private void RowWorks(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = "  " + (e.RowHandle + 1).ToString();
        }

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
                        gvMain.IndicatorWidth = gvMain.RowCount.ToString().Length * 10 + 15;
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

        private string _UniqueId;

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

        private void initOncekiAyarlar()
        {
            if (DesignMode)
                return;
            try
            {
                string _path = String.Format("{0}\\layouts\\{1}\\", Application.StartupPath, _UniqueId);
                if (System.IO.Directory.Exists(_path))
                {
                    foreach (BaseView view in this.ViewCollection)
                    {
                        string filePath = String.Format("{0}{1}.yyl", _path, view.Name);
                        string stylePath = String.Format("{0}{1}.yys", _path, view.Name);
                        if (System.IO.File.Exists(filePath))
                            view.RestoreLayoutFromXml(filePath);
                        if (System.IO.File.Exists(stylePath))
                        {
                            System.Xml.Serialization.XmlSerializer xm = new System.Xml.Serialization.XmlSerializer(typeof(GridAyar));
                            System.IO.FileStream fs = System.IO.File.OpenRead(stylePath);
                            GridAyar ayar = (GridAyar)xm.Deserialize(fs);

                            if (ayar != null)
                                if (view is GridView)
                                    initGridStyleCon((GridView)view, ayar);
                                else
                                    initGridStyleCon(view, ayar);
                        }
                    }
                }
                else
                {
                    // frmXGridStyleChooser.xs.LoadScheme(AvukatProLib.Kimlik.Bilgi.STYLE, view);
                    // this.MyGridStyle = AvukatProLib.Kimlik.Bilgi.STYLE;
                    //this.SetStyle
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void initGridStyleCon(GridView gv, GridAyar ayarVer)
        {
            foreach (Bilgi bilgi in ayarVer.StyleConditions)
            {
                gv.FormatConditions.Add(frmBicimlendirme.ConvertBilgiToSFC(bilgi, gv, false));
            }
            if (!String.IsNullOrEmpty(ayarVer.MyCustomStyle))
                frmXGridStyleChooser.xs.LoadScheme(ayarVer.MyCustomStyle, gv);
        }

        private void initGridStyleCon(BaseView vw, GridAyar ayarVer)
        {
            if (!String.IsNullOrEmpty(ayarVer.MyCustomStyle))
                frmXGridStyleChooser.xs.LoadScheme(ayarVer.MyCustomStyle, vw);
        }

        private void ExtendedGridControl_ButtonEditorClick(object sender, NavigatorButtonClickEventArgs e)
        {
            GridControlNavigator nav = (GridControlNavigator)sender;
            Form frm = nav.FindForm();

            Point pnt = Control.MousePosition;
            int k = (popupMenu1.ItemLinks.Count * 25) + 20;
            pnt.Y = pnt.Y - k;

            #region <MB-20100319>

            //Ýcra Takip Ekranýnda Editör butonu makbuz basmak için kullanýldýðýndan popup'tan gelen menülerin görünmesi istenmediði için kapatýldý.
            //if (popupMenu2.Opened)
            //{
            //    popupMenu2.HidePopup();
            //}
            //else
            //{
            //    popupMenu2.ShowPopup(pnt);
            //}

            #endregion
        }

        public BarCheckItem barCheckHucreBirlestir;

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

            //BarButtonItem barButtonItem2 = new BarButtonItem(barMen, "Email Olarak Gönder", MyImageIndexes[NavImages.Email]);
            //barButtonItem2.ItemClick += barButtonItem2_ItemClick;
            //popupMenu1.AddItem(barButtonItem2);
            BarButtonItem barButtonItem3 = new BarButtonItem(barMen, "Seçimli biçimlendirme", MyImageIndexes[NavImages.Kisisellestir]);
            barButtonItem3.ItemClick += barButtonItem3_ItemClick;
            popupMenu1.AddItem(barButtonItem3);
            BarButtonItem barButtonItem4 = new BarButtonItem(barMen, "Alan Seçimi", MyImageIndexes[NavImages.Kisisellestir]);
            barButtonItem4.ItemClick += barButtonItem4_ItemClick;
            popupMenu1.AddItem(barButtonItem4);

            //BarSubItem bbtnExport = new BarSubItem(barMen, "Export (Baþka Programda Aç)", MyImageIndexes[NavImages.Export]);
            ////new BarButtonItem(barMen, "", MyImageIndexes[NavImages.Kisisellestir]);
            ////barButtonItem4.ItemClick += new ItemClickEventHandler(barButtonItem4_ItemClick);

            //#region Export

            //BarButtonItem btnexpExcel = new BarButtonItem(barMen, "Excel (.xls)", MyImageIndexes[NavImages.Export]);
            //btnexpExcel.ItemClick += btnexpExcel_ItemClick;
            //bbtnExport.AddItem(btnexpExcel);
            //BarButtonItem btnexpWord = new BarButtonItem(barMen, "Word (.doc)", MyImageIndexes[NavImages.Doc]);
            //btnexpWord.ItemClick += btnexpWord_ItemClick;
            //bbtnExport.AddItem(btnexpWord);
            //BarButtonItem btnexpPdf = new BarButtonItem(barMen, "E-Book (.pdf)", MyImageIndexes[NavImages.Pdf]);
            //btnexpPdf.ItemClick += btnexpPdf_ItemClick;
            //bbtnExport.AddItem(btnexpPdf);
            //BarButtonItem btnexpHtml = new BarButtonItem(barMen, "Web Sayfasý (.html)", MyImageIndexes[NavImages.Html]);
            //btnexpHtml.ItemClick += btnexpHtml_ItemClick;
            //bbtnExport.AddItem(btnexpHtml);

            //#endregion

            //popupMenu1.AddItem(bbtnExport);

            //BarButtonItem btnFilterFormAc = new BarButtonItem(barMen, "Filtre Düzenleme", MyImageIndexes[NavImages.Kisisellestir]);
            //btnFilterFormAc.ItemClick += btnFilterFormAc_ItemClick;
            //popupMenu1.AddItem(btnFilterFormAc);

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

            barCheckHucreBirlestir = new BarCheckItem(barMen, allwCellMerge);
            barCheckHucreBirlestir.Caption = "Tekrarlayaný Birleþtir";
            barCheckHucreBirlestir.Enabled = allwEnabled;
            barCheckHucreBirlestir.CheckedChanged += barCheckHucreBirlestir_CheckedChanged;

            BarCheckItem barCheckGruplananiGoster = new BarCheckItem(barMen, showGrpClm);
            barCheckGruplananiGoster.Caption = "Gruplananý Göster";
            barCheckGruplananiGoster.Enabled = allwEnabled;
            barCheckGruplananiGoster.CheckedChanged += barCheckGruplananiGoster_CheckedChanged;

            BarCheckItem barCheckOnIzlemeGoster = new BarCheckItem(barMen, showPreview);
            barCheckOnIzlemeGoster.Caption = "Önizleme Göster";
            barCheckOnIzlemeGoster.Enabled = allwEnabled;
            barCheckOnIzlemeGoster.CheckedChanged += barCheckOnIzlemeGoster_CheckedChanged;

            popupMenu1.AddItems(new BarItem[]
                                    {
                                        barCheckGruplananiGoster,
                                        barCheckOnIzlemeGoster,
                                        barCheckHucreBirlestir
                                    });

            BarButtonItem btnSaveLayout = new BarButtonItem(barMen, "Görünümü Kaydet", MyImageIndexes[NavImages.Kisisellestir]);
            btnSaveLayout.ItemClick += btnSaveLayout_ItemClick;
            popupMenu1.AddItem(btnSaveLayout);

            #endregion Hücre Birleþtir
        }

        private bool _GridlerDuzenlenebilir = true;

        public bool GridlerDuzenlenebilir
        {
            get { return _GridlerDuzenlenebilir; }
            set
            {
                _GridlerDuzenlenebilir = value;
                DuzenlenebilmeyiAyarla(value);
            }
        }

        /// <summary>
        /// Grid üzerindeki alanlarýn ReadOnly deðerlerini deðiþtirmek için kullanýlan method
        /// </summary>
        /// <param name="value">Columnlarýn deðeri !value olarak ayarlanýr</param>
        private void DuzenlenebilmeyiAyarla(bool value)
        {
            ///TODO: Columnlarýn önceden tanýmlý ReadOnly deðerlerini bir yerlerde tutmak ve ona göre
            ///Tekrar açmak gerekiyor. Tag alanlarý dolu olabileceði için bunu bir field üzerinde
            ///tutmak daha uygun görünüyor.
            foreach (BaseView bView in this.ViewCollection)
            {
                if (bView is GridView)
                {
                    GridView gv = bView as GridView;
                    foreach (GridColumn gClm in gv.Columns)
                    {
                        if (gClm.FieldName != "IsSelected")
                            gClm.OptionsColumn.ReadOnly = !value;
                    }
                }
                else if (bView is DevExpress.XtraGrid.Views.Layout.LayoutView)
                {
                    DevExpress.XtraGrid.Views.Layout.LayoutView lv = bView as DevExpress.XtraGrid.Views.Layout.LayoutView;
                    foreach (LayoutViewColumn lvClm in lv.Columns)
                    {
                        if (lvClm.FieldName != "IsSelected")
                            lvClm.OptionsColumn.ReadOnly = !value;
                    }
                }
                else if (bView is DevExpress.XtraGrid.Views.Card.CardView)
                {
                    DevExpress.XtraGrid.Views.Card.CardView cv = bView as DevExpress.XtraGrid.Views.Card.CardView;
                    foreach (GridColumn gClm in cv.Columns)
                    {
                        if (gClm.FieldName != "IsSelected")
                            gClm.OptionsColumn.ReadOnly = !value;
                    }
                }
            }
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

        private void barCheckOnIzlemeGoster_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ((GridView)this.MainView).OptionsView.ShowPreview = ((BarCheckItem)e.Item).Checked;
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

        private void btnSaveLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string _path = Application.StartupPath + "\\layouts\\" + _UniqueId + "\\";
                if (!System.IO.Directory.Exists(_path))
                {
                    System.IO.Directory.CreateDirectory(_path);
                }
                foreach (BaseView view in this.ViewCollection)
                {
                    string filePath = _path + view.Name + ".yyl";
                    view.SaveLayoutToXml(filePath, DevExpress.Utils.OptionsLayoutBase.FullLayout);

                    string stylePath = _path + view.Name + ".yys";
                    GridAyar ayarim = new GridAyar();
                    if (view is GridView)
                    {
                        GridView gv = (GridView)view;

                        ayarim.StyleConditions = new List<Bilgi>();
                        foreach (StyleFormatCondition cnd in gv.FormatConditions)
                        {
                            Bilgi bilgi = (cnd.Tag as Bilgi);
                            ayarim.StyleConditions.Add(cnd.Tag as Bilgi);
                        }
                    }
                    if (view.Tag is string)
                        ayarim.MyCustomStyle = view.Tag.ToString();
                    //System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new BinaryFormatter();
                    System.Xml.Serialization.XmlSerializer xm = new System.Xml.Serialization.XmlSerializer(typeof(GridAyar));

                    System.IO.FileStream fs = new System.IO.FileStream(stylePath, System.IO.FileMode.Create);
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
        /// <param name="index">0 Excel - 1 Word -2 Pdf -3 html 5- e-mail</param>
        private void ExportIt(int index)
        {
            if (index == 5)
            {
                PrintingSystem prts = new PrintingSystem();
                prts.ContinuousPageNumbering = true;
                DevExpress.XtraPrintingLinks.CompositeLink compositeLink = new DevExpress.XtraPrintingLinks.CompositeLink(prts);
                compositeLink.PrintingSystem = new PrintingSystem();
                compositeLink.BreakSpace = 25;
                System.Drawing.Printing.Margins mrg = new System.Drawing.Printing.Margins(1, 1, 30, 1);
                compositeLink.Margins = mrg;
                compositeLink.PaperKind = System.Drawing.Printing.PaperKind.A4Rotated;
                try
                {
                    compositeLink.PrintingSystem.Document.ScaleFactor = 1;
                }
                catch { }
                PrintableComponentLink link = new PrintableComponentLink();
                link.Component = this;
                compositeLink.Links.Add(link);
                compositeLink.CreateDocument();
                CommandHandler cd = new CommandHandler();
                compositeLink.PrintingSystem.AddCommandHandler(cd);
                bool den = true;
                cd.HandleCommand(PrintingSystemCommand.SendXls, null, null, ref den);
                compositeLink.ShowPreviewDialog();
            }
            else
            {
                ExtendedGridControl gc = this;
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter =
                    "Excel Dosya Türü|*.xls|Word Dosya Türü|*.doc|PDF (E-Book) Dosya Türü|*.pdf|HTML Web Sayfasý|*.html";
                sv.FilterIndex = index;

                if (sv.ShowDialog() == DialogResult.OK)
                {
                    if (sv.FileName.EndsWith("xls"))
                    {
                        DevExpress.XtraGrid.Export.GridViewExportLink elink = null;
                        GridView gv = this.MainView as GridView;

                        if (this.MainView is GridView)
                        {
                            if (gv != null)
                            {
                                gv.OptionsPrint.PrintDetails = true;
                                elink =
                                    (DevExpress.XtraGrid.Export.GridViewExportLink)
                                    gv.CreateExportLink(new DevExpress.XtraExport.ExportXlsProvider(sv.FileName));

                                elink.ExportDetails = true;
                                elink.ExportAll = true;
                                elink.ExportTo(true);
                            }
                        }
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
                        DevExpress.XtraGrid.Export.GridViewExportLink elink = null;
                        GridView gv = this.MainView as GridView;

                        if (this.MainView is GridView)
                        {
                            if (gv != null)
                            {
                                elink =
                                    (DevExpress.XtraGrid.Export.GridViewExportLink)
                                    gv.CreateExportLink(new DevExpress.XtraExport.ExportHtmlProvider(sv.FileName));
                                elink.ExportDetails = true;
                                elink.ExportAll = true;
                                elink.ExportTo(true);
                            }
                        }
                    }

                    if (System.IO.File.Exists(sv.FileName))
                        System.Diagnostics.Process.Start(sv.FileName);
                    else
                        XtraMessageBox.Show(
                            "Lütfen dosya isminde '.' iþareti kullanmayýnýz. Dosya kayýt iþlemi yapýlamadý",
                            "Dosya kaydýnda hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.FocusedView is GridView)
            {
                GridView gridView = (GridView)this.FocusedView;
                gridView.ShowCustomization();
            }
        }

        /// <summary>
        /// Seçimli biçimlendirme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmXGridStyleChooser frm = new frmXGridStyleChooser();
            frm.ShowMe(this);
        }
        
        /// <summary>
        /// Grid renklendirme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBicimlendirme frm = new frmBicimlendirme();
            if (this.MainView is GridView)
            {
                frm.Grid = (GridView)this.MainView;
                frm.ShowDialog();
            }
            else
            {
                frm.Dispose();
                XtraMessageBox.Show("Bu özellik sadece liste grid ile kullanýlabilir"); //TODO:Resx den okunacak.
            }
        }

        private void ViewRepository_Changed(object sender, CollectionChangeEventArgs e)
        {
            if (e.Element is GridView && e.Action == CollectionChangeAction.Add)
            {
                ((GridView)e.Element).ShowGridMenu += ExtendedGridControl_ShowGridMenu;
                ((GridView)e.Element).ColumnFilterChanged += ExtendedGridControl_ColumnFilterChanged;
            }
        }

        private void ExtendedGridControl_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView gonderen = (GridView)sender;
            ColumnView view = gonderen;

            for (int i = 0; i < view.ActiveFilter.Count; i++)
            {
                ViewColumnFilterInfo flt = view.ActiveFilter[i];
                if (flt.Filter.Type == ColumnFilterType.AutoFilter && flt.Filter.Kind == ColumnFilterKind.User &&
                    !flt.Filter.FilterString.Contains("Like '%"))
                    flt.Filter = new ColumnFilterInfo(ColumnFilterType.AutoFilter, flt.Filter.Value,
                                                      flt.Filter.FilterString.Replace("Like '", "Like '%"));
            }
        }

        private void ExtendedGridControl_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                DevExpress.XtraGrid.Menu.GridViewColumnMenu menu = e.Menu as DevExpress.XtraGrid.Menu.GridViewColumnMenu;
                if (menu.Column != null)
                {
                    //TODO:Resources dan string olarak çek
                    menu.Items.Add(CreateCheckItem("Kilitsiz", menu.Column, FixedStyle.None,
                                                   AdimAdimDavaKaydi.Properties.Resources.lock_open));
                    menu.Items.Add(CreateCheckItem("Sola Kilitle", menu.Column, FixedStyle.Left,
                                                   AdimAdimDavaKaydi.Properties.Resources.gridex_SolaKilitle_16x16));
                    menu.Items.Add(CreateCheckItem("Saða Kilitle", menu.Column, FixedStyle.Right,
                                                   AdimAdimDavaKaydi.Properties.Resources.gridex_SagaKilitle_16x16));
                    //Group Interval
                    if (!(menu.Column.ColumnType == typeof(DateTime) || menu.Column.ColumnType == typeof(DateTime?)))
                    {
                        DXMenuItem baslangic = CreateMenuItem("Alfabetik grupla", menu.Column,
                                                              ColumnGroupInterval.Alphabetical);
                        baslangic.BeginGroup = true;
                        menu.Items.Add(baslangic);
                    }
                    menu.Items.Add(CreateMenuItem("Varsayýlan grupla", menu.Column, ColumnGroupInterval.Default));
                    menu.Items.Add(CreateMenuItem("Ýçeriðe göre grupla", menu.Column, ColumnGroupInterval.DisplayText));
                    menu.Items.Add(CreateMenuItem("Deðer'e göre grupla", menu.Column, ColumnGroupInterval.Value));
                }
            }
        }

        #region New column menu

        private DXMenuItem CreateMenuItem(string caption, GridColumn column, ColumnGroupInterval interval)
        {
            DXMenuItem item = new DXMenuItem(caption, OnClmGroupInterval);
            item.Tag = new ColumnGrpItervalInfo(column, interval);
            return item;
        }

        private DXMenuCheckItem CreateCheckItem(string caption, GridColumn column, FixedStyle style, Image image)
        {
            DXMenuCheckItem item = new DXMenuCheckItem(caption, column.Fixed == style, image, OnFixedClick);
            item.Tag = new MenuInfo(column, style);
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

        private class MenuInfo
        {
            public MenuInfo(GridColumn column, FixedStyle style)
            {
                this.Column = column;
                this.Style = style;
            }

            public FixedStyle Style;
            public GridColumn Column;
        }

        private class ColumnGrpItervalInfo
        {
            public GridColumn Column;
            public ColumnGroupInterval Interval;

            public ColumnGrpItervalInfo(GridColumn column, ColumnGroupInterval interval)
            {
                Column = column;
                Interval = interval;
            }
        }

        #endregion

        #region DataNavigatorExtended

        private static ImageList _MyImageList;

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
                    int index = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_getir, Color.Transparent);

                    MyImageIndexes.Add(NavImages.Getir, index);
                    int index2 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_cevir, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Cevir, index2);
                    int index3 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_fscreen, Color.Transparent);
                    MyImageIndexes.Add(NavImages.TamEkran, index3);
                    int index4 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_printer, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Yazdir, index4);
                    int index5 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_excel, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Export, index5);
                    int index6 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_email, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Email, index6);
                    int index7 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_add, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Ekle, index7);
                    int index8 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_tick, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Tamamla, index8);
                    int index9 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_next, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Ileri, index9);
                    int index10 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_previous, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Geri, index10);
                    int index11 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_last, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Son, index11);
                    int index12 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_first, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Ilk, index12);
                    int index122 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_delete, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Sil, index122);
                    int index13 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_editor, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Editor, index13);
                    int index14 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.favorite_22x221, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Kisisellestir, index14);
                    int index15 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.html, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Html, index15);
                    int index16 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.doc, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Doc, index16);
                    int index17 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.pdf, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Pdf, index17);

                    int index18 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.sihirbaz1_16x16, Color.Transparent);
                    MyImageIndexes.Add(NavImages.KolayKayit, index18);
                    int index19 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.kopyala_16x16, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Kopyala, index19);
                    int index20 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.dilekce, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Duzenle, index20);

                    #region <MB-20100701>

                    //Kaydetme iþlemi için icon eklendi.
                    int index21 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.kaydet_16x16, Color.Transparent);
                    MyImageIndexes.Add(NavImages.Kaydet, index21);

                    #endregion

                    #region <MB-20101222>

                    //Muallak Raporda faiz hesapla butonu için icon eklendi.
                    int index22 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.hesapla_16x16, Color.Transparent);
                    MyImageIndexes.Add(NavImages.FaizHesapla, index22);

                    #endregion

                    int index23 = imgList.Images.Add(AdimAdimDavaKaydi.Properties.Resources.rapor01_221, Color.Transparent);
                    MyImageIndexes.Add(NavImages.HizliRapor, index23);

                    _MyImageList = imgList;
                    return _MyImageList;
                }
                else
                {
                    return _MyImageList;
                }
            }
        }

        [Browsable(false)]
        public static Dictionary<NavImages, int> MyImageIndexes
        {
            get { return _MyImageIndexes; }
            set { _MyImageIndexes = value; }
        }

        /// <summary>
        /// Embeded Navigator u extend etmek istemediðinizde true yapabilirsiniz.
        /// </summary>
        [Category("Extended Properties")]
        public bool DoNotExtendEmbedNavigator { get; set; }

        /// <summary>
        /// HyperDragdrop özelliðini açar ve nesne tipinden sürüklemeyi etkin kýlar.
        /// </summary>
        [Category("Extended Properties")]
        public bool UseHyperDragDrop
        {
            get { return _UseHyperDragDrop; }
            set { _UseHyperDragDrop = value; }
        }

        public string MyGridStyle { get; set; }

        public bool SilmeKaldirilsin { get; set; }

        private static Dictionary<NavImages, int> _MyImageIndexes = new Dictionary<NavImages, int>();

        private void initMe(GridControl gridControl)
        {
            if (DesignMode)
                return;
            if (gridControl == null)
                return;
            GridView view = gridControl.FocusedView as GridView;
            //gridControl.EmbeddedNavigator.AutoSize = false;
            //gridControl.EmbeddedNavigator.AutoSizeInLayoutControl = false;
            gridControl.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            //gridControl.EmbeddedNavigator.ClientSize = new Size(300, 40);
            //gridControl.EmbeddedNavigator.Size = new Size(300, 40);
            gridControl.EmbeddedNavigator.BackColor = Color.Red;
            gridControl.EmbeddedNavigator.ForeColor = Color.White;
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
            gridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;

            if (!customButtonlarGorunmesin)
            {
                //NavigatorCustomButton cevir = gridControl.EmbeddedNavigator.CustomButtons.Add();
                //cevir.Enabled = true;
                //cevir.Visible = true;
                //cevir.Tag = "Cevir";
                //cevir.Hint = "Görünüm Deðiþtir";
                //cevir.ImageIndex = MyImageIndexes[NavImages.Cevir];

                NavigatorCustomButton tamekr = gridControl.EmbeddedNavigator.CustomButtons.Add();
                tamekr.Tag = "TamEkr";
                tamekr.Hint = "Tam Ekran";
                tamekr.ImageIndex = MyImageIndexes[NavImages.TamEkran];

                NavigatorCustomButton print = gridControl.EmbeddedNavigator.CustomButtons.Add();
                print.Tag = "Yazdir";
                print.Hint = "Yazdýr";
                print.ImageIndex = MyImageIndexes[NavImages.Yazdir];
                if (!SilmeKaldirilsin)
                {
                    NavigatorCustomButton kayitsil = gridControl.EmbeddedNavigator.CustomButtons.Add();
                    kayitsil.Tag = null;
                    kayitsil.Hint = "Geçerli Kaydý Sil";
                    kayitsil.ImageIndex = MyImageIndexes[NavImages.Sil];
                }
                NavigatorCustomButton mail = gridControl.EmbeddedNavigator.CustomButtons.Add();
                mail.Tag = "Biçimlendirme";
                mail.Hint = "Biçimlendirme";
                mail.ImageIndex = MyImageIndexes[NavImages.Kisisellestir];

                NavigatorCustomButton btnHizliRapor = gridControl.EmbeddedNavigator.CustomButtons.Add();
                btnHizliRapor.Tag = "HýzlýRapor";
                btnHizliRapor.Hint = "Hýzlý Raporlar";
                btnHizliRapor.ImageIndex = MyImageIndexes[NavImages.HizliRapor];

                NavigatorCustomButton exportToEditor = gridControl.EmbeddedNavigator.CustomButtons.Add();
                exportToEditor.Tag = "Editor";
                exportToEditor.Hint = "Gönder";
                exportToEditor.ImageIndex = MyImageIndexes[NavImages.Editor];

                NavigatorCustomButton btnEmailOlarakGonder = gridControl.EmbeddedNavigator.CustomButtons.Add();
                btnEmailOlarakGonder.Tag = "Mail";
                btnEmailOlarakGonder.Hint = "Mail olarak gönder";
                btnEmailOlarakGonder.ImageIndex = MyImageIndexes[NavImages.Email];

                NavigatorCustomButton btnExcel = gridControl.EmbeddedNavigator.CustomButtons.Add();
                btnExcel.Tag = "Excel";
                btnExcel.Hint = "Excel'e gönder";
                btnExcel.ImageIndex = MyImageIndexes[NavImages.Export];
                NavigatorCustomButton btnWord = gridControl.EmbeddedNavigator.CustomButtons.Add();
                btnWord.Tag = "Word";
                btnWord.Hint = "Word'e gönder";
                btnWord.ImageIndex = MyImageIndexes[NavImages.Doc];
                NavigatorCustomButton btnPdf = gridControl.EmbeddedNavigator.CustomButtons.Add();
                btnPdf.Tag = "Pdf";
                btnPdf.Hint = "Pdf'e gönder";
                btnPdf.ImageIndex = MyImageIndexes[NavImages.Pdf];
                //BarSubItem bbtnExport = new BarSubItem(barMen, "Export (Baþka Programda Aç)", MyImageIndexes[NavImages.Export]);
                ////new BarButtonItem(barMen, "", MyImageIndexes[NavImages.Kisisellestir]);
                ////barButtonItem4.ItemClick += new ItemClickEventHandler(barButtonItem4_ItemClick);

                //#region Export

                //BarButtonItem btnexpExcel = new BarButtonItem(barMen, "Excel (.xls)", MyImageIndexes[NavImages.Export]);
                //btnexpExcel.ItemClick += btnexpExcel_ItemClick;
                //bbtnExport.AddItem(btnexpExcel);
                //BarButtonItem btnexpWord = new BarButtonItem(barMen, "Word (.doc)", MyImageIndexes[NavImages.Doc]);
                //btnexpWord.ItemClick += btnexpWord_ItemClick;
                //bbtnExport.AddItem(btnexpWord);
                //BarButtonItem btnexpPdf = new BarButtonItem(barMen, "E-Book (.pdf)", MyImageIndexes[NavImages.Pdf]);
                //btnexpPdf.ItemClick += btnexpPdf_ItemClick;
                //bbtnExport.AddItem(btnexpPdf);
                //BarButtonItem btnexpHtml = new BarButtonItem(barMen, "Web Sayfasý (.html)", MyImageIndexes[NavImages.Html]);
                //btnexpHtml.ItemClick += btnexpHtml_ItemClick;
                //bbtnExport.AddItem(btnexpHtml);

                //#endregion

                //popupMenu1.AddItem(bbtnExport);

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
            gridControl.EmbeddedNavigator.ButtonClick += EmbeddedNavigator_ButtonClick;
            gridControl.EmbeddedNavigator.Buttons.EndUpdate();
        }

        private bool temizleKaldirGorunsun;
        private bool customButtonlarGorunmesin;

        [Category("Extended Properties")]
        public bool CustomButtonlarGorunmesin
        {
            get { return customButtonlarGorunmesin; }
            set { customButtonlarGorunmesin = value; }
        }

        [Category("Extended Properties")]
        public bool TemizleKaldirGorunsunmu
        {
            get { return temizleKaldirGorunsun; }
            set { temizleKaldirGorunsun = value; }
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
                    case "OtoYukseklik":
                        if (ButtonOtoYukseklik != null)
                        {
                            ButtonOtoYukseklik(sender, e);
                        }
                        break;
                    case "HýzlýRapor":
                        if (ButtonHizliRaporClick != null)
                        {
                            ButtonHizliRaporClick(sender, e);
                        }
                        break;
                    case "Word":
                        if (ButtonWordClick != null)
                        {
                            ButtonWordClick(sender, e);
                        }
                        break;
                    case "Pdf":
                        if (ButtonPdfClick != null)
                        {
                            ButtonPdfClick(sender, e);
                        }
                        break;
                    case "Biçimlendirme":
                        if (ButtonBicimlendirClick != null)
                        {
                            ButtonBicimlendirClick(sender, e);
                        }
                        break;
                    default:
                        break;
                }

            else if (/*e.Button.Tag != null &&*/ e.Button.Hint == "Geçerli Kaydý Sil")//aykut hýzlandýrma 25.01.2013
            {
                
                GridControl gc = (Cast<GridControl>.It(Cast<ControlNavigator>.It(sender).NavigatableControl));
                GridView view = gc.FocusedView as GridView;
                AdimAdimDavaKaydi.Util.frmKayitSil kayitSil;

                if (gc.Tag != null)
                {
                    if (gc.Tag.ToString() == "AV001_TDI_BIL_KASA" || gc.Tag.ToString() == "R_MASRAF_AVANS_DETAYLI2" || gc.Tag.ToString() == "R_FOY_MUHASEBESI_BIRLESIK_DETAYLI" || gc.Tag.ToString() == "AV001_TDI_BIL_FATURA" || gc.Tag.ToString() == "R_CARI_HESAP_DETAYLI")
                    {
                        if (gc.Tag.ToString() == "R_FOY_MUHASEBESI_BIRLESIK_DETAYLI")
                            kayitSil = new frmKayitSil("AV001_TDI_BIL_FOY_MUHASEBE", "ID = " + view.GetFocusedRowCellValue("Id"));
                        else if (gc.Tag.ToString() == "R_MASRAF_AVANS_DETAYLI2")
                            kayitSil = new frmKayitSil("AV001_TDI_BIL_MASRAF_AVANS", "ID = " + view.GetFocusedRowCellValue("Id"));
                        else if (gc.Tag.ToString() == "R_CARI_HESAP_DETAYLI")
                            kayitSil = new frmKayitSil("AV001_TDI_BIL_CARI_HESAP", "ID = " + view.GetFocusedRowCellValue("Id"));
                        else
                            kayitSil = new frmKayitSil(gc.Tag.ToString(), "ID = " + view.GetFocusedRowCellValue("Id"));

                        if (kayitSil.ShowDialog() == DialogResult.OK)
                        {
                            view.DeleteRow(view.FocusedRowHandle);
                        }
                    }
                    else if (gc.Tag.ToString() == "AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY")
                    {
                        kayitSil = new frmKayitSil("AV001_TDI_BIL_CARI_HESAP_DETAY", "ID = " + view.GetFocusedRowCellValue("HesapDetayId"), (e.Button.Tag is IEntity));

                        if (kayitSil.ShowDialog() == DialogResult.OK)
                            view.DeleteRow(view.FocusedRowHandle);
                    }
                    else if (gc.Tag.ToString() == "AV001_TI_BIL_FOY")
                    {
                        kayitSil = new frmKayitSil("AV001_TI_BIL_FOY", "ID = " + view.GetFocusedRowCellValue("ID"), (e.Button.Tag is IEntity));

                        if (kayitSil.ShowDialog() == DialogResult.OK)
                            view.DeleteRow(view.FocusedRowHandle);
                    }
                    else if (gc.Tag.ToString() == "AV001_TD_BIL_FOY")
                    {
                        kayitSil = new frmKayitSil("AV001_TD_BIL_FOY", "ID = " + view.GetFocusedRowCellValue("ID"), (e.Button.Tag is IEntity));

                        if (kayitSil.ShowDialog() == DialogResult.OK)
                            view.DeleteRow(view.FocusedRowHandle);
                    }
                    else if (gc.Tag.ToString() == "AV001_TI_BIL_ALACAK_NEDEN")
                    {
                        gc = Cast<GridControl>.It(Cast<ControlNavigator>.It(sender).NavigatableControl);
                        kayitSil = new frmKayitSil("AV001_TI_BIL_ALACAK_NEDEN", "ID = " + view.GetFocusedRowCellValue("ID"), true);

                        if (kayitSil.ShowDialog() == DialogResult.OK)
                            view.DeleteRow(view.FocusedRowHandle);
                    }
                    else
                    {
                        gc = Cast<GridControl>.It(Cast<ControlNavigator>.It(sender).NavigatableControl);
                        kayitSil = new frmKayitSil(gc.Tag.ToString(), "ID = " + view.GetFocusedRowCellValue("ID"), true);

                        if (kayitSil.ShowDialog() == DialogResult.OK)
                            view.DeleteRow(view.FocusedRowHandle);
                    }
                }
                else
                {
                    if (e.Button.Tag == null)
                    {
                        view.DeleteSelectedRows();
                    }
                    else
                    {
                        gc = Cast<GridControl>.It(Cast<ControlNavigator>.It(sender).NavigatableControl);
                        kayitSil = new frmKayitSil(e.Button.Tag.GetType().Name, "ID = " + e.Button.Tag.GetType().GetProperty("ID").GetValue(e.Button.Tag, null), (e.Button.Tag is IEntity));

                        if (kayitSil.ShowDialog() == DialogResult.OK)
                        {
                            if (e.Button.Tag.GetType().GetProperty("ID").GetValue(e.Button.Tag, null).ToString() == "0")
                                try
                                {
                                    gc.DataSource.GetType().GetMethod("RemoveAt").Invoke(gc.DataSource, new object[] { (gc.FocusedView as GridView).FocusedRowHandle });
                                }
                                catch
                                {
                                }

                            else
                                try
                                {
                                    gc.DataSource.GetType().GetMethod("Remove").Invoke(gc.DataSource, new[] { e.Button.Tag });
                                }
                                catch
                                {
                                }
                        }

                        gc.RefreshDataSource();
                    }
                }

            }

            if (ButtonClick != null)
            {
                ButtonClick(sender, e);
            }
        }

        public event EventHandler<NavigatorButtonClickEventArgs> ButtonGetirClick;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtonTamEkranClick;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtonClick;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtonEditorClick;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtonCevirClick;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtonExportClick;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtonYazdirClick;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtonMailClick;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtonHizliRaporClick;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtonWordClick;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtonPdfClick;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtonBicimlendirClick;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtonTumunuKaldir;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtonTumunuSec;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtonYeniEkle;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtontakipiSil;
        public event EventHandler<NavigatorButtonClickEventArgs> ButtonOtoYukseklik;

        public void TakipEkraninaGonder(string takipTipi, int? foyId)
        {
            switch (takipTipi)
            {
                case "Icra":

                    if (!foyId.HasValue)
                    {
                        MsgKayitBulunamadi();
                        break;
                    }

                    AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip frmIcra =
                        new AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip();
                    AV001_TI_BIL_FOY icraFoy = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.GetByID(foyId.Value);
                    TList<AV001_TI_BIL_FOY> icraFoyListesi = new TList<AV001_TI_BIL_FOY>();
                    icraFoyListesi.Add(icraFoy);
                    frmIcra.Show(icraFoyListesi);
                    break;
                case "Dava":

                    if (!foyId.HasValue)
                    {
                        MsgKayitBulunamadi();
                        break;
                    }
                    AV001_TD_BIL_FOY davaFoy = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.GetByID(foyId.Value);
                    TList<AV001_TD_BIL_FOY> davaFoyListesi = new TList<AV001_TD_BIL_FOY>();
                    davaFoyListesi.Add(davaFoy);
                    AdimAdimDavaKaydi.DavaTakip.frmDavaTakip frmDava = new AdimAdimDavaKaydi.DavaTakip.frmDavaTakip();
                    frmDava.Show(davaFoyListesi);
                    break;
                case "Soruþturma":
                    if (!foyId.HasValue)
                    {
                        MsgKayitBulunamadi();
                        break;
                    }
                    AV001_TD_BIL_HAZIRLIK hazirlik = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(foyId.Value);
                    TList<AV001_TD_BIL_HAZIRLIK> hazirlikListesi = new TList<AV001_TD_BIL_HAZIRLIK>();
                    hazirlikListesi.Add(hazirlik);
                    AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip frmSorusturma =
                        new AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip();
                    frmSorusturma.Show(hazirlikListesi);
                    break;
                default:
                    XtraMessageBox.Show(string.Format("{0} Takip Ekranýna Gönderme Yapým Aþamasýnda", takipTipi));
                    break;
            }
        }

        public void ClickEmbededNavigatorButton(R_BIRLESIK_TAKIPLER_TUMU_TEXT takip)
        {
            TakipEkraninaGonder(takip.Tipi, takip.ID);
        }

        public void ClickEmbededNavigatorButton(ICRA_PRATIK_ARAMA takip)
        {
            TakipEkraninaGonder("Icra", takip.ID);
        }

        public void ClickEmbededNavigatorButton(R_BIRLESIK_TAKIPLER_TARAFLI_SORUMLULU takip)
        {
            TakipEkraninaGonder(takip.Tipi, takip.ID);
        }

        private void MsgKayitBulunamadi()
        {
            XtraMessageBox.Show("Ýlgili Kayýt Bulunamadý");
        }

        public void ClickEmbededNavigatorButton(NavigatorButtonBase btn)
        {
            EmbeddedNavigator_ButtonClick(this, new NavigatorButtonClickEventArgs(btn));
        }
        
        private void EmbedDataNavigatorExtender_ButtonMailClick(object sender, NavigatorButtonClickEventArgs e)
        {
            GridRapor.GridPrintReport.MailIt(this);
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
        private void EmbedDataNavigatorExtender_ButtonHizliRaporClick(object sender, NavigatorButtonClickEventArgs e)
        {
            frmFiltreYonetim frm = new frmFiltreYonetim();
            frm.Show(this);
        }
        private void EmbedDataNavigatorExtender_ButtonWordClick(object sender, NavigatorButtonClickEventArgs e)
        {
            try
            {
                ExportIt(2);
            }
            catch
            {
                XtraMessageBox.Show("Dosyanýn kullanýmda olmadýðýndan veya bilgisayarýnýzda Word programýnýn yüklü olduðundan emin olunuz.", "Dosya Oluþturma Hatasý");
            }
        }
        private void EmbedDataNavigatorExtender_ButtonPdfClick(object sender, NavigatorButtonClickEventArgs e)
        {
            try
            {
                ExportIt(3);
            }
            catch
            {
                XtraMessageBox.Show("Dosyanýn kullanýmda olmadýðýndan veya bilgisayarýnýzda Pdf okuyucu programýn yüklü olduðundan emin olunuz.", "Dosya Oluþturma Hatasý");
            }
        }
        private void EmbedDataNavigatorExtender_ButtonBicimlendirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (sender is ExtendedGridControl)
            {
                ExtendedGridControl nav = (ExtendedGridControl)sender;
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
            else
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
        }

        private ExtendedGridControl _tamEkran;
        private Control _cntNormal;

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
                sbtn.Click += sbtn_Click;
                panelControl.Controls.Add(gc);
                panelControl.Dock = DockStyle.Fill;
                gc.BringToFront();
                gc.Visible = true;
                gc.Tag = gc.Dock;

                gc.Dock = DockStyle.Fill;
                frm.Controls.Add(panelControl);
            }
        }

        private void sbtn_Click(object sender, EventArgs e)
        {
            EmbedDataNavigatorExtender_ButtonTamEkranClick(this, null);
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

        #region Yazdýrma iþlemleri

        private static string GetDosyaBilgisi(Control parrent)
        {
            string sonuc = string.Empty;

            try
            {
                if (parrent is IcraTakipForms._frmIcraTakip)
                {
                    #region Ýcra Bilgileri

                    var icraFrm = parrent as AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip;

                    var foy = icraFrm.MyFoy;
                    sonuc = string.Format("{0} {1} {2} {5} {3} {5} {4}"
                                          , AdimAdimDavaKaydi.Editor.Degiskenler.Util.EditorDataAraclari.Icra.GetAdliyeAdi(foy.ADLI_BIRIM_ADLIYE_ID)
                                          , AdimAdimDavaKaydi.Editor.Degiskenler.Util.EditorDataAraclari.Icra.GetAdliBirimNo(foy.ADLI_BIRIM_NO_ID)
                                          , AdimAdimDavaKaydi.Editor.Degiskenler.Util.EditorDataAraclari.Icra.GetAdliBirimGorev(foy.ADLI_BIRIM_GOREV_ID)
                                          , foy.ESAS_NO
                                          , foy.TAKIP_TARIHI.Value.ToString("dd - MM - yy")
                                          , Environment.NewLine);

                    #endregion
                }
                else if (parrent is AdimAdimDavaKaydi.DavaTakip.frmDavaTakip)
                {
                    #region Dava Bilgileri

                    var frm = parrent as DavaTakip.frmDavaTakip;
                    var foy = frm.MyFoy;
                    sonuc = string.Format("{0} {1} {2} {5} {3} {5} {4}"
                                          , AdimAdimDavaKaydi.Editor.Degiskenler.Util.EditorDataAraclari.Icra.GetAdliyeAdi(foy.ADLI_BIRIM_ADLIYE_ID)
                                          , AdimAdimDavaKaydi.Editor.Degiskenler.Util.EditorDataAraclari.Icra.GetAdliBirimNo(foy.ADLI_BIRIM_NO_ID)
                                          , AdimAdimDavaKaydi.Editor.Degiskenler.Util.EditorDataAraclari.Icra.GetAdliBirimGorev(foy.ADLI_BIRIM_GOREV_ID)
                                          , foy.ESAS_NO
                                          , foy.DAVA_TARIHI.Value.ToString("dd - MM - yy")
                                          , Environment.NewLine);

                    #endregion
                }
                else if (parrent is AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeTakip)
                {
                    #region Sözleþme Bilgileri

                    var frm = parrent as Sozlesme.Forms.frmSozlesmeTakip;
                    var foy = frm.MySozlesme;
                    sonuc = string.Format("{0} {1} {2} {4} {3} {4}"
                                          , AdimAdimDavaKaydi.Editor.Degiskenler.Util.EditorDataAraclari.Icra.GetAdliyeAdi(foy.ADLI_BIRIM_ADLIYE_ID)
                                          , AdimAdimDavaKaydi.Editor.Degiskenler.Util.EditorDataAraclari.Icra.GetAdliBirimNo(foy.ADLI_BIRIM_NO_ID)
                                          , AdimAdimDavaKaydi.Editor.Degiskenler.Util.EditorDataAraclari.Icra.GetAdliBirimGorev(foy.ADLI_BIRIM_GOREV_ID)
                                          , foy.SOZLESME_NO
                                          , Environment.NewLine);
                    if (foy.BASLANGIC_TARIHI.HasValue)
                        sonuc += foy.BASLANGIC_TARIHI.Value.ToString("dd-MM-yy");

                    #endregion
                }
                else if (parrent is AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip)
                {
                    #region Soruþturma Bilgileri

                    var frm = parrent as Sorusturma.Forms.rFrmSorusturmaTakip;
                    var foy = frm.MyHazirlik;
                    sonuc = string.Format("{0} {1} {2} {4} {3} {4}"
                                          , AdimAdimDavaKaydi.Editor.Degiskenler.Util.EditorDataAraclari.Icra.GetAdliyeAdi(foy.ADLI_BIRIM_ADLIYE_ID)
                                          , AdimAdimDavaKaydi.Editor.Degiskenler.Util.EditorDataAraclari.Icra.GetAdliBirimNo(foy.ADLI_BIRIM_NO_ID)
                                          , AdimAdimDavaKaydi.Editor.Degiskenler.Util.EditorDataAraclari.Icra.GetAdliBirimGorev(foy.ADLI_BIRIM_GOREV_ID)
                                          , foy.HAZIRLIK_NO
                                          , Environment.NewLine);
                    if (foy.HAZIRLIK_TARIH.HasValue)
                        sonuc += foy.HAZIRLIK_TARIH.Value.ToString("dd-MM-yy");

                    #endregion
                }
                else if (parrent.Parent != null)
                {
                    //Aradýðýmýzý Bulamadýk
                    sonuc = GetDosyaBilgisi(parrent.Parent);
                }
                return sonuc;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Logger.ErrorException("Grid Üzerinden Alýnan Raporlar", ex);
            }

            return sonuc;
        }

        private static Image AntetLogosu { get; set; }

        public static void YazdirmaOnizleme(GridControl gc)
        {
            YazdirmaOnizleme(gc, gc);
        }

        public static void YazdirmaOnizleme(DevExpress.XtraTreeList.TreeList gc)
        {
            YazdirmaOnizleme(gc, gc);
        }

        private static void YazdirmaOnizleme(Control gc, IPrintable printControl)
        {
            frmRaporAdi frm = new frmRaporAdi();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                #region Bilgiler Toparlanýyor

                string ustBaslik = string.Empty;
                string iletisimBilgileri = string.Empty;
                string kullaniciAdi = string.Empty;
                string adresBilgileri = string.Empty;
                string dosyaBilgileri = GetDosyaBilgisi(gc.Parent);

                var antetler = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ANTETProvider.GetAll();

                if (antetler.Count > 0)
                {
                    var antet = antetler[0];

                    ustBaslik += antet.UST_1;
                    ustBaslik += Environment.NewLine;
                    if (antet.LOGO != null)
                    {
                        AntetLogosu = ResimAraclari.GetImage(antet.LOGO);
                    }
                }
                else
                {
                    ustBaslik += AvukatProLib.Kimlik.SirketBilgisi.LisansBilgisi.AdSoyad;
                    ustBaslik += Environment.NewLine;
                }

                ustBaslik += frm.RaporBasligi;
                var cari = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(AvukatProLib.Kimlik.CurrentCariId);
                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,
                                                                   typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE));
                iletisimBilgileri += cari.TEL_1;
                iletisimBilgileri += Environment.NewLine;
                iletisimBilgileri += cari.EMAIL_1;

                kullaniciAdi += DateTime.Now.ToString();
                kullaniciAdi += Environment.NewLine;
                kullaniciAdi += cari.AD;

                adresBilgileri = string.Format("{0} {1} {2}", cari.Aktif_ADRES1, cari.Aktif_ADRES2, cari.Aktif_ADRES3);
                string ilceAdi = string.Empty;
                string ilAdi = string.Empty;

                if (cari.Aktif_ILCE_ID.HasValue)
                {
                    var ilce = AvukatProLib2.Data.DataRepository.TDI_KOD_ILCEProvider.GetByID(cari.Aktif_ILCE_ID.Value);
                    ilceAdi = ilce.ILCE;
                }
                if (cari.Aktif_IL_ID.HasValue)
                {
                    var il = AvukatProLib2.Data.DataRepository.TDI_KOD_ILProvider.GetByID(cari.Aktif_IL_ID.Value);
                    ilAdi = il.IL;
                }

                adresBilgileri += Environment.NewLine;
                adresBilgileri += string.Format("{0}-{1}", ilceAdi, ilAdi);

                #endregion

                var printingSystem1 = new PrintingSystem();

                DevExpress.XtraPrinting.PrintableComponentLink pl = new DevExpress.XtraPrinting.PrintableComponentLink();
                printingSystem1.Links.Add(pl);
                pl.Component = printControl;
                pl.CreateMarginalHeaderArea += pl_CreateMarginalHeaderArea;

                PageHeaderFooter phf = pl.PageHeaderFooter as PageHeaderFooter;
                phf.Header.Content.Clear();

                phf.Header.Content.AddRange(new[] { null, ustBaslik, dosyaBilgileri });
                phf.Header.Font = new Font(phf.Header.Font.FontFamily, 12);
                phf.Footer.Content.AddRange(new[] { iletisimBilgileri, adresBilgileri, kullaniciAdi });

                pl.CreateDocument();
                pl.ShowPreview();

                #region Belgeyi Dosya altýna kaydet

                if (frm.Kaydedilsinmi)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();

                    printingSystem1.ExportToPdf(stream);
                    byte[] dizi = stream.ToArray();

                    AvukatProLib2.Data.TDIE_KOD_BELGE_TURQuery qu = new AvukatProLib2.Data.TDIE_KOD_BELGE_TURQuery();
                    qu.Append(TDIE_KOD_BELGE_TURColumn.BELGE_TURU, "RAPOR");
                    var belgeTur = AvukatProLib2.Data.DataRepository.TDIE_KOD_BELGE_TURProvider.Find(qu).FirstOrDefault();

                    var belge = AdimAdimDavaKaydi.Editor.Degiskenler.Util.BelgeAraclari.BelgeKaydet(dizi, frm.RaporBasligi, "pdf", belgeTur != null ? belgeTur.ID : 7); // 9 Rapor

                    if (belge == null)
                        MessageBox.Show("Belge Kaydedilemedi");
                }

                #endregion
            }
        }

        private static void pl_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            Image gosterilecek;

            if (AntetLogosu != null)
                gosterilecek = AntetLogosu;
            else
                gosterilecek = AdimAdimDavaKaydi.Properties.Resources.avukatpro_AS1;

            e.Graph.DrawPageImage(gosterilecek, new RectangleF(0, 0, gosterilecek.Width, gosterilecek.Height),
                                  BorderSide.Left, Color.White);
        }

        private void EmbedDataNavigatorExtender_ButtonYazdirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            try
            {
                if (sender is GridControlNavigator)
                {
                    GridControl gc = Cast<GridControl>.It(Cast<ControlNavigator>.It(sender).NavigatableControl);
                    YazdirmaOnizleme(gc);
                    //gc.ShowPrintPreview();
                }
                else if (sender is GridControl)
                {
                    GridControl gc = Cast<GridControl>.It(sender);
                    YazdirmaOnizleme(gc);
                    //gc.ShowPrintPreview();
                }
                //GridPrintReport.Raporla(gc);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        #endregion

        #endregion

        #region HyperDragDrop

        private bool _UseHyperDragDrop;


        #endregion


    }

    ///<summary>
    ///
    ///</summary>
    public class ExtendedGridView : DevExpress.XtraGrid.Views.Grid.GridView
    {
        public ExtendedGridView()
            : this(null)
        {
        }

        public ExtendedGridView(AdimAdimDavaKaydi.Util.ExtendedGridControl gridControl)
            : base(gridControl)
        {
            this.CustomDrawRowIndicator += ExtendedGridView_CustomDrawRowIndicator;
        }

        private void ExtendedGridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle == GridControl.InvalidRowHandle)
            {
                e.Handled = true;
                e.Painter.DrawObject(e.Info);

                Rectangle r = e.Bounds;
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 0, 0)), r);
                r.Height--;
                r.Width--;
                e.Graphics.DrawRectangle(Pens.Red, r);
            }
        }
    }

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
        Kopyala,
        Duzenle,
        Kaydet,
        FaizHesapla,
        HizliRapor
    }

    public static class Cast<T>
    {
        public static T It(object o)
        {
            return (T)o;
        }
    }

    public class CommandHandler : DevExpress.XtraPrinting.ICommandHandler
    {

        // This handler is used for the ExportGraphic command.
        public bool CanHandleCommand(PrintingSystemCommand command, IPrintControl printControl)
        {
            return (command == PrintingSystemCommand.SendPdf || command == PrintingSystemCommand.SendCsv || command == PrintingSystemCommand.SendGraphic || command == PrintingSystemCommand.SendMht || command == PrintingSystemCommand.SendRtf || command == PrintingSystemCommand.SendTxt || command == PrintingSystemCommand.SendXls);
        }

        public void HandleCommand(PrintingSystemCommand command, object[] args, IPrintControl printControl, ref bool handled)
        {
            // To prevent stack overflow when invoking standard action
            printControl.PrintingSystem.RemoveCommandHandler(this);

            printControl.PrintingSystem.ExportOptions.PrintPreview.ShowOptionsBeforeExport = false;
            printControl.PrintingSystem.ExportOptions.PrintPreview.SaveMode = SaveMode.UsingDefaultPath;

            // Standard action
            printControl.PrintingSystem.ExecCommand(command);

            printControl.PrintingSystem.ExportOptions.PrintPreview.ShowOptionsBeforeExport = true;
            printControl.PrintingSystem.ExportOptions.PrintPreview.SaveMode = SaveMode.UsingSaveFileDialog;

            // To restore this custom command handler
            printControl.PrintingSystem.AddCommandHandler(this);
            // Set handled to true to avoid the standard exporting procedure to be called.
            handled = true;
        }

    }

    public class GridViewColumnButtonMenu : DevExpress.XtraGrid.Menu.GridViewMenu
    {
        public GridViewColumnButtonMenu(DevExpress.XtraGrid.Views.Grid.GridView view)
            : base(view)
        {
        }

        protected override void CreateItems()
        {
            Items.Clear();
            DXSubMenuItem columnsItem = new DXSubMenuItem("Alan Seçimi");
            if (columnsItem.Visible)
                Items.Add(columnsItem);
            Items.Add(CreateMenuItem("Alan Düzenleme", DevExpress.XtraGrid.Menu.GridMenuImages.Column.Images[3], "Customization", true));
            foreach (GridColumn column in View.Columns)
            {
                if (column.OptionsColumn.ShowInCustomizationForm)
                    columnsItem.Items.Add(CreateMenuCheckItem(column.Caption, column.VisibleIndex >= 0, null, column,
                                                              true));
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
            else if (item.Tag.ToString() == "Customization")
                View.ColumnsCustomization();
        }
    }
}