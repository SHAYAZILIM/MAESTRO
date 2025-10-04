namespace AdimAdimDavaKaydi
{
    partial class frmBeklemePaneli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBeklemePaneli));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.BackColor2 = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.progressBarControl1);
            this.groupControl1.Controls.Add(this.lblBilgi);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.pictureBox1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(298, 124);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Lütfen Bekleyin...";
            // 
            // lblBilgi
            // 
            this.lblBilgi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBilgi.Location = new System.Drawing.Point(114, 57);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(177, 28);
            this.lblBilgi.TabIndex = 1;
            this.lblBilgi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(114, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "İşleminiz yapılıyor...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(114, 92);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.ShowTitle = true;
            this.progressBarControl1.Size = new System.Drawing.Size(177, 25);
            this.progressBarControl1.TabIndex = 2;
            // 
            // frmBeklemePaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(298, 124);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBeklemePaneli";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lütfen Bekleyin";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblBilgi;
        public DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
    }
}