namespace AdimAdimDavaKaydi.Is
{
    partial class frmIsSozlesmeKategoriEkle
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
            this.txtIsKategori = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.memAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtIsKategori.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAciklama.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIsKategori
            // 
            this.txtIsKategori.Location = new System.Drawing.Point(128, 12);
            this.txtIsKategori.Name = "txtIsKategori";
            this.txtIsKategori.Size = new System.Drawing.Size(208, 20);
            this.txtIsKategori.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Sözleşme Kategorisi";
            // 
            // memAciklama
            // 
            this.memAciklama.Location = new System.Drawing.Point(128, 38);
            this.memAciklama.Name = "memAciklama";
            this.memAciklama.Size = new System.Drawing.Size(208, 61);
            this.memAciklama.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Açıklama";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(253, 106);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // frmIsSozlesmeKategoriEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 138);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.memAciklama);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtIsKategori);
            this.Name = "frmIsSozlesmeKategoriEkle";
            this.Text = "Yeni Iş Sözleşme Ekle";
            ((System.ComponentModel.ISupportInitialize)(this.txtIsKategori.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAciklama.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtIsKategori;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit memAciklama;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
    }
}