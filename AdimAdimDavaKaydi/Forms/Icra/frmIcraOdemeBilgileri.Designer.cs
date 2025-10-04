namespace  AdimAdimDavaKaydi
{
    partial class frmIcraOdemeBilgileri
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
            this.ucOdemeBilgileri1 = new AdimAdimDavaKaydi.IcraTakip.ucOdemeBilgileri();
            this.ucOdemeBilgileri2 = new AdimAdimDavaKaydi.IcraTakip.ucOdemeBilgileri();
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
            this.c_pnlSag.Location = new System.Drawing.Point(703, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 482);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 482);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 457);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(720, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(570, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(645, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucOdemeBilgileri2);
            this.c_pnlContainer.Size = new System.Drawing.Size(720, 482);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucOdemeBilgileri2, 0);
            // 
            // ucOdemeBilgileri1
            // 
            this.ucOdemeBilgileri1.Foy = null;
            this.ucOdemeBilgileri1.Location = new System.Drawing.Point(1, 0);
            this.ucOdemeBilgileri1.MyDataSource = null;
            this.ucOdemeBilgileri1.MyTarafList = null;
            this.ucOdemeBilgileri1.Name = "ucOdemeBilgileri1";
            this.ucOdemeBilgileri1.Size = new System.Drawing.Size(513, 227);
            this.ucOdemeBilgileri1.TabIndex = 0;
            // 
            // ucOdemeBilgileri2
            // 
            this.ucOdemeBilgileri2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOdemeBilgileri2.Foy = null;
            this.ucOdemeBilgileri2.Location = new System.Drawing.Point(0, 0);
            this.ucOdemeBilgileri2.MyDataSource = null;
            this.ucOdemeBilgileri2.MyTarafList = null;
            this.ucOdemeBilgileri2.Name = "ucOdemeBilgileri2";
            this.ucOdemeBilgileri2.Size = new System.Drawing.Size(720, 457);
            this.ucOdemeBilgileri2.TabIndex = 0;
            // 
            // frmIcraOdemeBilgileri
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(720, 482);
            this.Name = "frmIcraOdemeBilgileri";
            this.Text = "Takip Öncesi Ödeme Bilgileri";
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

        private AdimAdimDavaKaydi.IcraTakip.ucOdemeBilgileri ucOdemeBilgileri1;
        private AdimAdimDavaKaydi.IcraTakip.ucOdemeBilgileri ucOdemeBilgileri2;
    }
}