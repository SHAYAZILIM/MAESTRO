namespace  AdimAdimDavaKaydi.Sorusturma.UserControls
{
    partial class ucSorusturmaNedenTaraf
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.vgSorusturmaNedenTaraf = new DevExpress.XtraVerticalGrid.VGridControl();
            this.perSozlesmeTaraf = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueSikayetNeden = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSorusturmaTarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rLueTarafSifat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueTarafCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rImexAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.rMemoAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.rowSIKAYET_NEDEN_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTARAF_SIFAT_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTARAF_CARI_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSORUSTURMA_IZIN_SONUC = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSORUSTURMA_IZIN_SONUC_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSORUSTURMA_IZIN_ISTEK_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowOGRENME_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowACIKLAMA = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.dataNavigatorExtended1 = new AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended();
            ((System.ComponentModel.ISupportInitialize)(this.vgSorusturmaNedenTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetNeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorusturmaTarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorusturmaTarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafSifat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rImexAciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMemoAciklama)).BeginInit();
            this.SuspendLayout();
            // 
            // vgSorusturmaNedenTaraf
            // 
            this.vgSorusturmaNedenTaraf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgSorusturmaNedenTaraf.ExternalRepository = this.perSozlesmeTaraf;
            this.vgSorusturmaNedenTaraf.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.BandsView;
            this.vgSorusturmaNedenTaraf.Location = new System.Drawing.Point(0, 0);
            this.vgSorusturmaNedenTaraf.Name = "vgSorusturmaNedenTaraf";
            this.vgSorusturmaNedenTaraf.RecordWidth = 217;
            this.vgSorusturmaNedenTaraf.RowHeaderWidth = 211;
            this.vgSorusturmaNedenTaraf.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowSIKAYET_NEDEN_ID,
            this.rowTARAF_SIFAT_ID,
            this.rowSORUSTURMA_IZIN_SONUC,
            this.rowOGRENME_TARIHI,
            this.rowACIKLAMA});
            this.vgSorusturmaNedenTaraf.Size = new System.Drawing.Size(439, 273);
            this.vgSorusturmaNedenTaraf.TabIndex = 2;
            // 
            // perSozlesmeTaraf
            // 
            this.perSozlesmeTaraf.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueSikayetNeden,
            this.rLueSorusturmaTarih,
            this.rLueTarafSifat,
            this.rLueTarafCari,
            this.rImexAciklama,
            this.rMemoAciklama});
            // 
            // rLueSikayetNeden
            // 
            this.rLueSikayetNeden.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSikayetNeden.Name = "rLueSikayetNeden";
            this.rLueSikayetNeden.NullText = "Sikayet Nedeni";
            // 
            // rLueSorusturmaTarih
            // 
            this.rLueSorusturmaTarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSorusturmaTarih.Name = "rLueSorusturmaTarih";
            this.rLueSorusturmaTarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rLueTarafSifat
            // 
            this.rLueTarafSifat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTarafSifat.Name = "rLueTarafSifat";
            this.rLueTarafSifat.NullText = "Sýfat";
            // 
            // rLueTarafCari
            // 
            this.rLueTarafCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "CariEkle", null)});
            this.rLueTarafCari.Name = "rLueTarafCari";
            this.rLueTarafCari.NullText = "Cari";
            this.rLueTarafCari.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rLueTarafCari.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rLueTarafCari_ButtonClick);
            this.rLueTarafCari.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.rLueTarafCari_ProcessNewValue);
            // 
            // rImexAciklama
            // 
            this.rImexAciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rImexAciklama.Name = "rImexAciklama";
            this.rImexAciklama.NullText = "Açýklama";
            // 
            // rMemoAciklama
            // 
            this.rMemoAciklama.Name = "rMemoAciklama";
            // 
            // rowSIKAYET_NEDEN_ID
            // 
            this.rowSIKAYET_NEDEN_ID.Name = "rowSIKAYET_NEDEN_ID";
            this.rowSIKAYET_NEDEN_ID.Properties.Caption = "Þikayet Nedeni ";
            this.rowSIKAYET_NEDEN_ID.Properties.FieldName = "SIKAYET_NEDEN_ID";
            this.rowSIKAYET_NEDEN_ID.Properties.RowEdit = this.rLueSikayetNeden;
            // 
            // rowTARAF_SIFAT_ID
            // 
            this.rowTARAF_SIFAT_ID.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowTARAF_CARI_ID});
            this.rowTARAF_SIFAT_ID.Name = "rowTARAF_SIFAT_ID";
            this.rowTARAF_SIFAT_ID.Properties.Caption = "Sýfat";
            this.rowTARAF_SIFAT_ID.Properties.FieldName = "TARAF_SIFAT_ID";
            this.rowTARAF_SIFAT_ID.Properties.RowEdit = this.rLueTarafSifat;
            // 
            // rowTARAF_CARI_ID
            // 
            this.rowTARAF_CARI_ID.Name = "rowTARAF_CARI_ID";
            this.rowTARAF_CARI_ID.Properties.Caption = "Taraf Adý ";
            this.rowTARAF_CARI_ID.Properties.FieldName = "TARAF_CARI_ID";
            this.rowTARAF_CARI_ID.Properties.RowEdit = this.rLueTarafCari;
            // 
            // rowSORUSTURMA_IZIN_SONUC
            // 
            this.rowSORUSTURMA_IZIN_SONUC.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowSORUSTURMA_IZIN_SONUC_TARIHI,
            this.rowSORUSTURMA_IZIN_ISTEK_TARIHI});
            this.rowSORUSTURMA_IZIN_SONUC.Name = "rowSORUSTURMA_IZIN_SONUC";
            this.rowSORUSTURMA_IZIN_SONUC.Properties.Caption = "Sorusturma Ýzin Sonucu ";
            this.rowSORUSTURMA_IZIN_SONUC.Properties.FieldName = "SORUSTURMA_IZIN_SONUC";
            // 
            // rowSORUSTURMA_IZIN_SONUC_TARIHI
            // 
            this.rowSORUSTURMA_IZIN_SONUC_TARIHI.Name = "rowSORUSTURMA_IZIN_SONUC_TARIHI";
            this.rowSORUSTURMA_IZIN_SONUC_TARIHI.Properties.Caption = "Ýzin Sonuç Tarihi";
            this.rowSORUSTURMA_IZIN_SONUC_TARIHI.Properties.FieldName = "SORUSTURMA_IZIN_SONUC_TARIHI";
            this.rowSORUSTURMA_IZIN_SONUC_TARIHI.Properties.RowEdit = this.rLueSorusturmaTarih;
            // 
            // rowSORUSTURMA_IZIN_ISTEK_TARIHI
            // 
            this.rowSORUSTURMA_IZIN_ISTEK_TARIHI.Name = "rowSORUSTURMA_IZIN_ISTEK_TARIHI";
            this.rowSORUSTURMA_IZIN_ISTEK_TARIHI.Properties.Caption = "Ýzin Ýstek Tarihi";
            this.rowSORUSTURMA_IZIN_ISTEK_TARIHI.Properties.FieldName = "SORUSTURMA_IZIN_ISTEK_TARIHI";
            this.rowSORUSTURMA_IZIN_ISTEK_TARIHI.Properties.RowEdit = this.rLueSorusturmaTarih;
            // 
            // rowOGRENME_TARIHI
            // 
            this.rowOGRENME_TARIHI.Name = "rowOGRENME_TARIHI";
            this.rowOGRENME_TARIHI.Properties.Caption = "Öðrenme Tarihi";
            this.rowOGRENME_TARIHI.Properties.FieldName = "OGRENME_TARIHI";
            this.rowOGRENME_TARIHI.Properties.RowEdit = this.rLueSorusturmaTarih;
            // 
            // rowACIKLAMA
            // 
            this.rowACIKLAMA.Name = "rowACIKLAMA";
            this.rowACIKLAMA.Properties.Caption = "Açýklama ";
            this.rowACIKLAMA.Properties.FieldName = "ACIKLAMA";
            this.rowACIKLAMA.Properties.RowEdit = this.rImexAciklama;
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Buttons.CancelEdit.Visible = false;
            this.dataNavigatorExtended1.Buttons.NextPage.Visible = false;
            this.dataNavigatorExtended1.Buttons.PrevPage.Visible = false;
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(0, 273);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = null;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = this.vgSorusturmaNedenTaraf;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(439, 24);
            this.dataNavigatorExtended1.TabIndex = 1;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.dataNavigatorExtended1.TextStringFormat = "Taraf {0} / {1}";
            // 
            // ucSorusturmaNedenTaraf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vgSorusturmaNedenTaraf);
            this.Controls.Add(this.dataNavigatorExtended1);
            this.Name = "ucSorusturmaNedenTaraf";
            this.Size = new System.Drawing.Size(439, 297);
            this.Load += new System.EventHandler(this.ucSorusturmaNedenTaraf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vgSorusturmaNedenTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetNeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorusturmaTarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorusturmaTarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafSifat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rImexAciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMemoAciklama)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private DevExpress.XtraVerticalGrid.VGridControl vgSorusturmaNedenTaraf;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSIKAYET_NEDEN_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowOGRENME_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowACIKLAMA;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSORUSTURMA_IZIN_SONUC;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSORUSTURMA_IZIN_SONUC_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSORUSTURMA_IZIN_ISTEK_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTARAF_SIFAT_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTARAF_CARI_ID;
        private DevExpress.XtraEditors.Repository.PersistentRepository perSozlesmeTaraf;
        private AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended dataNavigatorExtended1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSikayetNeden;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rLueSorusturmaTarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTarafSifat;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTarafCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit rImexAciklama;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit rMemoAciklama;
    }
}
