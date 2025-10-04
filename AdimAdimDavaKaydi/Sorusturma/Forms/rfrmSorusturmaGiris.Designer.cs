using AvukatProLib.Extras;

namespace AdimAdimDavaKaydi.Sorusturma.Forms
{
    partial class rfrmSorusturmaGiris
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rfrmSorusturmaGiris));
            this.grdSikayetEdenTaraf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsikayetEdenTEMSIL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rbtnTemsilEkle = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colSikayetEdenAVUKAT_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueTarafVAvukat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSikayetEdenTEMSIL_SEKLI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueTemsilSekli = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.exgrdSikayetEden = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.AV001_TD_BIL_HAZIRLIK_TARAFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.perRSorusturmaGenelBilgiler = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueSikayetEdenTaraf = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSikayetEdenSifat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSikayetEdilenCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSikayetEdenTemsil = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSikayetEdilenTaraf = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSikayetEdilenSifat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSikayetEdilenTemsil = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueAdliBirimNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueAdliBirimGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSorumluSavci = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rDateSikayet = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rLueHazirlikDurum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rIAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.grLueSorumluAvk = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueSikayetNeden = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rceSorusturma = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rLueSikayetKonu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueDosyaDurum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueOzelKod1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSikayetEdenCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueKarsiTarafVAvukat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rbtnTemsilEkleSEdilen = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rlueSorusturmaDurum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueOzelKod2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueOzelKod3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueOzelKod4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdSikayetEden = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTARAF_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSýfat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSikayetEden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exgrdSikayetEdilen = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.multiEditorRowProperties690 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties691 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties692 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties693 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties694 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties695 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties696 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties697 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties698 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties699 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties700 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties701 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties702 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.Tabs = new DevExpress.XtraTab.XtraTabControl();
            this.tbpGenel = new DevExpress.XtraTab.XtraTabPage();
            this.pnTemp = new System.Windows.Forms.Panel();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.grpSikayetNedenleri = new DevExpress.XtraEditors.GroupControl();
            this.ucSorusturmaNedenleri1 = new AdimAdimDavaKaydi.Sorusturma.UserControls.ucSorusturmaNedenleri();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.grpSikayetEden = new DevExpress.XtraEditors.GroupControl();
            this.grpSorumluAvukat = new DevExpress.XtraEditors.GroupControl();
            this.exgrdSorumluAvukat = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gvSAvukat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSorumluAvukat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYetkilimi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rLueSorumluAvukat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grpsikayetEdilen = new DevExpress.XtraEditors.GroupControl();
            this.lookUpExtender1 = new AdimAdimDavaKaydi.LookUpExtender();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.vgSorusturmaGenelBilgiler = new DevExpress.XtraVerticalGrid.VGridControl();
            this.HazirlikNo_Kod_Sayi = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.rowDosyaDurum = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSorusturmaDurumu = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.AdliBirim_Adliye_Gorev_No = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.Sikayet = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.HazýrlýkNo_Durum_Tarih = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.rowSORUMLU_SAVCI_CARI_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Refarans1_2_3 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.OzelKod1_2 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.OzelKod3_4 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.rowACIKLAMA = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.tabpSorusturmaNedenleri = new DevExpress.XtraTab.XtraTabPage();
            this.pnlSorusturma = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.ucKiymetliEvrak1 = new AdimAdimDavaKaydi.ucKiymetliEvrak();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.ucSorusturmaNedenTaraf1 = new AdimAdimDavaKaydi.Sorusturma.UserControls.ucSorusturmaNedenTaraf();
            this.xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
            this.ucGayriMenkul1 = new AdimAdimDavaKaydi.ucGayriMenkul();
            this.xtraTabPage7 = new DevExpress.XtraTab.XtraTabPage();
            this.tabAracBilgileri = new DevExpress.XtraTab.XtraTabControl();
            this.tpUcak = new DevExpress.XtraTab.XtraTabPage();
            this.ucUcakGemiArac1 = new AdimAdimDavaKaydi.ucUcakGemiArac();
            this.tpGemiBilgileri = new DevExpress.XtraTab.XtraTabPage();
            this.ugaGemi = new AdimAdimDavaKaydi.ucUcakGemiArac();
            this.tpAracBilgileri = new DevExpress.XtraTab.XtraTabPage();
            this.ugaArac = new AdimAdimDavaKaydi.ucUcakGemiArac();
            this.xtraTabPage8 = new DevExpress.XtraTab.XtraTabPage();
            this.ucPoliceBilgileri1 = new AdimAdimDavaKaydi.UserControls.ucPoliceBilgileri();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.AV001_TD_BIL_HAZIRLIKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlSorusturmaNedenleri = new DevExpress.XtraEditors.PanelControl();
            this.grdSikayetEdilenTaraf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTEMSIL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAVUKAT_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEMSIL_SEKLI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvSikayetEdilen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTarafKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSikayetEdilenSýfat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSikayetEdilen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueOzelKod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSikayetEdenTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTemsilEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafVAvukat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTemsilSekli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exgrdSikayetEden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AV001_TD_BIL_HAZIRLIK_TARAFBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdenTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdenSifat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdilenCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdenTemsil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdilenTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdilenSifat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdilenTemsil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimGorev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorumluSavci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGorev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateSikayet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateSikayet.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHazirlikDurum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rIAciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grLueSorumluAvk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetNeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rceSorusturma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetKonu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDosyaDurum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelKod1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdenCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKarsiTarafVAvukat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTemsilEkleSEdilen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueSorusturmaDurum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelKod2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelKod3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelKod4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSikayetEden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exgrdSikayetEdilen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tabs)).BeginInit();
            this.Tabs.SuspendLayout();
            this.tbpGenel.SuspendLayout();
            this.pnTemp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSikayetNedenleri)).BeginInit();
            this.grpSikayetNedenleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSikayetEden)).BeginInit();
            this.grpSikayetEden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSorumluAvukat)).BeginInit();
            this.grpSorumluAvukat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exgrdSorumluAvukat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSAvukat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorumluAvukat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpsikayetEdilen)).BeginInit();
            this.grpsikayetEdilen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vgSorusturmaGenelBilgiler)).BeginInit();
            this.tabpSorusturmaNedenleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSorusturma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage5.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            this.xtraTabPage6.SuspendLayout();
            this.xtraTabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabAracBilgileri)).BeginInit();
            this.tabAracBilgileri.SuspendLayout();
            this.tpUcak.SuspendLayout();
            this.tpGemiBilgileri.SuspendLayout();
            this.tpAracBilgileri.SuspendLayout();
            this.xtraTabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AV001_TD_BIL_HAZIRLIKBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSorusturmaNedenleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSikayetEdilenTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSikayetEdilen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelKod)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(985, 33);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 687);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Location = new System.Drawing.Point(0, 33);
            this.c_pnlSol.Size = new System.Drawing.Size(17, 687);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 716);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(1080, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(930, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(1005, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.clientPanel);
            this.c_pnlContainer.Size = new System.Drawing.Size(1080, 741);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.clientPanel, 0);
            // 
            // grdSikayetEdenTaraf
            // 
            this.grdSikayetEdenTaraf.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsikayetEdenTEMSIL_ID,
            this.colSikayetEdenAVUKAT_CARI_ID,
            this.colSikayetEdenTEMSIL_SEKLI});
            this.grdSikayetEdenTaraf.GridControl = this.exgrdSikayetEden;
            this.grdSikayetEdenTaraf.Name = "grdSikayetEdenTaraf";
            this.grdSikayetEdenTaraf.OptionsDetail.AllowExpandEmptyDetails = true;
            this.grdSikayetEdenTaraf.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.grdSikayetEdenTaraf.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grdSikayetEdenTaraf.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grdSikayetEdenTaraf.OptionsView.ShowGroupPanel = false;
            // 
            // colsikayetEdenTEMSIL_ID
            // 
            this.colsikayetEdenTEMSIL_ID.Caption = "TEMSIL";
            this.colsikayetEdenTEMSIL_ID.ColumnEdit = this.rbtnTemsilEkle;
            this.colsikayetEdenTEMSIL_ID.FieldName = "TEMSIL_ID";
            this.colsikayetEdenTEMSIL_ID.Name = "colsikayetEdenTEMSIL_ID";
            this.colsikayetEdenTEMSIL_ID.Visible = true;
            this.colsikayetEdenTEMSIL_ID.VisibleIndex = 0;
            // 
            // rbtnTemsilEkle
            // 
            this.rbtnTemsilEkle.AutoHeight = false;
            this.rbtnTemsilEkle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rbtnTemsilEkle.Name = "rbtnTemsilEkle";
            this.rbtnTemsilEkle.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rbtnTemsilEkle_ButtonClick);
            // 
            // colSikayetEdenAVUKAT_CARI_ID
            // 
            this.colSikayetEdenAVUKAT_CARI_ID.Caption = "AVUKAT";
            this.colSikayetEdenAVUKAT_CARI_ID.ColumnEdit = this.rLueTarafVAvukat;
            this.colSikayetEdenAVUKAT_CARI_ID.FieldName = "AVUKAT_CARI_ID";
            this.colSikayetEdenAVUKAT_CARI_ID.Name = "colSikayetEdenAVUKAT_CARI_ID";
            this.colSikayetEdenAVUKAT_CARI_ID.Visible = true;
            this.colSikayetEdenAVUKAT_CARI_ID.VisibleIndex = 1;
            // 
            // rLueTarafVAvukat
            // 
            this.rLueTarafVAvukat.AutoHeight = false;
            this.rLueTarafVAvukat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTarafVAvukat.Name = "rLueTarafVAvukat";
            // 
            // colSikayetEdenTEMSIL_SEKLI
            // 
            this.colSikayetEdenTEMSIL_SEKLI.Caption = "TEMSIL SEKLI";
            this.colSikayetEdenTEMSIL_SEKLI.ColumnEdit = this.rLueTemsilSekli;
            this.colSikayetEdenTEMSIL_SEKLI.FieldName = "TEMSIL_SEKLI_ID";
            this.colSikayetEdenTEMSIL_SEKLI.Name = "colSikayetEdenTEMSIL_SEKLI";
            this.colSikayetEdenTEMSIL_SEKLI.Visible = true;
            this.colSikayetEdenTEMSIL_SEKLI.VisibleIndex = 2;
            // 
            // rLueTemsilSekli
            // 
            this.rLueTemsilSekli.AutoHeight = false;
            this.rLueTemsilSekli.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTemsilSekli.Name = "rLueTemsilSekli";
            this.rLueTemsilSekli.NullText = "Temsil";
            // 
            // exgrdSikayetEden
            // 
            this.exgrdSikayetEden.CustomButtonlarGorunmesin = false;
            this.exgrdSikayetEden.DataSource = this.AV001_TD_BIL_HAZIRLIK_TARAFBindingSource;
            this.exgrdSikayetEden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exgrdSikayetEden.DoNotExtendEmbedNavigator = false;
            this.exgrdSikayetEden.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.exgrdSikayetEden.EmbeddedNavigator.Buttons.First.Visible = false;
            this.exgrdSikayetEden.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.exgrdSikayetEden.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.exgrdSikayetEden.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.exgrdSikayetEden.EmbeddedNavigator.TextStringFormat = "{0} / {1}";
            this.exgrdSikayetEden.ExternalRepository = this.perRSorusturmaGenelBilgiler;
            this.exgrdSikayetEden.FilterText = null;
            this.exgrdSikayetEden.FilterValue = null;
            this.exgrdSikayetEden.GridlerDuzenlenebilir = true;
            this.exgrdSikayetEden.GridsFilterControl = null;
            gridLevelNode2.LevelTemplate = this.grdSikayetEdenTaraf;
            gridLevelNode2.RelationName = "AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection";
            this.exgrdSikayetEden.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.exgrdSikayetEden.Location = new System.Drawing.Point(2, 21);
            this.exgrdSikayetEden.MainView = this.grdSikayetEden;
            this.exgrdSikayetEden.MyGridStyle = null;
            this.exgrdSikayetEden.Name = "exgrdSikayetEden";
            this.exgrdSikayetEden.ShowOnlyPredefinedDetails = true;
            this.exgrdSikayetEden.ShowRowNumbers = false;
            this.exgrdSikayetEden.SilmeKaldirilsin = false;
            this.exgrdSikayetEden.Size = new System.Drawing.Size(339, 178);
            this.exgrdSikayetEden.TabIndex = 2;
            this.exgrdSikayetEden.TemizleKaldirGorunsunmu = false;
            this.exgrdSikayetEden.UniqueId = "78bce619-d1a5-4449-a402-c91502e950f3";
            this.exgrdSikayetEden.UseEmbeddedNavigator = true;
            this.exgrdSikayetEden.UseHyperDragDrop = false;
            this.exgrdSikayetEden.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdSikayetEden,
            this.grdSikayetEdenTaraf});
            this.exgrdSikayetEden.DataSourceChanged += new System.EventHandler(this.exgrdSikayetEden_DataSourceChanged);
            // 
            // AV001_TD_BIL_HAZIRLIK_TARAFBindingSource
            // 
            this.AV001_TD_BIL_HAZIRLIK_TARAFBindingSource.DataSource = typeof(AvukatProLib2.Entities.AV001_TD_BIL_HAZIRLIK_TARAF);
            // 
            // perRSorusturmaGenelBilgiler
            // 
            this.perRSorusturmaGenelBilgiler.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueSikayetEdenTaraf,
            this.rLueSikayetEdenSifat,
            this.rLueSikayetEdilenCari,
            this.rLueSikayetEdenTemsil,
            this.rLueSikayetEdilenTaraf,
            this.rLueSikayetEdilenSifat,
            this.rLueSikayetEdilenTemsil,
            this.rLueAdliye,
            this.rLueAdliBirimNo,
            this.rLueAdliBirimGorev,
            this.rLueSorumluSavci,
            this.rLueTemsilSekli,
            this.rLueGorev,
            this.rDateSikayet,
            this.rLueHazirlikDurum,
            this.rIAciklama,
            this.grLueSorumluAvk,
            this.rLueSikayetNeden,
            this.rceSorusturma,
            this.rLueSikayetKonu,
            this.rlueDosyaDurum,
            this.rLueOzelKod1,
            this.rLueSikayetEdenCari,
            this.rLueTarafVAvukat,
            this.rLueKarsiTarafVAvukat,
            this.rbtnTemsilEkle,
            this.rbtnTemsilEkleSEdilen,
            this.rlueSorusturmaDurum,
            this.rLueOzelKod2,
            this.rLueOzelKod3,
            this.rLueOzelKod4});
            // 
            // rLueSikayetEdenTaraf
            // 
            this.rLueSikayetEdenTaraf.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSikayetEdenTaraf.Name = "rLueSikayetEdenTaraf";
            this.rLueSikayetEdenTaraf.NullText = "Taraf";
            // 
            // rLueSikayetEdenSifat
            // 
            this.rLueSikayetEdenSifat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSikayetEdenSifat.Name = "rLueSikayetEdenSifat";
            this.rLueSikayetEdenSifat.NullText = "Sýfat";
            // 
            // rLueSikayetEdilenCari
            // 
            this.rLueSikayetEdilenCari.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rLueSikayetEdilenCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Kiþi Ekle", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14, "", "mEkle", null, true)});
            this.rLueSikayetEdilenCari.Name = "rLueSikayetEdilenCari";
            this.rLueSikayetEdilenCari.NullText = "Sikayet Eden Ýsim";
            this.rLueSikayetEdilenCari.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rLueSikayetEdilenCari.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.rLueSikayetEdilenCari_ProcessNewValue);
            this.rLueSikayetEdilenCari.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rLueSikayetEdilenCari_ButtonClick);
            // 
            // rLueSikayetEdenTemsil
            // 
            this.rLueSikayetEdenTemsil.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSikayetEdenTemsil.Name = "rLueSikayetEdenTemsil";
            this.rLueSikayetEdenTemsil.NullText = "Temsil";
            // 
            // rLueSikayetEdilenTaraf
            // 
            this.rLueSikayetEdilenTaraf.AutoHeight = false;
            this.rLueSikayetEdilenTaraf.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSikayetEdilenTaraf.Name = "rLueSikayetEdilenTaraf";
            this.rLueSikayetEdilenTaraf.NullText = "Taraf";
            // 
            // rLueSikayetEdilenSifat
            // 
            this.rLueSikayetEdilenSifat.AutoHeight = false;
            this.rLueSikayetEdilenSifat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSikayetEdilenSifat.Name = "rLueSikayetEdilenSifat";
            this.rLueSikayetEdilenSifat.NullText = "Sýfat";
            // 
            // rLueSikayetEdilenTemsil
            // 
            this.rLueSikayetEdilenTemsil.AutoHeight = false;
            this.rLueSikayetEdilenTemsil.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSikayetEdilenTemsil.Name = "rLueSikayetEdilenTemsil";
            this.rLueSikayetEdilenTemsil.NullText = "Temsil";
            // 
            // rLueAdliye
            // 
            this.rLueAdliye.AutoHeight = false;
            this.rLueAdliye.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliye.Name = "rLueAdliye";
            this.rLueAdliye.NullText = "Adliye";
            // 
            // rLueAdliBirimNo
            // 
            this.rLueAdliBirimNo.AutoHeight = false;
            this.rLueAdliBirimNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimNo.Name = "rLueAdliBirimNo";
            this.rLueAdliBirimNo.NullText = "No";
            // 
            // rLueAdliBirimGorev
            // 
            this.rLueAdliBirimGorev.AutoHeight = false;
            this.rLueAdliBirimGorev.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimGorev.Name = "rLueAdliBirimGorev";
            this.rLueAdliBirimGorev.NullText = "Görev";
            // 
            // rLueSorumluSavci
            // 
            this.rLueSorumluSavci.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rLueSorumluSavci.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSorumluSavci.Name = "rLueSorumluSavci";
            this.rLueSorumluSavci.NullText = "Savcý";
            this.rLueSorumluSavci.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rLueSorumluSavci.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.rLueSorumluSavci_ProcessNewValue);
            this.rLueSorumluSavci.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rLueSorumluSavci_ButtonClick);
            // 
            // rLueGorev
            // 
            this.rLueGorev.AutoHeight = false;
            this.rLueGorev.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueGorev.Name = "rLueGorev";
            // 
            // rDateSikayet
            // 
            this.rDateSikayet.AutoHeight = false;
            this.rDateSikayet.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rDateSikayet.Name = "rDateSikayet";
            this.rDateSikayet.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rLueHazirlikDurum
            // 
            this.rLueHazirlikDurum.AutoHeight = false;
            this.rLueHazirlikDurum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueHazirlikDurum.Name = "rLueHazirlikDurum";
            this.rLueHazirlikDurum.NullText = "Hazýrlýk Durumu";
            // 
            // rIAciklama
            // 
            this.rIAciklama.AutoHeight = false;
            this.rIAciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rIAciklama.Name = "rIAciklama";
            // 
            // grLueSorumluAvk
            // 
            this.grLueSorumluAvk.AutoHeight = false;
            this.grLueSorumluAvk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grLueSorumluAvk.Name = "grLueSorumluAvk";
            this.grLueSorumluAvk.NullText = "SorumluAvk";
            this.grLueSorumluAvk.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Kod";
            this.gridColumn8.FieldName = "KOD";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Adý";
            this.gridColumn9.FieldName = "AD";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // rLueSikayetNeden
            // 
            this.rLueSikayetNeden.AutoHeight = false;
            this.rLueSikayetNeden.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSikayetNeden.Name = "rLueSikayetNeden";
            // 
            // rceSorusturma
            // 
            this.rceSorusturma.AutoHeight = false;
            this.rceSorusturma.Name = "rceSorusturma";
            // 
            // rLueSikayetKonu
            // 
            this.rLueSikayetKonu.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rLueSikayetKonu.AutoHeight = false;
            this.rLueSikayetKonu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSikayetKonu.Name = "rLueSikayetKonu";
            this.rLueSikayetKonu.NullText = "Sikayet Konu";
            this.rLueSikayetKonu.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rLueSikayetKonu.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.rLueSikayetKonu_ProcessNewValue);
            this.rLueSikayetKonu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rLueSikayetKonu_ButtonClick);
            // 
            // rlueDosyaDurum
            // 
            this.rlueDosyaDurum.AutoHeight = false;
            this.rlueDosyaDurum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueDosyaDurum.Name = "rlueDosyaDurum";
            this.rlueDosyaDurum.NullText = "Dosya Durum";
            // 
            // rLueOzelKod1
            // 
            this.rLueOzelKod1.AutoHeight = false;
            this.rLueOzelKod1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueOzelKod1.Name = "rLueOzelKod1";
            this.rLueOzelKod1.NullText = "Özel Kod ";
            // 
            // rLueSikayetEdenCari
            // 
            this.rLueSikayetEdenCari.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rLueSikayetEdenCari.AutoHeight = false;
            this.rLueSikayetEdenCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Kiþi Ekle", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, "", "mEkle", null, true)});
            this.rLueSikayetEdenCari.Name = "rLueSikayetEdenCari";
            this.rLueSikayetEdenCari.NullText = "Cari";
            this.rLueSikayetEdenCari.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rLueSikayetEdenCari.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.rLueSikayetEdenCari_ProcessNewValue);
            this.rLueSikayetEdenCari.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rLueSikayetEdenCari_ButtonClick);
            // 
            // rLueKarsiTarafVAvukat
            // 
            this.rLueKarsiTarafVAvukat.AutoHeight = false;
            this.rLueKarsiTarafVAvukat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueKarsiTarafVAvukat.Name = "rLueKarsiTarafVAvukat";
            // 
            // rbtnTemsilEkleSEdilen
            // 
            this.rbtnTemsilEkleSEdilen.AutoHeight = false;
            this.rbtnTemsilEkleSEdilen.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rbtnTemsilEkleSEdilen.Name = "rbtnTemsilEkleSEdilen";
            this.rbtnTemsilEkleSEdilen.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rbtnTemsilEkleSEdilen_ButtonClick);
            // 
            // rlueSorusturmaDurum
            // 
            this.rlueSorusturmaDurum.AutoHeight = false;
            this.rlueSorusturmaDurum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueSorusturmaDurum.Name = "rlueSorusturmaDurum";
            // 
            // rLueOzelKod2
            // 
            this.rLueOzelKod2.AutoHeight = false;
            this.rLueOzelKod2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueOzelKod2.Name = "rLueOzelKod2";
            // 
            // rLueOzelKod3
            // 
            this.rLueOzelKod3.AutoHeight = false;
            this.rLueOzelKod3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueOzelKod3.Name = "rLueOzelKod3";
            // 
            // rLueOzelKod4
            // 
            this.rLueOzelKod4.AutoHeight = false;
            this.rLueOzelKod4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueOzelKod4.Name = "rLueOzelKod4";
            // 
            // grdSikayetEden
            // 
            this.grdSikayetEden.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTARAF_KODU,
            this.colSýfat,
            this.colSikayetEden});
            this.grdSikayetEden.GridControl = this.exgrdSikayetEden;
            this.grdSikayetEden.IndicatorWidth = 20;
            this.grdSikayetEden.Name = "grdSikayetEden";
            this.grdSikayetEden.OptionsDetail.AllowExpandEmptyDetails = true;
            this.grdSikayetEden.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.grdSikayetEden.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grdSikayetEden.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.grdSikayetEden.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grdSikayetEden.OptionsView.ShowGroupPanel = false;
            this.grdSikayetEden.MasterRowExpanding += new DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventHandler(this.grdSikayetEden_MasterRowExpanding);
            // 
            // colTARAF_KODU
            // 
            this.colTARAF_KODU.Caption = "T.K";
            this.colTARAF_KODU.ColumnEdit = this.rLueSikayetEdenTaraf;
            this.colTARAF_KODU.FieldName = "TARAF_KODU";
            this.colTARAF_KODU.Name = "colTARAF_KODU";
            this.colTARAF_KODU.Visible = true;
            this.colTARAF_KODU.VisibleIndex = 0;
            // 
            // colSýfat
            // 
            this.colSýfat.Caption = "Sýfat";
            this.colSýfat.ColumnEdit = this.rLueSikayetEdenSifat;
            this.colSýfat.FieldName = "TARAF_SIFAT_ID";
            this.colSýfat.Name = "colSýfat";
            this.colSýfat.Visible = true;
            this.colSýfat.VisibleIndex = 1;
            // 
            // colSikayetEden
            // 
            this.colSikayetEden.Caption = "Þikayet Eden";
            this.colSikayetEden.ColumnEdit = this.rLueSikayetEdenCari;
            this.colSikayetEden.FieldName = "CARI_ID";
            this.colSikayetEden.Name = "colSikayetEden";
            this.colSikayetEden.Visible = true;
            this.colSikayetEden.VisibleIndex = 2;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.exgrdSikayetEdilen;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "TEMSIL";
            this.gridColumn1.ColumnEdit = this.rbtnTemsilEkleSEdilen;
            this.gridColumn1.FieldName = "TEMSIL_ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "AVUKAT";
            this.gridColumn2.ColumnEdit = this.rLueKarsiTarafVAvukat;
            this.gridColumn2.FieldName = "AVUKAT_CARI_ID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "TEMSIL SEKLI";
            this.gridColumn3.ColumnEdit = this.rLueTemsilSekli;
            this.gridColumn3.FieldName = "TEMSIL_SEKLI_ID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // exgrdSikayetEdilen
            // 
            this.exgrdSikayetEdilen.CustomButtonlarGorunmesin = false;
            this.exgrdSikayetEdilen.DataSource = this.AV001_TD_BIL_HAZIRLIK_TARAFBindingSource;
            this.exgrdSikayetEdilen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exgrdSikayetEdilen.DoNotExtendEmbedNavigator = false;
            this.exgrdSikayetEdilen.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.exgrdSikayetEdilen.EmbeddedNavigator.Buttons.First.Visible = false;
            this.exgrdSikayetEdilen.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.exgrdSikayetEdilen.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.exgrdSikayetEdilen.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.exgrdSikayetEdilen.EmbeddedNavigator.TextStringFormat = "{0} / {1}";
            this.exgrdSikayetEdilen.ExternalRepository = this.perRSorusturmaGenelBilgiler;
            this.exgrdSikayetEdilen.FilterText = null;
            this.exgrdSikayetEdilen.FilterValue = null;
            this.exgrdSikayetEdilen.GridlerDuzenlenebilir = true;
            this.exgrdSikayetEdilen.GridsFilterControl = null;
            gridLevelNode1.LevelTemplate = this.gridView1;
            gridLevelNode1.RelationName = "AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection";
            this.exgrdSikayetEdilen.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.exgrdSikayetEdilen.Location = new System.Drawing.Point(2, 21);
            this.exgrdSikayetEdilen.MainView = this.gridView2;
            this.exgrdSikayetEdilen.MyGridStyle = null;
            this.exgrdSikayetEdilen.Name = "exgrdSikayetEdilen";
            this.exgrdSikayetEdilen.ShowOnlyPredefinedDetails = true;
            this.exgrdSikayetEdilen.ShowRowNumbers = false;
            this.exgrdSikayetEdilen.SilmeKaldirilsin = false;
            this.exgrdSikayetEdilen.Size = new System.Drawing.Size(276, 178);
            this.exgrdSikayetEdilen.TabIndex = 2;
            this.exgrdSikayetEdilen.TemizleKaldirGorunsunmu = false;
            this.exgrdSikayetEdilen.UniqueId = "e0abec7e-c10a-4f95-95f3-d0b204248834";
            this.exgrdSikayetEdilen.UseEmbeddedNavigator = true;
            this.exgrdSikayetEdilen.UseHyperDragDrop = false;
            this.exgrdSikayetEdilen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2,
            this.gridView1});
            this.exgrdSikayetEdilen.DataSourceChanged += new System.EventHandler(this.exgrdSikayetEdilen_DataSourceChanged);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView2.GridControl = this.exgrdSikayetEdilen;
            this.gridView2.IndicatorWidth = 20;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView2.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.MasterRowExpanding += new DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventHandler(this.gridView2_MasterRowExpanding);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "T.K";
            this.gridColumn4.ColumnEdit = this.rLueSikayetEdilenTaraf;
            this.gridColumn4.FieldName = "TARAF_KODU";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Sýfat";
            this.gridColumn5.ColumnEdit = this.rLueSikayetEdilenSifat;
            this.gridColumn5.FieldName = "TARAF_SIFAT_ID";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Þikayet Edilen ";
            this.gridColumn6.ColumnEdit = this.rLueSikayetEdilenCari;
            this.gridColumn6.FieldName = "CARI_ID";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            // 
            // multiEditorRowProperties690
            // 
            this.multiEditorRowProperties690.Caption = "Raf No";
            this.multiEditorRowProperties690.FieldName = "HAZIRLIK_NO";
            // 
            // multiEditorRowProperties691
            // 
            this.multiEditorRowProperties691.Caption = "Savcýlýk :";
            this.multiEditorRowProperties691.CellWidth = 74;
            this.multiEditorRowProperties691.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.multiEditorRowProperties691.RowEdit = this.rLueAdliye;
            this.multiEditorRowProperties691.Width = 71;
            // 
            // multiEditorRowProperties692
            // 
            this.multiEditorRowProperties692.Caption = "Þikayet Tarihi";
            this.multiEditorRowProperties692.CellWidth = 96;
            this.multiEditorRowProperties692.FieldName = "SIKAYET_TARIHI";
            this.multiEditorRowProperties692.RowEdit = this.rDateSikayet;
            this.multiEditorRowProperties692.Width = 87;
            // 
            // multiEditorRowProperties693
            // 
            this.multiEditorRowProperties693.Caption = "Þikayet Konu ";
            this.multiEditorRowProperties693.CellWidth = 107;
            this.multiEditorRowProperties693.FieldName = "SIKAYET_KONU_ID";
            this.multiEditorRowProperties693.RowEdit = this.rLueSikayetKonu;
            this.multiEditorRowProperties693.Width = 133;
            // 
            // multiEditorRowProperties694
            // 
            this.multiEditorRowProperties694.Caption = "Soruþturma Tarihi";
            this.multiEditorRowProperties694.CellWidth = 54;
            this.multiEditorRowProperties694.FieldName = "HAZIRLIK_TARIH";
            this.multiEditorRowProperties694.Width = 86;
            // 
            // multiEditorRowProperties695
            // 
            this.multiEditorRowProperties695.Caption = "Soruþturma Esas No";
            this.multiEditorRowProperties695.CellWidth = 68;
            this.multiEditorRowProperties695.FieldName = "HAZIRLIK_ESAS_NO";
            this.multiEditorRowProperties695.Width = 105;
            // 
            // multiEditorRowProperties696
            // 
            this.multiEditorRowProperties696.Caption = "Referans 1";
            this.multiEditorRowProperties696.FieldName = "REFERANS_NO";
            // 
            // multiEditorRowProperties697
            // 
            this.multiEditorRowProperties697.Caption = "Referans 2";
            this.multiEditorRowProperties697.FieldName = "REFERANS_NO2";
            // 
            // multiEditorRowProperties698
            // 
            this.multiEditorRowProperties698.Caption = "Referans 3";
            this.multiEditorRowProperties698.FieldName = "REFERANS_NO3";
            // 
            // multiEditorRowProperties699
            // 
            this.multiEditorRowProperties699.Caption = "Özel Kod 1";
            this.multiEditorRowProperties699.FieldName = "OZEL_KOD_1_ID";
            this.multiEditorRowProperties699.RowEdit = this.rLueOzelKod1;
            // 
            // multiEditorRowProperties700
            // 
            this.multiEditorRowProperties700.Caption = "Özel Kod 2";
            this.multiEditorRowProperties700.FieldName = "OZEL_KOD_2_ID";
            this.multiEditorRowProperties700.RowEdit = this.rLueOzelKod2;
            // 
            // multiEditorRowProperties701
            // 
            this.multiEditorRowProperties701.Caption = "Özel Kod 3";
            this.multiEditorRowProperties701.FieldName = "OZEL_KOD_3_ID";
            this.multiEditorRowProperties701.RowEdit = this.rLueOzelKod3;
            this.multiEditorRowProperties701.Width = 72;
            // 
            // multiEditorRowProperties702
            // 
            this.multiEditorRowProperties702.Caption = "Özel Kod 4";
            this.multiEditorRowProperties702.FieldName = "OZEL_KOD_4_ID";
            this.multiEditorRowProperties702.RowEdit = this.rLueOzelKod4;
            this.multiEditorRowProperties702.Width = 72;
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.Tabs);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 0);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(1080, 716);
            this.clientPanel.TabIndex = 2;
            // 
            // Tabs
            // 
            this.Tabs.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Tabs.Appearance.Options.UseBackColor = true;
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.Tabs.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedTabPage = this.tbpGenel;
            this.Tabs.Size = new System.Drawing.Size(1080, 716);
            this.Tabs.TabIndex = 1;
            this.Tabs.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tbpGenel,
            this.tabpSorusturmaNedenleri});
            this.Tabs.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.Tabs_SelectedPageChanging);
            // 
            // tbpGenel
            // 
            this.tbpGenel.Controls.Add(this.pnTemp);
            this.tbpGenel.Image = ((System.Drawing.Image)(resources.GetObject("tbpGenel.Image")));
            this.tbpGenel.Name = "tbpGenel";
            this.tbpGenel.Size = new System.Drawing.Size(938, 710);
            this.tbpGenel.Text = "Genel Bilgiler ";
            // 
            // pnTemp
            // 
            this.pnTemp.Controls.Add(this.panelControl4);
            this.pnTemp.Controls.Add(this.panelControl3);
            this.pnTemp.Controls.Add(this.panelControl2);
            this.pnTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTemp.Location = new System.Drawing.Point(0, 0);
            this.pnTemp.Name = "pnTemp";
            this.pnTemp.Size = new System.Drawing.Size(938, 710);
            this.pnTemp.TabIndex = 0;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.grpSikayetNedenleri);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 344);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(938, 366);
            this.panelControl4.TabIndex = 7;
            // 
            // grpSikayetNedenleri
            // 
            this.grpSikayetNedenleri.Controls.Add(this.ucSorusturmaNedenleri1);
            this.grpSikayetNedenleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSikayetNedenleri.Location = new System.Drawing.Point(2, 2);
            this.grpSikayetNedenleri.Name = "grpSikayetNedenleri";
            this.grpSikayetNedenleri.Size = new System.Drawing.Size(934, 362);
            this.grpSikayetNedenleri.TabIndex = 6;
            this.grpSikayetNedenleri.Text = "Soruþturma Nedenleri";
            // 
            // ucSorusturmaNedenleri1
            // 
            this.ucSorusturmaNedenleri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSorusturmaNedenleri1.Location = new System.Drawing.Point(2, 21);
            this.ucSorusturmaNedenleri1.MyDataSource = null;
            this.ucSorusturmaNedenleri1.Name = "ucSorusturmaNedenleri1";
            this.ucSorusturmaNedenleri1.Size = new System.Drawing.Size(930, 339);
            this.ucSorusturmaNedenleri1.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.panelControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 135);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(938, 209);
            this.panelControl3.TabIndex = 7;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grpSikayetEden);
            this.panelControl1.Controls.Add(this.grpSorumluAvukat);
            this.panelControl1.Controls.Add(this.grpsikayetEdilen);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(934, 205);
            this.panelControl1.TabIndex = 4;
            // 
            // grpSikayetEden
            // 
            this.grpSikayetEden.Controls.Add(this.exgrdSikayetEdilen);
            this.grpSikayetEden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSikayetEden.Location = new System.Drawing.Point(345, 2);
            this.grpSikayetEden.Name = "grpSikayetEden";
            this.grpSikayetEden.Size = new System.Drawing.Size(280, 201);
            this.grpSikayetEden.TabIndex = 0;
            this.grpSikayetEden.Text = "Þikayet Edilen";
            // 
            // grpSorumluAvukat
            // 
            this.grpSorumluAvukat.Controls.Add(this.exgrdSorumluAvukat);
            this.grpSorumluAvukat.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpSorumluAvukat.Location = new System.Drawing.Point(625, 2);
            this.grpSorumluAvukat.Name = "grpSorumluAvukat";
            this.grpSorumluAvukat.Size = new System.Drawing.Size(307, 201);
            this.grpSorumluAvukat.TabIndex = 0;
            this.grpSorumluAvukat.Text = "SorumluAvukat";
            // 
            // exgrdSorumluAvukat
            // 
            this.exgrdSorumluAvukat.CustomButtonlarGorunmesin = false;
            this.exgrdSorumluAvukat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exgrdSorumluAvukat.DoNotExtendEmbedNavigator = false;
            this.exgrdSorumluAvukat.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.exgrdSorumluAvukat.EmbeddedNavigator.Buttons.First.Visible = false;
            this.exgrdSorumluAvukat.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.exgrdSorumluAvukat.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.exgrdSorumluAvukat.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.exgrdSorumluAvukat.EmbeddedNavigator.TextStringFormat = "{0} / {1}";
            this.exgrdSorumluAvukat.ExternalRepository = this.perRSorusturmaGenelBilgiler;
            this.exgrdSorumluAvukat.FilterText = null;
            this.exgrdSorumluAvukat.FilterValue = null;
            this.exgrdSorumluAvukat.GridlerDuzenlenebilir = true;
            this.exgrdSorumluAvukat.GridsFilterControl = null;
            this.exgrdSorumluAvukat.Location = new System.Drawing.Point(2, 21);
            this.exgrdSorumluAvukat.MainView = this.gvSAvukat;
            this.exgrdSorumluAvukat.MyGridStyle = null;
            this.exgrdSorumluAvukat.Name = "exgrdSorumluAvukat";
            this.exgrdSorumluAvukat.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueSorumluAvukat,
            this.repositoryItemCheckEdit1});
            this.exgrdSorumluAvukat.ShowRowNumbers = false;
            this.exgrdSorumluAvukat.SilmeKaldirilsin = false;
            this.exgrdSorumluAvukat.Size = new System.Drawing.Size(303, 178);
            this.exgrdSorumluAvukat.TabIndex = 1;
            this.exgrdSorumluAvukat.TemizleKaldirGorunsunmu = false;
            this.exgrdSorumluAvukat.UniqueId = "75e0c3d8-e096-4a8c-9300-dd91784dc183";
            this.exgrdSorumluAvukat.UseEmbeddedNavigator = true;
            this.exgrdSorumluAvukat.UseHyperDragDrop = false;
            this.exgrdSorumluAvukat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSAvukat});
            // 
            // gvSAvukat
            // 
            this.gvSAvukat.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSorumluAvukat,
            this.colYetkilimi});
            this.gvSAvukat.GridControl = this.exgrdSorumluAvukat;
            this.gvSAvukat.IndicatorWidth = 20;
            this.gvSAvukat.Name = "gvSAvukat";
            this.gvSAvukat.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gvSAvukat.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gvSAvukat.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvSAvukat.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gvSAvukat.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvSAvukat.OptionsView.ShowGroupPanel = false;
            // 
            // colSorumluAvukat
            // 
            this.colSorumluAvukat.Caption = "Sorumlu Avukat";
            this.colSorumluAvukat.ColumnEdit = this.grLueSorumluAvk;
            this.colSorumluAvukat.FieldName = "CARI_ID";
            this.colSorumluAvukat.Name = "colSorumluAvukat";
            this.colSorumluAvukat.Visible = true;
            this.colSorumluAvukat.VisibleIndex = 0;
            // 
            // colYetkilimi
            // 
            this.colYetkilimi.Caption = "YETKÝLÝMÝ";
            this.colYetkilimi.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colYetkilimi.FieldName = "YETKILI_MI";
            this.colYetkilimi.Name = "colYetkilimi";
            this.colYetkilimi.Visible = true;
            this.colYetkilimi.VisibleIndex = 1;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // rLueSorumluAvukat
            // 
            this.rLueSorumluAvukat.AutoHeight = false;
            this.rLueSorumluAvukat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSorumluAvukat.Name = "rLueSorumluAvukat";
            this.rLueSorumluAvukat.NullText = "Sorumlu Avukat";
            // 
            // grpsikayetEdilen
            // 
            this.grpsikayetEdilen.Controls.Add(this.exgrdSikayetEden);
            this.grpsikayetEdilen.Controls.Add(this.lookUpExtender1);
            this.grpsikayetEdilen.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpsikayetEdilen.Location = new System.Drawing.Point(2, 2);
            this.grpsikayetEdilen.Name = "grpsikayetEdilen";
            this.grpsikayetEdilen.Size = new System.Drawing.Size(343, 201);
            this.grpsikayetEdilen.TabIndex = 0;
            this.grpsikayetEdilen.Text = "Þikayet Eden ";
            // 
            // lookUpExtender1
            // 
            this.lookUpExtender1.AddLookUp = null;
            this.lookUpExtender1.AddRepoLookUp = null;
            this.lookUpExtender1.Location = new System.Drawing.Point(117, 128);
            this.lookUpExtender1.LookUpEditCollection = new DevExpress.XtraEditors.LookUpEdit[0];
            this.lookUpExtender1.Name = "lookUpExtender1";
            this.lookUpExtender1.RemoveLookUp = null;
            this.lookUpExtender1.RemoveRepoLookUp = null;
            this.lookUpExtender1.RepoLookUpEditCollection = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit[] {
        this.rLueSorumluSavci,
        this.rLueSikayetEdenCari,
        this.rLueSikayetKonu,
        this.rLueOzelKod1,
        this.rLueSikayetEdilenCari};
            this.lookUpExtender1.Size = new System.Drawing.Size(75, 23);
            this.lookUpExtender1.TabIndex = 1;
            this.lookUpExtender1.Text = "lookUpExtender1";
            this.lookUpExtender1.Visible = false;
            this.lookUpExtender1.OnClickOrProcessNewValue += new AdimAdimDavaKaydi.LookUpExtenderEventHandler(this.lookUpExtender1_OnClickOrProcessNewValue);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.tableLayoutPanel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(938, 135);
            this.panelControl2.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.vgSorusturmaGenelBilgiler, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.12658F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(934, 131);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // vgSorusturmaGenelBilgiler
            // 
            this.vgSorusturmaGenelBilgiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgSorusturmaGenelBilgiler.ExternalRepository = this.perRSorusturmaGenelBilgiler;
            this.vgSorusturmaGenelBilgiler.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.BandsView;
            this.vgSorusturmaGenelBilgiler.Location = new System.Drawing.Point(3, 3);
            this.vgSorusturmaGenelBilgiler.Name = "vgSorusturmaGenelBilgiler";
            this.vgSorusturmaGenelBilgiler.RecordWidth = 237;
            this.vgSorusturmaGenelBilgiler.RowHeaderWidth = 285;
            this.vgSorusturmaGenelBilgiler.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.HazirlikNo_Kod_Sayi,
            this.rowDosyaDurum,
            this.rowSorusturmaDurumu,
            this.AdliBirim_Adliye_Gorev_No,
            this.Sikayet,
            this.HazýrlýkNo_Durum_Tarih,
            this.rowSORUMLU_SAVCI_CARI_ID,
            this.Refarans1_2_3,
            this.OzelKod1_2,
            this.OzelKod3_4,
            this.rowACIKLAMA});
            this.vgSorusturmaGenelBilgiler.Size = new System.Drawing.Size(928, 125);
            this.vgSorusturmaGenelBilgiler.TabIndex = 1;
            // 
            // HazirlikNo_Kod_Sayi
            // 
            this.HazirlikNo_Kod_Sayi.Expanded = false;
            this.HazirlikNo_Kod_Sayi.Height = 16;
            this.HazirlikNo_Kod_Sayi.Name = "HazirlikNo_Kod_Sayi";
            this.HazirlikNo_Kod_Sayi.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties690});
            // 
            // rowDosyaDurum
            // 
            this.rowDosyaDurum.Name = "rowDosyaDurum";
            this.rowDosyaDurum.Properties.Caption = "Dosya Durum :";
            this.rowDosyaDurum.Properties.FieldName = "DOSYA_DURUM_ID";
            this.rowDosyaDurum.Properties.RowEdit = this.rlueDosyaDurum;
            // 
            // rowSorusturmaDurumu
            // 
            this.rowSorusturmaDurumu.Name = "rowSorusturmaDurumu";
            this.rowSorusturmaDurumu.Properties.Caption = "Sorusturma Durumu ";
            this.rowSorusturmaDurumu.Properties.FieldName = "DURUM_ID";
            this.rowSorusturmaDurumu.Properties.RowEdit = this.rlueSorusturmaDurum;
            // 
            // AdliBirim_Adliye_Gorev_No
            // 
            this.AdliBirim_Adliye_Gorev_No.Expanded = false;
            this.AdliBirim_Adliye_Gorev_No.Height = 19;
            this.AdliBirim_Adliye_Gorev_No.Name = "AdliBirim_Adliye_Gorev_No";
            this.AdliBirim_Adliye_Gorev_No.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties691});
            // 
            // Sikayet
            // 
            this.Sikayet.Expanded = false;
            this.Sikayet.Height = 15;
            this.Sikayet.Name = "Sikayet";
            this.Sikayet.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties692,
            this.multiEditorRowProperties693});
            // 
            // HazýrlýkNo_Durum_Tarih
            // 
            this.HazýrlýkNo_Durum_Tarih.Expanded = false;
            this.HazýrlýkNo_Durum_Tarih.Height = 18;
            this.HazýrlýkNo_Durum_Tarih.Name = "HazýrlýkNo_Durum_Tarih";
            this.HazýrlýkNo_Durum_Tarih.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties694,
            this.multiEditorRowProperties695});
            // 
            // rowSORUMLU_SAVCI_CARI_ID
            // 
            this.rowSORUMLU_SAVCI_CARI_ID.Height = 19;
            this.rowSORUMLU_SAVCI_CARI_ID.Name = "rowSORUMLU_SAVCI_CARI_ID";
            this.rowSORUMLU_SAVCI_CARI_ID.Properties.Caption = "Sorumlu Savcý";
            this.rowSORUMLU_SAVCI_CARI_ID.Properties.FieldName = "SORUMLU_SAVCI_CARI_ID";
            this.rowSORUMLU_SAVCI_CARI_ID.Properties.RowEdit = this.rLueSorumluSavci;
            // 
            // Refarans1_2_3
            // 
            this.Refarans1_2_3.Height = 17;
            this.Refarans1_2_3.Name = "Refarans1_2_3";
            this.Refarans1_2_3.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties696,
            this.multiEditorRowProperties697,
            this.multiEditorRowProperties698});
            // 
            // OzelKod1_2
            // 
            this.OzelKod1_2.Height = 16;
            this.OzelKod1_2.Name = "OzelKod1_2";
            this.OzelKod1_2.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties699,
            this.multiEditorRowProperties700});
            // 
            // OzelKod3_4
            // 
            this.OzelKod3_4.Height = 18;
            this.OzelKod3_4.Name = "OzelKod3_4";
            this.OzelKod3_4.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties701,
            this.multiEditorRowProperties702});
            // 
            // rowACIKLAMA
            // 
            this.rowACIKLAMA.Height = 17;
            this.rowACIKLAMA.Name = "rowACIKLAMA";
            this.rowACIKLAMA.Properties.Caption = "ACIKLAMA";
            this.rowACIKLAMA.Properties.FieldName = "ACIKLAMA";
            this.rowACIKLAMA.Properties.RowEdit = this.rIAciklama;
            // 
            // tabpSorusturmaNedenleri
            // 
            this.tabpSorusturmaNedenleri.Controls.Add(this.pnlSorusturma);
            this.tabpSorusturmaNedenleri.Controls.Add(this.xtraTabControl2);
            this.tabpSorusturmaNedenleri.Image = ((System.Drawing.Image)(resources.GetObject("tabpSorusturmaNedenleri.Image")));
            this.tabpSorusturmaNedenleri.Name = "tabpSorusturmaNedenleri";
            this.tabpSorusturmaNedenleri.Size = new System.Drawing.Size(938, 710);
            this.tabpSorusturmaNedenleri.Text = "Soruþturma Nedenleri";
            // 
            // pnlSorusturma
            // 
            this.pnlSorusturma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSorusturma.Location = new System.Drawing.Point(0, 0);
            this.pnlSorusturma.Name = "pnlSorusturma";
            this.pnlSorusturma.Size = new System.Drawing.Size(938, 356);
            this.pnlSorusturma.TabIndex = 1;
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraTabControl2.Location = new System.Drawing.Point(0, 356);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage5;
            this.xtraTabControl2.Size = new System.Drawing.Size(938, 354);
            this.xtraTabControl2.TabIndex = 0;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage4,
            this.xtraTabPage5,
            this.xtraTabPage6,
            this.xtraTabPage7,
            this.xtraTabPage8});
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.ucKiymetliEvrak1);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(932, 326);
            this.xtraTabPage5.Text = "Kýymetli Evrak Bilgileri";
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
            this.ucKiymetliEvrak1.Size = new System.Drawing.Size(932, 326);
            this.ucKiymetliEvrak1.TabIndex = 0;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.ucSorusturmaNedenTaraf1);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(932, 326);
            this.xtraTabPage4.Text = "Sorusturma Taraf Bilgileri ";
            // 
            // ucSorusturmaNedenTaraf1
            // 
            this.ucSorusturmaNedenTaraf1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSorusturmaNedenTaraf1.Location = new System.Drawing.Point(0, 0);
            this.ucSorusturmaNedenTaraf1.MyDataSource = null;
            this.ucSorusturmaNedenTaraf1.Name = "ucSorusturmaNedenTaraf1";
            this.ucSorusturmaNedenTaraf1.Size = new System.Drawing.Size(932, 326);
            this.ucSorusturmaNedenTaraf1.TabIndex = 0;
            // 
            // xtraTabPage6
            // 
            this.xtraTabPage6.Controls.Add(this.ucGayriMenkul1);
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.Size = new System.Drawing.Size(932, 326);
            this.xtraTabPage6.Text = "Gayrimenkul Bilgileri";
            // 
            // ucGayriMenkul1
            // 
            this.ucGayriMenkul1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGayriMenkul1.Location = new System.Drawing.Point(0, 0);
            this.ucGayriMenkul1.MyDataSource = null;
            this.ucGayriMenkul1.MyDavaFoy = null;
            this.ucGayriMenkul1.Name = "ucGayriMenkul1";
            this.ucGayriMenkul1.Size = new System.Drawing.Size(932, 326);
            this.ucGayriMenkul1.TabIndex = 0;
            // 
            // xtraTabPage7
            // 
            this.xtraTabPage7.Controls.Add(this.tabAracBilgileri);
            this.xtraTabPage7.Name = "xtraTabPage7";
            this.xtraTabPage7.Size = new System.Drawing.Size(932, 326);
            this.xtraTabPage7.Text = "Gemi Uçak Bilgileri";
            // 
            // tabAracBilgileri
            // 
            this.tabAracBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAracBilgileri.Location = new System.Drawing.Point(0, 0);
            this.tabAracBilgileri.Name = "tabAracBilgileri";
            this.tabAracBilgileri.SelectedTabPage = this.tpUcak;
            this.tabAracBilgileri.Size = new System.Drawing.Size(932, 326);
            this.tabAracBilgileri.TabIndex = 7;
            this.tabAracBilgileri.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpUcak,
            this.tpGemiBilgileri,
            this.tpAracBilgileri});
            // 
            // tpUcak
            // 
            this.tpUcak.Controls.Add(this.ucUcakGemiArac1);
            this.tpUcak.Name = "tpUcak";
            this.tpUcak.Size = new System.Drawing.Size(926, 298);
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
            this.tpGemiBilgileri.Controls.Add(this.ugaGemi);
            this.tpGemiBilgileri.Name = "tpGemiBilgileri";
            this.tpGemiBilgileri.Size = new System.Drawing.Size(926, 298);
            this.tpGemiBilgileri.Text = "Gemi Bilgileri";
            // 
            // ugaGemi
            // 
            this.ugaGemi.HacizKayitEkranimi = false;
            this.ugaGemi.KontrolTipi = AvukatProLib.Extras.GemiUcakAracTipi.SecimYapin;
            this.ugaGemi.Location = new System.Drawing.Point(0, 0);
            this.ugaGemi.MyDataSource = null;
            this.ugaGemi.Name = "ugaGemi";
            this.ugaGemi.PerMyDataSource = null;
            this.ugaGemi.Size = new System.Drawing.Size(150, 150);
            this.ugaGemi.TabIndex = 0;
            // 
            // tpAracBilgileri
            // 
            this.tpAracBilgileri.Controls.Add(this.ugaArac);
            this.tpAracBilgileri.Name = "tpAracBilgileri";
            this.tpAracBilgileri.Size = new System.Drawing.Size(926, 298);
            this.tpAracBilgileri.Text = "Araç Bilgileri";
            // 
            // ugaArac
            // 
            this.ugaArac.HacizKayitEkranimi = false;
            this.ugaArac.KontrolTipi = AvukatProLib.Extras.GemiUcakAracTipi.SecimYapin;
            this.ugaArac.Location = new System.Drawing.Point(0, 0);
            this.ugaArac.MyDataSource = null;
            this.ugaArac.Name = "ugaArac";
            this.ugaArac.PerMyDataSource = null;
            this.ugaArac.Size = new System.Drawing.Size(150, 150);
            this.ugaArac.TabIndex = 0;
            // 
            // xtraTabPage8
            // 
            this.xtraTabPage8.Controls.Add(this.ucPoliceBilgileri1);
            this.xtraTabPage8.Name = "xtraTabPage8";
            this.xtraTabPage8.Size = new System.Drawing.Size(932, 326);
            this.xtraTabPage8.Text = "Sigorta Poliçe Bilgileri";
            // 
            // ucPoliceBilgileri1
            // 
            this.ucPoliceBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPoliceBilgileri1.Location = new System.Drawing.Point(0, 0);
            this.ucPoliceBilgileri1.MyDataSource = null;
            this.ucPoliceBilgileri1.Name = "ucPoliceBilgileri1";
            this.ucPoliceBilgileri1.Size = new System.Drawing.Size(932, 326);
            this.ucPoliceBilgileri1.TabIndex = 0;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("46d7fd73-fd42-4087-9012-541c403fe4cf");
            this.dockPanel1.Location = new System.Drawing.Point(0, 143);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(0, 0);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(65, 573);
            this.dockPanel1.Text = "ÖnIzleme";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(59, 545);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // AV001_TD_BIL_HAZIRLIKBindingSource
            // 
            this.AV001_TD_BIL_HAZIRLIKBindingSource.DataSource = typeof(AvukatProLib2.Entities.AV001_TD_BIL_HAZIRLIK);
            // 
            // pnlSorusturmaNedenleri
            // 
            this.pnlSorusturmaNedenleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSorusturmaNedenleri.Location = new System.Drawing.Point(0, 0);
            this.pnlSorusturmaNedenleri.Name = "pnlSorusturmaNedenleri";
            this.pnlSorusturmaNedenleri.Size = new System.Drawing.Size(926, 188);
            this.pnlSorusturmaNedenleri.TabIndex = 1;
            // 
            // grdSikayetEdilenTaraf
            // 
            this.grdSikayetEdilenTaraf.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTEMSIL_ID,
            this.colAVUKAT_CARI_ID,
            this.colTEMSIL_SEKLI});
            this.grdSikayetEdilenTaraf.Name = "grdSikayetEdilenTaraf";
            // 
            // colTEMSIL_ID
            // 
            this.colTEMSIL_ID.Caption = "TEMSIL";
            this.colTEMSIL_ID.ColumnEdit = this.rbtnTemsilEkle;
            this.colTEMSIL_ID.FieldName = "TEMSIL_ID";
            this.colTEMSIL_ID.Name = "colTEMSIL_ID";
            this.colTEMSIL_ID.Visible = true;
            this.colTEMSIL_ID.VisibleIndex = 0;
            // 
            // colAVUKAT_CARI_ID
            // 
            this.colAVUKAT_CARI_ID.Caption = "AVUKAT";
            this.colAVUKAT_CARI_ID.ColumnEdit = this.rLueKarsiTarafVAvukat;
            this.colAVUKAT_CARI_ID.FieldName = "AVUKAT_CARI_ID";
            this.colAVUKAT_CARI_ID.Name = "colAVUKAT_CARI_ID";
            this.colAVUKAT_CARI_ID.Visible = true;
            this.colAVUKAT_CARI_ID.VisibleIndex = 1;
            // 
            // colTEMSIL_SEKLI
            // 
            this.colTEMSIL_SEKLI.Caption = "TEMSIL SEKLI";
            this.colTEMSIL_SEKLI.ColumnEdit = this.rLueTemsilSekli;
            this.colTEMSIL_SEKLI.FieldName = "TEMSIL_SEKLI";
            this.colTEMSIL_SEKLI.Name = "colTEMSIL_SEKLI";
            this.colTEMSIL_SEKLI.Visible = true;
            this.colTEMSIL_SEKLI.VisibleIndex = 2;
            // 
            // gvSikayetEdilen
            // 
            this.gvSikayetEdilen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTarafKodu,
            this.colSikayetEdilenSýfat,
            this.colSikayetEdilen});
            this.gvSikayetEdilen.IndicatorWidth = 20;
            this.gvSikayetEdilen.Name = "gvSikayetEdilen";
            this.gvSikayetEdilen.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gvSikayetEdilen.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gvSikayetEdilen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvSikayetEdilen.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gvSikayetEdilen.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvSikayetEdilen.OptionsView.ShowGroupPanel = false;
            // 
            // colTarafKodu
            // 
            this.colTarafKodu.Caption = "T.K";
            this.colTarafKodu.ColumnEdit = this.rLueSikayetEdilenTaraf;
            this.colTarafKodu.FieldName = "TARAF_KODU";
            this.colTarafKodu.Name = "colTarafKodu";
            this.colTarafKodu.Visible = true;
            this.colTarafKodu.VisibleIndex = 0;
            // 
            // colSikayetEdilenSýfat
            // 
            this.colSikayetEdilenSýfat.Caption = "Sýfat";
            this.colSikayetEdilenSýfat.ColumnEdit = this.rLueSikayetEdilenSifat;
            this.colSikayetEdilenSýfat.FieldName = "TARAF_SIFAT_ID";
            this.colSikayetEdilenSýfat.Name = "colSikayetEdilenSýfat";
            this.colSikayetEdilenSýfat.Visible = true;
            this.colSikayetEdilenSýfat.VisibleIndex = 1;
            // 
            // colSikayetEdilen
            // 
            this.colSikayetEdilen.Caption = "Þikayet Edilen ";
            this.colSikayetEdilen.ColumnEdit = this.rLueSikayetEdenCari;
            this.colSikayetEdilen.FieldName = "CARI_ID";
            this.colSikayetEdilen.Name = "colSikayetEdilen";
            this.colSikayetEdilen.Visible = true;
            this.colSikayetEdilen.VisibleIndex = 2;
            // 
            // rLueOzelKod
            // 
            this.rLueOzelKod.AutoHeight = false;
            this.rLueOzelKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueOzelKod.Name = "rLueOzelKod";
            this.rLueOzelKod.NullText = "Özel Kod ";
            this.rLueOzelKod.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // rfrmSorusturmaGiris
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 741);
            this.Name = "rfrmSorusturmaGiris";
            this.Text = "Avukatpro Soruþturma Yönetimi";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.rfrmSorusturmaGiris_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSikayetEdenTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTemsilEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafVAvukat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTemsilSekli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exgrdSikayetEden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AV001_TD_BIL_HAZIRLIK_TARAFBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdenTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdenSifat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdilenCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdenTemsil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdilenTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdilenSifat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdilenTemsil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimGorev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorumluSavci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGorev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateSikayet.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateSikayet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHazirlikDurum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rIAciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grLueSorumluAvk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetNeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rceSorusturma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetKonu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDosyaDurum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelKod1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSikayetEdenCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKarsiTarafVAvukat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTemsilEkleSEdilen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueSorusturmaDurum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelKod2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelKod3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelKod4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSikayetEden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exgrdSikayetEdilen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tabs)).EndInit();
            this.Tabs.ResumeLayout(false);
            this.tbpGenel.ResumeLayout(false);
            this.pnTemp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSikayetNedenleri)).EndInit();
            this.grpSikayetNedenleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSikayetEden)).EndInit();
            this.grpSikayetEden.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSorumluAvukat)).EndInit();
            this.grpSorumluAvukat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exgrdSorumluAvukat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSAvukat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorumluAvukat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpsikayetEdilen)).EndInit();
            this.grpsikayetEdilen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vgSorusturmaGenelBilgiler)).EndInit();
            this.tabpSorusturmaNedenleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSorusturma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage5.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage6.ResumeLayout(false);
            this.xtraTabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabAracBilgileri)).EndInit();
            this.tabAracBilgileri.ResumeLayout(false);
            this.tpUcak.ResumeLayout(false);
            this.tpGemiBilgileri.ResumeLayout(false);
            this.tpAracBilgileri.ResumeLayout(false);
            this.xtraTabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AV001_TD_BIL_HAZIRLIKBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSorusturmaNedenleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSikayetEdilenTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSikayetEdilen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelKod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
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
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem13;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem15;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem16;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem17;
        //private DevExpress.XtraBars.BarButtonItem btnTedbir;
        //private DevExpress.XtraBars.BarButtonItem btnOdeme;
        private DevExpress.XtraTab.XtraTabControl Tabs;
        private DevExpress.XtraTab.XtraTabPage tbpGenel;
        private DevExpress.XtraTab.XtraTabPage tabpSorusturmaNedenleri;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        //private AdimAdimDavaKaydi.ExtendTool.compRibbonExtender compRibbonExtender1;
        private System.Windows.Forms.BindingSource AV001_TD_BIL_HAZIRLIK_TARAFBindingSource;
        private DevExpress.XtraEditors.Repository.PersistentRepository perRSorusturmaGenelBilgiler;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSikayetEdenTaraf;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSikayetEdenSifat;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSikayetEdilenCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSikayetEdenTemsil;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSikayetEdilenTaraf;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSikayetEdilenTemsil;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSikayetEdilenSifat;
        private System.Windows.Forms.BindingSource AV001_TD_BIL_HAZIRLIKBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliye;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimGorev;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSorumluSavci;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTemsilSekli;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueGorev;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rDateSikayet;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueHazirlikDurum;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit rIAciklama;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit grLueSorumluAvk;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSikayetNeden;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rceSorusturma;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private DevExpress.XtraEditors.PanelControl pnlSorusturma;
        private ucKiymetliEvrak ucKiymetliEvrak1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage6;
        private ucGayriMenkul ucGayriMenkul1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage7;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage8;
        private AdimAdimDavaKaydi.UserControls.ucPoliceBilgileri ucPoliceBilgileri1;
        private DevExpress.XtraEditors.PanelControl pnlSorusturmaNedenleri;
        private DevExpress.XtraTab.XtraTabControl tabAracBilgileri;
        private DevExpress.XtraTab.XtraTabPage tpUcak;
        private ucUcakGemiArac ucUcakGemiArac1;
        private DevExpress.XtraTab.XtraTabPage tpGemiBilgileri;
        private ucUcakGemiArac ugaGemi;
        private DevExpress.XtraTab.XtraTabPage tpAracBilgileri;
        private ucUcakGemiArac ugaArac;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private AdimAdimDavaKaydi.Sorusturma.UserControls.ucSorusturmaNedenTaraf ucSorusturmaNedenTaraf1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSikayetKonu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueDosyaDurum;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueOzelKod1;
        private System.Windows.Forms.Panel pnTemp;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl grpsikayetEdilen;
        private LookUpExtender lookUpExtender1;
        private DevExpress.XtraEditors.GroupControl grpSorumluAvukat;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl exgrdSorumluAvukat;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSAvukat;
        private DevExpress.XtraGrid.Columns.GridColumn colSorumluAvukat;
        private DevExpress.XtraGrid.Columns.GridColumn colYetkilimi;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSorumluAvukat;
        private DevExpress.XtraEditors.GroupControl grpSikayetEden;
        private DevExpress.XtraEditors.GroupControl grpSikayetNedenleri;
        private AdimAdimDavaKaydi.Sorusturma.UserControls.ucSorusturmaNedenleri ucSorusturmaNedenleri1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraVerticalGrid.VGridControl vgSorusturmaGenelBilgiler;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDosyaDurum;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow AdliBirim_Adliye_Gorev_No;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow Sikayet;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow HazirlikNo_Kod_Sayi;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow HazýrlýkNo_Durum_Tarih;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSORUMLU_SAVCI_CARI_ID;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow Refarans1_2_3;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow OzelKod1_2;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow OzelKod3_4;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowACIKLAMA;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSorusturmaDurumu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSikayetEdenCari;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem18;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem19;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem20;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem21;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTarafVAvukat;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueKarsiTarafVAvukat;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnTemsilEkle;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnTemsilEkleSEdilen;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueSorusturmaDurum;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl exgrdSikayetEdilen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl exgrdSikayetEden;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSikayetEdenTaraf;
        private DevExpress.XtraGrid.Columns.GridColumn colsikayetEdenTEMSIL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSikayetEdenAVUKAT_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSikayetEdenTEMSIL_SEKLI;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSikayetEden;
        private DevExpress.XtraGrid.Columns.GridColumn colTARAF_KODU;
        private DevExpress.XtraGrid.Columns.GridColumn colSýfat;
        private DevExpress.XtraGrid.Columns.GridColumn colSikayetEden;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSikayetEdilenTaraf;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMSIL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colAVUKAT_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMSIL_SEKLI;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSikayetEdilen;
        private DevExpress.XtraGrid.Columns.GridColumn colTarafKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colSikayetEdilenSýfat;
        private DevExpress.XtraGrid.Columns.GridColumn colSikayetEdilen;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueOzelKod;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueOzelKod2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueOzelKod3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueOzelKod4;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties690;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties691;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties692;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties693;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties694;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties695;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties696;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties697;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties698;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties699;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties700;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties701;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties702;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    }
}
