namespace  AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    partial class ucTaahhutler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTaahhutler));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView12 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSIRA_NO1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDURUM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDurumID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTAAHHUTU_YERINE_GETIRME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAAHHUT_MIKTARI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDovizID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTAAHHUT_MIKTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAAHHUTTEN_KALAN_MIKTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_MIKTARI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_MIKTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridBorcluTaahhut = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueBorcluCariID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gwBorcluTaahhut = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTAAHHUT_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colTAAHHUT_EDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAAHHUDU_KABUL_EDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueAlacakliCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTAAHHUT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAAHHUDU_KABUL_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAAHHUDUN_YERINE_GETIRILME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAVASI_VAR_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.IsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TAAHHUT_SIRA_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.compGridDovizSummary1 = new AdimAdimDavaKaydi.Util.compGridDovizSummary(this.components);
            this.compGridDovizSummary2 = new AdimAdimDavaKaydi.Util.compGridDovizSummary(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridView12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDurumID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBorcluTaahhut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBorcluCariID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwBorcluTaahhut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAlacakliCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView12
            // 
            this.gridView12.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSIRA_NO1,
            this.colDURUM_ID,
            this.colTAAHHUTU_YERINE_GETIRME_TARIHI,
            this.colTAAHHUT_MIKTARI_DOVIZ_ID,
            this.colTAAHHUT_MIKTARI,
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID,
            this.colTAAHHUTTEN_KALAN_MIKTAR,
            this.colODEME_MIKTARI_DOVIZ_ID,
            this.colODEME_MIKTARI});
            this.gridView12.GridControl = this.gridBorcluTaahhut;
            this.gridView12.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gridView12.GroupSummary"))), resources.GetString("gridView12.GroupSummary1"), this.colTAAHHUT_MIKTARI, resources.GetString("gridView12.GroupSummary2")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gridView12.GroupSummary3"))), resources.GetString("gridView12.GroupSummary4"), this.colTAAHHUT_MIKTARI_DOVIZ_ID, resources.GetString("gridView12.GroupSummary5")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gridView12.GroupSummary6"))), resources.GetString("gridView12.GroupSummary7"), this.colTAAHHUTTEN_KALAN_MIKTAR, resources.GetString("gridView12.GroupSummary8")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gridView12.GroupSummary9"))), resources.GetString("gridView12.GroupSummary10"), this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID, resources.GetString("gridView12.GroupSummary11")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gridView12.GroupSummary12"))), resources.GetString("gridView12.GroupSummary13"), this.colODEME_MIKTARI, resources.GetString("gridView12.GroupSummary14")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gridView12.GroupSummary15"))), resources.GetString("gridView12.GroupSummary16"), this.colODEME_MIKTARI_DOVIZ_ID, resources.GetString("gridView12.GroupSummary17"))});
            this.gridView12.Name = "gridView12";
            this.gridView12.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView12.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView12.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView12.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView12.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView12.OptionsView.ColumnAutoWidth = false;
            this.gridView12.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView12.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView12.OptionsView.ShowAutoFilterRow = true;
            this.gridView12.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView12.OptionsView.ShowFooter = true;
            this.gridView12.PaintStyleName = "Skin";
            resources.ApplyResources(this.gridView12, "gridView12");
            // 
            // colSIRA_NO1
            // 
            resources.ApplyResources(this.colSIRA_NO1, "colSIRA_NO1");
            this.colSIRA_NO1.FieldName = "SIRA_NO";
            this.colSIRA_NO1.Name = "colSIRA_NO1";
            // 
            // colDURUM_ID
            // 
            resources.ApplyResources(this.colDURUM_ID, "colDURUM_ID");
            this.colDURUM_ID.ColumnEdit = this.rLueDurumID;
            this.colDURUM_ID.FieldName = "DURUM_ID";
            this.colDURUM_ID.Name = "colDURUM_ID";
            // 
            // rLueDurumID
            // 
            this.rLueDurumID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueDurumID.Buttons"))))});
            this.rLueDurumID.Name = "rLueDurumID";
            // 
            // colTAAHHUTU_YERINE_GETIRME_TARIHI
            // 
            resources.ApplyResources(this.colTAAHHUTU_YERINE_GETIRME_TARIHI, "colTAAHHUTU_YERINE_GETIRME_TARIHI");
            this.colTAAHHUTU_YERINE_GETIRME_TARIHI.FieldName = "TAAHHUTU_YERINE_GETIRME_TARIHI";
            this.colTAAHHUTU_YERINE_GETIRME_TARIHI.Name = "colTAAHHUTU_YERINE_GETIRME_TARIHI";
            // 
            // colTAAHHUT_MIKTARI_DOVIZ_ID
            // 
            resources.ApplyResources(this.colTAAHHUT_MIKTARI_DOVIZ_ID, "colTAAHHUT_MIKTARI_DOVIZ_ID");
            this.colTAAHHUT_MIKTARI_DOVIZ_ID.ColumnEdit = this.rLueDovizID;
            this.colTAAHHUT_MIKTARI_DOVIZ_ID.FieldName = "TAAHHUT_MIKTARI_DOVIZ_ID";
            this.colTAAHHUT_MIKTARI_DOVIZ_ID.Name = "colTAAHHUT_MIKTARI_DOVIZ_ID";
            this.colTAAHHUT_MIKTARI_DOVIZ_ID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colTAAHHUT_MIKTARI_DOVIZ_ID.Summary"))), resources.GetString("colTAAHHUT_MIKTARI_DOVIZ_ID.Summary1"), resources.GetString("colTAAHHUT_MIKTARI_DOVIZ_ID.Summary2"))});
            // 
            // rLueDovizID
            // 
            this.rLueDovizID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueDovizID.Buttons"))))});
            this.rLueDovizID.Name = "rLueDovizID";
            // 
            // colTAAHHUT_MIKTARI
            // 
            resources.ApplyResources(this.colTAAHHUT_MIKTARI, "colTAAHHUT_MIKTARI");
            this.colTAAHHUT_MIKTARI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colTAAHHUT_MIKTARI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTAAHHUT_MIKTARI.FieldName = "TAAHHUT_MIKTARI";
            this.colTAAHHUT_MIKTARI.Name = "colTAAHHUT_MIKTARI";
            this.colTAAHHUT_MIKTARI.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colTAAHHUT_MIKTARI.Summary"))), resources.GetString("colTAAHHUT_MIKTARI.Summary1"), resources.GetString("colTAAHHUT_MIKTARI.Summary2"))});
            // 
            // colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID
            // 
            resources.ApplyResources(this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID, "colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID");
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.ColumnEdit = this.rLueDovizID;
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.FieldName = "TAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID";
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Name = "colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID";
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Summary"))), resources.GetString("colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Summary1"), resources.GetString("colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Summary2"))});
            // 
            // colTAAHHUTTEN_KALAN_MIKTAR
            // 
            resources.ApplyResources(this.colTAAHHUTTEN_KALAN_MIKTAR, "colTAAHHUTTEN_KALAN_MIKTAR");
            this.colTAAHHUTTEN_KALAN_MIKTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colTAAHHUTTEN_KALAN_MIKTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTAAHHUTTEN_KALAN_MIKTAR.FieldName = "TAAHHUTTEN_KALAN_MIKTAR";
            this.colTAAHHUTTEN_KALAN_MIKTAR.Name = "colTAAHHUTTEN_KALAN_MIKTAR";
            this.colTAAHHUTTEN_KALAN_MIKTAR.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colTAAHHUTTEN_KALAN_MIKTAR.Summary"))), resources.GetString("colTAAHHUTTEN_KALAN_MIKTAR.Summary1"), resources.GetString("colTAAHHUTTEN_KALAN_MIKTAR.Summary2"))});
            // 
            // colODEME_MIKTARI_DOVIZ_ID
            // 
            resources.ApplyResources(this.colODEME_MIKTARI_DOVIZ_ID, "colODEME_MIKTARI_DOVIZ_ID");
            this.colODEME_MIKTARI_DOVIZ_ID.ColumnEdit = this.rLueDovizID;
            this.colODEME_MIKTARI_DOVIZ_ID.FieldName = "ODEME_MIKTARI_DOVIZ_ID";
            this.colODEME_MIKTARI_DOVIZ_ID.Name = "colODEME_MIKTARI_DOVIZ_ID";
            this.colODEME_MIKTARI_DOVIZ_ID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colODEME_MIKTARI_DOVIZ_ID.Summary"))), resources.GetString("colODEME_MIKTARI_DOVIZ_ID.Summary1"), resources.GetString("colODEME_MIKTARI_DOVIZ_ID.Summary2"))});
            // 
            // colODEME_MIKTARI
            // 
            resources.ApplyResources(this.colODEME_MIKTARI, "colODEME_MIKTARI");
            this.colODEME_MIKTARI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colODEME_MIKTARI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colODEME_MIKTARI.FieldName = "ODEME_MIKTARI";
            this.colODEME_MIKTARI.Name = "colODEME_MIKTARI";
            this.colODEME_MIKTARI.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colODEME_MIKTARI.Summary"))), resources.GetString("colODEME_MIKTARI.Summary1"), resources.GetString("colODEME_MIKTARI.Summary2"))});
            // 
            // gridBorcluTaahhut
            // 
            this.gridBorcluTaahhut.CustomButtonlarGorunmesin = false;
            resources.ApplyResources(this.gridBorcluTaahhut, "gridBorcluTaahhut");
            this.gridBorcluTaahhut.DoNotExtendEmbedNavigator = false;
            this.gridBorcluTaahhut.EmbeddedNavigator.Buttons.Append.Tag = "";
            this.gridBorcluTaahhut.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridBorcluTaahhut.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridBorcluTaahhut.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(((int)(resources.GetObject("gridBorcluTaahhut.EmbeddedNavigator.CustomButtons"))), ((int)(resources.GetObject("gridBorcluTaahhut.EmbeddedNavigator.CustomButtons1"))), ((bool)(resources.GetObject("gridBorcluTaahhut.EmbeddedNavigator.CustomButtons2"))), ((bool)(resources.GetObject("gridBorcluTaahhut.EmbeddedNavigator.CustomButtons3"))), resources.GetString("gridBorcluTaahhut.EmbeddedNavigator.CustomButtons4"), resources.GetString("gridBorcluTaahhut.EmbeddedNavigator.CustomButtons5"))});
            this.gridBorcluTaahhut.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridBorcluTaahhut_EmbeddedNavigator_ButtonClick);
            this.gridBorcluTaahhut.ExternalRepository = this.MyRepository;
            this.gridBorcluTaahhut.FilterText = null;
            this.gridBorcluTaahhut.FilterValue = null;
            this.gridBorcluTaahhut.GridlerDuzenlenebilir = true;
            this.gridBorcluTaahhut.GridsFilterControl = null;
            gridLevelNode1.LevelTemplate = this.gridView12;
            gridLevelNode1.RelationName = "AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection";
            this.gridBorcluTaahhut.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridBorcluTaahhut.MainView = this.gwBorcluTaahhut;
            this.gridBorcluTaahhut.MyGridStyle = null;
            this.gridBorcluTaahhut.Name = "gridBorcluTaahhut";
            this.gridBorcluTaahhut.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.rlueAlacakliCari,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3,
            this.repositoryItemCheckEdit4});
            this.gridBorcluTaahhut.ShowRowNumbers = false;
            this.gridBorcluTaahhut.SilmeKaldirilsin = false;
            this.gridBorcluTaahhut.TemizleKaldirGorunsunmu = false;
            this.gridBorcluTaahhut.UniqueId = "ce255b2e-7ad2-4c7c-bf5c-7ef31f72b79c";
            this.gridBorcluTaahhut.UseEmbeddedNavigator = true;
            this.gridBorcluTaahhut.UseHyperDragDrop = false;
            this.gridBorcluTaahhut.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwBorcluTaahhut,
            this.gridView12});
            this.gridBorcluTaahhut.DoubleClick += new System.EventHandler(this.gridBorcluTaahhut_DoubleClick);
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueDovizID,
            this.rLueBorcluCariID,
            this.rLueDurumID});
            // 
            // rLueBorcluCariID
            // 
            this.rLueBorcluCariID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueBorcluCariID.Buttons"))))});
            this.rLueBorcluCariID.Name = "rLueBorcluCariID";
            // 
            // gwBorcluTaahhut
            // 
            this.gwBorcluTaahhut.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTAAHHUT_TIP,
            this.colTAAHHUT_EDEN_ID,
            this.colTAAHHUDU_KABUL_EDEN_ID,
            this.colTAAHHUT_TARIHI,
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI,
            this.colTAAHHUDU_KABUL_TARIHI,
            this.colTAAHHUDUN_YERINE_GETIRILME_TARIHI,
            this.colDAVASI_VAR_MI,
            this.IsSelected,
            this.TAAHHUT_SIRA_NO,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gwBorcluTaahhut.GridControl = this.gridBorcluTaahhut;
            resources.ApplyResources(this.gwBorcluTaahhut, "gwBorcluTaahhut");
            this.gwBorcluTaahhut.IndicatorWidth = 20;
            this.gwBorcluTaahhut.Name = "gwBorcluTaahhut";
            this.gwBorcluTaahhut.OptionsBehavior.Editable = false;
            this.gwBorcluTaahhut.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwBorcluTaahhut.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gwBorcluTaahhut.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gwBorcluTaahhut.OptionsNavigation.AutoFocusNewRow = true;
            this.gwBorcluTaahhut.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwBorcluTaahhut.OptionsView.ColumnAutoWidth = false;
            this.gwBorcluTaahhut.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gwBorcluTaahhut.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gwBorcluTaahhut.OptionsView.ShowAutoFilterRow = true;
            this.gwBorcluTaahhut.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwBorcluTaahhut.OptionsView.ShowFooter = true;
            this.gwBorcluTaahhut.PaintStyleName = "Skin";
            // 
            // colTAAHHUT_TIP
            // 
            resources.ApplyResources(this.colTAAHHUT_TIP, "colTAAHHUT_TIP");
            this.colTAAHHUT_TIP.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colTAAHHUT_TIP.FieldName = "TAAHHUT_TIP";
            this.colTAAHHUT_TIP.Name = "colTAAHHUT_TIP";
            this.colTAAHHUT_TIP.OptionsColumn.ReadOnly = true;
            // 
            // repositoryItemCheckEdit2
            // 
            resources.ApplyResources(this.repositoryItemCheckEdit2, "repositoryItemCheckEdit2");
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // colTAAHHUT_EDEN_ID
            // 
            resources.ApplyResources(this.colTAAHHUT_EDEN_ID, "colTAAHHUT_EDEN_ID");
            this.colTAAHHUT_EDEN_ID.ColumnEdit = this.rLueBorcluCariID;
            this.colTAAHHUT_EDEN_ID.FieldName = "TAAHHUT_EDEN_ID";
            this.colTAAHHUT_EDEN_ID.Name = "colTAAHHUT_EDEN_ID";
            this.colTAAHHUT_EDEN_ID.OptionsColumn.ReadOnly = true;
            // 
            // colTAAHHUDU_KABUL_EDEN_ID
            // 
            resources.ApplyResources(this.colTAAHHUDU_KABUL_EDEN_ID, "colTAAHHUDU_KABUL_EDEN_ID");
            this.colTAAHHUDU_KABUL_EDEN_ID.ColumnEdit = this.rlueAlacakliCari;
            this.colTAAHHUDU_KABUL_EDEN_ID.FieldName = "TAAHHUDU_KABUL_EDEN_ID";
            this.colTAAHHUDU_KABUL_EDEN_ID.Name = "colTAAHHUDU_KABUL_EDEN_ID";
            this.colTAAHHUDU_KABUL_EDEN_ID.OptionsColumn.ReadOnly = true;
            // 
            // rlueAlacakliCari
            // 
            resources.ApplyResources(this.rlueAlacakliCari, "rlueAlacakliCari");
            this.rlueAlacakliCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rlueAlacakliCari.Buttons"))))});
            this.rlueAlacakliCari.Name = "rlueAlacakliCari";
            // 
            // colTAAHHUT_TARIHI
            // 
            resources.ApplyResources(this.colTAAHHUT_TARIHI, "colTAAHHUT_TARIHI");
            this.colTAAHHUT_TARIHI.FieldName = "TAAHHUT_TARIHI";
            this.colTAAHHUT_TARIHI.Name = "colTAAHHUT_TARIHI";
            this.colTAAHHUT_TARIHI.OptionsColumn.ReadOnly = true;
            // 
            // colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI
            // 
            resources.ApplyResources(this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI, "colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI");
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.FieldName = "TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI";
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.Name = "colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI";
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.OptionsColumn.ReadOnly = true;
            // 
            // colTAAHHUDU_KABUL_TARIHI
            // 
            resources.ApplyResources(this.colTAAHHUDU_KABUL_TARIHI, "colTAAHHUDU_KABUL_TARIHI");
            this.colTAAHHUDU_KABUL_TARIHI.FieldName = "TAAHHUDU_KABUL_TARIHI";
            this.colTAAHHUDU_KABUL_TARIHI.Name = "colTAAHHUDU_KABUL_TARIHI";
            this.colTAAHHUDU_KABUL_TARIHI.OptionsColumn.ReadOnly = true;
            // 
            // colTAAHHUDUN_YERINE_GETIRILME_TARIHI
            // 
            resources.ApplyResources(this.colTAAHHUDUN_YERINE_GETIRILME_TARIHI, "colTAAHHUDUN_YERINE_GETIRILME_TARIHI");
            this.colTAAHHUDUN_YERINE_GETIRILME_TARIHI.FieldName = "TAAHHUDUN_YERINE_GETIRILME_TARIHI";
            this.colTAAHHUDUN_YERINE_GETIRILME_TARIHI.Name = "colTAAHHUDUN_YERINE_GETIRILME_TARIHI";
            this.colTAAHHUDUN_YERINE_GETIRILME_TARIHI.OptionsColumn.ReadOnly = true;
            // 
            // colDAVASI_VAR_MI
            // 
            resources.ApplyResources(this.colDAVASI_VAR_MI, "colDAVASI_VAR_MI");
            this.colDAVASI_VAR_MI.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colDAVASI_VAR_MI.FieldName = "DAVASI_VAR_MI";
            this.colDAVASI_VAR_MI.Name = "colDAVASI_VAR_MI";
            this.colDAVASI_VAR_MI.OptionsColumn.ReadOnly = true;
            // 
            // repositoryItemCheckEdit1
            // 
            resources.ApplyResources(this.repositoryItemCheckEdit1, "repositoryItemCheckEdit1");
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // IsSelected
            // 
            resources.ApplyResources(this.IsSelected, "IsSelected");
            this.IsSelected.FieldName = "IsSelected";
            this.IsSelected.Name = "IsSelected";
            // 
            // TAAHHUT_SIRA_NO
            // 
            resources.ApplyResources(this.TAAHHUT_SIRA_NO, "TAAHHUT_SIRA_NO");
            this.TAAHHUT_SIRA_NO.FieldName = "TAAHHUT_SIRA_NO";
            this.TAAHHUT_SIRA_NO.Name = "TAAHHUT_SIRA_NO";
            this.TAAHHUT_SIRA_NO.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn1
            // 
            resources.ApplyResources(this.gridColumn1, "gridColumn1");
            this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit3;
            this.gridColumn1.FieldName = "RESMI_MI";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // repositoryItemCheckEdit3
            // 
            resources.ApplyResources(this.repositoryItemCheckEdit3, "repositoryItemCheckEdit3");
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // gridColumn2
            // 
            resources.ApplyResources(this.gridColumn2, "gridColumn2");
            this.gridColumn2.FieldName = "DAVA_FOY_ID";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            resources.ApplyResources(this.gridColumn3, "gridColumn3");
            this.gridColumn3.ColumnEdit = this.repositoryItemCheckEdit4;
            this.gridColumn3.FieldName = "GECERLI_MI";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // repositoryItemCheckEdit4
            // 
            resources.ApplyResources(this.repositoryItemCheckEdit4, "repositoryItemCheckEdit4");
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // compGridDovizSummary1
            // 
            this.compGridDovizSummary1.AltToplamlarAktifMi = true;
            this.compGridDovizSummary1.MyGridView = this.gwBorcluTaahhut;
            this.compGridDovizSummary1.YasakliAlanlar = ((System.Collections.Generic.List<string>)(resources.GetObject("compGridDovizSummary1.YasakliAlanlar")));
            // 
            // compGridDovizSummary2
            // 
            this.compGridDovizSummary2.AltToplamlarAktifMi = true;
            this.compGridDovizSummary2.MyGridView = this.gridView12;
            this.compGridDovizSummary2.YasakliAlanlar = ((System.Collections.Generic.List<string>)(resources.GetObject("compGridDovizSummary2.YasakliAlanlar")));
            // 
            // ucTaahhutler
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridBorcluTaahhut);
            this.Name = "ucTaahhutler";
            this.Load += new System.EventHandler(this.ucTaahhutler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDurumID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBorcluTaahhut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBorcluCariID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwBorcluTaahhut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAlacakliCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridBorcluTaahhut;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView12;
        private DevExpress.XtraGrid.Columns.GridColumn colSIRA_NO1;
        private DevExpress.XtraGrid.Columns.GridColumn colDURUM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUTU_YERINE_GETIRME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUT_MIKTARI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUT_MIKTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUTTEN_KALAN_MIKTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_MIKTARI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_MIKTARI;
        private DevExpress.XtraGrid.Views.Grid.GridView gwBorcluTaahhut;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUT_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUT_EDEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUDU_KABUL_EDEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUDU_KABUL_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUDUN_YERINE_GETIRILME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colDAVASI_VAR_MI;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBorcluCariID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDurumID;
        private DevExpress.XtraGrid.Columns.GridColumn IsSelected;
        private DevExpress.XtraGrid.Columns.GridColumn TAAHHUT_SIRA_NO;
        private AdimAdimDavaKaydi.Util.compGridDovizSummary compGridDovizSummary1;
        private AdimAdimDavaKaydi.Util.compGridDovizSummary compGridDovizSummary2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAlacakliCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;

    }
}
