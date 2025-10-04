namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucKimNeredeBilgileri
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
            this.exGridKimNErede = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPERSONEL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmpImgPersonel = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colBULUNMA_BASLANGIC_TARIHI_SAATI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDONUS_BASLANGIC_TARIHI_SAATI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDONULDU_MU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISIN_ACIKLAMASI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLuePersonelID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueAdliBirimAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueAdliBirimNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueAdliBirimGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueIsKategoriId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.riteDonusBaslangicSaati = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridKimNErede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmpImgPersonel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLuePersonelID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimAdliye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimGorev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIsKategoriId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riteDonusBaslangicSaati)).BeginInit();
            this.SuspendLayout();
            // 
            // exGridKimNErede
            // 
            this.exGridKimNErede.CustomButtonlarGorunmesin = false;
            this.exGridKimNErede.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridKimNErede.DoNotExtendEmbedNavigator = false;
            this.exGridKimNErede.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.exGridKimNErede.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.exGridKimNErede.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.exGridKimNErede.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.exGridKimNErede.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, true, "Düzenle", "KaydiDuzenle"),
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayýt", "FormAc")});
            this.exGridKimNErede.FilterText = null;
            this.exGridKimNErede.FilterValue = null;
            this.exGridKimNErede.GridlerDuzenlenebilir = true;
            this.exGridKimNErede.GridsFilterControl = null;
            this.exGridKimNErede.Location = new System.Drawing.Point(0, 0);
            this.exGridKimNErede.MainView = this.gridView1;
            this.exGridKimNErede.MyGridStyle = null;
            this.exGridKimNErede.Name = "exGridKimNErede";
            this.exGridKimNErede.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLuePersonelID,
            this.rLueAdliBirimAdliye,
            this.rLueAdliBirimNo,
            this.rLueAdliBirimGorev,
            this.rLueIsKategoriId,
            this.riteDonusBaslangicSaati,
            this.cmpImgPersonel});
            this.exGridKimNErede.ShowRowNumbers = false;
            this.exGridKimNErede.SilmeKaldirilsin = false;
            this.exGridKimNErede.Size = new System.Drawing.Size(926, 746);
            this.exGridKimNErede.TabIndex = 0;
            this.exGridKimNErede.TemizleKaldirGorunsunmu = false;
            this.exGridKimNErede.UniqueId = "d4fc373c-3181-4bd2-a15e-900ebbdb06b9";
            this.exGridKimNErede.UseEmbeddedNavigator = true;
            this.exGridKimNErede.UseHyperDragDrop = false;
            this.exGridKimNErede.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.exGridKimNErede.ButtonClick += new System.EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(this.exGridKimNErede_ButtonClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPERSONEL_ID,
            this.colBULUNMA_BASLANGIC_TARIHI_SAATI,
            this.colDONUS_BASLANGIC_TARIHI_SAATI,
            this.colDONULDU_MU,
            this.colADLI_BIRIM_ADLIYE_ID,
            this.colISIN_ACIKLAMASI});
            this.gridView1.GridControl = this.exGridKimNErede;
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            // 
            // colPERSONEL_ID
            // 
            this.colPERSONEL_ID.Caption = "Personel";
            this.colPERSONEL_ID.ColumnEdit = this.cmpImgPersonel;
            this.colPERSONEL_ID.FieldName = "PERSONEL_ID";
            this.colPERSONEL_ID.Name = "colPERSONEL_ID";
            this.colPERSONEL_ID.OptionsColumn.AllowEdit = false;
            this.colPERSONEL_ID.OptionsColumn.ReadOnly = true;
            this.colPERSONEL_ID.Visible = true;
            this.colPERSONEL_ID.VisibleIndex = 0;
            // 
            // cmpImgPersonel
            // 
            this.cmpImgPersonel.AutoHeight = false;
            this.cmpImgPersonel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmpImgPersonel.Name = "cmpImgPersonel";
            // 
            // colBULUNMA_BASLANGIC_TARIHI_SAATI
            // 
            this.colBULUNMA_BASLANGIC_TARIHI_SAATI.Caption = "Gidiþ T.";
            this.colBULUNMA_BASLANGIC_TARIHI_SAATI.FieldName = "BULUNMA_BASLANGIC_TARIHI_SAATI";
            this.colBULUNMA_BASLANGIC_TARIHI_SAATI.Name = "colBULUNMA_BASLANGIC_TARIHI_SAATI";
            this.colBULUNMA_BASLANGIC_TARIHI_SAATI.OptionsColumn.AllowEdit = false;
            this.colBULUNMA_BASLANGIC_TARIHI_SAATI.OptionsColumn.ReadOnly = true;
            this.colBULUNMA_BASLANGIC_TARIHI_SAATI.Visible = true;
            this.colBULUNMA_BASLANGIC_TARIHI_SAATI.VisibleIndex = 1;
            // 
            // colDONUS_BASLANGIC_TARIHI_SAATI
            // 
            this.colDONUS_BASLANGIC_TARIHI_SAATI.Caption = "Dönüþ T.";
            this.colDONUS_BASLANGIC_TARIHI_SAATI.FieldName = "DONUS_BASLANGIC_TARIHI_SAATI";
            this.colDONUS_BASLANGIC_TARIHI_SAATI.Name = "colDONUS_BASLANGIC_TARIHI_SAATI";
            this.colDONUS_BASLANGIC_TARIHI_SAATI.OptionsColumn.AllowEdit = false;
            this.colDONUS_BASLANGIC_TARIHI_SAATI.OptionsColumn.ReadOnly = true;
            this.colDONUS_BASLANGIC_TARIHI_SAATI.Visible = true;
            this.colDONUS_BASLANGIC_TARIHI_SAATI.VisibleIndex = 2;
            // 
            // colDONULDU_MU
            // 
            this.colDONULDU_MU.Caption = "Dönüldü";
            this.colDONULDU_MU.FieldName = "DONULDU_MU";
            this.colDONULDU_MU.Name = "colDONULDU_MU";
            this.colDONULDU_MU.OptionsColumn.AllowEdit = false;
            this.colDONULDU_MU.OptionsColumn.ReadOnly = true;
            this.colDONULDU_MU.Visible = true;
            this.colDONULDU_MU.VisibleIndex = 3;
            // 
            // colADLI_BIRIM_ADLIYE_ID
            // 
            this.colADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
            this.colADLI_BIRIM_ADLIYE_ID.FieldName = "ADLIYE";
            this.colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
            this.colADLI_BIRIM_ADLIYE_ID.OptionsColumn.AllowEdit = false;
            this.colADLI_BIRIM_ADLIYE_ID.OptionsColumn.ReadOnly = true;
            this.colADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 4;
            // 
            // colISIN_ACIKLAMASI
            // 
            this.colISIN_ACIKLAMASI.Caption = "Açýklama";
            this.colISIN_ACIKLAMASI.FieldName = "ISIN_ACIKLAMASI";
            this.colISIN_ACIKLAMASI.Name = "colISIN_ACIKLAMASI";
            this.colISIN_ACIKLAMASI.OptionsColumn.AllowEdit = false;
            this.colISIN_ACIKLAMASI.OptionsColumn.ReadOnly = true;
            this.colISIN_ACIKLAMASI.Visible = true;
            this.colISIN_ACIKLAMASI.VisibleIndex = 5;
            // 
            // rLuePersonelID
            // 
            this.rLuePersonelID.AutoHeight = false;
            this.rLuePersonelID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLuePersonelID.Name = "rLuePersonelID";
            this.rLuePersonelID.ReadOnly = true;
            // 
            // rLueAdliBirimAdliye
            // 
            this.rLueAdliBirimAdliye.AutoHeight = false;
            this.rLueAdliBirimAdliye.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimAdliye.Name = "rLueAdliBirimAdliye";
            this.rLueAdliBirimAdliye.ReadOnly = true;
            // 
            // rLueAdliBirimNo
            // 
            this.rLueAdliBirimNo.AutoHeight = false;
            this.rLueAdliBirimNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimNo.Name = "rLueAdliBirimNo";
            this.rLueAdliBirimNo.ReadOnly = true;
            // 
            // rLueAdliBirimGorev
            // 
            this.rLueAdliBirimGorev.AutoHeight = false;
            this.rLueAdliBirimGorev.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimGorev.Name = "rLueAdliBirimGorev";
            this.rLueAdliBirimGorev.ReadOnly = true;
            // 
            // rLueIsKategoriId
            // 
            this.rLueIsKategoriId.AutoHeight = false;
            this.rLueIsKategoriId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueIsKategoriId.Name = "rLueIsKategoriId";
            this.rLueIsKategoriId.ReadOnly = true;
            // 
            // riteDonusBaslangicSaati
            // 
            this.riteDonusBaslangicSaati.AutoHeight = false;
            this.riteDonusBaslangicSaati.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.riteDonusBaslangicSaati.Name = "riteDonusBaslangicSaati";
            this.riteDonusBaslangicSaati.ReadOnly = true;
            // 
            // ucKimNeredeBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exGridKimNErede);
            this.Name = "ucKimNeredeBilgileri";
            this.Size = new System.Drawing.Size(926, 746);
            this.Load += new System.EventHandler(this.ucKimNeredeBilgileri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exGridKimNErede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmpImgPersonel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLuePersonelID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimAdliye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimGorev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIsKategoriId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riteDonusBaslangicSaati)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl exGridKimNErede;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colPERSONEL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colBULUNMA_BASLANGIC_TARIHI_SAATI;
        private DevExpress.XtraGrid.Columns.GridColumn colDONULDU_MU;
        private DevExpress.XtraGrid.Columns.GridColumn colDONUS_BASLANGIC_TARIHI_SAATI;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_ADLIYE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colISIN_ACIKLAMASI;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLuePersonelID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimAdliye;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimGorev;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueIsKategoriId;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit riteDonusBaslangicSaati;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cmpImgPersonel;
    }
}
