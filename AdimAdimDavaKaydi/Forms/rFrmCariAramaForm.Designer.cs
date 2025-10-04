namespace  AdimAdimDavaKaydi.Forms
{
    partial class rFrmCariAramaForm
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
            this.ucCariArama1 = new AdimAdimDavaKaydi.UserControls.ucCariArama();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.ucCariAramaKriterler1 = new AdimAdimDavaKaydi.UserControls.ucCariAramaKriterler();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 602);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(975, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(825, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(900, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucCariArama1);
            this.c_pnlContainer.Controls.Add(this.panelControl2);
            this.c_pnlContainer.Size = new System.Drawing.Size(975, 627);
            this.c_pnlContainer.Controls.SetChildIndex(this.panelControl2, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucCariArama1, 0);
            // 
            // ucCariArama1
            // 
            this.ucCariArama1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCariArama1.Location = new System.Drawing.Point(0, 211);
            this.ucCariArama1.MyDataSource = null;
            this.ucCariArama1.Name = "ucCariArama1";
            this.ucCariArama1.SeciliCariler = null;
            this.ucCariArama1.Size = new System.Drawing.Size(975, 391);
            this.ucCariArama1.TabIndex = 2;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.ucCariAramaKriterler1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(975, 211);
            this.panelControl2.TabIndex = 9;
            // 
            // ucCariAramaKriterler1
            // 
            this.ucCariAramaKriterler1.ArananCarilerim = null;
            this.ucCariAramaKriterler1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucCariAramaKriterler1.Location = new System.Drawing.Point(2, 2);
            this.ucCariAramaKriterler1.Name = "ucCariAramaKriterler1";
            this.ucCariAramaKriterler1.Size = new System.Drawing.Size(971, 207);
            this.ucCariAramaKriterler1.TabIndex = 0;
            // 
            // rFrmCariAramaForm
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 627);
            this.Name = "rFrmCariAramaForm";
            this.Text = "Avukatpro Hukuk Ailesi Þahýs Arama Ekraný";
            this.UstMenu = true;
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private AdimAdimDavaKaydi.UserControls.ucCariArama ucCariArama1;
        //private AdimAdimDavaKaydi.ExtendTool.compRibbonExtender compRibbonExtender1;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem2;
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
        //private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private AdimAdimDavaKaydi.UserControls.ucCariAramaKriterler ucCariAramaKriterler1;
    }
}