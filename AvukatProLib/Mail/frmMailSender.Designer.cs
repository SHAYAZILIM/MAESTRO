namespace AvukatProLib.Mail
{
    partial class frmMailSender
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMailSender));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.GonderBTN = new DevExpress.XtraEditors.SimpleButton();
            this.IptalBTN = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.KimeTB = new DevExpress.XtraEditors.TextEdit();
            this.CCTB = new DevExpress.XtraEditors.TextEdit();
            this.BCCTB = new DevExpress.XtraEditors.TextEdit();
            this.KonuTB = new DevExpress.XtraEditors.TextEdit();
            this.MesajRTB = new System.Windows.Forms.RichTextBox();
            this.EkleBTN = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.DurumLBL = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EklentilerLB = new DevExpress.XtraEditors.ListBoxControl();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.KimeTB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CCTB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BCCTB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KonuTB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EklentilerLB)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(106, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Kime:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(114, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "CC:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(108, 78);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "BCC:";
            // 
            // GonderBTN
            // 
            this.GonderBTN.Image = ((System.Drawing.Image)(resources.GetObject("GonderBTN.Image")));
            this.GonderBTN.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.GonderBTN.Location = new System.Drawing.Point(3, 3);
            this.GonderBTN.Name = "GonderBTN";
            this.GonderBTN.Size = new System.Drawing.Size(79, 67);
            this.GonderBTN.TabIndex = 5;
            this.GonderBTN.Text = "Gönder";
            this.GonderBTN.Click += new System.EventHandler(this.GonderBTN_Click);
            // 
            // IptalBTN
            // 
            this.IptalBTN.Location = new System.Drawing.Point(3, 72);
            this.IptalBTN.Name = "IptalBTN";
            this.IptalBTN.Size = new System.Drawing.Size(79, 24);
            this.IptalBTN.TabIndex = 6;
            this.IptalBTN.Text = "İptal Et";
            this.IptalBTN.Click += new System.EventHandler(this.IptalBTN_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl6.Location = new System.Drawing.Point(0, 0);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.labelControl6.Size = new System.Drawing.Size(85, 27);
            this.labelControl6.TabIndex = 7;
            this.labelControl6.Text = "Konu:";
            // 
            // KimeTB
            // 
            this.KimeTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KimeTB.Location = new System.Drawing.Point(137, 33);
            this.KimeTB.Name = "KimeTB";
            this.KimeTB.Size = new System.Drawing.Size(780, 20);
            this.KimeTB.TabIndex = 0;
            // 
            // CCTB
            // 
            this.CCTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CCTB.Location = new System.Drawing.Point(137, 54);
            this.CCTB.Name = "CCTB";
            this.CCTB.Size = new System.Drawing.Size(780, 20);
            this.CCTB.TabIndex = 1;
            // 
            // BCCTB
            // 
            this.BCCTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BCCTB.Location = new System.Drawing.Point(137, 75);
            this.BCCTB.Name = "BCCTB";
            this.BCCTB.Size = new System.Drawing.Size(780, 20);
            this.BCCTB.TabIndex = 2;
            // 
            // KonuTB
            // 
            this.KonuTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KonuTB.Location = new System.Drawing.Point(84, 3);
            this.KonuTB.Name = "KonuTB";
            this.KonuTB.Size = new System.Drawing.Size(833, 20);
            this.KonuTB.TabIndex = 3;
            // 
            // MesajRTB
            // 
            this.MesajRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MesajRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MesajRTB.Location = new System.Drawing.Point(2, 2);
            this.MesajRTB.Name = "MesajRTB";
            this.MesajRTB.Size = new System.Drawing.Size(916, 387);
            this.MesajRTB.TabIndex = 4;
            this.MesajRTB.Text = "";
            // 
            // EkleBTN
            // 
            this.EkleBTN.Image = ((System.Drawing.Image)(resources.GetObject("EkleBTN.Image")));
            this.EkleBTN.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.EkleBTN.Location = new System.Drawing.Point(42, 3);
            this.EkleBTN.Name = "EkleBTN";
            this.EkleBTN.Size = new System.Drawing.Size(37, 32);
            this.EkleBTN.TabIndex = 9;
            this.EkleBTN.Click += new System.EventHandler(this.EkleBTN_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new System.Drawing.Point(4, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(37, 32);
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(499, 10);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(31, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Durum";
            // 
            // DurumLBL
            // 
            this.DurumLBL.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DurumLBL.Location = new System.Drawing.Point(77, 452);
            this.DurumLBL.Name = "DurumLBL";
            this.DurumLBL.Size = new System.Drawing.Size(0, 13);
            this.DurumLBL.TabIndex = 12;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl7.Location = new System.Drawing.Point(89, 7);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(281, 13);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "Mail alanlarına yalnızca birer mail adresi girilebilir.";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.panel2);
            this.panelControl1.Controls.Add(this.KimeTB);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.CCTB);
            this.panelControl1.Controls.Add(this.BCCTB);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(920, 99);
            this.panelControl1.TabIndex = 16;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.EklentilerLB);
            this.panelControl2.Controls.Add(this.panel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 99);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(920, 121);
            this.panelControl2.TabIndex = 17;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.KonuTB);
            this.panelControl3.Controls.Add(this.labelControl6);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 220);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(920, 27);
            this.panelControl3.TabIndex = 18;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.panelControl4.Controls.Add(this.MesajRTB);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 247);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(920, 391);
            this.panelControl4.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.EkleBTN);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(83, 121);
            this.panel1.TabIndex = 16;
            // 
            // EklentilerLB
            // 
            this.EklentilerLB.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.EklentilerLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EklentilerLB.HotTrackItems = true;
            this.EklentilerLB.Location = new System.Drawing.Point(83, 0);
            this.EklentilerLB.Name = "EklentilerLB";
            this.EklentilerLB.Size = new System.Drawing.Size(837, 121);
            this.EklentilerLB.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.GonderBTN);
            this.panel2.Controls.Add(this.IptalBTN);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(85, 99);
            this.panel2.TabIndex = 17;
            // 
            // frmMailSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 638);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.DurumLBL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmMailSender";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avukatpro Mail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMailSender_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.KimeTB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CCTB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BCCTB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KonuTB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EklentilerLB)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton GonderBTN;
        private DevExpress.XtraEditors.SimpleButton IptalBTN;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit KimeTB;
        private DevExpress.XtraEditors.TextEdit CCTB;
        private DevExpress.XtraEditors.TextEdit BCCTB;
        private DevExpress.XtraEditors.TextEdit KonuTB;
        private System.Windows.Forms.RichTextBox MesajRTB;
        private DevExpress.XtraEditors.SimpleButton EkleBTN;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl DurumLBL;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.ListBoxControl EklentilerLB;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
    }
}