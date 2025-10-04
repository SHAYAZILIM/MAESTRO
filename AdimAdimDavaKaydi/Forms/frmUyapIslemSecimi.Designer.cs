namespace AdimAdimDavaKaydi.Forms
{
    partial class frmUyapIslemSecimi
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
            this.groupUyapIslemSecimi = new DevExpress.XtraEditors.GroupControl();
            this.sbtnMail = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnKayit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupUyapIslemSecimi)).BeginInit();
            this.groupUyapIslemSecimi.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupUyapIslemSecimi
            // 
            this.groupUyapIslemSecimi.Controls.Add(this.sbtnMail);
            this.groupUyapIslemSecimi.Controls.Add(this.sbtnKayit);
            this.groupUyapIslemSecimi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupUyapIslemSecimi.Location = new System.Drawing.Point(0, 0);
            this.groupUyapIslemSecimi.Name = "groupUyapIslemSecimi";
            this.groupUyapIslemSecimi.Size = new System.Drawing.Size(271, 146);
            this.groupUyapIslemSecimi.TabIndex = 0;
            this.groupUyapIslemSecimi.Text = "UYAP Çıktısını Kullanma Şeklini Seçiniz.";
            // 
            // sbtnMail
            // 
            this.sbtnMail.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnMail.Appearance.ForeColor = System.Drawing.Color.Red;
            this.sbtnMail.Appearance.Options.UseFont = true;
            this.sbtnMail.Appearance.Options.UseForeColor = true;
            this.sbtnMail.Location = new System.Drawing.Point(75, 91);
            this.sbtnMail.Name = "sbtnMail";
            this.sbtnMail.Size = new System.Drawing.Size(127, 23);
            this.sbtnMail.TabIndex = 6;
            this.sbtnMail.Text = "MAİL";
            this.sbtnMail.Click += new System.EventHandler(this.sbtnMail_Click);
            // 
            // sbtnKayit
            // 
            this.sbtnKayit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnKayit.Appearance.ForeColor = System.Drawing.Color.Red;
            this.sbtnKayit.Appearance.Options.UseFont = true;
            this.sbtnKayit.Appearance.Options.UseForeColor = true;
            this.sbtnKayit.Location = new System.Drawing.Point(75, 49);
            this.sbtnKayit.Name = "sbtnKayit";
            this.sbtnKayit.Size = new System.Drawing.Size(127, 23);
            this.sbtnKayit.TabIndex = 5;
            this.sbtnKayit.Text = "KAYIT";
            this.sbtnKayit.Click += new System.EventHandler(this.sbtnKayit_Click);
            // 
            // frmUyapIslemSecimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 146);
            this.Controls.Add(this.groupUyapIslemSecimi);
            this.Name = "frmUyapIslemSecimi";
            this.Text = "UYAP İŞLEM SEÇİMİ";
            ((System.ComponentModel.ISupportInitialize)(this.groupUyapIslemSecimi)).EndInit();
            this.groupUyapIslemSecimi.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupUyapIslemSecimi;
        private DevExpress.XtraEditors.SimpleButton sbtnMail;
        private DevExpress.XtraEditors.SimpleButton sbtnKayit;
    }
}