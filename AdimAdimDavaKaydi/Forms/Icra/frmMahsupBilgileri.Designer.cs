namespace  AdimAdimDavaKaydi.Forms.Icra
{
    partial class frmMahsupBilgileri
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
            DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties3 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties4 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rSpeMahsupMiktari = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.rLueDovizTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dNEgrdMahsupBilgileri = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            this.vgMahsupBilgileri = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rDateMahsupTarihi = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rMexeAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.rowMAHSUP_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.mRowMahsupMiktarDoviz = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.rowACIKLAMA = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            
            
            
            ((System.ComponentModel.ISupportInitialize)(this.rSpeMahsupMiktari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vgMahsupBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateMahsupTarihi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateMahsupTarihi.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMexeAciklama)).BeginInit();
            this.SuspendLayout();
            // 
            // mrqEnAlt
            // 
            
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.clientPanel);
            this.c_pnlContainer.Size = new System.Drawing.Size(473, 230);
            this.c_pnlContainer.Controls.SetChildIndex(this.clientPanel, 0);
 
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(490, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 284);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 284);
            // 
            // c_pnlAltButtons
            // 
 
 
            // 
            // c_btnIptal
            // 
 
            // 
            // c_btnTamam
            // 
 
            // 
            // prgEnAlt
            // 
            // 
            // c_btnYardim
            // 
 
 
 
 
 
 
 
 
 
 
 
 
 
            // 
            // c_btnCaption
            // 
 
 
 
 
 
 
 
 
            // 
            // rSpeMahsupMiktari
            // 
            this.rSpeMahsupMiktari.AutoHeight = false;
            this.rSpeMahsupMiktari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rSpeMahsupMiktari.Name = "rSpeMahsupMiktari";
            // 
            // rLueDovizTip
            // 
            this.rLueDovizTip.AutoHeight = false;
            this.rLueDovizTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDovizTip.Name = "rLueDovizTip";
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.panelControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 0);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(473, 230);
            this.clientPanel.TabIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.vgMahsupBilgileri);
            this.panelControl1.Controls.Add(this.dNEgrdMahsupBilgileri);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(473, 202);
            this.panelControl1.TabIndex = 0;
            // 
            // dNEgrdMahsupBilgileri
            // 
            this.dNEgrdMahsupBilgileri.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dNEgrdMahsupBilgileri.Location = new System.Drawing.Point(2, 176);
            this.dNEgrdMahsupBilgileri.MyChartControl = null;
            this.dNEgrdMahsupBilgileri.MyGridControl = null;
            this.dNEgrdMahsupBilgileri.MyPivotGridControl = null;
            this.dNEgrdMahsupBilgileri.MyVGridControl = null;
            this.dNEgrdMahsupBilgileri.Name = "dNEgrdMahsupBilgileri";
            this.dNEgrdMahsupBilgileri.SelectButtonVisible = false;
            this.dNEgrdMahsupBilgileri.Size = new System.Drawing.Size(469, 24);
            this.dNEgrdMahsupBilgileri.TabIndex = 1;
            this.dNEgrdMahsupBilgileri.Text = "dataNavigatorExtended1";
            // 
            // vgMahsupBilgileri
            // 
            this.vgMahsupBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgMahsupBilgileri.Location = new System.Drawing.Point(2, 2);
            this.vgMahsupBilgileri.Name = "vgMahsupBilgileri";
            this.vgMahsupBilgileri.RecordWidth = 200;
            this.vgMahsupBilgileri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rDateMahsupTarihi,
            this.rSpeMahsupMiktari,
            this.rLueDovizTip,
            this.rMexeAciklama});
            this.vgMahsupBilgileri.RowHeaderWidth = 108;
            this.vgMahsupBilgileri.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowMAHSUP_TARIHI,
            this.mRowMahsupMiktarDoviz,
            this.rowACIKLAMA});
            this.vgMahsupBilgileri.Size = new System.Drawing.Size(469, 174);
            this.vgMahsupBilgileri.TabIndex = 0;
            // 
            // rDateMahsupTarihi
            // 
            this.rDateMahsupTarihi.AutoHeight = false;
            this.rDateMahsupTarihi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rDateMahsupTarihi.Name = "rDateMahsupTarihi";
            this.rDateMahsupTarihi.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rMexeAciklama
            // 
            this.rMexeAciklama.AutoHeight = false;
            this.rMexeAciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rMexeAciklama.Name = "rMexeAciklama";
            // 
            // rowMAHSUP_TARIHI
            // 
            this.rowMAHSUP_TARIHI.Height = 19;
            this.rowMAHSUP_TARIHI.Name = "rowMAHSUP_TARIHI";
            this.rowMAHSUP_TARIHI.Properties.Caption = "Mahsup Tarihi";
            this.rowMAHSUP_TARIHI.Properties.FieldName = "MAHSUP_TARIHI";
            this.rowMAHSUP_TARIHI.Properties.RowEdit = this.rDateMahsupTarihi;
            // 
            // mRowMahsupMiktarDoviz
            // 
            this.mRowMahsupMiktarDoviz.Name = "mRowMahsupMiktarDoviz";
            multiEditorRowProperties3.Caption = "Miktar";
            multiEditorRowProperties3.FieldName = "MAHSUP_MIKTAR";
            multiEditorRowProperties3.RowEdit = this.rSpeMahsupMiktari;
            multiEditorRowProperties3.Width = 79;
            multiEditorRowProperties4.FieldName = "MAHSUP_MIKTAR_DOVIZ_ID";
            multiEditorRowProperties4.RowEdit = this.rLueDovizTip;
            multiEditorRowProperties4.Width = 15;
            this.mRowMahsupMiktarDoviz.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            multiEditorRowProperties3,
            multiEditorRowProperties4});
            // 
            // rowACIKLAMA
            // 
            this.rowACIKLAMA.Height = 78;
            this.rowACIKLAMA.Name = "rowACIKLAMA";
            this.rowACIKLAMA.Properties.Caption = "Açýklama";
            this.rowACIKLAMA.Properties.FieldName = "ACIKLAMA";
            this.rowACIKLAMA.Properties.RowEdit = this.rMexeAciklama;
            // 
            // frmMahsupBilgileri
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 284);
            this.Name = "frmMahsupBilgileri";
            this.Text = "Mahsup Bilgileri";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmMahsupBilgileri_Load);
 
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
 
 
 
            ((System.ComponentModel.ISupportInitialize)(this.rSpeMahsupMiktari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vgMahsupBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateMahsupTarihi.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateMahsupTarihi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMexeAciklama)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.XtraVerticalGrid.VGridControl vgMahsupBilgileri;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMAHSUP_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowACIKLAMA;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow mRowMahsupMiktarDoviz;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rDateMahsupTarihi;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rSpeMahsupMiktari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizTip;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dNEgrdMahsupBilgileri;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit rMexeAciklama;
        //private DevExpress.XtraBars.BarButtonItem btnKaydetVeCik;
        //private DevExpress.XtraBars.BarButtonItem btnVazgec;
    }
}