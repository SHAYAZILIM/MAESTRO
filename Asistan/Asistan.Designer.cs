
namespace  Asistan
{
    partial class Asistan
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
            this.btnClose = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlContentControls = new System.Windows.Forms.Panel();
            this.loginControl1 = new LoginControl();
            this.pnlContent.SuspendLayout();
            this.pnlContentControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(296, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 17);
            this.btnClose.TabIndex = 0;
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.Paint += new System.Windows.Forms.PaintEventHandler(this.btnClose_Paint);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Controls.Add(this.btnClose);
            this.pnlContent.Controls.Add(this.pnlContentControls);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(10);
            this.pnlContent.Size = new System.Drawing.Size(320, 200);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlContentControls
            // 
            this.pnlContentControls.AutoScroll = true;
            this.pnlContentControls.BackColor = System.Drawing.Color.Transparent;
            this.pnlContentControls.Controls.Add(this.loginControl1);
            this.pnlContentControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentControls.Location = new System.Drawing.Point(10, 10);
            this.pnlContentControls.Name = "pnlContentControls";
            this.pnlContentControls.Size = new System.Drawing.Size(300, 180);
            this.pnlContentControls.TabIndex = 0;
            // 
            // loginControl1
            // 
            this.loginControl1.BackColor = System.Drawing.Color.Transparent;
            this.loginControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginControl1.Location = new System.Drawing.Point(0, 0);
            this.loginControl1.Name = "loginControl1";
            this.loginControl1.Size = new System.Drawing.Size(300, 180);
            this.loginControl1.TabIndex = 0;
            this.loginControl1.Load += new System.EventHandler(this.loginControl1_Load);
            this.loginControl1.OnLogon += new System.EventHandler(this.loginControl1_OnLogon);
            // 
            // Asistan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Asistan.Properties.Resources.asistan_giris_gir_yok;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(320, 200);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Asistan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Asistan";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.Asistan_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContentControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel btnClose;
        private System.Windows.Forms.Panel pnlContentControls;
        private LoginControl loginControl1;
    }
}