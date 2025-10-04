namespace  AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    partial class ucFeragat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFeragat));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridFeragat = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueFeragatAlacakNedenID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueFeragatAlacakKalemID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueDovizID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueFeragatTipID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueFeragatKapsamID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gwFeragat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFERAGAT_KAPSAM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFERAGAT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFERAGAT_MIKTAR_DOVIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFERAGAT_MIKTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rudTutar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colHARC_ICIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueMahsupAltKategori = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueMahsupKategori = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueTarafCARI = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueIlam = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gwOdemeDagilim = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_KARSILIK_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAHSUP_ALT_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAHSUP_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALACAK_NEDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALACAK_NEDEN_TARAF_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFOY_TARAF_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAGILIM_TIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.compGridDovizSummary1 = new AdimAdimDavaKaydi.Util.compGridDovizSummary(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFeragat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFeragatAlacakNedenID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFeragatAlacakKalemID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFeragatTipID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFeragatKapsamID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwFeragat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudTutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMahsupAltKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMahsupKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafCARI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIlam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwOdemeDagilim)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridFeragat;
            this.gridView1.Name = "gridView1";
            // 
            // gridFeragat
            // 
            this.gridFeragat.CustomButtonlarGorunmesin = false;
            resources.ApplyResources(this.gridFeragat, "gridFeragat");
            this.gridFeragat.DoNotExtendEmbedNavigator = false;
            this.gridFeragat.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridFeragat.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridFeragat.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridFeragat.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(((int)(resources.GetObject("gridFeragat.EmbeddedNavigator.CustomButtons"))), ((int)(resources.GetObject("gridFeragat.EmbeddedNavigator.CustomButtons1"))), ((bool)(resources.GetObject("gridFeragat.EmbeddedNavigator.CustomButtons2"))), ((bool)(resources.GetObject("gridFeragat.EmbeddedNavigator.CustomButtons3"))), resources.GetString("gridFeragat.EmbeddedNavigator.CustomButtons4"), resources.GetString("gridFeragat.EmbeddedNavigator.CustomButtons5")),
            new DevExpress.XtraEditors.NavigatorCustomButton(((int)(resources.GetObject("gridFeragat.EmbeddedNavigator.CustomButtons6"))), ((int)(resources.GetObject("gridFeragat.EmbeddedNavigator.CustomButtons7"))), ((bool)(resources.GetObject("gridFeragat.EmbeddedNavigator.CustomButtons8"))), ((bool)(resources.GetObject("gridFeragat.EmbeddedNavigator.CustomButtons9"))), resources.GetString("gridFeragat.EmbeddedNavigator.CustomButtons10"), resources.GetString("gridFeragat.EmbeddedNavigator.CustomButtons11"))});
            this.gridFeragat.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridFeragat_EmbeddedNavigator_ButtonClick);
            this.gridFeragat.ExternalRepository = this.MyRepository;
            this.gridFeragat.FilterText = null;
            this.gridFeragat.FilterValue = null;
            this.gridFeragat.GridlerDuzenlenebilir = true;
            this.gridFeragat.GridsFilterControl = null;
            gridLevelNode1.LevelTemplate = this.gridView1;
            gridLevelNode1.RelationName = "AV001_TI_BIL_ODEME_DAGILIMCollection";
            this.gridFeragat.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridFeragat.MainView = this.gwFeragat;
            this.gridFeragat.MyGridStyle = null;
            this.gridFeragat.Name = "gridFeragat";
            this.gridFeragat.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rudTutar,
            this.rLueMahsupAltKategori,
            this.rLueMahsupKategori,
            this.rLueTarafCARI,
            this.rLueIlam});
            this.gridFeragat.ShowRowNumbers = false;
            this.gridFeragat.SilmeKaldirilsin = false;
            this.gridFeragat.TemizleKaldirGorunsunmu = false;
            this.gridFeragat.UniqueId = "b3f3d084-4f7f-4c0f-8794-a7554a202383";
            this.gridFeragat.UseEmbeddedNavigator = true;
            this.gridFeragat.UseHyperDragDrop = false;
            this.gridFeragat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwFeragat,
            this.gwOdemeDagilim,
            this.gridView1});
            this.gridFeragat.ButtonEditorClick += new System.EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(this.gridFeragat_ButtonEditorClick);
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueFeragatAlacakNedenID,
            this.rLueFeragatAlacakKalemID,
            this.rLueDovizID,
            this.rLueFeragatTipID,
            this.rLueFeragatKapsamID});
            // 
            // rLueFeragatAlacakNedenID
            // 
            resources.ApplyResources(this.rLueFeragatAlacakNedenID, "rLueFeragatAlacakNedenID");
            this.rLueFeragatAlacakNedenID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueFeragatAlacakNedenID.Buttons"))))});
            this.rLueFeragatAlacakNedenID.Name = "rLueFeragatAlacakNedenID";
            // 
            // rLueFeragatAlacakKalemID
            // 
            resources.ApplyResources(this.rLueFeragatAlacakKalemID, "rLueFeragatAlacakKalemID");
            this.rLueFeragatAlacakKalemID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueFeragatAlacakKalemID.Buttons"))))});
            this.rLueFeragatAlacakKalemID.Name = "rLueFeragatAlacakKalemID";
            // 
            // rLueDovizID
            // 
            resources.ApplyResources(this.rLueDovizID, "rLueDovizID");
            this.rLueDovizID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueDovizID.Buttons"))))});
            this.rLueDovizID.Name = "rLueDovizID";
            // 
            // rLueFeragatTipID
            // 
            resources.ApplyResources(this.rLueFeragatTipID, "rLueFeragatTipID");
            this.rLueFeragatTipID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueFeragatTipID.Buttons"))))});
            this.rLueFeragatTipID.Name = "rLueFeragatTipID";
            // 
            // rLueFeragatKapsamID
            // 
            resources.ApplyResources(this.rLueFeragatKapsamID, "rLueFeragatKapsamID");
            this.rLueFeragatKapsamID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueFeragatKapsamID.Buttons"))))});
            this.rLueFeragatKapsamID.Name = "rLueFeragatKapsamID";
            // 
            // gwFeragat
            // 
            this.gwFeragat.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFERAGAT_KAPSAM,
            this.colFERAGAT_TARIHI,
            this.colFERAGAT_MIKTAR_DOVIZ,
            this.colFERAGAT_MIKTAR,
            this.colHARC_ICIN});
            this.gwFeragat.GridControl = this.gridFeragat;
            resources.ApplyResources(this.gwFeragat, "gwFeragat");
            this.gwFeragat.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary"))), resources.GetString("gwFeragat.GroupSummary1"), this.colFERAGAT_MIKTAR, resources.GetString("gwFeragat.GroupSummary2")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary3"))), resources.GetString("gwFeragat.GroupSummary4"), this.colFERAGAT_MIKTAR, resources.GetString("gwFeragat.GroupSummary5")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary6"))), resources.GetString("gwFeragat.GroupSummary7"), this.colFERAGAT_MIKTAR_DOVIZ, resources.GetString("gwFeragat.GroupSummary8")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary9"))), resources.GetString("gwFeragat.GroupSummary10"), this.colFERAGAT_MIKTAR, resources.GetString("gwFeragat.GroupSummary11")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary12"))), resources.GetString("gwFeragat.GroupSummary13"), this.colFERAGAT_MIKTAR_DOVIZ, resources.GetString("gwFeragat.GroupSummary14")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary15"))), resources.GetString("gwFeragat.GroupSummary16"), this.colFERAGAT_MIKTAR, resources.GetString("gwFeragat.GroupSummary17")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary18"))), resources.GetString("gwFeragat.GroupSummary19"), this.colFERAGAT_MIKTAR_DOVIZ, resources.GetString("gwFeragat.GroupSummary20")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary21"))), resources.GetString("gwFeragat.GroupSummary22"), this.colFERAGAT_MIKTAR, resources.GetString("gwFeragat.GroupSummary23")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary24"))), resources.GetString("gwFeragat.GroupSummary25"), this.colFERAGAT_MIKTAR_DOVIZ, resources.GetString("gwFeragat.GroupSummary26")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary27"))), resources.GetString("gwFeragat.GroupSummary28"), this.colFERAGAT_MIKTAR, resources.GetString("gwFeragat.GroupSummary29")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary30"))), resources.GetString("gwFeragat.GroupSummary31"), this.colFERAGAT_MIKTAR_DOVIZ, resources.GetString("gwFeragat.GroupSummary32")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary33"))), resources.GetString("gwFeragat.GroupSummary34"), this.colFERAGAT_MIKTAR, resources.GetString("gwFeragat.GroupSummary35")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary36"))), resources.GetString("gwFeragat.GroupSummary37"), this.colFERAGAT_MIKTAR_DOVIZ, resources.GetString("gwFeragat.GroupSummary38")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary39"))), resources.GetString("gwFeragat.GroupSummary40"), this.colFERAGAT_MIKTAR, resources.GetString("gwFeragat.GroupSummary41")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary42"))), resources.GetString("gwFeragat.GroupSummary43"), this.colFERAGAT_MIKTAR_DOVIZ, resources.GetString("gwFeragat.GroupSummary44")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary45"))), resources.GetString("gwFeragat.GroupSummary46"), this.colFERAGAT_MIKTAR, resources.GetString("gwFeragat.GroupSummary47")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary48"))), resources.GetString("gwFeragat.GroupSummary49"), this.colFERAGAT_MIKTAR_DOVIZ, resources.GetString("gwFeragat.GroupSummary50")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary51"))), resources.GetString("gwFeragat.GroupSummary52"), this.colFERAGAT_MIKTAR, resources.GetString("gwFeragat.GroupSummary53")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary54"))), resources.GetString("gwFeragat.GroupSummary55"), this.colFERAGAT_MIKTAR_DOVIZ, resources.GetString("gwFeragat.GroupSummary56")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary57"))), resources.GetString("gwFeragat.GroupSummary58"), this.colFERAGAT_MIKTAR, resources.GetString("gwFeragat.GroupSummary59")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary60"))), resources.GetString("gwFeragat.GroupSummary61"), this.colFERAGAT_MIKTAR_DOVIZ, resources.GetString("gwFeragat.GroupSummary62")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary63"))), resources.GetString("gwFeragat.GroupSummary64"), this.colFERAGAT_MIKTAR, resources.GetString("gwFeragat.GroupSummary65")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary66"))), resources.GetString("gwFeragat.GroupSummary67"), this.colFERAGAT_MIKTAR_DOVIZ, resources.GetString("gwFeragat.GroupSummary68")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary69"))), resources.GetString("gwFeragat.GroupSummary70"), this.colFERAGAT_MIKTAR, resources.GetString("gwFeragat.GroupSummary71")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwFeragat.GroupSummary72"))), resources.GetString("gwFeragat.GroupSummary73"), this.colFERAGAT_MIKTAR_DOVIZ, resources.GetString("gwFeragat.GroupSummary74"))});
            this.gwFeragat.IndicatorWidth = 20;
            this.gwFeragat.Name = "gwFeragat";
            this.gwFeragat.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwFeragat.OptionsDetail.ShowDetailTabs = false;
            this.gwFeragat.OptionsNavigation.AutoFocusNewRow = true;
            this.gwFeragat.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwFeragat.OptionsView.ColumnAutoWidth = false;
            this.gwFeragat.OptionsView.ShowAutoFilterRow = true;
            this.gwFeragat.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwFeragat.OptionsView.ShowDetailButtons = false;
            this.gwFeragat.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gwFeragat.OptionsView.ShowFooter = true;
            this.gwFeragat.OptionsView.ShowGroupPanel = false;
            this.gwFeragat.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gwFeragat_ValidateRow);
            // 
            // colFERAGAT_KAPSAM
            // 
            resources.ApplyResources(this.colFERAGAT_KAPSAM, "colFERAGAT_KAPSAM");
            this.colFERAGAT_KAPSAM.ColumnEdit = this.rLueFeragatKapsamID;
            this.colFERAGAT_KAPSAM.FieldName = "FERAGAT_KAPSAM";
            this.colFERAGAT_KAPSAM.Name = "colFERAGAT_KAPSAM";
            this.colFERAGAT_KAPSAM.OptionsColumn.ReadOnly = true;
            // 
            // colFERAGAT_TARIHI
            // 
            resources.ApplyResources(this.colFERAGAT_TARIHI, "colFERAGAT_TARIHI");
            this.colFERAGAT_TARIHI.FieldName = "FERAGAT_TARIHI";
            this.colFERAGAT_TARIHI.Name = "colFERAGAT_TARIHI";
            this.colFERAGAT_TARIHI.OptionsColumn.ReadOnly = true;
            // 
            // colFERAGAT_MIKTAR_DOVIZ
            // 
            resources.ApplyResources(this.colFERAGAT_MIKTAR_DOVIZ, "colFERAGAT_MIKTAR_DOVIZ");
            this.colFERAGAT_MIKTAR_DOVIZ.ColumnEdit = this.rLueDovizID;
            this.colFERAGAT_MIKTAR_DOVIZ.FieldName = "FERAGAT_MIKTAR_DOVIZ_ID";
            this.colFERAGAT_MIKTAR_DOVIZ.Name = "colFERAGAT_MIKTAR_DOVIZ";
            this.colFERAGAT_MIKTAR_DOVIZ.OptionsColumn.ReadOnly = true;
            this.colFERAGAT_MIKTAR_DOVIZ.SummaryItem.DisplayFormat = resources.GetString("colFERAGAT_MIKTAR_DOVIZ.SummaryItem.DisplayFormat");
            this.colFERAGAT_MIKTAR_DOVIZ.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            // 
            // colFERAGAT_MIKTAR
            // 
            resources.ApplyResources(this.colFERAGAT_MIKTAR, "colFERAGAT_MIKTAR");
            this.colFERAGAT_MIKTAR.ColumnEdit = this.rudTutar;
            this.colFERAGAT_MIKTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colFERAGAT_MIKTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFERAGAT_MIKTAR.FieldName = "FERAGAT_MIKTAR";
            this.colFERAGAT_MIKTAR.Name = "colFERAGAT_MIKTAR";
            this.colFERAGAT_MIKTAR.OptionsColumn.ReadOnly = true;
            this.colFERAGAT_MIKTAR.SummaryItem.DisplayFormat = resources.GetString("colFERAGAT_MIKTAR.SummaryItem.DisplayFormat");
            this.colFERAGAT_MIKTAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            // 
            // rudTutar
            // 
            this.rudTutar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rudTutar.Name = "rudTutar";
            // 
            // colHARC_ICIN
            // 
            resources.ApplyResources(this.colHARC_ICIN, "colHARC_ICIN");
            this.colHARC_ICIN.FieldName = "HARC_ICIN";
            this.colHARC_ICIN.Name = "colHARC_ICIN";
            this.colHARC_ICIN.OptionsColumn.ReadOnly = true;
            // 
            // rLueMahsupAltKategori
            // 
            resources.ApplyResources(this.rLueMahsupAltKategori, "rLueMahsupAltKategori");
            this.rLueMahsupAltKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueMahsupAltKategori.Buttons"))))});
            this.rLueMahsupAltKategori.Name = "rLueMahsupAltKategori";
            // 
            // rLueMahsupKategori
            // 
            resources.ApplyResources(this.rLueMahsupKategori, "rLueMahsupKategori");
            this.rLueMahsupKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueMahsupKategori.Buttons"))))});
            this.rLueMahsupKategori.Name = "rLueMahsupKategori";
            // 
            // rLueTarafCARI
            // 
            resources.ApplyResources(this.rLueTarafCARI, "rLueTarafCARI");
            this.rLueTarafCARI.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueTarafCARI.Buttons"))))});
            this.rLueTarafCARI.Name = "rLueTarafCARI";
            // 
            // rLueIlam
            // 
            resources.ApplyResources(this.rLueIlam, "rLueIlam");
            this.rLueIlam.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueIlam.Buttons"))))});
            this.rLueIlam.Name = "rLueIlam";
            // 
            // gwOdemeDagilim
            // 
            this.gwOdemeDagilim.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTUTAR,
            this.colTUTAR_DOVIZ_ID,
            this.colODEME_KARSILIK_TUTAR,
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID,
            this.colODEME_TARIHI,
            this.colMAHSUP_ALT_KATEGORI_ID,
            this.colMAHSUP_KATEGORI_ID,
            this.colALACAK_NEDEN_ID,
            this.colALACAK_NEDEN_TARAF_ID,
            this.colFOY_TARAF_ID,
            this.colDAGILIM_TIPI});
            this.gwOdemeDagilim.GridControl = this.gridFeragat;
            this.gwOdemeDagilim.Name = "gwOdemeDagilim";
            this.gwOdemeDagilim.OptionsBehavior.Editable = false;
            this.gwOdemeDagilim.OptionsNavigation.AutoFocusNewRow = true;
            this.gwOdemeDagilim.OptionsNavigation.EnterMoveNextColumn = true;
            resources.ApplyResources(this.gwOdemeDagilim, "gwOdemeDagilim");
            // 
            // colTUTAR
            // 
            resources.ApplyResources(this.colTUTAR, "colTUTAR");
            this.colTUTAR.ColumnEdit = this.rudTutar;
            this.colTUTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colTUTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTUTAR.FieldName = "TUTAR";
            this.colTUTAR.Name = "colTUTAR";
            // 
            // colTUTAR_DOVIZ_ID
            // 
            resources.ApplyResources(this.colTUTAR_DOVIZ_ID, "colTUTAR_DOVIZ_ID");
            this.colTUTAR_DOVIZ_ID.ColumnEdit = this.rLueDovizID;
            this.colTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            this.colTUTAR_DOVIZ_ID.Name = "colTUTAR_DOVIZ_ID";
            // 
            // colODEME_KARSILIK_TUTAR
            // 
            resources.ApplyResources(this.colODEME_KARSILIK_TUTAR, "colODEME_KARSILIK_TUTAR");
            this.colODEME_KARSILIK_TUTAR.ColumnEdit = this.rudTutar;
            this.colODEME_KARSILIK_TUTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colODEME_KARSILIK_TUTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colODEME_KARSILIK_TUTAR.FieldName = "ODEME_KARSILIK_TUTAR";
            this.colODEME_KARSILIK_TUTAR.Name = "colODEME_KARSILIK_TUTAR";
            // 
            // colODEME_KARSILIK_TUTAR_DOVIZ_ID
            // 
            resources.ApplyResources(this.colODEME_KARSILIK_TUTAR_DOVIZ_ID, "colODEME_KARSILIK_TUTAR_DOVIZ_ID");
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID.ColumnEdit = this.rLueDovizID;
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID.FieldName = "ODEME_KARSILIK_TUTAR_DOVIZ_ID";
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID.Name = "colODEME_KARSILIK_TUTAR_DOVIZ_ID";
            // 
            // colODEME_TARIHI
            // 
            resources.ApplyResources(this.colODEME_TARIHI, "colODEME_TARIHI");
            this.colODEME_TARIHI.FieldName = "ODEME_TARIHI";
            this.colODEME_TARIHI.Name = "colODEME_TARIHI";
            // 
            // colMAHSUP_ALT_KATEGORI_ID
            // 
            resources.ApplyResources(this.colMAHSUP_ALT_KATEGORI_ID, "colMAHSUP_ALT_KATEGORI_ID");
            this.colMAHSUP_ALT_KATEGORI_ID.ColumnEdit = this.rLueMahsupAltKategori;
            this.colMAHSUP_ALT_KATEGORI_ID.FieldName = "MAHSUP_ALT_KATEGORI_ID";
            this.colMAHSUP_ALT_KATEGORI_ID.Name = "colMAHSUP_ALT_KATEGORI_ID";
            // 
            // colMAHSUP_KATEGORI_ID
            // 
            resources.ApplyResources(this.colMAHSUP_KATEGORI_ID, "colMAHSUP_KATEGORI_ID");
            this.colMAHSUP_KATEGORI_ID.ColumnEdit = this.rLueMahsupKategori;
            this.colMAHSUP_KATEGORI_ID.FieldName = "MAHSUP_KATEGORI_ID";
            this.colMAHSUP_KATEGORI_ID.Name = "colMAHSUP_KATEGORI_ID";
            // 
            // colALACAK_NEDEN_ID
            // 
            resources.ApplyResources(this.colALACAK_NEDEN_ID, "colALACAK_NEDEN_ID");
            this.colALACAK_NEDEN_ID.ColumnEdit = this.rLueFeragatAlacakNedenID;
            this.colALACAK_NEDEN_ID.FieldName = "ALACAK_NEDEN_ID";
            this.colALACAK_NEDEN_ID.Name = "colALACAK_NEDEN_ID";
            // 
            // colALACAK_NEDEN_TARAF_ID
            // 
            resources.ApplyResources(this.colALACAK_NEDEN_TARAF_ID, "colALACAK_NEDEN_TARAF_ID");
            this.colALACAK_NEDEN_TARAF_ID.ColumnEdit = this.rLueTarafCARI;
            this.colALACAK_NEDEN_TARAF_ID.FieldName = "ALACAK_NEDEN_TARAF_ID";
            this.colALACAK_NEDEN_TARAF_ID.Name = "colALACAK_NEDEN_TARAF_ID";
            // 
            // colFOY_TARAF_ID
            // 
            resources.ApplyResources(this.colFOY_TARAF_ID, "colFOY_TARAF_ID");
            this.colFOY_TARAF_ID.ColumnEdit = this.rLueTarafCARI;
            this.colFOY_TARAF_ID.FieldName = "FOY_TARAF_ID";
            this.colFOY_TARAF_ID.Name = "colFOY_TARAF_ID";
            // 
            // colDAGILIM_TIPI
            // 
            resources.ApplyResources(this.colDAGILIM_TIPI, "colDAGILIM_TIPI");
            this.colDAGILIM_TIPI.FieldName = "DAGILIM_TIPI";
            this.colDAGILIM_TIPI.Name = "colDAGILIM_TIPI";
            // 
            // compGridDovizSummary1
            // 
            this.compGridDovizSummary1.AltToplamlarAktifMi = true;
            this.compGridDovizSummary1.MyGridView = this.gwFeragat;
            this.compGridDovizSummary1.YasakliAlanlar = ((System.Collections.Generic.List<string>)(resources.GetObject("compGridDovizSummary1.YasakliAlanlar")));
            // 
            // ucFeragat
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridFeragat);
            this.Name = "ucFeragat";
            this.Load += new System.EventHandler(this.ucFeragat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFeragat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFeragatAlacakNedenID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFeragatAlacakKalemID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFeragatTipID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFeragatKapsamID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwFeragat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudTutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMahsupAltKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMahsupKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafCARI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIlam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwOdemeDagilim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridFeragat;
        private DevExpress.XtraGrid.Views.Grid.GridView gwFeragat;
        private DevExpress.XtraGrid.Columns.GridColumn colFERAGAT_KAPSAM;
        private DevExpress.XtraGrid.Columns.GridColumn colFERAGAT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colFERAGAT_MIKTAR_DOVIZ;
        private DevExpress.XtraGrid.Columns.GridColumn colFERAGAT_MIKTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colHARC_ICIN;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueFeragatAlacakNedenID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueFeragatAlacakKalemID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueFeragatTipID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueFeragatKapsamID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rudTutar;
        private DevExpress.XtraGrid.Views.Grid.GridView gwOdemeDagilim;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_KARSILIK_TUTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_KARSILIK_TUTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colMAHSUP_ALT_KATEGORI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colMAHSUP_KATEGORI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colALACAK_NEDEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colALACAK_NEDEN_TARAF_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colFOY_TARAF_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDAGILIM_TIPI;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMahsupAltKategori;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMahsupKategori;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTarafCARI;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueIlam;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private AdimAdimDavaKaydi.Util.compGridDovizSummary compGridDovizSummary1;
    }
}
