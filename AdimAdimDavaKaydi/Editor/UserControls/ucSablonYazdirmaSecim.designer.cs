namespace  AvpNg.Editor.UserControls
{
    partial class ucSablonYazdirmaSecim
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.rlueSablonlar = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueYaziTipleri = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueYazdirmaSayislari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueYazdirmaSayisi = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSABLON_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYAZDIRILACAK_SABLON_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYAZI_TIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYAZDIRILSIN_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEDBIRDE_CIKSIN_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHACIZDE_CIKSIN_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCIKTI_SAYISININ_ALINACAGI_ALAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCIKTI_SAYISI = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueSablonlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueYaziTipleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueYazdirmaSayislari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueYazdirmaSayisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueSablonlar,
            this.rlueYazdirmaSayisi,
            this.rlueYaziTipleri,
            this.rlueYazdirmaSayislari});
            this.gridControl1.Size = new System.Drawing.Size(419, 273);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // rlueSablonlar
            // 
            this.rlueSablonlar.AutoHeight = false;
            this.rlueSablonlar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueSablonlar.Name = "rlueSablonlar";
            // 
            // rlueYaziTipleri
            // 
            this.rlueYaziTipleri.AutoHeight = false;
            this.rlueYaziTipleri.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueYaziTipleri.Name = "rlueYaziTipleri";
            // 
            // rlueYazdirmaSayislari
            // 
            this.rlueYazdirmaSayislari.AutoHeight = false;
            this.rlueYazdirmaSayislari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueYazdirmaSayislari.Name = "rlueYazdirmaSayislari";
            // 
            // rlueYazdirmaSayisi
            // 
            this.rlueYazdirmaSayisi.AutoHeight = false;
            this.rlueYazdirmaSayisi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueYazdirmaSayisi.Items.AddRange(new object[] {
            "Takip Eden Sayýsý",
            "Takip Edilen Sayýsý",
            "Sorumlu Avukat Sayýsý",
            "Takýp Eden Sayýsý + Sorumlu Avukat Sayýsý",
            "Takýp Edýlen Sayýsý + Sorumlu Avukat Sayýsý",
            "Takýp Eden Sayýsý + Takýp Edýlen Sayýsý",
            "Takýp Eden Sayýsý + Takýp Edýlen Sayýsý + Sorumlu Avukat Sayýsý",
            "Her Taraf için ve Bu Taraflarýn  her Bir Adresi Ýçinde Birer Tane",
            "Sadece Bir Kopyasýný Oluþtur",
            "Hiçbiri"});
            this.rlueYazdirmaSayisi.Name = "rlueYazdirmaSayisi";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsSelected,
            this.colSABLON_ID,
            this.colYAZDIRILACAK_SABLON_ID,
            this.colYAZI_TIPI,
            this.colYAZDIRILSIN_MI,
            this.colTEDBIRDE_CIKSIN_MI,
            this.colHACIZDE_CIKSIN_MI,
            this.colCIKTI_SAYISININ_ALINACAGI_ALAN,
            this.colCIKTI_SAYISI});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colYAZDIRILACAK_SABLON_ID, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colIsSelected
            // 
            this.colIsSelected.Caption = "Seçili mi?";
            this.colIsSelected.FieldName = "IsSelected";
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.Visible = true;
            this.colIsSelected.VisibleIndex = 3;
            this.colIsSelected.Width = 81;
            // 
            // colSABLON_ID
            // 
            this.colSABLON_ID.Caption = "Þablon";
            this.colSABLON_ID.ColumnEdit = this.rlueSablonlar;
            this.colSABLON_ID.FieldName = "SABLON_ID";
            this.colSABLON_ID.Name = "colSABLON_ID";
            this.colSABLON_ID.Visible = true;
            this.colSABLON_ID.VisibleIndex = 6;
            this.colSABLON_ID.Width = 46;
            // 
            // colYAZDIRILACAK_SABLON_ID
            // 
            this.colYAZDIRILACAK_SABLON_ID.Caption = "Yazdýrýlacak Þablon";
            this.colYAZDIRILACAK_SABLON_ID.ColumnEdit = this.rlueSablonlar;
            this.colYAZDIRILACAK_SABLON_ID.FieldName = "YAZDIRILACAK_SABLON_ID";
            this.colYAZDIRILACAK_SABLON_ID.Name = "colYAZDIRILACAK_SABLON_ID";
            this.colYAZDIRILACAK_SABLON_ID.Visible = true;
            this.colYAZDIRILACAK_SABLON_ID.VisibleIndex = 4;
            this.colYAZDIRILACAK_SABLON_ID.Width = 139;
            // 
            // colYAZI_TIPI
            // 
            this.colYAZI_TIPI.Caption = "Yazý Tipi";
            this.colYAZI_TIPI.ColumnEdit = this.rlueYaziTipleri;
            this.colYAZI_TIPI.FieldName = "YAZI_TIPI";
            this.colYAZI_TIPI.Name = "colYAZI_TIPI";
            this.colYAZI_TIPI.Visible = true;
            this.colYAZI_TIPI.VisibleIndex = 5;
            this.colYAZI_TIPI.Width = 55;
            // 
            // colYAZDIRILSIN_MI
            // 
            this.colYAZDIRILSIN_MI.Caption = "Takip Ekranýndan Gelirken Yazýdýlsýnmý";
            this.colYAZDIRILSIN_MI.FieldName = "YAZDIRILSIN_MI";
            this.colYAZDIRILSIN_MI.Name = "colYAZDIRILSIN_MI";
            this.colYAZDIRILSIN_MI.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colYAZDIRILSIN_MI.Visible = true;
            this.colYAZDIRILSIN_MI.VisibleIndex = 0;
            this.colYAZDIRILSIN_MI.Width = 109;
            // 
            // colTEDBIRDE_CIKSIN_MI
            // 
            this.colTEDBIRDE_CIKSIN_MI.Caption = "Tedbirde Çýksýn mý?";
            this.colTEDBIRDE_CIKSIN_MI.FieldName = "TEDBIRDE_CIKSIN_MI";
            this.colTEDBIRDE_CIKSIN_MI.Name = "colTEDBIRDE_CIKSIN_MI";
            this.colTEDBIRDE_CIKSIN_MI.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colTEDBIRDE_CIKSIN_MI.Visible = true;
            this.colTEDBIRDE_CIKSIN_MI.VisibleIndex = 1;
            this.colTEDBIRDE_CIKSIN_MI.Width = 66;
            // 
            // colHACIZDE_CIKSIN_MI
            // 
            this.colHACIZDE_CIKSIN_MI.Caption = "Hacizde Çýksýn mý?";
            this.colHACIZDE_CIKSIN_MI.FieldName = "HACIZDE_CIKSIN_MI";
            this.colHACIZDE_CIKSIN_MI.Name = "colHACIZDE_CIKSIN_MI";
            this.colHACIZDE_CIKSIN_MI.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colHACIZDE_CIKSIN_MI.Visible = true;
            this.colHACIZDE_CIKSIN_MI.VisibleIndex = 2;
            this.colHACIZDE_CIKSIN_MI.Width = 59;
            // 
            // colCIKTI_SAYISININ_ALINACAGI_ALAN
            // 
            this.colCIKTI_SAYISININ_ALINACAGI_ALAN.Caption = "Çýktý Sayýsýna Þu Alandan da Gelen Sayý Eklensin";
            this.colCIKTI_SAYISININ_ALINACAGI_ALAN.ColumnEdit = this.rlueYazdirmaSayislari;
            this.colCIKTI_SAYISININ_ALINACAGI_ALAN.FieldName = "CIKTI_SAYISININ_ALINACAGI_ALAN";
            this.colCIKTI_SAYISININ_ALINACAGI_ALAN.Name = "colCIKTI_SAYISININ_ALINACAGI_ALAN";
            this.colCIKTI_SAYISININ_ALINACAGI_ALAN.Visible = true;
            this.colCIKTI_SAYISININ_ALINACAGI_ALAN.VisibleIndex = 7;
            this.colCIKTI_SAYISININ_ALINACAGI_ALAN.Width = 87;
            // 
            // colCIKTI_SAYISI
            // 
            this.colCIKTI_SAYISI.Caption = "Çýktý Sayýsý";
            this.colCIKTI_SAYISI.FieldName = "CIKTI_SAYISI";
            this.colCIKTI_SAYISI.Name = "colCIKTI_SAYISI";
            this.colCIKTI_SAYISI.Visible = true;
            this.colCIKTI_SAYISI.VisibleIndex = 8;
            this.colCIKTI_SAYISI.Width = 64;
            // 
            // ucSablonYazdirmaSecim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "ucSablonYazdirmaSecim";
            this.Size = new System.Drawing.Size(419, 273);
            this.Load += new System.EventHandler(this.ucSablonYazdirmaSecim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueSablonlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueYaziTipleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueYazdirmaSayislari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueYazdirmaSayisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueSablonlar;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueYaziTipleri;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rlueYazdirmaSayisi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueYazdirmaSayislari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSelected;
        private DevExpress.XtraGrid.Columns.GridColumn colSABLON_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colYAZDIRILACAK_SABLON_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colYAZI_TIPI;
        private DevExpress.XtraGrid.Columns.GridColumn colYAZDIRILSIN_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colTEDBIRDE_CIKSIN_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colHACIZDE_CIKSIN_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colCIKTI_SAYISININ_ALINACAGI_ALAN;
        private DevExpress.XtraGrid.Columns.GridColumn colCIKTI_SAYISI;
    }
}
