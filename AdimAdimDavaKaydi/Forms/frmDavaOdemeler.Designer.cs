namespace AdimAdimDavaKaydi.Forms
{
    partial class frmDavaOdemeler
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
            this.grdControlDavaOdeme = new DevExpress.XtraGrid.GridControl();
            this.gvDavaOdeme = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colODEYEN_CARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_MIKTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_YERI = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdControlDavaOdeme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDavaOdeme)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 366);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(615, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(465, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(540, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.grdControlDavaOdeme);
            this.c_pnlContainer.Size = new System.Drawing.Size(615, 391);
            this.c_pnlContainer.Controls.SetChildIndex(this.grdControlDavaOdeme, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // grdControlDavaOdeme
            // 
            this.grdControlDavaOdeme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdControlDavaOdeme.Location = new System.Drawing.Point(0, 0);
            this.grdControlDavaOdeme.MainView = this.gvDavaOdeme;
            this.grdControlDavaOdeme.Name = "grdControlDavaOdeme";
            this.grdControlDavaOdeme.Size = new System.Drawing.Size(615, 391);
            this.grdControlDavaOdeme.TabIndex = 10;
            this.grdControlDavaOdeme.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDavaOdeme});
            // 
            // gvDavaOdeme
            // 
            this.gvDavaOdeme.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colODEYEN_CARI,
            this.colODEME_TARIHI,
            this.colODEME_MIKTAR,
            this.colODEME_TIP,
            this.colODEME_YERI});
            this.gvDavaOdeme.GridControl = this.grdControlDavaOdeme;
            this.gvDavaOdeme.Name = "gvDavaOdeme";
            // 
            // colODEYEN_CARI
            // 
            this.colODEYEN_CARI.Caption = "Ödeyen";
            this.colODEYEN_CARI.FieldName = "ODEYEN_CARI";
            this.colODEYEN_CARI.Name = "colODEYEN_CARI";
            this.colODEYEN_CARI.Visible = true;
            this.colODEYEN_CARI.VisibleIndex = 0;
            // 
            // colODEME_TARIHI
            // 
            this.colODEME_TARIHI.Caption = "Ödeme Tarihi";
            this.colODEME_TARIHI.FieldName = "ODEME_TARIHI";
            this.colODEME_TARIHI.Name = "colODEME_TARIHI";
            this.colODEME_TARIHI.Visible = true;
            this.colODEME_TARIHI.VisibleIndex = 1;
            // 
            // colODEME_MIKTAR
            // 
            this.colODEME_MIKTAR.Caption = "Ödeme Miktarı";
            this.colODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            this.colODEME_MIKTAR.Name = "colODEME_MIKTAR";
            this.colODEME_MIKTAR.Visible = true;
            this.colODEME_MIKTAR.VisibleIndex = 2;
            // 
            // colODEME_TIP
            // 
            this.colODEME_TIP.Caption = "Ödeme Tipi";
            this.colODEME_TIP.FieldName = "ODEME_TIP";
            this.colODEME_TIP.Name = "colODEME_TIP";
            this.colODEME_TIP.Visible = true;
            this.colODEME_TIP.VisibleIndex = 3;
            // 
            // colODEME_YERI
            // 
            this.colODEME_YERI.Caption = "Ödeme Yeri";
            this.colODEME_YERI.FieldName = "ODEME_YERI";
            this.colODEME_YERI.Name = "colODEME_YERI";
            this.colODEME_YERI.Visible = true;
            this.colODEME_YERI.VisibleIndex = 4;
            // 
            // frmDavaOdemeler
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 391);
            this.Name = "frmDavaOdemeler";
            this.Text = "Dava Ödeme Listesi";
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdControlDavaOdeme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDavaOdeme)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraGrid.GridControl grdControlDavaOdeme;
        public DevExpress.XtraGrid.Views.Grid.GridView gvDavaOdeme;
        private DevExpress.XtraGrid.Columns.GridColumn colODEYEN_CARI;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_MIKTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_YERI;

    }
}