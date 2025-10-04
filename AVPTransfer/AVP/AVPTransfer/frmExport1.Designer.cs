namespace AVPTransfer
{
    partial class frmExport1
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
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLogXml = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnShowLog = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveText = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveWord = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveCsv = new DevExpress.XtraEditors.SimpleButton();
            this.bgWorkerTransfer = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(0, 34);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(978, 441);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLogXml);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.btnShowLog);
            this.panel1.Controls.Add(this.btnSaveText);
            this.panel1.Controls.Add(this.btnSaveWord);
            this.panel1.Controls.Add(this.btnSaveCsv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 34);
            this.panel1.TabIndex = 1;
            // 
            // lblLogXml
            // 
            this.lblLogXml.Location = new System.Drawing.Point(573, 10);
            this.lblLogXml.Name = "lblLogXml";
            this.lblLogXml.Size = new System.Drawing.Size(0, 13);
            this.lblLogXml.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(480, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Log Dosya Yolu = ";
            // 
            // btnShowLog
            // 
            this.btnShowLog.Location = new System.Drawing.Point(363, 5);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(111, 23);
            this.btnShowLog.TabIndex = 0;
            this.btnShowLog.Text = "Log\'u Göster";
            this.btnShowLog.Click += new System.EventHandler(this.btnShowLog_Click);
            // 
            // btnSaveText
            // 
            this.btnSaveText.Location = new System.Drawing.Point(246, 5);
            this.btnSaveText.Name = "btnSaveText";
            this.btnSaveText.Size = new System.Drawing.Size(111, 23);
            this.btnSaveText.TabIndex = 0;
            this.btnSaveText.Text = "Text Kaydet";
            this.btnSaveText.Click += new System.EventHandler(this.btnSaveText_Click);
            // 
            // btnSaveWord
            // 
            this.btnSaveWord.Location = new System.Drawing.Point(12, 5);
            this.btnSaveWord.Name = "btnSaveWord";
            this.btnSaveWord.Size = new System.Drawing.Size(111, 23);
            this.btnSaveWord.TabIndex = 0;
            this.btnSaveWord.Text = "Word Kaydet";
            this.btnSaveWord.Click += new System.EventHandler(this.btnSaveWord_Click);
            // 
            // btnSaveCsv
            // 
            this.btnSaveCsv.Location = new System.Drawing.Point(129, 5);
            this.btnSaveCsv.Name = "btnSaveCsv";
            this.btnSaveCsv.Size = new System.Drawing.Size(111, 23);
            this.btnSaveCsv.TabIndex = 0;
            this.btnSaveCsv.Text = "Csv Kaydet";
            this.btnSaveCsv.Click += new System.EventHandler(this.btnSaveCsv_Click);
            // 
            // bgWorkerTransfer
            // 
            this.bgWorkerTransfer.WorkerReportsProgress = true;
            this.bgWorkerTransfer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerTransfer_DoWork);
            this.bgWorkerTransfer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerTransfer_ProgressChanged);
            this.bgWorkerTransfer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerTransfer_RunWorkerCompleted);
            // 
            // frmExport1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 475);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.panel1);
            this.Name = "frmExport1";
            this.Text = "AVP - Data Transfer Formu";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnSaveText;
        private DevExpress.XtraEditors.SimpleButton btnSaveCsv;
        private DevExpress.XtraEditors.SimpleButton btnShowLog;
        private DevExpress.XtraEditors.LabelControl lblLogXml;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSaveWord;
        public System.Windows.Forms.RichTextBox rtbLog;
        private System.ComponentModel.BackgroundWorker bgWorkerTransfer;
    }
}