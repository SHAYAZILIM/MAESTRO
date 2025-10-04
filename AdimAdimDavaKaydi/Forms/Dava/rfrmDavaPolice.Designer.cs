namespace  AdimAdimDavaKaydi.Forms.Dava
{
    partial class rfrmDavaPolice
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
            //this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            //this.btnKaydet = new DevExpress.XtraBars.BarButtonItem();
            //this.btnVazgec = new DevExpress.XtraBars.BarButtonItem();
            //this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.ucDavaPolice1 = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaPolice();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            //this.ribbon.ApplicationButtonKeyTip = "";
            //this.ribbon.ApplicationIcon = global::AdimAdimDavaKaydi.Properties.Resources.avukatpro7_40x40;
            //this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            //this.btnKaydet,
            //this.btnVazgec});
            //this.ribbon.Location = new System.Drawing.Point(0, 0);
            //this.ribbon.MaxItemId = 2;
            //this.ribbon.Name = "ribbon";
            //this.ribbon.Size = new System.Drawing.Size(770, 48);
            //this.ribbon.StatusBar = this.ribbonStatusBar;
            //// 
            //// btnKaydet
            //// 
            //this.btnKaydet.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            //this.btnKaydet.Caption = "&Kaydet ve &Çýk";
            //this.btnKaydet.Id = 0;
            //this.btnKaydet.Name = "btnKaydet";
            //this.btnKaydet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKaydet_ItemClick);
            //// 
            //// btnVazgec
            //// 
            //this.btnVazgec.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            //this.btnVazgec.Caption = "&Vazgeç";
            //this.btnVazgec.Id = 1;
            //this.btnVazgec.Name = "btnVazgec";
            //this.btnVazgec.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVazgec_ItemClick);
            //// 
            //// ribbonStatusBar
            //// 
            //this.ribbonStatusBar.ItemLinks.Add(this.btnKaydet);
            //this.ribbonStatusBar.ItemLinks.Add(this.btnVazgec);
            //this.ribbonStatusBar.Location = new System.Drawing.Point(0, 497);
            //this.ribbonStatusBar.Name = "ribbonStatusBar";
            //this.ribbonStatusBar.Ribbon = this.ribbon;
            //this.ribbonStatusBar.Size = new System.Drawing.Size(770, 25);
            //// 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.ucDavaPolice1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 48);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(770, 449);
            this.clientPanel.TabIndex = 2;
            // 
            // ucDavaPolice1
            // 
            this.ucDavaPolice1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDavaPolice1.Location = new System.Drawing.Point(0, 0);


            this.ucDavaPolice1.MyType = AvukatProLib.Extras.ViewType.VGrid;
            this.ucDavaPolice1.Name = "ucDavaPolice1";
            this.ucDavaPolice1.Size = new System.Drawing.Size(770, 449);
            this.ucDavaPolice1.TabIndex = 0;
            // 
            // rfrmDavaPolice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 522);
            this.c_pnlContainer.Controls.Add(this.clientPanel);
            //this.c_pnlContainer.Controls.Add(this.ribbonStatusBar);
            //this.c_pnlContainer.Controls.Add(this.ribbon);
            this.Name = "rfrmDavaPolice";
            //this.Ribbon = this.ribbon;
            //this.StatusBar = this.ribbonStatusBar;
            this.Text = "Yeni Poliçe Kayýt Ekraný";
            this.Load += new System.EventHandler(this.rfrmDavaPolice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        //private DevExpress.XtraBars.BarButtonItem btnKaydet;
        //private DevExpress.XtraBars.BarButtonItem btnVazgec;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaPolice ucDavaPolice1;
    }
}