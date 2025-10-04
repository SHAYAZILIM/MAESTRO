namespace  AdimAdimDavaKaydi.Forms
{
    partial class frmParolaDegistirme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParolaDegistirme));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtEskiParola = new DevExpress.XtraEditors.TextEdit();
            this.lblYeniParola1 = new DevExpress.XtraEditors.LabelControl();
            this.txtYeniParola1 = new DevExpress.XtraEditors.TextEdit();
            this.lblYeniParola2 = new DevExpress.XtraEditors.LabelControl();
            this.txtYeniParola2 = new DevExpress.XtraEditors.TextEdit();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEskiParola.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniParola1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniParola2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(68, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Kullanýcý Adý";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(175, 9);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.txtKullaniciAdi.Properties.ReadOnly = true;
            this.txtKullaniciAdi.Size = new System.Drawing.Size(161, 20);
            this.txtKullaniciAdi.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(68, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Eski Parola";
            // 
            // txtEskiParola
            // 
            this.txtEskiParola.Location = new System.Drawing.Point(175, 39);
            this.txtEskiParola.Name = "txtEskiParola";
            this.txtEskiParola.Properties.PasswordChar = '*';
            this.txtEskiParola.Size = new System.Drawing.Size(161, 20);
            this.txtEskiParola.TabIndex = 0;
            // 
            // lblYeniParola1
            // 
            this.lblYeniParola1.Location = new System.Drawing.Point(68, 73);
            this.lblYeniParola1.Name = "lblYeniParola1";
            this.lblYeniParola1.Size = new System.Drawing.Size(53, 13);
            this.lblYeniParola1.TabIndex = 0;
            this.lblYeniParola1.Text = "Yeni Parola";
            // 
            // txtYeniParola1
            // 
            this.txtYeniParola1.Location = new System.Drawing.Point(175, 69);
            this.txtYeniParola1.Name = "txtYeniParola1";
            this.txtYeniParola1.Properties.PasswordChar = '*';
            this.txtYeniParola1.Size = new System.Drawing.Size(161, 20);
            this.txtYeniParola1.TabIndex = 1;
            // 
            // lblYeniParola2
            // 
            this.lblYeniParola2.Location = new System.Drawing.Point(68, 103);
            this.lblYeniParola2.Name = "lblYeniParola2";
            this.lblYeniParola2.Size = new System.Drawing.Size(98, 13);
            this.lblYeniParola2.TabIndex = 0;
            this.lblYeniParola2.Text = "Yeni Parolayý Onayla";
            // 
            // txtYeniParola2
            // 
            this.txtYeniParola2.EditValue = "";
            this.txtYeniParola2.Location = new System.Drawing.Point(175, 99);
            this.txtYeniParola2.Name = "txtYeniParola2";
            this.txtYeniParola2.Properties.PasswordChar = '*';
            this.txtYeniParola2.Size = new System.Drawing.Size(161, 20);
            this.txtYeniParola2.TabIndex = 2;
            // 
            // btnIptal
            // 
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Location = new System.Drawing.Point(268, 128);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(68, 23);
            this.btnIptal.TabIndex = 4;
            this.btnIptal.Text = "Ýptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnTamam
            // 
            this.btnTamam.Location = new System.Drawing.Point(194, 128);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(68, 23);
            this.btnTamam.TabIndex = 3;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::AdimAdimDavaKaydi.Properties.Resources.Administrator_3_22x22;
            this.pictureEdit1.Location = new System.Drawing.Point(12, 13);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Size = new System.Drawing.Size(49, 136);
            this.pictureEdit1.TabIndex = 6;
            // 
            // frmParolaDegistirme
            // 
            this.AcceptButton = this.btnTamam;
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(347, 161);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.txtYeniParola2);
            this.Controls.Add(this.lblYeniParola2);
            this.Controls.Add(this.txtYeniParola1);
            this.Controls.Add(this.lblYeniParola1);
            this.Controls.Add(this.txtEskiParola);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmParolaDegistirme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parola Deðiþtirme";
            this.Load += new System.EventHandler(this.frmParolaDegistirme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEskiParola.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniParola1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniParola2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtEskiParola;
        private DevExpress.XtraEditors.LabelControl lblYeniParola1;
        private DevExpress.XtraEditors.TextEdit txtYeniParola1;
        private DevExpress.XtraEditors.LabelControl lblYeniParola2;
        private DevExpress.XtraEditors.TextEdit txtYeniParola2;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.SimpleButton btnTamam;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}