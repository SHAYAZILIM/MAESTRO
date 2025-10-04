using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    internal class MasterIcraAlacakNedenAyrintili
    {
        
        public GridColumn[] GetGridColumns()
        {
            #region Field & Properties

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 0;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colICRA_ADLIYE = new GridColumn();
            colICRA_ADLIYE.VisibleIndex = 1;
            colICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            colICRA_ADLIYE.Name = "colICRA_ADLIYE";
            colICRA_ADLIYE.Visible = true;

            GridColumn colICRA_BIRIM_NO = new GridColumn();
            colICRA_BIRIM_NO.VisibleIndex = 2;
            colICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Name = "colICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 3;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 4;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colVADE_TARIHI = new GridColumn();
            colVADE_TARIHI.VisibleIndex = 5;
            colVADE_TARIHI.FieldName = "VADE_TARIHI";
            colVADE_TARIHI.Name = "colVADE_TARIHI";
            colVADE_TARIHI.Visible = true;

            GridColumn colISLEME_KONAN_TUTAR = new GridColumn();
            colISLEME_KONAN_TUTAR.VisibleIndex = 6;
            colISLEME_KONAN_TUTAR.FieldName = "ISLEME_KONAN_TUTAR";
            colISLEME_KONAN_TUTAR.Name = "colISLEME_KONAN_TUTAR";
            colISLEME_KONAN_TUTAR.Visible = true;

            GridColumn colISLEME_KONAN_TUTAR_DOVIZ_ID = new GridColumn();
            colISLEME_KONAN_TUTAR_DOVIZ_ID.VisibleIndex = 7;
            colISLEME_KONAN_TUTAR_DOVIZ_ID.FieldName = "ISLEME_KONAN_TUTAR_DOVIZ_ID";
            colISLEME_KONAN_TUTAR_DOVIZ_ID.Name = "colISLEME_KONAN_TUTAR_DOVIZ_ID";
            colISLEME_KONAN_TUTAR_DOVIZ_ID.Visible = true;

            GridColumn colAL_NED_REF1 = new GridColumn();
            colAL_NED_REF1.VisibleIndex = 8;
            colAL_NED_REF1.FieldName = "AL_NED_REF1";
            colAL_NED_REF1.Name = "colAL_NED_REF1";
            colAL_NED_REF1.Visible = true;

            GridColumn colAL_NED_REF2 = new GridColumn();
            colAL_NED_REF2.VisibleIndex = 9;
            colAL_NED_REF2.FieldName = "AL_NED_REF2";
            colAL_NED_REF2.Name = "colAL_NED_REF2";
            colAL_NED_REF2.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 10;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colBANKA_SUBE = new GridColumn();
            colBANKA_SUBE.VisibleIndex = 11;
            colBANKA_SUBE.FieldName = "BANKA_SUBE";
            colBANKA_SUBE.Name = "colBANKA_SUBE";
            colBANKA_SUBE.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 12;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 13;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 14;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colBORCLU = new GridColumn();
            colBORCLU.VisibleIndex = 15;
            colBORCLU.FieldName = "BORCLU";
            colBORCLU.Name = "colBORCLU";
            colBORCLU.Visible = true;

            GridColumn colICRA_SORUMLU = new GridColumn();
            colICRA_SORUMLU.VisibleIndex = 16;
            colICRA_SORUMLU.FieldName = "ICRA_SORUMLU";
            colICRA_SORUMLU.Name = "colICRA_SORUMLU";
            colICRA_SORUMLU.Visible = true;

            GridColumn colTARAF_SIFAT = new GridColumn();
            colTARAF_SIFAT.VisibleIndex = 17;
            colTARAF_SIFAT.FieldName = "TARAF_SIFAT";
            colTARAF_SIFAT.Name = "colTARAF_SIFAT";
            colTARAF_SIFAT.Visible = true;

            GridColumn colFORM_TIPI = new GridColumn();
            colFORM_TIPI.VisibleIndex = 18;
            colFORM_TIPI.FieldName = "FORM_TIPI";
            colFORM_TIPI.Name = "colFORM_TIPI";
            colFORM_TIPI.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 19;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colTALEP_ADI = new GridColumn();
            colTALEP_ADI.VisibleIndex = 20;
            colTALEP_ADI.FieldName = "TALEP_ADI";
            colTALEP_ADI.Name = "colTALEP_ADI";
            colTALEP_ADI.Visible = true;

            GridColumn colITIRAZ_EDEN = new GridColumn();
            colITIRAZ_EDEN.VisibleIndex = 21;
            colITIRAZ_EDEN.FieldName = "ITIRAZ_EDEN";
            colITIRAZ_EDEN.Name = "colITIRAZ_EDEN";
            colITIRAZ_EDEN.Visible = true;

            GridColumn colBORCA_ITIRAZ_VARMI = new GridColumn();
            colBORCA_ITIRAZ_VARMI.VisibleIndex = 22;
            colBORCA_ITIRAZ_VARMI.FieldName = "BORCA_ITIRAZ_VARMI";
            colBORCA_ITIRAZ_VARMI.Name = "colBORCA_ITIRAZ_VARMI";
            colBORCA_ITIRAZ_VARMI.Visible = true;

            GridColumn colIMZAYA_ITIRAZ_VARMI = new GridColumn();
            colIMZAYA_ITIRAZ_VARMI.VisibleIndex = 23;
            colIMZAYA_ITIRAZ_VARMI.FieldName = "IMZAYA_ITIRAZ_VARMI";
            colIMZAYA_ITIRAZ_VARMI.Name = "colIMZAYA_ITIRAZ_VARMI";
            colIMZAYA_ITIRAZ_VARMI.Visible = true;

            GridColumn colYETKIYE_ITIRAZ_VARMI = new GridColumn();
            colYETKIYE_ITIRAZ_VARMI.VisibleIndex = 24;
            colYETKIYE_ITIRAZ_VARMI.FieldName = "YETKIYE_ITIRAZ_VARMI";
            colYETKIYE_ITIRAZ_VARMI.Name = "colYETKIYE_ITIRAZ_VARMI";
            colYETKIYE_ITIRAZ_VARMI.Visible = true;

            GridColumn colGOREVE_ITIRAZ_VARMI = new GridColumn();
            colGOREVE_ITIRAZ_VARMI.VisibleIndex = 25;
            colGOREVE_ITIRAZ_VARMI.FieldName = "GOREVE_ITIRAZ_VARMI";
            colGOREVE_ITIRAZ_VARMI.Name = "colGOREVE_ITIRAZ_VARMI";
            colGOREVE_ITIRAZ_VARMI.Visible = true;

            GridColumn colITIRAZ_SEBEP = new GridColumn();
            colITIRAZ_SEBEP.VisibleIndex = 26;
            colITIRAZ_SEBEP.FieldName = "ITIRAZ_SEBEP";
            colITIRAZ_SEBEP.Name = "colITIRAZ_SEBEP";
            colITIRAZ_SEBEP.Visible = true;

            GridColumn colITIRAZ_MAHKEME = new GridColumn();
            colITIRAZ_MAHKEME.VisibleIndex = 27;
            colITIRAZ_MAHKEME.FieldName = "ITIRAZ_MAHKEME";
            colITIRAZ_MAHKEME.Name = "colITIRAZ_MAHKEME";
            colITIRAZ_MAHKEME.Visible = true;

            GridColumn colITIRAZ_BIRIM_NO = new GridColumn();
            colITIRAZ_BIRIM_NO.VisibleIndex = 28;
            colITIRAZ_BIRIM_NO.FieldName = "ITIRAZ_BIRIM_NO";
            colITIRAZ_BIRIM_NO.Name = "colITIRAZ_BIRIM_NO";
            colITIRAZ_BIRIM_NO.Visible = true;

            GridColumn colITIRAZ_GOREV = new GridColumn();
            colITIRAZ_GOREV.VisibleIndex = 29;
            colITIRAZ_GOREV.FieldName = "ITIRAZ_GOREV";
            colITIRAZ_GOREV.Name = "colITIRAZ_GOREV";
            colITIRAZ_GOREV.Visible = true;

            GridColumn colITIRAZ_ESAS_NO = new GridColumn();
            colITIRAZ_ESAS_NO.VisibleIndex = 30;
            colITIRAZ_ESAS_NO.FieldName = "ITIRAZ_ESAS_NO";
            colITIRAZ_ESAS_NO.Name = "colITIRAZ_ESAS_NO";
            colITIRAZ_ESAS_NO.Visible = true;

            GridColumn colITIRAZ_TARIHI = new GridColumn();
            colITIRAZ_TARIHI.VisibleIndex = 31;
            colITIRAZ_TARIHI.FieldName = "ITIRAZ_TARIHI";
            colITIRAZ_TARIHI.Name = "colITIRAZ_TARIHI";
            colITIRAZ_TARIHI.Visible = true;

            GridColumn colITIRAZ_SONUC = new GridColumn();
            colITIRAZ_SONUC.VisibleIndex = 32;
            colITIRAZ_SONUC.FieldName = "ITIRAZ_SONUC";
            colITIRAZ_SONUC.Name = "colITIRAZ_SONUC";
            colITIRAZ_SONUC.Visible = true;

            GridColumn colYASAL_DAYANAK = new GridColumn();
            colYASAL_DAYANAK.VisibleIndex = 33;
            colYASAL_DAYANAK.FieldName = "YASAL_DAYANAK";
            colYASAL_DAYANAK.Name = "colYASAL_DAYANAK";
            colYASAL_DAYANAK.Visible = true;

            GridColumn colITIRAZIN_GIDERILME_YOLU = new GridColumn();
            colITIRAZIN_GIDERILME_YOLU.VisibleIndex = 34;
            colITIRAZIN_GIDERILME_YOLU.FieldName = "ITIRAZIN_GIDERILME_YOLU";
            colITIRAZIN_GIDERILME_YOLU.Name = "colITIRAZIN_GIDERILME_YOLU";
            colITIRAZIN_GIDERILME_YOLU.Visible = true;

            GridColumn colHUKMEDILEN_TAZMINAT_DOVIZ_ID = new GridColumn();
            colHUKMEDILEN_TAZMINAT_DOVIZ_ID.VisibleIndex = 35;
            colHUKMEDILEN_TAZMINAT_DOVIZ_ID.FieldName = "HUKMEDILEN_TAZMINAT_DOVIZ_ID";
            colHUKMEDILEN_TAZMINAT_DOVIZ_ID.Name = "colHUKMEDILEN_TAZMINAT_DOVIZ_ID";
            colHUKMEDILEN_TAZMINAT_DOVIZ_ID.Visible = true;

            GridColumn colHUKMEDILEN_TAZMINAT = new GridColumn();
            colHUKMEDILEN_TAZMINAT.VisibleIndex = 36;
            colHUKMEDILEN_TAZMINAT.FieldName = "HUKMEDILEN_TAZMINAT";
            colHUKMEDILEN_TAZMINAT.Name = "colHUKMEDILEN_TAZMINAT";
            colHUKMEDILEN_TAZMINAT.Visible = true;

            GridColumn colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID = new GridColumn();
            colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID.VisibleIndex = 37;
            colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID.FieldName = "ANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID";
            colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID.Name = "colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID";
            colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID.Visible = true;

            GridColumn colANA_PARA_ITIRAZ_TUTARI = new GridColumn();
            colANA_PARA_ITIRAZ_TUTARI.VisibleIndex = 38;
            colANA_PARA_ITIRAZ_TUTARI.FieldName = "ANA_PARA_ITIRAZ_TUTARI";
            colANA_PARA_ITIRAZ_TUTARI.Name = "colANA_PARA_ITIRAZ_TUTARI";
            colANA_PARA_ITIRAZ_TUTARI.Visible = true;

            GridColumn colKABUL_EDILEN_TUTAR_DOVIZ_ID = new GridColumn();
            colKABUL_EDILEN_TUTAR_DOVIZ_ID.VisibleIndex = 39;
            colKABUL_EDILEN_TUTAR_DOVIZ_ID.FieldName = "KABUL_EDILEN_TUTAR_DOVIZ_ID";
            colKABUL_EDILEN_TUTAR_DOVIZ_ID.Name = "colKABUL_EDILEN_TUTAR_DOVIZ_ID";
            colKABUL_EDILEN_TUTAR_DOVIZ_ID.Visible = true;

            GridColumn colKABUL_EDILEN_TUTAR = new GridColumn();
            colKABUL_EDILEN_TUTAR.VisibleIndex = 40;
            colKABUL_EDILEN_TUTAR.FieldName = "KABUL_EDILEN_TUTAR";
            colKABUL_EDILEN_TUTAR.Name = "colKABUL_EDILEN_TUTAR";
            colKABUL_EDILEN_TUTAR.Visible = true;

            GridColumn colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID = new GridColumn();
            colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID.VisibleIndex = 41;
            colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID.FieldName = "FAIZE_ITIRAZ_TUTARI_DOVIZ_ID";
            colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID.Name = "colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID";
            colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID.Visible = true;

            GridColumn colFAIZE_ITIRAZ_TUTARI = new GridColumn();
            colFAIZE_ITIRAZ_TUTARI.VisibleIndex = 42;
            colFAIZE_ITIRAZ_TUTARI.FieldName = "FAIZE_ITIRAZ_TUTARI";
            colFAIZE_ITIRAZ_TUTARI.Name = "colFAIZE_ITIRAZ_TUTARI";
            colFAIZE_ITIRAZ_TUTARI.Visible = true;

            GridColumn colITIRAZ_TUTARI_DOVIZ_ID = new GridColumn();
            colITIRAZ_TUTARI_DOVIZ_ID.VisibleIndex = 43;
            colITIRAZ_TUTARI_DOVIZ_ID.FieldName = "ITIRAZ_TUTARI_DOVIZ_ID";
            colITIRAZ_TUTARI_DOVIZ_ID.Name = "colITIRAZ_TUTARI_DOVIZ_ID";
            colITIRAZ_TUTARI_DOVIZ_ID.Visible = true;

            GridColumn colITIRAZ_TUTARI = new GridColumn();
            colITIRAZ_TUTARI.VisibleIndex = 44;
            colITIRAZ_TUTARI.FieldName = "ITIRAZ_TUTARI";
            colITIRAZ_TUTARI.Name = "colITIRAZ_TUTARI";
            colITIRAZ_TUTARI.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 45;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            GridColumn colDAVA_TALEP = new GridColumn();
            colDAVA_TALEP.VisibleIndex = 46;
            colDAVA_TALEP.FieldName = "DAVA_TALEP";
            colDAVA_TALEP.Name = "colDAVA_TALEP";
            colDAVA_TALEP.Visible = true;

            GridColumn colBIRIM = new GridColumn();
            colBIRIM.VisibleIndex = 47;
            colBIRIM.FieldName = "BIRIM";
            colBIRIM.Name = "colBIRIM";
            colBIRIM.Visible = true;

            GridColumn colDAVA_FOY_NO = new GridColumn();
            colDAVA_FOY_NO.VisibleIndex = 48;
            colDAVA_FOY_NO.FieldName = "DAVA_FOY_NO";
            colDAVA_FOY_NO.Name = "colDAVA_FOY_NO";
            colDAVA_FOY_NO.Visible = true;

            GridColumn colMAHKEME = new GridColumn();
            colMAHKEME.VisibleIndex = 49;
            colMAHKEME.FieldName = "MAHKEME";
            colMAHKEME.Name = "colMAHKEME";
            colMAHKEME.Visible = true;

            GridColumn colBIRIM_NO = new GridColumn();
            colBIRIM_NO.VisibleIndex = 50;
            colBIRIM_NO.FieldName = "BIRIM_NO";
            colBIRIM_NO.Name = "colBIRIM_NO";
            colBIRIM_NO.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 51;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colDAVA_ESAS_NO = new GridColumn();
            colDAVA_ESAS_NO.VisibleIndex = 52;
            colDAVA_ESAS_NO.FieldName = "DAVA_ESAS_NO";
            colDAVA_ESAS_NO.Name = "colDAVA_ESAS_NO";
            colDAVA_ESAS_NO.Visible = true;

            GridColumn colAVUKATA_INTIKAL_TARIHI = new GridColumn();
            colAVUKATA_INTIKAL_TARIHI.VisibleIndex = 53;
            colAVUKATA_INTIKAL_TARIHI.FieldName = "AVUKATA_INTIKAL_TARIHI";
            colAVUKATA_INTIKAL_TARIHI.Name = "colAVUKATA_INTIKAL_TARIHI";
            colAVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 54;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 55;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 56;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colOLAY_SUC_TARIHI = new GridColumn();
            colOLAY_SUC_TARIHI.VisibleIndex = 57;
            colOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            colOLAY_SUC_TARIHI.Name = "colOLAY_SUC_TARIHI";
            colOLAY_SUC_TARIHI.Visible = true;

            GridColumn colDAVACI = new GridColumn();
            colDAVACI.VisibleIndex = 58;
            colDAVACI.FieldName = "DAVACI";
            colDAVACI.Name = "colDAVACI";
            colDAVACI.Visible = true;

            GridColumn colDAVA_EDEN_SIFAT = new GridColumn();
            colDAVA_EDEN_SIFAT.VisibleIndex = 59;
            colDAVA_EDEN_SIFAT.FieldName = "DAVA_EDEN_SIFAT";
            colDAVA_EDEN_SIFAT.Name = "colDAVA_EDEN_SIFAT";
            colDAVA_EDEN_SIFAT.Visible = true;

            GridColumn colDAVA_TARAF_K = new GridColumn();
            colDAVA_TARAF_K.VisibleIndex = 60;
            colDAVA_TARAF_K.FieldName = "DAVA_TARAF_K";
            colDAVA_TARAF_K.Name = "colDAVA_TARAF_K";
            colDAVA_TARAF_K.Visible = true;

            GridColumn colDAVALI = new GridColumn();
            colDAVALI.VisibleIndex = 61;
            colDAVALI.FieldName = "DAVALI";
            colDAVALI.Name = "colDAVALI";
            colDAVALI.Visible = true;

            GridColumn colDAVA_EDILEN_SIFAT = new GridColumn();
            colDAVA_EDILEN_SIFAT.VisibleIndex = 62;
            colDAVA_EDILEN_SIFAT.FieldName = "DAVA_EDILEN_SIFAT";
            colDAVA_EDILEN_SIFAT.Name = "colDAVA_EDILEN_SIFAT";
            colDAVA_EDILEN_SIFAT.Visible = true;

            GridColumn colDAVA_TAKIP_EDILEN_TARAF_K = new GridColumn();
            colDAVA_TAKIP_EDILEN_TARAF_K.VisibleIndex = 63;
            colDAVA_TAKIP_EDILEN_TARAF_K.FieldName = "DAVA_TAKIP_EDILEN_TARAF_K";
            colDAVA_TAKIP_EDILEN_TARAF_K.Name = "colDAVA_TAKIP_EDILEN_TARAF_K";
            colDAVA_TAKIP_EDILEN_TARAF_K.Visible = true;

            GridColumn colDAVA_FOY_ID = new GridColumn();
            colDAVA_FOY_ID.VisibleIndex = 64;
            colDAVA_FOY_ID.FieldName = "DAVA_FOY_ID";
            colDAVA_FOY_ID.Name = "colDAVA_FOY_ID";
            colDAVA_FOY_ID.Visible = true;

            GridColumn colDAVA_ADI = new GridColumn();
            colDAVA_ADI.VisibleIndex = 65;
            colDAVA_ADI.FieldName = "DAVA_ADI";
            colDAVA_ADI.Name = "colDAVA_ADI";
            colDAVA_ADI.Visible = true;

            GridColumn colHUKUM_TARIHI = new GridColumn();
            colHUKUM_TARIHI.VisibleIndex = 66;
            colHUKUM_TARIHI.FieldName = "HUKUM_TARIHI";
            colHUKUM_TARIHI.Name = "colHUKUM_TARIHI";
            colHUKUM_TARIHI.Visible = true;

            GridColumn colKARAR_NO = new GridColumn();
            colKARAR_NO.VisibleIndex = 67;
            colKARAR_NO.FieldName = "KARAR_NO";
            colKARAR_NO.Name = "colKARAR_NO";
            colKARAR_NO.Visible = true;

            GridColumn colHUKUM = new GridColumn();
            colHUKUM.VisibleIndex = 68;
            colHUKUM.FieldName = "HUKUM";
            colHUKUM.Name = "colHUKUM";
            colHUKUM.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 69;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 70;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colID,
			colICRA_ADLIYE,
			colICRA_BIRIM_NO,
			colTAKIP_TARIHI,
			colESAS_NO,
			colVADE_TARIHI,
			colISLEME_KONAN_TUTAR,
			colISLEME_KONAN_TUTAR_DOVIZ_ID,
			colAL_NED_REF1,
			colAL_NED_REF2,
			colBANKA,
			colBANKA_SUBE,
			colKREDI_GRUP,
			colKREDI_TIP,
			colFOY_NO,
			colBORCLU,
			colICRA_SORUMLU,
			colTARAF_SIFAT,
			colFORM_TIPI,
			colDURUM,
			colTALEP_ADI,
			colITIRAZ_EDEN,
			colBORCA_ITIRAZ_VARMI,
			colIMZAYA_ITIRAZ_VARMI,
			colYETKIYE_ITIRAZ_VARMI,
			colGOREVE_ITIRAZ_VARMI,
			colITIRAZ_SEBEP,
			colITIRAZ_MAHKEME,
			colITIRAZ_BIRIM_NO,
			colITIRAZ_GOREV,
			colITIRAZ_ESAS_NO,
			colITIRAZ_TARIHI,
			colITIRAZ_SONUC,
			colYASAL_DAYANAK,
			colITIRAZIN_GIDERILME_YOLU,
			colHUKMEDILEN_TAZMINAT_DOVIZ_ID,
			colHUKMEDILEN_TAZMINAT,
			colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID,
			colANA_PARA_ITIRAZ_TUTARI,
			colKABUL_EDILEN_TUTAR_DOVIZ_ID,
			colKABUL_EDILEN_TUTAR,
			colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID,
			colFAIZE_ITIRAZ_TUTARI,
			colITIRAZ_TUTARI_DOVIZ_ID,
			colITIRAZ_TUTARI,
			colBOLUM,
			colDAVA_TALEP,
			colBIRIM,
			colDAVA_FOY_NO,
			colMAHKEME,
			colBIRIM_NO,
			colGOREV,
			colDAVA_ESAS_NO,
			colAVUKATA_INTIKAL_TARIHI,
			colSORUMLU,
			colIZLEYEN,
			colACIKLAMA,
			colOLAY_SUC_TARIHI,
			colDAVACI,
			colDAVA_EDEN_SIFAT,
			colDAVA_TARAF_K,
			colDAVALI,
			colDAVA_EDILEN_SIFAT,
			colDAVA_TAKIP_EDILEN_TARAF_K,
			colDAVA_FOY_ID,
			colDAVA_ADI,
			colHUKUM_TARIHI,
			colKARAR_NO,
			colHUKUM,
			colSUBE_KOD_ID,
			colKONTROL_KIM_ID,
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

            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("ICRA_ADLIYE", "Icra Adliye");
            dicFieldCaption.Add("ICRA_BIRIM_NO", "Icra Birim No");
            dicFieldCaption.Add("TAKIP_TARIHI", "Takip T");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("VADE_TARIHI", "Vade T");
            dicFieldCaption.Add("ISLEME_KONAN_TUTAR", "İşleme Konan Tutar");
            dicFieldCaption.Add("AL_NED_REF1", ANRefNo);
            dicFieldCaption.Add("AL_NED_REF2", ANRefNo2);
            dicFieldCaption.Add("BANKA", "Banka");
            dicFieldCaption.Add("BANKA_SUBE", "Şube");
            dicFieldCaption.Add("KREDI_GRUP", "Kredi Grup");
            dicFieldCaption.Add("KREDI_TIP", "Kredi Tip");
            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("BORCLU", "Borçlu");
            dicFieldCaption.Add("ICRA_SORUMLU", "Icra Sorumlu");
            dicFieldCaption.Add("TARAF_SIFAT", "Taraf Sıfat");
            dicFieldCaption.Add("FORM_TIPI", "Form Tipi");
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("TALEP_ADI", "Talep Adı");
            dicFieldCaption.Add("ITIRAZ_EDEN", "İtiraz Eden");
            dicFieldCaption.Add("BORCA_ITIRAZ_VARMI", "Borca İtiraz Var");
            dicFieldCaption.Add("IMZAYA_ITIRAZ_VARMI", "İmzaya İtiraz Var");
            dicFieldCaption.Add("YETKIYE_ITIRAZ_VARMI", "Yetkiye İtiraz Var");
            dicFieldCaption.Add("GOREVE_ITIRAZ_VARMI", "Göreve İtiraz Var");
            dicFieldCaption.Add("ITIRAZ_SEBEP", "İtiraz Sebeb");
            dicFieldCaption.Add("ITIRAZ_MAHKEME", "İtiraz Mahkeme");
            dicFieldCaption.Add("ITIRAZ_BIRIM_NO", "İtiraz Birim No");
            dicFieldCaption.Add("ITIRAZ_GOREV", "İtiraz Görev");
            dicFieldCaption.Add("ITIRAZ_ESAS_NO", "İtiraz Esas No");
            dicFieldCaption.Add("ITIRAZ_TARIHI", "İtiraz T");
            dicFieldCaption.Add("ITIRAZ_SONUC", "İtiraz Sonuç");
            dicFieldCaption.Add("YASAL_DAYANAK", "Yasal Dayanak");
            dicFieldCaption.Add("ITIRAZIN_GIDERILME_YOLU", "İtirazın Giderilme Yolu");
            dicFieldCaption.Add("HUKMEDILEN_TAZMINAT", "Hükmedilen Tazminat");
            dicFieldCaption.Add("ANA_PARA_ITIRAZ_TUTARI", "Ana Paraya İtiraz Tutarı");
            dicFieldCaption.Add("KABUL_EDILEN_TUTAR", "Kabul Edilşen İtiraz tutarı");
            dicFieldCaption.Add("FAIZE_ITIRAZ_TUTARI", "Faize İtiraz Tutarı");
            dicFieldCaption.Add("ITIRAZ_TUTARI", "İtiraz Tutarı");
            dicFieldCaption.Add("BOLUM", "Bölüm");
            dicFieldCaption.Add("DAVA_TALEP", "Dava Talep");
            dicFieldCaption.Add("BIRIM", "Birim");
            dicFieldCaption.Add("DAVA_FOY_NO", "Dava Dosya No");
            dicFieldCaption.Add("MAHKEME", "Dava Mahkeme");
            dicFieldCaption.Add("BIRIM_NO", "Dava Birim No");
            dicFieldCaption.Add("GOREV", "Dava Görev");
            dicFieldCaption.Add("DAVA_ESAS_NO", "Dava Esas No");
            dicFieldCaption.Add("AVUKATA_INTIKAL_TARIHI", "Dava İntikal T");
            dicFieldCaption.Add("SORUMLU", "Sorumlu");
            dicFieldCaption.Add("IZLEYEN", "İzleyen");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("OLAY_SUC_TARIHI", "Olay Suç T");
            dicFieldCaption.Add("DAVACI", "Davacı");
            dicFieldCaption.Add("DAVA_EDEN_SIFAT", "Dava Eden Sıfat");
            dicFieldCaption.Add("DAVA_TARAF_K", "Dava Eden T.K.");
            dicFieldCaption.Add("DAVALI", "Davalı");
            dicFieldCaption.Add("DAVA_EDILEN_SIFAT", "Davalı Sıfat");
            dicFieldCaption.Add("DAVA_TAKIP_EDILEN_TARAF_K", "Davalı T.K");
            dicFieldCaption.Add("DAVA_FOY_ID", "");
            dicFieldCaption.Add("DAVA_ADI", "Dava Adı");
            dicFieldCaption.Add("HUKUM_TARIHI", "Hüküm T");
            dicFieldCaption.Add("KARAR_NO", "karar No");
            dicFieldCaption.Add("HUKUM", "Hüküm");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
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

            sozluk.Add("DovizId", InitsEx.DovizTipGetir);

            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("ISLEME_KONAN_TUTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("ISLEME_KONAN_TUTAR_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("ANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("ANA_PARA_ITIRAZ_TUTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("KABUL_EDILEN_TUTAR_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("KABUL_EDILEN_TUTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("FAIZE_ITIRAZ_TUTARI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("FAIZE_ITIRAZ_TUTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("ITIRAZ_TUTARI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("ITIRAZ_TUTARI", InitsEx.ParaBicimiAyarla);

            #endregion Add item

            return sozluk;
        }
    }
}