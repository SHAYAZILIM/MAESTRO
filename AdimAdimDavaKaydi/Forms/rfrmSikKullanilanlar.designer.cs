namespace  AdimAdimDavaKaydi.Forms
{
    partial class rfrmSikKullanilanlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rfrmSikKullanilanlar));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.ucSikKullanilanlar1 = new AdimAdimDavaKaydi.UserControls.ucSikKullanilanlar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::AdimAdimDavaKaydi.Properties.Resources.avukatpro7_40x40;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.Size = new System.Drawing.Size(324, 48);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.Caption = "Kapat";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barButtonItem1);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 458);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(324, 25);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.ucSikKullanilanlar1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 48);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(324, 410);
            this.clientPanel.TabIndex = 2;
            // 
            // ucSikKullanilanlar1
            // 
            this.ucSikKullanilanlar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSikKullanilanlar1.Location = new System.Drawing.Point(0, 0);
            this.ucSikKullanilanlar1.MyDataSource = null;
            this.ucSikKullanilanlar1.Name = "ucSikKullanilanlar1";
            this.ucSikKullanilanlar1.Size = new System.Drawing.Size(324, 410);
            this.ucSikKullanilanlar1.TabIndex = 2;
            // 
            // rfrmSikKullanilanlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 483);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "rfrmSikKullanilanlar";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Sık Kullandıklarım";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private AdimAdimDavaKaydi.UserControls.ucSikKullanilanlar ucSikKullanilanlar1;
    }
}