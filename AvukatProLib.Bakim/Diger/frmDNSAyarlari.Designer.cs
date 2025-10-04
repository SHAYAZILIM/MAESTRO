using AvukatProLib.Util;

namespace  AvukatProLib.Bakim
{
    partial class frmDNSAyarlari
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
            this.components = new System.ComponentModel.Container();
            this.dtNDNSAyarlari = new DevExpress.XtraEditors.DataNavigator();
            this.dNSBilgileriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grCDNSAyarlari = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowhukukailesidnsadi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowmevzuat_karardnsadi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.dNSBilgileriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCDNSAyarlari)).BeginInit();
            this.SuspendLayout();
            // 
            // dtNDNSAyarlari
            // 
            this.dtNDNSAyarlari.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtNDNSAyarlari.DataSource = this.dNSBilgileriBindingSource;
            this.dtNDNSAyarlari.Location = new System.Drawing.Point(1, 75);
            this.dtNDNSAyarlari.Name = "dtNDNSAyarlari";
            this.dtNDNSAyarlari.Size = new System.Drawing.Size(287, 27);
            this.dtNDNSAyarlari.TabIndex = 1;
            this.dtNDNSAyarlari.Text = "dataNavigator1";
            // 
            // dNSBilgileriBindingSource
            // 
            this.dNSBilgileriBindingSource.DataSource = typeof(DNSBilgileri);
            // 
            // grCDNSAyarlari
            // 
            this.grCDNSAyarlari.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grCDNSAyarlari.DataSource = this.dNSBilgileriBindingSource;
            this.grCDNSAyarlari.Location = new System.Drawing.Point(1, 1);
            this.grCDNSAyarlari.Name = "grCDNSAyarlari";
            this.grCDNSAyarlari.RecordWidth = 181;
            this.grCDNSAyarlari.RowHeaderWidth = 145;
            this.grCDNSAyarlari.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowhukukailesidnsadi,
            this.rowmevzuat_karardnsadi});
            this.grCDNSAyarlari.Size = new System.Drawing.Size(287, 68);
            this.grCDNSAyarlari.TabIndex = 2;
            // 
            // rowhukukailesidnsadi
            // 
            this.rowhukukailesidnsadi.Height = 28;
            this.rowhukukailesidnsadi.Name = "rowhukukailesidnsadi";
            this.rowhukukailesidnsadi.Properties.Caption = "Hukuk Ailesi DNS Adi :";
            this.rowhukukailesidnsadi.Properties.FieldName = "hukukailesidnsadi";
            // 
            // rowmevzuat_karardnsadi
            // 
            this.rowmevzuat_karardnsadi.Height = 31;
            this.rowmevzuat_karardnsadi.Name = "rowmevzuat_karardnsadi";
            this.rowmevzuat_karardnsadi.Properties.Caption = "Mevzuat_Karar DNS Adi :";
            this.rowmevzuat_karardnsadi.Properties.FieldName = "mevzuat_karardnsadi";
            // 
            // frmDNSAyarlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 114);
            this.Controls.Add(this.grCDNSAyarlari);
            this.Controls.Add(this.dtNDNSAyarlari);
            this.Name = "frmDNSAyarlari";
            this.Text = "DNS Ayarlari";
            ((System.ComponentModel.ISupportInitialize)(this.dNSBilgileriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCDNSAyarlari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DataNavigator dtNDNSAyarlari;
        private DevExpress.XtraVerticalGrid.VGridControl grCDNSAyarlari;
        private System.Windows.Forms.BindingSource dNSBilgileriBindingSource;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowhukukailesidnsadi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowmevzuat_karardnsadi;
    }
}