namespace  AnaForm
{
    partial class frmIletisimAltKategoriEkle
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
            this.panelIletisimAltKategori = new DevExpress.XtraEditors.PanelControl();
            this.gridIletisimAltKategori = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ANA_KATEGORI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueIletisimAnaKat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ALT_KATEGORI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit26 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rCb_AnaKategori = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelIletisimAltKategori)).BeginInit();
            this.panelIletisimAltKategori.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIletisimAltKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIletisimAnaKat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AnaKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelIletisimAltKategori
            // 
            this.panelIletisimAltKategori.Controls.Add(this.gridIletisimAltKategori);
            this.panelIletisimAltKategori.Controls.Add(this.panelControl1);
            this.panelIletisimAltKategori.Controls.Add(this.panelControl2);
            this.panelIletisimAltKategori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIletisimAltKategori.Location = new System.Drawing.Point(0, 0);
            this.panelIletisimAltKategori.Name = "panelIletisimAltKategori";
            this.panelIletisimAltKategori.Size = new System.Drawing.Size(570, 460);
            this.panelIletisimAltKategori.TabIndex = 19;
            // 
            // gridIletisimAltKategori
            // 
            this.gridIletisimAltKategori.CustomButtonlarGorunmesin = false;
            this.gridIletisimAltKategori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridIletisimAltKategori.DoNotExtendEmbedNavigator = false;
            this.gridIletisimAltKategori.FilterText = null;
            this.gridIletisimAltKategori.FilterValue = null;
            this.gridIletisimAltKategori.GridlerDuzenlenebilir = true;
            this.gridIletisimAltKategori.GridsFilterControl = null;
            this.gridIletisimAltKategori.Location = new System.Drawing.Point(2, 72);
            this.gridIletisimAltKategori.MainView = this.gridView1;
            this.gridIletisimAltKategori.MyGridStyle = null;
            this.gridIletisimAltKategori.Name = "gridIletisimAltKategori";
            this.gridIletisimAltKategori.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rCb_AnaKategori,
            this.repositoryItemTextEdit26,
            this.rLueIletisimAnaKat});
            this.gridIletisimAltKategori.ShowRowNumbers = false;
            this.gridIletisimAltKategori.SilmeKaldirilsin = false;
            this.gridIletisimAltKategori.Size = new System.Drawing.Size(566, 386);
            this.gridIletisimAltKategori.TabIndex = 5;
            this.gridIletisimAltKategori.TemizleKaldirGorunsunmu = false;
            this.gridIletisimAltKategori.UniqueId = "99333243-d6b3-49c1-b0da-ae739da8905a";
            this.gridIletisimAltKategori.UseEmbeddedNavigator = true;
            this.gridIletisimAltKategori.UseHyperDragDrop = false;
            this.gridIletisimAltKategori.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ANA_KATEGORI,
            this.ALT_KATEGORI});
            this.gridView1.GridControl = this.gridIletisimAltKategori;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Ýletiþim Alt Kategori Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ANA_KATEGORI
            // 
            this.ANA_KATEGORI.Caption = "Ýletiþim Ana Kategori";
            this.ANA_KATEGORI.ColumnEdit = this.rLueIletisimAnaKat;
            this.ANA_KATEGORI.FieldName = "ANA_KATEGORI_ID";
            this.ANA_KATEGORI.Name = "ANA_KATEGORI";
            this.ANA_KATEGORI.Visible = true;
            this.ANA_KATEGORI.VisibleIndex = 0;
            // 
            // rLueIletisimAnaKat
            // 
            this.rLueIletisimAnaKat.AutoHeight = false;
            this.rLueIletisimAnaKat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueIletisimAnaKat.Name = "rLueIletisimAnaKat";
            // 
            // ALT_KATEGORI
            // 
            this.ALT_KATEGORI.Caption = "Ýletiþim Alt Kategori";
            this.ALT_KATEGORI.ColumnEdit = this.repositoryItemTextEdit26;
            this.ALT_KATEGORI.Name = "ALT_KATEGORI";
            this.ALT_KATEGORI.Visible = true;
            this.ALT_KATEGORI.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit26
            // 
            this.repositoryItemTextEdit26.AutoHeight = false;
            this.repositoryItemTextEdit26.Name = "repositoryItemTextEdit26";
            // 
            // rCb_AnaKategori
            // 
            this.rCb_AnaKategori.AutoHeight = false;
            this.rCb_AnaKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_AnaKategori.Name = "rCb_AnaKategori";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(566, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ýletiþim Alt Kategori Ekle";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(566, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(29, 10);
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
            this.gridControlExtender1.GridControl = this.gridIletisimAltKategori;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(442, 393);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 20;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmIletisimAltKategoriEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 460);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelIletisimAltKategori);
            this.Name = "frmIletisimAltKategoriEkle";
            this.Text = "Ýletiþim Alt Kategori";
            ((System.ComponentModel.ISupportInitialize)(this.panelIletisimAltKategori)).EndInit();
            this.panelIletisimAltKategori.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridIletisimAltKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIletisimAnaKat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AnaKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelIletisimAltKategori;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridIletisimAltKategori;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn ANA_KATEGORI;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_AnaKategori;
        private DevExpress.XtraGrid.Columns.GridColumn ALT_KATEGORI;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit26;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueIletisimAnaKat;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}