namespace  AdimAdimDavaKaydi.Forms.Icra
{
    partial class frmGayriMenkulGirisi
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
            //this.btnKaydetCik = new DevExpress.XtraBars.BarButtonItem();
            //this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            //this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.ucGayriMenkul1 = new AdimAdimDavaKaydi.ucGayriMenkul();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            //this.ribbon.ApplicationButtonKeyTip = "";
            //this.ribbon.ApplicationIcon = null;
            //this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            //this.btnKaydetCik,
            //this.barButtonItem2});
            //this.ribbon.Location = new System.Drawing.Point(0, 0);
            //this.ribbon.MaxItemId = 2;
            //this.ribbon.Name = "ribbon";
            //this.ribbon.Size = new System.Drawing.Size(745, 48);
            //this.ribbon.StatusBar = this.ribbonStatusBar;
            //// 
            //// btnKaydetCik
            //// 
            //this.btnKaydetCik.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            //this.btnKaydetCik.Caption = "&Kaydet ve &Çýk";
            //this.btnKaydetCik.Id = 0;
            //this.btnKaydetCik.Name = "btnKaydetCik";
            //this.btnKaydetCik.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKaydetCik_ItemClick);
            //// 
            //// barButtonItem2
            //// 
            //this.barButtonItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            //this.barButtonItem2.Caption = "&Vazgeç";
            //this.barButtonItem2.Id = 1;
            //this.barButtonItem2.Name = "barButtonItem2";
            //this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            //// 
            //// ribbonStatusBar
            //// 
            //this.ribbonStatusBar.ItemLinks.Add(this.btnKaydetCik);
            //this.ribbonStatusBar.ItemLinks.Add(this.barButtonItem2);
            //this.ribbonStatusBar.Location = new System.Drawing.Point(0, 421);
            //this.ribbonStatusBar.Name = "ribbonStatusBar";
            //this.ribbonStatusBar.Ribbon = this.ribbon;
            //this.ribbonStatusBar.Size = new System.Drawing.Size(745, 25);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.ucGayriMenkul1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 48);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(745, 373);
            this.clientPanel.TabIndex = 2;
            // 
            // ucGayriMenkul1
            // 
            this.ucGayriMenkul1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGayriMenkul1.Location = new System.Drawing.Point(0, 0);
            this.ucGayriMenkul1.Name = "ucGayriMenkul1";
            this.ucGayriMenkul1.Size = new System.Drawing.Size(745, 373);
            this.ucGayriMenkul1.TabIndex = 11;
            // 
            // frmGayriMenkulGirisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 446);
            this.c_pnlContainer.Controls.Add(this.clientPanel);
            //this.c_pnlContainer.Controls.Add(this.ribbonStatusBar);
            //this.c_pnlContainer.Controls.Add(this.ribbon);
            this.Name = "frmGayriMenkulGirisi";
            //this.Ribbon = this.ribbon;
            //this.StatusBar = this.ribbonStatusBar;
            this.Text = "Yeni GayriMenkul Giriþi";
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        //private DevExpress.XtraBars.BarButtonItem btnKaydetCik;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private ucGayriMenkul ucGayriMenkul1;
    }
}