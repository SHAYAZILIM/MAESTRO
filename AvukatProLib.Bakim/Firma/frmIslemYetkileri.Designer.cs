namespace  AvukatProLib.Bakim
{
    partial class frmIslemYetkileri
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
            this.dtNIslemYetkileri = new DevExpress.XtraEditors.DataNavigator();
            this.grCIslemYetkileri = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.grCIslemYetkileri)).BeginInit();
            this.SuspendLayout();
            // 
            // dtNIslemYetkileri
            // 
            this.dtNIslemYetkileri.Location = new System.Drawing.Point(37, 397);
            this.dtNIslemYetkileri.Name = "dtNIslemYetkileri";
            this.dtNIslemYetkileri.Size = new System.Drawing.Size(406, 24);
            this.dtNIslemYetkileri.TabIndex = 3;
            this.dtNIslemYetkileri.Text = "dataNavigator1";
            // 
            // grCIslemYetkileri
            // 
            this.grCIslemYetkileri.Location = new System.Drawing.Point(37, 58);
            this.grCIslemYetkileri.Name = "grCIslemYetkileri";
            this.grCIslemYetkileri.Size = new System.Drawing.Size(407, 271);
            this.grCIslemYetkileri.TabIndex = 2;
            this.grCIslemYetkileri.Text = "Ýþlem Yetkileri ";
            // 
            // frmIslemYetkileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 479);
            this.Controls.Add(this.dtNIslemYetkileri);
            this.Controls.Add(this.grCIslemYetkileri);
            this.Name = "frmIslemYetkileri";
            this.Text = "Islem Yetkileri";
            ((System.ComponentModel.ISupportInitialize)(this.grCIslemYetkileri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DataNavigator dtNIslemYetkileri;
        private DevExpress.XtraEditors.GroupControl grCIslemYetkileri;
    }
}