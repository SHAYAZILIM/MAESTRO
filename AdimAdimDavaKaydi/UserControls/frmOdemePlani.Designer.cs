namespace  AdimAdimDavaKaydi.UserControls
{
    partial class frmOdemePlani
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode4 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOdemePlani));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            AvukatProLib.Hesap.ParaVeDovizId paraVeDovizId1 = new AvukatProLib.Hesap.ParaVeDovizId();
            AvukatProLib.Hesap.ParaVeDovizId paraVeDovizId2 = new AvukatProLib.Hesap.ParaVeDovizId();
            AvukatProLib.Hesap.ParaVeDovizId paraVeDovizId3 = new AvukatProLib.Hesap.ParaVeDovizId();
            AvukatProLib.Hesap.ParaVeDovizId paraVeDovizId4 = new AvukatProLib.Hesap.ParaVeDovizId();
            AvukatProLib.Hesap.ParaVeDovizId paraVeDovizId5 = new AvukatProLib.Hesap.ParaVeDovizId();
            AvukatProLib.Hesap.ParaVeDovizId paraVeDovizId6 = new AvukatProLib.Hesap.ParaVeDovizId();
            AvukatProLib.Hesap.ParaVeDovizId paraVeDovizId7 = new AvukatProLib.Hesap.ParaVeDovizId();
            AvukatProLib.Hesap.ParaVeDovizId paraVeDovizId8 = new AvukatProLib.Hesap.ParaVeDovizId();
            AvukatProLib.Hesap.ParaVeDovizId paraVeDovizId9 = new AvukatProLib.Hesap.ParaVeDovizId();
            AvukatProLib.Hesap.ParaVeDovizId paraVeDovizId10 = new AvukatProLib.Hesap.ParaVeDovizId();
            AvukatProLib.Hesap.ParaVeDovizId paraVeDovizId11 = new AvukatProLib.Hesap.ParaVeDovizId();
            AvukatProLib.Hesap.ParaVeDovizId paraVeDovizId12 = new AvukatProLib.Hesap.ParaVeDovizId();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ODEME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ODEME_MIKTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ODEME_MIKTAR_DOVIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDovizId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ODEME_YERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ODEME_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ODEYEN_CARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BORCLU_ADINA_ODEYEN_CARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ODENEN_CARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ALACAKLI_ADINA_ODENEN_CARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ALACAK_NEDEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ICRADAN_CEKILME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IHTIYATI_HACIZDE_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MAAS_HACZINDEN_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KIYMETLI_EVRAK_ODENDI_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KIYMETLI_EVRAK_VADE_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KIYMETLI_EVRAK_VADESINDE_ODENDI_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ACIKLAMA_ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ODEME_MAHSUP_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOdemePlani = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.bndOdemePlani = new System.Windows.Forms.BindingSource(this.components);
            this.persistentRepository1 = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colICRA_ALACAK_NEDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colILAM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_KALEM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEN_SON_FAIZ_HESAPLANMA_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_TAKIPDEN_ONCE_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_ORANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_BASLANGIC_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_BITIS_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGUN_FARKI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATRAH_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATRAH_TUTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_TUTARI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_TUTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBSMV_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBSMV_TUTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKKDF_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKKDF_TUTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOIV_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOIV_TUTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKDV_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKDV_TUTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALACAK_NEDEN_TARAF_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBORC_TUTARI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rSpinTutar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colBORC_TUTARI_DOVIZ_ID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colANA_PARAYA_ODENEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colANA_PARAYA_ODENEN_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZE_ODENEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZE_ODENEN_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIGERLERINE_ODENEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIGERLERINE_ODENEN_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_DOVIZ_ID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBAKIYE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBAKIYE_DOVIZ_ID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGUN1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_TIP_ID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_ORAN1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDEVRE_FAIZI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDEVRE_FAIZI_DOVIZ_ID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gwOdemePlani = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colFOY_TARAF_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTARIH = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBORC_TUTARI = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBORC_TUTARI_DOVIZ_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colANAPARA = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colODEME = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colODEME_DOVIZ_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBAKIYE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBAKIYE_DOVIZ_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFAIZ_TIP_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFAIZ_ORAN = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colGUN = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDEVRE_FAIZI = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDEVRE_FAIZI_DOVIZ_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBSMV_3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_KARSILIK_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAHSUP_ALT_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAHSUP_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALACAK_NEDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAGILIM_TIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.multiEditorRowProperties1 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rlueMudurluk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties2 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rlueMudurlukNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gLueDosyaNo = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelParametreler = new DevExpress.XtraEditors.PanelControl();
            this.btnHesapSira = new DevExpress.XtraEditors.SimpleButton();
            this.cbVekaletOtomatikHesapla = new DevExpress.XtraEditors.CheckEdit();
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.gcAlacakNedenleri = new DevExpress.XtraGrid.GridControl();
            this.bndAlacakNeden = new System.Windows.Forms.BindingSource(this.components);
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAlacakNeden = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rSpinPara = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rSpinOran = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.lBtnFaizOraniUygula = new System.Windows.Forms.LinkLabel();
            this.linkLabel8 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.bEditTOFaizOrani = new DevExpress.XtraEditors.ButtonEdit();
            this.cEditTumAlacaklariSec = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl59 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl48 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.checkEdit10 = new DevExpress.XtraEditors.CheckEdit();
            this.lookUpEdit6 = new DevExpress.XtraEditors.LookUpEdit();
            this.checkEdit5 = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl58 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl38 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl57 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.checkEdit7 = new DevExpress.XtraEditors.CheckEdit();
            this.popupContainerEdit3 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.gridControl4 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn26 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn27 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemLookUpEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bandedGridColumn28 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemSpinEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.bandedGridColumn29 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn30 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn31 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn32 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn33 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn34 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn35 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.ucDovizliTutarAlani5 = new AdimAdimDavaKaydi.Util.UcDovizliTutarAlani();
            this.ucDovizliTutarAlani6 = new AdimAdimDavaKaydi.Util.UcDovizliTutarAlani();
            this.ucDovizliTutarAlani7 = new AdimAdimDavaKaydi.Util.UcDovizliTutarAlani();
            this.ucDovizliTutarAlani8 = new AdimAdimDavaKaydi.Util.UcDovizliTutarAlani();
            this.checkEdit9 = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl50 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit4 = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl51 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl52 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl53 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl54 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit5 = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl55 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl56 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit4 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl40 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit3 = new DevExpress.XtraEditors.DateEdit();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.popupContainerEdit2 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bandedGridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemSpinEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.bandedGridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn15 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn16 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn17 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn18 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.ucDovizliTutarAlani1 = new AdimAdimDavaKaydi.Util.UcDovizliTutarAlani();
            this.ucDovizliTutarAlani2 = new AdimAdimDavaKaydi.Util.UcDovizliTutarAlani();
            this.ucDovizliTutarAlani3 = new AdimAdimDavaKaydi.Util.UcDovizliTutarAlani();
            this.ucDovizliTutarAlani4 = new AdimAdimDavaKaydi.Util.UcDovizliTutarAlani();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl41 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl42 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl43 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl44 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl45 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit3 = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl46 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl47 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.checkEdit6 = new DevExpress.XtraEditors.CheckEdit();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.checkEdit4 = new DevExpress.XtraEditors.CheckEdit();
            this.gcSimulasyonGruplari = new DevExpress.XtraGrid.GridControl();
            this.gwSimulasyonGruplari = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colSecim = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rlueSimuDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTUTAR1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rSpinSimuPara = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colTUTAR_DOVIZ_ID1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFAIZ = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFAIZ_DOVIZ_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDIGER = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDIGER_DOVIZ_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTOPLAM = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTOPLAM_DOVIZ_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.prToplamMasraf = new AdimAdimDavaKaydi.Util.UcDovizliTutarAlani();
            this.prVekaletUcreti = new AdimAdimDavaKaydi.Util.UcDovizliTutarAlani();
            this.prBakiyeHarc = new AdimAdimDavaKaydi.Util.UcDovizliTutarAlani();
            this.prToplam = new AdimAdimDavaKaydi.Util.UcDovizliTutarAlani();
            this.cbBakiyeHarcHesabaDahil = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.lueHesapTipi = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.lueBirYilKacGun = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateSonHesapTarihi = new DevExpress.XtraEditors.DateEdit();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.lueFaizSecenekleri = new DevExpress.XtraEditors.LookUpEdit();
            this.dateTaksitlerBaslasin = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.rgKosullar = new DevExpress.XtraEditors.RadioGroup();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnTumKosullariKaldir = new System.Windows.Forms.ToolStripMenuItem();
            this.ceGayriNakit = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnHesapla = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.m5_deTarih = new DevExpress.XtraEditors.DateEdit();
            this.m1_spinOdeme = new DevExpress.XtraEditors.SpinEdit();
            this.m2_lueOdemeDovizId = new DevExpress.XtraEditors.LookUpEdit();
            this.m2_spinAy = new DevExpress.XtraEditors.SpinEdit();
            this.m1_spinGun = new DevExpress.XtraEditors.SpinEdit();
            this.m4_spinOdeme = new DevExpress.XtraEditors.SpinEdit();
            this.m5_lueOdemeDoviz = new DevExpress.XtraEditors.LookUpEdit();
            this.m3_spinAy = new DevExpress.XtraEditors.SpinEdit();
            this.m2_spinGun = new DevExpress.XtraEditors.SpinEdit();
            this.m5_spinOdeme = new DevExpress.XtraEditors.SpinEdit();
            this.m4_lueOdemeDovizId = new DevExpress.XtraEditors.LookUpEdit();
            this.m4_spinGun = new DevExpress.XtraEditors.SpinEdit();
            this.m3_spinGun = new DevExpress.XtraEditors.SpinEdit();
            this.m2_spinOdeme = new DevExpress.XtraEditors.SpinEdit();
            this.m1_lueOdemeDovizId = new DevExpress.XtraEditors.LookUpEdit();
            this.m4_spinAy = new DevExpress.XtraEditors.SpinEdit();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gcBorclular = new DevExpress.XtraGrid.GridControl();
            this.gvBorclular = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueBorclu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lueTaahhutEden = new AdimAdimDavaKaydi.Util.ExtendedLookUpEdit();
            this.lueTaahhutKabulEden = new AdimAdimDavaKaydi.Util.ExtendedLookUpEdit();
            this.ceGecerliTaahhut = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.deKabulTarihi = new DevExpress.XtraEditors.DateEdit();
            this.deTebligTarihi = new DevExpress.XtraEditors.DateEdit();
            this.deTaahhutTarihi = new DevExpress.XtraEditors.DateEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.editorRow1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.multiEditorRow1 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.compNavBarAutoHeight1 = new AdimAdimDavaKaydi.Util.compNavBarAutoHeight(this.components);
            this.compGridDovizSummary1 = new AdimAdimDavaKaydi.Util.compGridDovizSummary(this.components);
            this.compGridDovizSummary2 = new AdimAdimDavaKaydi.Util.compGridDovizSummary(this.components);
            this.bndSimulastonBirimi = new System.Windows.Forms.BindingSource(this.components);
            this.pnlWizard = new DevExpress.XtraEditors.PanelControl();
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.wpHesapParametreleri = new DevExpress.XtraWizard.WizardPage();
            this.txtFaizOrani = new DevExpress.XtraEditors.TextEdit();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.labelControl29 = new DevExpress.XtraEditors.LabelControl();
            this.ceToplamlarAsilAlacak = new DevExpress.XtraEditors.CheckEdit();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.simpleButton30 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton32 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton31 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton29 = new DevExpress.XtraEditors.SimpleButton();
            this.wpHesapKosullari = new DevExpress.XtraWizard.WizardPage();
            this.chKesitTarihiKullan = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl34 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblSonOdemeBakiye = new DevExpress.XtraEditors.LabelControl();
            this.lblSonOdemeText = new DevExpress.XtraEditors.LabelControl();
            this.lblToplamOdeme = new DevExpress.XtraEditors.LabelControl();
            this.labelControl32 = new DevExpress.XtraEditors.LabelControl();
            this.lblGiderVergisi = new DevExpress.XtraEditors.LabelControl();
            this.labelControl39 = new DevExpress.XtraEditors.LabelControl();
            this.lblVekaletUcretineOdenen = new DevExpress.XtraEditors.LabelControl();
            this.labelControl37 = new DevExpress.XtraEditors.LabelControl();
            this.lblHarcVeMasraflaraOdenen = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl35 = new DevExpress.XtraEditors.LabelControl();
            this.lblGiderVergisineOdenen = new DevExpress.XtraEditors.LabelControl();
            this.labelControl33 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.lblDigerAlacaklar = new DevExpress.XtraEditors.LabelControl();
            this.labelcontrolxxxx = new DevExpress.XtraEditors.LabelControl();
            this.lblTazminat = new DevExpress.XtraEditors.LabelControl();
            this.labelControl49 = new DevExpress.XtraEditors.LabelControl();
            this.lblMasraf = new DevExpress.XtraEditors.LabelControl();
            this.labelControl36 = new DevExpress.XtraEditors.LabelControl();
            this.lblVekaletUcreti = new DevExpress.XtraEditors.LabelControl();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.lblHarclar = new DevExpress.XtraEditors.LabelControl();
            this.labelControl28 = new DevExpress.XtraEditors.LabelControl();
            this.lblFaizTutari = new DevExpress.XtraEditors.LabelControl();
            this.labelControl26 = new DevExpress.XtraEditors.LabelControl();
            this.lblAsilAlacak = new DevExpress.XtraEditors.LabelControl();
            this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
            this.lblOrtFaizOrani = new DevExpress.XtraEditors.LabelControl();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.lblBakiye = new DevExpress.XtraEditors.LabelControl();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.lblFaizeOdenen = new DevExpress.XtraEditors.LabelControl();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.lblAnaparayaOdenen = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.lblToplamTutar = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.dateSimulasyonHesapTarihi = new DevExpress.XtraEditors.DateEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.wpOdemePlani = new DevExpress.XtraWizard.WizardPage();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcChildOdemePlan = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gwChildOdemePlan = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colFOY_TARAF_ID_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTARIH_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBORC_TUTARI_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBORC_TUTARI_DOVIZ_ID_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn13_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn14_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn15_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn16_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn17_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn18_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colODEME_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colODEME_DOVIZ_ID_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBAKIYE_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBAKIYE_DOVIZ_ID_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colGUN_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFAIZ_TIP_ID_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFAIZ_ORAN_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDEVRE_FAIZI_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBSMV_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTOPLAM_FAIZ_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDEVRE_FAIZI_DOVIZ_ID_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gcOdemePlaniDetay = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.wpTaahhütTaraflari = new DevExpress.XtraWizard.WizardPage();
            this.wpAlacakNedenleri = new DevExpress.XtraWizard.WizardPage();
            this.gcHariciAlacaklar = new DevExpress.XtraGrid.GridControl();
            this.bndHariciAlacakNeden = new System.Windows.Forms.BindingSource(this.components);
            this.gvHariciAlacaklar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.seHarcVeMasraflar = new DevExpress.XtraEditors.SpinEdit();
            this.seVekaletUcreti = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl31 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl30 = new DevExpress.XtraEditors.LabelControl();
            this.rLueTaraf = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOdemePlani)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndOdemePlani)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSpinTutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwOdemePlani)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueMudurluk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueMudurlukNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gLueDosyaNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelParametreler)).BeginInit();
            this.panelParametreler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbVekaletOtomatikHesapla.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacakNedenleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndAlacakNeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakNeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSpinPara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSpinOran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bEditTOFaizOrani.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cEditTumAlacaklariSec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit10.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit4.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit3.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSimulasyonGruplari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSimulasyonGruplari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueSimuDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSpinSimuPara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBakiyeHarcHesabaDahil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHesapTipi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBirYilKacGun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSonHesapTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSonHesapTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFaizSecenekleri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTaksitlerBaslasin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTaksitlerBaslasin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgKosullar.Properties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceGayriNakit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m5_deTarih.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m5_deTarih.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m1_spinOdeme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m2_lueOdemeDovizId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m2_spinAy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m1_spinGun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m4_spinOdeme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m5_lueOdemeDoviz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m3_spinAy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m2_spinGun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m5_spinOdeme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m4_lueOdemeDovizId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m4_spinGun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m3_spinGun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m2_spinOdeme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m1_lueOdemeDovizId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m4_spinAy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBorclular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBorclular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueBorclu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTaahhutEden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTaahhutKabulEden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceGecerliTaahhut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deKabulTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deKabulTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTebligTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTebligTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTaahhutTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTaahhutTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndSimulastonBirimi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWizard)).BeginInit();
            this.pnlWizard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wpHesapParametreleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaizOrani.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceToplamlarAsilAlacak.Properties)).BeginInit();
            this.completionWizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.wpHesapKosullari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chKesitTarihiKullan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateSimulasyonHesapTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSimulasyonHesapTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.wpOdemePlani.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcChildOdemePlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwChildOdemePlan)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcOdemePlaniDetay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            this.wpTaahhütTaraflari.SuspendLayout();
            this.wpAlacakNedenleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHariciAlacaklar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndHariciAlacakNeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHariciAlacaklar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seHarcVeMasraflar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seVekaletUcreti.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTaraf)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(894, 33);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 536);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Location = new System.Drawing.Point(0, 33);
            this.c_pnlSol.Size = new System.Drawing.Size(17, 536);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 697);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(996, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(846, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(921, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.pnlWizard);
            this.c_pnlContainer.Size = new System.Drawing.Size(996, 722);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.pnlWizard, 0);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ODEME_TARIHI,
            this.ODEME_MIKTAR,
            this.ODEME_MIKTAR_DOVIZ,
            this.ODEME_YERI,
            this.ODEME_TIP,
            this.ODEYEN_CARI,
            this.BORCLU_ADINA_ODEYEN_CARI,
            this.ODENEN_CARI,
            this.ALACAKLI_ADINA_ODENEN_CARI,
            this.ALACAK_NEDEN,
            this.ICRADAN_CEKILME_TARIHI,
            this.IHTIYATI_HACIZDE_MI,
            this.MAAS_HACZINDEN_MI,
            this.KIYMETLI_EVRAK_ODENDI_MI,
            this.KIYMETLI_EVRAK_VADE_TARIHI,
            this.KIYMETLI_EVRAK_VADESINDE_ODENDI_MI,
            this.ACIKLAMA_,
            this.ODEME_MAHSUP_TIP});
            this.gridView1.GridControl = this.gcOdemePlani;
            this.gridView1.GroupPanelText = "Verileri Gruplamak İçin Başlıkları Buraya Sürükleyin";
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_MIKTAR", this.ODEME_MIKTAR, "Grup Toplamı : {0:###,###,###,##0.00}", 1),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_MIKTAR_DOVIZ_ID", this.ODEME_MIKTAR_DOVIZ, "GecmisGunFaizi", 2)});
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Kayıt Eklemek İçin Tıklayınız..";
            this.gridView1.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView1.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowPreview = true;
            this.gridView1.PreviewFieldName = "ACIKLAMA";
            this.gridView1.ViewCaption = "Ödeme";
            // 
            // ODEME_TARIHI
            // 
            this.ODEME_TARIHI.Caption = "Ödeme T.";
            this.ODEME_TARIHI.FieldName = "ODEME_TARIHI";
            this.ODEME_TARIHI.Name = "ODEME_TARIHI";
            this.ODEME_TARIHI.Visible = true;
            this.ODEME_TARIHI.VisibleIndex = 2;
            this.ODEME_TARIHI.Width = 59;
            // 
            // ODEME_MIKTAR
            // 
            this.ODEME_MIKTAR.Caption = "Miktar";
            this.ODEME_MIKTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.ODEME_MIKTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            this.ODEME_MIKTAR.Name = "ODEME_MIKTAR";
            this.ODEME_MIKTAR.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_MIKTAR", "Toplam : {0:###,###,###,##0.##}", 1)});
            this.ODEME_MIKTAR.Visible = true;
            this.ODEME_MIKTAR.VisibleIndex = 3;
            this.ODEME_MIKTAR.Width = 55;
            // 
            // ODEME_MIKTAR_DOVIZ
            // 
            this.ODEME_MIKTAR_DOVIZ.Caption = "BRM";
            this.ODEME_MIKTAR_DOVIZ.ColumnEdit = this.rLueDovizId;
            this.ODEME_MIKTAR_DOVIZ.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            this.ODEME_MIKTAR_DOVIZ.Name = "ODEME_MIKTAR_DOVIZ";
            this.ODEME_MIKTAR_DOVIZ.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_MIKTAR_DOVIZ_ID", "", 2)});
            this.ODEME_MIKTAR_DOVIZ.Visible = true;
            this.ODEME_MIKTAR_DOVIZ.VisibleIndex = 4;
            this.ODEME_MIKTAR_DOVIZ.Width = 33;
            // 
            // rLueDovizId
            // 
            this.rLueDovizId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDovizId.Name = "rLueDovizId";
            // 
            // ODEME_YERI
            // 
            this.ODEME_YERI.Caption = "Ödeme Yeri";
            this.ODEME_YERI.FieldName = "ODEME_YER_ID";
            this.ODEME_YERI.Name = "ODEME_YERI";
            this.ODEME_YERI.Visible = true;
            this.ODEME_YERI.VisibleIndex = 5;
            this.ODEME_YERI.Width = 67;
            // 
            // ODEME_TIP
            // 
            this.ODEME_TIP.Caption = "Ödeme Tipi";
            this.ODEME_TIP.FieldName = "ODEME_TIP_ID";
            this.ODEME_TIP.Name = "ODEME_TIP";
            this.ODEME_TIP.Visible = true;
            this.ODEME_TIP.VisibleIndex = 6;
            this.ODEME_TIP.Width = 65;
            // 
            // ODEYEN_CARI
            // 
            this.ODEYEN_CARI.Caption = "Borçlu";
            this.ODEYEN_CARI.FieldName = "ODEYEN_CARI_ID";
            this.ODEYEN_CARI.Name = "ODEYEN_CARI";
            this.ODEYEN_CARI.Visible = true;
            this.ODEYEN_CARI.VisibleIndex = 0;
            this.ODEYEN_CARI.Width = 41;
            // 
            // BORCLU_ADINA_ODEYEN_CARI
            // 
            this.BORCLU_ADINA_ODEYEN_CARI.Caption = "B.Adına Ödeyen";
            this.BORCLU_ADINA_ODEYEN_CARI.FieldName = "BORCLU_ADINA_ODEYEN_CARI_ID";
            this.BORCLU_ADINA_ODEYEN_CARI.Name = "BORCLU_ADINA_ODEYEN_CARI";
            this.BORCLU_ADINA_ODEYEN_CARI.Width = 90;
            // 
            // ODENEN_CARI
            // 
            this.ODENEN_CARI.Caption = "Alacaklı";
            this.ODENEN_CARI.FieldName = "ODENEN_CARI_ID";
            this.ODENEN_CARI.Name = "ODENEN_CARI";
            this.ODENEN_CARI.Visible = true;
            this.ODENEN_CARI.VisibleIndex = 1;
            this.ODENEN_CARI.Width = 47;
            // 
            // ALACAKLI_ADINA_ODENEN_CARI
            // 
            this.ALACAKLI_ADINA_ODENEN_CARI.Caption = "A.Adına Ödenen";
            this.ALACAKLI_ADINA_ODENEN_CARI.FieldName = "BORCLU_ADINA_ODENEN_CARI_ID";
            this.ALACAKLI_ADINA_ODENEN_CARI.Name = "ALACAKLI_ADINA_ODENEN_CARI";
            this.ALACAKLI_ADINA_ODENEN_CARI.Width = 91;
            // 
            // ALACAK_NEDEN
            // 
            this.ALACAK_NEDEN.Caption = "Alacak Neden";
            this.ALACAK_NEDEN.FieldName = "ALACAK_NEDEN_ID";
            this.ALACAK_NEDEN.Name = "ALACAK_NEDEN";
            this.ALACAK_NEDEN.Width = 77;
            // 
            // ICRADAN_CEKILME_TARIHI
            // 
            this.ICRADAN_CEKILME_TARIHI.Caption = "İcradan Çe. T.";
            this.ICRADAN_CEKILME_TARIHI.FieldName = "ICRADAN_CEKILME_TARIHI";
            this.ICRADAN_CEKILME_TARIHI.Name = "ICRADAN_CEKILME_TARIHI";
            this.ICRADAN_CEKILME_TARIHI.Width = 82;
            // 
            // IHTIYATI_HACIZDE_MI
            // 
            this.IHTIYATI_HACIZDE_MI.Caption = "İ. Hacizde";
            this.IHTIYATI_HACIZDE_MI.FieldName = "IHTIYATI_HACIZDE_MI";
            this.IHTIYATI_HACIZDE_MI.Name = "IHTIYATI_HACIZDE_MI";
            this.IHTIYATI_HACIZDE_MI.Visible = true;
            this.IHTIYATI_HACIZDE_MI.VisibleIndex = 7;
            this.IHTIYATI_HACIZDE_MI.Width = 60;
            // 
            // MAAS_HACZINDEN_MI
            // 
            this.MAAS_HACZINDEN_MI.Caption = "Maaştan";
            this.MAAS_HACZINDEN_MI.FieldName = "MAAS_HACZINDEN_MI";
            this.MAAS_HACZINDEN_MI.Name = "MAAS_HACZINDEN_MI";
            this.MAAS_HACZINDEN_MI.Visible = true;
            this.MAAS_HACZINDEN_MI.VisibleIndex = 8;
            this.MAAS_HACZINDEN_MI.Width = 53;
            // 
            // KIYMETLI_EVRAK_ODENDI_MI
            // 
            this.KIYMETLI_EVRAK_ODENDI_MI.Caption = "Kıy. Ev. Ödendi";
            this.KIYMETLI_EVRAK_ODENDI_MI.FieldName = "KIYMETLI_EVRAK_ODENDI_MI";
            this.KIYMETLI_EVRAK_ODENDI_MI.Name = "KIYMETLI_EVRAK_ODENDI_MI";
            this.KIYMETLI_EVRAK_ODENDI_MI.Width = 86;
            // 
            // KIYMETLI_EVRAK_VADE_TARIHI
            // 
            this.KIYMETLI_EVRAK_VADE_TARIHI.Caption = "Kıy. Evrak T.";
            this.KIYMETLI_EVRAK_VADE_TARIHI.FieldName = "KIYMETLI_EVRAK_VADE_TARIHI";
            this.KIYMETLI_EVRAK_VADE_TARIHI.Name = "KIYMETLI_EVRAK_VADE_TARIHI";
            this.KIYMETLI_EVRAK_VADE_TARIHI.Width = 73;
            // 
            // KIYMETLI_EVRAK_VADESINDE_ODENDI_MI
            // 
            this.KIYMETLI_EVRAK_VADESINDE_ODENDI_MI.Caption = "K. Ev. Vadesindemi Ö.?";
            this.KIYMETLI_EVRAK_VADESINDE_ODENDI_MI.FieldName = "KIYMETLI_EVRAK_VADESINDE_ODENDI_MI";
            this.KIYMETLI_EVRAK_VADESINDE_ODENDI_MI.Name = "KIYMETLI_EVRAK_VADESINDE_ODENDI_MI";
            this.KIYMETLI_EVRAK_VADESINDE_ODENDI_MI.Width = 123;
            // 
            // ACIKLAMA_
            // 
            this.ACIKLAMA_.Caption = "Açıklama";
            this.ACIKLAMA_.FieldName = "ACIKLAMA";
            this.ACIKLAMA_.Name = "ACIKLAMA_";
            this.ACIKLAMA_.Visible = true;
            this.ACIKLAMA_.VisibleIndex = 9;
            this.ACIKLAMA_.Width = 53;
            // 
            // ODEME_MAHSUP_TIP
            // 
            this.ODEME_MAHSUP_TIP.Caption = "Mahsup Tip";
            this.ODEME_MAHSUP_TIP.FieldName = "ODEME_MAHSUP_TIP";
            this.ODEME_MAHSUP_TIP.Name = "ODEME_MAHSUP_TIP";
            this.ODEME_MAHSUP_TIP.Width = 66;
            // 
            // gcOdemePlani
            // 
            this.gcOdemePlani.CustomButtonlarGorunmesin = false;
            this.gcOdemePlani.DataSource = this.bndOdemePlani;
            this.gcOdemePlani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcOdemePlani.DoNotExtendEmbedNavigator = false;
            this.gcOdemePlani.ExternalRepository = this.persistentRepository1;
            this.gcOdemePlani.FilterText = null;
            this.gcOdemePlani.FilterValue = null;
            this.gcOdemePlani.GridlerDuzenlenebilir = true;
            this.gcOdemePlani.GridsFilterControl = null;
            gridLevelNode1.LevelTemplate = this.gridView1;
            gridLevelNode2.LevelTemplate = this.gridView3;
            gridLevelNode2.RelationName = "AV001_TI_BIL_ODEME_DAGILIMCollection";
            gridLevelNode1.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            gridLevelNode1.RelationName = "AV001_TI_BIL_BORCLU_ODEMECollection_From_NN_ICRA_ODEME_PLANI_BORCLU_ODEME";
            gridLevelNode3.LevelTemplate = this.gridView2;
            gridLevelNode3.RelationName = "AV001_TI_BIL_FAIZCollection_From_NN_ICRA_ODEME_PLANI_FAIZ";
            gridLevelNode4.LevelTemplate = this.gridView5;
            gridLevelNode4.RelationName = "OdemePlanlari";
            this.gcOdemePlani.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode3,
            gridLevelNode4});
            this.gcOdemePlani.Location = new System.Drawing.Point(0, 0);
            this.gcOdemePlani.MainView = this.gwOdemePlani;
            this.gcOdemePlani.MyGridStyle = null;
            this.gcOdemePlani.Name = "gcOdemePlani";
            this.gcOdemePlani.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rSpinTutar});
            this.gcOdemePlani.ShowOnlyPredefinedDetails = true;
            this.gcOdemePlani.ShowRowNumbers = false;
            this.gcOdemePlani.SilmeKaldirilsin = false;
            this.gcOdemePlani.Size = new System.Drawing.Size(926, 254);
            this.gcOdemePlani.TabIndex = 1;
            this.gcOdemePlani.TemizleKaldirGorunsunmu = false;
            this.gcOdemePlani.UniqueId = "b2bb7772-fd72-4ebe-97f3-3e7b891af360";
            this.gcOdemePlani.UseEmbeddedNavigator = true;
            this.gcOdemePlani.UseHyperDragDrop = false;
            this.gcOdemePlani.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2,
            this.gridView5,
            this.gwOdemePlani,
            this.gridView3,
            this.gridView1});
            // 
            // persistentRepository1
            // 
            this.persistentRepository1.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueDovizId});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colICRA_ALACAK_NEDEN_ID,
            this.colILAM_ID,
            this.colFAIZ_KALEM_ID,
            this.colEN_SON_FAIZ_HESAPLANMA_TARIHI,
            this.colFAIZ_TAKIPDEN_ONCE_MI,
            this.gridColumn9,
            this.colFAIZ_ORANI,
            this.colFAIZ_BASLANGIC_TARIHI,
            this.colFAIZ_BITIS_TARIHI,
            this.colGUN_FARKI,
            this.colMATRAH_DOVIZ_ID,
            this.colMATRAH_TUTARI,
            this.colFAIZ_TUTARI_DOVIZ_ID,
            this.colFAIZ_TUTARI,
            this.colBSMV_DOVIZ_ID,
            this.colBSMV_TUTARI,
            this.colKKDF_DOVIZ_ID,
            this.colKKDF_TUTARI,
            this.colOIV_DOVIZ_ID,
            this.colOIV_TUTARI,
            this.colKDV_DOVIZ_ID,
            this.colKDV_TUTARI,
            this.colALACAK_NEDEN_TARAF_ID});
            this.gridView2.GridControl = this.gcOdemePlani;
            this.gridView2.GroupCount = 1;
            this.gridView2.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KDV_TUTARI", this.colKDV_TUTARI, "GecmisGunFaizi"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OIV_TUTARI", this.colOIV_TUTARI, "GecmisGunFaizi"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KKDF_TUTARI", this.colKKDF_TUTARI, "GecmisGunFaizi"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BSMV_TUTARI", this.colBSMV_TUTARI, "GecmisGunFaizi"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FAIZ_TUTARI", this.colFAIZ_TUTARI, "GecmisGunFaizi"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GUN_FARKI", this.colGUN_FARKI, "GecmisGunFaizi")});
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView2.OptionsView.ShowGroupedColumns = true;
            this.gridView2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFAIZ_TAKIPDEN_ONCE_MI, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView2.ViewCaption = "Faiz";
            // 
            // colICRA_ALACAK_NEDEN_ID
            // 
            this.colICRA_ALACAK_NEDEN_ID.Caption = "Alacak Neden";
            this.colICRA_ALACAK_NEDEN_ID.ColumnEdit = this.rLueDovizId;
            this.colICRA_ALACAK_NEDEN_ID.FieldName = "ICRA_ALACAK_NEDEN_ID";
            this.colICRA_ALACAK_NEDEN_ID.Name = "colICRA_ALACAK_NEDEN_ID";
            this.colICRA_ALACAK_NEDEN_ID.Visible = true;
            this.colICRA_ALACAK_NEDEN_ID.VisibleIndex = 0;
            // 
            // colILAM_ID
            // 
            this.colILAM_ID.Caption = "İlam";
            this.colILAM_ID.FieldName = "ILAM_ID";
            this.colILAM_ID.Name = "colILAM_ID";
            // 
            // colFAIZ_KALEM_ID
            // 
            this.colFAIZ_KALEM_ID.Caption = "Faiz Kalem";
            this.colFAIZ_KALEM_ID.FieldName = "FAIZ_KALEM_ID";
            this.colFAIZ_KALEM_ID.Name = "colFAIZ_KALEM_ID";
            this.colFAIZ_KALEM_ID.Visible = true;
            this.colFAIZ_KALEM_ID.VisibleIndex = 1;
            // 
            // colEN_SON_FAIZ_HESAPLANMA_TARIHI
            // 
            this.colEN_SON_FAIZ_HESAPLANMA_TARIHI.Caption = "Son F. Hes. T.";
            this.colEN_SON_FAIZ_HESAPLANMA_TARIHI.FieldName = "EN_SON_FAIZ_HESAPLANMA_TARIHI";
            this.colEN_SON_FAIZ_HESAPLANMA_TARIHI.Name = "colEN_SON_FAIZ_HESAPLANMA_TARIHI";
            this.colEN_SON_FAIZ_HESAPLANMA_TARIHI.Visible = true;
            this.colEN_SON_FAIZ_HESAPLANMA_TARIHI.VisibleIndex = 2;
            // 
            // colFAIZ_TAKIPDEN_ONCE_MI
            // 
            this.colFAIZ_TAKIPDEN_ONCE_MI.Caption = "Faiz Takipten Öncemi";
            this.colFAIZ_TAKIPDEN_ONCE_MI.FieldName = "FAIZ_TAKIPDEN_ONCE_MI";
            this.colFAIZ_TAKIPDEN_ONCE_MI.Name = "colFAIZ_TAKIPDEN_ONCE_MI";
            this.colFAIZ_TAKIPDEN_ONCE_MI.Visible = true;
            this.colFAIZ_TAKIPDEN_ONCE_MI.VisibleIndex = 3;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Faiz Tip";
            this.gridColumn9.FieldName = "FAIZ_TIP_ID";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            // 
            // colFAIZ_ORANI
            // 
            this.colFAIZ_ORANI.Caption = "Faiz Oranı";
            this.colFAIZ_ORANI.FieldName = "FAIZ_ORANI";
            this.colFAIZ_ORANI.Name = "colFAIZ_ORANI";
            this.colFAIZ_ORANI.Visible = true;
            this.colFAIZ_ORANI.VisibleIndex = 5;
            // 
            // colFAIZ_BASLANGIC_TARIHI
            // 
            this.colFAIZ_BASLANGIC_TARIHI.Caption = "Faizm Baş. T.";
            this.colFAIZ_BASLANGIC_TARIHI.FieldName = "FAIZ_BASLANGIC_TARIHI";
            this.colFAIZ_BASLANGIC_TARIHI.Name = "colFAIZ_BASLANGIC_TARIHI";
            this.colFAIZ_BASLANGIC_TARIHI.Visible = true;
            this.colFAIZ_BASLANGIC_TARIHI.VisibleIndex = 6;
            // 
            // colFAIZ_BITIS_TARIHI
            // 
            this.colFAIZ_BITIS_TARIHI.Caption = "Bitiş T.";
            this.colFAIZ_BITIS_TARIHI.FieldName = "FAIZ_BITIS_TARIHI";
            this.colFAIZ_BITIS_TARIHI.Name = "colFAIZ_BITIS_TARIHI";
            this.colFAIZ_BITIS_TARIHI.Visible = true;
            this.colFAIZ_BITIS_TARIHI.VisibleIndex = 7;
            // 
            // colGUN_FARKI
            // 
            this.colGUN_FARKI.Caption = "Gün Farkı";
            this.colGUN_FARKI.FieldName = "GUN_FARKI";
            this.colGUN_FARKI.Name = "colGUN_FARKI";
            this.colGUN_FARKI.Visible = true;
            this.colGUN_FARKI.VisibleIndex = 20;
            // 
            // colMATRAH_DOVIZ_ID
            // 
            this.colMATRAH_DOVIZ_ID.Caption = "Brm.";
            this.colMATRAH_DOVIZ_ID.ColumnEdit = this.rLueDovizId;
            this.colMATRAH_DOVIZ_ID.FieldName = "MATRAH_DOVIZ_ID";
            this.colMATRAH_DOVIZ_ID.Name = "colMATRAH_DOVIZ_ID";
            this.colMATRAH_DOVIZ_ID.Visible = true;
            this.colMATRAH_DOVIZ_ID.VisibleIndex = 8;
            // 
            // colMATRAH_TUTARI
            // 
            this.colMATRAH_TUTARI.Caption = "Matrah Tutarı";
            this.colMATRAH_TUTARI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colMATRAH_TUTARI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMATRAH_TUTARI.FieldName = "MATRAH_TUTARI";
            this.colMATRAH_TUTARI.Name = "colMATRAH_TUTARI";
            this.colMATRAH_TUTARI.Visible = true;
            this.colMATRAH_TUTARI.VisibleIndex = 9;
            // 
            // colFAIZ_TUTARI_DOVIZ_ID
            // 
            this.colFAIZ_TUTARI_DOVIZ_ID.Caption = "BRM";
            this.colFAIZ_TUTARI_DOVIZ_ID.ColumnEdit = this.rLueDovizId;
            this.colFAIZ_TUTARI_DOVIZ_ID.FieldName = "FAIZ_TUTARI_DOVIZ_ID";
            this.colFAIZ_TUTARI_DOVIZ_ID.Name = "colFAIZ_TUTARI_DOVIZ_ID";
            this.colFAIZ_TUTARI_DOVIZ_ID.Visible = true;
            this.colFAIZ_TUTARI_DOVIZ_ID.VisibleIndex = 10;
            // 
            // colFAIZ_TUTARI
            // 
            this.colFAIZ_TUTARI.Caption = "Tutarı";
            this.colFAIZ_TUTARI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colFAIZ_TUTARI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFAIZ_TUTARI.FieldName = "FAIZ_TUTARI";
            this.colFAIZ_TUTARI.Name = "colFAIZ_TUTARI";
            this.colFAIZ_TUTARI.Visible = true;
            this.colFAIZ_TUTARI.VisibleIndex = 11;
            // 
            // colBSMV_DOVIZ_ID
            // 
            this.colBSMV_DOVIZ_ID.Caption = "BRM";
            this.colBSMV_DOVIZ_ID.ColumnEdit = this.rLueDovizId;
            this.colBSMV_DOVIZ_ID.FieldName = "BSMV_DOVIZ_ID";
            this.colBSMV_DOVIZ_ID.Name = "colBSMV_DOVIZ_ID";
            this.colBSMV_DOVIZ_ID.Visible = true;
            this.colBSMV_DOVIZ_ID.VisibleIndex = 12;
            // 
            // colBSMV_TUTARI
            // 
            this.colBSMV_TUTARI.Caption = "BSMV Tutarı";
            this.colBSMV_TUTARI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colBSMV_TUTARI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBSMV_TUTARI.FieldName = "BSMV_TUTARI";
            this.colBSMV_TUTARI.Name = "colBSMV_TUTARI";
            this.colBSMV_TUTARI.Visible = true;
            this.colBSMV_TUTARI.VisibleIndex = 13;
            // 
            // colKKDF_DOVIZ_ID
            // 
            this.colKKDF_DOVIZ_ID.Caption = "BRM";
            this.colKKDF_DOVIZ_ID.ColumnEdit = this.rLueDovizId;
            this.colKKDF_DOVIZ_ID.FieldName = "KKDF_DOVIZ_ID";
            this.colKKDF_DOVIZ_ID.Name = "colKKDF_DOVIZ_ID";
            this.colKKDF_DOVIZ_ID.Visible = true;
            this.colKKDF_DOVIZ_ID.VisibleIndex = 14;
            // 
            // colKKDF_TUTARI
            // 
            this.colKKDF_TUTARI.Caption = "KKDF Tutarı";
            this.colKKDF_TUTARI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colKKDF_TUTARI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKKDF_TUTARI.FieldName = "KKDF_TUTARI";
            this.colKKDF_TUTARI.Name = "colKKDF_TUTARI";
            this.colKKDF_TUTARI.Visible = true;
            this.colKKDF_TUTARI.VisibleIndex = 15;
            // 
            // colOIV_DOVIZ_ID
            // 
            this.colOIV_DOVIZ_ID.Caption = "BRM";
            this.colOIV_DOVIZ_ID.ColumnEdit = this.rLueDovizId;
            this.colOIV_DOVIZ_ID.FieldName = "OIV_DOVIZ_ID";
            this.colOIV_DOVIZ_ID.Name = "colOIV_DOVIZ_ID";
            this.colOIV_DOVIZ_ID.Visible = true;
            this.colOIV_DOVIZ_ID.VisibleIndex = 16;
            // 
            // colOIV_TUTARI
            // 
            this.colOIV_TUTARI.Caption = "OIV Tutarı";
            this.colOIV_TUTARI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colOIV_TUTARI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOIV_TUTARI.FieldName = "OIV_TUTARI";
            this.colOIV_TUTARI.Name = "colOIV_TUTARI";
            this.colOIV_TUTARI.Visible = true;
            this.colOIV_TUTARI.VisibleIndex = 17;
            // 
            // colKDV_DOVIZ_ID
            // 
            this.colKDV_DOVIZ_ID.Caption = "BRM";
            this.colKDV_DOVIZ_ID.ColumnEdit = this.rLueDovizId;
            this.colKDV_DOVIZ_ID.FieldName = "KDV_DOVIZ_ID";
            this.colKDV_DOVIZ_ID.Name = "colKDV_DOVIZ_ID";
            this.colKDV_DOVIZ_ID.Visible = true;
            this.colKDV_DOVIZ_ID.VisibleIndex = 18;
            // 
            // colKDV_TUTARI
            // 
            this.colKDV_TUTARI.Caption = "KDV Tutarı";
            this.colKDV_TUTARI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colKDV_TUTARI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKDV_TUTARI.FieldName = "KDV_TUTARI";
            this.colKDV_TUTARI.Name = "colKDV_TUTARI";
            this.colKDV_TUTARI.Visible = true;
            this.colKDV_TUTARI.VisibleIndex = 19;
            // 
            // colALACAK_NEDEN_TARAF_ID
            // 
            this.colALACAK_NEDEN_TARAF_ID.Caption = "Alacak Taraf";
            this.colALACAK_NEDEN_TARAF_ID.FieldName = "ALACAK_NEDEN_TARAF_ID";
            this.colALACAK_NEDEN_TARAF_ID.Name = "colALACAK_NEDEN_TARAF_ID";
            this.colALACAK_NEDEN_TARAF_ID.Visible = true;
            this.colALACAK_NEDEN_TARAF_ID.VisibleIndex = 21;
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn26,
            this.colBORC_TUTARI1,
            this.colBORC_TUTARI_DOVIZ_ID1,
            this.colANA_PARAYA_ODENEN,
            this.colANA_PARAYA_ODENEN_DOVIZ_ID,
            this.colFAIZE_ODENEN,
            this.colFAIZE_ODENEN_DOVIZ_ID,
            this.colDIGERLERINE_ODENEN,
            this.colDIGERLERINE_ODENEN_DOVIZ_ID,
            this.colODEME1,
            this.colODEME_DOVIZ_ID1,
            this.colBAKIYE1,
            this.colBAKIYE_DOVIZ_ID1,
            this.colGUN1,
            this.colFAIZ_TIP_ID1,
            this.colFAIZ_ORAN1,
            this.colDEVRE_FAIZI1,
            this.colDEVRE_FAIZI_DOVIZ_ID1});
            this.gridView5.GridControl = this.gcOdemePlani;
            this.gridView5.Name = "gridView5";
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Tarih";
            this.gridColumn26.FieldName = "TARIH";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 0;
            // 
            // colBORC_TUTARI1
            // 
            this.colBORC_TUTARI1.ColumnEdit = this.rSpinTutar;
            this.colBORC_TUTARI1.FieldName = "BORC_TUTARI";
            this.colBORC_TUTARI1.Name = "colBORC_TUTARI1";
            this.colBORC_TUTARI1.Visible = true;
            this.colBORC_TUTARI1.VisibleIndex = 1;
            // 
            // rSpinTutar
            // 
            this.rSpinTutar.AutoHeight = false;
            this.rSpinTutar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rSpinTutar.Name = "rSpinTutar";
            // 
            // colBORC_TUTARI_DOVIZ_ID1
            // 
            this.colBORC_TUTARI_DOVIZ_ID1.Caption = " ";
            this.colBORC_TUTARI_DOVIZ_ID1.ColumnEdit = this.rLueDovizId;
            this.colBORC_TUTARI_DOVIZ_ID1.FieldName = "BORC_TUTARI_DOVIZ_ID";
            this.colBORC_TUTARI_DOVIZ_ID1.Name = "colBORC_TUTARI_DOVIZ_ID1";
            this.colBORC_TUTARI_DOVIZ_ID1.Visible = true;
            this.colBORC_TUTARI_DOVIZ_ID1.VisibleIndex = 2;
            // 
            // colANA_PARAYA_ODENEN
            // 
            this.colANA_PARAYA_ODENEN.ColumnEdit = this.rSpinTutar;
            this.colANA_PARAYA_ODENEN.FieldName = "ANA_PARAYA_ODENEN";
            this.colANA_PARAYA_ODENEN.Name = "colANA_PARAYA_ODENEN";
            this.colANA_PARAYA_ODENEN.Visible = true;
            this.colANA_PARAYA_ODENEN.VisibleIndex = 3;
            // 
            // colANA_PARAYA_ODENEN_DOVIZ_ID
            // 
            this.colANA_PARAYA_ODENEN_DOVIZ_ID.Caption = " ";
            this.colANA_PARAYA_ODENEN_DOVIZ_ID.ColumnEdit = this.rLueDovizId;
            this.colANA_PARAYA_ODENEN_DOVIZ_ID.FieldName = "ANA_PARAYA_ODENEN_DOVIZ_ID";
            this.colANA_PARAYA_ODENEN_DOVIZ_ID.Name = "colANA_PARAYA_ODENEN_DOVIZ_ID";
            this.colANA_PARAYA_ODENEN_DOVIZ_ID.Visible = true;
            this.colANA_PARAYA_ODENEN_DOVIZ_ID.VisibleIndex = 4;
            // 
            // colFAIZE_ODENEN
            // 
            this.colFAIZE_ODENEN.ColumnEdit = this.rSpinTutar;
            this.colFAIZE_ODENEN.FieldName = "FAIZE_ODENEN";
            this.colFAIZE_ODENEN.Name = "colFAIZE_ODENEN";
            this.colFAIZE_ODENEN.Visible = true;
            this.colFAIZE_ODENEN.VisibleIndex = 5;
            // 
            // colFAIZE_ODENEN_DOVIZ_ID
            // 
            this.colFAIZE_ODENEN_DOVIZ_ID.Caption = " ";
            this.colFAIZE_ODENEN_DOVIZ_ID.ColumnEdit = this.rLueDovizId;
            this.colFAIZE_ODENEN_DOVIZ_ID.FieldName = "FAIZE_ODENEN_DOVIZ_ID";
            this.colFAIZE_ODENEN_DOVIZ_ID.Name = "colFAIZE_ODENEN_DOVIZ_ID";
            this.colFAIZE_ODENEN_DOVIZ_ID.Visible = true;
            this.colFAIZE_ODENEN_DOVIZ_ID.VisibleIndex = 6;
            // 
            // colDIGERLERINE_ODENEN
            // 
            this.colDIGERLERINE_ODENEN.ColumnEdit = this.rSpinTutar;
            this.colDIGERLERINE_ODENEN.FieldName = "DIGERLERINE_ODENEN";
            this.colDIGERLERINE_ODENEN.Name = "colDIGERLERINE_ODENEN";
            this.colDIGERLERINE_ODENEN.Visible = true;
            this.colDIGERLERINE_ODENEN.VisibleIndex = 7;
            // 
            // colDIGERLERINE_ODENEN_DOVIZ_ID
            // 
            this.colDIGERLERINE_ODENEN_DOVIZ_ID.Caption = " ";
            this.colDIGERLERINE_ODENEN_DOVIZ_ID.ColumnEdit = this.rLueDovizId;
            this.colDIGERLERINE_ODENEN_DOVIZ_ID.FieldName = "DIGERLERINE_ODENEN_DOVIZ_ID";
            this.colDIGERLERINE_ODENEN_DOVIZ_ID.Name = "colDIGERLERINE_ODENEN_DOVIZ_ID";
            this.colDIGERLERINE_ODENEN_DOVIZ_ID.Visible = true;
            this.colDIGERLERINE_ODENEN_DOVIZ_ID.VisibleIndex = 8;
            // 
            // colODEME1
            // 
            this.colODEME1.ColumnEdit = this.rSpinTutar;
            this.colODEME1.FieldName = "ODEME";
            this.colODEME1.Name = "colODEME1";
            this.colODEME1.Visible = true;
            this.colODEME1.VisibleIndex = 9;
            // 
            // colODEME_DOVIZ_ID1
            // 
            this.colODEME_DOVIZ_ID1.Caption = " ";
            this.colODEME_DOVIZ_ID1.ColumnEdit = this.rLueDovizId;
            this.colODEME_DOVIZ_ID1.FieldName = "ODEME_DOVIZ_ID";
            this.colODEME_DOVIZ_ID1.Name = "colODEME_DOVIZ_ID1";
            this.colODEME_DOVIZ_ID1.Visible = true;
            this.colODEME_DOVIZ_ID1.VisibleIndex = 10;
            // 
            // colBAKIYE1
            // 
            this.colBAKIYE1.ColumnEdit = this.rSpinTutar;
            this.colBAKIYE1.FieldName = "BAKIYE";
            this.colBAKIYE1.Name = "colBAKIYE1";
            this.colBAKIYE1.Visible = true;
            this.colBAKIYE1.VisibleIndex = 11;
            // 
            // colBAKIYE_DOVIZ_ID1
            // 
            this.colBAKIYE_DOVIZ_ID1.Caption = " ";
            this.colBAKIYE_DOVIZ_ID1.ColumnEdit = this.rLueDovizId;
            this.colBAKIYE_DOVIZ_ID1.FieldName = "BAKIYE_DOVIZ_ID";
            this.colBAKIYE_DOVIZ_ID1.Name = "colBAKIYE_DOVIZ_ID1";
            this.colBAKIYE_DOVIZ_ID1.Visible = true;
            this.colBAKIYE_DOVIZ_ID1.VisibleIndex = 12;
            // 
            // colGUN1
            // 
            this.colGUN1.FieldName = "GUN";
            this.colGUN1.Name = "colGUN1";
            this.colGUN1.Visible = true;
            this.colGUN1.VisibleIndex = 13;
            // 
            // colFAIZ_TIP_ID1
            // 
            this.colFAIZ_TIP_ID1.FieldName = "FAIZ_TIP_ID";
            this.colFAIZ_TIP_ID1.Name = "colFAIZ_TIP_ID1";
            this.colFAIZ_TIP_ID1.Visible = true;
            this.colFAIZ_TIP_ID1.VisibleIndex = 14;
            // 
            // colFAIZ_ORAN1
            // 
            this.colFAIZ_ORAN1.FieldName = "FAIZ_ORAN";
            this.colFAIZ_ORAN1.Name = "colFAIZ_ORAN1";
            this.colFAIZ_ORAN1.Visible = true;
            this.colFAIZ_ORAN1.VisibleIndex = 15;
            // 
            // colDEVRE_FAIZI1
            // 
            this.colDEVRE_FAIZI1.ColumnEdit = this.rSpinTutar;
            this.colDEVRE_FAIZI1.FieldName = "DEVRE_FAIZI";
            this.colDEVRE_FAIZI1.Name = "colDEVRE_FAIZI1";
            this.colDEVRE_FAIZI1.Visible = true;
            this.colDEVRE_FAIZI1.VisibleIndex = 16;
            // 
            // colDEVRE_FAIZI_DOVIZ_ID1
            // 
            this.colDEVRE_FAIZI_DOVIZ_ID1.Caption = " ";
            this.colDEVRE_FAIZI_DOVIZ_ID1.ColumnEdit = this.rLueDovizId;
            this.colDEVRE_FAIZI_DOVIZ_ID1.FieldName = "DEVRE_FAIZI_DOVIZ_ID";
            this.colDEVRE_FAIZI_DOVIZ_ID1.Name = "colDEVRE_FAIZI_DOVIZ_ID1";
            this.colDEVRE_FAIZI_DOVIZ_ID1.Visible = true;
            this.colDEVRE_FAIZI_DOVIZ_ID1.VisibleIndex = 17;
            // 
            // gwOdemePlani
            // 
            this.gwOdemePlani.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.gwOdemePlani.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colFOY_TARAF_ID,
            this.colTARIH,
            this.colBORC_TUTARI,
            this.colANAPARA,
            this.colBORC_TUTARI_DOVIZ_ID,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.colODEME,
            this.colODEME_DOVIZ_ID,
            this.colBAKIYE,
            this.colBAKIYE_DOVIZ_ID,
            this.colGUN,
            this.colFAIZ_TIP_ID,
            this.colFAIZ_ORAN,
            this.colDEVRE_FAIZI,
            this.colDEVRE_FAIZI_DOVIZ_ID,
            this.colBSMV_3});
            this.gwOdemePlani.CustomizationFormBounds = new System.Drawing.Rectangle(422, 380, 223, 236);
            this.gwOdemePlani.GridControl = this.gcOdemePlani;
            this.gwOdemePlani.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BORC_TUTARI", this.colBORC_TUTARI, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BORC_TUTARI_DOVIZ_ID", this.colBORC_TUTARI_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME", this.colODEME, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_DOVIZ_ID", this.colODEME_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BAKIYE", this.colBAKIYE, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BAKIYE_DOVIZ_ID", this.colBAKIYE_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DEVRE_FAIZI", this.colDEVRE_FAIZI, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DEVRE_FAIZI_DOVIZ_ID", this.colDEVRE_FAIZI_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BORC_TUTARI", this.colBORC_TUTARI, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BORC_TUTARI_DOVIZ_ID", this.colBORC_TUTARI_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME", this.colODEME, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_DOVIZ_ID", this.colODEME_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BAKIYE", this.colBAKIYE, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BAKIYE_DOVIZ_ID", this.colBAKIYE_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DEVRE_FAIZI", this.colDEVRE_FAIZI, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DEVRE_FAIZI_DOVIZ_ID", this.colDEVRE_FAIZI_DOVIZ_ID, "{0}")});
            this.gwOdemePlani.IndicatorWidth = 20;
            this.gwOdemePlani.Name = "gwOdemePlani";
            this.gwOdemePlani.OptionsBehavior.Editable = false;
            this.gwOdemePlani.OptionsView.ColumnAutoWidth = false;
            this.gwOdemePlani.OptionsView.ShowAutoFilterRow = true;
            this.gwOdemePlani.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwOdemePlani.OptionsView.ShowFooter = true;
            this.gwOdemePlani.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gwOdemePlani_FocusedRowChanged);
            this.gwOdemePlani.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gwOdemePlani_CustomColumnDisplayText);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Ödeme Planı";
            this.gridBand1.Columns.Add(this.colFOY_TARAF_ID);
            this.gridBand1.Columns.Add(this.colTARIH);
            this.gridBand1.Columns.Add(this.colBORC_TUTARI);
            this.gridBand1.Columns.Add(this.colBORC_TUTARI_DOVIZ_ID);
            this.gridBand1.Columns.Add(this.colANAPARA);
            this.gridBand1.Columns.Add(this.gridColumn13);
            this.gridBand1.Columns.Add(this.gridColumn14);
            this.gridBand1.Columns.Add(this.gridColumn15);
            this.gridBand1.Columns.Add(this.gridColumn16);
            this.gridBand1.Columns.Add(this.gridColumn17);
            this.gridBand1.Columns.Add(this.gridColumn18);
            this.gridBand1.Columns.Add(this.colODEME);
            this.gridBand1.Columns.Add(this.colODEME_DOVIZ_ID);
            this.gridBand1.Columns.Add(this.colBAKIYE);
            this.gridBand1.Columns.Add(this.colBAKIYE_DOVIZ_ID);
            this.gridBand1.Columns.Add(this.colFAIZ_TIP_ID);
            this.gridBand1.Columns.Add(this.colFAIZ_ORAN);
            this.gridBand1.Columns.Add(this.colGUN);
            this.gridBand1.Columns.Add(this.colDEVRE_FAIZI);
            this.gridBand1.Columns.Add(this.colDEVRE_FAIZI_DOVIZ_ID);
            this.gridBand1.Columns.Add(this.colBSMV_3);
            this.gridBand1.MinWidth = 20;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 894;
            // 
            // colFOY_TARAF_ID
            // 
            this.colFOY_TARAF_ID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.colFOY_TARAF_ID.AppearanceCell.Options.UseFont = true;
            this.colFOY_TARAF_ID.Caption = "Taraf";
            this.colFOY_TARAF_ID.FieldName = "FOY_TARAF_ID";
            this.colFOY_TARAF_ID.Name = "colFOY_TARAF_ID";
            this.colFOY_TARAF_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colTARIH
            // 
            this.colTARIH.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.colTARIH.AppearanceCell.Options.UseFont = true;
            this.colTARIH.Caption = "Tarih";
            this.colTARIH.DisplayFormat.FormatString = "d";
            this.colTARIH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTARIH.FieldName = "TARIH";
            this.colTARIH.Name = "colTARIH";
            this.colTARIH.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTARIH.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colTARIH.Visible = true;
            this.colTARIH.Width = 70;
            // 
            // colBORC_TUTARI
            // 
            this.colBORC_TUTARI.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.colBORC_TUTARI.AppearanceCell.Options.UseFont = true;
            this.colBORC_TUTARI.Caption = "Borç Tutarı";
            this.colBORC_TUTARI.ColumnEdit = this.rSpinTutar;
            this.colBORC_TUTARI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colBORC_TUTARI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBORC_TUTARI.FieldName = "BORC_TUTARI";
            this.colBORC_TUTARI.Name = "colBORC_TUTARI";
            this.colBORC_TUTARI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colBORC_TUTARI.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BORC_TUTARI", "{0:###,###,###,###,##0.00}")});
            this.colBORC_TUTARI.ToolTip = "Toplam";
            this.colBORC_TUTARI.Visible = true;
            this.colBORC_TUTARI.Width = 90;
            // 
            // colBORC_TUTARI_DOVIZ_ID
            // 
            this.colBORC_TUTARI_DOVIZ_ID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.colBORC_TUTARI_DOVIZ_ID.AppearanceCell.Options.UseFont = true;
            this.colBORC_TUTARI_DOVIZ_ID.Caption = "Brm";
            this.colBORC_TUTARI_DOVIZ_ID.ColumnEdit = this.rLueDovizId;
            this.colBORC_TUTARI_DOVIZ_ID.CustomizationCaption = "BORC_TUTARI_DOVIZ_ID";
            this.colBORC_TUTARI_DOVIZ_ID.FieldName = "BORC_TUTARI_DOVIZ_ID";
            this.colBORC_TUTARI_DOVIZ_ID.Name = "colBORC_TUTARI_DOVIZ_ID";
            this.colBORC_TUTARI_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colBORC_TUTARI_DOVIZ_ID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BORC_TUTARI_DOVIZ_ID", "{0}")});
            this.colBORC_TUTARI_DOVIZ_ID.ToolTip = "BORC TUTARI Birim";
            this.colBORC_TUTARI_DOVIZ_ID.Visible = true;
            this.colBORC_TUTARI_DOVIZ_ID.Width = 30;
            // 
            // colANAPARA
            // 
            this.colANAPARA.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.colANAPARA.AppearanceCell.Options.UseFont = true;
            this.colANAPARA.Caption = "KLN ANAPARA";
            this.colANAPARA.ColumnEdit = this.rSpinTutar;
            this.colANAPARA.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colANAPARA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colANAPARA.Name = "colANAPARA";
            this.colANAPARA.OptionsColumn.ReadOnly = true;
            this.colANAPARA.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colANAPARA.Width = 95;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.gridColumn13.AppearanceCell.Options.UseFont = true;
            this.gridColumn13.Caption = "Anaparaya";
            this.gridColumn13.ColumnEdit = this.rSpinTutar;
            this.gridColumn13.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13.FieldName = "ANA_PARAYA_ODENEN";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.gridColumn13.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ANA_PARAYA_ODENEN", "{0:###,###,###,###,##0.00}")});
            this.gridColumn13.ToolTip = "Toplam";
            this.gridColumn13.Visible = true;
            this.gridColumn13.Width = 87;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.gridColumn14.AppearanceCell.Options.UseFont = true;
            this.gridColumn14.Caption = "Brm";
            this.gridColumn14.ColumnEdit = this.rLueDovizId;
            this.gridColumn14.CustomizationCaption = "ANA_PARAYA_ODENEN_DOVIZ_ID";
            this.gridColumn14.FieldName = "ANA_PARAYA_ODENEN_DOVIZ_ID";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.gridColumn14.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ANA_PARAYA_ODENEN_DOVIZ_ID", "{0}")});
            this.gridColumn14.ToolTip = "ANA PARAYA ODENEN Birim";
            this.gridColumn14.Width = 30;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.gridColumn15.AppearanceCell.Options.UseFont = true;
            this.gridColumn15.Caption = "Faize";
            this.gridColumn15.ColumnEdit = this.rSpinTutar;
            this.gridColumn15.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn15.FieldName = "FAIZE_ODENEN";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.gridColumn15.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FAIZE_ODENEN", "{0:###,###,###,###,##0.00}")});
            this.gridColumn15.ToolTip = "Toplam";
            this.gridColumn15.Visible = true;
            this.gridColumn15.Width = 69;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.gridColumn16.AppearanceCell.Options.UseFont = true;
            this.gridColumn16.Caption = "Brm";
            this.gridColumn16.ColumnEdit = this.rLueDovizId;
            this.gridColumn16.CustomizationCaption = "FAIZE_ODENEN_DOVIZ_ID";
            this.gridColumn16.FieldName = "FAIZE_ODENEN_DOVIZ_ID";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.gridColumn16.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FAIZE_ODENEN_DOVIZ_ID", "{0}")});
            this.gridColumn16.ToolTip = "FAIZE ODENEN Birim";
            this.gridColumn16.Width = 30;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.gridColumn17.AppearanceCell.Options.UseFont = true;
            this.gridColumn17.Caption = "Diğer Giderlere";
            this.gridColumn17.ColumnEdit = this.rSpinTutar;
            this.gridColumn17.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn17.FieldName = "DIGERLERINE_ODENEN";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.gridColumn17.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGERLERINE_ODENEN", "{0:###,###,###,###,##0.00}")});
            this.gridColumn17.ToolTip = "Toplam";
            this.gridColumn17.Visible = true;
            this.gridColumn17.Width = 95;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.gridColumn18.AppearanceCell.Options.UseFont = true;
            this.gridColumn18.Caption = "Brm";
            this.gridColumn18.ColumnEdit = this.rLueDovizId;
            this.gridColumn18.CustomizationCaption = "DIGERLERINE_ODENEN_DOVIZ_ID";
            this.gridColumn18.FieldName = "DIGERLERINE_ODENEN_DOVIZ_ID";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.gridColumn18.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGERLERINE_ODENEN_DOVIZ_ID", "{0}")});
            this.gridColumn18.ToolTip = "DIGERLERINE ODENEN Birim";
            this.gridColumn18.Width = 30;
            // 
            // colODEME
            // 
            this.colODEME.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.colODEME.AppearanceCell.Options.UseFont = true;
            this.colODEME.Caption = "Ödeme";
            this.colODEME.ColumnEdit = this.rSpinTutar;
            this.colODEME.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colODEME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colODEME.FieldName = "ODEME";
            this.colODEME.Name = "colODEME";
            this.colODEME.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colODEME.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME", "{0:###,###,###,###,##0.00}")});
            this.colODEME.ToolTip = "Toplam";
            this.colODEME.Visible = true;
            this.colODEME.Width = 107;
            // 
            // colODEME_DOVIZ_ID
            // 
            this.colODEME_DOVIZ_ID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.colODEME_DOVIZ_ID.AppearanceCell.Options.UseFont = true;
            this.colODEME_DOVIZ_ID.Caption = "Brm";
            this.colODEME_DOVIZ_ID.ColumnEdit = this.rLueDovizId;
            this.colODEME_DOVIZ_ID.CustomizationCaption = "ODEME_DOVIZ_ID";
            this.colODEME_DOVIZ_ID.FieldName = "ODEME_DOVIZ_ID";
            this.colODEME_DOVIZ_ID.Name = "colODEME_DOVIZ_ID";
            this.colODEME_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colODEME_DOVIZ_ID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_DOVIZ_ID", "{0}")});
            this.colODEME_DOVIZ_ID.ToolTip = "ODEME Birim";
            this.colODEME_DOVIZ_ID.Width = 30;
            // 
            // colBAKIYE
            // 
            this.colBAKIYE.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.colBAKIYE.AppearanceCell.Options.UseFont = true;
            this.colBAKIYE.Caption = "Bakiye";
            this.colBAKIYE.ColumnEdit = this.rSpinTutar;
            this.colBAKIYE.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colBAKIYE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBAKIYE.FieldName = "BAKIYE";
            this.colBAKIYE.Name = "colBAKIYE";
            this.colBAKIYE.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colBAKIYE.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BAKIYE", "{0:###,###,###,###,##0.00}")});
            this.colBAKIYE.ToolTip = "Toplam";
            this.colBAKIYE.Visible = true;
            this.colBAKIYE.Width = 92;
            // 
            // colBAKIYE_DOVIZ_ID
            // 
            this.colBAKIYE_DOVIZ_ID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.colBAKIYE_DOVIZ_ID.AppearanceCell.Options.UseFont = true;
            this.colBAKIYE_DOVIZ_ID.Caption = "Brm";
            this.colBAKIYE_DOVIZ_ID.ColumnEdit = this.rLueDovizId;
            this.colBAKIYE_DOVIZ_ID.CustomizationCaption = "BAKIYE_DOVIZ_ID";
            this.colBAKIYE_DOVIZ_ID.FieldName = "BAKIYE_DOVIZ_ID";
            this.colBAKIYE_DOVIZ_ID.Name = "colBAKIYE_DOVIZ_ID";
            this.colBAKIYE_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colBAKIYE_DOVIZ_ID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BAKIYE_DOVIZ_ID", "{0}")});
            this.colBAKIYE_DOVIZ_ID.ToolTip = "BAKIYE Birim";
            this.colBAKIYE_DOVIZ_ID.Width = 30;
            // 
            // colFAIZ_TIP_ID
            // 
            this.colFAIZ_TIP_ID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.colFAIZ_TIP_ID.AppearanceCell.Options.UseFont = true;
            this.colFAIZ_TIP_ID.Caption = "Faiz Tipi";
            this.colFAIZ_TIP_ID.FieldName = "FAIZ_TIP_ID";
            this.colFAIZ_TIP_ID.Name = "colFAIZ_TIP_ID";
            this.colFAIZ_TIP_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colFAIZ_TIP_ID.Width = 72;
            // 
            // colFAIZ_ORAN
            // 
            this.colFAIZ_ORAN.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.colFAIZ_ORAN.AppearanceCell.Options.UseFont = true;
            this.colFAIZ_ORAN.Caption = "Faiz Oranı";
            this.colFAIZ_ORAN.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colFAIZ_ORAN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFAIZ_ORAN.FieldName = "FAIZ_ORAN";
            this.colFAIZ_ORAN.Name = "colFAIZ_ORAN";
            this.colFAIZ_ORAN.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colFAIZ_ORAN.Visible = true;
            this.colFAIZ_ORAN.Width = 73;
            // 
            // colGUN
            // 
            this.colGUN.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.colGUN.AppearanceCell.Options.UseFont = true;
            this.colGUN.Caption = "Gün";
            this.colGUN.FieldName = "GUN";
            this.colGUN.Name = "colGUN";
            this.colGUN.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colGUN.Visible = true;
            this.colGUN.Width = 39;
            // 
            // colDEVRE_FAIZI
            // 
            this.colDEVRE_FAIZI.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.colDEVRE_FAIZI.AppearanceCell.Options.UseFont = true;
            this.colDEVRE_FAIZI.Caption = "Devre Faizi";
            this.colDEVRE_FAIZI.ColumnEdit = this.rSpinTutar;
            this.colDEVRE_FAIZI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colDEVRE_FAIZI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDEVRE_FAIZI.FieldName = "DEVRE_FAIZI";
            this.colDEVRE_FAIZI.Name = "colDEVRE_FAIZI";
            this.colDEVRE_FAIZI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colDEVRE_FAIZI.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DEVRE_FAIZI", "{0:###,###,###,###,##0.00}")});
            this.colDEVRE_FAIZI.ToolTip = "Toplam";
            this.colDEVRE_FAIZI.Visible = true;
            this.colDEVRE_FAIZI.Width = 77;
            // 
            // colDEVRE_FAIZI_DOVIZ_ID
            // 
            this.colDEVRE_FAIZI_DOVIZ_ID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.colDEVRE_FAIZI_DOVIZ_ID.AppearanceCell.Options.UseFont = true;
            this.colDEVRE_FAIZI_DOVIZ_ID.Caption = "Brm";
            this.colDEVRE_FAIZI_DOVIZ_ID.ColumnEdit = this.rLueDovizId;
            this.colDEVRE_FAIZI_DOVIZ_ID.CustomizationCaption = "DEVRE_FAIZI_DOVIZ_ID";
            this.colDEVRE_FAIZI_DOVIZ_ID.FieldName = "DEVRE_FAIZI_DOVIZ_ID";
            this.colDEVRE_FAIZI_DOVIZ_ID.Name = "colDEVRE_FAIZI_DOVIZ_ID";
            this.colDEVRE_FAIZI_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colDEVRE_FAIZI_DOVIZ_ID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DEVRE_FAIZI_DOVIZ_ID", "{0}")});
            this.colDEVRE_FAIZI_DOVIZ_ID.ToolTip = "DEVRE FAIZI Birim";
            this.colDEVRE_FAIZI_DOVIZ_ID.Width = 30;
            // 
            // colBSMV_3
            // 
            this.colBSMV_3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.colBSMV_3.AppearanceCell.Options.UseFont = true;
            this.colBSMV_3.Caption = "Bsmv";
            this.colBSMV_3.ColumnEdit = this.rSpinTutar;
            this.colBSMV_3.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colBSMV_3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBSMV_3.Name = "colBSMV_3";
            this.colBSMV_3.OptionsColumn.ReadOnly = true;
            this.colBSMV_3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colBSMV_3.Visible = true;
            this.colBSMV_3.Width = 65;
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTUTAR,
            this.colTUTAR_DOVIZ_ID,
            this.colODEME_KARSILIK_TUTAR,
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID,
            this.colODEME_ID,
            this.colODEME_TARIHI,
            this.colMAHSUP_ALT_KATEGORI_ID,
            this.colMAHSUP_KATEGORI_ID,
            this.colALACAK_NEDEN_ID,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.colDAGILIM_TIPI});
            this.gridView3.GridControl = this.gcOdemePlani;
            this.gridView3.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ODEME_KARSILIK_TUTAR", this.colODEME_KARSILIK_TUTAR, "GecmisGunFaizi"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TUTAR", this.colTUTAR, "GecmisGunFaizi")});
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView3.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView3.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView3.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView3.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView3.OptionsView.ShowAutoFilterRow = true;
            this.gridView3.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView3.ViewCaption = "Ödeme Dağılım";
            // 
            // colTUTAR
            // 
            this.colTUTAR.Caption = "Tutar";
            this.colTUTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colTUTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTUTAR.FieldName = "TUTAR";
            this.colTUTAR.Name = "colTUTAR";
            this.colTUTAR.Visible = true;
            this.colTUTAR.VisibleIndex = 0;
            // 
            // colTUTAR_DOVIZ_ID
            // 
            this.colTUTAR_DOVIZ_ID.Caption = "BRM";
            this.colTUTAR_DOVIZ_ID.ColumnEdit = this.rLueDovizId;
            this.colTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            this.colTUTAR_DOVIZ_ID.Name = "colTUTAR_DOVIZ_ID";
            this.colTUTAR_DOVIZ_ID.Visible = true;
            this.colTUTAR_DOVIZ_ID.VisibleIndex = 1;
            // 
            // colODEME_KARSILIK_TUTAR
            // 
            this.colODEME_KARSILIK_TUTAR.Caption = "Karşılık Tutar";
            this.colODEME_KARSILIK_TUTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colODEME_KARSILIK_TUTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colODEME_KARSILIK_TUTAR.FieldName = "ODEME_KARSILIK_TUTAR";
            this.colODEME_KARSILIK_TUTAR.Name = "colODEME_KARSILIK_TUTAR";
            this.colODEME_KARSILIK_TUTAR.Visible = true;
            this.colODEME_KARSILIK_TUTAR.VisibleIndex = 2;
            // 
            // colODEME_KARSILIK_TUTAR_DOVIZ_ID
            // 
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID.Caption = "BRM";
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID.ColumnEdit = this.rLueDovizId;
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID.FieldName = "ODEME_KARSILIK_TUTAR_DOVIZ_ID";
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID.Name = "colODEME_KARSILIK_TUTAR_DOVIZ_ID";
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID.Visible = true;
            this.colODEME_KARSILIK_TUTAR_DOVIZ_ID.VisibleIndex = 3;
            // 
            // colODEME_ID
            // 
            this.colODEME_ID.Caption = "Ödeme";
            this.colODEME_ID.FieldName = "ODEME_ID";
            this.colODEME_ID.Name = "colODEME_ID";
            this.colODEME_ID.Visible = true;
            this.colODEME_ID.VisibleIndex = 4;
            // 
            // colODEME_TARIHI
            // 
            this.colODEME_TARIHI.Caption = "Ö.Tarihi";
            this.colODEME_TARIHI.FieldName = "ODEME_TARIHI";
            this.colODEME_TARIHI.Name = "colODEME_TARIHI";
            this.colODEME_TARIHI.Visible = true;
            this.colODEME_TARIHI.VisibleIndex = 5;
            // 
            // colMAHSUP_ALT_KATEGORI_ID
            // 
            this.colMAHSUP_ALT_KATEGORI_ID.Caption = "Mahsup Alt Kategori";
            this.colMAHSUP_ALT_KATEGORI_ID.FieldName = "MAHSUP_ALT_KATEGORI_ID";
            this.colMAHSUP_ALT_KATEGORI_ID.Name = "colMAHSUP_ALT_KATEGORI_ID";
            this.colMAHSUP_ALT_KATEGORI_ID.Visible = true;
            this.colMAHSUP_ALT_KATEGORI_ID.VisibleIndex = 6;
            // 
            // colMAHSUP_KATEGORI_ID
            // 
            this.colMAHSUP_KATEGORI_ID.Caption = "Mahsup Kategori";
            this.colMAHSUP_KATEGORI_ID.FieldName = "MAHSUP_KATEGORI_ID";
            this.colMAHSUP_KATEGORI_ID.Name = "colMAHSUP_KATEGORI_ID";
            this.colMAHSUP_KATEGORI_ID.Visible = true;
            this.colMAHSUP_KATEGORI_ID.VisibleIndex = 7;
            // 
            // colALACAK_NEDEN_ID
            // 
            this.colALACAK_NEDEN_ID.Caption = "Alacak Neden";
            this.colALACAK_NEDEN_ID.FieldName = "ALACAK_NEDEN_ID";
            this.colALACAK_NEDEN_ID.Name = "colALACAK_NEDEN_ID";
            this.colALACAK_NEDEN_ID.Visible = true;
            this.colALACAK_NEDEN_ID.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Alacak Neden Taraf";
            this.gridColumn10.FieldName = "ALACAK_NEDEN_TARAF_ID";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Föy Taraf";
            this.gridColumn11.FieldName = "FOY_TARAF_ID";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "İlam Tipi";
            this.gridColumn12.FieldName = "ILAM_ID";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 11;
            // 
            // colDAGILIM_TIPI
            // 
            this.colDAGILIM_TIPI.Caption = "Dağılım Tipi";
            this.colDAGILIM_TIPI.FieldName = "DAGILIM_TIPI";
            this.colDAGILIM_TIPI.Name = "colDAGILIM_TIPI";
            this.colDAGILIM_TIPI.Visible = true;
            this.colDAGILIM_TIPI.VisibleIndex = 12;
            // 
            // multiEditorRowProperties1
            // 
            this.multiEditorRowProperties1.Caption = "Müdürlük";
            this.multiEditorRowProperties1.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.multiEditorRowProperties1.RowEdit = this.rlueMudurluk;
            // 
            // rlueMudurluk
            // 
            this.rlueMudurluk.AutoHeight = false;
            this.rlueMudurluk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueMudurluk.Name = "rlueMudurluk";
            // 
            // multiEditorRowProperties2
            // 
            this.multiEditorRowProperties2.Caption = "No";
            this.multiEditorRowProperties2.FieldName = "ADLI_BIRIM_NO_ID";
            this.multiEditorRowProperties2.RowEdit = this.rlueMudurlukNo;
            // 
            // rlueMudurlukNo
            // 
            this.rlueMudurlukNo.AutoHeight = false;
            this.rlueMudurlukNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueMudurlukNo.Name = "rlueMudurlukNo";
            // 
            // gLueDosyaNo
            // 
            this.gLueDosyaNo.AutoHeight = false;
            this.gLueDosyaNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gLueDosyaNo.DisplayMember = "FOY_NO";
            this.gLueDosyaNo.Name = "gLueDosyaNo";
            this.gLueDosyaNo.ValueMember = "FOY_NO";
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel2});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dockPanel2.FloatVertical = true;
            this.dockPanel2.ID = new System.Guid("fae26abb-7467-446d-b867-bd71d5a9731c");
            this.dockPanel2.Location = new System.Drawing.Point(200, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(0, 0);
            this.dockPanel2.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dockPanel2.SavedIndex = 1;
            this.dockPanel2.Size = new System.Drawing.Size(711, 218);
            this.dockPanel2.Text = "Hesap Parametreleri";
            this.dockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(705, 190);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // panelParametreler
            // 
            this.panelParametreler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelParametreler.Controls.Add(this.btnHesapSira);
            this.panelParametreler.Controls.Add(this.cbVekaletOtomatikHesapla);
            this.panelParametreler.Controls.Add(this.popupContainerEdit1);
            this.panelParametreler.Controls.Add(this.gcSimulasyonGruplari);
            this.panelParametreler.Controls.Add(this.linkLabel1);
            this.panelParametreler.Controls.Add(this.prToplamMasraf);
            this.panelParametreler.Controls.Add(this.prVekaletUcreti);
            this.panelParametreler.Controls.Add(this.prBakiyeHarc);
            this.panelParametreler.Controls.Add(this.prToplam);
            this.panelParametreler.Controls.Add(this.cbBakiyeHarcHesabaDahil);
            this.panelParametreler.Controls.Add(this.labelControl16);
            this.panelParametreler.Controls.Add(this.lueHesapTipi);
            this.panelParametreler.Controls.Add(this.labelControl15);
            this.panelParametreler.Controls.Add(this.labelControl17);
            this.panelParametreler.Controls.Add(this.labelControl4);
            this.panelParametreler.Controls.Add(this.labelControl14);
            this.panelParametreler.Controls.Add(this.lueBirYilKacGun);
            this.panelParametreler.Controls.Add(this.labelControl2);
            this.panelParametreler.Controls.Add(this.labelControl1);
            this.panelParametreler.Controls.Add(this.dateSonHesapTarihi);
            this.panelParametreler.Location = new System.Drawing.Point(63, 12);
            this.panelParametreler.Name = "panelParametreler";
            this.panelParametreler.Size = new System.Drawing.Size(805, 281);
            this.panelParametreler.TabIndex = 7;
            // 
            // btnHesapSira
            // 
            this.btnHesapSira.Location = new System.Drawing.Point(133, 85);
            this.btnHesapSira.Name = "btnHesapSira";
            this.btnHesapSira.Size = new System.Drawing.Size(75, 23);
            this.btnHesapSira.TabIndex = 26;
            this.btnHesapSira.Text = "Hesap Sırası";
            this.btnHesapSira.Click += new System.EventHandler(this.btnHesapSira_Click);
            // 
            // cbVekaletOtomatikHesapla
            // 
            this.cbVekaletOtomatikHesapla.Location = new System.Drawing.Point(665, 35);
            this.cbVekaletOtomatikHesapla.Name = "cbVekaletOtomatikHesapla";
            this.cbVekaletOtomatikHesapla.Properties.Caption = "Sabit Vekalet Ücreti";
            this.cbVekaletOtomatikHesapla.Size = new System.Drawing.Size(124, 19);
            this.cbVekaletOtomatikHesapla.TabIndex = 25;
            this.cbVekaletOtomatikHesapla.Visible = false;
            this.cbVekaletOtomatikHesapla.CheckedChanged += new System.EventHandler(this.cbVekaletOtomatikHesapla_CheckedChanged);
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.EditValue = "ALACAK DETAYLARI - HESAP ÖNCESİ FAİZ Oranlarının Düzenlenmesi ";
            this.popupContainerEdit1.Location = new System.Drawing.Point(11, 115);
            this.popupContainerEdit1.MenuManager = this.ribbonControl1;
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.popupContainerEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.popupContainerEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.popupContainerEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.popupContainerEdit1.Properties.Appearance.Options.UseFont = true;
            this.popupContainerEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Size = new System.Drawing.Size(428, 20);
            this.popupContainerEdit1.TabIndex = 24;
            this.popupContainerEdit1.Visible = false;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonText = null;
            this.ribbonControl1.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbonControl1.ApplicationIcon")));
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItem2,
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(911, 142);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Yazdır";
            this.barButtonItem2.Enabled = false;
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Kaydet";
            this.barButtonItem1.Enabled = false;
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Seçenekler";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.gcAlacakNedenleri);
            this.popupContainerControl1.Controls.Add(this.textEdit2);
            this.popupContainerControl1.Controls.Add(this.textEdit1);
            this.popupContainerControl1.Controls.Add(this.lBtnFaizOraniUygula);
            this.popupContainerControl1.Controls.Add(this.linkLabel8);
            this.popupContainerControl1.Controls.Add(this.linkLabel5);
            this.popupContainerControl1.Controls.Add(this.bEditTOFaizOrani);
            this.popupContainerControl1.Controls.Add(this.cEditTumAlacaklariSec);
            this.popupContainerControl1.Controls.Add(this.labelControl59);
            this.popupContainerControl1.Controls.Add(this.labelControl48);
            this.popupContainerControl1.Controls.Add(this.labelControl3);
            this.popupContainerControl1.Controls.Add(this.checkEdit10);
            this.popupContainerControl1.Controls.Add(this.lookUpEdit6);
            this.popupContainerControl1.Controls.Add(this.checkEdit5);
            this.popupContainerControl1.Controls.Add(this.labelControl58);
            this.popupContainerControl1.Controls.Add(this.lookUpEdit1);
            this.popupContainerControl1.Controls.Add(this.simpleButton5);
            this.popupContainerControl1.Controls.Add(this.labelControl38);
            this.popupContainerControl1.Controls.Add(this.labelControl57);
            this.popupContainerControl1.Controls.Add(this.simpleButton4);
            this.popupContainerControl1.Controls.Add(this.panelControl6);
            this.popupContainerControl1.Controls.Add(this.labelControl40);
            this.popupContainerControl1.Controls.Add(this.dateEdit3);
            this.popupContainerControl1.Controls.Add(this.panelControl5);
            this.popupContainerControl1.Controls.Add(this.checkEdit6);
            this.popupContainerControl1.Controls.Add(this.dateEdit2);
            this.popupContainerControl1.Controls.Add(this.checkEdit4);
            this.popupContainerControl1.Location = new System.Drawing.Point(896, 49);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(706, 218);
            this.popupContainerControl1.TabIndex = 25;
            // 
            // gcAlacakNedenleri
            // 
            this.gcAlacakNedenleri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcAlacakNedenleri.DataSource = this.bndAlacakNeden;
            this.gcAlacakNedenleri.Location = new System.Drawing.Point(0, 31);
            this.gcAlacakNedenleri.MainView = this.gridView4;
            this.gcAlacakNedenleri.MenuManager = this.ribbonControl1;
            this.gcAlacakNedenleri.Name = "gcAlacakNedenleri";
            this.gcAlacakNedenleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rSpinOran,
            this.rLueDoviz,
            this.rSpinPara,
            this.rLueAlacakNeden});
            this.gcAlacakNedenleri.Size = new System.Drawing.Size(706, 185);
            this.gcAlacakNedenleri.TabIndex = 32;
            this.gcAlacakNedenleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // bndAlacakNeden
            // 
            this.bndAlacakNeden.DataSource = typeof(AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN);
            this.bndAlacakNeden.CurrentItemChanged += new System.EventHandler(this.bndAlacakNeden_CurrentItemChanged);
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25});
            this.gridView4.GridControl = this.gcAlacakNedenleri;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsView.ColumnAutoWidth = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Seç";
            this.gridColumn19.FieldName = "IsSelected";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Width = 32;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Alacak Nedeni";
            this.gridColumn20.ColumnEdit = this.rLueAlacakNeden;
            this.gridColumn20.FieldName = "ALACAK_NEDEN_KOD_ID";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.ReadOnly = true;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 0;
            this.gridColumn20.Width = 261;
            // 
            // rLueAlacakNeden
            // 
            this.rLueAlacakNeden.AutoHeight = false;
            this.rLueAlacakNeden.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAlacakNeden.Name = "rLueAlacakNeden";
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Tutar";
            this.gridColumn21.ColumnEdit = this.rSpinPara;
            this.gridColumn21.FieldName = "TUTARI";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.ReadOnly = true;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 1;
            this.gridColumn21.Width = 126;
            // 
            // rSpinPara
            // 
            this.rSpinPara.AutoHeight = false;
            this.rSpinPara.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rSpinPara.Name = "rSpinPara";
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Brm.";
            this.gridColumn22.ColumnEdit = this.rLueDoviz;
            this.gridColumn22.FieldName = "TUTAR_DOVIZ_ID";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.ReadOnly = true;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 2;
            this.gridColumn22.Width = 39;
            // 
            // rLueDoviz
            // 
            this.rLueDoviz.AutoHeight = false;
            this.rLueDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDoviz.Name = "rLueDoviz";
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "T.O. Faiz %";
            this.gridColumn23.ColumnEdit = this.rSpinOran;
            this.gridColumn23.FieldName = "TO_UYGULANACAK_FAIZ_ORANI";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 3;
            this.gridColumn23.Width = 72;
            // 
            // rSpinOran
            // 
            this.rSpinOran.AutoHeight = false;
            this.rSpinOran.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rSpinOran.Name = "rSpinOran";
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "T.S. Faiz %";
            this.gridColumn24.ColumnEdit = this.rSpinOran;
            this.gridColumn24.FieldName = "UYGULANACAK_FAIZ_ORANI";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Width = 76;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Vade Tarihi";
            this.gridColumn25.FieldName = "VADE_TARIHI";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 4;
            this.gridColumn25.Width = 92;
            // 
            // textEdit2
            // 
            this.textEdit2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textEdit2.Location = new System.Drawing.Point(-445, 343);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit2.Size = new System.Drawing.Size(56, 20);
            this.textEdit2.TabIndex = 31;
            // 
            // textEdit1
            // 
            this.textEdit1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textEdit1.Location = new System.Drawing.Point(-445, 343);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit1.Size = new System.Drawing.Size(56, 20);
            this.textEdit1.TabIndex = 31;
            // 
            // lBtnFaizOraniUygula
            // 
            this.lBtnFaizOraniUygula.AutoSize = true;
            this.lBtnFaizOraniUygula.ForeColor = System.Drawing.Color.Blue;
            this.lBtnFaizOraniUygula.Location = new System.Drawing.Point(552, 8);
            this.lBtnFaizOraniUygula.Name = "lBtnFaizOraniUygula";
            this.lBtnFaizOraniUygula.Size = new System.Drawing.Size(102, 13);
            this.lBtnFaizOraniUygula.TabIndex = 7;
            this.lBtnFaizOraniUygula.TabStop = true;
            this.lBtnFaizOraniUygula.Text = " Faiz Oranını Uygula";
            this.lBtnFaizOraniUygula.Visible = false;
            this.lBtnFaizOraniUygula.Click += new System.EventHandler(this.lBtnFaizOraniUygula_Click);
            // 
            // linkLabel8
            // 
            this.linkLabel8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabel8.AutoSize = true;
            this.linkLabel8.ForeColor = System.Drawing.Color.Blue;
            this.linkLabel8.Location = new System.Drawing.Point(-377, 346);
            this.linkLabel8.Name = "linkLabel8";
            this.linkLabel8.Size = new System.Drawing.Size(102, 13);
            this.linkLabel8.TabIndex = 30;
            this.linkLabel8.TabStop = true;
            this.linkLabel8.Text = " Faiz Oranını Uygula";
            this.linkLabel8.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.ForeColor = System.Drawing.Color.Blue;
            this.linkLabel5.Location = new System.Drawing.Point(-377, 346);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(102, 13);
            this.linkLabel5.TabIndex = 30;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = " Faiz Oranını Uygula";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // bEditTOFaizOrani
            // 
            this.bEditTOFaizOrani.Location = new System.Drawing.Point(484, 5);
            this.bEditTOFaizOrani.MenuManager = this.ribbonControl1;
            this.bEditTOFaizOrani.Name = "bEditTOFaizOrani";
            this.bEditTOFaizOrani.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.bEditTOFaizOrani.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.bEditTOFaizOrani.Properties.Appearance.Options.UseBackColor = true;
            this.bEditTOFaizOrani.Properties.Appearance.Options.UseForeColor = true;
            this.bEditTOFaizOrani.Properties.Appearance.Options.UseTextOptions = true;
            this.bEditTOFaizOrani.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bEditTOFaizOrani.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bEditTOFaizOrani.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.bEditTOFaizOrani.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "Faiz Oranlarını Sabitle", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "GecmisGunFaizi", null, null, false)});
            this.bEditTOFaizOrani.Properties.DisplayFormat.FormatString = "%999";
            this.bEditTOFaizOrani.Properties.Mask.EditMask = "P2";
            this.bEditTOFaizOrani.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.bEditTOFaizOrani.Size = new System.Drawing.Size(56, 18);
            this.bEditTOFaizOrani.TabIndex = 2;
            this.bEditTOFaizOrani.Visible = false;
            this.bEditTOFaizOrani.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bEditTOFaizOrani_ButtonClick);
            // 
            // cEditTumAlacaklariSec
            // 
            this.cEditTumAlacaklariSec.Location = new System.Drawing.Point(33, 5);
            this.cEditTumAlacaklariSec.MenuManager = this.ribbonControl1;
            this.cEditTumAlacaklariSec.Name = "cEditTumAlacaklariSec";
            this.cEditTumAlacaklariSec.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.cEditTumAlacaklariSec.Properties.Appearance.Options.UseForeColor = true;
            this.cEditTumAlacaklariSec.Properties.Caption = "Tüm Alacakları Seç";
            this.cEditTumAlacaklariSec.Size = new System.Drawing.Size(191, 19);
            this.cEditTumAlacaklariSec.TabIndex = 1;
            this.cEditTumAlacaklariSec.Visible = false;
            this.cEditTumAlacaklariSec.CheckedChanged += new System.EventHandler(this.cEditTumAlacaklariSec_CheckedChanged);
            // 
            // labelControl59
            // 
            this.labelControl59.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl59.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl59.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl59.LineColor = System.Drawing.Color.Transparent;
            this.labelControl59.Location = new System.Drawing.Point(-506, 346);
            this.labelControl59.Name = "labelControl59";
            this.labelControl59.Size = new System.Drawing.Size(55, 13);
            this.labelControl59.TabIndex = 29;
            this.labelControl59.Text = "Alacaklara  ";
            // 
            // labelControl48
            // 
            this.labelControl48.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl48.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl48.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl48.LineColor = System.Drawing.Color.Transparent;
            this.labelControl48.Location = new System.Drawing.Point(-506, 346);
            this.labelControl48.Name = "labelControl48";
            this.labelControl48.Size = new System.Drawing.Size(55, 13);
            this.labelControl48.TabIndex = 29;
            this.labelControl48.Text = "Alacaklara  ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl3.LineColor = System.Drawing.Color.Transparent;
            this.labelControl3.Location = new System.Drawing.Point(423, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Alacaklara  ";
            this.labelControl3.Visible = false;
            // 
            // checkEdit10
            // 
            this.checkEdit10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkEdit10.Location = new System.Drawing.Point(-508, 292);
            this.checkEdit10.Name = "checkEdit10";
            this.checkEdit10.Properties.Caption = "Masraf ve faizler asıl alacağa dahil edilsin";
            this.checkEdit10.Size = new System.Drawing.Size(254, 19);
            this.checkEdit10.TabIndex = 27;
            this.checkEdit10.CheckedChanged += new System.EventHandler(this.ceToplamlarAsilAlacak_CheckedChanged);
            // 
            // lookUpEdit6
            // 
            this.lookUpEdit6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lookUpEdit6.Location = new System.Drawing.Point(-709, 313);
            this.lookUpEdit6.Name = "lookUpEdit6";
            this.lookUpEdit6.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit6.Size = new System.Drawing.Size(513, 20);
            this.lookUpEdit6.TabIndex = 6;
            // 
            // checkEdit5
            // 
            this.checkEdit5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkEdit5.Location = new System.Drawing.Point(-508, 292);
            this.checkEdit5.Name = "checkEdit5";
            this.checkEdit5.Properties.Caption = "Masraf ve faizler asıl alacağa dahil edilsin";
            this.checkEdit5.Size = new System.Drawing.Size(254, 19);
            this.checkEdit5.TabIndex = 27;
            this.checkEdit5.CheckedChanged += new System.EventHandler(this.ceToplamlarAsilAlacak_CheckedChanged);
            // 
            // labelControl58
            // 
            this.labelControl58.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl58.Location = new System.Drawing.Point(-842, 316);
            this.labelControl58.Name = "labelControl58";
            this.labelControl58.Size = new System.Drawing.Size(110, 13);
            this.labelControl58.TabIndex = 1;
            this.labelControl58.Text = "Faiz İşletim Seçenekleri";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lookUpEdit1.Location = new System.Drawing.Point(-709, 313);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(513, 20);
            this.lookUpEdit1.TabIndex = 6;
            // 
            // simpleButton5
            // 
            this.simpleButton5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.simpleButton5.Appearance.BackColor = System.Drawing.Color.Red;
            this.simpleButton5.Appearance.Options.UseBackColor = true;
            this.simpleButton5.Location = new System.Drawing.Point(-190, 310);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(142, 23);
            this.simpleButton5.TabIndex = 26;
            this.simpleButton5.Text = "Hesabı Güncelle";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton3_Click_1);
            // 
            // labelControl38
            // 
            this.labelControl38.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl38.Location = new System.Drawing.Point(-842, 316);
            this.labelControl38.Name = "labelControl38";
            this.labelControl38.Size = new System.Drawing.Size(110, 13);
            this.labelControl38.TabIndex = 1;
            this.labelControl38.Text = "Faiz İşletim Seçenekleri";
            // 
            // labelControl57
            // 
            this.labelControl57.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl57.Location = new System.Drawing.Point(-842, 294);
            this.labelControl57.Name = "labelControl57";
            this.labelControl57.Size = new System.Drawing.Size(311, 13);
            this.labelControl57.TabIndex = 4;
            this.labelControl57.Text = "Taksitler                     ayı              tarihinden itibaren oluşturulsun.";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.simpleButton4.Appearance.BackColor = System.Drawing.Color.Red;
            this.simpleButton4.Appearance.Options.UseBackColor = true;
            this.simpleButton4.Location = new System.Drawing.Point(-190, 310);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(142, 23);
            this.simpleButton4.TabIndex = 26;
            this.simpleButton4.Text = "Hesabı Güncelle";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton3_Click_1);
            // 
            // panelControl6
            // 
            this.panelControl6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelControl6.Controls.Add(this.checkEdit7);
            this.panelControl6.Controls.Add(this.popupContainerEdit3);
            this.panelControl6.Controls.Add(this.gridControl4);
            this.panelControl6.Controls.Add(this.linkLabel7);
            this.panelControl6.Controls.Add(this.ucDovizliTutarAlani5);
            this.panelControl6.Controls.Add(this.ucDovizliTutarAlani6);
            this.panelControl6.Controls.Add(this.ucDovizliTutarAlani7);
            this.panelControl6.Controls.Add(this.ucDovizliTutarAlani8);
            this.panelControl6.Controls.Add(this.checkEdit9);
            this.panelControl6.Controls.Add(this.labelControl50);
            this.panelControl6.Controls.Add(this.lookUpEdit4);
            this.panelControl6.Controls.Add(this.labelControl51);
            this.panelControl6.Controls.Add(this.labelControl52);
            this.panelControl6.Controls.Add(this.labelControl53);
            this.panelControl6.Controls.Add(this.labelControl54);
            this.panelControl6.Controls.Add(this.lookUpEdit5);
            this.panelControl6.Controls.Add(this.labelControl55);
            this.panelControl6.Controls.Add(this.labelControl56);
            this.panelControl6.Controls.Add(this.dateEdit4);
            this.panelControl6.Location = new System.Drawing.Point(-849, -9);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(805, 281);
            this.panelControl6.TabIndex = 7;
            // 
            // checkEdit7
            // 
            this.checkEdit7.Location = new System.Drawing.Point(665, 35);
            this.checkEdit7.Name = "checkEdit7";
            this.checkEdit7.Properties.Caption = "Sabit Vekalet Ücreti";
            this.checkEdit7.Size = new System.Drawing.Size(124, 19);
            this.checkEdit7.TabIndex = 25;
            this.checkEdit7.Visible = false;
            this.checkEdit7.CheckedChanged += new System.EventHandler(this.cbVekaletOtomatikHesapla_CheckedChanged);
            // 
            // popupContainerEdit3
            // 
            this.popupContainerEdit3.EditValue = "ALACAK DETAYLARI - HESAP ÖNCESİ FAİZ Oranlarının Düzenlenmesi ";
            this.popupContainerEdit3.Location = new System.Drawing.Point(11, 115);
            this.popupContainerEdit3.Name = "popupContainerEdit3";
            this.popupContainerEdit3.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.popupContainerEdit3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.popupContainerEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.popupContainerEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.popupContainerEdit3.Properties.Appearance.Options.UseFont = true;
            this.popupContainerEdit3.Properties.Appearance.Options.UseForeColor = true;
            this.popupContainerEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit3.Size = new System.Drawing.Size(428, 20);
            this.popupContainerEdit3.TabIndex = 24;
            this.popupContainerEdit3.Visible = false;
            // 
            // gridControl4
            // 
            this.gridControl4.Location = new System.Drawing.Point(11, 141);
            this.gridControl4.MainView = this.bandedGridView5;
            this.gridControl4.Name = "gridControl4";
            this.gridControl4.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit7,
            this.repositoryItemSpinEdit8});
            this.gridControl4.Size = new System.Drawing.Size(789, 135);
            this.gridControl4.TabIndex = 0;
            this.gridControl4.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView5});
            this.gridControl4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gcSimulasyonGruplari_MouseMove);
            // 
            // bandedGridView5
            // 
            this.bandedGridView5.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand8});
            this.bandedGridView5.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn26,
            this.bandedGridColumn27,
            this.bandedGridColumn28,
            this.bandedGridColumn29,
            this.bandedGridColumn30,
            this.bandedGridColumn31,
            this.bandedGridColumn32,
            this.bandedGridColumn33,
            this.bandedGridColumn34,
            this.bandedGridColumn35});
            this.bandedGridView5.GridControl = this.gridControl4;
            this.bandedGridView5.Name = "bandedGridView5";
            this.bandedGridView5.OptionsView.ShowGroupPanel = false;
            this.bandedGridView5.OptionsView.ShowIndicator = false;
            this.bandedGridView5.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvSimulasyonGruplari_CellValueChanged);
            // 
            // gridBand8
            // 
            this.gridBand8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand8.Caption = "Alacağın Detayları";
            this.gridBand8.Columns.Add(this.bandedGridColumn26);
            this.gridBand8.Columns.Add(this.bandedGridColumn27);
            this.gridBand8.Columns.Add(this.bandedGridColumn28);
            this.gridBand8.Columns.Add(this.bandedGridColumn29);
            this.gridBand8.Columns.Add(this.bandedGridColumn30);
            this.gridBand8.Columns.Add(this.bandedGridColumn31);
            this.gridBand8.Columns.Add(this.bandedGridColumn32);
            this.gridBand8.Columns.Add(this.bandedGridColumn33);
            this.gridBand8.Columns.Add(this.bandedGridColumn34);
            this.gridBand8.Columns.Add(this.bandedGridColumn35);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.Width = 695;
            // 
            // bandedGridColumn26
            // 
            this.bandedGridColumn26.Caption = "Seç";
            this.bandedGridColumn26.FieldName = "Secim";
            this.bandedGridColumn26.Name = "bandedGridColumn26";
            this.bandedGridColumn26.Visible = true;
            this.bandedGridColumn26.Width = 24;
            // 
            // bandedGridColumn27
            // 
            this.bandedGridColumn27.Caption = "Alacak Birimi";
            this.bandedGridColumn27.ColumnEdit = this.repositoryItemLookUpEdit7;
            this.bandedGridColumn27.FieldName = "ParaBirimi";
            this.bandedGridColumn27.Name = "bandedGridColumn27";
            this.bandedGridColumn27.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn27.Visible = true;
            this.bandedGridColumn27.Width = 70;
            // 
            // repositoryItemLookUpEdit7
            // 
            this.repositoryItemLookUpEdit7.AutoHeight = false;
            this.repositoryItemLookUpEdit7.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit7.Name = "repositoryItemLookUpEdit7";
            // 
            // bandedGridColumn28
            // 
            this.bandedGridColumn28.Caption = "Tutar";
            this.bandedGridColumn28.ColumnEdit = this.repositoryItemSpinEdit8;
            this.bandedGridColumn28.FieldName = "TUTAR";
            this.bandedGridColumn28.Name = "bandedGridColumn28";
            this.bandedGridColumn28.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn28.Visible = true;
            this.bandedGridColumn28.Width = 105;
            // 
            // repositoryItemSpinEdit8
            // 
            this.repositoryItemSpinEdit8.AutoHeight = false;
            this.repositoryItemSpinEdit8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit8.Name = "repositoryItemSpinEdit8";
            // 
            // bandedGridColumn29
            // 
            this.bandedGridColumn29.Caption = " ";
            this.bandedGridColumn29.ColumnEdit = this.repositoryItemLookUpEdit7;
            this.bandedGridColumn29.CustomizationCaption = "Tutar Para Birimi";
            this.bandedGridColumn29.FieldName = "TUTAR_DOVIZ_ID";
            this.bandedGridColumn29.Name = "bandedGridColumn29";
            this.bandedGridColumn29.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn29.Visible = true;
            this.bandedGridColumn29.Width = 37;
            // 
            // bandedGridColumn30
            // 
            this.bandedGridColumn30.Caption = "Faiz";
            this.bandedGridColumn30.ColumnEdit = this.repositoryItemSpinEdit8;
            this.bandedGridColumn30.FieldName = "FAIZ";
            this.bandedGridColumn30.Name = "bandedGridColumn30";
            this.bandedGridColumn30.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn30.Visible = true;
            this.bandedGridColumn30.Width = 115;
            // 
            // bandedGridColumn31
            // 
            this.bandedGridColumn31.Caption = " ";
            this.bandedGridColumn31.ColumnEdit = this.repositoryItemLookUpEdit7;
            this.bandedGridColumn31.CustomizationCaption = "Faiz Para Birimi";
            this.bandedGridColumn31.FieldName = "FAIZ_DOVIZ_ID";
            this.bandedGridColumn31.Name = "bandedGridColumn31";
            this.bandedGridColumn31.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn31.Visible = true;
            this.bandedGridColumn31.Width = 36;
            // 
            // bandedGridColumn32
            // 
            this.bandedGridColumn32.Caption = "Diğer";
            this.bandedGridColumn32.ColumnEdit = this.repositoryItemSpinEdit8;
            this.bandedGridColumn32.FieldName = "DIGER";
            this.bandedGridColumn32.Name = "bandedGridColumn32";
            this.bandedGridColumn32.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn32.Visible = true;
            this.bandedGridColumn32.Width = 113;
            // 
            // bandedGridColumn33
            // 
            this.bandedGridColumn33.Caption = " ";
            this.bandedGridColumn33.ColumnEdit = this.repositoryItemLookUpEdit7;
            this.bandedGridColumn33.CustomizationCaption = "Diğer Gider Para Birimi";
            this.bandedGridColumn33.FieldName = "DIGER_DOVIZ_ID";
            this.bandedGridColumn33.Name = "bandedGridColumn33";
            this.bandedGridColumn33.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn33.Visible = true;
            this.bandedGridColumn33.Width = 37;
            // 
            // bandedGridColumn34
            // 
            this.bandedGridColumn34.Caption = "Toplam";
            this.bandedGridColumn34.ColumnEdit = this.repositoryItemSpinEdit8;
            this.bandedGridColumn34.FieldName = "TOPLAM";
            this.bandedGridColumn34.Name = "bandedGridColumn34";
            this.bandedGridColumn34.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn34.Visible = true;
            this.bandedGridColumn34.Width = 121;
            // 
            // bandedGridColumn35
            // 
            this.bandedGridColumn35.Caption = " ";
            this.bandedGridColumn35.ColumnEdit = this.repositoryItemLookUpEdit7;
            this.bandedGridColumn35.CustomizationCaption = "Toplam Para Birimi ";
            this.bandedGridColumn35.FieldName = "TOPLAM_DOVIZ_ID";
            this.bandedGridColumn35.Name = "bandedGridColumn35";
            this.bandedGridColumn35.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn35.Visible = true;
            this.bandedGridColumn35.Width = 37;
            // 
            // linkLabel7
            // 
            this.linkLabel7.AutoSize = true;
            this.linkLabel7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.linkLabel7.Location = new System.Drawing.Point(664, 89);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(54, 13);
            this.linkLabel7.TabIndex = 23;
            this.linkLabel7.TabStop = true;
            this.linkLabel7.Text = "Gelişmiş";
            this.linkLabel7.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ucDovizliTutarAlani5
            // 
            this.ucDovizliTutarAlani5.Location = new System.Drawing.Point(455, 6);
            this.ucDovizliTutarAlani5.MaximumSize = new System.Drawing.Size(0, 20);
            this.ucDovizliTutarAlani5.MinimumSize = new System.Drawing.Size(160, 20);
            this.ucDovizliTutarAlani5.Name = "ucDovizliTutarAlani5";
            this.ucDovizliTutarAlani5.ReadOnlyDoviz = true;
            this.ucDovizliTutarAlani5.ReadOnlyTutar = true;
            this.ucDovizliTutarAlani5.Size = new System.Drawing.Size(204, 20);
            this.ucDovizliTutarAlani5.TabIndex = 22;
            paraVeDovizId1.DovizId = 1;
            paraVeDovizId1.KurCevrimTarihi = null;
            paraVeDovizId1.Para = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucDovizliTutarAlani5.Tutar = paraVeDovizId1;
            // 
            // ucDovizliTutarAlani6
            // 
            this.ucDovizliTutarAlani6.Location = new System.Drawing.Point(455, 34);
            this.ucDovizliTutarAlani6.MaximumSize = new System.Drawing.Size(0, 20);
            this.ucDovizliTutarAlani6.MinimumSize = new System.Drawing.Size(160, 20);
            this.ucDovizliTutarAlani6.Name = "ucDovizliTutarAlani6";
            this.ucDovizliTutarAlani6.ReadOnlyDoviz = true;
            this.ucDovizliTutarAlani6.Size = new System.Drawing.Size(204, 20);
            this.ucDovizliTutarAlani6.TabIndex = 22;
            paraVeDovizId2.DovizId = 1;
            paraVeDovizId2.KurCevrimTarihi = null;
            paraVeDovizId2.Para = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucDovizliTutarAlani6.Tutar = paraVeDovizId2;
            this.ucDovizliTutarAlani6.TutarDegisti += new System.EventHandler<System.EventArgs>(this.prVekaletUcreti_TutarDegisti);
            // 
            // ucDovizliTutarAlani7
            // 
            this.ucDovizliTutarAlani7.Location = new System.Drawing.Point(455, 60);
            this.ucDovizliTutarAlani7.MaximumSize = new System.Drawing.Size(0, 20);
            this.ucDovizliTutarAlani7.MinimumSize = new System.Drawing.Size(160, 20);
            this.ucDovizliTutarAlani7.Name = "ucDovizliTutarAlani7";
            this.ucDovizliTutarAlani7.ReadOnlyDoviz = true;
            this.ucDovizliTutarAlani7.ReadOnlyTutar = true;
            this.ucDovizliTutarAlani7.Size = new System.Drawing.Size(204, 20);
            this.ucDovizliTutarAlani7.TabIndex = 22;
            paraVeDovizId3.DovizId = 1;
            paraVeDovizId3.KurCevrimTarihi = null;
            paraVeDovizId3.Para = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucDovizliTutarAlani7.Tutar = paraVeDovizId3;
            // 
            // ucDovizliTutarAlani8
            // 
            this.ucDovizliTutarAlani8.Location = new System.Drawing.Point(455, 86);
            this.ucDovizliTutarAlani8.MaximumSize = new System.Drawing.Size(0, 20);
            this.ucDovizliTutarAlani8.MinimumSize = new System.Drawing.Size(160, 20);
            this.ucDovizliTutarAlani8.Name = "ucDovizliTutarAlani8";
            this.ucDovizliTutarAlani8.ReadOnlyDoviz = true;
            this.ucDovizliTutarAlani8.ReadOnlyTutar = true;
            this.ucDovizliTutarAlani8.Size = new System.Drawing.Size(204, 20);
            this.ucDovizliTutarAlani8.TabIndex = 22;
            paraVeDovizId4.DovizId = 1;
            paraVeDovizId4.KurCevrimTarihi = null;
            paraVeDovizId4.Para = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucDovizliTutarAlani8.Tutar = paraVeDovizId4;
            // 
            // checkEdit9
            // 
            this.checkEdit9.Location = new System.Drawing.Point(665, 60);
            this.checkEdit9.Name = "checkEdit9";
            this.checkEdit9.Properties.Caption = "Dahil";
            this.checkEdit9.Size = new System.Drawing.Size(51, 19);
            this.checkEdit9.TabIndex = 3;
            // 
            // labelControl50
            // 
            this.labelControl50.Location = new System.Drawing.Point(373, 35);
            this.labelControl50.Name = "labelControl50";
            this.labelControl50.Size = new System.Drawing.Size(66, 13);
            this.labelControl50.TabIndex = 1;
            this.labelControl50.Text = "Vekalet Ücreti";
            // 
            // lookUpEdit4
            // 
            this.lookUpEdit4.Location = new System.Drawing.Point(133, 60);
            this.lookUpEdit4.Name = "lookUpEdit4";
            this.lookUpEdit4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit4.Size = new System.Drawing.Size(192, 20);
            this.lookUpEdit4.TabIndex = 2;
            // 
            // labelControl51
            // 
            this.labelControl51.Location = new System.Drawing.Point(373, 9);
            this.labelControl51.Name = "labelControl51";
            this.labelControl51.Size = new System.Drawing.Size(71, 13);
            this.labelControl51.TabIndex = 1;
            this.labelControl51.Text = "Toplam Masraf";
            // 
            // labelControl52
            // 
            this.labelControl52.Location = new System.Drawing.Point(373, 89);
            this.labelControl52.Name = "labelControl52";
            this.labelControl52.Size = new System.Drawing.Size(34, 13);
            this.labelControl52.TabIndex = 1;
            this.labelControl52.Text = "Toplam";
            // 
            // labelControl53
            // 
            this.labelControl53.Location = new System.Drawing.Point(11, 61);
            this.labelControl53.Name = "labelControl53";
            this.labelControl53.Size = new System.Drawing.Size(49, 13);
            this.labelControl53.TabIndex = 1;
            this.labelControl53.Text = "Hesap Tipi";
            // 
            // labelControl54
            // 
            this.labelControl54.Location = new System.Drawing.Point(373, 62);
            this.labelControl54.Name = "labelControl54";
            this.labelControl54.Size = new System.Drawing.Size(56, 13);
            this.labelControl54.TabIndex = 1;
            this.labelControl54.Text = "Bakiye Harç";
            // 
            // lookUpEdit5
            // 
            this.lookUpEdit5.Location = new System.Drawing.Point(133, 32);
            this.lookUpEdit5.Name = "lookUpEdit5";
            this.lookUpEdit5.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit5.Size = new System.Drawing.Size(192, 20);
            this.lookUpEdit5.TabIndex = 2;
            // 
            // labelControl55
            // 
            this.labelControl55.Location = new System.Drawing.Point(11, 35);
            this.labelControl55.Name = "labelControl55";
            this.labelControl55.Size = new System.Drawing.Size(67, 13);
            this.labelControl55.TabIndex = 1;
            this.labelControl55.Text = "Bir Yıl Kaç Gün";
            // 
            // labelControl56
            // 
            this.labelControl56.Location = new System.Drawing.Point(11, 8);
            this.labelControl56.Name = "labelControl56";
            this.labelControl56.Size = new System.Drawing.Size(59, 13);
            this.labelControl56.TabIndex = 1;
            this.labelControl56.Text = "Hesap Tarihi";
            // 
            // dateEdit4
            // 
            this.dateEdit4.EditValue = null;
            this.dateEdit4.Location = new System.Drawing.Point(133, 6);
            this.dateEdit4.Name = "dateEdit4";
            this.dateEdit4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit4.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit4.Size = new System.Drawing.Size(192, 20);
            this.dateEdit4.TabIndex = 0;
            // 
            // labelControl40
            // 
            this.labelControl40.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl40.Location = new System.Drawing.Point(-842, 294);
            this.labelControl40.Name = "labelControl40";
            this.labelControl40.Size = new System.Drawing.Size(311, 13);
            this.labelControl40.TabIndex = 4;
            this.labelControl40.Text = "Taksitler                     ayı              tarihinden itibaren oluşturulsun.";
            // 
            // dateEdit3
            // 
            this.dateEdit3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateEdit3.EditValue = null;
            this.dateEdit3.Location = new System.Drawing.Point(-794, 291);
            this.dateEdit3.Name = "dateEdit3";
            this.dateEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit3.Properties.MinValue = new System.DateTime(2010, 6, 2, 0, 0, 0, 0);
            this.dateEdit3.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit3.Size = new System.Drawing.Size(105, 20);
            this.dateEdit3.TabIndex = 5;
            this.dateEdit3.EditValueChanged += new System.EventHandler(this.dateTaksitlerBaslasin_EditValueChanged);
            // 
            // panelControl5
            // 
            this.panelControl5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelControl5.Controls.Add(this.checkEdit2);
            this.panelControl5.Controls.Add(this.popupContainerEdit2);
            this.panelControl5.Controls.Add(this.gridControl2);
            this.panelControl5.Controls.Add(this.linkLabel4);
            this.panelControl5.Controls.Add(this.ucDovizliTutarAlani1);
            this.panelControl5.Controls.Add(this.ucDovizliTutarAlani2);
            this.panelControl5.Controls.Add(this.ucDovizliTutarAlani3);
            this.panelControl5.Controls.Add(this.ucDovizliTutarAlani4);
            this.panelControl5.Controls.Add(this.checkEdit3);
            this.panelControl5.Controls.Add(this.labelControl41);
            this.panelControl5.Controls.Add(this.lookUpEdit2);
            this.panelControl5.Controls.Add(this.labelControl42);
            this.panelControl5.Controls.Add(this.labelControl43);
            this.panelControl5.Controls.Add(this.labelControl44);
            this.panelControl5.Controls.Add(this.labelControl45);
            this.panelControl5.Controls.Add(this.lookUpEdit3);
            this.panelControl5.Controls.Add(this.labelControl46);
            this.panelControl5.Controls.Add(this.labelControl47);
            this.panelControl5.Controls.Add(this.dateEdit1);
            this.panelControl5.Location = new System.Drawing.Point(-849, -9);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(805, 281);
            this.panelControl5.TabIndex = 7;
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(665, 35);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "Sabit Vekalet Ücreti";
            this.checkEdit2.Size = new System.Drawing.Size(124, 19);
            this.checkEdit2.TabIndex = 25;
            this.checkEdit2.Visible = false;
            this.checkEdit2.CheckedChanged += new System.EventHandler(this.cbVekaletOtomatikHesapla_CheckedChanged);
            // 
            // popupContainerEdit2
            // 
            this.popupContainerEdit2.EditValue = "ALACAK DETAYLARI - HESAP ÖNCESİ FAİZ Oranlarının Düzenlenmesi ";
            this.popupContainerEdit2.Location = new System.Drawing.Point(11, 115);
            this.popupContainerEdit2.Name = "popupContainerEdit2";
            this.popupContainerEdit2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.popupContainerEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.popupContainerEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.popupContainerEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.popupContainerEdit2.Properties.Appearance.Options.UseFont = true;
            this.popupContainerEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.popupContainerEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit2.Size = new System.Drawing.Size(428, 20);
            this.popupContainerEdit2.TabIndex = 24;
            this.popupContainerEdit2.Visible = false;
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(11, 141);
            this.gridControl2.MainView = this.bandedGridView3;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit4,
            this.repositoryItemSpinEdit5});
            this.gridControl2.Size = new System.Drawing.Size(789, 135);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView3});
            this.gridControl2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gcSimulasyonGruplari_MouseMove);
            // 
            // bandedGridView3
            // 
            this.bandedGridView3.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand6});
            this.bandedGridView3.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn9,
            this.bandedGridColumn10,
            this.bandedGridColumn11,
            this.bandedGridColumn12,
            this.bandedGridColumn13,
            this.bandedGridColumn14,
            this.bandedGridColumn15,
            this.bandedGridColumn16,
            this.bandedGridColumn17,
            this.bandedGridColumn18});
            this.bandedGridView3.GridControl = this.gridControl2;
            this.bandedGridView3.Name = "bandedGridView3";
            this.bandedGridView3.OptionsView.ShowGroupPanel = false;
            this.bandedGridView3.OptionsView.ShowIndicator = false;
            this.bandedGridView3.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvSimulasyonGruplari_CellValueChanged);
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "Alacağın Detayları";
            this.gridBand6.Columns.Add(this.bandedGridColumn9);
            this.gridBand6.Columns.Add(this.bandedGridColumn10);
            this.gridBand6.Columns.Add(this.bandedGridColumn11);
            this.gridBand6.Columns.Add(this.bandedGridColumn12);
            this.gridBand6.Columns.Add(this.bandedGridColumn13);
            this.gridBand6.Columns.Add(this.bandedGridColumn14);
            this.gridBand6.Columns.Add(this.bandedGridColumn15);
            this.gridBand6.Columns.Add(this.bandedGridColumn16);
            this.gridBand6.Columns.Add(this.bandedGridColumn17);
            this.gridBand6.Columns.Add(this.bandedGridColumn18);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.Width = 695;
            // 
            // bandedGridColumn9
            // 
            this.bandedGridColumn9.Caption = "Seç";
            this.bandedGridColumn9.FieldName = "Secim";
            this.bandedGridColumn9.Name = "bandedGridColumn9";
            this.bandedGridColumn9.Visible = true;
            this.bandedGridColumn9.Width = 24;
            // 
            // bandedGridColumn10
            // 
            this.bandedGridColumn10.Caption = "Alacak Birimi";
            this.bandedGridColumn10.ColumnEdit = this.repositoryItemLookUpEdit4;
            this.bandedGridColumn10.FieldName = "ParaBirimi";
            this.bandedGridColumn10.Name = "bandedGridColumn10";
            this.bandedGridColumn10.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn10.Visible = true;
            this.bandedGridColumn10.Width = 70;
            // 
            // repositoryItemLookUpEdit4
            // 
            this.repositoryItemLookUpEdit4.AutoHeight = false;
            this.repositoryItemLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit4.Name = "repositoryItemLookUpEdit4";
            // 
            // bandedGridColumn11
            // 
            this.bandedGridColumn11.Caption = "Tutar";
            this.bandedGridColumn11.ColumnEdit = this.repositoryItemSpinEdit5;
            this.bandedGridColumn11.FieldName = "TUTAR";
            this.bandedGridColumn11.Name = "bandedGridColumn11";
            this.bandedGridColumn11.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn11.Visible = true;
            this.bandedGridColumn11.Width = 105;
            // 
            // repositoryItemSpinEdit5
            // 
            this.repositoryItemSpinEdit5.AutoHeight = false;
            this.repositoryItemSpinEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit5.Name = "repositoryItemSpinEdit5";
            // 
            // bandedGridColumn12
            // 
            this.bandedGridColumn12.Caption = " ";
            this.bandedGridColumn12.ColumnEdit = this.repositoryItemLookUpEdit4;
            this.bandedGridColumn12.CustomizationCaption = "Tutar Para Birimi";
            this.bandedGridColumn12.FieldName = "TUTAR_DOVIZ_ID";
            this.bandedGridColumn12.Name = "bandedGridColumn12";
            this.bandedGridColumn12.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn12.Visible = true;
            this.bandedGridColumn12.Width = 37;
            // 
            // bandedGridColumn13
            // 
            this.bandedGridColumn13.Caption = "Faiz";
            this.bandedGridColumn13.ColumnEdit = this.repositoryItemSpinEdit5;
            this.bandedGridColumn13.FieldName = "FAIZ";
            this.bandedGridColumn13.Name = "bandedGridColumn13";
            this.bandedGridColumn13.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn13.Visible = true;
            this.bandedGridColumn13.Width = 115;
            // 
            // bandedGridColumn14
            // 
            this.bandedGridColumn14.Caption = " ";
            this.bandedGridColumn14.ColumnEdit = this.repositoryItemLookUpEdit4;
            this.bandedGridColumn14.CustomizationCaption = "Faiz Para Birimi";
            this.bandedGridColumn14.FieldName = "FAIZ_DOVIZ_ID";
            this.bandedGridColumn14.Name = "bandedGridColumn14";
            this.bandedGridColumn14.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn14.Visible = true;
            this.bandedGridColumn14.Width = 36;
            // 
            // bandedGridColumn15
            // 
            this.bandedGridColumn15.Caption = "Diğer";
            this.bandedGridColumn15.ColumnEdit = this.repositoryItemSpinEdit5;
            this.bandedGridColumn15.FieldName = "DIGER";
            this.bandedGridColumn15.Name = "bandedGridColumn15";
            this.bandedGridColumn15.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn15.Visible = true;
            this.bandedGridColumn15.Width = 113;
            // 
            // bandedGridColumn16
            // 
            this.bandedGridColumn16.Caption = " ";
            this.bandedGridColumn16.ColumnEdit = this.repositoryItemLookUpEdit4;
            this.bandedGridColumn16.CustomizationCaption = "Diğer Gider Para Birimi";
            this.bandedGridColumn16.FieldName = "DIGER_DOVIZ_ID";
            this.bandedGridColumn16.Name = "bandedGridColumn16";
            this.bandedGridColumn16.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn16.Visible = true;
            this.bandedGridColumn16.Width = 37;
            // 
            // bandedGridColumn17
            // 
            this.bandedGridColumn17.Caption = "Toplam";
            this.bandedGridColumn17.ColumnEdit = this.repositoryItemSpinEdit5;
            this.bandedGridColumn17.FieldName = "TOPLAM";
            this.bandedGridColumn17.Name = "bandedGridColumn17";
            this.bandedGridColumn17.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn17.Visible = true;
            this.bandedGridColumn17.Width = 121;
            // 
            // bandedGridColumn18
            // 
            this.bandedGridColumn18.Caption = " ";
            this.bandedGridColumn18.ColumnEdit = this.repositoryItemLookUpEdit4;
            this.bandedGridColumn18.CustomizationCaption = "Toplam Para Birimi ";
            this.bandedGridColumn18.FieldName = "TOPLAM_DOVIZ_ID";
            this.bandedGridColumn18.Name = "bandedGridColumn18";
            this.bandedGridColumn18.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn18.Visible = true;
            this.bandedGridColumn18.Width = 37;
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.linkLabel4.Location = new System.Drawing.Point(664, 89);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(54, 13);
            this.linkLabel4.TabIndex = 23;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Gelişmiş";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ucDovizliTutarAlani1
            // 
            this.ucDovizliTutarAlani1.Location = new System.Drawing.Point(455, 6);
            this.ucDovizliTutarAlani1.MaximumSize = new System.Drawing.Size(0, 20);
            this.ucDovizliTutarAlani1.MinimumSize = new System.Drawing.Size(160, 20);
            this.ucDovizliTutarAlani1.Name = "ucDovizliTutarAlani1";
            this.ucDovizliTutarAlani1.ReadOnlyDoviz = true;
            this.ucDovizliTutarAlani1.ReadOnlyTutar = true;
            this.ucDovizliTutarAlani1.Size = new System.Drawing.Size(204, 20);
            this.ucDovizliTutarAlani1.TabIndex = 22;
            paraVeDovizId5.DovizId = 1;
            paraVeDovizId5.KurCevrimTarihi = null;
            paraVeDovizId5.Para = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucDovizliTutarAlani1.Tutar = paraVeDovizId5;
            // 
            // ucDovizliTutarAlani2
            // 
            this.ucDovizliTutarAlani2.Location = new System.Drawing.Point(455, 34);
            this.ucDovizliTutarAlani2.MaximumSize = new System.Drawing.Size(0, 20);
            this.ucDovizliTutarAlani2.MinimumSize = new System.Drawing.Size(160, 20);
            this.ucDovizliTutarAlani2.Name = "ucDovizliTutarAlani2";
            this.ucDovizliTutarAlani2.ReadOnlyDoviz = true;
            this.ucDovizliTutarAlani2.Size = new System.Drawing.Size(204, 20);
            this.ucDovizliTutarAlani2.TabIndex = 22;
            paraVeDovizId6.DovizId = 1;
            paraVeDovizId6.KurCevrimTarihi = null;
            paraVeDovizId6.Para = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucDovizliTutarAlani2.Tutar = paraVeDovizId6;
            this.ucDovizliTutarAlani2.TutarDegisti += new System.EventHandler<System.EventArgs>(this.prVekaletUcreti_TutarDegisti);
            // 
            // ucDovizliTutarAlani3
            // 
            this.ucDovizliTutarAlani3.Location = new System.Drawing.Point(455, 60);
            this.ucDovizliTutarAlani3.MaximumSize = new System.Drawing.Size(0, 20);
            this.ucDovizliTutarAlani3.MinimumSize = new System.Drawing.Size(160, 20);
            this.ucDovizliTutarAlani3.Name = "ucDovizliTutarAlani3";
            this.ucDovizliTutarAlani3.ReadOnlyDoviz = true;
            this.ucDovizliTutarAlani3.ReadOnlyTutar = true;
            this.ucDovizliTutarAlani3.Size = new System.Drawing.Size(204, 20);
            this.ucDovizliTutarAlani3.TabIndex = 22;
            paraVeDovizId7.DovizId = 1;
            paraVeDovizId7.KurCevrimTarihi = null;
            paraVeDovizId7.Para = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucDovizliTutarAlani3.Tutar = paraVeDovizId7;
            // 
            // ucDovizliTutarAlani4
            // 
            this.ucDovizliTutarAlani4.Location = new System.Drawing.Point(455, 86);
            this.ucDovizliTutarAlani4.MaximumSize = new System.Drawing.Size(0, 20);
            this.ucDovizliTutarAlani4.MinimumSize = new System.Drawing.Size(160, 20);
            this.ucDovizliTutarAlani4.Name = "ucDovizliTutarAlani4";
            this.ucDovizliTutarAlani4.ReadOnlyDoviz = true;
            this.ucDovizliTutarAlani4.ReadOnlyTutar = true;
            this.ucDovizliTutarAlani4.Size = new System.Drawing.Size(204, 20);
            this.ucDovizliTutarAlani4.TabIndex = 22;
            paraVeDovizId8.DovizId = 1;
            paraVeDovizId8.KurCevrimTarihi = null;
            paraVeDovizId8.Para = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucDovizliTutarAlani4.Tutar = paraVeDovizId8;
            // 
            // checkEdit3
            // 
            this.checkEdit3.Location = new System.Drawing.Point(665, 60);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Caption = "Dahil";
            this.checkEdit3.Size = new System.Drawing.Size(51, 19);
            this.checkEdit3.TabIndex = 3;
            // 
            // labelControl41
            // 
            this.labelControl41.Location = new System.Drawing.Point(373, 35);
            this.labelControl41.Name = "labelControl41";
            this.labelControl41.Size = new System.Drawing.Size(66, 13);
            this.labelControl41.TabIndex = 1;
            this.labelControl41.Text = "Vekalet Ücreti";
            // 
            // lookUpEdit2
            // 
            this.lookUpEdit2.Location = new System.Drawing.Point(133, 60);
            this.lookUpEdit2.Name = "lookUpEdit2";
            this.lookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit2.Size = new System.Drawing.Size(192, 20);
            this.lookUpEdit2.TabIndex = 2;
            // 
            // labelControl42
            // 
            this.labelControl42.Location = new System.Drawing.Point(373, 9);
            this.labelControl42.Name = "labelControl42";
            this.labelControl42.Size = new System.Drawing.Size(71, 13);
            this.labelControl42.TabIndex = 1;
            this.labelControl42.Text = "Toplam Masraf";
            // 
            // labelControl43
            // 
            this.labelControl43.Location = new System.Drawing.Point(373, 89);
            this.labelControl43.Name = "labelControl43";
            this.labelControl43.Size = new System.Drawing.Size(34, 13);
            this.labelControl43.TabIndex = 1;
            this.labelControl43.Text = "Toplam";
            // 
            // labelControl44
            // 
            this.labelControl44.Location = new System.Drawing.Point(11, 61);
            this.labelControl44.Name = "labelControl44";
            this.labelControl44.Size = new System.Drawing.Size(49, 13);
            this.labelControl44.TabIndex = 1;
            this.labelControl44.Text = "Hesap Tipi";
            // 
            // labelControl45
            // 
            this.labelControl45.Location = new System.Drawing.Point(373, 62);
            this.labelControl45.Name = "labelControl45";
            this.labelControl45.Size = new System.Drawing.Size(56, 13);
            this.labelControl45.TabIndex = 1;
            this.labelControl45.Text = "Bakiye Harç";
            // 
            // lookUpEdit3
            // 
            this.lookUpEdit3.Location = new System.Drawing.Point(133, 32);
            this.lookUpEdit3.Name = "lookUpEdit3";
            this.lookUpEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit3.Size = new System.Drawing.Size(192, 20);
            this.lookUpEdit3.TabIndex = 2;
            // 
            // labelControl46
            // 
            this.labelControl46.Location = new System.Drawing.Point(11, 35);
            this.labelControl46.Name = "labelControl46";
            this.labelControl46.Size = new System.Drawing.Size(67, 13);
            this.labelControl46.TabIndex = 1;
            this.labelControl46.Text = "Bir Yıl Kaç Gün";
            // 
            // labelControl47
            // 
            this.labelControl47.Location = new System.Drawing.Point(11, 8);
            this.labelControl47.Name = "labelControl47";
            this.labelControl47.Size = new System.Drawing.Size(59, 13);
            this.labelControl47.TabIndex = 1;
            this.labelControl47.Text = "Hesap Tarihi";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(133, 6);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(192, 20);
            this.dateEdit1.TabIndex = 0;
            // 
            // checkEdit6
            // 
            this.checkEdit6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkEdit6.EditValue = true;
            this.checkEdit6.Location = new System.Drawing.Point(-222, 292);
            this.checkEdit6.Name = "checkEdit6";
            this.checkEdit6.Properties.Caption = "Gayrinakitler hesaba dahil edilsin";
            this.checkEdit6.Size = new System.Drawing.Size(180, 19);
            this.checkEdit6.TabIndex = 8;
            this.checkEdit6.Visible = false;
            // 
            // dateEdit2
            // 
            this.dateEdit2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(-794, 291);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.MinValue = new System.DateTime(2010, 6, 2, 0, 0, 0, 0);
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(105, 20);
            this.dateEdit2.TabIndex = 5;
            this.dateEdit2.EditValueChanged += new System.EventHandler(this.dateTaksitlerBaslasin_EditValueChanged);
            // 
            // checkEdit4
            // 
            this.checkEdit4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkEdit4.EditValue = true;
            this.checkEdit4.Location = new System.Drawing.Point(-222, 292);
            this.checkEdit4.Name = "checkEdit4";
            this.checkEdit4.Properties.Caption = "Gayrinakitler hesaba dahil edilsin";
            this.checkEdit4.Size = new System.Drawing.Size(180, 19);
            this.checkEdit4.TabIndex = 8;
            this.checkEdit4.Visible = false;
            // 
            // gcSimulasyonGruplari
            // 
            this.gcSimulasyonGruplari.Location = new System.Drawing.Point(11, 141);
            this.gcSimulasyonGruplari.MainView = this.gwSimulasyonGruplari;
            this.gcSimulasyonGruplari.MenuManager = this.ribbonControl1;
            this.gcSimulasyonGruplari.Name = "gcSimulasyonGruplari";
            this.gcSimulasyonGruplari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueSimuDoviz,
            this.rSpinSimuPara});
            this.gcSimulasyonGruplari.Size = new System.Drawing.Size(789, 135);
            this.gcSimulasyonGruplari.TabIndex = 0;
            this.gcSimulasyonGruplari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwSimulasyonGruplari});
            this.gcSimulasyonGruplari.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gcSimulasyonGruplari_MouseMove);
            // 
            // gwSimulasyonGruplari
            // 
            this.gwSimulasyonGruplari.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand3});
            this.gwSimulasyonGruplari.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colSecim,
            this.gridColumn27,
            this.colTUTAR1,
            this.colTUTAR_DOVIZ_ID1,
            this.colFAIZ,
            this.colFAIZ_DOVIZ_ID,
            this.colDIGER,
            this.colDIGER_DOVIZ_ID,
            this.colTOPLAM,
            this.colTOPLAM_DOVIZ_ID});
            this.gwSimulasyonGruplari.GridControl = this.gcSimulasyonGruplari;
            this.gwSimulasyonGruplari.Name = "gwSimulasyonGruplari";
            this.gwSimulasyonGruplari.OptionsView.ShowGroupPanel = false;
            this.gwSimulasyonGruplari.OptionsView.ShowIndicator = false;
            this.gwSimulasyonGruplari.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvSimulasyonGruplari_CellValueChanged);
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "Alacak Toplamları";
            this.gridBand3.Columns.Add(this.colSecim);
            this.gridBand3.Columns.Add(this.gridColumn27);
            this.gridBand3.Columns.Add(this.colTUTAR1);
            this.gridBand3.Columns.Add(this.colTUTAR_DOVIZ_ID1);
            this.gridBand3.Columns.Add(this.colFAIZ);
            this.gridBand3.Columns.Add(this.colFAIZ_DOVIZ_ID);
            this.gridBand3.Columns.Add(this.colDIGER);
            this.gridBand3.Columns.Add(this.colDIGER_DOVIZ_ID);
            this.gridBand3.Columns.Add(this.colTOPLAM);
            this.gridBand3.Columns.Add(this.colTOPLAM_DOVIZ_ID);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 695;
            // 
            // colSecim
            // 
            this.colSecim.Caption = "Seç";
            this.colSecim.FieldName = "Secim";
            this.colSecim.Name = "colSecim";
            this.colSecim.Visible = true;
            this.colSecim.Width = 24;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Alacak Birimi";
            this.gridColumn27.ColumnEdit = this.rlueSimuDoviz;
            this.gridColumn27.FieldName = "ParaBirimi";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.ReadOnly = true;
            this.gridColumn27.Visible = true;
            this.gridColumn27.Width = 70;
            // 
            // rlueSimuDoviz
            // 
            this.rlueSimuDoviz.AutoHeight = false;
            this.rlueSimuDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueSimuDoviz.Name = "rlueSimuDoviz";
            // 
            // colTUTAR1
            // 
            this.colTUTAR1.Caption = "Tutar";
            this.colTUTAR1.ColumnEdit = this.rSpinSimuPara;
            this.colTUTAR1.FieldName = "ASIL_ALACAK";
            this.colTUTAR1.Name = "colTUTAR1";
            this.colTUTAR1.OptionsColumn.ReadOnly = true;
            this.colTUTAR1.Visible = true;
            this.colTUTAR1.Width = 105;
            // 
            // rSpinSimuPara
            // 
            this.rSpinSimuPara.AutoHeight = false;
            this.rSpinSimuPara.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rSpinSimuPara.Name = "rSpinSimuPara";
            // 
            // colTUTAR_DOVIZ_ID1
            // 
            this.colTUTAR_DOVIZ_ID1.Caption = " ";
            this.colTUTAR_DOVIZ_ID1.ColumnEdit = this.rlueSimuDoviz;
            this.colTUTAR_DOVIZ_ID1.CustomizationCaption = "Tutar Para Birimi";
            this.colTUTAR_DOVIZ_ID1.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            this.colTUTAR_DOVIZ_ID1.Name = "colTUTAR_DOVIZ_ID1";
            this.colTUTAR_DOVIZ_ID1.OptionsColumn.ReadOnly = true;
            this.colTUTAR_DOVIZ_ID1.Visible = true;
            this.colTUTAR_DOVIZ_ID1.Width = 37;
            // 
            // colFAIZ
            // 
            this.colFAIZ.Caption = "Faiz";
            this.colFAIZ.ColumnEdit = this.rSpinSimuPara;
            this.colFAIZ.FieldName = "FAIZLER";
            this.colFAIZ.Name = "colFAIZ";
            this.colFAIZ.OptionsColumn.ReadOnly = true;
            this.colFAIZ.Visible = true;
            this.colFAIZ.Width = 115;
            // 
            // colFAIZ_DOVIZ_ID
            // 
            this.colFAIZ_DOVIZ_ID.Caption = " ";
            this.colFAIZ_DOVIZ_ID.ColumnEdit = this.rlueSimuDoviz;
            this.colFAIZ_DOVIZ_ID.CustomizationCaption = "Faiz Para Birimi";
            this.colFAIZ_DOVIZ_ID.FieldName = "FAIZLER_DOVIZ_ID";
            this.colFAIZ_DOVIZ_ID.Name = "colFAIZ_DOVIZ_ID";
            this.colFAIZ_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colFAIZ_DOVIZ_ID.Visible = true;
            this.colFAIZ_DOVIZ_ID.Width = 36;
            // 
            // colDIGER
            // 
            this.colDIGER.Caption = "Diğer";
            this.colDIGER.ColumnEdit = this.rSpinSimuPara;
            this.colDIGER.FieldName = "TOPLAM_DIGER";
            this.colDIGER.Name = "colDIGER";
            this.colDIGER.OptionsColumn.ReadOnly = true;
            this.colDIGER.Visible = true;
            this.colDIGER.Width = 113;
            // 
            // colDIGER_DOVIZ_ID
            // 
            this.colDIGER_DOVIZ_ID.Caption = " ";
            this.colDIGER_DOVIZ_ID.ColumnEdit = this.rlueSimuDoviz;
            this.colDIGER_DOVIZ_ID.CustomizationCaption = "Diğer Gider Para Birimi";
            this.colDIGER_DOVIZ_ID.FieldName = "TOPLAM_DOVIZ_ID";
            this.colDIGER_DOVIZ_ID.Name = "colDIGER_DOVIZ_ID";
            this.colDIGER_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colDIGER_DOVIZ_ID.Visible = true;
            this.colDIGER_DOVIZ_ID.Width = 37;
            // 
            // colTOPLAM
            // 
            this.colTOPLAM.Caption = "Toplam";
            this.colTOPLAM.ColumnEdit = this.rSpinSimuPara;
            this.colTOPLAM.FieldName = "TOPLAM";
            this.colTOPLAM.Name = "colTOPLAM";
            this.colTOPLAM.OptionsColumn.ReadOnly = true;
            this.colTOPLAM.Visible = true;
            this.colTOPLAM.Width = 121;
            // 
            // colTOPLAM_DOVIZ_ID
            // 
            this.colTOPLAM_DOVIZ_ID.Caption = " ";
            this.colTOPLAM_DOVIZ_ID.ColumnEdit = this.rlueSimuDoviz;
            this.colTOPLAM_DOVIZ_ID.CustomizationCaption = "Toplam Para Birimi ";
            this.colTOPLAM_DOVIZ_ID.FieldName = "TOPLAM_DOVIZ_ID";
            this.colTOPLAM_DOVIZ_ID.Name = "colTOPLAM_DOVIZ_ID";
            this.colTOPLAM_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colTOPLAM_DOVIZ_ID.Visible = true;
            this.colTOPLAM_DOVIZ_ID.Width = 37;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.linkLabel1.Location = new System.Drawing.Point(664, 89);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(54, 13);
            this.linkLabel1.TabIndex = 23;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Gelişmiş";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // prToplamMasraf
            // 
            this.prToplamMasraf.Location = new System.Drawing.Point(455, 6);
            this.prToplamMasraf.MaximumSize = new System.Drawing.Size(0, 20);
            this.prToplamMasraf.MinimumSize = new System.Drawing.Size(160, 20);
            this.prToplamMasraf.Name = "prToplamMasraf";
            this.prToplamMasraf.ReadOnlyDoviz = true;
            this.prToplamMasraf.ReadOnlyTutar = true;
            this.prToplamMasraf.Size = new System.Drawing.Size(204, 20);
            this.prToplamMasraf.TabIndex = 22;
            paraVeDovizId9.DovizId = 1;
            paraVeDovizId9.KurCevrimTarihi = null;
            paraVeDovizId9.Para = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.prToplamMasraf.Tutar = paraVeDovizId9;
            // 
            // prVekaletUcreti
            // 
            this.prVekaletUcreti.Location = new System.Drawing.Point(455, 34);
            this.prVekaletUcreti.MaximumSize = new System.Drawing.Size(0, 20);
            this.prVekaletUcreti.MinimumSize = new System.Drawing.Size(160, 20);
            this.prVekaletUcreti.Name = "prVekaletUcreti";
            this.prVekaletUcreti.ReadOnlyDoviz = true;
            this.prVekaletUcreti.Size = new System.Drawing.Size(204, 20);
            this.prVekaletUcreti.TabIndex = 22;
            paraVeDovizId10.DovizId = 1;
            paraVeDovizId10.KurCevrimTarihi = null;
            paraVeDovizId10.Para = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.prVekaletUcreti.Tutar = paraVeDovizId10;
            this.prVekaletUcreti.TutarDegisti += new System.EventHandler<System.EventArgs>(this.prVekaletUcreti_TutarDegisti);
            // 
            // prBakiyeHarc
            // 
            this.prBakiyeHarc.Location = new System.Drawing.Point(455, 60);
            this.prBakiyeHarc.MaximumSize = new System.Drawing.Size(0, 20);
            this.prBakiyeHarc.MinimumSize = new System.Drawing.Size(160, 20);
            this.prBakiyeHarc.Name = "prBakiyeHarc";
            this.prBakiyeHarc.ReadOnlyDoviz = true;
            this.prBakiyeHarc.ReadOnlyTutar = true;
            this.prBakiyeHarc.Size = new System.Drawing.Size(204, 20);
            this.prBakiyeHarc.TabIndex = 22;
            paraVeDovizId11.DovizId = 1;
            paraVeDovizId11.KurCevrimTarihi = null;
            paraVeDovizId11.Para = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.prBakiyeHarc.Tutar = paraVeDovizId11;
            // 
            // prToplam
            // 
            this.prToplam.Location = new System.Drawing.Point(455, 86);
            this.prToplam.MaximumSize = new System.Drawing.Size(0, 20);
            this.prToplam.MinimumSize = new System.Drawing.Size(160, 20);
            this.prToplam.Name = "prToplam";
            this.prToplam.ReadOnlyDoviz = true;
            this.prToplam.ReadOnlyTutar = true;
            this.prToplam.Size = new System.Drawing.Size(204, 20);
            this.prToplam.TabIndex = 22;
            paraVeDovizId12.DovizId = 1;
            paraVeDovizId12.KurCevrimTarihi = null;
            paraVeDovizId12.Para = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.prToplam.Tutar = paraVeDovizId12;
            // 
            // cbBakiyeHarcHesabaDahil
            // 
            this.cbBakiyeHarcHesabaDahil.Location = new System.Drawing.Point(665, 60);
            this.cbBakiyeHarcHesabaDahil.Name = "cbBakiyeHarcHesabaDahil";
            this.cbBakiyeHarcHesabaDahil.Properties.Caption = "Dahil";
            this.cbBakiyeHarcHesabaDahil.Size = new System.Drawing.Size(51, 19);
            this.cbBakiyeHarcHesabaDahil.TabIndex = 3;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(373, 35);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(66, 13);
            this.labelControl16.TabIndex = 1;
            this.labelControl16.Text = "Vekalet Ücreti";
            // 
            // lueHesapTipi
            // 
            this.lueHesapTipi.Location = new System.Drawing.Point(133, 60);
            this.lueHesapTipi.Name = "lueHesapTipi";
            this.lueHesapTipi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueHesapTipi.Size = new System.Drawing.Size(192, 20);
            this.lueHesapTipi.TabIndex = 2;
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(373, 9);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(71, 13);
            this.labelControl15.TabIndex = 1;
            this.labelControl15.Text = "Toplam Masraf";
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(373, 89);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(34, 13);
            this.labelControl17.TabIndex = 1;
            this.labelControl17.Text = "Toplam";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(11, 61);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(49, 13);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Hesap Tipi";
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(373, 62);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(56, 13);
            this.labelControl14.TabIndex = 1;
            this.labelControl14.Text = "Bakiye Harç";
            // 
            // lueBirYilKacGun
            // 
            this.lueBirYilKacGun.Location = new System.Drawing.Point(133, 32);
            this.lueBirYilKacGun.Name = "lueBirYilKacGun";
            this.lueBirYilKacGun.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBirYilKacGun.Size = new System.Drawing.Size(192, 20);
            this.lueBirYilKacGun.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Bir Yıl Kaç Gün";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Hesap Tarihi";
            // 
            // dateSonHesapTarihi
            // 
            this.dateSonHesapTarihi.EditValue = null;
            this.dateSonHesapTarihi.Location = new System.Drawing.Point(133, 6);
            this.dateSonHesapTarihi.Name = "dateSonHesapTarihi";
            this.dateSonHesapTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateSonHesapTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateSonHesapTarihi.Size = new System.Drawing.Size(192, 20);
            this.dateSonHesapTarihi.TabIndex = 0;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.simpleButton3.Appearance.BackColor = System.Drawing.Color.Red;
            this.simpleButton3.Appearance.Options.UseBackColor = true;
            this.simpleButton3.Location = new System.Drawing.Point(722, 331);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(142, 23);
            this.simpleButton3.TabIndex = 26;
            this.simpleButton3.Text = "Hesabı Güncelle";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click_1);
            // 
            // lueFaizSecenekleri
            // 
            this.lueFaizSecenekleri.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueFaizSecenekleri.Location = new System.Drawing.Point(203, 334);
            this.lueFaizSecenekleri.Name = "lueFaizSecenekleri";
            this.lueFaizSecenekleri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueFaizSecenekleri.Size = new System.Drawing.Size(513, 20);
            this.lueFaizSecenekleri.TabIndex = 6;
            // 
            // dateTaksitlerBaslasin
            // 
            this.dateTaksitlerBaslasin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTaksitlerBaslasin.EditValue = null;
            this.dateTaksitlerBaslasin.Location = new System.Drawing.Point(118, 312);
            this.dateTaksitlerBaslasin.Name = "dateTaksitlerBaslasin";
            this.dateTaksitlerBaslasin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTaksitlerBaslasin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateTaksitlerBaslasin.Size = new System.Drawing.Size(105, 20);
            this.dateTaksitlerBaslasin.TabIndex = 5;
            this.dateTaksitlerBaslasin.EditValueChanged += new System.EventHandler(this.dateTaksitlerBaslasin_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl5.Location = new System.Drawing.Point(70, 315);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(311, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Taksitler                     ayı              tarihinden itibaren oluşturulsun.";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl6.Location = new System.Drawing.Point(70, 337);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(110, 13);
            this.labelControl6.TabIndex = 1;
            this.labelControl6.Text = "Faiz İşletim Seçenekleri";
            // 
            // btnEkle
            // 
            this.btnEkle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEkle.Location = new System.Drawing.Point(422, 199);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 5;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // rgKosullar
            // 
            this.rgKosullar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rgKosullar.Location = new System.Drawing.Point(2, 2);
            this.rgKosullar.Name = "rgKosullar";
            this.rgKosullar.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Her ayın                 . günü .......................                 ödenerek " +
                    "bitsin."),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Her ayın                 . günü,                    ay süreyle ....              " +
                    "                        ödensin."),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Her ayın                  . günü ödensin.                   ayda bitsin."),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "                 ayda bir, ayın                 . günü ...............           " +
                    "             ödenerek bitsin."),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(5, "                                      tarihinde .............................   ö" +
                    "densin.")});
            this.rgKosullar.Size = new System.Drawing.Size(441, 140);
            this.rgKosullar.TabIndex = 0;
            this.rgKosullar.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.mbtnTumKosullariKaldir});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Koşulu Kaldır";
            // 
            // mbtnTumKosullariKaldir
            // 
            this.mbtnTumKosullariKaldir.Name = "mbtnTumKosullariKaldir";
            this.mbtnTumKosullariKaldir.Size = new System.Drawing.Size(180, 22);
            this.mbtnTumKosullariKaldir.Text = "Tüm Koşulları Kaldır";
            this.mbtnTumKosullariKaldir.Click += new System.EventHandler(this.mbtnTumKosullariKaldir_Click);
            // 
            // ceGayriNakit
            // 
            this.ceGayriNakit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ceGayriNakit.EditValue = true;
            this.ceGayriNakit.Location = new System.Drawing.Point(690, 313);
            this.ceGayriNakit.MenuManager = this.ribbonControl1;
            this.ceGayriNakit.Name = "ceGayriNakit";
            this.ceGayriNakit.Properties.Caption = "Gayrinakitler hesaba dahil edilsin";
            this.ceGayriNakit.Size = new System.Drawing.Size(180, 19);
            this.ceGayriNakit.TabIndex = 8;
            this.ceGayriNakit.Visible = false;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Location = new System.Drawing.Point(233, 129);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(103, 141);
            this.simpleButton2.TabIndex = 25;
            this.simpleButton2.Text = "Kaydet";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnHesapla
            // 
            this.btnHesapla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHesapla.Location = new System.Drawing.Point(621, 500);
            this.btnHesapla.Name = "btnHesapla";
            this.btnHesapla.Size = new System.Drawing.Size(75, 23);
            this.btnHesapla.TabIndex = 2;
            this.btnHesapla.Text = "Hesapla";
            this.btnHesapla.Visible = false;
            this.btnHesapla.Click += new System.EventHandler(this.btnHesapla_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl7.Location = new System.Drawing.Point(58, 213);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(78, 13);
            this.labelControl7.TabIndex = 24;
            this.labelControl7.Text = "Yapılan Tercihler";
            // 
            // m5_deTarih
            // 
            this.m5_deTarih.EditValue = null;
            this.m5_deTarih.Location = new System.Drawing.Point(24, 113);
            this.m5_deTarih.Name = "m5_deTarih";
            this.m5_deTarih.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.m5_deTarih.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.m5_deTarih.Size = new System.Drawing.Size(101, 20);
            this.m5_deTarih.TabIndex = 23;
            // 
            // m1_spinOdeme
            // 
            this.m1_spinOdeme.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m1_spinOdeme.Location = new System.Drawing.Point(150, 10);
            this.m1_spinOdeme.Name = "m1_spinOdeme";
            this.m1_spinOdeme.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.m1_spinOdeme.Size = new System.Drawing.Size(137, 20);
            this.m1_spinOdeme.TabIndex = 16;
            // 
            // m2_lueOdemeDovizId
            // 
            this.m2_lueOdemeDovizId.Location = new System.Drawing.Point(263, 36);
            this.m2_lueOdemeDovizId.Name = "m2_lueOdemeDovizId";
            this.m2_lueOdemeDovizId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.m2_lueOdemeDovizId.Size = new System.Drawing.Size(61, 20);
            this.m2_lueOdemeDovizId.TabIndex = 21;
            this.m2_lueOdemeDovizId.Visible = false;
            // 
            // m2_spinAy
            // 
            this.m2_spinAy.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m2_spinAy.Location = new System.Drawing.Point(151, 36);
            this.m2_spinAy.Name = "m2_spinAy";
            this.m2_spinAy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.m2_spinAy.Size = new System.Drawing.Size(54, 20);
            this.m2_spinAy.TabIndex = 13;
            // 
            // m1_spinGun
            // 
            this.m1_spinGun.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m1_spinGun.Location = new System.Drawing.Point(69, 10);
            this.m1_spinGun.Name = "m1_spinGun";
            this.m1_spinGun.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.m1_spinGun.Size = new System.Drawing.Size(47, 20);
            this.m1_spinGun.TabIndex = 12;
            // 
            // m4_spinOdeme
            // 
            this.m4_spinOdeme.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m4_spinOdeme.Location = new System.Drawing.Point(232, 88);
            this.m4_spinOdeme.Name = "m4_spinOdeme";
            this.m4_spinOdeme.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.m4_spinOdeme.Size = new System.Drawing.Size(114, 20);
            this.m4_spinOdeme.TabIndex = 17;
            // 
            // m5_lueOdemeDoviz
            // 
            this.m5_lueOdemeDoviz.Location = new System.Drawing.Point(183, 114);
            this.m5_lueOdemeDoviz.Name = "m5_lueOdemeDoviz";
            this.m5_lueOdemeDoviz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.m5_lueOdemeDoviz.Size = new System.Drawing.Size(61, 20);
            this.m5_lueOdemeDoviz.TabIndex = 20;
            this.m5_lueOdemeDoviz.Visible = false;
            // 
            // m3_spinAy
            // 
            this.m3_spinAy.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m3_spinAy.Location = new System.Drawing.Point(201, 62);
            this.m3_spinAy.Name = "m3_spinAy";
            this.m3_spinAy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.m3_spinAy.Size = new System.Drawing.Size(42, 20);
            this.m3_spinAy.TabIndex = 14;
            // 
            // m2_spinGun
            // 
            this.m2_spinGun.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m2_spinGun.Location = new System.Drawing.Point(69, 36);
            this.m2_spinGun.Name = "m2_spinGun";
            this.m2_spinGun.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.m2_spinGun.Size = new System.Drawing.Size(47, 20);
            this.m2_spinGun.TabIndex = 8;
            // 
            // m5_spinOdeme
            // 
            this.m5_spinOdeme.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m5_spinOdeme.Location = new System.Drawing.Point(183, 113);
            this.m5_spinOdeme.Name = "m5_spinOdeme";
            this.m5_spinOdeme.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.m5_spinOdeme.Size = new System.Drawing.Size(117, 20);
            this.m5_spinOdeme.TabIndex = 15;
            // 
            // m4_lueOdemeDovizId
            // 
            this.m4_lueOdemeDovizId.Location = new System.Drawing.Point(232, 84);
            this.m4_lueOdemeDovizId.Name = "m4_lueOdemeDovizId";
            this.m4_lueOdemeDovizId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.m4_lueOdemeDovizId.Size = new System.Drawing.Size(55, 20);
            this.m4_lueOdemeDovizId.TabIndex = 22;
            this.m4_lueOdemeDovizId.Visible = false;
            // 
            // m4_spinGun
            // 
            this.m4_spinGun.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m4_spinGun.Location = new System.Drawing.Point(148, 88);
            this.m4_spinGun.Name = "m4_spinGun";
            this.m4_spinGun.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.m4_spinGun.Size = new System.Drawing.Size(41, 20);
            this.m4_spinGun.TabIndex = 11;
            // 
            // m3_spinGun
            // 
            this.m3_spinGun.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m3_spinGun.Location = new System.Drawing.Point(71, 62);
            this.m3_spinGun.Name = "m3_spinGun";
            this.m3_spinGun.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.m3_spinGun.Size = new System.Drawing.Size(47, 20);
            this.m3_spinGun.TabIndex = 10;
            // 
            // m2_spinOdeme
            // 
            this.m2_spinOdeme.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m2_spinOdeme.Location = new System.Drawing.Point(263, 36);
            this.m2_spinOdeme.Name = "m2_spinOdeme";
            this.m2_spinOdeme.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.m2_spinOdeme.Size = new System.Drawing.Size(118, 20);
            this.m2_spinOdeme.TabIndex = 18;
            // 
            // m1_lueOdemeDovizId
            // 
            this.m1_lueOdemeDovizId.Location = new System.Drawing.Point(150, 10);
            this.m1_lueOdemeDovizId.Name = "m1_lueOdemeDovizId";
            this.m1_lueOdemeDovizId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.m1_lueOdemeDovizId.Size = new System.Drawing.Size(61, 20);
            this.m1_lueOdemeDovizId.TabIndex = 19;
            this.m1_lueOdemeDovizId.Visible = false;
            // 
            // m4_spinAy
            // 
            this.m4_spinAy.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m4_spinAy.Location = new System.Drawing.Point(24, 88);
            this.m4_spinAy.Name = "m4_spinAy";
            this.m4_spinAy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.m4_spinAy.Size = new System.Drawing.Size(43, 20);
            this.m4_spinAy.TabIndex = 9;
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listBoxControl1.HorizontalScrollbar = true;
            this.listBoxControl1.Location = new System.Drawing.Point(58, 232);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(441, 291);
            this.listBoxControl1.TabIndex = 6;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gcBorclular);
            this.panelControl1.Controls.Add(this.lueTaahhutEden);
            this.panelControl1.Controls.Add(this.lueTaahhutKabulEden);
            this.panelControl1.Controls.Add(this.ceGecerliTaahhut);
            this.panelControl1.Controls.Add(this.labelControl13);
            this.panelControl1.Controls.Add(this.labelControl12);
            this.panelControl1.Controls.Add(this.labelControl11);
            this.panelControl1.Controls.Add(this.deKabulTarihi);
            this.panelControl1.Controls.Add(this.deTebligTarihi);
            this.panelControl1.Controls.Add(this.deTaahhutTarihi);
            this.panelControl1.Controls.Add(this.labelControl10);
            this.panelControl1.Controls.Add(this.labelControl9);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(932, 531);
            this.panelControl1.TabIndex = 2;
            // 
            // gcBorclular
            // 
            this.gcBorclular.Location = new System.Drawing.Point(130, 117);
            this.gcBorclular.MainView = this.gvBorclular;
            this.gcBorclular.MenuManager = this.ribbonControl1;
            this.gcBorclular.Name = "gcBorclular";
            this.gcBorclular.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueBorclu});
            this.gcBorclular.Size = new System.Drawing.Size(343, 132);
            this.gcBorclular.TabIndex = 7;
            this.gcBorclular.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBorclular});
            this.gcBorclular.Visible = false;
            // 
            // gvBorclular
            // 
            this.gvBorclular.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn28});
            this.gvBorclular.GridControl = this.gcBorclular;
            this.gvBorclular.Name = "gvBorclular";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "ID";
            this.gridColumn7.FieldName = "ID";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Seç";
            this.gridColumn8.FieldName = "IsSelected";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Adı";
            this.gridColumn28.ColumnEdit = this.rlueBorclu;
            this.gridColumn28.FieldName = "CARI_ID";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 1;
            // 
            // rlueBorclu
            // 
            this.rlueBorclu.AutoHeight = false;
            this.rlueBorclu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueBorclu.Name = "rlueBorclu";
            // 
            // lueTaahhutEden
            // 
            this.lueTaahhutEden.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueTaahhutEden.Location = new System.Drawing.Point(287, 76);
            this.lueTaahhutEden.MenuManager = this.ribbonControl1;
            this.lueTaahhutEden.Name = "lueTaahhutEden";
            this.lueTaahhutEden.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTaahhutEden.Size = new System.Drawing.Size(186, 20);
            this.lueTaahhutEden.TabIndex = 6;
            this.lueTaahhutEden.EditValueChanged += new System.EventHandler(this.lueTaahhutEden_EditValueChanged);
            // 
            // lueTaahhutKabulEden
            // 
            this.lueTaahhutKabulEden.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lueTaahhutKabulEden.Location = new System.Drawing.Point(287, 40);
            this.lueTaahhutKabulEden.MenuManager = this.ribbonControl1;
            this.lueTaahhutKabulEden.Name = "lueTaahhutKabulEden";
            this.lueTaahhutKabulEden.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTaahhutKabulEden.Size = new System.Drawing.Size(186, 20);
            this.lueTaahhutKabulEden.TabIndex = 5;
            this.lueTaahhutKabulEden.EditValueChanged += new System.EventHandler(this.lueTaahhutKabulEden_EditValueChanged);
            // 
            // ceGecerliTaahhut
            // 
            this.ceGecerliTaahhut.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ceGecerliTaahhut.EditValue = true;
            this.ceGecerliTaahhut.Location = new System.Drawing.Point(602, 115);
            this.ceGecerliTaahhut.Name = "ceGecerliTaahhut";
            this.ceGecerliTaahhut.Properties.Caption = "Geçerli Taahhüt";
            this.ceGecerliTaahhut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ceGecerliTaahhut.Size = new System.Drawing.Size(120, 19);
            this.ceGecerliTaahhut.TabIndex = 4;
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl13.Location = new System.Drawing.Point(500, 91);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(55, 13);
            this.labelControl13.TabIndex = 3;
            this.labelControl13.Text = "Kabul Tarihi";
            // 
            // labelControl12
            // 
            this.labelControl12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl12.Location = new System.Drawing.Point(500, 65);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(57, 13);
            this.labelControl12.TabIndex = 3;
            this.labelControl12.Text = "Tebliğ Tarihi";
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl11.Location = new System.Drawing.Point(500, 39);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(69, 13);
            this.labelControl11.TabIndex = 3;
            this.labelControl11.Text = "Taahhüt Tarihi";
            // 
            // deKabulTarihi
            // 
            this.deKabulTarihi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.deKabulTarihi.EditValue = null;
            this.deKabulTarihi.Location = new System.Drawing.Point(602, 88);
            this.deKabulTarihi.Name = "deKabulTarihi";
            this.deKabulTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deKabulTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deKabulTarihi.Size = new System.Drawing.Size(165, 20);
            this.deKabulTarihi.TabIndex = 2;
            // 
            // deTebligTarihi
            // 
            this.deTebligTarihi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.deTebligTarihi.EditValue = null;
            this.deTebligTarihi.Location = new System.Drawing.Point(602, 62);
            this.deTebligTarihi.Name = "deTebligTarihi";
            this.deTebligTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTebligTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deTebligTarihi.Size = new System.Drawing.Size(165, 20);
            this.deTebligTarihi.TabIndex = 2;
            // 
            // deTaahhutTarihi
            // 
            this.deTaahhutTarihi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.deTaahhutTarihi.EditValue = null;
            this.deTaahhutTarihi.Location = new System.Drawing.Point(602, 36);
            this.deTaahhutTarihi.Name = "deTaahhutTarihi";
            this.deTaahhutTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTaahhutTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deTaahhutTarihi.Size = new System.Drawing.Size(165, 20);
            this.deTaahhutTarihi.TabIndex = 2;
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl10.Location = new System.Drawing.Point(130, 79);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(99, 13);
            this.labelControl10.TabIndex = 1;
            this.labelControl10.Text = "Taahhüt Eden Borçlu";
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl9.Location = new System.Drawing.Point(130, 43);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(142, 13);
            this.labelControl9.TabIndex = 1;
            this.labelControl9.Text = "Taahhüdü Kabul Eden Alacaklı";
            // 
            // editorRow1
            // 
            this.editorRow1.Name = "editorRow1";
            this.editorRow1.Properties.Caption = "Dosya No";
            this.editorRow1.Properties.FieldName = "FOY_NO";
            this.editorRow1.Properties.RowEdit = this.gLueDosyaNo;
            // 
            // multiEditorRow1
            // 
            this.multiEditorRow1.Name = "multiEditorRow1";
            this.multiEditorRow1.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties1,
            this.multiEditorRowProperties2});
            // 
            // compNavBarAutoHeight1
            // 
            this.compNavBarAutoHeight1.DockingGroup = null;
            this.compNavBarAutoHeight1.MyNavBarControl = null;
            // 
            // compGridDovizSummary1
            // 
            this.compGridDovizSummary1.AltToplamlarAktifMi = true;
            this.compGridDovizSummary1.MyGridView = null;
            this.compGridDovizSummary1.YasakliAlanlar = ((System.Collections.Generic.List<string>)(resources.GetObject("compGridDovizSummary1.YasakliAlanlar")));
            // 
            // compGridDovizSummary2
            // 
            this.compGridDovizSummary2.AltToplamlarAktifMi = false;
            this.compGridDovizSummary2.MyGridView = null;
            this.compGridDovizSummary2.YasakliAlanlar = ((System.Collections.Generic.List<string>)(resources.GetObject("compGridDovizSummary2.YasakliAlanlar")));
            // 
            // pnlWizard
            // 
            this.pnlWizard.Controls.Add(this.wizardControl1);
            this.pnlWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWizard.Location = new System.Drawing.Point(0, 0);
            this.pnlWizard.Name = "pnlWizard";
            this.pnlWizard.Size = new System.Drawing.Size(996, 697);
            this.pnlWizard.TabIndex = 10;
            // 
            // wizardControl1
            // 
            this.wizardControl1.CancelText = "İptal";
            this.wizardControl1.Controls.Add(this.wpHesapParametreleri);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Controls.Add(this.wpHesapKosullari);
            this.wizardControl1.Controls.Add(this.wpOdemePlani);
            this.wizardControl1.Controls.Add(this.wpTaahhütTaraflari);
            this.wizardControl1.Controls.Add(this.wpAlacakNedenleri);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.FinishText = "&Son";
            this.wizardControl1.HelpText = "&Yardım";
            this.wizardControl1.Location = new System.Drawing.Point(2, 2);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "&İleri >";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.wpAlacakNedenleri,
            this.wpTaahhütTaraflari,
            this.wpHesapParametreleri,
            this.wpHesapKosullari,
            this.wpOdemePlani,
            this.completionWizardPage1});
            this.wizardControl1.PreviousText = "< &Geri";
            this.wizardControl1.Size = new System.Drawing.Size(992, 693);
            this.wizardControl1.Text = "Geri";
            this.wizardControl1.WizardStyle = DevExpress.XtraWizard.WizardStyle.WizardAero;
            this.wizardControl1.SelectedPageChanging += new DevExpress.XtraWizard.WizardPageChangingEventHandler(this.wizardControl1_SelectedPageChanging);
            // 
            // wpHesapParametreleri
            // 
            this.wpHesapParametreleri.Controls.Add(this.txtFaizOrani);
            this.wpHesapParametreleri.Controls.Add(this.linkLabel2);
            this.wpHesapParametreleri.Controls.Add(this.labelControl29);
            this.wpHesapParametreleri.Controls.Add(this.ceToplamlarAsilAlacak);
            this.wpHesapParametreleri.Controls.Add(this.simpleButton3);
            this.wpHesapParametreleri.Controls.Add(this.dateTaksitlerBaslasin);
            this.wpHesapParametreleri.Controls.Add(this.ceGayriNakit);
            this.wpHesapParametreleri.Controls.Add(this.panelParametreler);
            this.wpHesapParametreleri.Controls.Add(this.labelControl5);
            this.wpHesapParametreleri.Controls.Add(this.labelControl6);
            this.wpHesapParametreleri.Controls.Add(this.lueFaizSecenekleri);
            this.wpHesapParametreleri.Controls.Add(this.popupContainerControl1);
            this.wpHesapParametreleri.Name = "wpHesapParametreleri";
            this.wpHesapParametreleri.Size = new System.Drawing.Size(932, 531);
            this.wpHesapParametreleri.Text = "Hesap Parametreleri";
            // 
            // txtFaizOrani
            // 
            this.txtFaizOrani.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFaizOrani.Location = new System.Drawing.Point(467, 364);
            this.txtFaizOrani.MenuManager = this.ribbonControl1;
            this.txtFaizOrani.Name = "txtFaizOrani";
            this.txtFaizOrani.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtFaizOrani.Size = new System.Drawing.Size(56, 20);
            this.txtFaizOrani.TabIndex = 31;
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.ForeColor = System.Drawing.Color.Blue;
            this.linkLabel2.Location = new System.Drawing.Point(535, 367);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(102, 13);
            this.linkLabel2.TabIndex = 30;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = " Faiz Oranını Uygula";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // labelControl29
            // 
            this.labelControl29.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl29.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl29.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl29.LineColor = System.Drawing.Color.Transparent;
            this.labelControl29.Location = new System.Drawing.Point(406, 367);
            this.labelControl29.Name = "labelControl29";
            this.labelControl29.Size = new System.Drawing.Size(55, 13);
            this.labelControl29.TabIndex = 29;
            this.labelControl29.Text = "Alacaklara  ";
            // 
            // ceToplamlarAsilAlacak
            // 
            this.ceToplamlarAsilAlacak.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ceToplamlarAsilAlacak.Location = new System.Drawing.Point(404, 313);
            this.ceToplamlarAsilAlacak.MenuManager = this.ribbonControl1;
            this.ceToplamlarAsilAlacak.Name = "ceToplamlarAsilAlacak";
            this.ceToplamlarAsilAlacak.Properties.Caption = "Masraf ve faizler asıl alacağa dahil edilsin";
            this.ceToplamlarAsilAlacak.Size = new System.Drawing.Size(254, 19);
            this.ceToplamlarAsilAlacak.TabIndex = 27;
            this.ceToplamlarAsilAlacak.CheckedChanged += new System.EventHandler(this.ceToplamlarAsilAlacak_CheckedChanged);
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Controls.Add(this.panelControl4);
            this.completionWizardPage1.FinishText = "Simülasyon işlemi başarıyla tamamlandı. İsterseniz yapılan değişiklikleri kaydede" +
    "bilirsiniz.";
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.ProceedText = "Sihirbazı kapatmak için Son\'a tıklayın.";
            this.completionWizardPage1.Size = new System.Drawing.Size(932, 531);
            this.completionWizardPage1.Text = "Simülasyon işlemi tamamlandı";
            // 
            // panelControl4
            // 
            this.panelControl4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelControl4.Controls.Add(this.radioGroup1);
            this.panelControl4.Controls.Add(this.simpleButton30);
            this.panelControl4.Controls.Add(this.simpleButton32);
            this.panelControl4.Controls.Add(this.simpleButton2);
            this.panelControl4.Controls.Add(this.simpleButton31);
            this.panelControl4.Controls.Add(this.simpleButton29);
            this.panelControl4.Location = new System.Drawing.Point(228, 108);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(458, 301);
            this.panelControl4.TabIndex = 30;
            // 
            // radioGroup1
            // 
            this.radioGroup1.EditValue = 0;
            this.radioGroup1.Location = new System.Drawing.Point(88, 56);
            this.radioGroup1.MenuManager = this.ribbonControl1;
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Resmi Taahhüt"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Protokol")});
            this.radioGroup1.Size = new System.Drawing.Size(283, 33);
            this.radioGroup1.TabIndex = 31;
            // 
            // simpleButton30
            // 
            this.simpleButton30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton30.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton30.Image")));
            this.simpleButton30.Location = new System.Drawing.Point(123, 129);
            this.simpleButton30.Name = "simpleButton30";
            this.simpleButton30.Size = new System.Drawing.Size(75, 23);
            this.simpleButton30.TabIndex = 27;
            this.simpleButton30.Text = "Excel";
            this.simpleButton30.Click += new System.EventHandler(this.simpleButton30_Click);
            // 
            // simpleButton32
            // 
            this.simpleButton32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton32.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton32.Image")));
            this.simpleButton32.Location = new System.Drawing.Point(123, 168);
            this.simpleButton32.Name = "simpleButton32";
            this.simpleButton32.Size = new System.Drawing.Size(75, 23);
            this.simpleButton32.TabIndex = 29;
            this.simpleButton32.Text = "Word";
            this.simpleButton32.Click += new System.EventHandler(this.simpleButton32_Click);
            // 
            // simpleButton31
            // 
            this.simpleButton31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton31.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton31.Image")));
            this.simpleButton31.Location = new System.Drawing.Point(123, 209);
            this.simpleButton31.Name = "simpleButton31";
            this.simpleButton31.Size = new System.Drawing.Size(75, 23);
            this.simpleButton31.TabIndex = 28;
            this.simpleButton31.Text = "Pdf";
            this.simpleButton31.Click += new System.EventHandler(this.simpleButton31_Click);
            // 
            // simpleButton29
            // 
            this.simpleButton29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton29.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton29.Image")));
            this.simpleButton29.Location = new System.Drawing.Point(123, 247);
            this.simpleButton29.Name = "simpleButton29";
            this.simpleButton29.Size = new System.Drawing.Size(75, 23);
            this.simpleButton29.TabIndex = 26;
            this.simpleButton29.Text = "Önizleme";
            this.simpleButton29.Click += new System.EventHandler(this.simpleButton29_Click);
            // 
            // wpHesapKosullari
            // 
            this.wpHesapKosullari.Controls.Add(this.chKesitTarihiKullan);
            this.wpHesapKosullari.Controls.Add(this.labelControl34);
            this.wpHesapKosullari.Controls.Add(this.groupControl1);
            this.wpHesapKosullari.Controls.Add(this.btnHesapla);
            this.wpHesapKosullari.Controls.Add(this.dateSimulasyonHesapTarihi);
            this.wpHesapKosullari.Controls.Add(this.panelControl2);
            this.wpHesapKosullari.Controls.Add(this.btnEkle);
            this.wpHesapKosullari.Controls.Add(this.listBoxControl1);
            this.wpHesapKosullari.Controls.Add(this.labelControl7);
            this.wpHesapKosullari.Name = "wpHesapKosullari";
            this.wpHesapKosullari.Size = new System.Drawing.Size(932, 531);
            this.wpHesapKosullari.Text = "Hesap Koşulları";
            // 
            // chKesitTarihiKullan
            // 
            this.chKesitTarihiKullan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chKesitTarihiKullan.EditValue = true;
            this.chKesitTarihiKullan.Location = new System.Drawing.Point(367, 13);
            this.chKesitTarihiKullan.Name = "chKesitTarihiKullan";
            this.chKesitTarihiKullan.Properties.Caption = "Kesit Tarihi Kullan";
            this.chKesitTarihiKullan.Size = new System.Drawing.Size(113, 19);
            this.chKesitTarihiKullan.TabIndex = 28;
            this.chKesitTarihiKullan.CheckedChanged += new System.EventHandler(this.chKesitTarihiKullan_CheckedChanged);
            // 
            // labelControl34
            // 
            this.labelControl34.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl34.Location = new System.Drawing.Point(68, 15);
            this.labelControl34.Name = "labelControl34";
            this.labelControl34.Size = new System.Drawing.Size(85, 13);
            this.labelControl34.TabIndex = 27;
            this.labelControl34.Text = "Hesap Kesit Tarihi";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupControl1.Controls.Add(this.lblSonOdemeBakiye);
            this.groupControl1.Controls.Add(this.lblSonOdemeText);
            this.groupControl1.Controls.Add(this.lblToplamOdeme);
            this.groupControl1.Controls.Add(this.labelControl32);
            this.groupControl1.Controls.Add(this.lblGiderVergisi);
            this.groupControl1.Controls.Add(this.labelControl39);
            this.groupControl1.Controls.Add(this.lblVekaletUcretineOdenen);
            this.groupControl1.Controls.Add(this.labelControl37);
            this.groupControl1.Controls.Add(this.lblHarcVeMasraflaraOdenen);
            this.groupControl1.Controls.Add(this.labelControl20);
            this.groupControl1.Controls.Add(this.labelControl35);
            this.groupControl1.Controls.Add(this.lblGiderVergisineOdenen);
            this.groupControl1.Controls.Add(this.labelControl33);
            this.groupControl1.Controls.Add(this.labelControl18);
            this.groupControl1.Controls.Add(this.lblDigerAlacaklar);
            this.groupControl1.Controls.Add(this.labelcontrolxxxx);
            this.groupControl1.Controls.Add(this.lblTazminat);
            this.groupControl1.Controls.Add(this.labelControl49);
            this.groupControl1.Controls.Add(this.lblMasraf);
            this.groupControl1.Controls.Add(this.labelControl36);
            this.groupControl1.Controls.Add(this.lblVekaletUcreti);
            this.groupControl1.Controls.Add(this.labelControl27);
            this.groupControl1.Controls.Add(this.lblHarclar);
            this.groupControl1.Controls.Add(this.labelControl28);
            this.groupControl1.Controls.Add(this.lblFaizTutari);
            this.groupControl1.Controls.Add(this.labelControl26);
            this.groupControl1.Controls.Add(this.lblAsilAlacak);
            this.groupControl1.Controls.Add(this.labelControl25);
            this.groupControl1.Controls.Add(this.lblOrtFaizOrani);
            this.groupControl1.Controls.Add(this.labelControl22);
            this.groupControl1.Controls.Add(this.lblBakiye);
            this.groupControl1.Controls.Add(this.labelControl24);
            this.groupControl1.Controls.Add(this.labelControl23);
            this.groupControl1.Controls.Add(this.lblFaizeOdenen);
            this.groupControl1.Controls.Add(this.labelControl21);
            this.groupControl1.Controls.Add(this.lblAnaparayaOdenen);
            this.groupControl1.Controls.Add(this.labelControl19);
            this.groupControl1.Controls.Add(this.lblToplamTutar);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Location = new System.Drawing.Point(503, 49);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(376, 474);
            this.groupControl1.TabIndex = 25;
            this.groupControl1.Text = "Hesap Detayları";
            // 
            // lblSonOdemeBakiye
            // 
            this.lblSonOdemeBakiye.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblSonOdemeBakiye.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSonOdemeBakiye.Location = new System.Drawing.Point(221, 366);
            this.lblSonOdemeBakiye.Name = "lblSonOdemeBakiye";
            this.lblSonOdemeBakiye.Size = new System.Drawing.Size(117, 13);
            this.lblSonOdemeBakiye.TabIndex = 33;
            this.lblSonOdemeBakiye.Text = "0 TL";
            this.lblSonOdemeBakiye.Visible = false;
            // 
            // lblSonOdemeText
            // 
            this.lblSonOdemeText.Location = new System.Drawing.Point(30, 366);
            this.lblSonOdemeText.Name = "lblSonOdemeText";
            this.lblSonOdemeText.Size = new System.Drawing.Size(156, 13);
            this.lblSonOdemeText.TabIndex = 32;
            this.lblSonOdemeText.Text = "Son Ödeme Tarihine Göre Bakiye";
            this.lblSonOdemeText.Visible = false;
            // 
            // lblToplamOdeme
            // 
            this.lblToplamOdeme.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblToplamOdeme.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblToplamOdeme.Location = new System.Drawing.Point(221, 326);
            this.lblToplamOdeme.Name = "lblToplamOdeme";
            this.lblToplamOdeme.Size = new System.Drawing.Size(117, 13);
            this.lblToplamOdeme.TabIndex = 31;
            this.lblToplamOdeme.Text = "0 TL";
            // 
            // labelControl32
            // 
            this.labelControl32.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl32.Location = new System.Drawing.Point(221, 331);
            this.labelControl32.Name = "labelControl32";
            this.labelControl32.Size = new System.Drawing.Size(144, 18);
            this.labelControl32.TabIndex = 30;
            this.labelControl32.Text = "________________________";
            // 
            // lblGiderVergisi
            // 
            this.lblGiderVergisi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblGiderVergisi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblGiderVergisi.Location = new System.Drawing.Point(221, 63);
            this.lblGiderVergisi.Name = "lblGiderVergisi";
            this.lblGiderVergisi.Size = new System.Drawing.Size(117, 13);
            this.lblGiderVergisi.TabIndex = 29;
            this.lblGiderVergisi.Text = "0 TL";
            // 
            // labelControl39
            // 
            this.labelControl39.Location = new System.Drawing.Point(30, 63);
            this.labelControl39.Name = "labelControl39";
            this.labelControl39.Size = new System.Drawing.Size(59, 13);
            this.labelControl39.TabIndex = 28;
            this.labelControl39.Text = "Gider Vergisi";
            // 
            // lblVekaletUcretineOdenen
            // 
            this.lblVekaletUcretineOdenen.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblVekaletUcretineOdenen.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblVekaletUcretineOdenen.Location = new System.Drawing.Point(221, 293);
            this.lblVekaletUcretineOdenen.Name = "lblVekaletUcretineOdenen";
            this.lblVekaletUcretineOdenen.Size = new System.Drawing.Size(117, 13);
            this.lblVekaletUcretineOdenen.TabIndex = 27;
            this.lblVekaletUcretineOdenen.Text = "0 TL";
            // 
            // labelControl37
            // 
            this.labelControl37.Location = new System.Drawing.Point(30, 293);
            this.labelControl37.Name = "labelControl37";
            this.labelControl37.Size = new System.Drawing.Size(119, 13);
            this.labelControl37.TabIndex = 26;
            this.labelControl37.Text = "Vekalet Ücretine Ödenen";
            // 
            // lblHarcVeMasraflaraOdenen
            // 
            this.lblHarcVeMasraflaraOdenen.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblHarcVeMasraflaraOdenen.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHarcVeMasraflaraOdenen.Location = new System.Drawing.Point(221, 274);
            this.lblHarcVeMasraflaraOdenen.Name = "lblHarcVeMasraflaraOdenen";
            this.lblHarcVeMasraflaraOdenen.Size = new System.Drawing.Size(117, 13);
            this.lblHarcVeMasraflaraOdenen.TabIndex = 25;
            this.lblHarcVeMasraflaraOdenen.Text = "0 TL";
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(30, 326);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(71, 13);
            this.labelControl20.TabIndex = 9;
            this.labelControl20.Text = "Toplam Ödeme";
            // 
            // labelControl35
            // 
            this.labelControl35.Location = new System.Drawing.Point(30, 274);
            this.labelControl35.Name = "labelControl35";
            this.labelControl35.Size = new System.Drawing.Size(132, 13);
            this.labelControl35.TabIndex = 24;
            this.labelControl35.Text = "Harç ve Masraflara Ödenen";
            // 
            // lblGiderVergisineOdenen
            // 
            this.lblGiderVergisineOdenen.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblGiderVergisineOdenen.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblGiderVergisineOdenen.Location = new System.Drawing.Point(221, 255);
            this.lblGiderVergisineOdenen.Name = "lblGiderVergisineOdenen";
            this.lblGiderVergisineOdenen.Size = new System.Drawing.Size(117, 13);
            this.lblGiderVergisineOdenen.TabIndex = 23;
            this.lblGiderVergisineOdenen.Text = "0 TL";
            // 
            // labelControl33
            // 
            this.labelControl33.Location = new System.Drawing.Point(30, 255);
            this.labelControl33.Name = "labelControl33";
            this.labelControl33.Size = new System.Drawing.Size(112, 13);
            this.labelControl33.TabIndex = 22;
            this.labelControl33.Text = "Gider Vergisine Ödenen";
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(221, 169);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(145, 13);
            this.labelControl18.TabIndex = 21;
            this.labelControl18.Text = "________________________";
            // 
            // lblDigerAlacaklar
            // 
            this.lblDigerAlacaklar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblDigerAlacaklar.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDigerAlacaklar.Location = new System.Drawing.Point(221, 155);
            this.lblDigerAlacaklar.Name = "lblDigerAlacaklar";
            this.lblDigerAlacaklar.Size = new System.Drawing.Size(117, 13);
            this.lblDigerAlacaklar.TabIndex = 20;
            this.lblDigerAlacaklar.Text = "0 TL";
            // 
            // labelcontrolxxxx
            // 
            this.labelcontrolxxxx.Location = new System.Drawing.Point(30, 155);
            this.labelcontrolxxxx.Name = "labelcontrolxxxx";
            this.labelcontrolxxxx.Size = new System.Drawing.Size(71, 13);
            this.labelcontrolxxxx.TabIndex = 19;
            this.labelcontrolxxxx.Text = "Diğer Alacaklar";
            // 
            // lblTazminat
            // 
            this.lblTazminat.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTazminat.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTazminat.Location = new System.Drawing.Point(221, 136);
            this.lblTazminat.Name = "lblTazminat";
            this.lblTazminat.Size = new System.Drawing.Size(117, 13);
            this.lblTazminat.TabIndex = 20;
            this.lblTazminat.Text = "0 TL";
            // 
            // labelControl49
            // 
            this.labelControl49.Location = new System.Drawing.Point(30, 136);
            this.labelControl49.Name = "labelControl49";
            this.labelControl49.Size = new System.Drawing.Size(43, 13);
            this.labelControl49.TabIndex = 19;
            this.labelControl49.Text = "Tazminat";
            // 
            // lblMasraf
            // 
            this.lblMasraf.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblMasraf.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMasraf.Location = new System.Drawing.Point(221, 117);
            this.lblMasraf.Name = "lblMasraf";
            this.lblMasraf.Size = new System.Drawing.Size(117, 13);
            this.lblMasraf.TabIndex = 20;
            this.lblMasraf.Text = "0 TL";
            // 
            // labelControl36
            // 
            this.labelControl36.Location = new System.Drawing.Point(30, 117);
            this.labelControl36.Name = "labelControl36";
            this.labelControl36.Size = new System.Drawing.Size(34, 13);
            this.labelControl36.TabIndex = 19;
            this.labelControl36.Text = "Masraf";
            // 
            // lblVekaletUcreti
            // 
            this.lblVekaletUcreti.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblVekaletUcreti.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblVekaletUcreti.Location = new System.Drawing.Point(221, 98);
            this.lblVekaletUcreti.Name = "lblVekaletUcreti";
            this.lblVekaletUcreti.Size = new System.Drawing.Size(117, 13);
            this.lblVekaletUcreti.TabIndex = 20;
            this.lblVekaletUcreti.Text = "0 TL";
            // 
            // labelControl27
            // 
            this.labelControl27.Location = new System.Drawing.Point(30, 98);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(66, 13);
            this.labelControl27.TabIndex = 19;
            this.labelControl27.Text = "Vekalet Ücreti";
            // 
            // lblHarclar
            // 
            this.lblHarclar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblHarclar.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHarclar.Location = new System.Drawing.Point(221, 79);
            this.lblHarclar.Name = "lblHarclar";
            this.lblHarclar.Size = new System.Drawing.Size(117, 13);
            this.lblHarclar.TabIndex = 18;
            this.lblHarclar.Text = "0 TL";
            // 
            // labelControl28
            // 
            this.labelControl28.Location = new System.Drawing.Point(30, 79);
            this.labelControl28.Name = "labelControl28";
            this.labelControl28.Size = new System.Drawing.Size(22, 13);
            this.labelControl28.TabIndex = 17;
            this.labelControl28.Text = "Harç";
            // 
            // lblFaizTutari
            // 
            this.lblFaizTutari.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblFaizTutari.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFaizTutari.Location = new System.Drawing.Point(221, 44);
            this.lblFaizTutari.Name = "lblFaizTutari";
            this.lblFaizTutari.Size = new System.Drawing.Size(117, 13);
            this.lblFaizTutari.TabIndex = 16;
            this.lblFaizTutari.Text = "0 TL";
            // 
            // labelControl26
            // 
            this.labelControl26.Location = new System.Drawing.Point(30, 44);
            this.labelControl26.Name = "labelControl26";
            this.labelControl26.Size = new System.Drawing.Size(182, 13);
            this.labelControl26.TabIndex = 15;
            this.labelControl26.Text = "Ödeme Tarihine Göre Hesaplanan Faiz";
            // 
            // lblAsilAlacak
            // 
            this.lblAsilAlacak.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblAsilAlacak.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAsilAlacak.Location = new System.Drawing.Point(221, 25);
            this.lblAsilAlacak.Name = "lblAsilAlacak";
            this.lblAsilAlacak.Size = new System.Drawing.Size(117, 13);
            this.lblAsilAlacak.TabIndex = 14;
            this.lblAsilAlacak.Text = "0 TL";
            // 
            // labelControl25
            // 
            this.labelControl25.Location = new System.Drawing.Point(30, 25);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new System.Drawing.Size(50, 13);
            this.labelControl25.TabIndex = 13;
            this.labelControl25.Text = "Asıl Alacak";
            // 
            // lblOrtFaizOrani
            // 
            this.lblOrtFaizOrani.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblOrtFaizOrani.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblOrtFaizOrani.Location = new System.Drawing.Point(221, 385);
            this.lblOrtFaizOrani.Name = "lblOrtFaizOrani";
            this.lblOrtFaizOrani.Size = new System.Drawing.Size(117, 13);
            this.lblOrtFaizOrani.TabIndex = 12;
            this.lblOrtFaizOrani.Text = "% 0";
            // 
            // labelControl22
            // 
            this.labelControl22.Location = new System.Drawing.Point(30, 385);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(95, 13);
            this.labelControl22.TabIndex = 11;
            this.labelControl22.Text = "Ortalama Faiz Oranı";
            // 
            // lblBakiye
            // 
            this.lblBakiye.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBakiye.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBakiye.Location = new System.Drawing.Point(221, 347);
            this.lblBakiye.Name = "lblBakiye";
            this.lblBakiye.Size = new System.Drawing.Size(117, 13);
            this.lblBakiye.TabIndex = 8;
            this.lblBakiye.Text = "0 TL";
            // 
            // labelControl24
            // 
            this.labelControl24.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl24.Location = new System.Drawing.Point(221, 302);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(144, 18);
            this.labelControl24.TabIndex = 7;
            this.labelControl24.Text = "________________________";
            // 
            // labelControl23
            // 
            this.labelControl23.Location = new System.Drawing.Point(30, 347);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(31, 13);
            this.labelControl23.TabIndex = 6;
            this.labelControl23.Text = "Bakiye";
            // 
            // lblFaizeOdenen
            // 
            this.lblFaizeOdenen.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblFaizeOdenen.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFaizeOdenen.Location = new System.Drawing.Point(221, 236);
            this.lblFaizeOdenen.Name = "lblFaizeOdenen";
            this.lblFaizeOdenen.Size = new System.Drawing.Size(117, 13);
            this.lblFaizeOdenen.TabIndex = 5;
            this.lblFaizeOdenen.Text = "0 TL";
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(30, 236);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(66, 13);
            this.labelControl21.TabIndex = 4;
            this.labelControl21.Text = "Faize Ödenen";
            // 
            // lblAnaparayaOdenen
            // 
            this.lblAnaparayaOdenen.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblAnaparayaOdenen.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAnaparayaOdenen.Location = new System.Drawing.Point(221, 217);
            this.lblAnaparayaOdenen.Name = "lblAnaparayaOdenen";
            this.lblAnaparayaOdenen.Size = new System.Drawing.Size(117, 13);
            this.lblAnaparayaOdenen.TabIndex = 3;
            this.lblAnaparayaOdenen.Text = "0 TL";
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(30, 217);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(94, 13);
            this.labelControl19.TabIndex = 2;
            this.labelControl19.Text = "Anaparaya Ödenen";
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblToplamTutar.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblToplamTutar.Location = new System.Drawing.Point(221, 188);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(117, 13);
            this.lblToplamTutar.TabIndex = 1;
            this.lblToplamTutar.Text = "0 TL";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(30, 188);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(63, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Toplam Tutar";
            // 
            // dateSimulasyonHesapTarihi
            // 
            this.dateSimulasyonHesapTarihi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateSimulasyonHesapTarihi.EditValue = null;
            this.dateSimulasyonHesapTarihi.Location = new System.Drawing.Point(176, 12);
            this.dateSimulasyonHesapTarihi.Name = "dateSimulasyonHesapTarihi";
            this.dateSimulasyonHesapTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateSimulasyonHesapTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateSimulasyonHesapTarihi.Size = new System.Drawing.Size(168, 20);
            this.dateSimulasyonHesapTarihi.TabIndex = 26;
            this.dateSimulasyonHesapTarihi.EditValueChanged += new System.EventHandler(this.dateSonHesapTarihi_EditValueChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelControl2.Controls.Add(this.m5_lueOdemeDoviz);
            this.panelControl2.Controls.Add(this.m5_spinOdeme);
            this.panelControl2.Controls.Add(this.m5_deTarih);
            this.panelControl2.Controls.Add(this.m4_spinOdeme);
            this.panelControl2.Controls.Add(this.m4_lueOdemeDovizId);
            this.panelControl2.Controls.Add(this.m3_spinAy);
            this.panelControl2.Controls.Add(this.m3_spinGun);
            this.panelControl2.Controls.Add(this.m4_spinGun);
            this.panelControl2.Controls.Add(this.m4_spinAy);
            this.panelControl2.Controls.Add(this.m2_lueOdemeDovizId);
            this.panelControl2.Controls.Add(this.m2_spinOdeme);
            this.panelControl2.Controls.Add(this.m2_spinAy);
            this.panelControl2.Controls.Add(this.m2_spinGun);
            this.panelControl2.Controls.Add(this.m1_lueOdemeDovizId);
            this.panelControl2.Controls.Add(this.m1_spinOdeme);
            this.panelControl2.Controls.Add(this.m1_spinGun);
            this.panelControl2.Controls.Add(this.rgKosullar);
            this.panelControl2.Location = new System.Drawing.Point(57, 49);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(448, 144);
            this.panelControl2.TabIndex = 13;
            // 
            // wpOdemePlani
            // 
            this.wpOdemePlani.Controls.Add(this.xtraTabControl1);
            this.wpOdemePlani.Name = "wpOdemePlani";
            this.wpOdemePlani.Size = new System.Drawing.Size(932, 531);
            this.wpOdemePlani.Text = "Ödeme Planı";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(932, 531);
            this.xtraTabControl1.TabIndex = 3;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.splitContainerControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(926, 503);
            this.xtraTabPage1.Text = "Ödeme Planı (Genel)";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcOdemePlani);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcChildOdemePlan);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(926, 503);
            this.splitContainerControl1.SplitterPosition = 254;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcChildOdemePlan
            // 
            this.gcChildOdemePlan.CustomButtonlarGorunmesin = false;
            this.gcChildOdemePlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcChildOdemePlan.DoNotExtendEmbedNavigator = false;
            this.gcChildOdemePlan.FilterText = null;
            this.gcChildOdemePlan.FilterValue = null;
            this.gcChildOdemePlan.GridlerDuzenlenebilir = true;
            this.gcChildOdemePlan.GridsFilterControl = null;
            this.gcChildOdemePlan.Location = new System.Drawing.Point(0, 0);
            this.gcChildOdemePlan.MainView = this.gwChildOdemePlan;
            this.gcChildOdemePlan.MenuManager = this.ribbonControl1;
            this.gcChildOdemePlan.MyGridStyle = null;
            this.gcChildOdemePlan.Name = "gcChildOdemePlan";
            this.gcChildOdemePlan.ShowRowNumbers = false;
            this.gcChildOdemePlan.SilmeKaldirilsin = false;
            this.gcChildOdemePlan.Size = new System.Drawing.Size(926, 244);
            this.gcChildOdemePlan.TabIndex = 0;
            this.gcChildOdemePlan.TemizleKaldirGorunsunmu = false;
            this.gcChildOdemePlan.UniqueId = "06373641-9058-4cc6-999d-79df67e69b44";
            this.gcChildOdemePlan.UseEmbeddedNavigator = true;
            this.gcChildOdemePlan.UseHyperDragDrop = false;
            this.gcChildOdemePlan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwChildOdemePlan});
            // 
            // gwChildOdemePlan
            // 
            this.gwChildOdemePlan.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2});
            this.gwChildOdemePlan.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colFOY_TARAF_ID_2,
            this.colTARIH_2,
            this.colBORC_TUTARI_2,
            this.colBORC_TUTARI_DOVIZ_ID_2,
            this.gridColumn13_2,
            this.gridColumn14_2,
            this.gridColumn15_2,
            this.gridColumn16_2,
            this.gridColumn17_2,
            this.gridColumn18_2,
            this.colODEME_2,
            this.colODEME_DOVIZ_ID_2,
            this.colBAKIYE_2,
            this.colBAKIYE_DOVIZ_ID_2,
            this.colGUN_2,
            this.colFAIZ_TIP_ID_2,
            this.colFAIZ_ORAN_2,
            this.colDEVRE_FAIZI_2,
            this.colBSMV_2,
            this.colTOPLAM_FAIZ_2,
            this.colDEVRE_FAIZI_DOVIZ_ID_2});
            this.gwChildOdemePlan.GridControl = this.gcChildOdemePlan;
            this.gwChildOdemePlan.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BORC_TUTARI", this.colBORC_TUTARI_2, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BORC_TUTARI_DOVIZ_ID", this.colBORC_TUTARI_DOVIZ_ID_2, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME", this.colODEME_2, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_DOVIZ_ID", this.colODEME_DOVIZ_ID_2, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BAKIYE", this.colBAKIYE_2, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BAKIYE_DOVIZ_ID", this.colBAKIYE_DOVIZ_ID_2, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DEVRE_FAIZI", this.colDEVRE_FAIZI_2, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DEVRE_FAIZI_DOVIZ_ID", this.colDEVRE_FAIZI_DOVIZ_ID_2, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BORC_TUTARI", this.colBORC_TUTARI_2, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BORC_TUTARI_DOVIZ_ID", this.colBORC_TUTARI_DOVIZ_ID_2, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME", this.colODEME_2, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_DOVIZ_ID", this.colODEME_DOVIZ_ID_2, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BAKIYE", this.colBAKIYE_2, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BAKIYE_DOVIZ_ID", this.colBAKIYE_DOVIZ_ID_2, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DEVRE_FAIZI", this.colDEVRE_FAIZI_2, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DEVRE_FAIZI_DOVIZ_ID", this.colDEVRE_FAIZI_DOVIZ_ID_2, "{0}")});
            this.gwChildOdemePlan.IndicatorWidth = 20;
            this.gwChildOdemePlan.Name = "gwChildOdemePlan";
            this.gwChildOdemePlan.OptionsView.ColumnAutoWidth = false;
            this.gwChildOdemePlan.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gwChildOdemePlan_CustomColumnDisplayText);
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Ödemelerin Alacak Nedenlerin Göre Dağılımı";
            this.gridBand2.Columns.Add(this.colFOY_TARAF_ID_2);
            this.gridBand2.Columns.Add(this.colTARIH_2);
            this.gridBand2.Columns.Add(this.colBORC_TUTARI_2);
            this.gridBand2.Columns.Add(this.colBORC_TUTARI_DOVIZ_ID_2);
            this.gridBand2.Columns.Add(this.gridColumn13_2);
            this.gridBand2.Columns.Add(this.gridColumn14_2);
            this.gridBand2.Columns.Add(this.gridColumn15_2);
            this.gridBand2.Columns.Add(this.gridColumn16_2);
            this.gridBand2.Columns.Add(this.gridColumn17_2);
            this.gridBand2.Columns.Add(this.gridColumn18_2);
            this.gridBand2.Columns.Add(this.colODEME_2);
            this.gridBand2.Columns.Add(this.colODEME_DOVIZ_ID_2);
            this.gridBand2.Columns.Add(this.colBAKIYE_2);
            this.gridBand2.Columns.Add(this.colBAKIYE_DOVIZ_ID_2);
            this.gridBand2.Columns.Add(this.colGUN_2);
            this.gridBand2.Columns.Add(this.colFAIZ_TIP_ID_2);
            this.gridBand2.Columns.Add(this.colFAIZ_ORAN_2);
            this.gridBand2.Columns.Add(this.colDEVRE_FAIZI_2);
            this.gridBand2.Columns.Add(this.colBSMV_2);
            this.gridBand2.Columns.Add(this.colTOPLAM_FAIZ_2);
            this.gridBand2.Columns.Add(this.colDEVRE_FAIZI_DOVIZ_ID_2);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 1073;
            // 
            // colFOY_TARAF_ID_2
            // 
            this.colFOY_TARAF_ID_2.Caption = "Taraf";
            this.colFOY_TARAF_ID_2.FieldName = "FOY_TARAF_ID";
            this.colFOY_TARAF_ID_2.Name = "colFOY_TARAF_ID_2";
            // 
            // colTARIH_2
            // 
            this.colTARIH_2.Caption = "Tarih";
            this.colTARIH_2.DisplayFormat.FormatString = "d";
            this.colTARIH_2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTARIH_2.FieldName = "TARIH";
            this.colTARIH_2.Name = "colTARIH_2";
            this.colTARIH_2.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colTARIH_2.Visible = true;
            this.colTARIH_2.Width = 67;
            // 
            // colBORC_TUTARI_2
            // 
            this.colBORC_TUTARI_2.Caption = "Borç Tutarı";
            this.colBORC_TUTARI_2.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colBORC_TUTARI_2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBORC_TUTARI_2.FieldName = "BORC_TUTARI";
            this.colBORC_TUTARI_2.Name = "colBORC_TUTARI_2";
            this.colBORC_TUTARI_2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BORC_TUTARI", "{0:###,###,###,###,##0.00}")});
            this.colBORC_TUTARI_2.ToolTip = "Toplam";
            this.colBORC_TUTARI_2.Visible = true;
            this.colBORC_TUTARI_2.Width = 67;
            // 
            // colBORC_TUTARI_DOVIZ_ID_2
            // 
            this.colBORC_TUTARI_DOVIZ_ID_2.Caption = "Brm";
            this.colBORC_TUTARI_DOVIZ_ID_2.CustomizationCaption = "BORC_TUTARI_DOVIZ_ID";
            this.colBORC_TUTARI_DOVIZ_ID_2.FieldName = "BORC_TUTARI_DOVIZ_ID";
            this.colBORC_TUTARI_DOVIZ_ID_2.Name = "colBORC_TUTARI_DOVIZ_ID_2";
            this.colBORC_TUTARI_DOVIZ_ID_2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BORC_TUTARI_DOVIZ_ID", "{0}")});
            this.colBORC_TUTARI_DOVIZ_ID_2.ToolTip = "BORC TUTARI Birim";
            this.colBORC_TUTARI_DOVIZ_ID_2.Visible = true;
            this.colBORC_TUTARI_DOVIZ_ID_2.Width = 27;
            // 
            // gridColumn13_2
            // 
            this.gridColumn13_2.Caption = "Anaparaya";
            this.gridColumn13_2.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn13_2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13_2.FieldName = "ANA_PARAYA_ODENEN";
            this.gridColumn13_2.Name = "gridColumn13_2";
            this.gridColumn13_2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ANA_PARAYA_ODENEN", "{0:###,###,###,###,##0.00}")});
            this.gridColumn13_2.ToolTip = "Toplam";
            this.gridColumn13_2.Visible = true;
            this.gridColumn13_2.Width = 72;
            // 
            // gridColumn14_2
            // 
            this.gridColumn14_2.Caption = "Brm";
            this.gridColumn14_2.CustomizationCaption = "ANA_PARAYA_ODENEN_DOVIZ_ID";
            this.gridColumn14_2.FieldName = "ANA_PARAYA_ODENEN_DOVIZ_ID";
            this.gridColumn14_2.Name = "gridColumn14_2";
            this.gridColumn14_2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ANA_PARAYA_ODENEN_DOVIZ_ID", "{0}")});
            this.gridColumn14_2.ToolTip = "ANA PARAYA ODENEN Birim";
            this.gridColumn14_2.Visible = true;
            this.gridColumn14_2.Width = 26;
            // 
            // gridColumn15_2
            // 
            this.gridColumn15_2.Caption = "Faize";
            this.gridColumn15_2.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn15_2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn15_2.FieldName = "FAIZE_ODENEN";
            this.gridColumn15_2.Name = "gridColumn15_2";
            this.gridColumn15_2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FAIZE_ODENEN", "{0:###,###,###,###,##0.00}")});
            this.gridColumn15_2.ToolTip = "Toplam";
            this.gridColumn15_2.Visible = true;
            this.gridColumn15_2.Width = 66;
            // 
            // gridColumn16_2
            // 
            this.gridColumn16_2.Caption = "Brm";
            this.gridColumn16_2.CustomizationCaption = "FAIZE_ODENEN_DOVIZ_ID";
            this.gridColumn16_2.FieldName = "FAIZE_ODENEN_DOVIZ_ID";
            this.gridColumn16_2.Name = "gridColumn16_2";
            this.gridColumn16_2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FAIZE_ODENEN_DOVIZ_ID", "{0}")});
            this.gridColumn16_2.ToolTip = "FAIZE ODENEN Birim";
            this.gridColumn16_2.Visible = true;
            this.gridColumn16_2.Width = 26;
            // 
            // gridColumn17_2
            // 
            this.gridColumn17_2.Caption = "Diğer Giderlere";
            this.gridColumn17_2.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn17_2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn17_2.FieldName = "DIGERLERINE_ODENEN";
            this.gridColumn17_2.Name = "gridColumn17_2";
            this.gridColumn17_2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGERLERINE_ODENEN", "{0:###,###,###,###,##0.00}")});
            this.gridColumn17_2.ToolTip = "Toplam";
            this.gridColumn17_2.Visible = true;
            this.gridColumn17_2.Width = 89;
            // 
            // gridColumn18_2
            // 
            this.gridColumn18_2.Caption = "Brm";
            this.gridColumn18_2.CustomizationCaption = "DIGERLERINE_ODENEN_DOVIZ_ID";
            this.gridColumn18_2.FieldName = "DIGERLERINE_ODENEN_DOVIZ_ID";
            this.gridColumn18_2.Name = "gridColumn18_2";
            this.gridColumn18_2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGERLERINE_ODENEN_DOVIZ_ID", "{0}")});
            this.gridColumn18_2.ToolTip = "DIGERLERINE ODENEN Birim";
            this.gridColumn18_2.Visible = true;
            this.gridColumn18_2.Width = 22;
            // 
            // colODEME_2
            // 
            this.colODEME_2.Caption = "Ödeme";
            this.colODEME_2.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colODEME_2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colODEME_2.FieldName = "ODEME";
            this.colODEME_2.Name = "colODEME_2";
            this.colODEME_2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME", "{0:###,###,###,###,##0.00}")});
            this.colODEME_2.ToolTip = "Toplam";
            this.colODEME_2.Visible = true;
            this.colODEME_2.Width = 60;
            // 
            // colODEME_DOVIZ_ID_2
            // 
            this.colODEME_DOVIZ_ID_2.Caption = "Brm";
            this.colODEME_DOVIZ_ID_2.CustomizationCaption = "ODEME_DOVIZ_ID";
            this.colODEME_DOVIZ_ID_2.FieldName = "ODEME_DOVIZ_ID";
            this.colODEME_DOVIZ_ID_2.Name = "colODEME_DOVIZ_ID_2";
            this.colODEME_DOVIZ_ID_2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_DOVIZ_ID", "{0}")});
            this.colODEME_DOVIZ_ID_2.ToolTip = "ODEME Birim";
            this.colODEME_DOVIZ_ID_2.Visible = true;
            this.colODEME_DOVIZ_ID_2.Width = 22;
            // 
            // colBAKIYE_2
            // 
            this.colBAKIYE_2.Caption = "Bakiye";
            this.colBAKIYE_2.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colBAKIYE_2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBAKIYE_2.FieldName = "BAKIYE";
            this.colBAKIYE_2.Name = "colBAKIYE_2";
            this.colBAKIYE_2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BAKIYE", "{0:###,###,###,###,##0.00}")});
            this.colBAKIYE_2.ToolTip = "Toplam";
            this.colBAKIYE_2.Visible = true;
            this.colBAKIYE_2.Width = 60;
            // 
            // colBAKIYE_DOVIZ_ID_2
            // 
            this.colBAKIYE_DOVIZ_ID_2.Caption = "Brm";
            this.colBAKIYE_DOVIZ_ID_2.CustomizationCaption = "BAKIYE_DOVIZ_ID";
            this.colBAKIYE_DOVIZ_ID_2.FieldName = "BAKIYE_DOVIZ_ID";
            this.colBAKIYE_DOVIZ_ID_2.Name = "colBAKIYE_DOVIZ_ID_2";
            this.colBAKIYE_DOVIZ_ID_2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BAKIYE_DOVIZ_ID", "{0}")});
            this.colBAKIYE_DOVIZ_ID_2.ToolTip = "BAKIYE Birim";
            this.colBAKIYE_DOVIZ_ID_2.Visible = true;
            this.colBAKIYE_DOVIZ_ID_2.Width = 22;
            // 
            // colGUN_2
            // 
            this.colGUN_2.Caption = "Gün";
            this.colGUN_2.FieldName = "GUN";
            this.colGUN_2.Name = "colGUN_2";
            this.colGUN_2.Visible = true;
            this.colGUN_2.Width = 60;
            // 
            // colFAIZ_TIP_ID_2
            // 
            this.colFAIZ_TIP_ID_2.Caption = "Faiz Tipi";
            this.colFAIZ_TIP_ID_2.FieldName = "FAIZ_TIP_ID";
            this.colFAIZ_TIP_ID_2.Name = "colFAIZ_TIP_ID_2";
            this.colFAIZ_TIP_ID_2.Visible = true;
            this.colFAIZ_TIP_ID_2.Width = 60;
            // 
            // colFAIZ_ORAN_2
            // 
            this.colFAIZ_ORAN_2.Caption = "Faiz Oranı";
            this.colFAIZ_ORAN_2.FieldName = "FAIZ_ORAN";
            this.colFAIZ_ORAN_2.Name = "colFAIZ_ORAN_2";
            this.colFAIZ_ORAN_2.Visible = true;
            this.colFAIZ_ORAN_2.Width = 60;
            // 
            // colDEVRE_FAIZI_2
            // 
            this.colDEVRE_FAIZI_2.Caption = "Devre Faizi";
            this.colDEVRE_FAIZI_2.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colDEVRE_FAIZI_2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDEVRE_FAIZI_2.FieldName = "DEVRE_FAIZI";
            this.colDEVRE_FAIZI_2.Name = "colDEVRE_FAIZI_2";
            this.colDEVRE_FAIZI_2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DEVRE_FAIZI", "{0:###,###,###,###,##0.00}")});
            this.colDEVRE_FAIZI_2.ToolTip = "Toplam";
            this.colDEVRE_FAIZI_2.Visible = true;
            this.colDEVRE_FAIZI_2.Width = 60;
            // 
            // colBSMV_2
            // 
            this.colBSMV_2.Caption = "Bsmv Tutarı";
            this.colBSMV_2.Name = "colBSMV_2";
            this.colBSMV_2.Visible = true;
            this.colBSMV_2.Width = 60;
            // 
            // colTOPLAM_FAIZ_2
            // 
            this.colTOPLAM_FAIZ_2.Caption = "Toplam Faiz";
            this.colTOPLAM_FAIZ_2.Name = "colTOPLAM_FAIZ_2";
            this.colTOPLAM_FAIZ_2.Visible = true;
            this.colTOPLAM_FAIZ_2.Width = 60;
            // 
            // colDEVRE_FAIZI_DOVIZ_ID_2
            // 
            this.colDEVRE_FAIZI_DOVIZ_ID_2.Caption = "Brm";
            this.colDEVRE_FAIZI_DOVIZ_ID_2.CustomizationCaption = "DEVRE_FAIZI_DOVIZ_ID";
            this.colDEVRE_FAIZI_DOVIZ_ID_2.FieldName = "DEVRE_FAIZI_DOVIZ_ID";
            this.colDEVRE_FAIZI_DOVIZ_ID_2.Name = "colDEVRE_FAIZI_DOVIZ_ID_2";
            this.colDEVRE_FAIZI_DOVIZ_ID_2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DEVRE_FAIZI_DOVIZ_ID", "{0}")});
            this.colDEVRE_FAIZI_DOVIZ_ID_2.ToolTip = "DEVRE FAIZI Birim";
            this.colDEVRE_FAIZI_DOVIZ_ID_2.Visible = true;
            this.colDEVRE_FAIZI_DOVIZ_ID_2.Width = 87;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gcOdemePlaniDetay);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(926, 503);
            this.xtraTabPage2.Text = "Ödeme Planı (Detaylı)";
            // 
            // gcOdemePlaniDetay
            // 
            this.gcOdemePlaniDetay.CustomButtonlarGorunmesin = false;
            this.gcOdemePlaniDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcOdemePlaniDetay.DoNotExtendEmbedNavigator = false;
            this.gcOdemePlaniDetay.FilterText = null;
            this.gcOdemePlaniDetay.FilterValue = null;
            this.gcOdemePlaniDetay.GridlerDuzenlenebilir = true;
            this.gcOdemePlaniDetay.GridsFilterControl = null;
            this.gcOdemePlaniDetay.Location = new System.Drawing.Point(0, 0);
            this.gcOdemePlaniDetay.MainView = this.gridView6;
            this.gcOdemePlaniDetay.MenuManager = this.ribbonControl1;
            this.gcOdemePlaniDetay.MyGridStyle = null;
            this.gcOdemePlaniDetay.Name = "gcOdemePlaniDetay";
            this.gcOdemePlaniDetay.ShowRowNumbers = false;
            this.gcOdemePlaniDetay.SilmeKaldirilsin = false;
            this.gcOdemePlaniDetay.Size = new System.Drawing.Size(926, 503);
            this.gcOdemePlaniDetay.TabIndex = 0;
            this.gcOdemePlaniDetay.TemizleKaldirGorunsunmu = false;
            this.gcOdemePlaniDetay.UniqueId = "0d530b11-dea9-4fcc-8a44-7a785517d24a";
            this.gcOdemePlaniDetay.UseEmbeddedNavigator = true;
            this.gcOdemePlaniDetay.UseHyperDragDrop = false;
            this.gcOdemePlaniDetay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView6});
            // 
            // gridView6
            // 
            this.gridView6.GridControl = this.gcOdemePlaniDetay;
            this.gridView6.IndicatorWidth = 20;
            this.gridView6.Name = "gridView6";
            // 
            // wpTaahhütTaraflari
            // 
            this.wpTaahhütTaraflari.Controls.Add(this.panelControl1);
            this.wpTaahhütTaraflari.Name = "wpTaahhütTaraflari";
            this.wpTaahhütTaraflari.Size = new System.Drawing.Size(932, 531);
            this.wpTaahhütTaraflari.Text = "Taahhüdün Tarafları";
            // 
            // wpAlacakNedenleri
            // 
            this.wpAlacakNedenleri.Controls.Add(this.gcHariciAlacaklar);
            this.wpAlacakNedenleri.Controls.Add(this.panelControl3);
            this.wpAlacakNedenleri.Name = "wpAlacakNedenleri";
            this.wpAlacakNedenleri.Size = new System.Drawing.Size(932, 531);
            this.wpAlacakNedenleri.Text = "Alacak Girişi";
            // 
            // gcHariciAlacaklar
            // 
            this.gcHariciAlacaklar.DataSource = this.bndHariciAlacakNeden;
            this.gcHariciAlacaklar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHariciAlacaklar.Location = new System.Drawing.Point(0, 0);
            this.gcHariciAlacaklar.MainView = this.gvHariciAlacaklar;
            this.gcHariciAlacaklar.MenuManager = this.ribbonControl1;
            this.gcHariciAlacaklar.Name = "gcHariciAlacaklar";
            this.gcHariciAlacaklar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit3,
            this.rLueDovizId,
            this.repositoryItemSpinEdit2,
            this.repositoryItemLookUpEdit1,
            this.repositoryItemDateEdit1});
            this.gcHariciAlacaklar.Size = new System.Drawing.Size(606, 531);
            this.gcHariciAlacaklar.TabIndex = 4;
            this.gcHariciAlacaklar.UseEmbeddedNavigator = true;
            this.gcHariciAlacaklar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHariciAlacaklar});
            // 
            // bndHariciAlacakNeden
            // 
            this.bndHariciAlacakNeden.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.bndHariciAlacakNeden_AddingNew);
            // 
            // gvHariciAlacaklar
            // 
            this.gvHariciAlacaklar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn5});
            this.gvHariciAlacaklar.GridControl = this.gcHariciAlacaklar;
            this.gvHariciAlacaklar.Name = "gvHariciAlacaklar";
            this.gvHariciAlacaklar.OptionsView.ColumnAutoWidth = false;
            this.gvHariciAlacaklar.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Para Birimi";
            this.gridColumn4.ColumnEdit = this.rLueDovizId;
            this.gridColumn4.FieldName = "TUTAR_DOVIZ_ID";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 119;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tutar";
            this.gridColumn3.ColumnEdit = this.repositoryItemSpinEdit2;
            this.gridColumn3.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "TUTARI";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 126;
            // 
            // repositoryItemSpinEdit2
            // 
            this.repositoryItemSpinEdit2.AutoHeight = false;
            this.repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Temerrüt Tarihi";
            this.gridColumn2.ColumnEdit = this.repositoryItemDateEdit1;
            this.gridColumn2.FieldName = "TEMERRUT_TARIHI";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 110;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "İşlemiş Faiz";
            this.gridColumn1.ColumnEdit = this.repositoryItemSpinEdit2;
            this.gridColumn1.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "ISLEMIS_FAIZ";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 92;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Gider Vergisi";
            this.gridColumn6.ColumnEdit = this.repositoryItemSpinEdit2;
            this.gridColumn6.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "BSMV";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 98;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Faiz Oranı";
            this.gridColumn5.ColumnEdit = this.repositoryItemSpinEdit3;
            this.gridColumn5.FieldName = "TO_UYGULANACAK_FAIZ_ORANI";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 72;
            // 
            // repositoryItemSpinEdit3
            // 
            this.repositoryItemSpinEdit3.AutoHeight = false;
            this.repositoryItemSpinEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit3.Name = "repositoryItemSpinEdit3";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.seHarcVeMasraflar);
            this.panelControl3.Controls.Add(this.seVekaletUcreti);
            this.panelControl3.Controls.Add(this.labelControl31);
            this.panelControl3.Controls.Add(this.labelControl30);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(606, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(326, 531);
            this.panelControl3.TabIndex = 3;
            // 
            // seHarcVeMasraflar
            // 
            this.seHarcVeMasraflar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seHarcVeMasraflar.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seHarcVeMasraflar.Location = new System.Drawing.Point(144, 70);
            this.seHarcVeMasraflar.Name = "seHarcVeMasraflar";
            this.seHarcVeMasraflar.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.seHarcVeMasraflar.Properties.Appearance.Options.UseBackColor = true;
            this.seHarcVeMasraflar.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.seHarcVeMasraflar.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.seHarcVeMasraflar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seHarcVeMasraflar.Size = new System.Drawing.Size(155, 20);
            this.seHarcVeMasraflar.TabIndex = 6;
            // 
            // seVekaletUcreti
            // 
            this.seVekaletUcreti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seVekaletUcreti.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seVekaletUcreti.Location = new System.Drawing.Point(144, 44);
            this.seVekaletUcreti.Name = "seVekaletUcreti";
            this.seVekaletUcreti.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.seVekaletUcreti.Properties.Appearance.Options.UseBackColor = true;
            this.seVekaletUcreti.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.seVekaletUcreti.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.seVekaletUcreti.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seVekaletUcreti.Size = new System.Drawing.Size(155, 20);
            this.seVekaletUcreti.TabIndex = 5;
            // 
            // labelControl31
            // 
            this.labelControl31.Location = new System.Drawing.Point(20, 73);
            this.labelControl31.Name = "labelControl31";
            this.labelControl31.Size = new System.Drawing.Size(85, 13);
            this.labelControl31.TabIndex = 2;
            this.labelControl31.Text = "Harç ve Masraflar";
            // 
            // labelControl30
            // 
            this.labelControl30.Location = new System.Drawing.Point(20, 47);
            this.labelControl30.Name = "labelControl30";
            this.labelControl30.Size = new System.Drawing.Size(66, 13);
            this.labelControl30.TabIndex = 0;
            this.labelControl30.Text = "Vekalet Ücreti";
            // 
            // rLueTaraf
            // 
            this.rLueTaraf.AutoHeight = false;
            this.rLueTaraf.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTaraf.Name = "rLueTaraf";
            // 
            // frmOdemePlani
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(996, 722);
            this.Name = "frmOdemePlani";
            this.Text = "Taahhüt Sihirbazı";
            this.UstMenu = true;
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOdemePlani)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndOdemePlani)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSpinTutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwOdemePlani)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueMudurluk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueMudurlukNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gLueDosyaNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelParametreler)).EndInit();
            this.panelParametreler.ResumeLayout(false);
            this.panelParametreler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbVekaletOtomatikHesapla.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            this.popupContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacakNedenleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndAlacakNeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakNeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSpinPara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSpinOran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bEditTOFaizOrani.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cEditTumAlacaklariSec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit10.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.panelControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit4.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit3.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSimulasyonGruplari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSimulasyonGruplari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueSimuDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSpinSimuPara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBakiyeHarcHesabaDahil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHesapTipi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBirYilKacGun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSonHesapTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSonHesapTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFaizSecenekleri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTaksitlerBaslasin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTaksitlerBaslasin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgKosullar.Properties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceGayriNakit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m5_deTarih.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m5_deTarih.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m1_spinOdeme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m2_lueOdemeDovizId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m2_spinAy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m1_spinGun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m4_spinOdeme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m5_lueOdemeDoviz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m3_spinAy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m2_spinGun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m5_spinOdeme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m4_lueOdemeDovizId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m4_spinGun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m3_spinGun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m2_spinOdeme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m1_lueOdemeDovizId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m4_spinAy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBorclular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBorclular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueBorclu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTaahhutEden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTaahhutKabulEden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceGecerliTaahhut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deKabulTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deKabulTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTebligTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTebligTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTaahhutTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTaahhutTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndSimulastonBirimi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWizard)).EndInit();
            this.pnlWizard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wpHesapParametreleri.ResumeLayout(false);
            this.wpHesapParametreleri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaizOrani.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceToplamlarAsilAlacak.Properties)).EndInit();
            this.completionWizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.wpHesapKosullari.ResumeLayout(false);
            this.wpHesapKosullari.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chKesitTarihiKullan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateSimulasyonHesapTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSimulasyonHesapTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.wpOdemePlani.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcChildOdemePlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwChildOdemePlan)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcOdemePlaniDetay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            this.wpTaahhütTaraflari.ResumeLayout(false);
            this.wpAlacakNedenleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcHariciAlacaklar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndHariciAlacakNeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHariciAlacaklar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seHarcVeMasraflar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seVekaletUcreti.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTaraf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraEditors.RadioGroup rgKosullar;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateSonHesapTarihi;
        private DevExpress.XtraEditors.LookUpEdit lueBirYilKacGun;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lueHesapTipi;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit cbBakiyeHarcHesabaDahil;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit dateTaksitlerBaslasin;
        private DevExpress.XtraEditors.LookUpEdit lueFaizSecenekleri;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.PanelControl panelParametreler;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcOdemePlani;
        private AdimAdimDavaKaydi.Util.compNavBarAutoHeight compNavBarAutoHeight1;
        private DevExpress.XtraEditors.DateEdit m5_deTarih;
        private DevExpress.XtraEditors.SpinEdit m1_spinOdeme;
        private DevExpress.XtraEditors.LookUpEdit m2_lueOdemeDovizId;
        private DevExpress.XtraEditors.SpinEdit m2_spinAy;
        private DevExpress.XtraEditors.SpinEdit m1_spinGun;
        private DevExpress.XtraEditors.SpinEdit m4_spinOdeme;
        private DevExpress.XtraEditors.LookUpEdit m5_lueOdemeDoviz;
        private DevExpress.XtraEditors.SpinEdit m3_spinAy;
        private DevExpress.XtraEditors.SpinEdit m2_spinGun;
        private DevExpress.XtraEditors.SpinEdit m5_spinOdeme;
        private DevExpress.XtraEditors.LookUpEdit m4_lueOdemeDovizId;
        private DevExpress.XtraEditors.SpinEdit m4_spinGun;
        private DevExpress.XtraEditors.SpinEdit m3_spinGun;
        private DevExpress.XtraEditors.SpinEdit m2_spinOdeme;
        private DevExpress.XtraEditors.LookUpEdit m1_lueOdemeDovizId;
        private DevExpress.XtraEditors.SpinEdit m4_spinAy;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow editorRow1;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow multiEditorRow1;
        private DevExpress.XtraEditors.SimpleButton btnHesapla;
        private System.Windows.Forms.ToolStripMenuItem mbtnTumKosullariKaldir;
        private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTaraf;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colICRA_ALACAK_NEDEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colILAM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_KALEM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colEN_SON_FAIZ_HESAPLANMA_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_TAKIPDEN_ONCE_MI;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_ORANI;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_BASLANGIC_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_BITIS_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colGUN_FARKI;
        private DevExpress.XtraGrid.Columns.GridColumn colMATRAH_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colMATRAH_TUTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_TUTARI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_TUTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colBSMV_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colBSMV_TUTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colKKDF_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colKKDF_TUTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colOIV_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colOIV_TUTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colKDV_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colKDV_TUTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colALACAK_NEDEN_TARAF_ID;
        private DevExpress.XtraGrid.Columns.GridColumn ODEME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn ODEME_MIKTAR;
        private DevExpress.XtraGrid.Columns.GridColumn ODEME_MIKTAR_DOVIZ;
        private DevExpress.XtraGrid.Columns.GridColumn ODEME_YERI;
        private DevExpress.XtraGrid.Columns.GridColumn ODEME_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn ODEYEN_CARI;
        private DevExpress.XtraGrid.Columns.GridColumn BORCLU_ADINA_ODEYEN_CARI;
        private DevExpress.XtraGrid.Columns.GridColumn ODENEN_CARI;
        private DevExpress.XtraGrid.Columns.GridColumn ALACAKLI_ADINA_ODENEN_CARI;
        private DevExpress.XtraGrid.Columns.GridColumn ALACAK_NEDEN;
        private DevExpress.XtraGrid.Columns.GridColumn ICRADAN_CEKILME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn IHTIYATI_HACIZDE_MI;
        private DevExpress.XtraGrid.Columns.GridColumn MAAS_HACZINDEN_MI;
        private DevExpress.XtraGrid.Columns.GridColumn KIYMETLI_EVRAK_ODENDI_MI;
        private DevExpress.XtraGrid.Columns.GridColumn KIYMETLI_EVRAK_VADE_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn KIYMETLI_EVRAK_VADESINDE_ODENDI_MI;
        private DevExpress.XtraGrid.Columns.GridColumn ACIKLAMA_;
        private DevExpress.XtraGrid.Columns.GridColumn ODEME_MAHSUP_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_KARSILIK_TUTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_KARSILIK_TUTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colMAHSUP_ALT_KATEGORI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colMAHSUP_KATEGORI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colALACAK_NEDEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn colDAGILIM_TIPI;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.DateEdit deKabulTarihi;
        private DevExpress.XtraEditors.DateEdit deTebligTarihi;
        private DevExpress.XtraEditors.DateEdit deTaahhutTarihi;
        private DevExpress.XtraEditors.CheckEdit ceGecerliTaahhut;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private AdimAdimDavaKaydi.Util.compGridDovizSummary compGridDovizSummary1;
        private AdimAdimDavaKaydi.Util.compGridDovizSummary compGridDovizSummary2;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private AdimAdimDavaKaydi.Util.UcDovizliTutarAlani prToplam;
        private AdimAdimDavaKaydi.Util.UcDovizliTutarAlani prToplamMasraf;
        private AdimAdimDavaKaydi.Util.UcDovizliTutarAlani prVekaletUcreti;
        private AdimAdimDavaKaydi.Util.UcDovizliTutarAlani prBakiyeHarc;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rSpinTutar;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private System.Windows.Forms.BindingSource bndAlacakNeden;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private System.Windows.Forms.BindingSource bndOdemePlani;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn colBORC_TUTARI1;
        private DevExpress.XtraGrid.Columns.GridColumn colBORC_TUTARI_DOVIZ_ID1;
        private DevExpress.XtraGrid.Columns.GridColumn colANA_PARAYA_ODENEN;
        private DevExpress.XtraGrid.Columns.GridColumn colANA_PARAYA_ODENEN_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZE_ODENEN;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZE_ODENEN_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDIGERLERINE_ODENEN;
        private DevExpress.XtraGrid.Columns.GridColumn colDIGERLERINE_ODENEN_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME1;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_DOVIZ_ID1;
        private DevExpress.XtraGrid.Columns.GridColumn colBAKIYE1;
        private DevExpress.XtraGrid.Columns.GridColumn colBAKIYE_DOVIZ_ID1;
        private DevExpress.XtraGrid.Columns.GridColumn colGUN1;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_TIP_ID1;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_ORAN1;
        private DevExpress.XtraGrid.Columns.GridColumn colDEVRE_FAIZI1;
        private DevExpress.XtraGrid.Columns.GridColumn colDEVRE_FAIZI_DOVIZ_ID1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.GridControl gcSimulasyonGruplari;
        private System.Windows.Forms.BindingSource bndSimulastonBirimi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueSimuDoviz;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rSpinSimuPara;
        private DevExpress.XtraEditors.CheckEdit ceGayriNakit;
        private DevExpress.XtraEditors.CheckEdit cbVekaletOtomatikHesapla;
        private DevExpress.XtraEditors.PanelControl pnlWizard;
        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WizardPage wpHesapParametreleri;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraWizard.WizardPage wpHesapKosullari;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraWizard.WizardPage wpOdemePlani;
        private DevExpress.XtraWizard.WizardPage wpTaahhütTaraflari;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit gLueDosyaNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueMudurluk;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueMudurlukNo;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.CheckEdit cEditTumAlacaklariSec;
        private DevExpress.XtraEditors.ButtonEdit bEditTOFaizOrani;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.LinkLabel lBtnFaizOraniUygula;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private AdimAdimDavaKaydi.Util.ExtendedLookUpEdit lueTaahhutKabulEden;
        private AdimAdimDavaKaydi.Util.ExtendedLookUpEdit lueTaahhutEden;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.LabelControl lblFaizeOdenen;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.LabelControl lblAnaparayaOdenen;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl lblToplamTutar;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl lblBakiye;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl lblOrtFaizOrani;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.LabelControl lblHarclar;
        private DevExpress.XtraEditors.LabelControl labelControl28;
        private DevExpress.XtraEditors.LabelControl lblFaizTutari;
        private DevExpress.XtraEditors.LabelControl labelControl26;
        private DevExpress.XtraEditors.LabelControl lblAsilAlacak;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl lblVekaletUcreti;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.CheckEdit ceToplamlarAsilAlacak;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private DevExpress.XtraEditors.LabelControl labelControl29;
        private DevExpress.XtraEditors.TextEdit txtFaizOrani;
        private DevExpress.XtraWizard.WizardPage wpAlacakNedenleri;
        private System.Windows.Forms.BindingSource bndHariciAlacakNeden;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl31;
        private DevExpress.XtraEditors.LabelControl labelControl30;
        private DevExpress.XtraGrid.GridControl gcHariciAlacaklar;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHariciAlacaklar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.SpinEdit seHarcVeMasraflar;
        private DevExpress.XtraEditors.SpinEdit seVekaletUcreti;
        private DevExpress.XtraEditors.LabelControl lblGiderVergisi;
        private DevExpress.XtraEditors.LabelControl labelControl39;
        private DevExpress.XtraEditors.LabelControl lblVekaletUcretineOdenen;
        private DevExpress.XtraEditors.LabelControl labelControl37;
        private DevExpress.XtraEditors.LabelControl lblHarcVeMasraflaraOdenen;
        private DevExpress.XtraEditors.LabelControl labelControl35;
        private DevExpress.XtraEditors.LabelControl lblGiderVergisineOdenen;
        private DevExpress.XtraEditors.LabelControl labelControl33;
        private DevExpress.XtraEditors.LabelControl lblToplamOdeme;
        private DevExpress.XtraEditors.LabelControl labelControl32;
        private DevExpress.XtraEditors.SimpleButton simpleButton32;
        private DevExpress.XtraEditors.SimpleButton simpleButton31;
        private DevExpress.XtraEditors.SimpleButton simpleButton30;
        private DevExpress.XtraEditors.SimpleButton simpleButton29;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gwOdemePlani;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFOY_TARAF_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTARIH;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBORC_TUTARI;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBORC_TUTARI_DOVIZ_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn13;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn14;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn15;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn16;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn17;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn18;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colODEME;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colODEME_DOVIZ_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBAKIYE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBAKIYE_DOVIZ_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGUN;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFAIZ_TIP_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFAIZ_ORAN;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDEVRE_FAIZI;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDEVRE_FAIZI_DOVIZ_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gwChildOdemePlan;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFOY_TARAF_ID_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTARIH_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBORC_TUTARI_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBORC_TUTARI_DOVIZ_ID_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn13_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn14_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn15_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn16_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn17_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn18_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colODEME_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colODEME_DOVIZ_ID_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBAKIYE_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBAKIYE_DOVIZ_ID_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGUN_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFAIZ_TIP_ID_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFAIZ_ORAN_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDEVRE_FAIZI_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBSMV_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTOPLAM_FAIZ_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDEVRE_FAIZI_DOVIZ_ID_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gwSimulasyonGruplari;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSecim;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn27;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTUTAR1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTUTAR_DOVIZ_ID1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFAIZ;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFAIZ_DOVIZ_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDIGER;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDIGER_DOVIZ_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTOPLAM;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTOPLAM_DOVIZ_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colANAPARA;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBSMV_3;
        private DevExpress.XtraEditors.LabelControl lblSonOdemeBakiye;
        private DevExpress.XtraEditors.LabelControl lblSonOdemeText;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.LabelControl labelControl34;
        private DevExpress.XtraEditors.DateEdit dateSimulasyonHesapTarihi;
        private DevExpress.XtraEditors.CheckEdit chKesitTarihiKullan;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.LinkLabel linkLabel8;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private DevExpress.XtraEditors.LabelControl labelControl59;
        private DevExpress.XtraEditors.LabelControl labelControl48;
        private DevExpress.XtraEditors.CheckEdit checkEdit10;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit6;
        private DevExpress.XtraEditors.CheckEdit checkEdit5;
        private DevExpress.XtraEditors.LabelControl labelControl58;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.LabelControl labelControl38;
        private DevExpress.XtraEditors.LabelControl labelControl57;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.CheckEdit checkEdit7;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit3;
        private DevExpress.XtraGrid.GridControl gridControl4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn26;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn27;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn28;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn29;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn30;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn31;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn32;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn33;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn34;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn35;
        private System.Windows.Forms.LinkLabel linkLabel7;
        private AdimAdimDavaKaydi.Util.UcDovizliTutarAlani ucDovizliTutarAlani5;
        private AdimAdimDavaKaydi.Util.UcDovizliTutarAlani ucDovizliTutarAlani6;
        private AdimAdimDavaKaydi.Util.UcDovizliTutarAlani ucDovizliTutarAlani7;
        private AdimAdimDavaKaydi.Util.UcDovizliTutarAlani ucDovizliTutarAlani8;
        private DevExpress.XtraEditors.CheckEdit checkEdit9;
        private DevExpress.XtraEditors.LabelControl labelControl50;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit4;
        private DevExpress.XtraEditors.LabelControl labelControl51;
        private DevExpress.XtraEditors.LabelControl labelControl52;
        private DevExpress.XtraEditors.LabelControl labelControl53;
        private DevExpress.XtraEditors.LabelControl labelControl54;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit5;
        private DevExpress.XtraEditors.LabelControl labelControl55;
        private DevExpress.XtraEditors.LabelControl labelControl56;
        private DevExpress.XtraEditors.DateEdit dateEdit4;
        private DevExpress.XtraEditors.LabelControl labelControl40;
        private DevExpress.XtraEditors.DateEdit dateEdit3;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit2;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn12;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn13;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn14;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn15;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn16;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn17;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn18;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private AdimAdimDavaKaydi.Util.UcDovizliTutarAlani ucDovizliTutarAlani1;
        private AdimAdimDavaKaydi.Util.UcDovizliTutarAlani ucDovizliTutarAlani2;
        private AdimAdimDavaKaydi.Util.UcDovizliTutarAlani ucDovizliTutarAlani3;
        private AdimAdimDavaKaydi.Util.UcDovizliTutarAlani ucDovizliTutarAlani4;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl41;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl42;
        private DevExpress.XtraEditors.LabelControl labelControl43;
        private DevExpress.XtraEditors.LabelControl labelControl44;
        private DevExpress.XtraEditors.LabelControl labelControl45;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl46;
        private DevExpress.XtraEditors.LabelControl labelControl47;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.CheckEdit checkEdit6;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit4;
        private DevExpress.XtraGrid.GridControl gcAlacakNedenleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAlacakNeden;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rSpinPara;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDoviz;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rSpinOran;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraEditors.SimpleButton btnHesapSira;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcChildOdemePlan;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcOdemePlaniDetay;
        private DevExpress.XtraGrid.GridControl gcBorclular;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBorclular;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueBorclu;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties1;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties2;
        private DevExpress.XtraEditors.LabelControl lblDigerAlacaklar;
        private DevExpress.XtraEditors.LabelControl labelcontrolxxxx;
        private DevExpress.XtraEditors.LabelControl lblTazminat;
        private DevExpress.XtraEditors.LabelControl labelControl49;
        private DevExpress.XtraEditors.LabelControl lblMasraf;
        private DevExpress.XtraEditors.LabelControl labelControl36;
    }
}
