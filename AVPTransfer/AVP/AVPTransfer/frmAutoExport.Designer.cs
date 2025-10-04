namespace AVPTransfer
{
    partial class frmAutoExport
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
            this.bgWorkerCompare = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerTransfer = new System.ComponentModel.BackgroundWorker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // bgWorkerCompare
            // 
            this.bgWorkerCompare.WorkerReportsProgress = true;
            this.bgWorkerCompare.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerCompare_DoWork);
            this.bgWorkerCompare.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerCompare_ProgressChanged);
            this.bgWorkerCompare.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerCompare_RunWorkerCompleted);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(47, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Karşılaştırılıyor...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(47, 47);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(381, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 2;
            // 
            // frmAutoExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 108);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmAutoExport";
            this.Text = "Avukatpro Data Transfer Ekranı";
            this.Shown += new System.EventHandler(this.frmAutoExport_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgWorkerCompare;
        private System.ComponentModel.BackgroundWorker bgWorkerTransfer;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}