namespace  AdimAdimDavaKaydi.Forms
{
    partial class frmKiymetliEvrakKayit
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
            this.ucKiymetliEvrak1 = new AdimAdimDavaKaydi.ucKiymetliEvrak();
            this.ucKiymetliEvrakTaraf1 = new AdimAdimDavaKaydi.ucKiymetliEvrakTaraf();
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
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 633);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.splitContainerControl1);
            this.c_pnlContainer.Size = new System.Drawing.Size(922, 658);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.splitContainerControl1, 0);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.ucKiymetliEvrak1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.ucKiymetliEvrakTaraf1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(922, 633);
            this.splitContainerControl1.SplitterPosition = 387;
            this.splitContainerControl1.TabIndex = 9;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ucKiymetliEvrak1
            // 
            this.ucKiymetliEvrak1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKiymetliEvrak1.Gorunum = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.ucKiymetliEvrak1.Location = new System.Drawing.Point(0, 0);
            this.ucKiymetliEvrak1.MyDataSource = null;
            this.ucKiymetliEvrak1.MyExtendedDataSource = null;
            this.ucKiymetliEvrak1.Name = "ucKiymetliEvrak1";
            this.ucKiymetliEvrak1.OnlyOneRecord = false;
            this.ucKiymetliEvrak1.Size = new System.Drawing.Size(922, 387);
            this.ucKiymetliEvrak1.TabIndex = 0;
            // 
            // ucKiymetliEvrakTaraf1
            // 
            this.ucKiymetliEvrakTaraf1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKiymetliEvrakTaraf1.Location = new System.Drawing.Point(0, 0);
            this.ucKiymetliEvrakTaraf1.MyDataSource = null;
            this.ucKiymetliEvrakTaraf1.Name = "ucKiymetliEvrakTaraf1";
            this.ucKiymetliEvrakTaraf1.Size = new System.Drawing.Size(922, 240);
            this.ucKiymetliEvrakTaraf1.TabIndex = 0;
            // 
            // frmKiymetliEvrakKayit
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 658);
            this.Name = "frmKiymetliEvrakKayit";
            this.Text = "Kýymetli Evrak Kayýt";
            this.UstMenu = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKiymetliEvrakKayit_FormClosing);
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
        private ucKiymetliEvrak ucKiymetliEvrak1;
        private ucKiymetliEvrakTaraf ucKiymetliEvrakTaraf1;
    }
}