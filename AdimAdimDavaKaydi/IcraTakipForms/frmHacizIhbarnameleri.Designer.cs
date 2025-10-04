namespace AdimAdimDavaKaydi.IcraTakipForms
{
    partial class frmHacizIhbarnameleri
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
            this.gcHacizIhbarnameleri = new DevExpress.XtraGrid.GridControl();
            this.gvHacizIhbarnameleri = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMUHATAP_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueMuhatapCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTEBLIG_TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEBLIGATA_ITIRAZ_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBORCUN_ODENDIGI_TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBILA_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMENFI_TESPIT_DAVA_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colICRAYA_BELGE_IBRAZ_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEBLIGATIN_KESINLESTIGI_TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEBLIGAT_IPTAL_DAVA_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOSTA_SON_ISLEM_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorcluYap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnBorcluYap = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHacizIhbarnameleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHacizIhbarnameleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueMuhatapCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBorcluYap)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 470);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(819, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(669, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(744, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.gcHacizIhbarnameleri);
            this.c_pnlContainer.Size = new System.Drawing.Size(819, 495);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.gcHacizIhbarnameleri, 0);
            // 
            // gcHacizIhbarnameleri
            // 
            this.gcHacizIhbarnameleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHacizIhbarnameleri.Location = new System.Drawing.Point(0, 0);
            this.gcHacizIhbarnameleri.MainView = this.gvHacizIhbarnameleri;
            this.gcHacizIhbarnameleri.Name = "gcHacizIhbarnameleri";
            this.gcHacizIhbarnameleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueMuhatapCari,
            this.btnBorcluYap});
            this.gcHacizIhbarnameleri.Size = new System.Drawing.Size(819, 470);
            this.gcHacizIhbarnameleri.TabIndex = 11;
            this.gcHacizIhbarnameleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHacizIhbarnameleri});
            // 
            // gvHacizIhbarnameleri
            // 
            this.gvHacizIhbarnameleri.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsSelected,
            this.colID,
            this.colMUHATAP_CARI_ID,
            this.colTEBLIG_TARIH,
            this.colTEBLIGATA_ITIRAZ_TARIHI,
            this.colBORCUN_ODENDIGI_TARIH,
            this.colBILA_TARIHI,
            this.colMENFI_TESPIT_DAVA_TARIHI,
            this.colICRAYA_BELGE_IBRAZ_TARIHI,
            this.colTEBLIGATIN_KESINLESTIGI_TARIH,
            this.colTEBLIGAT_IPTAL_DAVA_TARIHI,
            this.colPOSTA_SON_ISLEM_TARIHI,
            this.colBorcluYap});
            this.gvHacizIhbarnameleri.GridControl = this.gcHacizIhbarnameleri;
            this.gvHacizIhbarnameleri.Name = "gvHacizIhbarnameleri";
            this.gvHacizIhbarnameleri.OptionsView.ColumnAutoWidth = false;
            this.gvHacizIhbarnameleri.OptionsView.ShowGroupPanel = false;
            // 
            // colIsSelected
            // 
            this.colIsSelected.Caption = "Seç";
            this.colIsSelected.FieldName = "IsSelected";
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.Visible = true;
            this.colIsSelected.VisibleIndex = 1;
            this.colIsSelected.Width = 57;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colMUHATAP_CARI_ID
            // 
            this.colMUHATAP_CARI_ID.Caption = "1.Haciz İhbarnamesi Gönderilen ÜÇÜNCÜ Kişi";
            this.colMUHATAP_CARI_ID.ColumnEdit = this.rlueMuhatapCari;
            this.colMUHATAP_CARI_ID.FieldName = "MUHATAP_CARI_ID";
            this.colMUHATAP_CARI_ID.Name = "colMUHATAP_CARI_ID";
            this.colMUHATAP_CARI_ID.Visible = true;
            this.colMUHATAP_CARI_ID.VisibleIndex = 2;
            this.colMUHATAP_CARI_ID.Width = 236;
            // 
            // rlueMuhatapCari
            // 
            this.rlueMuhatapCari.AutoHeight = false;
            this.rlueMuhatapCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueMuhatapCari.Name = "rlueMuhatapCari";
            // 
            // colTEBLIG_TARIH
            // 
            this.colTEBLIG_TARIH.Caption = "Tebliğ T.";
            this.colTEBLIG_TARIH.FieldName = "TEBLIG_TARIH";
            this.colTEBLIG_TARIH.Name = "colTEBLIG_TARIH";
            this.colTEBLIG_TARIH.Visible = true;
            this.colTEBLIG_TARIH.VisibleIndex = 3;
            this.colTEBLIG_TARIH.Width = 63;
            // 
            // colTEBLIGATA_ITIRAZ_TARIHI
            // 
            this.colTEBLIGATA_ITIRAZ_TARIHI.Caption = "İtiraz T.";
            this.colTEBLIGATA_ITIRAZ_TARIHI.FieldName = "TEBLIGATA_ITIRAZ_TARIHI";
            this.colTEBLIGATA_ITIRAZ_TARIHI.Name = "colTEBLIGATA_ITIRAZ_TARIHI";
            this.colTEBLIGATA_ITIRAZ_TARIHI.Visible = true;
            this.colTEBLIGATA_ITIRAZ_TARIHI.VisibleIndex = 4;
            this.colTEBLIGATA_ITIRAZ_TARIHI.Width = 60;
            // 
            // colBORCUN_ODENDIGI_TARIH
            // 
            this.colBORCUN_ODENDIGI_TARIH.Caption = "Borcun Ödendiği T.";
            this.colBORCUN_ODENDIGI_TARIH.FieldName = "BORCUN_ODENDIGI_TARIH";
            this.colBORCUN_ODENDIGI_TARIH.Name = "colBORCUN_ODENDIGI_TARIH";
            this.colBORCUN_ODENDIGI_TARIH.Visible = true;
            this.colBORCUN_ODENDIGI_TARIH.VisibleIndex = 5;
            this.colBORCUN_ODENDIGI_TARIH.Width = 113;
            // 
            // colBILA_TARIHI
            // 
            this.colBILA_TARIHI.Caption = "Bila Tebliğ T.";
            this.colBILA_TARIHI.FieldName = "BILA_TARIHI";
            this.colBILA_TARIHI.Name = "colBILA_TARIHI";
            this.colBILA_TARIHI.Visible = true;
            this.colBILA_TARIHI.VisibleIndex = 6;
            this.colBILA_TARIHI.Width = 82;
            // 
            // colMENFI_TESPIT_DAVA_TARIHI
            // 
            this.colMENFI_TESPIT_DAVA_TARIHI.Caption = "Menfi Tespit Davası Açtığı T.";
            this.colMENFI_TESPIT_DAVA_TARIHI.FieldName = "MENFI_TESPIT_DAVA_TARIHI";
            this.colMENFI_TESPIT_DAVA_TARIHI.Name = "colMENFI_TESPIT_DAVA_TARIHI";
            this.colMENFI_TESPIT_DAVA_TARIHI.Visible = true;
            this.colMENFI_TESPIT_DAVA_TARIHI.VisibleIndex = 7;
            this.colMENFI_TESPIT_DAVA_TARIHI.Width = 157;
            // 
            // colICRAYA_BELGE_IBRAZ_TARIHI
            // 
            this.colICRAYA_BELGE_IBRAZ_TARIHI.Caption = "Dava Açtığına Dair Belgenin İcra Müd.İbraz T.";
            this.colICRAYA_BELGE_IBRAZ_TARIHI.FieldName = "ICRAYA_BELGE_IBRAZ_TARIHI";
            this.colICRAYA_BELGE_IBRAZ_TARIHI.Name = "colICRAYA_BELGE_IBRAZ_TARIHI";
            this.colICRAYA_BELGE_IBRAZ_TARIHI.Visible = true;
            this.colICRAYA_BELGE_IBRAZ_TARIHI.VisibleIndex = 8;
            this.colICRAYA_BELGE_IBRAZ_TARIHI.Width = 240;
            // 
            // colTEBLIGATIN_KESINLESTIGI_TARIH
            // 
            this.colTEBLIGATIN_KESINLESTIGI_TARIH.Caption = "Ödenmedi,Dava Açılmadı,Belge İbraz Edilmedi.Kesinleşme T.";
            this.colTEBLIGATIN_KESINLESTIGI_TARIH.FieldName = "TEBLIGATIN_KESINLESTIGI_TARIH";
            this.colTEBLIGATIN_KESINLESTIGI_TARIH.Name = "colTEBLIGATIN_KESINLESTIGI_TARIH";
            this.colTEBLIGATIN_KESINLESTIGI_TARIH.Visible = true;
            this.colTEBLIGATIN_KESINLESTIGI_TARIH.VisibleIndex = 9;
            this.colTEBLIGATIN_KESINLESTIGI_TARIH.Width = 308;
            // 
            // colTEBLIGAT_IPTAL_DAVA_TARIHI
            // 
            this.colTEBLIGAT_IPTAL_DAVA_TARIHI.Caption = "Menfi Tespit Davası Red Tarihi Kesinleşme T.";
            this.colTEBLIGAT_IPTAL_DAVA_TARIHI.FieldName = "TEBLIGAT_IPTAL_DAVA_TARIHI";
            this.colTEBLIGAT_IPTAL_DAVA_TARIHI.Name = "colTEBLIGAT_IPTAL_DAVA_TARIHI";
            this.colTEBLIGAT_IPTAL_DAVA_TARIHI.Visible = true;
            this.colTEBLIGAT_IPTAL_DAVA_TARIHI.VisibleIndex = 10;
            this.colTEBLIGAT_IPTAL_DAVA_TARIHI.Width = 234;
            // 
            // colPOSTA_SON_ISLEM_TARIHI
            // 
            this.colPOSTA_SON_ISLEM_TARIHI.Caption = "Menfi Tespit Davası Kabul Tarihi";
            this.colPOSTA_SON_ISLEM_TARIHI.FieldName = "POSTA_SON_ISLEM_TARIHI";
            this.colPOSTA_SON_ISLEM_TARIHI.Name = "colPOSTA_SON_ISLEM_TARIHI";
            this.colPOSTA_SON_ISLEM_TARIHI.Visible = true;
            this.colPOSTA_SON_ISLEM_TARIHI.VisibleIndex = 11;
            this.colPOSTA_SON_ISLEM_TARIHI.Width = 173;
            // 
            // colBorcluYap
            // 
            this.colBorcluYap.Caption = "BORÇLU YAP";
            this.colBorcluYap.ColumnEdit = this.btnBorcluYap;
            this.colBorcluYap.Name = "colBorcluYap";
            this.colBorcluYap.Visible = true;
            this.colBorcluYap.VisibleIndex = 0;
            // 
            // btnBorcluYap
            // 
            this.btnBorcluYap.AutoHeight = false;
            this.btnBorcluYap.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnBorcluYap.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.btnBorcluYap.Name = "btnBorcluYap";
            this.btnBorcluYap.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnBorcluYap.Click += new System.EventHandler(this.btnBorcluYap_Click);
            // 
            // frmHacizIhbarnameleri
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 495);
            this.Name = "frmHacizIhbarnameleri";
            this.Text = "Haciz İhbarnameleri";
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcHacizIhbarnameleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHacizIhbarnameleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueMuhatapCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBorcluYap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcHacizIhbarnameleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHacizIhbarnameleri;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSelected;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colMUHATAP_CARI_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueMuhatapCari;
        private DevExpress.XtraGrid.Columns.GridColumn colTEBLIG_TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colTEBLIGATA_ITIRAZ_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colBORCUN_ODENDIGI_TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colBILA_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colMENFI_TESPIT_DAVA_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colICRAYA_BELGE_IBRAZ_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTEBLIGATIN_KESINLESTIGI_TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colTEBLIGAT_IPTAL_DAVA_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colPOSTA_SON_ISLEM_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colBorcluYap;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnBorcluYap;

    }
}