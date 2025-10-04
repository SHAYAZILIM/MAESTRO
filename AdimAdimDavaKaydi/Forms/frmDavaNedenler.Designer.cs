namespace AdimAdimDavaKaydi.Forms
{
    partial class frmDavaNedenler
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
            this.grdControlDava = new DevExpress.XtraGrid.GridControl();
            this.gvDava = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDAVA_EDEN_TARAF_STATU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAVA_EDILEN_TARAF_STATU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAVA_NEDEN_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIGER_DAVA_NEDEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAVA_EDILEN_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdControlDava)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDava)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 328);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(653, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(503, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(578, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.grdControlDava);
            this.c_pnlContainer.Size = new System.Drawing.Size(653, 353);
            this.c_pnlContainer.Controls.SetChildIndex(this.grdControlDava, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // grdControlDava
            // 
            this.grdControlDava.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdControlDava.Location = new System.Drawing.Point(0, 0);
            this.grdControlDava.MainView = this.gvDava;
            this.grdControlDava.Name = "grdControlDava";
            this.grdControlDava.Size = new System.Drawing.Size(653, 353);
            this.grdControlDava.TabIndex = 10;
            this.grdControlDava.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDava});
            // 
            // gvDava
            // 
            this.gvDava.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDAVA_EDEN_TARAF_STATU,
            this.colDAVA_EDILEN_TARAF_STATU,
            this.colDAVA_NEDEN_TIP,
            this.colDIGER_DAVA_NEDEN,
            this.colDAVA_EDILEN_TUTAR});
            this.gvDava.GridControl = this.grdControlDava;
            this.gvDava.Name = "gvDava";
            // 
            // colDAVA_EDEN_TARAF_STATU
            // 
            this.colDAVA_EDEN_TARAF_STATU.Caption = "Dava Eden Taraf";
            this.colDAVA_EDEN_TARAF_STATU.FieldName = "DAVA_EDEN_TARAF_STATU";
            this.colDAVA_EDEN_TARAF_STATU.Name = "colDAVA_EDEN_TARAF_STATU";
            this.colDAVA_EDEN_TARAF_STATU.Visible = true;
            this.colDAVA_EDEN_TARAF_STATU.VisibleIndex = 0;
            // 
            // colDAVA_EDILEN_TARAF_STATU
            // 
            this.colDAVA_EDILEN_TARAF_STATU.Caption = "Dava Edilen Taraf";
            this.colDAVA_EDILEN_TARAF_STATU.FieldName = "DAVA_EDILEN_TARAF_STATU";
            this.colDAVA_EDILEN_TARAF_STATU.Name = "colDAVA_EDILEN_TARAF_STATU";
            this.colDAVA_EDILEN_TARAF_STATU.Visible = true;
            this.colDAVA_EDILEN_TARAF_STATU.VisibleIndex = 1;
            // 
            // colDAVA_NEDEN_TIP
            // 
            this.colDAVA_NEDEN_TIP.Caption = "Dava Neden Tip";
            this.colDAVA_NEDEN_TIP.FieldName = "DAVA_NEDEN_TIP";
            this.colDAVA_NEDEN_TIP.Name = "colDAVA_NEDEN_TIP";
            this.colDAVA_NEDEN_TIP.Visible = true;
            this.colDAVA_NEDEN_TIP.VisibleIndex = 2;
            // 
            // colDIGER_DAVA_NEDEN
            // 
            this.colDIGER_DAVA_NEDEN.Caption = "Diğer Neden";
            this.colDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            this.colDIGER_DAVA_NEDEN.Name = "colDIGER_DAVA_NEDEN";
            this.colDIGER_DAVA_NEDEN.Visible = true;
            this.colDIGER_DAVA_NEDEN.VisibleIndex = 3;
            // 
            // colDAVA_EDILEN_TUTAR
            // 
            this.colDAVA_EDILEN_TUTAR.Caption = "Dava Edilen Tutar";
            this.colDAVA_EDILEN_TUTAR.FieldName = "DAVA_EDILEN_TUTAR";
            this.colDAVA_EDILEN_TUTAR.Name = "colDAVA_EDILEN_TUTAR";
            this.colDAVA_EDILEN_TUTAR.Visible = true;
            this.colDAVA_EDILEN_TUTAR.VisibleIndex = 4;
            // 
            // frmDavaNedenleri
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 353);
            this.Name = "frmDavaNedenleri";
            this.Text = "Dava Nedenleri";
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdControlDava)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDava)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraGrid.GridControl grdControlDava;
        public DevExpress.XtraGrid.Views.Grid.GridView gvDava;
        private DevExpress.XtraGrid.Columns.GridColumn colDAVA_EDEN_TARAF_STATU;
        private DevExpress.XtraGrid.Columns.GridColumn colDAVA_EDILEN_TARAF_STATU;
        private DevExpress.XtraGrid.Columns.GridColumn colDAVA_NEDEN_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn colDIGER_DAVA_NEDEN;
        private DevExpress.XtraGrid.Columns.GridColumn colDAVA_EDILEN_TUTAR;
    }
}