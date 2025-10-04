namespace  AdimAdimDavaKaydi.UserControls.UcDava
{
    partial class ucDavaKayitIliskiDetay
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
            this.gridKayitIliskiDetay = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gwKayitIliskiDetay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colILISKI_TUR_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueKayitIliskiTur = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colILISKI_NEDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueKayitIliskiNeden = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colHEDEF_KAYIT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueKayitIliskiHEdefKayit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.colHEDEF_DOSYA_TALEP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHEDEF_DOSYA_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHEDEF_ESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHEDEF_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueHedefTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colHEDEF_ADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colHEDEF_ADLI_BIRIM_NO_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBirimNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colHEDEF_ADLI_BIRIM_GOREV_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKayitIliskiDetay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwKayitIliskiDetay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKayitIliskiTur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKayitIliskiNeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKayitIliskiHEdefKayit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueHedefTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBirimNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGorev)).BeginInit();
            this.SuspendLayout();
            // 
            // gridKayitIliskiDetay
            // 
            this.gridKayitIliskiDetay.CustomButtonlarGorunmesin = false;
            this.gridKayitIliskiDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridKayitIliskiDetay.DoNotExtendEmbedNavigator = false;
            this.gridKayitIliskiDetay.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridKayitIliskiDetay.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayýt", "FormdanEkle"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, false, "Kayýt Düzenle", "KayitDuzenle")});
            this.gridKayitIliskiDetay.FilterText = null;
            this.gridKayitIliskiDetay.FilterValue = null;
            this.gridKayitIliskiDetay.GridlerDuzenlenebilir = true;
            this.gridKayitIliskiDetay.GridsFilterControl = null;
            this.gridKayitIliskiDetay.Location = new System.Drawing.Point(0, 0);
            this.gridKayitIliskiDetay.MainView = this.gwKayitIliskiDetay;
            this.gridKayitIliskiDetay.MyGridStyle = null;
            this.gridKayitIliskiDetay.Name = "gridKayitIliskiDetay";
            this.gridKayitIliskiDetay.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueKayitIliskiTur,
            this.rLueKayitIliskiNeden,
            this.rLueKayitIliskiHEdefKayit,
            this.rLueAdliye,
            this.rLueBirimNo,
            this.rLueGorev,
            this.repositoryItemMemoExEdit1,
            this.rlueHedefTip});
            this.gridKayitIliskiDetay.ShowRowNumbers = false;
            this.gridKayitIliskiDetay.SilmeKaldirilsin = false;
            this.gridKayitIliskiDetay.Size = new System.Drawing.Size(707, 484);
            this.gridKayitIliskiDetay.TabIndex = 0;
            this.gridKayitIliskiDetay.TemizleKaldirGorunsunmu = false;
            this.gridKayitIliskiDetay.UniqueId = "591c53f3-cb6a-4a01-89ab-a08f8f61da03";
            this.gridKayitIliskiDetay.UseEmbeddedNavigator = true;
            this.gridKayitIliskiDetay.UseHyperDragDrop = false;
            this.gridKayitIliskiDetay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwKayitIliskiDetay});
            this.gridKayitIliskiDetay.ButtonClick += new System.EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(this.gridKayitIliskiDetay_ButtonClick);
            // 
            // gwKayitIliskiDetay
            // 
            this.gwKayitIliskiDetay.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colILISKI_TUR_ID,
            this.colILISKI_NEDEN_ID,
            this.colHEDEF_KAYIT_ID,
            this.colACIKLAMA,
            this.colHEDEF_DOSYA_TALEP,
            this.colHEDEF_DOSYA_TARIHI,
            this.colHEDEF_ESAS_NO,
            this.colHEDEF_TIP,
            this.colHEDEF_ADLI_BIRIM_ADLIYE_ID,
            this.colHEDEF_ADLI_BIRIM_NO_ID,
            this.colHEDEF_ADLI_BIRIM_GOREV_ID});
            this.gwKayitIliskiDetay.GridControl = this.gridKayitIliskiDetay;
            this.gwKayitIliskiDetay.IndicatorWidth = 20;
            this.gwKayitIliskiDetay.Name = "gwKayitIliskiDetay";
            this.gwKayitIliskiDetay.OptionsBehavior.FocusLeaveOnTab = true;
            this.gwKayitIliskiDetay.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwKayitIliskiDetay.OptionsNavigation.AutoFocusNewRow = true;
            this.gwKayitIliskiDetay.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwKayitIliskiDetay.OptionsView.AutoCalcPreviewLineCount = true;
            this.gwKayitIliskiDetay.OptionsView.ColumnAutoWidth = false;
            this.gwKayitIliskiDetay.OptionsView.ShowAutoFilterRow = true;
            this.gwKayitIliskiDetay.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwKayitIliskiDetay.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gwKayitIliskiDetay.OptionsView.ShowPreview = true;
            this.gwKayitIliskiDetay.PreviewFieldName = "ACIKLAMA";
            // 
            // colILISKI_TUR_ID
            // 
            this.colILISKI_TUR_ID.Caption = "Ýliþki Tür";
            this.colILISKI_TUR_ID.ColumnEdit = this.rLueKayitIliskiTur;
            this.colILISKI_TUR_ID.FieldName = "ILISKI_TUR_ID";
            this.colILISKI_TUR_ID.Name = "colILISKI_TUR_ID";
            this.colILISKI_TUR_ID.OptionsColumn.ReadOnly = true;
            this.colILISKI_TUR_ID.Visible = true;
            this.colILISKI_TUR_ID.VisibleIndex = 1;
            // 
            // rLueKayitIliskiTur
            // 
            this.rLueKayitIliskiTur.AutoHeight = false;
            this.rLueKayitIliskiTur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueKayitIliskiTur.Name = "rLueKayitIliskiTur";
            // 
            // colILISKI_NEDEN_ID
            // 
            this.colILISKI_NEDEN_ID.Caption = "Ýliþki Neden";
            this.colILISKI_NEDEN_ID.ColumnEdit = this.rLueKayitIliskiNeden;
            this.colILISKI_NEDEN_ID.FieldName = "ILISKI_NEDEN_ID";
            this.colILISKI_NEDEN_ID.Name = "colILISKI_NEDEN_ID";
            this.colILISKI_NEDEN_ID.OptionsColumn.ReadOnly = true;
            this.colILISKI_NEDEN_ID.Visible = true;
            this.colILISKI_NEDEN_ID.VisibleIndex = 2;
            // 
            // rLueKayitIliskiNeden
            // 
            this.rLueKayitIliskiNeden.AutoHeight = false;
            this.rLueKayitIliskiNeden.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueKayitIliskiNeden.Name = "rLueKayitIliskiNeden";
            // 
            // colHEDEF_KAYIT_ID
            // 
            this.colHEDEF_KAYIT_ID.Caption = "Hedef Kayit";
            this.colHEDEF_KAYIT_ID.ColumnEdit = this.rLueKayitIliskiHEdefKayit;
            this.colHEDEF_KAYIT_ID.FieldName = "HEDEF_KAYIT_ID";
            this.colHEDEF_KAYIT_ID.Name = "colHEDEF_KAYIT_ID";
            this.colHEDEF_KAYIT_ID.OptionsColumn.ReadOnly = true;
            // 
            // rLueKayitIliskiHEdefKayit
            // 
            this.rLueKayitIliskiHEdefKayit.AutoHeight = false;
            this.rLueKayitIliskiHEdefKayit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueKayitIliskiHEdefKayit.Name = "rLueKayitIliskiHEdefKayit";
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açýklama";
            this.colACIKLAMA.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.OptionsColumn.ReadOnly = true;
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 3;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // colHEDEF_DOSYA_TALEP
            // 
            this.colHEDEF_DOSYA_TALEP.Caption = "Dosya Talep";
            this.colHEDEF_DOSYA_TALEP.FieldName = "HEDEF_DOSYA_TALEP";
            this.colHEDEF_DOSYA_TALEP.Name = "colHEDEF_DOSYA_TALEP";
            this.colHEDEF_DOSYA_TALEP.OptionsColumn.ReadOnly = true;
            this.colHEDEF_DOSYA_TALEP.Visible = true;
            this.colHEDEF_DOSYA_TALEP.VisibleIndex = 4;
            // 
            // colHEDEF_DOSYA_TARIHI
            // 
            this.colHEDEF_DOSYA_TARIHI.Caption = "Hedef Dosya T.";
            this.colHEDEF_DOSYA_TARIHI.FieldName = "HEDEF_DOSYA_TARIHI";
            this.colHEDEF_DOSYA_TARIHI.Name = "colHEDEF_DOSYA_TARIHI";
            this.colHEDEF_DOSYA_TARIHI.OptionsColumn.ReadOnly = true;
            this.colHEDEF_DOSYA_TARIHI.Visible = true;
            this.colHEDEF_DOSYA_TARIHI.VisibleIndex = 5;
            // 
            // colHEDEF_ESAS_NO
            // 
            this.colHEDEF_ESAS_NO.Caption = "Esas No";
            this.colHEDEF_ESAS_NO.FieldName = "HEDEF_ESAS_NO";
            this.colHEDEF_ESAS_NO.Name = "colHEDEF_ESAS_NO";
            this.colHEDEF_ESAS_NO.OptionsColumn.ReadOnly = true;
            this.colHEDEF_ESAS_NO.Visible = true;
            this.colHEDEF_ESAS_NO.VisibleIndex = 6;
            // 
            // colHEDEF_TIP
            // 
            this.colHEDEF_TIP.Caption = "Hedef Tip";
            this.colHEDEF_TIP.ColumnEdit = this.rlueHedefTip;
            this.colHEDEF_TIP.FieldName = "HEDEF_TIP";
            this.colHEDEF_TIP.Name = "colHEDEF_TIP";
            this.colHEDEF_TIP.OptionsColumn.ReadOnly = true;
            this.colHEDEF_TIP.Visible = true;
            this.colHEDEF_TIP.VisibleIndex = 0;
            // 
            // rlueHedefTip
            // 
            this.rlueHedefTip.AutoHeight = false;
            this.rlueHedefTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueHedefTip.Name = "rlueHedefTip";
            // 
            // colHEDEF_ADLI_BIRIM_ADLIYE_ID
            // 
            this.colHEDEF_ADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
            this.colHEDEF_ADLI_BIRIM_ADLIYE_ID.ColumnEdit = this.rLueAdliye;
            this.colHEDEF_ADLI_BIRIM_ADLIYE_ID.FieldName = "HEDEF_ADLI_BIRIM_ADLIYE_ID";
            this.colHEDEF_ADLI_BIRIM_ADLIYE_ID.Name = "colHEDEF_ADLI_BIRIM_ADLIYE_ID";
            this.colHEDEF_ADLI_BIRIM_ADLIYE_ID.OptionsColumn.ReadOnly = true;
            this.colHEDEF_ADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colHEDEF_ADLI_BIRIM_ADLIYE_ID.VisibleIndex = 7;
            // 
            // rLueAdliye
            // 
            this.rLueAdliye.AutoHeight = false;
            this.rLueAdliye.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliye.Name = "rLueAdliye";
            // 
            // colHEDEF_ADLI_BIRIM_NO_ID
            // 
            this.colHEDEF_ADLI_BIRIM_NO_ID.Caption = "Birim No";
            this.colHEDEF_ADLI_BIRIM_NO_ID.ColumnEdit = this.rLueBirimNo;
            this.colHEDEF_ADLI_BIRIM_NO_ID.FieldName = "HEDEF_ADLI_BIRIM_NO_ID";
            this.colHEDEF_ADLI_BIRIM_NO_ID.Name = "colHEDEF_ADLI_BIRIM_NO_ID";
            this.colHEDEF_ADLI_BIRIM_NO_ID.OptionsColumn.ReadOnly = true;
            this.colHEDEF_ADLI_BIRIM_NO_ID.Visible = true;
            this.colHEDEF_ADLI_BIRIM_NO_ID.VisibleIndex = 8;
            // 
            // rLueBirimNo
            // 
            this.rLueBirimNo.AutoHeight = false;
            this.rLueBirimNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBirimNo.Name = "rLueBirimNo";
            // 
            // colHEDEF_ADLI_BIRIM_GOREV_ID
            // 
            this.colHEDEF_ADLI_BIRIM_GOREV_ID.Caption = "Görev";
            this.colHEDEF_ADLI_BIRIM_GOREV_ID.ColumnEdit = this.rLueGorev;
            this.colHEDEF_ADLI_BIRIM_GOREV_ID.FieldName = "HEDEF_ADLI_BIRIM_GOREV_ID";
            this.colHEDEF_ADLI_BIRIM_GOREV_ID.Name = "colHEDEF_ADLI_BIRIM_GOREV_ID";
            this.colHEDEF_ADLI_BIRIM_GOREV_ID.OptionsColumn.ReadOnly = true;
            this.colHEDEF_ADLI_BIRIM_GOREV_ID.Visible = true;
            this.colHEDEF_ADLI_BIRIM_GOREV_ID.VisibleIndex = 9;
            // 
            // rLueGorev
            // 
            this.rLueGorev.AutoHeight = false;
            this.rLueGorev.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueGorev.Name = "rLueGorev";
            // 
            // ucDavaKayitIliskiDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridKayitIliskiDetay);
            this.Name = "ucDavaKayitIliskiDetay";
            this.Size = new System.Drawing.Size(707, 484);
            this.Load += new System.EventHandler(this.ucDavaKayitIliskiDetay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridKayitIliskiDetay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwKayitIliskiDetay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKayitIliskiTur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKayitIliskiNeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKayitIliskiHEdefKayit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueHedefTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBirimNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGorev)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridKayitIliskiDetay;
        private DevExpress.XtraGrid.Views.Grid.GridView gwKayitIliskiDetay;
        private DevExpress.XtraGrid.Columns.GridColumn colILISKI_TUR_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueKayitIliskiTur;
        private DevExpress.XtraGrid.Columns.GridColumn colILISKI_NEDEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colHEDEF_KAYIT_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colHEDEF_DOSYA_TALEP;
        private DevExpress.XtraGrid.Columns.GridColumn colHEDEF_DOSYA_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colHEDEF_ESAS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colHEDEF_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn colHEDEF_ADLI_BIRIM_ADLIYE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colHEDEF_ADLI_BIRIM_NO_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colHEDEF_ADLI_BIRIM_GOREV_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueKayitIliskiNeden;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueKayitIliskiHEdefKayit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliye;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBirimNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueGorev;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueHedefTip;
    }
}
