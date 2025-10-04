namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmSektor
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.rtxteAd = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelSektor = new DevExpress.XtraEditors.PanelControl();
            this.gridSektor = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Ad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Aciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxteAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteAd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSektor)).BeginInit();
            this.panelSektor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSektor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteAciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(638, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(28, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(117, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // rtxteAd
            // 
            this.rtxteAd.AutoHeight = false;
            this.rtxteAd.Name = "rtxteAd";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // panelSektor
            // 
            this.panelSektor.Controls.Add(this.gridSektor);
            this.panelSektor.Controls.Add(this.panelControl1);
            this.panelSektor.Controls.Add(this.panelControl2);
            this.panelSektor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSektor.Location = new System.Drawing.Point(0, 0);
            this.panelSektor.Name = "panelSektor";
            this.panelSektor.Size = new System.Drawing.Size(642, 365);
            this.panelSektor.TabIndex = 21;
            // 
            // gridSektor
            // 
            this.gridSektor.CustomButtonlarGorunmesin = false;
            this.gridSektor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSektor.DoNotExtendEmbedNavigator = false;
            this.gridSektor.FilterText = null;
            this.gridSektor.FilterValue = null;
            this.gridSektor.GridlerDuzenlenebilir = true;
            this.gridSektor.GridsFilterControl = null;
            this.gridSektor.Location = new System.Drawing.Point(2, 72);
            this.gridSektor.MainView = this.gridView1;
            this.gridSektor.MyGridStyle = null;
            this.gridSektor.Name = "gridSektor";
            this.gridSektor.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxteAciklama,
            this.rtxteAd});
            this.gridSektor.ShowRowNumbers = false;
            this.gridSektor.SilmeKaldirilsin = false;
            this.gridSektor.Size = new System.Drawing.Size(638, 291);
            this.gridSektor.TabIndex = 5;
            this.gridSektor.TemizleKaldirGorunsunmu = false;
            this.gridSektor.UniqueId = "decb9a93-b90a-446d-b37e-103eb5afe20b";
            this.gridSektor.UseEmbeddedNavigator = true;
            this.gridSektor.UseHyperDragDrop = false;
            this.gridSektor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Ad,
            this.Aciklama});
            this.gridView1.GridControl = this.gridSektor;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Sözlüğe Yeni Kelime Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // Ad
            // 
            this.Ad.Caption = "Ad";
            this.Ad.FieldName = "AD";
            this.Ad.Name = "Ad";
            this.Ad.Visible = true;
            this.Ad.VisibleIndex = 0;
            // 
            // Aciklama
            // 
            this.Aciklama.Caption = "Açıklama";
            this.Aciklama.FieldName = "ACIKLAMA";
            this.Aciklama.Name = "Aciklama";
            this.Aciklama.Visible = true;
            this.Aciklama.VisibleIndex = 1;
            // 
            // rtxteAciklama
            // 
            this.rtxteAciklama.AutoHeight = false;
            this.rtxteAciklama.Name = "rtxteAciklama";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(638, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sektör";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // frmSektor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 365);
            this.Controls.Add(this.panelSektor);
            this.Name = "frmSektor";
            this.Text = "Sektör Kodları";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rtxteAd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSektor)).EndInit();
            this.panelSektor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSektor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteAciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxteAd;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.PanelControl panelSektor;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridSektor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Ad;
        private DevExpress.XtraGrid.Columns.GridColumn Aciklama;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxteAciklama;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
    }
}