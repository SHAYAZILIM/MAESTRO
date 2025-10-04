namespace  Asistan
{
    partial class AsistanTray
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
                nIcon.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsistanTray));
            this.cntMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.acToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yapilacakIslerimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cntMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cntMenu
            // 
            this.cntMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acToolStripMenuItem,
            this.yapilacakIslerimToolStripMenuItem});
            this.cntMenu.Name = "cntMenu";
            resources.ApplyResources(this.cntMenu, "cntMenu");
            // 
            // acToolStripMenuItem
            // 
            this.acToolStripMenuItem.Image = global::Asistan.Properties.Resources.Open;
            this.acToolStripMenuItem.Name = "acToolStripMenuItem";
            resources.ApplyResources(this.acToolStripMenuItem, "acToolStripMenuItem");
            this.acToolStripMenuItem.Click += new System.EventHandler(this.acToolStripMenuItem_Click);
            // 
            // yapilacakIslerimToolStripMenuItem
            // 
            this.yapilacakIslerimToolStripMenuItem.Image = global::Asistan.Properties.Resources.Works;
            this.yapilacakIslerimToolStripMenuItem.Name = "yapilacakIslerimToolStripMenuItem";
            resources.ApplyResources(this.yapilacakIslerimToolStripMenuItem, "yapilacakIslerimToolStripMenuItem");
            this.yapilacakIslerimToolStripMenuItem.Click += new System.EventHandler(this.yapilacakIslerimToolStripMenuItem_Click);
            // 
            // nIcon
            // 
            this.nIcon.ContextMenuStrip = this.cntMenu;
            resources.ApplyResources(this.nIcon, "nIcon");
            this.nIcon.DoubleClick += new System.EventHandler(this.nIcon_DoubleClick);
            // 
            // AsistanTray
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Asistan.Properties.Resources.emd;
            this.Name = "AsistanTray";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.AsistanTray_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.AsistanTray_Layout);
            this.cntMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cntMenu;
        private System.Windows.Forms.ToolStripMenuItem acToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon nIcon;
        private System.Windows.Forms.ToolStripMenuItem yapilacakIslerimToolStripMenuItem;

    }
}