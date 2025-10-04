namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmSozluk
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.gridSozluk = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Kelime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Anlami = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxteKelime = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rtxteAnlami = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelSozluk = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSozluk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteKelime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteAnlami)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSozluk)).BeginInit();
            this.panelSozluk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(666, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sözlük";
            // 
            // gridSozluk
            // 
            this.gridSozluk.CustomButtonlarGorunmesin = false;
            this.gridSozluk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSozluk.DoNotExtendEmbedNavigator = false;
            this.gridSozluk.FilterText = null;
            this.gridSozluk.FilterValue = null;
            this.gridSozluk.GridlerDuzenlenebilir = true;
            this.gridSozluk.GridsFilterControl = null;
            this.gridSozluk.Location = new System.Drawing.Point(2, 72);
            this.gridSozluk.MainView = this.gridView1;
            this.gridSozluk.MyGridStyle = null;
            this.gridSozluk.Name = "gridSozluk";
            this.gridSozluk.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxteKelime,
            this.rtxteAnlami});
            this.gridSozluk.ShowRowNumbers = false;
            this.gridSozluk.SilmeKaldirilsin = false;
            this.gridSozluk.Size = new System.Drawing.Size(666, 302);
            this.gridSozluk.TabIndex = 5;
            this.gridSozluk.TemizleKaldirGorunsunmu = false;
            this.gridSozluk.UniqueId = "43e93c8b-a2ed-49db-8133-90e8e8b72b35";
            this.gridSozluk.UseEmbeddedNavigator = true;
            this.gridSozluk.UseHyperDragDrop = false;
            this.gridSozluk.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Kelime,
            this.Anlami});
            this.gridView1.GridControl = this.gridSozluk;
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
            // Kelime
            // 
            this.Kelime.Caption = "Kelime";
            this.Kelime.FieldName = "KELIME";
            this.Kelime.Name = "Kelime";
            this.Kelime.Visible = true;
            this.Kelime.VisibleIndex = 0;
            // 
            // Anlami
            // 
            this.Anlami.Caption = "Anlami";
            this.Anlami.FieldName = "ANLAMI";
            this.Anlami.Name = "Anlami";
            this.Anlami.Visible = true;
            this.Anlami.VisibleIndex = 1;
            // 
            // rtxteKelime
            // 
            this.rtxteKelime.AutoHeight = false;
            this.rtxteKelime.Name = "rtxteKelime";
            // 
            // rtxteAnlami
            // 
            this.rtxteAnlami.AutoHeight = false;
            this.rtxteAnlami.Name = "rtxteAnlami";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(32, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(117, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panelSozluk
            // 
            this.panelSozluk.Controls.Add(this.gridSozluk);
            this.panelSozluk.Controls.Add(this.panelControl1);
            this.panelSozluk.Controls.Add(this.panelControl2);
            this.panelSozluk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSozluk.Location = new System.Drawing.Point(0, 0);
            this.panelSozluk.Name = "panelSozluk";
            this.panelSozluk.Size = new System.Drawing.Size(670, 376);
            this.panelSozluk.TabIndex = 20;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(666, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // frmSozluk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 376);
            this.Controls.Add(this.panelSozluk);
            this.Name = "frmSozluk";
            this.Text = "Sözlük";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSozluk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteKelime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteAnlami)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSozluk)).EndInit();
            this.panelSozluk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridSozluk;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxteKelime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxteAnlami;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelSozluk;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn Kelime;
        private DevExpress.XtraGrid.Columns.GridColumn Anlami;
    }
}