namespace  AdimAdimDavaKaydi.Sozlesme.Forms.Sozlesme.Util
{
    partial class ucSozlesmeHukum
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl1 = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMADE_BASLIK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOZLESME_MADDE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.colMADDE_ICERIK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMADDE_ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMADDE_GRUP = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.DoNotExtendEmbedNavigator = false;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1});
            this.gridControl1.Size = new System.Drawing.Size(677, 315);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.UseHyperDragDrop = false;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMADE_BASLIK,
            this.colSOZLESME_MADDE,
            this.colMADDE_ICERIK,
            this.colMADDE_ACIKLAMA,
            this.colMADDE_GRUP});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowPreview = true;
            this.gridView1.PreviewFieldName = "MADDE_ICERIK";
            this.gridView1.RowHeight = 30;
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            // 
            // colMADE_BASLIK
            // 
            this.colMADE_BASLIK.Caption = "Madde Baþlýk";
            this.colMADE_BASLIK.FieldName = "MADE_BASLIK";
            this.colMADE_BASLIK.Name = "colMADE_BASLIK";
            this.colMADE_BASLIK.Visible = true;
            this.colMADE_BASLIK.VisibleIndex = 0;
            this.colMADE_BASLIK.Width = 78;
            // 
            // colSOZLESME_MADDE
            // 
            this.colSOZLESME_MADDE.Caption = "Sözleþme Maddesi";
            this.colSOZLESME_MADDE.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colSOZLESME_MADDE.FieldName = "SOZLESME_MADDE";
            this.colSOZLESME_MADDE.Name = "colSOZLESME_MADDE";
            this.colSOZLESME_MADDE.Visible = true;
            this.colSOZLESME_MADDE.VisibleIndex = 1;
            this.colSOZLESME_MADDE.Width = 144;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // colMADDE_ICERIK
            // 
            this.colMADDE_ICERIK.Caption = "Ýçerik";
            this.colMADDE_ICERIK.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colMADDE_ICERIK.FieldName = "MADDE_ICERIK";
            this.colMADDE_ICERIK.Name = "colMADDE_ICERIK";
            this.colMADDE_ICERIK.Visible = true;
            this.colMADDE_ICERIK.VisibleIndex = 2;
            this.colMADDE_ICERIK.Width = 206;
            // 
            // colMADDE_ACIKLAMA
            // 
            this.colMADDE_ACIKLAMA.Caption = "Açýklama";
            this.colMADDE_ACIKLAMA.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colMADDE_ACIKLAMA.FieldName = "MADDE_ACIKLAMA";
            this.colMADDE_ACIKLAMA.Name = "colMADDE_ACIKLAMA";
            this.colMADDE_ACIKLAMA.Visible = true;
            this.colMADDE_ACIKLAMA.VisibleIndex = 3;
            this.colMADDE_ACIKLAMA.Width = 119;
            // 
            // colMADDE_GRUP
            // 
            this.colMADDE_GRUP.Caption = "Madde Grup";
            this.colMADDE_GRUP.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colMADDE_GRUP.FieldName = "MADDE_GRUP";
            this.colMADDE_GRUP.Name = "colMADDE_GRUP";
            this.colMADDE_GRUP.Visible = true;
            this.colMADDE_GRUP.VisibleIndex = 4;
            this.colMADDE_GRUP.Width = 109;
            // 
            // ucSozlesmeHukum
            // 
            this.Controls.Add(this.gridControl1);
            this.Name = "ucSozlesmeHukum";
            this.Size = new System.Drawing.Size(677, 315);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMADE_BASLIK;
        private DevExpress.XtraGrid.Columns.GridColumn colSOZLESME_MADDE;
        private DevExpress.XtraGrid.Columns.GridColumn colMADDE_ICERIK;
        private DevExpress.XtraGrid.Columns.GridColumn colMADDE_ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colMADDE_GRUP;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
    }
}
