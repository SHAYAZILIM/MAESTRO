namespace AvukatProLib.LisansYonetimi
{
    partial class frmLicenseWarning
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
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnActivate = new DevExpress.XtraEditors.SimpleButton();
            this.btnAskLater = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Appearance.Options.UseFont = true;
            this.lblMessage.Appearance.Options.UseForeColor = true;
            this.lblMessage.Appearance.Options.UseTextOptions = true;
            this.lblMessage.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblMessage.Location = new System.Drawing.Point(79, 26);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(400, 13);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "labelControl1";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(465, 78);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Çıkış";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnActivate
            // 
            this.btnActivate.Location = new System.Drawing.Point(92, 78);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(75, 23);
            this.btnActivate.TabIndex = 2;
            this.btnActivate.Text = "Aktive Et";
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // btnAskLater
            // 
            this.btnAskLater.Location = new System.Drawing.Point(237, 78);
            this.btnAskLater.Name = "btnAskLater";
            this.btnAskLater.Size = new System.Drawing.Size(126, 23);
            this.btnAskLater.TabIndex = 3;
            this.btnAskLater.Text = "Daha Sonra Hatırlat";
            this.btnAskLater.Click += new System.EventHandler(this.btnAskLater_Click);
            // 
            // frmLicenseWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 111);
            this.Controls.Add(this.btnAskLater);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLicenseWarning";
            this.Text = "Avukatpro Lisanslama";
            this.Load += new System.EventHandler(this.frmLicenseWarning_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblMessage;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnActivate;
        private DevExpress.XtraEditors.SimpleButton btnAskLater;
    }
}