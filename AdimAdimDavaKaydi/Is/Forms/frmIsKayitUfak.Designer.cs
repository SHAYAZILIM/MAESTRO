namespace  AdimAdimDavaKaydi.Is.Forms
{
    partial class frmIsKayitUfak
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
            this.ucIsKayitUfak1 = new AdimAdimDavaKaydi.Is.UserControls.ucIsKayitUfak();
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
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 730);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(867, 25);
            // 
            // c_pnlFormSakla
            // 
            this.c_pnlFormSakla.Size = new System.Drawing.Size(236, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnFormuYukle
            // 
            this.c_btnFormuYukle.Location = new System.Drawing.Point(49, -1);
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.c_btnIptal.Location = new System.Drawing.Point(712, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(787, 0);
            this.c_btnTamam.Size = new System.Drawing.Size(80, 25);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucIsKayitUfak1);
            this.c_pnlContainer.Dock = System.Windows.Forms.DockStyle.None;
            this.c_pnlContainer.Size = new System.Drawing.Size(867, 755);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucIsKayitUfak1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // ucIsKayitUfak1
            // 
            this.ucIsKayitUfak1.formTipi = 0;
            this.ucIsKayitUfak1.InForm = false;
            this.ucIsKayitUfak1.Location = new System.Drawing.Point(0, 0);
            this.ucIsKayitUfak1.Margin = new System.Windows.Forms.Padding(0);
            this.ucIsKayitUfak1.Modul = 0;
            this.ucIsKayitUfak1.ModulID = 10;
            this.ucIsKayitUfak1.MyDataSource = null;
            this.ucIsKayitUfak1.Name = "ucIsKayitUfak1";
            this.ucIsKayitUfak1.OpenedRecord = null;
            this.ucIsKayitUfak1.Record = null;
            this.ucIsKayitUfak1.Size = new System.Drawing.Size(867, 703);
            this.ucIsKayitUfak1.TabIndex = 15;
            // 
            // frmIsKayitUfak
            // 
            this.AcceptButton = this.c_btnTamam;
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.c_btnIptal;
            this.ClientSize = new System.Drawing.Size(867, 758);
            this.MinimumSize = new System.Drawing.Size(405, 412);
            this.Name = "frmIsKayitUfak";
            this.Text = "Ýþ Kayýt Formu";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmIsKayitUfak_Load);
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

        public AdimAdimDavaKaydi.Is.UserControls.ucIsKayitUfak ucIsKayitUfak1;


    }
}