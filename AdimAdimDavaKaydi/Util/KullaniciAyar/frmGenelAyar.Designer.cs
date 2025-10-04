namespace  AdimAdimDavaKaydi.Util.KullaniciAyar
{
    partial class frmGenelAyar
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
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.lnkGenel = new DevExpress.XtraNavBar.NavBarItem();
            this.lnkIcra = new DevExpress.XtraNavBar.NavBarItem();
            this.lnkDava = new DevExpress.XtraNavBar.NavBarItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(943, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 622);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 622);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 597);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(960, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(810, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(885, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.groupControl1);
            this.c_pnlContainer.Controls.Add(this.navBarControl1);
            this.c_pnlContainer.Size = new System.Drawing.Size(960, 622);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.navBarControl1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.groupControl1, 0);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.lnkGenel,
            this.lnkIcra,
            this.lnkDava});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 178;
            this.navBarControl1.Size = new System.Drawing.Size(178, 597);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Kullanýcý Ayarlarý";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.lnkGenel),
            new DevExpress.XtraNavBar.NavBarItemLink(this.lnkIcra),
            new DevExpress.XtraNavBar.NavBarItemLink(this.lnkDava)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // lnkGenel
            // 
            this.lnkGenel.Caption = "Genel Ayarlar";
            this.lnkGenel.Name = "lnkGenel";
            this.lnkGenel.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.lnkGenel_LinkClicked);
            // 
            // lnkIcra
            // 
            this.lnkIcra.Caption = "Ýcra Ayarlarý";
            this.lnkIcra.Name = "lnkIcra";
            this.lnkIcra.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.lnkIcra_LinkClicked);
            // 
            // lnkDava
            // 
            this.lnkDava.Caption = "Dava Ayarlarý";
            this.lnkDava.Name = "lnkDava";
            this.lnkDava.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.lnkDava_LinkClicked);
            // 
            // groupControl1
            // 
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(178, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(782, 597);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "[Baslik]";
            // 
            // frmGenelAyar
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 622);
            this.Name = "frmGenelAyar";
            this.Text = "Kullanýcý Genel Ayarlarý";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmGenelAyar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem lnkGenel;
        private DevExpress.XtraNavBar.NavBarItem lnkIcra;
        private DevExpress.XtraNavBar.NavBarItem lnkDava;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        //private DevExpress.XtraBars.BarButtonItem btnKaydet;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem13;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem15;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem16;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem17;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem18;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem19;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
    }
}