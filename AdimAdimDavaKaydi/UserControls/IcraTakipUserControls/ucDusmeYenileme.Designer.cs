namespace  AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    partial class ucDusmeYenileme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDusmeYenileme));
            this.gridDusmeYenileme = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.tarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DUSME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ESKI_ICRA_DOSYA_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YENILEME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dnDusmeYenileme = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            this.vGDusmeYenileme = new DevExpress.XtraVerticalGrid.VGridControl();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rowDUSME_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowESKI_ICRA_DOSYA_NO = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowYENILEME_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.gridDusmeYenileme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGDusmeYenileme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDusmeYenileme
            // 
            this.gridDusmeYenileme.CustomButtonlarGorunmesin = false;
            resources.ApplyResources(this.gridDusmeYenileme, "gridDusmeYenileme");
            this.gridDusmeYenileme.DoNotExtendEmbedNavigator = false;
            this.gridDusmeYenileme.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridDusmeYenileme.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridDusmeYenileme.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(((int)(resources.GetObject("gridDusmeYenileme.EmbeddedNavigator.CustomButtons"))), ((int)(resources.GetObject("gridDusmeYenileme.EmbeddedNavigator.CustomButtons1"))), ((bool)(resources.GetObject("gridDusmeYenileme.EmbeddedNavigator.CustomButtons2"))), ((bool)(resources.GetObject("gridDusmeYenileme.EmbeddedNavigator.CustomButtons3"))), resources.GetString("gridDusmeYenileme.EmbeddedNavigator.CustomButtons4"), resources.GetString("gridDusmeYenileme.EmbeddedNavigator.CustomButtons5")),
            new DevExpress.XtraEditors.NavigatorCustomButton(((int)(resources.GetObject("gridDusmeYenileme.EmbeddedNavigator.CustomButtons6"))), ((int)(resources.GetObject("gridDusmeYenileme.EmbeddedNavigator.CustomButtons7"))), ((bool)(resources.GetObject("gridDusmeYenileme.EmbeddedNavigator.CustomButtons8"))), ((bool)(resources.GetObject("gridDusmeYenileme.EmbeddedNavigator.CustomButtons9"))), resources.GetString("gridDusmeYenileme.EmbeddedNavigator.CustomButtons10"), resources.GetString("gridDusmeYenileme.EmbeddedNavigator.CustomButtons11"))});
            this.gridDusmeYenileme.ExternalRepository = this.MyRepository;
            this.gridDusmeYenileme.FilterText = null;
            this.gridDusmeYenileme.FilterValue = null;
            this.gridDusmeYenileme.GridlerDuzenlenebilir = true;
            this.gridDusmeYenileme.GridsFilterControl = null;
            this.gridDusmeYenileme.MainView = this.gridView10;
            this.gridDusmeYenileme.MyGridStyle = null;
            this.gridDusmeYenileme.Name = "gridDusmeYenileme";
            this.gridDusmeYenileme.ShowRowNumbers = false;
            this.gridDusmeYenileme.SilmeKaldirilsin = false;
            this.gridDusmeYenileme.TemizleKaldirGorunsunmu = false;
            this.gridDusmeYenileme.UniqueId = "e69ca4a6-31ea-41e5-81df-02ee490e7c08";
            this.gridDusmeYenileme.UseEmbeddedNavigator = true;
            this.gridDusmeYenileme.UseHyperDragDrop = false;
            this.gridDusmeYenileme.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView10});
            this.gridDusmeYenileme.ButtonClick += new System.EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(this.gridDusmeYenileme_ButtonClick);
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.tarih});
            // 
            // tarih
            // 
            resources.ApplyResources(this.tarih, "tarih");
            this.tarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("tarih.Buttons"))))});
            this.tarih.Name = "tarih";
            this.tarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridView10
            // 
            this.gridView10.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DUSME_TARIHI,
            this.ESKI_ICRA_DOSYA_NO,
            this.YENILEME_TARIHI});
            this.gridView10.GridControl = this.gridDusmeYenileme;
            resources.ApplyResources(this.gridView10, "gridView10");
            this.gridView10.IndicatorWidth = 20;
            this.gridView10.Name = "gridView10";
            this.gridView10.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView10.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView10.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView10.OptionsView.ColumnAutoWidth = false;
            this.gridView10.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView10.OptionsView.ShowAutoFilterRow = true;
            this.gridView10.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView10.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // DUSME_TARIHI
            // 
            resources.ApplyResources(this.DUSME_TARIHI, "DUSME_TARIHI");
            this.DUSME_TARIHI.ColumnEdit = this.tarih;
            this.DUSME_TARIHI.FieldName = "DUSME_TARIHI";
            this.DUSME_TARIHI.Name = "DUSME_TARIHI";
            // 
            // ESKI_ICRA_DOSYA_NO
            // 
            resources.ApplyResources(this.ESKI_ICRA_DOSYA_NO, "ESKI_ICRA_DOSYA_NO");
            this.ESKI_ICRA_DOSYA_NO.FieldName = "ESKI_ICRA_DOSYA_NO";
            this.ESKI_ICRA_DOSYA_NO.Name = "ESKI_ICRA_DOSYA_NO";
            // 
            // YENILEME_TARIHI
            // 
            resources.ApplyResources(this.YENILEME_TARIHI, "YENILEME_TARIHI");
            this.YENILEME_TARIHI.ColumnEdit = this.tarih;
            this.YENILEME_TARIHI.FieldName = "YENILEME_TARIHI";
            this.YENILEME_TARIHI.Name = "YENILEME_TARIHI";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dnDusmeYenileme);
            this.panelControl1.Controls.Add(this.vGDusmeYenileme);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // dnDusmeYenileme
            // 
            this.dnDusmeYenileme.Buttons.CancelEdit.Visible = false;
            this.dnDusmeYenileme.Buttons.NextPage.Visible = false;
            this.dnDusmeYenileme.Buttons.PrevPage.Visible = false;
            resources.ApplyResources(this.dnDusmeYenileme, "dnDusmeYenileme");
            this.dnDusmeYenileme.MyChartControl = null;
            this.dnDusmeYenileme.MyGridControl = this.gridDusmeYenileme;
            this.dnDusmeYenileme.MyPivotGridControl = null;
            this.dnDusmeYenileme.MyVGridControl = this.vGDusmeYenileme;
            this.dnDusmeYenileme.Name = "dnDusmeYenileme";
            this.dnDusmeYenileme.SelectButtonVisible = false;
            // 
            // vGDusmeYenileme
            // 
            resources.ApplyResources(this.vGDusmeYenileme, "vGDusmeYenileme");
            this.vGDusmeYenileme.ExternalRepository = this.MyRepository;
            this.vGDusmeYenileme.Name = "vGDusmeYenileme";
            this.vGDusmeYenileme.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.vGDusmeYenileme.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowDUSME_TARIHI,
            this.rowESKI_ICRA_DOSYA_NO,
            this.rowYENILEME_TARIHI});
            // 
            // repositoryItemDateEdit1
            // 
            resources.ApplyResources(this.repositoryItemDateEdit1, "repositoryItemDateEdit1");
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemDateEdit1.Buttons"))))});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rowDUSME_TARIHI
            // 
            resources.ApplyResources(this.rowDUSME_TARIHI, "rowDUSME_TARIHI");
            this.rowDUSME_TARIHI.Properties.Caption = resources.GetString("rowDUSME_TARIHI.Properties.Caption");
            this.rowDUSME_TARIHI.Properties.FieldName = "DUSME_TARIHI";
            this.rowDUSME_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowESKI_ICRA_DOSYA_NO
            // 
            resources.ApplyResources(this.rowESKI_ICRA_DOSYA_NO, "rowESKI_ICRA_DOSYA_NO");
            this.rowESKI_ICRA_DOSYA_NO.Properties.Caption = resources.GetString("rowESKI_ICRA_DOSYA_NO.Properties.Caption");
            this.rowESKI_ICRA_DOSYA_NO.Properties.FieldName = "ESKI_ICRA_DOSYA_NO";
            // 
            // rowYENILEME_TARIHI
            // 
            resources.ApplyResources(this.rowYENILEME_TARIHI, "rowYENILEME_TARIHI");
            this.rowYENILEME_TARIHI.Properties.Caption = resources.GetString("rowYENILEME_TARIHI.Properties.Caption");
            this.rowYENILEME_TARIHI.Properties.FieldName = "YENILEME_TARIHI";
            this.rowYENILEME_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // ucDusmeYenileme
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridDusmeYenileme);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucDusmeYenileme";
            this.Load += new System.EventHandler(this.ucDusmeYenileme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDusmeYenileme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGDusmeYenileme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDusmeYenileme;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView10;
        private DevExpress.XtraGrid.Columns.GridColumn DUSME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn ESKI_ICRA_DOSYA_NO;
        private DevExpress.XtraGrid.Columns.GridColumn YENILEME_TARIHI;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit tarih;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraVerticalGrid.VGridControl vGDusmeYenileme;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dnDusmeYenileme;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDUSME_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowESKI_ICRA_DOSYA_NO;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowYENILEME_TARIHI;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
    }
}
