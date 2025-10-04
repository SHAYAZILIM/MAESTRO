namespace  AdimAdimDavaKaydi.UserControls.UcDava
{
    partial class ucDavaAsama
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
            this.gridDavaAsamaBilgiler = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.aV001TDIEBILASAMABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gwDavaAsamaBilgiler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colASAMA_MODUL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAsamaModul = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colASAMA_KOD_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAsamaKod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colASAMA_ALT_KOD_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAsamaAltKod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colASAMA_KONU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colASAMA_ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colASAMA_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAVA_NEDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDavaNeden = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colALACAK_NEDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAlacakNeden = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADLI_BIRIM_BOLUM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdliBirimBolum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdliBirimAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADLI_BIRIM_NO_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdlibirimNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADLI_BIRIM_GOREV_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdliBirimGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEXTRA_KAYNAK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEXTRA_BELGE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colASAMA_OZEL_DURUM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueOzelDurumLar = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colASAMA_OZEL_DURUM2_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colASAMA_OZEL_DURUM3_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaAsamaBilgiler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TDIEBILASAMABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwDavaAsamaBilgiler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAsamaModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAsamaKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAsamaAltKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDavaNeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakNeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimBolum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimAdliye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdlibirimNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimGorev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelDurumLar)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDavaAsamaBilgiler
            // 
            this.gridDavaAsamaBilgiler.CustomButtonlarGorunmesin = false;
            this.gridDavaAsamaBilgiler.DataSource = this.aV001TDIEBILASAMABindingSource;
            this.gridDavaAsamaBilgiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDavaAsamaBilgiler.DoNotExtendEmbedNavigator = false;
            this.gridDavaAsamaBilgiler.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.gridDavaAsamaBilgiler.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridDavaAsamaBilgiler.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.gridDavaAsamaBilgiler.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridDavaAsamaBilgiler.FilterText = null;
            this.gridDavaAsamaBilgiler.FilterValue = null;
            this.gridDavaAsamaBilgiler.GridlerDuzenlenebilir = true;
            this.gridDavaAsamaBilgiler.GridsFilterControl = null;
            this.gridDavaAsamaBilgiler.Location = new System.Drawing.Point(0, 0);
            this.gridDavaAsamaBilgiler.MainView = this.gwDavaAsamaBilgiler;
            this.gridDavaAsamaBilgiler.MyGridStyle = null;
            this.gridDavaAsamaBilgiler.Name = "gridDavaAsamaBilgiler";
            this.gridDavaAsamaBilgiler.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueAsamaModul,
            this.rLueAsamaKod,
            this.rLueAsamaAltKod,
            this.rLueDavaNeden,
            this.rLueAlacakNeden,
            this.rLueAdliBirimBolum,
            this.rLueAdliBirimAdliye,
            this.rLueAdlibirimNo,
            this.rLueAdliBirimGorev,
            this.rLueOzelDurumLar});
            this.gridDavaAsamaBilgiler.ShowRowNumbers = false;
            this.gridDavaAsamaBilgiler.Size = new System.Drawing.Size(614, 487);
            this.gridDavaAsamaBilgiler.TabIndex = 0;
            this.gridDavaAsamaBilgiler.TemizleKaldirGorunsunmu = false;
            this.gridDavaAsamaBilgiler.UniqueId = "53e67fd6-2008-4989-a74c-9f1ea915c917";
            this.gridDavaAsamaBilgiler.UseEmbeddedNavigator = true;
            this.gridDavaAsamaBilgiler.UseHyperDragDrop = false;
            this.gridDavaAsamaBilgiler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwDavaAsamaBilgiler});
            // 
            // aV001TDIEBILASAMABindingSource
            // 
            this.aV001TDIEBILASAMABindingSource.DataSource = typeof(AvukatProLib2.Entities.AV001_TDIE_BIL_ASAMA);
            // 
            // gwDavaAsamaBilgiler
            // 
            this.gwDavaAsamaBilgiler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colASAMA_MODUL_ID,
            this.colASAMA_KOD_ID,
            this.colASAMA_ALT_KOD_ID,
            this.colASAMA_KONU,
            this.colASAMA_ACIKLAMA,
            this.colASAMA_TARIHI,
            this.colDAVA_NEDEN_ID,
            this.colALACAK_NEDEN_ID,
            this.colADLI_BIRIM_BOLUM_ID,
            this.colADLI_BIRIM_ADLIYE_ID,
            this.colADLI_BIRIM_NO_ID,
            this.colADLI_BIRIM_GOREV_ID,
            this.colESAS_NO,
            this.colEXTRA_KAYNAK,
            this.colEXTRA_BELGE_ID,
            this.colASAMA_OZEL_DURUM_ID,
            this.colASAMA_OZEL_DURUM2_ID,
            this.colASAMA_OZEL_DURUM3_ID});
            this.gwDavaAsamaBilgiler.GridControl = this.gridDavaAsamaBilgiler;
            this.gwDavaAsamaBilgiler.IndicatorWidth = 20;
            this.gwDavaAsamaBilgiler.Name = "gwDavaAsamaBilgiler";
            this.gwDavaAsamaBilgiler.OptionsBehavior.FocusLeaveOnTab = true;
            this.gwDavaAsamaBilgiler.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwDavaAsamaBilgiler.OptionsNavigation.AutoFocusNewRow = true;
            this.gwDavaAsamaBilgiler.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwDavaAsamaBilgiler.OptionsView.AutoCalcPreviewLineCount = true;
            this.gwDavaAsamaBilgiler.OptionsView.ColumnAutoWidth = false;
            this.gwDavaAsamaBilgiler.OptionsView.ShowAutoFilterRow = true;
            this.gwDavaAsamaBilgiler.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwDavaAsamaBilgiler.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gwDavaAsamaBilgiler.OptionsView.ShowPreview = true;
            this.gwDavaAsamaBilgiler.PreviewFieldName = "ASAMA_ACIKLAMA";
            // 
            // colASAMA_MODUL_ID
            // 
            this.colASAMA_MODUL_ID.Caption = "Modül";
            this.colASAMA_MODUL_ID.ColumnEdit = this.rLueAsamaModul;
            this.colASAMA_MODUL_ID.FieldName = "ASAMA_MODUL_ID";
            this.colASAMA_MODUL_ID.Name = "colASAMA_MODUL_ID";
            this.colASAMA_MODUL_ID.Visible = true;
            this.colASAMA_MODUL_ID.VisibleIndex = 0;
            // 
            // rLueAsamaModul
            // 
            this.rLueAsamaModul.AutoHeight = false;
            this.rLueAsamaModul.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAsamaModul.Name = "rLueAsamaModul";
            // 
            // colASAMA_KOD_ID
            // 
            this.colASAMA_KOD_ID.Caption = "Kod";
            this.colASAMA_KOD_ID.ColumnEdit = this.rLueAsamaKod;
            this.colASAMA_KOD_ID.FieldName = "ASAMA_KOD_ID";
            this.colASAMA_KOD_ID.Name = "colASAMA_KOD_ID";
            this.colASAMA_KOD_ID.Visible = true;
            this.colASAMA_KOD_ID.VisibleIndex = 1;
            // 
            // rLueAsamaKod
            // 
            this.rLueAsamaKod.AutoHeight = false;
            this.rLueAsamaKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAsamaKod.Name = "rLueAsamaKod";
            // 
            // colASAMA_ALT_KOD_ID
            // 
            this.colASAMA_ALT_KOD_ID.Caption = "Aþama Alt Kod";
            this.colASAMA_ALT_KOD_ID.ColumnEdit = this.rLueAsamaAltKod;
            this.colASAMA_ALT_KOD_ID.FieldName = "ASAMA_ALT_KOD_ID";
            this.colASAMA_ALT_KOD_ID.Name = "colASAMA_ALT_KOD_ID";
            this.colASAMA_ALT_KOD_ID.Visible = true;
            this.colASAMA_ALT_KOD_ID.VisibleIndex = 2;
            // 
            // rLueAsamaAltKod
            // 
            this.rLueAsamaAltKod.AutoHeight = false;
            this.rLueAsamaAltKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAsamaAltKod.Name = "rLueAsamaAltKod";
            // 
            // colASAMA_KONU
            // 
            this.colASAMA_KONU.Caption = "Konu";
            this.colASAMA_KONU.FieldName = "ASAMA_KONU";
            this.colASAMA_KONU.Name = "colASAMA_KONU";
            this.colASAMA_KONU.Visible = true;
            this.colASAMA_KONU.VisibleIndex = 3;
            // 
            // colASAMA_ACIKLAMA
            // 
            this.colASAMA_ACIKLAMA.Caption = "Açýklama";
            this.colASAMA_ACIKLAMA.FieldName = "ASAMA_ACIKLAMA";
            this.colASAMA_ACIKLAMA.Name = "colASAMA_ACIKLAMA";
            this.colASAMA_ACIKLAMA.Visible = true;
            this.colASAMA_ACIKLAMA.VisibleIndex = 4;
            // 
            // colASAMA_TARIHI
            // 
            this.colASAMA_TARIHI.Caption = "Tarihi";
            this.colASAMA_TARIHI.FieldName = "ASAMA_TARIHI";
            this.colASAMA_TARIHI.Name = "colASAMA_TARIHI";
            this.colASAMA_TARIHI.Visible = true;
            this.colASAMA_TARIHI.VisibleIndex = 5;
            // 
            // colDAVA_NEDEN_ID
            // 
            this.colDAVA_NEDEN_ID.Caption = "Dava Neden";
            this.colDAVA_NEDEN_ID.ColumnEdit = this.rLueDavaNeden;
            this.colDAVA_NEDEN_ID.FieldName = "DAVA_NEDEN_ID";
            this.colDAVA_NEDEN_ID.Name = "colDAVA_NEDEN_ID";
            this.colDAVA_NEDEN_ID.Visible = true;
            this.colDAVA_NEDEN_ID.VisibleIndex = 6;
            // 
            // rLueDavaNeden
            // 
            this.rLueDavaNeden.AutoHeight = false;
            this.rLueDavaNeden.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDavaNeden.Name = "rLueDavaNeden";
            // 
            // colALACAK_NEDEN_ID
            // 
            this.colALACAK_NEDEN_ID.Caption = "Alacak Neden";
            this.colALACAK_NEDEN_ID.ColumnEdit = this.rLueAlacakNeden;
            this.colALACAK_NEDEN_ID.FieldName = "ALACAK_NEDEN_ID";
            this.colALACAK_NEDEN_ID.Name = "colALACAK_NEDEN_ID";
            this.colALACAK_NEDEN_ID.Visible = true;
            this.colALACAK_NEDEN_ID.VisibleIndex = 7;
            // 
            // rLueAlacakNeden
            // 
            this.rLueAlacakNeden.AutoHeight = false;
            this.rLueAlacakNeden.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAlacakNeden.Name = "rLueAlacakNeden";
            // 
            // colADLI_BIRIM_BOLUM_ID
            // 
            this.colADLI_BIRIM_BOLUM_ID.Caption = "Birim Bölüm";
            this.colADLI_BIRIM_BOLUM_ID.ColumnEdit = this.rLueAdliBirimBolum;
            this.colADLI_BIRIM_BOLUM_ID.FieldName = "ADLI_BIRIM_BOLUM_ID";
            this.colADLI_BIRIM_BOLUM_ID.Name = "colADLI_BIRIM_BOLUM_ID";
            this.colADLI_BIRIM_BOLUM_ID.Visible = true;
            this.colADLI_BIRIM_BOLUM_ID.VisibleIndex = 8;
            // 
            // rLueAdliBirimBolum
            // 
            this.rLueAdliBirimBolum.AutoHeight = false;
            this.rLueAdliBirimBolum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimBolum.Name = "rLueAdliBirimBolum";
            // 
            // colADLI_BIRIM_ADLIYE_ID
            // 
            this.colADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
            this.colADLI_BIRIM_ADLIYE_ID.ColumnEdit = this.rLueAdliBirimAdliye;
            this.colADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
            this.colADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 9;
            // 
            // rLueAdliBirimAdliye
            // 
            this.rLueAdliBirimAdliye.AutoHeight = false;
            this.rLueAdliBirimAdliye.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimAdliye.Name = "rLueAdliBirimAdliye";
            // 
            // colADLI_BIRIM_NO_ID
            // 
            this.colADLI_BIRIM_NO_ID.Caption = "Birim No";
            this.colADLI_BIRIM_NO_ID.ColumnEdit = this.rLueAdlibirimNo;
            this.colADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            this.colADLI_BIRIM_NO_ID.Name = "colADLI_BIRIM_NO_ID";
            this.colADLI_BIRIM_NO_ID.Visible = true;
            this.colADLI_BIRIM_NO_ID.VisibleIndex = 10;
            // 
            // rLueAdlibirimNo
            // 
            this.rLueAdlibirimNo.AutoHeight = false;
            this.rLueAdlibirimNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdlibirimNo.Name = "rLueAdlibirimNo";
            // 
            // colADLI_BIRIM_GOREV_ID
            // 
            this.colADLI_BIRIM_GOREV_ID.Caption = "Görev";
            this.colADLI_BIRIM_GOREV_ID.ColumnEdit = this.rLueAdliBirimGorev;
            this.colADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.colADLI_BIRIM_GOREV_ID.Name = "colADLI_BIRIM_GOREV_ID";
            this.colADLI_BIRIM_GOREV_ID.Visible = true;
            this.colADLI_BIRIM_GOREV_ID.VisibleIndex = 11;
            // 
            // rLueAdliBirimGorev
            // 
            this.rLueAdliBirimGorev.AutoHeight = false;
            this.rLueAdliBirimGorev.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimGorev.Name = "rLueAdliBirimGorev";
            // 
            // colESAS_NO
            // 
            this.colESAS_NO.Caption = "Esas No";
            this.colESAS_NO.FieldName = "ESAS_NO";
            this.colESAS_NO.Name = "colESAS_NO";
            this.colESAS_NO.Visible = true;
            this.colESAS_NO.VisibleIndex = 12;
            // 
            // colEXTRA_KAYNAK
            // 
            this.colEXTRA_KAYNAK.Caption = "Extra Kaynak";
            this.colEXTRA_KAYNAK.FieldName = "EXTRA_KAYNAK";
            this.colEXTRA_KAYNAK.Name = "colEXTRA_KAYNAK";
            this.colEXTRA_KAYNAK.Visible = true;
            this.colEXTRA_KAYNAK.VisibleIndex = 13;
            // 
            // colEXTRA_BELGE_ID
            // 
            this.colEXTRA_BELGE_ID.Caption = "Extra Belge";
            this.colEXTRA_BELGE_ID.FieldName = "EXTRA_BELGE_ID";
            this.colEXTRA_BELGE_ID.Name = "colEXTRA_BELGE_ID";
            this.colEXTRA_BELGE_ID.Visible = true;
            this.colEXTRA_BELGE_ID.VisibleIndex = 14;
            // 
            // colASAMA_OZEL_DURUM_ID
            // 
            this.colASAMA_OZEL_DURUM_ID.Caption = "Özel Durum 1";
            this.colASAMA_OZEL_DURUM_ID.ColumnEdit = this.rLueOzelDurumLar;
            this.colASAMA_OZEL_DURUM_ID.FieldName = "ASAMA_OZEL_DURUM_ID";
            this.colASAMA_OZEL_DURUM_ID.Name = "colASAMA_OZEL_DURUM_ID";
            this.colASAMA_OZEL_DURUM_ID.Visible = true;
            this.colASAMA_OZEL_DURUM_ID.VisibleIndex = 15;
            // 
            // rLueOzelDurumLar
            // 
            this.rLueOzelDurumLar.AutoHeight = false;
            this.rLueOzelDurumLar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueOzelDurumLar.Name = "rLueOzelDurumLar";
            // 
            // colASAMA_OZEL_DURUM2_ID
            // 
            this.colASAMA_OZEL_DURUM2_ID.Caption = "Özel Durum 2";
            this.colASAMA_OZEL_DURUM2_ID.ColumnEdit = this.rLueOzelDurumLar;
            this.colASAMA_OZEL_DURUM2_ID.FieldName = "ASAMA_OZEL_DURUM2_ID";
            this.colASAMA_OZEL_DURUM2_ID.Name = "colASAMA_OZEL_DURUM2_ID";
            this.colASAMA_OZEL_DURUM2_ID.Visible = true;
            this.colASAMA_OZEL_DURUM2_ID.VisibleIndex = 16;
            // 
            // colASAMA_OZEL_DURUM3_ID
            // 
            this.colASAMA_OZEL_DURUM3_ID.Caption = "Özel Durum 3";
            this.colASAMA_OZEL_DURUM3_ID.ColumnEdit = this.rLueOzelDurumLar;
            this.colASAMA_OZEL_DURUM3_ID.FieldName = "ASAMA_OZEL_DURUM3_ID";
            this.colASAMA_OZEL_DURUM3_ID.Name = "colASAMA_OZEL_DURUM3_ID";
            this.colASAMA_OZEL_DURUM3_ID.Visible = true;
            this.colASAMA_OZEL_DURUM3_ID.VisibleIndex = 17;
            // 
            // ucDavaAsama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridDavaAsamaBilgiler);
            this.Name = "ucDavaAsama";
            this.Size = new System.Drawing.Size(614, 487);
            this.Load += new System.EventHandler(this.ucDavaAsama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaAsamaBilgiler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TDIEBILASAMABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwDavaAsamaBilgiler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAsamaModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAsamaKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAsamaAltKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDavaNeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakNeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimBolum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimAdliye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdlibirimNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimGorev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelDurumLar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDavaAsamaBilgiler;
        private DevExpress.XtraGrid.Views.Grid.GridView gwDavaAsamaBilgiler;
        private System.Windows.Forms.BindingSource aV001TDIEBILASAMABindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colASAMA_MODUL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colASAMA_KOD_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colASAMA_ALT_KOD_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colASAMA_KONU;
        private DevExpress.XtraGrid.Columns.GridColumn colASAMA_ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colASAMA_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colDAVA_NEDEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colALACAK_NEDEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_BOLUM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_ADLIYE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_NO_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_GOREV_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colESAS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colEXTRA_KAYNAK;
        private DevExpress.XtraGrid.Columns.GridColumn colEXTRA_BELGE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colASAMA_OZEL_DURUM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colASAMA_OZEL_DURUM2_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colASAMA_OZEL_DURUM3_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAsamaModul;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAsamaKod;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAsamaAltKod;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDavaNeden;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAlacakNeden;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimBolum;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimAdliye;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdlibirimNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimGorev;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueOzelDurumLar;
    }
}
