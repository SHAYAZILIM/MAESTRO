namespace AdimAdimDavaKaydi.Forms
{
    partial class frmPttBarkodAraligiKayit
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
            this.txtBoxTaahhutluOnayKodu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTaahhudluOnay = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTaahhutluBarkod = new System.Windows.Forms.TabPage();
            this.btnTaahhutluBarkodIste = new System.Windows.Forms.Button();
            this.lblTahhutKalan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabTebligatBarkod = new System.Windows.Forms.TabPage();
            this.btnTebligatBarkodIste = new System.Windows.Forms.Button();
            this.lblTebligatKalan = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTebligatOnay = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxTebligatOnayKodu = new System.Windows.Forms.TextBox();
            this.tabTebligatApsBarkod = new System.Windows.Forms.TabPage();
            this.btnTebligatAPSBarkodIste = new System.Windows.Forms.Button();
            this.lblTebligatAPSKalan = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTebligatAPSOnay = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBoxTebligatAPSOnayKodu = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabTaahhutluBarkod.SuspendLayout();
            this.tabTebligatBarkod.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabTebligatApsBarkod.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Onay Kodu :";
            // 
            // txtBoxTaahhutluOnayKodu
            // 
            this.txtBoxTaahhutluOnayKodu.Location = new System.Drawing.Point(91, 24);
            this.txtBoxTaahhutluOnayKodu.Name = "txtBoxTaahhutluOnayKodu";
            this.txtBoxTaahhutluOnayKodu.Size = new System.Drawing.Size(256, 21);
            this.txtBoxTaahhutluOnayKodu.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTaahhudluOnay);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBoxTaahhutluOnayKodu);
            this.groupBox1.Location = new System.Drawing.Point(6, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 69);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Taahhütlü Barkod Aralığı Tanımlama";
            this.groupBox1.Visible = false;
            // 
            // btnTaahhudluOnay
            // 
            this.btnTaahhudluOnay.Location = new System.Drawing.Point(368, 24);
            this.btnTaahhudluOnay.Name = "btnTaahhudluOnay";
            this.btnTaahhudluOnay.Size = new System.Drawing.Size(75, 23);
            this.btnTaahhudluOnay.TabIndex = 2;
            this.btnTaahhudluOnay.Text = "Giriş";
            this.btnTaahhudluOnay.UseVisualStyleBackColor = true;
            this.btnTaahhudluOnay.Click += new System.EventHandler(this.btnTaahhudluOnay_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTaahhutluBarkod);
            this.tabControl1.Controls.Add(this.tabTebligatBarkod);
            this.tabControl1.Controls.Add(this.tabTebligatApsBarkod);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(501, 150);
            this.tabControl1.TabIndex = 8;
            // 
            // tabTaahhutluBarkod
            // 
            this.tabTaahhutluBarkod.Controls.Add(this.btnTaahhutluBarkodIste);
            this.tabTaahhutluBarkod.Controls.Add(this.lblTahhutKalan);
            this.tabTaahhutluBarkod.Controls.Add(this.label2);
            this.tabTaahhutluBarkod.Controls.Add(this.groupBox1);
            this.tabTaahhutluBarkod.Location = new System.Drawing.Point(4, 22);
            this.tabTaahhutluBarkod.Name = "tabTaahhutluBarkod";
            this.tabTaahhutluBarkod.Padding = new System.Windows.Forms.Padding(3);
            this.tabTaahhutluBarkod.Size = new System.Drawing.Size(493, 124);
            this.tabTaahhutluBarkod.TabIndex = 0;
            this.tabTaahhutluBarkod.Text = "Taahhütlü Barkod";
            this.tabTaahhutluBarkod.UseVisualStyleBackColor = true;
            // 
            // btnTaahhutluBarkodIste
            // 
            this.btnTaahhutluBarkodIste.Location = new System.Drawing.Point(228, 15);
            this.btnTaahhutluBarkodIste.Name = "btnTaahhutluBarkodIste";
            this.btnTaahhutluBarkodIste.Size = new System.Drawing.Size(75, 23);
            this.btnTaahhutluBarkodIste.TabIndex = 9;
            this.btnTaahhutluBarkodIste.Text = "Barkod İste";
            this.btnTaahhutluBarkodIste.UseVisualStyleBackColor = true;
            this.btnTaahhutluBarkodIste.Click += new System.EventHandler(this.btnTaahhutluBarkodIste_Click);
            // 
            // lblTahhutKalan
            // 
            this.lblTahhutKalan.AutoSize = true;
            this.lblTahhutKalan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTahhutKalan.Location = new System.Drawing.Point(145, 20);
            this.lblTahhutKalan.Name = "lblTahhutKalan";
            this.lblTahhutKalan.Size = new System.Drawing.Size(11, 13);
            this.lblTahhutKalan.TabIndex = 8;
            this.lblTahhutKalan.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(13, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kalan Barkod Sayısı :";
            // 
            // tabTebligatBarkod
            // 
            this.tabTebligatBarkod.Controls.Add(this.btnTebligatBarkodIste);
            this.tabTebligatBarkod.Controls.Add(this.lblTebligatKalan);
            this.tabTebligatBarkod.Controls.Add(this.label5);
            this.tabTebligatBarkod.Controls.Add(this.groupBox2);
            this.tabTebligatBarkod.Location = new System.Drawing.Point(4, 22);
            this.tabTebligatBarkod.Name = "tabTebligatBarkod";
            this.tabTebligatBarkod.Padding = new System.Windows.Forms.Padding(3);
            this.tabTebligatBarkod.Size = new System.Drawing.Size(493, 124);
            this.tabTebligatBarkod.TabIndex = 1;
            this.tabTebligatBarkod.Text = "Tebligat Barkod";
            this.tabTebligatBarkod.UseVisualStyleBackColor = true;
            // 
            // btnTebligatBarkodIste
            // 
            this.btnTebligatBarkodIste.Location = new System.Drawing.Point(228, 15);
            this.btnTebligatBarkodIste.Name = "btnTebligatBarkodIste";
            this.btnTebligatBarkodIste.Size = new System.Drawing.Size(75, 23);
            this.btnTebligatBarkodIste.TabIndex = 13;
            this.btnTebligatBarkodIste.Text = "Barkod İste";
            this.btnTebligatBarkodIste.UseVisualStyleBackColor = true;
            this.btnTebligatBarkodIste.Click += new System.EventHandler(this.btnTebligatBarkodIste_Click);
            // 
            // lblTebligatKalan
            // 
            this.lblTebligatKalan.AutoSize = true;
            this.lblTebligatKalan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTebligatKalan.Location = new System.Drawing.Point(145, 20);
            this.lblTebligatKalan.Name = "lblTebligatKalan";
            this.lblTebligatKalan.Size = new System.Drawing.Size(11, 13);
            this.lblTebligatKalan.TabIndex = 12;
            this.lblTebligatKalan.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(13, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Kalan Barkod Sayısı :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTebligatOnay);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtBoxTebligatOnayKodu);
            this.groupBox2.Location = new System.Drawing.Point(6, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 69);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tebligat Barkod Aralığı Tanımlama";
            this.groupBox2.Visible = false;
            // 
            // btnTebligatOnay
            // 
            this.btnTebligatOnay.Location = new System.Drawing.Point(368, 24);
            this.btnTebligatOnay.Name = "btnTebligatOnay";
            this.btnTebligatOnay.Size = new System.Drawing.Size(75, 23);
            this.btnTebligatOnay.TabIndex = 2;
            this.btnTebligatOnay.Text = "Giriş";
            this.btnTebligatOnay.UseVisualStyleBackColor = true;
            this.btnTebligatOnay.Click += new System.EventHandler(this.btnTebligatOnay_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Onay Kodu :";
            // 
            // txtBoxTebligatOnayKodu
            // 
            this.txtBoxTebligatOnayKodu.Location = new System.Drawing.Point(91, 24);
            this.txtBoxTebligatOnayKodu.Name = "txtBoxTebligatOnayKodu";
            this.txtBoxTebligatOnayKodu.Size = new System.Drawing.Size(256, 21);
            this.txtBoxTebligatOnayKodu.TabIndex = 1;
            // 
            // tabTebligatApsBarkod
            // 
            this.tabTebligatApsBarkod.Controls.Add(this.btnTebligatAPSBarkodIste);
            this.tabTebligatApsBarkod.Controls.Add(this.lblTebligatAPSKalan);
            this.tabTebligatApsBarkod.Controls.Add(this.label8);
            this.tabTebligatApsBarkod.Controls.Add(this.groupBox3);
            this.tabTebligatApsBarkod.Location = new System.Drawing.Point(4, 22);
            this.tabTebligatApsBarkod.Name = "tabTebligatApsBarkod";
            this.tabTebligatApsBarkod.Padding = new System.Windows.Forms.Padding(3);
            this.tabTebligatApsBarkod.Size = new System.Drawing.Size(493, 124);
            this.tabTebligatApsBarkod.TabIndex = 2;
            this.tabTebligatApsBarkod.Text = "Tebligat APS Barkod";
            this.tabTebligatApsBarkod.UseVisualStyleBackColor = true;
            // 
            // btnTebligatAPSBarkodIste
            // 
            this.btnTebligatAPSBarkodIste.Location = new System.Drawing.Point(228, 15);
            this.btnTebligatAPSBarkodIste.Name = "btnTebligatAPSBarkodIste";
            this.btnTebligatAPSBarkodIste.Size = new System.Drawing.Size(75, 23);
            this.btnTebligatAPSBarkodIste.TabIndex = 13;
            this.btnTebligatAPSBarkodIste.Text = "Barkod İste";
            this.btnTebligatAPSBarkodIste.UseVisualStyleBackColor = true;
            this.btnTebligatAPSBarkodIste.Click += new System.EventHandler(this.btnTebligatAPSBarkodIste_Click);
            // 
            // lblTebligatAPSKalan
            // 
            this.lblTebligatAPSKalan.AutoSize = true;
            this.lblTebligatAPSKalan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTebligatAPSKalan.Location = new System.Drawing.Point(145, 20);
            this.lblTebligatAPSKalan.Name = "lblTebligatAPSKalan";
            this.lblTebligatAPSKalan.Size = new System.Drawing.Size(11, 13);
            this.lblTebligatAPSKalan.TabIndex = 12;
            this.lblTebligatAPSKalan.Text = ".";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(13, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Kalan Barkod Sayısı :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTebligatAPSOnay);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtBoxTebligatAPSOnayKodu);
            this.groupBox3.Location = new System.Drawing.Point(6, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(464, 69);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tebligat APS Barkod Aralığı Tanımlama";
            this.groupBox3.Visible = false;
            // 
            // btnTebligatAPSOnay
            // 
            this.btnTebligatAPSOnay.Location = new System.Drawing.Point(368, 24);
            this.btnTebligatAPSOnay.Name = "btnTebligatAPSOnay";
            this.btnTebligatAPSOnay.Size = new System.Drawing.Size(75, 23);
            this.btnTebligatAPSOnay.TabIndex = 2;
            this.btnTebligatAPSOnay.Text = "Giriş";
            this.btnTebligatAPSOnay.UseVisualStyleBackColor = true;
            this.btnTebligatAPSOnay.Click += new System.EventHandler(this.btnTebligatAPSOnay_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Onay Kodu :";
            // 
            // txtBoxTebligatAPSOnayKodu
            // 
            this.txtBoxTebligatAPSOnayKodu.Location = new System.Drawing.Point(91, 24);
            this.txtBoxTebligatAPSOnayKodu.Name = "txtBoxTebligatAPSOnayKodu";
            this.txtBoxTebligatAPSOnayKodu.Size = new System.Drawing.Size(256, 21);
            this.txtBoxTebligatAPSOnayKodu.TabIndex = 1;
            // 
            // frmPttBarkodAraligiKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 150);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmPttBarkodAraligiKayit";
            this.Text = "Ptt Barkod Aralıgı Kayıt";
            this.Load += new System.EventHandler(this.frmPttBarkodAraligiKayit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabTaahhutluBarkod.ResumeLayout(false);
            this.tabTaahhutluBarkod.PerformLayout();
            this.tabTebligatBarkod.ResumeLayout(false);
            this.tabTebligatBarkod.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabTebligatApsBarkod.ResumeLayout(false);
            this.tabTebligatApsBarkod.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxTaahhutluOnayKodu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTaahhudluOnay;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTaahhutluBarkod;
        private System.Windows.Forms.Label lblTahhutKalan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabTebligatBarkod;
        private System.Windows.Forms.Button btnTaahhutluBarkodIste;
        private System.Windows.Forms.Button btnTebligatBarkodIste;
        private System.Windows.Forms.Label lblTebligatKalan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTebligatOnay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxTebligatOnayKodu;
        private System.Windows.Forms.TabPage tabTebligatApsBarkod;
        private System.Windows.Forms.Button btnTebligatAPSBarkodIste;
        private System.Windows.Forms.Label lblTebligatAPSKalan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTebligatAPSOnay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxTebligatAPSOnayKodu;
    }
}