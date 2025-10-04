namespace  AdimAdimDavaKaydi.Belge.UserControls
{
    partial class ucBelgeDolasim
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
            this.exGrdBelgeDolasim = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colISLEM_REFERANS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBELGEYI_ALAN_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueCariID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBELGEYI_ALDIGI_TARIH_SAAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBELGEYI_BIRAKMA_TARIH_SAAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYAPILAN_ISLEM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueYapilanIslemID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBELGE_GONDERILEN_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGONDERILEN_YER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGONDERILME_TARIH_SAAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colONERILEN_ISLEM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colONERME_ACIKLAMASI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colICERIK = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exGrdBelgeDolasim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCariID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueYapilanIslemID)).BeginInit();
            this.SuspendLayout();
            // 
            // exGrdBelgeDolasim
            // 
            this.exGrdBelgeDolasim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGrdBelgeDolasim.Location = new System.Drawing.Point(0, 0);
            this.exGrdBelgeDolasim.MainView = this.gridView1;
            this.exGrdBelgeDolasim.Name = "exGrdBelgeDolasim";
            this.exGrdBelgeDolasim.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueCariID,
            this.rLueYapilanIslemID});
            this.exGrdBelgeDolasim.Size = new System.Drawing.Size(664, 483);
            this.exGrdBelgeDolasim.TabIndex = 0;
            this.exGrdBelgeDolasim.UseEmbeddedNavigator = true;
            this.exGrdBelgeDolasim.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colISLEM_REFERANS_NO,
            this.colBELGEYI_ALAN_CARI_ID,
            this.colBELGEYI_ALDIGI_TARIH_SAAT,
            this.colBELGEYI_BIRAKMA_TARIH_SAAT,
            this.colYAPILAN_ISLEM_ID,
            this.colACIKLAMA,
            this.colBELGE_GONDERILEN_CARI_ID,
            this.colGONDERILEN_YER,
            this.colGONDERILME_TARIH_SAAT,
            this.colONERILEN_ISLEM_ID,
            this.colONERME_ACIKLAMASI,
            this.colICERIK});
            this.gridView1.GridControl = this.exGrdBelgeDolasim;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.OptionsView.ShowPreview = true;
            this.gridView1.PreviewFieldName = "ASAMA_ACIKLAMA";
            // 
            // colISLEM_REFERANS_NO
            // 
            this.colISLEM_REFERANS_NO.Caption = "Ýþlem Ref. No";
            this.colISLEM_REFERANS_NO.FieldName = "ISLEM_REFERANS_NO";
            this.colISLEM_REFERANS_NO.Name = "colISLEM_REFERANS_NO";
            this.colISLEM_REFERANS_NO.Visible = true;
            this.colISLEM_REFERANS_NO.VisibleIndex = 0;
            // 
            // colBELGEYI_ALAN_CARI_ID
            // 
            this.colBELGEYI_ALAN_CARI_ID.Caption = "Belgeyi Alan";
            this.colBELGEYI_ALAN_CARI_ID.ColumnEdit = this.rLueCariID;
            this.colBELGEYI_ALAN_CARI_ID.FieldName = "BELGEYI_ALAN_CARI_ID";
            this.colBELGEYI_ALAN_CARI_ID.Name = "colBELGEYI_ALAN_CARI_ID";
            this.colBELGEYI_ALAN_CARI_ID.Visible = true;
            this.colBELGEYI_ALAN_CARI_ID.VisibleIndex = 1;
            // 
            // rLueCariID
            // 
            this.rLueCariID.AutoHeight = false;
            this.rLueCariID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueCariID.Name = "rLueCariID";
            // 
            // colBELGEYI_ALDIGI_TARIH_SAAT
            // 
            this.colBELGEYI_ALDIGI_TARIH_SAAT.Caption = "Alma T";
            this.colBELGEYI_ALDIGI_TARIH_SAAT.FieldName = "BELGEYI_ALDIGI_TARIH_SAAT";
            this.colBELGEYI_ALDIGI_TARIH_SAAT.Name = "colBELGEYI_ALDIGI_TARIH_SAAT";
            this.colBELGEYI_ALDIGI_TARIH_SAAT.Visible = true;
            this.colBELGEYI_ALDIGI_TARIH_SAAT.VisibleIndex = 2;
            // 
            // colBELGEYI_BIRAKMA_TARIH_SAAT
            // 
            this.colBELGEYI_BIRAKMA_TARIH_SAAT.Caption = "Býrakma T";
            this.colBELGEYI_BIRAKMA_TARIH_SAAT.FieldName = "BELGEYI_BIRAKMA_TARIH_SAAT";
            this.colBELGEYI_BIRAKMA_TARIH_SAAT.Name = "colBELGEYI_BIRAKMA_TARIH_SAAT";
            this.colBELGEYI_BIRAKMA_TARIH_SAAT.Visible = true;
            this.colBELGEYI_BIRAKMA_TARIH_SAAT.VisibleIndex = 3;
            // 
            // colYAPILAN_ISLEM_ID
            // 
            this.colYAPILAN_ISLEM_ID.Caption = "Yapýlan Ýþlem";
            this.colYAPILAN_ISLEM_ID.ColumnEdit = this.rLueYapilanIslemID;
            this.colYAPILAN_ISLEM_ID.FieldName = "YAPILAN_ISLEM_ID";
            this.colYAPILAN_ISLEM_ID.Name = "colYAPILAN_ISLEM_ID";
            this.colYAPILAN_ISLEM_ID.Visible = true;
            this.colYAPILAN_ISLEM_ID.VisibleIndex = 4;
            // 
            // rLueYapilanIslemID
            // 
            this.rLueYapilanIslemID.AutoHeight = false;
            this.rLueYapilanIslemID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueYapilanIslemID.Name = "rLueYapilanIslemID";
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açýklama";
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 5;
            // 
            // colBELGE_GONDERILEN_CARI_ID
            // 
            this.colBELGE_GONDERILEN_CARI_ID.Caption = "Belge Gönderilen";
            this.colBELGE_GONDERILEN_CARI_ID.ColumnEdit = this.rLueCariID;
            this.colBELGE_GONDERILEN_CARI_ID.FieldName = "BELGE_GONDERILEN_CARI_ID";
            this.colBELGE_GONDERILEN_CARI_ID.Name = "colBELGE_GONDERILEN_CARI_ID";
            this.colBELGE_GONDERILEN_CARI_ID.Visible = true;
            this.colBELGE_GONDERILEN_CARI_ID.VisibleIndex = 6;
            // 
            // colGONDERILEN_YER
            // 
            this.colGONDERILEN_YER.Caption = "Gönderilen Yer";
            this.colGONDERILEN_YER.FieldName = "GONDERILEN_YER";
            this.colGONDERILEN_YER.Name = "colGONDERILEN_YER";
            this.colGONDERILEN_YER.Visible = true;
            this.colGONDERILEN_YER.VisibleIndex = 7;
            // 
            // colGONDERILME_TARIH_SAAT
            // 
            this.colGONDERILME_TARIH_SAAT.Caption = "Gönderilme T";
            this.colGONDERILME_TARIH_SAAT.FieldName = "GONDERILME_TARIH_SAAT";
            this.colGONDERILME_TARIH_SAAT.Name = "colGONDERILME_TARIH_SAAT";
            this.colGONDERILME_TARIH_SAAT.Visible = true;
            this.colGONDERILME_TARIH_SAAT.VisibleIndex = 8;
            // 
            // colONERILEN_ISLEM_ID
            // 
            this.colONERILEN_ISLEM_ID.Caption = "Önerilen Ýþlem";
            this.colONERILEN_ISLEM_ID.ColumnEdit = this.rLueYapilanIslemID;
            this.colONERILEN_ISLEM_ID.FieldName = "ONERILEN_ISLEM_ID";
            this.colONERILEN_ISLEM_ID.Name = "colONERILEN_ISLEM_ID";
            this.colONERILEN_ISLEM_ID.Visible = true;
            this.colONERILEN_ISLEM_ID.VisibleIndex = 9;
            // 
            // colONERME_ACIKLAMASI
            // 
            this.colONERME_ACIKLAMASI.Caption = "Önerme Açýklamasý";
            this.colONERME_ACIKLAMASI.FieldName = "ONERME_ACIKLAMASI";
            this.colONERME_ACIKLAMASI.Name = "colONERME_ACIKLAMASI";
            this.colONERME_ACIKLAMASI.Visible = true;
            this.colONERME_ACIKLAMASI.VisibleIndex = 10;
            // 
            // colICERIK
            // 
            this.colICERIK.Caption = "Ýçerik";
            this.colICERIK.FieldName = "ICERIK";
            this.colICERIK.Name = "colICERIK";
            this.colICERIK.Visible = true;
            this.colICERIK.VisibleIndex = 11;
            // 
            // ucBelgeDolasim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exGrdBelgeDolasim);
            this.Name = "ucBelgeDolasim";
            this.Size = new System.Drawing.Size(664, 483);
            this.Load += new System.EventHandler(this.ucBelgeDolasim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exGrdBelgeDolasim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCariID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueYapilanIslemID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl exGrdBelgeDolasim;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colISLEM_REFERANS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colBELGEYI_ALAN_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colBELGEYI_ALDIGI_TARIH_SAAT;
        private DevExpress.XtraGrid.Columns.GridColumn colBELGEYI_BIRAKMA_TARIH_SAAT;
        private DevExpress.XtraGrid.Columns.GridColumn colYAPILAN_ISLEM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colBELGE_GONDERILEN_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colGONDERILEN_YER;
        private DevExpress.XtraGrid.Columns.GridColumn colGONDERILME_TARIH_SAAT;
        private DevExpress.XtraGrid.Columns.GridColumn colONERILEN_ISLEM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colONERME_ACIKLAMASI;
        private DevExpress.XtraGrid.Columns.GridColumn colICERIK;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueCariID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueYapilanIslemID;
    }
}
