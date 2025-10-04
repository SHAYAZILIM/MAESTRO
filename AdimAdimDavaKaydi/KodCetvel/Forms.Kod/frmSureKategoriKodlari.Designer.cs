namespace  AnaForm
{
    partial class frmSureKategoriKodlari
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelSureKategoriKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridSureKategoriKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KATEGORI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelSureKategoriKodlar)).BeginInit();
            this.panelSureKategoriKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSureKategoriKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSureKategoriKodlar
            // 
            this.panelSureKategoriKodlar.Controls.Add(this.gridSureKategoriKodlar);
            this.panelSureKategoriKodlar.Controls.Add(this.panelControl1);
            this.panelSureKategoriKodlar.Controls.Add(this.panelControl2);
            this.panelSureKategoriKodlar.Location = new System.Drawing.Point(10, 12);
            this.panelSureKategoriKodlar.Name = "panelSureKategoriKodlar";
            this.panelSureKategoriKodlar.Size = new System.Drawing.Size(750, 360);
            this.panelSureKategoriKodlar.TabIndex = 20;
            // 
            // gridSureKategoriKodlar
            // 
            this.gridSureKategoriKodlar.CustomButtonlarGorunmesin = false;
            this.gridSureKategoriKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSureKategoriKodlar.DoNotExtendEmbedNavigator = false;
            this.gridSureKategoriKodlar.FilterText = null;
            this.gridSureKategoriKodlar.FilterValue = null;
            this.gridSureKategoriKodlar.GridlerDuzenlenebilir = true;
            this.gridSureKategoriKodlar.GridsFilterControl = null;
            this.gridSureKategoriKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridSureKategoriKodlar.MainView = this.gridView1;
            this.gridSureKategoriKodlar.MyGridStyle = null;
            this.gridSureKategoriKodlar.Name = "gridSureKategoriKodlar";
            this.gridSureKategoriKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gridSureKategoriKodlar.ShowRowNumbers = false;
            this.gridSureKategoriKodlar.Size = new System.Drawing.Size(746, 286);
            this.gridSureKategoriKodlar.TabIndex = 5;
            this.gridSureKategoriKodlar.TemizleKaldirGorunsunmu = false;
            this.gridSureKategoriKodlar.UniqueId = "88f55d64-96ba-4955-a654-b98871eb3495";
            this.gridSureKategoriKodlar.UseEmbeddedNavigator = true;
            this.gridSureKategoriKodlar.UseHyperDragDrop = false;
            this.gridSureKategoriKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KATEGORI});
            this.gridView1.GridControl = this.gridSureKategoriKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Süre Kategorisi Ekleyin ";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // KATEGORI
            // 
            this.KATEGORI.Caption = "Süre Kategori";
            this.KATEGORI.ColumnEdit = this.repositoryItemTextEdit1;
            this.KATEGORI.FieldName = "KATEGORI";
            this.KATEGORI.Name = "KATEGORI";
            this.KATEGORI.Visible = true;
            this.KATEGORI.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(746, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Süre Kategori Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sBtnKaydet);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(746, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(53, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 6;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridSureKategoriKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(355, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 21;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmSureKategoriKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 426);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelSureKategoriKodlar);
            this.Name = "frmSureKategoriKodlari";
            this.Text = "Süre Kategori Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelSureKategoriKodlar)).EndInit();
            this.panelSureKategoriKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSureKategoriKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelSureKategoriKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridSureKategoriKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn KATEGORI;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}