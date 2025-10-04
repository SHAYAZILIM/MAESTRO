using AdimAdimDavaKaydi.UserControls;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    partial class frmIcraDosyaKayit
    {
        #region Fields

        public AdimAdimDavaKaydi.Util.ExtendedGridControl gcAlacak;

        // private DevExpress.XtraEditors.SimpleButton btnIhtiyatiTedbir;
        public DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit rglkSorumluAvs;

        internal DevExpress.XtraEditors.PanelControl bottomPanel;
        internal DevExpress.XtraEditors.PanelControl pnSorumluAvukat;
        internal DevExpress.XtraEditors.PanelControl pnTakipEden;
        internal DevExpress.XtraEditors.PanelControl pnTakipEdilen;
        internal IcraTakip.UserControls.ucAlacakNedenTaraf_Faiz ucAlacakNedenTaraf_Faiz1;

        private DevExpress.XtraGrid.Columns.GridColumn ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn ADI;
        private DevExpress.XtraGrid.Columns.GridColumn ADLI_BIRIM_ADLIYE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn ADLI_BIRIM_GOREV_ID;
        private DevExpress.XtraGrid.Columns.GridColumn ADLI_BIRIM_NO_ID;
        private DevExpress.XtraGrid.Columns.GridColumn ALT_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn ARAC_MODEL;
        private DevExpress.XtraGrid.Columns.GridColumn ARAC_MOTOR_NO;
        private DevExpress.XtraGrid.Columns.GridColumn ARAC_PLAKA;
        private DevExpress.XtraGrid.Columns.GridColumn ARAC_RENK;
        private DevExpress.XtraGrid.Columns.GridColumn ARAC_SASI_NO;
        private DevExpress.XtraGrid.Columns.GridColumn ARAC_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn ARKASI_YAZILDI_MI;
        private System.Windows.Forms.BindingSource aV001TIBILFOYTARAFBindingSource;
        private System.Windows.Forms.BindingSource aV001TIBILFOYTARAFVEKILBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn BAGLAMA_LIMANI;
        private DevExpress.XtraGrid.Columns.GridColumn BANKA_ID;
        private DevExpress.XtraGrid.Columns.GridColumn BANKA_SUBE_KODU;

        //private DevExpress.XtraBars.BarSubItem barSubItem2;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //private DevExpress.XtraBars.BarSubItem barSubItem1;
        //private DevExpress.XtraBars.BarSubItem barSubItem3;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        //private DevExpress.XtraBars.BarSubItem barSubItem4;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        //private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;

        // private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.BarLinkContainerItem barLinkContainerItem1;
        private DevExpress.XtraGrid.Columns.GridColumn BASLANGIC_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn BEDELI;
        private DevExpress.XtraGrid.Columns.GridColumn BEDELI_DOVIZ_ID;

        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarEditItem beDurum;
        private DevExpress.XtraBars.BarEditItem beKayitIliski;
        private DevExpress.XtraGrid.Columns.GridColumn BITIRILME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn BITIS_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn BORC_IKRARINI_HAVI_MI;
        private DevExpress.XtraGrid.Columns.GridColumn BOYU;
        private System.Windows.Forms.BindingSource bsrcMyFoy;
        private System.ComponentModel.BackgroundWorker bwFoyuKaydet;
        private DevExpress.XtraGrid.Columns.GridColumn CEK_NO;
        private DevExpress.XtraGrid.Columns.GridColumn CINSI;
        private DevExpress.XtraGrid.Columns.GridColumn clmADLI_BIRIM_ADLIYE;
        private DevExpress.XtraGrid.Columns.GridColumn clmADLI_BIRIM_NO;
        private DevExpress.XtraGrid.Columns.GridColumn clmESAS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn clmFOY_NO;
        private DevExpress.XtraGrid.Columns.GridColumn clmTAKIP_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colALACAK_FAIZ_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colALACAK_NEDEN_KOD_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colAVUKAT_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colAVUKAT_CARI_ID1;
        private DevExpress.XtraGrid.Columns.GridColumn colBIR_GUNE_AYLIK_FAIZ;
        private DevExpress.XtraGrid.Columns.GridColumn colBIR_GUNE_AYLIK_FAIZ1;
        private DevExpress.XtraGrid.Columns.GridColumn colBSMV_HESAPLANSIN;
        private DevExpress.XtraGrid.Columns.GridColumn colCEK_TAZMINATI_ORANI;
        private DevExpress.XtraGrid.Columns.GridColumn colDAMGA_PULU_HESAPLANSIN;
        private DevExpress.XtraGrid.Columns.GridColumn colDIGER_ALACAK_NEDENI;
        private DevExpress.XtraGrid.Columns.GridColumn colDUZENLENME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_BASLANGIC_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_BASLANGIC_TARIHI1;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_BITIS_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_YOK;
        private DevExpress.XtraGrid.Columns.GridColumn colHARCA_ESAS_DEGER;
        private DevExpress.XtraGrid.Columns.GridColumn colHARCA_ESAS_DEGER_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colHER_AY_TAZMINAT_EKLE;
        private DevExpress.XtraGrid.Columns.GridColumn colHESAPLAMA_MODU;
        private DevExpress.XtraGrid.Columns.GridColumn colICRA_ALACAK_NEDEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colIHTAR_GIDERI;
        private DevExpress.XtraGrid.Columns.GridColumn colIHTAR_GIDERI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colIHTAR_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colISLEME_KONAN_TUTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colISLEME_KONAN_TUTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colKDV_HESAPLANSIN;
        private DevExpress.XtraGrid.Columns.GridColumn colKDV_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colKKDV_HESAPLANSIN;
        private DevExpress.XtraGrid.Columns.GridColumn colKOMISYONU_ORANI;
        private DevExpress.XtraGrid.Columns.GridColumn colOIV_HESAPLANSIN;
        private DevExpress.XtraGrid.Columns.GridColumn colPROTESTO_GIDERI;
        private DevExpress.XtraGrid.Columns.GridColumn colPROTESTO_GIDERI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colREFERANS_NO2;
        private DevExpress.XtraGrid.Columns.GridColumn colREFERANS_NO3;
        private DevExpress.XtraGrid.Columns.GridColumn colSABIT_FAIZ;
        private DevExpress.XtraGrid.Columns.GridColumn colSABIT_FAIZ_UYGULA;
        private DevExpress.XtraGrid.Columns.GridColumn colSURE_AY;
        private DevExpress.XtraGrid.Columns.GridColumn colSURE_GUN;
        private DevExpress.XtraGrid.Columns.GridColumn colSURE_YIL;
        private DevExpress.XtraGrid.Columns.GridColumn colTARAF_CARI_ID1;
        private DevExpress.XtraGrid.Columns.GridColumn colTAZMINATI_ORANI;
        private DevExpress.XtraGrid.Columns.GridColumn colTAZMINAT_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMSIL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMSIL_ID1;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMSIL_SEKLI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMSIL_SEKLI_ID1;
        private DevExpress.XtraGrid.Columns.GridColumn colTO_ALACAK_FAIZ_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTO_UYGULANACAK_FAIZ_ORANI;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colUYGULANACAK_FAIZ_ORANI;
        private DevExpress.XtraGrid.Columns.GridColumn colVADE_TARIHI;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.Columns.GridColumn CVV1;
        private DevExpress.XtraGrid.Columns.GridColumn CVV2;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit Date;
        private DevExpress.XtraGrid.Columns.GridColumn DERINLIGI;

        //private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        //private DevExpress.XtraBars.BarLargeButtonItem rbtnYeni;
        //private DevExpress.XtraBars.BarLargeButtonItem rbtnAc;
        //private DevExpress.XtraBars.BarLargeButtonItem rbtnKaydet;
        //private DevExpress.XtraBars.BarLargeButtonItem rbtnYazdir;
        //private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem6;
        //private DevExpress.XtraBars.BarLargeButtonItem rbtnFarkliKaydet;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraGrid.Columns.GridColumn DURUM_ACIKLAMA;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSozlesme;
        private DevExpress.XtraGrid.Columns.GridColumn ENI;
        private DevExpress.XtraGrid.Columns.GridColumn ERISIM_NO;
        private DevExpress.XtraGrid.Columns.GridColumn EVRAK_KAYIT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn EVRAK_TANZIM_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn EVRAK_TUR_ID;
        private DevExpress.XtraGrid.Columns.GridColumn EVRAK_VADE_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn FEK_TARIHI3;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcSorumluAvukat;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcTakipEden;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcTakipEdilen;
        private DevExpress.XtraGrid.Columns.GridColumn GEMI_UCAK_ARAC_TIP;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit glkIcraFoy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn141;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn143;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn144;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn151;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn159;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn164;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView11;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.GroupControl grpOnSayfaANeden;
        private DevExpress.XtraEditors.GroupControl grpSozlesmeBilgileri;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBagliKayit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSorumluAvukat;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTakipEden;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTakipEdenTarafVekil;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTakipEdilen;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTakipEdilenVekil;
        private DevExpress.XtraGrid.Views.Grid.GridView gwAlacak;
        private DevExpress.XtraGrid.Columns.GridColumn HAKEM_YARGILAMASININ_YERI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn HARC_ISTISNA_BELGE_NO;
        private DevExpress.XtraGrid.Columns.GridColumn HARC_ISTISNA_BELGE_TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn HARC_ISTISNA_ID;
        private DevExpress.XtraGrid.Columns.GridColumn HESAP_NO;
        private DevExpress.XtraGrid.Columns.GridColumn IHTAR_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn IHTAR_TEBLIG_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn ILK_ALACAKLI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn ILK_BORCLU_ID;
        private DevExpress.XtraGrid.Columns.GridColumn IMZA_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn INSA_YERI;
        private DevExpress.XtraGrid.Columns.GridColumn INSA_YILI;
        private DevExpress.XtraGrid.Columns.GridColumn ISLEMLER_BASLADIMI;
        private DevExpress.XtraGrid.Columns.GridColumn ISLEMLER_BASLADIMI1;
        private DevExpress.XtraGrid.Columns.GridColumn KARSILIK_TUTAR;
        private DevExpress.XtraGrid.Columns.GridColumn KARSILIK_TUTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn KART_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn KESIDE_YERI;

        //private DevExpress.XtraBars.BarButtonItem barButtonItem29;
        private DevExpress.XtraEditors.SplitterControl kEvrakSplitter;
        private DevExpress.XtraGrid.Columns.GridColumn KREDI_KART_NO;
        private DevExpress.XtraGrid.Columns.GridColumn KUTUK_BOYU;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow multiEditorRow1;

        //private DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem1;
        //private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        //private DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem2;
        //private DevExpress.XtraBars.BarButtonItem rbtnHesaplanmisKalemler;
        //private DevExpress.XtraBars.BarButtonItem rbtnIlamBilgileri;
        //private DevExpress.XtraBars.BarButtonItem rbtnIhtiyatiHaciz;
        //private DevExpress.XtraBars.BarButtonItem rbtnTakipOncesiOdemeler;
        //private DevExpress.XtraBars.BarButtonItem rbtnIhtiyatiTedbir;
        //private DevExpress.XtraBars.BarButtonItem rbtnTakipOnizleme;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow multiEditorRow39;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow multiEditorRow40;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow multiEditorRow41;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow multiEditorRow43;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow multiEditorRow44;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraGrid.Columns.GridColumn NE_SEKILDE_AHZOLUNDUGU;
        private DevExpress.XtraGrid.Columns.GridColumn NOTER_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn NOTER_YEVMIYE_NO;
        private DevExpress.XtraGrid.Columns.GridColumn ODEME_YERI;
        private DevExpress.XtraGrid.Columns.GridColumn OZEL_KOD1_ID;
        private DevExpress.XtraGrid.Columns.GridColumn OZEL_KOD2_ID;
        private DevExpress.XtraGrid.Columns.GridColumn OZEL_KOD3_ID;
        private DevExpress.XtraGrid.Columns.GridColumn OZEL_KOD4_ID;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControlTaraflar;
        private System.Windows.Forms.GroupBox pnIslemler;
        private DevExpress.XtraEditors.PanelControl pnlGelismeANeden;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnTakipEdenTemsilBagla;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnTemsilBagla;
        private DevExpress.XtraGrid.Columns.GridColumn REHIN_CINS_ANA_TURU;
        private DevExpress.XtraGrid.Columns.GridColumn REHIN_CINS_ID;
        private DevExpress.XtraGrid.Columns.GridColumn REHIN_DERECE;
        private DevExpress.XtraGrid.Columns.GridColumn REHIN_DURUM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn REHIN_SIRA;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit2View;

        //private DevExpress.XtraBars.BarButtonItem barButtonItem25;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem26;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem27;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem28;
        //private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu2;
        //private AdimAdimDavaKaydi.ExtendTool.compRibbonExtender compRibbonExtender1;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgIliskiIslemleri;
        private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit1;
        private DevExpress.XtraEditors.Repository.PersistentRepository repositorylerim;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkAdliBirimAdliye;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit rlkBorclu;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit rlkCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkCariAvukat;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkFormTipi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkFoyDurum;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkMudurluk;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkOzelKod1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkOzelKod2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkOzelKod3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkOzelKod4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkTakipEdenSifat;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkTakipEdenTK;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkTakipEdilenSifat;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkTakipEdilenTK;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkTakipKonu;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rlkTakipTarihi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkTemsilSekil;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueVekaletSozlesme;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAlacakNeden;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDoviz;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueFaizTip;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueHesaplamaModu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueKdvTipi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueMudurlukNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSegmentId;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowAciklama;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowIlamsiziVarmi;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow rowOzelKod3;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSegment;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTAKIP_TALEP_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTAKIP_YOLU;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar rprgKayitEdiliyor;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rTutar;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtDosyaNoKod;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtDosyaNoSayi;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtEsasNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtReferans;
        private DevExpress.XtraGrid.Columns.GridColumn RUHSAT_SICIL_NO;
        private DevExpress.XtraGrid.Columns.GridColumn RUHSAT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn SERH_ACIKLAMASI;
        private DevExpress.XtraGrid.Columns.GridColumn SICIL_BOLGE_NO;
        private DevExpress.XtraGrid.Columns.GridColumn SICIL_ILCE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn SICIL_IL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn SICIL_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn SICIL_TESCIL_NO;
        private DevExpress.XtraGrid.Columns.GridColumn SICIL_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn SICIL_YEVMIYE_NO;
        private DevExpress.XtraGrid.Columns.GridColumn SIKAYET_EDILDI_MI;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraGrid.Columns.GridColumn SON_ISLEM_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn SON_KULLANIM_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn SORAN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn SORULDUGU_TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn SORULMA_SONUCU;
        private DevExpress.XtraGrid.Columns.GridColumn SOZLESME_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn SOZLESME_DURUM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn SOZLESME_NO;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.SplitContainerControl spSozlesme;
        private DevExpress.XtraGrid.Columns.GridColumn SUBE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn SURE_AY;
        private DevExpress.XtraGrid.Columns.GridColumn SURE_GUN;
        private DevExpress.XtraGrid.Columns.GridColumn SURE_UYGULAMA_TIPI;
        private DevExpress.XtraGrid.Columns.GridColumn SURE_YIL;
        private DevExpress.XtraTab.XtraTabControl tabGiris;
        private DevExpress.XtraTab.XtraTabPage tabPageIhtarname;
        private DevExpress.XtraTab.XtraTabPage tabpBankaSube;
        private DevExpress.XtraTab.XtraTabPage tabPDosyaHesabiveYazdirma;
        private DevExpress.XtraTab.XtraTabPage tabpGenel;
        private DevExpress.XtraTab.XtraTabPage tabPHasar;
        private DevExpress.XtraTab.XtraTabPage tabpPolice;
        private DevExpress.XtraGrid.Columns.GridColumn TAHLIYE_ADRESI;
        private DevExpress.XtraGrid.Columns.GridColumn TAHLIYE_TAAHHUT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn TANIMA_ISARETI;
        private DevExpress.XtraGrid.Columns.GridColumn TARAF_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn TASLAK_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn TASNIF_NO;
        private DevExpress.XtraTab.XtraTabPage tbPPoliçe;
        private DevExpress.XtraTab.XtraTabControl tcKevrak;
        private DevExpress.XtraGrid.Columns.GridColumn TEKNIK_KUTUK_NO;
        private DevExpress.XtraGrid.Columns.GridColumn TEMERRUT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn TESCIL_NUMARASI;
        private DevExpress.XtraGrid.Columns.GridColumn TIPI;
        private DevExpress.XtraGrid.Columns.GridColumn TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn TONALITOSU;

        //private DevExpress.XtraBars.BarButtonItem barButtonItem13;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraTab.XtraTabPage tpGelismeBilgileri;
        private DevExpress.XtraTab.XtraTabPage tpKiymetliEvrak;
        private DevExpress.XtraTab.XtraTabPage tpKiymetliTaraf;

        //private DevExpress.XtraBars.BarButtonItem btnDegistir;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem21;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        //private DevExpress.XtraBars.BarButtonItem rbtnKes;
        //private DevExpress.XtraBars.BarButtonItem rbtnKopyala;
        //private DevExpress.XtraBars.BarButtonItem rbtnYapistir;
        //private DevExpress.XtraBars.BarButtonItem rbtnGerial;
        //private DevExpress.XtraBars.BarButtonItem rbtnYeniden;
        //private DevExpress.XtraBars.BarButtonItem rbtnTarihce;
        //private DevExpress.XtraBars.BarButtonItem rbtnGizleGoster;
        //private DevExpress.XtraBars.BarButtonItem rbtnHesapla;
        //private DevExpress.XtraBars.BarButtonItem rbtnCikis;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem15;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem16;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem17;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        //private AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge.uctxEditor uctxEditor1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem18;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem19;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem20;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem22;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem23;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        //private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem24;
        private DevExpress.XtraTab.XtraTabPage tpSozTeminat;
        private DevExpress.XtraTab.XtraTabPage tpTakipGenelBilgileri;
        private DevExpress.XtraGrid.Columns.GridColumn TRAFIK_SUBESI;
        private DevExpress.XtraGrid.Columns.GridColumn TUR;
        private DevExpress.XtraGrid.Columns.GridColumn TUTAR;
        private DevExpress.XtraGrid.Columns.GridColumn TUTAR_DOVIZ_ID;
        private ucAlacakNedenGirisi ucAlacakNedenGirisi1;
        private AdimAdimDavaKaydi.IcraTakip.UserControls.ucAlacakNedenTaraf ucAlacakNedenTaraf1;
        private ucIcraHesapCetveli ucIcraHesapCetveli1;
        private ucKiymetliEvrak ucKiymetliEvrak2;
        private ucKiymetliEvrakTaraf ucKiymetliEvrakTaraf1;
        private ucOzelKodBankaSubeBilgileri ucOzelKodBankaSubeBilgileri1;
        private ucPoliceKayitvGrid ucPoliceKayitvGrid1;
        private DevExpress.XtraGrid.Columns.GridColumn UCRETIN_ODENME_SEKLI_ID;
        private ucSozlesmeBilgileri ucSozlesmeBilgileri1;
        private ucTebligatKayitUfakDock ucTebligatKayitUfakDock1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.Columns.GridColumn YEDI_EMIN_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn YENILENME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn ZAMAN_ASIMI_TARIHI;

        #endregion Fields

        #region Methods

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

        private void CreateUcAlacakNedenGirisi1()
        {
            SozlesmeYukle(); // Okan 12.08.2010 Performans
            //
            // ucAlacakNedenGirisi1
            //
            this.ucAlacakNedenGirisi1 = new AdimAdimDavaKaydi.UserControls.ucAlacakNedenGirisi();
            this.pnlGelismeANeden.Controls.Add(this.ucAlacakNedenGirisi1);
            this.ucAlacakNedenGirisi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAlacakNedenGirisi1.DtAlacakNeden = null;
            this.ucAlacakNedenGirisi1.Foy = null;
            this.ucAlacakNedenGirisi1.Location = new System.Drawing.Point(2, 2);
            //this.ucAlacakNedenGirisi1.MyIcraTaraf = null;
            this.ucAlacakNedenGirisi1.Name = "ucAlacakNedenGirisi1";
            this.ucAlacakNedenGirisi1.SeciliNedenler = null;
            this.ucAlacakNedenGirisi1.ShowOnlyGridControl = false;
            this.ucAlacakNedenGirisi1.Size = new System.Drawing.Size(839, 233);
            this.ucAlacakNedenGirisi1.TabIndex = 3;
            this.ucAlacakNedenGirisi1.TakipsizAlacakMi = false;
            this.ucAlacakNedenGirisi1.FocusedNedenChanged += new DevExpress.XtraVerticalGrid.Events.IndexChangedEventHandler(this.Neden_FocusedNedenChanged);
            this.ucAlacakNedenGirisi1.ValidateRecord += new DevExpress.XtraVerticalGrid.Events.ValidateRecordEventHandler(this.Neden_ValidateRecord);
        }

        private void CreateUcAlacakNedenTaraf1()
        {
            //
            // ucAlacakNedenTaraf1
            //
            this.ucAlacakNedenTaraf1 = new AdimAdimDavaKaydi.IcraTakip.UserControls.ucAlacakNedenTaraf();
            this.splitContainer2.Panel1.Controls.Add(this.ucAlacakNedenTaraf1);
            this.ucAlacakNedenTaraf1.CanEditCari = false;
            this.ucAlacakNedenTaraf1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAlacakNedenTaraf1.DtAlacakNeden = null;
            this.ucAlacakNedenTaraf1.Location = new System.Drawing.Point(0, 0);
            this.ucAlacakNedenTaraf1.Name = "ucAlacakNedenTaraf1";
            this.ucAlacakNedenTaraf1.Size = new System.Drawing.Size(384, 445);
            this.ucAlacakNedenTaraf1.TabIndex = 0;
            this.ucAlacakNedenTaraf1.FocusedTarafChanged += new DevExpress.XtraVerticalGrid.Events.IndexChangedEventHandler(this.ucAlacakNedenTaraf1_FocusedTarafChanged);
        }

        private void CreateUcAlacakNedenTaraf_Faiz1()
        {
            //
            // ucAlacakNedenTaraf_Faiz1
            //
            this.ucAlacakNedenTaraf_Faiz1 = new AdimAdimDavaKaydi.IcraTakip.UserControls.ucAlacakNedenTaraf_Faiz();
            this.groupControl5.Controls.Add(this.ucAlacakNedenTaraf_Faiz1);
            this.ucAlacakNedenTaraf_Faiz1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAlacakNedenTaraf_Faiz1.DtAlacakNeden = null;
            this.ucAlacakNedenTaraf_Faiz1.Location = new System.Drawing.Point(2, 22);
            this.ucAlacakNedenTaraf_Faiz1.Name = "ucAlacakNedenTaraf_Faiz1";
            this.ucAlacakNedenTaraf_Faiz1.Size = new System.Drawing.Size(444, 421);
            this.ucAlacakNedenTaraf_Faiz1.TabIndex = 0;
        }

        private void CreateUcIcraHesapCetveli1()
        {
            //
            // ucIcraHesapCetveli1
            //
            this.ucIcraHesapCetveli1 = new AdimAdimDavaKaydi.UserControls.ucIcraHesapCetveli();
            this.tabPDosyaHesabiveYazdirma.Controls.Add(this.ucIcraHesapCetveli1);
            this.ucIcraHesapCetveli1.BarGorunsun = false;
            this.ucIcraHesapCetveli1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIcraHesapCetveli1.Gorunum = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.ucIcraHesapCetveli1.KlasorHesabi = true;
            this.ucIcraHesapCetveli1.Location = new System.Drawing.Point(0, 0);
            //this.ucIcraHesapCetveli1.MyFoyDataSource = null;
            //this.ucIcraHesapCetveli1.MyOzetHesap = null;
            //this.ucIcraHesapCetveli1.MyTarafSource = null;
            this.ucIcraHesapCetveli1.Name = "ucIcraHesapCetveli1";
            this.ucIcraHesapCetveli1.OzetHesapBaslikGrubu = AdimAdimDavaKaydi.UserControls.ucOzetHesap.BaslikGruplari.Dosya;
            this.ucIcraHesapCetveli1.SadeceDosyaTabi = false;
            this.ucIcraHesapCetveli1.SadeceTarafTabi = false;
            this.ucIcraHesapCetveli1.SecilenSayfa = AdimAdimDavaKaydi.UserControls.ucIcraHesapCetveli.TabSayfalari.OzetHesap;
            this.ucIcraHesapCetveli1.Size = new System.Drawing.Size(344, 553);
            this.ucIcraHesapCetveli1.TabIndex = 0;
            this.ucIcraHesapCetveli1.Tag = "H";
        }

        private void CreateUcKiymetliEvrak2()
        {
            //
            // ucKiymetliEvrak2
            //
            this.ucKiymetliEvrak2 = new AdimAdimDavaKaydi.ucKiymetliEvrak();
            this.tpKiymetliEvrak.Controls.Add(this.ucKiymetliEvrak2);
            this.ucKiymetliEvrak2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKiymetliEvrak2.Gorunum = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.ucKiymetliEvrak2.Location = new System.Drawing.Point(0, 0);
            //this.ucKiymetliEvrak2.MyDataSource = null;
            //this.ucKiymetliEvrak2.MyExtendedDataSource = null;
            this.ucKiymetliEvrak2.Name = "ucKiymetliEvrak2";
            this.ucKiymetliEvrak2.OnlyOneRecord = true;
            this.ucKiymetliEvrak2.Size = new System.Drawing.Size(426, 361);
            this.ucKiymetliEvrak2.TabIndex = 3;
        }

        private void CreateUcKiymetliEvrakTaraf1()
        {
            //
            // ucKiymetliEvrakTaraf1
            //
            this.ucKiymetliEvrakTaraf1 = new ucKiymetliEvrakTaraf();
            this.tpKiymetliTaraf.Controls.Add(this.ucKiymetliEvrakTaraf1);
            this.ucKiymetliEvrakTaraf1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKiymetliEvrakTaraf1.Location = new System.Drawing.Point(0, 0);
            this.ucKiymetliEvrakTaraf1.Name = "ucKiymetliEvrakTaraf1";
            this.ucKiymetliEvrakTaraf1.Size = new System.Drawing.Size(426, 270);
            this.ucKiymetliEvrakTaraf1.TabIndex = 0;
        }

        private void CreateUcOzelKodBankaSubeBilgileri1()
        {
            //
            // ucOzelKodBankaSubeBilgileri1
            //
            this.ucOzelKodBankaSubeBilgileri1 = new AdimAdimDavaKaydi.UserControls.ucOzelKodBankaSubeBilgileri();
            this.tabpBankaSube.Controls.Add(this.ucOzelKodBankaSubeBilgileri1);
            this.ucOzelKodBankaSubeBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOzelKodBankaSubeBilgileri1.Location = new System.Drawing.Point(0, 0);
            //this.ucOzelKodBankaSubeBilgileri1.MyDavaOzelKod = null;
            //this.ucOzelKodBankaSubeBilgileri1.MyIcraOzelKod = null;
            this.ucOzelKodBankaSubeBilgileri1.Name = "ucOzelKodBankaSubeBilgileri1";
            this.ucOzelKodBankaSubeBilgileri1.Size = new System.Drawing.Size(674, 129);
            this.ucOzelKodBankaSubeBilgileri1.TabIndex = 0;
        }

        private void CreateUcPoliceKayitvGrid1()
        {
            //
            // ucPoliceKayitvGrid1
            //
            this.ucPoliceKayitvGrid1 = new AdimAdimDavaKaydi.UserControls.ucPoliceKayitvGrid();
            this.tabpPolice.Controls.Add(this.ucPoliceKayitvGrid1);
            this.ucPoliceKayitvGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPoliceKayitvGrid1.Location = new System.Drawing.Point(0, 0);
            //this.ucPoliceKayitvGrid1.MyDataSource = null;
            this.ucPoliceKayitvGrid1.Name = "ucPoliceKayitvGrid1";
            this.ucPoliceKayitvGrid1.Size = new System.Drawing.Size(756, 597);
            this.ucPoliceKayitvGrid1.TabIndex = 0;
        }

        private void CreateUcSozlesmeBilgileri1()
        {
            SozlesmeYukle(); // Okan 12.08.2010 Performans
            //
            // ucSozlesmeBilgileri1
            //
            this.ucSozlesmeBilgileri1 = new AdimAdimDavaKaydi.ucSozlesmeBilgileri();
            this.grpSozlesmeBilgileri.Controls.Add(this.ucSozlesmeBilgileri1);
            this.ucSozlesmeBilgileri1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ucSozlesmeBilgileri1.Appearance.Options.UseBackColor = true;
            this.ucSozlesmeBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSozlesmeBilgileri1.Location = new System.Drawing.Point(2, 22);
            //this.ucSozlesmeBilgileri1.MyDataSource = null;
            //this.ucSozlesmeBilgileri1.MyIcraFoy = null;
            //this.ucSozlesmeBilgileri1.MyIcraTaraf = null;
            this.ucSozlesmeBilgileri1.Name = "ucSozlesmeBilgileri1";
            this.ucSozlesmeBilgileri1.Size = new System.Drawing.Size(759, 602);
            this.ucSozlesmeBilgileri1.TabIndex = 0;
            this.ucSozlesmeBilgileri1.FocusedSozlesmeChanged += new DevExpress.XtraVerticalGrid.Events.IndexChangedEventHandler(this.ucSozlesmeBilgileri1_FocusedSozlesmeChanged);
            this.ucSozlesmeBilgileri1.SozlesmeValidateRecord += new DevExpress.XtraVerticalGrid.Events.ValidateRecordEventHandler(this.ucSozlesmeBilgileri1_SozlesmeValidateRecord);
        }

        private void CreateUcTebligatKayitUfakDock1()
        {
            //
            // ucTebligatKayitUfakDock1
            //
            this.ucTebligatKayitUfakDock1 = new AdimAdimDavaKaydi.UserControls.ucTebligatKayitUfakDock();
            this.splitContainerControl2.Panel1.Controls.Add(this.ucTebligatKayitUfakDock1);
            this.ucTebligatKayitUfakDock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTebligatKayitUfakDock1.Location = new System.Drawing.Point(0, 0);
            //this.ucTebligatKayitUfakDock1.MyDataSource = null;
            this.ucTebligatKayitUfakDock1.Name = "ucTebligatKayitUfakDock1";
            this.ucTebligatKayitUfakDock1.Size = new System.Drawing.Size(763, 351);
            this.ucTebligatKayitUfakDock1.TabIndex = 1;
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIcraDosyaKayit));
            this.gvTakipEdilenVekil = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTEMSIL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rbtnTakipEdenTemsilBagla = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colAVUKAT_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlkCariAvukat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTEMSIL_SEKLI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlkTemsilSekil = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcTakipEdilen = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.aV001TIBILFOYTARAFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bsrcMyFoy = new System.Windows.Forms.BindingSource(this.components);
            this.repositorylerim = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rglkSorumluAvs = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlkTakipEdenTK = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlkTakipEdilenTK = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlkTakipEdenSifat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlkTakipEdilenSifat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlkCari = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.rbtnTemsilBagla = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rlkBorclu = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gvTakipEdilen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvTakipEdenTarafVekil = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTEMSIL_ID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAVUKAT_CARI_ID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEMSIL_SEKLI_ID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTakipEden = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gvTakipEden = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.multiEditorRowProperties1 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rlkFormTipi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties2 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties3 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties4 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rlkTakipTarihi = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.multiEditorRowProperties5 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rlkFoyDurum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties6 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties7 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rlkMudurluk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties8 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rlueMudurlukNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties9 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rtxtEsasNo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.multiEditorRowProperties10 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rtxtReferans = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.multiEditorRowProperties11 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties12 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties13 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rlkOzelKod1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties14 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rlkOzelKod2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties15 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rlkOzelKod3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties16 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rlkOzelKod4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties17 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties18 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rtxtDosyaNoKod = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.multiEditorRowProperties19 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rtxtDosyaNoSayi = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.tabGiris = new DevExpress.XtraTab.XtraTabControl();
            this.tpTakipGenelBilgileri = new DevExpress.XtraTab.XtraTabPage();
            this.grpOnSayfaANeden = new DevExpress.XtraEditors.GroupControl();
            this.kEvrakSplitter = new DevExpress.XtraEditors.SplitterControl();
            this.tcKevrak = new DevExpress.XtraTab.XtraTabControl();
            this.tpKiymetliEvrak = new DevExpress.XtraTab.XtraTabPage();
            this.tpKiymetliTaraf = new DevExpress.XtraTab.XtraTabPage();
            this.bottomPanel = new DevExpress.XtraEditors.PanelControl();
            this.panelControlTaraflar = new DevExpress.XtraEditors.PanelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.pnSorumluAvukat = new DevExpress.XtraEditors.PanelControl();
            this.gcSorumluAvukat = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gvSorumluAvukat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.pnTakipEdilen = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.pnTakipEden = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.tabpGenel = new DevExpress.XtraTab.XtraTabPage();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rlkTakipKonu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueVekaletSozlesme = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSegmentId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRow1 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.multiEditorRowProperties20 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties21 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties22 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rowTAKIP_TALEP_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.multiEditorRow44 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.multiEditorRowProperties23 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties24 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties25 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rowIlamsiziVarmi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.multiEditorRow43 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.multiEditorRowProperties26 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties27 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties28 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rowMudurlukIBANNo = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSegment = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTAKIP_YOLU = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.multiEditorRow40 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.multiEditorRowProperties29 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties30 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties31 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRow41 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.multiEditorRowProperties32 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties33 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rowOzelKod3 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.multiEditorRowProperties34 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties35 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rowSozlesme = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowAciklama = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.tabpBankaSube = new DevExpress.XtraTab.XtraTabPage();
            this.tpGelismeBilgileri = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnlGelismeANeden = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.tpSozTeminat = new DevExpress.XtraTab.XtraTabPage();
            this.spSozlesme = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpSozlesmeBilgileri = new DevExpress.XtraEditors.GroupControl();
            this.tabPageIhtarname = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gcAlacak = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueAlacakNeden = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rTutar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.Date = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rLueDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueHesaplamaModu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueFaizTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueKdvTipi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gwAlacak = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALACAK_NEDEN_KOD_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIGER_ALACAK_NEDENI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDUZENLENME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVADE_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_BASLANGIC_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHESAPLAMA_MODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTUTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISLEME_KONAN_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHARCA_ESAS_DEGER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHARCA_ESAS_DEGER_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_YOK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALACAK_FAIZ_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUYGULANACAK_FAIZ_ORANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTO_ALACAK_FAIZ_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTO_UYGULANACAK_FAIZ_ORANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSABIT_FAIZ_UYGULA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBIR_GUNE_AYLIK_FAIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIHTAR_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIHTAR_GIDERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIHTAR_GIDERI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROTESTO_GIDERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROTESTO_GIDERI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHER_AY_TAZMINAT_EKLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAZMINAT_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAZMINATI_ORANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCEK_TAZMINATI_ORANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKOMISYONU_ORANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBSMV_HESAPLANSIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKKDV_HESAPLANSIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOIV_HESAPLANSIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKDV_HESAPLANSIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKDV_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAMGA_PULU_HESAPLANSIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSURE_GUN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSURE_AY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSURE_YIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colREFERANS_NO2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colREFERANS_NO3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEMI_UCAK_ARAC_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CINSI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TESCIL_NUMARASI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TANIMA_ISARETI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.INSA_YILI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.INSA_YERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BOYU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ENI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TONALITOSU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BAGLAMA_LIMANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEKNIK_KUTUK_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ERISIM_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DERINLIGI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KUTUK_BOYU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ARAC_PLAKA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ARAC_MODEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ARAC_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ARAC_MOTOR_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ARAC_SASI_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ARAC_RENK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TRAFIK_SUBESI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RUHSAT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RUHSAT_SICIL_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colICRA_ALACAK_NEDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTARAF_CARI_ID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_BASLANGIC_TARIHI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_BITIS_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSABIT_FAIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBIR_GUNE_AYLIK_FAIZ1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.EVRAK_TUR_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EVRAK_KAYIT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EVRAK_VADE_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EVRAK_TANZIM_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NE_SEKILDE_AHZOLUNDUGU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BANKA_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SUBE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BANKA_SUBE_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HESAP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CEK_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SORULDUGU_TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SORULMA_SONUCU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KARSILIK_TUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KARSILIK_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SORAN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ARKASI_YAZILDI_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SERH_ACIKLAMASI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ILK_ALACAKLI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ILK_BORCLU_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SIKAYET_EDILDI_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KESIDE_YERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ODEME_YERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ISLEMLER_BASLADIMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOZLESME_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOZLESME_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ALT_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TASNIF_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OZEL_KOD1_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OZEL_KOD2_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OZEL_KOD3_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OZEL_KOD4_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TASLAK_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IMZA_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BASLANGIC_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YENILENME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SON_ISLEM_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BITIS_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BITIRILME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SURE_GUN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SURE_AY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SURE_YIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NOTER_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NOTER_YEVMIYE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ADLI_BIRIM_GOREV_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ADLI_BIRIM_NO_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YEDI_EMIN_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BEDELI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BEDELI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TAHLIYE_TAAHHUT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TAHLIYE_ADRESI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KART_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KREDI_KART_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CVV1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CVV2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SON_KULLANIM_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REHIN_CINS_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BORC_IKRARINI_HAVI_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HARC_ISTISNA_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HARC_ISTISNA_BELGE_TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HARC_ISTISNA_BELGE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REHIN_DERECE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REHIN_SIRA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SICIL_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SICIL_BOLGE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SICIL_ILCE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SICIL_IL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SICIL_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SICIL_YEVMIYE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SICIL_TESCIL_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FEK_TARIHI3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REHIN_DURUM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOZLESME_DURUM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DURUM_ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REHIN_CINS_ANA_TURU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ISLEMLER_BASLADIMI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UCRETIN_ODENME_SEKLI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HAKEM_YARGILAMASININ_YERI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SURE_UYGULAMA_TIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView11 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TARAF_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IHTAR_TEBLIG_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEMERRUT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ZAMAN_ASIMI_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IHTAR_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn141 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn143 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn144 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn151 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn159 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn164 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.tbPPoliçe = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabControl3 = new DevExpress.XtraTab.XtraTabControl();
            this.tabpPolice = new DevExpress.XtraTab.XtraTabPage();
            this.tabPHasar = new DevExpress.XtraTab.XtraTabPage();
            this.tabPDosyaHesabiveYazdirma = new DevExpress.XtraTab.XtraTabPage();
            this.pnIslemler = new System.Windows.Forms.GroupBox();
            this.multiEditorRow39 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.aV001TIBILFOYTARAFVEKILBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barLinkContainerItem1 = new DevExpress.XtraBars.BarLinkContainerItem();
            this.glkIcraFoy = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.rlkAdliBirimAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvBagliKayit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clmFOY_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmTAKIP_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmADLI_BIRIM_ADLIYE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmADLI_BIRIM_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.beDurum = new DevExpress.XtraBars.BarEditItem();
            this.rprgKayitEdiliyor = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.repositoryItemPopupContainerEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.bwFoyuKaydet = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTakipEdilenVekil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTakipEdenTemsilBagla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkCariAvukat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTemsilSekil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTakipEdilen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TIBILFOYTARAFBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsrcMyFoy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rglkSorumluAvs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTakipEdenTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTakipEdilenTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTakipEdenSifat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTakipEdilenSifat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTemsilBagla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkBorclu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTakipEdilen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTakipEdenTarafVekil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTakipEden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTakipEden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkFormTipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTakipTarihi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTakipTarihi.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkFoyDurum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkMudurluk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueMudurlukNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEsasNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtReferans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkOzelKod1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkOzelKod2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkOzelKod3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkOzelKod4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtDosyaNoKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtDosyaNoSayi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabGiris)).BeginInit();
            this.tabGiris.SuspendLayout();
            this.tpTakipGenelBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpOnSayfaANeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcKevrak)).BeginInit();
            this.tcKevrak.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomPanel)).BeginInit();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTaraflar)).BeginInit();
            this.panelControlTaraflar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnSorumluAvukat)).BeginInit();
            this.pnSorumluAvukat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSorumluAvukat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSorumluAvukat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnTakipEdilen)).BeginInit();
            this.pnTakipEdilen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnTakipEden)).BeginInit();
            this.pnTakipEden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.tabpGenel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTakipKonu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueVekaletSozlesme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSegmentId)).BeginInit();
            this.tpGelismeBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGelismeANeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.tpSozTeminat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spSozlesme)).BeginInit();
            this.spSozlesme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSozlesmeBilgileri)).BeginInit();
            this.tabPageIhtarname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakNeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHesaplamaModu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueFaizTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKdvTipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwAlacak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).BeginInit();
            this.tbPPoliçe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl3)).BeginInit();
            this.xtraTabControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TIBILFOYTARAFVEKILBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glkIcraFoy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkAdliBirimAdliye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBagliKayit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rprgKayitEdiliyor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(985, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 749);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 749);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 724);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(1173, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(1023, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(1098, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.tabGiris);
            this.c_pnlContainer.Size = new System.Drawing.Size(1173, 749);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.tabGiris, 0);
            // 
            // gvTakipEdilenVekil
            // 
            this.gvTakipEdilenVekil.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTEMSIL_ID,
            this.colAVUKAT_CARI_ID,
            this.colTEMSIL_SEKLI_ID});
            this.gvTakipEdilenVekil.GridControl = this.gcTakipEdilen;
            this.gvTakipEdilenVekil.Name = "gvTakipEdilenVekil";
            this.gvTakipEdilenVekil.NewItemRowText = "Yeni Temsil Ekle";
            this.gvTakipEdilenVekil.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gvTakipEdilenVekil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvTakipEdilenVekil.OptionsView.ShowGroupPanel = false;
            this.gvTakipEdilenVekil.ViewCaption = "Vekil";
            // 
            // colTEMSIL_ID
            // 
            this.colTEMSIL_ID.Caption = "Temsil";
            this.colTEMSIL_ID.ColumnEdit = this.rbtnTakipEdenTemsilBagla;
            this.colTEMSIL_ID.FieldName = "TEMSIL_ID";
            this.colTEMSIL_ID.Name = "colTEMSIL_ID";
            this.colTEMSIL_ID.Visible = true;
            this.colTEMSIL_ID.VisibleIndex = 0;
            this.colTEMSIL_ID.Width = 48;
            // 
            // rbtnTakipEdenTemsilBagla
            // 
            this.rbtnTakipEdenTemsilBagla.AutoHeight = false;
            this.rbtnTakipEdenTemsilBagla.Name = "rbtnTakipEdenTemsilBagla";
            this.rbtnTakipEdenTemsilBagla.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rbtnTakipEdenTemsilBagla.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rbtnTakipEdenTemsilBagla_ButtonClick);
            // 
            // colAVUKAT_CARI_ID
            // 
            this.colAVUKAT_CARI_ID.Caption = "Vekil";
            this.colAVUKAT_CARI_ID.ColumnEdit = this.rlkCariAvukat;
            this.colAVUKAT_CARI_ID.FieldName = "AVUKAT_CARI_ID";
            this.colAVUKAT_CARI_ID.Name = "colAVUKAT_CARI_ID";
            this.colAVUKAT_CARI_ID.Visible = true;
            this.colAVUKAT_CARI_ID.VisibleIndex = 1;
            this.colAVUKAT_CARI_ID.Width = 82;
            // 
            // rlkCariAvukat
            // 
            this.rlkCariAvukat.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rlkCariAvukat.AutoHeight = false;
            this.rlkCariAvukat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Kiþi Ekle", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", "ekle", null, true)});
            this.rlkCariAvukat.Name = "rlkCariAvukat";
            this.rlkCariAvukat.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rlkCariAvukat.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rlkCariAvukat_ButtonClick);
            // 
            // colTEMSIL_SEKLI_ID
            // 
            this.colTEMSIL_SEKLI_ID.Caption = "Þekli";
            this.colTEMSIL_SEKLI_ID.ColumnEdit = this.rlkTemsilSekil;
            this.colTEMSIL_SEKLI_ID.FieldName = "TEMSIL_SEKLI_ID";
            this.colTEMSIL_SEKLI_ID.Name = "colTEMSIL_SEKLI_ID";
            this.colTEMSIL_SEKLI_ID.Visible = true;
            this.colTEMSIL_SEKLI_ID.VisibleIndex = 2;
            this.colTEMSIL_SEKLI_ID.Width = 119;
            // 
            // rlkTemsilSekil
            // 
            this.rlkTemsilSekil.AutoHeight = false;
            this.rlkTemsilSekil.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkTemsilSekil.Name = "rlkTemsilSekil";
            // 
            // gcTakipEdilen
            // 
            this.gcTakipEdilen.CustomButtonlarGorunmesin = false;
            this.gcTakipEdilen.DataSource = this.aV001TIBILFOYTARAFBindingSource;
            this.gcTakipEdilen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTakipEdilen.DoNotExtendEmbedNavigator = false;
            this.gcTakipEdilen.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcTakipEdilen.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.gcTakipEdilen.ExternalRepository = this.repositorylerim;
            this.gcTakipEdilen.FilterText = null;
            this.gcTakipEdilen.FilterValue = null;
            this.gcTakipEdilen.GridlerDuzenlenebilir = true;
            this.gcTakipEdilen.GridsFilterControl = null;
            gridLevelNode1.LevelTemplate = this.gvTakipEdilenVekil;
            gridLevelNode1.RelationName = "AV001_TI_BIL_FOY_TARAF_VEKILCollection";
            this.gcTakipEdilen.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcTakipEdilen.Location = new System.Drawing.Point(2, 2);
            this.gcTakipEdilen.MainView = this.gvTakipEdilen;
            this.gcTakipEdilen.MyGridStyle = null;
            this.gcTakipEdilen.Name = "gcTakipEdilen";
            this.gcTakipEdilen.ShowOnlyPredefinedDetails = true;
            this.gcTakipEdilen.ShowRowNumbers = false;
            this.gcTakipEdilen.SilmeKaldirilsin = false;
            this.gcTakipEdilen.Size = new System.Drawing.Size(330, 116);
            this.gcTakipEdilen.TabIndex = 0;
            this.gcTakipEdilen.TemizleKaldirGorunsunmu = false;
            this.gcTakipEdilen.UniqueId = "b6c30c1c-915d-480d-9984-89cc2ebcd8c7";
            this.gcTakipEdilen.UseEmbeddedNavigator = true;
            this.gcTakipEdilen.UseHyperDragDrop = false;
            this.gcTakipEdilen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTakipEdilen,
            this.gridView3,
            this.gvTakipEdilenVekil});
            this.gcTakipEdilen.DataSourceChanged += new System.EventHandler(this.gcTakipEdilen_DataSourceChanged);
            // 
            // aV001TIBILFOYTARAFBindingSource
            // 
            this.aV001TIBILFOYTARAFBindingSource.DataMember = "AV001_TI_BIL_FOY_TARAFCollection";
            this.aV001TIBILFOYTARAFBindingSource.DataSource = this.bsrcMyFoy;
            // 
            // bsrcMyFoy
            // 
            this.bsrcMyFoy.DataSource = typeof(AvukatProLib2.Entities.AV001_TI_BIL_FOY);
            // 
            // repositorylerim
            // 
            this.repositorylerim.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rglkSorumluAvs,
            this.rlkTakipEdenTK,
            this.rlkTakipEdilenTK,
            this.rlkTakipEdenSifat,
            this.rlkTakipEdilenSifat,
            this.rlkCari,
            this.rlkCariAvukat,
            this.rlkTemsilSekil,
            this.rbtnTemsilBagla,
            this.rlkBorclu,
            this.rbtnTakipEdenTemsilBagla});
            // 
            // rglkSorumluAvs
            // 
            this.rglkSorumluAvs.AutoHeight = false;
            this.rglkSorumluAvs.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rglkSorumluAvs.Name = "rglkSorumluAvs";
            this.rglkSorumluAvs.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn13});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsCustomization.AllowColumnMoving = false;
            this.repositoryItemGridLookUpEdit1View.OptionsCustomization.AllowGroup = false;
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Adý";
            this.gridColumn12.FieldName = "AD";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Kod";
            this.gridColumn13.FieldName = "KOD";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            // 
            // rlkTakipEdenTK
            // 
            this.rlkTakipEdenTK.AutoHeight = false;
            this.rlkTakipEdenTK.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkTakipEdenTK.Name = "rlkTakipEdenTK";
            this.rlkTakipEdenTK.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.rlkTakipEdenSifat_EditValueChanging);
            // 
            // rlkTakipEdilenTK
            // 
            this.rlkTakipEdilenTK.AutoHeight = false;
            this.rlkTakipEdilenTK.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkTakipEdilenTK.Name = "rlkTakipEdilenTK";
            this.rlkTakipEdilenTK.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.rlkTakipEdilenSifat_EditValueChanging);
            // 
            // rlkTakipEdenSifat
            // 
            this.rlkTakipEdenSifat.AutoHeight = false;
            this.rlkTakipEdenSifat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkTakipEdenSifat.Name = "rlkTakipEdenSifat";
            // 
            // rlkTakipEdilenSifat
            // 
            this.rlkTakipEdilenSifat.AutoHeight = false;
            this.rlkTakipEdilenSifat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkTakipEdilenSifat.Name = "rlkTakipEdilenSifat";
            // 
            // rlkCari
            // 
            this.rlkCari.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rlkCari.AutoHeight = false;
            this.rlkCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Kiþi Ekle", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "mEkle", null, true)});
            this.rlkCari.Name = "rlkCari";
            this.rlkCari.PopupFormSize = new System.Drawing.Size(700, 0);
            this.rlkCari.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rlkCari.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.rlkCari_ProcessNewValue);
            this.rlkCari.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rlkCari_ButtonClick);
            // 
            // rbtnTemsilBagla
            // 
            this.rbtnTemsilBagla.AllowFocused = false;
            this.rbtnTemsilBagla.AutoHeight = false;
            this.rbtnTemsilBagla.Name = "rbtnTemsilBagla";
            this.rbtnTemsilBagla.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rbtnTemsilBagla.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rbtnTemsilBagla_ButtonClick);
            // 
            // rlkBorclu
            // 
            this.rlkBorclu.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rlkBorclu.AutoHeight = false;
            this.rlkBorclu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Kiþi Ekle", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", "mEkle", null, true)});
            this.rlkBorclu.Name = "rlkBorclu";
            this.rlkBorclu.PopupFormSize = new System.Drawing.Size(700, 0);
            this.rlkBorclu.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rlkBorclu.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.rlkBorclu_ProcessNewValue);
            this.rlkBorclu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rlkBorclu_ButtonClick);
            // 
            // gvTakipEdilen
            // 
            this.gvTakipEdilen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gvTakipEdilen.GridControl = this.gcTakipEdilen;
            this.gvTakipEdilen.IndicatorWidth = 20;
            this.gvTakipEdilen.Name = "gvTakipEdilen";
            this.gvTakipEdilen.NewItemRowText = "Yeni Kayýt Ekle";
            this.gvTakipEdilen.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gvTakipEdilen.OptionsDetail.AutoZoomDetail = true;
            this.gvTakipEdilen.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvTakipEdilen.OptionsView.ShowGroupPanel = false;
            this.gvTakipEdilen.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvTakipEdilen_ValidateRow);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "TK";
            this.gridColumn4.ColumnEdit = this.rlkTakipEdilenTK;
            this.gridColumn4.FieldName = "TARAF_KODU";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 42;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Sýfat";
            this.gridColumn5.ColumnEdit = this.rlkTakipEdilenSifat;
            this.gridColumn5.FieldName = "TARAF_SIFAT_ID";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 93;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Takip Edilen";
            this.gridColumn6.ColumnEdit = this.rlkBorclu;
            this.gridColumn6.FieldName = "CARI_ID";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 151;
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gcTakipEdilen;
            this.gridView3.Name = "gridView3";
            // 
            // gvTakipEdenTarafVekil
            // 
            this.gvTakipEdenTarafVekil.ChildGridLevelName = "Temsil";
            this.gvTakipEdenTarafVekil.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTEMSIL_ID1,
            this.colAVUKAT_CARI_ID1,
            this.colTEMSIL_SEKLI_ID1});
            this.gvTakipEdenTarafVekil.GridControl = this.gcTakipEden;
            this.gvTakipEdenTarafVekil.Name = "gvTakipEdenTarafVekil";
            this.gvTakipEdenTarafVekil.OptionsDetail.AutoZoomDetail = true;
            this.gvTakipEdenTarafVekil.OptionsView.ShowGroupPanel = false;
            this.gvTakipEdenTarafVekil.ViewCaption = "Taraf Vekil Bilgileri";
            // 
            // colTEMSIL_ID1
            // 
            this.colTEMSIL_ID1.Caption = "Temsil";
            this.colTEMSIL_ID1.ColumnEdit = this.rbtnTemsilBagla;
            this.colTEMSIL_ID1.FieldName = "TEMSIL_ID";
            this.colTEMSIL_ID1.Name = "colTEMSIL_ID1";
            this.colTEMSIL_ID1.Visible = true;
            this.colTEMSIL_ID1.VisibleIndex = 0;
            this.colTEMSIL_ID1.Width = 222;
            // 
            // colAVUKAT_CARI_ID1
            // 
            this.colAVUKAT_CARI_ID1.Caption = "Vekil";
            this.colAVUKAT_CARI_ID1.ColumnEdit = this.rlkCariAvukat;
            this.colAVUKAT_CARI_ID1.FieldName = "AVUKAT_CARI_ID";
            this.colAVUKAT_CARI_ID1.Name = "colAVUKAT_CARI_ID1";
            this.colAVUKAT_CARI_ID1.Visible = true;
            this.colAVUKAT_CARI_ID1.VisibleIndex = 1;
            this.colAVUKAT_CARI_ID1.Width = 426;
            // 
            // colTEMSIL_SEKLI_ID1
            // 
            this.colTEMSIL_SEKLI_ID1.Caption = "Þekli";
            this.colTEMSIL_SEKLI_ID1.ColumnEdit = this.rlkTemsilSekil;
            this.colTEMSIL_SEKLI_ID1.FieldName = "TEMSIL_SEKLI_ID";
            this.colTEMSIL_SEKLI_ID1.Name = "colTEMSIL_SEKLI_ID1";
            this.colTEMSIL_SEKLI_ID1.Visible = true;
            this.colTEMSIL_SEKLI_ID1.VisibleIndex = 2;
            this.colTEMSIL_SEKLI_ID1.Width = 440;
            // 
            // gcTakipEden
            // 
            this.gcTakipEden.CustomButtonlarGorunmesin = false;
            this.gcTakipEden.DataSource = this.aV001TIBILFOYTARAFBindingSource;
            this.gcTakipEden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTakipEden.DoNotExtendEmbedNavigator = false;
            this.gcTakipEden.EmbeddedNavigator.Buttons.Append.ImageIndex = 0;
            this.gcTakipEden.EmbeddedNavigator.Buttons.CancelEdit.ImageIndex = 2;
            this.gcTakipEden.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcTakipEden.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 13;
            this.gcTakipEden.EmbeddedNavigator.Buttons.First.ImageIndex = 6;
            this.gcTakipEden.EmbeddedNavigator.Buttons.Last.ImageIndex = 9;
            this.gcTakipEden.EmbeddedNavigator.Buttons.Next.ImageIndex = 10;
            this.gcTakipEden.EmbeddedNavigator.Buttons.NextPage.ImageIndex = 9;
            this.gcTakipEden.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gcTakipEden.EmbeddedNavigator.Buttons.Prev.ImageIndex = 11;
            this.gcTakipEden.EmbeddedNavigator.Buttons.PrevPage.ImageIndex = 6;
            this.gcTakipEden.EmbeddedNavigator.Buttons.Remove.ImageIndex = 2;
            this.gcTakipEden.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.gcTakipEden.ExternalRepository = this.repositorylerim;
            this.gcTakipEden.FilterText = null;
            this.gcTakipEden.FilterValue = null;
            this.gcTakipEden.GridlerDuzenlenebilir = true;
            this.gcTakipEden.GridsFilterControl = null;
            gridLevelNode2.LevelTemplate = this.gvTakipEdenTarafVekil;
            gridLevelNode2.RelationName = "AV001_TI_BIL_FOY_TARAF_VEKILCollection";
            this.gcTakipEden.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gcTakipEden.Location = new System.Drawing.Point(2, 2);
            this.gcTakipEden.MainView = this.gvTakipEden;
            this.gcTakipEden.MyGridStyle = null;
            this.gcTakipEden.Name = "gcTakipEden";
            this.gcTakipEden.ShowOnlyPredefinedDetails = true;
            this.gcTakipEden.ShowRowNumbers = false;
            this.gcTakipEden.SilmeKaldirilsin = false;
            this.gcTakipEden.Size = new System.Drawing.Size(327, 116);
            this.gcTakipEden.TabIndex = 0;
            this.gcTakipEden.TemizleKaldirGorunsunmu = false;
            this.gcTakipEden.UniqueId = "7057168b-eb86-4421-ba6f-4a5d97df3cf0";
            this.gcTakipEden.UseEmbeddedNavigator = true;
            this.gcTakipEden.UseHyperDragDrop = false;
            this.gcTakipEden.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTakipEden,
            this.gvTakipEdenTarafVekil});
            this.gcTakipEden.DataSourceChanged += new System.EventHandler(this.gcTakipEden_DataSourceChanged);
            // 
            // gvTakipEden
            // 
            this.gvTakipEden.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gvTakipEden.GridControl = this.gcTakipEden;
            this.gvTakipEden.GroupPanelText = "Gruplama yapmak için bir sutun sürükleyin";
            this.gvTakipEden.IndicatorWidth = 20;
            this.gvTakipEden.Name = "gvTakipEden";
            this.gvTakipEden.NewItemRowText = "Yeni Kayýt Ekle";
            this.gvTakipEden.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gvTakipEden.OptionsDetail.AutoZoomDetail = true;
            this.gvTakipEden.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvTakipEden.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvTakipEden.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvTakipEden.OptionsView.ShowGroupPanel = false;
            this.gvTakipEden.MasterRowExpanding += new DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventHandler(this.gvTakipEden_MasterRowExpanding);
            this.gvTakipEden.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvTakipEden_ValidateRow);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "TK";
            this.gridColumn1.ColumnEdit = this.rlkTakipEdenTK;
            this.gridColumn1.FieldName = "TARAF_KODU";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 55;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Sýfat";
            this.gridColumn2.ColumnEdit = this.rlkTakipEdenSifat;
            this.gridColumn2.FieldName = "TARAF_SIFAT_ID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 102;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Takip Eden";
            this.gridColumn3.ColumnEdit = this.rlkCari;
            this.gridColumn3.FieldName = "CARI_ID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 131;
            // 
            // multiEditorRowProperties1
            // 
            this.multiEditorRowProperties1.Caption = "Form Tipi";
            this.multiEditorRowProperties1.FieldName = "FORM_TIP_ID";
            this.multiEditorRowProperties1.RowEdit = this.rlkFormTipi;
            this.multiEditorRowProperties1.Width = 136;
            // 
            // rlkFormTipi
            // 
            this.rlkFormTipi.AutoHeight = false;
            this.rlkFormTipi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkFormTipi.Name = "rlkFormTipi";
            this.rlkFormTipi.NullText = "<Form Tipi>";
            // 
            // multiEditorRowProperties2
            // 
            this.multiEditorRowProperties2.Caption = "Raf No";
            this.multiEditorRowProperties2.FieldName = "FOY_NO_Kod";
            this.multiEditorRowProperties2.Width = 48;
            // 
            // multiEditorRowProperties3
            // 
            this.multiEditorRowProperties3.FieldName = "FOY_NO_Sayi";
            this.multiEditorRowProperties3.Width = 31;
            // 
            // multiEditorRowProperties4
            // 
            this.multiEditorRowProperties4.Caption = "Takip T.";
            this.multiEditorRowProperties4.FieldName = "TAKIP_TARIHI";
            this.multiEditorRowProperties4.RowEdit = this.rlkTakipTarihi;
            this.multiEditorRowProperties4.Width = 116;
            // 
            // rlkTakipTarihi
            // 
            this.rlkTakipTarihi.AutoHeight = false;
            this.rlkTakipTarihi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkTakipTarihi.Name = "rlkTakipTarihi";
            this.rlkTakipTarihi.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // multiEditorRowProperties5
            // 
            this.multiEditorRowProperties5.Caption = "Durum";
            this.multiEditorRowProperties5.FieldName = "FOY_DURUM_ID";
            this.multiEditorRowProperties5.RowEdit = this.rlkFoyDurum;
            this.multiEditorRowProperties5.Width = 98;
            // 
            // rlkFoyDurum
            // 
            this.rlkFoyDurum.AutoHeight = false;
            this.rlkFoyDurum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkFoyDurum.Name = "rlkFoyDurum";
            this.rlkFoyDurum.NullText = "<Dosya Durumu>";
            // 
            // multiEditorRowProperties6
            // 
            this.multiEditorRowProperties6.Caption = "Ýnt Tarihi";
            this.multiEditorRowProperties6.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            this.multiEditorRowProperties6.Width = 128;
            // 
            // multiEditorRowProperties7
            // 
            this.multiEditorRowProperties7.Caption = "Müdürlük";
            this.multiEditorRowProperties7.CellWidth = 119;
            this.multiEditorRowProperties7.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.multiEditorRowProperties7.RowEdit = this.rlkMudurluk;
            this.multiEditorRowProperties7.Width = 73;
            // 
            // rlkMudurluk
            // 
            this.rlkMudurluk.AutoHeight = false;
            this.rlkMudurluk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkMudurluk.Name = "rlkMudurluk";
            this.rlkMudurluk.NullText = "<Müdürlük>";
            // 
            // multiEditorRowProperties8
            // 
            this.multiEditorRowProperties8.Caption = "No";
            this.multiEditorRowProperties8.CellWidth = 36;
            this.multiEditorRowProperties8.FieldName = "ADLI_BIRIM_NO_ID";
            this.multiEditorRowProperties8.RowEdit = this.rlueMudurlukNo;
            this.multiEditorRowProperties8.Width = 31;
            // 
            // rlueMudurlukNo
            // 
            this.rlueMudurlukNo.AutoHeight = false;
            this.rlueMudurlukNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueMudurlukNo.Name = "rlueMudurlukNo";
            this.rlueMudurlukNo.NullText = "No";
            // 
            // multiEditorRowProperties9
            // 
            this.multiEditorRowProperties9.Caption = "Esas No";
            this.multiEditorRowProperties9.CellWidth = 133;
            this.multiEditorRowProperties9.FieldName = "ESAS_NO";
            this.multiEditorRowProperties9.RowEdit = this.rtxtEsasNo;
            this.multiEditorRowProperties9.Width = 62;
            // 
            // rtxtEsasNo
            // 
            this.rtxtEsasNo.AutoHeight = false;
            this.rtxtEsasNo.Mask.EditMask = "..../.+";
            this.rtxtEsasNo.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.rtxtEsasNo.Name = "rtxtEsasNo";
            this.rtxtEsasNo.NullText = "<Esas No>";
            // 
            // multiEditorRowProperties10
            // 
            this.multiEditorRowProperties10.Caption = "Referans 1";
            this.multiEditorRowProperties10.FieldName = "REFERANS_NO";
            this.multiEditorRowProperties10.RowEdit = this.rtxtReferans;
            // 
            // rtxtReferans
            // 
            this.rtxtReferans.AutoHeight = false;
            this.rtxtReferans.Name = "rtxtReferans";
            this.rtxtReferans.NullText = "<Referans>";
            // 
            // multiEditorRowProperties11
            // 
            this.multiEditorRowProperties11.Caption = "Referans 2";
            this.multiEditorRowProperties11.FieldName = "REFERANS_NO2";
            this.multiEditorRowProperties11.RowEdit = this.rtxtReferans;
            // 
            // multiEditorRowProperties12
            // 
            this.multiEditorRowProperties12.Caption = "Referans 3";
            this.multiEditorRowProperties12.FieldName = "REFERANS_NO3";
            this.multiEditorRowProperties12.RowEdit = this.rtxtReferans;
            // 
            // multiEditorRowProperties13
            // 
            this.multiEditorRowProperties13.Caption = "Özel Kod 1";
            this.multiEditorRowProperties13.FieldName = "ICRA_OZEL_KOD1_ID";
            this.multiEditorRowProperties13.RowEdit = this.rlkOzelKod1;
            // 
            // rlkOzelKod1
            // 
            this.rlkOzelKod1.AutoHeight = false;
            this.rlkOzelKod1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkOzelKod1.Name = "rlkOzelKod1";
            this.rlkOzelKod1.NullText = "<Özel Kod>";
            this.rlkOzelKod1.Tag = "OzelKod";
            // 
            // multiEditorRowProperties14
            // 
            this.multiEditorRowProperties14.Caption = "Özel Kod 2";
            this.multiEditorRowProperties14.FieldName = "ICRA_OZEL_KOD2_ID";
            this.multiEditorRowProperties14.RowEdit = this.rlkOzelKod2;
            // 
            // rlkOzelKod2
            // 
            this.rlkOzelKod2.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rlkOzelKod2.AutoHeight = false;
            this.rlkOzelKod2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkOzelKod2.Name = "rlkOzelKod2";
            this.rlkOzelKod2.Tag = "OzelKod";
            // 
            // multiEditorRowProperties15
            // 
            this.multiEditorRowProperties15.Caption = "Özel Kod 3";
            this.multiEditorRowProperties15.FieldName = "ICRA_OZEL_KOD3_ID";
            this.multiEditorRowProperties15.RowEdit = this.rlkOzelKod3;
            // 
            // rlkOzelKod3
            // 
            this.rlkOzelKod3.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rlkOzelKod3.AutoHeight = false;
            this.rlkOzelKod3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkOzelKod3.Name = "rlkOzelKod3";
            this.rlkOzelKod3.Tag = "OzelKod";
            // 
            // multiEditorRowProperties16
            // 
            this.multiEditorRowProperties16.Caption = "Özel Kod 4";
            this.multiEditorRowProperties16.FieldName = "ICRA_OZEL_KOD4_ID";
            this.multiEditorRowProperties16.RowEdit = this.rlkOzelKod4;
            // 
            // rlkOzelKod4
            // 
            this.rlkOzelKod4.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rlkOzelKod4.AutoHeight = false;
            this.rlkOzelKod4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkOzelKod4.Name = "rlkOzelKod4";
            this.rlkOzelKod4.Tag = "OzelKod";
            // 
            // multiEditorRowProperties17
            // 
            this.multiEditorRowProperties17.Caption = "Form Tipi";
            this.multiEditorRowProperties17.CellWidth = 120;
            this.multiEditorRowProperties17.FieldName = "FORM_TIP_ID";
            this.multiEditorRowProperties17.RowEdit = this.rlkFormTipi;
            this.multiEditorRowProperties17.Width = 120;
            // 
            // multiEditorRowProperties18
            // 
            this.multiEditorRowProperties18.Caption = "Dosya No";
            this.multiEditorRowProperties18.CellWidth = 83;
            this.multiEditorRowProperties18.FieldName = "FOY_NO_Kod";
            this.multiEditorRowProperties18.RowEdit = this.rtxtDosyaNoKod;
            this.multiEditorRowProperties18.Width = 98;
            // 
            // rtxtDosyaNoKod
            // 
            this.rtxtDosyaNoKod.AutoHeight = false;
            this.rtxtDosyaNoKod.Name = "rtxtDosyaNoKod";
            this.rtxtDosyaNoKod.NullText = "<Kod>";
            // 
            // multiEditorRowProperties19
            // 
            this.multiEditorRowProperties19.CellWidth = 85;
            this.multiEditorRowProperties19.FieldName = "FOY_NO_Sayi";
            this.multiEditorRowProperties19.RowEdit = this.rtxtDosyaNoSayi;
            this.multiEditorRowProperties19.Width = 15;
            // 
            // rtxtDosyaNoSayi
            // 
            this.rtxtDosyaNoSayi.AutoHeight = false;
            this.rtxtDosyaNoSayi.Name = "rtxtDosyaNoSayi";
            this.rtxtDosyaNoSayi.NullText = "<No>";
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Av.";
            this.gridColumn14.FieldName = "AVUKAT_MI";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 35;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Ýzleyen.";
            this.gridColumn15.FieldName = "YETKILI_MI";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 3;
            this.gridColumn15.Width = 35;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // tabGiris
            // 
            this.tabGiris.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGiris.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.tabGiris.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.tabGiris.Location = new System.Drawing.Point(0, 0);
            this.tabGiris.Name = "tabGiris";
            this.tabGiris.SelectedTabPage = this.tpTakipGenelBilgileri;
            this.tabGiris.Size = new System.Drawing.Size(1173, 724);
            this.tabGiris.TabIndex = 0;
            this.tabGiris.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpTakipGenelBilgileri,
            this.tpGelismeBilgileri,
            this.tpSozTeminat,
            this.tabPageIhtarname,
            this.tbPPoliçe,
            this.tabPDosyaHesabiveYazdirma});
            this.tabGiris.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabGiris_SelectedPageChanged);
            this.tabGiris.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.tabGiris_SelectedPageChanging);
            // 
            // tpTakipGenelBilgileri
            // 
            this.tpTakipGenelBilgileri.Controls.Add(this.grpOnSayfaANeden);
            this.tpTakipGenelBilgileri.Controls.Add(this.kEvrakSplitter);
            this.tpTakipGenelBilgileri.Controls.Add(this.tcKevrak);
            this.tpTakipGenelBilgileri.Controls.Add(this.bottomPanel);
            this.tpTakipGenelBilgileri.Image = ((System.Drawing.Image)(resources.GetObject("tpTakipGenelBilgileri.Image")));
            this.tpTakipGenelBilgileri.Name = "tpTakipGenelBilgileri";
            this.tpTakipGenelBilgileri.Size = new System.Drawing.Size(990, 718);
            this.tpTakipGenelBilgileri.Text = "Alacak Bilgileri";
            // 
            // grpOnSayfaANeden
            // 
            this.grpOnSayfaANeden.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpOnSayfaANeden.Appearance.Options.UseFont = true;
            this.grpOnSayfaANeden.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpOnSayfaANeden.AppearanceCaption.Options.UseFont = true;
            this.grpOnSayfaANeden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOnSayfaANeden.Location = new System.Drawing.Point(0, 327);
            this.grpOnSayfaANeden.Name = "grpOnSayfaANeden";
            this.grpOnSayfaANeden.Size = new System.Drawing.Size(552, 391);
            this.grpOnSayfaANeden.TabIndex = 45;
            this.grpOnSayfaANeden.Text = "Alacak Nedenleri";
            // 
            // kEvrakSplitter
            // 
            this.kEvrakSplitter.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.kEvrakSplitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.kEvrakSplitter.Location = new System.Drawing.Point(552, 327);
            this.kEvrakSplitter.Name = "kEvrakSplitter";
            this.kEvrakSplitter.Size = new System.Drawing.Size(5, 391);
            this.kEvrakSplitter.TabIndex = 44;
            this.kEvrakSplitter.TabStop = false;
            this.kEvrakSplitter.Visible = false;
            // 
            // tcKevrak
            // 
            this.tcKevrak.Dock = System.Windows.Forms.DockStyle.Right;
            this.tcKevrak.Location = new System.Drawing.Point(557, 327);
            this.tcKevrak.Name = "tcKevrak";
            this.tcKevrak.SelectedTabPage = this.tpKiymetliEvrak;
            this.tcKevrak.Size = new System.Drawing.Size(433, 391);
            this.tcKevrak.TabIndex = 43;
            this.tcKevrak.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpKiymetliEvrak,
            this.tpKiymetliTaraf});
            this.tcKevrak.Visible = false;
            this.tcKevrak.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.tcKevrak_SelectedPageChanging);
            // 
            // tpKiymetliEvrak
            // 
            this.tpKiymetliEvrak.Name = "tpKiymetliEvrak";
            this.tpKiymetliEvrak.Size = new System.Drawing.Size(427, 363);
            this.tpKiymetliEvrak.Text = "Kýymetli Evraklar";
            // 
            // tpKiymetliTaraf
            // 
            this.tpKiymetliTaraf.Name = "tpKiymetliTaraf";
            this.tpKiymetliTaraf.Size = new System.Drawing.Size(427, 272);
            this.tpKiymetliTaraf.Text = "Kýymetli Evrak Taraflarý";
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.panelControlTaraflar);
            this.bottomPanel.Controls.Add(this.groupControl1);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomPanel.Location = new System.Drawing.Point(0, 0);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(990, 327);
            this.bottomPanel.TabIndex = 1;
            // 
            // panelControlTaraflar
            // 
            this.panelControlTaraflar.Controls.Add(this.groupControl4);
            this.panelControlTaraflar.Controls.Add(this.splitterControl2);
            this.panelControlTaraflar.Controls.Add(this.groupControl3);
            this.panelControlTaraflar.Controls.Add(this.splitterControl1);
            this.panelControlTaraflar.Controls.Add(this.groupControl2);
            this.panelControlTaraflar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlTaraflar.Location = new System.Drawing.Point(2, 178);
            this.panelControlTaraflar.Name = "panelControlTaraflar";
            this.panelControlTaraflar.Size = new System.Drawing.Size(986, 147);
            this.panelControlTaraflar.TabIndex = 42;
            // 
            // groupControl4
            // 
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.Controls.Add(this.pnSorumluAvukat);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(685, 2);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(299, 143);
            this.groupControl4.TabIndex = 6;
            this.groupControl4.Text = "Sorumlu Personel";
            // 
            // pnSorumluAvukat
            // 
            this.pnSorumluAvukat.Controls.Add(this.gcSorumluAvukat);
            this.pnSorumluAvukat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSorumluAvukat.Location = new System.Drawing.Point(2, 21);
            this.pnSorumluAvukat.Name = "pnSorumluAvukat";
            this.pnSorumluAvukat.Size = new System.Drawing.Size(295, 120);
            this.pnSorumluAvukat.TabIndex = 1;
            // 
            // gcSorumluAvukat
            // 
            this.gcSorumluAvukat.CustomButtonlarGorunmesin = false;
            this.gcSorumluAvukat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSorumluAvukat.DoNotExtendEmbedNavigator = false;
            this.gcSorumluAvukat.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcSorumluAvukat.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.gcSorumluAvukat.ExternalRepository = this.repositorylerim;
            this.gcSorumluAvukat.FilterText = null;
            this.gcSorumluAvukat.FilterValue = null;
            this.gcSorumluAvukat.GridlerDuzenlenebilir = true;
            this.gcSorumluAvukat.GridsFilterControl = null;
            this.gcSorumluAvukat.Location = new System.Drawing.Point(2, 2);
            this.gcSorumluAvukat.MainView = this.gvSorumluAvukat;
            this.gcSorumluAvukat.MyGridStyle = null;
            this.gcSorumluAvukat.Name = "gcSorumluAvukat";
            this.gcSorumluAvukat.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gcSorumluAvukat.ShowRowNumbers = false;
            this.gcSorumluAvukat.SilmeKaldirilsin = false;
            this.gcSorumluAvukat.Size = new System.Drawing.Size(291, 116);
            this.gcSorumluAvukat.TabIndex = 0;
            this.gcSorumluAvukat.TemizleKaldirGorunsunmu = false;
            this.gcSorumluAvukat.UniqueId = "f21bbcb3-8205-4c79-9f3d-164094eca0a0";
            this.gcSorumluAvukat.UseEmbeddedNavigator = true;
            this.gcSorumluAvukat.UseHyperDragDrop = false;
            this.gcSorumluAvukat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSorumluAvukat,
            this.gridView5});
            // 
            // gvSorumluAvukat
            // 
            this.gvSorumluAvukat.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn11});
            this.gvSorumluAvukat.GridControl = this.gcSorumluAvukat;
            this.gvSorumluAvukat.GroupPanelText = "Gruplama yapmak için bir sutun sürükleyin";
            this.gvSorumluAvukat.IndicatorWidth = 20;
            this.gvSorumluAvukat.Name = "gvSorumluAvukat";
            this.gvSorumluAvukat.NewItemRowText = "Yeni Kayýt Ekle";
            this.gvSorumluAvukat.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvSorumluAvukat.OptionsView.ShowGroupPanel = false;
            this.gvSorumluAvukat.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvSorumluAvukat_CellValueChanged);
            this.gvSorumluAvukat.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvSorumluAvukat_CellValueChanging);
            this.gvSorumluAvukat.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvSorumluAvukat_ValidateRow);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Sorumlu Avukat";
            this.gridColumn7.ColumnEdit = this.rglkSorumluAvs;
            this.gridColumn7.FieldName = "SORUMLU_AVUKAT_CARI_ID";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 170;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Ýzleyen";
            this.gridColumn11.FieldName = "YETKILI_MI";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            this.gridColumn11.Width = 32;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridView5
            // 
            this.gridView5.GridControl = this.gcSorumluAvukat;
            this.gridView5.Name = "gridView5";
            // 
            // splitterControl2
            // 
            this.splitterControl2.Location = new System.Drawing.Point(680, 2);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(5, 143);
            this.splitterControl2.TabIndex = 5;
            this.splitterControl2.TabStop = false;
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.pnTakipEdilen);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl3.Location = new System.Drawing.Point(342, 2);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(338, 143);
            this.groupControl3.TabIndex = 3;
            this.groupControl3.Text = "Borçlular";
            // 
            // pnTakipEdilen
            // 
            this.pnTakipEdilen.Controls.Add(this.gcTakipEdilen);
            this.pnTakipEdilen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTakipEdilen.Location = new System.Drawing.Point(2, 21);
            this.pnTakipEdilen.Name = "pnTakipEdilen";
            this.pnTakipEdilen.Size = new System.Drawing.Size(334, 120);
            this.pnTakipEdilen.TabIndex = 2;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(337, 2);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 143);
            this.splitterControl1.TabIndex = 4;
            this.splitterControl1.TabStop = false;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.pnTakipEden);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(335, 143);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Alacaklýlar";
            // 
            // pnTakipEden
            // 
            this.pnTakipEden.Controls.Add(this.gcTakipEden);
            this.pnTakipEden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTakipEden.Location = new System.Drawing.Point(2, 21);
            this.pnTakipEden.Name = "pnTakipEden";
            this.pnTakipEden.Size = new System.Drawing.Size(331, 120);
            this.pnTakipEden.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.xtraTabControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(986, 176);
            this.groupControl1.TabIndex = 40;
            this.groupControl1.Text = "Dosya Genel Bilgileri";
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl2.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.xtraTabControl2.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.xtraTabControl2.Location = new System.Drawing.Point(2, 21);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.tabpGenel;
            this.xtraTabControl2.Size = new System.Drawing.Size(982, 153);
            this.xtraTabControl2.TabIndex = 2;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabpGenel,
            this.tabpBankaSube});
            this.xtraTabControl2.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.xtraTabControl2_SelectedPageChanging);
            // 
            // tabpGenel
            // 
            this.tabpGenel.Controls.Add(this.vGridControl1);
            this.tabpGenel.Name = "tabpGenel";
            this.tabpGenel.Size = new System.Drawing.Size(902, 147);
            this.tabpGenel.Text = "Genel Bilgiler";
            // 
            // vGridControl1
            // 
            this.vGridControl1.Appearance.BandBorder.Options.UseBackColor = true;
            this.vGridControl1.Appearance.BandBorder.Options.UseBorderColor = true;
            this.vGridControl1.Appearance.Category.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vGridControl1.Appearance.Category.Options.UseFont = true;
            this.vGridControl1.Appearance.Empty.Options.UseBackColor = true;
            this.vGridControl1.Appearance.Empty.Options.UseBorderColor = true;
            this.vGridControl1.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vGridControl1.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.vGridControl1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.vGridControl1.Appearance.VertLine.Options.UseBackColor = true;
            this.vGridControl1.DataSource = this.bsrcMyFoy;
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.BandsView;
            this.vGridControl1.Location = new System.Drawing.Point(0, 0);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RecordWidth = 293;
            this.vGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkFormTipi,
            this.rtxtDosyaNoKod,
            this.rtxtDosyaNoSayi,
            this.rlkTakipKonu,
            this.rlkMudurluk,
            this.rtxtEsasNo,
            this.rlkTakipTarihi,
            this.rtxtReferans,
            this.rlkOzelKod1,
            this.rlkFoyDurum,
            this.rlueVekaletSozlesme,
            this.rlueMudurlukNo,
            this.rlkOzelKod2,
            this.rlkOzelKod3,
            this.rlkOzelKod4,
            this.rLueSegmentId});
            this.vGridControl1.RowHeaderWidth = 232;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.multiEditorRow1,
            this.rowTAKIP_TALEP_ID,
            this.multiEditorRow44,
            this.rowIlamsiziVarmi,
            this.multiEditorRow43,
            this.rowMudurlukIBANNo,
            this.rowSegment,
            this.rowTAKIP_YOLU,
            this.multiEditorRow40,
            this.multiEditorRow41,
            this.rowOzelKod3,
            this.rowSozlesme,
            this.rowAciklama});
            this.vGridControl1.Size = new System.Drawing.Size(902, 147);
            this.vGridControl1.TabIndex = 39;
            // 
            // rlkTakipKonu
            // 
            this.rlkTakipKonu.AutoHeight = false;
            this.rlkTakipKonu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkTakipKonu.Name = "rlkTakipKonu";
            this.rlkTakipKonu.NullText = "<Takip Konusu>";
            // 
            // rlueVekaletSozlesme
            // 
            this.rlueVekaletSozlesme.AutoHeight = false;
            this.rlueVekaletSozlesme.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueVekaletSozlesme.Name = "rlueVekaletSozlesme";
            this.rlueVekaletSozlesme.NullText = "<Sözleþme>";
            // 
            // rLueSegmentId
            // 
            this.rLueSegmentId.AutoHeight = false;
            this.rLueSegmentId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSegmentId.Name = "rLueSegmentId";
            // 
            // multiEditorRow1
            // 
            this.multiEditorRow1.Height = 16;
            this.multiEditorRow1.Name = "multiEditorRow1";
            this.multiEditorRow1.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties20,
            this.multiEditorRowProperties21,
            this.multiEditorRowProperties22});
            // 
            // multiEditorRowProperties20
            // 
            this.multiEditorRowProperties20.Caption = "Form Tipi";
            this.multiEditorRowProperties20.FieldName = "FORM_TIP_ID";
            this.multiEditorRowProperties20.RowEdit = this.rlkFormTipi;
            this.multiEditorRowProperties20.Width = 136;
            // 
            // multiEditorRowProperties21
            // 
            this.multiEditorRowProperties21.Caption = "Raf No";
            this.multiEditorRowProperties21.FieldName = "FOY_NO_Kod";
            this.multiEditorRowProperties21.Width = 48;
            // 
            // multiEditorRowProperties22
            // 
            this.multiEditorRowProperties22.FieldName = "FOY_NO_Sayi";
            this.multiEditorRowProperties22.Width = 31;
            // 
            // rowTAKIP_TALEP_ID
            // 
            this.rowTAKIP_TALEP_ID.Height = 15;
            this.rowTAKIP_TALEP_ID.Name = "rowTAKIP_TALEP_ID";
            this.rowTAKIP_TALEP_ID.Properties.Caption = "Takip Konusu";
            this.rowTAKIP_TALEP_ID.Properties.FieldName = "TAKIP_TALEP_ID";
            this.rowTAKIP_TALEP_ID.Properties.RowEdit = this.rlkTakipKonu;
            // 
            // multiEditorRow44
            // 
            this.multiEditorRow44.Height = 16;
            this.multiEditorRow44.Name = "multiEditorRow44";
            this.multiEditorRow44.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties23,
            this.multiEditorRowProperties24,
            this.multiEditorRowProperties25});
            // 
            // multiEditorRowProperties23
            // 
            this.multiEditorRowProperties23.Caption = "Takip T.";
            this.multiEditorRowProperties23.FieldName = "TAKIP_TARIHI";
            this.multiEditorRowProperties23.RowEdit = this.rlkTakipTarihi;
            this.multiEditorRowProperties23.Width = 116;
            // 
            // multiEditorRowProperties24
            // 
            this.multiEditorRowProperties24.Caption = "Durum";
            this.multiEditorRowProperties24.FieldName = "FOY_DURUM_ID";
            this.multiEditorRowProperties24.RowEdit = this.rlkFoyDurum;
            this.multiEditorRowProperties24.Width = 98;
            // 
            // multiEditorRowProperties25
            // 
            this.multiEditorRowProperties25.Caption = "Ýnt Tarihi";
            this.multiEditorRowProperties25.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            this.multiEditorRowProperties25.Width = 128;
            // 
            // rowIlamsiziVarmi
            // 
            this.rowIlamsiziVarmi.Name = "rowIlamsiziVarmi";
            this.rowIlamsiziVarmi.Properties.Caption = "Ýlamsýzla Birlikte";
            this.rowIlamsiziVarmi.Properties.FieldName = "IlamsiziVarmi";
            this.rowIlamsiziVarmi.Tag = "IlamsizIleBirlikte";
            this.rowIlamsiziVarmi.Visible = false;
            // 
            // multiEditorRow43
            // 
            this.multiEditorRow43.Name = "multiEditorRow43";
            this.multiEditorRow43.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties26,
            this.multiEditorRowProperties27,
            this.multiEditorRowProperties28});
            // 
            // multiEditorRowProperties26
            // 
            this.multiEditorRowProperties26.Caption = "Müdürlük";
            this.multiEditorRowProperties26.CellWidth = 119;
            this.multiEditorRowProperties26.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.multiEditorRowProperties26.RowEdit = this.rlkMudurluk;
            this.multiEditorRowProperties26.Width = 73;
            // 
            // multiEditorRowProperties27
            // 
            this.multiEditorRowProperties27.Caption = "No";
            this.multiEditorRowProperties27.CellWidth = 36;
            this.multiEditorRowProperties27.FieldName = "ADLI_BIRIM_NO_ID";
            this.multiEditorRowProperties27.RowEdit = this.rlueMudurlukNo;
            this.multiEditorRowProperties27.Width = 31;
            // 
            // multiEditorRowProperties28
            // 
            this.multiEditorRowProperties28.Caption = "Esas No";
            this.multiEditorRowProperties28.CellWidth = 133;
            this.multiEditorRowProperties28.FieldName = "ESAS_NO";
            this.multiEditorRowProperties28.RowEdit = this.rtxtEsasNo;
            this.multiEditorRowProperties28.Width = 62;
            // 
            // rowMudurlukIBANNo
            // 
            this.rowMudurlukIBANNo.Name = "rowMudurlukIBANNo";
            this.rowMudurlukIBANNo.Properties.Caption = "Müdürlük IBAN No";
            this.rowMudurlukIBANNo.Properties.FieldName = "ALACAKLI_TARAF_STATU";
            // 
            // rowSegment
            // 
            this.rowSegment.Height = 14;
            this.rowSegment.Name = "rowSegment";
            this.rowSegment.Properties.Caption = "Bölüm";
            this.rowSegment.Properties.FieldName = "SEGMENT_ID";
            this.rowSegment.Properties.RowEdit = this.rLueSegmentId;
            // 
            // rowTAKIP_YOLU
            // 
            this.rowTAKIP_YOLU.Height = 16;
            this.rowTAKIP_YOLU.Name = "rowTAKIP_YOLU";
            this.rowTAKIP_YOLU.Properties.Caption = "Takip Yolu";
            this.rowTAKIP_YOLU.Properties.FieldName = "TAKIP_YOLU";
            this.rowTAKIP_YOLU.Properties.ReadOnly = true;
            // 
            // multiEditorRow40
            // 
            this.multiEditorRow40.Height = 18;
            this.multiEditorRow40.Name = "multiEditorRow40";
            this.multiEditorRow40.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties29,
            this.multiEditorRowProperties30,
            this.multiEditorRowProperties31});
            // 
            // multiEditorRowProperties29
            // 
            this.multiEditorRowProperties29.Caption = "Referans 1";
            this.multiEditorRowProperties29.FieldName = "REFERANS_NO";
            this.multiEditorRowProperties29.RowEdit = this.rtxtReferans;
            // 
            // multiEditorRowProperties30
            // 
            this.multiEditorRowProperties30.Caption = "Referans 2";
            this.multiEditorRowProperties30.FieldName = "REFERANS_NO2";
            this.multiEditorRowProperties30.RowEdit = this.rtxtReferans;
            // 
            // multiEditorRowProperties31
            // 
            this.multiEditorRowProperties31.Caption = "Referans 3";
            this.multiEditorRowProperties31.FieldName = "REFERANS_NO3";
            this.multiEditorRowProperties31.RowEdit = this.rtxtReferans;
            // 
            // multiEditorRow41
            // 
            this.multiEditorRow41.Height = 19;
            this.multiEditorRow41.Name = "multiEditorRow41";
            this.multiEditorRow41.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties32,
            this.multiEditorRowProperties33});
            this.multiEditorRow41.Tag = "OzelKod12";
            // 
            // multiEditorRowProperties32
            // 
            this.multiEditorRowProperties32.Caption = "Özel Kod 1";
            this.multiEditorRowProperties32.FieldName = "ICRA_OZEL_KOD1_ID";
            this.multiEditorRowProperties32.RowEdit = this.rlkOzelKod1;
            // 
            // multiEditorRowProperties33
            // 
            this.multiEditorRowProperties33.Caption = "Özel Kod 2";
            this.multiEditorRowProperties33.FieldName = "ICRA_OZEL_KOD2_ID";
            this.multiEditorRowProperties33.RowEdit = this.rlkOzelKod2;
            // 
            // rowOzelKod3
            // 
            this.rowOzelKod3.Height = 17;
            this.rowOzelKod3.Name = "rowOzelKod3";
            this.rowOzelKod3.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties34,
            this.multiEditorRowProperties35});
            this.rowOzelKod3.Tag = "OzelKod34";
            // 
            // multiEditorRowProperties34
            // 
            this.multiEditorRowProperties34.Caption = "Özel Kod 3";
            this.multiEditorRowProperties34.FieldName = "ICRA_OZEL_KOD3_ID";
            this.multiEditorRowProperties34.RowEdit = this.rlkOzelKod3;
            // 
            // multiEditorRowProperties35
            // 
            this.multiEditorRowProperties35.Caption = "Özel Kod 4";
            this.multiEditorRowProperties35.FieldName = "ICRA_OZEL_KOD4_ID";
            this.multiEditorRowProperties35.RowEdit = this.rlkOzelKod4;
            // 
            // rowSozlesme
            // 
            this.rowSozlesme.Height = 19;
            this.rowSozlesme.Name = "rowSozlesme";
            this.rowSozlesme.Properties.Caption = "Sözleþme";
            this.rowSozlesme.Properties.FieldName = "VEKALET_SOZLESME_ID";
            this.rowSozlesme.Properties.RowEdit = this.rlueVekaletSozlesme;
            // 
            // rowAciklama
            // 
            this.rowAciklama.Height = 17;
            this.rowAciklama.Name = "rowAciklama";
            this.rowAciklama.Properties.Caption = "Açýklama";
            this.rowAciklama.Properties.FieldName = "ACIKLAMA";
            // 
            // tabpBankaSube
            // 
            this.tabpBankaSube.Name = "tabpBankaSube";
            this.tabpBankaSube.Size = new System.Drawing.Size(651, 147);
            this.tabpBankaSube.Text = "Þube Bilgileri";
            // 
            // tpGelismeBilgileri
            // 
            this.tpGelismeBilgileri.Controls.Add(this.splitContainerControl1);
            this.tpGelismeBilgileri.Image = ((System.Drawing.Image)(resources.GetObject("tpGelismeBilgileri.Image")));
            this.tpGelismeBilgileri.Name = "tpGelismeBilgileri";
            this.tpGelismeBilgileri.Size = new System.Drawing.Size(739, 627);
            this.tpGelismeBilgileri.Text = "Taraflarýn Sorumluluk  Bilgileri";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.pnlGelismeANeden);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(739, 627);
            this.splitContainerControl1.SplitterPosition = 237;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // pnlGelismeANeden
            // 
            this.pnlGelismeANeden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGelismeANeden.Location = new System.Drawing.Point(0, 0);
            this.pnlGelismeANeden.Name = "pnlGelismeANeden";
            this.pnlGelismeANeden.Size = new System.Drawing.Size(739, 237);
            this.pnlGelismeANeden.TabIndex = 1;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl1.Size = new System.Drawing.Size(739, 385);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.splitContainer2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(733, 357);
            this.xtraTabPage2.Text = "Alacak Neden Taraf Sorumluluk Bilgileri";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupControl5);
            this.splitContainer2.Size = new System.Drawing.Size(733, 357);
            this.splitContainer2.SplitterDistance = 332;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupControl5
            // 
            this.groupControl5.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl5.AppearanceCaption.Options.UseFont = true;
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl5.Location = new System.Drawing.Point(0, 0);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(397, 357);
            this.groupControl5.TabIndex = 1;
            this.groupControl5.Text = "Alacak Neden Taraf Faizleri";
            // 
            // tpSozTeminat
            // 
            this.tpSozTeminat.Controls.Add(this.spSozlesme);
            this.tpSozTeminat.Image = ((System.Drawing.Image)(resources.GetObject("tpSozTeminat.Image")));
            this.tpSozTeminat.Name = "tpSozTeminat";
            this.tpSozTeminat.Size = new System.Drawing.Size(739, 627);
            this.tpSozTeminat.Text = "Sözleþme Bilgileri";
            // 
            // spSozlesme
            // 
            this.spSozlesme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spSozlesme.Horizontal = false;
            this.spSozlesme.Location = new System.Drawing.Point(0, 0);
            this.spSozlesme.Name = "spSozlesme";
            this.spSozlesme.Panel1.Controls.Add(this.grpSozlesmeBilgileri);
            this.spSozlesme.Panel1.Text = "Panel1";
            this.spSozlesme.Panel2.Text = "Panel2";
            this.spSozlesme.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            this.spSozlesme.Size = new System.Drawing.Size(739, 627);
            this.spSozlesme.SplitterPosition = 289;
            this.spSozlesme.TabIndex = 9;
            this.spSozlesme.Text = "splitContainerControl2";
            // 
            // grpSozlesmeBilgileri
            // 
            this.grpSozlesmeBilgileri.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpSozlesmeBilgileri.AppearanceCaption.Options.UseFont = true;
            this.grpSozlesmeBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSozlesmeBilgileri.Location = new System.Drawing.Point(0, 0);
            this.grpSozlesmeBilgileri.Name = "grpSozlesmeBilgileri";
            this.grpSozlesmeBilgileri.Size = new System.Drawing.Size(739, 627);
            this.grpSozlesmeBilgileri.TabIndex = 8;
            this.grpSozlesmeBilgileri.Text = "Sözleþme Bilgileri";
            // 
            // tabPageIhtarname
            // 
            this.tabPageIhtarname.Controls.Add(this.splitContainerControl2);
            this.tabPageIhtarname.Image = ((System.Drawing.Image)(resources.GetObject("tabPageIhtarname.Image")));
            this.tabPageIhtarname.Name = "tabPageIhtarname";
            this.tabPageIhtarname.PageVisible = false;
            this.tabPageIhtarname.Size = new System.Drawing.Size(739, 627);
            this.tabPageIhtarname.Text = "Ýhtarname Bilgileri";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(739, 627);
            this.splitContainerControl2.SplitterPosition = 351;
            this.splitContainerControl2.TabIndex = 7;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gcAlacak);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, -68);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(739, 339);
            this.panelControl1.TabIndex = 7;
            // 
            // gcAlacak
            // 
            this.gcAlacak.CustomButtonlarGorunmesin = false;
            this.gcAlacak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAlacak.DoNotExtendEmbedNavigator = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcAlacak.ExternalRepository = this.MyRepository;
            this.gcAlacak.FilterText = null;
            this.gcAlacak.FilterValue = null;
            this.gcAlacak.GridlerDuzenlenebilir = true;
            this.gcAlacak.GridsFilterControl = null;
            this.gcAlacak.Location = new System.Drawing.Point(2, 2);
            this.gcAlacak.MainView = this.gwAlacak;
            this.gcAlacak.MyGridStyle = null;
            this.gcAlacak.Name = "gcAlacak";
            this.gcAlacak.ShowRowNumbers = false;
            this.gcAlacak.SilmeKaldirilsin = false;
            this.gcAlacak.Size = new System.Drawing.Size(735, 313);
            this.gcAlacak.TabIndex = 5;
            this.gcAlacak.TemizleKaldirGorunsunmu = false;
            this.gcAlacak.UniqueId = "449d621a-621f-47f3-9692-619c0a975a70";
            this.gcAlacak.UseEmbeddedNavigator = true;
            this.gcAlacak.UseHyperDragDrop = false;
            this.gcAlacak.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwAlacak,
            this.gridView1,
            this.gridView2,
            this.gridView4,
            this.gridView6,
            this.gridView7,
            this.gridView11});
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueAlacakNeden,
            this.rTutar,
            this.Date,
            this.rLueDoviz,
            this.rLueHesaplamaModu,
            this.rlueFaizTip,
            this.rLueKdvTipi});
            // 
            // rLueAlacakNeden
            // 
            this.rLueAlacakNeden.AutoHeight = false;
            this.rLueAlacakNeden.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.rLueAlacakNeden.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAlacakNeden.Name = "rLueAlacakNeden";
            // 
            // rTutar
            // 
            this.rTutar.AutoHeight = false;
            this.rTutar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.rTutar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rTutar.Name = "rTutar";
            // 
            // Date
            // 
            this.Date.AutoHeight = false;
            this.Date.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Date.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Date.Name = "Date";
            this.Date.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rLueDoviz
            // 
            this.rLueDoviz.AutoHeight = false;
            this.rLueDoviz.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.rLueDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDoviz.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.rLueDoviz.Name = "rLueDoviz";
            // 
            // rLueHesaplamaModu
            // 
            this.rLueHesaplamaModu.AutoHeight = false;
            this.rLueHesaplamaModu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.rLueHesaplamaModu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueHesaplamaModu.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.rLueHesaplamaModu.Name = "rLueHesaplamaModu";
            // 
            // rlueFaizTip
            // 
            this.rlueFaizTip.AutoHeight = false;
            this.rlueFaizTip.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.rlueFaizTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueFaizTip.Name = "rlueFaizTip";
            // 
            // rLueKdvTipi
            // 
            this.rLueKdvTipi.AutoHeight = false;
            this.rLueKdvTipi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.rLueKdvTipi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueKdvTipi.Name = "rLueKdvTipi";
            // 
            // gwAlacak
            // 
            this.gwAlacak.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.colALACAK_NEDEN_KOD_ID,
            this.colDIGER_ALACAK_NEDENI,
            this.colDUZENLENME_TARIHI,
            this.colVADE_TARIHI,
            this.colFAIZ_BASLANGIC_TARIHI,
            this.colHESAPLAMA_MODU,
            this.colTUTARI,
            this.colTUTAR_DOVIZ_ID,
            this.colISLEME_KONAN_TUTAR,
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID,
            this.colHARCA_ESAS_DEGER,
            this.colHARCA_ESAS_DEGER_DOVIZ_ID,
            this.colFAIZ_YOK,
            this.colALACAK_FAIZ_TIP_ID,
            this.colUYGULANACAK_FAIZ_ORANI,
            this.colTO_ALACAK_FAIZ_TIP_ID,
            this.colTO_UYGULANACAK_FAIZ_ORANI,
            this.colSABIT_FAIZ_UYGULA,
            this.colBIR_GUNE_AYLIK_FAIZ,
            this.colIHTAR_TARIHI,
            this.colIHTAR_GIDERI,
            this.colIHTAR_GIDERI_DOVIZ_ID,
            this.colPROTESTO_GIDERI,
            this.colPROTESTO_GIDERI_DOVIZ_ID,
            this.colHER_AY_TAZMINAT_EKLE,
            this.colTAZMINAT_TIP_ID,
            this.colTAZMINATI_ORANI,
            this.colCEK_TAZMINATI_ORANI,
            this.colKOMISYONU_ORANI,
            this.colBSMV_HESAPLANSIN,
            this.colKKDV_HESAPLANSIN,
            this.colOIV_HESAPLANSIN,
            this.colKDV_HESAPLANSIN,
            this.colKDV_TIP_ID,
            this.colDAMGA_PULU_HESAPLANSIN,
            this.colSURE_GUN,
            this.colSURE_AY,
            this.colSURE_YIL,
            this.colACIKLAMA,
            this.colREFERANS_NO2,
            this.colREFERANS_NO3});
            this.gwAlacak.GridControl = this.gcAlacak;
            this.gwAlacak.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gwAlacak.IndicatorWidth = 20;
            this.gwAlacak.Name = "gwAlacak";
            this.gwAlacak.NewItemRowText = "Yeni Kayýt Eklemek Ýçin Týklayýn..";
            this.gwAlacak.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwAlacak.OptionsNavigation.AutoFocusNewRow = true;
            this.gwAlacak.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwAlacak.OptionsView.ColumnAutoWidth = false;
            this.gwAlacak.OptionsView.RowAutoHeight = true;
            this.gwAlacak.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwAlacak.OptionsView.ShowDetailButtons = false;
            this.gwAlacak.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gwAlacak.OptionsView.ShowFooter = true;
            this.gwAlacak.OptionsView.ShowGroupPanel = false;
            this.gwAlacak.PaintStyleName = "Skin";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Seç";
            this.gridColumn8.FieldName = "IsSelected";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 40;
            // 
            // colALACAK_NEDEN_KOD_ID
            // 
            this.colALACAK_NEDEN_KOD_ID.Caption = "Alacak Neden";
            this.colALACAK_NEDEN_KOD_ID.ColumnEdit = this.rLueAlacakNeden;
            this.colALACAK_NEDEN_KOD_ID.FieldName = "ALACAK_NEDEN_KOD_ID";
            this.colALACAK_NEDEN_KOD_ID.Name = "colALACAK_NEDEN_KOD_ID";
            this.colALACAK_NEDEN_KOD_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colALACAK_NEDEN_KOD_ID.Visible = true;
            this.colALACAK_NEDEN_KOD_ID.VisibleIndex = 1;
            this.colALACAK_NEDEN_KOD_ID.Width = 99;
            // 
            // colDIGER_ALACAK_NEDENI
            // 
            this.colDIGER_ALACAK_NEDENI.Caption = "Diðer Alacak Nedeni";
            this.colDIGER_ALACAK_NEDENI.FieldName = "DIGER_ALACAK_NEDENI";
            this.colDIGER_ALACAK_NEDENI.Name = "colDIGER_ALACAK_NEDENI";
            this.colDIGER_ALACAK_NEDENI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDIGER_ALACAK_NEDENI.Visible = true;
            this.colDIGER_ALACAK_NEDENI.VisibleIndex = 2;
            this.colDIGER_ALACAK_NEDENI.Width = 118;
            // 
            // colDUZENLENME_TARIHI
            // 
            this.colDUZENLENME_TARIHI.Caption = "Düz. T.";
            this.colDUZENLENME_TARIHI.ColumnEdit = this.Date;
            this.colDUZENLENME_TARIHI.FieldName = "DUZENLENME_TARIHI";
            this.colDUZENLENME_TARIHI.Name = "colDUZENLENME_TARIHI";
            this.colDUZENLENME_TARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDUZENLENME_TARIHI.Visible = true;
            this.colDUZENLENME_TARIHI.VisibleIndex = 3;
            this.colDUZENLENME_TARIHI.Width = 67;
            // 
            // colVADE_TARIHI
            // 
            this.colVADE_TARIHI.Caption = "Vade T.";
            this.colVADE_TARIHI.ColumnEdit = this.Date;
            this.colVADE_TARIHI.FieldName = "VADE_TARIHI";
            this.colVADE_TARIHI.Name = "colVADE_TARIHI";
            this.colVADE_TARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colVADE_TARIHI.Visible = true;
            this.colVADE_TARIHI.VisibleIndex = 4;
            this.colVADE_TARIHI.Width = 72;
            // 
            // colFAIZ_BASLANGIC_TARIHI
            // 
            this.colFAIZ_BASLANGIC_TARIHI.Caption = "Faiz. Baþ. T.";
            this.colFAIZ_BASLANGIC_TARIHI.ColumnEdit = this.Date;
            this.colFAIZ_BASLANGIC_TARIHI.FieldName = "FAIZ_BASLANGIC_TARIHI";
            this.colFAIZ_BASLANGIC_TARIHI.Name = "colFAIZ_BASLANGIC_TARIHI";
            this.colFAIZ_BASLANGIC_TARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colFAIZ_BASLANGIC_TARIHI.Visible = true;
            this.colFAIZ_BASLANGIC_TARIHI.VisibleIndex = 5;
            // 
            // colHESAPLAMA_MODU
            // 
            this.colHESAPLAMA_MODU.Caption = "Hesap Modu";
            this.colHESAPLAMA_MODU.ColumnEdit = this.rLueHesaplamaModu;
            this.colHESAPLAMA_MODU.FieldName = "HESAPLAMA_MODU";
            this.colHESAPLAMA_MODU.Name = "colHESAPLAMA_MODU";
            this.colHESAPLAMA_MODU.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHESAPLAMA_MODU.Visible = true;
            this.colHESAPLAMA_MODU.VisibleIndex = 6;
            this.colHESAPLAMA_MODU.Width = 88;
            // 
            // colTUTARI
            // 
            this.colTUTARI.Caption = "Tutarý";
            this.colTUTARI.ColumnEdit = this.rTutar;
            this.colTUTARI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colTUTARI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTUTARI.FieldName = "TUTARI";
            this.colTUTARI.Name = "colTUTARI";
            this.colTUTARI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTUTARI.Visible = true;
            this.colTUTARI.VisibleIndex = 7;
            this.colTUTARI.Width = 68;
            // 
            // colTUTAR_DOVIZ_ID
            // 
            this.colTUTAR_DOVIZ_ID.ColumnEdit = this.rLueDoviz;
            this.colTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            this.colTUTAR_DOVIZ_ID.Name = "colTUTAR_DOVIZ_ID";
            this.colTUTAR_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTUTAR_DOVIZ_ID.Visible = true;
            this.colTUTAR_DOVIZ_ID.VisibleIndex = 8;
            this.colTUTAR_DOVIZ_ID.Width = 36;
            // 
            // colISLEME_KONAN_TUTAR
            // 
            this.colISLEME_KONAN_TUTAR.Caption = "Ýþleme Konan Tu.";
            this.colISLEME_KONAN_TUTAR.ColumnEdit = this.rTutar;
            this.colISLEME_KONAN_TUTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colISLEME_KONAN_TUTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colISLEME_KONAN_TUTAR.FieldName = "ISLEME_KONAN_TUTAR";
            this.colISLEME_KONAN_TUTAR.Name = "colISLEME_KONAN_TUTAR";
            this.colISLEME_KONAN_TUTAR.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colISLEME_KONAN_TUTAR.Visible = true;
            this.colISLEME_KONAN_TUTAR.VisibleIndex = 9;
            this.colISLEME_KONAN_TUTAR.Width = 95;
            // 
            // colISLEME_KONAN_TUTAR_DOVIZ_ID
            // 
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.ColumnEdit = this.rLueDoviz;
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.FieldName = "ISLEME_KONAN_TUTAR_DOVIZ_ID";
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.Name = "colISLEME_KONAN_TUTAR_DOVIZ_ID";
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.Visible = true;
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.VisibleIndex = 10;
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.Width = 32;
            // 
            // colHARCA_ESAS_DEGER
            // 
            this.colHARCA_ESAS_DEGER.Caption = "Esas Deðer";
            this.colHARCA_ESAS_DEGER.ColumnEdit = this.rTutar;
            this.colHARCA_ESAS_DEGER.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colHARCA_ESAS_DEGER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHARCA_ESAS_DEGER.FieldName = "HARCA_ESAS_DEGER";
            this.colHARCA_ESAS_DEGER.Name = "colHARCA_ESAS_DEGER";
            this.colHARCA_ESAS_DEGER.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHARCA_ESAS_DEGER.Visible = true;
            this.colHARCA_ESAS_DEGER.VisibleIndex = 11;
            // 
            // colHARCA_ESAS_DEGER_DOVIZ_ID
            // 
            this.colHARCA_ESAS_DEGER_DOVIZ_ID.ColumnEdit = this.rLueDoviz;
            this.colHARCA_ESAS_DEGER_DOVIZ_ID.FieldName = "HARCA_ESAS_DEGER_DOVIZ_ID";
            this.colHARCA_ESAS_DEGER_DOVIZ_ID.Name = "colHARCA_ESAS_DEGER_DOVIZ_ID";
            this.colHARCA_ESAS_DEGER_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHARCA_ESAS_DEGER_DOVIZ_ID.Visible = true;
            this.colHARCA_ESAS_DEGER_DOVIZ_ID.VisibleIndex = 12;
            this.colHARCA_ESAS_DEGER_DOVIZ_ID.Width = 28;
            // 
            // colFAIZ_YOK
            // 
            this.colFAIZ_YOK.Caption = "Faiz Yok";
            this.colFAIZ_YOK.FieldName = "FAIZ_YOK";
            this.colFAIZ_YOK.Name = "colFAIZ_YOK";
            this.colFAIZ_YOK.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colFAIZ_YOK.Visible = true;
            this.colFAIZ_YOK.VisibleIndex = 13;
            this.colFAIZ_YOK.Width = 51;
            // 
            // colALACAK_FAIZ_TIP_ID
            // 
            this.colALACAK_FAIZ_TIP_ID.Caption = "Faiz Tip";
            this.colALACAK_FAIZ_TIP_ID.ColumnEdit = this.rlueFaizTip;
            this.colALACAK_FAIZ_TIP_ID.FieldName = "ALACAK_FAIZ_TIP_ID";
            this.colALACAK_FAIZ_TIP_ID.Name = "colALACAK_FAIZ_TIP_ID";
            this.colALACAK_FAIZ_TIP_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colALACAK_FAIZ_TIP_ID.Visible = true;
            this.colALACAK_FAIZ_TIP_ID.VisibleIndex = 14;
            // 
            // colUYGULANACAK_FAIZ_ORANI
            // 
            this.colUYGULANACAK_FAIZ_ORANI.Caption = "Faiz Oraný";
            this.colUYGULANACAK_FAIZ_ORANI.ColumnEdit = this.rTutar;
            this.colUYGULANACAK_FAIZ_ORANI.FieldName = "UYGULANACAK_FAIZ_ORANI";
            this.colUYGULANACAK_FAIZ_ORANI.Name = "colUYGULANACAK_FAIZ_ORANI";
            this.colUYGULANACAK_FAIZ_ORANI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colUYGULANACAK_FAIZ_ORANI.Visible = true;
            this.colUYGULANACAK_FAIZ_ORANI.VisibleIndex = 15;
            // 
            // colTO_ALACAK_FAIZ_TIP_ID
            // 
            this.colTO_ALACAK_FAIZ_TIP_ID.Caption = "Alacak Faiz Tipi";
            this.colTO_ALACAK_FAIZ_TIP_ID.ColumnEdit = this.rlueFaizTip;
            this.colTO_ALACAK_FAIZ_TIP_ID.FieldName = "TO_ALACAK_FAIZ_TIP_ID";
            this.colTO_ALACAK_FAIZ_TIP_ID.Name = "colTO_ALACAK_FAIZ_TIP_ID";
            this.colTO_ALACAK_FAIZ_TIP_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTO_ALACAK_FAIZ_TIP_ID.Visible = true;
            this.colTO_ALACAK_FAIZ_TIP_ID.VisibleIndex = 16;
            this.colTO_ALACAK_FAIZ_TIP_ID.Width = 84;
            // 
            // colTO_UYGULANACAK_FAIZ_ORANI
            // 
            this.colTO_UYGULANACAK_FAIZ_ORANI.Caption = "Uygulanacak Faiz Oraný";
            this.colTO_UYGULANACAK_FAIZ_ORANI.ColumnEdit = this.rTutar;
            this.colTO_UYGULANACAK_FAIZ_ORANI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colTO_UYGULANACAK_FAIZ_ORANI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTO_UYGULANACAK_FAIZ_ORANI.FieldName = "TO_UYGULANACAK_FAIZ_ORANI";
            this.colTO_UYGULANACAK_FAIZ_ORANI.Name = "colTO_UYGULANACAK_FAIZ_ORANI";
            this.colTO_UYGULANACAK_FAIZ_ORANI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTO_UYGULANACAK_FAIZ_ORANI.Visible = true;
            this.colTO_UYGULANACAK_FAIZ_ORANI.VisibleIndex = 17;
            // 
            // colSABIT_FAIZ_UYGULA
            // 
            this.colSABIT_FAIZ_UYGULA.Caption = "S. F. Uygula";
            this.colSABIT_FAIZ_UYGULA.FieldName = "SABIT_FAIZ_UYGULA";
            this.colSABIT_FAIZ_UYGULA.Name = "colSABIT_FAIZ_UYGULA";
            this.colSABIT_FAIZ_UYGULA.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSABIT_FAIZ_UYGULA.Visible = true;
            this.colSABIT_FAIZ_UYGULA.VisibleIndex = 18;
            // 
            // colBIR_GUNE_AYLIK_FAIZ
            // 
            this.colBIR_GUNE_AYLIK_FAIZ.Caption = "1 A.F";
            this.colBIR_GUNE_AYLIK_FAIZ.FieldName = "BIR_GUNE_AYLIK_FAIZ";
            this.colBIR_GUNE_AYLIK_FAIZ.Name = "colBIR_GUNE_AYLIK_FAIZ";
            this.colBIR_GUNE_AYLIK_FAIZ.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colBIR_GUNE_AYLIK_FAIZ.Visible = true;
            this.colBIR_GUNE_AYLIK_FAIZ.VisibleIndex = 19;
            // 
            // colIHTAR_TARIHI
            // 
            this.colIHTAR_TARIHI.Caption = "Ýhtar T.";
            this.colIHTAR_TARIHI.ColumnEdit = this.Date;
            this.colIHTAR_TARIHI.FieldName = "IHTAR_TARIHI";
            this.colIHTAR_TARIHI.Name = "colIHTAR_TARIHI";
            this.colIHTAR_TARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colIHTAR_TARIHI.Visible = true;
            this.colIHTAR_TARIHI.VisibleIndex = 20;
            // 
            // colIHTAR_GIDERI
            // 
            this.colIHTAR_GIDERI.Caption = "Ýhtar Gi.";
            this.colIHTAR_GIDERI.ColumnEdit = this.rTutar;
            this.colIHTAR_GIDERI.FieldName = "IHTAR_GIDERI";
            this.colIHTAR_GIDERI.Name = "colIHTAR_GIDERI";
            this.colIHTAR_GIDERI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colIHTAR_GIDERI.Visible = true;
            this.colIHTAR_GIDERI.VisibleIndex = 21;
            // 
            // colIHTAR_GIDERI_DOVIZ_ID
            // 
            this.colIHTAR_GIDERI_DOVIZ_ID.ColumnEdit = this.rLueDoviz;
            this.colIHTAR_GIDERI_DOVIZ_ID.FieldName = "IHTAR_GIDERI_DOVIZ_ID";
            this.colIHTAR_GIDERI_DOVIZ_ID.Name = "colIHTAR_GIDERI_DOVIZ_ID";
            this.colIHTAR_GIDERI_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colIHTAR_GIDERI_DOVIZ_ID.Visible = true;
            this.colIHTAR_GIDERI_DOVIZ_ID.VisibleIndex = 22;
            // 
            // colPROTESTO_GIDERI
            // 
            this.colPROTESTO_GIDERI.Caption = "Pretesto Gideri";
            this.colPROTESTO_GIDERI.ColumnEdit = this.rTutar;
            this.colPROTESTO_GIDERI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colPROTESTO_GIDERI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPROTESTO_GIDERI.FieldName = "PROTESTO_GIDERI";
            this.colPROTESTO_GIDERI.Name = "colPROTESTO_GIDERI";
            this.colPROTESTO_GIDERI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPROTESTO_GIDERI.Visible = true;
            this.colPROTESTO_GIDERI.VisibleIndex = 23;
            // 
            // colPROTESTO_GIDERI_DOVIZ_ID
            // 
            this.colPROTESTO_GIDERI_DOVIZ_ID.ColumnEdit = this.rLueDoviz;
            this.colPROTESTO_GIDERI_DOVIZ_ID.FieldName = "PROTESTO_GIDERI_DOVIZ_ID";
            this.colPROTESTO_GIDERI_DOVIZ_ID.Name = "colPROTESTO_GIDERI_DOVIZ_ID";
            this.colPROTESTO_GIDERI_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPROTESTO_GIDERI_DOVIZ_ID.Visible = true;
            this.colPROTESTO_GIDERI_DOVIZ_ID.VisibleIndex = 24;
            // 
            // colHER_AY_TAZMINAT_EKLE
            // 
            this.colHER_AY_TAZMINAT_EKLE.Caption = "Taz. Ekle";
            this.colHER_AY_TAZMINAT_EKLE.FieldName = "HER_AY_TAZMINAT_EKLE";
            this.colHER_AY_TAZMINAT_EKLE.Name = "colHER_AY_TAZMINAT_EKLE";
            this.colHER_AY_TAZMINAT_EKLE.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHER_AY_TAZMINAT_EKLE.Visible = true;
            this.colHER_AY_TAZMINAT_EKLE.VisibleIndex = 25;
            // 
            // colTAZMINAT_TIP_ID
            // 
            this.colTAZMINAT_TIP_ID.Caption = "Tazminat Tip";
            this.colTAZMINAT_TIP_ID.FieldName = "TAZMINAT_TIP_ID";
            this.colTAZMINAT_TIP_ID.Name = "colTAZMINAT_TIP_ID";
            this.colTAZMINAT_TIP_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTAZMINAT_TIP_ID.Visible = true;
            this.colTAZMINAT_TIP_ID.VisibleIndex = 26;
            // 
            // colTAZMINATI_ORANI
            // 
            this.colTAZMINATI_ORANI.Caption = "Tazminatýn Oraný";
            this.colTAZMINATI_ORANI.ColumnEdit = this.rTutar;
            this.colTAZMINATI_ORANI.FieldName = "TAZMINATI_ORANI";
            this.colTAZMINATI_ORANI.Name = "colTAZMINATI_ORANI";
            this.colTAZMINATI_ORANI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTAZMINATI_ORANI.Visible = true;
            this.colTAZMINATI_ORANI.VisibleIndex = 27;
            // 
            // colCEK_TAZMINATI_ORANI
            // 
            this.colCEK_TAZMINATI_ORANI.Caption = "Çek Taz. Oraný";
            this.colCEK_TAZMINATI_ORANI.ColumnEdit = this.rTutar;
            this.colCEK_TAZMINATI_ORANI.FieldName = "CEK_TAZMINATI_ORANI";
            this.colCEK_TAZMINATI_ORANI.Name = "colCEK_TAZMINATI_ORANI";
            this.colCEK_TAZMINATI_ORANI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCEK_TAZMINATI_ORANI.Visible = true;
            this.colCEK_TAZMINATI_ORANI.VisibleIndex = 28;
            // 
            // colKOMISYONU_ORANI
            // 
            this.colKOMISYONU_ORANI.Caption = "Kom.";
            this.colKOMISYONU_ORANI.ColumnEdit = this.rTutar;
            this.colKOMISYONU_ORANI.FieldName = "KOMISYONU_ORANI";
            this.colKOMISYONU_ORANI.Name = "colKOMISYONU_ORANI";
            this.colKOMISYONU_ORANI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colKOMISYONU_ORANI.Visible = true;
            this.colKOMISYONU_ORANI.VisibleIndex = 29;
            // 
            // colBSMV_HESAPLANSIN
            // 
            this.colBSMV_HESAPLANSIN.Caption = "BSMV Hesaplansýn";
            this.colBSMV_HESAPLANSIN.FieldName = "BSMV_HESAPLANSIN";
            this.colBSMV_HESAPLANSIN.Name = "colBSMV_HESAPLANSIN";
            this.colBSMV_HESAPLANSIN.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colBSMV_HESAPLANSIN.Visible = true;
            this.colBSMV_HESAPLANSIN.VisibleIndex = 30;
            // 
            // colKKDV_HESAPLANSIN
            // 
            this.colKKDV_HESAPLANSIN.Caption = "KKDV Hesaplansýn";
            this.colKKDV_HESAPLANSIN.FieldName = "KKDV_HESAPLANSIN";
            this.colKKDV_HESAPLANSIN.Name = "colKKDV_HESAPLANSIN";
            this.colKKDV_HESAPLANSIN.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colKKDV_HESAPLANSIN.Visible = true;
            this.colKKDV_HESAPLANSIN.VisibleIndex = 31;
            // 
            // colOIV_HESAPLANSIN
            // 
            this.colOIV_HESAPLANSIN.Caption = "OIV Hesaplansýn";
            this.colOIV_HESAPLANSIN.FieldName = "OIV_HESAPLANSIN";
            this.colOIV_HESAPLANSIN.Name = "colOIV_HESAPLANSIN";
            this.colOIV_HESAPLANSIN.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colOIV_HESAPLANSIN.Visible = true;
            this.colOIV_HESAPLANSIN.VisibleIndex = 32;
            // 
            // colKDV_HESAPLANSIN
            // 
            this.colKDV_HESAPLANSIN.Caption = "KDV Hesaplansýn";
            this.colKDV_HESAPLANSIN.FieldName = "KDV_HESAPLANSIN";
            this.colKDV_HESAPLANSIN.Name = "colKDV_HESAPLANSIN";
            this.colKDV_HESAPLANSIN.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colKDV_HESAPLANSIN.Visible = true;
            this.colKDV_HESAPLANSIN.VisibleIndex = 33;
            // 
            // colKDV_TIP_ID
            // 
            this.colKDV_TIP_ID.Caption = "KDV Tipi";
            this.colKDV_TIP_ID.ColumnEdit = this.rLueKdvTipi;
            this.colKDV_TIP_ID.FieldName = "KDV_TIP_ID";
            this.colKDV_TIP_ID.Name = "colKDV_TIP_ID";
            this.colKDV_TIP_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colKDV_TIP_ID.Visible = true;
            this.colKDV_TIP_ID.VisibleIndex = 34;
            // 
            // colDAMGA_PULU_HESAPLANSIN
            // 
            this.colDAMGA_PULU_HESAPLANSIN.Caption = "D. P. Hesaplansýn";
            this.colDAMGA_PULU_HESAPLANSIN.FieldName = "DAMGA_PULU_HESAPLANSIN";
            this.colDAMGA_PULU_HESAPLANSIN.Name = "colDAMGA_PULU_HESAPLANSIN";
            this.colDAMGA_PULU_HESAPLANSIN.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDAMGA_PULU_HESAPLANSIN.Visible = true;
            this.colDAMGA_PULU_HESAPLANSIN.VisibleIndex = 35;
            // 
            // colSURE_GUN
            // 
            this.colSURE_GUN.Caption = "Gün";
            this.colSURE_GUN.FieldName = "SURE_GUN";
            this.colSURE_GUN.Name = "colSURE_GUN";
            this.colSURE_GUN.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSURE_GUN.Visible = true;
            this.colSURE_GUN.VisibleIndex = 36;
            // 
            // colSURE_AY
            // 
            this.colSURE_AY.Caption = "Ay";
            this.colSURE_AY.FieldName = "SURE_AY";
            this.colSURE_AY.Name = "colSURE_AY";
            this.colSURE_AY.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSURE_AY.Visible = true;
            this.colSURE_AY.VisibleIndex = 37;
            // 
            // colSURE_YIL
            // 
            this.colSURE_YIL.Caption = "Yýl";
            this.colSURE_YIL.FieldName = "SURE_YIL";
            this.colSURE_YIL.Name = "colSURE_YIL";
            this.colSURE_YIL.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSURE_YIL.Visible = true;
            this.colSURE_YIL.VisibleIndex = 38;
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açýklama";
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 39;
            // 
            // colREFERANS_NO2
            // 
            this.colREFERANS_NO2.Caption = "Ref. No 2";
            this.colREFERANS_NO2.FieldName = "REFERANS_NO2";
            this.colREFERANS_NO2.Name = "colREFERANS_NO2";
            this.colREFERANS_NO2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colREFERANS_NO2.Visible = true;
            this.colREFERANS_NO2.VisibleIndex = 40;
            // 
            // colREFERANS_NO3
            // 
            this.colREFERANS_NO3.Caption = "Ref. No 3";
            this.colREFERANS_NO3.FieldName = "REFERANS_NO3";
            this.colREFERANS_NO3.Name = "colREFERANS_NO3";
            this.colREFERANS_NO3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colREFERANS_NO3.Visible = true;
            this.colREFERANS_NO3.VisibleIndex = 41;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GEMI_UCAK_ARAC_TIP,
            this.ADI,
            this.CINSI,
            this.TESCIL_NUMARASI,
            this.TANIMA_ISARETI,
            this.INSA_YILI,
            this.INSA_YERI,
            this.BOYU,
            this.ENI,
            this.TONALITOSU,
            this.BAGLAMA_LIMANI,
            this.TEKNIK_KUTUK_NO,
            this.ERISIM_NO,
            this.TIPI,
            this.DERINLIGI,
            this.KUTUK_BOYU,
            this.ARAC_PLAKA,
            this.ARAC_MODEL,
            this.ARAC_TIP,
            this.ARAC_MOTOR_NO,
            this.ARAC_SASI_NO,
            this.ARAC_RENK,
            this.TRAFIK_SUBESI,
            this.RUHSAT_TARIHI,
            this.RUHSAT_SICIL_NO});
            this.gridView1.GridControl = this.gcAlacak;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView1.ViewCaption = "Gemi-Uçak-Araç";
            // 
            // GEMI_UCAK_ARAC_TIP
            // 
            this.GEMI_UCAK_ARAC_TIP.Caption = "Tip";
            this.GEMI_UCAK_ARAC_TIP.FieldName = "GEMI_UCAK_ARAC_TIP";
            this.GEMI_UCAK_ARAC_TIP.Name = "GEMI_UCAK_ARAC_TIP";
            this.GEMI_UCAK_ARAC_TIP.Visible = true;
            this.GEMI_UCAK_ARAC_TIP.VisibleIndex = 1;
            // 
            // ADI
            // 
            this.ADI.Caption = "Adý";
            this.ADI.FieldName = "ADI";
            this.ADI.Name = "ADI";
            this.ADI.Visible = true;
            this.ADI.VisibleIndex = 2;
            // 
            // CINSI
            // 
            this.CINSI.Caption = "Cinsi";
            this.CINSI.FieldName = "CINSI";
            this.CINSI.Name = "CINSI";
            this.CINSI.Visible = true;
            this.CINSI.VisibleIndex = 3;
            // 
            // TESCIL_NUMARASI
            // 
            this.TESCIL_NUMARASI.Caption = "Tescil Numarasý";
            this.TESCIL_NUMARASI.FieldName = "TESCIL_NUMARASI";
            this.TESCIL_NUMARASI.Name = "TESCIL_NUMARASI";
            this.TESCIL_NUMARASI.Visible = true;
            this.TESCIL_NUMARASI.VisibleIndex = 4;
            // 
            // TANIMA_ISARETI
            // 
            this.TANIMA_ISARETI.Caption = "Tanýma Ýþareti";
            this.TANIMA_ISARETI.FieldName = "TANIMA_ISARETI";
            this.TANIMA_ISARETI.Name = "TANIMA_ISARETI";
            this.TANIMA_ISARETI.Visible = true;
            this.TANIMA_ISARETI.VisibleIndex = 5;
            // 
            // INSA_YILI
            // 
            this.INSA_YILI.Caption = "Ýnþa Yýlý";
            this.INSA_YILI.FieldName = "INSA_YILI";
            this.INSA_YILI.Name = "INSA_YILI";
            this.INSA_YILI.Visible = true;
            this.INSA_YILI.VisibleIndex = 6;
            // 
            // INSA_YERI
            // 
            this.INSA_YERI.Caption = "Ýnþa Yeri";
            this.INSA_YERI.FieldName = "INSA_YERI";
            this.INSA_YERI.Name = "INSA_YERI";
            this.INSA_YERI.Visible = true;
            this.INSA_YERI.VisibleIndex = 7;
            // 
            // BOYU
            // 
            this.BOYU.Caption = "Boyu";
            this.BOYU.FieldName = "BOYU";
            this.BOYU.Name = "BOYU";
            this.BOYU.Visible = true;
            this.BOYU.VisibleIndex = 8;
            // 
            // ENI
            // 
            this.ENI.Caption = "Eni";
            this.ENI.FieldName = "ENI";
            this.ENI.Name = "ENI";
            this.ENI.Visible = true;
            this.ENI.VisibleIndex = 9;
            // 
            // TONALITOSU
            // 
            this.TONALITOSU.Caption = "Tonalitosu";
            this.TONALITOSU.FieldName = "TONALITOSU";
            this.TONALITOSU.Name = "TONALITOSU";
            this.TONALITOSU.Visible = true;
            this.TONALITOSU.VisibleIndex = 10;
            // 
            // BAGLAMA_LIMANI
            // 
            this.BAGLAMA_LIMANI.Caption = "Baðlama Limaný";
            this.BAGLAMA_LIMANI.FieldName = "BAGLAMA_LIMANI";
            this.BAGLAMA_LIMANI.Name = "BAGLAMA_LIMANI";
            this.BAGLAMA_LIMANI.Visible = true;
            this.BAGLAMA_LIMANI.VisibleIndex = 11;
            // 
            // TEKNIK_KUTUK_NO
            // 
            this.TEKNIK_KUTUK_NO.Caption = "Kütük No";
            this.TEKNIK_KUTUK_NO.FieldName = "TEKNIK_KUTUK_NO";
            this.TEKNIK_KUTUK_NO.Name = "TEKNIK_KUTUK_NO";
            this.TEKNIK_KUTUK_NO.Visible = true;
            this.TEKNIK_KUTUK_NO.VisibleIndex = 12;
            // 
            // ERISIM_NO
            // 
            this.ERISIM_NO.Caption = "Eriþim No";
            this.ERISIM_NO.FieldName = "ERISIM_NO";
            this.ERISIM_NO.Name = "ERISIM_NO";
            this.ERISIM_NO.Visible = true;
            this.ERISIM_NO.VisibleIndex = 13;
            // 
            // TIPI
            // 
            this.TIPI.Caption = "Tipi";
            this.TIPI.FieldName = "TIPI";
            this.TIPI.Name = "TIPI";
            this.TIPI.Visible = true;
            this.TIPI.VisibleIndex = 14;
            // 
            // DERINLIGI
            // 
            this.DERINLIGI.Caption = "Derinliði";
            this.DERINLIGI.FieldName = "DERINLIGI";
            this.DERINLIGI.Name = "DERINLIGI";
            this.DERINLIGI.Visible = true;
            this.DERINLIGI.VisibleIndex = 15;
            // 
            // KUTUK_BOYU
            // 
            this.KUTUK_BOYU.Caption = "Kütük Boyu";
            this.KUTUK_BOYU.FieldName = "KUTUK_BOYU";
            this.KUTUK_BOYU.Name = "KUTUK_BOYU";
            this.KUTUK_BOYU.Visible = true;
            this.KUTUK_BOYU.VisibleIndex = 16;
            // 
            // ARAC_PLAKA
            // 
            this.ARAC_PLAKA.Caption = "Plaka";
            this.ARAC_PLAKA.FieldName = "ARAC_PLAKA";
            this.ARAC_PLAKA.Name = "ARAC_PLAKA";
            this.ARAC_PLAKA.Visible = true;
            this.ARAC_PLAKA.VisibleIndex = 17;
            // 
            // ARAC_MODEL
            // 
            this.ARAC_MODEL.Caption = "Araç Model";
            this.ARAC_MODEL.FieldName = "ARAC_MODEL";
            this.ARAC_MODEL.Name = "ARAC_MODEL";
            this.ARAC_MODEL.Visible = true;
            this.ARAC_MODEL.VisibleIndex = 18;
            // 
            // ARAC_TIP
            // 
            this.ARAC_TIP.Caption = "Araç Tip";
            this.ARAC_TIP.FieldName = "ARAC_TIP";
            this.ARAC_TIP.Name = "ARAC_TIP";
            this.ARAC_TIP.Visible = true;
            this.ARAC_TIP.VisibleIndex = 19;
            // 
            // ARAC_MOTOR_NO
            // 
            this.ARAC_MOTOR_NO.Caption = "Araç Motor No";
            this.ARAC_MOTOR_NO.FieldName = "ARAC_MOTOR_NO";
            this.ARAC_MOTOR_NO.Name = "ARAC_MOTOR_NO";
            this.ARAC_MOTOR_NO.Visible = true;
            this.ARAC_MOTOR_NO.VisibleIndex = 20;
            // 
            // ARAC_SASI_NO
            // 
            this.ARAC_SASI_NO.Caption = "Þasi No";
            this.ARAC_SASI_NO.FieldName = "ARAC_SASI_NO";
            this.ARAC_SASI_NO.Name = "ARAC_SASI_NO";
            this.ARAC_SASI_NO.Visible = true;
            this.ARAC_SASI_NO.VisibleIndex = 21;
            // 
            // ARAC_RENK
            // 
            this.ARAC_RENK.Caption = "Araç Renk";
            this.ARAC_RENK.FieldName = "ARAC_RENK";
            this.ARAC_RENK.Name = "ARAC_RENK";
            this.ARAC_RENK.Visible = true;
            this.ARAC_RENK.VisibleIndex = 22;
            // 
            // TRAFIK_SUBESI
            // 
            this.TRAFIK_SUBESI.Caption = "Trafik Þubesi";
            this.TRAFIK_SUBESI.FieldName = "TRAFIK_SUBESI";
            this.TRAFIK_SUBESI.Name = "TRAFIK_SUBESI";
            this.TRAFIK_SUBESI.Visible = true;
            this.TRAFIK_SUBESI.VisibleIndex = 23;
            // 
            // RUHSAT_TARIHI
            // 
            this.RUHSAT_TARIHI.Caption = "Ruhsat T.";
            this.RUHSAT_TARIHI.FieldName = "RUHSAT_TARIHI";
            this.RUHSAT_TARIHI.Name = "RUHSAT_TARIHI";
            this.RUHSAT_TARIHI.Visible = true;
            this.RUHSAT_TARIHI.VisibleIndex = 24;
            // 
            // RUHSAT_SICIL_NO
            // 
            this.RUHSAT_SICIL_NO.Caption = "Sicil No";
            this.RUHSAT_SICIL_NO.FieldName = "RUHSAT_SICIL_NO";
            this.RUHSAT_SICIL_NO.Name = "RUHSAT_SICIL_NO";
            this.RUHSAT_SICIL_NO.Visible = true;
            this.RUHSAT_SICIL_NO.VisibleIndex = 0;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gcAlacak;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colICRA_ALACAK_NEDEN_ID,
            this.colTARAF_CARI_ID1,
            this.colFAIZ_BASLANGIC_TARIHI1,
            this.colFAIZ_BITIS_TARIHI,
            this.colSABIT_FAIZ,
            this.colBIR_GUNE_AYLIK_FAIZ1,
            this.colFAIZ_TIP_ID});
            this.gridView4.GridControl = this.gcAlacak;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView4.ViewCaption = "Faiz";
            // 
            // colICRA_ALACAK_NEDEN_ID
            // 
            this.colICRA_ALACAK_NEDEN_ID.Caption = "Alacak Neden";
            this.colICRA_ALACAK_NEDEN_ID.FieldName = "ICRA_ALACAK_NEDEN_ID";
            this.colICRA_ALACAK_NEDEN_ID.Name = "colICRA_ALACAK_NEDEN_ID";
            // 
            // colTARAF_CARI_ID1
            // 
            this.colTARAF_CARI_ID1.Caption = "Þahýs";
            this.colTARAF_CARI_ID1.FieldName = "TARAF_CARI_ID";
            this.colTARAF_CARI_ID1.Name = "colTARAF_CARI_ID1";
            // 
            // colFAIZ_BASLANGIC_TARIHI1
            // 
            this.colFAIZ_BASLANGIC_TARIHI1.Caption = "Baþlangýç T.";
            this.colFAIZ_BASLANGIC_TARIHI1.FieldName = "FAIZ_BASLANGIC_TARIHI";
            this.colFAIZ_BASLANGIC_TARIHI1.Name = "colFAIZ_BASLANGIC_TARIHI1";
            this.colFAIZ_BASLANGIC_TARIHI1.Visible = true;
            this.colFAIZ_BASLANGIC_TARIHI1.VisibleIndex = 0;
            // 
            // colFAIZ_BITIS_TARIHI
            // 
            this.colFAIZ_BITIS_TARIHI.Caption = "Bitiþ T.";
            this.colFAIZ_BITIS_TARIHI.FieldName = "FAIZ_BITIS_TARIHI";
            this.colFAIZ_BITIS_TARIHI.Name = "colFAIZ_BITIS_TARIHI";
            this.colFAIZ_BITIS_TARIHI.Visible = true;
            this.colFAIZ_BITIS_TARIHI.VisibleIndex = 1;
            // 
            // colSABIT_FAIZ
            // 
            this.colSABIT_FAIZ.Caption = "Sabit Faiz";
            this.colSABIT_FAIZ.FieldName = "SABIT_FAIZ";
            this.colSABIT_FAIZ.Name = "colSABIT_FAIZ";
            this.colSABIT_FAIZ.Visible = true;
            this.colSABIT_FAIZ.VisibleIndex = 2;
            // 
            // colBIR_GUNE_AYLIK_FAIZ1
            // 
            this.colBIR_GUNE_AYLIK_FAIZ1.Caption = "1 Güne Aylik Faiz";
            this.colBIR_GUNE_AYLIK_FAIZ1.FieldName = "BIR_GUNE_AYLIK_FAIZ";
            this.colBIR_GUNE_AYLIK_FAIZ1.Name = "colBIR_GUNE_AYLIK_FAIZ1";
            this.colBIR_GUNE_AYLIK_FAIZ1.Visible = true;
            this.colBIR_GUNE_AYLIK_FAIZ1.VisibleIndex = 3;
            // 
            // colFAIZ_TIP_ID
            // 
            this.colFAIZ_TIP_ID.Caption = "Faiz Tip";
            this.colFAIZ_TIP_ID.FieldName = "FAIZ_TIP_ID";
            this.colFAIZ_TIP_ID.Name = "colFAIZ_TIP_ID";
            this.colFAIZ_TIP_ID.Visible = true;
            this.colFAIZ_TIP_ID.VisibleIndex = 4;
            // 
            // gridView6
            // 
            this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.EVRAK_TUR_ID,
            this.EVRAK_KAYIT_TARIHI,
            this.EVRAK_VADE_TARIHI,
            this.EVRAK_TANZIM_TARIHI,
            this.TUTAR_DOVIZ_ID,
            this.TUTAR,
            this.NE_SEKILDE_AHZOLUNDUGU,
            this.BANKA_ID,
            this.SUBE_ID,
            this.BANKA_SUBE_KODU,
            this.HESAP_NO,
            this.CEK_NO,
            this.SORULDUGU_TARIH,
            this.SORULMA_SONUCU,
            this.KARSILIK_TUTAR_DOVIZ_ID,
            this.KARSILIK_TUTAR,
            this.SORAN_ID,
            this.ARKASI_YAZILDI_MI,
            this.SERH_ACIKLAMASI,
            this.ILK_ALACAKLI_ID,
            this.ILK_BORCLU_ID,
            this.SIKAYET_EDILDI_MI,
            this.KESIDE_YERI,
            this.ODEME_YERI,
            this.ISLEMLER_BASLADIMI});
            this.gridView6.GridControl = this.gcAlacak;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView6.OptionsView.ShowPreview = true;
            this.gridView6.PreviewFieldName = "SERH_ACIKLAMASI";
            this.gridView6.ViewCaption = "Kýymetli Evrak";
            // 
            // EVRAK_TUR_ID
            // 
            this.EVRAK_TUR_ID.Caption = "Evrak Tür";
            this.EVRAK_TUR_ID.FieldName = "EVRAK_TUR_ID";
            this.EVRAK_TUR_ID.Name = "EVRAK_TUR_ID";
            this.EVRAK_TUR_ID.Visible = true;
            this.EVRAK_TUR_ID.VisibleIndex = 0;
            // 
            // EVRAK_KAYIT_TARIHI
            // 
            this.EVRAK_KAYIT_TARIHI.Caption = "Evrak Kayýt T.";
            this.EVRAK_KAYIT_TARIHI.FieldName = "EVRAK_KAYIT_TARIHI";
            this.EVRAK_KAYIT_TARIHI.Name = "EVRAK_KAYIT_TARIHI";
            this.EVRAK_KAYIT_TARIHI.Visible = true;
            this.EVRAK_KAYIT_TARIHI.VisibleIndex = 1;
            // 
            // EVRAK_VADE_TARIHI
            // 
            this.EVRAK_VADE_TARIHI.Caption = "Vade T.";
            this.EVRAK_VADE_TARIHI.FieldName = "EVRAK_VADE_TARIHI";
            this.EVRAK_VADE_TARIHI.Name = "EVRAK_VADE_TARIHI";
            this.EVRAK_VADE_TARIHI.Visible = true;
            this.EVRAK_VADE_TARIHI.VisibleIndex = 2;
            // 
            // EVRAK_TANZIM_TARIHI
            // 
            this.EVRAK_TANZIM_TARIHI.Caption = "Tanzim T.";
            this.EVRAK_TANZIM_TARIHI.FieldName = "EVRAK_TANZIM_TARIHI";
            this.EVRAK_TANZIM_TARIHI.Name = "EVRAK_TANZIM_TARIHI";
            this.EVRAK_TANZIM_TARIHI.Visible = true;
            this.EVRAK_TANZIM_TARIHI.VisibleIndex = 3;
            // 
            // TUTAR_DOVIZ_ID
            // 
            this.TUTAR_DOVIZ_ID.Caption = "BRM";
            this.TUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            this.TUTAR_DOVIZ_ID.Name = "TUTAR_DOVIZ_ID";
            this.TUTAR_DOVIZ_ID.Visible = true;
            this.TUTAR_DOVIZ_ID.VisibleIndex = 4;
            // 
            // TUTAR
            // 
            this.TUTAR.Caption = "Tutar";
            this.TUTAR.FieldName = "TUTAR";
            this.TUTAR.Name = "TUTAR";
            this.TUTAR.Visible = true;
            this.TUTAR.VisibleIndex = 5;
            // 
            // NE_SEKILDE_AHZOLUNDUGU
            // 
            this.NE_SEKILDE_AHZOLUNDUGU.Caption = "Ne Þekilde Ahzoldu";
            this.NE_SEKILDE_AHZOLUNDUGU.FieldName = "NE_SEKILDE_AHZOLUNDUGU";
            this.NE_SEKILDE_AHZOLUNDUGU.Name = "NE_SEKILDE_AHZOLUNDUGU";
            this.NE_SEKILDE_AHZOLUNDUGU.Visible = true;
            this.NE_SEKILDE_AHZOLUNDUGU.VisibleIndex = 6;
            // 
            // BANKA_ID
            // 
            this.BANKA_ID.Caption = "Banka";
            this.BANKA_ID.FieldName = "BANKA_ID";
            this.BANKA_ID.Name = "BANKA_ID";
            this.BANKA_ID.Visible = true;
            this.BANKA_ID.VisibleIndex = 7;
            // 
            // SUBE_ID
            // 
            this.SUBE_ID.Caption = "Þube";
            this.SUBE_ID.FieldName = "SUBE_ID";
            this.SUBE_ID.Name = "SUBE_ID";
            this.SUBE_ID.Visible = true;
            this.SUBE_ID.VisibleIndex = 8;
            // 
            // BANKA_SUBE_KODU
            // 
            this.BANKA_SUBE_KODU.Caption = "Banka Þube Kodu";
            this.BANKA_SUBE_KODU.FieldName = "BANKA_SUBE_KODU";
            this.BANKA_SUBE_KODU.Name = "BANKA_SUBE_KODU";
            this.BANKA_SUBE_KODU.Visible = true;
            this.BANKA_SUBE_KODU.VisibleIndex = 9;
            // 
            // HESAP_NO
            // 
            this.HESAP_NO.Caption = "Hesap No";
            this.HESAP_NO.FieldName = "HESAP_NO";
            this.HESAP_NO.Name = "HESAP_NO";
            this.HESAP_NO.Visible = true;
            this.HESAP_NO.VisibleIndex = 10;
            // 
            // CEK_NO
            // 
            this.CEK_NO.Caption = "Çek No";
            this.CEK_NO.FieldName = "CEK_NO";
            this.CEK_NO.Name = "CEK_NO";
            this.CEK_NO.Visible = true;
            this.CEK_NO.VisibleIndex = 11;
            // 
            // SORULDUGU_TARIH
            // 
            this.SORULDUGU_TARIH.Caption = "Sorulduðu T.";
            this.SORULDUGU_TARIH.FieldName = "SORULDUGU_TARIH";
            this.SORULDUGU_TARIH.Name = "SORULDUGU_TARIH";
            this.SORULDUGU_TARIH.Visible = true;
            this.SORULDUGU_TARIH.VisibleIndex = 12;
            // 
            // SORULMA_SONUCU
            // 
            this.SORULMA_SONUCU.Caption = "Sorulma Sonucu";
            this.SORULMA_SONUCU.FieldName = "SORULMA_SONUCU";
            this.SORULMA_SONUCU.Name = "SORULMA_SONUCU";
            this.SORULMA_SONUCU.Visible = true;
            this.SORULMA_SONUCU.VisibleIndex = 13;
            // 
            // KARSILIK_TUTAR_DOVIZ_ID
            // 
            this.KARSILIK_TUTAR_DOVIZ_ID.Caption = "BRM";
            this.KARSILIK_TUTAR_DOVIZ_ID.FieldName = "KARSILIK_TUTAR_DOVIZ_ID";
            this.KARSILIK_TUTAR_DOVIZ_ID.Name = "KARSILIK_TUTAR_DOVIZ_ID";
            this.KARSILIK_TUTAR_DOVIZ_ID.Visible = true;
            this.KARSILIK_TUTAR_DOVIZ_ID.VisibleIndex = 14;
            // 
            // KARSILIK_TUTAR
            // 
            this.KARSILIK_TUTAR.Caption = "Karþýlýk Tutar";
            this.KARSILIK_TUTAR.FieldName = "KARSILIK_TUTAR";
            this.KARSILIK_TUTAR.Name = "KARSILIK_TUTAR";
            this.KARSILIK_TUTAR.Visible = true;
            this.KARSILIK_TUTAR.VisibleIndex = 15;
            // 
            // SORAN_ID
            // 
            this.SORAN_ID.Caption = "Soran";
            this.SORAN_ID.FieldName = "SORAN_ID";
            this.SORAN_ID.Name = "SORAN_ID";
            this.SORAN_ID.Visible = true;
            this.SORAN_ID.VisibleIndex = 16;
            // 
            // ARKASI_YAZILDI_MI
            // 
            this.ARKASI_YAZILDI_MI.Caption = "Arkasý Yazýldýmý";
            this.ARKASI_YAZILDI_MI.FieldName = "ARKASI_YAZILDI_MI";
            this.ARKASI_YAZILDI_MI.Name = "ARKASI_YAZILDI_MI";
            this.ARKASI_YAZILDI_MI.Visible = true;
            this.ARKASI_YAZILDI_MI.VisibleIndex = 17;
            // 
            // SERH_ACIKLAMASI
            // 
            this.SERH_ACIKLAMASI.Caption = "Þerh Açýklama";
            this.SERH_ACIKLAMASI.FieldName = "SERH_ACIKLAMASI";
            this.SERH_ACIKLAMASI.Name = "SERH_ACIKLAMASI";
            this.SERH_ACIKLAMASI.Visible = true;
            this.SERH_ACIKLAMASI.VisibleIndex = 18;
            // 
            // ILK_ALACAKLI_ID
            // 
            this.ILK_ALACAKLI_ID.Caption = "Ýlk Alacaklý";
            this.ILK_ALACAKLI_ID.FieldName = "ILK_ALACAKLI_ID";
            this.ILK_ALACAKLI_ID.Name = "ILK_ALACAKLI_ID";
            this.ILK_ALACAKLI_ID.Visible = true;
            this.ILK_ALACAKLI_ID.VisibleIndex = 19;
            // 
            // ILK_BORCLU_ID
            // 
            this.ILK_BORCLU_ID.Caption = "Ýlk Borçlu";
            this.ILK_BORCLU_ID.FieldName = "ILK_BORCLU_ID";
            this.ILK_BORCLU_ID.Name = "ILK_BORCLU_ID";
            this.ILK_BORCLU_ID.Visible = true;
            this.ILK_BORCLU_ID.VisibleIndex = 20;
            // 
            // SIKAYET_EDILDI_MI
            // 
            this.SIKAYET_EDILDI_MI.Caption = "Þikayet Edildi mi";
            this.SIKAYET_EDILDI_MI.FieldName = "SIKAYET_EDILDI_MI";
            this.SIKAYET_EDILDI_MI.Name = "SIKAYET_EDILDI_MI";
            this.SIKAYET_EDILDI_MI.Visible = true;
            this.SIKAYET_EDILDI_MI.VisibleIndex = 21;
            // 
            // KESIDE_YERI
            // 
            this.KESIDE_YERI.Caption = "Keside Yeri";
            this.KESIDE_YERI.FieldName = "KESIDE_YERI";
            this.KESIDE_YERI.Name = "KESIDE_YERI";
            this.KESIDE_YERI.Visible = true;
            this.KESIDE_YERI.VisibleIndex = 22;
            // 
            // ODEME_YERI
            // 
            this.ODEME_YERI.Caption = "Ödeme Yeri";
            this.ODEME_YERI.FieldName = "ODEME_YERI";
            this.ODEME_YERI.Name = "ODEME_YERI";
            this.ODEME_YERI.Visible = true;
            this.ODEME_YERI.VisibleIndex = 23;
            // 
            // ISLEMLER_BASLADIMI
            // 
            this.ISLEMLER_BASLADIMI.Caption = "Ýþlemler Baþladýmý";
            this.ISLEMLER_BASLADIMI.FieldName = "ISLEMLER_BASLADIMI";
            this.ISLEMLER_BASLADIMI.Name = "ISLEMLER_BASLADIMI";
            this.ISLEMLER_BASLADIMI.Visible = true;
            this.ISLEMLER_BASLADIMI.VisibleIndex = 24;
            // 
            // gridView7
            // 
            this.gridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TUR,
            this.SOZLESME_NO,
            this.SOZLESME_ADI,
            this.TIP_ID,
            this.ALT_TIP_ID,
            this.TASNIF_NO,
            this.OZEL_KOD1_ID,
            this.OZEL_KOD2_ID,
            this.OZEL_KOD3_ID,
            this.OZEL_KOD4_ID,
            this.TASLAK_TARIHI,
            this.IMZA_TARIHI,
            this.BASLANGIC_TARIHI,
            this.YENILENME_TARIHI,
            this.SON_ISLEM_TARIHI,
            this.BITIS_TARIHI,
            this.BITIRILME_TARIHI,
            this.SURE_GUN,
            this.SURE_AY,
            this.SURE_YIL,
            this.NOTER_TARIHI,
            this.NOTER_YEVMIYE_NO,
            this.ADLI_BIRIM_ADLIYE_ID,
            this.ADLI_BIRIM_GOREV_ID,
            this.ADLI_BIRIM_NO_ID,
            this.YEDI_EMIN_CARI_ID,
            this.BEDELI_DOVIZ_ID,
            this.BEDELI,
            this.TAHLIYE_TAAHHUT_TARIHI,
            this.TAHLIYE_ADRESI,
            this.KART_TIP_ID,
            this.KREDI_KART_NO,
            this.CVV1,
            this.CVV2,
            this.SON_KULLANIM_TARIHI,
            this.REHIN_CINS_ID,
            this.BORC_IKRARINI_HAVI_MI,
            this.HARC_ISTISNA_ID,
            this.HARC_ISTISNA_BELGE_TARIH,
            this.HARC_ISTISNA_BELGE_NO,
            this.REHIN_DERECE,
            this.REHIN_SIRA,
            this.SICIL_TIP_ID,
            this.SICIL_BOLGE_NO,
            this.SICIL_ILCE_ID,
            this.SICIL_IL_ID,
            this.SICIL_TARIHI,
            this.SICIL_YEVMIYE_NO,
            this.SICIL_TESCIL_NO,
            this.FEK_TARIHI3,
            this.REHIN_DURUM_ID,
            this.SOZLESME_DURUM_ID,
            this.DURUM_ACIKLAMA,
            this.ACIKLAMA,
            this.REHIN_CINS_ANA_TURU,
            this.ISLEMLER_BASLADIMI1,
            this.UCRETIN_ODENME_SEKLI_ID,
            this.HAKEM_YARGILAMASININ_YERI_ID,
            this.SURE_UYGULAMA_TIPI});
            this.gridView7.GridControl = this.gcAlacak;
            this.gridView7.Name = "gridView7";
            this.gridView7.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView7.OptionsView.ShowPreview = true;
            this.gridView7.PreviewFieldName = "ACIKLAMA";
            this.gridView7.ViewCaption = "Sözleþme";
            // 
            // TUR
            // 
            this.TUR.Caption = "Tür";
            this.TUR.FieldName = "TUR";
            this.TUR.Name = "TUR";
            this.TUR.Visible = true;
            this.TUR.VisibleIndex = 0;
            // 
            // SOZLESME_NO
            // 
            this.SOZLESME_NO.Caption = "Sözleþme No";
            this.SOZLESME_NO.FieldName = "SOZLESME_NO";
            this.SOZLESME_NO.Name = "SOZLESME_NO";
            this.SOZLESME_NO.Visible = true;
            this.SOZLESME_NO.VisibleIndex = 1;
            // 
            // SOZLESME_ADI
            // 
            this.SOZLESME_ADI.Caption = "Sözleþme Adý";
            this.SOZLESME_ADI.FieldName = "SOZLESME_ADI";
            this.SOZLESME_ADI.Name = "SOZLESME_ADI";
            this.SOZLESME_ADI.Visible = true;
            this.SOZLESME_ADI.VisibleIndex = 2;
            // 
            // TIP_ID
            // 
            this.TIP_ID.Caption = "Tip";
            this.TIP_ID.FieldName = "TIP_ID";
            this.TIP_ID.Name = "TIP_ID";
            this.TIP_ID.Visible = true;
            this.TIP_ID.VisibleIndex = 3;
            // 
            // ALT_TIP_ID
            // 
            this.ALT_TIP_ID.Caption = "Alt Tip";
            this.ALT_TIP_ID.FieldName = "ALT_TIP_ID";
            this.ALT_TIP_ID.Name = "ALT_TIP_ID";
            this.ALT_TIP_ID.Visible = true;
            this.ALT_TIP_ID.VisibleIndex = 4;
            // 
            // TASNIF_NO
            // 
            this.TASNIF_NO.Caption = "Tasnif No";
            this.TASNIF_NO.FieldName = "TASNIF_NO";
            this.TASNIF_NO.Name = "TASNIF_NO";
            this.TASNIF_NO.Visible = true;
            this.TASNIF_NO.VisibleIndex = 5;
            // 
            // OZEL_KOD1_ID
            // 
            this.OZEL_KOD1_ID.Caption = "Özel Kod 1";
            this.OZEL_KOD1_ID.FieldName = "OZEL_KOD1_ID";
            this.OZEL_KOD1_ID.Name = "OZEL_KOD1_ID";
            this.OZEL_KOD1_ID.Visible = true;
            this.OZEL_KOD1_ID.VisibleIndex = 6;
            // 
            // OZEL_KOD2_ID
            // 
            this.OZEL_KOD2_ID.Name = "OZEL_KOD2_ID";
            // 
            // OZEL_KOD3_ID
            // 
            this.OZEL_KOD3_ID.Caption = "Özel Kod 3";
            this.OZEL_KOD3_ID.FieldName = "OZEL_KOD3_ID";
            this.OZEL_KOD3_ID.Name = "OZEL_KOD3_ID";
            this.OZEL_KOD3_ID.Visible = true;
            this.OZEL_KOD3_ID.VisibleIndex = 7;
            // 
            // OZEL_KOD4_ID
            // 
            this.OZEL_KOD4_ID.Caption = "Özel Kod 4";
            this.OZEL_KOD4_ID.FieldName = "OZEL_KOD4_ID";
            this.OZEL_KOD4_ID.Name = "OZEL_KOD4_ID";
            this.OZEL_KOD4_ID.Visible = true;
            this.OZEL_KOD4_ID.VisibleIndex = 8;
            // 
            // TASLAK_TARIHI
            // 
            this.TASLAK_TARIHI.Caption = "Taslak T.";
            this.TASLAK_TARIHI.FieldName = "TASLAK_TARIHI";
            this.TASLAK_TARIHI.Name = "TASLAK_TARIHI";
            this.TASLAK_TARIHI.Visible = true;
            this.TASLAK_TARIHI.VisibleIndex = 9;
            // 
            // IMZA_TARIHI
            // 
            this.IMZA_TARIHI.Caption = "Ýmza T.";
            this.IMZA_TARIHI.FieldName = "IMZA_TARIHI";
            this.IMZA_TARIHI.Name = "IMZA_TARIHI";
            this.IMZA_TARIHI.Visible = true;
            this.IMZA_TARIHI.VisibleIndex = 10;
            // 
            // BASLANGIC_TARIHI
            // 
            this.BASLANGIC_TARIHI.Caption = "Baþlangýç T.";
            this.BASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            this.BASLANGIC_TARIHI.Name = "BASLANGIC_TARIHI";
            this.BASLANGIC_TARIHI.Visible = true;
            this.BASLANGIC_TARIHI.VisibleIndex = 11;
            // 
            // YENILENME_TARIHI
            // 
            this.YENILENME_TARIHI.Caption = "Yenileme T.";
            this.YENILENME_TARIHI.FieldName = "YENILENME_TARIHI";
            this.YENILENME_TARIHI.Name = "YENILENME_TARIHI";
            this.YENILENME_TARIHI.Visible = true;
            this.YENILENME_TARIHI.VisibleIndex = 12;
            // 
            // SON_ISLEM_TARIHI
            // 
            this.SON_ISLEM_TARIHI.Caption = "Son Ýþlem T.";
            this.SON_ISLEM_TARIHI.FieldName = "SON_ISLEM_TARIHI";
            this.SON_ISLEM_TARIHI.Name = "SON_ISLEM_TARIHI";
            this.SON_ISLEM_TARIHI.Visible = true;
            this.SON_ISLEM_TARIHI.VisibleIndex = 13;
            // 
            // BITIS_TARIHI
            // 
            this.BITIS_TARIHI.Caption = "Bitiþ T.";
            this.BITIS_TARIHI.FieldName = "BITIS_TARIHI";
            this.BITIS_TARIHI.Name = "BITIS_TARIHI";
            this.BITIS_TARIHI.Visible = true;
            this.BITIS_TARIHI.VisibleIndex = 14;
            // 
            // BITIRILME_TARIHI
            // 
            this.BITIRILME_TARIHI.Caption = "Bitirilme T.";
            this.BITIRILME_TARIHI.FieldName = "BITIRILME_TARIHI";
            this.BITIRILME_TARIHI.Name = "BITIRILME_TARIHI";
            this.BITIRILME_TARIHI.Visible = true;
            this.BITIRILME_TARIHI.VisibleIndex = 15;
            // 
            // SURE_GUN
            // 
            this.SURE_GUN.Caption = "Gün";
            this.SURE_GUN.FieldName = "SURE_GUN";
            this.SURE_GUN.Name = "SURE_GUN";
            this.SURE_GUN.Visible = true;
            this.SURE_GUN.VisibleIndex = 16;
            // 
            // SURE_AY
            // 
            this.SURE_AY.Caption = "Ay";
            this.SURE_AY.FieldName = "SURE_AY";
            this.SURE_AY.Name = "SURE_AY";
            this.SURE_AY.Visible = true;
            this.SURE_AY.VisibleIndex = 17;
            // 
            // SURE_YIL
            // 
            this.SURE_YIL.Caption = "Yýl";
            this.SURE_YIL.FieldName = "SURE_YIL";
            this.SURE_YIL.Name = "SURE_YIL";
            this.SURE_YIL.Visible = true;
            this.SURE_YIL.VisibleIndex = 18;
            // 
            // NOTER_TARIHI
            // 
            this.NOTER_TARIHI.Caption = "Noter T.";
            this.NOTER_TARIHI.FieldName = "NOTER_TARIHI";
            this.NOTER_TARIHI.Name = "NOTER_TARIHI";
            this.NOTER_TARIHI.Visible = true;
            this.NOTER_TARIHI.VisibleIndex = 19;
            // 
            // NOTER_YEVMIYE_NO
            // 
            this.NOTER_YEVMIYE_NO.Caption = "Yevmiye No";
            this.NOTER_YEVMIYE_NO.FieldName = "NOTER_YEVMIYE_NO";
            this.NOTER_YEVMIYE_NO.Name = "NOTER_YEVMIYE_NO";
            this.NOTER_YEVMIYE_NO.Visible = true;
            this.NOTER_YEVMIYE_NO.VisibleIndex = 20;
            // 
            // ADLI_BIRIM_ADLIYE_ID
            // 
            this.ADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
            this.ADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.ADLI_BIRIM_ADLIYE_ID.Name = "ADLI_BIRIM_ADLIYE_ID";
            this.ADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.ADLI_BIRIM_ADLIYE_ID.VisibleIndex = 21;
            // 
            // ADLI_BIRIM_GOREV_ID
            // 
            this.ADLI_BIRIM_GOREV_ID.Caption = "Görev";
            this.ADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.ADLI_BIRIM_GOREV_ID.Name = "ADLI_BIRIM_GOREV_ID";
            this.ADLI_BIRIM_GOREV_ID.Visible = true;
            this.ADLI_BIRIM_GOREV_ID.VisibleIndex = 22;
            // 
            // ADLI_BIRIM_NO_ID
            // 
            this.ADLI_BIRIM_NO_ID.Caption = "Birim No";
            this.ADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            this.ADLI_BIRIM_NO_ID.Name = "ADLI_BIRIM_NO_ID";
            this.ADLI_BIRIM_NO_ID.Visible = true;
            this.ADLI_BIRIM_NO_ID.VisibleIndex = 23;
            // 
            // YEDI_EMIN_CARI_ID
            // 
            this.YEDI_EMIN_CARI_ID.Caption = "Yeddi Emin";
            this.YEDI_EMIN_CARI_ID.FieldName = "YEDI_EMIN_CARI_ID";
            this.YEDI_EMIN_CARI_ID.Name = "YEDI_EMIN_CARI_ID";
            this.YEDI_EMIN_CARI_ID.Visible = true;
            this.YEDI_EMIN_CARI_ID.VisibleIndex = 24;
            // 
            // BEDELI_DOVIZ_ID
            // 
            this.BEDELI_DOVIZ_ID.Caption = "BRM";
            this.BEDELI_DOVIZ_ID.FieldName = "BEDELI_DOVIZ_ID";
            this.BEDELI_DOVIZ_ID.Name = "BEDELI_DOVIZ_ID";
            this.BEDELI_DOVIZ_ID.Visible = true;
            this.BEDELI_DOVIZ_ID.VisibleIndex = 25;
            // 
            // BEDELI
            // 
            this.BEDELI.Caption = "Bedeli";
            this.BEDELI.FieldName = "BEDELI";
            this.BEDELI.Name = "BEDELI";
            this.BEDELI.Visible = true;
            this.BEDELI.VisibleIndex = 26;
            // 
            // TAHLIYE_TAAHHUT_TARIHI
            // 
            this.TAHLIYE_TAAHHUT_TARIHI.Caption = "Taahhut T.";
            this.TAHLIYE_TAAHHUT_TARIHI.FieldName = "TAHLIYE_TAAHHUT_TARIHI";
            this.TAHLIYE_TAAHHUT_TARIHI.Name = "TAHLIYE_TAAHHUT_TARIHI";
            this.TAHLIYE_TAAHHUT_TARIHI.Visible = true;
            this.TAHLIYE_TAAHHUT_TARIHI.VisibleIndex = 27;
            // 
            // TAHLIYE_ADRESI
            // 
            this.TAHLIYE_ADRESI.Caption = "Tahliye Adresi";
            this.TAHLIYE_ADRESI.FieldName = "TAHLIYE_ADRESI";
            this.TAHLIYE_ADRESI.Name = "TAHLIYE_ADRESI";
            this.TAHLIYE_ADRESI.Visible = true;
            this.TAHLIYE_ADRESI.VisibleIndex = 28;
            // 
            // KART_TIP_ID
            // 
            this.KART_TIP_ID.Caption = "Kart Tipi";
            this.KART_TIP_ID.FieldName = "KART_TIP_ID";
            this.KART_TIP_ID.Name = "KART_TIP_ID";
            this.KART_TIP_ID.Visible = true;
            this.KART_TIP_ID.VisibleIndex = 29;
            // 
            // KREDI_KART_NO
            // 
            this.KREDI_KART_NO.Caption = "Kredi K. No";
            this.KREDI_KART_NO.FieldName = "KREDI_KART_NO";
            this.KREDI_KART_NO.Name = "KREDI_KART_NO";
            this.KREDI_KART_NO.Visible = true;
            this.KREDI_KART_NO.VisibleIndex = 30;
            // 
            // CVV1
            // 
            this.CVV1.Caption = "CVV1";
            this.CVV1.FieldName = "CVV1";
            this.CVV1.Name = "CVV1";
            this.CVV1.Visible = true;
            this.CVV1.VisibleIndex = 31;
            // 
            // CVV2
            // 
            this.CVV2.Caption = "CVV2";
            this.CVV2.FieldName = "CVV2";
            this.CVV2.Name = "CVV2";
            this.CVV2.Visible = true;
            this.CVV2.VisibleIndex = 32;
            // 
            // SON_KULLANIM_TARIHI
            // 
            this.SON_KULLANIM_TARIHI.Caption = "S.K.T";
            this.SON_KULLANIM_TARIHI.FieldName = "SON_KULLANIM_TARIHI";
            this.SON_KULLANIM_TARIHI.Name = "SON_KULLANIM_TARIHI";
            this.SON_KULLANIM_TARIHI.Visible = true;
            this.SON_KULLANIM_TARIHI.VisibleIndex = 33;
            // 
            // REHIN_CINS_ID
            // 
            this.REHIN_CINS_ID.Caption = "Rehin Cins";
            this.REHIN_CINS_ID.FieldName = "REHIN_CINS_ID";
            this.REHIN_CINS_ID.Name = "REHIN_CINS_ID";
            this.REHIN_CINS_ID.Visible = true;
            this.REHIN_CINS_ID.VisibleIndex = 34;
            // 
            // BORC_IKRARINI_HAVI_MI
            // 
            this.BORC_IKRARINI_HAVI_MI.Caption = "Borç Ikrarý Havimi";
            this.BORC_IKRARINI_HAVI_MI.FieldName = "BORC_IKRARINI_HAVI_MI";
            this.BORC_IKRARINI_HAVI_MI.Name = "BORC_IKRARINI_HAVI_MI";
            this.BORC_IKRARINI_HAVI_MI.Visible = true;
            this.BORC_IKRARINI_HAVI_MI.VisibleIndex = 35;
            // 
            // HARC_ISTISNA_ID
            // 
            this.HARC_ISTISNA_ID.Caption = "Harc Istisna";
            this.HARC_ISTISNA_ID.FieldName = "HARC_ISTISNA_ID";
            this.HARC_ISTISNA_ID.Name = "HARC_ISTISNA_ID";
            this.HARC_ISTISNA_ID.Visible = true;
            this.HARC_ISTISNA_ID.VisibleIndex = 36;
            // 
            // HARC_ISTISNA_BELGE_TARIH
            // 
            this.HARC_ISTISNA_BELGE_TARIH.Caption = "Belge T.";
            this.HARC_ISTISNA_BELGE_TARIH.FieldName = "HARC_ISTISNA_BELGE_TARIH";
            this.HARC_ISTISNA_BELGE_TARIH.Name = "HARC_ISTISNA_BELGE_TARIH";
            this.HARC_ISTISNA_BELGE_TARIH.Visible = true;
            this.HARC_ISTISNA_BELGE_TARIH.VisibleIndex = 37;
            // 
            // HARC_ISTISNA_BELGE_NO
            // 
            this.HARC_ISTISNA_BELGE_NO.Caption = "Belge No";
            this.HARC_ISTISNA_BELGE_NO.FieldName = "HARC_ISTISNA_BELGE_NO";
            this.HARC_ISTISNA_BELGE_NO.Name = "HARC_ISTISNA_BELGE_NO";
            this.HARC_ISTISNA_BELGE_NO.Visible = true;
            this.HARC_ISTISNA_BELGE_NO.VisibleIndex = 38;
            // 
            // REHIN_DERECE
            // 
            this.REHIN_DERECE.Caption = "Rehin Derece";
            this.REHIN_DERECE.FieldName = "REHIN_DERECE";
            this.REHIN_DERECE.Name = "REHIN_DERECE";
            this.REHIN_DERECE.Visible = true;
            this.REHIN_DERECE.VisibleIndex = 39;
            // 
            // REHIN_SIRA
            // 
            this.REHIN_SIRA.Caption = "Rehin Sýra";
            this.REHIN_SIRA.FieldName = "REHIN_SIRA";
            this.REHIN_SIRA.Name = "REHIN_SIRA";
            this.REHIN_SIRA.Visible = true;
            this.REHIN_SIRA.VisibleIndex = 40;
            // 
            // SICIL_TIP_ID
            // 
            this.SICIL_TIP_ID.Caption = "Sicil Tip";
            this.SICIL_TIP_ID.FieldName = "SICIL_TIP_ID";
            this.SICIL_TIP_ID.Name = "SICIL_TIP_ID";
            this.SICIL_TIP_ID.Visible = true;
            this.SICIL_TIP_ID.VisibleIndex = 41;
            // 
            // SICIL_BOLGE_NO
            // 
            this.SICIL_BOLGE_NO.Caption = "Sicil Bölge No";
            this.SICIL_BOLGE_NO.FieldName = "SICIL_BOLGE_NO";
            this.SICIL_BOLGE_NO.Name = "SICIL_BOLGE_NO";
            this.SICIL_BOLGE_NO.Visible = true;
            this.SICIL_BOLGE_NO.VisibleIndex = 42;
            // 
            // SICIL_ILCE_ID
            // 
            this.SICIL_ILCE_ID.Caption = "Ilçe";
            this.SICIL_ILCE_ID.FieldName = "SICIL_ILCE_ID";
            this.SICIL_ILCE_ID.Name = "SICIL_ILCE_ID";
            this.SICIL_ILCE_ID.Visible = true;
            this.SICIL_ILCE_ID.VisibleIndex = 43;
            // 
            // SICIL_IL_ID
            // 
            this.SICIL_IL_ID.Caption = "Il";
            this.SICIL_IL_ID.FieldName = "SICIL_IL_ID";
            this.SICIL_IL_ID.Name = "SICIL_IL_ID";
            this.SICIL_IL_ID.Visible = true;
            this.SICIL_IL_ID.VisibleIndex = 44;
            // 
            // SICIL_TARIHI
            // 
            this.SICIL_TARIHI.Caption = "Sicil T.";
            this.SICIL_TARIHI.FieldName = "SICIL_TARIHI";
            this.SICIL_TARIHI.Name = "SICIL_TARIHI";
            this.SICIL_TARIHI.Visible = true;
            this.SICIL_TARIHI.VisibleIndex = 45;
            // 
            // SICIL_YEVMIYE_NO
            // 
            this.SICIL_YEVMIYE_NO.Caption = "Yevmiye No";
            this.SICIL_YEVMIYE_NO.FieldName = "SICIL_YEVMIYE_NO";
            this.SICIL_YEVMIYE_NO.Name = "SICIL_YEVMIYE_NO";
            this.SICIL_YEVMIYE_NO.Visible = true;
            this.SICIL_YEVMIYE_NO.VisibleIndex = 46;
            // 
            // SICIL_TESCIL_NO
            // 
            this.SICIL_TESCIL_NO.Caption = "Tescil No";
            this.SICIL_TESCIL_NO.FieldName = "SICIL_TESCIL_NO";
            this.SICIL_TESCIL_NO.Name = "SICIL_TESCIL_NO";
            this.SICIL_TESCIL_NO.Visible = true;
            this.SICIL_TESCIL_NO.VisibleIndex = 47;
            // 
            // FEK_TARIHI3
            // 
            this.FEK_TARIHI3.Caption = "Fek T.";
            this.FEK_TARIHI3.FieldName = "FEK_TARIHI";
            this.FEK_TARIHI3.Name = "FEK_TARIHI3";
            this.FEK_TARIHI3.Visible = true;
            this.FEK_TARIHI3.VisibleIndex = 48;
            // 
            // REHIN_DURUM_ID
            // 
            this.REHIN_DURUM_ID.Caption = "Rehin Durum";
            this.REHIN_DURUM_ID.FieldName = "REHIN_DURUM_ID";
            this.REHIN_DURUM_ID.Name = "REHIN_DURUM_ID";
            this.REHIN_DURUM_ID.Visible = true;
            this.REHIN_DURUM_ID.VisibleIndex = 49;
            // 
            // SOZLESME_DURUM_ID
            // 
            this.SOZLESME_DURUM_ID.Caption = "Söz. Durum";
            this.SOZLESME_DURUM_ID.FieldName = "SOZLESME_DURUM_ID";
            this.SOZLESME_DURUM_ID.Name = "SOZLESME_DURUM_ID";
            this.SOZLESME_DURUM_ID.Visible = true;
            this.SOZLESME_DURUM_ID.VisibleIndex = 50;
            // 
            // DURUM_ACIKLAMA
            // 
            this.DURUM_ACIKLAMA.Caption = "Durum Açýklama";
            this.DURUM_ACIKLAMA.FieldName = "DURUM_ACIKLAMA";
            this.DURUM_ACIKLAMA.Name = "DURUM_ACIKLAMA";
            this.DURUM_ACIKLAMA.Visible = true;
            this.DURUM_ACIKLAMA.VisibleIndex = 51;
            // 
            // ACIKLAMA
            // 
            this.ACIKLAMA.Caption = "Açýklama";
            this.ACIKLAMA.FieldName = "ACIKLAMA";
            this.ACIKLAMA.Name = "ACIKLAMA";
            this.ACIKLAMA.Visible = true;
            this.ACIKLAMA.VisibleIndex = 52;
            // 
            // REHIN_CINS_ANA_TURU
            // 
            this.REHIN_CINS_ANA_TURU.Caption = "Rehin Cins Ana Tür";
            this.REHIN_CINS_ANA_TURU.FieldName = "REHIN_CINS_ANA_TURU";
            this.REHIN_CINS_ANA_TURU.Name = "REHIN_CINS_ANA_TURU";
            this.REHIN_CINS_ANA_TURU.Visible = true;
            this.REHIN_CINS_ANA_TURU.VisibleIndex = 53;
            // 
            // ISLEMLER_BASLADIMI1
            // 
            this.ISLEMLER_BASLADIMI1.Caption = "Ýþlemler Baþladýmý";
            this.ISLEMLER_BASLADIMI1.FieldName = "ISLEMLER_BASLADIMI";
            this.ISLEMLER_BASLADIMI1.Name = "ISLEMLER_BASLADIMI1";
            this.ISLEMLER_BASLADIMI1.Visible = true;
            this.ISLEMLER_BASLADIMI1.VisibleIndex = 54;
            // 
            // UCRETIN_ODENME_SEKLI_ID
            // 
            this.UCRETIN_ODENME_SEKLI_ID.Caption = "Ü. Ödenme Þekli";
            this.UCRETIN_ODENME_SEKLI_ID.FieldName = "UCRETIN_ODENME_SEKLI_ID";
            this.UCRETIN_ODENME_SEKLI_ID.Name = "UCRETIN_ODENME_SEKLI_ID";
            this.UCRETIN_ODENME_SEKLI_ID.Visible = true;
            this.UCRETIN_ODENME_SEKLI_ID.VisibleIndex = 55;
            // 
            // HAKEM_YARGILAMASININ_YERI_ID
            // 
            this.HAKEM_YARGILAMASININ_YERI_ID.Caption = "Yarg. Yeri";
            this.HAKEM_YARGILAMASININ_YERI_ID.FieldName = "HAKEM_YARGILAMASININ_YERI_ID";
            this.HAKEM_YARGILAMASININ_YERI_ID.Name = "HAKEM_YARGILAMASININ_YERI_ID";
            this.HAKEM_YARGILAMASININ_YERI_ID.Visible = true;
            this.HAKEM_YARGILAMASININ_YERI_ID.VisibleIndex = 56;
            // 
            // SURE_UYGULAMA_TIPI
            // 
            this.SURE_UYGULAMA_TIPI.Caption = "Süre Uygulama Yeri";
            this.SURE_UYGULAMA_TIPI.FieldName = "SURE_UYGULAMA_TIPI";
            this.SURE_UYGULAMA_TIPI.Name = "SURE_UYGULAMA_TIPI";
            this.SURE_UYGULAMA_TIPI.Visible = true;
            this.SURE_UYGULAMA_TIPI.VisibleIndex = 57;
            // 
            // gridView11
            // 
            this.gridView11.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TARAF_CARI_ID,
            this.IHTAR_TEBLIG_TARIHI,
            this.TEMERRUT_TARIHI,
            this.ZAMAN_ASIMI_TARIHI,
            this.IHTAR_TARIHI,
            this.gridColumn141,
            this.gridColumn143,
            this.gridColumn144,
            this.gridColumn151,
            this.gridColumn159,
            this.gridColumn164});
            this.gridView11.GridControl = this.gcAlacak;
            this.gridView11.Name = "gridView11";
            this.gridView11.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView11.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView11.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView11.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView11.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView11.OptionsView.ColumnAutoWidth = false;
            this.gridView11.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView11.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView11.OptionsView.ShowAutoFilterRow = true;
            this.gridView11.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView11.PaintStyleName = "Skin";
            this.gridView11.ViewCaption = "Alacak Neden Taraf";
            // 
            // TARAF_CARI_ID
            // 
            this.TARAF_CARI_ID.Caption = "Taraf";
            this.TARAF_CARI_ID.FieldName = "TARAF_CARI_ID";
            this.TARAF_CARI_ID.Name = "TARAF_CARI_ID";
            this.TARAF_CARI_ID.Visible = true;
            this.TARAF_CARI_ID.VisibleIndex = 0;
            // 
            // IHTAR_TEBLIG_TARIHI
            // 
            this.IHTAR_TEBLIG_TARIHI.Caption = "Teblið T.";
            this.IHTAR_TEBLIG_TARIHI.FieldName = "IHTAR_TEBLIG_TARIHI";
            this.IHTAR_TEBLIG_TARIHI.Name = "IHTAR_TEBLIG_TARIHI";
            this.IHTAR_TEBLIG_TARIHI.Visible = true;
            this.IHTAR_TEBLIG_TARIHI.VisibleIndex = 1;
            // 
            // TEMERRUT_TARIHI
            // 
            this.TEMERRUT_TARIHI.Caption = "Temerrüt T.";
            this.TEMERRUT_TARIHI.FieldName = "TEMERRUT_TARIHI";
            this.TEMERRUT_TARIHI.Name = "TEMERRUT_TARIHI";
            this.TEMERRUT_TARIHI.Visible = true;
            this.TEMERRUT_TARIHI.VisibleIndex = 2;
            // 
            // ZAMAN_ASIMI_TARIHI
            // 
            this.ZAMAN_ASIMI_TARIHI.Caption = "Zaman Aþýmý";
            this.ZAMAN_ASIMI_TARIHI.FieldName = "ZAMAN_ASIMI_TARIHI";
            this.ZAMAN_ASIMI_TARIHI.Name = "ZAMAN_ASIMI_TARIHI";
            this.ZAMAN_ASIMI_TARIHI.Visible = true;
            this.ZAMAN_ASIMI_TARIHI.VisibleIndex = 3;
            // 
            // IHTAR_TARIHI
            // 
            this.IHTAR_TARIHI.Caption = "Ihtar T.";
            this.IHTAR_TARIHI.FieldName = "IHTAR_TARIHI";
            this.IHTAR_TARIHI.Name = "IHTAR_TARIHI";
            this.IHTAR_TARIHI.Visible = true;
            this.IHTAR_TARIHI.VisibleIndex = 4;
            // 
            // gridColumn141
            // 
            this.gridColumn141.Caption = "Sorumluluk Miktarý";
            this.gridColumn141.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn141.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn141.FieldName = "SORUMLU_OLUNAN_MIKTAR";
            this.gridColumn141.Name = "gridColumn141";
            this.gridColumn141.Visible = true;
            this.gridColumn141.VisibleIndex = 5;
            // 
            // gridColumn143
            // 
            this.gridColumn143.Caption = "BRM";
            this.gridColumn143.FieldName = "SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID";
            this.gridColumn143.Name = "gridColumn143";
            this.gridColumn143.Visible = true;
            this.gridColumn143.VisibleIndex = 6;
            // 
            // gridColumn144
            // 
            this.gridColumn144.Caption = "Protesto Gideri";
            this.gridColumn144.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn144.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn144.FieldName = "PROTESTO_GIDERI";
            this.gridColumn144.Name = "gridColumn144";
            this.gridColumn144.Visible = true;
            this.gridColumn144.VisibleIndex = 7;
            // 
            // gridColumn151
            // 
            this.gridColumn151.Caption = "BRM";
            this.gridColumn151.FieldName = "PROTESTO_GIDERI_DOVIZ_ID";
            this.gridColumn151.Name = "gridColumn151";
            this.gridColumn151.Visible = true;
            this.gridColumn151.VisibleIndex = 8;
            // 
            // gridColumn159
            // 
            this.gridColumn159.Caption = "Ýhtar Gideri";
            this.gridColumn159.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn159.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn159.FieldName = "IHTAR_GIDERI";
            this.gridColumn159.Name = "gridColumn159";
            this.gridColumn159.Visible = true;
            this.gridColumn159.VisibleIndex = 9;
            // 
            // gridColumn164
            // 
            this.gridColumn164.Caption = "BRM";
            this.gridColumn164.FieldName = "IHTAR_GIDERI_DOVIZ_ID";
            this.gridColumn164.Name = "gridColumn164";
            this.gridColumn164.Visible = true;
            this.gridColumn164.VisibleIndex = 10;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.BackColor = System.Drawing.Color.Red;
            this.simpleButton2.Appearance.BackColor2 = System.Drawing.Color.Red;
            this.simpleButton2.Appearance.BorderColor = System.Drawing.Color.Red;
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButton2.Appearance.Options.UseBackColor = true;
            this.simpleButton2.Appearance.Options.UseBorderColor = true;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.simpleButton2.Location = new System.Drawing.Point(2, 315);
            this.simpleButton2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.simpleButton2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(735, 22);
            this.simpleButton2.TabIndex = 6;
            this.simpleButton2.Text = "Seçili Alacak Nedenlerine Ýhtarnameyi Baðla";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // tbPPoliçe
            // 
            this.tbPPoliçe.Controls.Add(this.xtraTabControl3);
            this.tbPPoliçe.Image = ((System.Drawing.Image)(resources.GetObject("tbPPoliçe.Image")));
            this.tbPPoliçe.Name = "tbPPoliçe";
            this.tbPPoliçe.PageVisible = false;
            this.tbPPoliçe.Size = new System.Drawing.Size(739, 627);
            this.tbPPoliçe.Text = "Poliçe ve Hasar";
            // 
            // xtraTabControl3
            // 
            this.xtraTabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl3.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl3.Name = "xtraTabControl3";
            this.xtraTabControl3.SelectedTabPage = this.tabpPolice;
            this.xtraTabControl3.Size = new System.Drawing.Size(739, 627);
            this.xtraTabControl3.TabIndex = 0;
            this.xtraTabControl3.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabpPolice,
            this.tabPHasar});
            // 
            // tabpPolice
            // 
            this.tabpPolice.Name = "tabpPolice";
            this.tabpPolice.Size = new System.Drawing.Size(733, 599);
            this.tabpPolice.Text = "Poliçe";
            // 
            // tabPHasar
            // 
            this.tabPHasar.Name = "tabPHasar";
            this.tabPHasar.PageVisible = false;
            this.tabPHasar.Size = new System.Drawing.Size(733, 599);
            this.tabPHasar.Text = "Hasar";
            // 
            // tabPDosyaHesabiveYazdirma
            // 
            this.tabPDosyaHesabiveYazdirma.Image = ((System.Drawing.Image)(resources.GetObject("tabPDosyaHesabiveYazdirma.Image")));
            this.tabPDosyaHesabiveYazdirma.Name = "tabPDosyaHesabiveYazdirma";
            this.tabPDosyaHesabiveYazdirma.PageVisible = false;
            this.tabPDosyaHesabiveYazdirma.Size = new System.Drawing.Size(739, 627);
            this.tabPDosyaHesabiveYazdirma.Text = "Dosya Hesabý ve Yazdýrma";
            // 
            // pnIslemler
            // 
            this.pnIslemler.Location = new System.Drawing.Point(3, 628);
            this.pnIslemler.Name = "pnIslemler";
            this.pnIslemler.Size = new System.Drawing.Size(952, 40);
            this.pnIslemler.TabIndex = 11;
            this.pnIslemler.TabStop = false;
            this.pnIslemler.Text = "Ýþlemler";
            // 
            // multiEditorRow39
            // 
            this.multiEditorRow39.Name = "multiEditorRow39";
            this.multiEditorRow39.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties17,
            this.multiEditorRowProperties18,
            this.multiEditorRowProperties19});
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            // 
            // bar3
            // 
            this.bar3.BarName = "Main menu";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            // 
            // aV001TIBILFOYTARAFVEKILBindingSource
            // 
            this.aV001TIBILFOYTARAFVEKILBindingSource.DataSource = typeof(AvukatProLib2.Entities.AV001_TI_BIL_FOY_TARAF_VEKIL);
            // 
            // barLinkContainerItem1
            // 
            this.barLinkContainerItem1.Id = -1;
            this.barLinkContainerItem1.Name = "barLinkContainerItem1";
            // 
            // glkIcraFoy
            // 
            this.glkIcraFoy.AutoHeight = false;
            this.glkIcraFoy.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glkIcraFoy.DisplayMember = "FOY_NO";
            this.glkIcraFoy.Name = "glkIcraFoy";
            this.glkIcraFoy.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkAdliBirimAdliye});
            this.glkIcraFoy.View = this.gvBagliKayit;
            // 
            // rlkAdliBirimAdliye
            // 
            this.rlkAdliBirimAdliye.AutoHeight = false;
            this.rlkAdliBirimAdliye.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkAdliBirimAdliye.Name = "rlkAdliBirimAdliye";
            // 
            // gvBagliKayit
            // 
            this.gvBagliKayit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clmFOY_NO,
            this.clmESAS_NO,
            this.clmTAKIP_TARIHI,
            this.clmADLI_BIRIM_ADLIYE,
            this.clmADLI_BIRIM_NO});
            this.gvBagliKayit.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvBagliKayit.Name = "gvBagliKayit";
            this.gvBagliKayit.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvBagliKayit.OptionsView.ShowGroupPanel = false;
            // 
            // clmFOY_NO
            // 
            this.clmFOY_NO.Caption = "Dosya No";
            this.clmFOY_NO.FieldName = "FOY_NO";
            this.clmFOY_NO.Name = "clmFOY_NO";
            this.clmFOY_NO.Visible = true;
            this.clmFOY_NO.VisibleIndex = 0;
            // 
            // clmESAS_NO
            // 
            this.clmESAS_NO.Caption = "Esas No";
            this.clmESAS_NO.FieldName = "ESAS_NO";
            this.clmESAS_NO.Name = "clmESAS_NO";
            this.clmESAS_NO.Visible = true;
            this.clmESAS_NO.VisibleIndex = 4;
            // 
            // clmTAKIP_TARIHI
            // 
            this.clmTAKIP_TARIHI.Caption = "Takip Tarihi";
            this.clmTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            this.clmTAKIP_TARIHI.Name = "clmTAKIP_TARIHI";
            this.clmTAKIP_TARIHI.Visible = true;
            this.clmTAKIP_TARIHI.VisibleIndex = 1;
            // 
            // clmADLI_BIRIM_ADLIYE
            // 
            this.clmADLI_BIRIM_ADLIYE.Caption = "Müdürlük";
            this.clmADLI_BIRIM_ADLIYE.ColumnEdit = this.rlkAdliBirimAdliye;
            this.clmADLI_BIRIM_ADLIYE.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.clmADLI_BIRIM_ADLIYE.Name = "clmADLI_BIRIM_ADLIYE";
            this.clmADLI_BIRIM_ADLIYE.Visible = true;
            this.clmADLI_BIRIM_ADLIYE.VisibleIndex = 2;
            // 
            // clmADLI_BIRIM_NO
            // 
            this.clmADLI_BIRIM_NO.Caption = "No";
            this.clmADLI_BIRIM_NO.FieldName = "BIRIM_NO";
            this.clmADLI_BIRIM_NO.Name = "clmADLI_BIRIM_NO";
            this.clmADLI_BIRIM_NO.Visible = true;
            this.clmADLI_BIRIM_NO.VisibleIndex = 3;
            // 
            // beDurum
            // 
            this.beDurum.Caption = "Dosya kaydediliyor...";
            this.beDurum.Edit = this.rprgKayitEdiliyor;
            this.beDurum.Id = 40;
            this.beDurum.Name = "beDurum";
            this.beDurum.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.beDurum.Width = 100;
            // 
            // rprgKayitEdiliyor
            // 
            this.rprgKayitEdiliyor.Name = "rprgKayitEdiliyor";
            // 
            // repositoryItemPopupContainerEdit1
            // 
            this.repositoryItemPopupContainerEdit1.AutoHeight = false;
            this.repositoryItemPopupContainerEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit1.Name = "repositoryItemPopupContainerEdit1";
            // 
            // repositoryItemGridLookUpEdit2
            // 
            this.repositoryItemGridLookUpEdit2.AutoHeight = false;
            this.repositoryItemGridLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit2.Name = "repositoryItemGridLookUpEdit2";
            this.repositoryItemGridLookUpEdit2.View = this.repositoryItemGridLookUpEdit2View;
            // 
            // repositoryItemGridLookUpEdit2View
            // 
            this.repositoryItemGridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit2View.Name = "repositoryItemGridLookUpEdit2View";
            this.repositoryItemGridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            // 
            // bwFoyuKaydet
            // 
            this.bwFoyuKaydet.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwFoyuKaydet_DoWork);
            this.bwFoyuKaydet.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwFoyuKaydet_RunWorkerCompleted);
            // 
            // frmIcraDosyaKayit
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 749);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormunBolumu = AdimAdimDavaKaydi.Util.BaseClasses.FormBolumu.Icra;
            this.FormunTipi = AdimAdimDavaKaydi.Util.BaseClasses.FormTipi.KayitFormu;
            this.Name = "frmIcraDosyaKayit";
            this.Text = "Avukatpro Hukuk Ailesi Ýcra Kayýt Formu";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmIcraDosyaKayit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvTakipEdilenVekil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTakipEdenTemsilBagla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkCariAvukat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTemsilSekil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTakipEdilen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TIBILFOYTARAFBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsrcMyFoy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rglkSorumluAvs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTakipEdenTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTakipEdilenTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTakipEdenSifat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTakipEdilenSifat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTemsilBagla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkBorclu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTakipEdilen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTakipEdenTarafVekil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTakipEden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTakipEden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkFormTipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTakipTarihi.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTakipTarihi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkFoyDurum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkMudurluk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueMudurlukNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEsasNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtReferans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkOzelKod1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkOzelKod2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkOzelKod3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkOzelKod4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtDosyaNoKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtDosyaNoSayi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabGiris)).EndInit();
            this.tabGiris.ResumeLayout(false);
            this.tpTakipGenelBilgileri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpOnSayfaANeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcKevrak)).EndInit();
            this.tcKevrak.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bottomPanel)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTaraflar)).EndInit();
            this.panelControlTaraflar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnSorumluAvukat)).EndInit();
            this.pnSorumluAvukat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSorumluAvukat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSorumluAvukat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnTakipEdilen)).EndInit();
            this.pnTakipEdilen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnTakipEden)).EndInit();
            this.pnTakipEden.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.tabpGenel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTakipKonu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueVekaletSozlesme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSegmentId)).EndInit();
            this.tpGelismeBilgileri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlGelismeANeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.tpSozTeminat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spSozlesme)).EndInit();
            this.spSozlesme.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSozlesmeBilgileri)).EndInit();
            this.tabPageIhtarname.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakNeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHesaplamaModu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueFaizTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKdvTipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwAlacak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).EndInit();
            this.tbPPoliçe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl3)).EndInit();
            this.xtraTabControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TIBILFOYTARAFVEKILBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glkIcraFoy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkAdliBirimAdliye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBagliKayit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rprgKayitEdiliyor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion Methods

        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties1;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties2;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties3;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties4;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties5;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties6;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties7;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties8;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties9;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties10;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties11;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties12;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties13;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties14;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties15;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties16;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties17;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties18;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties19;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties20;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties21;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties22;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties23;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties24;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties25;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties26;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties27;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties28;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties29;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties30;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties31;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties32;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties33;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties34;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties35;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMudurlukIBANNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}