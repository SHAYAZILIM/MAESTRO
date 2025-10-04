namespace AdimAdimDavaKaydi.IcraTakipForms
{
    partial class frmIcraTarafGelismeler
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
            this.ucIcraTarafGelismeleri1 = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri();
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
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 498);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(507, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(357, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(432, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucIcraTarafGelismeleri1);
            this.c_pnlContainer.Size = new System.Drawing.Size(507, 523);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucIcraTarafGelismeleri1, 0);
            // 
            // ucIcraTarafGelismeleri1
            // 
            this.ucIcraTarafGelismeleri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIcraTarafGelismeleri1.Location = new System.Drawing.Point(0, 0);
            this.ucIcraTarafGelismeleri1.Name = "ucIcraTarafGelismeleri1";
            this.ucIcraTarafGelismeleri1.Size = new System.Drawing.Size(507, 498);
            this.ucIcraTarafGelismeleri1.TabIndex = 12;
            // 
            // frmIcraTarafGelismeler
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 523);
            this.Name = "frmIcraTarafGelismeler";
            this.Text = "Gelişmeler";
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

        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri ucIcraTarafGelismeleri1;

    }
}