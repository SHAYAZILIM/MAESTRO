namespace AdimAdimDavaKaydi.Entegrasyon
{
    partial class frmKlasorSec
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
            this.cmsKlasorSec = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seçToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.sbtnBagimsizTakipAc = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnYeniKlasor = new DevExpress.XtraEditors.SimpleButton();
            this.gcDosyalar = new DevExpress.XtraGrid.GridControl();
            this.gvDosyalar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFOY_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADLI_BIRIM_NO_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADLI_BIRIM_GOREV_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueTarafCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTARAF_SIFAT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueTarafSifat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTARAF_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueTarafKodu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSORUMLU_AVUKAT_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueSorumluAvukat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colYETKILI_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDURUM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueDosyaDurum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKLASOR_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueKlasor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmsKlasorSec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDosyalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDosyalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdliye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueGorev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTarafCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTarafSifat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTarafKodu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueSorumluAvukat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDosyaDurum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueKlasor)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsKlasorSec
            // 
            this.cmsKlasorSec.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seçToolStripMenuItem});
            this.cmsKlasorSec.Name = "cmsKlasorSec";
            this.cmsKlasorSec.Size = new System.Drawing.Size(93, 26);
            // 
            // seçToolStripMenuItem
            // 
            this.seçToolStripMenuItem.Image = global::AdimAdimDavaKaydi.Properties.Resources.sec;
            this.seçToolStripMenuItem.Name = "seçToolStripMenuItem";
            this.seçToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.seçToolStripMenuItem.Text = "Seç";
            this.seçToolStripMenuItem.Click += new System.EventHandler(this.seçToolStripMenuItem_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.sbtnBagimsizTakipAc);
            this.panelControl1.Controls.Add(this.sbtnYeniKlasor);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 410);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(907, 44);
            this.panelControl1.TabIndex = 1;
            // 
            // sbtnBagimsizTakipAc
            // 
            this.sbtnBagimsizTakipAc.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnBagimsizTakipAc.Appearance.ForeColor = System.Drawing.Color.Red;
            this.sbtnBagimsizTakipAc.Appearance.Options.UseFont = true;
            this.sbtnBagimsizTakipAc.Appearance.Options.UseForeColor = true;
            this.sbtnBagimsizTakipAc.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbtnBagimsizTakipAc.Location = new System.Drawing.Point(609, 2);
            this.sbtnBagimsizTakipAc.Name = "sbtnBagimsizTakipAc";
            this.sbtnBagimsizTakipAc.Size = new System.Drawing.Size(148, 40);
            this.sbtnBagimsizTakipAc.TabIndex = 1;
            this.sbtnBagimsizTakipAc.Text = "BAĞIMSIZ TAKİP AÇ";
            this.sbtnBagimsizTakipAc.Click += new System.EventHandler(this.sbtnBagimsizTakipAc_Click);
            // 
            // sbtnYeniKlasor
            // 
            this.sbtnYeniKlasor.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnYeniKlasor.Appearance.ForeColor = System.Drawing.Color.Red;
            this.sbtnYeniKlasor.Appearance.Options.UseFont = true;
            this.sbtnYeniKlasor.Appearance.Options.UseForeColor = true;
            this.sbtnYeniKlasor.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbtnYeniKlasor.Location = new System.Drawing.Point(757, 2);
            this.sbtnYeniKlasor.Name = "sbtnYeniKlasor";
            this.sbtnYeniKlasor.Size = new System.Drawing.Size(148, 40);
            this.sbtnYeniKlasor.TabIndex = 0;
            this.sbtnYeniKlasor.Text = "YENİ KLASÖR";
            this.sbtnYeniKlasor.Click += new System.EventHandler(this.sbtnYeniKlasor_Click);
            // 
            // gcDosyalar
            // 
            this.gcDosyalar.ContextMenuStrip = this.cmsKlasorSec;
            this.gcDosyalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDosyalar.Location = new System.Drawing.Point(0, 0);
            this.gcDosyalar.MainView = this.gvDosyalar;
            this.gcDosyalar.Name = "gcDosyalar";
            this.gcDosyalar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueAdliye,
            this.rlueNo,
            this.rlueGorev,
            this.rlueTarafCari,
            this.rlueTarafSifat,
            this.rlueTarafKodu,
            this.rlueSorumluAvukat,
            this.rlueDosyaDurum,
            this.rlueKlasor});
            this.gcDosyalar.Size = new System.Drawing.Size(907, 410);
            this.gcDosyalar.TabIndex = 2;
            this.gcDosyalar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDosyalar});
            // 
            // gvDosyalar
            // 
            this.gvDosyalar.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvDosyalar.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvDosyalar.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvDosyalar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colESAS_NO,
            this.colFOY_NO,
            this.colADLI_BIRIM_ADLIYE_ID,
            this.colADLI_BIRIM_NO_ID,
            this.colADLI_BIRIM_GOREV_ID,
            this.colTARIH,
            this.colCARI_ID,
            this.colTARAF_SIFAT_ID,
            this.colTARAF_KODU,
            this.colSORUMLU_AVUKAT_CARI_ID,
            this.colYETKILI_MI,
            this.colDURUM_ID,
            this.colTIPI,
            this.colKLASOR_ID,
            this.colACIKLAMA});
            this.gvDosyalar.GridControl = this.gcDosyalar;
            this.gvDosyalar.GroupCount = 4;
            this.gvDosyalar.Name = "gvDosyalar";
            this.gvDosyalar.OptionsView.ColumnAutoWidth = false;
            this.gvDosyalar.OptionsView.ShowGroupPanel = false;
            this.gvDosyalar.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colACIKLAMA, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTIPI, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFOY_NO, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCARI_ID, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colESAS_NO
            // 
            this.colESAS_NO.Caption = "Dosya No";
            this.colESAS_NO.FieldName = "ESAS_NO";
            this.colESAS_NO.Name = "colESAS_NO";
            this.colESAS_NO.Visible = true;
            this.colESAS_NO.VisibleIndex = 0;
            this.colESAS_NO.Width = 130;
            // 
            // colFOY_NO
            // 
            this.colFOY_NO.Caption = "Raf No";
            this.colFOY_NO.FieldName = "FOY_NO";
            this.colFOY_NO.Name = "colFOY_NO";
            this.colFOY_NO.Visible = true;
            this.colFOY_NO.VisibleIndex = 1;
            this.colFOY_NO.Width = 180;
            // 
            // colADLI_BIRIM_ADLIYE_ID
            // 
            this.colADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
            this.colADLI_BIRIM_ADLIYE_ID.ColumnEdit = this.rlueAdliye;
            this.colADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
            this.colADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 1;
            this.colADLI_BIRIM_ADLIYE_ID.Width = 157;
            // 
            // rlueAdliye
            // 
            this.rlueAdliye.AutoHeight = false;
            this.rlueAdliye.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueAdliye.Name = "rlueAdliye";
            // 
            // colADLI_BIRIM_NO_ID
            // 
            this.colADLI_BIRIM_NO_ID.Caption = "No";
            this.colADLI_BIRIM_NO_ID.ColumnEdit = this.rlueNo;
            this.colADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            this.colADLI_BIRIM_NO_ID.Name = "colADLI_BIRIM_NO_ID";
            this.colADLI_BIRIM_NO_ID.Visible = true;
            this.colADLI_BIRIM_NO_ID.VisibleIndex = 2;
            this.colADLI_BIRIM_NO_ID.Width = 48;
            // 
            // rlueNo
            // 
            this.rlueNo.AutoHeight = false;
            this.rlueNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueNo.Name = "rlueNo";
            // 
            // colADLI_BIRIM_GOREV_ID
            // 
            this.colADLI_BIRIM_GOREV_ID.Caption = "Görev";
            this.colADLI_BIRIM_GOREV_ID.ColumnEdit = this.rlueGorev;
            this.colADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.colADLI_BIRIM_GOREV_ID.Name = "colADLI_BIRIM_GOREV_ID";
            this.colADLI_BIRIM_GOREV_ID.Visible = true;
            this.colADLI_BIRIM_GOREV_ID.VisibleIndex = 3;
            this.colADLI_BIRIM_GOREV_ID.Width = 84;
            // 
            // rlueGorev
            // 
            this.rlueGorev.AutoHeight = false;
            this.rlueGorev.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueGorev.Name = "rlueGorev";
            // 
            // colTARIH
            // 
            this.colTARIH.Caption = "Tarih";
            this.colTARIH.FieldName = "TARIH";
            this.colTARIH.Name = "colTARIH";
            this.colTARIH.Visible = true;
            this.colTARIH.VisibleIndex = 4;
            this.colTARIH.Width = 108;
            // 
            // colCARI_ID
            // 
            this.colCARI_ID.Caption = "Taraf";
            this.colCARI_ID.ColumnEdit = this.rlueTarafCari;
            this.colCARI_ID.FieldName = "CARI_ID";
            this.colCARI_ID.Name = "colCARI_ID";
            // 
            // rlueTarafCari
            // 
            this.rlueTarafCari.AutoHeight = false;
            this.rlueTarafCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueTarafCari.Name = "rlueTarafCari";
            // 
            // colTARAF_SIFAT_ID
            // 
            this.colTARAF_SIFAT_ID.Caption = "Taraf Sıfat";
            this.colTARAF_SIFAT_ID.ColumnEdit = this.rlueTarafSifat;
            this.colTARAF_SIFAT_ID.FieldName = "TARAF_SIFAT_ID";
            this.colTARAF_SIFAT_ID.Name = "colTARAF_SIFAT_ID";
            this.colTARAF_SIFAT_ID.Visible = true;
            this.colTARAF_SIFAT_ID.VisibleIndex = 5;
            this.colTARAF_SIFAT_ID.Width = 86;
            // 
            // rlueTarafSifat
            // 
            this.rlueTarafSifat.AutoHeight = false;
            this.rlueTarafSifat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueTarafSifat.Name = "rlueTarafSifat";
            // 
            // colTARAF_KODU
            // 
            this.colTARAF_KODU.Caption = "Taraf Kodu";
            this.colTARAF_KODU.ColumnEdit = this.rlueTarafKodu;
            this.colTARAF_KODU.FieldName = "TARAF_KODU";
            this.colTARAF_KODU.Name = "colTARAF_KODU";
            this.colTARAF_KODU.Visible = true;
            this.colTARAF_KODU.VisibleIndex = 6;
            this.colTARAF_KODU.Width = 86;
            // 
            // rlueTarafKodu
            // 
            this.rlueTarafKodu.AutoHeight = false;
            this.rlueTarafKodu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueTarafKodu.Name = "rlueTarafKodu";
            // 
            // colSORUMLU_AVUKAT_CARI_ID
            // 
            this.colSORUMLU_AVUKAT_CARI_ID.Caption = "Sorumlu Avukat";
            this.colSORUMLU_AVUKAT_CARI_ID.ColumnEdit = this.rlueSorumluAvukat;
            this.colSORUMLU_AVUKAT_CARI_ID.FieldName = "SORUMLU_AVUKAT_CARI_ID";
            this.colSORUMLU_AVUKAT_CARI_ID.Name = "colSORUMLU_AVUKAT_CARI_ID";
            this.colSORUMLU_AVUKAT_CARI_ID.Visible = true;
            this.colSORUMLU_AVUKAT_CARI_ID.VisibleIndex = 7;
            this.colSORUMLU_AVUKAT_CARI_ID.Width = 205;
            // 
            // rlueSorumluAvukat
            // 
            this.rlueSorumluAvukat.AutoHeight = false;
            this.rlueSorumluAvukat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueSorumluAvukat.Name = "rlueSorumluAvukat";
            // 
            // colYETKILI_MI
            // 
            this.colYETKILI_MI.Caption = "İzleyen mi ?";
            this.colYETKILI_MI.FieldName = "YETKILI_MI";
            this.colYETKILI_MI.Name = "colYETKILI_MI";
            this.colYETKILI_MI.Visible = true;
            this.colYETKILI_MI.VisibleIndex = 8;
            this.colYETKILI_MI.Width = 80;
            // 
            // colDURUM_ID
            // 
            this.colDURUM_ID.Caption = "Dosya Durum";
            this.colDURUM_ID.ColumnEdit = this.rlueDosyaDurum;
            this.colDURUM_ID.FieldName = "DURUM_ID";
            this.colDURUM_ID.Name = "colDURUM_ID";
            this.colDURUM_ID.Visible = true;
            this.colDURUM_ID.VisibleIndex = 9;
            this.colDURUM_ID.Width = 134;
            // 
            // rlueDosyaDurum
            // 
            this.rlueDosyaDurum.AutoHeight = false;
            this.rlueDosyaDurum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueDosyaDurum.Name = "rlueDosyaDurum";
            // 
            // colTIPI
            // 
            this.colTIPI.Caption = "Tipi";
            this.colTIPI.FieldName = "TIPI";
            this.colTIPI.Name = "colTIPI";
            // 
            // colKLASOR_ID
            // 
            this.colKLASOR_ID.Caption = "Kredi Dosyası";
            this.colKLASOR_ID.ColumnEdit = this.rlueKlasor;
            this.colKLASOR_ID.FieldName = "KLASOR";
            this.colKLASOR_ID.Name = "colKLASOR_ID";
            // 
            // rlueKlasor
            // 
            this.rlueKlasor.AutoHeight = false;
            this.rlueKlasor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueKlasor.Name = "rlueKlasor";
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açıklama";
            this.colACIKLAMA.FieldName = "DOSYA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            // 
            // frmKlasorSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 454);
            this.Controls.Add(this.gcDosyalar);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmKlasorSec";
            this.Text = "Klasör Seçme Ekranı";
            this.Load += new System.EventHandler(this.frmKlasorSec_Load);
            this.cmsKlasorSec.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDosyalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDosyalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdliye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueGorev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTarafCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTarafSifat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTarafKodu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueSorumluAvukat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDosyaDurum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueKlasor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton sbtnYeniKlasor;
        private DevExpress.XtraEditors.SimpleButton sbtnBagimsizTakipAc;
        private System.Windows.Forms.ContextMenuStrip cmsKlasorSec;
        private System.Windows.Forms.ToolStripMenuItem seçToolStripMenuItem;
        private DevExpress.XtraGrid.GridControl gcDosyalar;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDosyalar;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colESAS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colFOY_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_ADLIYE_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAdliye;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_NO_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueNo;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_GOREV_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueGorev;
        private DevExpress.XtraGrid.Columns.GridColumn colTARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colCARI_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueTarafCari;
        private DevExpress.XtraGrid.Columns.GridColumn colTARAF_SIFAT_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueTarafSifat;
        private DevExpress.XtraGrid.Columns.GridColumn colTARAF_KODU;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueTarafKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colSORUMLU_AVUKAT_CARI_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueSorumluAvukat;
        private DevExpress.XtraGrid.Columns.GridColumn colYETKILI_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colDURUM_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueDosyaDurum;
        private DevExpress.XtraGrid.Columns.GridColumn colTIPI;
        private DevExpress.XtraGrid.Columns.GridColumn colKLASOR_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueKlasor;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
    }
}