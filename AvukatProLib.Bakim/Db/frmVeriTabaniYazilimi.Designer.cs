namespace  AvukatProLib.Bakim
{
    partial class frmVeriTabaniYazilimi
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
            this.lblYazilimBilgisi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblYazilimBilgisi
            // 
            this.lblYazilimBilgisi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblYazilimBilgisi.BackColor = System.Drawing.Color.Gainsboro;
            this.lblYazilimBilgisi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblYazilimBilgisi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblYazilimBilgisi.Location = new System.Drawing.Point(5, 41);
            this.lblYazilimBilgisi.Name = "lblYazilimBilgisi";
            this.lblYazilimBilgisi.Size = new System.Drawing.Size(561, 215);
            this.lblYazilimBilgisi.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(2, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(564, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Veri Tabaný Sunucu Bilgisi ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmVeriTabaniYazilimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 259);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblYazilimBilgisi);
            this.Name = "frmVeriTabaniYazilimi";
            this.Text = "Veri Tabani Yazilimi";
            this.Load += new System.EventHandler(this.frmVeriTabaniYazilimi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblYazilimBilgisi;
        private System.Windows.Forms.Label label2;

    }
}