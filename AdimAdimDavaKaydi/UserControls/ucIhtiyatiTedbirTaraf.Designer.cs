namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucIhtiyatiTedbirTaraf
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
            this.multiEditorRowProperties1 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rlueSifatIcra = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties2 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rlueCariIcra = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties3 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rlkSifatDavaId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties4 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rlkCariDavaId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties5 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.tarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.multiEditorRowProperties6 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.aciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.vgIhtiyatiTedbirTaraf = new DevExpress.XtraVerticalGrid.VGridControl();
            this.persistentRepository1 = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rlkItirazSonucId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.mrowIcra = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.mrowDava = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.multiEditorRow2 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.rowITIRAZ_SONUC_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowIHTIYATI_TEDBIR_MAHKEMESI_KESINLESTIRME_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowIHTIYATI_TEDBIRIN_KALDIRILMASI_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEMINAT_IADESINE_MUVAFAKAT_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.multiEditorRow1 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.dataNavigatorExtended1 = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.rlueSifatIcra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCariIcra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkSifatDavaId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkCariDavaId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgIhtiyatiTedbirTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkItirazSonucId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // multiEditorRowProperties1
            // 
            this.multiEditorRowProperties1.Caption = "Taraf Sýfat ";
            this.multiEditorRowProperties1.FieldName = "ICRA_TARAF_SIFAT_ID";
            this.multiEditorRowProperties1.RowEdit = this.rlueSifatIcra;
            // 
            // rlueSifatIcra
            // 
            this.rlueSifatIcra.AutoHeight = false;
            this.rlueSifatIcra.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueSifatIcra.Name = "rlueSifatIcra";
            // 
            // multiEditorRowProperties2
            // 
            this.multiEditorRowProperties2.Caption = "Taraf";
            this.multiEditorRowProperties2.FieldName = "ICRA_CARI_TARAF_ID";
            this.multiEditorRowProperties2.RowEdit = this.rlueCariIcra;
            // 
            // rlueCariIcra
            // 
            this.rlueCariIcra.AutoHeight = false;
            this.rlueCariIcra.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueCariIcra.Name = "rlueCariIcra";
            // 
            // multiEditorRowProperties3
            // 
            this.multiEditorRowProperties3.Caption = "Taraf Sýfat";
            this.multiEditorRowProperties3.FieldName = "DAVA_TARAF_SIFAT_ID";
            this.multiEditorRowProperties3.RowEdit = this.rlkSifatDavaId;
            // 
            // rlkSifatDavaId
            // 
            this.rlkSifatDavaId.AutoHeight = false;
            this.rlkSifatDavaId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkSifatDavaId.Name = "rlkSifatDavaId";
            // 
            // multiEditorRowProperties4
            // 
            this.multiEditorRowProperties4.Caption = "Taraf";
            this.multiEditorRowProperties4.FieldName = "ICRA_CARI_TARAF_ID";
            this.multiEditorRowProperties4.RowEdit = this.rlkCariDavaId;
            // 
            // rlkCariDavaId
            // 
            this.rlkCariDavaId.AutoHeight = false;
            this.rlkCariDavaId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "CariEkle", null, false)});
            this.rlkCariDavaId.Name = "rlkCariDavaId";
            this.rlkCariDavaId.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rlkCariDavaId.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.rlkCariDavaId_ProcessNewValue);
            this.rlkCariDavaId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rlkCariDavaId_ButtonClick);
            // 
            // multiEditorRowProperties5
            // 
            this.multiEditorRowProperties5.Caption = "Ýtiraz Tarihi";
            this.multiEditorRowProperties5.FieldName = "IHTIYATI_TEDBIRE_ITIRAZ_TARIHI";
            this.multiEditorRowProperties5.RowEdit = this.tarih;
            this.multiEditorRowProperties5.Width = 68;
            // 
            // tarih
            // 
            this.tarih.AutoHeight = false;
            this.tarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tarih.Name = "tarih";
            this.tarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // multiEditorRowProperties6
            // 
            this.multiEditorRowProperties6.Caption = "Nedeni";
            this.multiEditorRowProperties6.FieldName = "IHTIYATI_TEDBIRE_ITIRAZ_NEDENI";
            this.multiEditorRowProperties6.RowEdit = this.aciklama;
            this.multiEditorRowProperties6.Width = 49;
            // 
            // aciklama
            // 
            this.aciklama.AutoHeight = false;
            this.aciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.aciklama.Name = "aciklama";
            // 
            // vgIhtiyatiTedbirTaraf
            // 
            this.vgIhtiyatiTedbirTaraf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgIhtiyatiTedbirTaraf.ExternalRepository = this.persistentRepository1;
            this.vgIhtiyatiTedbirTaraf.Location = new System.Drawing.Point(0, 0);
            this.vgIhtiyatiTedbirTaraf.Name = "vgIhtiyatiTedbirTaraf";
            this.vgIhtiyatiTedbirTaraf.RecordWidth = 246;
            this.vgIhtiyatiTedbirTaraf.RowHeaderWidth = 131;
            this.vgIhtiyatiTedbirTaraf.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.mrowIcra,
            this.mrowDava,
            this.multiEditorRow2,
            this.rowITIRAZ_SONUC_ID,
            this.rowIHTIYATI_TEDBIR_MAHKEMESI_KESINLESTIRME_TARIHI,
            this.rowIHTIYATI_TEDBIRIN_KALDIRILMASI_TARIHI,
            this.rowTEMINAT_IADESINE_MUVAFAKAT_TARIHI});
            this.vgIhtiyatiTedbirTaraf.Size = new System.Drawing.Size(633, 328);
            this.vgIhtiyatiTedbirTaraf.TabIndex = 0;
            // 
            // persistentRepository1
            // 
            this.persistentRepository1.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkSifatDavaId,
            this.rlkCariDavaId,
            this.rlkItirazSonucId,
            this.tarih,
            this.aciklama,
            this.rlueSifatIcra,
            this.rlueCariIcra});
            // 
            // rlkItirazSonucId
            // 
            this.rlkItirazSonucId.AutoHeight = false;
            this.rlkItirazSonucId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkItirazSonucId.Name = "rlkItirazSonucId";
            // 
            // mrowIcra
            // 
            this.mrowIcra.Name = "mrowIcra";
            this.mrowIcra.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties1,
            this.multiEditorRowProperties2});
            this.mrowIcra.Tag = "I";
            // 
            // mrowDava
            // 
            this.mrowDava.Name = "mrowDava";
            this.mrowDava.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties3,
            this.multiEditorRowProperties4});
            this.mrowDava.Visible = false;
            // 
            // multiEditorRow2
            // 
            this.multiEditorRow2.Name = "multiEditorRow2";
            this.multiEditorRow2.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties5,
            this.multiEditorRowProperties6});
            // 
            // rowITIRAZ_SONUC_ID
            // 
            this.rowITIRAZ_SONUC_ID.Name = "rowITIRAZ_SONUC_ID";
            this.rowITIRAZ_SONUC_ID.Properties.Caption = "Ýtiraz Sonucu";
            this.rowITIRAZ_SONUC_ID.Properties.FieldName = "ITIRAZ_SONUC_ID";
            this.rowITIRAZ_SONUC_ID.Properties.RowEdit = this.rlkItirazSonucId;
            // 
            // rowIHTIYATI_TEDBIR_MAHKEMESI_KESINLESTIRME_TARIHI
            // 
            this.rowIHTIYATI_TEDBIR_MAHKEMESI_KESINLESTIRME_TARIHI.Name = "rowIHTIYATI_TEDBIR_MAHKEMESI_KESINLESTIRME_TARIHI";
            this.rowIHTIYATI_TEDBIR_MAHKEMESI_KESINLESTIRME_TARIHI.Properties.Caption = "Kesinleþme T.";
            this.rowIHTIYATI_TEDBIR_MAHKEMESI_KESINLESTIRME_TARIHI.Properties.FieldName = "IHTIYATI_TEDBIR_MAHKEMESI_KESINLESTIRME_TARIHI";
            this.rowIHTIYATI_TEDBIR_MAHKEMESI_KESINLESTIRME_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowIHTIYATI_TEDBIRIN_KALDIRILMASI_TARIHI
            // 
            this.rowIHTIYATI_TEDBIRIN_KALDIRILMASI_TARIHI.Name = "rowIHTIYATI_TEDBIRIN_KALDIRILMASI_TARIHI";
            this.rowIHTIYATI_TEDBIRIN_KALDIRILMASI_TARIHI.Properties.Caption = "Kaldýrýlma T.";
            this.rowIHTIYATI_TEDBIRIN_KALDIRILMASI_TARIHI.Properties.FieldName = "IHTIYATI_TEDBIRIN_KALDIRILMASI_TARIHI";
            this.rowIHTIYATI_TEDBIRIN_KALDIRILMASI_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowTEMINAT_IADESINE_MUVAFAKAT_TARIHI
            // 
            this.rowTEMINAT_IADESINE_MUVAFAKAT_TARIHI.Name = "rowTEMINAT_IADESINE_MUVAFAKAT_TARIHI";
            this.rowTEMINAT_IADESINE_MUVAFAKAT_TARIHI.Properties.Caption = "Muvafakat T.";
            this.rowTEMINAT_IADESINE_MUVAFAKAT_TARIHI.Properties.FieldName = "TEMINAT_IADESINE_MUVAFAKAT_TARIHI";
            this.rowTEMINAT_IADESINE_MUVAFAKAT_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // multiEditorRow1
            // 
            this.multiEditorRow1.Name = "multiEditorRow1";
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Buttons.Append.Visible = false;
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(0, 304);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = null;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = this.vgIhtiyatiTedbirTaraf;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(633, 24);
            this.dataNavigatorExtended1.TabIndex = 1;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.OnCevirClick += new System.EventHandler(this.dataNavigatorExtended1_OnCevirClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn5,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Gruplamak için bir sutunu buraya sürükleyin";
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "")});
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Kayýt Eklemek Ýçin Týklayýn..";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Sýfat";
            this.gridColumn1.ColumnEdit = this.rlkSifatDavaId;
            this.gridColumn1.FieldName = "ICRA_TARAF_SIFAT_ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.gridColumn1.Tag = "I";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 139;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Taraf";
            this.gridColumn4.ColumnEdit = this.rlkCariDavaId;
            this.gridColumn4.FieldName = "ICRA_CARI_TARAF_ID";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 152;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Nedeni";
            this.gridColumn6.FieldName = "IHTIYATI_TEDBIRE_ITIRAZ_NEDENI";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 124;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Ýtiraz Sonucu";
            this.gridColumn7.ColumnEdit = this.rlkItirazSonucId;
            this.gridColumn7.FieldName = "ITIRAZ_SONUC_ID";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 135;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Ýtiraz Tarihi";
            this.gridColumn5.FieldName = "IHTIYATI_TEDBIRE_ITIRAZ_TARIHI";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 85;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Kesinleþme T.";
            this.gridColumn8.FieldName = "IHTIYATI_TEDBIR_MAHKEMESI_KESINLESTIRME_TARIHI";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 80;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Kaldýrýlma T.";
            this.gridColumn9.FieldName = "IHTIYATI_TEDBIRIN_KALDIRILMASI_TARIHI";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 77;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Muvafakat T.";
            this.gridColumn10.FieldName = "TEMINAT_IADESINE_MUVAFAKAT_TARIHI";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 7;
            this.gridColumn10.Width = 87;
            // 
            // gridControl1
            // 
            this.gridControl1.CustomButtonlarGorunmesin = false;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.DoNotExtendEmbedNavigator = false;
            this.gridControl1.ExternalRepository = this.persistentRepository1;
            this.gridControl1.FilterText = null;
            this.gridControl1.FilterValue = null;
            this.gridControl1.GridlerDuzenlenebilir = true;
            this.gridControl1.GridsFilterControl = null;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MyGridStyle = null;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ShowRowNumbers = false;
            this.gridControl1.SilmeKaldirilsin = false;
            this.gridControl1.Size = new System.Drawing.Size(633, 304);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.TemizleKaldirGorunsunmu = false;
            this.gridControl1.UniqueId = "0e7c3627-35dd-4d40-8b03-848ee9b74382";
            this.gridControl1.UseHyperDragDrop = false;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // ucIhtiyatiTedbirTaraf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dataNavigatorExtended1);
            this.Controls.Add(this.vgIhtiyatiTedbirTaraf);
            this.Name = "ucIhtiyatiTedbirTaraf";
            this.Size = new System.Drawing.Size(633, 328);
            this.Load += new System.EventHandler(this.ucIhtiyatiTedbirTaraf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rlueSifatIcra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCariIcra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkSifatDavaId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkCariDavaId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgIhtiyatiTedbirTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkItirazSonucId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl vgIhtiyatiTedbirTaraf;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowITIRAZ_SONUC_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowIHTIYATI_TEDBIR_MAHKEMESI_KESINLESTIRME_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowIHTIYATI_TEDBIRIN_KALDIRILMASI_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEMINAT_IADESINE_MUVAFAKAT_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow mrowIcra;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow mrowDava;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow multiEditorRow2;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow multiEditorRow1;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dataNavigatorExtended1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkSifatDavaId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkCariDavaId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkItirazSonucId;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridControl1;

        private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit tarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit aciklama;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueSifatIcra;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCariIcra;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties1;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties2;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties3;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties4;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties5;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties6;
    }
}
