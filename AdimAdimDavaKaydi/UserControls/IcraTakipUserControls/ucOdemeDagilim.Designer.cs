namespace  AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    partial class ucOdemeDagilim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOdemeDagilim));
            this.gridOdemeDagilim = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueFoyTarafID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueAlacakNedenTarafID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueMahsupKategoriID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueMahsupAltKategoriID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueDovizID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueAlacakNedenID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueDagilimTipID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueIlamID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gwOdemeDagilim = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rudTutar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colTUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_KARSILIK_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAHSUP_ALT_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAHSUP_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALACAK_NEDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALACAK_NEDEN_TARAF_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFOY_TARAF_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colILAM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAGILIM_TIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.compGridDovizSummary1 = new AdimAdimDavaKaydi.Util.compGridDovizSummary(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridOdemeDagilim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFoyTarafID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakNedenTarafID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMahsupKategoriID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMahsupAltKategoriID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakNedenID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDagilimTipID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIlamID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwOdemeDagilim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudTutar)).BeginInit();
            this.SuspendLayout();
            // 
            // gridOdemeDagilim
            // 
            this.gridOdemeDagilim.CustomButtonlarGorunmesin = false;
            resources.ApplyResources(this.gridOdemeDagilim, "gridOdemeDagilim");
            this.gridOdemeDagilim.DoNotExtendEmbedNavigator = false;
            this.gridOdemeDagilim.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridOdemeDagilim.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridOdemeDagilim.ExternalRepository = this.MyRepository;
            this.gridOdemeDagilim.FilterText = null;
            this.gridOdemeDagilim.FilterValue = null;
            this.gridOdemeDagilim.GridlerDuzenlenebilir = true;
            this.gridOdemeDagilim.GridsFilterControl = null;
            this.gridOdemeDagilim.MainView = this.gwOdemeDagilim;
            this.gridOdemeDagilim.MyGridStyle = null;
            this.gridOdemeDagilim.Name = "gridOdemeDagilim";
            this.gridOdemeDagilim.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rudTutar});
            this.gridOdemeDagilim.ShowOnlyPredefinedDetails = true;
            this.gridOdemeDagilim.ShowRowNumbers = false;
            this.gridOdemeDagilim.SilmeKaldirilsin = false;
            this.gridOdemeDagilim.TemizleKaldirGorunsunmu = false;
            this.gridOdemeDagilim.UniqueId = "a30034e0-0380-484c-9a97-af46df61b012";
            this.gridOdemeDagilim.UseEmbeddedNavigator = true;
            this.gridOdemeDagilim.UseHyperDragDrop = false;
            this.gridOdemeDagilim.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwOdemeDagilim});
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueFoyTarafID,
            this.rLueAlacakNedenTarafID,
            this.rLueMahsupKategoriID,
            this.rLueMahsupAltKategoriID,
            this.rLueDovizID,
            this.rLueAlacakNedenID,
            this.rLueDagilimTipID,
            this.rLueIlamID});
            // 
            // rLueFoyTarafID
            // 
            this.rLueFoyTarafID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueFoyTarafID.Buttons"))))});
            this.rLueFoyTarafID.Name = "rLueFoyTarafID";
            // 
            // rLueAlacakNedenTarafID
            // 
            this.rLueAlacakNedenTarafID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueAlacakNedenTarafID.Buttons"))))});
            this.rLueAlacakNedenTarafID.Name = "rLueAlacakNedenTarafID";
            // 
            // rLueMahsupKategoriID
            // 
            this.rLueMahsupKategoriID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueMahsupKategoriID.Buttons"))))});
            this.rLueMahsupKategoriID.Name = "rLueMahsupKategoriID";
            // 
            // rLueMahsupAltKategoriID
            // 
            this.rLueMahsupAltKategoriID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueMahsupAltKategoriID.Buttons"))))});
            this.rLueMahsupAltKategoriID.Name = "rLueMahsupAltKategoriID";
            // 
            // rLueDovizID
            // 
            this.rLueDovizID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueDovizID.Buttons"))))});
            this.rLueDovizID.Name = "rLueDovizID";
            // 
            // rLueAlacakNedenID
            // 
            this.rLueAlacakNedenID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueAlacakNedenID.Buttons"))))});
            this.rLueAlacakNedenID.Name = "rLueAlacakNedenID";
            // 
            // rLueDagilimTipID
            // 
            resources.ApplyResources(this.rLueDagilimTipID, "rLueDagilimTipID");
            this.rLueDagilimTipID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueDagilimTipID.Buttons"))))});
            this.rLueDagilimTipID.Name = "rLueDagilimTipID";
            // 
            // rLueIlamID
            // 
            resources.ApplyResources(this.rLueIlamID, "rLueIlamID");
            this.rLueIlamID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueIlamID.Buttons"))))});
            this.rLueIlamID.Name = "rLueIlamID";
            // 
            // gwOdemeDagilim
            // 
            this.gwOdemeDagilim.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTUTAR,
            this.colTUTAR_DOVIZ_ID,
            this.colODEME_KARSILIK_TUTAR,
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID,
            this.colODEME_ID,
            this.colODEME_TARIHI,
            this.colMAHSUP_ALT_KATEGORI_ID,
            this.colMAHSUP_KATEGORI_ID,
            this.colALACAK_NEDEN_ID,
            this.colALACAK_NEDEN_TARAF_ID,
            this.colFOY_TARAF_ID,
            this.colILAM_ID,
            this.colDAGILIM_TIPI});
            this.gwOdemeDagilim.GridControl = this.gridOdemeDagilim;
            this.gwOdemeDagilim.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary"))), resources.GetString("gwOdemeDagilim.GroupSummary1"), this.colODEME_KARSILIK_TUTAR, resources.GetString("gwOdemeDagilim.GroupSummary2")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary3"))), resources.GetString("gwOdemeDagilim.GroupSummary4"), this.colTUTAR, resources.GetString("gwOdemeDagilim.GroupSummary5")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary6"))), resources.GetString("gwOdemeDagilim.GroupSummary7"), this.colTUTAR, resources.GetString("gwOdemeDagilim.GroupSummary8")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary9"))), resources.GetString("gwOdemeDagilim.GroupSummary10"), this.colTUTAR_DOVIZ_ID, resources.GetString("gwOdemeDagilim.GroupSummary11")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary12"))), resources.GetString("gwOdemeDagilim.GroupSummary13"), this.colODEME_KARSILIK_TUTAR, resources.GetString("gwOdemeDagilim.GroupSummary14")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary15"))), resources.GetString("gwOdemeDagilim.GroupSummary16"), this.colODEME_KARSILIK_TUTAR_DOVIZ_ID, resources.GetString("gwOdemeDagilim.GroupSummary17")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary18"))), resources.GetString("gwOdemeDagilim.GroupSummary19"), this.colTUTAR, resources.GetString("gwOdemeDagilim.GroupSummary20")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary21"))), resources.GetString("gwOdemeDagilim.GroupSummary22"), this.colTUTAR_DOVIZ_ID, resources.GetString("gwOdemeDagilim.GroupSummary23")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary24"))), resources.GetString("gwOdemeDagilim.GroupSummary25"), this.colODEME_KARSILIK_TUTAR, resources.GetString("gwOdemeDagilim.GroupSummary26")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary27"))), resources.GetString("gwOdemeDagilim.GroupSummary28"), this.colODEME_KARSILIK_TUTAR_DOVIZ_ID, resources.GetString("gwOdemeDagilim.GroupSummary29")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary30"))), resources.GetString("gwOdemeDagilim.GroupSummary31"), this.colTUTAR, resources.GetString("gwOdemeDagilim.GroupSummary32")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary33"))), resources.GetString("gwOdemeDagilim.GroupSummary34"), this.colTUTAR_DOVIZ_ID, resources.GetString("gwOdemeDagilim.GroupSummary35")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary36"))), resources.GetString("gwOdemeDagilim.GroupSummary37"), this.colODEME_KARSILIK_TUTAR, resources.GetString("gwOdemeDagilim.GroupSummary38")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary39"))), resources.GetString("gwOdemeDagilim.GroupSummary40"), this.colODEME_KARSILIK_TUTAR_DOVIZ_ID, resources.GetString("gwOdemeDagilim.GroupSummary41")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary42"))), resources.GetString("gwOdemeDagilim.GroupSummary43"), this.colTUTAR, resources.GetString("gwOdemeDagilim.GroupSummary44")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary45"))), resources.GetString("gwOdemeDagilim.GroupSummary46"), this.colTUTAR_DOVIZ_ID, resources.GetString("gwOdemeDagilim.GroupSummary47")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary48"))), resources.GetString("gwOdemeDagilim.GroupSummary49"), this.colODEME_KARSILIK_TUTAR, resources.GetString("gwOdemeDagilim.GroupSummary50")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwOdemeDagilim.GroupSummary51"))), resources.GetString("gwOdemeDagilim.GroupSummary52"), this.colODEME_KARSILIK_TUTAR_DOVIZ_ID, resources.GetString("gwOdemeDagilim.GroupSummary53"))});
            this.gwOdemeDagilim.IndicatorWidth = 20;
            this.gwOdemeDagilim.Name = "gwOdemeDagilim";
            this.gwOdemeDagilim.OptionsBehavior.FocusLeaveOnTab = true;
            this.gwOdemeDagilim.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwOdemeDagilim.OptionsNavigation.AutoFocusNewRow = true;
            this.gwOdemeDagilim.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwOdemeDagilim.OptionsView.ColumnAutoWidth = false;
            this.gwOdemeDagilim.OptionsView.ShowAutoFilterRow = true;
            this.gwOdemeDagilim.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwOdemeDagilim.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gwOdemeDagilim.OptionsView.ShowFooter = true;
            // 
            // colTUTAR
            // 
            resources.ApplyResources(this.colTUTAR, "colTUTAR");
            this.colTUTAR.ColumnEdit = this.rudTutar;
            this.colTUTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colTUTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTUTAR.FieldName = "TUTAR";
            this.colTUTAR.Name = "colTUTAR";
            this.colTUTAR.OptionsColumn.ReadOnly = true;
            this.colTUTAR.SummaryItem.DisplayFormat = resources.GetString("colTUTAR.SummaryItem.DisplayFormat");
            this.colTUTAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            // 
            // rudTutar
            // 
            resources.ApplyResources(this.rudTutar, "rudTutar");
            this.rudTutar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rudTutar.Name = "rudTutar";
            // 
            // colTUTAR_DOVIZ_ID
            // 
            resources.ApplyResources(this.colTUTAR_DOVIZ_ID, "colTUTAR_DOVIZ_ID");
            this.colTUTAR_DOVIZ_ID.ColumnEdit = this.rLueDovizID;
            this.colTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            this.colTUTAR_DOVIZ_ID.Name = "colTUTAR_DOVIZ_ID";
            this.colTUTAR_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colTUTAR_DOVIZ_ID.SummaryItem.DisplayFormat = resources.GetString("colTUTAR_DOVIZ_ID.SummaryItem.DisplayFormat");
            this.colTUTAR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            // 
            // colODEME_KARSILIK_TUTAR
            // 
            resources.ApplyResources(this.colODEME_KARSILIK_TUTAR, "colODEME_KARSILIK_TUTAR");
            this.colODEME_KARSILIK_TUTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colODEME_KARSILIK_TUTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colODEME_KARSILIK_TUTAR.FieldName = "ODEME_KARSILIK_TUTAR";
            this.colODEME_KARSILIK_TUTAR.Name = "colODEME_KARSILIK_TUTAR";
            this.colODEME_KARSILIK_TUTAR.OptionsColumn.ReadOnly = true;
            this.colODEME_KARSILIK_TUTAR.SummaryItem.DisplayFormat = resources.GetString("colODEME_KARSILIK_TUTAR.SummaryItem.DisplayFormat");
            this.colODEME_KARSILIK_TUTAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            // 
            // colODEME_KARSILIK_TUTAR_DOVIZ_ID
            // 
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID.ColumnEdit = this.rLueDovizID;
            resources.ApplyResources(this.colODEME_KARSILIK_TUTAR_DOVIZ_ID, "colODEME_KARSILIK_TUTAR_DOVIZ_ID");
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID.FieldName = "ODEME_KARSILIK_TUTAR_DOVIZ_ID";
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID.Name = "colODEME_KARSILIK_TUTAR_DOVIZ_ID";
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID.SummaryItem.DisplayFormat = resources.GetString("colODEME_KARSILIK_TUTAR_DOVIZ_ID.SummaryItem.DisplayFormat");
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            // 
            // colODEME_ID
            // 
            resources.ApplyResources(this.colODEME_ID, "colODEME_ID");
            this.colODEME_ID.FieldName = "ODEME_ID";
            this.colODEME_ID.Name = "colODEME_ID";
            this.colODEME_ID.OptionsColumn.ReadOnly = true;
            // 
            // colODEME_TARIHI
            // 
            resources.ApplyResources(this.colODEME_TARIHI, "colODEME_TARIHI");
            this.colODEME_TARIHI.FieldName = "ODEME_TARIHI";
            this.colODEME_TARIHI.Name = "colODEME_TARIHI";
            this.colODEME_TARIHI.OptionsColumn.ReadOnly = true;
            // 
            // colMAHSUP_ALT_KATEGORI_ID
            // 
            resources.ApplyResources(this.colMAHSUP_ALT_KATEGORI_ID, "colMAHSUP_ALT_KATEGORI_ID");
            this.colMAHSUP_ALT_KATEGORI_ID.ColumnEdit = this.rLueMahsupAltKategoriID;
            this.colMAHSUP_ALT_KATEGORI_ID.FieldName = "MAHSUP_ALT_KATEGORI_ID";
            this.colMAHSUP_ALT_KATEGORI_ID.Name = "colMAHSUP_ALT_KATEGORI_ID";
            this.colMAHSUP_ALT_KATEGORI_ID.OptionsColumn.ReadOnly = true;
            // 
            // colMAHSUP_KATEGORI_ID
            // 
            resources.ApplyResources(this.colMAHSUP_KATEGORI_ID, "colMAHSUP_KATEGORI_ID");
            this.colMAHSUP_KATEGORI_ID.ColumnEdit = this.rLueMahsupKategoriID;
            this.colMAHSUP_KATEGORI_ID.FieldName = "MAHSUP_KATEGORI_ID";
            this.colMAHSUP_KATEGORI_ID.Name = "colMAHSUP_KATEGORI_ID";
            this.colMAHSUP_KATEGORI_ID.OptionsColumn.ReadOnly = true;
            // 
            // colALACAK_NEDEN_ID
            // 
            resources.ApplyResources(this.colALACAK_NEDEN_ID, "colALACAK_NEDEN_ID");
            this.colALACAK_NEDEN_ID.ColumnEdit = this.rLueAlacakNedenID;
            this.colALACAK_NEDEN_ID.FieldName = "ALACAK_NEDEN_ID";
            this.colALACAK_NEDEN_ID.Name = "colALACAK_NEDEN_ID";
            this.colALACAK_NEDEN_ID.OptionsColumn.ReadOnly = true;
            // 
            // colALACAK_NEDEN_TARAF_ID
            // 
            resources.ApplyResources(this.colALACAK_NEDEN_TARAF_ID, "colALACAK_NEDEN_TARAF_ID");
            this.colALACAK_NEDEN_TARAF_ID.ColumnEdit = this.rLueAlacakNedenTarafID;
            this.colALACAK_NEDEN_TARAF_ID.FieldName = "ALACAK_NEDEN_TARAF_ID";
            this.colALACAK_NEDEN_TARAF_ID.Name = "colALACAK_NEDEN_TARAF_ID";
            this.colALACAK_NEDEN_TARAF_ID.OptionsColumn.ReadOnly = true;
            // 
            // colFOY_TARAF_ID
            // 
            resources.ApplyResources(this.colFOY_TARAF_ID, "colFOY_TARAF_ID");
            this.colFOY_TARAF_ID.ColumnEdit = this.rLueFoyTarafID;
            this.colFOY_TARAF_ID.FieldName = "FOY_TARAF_ID";
            this.colFOY_TARAF_ID.Name = "colFOY_TARAF_ID";
            this.colFOY_TARAF_ID.OptionsColumn.ReadOnly = true;
            // 
            // colILAM_ID
            // 
            resources.ApplyResources(this.colILAM_ID, "colILAM_ID");
            this.colILAM_ID.ColumnEdit = this.rLueIlamID;
            this.colILAM_ID.FieldName = "ILAM_ID";
            this.colILAM_ID.Name = "colILAM_ID";
            this.colILAM_ID.OptionsColumn.ReadOnly = true;
            // 
            // colDAGILIM_TIPI
            // 
            resources.ApplyResources(this.colDAGILIM_TIPI, "colDAGILIM_TIPI");
            this.colDAGILIM_TIPI.ColumnEdit = this.rLueDagilimTipID;
            this.colDAGILIM_TIPI.FieldName = "DAGILIM_TIPI";
            this.colDAGILIM_TIPI.Name = "colDAGILIM_TIPI";
            this.colDAGILIM_TIPI.OptionsColumn.ReadOnly = true;
            // 
            // compGridDovizSummary1
            // 
            this.compGridDovizSummary1.AltToplamlarAktifMi = true;
            this.compGridDovizSummary1.MyGridView = this.gwOdemeDagilim;
            // 
            // ucOdemeDagilim
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridOdemeDagilim);
            this.Name = "ucOdemeDagilim";
            this.Load += new System.EventHandler(this.ucOdemeDagilim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridOdemeDagilim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFoyTarafID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakNedenTarafID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMahsupKategoriID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMahsupAltKategoriID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakNedenID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDagilimTipID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIlamID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwOdemeDagilim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudTutar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridOdemeDagilim;
        private DevExpress.XtraGrid.Views.Grid.GridView gwOdemeDagilim;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_KARSILIK_TUTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_KARSILIK_TUTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colMAHSUP_ALT_KATEGORI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colMAHSUP_KATEGORI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colALACAK_NEDEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colALACAK_NEDEN_TARAF_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colFOY_TARAF_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colILAM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDAGILIM_TIPI;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueFoyTarafID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAlacakNedenTarafID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMahsupKategoriID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMahsupAltKategoriID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAlacakNedenID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDagilimTipID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueIlamID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rudTutar;
        private AdimAdimDavaKaydi.Util.compGridDovizSummary compGridDovizSummary1;
    }
}
