using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class TutuklanmaVeGozAlti
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

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 0;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colHAZIRLIK_NO = new GridColumn();
            colHAZIRLIK_NO.VisibleIndex = 1;
            colHAZIRLIK_NO.FieldName = "HAZIRLIK_NO";
            colHAZIRLIK_NO.Name = "colHAZIRLIK_NO";
            colHAZIRLIK_NO.Visible = true;

            GridColumn colSIKAYET_TARIHI = new GridColumn();
            colSIKAYET_TARIHI.VisibleIndex = 2;
            colSIKAYET_TARIHI.FieldName = "SIKAYET_TARIHI";
            colSIKAYET_TARIHI.Name = "colSIKAYET_TARIHI";
            colSIKAYET_TARIHI.Visible = true;

            GridColumn colDAVA_TALEP = new GridColumn();
            colDAVA_TALEP.VisibleIndex = 3;
            colDAVA_TALEP.FieldName = "DAVA_TALEP";
            colDAVA_TALEP.Name = "colDAVA_TALEP";
            colDAVA_TALEP.Visible = true;

            GridColumn colHAZIRLIK_TARIH = new GridColumn();
            colHAZIRLIK_TARIH.VisibleIndex = 4;
            colHAZIRLIK_TARIH.FieldName = "HAZIRLIK_TARIH";
            colHAZIRLIK_TARIH.Name = "colHAZIRLIK_TARIH";
            colHAZIRLIK_TARIH.Visible = true;

            GridColumn colHAZIRLIK_ESAS_NO = new GridColumn();
            colHAZIRLIK_ESAS_NO.VisibleIndex = 5;
            colHAZIRLIK_ESAS_NO.FieldName = "HAZIRLIK_ESAS_NO";
            colHAZIRLIK_ESAS_NO.Name = "colHAZIRLIK_ESAS_NO";
            colHAZIRLIK_ESAS_NO.Visible = true;

            GridColumn colREFERANS_NO2 = new GridColumn();
            colREFERANS_NO2.VisibleIndex = 6;
            colREFERANS_NO2.FieldName = "REFERANS_NO2";
            colREFERANS_NO2.Name = "colREFERANS_NO2";
            colREFERANS_NO2.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 7;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 8;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 9;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 10;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 11;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 12;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colTUTUKLANMA_TIP = new GridColumn();
            colTUTUKLANMA_TIP.VisibleIndex = 13;
            colTUTUKLANMA_TIP.FieldName = "TUTUKLANMA_TIP";
            colTUTUKLANMA_TIP.Name = "colTUTUKLANMA_TIP";
            colTUTUKLANMA_TIP.Visible = true;

            GridColumn colTUTUKLAMA_GELIS_TIP = new GridColumn();
            colTUTUKLAMA_GELIS_TIP.VisibleIndex = 14;
            colTUTUKLAMA_GELIS_TIP.FieldName = "TUTUKLAMA_GELIS_TIP";
            colTUTUKLAMA_GELIS_TIP.Name = "colTUTUKLAMA_GELIS_TIP";
            colTUTUKLAMA_GELIS_TIP.Visible = true;

            GridColumn colTUTUKLANMA_TARIHI = new GridColumn();
            colTUTUKLANMA_TARIHI.VisibleIndex = 15;
            colTUTUKLANMA_TARIHI.FieldName = "TUTUKLANMA_TARIHI";
            colTUTUKLANMA_TARIHI.Name = "colTUTUKLANMA_TARIHI";
            colTUTUKLANMA_TARIHI.Visible = true;

            GridColumn colTUTUKLANMA_SAATI = new GridColumn();
            colTUTUKLANMA_SAATI.VisibleIndex = 16;
            colTUTUKLANMA_SAATI.FieldName = "TUTUKLANMA_SAATI";
            colTUTUKLANMA_SAATI.Name = "colTUTUKLANMA_SAATI";
            colTUTUKLANMA_SAATI.Visible = true;

            GridColumn colSERBEST_BIRAKILMA_TARIHI = new GridColumn();
            colSERBEST_BIRAKILMA_TARIHI.VisibleIndex = 17;
            colSERBEST_BIRAKILMA_TARIHI.FieldName = "SERBEST_BIRAKILMA_TARIHI";
            colSERBEST_BIRAKILMA_TARIHI.Name = "colSERBEST_BIRAKILMA_TARIHI";
            colSERBEST_BIRAKILMA_TARIHI.Visible = true;

            GridColumn colSERBEST_BIRAKILMA_SAATI = new GridColumn();
            colSERBEST_BIRAKILMA_SAATI.VisibleIndex = 18;
            colSERBEST_BIRAKILMA_SAATI.FieldName = "SERBEST_BIRAKILMA_SAATI";
            colSERBEST_BIRAKILMA_SAATI.Name = "colSERBEST_BIRAKILMA_SAATI";
            colSERBEST_BIRAKILMA_SAATI.Visible = true;

            GridColumn colSERBEST_BIRAKILMA_NEDEN = new GridColumn();
            colSERBEST_BIRAKILMA_NEDEN.VisibleIndex = 19;
            colSERBEST_BIRAKILMA_NEDEN.FieldName = "SERBEST_BIRAKILMA_NEDEN";
            colSERBEST_BIRAKILMA_NEDEN.Name = "colSERBEST_BIRAKILMA_NEDEN";
            colSERBEST_BIRAKILMA_NEDEN.Visible = true;

            GridColumn colTUTUKLU_KALINAN_YER = new GridColumn();
            colTUTUKLU_KALINAN_YER.VisibleIndex = 20;
            colTUTUKLU_KALINAN_YER.FieldName = "TUTUKLU_KALINAN_YER";
            colTUTUKLU_KALINAN_YER.Name = "colTUTUKLU_KALINAN_YER";
            colTUTUKLU_KALINAN_YER.Visible = true;

            GridColumn colTUTUKLU = new GridColumn();
            colTUTUKLU.VisibleIndex = 21;
            colTUTUKLU.FieldName = "TUTUKLU";
            colTUTUKLU.Name = "colTUTUKLU";
            colTUTUKLU.Visible = true;

            GridColumn colTUTUKLANMA_KARARINA_ITIRAZ_TARIHI = new GridColumn();
            colTUTUKLANMA_KARARINA_ITIRAZ_TARIHI.VisibleIndex = 22;
            colTUTUKLANMA_KARARINA_ITIRAZ_TARIHI.FieldName = "TUTUKLANMA_KARARINA_ITIRAZ_TARIHI";
            colTUTUKLANMA_KARARINA_ITIRAZ_TARIHI.Name = "colTUTUKLANMA_KARARINA_ITIRAZ_TARIHI";
            colTUTUKLANMA_KARARINA_ITIRAZ_TARIHI.Visible = true;

            GridColumn colTUTUKLAMANIN_GERI_ALINMASI_TARIHI = new GridColumn();
            colTUTUKLAMANIN_GERI_ALINMASI_TARIHI.VisibleIndex = 23;
            colTUTUKLAMANIN_GERI_ALINMASI_TARIHI.FieldName = "TUTUKLAMANIN_GERI_ALINMASI_TARIHI";
            colTUTUKLAMANIN_GERI_ALINMASI_TARIHI.Name = "colTUTUKLAMANIN_GERI_ALINMASI_TARIHI";
            colTUTUKLAMANIN_GERI_ALINMASI_TARIHI.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 24;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colTUTUKLANMA_ID = new GridColumn();
            colTUTUKLANMA_ID.VisibleIndex = 25;
            colTUTUKLANMA_ID.FieldName = "TUTUKLANMA_ID";
            colTUTUKLANMA_ID.Name = "colTUTUKLANMA_ID";
            colTUTUKLANMA_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			//colID,
			colHAZIRLIK_NO,
			colSIKAYET_TARIHI,
			colDAVA_TALEP,
			colHAZIRLIK_TARIH,
			colHAZIRLIK_ESAS_NO,

			//colREFERANS_NO2,
			colDURUM,
			colADLIYE,
			colNO,
			colGOREV,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
			colTUTUKLANMA_TIP,
			colTUTUKLAMA_GELIS_TIP,
			colTUTUKLANMA_TARIHI,
			colTUTUKLANMA_SAATI,
			colSERBEST_BIRAKILMA_TARIHI,
			colSERBEST_BIRAKILMA_SAATI,
			colSERBEST_BIRAKILMA_NEDEN,
			colTUTUKLU_KALINAN_YER,
			colTUTUKLU,
			colTUTUKLANMA_KARARINA_ITIRAZ_TARIHI,
			colTUTUKLAMANIN_GERI_ALINMASI_TARIHI,
			colACIKLAMA,

			//colTUTUKLANMA_ID,
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

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldHAZIRLIK_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_NO.AreaIndex = 1;
            fieldHAZIRLIK_NO.FieldName = "HAZIRLIK_NO";
            fieldHAZIRLIK_NO.Name = "fieldHAZIRLIK_NO";
            fieldHAZIRLIK_NO.Visible = false;

            PivotGridField fieldSIKAYET_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSIKAYET_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSIKAYET_TARIHI.AreaIndex = 2;
            fieldSIKAYET_TARIHI.FieldName = "SIKAYET_TARIHI";
            fieldSIKAYET_TARIHI.Name = "fieldSIKAYET_TARIHI";
            fieldSIKAYET_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 3;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldHAZIRLIK_TARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_TARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_TARIH.AreaIndex = 4;
            fieldHAZIRLIK_TARIH.FieldName = "HAZIRLIK_TARIH";
            fieldHAZIRLIK_TARIH.Name = "fieldHAZIRLIK_TARIH";
            fieldHAZIRLIK_TARIH.Visible = false;

            PivotGridField fieldHAZIRLIK_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_ESAS_NO.AreaIndex = 5;
            fieldHAZIRLIK_ESAS_NO.FieldName = "HAZIRLIK_ESAS_NO";
            fieldHAZIRLIK_ESAS_NO.Name = "fieldHAZIRLIK_ESAS_NO";
            fieldHAZIRLIK_ESAS_NO.Visible = false;

            PivotGridField fieldREFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO2.AreaIndex = 6;
            fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
            fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";
            fieldREFERANS_NO2.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 7;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 8;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 9;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 10;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 11;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 12;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldTUTUKLANMA_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTUKLANMA_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTUKLANMA_TIP.AreaIndex = 13;
            fieldTUTUKLANMA_TIP.FieldName = "TUTUKLANMA_TIP";
            fieldTUTUKLANMA_TIP.Name = "fieldTUTUKLANMA_TIP";
            fieldTUTUKLANMA_TIP.Visible = false;

            PivotGridField fieldTUTUKLAMA_GELIS_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTUKLAMA_GELIS_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTUKLAMA_GELIS_TIP.AreaIndex = 14;
            fieldTUTUKLAMA_GELIS_TIP.FieldName = "TUTUKLAMA_GELIS_TIP";
            fieldTUTUKLAMA_GELIS_TIP.Name = "fieldTUTUKLAMA_GELIS_TIP";
            fieldTUTUKLAMA_GELIS_TIP.Visible = false;

            PivotGridField fieldTUTUKLANMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTUKLANMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTUKLANMA_TARIHI.AreaIndex = 15;
            fieldTUTUKLANMA_TARIHI.FieldName = "TUTUKLANMA_TARIHI";
            fieldTUTUKLANMA_TARIHI.Name = "fieldTUTUKLANMA_TARIHI";
            fieldTUTUKLANMA_TARIHI.Visible = false;

            PivotGridField fieldTUTUKLANMA_SAATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTUKLANMA_SAATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTUKLANMA_SAATI.AreaIndex = 16;
            fieldTUTUKLANMA_SAATI.FieldName = "TUTUKLANMA_SAATI";
            fieldTUTUKLANMA_SAATI.Name = "fieldTUTUKLANMA_SAATI";
            fieldTUTUKLANMA_SAATI.Visible = false;

            PivotGridField fieldSERBEST_BIRAKILMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSERBEST_BIRAKILMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSERBEST_BIRAKILMA_TARIHI.AreaIndex = 17;
            fieldSERBEST_BIRAKILMA_TARIHI.FieldName = "SERBEST_BIRAKILMA_TARIHI";
            fieldSERBEST_BIRAKILMA_TARIHI.Name = "fieldSERBEST_BIRAKILMA_TARIHI";
            fieldSERBEST_BIRAKILMA_TARIHI.Visible = false;

            PivotGridField fieldSERBEST_BIRAKILMA_SAATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSERBEST_BIRAKILMA_SAATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSERBEST_BIRAKILMA_SAATI.AreaIndex = 18;
            fieldSERBEST_BIRAKILMA_SAATI.FieldName = "SERBEST_BIRAKILMA_SAATI";
            fieldSERBEST_BIRAKILMA_SAATI.Name = "fieldSERBEST_BIRAKILMA_SAATI";
            fieldSERBEST_BIRAKILMA_SAATI.Visible = false;

            PivotGridField fieldSERBEST_BIRAKILMA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSERBEST_BIRAKILMA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSERBEST_BIRAKILMA_NEDEN.AreaIndex = 19;
            fieldSERBEST_BIRAKILMA_NEDEN.FieldName = "SERBEST_BIRAKILMA_NEDEN";
            fieldSERBEST_BIRAKILMA_NEDEN.Name = "fieldSERBEST_BIRAKILMA_NEDEN";
            fieldSERBEST_BIRAKILMA_NEDEN.Visible = false;

            PivotGridField fieldTUTUKLU_KALINAN_YER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTUKLU_KALINAN_YER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTUKLU_KALINAN_YER.AreaIndex = 20;
            fieldTUTUKLU_KALINAN_YER.FieldName = "TUTUKLU_KALINAN_YER";
            fieldTUTUKLU_KALINAN_YER.Name = "fieldTUTUKLU_KALINAN_YER";
            fieldTUTUKLU_KALINAN_YER.Visible = false;

            PivotGridField fieldTUTUKLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTUKLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTUKLU.AreaIndex = 21;
            fieldTUTUKLU.FieldName = "TUTUKLU";
            fieldTUTUKLU.Name = "fieldTUTUKLU";
            fieldTUTUKLU.Visible = false;

            PivotGridField fieldTUTUKLANMA_KARARINA_ITIRAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTUKLANMA_KARARINA_ITIRAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTUKLANMA_KARARINA_ITIRAZ_TARIHI.AreaIndex = 22;
            fieldTUTUKLANMA_KARARINA_ITIRAZ_TARIHI.FieldName = "TUTUKLANMA_KARARINA_ITIRAZ_TARIHI";
            fieldTUTUKLANMA_KARARINA_ITIRAZ_TARIHI.Name = "fieldTUTUKLANMA_KARARINA_ITIRAZ_TARIHI";
            fieldTUTUKLANMA_KARARINA_ITIRAZ_TARIHI.Visible = false;

            PivotGridField fieldTUTUKLAMANIN_GERI_ALINMASI_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTUKLAMANIN_GERI_ALINMASI_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTUKLAMANIN_GERI_ALINMASI_TARIHI.AreaIndex = 23;
            fieldTUTUKLAMANIN_GERI_ALINMASI_TARIHI.FieldName = "TUTUKLAMANIN_GERI_ALINMASI_TARIHI";
            fieldTUTUKLAMANIN_GERI_ALINMASI_TARIHI.Name = "fieldTUTUKLAMANIN_GERI_ALINMASI_TARIHI";
            fieldTUTUKLAMANIN_GERI_ALINMASI_TARIHI.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 24;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldTUTUKLANMA_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTUKLANMA_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTUKLANMA_ID.AreaIndex = 25;
            fieldTUTUKLANMA_ID.FieldName = "TUTUKLANMA_ID";
            fieldTUTUKLANMA_ID.Name = "fieldTUTUKLANMA_ID";
            fieldTUTUKLANMA_ID.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldHAZIRLIK_NO,
			fieldSIKAYET_TARIHI,
			fieldDAVA_TALEP,
			fieldHAZIRLIK_TARIH,
			fieldHAZIRLIK_ESAS_NO,

			//fieldREFERANS_NO2,
			fieldDURUM,
			fieldADLIYE,
			fieldNO,
			fieldGOREV,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldTUTUKLANMA_TIP,
			fieldTUTUKLAMA_GELIS_TIP,
			fieldTUTUKLANMA_TARIHI,
			fieldTUTUKLANMA_SAATI,
			fieldSERBEST_BIRAKILMA_TARIHI,
			fieldSERBEST_BIRAKILMA_SAATI,
			fieldSERBEST_BIRAKILMA_NEDEN,
			fieldTUTUKLU_KALINAN_YER,
			fieldTUTUKLU,
			fieldTUTUKLANMA_KARARINA_ITIRAZ_TARIHI,
			fieldTUTUKLAMANIN_GERI_ALINMASI_TARIHI,
			fieldACIKLAMA,
			fieldTUTUKLANMA_ID,
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

            #region Caption Edit

            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("HAZIRLIK_NO", "Soruşturma No");
            dicFieldCaption.Add("SIKAYET_TARIHI", "Şikayet T.");
            dicFieldCaption.Add("DAVA_TALEP", "Soruşturma Konusu");
            dicFieldCaption.Add("HAZIRLIK_TARIH", "Soruşturma T.");
            dicFieldCaption.Add("HAZIRLIK_ESAS_NO", "Soruşturma Esas No:");
            dicFieldCaption.Add("REFERANS_NO2", "");
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("ADLIYE", "Mahkeme");
            dicFieldCaption.Add("NO", "No");
            dicFieldCaption.Add("GOREV", "Görev");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("TUTUKLANMA_TIP", "Tutuklanma Tipi");
            dicFieldCaption.Add("TUTUKLAMA_GELIS_TIP", "Tutuklama Geliş Tip");
            dicFieldCaption.Add("TUTUKLANMA_TARIHI", "Tutuklanma T.");
            dicFieldCaption.Add("TUTUKLANMA_SAATI", "Tutuklanma S.");
            dicFieldCaption.Add("SERBEST_BIRAKILMA_TARIHI", "Serbest Bırakılma T.");
            dicFieldCaption.Add("SERBEST_BIRAKILMA_SAATI", "Serbest Bırakılma S.");
            dicFieldCaption.Add("SERBEST_BIRAKILMA_NEDEN", "Serbest Bırakılma Nedeni");
            dicFieldCaption.Add("TUTUKLU_KALINAN_YER", "Tutuklu Kalınan Yer");
            dicFieldCaption.Add("TUTUKLU", "Tutuklu");
            dicFieldCaption.Add("TUTUKLANMA_KARARINA_ITIRAZ_TARIHI", "Tutuklanma Kararına İtiraz T.");
            dicFieldCaption.Add("TUTUKLAMANIN_GERI_ALINMASI_TARIHI", "Tutuklanmanın Geri Alınma T.");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("TUTUKLANMA_ID", "");

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

            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);

            //sozluk.Add("TUTUKLANMA_ID", Item);

            #endregion Add item

            return sozluk;
        }
    }
}