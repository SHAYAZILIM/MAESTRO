namespace  AnaForm
{
    partial class frmMahkemeAdlari
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
            this.panelMahkemeAdlari = new DevExpress.XtraEditors.PanelControl();
            this.gridMahkemeAdlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ADLI_BIRIM_BOLUM_KOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdliBirimBolum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.GOREV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit27 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.MAHKEME_GRUP_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit29 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.VEKALET_UCR_GRUP_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit30 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rCb_AdliBirimBolumKOD = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelMahkemeAdlari)).BeginInit();
            this.panelMahkemeAdlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMahkemeAdlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimBolum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AdliBirimBolumKOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMahkemeAdlari
            // 
            this.panelMahkemeAdlari.Controls.Add(this.gridMahkemeAdlari);
            this.panelMahkemeAdlari.Controls.Add(this.panelControl1);
            this.panelMahkemeAdlari.Controls.Add(this.panelControl2);
            this.panelMahkemeAdlari.Location = new System.Drawing.Point(12, 12);
            this.panelMahkemeAdlari.Name = "panelMahkemeAdlari";
            this.panelMahkemeAdlari.Size = new System.Drawing.Size(740, 368);
            this.panelMahkemeAdlari.TabIndex = 27;
            // 
            // gridMahkemeAdlari
            // 
            this.gridMahkemeAdlari.CustomButtonlarGorunmesin = false;
            this.gridMahkemeAdlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMahkemeAdlari.DoNotExtendEmbedNavigator = false;
            this.gridMahkemeAdlari.FilterText = null;
            this.gridMahkemeAdlari.FilterValue = null;
            this.gridMahkemeAdlari.GridlerDuzenlenebilir = true;
            this.gridMahkemeAdlari.GridsFilterControl = null;
            this.gridMahkemeAdlari.Location = new System.Drawing.Point(2, 72);
            this.gridMahkemeAdlari.MainView = this.gridView1;
            this.gridMahkemeAdlari.MyGridStyle = null;
            this.gridMahkemeAdlari.Name = "gridMahkemeAdlari";
            this.gridMahkemeAdlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit27,
            this.repositoryItemMemoExEdit4,
            this.repositoryItemTextEdit29,
            this.repositoryItemTextEdit30,
            this.rCb_AdliBirimBolumKOD,
            this.rLueAdliBirimBolum});
            this.gridMahkemeAdlari.ShowRowNumbers = false;
            this.gridMahkemeAdlari.Size = new System.Drawing.Size(736, 294);
            this.gridMahkemeAdlari.TabIndex = 5;
            this.gridMahkemeAdlari.TemizleKaldirGorunsunmu = false;
            this.gridMahkemeAdlari.UniqueId = "37fb2853-3827-41cf-a36b-a49654711d92";
            this.gridMahkemeAdlari.UseEmbeddedNavigator = true;
            this.gridMahkemeAdlari.UseHyperDragDrop = false;
            this.gridMahkemeAdlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ADLI_BIRIM_BOLUM_KOD,
            this.GOREV,
            this.ACIKLAMA,
            this.MAHKEME_GRUP_KODU,
            this.VEKALET_UCR_GRUP_KODU});
            this.gridView1.GridControl = this.gridMahkemeAdlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Mahkeme Adý Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ADLI_BIRIM_BOLUM_KOD
            // 
            this.ADLI_BIRIM_BOLUM_KOD.Caption = "Adli Birim Bölüm Kod No";
            this.ADLI_BIRIM_BOLUM_KOD.ColumnEdit = this.rLueAdliBirimBolum;
            this.ADLI_BIRIM_BOLUM_KOD.FieldName = "ADLI_BIRIM_BOLUM_ID";
            this.ADLI_BIRIM_BOLUM_KOD.Name = "ADLI_BIRIM_BOLUM_KOD";
            this.ADLI_BIRIM_BOLUM_KOD.Visible = true;
            this.ADLI_BIRIM_BOLUM_KOD.VisibleIndex = 0;
            // 
            // rLueAdliBirimBolum
            // 
            this.rLueAdliBirimBolum.AutoHeight = false;
            this.rLueAdliBirimBolum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimBolum.Name = "rLueAdliBirimBolum";
            // 
            // GOREV
            // 
            this.GOREV.Caption = "Görev";
            this.GOREV.ColumnEdit = this.repositoryItemTextEdit27;
            this.GOREV.FieldName = "GOREV";
            this.GOREV.Name = "GOREV";
            this.GOREV.Visible = true;
            this.GOREV.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit27
            // 
            this.repositoryItemTextEdit27.AutoHeight = false;
            this.repositoryItemTextEdit27.Name = "repositoryItemTextEdit27";
            // 
            // ACIKLAMA
            // 
            this.ACIKLAMA.Caption = "Açýklama";
            this.ACIKLAMA.ColumnEdit = this.repositoryItemMemoExEdit4;
            this.ACIKLAMA.FieldName = "ACIKLAMA";
            this.ACIKLAMA.Name = "ACIKLAMA";
            this.ACIKLAMA.Visible = true;
            this.ACIKLAMA.VisibleIndex = 2;
            // 
            // repositoryItemMemoExEdit4
            // 
            this.repositoryItemMemoExEdit4.AutoHeight = false;
            this.repositoryItemMemoExEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit4.Name = "repositoryItemMemoExEdit4";
            // 
            // MAHKEME_GRUP_KODU
            // 
            this.MAHKEME_GRUP_KODU.Caption = "Mahkeme Grup Kodu";
            this.MAHKEME_GRUP_KODU.ColumnEdit = this.repositoryItemTextEdit29;
            this.MAHKEME_GRUP_KODU.FieldName = "MAHKEME_GRUP_KODU";
            this.MAHKEME_GRUP_KODU.Name = "MAHKEME_GRUP_KODU";
            this.MAHKEME_GRUP_KODU.Visible = true;
            this.MAHKEME_GRUP_KODU.VisibleIndex = 3;
            // 
            // repositoryItemTextEdit29
            // 
            this.repositoryItemTextEdit29.AutoHeight = false;
            this.repositoryItemTextEdit29.Name = "repositoryItemTextEdit29";
            // 
            // VEKALET_UCR_GRUP_KODU
            // 
            this.VEKALET_UCR_GRUP_KODU.Caption = "Vekalet Ucret Grup Kodu";
            this.VEKALET_UCR_GRUP_KODU.ColumnEdit = this.repositoryItemTextEdit30;
            this.VEKALET_UCR_GRUP_KODU.FieldName = "VEKALET_UCR_GRUP_KODU";
            this.VEKALET_UCR_GRUP_KODU.Name = "VEKALET_UCR_GRUP_KODU";
            this.VEKALET_UCR_GRUP_KODU.Visible = true;
            this.VEKALET_UCR_GRUP_KODU.VisibleIndex = 4;
            // 
            // repositoryItemTextEdit30
            // 
            this.repositoryItemTextEdit30.AutoHeight = false;
            this.repositoryItemTextEdit30.Name = "repositoryItemTextEdit30";
            // 
            // rCb_AdliBirimBolumKOD
            // 
            this.rCb_AdliBirimBolumKOD.AutoHeight = false;
            this.rCb_AdliBirimBolumKOD.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_AdliBirimBolumKOD.Name = "rCb_AdliBirimBolumKOD";
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
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mahkeme Adlarý";
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
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridMahkemeAdlari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(475, 385);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 28;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(34, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmMahkemeAdlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 419);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelMahkemeAdlari);
            this.Name = "frmMahkemeAdlari";
            this.Text = "Mahkeme Adlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelMahkemeAdlari)).EndInit();
            this.panelMahkemeAdlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMahkemeAdlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimBolum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AdliBirimBolumKOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelMahkemeAdlari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridMahkemeAdlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn ADLI_BIRIM_BOLUM_KOD;
        private DevExpress.XtraGrid.Columns.GridColumn GOREV;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit27;
        private DevExpress.XtraGrid.Columns.GridColumn ACIKLAMA;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit4;
        private DevExpress.XtraGrid.Columns.GridColumn MAHKEME_GRUP_KODU;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit29;
        private DevExpress.XtraGrid.Columns.GridColumn VEKALET_UCR_GRUP_KODU;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit30;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_AdliBirimBolumKOD;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimBolum;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}