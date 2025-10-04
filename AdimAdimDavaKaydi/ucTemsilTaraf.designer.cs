namespace  AdimAdimDavaKaydi
{
    partial class ucTemsilTaraf
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
            this.gridTemsilTaraf = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rlueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueTemsilTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueVsesTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CARI_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEMSIL_YETKISI_VAR_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEMSIL_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEMSILE_YETKILI_CARI1_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEMSILE_YETKILI_CARI2_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEMSILE_YETKILI_CARI3_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEMSIL_SONA_ERME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VSES_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dataNavigatorExtended1 = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            this.vgTemsilTaraf = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowCARI_ADI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEMSIL_YETKISI_VAR_MI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEMSIL_TIP = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEMSILE_YETKILI_CARI1_ADI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEMSILE_YETKILI_CARI2_ADI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEMSILE_YETKILI_CARI3_ADI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEMSIL_SONA_ERME_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowVSES_TIP = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.gridTemsilTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTemsilTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueVsesTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgTemsilTaraf)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTemsilTaraf
            // 
            this.gridTemsilTaraf.CustomButtonlarGorunmesin = false;
            this.gridTemsilTaraf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTemsilTaraf.DoNotExtendEmbedNavigator = false;
            this.gridTemsilTaraf.ExternalRepository = this.MyRepository;
            this.gridTemsilTaraf.FilterText = null;
            this.gridTemsilTaraf.FilterValue = null;
            this.gridTemsilTaraf.GridlerDuzenlenebilir = true;
            this.gridTemsilTaraf.GridsFilterControl = null;
            this.gridTemsilTaraf.Location = new System.Drawing.Point(0, 0);
            this.gridTemsilTaraf.MainView = this.gridView1;
            this.gridTemsilTaraf.MyGridStyle = null;
            this.gridTemsilTaraf.Name = "gridTemsilTaraf";
            this.gridTemsilTaraf.ShowRowNumbers = false;
            this.gridTemsilTaraf.SilmeKaldirilsin = false;
            this.gridTemsilTaraf.Size = new System.Drawing.Size(349, 221);
            this.gridTemsilTaraf.TabIndex = 1;
            this.gridTemsilTaraf.TemizleKaldirGorunsunmu = false;
            this.gridTemsilTaraf.UniqueId = "3f9afdfa-48db-4053-b83b-304dce756411";
            this.gridTemsilTaraf.UseHyperDragDrop = false;
            this.gridTemsilTaraf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridTemsilTaraf.Visible = false;
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueCari,
            this.rlueTemsilTip,
            this.rlueVsesTip,
            this.tarih});
            // 
            // rlueCari
            // 
            this.rlueCari.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rlueCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Yeni Þahýs", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "Yeni", null, true)});
            this.rlueCari.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.rlueCari.Name = "rlueCari";
            this.rlueCari.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rlueCari.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rlueCari_ButtonClick);
            // 
            // rlueTemsilTip
            // 
            this.rlueTemsilTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueTemsilTip.Name = "rlueTemsilTip";
            // 
            // rlueVsesTip
            // 
            this.rlueVsesTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueVsesTip.Name = "rlueVsesTip";
            // 
            // tarih
            // 
            this.tarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tarih.Name = "tarih";
            this.tarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CARI_ADI,
            this.TEMSIL_YETKISI_VAR_MI,
            this.TEMSIL_TIP,
            this.TEMSILE_YETKILI_CARI1_ADI,
            this.TEMSILE_YETKILI_CARI2_ADI,
            this.TEMSILE_YETKILI_CARI3_ADI,
            this.TEMSIL_SONA_ERME_TARIHI,
            this.VSES_TIP});
            this.gridView1.GridControl = this.gridTemsilTaraf;
            this.gridView1.GroupPanelText = "Verileri gruplamak Ýçin Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Temsil Yetkisi Veren Ekle";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // CARI_ADI
            // 
            this.CARI_ADI.Caption = "Temsil Yetkisi Veren";
            this.CARI_ADI.ColumnEdit = this.rlueCari;
            this.CARI_ADI.FieldName = "TARAF_CARI_ID";
            this.CARI_ADI.Name = "CARI_ADI";
            this.CARI_ADI.Visible = true;
            this.CARI_ADI.VisibleIndex = 0;
            this.CARI_ADI.Width = 246;
            // 
            // TEMSIL_YETKISI_VAR_MI
            // 
            this.TEMSIL_YETKISI_VAR_MI.Caption = "Yetkisi Var mý?";
            this.TEMSIL_YETKISI_VAR_MI.FieldName = "TEMSIL_YETKISI_VAR_MI";
            this.TEMSIL_YETKISI_VAR_MI.Name = "TEMSIL_YETKISI_VAR_MI";
            this.TEMSIL_YETKISI_VAR_MI.Visible = true;
            this.TEMSIL_YETKISI_VAR_MI.VisibleIndex = 1;
            this.TEMSIL_YETKISI_VAR_MI.Width = 90;
            // 
            // TEMSIL_TIP
            // 
            this.TEMSIL_TIP.Caption = "Temsil Tipi";
            this.TEMSIL_TIP.ColumnEdit = this.rlueTemsilTip;
            this.TEMSIL_TIP.FieldName = "TEMSIL_TIP_ID";
            this.TEMSIL_TIP.Name = "TEMSIL_TIP";
            this.TEMSIL_TIP.Visible = true;
            this.TEMSIL_TIP.VisibleIndex = 2;
            this.TEMSIL_TIP.Width = 79;
            // 
            // TEMSILE_YETKILI_CARI1_ADI
            // 
            this.TEMSILE_YETKILI_CARI1_ADI.Caption = "Yetkili Cari Adý";
            this.TEMSILE_YETKILI_CARI1_ADI.ColumnEdit = this.rlueCari;
            this.TEMSILE_YETKILI_CARI1_ADI.FieldName = "TEMSILE_YETKILI_CARI1_ID";
            this.TEMSILE_YETKILI_CARI1_ADI.Name = "TEMSILE_YETKILI_CARI1_ADI";
            this.TEMSILE_YETKILI_CARI1_ADI.Visible = true;
            this.TEMSILE_YETKILI_CARI1_ADI.VisibleIndex = 3;
            this.TEMSILE_YETKILI_CARI1_ADI.Width = 106;
            // 
            // TEMSILE_YETKILI_CARI2_ADI
            // 
            this.TEMSILE_YETKILI_CARI2_ADI.Caption = "Yetkili Cari 2 ";
            this.TEMSILE_YETKILI_CARI2_ADI.ColumnEdit = this.rlueCari;
            this.TEMSILE_YETKILI_CARI2_ADI.FieldName = "TEMSILE_YETKILI_CARI2_ID";
            this.TEMSILE_YETKILI_CARI2_ADI.Name = "TEMSILE_YETKILI_CARI2_ADI";
            this.TEMSILE_YETKILI_CARI2_ADI.Visible = true;
            this.TEMSILE_YETKILI_CARI2_ADI.VisibleIndex = 4;
            this.TEMSILE_YETKILI_CARI2_ADI.Width = 101;
            // 
            // TEMSILE_YETKILI_CARI3_ADI
            // 
            this.TEMSILE_YETKILI_CARI3_ADI.Caption = "Yetkili Cari 3";
            this.TEMSILE_YETKILI_CARI3_ADI.ColumnEdit = this.rlueCari;
            this.TEMSILE_YETKILI_CARI3_ADI.FieldName = "TEMSILE_YETKILI_CARI3_ID";
            this.TEMSILE_YETKILI_CARI3_ADI.Name = "TEMSILE_YETKILI_CARI3_ADI";
            this.TEMSILE_YETKILI_CARI3_ADI.Visible = true;
            this.TEMSILE_YETKILI_CARI3_ADI.VisibleIndex = 5;
            this.TEMSILE_YETKILI_CARI3_ADI.Width = 79;
            // 
            // TEMSIL_SONA_ERME_TARIHI
            // 
            this.TEMSIL_SONA_ERME_TARIHI.Caption = "Sona Erme Tarihi";
            this.TEMSIL_SONA_ERME_TARIHI.ColumnEdit = this.tarih;
            this.TEMSIL_SONA_ERME_TARIHI.FieldName = "TEMSIL_SONA_ERME_TARIHI";
            this.TEMSIL_SONA_ERME_TARIHI.Name = "TEMSIL_SONA_ERME_TARIHI";
            this.TEMSIL_SONA_ERME_TARIHI.Visible = true;
            this.TEMSIL_SONA_ERME_TARIHI.VisibleIndex = 6;
            this.TEMSIL_SONA_ERME_TARIHI.Width = 117;
            // 
            // VSES_TIP
            // 
            this.VSES_TIP.Caption = "VSES Tipi";
            this.VSES_TIP.ColumnEdit = this.rlueVsesTip;
            this.VSES_TIP.FieldName = "VSES_ID";
            this.VSES_TIP.Name = "VSES_TIP";
            this.VSES_TIP.Visible = true;
            this.VSES_TIP.VisibleIndex = 7;
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(0, 197);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = this.gridTemsilTaraf;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = null;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(349, 24);
            this.dataNavigatorExtended1.TabIndex = 2;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.OnListedenGetirClick += new AdimAdimDavaKaydi.Util.ListedenGetirEventHandler(this.dataNavigatorExtended1_OnListedenGetirClick);
            this.dataNavigatorExtended1.OnCevirClick += new System.EventHandler(this.dataNavigatorExtended1_OnCevirClick);
            // 
            // vgTemsilTaraf
            // 
            this.vgTemsilTaraf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgTemsilTaraf.ExternalRepository = this.MyRepository;
            this.vgTemsilTaraf.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vgTemsilTaraf.Location = new System.Drawing.Point(0, 0);
            this.vgTemsilTaraf.Name = "vgTemsilTaraf";
            this.vgTemsilTaraf.RecordWidth = 111;
            this.vgTemsilTaraf.RowHeaderWidth = 89;
            this.vgTemsilTaraf.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowCARI_ADI,
            this.rowTEMSIL_YETKISI_VAR_MI,
            this.rowTEMSIL_TIP,
            this.rowTEMSILE_YETKILI_CARI1_ADI,
            this.rowTEMSILE_YETKILI_CARI2_ADI,
            this.rowTEMSILE_YETKILI_CARI3_ADI,
            this.rowTEMSIL_SONA_ERME_TARIHI,
            this.rowVSES_TIP});
            this.vgTemsilTaraf.Size = new System.Drawing.Size(349, 221);
            this.vgTemsilTaraf.TabIndex = 4;
            // 
            // rowCARI_ADI
            // 
            this.rowCARI_ADI.Name = "rowCARI_ADI";
            this.rowCARI_ADI.Properties.Caption = "Temsil Yetkisi Veren";
            this.rowCARI_ADI.Properties.FieldName = "TARAF_CARI_ID";
            this.rowCARI_ADI.Properties.RowEdit = this.rlueCari;
            // 
            // rowTEMSIL_YETKISI_VAR_MI
            // 
            this.rowTEMSIL_YETKISI_VAR_MI.Name = "rowTEMSIL_YETKISI_VAR_MI";
            this.rowTEMSIL_YETKISI_VAR_MI.Properties.Caption = "Temsil Yetkisi Var mý";
            this.rowTEMSIL_YETKISI_VAR_MI.Properties.FieldName = "TEMSIL_YETKISI_VAR_MI";
            // 
            // rowTEMSIL_TIP
            // 
            this.rowTEMSIL_TIP.Name = "rowTEMSIL_TIP";
            this.rowTEMSIL_TIP.Properties.Caption = "Temsil Tip";
            this.rowTEMSIL_TIP.Properties.FieldName = "TEMSIL_TIP_ID";
            this.rowTEMSIL_TIP.Properties.RowEdit = this.rlueTemsilTip;
            // 
            // rowTEMSILE_YETKILI_CARI1_ADI
            // 
            this.rowTEMSILE_YETKILI_CARI1_ADI.Name = "rowTEMSILE_YETKILI_CARI1_ADI";
            this.rowTEMSILE_YETKILI_CARI1_ADI.Properties.Caption = "Temsile Yetkili Þahýs1";
            this.rowTEMSILE_YETKILI_CARI1_ADI.Properties.FieldName = "TEMSILE_YETKILI_CARI1_ID";
            this.rowTEMSILE_YETKILI_CARI1_ADI.Properties.RowEdit = this.rlueCari;
            // 
            // rowTEMSILE_YETKILI_CARI2_ADI
            // 
            this.rowTEMSILE_YETKILI_CARI2_ADI.Name = "rowTEMSILE_YETKILI_CARI2_ADI";
            this.rowTEMSILE_YETKILI_CARI2_ADI.Properties.Caption = "Temsile Yetkili Þahýs2";
            this.rowTEMSILE_YETKILI_CARI2_ADI.Properties.FieldName = "TEMSILE_YETKILI_CARI2_ID";
            this.rowTEMSILE_YETKILI_CARI2_ADI.Properties.RowEdit = this.rlueCari;
            // 
            // rowTEMSILE_YETKILI_CARI3_ADI
            // 
            this.rowTEMSILE_YETKILI_CARI3_ADI.Name = "rowTEMSILE_YETKILI_CARI3_ADI";
            this.rowTEMSILE_YETKILI_CARI3_ADI.Properties.Caption = "Temsile Yetkili Þahýs3";
            this.rowTEMSILE_YETKILI_CARI3_ADI.Properties.FieldName = "TEMSILE_YETKILI_CARI3_ID";
            this.rowTEMSILE_YETKILI_CARI3_ADI.Properties.RowEdit = this.rlueCari;
            // 
            // rowTEMSIL_SONA_ERME_TARIHI
            // 
            this.rowTEMSIL_SONA_ERME_TARIHI.Name = "rowTEMSIL_SONA_ERME_TARIHI";
            this.rowTEMSIL_SONA_ERME_TARIHI.Properties.Caption = "Temsil Sona Erme T";
            this.rowTEMSIL_SONA_ERME_TARIHI.Properties.FieldName = "TEMSIL_SONA_ERME_TARIHI";
            this.rowTEMSIL_SONA_ERME_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowVSES_TIP
            // 
            this.rowVSES_TIP.Name = "rowVSES_TIP";
            this.rowVSES_TIP.Properties.Caption = "Vekalet Sona Erme Sebebi";
            this.rowVSES_TIP.Properties.FieldName = "VSES_ID";
            this.rowVSES_TIP.Properties.RowEdit = this.rlueVsesTip;
            // 
            // ucTemsilTaraf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataNavigatorExtended1);
            this.Controls.Add(this.vgTemsilTaraf);
            this.Controls.Add(this.gridTemsilTaraf);
            this.Name = "ucTemsilTaraf";
            this.Size = new System.Drawing.Size(349, 221);
            this.Load += new System.EventHandler(this.ucTemsilTaraf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridTemsilTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTemsilTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueVsesTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgTemsilTaraf)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTemsilTaraf;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CARI_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn TEMSIL_YETKISI_VAR_MI;
        private DevExpress.XtraGrid.Columns.GridColumn TEMSIL_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn TEMSILE_YETKILI_CARI1_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn TEMSILE_YETKILI_CARI2_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn TEMSILE_YETKILI_CARI3_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn TEMSIL_SONA_ERME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn VSES_TIP;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dataNavigatorExtended1;
        private DevExpress.XtraVerticalGrid.VGridControl vgTemsilTaraf;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCARI_ADI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEMSIL_YETKISI_VAR_MI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEMSIL_TIP;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEMSILE_YETKILI_CARI1_ADI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEMSILE_YETKILI_CARI2_ADI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEMSILE_YETKILI_CARI3_ADI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEMSIL_SONA_ERME_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowVSES_TIP;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueTemsilTip;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueVsesTip;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit tarih;
    }
}
