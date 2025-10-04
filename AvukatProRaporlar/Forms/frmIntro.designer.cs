namespace AvukatProRaporlar.Forms
{
    partial class frmIntro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntro));
            this.lblSurumBilgisi = new System.Windows.Forms.Label();
            this.lblKullanici = new System.Windows.Forms.Label();
            this.lblLisansNo = new System.Windows.Forms.Label();
            this.txteKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.txteSifreBilgi = new DevExpress.XtraEditors.TextEdit();
            this.lkSirket = new DevExpress.XtraEditors.LookUpEdit();
            this.lkSube = new DevExpress.XtraEditors.LookUpEdit();
            this.bwYukleyici = new System.ComponentModel.BackgroundWorker();
            this.ýmageList1 = new System.Windows.Forms.ImageList();
            this.picCik = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txteKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txteSifreBilgi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkSirket.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkSube.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCik.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSurumBilgisi
            // 
            this.lblSurumBilgisi.AutoSize = true;
            this.lblSurumBilgisi.BackColor = System.Drawing.Color.Transparent;
            this.lblSurumBilgisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSurumBilgisi.ForeColor = System.Drawing.Color.Maroon;
            this.lblSurumBilgisi.Location = new System.Drawing.Point(377, 241);
            this.lblSurumBilgisi.Name = "lblSurumBilgisi";
            this.lblSurumBilgisi.Size = new System.Drawing.Size(89, 15);
            this.lblSurumBilgisi.TabIndex = 3;
            this.lblSurumBilgisi.Text = "ALFA v1.0.34";
            // 
            // lblKullanici
            // 
            this.lblKullanici.BackColor = System.Drawing.Color.Transparent;
            this.lblKullanici.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullanici.ForeColor = System.Drawing.Color.Maroon;
            this.lblKullanici.Location = new System.Drawing.Point(12, 253);
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Size = new System.Drawing.Size(270, 15);
            this.lblKullanici.TabIndex = 7;
            this.lblKullanici.Text = "Avukatpro Yazýlým Ltd.";
            this.lblKullanici.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKullanici.Click += new System.EventHandler(this.lblKullanici_Click);
            // 
            // lblLisansNo
            // 
            this.lblLisansNo.BackColor = System.Drawing.Color.Transparent;
            this.lblLisansNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLisansNo.ForeColor = System.Drawing.Color.Maroon;
            this.lblLisansNo.Location = new System.Drawing.Point(12, 297);
            this.lblLisansNo.Name = "lblLisansNo";
            this.lblLisansNo.Size = new System.Drawing.Size(270, 15);
            this.lblLisansNo.TabIndex = 8;
            this.lblLisansNo.Text = "AVPNG 11-88-33-895308";
            this.lblLisansNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLisansNo.Click += new System.EventHandler(this.lblLisansNo_Click);
            // 
            // txteKullaniciAdi
            // 
            this.txteKullaniciAdi.EditValue = "";
            this.txteKullaniciAdi.Enabled = false;
            this.txteKullaniciAdi.Location = new System.Drawing.Point(379, 306);
            this.txteKullaniciAdi.Name = "txteKullaniciAdi";
            this.txteKullaniciAdi.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txteKullaniciAdi.Properties.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.txteKullaniciAdi.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.txteKullaniciAdi.Properties.Appearance.Options.UseBackColor = true;
            this.txteKullaniciAdi.Properties.Appearance.Options.UseBorderColor = true;
            this.txteKullaniciAdi.Properties.Appearance.Options.UseForeColor = true;
            this.txteKullaniciAdi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Transparent;
            this.txteKullaniciAdi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txteKullaniciAdi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txteKullaniciAdi.Size = new System.Drawing.Size(125, 18);
            this.txteKullaniciAdi.TabIndex = 0;
            this.txteKullaniciAdi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txteKullaniciAdi_KeyUp);
            // 
            // txteSifreBilgi
            // 
            this.txteSifreBilgi.EditValue = "";
            this.txteSifreBilgi.Enabled = false;
            this.txteSifreBilgi.Location = new System.Drawing.Point(379, 329);
            this.txteSifreBilgi.Name = "txteSifreBilgi";
            this.txteSifreBilgi.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txteSifreBilgi.Properties.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.txteSifreBilgi.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.txteSifreBilgi.Properties.Appearance.Options.UseBackColor = true;
            this.txteSifreBilgi.Properties.Appearance.Options.UseForeColor = true;
            this.txteSifreBilgi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txteSifreBilgi.Properties.PasswordChar = '*';
            this.txteSifreBilgi.Size = new System.Drawing.Size(125, 18);
            this.txteSifreBilgi.TabIndex = 1;
            this.txteSifreBilgi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txteSifreBilgi_KeyUp);
            // 
            // lkSirket
            // 
            this.lkSirket.Location = new System.Drawing.Point(376, 263);
            this.lkSirket.Name = "lkSirket";
            this.lkSirket.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lkSirket.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lkSirket.Properties.Appearance.Options.UseBackColor = true;
            this.lkSirket.Properties.Appearance.Options.UseForeColor = true;
            this.lkSirket.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lkSirket.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkSirket.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", 200, "Þirket")});
            this.lkSirket.Properties.NullText = "Þirket Seçiniz";
            this.lkSirket.Size = new System.Drawing.Size(169, 18);
            this.lkSirket.TabIndex = 4;
            this.lkSirket.EditValueChanged += new System.EventHandler(this.lkSirket_EditValueChanged);
            // 
            // lkSube
            // 
            this.lkSube.Location = new System.Drawing.Point(377, 284);
            this.lkSube.Name = "lkSube";
            this.lkSube.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lkSube.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lkSube.Properties.Appearance.Options.UseBackColor = true;
            this.lkSube.Properties.Appearance.Options.UseForeColor = true;
            this.lkSube.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lkSube.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkSube.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SUBE_ADI", 200, "Þube Adý")});
            this.lkSube.Properties.DisplayMember = "SUBE_ADI";
            this.lkSube.Properties.NullText = "Büro Seçiniz";
            this.lkSube.Properties.ValueMember = "ID";
            this.lkSube.Size = new System.Drawing.Size(168, 18);
            this.lkSube.TabIndex = 5;
            // 
            // bwYukleyici
            // 
            this.bwYukleyici.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwYukleyici_DoWork);
            this.bwYukleyici.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwYukleyici_RunWorkerCompleted);
            // 
            // ýmageList1
            // 
            this.ýmageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ýmageList1.ImageStream")));
            this.ýmageList1.TransparentColor = System.Drawing.Color.Transparent;
            //this.ýmageList1.Images.SetKeyName(0, "anhtar_kirmizi.png");
            //this.ýmageList1.Images.SetKeyName(1, "anhtar_kirmizi_hover.png");
            //this.ýmageList1.Images.SetKeyName(2, "anhtar_kirmizi_cevreli.png");
            //this.ýmageList1.Images.SetKeyName(3, "anhtar_yesil.png");
            // 
            // picCik
            // 
            this.picCik.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCik.EditValue = ((object)(resources.GetObject("picCik.EditValue")));
            this.picCik.Location = new System.Drawing.Point(2, 3);
            this.picCik.Name = "picCik";
            this.picCik.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picCik.Properties.Appearance.Options.UseBackColor = true;
            this.picCik.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picCik.Size = new System.Drawing.Size(33, 33);
            this.picCik.TabIndex = 6;
            this.picCik.EditValueChanged += new System.EventHandler(this.picCik_EditValueChanged);
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureEdit2.EditValue = ((object)(resources.GetObject("pictureEdit2.EditValue")));
            this.pictureEdit2.Location = new System.Drawing.Point(506, 304);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Size = new System.Drawing.Size(42, 43);
            this.pictureEdit2.TabIndex = 2;
            this.pictureEdit2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureEdit1_MouseClick);
            // 
            // frmIntro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(550, 350);
            this.ControlBox = false;
            this.Controls.Add(this.pictureEdit2);
            this.Controls.Add(this.picCik);
            this.Controls.Add(this.lkSube);
            this.Controls.Add(this.lkSirket);
            this.Controls.Add(this.txteSifreBilgi);
            this.Controls.Add(this.txteKullaniciAdi);
            this.Controls.Add(this.lblKullanici);
            this.Controls.Add(this.lblLisansNo);
            this.Controls.Add(this.lblSurumBilgisi);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmIntro";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avukatpro Hukuk Ailesi Yeni Nesil Kullanýcý Giriþ Ekraný ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmIntro_Load);
            this.Shown += new System.EventHandler(this.frmIntro_Shown);
            this.Click += new System.EventHandler(this.frmIntro_Click);
            this.DoubleClick += new System.EventHandler(this.frmIntro_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmIntro_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txteKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txteSifreBilgi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkSirket.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkSube.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCik.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSurumBilgisi;
        private System.Windows.Forms.Label lblKullanici;
        private System.Windows.Forms.Label lblLisansNo;
        private DevExpress.XtraEditors.TextEdit txteKullaniciAdi;
        private DevExpress.XtraEditors.TextEdit txteSifreBilgi;
        private DevExpress.XtraEditors.LookUpEdit lkSirket;
        private DevExpress.XtraEditors.LookUpEdit lkSube;
        private System.ComponentModel.BackgroundWorker bwYukleyici;
        private System.Windows.Forms.ImageList ýmageList1;
        private DevExpress.XtraEditors.PictureEdit picCik;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
    }
}