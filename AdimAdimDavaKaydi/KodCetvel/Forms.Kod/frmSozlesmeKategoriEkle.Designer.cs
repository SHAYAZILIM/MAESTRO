namespace  AnaForm
{
    partial class frmSozlesmeKategoriEkle
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
            this.panelSozlesmeKategoriEkle = new DevExpress.XtraEditors.PanelControl();
            this.gridSozlesmeKategoriEkle = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit26 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelSozlesmeKategoriEkle)).BeginInit();
            this.panelSozlesmeKategoriEkle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSozlesmeKategoriEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSozlesmeKategoriEkle
            // 
            this.panelSozlesmeKategoriEkle.Controls.Add(this.gridSozlesmeKategoriEkle);
            this.panelSozlesmeKategoriEkle.Controls.Add(this.panelControl1);
            this.panelSozlesmeKategoriEkle.Controls.Add(this.panelControl2);
            this.panelSozlesmeKategoriEkle.Location = new System.Drawing.Point(10, 12);
            this.panelSozlesmeKategoriEkle.Name = "panelSozlesmeKategoriEkle";
            this.panelSozlesmeKategoriEkle.Size = new System.Drawing.Size(750, 360);
            this.panelSozlesmeKategoriEkle.TabIndex = 20;
            // 
            // gridSozlesmeKategoriEkle
            // 
            this.gridSozlesmeKategoriEkle.CustomButtonlarGorunmesin = false;
            this.gridSozlesmeKategoriEkle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSozlesmeKategoriEkle.DoNotExtendEmbedNavigator = false;
            this.gridSozlesmeKategoriEkle.FilterText = null;
            this.gridSozlesmeKategoriEkle.FilterValue = null;
            this.gridSozlesmeKategoriEkle.GridlerDuzenlenebilir = true;
            this.gridSozlesmeKategoriEkle.GridsFilterControl = null;
            this.gridSozlesmeKategoriEkle.Location = new System.Drawing.Point(2, 72);
            this.gridSozlesmeKategoriEkle.MainView = this.gridView1;
            this.gridSozlesmeKategoriEkle.MyGridStyle = null;
            this.gridSozlesmeKategoriEkle.Name = "gridSozlesmeKategoriEkle";
            this.gridSozlesmeKategoriEkle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit26,
            this.repositoryItemMemoExEdit2});
            this.gridSozlesmeKategoriEkle.ShowRowNumbers = false;
            this.gridSozlesmeKategoriEkle.Size = new System.Drawing.Size(746, 286);
            this.gridSozlesmeKategoriEkle.TabIndex = 5;
            this.gridSozlesmeKategoriEkle.TemizleKaldirGorunsunmu = false;
            this.gridSozlesmeKategoriEkle.UniqueId = "ada2b295-f6c1-432f-9f2c-85465c99496a";
            this.gridSozlesmeKategoriEkle.UseEmbeddedNavigator = true;
            this.gridSozlesmeKategoriEkle.UseHyperDragDrop = false;
            this.gridSozlesmeKategoriEkle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AD,
            this.ACIKLAMA});
            this.gridView1.GridControl = this.gridSozlesmeKategoriEkle;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Sözleþme Kategorileri Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // AD
            // 
            this.AD.Caption = "Sözleþme Kategori Adý";
            this.AD.ColumnEdit = this.repositoryItemTextEdit26;
            this.AD.FieldName = "AD";
            this.AD.Name = "AD";
            this.AD.Visible = true;
            this.AD.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit26
            // 
            this.repositoryItemTextEdit26.AutoHeight = false;
            this.repositoryItemTextEdit26.Name = "repositoryItemTextEdit26";
            // 
            // ACIKLAMA
            // 
            this.ACIKLAMA.Caption = "Kategori Açýklama";
            this.ACIKLAMA.ColumnEdit = this.repositoryItemMemoExEdit2;
            this.ACIKLAMA.FieldName = "ACIKLAMA";
            this.ACIKLAMA.Name = "ACIKLAMA";
            this.ACIKLAMA.Visible = true;
            this.ACIKLAMA.VisibleIndex = 1;
            // 
            // repositoryItemMemoExEdit2
            // 
            this.repositoryItemMemoExEdit2.AutoHeight = false;
            this.repositoryItemMemoExEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit2.Name = "repositoryItemMemoExEdit2";
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
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sözleþme Kategori Ekle";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sBtnKaydet);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(746, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(65, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 6;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridSozlesmeKategoriEkle;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(423, 390);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 21;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmSozlesmeKategoriEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 437);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelSozlesmeKategoriEkle);
            this.Name = "frmSozlesmeKategoriEkle";
            this.Text = "Sözleþme Kategori Ekle";
            ((System.ComponentModel.ISupportInitialize)(this.panelSozlesmeKategoriEkle)).EndInit();
            this.panelSozlesmeKategoriEkle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSozlesmeKategoriEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelSozlesmeKategoriEkle;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridSozlesmeKategoriEkle;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn AD;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit26;
        private DevExpress.XtraGrid.Columns.GridColumn ACIKLAMA;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit2;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}