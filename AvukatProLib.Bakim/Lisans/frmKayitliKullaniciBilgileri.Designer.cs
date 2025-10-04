using AvukatProLib.Util;

namespace  AvukatProLib.Bakim
{
    partial class frmKayitliKullaniciBilgileri
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
            this.dataNavigator1 = new DevExpress.XtraEditors.DataNavigator();
            this.cKayitliKullaniciBilgileriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowurunsahibikullanici = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowurunsahibifirma = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.cKayitliKullaniciBilgileriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataNavigator1.DataSource = this.cKayitliKullaniciBilgileriBindingSource;
            this.dataNavigator1.Location = new System.Drawing.Point(12, 67);
            this.dataNavigator1.Name = "dataNavigator1";
            this.dataNavigator1.Size = new System.Drawing.Size(611, 24);
            this.dataNavigator1.TabIndex = 0;
            this.dataNavigator1.Text = "dataNavigator1";
            // 
            // cKayitliKullaniciBilgileriBindingSource
            // 
            this.cKayitliKullaniciBilgileriBindingSource.DataSource = typeof(KayitliKullaniciBilgileri);
            // 
            // vGridControl1
            // 
            this.vGridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vGridControl1.DataSource = this.cKayitliKullaniciBilgileriBindingSource;
            this.vGridControl1.Location = new System.Drawing.Point(3, 12);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RecordWidth = 492;
            this.vGridControl1.RowHeaderWidth = 189;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowurunsahibikullanici,
            this.rowurunsahibifirma});
            this.vGridControl1.Size = new System.Drawing.Size(620, 49);
            this.vGridControl1.TabIndex = 1;
            // 
            // rowurunsahibikullanici
            // 
            this.rowurunsahibikullanici.Height = 20;
            this.rowurunsahibikullanici.Name = "rowurunsahibikullanici";
            this.rowurunsahibikullanici.Properties.Caption = "Ürün Sahibi Kullanici Bilgisi";
            this.rowurunsahibikullanici.Properties.FieldName = "urunsahibikullanici";
            // 
            // rowurunsahibifirma
            // 
            this.rowurunsahibifirma.Height = 22;
            this.rowurunsahibifirma.Name = "rowurunsahibifirma";
            this.rowurunsahibifirma.Properties.Caption = "Ürün Sahibi Firma Bilgisi ";
            this.rowurunsahibifirma.Properties.FieldName = "urunsahibifirma";
            // 
            // frmKayitliKullaniciBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 101);
            this.Controls.Add(this.vGridControl1);
            this.Controls.Add(this.dataNavigator1);
            this.Name = "frmKayitliKullaniciBilgileri";
            this.Text = "Kayitli Kullanici Bilgileri";
            this.Load += new System.EventHandler(this.frmKayitliKullaniciBilgileri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cKayitliKullaniciBilgileriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DataNavigator dataNavigator1;
        private System.Windows.Forms.BindingSource cKayitliKullaniciBilgileriBindingSource;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowurunsahibikullanici;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowurunsahibifirma;
    }
}