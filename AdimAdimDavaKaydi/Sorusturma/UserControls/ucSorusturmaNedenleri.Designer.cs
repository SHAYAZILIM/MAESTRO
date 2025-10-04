namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    partial class ucSorusturmaNedenleri
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.multiEditorRowProperties1 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rckKontrol = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.multiEditorRowProperties2 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rLueAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties3 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rDateSorusturma = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.multiEditorRowProperties4 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties5 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.vgrdSorusturmaNedenleri = new DevExpress.XtraVerticalGrid.VGridControl();
            this.persistentRepository1 = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueSikayetNedenKod = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.rLueFoy = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rSikayetAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.rowSIKAYET_NEDEN_KOD_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEMADI_VAR = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.roeDava = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.rowOlay = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.rowref12 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.rowACIKLAMA = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.dataNavigatorExtended1 = new AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended();
            ((System.ComponentModel.ISupportInitialize)(this.rckKontrol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateSorusturma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateSorusturma.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdSorusturmaNedenleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetNedenKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFoy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSikayetAciklama)).BeginInit();
            this.SuspendLayout();
            // 
            // multiEditorRowProperties1
            // 
            this.multiEditorRowProperties1.Caption = "Davasý açýldý mý ?";
            this.multiEditorRowProperties1.FieldName = "DAVASI_ACILDIMI";
            this.multiEditorRowProperties1.RowEdit = this.rckKontrol;
            // 
            // rckKontrol
            // 
            this.rckKontrol.Name = "rckKontrol";
            // 
            // multiEditorRowProperties2
            // 
            this.multiEditorRowProperties2.Caption = "Suç Yeri";
            this.multiEditorRowProperties2.FieldName = "OLAY_ADLI_BIRIM_ADLIYE_ID";
            this.multiEditorRowProperties2.RowEdit = this.rLueAdliye;
            // 
            // rLueAdliye
            // 
            this.rLueAdliye.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliye.Name = "rLueAdliye";
            this.rLueAdliye.NullText = "Adliye";
            // 
            // multiEditorRowProperties3
            // 
            this.multiEditorRowProperties3.Caption = "Suç Tarihi";
            this.multiEditorRowProperties3.FieldName = "OLAY_SUC_TARIHI";
            this.multiEditorRowProperties3.RowEdit = this.rDateSorusturma;
            // 
            // rDateSorusturma
            // 
            this.rDateSorusturma.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rDateSorusturma.Name = "rDateSorusturma";
            this.rDateSorusturma.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // multiEditorRowProperties4
            // 
            this.multiEditorRowProperties4.Caption = "Ref 1";
            this.multiEditorRowProperties4.FieldName = "REFERANS_NO_1";
            // 
            // multiEditorRowProperties5
            // 
            this.multiEditorRowProperties5.Caption = "Ref 2";
            this.multiEditorRowProperties5.FieldName = "REFERANS_NO_2";
            // 
            // vgrdSorusturmaNedenleri
            // 
            this.vgrdSorusturmaNedenleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgrdSorusturmaNedenleri.ExternalRepository = this.persistentRepository1;
            this.vgrdSorusturmaNedenleri.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.BandsView;
            this.vgrdSorusturmaNedenleri.Location = new System.Drawing.Point(0, 0);
            this.vgrdSorusturmaNedenleri.Name = "vgrdSorusturmaNedenleri";
            this.vgrdSorusturmaNedenleri.RecordWidth = 212;
            this.vgrdSorusturmaNedenleri.RowHeaderWidth = 197;
            this.vgrdSorusturmaNedenleri.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowSIKAYET_NEDEN_KOD_ID,
            this.rowTEMADI_VAR,
            this.roeDava,
            this.rowOlay,
            this.rowref12,
            this.rowACIKLAMA});
            this.vgrdSorusturmaNedenleri.Size = new System.Drawing.Size(418, 195);
            this.vgrdSorusturmaNedenleri.TabIndex = 0;
            // 
            // persistentRepository1
            // 
            this.persistentRepository1.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueSikayetNedenKod,
            this.rckKontrol,
            this.rDateSorusturma,
            this.rLueAdliye,
            this.rLueFoy,
            this.rSikayetAciklama});
            // 
            // rLueSikayetNedenKod
            // 
            this.rLueSikayetNedenKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSikayetNedenKod.Name = "rLueSikayetNedenKod";
            this.rLueSikayetNedenKod.NullText = "Þikayet Neden Kodu";
            // 
            // rLueFoy
            // 
            this.rLueFoy.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueFoy.Name = "rLueFoy";
            this.rLueFoy.NullText = "Foy";
            // 
            // rSikayetAciklama
            // 
            this.rSikayetAciklama.Name = "rSikayetAciklama";
            // 
            // rowSIKAYET_NEDEN_KOD_ID
            // 
            this.rowSIKAYET_NEDEN_KOD_ID.Name = "rowSIKAYET_NEDEN_KOD_ID";
            this.rowSIKAYET_NEDEN_KOD_ID.Properties.Caption = "Sikayet Neden Kodu";
            this.rowSIKAYET_NEDEN_KOD_ID.Properties.FieldName = "SIKAYET_NEDEN_KOD_ID";
            this.rowSIKAYET_NEDEN_KOD_ID.Properties.RowEdit = this.rLueSikayetNedenKod;
            // 
            // rowTEMADI_VAR
            // 
            this.rowTEMADI_VAR.Name = "rowTEMADI_VAR";
            this.rowTEMADI_VAR.Properties.Caption = "Temadý Var ";
            this.rowTEMADI_VAR.Properties.FieldName = "TEMADI_VAR";
            this.rowTEMADI_VAR.Properties.RowEdit = this.rckKontrol;
            // 
            // roeDava
            // 
            this.roeDava.Name = "roeDava";
            this.roeDava.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties1});
            // 
            // rowOlay
            // 
            this.rowOlay.Name = "rowOlay";
            this.rowOlay.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties2,
            this.multiEditorRowProperties3});
            // 
            // rowref12
            // 
            this.rowref12.Height = 16;
            this.rowref12.Name = "rowref12";
            this.rowref12.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties4,
            this.multiEditorRowProperties5});
            // 
            // rowACIKLAMA
            // 
            this.rowACIKLAMA.Height = 84;
            this.rowACIKLAMA.Name = "rowACIKLAMA";
            this.rowACIKLAMA.Properties.Caption = "ACIKLAMA";
            this.rowACIKLAMA.Properties.FieldName = "ACIKLAMA";
            this.rowACIKLAMA.Properties.RowEdit = this.rSikayetAciklama;
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Buttons.CancelEdit.Visible = false;
            this.dataNavigatorExtended1.Buttons.NextPage.Visible = false;
            this.dataNavigatorExtended1.Buttons.PrevPage.Visible = false;
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(0, 195);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = null;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = this.vgrdSorusturmaNedenleri;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(418, 24);
            this.dataNavigatorExtended1.TabIndex = 1;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.dataNavigatorExtended1.TextStringFormat = "Taraf {0} / {1}";
            // 
            // ucSorusturmaNedenleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vgrdSorusturmaNedenleri);
            this.Controls.Add(this.dataNavigatorExtended1);
            this.Name = "ucSorusturmaNedenleri";
            this.Size = new System.Drawing.Size(418, 219);
            this.Load += new System.EventHandler(this.ucSorusturmaNedenleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rckKontrol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateSorusturma.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateSorusturma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdSorusturmaNedenleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetNedenKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFoy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSikayetAciklama)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl vgrdSorusturmaNedenleri;
        private AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended dataNavigatorExtended1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSIKAYET_NEDEN_KOD_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEMADI_VAR;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowACIKLAMA;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow rowref12;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow roeDava;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow rowOlay;
        private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rckKontrol;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rDateSorusturma;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliye;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueFoy;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit rSikayetAciklama;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties1;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties2;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties3;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties4;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties5;
        public DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rLueSikayetNedenKod;
    }
}
