namespace  AdimAdimDavaKaydi.Forms.Dava
{
    partial class rfrmTutuklanma
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
            this.ucTutuklanmaVeGozAlt1 = new AdimAdimDavaKaydi.DavaTakip.ucTutuklanmaVeGozAlt();
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
            this.c_pnlContainer.Size = new System.Drawing.Size(758, 545);
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(775, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 599);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 599);
            // 
            // c_btnYardim
            // 
 
 
 
 
 
 
 
 
 
 
 
 
 
            // 
            // c_btnCaption
            // 
 
 
 
 
 
 
 
 
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.ucTutuklanmaVeGozAlt1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 0);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(758, 545);
            this.clientPanel.TabIndex = 2;
            // 
            // ucTutuklanmaVeGozAlt1
            // 
            this.ucTutuklanmaVeGozAlt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTutuklanmaVeGozAlt1.Location = new System.Drawing.Point(0, 0);


            this.ucTutuklanmaVeGozAlt1.MyType = AvukatProLib.Extras.ViewType.VGrid;
            this.ucTutuklanmaVeGozAlt1.Name = "ucTutuklanmaVeGozAlt1";
            this.ucTutuklanmaVeGozAlt1.Size = new System.Drawing.Size(758, 545);
            this.ucTutuklanmaVeGozAlt1.TabIndex = 0;
            // 
            // rfrmTutuklanma
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 599);
            this.FormunBolumu = AdimAdimDavaKaydi.Util.BaseClasses.FormBolumu.Dava;
            this.FormunTipi = AdimAdimDavaKaydi.Util.BaseClasses.FormTipi.UfakKayitFormu;
            this.Name = "rfrmTutuklanma";
            this.Text = "Tutuklanma Kayýt Formu";
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
        private AdimAdimDavaKaydi.DavaTakip.ucTutuklanmaVeGozAlt ucTutuklanmaVeGozAlt1;
    }
}