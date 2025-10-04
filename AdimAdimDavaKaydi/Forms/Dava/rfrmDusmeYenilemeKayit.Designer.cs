namespace  AdimAdimDavaKaydi.Forms.Dava
{
    partial class rfrmDusmeYenilemeKayit
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
            this.ucDavaDusmeYenileme1 = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaDusmeYenileme();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.clientPanel);
            this.c_pnlContainer.Size = new System.Drawing.Size(598, 425);
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(615, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 479);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 479);
            // 
            // c_btnYardim
            // 
 
 
 
 
 
 
 
 
 
 
 
 
 
            // 
            // c_btnCaption
            // 
 
 
 
 
 
 
 
 
            // 
            // ribbon
            // 
            //this.ribbon.ApplicationButtonKeyTip = "";
            //this.ribbon.ApplicationIcon = null;
            //this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            //this.btnKaydet,
            //this.btnVazgec});
            //this.ribbon.Location = new System.Drawing.Point(0, 0);
            //this.ribbon.MaxItemId = 2;
            //this.ribbon.Name = "ribbon";
            //this.ribbon.Size = new System.Drawing.Size(632, 20);
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
            //this.ribbonStatusBar.Location = new System.Drawing.Point(0, 455);
            //this.ribbonStatusBar.Name = "ribbonStatusBar";
            //this.ribbonStatusBar.Ribbon = this.ribbon;
            //this.ribbonStatusBar.Size = new System.Drawing.Size(632, 24);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.ucDavaDusmeYenileme1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 0);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(598, 425);
            this.clientPanel.TabIndex = 2;
            // 
            // ucDavaDusmeYenileme1
            // 
            this.ucDavaDusmeYenileme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDavaDusmeYenileme1.Location = new System.Drawing.Point(0, 0);


            this.ucDavaDusmeYenileme1.MyType = AvukatProLib.Extras.ViewType.VGrid;
            this.ucDavaDusmeYenileme1.Name = "ucDavaDusmeYenileme1";
            this.ucDavaDusmeYenileme1.Size = new System.Drawing.Size(598, 425);
            this.ucDavaDusmeYenileme1.TabIndex = 0;
            // 
            // rfrmDusmeYenilemeKayit
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 479);
            this.FormunBolumu = AdimAdimDavaKaydi.Util.BaseClasses.FormBolumu.Dava;
            this.FormunTipi = AdimAdimDavaKaydi.Util.BaseClasses.FormTipi.UfakKayitFormu;
            this.Name = "rfrmDusmeYenilemeKayit";
            this.Text = "Yeni Düþme Yenileme Kayýt Formu";
            this.UstMenu = true;
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        //private DevExpress.XtraBars.BarButtonItem btnKaydet;
        //private DevExpress.XtraBars.BarButtonItem btnVazgec;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaDusmeYenileme ucDavaDusmeYenileme1;
    }
}