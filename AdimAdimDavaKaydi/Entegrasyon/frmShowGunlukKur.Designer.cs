namespace AdimAdimDavaKaydi.Entegrasyon
{
    partial class frmShowGunlukKur
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
            this.sbtnKurGetir = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // sbtnKurGetir
            // 
            this.sbtnKurGetir.Location = new System.Drawing.Point(61, 38);
            this.sbtnKurGetir.Name = "sbtnKurGetir";
            this.sbtnKurGetir.Size = new System.Drawing.Size(138, 23);
            this.sbtnKurGetir.TabIndex = 0;
            this.sbtnKurGetir.Text = "Kur Bilgisi Güncelle";
            this.sbtnKurGetir.Click += new System.EventHandler(this.sbtnKurGetir_Click);
            // 
            // frmKurUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 106);
            this.Controls.Add(this.sbtnKurGetir);
            this.Name = "frmKurUpdate";
            this.Text = "Kur Bilgisi Güncelleme Ekranı";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbtnKurGetir;
    }
}