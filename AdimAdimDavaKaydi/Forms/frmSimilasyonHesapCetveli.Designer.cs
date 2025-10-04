namespace  AdimAdimDavaKaydi.Forms
{
    partial class frmSimilasyonHesapCetveli
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
            this.ucSimulasyonHesapCetveli1 = new AdimAdimDavaKaydi.UserControls.ucSimulasyonHesapCetveli();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // ucSimulasyonHesapCetveli1
            // 
            this.ucSimulasyonHesapCetveli1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSimulasyonHesapCetveli1.Location = new System.Drawing.Point(0, 0);
            this.ucSimulasyonHesapCetveli1.Name = "ucSimulasyonHesapCetveli1";
            this.ucSimulasyonHesapCetveli1.Size = new System.Drawing.Size(562, 489);
            this.ucSimulasyonHesapCetveli1.TabIndex = 9;
            // 
            // btnTamam
            // 
            this.btnTamam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTamam.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTamam.Location = new System.Drawing.Point(397, 493);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(75, 23);
            this.btnTamam.TabIndex = 10;
            this.btnTamam.Text = "Tamam";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton2.Location = new System.Drawing.Point(478, 493);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 10;
            this.simpleButton2.Text = "Vazgeç";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // frmSimilasyonHesapCetveli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 518);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.ucSimulasyonHesapCetveli1);
            this.Name = "frmSimilasyonHesapCetveli";
            this.Text = "Avukatpro - Simülasyon Hesap Cetveli";
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.UserControls.ucSimulasyonHesapCetveli ucSimulasyonHesapCetveli1;
        private DevExpress.XtraEditors.SimpleButton btnTamam;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;

    }
}