namespace  AvukatProLib.Bakim.Firma
{
    partial class frmSubeEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubeEkle));
            this.txtBuroAdi = new DevExpress.XtraEditors.TextEdit();
            this.lblSubeKodu = new DevExpress.XtraEditors.LabelControl();
            this.lblSubeAdi = new DevExpress.XtraEditors.LabelControl();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.rLueBagliBuro = new AvukatProLib.Bakim.UserKontrol.ExtendedLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuroAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBagliBuro.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuroAdi
            // 
            this.txtBuroAdi.Location = new System.Drawing.Point(73, 40);
            this.txtBuroAdi.Name = "txtBuroAdi";
            this.txtBuroAdi.Size = new System.Drawing.Size(194, 20);
            this.txtBuroAdi.TabIndex = 0;
            // 
            // lblSubeKodu
            // 
            this.lblSubeKodu.Location = new System.Drawing.Point(19, 43);
            this.lblSubeKodu.Name = "lblSubeKodu";
            this.lblSubeKodu.Size = new System.Drawing.Size(44, 13);
            this.lblSubeKodu.TabIndex = 1;
            this.lblSubeKodu.Text = "Büro Adý:";
            // 
            // lblSubeAdi
            // 
            this.lblSubeAdi.Location = new System.Drawing.Point(12, 12);
            this.lblSubeAdi.Name = "lblSubeAdi";
            this.lblSubeAdi.Size = new System.Drawing.Size(51, 13);
            this.lblSubeAdi.TabIndex = 2;
            this.lblSubeAdi.Text = "Baðlý Büro:";
            this.lblSubeAdi.Visible = false;
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(111, 89);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Temizle";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(201, 89);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 23);
            this.btnIptal.TabIndex = 4;
            this.btnIptal.Text = "Ýptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(21, 89);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 5;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // rLueBagliBuro
            // 
            this.rLueBagliBuro.Location = new System.Drawing.Point(73, 9);
            this.rLueBagliBuro.Name = "rLueBagliBuro";
            this.rLueBagliBuro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBagliBuro.Size = new System.Drawing.Size(194, 20);
            this.rLueBagliBuro.TabIndex = 6;
            this.rLueBagliBuro.Visible = false;
            // 
            // frmSubeEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 124);
            this.Controls.Add(this.rLueBagliBuro);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.lblSubeAdi);
            this.Controls.Add(this.lblSubeKodu);
            this.Controls.Add(this.txtBuroAdi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSubeEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Þube Ekle";
            this.Load += new System.EventHandler(this.frmSubeEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBuroAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBagliBuro.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtBuroAdi;
        private DevExpress.XtraEditors.LabelControl lblSubeKodu;
        private DevExpress.XtraEditors.LabelControl lblSubeAdi;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private AvukatProLib.Bakim.UserKontrol.ExtendedLookUpEdit rLueBagliBuro;
    }
}