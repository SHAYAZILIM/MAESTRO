using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class DurusmaDavaGenelRapor
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

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 0;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colDAVA_TARIHI = new GridColumn();
            colDAVA_TARIHI.VisibleIndex = 1;
            colDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            colDAVA_TARIHI.Name = "colDAVA_TARIHI";
            colDAVA_TARIHI.Visible = true;

            GridColumn colBIRIM = new GridColumn();
            colBIRIM.VisibleIndex = 2;
            colBIRIM.FieldName = "BIRIM";
            colBIRIM.Name = "colBIRIM";
            colBIRIM.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 3;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colREFERANS_NO2 = new GridColumn();
            colREFERANS_NO2.VisibleIndex = 4;
            colREFERANS_NO2.FieldName = "REFERANS_NO2";
            colREFERANS_NO2.Name = "colREFERANS_NO2";
            colREFERANS_NO2.Visible = true;

            GridColumn colREFERANS_NO3 = new GridColumn();
            colREFERANS_NO3.VisibleIndex = 5;
            colREFERANS_NO3.FieldName = "REFERANS_NO3";
            colREFERANS_NO3.Name = "colREFERANS_NO3";
            colREFERANS_NO3.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 6;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 7;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 8;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 9;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 10;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colAVUKATA_INTIKAL_TARIHI = new GridColumn();
            colAVUKATA_INTIKAL_TARIHI.VisibleIndex = 11;
            colAVUKATA_INTIKAL_TARIHI.FieldName = "AVUKATA_INTIKAL_TARIHI";
            colAVUKATA_INTIKAL_TARIHI.Name = "colAVUKATA_INTIKAL_TARIHI";
            colAVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colDAVACI = new GridColumn();
            colDAVACI.VisibleIndex = 12;
            colDAVACI.FieldName = "DAVACI";
            colDAVACI.Name = "colDAVACI";
            colDAVACI.Visible = true;

            GridColumn colDAVA_EDEN_SIFAT = new GridColumn();
            colDAVA_EDEN_SIFAT.VisibleIndex = 13;
            colDAVA_EDEN_SIFAT.FieldName = "DAVA_EDEN_SIFAT";
            colDAVA_EDEN_SIFAT.Name = "colDAVA_EDEN_SIFAT";
            colDAVA_EDEN_SIFAT.Visible = true;

            GridColumn colDAVALI = new GridColumn();
            colDAVALI.VisibleIndex = 14;
            colDAVALI.FieldName = "DAVALI";
            colDAVALI.Name = "colDAVALI";
            colDAVALI.Visible = true;

            GridColumn colDAVA_EDILEN_SIFAT = new GridColumn();
            colDAVA_EDILEN_SIFAT.VisibleIndex = 15;
            colDAVA_EDILEN_SIFAT.FieldName = "DAVA_EDILEN_SIFAT";
            colDAVA_EDILEN_SIFAT.Name = "colDAVA_EDILEN_SIFAT";
            colDAVA_EDILEN_SIFAT.Visible = true;

            GridColumn colDAVA_TALEP = new GridColumn();
            colDAVA_TALEP.VisibleIndex = 16;
            colDAVA_TALEP.FieldName = "DAVA_TALEP";
            colDAVA_TALEP.Name = "colDAVA_TALEP";
            colDAVA_TALEP.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 17;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colOzelKod1 = new GridColumn();
            colOzelKod1.VisibleIndex = 18;
            colOzelKod1.FieldName = "OzelKod1";
            colOzelKod1.Name = "colOzelKod1";
            colOzelKod1.Visible = true;

            GridColumn colOzelKod2 = new GridColumn();
            colOzelKod2.VisibleIndex = 19;
            colOzelKod2.FieldName = "OzelKod2";
            colOzelKod2.Name = "colOzelKod2";
            colOzelKod2.Visible = true;

            GridColumn colOzelKod3 = new GridColumn();
            colOzelKod3.VisibleIndex = 20;
            colOzelKod3.FieldName = "OzelKod3";
            colOzelKod3.Name = "colOzelKod3";
            colOzelKod3.Visible = true;

            GridColumn colOzelKod4 = new GridColumn();
            colOzelKod4.VisibleIndex = 21;
            colOzelKod4.FieldName = "OzelKod4";
            colOzelKod4.Name = "colOzelKod4";
            colOzelKod4.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 22;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 23;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 24;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colTARIH = new GridColumn();
            colTARIH.VisibleIndex = 25;
            colTARIH.FieldName = "TARIH";
            colTARIH.Name = "colTARIH";
            colTARIH.Visible = true;

            GridColumn colSAAT = new GridColumn();
            colSAAT.VisibleIndex = 26;
            colSAAT.FieldName = "SAAT";
            colSAAT.Name = "colSAAT";
            colSAAT.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 27;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 28;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 29;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 30;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colSUBE = new GridColumn();
            colSUBE.VisibleIndex = 31;
            colSUBE.FieldName = "SUBE";
            colSUBE.Name = "colSUBE";
            colSUBE.Visible = true;

            GridColumn colFOY_BIRIM = new GridColumn();
            colFOY_BIRIM.VisibleIndex = 32;
            colFOY_BIRIM.FieldName = "FOY_BIRIM";
            colFOY_BIRIM.Name = "colFOY_BIRIM";
            colFOY_BIRIM.Visible = true;

            GridColumn colFOY_YERI = new GridColumn();
            colFOY_YERI.VisibleIndex = 33;
            colFOY_YERI.FieldName = "FOY_YERI";
            colFOY_YERI.Name = "colFOY_YERI";
            colFOY_YERI.Visible = true;

            GridColumn colFOY_OZEL_DURUM = new GridColumn();
            colFOY_OZEL_DURUM.VisibleIndex = 34;
            colFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Name = "colFOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Visible = true;

            GridColumn colTAHSILAT_DURUM = new GridColumn();
            colTAHSILAT_DURUM.VisibleIndex = 35;
            colTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            colTAHSILAT_DURUM.Name = "colTAHSILAT_DURUM";
            colTAHSILAT_DURUM.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 36;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 37;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colSORUMLU_AVUKAT1 = new GridColumn();
            colSORUMLU_AVUKAT1.VisibleIndex = 38;
            colSORUMLU_AVUKAT1.FieldName = "SORUMLU_AVUKAT1";
            colSORUMLU_AVUKAT1.Name = "colSORUMLU_AVUKAT1";
            colSORUMLU_AVUKAT1.Visible = true;

            GridColumn colSORUMLU_AVUKAT2 = new GridColumn();
            colSORUMLU_AVUKAT2.VisibleIndex = 39;
            colSORUMLU_AVUKAT2.FieldName = "SORUMLU_AVUKAT2";
            colSORUMLU_AVUKAT2.Name = "colSORUMLU_AVUKAT2";
            colSORUMLU_AVUKAT2.Visible = true;

            GridColumn colHAKIM1 = new GridColumn();
            colHAKIM1.VisibleIndex = 40;
            colHAKIM1.FieldName = "HAKIM1";
            colHAKIM1.Name = "colHAKIM1";
            colHAKIM1.Visible = true;

            GridColumn colHAKIM2 = new GridColumn();
            colHAKIM2.VisibleIndex = 41;
            colHAKIM2.FieldName = "HAKIM2";
            colHAKIM2.Name = "colHAKIM2";
            colHAKIM2.Visible = true;

            GridColumn colHAKIM3 = new GridColumn();
            colHAKIM3.VisibleIndex = 42;
            colHAKIM3.FieldName = "HAKIM3";
            colHAKIM3.Name = "colHAKIM3";
            colHAKIM3.Visible = true;

            GridColumn colSAVCI = new GridColumn();
            colSAVCI.VisibleIndex = 43;
            colSAVCI.FieldName = "SAVCI";
            colSAVCI.Name = "colSAVCI";
            colSAVCI.Visible = true;

            GridColumn colKATIP = new GridColumn();
            colKATIP.VisibleIndex = 44;
            colKATIP.FieldName = "KATIP";
            colKATIP.Name = "colKATIP";
            colKATIP.Visible = true;

            GridColumn colMAZERET_VAR_MI = new GridColumn();
            colMAZERET_VAR_MI.VisibleIndex = 45;
            colMAZERET_VAR_MI.FieldName = "MAZERET_VAR_MI";
            colMAZERET_VAR_MI.Name = "colMAZERET_VAR_MI";
            colMAZERET_VAR_MI.Visible = true;

            GridColumn colMURAFA_MI = new GridColumn();
            colMURAFA_MI.VisibleIndex = 46;
            colMURAFA_MI.FieldName = "MURAFA_MI";
            colMURAFA_MI.Name = "colMURAFA_MI";
            colMURAFA_MI.Visible = true;

            GridColumn colCELSE_MI = new GridColumn();
            colCELSE_MI.VisibleIndex = 47;
            colCELSE_MI.FieldName = "CELSE_MI";
            colCELSE_MI.Name = "colCELSE_MI";
            colCELSE_MI.Visible = true;

            GridColumn colTURU = new GridColumn();
            colTURU.VisibleIndex = 48;
            colTURU.FieldName = "TURU";
            colTURU.Name = "colTURU";
            colTURU.Visible = true;

            GridColumn colCELSE_ACIKLAMA = new GridColumn();
            colCELSE_ACIKLAMA.VisibleIndex = 49;
            colCELSE_ACIKLAMA.FieldName = "CELSE_ACIKLAMA";
            colCELSE_ACIKLAMA.Name = "colCELSE_ACIKLAMA";
            colCELSE_ACIKLAMA.Visible = true;

            GridColumn colCELSE_REFERANS_NO = new GridColumn();
            colCELSE_REFERANS_NO.VisibleIndex = 50;
            colCELSE_REFERANS_NO.FieldName = "CELSE_REFERANS_NO";
            colCELSE_REFERANS_NO.Name = "colCELSE_REFERANS_NO";
            colCELSE_REFERANS_NO.Visible = true;

            GridColumn colCELSE_ID = new GridColumn();
            colCELSE_ID.VisibleIndex = 51;
            colCELSE_ID.FieldName = "CELSE_ID";
            colCELSE_ID.Name = "colCELSE_ID";
            colCELSE_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colDURUM,
			colDAVA_TARIHI,
			colBIRIM,
			colREFERANS_NO,
			colREFERANS_NO2,
			colREFERANS_NO3,
			colADLIYE,
			colNO,
			colGOREV,
			colACIKLAMA,
			colESAS_NO,
			colAVUKATA_INTIKAL_TARIHI,
			colDAVACI,
			colDAVA_EDEN_SIFAT,
			colDAVALI,
			colDAVA_EDILEN_SIFAT,
			colDAVA_TALEP,
			colFOY_NO,
			colOzelKod1,
			colOzelKod2,
			colOzelKod3,
			colOzelKod4,
			colSORUMLU,
			colIZLEYEN,
			colID,
			colTARIH,
			colSAAT,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
			colBOLUM,
			colBANKA,
			colSUBE,
			colFOY_BIRIM,
			colFOY_YERI,
			colFOY_OZEL_DURUM,
			colTAHSILAT_DURUM,
			colKREDI_GRUP,
			colKREDI_TIP,
			colSORUMLU_AVUKAT1,
			colSORUMLU_AVUKAT2,
			colHAKIM1,
			colHAKIM2,
			colHAKIM3,
			colSAVCI,
			colKATIP,
			colMAZERET_VAR_MI,
			colMURAFA_MI,
			colCELSE_MI,
			colTURU,
			colCELSE_ACIKLAMA,
			colCELSE_REFERANS_NO,
			colCELSE_ID,
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
                    dizi[i].Caption = "Brm";

                if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
                {
                    dizi[i].ColumnEdit = editler["DovizId"];
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

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 0;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 1;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldBIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM.AreaIndex = 2;
            fieldBIRIM.FieldName = "BIRIM";
            fieldBIRIM.Name = "fieldBIRIM";
            fieldBIRIM.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 3;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldREFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO2.AreaIndex = 4;
            fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
            fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";
            fieldREFERANS_NO2.Visible = false;

            PivotGridField fieldREFERANS_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO3.AreaIndex = 5;
            fieldREFERANS_NO3.FieldName = "REFERANS_NO3";
            fieldREFERANS_NO3.Name = "fieldREFERANS_NO3";
            fieldREFERANS_NO3.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 6;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 7;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 8;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 9;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 10;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldAVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAVUKATA_INTIKAL_TARIHI.AreaIndex = 11;
            fieldAVUKATA_INTIKAL_TARIHI.FieldName = "AVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Name = "fieldAVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldDAVACI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVACI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVACI.AreaIndex = 12;
            fieldDAVACI.FieldName = "DAVACI";
            fieldDAVACI.Name = "fieldDAVACI";
            fieldDAVACI.Visible = false;

            PivotGridField fieldDAVA_EDEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_EDEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_EDEN_SIFAT.AreaIndex = 13;
            fieldDAVA_EDEN_SIFAT.FieldName = "DAVA_EDEN_SIFAT";
            fieldDAVA_EDEN_SIFAT.Name = "fieldDAVA_EDEN_SIFAT";
            fieldDAVA_EDEN_SIFAT.Visible = false;

            PivotGridField fieldDAVALI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVALI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVALI.AreaIndex = 14;
            fieldDAVALI.FieldName = "DAVALI";
            fieldDAVALI.Name = "fieldDAVALI";
            fieldDAVALI.Visible = false;

            PivotGridField fieldDAVA_EDILEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_EDILEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_EDILEN_SIFAT.AreaIndex = 15;
            fieldDAVA_EDILEN_SIFAT.FieldName = "DAVA_EDILEN_SIFAT";
            fieldDAVA_EDILEN_SIFAT.Name = "fieldDAVA_EDILEN_SIFAT";
            fieldDAVA_EDILEN_SIFAT.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 16;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 17;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldOzelKod1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzelKod1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzelKod1.AreaIndex = 18;
            fieldOzelKod1.FieldName = "OzelKod1";
            fieldOzelKod1.Name = "fieldOzelKod1";
            fieldOzelKod1.Visible = false;

            PivotGridField fieldOzelKod2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzelKod2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzelKod2.AreaIndex = 19;
            fieldOzelKod2.FieldName = "OzelKod2";
            fieldOzelKod2.Name = "fieldOzelKod2";
            fieldOzelKod2.Visible = false;

            PivotGridField fieldOzelKod3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzelKod3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzelKod3.AreaIndex = 20;
            fieldOzelKod3.FieldName = "OzelKod3";
            fieldOzelKod3.Name = "fieldOzelKod3";
            fieldOzelKod3.Visible = false;

            PivotGridField fieldOzelKod4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzelKod4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzelKod4.AreaIndex = 21;
            fieldOzelKod4.FieldName = "OzelKod4";
            fieldOzelKod4.Name = "fieldOzelKod4";
            fieldOzelKod4.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 22;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 23;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 24;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 25;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldSAAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSAAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSAAT.AreaIndex = 26;
            fieldSAAT.FieldName = "SAAT";
            fieldSAAT.Name = "fieldSAAT";
            fieldSAAT.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 27;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 28;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 29;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 30;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldSUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE.AreaIndex = 31;
            fieldSUBE.FieldName = "SUBE";
            fieldSUBE.Name = "fieldSUBE";
            fieldSUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 32;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 33;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 34;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 35;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 36;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 37;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldSORUMLU_AVUKAT1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU_AVUKAT1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU_AVUKAT1.AreaIndex = 38;
            fieldSORUMLU_AVUKAT1.FieldName = "SORUMLU_AVUKAT1";
            fieldSORUMLU_AVUKAT1.Name = "fieldSORUMLU_AVUKAT1";
            fieldSORUMLU_AVUKAT1.Visible = false;

            PivotGridField fieldSORUMLU_AVUKAT2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU_AVUKAT2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU_AVUKAT2.AreaIndex = 39;
            fieldSORUMLU_AVUKAT2.FieldName = "SORUMLU_AVUKAT2";
            fieldSORUMLU_AVUKAT2.Name = "fieldSORUMLU_AVUKAT2";
            fieldSORUMLU_AVUKAT2.Visible = false;

            PivotGridField fieldHAKIM1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAKIM1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAKIM1.AreaIndex = 40;
            fieldHAKIM1.FieldName = "HAKIM1";
            fieldHAKIM1.Name = "fieldHAKIM1";
            fieldHAKIM1.Visible = false;

            PivotGridField fieldHAKIM2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAKIM2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAKIM2.AreaIndex = 41;
            fieldHAKIM2.FieldName = "HAKIM2";
            fieldHAKIM2.Name = "fieldHAKIM2";
            fieldHAKIM2.Visible = false;

            PivotGridField fieldHAKIM3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAKIM3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAKIM3.AreaIndex = 42;
            fieldHAKIM3.FieldName = "HAKIM3";
            fieldHAKIM3.Name = "fieldHAKIM3";
            fieldHAKIM3.Visible = false;

            PivotGridField fieldSAVCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSAVCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSAVCI.AreaIndex = 43;
            fieldSAVCI.FieldName = "SAVCI";
            fieldSAVCI.Name = "fieldSAVCI";
            fieldSAVCI.Visible = false;

            PivotGridField fieldKATIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKATIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKATIP.AreaIndex = 44;
            fieldKATIP.FieldName = "KATIP";
            fieldKATIP.Name = "fieldKATIP";
            fieldKATIP.Visible = false;

            PivotGridField fieldMAZERET_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAZERET_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAZERET_VAR_MI.AreaIndex = 45;
            fieldMAZERET_VAR_MI.FieldName = "MAZERET_VAR_MI";
            fieldMAZERET_VAR_MI.Name = "fieldMAZERET_VAR_MI";
            fieldMAZERET_VAR_MI.Visible = false;

            PivotGridField fieldMURAFA_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMURAFA_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMURAFA_MI.AreaIndex = 46;
            fieldMURAFA_MI.FieldName = "MURAFA_MI";
            fieldMURAFA_MI.Name = "fieldMURAFA_MI";
            fieldMURAFA_MI.Visible = false;

            PivotGridField fieldCELSE_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCELSE_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCELSE_MI.AreaIndex = 47;
            fieldCELSE_MI.FieldName = "CELSE_MI";
            fieldCELSE_MI.Name = "fieldCELSE_MI";
            fieldCELSE_MI.Visible = false;

            PivotGridField fieldTURU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTURU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTURU.AreaIndex = 48;
            fieldTURU.FieldName = "TURU";
            fieldTURU.Name = "fieldTURU";
            fieldTURU.Visible = false;

            PivotGridField fieldCELSE_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCELSE_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCELSE_ACIKLAMA.AreaIndex = 49;
            fieldCELSE_ACIKLAMA.FieldName = "CELSE_ACIKLAMA";
            fieldCELSE_ACIKLAMA.Name = "fieldCELSE_ACIKLAMA";
            fieldCELSE_ACIKLAMA.Visible = false;

            PivotGridField fieldCELSE_REFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCELSE_REFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCELSE_REFERANS_NO.AreaIndex = 50;
            fieldCELSE_REFERANS_NO.FieldName = "CELSE_REFERANS_NO";
            fieldCELSE_REFERANS_NO.Name = "fieldCELSE_REFERANS_NO";
            fieldCELSE_REFERANS_NO.Visible = false;

            PivotGridField fieldCELSE_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCELSE_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCELSE_ID.AreaIndex = 51;
            fieldCELSE_ID.FieldName = "CELSE_ID";
            fieldCELSE_ID.Name = "fieldCELSE_ID";
            fieldCELSE_ID.Visible = false;

            #endregion Field & Properties

            switch (pencere)
            {
                case "Duruşma Sayısı (Bürolara Göre)":
                    dizi = DurusmaSayisiBurolaraGore();
                    break;
                default:
                    dizi = null;
                    break;
            }

            #region []

            if (dizi == null)
            {
                dizi = new PivotGridField[]
		{
			fieldDURUM,
			fieldDAVA_TARIHI,
			fieldBIRIM,
			fieldREFERANS_NO,
			fieldREFERANS_NO2,
			fieldREFERANS_NO3,
			fieldADLIYE,
			fieldNO,
			fieldGOREV,
			fieldACIKLAMA,
			fieldESAS_NO,
			fieldAVUKATA_INTIKAL_TARIHI,
			fieldDAVACI,
			fieldDAVA_EDEN_SIFAT,
			fieldDAVALI,
			fieldDAVA_EDILEN_SIFAT,
			fieldDAVA_TALEP,
			fieldFOY_NO,
			fieldOzelKod1,
			fieldOzelKod2,
			fieldOzelKod3,
			fieldOzelKod4,
			fieldSORUMLU,
			fieldIZLEYEN,
			fieldID,
			fieldTARIH,
			fieldSAAT,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldBOLUM,
			fieldBANKA,
			fieldSUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldTAHSILAT_DURUM,
			fieldKREDI_GRUP,
			fieldKREDI_TIP,
			fieldSORUMLU_AVUKAT1,
			fieldSORUMLU_AVUKAT2,
			fieldHAKIM1,
			fieldHAKIM2,
			fieldHAKIM3,
			fieldSAVCI,
			fieldKATIP,
			fieldMAZERET_VAR_MI,
			fieldMURAFA_MI,
			fieldCELSE_MI,
			fieldTURU,
			fieldCELSE_ACIKLAMA,
			fieldCELSE_REFERANS_NO,
			fieldCELSE_ID,
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

        private PivotGridField[] DurusmaSayisiBurolaraGore()
        {
            #region Field & Properties

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 0;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 1;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldBIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM.AreaIndex = 2;
            fieldBIRIM.FieldName = "BIRIM";
            fieldBIRIM.Name = "fieldBIRIM";
            fieldBIRIM.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 3;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldREFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO2.AreaIndex = 4;
            fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
            fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";
            fieldREFERANS_NO2.Visible = false;

            PivotGridField fieldREFERANS_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO3.AreaIndex = 5;
            fieldREFERANS_NO3.FieldName = "REFERANS_NO3";
            fieldREFERANS_NO3.Name = "fieldREFERANS_NO3";
            fieldREFERANS_NO3.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 6;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 7;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 8;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 9;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 10;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldAVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAVUKATA_INTIKAL_TARIHI.AreaIndex = 11;
            fieldAVUKATA_INTIKAL_TARIHI.FieldName = "AVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Name = "fieldAVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldDAVACI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVACI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVACI.AreaIndex = 12;
            fieldDAVACI.FieldName = "DAVACI";
            fieldDAVACI.Name = "fieldDAVACI";
            fieldDAVACI.Visible = false;

            PivotGridField fieldDAVA_EDEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_EDEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_EDEN_SIFAT.AreaIndex = 13;
            fieldDAVA_EDEN_SIFAT.FieldName = "DAVA_EDEN_SIFAT";
            fieldDAVA_EDEN_SIFAT.Name = "fieldDAVA_EDEN_SIFAT";
            fieldDAVA_EDEN_SIFAT.Visible = false;

            PivotGridField fieldDAVALI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVALI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVALI.AreaIndex = 14;
            fieldDAVALI.FieldName = "DAVALI";
            fieldDAVALI.Name = "fieldDAVALI";
            fieldDAVALI.Visible = false;

            PivotGridField fieldDAVA_EDILEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_EDILEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_EDILEN_SIFAT.AreaIndex = 15;
            fieldDAVA_EDILEN_SIFAT.FieldName = "DAVA_EDILEN_SIFAT";
            fieldDAVA_EDILEN_SIFAT.Name = "fieldDAVA_EDILEN_SIFAT";
            fieldDAVA_EDILEN_SIFAT.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 16;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 17;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldÖzelKod1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldÖzelKod1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldÖzelKod1.AreaIndex = 18;
            fieldÖzelKod1.FieldName = "ÖzelKod1";
            fieldÖzelKod1.Name = "fieldÖzelKod1";
            fieldÖzelKod1.Visible = false;

            PivotGridField fieldÖzelKod2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldÖzelKod2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldÖzelKod2.AreaIndex = 19;
            fieldÖzelKod2.FieldName = "ÖzelKod2";
            fieldÖzelKod2.Name = "fieldÖzelKod2";
            fieldÖzelKod2.Visible = false;

            PivotGridField fieldÖzelKod3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldÖzelKod3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldÖzelKod3.AreaIndex = 20;
            fieldÖzelKod3.FieldName = "ÖzelKod3";
            fieldÖzelKod3.Name = "fieldÖzelKod3";
            fieldÖzelKod3.Visible = false;

            PivotGridField fieldÖzelKod4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldÖzelKod4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldÖzelKod4.AreaIndex = 21;
            fieldÖzelKod4.FieldName = "ÖzelKod4";
            fieldÖzelKod4.Name = "fieldÖzelKod4";
            fieldÖzelKod4.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 22;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 23;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 24;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 25;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldSAAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSAAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSAAT.AreaIndex = 26;
            fieldSAAT.FieldName = "SAAT";
            fieldSAAT.Name = "fieldSAAT";
            fieldSAAT.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 27;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSUBE_KOD_ID.AreaIndex = 28;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            PivotGridField fieldBÖLÜM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBÖLÜM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBÖLÜM.AreaIndex = 29;
            fieldBÖLÜM.FieldName = "BÖLÜM";
            fieldBÖLÜM.Name = "fieldBÖLÜM";
            fieldBÖLÜM.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 30;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldSUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE.AreaIndex = 31;
            fieldSUBE.FieldName = "SUBE";
            fieldSUBE.Name = "fieldSUBE";
            fieldSUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 32;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 33;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 34;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 35;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 36;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 37;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldSORUMLU_AVUKAT1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU_AVUKAT1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU_AVUKAT1.AreaIndex = 38;
            fieldSORUMLU_AVUKAT1.FieldName = "SORUMLU_AVUKAT1";
            fieldSORUMLU_AVUKAT1.Name = "fieldSORUMLU_AVUKAT1";
            fieldSORUMLU_AVUKAT1.Visible = false;

            PivotGridField fieldSORUMLU_AVUKAT2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU_AVUKAT2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU_AVUKAT2.AreaIndex = 39;
            fieldSORUMLU_AVUKAT2.FieldName = "SORUMLU_AVUKAT2";
            fieldSORUMLU_AVUKAT2.Name = "fieldSORUMLU_AVUKAT2";
            fieldSORUMLU_AVUKAT2.Visible = false;

            PivotGridField fieldHAKIM1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAKIM1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAKIM1.AreaIndex = 40;
            fieldHAKIM1.FieldName = "HAKIM1";
            fieldHAKIM1.Name = "fieldHAKIM1";
            fieldHAKIM1.Visible = false;

            PivotGridField fieldHAKIM2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAKIM2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAKIM2.AreaIndex = 41;
            fieldHAKIM2.FieldName = "HAKIM2";
            fieldHAKIM2.Name = "fieldHAKIM2";
            fieldHAKIM2.Visible = false;

            PivotGridField fieldHAKIM3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAKIM3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAKIM3.AreaIndex = 42;
            fieldHAKIM3.FieldName = "HAKIM3";
            fieldHAKIM3.Name = "fieldHAKIM3";
            fieldHAKIM3.Visible = false;

            PivotGridField fieldSAVCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSAVCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSAVCI.AreaIndex = 43;
            fieldSAVCI.FieldName = "SAVCI";
            fieldSAVCI.Name = "fieldSAVCI";
            fieldSAVCI.Visible = false;

            PivotGridField fieldKATIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKATIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKATIP.AreaIndex = 44;
            fieldKATIP.FieldName = "KATIP";
            fieldKATIP.Name = "fieldKATIP";
            fieldKATIP.Visible = false;

            PivotGridField fieldMAZERET_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAZERET_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAZERET_VAR_MI.AreaIndex = 45;
            fieldMAZERET_VAR_MI.FieldName = "MAZERET_VAR_MI";
            fieldMAZERET_VAR_MI.Name = "fieldMAZERET_VAR_MI";
            fieldMAZERET_VAR_MI.Visible = false;

            PivotGridField fieldMURAFA_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMURAFA_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMURAFA_MI.AreaIndex = 46;
            fieldMURAFA_MI.FieldName = "MURAFA_MI";
            fieldMURAFA_MI.Name = "fieldMURAFA_MI";
            fieldMURAFA_MI.Visible = false;

            PivotGridField fieldCELSE_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCELSE_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCELSE_MI.AreaIndex = 47;
            fieldCELSE_MI.FieldName = "CELSE_MI";
            fieldCELSE_MI.Name = "fieldCELSE_MI";
            fieldCELSE_MI.Visible = false;

            PivotGridField fieldTURU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTURU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTURU.AreaIndex = 48;
            fieldTURU.FieldName = "TURU";
            fieldTURU.Name = "fieldTURU";
            fieldTURU.Visible = false;

            PivotGridField fieldCELSE_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCELSE_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCELSE_ACIKLAMA.AreaIndex = 49;
            fieldCELSE_ACIKLAMA.FieldName = "CELSE_ACIKLAMA";
            fieldCELSE_ACIKLAMA.Name = "fieldCELSE_ACIKLAMA";
            fieldCELSE_ACIKLAMA.Visible = false;

            PivotGridField fieldCELSE_REFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCELSE_REFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCELSE_REFERANS_NO.AreaIndex = 50;
            fieldCELSE_REFERANS_NO.FieldName = "CELSE_REFERANS_NO";
            fieldCELSE_REFERANS_NO.Name = "fieldCELSE_REFERANS_NO";
            fieldCELSE_REFERANS_NO.Visible = false;

            PivotGridField fieldCELSE_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCELSE_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldCELSE_ID.Caption = "Kayıt Sayisi";
            fieldCELSE_ID.AreaIndex = 51;
            fieldCELSE_ID.FieldName = "CELSE_ID";
            fieldCELSE_ID.Name = "fieldCELSE_ID";
            fieldCELSE_ID.Visible = true;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldDURUM,
			fieldDAVA_TARIHI,
			fieldBIRIM,
			fieldREFERANS_NO,
			fieldREFERANS_NO2,
			fieldREFERANS_NO3,
			fieldADLIYE,
			fieldNO,
			fieldGOREV,
			fieldACIKLAMA,
			fieldESAS_NO,
			fieldAVUKATA_INTIKAL_TARIHI,
			fieldDAVACI,
			fieldDAVA_EDEN_SIFAT,
			fieldDAVALI,
			fieldDAVA_EDILEN_SIFAT,
			fieldDAVA_TALEP,
			fieldFOY_NO,
			fieldÖzelKod1,
			fieldÖzelKod2,
			fieldÖzelKod3,
			fieldÖzelKod4,
			fieldSORUMLU,
			fieldIZLEYEN,
			fieldID,
			fieldTARIH,
			fieldSAAT,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldBÖLÜM,
			fieldBANKA,
			fieldSUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldTAHSILAT_DURUM,
			fieldKREDI_GRUP,
			fieldKREDI_TIP,
			fieldSORUMLU_AVUKAT1,
			fieldSORUMLU_AVUKAT2,
			fieldHAKIM1,
			fieldHAKIM2,
			fieldHAKIM3,
			fieldSAVCI,
			fieldKATIP,
			fieldMAZERET_VAR_MI,
			fieldMURAFA_MI,
			fieldCELSE_MI,
			fieldTURU,
			fieldCELSE_ACIKLAMA,
			fieldCELSE_REFERANS_NO,
			fieldCELSE_ID,
			};
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

            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("DAVA_TARIHI", "Dava T.");
            dicFieldCaption.Add("BIRIM", "Birim");
            dicFieldCaption.Add("REFERANS_NO", RefNo);
            dicFieldCaption.Add("REFERANS_NO2", RefNo2);
            dicFieldCaption.Add("REFERANS_NO3", refNo3);
            dicFieldCaption.Add("ADLIYE", "Mahkeme");
            dicFieldCaption.Add("NO", "No");
            dicFieldCaption.Add("GOREV", "Görev");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("AVUKATA_INTIKAL_TARIHI", "İntikal T.");
            dicFieldCaption.Add("DAVACI", "Davacı");
            dicFieldCaption.Add("DAVA_EDEN_SIFAT", "Davacı Sıfat");
            dicFieldCaption.Add("DAVALI", "Davalı");
            dicFieldCaption.Add("DAVA_EDILEN_SIFAT", "Davalı Sıfat");
            dicFieldCaption.Add("DAVA_TALEP", "Dava Talep");
            dicFieldCaption.Add("FOY_NO", "Foy No");
            dicFieldCaption.Add("OzelKod1", OzelKod1);
            dicFieldCaption.Add("OzelKod2", OzelKod2);
            dicFieldCaption.Add("OzelKod3", OzelKod3);
            dicFieldCaption.Add("OzelKod4", OzelKod4);
            dicFieldCaption.Add("SORUMLU", "Sorumlu");
            dicFieldCaption.Add("IZLEYEN", "İzleyen");
            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("TARIH", "Celse T.");
            dicFieldCaption.Add("SAAT", "Celse S.");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("BOLUM", "Bölüm");
            dicFieldCaption.Add("BANKA", "Banka");
            dicFieldCaption.Add("SUBE", "Şube");
            dicFieldCaption.Add("FOY_BIRIM", "Foy Birim");
            dicFieldCaption.Add("FOY_YERI", "Foy Yeri");
            dicFieldCaption.Add("FOY_OZEL_DURUM", "Foy Özel Durum");
            dicFieldCaption.Add("TAHSILAT_DURUM", "Tahsilat Durum");
            dicFieldCaption.Add("KREDI_GRUP", "Kredi Grup");
            dicFieldCaption.Add("KREDI_TIP", "Kredi Tip");
            dicFieldCaption.Add("SORUMLU_AVUKAT1", "Celse Sorumlu1");
            dicFieldCaption.Add("SORUMLU_AVUKAT2", "Celse Sorumlu2");
            dicFieldCaption.Add("HAKIM1", "Hakim1");
            dicFieldCaption.Add("HAKIM2", "Hakim2");
            dicFieldCaption.Add("HAKIM3", "Hakim3");
            dicFieldCaption.Add("SAVCI", "Savcı");
            dicFieldCaption.Add("KATIP", "Katip");
            dicFieldCaption.Add("MAZERET_VAR_MI", "Mazaret Var");
            dicFieldCaption.Add("MURAFA_MI", "Murafa");
            dicFieldCaption.Add("CELSE_MI", "Celse");
            dicFieldCaption.Add("TURU", "Türü");
            dicFieldCaption.Add("CELSE_ACIKLAMA", "Celse Açıklama");
            dicFieldCaption.Add("CELSE_REFERANS_NO", "Celse Ref No");
            dicFieldCaption.Add("CELSE_ID", "");

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

            #endregion Add item

            return sozluk;
        }
    }
}