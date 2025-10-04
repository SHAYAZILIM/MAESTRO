namespace  AnaForm
{
    partial class frmKlasorKodlari
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
            this.panelKlosorKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridKlosorKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit30 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelKlosorKodlar)).BeginInit();
            this.panelKlosorKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKlosorKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelKlosorKodlar
            // 
            this.panelKlosorKodlar.Controls.Add(this.gridKlosorKodlar);
            this.panelKlosorKodlar.Controls.Add(this.panelControl1);
            this.panelKlosorKodlar.Controls.Add(this.panelControl2);
            this.panelKlosorKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKlosorKodlar.Location = new System.Drawing.Point(0, 0);
            this.panelKlosorKodlar.Name = "panelKlosorKodlar";
            this.panelKlosorKodlar.Size = new System.Drawing.Size(580, 404);
            this.panelKlosorKodlar.TabIndex = 25;
            // 
            // gridKlosorKodlar
            // 
            this.gridKlosorKodlar.CustomButtonlarGorunmesin = false;
            this.gridKlosorKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridKlosorKodlar.DoNotExtendEmbedNavigator = false;
            this.gridKlosorKodlar.FilterText = null;
            this.gridKlosorKodlar.FilterValue = null;
            this.gridKlosorKodlar.GridlerDuzenlenebilir = true;
            this.gridKlosorKodlar.GridsFilterControl = null;
            this.gridKlosorKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridKlosorKodlar.MainView = this.gridView1;
            this.gridKlosorKodlar.MyGridStyle = null;
            this.gridKlosorKodlar.Name = "gridKlosorKodlar";
            this.gridKlosorKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit30,
            this.repositoryItemMemoExEdit3});
            this.gridKlosorKodlar.ShowRowNumbers = false;
            this.gridKlosorKodlar.SilmeKaldirilsin = false;
            this.gridKlosorKodlar.Size = new System.Drawing.Size(576, 330);
            this.gridKlosorKodlar.TabIndex = 5;
            this.gridKlosorKodlar.TemizleKaldirGorunsunmu = false;
            this.gridKlosorKodlar.UniqueId = "045d0534-2388-4a9e-a917-e1824312a592";
            this.gridKlosorKodlar.UseEmbeddedNavigator = true;
            this.gridKlosorKodlar.UseHyperDragDrop = false;
            this.gridKlosorKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KOD,
            this.ACIKLAMA});
            this.gridView1.GridControl = this.gridKlosorKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Kloasör Kodu Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // KOD
            // 
            this.KOD.Caption = "Klosör Kodu";
            this.KOD.ColumnEdit = this.repositoryItemTextEdit30;
            this.KOD.FieldName = "KOD";
            this.KOD.Name = "KOD";
            this.KOD.Visible = true;
            this.KOD.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit30
            // 
            this.repositoryItemTextEdit30.AutoHeight = false;
            this.repositoryItemTextEdit30.Name = "repositoryItemTextEdit30";
            // 
            // ACIKLAMA
            // 
            this.ACIKLAMA.Caption = "Açýklama";
            this.ACIKLAMA.ColumnEdit = this.repositoryItemMemoExEdit3;
            this.ACIKLAMA.FieldName = "ACIKLAMA";
            this.ACIKLAMA.Name = "ACIKLAMA";
            this.ACIKLAMA.Visible = true;
            this.ACIKLAMA.VisibleIndex = 1;
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
            this.panelControl1.Size = new System.Drawing.Size(576, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Klasör Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(576, 43);
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
            this.gridControlExtender1.GridControl = this.gridKlosorKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(440, 390);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 26;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmKlasorKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 404);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelKlosorKodlar);
            this.Name = "frmKlasorKodlari";
            this.Text = "Klasör Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelKlosorKodlar)).EndInit();
            this.panelKlosorKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKlosorKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelKlosorKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridKlosorKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn KOD;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit30;
        private DevExpress.XtraGrid.Columns.GridColumn ACIKLAMA;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit3;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}