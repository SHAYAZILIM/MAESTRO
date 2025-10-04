namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucSozlesmeUrunIlgilileri
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
            this.aV001TSBILSOZLESMEURUNILGILILERIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new AdimAdimDavaKaydi.Util.ExtendedGridView();
            this.colURUN_ILGILI_TARAF_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueTarafKoduId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colURUN_ILGILI_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueCariId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colURUN_ILGILI_SIFAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueTarafSifatId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.extendedGridControl1 = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TSBILSOZLESMEURUNILGILILERIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafKoduId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCariId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafSifatId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extendedGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.aV001TSBILSOZLESMEURUNILGILILERIBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.DoNotExtendEmbedNavigator = false;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.FilterText = null;
            this.gridControl1.FilterValue = null;
            this.gridControl1.GridsFilterControl = null;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MyGridStyle = null;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueCariId,
            this.rLueTarafSifatId,
            this.rLueTarafKoduId});
            this.gridControl1.Size = new System.Drawing.Size(437, 287);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UniqueId = "d3e2d0b5-5951-45d8-b904-95f40658bc6f";
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.UseHyperDragDrop = false;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // aV001TSBILSOZLESMEURUNILGILILERIBindingSource
            // 
            this.aV001TSBILSOZLESMEURUNILGILILERIBindingSource.DataSource = typeof(AvukatProLib2.Entities.AV001_TS_BIL_SOZLESME_URUN_ILGILILERI);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colURUN_ILGILI_TARAF_KODU,
            this.colURUN_ILGILI_CARI_ID,
            this.colURUN_ILGILI_SIFAT});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colURUN_ILGILI_TARAF_KODU
            // 
            this.colURUN_ILGILI_TARAF_KODU.Caption = "T.K";
            this.colURUN_ILGILI_TARAF_KODU.ColumnEdit = this.rLueTarafKoduId;
            this.colURUN_ILGILI_TARAF_KODU.FieldName = "URUN_ILGILI_TARAF_KODU";
            this.colURUN_ILGILI_TARAF_KODU.Name = "colURUN_ILGILI_TARAF_KODU";
            this.colURUN_ILGILI_TARAF_KODU.Visible = true;
            this.colURUN_ILGILI_TARAF_KODU.VisibleIndex = 0;
            this.colURUN_ILGILI_TARAF_KODU.Width = 60;
            // 
            // rLueTarafKoduId
            // 
            this.rLueTarafKoduId.AutoHeight = false;
            this.rLueTarafKoduId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTarafKoduId.Name = "rLueTarafKoduId";
            // 
            // colURUN_ILGILI_CARI_ID
            // 
            this.colURUN_ILGILI_CARI_ID.Caption = "Taraf";
            this.colURUN_ILGILI_CARI_ID.ColumnEdit = this.rLueCariId;
            this.colURUN_ILGILI_CARI_ID.FieldName = "URUN_ILGILI_CARI_ID";
            this.colURUN_ILGILI_CARI_ID.Name = "colURUN_ILGILI_CARI_ID";
            this.colURUN_ILGILI_CARI_ID.Visible = true;
            this.colURUN_ILGILI_CARI_ID.VisibleIndex = 2;
            this.colURUN_ILGILI_CARI_ID.Width = 252;
            // 
            // rLueCariId
            // 
            this.rLueCariId.AutoHeight = false;
            this.rLueCariId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueCariId.Name = "rLueCariId";
            // 
            // colURUN_ILGILI_SIFAT
            // 
            this.colURUN_ILGILI_SIFAT.Caption = "Sýfat";
            this.colURUN_ILGILI_SIFAT.ColumnEdit = this.rLueTarafSifatId;
            this.colURUN_ILGILI_SIFAT.FieldName = "URUN_ILGILI_SIFAT";
            this.colURUN_ILGILI_SIFAT.Name = "colURUN_ILGILI_SIFAT";
            this.colURUN_ILGILI_SIFAT.Visible = true;
            this.colURUN_ILGILI_SIFAT.VisibleIndex = 1;
            this.colURUN_ILGILI_SIFAT.Width = 104;
            // 
            // rLueTarafSifatId
            // 
            this.rLueTarafSifatId.AutoHeight = false;
            this.rLueTarafSifatId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTarafSifatId.Name = "rLueTarafSifatId";
            // 
            // extendedGridControl1
            // 
            this.extendedGridControl1.DataSource = this.aV001TSBILSOZLESMEURUNILGILILERIBindingSource;
            this.extendedGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extendedGridControl1.DoNotExtendEmbedNavigator = false;
            this.extendedGridControl1.EmbeddedNavigator.Name = "";
            this.extendedGridControl1.FilterText = null;
            this.extendedGridControl1.FilterValue = null;
            this.extendedGridControl1.GridsFilterControl = null;
            this.extendedGridControl1.Location = new System.Drawing.Point(0, 0);
            this.extendedGridControl1.MainView = this.layoutView1;
            this.extendedGridControl1.MyGridStyle = null;
            this.extendedGridControl1.Name = "extendedGridControl1";
            this.extendedGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit2,
            this.repositoryItemLookUpEdit3,
            this.repositoryItemLookUpEdit1});
            this.extendedGridControl1.Size = new System.Drawing.Size(437, 287);
            this.extendedGridControl1.TabIndex = 1;
            this.extendedGridControl1.UniqueId = "01486561-58b9-4bc1-b77b-d7b2901baf99";
            this.extendedGridControl1.UseEmbeddedNavigator = true;
            this.extendedGridControl1.UseHyperDragDrop = false;
            this.extendedGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
            // 
            // layoutView1
            // 
            this.layoutView1.CardCaptionFormat = "Kayýt {0}";
            this.layoutView1.CardMinSize = new System.Drawing.Size(616, 74);
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
            this.gridColumn1.Caption = "T.K";
            this.gridColumn1.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.gridColumn1.FieldName = "URUN_ILGILI_TARAF_KODU";
            this.gridColumn1.LayoutViewField = this.layoutViewField_gridColumn1;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 60;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // layoutViewField_gridColumn1
            // 
            this.layoutViewField_gridColumn1.EditorPreferredWidth = 568;
            this.layoutViewField_gridColumn1.Location = new System.Drawing.Point(0, 27);
            this.layoutViewField_gridColumn1.Name = "layoutViewField_gridColumn1";
            this.layoutViewField_gridColumn1.Size = new System.Drawing.Size(614, 27);
            this.layoutViewField_gridColumn1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn1.TextSize = new System.Drawing.Size(30, 20);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Taraf";
            this.gridColumn2.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.gridColumn2.FieldName = "URUN_ILGILI_CARI_ID";
            this.gridColumn2.LayoutViewField = this.layoutViewField_gridColumn2;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 252;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            // 
            // layoutViewField_gridColumn2
            // 
            this.layoutViewField_gridColumn2.EditorPreferredWidth = 395;
            this.layoutViewField_gridColumn2.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_gridColumn2.Name = "layoutViewField_gridColumn2";
            this.layoutViewField_gridColumn2.Size = new System.Drawing.Size(441, 27);
            this.layoutViewField_gridColumn2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn2.TextSize = new System.Drawing.Size(30, 20);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Sýfat";
            this.gridColumn3.ColumnEdit = this.repositoryItemLookUpEdit3;
            this.gridColumn3.FieldName = "URUN_ILGILI_SIFAT";
            this.gridColumn3.LayoutViewField = this.layoutViewField_gridColumn3;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Width = 104;
            // 
            // repositoryItemLookUpEdit3
            // 
            this.repositoryItemLookUpEdit3.AutoHeight = false;
            this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
            // 
            // layoutViewField_gridColumn3
            // 
            this.layoutViewField_gridColumn3.EditorPreferredWidth = 127;
            this.layoutViewField_gridColumn3.Location = new System.Drawing.Point(441, 0);
            this.layoutViewField_gridColumn3.Name = "layoutViewField_gridColumn3";
            this.layoutViewField_gridColumn3.Size = new System.Drawing.Size(173, 27);
            this.layoutViewField_gridColumn3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn3.TextSize = new System.Drawing.Size(30, 20);
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "layoutViewTemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_gridColumn2,
            this.layoutViewField_gridColumn3,
            this.layoutViewField_gridColumn1});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // ucSozlesmeUrunIlgilileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.extendedGridControl1);
            this.Name = "ucSozlesmeUrunIlgilileri";
            this.Size = new System.Drawing.Size(437, 287);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TSBILSOZLESMEURUNILGILILERIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafKoduId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCariId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafSifatId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extendedGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridControl1;
        private AdimAdimDavaKaydi.Util.ExtendedGridView  gridView1;
        private System.Windows.Forms.BindingSource aV001TSBILSOZLESMEURUNILGILILERIBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colURUN_ILGILI_TARAF_KODU;
        private DevExpress.XtraGrid.Columns.GridColumn colURUN_ILGILI_SIFAT;
        private DevExpress.XtraGrid.Columns.GridColumn colURUN_ILGILI_CARI_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueCariId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTarafSifatId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTarafKoduId;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl extendedGridControl1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn2;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
    }
}
