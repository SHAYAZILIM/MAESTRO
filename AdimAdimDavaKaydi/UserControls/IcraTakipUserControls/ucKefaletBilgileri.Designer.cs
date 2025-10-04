namespace  AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    partial class ucKefaletBilgileri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKefaletBilgileri));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.multiEditorRowProperties1 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.tutar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.multiEditorRowProperties2 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rLueDovizID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridKefaletBilgileri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueCariID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueKefaletKapsamID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.aciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.gwKefaletBilgileri = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKEFIL_OLAN_CARI_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKEFALET_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKEFALET_KAPSAMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKEFALET_MIKTAR_DOVIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKEFALET_MIKTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIKLAMA4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.vGKafalet = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowKEFIL_OLAN_CARI_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowKEFALET_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowKEFALET_KAPSAM_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.mRowKefMiktar = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.rowACIKLAMA = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.dnKefalet = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            ((System.ComponentModel.ISupportInitialize)(this.tutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKefaletBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCariID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKefaletKapsamID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwKefaletBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGKafalet)).BeginInit();
            this.SuspendLayout();
            // 
            // multiEditorRowProperties1
            // 
            resources.ApplyResources(this.multiEditorRowProperties1, "multiEditorRowProperties1");
            this.multiEditorRowProperties1.FieldName = "KEFALET_MIKTARI";
            this.multiEditorRowProperties1.RowEdit = this.tutar;
            // 
            // tutar
            // 
            resources.ApplyResources(this.tutar, "tutar");
            this.tutar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tutar.Name = "tutar";
            // 
            // multiEditorRowProperties2
            // 
            resources.ApplyResources(this.multiEditorRowProperties2, "multiEditorRowProperties2");
            this.multiEditorRowProperties2.FieldName = "KEFALET_MIKTAR_DOVIZ_ID";
            this.multiEditorRowProperties2.RowEdit = this.rLueDovizID;
            // 
            // rLueDovizID
            // 
            this.rLueDovizID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueDovizID.Buttons"))))});
            this.rLueDovizID.Name = "rLueDovizID";
            // 
            // gridKefaletBilgileri
            // 
            this.gridKefaletBilgileri.CustomButtonlarGorunmesin = false;
            resources.ApplyResources(this.gridKefaletBilgileri, "gridKefaletBilgileri");
            this.gridKefaletBilgileri.DoNotExtendEmbedNavigator = false;
            this.gridKefaletBilgileri.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridKefaletBilgileri.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridKefaletBilgileri.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(((int)(resources.GetObject("gridKefaletBilgileri.EmbeddedNavigator.CustomButtons"))), ((int)(resources.GetObject("gridKefaletBilgileri.EmbeddedNavigator.CustomButtons1"))), ((bool)(resources.GetObject("gridKefaletBilgileri.EmbeddedNavigator.CustomButtons2"))), ((bool)(resources.GetObject("gridKefaletBilgileri.EmbeddedNavigator.CustomButtons3"))), resources.GetString("gridKefaletBilgileri.EmbeddedNavigator.CustomButtons4"), resources.GetString("gridKefaletBilgileri.EmbeddedNavigator.CustomButtons5")),
            new DevExpress.XtraEditors.NavigatorCustomButton(((int)(resources.GetObject("gridKefaletBilgileri.EmbeddedNavigator.CustomButtons6"))), ((int)(resources.GetObject("gridKefaletBilgileri.EmbeddedNavigator.CustomButtons7"))), ((bool)(resources.GetObject("gridKefaletBilgileri.EmbeddedNavigator.CustomButtons8"))), ((bool)(resources.GetObject("gridKefaletBilgileri.EmbeddedNavigator.CustomButtons9"))), resources.GetString("gridKefaletBilgileri.EmbeddedNavigator.CustomButtons10"), resources.GetString("gridKefaletBilgileri.EmbeddedNavigator.CustomButtons11"))});
            this.gridKefaletBilgileri.ExternalRepository = this.MyRepository;
            this.gridKefaletBilgileri.FilterText = null;
            this.gridKefaletBilgileri.FilterValue = null;
            this.gridKefaletBilgileri.GridlerDuzenlenebilir = true;
            this.gridKefaletBilgileri.GridsFilterControl = null;
            this.gridKefaletBilgileri.MainView = this.gwKefaletBilgileri;
            this.gridKefaletBilgileri.MyGridStyle = null;
            this.gridKefaletBilgileri.Name = "gridKefaletBilgileri";
            this.gridKefaletBilgileri.ShowRowNumbers = false;
            this.gridKefaletBilgileri.SilmeKaldirilsin = false;
            this.gridKefaletBilgileri.TemizleKaldirGorunsunmu = false;
            this.gridKefaletBilgileri.UniqueId = "fb1e5dc3-9a2e-4b6b-a2f1-09d71c6f7d68";
            this.gridKefaletBilgileri.UseEmbeddedNavigator = true;
            this.gridKefaletBilgileri.UseHyperDragDrop = false;
            this.gridKefaletBilgileri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwKefaletBilgileri});
            this.gridKefaletBilgileri.ButtonClick += new System.EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(this.gridKefaletBilgileri_ButtonClick);
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueCariID,
            this.rLueKefaletKapsamID,
            this.rLueDovizID,
            this.tarih,
            this.aciklama,
            this.tutar});
            // 
            // rLueCariID
            // 
            this.rLueCariID.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rLueCariID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueCariID.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueCariID.Buttons1"))), resources.GetString("rLueCariID.Buttons2"), ((int)(resources.GetObject("rLueCariID.Buttons3"))), ((bool)(resources.GetObject("rLueCariID.Buttons4"))), ((bool)(resources.GetObject("rLueCariID.Buttons5"))), ((bool)(resources.GetObject("rLueCariID.Buttons6"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("rLueCariID.Buttons7"))), ((System.Drawing.Image)(resources.GetObject("rLueCariID.Buttons8"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("rLueCariID.Buttons9"), resources.GetString("rLueCariID.Buttons10"), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("rLueCariID.Buttons11"))), ((bool)(resources.GetObject("rLueCariID.Buttons12"))))});
            this.rLueCariID.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.rLueCariID.Name = "rLueCariID";
            this.rLueCariID.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rLueCariID.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rLueCariID_ButtonClick);
            // 
            // rLueKefaletKapsamID
            // 
            this.rLueKefaletKapsamID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueKefaletKapsamID.Buttons"))))});
            this.rLueKefaletKapsamID.Name = "rLueKefaletKapsamID";
            // 
            // tarih
            // 
            resources.ApplyResources(this.tarih, "tarih");
            this.tarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("tarih.Buttons"))))});
            this.tarih.Name = "tarih";
            this.tarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // aciklama
            // 
            resources.ApplyResources(this.aciklama, "aciklama");
            this.aciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("aciklama.Buttons"))))});
            this.aciklama.Name = "aciklama";
            // 
            // gwKefaletBilgileri
            // 
            this.gwKefaletBilgileri.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKEFIL_OLAN_CARI_ADI,
            this.colKEFALET_TARIHI,
            this.colKEFALET_KAPSAMI,
            this.colKEFALET_MIKTAR_DOVIZ,
            this.colKEFALET_MIKTARI,
            this.colACIKLAMA4});
            this.gwKefaletBilgileri.GridControl = this.gridKefaletBilgileri;
            resources.ApplyResources(this.gwKefaletBilgileri, "gwKefaletBilgileri");
            this.gwKefaletBilgileri.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwKefaletBilgileri.GroupSummary"))), resources.GetString("gwKefaletBilgileri.GroupSummary1"), this.colKEFALET_MIKTARI, resources.GetString("gwKefaletBilgileri.GroupSummary2"))});
            this.gwKefaletBilgileri.IndicatorWidth = 20;
            this.gwKefaletBilgileri.Name = "gwKefaletBilgileri";
            this.gwKefaletBilgileri.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwKefaletBilgileri.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gwKefaletBilgileri.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gwKefaletBilgileri.OptionsNavigation.AutoFocusNewRow = true;
            this.gwKefaletBilgileri.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwKefaletBilgileri.OptionsView.ColumnAutoWidth = false;
            this.gwKefaletBilgileri.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gwKefaletBilgileri.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwKefaletBilgileri.PaintStyleName = "Skin";
            this.gwKefaletBilgileri.PreviewFieldName = "ACIKLAMA";
            // 
            // colKEFIL_OLAN_CARI_ADI
            // 
            resources.ApplyResources(this.colKEFIL_OLAN_CARI_ADI, "colKEFIL_OLAN_CARI_ADI");
            this.colKEFIL_OLAN_CARI_ADI.ColumnEdit = this.rLueCariID;
            this.colKEFIL_OLAN_CARI_ADI.FieldName = "KEFIL_OLAN_CARI_ID";
            this.colKEFIL_OLAN_CARI_ADI.Name = "colKEFIL_OLAN_CARI_ADI";
            this.colKEFIL_OLAN_CARI_ADI.OptionsColumn.AllowEdit = false;
            this.colKEFIL_OLAN_CARI_ADI.OptionsColumn.ReadOnly = true;
            // 
            // colKEFALET_TARIHI
            // 
            resources.ApplyResources(this.colKEFALET_TARIHI, "colKEFALET_TARIHI");
            this.colKEFALET_TARIHI.ColumnEdit = this.tarih;
            this.colKEFALET_TARIHI.FieldName = "KEFALET_TARIHI";
            this.colKEFALET_TARIHI.Name = "colKEFALET_TARIHI";
            this.colKEFALET_TARIHI.OptionsColumn.AllowEdit = false;
            this.colKEFALET_TARIHI.OptionsColumn.ReadOnly = true;
            // 
            // colKEFALET_KAPSAMI
            // 
            resources.ApplyResources(this.colKEFALET_KAPSAMI, "colKEFALET_KAPSAMI");
            this.colKEFALET_KAPSAMI.ColumnEdit = this.rLueKefaletKapsamID;
            this.colKEFALET_KAPSAMI.FieldName = "KEFALET_KAPSAM_ID";
            this.colKEFALET_KAPSAMI.Name = "colKEFALET_KAPSAMI";
            this.colKEFALET_KAPSAMI.OptionsColumn.AllowEdit = false;
            this.colKEFALET_KAPSAMI.OptionsColumn.ReadOnly = true;
            // 
            // colKEFALET_MIKTAR_DOVIZ
            // 
            this.colKEFALET_MIKTAR_DOVIZ.ColumnEdit = this.rLueDovizID;
            resources.ApplyResources(this.colKEFALET_MIKTAR_DOVIZ, "colKEFALET_MIKTAR_DOVIZ");
            this.colKEFALET_MIKTAR_DOVIZ.FieldName = "KEFALET_MIKTAR_DOVIZ_ID";
            this.colKEFALET_MIKTAR_DOVIZ.Name = "colKEFALET_MIKTAR_DOVIZ";
            this.colKEFALET_MIKTAR_DOVIZ.OptionsColumn.AllowEdit = false;
            this.colKEFALET_MIKTAR_DOVIZ.OptionsColumn.ReadOnly = true;
            // 
            // colKEFALET_MIKTARI
            // 
            resources.ApplyResources(this.colKEFALET_MIKTARI, "colKEFALET_MIKTARI");
            this.colKEFALET_MIKTARI.ColumnEdit = this.tutar;
            this.colKEFALET_MIKTARI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colKEFALET_MIKTARI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKEFALET_MIKTARI.FieldName = "KEFALET_MIKTARI";
            this.colKEFALET_MIKTARI.Name = "colKEFALET_MIKTARI";
            this.colKEFALET_MIKTARI.OptionsColumn.AllowEdit = false;
            this.colKEFALET_MIKTARI.OptionsColumn.ReadOnly = true;
            // 
            // colACIKLAMA4
            // 
            resources.ApplyResources(this.colACIKLAMA4, "colACIKLAMA4");
            this.colACIKLAMA4.ColumnEdit = this.aciklama;
            this.colACIKLAMA4.FieldName = "ACIKLAMA";
            this.colACIKLAMA4.Name = "colACIKLAMA4";
            this.colACIKLAMA4.OptionsColumn.AllowEdit = false;
            this.colACIKLAMA4.OptionsColumn.ReadOnly = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.vGKafalet);
            this.panelControl1.Controls.Add(this.dnKefalet);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // vGKafalet
            // 
            resources.ApplyResources(this.vGKafalet, "vGKafalet");
            this.vGKafalet.ExternalRepository = this.MyRepository;
            this.vGKafalet.Name = "vGKafalet";
            this.vGKafalet.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowKEFIL_OLAN_CARI_ID,
            this.rowKEFALET_TARIHI,
            this.rowKEFALET_KAPSAM_ID,
            this.mRowKefMiktar,
            this.rowACIKLAMA});
            // 
            // rowKEFIL_OLAN_CARI_ID
            // 
            resources.ApplyResources(this.rowKEFIL_OLAN_CARI_ID, "rowKEFIL_OLAN_CARI_ID");
            this.rowKEFIL_OLAN_CARI_ID.Properties.Caption = resources.GetString("rowKEFIL_OLAN_CARI_ID.Properties.Caption");
            this.rowKEFIL_OLAN_CARI_ID.Properties.FieldName = "KEFIL_OLAN_CARI_ID";
            this.rowKEFIL_OLAN_CARI_ID.Properties.RowEdit = this.rLueCariID;
            // 
            // rowKEFALET_TARIHI
            // 
            resources.ApplyResources(this.rowKEFALET_TARIHI, "rowKEFALET_TARIHI");
            this.rowKEFALET_TARIHI.Properties.Caption = resources.GetString("rowKEFALET_TARIHI.Properties.Caption");
            this.rowKEFALET_TARIHI.Properties.FieldName = "KEFALET_TARIHI";
            this.rowKEFALET_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowKEFALET_KAPSAM_ID
            // 
            resources.ApplyResources(this.rowKEFALET_KAPSAM_ID, "rowKEFALET_KAPSAM_ID");
            this.rowKEFALET_KAPSAM_ID.Properties.Caption = resources.GetString("rowKEFALET_KAPSAM_ID.Properties.Caption");
            this.rowKEFALET_KAPSAM_ID.Properties.FieldName = "KEFALET_KAPSAM_ID";
            this.rowKEFALET_KAPSAM_ID.Properties.RowEdit = this.rLueKefaletKapsamID;
            // 
            // mRowKefMiktar
            // 
            resources.ApplyResources(this.mRowKefMiktar, "mRowKefMiktar");
            this.mRowKefMiktar.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties1,
            this.multiEditorRowProperties2});
            // 
            // rowACIKLAMA
            // 
            resources.ApplyResources(this.rowACIKLAMA, "rowACIKLAMA");
            this.rowACIKLAMA.Properties.Caption = resources.GetString("rowACIKLAMA.Properties.Caption");
            this.rowACIKLAMA.Properties.FieldName = "ACIKLAMA";
            this.rowACIKLAMA.Properties.RowEdit = this.aciklama;
            // 
            // dnKefalet
            // 
            this.dnKefalet.Buttons.CancelEdit.Visible = false;
            this.dnKefalet.Buttons.NextPage.Visible = false;
            this.dnKefalet.Buttons.PrevPage.Visible = false;
            resources.ApplyResources(this.dnKefalet, "dnKefalet");
            this.dnKefalet.MyChartControl = null;
            this.dnKefalet.MyGridControl = this.gridKefaletBilgileri;
            this.dnKefalet.MyPivotGridControl = null;
            this.dnKefalet.MyVGridControl = this.vGKafalet;
            this.dnKefalet.Name = "dnKefalet";
            this.dnKefalet.SelectButtonVisible = false;
            // 
            // ucKefaletBilgileri
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridKefaletBilgileri);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucKefaletBilgileri";
            this.Load += new System.EventHandler(this.ucKefaletBilgileri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKefaletBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCariID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKefaletKapsamID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwKefaletBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGKafalet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridKefaletBilgileri;
        private DevExpress.XtraGrid.Views.Grid.GridView gwKefaletBilgileri;
        private DevExpress.XtraGrid.Columns.GridColumn colKEFIL_OLAN_CARI_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn colKEFALET_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colKEFALET_KAPSAMI;
        private DevExpress.XtraGrid.Columns.GridColumn colKEFALET_MIKTAR_DOVIZ;
        private DevExpress.XtraGrid.Columns.GridColumn colKEFALET_MIKTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA4;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueCariID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueKefaletKapsamID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizID;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraVerticalGrid.VGridControl vGKafalet;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowKEFIL_OLAN_CARI_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowKEFALET_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowKEFALET_KAPSAM_ID;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow mRowKefMiktar;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowACIKLAMA;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dnKefalet;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit tarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit aciklama;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit tutar;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties1;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties2;
    }
}
