namespace  AdimAdimDavaKaydi.IcraTakipForms
{
    partial class frmKefaletBilgileri
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
            this.ucKefaletBilgileri1 = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucKefaletBilgileri();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(537, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 456);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 456);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 431);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(554, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(404, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(479, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucKefaletBilgileri1);
            this.c_pnlContainer.Size = new System.Drawing.Size(554, 456);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucKefaletBilgileri1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // ucKefaletBilgileri1
            // 
            this.ucKefaletBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKefaletBilgileri1.Location = new System.Drawing.Point(0, 0);
            this.ucKefaletBilgileri1.MyView = AvukatProLib.Extras.ViewType.VGrid;
            this.ucKefaletBilgileri1.Name = "ucKefaletBilgileri1";
            this.ucKefaletBilgileri1.Size = new System.Drawing.Size(554, 456);
            this.ucKefaletBilgileri1.TabIndex = 0;
            // 
            // frmKefaletBilgileri
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 456);
            this.FormunBolumu = AdimAdimDavaKaydi.Util.BaseClasses.FormBolumu.Icra;
            this.FormunTipi = AdimAdimDavaKaydi.Util.BaseClasses.FormTipi.KayitFormu;
            this.Name = "frmKefaletBilgileri";
            this.Text = "Kefalet Bilgileri Kayýt Formu";
            this.UstMenu = true;
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucKefaletBilgileri ucKefaletBilgileri1;
    }
}