namespace  AdimAdimDavaKaydi.Forms.Dava
{
    partial class rFrmDavaGenelNotlar
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
            this.ucDavaGenelNotlar1 = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaGenelNotlar();
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
            this.c_pnlContainer.Size = new System.Drawing.Size(473, 395);
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(490, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 449);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 449);
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
            this.clientPanel.Controls.Add(this.ucDavaGenelNotlar1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 0);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(473, 395);
            this.clientPanel.TabIndex = 2;
            // 
            // ucDavaGenelNotlar1
            // 
            this.ucDavaGenelNotlar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDavaGenelNotlar1.Location = new System.Drawing.Point(0, 0);


            this.ucDavaGenelNotlar1.MyType = AvukatProLib.Extras.ViewType.VGrid;
            this.ucDavaGenelNotlar1.Name = "ucDavaGenelNotlar1";
            this.ucDavaGenelNotlar1.Size = new System.Drawing.Size(473, 395);
            this.ucDavaGenelNotlar1.TabIndex = 0;
            // 
            // rFrmDavaGenelNotlar
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 449);
            this.Name = "rFrmDavaGenelNotlar";
            this.Text = "Dava Genel Notlar Giriþ Formu";
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
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaGenelNotlar ucDavaGenelNotlar1;
        //private DevExpress.XtraBars.BarButtonItem btnKaydet;
        //private DevExpress.XtraBars.BarButtonItem btnVazgec;
    }
}