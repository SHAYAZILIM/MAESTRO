namespace  AdimAdimDavaKaydi
{
    partial class frmHatalar
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UyapWB = new System.Windows.Forms.WebBrowser();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.HatalarNB = new DevExpress.XtraNavBar.NavBarGroup();
            this.UyarilarNB = new DevExpress.XtraNavBar.NavBarGroup();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(750, 490);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(80, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Tamam";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Xml Dosya Ýçeriði";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(495, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Oluþan Hatalar";
            // 
            // UyapWB
            // 
            this.UyapWB.Location = new System.Drawing.Point(15, 28);
            this.UyapWB.MinimumSize = new System.Drawing.Size(20, 20);
            this.UyapWB.Name = "UyapWB";
            this.UyapWB.Size = new System.Drawing.Size(452, 450);
            this.UyapWB.TabIndex = 8;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.HatalarNB;
            this.navBarControl1.Appearance.Background.Options.UseTextOptions = true;
            this.navBarControl1.Appearance.Background.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBarControl1.Appearance.Item.Options.UseTextOptions = true;
            this.navBarControl1.Appearance.Item.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBarControl1.Appearance.ItemActive.Options.UseTextOptions = true;
            this.navBarControl1.Appearance.ItemActive.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.HatalarNB,
            this.UyarilarNB});
            this.navBarControl1.Location = new System.Drawing.Point(497, 28);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 259;
            this.navBarControl1.Size = new System.Drawing.Size(333, 450);
            this.navBarControl1.TabIndex = 9;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("The Asphalt World");
            // 
            // HatalarNB
            // 
            this.HatalarNB.Appearance.Options.UseTextOptions = true;
            this.HatalarNB.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.HatalarNB.AppearanceBackground.Options.UseTextOptions = true;
            this.HatalarNB.AppearanceBackground.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.HatalarNB.AppearanceHotTracked.Options.UseTextOptions = true;
            this.HatalarNB.AppearanceHotTracked.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.HatalarNB.AppearancePressed.Options.UseTextOptions = true;
            this.HatalarNB.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.HatalarNB.Caption = "Hatalar";
            this.HatalarNB.Expanded = true;
            this.HatalarNB.Name = "HatalarNB";
            // 
            // UyarilarNB
            // 
            this.UyarilarNB.Caption = "Uyarýlar";
            this.UyarilarNB.Name = "UyarilarNB";
            // 
            // frmHatalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 517);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.UyapWB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleButton1);
            this.Name = "frmHatalar";
            this.Text = "Sonuç";
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser UyapWB;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup HatalarNB;
        private DevExpress.XtraNavBar.NavBarGroup UyarilarNB;

    }
}