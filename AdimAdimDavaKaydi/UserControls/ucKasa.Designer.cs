namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucKasa
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
            this.extendedGridControl1 = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHAREKET_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlkCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBORC_ALACAK_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlkBorcAlacak = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colREFERANS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBELGE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlkOdemeTipi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colHAREKET_ANA_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlkMuhasebeAnaKategori = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADET = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlkDovizId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBIRIM_FIYAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rudTutar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colGENEL_TOPLAM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAYIT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSUBE_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGENEL_TOPLAM_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.compGridDovizSummary1 = new AdimAdimDavaKaydi.Util.compGridDovizSummary(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.extendedGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkBorcAlacak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkOdemeTipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkMuhasebeAnaKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkDovizId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudTutar)).BeginInit();
            this.SuspendLayout();
            // 
            // extendedGridControl1
            // 
            this.extendedGridControl1.CustomButtonlarGorunmesin = false;
            this.extendedGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extendedGridControl1.DoNotExtendEmbedNavigator = false;
            this.extendedGridControl1.FilterText = null;
            this.extendedGridControl1.FilterValue = null;
            this.extendedGridControl1.GridlerDuzenlenebilir = true;
            this.extendedGridControl1.GridsFilterControl = null;
            this.extendedGridControl1.Location = new System.Drawing.Point(0, 0);
            this.extendedGridControl1.MainView = this.gridView1;
            this.extendedGridControl1.MyGridStyle = null;
            this.extendedGridControl1.Name = "extendedGridControl1";
            this.extendedGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkCari,
            this.rlkBorcAlacak,
            this.rlkOdemeTipi,
            this.rlkMuhasebeAnaKategori,
            this.rlkDovizId,
            this.rudTutar,
            this.repositoryItemDateEdit1});
            this.extendedGridControl1.ShowRowNumbers = false;
            this.extendedGridControl1.Size = new System.Drawing.Size(735, 498);
            this.extendedGridControl1.TabIndex = 1;
            this.extendedGridControl1.TemizleKaldirGorunsunmu = false;
            this.extendedGridControl1.UniqueId = "5069bdb8-14bb-4d97-a4c0-4ad7b089c1c2";
            this.extendedGridControl1.UseHyperDragDrop = false;
            this.extendedGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHAREKET_CARI_ID,
            this.colBORC_ALACAK_ID,
            this.colREFERANS_NO,
            this.colBELGE_NO,
            this.colODEME_TIP_ID,
            this.colTARIH,
            this.colHAREKET_ANA_KATEGORI_ID,
            this.colADET,
            this.colBIRIM_FIYAT_DOVIZ_ID,
            this.colBIRIM_FIYAT,
            this.colGENEL_TOPLAM,
            this.colACIKLAMA,
            this.colKAYIT_TARIHI,
            this.colSUBE_KODU,
            this.colGENEL_TOPLAM_DOVIZ_ID});
            this.gridView1.GridControl = this.extendedGridControl1;
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            // 
            // colHAREKET_CARI_ID
            // 
            this.colHAREKET_CARI_ID.Caption = "Þahýs Adý";
            this.colHAREKET_CARI_ID.ColumnEdit = this.rlkCari;
            this.colHAREKET_CARI_ID.FieldName = "HAREKET_CARI_ID";
            this.colHAREKET_CARI_ID.Name = "colHAREKET_CARI_ID";
            this.colHAREKET_CARI_ID.Visible = true;
            this.colHAREKET_CARI_ID.VisibleIndex = 2;
            this.colHAREKET_CARI_ID.Width = 196;
            // 
            // rlkCari
            // 
            this.rlkCari.AutoHeight = false;
            this.rlkCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkCari.Name = "rlkCari";
            // 
            // colBORC_ALACAK_ID
            // 
            this.colBORC_ALACAK_ID.Caption = "B/A";
            this.colBORC_ALACAK_ID.ColumnEdit = this.rlkBorcAlacak;
            this.colBORC_ALACAK_ID.FieldName = "BORC_ALACAK_ID";
            this.colBORC_ALACAK_ID.Name = "colBORC_ALACAK_ID";
            this.colBORC_ALACAK_ID.Visible = true;
            this.colBORC_ALACAK_ID.VisibleIndex = 4;
            // 
            // rlkBorcAlacak
            // 
            this.rlkBorcAlacak.AutoHeight = false;
            this.rlkBorcAlacak.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkBorcAlacak.Name = "rlkBorcAlacak";
            // 
            // colREFERANS_NO
            // 
            this.colREFERANS_NO.Caption = "Referans No";
            this.colREFERANS_NO.FieldName = "REFERANS_NO";
            this.colREFERANS_NO.Name = "colREFERANS_NO";
            this.colREFERANS_NO.Visible = true;
            this.colREFERANS_NO.VisibleIndex = 11;
            this.colREFERANS_NO.Width = 104;
            // 
            // colBELGE_NO
            // 
            this.colBELGE_NO.Caption = "Belge No";
            this.colBELGE_NO.FieldName = "BELGE_NO";
            this.colBELGE_NO.Name = "colBELGE_NO";
            this.colBELGE_NO.Visible = true;
            this.colBELGE_NO.VisibleIndex = 12;
            // 
            // colODEME_TIP_ID
            // 
            this.colODEME_TIP_ID.Caption = "Ödeme Tipi";
            this.colODEME_TIP_ID.ColumnEdit = this.rlkOdemeTipi;
            this.colODEME_TIP_ID.FieldName = "ODEME_TIP_ID";
            this.colODEME_TIP_ID.Name = "colODEME_TIP_ID";
            this.colODEME_TIP_ID.Visible = true;
            this.colODEME_TIP_ID.VisibleIndex = 3;
            this.colODEME_TIP_ID.Width = 93;
            // 
            // rlkOdemeTipi
            // 
            this.rlkOdemeTipi.AutoHeight = false;
            this.rlkOdemeTipi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkOdemeTipi.Name = "rlkOdemeTipi";
            // 
            // colTARIH
            // 
            this.colTARIH.Caption = "Tarih";
            this.colTARIH.ColumnEdit = this.repositoryItemDateEdit1;
            this.colTARIH.FieldName = "TARIH";
            this.colTARIH.Name = "colTARIH";
            this.colTARIH.Visible = true;
            this.colTARIH.VisibleIndex = 0;
            this.colTARIH.Width = 88;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colHAREKET_ANA_KATEGORI_ID
            // 
            this.colHAREKET_ANA_KATEGORI_ID.Caption = "Haraket Kategori";
            this.colHAREKET_ANA_KATEGORI_ID.ColumnEdit = this.rlkMuhasebeAnaKategori;
            this.colHAREKET_ANA_KATEGORI_ID.FieldName = "HAREKET_ANA_KATEGORI_ID";
            this.colHAREKET_ANA_KATEGORI_ID.Name = "colHAREKET_ANA_KATEGORI_ID";
            this.colHAREKET_ANA_KATEGORI_ID.Visible = true;
            this.colHAREKET_ANA_KATEGORI_ID.VisibleIndex = 1;
            this.colHAREKET_ANA_KATEGORI_ID.Width = 232;
            // 
            // rlkMuhasebeAnaKategori
            // 
            this.rlkMuhasebeAnaKategori.AutoHeight = false;
            this.rlkMuhasebeAnaKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkMuhasebeAnaKategori.Name = "rlkMuhasebeAnaKategori";
            // 
            // colADET
            // 
            this.colADET.Caption = "Adet";
            this.colADET.FieldName = "ADET";
            this.colADET.Name = "colADET";
            this.colADET.Visible = true;
            this.colADET.VisibleIndex = 7;
            this.colADET.Width = 44;
            // 
            // colBIRIM_FIYAT_DOVIZ_ID
            // 
            this.colBIRIM_FIYAT_DOVIZ_ID.Caption = "Brm.";
            this.colBIRIM_FIYAT_DOVIZ_ID.ColumnEdit = this.rlkDovizId;
            this.colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            this.colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
            this.colBIRIM_FIYAT_DOVIZ_ID.Visible = true;
            this.colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 6;
            this.colBIRIM_FIYAT_DOVIZ_ID.Width = 35;
            // 
            // rlkDovizId
            // 
            this.rlkDovizId.AutoHeight = false;
            this.rlkDovizId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkDovizId.Name = "rlkDovizId";
            // 
            // colBIRIM_FIYAT
            // 
            this.colBIRIM_FIYAT.Caption = "Tutar";
            this.colBIRIM_FIYAT.ColumnEdit = this.rudTutar;
            this.colBIRIM_FIYAT.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colBIRIM_FIYAT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            this.colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
            this.colBIRIM_FIYAT.Visible = true;
            this.colBIRIM_FIYAT.VisibleIndex = 5;
            this.colBIRIM_FIYAT.Width = 104;
            // 
            // rudTutar
            // 
            this.rudTutar.AutoHeight = false;
            this.rudTutar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rudTutar.Name = "rudTutar";
            // 
            // colGENEL_TOPLAM
            // 
            this.colGENEL_TOPLAM.Caption = "Genel Toplam";
            this.colGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            this.colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
            this.colGENEL_TOPLAM.Visible = true;
            this.colGENEL_TOPLAM.VisibleIndex = 8;
            this.colGENEL_TOPLAM.Width = 90;
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açýklama";
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 10;
            // 
            // colKAYIT_TARIHI
            // 
            this.colKAYIT_TARIHI.Caption = "Kayýt Tarihi";
            this.colKAYIT_TARIHI.ColumnEdit = this.repositoryItemDateEdit1;
            this.colKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            this.colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
            this.colKAYIT_TARIHI.Visible = true;
            this.colKAYIT_TARIHI.VisibleIndex = 13;
            // 
            // colSUBE_KODU
            // 
            this.colSUBE_KODU.Caption = "Þube";
            this.colSUBE_KODU.FieldName = "SUBE_KODU";
            this.colSUBE_KODU.Name = "colSUBE_KODU";
            this.colSUBE_KODU.Visible = true;
            this.colSUBE_KODU.VisibleIndex = 14;
            // 
            // colGENEL_TOPLAM_DOVIZ_ID
            // 
            this.colGENEL_TOPLAM_DOVIZ_ID.Caption = "Brm.";
            this.colGENEL_TOPLAM_DOVIZ_ID.ColumnEdit = this.rlkDovizId;
            this.colGENEL_TOPLAM_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            this.colGENEL_TOPLAM_DOVIZ_ID.Name = "colGENEL_TOPLAM_DOVIZ_ID";
            this.colGENEL_TOPLAM_DOVIZ_ID.Visible = true;
            this.colGENEL_TOPLAM_DOVIZ_ID.VisibleIndex = 9;
            this.colGENEL_TOPLAM_DOVIZ_ID.Width = 31;
            // 
            // compGridDovizSummary1
            // 
            this.compGridDovizSummary1.AltToplamlarAktifMi = true;
            this.compGridDovizSummary1.MyGridView = null;
            // 
            // ucKasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.extendedGridControl1);
            this.Name = "ucKasa";
            this.Size = new System.Drawing.Size(735, 498);
            this.Load += new System.EventHandler(this.ucKasa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.extendedGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkBorcAlacak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkOdemeTipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkMuhasebeAnaKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkDovizId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudTutar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl extendedGridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colHAREKET_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colBORC_ALACAK_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colREFERANS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colBELGE_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colHAREKET_ANA_KATEGORI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colADET;
        private DevExpress.XtraGrid.Columns.GridColumn colBIRIM_FIYAT_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colBIRIM_FIYAT;
        private DevExpress.XtraGrid.Columns.GridColumn colGENEL_TOPLAM;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colKAYIT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colSUBE_KODU;
        private DevExpress.XtraGrid.Columns.GridColumn colGENEL_TOPLAM_DOVIZ_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkBorcAlacak;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkOdemeTipi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkMuhasebeAnaKategori;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkDovizId;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rudTutar;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private AdimAdimDavaKaydi.Util.compGridDovizSummary compGridDovizSummary1;
    }
}
