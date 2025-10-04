using AvukatProLib.Util;
namespace AdimAdimDavaKaydi.IcraTakipForms
{
    partial class ucIcraTarafBilgileri
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
            if (AuthHelperBase.loadedControlList.Contains(this.Name)) AuthHelperBase.loadedControlList.Remove(this.Name);
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.gvBorcluTarafVekil = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rbtnBorcluTemsilEkle = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBorcluVekil = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueTemsilSekli = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcBorclu = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.persistentRepository1 = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueTarafCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueAlacakliTarafKodu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueAlacakliSifat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueBorcluTarafKodu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueBorcluSifat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSorumluTaraf = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gwBorclu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorcluAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBorcluTemsil = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvAlacakliTarafVekil = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTEMSIL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rbtnTemsilEkle = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colAVUKAT_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAlacakliAvukat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTEMSIL_SEKLI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAlacakliTemsilSekli = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcAlacak = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gwAlacak = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueAlacakliTemsil = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnDuzenle = new DevExpress.XtraEditors.SimpleButton();
            this.gcIletisimBilgileri = new DevExpress.XtraGrid.GridControl();
            this.lvIletisimBilgileri = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.lvcAdres = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rlueAdres = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcIlce = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcIl = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_4 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcTel1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_6 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcTel2 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_7 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcCepTel1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_10 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcEmail1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_12 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcVergiDairesi = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_14 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcVergiNo = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_15 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcTcKimlikNo = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcBabaAdi = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcDogumTarihi = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_5 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcAnneKizlikSoyadi = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_8 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcMusteriNo = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_9 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.rlueIlce = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueIl = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcSorumlu = new DevExpress.XtraGrid.GridControl();
            this.gwSorumluAvk = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgIletisimBilgileri = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciIletisimBilgileri = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSorumlu = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBorclu = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.bndGorusme = new System.Windows.Forms.BindingSource(this.components);
            this.txtOdemeEtk = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBorcluTarafVekil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnBorcluTemsilEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBorcluVekil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTemsilSekli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBorclu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakliTarafKodu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakliSifat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBorcluTarafKodu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBorcluSifat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorumluTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwBorclu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBorcluTemsil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAlacakliTarafVekil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTemsilEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakliAvukat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakliTemsilSekli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwAlacak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAlacakliTemsil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcIletisimBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvIletisimBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueIlce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueIl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSorumlu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSorumluAvk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIletisimBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIletisimBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSorumlu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBorclu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndGorusme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeEtk.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gvBorcluTarafVekil
            // 
            this.gvBorcluTarafVekil.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gvBorcluTarafVekil.GridControl = this.gcBorclu;
            this.gvBorcluTarafVekil.Name = "gvBorcluTarafVekil";
            this.gvBorcluTarafVekil.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gvBorcluTarafVekil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvBorcluTarafVekil.OptionsView.ShowGroupPanel = false;
            this.gvBorcluTarafVekil.ViewCaption = "Taraf Vekilleri";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Temsil";
            this.gridColumn9.ColumnEdit = this.rbtnBorcluTemsilEkle;
            this.gridColumn9.FieldName = "TEMSIL_ID";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            // 
            // rbtnBorcluTemsilEkle
            // 
            this.rbtnBorcluTemsilEkle.AllowFocused = false;
            this.rbtnBorcluTemsilEkle.AutoHeight = false;
            this.rbtnBorcluTemsilEkle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rbtnBorcluTemsilEkle.Name = "rbtnBorcluTemsilEkle";
            this.rbtnBorcluTemsilEkle.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rbtnBorcluTemsilEkle.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rbtnBorcluTemsilEkle_ButtonClick);
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Vekil";
            this.gridColumn10.ColumnEdit = this.rLueBorcluVekil;
            this.gridColumn10.FieldName = "AVUKAT_CARI_ID";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            // 
            // rLueBorcluVekil
            // 
            this.rLueBorcluVekil.AutoHeight = false;
            this.rLueBorcluVekil.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBorcluVekil.Name = "rLueBorcluVekil";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Þekil";
            this.gridColumn11.ColumnEdit = this.rLueTemsilSekli;
            this.gridColumn11.FieldName = "TEMSIL_SEKLI_ID";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            // 
            // rLueTemsilSekli
            // 
            this.rLueTemsilSekli.AutoHeight = false;
            this.rLueTemsilSekli.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTemsilSekli.Name = "rLueTemsilSekli";
            // 
            // gcBorclu
            // 
            this.gcBorclu.CustomButtonlarGorunmesin = false;
            this.gcBorclu.DoNotExtendEmbedNavigator = false;
            this.gcBorclu.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcBorclu.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcBorclu.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gcBorclu.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gcBorclu.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gcBorclu.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gcBorclu.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcBorclu.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gcBorclu_EmbeddedNavigator_ButtonClick);
            this.gcBorclu.ExternalRepository = this.persistentRepository1;
            this.gcBorclu.FilterText = null;
            this.gcBorclu.FilterValue = null;
            this.gcBorclu.GridlerDuzenlenebilir = true;
            this.gcBorclu.GridsFilterControl = null;
            gridLevelNode1.LevelTemplate = this.gvBorcluTarafVekil;
            gridLevelNode1.RelationName = "AV001_TI_BIL_FOY_TARAF_VEKILCollection";
            this.gcBorclu.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcBorclu.Location = new System.Drawing.Point(12, 276);
            this.gcBorclu.MainView = this.gwBorclu;
            this.gcBorclu.MyGridStyle = null;
            this.gcBorclu.Name = "gcBorclu";
            this.gcBorclu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueBorcluTemsil,
            this.rLueBorcluVekil,
            this.rLueTemsilSekli,
            this.rbtnBorcluTemsilEkle});
            this.gcBorclu.ShowOnlyPredefinedDetails = true;
            this.gcBorclu.ShowRowNumbers = false;
            this.gcBorclu.SilmeKaldirilsin = false;
            this.gcBorclu.Size = new System.Drawing.Size(222, 128);
            this.gcBorclu.TabIndex = 8;
            this.gcBorclu.TemizleKaldirGorunsunmu = false;
            this.gcBorclu.UniqueId = "f06acd3e-c368-46af-b5bd-2f32a63213a2";
            this.gcBorclu.UseEmbeddedNavigator = true;
            this.gcBorclu.UseHyperDragDrop = false;
            this.gcBorclu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwBorclu,
            this.gvBorcluTarafVekil});
            // 
            // persistentRepository1
            // 
            this.persistentRepository1.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueTarafCari,
            this.rLueAlacakliTarafKodu,
            this.rLueAlacakliSifat,
            this.rLueBorcluTarafKodu,
            this.rLueBorcluSifat,
            this.rLueSorumluTaraf});
            // 
            // rLueTarafCari
            // 
            this.rLueTarafCari.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rLueTarafCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Yeni Þahýs", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "Yeni", null, true)});
            this.rLueTarafCari.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.rLueTarafCari.Name = "rLueTarafCari";
            this.rLueTarafCari.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rLueTarafCari.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rLueTarafCari_ButtonClick);
            // 
            // rLueAlacakliTarafKodu
            // 
            this.rLueAlacakliTarafKodu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAlacakliTarafKodu.Name = "rLueAlacakliTarafKodu";
            // 
            // rLueAlacakliSifat
            // 
            this.rLueAlacakliSifat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAlacakliSifat.Name = "rLueAlacakliSifat";
            // 
            // rLueBorcluTarafKodu
            // 
            this.rLueBorcluTarafKodu.AutoHeight = false;
            this.rLueBorcluTarafKodu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBorcluTarafKodu.Name = "rLueBorcluTarafKodu";
            // 
            // rLueBorcluSifat
            // 
            this.rLueBorcluSifat.AutoHeight = false;
            this.rLueBorcluSifat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBorcluSifat.Name = "rLueBorcluSifat";
            // 
            // rLueSorumluTaraf
            // 
            this.rLueSorumluTaraf.AutoHeight = false;
            this.rLueSorumluTaraf.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSorumluTaraf.Name = "rLueSorumluTaraf";
            // 
            // gwBorclu
            // 
            this.gwBorclu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.colBorcluAdi});
            this.gwBorclu.GridControl = this.gcBorclu;
            this.gwBorclu.IndicatorWidth = 20;
            this.gwBorclu.Name = "gwBorclu";
            this.gwBorclu.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwBorclu.OptionsDetail.AutoZoomDetail = true;
            this.gwBorclu.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gwBorclu.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gwBorclu.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gwBorclu.OptionsView.ShowGroupPanel = false;
            this.gwBorclu.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gwBorclu_RowClick);
            this.gwBorclu.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gwBorclu_RowStyle);
            this.gwBorclu.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gwBorclu_FocusedRowChanged);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "TK";
            this.gridColumn4.ColumnEdit = this.rLueBorcluTarafKodu;
            this.gridColumn4.FieldName = "TARAF_KODU";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 43;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Sýfatý";
            this.gridColumn5.ColumnEdit = this.rLueBorcluSifat;
            this.gridColumn5.FieldName = "TARAF_SIFAT_ID";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 66;
            // 
            // colBorcluAdi
            // 
            this.colBorcluAdi.Caption = "Borçlu Adý";
            this.colBorcluAdi.ColumnEdit = this.rLueTarafCari;
            this.colBorcluAdi.FieldName = "CARI_ID";
            this.colBorcluAdi.Name = "colBorcluAdi";
            this.colBorcluAdi.OptionsColumn.AllowEdit = false;
            this.colBorcluAdi.OptionsColumn.ReadOnly = true;
            this.colBorcluAdi.Visible = true;
            this.colBorcluAdi.VisibleIndex = 2;
            this.colBorcluAdi.Width = 176;
            // 
            // rLueBorcluTemsil
            // 
            this.rLueBorcluTemsil.AutoHeight = false;
            this.rLueBorcluTemsil.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBorcluTemsil.Name = "rLueBorcluTemsil";
            // 
            // gvAlacakliTarafVekil
            // 
            this.gvAlacakliTarafVekil.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTEMSIL_ID,
            this.colAVUKAT_CARI_ID,
            this.colTEMSIL_SEKLI_ID});
            this.gvAlacakliTarafVekil.GridControl = this.gcAlacak;
            this.gvAlacakliTarafVekil.Name = "gvAlacakliTarafVekil";
            this.gvAlacakliTarafVekil.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gvAlacakliTarafVekil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvAlacakliTarafVekil.OptionsView.ShowGroupPanel = false;
            this.gvAlacakliTarafVekil.ViewCaption = "Taraf Vekilleri";
            // 
            // colTEMSIL_ID
            // 
            this.colTEMSIL_ID.Caption = "Temsil";
            this.colTEMSIL_ID.ColumnEdit = this.rbtnTemsilEkle;
            this.colTEMSIL_ID.FieldName = "TEMSIL_ID";
            this.colTEMSIL_ID.Name = "colTEMSIL_ID";
            this.colTEMSIL_ID.Visible = true;
            this.colTEMSIL_ID.VisibleIndex = 0;
            // 
            // rbtnTemsilEkle
            // 
            this.rbtnTemsilEkle.AutoHeight = false;
            this.rbtnTemsilEkle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rbtnTemsilEkle.Name = "rbtnTemsilEkle";
            this.rbtnTemsilEkle.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rbtnTemsilEkle.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rbtnTemsilEkle_ButtonClick);
            // 
            // colAVUKAT_CARI_ID
            // 
            this.colAVUKAT_CARI_ID.Caption = "Vekil";
            this.colAVUKAT_CARI_ID.ColumnEdit = this.rLueAlacakliAvukat;
            this.colAVUKAT_CARI_ID.FieldName = "AVUKAT_CARI_ID";
            this.colAVUKAT_CARI_ID.Name = "colAVUKAT_CARI_ID";
            this.colAVUKAT_CARI_ID.Visible = true;
            this.colAVUKAT_CARI_ID.VisibleIndex = 1;
            // 
            // rLueAlacakliAvukat
            // 
            this.rLueAlacakliAvukat.AutoHeight = false;
            this.rLueAlacakliAvukat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAlacakliAvukat.Name = "rLueAlacakliAvukat";
            // 
            // colTEMSIL_SEKLI_ID
            // 
            this.colTEMSIL_SEKLI_ID.Caption = "Þekil";
            this.colTEMSIL_SEKLI_ID.ColumnEdit = this.rLueAlacakliTemsilSekli;
            this.colTEMSIL_SEKLI_ID.FieldName = "TEMSIL_SEKLI_ID";
            this.colTEMSIL_SEKLI_ID.Name = "colTEMSIL_SEKLI_ID";
            this.colTEMSIL_SEKLI_ID.Visible = true;
            this.colTEMSIL_SEKLI_ID.VisibleIndex = 2;
            // 
            // rLueAlacakliTemsilSekli
            // 
            this.rLueAlacakliTemsilSekli.AutoHeight = false;
            this.rLueAlacakliTemsilSekli.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAlacakliTemsilSekli.Name = "rLueAlacakliTemsilSekli";
            // 
            // gcAlacak
            // 
            this.gcAlacak.CustomButtonlarGorunmesin = false;
            this.gcAlacak.DoNotExtendEmbedNavigator = true;
            this.gcAlacak.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcAlacak.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gcAlacak_EmbeddedNavigator_ButtonClick);
            this.gcAlacak.ExternalRepository = this.persistentRepository1;
            this.gcAlacak.FilterText = null;
            this.gcAlacak.FilterValue = null;
            this.gcAlacak.GridlerDuzenlenebilir = true;
            this.gcAlacak.GridsFilterControl = null;
            gridLevelNode2.LevelTemplate = this.gvAlacakliTarafVekil;
            gridLevelNode2.RelationName = "AV001_TI_BIL_FOY_TARAF_VEKILCollection";
            this.gcAlacak.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gcAlacak.Location = new System.Drawing.Point(12, 12);
            this.gcAlacak.MainView = this.gwAlacak;
            this.gcAlacak.MyGridStyle = null;
            this.gcAlacak.Name = "gcAlacak";
            this.gcAlacak.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueAlacakliTemsil,
            this.rLueAlacakliAvukat,
            this.rLueAlacakliTemsilSekli,
            this.rbtnTemsilEkle});
            this.gcAlacak.ShowOnlyPredefinedDetails = true;
            this.gcAlacak.ShowRowNumbers = false;
            this.gcAlacak.SilmeKaldirilsin = false;
            this.gcAlacak.Size = new System.Drawing.Size(222, 128);
            this.gcAlacak.TabIndex = 7;
            this.gcAlacak.TemizleKaldirGorunsunmu = false;
            this.gcAlacak.UniqueId = "b5b4f05f-9009-495b-801f-fb843a34cfec";
            this.gcAlacak.UseEmbeddedNavigator = true;
            this.gcAlacak.UseHyperDragDrop = false;
            this.gcAlacak.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwAlacak,
            this.gvAlacakliTarafVekil});
            // 
            // gwAlacak
            // 
            this.gwAlacak.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gwAlacak.GridControl = this.gcAlacak;
            this.gwAlacak.IndicatorWidth = 20;
            this.gwAlacak.Name = "gwAlacak";
            this.gwAlacak.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwAlacak.OptionsDetail.AutoZoomDetail = true;
            this.gwAlacak.OptionsView.ShowGroupPanel = false;
            this.gwAlacak.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gwAlacak_RowClick);
            this.gwAlacak.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gwAlacak_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "TK";
            this.gridColumn1.ColumnEdit = this.rLueAlacakliTarafKodu;
            this.gridColumn1.FieldName = "TARAF_KODU";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 43;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Sýfatý";
            this.gridColumn2.ColumnEdit = this.rLueAlacakliSifat;
            this.gridColumn2.FieldName = "TARAF_SIFAT_ID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 66;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Alacaklý Adý";
            this.gridColumn3.ColumnEdit = this.rLueTarafCari;
            this.gridColumn3.FieldName = "CARI_ID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 176;
            // 
            // rlueAlacakliTemsil
            // 
            this.rlueAlacakliTemsil.AutoHeight = false;
            this.rlueAlacakliTemsil.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueAlacakliTemsil.Name = "rlueAlacakliTemsil";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnDuzenle);
            this.layoutControl1.Controls.Add(this.gcIletisimBilgileri);
            this.layoutControl1.Controls.Add(this.gcSorumlu);
            this.layoutControl1.Controls.Add(this.gcBorclu);
            this.layoutControl1.Controls.Add(this.gcAlacak);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup2;
            this.layoutControl1.Size = new System.Drawing.Size(246, 800);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(24, 751);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(198, 25);
            this.btnDuzenle.StyleController = this.layoutControl1;
            this.btnDuzenle.TabIndex = 11;
            this.btnDuzenle.Text = "Þahsýn Ýletiþim Bilgilerini Düzenle";
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // gcIletisimBilgileri
            // 
            this.gcIletisimBilgileri.Location = new System.Drawing.Point(24, 439);
            this.gcIletisimBilgileri.MainView = this.lvIletisimBilgileri;
            this.gcIletisimBilgileri.Name = "gcIletisimBilgileri";
            this.gcIletisimBilgileri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueIlce,
            this.rlueIl,
            this.rlueAdres});
            this.gcIletisimBilgileri.Size = new System.Drawing.Size(198, 308);
            this.gcIletisimBilgileri.TabIndex = 10;
            this.gcIletisimBilgileri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.lvIletisimBilgileri});
            // 
            // lvIletisimBilgileri
            // 
            this.lvIletisimBilgileri.CardMinSize = new System.Drawing.Size(260, 200);
            this.lvIletisimBilgileri.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.lvcAdres,
            this.lvcIlce,
            this.lvcIl,
            this.lvcTel1,
            this.lvcTel2,
            this.lvcCepTel1,
            this.lvcEmail1,
            this.lvcVergiDairesi,
            this.lvcVergiNo,
            this.lvcTcKimlikNo,
            this.lvcBabaAdi,
            this.lvcDogumTarihi,
            this.lvcAnneKizlikSoyadi,
            this.lvcMusteriNo});
            this.lvIletisimBilgileri.GridControl = this.gcIletisimBilgileri;
            this.lvIletisimBilgileri.Name = "lvIletisimBilgileri";
            this.lvIletisimBilgileri.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.lvIletisimBilgileri.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.lvIletisimBilgileri.OptionsBehavior.Editable = false;
            this.lvIletisimBilgileri.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.lvIletisimBilgileri.OptionsLayout.Columns.AddNewColumns = false;
            this.lvIletisimBilgileri.OptionsSingleRecordMode.CardAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near;
            this.lvIletisimBilgileri.OptionsSingleRecordMode.StretchCardToViewHeight = true;
            this.lvIletisimBilgileri.OptionsSingleRecordMode.StretchCardToViewWidth = true;
            this.lvIletisimBilgileri.OptionsView.CardsAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near;
            this.lvIletisimBilgileri.OptionsView.ShowCardCaption = false;
            this.lvIletisimBilgileri.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.lvIletisimBilgileri.OptionsView.ShowHeaderPanel = false;
            this.lvIletisimBilgileri.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
            this.lvIletisimBilgileri.TemplateCard = this.layoutViewCard1;
            // 
            // lvcAdres
            // 
            this.lvcAdres.Caption = "Adres";
            this.lvcAdres.ColumnEdit = this.rlueAdres;
            this.lvcAdres.FieldName = "ADRES";
            this.lvcAdres.LayoutViewField = this.layoutViewField_layoutViewColumn1;
            this.lvcAdres.Name = "lvcAdres";
            // 
            // rlueAdres
            // 
            this.rlueAdres.LinesCount = 2;
            this.rlueAdres.Name = "rlueAdres";
            // 
            // layoutViewField_layoutViewColumn1
            // 
            this.layoutViewField_layoutViewColumn1.EditorPreferredWidth = 195;
            this.layoutViewField_layoutViewColumn1.Location = new System.Drawing.Point(0, 60);
            this.layoutViewField_layoutViewColumn1.MaxSize = new System.Drawing.Size(0, 40);
            this.layoutViewField_layoutViewColumn1.MinSize = new System.Drawing.Size(85, 37);
            this.layoutViewField_layoutViewColumn1.Name = "layoutViewField_layoutViewColumn1";
            this.layoutViewField_layoutViewColumn1.Size = new System.Drawing.Size(260, 37);
            this.layoutViewField_layoutViewColumn1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_layoutViewColumn1.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1.TextToControlDistance = 5;
            // 
            // lvcIlce
            // 
            this.lvcIlce.Caption = "Ýlçe";
            this.lvcIlce.FieldName = "ILCE";
            this.lvcIlce.LayoutViewField = this.layoutViewField_layoutViewColumn1_3;
            this.lvcIlce.Name = "lvcIlce";
            // 
            // layoutViewField_layoutViewColumn1_3
            // 
            this.layoutViewField_layoutViewColumn1_3.EditorPreferredWidth = 96;
            this.layoutViewField_layoutViewColumn1_3.Location = new System.Drawing.Point(160, 97);
            this.layoutViewField_layoutViewColumn1_3.Name = "layoutViewField_layoutViewColumn1_3";
            this.layoutViewField_layoutViewColumn1_3.Size = new System.Drawing.Size(100, 20);
            this.layoutViewField_layoutViewColumn1_3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_layoutViewColumn1_3.TextToControlDistance = 0;
            this.layoutViewField_layoutViewColumn1_3.TextVisible = false;
            // 
            // lvcIl
            // 
            this.lvcIl.Caption = "Ýl - Ýlçe";
            this.lvcIl.FieldName = "IL";
            this.lvcIl.LayoutViewField = this.layoutViewField_layoutViewColumn1_4;
            this.lvcIl.Name = "lvcIl";
            // 
            // layoutViewField_layoutViewColumn1_4
            // 
            this.layoutViewField_layoutViewColumn1_4.EditorPreferredWidth = 95;
            this.layoutViewField_layoutViewColumn1_4.Location = new System.Drawing.Point(0, 97);
            this.layoutViewField_layoutViewColumn1_4.Name = "layoutViewField_layoutViewColumn1_4";
            this.layoutViewField_layoutViewColumn1_4.Size = new System.Drawing.Size(160, 20);
            this.layoutViewField_layoutViewColumn1_4.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_4.TextToControlDistance = 5;
            // 
            // lvcTel1
            // 
            this.lvcTel1.Caption = "Tel";
            this.lvcTel1.FieldName = "TEL_1";
            this.lvcTel1.LayoutViewField = this.layoutViewField_layoutViewColumn1_6;
            this.lvcTel1.Name = "lvcTel1";
            // 
            // layoutViewField_layoutViewColumn1_6
            // 
            this.layoutViewField_layoutViewColumn1_6.EditorPreferredWidth = 95;
            this.layoutViewField_layoutViewColumn1_6.Location = new System.Drawing.Point(0, 117);
            this.layoutViewField_layoutViewColumn1_6.Name = "layoutViewField_layoutViewColumn1_6";
            this.layoutViewField_layoutViewColumn1_6.Size = new System.Drawing.Size(160, 20);
            this.layoutViewField_layoutViewColumn1_6.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_6.TextToControlDistance = 5;
            // 
            // lvcTel2
            // 
            this.lvcTel2.Caption = "Tel 2";
            this.lvcTel2.FieldName = "TEL_2";
            this.lvcTel2.LayoutViewField = this.layoutViewField_layoutViewColumn1_7;
            this.lvcTel2.Name = "lvcTel2";
            // 
            // layoutViewField_layoutViewColumn1_7
            // 
            this.layoutViewField_layoutViewColumn1_7.EditorPreferredWidth = 96;
            this.layoutViewField_layoutViewColumn1_7.Location = new System.Drawing.Point(160, 117);
            this.layoutViewField_layoutViewColumn1_7.Name = "layoutViewField_layoutViewColumn1_7";
            this.layoutViewField_layoutViewColumn1_7.Size = new System.Drawing.Size(100, 20);
            this.layoutViewField_layoutViewColumn1_7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_layoutViewColumn1_7.TextToControlDistance = 0;
            this.layoutViewField_layoutViewColumn1_7.TextVisible = false;
            // 
            // lvcCepTel1
            // 
            this.lvcCepTel1.Caption = "Cep";
            this.lvcCepTel1.FieldName = "CEP_TEL";
            this.lvcCepTel1.LayoutViewField = this.layoutViewField_layoutViewColumn1_10;
            this.lvcCepTel1.Name = "lvcCepTel1";
            // 
            // layoutViewField_layoutViewColumn1_10
            // 
            this.layoutViewField_layoutViewColumn1_10.EditorPreferredWidth = 195;
            this.layoutViewField_layoutViewColumn1_10.Location = new System.Drawing.Point(0, 137);
            this.layoutViewField_layoutViewColumn1_10.Name = "layoutViewField_layoutViewColumn1_10";
            this.layoutViewField_layoutViewColumn1_10.Size = new System.Drawing.Size(260, 20);
            this.layoutViewField_layoutViewColumn1_10.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_10.TextToControlDistance = 5;
            // 
            // lvcEmail1
            // 
            this.lvcEmail1.Caption = "Email";
            this.lvcEmail1.FieldName = "EMAIL_1";
            this.lvcEmail1.LayoutViewField = this.layoutViewField_layoutViewColumn1_12;
            this.lvcEmail1.Name = "lvcEmail1";
            // 
            // layoutViewField_layoutViewColumn1_12
            // 
            this.layoutViewField_layoutViewColumn1_12.EditorPreferredWidth = 195;
            this.layoutViewField_layoutViewColumn1_12.Location = new System.Drawing.Point(0, 157);
            this.layoutViewField_layoutViewColumn1_12.Name = "layoutViewField_layoutViewColumn1_12";
            this.layoutViewField_layoutViewColumn1_12.Size = new System.Drawing.Size(260, 20);
            this.layoutViewField_layoutViewColumn1_12.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_12.TextToControlDistance = 5;
            // 
            // lvcVergiDairesi
            // 
            this.lvcVergiDairesi.Caption = "V. No";
            this.lvcVergiDairesi.FieldName = "VERGI_DAIRESI";
            this.lvcVergiDairesi.LayoutViewField = this.layoutViewField_layoutViewColumn1_14;
            this.lvcVergiDairesi.Name = "lvcVergiDairesi";
            // 
            // layoutViewField_layoutViewColumn1_14
            // 
            this.layoutViewField_layoutViewColumn1_14.EditorPreferredWidth = 95;
            this.layoutViewField_layoutViewColumn1_14.Location = new System.Drawing.Point(0, 177);
            this.layoutViewField_layoutViewColumn1_14.Name = "layoutViewField_layoutViewColumn1_14";
            this.layoutViewField_layoutViewColumn1_14.Size = new System.Drawing.Size(160, 20);
            this.layoutViewField_layoutViewColumn1_14.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_14.TextToControlDistance = 5;
            // 
            // lvcVergiNo
            // 
            this.lvcVergiNo.Caption = "V. No";
            this.lvcVergiNo.FieldName = "VERGI_NO";
            this.lvcVergiNo.LayoutViewField = this.layoutViewField_layoutViewColumn1_15;
            this.lvcVergiNo.Name = "lvcVergiNo";
            // 
            // layoutViewField_layoutViewColumn1_15
            // 
            this.layoutViewField_layoutViewColumn1_15.EditorPreferredWidth = 96;
            this.layoutViewField_layoutViewColumn1_15.Location = new System.Drawing.Point(160, 177);
            this.layoutViewField_layoutViewColumn1_15.Name = "layoutViewField_layoutViewColumn1_15";
            this.layoutViewField_layoutViewColumn1_15.Size = new System.Drawing.Size(100, 20);
            this.layoutViewField_layoutViewColumn1_15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_layoutViewColumn1_15.TextToControlDistance = 0;
            this.layoutViewField_layoutViewColumn1_15.TextVisible = false;
            // 
            // lvcTcKimlikNo
            // 
            this.lvcTcKimlikNo.Caption = "Tc. No";
            this.lvcTcKimlikNo.FieldName = "TC_KIMLIK_NO";
            this.lvcTcKimlikNo.LayoutViewField = this.layoutViewField_layoutViewColumn1_1;
            this.lvcTcKimlikNo.Name = "lvcTcKimlikNo";
            // 
            // layoutViewField_layoutViewColumn1_1
            // 
            this.layoutViewField_layoutViewColumn1_1.EditorPreferredWidth = 69;
            this.layoutViewField_layoutViewColumn1_1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1_1.Name = "layoutViewField_layoutViewColumn1_1";
            this.layoutViewField_layoutViewColumn1_1.Size = new System.Drawing.Size(134, 20);
            this.layoutViewField_layoutViewColumn1_1.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_1.TextToControlDistance = 5;
            // 
            // lvcBabaAdi
            // 
            this.lvcBabaAdi.Caption = "B. Adi";
            this.lvcBabaAdi.FieldName = "BABA_ADI";
            this.lvcBabaAdi.LayoutViewField = this.layoutViewField_layoutViewColumn1_2;
            this.lvcBabaAdi.Name = "lvcBabaAdi";
            // 
            // layoutViewField_layoutViewColumn1_2
            // 
            this.layoutViewField_layoutViewColumn1_2.EditorPreferredWidth = 97;
            this.layoutViewField_layoutViewColumn1_2.Location = new System.Drawing.Point(0, 20);
            this.layoutViewField_layoutViewColumn1_2.Name = "layoutViewField_layoutViewColumn1_2";
            this.layoutViewField_layoutViewColumn1_2.Size = new System.Drawing.Size(162, 20);
            this.layoutViewField_layoutViewColumn1_2.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_2.TextToControlDistance = 5;
            // 
            // lvcDogumTarihi
            // 
            this.lvcDogumTarihi.Caption = "D. T.";
            this.lvcDogumTarihi.FieldName = "DOGUM_TARIHI";
            this.lvcDogumTarihi.LayoutViewField = this.layoutViewField_layoutViewColumn1_5;
            this.lvcDogumTarihi.Name = "lvcDogumTarihi";
            // 
            // layoutViewField_layoutViewColumn1_5
            // 
            this.layoutViewField_layoutViewColumn1_5.EditorPreferredWidth = 61;
            this.layoutViewField_layoutViewColumn1_5.Location = new System.Drawing.Point(162, 20);
            this.layoutViewField_layoutViewColumn1_5.Name = "layoutViewField_layoutViewColumn1_5";
            this.layoutViewField_layoutViewColumn1_5.Size = new System.Drawing.Size(98, 20);
            this.layoutViewField_layoutViewColumn1_5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutViewField_layoutViewColumn1_5.TextSize = new System.Drawing.Size(28, 13);
            this.layoutViewField_layoutViewColumn1_5.TextToControlDistance = 5;
            // 
            // lvcAnneKizlikSoyadi
            // 
            this.lvcAnneKizlikSoyadi.Caption = "Kiz. Soyadý";
            this.lvcAnneKizlikSoyadi.FieldName = "ANNE_KIZLIK_SOYADI";
            this.lvcAnneKizlikSoyadi.LayoutViewField = this.layoutViewField_layoutViewColumn1_8;
            this.lvcAnneKizlikSoyadi.Name = "lvcAnneKizlikSoyadi";
            // 
            // layoutViewField_layoutViewColumn1_8
            // 
            this.layoutViewField_layoutViewColumn1_8.EditorPreferredWidth = 195;
            this.layoutViewField_layoutViewColumn1_8.Location = new System.Drawing.Point(0, 40);
            this.layoutViewField_layoutViewColumn1_8.Name = "layoutViewField_layoutViewColumn1_8";
            this.layoutViewField_layoutViewColumn1_8.Size = new System.Drawing.Size(260, 20);
            this.layoutViewField_layoutViewColumn1_8.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_8.TextToControlDistance = 5;
            // 
            // lvcMusteriNo
            // 
            this.lvcMusteriNo.Caption = "Mus No";
            this.lvcMusteriNo.FieldName = "MUSTERI_NO";
            this.lvcMusteriNo.LayoutViewField = this.layoutViewField_layoutViewColumn1_9;
            this.lvcMusteriNo.Name = "lvcMusteriNo";
            // 
            // layoutViewField_layoutViewColumn1_9
            // 
            this.layoutViewField_layoutViewColumn1_9.EditorPreferredWidth = 61;
            this.layoutViewField_layoutViewColumn1_9.Location = new System.Drawing.Point(134, 0);
            this.layoutViewField_layoutViewColumn1_9.Name = "layoutViewField_layoutViewColumn1_9";
            this.layoutViewField_layoutViewColumn1_9.Size = new System.Drawing.Size(126, 20);
            this.layoutViewField_layoutViewColumn1_9.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_9.TextToControlDistance = 5;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.AppearanceGroup.BackColor = System.Drawing.Color.Khaki;
            this.layoutViewCard1.AppearanceGroup.Options.UseBackColor = true;
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.GroupBordersVisible = false;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn1,
            this.layoutViewField_layoutViewColumn1_4,
            this.layoutViewField_layoutViewColumn1_6,
            this.layoutViewField_layoutViewColumn1_10,
            this.layoutViewField_layoutViewColumn1_14,
            this.layoutViewField_layoutViewColumn1_7,
            this.layoutViewField_layoutViewColumn1_3,
            this.layoutViewField_layoutViewColumn1_2,
            this.layoutViewField_layoutViewColumn1_5,
            this.layoutViewField_layoutViewColumn1_8,
            this.layoutViewField_layoutViewColumn1_15,
            this.layoutViewField_layoutViewColumn1_12,
            this.layoutViewField_layoutViewColumn1_1,
            this.layoutViewField_layoutViewColumn1_9});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 5;
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // rlueIlce
            // 
            this.rlueIlce.AutoHeight = false;
            this.rlueIlce.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueIlce.Name = "rlueIlce";
            // 
            // rlueIl
            // 
            this.rlueIl.AutoHeight = false;
            this.rlueIl.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueIl.Name = "rlueIl";
            // 
            // gcSorumlu
            // 
            this.gcSorumlu.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcSorumlu.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcSorumlu.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gcSorumlu.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gcSorumlu.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gcSorumlu.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gcSorumlu.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcSorumlu.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(7, 7, true, true, "Sil", "KaydiSil")});
            this.gcSorumlu.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gcSorumlu_EmbeddedNavigator_ButtonClick);
            this.gcSorumlu.ExternalRepository = this.persistentRepository1;
            this.gcSorumlu.Location = new System.Drawing.Point(12, 144);
            this.gcSorumlu.MainView = this.gwSorumluAvk;
            this.gcSorumlu.Name = "gcSorumlu";
            this.gcSorumlu.Size = new System.Drawing.Size(222, 128);
            this.gcSorumlu.TabIndex = 9;
            this.gcSorumlu.UseEmbeddedNavigator = true;
            this.gcSorumlu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwSorumluAvk});
            // 
            // gwSorumluAvk
            // 
            this.gwSorumluAvk.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8});
            this.gwSorumluAvk.GridControl = this.gcSorumlu;
            this.gwSorumluAvk.Name = "gwSorumluAvk";
            this.gwSorumluAvk.OptionsView.ShowDetailButtons = false;
            this.gwSorumluAvk.OptionsView.ShowGroupPanel = false;
            this.gwSorumluAvk.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gwSorumluAvk_RowClick);
            this.gwSorumluAvk.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gwSorumluAvk_FocusedRowChanged);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Sorumlu Avukat";
            this.gridColumn7.ColumnEdit = this.rLueSorumluTaraf;
            this.gridColumn7.FieldName = "SORUMLU_AVUKAT_CARI_ID";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 242;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Ýzleyen";
            this.gridColumn8.FieldName = "YETKILI_MI";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Root";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgIletisimBilgileri,
            this.layoutControlItem1,
            this.lciSorumlu,
            this.lciBorclu});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Size = new System.Drawing.Size(246, 800);
            this.layoutControlGroup2.Text = "Root";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // lcgIletisimBilgileri
            // 
            this.lcgIletisimBilgileri.CustomizationFormText = "Ýletiþim Bilgileri";
            this.lcgIletisimBilgileri.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciIletisimBilgileri,
            this.layoutControlItem2});
            this.lcgIletisimBilgileri.Location = new System.Drawing.Point(0, 396);
            this.lcgIletisimBilgileri.Name = "lcgIletisimBilgileri";
            this.lcgIletisimBilgileri.Size = new System.Drawing.Size(226, 384);
            this.lcgIletisimBilgileri.Text = "Ýletiþim Bilgileri";
            // 
            // lciIletisimBilgileri
            // 
            this.lciIletisimBilgileri.Control = this.gcIletisimBilgileri;
            this.lciIletisimBilgileri.CustomizationFormText = "lciIletisimBilgileri";
            this.lciIletisimBilgileri.Location = new System.Drawing.Point(0, 0);
            this.lciIletisimBilgileri.Name = "lciIletisimBilgileri";
            this.lciIletisimBilgileri.Size = new System.Drawing.Size(202, 312);
            this.lciIletisimBilgileri.Text = "lciIletisimBilgileri";
            this.lciIletisimBilgileri.TextSize = new System.Drawing.Size(0, 0);
            this.lciIletisimBilgileri.TextToControlDistance = 0;
            this.lciIletisimBilgileri.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnDuzenle;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 312);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(82, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(202, 29);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcAlacak;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(226, 132);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // lciSorumlu
            // 
            this.lciSorumlu.Control = this.gcSorumlu;
            this.lciSorumlu.CustomizationFormText = "layoutControlItem85";
            this.lciSorumlu.Location = new System.Drawing.Point(0, 132);
            this.lciSorumlu.Name = "lciSorumlu";
            this.lciSorumlu.Size = new System.Drawing.Size(226, 132);
            this.lciSorumlu.Text = "lciSorumlu";
            this.lciSorumlu.TextSize = new System.Drawing.Size(0, 0);
            this.lciSorumlu.TextToControlDistance = 0;
            this.lciSorumlu.TextVisible = false;
            // 
            // lciBorclu
            // 
            this.lciBorclu.Control = this.gcBorclu;
            this.lciBorclu.CustomizationFormText = "layoutControlItem4";
            this.lciBorclu.Location = new System.Drawing.Point(0, 264);
            this.lciBorclu.Name = "lciBorclu";
            this.lciBorclu.Size = new System.Drawing.Size(226, 132);
            this.lciBorclu.Text = "lciBorclu";
            this.lciBorclu.TextSize = new System.Drawing.Size(0, 0);
            this.lciBorclu.TextToControlDistance = 0;
            this.lciBorclu.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(50, 26);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            // 
            // bndGorusme
            // 
            this.bndGorusme.DataSource = typeof(AvukatProLib2.Entities.AV001_TDI_BIL_GORUSME);
            // 
            // txtOdemeEtk
            // 
            this.txtOdemeEtk.Location = new System.Drawing.Point(342, 256);
            this.txtOdemeEtk.Name = "txtOdemeEtk";
            this.txtOdemeEtk.Properties.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.txtOdemeEtk.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtOdemeEtk.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtOdemeEtk.Properties.Appearance.Options.UseBackColor = true;
            this.txtOdemeEtk.Properties.Appearance.Options.UseFont = true;
            this.txtOdemeEtk.Properties.Appearance.Options.UseForeColor = true;
            this.txtOdemeEtk.Properties.ReadOnly = true;
            this.txtOdemeEtk.Size = new System.Drawing.Size(106, 20);
            this.txtOdemeEtk.TabIndex = 249;
            // 
            // ucIcraTarafBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.txtOdemeEtk);
            this.Name = "ucIcraTarafBilgileri";
            this.Size = new System.Drawing.Size(246, 800);
            ((System.ComponentModel.ISupportInitialize)(this.gvBorcluTarafVekil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnBorcluTemsilEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBorcluVekil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTemsilSekli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBorclu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakliTarafKodu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakliSifat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBorcluTarafKodu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBorcluSifat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorumluTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwBorclu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBorcluTemsil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAlacakliTarafVekil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTemsilEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakliAvukat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakliTemsilSekli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwAlacak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAlacakliTemsil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcIletisimBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvIletisimBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueIlce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueIl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSorumlu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSorumluAvk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIletisimBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIletisimBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSorumlu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBorclu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndGorusme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeEtk.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        //private void CreateIcraTarafGelismeleri1()
        //{
        //    // 
        //    // IcraTarafGelismeleri1
        //    // 
        //    this.IcraTarafGelismeleri1 = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri();
        //    this.layoutControl2.Controls.Add(this.IcraTarafGelismeleri1);
        //    this.layoutControlItem89.Control = this.IcraTarafGelismeleri1;
        //    this.layoutControlItem89.TextVisible = false;
        //    this.IcraTarafGelismeleri1.CurrBorcluId = 0;
        //    this.IcraTarafGelismeleri1.Location = new System.Drawing.Point(20, 68);
        //    //this.IcraTarafGelismeleri1.MyFoy = null;
        //    this.IcraTarafGelismeleri1.Name = "IcraTarafGelismeleri1";
        //    this.IcraTarafGelismeleri1.Size = new System.Drawing.Size(298, 506);
        //    this.IcraTarafGelismeleri1.TabIndex = 267;
        //}

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gcSorumlu;
        private DevExpress.XtraGrid.Views.Grid.GridView gwSorumluAvk;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Views.Grid.GridView gwBorclu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn colBorcluAdi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTarafCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAlacakliTarafKodu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAlacakliSifat;
        private DevExpress.XtraGrid.Views.Grid.GridView gwAlacak;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcAlacak;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcBorclu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBorcluTarafKodu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBorcluSifat;
        private System.Windows.Forms.BindingSource bndGorusme;
        private DevExpress.XtraEditors.TextEdit txtOdemeEtk;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAlacakliTarafVekil;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBorcluTarafVekil;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMSIL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colAVUKAT_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMSIL_SEKLI_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAlacakliTemsil;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAlacakliAvukat;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAlacakliTemsilSekli;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBorcluTemsil;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBorcluVekil;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTemsilSekli;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSorumluTaraf;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnTemsilEkle;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnBorcluTemsilEkle;
        private DevExpress.XtraGrid.GridControl gcIletisimBilgileri;
        private DevExpress.XtraGrid.Views.Layout.LayoutView lvIletisimBilgileri;
        private DevExpress.XtraLayout.LayoutControlGroup lcgIletisimBilgileri;
        private DevExpress.XtraLayout.LayoutControlItem lciIletisimBilgileri;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcAdres;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcIlce;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcIl;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcTel1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcTel2;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcCepTel1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcEmail1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcVergiDairesi;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcVergiNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueIlce;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueIl;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcTcKimlikNo;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcBabaAdi;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcDogumTarihi;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcAnneKizlikSoyadi;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcMusteriNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit rlueAdres;
        private DevExpress.XtraEditors.SimpleButton btnDuzenle;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_4;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_6;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_7;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_10;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_12;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_14;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_15;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_5;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_8;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_9;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem lciSorumlu;
        private DevExpress.XtraLayout.LayoutControlItem lciBorclu;
    }
}
