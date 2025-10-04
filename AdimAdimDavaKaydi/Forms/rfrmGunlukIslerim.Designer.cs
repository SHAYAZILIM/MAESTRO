namespace AdimAdimDavaKaydi.Forms
{
    partial class rfrmGunlukIslerim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rfrmGunlukIslerim));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.ucIsler1 = new AdimAdimDavaKaydi.UserControls.ucIsler();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::AdimAdimDavaKaydi.Properties.Resources.avukatpro7_40x40;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Name = "ribbon";
            this.ribbon.Size = new System.Drawing.Size(442, 48);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 424);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(442, 25);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.ucIsler1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 48);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(442, 376);
            this.clientPanel.TabIndex = 2;
            // 
            // ucIsler1
            // 
            this.ucIsler1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIsler1.Location = new System.Drawing.Point(0, 0);
            this.ucIsler1.MyDataSource = null;
            this.ucIsler1.Name = "ucIsler1";
            this.ucIsler1.Size = new System.Drawing.Size(442, 376);
            this.ucIsler1.TabIndex = 3;
            // 
            // rfrmGunlukIslerim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 449);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "rfrmGunlukIslerim";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Günlük İşlerim";
            this.Load += new System.EventHandler(this.rfrmGunlukIslerim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private AdimAdimDavaKaydi.UserControls.ucIsler ucIsler1;
    }
}