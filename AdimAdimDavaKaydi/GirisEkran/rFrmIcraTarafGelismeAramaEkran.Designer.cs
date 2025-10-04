namespace  AdimAdimDavaKaydi.GirisEkran
{
    partial class rFrmIcraTarafGelismeAramaEkran
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
            this.ucIcraTarafGelismeBilgileri1 = new AdimAdimDavaKaydi.UserControls.ucIcraTarafGelismeBilgileri();
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
            this.c_pnlContainer.Controls.Add(this.ucIcraTarafGelismeBilgileri1);
            this.c_pnlContainer.Size = new System.Drawing.Size(922, 658);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucIcraTarafGelismeBilgileri1, 0);
            // 
            // ucIcraTarafGelismeBilgileri1
            // 
            this.ucIcraTarafGelismeBilgileri1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.ucIcraTarafGelismeBilgileri1.Appearance.Options.UseBackColor = true;
            this.ucIcraTarafGelismeBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIcraTarafGelismeBilgileri1.Location = new System.Drawing.Point(0, 0);
            this.ucIcraTarafGelismeBilgileri1.MyDataSource = null;
            this.ucIcraTarafGelismeBilgileri1.Name = "ucIcraTarafGelismeBilgileri1";
            this.ucIcraTarafGelismeBilgileri1.Size = new System.Drawing.Size(922, 633);
            this.ucIcraTarafGelismeBilgileri1.TabIndex = 10;
            // 
            // rFrmIcraTarafGelismeAramaEkran
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(922, 658);
            this.Name = "rFrmIcraTarafGelismeAramaEkran";
            this.Text = "Borçlu Takip Gelişme Bilgileri";
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

        private AdimAdimDavaKaydi.UserControls.ucIcraTarafGelismeBilgileri ucIcraTarafGelismeBilgileri1;
    }
}
