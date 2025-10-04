namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucSikayetBilgileri
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
            this.exGridSikayet = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSIKAYET_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSIKAYET_KATEGORISI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueSikayetKategorisi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSIKAYET_NEDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueSikayetNEdeni = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSIKAYET_EDEN_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueSikayetCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colISLEMI_SIKAYET_EDILEN_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdliBirimAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdliBirimGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSIKAYET_EDILEN_ADLI_BIRIM_NO_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdliBirimNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSIKAYET_EDILEN_ISLEM_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSIKAYET_SONUCU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exGridSikayet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetKategorisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetNEdeni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimAdliye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimGorev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // exGridSikayet
            // 
            this.exGridSikayet.CustomButtonlarGorunmesin = false;
            this.exGridSikayet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridSikayet.DoNotExtendEmbedNavigator = false;
            this.exGridSikayet.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.exGridSikayet.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.exGridSikayet.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.exGridSikayet.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayýt Ekle", "rFrmSikayetKayit"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, true, "Kaydý Düzenle", "Duzenle")});
            this.exGridSikayet.FilterText = null;
            this.exGridSikayet.FilterValue = null;
            this.exGridSikayet.GridlerDuzenlenebilir = true;
            this.exGridSikayet.GridsFilterControl = null;
            this.exGridSikayet.Location = new System.Drawing.Point(0, 0);
            this.exGridSikayet.MainView = this.gridView1;
            this.exGridSikayet.MyGridStyle = null;
            this.exGridSikayet.Name = "exGridSikayet";
            this.exGridSikayet.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueSikayetKategorisi,
            this.rLueSikayetNEdeni,
            this.rLueSikayetCari,
            this.rLueAdliBirimAdliye,
            this.rLueAdliBirimGorev,
            this.rLueAdliBirimNo,
            this.repositoryItemMemoExEdit1});
            this.exGridSikayet.ShowRowNumbers = false;
            this.exGridSikayet.SilmeKaldirilsin = false;
            this.exGridSikayet.Size = new System.Drawing.Size(729, 505);
            this.exGridSikayet.TabIndex = 0;
            this.exGridSikayet.TemizleKaldirGorunsunmu = false;
            this.exGridSikayet.UniqueId = "7e34ecac-16cc-4ee3-8520-52f5f346a283";
            this.exGridSikayet.UseEmbeddedNavigator = true;
            this.exGridSikayet.UseHyperDragDrop = false;
            this.exGridSikayet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.exGridSikayet.ButtonClick += new System.EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(this.exGridSikayet_ButtonClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSIKAYET_TARIHI,
            this.colSIKAYET_KATEGORISI_ID,
            this.colSIKAYET_NEDEN_ID,
            this.colSIKAYET_EDEN_CARI_ID,
            this.colISLEMI_SIKAYET_EDILEN_CARI_ID,
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID,
            this.colSIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID,
            this.colSIKAYET_EDILEN_ADLI_BIRIM_NO_ID,
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ESAS_NO,
            this.colSIKAYET_EDILEN_ISLEM_TARIHI,
            this.colSIKAYET_SONUCU,
            this.colACIKLAMA});
            this.gridView1.GridControl = this.exGridSikayet;
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.OptionsView.ShowPreview = true;
            this.gridView1.PreviewFieldName = "SIKAYET_SONUCU";
            // 
            // colSIKAYET_TARIHI
            // 
            this.colSIKAYET_TARIHI.Caption = "Tarihi";
            this.colSIKAYET_TARIHI.FieldName = "SIKAYET_TARIHI";
            this.colSIKAYET_TARIHI.Name = "colSIKAYET_TARIHI";
            this.colSIKAYET_TARIHI.OptionsColumn.ReadOnly = true;
            this.colSIKAYET_TARIHI.Visible = true;
            this.colSIKAYET_TARIHI.VisibleIndex = 0;
            // 
            // colSIKAYET_KATEGORISI_ID
            // 
            this.colSIKAYET_KATEGORISI_ID.Caption = "Kategorisi";
            this.colSIKAYET_KATEGORISI_ID.ColumnEdit = this.rLueSikayetKategorisi;
            this.colSIKAYET_KATEGORISI_ID.FieldName = "SIKAYET_KATEGORISI_ID";
            this.colSIKAYET_KATEGORISI_ID.Name = "colSIKAYET_KATEGORISI_ID";
            this.colSIKAYET_KATEGORISI_ID.OptionsColumn.ReadOnly = true;
            this.colSIKAYET_KATEGORISI_ID.Visible = true;
            this.colSIKAYET_KATEGORISI_ID.VisibleIndex = 1;
            // 
            // rLueSikayetKategorisi
            // 
            this.rLueSikayetKategorisi.AutoHeight = false;
            this.rLueSikayetKategorisi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSikayetKategorisi.Name = "rLueSikayetKategorisi";
            // 
            // colSIKAYET_NEDEN_ID
            // 
            this.colSIKAYET_NEDEN_ID.Caption = "Nedeni";
            this.colSIKAYET_NEDEN_ID.ColumnEdit = this.rLueSikayetNEdeni;
            this.colSIKAYET_NEDEN_ID.FieldName = "SIKAYET_NEDEN_ID";
            this.colSIKAYET_NEDEN_ID.Name = "colSIKAYET_NEDEN_ID";
            this.colSIKAYET_NEDEN_ID.OptionsColumn.ReadOnly = true;
            this.colSIKAYET_NEDEN_ID.Visible = true;
            this.colSIKAYET_NEDEN_ID.VisibleIndex = 2;
            // 
            // rLueSikayetNEdeni
            // 
            this.rLueSikayetNEdeni.AutoHeight = false;
            this.rLueSikayetNEdeni.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSikayetNEdeni.Name = "rLueSikayetNEdeni";
            // 
            // colSIKAYET_EDEN_CARI_ID
            // 
            this.colSIKAYET_EDEN_CARI_ID.Caption = "Þikayet Eden";
            this.colSIKAYET_EDEN_CARI_ID.ColumnEdit = this.rLueSikayetCari;
            this.colSIKAYET_EDEN_CARI_ID.FieldName = "SIKAYET_EDEN_CARI_ID";
            this.colSIKAYET_EDEN_CARI_ID.Name = "colSIKAYET_EDEN_CARI_ID";
            this.colSIKAYET_EDEN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colSIKAYET_EDEN_CARI_ID.Visible = true;
            this.colSIKAYET_EDEN_CARI_ID.VisibleIndex = 3;
            // 
            // rLueSikayetCari
            // 
            this.rLueSikayetCari.AutoHeight = false;
            this.rLueSikayetCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSikayetCari.Name = "rLueSikayetCari";
            // 
            // colISLEMI_SIKAYET_EDILEN_CARI_ID
            // 
            this.colISLEMI_SIKAYET_EDILEN_CARI_ID.Caption = "Þikayet Edilen";
            this.colISLEMI_SIKAYET_EDILEN_CARI_ID.ColumnEdit = this.rLueSikayetCari;
            this.colISLEMI_SIKAYET_EDILEN_CARI_ID.FieldName = "ISLEMI_SIKAYET_EDILEN_CARI_ID";
            this.colISLEMI_SIKAYET_EDILEN_CARI_ID.Name = "colISLEMI_SIKAYET_EDILEN_CARI_ID";
            this.colISLEMI_SIKAYET_EDILEN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colISLEMI_SIKAYET_EDILEN_CARI_ID.Visible = true;
            this.colISLEMI_SIKAYET_EDILEN_CARI_ID.VisibleIndex = 4;
            // 
            // colSIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID
            // 
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID.ColumnEdit = this.rLueAdliBirimAdliye;
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID.FieldName = "SIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID";
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID.Name = "colSIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID";
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID.OptionsColumn.ReadOnly = true;
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID.VisibleIndex = 5;
            // 
            // rLueAdliBirimAdliye
            // 
            this.rLueAdliBirimAdliye.AutoHeight = false;
            this.rLueAdliBirimAdliye.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimAdliye.Name = "rLueAdliBirimAdliye";
            // 
            // colSIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID
            // 
            this.colSIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID.Caption = "Görev";
            this.colSIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID.ColumnEdit = this.rLueAdliBirimGorev;
            this.colSIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID.FieldName = "SIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID";
            this.colSIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID.Name = "colSIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID";
            this.colSIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID.OptionsColumn.ReadOnly = true;
            this.colSIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID.Visible = true;
            this.colSIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID.VisibleIndex = 7;
            // 
            // rLueAdliBirimGorev
            // 
            this.rLueAdliBirimGorev.AutoHeight = false;
            this.rLueAdliBirimGorev.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimGorev.Name = "rLueAdliBirimGorev";
            // 
            // colSIKAYET_EDILEN_ADLI_BIRIM_NO_ID
            // 
            this.colSIKAYET_EDILEN_ADLI_BIRIM_NO_ID.Caption = "Birim No";
            this.colSIKAYET_EDILEN_ADLI_BIRIM_NO_ID.ColumnEdit = this.rLueAdliBirimNo;
            this.colSIKAYET_EDILEN_ADLI_BIRIM_NO_ID.FieldName = "SIKAYET_EDILEN_ADLI_BIRIM_NO_ID";
            this.colSIKAYET_EDILEN_ADLI_BIRIM_NO_ID.Name = "colSIKAYET_EDILEN_ADLI_BIRIM_NO_ID";
            this.colSIKAYET_EDILEN_ADLI_BIRIM_NO_ID.OptionsColumn.ReadOnly = true;
            this.colSIKAYET_EDILEN_ADLI_BIRIM_NO_ID.Visible = true;
            this.colSIKAYET_EDILEN_ADLI_BIRIM_NO_ID.VisibleIndex = 6;
            // 
            // rLueAdliBirimNo
            // 
            this.rLueAdliBirimNo.AutoHeight = false;
            this.rLueAdliBirimNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimNo.Name = "rLueAdliBirimNo";
            // 
            // colSIKAYET_EDILEN_ADLI_BIRIM_ESAS_NO
            // 
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ESAS_NO.Caption = "Esas No";
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ESAS_NO.FieldName = "SIKAYET_EDILEN_ADLI_BIRIM_ESAS_NO";
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ESAS_NO.Name = "colSIKAYET_EDILEN_ADLI_BIRIM_ESAS_NO";
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ESAS_NO.OptionsColumn.ReadOnly = true;
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ESAS_NO.Visible = true;
            this.colSIKAYET_EDILEN_ADLI_BIRIM_ESAS_NO.VisibleIndex = 8;
            // 
            // colSIKAYET_EDILEN_ISLEM_TARIHI
            // 
            this.colSIKAYET_EDILEN_ISLEM_TARIHI.Caption = "Ýþlem T";
            this.colSIKAYET_EDILEN_ISLEM_TARIHI.FieldName = "SIKAYET_EDILEN_ISLEM_TARIHI";
            this.colSIKAYET_EDILEN_ISLEM_TARIHI.Name = "colSIKAYET_EDILEN_ISLEM_TARIHI";
            this.colSIKAYET_EDILEN_ISLEM_TARIHI.OptionsColumn.ReadOnly = true;
            this.colSIKAYET_EDILEN_ISLEM_TARIHI.Visible = true;
            this.colSIKAYET_EDILEN_ISLEM_TARIHI.VisibleIndex = 9;
            // 
            // colSIKAYET_SONUCU
            // 
            this.colSIKAYET_SONUCU.Caption = "Sonucu";
            this.colSIKAYET_SONUCU.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colSIKAYET_SONUCU.FieldName = "SIKAYET_SONUCU";
            this.colSIKAYET_SONUCU.Name = "colSIKAYET_SONUCU";
            this.colSIKAYET_SONUCU.OptionsColumn.ReadOnly = true;
            this.colSIKAYET_SONUCU.Visible = true;
            this.colSIKAYET_SONUCU.VisibleIndex = 10;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açýklama";
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.OptionsColumn.ReadOnly = true;
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 11;
            // 
            // ucSikayetBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exGridSikayet);
            this.Name = "ucSikayetBilgileri";
            this.Size = new System.Drawing.Size(729, 505);
            this.Load += new System.EventHandler(this.ucSikayetBilgileri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exGridSikayet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetKategorisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetNEdeni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimAdliye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimGorev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl exGridSikayet;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSIKAYET_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colSIKAYET_KATEGORISI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSIKAYET_NEDEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSIKAYET_EDEN_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colISLEMI_SIKAYET_EDILEN_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSIKAYET_EDILEN_ADLI_BIRIM_NO_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSIKAYET_EDILEN_ADLI_BIRIM_ESAS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colSIKAYET_EDILEN_ISLEM_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colSIKAYET_SONUCU;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSikayetKategorisi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSikayetNEdeni;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSikayetCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimAdliye;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimGorev;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
    }
}
