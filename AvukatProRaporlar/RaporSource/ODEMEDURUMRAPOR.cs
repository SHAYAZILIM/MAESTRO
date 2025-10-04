using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class ODEMEDURUMRAPOR
    {
        #region Settings

        public bool EnableChart
        {
            get { return false; }
        }

        public bool EnableGrid
        {
            get { return false; }
        }

        public bool EnablePivot
        {
            get { return false; }
        }

        public bool EnablePrintChart
        {
            get { return false; }
        }

        public bool EnablePrintList
        {
            get { return false; }
        }

        public bool EnablePrintPivot
        {
            get { return false; }
        }

        public bool EnableSaveChart
        {
            get { return false; }
        }

        public bool EnableSaveList
        {
            get { return false; }
        }

        public bool EnableSavePivot
        {
            get { return false; }
        }

        public string MenuName
        {
            get { return "Menu Name"; }
        }

        public string Title
        {
            get { return "Title"; }
        }

        #endregion Settings

        private GridColumn[] dizi = null;

        public GridColumn[] GetGridColumns(string pencere)
        {
            #region Field & Properties

            GridColumn colAN_REF_NO1 = new GridColumn();
            colAN_REF_NO1.VisibleIndex = 0;
            colAN_REF_NO1.FieldName = "AN_REF_NO1";
            colAN_REF_NO1.Name = "colAN_REF_NO1";
            colAN_REF_NO1.Visible = true;

            GridColumn colAN_REF_NO2 = new GridColumn();
            colAN_REF_NO2.VisibleIndex = 1;
            colAN_REF_NO2.FieldName = "AN_REF_NO2";
            colAN_REF_NO2.Name = "colAN_REF_NO2";
            colAN_REF_NO2.Visible = true;

            GridColumn colAN_REF_NO3 = new GridColumn();
            colAN_REF_NO3.VisibleIndex = 2;
            colAN_REF_NO3.FieldName = "AN_REF_NO3";
            colAN_REF_NO3.Name = "colAN_REF_NO3";
            colAN_REF_NO3.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 3;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colICRA_REF_NO1 = new GridColumn();
            colICRA_REF_NO1.VisibleIndex = 4;
            colICRA_REF_NO1.FieldName = "ICRA_REF_NO1";
            colICRA_REF_NO1.Name = "colICRA_REF_NO1";
            colICRA_REF_NO1.Visible = true;

            GridColumn colICRA_REF_NO2 = new GridColumn();
            colICRA_REF_NO2.VisibleIndex = 5;
            colICRA_REF_NO2.FieldName = "ICRA_REF_NO2";
            colICRA_REF_NO2.Name = "colICRA_REF_NO2";
            colICRA_REF_NO2.Visible = true;

            GridColumn colICRA_REF_NO3 = new GridColumn();
            colICRA_REF_NO3.VisibleIndex = 6;
            colICRA_REF_NO3.FieldName = "ICRA_REF_NO3";
            colICRA_REF_NO3.Name = "colICRA_REF_NO3";
            colICRA_REF_NO3.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 7;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 8;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colTAKIBIN_AVUKATA_INTIKAL_TARIHI = new GridColumn();
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 9;
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "colTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colASIL_ALACAK = new GridColumn();
            colASIL_ALACAK.VisibleIndex = 10;
            colASIL_ALACAK.FieldName = "ASIL_ALACAK";
            colASIL_ALACAK.Name = "colASIL_ALACAK";
            colASIL_ALACAK.Visible = true;

            GridColumn colASIL_ALACAK_DOVIZ_ID = new GridColumn();
            colASIL_ALACAK_DOVIZ_ID.VisibleIndex = 11;
            colASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Name = "colASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Visible = true;

            GridColumn colISLEMIS_FAIZ = new GridColumn();
            colISLEMIS_FAIZ.VisibleIndex = 12;
            colISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Name = "colISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Visible = true;

            GridColumn colISLEMIS_FAIZ_DOVIZ_ID = new GridColumn();
            colISLEMIS_FAIZ_DOVIZ_ID.VisibleIndex = 13;
            colISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Name = "colISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colSON_HESAP_TARIHI = new GridColumn();
            colSON_HESAP_TARIHI.VisibleIndex = 14;
            colSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Name = "colSON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Visible = true;

            GridColumn colTAKIP_CIKISI = new GridColumn();
            colTAKIP_CIKISI.VisibleIndex = 15;
            colTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            colTAKIP_CIKISI.Name = "colTAKIP_CIKISI";
            colTAKIP_CIKISI.Visible = true;

            GridColumn colTAKIP_CIKISI_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKISI_DOVIZ_ID.VisibleIndex = 16;
            colTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Name = "colTAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_TOPLAMI = new GridColumn();
            colODEME_TOPLAMI.VisibleIndex = 17;
            colODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            colODEME_TOPLAMI.Name = "colODEME_TOPLAMI";
            colODEME_TOPLAMI.Visible = true;

            GridColumn colODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 18;
            colODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Name = "colODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN = new GridColumn();
            colKALAN.VisibleIndex = 19;
            colKALAN.FieldName = "KALAN";
            colKALAN.Name = "colKALAN";
            colKALAN.Visible = true;

            GridColumn colKALAN_DOVIZ_ID = new GridColumn();
            colKALAN_DOVIZ_ID.VisibleIndex = 20;
            colKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Name = "colKALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Visible = true;

            GridColumn colKAPAMA_TARIHI = new GridColumn();
            colKAPAMA_TARIHI.VisibleIndex = 21;
            colKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            colKAPAMA_TARIHI.Name = "colKAPAMA_TARIHI";
            colKAPAMA_TARIHI.Visible = true;

            GridColumn colRISK_MIKTARI = new GridColumn();
            colRISK_MIKTARI.VisibleIndex = 22;
            colRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            colRISK_MIKTARI.Name = "colRISK_MIKTARI";
            colRISK_MIKTARI.Visible = true;

            GridColumn colRISK_MIKTARI_DOVIZ_ID = new GridColumn();
            colRISK_MIKTARI_DOVIZ_ID.VisibleIndex = 23;
            colRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Name = "colRISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 24;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 25;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 26;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 27;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 28;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 29;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 30;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 31;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.Visible = true;

            GridColumn colHESAPLAMA_TIPI = new GridColumn();
            colHESAPLAMA_TIPI.VisibleIndex = 32;
            colHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Name = "colHESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Visible = true;

            GridColumn colBIR_YIL_KAC_GUN = new GridColumn();
            colBIR_YIL_KAC_GUN.VisibleIndex = 33;
            colBIR_YIL_KAC_GUN.FieldName = "BIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Name = "colBIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI = new GridColumn();
            colTAKIP_VEKALET_UCRETI.VisibleIndex = 34;
            colTAKIP_VEKALET_UCRETI.FieldName = "TAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Name = "colTAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 35;
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Name = "colTAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colMAHSUP_TOPLAMI = new GridColumn();
            colMAHSUP_TOPLAMI.VisibleIndex = 36;
            colMAHSUP_TOPLAMI.FieldName = "MAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Name = "colMAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Visible = true;

            GridColumn colMAHSUP_TOPLAMI_DOVIZ_ID = new GridColumn();
            colMAHSUP_TOPLAMI_DOVIZ_ID.VisibleIndex = 37;
            colMAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Name = "colMAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colALACAK_TOPLAMI = new GridColumn();
            colALACAK_TOPLAMI.VisibleIndex = 38;
            colALACAK_TOPLAMI.FieldName = "ALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Name = "colALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Visible = true;

            GridColumn colALACAK_TOPLAMI_DOVIZ_ID = new GridColumn();
            colALACAK_TOPLAMI_DOVIZ_ID.VisibleIndex = 39;
            colALACAK_TOPLAMI_DOVIZ_ID.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Name = "colALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colFERAGAT_TOPLAMI = new GridColumn();
            colFERAGAT_TOPLAMI.VisibleIndex = 40;
            colFERAGAT_TOPLAMI.FieldName = "FERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Name = "colFERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Visible = true;

            GridColumn colFERAGAT_TOPLAMI_DOVIZ_ID = new GridColumn();
            colFERAGAT_TOPLAMI_DOVIZ_ID.VisibleIndex = 41;
            colFERAGAT_TOPLAMI_DOVIZ_ID.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Name = "colFERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_MIKTARI = new GridColumn();
            colPROTOKOL_MIKTARI.VisibleIndex = 42;
            colPROTOKOL_MIKTARI.FieldName = "PROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Name = "colPROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Visible = true;

            GridColumn colPROTOKOL_MIKTARI_DOVIZ_ID = new GridColumn();
            colPROTOKOL_MIKTARI_DOVIZ_ID.VisibleIndex = 43;
            colPROTOKOL_MIKTARI_DOVIZ_ID.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Name = "colPROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_TARIHI = new GridColumn();
            colPROTOKOL_TARIHI.VisibleIndex = 44;
            colPROTOKOL_TARIHI.FieldName = "PROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Name = "colPROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Visible = true;

            GridColumn colKARSILIK_TUTARI = new GridColumn();
            colKARSILIK_TUTARI.VisibleIndex = 45;
            colKARSILIK_TUTARI.FieldName = "KARSILIK_TUTARI";
            colKARSILIK_TUTARI.Name = "colKARSILIK_TUTARI";
            colKARSILIK_TUTARI.Visible = true;

            GridColumn colKARSILIK_TUTARI_DOVIZ_ID = new GridColumn();
            colKARSILIK_TUTARI_DOVIZ_ID.VisibleIndex = 46;
            colKARSILIK_TUTARI_DOVIZ_ID.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Name = "colKARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI = new GridColumn();
            colTUM_MASRAF_TOPLAMI.VisibleIndex = 47;
            colTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Name = "colTUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.VisibleIndex = 48;
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "colTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colHARC_TOPLAMI = new GridColumn();
            colHARC_TOPLAMI.VisibleIndex = 49;
            colHARC_TOPLAMI.FieldName = "HARC_TOPLAMI";
            colHARC_TOPLAMI.Name = "colHARC_TOPLAMI";
            colHARC_TOPLAMI.Visible = true;

            GridColumn colHARC_TOPLAMI_DOVIZ_ID = new GridColumn();
            colHARC_TOPLAMI_DOVIZ_ID.VisibleIndex = 50;
            colHARC_TOPLAMI_DOVIZ_ID.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Name = "colHARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI = new GridColumn();
            colTUM_VEKALET_TOPLAMI.VisibleIndex = 51;
            colTUM_VEKALET_TOPLAMI.FieldName = "TUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Name = "colTUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.VisibleIndex = 52;
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Name = "colTUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT.VisibleIndex = 53;
            colTAKIP_CIKIS_GAYRI_NAKIT.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Name = "colTAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.VisibleIndex = 54;
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Name = "colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN = new GridColumn();
            colGAYRI_NAKIT_KALAN.VisibleIndex = 55;
            colGAYRI_NAKIT_KALAN.FieldName = "GAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Name = "colGAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN_DOVIZ_ID = new GridColumn();
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.VisibleIndex = 56;
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.FieldName = "GAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Name = "colGAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 57;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colSUBE = new GridColumn();
            colSUBE.VisibleIndex = 58;
            colSUBE.FieldName = "SUBE";
            colSUBE.Name = "colSUBE";
            colSUBE.Visible = true;

            GridColumn colFOY_BIRIM = new GridColumn();
            colFOY_BIRIM.VisibleIndex = 59;
            colFOY_BIRIM.FieldName = "FOY_BIRIM";
            colFOY_BIRIM.Name = "colFOY_BIRIM";
            colFOY_BIRIM.Visible = true;

            GridColumn colFOY_YERI = new GridColumn();
            colFOY_YERI.VisibleIndex = 60;
            colFOY_YERI.FieldName = "FOY_YERI";
            colFOY_YERI.Name = "colFOY_YERI";
            colFOY_YERI.Visible = true;

            GridColumn colFOY_OZEL_DURUM = new GridColumn();
            colFOY_OZEL_DURUM.VisibleIndex = 61;
            colFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Name = "colFOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Visible = true;

            GridColumn colTAHSILAT_DURUM = new GridColumn();
            colTAHSILAT_DURUM.VisibleIndex = 62;
            colTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            colTAHSILAT_DURUM.Name = "colTAHSILAT_DURUM";
            colTAHSILAT_DURUM.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 63;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 64;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colKLASOR_1 = new GridColumn();
            colKLASOR_1.VisibleIndex = 65;
            colKLASOR_1.FieldName = "KLASOR_1";
            colKLASOR_1.Name = "colKLASOR_1";
            colKLASOR_1.Visible = true;

            GridColumn colKLASOR_2 = new GridColumn();
            colKLASOR_2.VisibleIndex = 66;
            colKLASOR_2.FieldName = "KLASOR_2";
            colKLASOR_2.Name = "colKLASOR_2";
            colKLASOR_2.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI = new GridColumn();
            colTUM_ODEME_TOPLAMI.VisibleIndex = 67;
            colTUM_ODEME_TOPLAMI.FieldName = "TUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Name = "colTUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 68;
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN.VisibleIndex = 69;
            colVEKALET_UCRETINDEN_ODENEN.FieldName = "VEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Name = "colVEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.VisibleIndex = 70;
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.FieldName = "VEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Name = "colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Visible = true;

            GridColumn colRISKTEN_KALAN = new GridColumn();
            colRISKTEN_KALAN.VisibleIndex = 71;
            colRISKTEN_KALAN.FieldName = "RISKTEN_KALAN";
            colRISKTEN_KALAN.Name = "colRISKTEN_KALAN";
            colRISKTEN_KALAN.Visible = true;

            GridColumn colRISKTEN_KALAN_DOVIZ_ID = new GridColumn();
            colRISKTEN_KALAN_DOVIZ_ID.VisibleIndex = 72;
            colRISKTEN_KALAN_DOVIZ_ID.FieldName = "RISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Name = "colRISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT.VisibleIndex = 73;
            colMASRAFA_YAPILAN_TAHSILAT.FieldName = "MASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Name = "colMASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 74;
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "MASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT.VisibleIndex = 75;
            colANA_PARAYA_YAPILAN_TAHSILAT.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Name = "colANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 76;
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT.VisibleIndex = 77;
            colFAIZE_YAPILAN_TAHSILAT.FieldName = "FAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Name = "colFAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 78;
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "FAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI = new GridColumn();
            colTO_ODEME_TOPLAMI.VisibleIndex = 79;
            colTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Name = "colTO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTO_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 80;
            colTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_NO = new GridColumn();
            colSUBE_NO.VisibleIndex = 81;
            colSUBE_NO.FieldName = "SUBE_NO";
            colSUBE_NO.Name = "colSUBE_NO";
            colSUBE_NO.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 82;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR.VisibleIndex = 83;
            colAVUKATA_ODENEN_MIKTAR.FieldName = "AVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Name = "colAVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 84;
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "AVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR.VisibleIndex = 85;
            colALACAKLIYA_ODENEN_MIKTAR.FieldName = "ALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Name = "colALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 86;
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "ALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR = new GridColumn();
            colSATISTAN_GELEN_MIKTAR.VisibleIndex = 87;
            colSATISTAN_GELEN_MIKTAR.FieldName = "SATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Name = "colSATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.VisibleIndex = 88;
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.FieldName = "SATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Name = "colSATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSEGMENT_ID = new GridColumn();
            colSEGMENT_ID.VisibleIndex = 89;
            colSEGMENT_ID.FieldName = "SEGMENT_ID";
            colSEGMENT_ID.Name = "colSEGMENT_ID";
            colSEGMENT_ID.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 90;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colTAKIP_EDILEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDILEN_TARAF_KOD.VisibleIndex = 91;
            colTAKIP_EDILEN_TARAF_KOD.FieldName = "TAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Name = "colTAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 92;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colTAKIP_EDILEN_SIFAT = new GridColumn();
            colTAKIP_EDILEN_SIFAT.VisibleIndex = 93;
            colTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Name = "colTAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Visible = true;

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 94;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colTAKIP_EDEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDEN_TARAF_KOD.VisibleIndex = 95;
            colTAKIP_EDEN_TARAF_KOD.FieldName = "TAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Name = "colTAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDEN_SIFAT = new GridColumn();
            colTAKIP_EDEN_SIFAT.VisibleIndex = 96;
            colTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Name = "colTAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 97;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 98;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            #endregion Field & Properties

            switch (pencere)
            {
                case "Bu Ay İçinde Gelen Dosyaların Anapara Toplamı":
                    dizi = BuAyIcindeGelenAnaParaTop();
                    break;

                case "Devam Eden Dosyalardan Anaparaya Yapılan Tahsilatlar":
                case "Devam Eden Dosyalardan Faize Yapılan Tahsilatlar":
                case "Biten Dosyalardan Anaparaya Yapılan Tahsilatlar":
                case "Biten Dosyalardan Faize Yapılan Tahsilatlar":
                case "Tüm Dosyalardan Faize Yapılan Tahsilatlar":
                case "Tüm Dosyalardan Anaparaya Yapılan Tahsilatlar":
                    dizi = DevamEdenDosyalardanAnaparayaYapılanTahsilatlar();
                    break;

                case "Toplam Tahsilat (Anapara ve Faize Yapılan Biten ve Devam Eden Dosyalardan)":
                case "Avukat Tahsilatları":
                case "Bankaca Yapılan Tahsilatlar":
                    dizi = ToplamTahsilat();
                    break;

                case "Kanuni Takibe İntikal Eden Ticari ve Kurumsal Krediler/Haftalık Rapor":
                case "Kanuni Takibe İntikal Eden Ticari ve Kurumsal Krediler/Aylık Rapor":
                case "Kanuni Takibe İntikal Eden Bireysel Krediler/Haftalık Rapor":
                case "Kanuni Takibe İntikal Eden Bireysel Krediler/Aylık Rapor":
                case "Kanuni Takibe İntikal Eden Kredi Kartları/Haftalık Rapor":
                case "Kanuni Takibe İntikal Eden Kredi Kartları/Aylık Rapor":
                    dizi = KanuniTakip();
                    break;

                case "Kanuni Takibe İntikal Eden Ticari ve Kurumsal Krediler/Bakiyeli Haftalık Rapor":
                case "Kanuni Takibe İntikal Eden Ticari ve Kurumsal Krediler/Bakiyeli Aylık Rapor":
                case "Kanuni Takibe İntikal Eden Bireysel Krediler/Bakiyeli Haftalık Rapor":
                case "Kanuni Takibe İntikal Eden Bireysel Krediler/Bakiyeli Aylık Rapor":
                case "Kanuni Takibe İntikal Eden Kredi Kartları/Bakiyeli Haftalık Rapor":
                case "Kanuni Takibe İntikal Eden Kredi Kartları/Bakiyeli Aylık Rapor":
                    dizi = KanuniTakipBakiyeli();
                    break;

                case "Devre Tahsilatları":
                    dizi = DevreTahsilat();
                    break;

                case "Devre Tahsilatları (icmal)":
                    dizi = DevreTahsilatIcmal();
                    break;
                default:
                    break;
            }

            #region []

            if (dizi == null)
            {
                dizi = new GridColumn[]
		{
			colAN_REF_NO1,
			colAN_REF_NO2,
			colAN_REF_NO3,
			colFOY_NO,
			colICRA_REF_NO1,
			colICRA_REF_NO2,
			colICRA_REF_NO3,
			colTAKIP_TARIHI,
			colESAS_NO,
			colTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			colASIL_ALACAK,
			colASIL_ALACAK_DOVIZ_ID,
			colISLEMIS_FAIZ,
			colISLEMIS_FAIZ_DOVIZ_ID,
			colSON_HESAP_TARIHI,
			colTAKIP_CIKISI,
			colTAKIP_CIKISI_DOVIZ_ID,
			colODEME_TOPLAMI,
			colODEME_TOPLAMI_DOVIZ_ID,
			colKALAN,
			colKALAN_DOVIZ_ID,
			colKAPAMA_TARIHI,
			colRISK_MIKTARI,
			colRISK_MIKTARI_DOVIZ_ID,
			colSUBE_KOD_ID,
			colDURUM,
			colADLIYE,
			colNO,
			colOZEL_KOD1,
			colOZEL_KOD2,
			colOZEL_KOD3,
			colOZEL_KOD4,
			colHESAPLAMA_TIPI,
			colBIR_YIL_KAC_GUN,
			colTAKIP_VEKALET_UCRETI,
			colTAKIP_VEKALET_UCRETI_DOVIZ_ID,
			colMAHSUP_TOPLAMI,
			colMAHSUP_TOPLAMI_DOVIZ_ID,
			colALACAK_TOPLAMI,
			colALACAK_TOPLAMI_DOVIZ_ID,
			colFERAGAT_TOPLAMI,
			colFERAGAT_TOPLAMI_DOVIZ_ID,
			colPROTOKOL_MIKTARI,
			colPROTOKOL_MIKTARI_DOVIZ_ID,
			colPROTOKOL_TARIHI,
			colKARSILIK_TUTARI,
			colKARSILIK_TUTARI_DOVIZ_ID,
			colTUM_MASRAF_TOPLAMI,
			colTUM_MASRAF_TOPLAMI_DOVIZ_ID,
			colHARC_TOPLAMI,
			colHARC_TOPLAMI_DOVIZ_ID,
			colTUM_VEKALET_TOPLAMI,
			colTUM_VEKALET_TOPLAMI_DOVIZ_ID,
			colTAKIP_CIKIS_GAYRI_NAKIT,
			colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID,
			colGAYRI_NAKIT_KALAN,
			colGAYRI_NAKIT_KALAN_DOVIZ_ID,
			colBANKA,
			colSUBE,
			colFOY_BIRIM,
			colFOY_YERI,
			colFOY_OZEL_DURUM,
			colTAHSILAT_DURUM,
			colKREDI_GRUP,
			colKREDI_TIP,
			colKLASOR_1,
			colKLASOR_2,
			colTUM_ODEME_TOPLAMI,
			colTUM_ODEME_TOPLAMI_DOVIZ_ID,
			colVEKALET_UCRETINDEN_ODENEN,
			colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID,
			colRISKTEN_KALAN,
			colRISKTEN_KALAN_DOVIZ_ID,
			colMASRAFA_YAPILAN_TAHSILAT,
			colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID,
			colANA_PARAYA_YAPILAN_TAHSILAT,
			colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID,
			colFAIZE_YAPILAN_TAHSILAT,
			colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID,
			colTO_ODEME_TOPLAMI,
			colTO_ODEME_TOPLAMI_DOVIZ_ID,
			colSUBE_NO,
			colID,
			colAVUKATA_ODENEN_MIKTAR,
			colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID,
			colALACAKLIYA_ODENEN_MIKTAR,
			colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID,
			colSATISTAN_GELEN_MIKTAR,
			colSATISTAN_GELEN_MIKTAR_DOVIZ_ID,
			colSEGMENT_ID,
			colSORUMLU,
			colTAKIP_EDILEN_TARAF_KOD,
			colTAKIP_EDILEN,
			colTAKIP_EDILEN_SIFAT,
			colTAKIP_EDEN,
			colTAKIP_EDEN_TARAF_KOD,
			colTAKIP_EDEN_SIFAT,
			colIZLEYEN,
			colKONTROL_KIM_ID,
			};
            }

            #endregion []

            #region Column Caption

            Dictionary<string, string> captionlar = GetCaptionDictinory();
            Dictionary<string, RepositoryItem> editler = GetRepositoryItemDictinory();

            for (int i = 0; i < dizi.Length; i++)
            {
                string caption = string.Empty;
                if (captionlar.ContainsKey(dizi[i].FieldName))
                    caption = captionlar[dizi[i].FieldName];
                if (caption.Length > 0)
                    dizi[i].Caption = caption;
                else if (dizi[i].FieldName.ToLower().Contains("doviz_id"))
                {
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTip = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToString();
                }
                if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
                {
                    dizi[i].ColumnEdit = editler["DovizId"];
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTip = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToString();
                }
                else if (editler.ContainsKey(dizi[i].FieldName))
                    dizi[i].ColumnEdit = editler[dizi[i].FieldName];
            }

            #endregion Column Caption

            return dizi;
        }

        public PivotGridField[] GetPivotFields()
        {
            #region Field & Properties

            PivotGridField fieldAN_REF_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAN_REF_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAN_REF_NO1.AreaIndex = 0;
            fieldAN_REF_NO1.FieldName = "AN_REF_NO1";
            fieldAN_REF_NO1.Name = "fieldAN_REF_NO1";
            fieldAN_REF_NO1.Visible = false;

            PivotGridField fieldAN_REF_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAN_REF_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAN_REF_NO2.AreaIndex = 1;
            fieldAN_REF_NO2.FieldName = "AN_REF_NO2";
            fieldAN_REF_NO2.Name = "fieldAN_REF_NO2";
            fieldAN_REF_NO2.Visible = false;

            PivotGridField fieldAN_REF_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAN_REF_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAN_REF_NO3.AreaIndex = 2;
            fieldAN_REF_NO3.FieldName = "AN_REF_NO3";
            fieldAN_REF_NO3.Name = "fieldAN_REF_NO3";
            fieldAN_REF_NO3.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 3;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldICRA_REF_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_REF_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_REF_NO1.AreaIndex = 4;
            fieldICRA_REF_NO1.FieldName = "ICRA_REF_NO1";
            fieldICRA_REF_NO1.Name = "fieldICRA_REF_NO1";
            fieldICRA_REF_NO1.Visible = false;

            PivotGridField fieldICRA_REF_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_REF_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_REF_NO2.AreaIndex = 5;
            fieldICRA_REF_NO2.FieldName = "ICRA_REF_NO2";
            fieldICRA_REF_NO2.Name = "fieldICRA_REF_NO2";
            fieldICRA_REF_NO2.Visible = false;

            PivotGridField fieldICRA_REF_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_REF_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_REF_NO3.AreaIndex = 6;
            fieldICRA_REF_NO3.FieldName = "ICRA_REF_NO3";
            fieldICRA_REF_NO3.Name = "fieldICRA_REF_NO3";
            fieldICRA_REF_NO3.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 7;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 8;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 9;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 11;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldISLEMIS_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEMIS_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEMIS_FAIZ.AreaIndex = 12;
            fieldISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            fieldISLEMIS_FAIZ.Name = "fieldISLEMIS_FAIZ";
            fieldISLEMIS_FAIZ.Visible = false;

            PivotGridField fieldISLEMIS_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEMIS_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEMIS_FAIZ_DOVIZ_ID.AreaIndex = 13;
            fieldISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            fieldISLEMIS_FAIZ_DOVIZ_ID.Name = "fieldISLEMIS_FAIZ_DOVIZ_ID";
            fieldISLEMIS_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldSON_HESAP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSON_HESAP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSON_HESAP_TARIHI.AreaIndex = 14;
            fieldSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Name = "fieldSON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI.AreaIndex = 15;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 16;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI.AreaIndex = 17;
            fieldODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Name = "fieldODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Visible = false;

            PivotGridField fieldODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 18;
            fieldODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Name = "fieldODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 19;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 20;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 21;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 22;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 23;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 24;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 25;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 26;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 27;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldOZEL_KOD1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD1.AreaIndex = 28;
            fieldOZEL_KOD1.FieldName = "OZEL_KOD1";
            fieldOZEL_KOD1.Name = "fieldOZEL_KOD1";
            fieldOZEL_KOD1.Visible = false;

            PivotGridField fieldOZEL_KOD2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD2.AreaIndex = 29;
            fieldOZEL_KOD2.FieldName = "OZEL_KOD2";
            fieldOZEL_KOD2.Name = "fieldOZEL_KOD2";
            fieldOZEL_KOD2.Visible = false;

            PivotGridField fieldOZEL_KOD3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD3.AreaIndex = 30;
            fieldOZEL_KOD3.FieldName = "OZEL_KOD3";
            fieldOZEL_KOD3.Name = "fieldOZEL_KOD3";
            fieldOZEL_KOD3.Visible = false;

            PivotGridField fieldOZEL_KOD4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD4.AreaIndex = 31;
            fieldOZEL_KOD4.FieldName = "OZEL_KOD4";
            fieldOZEL_KOD4.Name = "fieldOZEL_KOD4";
            fieldOZEL_KOD4.Visible = false;

            PivotGridField fieldHESAPLAMA_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHESAPLAMA_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHESAPLAMA_TIPI.AreaIndex = 32;
            fieldHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            fieldHESAPLAMA_TIPI.Name = "fieldHESAPLAMA_TIPI";
            fieldHESAPLAMA_TIPI.Visible = false;

            PivotGridField fieldBIR_YIL_KAC_GUN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIR_YIL_KAC_GUN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIR_YIL_KAC_GUN.AreaIndex = 33;
            fieldBIR_YIL_KAC_GUN.FieldName = "BIR_YIL_KAC_GUN";
            fieldBIR_YIL_KAC_GUN.Name = "fieldBIR_YIL_KAC_GUN";
            fieldBIR_YIL_KAC_GUN.Visible = false;

            PivotGridField fieldTAKIP_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_VEKALET_UCRETI.AreaIndex = 34;
            fieldTAKIP_VEKALET_UCRETI.FieldName = "TAKIP_VEKALET_UCRETI";
            fieldTAKIP_VEKALET_UCRETI.Name = "fieldTAKIP_VEKALET_UCRETI";
            fieldTAKIP_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 35;
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID";
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldMAHSUP_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHSUP_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHSUP_TOPLAMI.AreaIndex = 36;
            fieldMAHSUP_TOPLAMI.FieldName = "MAHSUP_TOPLAMI";
            fieldMAHSUP_TOPLAMI.Name = "fieldMAHSUP_TOPLAMI";
            fieldMAHSUP_TOPLAMI.Visible = false;

            PivotGridField fieldMAHSUP_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.AreaIndex = 37;
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.Name = "fieldMAHSUP_TOPLAMI_DOVIZ_ID";
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldALACAK_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_TOPLAMI.AreaIndex = 38;
            fieldALACAK_TOPLAMI.FieldName = "ALACAK_TOPLAMI";
            fieldALACAK_TOPLAMI.Name = "fieldALACAK_TOPLAMI";
            fieldALACAK_TOPLAMI.Visible = false;

            PivotGridField fieldALACAK_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_TOPLAMI_DOVIZ_ID.AreaIndex = 39;
            fieldALACAK_TOPLAMI_DOVIZ_ID.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            fieldALACAK_TOPLAMI_DOVIZ_ID.Name = "fieldALACAK_TOPLAMI_DOVIZ_ID";
            fieldALACAK_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldFERAGAT_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFERAGAT_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFERAGAT_TOPLAMI.AreaIndex = 40;
            fieldFERAGAT_TOPLAMI.FieldName = "FERAGAT_TOPLAMI";
            fieldFERAGAT_TOPLAMI.Name = "fieldFERAGAT_TOPLAMI";
            fieldFERAGAT_TOPLAMI.Visible = false;

            PivotGridField fieldFERAGAT_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.AreaIndex = 41;
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.Name = "fieldFERAGAT_TOPLAMI_DOVIZ_ID";
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldPROTOKOL_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTOKOL_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTOKOL_MIKTARI.AreaIndex = 42;
            fieldPROTOKOL_MIKTARI.FieldName = "PROTOKOL_MIKTARI";
            fieldPROTOKOL_MIKTARI.Name = "fieldPROTOKOL_MIKTARI";
            fieldPROTOKOL_MIKTARI.Visible = false;

            PivotGridField fieldPROTOKOL_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.AreaIndex = 43;
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.Name = "fieldPROTOKOL_MIKTARI_DOVIZ_ID";
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldPROTOKOL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTOKOL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTOKOL_TARIHI.AreaIndex = 44;
            fieldPROTOKOL_TARIHI.FieldName = "PROTOKOL_TARIHI";
            fieldPROTOKOL_TARIHI.Name = "fieldPROTOKOL_TARIHI";
            fieldPROTOKOL_TARIHI.Visible = false;

            PivotGridField fieldKARSILIK_TUTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIK_TUTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIK_TUTARI.AreaIndex = 45;
            fieldKARSILIK_TUTARI.FieldName = "KARSILIK_TUTARI";
            fieldKARSILIK_TUTARI.Name = "fieldKARSILIK_TUTARI";
            fieldKARSILIK_TUTARI.Visible = false;

            PivotGridField fieldKARSILIK_TUTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIK_TUTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIK_TUTARI_DOVIZ_ID.AreaIndex = 46;
            fieldKARSILIK_TUTARI_DOVIZ_ID.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            fieldKARSILIK_TUTARI_DOVIZ_ID.Name = "fieldKARSILIK_TUTARI_DOVIZ_ID";
            fieldKARSILIK_TUTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 47;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 48;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldHARC_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHARC_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHARC_TOPLAMI.AreaIndex = 49;
            fieldHARC_TOPLAMI.FieldName = "HARC_TOPLAMI";
            fieldHARC_TOPLAMI.Name = "fieldHARC_TOPLAMI";
            fieldHARC_TOPLAMI.Visible = false;

            PivotGridField fieldHARC_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHARC_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHARC_TOPLAMI_DOVIZ_ID.AreaIndex = 50;
            fieldHARC_TOPLAMI_DOVIZ_ID.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            fieldHARC_TOPLAMI_DOVIZ_ID.Name = "fieldHARC_TOPLAMI_DOVIZ_ID";
            fieldHARC_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_VEKALET_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_VEKALET_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_VEKALET_TOPLAMI.AreaIndex = 51;
            fieldTUM_VEKALET_TOPLAMI.FieldName = "TUM_VEKALET_TOPLAMI";
            fieldTUM_VEKALET_TOPLAMI.Name = "fieldTUM_VEKALET_TOPLAMI";
            fieldTUM_VEKALET_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.AreaIndex = 52;
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAKIP_CIKIS_GAYRI_NAKIT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKIS_GAYRI_NAKIT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKIS_GAYRI_NAKIT.AreaIndex = 53;
            fieldTAKIP_CIKIS_GAYRI_NAKIT.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT";
            fieldTAKIP_CIKIS_GAYRI_NAKIT.Name = "fieldTAKIP_CIKIS_GAYRI_NAKIT";
            fieldTAKIP_CIKIS_GAYRI_NAKIT.Visible = false;

            PivotGridField fieldTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.AreaIndex = 54;
            fieldTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            fieldTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Name = "fieldTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            fieldTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Visible = false;

            PivotGridField fieldGAYRI_NAKIT_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGAYRI_NAKIT_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGAYRI_NAKIT_KALAN.AreaIndex = 55;
            fieldGAYRI_NAKIT_KALAN.FieldName = "GAYRI_NAKIT_KALAN";
            fieldGAYRI_NAKIT_KALAN.Name = "fieldGAYRI_NAKIT_KALAN";
            fieldGAYRI_NAKIT_KALAN.Visible = false;

            PivotGridField fieldGAYRI_NAKIT_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGAYRI_NAKIT_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGAYRI_NAKIT_KALAN_DOVIZ_ID.AreaIndex = 56;
            fieldGAYRI_NAKIT_KALAN_DOVIZ_ID.FieldName = "GAYRI_NAKIT_KALAN_DOVIZ_ID";
            fieldGAYRI_NAKIT_KALAN_DOVIZ_ID.Name = "fieldGAYRI_NAKIT_KALAN_DOVIZ_ID";
            fieldGAYRI_NAKIT_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 57;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldSUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE.AreaIndex = 58;
            fieldSUBE.FieldName = "SUBE";
            fieldSUBE.Name = "fieldSUBE";
            fieldSUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 59;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 60;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 61;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 62;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 63;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 64;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 65;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 66;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldTUM_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_ODEME_TOPLAMI.AreaIndex = 67;
            fieldTUM_ODEME_TOPLAMI.FieldName = "TUM_ODEME_TOPLAMI";
            fieldTUM_ODEME_TOPLAMI.Name = "fieldTUM_ODEME_TOPLAMI";
            fieldTUM_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 68;
            fieldTUM_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TUM_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTUM_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTUM_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldVEKALET_UCRETINDEN_ODENEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVEKALET_UCRETINDEN_ODENEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVEKALET_UCRETINDEN_ODENEN.AreaIndex = 69;
            fieldVEKALET_UCRETINDEN_ODENEN.FieldName = "VEKALET_UCRETINDEN_ODENEN";
            fieldVEKALET_UCRETINDEN_ODENEN.Name = "fieldVEKALET_UCRETINDEN_ODENEN";
            fieldVEKALET_UCRETINDEN_ODENEN.Visible = false;

            PivotGridField fieldVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.AreaIndex = 70;
            fieldVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.FieldName = "VEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            fieldVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Name = "fieldVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            fieldVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISKTEN_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISKTEN_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISKTEN_KALAN.AreaIndex = 71;
            fieldRISKTEN_KALAN.FieldName = "RISKTEN_KALAN";
            fieldRISKTEN_KALAN.Name = "fieldRISKTEN_KALAN";
            fieldRISKTEN_KALAN.Visible = false;

            PivotGridField fieldRISKTEN_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISKTEN_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISKTEN_KALAN_DOVIZ_ID.AreaIndex = 72;
            fieldRISKTEN_KALAN_DOVIZ_ID.FieldName = "RISKTEN_KALAN_DOVIZ_ID";
            fieldRISKTEN_KALAN_DOVIZ_ID.Name = "fieldRISKTEN_KALAN_DOVIZ_ID";
            fieldRISKTEN_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldMASRAFA_YAPILAN_TAHSILAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAFA_YAPILAN_TAHSILAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAFA_YAPILAN_TAHSILAT.AreaIndex = 73;
            fieldMASRAFA_YAPILAN_TAHSILAT.FieldName = "MASRAFA_YAPILAN_TAHSILAT";
            fieldMASRAFA_YAPILAN_TAHSILAT.Name = "fieldMASRAFA_YAPILAN_TAHSILAT";
            fieldMASRAFA_YAPILAN_TAHSILAT.Visible = false;

            PivotGridField fieldMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.AreaIndex = 74;
            fieldMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "MASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            fieldMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "fieldMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            fieldMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldANA_PARAYA_YAPILAN_TAHSILAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_PARAYA_YAPILAN_TAHSILAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldANA_PARAYA_YAPILAN_TAHSILAT.AreaIndex = 75;
            fieldANA_PARAYA_YAPILAN_TAHSILAT.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT";
            fieldANA_PARAYA_YAPILAN_TAHSILAT.Name = "fieldANA_PARAYA_YAPILAN_TAHSILAT";
            fieldANA_PARAYA_YAPILAN_TAHSILAT.Visible = false;

            PivotGridField fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.AreaIndex = 76;
            fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldFAIZE_YAPILAN_TAHSILAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFAIZE_YAPILAN_TAHSILAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFAIZE_YAPILAN_TAHSILAT.AreaIndex = 77;
            fieldFAIZE_YAPILAN_TAHSILAT.FieldName = "FAIZE_YAPILAN_TAHSILAT";
            fieldFAIZE_YAPILAN_TAHSILAT.Name = "fieldFAIZE_YAPILAN_TAHSILAT";
            fieldFAIZE_YAPILAN_TAHSILAT.Visible = false;

            PivotGridField fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.AreaIndex = 78;
            fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "FAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 79;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 80;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_NO.AreaIndex = 81;
            fieldSUBE_NO.FieldName = "SUBE_NO";
            fieldSUBE_NO.Name = "fieldSUBE_NO";
            fieldSUBE_NO.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 82;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldAVUKATA_ODENEN_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAVUKATA_ODENEN_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAVUKATA_ODENEN_MIKTAR.AreaIndex = 83;
            fieldAVUKATA_ODENEN_MIKTAR.FieldName = "AVUKATA_ODENEN_MIKTAR";
            fieldAVUKATA_ODENEN_MIKTAR.Name = "fieldAVUKATA_ODENEN_MIKTAR";
            fieldAVUKATA_ODENEN_MIKTAR.Visible = false;

            PivotGridField fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.AreaIndex = 84;
            fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "AVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Name = "fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldALACAKLIYA_ODENEN_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAKLIYA_ODENEN_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAKLIYA_ODENEN_MIKTAR.AreaIndex = 85;
            fieldALACAKLIYA_ODENEN_MIKTAR.FieldName = "ALACAKLIYA_ODENEN_MIKTAR";
            fieldALACAKLIYA_ODENEN_MIKTAR.Name = "fieldALACAKLIYA_ODENEN_MIKTAR";
            fieldALACAKLIYA_ODENEN_MIKTAR.Visible = false;

            PivotGridField fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.AreaIndex = 86;
            fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "ALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Name = "fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldSATISTAN_GELEN_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATISTAN_GELEN_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATISTAN_GELEN_MIKTAR.AreaIndex = 87;
            fieldSATISTAN_GELEN_MIKTAR.FieldName = "SATISTAN_GELEN_MIKTAR";
            fieldSATISTAN_GELEN_MIKTAR.Name = "fieldSATISTAN_GELEN_MIKTAR";
            fieldSATISTAN_GELEN_MIKTAR.Visible = false;

            PivotGridField fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID.AreaIndex = 88;
            fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID.FieldName = "SATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Name = "fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldSEGMENT_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSEGMENT_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSEGMENT_ID.AreaIndex = 89;
            fieldSEGMENT_ID.FieldName = "SEGMENT_ID";
            fieldSEGMENT_ID.Name = "fieldSEGMENT_ID";
            fieldSEGMENT_ID.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 90;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldTAKIP_EDILEN_TARAF_KOD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN_TARAF_KOD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN_TARAF_KOD.AreaIndex = 91;
            fieldTAKIP_EDILEN_TARAF_KOD.FieldName = "TAKIP_EDILEN_TARAF_KOD";
            fieldTAKIP_EDILEN_TARAF_KOD.Name = "fieldTAKIP_EDILEN_TARAF_KOD";
            fieldTAKIP_EDILEN_TARAF_KOD.Visible = false;

            PivotGridField fieldTAKIP_EDILEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN.AreaIndex = 92;
            fieldTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            fieldTAKIP_EDILEN.Name = "fieldTAKIP_EDILEN";
            fieldTAKIP_EDILEN.Visible = false;

            PivotGridField fieldTAKIP_EDILEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN_SIFAT.AreaIndex = 93;
            fieldTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            fieldTAKIP_EDILEN_SIFAT.Name = "fieldTAKIP_EDILEN_SIFAT";
            fieldTAKIP_EDILEN_SIFAT.Visible = false;

            PivotGridField fieldTAKIP_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN.AreaIndex = 94;
            fieldTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            fieldTAKIP_EDEN.Name = "fieldTAKIP_EDEN";
            fieldTAKIP_EDEN.Visible = false;

            PivotGridField fieldTAKIP_EDEN_TARAF_KOD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN_TARAF_KOD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN_TARAF_KOD.AreaIndex = 95;
            fieldTAKIP_EDEN_TARAF_KOD.FieldName = "TAKIP_EDEN_TARAF_KOD";
            fieldTAKIP_EDEN_TARAF_KOD.Name = "fieldTAKIP_EDEN_TARAF_KOD";
            fieldTAKIP_EDEN_TARAF_KOD.Visible = false;

            PivotGridField fieldTAKIP_EDEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN_SIFAT.AreaIndex = 96;
            fieldTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            fieldTAKIP_EDEN_SIFAT.Name = "fieldTAKIP_EDEN_SIFAT";
            fieldTAKIP_EDEN_SIFAT.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 97;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 98;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldAN_REF_NO1,
			fieldAN_REF_NO2,
			fieldAN_REF_NO3,
			fieldFOY_NO,
			fieldICRA_REF_NO1,
			fieldICRA_REF_NO2,
			fieldICRA_REF_NO3,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			fieldASIL_ALACAK,
			fieldASIL_ALACAK_DOVIZ_ID,
			fieldISLEMIS_FAIZ,
			fieldISLEMIS_FAIZ_DOVIZ_ID,
			fieldSON_HESAP_TARIHI,
			fieldTAKIP_CIKISI,
			fieldTAKIP_CIKISI_DOVIZ_ID,
			fieldODEME_TOPLAMI,
			fieldODEME_TOPLAMI_DOVIZ_ID,
			fieldKALAN,
			fieldKALAN_DOVIZ_ID,
			fieldKAPAMA_TARIHI,
			fieldRISK_MIKTARI,
			fieldRISK_MIKTARI_DOVIZ_ID,
			fieldSUBE_KOD_ID,
			fieldDURUM,
			fieldADLIYE,
			fieldNO,
			fieldOZEL_KOD1,
			fieldOZEL_KOD2,
			fieldOZEL_KOD3,
			fieldOZEL_KOD4,
			fieldHESAPLAMA_TIPI,
			fieldBIR_YIL_KAC_GUN,
			fieldTAKIP_VEKALET_UCRETI,
			fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID,
			fieldMAHSUP_TOPLAMI,
			fieldMAHSUP_TOPLAMI_DOVIZ_ID,
			fieldALACAK_TOPLAMI,
			fieldALACAK_TOPLAMI_DOVIZ_ID,
			fieldFERAGAT_TOPLAMI,
			fieldFERAGAT_TOPLAMI_DOVIZ_ID,
			fieldPROTOKOL_MIKTARI,
			fieldPROTOKOL_MIKTARI_DOVIZ_ID,
			fieldPROTOKOL_TARIHI,
			fieldKARSILIK_TUTARI,
			fieldKARSILIK_TUTARI_DOVIZ_ID,
			fieldTUM_MASRAF_TOPLAMI,
			fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
			fieldHARC_TOPLAMI,
			fieldHARC_TOPLAMI_DOVIZ_ID,
			fieldTUM_VEKALET_TOPLAMI,
			fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID,
			fieldTAKIP_CIKIS_GAYRI_NAKIT,
			fieldTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID,
			fieldGAYRI_NAKIT_KALAN,
			fieldGAYRI_NAKIT_KALAN_DOVIZ_ID,
			fieldBANKA,
			fieldSUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldTAHSILAT_DURUM,
			fieldKREDI_GRUP,
			fieldKREDI_TIP,
			fieldKLASOR_1,
			fieldKLASOR_2,
			fieldTUM_ODEME_TOPLAMI,
			fieldTUM_ODEME_TOPLAMI_DOVIZ_ID,
			fieldVEKALET_UCRETINDEN_ODENEN,
			fieldVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID,
			fieldRISKTEN_KALAN,
			fieldRISKTEN_KALAN_DOVIZ_ID,
			fieldMASRAFA_YAPILAN_TAHSILAT,
			fieldMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID,
			fieldANA_PARAYA_YAPILAN_TAHSILAT,
			fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID,
			fieldFAIZE_YAPILAN_TAHSILAT,
			fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID,
			fieldTO_ODEME_TOPLAMI,
			fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
			fieldSUBE_NO,
			fieldID,
			fieldAVUKATA_ODENEN_MIKTAR,
			fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID,
			fieldALACAKLIYA_ODENEN_MIKTAR,
			fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID,
			fieldSATISTAN_GELEN_MIKTAR,
			fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID,
			fieldSEGMENT_ID,
			fieldSORUMLU,
			fieldTAKIP_EDILEN_TARAF_KOD,
			fieldTAKIP_EDILEN,
			fieldTAKIP_EDILEN_SIFAT,
			fieldTAKIP_EDEN,
			fieldTAKIP_EDEN_TARAF_KOD,
			fieldTAKIP_EDEN_SIFAT,
			fieldIZLEYEN,
			fieldKONTROL_KIM_ID,
			};

            #endregion []

            #region Field Caption

            Dictionary<string, string> captionlar = GetCaptionDictinory();
            Dictionary<string, RepositoryItem> editler = GetRepositoryItemDictinory();

            for (int i = 0; i < dizi.Length; i++)
            {
                string caption = string.Empty;
                if (captionlar.ContainsKey(dizi[i].FieldName))
                    caption = captionlar[dizi[i].FieldName];
                if (caption.Length > 0)
                    dizi[i].Caption = caption;
                else if (dizi[i].FieldName.ToLower().Contains("doviz_id"))
                {
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTips.ValueText = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToString();
                }
                if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
                {
                    dizi[i].FieldEdit = editler["DovizId"];
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTips.ValueText = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToString();
                }
                else if (editler.ContainsKey(dizi[i].FieldName))
                    dizi[i].FieldEdit = editler[dizi[i].FieldName];
            }

            #endregion Field Caption

            return dizi;
        }

        private GridColumn[] BuAyIcindeGelenAnaParaTop()
        {
            #region Field & Properties

            GridColumn colAN_REF_NO1 = new GridColumn();
            colAN_REF_NO1.VisibleIndex = 0;
            colAN_REF_NO1.FieldName = "AN_REF_NO1";
            colAN_REF_NO1.Name = "colAN_REF_NO1";
            colAN_REF_NO1.Visible = true;

            GridColumn colAN_REF_NO2 = new GridColumn();
            colAN_REF_NO2.VisibleIndex = 1;
            colAN_REF_NO2.FieldName = "AN_REF_NO2";
            colAN_REF_NO2.Name = "colAN_REF_NO2";
            colAN_REF_NO2.Visible = true;

            GridColumn colAN_REF_NO3 = new GridColumn();
            colAN_REF_NO3.VisibleIndex = 2;
            colAN_REF_NO3.FieldName = "AN_REF_NO3";
            colAN_REF_NO3.Name = "colAN_REF_NO3";
            colAN_REF_NO3.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 3;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colICRA_REF_NO1 = new GridColumn();
            colICRA_REF_NO1.VisibleIndex = 4;
            colICRA_REF_NO1.FieldName = "ICRA_REF_NO1";
            colICRA_REF_NO1.Name = "colICRA_REF_NO1";
            colICRA_REF_NO1.Visible = true;

            GridColumn colICRA_REF_NO2 = new GridColumn();
            colICRA_REF_NO2.VisibleIndex = 5;
            colICRA_REF_NO2.FieldName = "ICRA_REF_NO2";
            colICRA_REF_NO2.Name = "colICRA_REF_NO2";
            colICRA_REF_NO2.Visible = true;

            GridColumn colICRA_REF_NO3 = new GridColumn();
            colICRA_REF_NO3.VisibleIndex = 6;
            colICRA_REF_NO3.FieldName = "ICRA_REF_NO3";
            colICRA_REF_NO3.Name = "colICRA_REF_NO3";
            colICRA_REF_NO3.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 7;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 8;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colTAKIBIN_AVUKATA_INTIKAL_TARIHI = new GridColumn();
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 9;
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "colTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colASIL_ALACAK = new GridColumn();
            colASIL_ALACAK.VisibleIndex = 10;
            colASIL_ALACAK.FieldName = "ASIL_ALACAK";
            colASIL_ALACAK.Name = "colASIL_ALACAK";
            colASIL_ALACAK.Visible = true;

            GridColumn colASIL_ALACAK_DOVIZ_ID = new GridColumn();
            colASIL_ALACAK_DOVIZ_ID.VisibleIndex = 11;
            colASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Name = "colASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Visible = true;

            GridColumn colISLEMIS_FAIZ = new GridColumn();
            colISLEMIS_FAIZ.VisibleIndex = 12;
            colISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Name = "colISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Visible = true;

            GridColumn colISLEMIS_FAIZ_DOVIZ_ID = new GridColumn();
            colISLEMIS_FAIZ_DOVIZ_ID.VisibleIndex = 13;
            colISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Name = "colISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colSON_HESAP_TARIHI = new GridColumn();
            colSON_HESAP_TARIHI.VisibleIndex = 14;
            colSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Name = "colSON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Visible = true;

            GridColumn colTAKIP_CIKISI = new GridColumn();
            colTAKIP_CIKISI.VisibleIndex = 15;
            colTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            colTAKIP_CIKISI.Name = "colTAKIP_CIKISI";
            colTAKIP_CIKISI.Visible = true;

            GridColumn colTAKIP_CIKISI_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKISI_DOVIZ_ID.VisibleIndex = 16;
            colTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Name = "colTAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_TOPLAMI = new GridColumn();
            colODEME_TOPLAMI.VisibleIndex = 17;
            colODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            colODEME_TOPLAMI.Name = "colODEME_TOPLAMI";
            colODEME_TOPLAMI.Visible = true;

            GridColumn colODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 18;
            colODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Name = "colODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN = new GridColumn();
            colKALAN.VisibleIndex = 19;
            colKALAN.FieldName = "KALAN";
            colKALAN.Name = "colKALAN";
            colKALAN.Visible = true;

            GridColumn colKALAN_DOVIZ_ID = new GridColumn();
            colKALAN_DOVIZ_ID.VisibleIndex = 20;
            colKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Name = "colKALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Visible = true;

            GridColumn colKAPAMA_TARIHI = new GridColumn();
            colKAPAMA_TARIHI.VisibleIndex = 21;
            colKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            colKAPAMA_TARIHI.Name = "colKAPAMA_TARIHI";
            colKAPAMA_TARIHI.Visible = true;

            GridColumn colRISK_MIKTARI = new GridColumn();
            colRISK_MIKTARI.VisibleIndex = 22;
            colRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            colRISK_MIKTARI.Name = "colRISK_MIKTARI";
            colRISK_MIKTARI.Visible = true;

            GridColumn colRISK_MIKTARI_DOVIZ_ID = new GridColumn();
            colRISK_MIKTARI_DOVIZ_ID.VisibleIndex = 23;
            colRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Name = "colRISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 24;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 25;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 26;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 27;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 28;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 29;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 30;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 31;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.Visible = true;

            GridColumn colHESAPLAMA_TIPI = new GridColumn();
            colHESAPLAMA_TIPI.VisibleIndex = 32;
            colHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Name = "colHESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Visible = true;

            GridColumn colBIR_YIL_KAC_GUN = new GridColumn();
            colBIR_YIL_KAC_GUN.VisibleIndex = 33;
            colBIR_YIL_KAC_GUN.FieldName = "BIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Name = "colBIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI = new GridColumn();
            colTAKIP_VEKALET_UCRETI.VisibleIndex = 34;
            colTAKIP_VEKALET_UCRETI.FieldName = "TAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Name = "colTAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 35;
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Name = "colTAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colMAHSUP_TOPLAMI = new GridColumn();
            colMAHSUP_TOPLAMI.VisibleIndex = 36;
            colMAHSUP_TOPLAMI.FieldName = "MAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Name = "colMAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Visible = true;

            GridColumn colMAHSUP_TOPLAMI_DOVIZ_ID = new GridColumn();
            colMAHSUP_TOPLAMI_DOVIZ_ID.VisibleIndex = 37;
            colMAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Name = "colMAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colALACAK_TOPLAMI = new GridColumn();
            colALACAK_TOPLAMI.VisibleIndex = 38;
            colALACAK_TOPLAMI.FieldName = "ALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Name = "colALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Visible = true;

            GridColumn colALACAK_TOPLAMI_DOVIZ_ID = new GridColumn();
            colALACAK_TOPLAMI_DOVIZ_ID.VisibleIndex = 39;
            colALACAK_TOPLAMI_DOVIZ_ID.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Name = "colALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colFERAGAT_TOPLAMI = new GridColumn();
            colFERAGAT_TOPLAMI.VisibleIndex = 40;
            colFERAGAT_TOPLAMI.FieldName = "FERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Name = "colFERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Visible = true;

            GridColumn colFERAGAT_TOPLAMI_DOVIZ_ID = new GridColumn();
            colFERAGAT_TOPLAMI_DOVIZ_ID.VisibleIndex = 41;
            colFERAGAT_TOPLAMI_DOVIZ_ID.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Name = "colFERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_MIKTARI = new GridColumn();
            colPROTOKOL_MIKTARI.VisibleIndex = 42;
            colPROTOKOL_MIKTARI.FieldName = "PROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Name = "colPROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Visible = true;

            GridColumn colPROTOKOL_MIKTARI_DOVIZ_ID = new GridColumn();
            colPROTOKOL_MIKTARI_DOVIZ_ID.VisibleIndex = 43;
            colPROTOKOL_MIKTARI_DOVIZ_ID.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Name = "colPROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_TARIHI = new GridColumn();
            colPROTOKOL_TARIHI.VisibleIndex = 44;
            colPROTOKOL_TARIHI.FieldName = "PROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Name = "colPROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Visible = true;

            GridColumn colKARSILIK_TUTARI = new GridColumn();
            colKARSILIK_TUTARI.VisibleIndex = 45;
            colKARSILIK_TUTARI.FieldName = "KARSILIK_TUTARI";
            colKARSILIK_TUTARI.Name = "colKARSILIK_TUTARI";
            colKARSILIK_TUTARI.Visible = true;

            GridColumn colKARSILIK_TUTARI_DOVIZ_ID = new GridColumn();
            colKARSILIK_TUTARI_DOVIZ_ID.VisibleIndex = 46;
            colKARSILIK_TUTARI_DOVIZ_ID.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Name = "colKARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI = new GridColumn();
            colTUM_MASRAF_TOPLAMI.VisibleIndex = 47;
            colTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Name = "colTUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.VisibleIndex = 48;
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "colTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colHARC_TOPLAMI = new GridColumn();
            colHARC_TOPLAMI.VisibleIndex = 49;
            colHARC_TOPLAMI.FieldName = "HARC_TOPLAMI";
            colHARC_TOPLAMI.Name = "colHARC_TOPLAMI";
            colHARC_TOPLAMI.Visible = true;

            GridColumn colHARC_TOPLAMI_DOVIZ_ID = new GridColumn();
            colHARC_TOPLAMI_DOVIZ_ID.VisibleIndex = 50;
            colHARC_TOPLAMI_DOVIZ_ID.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Name = "colHARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI = new GridColumn();
            colTUM_VEKALET_TOPLAMI.VisibleIndex = 51;
            colTUM_VEKALET_TOPLAMI.FieldName = "TUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Name = "colTUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.VisibleIndex = 52;
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Name = "colTUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT.VisibleIndex = 53;
            colTAKIP_CIKIS_GAYRI_NAKIT.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Name = "colTAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.VisibleIndex = 54;
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Name = "colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN = new GridColumn();
            colGAYRI_NAKIT_KALAN.VisibleIndex = 55;
            colGAYRI_NAKIT_KALAN.FieldName = "GAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Name = "colGAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN_DOVIZ_ID = new GridColumn();
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.VisibleIndex = 56;
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.FieldName = "GAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Name = "colGAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 57;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colSUBE = new GridColumn();
            colSUBE.VisibleIndex = 58;
            colSUBE.FieldName = "SUBE";
            colSUBE.Name = "colSUBE";
            colSUBE.Visible = true;

            GridColumn colFOY_BIRIM = new GridColumn();
            colFOY_BIRIM.VisibleIndex = 59;
            colFOY_BIRIM.FieldName = "FOY_BIRIM";
            colFOY_BIRIM.Name = "colFOY_BIRIM";
            colFOY_BIRIM.Visible = true;

            GridColumn colFOY_YERI = new GridColumn();
            colFOY_YERI.VisibleIndex = 60;
            colFOY_YERI.FieldName = "FOY_YERI";
            colFOY_YERI.Name = "colFOY_YERI";
            colFOY_YERI.Visible = true;

            GridColumn colFOY_OZEL_DURUM = new GridColumn();
            colFOY_OZEL_DURUM.VisibleIndex = 61;
            colFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Name = "colFOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Visible = true;

            GridColumn colTAHSILAT_DURUM = new GridColumn();
            colTAHSILAT_DURUM.VisibleIndex = 62;
            colTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            colTAHSILAT_DURUM.Name = "colTAHSILAT_DURUM";
            colTAHSILAT_DURUM.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 63;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 64;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colKLASOR_1 = new GridColumn();
            colKLASOR_1.VisibleIndex = 65;
            colKLASOR_1.FieldName = "KLASOR_1";
            colKLASOR_1.Name = "colKLASOR_1";
            colKLASOR_1.Visible = true;

            GridColumn colKLASOR_2 = new GridColumn();
            colKLASOR_2.VisibleIndex = 66;
            colKLASOR_2.FieldName = "KLASOR_2";
            colKLASOR_2.Name = "colKLASOR_2";
            colKLASOR_2.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI = new GridColumn();
            colTUM_ODEME_TOPLAMI.VisibleIndex = 67;
            colTUM_ODEME_TOPLAMI.FieldName = "TUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Name = "colTUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 68;
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN.VisibleIndex = 69;
            colVEKALET_UCRETINDEN_ODENEN.FieldName = "VEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Name = "colVEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.VisibleIndex = 70;
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.FieldName = "VEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Name = "colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Visible = true;

            GridColumn colRISKTEN_KALAN = new GridColumn();
            colRISKTEN_KALAN.VisibleIndex = 71;
            colRISKTEN_KALAN.FieldName = "RISKTEN_KALAN";
            colRISKTEN_KALAN.Name = "colRISKTEN_KALAN";
            colRISKTEN_KALAN.Visible = true;

            GridColumn colRISKTEN_KALAN_DOVIZ_ID = new GridColumn();
            colRISKTEN_KALAN_DOVIZ_ID.VisibleIndex = 72;
            colRISKTEN_KALAN_DOVIZ_ID.FieldName = "RISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Name = "colRISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT.VisibleIndex = 73;
            colMASRAFA_YAPILAN_TAHSILAT.FieldName = "MASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Name = "colMASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 74;
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "MASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT.VisibleIndex = 75;
            colANA_PARAYA_YAPILAN_TAHSILAT.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Name = "colANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 76;
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT.VisibleIndex = 77;
            colFAIZE_YAPILAN_TAHSILAT.FieldName = "FAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Name = "colFAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 78;
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "FAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI = new GridColumn();
            colTO_ODEME_TOPLAMI.VisibleIndex = 79;
            colTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Name = "colTO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTO_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 80;
            colTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_NO = new GridColumn();
            colSUBE_NO.VisibleIndex = 81;
            colSUBE_NO.FieldName = "SUBE_NO";
            colSUBE_NO.Name = "colSUBE_NO";
            colSUBE_NO.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 82;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR.VisibleIndex = 83;
            colAVUKATA_ODENEN_MIKTAR.FieldName = "AVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Name = "colAVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 84;
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "AVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR.VisibleIndex = 85;
            colALACAKLIYA_ODENEN_MIKTAR.FieldName = "ALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Name = "colALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 86;
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "ALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR = new GridColumn();
            colSATISTAN_GELEN_MIKTAR.VisibleIndex = 87;
            colSATISTAN_GELEN_MIKTAR.FieldName = "SATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Name = "colSATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.VisibleIndex = 88;
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.FieldName = "SATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Name = "colSATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSEGMENT_ID = new GridColumn();
            colSEGMENT_ID.VisibleIndex = 89;
            colSEGMENT_ID.FieldName = "SEGMENT_ID";
            colSEGMENT_ID.Name = "colSEGMENT_ID";
            colSEGMENT_ID.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 90;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colTAKIP_EDILEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDILEN_TARAF_KOD.VisibleIndex = 91;
            colTAKIP_EDILEN_TARAF_KOD.FieldName = "TAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Name = "colTAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 92;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colTAKIP_EDILEN_SIFAT = new GridColumn();
            colTAKIP_EDILEN_SIFAT.VisibleIndex = 93;
            colTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Name = "colTAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Visible = true;

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 94;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colTAKIP_EDEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDEN_TARAF_KOD.VisibleIndex = 95;
            colTAKIP_EDEN_TARAF_KOD.FieldName = "TAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Name = "colTAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDEN_SIFAT = new GridColumn();
            colTAKIP_EDEN_SIFAT.VisibleIndex = 96;
            colTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Name = "colTAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 97;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 98;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            #endregion Field & Properties

            dizi = new GridColumn[]
		{
           // colID,
            colFOY_NO,
            colDURUM,
			colTAKIP_EDEN,
			colTAKIP_EDEN_TARAF_KOD,
			colTAKIP_EDEN_SIFAT,
			colTAKIP_EDILEN,
			colTAKIP_EDILEN_TARAF_KOD,
			colTAKIP_EDILEN_SIFAT,
			colIZLEYEN,
			colSORUMLU,
			colTAKIP_TARIHI,
			colESAS_NO,
			colTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			colASIL_ALACAK,
			colASIL_ALACAK_DOVIZ_ID,
			colISLEMIS_FAIZ,
			colISLEMIS_FAIZ_DOVIZ_ID,
			colSON_HESAP_TARIHI,
			colTAKIP_CIKISI,
			colTAKIP_CIKISI_DOVIZ_ID,
			colKALAN,
			colKALAN_DOVIZ_ID,
			colRISK_MIKTARI,
			colRISK_MIKTARI_DOVIZ_ID,
			colSUBE_KOD_ID,
			colADLIYE,
			colNO,
			colTAKIP_CIKIS_GAYRI_NAKIT,
			colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID,
			colGAYRI_NAKIT_KALAN,
			colGAYRI_NAKIT_KALAN_DOVIZ_ID,
			colBANKA,
			colSUBE,
			colKREDI_GRUP,
			colKREDI_TIP,
			colKLASOR_1,
			colKLASOR_2,
             colTO_ODEME_TOPLAMI,
            colTO_ODEME_TOPLAMI_DOVIZ_ID,
			};
            return dizi;
        }

        private GridColumn[] DevamEdenDosyalardanAnaparayaYapılanTahsilatlar()
        {
            #region Field & Properties

            GridColumn colAN_REF_NO1 = new GridColumn();
            colAN_REF_NO1.VisibleIndex = 0;
            colAN_REF_NO1.FieldName = "AN_REF_NO1";
            colAN_REF_NO1.Name = "colAN_REF_NO1";
            colAN_REF_NO1.Visible = true;

            GridColumn colAN_REF_NO2 = new GridColumn();
            colAN_REF_NO2.VisibleIndex = 1;
            colAN_REF_NO2.FieldName = "AN_REF_NO2";
            colAN_REF_NO2.Name = "colAN_REF_NO2";
            colAN_REF_NO2.Visible = true;

            GridColumn colAN_REF_NO3 = new GridColumn();
            colAN_REF_NO3.VisibleIndex = 2;
            colAN_REF_NO3.FieldName = "AN_REF_NO3";
            colAN_REF_NO3.Name = "colAN_REF_NO3";
            colAN_REF_NO3.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 3;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colICRA_REF_NO1 = new GridColumn();
            colICRA_REF_NO1.VisibleIndex = 4;
            colICRA_REF_NO1.FieldName = "ICRA_REF_NO1";
            colICRA_REF_NO1.Name = "colICRA_REF_NO1";
            colICRA_REF_NO1.Visible = true;

            GridColumn colICRA_REF_NO2 = new GridColumn();
            colICRA_REF_NO2.VisibleIndex = 5;
            colICRA_REF_NO2.FieldName = "ICRA_REF_NO2";
            colICRA_REF_NO2.Name = "colICRA_REF_NO2";
            colICRA_REF_NO2.Visible = true;

            GridColumn colICRA_REF_NO3 = new GridColumn();
            colICRA_REF_NO3.VisibleIndex = 6;
            colICRA_REF_NO3.FieldName = "ICRA_REF_NO3";
            colICRA_REF_NO3.Name = "colICRA_REF_NO3";
            colICRA_REF_NO3.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 7;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 8;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colTAKIBIN_AVUKATA_INTIKAL_TARIHI = new GridColumn();
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 9;
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "colTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colASIL_ALACAK = new GridColumn();
            colASIL_ALACAK.VisibleIndex = 10;
            colASIL_ALACAK.FieldName = "ASIL_ALACAK";
            colASIL_ALACAK.Name = "colASIL_ALACAK";
            colASIL_ALACAK.Visible = true;

            GridColumn colASIL_ALACAK_DOVIZ_ID = new GridColumn();
            colASIL_ALACAK_DOVIZ_ID.VisibleIndex = 11;
            colASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Name = "colASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Visible = true;

            GridColumn colISLEMIS_FAIZ = new GridColumn();
            colISLEMIS_FAIZ.VisibleIndex = 12;
            colISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Name = "colISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Visible = true;

            GridColumn colISLEMIS_FAIZ_DOVIZ_ID = new GridColumn();
            colISLEMIS_FAIZ_DOVIZ_ID.VisibleIndex = 13;
            colISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Name = "colISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colSON_HESAP_TARIHI = new GridColumn();
            colSON_HESAP_TARIHI.VisibleIndex = 14;
            colSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Name = "colSON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Visible = true;

            GridColumn colTAKIP_CIKISI = new GridColumn();
            colTAKIP_CIKISI.VisibleIndex = 15;
            colTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            colTAKIP_CIKISI.Name = "colTAKIP_CIKISI";
            colTAKIP_CIKISI.Visible = true;

            GridColumn colTAKIP_CIKISI_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKISI_DOVIZ_ID.VisibleIndex = 16;
            colTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Name = "colTAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_TOPLAMI = new GridColumn();
            colODEME_TOPLAMI.VisibleIndex = 17;
            colODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            colODEME_TOPLAMI.Name = "colODEME_TOPLAMI";
            colODEME_TOPLAMI.Visible = true;

            GridColumn colODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 18;
            colODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Name = "colODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN = new GridColumn();
            colKALAN.VisibleIndex = 19;
            colKALAN.FieldName = "KALAN";
            colKALAN.Name = "colKALAN";
            colKALAN.Visible = true;

            GridColumn colKALAN_DOVIZ_ID = new GridColumn();
            colKALAN_DOVIZ_ID.VisibleIndex = 20;
            colKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Name = "colKALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Visible = true;

            GridColumn colKAPAMA_TARIHI = new GridColumn();
            colKAPAMA_TARIHI.VisibleIndex = 21;
            colKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            colKAPAMA_TARIHI.Name = "colKAPAMA_TARIHI";
            colKAPAMA_TARIHI.Visible = true;

            GridColumn colRISK_MIKTARI = new GridColumn();
            colRISK_MIKTARI.VisibleIndex = 22;
            colRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            colRISK_MIKTARI.Name = "colRISK_MIKTARI";
            colRISK_MIKTARI.Visible = true;

            GridColumn colRISK_MIKTARI_DOVIZ_ID = new GridColumn();
            colRISK_MIKTARI_DOVIZ_ID.VisibleIndex = 23;
            colRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Name = "colRISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 24;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 25;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 26;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 27;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 28;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 29;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 30;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 31;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.Visible = true;

            GridColumn colHESAPLAMA_TIPI = new GridColumn();
            colHESAPLAMA_TIPI.VisibleIndex = 32;
            colHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Name = "colHESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Visible = true;

            GridColumn colBIR_YIL_KAC_GUN = new GridColumn();
            colBIR_YIL_KAC_GUN.VisibleIndex = 33;
            colBIR_YIL_KAC_GUN.FieldName = "BIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Name = "colBIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI = new GridColumn();
            colTAKIP_VEKALET_UCRETI.VisibleIndex = 34;
            colTAKIP_VEKALET_UCRETI.FieldName = "TAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Name = "colTAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 35;
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Name = "colTAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colMAHSUP_TOPLAMI = new GridColumn();
            colMAHSUP_TOPLAMI.VisibleIndex = 36;
            colMAHSUP_TOPLAMI.FieldName = "MAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Name = "colMAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Visible = true;

            GridColumn colMAHSUP_TOPLAMI_DOVIZ_ID = new GridColumn();
            colMAHSUP_TOPLAMI_DOVIZ_ID.VisibleIndex = 37;
            colMAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Name = "colMAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colALACAK_TOPLAMI = new GridColumn();
            colALACAK_TOPLAMI.VisibleIndex = 38;
            colALACAK_TOPLAMI.FieldName = "ALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Name = "colALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Visible = true;

            GridColumn colALACAK_TOPLAMI_DOVIZ_ID = new GridColumn();
            colALACAK_TOPLAMI_DOVIZ_ID.VisibleIndex = 39;
            colALACAK_TOPLAMI_DOVIZ_ID.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Name = "colALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colFERAGAT_TOPLAMI = new GridColumn();
            colFERAGAT_TOPLAMI.VisibleIndex = 40;
            colFERAGAT_TOPLAMI.FieldName = "FERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Name = "colFERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Visible = true;

            GridColumn colFERAGAT_TOPLAMI_DOVIZ_ID = new GridColumn();
            colFERAGAT_TOPLAMI_DOVIZ_ID.VisibleIndex = 41;
            colFERAGAT_TOPLAMI_DOVIZ_ID.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Name = "colFERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_MIKTARI = new GridColumn();
            colPROTOKOL_MIKTARI.VisibleIndex = 42;
            colPROTOKOL_MIKTARI.FieldName = "PROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Name = "colPROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Visible = true;

            GridColumn colPROTOKOL_MIKTARI_DOVIZ_ID = new GridColumn();
            colPROTOKOL_MIKTARI_DOVIZ_ID.VisibleIndex = 43;
            colPROTOKOL_MIKTARI_DOVIZ_ID.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Name = "colPROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_TARIHI = new GridColumn();
            colPROTOKOL_TARIHI.VisibleIndex = 44;
            colPROTOKOL_TARIHI.FieldName = "PROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Name = "colPROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Visible = true;

            GridColumn colKARSILIK_TUTARI = new GridColumn();
            colKARSILIK_TUTARI.VisibleIndex = 45;
            colKARSILIK_TUTARI.FieldName = "KARSILIK_TUTARI";
            colKARSILIK_TUTARI.Name = "colKARSILIK_TUTARI";
            colKARSILIK_TUTARI.Visible = true;

            GridColumn colKARSILIK_TUTARI_DOVIZ_ID = new GridColumn();
            colKARSILIK_TUTARI_DOVIZ_ID.VisibleIndex = 46;
            colKARSILIK_TUTARI_DOVIZ_ID.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Name = "colKARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI = new GridColumn();
            colTUM_MASRAF_TOPLAMI.VisibleIndex = 47;
            colTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Name = "colTUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.VisibleIndex = 48;
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "colTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colHARC_TOPLAMI = new GridColumn();
            colHARC_TOPLAMI.VisibleIndex = 49;
            colHARC_TOPLAMI.FieldName = "HARC_TOPLAMI";
            colHARC_TOPLAMI.Name = "colHARC_TOPLAMI";
            colHARC_TOPLAMI.Visible = true;

            GridColumn colHARC_TOPLAMI_DOVIZ_ID = new GridColumn();
            colHARC_TOPLAMI_DOVIZ_ID.VisibleIndex = 50;
            colHARC_TOPLAMI_DOVIZ_ID.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Name = "colHARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI = new GridColumn();
            colTUM_VEKALET_TOPLAMI.VisibleIndex = 51;
            colTUM_VEKALET_TOPLAMI.FieldName = "TUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Name = "colTUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.VisibleIndex = 52;
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Name = "colTUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT.VisibleIndex = 53;
            colTAKIP_CIKIS_GAYRI_NAKIT.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Name = "colTAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.VisibleIndex = 54;
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Name = "colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN = new GridColumn();
            colGAYRI_NAKIT_KALAN.VisibleIndex = 55;
            colGAYRI_NAKIT_KALAN.FieldName = "GAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Name = "colGAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN_DOVIZ_ID = new GridColumn();
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.VisibleIndex = 56;
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.FieldName = "GAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Name = "colGAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 57;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colSUBE = new GridColumn();
            colSUBE.VisibleIndex = 58;
            colSUBE.FieldName = "SUBE";
            colSUBE.Name = "colSUBE";
            colSUBE.Visible = true;

            GridColumn colFOY_BIRIM = new GridColumn();
            colFOY_BIRIM.VisibleIndex = 59;
            colFOY_BIRIM.FieldName = "FOY_BIRIM";
            colFOY_BIRIM.Name = "colFOY_BIRIM";
            colFOY_BIRIM.Visible = true;

            GridColumn colFOY_YERI = new GridColumn();
            colFOY_YERI.VisibleIndex = 60;
            colFOY_YERI.FieldName = "FOY_YERI";
            colFOY_YERI.Name = "colFOY_YERI";
            colFOY_YERI.Visible = true;

            GridColumn colFOY_OZEL_DURUM = new GridColumn();
            colFOY_OZEL_DURUM.VisibleIndex = 61;
            colFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Name = "colFOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Visible = true;

            GridColumn colTAHSILAT_DURUM = new GridColumn();
            colTAHSILAT_DURUM.VisibleIndex = 62;
            colTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            colTAHSILAT_DURUM.Name = "colTAHSILAT_DURUM";
            colTAHSILAT_DURUM.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 63;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 64;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colKLASOR_1 = new GridColumn();
            colKLASOR_1.VisibleIndex = 65;
            colKLASOR_1.FieldName = "KLASOR_1";
            colKLASOR_1.Name = "colKLASOR_1";
            colKLASOR_1.Visible = true;

            GridColumn colKLASOR_2 = new GridColumn();
            colKLASOR_2.VisibleIndex = 66;
            colKLASOR_2.FieldName = "KLASOR_2";
            colKLASOR_2.Name = "colKLASOR_2";
            colKLASOR_2.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI = new GridColumn();
            colTUM_ODEME_TOPLAMI.VisibleIndex = 67;
            colTUM_ODEME_TOPLAMI.FieldName = "TUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Name = "colTUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 68;
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN.VisibleIndex = 69;
            colVEKALET_UCRETINDEN_ODENEN.FieldName = "VEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Name = "colVEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.VisibleIndex = 70;
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.FieldName = "VEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Name = "colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Visible = true;

            GridColumn colRISKTEN_KALAN = new GridColumn();
            colRISKTEN_KALAN.VisibleIndex = 71;
            colRISKTEN_KALAN.FieldName = "RISKTEN_KALAN";
            colRISKTEN_KALAN.Name = "colRISKTEN_KALAN";
            colRISKTEN_KALAN.Visible = true;

            GridColumn colRISKTEN_KALAN_DOVIZ_ID = new GridColumn();
            colRISKTEN_KALAN_DOVIZ_ID.VisibleIndex = 72;
            colRISKTEN_KALAN_DOVIZ_ID.FieldName = "RISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Name = "colRISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT.VisibleIndex = 73;
            colMASRAFA_YAPILAN_TAHSILAT.FieldName = "MASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Name = "colMASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 74;
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "MASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT.VisibleIndex = 75;
            colANA_PARAYA_YAPILAN_TAHSILAT.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Name = "colANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 76;
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT.VisibleIndex = 77;
            colFAIZE_YAPILAN_TAHSILAT.FieldName = "FAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Name = "colFAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 78;
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "FAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI = new GridColumn();
            colTO_ODEME_TOPLAMI.VisibleIndex = 79;
            colTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Name = "colTO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTO_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 80;
            colTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_NO = new GridColumn();
            colSUBE_NO.VisibleIndex = 81;
            colSUBE_NO.FieldName = "SUBE_NO";
            colSUBE_NO.Name = "colSUBE_NO";
            colSUBE_NO.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 82;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR.VisibleIndex = 83;
            colAVUKATA_ODENEN_MIKTAR.FieldName = "AVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Name = "colAVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 84;
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "AVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR.VisibleIndex = 85;
            colALACAKLIYA_ODENEN_MIKTAR.FieldName = "ALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Name = "colALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 86;
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "ALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR = new GridColumn();
            colSATISTAN_GELEN_MIKTAR.VisibleIndex = 87;
            colSATISTAN_GELEN_MIKTAR.FieldName = "SATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Name = "colSATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.VisibleIndex = 88;
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.FieldName = "SATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Name = "colSATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSEGMENT_ID = new GridColumn();
            colSEGMENT_ID.VisibleIndex = 89;
            colSEGMENT_ID.FieldName = "SEGMENT_ID";
            colSEGMENT_ID.Name = "colSEGMENT_ID";
            colSEGMENT_ID.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 90;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colTAKIP_EDILEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDILEN_TARAF_KOD.VisibleIndex = 91;
            colTAKIP_EDILEN_TARAF_KOD.FieldName = "TAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Name = "colTAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 92;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colTAKIP_EDILEN_SIFAT = new GridColumn();
            colTAKIP_EDILEN_SIFAT.VisibleIndex = 93;
            colTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Name = "colTAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Visible = true;

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 94;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colTAKIP_EDEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDEN_TARAF_KOD.VisibleIndex = 95;
            colTAKIP_EDEN_TARAF_KOD.FieldName = "TAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Name = "colTAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDEN_SIFAT = new GridColumn();
            colTAKIP_EDEN_SIFAT.VisibleIndex = 96;
            colTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Name = "colTAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 97;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 98;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            #endregion Field & Properties

            dizi = new GridColumn[]
		{
            //colID,
            colFOY_NO,
            colDURUM,
			colTAKIP_EDEN,
			colTAKIP_EDEN_TARAF_KOD,
			colTAKIP_EDEN_SIFAT,
			colTAKIP_EDILEN,
			colTAKIP_EDILEN_TARAF_KOD,
			colTAKIP_EDILEN_SIFAT,
			colIZLEYEN,
			colSORUMLU,
			colTAKIP_TARIHI,
			colESAS_NO,
			colTAKIBIN_AVUKATA_INTIKAL_TARIHI,

            //colASIL_ALACAK,
            //colASIL_ALACAK_DOVIZ_ID,
            //colISLEMIS_FAIZ,
            //colISLEMIS_FAIZ_DOVIZ_ID,
            //colSON_HESAP_TARIHI,
            //colTAKIP_CIKISI,
            //colTAKIP_CIKISI_DOVIZ_ID,
            //colKALAN,
            //colKALAN_DOVIZ_ID,
            //colRISK_MIKTARI,
            //colRISK_MIKTARI_DOVIZ_ID,
            //colSUBE_KOD_ID,
            //colADLIYE,
            //colNO,
            //colTAKIP_CIKIS_GAYRI_NAKIT,
            //colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID,
            //colGAYRI_NAKIT_KALAN,
            //colGAYRI_NAKIT_KALAN_DOVIZ_ID,
			colBANKA,
			colSUBE,
			colKREDI_GRUP,
			colKREDI_TIP,
			colKLASOR_1,
			colKLASOR_2,
            colANA_PARAYA_YAPILAN_TAHSILAT,
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID,
			colFAIZE_YAPILAN_TAHSILAT,
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID,
             colTO_ODEME_TOPLAMI,
            colTO_ODEME_TOPLAMI_DOVIZ_ID,
			};
            return dizi;
        }

        private GridColumn[] DevreTahsilat()
        {
            #region Field & Properties

            GridColumn colAN_REF_NO1 = new GridColumn();
            colAN_REF_NO1.VisibleIndex = 0;
            colAN_REF_NO1.FieldName = "AN_REF_NO1";
            colAN_REF_NO1.Name = "colAN_REF_NO1";
            colAN_REF_NO1.Visible = true;

            GridColumn colAN_REF_NO2 = new GridColumn();
            colAN_REF_NO2.VisibleIndex = 1;
            colAN_REF_NO2.FieldName = "AN_REF_NO2";
            colAN_REF_NO2.Name = "colAN_REF_NO2";
            colAN_REF_NO2.Visible = true;

            GridColumn colAN_REF_NO3 = new GridColumn();
            colAN_REF_NO3.VisibleIndex = 2;
            colAN_REF_NO3.FieldName = "AN_REF_NO3";
            colAN_REF_NO3.Name = "colAN_REF_NO3";
            colAN_REF_NO3.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 3;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colICRA_REF_NO1 = new GridColumn();
            colICRA_REF_NO1.VisibleIndex = 4;
            colICRA_REF_NO1.FieldName = "ICRA_REF_NO1";
            colICRA_REF_NO1.Name = "colICRA_REF_NO1";
            colICRA_REF_NO1.Visible = true;

            GridColumn colICRA_REF_NO2 = new GridColumn();
            colICRA_REF_NO2.VisibleIndex = 5;
            colICRA_REF_NO2.FieldName = "ICRA_REF_NO2";
            colICRA_REF_NO2.Name = "colICRA_REF_NO2";
            colICRA_REF_NO2.Visible = true;

            GridColumn colICRA_REF_NO3 = new GridColumn();
            colICRA_REF_NO3.VisibleIndex = 6;
            colICRA_REF_NO3.FieldName = "ICRA_REF_NO3";
            colICRA_REF_NO3.Name = "colICRA_REF_NO3";
            colICRA_REF_NO3.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 7;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 8;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colTAKIBIN_AVUKATA_INTIKAL_TARIHI = new GridColumn();
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 9;
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "colTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colASIL_ALACAK = new GridColumn();
            colASIL_ALACAK.VisibleIndex = 10;
            colASIL_ALACAK.FieldName = "ASIL_ALACAK";
            colASIL_ALACAK.Name = "colASIL_ALACAK";
            colASIL_ALACAK.Visible = true;

            GridColumn colASIL_ALACAK_DOVIZ_ID = new GridColumn();
            colASIL_ALACAK_DOVIZ_ID.VisibleIndex = 11;
            colASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Name = "colASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Visible = true;

            GridColumn colISLEMIS_FAIZ = new GridColumn();
            colISLEMIS_FAIZ.VisibleIndex = 12;
            colISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Name = "colISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Visible = true;

            GridColumn colISLEMIS_FAIZ_DOVIZ_ID = new GridColumn();
            colISLEMIS_FAIZ_DOVIZ_ID.VisibleIndex = 13;
            colISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Name = "colISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colSON_HESAP_TARIHI = new GridColumn();
            colSON_HESAP_TARIHI.VisibleIndex = 14;
            colSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Name = "colSON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Visible = true;

            GridColumn colTAKIP_CIKISI = new GridColumn();
            colTAKIP_CIKISI.VisibleIndex = 15;
            colTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            colTAKIP_CIKISI.Name = "colTAKIP_CIKISI";
            colTAKIP_CIKISI.Visible = true;

            GridColumn colTAKIP_CIKISI_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKISI_DOVIZ_ID.VisibleIndex = 16;
            colTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Name = "colTAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_TOPLAMI = new GridColumn();
            colODEME_TOPLAMI.VisibleIndex = 17;
            colODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            colODEME_TOPLAMI.Name = "colODEME_TOPLAMI";
            colODEME_TOPLAMI.Visible = true;

            GridColumn colODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 18;
            colODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Name = "colODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN = new GridColumn();
            colKALAN.VisibleIndex = 19;
            colKALAN.FieldName = "KALAN";
            colKALAN.Name = "colKALAN";
            colKALAN.Visible = true;

            GridColumn colKALAN_DOVIZ_ID = new GridColumn();
            colKALAN_DOVIZ_ID.VisibleIndex = 20;
            colKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Name = "colKALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Visible = true;

            GridColumn colKAPAMA_TARIHI = new GridColumn();
            colKAPAMA_TARIHI.VisibleIndex = 21;
            colKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            colKAPAMA_TARIHI.Name = "colKAPAMA_TARIHI";
            colKAPAMA_TARIHI.Visible = true;

            GridColumn colRISK_MIKTARI = new GridColumn();
            colRISK_MIKTARI.VisibleIndex = 22;
            colRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            colRISK_MIKTARI.Name = "colRISK_MIKTARI";
            colRISK_MIKTARI.Visible = true;

            GridColumn colRISK_MIKTARI_DOVIZ_ID = new GridColumn();
            colRISK_MIKTARI_DOVIZ_ID.VisibleIndex = 23;
            colRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Name = "colRISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 24;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 25;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 26;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 27;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 28;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 29;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 30;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 31;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.Visible = true;

            GridColumn colHESAPLAMA_TIPI = new GridColumn();
            colHESAPLAMA_TIPI.VisibleIndex = 32;
            colHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Name = "colHESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Visible = true;

            GridColumn colBIR_YIL_KAC_GUN = new GridColumn();
            colBIR_YIL_KAC_GUN.VisibleIndex = 33;
            colBIR_YIL_KAC_GUN.FieldName = "BIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Name = "colBIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI = new GridColumn();
            colTAKIP_VEKALET_UCRETI.VisibleIndex = 34;
            colTAKIP_VEKALET_UCRETI.FieldName = "TAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Name = "colTAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 35;
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Name = "colTAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colMAHSUP_TOPLAMI = new GridColumn();
            colMAHSUP_TOPLAMI.VisibleIndex = 36;
            colMAHSUP_TOPLAMI.FieldName = "MAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Name = "colMAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Visible = true;

            GridColumn colMAHSUP_TOPLAMI_DOVIZ_ID = new GridColumn();
            colMAHSUP_TOPLAMI_DOVIZ_ID.VisibleIndex = 37;
            colMAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Name = "colMAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colALACAK_TOPLAMI = new GridColumn();
            colALACAK_TOPLAMI.VisibleIndex = 38;
            colALACAK_TOPLAMI.FieldName = "ALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Name = "colALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Visible = true;

            GridColumn colALACAK_TOPLAMI_DOVIZ_ID = new GridColumn();
            colALACAK_TOPLAMI_DOVIZ_ID.VisibleIndex = 39;
            colALACAK_TOPLAMI_DOVIZ_ID.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Name = "colALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colFERAGAT_TOPLAMI = new GridColumn();
            colFERAGAT_TOPLAMI.VisibleIndex = 40;
            colFERAGAT_TOPLAMI.FieldName = "FERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Name = "colFERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Visible = true;

            GridColumn colFERAGAT_TOPLAMI_DOVIZ_ID = new GridColumn();
            colFERAGAT_TOPLAMI_DOVIZ_ID.VisibleIndex = 41;
            colFERAGAT_TOPLAMI_DOVIZ_ID.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Name = "colFERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_MIKTARI = new GridColumn();
            colPROTOKOL_MIKTARI.VisibleIndex = 42;
            colPROTOKOL_MIKTARI.FieldName = "PROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Name = "colPROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Visible = true;

            GridColumn colPROTOKOL_MIKTARI_DOVIZ_ID = new GridColumn();
            colPROTOKOL_MIKTARI_DOVIZ_ID.VisibleIndex = 43;
            colPROTOKOL_MIKTARI_DOVIZ_ID.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Name = "colPROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_TARIHI = new GridColumn();
            colPROTOKOL_TARIHI.VisibleIndex = 44;
            colPROTOKOL_TARIHI.FieldName = "PROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Name = "colPROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Visible = true;

            GridColumn colKARSILIK_TUTARI = new GridColumn();
            colKARSILIK_TUTARI.VisibleIndex = 45;
            colKARSILIK_TUTARI.FieldName = "KARSILIK_TUTARI";
            colKARSILIK_TUTARI.Name = "colKARSILIK_TUTARI";
            colKARSILIK_TUTARI.Visible = true;

            GridColumn colKARSILIK_TUTARI_DOVIZ_ID = new GridColumn();
            colKARSILIK_TUTARI_DOVIZ_ID.VisibleIndex = 46;
            colKARSILIK_TUTARI_DOVIZ_ID.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Name = "colKARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI = new GridColumn();
            colTUM_MASRAF_TOPLAMI.VisibleIndex = 47;
            colTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Name = "colTUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.VisibleIndex = 48;
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "colTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colHARC_TOPLAMI = new GridColumn();
            colHARC_TOPLAMI.VisibleIndex = 49;
            colHARC_TOPLAMI.FieldName = "HARC_TOPLAMI";
            colHARC_TOPLAMI.Name = "colHARC_TOPLAMI";
            colHARC_TOPLAMI.Visible = true;

            GridColumn colHARC_TOPLAMI_DOVIZ_ID = new GridColumn();
            colHARC_TOPLAMI_DOVIZ_ID.VisibleIndex = 50;
            colHARC_TOPLAMI_DOVIZ_ID.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Name = "colHARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI = new GridColumn();
            colTUM_VEKALET_TOPLAMI.VisibleIndex = 51;
            colTUM_VEKALET_TOPLAMI.FieldName = "TUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Name = "colTUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.VisibleIndex = 52;
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Name = "colTUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT.VisibleIndex = 53;
            colTAKIP_CIKIS_GAYRI_NAKIT.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Name = "colTAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.VisibleIndex = 54;
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Name = "colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN = new GridColumn();
            colGAYRI_NAKIT_KALAN.VisibleIndex = 55;
            colGAYRI_NAKIT_KALAN.FieldName = "GAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Name = "colGAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN_DOVIZ_ID = new GridColumn();
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.VisibleIndex = 56;
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.FieldName = "GAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Name = "colGAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 57;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colSUBE = new GridColumn();
            colSUBE.VisibleIndex = 58;
            colSUBE.FieldName = "SUBE";
            colSUBE.Name = "colSUBE";
            colSUBE.Visible = true;

            GridColumn colFOY_BIRIM = new GridColumn();
            colFOY_BIRIM.VisibleIndex = 59;
            colFOY_BIRIM.FieldName = "FOY_BIRIM";
            colFOY_BIRIM.Name = "colFOY_BIRIM";
            colFOY_BIRIM.Visible = true;

            GridColumn colFOY_YERI = new GridColumn();
            colFOY_YERI.VisibleIndex = 60;
            colFOY_YERI.FieldName = "FOY_YERI";
            colFOY_YERI.Name = "colFOY_YERI";
            colFOY_YERI.Visible = true;

            GridColumn colFOY_OZEL_DURUM = new GridColumn();
            colFOY_OZEL_DURUM.VisibleIndex = 61;
            colFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Name = "colFOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Visible = true;

            GridColumn colTAHSILAT_DURUM = new GridColumn();
            colTAHSILAT_DURUM.VisibleIndex = 62;
            colTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            colTAHSILAT_DURUM.Name = "colTAHSILAT_DURUM";
            colTAHSILAT_DURUM.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 63;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 64;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colKLASOR_1 = new GridColumn();
            colKLASOR_1.VisibleIndex = 65;
            colKLASOR_1.FieldName = "KLASOR_1";
            colKLASOR_1.Name = "colKLASOR_1";
            colKLASOR_1.Visible = true;

            GridColumn colKLASOR_2 = new GridColumn();
            colKLASOR_2.VisibleIndex = 66;
            colKLASOR_2.FieldName = "KLASOR_2";
            colKLASOR_2.Name = "colKLASOR_2";
            colKLASOR_2.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI = new GridColumn();
            colTUM_ODEME_TOPLAMI.VisibleIndex = 67;
            colTUM_ODEME_TOPLAMI.FieldName = "TUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Name = "colTUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 68;
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN.VisibleIndex = 69;
            colVEKALET_UCRETINDEN_ODENEN.FieldName = "VEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Name = "colVEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.VisibleIndex = 70;
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.FieldName = "VEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Name = "colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Visible = true;

            GridColumn colRISKTEN_KALAN = new GridColumn();
            colRISKTEN_KALAN.VisibleIndex = 71;
            colRISKTEN_KALAN.FieldName = "RISKTEN_KALAN";
            colRISKTEN_KALAN.Name = "colRISKTEN_KALAN";
            colRISKTEN_KALAN.Visible = true;

            GridColumn colRISKTEN_KALAN_DOVIZ_ID = new GridColumn();
            colRISKTEN_KALAN_DOVIZ_ID.VisibleIndex = 72;
            colRISKTEN_KALAN_DOVIZ_ID.FieldName = "RISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Name = "colRISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT.VisibleIndex = 73;
            colMASRAFA_YAPILAN_TAHSILAT.FieldName = "MASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Name = "colMASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 74;
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "MASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT.VisibleIndex = 75;
            colANA_PARAYA_YAPILAN_TAHSILAT.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Name = "colANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 76;
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT.VisibleIndex = 77;
            colFAIZE_YAPILAN_TAHSILAT.FieldName = "FAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Name = "colFAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 78;
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "FAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI = new GridColumn();
            colTO_ODEME_TOPLAMI.VisibleIndex = 79;
            colTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Name = "colTO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTO_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 80;
            colTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_NO = new GridColumn();
            colSUBE_NO.VisibleIndex = 81;
            colSUBE_NO.FieldName = "SUBE_NO";
            colSUBE_NO.Name = "colSUBE_NO";
            colSUBE_NO.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 82;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR.VisibleIndex = 83;
            colAVUKATA_ODENEN_MIKTAR.FieldName = "AVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Name = "colAVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 84;
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "AVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR.VisibleIndex = 85;
            colALACAKLIYA_ODENEN_MIKTAR.FieldName = "ALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Name = "colALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 86;
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "ALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR = new GridColumn();
            colSATISTAN_GELEN_MIKTAR.VisibleIndex = 87;
            colSATISTAN_GELEN_MIKTAR.FieldName = "SATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Name = "colSATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.VisibleIndex = 88;
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.FieldName = "SATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Name = "colSATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSEGMENT_ID = new GridColumn();
            colSEGMENT_ID.VisibleIndex = 89;
            colSEGMENT_ID.FieldName = "SEGMENT_ID";
            colSEGMENT_ID.Name = "colSEGMENT_ID";
            colSEGMENT_ID.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 90;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colTAKIP_EDILEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDILEN_TARAF_KOD.VisibleIndex = 91;
            colTAKIP_EDILEN_TARAF_KOD.FieldName = "TAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Name = "colTAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 92;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colTAKIP_EDILEN_SIFAT = new GridColumn();
            colTAKIP_EDILEN_SIFAT.VisibleIndex = 93;
            colTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Name = "colTAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Visible = true;

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 94;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colTAKIP_EDEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDEN_TARAF_KOD.VisibleIndex = 95;
            colTAKIP_EDEN_TARAF_KOD.FieldName = "TAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Name = "colTAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDEN_SIFAT = new GridColumn();
            colTAKIP_EDEN_SIFAT.VisibleIndex = 96;
            colTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Name = "colTAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 97;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 98;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            #endregion Field & Properties

            dizi = new GridColumn[]
		{
			colFOY_NO,
            colESAS_NO,
            colDURUM,
			colADLIYE,
			colNO,
            colTAKIP_TARIHI,
			colTAKIP_EDEN,
			colTAKIP_EDILEN,
			colIZLEYEN,
			colSORUMLU,
			colTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			colASIL_ALACAK,
			colASIL_ALACAK_DOVIZ_ID,
			colISLEMIS_FAIZ,
			colISLEMIS_FAIZ_DOVIZ_ID,
			colTAKIP_CIKISI,
			colTAKIP_CIKISI_DOVIZ_ID,
			colODEME_TOPLAMI,
			colODEME_TOPLAMI_DOVIZ_ID,
			colKALAN,
			colKALAN_DOVIZ_ID,
			colRISK_MIKTARI,
			colRISK_MIKTARI_DOVIZ_ID,
			colSUBE_KOD_ID,
			colSUBE,
            colSUBE_NO,
			colFOY_BIRIM,
			colFOY_YERI,
			colRISKTEN_KALAN,
			colRISKTEN_KALAN_DOVIZ_ID,
			};
            return dizi;
        }

        private GridColumn[] DevreTahsilatIcmal()
        {
            #region Field & Properties

            GridColumn colAN_REF_NO1 = new GridColumn();
            colAN_REF_NO1.VisibleIndex = 0;
            colAN_REF_NO1.FieldName = "AN_REF_NO1";
            colAN_REF_NO1.Name = "colAN_REF_NO1";
            colAN_REF_NO1.Visible = true;

            GridColumn colAN_REF_NO2 = new GridColumn();
            colAN_REF_NO2.VisibleIndex = 1;
            colAN_REF_NO2.FieldName = "AN_REF_NO2";
            colAN_REF_NO2.Name = "colAN_REF_NO2";
            colAN_REF_NO2.Visible = true;

            GridColumn colAN_REF_NO3 = new GridColumn();
            colAN_REF_NO3.VisibleIndex = 2;
            colAN_REF_NO3.FieldName = "AN_REF_NO3";
            colAN_REF_NO3.Name = "colAN_REF_NO3";
            colAN_REF_NO3.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 3;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colICRA_REF_NO1 = new GridColumn();
            colICRA_REF_NO1.VisibleIndex = 4;
            colICRA_REF_NO1.FieldName = "ICRA_REF_NO1";
            colICRA_REF_NO1.Name = "colICRA_REF_NO1";
            colICRA_REF_NO1.Visible = true;

            GridColumn colICRA_REF_NO2 = new GridColumn();
            colICRA_REF_NO2.VisibleIndex = 5;
            colICRA_REF_NO2.FieldName = "ICRA_REF_NO2";
            colICRA_REF_NO2.Name = "colICRA_REF_NO2";
            colICRA_REF_NO2.Visible = true;

            GridColumn colICRA_REF_NO3 = new GridColumn();
            colICRA_REF_NO3.VisibleIndex = 6;
            colICRA_REF_NO3.FieldName = "ICRA_REF_NO3";
            colICRA_REF_NO3.Name = "colICRA_REF_NO3";
            colICRA_REF_NO3.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 7;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 8;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colTAKIBIN_AVUKATA_INTIKAL_TARIHI = new GridColumn();
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 9;
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "colTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colASIL_ALACAK = new GridColumn();
            colASIL_ALACAK.VisibleIndex = 10;
            colASIL_ALACAK.FieldName = "ASIL_ALACAK";
            colASIL_ALACAK.Name = "colASIL_ALACAK";
            colASIL_ALACAK.Visible = true;

            GridColumn colASIL_ALACAK_DOVIZ_ID = new GridColumn();
            colASIL_ALACAK_DOVIZ_ID.VisibleIndex = 11;
            colASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Name = "colASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Visible = true;

            GridColumn colISLEMIS_FAIZ = new GridColumn();
            colISLEMIS_FAIZ.VisibleIndex = 12;
            colISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Name = "colISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Visible = true;

            GridColumn colISLEMIS_FAIZ_DOVIZ_ID = new GridColumn();
            colISLEMIS_FAIZ_DOVIZ_ID.VisibleIndex = 13;
            colISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Name = "colISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colSON_HESAP_TARIHI = new GridColumn();
            colSON_HESAP_TARIHI.VisibleIndex = 14;
            colSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Name = "colSON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Visible = true;

            GridColumn colTAKIP_CIKISI = new GridColumn();
            colTAKIP_CIKISI.VisibleIndex = 15;
            colTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            colTAKIP_CIKISI.Name = "colTAKIP_CIKISI";
            colTAKIP_CIKISI.Visible = true;

            GridColumn colTAKIP_CIKISI_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKISI_DOVIZ_ID.VisibleIndex = 16;
            colTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Name = "colTAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_TOPLAMI = new GridColumn();
            colODEME_TOPLAMI.VisibleIndex = 17;
            colODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            colODEME_TOPLAMI.Name = "colODEME_TOPLAMI";
            colODEME_TOPLAMI.Visible = true;

            GridColumn colODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 18;
            colODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Name = "colODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN = new GridColumn();
            colKALAN.VisibleIndex = 19;
            colKALAN.FieldName = "KALAN";
            colKALAN.Name = "colKALAN";
            colKALAN.Visible = true;

            GridColumn colKALAN_DOVIZ_ID = new GridColumn();
            colKALAN_DOVIZ_ID.VisibleIndex = 20;
            colKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Name = "colKALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Visible = true;

            GridColumn colKAPAMA_TARIHI = new GridColumn();
            colKAPAMA_TARIHI.VisibleIndex = 21;
            colKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            colKAPAMA_TARIHI.Name = "colKAPAMA_TARIHI";
            colKAPAMA_TARIHI.Visible = true;

            GridColumn colRISK_MIKTARI = new GridColumn();
            colRISK_MIKTARI.VisibleIndex = 22;
            colRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            colRISK_MIKTARI.Name = "colRISK_MIKTARI";
            colRISK_MIKTARI.Visible = true;

            GridColumn colRISK_MIKTARI_DOVIZ_ID = new GridColumn();
            colRISK_MIKTARI_DOVIZ_ID.VisibleIndex = 23;
            colRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Name = "colRISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 24;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 25;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 26;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 27;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 28;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 29;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 30;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 31;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.Visible = true;

            GridColumn colHESAPLAMA_TIPI = new GridColumn();
            colHESAPLAMA_TIPI.VisibleIndex = 32;
            colHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Name = "colHESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Visible = true;

            GridColumn colBIR_YIL_KAC_GUN = new GridColumn();
            colBIR_YIL_KAC_GUN.VisibleIndex = 33;
            colBIR_YIL_KAC_GUN.FieldName = "BIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Name = "colBIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI = new GridColumn();
            colTAKIP_VEKALET_UCRETI.VisibleIndex = 34;
            colTAKIP_VEKALET_UCRETI.FieldName = "TAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Name = "colTAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 35;
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Name = "colTAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colMAHSUP_TOPLAMI = new GridColumn();
            colMAHSUP_TOPLAMI.VisibleIndex = 36;
            colMAHSUP_TOPLAMI.FieldName = "MAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Name = "colMAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Visible = true;

            GridColumn colMAHSUP_TOPLAMI_DOVIZ_ID = new GridColumn();
            colMAHSUP_TOPLAMI_DOVIZ_ID.VisibleIndex = 37;
            colMAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Name = "colMAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colALACAK_TOPLAMI = new GridColumn();
            colALACAK_TOPLAMI.VisibleIndex = 38;
            colALACAK_TOPLAMI.FieldName = "ALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Name = "colALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Visible = true;

            GridColumn colALACAK_TOPLAMI_DOVIZ_ID = new GridColumn();
            colALACAK_TOPLAMI_DOVIZ_ID.VisibleIndex = 39;
            colALACAK_TOPLAMI_DOVIZ_ID.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Name = "colALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colFERAGAT_TOPLAMI = new GridColumn();
            colFERAGAT_TOPLAMI.VisibleIndex = 40;
            colFERAGAT_TOPLAMI.FieldName = "FERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Name = "colFERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Visible = true;

            GridColumn colFERAGAT_TOPLAMI_DOVIZ_ID = new GridColumn();
            colFERAGAT_TOPLAMI_DOVIZ_ID.VisibleIndex = 41;
            colFERAGAT_TOPLAMI_DOVIZ_ID.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Name = "colFERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_MIKTARI = new GridColumn();
            colPROTOKOL_MIKTARI.VisibleIndex = 42;
            colPROTOKOL_MIKTARI.FieldName = "PROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Name = "colPROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Visible = true;

            GridColumn colPROTOKOL_MIKTARI_DOVIZ_ID = new GridColumn();
            colPROTOKOL_MIKTARI_DOVIZ_ID.VisibleIndex = 43;
            colPROTOKOL_MIKTARI_DOVIZ_ID.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Name = "colPROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_TARIHI = new GridColumn();
            colPROTOKOL_TARIHI.VisibleIndex = 44;
            colPROTOKOL_TARIHI.FieldName = "PROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Name = "colPROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Visible = true;

            GridColumn colKARSILIK_TUTARI = new GridColumn();
            colKARSILIK_TUTARI.VisibleIndex = 45;
            colKARSILIK_TUTARI.FieldName = "KARSILIK_TUTARI";
            colKARSILIK_TUTARI.Name = "colKARSILIK_TUTARI";
            colKARSILIK_TUTARI.Visible = true;

            GridColumn colKARSILIK_TUTARI_DOVIZ_ID = new GridColumn();
            colKARSILIK_TUTARI_DOVIZ_ID.VisibleIndex = 46;
            colKARSILIK_TUTARI_DOVIZ_ID.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Name = "colKARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI = new GridColumn();
            colTUM_MASRAF_TOPLAMI.VisibleIndex = 47;
            colTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Name = "colTUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.VisibleIndex = 48;
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "colTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colHARC_TOPLAMI = new GridColumn();
            colHARC_TOPLAMI.VisibleIndex = 49;
            colHARC_TOPLAMI.FieldName = "HARC_TOPLAMI";
            colHARC_TOPLAMI.Name = "colHARC_TOPLAMI";
            colHARC_TOPLAMI.Visible = true;

            GridColumn colHARC_TOPLAMI_DOVIZ_ID = new GridColumn();
            colHARC_TOPLAMI_DOVIZ_ID.VisibleIndex = 50;
            colHARC_TOPLAMI_DOVIZ_ID.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Name = "colHARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI = new GridColumn();
            colTUM_VEKALET_TOPLAMI.VisibleIndex = 51;
            colTUM_VEKALET_TOPLAMI.FieldName = "TUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Name = "colTUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.VisibleIndex = 52;
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Name = "colTUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT.VisibleIndex = 53;
            colTAKIP_CIKIS_GAYRI_NAKIT.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Name = "colTAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.VisibleIndex = 54;
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Name = "colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN = new GridColumn();
            colGAYRI_NAKIT_KALAN.VisibleIndex = 55;
            colGAYRI_NAKIT_KALAN.FieldName = "GAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Name = "colGAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN_DOVIZ_ID = new GridColumn();
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.VisibleIndex = 56;
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.FieldName = "GAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Name = "colGAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 57;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colSUBE = new GridColumn();
            colSUBE.VisibleIndex = 58;
            colSUBE.FieldName = "SUBE";
            colSUBE.Name = "colSUBE";
            colSUBE.Visible = true;

            GridColumn colFOY_BIRIM = new GridColumn();
            colFOY_BIRIM.VisibleIndex = 59;
            colFOY_BIRIM.FieldName = "FOY_BIRIM";
            colFOY_BIRIM.Name = "colFOY_BIRIM";
            colFOY_BIRIM.Visible = true;

            GridColumn colFOY_YERI = new GridColumn();
            colFOY_YERI.VisibleIndex = 60;
            colFOY_YERI.FieldName = "FOY_YERI";
            colFOY_YERI.Name = "colFOY_YERI";
            colFOY_YERI.Visible = true;

            GridColumn colFOY_OZEL_DURUM = new GridColumn();
            colFOY_OZEL_DURUM.VisibleIndex = 61;
            colFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Name = "colFOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Visible = true;

            GridColumn colTAHSILAT_DURUM = new GridColumn();
            colTAHSILAT_DURUM.VisibleIndex = 62;
            colTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            colTAHSILAT_DURUM.Name = "colTAHSILAT_DURUM";
            colTAHSILAT_DURUM.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 63;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 64;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colKLASOR_1 = new GridColumn();
            colKLASOR_1.VisibleIndex = 65;
            colKLASOR_1.FieldName = "KLASOR_1";
            colKLASOR_1.Name = "colKLASOR_1";
            colKLASOR_1.Visible = true;

            GridColumn colKLASOR_2 = new GridColumn();
            colKLASOR_2.VisibleIndex = 66;
            colKLASOR_2.FieldName = "KLASOR_2";
            colKLASOR_2.Name = "colKLASOR_2";
            colKLASOR_2.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI = new GridColumn();
            colTUM_ODEME_TOPLAMI.VisibleIndex = 67;
            colTUM_ODEME_TOPLAMI.FieldName = "TUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Name = "colTUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 68;
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN.VisibleIndex = 69;
            colVEKALET_UCRETINDEN_ODENEN.FieldName = "VEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Name = "colVEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.VisibleIndex = 70;
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.FieldName = "VEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Name = "colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Visible = true;

            GridColumn colRISKTEN_KALAN = new GridColumn();
            colRISKTEN_KALAN.VisibleIndex = 71;
            colRISKTEN_KALAN.FieldName = "RISKTEN_KALAN";
            colRISKTEN_KALAN.Name = "colRISKTEN_KALAN";
            colRISKTEN_KALAN.Visible = true;

            GridColumn colRISKTEN_KALAN_DOVIZ_ID = new GridColumn();
            colRISKTEN_KALAN_DOVIZ_ID.VisibleIndex = 72;
            colRISKTEN_KALAN_DOVIZ_ID.FieldName = "RISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Name = "colRISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT.VisibleIndex = 73;
            colMASRAFA_YAPILAN_TAHSILAT.FieldName = "MASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Name = "colMASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 74;
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "MASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT.VisibleIndex = 75;
            colANA_PARAYA_YAPILAN_TAHSILAT.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Name = "colANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 76;
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT.VisibleIndex = 77;
            colFAIZE_YAPILAN_TAHSILAT.FieldName = "FAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Name = "colFAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 78;
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "FAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI = new GridColumn();
            colTO_ODEME_TOPLAMI.VisibleIndex = 79;
            colTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Name = "colTO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTO_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 80;
            colTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_NO = new GridColumn();
            colSUBE_NO.VisibleIndex = 81;
            colSUBE_NO.FieldName = "SUBE_NO";
            colSUBE_NO.Name = "colSUBE_NO";
            colSUBE_NO.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 82;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR.VisibleIndex = 83;
            colAVUKATA_ODENEN_MIKTAR.FieldName = "AVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Name = "colAVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 84;
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "AVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR.VisibleIndex = 85;
            colALACAKLIYA_ODENEN_MIKTAR.FieldName = "ALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Name = "colALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 86;
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "ALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR = new GridColumn();
            colSATISTAN_GELEN_MIKTAR.VisibleIndex = 87;
            colSATISTAN_GELEN_MIKTAR.FieldName = "SATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Name = "colSATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.VisibleIndex = 88;
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.FieldName = "SATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Name = "colSATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSEGMENT_ID = new GridColumn();
            colSEGMENT_ID.VisibleIndex = 89;
            colSEGMENT_ID.FieldName = "SEGMENT_ID";
            colSEGMENT_ID.Name = "colSEGMENT_ID";
            colSEGMENT_ID.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 90;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colTAKIP_EDILEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDILEN_TARAF_KOD.VisibleIndex = 91;
            colTAKIP_EDILEN_TARAF_KOD.FieldName = "TAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Name = "colTAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 92;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colTAKIP_EDILEN_SIFAT = new GridColumn();
            colTAKIP_EDILEN_SIFAT.VisibleIndex = 93;
            colTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Name = "colTAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Visible = true;

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 94;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colTAKIP_EDEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDEN_TARAF_KOD.VisibleIndex = 95;
            colTAKIP_EDEN_TARAF_KOD.FieldName = "TAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Name = "colTAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDEN_SIFAT = new GridColumn();
            colTAKIP_EDEN_SIFAT.VisibleIndex = 96;
            colTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Name = "colTAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 97;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 98;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            #endregion Field & Properties

            dizi = new GridColumn[]
		{
			colFOY_NO,
            colESAS_NO,
            colDURUM,
			colADLIYE,
			colNO,
            colTAKIP_TARIHI,
			colTAKIP_EDEN,
			colTAKIP_EDILEN,
			colIZLEYEN,
			colSORUMLU,
			colTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			colASIL_ALACAK,
			colASIL_ALACAK_DOVIZ_ID,
			colISLEMIS_FAIZ,
			colISLEMIS_FAIZ_DOVIZ_ID,
			colTAKIP_CIKISI,
			colTAKIP_CIKISI_DOVIZ_ID,
			colODEME_TOPLAMI,
			colODEME_TOPLAMI_DOVIZ_ID,
			colKALAN,
			colKALAN_DOVIZ_ID,
			colRISK_MIKTARI,
			colRISK_MIKTARI_DOVIZ_ID,
			colSUBE_KOD_ID,
			colSUBE,
            colSUBE_NO,
			colFOY_BIRIM,
			colFOY_YERI,
			colRISKTEN_KALAN,
			colRISKTEN_KALAN_DOVIZ_ID,
             colAN_REF_NO3,
			};
            return dizi;
        }

        private Dictionary<string, string> GetCaptionDictinory()
        {
            Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

            #region Özelleştirme

            string RefNo, RefNo2, refNo3, OzelKod1, OzelKod2, OzelKod3, OzelKod4, ANRefNo, ANRefNo2, ANRefNo3;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraReferans.Referans1))
                RefNo = "Ref No";
            else
                RefNo = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraReferans.Referans1;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraReferans.Referans2))
                RefNo2 = "Ref No2";
            else
                RefNo2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraReferans.Referans2;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraReferans.Referans3))
                refNo3 = "Ref No3";
            else
                refNo3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraReferans.Referans3;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod1))
                OzelKod1 = "Özel Kod1";
            else
                OzelKod1 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod1;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod2))
                OzelKod2 = "Özel Kod2";
            else
                OzelKod2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod2;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod3))
                OzelKod3 = "Özel Kod3";
            else
                OzelKod3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod3;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod4))
                OzelKod4 = "Özel Kod4";
            else
                OzelKod4 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod4;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans1))
                ANRefNo = "Kredi Kartı Numarası";
            else
                ANRefNo = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans1;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans2))
                ANRefNo2 = "Hesap No";
            else
                ANRefNo2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans2;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans3))
                ANRefNo3 = "Kebir";
            else
                ANRefNo3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans3;

            #endregion Özelleştirme

            #region Caption Edit

            dicFieldCaption.Add("AN_REF_NO1", ANRefNo);
            dicFieldCaption.Add("AN_REF_NO2", ANRefNo2);
            dicFieldCaption.Add("AN_REF_NO3", ANRefNo3);
            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("ICRA_REF_NO1", RefNo);
            dicFieldCaption.Add("ICRA_REF_NO2", RefNo2);
            dicFieldCaption.Add("ICRA_REF_NO3", refNo3);
            dicFieldCaption.Add("TAKIP_TARIHI", "Takip T");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("TAKIBIN_AVUKATA_INTIKAL_TARIHI", "İntikal T");
            dicFieldCaption.Add("ASIL_ALACAK", "Asıl Alacak");
            dicFieldCaption.Add("ISLEMIS_FAIZ", "İşlenmiş Faiz");
            dicFieldCaption.Add("SON_HESAP_TARIHI", "Son Hesap T");
            dicFieldCaption.Add("TAKIP_CIKISI", "Takip Çıkışı");
            dicFieldCaption.Add("ODEME_TOPLAMI", "Ödeme Toplamı");
            dicFieldCaption.Add("KALAN", "Kalan");
            dicFieldCaption.Add("KAPAMA_TARIHI", "Kapama T");
            dicFieldCaption.Add("RISK_MIKTARI", "Risk Miktarı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("ADLIYE", "Adliye");
            dicFieldCaption.Add("NO", "No");
            dicFieldCaption.Add("OZEL_KOD1", OzelKod1);
            dicFieldCaption.Add("OZEL_KOD2", OzelKod2);
            dicFieldCaption.Add("OZEL_KOD3", OzelKod3);
            dicFieldCaption.Add("OZEL_KOD4", OzelKod4);
            dicFieldCaption.Add("HESAPLAMA_TIPI", "Hesaplama Tipi");
            dicFieldCaption.Add("BIR_YIL_KAC_GUN", "Bir Yıl Kaç Gün");
            dicFieldCaption.Add("TAKIP_VEKALET_UCRETI", "Takip Vekalet Ücreti");
            dicFieldCaption.Add("MAHSUP_TOPLAMI", "Mahsup Toplamı");
            dicFieldCaption.Add("ALACAK_TOPLAMI", "Alacak Toplamı");
            dicFieldCaption.Add("FERAGAT_TOPLAMI", "Feragat Toplamı");
            dicFieldCaption.Add("PROTOKOL_MIKTARI", "Protokol Miktarı");
            dicFieldCaption.Add("PROTOKOL_TARIHI", "Protokol T.");
            dicFieldCaption.Add("KARSILIK_TUTARI", "Karşılık Tutarı");
            dicFieldCaption.Add("TUM_MASRAF_TOPLAMI", "Tüm Masraf Toplamı");
            dicFieldCaption.Add("HARC_TOPLAMI", "Harç Toplamı");
            dicFieldCaption.Add("TUM_VEKALET_TOPLAMI", "Tüm Vekalet Toplamı");
            dicFieldCaption.Add("TAKIP_CIKIS_GAYRI_NAKIT", "Takip Çıkışı Gayrinakit");
            dicFieldCaption.Add("GAYRI_NAKIT_KALAN", "Gayri Nakit Kalan");
            dicFieldCaption.Add("BANKA", "Banka");
            dicFieldCaption.Add("SUBE", "Şube");
            dicFieldCaption.Add("FOY_BIRIM", "Dosya Birim");
            dicFieldCaption.Add("FOY_YERI", "Dosya Yeri");
            dicFieldCaption.Add("FOY_OZEL_DURUM", "Dosya Özel Durum");
            dicFieldCaption.Add("TAHSILAT_DURUM", "Tahsilat Durum");
            dicFieldCaption.Add("KREDI_GRUP", "Kredi Grup");
            dicFieldCaption.Add("KREDI_TIP", "Kredi Tip");
            dicFieldCaption.Add("KLASOR_1", "Klasör 1");
            dicFieldCaption.Add("KLASOR_2", "Klasör 1");
            dicFieldCaption.Add("TUM_ODEME_TOPLAMI", "Tüm Ödeme Toplamı");
            dicFieldCaption.Add("VEKALET_UCRETINDEN_ODENEN", "Vekalet Ücretinden Ödenen");
            dicFieldCaption.Add("RISKTEN_KALAN", "Riskten Kalan");
            dicFieldCaption.Add("MASRAFA_YAPILAN_TAHSILAT", "Masrafa Yapılan Tahsilat");
            dicFieldCaption.Add("ANA_PARAYA_YAPILAN_TAHSILAT", "Ana Paraya Yapılan Tahsilat");
            dicFieldCaption.Add("FAIZE_YAPILAN_TAHSILAT", "Faize Yapılan Tahsilat");
            dicFieldCaption.Add("TO_ODEME_TOPLAMI", "T.Ö Ödeme Toplamı");
            dicFieldCaption.Add("SUBE_NO", "Şube No");
            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("AVUKATA_ODENEN_MIKTAR", "Avukata Ödenen");
            dicFieldCaption.Add("ALACAKLIYA_ODENEN_MIKTAR", "Alacaklıya Ödenen");
            dicFieldCaption.Add("SATISTAN_GELEN_MIKTAR", "Satıştan Gelen");
            dicFieldCaption.Add("SEGMENT_ID", "Bölüm");
            dicFieldCaption.Add("SORUMLU", "Sorumlu");
            dicFieldCaption.Add("TAKIP_EDILEN_TARAF_KOD", "Takip Edilen T.K");
            dicFieldCaption.Add("TAKIP_EDILEN", "Takip Edilen");
            dicFieldCaption.Add("TAKIP_EDILEN_SIFAT", "Takip Edilen Sıfat");
            dicFieldCaption.Add("TAKIP_EDEN", "Takip Eden");
            dicFieldCaption.Add("TAKIP_EDEN_TARAF_KOD", "Takip Eden T.K");
            dicFieldCaption.Add("TAKIP_EDEN_SIFAT", "Takip Eden Sıfat");
            dicFieldCaption.Add("IZLEYEN", "İzleyen");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            //RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

            //Inits.DovizTipGetir(rlueDoviz);

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            #region <cc-20090622>

            //çevirme yapilinca açılacak
            sozluk.Add("DovizId", InitsEx.DovizTipGetir);

            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("SEGMENT_ID", InitsEx.SegmnetBolumGetir);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("KALAN", InitsEx.ParaBicimiAyarla);
            sozluk.Add("RISK_MIKTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("RISK_MIKTARI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("PROTOKOL_MIKTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("PROTOKOL_MIKTARI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("KARSILIK_TUTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("KARSILIK_TUTARI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("GAYRI_NAKIT_KALAN", InitsEx.ParaBicimiAyarla);
            sozluk.Add("RISKTEN_KALAN", InitsEx.ParaBicimiAyarla);
            sozluk.Add("MASRAFA_YAPILAN_TAHSILAT", InitsEx.ParaBicimiAyarla);
            sozluk.Add("MASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("ANA_PARAYA_YAPILAN_TAHSILAT", InitsEx.ParaBicimiAyarla);
            sozluk.Add("ANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("FAIZE_YAPILAN_TAHSILAT", InitsEx.ParaBicimiAyarla);
            sozluk.Add("FAIZE_YAPILAN_TAHSILAT_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("AVUKATA_ODENEN_MIKTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("AVUKATA_ODENEN_MIKTAR_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("ALACAKLIYA_ODENEN_MIKTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("ALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("SATISTAN_GELEN_MIKTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("SATISTAN_GELEN_MIKTAR_DOVIZ_ID", InitsEx.DovizTipGetir);

            #endregion <cc-20090622>

            #endregion Add item

            return sozluk;
        }

        private GridColumn[] KanuniTakip()
        {
            #region Field & Properties

            GridColumn colAN_REF_NO1 = new GridColumn();
            colAN_REF_NO1.VisibleIndex = 0;
            colAN_REF_NO1.FieldName = "AN_REF_NO1";
            colAN_REF_NO1.Name = "colAN_REF_NO1";
            colAN_REF_NO1.Visible = true;

            GridColumn colAN_REF_NO2 = new GridColumn();
            colAN_REF_NO2.VisibleIndex = 1;
            colAN_REF_NO2.FieldName = "AN_REF_NO2";
            colAN_REF_NO2.Name = "colAN_REF_NO2";
            colAN_REF_NO2.Visible = true;

            GridColumn colAN_REF_NO3 = new GridColumn();
            colAN_REF_NO3.VisibleIndex = 2;
            colAN_REF_NO3.FieldName = "AN_REF_NO3";
            colAN_REF_NO3.Name = "colAN_REF_NO3";
            colAN_REF_NO3.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 3;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colICRA_REF_NO1 = new GridColumn();
            colICRA_REF_NO1.VisibleIndex = 4;
            colICRA_REF_NO1.FieldName = "ICRA_REF_NO1";
            colICRA_REF_NO1.Name = "colICRA_REF_NO1";
            colICRA_REF_NO1.Visible = true;

            GridColumn colICRA_REF_NO2 = new GridColumn();
            colICRA_REF_NO2.VisibleIndex = 5;
            colICRA_REF_NO2.FieldName = "ICRA_REF_NO2";
            colICRA_REF_NO2.Name = "colICRA_REF_NO2";
            colICRA_REF_NO2.Visible = true;

            GridColumn colICRA_REF_NO3 = new GridColumn();
            colICRA_REF_NO3.VisibleIndex = 6;
            colICRA_REF_NO3.FieldName = "ICRA_REF_NO3";
            colICRA_REF_NO3.Name = "colICRA_REF_NO3";
            colICRA_REF_NO3.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 7;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 8;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colTAKIBIN_AVUKATA_INTIKAL_TARIHI = new GridColumn();
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 9;
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "colTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colASIL_ALACAK = new GridColumn();
            colASIL_ALACAK.VisibleIndex = 10;
            colASIL_ALACAK.FieldName = "ASIL_ALACAK";
            colASIL_ALACAK.Name = "colASIL_ALACAK";
            colASIL_ALACAK.Visible = true;

            GridColumn colASIL_ALACAK_DOVIZ_ID = new GridColumn();
            colASIL_ALACAK_DOVIZ_ID.VisibleIndex = 11;
            colASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Name = "colASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Visible = true;

            GridColumn colISLEMIS_FAIZ = new GridColumn();
            colISLEMIS_FAIZ.VisibleIndex = 12;
            colISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Name = "colISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Visible = true;

            GridColumn colISLEMIS_FAIZ_DOVIZ_ID = new GridColumn();
            colISLEMIS_FAIZ_DOVIZ_ID.VisibleIndex = 13;
            colISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Name = "colISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colSON_HESAP_TARIHI = new GridColumn();
            colSON_HESAP_TARIHI.VisibleIndex = 14;
            colSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Name = "colSON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Visible = true;

            GridColumn colTAKIP_CIKISI = new GridColumn();
            colTAKIP_CIKISI.VisibleIndex = 15;
            colTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            colTAKIP_CIKISI.Name = "colTAKIP_CIKISI";
            colTAKIP_CIKISI.Visible = true;

            GridColumn colTAKIP_CIKISI_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKISI_DOVIZ_ID.VisibleIndex = 16;
            colTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Name = "colTAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_TOPLAMI = new GridColumn();
            colODEME_TOPLAMI.VisibleIndex = 17;
            colODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            colODEME_TOPLAMI.Name = "colODEME_TOPLAMI";
            colODEME_TOPLAMI.Visible = true;

            GridColumn colODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 18;
            colODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Name = "colODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN = new GridColumn();
            colKALAN.VisibleIndex = 19;
            colKALAN.FieldName = "KALAN";
            colKALAN.Name = "colKALAN";
            colKALAN.Visible = true;

            GridColumn colKALAN_DOVIZ_ID = new GridColumn();
            colKALAN_DOVIZ_ID.VisibleIndex = 20;
            colKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Name = "colKALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Visible = true;

            GridColumn colKAPAMA_TARIHI = new GridColumn();
            colKAPAMA_TARIHI.VisibleIndex = 21;
            colKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            colKAPAMA_TARIHI.Name = "colKAPAMA_TARIHI";
            colKAPAMA_TARIHI.Visible = true;

            GridColumn colRISK_MIKTARI = new GridColumn();
            colRISK_MIKTARI.VisibleIndex = 22;
            colRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            colRISK_MIKTARI.Name = "colRISK_MIKTARI";
            colRISK_MIKTARI.Visible = true;

            GridColumn colRISK_MIKTARI_DOVIZ_ID = new GridColumn();
            colRISK_MIKTARI_DOVIZ_ID.VisibleIndex = 23;
            colRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Name = "colRISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 24;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 25;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 26;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 27;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 28;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 29;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 30;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 31;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.Visible = true;

            GridColumn colHESAPLAMA_TIPI = new GridColumn();
            colHESAPLAMA_TIPI.VisibleIndex = 32;
            colHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Name = "colHESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Visible = true;

            GridColumn colBIR_YIL_KAC_GUN = new GridColumn();
            colBIR_YIL_KAC_GUN.VisibleIndex = 33;
            colBIR_YIL_KAC_GUN.FieldName = "BIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Name = "colBIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI = new GridColumn();
            colTAKIP_VEKALET_UCRETI.VisibleIndex = 34;
            colTAKIP_VEKALET_UCRETI.FieldName = "TAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Name = "colTAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 35;
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Name = "colTAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colMAHSUP_TOPLAMI = new GridColumn();
            colMAHSUP_TOPLAMI.VisibleIndex = 36;
            colMAHSUP_TOPLAMI.FieldName = "MAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Name = "colMAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Visible = true;

            GridColumn colMAHSUP_TOPLAMI_DOVIZ_ID = new GridColumn();
            colMAHSUP_TOPLAMI_DOVIZ_ID.VisibleIndex = 37;
            colMAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Name = "colMAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colALACAK_TOPLAMI = new GridColumn();
            colALACAK_TOPLAMI.VisibleIndex = 38;
            colALACAK_TOPLAMI.FieldName = "ALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Name = "colALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Visible = true;

            GridColumn colALACAK_TOPLAMI_DOVIZ_ID = new GridColumn();
            colALACAK_TOPLAMI_DOVIZ_ID.VisibleIndex = 39;
            colALACAK_TOPLAMI_DOVIZ_ID.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Name = "colALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colFERAGAT_TOPLAMI = new GridColumn();
            colFERAGAT_TOPLAMI.VisibleIndex = 40;
            colFERAGAT_TOPLAMI.FieldName = "FERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Name = "colFERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Visible = true;

            GridColumn colFERAGAT_TOPLAMI_DOVIZ_ID = new GridColumn();
            colFERAGAT_TOPLAMI_DOVIZ_ID.VisibleIndex = 41;
            colFERAGAT_TOPLAMI_DOVIZ_ID.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Name = "colFERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_MIKTARI = new GridColumn();
            colPROTOKOL_MIKTARI.VisibleIndex = 42;
            colPROTOKOL_MIKTARI.FieldName = "PROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Name = "colPROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Visible = true;

            GridColumn colPROTOKOL_MIKTARI_DOVIZ_ID = new GridColumn();
            colPROTOKOL_MIKTARI_DOVIZ_ID.VisibleIndex = 43;
            colPROTOKOL_MIKTARI_DOVIZ_ID.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Name = "colPROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_TARIHI = new GridColumn();
            colPROTOKOL_TARIHI.VisibleIndex = 44;
            colPROTOKOL_TARIHI.FieldName = "PROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Name = "colPROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Visible = true;

            GridColumn colKARSILIK_TUTARI = new GridColumn();
            colKARSILIK_TUTARI.VisibleIndex = 45;
            colKARSILIK_TUTARI.FieldName = "KARSILIK_TUTARI";
            colKARSILIK_TUTARI.Name = "colKARSILIK_TUTARI";
            colKARSILIK_TUTARI.Visible = true;

            GridColumn colKARSILIK_TUTARI_DOVIZ_ID = new GridColumn();
            colKARSILIK_TUTARI_DOVIZ_ID.VisibleIndex = 46;
            colKARSILIK_TUTARI_DOVIZ_ID.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Name = "colKARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI = new GridColumn();
            colTUM_MASRAF_TOPLAMI.VisibleIndex = 47;
            colTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Name = "colTUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.VisibleIndex = 48;
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "colTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colHARC_TOPLAMI = new GridColumn();
            colHARC_TOPLAMI.VisibleIndex = 49;
            colHARC_TOPLAMI.FieldName = "HARC_TOPLAMI";
            colHARC_TOPLAMI.Name = "colHARC_TOPLAMI";
            colHARC_TOPLAMI.Visible = true;

            GridColumn colHARC_TOPLAMI_DOVIZ_ID = new GridColumn();
            colHARC_TOPLAMI_DOVIZ_ID.VisibleIndex = 50;
            colHARC_TOPLAMI_DOVIZ_ID.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Name = "colHARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI = new GridColumn();
            colTUM_VEKALET_TOPLAMI.VisibleIndex = 51;
            colTUM_VEKALET_TOPLAMI.FieldName = "TUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Name = "colTUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.VisibleIndex = 52;
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Name = "colTUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT.VisibleIndex = 53;
            colTAKIP_CIKIS_GAYRI_NAKIT.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Name = "colTAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.VisibleIndex = 54;
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Name = "colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN = new GridColumn();
            colGAYRI_NAKIT_KALAN.VisibleIndex = 55;
            colGAYRI_NAKIT_KALAN.FieldName = "GAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Name = "colGAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN_DOVIZ_ID = new GridColumn();
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.VisibleIndex = 56;
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.FieldName = "GAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Name = "colGAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 57;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colSUBE = new GridColumn();
            colSUBE.VisibleIndex = 58;
            colSUBE.FieldName = "SUBE";
            colSUBE.Name = "colSUBE";
            colSUBE.Visible = true;

            GridColumn colFOY_BIRIM = new GridColumn();
            colFOY_BIRIM.VisibleIndex = 59;
            colFOY_BIRIM.FieldName = "FOY_BIRIM";
            colFOY_BIRIM.Name = "colFOY_BIRIM";
            colFOY_BIRIM.Visible = true;

            GridColumn colFOY_YERI = new GridColumn();
            colFOY_YERI.VisibleIndex = 60;
            colFOY_YERI.FieldName = "FOY_YERI";
            colFOY_YERI.Name = "colFOY_YERI";
            colFOY_YERI.Visible = true;

            GridColumn colFOY_OZEL_DURUM = new GridColumn();
            colFOY_OZEL_DURUM.VisibleIndex = 61;
            colFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Name = "colFOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Visible = true;

            GridColumn colTAHSILAT_DURUM = new GridColumn();
            colTAHSILAT_DURUM.VisibleIndex = 62;
            colTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            colTAHSILAT_DURUM.Name = "colTAHSILAT_DURUM";
            colTAHSILAT_DURUM.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 63;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 64;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colKLASOR_1 = new GridColumn();
            colKLASOR_1.VisibleIndex = 65;
            colKLASOR_1.FieldName = "KLASOR_1";
            colKLASOR_1.Name = "colKLASOR_1";
            colKLASOR_1.Visible = true;

            GridColumn colKLASOR_2 = new GridColumn();
            colKLASOR_2.VisibleIndex = 66;
            colKLASOR_2.FieldName = "KLASOR_2";
            colKLASOR_2.Name = "colKLASOR_2";
            colKLASOR_2.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI = new GridColumn();
            colTUM_ODEME_TOPLAMI.VisibleIndex = 67;
            colTUM_ODEME_TOPLAMI.FieldName = "TUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Name = "colTUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 68;
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN.VisibleIndex = 69;
            colVEKALET_UCRETINDEN_ODENEN.FieldName = "VEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Name = "colVEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.VisibleIndex = 70;
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.FieldName = "VEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Name = "colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Visible = true;

            GridColumn colRISKTEN_KALAN = new GridColumn();
            colRISKTEN_KALAN.VisibleIndex = 71;
            colRISKTEN_KALAN.FieldName = "RISKTEN_KALAN";
            colRISKTEN_KALAN.Name = "colRISKTEN_KALAN";
            colRISKTEN_KALAN.Visible = true;

            GridColumn colRISKTEN_KALAN_DOVIZ_ID = new GridColumn();
            colRISKTEN_KALAN_DOVIZ_ID.VisibleIndex = 72;
            colRISKTEN_KALAN_DOVIZ_ID.FieldName = "RISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Name = "colRISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT.VisibleIndex = 73;
            colMASRAFA_YAPILAN_TAHSILAT.FieldName = "MASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Name = "colMASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 74;
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "MASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT.VisibleIndex = 75;
            colANA_PARAYA_YAPILAN_TAHSILAT.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Name = "colANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 76;
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT.VisibleIndex = 77;
            colFAIZE_YAPILAN_TAHSILAT.FieldName = "FAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Name = "colFAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 78;
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "FAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI = new GridColumn();
            colTO_ODEME_TOPLAMI.VisibleIndex = 79;
            colTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Name = "colTO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTO_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 80;
            colTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_NO = new GridColumn();
            colSUBE_NO.VisibleIndex = 81;
            colSUBE_NO.FieldName = "SUBE_NO";
            colSUBE_NO.Name = "colSUBE_NO";
            colSUBE_NO.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 82;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR.VisibleIndex = 83;
            colAVUKATA_ODENEN_MIKTAR.FieldName = "AVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Name = "colAVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 84;
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "AVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR.VisibleIndex = 85;
            colALACAKLIYA_ODENEN_MIKTAR.FieldName = "ALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Name = "colALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 86;
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "ALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR = new GridColumn();
            colSATISTAN_GELEN_MIKTAR.VisibleIndex = 87;
            colSATISTAN_GELEN_MIKTAR.FieldName = "SATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Name = "colSATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.VisibleIndex = 88;
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.FieldName = "SATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Name = "colSATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSEGMENT_ID = new GridColumn();
            colSEGMENT_ID.VisibleIndex = 89;
            colSEGMENT_ID.FieldName = "SEGMENT_ID";
            colSEGMENT_ID.Name = "colSEGMENT_ID";
            colSEGMENT_ID.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 90;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colTAKIP_EDILEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDILEN_TARAF_KOD.VisibleIndex = 91;
            colTAKIP_EDILEN_TARAF_KOD.FieldName = "TAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Name = "colTAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 92;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colTAKIP_EDILEN_SIFAT = new GridColumn();
            colTAKIP_EDILEN_SIFAT.VisibleIndex = 93;
            colTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Name = "colTAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Visible = true;

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 94;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colTAKIP_EDEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDEN_TARAF_KOD.VisibleIndex = 95;
            colTAKIP_EDEN_TARAF_KOD.FieldName = "TAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Name = "colTAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDEN_SIFAT = new GridColumn();
            colTAKIP_EDEN_SIFAT.VisibleIndex = 96;
            colTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Name = "colTAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 97;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 98;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            #endregion Field & Properties

            #region

            dizi = new GridColumn[]
		{
            colFOY_NO,
            colDURUM,
            colESAS_NO,
            colTAKIP_TARIHI,
            colADLIYE,
			colNO,
            colTAKIP_EDEN,
            colSUBE_NO,
            colSUBE,
            colKREDI_TIP,
            colIZLEYEN,
			colSORUMLU,
            colAN_REF_NO2,
			colAN_REF_NO3,
            colTAKIP_EDILEN,
			colTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			colASIL_ALACAK,
			colASIL_ALACAK_DOVIZ_ID,
			colSUBE_KOD_ID,
            colAN_REF_NO1,
			};
            return dizi;

            #endregion
        }

        private GridColumn[] KanuniTakipBakiyeli()
        {
            #region Field & Properties

            GridColumn colAN_REF_NO1 = new GridColumn();
            colAN_REF_NO1.VisibleIndex = 0;
            colAN_REF_NO1.FieldName = "AN_REF_NO1";
            colAN_REF_NO1.Name = "colAN_REF_NO1";
            colAN_REF_NO1.Visible = true;

            GridColumn colAN_REF_NO2 = new GridColumn();
            colAN_REF_NO2.VisibleIndex = 1;
            colAN_REF_NO2.FieldName = "AN_REF_NO2";
            colAN_REF_NO2.Name = "colAN_REF_NO2";
            colAN_REF_NO2.Visible = true;

            GridColumn colAN_REF_NO3 = new GridColumn();
            colAN_REF_NO3.VisibleIndex = 2;
            colAN_REF_NO3.FieldName = "AN_REF_NO3";
            colAN_REF_NO3.Name = "colAN_REF_NO3";
            colAN_REF_NO3.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 3;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colICRA_REF_NO1 = new GridColumn();
            colICRA_REF_NO1.VisibleIndex = 4;
            colICRA_REF_NO1.FieldName = "ICRA_REF_NO1";
            colICRA_REF_NO1.Name = "colICRA_REF_NO1";
            colICRA_REF_NO1.Visible = true;

            GridColumn colICRA_REF_NO2 = new GridColumn();
            colICRA_REF_NO2.VisibleIndex = 5;
            colICRA_REF_NO2.FieldName = "ICRA_REF_NO2";
            colICRA_REF_NO2.Name = "colICRA_REF_NO2";
            colICRA_REF_NO2.Visible = true;

            GridColumn colICRA_REF_NO3 = new GridColumn();
            colICRA_REF_NO3.VisibleIndex = 6;
            colICRA_REF_NO3.FieldName = "ICRA_REF_NO3";
            colICRA_REF_NO3.Name = "colICRA_REF_NO3";
            colICRA_REF_NO3.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 7;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 8;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colTAKIBIN_AVUKATA_INTIKAL_TARIHI = new GridColumn();
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 9;
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "colTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colASIL_ALACAK = new GridColumn();
            colASIL_ALACAK.VisibleIndex = 10;
            colASIL_ALACAK.FieldName = "ASIL_ALACAK";
            colASIL_ALACAK.Name = "colASIL_ALACAK";
            colASIL_ALACAK.Visible = true;

            GridColumn colASIL_ALACAK_DOVIZ_ID = new GridColumn();
            colASIL_ALACAK_DOVIZ_ID.VisibleIndex = 11;
            colASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Name = "colASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Visible = true;

            GridColumn colISLEMIS_FAIZ = new GridColumn();
            colISLEMIS_FAIZ.VisibleIndex = 12;
            colISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Name = "colISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Visible = true;

            GridColumn colISLEMIS_FAIZ_DOVIZ_ID = new GridColumn();
            colISLEMIS_FAIZ_DOVIZ_ID.VisibleIndex = 13;
            colISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Name = "colISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colSON_HESAP_TARIHI = new GridColumn();
            colSON_HESAP_TARIHI.VisibleIndex = 14;
            colSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Name = "colSON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Visible = true;

            GridColumn colTAKIP_CIKISI = new GridColumn();
            colTAKIP_CIKISI.VisibleIndex = 15;
            colTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            colTAKIP_CIKISI.Name = "colTAKIP_CIKISI";
            colTAKIP_CIKISI.Visible = true;

            GridColumn colTAKIP_CIKISI_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKISI_DOVIZ_ID.VisibleIndex = 16;
            colTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Name = "colTAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_TOPLAMI = new GridColumn();
            colODEME_TOPLAMI.VisibleIndex = 17;
            colODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            colODEME_TOPLAMI.Name = "colODEME_TOPLAMI";
            colODEME_TOPLAMI.Visible = true;

            GridColumn colODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 18;
            colODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Name = "colODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN = new GridColumn();
            colKALAN.VisibleIndex = 19;
            colKALAN.FieldName = "KALAN";
            colKALAN.Name = "colKALAN";
            colKALAN.Visible = true;

            GridColumn colKALAN_DOVIZ_ID = new GridColumn();
            colKALAN_DOVIZ_ID.VisibleIndex = 20;
            colKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Name = "colKALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Visible = true;

            GridColumn colKAPAMA_TARIHI = new GridColumn();
            colKAPAMA_TARIHI.VisibleIndex = 21;
            colKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            colKAPAMA_TARIHI.Name = "colKAPAMA_TARIHI";
            colKAPAMA_TARIHI.Visible = true;

            GridColumn colRISK_MIKTARI = new GridColumn();
            colRISK_MIKTARI.VisibleIndex = 22;
            colRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            colRISK_MIKTARI.Name = "colRISK_MIKTARI";
            colRISK_MIKTARI.Visible = true;

            GridColumn colRISK_MIKTARI_DOVIZ_ID = new GridColumn();
            colRISK_MIKTARI_DOVIZ_ID.VisibleIndex = 23;
            colRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Name = "colRISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 24;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 25;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 26;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 27;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 28;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 29;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 30;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 31;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.Visible = true;

            GridColumn colHESAPLAMA_TIPI = new GridColumn();
            colHESAPLAMA_TIPI.VisibleIndex = 32;
            colHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Name = "colHESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Visible = true;

            GridColumn colBIR_YIL_KAC_GUN = new GridColumn();
            colBIR_YIL_KAC_GUN.VisibleIndex = 33;
            colBIR_YIL_KAC_GUN.FieldName = "BIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Name = "colBIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI = new GridColumn();
            colTAKIP_VEKALET_UCRETI.VisibleIndex = 34;
            colTAKIP_VEKALET_UCRETI.FieldName = "TAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Name = "colTAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 35;
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Name = "colTAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colMAHSUP_TOPLAMI = new GridColumn();
            colMAHSUP_TOPLAMI.VisibleIndex = 36;
            colMAHSUP_TOPLAMI.FieldName = "MAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Name = "colMAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Visible = true;

            GridColumn colMAHSUP_TOPLAMI_DOVIZ_ID = new GridColumn();
            colMAHSUP_TOPLAMI_DOVIZ_ID.VisibleIndex = 37;
            colMAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Name = "colMAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colALACAK_TOPLAMI = new GridColumn();
            colALACAK_TOPLAMI.VisibleIndex = 38;
            colALACAK_TOPLAMI.FieldName = "ALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Name = "colALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Visible = true;

            GridColumn colALACAK_TOPLAMI_DOVIZ_ID = new GridColumn();
            colALACAK_TOPLAMI_DOVIZ_ID.VisibleIndex = 39;
            colALACAK_TOPLAMI_DOVIZ_ID.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Name = "colALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colFERAGAT_TOPLAMI = new GridColumn();
            colFERAGAT_TOPLAMI.VisibleIndex = 40;
            colFERAGAT_TOPLAMI.FieldName = "FERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Name = "colFERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Visible = true;

            GridColumn colFERAGAT_TOPLAMI_DOVIZ_ID = new GridColumn();
            colFERAGAT_TOPLAMI_DOVIZ_ID.VisibleIndex = 41;
            colFERAGAT_TOPLAMI_DOVIZ_ID.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Name = "colFERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_MIKTARI = new GridColumn();
            colPROTOKOL_MIKTARI.VisibleIndex = 42;
            colPROTOKOL_MIKTARI.FieldName = "PROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Name = "colPROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Visible = true;

            GridColumn colPROTOKOL_MIKTARI_DOVIZ_ID = new GridColumn();
            colPROTOKOL_MIKTARI_DOVIZ_ID.VisibleIndex = 43;
            colPROTOKOL_MIKTARI_DOVIZ_ID.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Name = "colPROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_TARIHI = new GridColumn();
            colPROTOKOL_TARIHI.VisibleIndex = 44;
            colPROTOKOL_TARIHI.FieldName = "PROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Name = "colPROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Visible = true;

            GridColumn colKARSILIK_TUTARI = new GridColumn();
            colKARSILIK_TUTARI.VisibleIndex = 45;
            colKARSILIK_TUTARI.FieldName = "KARSILIK_TUTARI";
            colKARSILIK_TUTARI.Name = "colKARSILIK_TUTARI";
            colKARSILIK_TUTARI.Visible = true;

            GridColumn colKARSILIK_TUTARI_DOVIZ_ID = new GridColumn();
            colKARSILIK_TUTARI_DOVIZ_ID.VisibleIndex = 46;
            colKARSILIK_TUTARI_DOVIZ_ID.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Name = "colKARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI = new GridColumn();
            colTUM_MASRAF_TOPLAMI.VisibleIndex = 47;
            colTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Name = "colTUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.VisibleIndex = 48;
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "colTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colHARC_TOPLAMI = new GridColumn();
            colHARC_TOPLAMI.VisibleIndex = 49;
            colHARC_TOPLAMI.FieldName = "HARC_TOPLAMI";
            colHARC_TOPLAMI.Name = "colHARC_TOPLAMI";
            colHARC_TOPLAMI.Visible = true;

            GridColumn colHARC_TOPLAMI_DOVIZ_ID = new GridColumn();
            colHARC_TOPLAMI_DOVIZ_ID.VisibleIndex = 50;
            colHARC_TOPLAMI_DOVIZ_ID.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Name = "colHARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI = new GridColumn();
            colTUM_VEKALET_TOPLAMI.VisibleIndex = 51;
            colTUM_VEKALET_TOPLAMI.FieldName = "TUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Name = "colTUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.VisibleIndex = 52;
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Name = "colTUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT.VisibleIndex = 53;
            colTAKIP_CIKIS_GAYRI_NAKIT.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Name = "colTAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.VisibleIndex = 54;
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Name = "colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN = new GridColumn();
            colGAYRI_NAKIT_KALAN.VisibleIndex = 55;
            colGAYRI_NAKIT_KALAN.FieldName = "GAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Name = "colGAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN_DOVIZ_ID = new GridColumn();
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.VisibleIndex = 56;
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.FieldName = "GAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Name = "colGAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 57;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colSUBE = new GridColumn();
            colSUBE.VisibleIndex = 58;
            colSUBE.FieldName = "SUBE";
            colSUBE.Name = "colSUBE";
            colSUBE.Visible = true;

            GridColumn colFOY_BIRIM = new GridColumn();
            colFOY_BIRIM.VisibleIndex = 59;
            colFOY_BIRIM.FieldName = "FOY_BIRIM";
            colFOY_BIRIM.Name = "colFOY_BIRIM";
            colFOY_BIRIM.Visible = true;

            GridColumn colFOY_YERI = new GridColumn();
            colFOY_YERI.VisibleIndex = 60;
            colFOY_YERI.FieldName = "FOY_YERI";
            colFOY_YERI.Name = "colFOY_YERI";
            colFOY_YERI.Visible = true;

            GridColumn colFOY_OZEL_DURUM = new GridColumn();
            colFOY_OZEL_DURUM.VisibleIndex = 61;
            colFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Name = "colFOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Visible = true;

            GridColumn colTAHSILAT_DURUM = new GridColumn();
            colTAHSILAT_DURUM.VisibleIndex = 62;
            colTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            colTAHSILAT_DURUM.Name = "colTAHSILAT_DURUM";
            colTAHSILAT_DURUM.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 63;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 64;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colKLASOR_1 = new GridColumn();
            colKLASOR_1.VisibleIndex = 65;
            colKLASOR_1.FieldName = "KLASOR_1";
            colKLASOR_1.Name = "colKLASOR_1";
            colKLASOR_1.Visible = true;

            GridColumn colKLASOR_2 = new GridColumn();
            colKLASOR_2.VisibleIndex = 66;
            colKLASOR_2.FieldName = "KLASOR_2";
            colKLASOR_2.Name = "colKLASOR_2";
            colKLASOR_2.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI = new GridColumn();
            colTUM_ODEME_TOPLAMI.VisibleIndex = 67;
            colTUM_ODEME_TOPLAMI.FieldName = "TUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Name = "colTUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 68;
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN.VisibleIndex = 69;
            colVEKALET_UCRETINDEN_ODENEN.FieldName = "VEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Name = "colVEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.VisibleIndex = 70;
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.FieldName = "VEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Name = "colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Visible = true;

            GridColumn colRISKTEN_KALAN = new GridColumn();
            colRISKTEN_KALAN.VisibleIndex = 71;
            colRISKTEN_KALAN.FieldName = "RISKTEN_KALAN";
            colRISKTEN_KALAN.Name = "colRISKTEN_KALAN";
            colRISKTEN_KALAN.Visible = true;

            GridColumn colRISKTEN_KALAN_DOVIZ_ID = new GridColumn();
            colRISKTEN_KALAN_DOVIZ_ID.VisibleIndex = 72;
            colRISKTEN_KALAN_DOVIZ_ID.FieldName = "RISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Name = "colRISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT.VisibleIndex = 73;
            colMASRAFA_YAPILAN_TAHSILAT.FieldName = "MASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Name = "colMASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 74;
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "MASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT.VisibleIndex = 75;
            colANA_PARAYA_YAPILAN_TAHSILAT.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Name = "colANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 76;
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT.VisibleIndex = 77;
            colFAIZE_YAPILAN_TAHSILAT.FieldName = "FAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Name = "colFAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 78;
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "FAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI = new GridColumn();
            colTO_ODEME_TOPLAMI.VisibleIndex = 79;
            colTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Name = "colTO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTO_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 80;
            colTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_NO = new GridColumn();
            colSUBE_NO.VisibleIndex = 81;
            colSUBE_NO.FieldName = "SUBE_NO";
            colSUBE_NO.Name = "colSUBE_NO";
            colSUBE_NO.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 82;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR.VisibleIndex = 83;
            colAVUKATA_ODENEN_MIKTAR.FieldName = "AVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Name = "colAVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 84;
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "AVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR.VisibleIndex = 85;
            colALACAKLIYA_ODENEN_MIKTAR.FieldName = "ALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Name = "colALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 86;
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "ALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR = new GridColumn();
            colSATISTAN_GELEN_MIKTAR.VisibleIndex = 87;
            colSATISTAN_GELEN_MIKTAR.FieldName = "SATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Name = "colSATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.VisibleIndex = 88;
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.FieldName = "SATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Name = "colSATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSEGMENT_ID = new GridColumn();
            colSEGMENT_ID.VisibleIndex = 89;
            colSEGMENT_ID.FieldName = "SEGMENT_ID";
            colSEGMENT_ID.Name = "colSEGMENT_ID";
            colSEGMENT_ID.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 90;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colTAKIP_EDILEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDILEN_TARAF_KOD.VisibleIndex = 91;
            colTAKIP_EDILEN_TARAF_KOD.FieldName = "TAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Name = "colTAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 92;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colTAKIP_EDILEN_SIFAT = new GridColumn();
            colTAKIP_EDILEN_SIFAT.VisibleIndex = 93;
            colTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Name = "colTAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Visible = true;

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 94;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colTAKIP_EDEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDEN_TARAF_KOD.VisibleIndex = 95;
            colTAKIP_EDEN_TARAF_KOD.FieldName = "TAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Name = "colTAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDEN_SIFAT = new GridColumn();
            colTAKIP_EDEN_SIFAT.VisibleIndex = 96;
            colTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Name = "colTAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 97;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 98;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            #endregion

            #region

            dizi = new GridColumn[]
		{
            colFOY_NO,
            colDURUM,
            colESAS_NO,
            colTAKIP_TARIHI,
            colADLIYE,
			colNO,
            colTAKIP_EDEN,
            colSUBE_NO,
            colSUBE,
            colKREDI_TIP,
            colIZLEYEN,
			colSORUMLU,
            colAN_REF_NO2,
			colAN_REF_NO3,
            colTAKIP_EDILEN,
			colTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			colASIL_ALACAK,
			colASIL_ALACAK_DOVIZ_ID,
			colSUBE_KOD_ID,
            colRISK_MIKTARI,
            colRISK_MIKTARI_DOVIZ_ID,
            colODEME_TOPLAMI,
            colODEME_TOPLAMI_DOVIZ_ID,
            colKALAN,
            colKALAN_DOVIZ_ID,
            colRISKTEN_KALAN,
            colRISKTEN_KALAN_DOVIZ_ID,
            colAN_REF_NO1,
			};
            return dizi;

            #endregion
        }

        private GridColumn[] ToplamTahsilat()
        {
            #region Field & Properties

            GridColumn colAN_REF_NO1 = new GridColumn();
            colAN_REF_NO1.VisibleIndex = 0;
            colAN_REF_NO1.FieldName = "AN_REF_NO1";
            colAN_REF_NO1.Name = "colAN_REF_NO1";
            colAN_REF_NO1.Visible = true;

            GridColumn colAN_REF_NO2 = new GridColumn();
            colAN_REF_NO2.VisibleIndex = 1;
            colAN_REF_NO2.FieldName = "AN_REF_NO2";
            colAN_REF_NO2.Name = "colAN_REF_NO2";
            colAN_REF_NO2.Visible = true;

            GridColumn colAN_REF_NO3 = new GridColumn();
            colAN_REF_NO3.VisibleIndex = 2;
            colAN_REF_NO3.FieldName = "AN_REF_NO3";
            colAN_REF_NO3.Name = "colAN_REF_NO3";
            colAN_REF_NO3.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 3;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colICRA_REF_NO1 = new GridColumn();
            colICRA_REF_NO1.VisibleIndex = 4;
            colICRA_REF_NO1.FieldName = "ICRA_REF_NO1";
            colICRA_REF_NO1.Name = "colICRA_REF_NO1";
            colICRA_REF_NO1.Visible = true;

            GridColumn colICRA_REF_NO2 = new GridColumn();
            colICRA_REF_NO2.VisibleIndex = 5;
            colICRA_REF_NO2.FieldName = "ICRA_REF_NO2";
            colICRA_REF_NO2.Name = "colICRA_REF_NO2";
            colICRA_REF_NO2.Visible = true;

            GridColumn colICRA_REF_NO3 = new GridColumn();
            colICRA_REF_NO3.VisibleIndex = 6;
            colICRA_REF_NO3.FieldName = "ICRA_REF_NO3";
            colICRA_REF_NO3.Name = "colICRA_REF_NO3";
            colICRA_REF_NO3.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 7;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 8;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colTAKIBIN_AVUKATA_INTIKAL_TARIHI = new GridColumn();
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 9;
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "colTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colASIL_ALACAK = new GridColumn();
            colASIL_ALACAK.VisibleIndex = 10;
            colASIL_ALACAK.FieldName = "ASIL_ALACAK";
            colASIL_ALACAK.Name = "colASIL_ALACAK";
            colASIL_ALACAK.Visible = true;

            GridColumn colASIL_ALACAK_DOVIZ_ID = new GridColumn();
            colASIL_ALACAK_DOVIZ_ID.VisibleIndex = 11;
            colASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Name = "colASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Visible = true;

            GridColumn colISLEMIS_FAIZ = new GridColumn();
            colISLEMIS_FAIZ.VisibleIndex = 12;
            colISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Name = "colISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Visible = true;

            GridColumn colISLEMIS_FAIZ_DOVIZ_ID = new GridColumn();
            colISLEMIS_FAIZ_DOVIZ_ID.VisibleIndex = 13;
            colISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Name = "colISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colSON_HESAP_TARIHI = new GridColumn();
            colSON_HESAP_TARIHI.VisibleIndex = 14;
            colSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Name = "colSON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Visible = true;

            GridColumn colTAKIP_CIKISI = new GridColumn();
            colTAKIP_CIKISI.VisibleIndex = 15;
            colTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            colTAKIP_CIKISI.Name = "colTAKIP_CIKISI";
            colTAKIP_CIKISI.Visible = true;

            GridColumn colTAKIP_CIKISI_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKISI_DOVIZ_ID.VisibleIndex = 16;
            colTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Name = "colTAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_TOPLAMI = new GridColumn();
            colODEME_TOPLAMI.VisibleIndex = 17;
            colODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            colODEME_TOPLAMI.Name = "colODEME_TOPLAMI";
            colODEME_TOPLAMI.Visible = true;

            GridColumn colODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 18;
            colODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Name = "colODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN = new GridColumn();
            colKALAN.VisibleIndex = 19;
            colKALAN.FieldName = "KALAN";
            colKALAN.Name = "colKALAN";
            colKALAN.Visible = true;

            GridColumn colKALAN_DOVIZ_ID = new GridColumn();
            colKALAN_DOVIZ_ID.VisibleIndex = 20;
            colKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Name = "colKALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Visible = true;

            GridColumn colKAPAMA_TARIHI = new GridColumn();
            colKAPAMA_TARIHI.VisibleIndex = 21;
            colKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            colKAPAMA_TARIHI.Name = "colKAPAMA_TARIHI";
            colKAPAMA_TARIHI.Visible = true;

            GridColumn colRISK_MIKTARI = new GridColumn();
            colRISK_MIKTARI.VisibleIndex = 22;
            colRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            colRISK_MIKTARI.Name = "colRISK_MIKTARI";
            colRISK_MIKTARI.Visible = true;

            GridColumn colRISK_MIKTARI_DOVIZ_ID = new GridColumn();
            colRISK_MIKTARI_DOVIZ_ID.VisibleIndex = 23;
            colRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Name = "colRISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 24;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 25;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 26;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 27;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 28;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 29;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 30;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 31;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.Visible = true;

            GridColumn colHESAPLAMA_TIPI = new GridColumn();
            colHESAPLAMA_TIPI.VisibleIndex = 32;
            colHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Name = "colHESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Visible = true;

            GridColumn colBIR_YIL_KAC_GUN = new GridColumn();
            colBIR_YIL_KAC_GUN.VisibleIndex = 33;
            colBIR_YIL_KAC_GUN.FieldName = "BIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Name = "colBIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI = new GridColumn();
            colTAKIP_VEKALET_UCRETI.VisibleIndex = 34;
            colTAKIP_VEKALET_UCRETI.FieldName = "TAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Name = "colTAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 35;
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Name = "colTAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colMAHSUP_TOPLAMI = new GridColumn();
            colMAHSUP_TOPLAMI.VisibleIndex = 36;
            colMAHSUP_TOPLAMI.FieldName = "MAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Name = "colMAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Visible = true;

            GridColumn colMAHSUP_TOPLAMI_DOVIZ_ID = new GridColumn();
            colMAHSUP_TOPLAMI_DOVIZ_ID.VisibleIndex = 37;
            colMAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Name = "colMAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colALACAK_TOPLAMI = new GridColumn();
            colALACAK_TOPLAMI.VisibleIndex = 38;
            colALACAK_TOPLAMI.FieldName = "ALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Name = "colALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Visible = true;

            GridColumn colALACAK_TOPLAMI_DOVIZ_ID = new GridColumn();
            colALACAK_TOPLAMI_DOVIZ_ID.VisibleIndex = 39;
            colALACAK_TOPLAMI_DOVIZ_ID.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Name = "colALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colFERAGAT_TOPLAMI = new GridColumn();
            colFERAGAT_TOPLAMI.VisibleIndex = 40;
            colFERAGAT_TOPLAMI.FieldName = "FERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Name = "colFERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Visible = true;

            GridColumn colFERAGAT_TOPLAMI_DOVIZ_ID = new GridColumn();
            colFERAGAT_TOPLAMI_DOVIZ_ID.VisibleIndex = 41;
            colFERAGAT_TOPLAMI_DOVIZ_ID.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Name = "colFERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_MIKTARI = new GridColumn();
            colPROTOKOL_MIKTARI.VisibleIndex = 42;
            colPROTOKOL_MIKTARI.FieldName = "PROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Name = "colPROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Visible = true;

            GridColumn colPROTOKOL_MIKTARI_DOVIZ_ID = new GridColumn();
            colPROTOKOL_MIKTARI_DOVIZ_ID.VisibleIndex = 43;
            colPROTOKOL_MIKTARI_DOVIZ_ID.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Name = "colPROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_TARIHI = new GridColumn();
            colPROTOKOL_TARIHI.VisibleIndex = 44;
            colPROTOKOL_TARIHI.FieldName = "PROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Name = "colPROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Visible = true;

            GridColumn colKARSILIK_TUTARI = new GridColumn();
            colKARSILIK_TUTARI.VisibleIndex = 45;
            colKARSILIK_TUTARI.FieldName = "KARSILIK_TUTARI";
            colKARSILIK_TUTARI.Name = "colKARSILIK_TUTARI";
            colKARSILIK_TUTARI.Visible = true;

            GridColumn colKARSILIK_TUTARI_DOVIZ_ID = new GridColumn();
            colKARSILIK_TUTARI_DOVIZ_ID.VisibleIndex = 46;
            colKARSILIK_TUTARI_DOVIZ_ID.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Name = "colKARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI = new GridColumn();
            colTUM_MASRAF_TOPLAMI.VisibleIndex = 47;
            colTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Name = "colTUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.VisibleIndex = 48;
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "colTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colHARC_TOPLAMI = new GridColumn();
            colHARC_TOPLAMI.VisibleIndex = 49;
            colHARC_TOPLAMI.FieldName = "HARC_TOPLAMI";
            colHARC_TOPLAMI.Name = "colHARC_TOPLAMI";
            colHARC_TOPLAMI.Visible = true;

            GridColumn colHARC_TOPLAMI_DOVIZ_ID = new GridColumn();
            colHARC_TOPLAMI_DOVIZ_ID.VisibleIndex = 50;
            colHARC_TOPLAMI_DOVIZ_ID.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Name = "colHARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI = new GridColumn();
            colTUM_VEKALET_TOPLAMI.VisibleIndex = 51;
            colTUM_VEKALET_TOPLAMI.FieldName = "TUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Name = "colTUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.VisibleIndex = 52;
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Name = "colTUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT.VisibleIndex = 53;
            colTAKIP_CIKIS_GAYRI_NAKIT.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Name = "colTAKIP_CIKIS_GAYRI_NAKIT";
            colTAKIP_CIKIS_GAYRI_NAKIT.Visible = true;

            GridColumn colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.VisibleIndex = 54;
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.FieldName = "TAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Name = "colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID";
            colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN = new GridColumn();
            colGAYRI_NAKIT_KALAN.VisibleIndex = 55;
            colGAYRI_NAKIT_KALAN.FieldName = "GAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Name = "colGAYRI_NAKIT_KALAN";
            colGAYRI_NAKIT_KALAN.Visible = true;

            GridColumn colGAYRI_NAKIT_KALAN_DOVIZ_ID = new GridColumn();
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.VisibleIndex = 56;
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.FieldName = "GAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Name = "colGAYRI_NAKIT_KALAN_DOVIZ_ID";
            colGAYRI_NAKIT_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 57;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colSUBE = new GridColumn();
            colSUBE.VisibleIndex = 58;
            colSUBE.FieldName = "SUBE";
            colSUBE.Name = "colSUBE";
            colSUBE.Visible = true;

            GridColumn colFOY_BIRIM = new GridColumn();
            colFOY_BIRIM.VisibleIndex = 59;
            colFOY_BIRIM.FieldName = "FOY_BIRIM";
            colFOY_BIRIM.Name = "colFOY_BIRIM";
            colFOY_BIRIM.Visible = true;

            GridColumn colFOY_YERI = new GridColumn();
            colFOY_YERI.VisibleIndex = 60;
            colFOY_YERI.FieldName = "FOY_YERI";
            colFOY_YERI.Name = "colFOY_YERI";
            colFOY_YERI.Visible = true;

            GridColumn colFOY_OZEL_DURUM = new GridColumn();
            colFOY_OZEL_DURUM.VisibleIndex = 61;
            colFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Name = "colFOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Visible = true;

            GridColumn colTAHSILAT_DURUM = new GridColumn();
            colTAHSILAT_DURUM.VisibleIndex = 62;
            colTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            colTAHSILAT_DURUM.Name = "colTAHSILAT_DURUM";
            colTAHSILAT_DURUM.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 63;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 64;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colKLASOR_1 = new GridColumn();
            colKLASOR_1.VisibleIndex = 65;
            colKLASOR_1.FieldName = "KLASOR_1";
            colKLASOR_1.Name = "colKLASOR_1";
            colKLASOR_1.Visible = true;

            GridColumn colKLASOR_2 = new GridColumn();
            colKLASOR_2.VisibleIndex = 66;
            colKLASOR_2.FieldName = "KLASOR_2";
            colKLASOR_2.Name = "colKLASOR_2";
            colKLASOR_2.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI = new GridColumn();
            colTUM_ODEME_TOPLAMI.VisibleIndex = 67;
            colTUM_ODEME_TOPLAMI.FieldName = "TUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Name = "colTUM_ODEME_TOPLAMI";
            colTUM_ODEME_TOPLAMI.Visible = true;

            GridColumn colTUM_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 68;
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTUM_ODEME_TOPLAMI_DOVIZ_ID";
            colTUM_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN.VisibleIndex = 69;
            colVEKALET_UCRETINDEN_ODENEN.FieldName = "VEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Name = "colVEKALET_UCRETINDEN_ODENEN";
            colVEKALET_UCRETINDEN_ODENEN.Visible = true;

            GridColumn colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID = new GridColumn();
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.VisibleIndex = 70;
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.FieldName = "VEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Name = "colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID";
            colVEKALET_UCRETINDEN_ODENEN_DOVIZ_ID.Visible = true;

            GridColumn colRISKTEN_KALAN = new GridColumn();
            colRISKTEN_KALAN.VisibleIndex = 71;
            colRISKTEN_KALAN.FieldName = "RISKTEN_KALAN";
            colRISKTEN_KALAN.Name = "colRISKTEN_KALAN";
            colRISKTEN_KALAN.Visible = true;

            GridColumn colRISKTEN_KALAN_DOVIZ_ID = new GridColumn();
            colRISKTEN_KALAN_DOVIZ_ID.VisibleIndex = 72;
            colRISKTEN_KALAN_DOVIZ_ID.FieldName = "RISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Name = "colRISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT.VisibleIndex = 73;
            colMASRAFA_YAPILAN_TAHSILAT.FieldName = "MASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Name = "colMASRAFA_YAPILAN_TAHSILAT";
            colMASRAFA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 74;
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "MASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colMASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT.VisibleIndex = 75;
            colANA_PARAYA_YAPILAN_TAHSILAT.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Name = "colANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 76;
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT.VisibleIndex = 77;
            colFAIZE_YAPILAN_TAHSILAT.FieldName = "FAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Name = "colFAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 78;
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "FAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI = new GridColumn();
            colTO_ODEME_TOPLAMI.VisibleIndex = 79;
            colTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Name = "colTO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTO_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 80;
            colTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_NO = new GridColumn();
            colSUBE_NO.VisibleIndex = 81;
            colSUBE_NO.FieldName = "SUBE_NO";
            colSUBE_NO.Name = "colSUBE_NO";
            colSUBE_NO.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 82;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR.VisibleIndex = 83;
            colAVUKATA_ODENEN_MIKTAR.FieldName = "AVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Name = "colAVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 84;
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "AVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR.VisibleIndex = 85;
            colALACAKLIYA_ODENEN_MIKTAR.FieldName = "ALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Name = "colALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 86;
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "ALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR = new GridColumn();
            colSATISTAN_GELEN_MIKTAR.VisibleIndex = 87;
            colSATISTAN_GELEN_MIKTAR.FieldName = "SATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Name = "colSATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.VisibleIndex = 88;
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.FieldName = "SATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Name = "colSATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSEGMENT_ID = new GridColumn();
            colSEGMENT_ID.VisibleIndex = 89;
            colSEGMENT_ID.FieldName = "SEGMENT_ID";
            colSEGMENT_ID.Name = "colSEGMENT_ID";
            colSEGMENT_ID.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 90;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colTAKIP_EDILEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDILEN_TARAF_KOD.VisibleIndex = 91;
            colTAKIP_EDILEN_TARAF_KOD.FieldName = "TAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Name = "colTAKIP_EDILEN_TARAF_KOD";
            colTAKIP_EDILEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 92;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colTAKIP_EDILEN_SIFAT = new GridColumn();
            colTAKIP_EDILEN_SIFAT.VisibleIndex = 93;
            colTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Name = "colTAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Visible = true;

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 94;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colTAKIP_EDEN_TARAF_KOD = new GridColumn();
            colTAKIP_EDEN_TARAF_KOD.VisibleIndex = 95;
            colTAKIP_EDEN_TARAF_KOD.FieldName = "TAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Name = "colTAKIP_EDEN_TARAF_KOD";
            colTAKIP_EDEN_TARAF_KOD.Visible = true;

            GridColumn colTAKIP_EDEN_SIFAT = new GridColumn();
            colTAKIP_EDEN_SIFAT.VisibleIndex = 96;
            colTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Name = "colTAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 97;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 98;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            #endregion

            dizi = new GridColumn[]
		{
            //colID,
            colFOY_NO,
            colDURUM,
			colTAKIP_EDEN,
			colTAKIP_EDEN_TARAF_KOD,
			colTAKIP_EDEN_SIFAT,
			colTAKIP_EDILEN,
			colTAKIP_EDILEN_TARAF_KOD,
			colTAKIP_EDILEN_SIFAT,
			colIZLEYEN,
			colSORUMLU,
			colTAKIP_TARIHI,
			colESAS_NO,
			colTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			colASIL_ALACAK,
			colASIL_ALACAK_DOVIZ_ID,
			colISLEMIS_FAIZ,
			colISLEMIS_FAIZ_DOVIZ_ID,
			colSON_HESAP_TARIHI,
			colTAKIP_CIKISI,
			colTAKIP_CIKISI_DOVIZ_ID,
			colKALAN,
			colKALAN_DOVIZ_ID,
			colRISK_MIKTARI,
			colRISK_MIKTARI_DOVIZ_ID,
			colSUBE_KOD_ID,
			colADLIYE,
			colNO,
			colTAKIP_CIKIS_GAYRI_NAKIT,
			colTAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID,
			colGAYRI_NAKIT_KALAN,
			colGAYRI_NAKIT_KALAN_DOVIZ_ID,
			colBANKA,
			colSUBE,
			colKREDI_GRUP,
			colKREDI_TIP,
			colKLASOR_1,
			colKLASOR_2,
            colANA_PARAYA_YAPILAN_TAHSILAT,
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID,
			colFAIZE_YAPILAN_TAHSILAT,
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID,
            colTUM_ODEME_TOPLAMI,
            colTUM_ODEME_TOPLAMI_DOVIZ_ID,
             colTO_ODEME_TOPLAMI,
            colTO_ODEME_TOPLAMI_DOVIZ_ID,
			};
            return dizi;
        }
    }
}