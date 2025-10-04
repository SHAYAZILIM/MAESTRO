using DevExpress.XtraEditors;
namespace  AdimAdimDavaKaydi.Generalclass.Forms
{
    partial class frmIstek
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
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.c_pnlButtons = new System.Windows.Forms.Panel();
            this.gBoxSecenekler = new System.Windows.Forms.GroupBox();
            this.pictureBoxPTT = new System.Windows.Forms.PictureBox();
            this.gBoxAdiPosta = new System.Windows.Forms.GroupBox();
            this.rdButtonAdiPostaAPS = new System.Windows.Forms.RadioButton();
            this.rdButtonAdiPostaBarkodsuz = new System.Windows.Forms.RadioButton();
            this.gBoxMuzekkere = new System.Windows.Forms.GroupBox();
            this.rdButtonMuzekkereBarkodsuz = new System.Windows.Forms.RadioButton();
            this.rdButtonMuzekkereTaahhudlu = new System.Windows.Forms.RadioButton();
            this.gBoxResmi = new System.Windows.Forms.GroupBox();
            this.rdButtonResmiAPS = new System.Windows.Forms.RadioButton();
            this.rdButtonResmiBarkodsuz = new System.Windows.Forms.RadioButton();
            this.rdButtonResmiTebligat = new System.Windows.Forms.RadioButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dateTakipTarihi = new DevExpress.XtraEditors.DateEdit();
            this.btnTarihDegistir = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkPostaListesi = new DevExpress.XtraEditors.CheckEdit();
            this.c_pnlButtons.SuspendLayout();
            this.gBoxSecenekler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPTT)).BeginInit();
            this.gBoxAdiPosta.SuspendLayout();
            this.gBoxMuzekkere.SuspendLayout();
            this.gBoxResmi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTakipTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTakipTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPostaListesi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(601, 327);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(137, 25);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Tamam";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // c_pnlButtons
            // 
            this.c_pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c_pnlButtons.AutoScroll = true;
            this.c_pnlButtons.Controls.Add(this.gBoxSecenekler);
            this.c_pnlButtons.Location = new System.Drawing.Point(6, 80);
            this.c_pnlButtons.Name = "c_pnlButtons";
            this.c_pnlButtons.Size = new System.Drawing.Size(732, 241);
            this.c_pnlButtons.TabIndex = 1;
            // 
            // gBoxSecenekler
            // 
            this.gBoxSecenekler.Controls.Add(this.pictureBoxPTT);
            this.gBoxSecenekler.Controls.Add(this.gBoxAdiPosta);
            this.gBoxSecenekler.Controls.Add(this.gBoxMuzekkere);
            this.gBoxSecenekler.Controls.Add(this.gBoxResmi);
            this.gBoxSecenekler.Location = new System.Drawing.Point(375, 3);
            this.gBoxSecenekler.Name = "gBoxSecenekler";
            this.gBoxSecenekler.Size = new System.Drawing.Size(350, 232);
            this.gBoxSecenekler.TabIndex = 0;
            this.gBoxSecenekler.TabStop = false;
            this.gBoxSecenekler.Text = "Barkod Seçenekleri";
            // 
            // pictureBoxPTT
            // 
            this.pictureBoxPTT.Location = new System.Drawing.Point(6, 20);
            this.pictureBoxPTT.Name = "pictureBoxPTT";
            this.pictureBoxPTT.Size = new System.Drawing.Size(338, 48);
            this.pictureBoxPTT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPTT.TabIndex = 6;
            this.pictureBoxPTT.TabStop = false;
            // 
            // gBoxAdiPosta
            // 
            this.gBoxAdiPosta.Controls.Add(this.rdButtonAdiPostaAPS);
            this.gBoxAdiPosta.Controls.Add(this.rdButtonAdiPostaBarkodsuz);
            this.gBoxAdiPosta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gBoxAdiPosta.Location = new System.Drawing.Point(3, 183);
            this.gBoxAdiPosta.Name = "gBoxAdiPosta";
            this.gBoxAdiPosta.Size = new System.Drawing.Size(344, 46);
            this.gBoxAdiPosta.TabIndex = 5;
            this.gBoxAdiPosta.TabStop = false;
            this.gBoxAdiPosta.Text = "Adi Posta";
            this.gBoxAdiPosta.Visible = false;
            // 
            // rdButtonAdiPostaAPS
            // 
            this.rdButtonAdiPostaAPS.AutoSize = true;
            this.rdButtonAdiPostaAPS.Location = new System.Drawing.Point(129, 18);
            this.rdButtonAdiPostaAPS.Name = "rdButtonAdiPostaAPS";
            this.rdButtonAdiPostaAPS.Size = new System.Drawing.Size(46, 17);
            this.rdButtonAdiPostaAPS.TabIndex = 3;
            this.rdButtonAdiPostaAPS.Text = "APS";
            this.rdButtonAdiPostaAPS.UseVisualStyleBackColor = true;
            this.rdButtonAdiPostaAPS.CheckedChanged += new System.EventHandler(this.rdButton_CheckedChanged);
            // 
            // rdButtonAdiPostaBarkodsuz
            // 
            this.rdButtonAdiPostaBarkodsuz.AutoSize = true;
            this.rdButtonAdiPostaBarkodsuz.Checked = true;
            this.rdButtonAdiPostaBarkodsuz.Location = new System.Drawing.Point(238, 18);
            this.rdButtonAdiPostaBarkodsuz.Name = "rdButtonAdiPostaBarkodsuz";
            this.rdButtonAdiPostaBarkodsuz.Size = new System.Drawing.Size(75, 17);
            this.rdButtonAdiPostaBarkodsuz.TabIndex = 4;
            this.rdButtonAdiPostaBarkodsuz.TabStop = true;
            this.rdButtonAdiPostaBarkodsuz.Text = "Barkodsuz";
            this.rdButtonAdiPostaBarkodsuz.UseVisualStyleBackColor = true;
            this.rdButtonAdiPostaBarkodsuz.CheckedChanged += new System.EventHandler(this.rdButton_CheckedChanged);
            // 
            // gBoxMuzekkere
            // 
            this.gBoxMuzekkere.Controls.Add(this.rdButtonMuzekkereBarkodsuz);
            this.gBoxMuzekkere.Controls.Add(this.rdButtonMuzekkereTaahhudlu);
            this.gBoxMuzekkere.Location = new System.Drawing.Point(3, 128);
            this.gBoxMuzekkere.Name = "gBoxMuzekkere";
            this.gBoxMuzekkere.Size = new System.Drawing.Size(341, 45);
            this.gBoxMuzekkere.TabIndex = 4;
            this.gBoxMuzekkere.TabStop = false;
            this.gBoxMuzekkere.Text = "Müzekkere";
            this.gBoxMuzekkere.Visible = false;
            // 
            // rdButtonMuzekkereBarkodsuz
            // 
            this.rdButtonMuzekkereBarkodsuz.AutoSize = true;
            this.rdButtonMuzekkereBarkodsuz.Location = new System.Drawing.Point(241, 19);
            this.rdButtonMuzekkereBarkodsuz.Name = "rdButtonMuzekkereBarkodsuz";
            this.rdButtonMuzekkereBarkodsuz.Size = new System.Drawing.Size(75, 17);
            this.rdButtonMuzekkereBarkodsuz.TabIndex = 5;
            this.rdButtonMuzekkereBarkodsuz.Text = "Barkodsuz";
            this.rdButtonMuzekkereBarkodsuz.UseVisualStyleBackColor = true;
            this.rdButtonMuzekkereBarkodsuz.CheckedChanged += new System.EventHandler(this.rdButton_CheckedChanged);
            // 
            // rdButtonMuzekkereTaahhudlu
            // 
            this.rdButtonMuzekkereTaahhudlu.AutoSize = true;
            this.rdButtonMuzekkereTaahhudlu.Checked = true;
            this.rdButtonMuzekkereTaahhudlu.Location = new System.Drawing.Point(20, 19);
            this.rdButtonMuzekkereTaahhudlu.Name = "rdButtonMuzekkereTaahhudlu";
            this.rdButtonMuzekkereTaahhudlu.Size = new System.Drawing.Size(73, 17);
            this.rdButtonMuzekkereTaahhudlu.TabIndex = 3;
            this.rdButtonMuzekkereTaahhudlu.TabStop = true;
            this.rdButtonMuzekkereTaahhudlu.Text = "Taahhütlü";
            this.rdButtonMuzekkereTaahhudlu.UseVisualStyleBackColor = true;
            this.rdButtonMuzekkereTaahhudlu.CheckedChanged += new System.EventHandler(this.rdButton_CheckedChanged);
            // 
            // gBoxResmi
            // 
            this.gBoxResmi.Controls.Add(this.rdButtonResmiAPS);
            this.gBoxResmi.Controls.Add(this.rdButtonResmiBarkodsuz);
            this.gBoxResmi.Controls.Add(this.rdButtonResmiTebligat);
            this.gBoxResmi.Location = new System.Drawing.Point(3, 74);
            this.gBoxResmi.Name = "gBoxResmi";
            this.gBoxResmi.Size = new System.Drawing.Size(341, 44);
            this.gBoxResmi.TabIndex = 3;
            this.gBoxResmi.TabStop = false;
            this.gBoxResmi.Text = "Resmi Tebligatlar";
            this.gBoxResmi.Visible = false;
            // 
            // rdButtonResmiAPS
            // 
            this.rdButtonResmiAPS.AutoSize = true;
            this.rdButtonResmiAPS.Location = new System.Drawing.Point(131, 19);
            this.rdButtonResmiAPS.Name = "rdButtonResmiAPS";
            this.rdButtonResmiAPS.Size = new System.Drawing.Size(87, 17);
            this.rdButtonResmiAPS.TabIndex = 1;
            this.rdButtonResmiAPS.Text = "APS Tebligat";
            this.rdButtonResmiAPS.UseVisualStyleBackColor = true;
            this.rdButtonResmiAPS.CheckedChanged += new System.EventHandler(this.rdButton_CheckedChanged);
            // 
            // rdButtonResmiBarkodsuz
            // 
            this.rdButtonResmiBarkodsuz.AutoSize = true;
            this.rdButtonResmiBarkodsuz.Location = new System.Drawing.Point(241, 19);
            this.rdButtonResmiBarkodsuz.Name = "rdButtonResmiBarkodsuz";
            this.rdButtonResmiBarkodsuz.Size = new System.Drawing.Size(75, 17);
            this.rdButtonResmiBarkodsuz.TabIndex = 2;
            this.rdButtonResmiBarkodsuz.Text = "Barkodsuz";
            this.rdButtonResmiBarkodsuz.UseVisualStyleBackColor = true;
            this.rdButtonResmiBarkodsuz.CheckedChanged += new System.EventHandler(this.rdButton_CheckedChanged);
            // 
            // rdButtonResmiTebligat
            // 
            this.rdButtonResmiTebligat.AutoSize = true;
            this.rdButtonResmiTebligat.Checked = true;
            this.rdButtonResmiTebligat.Location = new System.Drawing.Point(20, 19);
            this.rdButtonResmiTebligat.Name = "rdButtonResmiTebligat";
            this.rdButtonResmiTebligat.Size = new System.Drawing.Size(63, 17);
            this.rdButtonResmiTebligat.TabIndex = 0;
            this.rdButtonResmiTebligat.TabStop = true;
            this.rdButtonResmiTebligat.Text = "Tebligat";
            this.rdButtonResmiTebligat.UseVisualStyleBackColor = true;
            this.rdButtonResmiTebligat.CheckedChanged += new System.EventHandler(this.rdButton_CheckedChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(458, 327);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(137, 25);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Vazgeç";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkPostaListesi);
            this.groupControl1.Controls.Add(this.dateTakipTarihi);
            this.groupControl1.Controls.Add(this.btnTarihDegistir);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(6, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(732, 71);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Takip Tarihi Güncelle";
            // 
            // dateTakipTarihi
            // 
            this.dateTakipTarihi.EditValue = null;
            this.dateTakipTarihi.Location = new System.Drawing.Point(151, 37);
            this.dateTakipTarihi.Name = "dateTakipTarihi";
            this.dateTakipTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTakipTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateTakipTarihi.Size = new System.Drawing.Size(100, 20);
            this.dateTakipTarihi.TabIndex = 2;
            // 
            // btnTarihDegistir
            // 
            this.btnTarihDegistir.Location = new System.Drawing.Point(257, 35);
            this.btnTarihDegistir.Name = "btnTarihDegistir";
            this.btnTarihDegistir.Size = new System.Drawing.Size(75, 23);
            this.btnTarihDegistir.TabIndex = 1;
            this.btnTarihDegistir.Text = "Uygula";
            this.btnTarihDegistir.Click += new System.EventHandler(this.btnTarihDegistir_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(132, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Güncellenecek Takip Tarihi :";
            // 
            // chkPostaListesi
            // 
            this.chkPostaListesi.Location = new System.Drawing.Point(386, 37);
            this.chkPostaListesi.Name = "chkPostaListesi";
            this.chkPostaListesi.Properties.Caption = "Posta Listesi Yazdýrýlsýn";
            this.chkPostaListesi.Size = new System.Drawing.Size(167, 19);
            this.chkPostaListesi.TabIndex = 3;
            // 
            // frmIstek
            // 
            this.ClientSize = new System.Drawing.Size(743, 357);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.c_pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmIstek";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmIstek_Load);
            this.c_pnlButtons.ResumeLayout(false);
            this.gBoxSecenekler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPTT)).EndInit();
            this.gBoxAdiPosta.ResumeLayout(false);
            this.gBoxAdiPosta.PerformLayout();
            this.gBoxMuzekkere.ResumeLayout(false);
            this.gBoxMuzekkere.PerformLayout();
            this.gBoxResmi.ResumeLayout(false);
            this.gBoxResmi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTakipTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTakipTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPostaListesi.Properties)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion
        SimpleButton btnOk;
        private System.Windows.Forms.Panel c_pnlButtons;
        private SimpleButton simpleButton1;
        private System.Windows.Forms.GroupBox gBoxSecenekler;
        private System.Windows.Forms.PictureBox pictureBoxPTT;
        private System.Windows.Forms.GroupBox gBoxAdiPosta;
        private System.Windows.Forms.RadioButton rdButtonAdiPostaAPS;
        private System.Windows.Forms.RadioButton rdButtonAdiPostaBarkodsuz;
        private System.Windows.Forms.GroupBox gBoxMuzekkere;
        private System.Windows.Forms.RadioButton rdButtonMuzekkereBarkodsuz;
        private System.Windows.Forms.RadioButton rdButtonMuzekkereTaahhudlu;
        private System.Windows.Forms.GroupBox gBoxResmi;
        private System.Windows.Forms.RadioButton rdButtonResmiAPS;
        private System.Windows.Forms.RadioButton rdButtonResmiBarkodsuz;
        private System.Windows.Forms.RadioButton rdButtonResmiTebligat;
        private GroupControl groupControl1;
        private DateEdit dateTakipTarihi;
        private SimpleButton btnTarihDegistir;
        private LabelControl labelControl1;
        private CheckEdit chkPostaListesi;
    }
}