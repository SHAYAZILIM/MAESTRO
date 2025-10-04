namespace AvukatproUpdater.Common.Controls
{
    partial class ProgressControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pbarStatus = new System.Windows.Forms.ProgressBar();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblKb = new System.Windows.Forms.Label();
            this.lblRemainingTime = new System.Windows.Forms.Label();
            this.pnlDownload = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.progressDisk1 = new AvukatproUpdater.Common.Controls.ProgressDisk();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.pnlDownload.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.ErrorImage = null;
            this.pictureBox.Image = global::AvukatproUpdater.Common.Properties.Resources.tickIcon;
            this.pictureBox.Location = new System.Drawing.Point(11, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(28, 28);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // pbarStatus
            // 
            this.pbarStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbarStatus.Location = new System.Drawing.Point(0, 5);
            this.pbarStatus.Name = "pbarStatus";
            this.pbarStatus.Size = new System.Drawing.Size(299, 23);
            this.pbarStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbarStatus.TabIndex = 5;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.BackColor = System.Drawing.Color.Transparent;
            this.lblPercent.Location = new System.Drawing.Point(143, 37);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(21, 13);
            this.lblPercent.TabIndex = 7;
            this.lblPercent.Text = "%0";
            // 
            // lblKb
            // 
            this.lblKb.AutoSize = true;
            this.lblKb.BackColor = System.Drawing.Color.Transparent;
            this.lblKb.Location = new System.Drawing.Point(236, 37);
            this.lblKb.Name = "lblKb";
            this.lblKb.Size = new System.Drawing.Size(47, 13);
            this.lblKb.TabIndex = 6;
            this.lblKb.Text = "354kb/s";
            // 
            // lblRemainingTime
            // 
            this.lblRemainingTime.AutoSize = true;
            this.lblRemainingTime.Location = new System.Drawing.Point(5, 56);
            this.lblRemainingTime.Name = "lblRemainingTime";
            this.lblRemainingTime.Size = new System.Drawing.Size(60, 13);
            this.lblRemainingTime.TabIndex = 8;
            this.lblRemainingTime.Text = "Kalan süre:";
            // 
            // pnlDownload
            // 
            this.pnlDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDownload.Controls.Add(this.lblRemainingTime);
            this.pnlDownload.Controls.Add(this.lblKb);
            this.pnlDownload.Controls.Add(this.lblPercent);
            this.pnlDownload.Controls.Add(this.pbarStatus);
            this.pnlDownload.Location = new System.Drawing.Point(3, 38);
            this.pnlDownload.Name = "pnlDownload";
            this.pnlDownload.Size = new System.Drawing.Size(300, 75);
            this.pnlDownload.TabIndex = 6;
            this.pnlDownload.Visible = false;
            this.pnlDownload.VisibleChanged += new System.EventHandler(this.pnlDownload_VisibleChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label.Location = new System.Drawing.Point(48, 11);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(39, 15);
            this.label.TabIndex = 3;
            this.label.Text = "label";
            // 
            // progressDisk1
            // 
            this.progressDisk1.ActiveForeColor1 = System.Drawing.Color.DarkTurquoise;
            this.progressDisk1.ActiveForeColor2 = System.Drawing.Color.LightCyan;
            this.progressDisk1.BackGroundColor = System.Drawing.Color.Transparent;
            this.progressDisk1.BlockSize = AvukatproUpdater.Common.Controls.BlockSize.Medium;
            this.progressDisk1.Location = new System.Drawing.Point(11, 4);
            this.progressDisk1.Name = "progressDisk1";
            this.progressDisk1.Size = new System.Drawing.Size(28, 28);
            this.progressDisk1.SliceCount = 1;
            this.progressDisk1.SquareSize = 28;
            this.progressDisk1.TabIndex = 7;
            this.progressDisk1.Value = 5;
            // 
            // ProgressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.progressDisk1);
            this.Controls.Add(this.pnlDownload);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label);
            this.DoubleBuffered = true;
            this.Name = "ProgressControl";
            this.Size = new System.Drawing.Size(305, 35);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.pnlDownload.ResumeLayout(false);
            this.pnlDownload.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ProgressBar pbarStatus;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblKb;
        private System.Windows.Forms.Label lblRemainingTime;
        private System.Windows.Forms.Panel pnlDownload;
        private System.Windows.Forms.Label label;
        private ProgressDisk progressDisk1;
    }
}
