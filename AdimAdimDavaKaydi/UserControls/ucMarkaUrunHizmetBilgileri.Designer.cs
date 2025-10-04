namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucMarkaUrunHizmetBilgileri
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
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.aV001TSBILMARKAURUNHIZMETBILGILERIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new AdimAdimDavaKaydi.Util.ExtendedGridView();
            this.colSOZLESME_URUN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMARKANIN_KULLANILACAGI_MAL_HIZMET_SEKTOR_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueHizmetSektor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.rLueUrunKategori = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.extendedGridControl1 = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemMemoExEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.layoutViewField_gridColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_gridColumn3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_gridColumn2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TSBILMARKAURUNHIZMETBILGILERIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHizmetSektor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueUrunKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extendedGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.aV001TSBILMARKAURUNHIZMETBILGILERIBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.DoNotExtendEmbedNavigator = false;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1,
            this.rLueUrunKategori,
            this.rLueHizmetSektor});
            this.gridControl1.Size = new System.Drawing.Size(646, 353);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.UseHyperDragDrop = false;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // aV001TSBILMARKAURUNHIZMETBILGILERIBindingSource
            // 
            this.aV001TSBILMARKAURUNHIZMETBILGILERIBindingSource.DataSource = typeof(AvukatProLib2.Entities.AV001_TS_BIL_MARKA_URUN_HIZMET_BILGILERI);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSOZLESME_URUN_ID,
            this.colMARKANIN_KULLANILACAGI_MAL_HIZMET_SEKTOR_ID,
            this.colACIKLAMA});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowPreview = true;
            this.gridView1.PreviewFieldName = "ACIKLAMA";
            // 
            // colSOZLESME_URUN_ID
            // 
            this.colSOZLESME_URUN_ID.Caption = "Ürün";
            this.colSOZLESME_URUN_ID.FieldName = "SOZLESME_URUN_ID";
            this.colSOZLESME_URUN_ID.Name = "colSOZLESME_URUN_ID";
            this.colSOZLESME_URUN_ID.Visible = true;
            this.colSOZLESME_URUN_ID.VisibleIndex = 0;
            // 
            // colMARKANIN_KULLANILACAGI_MAL_HIZMET_SEKTOR_ID
            // 
            this.colMARKANIN_KULLANILACAGI_MAL_HIZMET_SEKTOR_ID.Caption = "Sektör";
            this.colMARKANIN_KULLANILACAGI_MAL_HIZMET_SEKTOR_ID.ColumnEdit = this.rLueHizmetSektor;
            this.colMARKANIN_KULLANILACAGI_MAL_HIZMET_SEKTOR_ID.FieldName = "MARKANIN_KULLANILACAGI_MAL_HIZMET_SEKTOR_ID";
            this.colMARKANIN_KULLANILACAGI_MAL_HIZMET_SEKTOR_ID.Name = "colMARKANIN_KULLANILACAGI_MAL_HIZMET_SEKTOR_ID";
            this.colMARKANIN_KULLANILACAGI_MAL_HIZMET_SEKTOR_ID.Visible = true;
            this.colMARKANIN_KULLANILACAGI_MAL_HIZMET_SEKTOR_ID.VisibleIndex = 1;
            // 
            // rLueHizmetSektor
            // 
            this.rLueHizmetSektor.AutoHeight = false;
            this.rLueHizmetSektor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueHizmetSektor.Name = "rLueHizmetSektor";
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açýklama";
            this.colACIKLAMA.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 2;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // rLueUrunKategori
            // 
            this.rLueUrunKategori.AutoHeight = false;
            this.rLueUrunKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueUrunKategori.Name = "rLueUrunKategori";
            // 
            // extendedGridControl1
            // 
            this.extendedGridControl1.DataSource = this.aV001TSBILMARKAURUNHIZMETBILGILERIBindingSource;
            this.extendedGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extendedGridControl1.DoNotExtendEmbedNavigator = false;
            this.extendedGridControl1.EmbeddedNavigator.Name = "";
            this.extendedGridControl1.Location = new System.Drawing.Point(0, 0);
            this.extendedGridControl1.MainView = this.layoutView1;
            this.extendedGridControl1.Name = "extendedGridControl1";
            this.extendedGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit2,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemLookUpEdit1});
            this.extendedGridControl1.Size = new System.Drawing.Size(646, 353);
            this.extendedGridControl1.TabIndex = 1;
            this.extendedGridControl1.UseEmbeddedNavigator = true;
            this.extendedGridControl1.UseHyperDragDrop = false;
            this.extendedGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // repositoryItemMemoExEdit2
            // 
            this.repositoryItemMemoExEdit2.AutoHeight = false;
            this.repositoryItemMemoExEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit2.Name = "repositoryItemMemoExEdit2";
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            // 
            // layoutView1
            // 
            this.layoutView1.CardCaptionFormat = "Kayýt {0}";
            this.layoutView1.CardMinSize = new System.Drawing.Size(619, 74);
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.layoutView1.GridControl = this.extendedGridControl1;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ürün";
            this.gridColumn1.FieldName = "SOZLESME_URUN_ID";
            this.gridColumn1.LayoutViewField = this.layoutViewField_gridColumn1;
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Sektör";
            this.gridColumn2.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.gridColumn2.FieldName = "MARKANIN_KULLANILACAGI_MAL_HIZMET_SEKTOR_ID";
            this.gridColumn2.LayoutViewField = this.layoutViewField_gridColumn2;
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Açýklama";
            this.gridColumn3.ColumnEdit = this.repositoryItemMemoExEdit2;
            this.gridColumn3.FieldName = "ACIKLAMA";
            this.gridColumn3.LayoutViewField = this.layoutViewField_gridColumn3;
            this.gridColumn3.Name = "gridColumn3";
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "layoutViewTemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_gridColumn1,
            this.layoutViewField_gridColumn3,
            this.layoutViewField_gridColumn2});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // layoutViewField_gridColumn1
            // 
            this.layoutViewField_gridColumn1.EditorPreferredWidth = 246;
            this.layoutViewField_gridColumn1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_gridColumn1.Name = "layoutViewField_gridColumn1";
            this.layoutViewField_gridColumn1.Size = new System.Drawing.Size(307, 27);
            this.layoutViewField_gridColumn1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn1.TextSize = new System.Drawing.Size(45, 20);
            // 
            // layoutViewField_gridColumn3
            // 
            this.layoutViewField_gridColumn3.EditorPreferredWidth = 556;
            this.layoutViewField_gridColumn3.Location = new System.Drawing.Point(0, 27);
            this.layoutViewField_gridColumn3.Name = "layoutViewField_gridColumn3";
            this.layoutViewField_gridColumn3.Size = new System.Drawing.Size(617, 27);
            this.layoutViewField_gridColumn3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn3.TextSize = new System.Drawing.Size(45, 20);
            // 
            // layoutViewField_gridColumn2
            // 
            this.layoutViewField_gridColumn2.EditorPreferredWidth = 249;
            this.layoutViewField_gridColumn2.Location = new System.Drawing.Point(307, 0);
            this.layoutViewField_gridColumn2.Name = "layoutViewField_gridColumn2";
            this.layoutViewField_gridColumn2.Size = new System.Drawing.Size(310, 27);
            this.layoutViewField_gridColumn2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn2.TextSize = new System.Drawing.Size(45, 20);
            // 
            // ucMarkaUrunHizmetBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.extendedGridControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "ucMarkaUrunHizmetBilgileri";
            this.Size = new System.Drawing.Size(646, 353);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TSBILMARKAURUNHIZMETBILGILERIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHizmetSektor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueUrunKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extendedGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl  gridControl1;
        private AdimAdimDavaKaydi.Util.ExtendedGridView  gridView1;
        private System.Windows.Forms.BindingSource aV001TSBILMARKAURUNHIZMETBILGILERIBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSOZLESME_URUN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colMARKANIN_KULLANILACAGI_MAL_HIZMET_SEKTOR_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueUrunKategori;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueHizmetSektor;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl extendedGridControl1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn2;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
    }
}
