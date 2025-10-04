using AvukatProLib.Util;

namespace  AvukatProLib.Bakim
{
    partial class frmLisansSonucu
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
            this.grCLisansSunucusu = new DevExpress.XtraVerticalGrid.VGridControl();
            this.dtNLisansSunucusu = new DevExpress.XtraEditors.DataNavigator();
            this.lisansSunucusuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rowsunucuadresi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowzamanasimi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowiletisimportu = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.grCLisansSunucusu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lisansSunucusuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grCLisansSunucusu
            // 
            this.grCLisansSunucusu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grCLisansSunucusu.DataSource = this.lisansSunucusuBindingSource;
            this.grCLisansSunucusu.Location = new System.Drawing.Point(13, 13);
            this.grCLisansSunucusu.Name = "grCLisansSunucusu";
            this.grCLisansSunucusu.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowsunucuadresi,
            this.rowzamanasimi,
            this.rowiletisimportu});
            this.grCLisansSunucusu.Size = new System.Drawing.Size(400, 57);
            this.grCLisansSunucusu.TabIndex = 0;
            // 
            // dtNLisansSunucusu
            // 
            this.dtNLisansSunucusu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtNLisansSunucusu.DataSource = this.lisansSunucusuBindingSource;
            this.dtNLisansSunucusu.Location = new System.Drawing.Point(12, 76);
            this.dtNLisansSunucusu.Name = "dtNLisansSunucusu";
            this.dtNLisansSunucusu.Size = new System.Drawing.Size(401, 24);
            this.dtNLisansSunucusu.TabIndex = 1;
            this.dtNLisansSunucusu.Text = "dataNavigator1";
            // 
            // lisansSunucusuBindingSource
            // 
            this.lisansSunucusuBindingSource.DataSource = typeof(LisansSunucusu);
            // 
            // rowsunucuadresi
            // 
            this.rowsunucuadresi.Name = "rowsunucuadresi";
            this.rowsunucuadresi.Properties.Caption = "Sunucu Adresi";
            this.rowsunucuadresi.Properties.FieldName = "sunucuadresi";
            this.rowsunucuadresi.Properties.Value = "";
            // 
            // rowzamanasimi
            // 
            this.rowzamanasimi.Name = "rowzamanasimi";
            this.rowzamanasimi.Properties.Caption = "Zaman Aþýmý ";
            this.rowzamanasimi.Properties.FieldName = "zamanasimi";
            // 
            // rowiletisimportu
            // 
            this.rowiletisimportu.Name = "rowiletisimportu";
            this.rowiletisimportu.Properties.Caption = "Ýletiþim Portu ";
            this.rowiletisimportu.Properties.FieldName = "iletisimportu";
            // 
            // frmLisansSonucu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 109);
            this.Controls.Add(this.dtNLisansSunucusu);
            this.Controls.Add(this.grCLisansSunucusu);
            this.Name = "frmLisansSonucu";
            this.Text = "Lisans Sunucusu";
            ((System.ComponentModel.ISupportInitialize)(this.grCLisansSunucusu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lisansSunucusuBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl grCLisansSunucusu;
        private System.Windows.Forms.BindingSource lisansSunucusuBindingSource;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowsunucuadresi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowzamanasimi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowiletisimportu;
        private DevExpress.XtraEditors.DataNavigator dtNLisansSunucusu;
    }
}