namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmAdresDurum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdresDurum));
            this.panelAdresDurumlari = new DevExpress.XtraEditors.PanelControl();
            this.gridAdresDurumlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ADRESDURUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxteAdresDurum = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelAdresDurumlari)).BeginInit();
            this.panelAdresDurumlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAdresDurumlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteAdresDurum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAdresDurumlari
            // 
            this.panelAdresDurumlari.Controls.Add(this.gridAdresDurumlari);
            this.panelAdresDurumlari.Controls.Add(this.panelControl1);
            this.panelAdresDurumlari.Controls.Add(this.panelControl2);
            this.panelAdresDurumlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdresDurumlari.Location = new System.Drawing.Point(0, 0);
            this.panelAdresDurumlari.Name = "panelAdresDurumlari";
            this.panelAdresDurumlari.Size = new System.Drawing.Size(535, 400);
            this.panelAdresDurumlari.TabIndex = 18;
            // 
            // gridAdresDurumlari
            // 
            this.gridAdresDurumlari.CustomButtonlarGorunmesin = false;
            this.gridAdresDurumlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAdresDurumlari.DoNotExtendEmbedNavigator = false;
            this.gridAdresDurumlari.FilterText = null;
            this.gridAdresDurumlari.FilterValue = null;
            this.gridAdresDurumlari.GridlerDuzenlenebilir = true;
            this.gridAdresDurumlari.GridsFilterControl = null;
            this.gridAdresDurumlari.Location = new System.Drawing.Point(2, 72);
            this.gridAdresDurumlari.MainView = this.gridView1;
            this.gridAdresDurumlari.MyGridStyle = null;
            this.gridAdresDurumlari.Name = "gridAdresDurumlari";
            this.gridAdresDurumlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxteAdresDurum});
            this.gridAdresDurumlari.ShowRowNumbers = false;
            this.gridAdresDurumlari.SilmeKaldirilsin = false;
            this.gridAdresDurumlari.Size = new System.Drawing.Size(531, 326);
            this.gridAdresDurumlari.TabIndex = 5;
            this.gridAdresDurumlari.TemizleKaldirGorunsunmu = false;
            this.gridAdresDurumlari.UniqueId = "eafb1168-c4c9-4a7c-87ee-011b0405699d";
            this.gridAdresDurumlari.UseEmbeddedNavigator = true;
            this.gridAdresDurumlari.UseHyperDragDrop = false;
            this.gridAdresDurumlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ADRESDURUM});
            this.gridView1.GridControl = this.gridAdresDurumlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Adres Durum Adı Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ADRESDURUM
            // 
            this.ADRESDURUM.Caption = "Adres Durum";
            this.ADRESDURUM.ColumnEdit = this.rtxteAdresDurum;
            this.ADRESDURUM.FieldName = "ADRES_DURUM";
            this.ADRESDURUM.Name = "ADRESDURUM";
            this.ADRESDURUM.Visible = true;
            this.ADRESDURUM.VisibleIndex = 0;
            // 
            // rtxteAdresDurum
            // 
            this.rtxteAdresDurum.AutoHeight = false;
            this.rtxteAdresDurum.Name = "rtxteAdresDurum";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(531, 27);
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
            this.label1.Text = "AdresDurum";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(531, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(19, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(117, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // frmAdresDurum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 400);
            this.Controls.Add(this.panelAdresDurumlari);
            this.Name = "frmAdresDurum";
            this.Text = "AdresDurum";
            ((System.ComponentModel.ISupportInitialize)(this.panelAdresDurumlari)).EndInit();
            this.panelAdresDurumlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAdresDurumlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteAdresDurum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelAdresDurumlari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridAdresDurumlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ADRESDURUM;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxteAdresDurum;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;


    }
}