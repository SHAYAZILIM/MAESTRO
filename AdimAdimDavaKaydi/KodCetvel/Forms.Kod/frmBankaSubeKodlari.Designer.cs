namespace  AnaForm
{
    partial class frmBankaSubeKodlari
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
            this.panelBankaSubeKodlari = new DevExpress.XtraEditors.PanelControl();
            this.gridBankaSubeKodlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BANKA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBanka = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.BOLGE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBolge = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit43 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.SUBE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit42 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelBankaSubeKodlari)).BeginInit();
            this.panelBankaSubeKodlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBankaSubeKodlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBanka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBolge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBankaSubeKodlari
            // 
            this.panelBankaSubeKodlari.Controls.Add(this.gridBankaSubeKodlari);
            this.panelBankaSubeKodlari.Controls.Add(this.panelControl1);
            this.panelBankaSubeKodlari.Controls.Add(this.panelControl2);
            this.panelBankaSubeKodlari.Location = new System.Drawing.Point(12, 12);
            this.panelBankaSubeKodlari.Name = "panelBankaSubeKodlari";
            this.panelBankaSubeKodlari.Size = new System.Drawing.Size(750, 360);
            this.panelBankaSubeKodlari.TabIndex = 31;
            // 
            // gridBankaSubeKodlari
            // 
            this.gridBankaSubeKodlari.CustomButtonlarGorunmesin = false;
            this.gridBankaSubeKodlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBankaSubeKodlari.DoNotExtendEmbedNavigator = false;
            this.gridBankaSubeKodlari.FilterText = null;
            this.gridBankaSubeKodlari.FilterValue = null;
            this.gridBankaSubeKodlari.GridlerDuzenlenebilir = true;
            this.gridBankaSubeKodlari.GridsFilterControl = null;
            this.gridBankaSubeKodlari.Location = new System.Drawing.Point(2, 72);
            this.gridBankaSubeKodlari.MainView = this.gridView1;
            this.gridBankaSubeKodlari.MyGridStyle = null;
            this.gridBankaSubeKodlari.Name = "gridBankaSubeKodlari";
            this.gridBankaSubeKodlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit3,
            this.repositoryItemTextEdit42,
            this.repositoryItemTextEdit43,
            this.rLueBanka,
            this.rLueBolge});
            this.gridBankaSubeKodlari.ShowRowNumbers = false;
            this.gridBankaSubeKodlari.Size = new System.Drawing.Size(746, 286);
            this.gridBankaSubeKodlari.TabIndex = 5;
            this.gridBankaSubeKodlari.TemizleKaldirGorunsunmu = false;
            this.gridBankaSubeKodlari.UniqueId = "b4eb4fbc-5bab-468c-90ec-3f159ddac587";
            this.gridBankaSubeKodlari.UseEmbeddedNavigator = true;
            this.gridBankaSubeKodlari.UseHyperDragDrop = false;
            this.gridBankaSubeKodlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BANKA,
            this.BOLGE,
            this.KODU,
            this.SUBE,
            this.ACIKLAMA});
            this.gridView1.GridControl = this.gridBankaSubeKodlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Banka Þubesi Ekleyin";
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
            this.BANKA.Caption = "Banka";
            this.BANKA.ColumnEdit = this.rLueBanka;
            this.BANKA.FieldName = "BANKA_ID";
            this.BANKA.Name = "BANKA";
            this.BANKA.Visible = true;
            this.BANKA.VisibleIndex = 0;
            // 
            // rLueBanka
            // 
            this.rLueBanka.AutoHeight = false;
            this.rLueBanka.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBanka.Name = "rLueBanka";
            // 
            // BOLGE
            // 
            this.BOLGE.Caption = "Bölge";
            this.BOLGE.ColumnEdit = this.rLueBolge;
            this.BOLGE.FieldName = "BOLGE_ID";
            this.BOLGE.Name = "BOLGE";
            this.BOLGE.Visible = true;
            this.BOLGE.VisibleIndex = 1;
            // 
            // rLueBolge
            // 
            this.rLueBolge.AutoHeight = false;
            this.rLueBolge.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBolge.Name = "rLueBolge";
            // 
            // KODU
            // 
            this.KODU.Caption = "Bölge Kodu";
            this.KODU.ColumnEdit = this.repositoryItemTextEdit43;
            this.KODU.FieldName = "KODU";
            this.KODU.Name = "KODU";
            this.KODU.Visible = true;
            this.KODU.VisibleIndex = 2;
            // 
            // repositoryItemTextEdit43
            // 
            this.repositoryItemTextEdit43.AutoHeight = false;
            this.repositoryItemTextEdit43.Name = "repositoryItemTextEdit43";
            // 
            // SUBE
            // 
            this.SUBE.Caption = "Banka Þubesi";
            this.SUBE.ColumnEdit = this.repositoryItemTextEdit42;
            this.SUBE.FieldName = "SUBE";
            this.SUBE.Name = "SUBE";
            this.SUBE.Visible = true;
            this.SUBE.VisibleIndex = 3;
            // 
            // repositoryItemTextEdit42
            // 
            this.repositoryItemTextEdit42.AutoHeight = false;
            this.repositoryItemTextEdit42.Name = "repositoryItemTextEdit42";
            // 
            // ACIKLAMA
            // 
            this.ACIKLAMA.Caption = "Açýklama";
            this.ACIKLAMA.ColumnEdit = this.repositoryItemMemoExEdit3;
            this.ACIKLAMA.FieldName = "ACIKLAMA";
            this.ACIKLAMA.Name = "ACIKLAMA";
            this.ACIKLAMA.Visible = true;
            this.ACIKLAMA.VisibleIndex = 4;
            // 
            // repositoryItemMemoExEdit3
            // 
            this.repositoryItemMemoExEdit3.AutoHeight = false;
            this.repositoryItemMemoExEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit3.Name = "repositoryItemMemoExEdit3";
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
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Banka Þube Kodlarý";
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
            this.simpleButton1.Location = new System.Drawing.Point(29, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(88, 22);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmBankaSubeKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 459);
            this.Controls.Add(this.panelBankaSubeKodlari);
            this.Name = "frmBankaSubeKodlari";
            this.Text = "Banka Þube Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelBankaSubeKodlari)).EndInit();
            this.panelBankaSubeKodlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBankaSubeKodlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBanka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBolge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelBankaSubeKodlari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridBankaSubeKodlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn BANKA;
        private DevExpress.XtraGrid.Columns.GridColumn BOLGE;
        private DevExpress.XtraGrid.Columns.GridColumn KODU;
        private DevExpress.XtraGrid.Columns.GridColumn SUBE;
        private DevExpress.XtraGrid.Columns.GridColumn ACIKLAMA;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit42;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit43;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBanka;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBolge;
        //private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
    }
}