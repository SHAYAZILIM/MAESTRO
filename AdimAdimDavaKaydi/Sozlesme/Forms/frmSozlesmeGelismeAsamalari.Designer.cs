namespace  AdimAdimDavaKaydi.Sozlesme.Forms
{
    partial class frmSozlesmeGelismeAsamalari
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
            this.vgAsama = new DevExpress.XtraVerticalGrid.VGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueGelismeAdim = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rDateTarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rMemoAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.aciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.rowGELISME_ADIM_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTARAF_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTARIH = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowACIKLAMA = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.dnAsama = new DevExpress.XtraEditors.DataNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vgAsama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGelismeAdim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMemoAciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aciklama)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(655, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 377);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 377);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 352);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(672, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(522, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(597, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.vgAsama);
            this.c_pnlContainer.Controls.Add(this.dnAsama);
            this.c_pnlContainer.Size = new System.Drawing.Size(672, 377);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.dnAsama, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.vgAsama, 0);
            // 
            // vgAsama
            // 
            this.vgAsama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgAsama.ExternalRepository = this.MyRepository;
            this.vgAsama.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vgAsama.Location = new System.Drawing.Point(0, 0);
            this.vgAsama.Name = "vgAsama";
            this.vgAsama.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowGELISME_ADIM_ID,
            this.rowTARAF_ID,
            this.rowTARIH,
            this.rowACIKLAMA});
            this.vgAsama.Size = new System.Drawing.Size(672, 328);
            this.vgAsama.TabIndex = 9;
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueGelismeAdim,
            this.rLueCari,
            this.rDateTarih,
            this.rMemoAciklama,
            this.aciklama});
            // 
            // rLueGelismeAdim
            // 
            this.rLueGelismeAdim.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueGelismeAdim.Name = "rLueGelismeAdim";
            // 
            // rLueCari
            // 
            this.rLueCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueCari.Name = "rLueCari";
            // 
            // rDateTarih
            // 
            this.rDateTarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rDateTarih.Name = "rDateTarih";
            this.rDateTarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rMemoAciklama
            // 
            this.rMemoAciklama.Name = "rMemoAciklama";
            // 
            // aciklama
            // 
            this.aciklama.AutoHeight = false;
            this.aciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.aciklama.Name = "aciklama";
            // 
            // rowGELISME_ADIM_ID
            // 
            this.rowGELISME_ADIM_ID.Name = "rowGELISME_ADIM_ID";
            this.rowGELISME_ADIM_ID.Properties.Caption = "Geliþme Adým";
            this.rowGELISME_ADIM_ID.Properties.FieldName = "GELISME_ADIM_ID";
            this.rowGELISME_ADIM_ID.Properties.RowEdit = this.rLueGelismeAdim;
            // 
            // rowTARAF_ID
            // 
            this.rowTARAF_ID.Name = "rowTARAF_ID";
            this.rowTARAF_ID.Properties.Caption = "Taraf";
            this.rowTARAF_ID.Properties.FieldName = "TARAF_ID";
            this.rowTARAF_ID.Properties.RowEdit = this.rLueCari;
            // 
            // rowTARIH
            // 
            this.rowTARIH.Name = "rowTARIH";
            this.rowTARIH.Properties.Caption = "Tarih";
            this.rowTARIH.Properties.FieldName = "TARIH";
            this.rowTARIH.Properties.RowEdit = this.rDateTarih;
            // 
            // rowACIKLAMA
            // 
            this.rowACIKLAMA.Height = 123;
            this.rowACIKLAMA.Name = "rowACIKLAMA";
            this.rowACIKLAMA.Properties.Caption = "Açýklama";
            this.rowACIKLAMA.Properties.FieldName = "ACIKLAMA";
            this.rowACIKLAMA.Properties.RowEdit = this.aciklama;
            // 
            // dnAsama
            // 
            this.dnAsama.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dnAsama.Location = new System.Drawing.Point(0, 328);
            this.dnAsama.Name = "dnAsama";
            this.dnAsama.Size = new System.Drawing.Size(672, 24);
            this.dnAsama.TabIndex = 10;
            this.dnAsama.Text = "dataNavigator1";
            this.dnAsama.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.dnAsama.TextStringFormat = "Kayit {0} / {1}";
            // 
            // frmSozlesmeGelismeAsamalari
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 377);
            this.Name = "frmSozlesmeGelismeAsamalari";
            this.Text = "Sözleþme Geliþme Aþamalarý Kayýt Formu";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmSozlesmeGelismeAsamalari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vgAsama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGelismeAdim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMemoAciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aciklama)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl vgAsama;
        private DevExpress.XtraEditors.DataNavigator dnAsama;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowGELISME_ADIM_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTARAF_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTARIH;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowACIKLAMA;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueGelismeAdim;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rDateTarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit rMemoAciklama;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit aciklama;
    }
}