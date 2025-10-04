namespace  AdimAdimDavaKaydi.GirisEkran
{
    partial class rFrmTeminatMektupGirisEkran
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
            this.ucTeminatMektupBilgiler1 = new AdimAdimDavaKaydi.UserControls.ucTeminatMektupBilgiler();
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
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 633);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucTeminatMektupBilgiler1);
            this.c_pnlContainer.Size = new System.Drawing.Size(922, 658);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucTeminatMektupBilgiler1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // ucTeminatMektupBilgiler1
            // 
            this.ucTeminatMektupBilgiler1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTeminatMektupBilgiler1.Location = new System.Drawing.Point(0, 0);
            this.ucTeminatMektupBilgiler1.MyDataSource = null;
            this.ucTeminatMektupBilgiler1.Name = "ucTeminatMektupBilgiler1";
            this.ucTeminatMektupBilgiler1.Size = new System.Drawing.Size(922, 658);
            this.ucTeminatMektupBilgiler1.TabIndex = 9;
            // 
            // rFrmTeminatMektupGirisEkran
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(922, 658);
            this.Name = "rFrmTeminatMektupGirisEkran";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.rFrmTeminatMektupGirisEkran_Load);
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

        private AdimAdimDavaKaydi.UserControls.ucTeminatMektupBilgiler ucTeminatMektupBilgiler1;
    }
}
