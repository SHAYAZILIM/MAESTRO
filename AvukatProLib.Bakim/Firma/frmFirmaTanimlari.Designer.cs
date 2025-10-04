namespace  AvukatProLib.Bakim
{
    partial class frmFirmaTanimlari
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowTABLO_KODU = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowFIRMA_KODU = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowFIRMA_ADI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTABLOLAR_OLUSTURULDU_MU = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowVARSAYILAN = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSUBE_KODU = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.dnFirmaBilgileri = new DevExpress.XtraEditors.DataNavigator();
            this.prFirmaTanýmlama = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.vGridControl1);
            this.groupControl1.Controls.Add(this.dnFirmaBilgileri);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(726, 186);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Firma Tanýmlarý ";
            // 
            // vGridControl1
            // 
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.Location = new System.Drawing.Point(2, 20);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RecordWidth = 238;
            this.vGridControl1.RowHeaderWidth = 272;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowTABLO_KODU,
            this.rowFIRMA_KODU,
            this.rowFIRMA_ADI,
            this.rowTABLOLAR_OLUSTURULDU_MU,
            this.rowVARSAYILAN,
            this.rowSUBE_KODU});
            this.vGridControl1.Size = new System.Drawing.Size(722, 140);
            this.vGridControl1.TabIndex = 0;
            // 
            // rowTABLO_KODU
            // 
            this.rowTABLO_KODU.Name = "rowTABLO_KODU";
            this.rowTABLO_KODU.Properties.Caption = "TABLO_KODU";
            this.rowTABLO_KODU.Properties.FieldName = "TABLO_KODU";
            // 
            // rowFIRMA_KODU
            // 
            this.rowFIRMA_KODU.Name = "rowFIRMA_KODU";
            this.rowFIRMA_KODU.Properties.Caption = "FIRMA_KODU";
            this.rowFIRMA_KODU.Properties.FieldName = "FIRMA_KODU";
            // 
            // rowFIRMA_ADI
            // 
            this.rowFIRMA_ADI.Name = "rowFIRMA_ADI";
            this.rowFIRMA_ADI.Properties.Caption = "FIRMA_ADI";
            this.rowFIRMA_ADI.Properties.FieldName = "FIRMA_ADI";
            // 
            // rowTABLOLAR_OLUSTURULDU_MU
            // 
            this.rowTABLOLAR_OLUSTURULDU_MU.Height = 16;
            this.rowTABLOLAR_OLUSTURULDU_MU.Name = "rowTABLOLAR_OLUSTURULDU_MU";
            this.rowTABLOLAR_OLUSTURULDU_MU.Properties.Caption = "TABLOLAR_OLUSTURULDU_MU";
            this.rowTABLOLAR_OLUSTURULDU_MU.Properties.FieldName = "TABLOLAR_OLUSTURULDU_MU";
            // 
            // rowVARSAYILAN
            // 
            this.rowVARSAYILAN.Name = "rowVARSAYILAN";
            this.rowVARSAYILAN.Properties.Caption = "VARSAYILAN";
            this.rowVARSAYILAN.Properties.FieldName = "VARSAYILAN";
            // 
            // rowSUBE_KODU
            // 
            this.rowSUBE_KODU.Name = "rowSUBE_KODU";
            this.rowSUBE_KODU.Properties.Caption = "SUBE_KODU";
            this.rowSUBE_KODU.Properties.FieldName = "SUBE_KODU";
            // 
            // dnFirmaBilgileri
            // 
            this.dnFirmaBilgileri.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dnFirmaBilgileri.Location = new System.Drawing.Point(2, 160);
            this.dnFirmaBilgileri.Name = "dnFirmaBilgileri";
            this.dnFirmaBilgileri.Size = new System.Drawing.Size(722, 24);
            this.dnFirmaBilgileri.TabIndex = 1;
            this.dnFirmaBilgileri.Text = "dataNavigator1";
            // 
            // frmFirmaTanimlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 186);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmFirmaTanimlari";
            this.Text = "Firma Tanimlari";
            this.Load += new System.EventHandler(this.frmFirmaTanimlari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DataNavigator dnFirmaBilgileri;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTABLO_KODU;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowFIRMA_KODU;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowFIRMA_ADI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTABLOLAR_OLUSTURULDU_MU;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowVARSAYILAN;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSUBE_KODU;
        private DevExpress.XtraEditors.Repository.PersistentRepository prFirmaTanýmlama;

    }
}