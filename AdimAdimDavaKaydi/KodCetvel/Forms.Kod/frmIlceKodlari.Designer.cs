namespace  AnaForm
{
    partial class frmIlceKodlari
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
            this.panelIlceKodlari = new DevExpress.XtraEditors.PanelControl();
            this.gridIlceKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueIlGetir = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ILCE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_Ilce = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.KOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit27 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rCb_Il = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelIlceKodlari)).BeginInit();
            this.panelIlceKodlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIlceKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIlGetir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Ilce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Il)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelIlceKodlari
            // 
            this.panelIlceKodlari.Controls.Add(this.gridIlceKodlar);
            this.panelIlceKodlari.Controls.Add(this.panelControl1);
            this.panelIlceKodlari.Controls.Add(this.panelControl2);
            this.panelIlceKodlari.Location = new System.Drawing.Point(9, 41);
            this.panelIlceKodlari.Name = "panelIlceKodlari";
            this.panelIlceKodlari.Size = new System.Drawing.Size(750, 360);
            this.panelIlceKodlari.TabIndex = 21;
            // 
            // gridIlceKodlar
            // 
            this.gridIlceKodlar.CustomButtonlarGorunmesin = false;
            this.gridIlceKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridIlceKodlar.DoNotExtendEmbedNavigator = false;
            this.gridIlceKodlar.FilterText = null;
            this.gridIlceKodlar.FilterValue = null;
            this.gridIlceKodlar.GridlerDuzenlenebilir = true;
            this.gridIlceKodlar.GridsFilterControl = null;
            this.gridIlceKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridIlceKodlar.MainView = this.gridView1;
            this.gridIlceKodlar.MyGridStyle = null;
            this.gridIlceKodlar.Name = "gridIlceKodlar";
            this.gridIlceKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rCb_Il,
            this.rCb_Ilce,
            this.repositoryItemTextEdit27,
            this.repositoryItemMemoExEdit1,
            this.rLueIlGetir});
            this.gridIlceKodlar.ShowRowNumbers = false;
            this.gridIlceKodlar.SilmeKaldirilsin = false;
            this.gridIlceKodlar.Size = new System.Drawing.Size(746, 286);
            this.gridIlceKodlar.TabIndex = 5;
            this.gridIlceKodlar.TemizleKaldirGorunsunmu = false;
            this.gridIlceKodlar.UniqueId = "e912ad5e-6792-4fb7-b11e-3cc0b9fbbd27";
            this.gridIlceKodlar.UseEmbeddedNavigator = true;
            this.gridIlceKodlar.UseHyperDragDrop = false;
            this.gridIlceKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IL,
            this.ILCE,
            this.KOD});
            this.gridView1.GridControl = this.gridIlceKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Kayýt Eklemek için Týklayýn";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // IL
            // 
            this.IL.Caption = "Ýli";
            this.IL.ColumnEdit = this.rLueIlGetir;
            this.IL.FieldName = "IL_ID";
            this.IL.Name = "IL";
            this.IL.Visible = true;
            this.IL.VisibleIndex = 0;
            // 
            // rLueIlGetir
            // 
            this.rLueIlGetir.AutoHeight = false;
            this.rLueIlGetir.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueIlGetir.Name = "rLueIlGetir";
            // 
            // ILCE
            // 
            this.ILCE.Caption = "Ýlçe";
            this.ILCE.ColumnEdit = this.rCb_Ilce;
            this.ILCE.FieldName = "ILCE";
            this.ILCE.Name = "ILCE";
            this.ILCE.Visible = true;
            this.ILCE.VisibleIndex = 1;
            // 
            // rCb_Ilce
            // 
            this.rCb_Ilce.AutoHeight = false;
            this.rCb_Ilce.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_Ilce.Name = "rCb_Ilce";
            // 
            // KOD
            // 
            this.KOD.Caption = "Ýlçe Kodu";
            this.KOD.ColumnEdit = this.repositoryItemTextEdit27;
            this.KOD.FieldName = "KOD";
            this.KOD.Name = "KOD";
            this.KOD.Visible = true;
            this.KOD.VisibleIndex = 2;
            // 
            // repositoryItemTextEdit27
            // 
            this.repositoryItemTextEdit27.AutoHeight = false;
            this.repositoryItemTextEdit27.Name = "repositoryItemTextEdit27";
            // 
            // rCb_Il
            // 
            this.rCb_Il.AutoHeight = false;
            this.rCb_Il.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_Il.Name = "rCb_Il";
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
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
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ýlçe Kodlarý";
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
            this.simpleButton1.Location = new System.Drawing.Point(32, 6);
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
            this.gridControlExtender1.GridControl = this.gridIlceKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(425, 406);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 22;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmIlceKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 442);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelIlceKodlari);
            this.Name = "frmIlceKodlari";
            this.Text = "Ýlçe Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelIlceKodlari)).EndInit();
            this.panelIlceKodlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridIlceKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIlGetir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Ilce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Il)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelIlceKodlari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridIlceKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn IL;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_Il;
        private DevExpress.XtraGrid.Columns.GridColumn ILCE;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_Ilce;
        private DevExpress.XtraGrid.Columns.GridColumn KOD;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit27;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueIlGetir;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}