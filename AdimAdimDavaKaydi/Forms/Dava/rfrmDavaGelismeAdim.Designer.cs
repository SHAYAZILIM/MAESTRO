namespace  AdimAdimDavaKaydi.Forms.Dava
{
    partial class rfrmDavaGelismeAdim
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
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.ucDavaGelismeAdim1 = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaGelismeAdim();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 454);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(632, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(482, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(557, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.clientPanel);
            this.c_pnlContainer.Size = new System.Drawing.Size(632, 479);
            this.c_pnlContainer.Controls.SetChildIndex(this.clientPanel, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.ucDavaGelismeAdim1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 0);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(632, 479);
            this.clientPanel.TabIndex = 2;
            // 
            // ucDavaGelismeAdim1
            // 
            this.ucDavaGelismeAdim1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDavaGelismeAdim1.Location = new System.Drawing.Point(0, 0);
            this.ucDavaGelismeAdim1.MView = AvukatProLib.Extras.ViewType.VGrid;
            this.ucDavaGelismeAdim1.Name = "ucDavaGelismeAdim1";
            this.ucDavaGelismeAdim1.Size = new System.Drawing.Size(632, 479);
            this.ucDavaGelismeAdim1.TabIndex = 0;
            // 
            // rfrmDavaGelismeAdim
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 479);
            this.Name = "rfrmDavaGelismeAdim";
            this.Text = "Yeni Dava Gelisme Kayýt Formu";
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
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
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaGelismeAdim ucDavaGelismeAdim1;
    }
}