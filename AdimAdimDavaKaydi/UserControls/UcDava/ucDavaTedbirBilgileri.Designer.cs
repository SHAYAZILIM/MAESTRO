namespace  AdimAdimDavaKaydi.UserControls.UcDava
{
    partial class ucDavaTedbirBilgileri
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
            this.gridIhtiyatiTedbir = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.Aciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.Tarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rlueAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueAdliNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueAdliGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueCariPersonel = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueTeminatTur = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.Tutar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gwIhtiyatiTedbir = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colADLIYE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGOREV1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBIRIM_NO1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAVA_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colESAS_NO1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKARAR_NO1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKARAR_TARIHI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTALEP_TARIHI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEMINAT_TUR1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEMINAT_TUTARI_DOVIZ1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEMINAT_TUTARI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEMINAT_IADE_TARIHI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMUVEKKILE_TESLIM_TARIHI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTESLIM_ALAN_CARI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIKLAMA5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridIhtiyatiTedbir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdliye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdliNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdliGorev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCariPersonel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTeminatTur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwIhtiyatiTedbir)).BeginInit();
            this.SuspendLayout();
            // 
            // gridIhtiyatiTedbir
            // 
            this.gridIhtiyatiTedbir.CustomButtonlarGorunmesin = false;
            this.gridIhtiyatiTedbir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridIhtiyatiTedbir.DoNotExtendEmbedNavigator = false;
            this.gridIhtiyatiTedbir.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridIhtiyatiTedbir.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayýt", "FormAc"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, true, "Düzenle", "KaydýDuzenle")});
            this.gridIhtiyatiTedbir.ExternalRepository = this.MyRepository;
            this.gridIhtiyatiTedbir.FilterText = null;
            this.gridIhtiyatiTedbir.FilterValue = null;
            this.gridIhtiyatiTedbir.GridlerDuzenlenebilir = true;
            this.gridIhtiyatiTedbir.GridsFilterControl = null;
            this.gridIhtiyatiTedbir.Location = new System.Drawing.Point(0, 0);
            this.gridIhtiyatiTedbir.MainView = this.gwIhtiyatiTedbir;
            this.gridIhtiyatiTedbir.MyGridStyle = null;
            this.gridIhtiyatiTedbir.Name = "gridIhtiyatiTedbir";
            this.gridIhtiyatiTedbir.ShowRowNumbers = false;
            this.gridIhtiyatiTedbir.SilmeKaldirilsin = false;
            this.gridIhtiyatiTedbir.Size = new System.Drawing.Size(736, 491);
            this.gridIhtiyatiTedbir.TabIndex = 1;
            this.gridIhtiyatiTedbir.TemizleKaldirGorunsunmu = false;
            this.gridIhtiyatiTedbir.UniqueId = "fbd55ba7-d83c-4f64-a3c8-fda7a0aeb196";
            this.gridIhtiyatiTedbir.UseEmbeddedNavigator = true;
            this.gridIhtiyatiTedbir.UseHyperDragDrop = false;
            this.gridIhtiyatiTedbir.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwIhtiyatiTedbir});
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Aciklama,
            this.Tarih,
            this.rlueAdliye,
            this.rlueAdliNo,
            this.rlueAdliGorev,
            this.rlueCariPersonel,
            this.rlueTeminatTur,
            this.rlueDoviz,
            this.Tutar});
            // 
            // Aciklama
            // 
            this.Aciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Aciklama.Name = "Aciklama";
            // 
            // Tarih
            // 
            this.Tarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Tarih.Name = "Tarih";
            this.Tarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rlueAdliye
            // 
            this.rlueAdliye.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueAdliye.Name = "rlueAdliye";
            // 
            // rlueAdliNo
            // 
            this.rlueAdliNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueAdliNo.Name = "rlueAdliNo";
            // 
            // rlueAdliGorev
            // 
            this.rlueAdliGorev.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueAdliGorev.Name = "rlueAdliGorev";
            // 
            // rlueCariPersonel
            // 
            this.rlueCariPersonel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueCariPersonel.Name = "rlueCariPersonel";
            // 
            // rlueTeminatTur
            // 
            this.rlueTeminatTur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueTeminatTur.Name = "rlueTeminatTur";
            // 
            // rlueDoviz
            // 
            this.rlueDoviz.AutoHeight = false;
            this.rlueDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueDoviz.Name = "rlueDoviz";
            // 
            // Tutar
            // 
            this.Tutar.AutoHeight = false;
            this.Tutar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Tutar.Name = "Tutar";
            // 
            // gwIhtiyatiTedbir
            // 
            this.gwIhtiyatiTedbir.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colADLIYE1,
            this.colGOREV1,
            this.colBIRIM_NO1,
            this.colDAVA_TARIHI,
            this.colESAS_NO1,
            this.colKARAR_NO1,
            this.colKARAR_TARIHI1,
            this.colTALEP_TARIHI1,
            this.colTEMINAT_TUR1,
            this.colTEMINAT_TUTARI_DOVIZ1,
            this.colTEMINAT_TUTARI1,
            this.colTEMINAT_IADE_TARIHI1,
            this.colMUVEKKILE_TESLIM_TARIHI1,
            this.colTESLIM_ALAN_CARI1,
            this.colACIKLAMA5});
            this.gwIhtiyatiTedbir.GridControl = this.gridIhtiyatiTedbir;
            this.gwIhtiyatiTedbir.GroupPanelText = "Verileri Gruplandýrmak Ýçin Baþlýklarý Buraya Sürükleyin..";
            this.gwIhtiyatiTedbir.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TEMINAT_TUTARI", this.colTEMINAT_TUTARI1, "")});
            this.gwIhtiyatiTedbir.IndicatorWidth = 20;
            this.gwIhtiyatiTedbir.Name = "gwIhtiyatiTedbir";
            this.gwIhtiyatiTedbir.NewItemRowText = "Yeni Kayýt EklemekÝçin Buraya Týklayýn..";
            this.gwIhtiyatiTedbir.OptionsBehavior.FocusLeaveOnTab = true;
            this.gwIhtiyatiTedbir.OptionsNavigation.AutoFocusNewRow = true;
            this.gwIhtiyatiTedbir.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwIhtiyatiTedbir.OptionsView.AutoCalcPreviewLineCount = true;
            this.gwIhtiyatiTedbir.OptionsView.ColumnAutoWidth = false;
            this.gwIhtiyatiTedbir.OptionsView.ShowAutoFilterRow = true;
            this.gwIhtiyatiTedbir.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwIhtiyatiTedbir.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gwIhtiyatiTedbir.OptionsView.ShowPreview = true;
            this.gwIhtiyatiTedbir.PaintStyleName = "Skin";
            this.gwIhtiyatiTedbir.PreviewFieldName = "ACIKLAMA";
            // 
            // colADLIYE1
            // 
            this.colADLIYE1.Caption = "Adliye";
            this.colADLIYE1.ColumnEdit = this.rlueAdliye;
            this.colADLIYE1.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.colADLIYE1.Name = "colADLIYE1";
            this.colADLIYE1.OptionsColumn.ReadOnly = true;
            this.colADLIYE1.Visible = true;
            this.colADLIYE1.VisibleIndex = 0;
            this.colADLIYE1.Width = 118;
            // 
            // colGOREV1
            // 
            this.colGOREV1.Caption = "Görev";
            this.colGOREV1.ColumnEdit = this.rlueAdliGorev;
            this.colGOREV1.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.colGOREV1.Name = "colGOREV1";
            this.colGOREV1.OptionsColumn.ReadOnly = true;
            this.colGOREV1.Visible = true;
            this.colGOREV1.VisibleIndex = 2;
            this.colGOREV1.Width = 112;
            // 
            // colBIRIM_NO1
            // 
            this.colBIRIM_NO1.Caption = "Birim No";
            this.colBIRIM_NO1.ColumnEdit = this.rlueAdliNo;
            this.colBIRIM_NO1.FieldName = "ADLI_BIRIM_NO_ID";
            this.colBIRIM_NO1.Name = "colBIRIM_NO1";
            this.colBIRIM_NO1.OptionsColumn.ReadOnly = true;
            this.colBIRIM_NO1.Visible = true;
            this.colBIRIM_NO1.VisibleIndex = 1;
            this.colBIRIM_NO1.Width = 69;
            // 
            // colDAVA_TARIHI
            // 
            this.colDAVA_TARIHI.Caption = "Dava T.";
            this.colDAVA_TARIHI.ColumnEdit = this.Tarih;
            this.colDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            this.colDAVA_TARIHI.Name = "colDAVA_TARIHI";
            this.colDAVA_TARIHI.OptionsColumn.ReadOnly = true;
            this.colDAVA_TARIHI.Visible = true;
            this.colDAVA_TARIHI.VisibleIndex = 3;
            this.colDAVA_TARIHI.Width = 100;
            // 
            // colESAS_NO1
            // 
            this.colESAS_NO1.Caption = "Esas No";
            this.colESAS_NO1.FieldName = "ESAS_NO";
            this.colESAS_NO1.Name = "colESAS_NO1";
            this.colESAS_NO1.OptionsColumn.ReadOnly = true;
            this.colESAS_NO1.Visible = true;
            this.colESAS_NO1.VisibleIndex = 4;
            this.colESAS_NO1.Width = 92;
            // 
            // colKARAR_NO1
            // 
            this.colKARAR_NO1.Caption = "Karar No";
            this.colKARAR_NO1.FieldName = "KARAR_NO";
            this.colKARAR_NO1.Name = "colKARAR_NO1";
            this.colKARAR_NO1.OptionsColumn.ReadOnly = true;
            this.colKARAR_NO1.Visible = true;
            this.colKARAR_NO1.VisibleIndex = 5;
            this.colKARAR_NO1.Width = 91;
            // 
            // colKARAR_TARIHI1
            // 
            this.colKARAR_TARIHI1.Caption = "Karar T.";
            this.colKARAR_TARIHI1.ColumnEdit = this.Tarih;
            this.colKARAR_TARIHI1.FieldName = "KARAR_TARIHI";
            this.colKARAR_TARIHI1.Name = "colKARAR_TARIHI1";
            this.colKARAR_TARIHI1.OptionsColumn.ReadOnly = true;
            this.colKARAR_TARIHI1.Visible = true;
            this.colKARAR_TARIHI1.VisibleIndex = 6;
            this.colKARAR_TARIHI1.Width = 87;
            // 
            // colTALEP_TARIHI1
            // 
            this.colTALEP_TARIHI1.Caption = "Talep T.";
            this.colTALEP_TARIHI1.ColumnEdit = this.Tarih;
            this.colTALEP_TARIHI1.FieldName = "TALEP_TARIHI";
            this.colTALEP_TARIHI1.Name = "colTALEP_TARIHI1";
            this.colTALEP_TARIHI1.OptionsColumn.ReadOnly = true;
            this.colTALEP_TARIHI1.Visible = true;
            this.colTALEP_TARIHI1.VisibleIndex = 7;
            this.colTALEP_TARIHI1.Width = 87;
            // 
            // colTEMINAT_TUR1
            // 
            this.colTEMINAT_TUR1.Caption = "Teminat Tür";
            this.colTEMINAT_TUR1.ColumnEdit = this.rlueTeminatTur;
            this.colTEMINAT_TUR1.FieldName = "TEMINAT_TUR_ID";
            this.colTEMINAT_TUR1.Name = "colTEMINAT_TUR1";
            this.colTEMINAT_TUR1.OptionsColumn.ReadOnly = true;
            this.colTEMINAT_TUR1.Visible = true;
            this.colTEMINAT_TUR1.VisibleIndex = 8;
            this.colTEMINAT_TUR1.Width = 81;
            // 
            // colTEMINAT_TUTARI_DOVIZ1
            // 
            this.colTEMINAT_TUTARI_DOVIZ1.Caption = " ";
            this.colTEMINAT_TUTARI_DOVIZ1.ColumnEdit = this.rlueDoviz;
            this.colTEMINAT_TUTARI_DOVIZ1.CustomizationCaption = "Teminat Tutarý Döviz Cinsi";
            this.colTEMINAT_TUTARI_DOVIZ1.FieldName = "TEMINAT_TUTARI_DOVIZ_ID";
            this.colTEMINAT_TUTARI_DOVIZ1.Name = "colTEMINAT_TUTARI_DOVIZ1";
            this.colTEMINAT_TUTARI_DOVIZ1.OptionsColumn.ReadOnly = true;
            this.colTEMINAT_TUTARI_DOVIZ1.Visible = true;
            this.colTEMINAT_TUTARI_DOVIZ1.VisibleIndex = 10;
            // 
            // colTEMINAT_TUTARI1
            // 
            this.colTEMINAT_TUTARI1.Caption = "Teminat Tutarý";
            this.colTEMINAT_TUTARI1.ColumnEdit = this.Tutar;
            this.colTEMINAT_TUTARI1.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colTEMINAT_TUTARI1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTEMINAT_TUTARI1.FieldName = "TEMINAT_TUTARI";
            this.colTEMINAT_TUTARI1.Name = "colTEMINAT_TUTARI1";
            this.colTEMINAT_TUTARI1.OptionsColumn.ReadOnly = true;
            this.colTEMINAT_TUTARI1.Visible = true;
            this.colTEMINAT_TUTARI1.VisibleIndex = 9;
            this.colTEMINAT_TUTARI1.Width = 102;
            // 
            // colTEMINAT_IADE_TARIHI1
            // 
            this.colTEMINAT_IADE_TARIHI1.Caption = "Teminat Ýade T.";
            this.colTEMINAT_IADE_TARIHI1.ColumnEdit = this.Tarih;
            this.colTEMINAT_IADE_TARIHI1.FieldName = "TEMINAT_IADE_TARIHI";
            this.colTEMINAT_IADE_TARIHI1.Name = "colTEMINAT_IADE_TARIHI1";
            this.colTEMINAT_IADE_TARIHI1.OptionsColumn.ReadOnly = true;
            this.colTEMINAT_IADE_TARIHI1.Visible = true;
            this.colTEMINAT_IADE_TARIHI1.VisibleIndex = 11;
            this.colTEMINAT_IADE_TARIHI1.Width = 86;
            // 
            // colMUVEKKILE_TESLIM_TARIHI1
            // 
            this.colMUVEKKILE_TESLIM_TARIHI1.Caption = "Müvekkile Teslim T.";
            this.colMUVEKKILE_TESLIM_TARIHI1.ColumnEdit = this.Tarih;
            this.colMUVEKKILE_TESLIM_TARIHI1.FieldName = "MUVEKKILE_TESLIM_TARIHI";
            this.colMUVEKKILE_TESLIM_TARIHI1.Name = "colMUVEKKILE_TESLIM_TARIHI1";
            this.colMUVEKKILE_TESLIM_TARIHI1.OptionsColumn.ReadOnly = true;
            this.colMUVEKKILE_TESLIM_TARIHI1.Visible = true;
            this.colMUVEKKILE_TESLIM_TARIHI1.VisibleIndex = 12;
            this.colMUVEKKILE_TESLIM_TARIHI1.Width = 89;
            // 
            // colTESLIM_ALAN_CARI1
            // 
            this.colTESLIM_ALAN_CARI1.Caption = "Teslim Alan";
            this.colTESLIM_ALAN_CARI1.ColumnEdit = this.rlueCariPersonel;
            this.colTESLIM_ALAN_CARI1.FieldName = "TESLIM_ALAN_CARI_ID";
            this.colTESLIM_ALAN_CARI1.Name = "colTESLIM_ALAN_CARI1";
            this.colTESLIM_ALAN_CARI1.OptionsColumn.ReadOnly = true;
            this.colTESLIM_ALAN_CARI1.Visible = true;
            this.colTESLIM_ALAN_CARI1.VisibleIndex = 13;
            this.colTESLIM_ALAN_CARI1.Width = 135;
            // 
            // colACIKLAMA5
            // 
            this.colACIKLAMA5.Caption = "Açýklama";
            this.colACIKLAMA5.ColumnEdit = this.Aciklama;
            this.colACIKLAMA5.FieldName = "ACIKLAMA";
            this.colACIKLAMA5.Name = "colACIKLAMA5";
            this.colACIKLAMA5.OptionsColumn.ReadOnly = true;
            this.colACIKLAMA5.Visible = true;
            this.colACIKLAMA5.VisibleIndex = 14;
            this.colACIKLAMA5.Width = 108;
            // 
            // ucDavaTedbirBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridIhtiyatiTedbir);
            this.Name = "ucDavaTedbirBilgileri";
            this.Size = new System.Drawing.Size(736, 491);
            this.Load += new System.EventHandler(this.ucDavaTedbirBilgileri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridIhtiyatiTedbir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdliye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdliNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdliGorev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCariPersonel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTeminatTur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwIhtiyatiTedbir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridIhtiyatiTedbir;
        private DevExpress.XtraGrid.Views.Grid.GridView gwIhtiyatiTedbir;
        private DevExpress.XtraGrid.Columns.GridColumn colADLIYE1;
        private DevExpress.XtraGrid.Columns.GridColumn colGOREV1;
        private DevExpress.XtraGrid.Columns.GridColumn colBIRIM_NO1;
        private DevExpress.XtraGrid.Columns.GridColumn colDAVA_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colESAS_NO1;
        private DevExpress.XtraGrid.Columns.GridColumn colKARAR_NO1;
        private DevExpress.XtraGrid.Columns.GridColumn colKARAR_TARIHI1;
        private DevExpress.XtraGrid.Columns.GridColumn colTALEP_TARIHI1;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMINAT_TUR1;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMINAT_TUTARI_DOVIZ1;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMINAT_TUTARI1;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMINAT_IADE_TARIHI1;
        private DevExpress.XtraGrid.Columns.GridColumn colMUVEKKILE_TESLIM_TARIHI1;
        private DevExpress.XtraGrid.Columns.GridColumn colTESLIM_ALAN_CARI1;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA5;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit Aciklama;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit Tarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAdliye;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAdliNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAdliGorev;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCariPersonel;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueTeminatTur;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueDoviz;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit Tutar;
    }
}
