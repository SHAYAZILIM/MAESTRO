using AdimAdimDavaKaydi.UserControls;
namespace  AdimAdimDavaKaydi.Forms
{
    partial class frmIlamMahkemesiTarafli
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucIlamMahkemesi1 = new AdimAdimDavaKaydi.ucIlamMahkemesi();
            this.ucIlamTarafBilgileri1 = new AdimAdimDavaKaydi.UserControls.ucIlamTarafBilgileri();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 518);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(729, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(579, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(654, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.splitContainerControl1);
            this.c_pnlContainer.Size = new System.Drawing.Size(729, 543);
            this.c_pnlContainer.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.ucIlamMahkemesi1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.ucIlamTarafBilgileri1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(729, 515);
            this.splitContainerControl1.SplitterPosition = 267;
            this.splitContainerControl1.TabIndex = 10;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ucIlamMahkemesi1
            // 
            this.ucIlamMahkemesi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIlamMahkemesi1.Location = new System.Drawing.Point(0, 0);
            this.ucIlamMahkemesi1.MyDataSource = null;
            this.ucIlamMahkemesi1.Name = "ucIlamMahkemesi1";
            this.ucIlamMahkemesi1.Size = new System.Drawing.Size(729, 267);
            this.ucIlamMahkemesi1.TabIndex = 2;
            // 
            // ucIlamTarafBilgileri1
            // 
            this.ucIlamTarafBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIlamTarafBilgileri1.MyDaTaSource = null;
            this.ucIlamTarafBilgileri1.Location = new System.Drawing.Point(0, 0);
            this.ucIlamTarafBilgileri1.Name = "ucIlamTarafBilgileri1";
            this.ucIlamTarafBilgileri1.Size = new System.Drawing.Size(729, 242);
            this.ucIlamTarafBilgileri1.TabIndex = 2;
            // 
            // frmIlamMahkemesiTarafli
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 543);
            this.Name = "frmIlamMahkemesiTarafli";
            this.Text = "frmIlamMahkemesiTarafli";
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private ucIlamMahkemesi ucIlamMahkemesi1;
        private ucIlamTarafBilgileri ucIlamTarafBilgileri1 ;
    }
}