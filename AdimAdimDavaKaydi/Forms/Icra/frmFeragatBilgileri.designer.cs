namespace  AdimAdimDavaKaydi.Forms.Icra
{
    partial class frmFeragatBilgileri
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
            DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties1 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties2 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties3 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties4 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rSpinMiktar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.rLueDovizID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.vgFeragatBilgileri = new DevExpress.XtraVerticalGrid.VGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueFeragatTipi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rDateTarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rLueMahsupAltKategori = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueFeragatKapsami = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rowFERAGAT_TIP = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowFERAGAT_KAPSAM = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowFERAGAT_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.mRowFERAGAT_MIKTAR = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.mRowDAGITILMAMIS_MIKTAR = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.rowMAHSUP_ALT_KATEGORI_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.dnFeragat = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            
            
            
            ((System.ComponentModel.ISupportInitialize)(this.rSpinMiktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgFeragatBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFeragatTipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMahsupAltKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFeragatKapsami)).BeginInit();
            this.SuspendLayout();
            // 
            // mrqEnAlt
            // 
            
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(708, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 368);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 368);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.dnFeragat);
            this.c_pnlContainer.Controls.Add(this.vgFeragatBilgileri);
            this.c_pnlContainer.Size = new System.Drawing.Size(725, 314);
            this.c_pnlContainer.Controls.SetChildIndex(this.vgFeragatBilgileri, 0);
 
            this.c_pnlContainer.Controls.SetChildIndex(this.dnFeragat, 0);
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
            // rSpinMiktar
            // 
            this.rSpinMiktar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rSpinMiktar.Name = "rSpinMiktar";
            // 
            // rLueDovizID
            // 
            this.rLueDovizID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDovizID.Name = "rLueDovizID";
            // 
            // vgFeragatBilgileri
            // 
            this.vgFeragatBilgileri.Dock = System.Windows.Forms.DockStyle.Top;
            this.vgFeragatBilgileri.ExternalRepository = this.MyRepository;
            this.vgFeragatBilgileri.Location = new System.Drawing.Point(0, 0);
            this.vgFeragatBilgileri.Name = "vgFeragatBilgileri";
            this.vgFeragatBilgileri.RecordWidth = 145;
            this.vgFeragatBilgileri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueFeragatKapsami});
            this.vgFeragatBilgileri.RowHeaderWidth = 177;
            this.vgFeragatBilgileri.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowFERAGAT_TIP,
            this.rowFERAGAT_KAPSAM,
            this.rowFERAGAT_TARIHI,
            this.mRowFERAGAT_MIKTAR,
            this.mRowDAGITILMAMIS_MIKTAR,
            this.rowMAHSUP_ALT_KATEGORI_ID});
            this.vgFeragatBilgileri.Size = new System.Drawing.Size(725, 265);
            this.vgFeragatBilgileri.TabIndex = 0;
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueFeragatTipi,
            this.rSpinMiktar,
            this.rDateTarih,
            this.rLueDovizID,
            this.rLueMahsupAltKategori});
            // 
            // rLueFeragatTipi
            // 
            this.rLueFeragatTipi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueFeragatTipi.Name = "rLueFeragatTipi";
            // 
            // rDateTarih
            // 
            this.rDateTarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rDateTarih.Name = "rDateTarih";
            this.rDateTarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rLueMahsupAltKategori
            // 
            this.rLueMahsupAltKategori.AutoHeight = false;
            this.rLueMahsupAltKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMahsupAltKategori.Name = "rLueMahsupAltKategori";
            // 
            // rLueFeragatKapsami
            // 
            this.rLueFeragatKapsami.AutoHeight = false;
            this.rLueFeragatKapsami.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueFeragatKapsami.Name = "rLueFeragatKapsami";
            // 
            // rowFERAGAT_TIP
            // 
            this.rowFERAGAT_TIP.Name = "rowFERAGAT_TIP";
            this.rowFERAGAT_TIP.Properties.Caption = "Feragat Tipi ";
            this.rowFERAGAT_TIP.Properties.FieldName = "FERAGAT_TIP";
            this.rowFERAGAT_TIP.Properties.RowEdit = this.rLueFeragatTipi;
            // 
            // rowFERAGAT_KAPSAM
            // 
            this.rowFERAGAT_KAPSAM.Name = "rowFERAGAT_KAPSAM";
            this.rowFERAGAT_KAPSAM.Properties.Caption = "Feragat Kapsamý ";
            this.rowFERAGAT_KAPSAM.Properties.FieldName = "FERAGAT_KAPSAM";
            this.rowFERAGAT_KAPSAM.Properties.RowEdit = this.rLueFeragatKapsami;
            // 
            // rowFERAGAT_TARIHI
            // 
            this.rowFERAGAT_TARIHI.Name = "rowFERAGAT_TARIHI";
            this.rowFERAGAT_TARIHI.Properties.Caption = "Feragat Tarihi";
            this.rowFERAGAT_TARIHI.Properties.FieldName = "FERAGAT_TARIHI";
            this.rowFERAGAT_TARIHI.Properties.RowEdit = this.rDateTarih;
            // 
            // mRowFERAGAT_MIKTAR
            // 
            this.mRowFERAGAT_MIKTAR.Name = "mRowFERAGAT_MIKTAR";
            multiEditorRowProperties1.Caption = "Feragat Miktarý";
            multiEditorRowProperties1.FieldName = "FERAGAT_MIKTAR";
            multiEditorRowProperties1.RowEdit = this.rSpinMiktar;
            multiEditorRowProperties2.Caption = "Brm.";
            multiEditorRowProperties2.FieldName = "FERAGAT_MIKTAR_DOVIZ_ID";
            multiEditorRowProperties2.RowEdit = this.rLueDovizID;
            this.mRowFERAGAT_MIKTAR.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            multiEditorRowProperties1,
            multiEditorRowProperties2});
            // 
            // mRowDAGITILMAMIS_MIKTAR
            // 
            this.mRowDAGITILMAMIS_MIKTAR.Name = "mRowDAGITILMAMIS_MIKTAR";
            multiEditorRowProperties3.Caption = "Daðýtýlmýþ Miktar ";
            multiEditorRowProperties3.FieldName = "DAGITILMAMIS_MIKTAR";
            multiEditorRowProperties3.RowEdit = this.rSpinMiktar;
            multiEditorRowProperties4.Caption = "Brm.";
            multiEditorRowProperties4.FieldName = "DAGITILMAMIS_MIKTAR_DOVIZ_ID";
            multiEditorRowProperties4.RowEdit = this.rLueDovizID;
            this.mRowDAGITILMAMIS_MIKTAR.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            multiEditorRowProperties3,
            multiEditorRowProperties4});
            // 
            // rowMAHSUP_ALT_KATEGORI_ID
            // 
            this.rowMAHSUP_ALT_KATEGORI_ID.Name = "rowMAHSUP_ALT_KATEGORI_ID";
            this.rowMAHSUP_ALT_KATEGORI_ID.Properties.Caption = "Mahsup Alt Kategori";
            this.rowMAHSUP_ALT_KATEGORI_ID.Properties.FieldName = "MAHSUP_ALT_KATEGORI_ID";
            this.rowMAHSUP_ALT_KATEGORI_ID.Properties.RowEdit = this.rLueMahsupAltKategori;
            // 
            // dnFeragat
            // 
            this.dnFeragat.Buttons.CancelEdit.Visible = false;
            this.dnFeragat.Buttons.NextPage.Visible = false;
            this.dnFeragat.Buttons.PrevPage.Visible = false;
            this.dnFeragat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dnFeragat.Location = new System.Drawing.Point(0, 265);
            this.dnFeragat.MyChartControl = null;
            this.dnFeragat.MyGridControl = null;
            this.dnFeragat.MyPivotGridControl = null;
            this.dnFeragat.MyVGridControl = null;
            this.dnFeragat.Name = "dnFeragat";
            this.dnFeragat.SelectButtonVisible = false;
            this.dnFeragat.Size = new System.Drawing.Size(725, 24);
            this.dnFeragat.TabIndex = 11;
            this.dnFeragat.Text = "dataNavigatorExtended1";
            this.dnFeragat.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.dnFeragat.TextStringFormat = "Kayýt {0} / {1}";
            // 
            // frmFeragatBilgileri
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 368);
            this.Name = "frmFeragatBilgileri";
            this.Text = "Feragat Bilgileri Kayýt Formu";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmFeragatBilgileri_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFeragatBilgileri_FormClosing);
 
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
 
 
 
            ((System.ComponentModel.ISupportInitialize)(this.rSpinMiktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgFeragatBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFeragatTipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMahsupAltKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFeragatKapsami)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl vgFeragatBilgileri;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowFERAGAT_TIP;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowFERAGAT_KAPSAM;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowFERAGAT_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMAHSUP_ALT_KATEGORI_ID;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueFeragatTipi;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rSpinMiktar;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rDateTarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMahsupAltKategori;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueFeragatKapsami;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dnFeragat;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow mRowFERAGAT_MIKTAR;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow mRowDAGITILMAMIS_MIKTAR;


    }
}