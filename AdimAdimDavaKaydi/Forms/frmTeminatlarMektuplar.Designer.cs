namespace AdimAdimDavaKaydi.Forms
{
    partial class frmTeminatlarMektuplar
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
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.gcMektupListesi = new DevExpress.XtraGrid.GridControl();
            this.gvMektupListesi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBANKA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueBanka = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSUBE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueSube = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colHESAP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEMINAT_TUTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEMINAT_TUTARI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAYIT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMektupListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMektupListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBanka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDoviz)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 373);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(762, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(612, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(687, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.gcMektupListesi);
            this.c_pnlContainer.Controls.Add(this.navBarControl1);
            this.c_pnlContainer.Size = new System.Drawing.Size(762, 398);
            this.c_pnlContainer.Controls.SetChildIndex(this.navBarControl1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.gcMektupListesi, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = null;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 756;
            this.navBarControl1.Size = new System.Drawing.Size(762, 398);
            this.navBarControl1.TabIndex = 10;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // gcMektupListesi
            // 
            this.gcMektupListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMektupListesi.Location = new System.Drawing.Point(0, 0);
            this.gcMektupListesi.MainView = this.gvMektupListesi;
            this.gcMektupListesi.Name = "gcMektupListesi";
            this.gcMektupListesi.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueBanka,
            this.lueSube,
            this.lueDoviz});
            this.gcMektupListesi.Size = new System.Drawing.Size(762, 398);
            this.gcMektupListesi.TabIndex = 11;
            this.gcMektupListesi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMektupListesi});
            // 
            // gvMektupListesi
            // 
            this.gvMektupListesi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBANKA,
            this.colSUBE_ID,
            this.colHESAP_NO,
            this.colTEMINAT_TUTARI,
            this.colTEMINAT_TUTARI_DOVIZ_ID,
            this.colTARIHI,
            this.colACIKLAMA,
            this.colKAYIT_TARIHI});
            this.gvMektupListesi.GridControl = this.gcMektupListesi;
            this.gvMektupListesi.Name = "gvMektupListesi";
            // 
            // colBANKA
            // 
            this.colBANKA.Caption = "Banka";
            this.colBANKA.ColumnEdit = this.lueBanka;
            this.colBANKA.FieldName = "BANKA_ID";
            this.colBANKA.Name = "colBANKA";
            this.colBANKA.Visible = true;
            this.colBANKA.VisibleIndex = 0;
            this.colBANKA.Width = 92;
            // 
            // lueBanka
            // 
            this.lueBanka.AutoHeight = false;
            this.lueBanka.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBanka.Name = "lueBanka";
            // 
            // colSUBE_ID
            // 
            this.colSUBE_ID.Caption = "Şube";
            this.colSUBE_ID.ColumnEdit = this.lueSube;
            this.colSUBE_ID.FieldName = "SUBE_ID";
            this.colSUBE_ID.Name = "colSUBE_ID";
            this.colSUBE_ID.Visible = true;
            this.colSUBE_ID.VisibleIndex = 1;
            this.colSUBE_ID.Width = 92;
            // 
            // lueSube
            // 
            this.lueSube.AutoHeight = false;
            this.lueSube.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSube.Name = "lueSube";
            // 
            // colHESAP_NO
            // 
            this.colHESAP_NO.Caption = "Hesap No";
            this.colHESAP_NO.FieldName = "HESAP_NO";
            this.colHESAP_NO.Name = "colHESAP_NO";
            this.colHESAP_NO.Visible = true;
            this.colHESAP_NO.VisibleIndex = 2;
            this.colHESAP_NO.Width = 92;
            // 
            // colTEMINAT_TUTARI
            // 
            this.colTEMINAT_TUTARI.Caption = "Teminat Tutarı";
            this.colTEMINAT_TUTARI.FieldName = "TEMINAT_TUTARI";
            this.colTEMINAT_TUTARI.Name = "colTEMINAT_TUTARI";
            this.colTEMINAT_TUTARI.Visible = true;
            this.colTEMINAT_TUTARI.VisibleIndex = 3;
            this.colTEMINAT_TUTARI.Width = 92;
            // 
            // colTEMINAT_TUTARI_DOVIZ_ID
            // 
            this.colTEMINAT_TUTARI_DOVIZ_ID.Caption = " ";
            this.colTEMINAT_TUTARI_DOVIZ_ID.ColumnEdit = this.lueDoviz;
            this.colTEMINAT_TUTARI_DOVIZ_ID.FieldName = "TEMINAT_TUTARI_DOVIZ_ID";
            this.colTEMINAT_TUTARI_DOVIZ_ID.Name = "colTEMINAT_TUTARI_DOVIZ_ID";
            this.colTEMINAT_TUTARI_DOVIZ_ID.Visible = true;
            this.colTEMINAT_TUTARI_DOVIZ_ID.VisibleIndex = 4;
            this.colTEMINAT_TUTARI_DOVIZ_ID.Width = 31;
            // 
            // lueDoviz
            // 
            this.lueDoviz.AutoHeight = false;
            this.lueDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDoviz.Name = "lueDoviz";
            // 
            // colTARIHI
            // 
            this.colTARIHI.Caption = "Tarihi";
            this.colTARIHI.FieldName = "TARIHI";
            this.colTARIHI.Name = "colTARIHI";
            this.colTARIHI.Visible = true;
            this.colTARIHI.VisibleIndex = 5;
            this.colTARIHI.Width = 111;
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açıklama";
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 6;
            this.colACIKLAMA.Width = 111;
            // 
            // colKAYIT_TARIHI
            // 
            this.colKAYIT_TARIHI.Caption = "Kayıt Tarihi";
            this.colKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            this.colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
            this.colKAYIT_TARIHI.Visible = true;
            this.colKAYIT_TARIHI.VisibleIndex = 7;
            this.colKAYIT_TARIHI.Width = 120;
            // 
            // frmTeminatlarMektuplar
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 398);
            this.Name = "frmTeminatlarMektuplar";
            this.Text = "Teminat Mektup Listesi";
            this.Load += new System.EventHandler(this.frmTeminatlarMektuplar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMektupListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMektupListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBanka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDoviz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        public DevExpress.XtraGrid.GridControl gcMektupListesi;
        public DevExpress.XtraGrid.Views.Grid.GridView gvMektupListesi;
        private DevExpress.XtraGrid.Columns.GridColumn colBANKA;
        private DevExpress.XtraGrid.Columns.GridColumn colSUBE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colHESAP_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMINAT_TUTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMINAT_TUTARI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colKAYIT_TARIHI;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueBanka;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueSube;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueDoviz;
    }
}