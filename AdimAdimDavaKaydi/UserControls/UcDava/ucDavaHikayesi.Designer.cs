namespace  AdimAdimDavaKaydi.UserControls.UcDava
{
    partial class ucDavaHikayesi
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
            this.gridDavaninIzahi = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.aciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.rlueHikayeSureci = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gwDananinIzahi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHIKAYE_SUREC_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISTEKLER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowHikayeSurec = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowAciklama = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowIstekler = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.dataNavigatorExtended1 = new AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended();
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaninIzahi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueHikayeSureci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwDananinIzahi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDavaninIzahi
            // 
            this.gridDavaninIzahi.CustomButtonlarGorunmesin = false;
            this.gridDavaninIzahi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDavaninIzahi.DoNotExtendEmbedNavigator = false;
            this.gridDavaninIzahi.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridDavaninIzahi.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayýt", "FormAc"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, true, "Düzenle", "KaydýDuzenle")});
            this.gridDavaninIzahi.ExternalRepository = this.MyRepository;
            this.gridDavaninIzahi.FilterText = null;
            this.gridDavaninIzahi.FilterValue = null;
            this.gridDavaninIzahi.GridlerDuzenlenebilir = true;
            this.gridDavaninIzahi.GridsFilterControl = null;
            this.gridDavaninIzahi.Location = new System.Drawing.Point(0, 0);
            this.gridDavaninIzahi.MainView = this.gwDananinIzahi;
            this.gridDavaninIzahi.MyGridStyle = null;
            this.gridDavaninIzahi.Name = "gridDavaninIzahi";
            this.gridDavaninIzahi.ShowRowNumbers = false;
            this.gridDavaninIzahi.SilmeKaldirilsin = false;
            this.gridDavaninIzahi.Size = new System.Drawing.Size(711, 502);
            this.gridDavaninIzahi.TabIndex = 0;
            this.gridDavaninIzahi.TemizleKaldirGorunsunmu = false;
            this.gridDavaninIzahi.UniqueId = "682b943b-14ed-49b9-a36a-3efa98d57ccb";
            this.gridDavaninIzahi.UseEmbeddedNavigator = true;
            this.gridDavaninIzahi.UseHyperDragDrop = false;
            this.gridDavaninIzahi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwDananinIzahi});
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.aciklama,
            this.rlueHikayeSureci});
            // 
            // aciklama
            // 
            this.aciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.aciklama.Name = "aciklama";
            // 
            // rlueHikayeSureci
            // 
            this.rlueHikayeSureci.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rlueHikayeSureci.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Yeni", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "Yeni", null, true)});
            this.rlueHikayeSureci.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.rlueHikayeSureci.Name = "rlueHikayeSureci";
            this.rlueHikayeSureci.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gwDananinIzahi
            // 
            this.gwDananinIzahi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHIKAYE_SUREC_ID,
            this.colACIKLAMA,
            this.colISTEKLER});
            this.gwDananinIzahi.GridControl = this.gridDavaninIzahi;
            this.gwDananinIzahi.IndicatorWidth = 20;
            this.gwDananinIzahi.Name = "gwDananinIzahi";
            this.gwDananinIzahi.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwDananinIzahi.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gwDananinIzahi.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gwDananinIzahi.OptionsNavigation.AutoFocusNewRow = true;
            this.gwDananinIzahi.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwDananinIzahi.OptionsView.AutoCalcPreviewLineCount = true;
            this.gwDananinIzahi.OptionsView.ColumnAutoWidth = false;
            this.gwDananinIzahi.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gwDananinIzahi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gwDananinIzahi.OptionsView.ShowAutoFilterRow = true;
            this.gwDananinIzahi.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwDananinIzahi.OptionsView.ShowPreview = true;
            this.gwDananinIzahi.PreviewFieldName = "ACIKLAMA";
            // 
            // colHIKAYE_SUREC_ID
            // 
            this.colHIKAYE_SUREC_ID.Caption = "Süreç";
            this.colHIKAYE_SUREC_ID.ColumnEdit = this.rlueHikayeSureci;
            this.colHIKAYE_SUREC_ID.FieldName = "HIKAYE_SUREC_ID";
            this.colHIKAYE_SUREC_ID.Name = "colHIKAYE_SUREC_ID";
            this.colHIKAYE_SUREC_ID.OptionsColumn.ReadOnly = true;
            this.colHIKAYE_SUREC_ID.Visible = true;
            this.colHIKAYE_SUREC_ID.VisibleIndex = 0;
            this.colHIKAYE_SUREC_ID.Width = 178;
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açýklama";
            this.colACIKLAMA.ColumnEdit = this.aciklama;
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.OptionsColumn.ReadOnly = true;
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 1;
            this.colACIKLAMA.Width = 239;
            // 
            // colISTEKLER
            // 
            this.colISTEKLER.Caption = "Ýstekler";
            this.colISTEKLER.ColumnEdit = this.aciklama;
            this.colISTEKLER.FieldName = "ISTEKLER";
            this.colISTEKLER.Name = "colISTEKLER";
            this.colISTEKLER.OptionsColumn.ReadOnly = true;
            this.colISTEKLER.Visible = true;
            this.colISTEKLER.VisibleIndex = 2;
            this.colISTEKLER.Width = 220;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.vGridControl1);
            this.panelControl1.Controls.Add(this.dataNavigatorExtended1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(711, 502);
            this.panelControl1.TabIndex = 2;
            // 
            // vGridControl1
            // 
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.ExternalRepository = this.MyRepository;
            this.vGridControl1.Location = new System.Drawing.Point(2, 2);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RecordWidth = 267;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowHikayeSurec,
            this.rowAciklama,
            this.rowIstekler});
            this.vGridControl1.Size = new System.Drawing.Size(707, 474);
            this.vGridControl1.TabIndex = 2;
            // 
            // rowHikayeSurec
            // 
            this.rowHikayeSurec.Height = 19;
            this.rowHikayeSurec.Name = "rowHikayeSurec";
            this.rowHikayeSurec.Properties.Caption = "Süreç";
            this.rowHikayeSurec.Properties.FieldName = "HIKAYE_SUREC_ID";
            this.rowHikayeSurec.Properties.RowEdit = this.rlueHikayeSureci;
            // 
            // rowAciklama
            // 
            this.rowAciklama.Height = 139;
            this.rowAciklama.Name = "rowAciklama";
            this.rowAciklama.Properties.Caption = "Açýklama";
            this.rowAciklama.Properties.FieldName = "ACIKLAMA";
            this.rowAciklama.Properties.RowEdit = this.aciklama;
            // 
            // rowIstekler
            // 
            this.rowIstekler.Height = 287;
            this.rowIstekler.Name = "rowIstekler";
            this.rowIstekler.Properties.Caption = "Ýstekler";
            this.rowIstekler.Properties.FieldName = "ISTEKLER";
            this.rowIstekler.Properties.RowEdit = this.aciklama;
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(2, 476);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = null;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = null;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(707, 24);
            this.dataNavigatorExtended1.TabIndex = 1;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            // 
            // ucDavaHikayesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridDavaninIzahi);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucDavaHikayesi";
            this.Size = new System.Drawing.Size(711, 502);
            this.Load += new System.EventHandler(this.ucDavaHikayesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaninIzahi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueHikayeSureci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwDananinIzahi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDavaninIzahi;
        private DevExpress.XtraGrid.Views.Grid.GridView gwDananinIzahi;
        private DevExpress.XtraGrid.Columns.GridColumn colHIKAYE_SUREC_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colISTEKLER;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHikayeSurec;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowAciklama;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowIstekler;
        private AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended dataNavigatorExtended1;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit aciklama;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueHikayeSureci;
    }
}
