namespace AvukatproUpdater.Common.Parameters
{
    partial class frmParam
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
            this.txtAppBackupFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDbBackupFolder = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAppFolder = new System.Windows.Forms.TextBox();
            this.tabParams = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxIsClient = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLogFolder = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPageUpdate = new System.Windows.Forms.TabPage();
            this.groupBoxUpdateAddress = new System.Windows.Forms.GroupBox();
            this.txtUpdateServerUri = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBoxUpdateTime = new System.Windows.Forms.GroupBox();
            this.txtTimeSchedule = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbUpdateAutoAsk = new System.Windows.Forms.RadioButton();
            this.rbUpdatesAutoYes = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kaydetToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.farklıKaydetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaydetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.farklıKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxUpdateType = new System.Windows.Forms.GroupBox();
            this.rbUpdateOffline = new System.Windows.Forms.RadioButton();
            this.rbUpdateOnline = new System.Windows.Forms.RadioButton();
            this.tabParams.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tabPageUpdate.SuspendLayout();
            this.groupBoxUpdateAddress.SuspendLayout();
            this.groupBoxUpdateTime.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBoxUpdateType.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAppBackupFolder
            // 
            this.txtAppBackupFolder.Location = new System.Drawing.Point(169, 46);
            this.txtAppBackupFolder.Name = "txtAppBackupFolder";
            this.txtAppBackupFolder.Size = new System.Drawing.Size(418, 21);
            this.txtAppBackupFolder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Uygulama Backup Klasörü";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(593, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 23);
            this.button1.TabIndex = 2;
            this.button1.Tag = "2";
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(593, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 23);
            this.button2.TabIndex = 5;
            this.button2.Tag = "3";
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Veritabanı Backup Klasörü";
            // 
            // txtDbBackupFolder
            // 
            this.txtDbBackupFolder.Location = new System.Drawing.Point(169, 72);
            this.txtDbBackupFolder.Name = "txtDbBackupFolder";
            this.txtDbBackupFolder.Size = new System.Drawing.Size(418, 21);
            this.txtDbBackupFolder.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(593, 97);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(29, 23);
            this.button4.TabIndex = 8;
            this.button4.Tag = "4";
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "İndirilenler Klasörü";
            // 
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.Location = new System.Drawing.Point(169, 97);
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.Size = new System.Drawing.Size(418, 21);
            this.txtDownloadFolder.TabIndex = 6;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(593, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(29, 23);
            this.button5.TabIndex = 14;
            this.button5.Tag = "1";
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Uygulama Klasörü";
            // 
            // txtAppFolder
            // 
            this.txtAppFolder.Location = new System.Drawing.Point(169, 20);
            this.txtAppFolder.Name = "txtAppFolder";
            this.txtAppFolder.Size = new System.Drawing.Size(418, 21);
            this.txtAppFolder.TabIndex = 12;
            // 
            // tabParams
            // 
            this.tabParams.Controls.Add(this.tabPageGeneral);
            this.tabParams.Controls.Add(this.tabPageUpdate);
            this.tabParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabParams.Location = new System.Drawing.Point(0, 24);
            this.tabParams.Name = "tabParams";
            this.tabParams.SelectedIndex = 0;
            this.tabParams.Size = new System.Drawing.Size(640, 290);
            this.tabParams.TabIndex = 15;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.label3);
            this.tabPageGeneral.Controls.Add(this.cbxIsClient);
            this.tabPageGeneral.Controls.Add(this.button7);
            this.tabPageGeneral.Controls.Add(this.label6);
            this.tabPageGeneral.Controls.Add(this.txtLogFolder);
            this.tabPageGeneral.Controls.Add(this.button6);
            this.tabPageGeneral.Controls.Add(this.label5);
            this.tabPageGeneral.Controls.Add(this.button5);
            this.tabPageGeneral.Controls.Add(this.txtAppBackupFolder);
            this.tabPageGeneral.Controls.Add(this.label1);
            this.tabPageGeneral.Controls.Add(this.txtAppFolder);
            this.tabPageGeneral.Controls.Add(this.button1);
            this.tabPageGeneral.Controls.Add(this.txtDbBackupFolder);
            this.tabPageGeneral.Controls.Add(this.label2);
            this.tabPageGeneral.Controls.Add(this.button2);
            this.tabPageGeneral.Controls.Add(this.button4);
            this.tabPageGeneral.Controls.Add(this.txtDownloadFolder);
            this.tabPageGeneral.Controls.Add(this.label4);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(632, 264);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "Genel";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Kullanıcı bilgisayarı server mı?";
            // 
            // cbxIsClient
            // 
            this.cbxIsClient.AutoSize = true;
            this.cbxIsClient.Location = new System.Drawing.Point(169, 149);
            this.cbxIsClient.Name = "cbxIsClient";
            this.cbxIsClient.Size = new System.Drawing.Size(15, 14);
            this.cbxIsClient.TabIndex = 19;
            this.cbxIsClient.UseVisualStyleBackColor = true;
            this.cbxIsClient.CheckedChanged += new System.EventHandler(this.cbxIsClient_CheckedChanged);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(593, 123);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(29, 23);
            this.button7.TabIndex = 18;
            this.button7.Tag = "5";
            this.button7.Text = "...";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Log Dosya Klasörü";
            // 
            // txtLogFolder
            // 
            this.txtLogFolder.Location = new System.Drawing.Point(169, 123);
            this.txtLogFolder.Name = "txtLogFolder";
            this.txtLogFolder.Size = new System.Drawing.Size(418, 21);
            this.txtLogFolder.TabIndex = 16;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(512, 211);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(110, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "Varsayılanları Kullan";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            // 
            // tabPageUpdate
            // 
            this.tabPageUpdate.Controls.Add(this.groupBoxUpdateType);
            this.tabPageUpdate.Controls.Add(this.groupBoxUpdateAddress);
            this.tabPageUpdate.Controls.Add(this.groupBoxUpdateTime);
            this.tabPageUpdate.Controls.Add(this.groupBox1);
            this.tabPageUpdate.Location = new System.Drawing.Point(4, 22);
            this.tabPageUpdate.Name = "tabPageUpdate";
            this.tabPageUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUpdate.Size = new System.Drawing.Size(632, 264);
            this.tabPageUpdate.TabIndex = 1;
            this.tabPageUpdate.Text = "Güncelleme Ayarları";
            this.tabPageUpdate.UseVisualStyleBackColor = true;
            // 
            // groupBoxUpdateAddress
            // 
            this.groupBoxUpdateAddress.Controls.Add(this.txtUpdateServerUri);
            this.groupBoxUpdateAddress.Controls.Add(this.label8);
            this.groupBoxUpdateAddress.Location = new System.Drawing.Point(8, 14);
            this.groupBoxUpdateAddress.Name = "groupBoxUpdateAddress";
            this.groupBoxUpdateAddress.Size = new System.Drawing.Size(616, 54);
            this.groupBoxUpdateAddress.TabIndex = 16;
            this.groupBoxUpdateAddress.TabStop = false;
            this.groupBoxUpdateAddress.Text = "Güncelleme";
            // 
            // txtUpdateServerUri
            // 
            this.txtUpdateServerUri.Location = new System.Drawing.Point(166, 21);
            this.txtUpdateServerUri.Name = "txtUpdateServerUri";
            this.txtUpdateServerUri.Size = new System.Drawing.Size(433, 21);
            this.txtUpdateServerUri.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Güncelleme Sunucu Adresi:";
            // 
            // groupBoxUpdateTime
            // 
            this.groupBoxUpdateTime.Controls.Add(this.txtTimeSchedule);
            this.groupBoxUpdateTime.Controls.Add(this.label7);
            this.groupBoxUpdateTime.Location = new System.Drawing.Point(8, 155);
            this.groupBoxUpdateTime.Name = "groupBoxUpdateTime";
            this.groupBoxUpdateTime.Size = new System.Drawing.Size(306, 69);
            this.groupBoxUpdateTime.TabIndex = 2;
            this.groupBoxUpdateTime.TabStop = false;
            this.groupBoxUpdateTime.Text = "Güncelleme Kontrolü  (Server için)";
            // 
            // txtTimeSchedule
            // 
            this.txtTimeSchedule.Location = new System.Drawing.Point(177, 29);
            this.txtTimeSchedule.Mask = "00:00";
            this.txtTimeSchedule.Name = "txtTimeSchedule";
            this.txtTimeSchedule.Size = new System.Drawing.Size(36, 21);
            this.txtTimeSchedule.TabIndex = 1;
            this.txtTimeSchedule.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Hergün şu saatte";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbUpdateAutoAsk);
            this.groupBox1.Controls.Add(this.rbUpdatesAutoYes);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(8, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 64);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Güncelleme başlangıcı";
            // 
            // rbUpdateAutoAsk
            // 
            this.rbUpdateAutoAsk.AutoSize = true;
            this.rbUpdateAutoAsk.Location = new System.Drawing.Point(188, 29);
            this.rbUpdateAutoAsk.Name = "rbUpdateAutoAsk";
            this.rbUpdateAutoAsk.Size = new System.Drawing.Size(66, 17);
            this.rbUpdateAutoAsk.TabIndex = 1;
            this.rbUpdateAutoAsk.TabStop = true;
            this.rbUpdateAutoAsk.Text = "Sorulsun";
            this.rbUpdateAutoAsk.UseVisualStyleBackColor = true;
            // 
            // rbUpdatesAutoYes
            // 
            this.rbUpdatesAutoYes.AutoSize = true;
            this.rbUpdatesAutoYes.Location = new System.Drawing.Point(26, 29);
            this.rbUpdatesAutoYes.Name = "rbUpdatesAutoYes";
            this.rbUpdatesAutoYes.Size = new System.Drawing.Size(110, 17);
            this.rbUpdatesAutoYes.TabIndex = 0;
            this.rbUpdatesAutoYes.TabStop = true;
            this.rbUpdatesAutoYes.Text = "Ototmatik yapılsın";
            this.rbUpdatesAutoYes.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(640, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem1
            // 
            this.dosyaToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kaydetToolStripMenuItem2,
            this.farklıKaydetToolStripMenuItem1});
            this.dosyaToolStripMenuItem1.Name = "dosyaToolStripMenuItem1";
            this.dosyaToolStripMenuItem1.Size = new System.Drawing.Size(49, 20);
            this.dosyaToolStripMenuItem1.Text = "Dosya";
            // 
            // kaydetToolStripMenuItem2
            // 
            this.kaydetToolStripMenuItem2.Name = "kaydetToolStripMenuItem2";
            this.kaydetToolStripMenuItem2.Size = new System.Drawing.Size(147, 22);
            this.kaydetToolStripMenuItem2.Text = "Kaydet";
            this.kaydetToolStripMenuItem2.Click += new System.EventHandler(this.kaydetToolStripMenuItem1_Click);
            // 
            // farklıKaydetToolStripMenuItem1
            // 
            this.farklıKaydetToolStripMenuItem1.Name = "farklıKaydetToolStripMenuItem1";
            this.farklıKaydetToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.farklıKaydetToolStripMenuItem1.Text = "Farklı Kaydet";
            this.farklıKaydetToolStripMenuItem1.Click += new System.EventHandler(this.farklıKaydetToolStripMenuItem1_Click);
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // kaydetToolStripMenuItem
            // 
            this.kaydetToolStripMenuItem.Name = "kaydetToolStripMenuItem";
            this.kaydetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kaydetToolStripMenuItem.Text = "Aç";
            this.kaydetToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // kaydetToolStripMenuItem1
            // 
            this.kaydetToolStripMenuItem1.Name = "kaydetToolStripMenuItem1";
            this.kaydetToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.kaydetToolStripMenuItem1.Text = "Kaydet";
            this.kaydetToolStripMenuItem1.Click += new System.EventHandler(this.kaydetToolStripMenuItem1_Click);
            // 
            // farklıKaydetToolStripMenuItem
            // 
            this.farklıKaydetToolStripMenuItem.Name = "farklıKaydetToolStripMenuItem";
            this.farklıKaydetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.farklıKaydetToolStripMenuItem.Text = "Farklı Kaydet";
            // 
            // groupBoxUpdateType
            // 
            this.groupBoxUpdateType.Controls.Add(this.rbUpdateOffline);
            this.groupBoxUpdateType.Controls.Add(this.rbUpdateOnline);
            this.groupBoxUpdateType.Enabled = false;
            this.groupBoxUpdateType.Location = new System.Drawing.Point(318, 74);
            this.groupBoxUpdateType.Name = "groupBoxUpdateType";
            this.groupBoxUpdateType.Size = new System.Drawing.Size(306, 64);
            this.groupBoxUpdateType.TabIndex = 17;
            this.groupBoxUpdateType.TabStop = false;
            this.groupBoxUpdateType.Text = "Güncelleme türü";
            this.groupBoxUpdateType.Visible = false;
            // 
            // rbUpdateOffline
            // 
            this.rbUpdateOffline.AutoSize = true;
            this.rbUpdateOffline.Location = new System.Drawing.Point(188, 29);
            this.rbUpdateOffline.Name = "rbUpdateOffline";
            this.rbUpdateOffline.Size = new System.Drawing.Size(57, 17);
            this.rbUpdateOffline.TabIndex = 1;
            this.rbUpdateOffline.Text = "Offline";
            this.rbUpdateOffline.UseVisualStyleBackColor = true;
            // 
            // rbUpdateOnline
            // 
            this.rbUpdateOnline.AutoSize = true;
            this.rbUpdateOnline.Checked = true;
            this.rbUpdateOnline.Location = new System.Drawing.Point(26, 29);
            this.rbUpdateOnline.Name = "rbUpdateOnline";
            this.rbUpdateOnline.Size = new System.Drawing.Size(55, 17);
            this.rbUpdateOnline.TabIndex = 0;
            this.rbUpdateOnline.TabStop = true;
            this.rbUpdateOnline.Text = "Online";
            this.rbUpdateOnline.UseVisualStyleBackColor = true;
            // 
            // frmParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 314);
            this.Controls.Add(this.tabParams);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmParam";
            this.Text = "Parametreler";
            this.Load += new System.EventHandler(this.frmParam_Load);
            this.tabParams.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tabPageUpdate.ResumeLayout(false);
            this.groupBoxUpdateAddress.ResumeLayout(false);
            this.groupBoxUpdateAddress.PerformLayout();
            this.groupBoxUpdateTime.ResumeLayout(false);
            this.groupBoxUpdateTime.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxUpdateType.ResumeLayout(false);
            this.groupBoxUpdateType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAppBackupFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDbBackupFolder;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDownloadFolder;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAppFolder;
        private System.Windows.Forms.TabControl tabParams;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageUpdate;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kaydetToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem farklıKaydetToolStripMenuItem;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLogFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbxIsClient;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbUpdateAutoAsk;
        private System.Windows.Forms.RadioButton rbUpdatesAutoYes;
        private System.Windows.Forms.GroupBox groupBoxUpdateTime;
        private System.Windows.Forms.MaskedTextBox txtTimeSchedule;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem kaydetToolStripMenuItem2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUpdateServerUri;
        private System.Windows.Forms.GroupBox groupBoxUpdateAddress;
        private System.Windows.Forms.ToolStripMenuItem farklıKaydetToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBoxUpdateType;
        private System.Windows.Forms.RadioButton rbUpdateOffline;
        private System.Windows.Forms.RadioButton rbUpdateOnline;
    }
}