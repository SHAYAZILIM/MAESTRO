namespace  AdimAdimDavaKaydi.UserControls.UcDava
{
    partial class ucDavaGorusme
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridDavaGorusme = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.Tarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.Aciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.rlueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueRucu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rluePersonelCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueKategori = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rluegorusmeYonu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gwDavaGorusme = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHEDEF_KAYIT_TIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIS_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGORUSME_YONU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGORUSEN_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGORUSEN_TEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGORUSULEN_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGORUSULEN_TEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGORUSENIN_NOTU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISIN_YAPILDIGI_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIS_KAYDEDILSIN_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colMUHASEBELESTIRILSIN_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colAJANDADA_GORUNSUN_MU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colGORUSME_SURE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colONGORULEN_BITIS_TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colONGORULEN_BITIS_SAATI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBITIS_TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBITIS_SAATI = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaGorusme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueRucu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluePersonelCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluegorusmeYonu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwDavaGorusme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDavaGorusme
            // 
            this.gridDavaGorusme.CustomButtonlarGorunmesin = false;
            this.gridDavaGorusme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDavaGorusme.DoNotExtendEmbedNavigator = false;
            this.gridDavaGorusme.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridDavaGorusme.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 6, true, true, "Yeni Kayýt", "FormdanEkle"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, true, "Düzenle", "KaydýDuzenle")});
            this.gridDavaGorusme.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridDavaGorusme_EmbeddedNavigator_ButtonClick);
            this.gridDavaGorusme.ExternalRepository = this.MyRepository;
            this.gridDavaGorusme.FilterText = null;
            this.gridDavaGorusme.FilterValue = null;
            this.gridDavaGorusme.GridlerDuzenlenebilir = true;
            this.gridDavaGorusme.GridsFilterControl = null;
            this.gridDavaGorusme.Location = new System.Drawing.Point(0, 0);
            this.gridDavaGorusme.MainView = this.gwDavaGorusme;
            this.gridDavaGorusme.MyGridStyle = null;
            this.gridDavaGorusme.Name = "gridDavaGorusme";
            this.gridDavaGorusme.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3});
            this.gridDavaGorusme.ShowRowNumbers = false;
            this.gridDavaGorusme.SilmeKaldirilsin = false;
            this.gridDavaGorusme.Size = new System.Drawing.Size(725, 504);
            this.gridDavaGorusme.TabIndex = 0;
            this.gridDavaGorusme.TemizleKaldirGorunsunmu = false;
            this.gridDavaGorusme.UniqueId = "25ce195a-b60b-439b-b992-a7cfcfd04e8e";
            this.gridDavaGorusme.UseEmbeddedNavigator = true;
            this.gridDavaGorusme.UseHyperDragDrop = false;
            this.gridDavaGorusme.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwDavaGorusme});
            this.gridDavaGorusme.ButtonClick += new System.EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(this.gridDavaGorusme_EmbeddedNavigator_ButtonClick);
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Tarih,
            this.Aciklama,
            this.rlueCari,
            this.rlueRucu,
            this.rluePersonelCari,
            this.rlueKategori,
            this.rluegorusmeYonu});
            // 
            // Tarih
            // 
            this.Tarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Tarih.Name = "Tarih";
            this.Tarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // Aciklama
            // 
            this.Aciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Aciklama.Name = "Aciklama";
            // 
            // rlueCari
            // 
            this.rlueCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueCari.Name = "rlueCari";
            // 
            // rlueRucu
            // 
            this.rlueRucu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueRucu.Name = "rlueRucu";
            // 
            // rluePersonelCari
            // 
            this.rluePersonelCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rluePersonelCari.Name = "rluePersonelCari";
            // 
            // rlueKategori
            // 
            this.rlueKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueKategori.Name = "rlueKategori";
            // 
            // rluegorusmeYonu
            // 
            this.rluegorusmeYonu.AutoHeight = false;
            this.rluegorusmeYonu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rluegorusmeYonu.Name = "rluegorusmeYonu";
            // 
            // gwDavaGorusme
            // 
            this.gwDavaGorusme.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTARIH,
            this.colSAAT,
            this.colHEDEF_KAYIT_TIPI,
            this.colIS_KATEGORI_ID,
            this.colGORUSME_YONU,
            this.colGORUSEN_CARI_ID,
            this.colGORUSEN_TEL,
            this.colGORUSULEN_CARI_ID,
            this.colGORUSULEN_TEL,
            this.colGORUSENIN_NOTU,
            this.colISIN_YAPILDIGI_CARI_ID,
            this.colIS_KAYDEDILSIN_MI,
            this.colMUHASEBELESTIRILSIN_MI,
            this.colAJANDADA_GORUNSUN_MU,
            this.colGORUSME_SURE,
            this.colONGORULEN_BITIS_TARIH,
            this.colONGORULEN_BITIS_SAATI,
            this.colBITIS_TARIH,
            this.colBITIS_SAATI});
            this.gwDavaGorusme.GridControl = this.gridDavaGorusme;
            this.gwDavaGorusme.IndicatorWidth = 20;
            this.gwDavaGorusme.Name = "gwDavaGorusme";
            this.gwDavaGorusme.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwDavaGorusme.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gwDavaGorusme.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gwDavaGorusme.OptionsNavigation.AutoFocusNewRow = true;
            this.gwDavaGorusme.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwDavaGorusme.OptionsView.AutoCalcPreviewLineCount = true;
            this.gwDavaGorusme.OptionsView.ColumnAutoWidth = false;
            this.gwDavaGorusme.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gwDavaGorusme.OptionsView.ShowAutoFilterRow = true;
            this.gwDavaGorusme.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwDavaGorusme.OptionsView.ShowPreview = true;
            this.gwDavaGorusme.PreviewFieldName = "GORUSENIN_NOTU";
            // 
            // colTARIH
            // 
            this.colTARIH.Caption = "Tarih";
            this.colTARIH.ColumnEdit = this.Tarih;
            this.colTARIH.FieldName = "TARIH";
            this.colTARIH.Name = "colTARIH";
            this.colTARIH.OptionsColumn.ReadOnly = true;
            this.colTARIH.Visible = true;
            this.colTARIH.VisibleIndex = 0;
            // 
            // colSAAT
            // 
            this.colSAAT.Caption = "Saat";
            this.colSAAT.FieldName = "SAAT";
            this.colSAAT.Name = "colSAAT";
            this.colSAAT.OptionsColumn.ReadOnly = true;
            this.colSAAT.Visible = true;
            this.colSAAT.VisibleIndex = 1;
            // 
            // colHEDEF_KAYIT_TIPI
            // 
            this.colHEDEF_KAYIT_TIPI.Caption = "Hedef Kayýt Tipi";
            this.colHEDEF_KAYIT_TIPI.FieldName = "HEDEF_KAYIT_TIPI";
            this.colHEDEF_KAYIT_TIPI.Name = "colHEDEF_KAYIT_TIPI";
            this.colHEDEF_KAYIT_TIPI.OptionsColumn.ReadOnly = true;
            // 
            // colIS_KATEGORI_ID
            // 
            this.colIS_KATEGORI_ID.Caption = "Ýþ Kategori";
            this.colIS_KATEGORI_ID.ColumnEdit = this.rlueKategori;
            this.colIS_KATEGORI_ID.FieldName = "IS_KATEGORI_ID";
            this.colIS_KATEGORI_ID.Name = "colIS_KATEGORI_ID";
            this.colIS_KATEGORI_ID.OptionsColumn.ReadOnly = true;
            this.colIS_KATEGORI_ID.Visible = true;
            this.colIS_KATEGORI_ID.VisibleIndex = 2;
            // 
            // colGORUSME_YONU
            // 
            this.colGORUSME_YONU.Caption = "Görüþme Yönü";
            this.colGORUSME_YONU.ColumnEdit = this.rluegorusmeYonu;
            this.colGORUSME_YONU.FieldName = "GORUSME_YONU";
            this.colGORUSME_YONU.Name = "colGORUSME_YONU";
            this.colGORUSME_YONU.OptionsColumn.ReadOnly = true;
            this.colGORUSME_YONU.Visible = true;
            this.colGORUSME_YONU.VisibleIndex = 3;
            // 
            // colGORUSEN_CARI_ID
            // 
            this.colGORUSEN_CARI_ID.Caption = "Görüþen";
            this.colGORUSEN_CARI_ID.ColumnEdit = this.rluePersonelCari;
            this.colGORUSEN_CARI_ID.FieldName = "GORUSEN_CARI_ID";
            this.colGORUSEN_CARI_ID.Name = "colGORUSEN_CARI_ID";
            this.colGORUSEN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colGORUSEN_CARI_ID.Visible = true;
            this.colGORUSEN_CARI_ID.VisibleIndex = 4;
            // 
            // colGORUSEN_TEL
            // 
            this.colGORUSEN_TEL.Caption = "Görüþen Tel";
            this.colGORUSEN_TEL.FieldName = "GORUSEN_TEL";
            this.colGORUSEN_TEL.Name = "colGORUSEN_TEL";
            this.colGORUSEN_TEL.OptionsColumn.ReadOnly = true;
            this.colGORUSEN_TEL.Visible = true;
            this.colGORUSEN_TEL.VisibleIndex = 5;
            // 
            // colGORUSULEN_CARI_ID
            // 
            this.colGORUSULEN_CARI_ID.Caption = "Görüþülen";
            this.colGORUSULEN_CARI_ID.ColumnEdit = this.rlueCari;
            this.colGORUSULEN_CARI_ID.FieldName = "GORUSULEN_CARI_ID";
            this.colGORUSULEN_CARI_ID.Name = "colGORUSULEN_CARI_ID";
            this.colGORUSULEN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colGORUSULEN_CARI_ID.Visible = true;
            this.colGORUSULEN_CARI_ID.VisibleIndex = 6;
            // 
            // colGORUSULEN_TEL
            // 
            this.colGORUSULEN_TEL.Caption = "Görüþülen Tel.";
            this.colGORUSULEN_TEL.FieldName = "GORUSULEN_TEL";
            this.colGORUSULEN_TEL.Name = "colGORUSULEN_TEL";
            this.colGORUSULEN_TEL.OptionsColumn.ReadOnly = true;
            this.colGORUSULEN_TEL.Visible = true;
            this.colGORUSULEN_TEL.VisibleIndex = 7;
            // 
            // colGORUSENIN_NOTU
            // 
            this.colGORUSENIN_NOTU.Caption = "Görüþenin Notu";
            this.colGORUSENIN_NOTU.ColumnEdit = this.Aciklama;
            this.colGORUSENIN_NOTU.FieldName = "GORUSENIN_NOTU";
            this.colGORUSENIN_NOTU.Name = "colGORUSENIN_NOTU";
            this.colGORUSENIN_NOTU.OptionsColumn.ReadOnly = true;
            this.colGORUSENIN_NOTU.Visible = true;
            this.colGORUSENIN_NOTU.VisibleIndex = 8;
            // 
            // colISIN_YAPILDIGI_CARI_ID
            // 
            this.colISIN_YAPILDIGI_CARI_ID.Caption = "Ýþin Yapýldýðý";
            this.colISIN_YAPILDIGI_CARI_ID.ColumnEdit = this.rlueCari;
            this.colISIN_YAPILDIGI_CARI_ID.FieldName = "ISIN_YAPILDIGI_CARI_ID";
            this.colISIN_YAPILDIGI_CARI_ID.Name = "colISIN_YAPILDIGI_CARI_ID";
            this.colISIN_YAPILDIGI_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colISIN_YAPILDIGI_CARI_ID.Visible = true;
            this.colISIN_YAPILDIGI_CARI_ID.VisibleIndex = 9;
            // 
            // colIS_KAYDEDILSIN_MI
            // 
            this.colIS_KAYDEDILSIN_MI.Caption = "Ýþ Kaydedilsin mi";
            this.colIS_KAYDEDILSIN_MI.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIS_KAYDEDILSIN_MI.FieldName = "IS_KAYDEDILSIN_MI";
            this.colIS_KAYDEDILSIN_MI.Name = "colIS_KAYDEDILSIN_MI";
            this.colIS_KAYDEDILSIN_MI.OptionsColumn.ReadOnly = true;
            this.colIS_KAYDEDILSIN_MI.Visible = true;
            this.colIS_KAYDEDILSIN_MI.VisibleIndex = 10;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.DisplayValueChecked = "Ýþ Kayýt Edilsin";
            this.repositoryItemCheckEdit1.DisplayValueUnchecked = "Ýþ Kayýt Edilmesin";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colMUHASEBELESTIRILSIN_MI
            // 
            this.colMUHASEBELESTIRILSIN_MI.Caption = "Muhasebeleþtirilsin mi";
            this.colMUHASEBELESTIRILSIN_MI.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colMUHASEBELESTIRILSIN_MI.FieldName = "MUHASEBELESTIRILSIN_MI";
            this.colMUHASEBELESTIRILSIN_MI.Name = "colMUHASEBELESTIRILSIN_MI";
            this.colMUHASEBELESTIRILSIN_MI.OptionsColumn.ReadOnly = true;
            this.colMUHASEBELESTIRILSIN_MI.Visible = true;
            this.colMUHASEBELESTIRILSIN_MI.VisibleIndex = 11;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.DisplayValueChecked = "Muhasebeleþtirilsin";
            this.repositoryItemCheckEdit2.DisplayValueUnchecked = "Muhasebeleþtirilmesin";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // colAJANDADA_GORUNSUN_MU
            // 
            this.colAJANDADA_GORUNSUN_MU.Caption = "Ajanda da Görünsün mü";
            this.colAJANDADA_GORUNSUN_MU.ColumnEdit = this.repositoryItemCheckEdit3;
            this.colAJANDADA_GORUNSUN_MU.FieldName = "AJANDADA_GORUNSUN_MU";
            this.colAJANDADA_GORUNSUN_MU.Name = "colAJANDADA_GORUNSUN_MU";
            this.colAJANDADA_GORUNSUN_MU.OptionsColumn.ReadOnly = true;
            this.colAJANDADA_GORUNSUN_MU.Visible = true;
            this.colAJANDADA_GORUNSUN_MU.VisibleIndex = 12;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.DisplayValueChecked = "Ajanda da Görünsün";
            this.repositoryItemCheckEdit3.DisplayValueUnchecked = "Ajanda da Görünmesin";
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // colGORUSME_SURE
            // 
            this.colGORUSME_SURE.Caption = "Görüþme Süre";
            this.colGORUSME_SURE.FieldName = "GORUSME_SURE";
            this.colGORUSME_SURE.Name = "colGORUSME_SURE";
            this.colGORUSME_SURE.OptionsColumn.ReadOnly = true;
            this.colGORUSME_SURE.Visible = true;
            this.colGORUSME_SURE.VisibleIndex = 13;
            // 
            // colONGORULEN_BITIS_TARIH
            // 
            this.colONGORULEN_BITIS_TARIH.Caption = "ONGORULEN_BITIS_TARIH";
            this.colONGORULEN_BITIS_TARIH.ColumnEdit = this.Tarih;
            this.colONGORULEN_BITIS_TARIH.FieldName = "ONGORULEN_BITIS_TARIH";
            this.colONGORULEN_BITIS_TARIH.Name = "colONGORULEN_BITIS_TARIH";
            this.colONGORULEN_BITIS_TARIH.OptionsColumn.ReadOnly = true;
            // 
            // colONGORULEN_BITIS_SAATI
            // 
            this.colONGORULEN_BITIS_SAATI.Caption = "ONGORULEN_BITIS_SAATI";
            this.colONGORULEN_BITIS_SAATI.FieldName = "ONGORULEN_BITIS_SAATI";
            this.colONGORULEN_BITIS_SAATI.Name = "colONGORULEN_BITIS_SAATI";
            this.colONGORULEN_BITIS_SAATI.OptionsColumn.ReadOnly = true;
            // 
            // colBITIS_TARIH
            // 
            this.colBITIS_TARIH.Caption = "Bitiþ T.";
            this.colBITIS_TARIH.ColumnEdit = this.Tarih;
            this.colBITIS_TARIH.FieldName = "BITIS_TARIH";
            this.colBITIS_TARIH.Name = "colBITIS_TARIH";
            this.colBITIS_TARIH.OptionsColumn.ReadOnly = true;
            this.colBITIS_TARIH.Visible = true;
            this.colBITIS_TARIH.VisibleIndex = 14;
            // 
            // colBITIS_SAATI
            // 
            this.colBITIS_SAATI.Caption = "Bitiþ S.";
            this.colBITIS_SAATI.FieldName = "BITIS_SAATI";
            this.colBITIS_SAATI.Name = "colBITIS_SAATI";
            this.colBITIS_SAATI.OptionsColumn.ReadOnly = true;
            this.colBITIS_SAATI.Visible = true;
            this.colBITIS_SAATI.VisibleIndex = 15;
            // 
            // ucDavaGorusme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridDavaGorusme);
            this.Name = "ucDavaGorusme";
            this.Size = new System.Drawing.Size(725, 504);
            this.Load += new System.EventHandler(this.ucDavaGorusme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaGorusme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueRucu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluePersonelCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluegorusmeYonu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwDavaGorusme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDavaGorusme;
        private DevExpress.XtraGrid.Views.Grid.GridView gwDavaGorusme;
        private DevExpress.XtraGrid.Columns.GridColumn colTARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colSAAT;
        private DevExpress.XtraGrid.Columns.GridColumn colHEDEF_KAYIT_TIPI;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_KATEGORI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colGORUSME_YONU;
        private DevExpress.XtraGrid.Columns.GridColumn colGORUSEN_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colGORUSEN_TEL;
        private DevExpress.XtraGrid.Columns.GridColumn colGORUSULEN_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colGORUSULEN_TEL;
        private DevExpress.XtraGrid.Columns.GridColumn colGORUSENIN_NOTU;
        private DevExpress.XtraGrid.Columns.GridColumn colISIN_YAPILDIGI_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_KAYDEDILSIN_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colMUHASEBELESTIRILSIN_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colAJANDADA_GORUNSUN_MU;
        private DevExpress.XtraGrid.Columns.GridColumn colGORUSME_SURE;
        private DevExpress.XtraGrid.Columns.GridColumn colONGORULEN_BITIS_TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colONGORULEN_BITIS_SAATI;
        private DevExpress.XtraGrid.Columns.GridColumn colBITIS_TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colBITIS_SAATI;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit Tarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit Aciklama;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueRucu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluePersonelCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueKategori;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluegorusmeYonu;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
    }
}
