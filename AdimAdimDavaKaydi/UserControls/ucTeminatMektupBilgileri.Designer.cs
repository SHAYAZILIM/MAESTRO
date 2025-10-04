namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucTeminatMektupBilgileri
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
            this.exgrdTwminatMaktup = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMEKTUP_KONU_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueMektupKonu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBANKA_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBanka = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSUBE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBSube = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colHESAP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colREFERANS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSURE_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVADE_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTUTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTUTARI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTAZMIN_TALEP_BASLANGIC_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAZMIN_TALEP_BITIS_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAZMIN_TUTARI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAZMIN_TUTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEMINAT_TURU_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueTeminatTuru = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTEMINAT_TUTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEMINAT_TUTARI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLEHTAR_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTEMINAT_IADE_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMUVEKKILE_TESLIM_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTESLIM_ALAN_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADLI_BIRIM_GOREV_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADLI_BIRIM_NO_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBirim = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exgrdTwminatMaktup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMektupKonu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBanka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBSube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTeminatTuru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGorev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBirim)).BeginInit();
            this.SuspendLayout();
            // 
            // exgrdTwminatMaktup
            // 
            this.exgrdTwminatMaktup.CustomButtonlarGorunmesin = false;
            this.exgrdTwminatMaktup.DataSource = this.bindingSource1;
            this.exgrdTwminatMaktup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exgrdTwminatMaktup.DoNotExtendEmbedNavigator = false;
            this.exgrdTwminatMaktup.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.exgrdTwminatMaktup.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayıt", "FormAc")});
            this.exgrdTwminatMaktup.FilterText = null;
            this.exgrdTwminatMaktup.FilterValue = null;
            this.exgrdTwminatMaktup.GridlerDuzenlenebilir = true;
            this.exgrdTwminatMaktup.GridsFilterControl = null;
            this.exgrdTwminatMaktup.Location = new System.Drawing.Point(0, 0);
            this.exgrdTwminatMaktup.MainView = this.gridView1;
            this.exgrdTwminatMaktup.MyGridStyle = null;
            this.exgrdTwminatMaktup.Name = "exgrdTwminatMaktup";
            this.exgrdTwminatMaktup.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueTip,
            this.rLueMektupKonu,
            this.rLueBanka,
            this.rLueBSube,
            this.rLueDoviz,
            this.rLueTeminatTuru,
            this.rLueCari,
            this.rLueAdliye,
            this.rLueGorev,
            this.rLueBirim});
            this.exgrdTwminatMaktup.ShowRowNumbers = false;
            this.exgrdTwminatMaktup.Size = new System.Drawing.Size(697, 425);
            this.exgrdTwminatMaktup.TabIndex = 0;
            this.exgrdTwminatMaktup.TemizleKaldirGorunsunmu = false;
            this.exgrdTwminatMaktup.UniqueId = "2ec33e24-ca2c-4d2f-aa70-72db1ee03f0a";
            this.exgrdTwminatMaktup.UseEmbeddedNavigator = true;
            this.exgrdTwminatMaktup.UseHyperDragDrop = false;
            this.exgrdTwminatMaktup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(AvukatProLib2.Entities.R_BIRLESIK_TAKIPLER_TEMINAT_MEKTUP);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTIP_ID,
            this.colMEKTUP_KONU_ID,
            this.colBANKA_ID,
            this.colSUBE_ID,
            this.colHESAP_NO,
            this.colTARIHI,
            this.colREFERANS_NO,
            this.colSURE_TIP,
            this.colVADE_TARIHI,
            this.colTUTARI,
            this.colTUTARI_DOVIZ_ID,
            this.colTAZMIN_TALEP_BASLANGIC_TARIHI,
            this.colTAZMIN_TALEP_BITIS_TARIHI,
            this.colODEME_TARIHI,
            this.colTAZMIN_TUTARI_DOVIZ_ID,
            this.colTAZMIN_TUTARI,
            this.colTEMINAT_TURU_ID,
            this.colTEMINAT_TUTARI,
            this.colTEMINAT_TUTARI_DOVIZ_ID,
            this.colLEHTAR_CARI_ID,
            this.colTEMINAT_IADE_TARIHI,
            this.colMUVEKKILE_TESLIM_TARIHI,
            this.colTESLIM_ALAN_CARI_ID,
            this.colADLI_BIRIM_ADLIYE_ID,
            this.colADLI_BIRIM_GOREV_ID,
            this.colADLI_BIRIM_NO_ID,
            this.colESAS_NO});
            this.gridView1.GridControl = this.exgrdTwminatMaktup;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "")});
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            // 
            // colTIP_ID
            // 
            this.colTIP_ID.Caption = "Tip";
            this.colTIP_ID.ColumnEdit = this.rLueTip;
            this.colTIP_ID.FieldName = "TIP_ID";
            this.colTIP_ID.Name = "colTIP_ID";
            this.colTIP_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colTIP_ID.Visible = true;
            this.colTIP_ID.VisibleIndex = 0;
            // 
            // rLueTip
            // 
            this.rLueTip.AutoHeight = false;
            this.rLueTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTip.Name = "rLueTip";
            // 
            // colMEKTUP_KONU_ID
            // 
            this.colMEKTUP_KONU_ID.Caption = "Konu";
            this.colMEKTUP_KONU_ID.ColumnEdit = this.rLueMektupKonu;
            this.colMEKTUP_KONU_ID.FieldName = "MEKTUP_KONU_ID";
            this.colMEKTUP_KONU_ID.Name = "colMEKTUP_KONU_ID";
            this.colMEKTUP_KONU_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colMEKTUP_KONU_ID.Visible = true;
            this.colMEKTUP_KONU_ID.VisibleIndex = 1;
            // 
            // rLueMektupKonu
            // 
            this.rLueMektupKonu.AutoHeight = false;
            this.rLueMektupKonu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMektupKonu.Name = "rLueMektupKonu";
            // 
            // colBANKA_ID
            // 
            this.colBANKA_ID.Caption = "Banka";
            this.colBANKA_ID.ColumnEdit = this.rLueBanka;
            this.colBANKA_ID.FieldName = "BANKA_ID";
            this.colBANKA_ID.Name = "colBANKA_ID";
            this.colBANKA_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colBANKA_ID.Visible = true;
            this.colBANKA_ID.VisibleIndex = 2;
            // 
            // rLueBanka
            // 
            this.rLueBanka.AutoHeight = false;
            this.rLueBanka.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBanka.Name = "rLueBanka";
            // 
            // colSUBE_ID
            // 
            this.colSUBE_ID.Caption = "Şube";
            this.colSUBE_ID.ColumnEdit = this.rLueBSube;
            this.colSUBE_ID.FieldName = "SUBE_ID";
            this.colSUBE_ID.Name = "colSUBE_ID";
            this.colSUBE_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colSUBE_ID.Visible = true;
            this.colSUBE_ID.VisibleIndex = 3;
            // 
            // rLueBSube
            // 
            this.rLueBSube.AutoHeight = false;
            this.rLueBSube.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBSube.Name = "rLueBSube";
            // 
            // colHESAP_NO
            // 
            this.colHESAP_NO.Caption = "Hesap No";
            this.colHESAP_NO.FieldName = "HESAP_NO";
            this.colHESAP_NO.Name = "colHESAP_NO";
            this.colHESAP_NO.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHESAP_NO.Visible = true;
            this.colHESAP_NO.VisibleIndex = 4;
            // 
            // colTARIHI
            // 
            this.colTARIHI.Caption = "Tarih";
            this.colTARIHI.FieldName = "TARIHI";
            this.colTARIHI.Name = "colTARIHI";
            this.colTARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTARIHI.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colTARIHI.Visible = true;
            this.colTARIHI.VisibleIndex = 5;
            // 
            // colREFERANS_NO
            // 
            this.colREFERANS_NO.Caption = "Referans No";
            this.colREFERANS_NO.FieldName = "REFERANS_NO";
            this.colREFERANS_NO.Name = "colREFERANS_NO";
            this.colREFERANS_NO.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colREFERANS_NO.Visible = true;
            this.colREFERANS_NO.VisibleIndex = 6;
            // 
            // colSURE_TIP
            // 
            this.colSURE_TIP.Caption = "Süre";
            this.colSURE_TIP.FieldName = "SURE_TIP";
            this.colSURE_TIP.Name = "colSURE_TIP";
            this.colSURE_TIP.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSURE_TIP.Visible = true;
            this.colSURE_TIP.VisibleIndex = 7;
            // 
            // colVADE_TARIHI
            // 
            this.colVADE_TARIHI.Caption = "Vade Tarihi";
            this.colVADE_TARIHI.FieldName = "VADE_TARIHI";
            this.colVADE_TARIHI.Name = "colVADE_TARIHI";
            this.colVADE_TARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colVADE_TARIHI.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colVADE_TARIHI.Visible = true;
            this.colVADE_TARIHI.VisibleIndex = 8;
            // 
            // colTUTARI
            // 
            this.colTUTARI.Caption = "Tutar";
            this.colTUTARI.FieldName = "TUTARI";
            this.colTUTARI.Name = "colTUTARI";
            this.colTUTARI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTUTARI.Visible = true;
            this.colTUTARI.VisibleIndex = 9;
            // 
            // colTUTARI_DOVIZ_ID
            // 
            this.colTUTARI_DOVIZ_ID.ColumnEdit = this.rLueDoviz;
            this.colTUTARI_DOVIZ_ID.FieldName = "TUTARI_DOVIZ_ID";
            this.colTUTARI_DOVIZ_ID.Name = "colTUTARI_DOVIZ_ID";
            this.colTUTARI_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colTUTARI_DOVIZ_ID.ToolTip = "TUTARI Birim";
            this.colTUTARI_DOVIZ_ID.Visible = true;
            this.colTUTARI_DOVIZ_ID.VisibleIndex = 10;
            this.colTUTARI_DOVIZ_ID.Width = 30;
            // 
            // rLueDoviz
            // 
            this.rLueDoviz.AutoHeight = false;
            this.rLueDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDoviz.Name = "rLueDoviz";
            // 
            // colTAZMIN_TALEP_BASLANGIC_TARIHI
            // 
            this.colTAZMIN_TALEP_BASLANGIC_TARIHI.Caption = "Tanzim Başlangıç T";
            this.colTAZMIN_TALEP_BASLANGIC_TARIHI.FieldName = "TAZMIN_TALEP_BASLANGIC_TARIHI";
            this.colTAZMIN_TALEP_BASLANGIC_TARIHI.Name = "colTAZMIN_TALEP_BASLANGIC_TARIHI";
            this.colTAZMIN_TALEP_BASLANGIC_TARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTAZMIN_TALEP_BASLANGIC_TARIHI.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colTAZMIN_TALEP_BASLANGIC_TARIHI.Visible = true;
            this.colTAZMIN_TALEP_BASLANGIC_TARIHI.VisibleIndex = 11;
            // 
            // colTAZMIN_TALEP_BITIS_TARIHI
            // 
            this.colTAZMIN_TALEP_BITIS_TARIHI.Caption = "Tanzim Bitiş T";
            this.colTAZMIN_TALEP_BITIS_TARIHI.FieldName = "TAZMIN_TALEP_BITIS_TARIHI";
            this.colTAZMIN_TALEP_BITIS_TARIHI.Name = "colTAZMIN_TALEP_BITIS_TARIHI";
            this.colTAZMIN_TALEP_BITIS_TARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTAZMIN_TALEP_BITIS_TARIHI.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colTAZMIN_TALEP_BITIS_TARIHI.Visible = true;
            this.colTAZMIN_TALEP_BITIS_TARIHI.VisibleIndex = 12;
            // 
            // colODEME_TARIHI
            // 
            this.colODEME_TARIHI.Caption = "Ödeme T";
            this.colODEME_TARIHI.FieldName = "ODEME_TARIHI";
            this.colODEME_TARIHI.Name = "colODEME_TARIHI";
            this.colODEME_TARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colODEME_TARIHI.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colODEME_TARIHI.Visible = true;
            this.colODEME_TARIHI.VisibleIndex = 13;
            // 
            // colTAZMIN_TUTARI_DOVIZ_ID
            // 
            this.colTAZMIN_TUTARI_DOVIZ_ID.ColumnEdit = this.rLueDoviz;
            this.colTAZMIN_TUTARI_DOVIZ_ID.FieldName = "TAZMIN_TUTARI_DOVIZ_ID";
            this.colTAZMIN_TUTARI_DOVIZ_ID.Name = "colTAZMIN_TUTARI_DOVIZ_ID";
            this.colTAZMIN_TUTARI_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colTAZMIN_TUTARI_DOVIZ_ID.ToolTip = "TAZMIN TUTARI Birim";
            this.colTAZMIN_TUTARI_DOVIZ_ID.Visible = true;
            this.colTAZMIN_TUTARI_DOVIZ_ID.VisibleIndex = 14;
            this.colTAZMIN_TUTARI_DOVIZ_ID.Width = 30;
            // 
            // colTAZMIN_TUTARI
            // 
            this.colTAZMIN_TUTARI.Caption = "Tanzim Tutarı";
            this.colTAZMIN_TUTARI.FieldName = "TAZMIN_TUTARI";
            this.colTAZMIN_TUTARI.Name = "colTAZMIN_TUTARI";
            this.colTAZMIN_TUTARI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTAZMIN_TUTARI.Visible = true;
            this.colTAZMIN_TUTARI.VisibleIndex = 15;
            // 
            // colTEMINAT_TURU_ID
            // 
            this.colTEMINAT_TURU_ID.Caption = "Teminat Türü";
            this.colTEMINAT_TURU_ID.ColumnEdit = this.rLueTeminatTuru;
            this.colTEMINAT_TURU_ID.FieldName = "TEMINAT_TURU_ID";
            this.colTEMINAT_TURU_ID.Name = "colTEMINAT_TURU_ID";
            this.colTEMINAT_TURU_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colTEMINAT_TURU_ID.Visible = true;
            this.colTEMINAT_TURU_ID.VisibleIndex = 16;
            // 
            // rLueTeminatTuru
            // 
            this.rLueTeminatTuru.AutoHeight = false;
            this.rLueTeminatTuru.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTeminatTuru.Name = "rLueTeminatTuru";
            // 
            // colTEMINAT_TUTARI
            // 
            this.colTEMINAT_TUTARI.Caption = "TeminatTutarı";
            this.colTEMINAT_TUTARI.FieldName = "TEMINAT_TUTARI";
            this.colTEMINAT_TUTARI.Name = "colTEMINAT_TUTARI";
            this.colTEMINAT_TUTARI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTEMINAT_TUTARI.Visible = true;
            this.colTEMINAT_TUTARI.VisibleIndex = 17;
            // 
            // colTEMINAT_TUTARI_DOVIZ_ID
            // 
            this.colTEMINAT_TUTARI_DOVIZ_ID.ColumnEdit = this.rLueDoviz;
            this.colTEMINAT_TUTARI_DOVIZ_ID.FieldName = "TEMINAT_TUTARI_DOVIZ_ID";
            this.colTEMINAT_TUTARI_DOVIZ_ID.Name = "colTEMINAT_TUTARI_DOVIZ_ID";
            this.colTEMINAT_TUTARI_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colTEMINAT_TUTARI_DOVIZ_ID.ToolTip = "TEMINAT TUTARI Birim";
            this.colTEMINAT_TUTARI_DOVIZ_ID.Visible = true;
            this.colTEMINAT_TUTARI_DOVIZ_ID.VisibleIndex = 18;
            this.colTEMINAT_TUTARI_DOVIZ_ID.Width = 30;
            // 
            // colLEHTAR_CARI_ID
            // 
            this.colLEHTAR_CARI_ID.Caption = "Cari";
            this.colLEHTAR_CARI_ID.ColumnEdit = this.rLueCari;
            this.colLEHTAR_CARI_ID.FieldName = "LEHTAR_CARI_ID";
            this.colLEHTAR_CARI_ID.Name = "colLEHTAR_CARI_ID";
            this.colLEHTAR_CARI_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colLEHTAR_CARI_ID.Visible = true;
            this.colLEHTAR_CARI_ID.VisibleIndex = 19;
            // 
            // rLueCari
            // 
            this.rLueCari.AutoHeight = false;
            this.rLueCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueCari.Name = "rLueCari";
            // 
            // colTEMINAT_IADE_TARIHI
            // 
            this.colTEMINAT_IADE_TARIHI.Caption = "Teminat İade T";
            this.colTEMINAT_IADE_TARIHI.FieldName = "TEMINAT_IADE_TARIHI";
            this.colTEMINAT_IADE_TARIHI.Name = "colTEMINAT_IADE_TARIHI";
            this.colTEMINAT_IADE_TARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTEMINAT_IADE_TARIHI.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colTEMINAT_IADE_TARIHI.Visible = true;
            this.colTEMINAT_IADE_TARIHI.VisibleIndex = 20;
            // 
            // colMUVEKKILE_TESLIM_TARIHI
            // 
            this.colMUVEKKILE_TESLIM_TARIHI.Caption = "Müvekkile Teslim T";
            this.colMUVEKKILE_TESLIM_TARIHI.FieldName = "MUVEKKILE_TESLIM_TARIHI";
            this.colMUVEKKILE_TESLIM_TARIHI.Name = "colMUVEKKILE_TESLIM_TARIHI";
            this.colMUVEKKILE_TESLIM_TARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMUVEKKILE_TESLIM_TARIHI.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colMUVEKKILE_TESLIM_TARIHI.Visible = true;
            this.colMUVEKKILE_TESLIM_TARIHI.VisibleIndex = 21;
            // 
            // colTESLIM_ALAN_CARI_ID
            // 
            this.colTESLIM_ALAN_CARI_ID.Caption = "TeslimAlan";
            this.colTESLIM_ALAN_CARI_ID.ColumnEdit = this.rLueCari;
            this.colTESLIM_ALAN_CARI_ID.FieldName = "TESLIM_ALAN_CARI_ID";
            this.colTESLIM_ALAN_CARI_ID.Name = "colTESLIM_ALAN_CARI_ID";
            this.colTESLIM_ALAN_CARI_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colTESLIM_ALAN_CARI_ID.Visible = true;
            this.colTESLIM_ALAN_CARI_ID.VisibleIndex = 22;
            // 
            // colADLI_BIRIM_ADLIYE_ID
            // 
            this.colADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
            this.colADLI_BIRIM_ADLIYE_ID.ColumnEdit = this.rLueAdliye;
            this.colADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
            this.colADLI_BIRIM_ADLIYE_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 23;
            // 
            // rLueAdliye
            // 
            this.rLueAdliye.AutoHeight = false;
            this.rLueAdliye.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliye.Name = "rLueAdliye";
            // 
            // colADLI_BIRIM_GOREV_ID
            // 
            this.colADLI_BIRIM_GOREV_ID.Caption = "Görev";
            this.colADLI_BIRIM_GOREV_ID.ColumnEdit = this.rLueGorev;
            this.colADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.colADLI_BIRIM_GOREV_ID.Name = "colADLI_BIRIM_GOREV_ID";
            this.colADLI_BIRIM_GOREV_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colADLI_BIRIM_GOREV_ID.Visible = true;
            this.colADLI_BIRIM_GOREV_ID.VisibleIndex = 24;
            // 
            // rLueGorev
            // 
            this.rLueGorev.AutoHeight = false;
            this.rLueGorev.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueGorev.Name = "rLueGorev";
            // 
            // colADLI_BIRIM_NO_ID
            // 
            this.colADLI_BIRIM_NO_ID.Caption = "Birim No";
            this.colADLI_BIRIM_NO_ID.ColumnEdit = this.rLueBirim;
            this.colADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            this.colADLI_BIRIM_NO_ID.Name = "colADLI_BIRIM_NO_ID";
            this.colADLI_BIRIM_NO_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colADLI_BIRIM_NO_ID.Visible = true;
            this.colADLI_BIRIM_NO_ID.VisibleIndex = 25;
            // 
            // rLueBirim
            // 
            this.rLueBirim.AutoHeight = false;
            this.rLueBirim.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBirim.Name = "rLueBirim";
            // 
            // colESAS_NO
            // 
            this.colESAS_NO.Caption = "Esas No";
            this.colESAS_NO.FieldName = "ESAS_NO";
            this.colESAS_NO.Name = "colESAS_NO";
            this.colESAS_NO.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colESAS_NO.Visible = true;
            this.colESAS_NO.VisibleIndex = 26;
            // 
            // ucTeminatMektupBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exgrdTwminatMaktup);
            this.Name = "ucTeminatMektupBilgileri";
            this.Size = new System.Drawing.Size(697, 425);
            ((System.ComponentModel.ISupportInitialize)(this.exgrdTwminatMaktup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMektupKonu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBanka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBSube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTeminatTuru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGorev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBirim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl exgrdTwminatMaktup;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colTIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colMEKTUP_KONU_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colBANKA_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSUBE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colHESAP_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colTARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colREFERANS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colSURE_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn colVADE_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTARI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTAZMIN_TALEP_BASLANGIC_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTAZMIN_TALEP_BITIS_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTAZMIN_TUTARI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTAZMIN_TUTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMINAT_TURU_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMINAT_TUTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMINAT_TUTARI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colLEHTAR_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMINAT_IADE_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colMUVEKKILE_TESLIM_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTESLIM_ALAN_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_ADLIYE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_GOREV_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_NO_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colESAS_NO;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTip;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMektupKonu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBanka;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBSube;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDoviz;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTeminatTuru;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliye;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueGorev;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBirim;
    }
}
