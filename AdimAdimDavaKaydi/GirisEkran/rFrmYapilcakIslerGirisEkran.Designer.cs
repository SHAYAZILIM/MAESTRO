namespace  AdimAdimDavaKaydi.GirisEkran
{
    partial class rFrmYapilcakIslerGirisEkran
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
            this.components = new System.ComponentModel.Container();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucGorevGrid1 = new AdimAdimDavaKaydi.Is.UserControls.ucGorevGrid();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(839, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 551);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 551);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 526);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(856, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(706, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(781, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucGorevGrid1);
            this.c_pnlContainer.Size = new System.Drawing.Size(856, 551);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucGorevGrid1, 0);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel2});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel2.ID = new System.Guid("5d11f5de-d584-4046-8b85-c23a5e53d8c8");
            this.dockPanel2.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.Options.ShowCloseButton = false;
            this.dockPanel2.OriginalSize = new System.Drawing.Size(0, 0);
            this.dockPanel2.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel2.SavedIndex = 0;
            this.dockPanel2.Size = new System.Drawing.Size(200, 383);
            this.dockPanel2.Text = "dockPanel2";
            this.dockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(194, 355);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // ucGorevGrid1
            // 
            this.ucGorevGrid1.AllowInsert = false;
            this.ucGorevGrid1.AramaDockPanel = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            this.ucGorevGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGorevGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucGorevGrid1.MyDataSource = null;
            this.ucGorevGrid1.MyDataSourceView = null;
            this.ucGorevGrid1.Name = "ucGorevGrid1";
            this.ucGorevGrid1.SelectedRecord = null;
            this.ucGorevGrid1.SelectedRecordId = 0;
            this.ucGorevGrid1.ShowKayitEkranOnDoubleClick = false;
            this.ucGorevGrid1.Size = new System.Drawing.Size(856, 526);
            this.ucGorevGrid1.TabIndex = 2;
            this.ucGorevGrid1.Load += new System.EventHandler(this.ucGorevGrid1_Load);
            // 
            // rFrmYapilcakIslerGirisEkran
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 551);
            this.Name = "rFrmYapilcakIslerGirisEkran";
            this.Text = "Avukatpro Hukuk Ailesi Yapýlcak Iþler Giriþ Ekraný";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.rFrmYapilcakIslerGirisEkran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //private DevExpress.XtraBars.BarButtonItem btnKaydet;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem4;
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
        //private DevExpress.XtraBars.BarButtonItem barButtonItem20;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem21;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem22;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem23;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem24;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem25;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem26;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private AdimAdimDavaKaydi.Is.UserControls.ucGorevGrid ucGorevGrid1;
        //private AdimAdimDavaKaydi.ExtendTool.compRibbonExtender compRibbonExtender1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
    }
}
