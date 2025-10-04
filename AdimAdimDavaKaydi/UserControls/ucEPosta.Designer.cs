namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucEPosta
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
            this.exEPosta = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rlueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKONU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGONDEREN_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGONDERILENLER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colICERIK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.colDISARIDAN_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colREFERANS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exEPosta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // exEPosta
            // 
            this.exEPosta.CustomButtonlarGorunmesin = false;
            this.exEPosta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exEPosta.DoNotExtendEmbedNavigator = false;
            this.exEPosta.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.exEPosta.ExternalRepository = this.MyRepository;
            this.exEPosta.FilterText = null;
            this.exEPosta.FilterValue = null;
            this.exEPosta.GridlerDuzenlenebilir = true;
            this.exEPosta.GridsFilterControl = null;
            this.exEPosta.Location = new System.Drawing.Point(0, 0);
            this.exEPosta.MainView = this.gridView1;
            this.exEPosta.MyGridStyle = null;
            this.exEPosta.Name = "exEPosta";
            this.exEPosta.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1});
            this.exEPosta.ShowRowNumbers = false;
            this.exEPosta.SilmeKaldirilsin = false;
            this.exEPosta.Size = new System.Drawing.Size(711, 494);
            this.exEPosta.TabIndex = 0;
            this.exEPosta.TemizleKaldirGorunsunmu = false;
            this.exEPosta.UniqueId = "22aed9f3-aa5b-4ebf-a439-ca8a51fb22cb";
            this.exEPosta.UseEmbeddedNavigator = true;
            this.exEPosta.UseHyperDragDrop = false;
            this.exEPosta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueCari});
            // 
            // rlueCari
            // 
            this.rlueCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueCari.Name = "rlueCari";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKONU,
            this.colGONDEREN_CARI_ID,
            this.colGONDERILENLER,
            this.colCC,
            this.colBCC,
            this.colICERIK,
            this.colDISARIDAN_MI,
            this.colREFERANS_NO});
            this.gridView1.GridControl = this.exEPosta;
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.OptionsView.ShowPreview = true;
            this.gridView1.PreviewFieldName = "ICERIK";
            // 
            // colKONU
            // 
            this.colKONU.Caption = "Konu";
            this.colKONU.FieldName = "KONU";
            this.colKONU.Name = "colKONU";
            this.colKONU.OptionsColumn.ReadOnly = true;
            this.colKONU.Visible = true;
            this.colKONU.VisibleIndex = 0;
            // 
            // colGONDEREN_CARI_ID
            // 
            this.colGONDEREN_CARI_ID.Caption = "Gönderen";
            this.colGONDEREN_CARI_ID.ColumnEdit = this.rlueCari;
            this.colGONDEREN_CARI_ID.FieldName = "GONDEREN_CARI_ID";
            this.colGONDEREN_CARI_ID.Name = "colGONDEREN_CARI_ID";
            this.colGONDEREN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colGONDEREN_CARI_ID.Visible = true;
            this.colGONDEREN_CARI_ID.VisibleIndex = 1;
            // 
            // colGONDERILENLER
            // 
            this.colGONDERILENLER.Caption = "Gönderilenler";
            this.colGONDERILENLER.ColumnEdit = this.rlueCari;
            this.colGONDERILENLER.FieldName = "GONDERILENLER";
            this.colGONDERILENLER.Name = "colGONDERILENLER";
            this.colGONDERILENLER.OptionsColumn.ReadOnly = true;
            this.colGONDERILENLER.Visible = true;
            this.colGONDERILENLER.VisibleIndex = 2;
            // 
            // colCC
            // 
            this.colCC.Caption = "CC";
            this.colCC.ColumnEdit = this.rlueCari;
            this.colCC.FieldName = "CC";
            this.colCC.Name = "colCC";
            this.colCC.OptionsColumn.ReadOnly = true;
            this.colCC.Visible = true;
            this.colCC.VisibleIndex = 3;
            // 
            // colBCC
            // 
            this.colBCC.Caption = "BCC";
            this.colBCC.ColumnEdit = this.rlueCari;
            this.colBCC.FieldName = "BCC";
            this.colBCC.Name = "colBCC";
            this.colBCC.OptionsColumn.ReadOnly = true;
            this.colBCC.Visible = true;
            this.colBCC.VisibleIndex = 4;
            // 
            // colICERIK
            // 
            this.colICERIK.Caption = "Ýçerik";
            this.colICERIK.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colICERIK.FieldName = "ICERIK";
            this.colICERIK.Name = "colICERIK";
            this.colICERIK.OptionsColumn.ReadOnly = true;
            this.colICERIK.Visible = true;
            this.colICERIK.VisibleIndex = 5;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // colDISARIDAN_MI
            // 
            this.colDISARIDAN_MI.Caption = "Dýþardan";
            this.colDISARIDAN_MI.FieldName = "DISARIDAN_MI";
            this.colDISARIDAN_MI.Name = "colDISARIDAN_MI";
            this.colDISARIDAN_MI.OptionsColumn.ReadOnly = true;
            this.colDISARIDAN_MI.Visible = true;
            this.colDISARIDAN_MI.VisibleIndex = 6;
            // 
            // colREFERANS_NO
            // 
            this.colREFERANS_NO.Caption = "Referans No";
            this.colREFERANS_NO.FieldName = "REFERANS_NO";
            this.colREFERANS_NO.Name = "colREFERANS_NO";
            this.colREFERANS_NO.OptionsColumn.ReadOnly = true;
            this.colREFERANS_NO.Visible = true;
            this.colREFERANS_NO.VisibleIndex = 7;
            // 
            // ucEPosta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exEPosta);
            this.Name = "ucEPosta";
            this.Size = new System.Drawing.Size(711, 494);
            this.Load += new System.EventHandler(this.ucEPosta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exEPosta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl exEPosta;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colKONU;
        private DevExpress.XtraGrid.Columns.GridColumn colGONDEREN_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colGONDERILENLER;
        private DevExpress.XtraGrid.Columns.GridColumn colCC;
        private DevExpress.XtraGrid.Columns.GridColumn colBCC;
        private DevExpress.XtraGrid.Columns.GridColumn colICERIK;
        private DevExpress.XtraGrid.Columns.GridColumn colDISARIDAN_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colREFERANS_NO;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCari;
    }
}
