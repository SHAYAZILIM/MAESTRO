namespace  AvukatProLib.DbBackup
{
    partial class frmRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRestore));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bgwZipAc = new System.ComponentModel.BackgroundWorker();
            this.bgwRestore = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 33);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(262, 14);
            this.progressBar1.TabIndex = 2;
            // 
            // bgwZipAc
            // 
            this.bgwZipAc.WorkerReportsProgress = true;
            this.bgwZipAc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwZipAc_DoWork);
            this.bgwZipAc.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwZipAc_RunWorkerCompleted);
            this.bgwZipAc.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwZipAc_ProgressChanged);
            // 
            // bgwRestore
            // 
            this.bgwRestore.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRestore_DoWork);
            this.bgwRestore.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRestore_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Veritabaný Hazýrlanýyor...";
            // 
            // frmRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 64);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRestore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avukatpro Veritabaný Yükleme";
            this.Load += new System.EventHandler(this.frmRestore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker bgwZipAc;
        private System.ComponentModel.BackgroundWorker bgwRestore;
        private System.Windows.Forms.Label label1;

    }
}