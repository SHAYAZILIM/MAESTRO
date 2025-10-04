namespace  AnaForm
{
    partial class frmBankaAdlari
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
            this.panelBankaAdlari = new DevExpress.XtraEditors.PanelControl();
            this.gridBankaAdlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BANKA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxteBankaAdi = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelBankaAdlari)).BeginInit();
            this.panelBankaAdlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBankaAdlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteBankaAdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBankaAdlari
            // 
            this.panelBankaAdlari.Controls.Add(this.gridBankaAdlari);
            this.panelBankaAdlari.Controls.Add(this.panelControl1);
            this.panelBankaAdlari.Controls.Add(this.panelControl2);
            this.panelBankaAdlari.Location = new System.Drawing.Point(4, 12);
            this.panelBankaAdlari.Name = "panelBankaAdlari";
            this.panelBankaAdlari.Size = new System.Drawing.Size(750, 360);
            this.panelBankaAdlari.TabIndex = 16;
            // 
            // gridBankaAdlari
            // 
            this.gridBankaAdlari.CustomButtonlarGorunmesin = false;
            this.gridBankaAdlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBankaAdlari.DoNotExtendEmbedNavigator = false;
            this.gridBankaAdlari.FilterText = null;
            this.gridBankaAdlari.FilterValue = null;
            this.gridBankaAdlari.GridlerDuzenlenebilir = true;
            this.gridBankaAdlari.GridsFilterControl = null;
            this.gridBankaAdlari.Location = new System.Drawing.Point(2, 72);
            this.gridBankaAdlari.MainView = this.gridView1;
            this.gridBankaAdlari.MyGridStyle = null;
            this.gridBankaAdlari.Name = "gridBankaAdlari";
            this.gridBankaAdlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxteBankaAdi});
            this.gridBankaAdlari.ShowRowNumbers = false;
            this.gridBankaAdlari.SilmeKaldirilsin = false;
            this.gridBankaAdlari.Size = new System.Drawing.Size(746, 286);
            this.gridBankaAdlari.TabIndex = 5;
            this.gridBankaAdlari.TemizleKaldirGorunsunmu = false;
            this.gridBankaAdlari.UniqueId = "4a213077-1f8f-49b1-b9f3-6988bb5230ce";
            this.gridBankaAdlari.UseEmbeddedNavigator = true;
            this.gridBankaAdlari.UseHyperDragDrop = false;
            this.gridBankaAdlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BANKA});
            this.gridView1.GridControl = this.gridBankaAdlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Banka Adý Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // BANKA
            // 
            this.BANKA.Caption = "Banka Adý";
            this.BANKA.ColumnEdit = this.rtxteBankaAdi;
            this.BANKA.FieldName = "BANKA";
            this.BANKA.Name = "BANKA";
            this.BANKA.Visible = true;
            this.BANKA.VisibleIndex = 0;
            // 
            // rtxteBankaAdi
            // 
            this.rtxteBankaAdi.AutoHeight = false;
            this.rtxteBankaAdi.Name = "rtxteBankaAdi";
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
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Banka Adlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(746, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(41, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(117, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmBankaAdlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 440);
            this.Controls.Add(this.panelBankaAdlari);
            this.Name = "frmBankaAdlari";
            this.Text = "Banka Adlarý";
            this.Load += new System.EventHandler(this.frmBankaAdlari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelBankaAdlari)).EndInit();
            this.panelBankaAdlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBankaAdlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteBankaAdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelBankaAdlari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridBankaAdlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn BANKA;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxteBankaAdi;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        //private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
    }
}