using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class mahkemeHukum
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

            GridColumn colASAMA_ADI = new GridColumn();
            colASAMA_ADI.VisibleIndex = -1;
            colASAMA_ADI.FieldName = "ASAMA_ADI";
            colASAMA_ADI.Name = "colASAMA_ADI";
            colASAMA_ADI.Visible = false;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 1;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 2;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colDAVA_TARIHI = new GridColumn();
            colDAVA_TARIHI.VisibleIndex = 3;
            colDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            colDAVA_TARIHI.Name = "colDAVA_TARIHI";
            colDAVA_TARIHI.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 4;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colREFERANS_NO2 = new GridColumn();
            colREFERANS_NO2.VisibleIndex = 5;
            colREFERANS_NO2.FieldName = "REFERANS_NO2";
            colREFERANS_NO2.Name = "colREFERANS_NO2";
            colREFERANS_NO2.Visible = true;

            GridColumn colREFERANS_NO3 = new GridColumn();
            colREFERANS_NO3.VisibleIndex = 6;
            colREFERANS_NO3.FieldName = "REFERANS_NO3";
            colREFERANS_NO3.Name = "colREFERANS_NO3";
            colREFERANS_NO3.Visible = true;

            GridColumn colOzelKod1 = new GridColumn();
            colOzelKod1.VisibleIndex = 7;
            colOzelKod1.FieldName = "OzelKod1";
            colOzelKod1.Name = "colOzelKod1";
            colOzelKod1.Visible = true;

            GridColumn colOzelKod2 = new GridColumn();
            colOzelKod2.VisibleIndex = 8;
            colOzelKod2.FieldName = "OzelKod2";
            colOzelKod2.Name = "colOzelKod2";
            colOzelKod2.Visible = true;

            GridColumn colOzelKod3 = new GridColumn();
            colOzelKod3.VisibleIndex = 9;
            colOzelKod3.FieldName = "OzelKod3";
            colOzelKod3.Name = "colOzelKod3";
            colOzelKod3.Visible = true;

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

            GridColumn colOzelKod4 = new GridColumn();
            colOzelKod4.VisibleIndex = 12;
            colOzelKod4.FieldName = "OzelKod4";
            colOzelKod4.Name = "colOzelKod4";
            colOzelKod4.Visible = true;

            GridColumn colDAVA_TALEP = new GridColumn();
            colDAVA_TALEP.VisibleIndex = 13;
            colDAVA_TALEP.FieldName = "DAVA_TALEP";
            colDAVA_TALEP.Name = "colDAVA_TALEP";
            colDAVA_TALEP.Visible = true;

            GridColumn colDAVA_ADI = new GridColumn();
            colDAVA_ADI.VisibleIndex = 14;
            colDAVA_ADI.FieldName = "DAVA_ADI";
            colDAVA_ADI.Name = "colDAVA_ADI";
            colDAVA_ADI.Visible = true;

            GridColumn colDIGER_DAVA_NEDEN = new GridColumn();
            colDIGER_DAVA_NEDEN.VisibleIndex = 15;
            colDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            colDIGER_DAVA_NEDEN.Name = "colDIGER_DAVA_NEDEN";
            colDIGER_DAVA_NEDEN.Visible = true;

            GridColumn colOLAY_SUC_TARIHI = new GridColumn();
            colOLAY_SUC_TARIHI.VisibleIndex = 16;
            colOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            colOLAY_SUC_TARIHI.Name = "colOLAY_SUC_TARIHI";
            colOLAY_SUC_TARIHI.Visible = true;

            GridColumn colDUZENLEME_TARIHI = new GridColumn();
            colDUZENLEME_TARIHI.VisibleIndex = 17;
            colDUZENLEME_TARIHI.FieldName = "DUZENLEME_TARIHI";
            colDUZENLEME_TARIHI.Name = "colDUZENLEME_TARIHI";
            colDUZENLEME_TARIHI.Visible = true;

            GridColumn colDAVA_EDILEN_TUTAR = new GridColumn();
            colDAVA_EDILEN_TUTAR.VisibleIndex = 18;
            colDAVA_EDILEN_TUTAR.FieldName = "DAVA_EDILEN_TUTAR";
            colDAVA_EDILEN_TUTAR.Name = "colDAVA_EDILEN_TUTAR";
            colDAVA_EDILEN_TUTAR.Visible = true;

            GridColumn colDAVA_EDILEN_TUTAR_DOVIZ_ID = new GridColumn();
            colDAVA_EDILEN_TUTAR_DOVIZ_ID.VisibleIndex = 19;
            colDAVA_EDILEN_TUTAR_DOVIZ_ID.FieldName = "DAVA_EDILEN_TUTAR_DOVIZ_ID";
            colDAVA_EDILEN_TUTAR_DOVIZ_ID.Name = "colDAVA_EDILEN_TUTAR_DOVIZ_ID";
            colDAVA_EDILEN_TUTAR_DOVIZ_ID.Visible = true;

            GridColumn colKESINLESME_TARIHI = new GridColumn();
            colKESINLESME_TARIHI.VisibleIndex = 20;
            colKESINLESME_TARIHI.FieldName = "KESINLESME_TARIHI";
            colKESINLESME_TARIHI.Name = "colKESINLESME_TARIHI";
            colKESINLESME_TARIHI.Visible = true;

            GridColumn colTARAF_SIFAT = new GridColumn();
            colTARAF_SIFAT.VisibleIndex = 21;
            colTARAF_SIFAT.FieldName = "TARAF_SIFAT";
            colTARAF_SIFAT.Name = "colTARAF_SIFAT";
            colTARAF_SIFAT.Visible = true;

            GridColumn colDAVA_TARAF = new GridColumn();
            colDAVA_TARAF.VisibleIndex = 22;
            colDAVA_TARAF.FieldName = "DAVA_TARAF";
            colDAVA_TARAF.Name = "colDAVA_TARAF";
            colDAVA_TARAF.Visible = true;

            GridColumn colSORUMLU_OLUNAN_MIKTAR = new GridColumn();
            colSORUMLU_OLUNAN_MIKTAR.VisibleIndex = 23;
            colSORUMLU_OLUNAN_MIKTAR.FieldName = "SORUMLU_OLUNAN_MIKTAR";
            colSORUMLU_OLUNAN_MIKTAR.Name = "colSORUMLU_OLUNAN_MIKTAR";
            colSORUMLU_OLUNAN_MIKTAR.Visible = true;

            GridColumn colSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = new GridColumn();
            colSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.VisibleIndex = 24;
            colSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.FieldName = "SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID";
            colSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.Name = "colSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID";
            colSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 25;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colHUKUM = new GridColumn();
            colHUKUM.VisibleIndex = 26;
            colHUKUM.FieldName = "HUKUM";
            colHUKUM.Name = "colHUKUM";
            colHUKUM.Visible = true;

            GridColumn colHUKUM_TARIHI = new GridColumn();
            colHUKUM_TARIHI.VisibleIndex = 27;
            colHUKUM_TARIHI.FieldName = "HUKUM_TARIHI";
            colHUKUM_TARIHI.Name = "colHUKUM_TARIHI";
            colHUKUM_TARIHI.Visible = true;

            GridColumn colKARAR_NO = new GridColumn();
            colKARAR_NO.VisibleIndex = 28;
            colKARAR_NO.FieldName = "KARAR_NO";
            colKARAR_NO.Name = "colKARAR_NO";
            colKARAR_NO.Visible = true;

            GridColumn colGEREKCE = new GridColumn();
            colGEREKCE.VisibleIndex = 29;
            colGEREKCE.FieldName = "GEREKCE";
            colGEREKCE.Name = "colGEREKCE";
            colGEREKCE.Visible = true;

            GridColumn colHUKUM_DEGER = new GridColumn();
            colHUKUM_DEGER.VisibleIndex = 30;
            colHUKUM_DEGER.FieldName = "HUKUM_DEGER";
            colHUKUM_DEGER.Name = "colHUKUM_DEGER";
            colHUKUM_DEGER.Visible = true;

            GridColumn colHUKUM_DEGER_DOVIZ_ID = new GridColumn();
            colHUKUM_DEGER_DOVIZ_ID.VisibleIndex = 31;
            colHUKUM_DEGER_DOVIZ_ID.FieldName = "HUKUM_DEGER_DOVIZ_ID";
            colHUKUM_DEGER_DOVIZ_ID.Name = "colHUKUM_DEGER_DOVIZ_ID";
            colHUKUM_DEGER_DOVIZ_ID.Visible = true;

            GridColumn colMUSADERE_DEGER = new GridColumn();
            colMUSADERE_DEGER.VisibleIndex = 32;
            colMUSADERE_DEGER.FieldName = "MUSADERE_DEGER";
            colMUSADERE_DEGER.Name = "colMUSADERE_DEGER";
            colMUSADERE_DEGER.Visible = true;

            GridColumn colMUSADERE_DEGER_DOVIZ_ID = new GridColumn();
            colMUSADERE_DEGER_DOVIZ_ID.VisibleIndex = 33;
            colMUSADERE_DEGER_DOVIZ_ID.FieldName = "MUSADERE_DEGER_DOVIZ_ID";
            colMUSADERE_DEGER_DOVIZ_ID.Name = "colMUSADERE_DEGER_DOVIZ_ID";
            colMUSADERE_DEGER_DOVIZ_ID.Visible = true;

            GridColumn colMAHKUMIYET_YIL = new GridColumn();
            colMAHKUMIYET_YIL.VisibleIndex = 34;
            colMAHKUMIYET_YIL.FieldName = "MAHKUMIYET_YIL";
            colMAHKUMIYET_YIL.Name = "colMAHKUMIYET_YIL";
            colMAHKUMIYET_YIL.Visible = true;

            GridColumn colMAHKUMIYET_AY = new GridColumn();
            colMAHKUMIYET_AY.VisibleIndex = 35;
            colMAHKUMIYET_AY.FieldName = "MAHKUMIYET_AY";
            colMAHKUMIYET_AY.Name = "colMAHKUMIYET_AY";
            colMAHKUMIYET_AY.Visible = true;

            GridColumn colMAHKUMIYET_GUN = new GridColumn();
            colMAHKUMIYET_GUN.VisibleIndex = 36;
            colMAHKUMIYET_GUN.FieldName = "MAHKUMIYET_GUN";
            colMAHKUMIYET_GUN.Name = "colMAHKUMIYET_GUN";
            colMAHKUMIYET_GUN.Visible = true;

            GridColumn colCEZA_ERTELENDI = new GridColumn();
            colCEZA_ERTELENDI.VisibleIndex = 37;
            colCEZA_ERTELENDI.FieldName = "CEZA_ERTELENDI";
            colCEZA_ERTELENDI.Name = "colCEZA_ERTELENDI";
            colCEZA_ERTELENDI.Visible = true;

            GridColumn colPARAYA_CEVRILDI = new GridColumn();
            colPARAYA_CEVRILDI.VisibleIndex = 38;
            colPARAYA_CEVRILDI.FieldName = "PARAYA_CEVRILDI";
            colPARAYA_CEVRILDI.Name = "colPARAYA_CEVRILDI";
            colPARAYA_CEVRILDI.Visible = true;

            GridColumn colPARAYA_CEVRILEN_MIKTAR = new GridColumn();
            colPARAYA_CEVRILEN_MIKTAR.VisibleIndex = 39;
            colPARAYA_CEVRILEN_MIKTAR.FieldName = "PARAYA_CEVRILEN_MIKTAR";
            colPARAYA_CEVRILEN_MIKTAR.Name = "colPARAYA_CEVRILEN_MIKTAR";
            colPARAYA_CEVRILEN_MIKTAR.Visible = true;

            GridColumn colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.VisibleIndex = 40;
            colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.FieldName = "PARAYA_CEVRILEN_MIKTAR_DOVIZ_ID";
            colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.Name = "colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID";
            colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colMESLEK_ICRA_MEN_TIP = new GridColumn();
            colMESLEK_ICRA_MEN_TIP.VisibleIndex = 41;
            colMESLEK_ICRA_MEN_TIP.FieldName = "MESLEK_ICRA_MEN_TIP";
            colMESLEK_ICRA_MEN_TIP.Name = "colMESLEK_ICRA_MEN_TIP";
            colMESLEK_ICRA_MEN_TIP.Visible = true;

            GridColumn colMESLEK_ICRA_MEN_SURE = new GridColumn();
            colMESLEK_ICRA_MEN_SURE.VisibleIndex = 42;
            colMESLEK_ICRA_MEN_SURE.FieldName = "MESLEK_ICRA_MEN_SURE";
            colMESLEK_ICRA_MEN_SURE.Name = "colMESLEK_ICRA_MEN_SURE";
            colMESLEK_ICRA_MEN_SURE.Visible = true;

            GridColumn colEHLIYET_GERI_ALINMA_MEN_TIP = new GridColumn();
            colEHLIYET_GERI_ALINMA_MEN_TIP.VisibleIndex = 43;
            colEHLIYET_GERI_ALINMA_MEN_TIP.FieldName = "EHLIYET_GERI_ALINMA_MEN_TIP";
            colEHLIYET_GERI_ALINMA_MEN_TIP.Name = "colEHLIYET_GERI_ALINMA_MEN_TIP";
            colEHLIYET_GERI_ALINMA_MEN_TIP.Visible = true;

            GridColumn colEHLIYET_GERI_ALINMA_MEN_SURE = new GridColumn();
            colEHLIYET_GERI_ALINMA_MEN_SURE.VisibleIndex = 44;
            colEHLIYET_GERI_ALINMA_MEN_SURE.FieldName = "EHLIYET_GERI_ALINMA_MEN_SURE";
            colEHLIYET_GERI_ALINMA_MEN_SURE.Name = "colEHLIYET_GERI_ALINMA_MEN_SURE";
            colEHLIYET_GERI_ALINMA_MEN_SURE.Visible = true;

            GridColumn colKAMU_HIZMET_YASAK_TIP = new GridColumn();
            colKAMU_HIZMET_YASAK_TIP.VisibleIndex = 45;
            colKAMU_HIZMET_YASAK_TIP.FieldName = "KAMU_HIZMET_YASAK_TIP";
            colKAMU_HIZMET_YASAK_TIP.Name = "colKAMU_HIZMET_YASAK_TIP";
            colKAMU_HIZMET_YASAK_TIP.Visible = true;

            GridColumn colKAMU_HIZMET_YASAK_SURE = new GridColumn();
            colKAMU_HIZMET_YASAK_SURE.VisibleIndex = 46;
            colKAMU_HIZMET_YASAK_SURE.FieldName = "KAMU_HIZMET_YASAK_SURE";
            colKAMU_HIZMET_YASAK_SURE.Name = "colKAMU_HIZMET_YASAK_SURE";
            colKAMU_HIZMET_YASAK_SURE.Visible = true;

            GridColumn colINFAZ_TARIHI = new GridColumn();
            colINFAZ_TARIHI.VisibleIndex = 47;
            colINFAZ_TARIHI.FieldName = "INFAZ_TARIHI";
            colINFAZ_TARIHI.Name = "colINFAZ_TARIHI";
            colINFAZ_TARIHI.Visible = true;

            GridColumn colHUKUM_KESINLESME_TARIHI = new GridColumn();
            colHUKUM_KESINLESME_TARIHI.VisibleIndex = 48;
            colHUKUM_KESINLESME_TARIHI.FieldName = "HUKUM_KESINLESME_TARIHI";
            colHUKUM_KESINLESME_TARIHI.Name = "colHUKUM_KESINLESME_TARIHI";
            colHUKUM_KESINLESME_TARIHI.Visible = true;

            GridColumn colSORUMLULUK_MIKTARI = new GridColumn();
            colSORUMLULUK_MIKTARI.VisibleIndex = 49;
            colSORUMLULUK_MIKTARI.FieldName = "SORUMLULUK_MIKTARI";
            colSORUMLULUK_MIKTARI.Name = "colSORUMLULUK_MIKTARI";
            colSORUMLULUK_MIKTARI.Visible = true;

            GridColumn colSORUMLULUK_MIKTARI_DOVIZ_ID = new GridColumn();
            colSORUMLULUK_MIKTARI_DOVIZ_ID.VisibleIndex = 50;
            colSORUMLULUK_MIKTARI_DOVIZ_ID.FieldName = "SORUMLULUK_MIKTARI_DOVIZ_ID";
            colSORUMLULUK_MIKTARI_DOVIZ_ID.Name = "colSORUMLULUK_MIKTARI_DOVIZ_ID";
            colSORUMLULUK_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colHUKUM_TEBLIG_TEFHIM_TARIHI = new GridColumn();
            colHUKUM_TEBLIG_TEFHIM_TARIHI.VisibleIndex = 51;
            colHUKUM_TEBLIG_TEFHIM_TARIHI.FieldName = "HUKUM_TEBLIG_TEFHIM_TARIHI";
            colHUKUM_TEBLIG_TEFHIM_TARIHI.Name = "colHUKUM_TEBLIG_TEFHIM_TARIHI";
            colHUKUM_TEBLIG_TEFHIM_TARIHI.Visible = true;

            GridColumn colHUKUM_TIP = new GridColumn();
            colHUKUM_TIP.VisibleIndex = 52;
            colHUKUM_TIP.FieldName = "HUKUM_TIP";
            colHUKUM_TIP.Name = "colHUKUM_TIP";
            colHUKUM_TIP.Visible = true;

            GridColumn colHUKUM_ANLAM = new GridColumn();
            colHUKUM_ANLAM.VisibleIndex = 53;
            colHUKUM_ANLAM.FieldName = "HUKUM_ANLAM";
            colHUKUM_ANLAM.Name = "colHUKUM_ANLAM";
            colHUKUM_ANLAM.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 54;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 55;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colDAVACI = new GridColumn();
            colDAVACI.VisibleIndex = 56;
            colDAVACI.FieldName = "DAVACI";
            colDAVACI.Name = "colDAVACI";
            colDAVACI.Visible = true;

            GridColumn colDAVALI = new GridColumn();
            colDAVALI.VisibleIndex = 57;
            colDAVALI.FieldName = "DAVALI";
            colDAVALI.Name = "colDAVALI";
            colDAVALI.Visible = true;

            GridColumn colTAKIP_EDEN_TARAF_KODU = new GridColumn();
            colTAKIP_EDEN_TARAF_KODU.VisibleIndex = 58;
            colTAKIP_EDEN_TARAF_KODU.FieldName = "TAKIP_EDEN_TARAF_KODU";
            colTAKIP_EDEN_TARAF_KODU.Name = "colTAKIP_EDEN_TARAF_KODU";
            colTAKIP_EDEN_TARAF_KODU.Visible = true;

            GridColumn colTAKIP_EDILEN_TARAF_KODU = new GridColumn();
            colTAKIP_EDILEN_TARAF_KODU.VisibleIndex = 59;
            colTAKIP_EDILEN_TARAF_KODU.FieldName = "TAKIP_EDILEN_TARAF_KODU";
            colTAKIP_EDILEN_TARAF_KODU.Name = "colTAKIP_EDILEN_TARAF_KODU";
            colTAKIP_EDILEN_TARAF_KODU.Visible = true;

            GridColumn colDAVA_EDEN_SIFAT = new GridColumn();
            colDAVA_EDEN_SIFAT.VisibleIndex = 60;
            colDAVA_EDEN_SIFAT.FieldName = "DAVA_EDEN_SIFAT";
            colDAVA_EDEN_SIFAT.Name = "colDAVA_EDEN_SIFAT";
            colDAVA_EDEN_SIFAT.Visible = true;

            GridColumn colDAVA_EDILEN_SIFAT = new GridColumn();
            colDAVA_EDILEN_SIFAT.VisibleIndex = 61;
            colDAVA_EDILEN_SIFAT.FieldName = "DAVA_EDILEN_SIFAT";
            colDAVA_EDILEN_SIFAT.Name = "colDAVA_EDILEN_SIFAT";
            colDAVA_EDILEN_SIFAT.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 62;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 63;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 64;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 65;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 66;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 0;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colASAMA_ADI,
			colFOY_NO,
			colESAS_NO,
			colDAVA_TARIHI,
			colREFERANS_NO,
			colREFERANS_NO2,
			colREFERANS_NO3,
			colOzelKod1,
			colOzelKod2,
			colOzelKod3,
			colIZLEYEN,
			colSORUMLU,
			colOzelKod4,
			colDAVA_TALEP,
			colDAVA_ADI,
			colDIGER_DAVA_NEDEN,
			colOLAY_SUC_TARIHI,
			colDUZENLEME_TARIHI,
			colDAVA_EDILEN_TUTAR,
			colDAVA_EDILEN_TUTAR_DOVIZ_ID,
			colKESINLESME_TARIHI,
			colTARAF_SIFAT,
			colDAVA_TARAF,
			colSORUMLU_OLUNAN_MIKTAR,
			colSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID,
			colID,
			colHUKUM,
			colHUKUM_TARIHI,
			colKARAR_NO,
			colGEREKCE,
			colHUKUM_DEGER,
			colHUKUM_DEGER_DOVIZ_ID,
			colMUSADERE_DEGER,
			colMUSADERE_DEGER_DOVIZ_ID,
			colMAHKUMIYET_YIL,
			colMAHKUMIYET_AY,
			colMAHKUMIYET_GUN,
			colCEZA_ERTELENDI,
			colPARAYA_CEVRILDI,
			colPARAYA_CEVRILEN_MIKTAR,
			colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID,
			colMESLEK_ICRA_MEN_TIP,
			colMESLEK_ICRA_MEN_SURE,
			colEHLIYET_GERI_ALINMA_MEN_TIP,
			colEHLIYET_GERI_ALINMA_MEN_SURE,
			colKAMU_HIZMET_YASAK_TIP,
			colKAMU_HIZMET_YASAK_SURE,
			colINFAZ_TARIHI,
			colHUKUM_KESINLESME_TARIHI,
			colSORUMLULUK_MIKTARI,
			colSORUMLULUK_MIKTARI_DOVIZ_ID,
			colHUKUM_TEBLIG_TEFHIM_TARIHI,
			colHUKUM_TIP,
			colHUKUM_ANLAM,
			colSUBE_KOD_ID,
			colKONTROL_KIM_ID,
			colDAVACI,
			colDAVALI,
			colTAKIP_EDEN_TARAF_KODU,
			colTAKIP_EDILEN_TARAF_KODU,
			colDAVA_EDEN_SIFAT,
			colDAVA_EDILEN_SIFAT,
			colBOLUM,
			colADLIYE,
			colGOREV,
			colNO,
			colACIKLAMA,
			colDURUM,
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
                {
                    dizi[i].Caption = caption;
                }
                else if (dizi[i].FieldName.ToLower().Contains("doviz_id"))
                {
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTip = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToLower().ToString();
                }

                if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
                {
                    dizi[i].ColumnEdit = editler["DovizId"];
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTip = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToLower().ToString();
                }
                else if (editler.ContainsKey(dizi[i].FieldName))
                    dizi[i].ColumnEdit = editler[dizi[i].FieldName];
            }

            #endregion Column Caption

            return dizi;
        }

        public PivotGridField[] GetPivotFields(string pencere)
        {
            PivotGridField[] dizi = null;

            #region Field & Properties

            PivotGridField fieldASAMA_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASAMA_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASAMA_ADI.AreaIndex = 0;
            fieldASAMA_ADI.FieldName = "ASAMA_ADI";
            fieldASAMA_ADI.Name = "fieldASAMA_ADI";
            fieldASAMA_ADI.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 1;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 2;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 3;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 4;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldREFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO2.AreaIndex = 5;
            fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
            fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";
            fieldREFERANS_NO2.Visible = false;

            PivotGridField fieldREFERANS_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO3.AreaIndex = 6;
            fieldREFERANS_NO3.FieldName = "REFERANS_NO3";
            fieldREFERANS_NO3.Name = "fieldREFERANS_NO3";
            fieldREFERANS_NO3.Visible = false;

            PivotGridField fieldOzelKod1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzelKod1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzelKod1.AreaIndex = 7;
            fieldOzelKod1.FieldName = "OzelKod1";
            fieldOzelKod1.Name = "fieldOzelKod1";
            fieldOzelKod1.Visible = false;

            PivotGridField fieldOzelKod2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzelKod2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzelKod2.AreaIndex = 8;
            fieldOzelKod2.FieldName = "OzelKod2";
            fieldOzelKod2.Name = "fieldOzelKod2";
            fieldOzelKod2.Visible = false;

            PivotGridField fieldOzelKod3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzelKod3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzelKod3.AreaIndex = 9;
            fieldOzelKod3.FieldName = "OzelKod3";
            fieldOzelKod3.Name = "fieldOzelKod3";
            fieldOzelKod3.Visible = false;

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

            PivotGridField fieldOzelKod4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzelKod4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzelKod4.AreaIndex = 12;
            fieldOzelKod4.FieldName = "OzelKod4";
            fieldOzelKod4.Name = "fieldOzelKod4";
            fieldOzelKod4.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 13;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldDAVA_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_ADI.AreaIndex = 14;
            fieldDAVA_ADI.FieldName = "DAVA_ADI";
            fieldDAVA_ADI.Name = "fieldDAVA_ADI";
            fieldDAVA_ADI.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 15;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOLAY_SUC_TARIHI.AreaIndex = 16;
            fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Visible = false;

            PivotGridField fieldDUZENLEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDUZENLEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDUZENLEME_TARIHI.AreaIndex = 17;
            fieldDUZENLEME_TARIHI.FieldName = "DUZENLEME_TARIHI";
            fieldDUZENLEME_TARIHI.Name = "fieldDUZENLEME_TARIHI";
            fieldDUZENLEME_TARIHI.Visible = false;

            PivotGridField fieldDAVA_EDILEN_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_EDILEN_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_EDILEN_TUTAR.AreaIndex = 18;
            fieldDAVA_EDILEN_TUTAR.FieldName = "DAVA_EDILEN_TUTAR";
            fieldDAVA_EDILEN_TUTAR.Name = "fieldDAVA_EDILEN_TUTAR";
            fieldDAVA_EDILEN_TUTAR.Visible = false;

            PivotGridField fieldDAVA_EDILEN_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_EDILEN_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_EDILEN_TUTAR_DOVIZ_ID.AreaIndex = 19;
            fieldDAVA_EDILEN_TUTAR_DOVIZ_ID.FieldName = "DAVA_EDILEN_TUTAR_DOVIZ_ID";
            fieldDAVA_EDILEN_TUTAR_DOVIZ_ID.Name = "fieldDAVA_EDILEN_TUTAR_DOVIZ_ID";
            fieldDAVA_EDILEN_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldKESINLESME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKESINLESME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKESINLESME_TARIHI.AreaIndex = 20;
            fieldKESINLESME_TARIHI.FieldName = "KESINLESME_TARIHI";
            fieldKESINLESME_TARIHI.Name = "fieldKESINLESME_TARIHI";
            fieldKESINLESME_TARIHI.Visible = false;

            PivotGridField fieldTARAF_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARAF_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARAF_SIFAT.AreaIndex = 21;
            fieldTARAF_SIFAT.FieldName = "TARAF_SIFAT";
            fieldTARAF_SIFAT.Name = "fieldTARAF_SIFAT";
            fieldTARAF_SIFAT.Visible = false;

            PivotGridField fieldDAVA_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARAF.AreaIndex = 22;
            fieldDAVA_TARAF.FieldName = "DAVA_TARAF";
            fieldDAVA_TARAF.Name = "fieldDAVA_TARAF";
            fieldDAVA_TARAF.Visible = false;

            PivotGridField fieldSORUMLU_OLUNAN_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU_OLUNAN_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU_OLUNAN_MIKTAR.AreaIndex = 23;
            fieldSORUMLU_OLUNAN_MIKTAR.FieldName = "SORUMLU_OLUNAN_MIKTAR";
            fieldSORUMLU_OLUNAN_MIKTAR.Name = "fieldSORUMLU_OLUNAN_MIKTAR";
            fieldSORUMLU_OLUNAN_MIKTAR.Visible = false;

            PivotGridField fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.AreaIndex = 24;
            fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.FieldName = "SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID";
            fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.Name = "fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID";
            fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 25;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldHUKUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHUKUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHUKUM.AreaIndex = 26;
            fieldHUKUM.FieldName = "HUKUM";
            fieldHUKUM.Name = "fieldHUKUM";
            fieldHUKUM.Visible = false;

            PivotGridField fieldHUKUM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHUKUM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHUKUM_TARIHI.AreaIndex = 27;
            fieldHUKUM_TARIHI.FieldName = "HUKUM_TARIHI";
            fieldHUKUM_TARIHI.Name = "fieldHUKUM_TARIHI";
            fieldHUKUM_TARIHI.Visible = false;

            PivotGridField fieldKARAR_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARAR_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARAR_NO.AreaIndex = 28;
            fieldKARAR_NO.FieldName = "KARAR_NO";
            fieldKARAR_NO.Name = "fieldKARAR_NO";
            fieldKARAR_NO.Visible = false;

            PivotGridField fieldGEREKCE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGEREKCE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGEREKCE.AreaIndex = 29;
            fieldGEREKCE.FieldName = "GEREKCE";
            fieldGEREKCE.Name = "fieldGEREKCE";
            fieldGEREKCE.Visible = false;

            PivotGridField fieldHUKUM_DEGER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHUKUM_DEGER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHUKUM_DEGER.AreaIndex = 30;
            fieldHUKUM_DEGER.FieldName = "HUKUM_DEGER";
            fieldHUKUM_DEGER.Name = "fieldHUKUM_DEGER";
            fieldHUKUM_DEGER.Visible = false;

            PivotGridField fieldHUKUM_DEGER_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHUKUM_DEGER_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHUKUM_DEGER_DOVIZ_ID.AreaIndex = 31;
            fieldHUKUM_DEGER_DOVIZ_ID.FieldName = "HUKUM_DEGER_DOVIZ_ID";
            fieldHUKUM_DEGER_DOVIZ_ID.Name = "fieldHUKUM_DEGER_DOVIZ_ID";
            fieldHUKUM_DEGER_DOVIZ_ID.Visible = false;

            PivotGridField fieldMUSADERE_DEGER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUSADERE_DEGER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUSADERE_DEGER.AreaIndex = 32;
            fieldMUSADERE_DEGER.FieldName = "MUSADERE_DEGER";
            fieldMUSADERE_DEGER.Name = "fieldMUSADERE_DEGER";
            fieldMUSADERE_DEGER.Visible = false;

            PivotGridField fieldMUSADERE_DEGER_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUSADERE_DEGER_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUSADERE_DEGER_DOVIZ_ID.AreaIndex = 33;
            fieldMUSADERE_DEGER_DOVIZ_ID.FieldName = "MUSADERE_DEGER_DOVIZ_ID";
            fieldMUSADERE_DEGER_DOVIZ_ID.Name = "fieldMUSADERE_DEGER_DOVIZ_ID";
            fieldMUSADERE_DEGER_DOVIZ_ID.Visible = false;

            PivotGridField fieldMAHKUMIYET_YIL = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHKUMIYET_YIL.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHKUMIYET_YIL.AreaIndex = 34;
            fieldMAHKUMIYET_YIL.FieldName = "MAHKUMIYET_YIL";
            fieldMAHKUMIYET_YIL.Name = "fieldMAHKUMIYET_YIL";
            fieldMAHKUMIYET_YIL.Visible = false;

            PivotGridField fieldMAHKUMIYET_AY = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHKUMIYET_AY.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHKUMIYET_AY.AreaIndex = 35;
            fieldMAHKUMIYET_AY.FieldName = "MAHKUMIYET_AY";
            fieldMAHKUMIYET_AY.Name = "fieldMAHKUMIYET_AY";
            fieldMAHKUMIYET_AY.Visible = false;

            PivotGridField fieldMAHKUMIYET_GUN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHKUMIYET_GUN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHKUMIYET_GUN.AreaIndex = 36;
            fieldMAHKUMIYET_GUN.FieldName = "MAHKUMIYET_GUN";
            fieldMAHKUMIYET_GUN.Name = "fieldMAHKUMIYET_GUN";
            fieldMAHKUMIYET_GUN.Visible = false;

            PivotGridField fieldCEZA_ERTELENDI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCEZA_ERTELENDI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCEZA_ERTELENDI.AreaIndex = 37;
            fieldCEZA_ERTELENDI.FieldName = "CEZA_ERTELENDI";
            fieldCEZA_ERTELENDI.Name = "fieldCEZA_ERTELENDI";
            fieldCEZA_ERTELENDI.Visible = false;

            PivotGridField fieldPARAYA_CEVRILDI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPARAYA_CEVRILDI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPARAYA_CEVRILDI.AreaIndex = 38;
            fieldPARAYA_CEVRILDI.FieldName = "PARAYA_CEVRILDI";
            fieldPARAYA_CEVRILDI.Name = "fieldPARAYA_CEVRILDI";
            fieldPARAYA_CEVRILDI.Visible = false;

            PivotGridField fieldPARAYA_CEVRILEN_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPARAYA_CEVRILEN_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPARAYA_CEVRILEN_MIKTAR.AreaIndex = 39;
            fieldPARAYA_CEVRILEN_MIKTAR.FieldName = "PARAYA_CEVRILEN_MIKTAR";
            fieldPARAYA_CEVRILEN_MIKTAR.Name = "fieldPARAYA_CEVRILEN_MIKTAR";
            fieldPARAYA_CEVRILEN_MIKTAR.Visible = false;

            PivotGridField fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.AreaIndex = 40;
            fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.FieldName = "PARAYA_CEVRILEN_MIKTAR_DOVIZ_ID";
            fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.Name = "fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID";
            fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldMESLEK_ICRA_MEN_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMESLEK_ICRA_MEN_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMESLEK_ICRA_MEN_TIP.AreaIndex = 41;
            fieldMESLEK_ICRA_MEN_TIP.FieldName = "MESLEK_ICRA_MEN_TIP";
            fieldMESLEK_ICRA_MEN_TIP.Name = "fieldMESLEK_ICRA_MEN_TIP";
            fieldMESLEK_ICRA_MEN_TIP.Visible = false;

            PivotGridField fieldMESLEK_ICRA_MEN_SURE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMESLEK_ICRA_MEN_SURE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMESLEK_ICRA_MEN_SURE.AreaIndex = 42;
            fieldMESLEK_ICRA_MEN_SURE.FieldName = "MESLEK_ICRA_MEN_SURE";
            fieldMESLEK_ICRA_MEN_SURE.Name = "fieldMESLEK_ICRA_MEN_SURE";
            fieldMESLEK_ICRA_MEN_SURE.Visible = false;

            PivotGridField fieldEHLIYET_GERI_ALINMA_MEN_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldEHLIYET_GERI_ALINMA_MEN_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldEHLIYET_GERI_ALINMA_MEN_TIP.AreaIndex = 43;
            fieldEHLIYET_GERI_ALINMA_MEN_TIP.FieldName = "EHLIYET_GERI_ALINMA_MEN_TIP";
            fieldEHLIYET_GERI_ALINMA_MEN_TIP.Name = "fieldEHLIYET_GERI_ALINMA_MEN_TIP";
            fieldEHLIYET_GERI_ALINMA_MEN_TIP.Visible = false;

            PivotGridField fieldEHLIYET_GERI_ALINMA_MEN_SURE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldEHLIYET_GERI_ALINMA_MEN_SURE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldEHLIYET_GERI_ALINMA_MEN_SURE.AreaIndex = 44;
            fieldEHLIYET_GERI_ALINMA_MEN_SURE.FieldName = "EHLIYET_GERI_ALINMA_MEN_SURE";
            fieldEHLIYET_GERI_ALINMA_MEN_SURE.Name = "fieldEHLIYET_GERI_ALINMA_MEN_SURE";
            fieldEHLIYET_GERI_ALINMA_MEN_SURE.Visible = false;

            PivotGridField fieldKAMU_HIZMET_YASAK_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAMU_HIZMET_YASAK_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAMU_HIZMET_YASAK_TIP.AreaIndex = 45;
            fieldKAMU_HIZMET_YASAK_TIP.FieldName = "KAMU_HIZMET_YASAK_TIP";
            fieldKAMU_HIZMET_YASAK_TIP.Name = "fieldKAMU_HIZMET_YASAK_TIP";
            fieldKAMU_HIZMET_YASAK_TIP.Visible = false;

            PivotGridField fieldKAMU_HIZMET_YASAK_SURE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAMU_HIZMET_YASAK_SURE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAMU_HIZMET_YASAK_SURE.AreaIndex = 46;
            fieldKAMU_HIZMET_YASAK_SURE.FieldName = "KAMU_HIZMET_YASAK_SURE";
            fieldKAMU_HIZMET_YASAK_SURE.Name = "fieldKAMU_HIZMET_YASAK_SURE";
            fieldKAMU_HIZMET_YASAK_SURE.Visible = false;

            PivotGridField fieldINFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINFAZ_TARIHI.AreaIndex = 47;
            fieldINFAZ_TARIHI.FieldName = "INFAZ_TARIHI";
            fieldINFAZ_TARIHI.Name = "fieldINFAZ_TARIHI";
            fieldINFAZ_TARIHI.Visible = false;

            PivotGridField fieldHUKUM_KESINLESME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHUKUM_KESINLESME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHUKUM_KESINLESME_TARIHI.AreaIndex = 48;
            fieldHUKUM_KESINLESME_TARIHI.FieldName = "HUKUM_KESINLESME_TARIHI";
            fieldHUKUM_KESINLESME_TARIHI.Name = "fieldHUKUM_KESINLESME_TARIHI";
            fieldHUKUM_KESINLESME_TARIHI.Visible = false;

            PivotGridField fieldSORUMLULUK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLULUK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLULUK_MIKTARI.AreaIndex = 49;
            fieldSORUMLULUK_MIKTARI.FieldName = "SORUMLULUK_MIKTARI";
            fieldSORUMLULUK_MIKTARI.Name = "fieldSORUMLULUK_MIKTARI";
            fieldSORUMLULUK_MIKTARI.Visible = false;

            PivotGridField fieldSORUMLULUK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLULUK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLULUK_MIKTARI_DOVIZ_ID.AreaIndex = 50;
            fieldSORUMLULUK_MIKTARI_DOVIZ_ID.FieldName = "SORUMLULUK_MIKTARI_DOVIZ_ID";
            fieldSORUMLULUK_MIKTARI_DOVIZ_ID.Name = "fieldSORUMLULUK_MIKTARI_DOVIZ_ID";
            fieldSORUMLULUK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldHUKUM_TEBLIG_TEFHIM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHUKUM_TEBLIG_TEFHIM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHUKUM_TEBLIG_TEFHIM_TARIHI.AreaIndex = 51;
            fieldHUKUM_TEBLIG_TEFHIM_TARIHI.FieldName = "HUKUM_TEBLIG_TEFHIM_TARIHI";
            fieldHUKUM_TEBLIG_TEFHIM_TARIHI.Name = "fieldHUKUM_TEBLIG_TEFHIM_TARIHI";
            fieldHUKUM_TEBLIG_TEFHIM_TARIHI.Visible = false;

            PivotGridField fieldHUKUM_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHUKUM_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHUKUM_TIP.AreaIndex = 52;
            fieldHUKUM_TIP.FieldName = "HUKUM_TIP";
            fieldHUKUM_TIP.Name = "fieldHUKUM_TIP";
            fieldHUKUM_TIP.Visible = false;

            PivotGridField fieldHUKUM_ANLAM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHUKUM_ANLAM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHUKUM_ANLAM.AreaIndex = 53;
            fieldHUKUM_ANLAM.FieldName = "HUKUM_ANLAM";
            fieldHUKUM_ANLAM.Name = "fieldHUKUM_ANLAM";
            fieldHUKUM_ANLAM.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 54;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 55;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldDAVACI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVACI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVACI.AreaIndex = 56;
            fieldDAVACI.FieldName = "DAVACI";
            fieldDAVACI.Name = "fieldDAVACI";
            fieldDAVACI.Visible = false;

            PivotGridField fieldDAVALI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVALI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVALI.AreaIndex = 57;
            fieldDAVALI.FieldName = "DAVALI";
            fieldDAVALI.Name = "fieldDAVALI";
            fieldDAVALI.Visible = false;

            PivotGridField fieldTAKIP_EDEN_TARAF_KODU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN_TARAF_KODU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN_TARAF_KODU.AreaIndex = 58;
            fieldTAKIP_EDEN_TARAF_KODU.FieldName = "TAKIP_EDEN_TARAF_KODU";
            fieldTAKIP_EDEN_TARAF_KODU.Name = "fieldTAKIP_EDEN_TARAF_KODU";
            fieldTAKIP_EDEN_TARAF_KODU.Visible = false;

            PivotGridField fieldTAKIP_EDILEN_TARAF_KODU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN_TARAF_KODU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN_TARAF_KODU.AreaIndex = 59;
            fieldTAKIP_EDILEN_TARAF_KODU.FieldName = "TAKIP_EDILEN_TARAF_KODU";
            fieldTAKIP_EDILEN_TARAF_KODU.Name = "fieldTAKIP_EDILEN_TARAF_KODU";
            fieldTAKIP_EDILEN_TARAF_KODU.Visible = false;

            PivotGridField fieldDAVA_EDEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_EDEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_EDEN_SIFAT.AreaIndex = 60;
            fieldDAVA_EDEN_SIFAT.FieldName = "DAVA_EDEN_SIFAT";
            fieldDAVA_EDEN_SIFAT.Name = "fieldDAVA_EDEN_SIFAT";
            fieldDAVA_EDEN_SIFAT.Visible = false;

            PivotGridField fieldDAVA_EDILEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_EDILEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_EDILEN_SIFAT.AreaIndex = 61;
            fieldDAVA_EDILEN_SIFAT.FieldName = "DAVA_EDILEN_SIFAT";
            fieldDAVA_EDILEN_SIFAT.Name = "fieldDAVA_EDILEN_SIFAT";
            fieldDAVA_EDILEN_SIFAT.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 62;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 63;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 64;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 65;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 66;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 67;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            #endregion Field & Properties

            switch (pencere)
            {
                case "Dava Dosyalarının Kazanılan ve Kaybedilenlere Göre Dağılımı":
                    dizi = KazanilanKaybedileneGore();
                    break;
                default:
                    break;
            }

            #region []

            if (dizi == null)
            {
                dizi = new PivotGridField[]
		{
			fieldASAMA_ADI,
			fieldFOY_NO,
			fieldESAS_NO,
			fieldDAVA_TARIHI,
			fieldREFERANS_NO,
			fieldREFERANS_NO2,
			fieldREFERANS_NO3,
			fieldOzelKod1,
			fieldOzelKod2,
			fieldOzelKod3,
			fieldIZLEYEN,
			fieldSORUMLU,
			fieldOzelKod4,
			fieldDAVA_TALEP,
			fieldDAVA_ADI,
			fieldDIGER_DAVA_NEDEN,
			fieldOLAY_SUC_TARIHI,
			fieldDUZENLEME_TARIHI,
			fieldDAVA_EDILEN_TUTAR,
			fieldDAVA_EDILEN_TUTAR_DOVIZ_ID,
			fieldKESINLESME_TARIHI,
			fieldTARAF_SIFAT,
			fieldDAVA_TARAF,
			fieldSORUMLU_OLUNAN_MIKTAR,
			fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID,
			fieldID,
			fieldHUKUM,
			fieldHUKUM_TARIHI,
			fieldKARAR_NO,
			fieldGEREKCE,
			fieldHUKUM_DEGER,
			fieldHUKUM_DEGER_DOVIZ_ID,
			fieldMUSADERE_DEGER,
			fieldMUSADERE_DEGER_DOVIZ_ID,
			fieldMAHKUMIYET_YIL,
			fieldMAHKUMIYET_AY,
			fieldMAHKUMIYET_GUN,
			fieldCEZA_ERTELENDI,
			fieldPARAYA_CEVRILDI,
			fieldPARAYA_CEVRILEN_MIKTAR,
			fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID,
			fieldMESLEK_ICRA_MEN_TIP,
			fieldMESLEK_ICRA_MEN_SURE,
			fieldEHLIYET_GERI_ALINMA_MEN_TIP,
			fieldEHLIYET_GERI_ALINMA_MEN_SURE,
			fieldKAMU_HIZMET_YASAK_TIP,
			fieldKAMU_HIZMET_YASAK_SURE,
			fieldINFAZ_TARIHI,
			fieldHUKUM_KESINLESME_TARIHI,
			fieldSORUMLULUK_MIKTARI,
			fieldSORUMLULUK_MIKTARI_DOVIZ_ID,
			fieldHUKUM_TEBLIG_TEFHIM_TARIHI,
			fieldHUKUM_TIP,
			fieldHUKUM_ANLAM,
			fieldSUBE_KOD_ID,
			fieldKONTROL_KIM_ID,
			fieldDAVACI,
			fieldDAVALI,
			fieldTAKIP_EDEN_TARAF_KODU,
			fieldTAKIP_EDILEN_TARAF_KODU,
			fieldDAVA_EDEN_SIFAT,
			fieldDAVA_EDILEN_SIFAT,
            fieldBOLUM,
			};
            }

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

            string RefNo, RefNo2, refNo3, OzelKod1, OzelKod2, OzelKod3, OzelKod4, DNRefNo, DNRefNo2;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans1))
                RefNo = "Ref No";
            else
                RefNo = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans1;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans2))
                RefNo2 = "Ref No2";
            else
                RefNo2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans2;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans3))
                refNo3 = "Ref No3";
            else
                refNo3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans3;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod1))
                OzelKod1 = "Özel Kod1";
            else
                OzelKod1 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod1;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod2))
                OzelKod2 = "Özel Kod2";
            else
                OzelKod2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod2;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod3))
                OzelKod3 = "Özel Kod3";
            else
                OzelKod3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod3;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod4))
                OzelKod4 = "Özel Kod4";
            else
                OzelKod4 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod4;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaDnReferans.Referans1))
                DNRefNo = "Dava Neden Ref No1";
            else
                DNRefNo = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaDnReferans.Referans1;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaDnReferans.Referans2))
                DNRefNo2 = "Dava Neden Ref No2";
            else
                DNRefNo2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaDnReferans.Referans2;

            #endregion Özelleştirme

            #region Caption Edit

            dicFieldCaption.Add("ASAMA_ADI", "Aşama");
            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("DAVA_TARIHI", "Dava T.");
            dicFieldCaption.Add("REFERANS_NO", RefNo);
            dicFieldCaption.Add("REFERANS_NO2", RefNo2);
            dicFieldCaption.Add("REFERANS_NO3", refNo3);
            dicFieldCaption.Add("OzelKod1", OzelKod1);
            dicFieldCaption.Add("OzelKod2", OzelKod2);
            dicFieldCaption.Add("OzelKod3", OzelKod3);
            dicFieldCaption.Add("IZLEYEN", "İzleyen");
            dicFieldCaption.Add("SORUMLU", "Sorumlu");
            dicFieldCaption.Add("ÖzelKod4", OzelKod4);
            dicFieldCaption.Add("DAVA_TALEP", "Dava Talep");
            dicFieldCaption.Add("DAVA_ADI", "Dava Adı");
            dicFieldCaption.Add("DIGER_DAVA_NEDEN", "Diğer Dava Neden");
            dicFieldCaption.Add("OLAY_SUC_TARIHI", "Olay Suç T.");
            dicFieldCaption.Add("DUZENLEME_TARIHI", "Düzenleme T.");
            dicFieldCaption.Add("DAVA_EDILEN_TUTAR", "Dava Edilen");
            dicFieldCaption.Add("KESINLESME_TARIHI", "Kesinleşme T.");
            dicFieldCaption.Add("TARAF_SIFAT", "Taraf Sıfat");
            dicFieldCaption.Add("DAVA_TARAF", "Dava Taraf");
            dicFieldCaption.Add("SORUMLU_OLUNAN_MIKTAR", "Sorumlu Olunan Miktar");
            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("HUKUM", "Hüküm");
            dicFieldCaption.Add("HUKUM_TARIHI", "Hüküm T.");
            dicFieldCaption.Add("KARAR_NO", "Karar No");
            dicFieldCaption.Add("GEREKCE", "Gerekçe");
            dicFieldCaption.Add("HUKUM_DEGER", "Hüküm Değer");
            dicFieldCaption.Add("MUSADERE_DEGER", "Müsadere Değer");
            dicFieldCaption.Add("MAHKUMIYET_YIL", "Mahkumiyet Yıl");
            dicFieldCaption.Add("MAHKUMIYET_AY", "Mahkumiyet Ay");
            dicFieldCaption.Add("MAHKUMIYET_GUN", "Mahkumiyet Gün");
            dicFieldCaption.Add("CEZA_ERTELENDI", "Ceza Ertelendi");
            dicFieldCaption.Add("PARAYA_CEVRILDI", "Paraya Çevrildi");
            dicFieldCaption.Add("PARAYA_CEVRILEN_MIKTAR", "Paraya Çevrilen Miktar");
            dicFieldCaption.Add("MESLEK_ICRA_MEN_TIP", "Meslek İcra Men Tip");
            dicFieldCaption.Add("MESLEK_ICRA_MEN_SURE", "Meslek İcra Men Süre");
            dicFieldCaption.Add("EHLIYET_GERI_ALINMA_MEN_TIP", "Ehliyet Geri Alınma Men Tip");
            dicFieldCaption.Add("EHLIYET_GERI_ALINMA_MEN_SURE", "Ehliyet Geri Alınma Men Süre");
            dicFieldCaption.Add("KAMU_HIZMET_YASAK_TIP", "Kamu Hizmet Yasak Tip");
            dicFieldCaption.Add("KAMU_HIZMET_YASAK_SURE", "Kamu Hizmet Yasak Süre");
            dicFieldCaption.Add("INFAZ_TARIHI", "İnfaz T.");
            dicFieldCaption.Add("HUKUM_KESINLESME_TARIHI", "Hüküm Kesinleşme T.");
            dicFieldCaption.Add("SORUMLULUK_MIKTARI", "Sorumluluk Miktarı");
            dicFieldCaption.Add("HUKUM_TEBLIG_TEFHIM_TARIHI", "Hüküm Tebliğ Tefhim T.");
            dicFieldCaption.Add("HUKUM_TIP", "Hüküm Tip");
            dicFieldCaption.Add("HUKUM_ANLAM", "Hüküm Anlam");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("DAVACI", "Davacı");
            dicFieldCaption.Add("DAVALI", "Davalı");
            dicFieldCaption.Add("TAKIP_EDEN_TARAF_KODU", "Davacı T.K.");
            dicFieldCaption.Add("TAKIP_EDILEN_TARAF_KODU", "Davalı T.K");
            dicFieldCaption.Add("DAVA_EDEN_SIFAT", "Davacı Sıfat");
            dicFieldCaption.Add("DAVA_EDILEN_SIFAT", "Davalı Sıfat");
            dicFieldCaption.Add("BOLUM", "Bölüm");
            dicFieldCaption.Add("ADLIYE", "Mahkeme");
            dicFieldCaption.Add("GOREV", "Görev");
            dicFieldCaption.Add("NO", "No");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("DURUM", "Durumu");

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

            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("DAVA_EDILEN_TUTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("DAVA_EDILEN_TUTAR_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("SORUMLU_OLUNAN_MIKTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("HUKUM_DEGER", InitsEx.ParaBicimiAyarla);
            sozluk.Add("HUKUM_DEGER_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("MUSADERE_DEGER", InitsEx.ParaBicimiAyarla);
            sozluk.Add("MUSADERE_DEGER_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("PARAYA_CEVRILEN_MIKTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("PARAYA_CEVRILEN_MIKTAR_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("SORUMLULUK_MIKTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("SORUMLULUK_MIKTARI_DOVIZ_ID", InitsEx.DovizTipGetir);

            #endregion Add item

            return sozluk;
        }

        private PivotGridField[] KazanilanKaybedileneGore()
        {
            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 25;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldHUKUM_ANLAM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHUKUM_ANLAM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldHUKUM_ANLAM.AreaIndex = 53;
            fieldHUKUM_ANLAM.FieldName = "HUKUM_ANLAM";
            fieldHUKUM_ANLAM.Name = "fieldHUKUM_ANLAM";
            fieldHUKUM_ANLAM.Visible = true;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 54;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldHUKUM_DEGER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHUKUM_DEGER.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldHUKUM_DEGER.AreaIndex = 30;
            fieldHUKUM_DEGER.FieldName = "HUKUM_DEGER";
            fieldHUKUM_DEGER.Name = "fieldHUKUM_DEGER";
            fieldHUKUM_DEGER.Visible = true;

            PivotGridField fieldHUKUM_DEGER_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHUKUM_DEGER_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHUKUM_DEGER_DOVIZ_ID.AreaIndex = 31;
            fieldHUKUM_DEGER_DOVIZ_ID.FieldName = "HUKUM_DEGER_DOVIZ_ID";
            fieldHUKUM_DEGER_DOVIZ_ID.Name = "fieldHUKUM_DEGER_DOVIZ_ID";
            fieldHUKUM_DEGER_DOVIZ_ID.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 62;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField[] dizi = new PivotGridField[]
		        {
                    fieldID,
                    fieldHUKUM_ANLAM,
                    fieldHUKUM_DEGER,
                    fieldBOLUM,
                };
            return dizi;
        }
    }
}