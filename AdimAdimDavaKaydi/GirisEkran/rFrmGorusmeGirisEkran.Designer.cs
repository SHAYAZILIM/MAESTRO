
using AdimAdimDavaKaydi.UserControls.AramaUserKontrol;
namespace  AdimAdimDavaKaydi.GirisEkran
{
    partial class rFrmGorusmeGirisEkran
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
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.ucGorusmeler1 = new AdimAdimDavaKaydi.UserControls.AramaUserKontrol.ucGorusmeArama();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(878, 33);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 474);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Location = new System.Drawing.Point(0, 33);
            this.c_pnlSol.Size = new System.Drawing.Size(17, 474);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 503);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(895, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(745, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(820, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucGorusmeler1);
            this.c_pnlContainer.Size = new System.Drawing.Size(895, 528);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucGorusmeler1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // ucGorusmeler1
            // 
            this.ucGorusmeler1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGorusmeler1.Location = new System.Drawing.Point(0, 0);
            this.ucGorusmeler1.MyDataSource = null;
            this.ucGorusmeler1.Name = "ucGorusmeler1";
            this.ucGorusmeler1.Size = new System.Drawing.Size(895, 528);
            this.ucGorusmeler1.TabIndex = 2;
            // 
            // rFrmGorusmeGirisEkran
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 528);
            this.FormunBolumu = AdimAdimDavaKaydi.Util.BaseClasses.FormBolumu.Gorusme;
            this.FormunTipi = AdimAdimDavaKaydi.Util.BaseClasses.FormTipi.GirisFormu;
            this.Name = "rFrmGorusmeGirisEkran";
            this.Text = "Avukatpro Hukuk Ailesi Görüþme Giriþ Ekraný";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.rFrmGorusmeGirisEkran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private ucGorusmeArama ucGorusmeler1;
    }
}