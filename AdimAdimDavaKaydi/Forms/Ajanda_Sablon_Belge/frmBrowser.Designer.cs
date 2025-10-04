namespace  AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge
{
    partial class frmBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrowser));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.browser1 = new AdimAdimDavaKaydi.GeneralClass.Browser();
            
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            
            
            
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mrqEnAlt
            // 
            
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.clientPanel);
            this.c_pnlContainer.Size = new System.Drawing.Size(671, 481);
            this.c_pnlContainer.Controls.SetChildIndex(this.clientPanel, 0);
 
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(688, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 535);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 535);
            // 
            // c_pnlAltButtons
            // 
 
 
            // 
            // c_btnIptal
            // 
 
            // 
            // c_btnTamam
            // 
 
            // 
            // prgEnAlt
            // 
            // 
            // c_btnYardim
            // 
 
 
 
 
 
 
 
 
 
 
 
 
 
            // 
            // c_btnCaption
            // 
 
 
 
 
 
 
 
 
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.ribbon.ApplicationButtonKeyTip = "";
            this.ribbon.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbon.ApplicationIcon")));
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Name = "ribbon";
            this.ribbon.Size = new System.Drawing.Size(705, 20);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.BottomPaneControlContainer = null;
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbon;
            this.applicationMenu1.RightPaneControlContainer = null;
            this.applicationMenu1.RightPaneWidth = 240;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 511);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(705, 24);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.browser1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 0);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(671, 481);
            this.clientPanel.TabIndex = 2;
            // 
            // browser1
            // 
            this.browser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser1.Location = new System.Drawing.Point(0, 0);
            this.browser1.Name = "browser1";
            this.browser1.Size = new System.Drawing.Size(671, 481);
            this.browser1.TabIndex = 0;
            // 
            // frmBrowser
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 535);
            this.Name = "frmBrowser";
            this.Text = "Web Tarayýcý";
            this.UstMenu = true;
 
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
 
 
 
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private AdimAdimDavaKaydi.GeneralClass.Browser browser1;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
    }
}