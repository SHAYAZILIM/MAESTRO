namespace  AdimAdimDavaKaydi.Forms.Dava
{
    partial class rFrmTeminatBilgileriKaydet
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
            this.ucTeminatKefaletKayitForDava1 = new AdimAdimDavaKaydi.UserControls.UcDava.ucTeminatKefaletKayitForDava();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            
            
            
            this.SuspendLayout();
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucTeminatKefaletKayitForDava1);
            this.c_pnlContainer.Size = new System.Drawing.Size(715, 412);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucTeminatKefaletKayitForDava1, 0);
 
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(732, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 466);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 466);
            // 
            // c_pnlAltButtons
            // 
 
 
            // 
            // c_btnIptal
            // 
 
            // 
            // c_btnTamam
            // 
 
            // 
            // prgEnAlt
            // 
            // 
            // c_btnYardim
            // 
 
 
 
 
 
 
 
 
 
 
 
 
 
            // 
            // c_btnCaption
            // 
 
 
 
 
 
 
 
 
            // 
            // ucTeminatKefaletKayitForDava1
            // 
            this.ucTeminatKefaletKayitForDava1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTeminatKefaletKayitForDava1.Location = new System.Drawing.Point(0, 0);
            this.ucTeminatKefaletKayitForDava1.MView = AvukatProLib.Extras.ViewType.VGrid;


            this.ucTeminatKefaletKayitForDava1.Name = "ucTeminatKefaletKayitForDava1";
            this.ucTeminatKefaletKayitForDava1.Size = new System.Drawing.Size(715, 412);
            this.ucTeminatKefaletKayitForDava1.TabIndex = 2;
            // 
            // rFrmTeminatBilgileriKaydet
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 466);
            this.FormunBolumu = AdimAdimDavaKaydi.Util.BaseClasses.FormBolumu.Dava;
            this.FormunTipi = AdimAdimDavaKaydi.Util.BaseClasses.FormTipi.UfakKayitFormu;
            this.Name = "rFrmTeminatBilgileriKaydet";
            this.Text = "Avukatpro Hukuk Ailesi Teminat Bilgileri Kayýt Formu";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.rFrmTeminatBilgileriKaydet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
 
 
 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //private DevExpress.XtraBars.BarButtonItem bBtnKaydet;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucTeminatKefaletKayitForDava ucTeminatKefaletKayitForDava1;
    }
}