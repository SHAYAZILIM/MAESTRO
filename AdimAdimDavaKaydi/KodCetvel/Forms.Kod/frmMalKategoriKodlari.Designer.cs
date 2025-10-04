namespace  AnaForm
{
    partial class frmMalKategoriKodlari
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
            this.panelMalKategoriKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridMalKategoriKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit26 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.KATEGORI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBox10 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelMalKategoriKodlar)).BeginInit();
            this.panelMalKategoriKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMalKategoriKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMalKategoriKodlar
            // 
            this.panelMalKategoriKodlar.Controls.Add(this.gridMalKategoriKodlar);
            this.panelMalKategoriKodlar.Controls.Add(this.panelControl1);
            this.panelMalKategoriKodlar.Controls.Add(this.panelControl2);
            this.panelMalKategoriKodlar.Location = new System.Drawing.Point(12, 12);
            this.panelMalKategoriKodlar.Name = "panelMalKategoriKodlar";
            this.panelMalKategoriKodlar.Size = new System.Drawing.Size(740, 368);
            this.panelMalKategoriKodlar.TabIndex = 25;
            // 
            // gridMalKategoriKodlar
            // 
            this.gridMalKategoriKodlar.CustomButtonlarGorunmesin = false;
            this.gridMalKategoriKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMalKategoriKodlar.DoNotExtendEmbedNavigator = false;
            this.gridMalKategoriKodlar.FilterText = null;
            this.gridMalKategoriKodlar.FilterValue = null;
            this.gridMalKategoriKodlar.GridlerDuzenlenebilir = true;
            this.gridMalKategoriKodlar.GridsFilterControl = null;
            this.gridMalKategoriKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridMalKategoriKodlar.MainView = this.gridView1;
            this.gridMalKategoriKodlar.MyGridStyle = null;
            this.gridMalKategoriKodlar.Name = "gridMalKategoriKodlar";
            this.gridMalKategoriKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit26,
            this.repositoryItemComboBox10,
            this.repositoryItemTextEdit1});
            this.gridMalKategoriKodlar.ShowRowNumbers = false;
            this.gridMalKategoriKodlar.Size = new System.Drawing.Size(736, 294);
            this.gridMalKategoriKodlar.TabIndex = 5;
            this.gridMalKategoriKodlar.TemizleKaldirGorunsunmu = false;
            this.gridMalKategoriKodlar.UniqueId = "91c9b715-3a11-442a-a6f3-efe6a2f2814c";
            this.gridMalKategoriKodlar.UseEmbeddedNavigator = true;
            this.gridMalKategoriKodlar.UseHyperDragDrop = false;
            this.gridMalKategoriKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KOD,
            this.KATEGORI});
            this.gridView1.GridControl = this.gridMalKategoriKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Mal Kategorileri Ekleyin";
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
            this.KOD.Caption = "Mal Kategori Kodlar";
            this.KOD.ColumnEdit = this.repositoryItemTextEdit26;
            this.KOD.FieldName = "KOD";
            this.KOD.Name = "KOD";
            this.KOD.Visible = true;
            this.KOD.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit26
            // 
            this.repositoryItemTextEdit26.AutoHeight = false;
            this.repositoryItemTextEdit26.Name = "repositoryItemTextEdit26";
            // 
            // KATEGORI
            // 
            this.KATEGORI.Caption = "Mal Kategori";
            this.KATEGORI.ColumnEdit = this.repositoryItemTextEdit1;
            this.KATEGORI.FieldName = "KATEGORI";
            this.KATEGORI.Name = "KATEGORI";
            this.KATEGORI.Visible = true;
            this.KATEGORI.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemComboBox10
            // 
            this.repositoryItemComboBox10.AutoHeight = false;
            this.repositoryItemComboBox10.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox10.Name = "repositoryItemComboBox10";
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
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mal Kategori Kodlarý";
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
            this.simpleButton1.Location = new System.Drawing.Point(44, 6);
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
            this.gridControlExtender1.GridControl = this.gridMalKategoriKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(535, 387);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 26;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmMalKategoriKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 458);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelMalKategoriKodlar);
            this.Name = "frmMalKategoriKodlari";
            this.Text = "Mal Kategori Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelMalKategoriKodlar)).EndInit();
            this.panelMalKategoriKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMalKategoriKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelMalKategoriKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridMalKategoriKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn KOD;
        private DevExpress.XtraGrid.Columns.GridColumn KATEGORI;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit26;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox10;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}