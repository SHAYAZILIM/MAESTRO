using System.Collections.Generic;
using AvukatProLib;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class IcraBirlesikDava
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

        public GridColumn[] GetGridColumns()
        {
            #region Field & Properties

            GridColumn colKAYNAK_ICRA_FOY_ID = new GridColumn();
            colKAYNAK_ICRA_FOY_ID.VisibleIndex = 0;
            colKAYNAK_ICRA_FOY_ID.FieldName = "KAYNAK_ICRA_FOY_ID";
            colKAYNAK_ICRA_FOY_ID.Name = "colKAYNAK_ICRA_FOY_ID";
            colKAYNAK_ICRA_FOY_ID.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 1;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colILISKI_TUR_ID = new GridColumn();
            colILISKI_TUR_ID.VisibleIndex = 2;
            colILISKI_TUR_ID.FieldName = "ILISKI_TUR_ID";
            colILISKI_TUR_ID.Name = "colILISKI_TUR_ID";
            colILISKI_TUR_ID.Visible = true;

            GridColumn colILISKI_TUR = new GridColumn();
            colILISKI_TUR.VisibleIndex = 3;
            colILISKI_TUR.FieldName = "ILISKI_TUR";
            colILISKI_TUR.Name = "colILISKI_TUR";
            colILISKI_TUR.Visible = true;

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 4;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colTAKIP_EDEN_TARAF_KODU = new GridColumn();
            colTAKIP_EDEN_TARAF_KODU.VisibleIndex = 5;
            colTAKIP_EDEN_TARAF_KODU.FieldName = "TAKIP_EDEN_TARAF_KODU";
            colTAKIP_EDEN_TARAF_KODU.Name = "colTAKIP_EDEN_TARAF_KODU";
            colTAKIP_EDEN_TARAF_KODU.Visible = true;

            GridColumn colTAKIP_EDEN_SIFAT = new GridColumn();
            colTAKIP_EDEN_SIFAT.VisibleIndex = 6;
            colTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Name = "colTAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 7;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colTAKIP_EDILEN_TARAF_KODU = new GridColumn();
            colTAKIP_EDILEN_TARAF_KODU.VisibleIndex = 8;
            colTAKIP_EDILEN_TARAF_KODU.FieldName = "TAKIP_EDILEN_TARAF_KODU";
            colTAKIP_EDILEN_TARAF_KODU.Name = "colTAKIP_EDILEN_TARAF_KODU";
            colTAKIP_EDILEN_TARAF_KODU.Visible = true;

            GridColumn colTAKIP_EDILEN_SIFAT = new GridColumn();
            colTAKIP_EDILEN_SIFAT.VisibleIndex = 9;
            colTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Name = "colTAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 10;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 11;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 12;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 13;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colREFERANS_NO2 = new GridColumn();
            colREFERANS_NO2.VisibleIndex = 14;
            colREFERANS_NO2.FieldName = "REFERANS_NO2";
            colREFERANS_NO2.Name = "colREFERANS_NO2";
            colREFERANS_NO2.Visible = true;

            GridColumn colREFERANS_NO3 = new GridColumn();
            colREFERANS_NO3.VisibleIndex = 15;
            colREFERANS_NO3.FieldName = "REFERANS_NO3";
            colREFERANS_NO3.Name = "colREFERANS_NO3";
            colREFERANS_NO3.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 16;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 17;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colADLI_BIRIM_ADLIYE = new GridColumn();
            colADLI_BIRIM_ADLIYE.VisibleIndex = 18;
            colADLI_BIRIM_ADLIYE.FieldName = "ADLI_BIRIM_ADLIYE";
            colADLI_BIRIM_ADLIYE.Name = "colADLI_BIRIM_ADLIYE";
            colADLI_BIRIM_ADLIYE.Visible = true;

            GridColumn colADLI_BIRIM_GOREV = new GridColumn();
            colADLI_BIRIM_GOREV.VisibleIndex = 19;
            colADLI_BIRIM_GOREV.FieldName = "ADLI_BIRIM_GOREV";
            colADLI_BIRIM_GOREV.Name = "colADLI_BIRIM_GOREV";
            colADLI_BIRIM_GOREV.Visible = true;

            GridColumn colADLI_BIRIM_NO = new GridColumn();
            colADLI_BIRIM_NO.VisibleIndex = 20;
            colADLI_BIRIM_NO.FieldName = "ADLI_BIRIM_NO";
            colADLI_BIRIM_NO.Name = "colADLI_BIRIM_NO";
            colADLI_BIRIM_NO.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 21;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 22;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 23;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 24;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 25;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.Visible = true;

            GridColumn colTAKIBIN_AVUKATA_INTIKAL_TARIHI = new GridColumn();
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 26;
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "colTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colASIL_ALACAK = new GridColumn();
            colASIL_ALACAK.VisibleIndex = 27;
            colASIL_ALACAK.FieldName = "ASIL_ALACAK";
            colASIL_ALACAK.Name = "colASIL_ALACAK";
            colASIL_ALACAK.Visible = true;

            GridColumn colASIL_ALACAK_DOVIZ_ID = new GridColumn();
            colASIL_ALACAK_DOVIZ_ID.VisibleIndex = 28;
            colASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Name = "colASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Visible = true;

            GridColumn colISLEMIS_FAIZ = new GridColumn();
            colISLEMIS_FAIZ.VisibleIndex = 29;
            colISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Name = "colISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Visible = true;

            GridColumn colISLEMIS_FAIZ_DOVIZ_ID = new GridColumn();
            colISLEMIS_FAIZ_DOVIZ_ID.VisibleIndex = 30;
            colISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Name = "colISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colSON_HESAP_TARIHI = new GridColumn();
            colSON_HESAP_TARIHI.VisibleIndex = 31;
            colSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Name = "colSON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Visible = true;

            GridColumn colTAKIP_CIKISI = new GridColumn();
            colTAKIP_CIKISI.VisibleIndex = 32;
            colTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            colTAKIP_CIKISI.Name = "colTAKIP_CIKISI";
            colTAKIP_CIKISI.Visible = true;

            GridColumn colTAKIP_CIKISI_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKISI_DOVIZ_ID.VisibleIndex = 33;
            colTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Name = "colTAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Visible = true;

            GridColumn colSONRAKI_FAIZ = new GridColumn();
            colSONRAKI_FAIZ.VisibleIndex = 34;
            colSONRAKI_FAIZ.FieldName = "SONRAKI_FAIZ";
            colSONRAKI_FAIZ.Name = "colSONRAKI_FAIZ";
            colSONRAKI_FAIZ.Visible = true;

            GridColumn colSONRAKI_FAIZ_DOVIZ_ID = new GridColumn();
            colSONRAKI_FAIZ_DOVIZ_ID.VisibleIndex = 35;
            colSONRAKI_FAIZ_DOVIZ_ID.FieldName = "SONRAKI_FAIZ_DOVIZ_ID";
            colSONRAKI_FAIZ_DOVIZ_ID.Name = "colSONRAKI_FAIZ_DOVIZ_ID";
            colSONRAKI_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colODEME_TOPLAMI = new GridColumn();
            colODEME_TOPLAMI.VisibleIndex = 36;
            colODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            colODEME_TOPLAMI.Name = "colODEME_TOPLAMI";
            colODEME_TOPLAMI.Visible = true;

            GridColumn colODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 37;
            colODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Name = "colODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI = new GridColumn();
            colTO_ODEME_TOPLAMI.VisibleIndex = 38;
            colTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Name = "colTO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTO_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 39;
            colTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN = new GridColumn();
            colKALAN.VisibleIndex = 40;
            colKALAN.FieldName = "KALAN";
            colKALAN.Name = "colKALAN";
            colKALAN.Visible = true;

            GridColumn colKALAN_DOVIZ_ID = new GridColumn();
            colKALAN_DOVIZ_ID.VisibleIndex = 41;
            colKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Name = "colKALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 42;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colTO_HESAP_TIP = new GridColumn();
            colTO_HESAP_TIP.VisibleIndex = 43;
            colTO_HESAP_TIP.FieldName = "TO_HESAP_TIP";
            colTO_HESAP_TIP.Name = "colTO_HESAP_TIP";
            colTO_HESAP_TIP.Visible = true;

            GridColumn colTS_HESAP_TIP = new GridColumn();
            colTS_HESAP_TIP.VisibleIndex = 44;
            colTS_HESAP_TIP.FieldName = "TS_HESAP_TIP";
            colTS_HESAP_TIP.Name = "colTS_HESAP_TIP";
            colTS_HESAP_TIP.Visible = true;

            GridColumn colKAPAMA_TARIHI = new GridColumn();
            colKAPAMA_TARIHI.VisibleIndex = 45;
            colKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            colKAPAMA_TARIHI.Name = "colKAPAMA_TARIHI";
            colKAPAMA_TARIHI.Visible = true;

            GridColumn colRISK_MIKTARI = new GridColumn();
            colRISK_MIKTARI.VisibleIndex = 46;
            colRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            colRISK_MIKTARI.Name = "colRISK_MIKTARI";
            colRISK_MIKTARI.Visible = true;

            GridColumn colRISK_MIKTARI_DOVIZ_ID = new GridColumn();
            colRISK_MIKTARI_DOVIZ_ID.VisibleIndex = 47;
            colRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Name = "colRISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colTS_MASRAF_HARC_TOPLAMI = new GridColumn();
            colTS_MASRAF_HARC_TOPLAMI.VisibleIndex = 48;
            colTS_MASRAF_HARC_TOPLAMI.FieldName = "TS_MASRAF_HARC_TOPLAMI";
            colTS_MASRAF_HARC_TOPLAMI.Name = "colTS_MASRAF_HARC_TOPLAMI";
            colTS_MASRAF_HARC_TOPLAMI.Visible = true;

            GridColumn colTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.VisibleIndex = 49;
            colTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_HARC_TOPLAMI_DOVIZ_ID";
            colTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.Name = "colTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID";
            colTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 50;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 51;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colTALEP_ADI = new GridColumn();
            colTALEP_ADI.VisibleIndex = 52;
            colTALEP_ADI.FieldName = "TALEP_ADI";
            colTALEP_ADI.Name = "colTALEP_ADI";
            colTALEP_ADI.Visible = true;

            GridColumn colHEDEF_ICRA_FOY_ID = new GridColumn();
            colHEDEF_ICRA_FOY_ID.VisibleIndex = 53;
            colHEDEF_ICRA_FOY_ID.FieldName = "HEDEF_ICRA_FOY_ID";
            colHEDEF_ICRA_FOY_ID.Name = "colHEDEF_ICRA_FOY_ID";
            colHEDEF_ICRA_FOY_ID.Visible = true;

            GridColumn colHEDEF_HAZIRLIK_ID = new GridColumn();
            colHEDEF_HAZIRLIK_ID.VisibleIndex = 54;
            colHEDEF_HAZIRLIK_ID.FieldName = "HEDEF_HAZIRLIK_ID";
            colHEDEF_HAZIRLIK_ID.Name = "colHEDEF_HAZIRLIK_ID";
            colHEDEF_HAZIRLIK_ID.Visible = true;

            GridColumn colHEDEF_RUCU_ID = new GridColumn();
            colHEDEF_RUCU_ID.VisibleIndex = 55;
            colHEDEF_RUCU_ID.FieldName = "HEDEF_RUCU_ID";
            colHEDEF_RUCU_ID.Name = "colHEDEF_RUCU_ID";
            colHEDEF_RUCU_ID.Visible = true;

            GridColumn colDAVA_DEGERI = new GridColumn();
            colDAVA_DEGERI.VisibleIndex = 56;
            colDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            colDAVA_DEGERI.Name = "colDAVA_DEGERI";
            colDAVA_DEGERI.Visible = true;

            GridColumn colDAVA_DEGERI_DOVIZ_ID = new GridColumn();
            colDAVA_DEGERI_DOVIZ_ID.VisibleIndex = 57;
            colDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            colDAVA_DEGERI_DOVIZ_ID.Name = "colDAVA_DEGERI_DOVIZ_ID";
            colDAVA_DEGERI_DOVIZ_ID.Visible = true;

            GridColumn colDAVA_TALEP = new GridColumn();
            colDAVA_TALEP.VisibleIndex = 58;
            colDAVA_TALEP.FieldName = "DAVA_TALEP";
            colDAVA_TALEP.Name = "colDAVA_TALEP";
            colDAVA_TALEP.Visible = true;

            GridColumn colBIRIM = new GridColumn();
            colBIRIM.VisibleIndex = 59;
            colBIRIM.FieldName = "BIRIM";
            colBIRIM.Name = "colBIRIM";
            colBIRIM.Visible = true;

            GridColumn colDAVA_FOY_NO = new GridColumn();
            colDAVA_FOY_NO.VisibleIndex = 60;
            colDAVA_FOY_NO.FieldName = "DAVA_FOY_NO";
            colDAVA_FOY_NO.Name = "colDAVA_FOY_NO";
            colDAVA_FOY_NO.Visible = true;

            GridColumn colDAVA_DURUM = new GridColumn();
            colDAVA_DURUM.VisibleIndex = 61;
            colDAVA_DURUM.FieldName = "DAVA_DURUM";
            colDAVA_DURUM.Name = "colDAVA_DURUM";
            colDAVA_DURUM.Visible = true;

            GridColumn colDAVA_TARIHI = new GridColumn();
            colDAVA_TARIHI.VisibleIndex = 62;
            colDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            colDAVA_TARIHI.Name = "colDAVA_TARIHI";
            colDAVA_TARIHI.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 63;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 64;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 65;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colDAVA_ESAS_NO = new GridColumn();
            colDAVA_ESAS_NO.VisibleIndex = 66;
            colDAVA_ESAS_NO.FieldName = "DAVA_ESAS_NO";
            colDAVA_ESAS_NO.Name = "colDAVA_ESAS_NO";
            colDAVA_ESAS_NO.Visible = true;

            GridColumn colAVUKATA_INTIKAL_TARIHI = new GridColumn();
            colAVUKATA_INTIKAL_TARIHI.VisibleIndex = 67;
            colAVUKATA_INTIKAL_TARIHI.FieldName = "AVUKATA_INTIKAL_TARIHI";
            colAVUKATA_INTIKAL_TARIHI.Name = "colAVUKATA_INTIKAL_TARIHI";
            colAVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colDavaAsama = new GridColumn();
            colDavaAsama.VisibleIndex = 68;
            colDavaAsama.FieldName = "DavaAsama";
            colDavaAsama.Name = "colDavaAsama";
            colDavaAsama.Visible = true;

            GridColumn colSorumluAvukat = new GridColumn();
            colSorumluAvukat.VisibleIndex = 69;
            colSorumluAvukat.FieldName = "DAVA_SORUMLU_AVUKAT";
            colSorumluAvukat.Name = "colSorumluAvukat";
            colSorumluAvukat.Visible = true;

            GridColumn colOLAY_SUC_TARIHI = new GridColumn();
            colOLAY_SUC_TARIHI.VisibleIndex = 70;
            colOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            colOLAY_SUC_TARIHI.Name = "colOLAY_SUC_TARIHI";
            colOLAY_SUC_TARIHI.Visible = true;

            GridColumn colTARAF_KODU = new GridColumn();
            colTARAF_KODU.VisibleIndex = 71;
            colTARAF_KODU.FieldName = "TARAF_KODU";
            colTARAF_KODU.Name = "colTARAF_KODU";
            colTARAF_KODU.Visible = true;

            GridColumn colTaraf = new GridColumn();
            colTaraf.VisibleIndex = 72;
            colTaraf.FieldName = "Taraf";
            colTaraf.Name = "colTaraf";
            colTaraf.Visible = true;

            GridColumn colTarafSifat = new GridColumn();
            colTarafSifat.VisibleIndex = 73;
            colTarafSifat.FieldName = "TarafSifat";
            colTarafSifat.Name = "colTarafSifat";
            colTarafSifat.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 74;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            GridColumn colDIGER_DAVA_NEDEN = new GridColumn();
            colDIGER_DAVA_NEDEN.VisibleIndex = 75;
            colDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            colDIGER_DAVA_NEDEN.Name = "colDIGER_DAVA_NEDEN";
            colDIGER_DAVA_NEDEN.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			//colKAYNAK_ICRA_FOY_ID,
			//colID,
			//colILISKI_TUR_ID,
			colILISKI_TUR,
			colTAKIP_EDEN,
			colTAKIP_EDEN_TARAF_KODU,
			colTAKIP_EDEN_SIFAT,
			colTAKIP_EDILEN,
			colTAKIP_EDILEN_TARAF_KODU,
			colTAKIP_EDILEN_SIFAT,
			colIZLEYEN,
			colSORUMLU,
			colFOY_NO,
			colREFERANS_NO,
			colREFERANS_NO2,
			colREFERANS_NO3,
			colDURUM,
			colTAKIP_TARIHI,
			colADLI_BIRIM_ADLIYE,
			colADLI_BIRIM_GOREV,
			colADLI_BIRIM_NO,
			colESAS_NO,
			colOZEL_KOD1,
			colOZEL_KOD2,
			colOZEL_KOD3,
			colOZEL_KOD4,
			colTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			colASIL_ALACAK,
			colASIL_ALACAK_DOVIZ_ID,
			colISLEMIS_FAIZ,
			colISLEMIS_FAIZ_DOVIZ_ID,
			colSON_HESAP_TARIHI,
			colTAKIP_CIKISI,
			colTAKIP_CIKISI_DOVIZ_ID,
			colSONRAKI_FAIZ,
			colSONRAKI_FAIZ_DOVIZ_ID,
			colODEME_TOPLAMI,
			colODEME_TOPLAMI_DOVIZ_ID,
			colTO_ODEME_TOPLAMI,
			colTO_ODEME_TOPLAMI_DOVIZ_ID,
			colKALAN,
			colKALAN_DOVIZ_ID,
			colACIKLAMA,
			colTO_HESAP_TIP,
			colTS_HESAP_TIP,
			colKAPAMA_TARIHI,
			colRISK_MIKTARI,
			colRISK_MIKTARI_DOVIZ_ID,
			colTS_MASRAF_HARC_TOPLAMI,
			colTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID,
			colSUBE_KOD_ID,
			colKONTROL_KIM_ID,
			colTALEP_ADI,

			//colHEDEF_ICRA_FOY_ID,
			//colHEDEF_HAZIRLIK_ID,
			//colHEDEF_RUCU_ID,
			colDAVA_DEGERI,
			colDAVA_DEGERI_DOVIZ_ID,
			colDAVA_TALEP,
			colBIRIM,
			colDAVA_FOY_NO,
			colDAVA_DURUM,
			colDAVA_TARIHI,
			colADLIYE,
			colNO,
			colGOREV,
			colDAVA_ESAS_NO,
			colAVUKATA_INTIKAL_TARIHI,
			colDavaAsama,
			colSorumluAvukat,
			colOLAY_SUC_TARIHI,
			colTARAF_KODU,
			colTaraf,
			colTarafSifat,
			colBOLUM,
			colDIGER_DAVA_NEDEN,
			};

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

            PivotGridField fieldKAYNAK_ICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAYNAK_ICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAYNAK_ICRA_FOY_ID.AreaIndex = 0;
            fieldKAYNAK_ICRA_FOY_ID.FieldName = "KAYNAK_ICRA_FOY_ID";
            fieldKAYNAK_ICRA_FOY_ID.Name = "fieldKAYNAK_ICRA_FOY_ID";
            fieldKAYNAK_ICRA_FOY_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 1;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldILISKI_TUR_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILISKI_TUR_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILISKI_TUR_ID.AreaIndex = 2;
            fieldILISKI_TUR_ID.FieldName = "ILISKI_TUR_ID";
            fieldILISKI_TUR_ID.Name = "fieldILISKI_TUR_ID";
            fieldILISKI_TUR_ID.Visible = false;

            PivotGridField fieldILISKI_TUR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILISKI_TUR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILISKI_TUR.AreaIndex = 3;
            fieldILISKI_TUR.FieldName = "ILISKI_TUR";
            fieldILISKI_TUR.Name = "fieldILISKI_TUR";
            fieldILISKI_TUR.Visible = false;

            PivotGridField fieldTAKIP_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN.AreaIndex = 4;
            fieldTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            fieldTAKIP_EDEN.Name = "fieldTAKIP_EDEN";
            fieldTAKIP_EDEN.Visible = false;

            PivotGridField fieldTAKIP_EDEN_TARAF_KODU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN_TARAF_KODU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN_TARAF_KODU.AreaIndex = 5;
            fieldTAKIP_EDEN_TARAF_KODU.FieldName = "TAKIP_EDEN_TARAF_KODU";
            fieldTAKIP_EDEN_TARAF_KODU.Name = "fieldTAKIP_EDEN_TARAF_KODU";
            fieldTAKIP_EDEN_TARAF_KODU.Visible = false;

            PivotGridField fieldTAKIP_EDEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN_SIFAT.AreaIndex = 6;
            fieldTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            fieldTAKIP_EDEN_SIFAT.Name = "fieldTAKIP_EDEN_SIFAT";
            fieldTAKIP_EDEN_SIFAT.Visible = false;

            PivotGridField fieldTAKIP_EDILEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN.AreaIndex = 7;
            fieldTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            fieldTAKIP_EDILEN.Name = "fieldTAKIP_EDILEN";
            fieldTAKIP_EDILEN.Visible = false;

            PivotGridField fieldTAKIP_EDILEN_TARAF_KODU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN_TARAF_KODU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN_TARAF_KODU.AreaIndex = 8;
            fieldTAKIP_EDILEN_TARAF_KODU.FieldName = "TAKIP_EDILEN_TARAF_KODU";
            fieldTAKIP_EDILEN_TARAF_KODU.Name = "fieldTAKIP_EDILEN_TARAF_KODU";
            fieldTAKIP_EDILEN_TARAF_KODU.Visible = false;

            PivotGridField fieldTAKIP_EDILEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN_SIFAT.AreaIndex = 9;
            fieldTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            fieldTAKIP_EDILEN_SIFAT.Name = "fieldTAKIP_EDILEN_SIFAT";
            fieldTAKIP_EDILEN_SIFAT.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 10;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 11;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 12;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 13;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldREFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO2.AreaIndex = 14;
            fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
            fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";
            fieldREFERANS_NO2.Visible = false;

            PivotGridField fieldREFERANS_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO3.AreaIndex = 15;
            fieldREFERANS_NO3.FieldName = "REFERANS_NO3";
            fieldREFERANS_NO3.Name = "fieldREFERANS_NO3";
            fieldREFERANS_NO3.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 16;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 17;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldADLI_BIRIM_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_ADLIYE.AreaIndex = 18;
            fieldADLI_BIRIM_ADLIYE.FieldName = "ADLI_BIRIM_ADLIYE";
            fieldADLI_BIRIM_ADLIYE.Name = "fieldADLI_BIRIM_ADLIYE";
            fieldADLI_BIRIM_ADLIYE.Visible = false;

            PivotGridField fieldADLI_BIRIM_GOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_GOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_GOREV.AreaIndex = 19;
            fieldADLI_BIRIM_GOREV.FieldName = "ADLI_BIRIM_GOREV";
            fieldADLI_BIRIM_GOREV.Name = "fieldADLI_BIRIM_GOREV";
            fieldADLI_BIRIM_GOREV.Visible = false;

            PivotGridField fieldADLI_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_NO.AreaIndex = 20;
            fieldADLI_BIRIM_NO.FieldName = "ADLI_BIRIM_NO";
            fieldADLI_BIRIM_NO.Name = "fieldADLI_BIRIM_NO";
            fieldADLI_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 21;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldOZEL_KOD1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD1.AreaIndex = 22;
            fieldOZEL_KOD1.FieldName = "OZEL_KOD1";
            fieldOZEL_KOD1.Name = "fieldOZEL_KOD1";
            fieldOZEL_KOD1.Visible = false;

            PivotGridField fieldOZEL_KOD2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD2.AreaIndex = 23;
            fieldOZEL_KOD2.FieldName = "OZEL_KOD2";
            fieldOZEL_KOD2.Name = "fieldOZEL_KOD2";
            fieldOZEL_KOD2.Visible = false;

            PivotGridField fieldOZEL_KOD3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD3.AreaIndex = 24;
            fieldOZEL_KOD3.FieldName = "OZEL_KOD3";
            fieldOZEL_KOD3.Name = "fieldOZEL_KOD3";
            fieldOZEL_KOD3.Visible = false;

            PivotGridField fieldOZEL_KOD4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD4.AreaIndex = 25;
            fieldOZEL_KOD4.FieldName = "OZEL_KOD4";
            fieldOZEL_KOD4.Name = "fieldOZEL_KOD4";
            fieldOZEL_KOD4.Visible = false;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 26;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 27;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 28;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldISLEMIS_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEMIS_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEMIS_FAIZ.AreaIndex = 29;
            fieldISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            fieldISLEMIS_FAIZ.Name = "fieldISLEMIS_FAIZ";
            fieldISLEMIS_FAIZ.Visible = false;

            PivotGridField fieldISLEMIS_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEMIS_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEMIS_FAIZ_DOVIZ_ID.AreaIndex = 30;
            fieldISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            fieldISLEMIS_FAIZ_DOVIZ_ID.Name = "fieldISLEMIS_FAIZ_DOVIZ_ID";
            fieldISLEMIS_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldSON_HESAP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSON_HESAP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSON_HESAP_TARIHI.AreaIndex = 31;
            fieldSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Name = "fieldSON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI.AreaIndex = 32;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 33;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSONRAKI_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_FAIZ.AreaIndex = 34;
            fieldSONRAKI_FAIZ.FieldName = "SONRAKI_FAIZ";
            fieldSONRAKI_FAIZ.Name = "fieldSONRAKI_FAIZ";
            fieldSONRAKI_FAIZ.Visible = false;

            PivotGridField fieldSONRAKI_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_FAIZ_DOVIZ_ID.AreaIndex = 35;
            fieldSONRAKI_FAIZ_DOVIZ_ID.FieldName = "SONRAKI_FAIZ_DOVIZ_ID";
            fieldSONRAKI_FAIZ_DOVIZ_ID.Name = "fieldSONRAKI_FAIZ_DOVIZ_ID";
            fieldSONRAKI_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI.AreaIndex = 36;
            fieldODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Name = "fieldODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Visible = false;

            PivotGridField fieldODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 37;
            fieldODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Name = "fieldODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 38;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 39;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 40;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 41;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 42;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldTO_HESAP_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_HESAP_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_HESAP_TIP.AreaIndex = 43;
            fieldTO_HESAP_TIP.FieldName = "TO_HESAP_TIP";
            fieldTO_HESAP_TIP.Name = "fieldTO_HESAP_TIP";
            fieldTO_HESAP_TIP.Visible = false;

            PivotGridField fieldTS_HESAP_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_HESAP_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_HESAP_TIP.AreaIndex = 44;
            fieldTS_HESAP_TIP.FieldName = "TS_HESAP_TIP";
            fieldTS_HESAP_TIP.Name = "fieldTS_HESAP_TIP";
            fieldTS_HESAP_TIP.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 45;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 46;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 47;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_HARC_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_HARC_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_HARC_TOPLAMI.AreaIndex = 48;
            fieldTS_MASRAF_HARC_TOPLAMI.FieldName = "TS_MASRAF_HARC_TOPLAMI";
            fieldTS_MASRAF_HARC_TOPLAMI.Name = "fieldTS_MASRAF_HARC_TOPLAMI";
            fieldTS_MASRAF_HARC_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.AreaIndex = 49;
            fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_HARC_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 50;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 51;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 52;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldHEDEF_ICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHEDEF_ICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHEDEF_ICRA_FOY_ID.AreaIndex = 53;
            fieldHEDEF_ICRA_FOY_ID.FieldName = "HEDEF_ICRA_FOY_ID";
            fieldHEDEF_ICRA_FOY_ID.Name = "fieldHEDEF_ICRA_FOY_ID";
            fieldHEDEF_ICRA_FOY_ID.Visible = false;

            PivotGridField fieldHEDEF_HAZIRLIK_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHEDEF_HAZIRLIK_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHEDEF_HAZIRLIK_ID.AreaIndex = 54;
            fieldHEDEF_HAZIRLIK_ID.FieldName = "HEDEF_HAZIRLIK_ID";
            fieldHEDEF_HAZIRLIK_ID.Name = "fieldHEDEF_HAZIRLIK_ID";
            fieldHEDEF_HAZIRLIK_ID.Visible = false;

            PivotGridField fieldHEDEF_RUCU_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHEDEF_RUCU_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHEDEF_RUCU_ID.AreaIndex = 55;
            fieldHEDEF_RUCU_ID.FieldName = "HEDEF_RUCU_ID";
            fieldHEDEF_RUCU_ID.Name = "fieldHEDEF_RUCU_ID";
            fieldHEDEF_RUCU_ID.Visible = false;

            PivotGridField fieldDAVA_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI.AreaIndex = 56;
            fieldDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            fieldDAVA_DEGERI.Name = "fieldDAVA_DEGERI";
            fieldDAVA_DEGERI.Visible = false;

            PivotGridField fieldDAVA_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 57;
            fieldDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Name = "fieldDAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 58;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldBIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM.AreaIndex = 59;
            fieldBIRIM.FieldName = "BIRIM";
            fieldBIRIM.Name = "fieldBIRIM";
            fieldBIRIM.Visible = false;

            PivotGridField fieldDAVA_FOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_FOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_FOY_NO.AreaIndex = 60;
            fieldDAVA_FOY_NO.FieldName = "DAVA_FOY_NO";
            fieldDAVA_FOY_NO.Name = "fieldDAVA_FOY_NO";
            fieldDAVA_FOY_NO.Visible = false;

            PivotGridField fieldDAVA_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DURUM.AreaIndex = 61;
            fieldDAVA_DURUM.FieldName = "DAVA_DURUM";
            fieldDAVA_DURUM.Name = "fieldDAVA_DURUM";
            fieldDAVA_DURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 62;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 63;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 64;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 65;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldDAVA_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_ESAS_NO.AreaIndex = 66;
            fieldDAVA_ESAS_NO.FieldName = "DAVA_ESAS_NO";
            fieldDAVA_ESAS_NO.Name = "fieldDAVA_ESAS_NO";
            fieldDAVA_ESAS_NO.Visible = false;

            PivotGridField fieldAVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAVUKATA_INTIKAL_TARIHI.AreaIndex = 67;
            fieldAVUKATA_INTIKAL_TARIHI.FieldName = "AVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Name = "fieldAVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldDavaAsama = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDavaAsama.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDavaAsama.AreaIndex = 68;
            fieldDavaAsama.FieldName = "DavaAsama";
            fieldDavaAsama.Name = "fieldDavaAsama";
            fieldDavaAsama.Visible = false;

            PivotGridField fieldSorumluAvukat = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSorumluAvukat.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSorumluAvukat.AreaIndex = 69;
            fieldSorumluAvukat.FieldName = "SorumluAvukat";
            fieldSorumluAvukat.Name = "fieldSorumluAvukat";
            fieldSorumluAvukat.Visible = false;

            PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOLAY_SUC_TARIHI.AreaIndex = 70;
            fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Visible = false;

            PivotGridField fieldTARAF_KODU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARAF_KODU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARAF_KODU.AreaIndex = 71;
            fieldTARAF_KODU.FieldName = "TARAF_KODU";
            fieldTARAF_KODU.Name = "fieldTARAF_KODU";
            fieldTARAF_KODU.Visible = false;

            PivotGridField fieldTaraf = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTaraf.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTaraf.AreaIndex = 72;
            fieldTaraf.FieldName = "Taraf";
            fieldTaraf.Name = "fieldTaraf";
            fieldTaraf.Visible = false;

            PivotGridField fieldTarafSifat = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTarafSifat.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTarafSifat.AreaIndex = 73;
            fieldTarafSifat.FieldName = "TarafSifat";
            fieldTarafSifat.Name = "fieldTarafSifat";
            fieldTarafSifat.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 74;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 75;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldKAYNAK_ICRA_FOY_ID,
			fieldID,
			fieldILISKI_TUR_ID,
			fieldILISKI_TUR,
			fieldTAKIP_EDEN,
			fieldTAKIP_EDEN_TARAF_KODU,
			fieldTAKIP_EDEN_SIFAT,
			fieldTAKIP_EDILEN,
			fieldTAKIP_EDILEN_TARAF_KODU,
			fieldTAKIP_EDILEN_SIFAT,
			fieldIZLEYEN,
			fieldSORUMLU,
			fieldFOY_NO,
			fieldREFERANS_NO,
			fieldREFERANS_NO2,
			fieldREFERANS_NO3,
			fieldDURUM,
			fieldTAKIP_TARIHI,
			fieldADLI_BIRIM_ADLIYE,
			fieldADLI_BIRIM_GOREV,
			fieldADLI_BIRIM_NO,
			fieldESAS_NO,
			fieldOZEL_KOD1,
			fieldOZEL_KOD2,
			fieldOZEL_KOD3,
			fieldOZEL_KOD4,
			fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			fieldASIL_ALACAK,
			fieldASIL_ALACAK_DOVIZ_ID,
			fieldISLEMIS_FAIZ,
			fieldISLEMIS_FAIZ_DOVIZ_ID,
			fieldSON_HESAP_TARIHI,
			fieldTAKIP_CIKISI,
			fieldTAKIP_CIKISI_DOVIZ_ID,
			fieldSONRAKI_FAIZ,
			fieldSONRAKI_FAIZ_DOVIZ_ID,
			fieldODEME_TOPLAMI,
			fieldODEME_TOPLAMI_DOVIZ_ID,
			fieldTO_ODEME_TOPLAMI,
			fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
			fieldKALAN,
			fieldKALAN_DOVIZ_ID,
			fieldACIKLAMA,
			fieldTO_HESAP_TIP,
			fieldTS_HESAP_TIP,
			fieldKAPAMA_TARIHI,
			fieldRISK_MIKTARI,
			fieldRISK_MIKTARI_DOVIZ_ID,
			fieldTS_MASRAF_HARC_TOPLAMI,
			fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID,
			fieldSUBE_KOD_ID,
			fieldKONTROL_KIM_ID,
			fieldTALEP_ADI,
			fieldHEDEF_ICRA_FOY_ID,
			fieldHEDEF_HAZIRLIK_ID,
			fieldHEDEF_RUCU_ID,
			fieldDAVA_DEGERI,
			fieldDAVA_DEGERI_DOVIZ_ID,
			fieldDAVA_TALEP,
			fieldBIRIM,
			fieldDAVA_FOY_NO,
			fieldDAVA_DURUM,
			fieldDAVA_TARIHI,
			fieldADLIYE,
			fieldNO,
			fieldGOREV,
			fieldDAVA_ESAS_NO,
			fieldAVUKATA_INTIKAL_TARIHI,
			fieldDavaAsama,
			fieldSorumluAvukat,
			fieldOLAY_SUC_TARIHI,
			fieldTARAF_KODU,
			fieldTaraf,
			fieldTarafSifat,
			fieldBOLUM,
			fieldDIGER_DAVA_NEDEN,
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

        private Dictionary<string, string> GetCaptionDictinory()
        {
            Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

            #region Özelleştirme

            CompInfo cm = new CompInfo();
            string RefNo, RefNo2, refNo3, OzelKod1, OzelKod2, OzelKod3, OzelKod4, ANRefNo, ANRefNo2, ANRefNo3;
            var icrarefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetIcraOzelKodReferans(cm.ConStr);
            if (string.IsNullOrEmpty(icrarefoz.IcraReferans1))
                RefNo = "Ref No";
            else
                RefNo = icrarefoz.IcraReferans1;

            if (string.IsNullOrEmpty(icrarefoz.IcraReferans2))
                RefNo2 = "Ref No2";
            else
                RefNo2 = icrarefoz.IcraReferans2;

            if (string.IsNullOrEmpty(icrarefoz.IcraReferans3))
                refNo3 = "Ref No3";
            else
                refNo3 = icrarefoz.IcraReferans3;

            if (string.IsNullOrEmpty(icrarefoz.IcraOzelKod1))
                OzelKod1 = "Özel Kod1";
            else
                OzelKod1 = icrarefoz.IcraOzelKod1;

            if (string.IsNullOrEmpty(icrarefoz.IcraOzelKod2))
                OzelKod2 = "Özel Kod2";
            else
                OzelKod2 = icrarefoz.IcraOzelKod2;

            if (string.IsNullOrEmpty(icrarefoz.IcraOzelKod3))
                OzelKod3 = "Özel Kod3";
            else
                OzelKod3 = icrarefoz.IcraOzelKod3;

            if (string.IsNullOrEmpty(icrarefoz.IcraOzelKod4))
                OzelKod4 = "Özel Kod4";
            else
                OzelKod4 = icrarefoz.IcraOzelKod4;
            if (string.IsNullOrEmpty(icrarefoz.IcraANrefarans1))
                ANRefNo = "Kredi Kartı Numarası";
            else
                ANRefNo = icrarefoz.IcraANrefarans1;
            if (string.IsNullOrEmpty(icrarefoz.IcraANreferans2))
                ANRefNo2 = "Hesap No";
            else
                ANRefNo2 = icrarefoz.IcraANreferans2;
            if (string.IsNullOrEmpty(icrarefoz.IcraANreferans3))
                ANRefNo3 = "Kebir";
            else
                ANRefNo3 = icrarefoz.IcraANreferans3;

            #endregion Özelleştirme

            #region Caption Edit

            dicFieldCaption.Add("KAYNAK_ICRA_FOY_ID", "");
            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("ILISKI_TUR_ID", "");
            dicFieldCaption.Add("ILISKI_TUR", "İlişki Türü");
            dicFieldCaption.Add("TAKIP_EDEN", "Takip Eden");
            dicFieldCaption.Add("TAKIP_EDEN_TARAF_KODU", "Takip Eden T.K");
            dicFieldCaption.Add("TAKIP_EDEN_SIFAT", "Takip Eden Sıfat");
            dicFieldCaption.Add("TAKIP_EDILEN", "Takip Edilen");
            dicFieldCaption.Add("TAKIP_EDILEN_TARAF_KODU", "Takip Edilen T.K.");
            dicFieldCaption.Add("TAKIP_EDILEN_SIFAT", "Takip Edilen Sıfat");
            dicFieldCaption.Add("IZLEYEN", "İzleyen");
            dicFieldCaption.Add("SORUMLU", "Sorumlu");
            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("REFERANS_NO", RefNo);
            dicFieldCaption.Add("REFERANS_NO2", RefNo2);
            dicFieldCaption.Add("REFERANS_NO3", refNo3);
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("TAKIP_TARIHI", "Takip T.");
            dicFieldCaption.Add("ADLI_BIRIM_ADLIYE", "Adliye");
            dicFieldCaption.Add("ADLI_BIRIM_GOREV", "Görev");
            dicFieldCaption.Add("ADLI_BIRIM_NO", "Birim No");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("OZEL_KOD1", OzelKod1);
            dicFieldCaption.Add("OZEL_KOD2", OzelKod2);
            dicFieldCaption.Add("OZEL_KOD3", OzelKod3);
            dicFieldCaption.Add("OZEL_KOD4", OzelKod4);
            dicFieldCaption.Add("TAKIBIN_AVUKATA_INTIKAL_TARIHI", "İntikal T.");
            dicFieldCaption.Add("ASIL_ALACAK", "Asıl Alacak");
            dicFieldCaption.Add("ISLEMIS_FAIZ", "İşlenmiş Faiz");
            dicFieldCaption.Add("SON_HESAP_TARIHI", "Son Hesap T.");
            dicFieldCaption.Add("TAKIP_CIKISI", "Takip Çıkışı");
            dicFieldCaption.Add("SONRAKI_FAIZ", "Sonraki Faiz");
            dicFieldCaption.Add("ODEME_TOPLAMI", "Ödeme Toplamı");
            dicFieldCaption.Add("TO_ODEME_TOPLAMI", "T.Ö. Ödeme Toplamı");
            dicFieldCaption.Add("KALAN", "Kalan");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("TO_HESAP_TIP", "T.Ö Hesap Tip");
            dicFieldCaption.Add("TS_HESAP_TIP", "T.S. Hesap Tip");
            dicFieldCaption.Add("KAPAMA_TARIHI", "Kapama T.");
            dicFieldCaption.Add("RISK_MIKTARI", "Risk Miktarı");
            dicFieldCaption.Add("TS_MASRAF_HARC_TOPLAMI", "T.S Masraf Harç Toplamı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("TALEP_ADI", "Talep Adı");
            dicFieldCaption.Add("HEDEF_ICRA_FOY_ID", "");
            dicFieldCaption.Add("HEDEF_HAZIRLIK_ID", "");
            dicFieldCaption.Add("HEDEF_RUCU_ID", "");
            dicFieldCaption.Add("DAVA_DEGERI", "Dava Değeri");
            dicFieldCaption.Add("DAVA_TALEP", "Dava Talep");
            dicFieldCaption.Add("BIRIM", "Birim");
            dicFieldCaption.Add("DAVA_FOY_NO", "Dava Dosya No");
            dicFieldCaption.Add("DAVA_DURUM", "Dava Durum");
            dicFieldCaption.Add("DAVA_TARIHI", "Dava T.");
            dicFieldCaption.Add("ADLIYE", "Mahkeme");
            dicFieldCaption.Add("NO", "No");
            dicFieldCaption.Add("GOREV", "Gorev");
            dicFieldCaption.Add("DAVA_ESAS_NO", "Dava Esas No");
            dicFieldCaption.Add("AVUKATA_INTIKAL_TARIHI", "İntikal T.");
            dicFieldCaption.Add("DavaAsama", "Dava Aşama");
            dicFieldCaption.Add("SorumluAvukat", "Sorumlu");
            dicFieldCaption.Add("OLAY_SUC_TARIHI", "Olay Suç T.");
            dicFieldCaption.Add("TARAF_KODU", "T.K.");
            dicFieldCaption.Add("Taraf", "Taraf");
            dicFieldCaption.Add("TarafSifat", "Taraf Sıfat");
            dicFieldCaption.Add("BOLUM", "Bölüm");
            dicFieldCaption.Add("DIGER_DAVA_NEDEN", "Diğer Dava Neden");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            //RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

            //Inits.DovizTipGetir(rlueDoviz);

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("DovizId", InitsEx.DovizTipGetir);

            // sozluk.Add("KAYNAK_ICRA_FOY_ID", Item);
            //sozluk.Add("ILISKI_TUR_ID", Item);
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);

            //sozluk.Add("HEDEF_ICRA_FOY_ID", Item);
            // sozluk.Add("HEDEF_HAZIRLIK_ID", Item);
            // sozluk.Add("HEDEF_RUCU_ID", Item);
            sozluk.Add("KALAN", InitsEx.ParaBicimiAyarla);
            sozluk.Add("RISK_MIKTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("RISK_MIKTARI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("DAVA_DEGERI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("DAVA_DEGERI_DOVIZ_ID", InitsEx.DovizTipGetir);

            #endregion Add item

            return sozluk;
        }
    }
}