namespace  AdimAdimDavaKaydi
{
    partial class frmCariGenelGiris
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabSahisBilgileri = new DevExpress.XtraTab.XtraTabPage();
            this.ucCari1 = new AdimAdimDavaKaydi.ucCari();
            this.tabKimlikBilgileri = new DevExpress.XtraTab.XtraTabPage();
            this.ucSahisKimlikBilgileri1 = new AdimAdimDavaKaydi.UserControls.ucSahisKimlikBilgileri();
            this.tabSahisBankaBilgileri = new DevExpress.XtraTab.XtraTabPage();
            this.ucSahisBankaBilgileri1 = new AdimAdimDavaKaydi.UserControls.ucSahisBankaBilgileri();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabSahisBilgileri.SuspendLayout();
            this.tabKimlikBilgileri.SuspendLayout();
            this.tabSahisBankaBilgileri.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(963, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 675);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 675);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 426);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(872, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(722, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(797, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.xtraTabControl1);
            this.c_pnlContainer.Size = new System.Drawing.Size(872, 451);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.xtraTabControl1, 0);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabSahisBilgileri;
            this.xtraTabControl1.Size = new System.Drawing.Size(872, 426);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabSahisBilgileri,
            this.tabKimlikBilgileri,
            this.tabSahisBankaBilgileri});
            // 
            // tabSahisBilgileri
            // 
            this.tabSahisBilgileri.Controls.Add(this.ucCari1);
            this.tabSahisBilgileri.Name = "tabSahisBilgileri";
            this.tabSahisBilgileri.Size = new System.Drawing.Size(866, 398);
            this.tabSahisBilgileri.Text = "Şahıs Bilgileri";
            // 
            // ucCari1
            // 
            this.ucCari1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCari1.Location = new System.Drawing.Point(0, 0);
            this.ucCari1.MyCari = null;
            this.ucCari1.MyDataSource = null;
            this.ucCari1.Name = "ucCari1";
            this.ucCari1.Size = new System.Drawing.Size(866, 398);
            this.ucCari1.TabIndex = 1;
            // 
            // tabKimlikBilgileri
            // 
            this.tabKimlikBilgileri.Controls.Add(this.ucSahisKimlikBilgileri1);
            this.tabKimlikBilgileri.Name = "tabKimlikBilgileri";
            this.tabKimlikBilgileri.Size = new System.Drawing.Size(866, 398);
            this.tabKimlikBilgileri.Text = "Şahısın Kimlik Bilgileri";
            // 
            // ucSahisKimlikBilgileri1
            // 
            this.ucSahisKimlikBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSahisKimlikBilgileri1.Location = new System.Drawing.Point(0, 0);
            this.ucSahisKimlikBilgileri1.MyDataSource = null;
            this.ucSahisKimlikBilgileri1.Name = "ucSahisKimlikBilgileri1";
            this.ucSahisKimlikBilgileri1.Size = new System.Drawing.Size(866, 398);
            this.ucSahisKimlikBilgileri1.TabIndex = 0;
            // 
            // tabSahisBankaBilgileri
            // 
            this.tabSahisBankaBilgileri.Controls.Add(this.ucSahisBankaBilgileri1);
            this.tabSahisBankaBilgileri.Name = "tabSahisBankaBilgileri";
            this.tabSahisBankaBilgileri.Size = new System.Drawing.Size(866, 398);
            this.tabSahisBankaBilgileri.Text = "Şahsın Banka Bilgileri";
            // 
            // ucSahisBankaBilgileri1
            // 
            this.ucSahisBankaBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSahisBankaBilgileri1.Location = new System.Drawing.Point(0, 0);
            this.ucSahisBankaBilgileri1.MyDataBankaSource = null;
            this.ucSahisBankaBilgileri1.Name = "ucSahisBankaBilgileri1";
            this.ucSahisBankaBilgileri1.Size = new System.Drawing.Size(866, 398);
            this.ucSahisBankaBilgileri1.TabIndex = 0;
            // 
            // frmCariGenelGiris
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 451);
            this.Name = "frmCariGenelGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avukatpro Hukuk Ailesi Şahıs Kayıt Ekranı";
            this.UstMenu = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCariGenelGiris_FormClosing);
            this.Load += new System.EventHandler(this.frmCariGenelGiris_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabSahisBilgileri.ResumeLayout(false);
            this.tabKimlikBilgileri.ResumeLayout(false);
            this.tabSahisBankaBilgileri.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        //private DevExpress.XtraBars.BarButtonItem bbtnKaydet;
        //private DevExpress.XtraBars.BarButtonItem bbtnFarkliKaydet;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        //private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        //private DevExpress.XtraBars.BarButtonItem bbtnYeni;
        //private DevExpress.XtraBars.BarButtonItem bbtnCikis;
        //private DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem1;
        //private DevExpress.XtraBars.BarButtonItem bbtnDegistir;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabSahisBilgileri;
        private ucCari ucCari1;
        private DevExpress.XtraTab.XtraTabPage tabKimlikBilgileri;
        private AdimAdimDavaKaydi.UserControls.ucSahisKimlikBilgileri ucSahisKimlikBilgileri1;
        private DevExpress.XtraTab.XtraTabPage tabSahisBankaBilgileri;
        private UserControls.ucSahisBankaBilgileri ucSahisBankaBilgileri1;
        //private AdimAdimDavaKaydi.ExtendTool.compRibbonExtender compRibbonExtender1;
    }
}
