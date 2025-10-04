namespace AvukatProLib.Bakim
{
    partial class frmSurumGuncelleme
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblYukluSurum = new System.Windows.Forms.Label();
            this.btnVazgec = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yazılacak Sürüm :";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(129, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(131, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(185, 97);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Yüklü Sürüm :";
            // 
            // lblYukluSurum
            // 
            this.lblYukluSurum.AutoSize = true;
            this.lblYukluSurum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYukluSurum.Location = new System.Drawing.Point(126, 31);
            this.lblYukluSurum.Name = "lblYukluSurum";
            this.lblYukluSurum.Size = new System.Drawing.Size(84, 13);
            this.lblYukluSurum.TabIndex = 0;
            this.lblYukluSurum.Text = "Yüklü Sürüm :";
            // 
            // btnVazgec
            // 
            this.btnVazgec.Location = new System.Drawing.Point(104, 97);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(75, 23);
            this.btnVazgec.TabIndex = 2;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.UseVisualStyleBackColor = true;
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // frmSurumGuncelleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 131);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lblYukluSurum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSurumGuncelleme";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sürüm Güncelleme";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSurumGuncelleme_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblYukluSurum;
        private System.Windows.Forms.Button btnVazgec;
    }
}