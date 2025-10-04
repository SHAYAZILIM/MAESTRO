namespace Avukatpro.UserImport
{
    partial class frmImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImport));
            this.opfUser = new System.Windows.Forms.OpenFileDialog();
            this.opfSube = new System.Windows.Forms.OpenFileDialog();
            this.txtUserFile = new System.Windows.Forms.TextBox();
            this.btnUserOpenFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubeFile = new System.Windows.Forms.TextBox();
            this.btnSubeOpenFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bckImport = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // opfUser
            // 
            this.opfUser.DefaultExt = "*.xls";
            this.opfUser.Filter = "Excel Dosyası|*.xls|2007-2010 Excel|*.xlsx";
            // 
            // opfSube
            // 
            this.opfSube.DefaultExt = "*.xls";
            this.opfSube.Filter = "Excel Dosyası|*.xls|2007-2010 Excel|*.xlsx";
            // 
            // txtUserFile
            // 
            this.txtUserFile.Location = new System.Drawing.Point(12, 28);
            this.txtUserFile.Name = "txtUserFile";
            this.txtUserFile.ReadOnly = true;
            this.txtUserFile.Size = new System.Drawing.Size(406, 20);
            this.txtUserFile.TabIndex = 0;
            // 
            // btnUserOpenFile
            // 
            this.btnUserOpenFile.Location = new System.Drawing.Point(424, 25);
            this.btnUserOpenFile.Name = "btnUserOpenFile";
            this.btnUserOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnUserOpenFile.TabIndex = 1;
            this.btnUserOpenFile.Text = "Excel Aç";
            this.btnUserOpenFile.UseVisualStyleBackColor = true;
            this.btnUserOpenFile.Click += new System.EventHandler(this.btnUserOpenFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kullanıcı Excel Dosyası";
            // 
            // txtSubeFile
            // 
            this.txtSubeFile.Location = new System.Drawing.Point(12, 70);
            this.txtSubeFile.Name = "txtSubeFile";
            this.txtSubeFile.ReadOnly = true;
            this.txtSubeFile.Size = new System.Drawing.Size(406, 20);
            this.txtSubeFile.TabIndex = 0;
            this.txtSubeFile.Visible = false;
            // 
            // btnSubeOpenFile
            // 
            this.btnSubeOpenFile.Location = new System.Drawing.Point(424, 67);
            this.btnSubeOpenFile.Name = "btnSubeOpenFile";
            this.btnSubeOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnSubeOpenFile.TabIndex = 1;
            this.btnSubeOpenFile.Text = "Excel Aç";
            this.btnSubeOpenFile.UseVisualStyleBackColor = true;
            this.btnSubeOpenFile.Visible = false;
            this.btnSubeOpenFile.Click += new System.EventHandler(this.btnSubeOpenFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Şube Excel Dosyası";
            this.label2.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(424, 110);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Başla";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.txtUserFile);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnUserOpenFile);
            this.panel1.Controls.Add(this.btnSubeOpenFile);
            this.panel1.Controls.Add(this.txtSubeFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 152);
            this.panel1.TabIndex = 4;
            // 
            // bckImport
            // 
            this.bckImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckImport_DoWork);
            this.bckImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckImport_RunWorkerCompleted);
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 152);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImport";
            this.Text = "Kullanıcı Ve Şube Aktarma";
            this.Load += new System.EventHandler(this.frmImport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog opfUser;
        private System.Windows.Forms.OpenFileDialog opfSube;
        private System.Windows.Forms.TextBox txtUserFile;
        private System.Windows.Forms.Button btnUserOpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubeFile;
        private System.Windows.Forms.Button btnSubeOpenFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker bckImport;
    }
}

