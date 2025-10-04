namespace AdimAdimDavaKaydi.Forms
{
    partial class frmSikKullanilanDuzenle
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
            this.pnlKategoriBilgileri = new System.Windows.Forms.Panel();
            this.lblKategoriIsim = new DevExpress.XtraEditors.LabelControl();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.txtKategori = new DevExpress.XtraEditors.TextEdit();
            this.pnlKategoriBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKategori.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlKategoriBilgileri
            // 
            this.pnlKategoriBilgileri.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlKategoriBilgileri.Controls.Add(this.lblKategoriIsim);
            this.pnlKategoriBilgileri.Controls.Add(this.btnKaydet);
            this.pnlKategoriBilgileri.Controls.Add(this.txtKategori);
            this.pnlKategoriBilgileri.Location = new System.Drawing.Point(12, 3);
            this.pnlKategoriBilgileri.Name = "pnlKategoriBilgileri";
            this.pnlKategoriBilgileri.Size = new System.Drawing.Size(227, 63);
            this.pnlKategoriBilgileri.TabIndex = 0;
            // 
            // lblKategoriIsim
            // 
            this.lblKategoriIsim.Location = new System.Drawing.Point(22, 10);
            this.lblKategoriIsim.Name = "lblKategoriIsim";
            this.lblKategoriIsim.Size = new System.Drawing.Size(40, 13);
            this.lblKategoriIsim.TabIndex = 16;
            this.lblKategoriIsim.Text = "Kategori";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(103, 31);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(102, 23);
            this.btnKaydet.TabIndex = 15;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtKategori
            // 
            this.txtKategori.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKategori.Location = new System.Drawing.Point(103, 7);
            this.txtKategori.Name = "txtKategori";
            this.txtKategori.Size = new System.Drawing.Size(102, 20);
            this.txtKategori.TabIndex = 14;
            // 
            // frmSikKullanilanDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 69);
            this.Controls.Add(this.pnlKategoriBilgileri);
            this.Name = "frmSikKullanilanDuzenle";
            this.Text = "Kategori Adı Değiştir";
            this.Load += new System.EventHandler(this.frmSikKullanilanDuzenle_Load);
            this.pnlKategoriBilgileri.ResumeLayout(false);
            this.pnlKategoriBilgileri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKategori.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlKategoriBilgileri;
        private DevExpress.XtraEditors.LabelControl lblKategoriIsim;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.TextEdit txtKategori;

    }
}