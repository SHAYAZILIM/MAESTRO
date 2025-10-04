namespace  AdimAdimDavaKaydi.Sorusturma.UserControls
{
    partial class ucHazirlikMuhasebeBilgileri
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
            this.gridMuhasebeBilgileri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gwMuhasebeBilgileri = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colREFERANS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHACIZ_SIRA_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSATIS_SIRA_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGORUSME_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueGorusme = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colORTAKLIK_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueOrtaklik = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueMuhasebeCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADINA_YAPAN_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISLEMI_YAPAN_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHAREKET_ANA_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueHareketAnaKategori = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colHAREKET_ALT_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueHareketAltKategori = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBELGE_TUR_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBelgetur = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBELGE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBORC_ALACAK_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueMuhBorcAlacak = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADET = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIK_KAPALI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAcikKapaliID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colVADESI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGORUNUM_SIRA_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHESAPLAMA_SONUCUMU_OLUSTU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueMuhasebeDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTUTAR_KDV_SIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTUTAR_KDV_LI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTOPLAM_TUTAR_KDV_SIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTOPLAM_TUTAR_KDV_LI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTOPLAM_KDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTOPLAM_TUTAR_SSDF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTOPLAM_TUTAR_STOPAJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFATURALI_MIKTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFATURALI_MIKTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBAKIYE_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBAKIYE_TOPLAM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBAKIYE_ALACAK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBAKIYE_BORC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOZEL_FOY_KOD_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueOzelFoyKod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colOZEL_CARI_KOD_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueCariOzelKod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBELGE_OZEL_KOD_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBelgeOzelKod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTARAF_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueMuhasebeTaraf = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colIS_KAYDEDILSIN_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHATIRLATILSIN_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAJANDADA_GORUNSUN_MU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSURE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOZEL_TUTAR_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueOzelTutar = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTUTAR_PAYLASTIRILCAK_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHESAPLANACAKMI_KDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHESAPLANACAKMI_STOPAJ_SSDF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colICINDEMI_KDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colICINDEMI_STOPAJ_SSDF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMUHASEBE_ARKADASLIK_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueMuhasebeArkalik = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTUTAR_PAYLASTIRILMISMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTARAF_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBOLUSTURME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOTOMATIK_KAYIT_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBORCLU_ODEME_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueMuvekkilOdeme = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTEBLIGAT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueMuhasebeTebligat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMUVEKKILE_ODEME_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.extendedGridControl1 = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn4 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn5 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn6 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn7 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn8 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn9 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn10 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn11 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn12 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn13 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn14 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn15 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn16 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn17 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn18 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn19 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn20 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn21 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn22 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn23 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn24 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn25 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn26 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn27 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn28 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn29 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn30 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn31 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn32 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn33 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn34 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit10 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn35 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit11 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn36 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit12 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn37 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit13 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn38 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn39 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn40 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn41 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn42 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn42 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn43 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit14 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn43 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn44 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn44 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn45 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn45 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn46 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn46 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn47 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn47 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn48 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn48 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn49 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit15 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn49 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn50 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn50 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn51 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn51 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn52 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn52 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn53 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn53 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn54 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit16 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn54 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn55 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit17 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn55 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn56 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn56 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridMuhasebeBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwMuhasebeBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGorusme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOrtaklik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuhasebeCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHareketAnaKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHareketAltKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBelgetur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuhBorcAlacak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAcikKapaliID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuhasebeDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelFoyKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCariOzelKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBelgeOzelKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuhasebeTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelTutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuhasebeArkalik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkilOdeme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuhasebeTebligat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extendedGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMuhasebeBilgileri
            // 
            this.gridMuhasebeBilgileri.CustomButtonlarGorunmesin = false;
            this.gridMuhasebeBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMuhasebeBilgileri.DoNotExtendEmbedNavigator = false;
            this.gridMuhasebeBilgileri.FilterText = null;
            this.gridMuhasebeBilgileri.FilterValue = null;
            this.gridMuhasebeBilgileri.GridsFilterControl = null;
            this.gridMuhasebeBilgileri.Location = new System.Drawing.Point(0, 0);
            this.gridMuhasebeBilgileri.MainView = this.gwMuhasebeBilgileri;
            this.gridMuhasebeBilgileri.MyGridStyle = null;
            this.gridMuhasebeBilgileri.Name = "gridMuhasebeBilgileri";
            this.gridMuhasebeBilgileri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueMuvekkilOdeme,
            this.rLueMuhasebeTebligat,
            this.rLueMuhasebeArkalik,
            this.rLueOzelTutar,
            this.rLueMuhasebeTaraf,
            this.rLueBelgeOzelKod,
            this.rLueCariOzelKod,
            this.rLueOzelFoyKod,
            this.rLueMuhasebeDoviz,
            this.rLueAcikKapaliID,
            this.rLueMuhBorcAlacak,
            this.rLueBelgetur,
            this.rLueHareketAltKategori,
            this.rLueHareketAnaKategori,
            this.rLueMuhasebeCari,
            this.rLueOrtaklik,
            this.rLueGorusme});
            this.gridMuhasebeBilgileri.ShowRowNumbers = false;
            this.gridMuhasebeBilgileri.Size = new System.Drawing.Size(733, 499);
            this.gridMuhasebeBilgileri.TabIndex = 2;
            this.gridMuhasebeBilgileri.TemizleKaldirGorunsunmu = false;
            this.gridMuhasebeBilgileri.UniqueId = "dbb8ae99-991a-489b-9e20-31cbc681d045";
            this.gridMuhasebeBilgileri.UseEmbeddedNavigator = true;
            this.gridMuhasebeBilgileri.UseHyperDragDrop = false;
            this.gridMuhasebeBilgileri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwMuhasebeBilgileri,
            this.gridView1});
            // 
            // gwMuhasebeBilgileri
            // 
            this.gwMuhasebeBilgileri.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colREFERANS_NO,
            this.colHACIZ_SIRA_NO,
            this.colSATIS_SIRA_NO,
            this.colGORUSME_ID,
            this.colORTAKLIK_ID,
            this.colCARI_ID,
            this.colADINA_YAPAN_CARI_ID,
            this.colISLEMI_YAPAN_CARI_ID,
            this.colTARIH,
            this.colHAREKET_ANA_KATEGORI_ID,
            this.colHAREKET_ALT_KATEGORI_ID,
            this.colBELGE_TUR_ID,
            this.colBELGE_NO,
            this.colBORC_ALACAK_ID,
            this.colADET,
            this.colACIK_KAPALI_ID,
            this.colVADESI,
            this.colACIKLAMA,
            this.colGORUNUM_SIRA_NO,
            this.colHESAPLAMA_SONUCUMU_OLUSTU,
            this.colDOVIZ_ID,
            this.colTUTAR_KDV_SIZ,
            this.colTUTAR_KDV_LI,
            this.colTOPLAM_TUTAR_KDV_SIZ,
            this.colTOPLAM_TUTAR_KDV_LI,
            this.colTOPLAM_KDV,
            this.colTOPLAM_TUTAR_SSDF,
            this.colTOPLAM_TUTAR_STOPAJ,
            this.colFATURALI_MIKTAR_DOVIZ_ID,
            this.colFATURALI_MIKTAR,
            this.colBAKIYE_TUTAR,
            this.colBAKIYE_TOPLAM,
            this.colBAKIYE_ALACAK,
            this.colBAKIYE_BORC,
            this.colOZEL_FOY_KOD_ID,
            this.colOZEL_CARI_KOD_ID,
            this.colBELGE_OZEL_KOD_ID,
            this.colTARAF_ID,
            this.colIS_KAYDEDILSIN_MI,
            this.colHATIRLATILSIN_MI,
            this.colAJANDADA_GORUNSUN_MU,
            this.colSURE,
            this.colOZEL_TUTAR_ID,
            this.colTUTAR_PAYLASTIRILCAK_MI,
            this.colHESAPLANACAKMI_KDV,
            this.colHESAPLANACAKMI_STOPAJ_SSDF,
            this.colICINDEMI_KDV,
            this.colICINDEMI_STOPAJ_SSDF,
            this.colMUHASEBE_ARKADASLIK_ID,
            this.colTUTAR_PAYLASTIRILMISMI,
            this.colTARAF_TIP,
            this.colBOLUSTURME,
            this.colOTOMATIK_KAYIT_MI,
            this.colBORCLU_ODEME_ID,
            this.colTEBLIGAT_ID,
            this.colMUVEKKILE_ODEME_ID});
            this.gwMuhasebeBilgileri.GridControl = this.gridMuhasebeBilgileri;
            this.gwMuhasebeBilgileri.IndicatorWidth = 20;
            this.gwMuhasebeBilgileri.Name = "gwMuhasebeBilgileri";
            this.gwMuhasebeBilgileri.OptionsBehavior.FocusLeaveOnTab = true;
            this.gwMuhasebeBilgileri.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwMuhasebeBilgileri.OptionsNavigation.AutoFocusNewRow = true;
            this.gwMuhasebeBilgileri.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwMuhasebeBilgileri.OptionsView.ColumnAutoWidth = false;
            this.gwMuhasebeBilgileri.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gwMuhasebeBilgileri.OptionsView.ShowAutoFilterRow = true;
            this.gwMuhasebeBilgileri.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwMuhasebeBilgileri.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gwMuhasebeBilgileri.OptionsView.ShowPreview = true;
            this.gwMuhasebeBilgileri.PreviewFieldName = "ACIKLAMA";
            // 
            // colREFERANS_NO
            // 
            this.colREFERANS_NO.Caption = "Ref. No";
            this.colREFERANS_NO.FieldName = "REFERANS_NO";
            this.colREFERANS_NO.Name = "colREFERANS_NO";
            this.colREFERANS_NO.Visible = true;
            this.colREFERANS_NO.VisibleIndex = 0;
            // 
            // colHACIZ_SIRA_NO
            // 
            this.colHACIZ_SIRA_NO.Caption = "Haciz Sýra No";
            this.colHACIZ_SIRA_NO.FieldName = "HACIZ_SIRA_NO";
            this.colHACIZ_SIRA_NO.Name = "colHACIZ_SIRA_NO";
            this.colHACIZ_SIRA_NO.Visible = true;
            this.colHACIZ_SIRA_NO.VisibleIndex = 1;
            // 
            // colSATIS_SIRA_NO
            // 
            this.colSATIS_SIRA_NO.Caption = "Satýþ Sýra No";
            this.colSATIS_SIRA_NO.FieldName = "SATIS_SIRA_NO";
            this.colSATIS_SIRA_NO.Name = "colSATIS_SIRA_NO";
            this.colSATIS_SIRA_NO.Visible = true;
            this.colSATIS_SIRA_NO.VisibleIndex = 2;
            // 
            // colGORUSME_ID
            // 
            this.colGORUSME_ID.Caption = "Görüþme";
            this.colGORUSME_ID.ColumnEdit = this.rLueGorusme;
            this.colGORUSME_ID.FieldName = "GORUSME_ID";
            this.colGORUSME_ID.Name = "colGORUSME_ID";
            // 
            // rLueGorusme
            // 
            this.rLueGorusme.AutoHeight = false;
            this.rLueGorusme.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueGorusme.Name = "rLueGorusme";
            // 
            // colORTAKLIK_ID
            // 
            this.colORTAKLIK_ID.Caption = "Ortaklýk ";
            this.colORTAKLIK_ID.ColumnEdit = this.rLueOrtaklik;
            this.colORTAKLIK_ID.FieldName = "ORTAKLIK_ID";
            this.colORTAKLIK_ID.Name = "colORTAKLIK_ID";
            // 
            // rLueOrtaklik
            // 
            this.rLueOrtaklik.AutoHeight = false;
            this.rLueOrtaklik.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueOrtaklik.Name = "rLueOrtaklik";
            // 
            // colCARI_ID
            // 
            this.colCARI_ID.Caption = "Þahýs";
            this.colCARI_ID.ColumnEdit = this.rLueMuhasebeCari;
            this.colCARI_ID.FieldName = "CARI_ID";
            this.colCARI_ID.Name = "colCARI_ID";
            this.colCARI_ID.Visible = true;
            this.colCARI_ID.VisibleIndex = 3;
            // 
            // rLueMuhasebeCari
            // 
            this.rLueMuhasebeCari.AutoHeight = false;
            this.rLueMuhasebeCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMuhasebeCari.Name = "rLueMuhasebeCari";
            // 
            // colADINA_YAPAN_CARI_ID
            // 
            this.colADINA_YAPAN_CARI_ID.Caption = "Adýna Yapan";
            this.colADINA_YAPAN_CARI_ID.ColumnEdit = this.rLueMuhasebeCari;
            this.colADINA_YAPAN_CARI_ID.FieldName = "ADINA_YAPAN_CARI_ID";
            this.colADINA_YAPAN_CARI_ID.Name = "colADINA_YAPAN_CARI_ID";
            this.colADINA_YAPAN_CARI_ID.Visible = true;
            this.colADINA_YAPAN_CARI_ID.VisibleIndex = 4;
            // 
            // colISLEMI_YAPAN_CARI_ID
            // 
            this.colISLEMI_YAPAN_CARI_ID.Caption = "Ýþlemi Yapan";
            this.colISLEMI_YAPAN_CARI_ID.ColumnEdit = this.rLueMuhasebeCari;
            this.colISLEMI_YAPAN_CARI_ID.FieldName = "ISLEMI_YAPAN_CARI_ID";
            this.colISLEMI_YAPAN_CARI_ID.Name = "colISLEMI_YAPAN_CARI_ID";
            this.colISLEMI_YAPAN_CARI_ID.Visible = true;
            this.colISLEMI_YAPAN_CARI_ID.VisibleIndex = 5;
            // 
            // colTARIH
            // 
            this.colTARIH.Caption = "Tarih";
            this.colTARIH.FieldName = "TARIH";
            this.colTARIH.Name = "colTARIH";
            this.colTARIH.Visible = true;
            this.colTARIH.VisibleIndex = 6;
            // 
            // colHAREKET_ANA_KATEGORI_ID
            // 
            this.colHAREKET_ANA_KATEGORI_ID.Caption = "Hareket Ana Kat.";
            this.colHAREKET_ANA_KATEGORI_ID.ColumnEdit = this.rLueHareketAnaKategori;
            this.colHAREKET_ANA_KATEGORI_ID.FieldName = "HAREKET_ANA_KATEGORI_ID";
            this.colHAREKET_ANA_KATEGORI_ID.Name = "colHAREKET_ANA_KATEGORI_ID";
            this.colHAREKET_ANA_KATEGORI_ID.Visible = true;
            this.colHAREKET_ANA_KATEGORI_ID.VisibleIndex = 7;
            // 
            // rLueHareketAnaKategori
            // 
            this.rLueHareketAnaKategori.AutoHeight = false;
            this.rLueHareketAnaKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueHareketAnaKategori.Name = "rLueHareketAnaKategori";
            // 
            // colHAREKET_ALT_KATEGORI_ID
            // 
            this.colHAREKET_ALT_KATEGORI_ID.Caption = "Hareket Alt Kat.";
            this.colHAREKET_ALT_KATEGORI_ID.ColumnEdit = this.rLueHareketAltKategori;
            this.colHAREKET_ALT_KATEGORI_ID.FieldName = "HAREKET_ALT_KATEGORI_ID";
            this.colHAREKET_ALT_KATEGORI_ID.Name = "colHAREKET_ALT_KATEGORI_ID";
            this.colHAREKET_ALT_KATEGORI_ID.Visible = true;
            this.colHAREKET_ALT_KATEGORI_ID.VisibleIndex = 8;
            // 
            // rLueHareketAltKategori
            // 
            this.rLueHareketAltKategori.AutoHeight = false;
            this.rLueHareketAltKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueHareketAltKategori.Name = "rLueHareketAltKategori";
            // 
            // colBELGE_TUR_ID
            // 
            this.colBELGE_TUR_ID.Caption = "Belge Tür";
            this.colBELGE_TUR_ID.ColumnEdit = this.rLueBelgetur;
            this.colBELGE_TUR_ID.FieldName = "BELGE_TUR_ID";
            this.colBELGE_TUR_ID.Name = "colBELGE_TUR_ID";
            this.colBELGE_TUR_ID.Visible = true;
            this.colBELGE_TUR_ID.VisibleIndex = 9;
            // 
            // rLueBelgetur
            // 
            this.rLueBelgetur.AutoHeight = false;
            this.rLueBelgetur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBelgetur.Name = "rLueBelgetur";
            // 
            // colBELGE_NO
            // 
            this.colBELGE_NO.Caption = "Belge No";
            this.colBELGE_NO.FieldName = "BELGE_NO";
            this.colBELGE_NO.Name = "colBELGE_NO";
            this.colBELGE_NO.Visible = true;
            this.colBELGE_NO.VisibleIndex = 10;
            // 
            // colBORC_ALACAK_ID
            // 
            this.colBORC_ALACAK_ID.Caption = "Borç Alacak";
            this.colBORC_ALACAK_ID.ColumnEdit = this.rLueMuhBorcAlacak;
            this.colBORC_ALACAK_ID.FieldName = "BORC_ALACAK_ID";
            this.colBORC_ALACAK_ID.Name = "colBORC_ALACAK_ID";
            this.colBORC_ALACAK_ID.Visible = true;
            this.colBORC_ALACAK_ID.VisibleIndex = 11;
            // 
            // rLueMuhBorcAlacak
            // 
            this.rLueMuhBorcAlacak.AutoHeight = false;
            this.rLueMuhBorcAlacak.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMuhBorcAlacak.Name = "rLueMuhBorcAlacak";
            // 
            // colADET
            // 
            this.colADET.Caption = "Adet";
            this.colADET.FieldName = "ADET";
            this.colADET.Name = "colADET";
            this.colADET.Visible = true;
            this.colADET.VisibleIndex = 12;
            // 
            // colACIK_KAPALI_ID
            // 
            this.colACIK_KAPALI_ID.Caption = "Açýk Kapalý";
            this.colACIK_KAPALI_ID.ColumnEdit = this.rLueAcikKapaliID;
            this.colACIK_KAPALI_ID.FieldName = "ACIK_KAPALI_ID";
            this.colACIK_KAPALI_ID.Name = "colACIK_KAPALI_ID";
            this.colACIK_KAPALI_ID.Visible = true;
            this.colACIK_KAPALI_ID.VisibleIndex = 13;
            // 
            // rLueAcikKapaliID
            // 
            this.rLueAcikKapaliID.AutoHeight = false;
            this.rLueAcikKapaliID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAcikKapaliID.Name = "rLueAcikKapaliID";
            // 
            // colVADESI
            // 
            this.colVADESI.Caption = "Vadesi";
            this.colVADESI.FieldName = "VADESI";
            this.colVADESI.Name = "colVADESI";
            this.colVADESI.Visible = true;
            this.colVADESI.VisibleIndex = 14;
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açýklama";
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 15;
            // 
            // colGORUNUM_SIRA_NO
            // 
            this.colGORUNUM_SIRA_NO.Caption = "Görünüm Sýra No";
            this.colGORUNUM_SIRA_NO.FieldName = "GORUNUM_SIRA_NO";
            this.colGORUNUM_SIRA_NO.Name = "colGORUNUM_SIRA_NO";
            this.colGORUNUM_SIRA_NO.Visible = true;
            this.colGORUNUM_SIRA_NO.VisibleIndex = 16;
            // 
            // colHESAPLAMA_SONUCUMU_OLUSTU
            // 
            this.colHESAPLAMA_SONUCUMU_OLUSTU.Caption = "H. Sonucu Oluþtumu";
            this.colHESAPLAMA_SONUCUMU_OLUSTU.FieldName = "HESAPLAMA_SONUCUMU_OLUSTU";
            this.colHESAPLAMA_SONUCUMU_OLUSTU.Name = "colHESAPLAMA_SONUCUMU_OLUSTU";
            this.colHESAPLAMA_SONUCUMU_OLUSTU.Visible = true;
            this.colHESAPLAMA_SONUCUMU_OLUSTU.VisibleIndex = 17;
            // 
            // colDOVIZ_ID
            // 
            this.colDOVIZ_ID.Caption = "Brm.";
            this.colDOVIZ_ID.ColumnEdit = this.rLueMuhasebeDoviz;
            this.colDOVIZ_ID.FieldName = "DOVIZ_ID";
            this.colDOVIZ_ID.Name = "colDOVIZ_ID";
            this.colDOVIZ_ID.Visible = true;
            this.colDOVIZ_ID.VisibleIndex = 18;
            // 
            // rLueMuhasebeDoviz
            // 
            this.rLueMuhasebeDoviz.AutoHeight = false;
            this.rLueMuhasebeDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMuhasebeDoviz.Name = "rLueMuhasebeDoviz";
            // 
            // colTUTAR_KDV_SIZ
            // 
            this.colTUTAR_KDV_SIZ.Caption = "KDV`siz Tutar";
            this.colTUTAR_KDV_SIZ.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.colTUTAR_KDV_SIZ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTUTAR_KDV_SIZ.FieldName = "TUTAR_KDV_SIZ";
            this.colTUTAR_KDV_SIZ.Name = "colTUTAR_KDV_SIZ";
            this.colTUTAR_KDV_SIZ.Visible = true;
            this.colTUTAR_KDV_SIZ.VisibleIndex = 19;
            // 
            // colTUTAR_KDV_LI
            // 
            this.colTUTAR_KDV_LI.Caption = "KDV li Tutar";
            this.colTUTAR_KDV_LI.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.colTUTAR_KDV_LI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTUTAR_KDV_LI.FieldName = "TUTAR_KDV_LI";
            this.colTUTAR_KDV_LI.Name = "colTUTAR_KDV_LI";
            this.colTUTAR_KDV_LI.Visible = true;
            this.colTUTAR_KDV_LI.VisibleIndex = 20;
            // 
            // colTOPLAM_TUTAR_KDV_SIZ
            // 
            this.colTOPLAM_TUTAR_KDV_SIZ.Caption = "KDV siz Toplam Tutar";
            this.colTOPLAM_TUTAR_KDV_SIZ.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.colTOPLAM_TUTAR_KDV_SIZ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTOPLAM_TUTAR_KDV_SIZ.FieldName = "TOPLAM_TUTAR_KDV_SIZ";
            this.colTOPLAM_TUTAR_KDV_SIZ.Name = "colTOPLAM_TUTAR_KDV_SIZ";
            this.colTOPLAM_TUTAR_KDV_SIZ.Visible = true;
            this.colTOPLAM_TUTAR_KDV_SIZ.VisibleIndex = 21;
            // 
            // colTOPLAM_TUTAR_KDV_LI
            // 
            this.colTOPLAM_TUTAR_KDV_LI.Caption = "KDV li Toplam Tutar";
            this.colTOPLAM_TUTAR_KDV_LI.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.colTOPLAM_TUTAR_KDV_LI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTOPLAM_TUTAR_KDV_LI.FieldName = "TOPLAM_TUTAR_KDV_LI";
            this.colTOPLAM_TUTAR_KDV_LI.Name = "colTOPLAM_TUTAR_KDV_LI";
            this.colTOPLAM_TUTAR_KDV_LI.Visible = true;
            this.colTOPLAM_TUTAR_KDV_LI.VisibleIndex = 22;
            // 
            // colTOPLAM_KDV
            // 
            this.colTOPLAM_KDV.Caption = "KDV Toplamý";
            this.colTOPLAM_KDV.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.colTOPLAM_KDV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTOPLAM_KDV.FieldName = "TOPLAM_KDV";
            this.colTOPLAM_KDV.Name = "colTOPLAM_KDV";
            this.colTOPLAM_KDV.Visible = true;
            this.colTOPLAM_KDV.VisibleIndex = 23;
            // 
            // colTOPLAM_TUTAR_SSDF
            // 
            this.colTOPLAM_TUTAR_SSDF.Caption = "SSDF Toplamý";
            this.colTOPLAM_TUTAR_SSDF.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.colTOPLAM_TUTAR_SSDF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTOPLAM_TUTAR_SSDF.FieldName = "TOPLAM_TUTAR_SSDF";
            this.colTOPLAM_TUTAR_SSDF.Name = "colTOPLAM_TUTAR_SSDF";
            this.colTOPLAM_TUTAR_SSDF.Visible = true;
            this.colTOPLAM_TUTAR_SSDF.VisibleIndex = 24;
            // 
            // colTOPLAM_TUTAR_STOPAJ
            // 
            this.colTOPLAM_TUTAR_STOPAJ.Caption = "STOPAJ Toplamý";
            this.colTOPLAM_TUTAR_STOPAJ.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.colTOPLAM_TUTAR_STOPAJ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTOPLAM_TUTAR_STOPAJ.FieldName = "TOPLAM_TUTAR_STOPAJ";
            this.colTOPLAM_TUTAR_STOPAJ.Name = "colTOPLAM_TUTAR_STOPAJ";
            this.colTOPLAM_TUTAR_STOPAJ.Visible = true;
            this.colTOPLAM_TUTAR_STOPAJ.VisibleIndex = 25;
            // 
            // colFATURALI_MIKTAR_DOVIZ_ID
            // 
            this.colFATURALI_MIKTAR_DOVIZ_ID.Caption = "Brm.";
            this.colFATURALI_MIKTAR_DOVIZ_ID.ColumnEdit = this.rLueMuhasebeDoviz;
            this.colFATURALI_MIKTAR_DOVIZ_ID.FieldName = "FATURALI_MIKTAR_DOVIZ_ID";
            this.colFATURALI_MIKTAR_DOVIZ_ID.Name = "colFATURALI_MIKTAR_DOVIZ_ID";
            this.colFATURALI_MIKTAR_DOVIZ_ID.Visible = true;
            this.colFATURALI_MIKTAR_DOVIZ_ID.VisibleIndex = 26;
            // 
            // colFATURALI_MIKTAR
            // 
            this.colFATURALI_MIKTAR.Caption = "Faturali Miktar";
            this.colFATURALI_MIKTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.colFATURALI_MIKTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFATURALI_MIKTAR.FieldName = "FATURALI_MIKTAR";
            this.colFATURALI_MIKTAR.Name = "colFATURALI_MIKTAR";
            this.colFATURALI_MIKTAR.Visible = true;
            this.colFATURALI_MIKTAR.VisibleIndex = 27;
            // 
            // colBAKIYE_TUTAR
            // 
            this.colBAKIYE_TUTAR.Caption = "Bakiye Tutar";
            this.colBAKIYE_TUTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.colBAKIYE_TUTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBAKIYE_TUTAR.FieldName = "BAKIYE_TUTAR";
            this.colBAKIYE_TUTAR.Name = "colBAKIYE_TUTAR";
            this.colBAKIYE_TUTAR.Visible = true;
            this.colBAKIYE_TUTAR.VisibleIndex = 28;
            // 
            // colBAKIYE_TOPLAM
            // 
            this.colBAKIYE_TOPLAM.Caption = "Bakiye Toplam";
            this.colBAKIYE_TOPLAM.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.colBAKIYE_TOPLAM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBAKIYE_TOPLAM.FieldName = "BAKIYE_TOPLAM";
            this.colBAKIYE_TOPLAM.Name = "colBAKIYE_TOPLAM";
            this.colBAKIYE_TOPLAM.Visible = true;
            this.colBAKIYE_TOPLAM.VisibleIndex = 29;
            // 
            // colBAKIYE_ALACAK
            // 
            this.colBAKIYE_ALACAK.Caption = "Bakiye Alacak";
            this.colBAKIYE_ALACAK.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.colBAKIYE_ALACAK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBAKIYE_ALACAK.FieldName = "BAKIYE_ALACAK";
            this.colBAKIYE_ALACAK.Name = "colBAKIYE_ALACAK";
            this.colBAKIYE_ALACAK.Visible = true;
            this.colBAKIYE_ALACAK.VisibleIndex = 30;
            // 
            // colBAKIYE_BORC
            // 
            this.colBAKIYE_BORC.Caption = "Bakiye Borç";
            this.colBAKIYE_BORC.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.colBAKIYE_BORC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBAKIYE_BORC.FieldName = "BAKIYE_BORC";
            this.colBAKIYE_BORC.Name = "colBAKIYE_BORC";
            this.colBAKIYE_BORC.Visible = true;
            this.colBAKIYE_BORC.VisibleIndex = 31;
            // 
            // colOZEL_FOY_KOD_ID
            // 
            this.colOZEL_FOY_KOD_ID.Caption = "Özel Föy Kod";
            this.colOZEL_FOY_KOD_ID.ColumnEdit = this.rLueOzelFoyKod;
            this.colOZEL_FOY_KOD_ID.FieldName = "OZEL_FOY_KOD_ID";
            this.colOZEL_FOY_KOD_ID.Name = "colOZEL_FOY_KOD_ID";
            this.colOZEL_FOY_KOD_ID.Visible = true;
            this.colOZEL_FOY_KOD_ID.VisibleIndex = 32;
            // 
            // rLueOzelFoyKod
            // 
            this.rLueOzelFoyKod.AutoHeight = false;
            this.rLueOzelFoyKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueOzelFoyKod.Name = "rLueOzelFoyKod";
            // 
            // colOZEL_CARI_KOD_ID
            // 
            this.colOZEL_CARI_KOD_ID.Caption = "Þahýs Özel Kod";
            this.colOZEL_CARI_KOD_ID.ColumnEdit = this.rLueCariOzelKod;
            this.colOZEL_CARI_KOD_ID.FieldName = "OZEL_CARI_KOD_ID";
            this.colOZEL_CARI_KOD_ID.Name = "colOZEL_CARI_KOD_ID";
            this.colOZEL_CARI_KOD_ID.Visible = true;
            this.colOZEL_CARI_KOD_ID.VisibleIndex = 33;
            // 
            // rLueCariOzelKod
            // 
            this.rLueCariOzelKod.AutoHeight = false;
            this.rLueCariOzelKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueCariOzelKod.Name = "rLueCariOzelKod";
            // 
            // colBELGE_OZEL_KOD_ID
            // 
            this.colBELGE_OZEL_KOD_ID.Caption = "Belge Özel Kod";
            this.colBELGE_OZEL_KOD_ID.ColumnEdit = this.rLueBelgeOzelKod;
            this.colBELGE_OZEL_KOD_ID.FieldName = "BELGE_OZEL_KOD_ID";
            this.colBELGE_OZEL_KOD_ID.Name = "colBELGE_OZEL_KOD_ID";
            this.colBELGE_OZEL_KOD_ID.Visible = true;
            this.colBELGE_OZEL_KOD_ID.VisibleIndex = 34;
            // 
            // rLueBelgeOzelKod
            // 
            this.rLueBelgeOzelKod.AutoHeight = false;
            this.rLueBelgeOzelKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBelgeOzelKod.Name = "rLueBelgeOzelKod";
            // 
            // colTARAF_ID
            // 
            this.colTARAF_ID.Caption = "Taraf";
            this.colTARAF_ID.ColumnEdit = this.rLueMuhasebeTaraf;
            this.colTARAF_ID.FieldName = "TARAF_ID";
            this.colTARAF_ID.Name = "colTARAF_ID";
            this.colTARAF_ID.Visible = true;
            this.colTARAF_ID.VisibleIndex = 35;
            // 
            // rLueMuhasebeTaraf
            // 
            this.rLueMuhasebeTaraf.AutoHeight = false;
            this.rLueMuhasebeTaraf.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMuhasebeTaraf.Name = "rLueMuhasebeTaraf";
            // 
            // colIS_KAYDEDILSIN_MI
            // 
            this.colIS_KAYDEDILSIN_MI.Caption = "Ýþ Kaydedilsin mi";
            this.colIS_KAYDEDILSIN_MI.FieldName = "IS_KAYDEDILSIN_MI";
            this.colIS_KAYDEDILSIN_MI.Name = "colIS_KAYDEDILSIN_MI";
            this.colIS_KAYDEDILSIN_MI.Visible = true;
            this.colIS_KAYDEDILSIN_MI.VisibleIndex = 36;
            // 
            // colHATIRLATILSIN_MI
            // 
            this.colHATIRLATILSIN_MI.Caption = "Hatýrlatýlsýn mý";
            this.colHATIRLATILSIN_MI.FieldName = "HATIRLATILSIN_MI";
            this.colHATIRLATILSIN_MI.Name = "colHATIRLATILSIN_MI";
            this.colHATIRLATILSIN_MI.Visible = true;
            this.colHATIRLATILSIN_MI.VisibleIndex = 37;
            // 
            // colAJANDADA_GORUNSUN_MU
            // 
            this.colAJANDADA_GORUNSUN_MU.Caption = "Ajanda da Görünsün mü";
            this.colAJANDADA_GORUNSUN_MU.FieldName = "AJANDADA_GORUNSUN_MU";
            this.colAJANDADA_GORUNSUN_MU.Name = "colAJANDADA_GORUNSUN_MU";
            this.colAJANDADA_GORUNSUN_MU.Visible = true;
            this.colAJANDADA_GORUNSUN_MU.VisibleIndex = 38;
            // 
            // colSURE
            // 
            this.colSURE.Caption = "Süre";
            this.colSURE.FieldName = "SURE";
            this.colSURE.Name = "colSURE";
            this.colSURE.Visible = true;
            this.colSURE.VisibleIndex = 39;
            // 
            // colOZEL_TUTAR_ID
            // 
            this.colOZEL_TUTAR_ID.Caption = "Ozel Tutar";
            this.colOZEL_TUTAR_ID.ColumnEdit = this.rLueOzelTutar;
            this.colOZEL_TUTAR_ID.FieldName = "OZEL_TUTAR_ID";
            this.colOZEL_TUTAR_ID.Name = "colOZEL_TUTAR_ID";
            this.colOZEL_TUTAR_ID.Visible = true;
            this.colOZEL_TUTAR_ID.VisibleIndex = 40;
            // 
            // rLueOzelTutar
            // 
            this.rLueOzelTutar.AutoHeight = false;
            this.rLueOzelTutar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueOzelTutar.Name = "rLueOzelTutar";
            // 
            // colTUTAR_PAYLASTIRILCAK_MI
            // 
            this.colTUTAR_PAYLASTIRILCAK_MI.Caption = "Tutar Paylaþýlacak mý";
            this.colTUTAR_PAYLASTIRILCAK_MI.FieldName = "TUTAR_PAYLASTIRILCAK_MI";
            this.colTUTAR_PAYLASTIRILCAK_MI.Name = "colTUTAR_PAYLASTIRILCAK_MI";
            this.colTUTAR_PAYLASTIRILCAK_MI.Visible = true;
            this.colTUTAR_PAYLASTIRILCAK_MI.VisibleIndex = 41;
            // 
            // colHESAPLANACAKMI_KDV
            // 
            this.colHESAPLANACAKMI_KDV.Caption = "KDV Hesaplanacak mý";
            this.colHESAPLANACAKMI_KDV.FieldName = "HESAPLANACAKMI_KDV";
            this.colHESAPLANACAKMI_KDV.Name = "colHESAPLANACAKMI_KDV";
            this.colHESAPLANACAKMI_KDV.Visible = true;
            this.colHESAPLANACAKMI_KDV.VisibleIndex = 42;
            // 
            // colHESAPLANACAKMI_STOPAJ_SSDF
            // 
            this.colHESAPLANACAKMI_STOPAJ_SSDF.Caption = "SSDF Hesaplanacak mý";
            this.colHESAPLANACAKMI_STOPAJ_SSDF.FieldName = "HESAPLANACAKMI_STOPAJ_SSDF";
            this.colHESAPLANACAKMI_STOPAJ_SSDF.Name = "colHESAPLANACAKMI_STOPAJ_SSDF";
            this.colHESAPLANACAKMI_STOPAJ_SSDF.Visible = true;
            this.colHESAPLANACAKMI_STOPAJ_SSDF.VisibleIndex = 43;
            // 
            // colICINDEMI_KDV
            // 
            this.colICINDEMI_KDV.Caption = "KDV Dahil mi";
            this.colICINDEMI_KDV.FieldName = "ICINDEMI_KDV";
            this.colICINDEMI_KDV.Name = "colICINDEMI_KDV";
            this.colICINDEMI_KDV.Visible = true;
            this.colICINDEMI_KDV.VisibleIndex = 44;
            // 
            // colICINDEMI_STOPAJ_SSDF
            // 
            this.colICINDEMI_STOPAJ_SSDF.Caption = "SSDF Dahil mi";
            this.colICINDEMI_STOPAJ_SSDF.FieldName = "ICINDEMI_STOPAJ_SSDF";
            this.colICINDEMI_STOPAJ_SSDF.Name = "colICINDEMI_STOPAJ_SSDF";
            this.colICINDEMI_STOPAJ_SSDF.Visible = true;
            this.colICINDEMI_STOPAJ_SSDF.VisibleIndex = 45;
            // 
            // colMUHASEBE_ARKADASLIK_ID
            // 
            this.colMUHASEBE_ARKADASLIK_ID.Caption = "Muhasebe Arkadaþlýk";
            this.colMUHASEBE_ARKADASLIK_ID.ColumnEdit = this.rLueMuhasebeArkalik;
            this.colMUHASEBE_ARKADASLIK_ID.FieldName = "MUHASEBE_ARKADASLIK_ID";
            this.colMUHASEBE_ARKADASLIK_ID.Name = "colMUHASEBE_ARKADASLIK_ID";
            // 
            // rLueMuhasebeArkalik
            // 
            this.rLueMuhasebeArkalik.AutoHeight = false;
            this.rLueMuhasebeArkalik.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMuhasebeArkalik.Name = "rLueMuhasebeArkalik";
            // 
            // colTUTAR_PAYLASTIRILMISMI
            // 
            this.colTUTAR_PAYLASTIRILMISMI.Caption = "Tutar Paylaþtýrýlsýn mý";
            this.colTUTAR_PAYLASTIRILMISMI.FieldName = "TUTAR_PAYLASTIRILMISMI";
            this.colTUTAR_PAYLASTIRILMISMI.Name = "colTUTAR_PAYLASTIRILMISMI";
            this.colTUTAR_PAYLASTIRILMISMI.Visible = true;
            this.colTUTAR_PAYLASTIRILMISMI.VisibleIndex = 46;
            // 
            // colTARAF_TIP
            // 
            this.colTARAF_TIP.Caption = "Taraf Tip";
            this.colTARAF_TIP.FieldName = "TARAF_TIP";
            this.colTARAF_TIP.Name = "colTARAF_TIP";
            this.colTARAF_TIP.Visible = true;
            this.colTARAF_TIP.VisibleIndex = 47;
            // 
            // colBOLUSTURME
            // 
            this.colBOLUSTURME.Caption = "Bölüþtürme";
            this.colBOLUSTURME.FieldName = "BOLUSTURME";
            this.colBOLUSTURME.Name = "colBOLUSTURME";
            this.colBOLUSTURME.Visible = true;
            this.colBOLUSTURME.VisibleIndex = 48;
            // 
            // colOTOMATIK_KAYIT_MI
            // 
            this.colOTOMATIK_KAYIT_MI.Caption = "Otomatik Kayýtmý";
            this.colOTOMATIK_KAYIT_MI.FieldName = "OTOMATIK_KAYIT_MI";
            this.colOTOMATIK_KAYIT_MI.Name = "colOTOMATIK_KAYIT_MI";
            this.colOTOMATIK_KAYIT_MI.Visible = true;
            this.colOTOMATIK_KAYIT_MI.VisibleIndex = 49;
            // 
            // colBORCLU_ODEME_ID
            // 
            this.colBORCLU_ODEME_ID.Caption = "Borclu Odeme";
            this.colBORCLU_ODEME_ID.ColumnEdit = this.rLueMuvekkilOdeme;
            this.colBORCLU_ODEME_ID.FieldName = "BORCLU_ODEME_ID";
            this.colBORCLU_ODEME_ID.Name = "colBORCLU_ODEME_ID";
            // 
            // rLueMuvekkilOdeme
            // 
            this.rLueMuvekkilOdeme.AutoHeight = false;
            this.rLueMuvekkilOdeme.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMuvekkilOdeme.Name = "rLueMuvekkilOdeme";
            // 
            // colTEBLIGAT_ID
            // 
            this.colTEBLIGAT_ID.Caption = "Tebligat";
            this.colTEBLIGAT_ID.ColumnEdit = this.rLueMuhasebeTebligat;
            this.colTEBLIGAT_ID.FieldName = "TEBLIGAT_ID";
            this.colTEBLIGAT_ID.Name = "colTEBLIGAT_ID";
            this.colTEBLIGAT_ID.Visible = true;
            this.colTEBLIGAT_ID.VisibleIndex = 50;
            // 
            // rLueMuhasebeTebligat
            // 
            this.rLueMuhasebeTebligat.AutoHeight = false;
            this.rLueMuhasebeTebligat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMuhasebeTebligat.Name = "rLueMuhasebeTebligat";
            // 
            // colMUVEKKILE_ODEME_ID
            // 
            this.colMUVEKKILE_ODEME_ID.Caption = "Müvekkil Odeme";
            this.colMUVEKKILE_ODEME_ID.ColumnEdit = this.rLueMuvekkilOdeme;
            this.colMUVEKKILE_ODEME_ID.FieldName = "MUVEKKILE_ODEME_ID";
            this.colMUVEKKILE_ODEME_ID.Name = "colMUVEKKILE_ODEME_ID";
            this.colMUVEKKILE_ODEME_ID.Visible = true;
            this.colMUVEKKILE_ODEME_ID.VisibleIndex = 51;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridMuhasebeBilgileri;
            this.gridView1.Name = "gridView1";
            // 
            // extendedGridControl1
            // 
            this.extendedGridControl1.CustomButtonlarGorunmesin = false;
            this.extendedGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extendedGridControl1.DoNotExtendEmbedNavigator = false;
            this.extendedGridControl1.FilterText = null;
            this.extendedGridControl1.FilterValue = null;
            this.extendedGridControl1.GridsFilterControl = null;
            this.extendedGridControl1.Location = new System.Drawing.Point(0, 0);
            this.extendedGridControl1.MainView = this.layoutView1;
            this.extendedGridControl1.MyGridStyle = null;
            this.extendedGridControl1.Name = "extendedGridControl1";
            this.extendedGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit16,
            this.repositoryItemLookUpEdit17,
            this.repositoryItemLookUpEdit15,
            this.repositoryItemLookUpEdit14,
            this.repositoryItemLookUpEdit13,
            this.repositoryItemLookUpEdit12,
            this.repositoryItemLookUpEdit11,
            this.repositoryItemLookUpEdit10,
            this.repositoryItemLookUpEdit9,
            this.repositoryItemLookUpEdit8,
            this.repositoryItemLookUpEdit7,
            this.repositoryItemLookUpEdit6,
            this.repositoryItemLookUpEdit5,
            this.repositoryItemLookUpEdit4,
            this.repositoryItemLookUpEdit3,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemLookUpEdit1});
            this.extendedGridControl1.ShowRowNumbers = false;
            this.extendedGridControl1.Size = new System.Drawing.Size(733, 499);
            this.extendedGridControl1.TabIndex = 3;
            this.extendedGridControl1.TemizleKaldirGorunsunmu = false;
            this.extendedGridControl1.UniqueId = "60d543e4-786c-4d1d-9375-78b849087347";
            this.extendedGridControl1.UseEmbeddedNavigator = true;
            this.extendedGridControl1.UseHyperDragDrop = false;
            this.extendedGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1,
            this.gridView3});
            // 
            // layoutView1
            // 
            this.layoutView1.CardCaptionFormat = "Kayýt{0}";
            this.layoutView1.CardMinSize = new System.Drawing.Size(635, 668);
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn34,
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn38,
            this.gridColumn39,
            this.gridColumn40,
            this.gridColumn41,
            this.gridColumn42,
            this.gridColumn43,
            this.gridColumn44,
            this.gridColumn45,
            this.gridColumn46,
            this.gridColumn47,
            this.gridColumn48,
            this.gridColumn49,
            this.gridColumn50,
            this.gridColumn51,
            this.gridColumn52,
            this.gridColumn53,
            this.gridColumn54,
            this.gridColumn55,
            this.gridColumn56});
            this.layoutView1.GridControl = this.extendedGridControl1;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ref. No";
            this.gridColumn1.FieldName = "REFERANS_NO";
            this.gridColumn1.LayoutViewField = this.layoutViewField_gridColumn1;
            this.gridColumn1.Name = "gridColumn1";
            // 
            // layoutViewField_gridColumn1
            // 
            this.layoutViewField_gridColumn1.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_gridColumn1.Name = "layoutViewField_gridColumn1";
            this.layoutViewField_gridColumn1.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn1.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Haciz Sýra No";
            this.gridColumn2.FieldName = "HACIZ_SIRA_NO";
            this.gridColumn2.LayoutViewField = this.layoutViewField_gridColumn2;
            this.gridColumn2.Name = "gridColumn2";
            // 
            // layoutViewField_gridColumn2
            // 
            this.layoutViewField_gridColumn2.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn2.Location = new System.Drawing.Point(158, 0);
            this.layoutViewField_gridColumn2.Name = "layoutViewField_gridColumn2";
            this.layoutViewField_gridColumn2.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn2.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Satýþ Sýra No";
            this.gridColumn3.FieldName = "SATIS_SIRA_NO";
            this.gridColumn3.LayoutViewField = this.layoutViewField_gridColumn3;
            this.gridColumn3.Name = "gridColumn3";
            // 
            // layoutViewField_gridColumn3
            // 
            this.layoutViewField_gridColumn3.EditorPreferredWidth = 182;
            this.layoutViewField_gridColumn3.Location = new System.Drawing.Point(316, 0);
            this.layoutViewField_gridColumn3.Name = "layoutViewField_gridColumn3";
            this.layoutViewField_gridColumn3.Size = new System.Drawing.Size(317, 27);
            this.layoutViewField_gridColumn3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn3.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Görüþme";
            this.gridColumn4.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.gridColumn4.FieldName = "GORUSME_ID";
            this.gridColumn4.LayoutViewField = this.layoutViewField_gridColumn4;
            this.gridColumn4.Name = "gridColumn4";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // layoutViewField_gridColumn4
            // 
            this.layoutViewField_gridColumn4.EditorPreferredWidth = 340;
            this.layoutViewField_gridColumn4.Location = new System.Drawing.Point(158, 27);
            this.layoutViewField_gridColumn4.Name = "layoutViewField_gridColumn4";
            this.layoutViewField_gridColumn4.Size = new System.Drawing.Size(475, 27);
            this.layoutViewField_gridColumn4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn4.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Ortaklýk ";
            this.gridColumn5.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.gridColumn5.FieldName = "ORTAKLIK_ID";
            this.gridColumn5.LayoutViewField = this.layoutViewField_gridColumn5;
            this.gridColumn5.Name = "gridColumn5";
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            // 
            // layoutViewField_gridColumn5
            // 
            this.layoutViewField_gridColumn5.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn5.Location = new System.Drawing.Point(0, 27);
            this.layoutViewField_gridColumn5.Name = "layoutViewField_gridColumn5";
            this.layoutViewField_gridColumn5.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn5.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Þahýs";
            this.gridColumn6.ColumnEdit = this.repositoryItemLookUpEdit3;
            this.gridColumn6.FieldName = "CARI_ID";
            this.gridColumn6.LayoutViewField = this.layoutViewField_gridColumn6;
            this.gridColumn6.Name = "gridColumn6";
            // 
            // repositoryItemLookUpEdit3
            // 
            this.repositoryItemLookUpEdit3.AutoHeight = false;
            this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
            // 
            // layoutViewField_gridColumn6
            // 
            this.layoutViewField_gridColumn6.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn6.Location = new System.Drawing.Point(0, 54);
            this.layoutViewField_gridColumn6.Name = "layoutViewField_gridColumn6";
            this.layoutViewField_gridColumn6.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn6.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn6.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Adýna Yapan";
            this.gridColumn7.ColumnEdit = this.repositoryItemLookUpEdit3;
            this.gridColumn7.FieldName = "ADINA_YAPAN_CARI_ID";
            this.gridColumn7.LayoutViewField = this.layoutViewField_gridColumn7;
            this.gridColumn7.Name = "gridColumn7";
            // 
            // layoutViewField_gridColumn7
            // 
            this.layoutViewField_gridColumn7.EditorPreferredWidth = 340;
            this.layoutViewField_gridColumn7.Location = new System.Drawing.Point(158, 54);
            this.layoutViewField_gridColumn7.Name = "layoutViewField_gridColumn7";
            this.layoutViewField_gridColumn7.Size = new System.Drawing.Size(475, 27);
            this.layoutViewField_gridColumn7.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn7.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Ýþlemi Yapan";
            this.gridColumn8.ColumnEdit = this.repositoryItemLookUpEdit3;
            this.gridColumn8.FieldName = "ISLEMI_YAPAN_CARI_ID";
            this.gridColumn8.LayoutViewField = this.layoutViewField_gridColumn8;
            this.gridColumn8.Name = "gridColumn8";
            // 
            // layoutViewField_gridColumn8
            // 
            this.layoutViewField_gridColumn8.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn8.Location = new System.Drawing.Point(0, 81);
            this.layoutViewField_gridColumn8.Name = "layoutViewField_gridColumn8";
            this.layoutViewField_gridColumn8.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn8.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn8.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Tarih";
            this.gridColumn9.FieldName = "TARIH";
            this.gridColumn9.LayoutViewField = this.layoutViewField_gridColumn9;
            this.gridColumn9.Name = "gridColumn9";
            // 
            // layoutViewField_gridColumn9
            // 
            this.layoutViewField_gridColumn9.EditorPreferredWidth = 340;
            this.layoutViewField_gridColumn9.Location = new System.Drawing.Point(158, 81);
            this.layoutViewField_gridColumn9.Name = "layoutViewField_gridColumn9";
            this.layoutViewField_gridColumn9.Size = new System.Drawing.Size(475, 27);
            this.layoutViewField_gridColumn9.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn9.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Hareket Ana Kat.";
            this.gridColumn10.ColumnEdit = this.repositoryItemLookUpEdit4;
            this.gridColumn10.FieldName = "HAREKET_ANA_KATEGORI_ID";
            this.gridColumn10.LayoutViewField = this.layoutViewField_gridColumn10;
            this.gridColumn10.Name = "gridColumn10";
            // 
            // repositoryItemLookUpEdit4
            // 
            this.repositoryItemLookUpEdit4.AutoHeight = false;
            this.repositoryItemLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit4.Name = "repositoryItemLookUpEdit4";
            // 
            // layoutViewField_gridColumn10
            // 
            this.layoutViewField_gridColumn10.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn10.Location = new System.Drawing.Point(0, 108);
            this.layoutViewField_gridColumn10.Name = "layoutViewField_gridColumn10";
            this.layoutViewField_gridColumn10.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn10.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn10.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Hareket Alt Kat.";
            this.gridColumn11.ColumnEdit = this.repositoryItemLookUpEdit5;
            this.gridColumn11.FieldName = "HAREKET_ALT_KATEGORI_ID";
            this.gridColumn11.LayoutViewField = this.layoutViewField_gridColumn11;
            this.gridColumn11.Name = "gridColumn11";
            // 
            // repositoryItemLookUpEdit5
            // 
            this.repositoryItemLookUpEdit5.AutoHeight = false;
            this.repositoryItemLookUpEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit5.Name = "repositoryItemLookUpEdit5";
            // 
            // layoutViewField_gridColumn11
            // 
            this.layoutViewField_gridColumn11.EditorPreferredWidth = 340;
            this.layoutViewField_gridColumn11.Location = new System.Drawing.Point(158, 108);
            this.layoutViewField_gridColumn11.Name = "layoutViewField_gridColumn11";
            this.layoutViewField_gridColumn11.Size = new System.Drawing.Size(475, 27);
            this.layoutViewField_gridColumn11.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn11.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Belge Tür";
            this.gridColumn12.ColumnEdit = this.repositoryItemLookUpEdit6;
            this.gridColumn12.FieldName = "BELGE_TUR_ID";
            this.gridColumn12.LayoutViewField = this.layoutViewField_gridColumn12;
            this.gridColumn12.Name = "gridColumn12";
            // 
            // repositoryItemLookUpEdit6
            // 
            this.repositoryItemLookUpEdit6.AutoHeight = false;
            this.repositoryItemLookUpEdit6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit6.Name = "repositoryItemLookUpEdit6";
            // 
            // layoutViewField_gridColumn12
            // 
            this.layoutViewField_gridColumn12.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn12.Location = new System.Drawing.Point(0, 135);
            this.layoutViewField_gridColumn12.Name = "layoutViewField_gridColumn12";
            this.layoutViewField_gridColumn12.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn12.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn12.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Belge No";
            this.gridColumn13.FieldName = "BELGE_NO";
            this.gridColumn13.LayoutViewField = this.layoutViewField_gridColumn13;
            this.gridColumn13.Name = "gridColumn13";
            // 
            // layoutViewField_gridColumn13
            // 
            this.layoutViewField_gridColumn13.EditorPreferredWidth = 340;
            this.layoutViewField_gridColumn13.Location = new System.Drawing.Point(158, 135);
            this.layoutViewField_gridColumn13.Name = "layoutViewField_gridColumn13";
            this.layoutViewField_gridColumn13.Size = new System.Drawing.Size(475, 27);
            this.layoutViewField_gridColumn13.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn13.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Borç Alacak";
            this.gridColumn14.ColumnEdit = this.repositoryItemLookUpEdit7;
            this.gridColumn14.FieldName = "BORC_ALACAK_ID";
            this.gridColumn14.LayoutViewField = this.layoutViewField_gridColumn14;
            this.gridColumn14.Name = "gridColumn14";
            // 
            // repositoryItemLookUpEdit7
            // 
            this.repositoryItemLookUpEdit7.AutoHeight = false;
            this.repositoryItemLookUpEdit7.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit7.Name = "repositoryItemLookUpEdit7";
            // 
            // layoutViewField_gridColumn14
            // 
            this.layoutViewField_gridColumn14.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn14.Location = new System.Drawing.Point(158, 162);
            this.layoutViewField_gridColumn14.Name = "layoutViewField_gridColumn14";
            this.layoutViewField_gridColumn14.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn14.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn14.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Adet";
            this.gridColumn15.FieldName = "ADET";
            this.gridColumn15.LayoutViewField = this.layoutViewField_gridColumn15;
            this.gridColumn15.Name = "gridColumn15";
            // 
            // layoutViewField_gridColumn15
            // 
            this.layoutViewField_gridColumn15.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn15.Location = new System.Drawing.Point(0, 162);
            this.layoutViewField_gridColumn15.Name = "layoutViewField_gridColumn15";
            this.layoutViewField_gridColumn15.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn15.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn15.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Açýk Kapalý";
            this.gridColumn16.ColumnEdit = this.repositoryItemLookUpEdit8;
            this.gridColumn16.FieldName = "ACIK_KAPALI_ID";
            this.gridColumn16.LayoutViewField = this.layoutViewField_gridColumn16;
            this.gridColumn16.Name = "gridColumn16";
            // 
            // repositoryItemLookUpEdit8
            // 
            this.repositoryItemLookUpEdit8.AutoHeight = false;
            this.repositoryItemLookUpEdit8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit8.Name = "repositoryItemLookUpEdit8";
            // 
            // layoutViewField_gridColumn16
            // 
            this.layoutViewField_gridColumn16.EditorPreferredWidth = 182;
            this.layoutViewField_gridColumn16.Location = new System.Drawing.Point(316, 162);
            this.layoutViewField_gridColumn16.Name = "layoutViewField_gridColumn16";
            this.layoutViewField_gridColumn16.Size = new System.Drawing.Size(317, 27);
            this.layoutViewField_gridColumn16.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn16.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Vadesi";
            this.gridColumn17.FieldName = "VADESI";
            this.gridColumn17.LayoutViewField = this.layoutViewField_gridColumn17;
            this.gridColumn17.Name = "gridColumn17";
            // 
            // layoutViewField_gridColumn17
            // 
            this.layoutViewField_gridColumn17.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn17.Location = new System.Drawing.Point(0, 189);
            this.layoutViewField_gridColumn17.Name = "layoutViewField_gridColumn17";
            this.layoutViewField_gridColumn17.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn17.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn17.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Açýklama";
            this.gridColumn18.FieldName = "ACIKLAMA";
            this.gridColumn18.LayoutViewField = this.layoutViewField_gridColumn18;
            this.gridColumn18.Name = "gridColumn18";
            // 
            // layoutViewField_gridColumn18
            // 
            this.layoutViewField_gridColumn18.EditorPreferredWidth = 498;
            this.layoutViewField_gridColumn18.Location = new System.Drawing.Point(0, 621);
            this.layoutViewField_gridColumn18.Name = "layoutViewField_gridColumn18";
            this.layoutViewField_gridColumn18.Size = new System.Drawing.Size(633, 27);
            this.layoutViewField_gridColumn18.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn18.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Görünüm Sýra No";
            this.gridColumn19.FieldName = "GORUNUM_SIRA_NO";
            this.gridColumn19.LayoutViewField = this.layoutViewField_gridColumn19;
            this.gridColumn19.Name = "gridColumn19";
            // 
            // layoutViewField_gridColumn19
            // 
            this.layoutViewField_gridColumn19.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn19.Location = new System.Drawing.Point(158, 189);
            this.layoutViewField_gridColumn19.Name = "layoutViewField_gridColumn19";
            this.layoutViewField_gridColumn19.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn19.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn19.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "H. Sonucu Oluþtumu";
            this.gridColumn20.FieldName = "HESAPLAMA_SONUCUMU_OLUSTU";
            this.gridColumn20.LayoutViewField = this.layoutViewField_gridColumn20;
            this.gridColumn20.Name = "gridColumn20";
            // 
            // layoutViewField_gridColumn20
            // 
            this.layoutViewField_gridColumn20.EditorPreferredWidth = 182;
            this.layoutViewField_gridColumn20.Location = new System.Drawing.Point(316, 189);
            this.layoutViewField_gridColumn20.Name = "layoutViewField_gridColumn20";
            this.layoutViewField_gridColumn20.Size = new System.Drawing.Size(317, 27);
            this.layoutViewField_gridColumn20.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn20.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Brm.";
            this.gridColumn21.ColumnEdit = this.repositoryItemLookUpEdit9;
            this.gridColumn21.FieldName = "DOVIZ_ID";
            this.gridColumn21.LayoutViewField = this.layoutViewField_gridColumn21;
            this.gridColumn21.Name = "gridColumn21";
            // 
            // repositoryItemLookUpEdit9
            // 
            this.repositoryItemLookUpEdit9.AutoHeight = false;
            this.repositoryItemLookUpEdit9.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit9.Name = "repositoryItemLookUpEdit9";
            // 
            // layoutViewField_gridColumn21
            // 
            this.layoutViewField_gridColumn21.EditorPreferredWidth = 340;
            this.layoutViewField_gridColumn21.Location = new System.Drawing.Point(158, 216);
            this.layoutViewField_gridColumn21.Name = "layoutViewField_gridColumn21";
            this.layoutViewField_gridColumn21.Size = new System.Drawing.Size(475, 27);
            this.layoutViewField_gridColumn21.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn21.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "KDV`siz Tutar";
            this.gridColumn22.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.gridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn22.FieldName = "TUTAR_KDV_SIZ";
            this.gridColumn22.LayoutViewField = this.layoutViewField_gridColumn22;
            this.gridColumn22.Name = "gridColumn22";
            // 
            // layoutViewField_gridColumn22
            // 
            this.layoutViewField_gridColumn22.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn22.Location = new System.Drawing.Point(0, 216);
            this.layoutViewField_gridColumn22.Name = "layoutViewField_gridColumn22";
            this.layoutViewField_gridColumn22.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn22.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn22.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "KDV li Tutar";
            this.gridColumn23.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.gridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn23.FieldName = "TUTAR_KDV_LI";
            this.gridColumn23.LayoutViewField = this.layoutViewField_gridColumn23;
            this.gridColumn23.Name = "gridColumn23";
            // 
            // layoutViewField_gridColumn23
            // 
            this.layoutViewField_gridColumn23.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn23.Location = new System.Drawing.Point(0, 243);
            this.layoutViewField_gridColumn23.Name = "layoutViewField_gridColumn23";
            this.layoutViewField_gridColumn23.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn23.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn23.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "KDV siz Toplam Tutar";
            this.gridColumn24.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.gridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn24.FieldName = "TOPLAM_TUTAR_KDV_SIZ";
            this.gridColumn24.LayoutViewField = this.layoutViewField_gridColumn24;
            this.gridColumn24.Name = "gridColumn24";
            // 
            // layoutViewField_gridColumn24
            // 
            this.layoutViewField_gridColumn24.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn24.Location = new System.Drawing.Point(158, 243);
            this.layoutViewField_gridColumn24.Name = "layoutViewField_gridColumn24";
            this.layoutViewField_gridColumn24.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn24.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn24.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "KDV li Toplam Tutar";
            this.gridColumn25.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.gridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn25.FieldName = "TOPLAM_TUTAR_KDV_LI";
            this.gridColumn25.LayoutViewField = this.layoutViewField_gridColumn25;
            this.gridColumn25.Name = "gridColumn25";
            // 
            // layoutViewField_gridColumn25
            // 
            this.layoutViewField_gridColumn25.EditorPreferredWidth = 182;
            this.layoutViewField_gridColumn25.Location = new System.Drawing.Point(316, 243);
            this.layoutViewField_gridColumn25.Name = "layoutViewField_gridColumn25";
            this.layoutViewField_gridColumn25.Size = new System.Drawing.Size(317, 27);
            this.layoutViewField_gridColumn25.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn25.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "KDV Toplamý";
            this.gridColumn26.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.gridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn26.FieldName = "TOPLAM_KDV";
            this.gridColumn26.LayoutViewField = this.layoutViewField_gridColumn26;
            this.gridColumn26.Name = "gridColumn26";
            // 
            // layoutViewField_gridColumn26
            // 
            this.layoutViewField_gridColumn26.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn26.Location = new System.Drawing.Point(158, 270);
            this.layoutViewField_gridColumn26.Name = "layoutViewField_gridColumn26";
            this.layoutViewField_gridColumn26.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn26.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn26.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "SSDF Toplamý";
            this.gridColumn27.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.gridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn27.FieldName = "TOPLAM_TUTAR_SSDF";
            this.gridColumn27.LayoutViewField = this.layoutViewField_gridColumn27;
            this.gridColumn27.Name = "gridColumn27";
            // 
            // layoutViewField_gridColumn27
            // 
            this.layoutViewField_gridColumn27.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn27.Location = new System.Drawing.Point(0, 270);
            this.layoutViewField_gridColumn27.Name = "layoutViewField_gridColumn27";
            this.layoutViewField_gridColumn27.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn27.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn27.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "STOPAJ Toplamý";
            this.gridColumn28.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.gridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn28.FieldName = "TOPLAM_TUTAR_STOPAJ";
            this.gridColumn28.LayoutViewField = this.layoutViewField_gridColumn28;
            this.gridColumn28.Name = "gridColumn28";
            // 
            // layoutViewField_gridColumn28
            // 
            this.layoutViewField_gridColumn28.EditorPreferredWidth = 182;
            this.layoutViewField_gridColumn28.Location = new System.Drawing.Point(316, 270);
            this.layoutViewField_gridColumn28.Name = "layoutViewField_gridColumn28";
            this.layoutViewField_gridColumn28.Size = new System.Drawing.Size(317, 27);
            this.layoutViewField_gridColumn28.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn28.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Brm.";
            this.gridColumn29.ColumnEdit = this.repositoryItemLookUpEdit9;
            this.gridColumn29.FieldName = "FATURALI_MIKTAR_DOVIZ_ID";
            this.gridColumn29.LayoutViewField = this.layoutViewField_gridColumn29;
            this.gridColumn29.Name = "gridColumn29";
            // 
            // layoutViewField_gridColumn29
            // 
            this.layoutViewField_gridColumn29.EditorPreferredWidth = 340;
            this.layoutViewField_gridColumn29.Location = new System.Drawing.Point(158, 297);
            this.layoutViewField_gridColumn29.Name = "layoutViewField_gridColumn29";
            this.layoutViewField_gridColumn29.Size = new System.Drawing.Size(475, 27);
            this.layoutViewField_gridColumn29.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn29.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "Faturali Miktar";
            this.gridColumn30.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.gridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn30.FieldName = "FATURALI_MIKTAR";
            this.gridColumn30.LayoutViewField = this.layoutViewField_gridColumn30;
            this.gridColumn30.Name = "gridColumn30";
            // 
            // layoutViewField_gridColumn30
            // 
            this.layoutViewField_gridColumn30.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn30.Location = new System.Drawing.Point(0, 297);
            this.layoutViewField_gridColumn30.Name = "layoutViewField_gridColumn30";
            this.layoutViewField_gridColumn30.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn30.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn30.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Bakiye Tutar";
            this.gridColumn31.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.gridColumn31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn31.FieldName = "BAKIYE_TUTAR";
            this.gridColumn31.LayoutViewField = this.layoutViewField_gridColumn31;
            this.gridColumn31.Name = "gridColumn31";
            // 
            // layoutViewField_gridColumn31
            // 
            this.layoutViewField_gridColumn31.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn31.Location = new System.Drawing.Point(0, 324);
            this.layoutViewField_gridColumn31.Name = "layoutViewField_gridColumn31";
            this.layoutViewField_gridColumn31.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn31.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn31.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "Bakiye Toplam";
            this.gridColumn32.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.gridColumn32.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn32.FieldName = "BAKIYE_TOPLAM";
            this.gridColumn32.LayoutViewField = this.layoutViewField_gridColumn32;
            this.gridColumn32.Name = "gridColumn32";
            // 
            // layoutViewField_gridColumn32
            // 
            this.layoutViewField_gridColumn32.EditorPreferredWidth = 340;
            this.layoutViewField_gridColumn32.Location = new System.Drawing.Point(158, 324);
            this.layoutViewField_gridColumn32.Name = "layoutViewField_gridColumn32";
            this.layoutViewField_gridColumn32.Size = new System.Drawing.Size(475, 27);
            this.layoutViewField_gridColumn32.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn32.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Bakiye Alacak";
            this.gridColumn33.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.gridColumn33.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn33.FieldName = "BAKIYE_ALACAK";
            this.gridColumn33.LayoutViewField = this.layoutViewField_gridColumn33;
            this.gridColumn33.Name = "gridColumn33";
            // 
            // layoutViewField_gridColumn33
            // 
            this.layoutViewField_gridColumn33.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn33.Location = new System.Drawing.Point(0, 351);
            this.layoutViewField_gridColumn33.Name = "layoutViewField_gridColumn33";
            this.layoutViewField_gridColumn33.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn33.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn33.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "Bakiye Borç";
            this.gridColumn34.DisplayFormat.FormatString = "###,###,###,###,##0.00 ";
            this.gridColumn34.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn34.FieldName = "BAKIYE_BORC";
            this.gridColumn34.LayoutViewField = this.layoutViewField_gridColumn34;
            this.gridColumn34.Name = "gridColumn34";
            // 
            // layoutViewField_gridColumn34
            // 
            this.layoutViewField_gridColumn34.EditorPreferredWidth = 340;
            this.layoutViewField_gridColumn34.Location = new System.Drawing.Point(158, 351);
            this.layoutViewField_gridColumn34.Name = "layoutViewField_gridColumn34";
            this.layoutViewField_gridColumn34.Size = new System.Drawing.Size(475, 27);
            this.layoutViewField_gridColumn34.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn34.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "Özel Föy Kod";
            this.gridColumn35.ColumnEdit = this.repositoryItemLookUpEdit10;
            this.gridColumn35.FieldName = "OZEL_FOY_KOD_ID";
            this.gridColumn35.LayoutViewField = this.layoutViewField_gridColumn35;
            this.gridColumn35.Name = "gridColumn35";
            // 
            // repositoryItemLookUpEdit10
            // 
            this.repositoryItemLookUpEdit10.AutoHeight = false;
            this.repositoryItemLookUpEdit10.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit10.Name = "repositoryItemLookUpEdit10";
            // 
            // layoutViewField_gridColumn35
            // 
            this.layoutViewField_gridColumn35.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn35.Location = new System.Drawing.Point(0, 378);
            this.layoutViewField_gridColumn35.Name = "layoutViewField_gridColumn35";
            this.layoutViewField_gridColumn35.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn35.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn35.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "Þahýs Özel Kod";
            this.gridColumn36.ColumnEdit = this.repositoryItemLookUpEdit11;
            this.gridColumn36.FieldName = "OZEL_CARI_KOD_ID";
            this.gridColumn36.LayoutViewField = this.layoutViewField_gridColumn36;
            this.gridColumn36.Name = "gridColumn36";
            // 
            // repositoryItemLookUpEdit11
            // 
            this.repositoryItemLookUpEdit11.AutoHeight = false;
            this.repositoryItemLookUpEdit11.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit11.Name = "repositoryItemLookUpEdit11";
            // 
            // layoutViewField_gridColumn36
            // 
            this.layoutViewField_gridColumn36.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn36.Location = new System.Drawing.Point(158, 378);
            this.layoutViewField_gridColumn36.Name = "layoutViewField_gridColumn36";
            this.layoutViewField_gridColumn36.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn36.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn36.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "Belge Özel Kod";
            this.gridColumn37.ColumnEdit = this.repositoryItemLookUpEdit12;
            this.gridColumn37.FieldName = "BELGE_OZEL_KOD_ID";
            this.gridColumn37.LayoutViewField = this.layoutViewField_gridColumn37;
            this.gridColumn37.Name = "gridColumn37";
            // 
            // repositoryItemLookUpEdit12
            // 
            this.repositoryItemLookUpEdit12.AutoHeight = false;
            this.repositoryItemLookUpEdit12.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit12.Name = "repositoryItemLookUpEdit12";
            // 
            // layoutViewField_gridColumn37
            // 
            this.layoutViewField_gridColumn37.EditorPreferredWidth = 182;
            this.layoutViewField_gridColumn37.Location = new System.Drawing.Point(316, 378);
            this.layoutViewField_gridColumn37.Name = "layoutViewField_gridColumn37";
            this.layoutViewField_gridColumn37.Size = new System.Drawing.Size(317, 27);
            this.layoutViewField_gridColumn37.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn37.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "Taraf";
            this.gridColumn38.ColumnEdit = this.repositoryItemLookUpEdit13;
            this.gridColumn38.FieldName = "TARAF_ID";
            this.gridColumn38.LayoutViewField = this.layoutViewField_gridColumn38;
            this.gridColumn38.Name = "gridColumn38";
            // 
            // repositoryItemLookUpEdit13
            // 
            this.repositoryItemLookUpEdit13.AutoHeight = false;
            this.repositoryItemLookUpEdit13.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit13.Name = "repositoryItemLookUpEdit13";
            // 
            // layoutViewField_gridColumn38
            // 
            this.layoutViewField_gridColumn38.EditorPreferredWidth = 498;
            this.layoutViewField_gridColumn38.Location = new System.Drawing.Point(0, 405);
            this.layoutViewField_gridColumn38.Name = "layoutViewField_gridColumn38";
            this.layoutViewField_gridColumn38.Size = new System.Drawing.Size(633, 27);
            this.layoutViewField_gridColumn38.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn38.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn39
            // 
            this.gridColumn39.Caption = "Ýþ Kaydedilsin mi";
            this.gridColumn39.FieldName = "IS_KAYDEDILSIN_MI";
            this.gridColumn39.LayoutViewField = this.layoutViewField_gridColumn39;
            this.gridColumn39.Name = "gridColumn39";
            // 
            // layoutViewField_gridColumn39
            // 
            this.layoutViewField_gridColumn39.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn39.Location = new System.Drawing.Point(158, 432);
            this.layoutViewField_gridColumn39.Name = "layoutViewField_gridColumn39";
            this.layoutViewField_gridColumn39.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn39.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn39.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn40
            // 
            this.gridColumn40.Caption = "Hatýrlatýlsýn mý";
            this.gridColumn40.FieldName = "HATIRLATILSIN_MI";
            this.gridColumn40.LayoutViewField = this.layoutViewField_gridColumn40;
            this.gridColumn40.Name = "gridColumn40";
            // 
            // layoutViewField_gridColumn40
            // 
            this.layoutViewField_gridColumn40.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn40.Location = new System.Drawing.Point(0, 432);
            this.layoutViewField_gridColumn40.Name = "layoutViewField_gridColumn40";
            this.layoutViewField_gridColumn40.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn40.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn40.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn41
            // 
            this.gridColumn41.Caption = "Ajanda da Görünsün mü";
            this.gridColumn41.FieldName = "AJANDADA_GORUNSUN_MU";
            this.gridColumn41.LayoutViewField = this.layoutViewField_gridColumn41;
            this.gridColumn41.Name = "gridColumn41";
            // 
            // layoutViewField_gridColumn41
            // 
            this.layoutViewField_gridColumn41.EditorPreferredWidth = 182;
            this.layoutViewField_gridColumn41.Location = new System.Drawing.Point(316, 432);
            this.layoutViewField_gridColumn41.Name = "layoutViewField_gridColumn41";
            this.layoutViewField_gridColumn41.Size = new System.Drawing.Size(317, 27);
            this.layoutViewField_gridColumn41.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn41.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn42
            // 
            this.gridColumn42.Caption = "Süre";
            this.gridColumn42.FieldName = "SURE";
            this.gridColumn42.LayoutViewField = this.layoutViewField_gridColumn42;
            this.gridColumn42.Name = "gridColumn42";
            // 
            // layoutViewField_gridColumn42
            // 
            this.layoutViewField_gridColumn42.EditorPreferredWidth = 102;
            this.layoutViewField_gridColumn42.Location = new System.Drawing.Point(0, 459);
            this.layoutViewField_gridColumn42.Name = "layoutViewField_gridColumn42";
            this.layoutViewField_gridColumn42.Size = new System.Drawing.Size(237, 27);
            this.layoutViewField_gridColumn42.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn42.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn43
            // 
            this.gridColumn43.Caption = "Ozel Tutar";
            this.gridColumn43.ColumnEdit = this.repositoryItemLookUpEdit14;
            this.gridColumn43.FieldName = "OZEL_TUTAR_ID";
            this.gridColumn43.LayoutViewField = this.layoutViewField_gridColumn43;
            this.gridColumn43.Name = "gridColumn43";
            // 
            // repositoryItemLookUpEdit14
            // 
            this.repositoryItemLookUpEdit14.AutoHeight = false;
            this.repositoryItemLookUpEdit14.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit14.Name = "repositoryItemLookUpEdit14";
            // 
            // layoutViewField_gridColumn43
            // 
            this.layoutViewField_gridColumn43.EditorPreferredWidth = 261;
            this.layoutViewField_gridColumn43.Location = new System.Drawing.Point(237, 459);
            this.layoutViewField_gridColumn43.Name = "layoutViewField_gridColumn43";
            this.layoutViewField_gridColumn43.Size = new System.Drawing.Size(396, 27);
            this.layoutViewField_gridColumn43.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn43.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn44
            // 
            this.gridColumn44.Caption = "Tutar Paylaþýlacak mý";
            this.gridColumn44.FieldName = "TUTAR_PAYLASTIRILCAK_MI";
            this.gridColumn44.LayoutViewField = this.layoutViewField_gridColumn44;
            this.gridColumn44.Name = "gridColumn44";
            // 
            // layoutViewField_gridColumn44
            // 
            this.layoutViewField_gridColumn44.EditorPreferredWidth = 340;
            this.layoutViewField_gridColumn44.Location = new System.Drawing.Point(0, 486);
            this.layoutViewField_gridColumn44.Name = "layoutViewField_gridColumn44";
            this.layoutViewField_gridColumn44.Size = new System.Drawing.Size(475, 27);
            this.layoutViewField_gridColumn44.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn44.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn45
            // 
            this.gridColumn45.Caption = "KDV Hesaplanacak mý";
            this.gridColumn45.FieldName = "HESAPLANACAKMI_KDV";
            this.gridColumn45.LayoutViewField = this.layoutViewField_gridColumn45;
            this.gridColumn45.Name = "gridColumn45";
            // 
            // layoutViewField_gridColumn45
            // 
            this.layoutViewField_gridColumn45.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn45.Location = new System.Drawing.Point(475, 486);
            this.layoutViewField_gridColumn45.Name = "layoutViewField_gridColumn45";
            this.layoutViewField_gridColumn45.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn45.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn45.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn46
            // 
            this.gridColumn46.Caption = "SSDF Hesaplanacak mý";
            this.gridColumn46.FieldName = "HESAPLANACAKMI_STOPAJ_SSDF";
            this.gridColumn46.LayoutViewField = this.layoutViewField_gridColumn46;
            this.gridColumn46.Name = "gridColumn46";
            // 
            // layoutViewField_gridColumn46
            // 
            this.layoutViewField_gridColumn46.EditorPreferredWidth = 24;
            this.layoutViewField_gridColumn46.Location = new System.Drawing.Point(474, 513);
            this.layoutViewField_gridColumn46.Name = "layoutViewField_gridColumn46";
            this.layoutViewField_gridColumn46.Size = new System.Drawing.Size(159, 27);
            this.layoutViewField_gridColumn46.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn46.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn47
            // 
            this.gridColumn47.Caption = "KDV Dahil mi";
            this.gridColumn47.FieldName = "ICINDEMI_KDV";
            this.gridColumn47.LayoutViewField = this.layoutViewField_gridColumn47;
            this.gridColumn47.Name = "gridColumn47";
            // 
            // layoutViewField_gridColumn47
            // 
            this.layoutViewField_gridColumn47.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn47.Location = new System.Drawing.Point(158, 513);
            this.layoutViewField_gridColumn47.Name = "layoutViewField_gridColumn47";
            this.layoutViewField_gridColumn47.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn47.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn47.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn48
            // 
            this.gridColumn48.Caption = "SSDF Dahil mi";
            this.gridColumn48.FieldName = "ICINDEMI_STOPAJ_SSDF";
            this.gridColumn48.LayoutViewField = this.layoutViewField_gridColumn48;
            this.gridColumn48.Name = "gridColumn48";
            // 
            // layoutViewField_gridColumn48
            // 
            this.layoutViewField_gridColumn48.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn48.Location = new System.Drawing.Point(316, 513);
            this.layoutViewField_gridColumn48.Name = "layoutViewField_gridColumn48";
            this.layoutViewField_gridColumn48.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn48.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn48.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn49
            // 
            this.gridColumn49.Caption = "Muhasebe Arkadaþlýk";
            this.gridColumn49.ColumnEdit = this.repositoryItemLookUpEdit15;
            this.gridColumn49.FieldName = "MUHASEBE_ARKADASLIK_ID";
            this.gridColumn49.LayoutViewField = this.layoutViewField_gridColumn49;
            this.gridColumn49.Name = "gridColumn49";
            // 
            // repositoryItemLookUpEdit15
            // 
            this.repositoryItemLookUpEdit15.AutoHeight = false;
            this.repositoryItemLookUpEdit15.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit15.Name = "repositoryItemLookUpEdit15";
            // 
            // layoutViewField_gridColumn49
            // 
            this.layoutViewField_gridColumn49.EditorPreferredWidth = 182;
            this.layoutViewField_gridColumn49.Location = new System.Drawing.Point(316, 540);
            this.layoutViewField_gridColumn49.Name = "layoutViewField_gridColumn49";
            this.layoutViewField_gridColumn49.Size = new System.Drawing.Size(317, 27);
            this.layoutViewField_gridColumn49.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn49.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn50
            // 
            this.gridColumn50.Caption = "Tutar Paylaþtýrýlsýn mý";
            this.gridColumn50.FieldName = "TUTAR_PAYLASTIRILMISMI";
            this.gridColumn50.LayoutViewField = this.layoutViewField_gridColumn50;
            this.gridColumn50.Name = "gridColumn50";
            // 
            // layoutViewField_gridColumn50
            // 
            this.layoutViewField_gridColumn50.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn50.Location = new System.Drawing.Point(0, 513);
            this.layoutViewField_gridColumn50.Name = "layoutViewField_gridColumn50";
            this.layoutViewField_gridColumn50.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn50.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn50.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn51
            // 
            this.gridColumn51.Caption = "Taraf Tip";
            this.gridColumn51.FieldName = "TARAF_TIP";
            this.gridColumn51.LayoutViewField = this.layoutViewField_gridColumn51;
            this.gridColumn51.Name = "gridColumn51";
            // 
            // layoutViewField_gridColumn51
            // 
            this.layoutViewField_gridColumn51.EditorPreferredWidth = 181;
            this.layoutViewField_gridColumn51.Location = new System.Drawing.Point(0, 540);
            this.layoutViewField_gridColumn51.Name = "layoutViewField_gridColumn51";
            this.layoutViewField_gridColumn51.Size = new System.Drawing.Size(316, 27);
            this.layoutViewField_gridColumn51.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn51.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn52
            // 
            this.gridColumn52.Caption = "Bölüþtürme";
            this.gridColumn52.FieldName = "BOLUSTURME";
            this.gridColumn52.LayoutViewField = this.layoutViewField_gridColumn52;
            this.gridColumn52.Name = "gridColumn52";
            // 
            // layoutViewField_gridColumn52
            // 
            this.layoutViewField_gridColumn52.EditorPreferredWidth = 182;
            this.layoutViewField_gridColumn52.Location = new System.Drawing.Point(316, 567);
            this.layoutViewField_gridColumn52.Name = "layoutViewField_gridColumn52";
            this.layoutViewField_gridColumn52.Size = new System.Drawing.Size(317, 27);
            this.layoutViewField_gridColumn52.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn52.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn53
            // 
            this.gridColumn53.Caption = "Otomatik Kayýtmý";
            this.gridColumn53.FieldName = "OTOMATIK_KAYIT_MI";
            this.gridColumn53.LayoutViewField = this.layoutViewField_gridColumn53;
            this.gridColumn53.Name = "gridColumn53";
            // 
            // layoutViewField_gridColumn53
            // 
            this.layoutViewField_gridColumn53.EditorPreferredWidth = 181;
            this.layoutViewField_gridColumn53.Location = new System.Drawing.Point(0, 567);
            this.layoutViewField_gridColumn53.Name = "layoutViewField_gridColumn53";
            this.layoutViewField_gridColumn53.Size = new System.Drawing.Size(316, 27);
            this.layoutViewField_gridColumn53.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn53.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn54
            // 
            this.gridColumn54.Caption = "Borclu Odeme";
            this.gridColumn54.ColumnEdit = this.repositoryItemLookUpEdit16;
            this.gridColumn54.FieldName = "BORCLU_ODEME_ID";
            this.gridColumn54.LayoutViewField = this.layoutViewField_gridColumn54;
            this.gridColumn54.Name = "gridColumn54";
            // 
            // repositoryItemLookUpEdit16
            // 
            this.repositoryItemLookUpEdit16.AutoHeight = false;
            this.repositoryItemLookUpEdit16.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit16.Name = "repositoryItemLookUpEdit16";
            // 
            // layoutViewField_gridColumn54
            // 
            this.layoutViewField_gridColumn54.EditorPreferredWidth = 24;
            this.layoutViewField_gridColumn54.Location = new System.Drawing.Point(474, 594);
            this.layoutViewField_gridColumn54.Name = "layoutViewField_gridColumn54";
            this.layoutViewField_gridColumn54.Size = new System.Drawing.Size(159, 27);
            this.layoutViewField_gridColumn54.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn54.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn55
            // 
            this.gridColumn55.Caption = "Tebligat";
            this.gridColumn55.ColumnEdit = this.repositoryItemLookUpEdit17;
            this.gridColumn55.FieldName = "TEBLIGAT_ID";
            this.gridColumn55.LayoutViewField = this.layoutViewField_gridColumn55;
            this.gridColumn55.Name = "gridColumn55";
            // 
            // repositoryItemLookUpEdit17
            // 
            this.repositoryItemLookUpEdit17.AutoHeight = false;
            this.repositoryItemLookUpEdit17.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit17.Name = "repositoryItemLookUpEdit17";
            // 
            // layoutViewField_gridColumn55
            // 
            this.layoutViewField_gridColumn55.EditorPreferredWidth = 181;
            this.layoutViewField_gridColumn55.Location = new System.Drawing.Point(0, 594);
            this.layoutViewField_gridColumn55.Name = "layoutViewField_gridColumn55";
            this.layoutViewField_gridColumn55.Size = new System.Drawing.Size(316, 27);
            this.layoutViewField_gridColumn55.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn55.TextSize = new System.Drawing.Size(119, 20);
            // 
            // gridColumn56
            // 
            this.gridColumn56.Caption = "Müvekkil Odeme";
            this.gridColumn56.ColumnEdit = this.repositoryItemLookUpEdit16;
            this.gridColumn56.FieldName = "MUVEKKILE_ODEME_ID";
            this.gridColumn56.LayoutViewField = this.layoutViewField_gridColumn56;
            this.gridColumn56.Name = "gridColumn56";
            // 
            // layoutViewField_gridColumn56
            // 
            this.layoutViewField_gridColumn56.EditorPreferredWidth = 23;
            this.layoutViewField_gridColumn56.Location = new System.Drawing.Point(316, 594);
            this.layoutViewField_gridColumn56.Name = "layoutViewField_gridColumn56";
            this.layoutViewField_gridColumn56.Size = new System.Drawing.Size(158, 27);
            this.layoutViewField_gridColumn56.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn56.TextSize = new System.Drawing.Size(119, 20);
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "layoutViewTemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_gridColumn1,
            this.layoutViewField_gridColumn4,
            this.layoutViewField_gridColumn6,
            this.layoutViewField_gridColumn8,
            this.layoutViewField_gridColumn10,
            this.layoutViewField_gridColumn12,
            this.layoutViewField_gridColumn14,
            this.layoutViewField_gridColumn17,
            this.layoutViewField_gridColumn21,
            this.layoutViewField_gridColumn23,
            this.layoutViewField_gridColumn26,
            this.layoutViewField_gridColumn29,
            this.layoutViewField_gridColumn31,
            this.layoutViewField_gridColumn33,
            this.layoutViewField_gridColumn35,
            this.layoutViewField_gridColumn38,
            this.layoutViewField_gridColumn39,
            this.layoutViewField_gridColumn42,
            this.layoutViewField_gridColumn45,
            this.layoutViewField_gridColumn46,
            this.layoutViewField_gridColumn49,
            this.layoutViewField_gridColumn52,
            this.layoutViewField_gridColumn54,
            this.layoutViewField_gridColumn2,
            this.layoutViewField_gridColumn3,
            this.layoutViewField_gridColumn5,
            this.layoutViewField_gridColumn7,
            this.layoutViewField_gridColumn9,
            this.layoutViewField_gridColumn11,
            this.layoutViewField_gridColumn13,
            this.layoutViewField_gridColumn15,
            this.layoutViewField_gridColumn16,
            this.layoutViewField_gridColumn19,
            this.layoutViewField_gridColumn22,
            this.layoutViewField_gridColumn20,
            this.layoutViewField_gridColumn24,
            this.layoutViewField_gridColumn25,
            this.layoutViewField_gridColumn27,
            this.layoutViewField_gridColumn28,
            this.layoutViewField_gridColumn30,
            this.layoutViewField_gridColumn32,
            this.layoutViewField_gridColumn34,
            this.layoutViewField_gridColumn36,
            this.layoutViewField_gridColumn37,
            this.layoutViewField_gridColumn40,
            this.layoutViewField_gridColumn41,
            this.layoutViewField_gridColumn43,
            this.layoutViewField_gridColumn44,
            this.layoutViewField_gridColumn47,
            this.layoutViewField_gridColumn48,
            this.layoutViewField_gridColumn50,
            this.layoutViewField_gridColumn18,
            this.layoutViewField_gridColumn51,
            this.layoutViewField_gridColumn53,
            this.layoutViewField_gridColumn55,
            this.layoutViewField_gridColumn56});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.extendedGridControl1;
            this.gridView3.Name = "gridView3";
            // 
            // ucHazirlikMuhasebeBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridMuhasebeBilgileri);
            this.Controls.Add(this.extendedGridControl1);
            this.Name = "ucHazirlikMuhasebeBilgileri";
            this.Size = new System.Drawing.Size(733, 499);
            this.Load += new System.EventHandler(this.ucMuhasebeBilgileri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMuhasebeBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwMuhasebeBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGorusme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOrtaklik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuhasebeCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHareketAnaKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHareketAltKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBelgetur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuhBorcAlacak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAcikKapaliID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuhasebeDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelFoyKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCariOzelKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBelgeOzelKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuhasebeTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOzelTutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuhasebeArkalik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkilOdeme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuhasebeTebligat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extendedGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridMuhasebeBilgileri;
        private DevExpress.XtraGrid.Views.Grid.GridView gwMuhasebeBilgileri;
        private DevExpress.XtraGrid.Columns.GridColumn colREFERANS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colHACIZ_SIRA_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colSATIS_SIRA_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colGORUSME_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueGorusme;
        private DevExpress.XtraGrid.Columns.GridColumn colORTAKLIK_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueOrtaklik;
        private DevExpress.XtraGrid.Columns.GridColumn colCARI_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMuhasebeCari;
        private DevExpress.XtraGrid.Columns.GridColumn colADINA_YAPAN_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colISLEMI_YAPAN_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colHAREKET_ANA_KATEGORI_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueHareketAnaKategori;
        private DevExpress.XtraGrid.Columns.GridColumn colHAREKET_ALT_KATEGORI_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueHareketAltKategori;
        private DevExpress.XtraGrid.Columns.GridColumn colBELGE_TUR_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBelgetur;
        private DevExpress.XtraGrid.Columns.GridColumn colBELGE_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colBORC_ALACAK_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMuhBorcAlacak;
        private DevExpress.XtraGrid.Columns.GridColumn colADET;
        private DevExpress.XtraGrid.Columns.GridColumn colACIK_KAPALI_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAcikKapaliID;
        private DevExpress.XtraGrid.Columns.GridColumn colVADESI;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colGORUNUM_SIRA_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colHESAPLAMA_SONUCUMU_OLUSTU;
        private DevExpress.XtraGrid.Columns.GridColumn colDOVIZ_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMuhasebeDoviz;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTAR_KDV_SIZ;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTAR_KDV_LI;
        private DevExpress.XtraGrid.Columns.GridColumn colTOPLAM_TUTAR_KDV_SIZ;
        private DevExpress.XtraGrid.Columns.GridColumn colTOPLAM_TUTAR_KDV_LI;
        private DevExpress.XtraGrid.Columns.GridColumn colTOPLAM_KDV;
        private DevExpress.XtraGrid.Columns.GridColumn colTOPLAM_TUTAR_SSDF;
        private DevExpress.XtraGrid.Columns.GridColumn colTOPLAM_TUTAR_STOPAJ;
        private DevExpress.XtraGrid.Columns.GridColumn colFATURALI_MIKTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colFATURALI_MIKTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colBAKIYE_TUTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colBAKIYE_TOPLAM;
        private DevExpress.XtraGrid.Columns.GridColumn colBAKIYE_ALACAK;
        private DevExpress.XtraGrid.Columns.GridColumn colBAKIYE_BORC;
        private DevExpress.XtraGrid.Columns.GridColumn colOZEL_FOY_KOD_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueOzelFoyKod;
        private DevExpress.XtraGrid.Columns.GridColumn colOZEL_CARI_KOD_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueCariOzelKod;
        private DevExpress.XtraGrid.Columns.GridColumn colBELGE_OZEL_KOD_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBelgeOzelKod;
        private DevExpress.XtraGrid.Columns.GridColumn colTARAF_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMuhasebeTaraf;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_KAYDEDILSIN_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colHATIRLATILSIN_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colAJANDADA_GORUNSUN_MU;
        private DevExpress.XtraGrid.Columns.GridColumn colSURE;
        private DevExpress.XtraGrid.Columns.GridColumn colOZEL_TUTAR_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueOzelTutar;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTAR_PAYLASTIRILCAK_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colHESAPLANACAKMI_KDV;
        private DevExpress.XtraGrid.Columns.GridColumn colHESAPLANACAKMI_STOPAJ_SSDF;
        private DevExpress.XtraGrid.Columns.GridColumn colICINDEMI_KDV;
        private DevExpress.XtraGrid.Columns.GridColumn colICINDEMI_STOPAJ_SSDF;
        private DevExpress.XtraGrid.Columns.GridColumn colMUHASEBE_ARKADASLIK_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMuhasebeArkalik;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTAR_PAYLASTIRILMISMI;
        private DevExpress.XtraGrid.Columns.GridColumn colTARAF_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn colBOLUSTURME;
        private DevExpress.XtraGrid.Columns.GridColumn colOTOMATIK_KAYIT_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colBORCLU_ODEME_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMuvekkilOdeme;
        private DevExpress.XtraGrid.Columns.GridColumn colTEBLIGAT_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMuhasebeTebligat;
        private DevExpress.XtraGrid.Columns.GridColumn colMUVEKKILE_ODEME_ID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl extendedGridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit7;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit9;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit10;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit11;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit12;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit13;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit14;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit15;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit16;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit17;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn34;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn38;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn41;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn42;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn43;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn44;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn45;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn46;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn47;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn48;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn49;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn50;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn51;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn52;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn53;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn54;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn55;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn56;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn4;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn5;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn6;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn7;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn8;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn9;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn10;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn11;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn12;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn13;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn14;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn15;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn16;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn17;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn18;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn19;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn20;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn21;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn22;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn23;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn24;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn25;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn26;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn27;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn28;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn29;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn30;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn31;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn32;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn33;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn34;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn35;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn36;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn37;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn38;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn39;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn40;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn41;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn42;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn43;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn44;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn45;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn46;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn47;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn48;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn49;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn50;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn51;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn52;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn53;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn54;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn55;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn56;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;


    }
}
