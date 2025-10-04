namespace  AnaForm
{
    partial class frmMuhasebeAnaKategoriEkle
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
            this.panelMuhasebeanaKategorileri = new DevExpress.XtraEditors.PanelControl();
            this.gridMuhasebeAnaKategori = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemTextEdit29 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelMuhasebeanaKategorileri)).BeginInit();
            this.panelMuhasebeanaKategorileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMuhasebeAnaKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMuhasebeanaKategorileri
            // 
            this.panelMuhasebeanaKategorileri.Controls.Add(this.gridMuhasebeAnaKategori);
            this.panelMuhasebeanaKategorileri.Controls.Add(this.panelControl1);
            this.panelMuhasebeanaKategorileri.Controls.Add(this.panelControl2);
            this.panelMuhasebeanaKategorileri.Location = new System.Drawing.Point(12, 12);
            this.panelMuhasebeanaKategorileri.Name = "panelMuhasebeanaKategorileri";
            this.panelMuhasebeanaKategorileri.Size = new System.Drawing.Size(740, 368);
            this.panelMuhasebeanaKategorileri.TabIndex = 26;
            // 
            // gridMuhasebeAnaKategori
            // 
            this.gridMuhasebeAnaKategori.CustomButtonlarGorunmesin = false;
            this.gridMuhasebeAnaKategori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMuhasebeAnaKategori.DoNotExtendEmbedNavigator = false;
            this.gridMuhasebeAnaKategori.FilterText = null;
            this.gridMuhasebeAnaKategori.FilterValue = null;
            this.gridMuhasebeAnaKategori.GridlerDuzenlenebilir = true;
            this.gridMuhasebeAnaKategori.GridsFilterControl = null;
            this.gridMuhasebeAnaKategori.Location = new System.Drawing.Point(2, 72);
            this.gridMuhasebeAnaKategori.MainView = this.gridView1;
            this.gridMuhasebeAnaKategori.MyGridStyle = null;
            this.gridMuhasebeAnaKategori.Name = "gridMuhasebeAnaKategori";
            this.gridMuhasebeAnaKategori.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit29,
            this.repositoryItemCheckEdit1});
            this.gridMuhasebeAnaKategori.ShowRowNumbers = false;
            this.gridMuhasebeAnaKategori.SilmeKaldirilsin = false;
            this.gridMuhasebeAnaKategori.Size = new System.Drawing.Size(736, 294);
            this.gridMuhasebeAnaKategori.TabIndex = 5;
            this.gridMuhasebeAnaKategori.TemizleKaldirGorunsunmu = false;
            this.gridMuhasebeAnaKategori.UniqueId = "bc52d946-126e-432c-ab68-75d2a55265ab";
            this.gridMuhasebeAnaKategori.UseEmbeddedNavigator = true;
            this.gridMuhasebeAnaKategori.UseHyperDragDrop = false;
            this.gridMuhasebeAnaKategori.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridMuhasebeAnaKategori;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni muhasebe Ana Kategori Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // repositoryItemTextEdit29
            // 
            this.repositoryItemTextEdit29.AutoHeight = false;
            this.repositoryItemTextEdit29.Name = "repositoryItemTextEdit29";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(736, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Muhasebe Ana Kategorileri";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(736, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(39, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridMuhasebeAnaKategori;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(449, 382);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 27;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmMuhasebeAnaKategoriEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 417);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelMuhasebeanaKategorileri);
            this.Name = "frmMuhasebeAnaKategoriEkle";
            this.Text = "Muhasebe Ana Kategorileri";
            ((System.ComponentModel.ISupportInitialize)(this.panelMuhasebeanaKategorileri)).EndInit();
            this.panelMuhasebeanaKategorileri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMuhasebeAnaKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelMuhasebeanaKategorileri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridMuhasebeAnaKategori;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit29;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}