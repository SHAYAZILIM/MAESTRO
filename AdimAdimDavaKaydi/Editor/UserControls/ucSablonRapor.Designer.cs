namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucSablonRapor
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
            this.gridSablonRapor = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRAPOR_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueRaporTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADLI_BIRIM_BOLUM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdliBirimBolum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colKATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueKategori = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDOSYA_ADRES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMODUL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueModul = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colFORM_ORNEK_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueFormOrnekNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTAKIP_TALEP_KONU_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueTakipTalepKonu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDAVA_TALEP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDavaTalep = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADLI_BIRIM_GOREV_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdliBirimGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSOZLESME_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueSozlesmeTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDAVA_NEDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDavaNeden = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDOSYA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLuedil = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSEKTOR_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueSektor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDEGISKENI_VARMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColSec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYAYINDA_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridSablonRapor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueRaporTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimBolum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFormOrnekNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTakipTalepKonu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDavaTalep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimGorev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSozlesmeTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDavaNeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLuedil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSektor)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSablonRapor
            // 
            this.gridSablonRapor.CustomButtonlarGorunmesin = false;
            this.gridSablonRapor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSablonRapor.DoNotExtendEmbedNavigator = false;
            this.gridSablonRapor.FilterText = null;
            this.gridSablonRapor.FilterValue = null;
            this.gridSablonRapor.GridlerDuzenlenebilir = true;
            this.gridSablonRapor.GridsFilterControl = null;
            this.gridSablonRapor.ImeMode = System.Windows.Forms.ImeMode.On;
            this.gridSablonRapor.Location = new System.Drawing.Point(0, 0);
            this.gridSablonRapor.MainView = this.gridView1;
            this.gridSablonRapor.MyGridStyle = null;
            this.gridSablonRapor.Name = "gridSablonRapor";
            this.gridSablonRapor.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLuedil,
            this.rLueDavaNeden,
            this.rLueSozlesmeTip,
            this.rLueAdliBirimGorev,
            this.rLueDavaTalep,
            this.rLueTakipTalepKonu,
            this.rLueFormOrnekNo,
            this.rLueModul,
            this.rLueKategori,
            this.rLueAdliBirimBolum,
            this.rLueRaporTip,
            this.rLueSektor});
            this.gridSablonRapor.ShowRowNumbers = false;
            this.gridSablonRapor.SilmeKaldirilsin = false;
            this.gridSablonRapor.Size = new System.Drawing.Size(614, 402);
            this.gridSablonRapor.TabIndex = 1;
            this.gridSablonRapor.TemizleKaldirGorunsunmu = false;
            this.gridSablonRapor.UniqueId = "7f8e0871-f893-4009-ba4d-83c7d203d844";
            this.gridSablonRapor.UseHyperDragDrop = false;
            this.gridSablonRapor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAD,
            this.colACIKLAMA,
            this.colRAPOR_TIP_ID,
            this.colADLI_BIRIM_BOLUM_ID,
            this.colKATEGORI_ID,
            this.colDOSYA_ADRES,
            this.colMODUL_ID,
            this.colFORM_ORNEK_ID,
            this.colTAKIP_TALEP_KONU_ID,
            this.colDAVA_TALEP_ID,
            this.colADLI_BIRIM_GOREV_ID,
            this.colSOZLESME_TIP_ID,
            this.colDAVA_NEDEN_ID,
            this.colDOSYA,
            this.colDIL_ID,
            this.colSEKTOR_ID,
            this.colDEGISKENI_VARMI,
            this.gColSec,
            this.colYAYINDA_MI});
            this.gridView1.GridControl = this.gridSablonRapor;
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView1.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.OptionsView.ShowPreview = true;
            this.gridView1.PreviewFieldName = "ACIKLAMA";
            // 
            // colAD
            // 
            this.colAD.Caption = "Ad";
            this.colAD.FieldName = "AD";
            this.colAD.Name = "colAD";
            this.colAD.Visible = true;
            this.colAD.VisibleIndex = 1;
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açýklama";
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 2;
            // 
            // colRAPOR_TIP_ID
            // 
            this.colRAPOR_TIP_ID.Caption = "Rapor Tip";
            this.colRAPOR_TIP_ID.ColumnEdit = this.rLueRaporTip;
            this.colRAPOR_TIP_ID.FieldName = "RAPOR_TIP_ID";
            this.colRAPOR_TIP_ID.Name = "colRAPOR_TIP_ID";
            this.colRAPOR_TIP_ID.Visible = true;
            this.colRAPOR_TIP_ID.VisibleIndex = 3;
            // 
            // rLueRaporTip
            // 
            this.rLueRaporTip.AutoHeight = false;
            this.rLueRaporTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueRaporTip.Name = "rLueRaporTip";
            // 
            // colADLI_BIRIM_BOLUM_ID
            // 
            this.colADLI_BIRIM_BOLUM_ID.Caption = "Bölüm";
            this.colADLI_BIRIM_BOLUM_ID.ColumnEdit = this.rLueAdliBirimBolum;
            this.colADLI_BIRIM_BOLUM_ID.FieldName = "ADLI_BIRIM_BOLUM_ID";
            this.colADLI_BIRIM_BOLUM_ID.Name = "colADLI_BIRIM_BOLUM_ID";
            this.colADLI_BIRIM_BOLUM_ID.Visible = true;
            this.colADLI_BIRIM_BOLUM_ID.VisibleIndex = 4;
            // 
            // rLueAdliBirimBolum
            // 
            this.rLueAdliBirimBolum.AutoHeight = false;
            this.rLueAdliBirimBolum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimBolum.Name = "rLueAdliBirimBolum";
            // 
            // colKATEGORI_ID
            // 
            this.colKATEGORI_ID.Caption = "Kategori";
            this.colKATEGORI_ID.ColumnEdit = this.rLueKategori;
            this.colKATEGORI_ID.FieldName = "KATEGORI_ID";
            this.colKATEGORI_ID.Name = "colKATEGORI_ID";
            this.colKATEGORI_ID.Visible = true;
            this.colKATEGORI_ID.VisibleIndex = 5;
            // 
            // rLueKategori
            // 
            this.rLueKategori.AutoHeight = false;
            this.rLueKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueKategori.Name = "rLueKategori";
            // 
            // colDOSYA_ADRES
            // 
            this.colDOSYA_ADRES.Caption = "Dosya Adres";
            this.colDOSYA_ADRES.FieldName = "DOSYA_ADRES";
            this.colDOSYA_ADRES.Name = "colDOSYA_ADRES";
            this.colDOSYA_ADRES.Visible = true;
            this.colDOSYA_ADRES.VisibleIndex = 6;
            // 
            // colMODUL_ID
            // 
            this.colMODUL_ID.Caption = "Modul";
            this.colMODUL_ID.ColumnEdit = this.rLueModul;
            this.colMODUL_ID.FieldName = "MODUL_ID";
            this.colMODUL_ID.Name = "colMODUL_ID";
            this.colMODUL_ID.Visible = true;
            this.colMODUL_ID.VisibleIndex = 7;
            // 
            // rLueModul
            // 
            this.rLueModul.AutoHeight = false;
            this.rLueModul.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueModul.Name = "rLueModul";
            // 
            // colFORM_ORNEK_ID
            // 
            this.colFORM_ORNEK_ID.Caption = "Form Örnek";
            this.colFORM_ORNEK_ID.ColumnEdit = this.rLueFormOrnekNo;
            this.colFORM_ORNEK_ID.FieldName = "FORM_ORNEK_ID";
            this.colFORM_ORNEK_ID.Name = "colFORM_ORNEK_ID";
            this.colFORM_ORNEK_ID.Visible = true;
            this.colFORM_ORNEK_ID.VisibleIndex = 8;
            // 
            // rLueFormOrnekNo
            // 
            this.rLueFormOrnekNo.AutoHeight = false;
            this.rLueFormOrnekNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueFormOrnekNo.Name = "rLueFormOrnekNo";
            // 
            // colTAKIP_TALEP_KONU_ID
            // 
            this.colTAKIP_TALEP_KONU_ID.Caption = "Takip Talep";
            this.colTAKIP_TALEP_KONU_ID.ColumnEdit = this.rLueTakipTalepKonu;
            this.colTAKIP_TALEP_KONU_ID.FieldName = "TAKIP_TALEP_KONU_ID";
            this.colTAKIP_TALEP_KONU_ID.Name = "colTAKIP_TALEP_KONU_ID";
            this.colTAKIP_TALEP_KONU_ID.Visible = true;
            this.colTAKIP_TALEP_KONU_ID.VisibleIndex = 9;
            // 
            // rLueTakipTalepKonu
            // 
            this.rLueTakipTalepKonu.AutoHeight = false;
            this.rLueTakipTalepKonu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTakipTalepKonu.Name = "rLueTakipTalepKonu";
            // 
            // colDAVA_TALEP_ID
            // 
            this.colDAVA_TALEP_ID.Caption = "Dava Talep";
            this.colDAVA_TALEP_ID.ColumnEdit = this.rLueDavaTalep;
            this.colDAVA_TALEP_ID.FieldName = "DAVA_TALEP_ID";
            this.colDAVA_TALEP_ID.Name = "colDAVA_TALEP_ID";
            this.colDAVA_TALEP_ID.Visible = true;
            this.colDAVA_TALEP_ID.VisibleIndex = 10;
            // 
            // rLueDavaTalep
            // 
            this.rLueDavaTalep.AutoHeight = false;
            this.rLueDavaTalep.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDavaTalep.Name = "rLueDavaTalep";
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
            // colSOZLESME_TIP_ID
            // 
            this.colSOZLESME_TIP_ID.Caption = "Sözleþme Tip";
            this.colSOZLESME_TIP_ID.ColumnEdit = this.rLueSozlesmeTip;
            this.colSOZLESME_TIP_ID.FieldName = "SOZLESME_TIP_ID";
            this.colSOZLESME_TIP_ID.Name = "colSOZLESME_TIP_ID";
            this.colSOZLESME_TIP_ID.Visible = true;
            this.colSOZLESME_TIP_ID.VisibleIndex = 12;
            // 
            // rLueSozlesmeTip
            // 
            this.rLueSozlesmeTip.AutoHeight = false;
            this.rLueSozlesmeTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSozlesmeTip.Name = "rLueSozlesmeTip";
            // 
            // colDAVA_NEDEN_ID
            // 
            this.colDAVA_NEDEN_ID.Caption = "Dava Neden";
            this.colDAVA_NEDEN_ID.ColumnEdit = this.rLueDavaNeden;
            this.colDAVA_NEDEN_ID.FieldName = "DAVA_NEDEN_ID";
            this.colDAVA_NEDEN_ID.Name = "colDAVA_NEDEN_ID";
            this.colDAVA_NEDEN_ID.Visible = true;
            this.colDAVA_NEDEN_ID.VisibleIndex = 13;
            // 
            // rLueDavaNeden
            // 
            this.rLueDavaNeden.AutoHeight = false;
            this.rLueDavaNeden.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDavaNeden.Name = "rLueDavaNeden";
            // 
            // colDOSYA
            // 
            this.colDOSYA.Caption = "Dosya";
            this.colDOSYA.FieldName = "DOSYA";
            this.colDOSYA.Name = "colDOSYA";
            this.colDOSYA.Visible = true;
            this.colDOSYA.VisibleIndex = 14;
            // 
            // colDIL_ID
            // 
            this.colDIL_ID.Caption = "Dil";
            this.colDIL_ID.ColumnEdit = this.rLuedil;
            this.colDIL_ID.FieldName = "DIL_ID";
            this.colDIL_ID.Name = "colDIL_ID";
            this.colDIL_ID.Visible = true;
            this.colDIL_ID.VisibleIndex = 15;
            // 
            // rLuedil
            // 
            this.rLuedil.AutoHeight = false;
            this.rLuedil.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLuedil.Name = "rLuedil";
            // 
            // colSEKTOR_ID
            // 
            this.colSEKTOR_ID.Caption = "Sektör";
            this.colSEKTOR_ID.ColumnEdit = this.rLueSektor;
            this.colSEKTOR_ID.FieldName = "SEKTOR_ID";
            this.colSEKTOR_ID.Name = "colSEKTOR_ID";
            this.colSEKTOR_ID.Visible = true;
            this.colSEKTOR_ID.VisibleIndex = 16;
            // 
            // rLueSektor
            // 
            this.rLueSektor.AutoHeight = false;
            this.rLueSektor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSektor.Name = "rLueSektor";
            // 
            // colDEGISKENI_VARMI
            // 
            this.colDEGISKENI_VARMI.Caption = "Deðiþken Varmý";
            this.colDEGISKENI_VARMI.FieldName = "DEGISKENI_VARMI";
            this.colDEGISKENI_VARMI.Name = "colDEGISKENI_VARMI";
            this.colDEGISKENI_VARMI.Visible = true;
            this.colDEGISKENI_VARMI.VisibleIndex = 17;
            // 
            // gColSec
            // 
            this.gColSec.Caption = "Seç";
            this.gColSec.FieldName = "IsSelected";
            this.gColSec.Name = "gColSec";
            this.gColSec.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.gColSec.Visible = true;
            this.gColSec.VisibleIndex = 0;
            // 
            // colYAYINDA_MI
            // 
            this.colYAYINDA_MI.Caption = "Yayýnda mý";
            this.colYAYINDA_MI.FieldName = "YAYINDA_MI";
            this.colYAYINDA_MI.Name = "colYAYINDA_MI";
            this.colYAYINDA_MI.Visible = true;
            this.colYAYINDA_MI.VisibleIndex = 18;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.simpleButton1.Location = new System.Drawing.Point(0, 425);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(614, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Sil";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.simpleButton2.Location = new System.Drawing.Point(0, 402);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(614, 23);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "Kaydet";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // ucSablonRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridSablonRapor);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Name = "ucSablonRapor";
            this.Size = new System.Drawing.Size(614, 448);
            this.Load += new System.EventHandler(this.ucSablonRapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSablonRapor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueRaporTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimBolum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFormOrnekNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTakipTalepKonu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDavaTalep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimGorev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSozlesmeTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDavaNeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLuedil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSektor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colAD;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colRAPOR_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_BOLUM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colKATEGORI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDOSYA_ADRES;
        private DevExpress.XtraGrid.Columns.GridColumn colMODUL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colFORM_ORNEK_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTAKIP_TALEP_KONU_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDAVA_TALEP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_GOREV_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSOZLESME_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDAVA_NEDEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDOSYA;
        private DevExpress.XtraGrid.Columns.GridColumn colDIL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSEKTOR_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDEGISKENI_VARMI;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSozlesmeTip;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDavaNeden;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLuedil;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueRaporTip;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimBolum;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueKategori;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueModul;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueFormOrnekNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTakipTalepKonu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDavaTalep;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimGorev;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSektor;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraGrid.Columns.GridColumn gColSec;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        public AdimAdimDavaKaydi.Util.ExtendedGridControl gridSablonRapor;
        private DevExpress.XtraGrid.Columns.GridColumn colYAYINDA_MI;

    }
}
