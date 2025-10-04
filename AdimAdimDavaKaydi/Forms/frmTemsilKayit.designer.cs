namespace  AdimAdimDavaKaydi
{
    partial class frmTemsilKayit
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
            this.ucTemsilTaraf1 = new AdimAdimDavaKaydi.ucTemsilTaraf();
            this.ucTemsilAvukat2 = new AdimAdimDavaKaydi.ucTemsilAvukat();
            this.ucTemsilBilgileri1 = new AdimAdimDavaKaydi.ucTemsilBilgileri();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 492);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(830, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(680, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(755, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Appearance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.c_pnlContainer.Appearance.Options.UseBackColor = true;
            this.c_pnlContainer.Controls.Add(this.panelControl1);
            this.c_pnlContainer.Size = new System.Drawing.Size(830, 517);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.panelControl1, 0);
            // 
            // ucTemsilTaraf1
            // 
            this.ucTemsilTaraf1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucTemsilTaraf1.Location = new System.Drawing.Point(2, 2);
            this.ucTemsilTaraf1.MyDataSource = null;
            this.ucTemsilTaraf1.Name = "ucTemsilTaraf1";
            this.ucTemsilTaraf1.Size = new System.Drawing.Size(364, 271);
            this.ucTemsilTaraf1.TabIndex = 3;
            // 
            // ucTemsilAvukat2
            // 
            this.ucTemsilAvukat2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTemsilAvukat2.Location = new System.Drawing.Point(366, 2);
            this.ucTemsilAvukat2.Name = "ucTemsilAvukat2";
            this.ucTemsilAvukat2.Size = new System.Drawing.Size(458, 271);
            this.ucTemsilAvukat2.TabIndex = 2;
            // 
            // ucTemsilBilgileri1
            // 
            this.ucTemsilBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTemsilBilgileri1.Location = new System.Drawing.Point(2, 2);
            this.ucTemsilBilgileri1.MyDataSource = null;
            this.ucTemsilBilgileri1.MyDataSourceExtended = null;
            this.ucTemsilBilgileri1.MyDataSourceExtendedByDava = null;
            this.ucTemsilBilgileri1.MyDataSourceExtendedBySorusturma = null;
            this.ucTemsilBilgileri1.MyDataSourceExtendedBySozlesme = null;
            this.ucTemsilBilgileri1.Name = "ucTemsilBilgileri1";
            this.ucTemsilBilgileri1.Size = new System.Drawing.Size(826, 213);
            this.ucTemsilBilgileri1.TabIndex = 0;
            this.ucTemsilBilgileri1.MyDataSourceChanged += new System.EventHandler(this.ucTemsilBilgileri1_MyDataSourceChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ucTemsilBilgileri1);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(830, 492);
            this.panelControl1.TabIndex = 10;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.ucTemsilAvukat2);
            this.panelControl2.Controls.Add(this.ucTemsilTaraf1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 215);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(826, 275);
            this.panelControl2.TabIndex = 1;
            // 
            // frmTemsilKayit
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 517);
            this.MinimumSize = new System.Drawing.Size(0, 0);
            this.Name = "frmTemsilKayit";
            this.Text = "Temsil Yetkileri";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmTemsilKayit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucTemsilBilgileri ucTemsilBilgileri1;
        private ucTemsilAvukat ucTemsilAvukat2;
        private ucTemsilTaraf ucTemsilTaraf1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    }
}