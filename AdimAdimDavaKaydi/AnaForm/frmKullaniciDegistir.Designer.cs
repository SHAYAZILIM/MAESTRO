namespace AdimAdimDavaKaydi.AnaForm
{
    partial class frmKullaniciDegistir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKullaniciDegistir));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnVazgec = new System.Windows.Forms.Button();
            this.btnDevam = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txteSifreBilgi = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 71);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnVazgec
            // 
            this.btnVazgec.Location = new System.Drawing.Point(179, 93);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(75, 23);
            this.btnVazgec.TabIndex = 3;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.UseVisualStyleBackColor = true;
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // btnDevam
            // 
            this.btnDevam.Location = new System.Drawing.Point(257, 93);
            this.btnDevam.Name = "btnDevam";
            this.btnDevam.Size = new System.Drawing.Size(75, 23);
            this.btnDevam.TabIndex = 2;
            this.btnDevam.Text = "Devam";
            this.btnDevam.UseVisualStyleBackColor = true;
            this.btnDevam.Click += new System.EventHandler(this.btnDevam_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şifresi :";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(165, 30);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(167, 20);
            this.txtKullaniciAdi.TabIndex = 0;
            // 
            // txteSifreBilgi
            // 
            this.txteSifreBilgi.Location = new System.Drawing.Point(165, 53);
            this.txteSifreBilgi.Name = "txteSifreBilgi";
            this.txteSifreBilgi.PasswordChar = '*';
            this.txteSifreBilgi.Size = new System.Drawing.Size(167, 20);
            this.txteSifreBilgi.TabIndex = 1;
            // 
            // frmKullaniciDegistir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 129);
            this.Controls.Add(this.txteSifreBilgi);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDevam);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKullaniciDegistir";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Değiştir";
            this.Load += new System.EventHandler(this.frmKullaniciDegistir_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKullaniciDegistir_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnVazgec;
        private System.Windows.Forms.Button btnDevam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txteSifreBilgi;
    }
}