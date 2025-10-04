namespace  AdimAdimDavaKaydi.Sorusturma.Forms
{
    partial class frmSikayetNeden
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
            this.vgSikayetNeden = new DevExpress.XtraVerticalGrid.VGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueSikayetNedenKod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueAdliBirimAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rMemoAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.rDateTarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rMemoAciklamaa = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.rowSIKAYET_NEDEN_KOD_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowOLAY_SUC_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowOLAY_ADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEMADI_VAR = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDAVASI_ACILDIMI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowACIKLAMA = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowREFERANS_NO_1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowREFERANS_NO_2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.dnSikayetNeden = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            
            
            
            ((System.ComponentModel.ISupportInitialize)(this.vgSikayetNeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetNedenKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimAdliye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMemoAciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMemoAciklamaa)).BeginInit();
            this.SuspendLayout();
            // 
            // mrqEnAlt
            // 
            
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.vgSikayetNeden);
            this.c_pnlContainer.Controls.Add(this.dnSikayetNeden);
            this.c_pnlContainer.Size = new System.Drawing.Size(473, 229);
 
            this.c_pnlContainer.Controls.SetChildIndex(this.dnSikayetNeden, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.vgSikayetNeden, 0);
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(490, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 283);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 283);
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
            // vgSikayetNeden
            // 
            this.vgSikayetNeden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgSikayetNeden.ExternalRepository = this.MyRepository;
            this.vgSikayetNeden.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vgSikayetNeden.Location = new System.Drawing.Point(0, 0);
            this.vgSikayetNeden.Name = "vgSikayetNeden";
            this.vgSikayetNeden.RecordWidth = 123;
            this.vgSikayetNeden.RowHeaderWidth = 77;
            this.vgSikayetNeden.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowSIKAYET_NEDEN_KOD_ID,
            this.rowOLAY_SUC_TARIHI,
            this.rowOLAY_ADLI_BIRIM_ADLIYE_ID,
            this.rowTEMADI_VAR,
            this.rowDAVASI_ACILDIMI,
            this.rowACIKLAMA,
            this.rowREFERANS_NO_1,
            this.rowREFERANS_NO_2});
            this.vgSikayetNeden.Size = new System.Drawing.Size(473, 185);
            this.vgSikayetNeden.TabIndex = 9;
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueSikayetNedenKod,
            this.rLueAdliBirimAdliye,
            this.rMemoAciklama,
            this.rDateTarih,
            this.rCheckEdit,
            this.rMemoAciklamaa});
            // 
            // rLueSikayetNedenKod
            // 
            this.rLueSikayetNedenKod.AutoHeight = false;
            this.rLueSikayetNedenKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSikayetNedenKod.Name = "rLueSikayetNedenKod";
            // 
            // rLueAdliBirimAdliye
            // 
            this.rLueAdliBirimAdliye.AutoHeight = false;
            this.rLueAdliBirimAdliye.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimAdliye.Name = "rLueAdliBirimAdliye";
            // 
            // rMemoAciklama
            // 
            this.rMemoAciklama.AutoHeight = false;
            this.rMemoAciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rMemoAciklama.Name = "rMemoAciklama";
            // 
            // rDateTarih
            // 
            this.rDateTarih.AutoHeight = false;
            this.rDateTarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rDateTarih.Name = "rDateTarih";
            this.rDateTarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rCheckEdit
            // 
            this.rCheckEdit.AutoHeight = false;
            this.rCheckEdit.Name = "rCheckEdit";
            // 
            // rMemoAciklamaa
            // 
            this.rMemoAciklamaa.Name = "rMemoAciklamaa";
            // 
            // rowSIKAYET_NEDEN_KOD_ID
            // 
            this.rowSIKAYET_NEDEN_KOD_ID.Name = "rowSIKAYET_NEDEN_KOD_ID";
            this.rowSIKAYET_NEDEN_KOD_ID.Properties.Caption = "Sikayet Neden";
            this.rowSIKAYET_NEDEN_KOD_ID.Properties.FieldName = "SIKAYET_NEDEN_KOD_ID";
            this.rowSIKAYET_NEDEN_KOD_ID.Properties.RowEdit = this.rLueSikayetNedenKod;
            // 
            // rowOLAY_SUC_TARIHI
            // 
            this.rowOLAY_SUC_TARIHI.Name = "rowOLAY_SUC_TARIHI";
            this.rowOLAY_SUC_TARIHI.Properties.Caption = "Olay SuçT.";
            this.rowOLAY_SUC_TARIHI.Properties.FieldName = "OLAY_SUC_TARIHI";
            this.rowOLAY_SUC_TARIHI.Properties.RowEdit = this.rDateTarih;
            // 
            // rowOLAY_ADLI_BIRIM_ADLIYE_ID
            // 
            this.rowOLAY_ADLI_BIRIM_ADLIYE_ID.Name = "rowOLAY_ADLI_BIRIM_ADLIYE_ID";
            this.rowOLAY_ADLI_BIRIM_ADLIYE_ID.Properties.Caption = "Olay Adliye";
            this.rowOLAY_ADLI_BIRIM_ADLIYE_ID.Properties.FieldName = "OLAY_ADLI_BIRIM_ADLIYE_ID";
            this.rowOLAY_ADLI_BIRIM_ADLIYE_ID.Properties.RowEdit = this.rLueAdliBirimAdliye;
            // 
            // rowTEMADI_VAR
            // 
            this.rowTEMADI_VAR.Name = "rowTEMADI_VAR";
            this.rowTEMADI_VAR.Properties.Caption = "Temadý var mý?";
            this.rowTEMADI_VAR.Properties.FieldName = "TEMADI_VAR";
            this.rowTEMADI_VAR.Properties.RowEdit = this.rCheckEdit;
            // 
            // rowDAVASI_ACILDIMI
            // 
            this.rowDAVASI_ACILDIMI.Name = "rowDAVASI_ACILDIMI";
            this.rowDAVASI_ACILDIMI.Properties.Caption = "Davasý Açýldý mý?";
            this.rowDAVASI_ACILDIMI.Properties.FieldName = "DAVASI_ACILDIMI";
            this.rowDAVASI_ACILDIMI.Properties.RowEdit = this.rCheckEdit;
            this.rowDAVASI_ACILDIMI.Properties.Value = false;
            // 
            // rowACIKLAMA
            // 
            this.rowACIKLAMA.Height = 59;
            this.rowACIKLAMA.Name = "rowACIKLAMA";
            this.rowACIKLAMA.Properties.Caption = "Açýklama";
            this.rowACIKLAMA.Properties.FieldName = "ACIKLAMA";
            this.rowACIKLAMA.Properties.RowEdit = this.rMemoAciklamaa;
            // 
            // rowREFERANS_NO_1
            // 
            this.rowREFERANS_NO_1.Name = "rowREFERANS_NO_1";
            this.rowREFERANS_NO_1.Properties.Caption = "REFERANS_NO_1";
            this.rowREFERANS_NO_1.Properties.FieldName = "REFERANS_NO_1";
            this.rowREFERANS_NO_1.Visible = false;
            // 
            // rowREFERANS_NO_2
            // 
            this.rowREFERANS_NO_2.Name = "rowREFERANS_NO_2";
            this.rowREFERANS_NO_2.Properties.Caption = "REFERANS_NO_2";
            this.rowREFERANS_NO_2.Properties.FieldName = "REFERANS_NO_2";
            this.rowREFERANS_NO_2.Visible = false;
            // 
            // dnSikayetNeden
            // 
            this.dnSikayetNeden.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dnSikayetNeden.Location = new System.Drawing.Point(0, 185);
            this.dnSikayetNeden.MyChartControl = null;
            this.dnSikayetNeden.MyGridControl = null;
            this.dnSikayetNeden.MyPivotGridControl = null;
            this.dnSikayetNeden.MyVGridControl = null;
            this.dnSikayetNeden.Name = "dnSikayetNeden";
            this.dnSikayetNeden.SelectButtonVisible = false;
            this.dnSikayetNeden.Size = new System.Drawing.Size(473, 19);
            this.dnSikayetNeden.TabIndex = 10;
            // 
            // frmSikayetNeden
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 283);
            this.Name = "frmSikayetNeden";
            this.Text = "Þikayet Neden Kayýt Formu";
            this.UstMenu = true;
 
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
 
 
 
            ((System.ComponentModel.ISupportInitialize)(this.vgSikayetNeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetNedenKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimAdliye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMemoAciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMemoAciklamaa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl vgSikayetNeden;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSIKAYET_NEDEN_KOD_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowOLAY_SUC_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowOLAY_ADLI_BIRIM_ADLIYE_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEMADI_VAR;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowACIKLAMA;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDAVASI_ACILDIMI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowREFERANS_NO_1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowREFERANS_NO_2;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dnSikayetNeden;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSikayetNedenKod;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimAdliye;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit rMemoAciklama;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rDateTarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rCheckEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit rMemoAciklamaa;
    }
}