namespace  AdimAdimDavaKaydi
{
    partial class frmKisayolOlustur
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
            this.btnKisayolOlustur = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnStartMenuEkle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKisayolOlustur
            // 
            this.btnKisayolOlustur.Location = new System.Drawing.Point(12, 10);
            this.btnKisayolOlustur.Name = "btnKisayolOlustur";
            this.btnKisayolOlustur.Size = new System.Drawing.Size(267, 85);
            this.btnKisayolOlustur.TabIndex = 0;
            this.btnKisayolOlustur.Text = "Kısayolları Oluştur";
            this.btnKisayolOlustur.UseVisualStyleBackColor = true;
            this.btnKisayolOlustur.Click += new System.EventHandler(this.btnKisayolOlustur_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Kısayol için klasör seçiniz";
            // 
            // btnStartMenuEkle
            // 
            this.btnStartMenuEkle.Location = new System.Drawing.Point(13, 113);
            this.btnStartMenuEkle.Name = "btnStartMenuEkle";
            this.btnStartMenuEkle.Size = new System.Drawing.Size(267, 85);
            this.btnStartMenuEkle.TabIndex = 0;
            this.btnStartMenuEkle.Text = "Başlangıç\'a Ekle";
            this.btnStartMenuEkle.UseVisualStyleBackColor = true;
            this.btnStartMenuEkle.Click += new System.EventHandler(this.btnStartMenuEkle_Click);
            // 
            // frmKisayolOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnStartMenuEkle);
            this.Controls.Add(this.btnKisayolOlustur);
            this.Name = "frmKisayolOlustur";
            this.Text = "frmKisayolOlustur";
            this.Load += new System.EventHandler(this.frmKisayolOlustur_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKisayolOlustur;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnStartMenuEkle;
    }
}