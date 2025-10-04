namespace  AdimAdimDavaKaydi
{
    partial class ucTemsilAvukat
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridTemsilAvukat = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AVUKAT_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlkCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rCb_TemsilAvukatAd = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.dataNavigatorExtended1 = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            this.extendedGridControl1 = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rlueAvukatCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridTemsilAvukat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_TemsilAvukatAd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extendedGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAvukatCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTemsilAvukat
            // 
            this.gridTemsilAvukat.CustomButtonlarGorunmesin = false;
            this.gridTemsilAvukat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTemsilAvukat.DoNotExtendEmbedNavigator = false;
            this.gridTemsilAvukat.FilterText = null;
            this.gridTemsilAvukat.FilterValue = null;
            this.gridTemsilAvukat.GridlerDuzenlenebilir = true;
            this.gridTemsilAvukat.GridsFilterControl = null;
            this.gridTemsilAvukat.Location = new System.Drawing.Point(0, 0);
            this.gridTemsilAvukat.MainView = this.gridView1;
            this.gridTemsilAvukat.MyGridStyle = null;
            this.gridTemsilAvukat.Name = "gridTemsilAvukat";
            this.gridTemsilAvukat.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rCb_TemsilAvukatAd,
            this.rlkCari});
            this.gridTemsilAvukat.ShowRowNumbers = false;
            this.gridTemsilAvukat.SilmeKaldirilsin = false;
            this.gridTemsilAvukat.Size = new System.Drawing.Size(716, 503);
            this.gridTemsilAvukat.TabIndex = 1;
            this.gridTemsilAvukat.TemizleKaldirGorunsunmu = false;
            this.gridTemsilAvukat.UniqueId = "5ab3228d-25e5-4ad8-8466-eb2763a1abdc";
            this.gridTemsilAvukat.UseEmbeddedNavigator = true;
            this.gridTemsilAvukat.UseHyperDragDrop = false;
            this.gridTemsilAvukat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AVUKAT_CARI_ID});
            this.gridView1.GridControl = this.gridTemsilAvukat;
            this.gridView1.GroupPanelText = "Verileri Gruplamak Ýçin Baþlýklarý Buraya Sürükleyin";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Temsil Yetkisi Alan Ekle";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // AVUKAT_CARI_ID
            // 
            this.AVUKAT_CARI_ID.Caption = "Temsil Yetkisi Alan";
            this.AVUKAT_CARI_ID.ColumnEdit = this.rlkCari;
            this.AVUKAT_CARI_ID.FieldName = "AVUKAT_CARI_ID";
            this.AVUKAT_CARI_ID.Name = "AVUKAT_CARI_ID";
            this.AVUKAT_CARI_ID.Visible = true;
            this.AVUKAT_CARI_ID.VisibleIndex = 0;
            this.AVUKAT_CARI_ID.Width = 811;
            // 
            // rlkCari
            // 
            this.rlkCari.AutoHeight = false;
            this.rlkCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkCari.Name = "rlkCari";
            // 
            // rCb_TemsilAvukatAd
            // 
            this.rCb_TemsilAvukatAd.AutoHeight = false;
            this.rCb_TemsilAvukatAd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_TemsilAvukatAd.Name = "rCb_TemsilAvukatAd";
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(0, 461);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = this.gridTemsilAvukat;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = null;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(771, 24);
            this.dataNavigatorExtended1.TabIndex = 2;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            // 
            // extendedGridControl1
            // 
            this.extendedGridControl1.CustomButtonlarGorunmesin = false;
            this.extendedGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extendedGridControl1.DoNotExtendEmbedNavigator = false;
            this.extendedGridControl1.ExternalRepository = this.MyRepository;
            this.extendedGridControl1.FilterText = null;
            this.extendedGridControl1.FilterValue = null;
            this.extendedGridControl1.GridlerDuzenlenebilir = true;
            this.extendedGridControl1.GridsFilterControl = null;
            this.extendedGridControl1.Location = new System.Drawing.Point(0, 0);
            this.extendedGridControl1.MainView = this.gridView2;
            this.extendedGridControl1.MyGridStyle = null;
            this.extendedGridControl1.Name = "extendedGridControl1";
            this.extendedGridControl1.ShowRowNumbers = false;
            this.extendedGridControl1.SilmeKaldirilsin = false;
            this.extendedGridControl1.Size = new System.Drawing.Size(716, 503);
            this.extendedGridControl1.TabIndex = 2;
            this.extendedGridControl1.TemizleKaldirGorunsunmu = false;
            this.extendedGridControl1.UniqueId = "60ac32bb-9a96-4c9a-8d7e-00d2e823410b";
            this.extendedGridControl1.UseEmbeddedNavigator = true;
            this.extendedGridControl1.UseHyperDragDrop = false;
            this.extendedGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueAvukatCari});
            // 
            // rlueAvukatCari
            // 
            this.rlueAvukatCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Yeni Avukat Ekle", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "AvukatEkle", null, true)});
            this.rlueAvukatCari.Name = "rlueAvukatCari";
            this.rlueAvukatCari.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rlueAvukatCari.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rlueAvukatCari_ButtonClick);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridView2.GridControl = this.extendedGridControl1;
            this.gridView2.IndicatorWidth = 20;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Temsil Yetkisi Alan";
            this.gridColumn1.ColumnEdit = this.rlueAvukatCari;
            this.gridColumn1.FieldName = "AVUKAT_CARI_ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 811;
            // 
            // ucTemsilAvukat
            // 
            this.Controls.Add(this.extendedGridControl1);
            this.Controls.Add(this.gridTemsilAvukat);
            this.Name = "ucTemsilAvukat";
            this.Size = new System.Drawing.Size(716, 503);
            ((System.ComponentModel.ISupportInitialize)(this.gridTemsilAvukat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_TemsilAvukatAd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extendedGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAvukatCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTemsilAvukat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn AVUKAT_CARI_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_TemsilAvukatAd;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkCari;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dataNavigatorExtended1;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl extendedGridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAvukatCari;
    }
}
