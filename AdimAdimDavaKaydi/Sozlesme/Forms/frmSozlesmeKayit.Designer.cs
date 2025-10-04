using AvukatProLib.Extras;

namespace  AdimAdimDavaKaydi.Sozlesme.Forms
{
    partial class frmSozlesmeKayit
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSozlesmeKayit));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdSozlemeMuvekkilTaraf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTemsil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rbtnTemsilEkle = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colAvukat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueSorumlu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTemsilSekli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTemsilSekli = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcSozlesmeTarafi = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.perRSzolesme = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueMuvekkilTK = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueMuvekkilCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueMuvekkilSifat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueMuvekkilTKKarsi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueMuvekkilCariKarsi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueMuvekkilSifatK = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rbtnTemsilEkleKarsi = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rspMiktar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.rLueDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gwSozlesmeMuvekkilT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMUVEKKÝLSIFAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMuvekkilTaraf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdMuvekkilKarsi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTEMSIL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAVUKAT_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueMuvekkilKarsiTarafAvukat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTEMSIL_SEKLI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSozlesmeKarsiT = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gwSozlesmeKarsiTarafi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTarafKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSýfat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMuvekkilKarsiTaraf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSorumlulukMiktari = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSorumlulukmiktariDoviz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lookUpExtender1 = new AdimAdimDavaKaydi.LookUpExtender();
            this.rLueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ucSozlesmeBilgileri1 = new AdimAdimDavaKaydi.ucSozlesmeBilgileri();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gcSozlesmeSorumlusu = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gwSozlesmeSorumlusu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSorumluAvukat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueSorumluAvukat = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYetkilimi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.tabSigortaPolice = new DevExpress.XtraTab.XtraTabPage();
            this.ucPoliceBilgileri1 = new AdimAdimDavaKaydi.UserControls.ucPoliceBilgileri();
            this.tabSozlesmeHukum = new DevExpress.XtraTab.XtraTabPage();
            this.ucSozlesmeHukum1 = new AdimAdimDavaKaydi.Sozlesme.Forms.Sozlesme.Util.ucSozlesmeHukum();
            this.tabGayriMenkul = new DevExpress.XtraTab.XtraTabPage();
            this.ucSozlesmeDetaylari1 = new AdimAdimDavaKaydi.ucSozlesmeDetaylari();
            this.tabArac = new DevExpress.XtraTab.XtraTabPage();
            this.tabAracBilgileri = new DevExpress.XtraTab.XtraTabControl();
            this.tpUcak = new DevExpress.XtraTab.XtraTabPage();
            this.ucUcakGemiArac1 = new AdimAdimDavaKaydi.ucUcakGemiArac();
            this.tpGemiBilgileri = new DevExpress.XtraTab.XtraTabPage();
            this.tpAracBilgileri = new DevExpress.XtraTab.XtraTabPage();
            this.tabUrun = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.ucUrunBilgileri1 = new AdimAdimDavaKaydi.UserControls.ucUrunBilgileri();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.ucMarkaUrunHizmetBilgileri1 = new AdimAdimDavaKaydi.UserControls.ucMarkaUrunHizmetBilgileri();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.ucSozlesmeUrunIlgilileri1 = new AdimAdimDavaKaydi.UserControls.ucSozlesmeUrunIlgilileri();
            this.tabHakem = new DevExpress.XtraTab.XtraTabPage();
            this.ucSozlesmeHakemleri1 = new AdimAdimDavaKaydi.Sozlesme.Forms.Sozlesme.Util.ucSozlesmeHakemleri();
            this.tabKýymetliEvrak = new DevExpress.XtraTab.XtraTabPage();
            this.ucKiymetliEvrak1 = new AdimAdimDavaKaydi.ucKiymetliEvrak();
            this.grdlueSorumluAvukat = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSozlemeMuvekkilTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTemsilEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSorumlu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTemsilSekli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSozlesmeTarafi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkilTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkilCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkilSifat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkilTKKarsi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkilCariKarsi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkilSifatK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTemsilEkleKarsi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspMiktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSozlesmeMuvekkilT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMuvekkilKarsi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueMuvekkilKarsiTarafAvukat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSozlesmeKarsiT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSozlesmeKarsiTarafi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSozlesmeSorumlusu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSozlesmeSorumlusu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueSorumluAvukat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.tabSigortaPolice.SuspendLayout();
            this.tabSozlesmeHukum.SuspendLayout();
            this.tabGayriMenkul.SuspendLayout();
            this.tabArac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabAracBilgileri)).BeginInit();
            this.tabAracBilgileri.SuspendLayout();
            this.tpUcak.SuspendLayout();
            this.tabUrun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            this.tabHakem.SuspendLayout();
            this.tabKýymetliEvrak.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdlueSorumluAvukat)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(1011, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 840);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 840);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 815);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(1028, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(878, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(953, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.clientPanel);
            this.c_pnlContainer.Size = new System.Drawing.Size(1028, 840);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.clientPanel, 0);
            // 
            // grdSozlemeMuvekkilTaraf
            // 
            this.grdSozlemeMuvekkilTaraf.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTemsil,
            this.colAvukat,
            this.colTemsilSekli});
            this.grdSozlemeMuvekkilTaraf.GridControl = this.gcSozlesmeTarafi;
            this.grdSozlemeMuvekkilTaraf.Name = "grdSozlemeMuvekkilTaraf";
            // 
            // colTemsil
            // 
            this.colTemsil.Caption = "TEMSIL";
            this.colTemsil.ColumnEdit = this.rbtnTemsilEkle;
            this.colTemsil.FieldName = "TEMSIL_ID";
            this.colTemsil.Name = "colTemsil";
            this.colTemsil.Visible = true;
            this.colTemsil.VisibleIndex = 0;
            // 
            // rbtnTemsilEkle
            // 
            this.rbtnTemsilEkle.AutoHeight = false;
            this.rbtnTemsilEkle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rbtnTemsilEkle.Name = "rbtnTemsilEkle";
            this.rbtnTemsilEkle.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rbtnTemsilEkle_ButtonClick);
            // 
            // colAvukat
            // 
            this.colAvukat.Caption = "AVUKAT";
            this.colAvukat.ColumnEdit = this.lueSorumlu;
            this.colAvukat.FieldName = "AVUKAT_CARI_ID";
            this.colAvukat.Name = "colAvukat";
            this.colAvukat.Visible = true;
            this.colAvukat.VisibleIndex = 1;
            // 
            // lueSorumlu
            // 
            this.lueSorumlu.AutoHeight = false;
            this.lueSorumlu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSorumlu.Name = "lueSorumlu";
            // 
            // colTemsilSekli
            // 
            this.colTemsilSekli.Caption = "TEMSIL SEKLI";
            this.colTemsilSekli.ColumnEdit = this.lueTemsilSekli;
            this.colTemsilSekli.FieldName = "TEMSIL_SEKLI_ID";
            this.colTemsilSekli.Name = "colTemsilSekli";
            this.colTemsilSekli.Visible = true;
            this.colTemsilSekli.VisibleIndex = 2;
            // 
            // lueTemsilSekli
            // 
            this.lueTemsilSekli.AutoHeight = false;
            this.lueTemsilSekli.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTemsilSekli.Name = "lueTemsilSekli";
            // 
            // gcSozlesmeTarafi
            // 
            this.gcSozlesmeTarafi.CustomButtonlarGorunmesin = false;
            this.gcSozlesmeTarafi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSozlesmeTarafi.DoNotExtendEmbedNavigator = false;
            this.gcSozlesmeTarafi.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcSozlesmeTarafi.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcSozlesmeTarafi.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gcSozlesmeTarafi.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gcSozlesmeTarafi.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gcSozlesmeTarafi.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gcSozlesmeTarafi.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.gcSozlesmeTarafi.EmbeddedNavigator.TextStringFormat = "";
            this.gcSozlesmeTarafi.ExternalRepository = this.perRSzolesme;
            this.gcSozlesmeTarafi.FilterText = null;
            this.gcSozlesmeTarafi.FilterValue = null;
            this.gcSozlesmeTarafi.GridlerDuzenlenebilir = true;
            this.gcSozlesmeTarafi.GridsFilterControl = null;
            gridLevelNode1.LevelTemplate = this.grdSozlemeMuvekkilTaraf;
            gridLevelNode1.RelationName = "AV001_TDI_BIL_SOZLESME_TARAF_VEKILCollection";
            this.gcSozlesmeTarafi.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcSozlesmeTarafi.Location = new System.Drawing.Point(2, 22);
            this.gcSozlesmeTarafi.MainView = this.gwSozlesmeMuvekkilT;
            this.gcSozlesmeTarafi.MyGridStyle = null;
            this.gcSozlesmeTarafi.Name = "gcSozlesmeTarafi";
            this.gcSozlesmeTarafi.ShowOnlyPredefinedDetails = true;
            this.gcSozlesmeTarafi.ShowRowNumbers = false;
            this.gcSozlesmeTarafi.SilmeKaldirilsin = false;
            this.gcSozlesmeTarafi.Size = new System.Drawing.Size(442, 215);
            this.gcSozlesmeTarafi.TabIndex = 0;
            this.gcSozlesmeTarafi.TemizleKaldirGorunsunmu = false;
            this.gcSozlesmeTarafi.UniqueId = "4a96371a-6501-4129-9089-be54e25f915f";
            this.gcSozlesmeTarafi.UseEmbeddedNavigator = true;
            this.gcSozlesmeTarafi.UseHyperDragDrop = false;
            this.gcSozlesmeTarafi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwSozlesmeMuvekkilT,
            this.grdSozlemeMuvekkilTaraf});
            this.gcSozlesmeTarafi.DataSourceChanged += new System.EventHandler(this.gcSozlesmeTarafi_DataSourceChanged);
            // 
            // perRSzolesme
            // 
            this.perRSzolesme.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueMuvekkilTK,
            this.rLueMuvekkilCari,
            this.rLueMuvekkilSifat,
            this.rLueMuvekkilTKKarsi,
            this.rLueMuvekkilCariKarsi,
            this.rLueMuvekkilSifatK,
            this.rbtnTemsilEkle,
            this.rbtnTemsilEkleKarsi,
            this.rspMiktar,
            this.rLueDoviz,
            this.lueSorumlu,
            this.lueTemsilSekli});
            // 
            // rLueMuvekkilTK
            // 
            this.rLueMuvekkilTK.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMuvekkilTK.Name = "rLueMuvekkilTK";
            // 
            // rLueMuvekkilCari
            // 
            this.rLueMuvekkilCari.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rLueMuvekkilCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16, "Ekle", "mEkle", null, false)});
            this.rLueMuvekkilCari.Name = "rLueMuvekkilCari";
            this.rLueMuvekkilCari.Tag = "MuvekkilTaraf";
            this.rLueMuvekkilCari.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rLueMuvekkilCari.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rLueMuvekkilCari_ButtonClick);
            // 
            // rLueMuvekkilSifat
            // 
            this.rLueMuvekkilSifat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMuvekkilSifat.Name = "rLueMuvekkilSifat";
            // 
            // rLueMuvekkilTKKarsi
            // 
            this.rLueMuvekkilTKKarsi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMuvekkilTKKarsi.Name = "rLueMuvekkilTKKarsi";
            // 
            // rLueMuvekkilCariKarsi
            // 
            this.rLueMuvekkilCariKarsi.AutoHeight = false;
            this.rLueMuvekkilCariKarsi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17, "Ekle", "mEkle", null, false)});
            this.rLueMuvekkilCariKarsi.Name = "rLueMuvekkilCariKarsi";
            this.rLueMuvekkilCariKarsi.Tag = "KarsiTaraf";
            this.rLueMuvekkilCariKarsi.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rLueMuvekkilCariKarsi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rLueMuvekkilCariKarsi_ButtonClick);
            // 
            // rLueMuvekkilSifatK
            // 
            this.rLueMuvekkilSifatK.AutoHeight = false;
            this.rLueMuvekkilSifatK.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMuvekkilSifatK.Name = "rLueMuvekkilSifatK";
            // 
            // rbtnTemsilEkleKarsi
            // 
            this.rbtnTemsilEkleKarsi.AutoHeight = false;
            this.rbtnTemsilEkleKarsi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rbtnTemsilEkleKarsi.Name = "rbtnTemsilEkleKarsi";
            this.rbtnTemsilEkleKarsi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rbtnTemsilEkleKarsi_ButtonClick);
            // 
            // rspMiktar
            // 
            this.rspMiktar.AutoHeight = false;
            this.rspMiktar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rspMiktar.Name = "rspMiktar";
            // 
            // rLueDoviz
            // 
            this.rLueDoviz.AutoHeight = false;
            this.rLueDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDoviz.Name = "rLueDoviz";
            // 
            // gwSozlesmeMuvekkilT
            // 
            this.gwSozlesmeMuvekkilT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTK,
            this.colMUVEKKÝLSIFAT,
            this.colMuvekkilTaraf});
            this.gwSozlesmeMuvekkilT.GridControl = this.gcSozlesmeTarafi;
            this.gwSozlesmeMuvekkilT.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "")});
            this.gwSozlesmeMuvekkilT.IndicatorWidth = 20;
            this.gwSozlesmeMuvekkilT.Name = "gwSozlesmeMuvekkilT";
            this.gwSozlesmeMuvekkilT.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwSozlesmeMuvekkilT.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gwSozlesmeMuvekkilT.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gwSozlesmeMuvekkilT.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gwSozlesmeMuvekkilT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gwSozlesmeMuvekkilT.OptionsView.ShowGroupPanel = false;
            this.gwSozlesmeMuvekkilT.MasterRowExpanding += new DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventHandler(this.gwSozlesmeMuvekkilT_MasterRowExpanding);
            this.gwSozlesmeMuvekkilT.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gwSozlesmeMuvekkilT_CustomRowCellEdit);
            this.gwSozlesmeMuvekkilT.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gwSozlesmeMuvekkilT_ValidateRow);
            // 
            // colTK
            // 
            this.colTK.Caption = "Taraf Kodu";
            this.colTK.ColumnEdit = this.rLueMuvekkilTK;
            this.colTK.FieldName = "TARAF_KODU";
            this.colTK.Name = "colTK";
            this.colTK.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colTK.Visible = true;
            this.colTK.VisibleIndex = 0;
            this.colTK.Width = 191;
            // 
            // colMUVEKKÝLSIFAT
            // 
            this.colMUVEKKÝLSIFAT.Caption = "Sýfat";
            this.colMUVEKKÝLSIFAT.ColumnEdit = this.rLueMuvekkilSifat;
            this.colMUVEKKÝLSIFAT.FieldName = "TARAF_SIFAT_ID";
            this.colMUVEKKÝLSIFAT.Name = "colMUVEKKÝLSIFAT";
            this.colMUVEKKÝLSIFAT.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colMUVEKKÝLSIFAT.Visible = true;
            this.colMUVEKKÝLSIFAT.VisibleIndex = 1;
            this.colMUVEKKÝLSIFAT.Width = 338;
            // 
            // colMuvekkilTaraf
            // 
            this.colMuvekkilTaraf.Caption = "Muvekkil Taraf";
            this.colMuvekkilTaraf.ColumnEdit = this.rLueMuvekkilCari;
            this.colMuvekkilTaraf.FieldName = "CARI_ID";
            this.colMuvekkilTaraf.Name = "colMuvekkilTaraf";
            this.colMuvekkilTaraf.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colMuvekkilTaraf.Visible = true;
            this.colMuvekkilTaraf.VisibleIndex = 2;
            this.colMuvekkilTaraf.Width = 546;
            // 
            // grdMuvekkilKarsi
            // 
            this.grdMuvekkilKarsi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTEMSIL_ID,
            this.colAVUKAT_CARI_ID,
            this.colTEMSIL_SEKLI_ID});
            this.grdMuvekkilKarsi.GridControl = this.gcSozlesmeKarsiT;
            this.grdMuvekkilKarsi.Name = "grdMuvekkilKarsi";
            // 
            // colTEMSIL_ID
            // 
            this.colTEMSIL_ID.Caption = "Temsil";
            this.colTEMSIL_ID.ColumnEdit = this.rbtnTemsilEkleKarsi;
            this.colTEMSIL_ID.FieldName = "TEMSIL_ID";
            this.colTEMSIL_ID.Name = "colTEMSIL_ID";
            this.colTEMSIL_ID.Visible = true;
            this.colTEMSIL_ID.VisibleIndex = 0;
            // 
            // colAVUKAT_CARI_ID
            // 
            this.colAVUKAT_CARI_ID.Caption = "Avukat";
            this.colAVUKAT_CARI_ID.ColumnEdit = this.rlueMuvekkilKarsiTarafAvukat;
            this.colAVUKAT_CARI_ID.FieldName = "AVUKAT_CARI_ID";
            this.colAVUKAT_CARI_ID.Name = "colAVUKAT_CARI_ID";
            this.colAVUKAT_CARI_ID.Visible = true;
            this.colAVUKAT_CARI_ID.VisibleIndex = 1;
            // 
            // rlueMuvekkilKarsiTarafAvukat
            // 
            this.rlueMuvekkilKarsiTarafAvukat.AutoHeight = false;
            this.rlueMuvekkilKarsiTarafAvukat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueMuvekkilKarsiTarafAvukat.Name = "rlueMuvekkilKarsiTarafAvukat";
            // 
            // colTEMSIL_SEKLI_ID
            // 
            this.colTEMSIL_SEKLI_ID.Caption = "Temsil Þekli";
            this.colTEMSIL_SEKLI_ID.ColumnEdit = this.lueTemsilSekli;
            this.colTEMSIL_SEKLI_ID.FieldName = "TEMSIL_SEKLI_ID";
            this.colTEMSIL_SEKLI_ID.Name = "colTEMSIL_SEKLI_ID";
            this.colTEMSIL_SEKLI_ID.Visible = true;
            this.colTEMSIL_SEKLI_ID.VisibleIndex = 2;
            // 
            // gcSozlesmeKarsiT
            // 
            this.gcSozlesmeKarsiT.CustomButtonlarGorunmesin = false;
            this.gcSozlesmeKarsiT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSozlesmeKarsiT.DoNotExtendEmbedNavigator = false;
            this.gcSozlesmeKarsiT.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcSozlesmeKarsiT.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcSozlesmeKarsiT.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gcSozlesmeKarsiT.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gcSozlesmeKarsiT.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gcSozlesmeKarsiT.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gcSozlesmeKarsiT.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.gcSozlesmeKarsiT.ExternalRepository = this.perRSzolesme;
            this.gcSozlesmeKarsiT.FilterText = null;
            this.gcSozlesmeKarsiT.FilterValue = null;
            this.gcSozlesmeKarsiT.GridlerDuzenlenebilir = true;
            this.gcSozlesmeKarsiT.GridsFilterControl = null;
            gridLevelNode3.LevelTemplate = this.grdMuvekkilKarsi;
            gridLevelNode3.RelationName = "AV001_TDI_BIL_SOZLESME_TARAF_VEKILCollection";
            this.gcSozlesmeKarsiT.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode3});
            this.gcSozlesmeKarsiT.Location = new System.Drawing.Point(2, 22);
            this.gcSozlesmeKarsiT.MainView = this.gwSozlesmeKarsiTarafi;
            this.gcSozlesmeKarsiT.MyGridStyle = null;
            this.gcSozlesmeKarsiT.Name = "gcSozlesmeKarsiT";
            this.gcSozlesmeKarsiT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueMuvekkilKarsiTarafAvukat});
            this.gcSozlesmeKarsiT.ShowOnlyPredefinedDetails = true;
            this.gcSozlesmeKarsiT.ShowRowNumbers = false;
            this.gcSozlesmeKarsiT.SilmeKaldirilsin = false;
            this.gcSozlesmeKarsiT.Size = new System.Drawing.Size(442, 210);
            this.gcSozlesmeKarsiT.TabIndex = 0;
            this.gcSozlesmeKarsiT.TemizleKaldirGorunsunmu = false;
            this.gcSozlesmeKarsiT.UniqueId = "5d3a32ae-d51d-41db-838b-2b6754a7038e";
            this.gcSozlesmeKarsiT.UseEmbeddedNavigator = true;
            this.gcSozlesmeKarsiT.UseHyperDragDrop = false;
            this.gcSozlesmeKarsiT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwSozlesmeKarsiTarafi,
            this.grdMuvekkilKarsi});
            this.gcSozlesmeKarsiT.DataSourceChanged += new System.EventHandler(this.gcSozlesmeKarsiT_DataSourceChanged);
            // 
            // gwSozlesmeKarsiTarafi
            // 
            this.gwSozlesmeKarsiTarafi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTarafKodu,
            this.colSýfat,
            this.colMuvekkilKarsiTaraf,
            this.colSorumlulukMiktari,
            this.colSorumlulukmiktariDoviz});
            this.gwSozlesmeKarsiTarafi.GridControl = this.gcSozlesmeKarsiT;
            this.gwSozlesmeKarsiTarafi.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "")});
            this.gwSozlesmeKarsiTarafi.IndicatorWidth = 20;
            this.gwSozlesmeKarsiTarafi.Name = "gwSozlesmeKarsiTarafi";
            this.gwSozlesmeKarsiTarafi.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwSozlesmeKarsiTarafi.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gwSozlesmeKarsiTarafi.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gwSozlesmeKarsiTarafi.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gwSozlesmeKarsiTarafi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gwSozlesmeKarsiTarafi.OptionsView.ShowGroupPanel = false;
            this.gwSozlesmeKarsiTarafi.MasterRowExpanding += new DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventHandler(this.gwSozlesmeKarsiTarafi_MasterRowExpanding);
            this.gwSozlesmeKarsiTarafi.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gwSozlesmeKarsiTarafi_ValidateRow);
            // 
            // colTarafKodu
            // 
            this.colTarafKodu.Caption = "Taraf Kodu";
            this.colTarafKodu.ColumnEdit = this.rLueMuvekkilTKKarsi;
            this.colTarafKodu.FieldName = "TARAF_KODU";
            this.colTarafKodu.Name = "colTarafKodu";
            this.colTarafKodu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colTarafKodu.Visible = true;
            this.colTarafKodu.VisibleIndex = 0;
            this.colTarafKodu.Width = 184;
            // 
            // colSýfat
            // 
            this.colSýfat.Caption = "Sýfat";
            this.colSýfat.ColumnEdit = this.rLueMuvekkilSifat;
            this.colSýfat.FieldName = "TARAF_SIFAT_ID";
            this.colSýfat.Name = "colSýfat";
            this.colSýfat.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colSýfat.Visible = true;
            this.colSýfat.VisibleIndex = 1;
            this.colSýfat.Width = 167;
            // 
            // colMuvekkilKarsiTaraf
            // 
            this.colMuvekkilKarsiTaraf.Caption = "Muvekkil Karþý Taraf";
            this.colMuvekkilKarsiTaraf.ColumnEdit = this.rLueMuvekkilCariKarsi;
            this.colMuvekkilKarsiTaraf.FieldName = "CARI_ID";
            this.colMuvekkilKarsiTaraf.Name = "colMuvekkilKarsiTaraf";
            this.colMuvekkilKarsiTaraf.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colMuvekkilKarsiTaraf.Visible = true;
            this.colMuvekkilKarsiTaraf.VisibleIndex = 2;
            this.colMuvekkilKarsiTaraf.Width = 275;
            // 
            // colSorumlulukMiktari
            // 
            this.colSorumlulukMiktari.Caption = "Sorumluluk Mik.";
            this.colSorumlulukMiktari.ColumnEdit = this.rspMiktar;
            this.colSorumlulukMiktari.FieldName = "SORUMLULUK_MIKTAR";
            this.colSorumlulukMiktari.Name = "colSorumlulukMiktari";
            this.colSorumlulukMiktari.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colSorumlulukMiktari.Visible = true;
            this.colSorumlulukMiktari.VisibleIndex = 3;
            this.colSorumlulukMiktari.Width = 224;
            // 
            // colSorumlulukmiktariDoviz
            // 
            this.colSorumlulukmiktariDoviz.Caption = " ";
            this.colSorumlulukmiktariDoviz.ColumnEdit = this.rLueDoviz;
            this.colSorumlulukmiktariDoviz.FieldName = "SORUMLULUK_MIKTAR_DOVIZ_ID";
            this.colSorumlulukmiktariDoviz.Name = "colSorumlulukmiktariDoviz";
            this.colSorumlulukmiktariDoviz.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colSorumlulukmiktariDoviz.Visible = true;
            this.colSorumlulukmiktariDoviz.VisibleIndex = 4;
            this.colSorumlulukmiktariDoviz.Width = 235;
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.xtraTabControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 0);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(1028, 815);
            this.clientPanel.TabIndex = 2;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.xtraTabControl1.Appearance.Options.UseBackColor = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.xtraTabControl1.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1028, 815);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.xtraTabControl1.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.xtraTabControl1_SelectedPageChanging);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panelControl1);
            this.xtraTabPage1.Controls.Add(this.panelControl2);
            this.xtraTabPage1.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage1.Image")));
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(876, 809);
            this.xtraTabPage1.Text = "Sözleþme Genel Bilgileri";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lookUpExtender1);
            this.panelControl1.Controls.Add(this.ucSozlesmeBilgileri1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(450, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(426, 809);
            this.panelControl1.TabIndex = 3;
            // 
            // lookUpExtender1
            // 
            this.lookUpExtender1.AddLookUp = null;
            this.lookUpExtender1.AddRepoLookUp = null;
            this.lookUpExtender1.Location = new System.Drawing.Point(80, 572);
            this.lookUpExtender1.LookUpEditCollection = new DevExpress.XtraEditors.LookUpEdit[0];
            this.lookUpExtender1.Name = "lookUpExtender1";
            this.lookUpExtender1.RemoveLookUp = null;
            this.lookUpExtender1.RemoveRepoLookUp = null;
            this.lookUpExtender1.RepoLookUpEditCollection = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit[] {
        this.rLueMuvekkilCari,
        this.rLueCari,
        this.rLueMuvekkilCariKarsi};
            this.lookUpExtender1.Size = new System.Drawing.Size(75, 23);
            this.lookUpExtender1.TabIndex = 1;
            this.lookUpExtender1.Text = "lookUpExtender1";
            this.lookUpExtender1.Visible = false;
            // 
            // rLueCari
            // 
            this.rLueCari.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rLueCari.AutoHeight = false;
            this.rLueCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18, "Ekle", "mEkle", null, false)});
            this.rLueCari.Name = "rLueCari";
            this.rLueCari.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // ucSozlesmeBilgileri1
            // 
            this.ucSozlesmeBilgileri1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ucSozlesmeBilgileri1.Appearance.Options.UseBackColor = true;
            this.ucSozlesmeBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSozlesmeBilgileri1.Location = new System.Drawing.Point(2, 2);
            this.ucSozlesmeBilgileri1.MyDataSource = null;
            this.ucSozlesmeBilgileri1.MyIcraFoy = null;
            this.ucSozlesmeBilgileri1.MyIcraTaraf = null;
            this.ucSozlesmeBilgileri1.Name = "ucSozlesmeBilgileri1";
            this.ucSozlesmeBilgileri1.Size = new System.Drawing.Size(422, 805);
            this.ucSozlesmeBilgileri1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.splitContainerControl2);
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(450, 809);
            this.panelControl2.TabIndex = 4;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(2, 241);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl3);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(446, 566);
            this.splitContainerControl2.SplitterPosition = 231;
            this.splitContainerControl2.TabIndex = 1;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.gcSozlesmeKarsiT);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(446, 234);
            this.groupControl3.TabIndex = 5;
            this.groupControl3.Text = "Sözleþme Karþý Tarafý";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gcSozlesmeSorumlusu);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(446, 250);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "Sözleþme Sorumlusu";
            // 
            // gcSozlesmeSorumlusu
            // 
            this.gcSozlesmeSorumlusu.CustomButtonlarGorunmesin = false;
            this.gcSozlesmeSorumlusu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSozlesmeSorumlusu.DoNotExtendEmbedNavigator = false;
            this.gcSozlesmeSorumlusu.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcSozlesmeSorumlusu.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcSozlesmeSorumlusu.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gcSozlesmeSorumlusu.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gcSozlesmeSorumlusu.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gcSozlesmeSorumlusu.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.gcSozlesmeSorumlusu.FilterText = null;
            this.gcSozlesmeSorumlusu.FilterValue = null;
            this.gcSozlesmeSorumlusu.GridlerDuzenlenebilir = true;
            this.gcSozlesmeSorumlusu.GridsFilterControl = null;
            this.gcSozlesmeSorumlusu.Location = new System.Drawing.Point(2, 22);
            this.gcSozlesmeSorumlusu.MainView = this.gwSozlesmeSorumlusu;
            this.gcSozlesmeSorumlusu.MyGridStyle = null;
            this.gcSozlesmeSorumlusu.Name = "gcSozlesmeSorumlusu";
            this.gcSozlesmeSorumlusu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueCari,
            this.rlueSorumluAvukat});
            this.gcSozlesmeSorumlusu.ShowRowNumbers = false;
            this.gcSozlesmeSorumlusu.SilmeKaldirilsin = false;
            this.gcSozlesmeSorumlusu.Size = new System.Drawing.Size(442, 226);
            this.gcSozlesmeSorumlusu.TabIndex = 4;
            this.gcSozlesmeSorumlusu.TemizleKaldirGorunsunmu = false;
            this.gcSozlesmeSorumlusu.UniqueId = "5cb35bb1-83ef-4acd-9160-bc79659a8cbc";
            this.gcSozlesmeSorumlusu.UseEmbeddedNavigator = true;
            this.gcSozlesmeSorumlusu.UseHyperDragDrop = false;
            this.gcSozlesmeSorumlusu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwSozlesmeSorumlusu});
            // 
            // gwSozlesmeSorumlusu
            // 
            this.gwSozlesmeSorumlusu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSorumluAvukat,
            this.colYetkilimi});
            this.gwSozlesmeSorumlusu.GridControl = this.gcSozlesmeSorumlusu;
            this.gwSozlesmeSorumlusu.IndicatorWidth = 20;
            this.gwSozlesmeSorumlusu.Name = "gwSozlesmeSorumlusu";
            this.gwSozlesmeSorumlusu.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwSozlesmeSorumlusu.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gwSozlesmeSorumlusu.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gwSozlesmeSorumlusu.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gwSozlesmeSorumlusu.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gwSozlesmeSorumlusu.OptionsView.ShowGroupPanel = false;
            // 
            // colSorumluAvukat
            // 
            this.colSorumluAvukat.Caption = "Sorumlu Avukat";
            this.colSorumluAvukat.ColumnEdit = this.rlueSorumluAvukat;
            this.colSorumluAvukat.FieldName = "SORUMLU_CARI_ID";
            this.colSorumluAvukat.Name = "colSorumluAvukat";
            this.colSorumluAvukat.Visible = true;
            this.colSorumluAvukat.VisibleIndex = 0;
            // 
            // rlueSorumluAvukat
            // 
            this.rlueSorumluAvukat.AutoHeight = false;
            this.rlueSorumluAvukat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueSorumluAvukat.DisplayMember = "AD";
            this.rlueSorumluAvukat.Name = "rlueSorumluAvukat";
            this.rlueSorumluAvukat.ValueMember = "ID";
            this.rlueSorumluAvukat.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn3});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Adý";
            this.gridColumn4.FieldName = "AD";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Kod";
            this.gridColumn3.FieldName = "KOD";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // colYetkilimi
            // 
            this.colYetkilimi.Caption = "YETKÝLÝMÝ";
            this.colYetkilimi.FieldName = "YETKILI_MI";
            this.colYetkilimi.Name = "colYetkilimi";
            this.colYetkilimi.Visible = true;
            this.colYetkilimi.VisibleIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcSozlesmeTarafi);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(446, 239);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Sözleþme Tarafý";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.xtraTabControl2);
            this.xtraTabPage2.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage2.Image")));
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(876, 809);
            this.xtraTabPage2.Text = "Sözleþme Detaylarý";
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl2.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.tabSigortaPolice;
            this.xtraTabControl2.Size = new System.Drawing.Size(876, 809);
            this.xtraTabControl2.TabIndex = 0;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabSozlesmeHukum,
            this.tabGayriMenkul,
            this.tabArac,
            this.tabUrun,
            this.tabHakem,
            this.tabKýymetliEvrak,
            this.tabSigortaPolice});
            // 
            // tabSigortaPolice
            // 
            this.tabSigortaPolice.Controls.Add(this.ucPoliceBilgileri1);
            this.tabSigortaPolice.Name = "tabSigortaPolice";
            this.tabSigortaPolice.PageVisible = false;
            this.tabSigortaPolice.Size = new System.Drawing.Size(870, 783);
            this.tabSigortaPolice.Text = "Sigorta Poliçe";
            // 
            // ucPoliceBilgileri1
            // 
            this.ucPoliceBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPoliceBilgileri1.Location = new System.Drawing.Point(0, 0);
            this.ucPoliceBilgileri1.MyDataSource = null;
            this.ucPoliceBilgileri1.Name = "ucPoliceBilgileri1";
            this.ucPoliceBilgileri1.Size = new System.Drawing.Size(870, 783);
            this.ucPoliceBilgileri1.TabIndex = 0;
            // 
            // tabSozlesmeHukum
            // 
            this.tabSozlesmeHukum.Controls.Add(this.ucSozlesmeHukum1);
            this.tabSozlesmeHukum.Name = "tabSozlesmeHukum";
            this.tabSozlesmeHukum.Size = new System.Drawing.Size(870, 783);
            this.tabSozlesmeHukum.Text = "Sözleþme Hükümleri";
            // 
            // ucSozlesmeHukum1
            // 
            this.ucSozlesmeHukum1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSozlesmeHukum1.Location = new System.Drawing.Point(0, 0);
            this.ucSozlesmeHukum1.MyDataSource = null;
            this.ucSozlesmeHukum1.Name = "ucSozlesmeHukum1";
            this.ucSozlesmeHukum1.Size = new System.Drawing.Size(870, 783);
            this.ucSozlesmeHukum1.TabIndex = 0;
            // 
            // tabGayriMenkul
            // 
            this.tabGayriMenkul.Controls.Add(this.ucSozlesmeDetaylari1);
            this.tabGayriMenkul.Name = "tabGayriMenkul";
            this.tabGayriMenkul.Size = new System.Drawing.Size(870, 783);
            this.tabGayriMenkul.Text = "Gayrimenkul Bilgileri";
            // 
            // ucSozlesmeDetaylari1
            // 
            this.ucSozlesmeDetaylari1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSozlesmeDetaylari1.Location = new System.Drawing.Point(0, 0);
            this.ucSozlesmeDetaylari1.Name = "ucSozlesmeDetaylari1";
            this.ucSozlesmeDetaylari1.Size = new System.Drawing.Size(870, 783);
            this.ucSozlesmeDetaylari1.TabIndex = 0;
            // 
            // tabArac
            // 
            this.tabArac.Controls.Add(this.tabAracBilgileri);
            this.tabArac.Name = "tabArac";
            this.tabArac.Size = new System.Drawing.Size(870, 783);
            this.tabArac.Text = "Araç Bilgileri";
            // 
            // tabAracBilgileri
            // 
            this.tabAracBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAracBilgileri.Location = new System.Drawing.Point(0, 0);
            this.tabAracBilgileri.Name = "tabAracBilgileri";
            this.tabAracBilgileri.SelectedTabPage = this.tpUcak;
            this.tabAracBilgileri.Size = new System.Drawing.Size(870, 783);
            this.tabAracBilgileri.TabIndex = 8;
            this.tabAracBilgileri.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpUcak,
            this.tpGemiBilgileri,
            this.tpAracBilgileri});
            this.tabAracBilgileri.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabAracBilgileri_SelectedPageChanged);
            // 
            // tpUcak
            // 
            this.tpUcak.Controls.Add(this.ucUcakGemiArac1);
            this.tpUcak.Name = "tpUcak";
            this.tpUcak.Size = new System.Drawing.Size(864, 757);
            this.tpUcak.Text = "Uçak Bilgileri";
            // 
            // ucUcakGemiArac1
            // 
            this.ucUcakGemiArac1.HacizKayitEkranimi = false;
            this.ucUcakGemiArac1.KontrolTipi = AvukatProLib.Extras.GemiUcakAracTipi.SecimYapin;
            this.ucUcakGemiArac1.Location = new System.Drawing.Point(0, 0);
            this.ucUcakGemiArac1.MyDataSource = null;
            this.ucUcakGemiArac1.Name = "ucUcakGemiArac1";
            this.ucUcakGemiArac1.PerMyDataSource = null;
            this.ucUcakGemiArac1.Size = new System.Drawing.Size(150, 150);
            this.ucUcakGemiArac1.TabIndex = 0;
            // 
            // tpGemiBilgileri
            // 
            this.tpGemiBilgileri.Name = "tpGemiBilgileri";
            this.tpGemiBilgileri.Size = new System.Drawing.Size(864, 757);
            this.tpGemiBilgileri.Text = "Gemi Bilgileri";
            // 
            // tpAracBilgileri
            // 
            this.tpAracBilgileri.Name = "tpAracBilgileri";
            this.tpAracBilgileri.Size = new System.Drawing.Size(864, 757);
            this.tpAracBilgileri.Text = "Araç Bilgileri";
            // 
            // tabUrun
            // 
            this.tabUrun.Controls.Add(this.panelControl3);
            this.tabUrun.Controls.Add(this.groupControl5);
            this.tabUrun.Name = "tabUrun";
            this.tabUrun.PageVisible = false;
            this.tabUrun.Size = new System.Drawing.Size(870, 783);
            this.tabUrun.Text = "Ürün Bilgileri";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.ucUrunBilgileri1);
            this.panelControl3.Location = new System.Drawing.Point(0, 52);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1010, 406);
            this.panelControl3.TabIndex = 2;
            // 
            // ucUrunBilgileri1
            // 
            this.ucUrunBilgileri1.Location = new System.Drawing.Point(2, 27);
            this.ucUrunBilgileri1.MyDataSource = null;
            this.ucUrunBilgileri1.Name = "ucUrunBilgileri1";
            this.ucUrunBilgileri1.Size = new System.Drawing.Size(1006, 429);
            this.ucUrunBilgileri1.TabIndex = 0;
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.splitContainerControl1);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl5.Location = new System.Drawing.Point(0, 577);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(870, 206);
            this.groupControl5.TabIndex = 0;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 22);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl4);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl5);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(866, 182);
            this.splitContainerControl1.SplitterPosition = 515;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.ucMarkaUrunHizmetBilgileri1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(515, 182);
            this.panelControl4.TabIndex = 1;
            // 
            // ucMarkaUrunHizmetBilgileri1
            // 
            this.ucMarkaUrunHizmetBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMarkaUrunHizmetBilgileri1.Location = new System.Drawing.Point(2, 2);
            this.ucMarkaUrunHizmetBilgileri1.MyDataSoruce = null;
            this.ucMarkaUrunHizmetBilgileri1.Name = "ucMarkaUrunHizmetBilgileri1";
            this.ucMarkaUrunHizmetBilgileri1.Size = new System.Drawing.Size(511, 178);
            this.ucMarkaUrunHizmetBilgileri1.TabIndex = 0;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.ucSozlesmeUrunIlgilileri1);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(0, 0);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(346, 182);
            this.panelControl5.TabIndex = 3;
            // 
            // ucSozlesmeUrunIlgilileri1
            // 
            this.ucSozlesmeUrunIlgilileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSozlesmeUrunIlgilileri1.Location = new System.Drawing.Point(2, 2);
            this.ucSozlesmeUrunIlgilileri1.MyDataSource = null;
            this.ucSozlesmeUrunIlgilileri1.Name = "ucSozlesmeUrunIlgilileri1";
            this.ucSozlesmeUrunIlgilileri1.Size = new System.Drawing.Size(342, 178);
            this.ucSozlesmeUrunIlgilileri1.TabIndex = 2;
            // 
            // tabHakem
            // 
            this.tabHakem.Controls.Add(this.ucSozlesmeHakemleri1);
            this.tabHakem.Name = "tabHakem";
            this.tabHakem.Size = new System.Drawing.Size(870, 783);
            this.tabHakem.Text = "Sözleþme Hakemleri";
            // 
            // ucSozlesmeHakemleri1
            // 
            this.ucSozlesmeHakemleri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSozlesmeHakemleri1.Location = new System.Drawing.Point(0, 0);
            this.ucSozlesmeHakemleri1.MyDataSource = null;
            this.ucSozlesmeHakemleri1.Name = "ucSozlesmeHakemleri1";
            this.ucSozlesmeHakemleri1.Size = new System.Drawing.Size(870, 783);
            this.ucSozlesmeHakemleri1.TabIndex = 0;
            // 
            // tabKýymetliEvrak
            // 
            this.tabKýymetliEvrak.Controls.Add(this.ucKiymetliEvrak1);
            this.tabKýymetliEvrak.Name = "tabKýymetliEvrak";
            this.tabKýymetliEvrak.Size = new System.Drawing.Size(870, 783);
            this.tabKýymetliEvrak.Text = "Kýymetli Evrak";
            // 
            // ucKiymetliEvrak1
            // 
            this.ucKiymetliEvrak1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKiymetliEvrak1.Gorunum = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.ucKiymetliEvrak1.Location = new System.Drawing.Point(0, 0);
            this.ucKiymetliEvrak1.MyDataSource = null;
            this.ucKiymetliEvrak1.MyExtendedDataSource = null;
            this.ucKiymetliEvrak1.Name = "ucKiymetliEvrak1";
            this.ucKiymetliEvrak1.OnlyOneRecord = false;
            this.ucKiymetliEvrak1.Size = new System.Drawing.Size(870, 783);
            this.ucKiymetliEvrak1.TabIndex = 0;
            // 
            // grdlueSorumluAvukat
            // 
            this.grdlueSorumluAvukat.AutoHeight = false;
            this.grdlueSorumluAvukat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdlueSorumluAvukat.DisplayMember = "AD";
            this.grdlueSorumluAvukat.Name = "grdlueSorumluAvukat";
            this.grdlueSorumluAvukat.ValidateOnEnterKey = true;
            this.grdlueSorumluAvukat.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // frmSozlesmeKayit
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 840);
            this.Name = "frmSozlesmeKayit";
            this.Text = "Avukatpro Hukuk Ailesi Sözleþme Kayýt Formu";
            this.UstMenu = true;
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSozlemeMuvekkilTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTemsilEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSorumlu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTemsilSekli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSozlesmeTarafi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkilTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkilCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkilSifat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkilTKKarsi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkilCariKarsi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkilSifatK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTemsilEkleKarsi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspMiktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSozlesmeMuvekkilT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMuvekkilKarsi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueMuvekkilKarsiTarafAvukat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSozlesmeKarsiT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSozlesmeKarsiTarafi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rLueCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSozlesmeSorumlusu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSozlesmeSorumlusu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueSorumluAvukat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.tabSigortaPolice.ResumeLayout(false);
            this.tabSozlesmeHukum.ResumeLayout(false);
            this.tabGayriMenkul.ResumeLayout(false);
            this.tabArac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabAracBilgileri)).EndInit();
            this.tabAracBilgileri.ResumeLayout(false);
            this.tpUcak.ResumeLayout(false);
            this.tabUrun.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.tabHakem.ResumeLayout(false);
            this.tabKýymetliEvrak.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdlueSorumluAvukat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabPage tabGayriMenkul;
        private DevExpress.XtraTab.XtraTabPage tabArac;
        private DevExpress.XtraTab.XtraTabPage tabUrun;
        private DevExpress.XtraTab.XtraTabPage tabSozlesmeHukum;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private AdimAdimDavaKaydi.Sozlesme.Forms.Sozlesme.Util.ucSozlesmeHukum ucSozlesmeHukum1;
        private AdimAdimDavaKaydi.UserControls.ucMarkaUrunHizmetBilgileri ucMarkaUrunHizmetBilgileri1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private AdimAdimDavaKaydi.UserControls.ucUrunBilgileri ucUrunBilgileri1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private AdimAdimDavaKaydi.UserControls.ucSozlesmeUrunIlgilileri ucSozlesmeUrunIlgilileri1;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //private DevExpress.XtraBars.BarButtonItem btnKaydet;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem13;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem15;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem16;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem17;
        private DevExpress.XtraTab.XtraTabPage tabHakem;
        private AdimAdimDavaKaydi.Sozlesme.Forms.Sozlesme.Util.ucSozlesmeHakemleri ucSozlesmeHakemleri1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem18;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem19;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem20;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem21;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private ucSozlesmeBilgileri ucSozlesmeBilgileri1;
        private DevExpress.XtraTab.XtraTabControl tabAracBilgileri;
        private DevExpress.XtraTab.XtraTabPage tpUcak;
        private ucUcakGemiArac ucUcakGemiArac1;
        private DevExpress.XtraTab.XtraTabPage tpGemiBilgileri;
        private DevExpress.XtraTab.XtraTabPage tpAracBilgileri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcSozlesmeTarafi;
        private DevExpress.XtraGrid.Views.Grid.GridView gwSozlesmeMuvekkilT;
        private DevExpress.XtraGrid.Columns.GridColumn colTK;
        private DevExpress.XtraGrid.Columns.GridColumn colMUVEKKÝLSIFAT;
        private DevExpress.XtraGrid.Columns.GridColumn colMuvekkilTaraf;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSozlemeMuvekkilTaraf;
        private DevExpress.XtraGrid.Columns.GridColumn colTemsil;
        private DevExpress.XtraGrid.Columns.GridColumn colAvukat;
        private DevExpress.XtraGrid.Columns.GridColumn colTemsilSekli;
        private DevExpress.XtraEditors.Repository.PersistentRepository perRSzolesme;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMuvekkilTK;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMuvekkilCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMuvekkilSifat;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMuvekkilTKKarsi;
        private DevExpress.XtraTab.XtraTabPage tabKýymetliEvrak;
        private DevExpress.XtraTab.XtraTabPage tabSigortaPolice;
        private ucKiymetliEvrak ucKiymetliEvrak1;
        private AdimAdimDavaKaydi.UserControls.ucPoliceBilgileri ucPoliceBilgileri1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMuvekkilCariKarsi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMuvekkilSifatK;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnTemsilEkle;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnTemsilEkleKarsi;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcSozlesmeKarsiT;
        private DevExpress.XtraGrid.Views.Grid.GridView grdMuvekkilKarsi;
        private DevExpress.XtraGrid.Views.Grid.GridView gwSozlesmeKarsiTarafi;
        private DevExpress.XtraGrid.Columns.GridColumn colTarafKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colSýfat;
        private DevExpress.XtraGrid.Columns.GridColumn colMuvekkilKarsiTaraf;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcSozlesmeSorumlusu;
        private DevExpress.XtraGrid.Views.Grid.GridView gwSozlesmeSorumlusu;
        private DevExpress.XtraGrid.Columns.GridColumn colSorumluAvukat;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit rlueSorumluAvukat;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn colYetkilimi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueCari;
        private LookUpExtender lookUpExtender1;
        private ucSozlesmeDetaylari ucSozlesmeDetaylari1;
        private DevExpress.XtraGrid.Columns.GridColumn colSorumlulukMiktari;
        private DevExpress.XtraGrid.Columns.GridColumn colSorumlulukmiktariDoviz;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspMiktar;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDoviz;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMSIL_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueSorumlu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTemsilSekli;
        private DevExpress.XtraGrid.Columns.GridColumn colAVUKAT_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMSIL_SEKLI_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueMuvekkilKarsiTarafAvukat;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit grdlueSorumluAvukat;




    }
}

