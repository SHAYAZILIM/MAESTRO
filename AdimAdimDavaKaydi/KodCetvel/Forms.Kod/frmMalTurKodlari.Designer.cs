namespace  AnaForm
{
    partial class frmMalTurKodlari
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
            this.panelMalTurKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridMalTurKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KATEGORI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueMalKat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.KOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit28 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit29 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.HACIZ_EDILEMEZLIK_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit30 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rCb_MalKategori = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelMalTurKodlar)).BeginInit();
            this.panelMalTurKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMalTurKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMalKat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_MalKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMalTurKodlar
            // 
            this.panelMalTurKodlar.Controls.Add(this.gridMalTurKodlar);
            this.panelMalTurKodlar.Controls.Add(this.panelControl1);
            this.panelMalTurKodlar.Controls.Add(this.panelControl2);
            this.panelMalTurKodlar.Location = new System.Drawing.Point(12, 12);
            this.panelMalTurKodlar.Name = "panelMalTurKodlar";
            this.panelMalTurKodlar.Size = new System.Drawing.Size(740, 368);
            this.panelMalTurKodlar.TabIndex = 26;
            // 
            // gridMalTurKodlar
            // 
            this.gridMalTurKodlar.CustomButtonlarGorunmesin = false;
            this.gridMalTurKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMalTurKodlar.DoNotExtendEmbedNavigator = false;
            this.gridMalTurKodlar.FilterText = null;
            this.gridMalTurKodlar.FilterValue = null;
            this.gridMalTurKodlar.GridlerDuzenlenebilir = true;
            this.gridMalTurKodlar.GridsFilterControl = null;
            this.gridMalTurKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridMalTurKodlar.MainView = this.gridView1;
            this.gridMalTurKodlar.MyGridStyle = null;
            this.gridMalTurKodlar.Name = "gridMalTurKodlar";
            this.gridMalTurKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit28,
            this.repositoryItemTextEdit29,
            this.repositoryItemTextEdit30,
            this.rCb_MalKategori,
            this.rLueMalKat});
            this.gridMalTurKodlar.ShowRowNumbers = false;
            this.gridMalTurKodlar.SilmeKaldirilsin = false;
            this.gridMalTurKodlar.Size = new System.Drawing.Size(736, 294);
            this.gridMalTurKodlar.TabIndex = 5;
            this.gridMalTurKodlar.TemizleKaldirGorunsunmu = false;
            this.gridMalTurKodlar.UniqueId = "18390a84-e9cf-48d3-b08c-bdb255a9d7c1";
            this.gridMalTurKodlar.UseEmbeddedNavigator = true;
            this.gridMalTurKodlar.UseHyperDragDrop = false;
            this.gridMalTurKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KATEGORI,
            this.KOD,
            this.TUR,
            this.HACIZ_EDILEMEZLIK_KODU});
            this.gridView1.GridControl = this.gridMalTurKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Mal Türü Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // KATEGORI
            // 
            this.KATEGORI.Caption = "Mal Tür Kategorisi";
            this.KATEGORI.ColumnEdit = this.rLueMalKat;
            this.KATEGORI.FieldName = "KATEGORI_ID";
            this.KATEGORI.Name = "KATEGORI";
            this.KATEGORI.Visible = true;
            this.KATEGORI.VisibleIndex = 0;
            // 
            // rLueMalKat
            // 
            this.rLueMalKat.AutoHeight = false;
            this.rLueMalKat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMalKat.Name = "rLueMalKat";
            // 
            // KOD
            // 
            this.KOD.Caption = "Mal Tür Kodu";
            this.KOD.ColumnEdit = this.repositoryItemTextEdit28;
            this.KOD.FieldName = "KOD";
            this.KOD.Name = "KOD";
            this.KOD.Visible = true;
            this.KOD.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit28
            // 
            this.repositoryItemTextEdit28.AutoHeight = false;
            this.repositoryItemTextEdit28.Name = "repositoryItemTextEdit28";
            // 
            // TUR
            // 
            this.TUR.Caption = "Mal Türü";
            this.TUR.ColumnEdit = this.repositoryItemTextEdit29;
            this.TUR.FieldName = "TUR";
            this.TUR.Name = "TUR";
            this.TUR.Visible = true;
            this.TUR.VisibleIndex = 2;
            // 
            // repositoryItemTextEdit29
            // 
            this.repositoryItemTextEdit29.AutoHeight = false;
            this.repositoryItemTextEdit29.Name = "repositoryItemTextEdit29";
            // 
            // HACIZ_EDILEMEZLIK_KODU
            // 
            this.HACIZ_EDILEMEZLIK_KODU.Caption = "Haciz Edilmezlik Kodu";
            this.HACIZ_EDILEMEZLIK_KODU.ColumnEdit = this.repositoryItemTextEdit30;
            this.HACIZ_EDILEMEZLIK_KODU.FieldName = "HACIZ_EDILEMEZLIK_KODU";
            this.HACIZ_EDILEMEZLIK_KODU.Name = "HACIZ_EDILEMEZLIK_KODU";
            this.HACIZ_EDILEMEZLIK_KODU.Visible = true;
            this.HACIZ_EDILEMEZLIK_KODU.VisibleIndex = 3;
            // 
            // repositoryItemTextEdit30
            // 
            this.repositoryItemTextEdit30.AutoHeight = false;
            this.repositoryItemTextEdit30.Name = "repositoryItemTextEdit30";
            // 
            // rCb_MalKategori
            // 
            this.rCb_MalKategori.AutoHeight = false;
            this.rCb_MalKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_MalKategori.Name = "rCb_MalKategori";
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
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mal Tür Kodlarý";
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
            this.simpleButton1.Location = new System.Drawing.Point(37, 6);
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
            this.gridControlExtender1.GridControl = this.gridMalTurKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(442, 385);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 27;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmMalTurKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 449);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelMalTurKodlar);
            this.Name = "frmMalTurKodlari";
            this.Text = "Mal Tür Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelMalTurKodlar)).EndInit();
            this.panelMalTurKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMalTurKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMalKat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_MalKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelMalTurKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridMalTurKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn KATEGORI;
        private DevExpress.XtraGrid.Columns.GridColumn KOD;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit28;
        private DevExpress.XtraGrid.Columns.GridColumn TUR;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit29;
        private DevExpress.XtraGrid.Columns.GridColumn HACIZ_EDILEMEZLIK_KODU;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit30;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_MalKategori;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMalKat;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}