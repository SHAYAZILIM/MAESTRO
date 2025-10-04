using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class masterIcraBorcluTaahutGenelRapor
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

            GridColumn colRESMI_MI = new GridColumn();
            colRESMI_MI.VisibleIndex = 0;
            colRESMI_MI.FieldName = "RESMI_MI";
            colRESMI_MI.Name = "colRESMI_MI";
            colRESMI_MI.Visible = true;

            GridColumn colTAAHHUT_EDEN = new GridColumn();
            colTAAHHUT_EDEN.VisibleIndex = 1;
            colTAAHHUT_EDEN.FieldName = "TAAHHUT_EDEN";
            colTAAHHUT_EDEN.Name = "colTAAHHUT_EDEN";
            colTAAHHUT_EDEN.Visible = true;

            GridColumn colKABUL_EDEN = new GridColumn();
            colKABUL_EDEN.VisibleIndex = 2;
            colKABUL_EDEN.FieldName = "KABUL_EDEN";
            colKABUL_EDEN.Name = "colKABUL_EDEN";
            colKABUL_EDEN.Visible = true;

            GridColumn colTAAHHUT_TARIHI = new GridColumn();
            colTAAHHUT_TARIHI.VisibleIndex = 3;
            colTAAHHUT_TARIHI.FieldName = "TAAHHUT_TARIHI";
            colTAAHHUT_TARIHI.Name = "colTAAHHUT_TARIHI";
            colTAAHHUT_TARIHI.Visible = true;

            GridColumn colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI = new GridColumn();
            colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.VisibleIndex = 4;
            colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.FieldName = "TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI";
            colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.Name = "colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI";
            colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.Visible = true;

            GridColumn colTAAHHUDU_KABUL_TARIHI = new GridColumn();
            colTAAHHUDU_KABUL_TARIHI.VisibleIndex = 5;
            colTAAHHUDU_KABUL_TARIHI.FieldName = "TAAHHUDU_KABUL_TARIHI";
            colTAAHHUDU_KABUL_TARIHI.Name = "colTAAHHUDU_KABUL_TARIHI";
            colTAAHHUDU_KABUL_TARIHI.Visible = true;

            GridColumn colDAVASI_VAR_MI = new GridColumn();
            colDAVASI_VAR_MI.VisibleIndex = 6;
            colDAVASI_VAR_MI.FieldName = "DAVASI_VAR_MI";
            colDAVASI_VAR_MI.Name = "colDAVASI_VAR_MI";
            colDAVASI_VAR_MI.Visible = true;

            GridColumn colICRA_FOY_NO = new GridColumn();
            colICRA_FOY_NO.VisibleIndex = 7;
            colICRA_FOY_NO.FieldName = "ICRA_FOY_NO";
            colICRA_FOY_NO.Name = "colICRA_FOY_NO";
            colICRA_FOY_NO.Visible = true;

            GridColumn colICRA_ESAS_NO = new GridColumn();
            colICRA_ESAS_NO.VisibleIndex = 8;
            colICRA_ESAS_NO.FieldName = "ICRA_ESAS_NO";
            colICRA_ESAS_NO.Name = "colICRA_ESAS_NO";
            colICRA_ESAS_NO.Visible = true;

            GridColumn colICRA_ADLIYE = new GridColumn();
            colICRA_ADLIYE.VisibleIndex = 9;
            colICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            colICRA_ADLIYE.Name = "colICRA_ADLIYE";
            colICRA_ADLIYE.Visible = true;

            GridColumn colICRA_ADLIBIRIM_NO = new GridColumn();
            colICRA_ADLIBIRIM_NO.VisibleIndex = 10;
            colICRA_ADLIBIRIM_NO.FieldName = "ICRA_ADLIBIRIM_NO";
            colICRA_ADLIBIRIM_NO.Name = "colICRA_ADLIBIRIM_NO";
            colICRA_ADLIBIRIM_NO.Visible = true;

            GridColumn colDAVA_FOY_NO = new GridColumn();
            colDAVA_FOY_NO.VisibleIndex = 11;
            colDAVA_FOY_NO.FieldName = "DAVA_FOY_NO";
            colDAVA_FOY_NO.Name = "colDAVA_FOY_NO";
            colDAVA_FOY_NO.Visible = true;

            GridColumn colDAVA_TARIHI = new GridColumn();
            colDAVA_TARIHI.VisibleIndex = 12;
            colDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            colDAVA_TARIHI.Name = "colDAVA_TARIHI";
            colDAVA_TARIHI.Visible = true;

            GridColumn colDAVA_ESAS_NO = new GridColumn();
            colDAVA_ESAS_NO.VisibleIndex = 13;
            colDAVA_ESAS_NO.FieldName = "DAVA_ESAS_NO";
            colDAVA_ESAS_NO.Name = "colDAVA_ESAS_NO";
            colDAVA_ESAS_NO.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 14;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colMAHKEME = new GridColumn();
            colMAHKEME.VisibleIndex = 15;
            colMAHKEME.FieldName = "MAHKEME";
            colMAHKEME.Name = "colMAHKEME";
            colMAHKEME.Visible = true;

            GridColumn colADLI_BIRIM_NO = new GridColumn();
            colADLI_BIRIM_NO.VisibleIndex = 16;
            colADLI_BIRIM_NO.FieldName = "ADLI_BIRIM_NO";
            colADLI_BIRIM_NO.Name = "colADLI_BIRIM_NO";
            colADLI_BIRIM_NO.Visible = true;

            GridColumn colSIRA_NO = new GridColumn();
            colSIRA_NO.VisibleIndex = 17;
            colSIRA_NO.FieldName = "SIRA_NO";
            colSIRA_NO.Name = "colSIRA_NO";
            colSIRA_NO.Visible = true;

            GridColumn colTAAHHUTU_YERINE_GETIRME_TARIHI = new GridColumn();
            colTAAHHUTU_YERINE_GETIRME_TARIHI.VisibleIndex = 18;
            colTAAHHUTU_YERINE_GETIRME_TARIHI.FieldName = "TAAHHUTU_YERINE_GETIRME_TARIHI";
            colTAAHHUTU_YERINE_GETIRME_TARIHI.Name = "colTAAHHUTU_YERINE_GETIRME_TARIHI";
            colTAAHHUTU_YERINE_GETIRME_TARIHI.Visible = true;

            GridColumn colTAAHHUT_MIKTARI_DOVIZ_ID = new GridColumn();
            colTAAHHUT_MIKTARI_DOVIZ_ID.VisibleIndex = 19;
            colTAAHHUT_MIKTARI_DOVIZ_ID.FieldName = "TAAHHUT_MIKTARI_DOVIZ_ID";
            colTAAHHUT_MIKTARI_DOVIZ_ID.Name = "colTAAHHUT_MIKTARI_DOVIZ_ID";
            colTAAHHUT_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colTAAHHUT_MIKTARI = new GridColumn();
            colTAAHHUT_MIKTARI.VisibleIndex = 20;
            colTAAHHUT_MIKTARI.FieldName = "TAAHHUT_MIKTARI";
            colTAAHHUT_MIKTARI.Name = "colTAAHHUT_MIKTARI";
            colTAAHHUT_MIKTARI.Visible = true;

            GridColumn colTAAHHUTTEN_KALAN_MIKTAR = new GridColumn();
            colTAAHHUTTEN_KALAN_MIKTAR.VisibleIndex = 21;
            colTAAHHUTTEN_KALAN_MIKTAR.FieldName = "TAAHHUTTEN_KALAN_MIKTAR";
            colTAAHHUTTEN_KALAN_MIKTAR.Name = "colTAAHHUTTEN_KALAN_MIKTAR";
            colTAAHHUTTEN_KALAN_MIKTAR.Visible = true;

            GridColumn colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID = new GridColumn();
            colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.VisibleIndex = 22;
            colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.FieldName = "TAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID";
            colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Name = "colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID";
            colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colODEME_MIKTARI = new GridColumn();
            colODEME_MIKTARI.VisibleIndex = 23;
            colODEME_MIKTARI.FieldName = "ODEME_MIKTARI";
            colODEME_MIKTARI.Name = "colODEME_MIKTARI";
            colODEME_MIKTARI.Visible = true;

            GridColumn colODEME_MIKTARI_DOVIZ_ID = new GridColumn();
            colODEME_MIKTARI_DOVIZ_ID.VisibleIndex = 24;
            colODEME_MIKTARI_DOVIZ_ID.FieldName = "ODEME_MIKTARI_DOVIZ_ID";
            colODEME_MIKTARI_DOVIZ_ID.Name = "colODEME_MIKTARI_DOVIZ_ID";
            colODEME_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 25;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 26;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 27;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colICRA_FOY_ID = new GridColumn();
            colICRA_FOY_ID.VisibleIndex = 28;
            colICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            colICRA_FOY_ID.Name = "colICRA_FOY_ID";
            colICRA_FOY_ID.Visible = true;

            GridColumn colDAVA_FOY_ID = new GridColumn();
            colDAVA_FOY_ID.VisibleIndex = 29;
            colDAVA_FOY_ID.FieldName = "DAVA_FOY_ID";
            colDAVA_FOY_ID.Name = "colDAVA_FOY_ID";
            colDAVA_FOY_ID.Visible = true;

            GridColumn colICRA_BOLUM_ID = new GridColumn();
            colICRA_BOLUM_ID.VisibleIndex = 30;
            colICRA_BOLUM_ID.FieldName = "ICRA_BOLUM_ID";
            colICRA_BOLUM_ID.Name = "colICRA_BOLUM_ID";
            colICRA_BOLUM_ID.Visible = true;

            GridColumn colDAVA_BOLUM_ID = new GridColumn();
            colDAVA_BOLUM_ID.VisibleIndex = 31;
            colDAVA_BOLUM_ID.FieldName = "DAVA_BOLUM_ID";
            colDAVA_BOLUM_ID.Name = "colDAVA_BOLUM_ID";
            colDAVA_BOLUM_ID.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 32;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colRESMI_MI,
			colTAAHHUT_EDEN,
			colKABUL_EDEN,
			colTAAHHUT_TARIHI,
			colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI,
			colTAAHHUDU_KABUL_TARIHI,
			colDAVASI_VAR_MI,
			colICRA_FOY_NO,
			colICRA_ESAS_NO,
			colICRA_ADLIYE,
			colICRA_ADLIBIRIM_NO,
			colDAVA_FOY_NO,
			colDAVA_TARIHI,
			colDAVA_ESAS_NO,
			colGOREV,
			colMAHKEME,
			colADLI_BIRIM_NO,
			colSIRA_NO,
			colTAAHHUTU_YERINE_GETIRME_TARIHI,
			colTAAHHUT_MIKTARI_DOVIZ_ID,
			colTAAHHUT_MIKTARI,
			colTAAHHUTTEN_KALAN_MIKTAR,
			colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID,
			colODEME_MIKTARI,
			colODEME_MIKTARI_DOVIZ_ID,
			colDURUM,
			colSUBE_KOD_ID,
			colKONTROL_KIM_ID,
			colICRA_FOY_ID,
			colDAVA_FOY_ID,
			colICRA_BOLUM_ID,
			colDAVA_BOLUM_ID,
			colID,
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

        public PivotGridField[] GetPivotFields(string pencere)
        {
            #region Field & Properties

            PivotGridField fieldRESMI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRESMI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRESMI_MI.AreaIndex = 0;
            fieldRESMI_MI.FieldName = "RESMI_MI";
            fieldRESMI_MI.Name = "fieldRESMI_MI";
            fieldRESMI_MI.Visible = false;

            PivotGridField fieldTAAHHUT_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUT_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUT_EDEN.AreaIndex = 1;
            fieldTAAHHUT_EDEN.FieldName = "TAAHHUT_EDEN";
            fieldTAAHHUT_EDEN.Name = "fieldTAAHHUT_EDEN";
            fieldTAAHHUT_EDEN.Visible = false;

            PivotGridField fieldKABUL_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKABUL_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKABUL_EDEN.AreaIndex = 2;
            fieldKABUL_EDEN.FieldName = "KABUL_EDEN";
            fieldKABUL_EDEN.Name = "fieldKABUL_EDEN";
            fieldKABUL_EDEN.Visible = false;

            PivotGridField fieldTAAHHUT_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUT_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUT_TARIHI.AreaIndex = 3;
            fieldTAAHHUT_TARIHI.FieldName = "TAAHHUT_TARIHI";
            fieldTAAHHUT_TARIHI.Name = "fieldTAAHHUT_TARIHI";
            fieldTAAHHUT_TARIHI.Visible = false;

            PivotGridField fieldTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.AreaIndex = 4;
            fieldTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.FieldName = "TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI";
            fieldTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.Name = "fieldTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI";
            fieldTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.Visible = false;

            PivotGridField fieldTAAHHUDU_KABUL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUDU_KABUL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUDU_KABUL_TARIHI.AreaIndex = 5;
            fieldTAAHHUDU_KABUL_TARIHI.FieldName = "TAAHHUDU_KABUL_TARIHI";
            fieldTAAHHUDU_KABUL_TARIHI.Name = "fieldTAAHHUDU_KABUL_TARIHI";
            fieldTAAHHUDU_KABUL_TARIHI.Visible = false;

            PivotGridField fieldDAVASI_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVASI_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVASI_VAR_MI.AreaIndex = 6;
            fieldDAVASI_VAR_MI.FieldName = "DAVASI_VAR_MI";
            fieldDAVASI_VAR_MI.Name = "fieldDAVASI_VAR_MI";
            fieldDAVASI_VAR_MI.Visible = false;

            PivotGridField fieldICRA_FOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_FOY_NO.AreaIndex = 7;
            fieldICRA_FOY_NO.FieldName = "ICRA_FOY_NO";
            fieldICRA_FOY_NO.Name = "fieldICRA_FOY_NO";
            fieldICRA_FOY_NO.Visible = false;

            PivotGridField fieldICRA_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ESAS_NO.AreaIndex = 8;
            fieldICRA_ESAS_NO.FieldName = "ICRA_ESAS_NO";
            fieldICRA_ESAS_NO.Name = "fieldICRA_ESAS_NO";
            fieldICRA_ESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 9;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_ADLIBIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIBIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIBIRIM_NO.AreaIndex = 10;
            fieldICRA_ADLIBIRIM_NO.FieldName = "ICRA_ADLIBIRIM_NO";
            fieldICRA_ADLIBIRIM_NO.Name = "fieldICRA_ADLIBIRIM_NO";
            fieldICRA_ADLIBIRIM_NO.Visible = false;

            PivotGridField fieldDAVA_FOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_FOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_FOY_NO.AreaIndex = 11;
            fieldDAVA_FOY_NO.FieldName = "DAVA_FOY_NO";
            fieldDAVA_FOY_NO.Name = "fieldDAVA_FOY_NO";
            fieldDAVA_FOY_NO.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 12;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldDAVA_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_ESAS_NO.AreaIndex = 13;
            fieldDAVA_ESAS_NO.FieldName = "DAVA_ESAS_NO";
            fieldDAVA_ESAS_NO.Name = "fieldDAVA_ESAS_NO";
            fieldDAVA_ESAS_NO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 14;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldMAHKEME = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHKEME.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHKEME.AreaIndex = 15;
            fieldMAHKEME.FieldName = "MAHKEME";
            fieldMAHKEME.Name = "fieldMAHKEME";
            fieldMAHKEME.Visible = false;

            PivotGridField fieldADLI_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_NO.AreaIndex = 16;
            fieldADLI_BIRIM_NO.FieldName = "ADLI_BIRIM_NO";
            fieldADLI_BIRIM_NO.Name = "fieldADLI_BIRIM_NO";
            fieldADLI_BIRIM_NO.Visible = false;

            PivotGridField fieldSIRA_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSIRA_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSIRA_NO.AreaIndex = 17;
            fieldSIRA_NO.FieldName = "SIRA_NO";
            fieldSIRA_NO.Name = "fieldSIRA_NO";
            fieldSIRA_NO.Visible = false;

            PivotGridField fieldTAAHHUTU_YERINE_GETIRME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUTU_YERINE_GETIRME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUTU_YERINE_GETIRME_TARIHI.AreaIndex = 18;
            fieldTAAHHUTU_YERINE_GETIRME_TARIHI.FieldName = "TAAHHUTU_YERINE_GETIRME_TARIHI";
            fieldTAAHHUTU_YERINE_GETIRME_TARIHI.Name = "fieldTAAHHUTU_YERINE_GETIRME_TARIHI";
            fieldTAAHHUTU_YERINE_GETIRME_TARIHI.Visible = false;

            PivotGridField fieldTAAHHUT_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUT_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUT_MIKTARI_DOVIZ_ID.AreaIndex = 19;
            fieldTAAHHUT_MIKTARI_DOVIZ_ID.FieldName = "TAAHHUT_MIKTARI_DOVIZ_ID";
            fieldTAAHHUT_MIKTARI_DOVIZ_ID.Name = "fieldTAAHHUT_MIKTARI_DOVIZ_ID";
            fieldTAAHHUT_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAAHHUT_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUT_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUT_MIKTARI.AreaIndex = 20;
            fieldTAAHHUT_MIKTARI.FieldName = "TAAHHUT_MIKTARI";
            fieldTAAHHUT_MIKTARI.Name = "fieldTAAHHUT_MIKTARI";
            fieldTAAHHUT_MIKTARI.Visible = false;

            PivotGridField fieldTAAHHUTTEN_KALAN_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUTTEN_KALAN_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUTTEN_KALAN_MIKTAR.AreaIndex = 21;
            fieldTAAHHUTTEN_KALAN_MIKTAR.FieldName = "TAAHHUTTEN_KALAN_MIKTAR";
            fieldTAAHHUTTEN_KALAN_MIKTAR.Name = "fieldTAAHHUTTEN_KALAN_MIKTAR";
            fieldTAAHHUTTEN_KALAN_MIKTAR.Visible = false;

            PivotGridField fieldTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.AreaIndex = 22;
            fieldTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.FieldName = "TAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID";
            fieldTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Name = "fieldTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID";
            fieldTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTARI.AreaIndex = 23;
            fieldODEME_MIKTARI.FieldName = "ODEME_MIKTARI";
            fieldODEME_MIKTARI.Name = "fieldODEME_MIKTARI";
            fieldODEME_MIKTARI.Visible = false;

            PivotGridField fieldODEME_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTARI_DOVIZ_ID.AreaIndex = 24;
            fieldODEME_MIKTARI_DOVIZ_ID.FieldName = "ODEME_MIKTARI_DOVIZ_ID";
            fieldODEME_MIKTARI_DOVIZ_ID.Name = "fieldODEME_MIKTARI_DOVIZ_ID";
            fieldODEME_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 25;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 26;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 27;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_FOY_ID.AreaIndex = 28;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.Visible = false;

            PivotGridField fieldDAVA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_FOY_ID.AreaIndex = 29;
            fieldDAVA_FOY_ID.FieldName = "DAVA_FOY_ID";
            fieldDAVA_FOY_ID.Name = "fieldDAVA_FOY_ID";
            fieldDAVA_FOY_ID.Visible = false;

            PivotGridField fieldICRA_BOLUM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BOLUM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BOLUM_ID.AreaIndex = 30;
            fieldICRA_BOLUM_ID.FieldName = "ICRA_BOLUM_ID";
            fieldICRA_BOLUM_ID.Name = "fieldICRA_BOLUM_ID";
            fieldICRA_BOLUM_ID.Visible = false;

            PivotGridField fieldDAVA_BOLUM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_BOLUM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_BOLUM_ID.AreaIndex = 31;
            fieldDAVA_BOLUM_ID.FieldName = "DAVA_BOLUM_ID";
            fieldDAVA_BOLUM_ID.Name = "fieldDAVA_BOLUM_ID";
            fieldDAVA_BOLUM_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 32;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = null;
            switch (pencere)
            {
                case "Resmi Taahhütleri Alınmış Dosyalar":
                    dizi = ResmiTaahutleriAlinmisDosyalar();
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
			fieldRESMI_MI,
			fieldTAAHHUT_EDEN,
			fieldKABUL_EDEN,
			fieldTAAHHUT_TARIHI,
			fieldTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI,
			fieldTAAHHUDU_KABUL_TARIHI,
			fieldDAVASI_VAR_MI,
			fieldICRA_FOY_NO,
			fieldICRA_ESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_ADLIBIRIM_NO,
			fieldDAVA_FOY_NO,
			fieldDAVA_TARIHI,
			fieldDAVA_ESAS_NO,
			fieldGOREV,
			fieldMAHKEME,
			fieldADLI_BIRIM_NO,
			fieldSIRA_NO,
			fieldTAAHHUTU_YERINE_GETIRME_TARIHI,
			fieldTAAHHUT_MIKTARI_DOVIZ_ID,
			fieldTAAHHUT_MIKTARI,
			fieldTAAHHUTTEN_KALAN_MIKTAR,
			fieldTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID,
			fieldODEME_MIKTARI,
			fieldODEME_MIKTARI_DOVIZ_ID,
			fieldDURUM,
			fieldSUBE_KOD_ID,
			fieldKONTROL_KIM_ID,
			fieldICRA_FOY_ID,
			fieldDAVA_FOY_ID,
            fieldICRA_BOLUM_ID,
			fieldDAVA_BOLUM_ID,
			fieldID,
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

            #region Caption Edit

            dicFieldCaption.Add("RESMI_MI", "Resmi");
            dicFieldCaption.Add("TAAHHUT_EDEN", "Taahhut Eden");
            dicFieldCaption.Add("KABUL_EDEN", "Kabul Eden");
            dicFieldCaption.Add("TAAHHUT_TARIHI", "Taahhut T.");
            dicFieldCaption.Add("TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI", "Taahhudün Kabul Edene Tebliğ T.");
            dicFieldCaption.Add("TAAHHUDU_KABUL_TARIHI", "Taahhüdü Kabul T.");
            dicFieldCaption.Add("DAVASI_VAR_MI", "Davası Var");
            dicFieldCaption.Add("ICRA_FOY_NO", "");
            dicFieldCaption.Add("ICRA_ESAS_NO", "Icra Esas No");
            dicFieldCaption.Add("ICRA_ADLIYE", "Icra Adliye");
            dicFieldCaption.Add("ICRA_ADLIBIRIM_NO", "Icra Birim No");
            dicFieldCaption.Add("DAVA_FOY_NO", "Dosya No");
            dicFieldCaption.Add("DAVA_TARIHI", "Dava T.");
            dicFieldCaption.Add("DAVA_ESAS_NO", "Dava Esas No");
            dicFieldCaption.Add("GOREV", "Görev");
            dicFieldCaption.Add("MAHKEME", "Mahkeme");
            dicFieldCaption.Add("ADLI_BIRIM_NO", "Birim No");
            dicFieldCaption.Add("SIRA_NO", "Sıra No");
            dicFieldCaption.Add("TAAHHUTU_YERINE_GETIRME_TARIHI", "Taahhutu Yerine Getirme T.");
            dicFieldCaption.Add("TAAHHUT_MIKTARI", "Taahhut Miktarı");
            dicFieldCaption.Add("TAAHHUTTEN_KALAN_MIKTAR", "Taahhutten Kalan Miktar");
            dicFieldCaption.Add("ODEME_MIKTARI", "Ödeme Miktarı");
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("ICRA_FOY_ID", "");
            dicFieldCaption.Add("DAVA_FOY_ID", "");
            dicFieldCaption.Add("ICRA_BOLUM_ID", "Icra Bölüm");
            dicFieldCaption.Add("DAVA_BOLUM_ID", "Dava Bölüm");
            dicFieldCaption.Add("ID", "Kayıt Sayısı");

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
            sozluk.Add("TAAHHUT_MIKTARI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TAAHHUT_MIKTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TAAHHUTTEN_KALAN_MIKTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("ODEME_MIKTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("ODEME_MIKTARI_DOVIZ_ID", InitsEx.DovizTipGetir);

            #endregion Add item

            return sozluk;
        }

        private PivotGridField[] ResmiTaahutleriAlinmisDosyalar()
        {
            #region Field & Properties

            PivotGridField fieldRESMI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRESMI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRESMI_MI.AreaIndex = 0;
            fieldRESMI_MI.FieldName = "RESMI_MI";
            fieldRESMI_MI.Name = "fieldRESMI_MI";
            fieldRESMI_MI.Visible = true;

            PivotGridField fieldTAAHHUT_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUT_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUT_EDEN.AreaIndex = 1;
            fieldTAAHHUT_EDEN.FieldName = "TAAHHUT_EDEN";
            fieldTAAHHUT_EDEN.Name = "fieldTAAHHUT_EDEN";
            fieldTAAHHUT_EDEN.Visible = false;

            PivotGridField fieldKABUL_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKABUL_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKABUL_EDEN.AreaIndex = 2;
            fieldKABUL_EDEN.FieldName = "KABUL_EDEN";
            fieldKABUL_EDEN.Name = "fieldKABUL_EDEN";
            fieldKABUL_EDEN.Visible = false;

            PivotGridField fieldTAAHHUT_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUT_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUT_TARIHI.AreaIndex = 3;
            fieldTAAHHUT_TARIHI.FieldName = "TAAHHUT_TARIHI";
            fieldTAAHHUT_TARIHI.Name = "fieldTAAHHUT_TARIHI";
            fieldTAAHHUT_TARIHI.Visible = true;

            PivotGridField fieldTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.AreaIndex = 4;
            fieldTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.FieldName = "TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI";
            fieldTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.Name = "fieldTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI";
            fieldTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.Visible = false;

            PivotGridField fieldTAAHHUDU_KABUL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUDU_KABUL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUDU_KABUL_TARIHI.AreaIndex = 5;
            fieldTAAHHUDU_KABUL_TARIHI.FieldName = "TAAHHUDU_KABUL_TARIHI";
            fieldTAAHHUDU_KABUL_TARIHI.Name = "fieldTAAHHUDU_KABUL_TARIHI";
            fieldTAAHHUDU_KABUL_TARIHI.Visible = false;

            PivotGridField fieldDAVASI_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVASI_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVASI_VAR_MI.AreaIndex = 6;
            fieldDAVASI_VAR_MI.FieldName = "DAVASI_VAR_MI";
            fieldDAVASI_VAR_MI.Name = "fieldDAVASI_VAR_MI";
            fieldDAVASI_VAR_MI.Visible = false;

            PivotGridField fieldICRA_FOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_FOY_NO.AreaIndex = 7;
            fieldICRA_FOY_NO.FieldName = "ICRA_FOY_NO";
            fieldICRA_FOY_NO.Name = "fieldICRA_FOY_NO";
            fieldICRA_FOY_NO.Visible = false;

            PivotGridField fieldICRA_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ESAS_NO.AreaIndex = 8;
            fieldICRA_ESAS_NO.FieldName = "ICRA_ESAS_NO";
            fieldICRA_ESAS_NO.Name = "fieldICRA_ESAS_NO";
            fieldICRA_ESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 9;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_ADLIBIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIBIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIBIRIM_NO.AreaIndex = 10;
            fieldICRA_ADLIBIRIM_NO.FieldName = "ICRA_ADLIBIRIM_NO";
            fieldICRA_ADLIBIRIM_NO.Name = "fieldICRA_ADLIBIRIM_NO";
            fieldICRA_ADLIBIRIM_NO.Visible = false;

            PivotGridField fieldDAVA_FOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_FOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_FOY_NO.AreaIndex = 11;
            fieldDAVA_FOY_NO.FieldName = "DAVA_FOY_NO";
            fieldDAVA_FOY_NO.Name = "fieldDAVA_FOY_NO";
            fieldDAVA_FOY_NO.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 12;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = true;

            PivotGridField fieldDAVA_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_ESAS_NO.AreaIndex = 13;
            fieldDAVA_ESAS_NO.FieldName = "DAVA_ESAS_NO";
            fieldDAVA_ESAS_NO.Name = "fieldDAVA_ESAS_NO";
            fieldDAVA_ESAS_NO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 14;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldMAHKEME = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHKEME.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHKEME.AreaIndex = 15;
            fieldMAHKEME.FieldName = "MAHKEME";
            fieldMAHKEME.Name = "fieldMAHKEME";
            fieldMAHKEME.Visible = false;

            PivotGridField fieldADLI_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_NO.AreaIndex = 16;
            fieldADLI_BIRIM_NO.FieldName = "ADLI_BIRIM_NO";
            fieldADLI_BIRIM_NO.Name = "fieldADLI_BIRIM_NO";
            fieldADLI_BIRIM_NO.Visible = false;

            PivotGridField fieldSIRA_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSIRA_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSIRA_NO.AreaIndex = 17;
            fieldSIRA_NO.FieldName = "SIRA_NO";
            fieldSIRA_NO.Name = "fieldSIRA_NO";
            fieldSIRA_NO.Visible = false;

            PivotGridField fieldTAAHHUTU_YERINE_GETIRME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUTU_YERINE_GETIRME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUTU_YERINE_GETIRME_TARIHI.AreaIndex = 18;
            fieldTAAHHUTU_YERINE_GETIRME_TARIHI.FieldName = "TAAHHUTU_YERINE_GETIRME_TARIHI";
            fieldTAAHHUTU_YERINE_GETIRME_TARIHI.Name = "fieldTAAHHUTU_YERINE_GETIRME_TARIHI";
            fieldTAAHHUTU_YERINE_GETIRME_TARIHI.Visible = false;

            PivotGridField fieldTAAHHUT_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUT_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUT_MIKTARI_DOVIZ_ID.AreaIndex = 19;
            fieldTAAHHUT_MIKTARI_DOVIZ_ID.FieldName = "TAAHHUT_MIKTARI_DOVIZ_ID";
            fieldTAAHHUT_MIKTARI_DOVIZ_ID.Name = "fieldTAAHHUT_MIKTARI_DOVIZ_ID";
            fieldTAAHHUT_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAAHHUT_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUT_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUT_MIKTARI.AreaIndex = 20;
            fieldTAAHHUT_MIKTARI.FieldName = "TAAHHUT_MIKTARI";
            fieldTAAHHUT_MIKTARI.Name = "fieldTAAHHUT_MIKTARI";
            fieldTAAHHUT_MIKTARI.Visible = true;

            PivotGridField fieldTAAHHUTTEN_KALAN_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUTTEN_KALAN_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUTTEN_KALAN_MIKTAR.AreaIndex = 21;
            fieldTAAHHUTTEN_KALAN_MIKTAR.FieldName = "TAAHHUTTEN_KALAN_MIKTAR";
            fieldTAAHHUTTEN_KALAN_MIKTAR.Name = "fieldTAAHHUTTEN_KALAN_MIKTAR";
            fieldTAAHHUTTEN_KALAN_MIKTAR.Visible = false;

            PivotGridField fieldTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.AreaIndex = 22;
            fieldTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.FieldName = "TAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID";
            fieldTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Name = "fieldTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID";
            fieldTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTARI.AreaIndex = 23;
            fieldODEME_MIKTARI.FieldName = "ODEME_MIKTARI";
            fieldODEME_MIKTARI.Name = "fieldODEME_MIKTARI";
            fieldODEME_MIKTARI.Visible = true;

            PivotGridField fieldODEME_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTARI_DOVIZ_ID.AreaIndex = 24;
            fieldODEME_MIKTARI_DOVIZ_ID.FieldName = "ODEME_MIKTARI_DOVIZ_ID";
            fieldODEME_MIKTARI_DOVIZ_ID.Name = "fieldODEME_MIKTARI_DOVIZ_ID";
            fieldODEME_MIKTARI_DOVIZ_ID.Visible = true;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 25;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = true;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 26;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 27;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_FOY_ID.AreaIndex = 28;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.Visible = false;

            PivotGridField fieldDAVA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_FOY_ID.AreaIndex = 29;
            fieldDAVA_FOY_ID.FieldName = "DAVA_FOY_ID";
            fieldDAVA_FOY_ID.Name = "fieldDAVA_FOY_ID";
            fieldDAVA_FOY_ID.Visible = false;

            PivotGridField fieldICRA_BOLUM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BOLUM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BOLUM_ID.AreaIndex = 30;
            fieldICRA_BOLUM_ID.FieldName = "ICRA_BOLUM_ID";
            fieldICRA_BOLUM_ID.Name = "fieldICRA_BOLUM_ID";
            fieldICRA_BOLUM_ID.Visible = true;

            PivotGridField fieldDAVA_BOLUM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_BOLUM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_BOLUM_ID.AreaIndex = 31;
            fieldDAVA_BOLUM_ID.FieldName = "DAVA_BOLUM_ID";
            fieldDAVA_BOLUM_ID.Name = "fieldDAVA_BOLUM_ID";
            fieldDAVA_BOLUM_ID.Visible = true;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 32;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
            fieldRESMI_MI,
			fieldTAAHHUT_TARIHI,
			fieldDAVA_TARIHI,
            fieldSUBE_KOD_ID,
			fieldTAAHHUT_MIKTARI,
			fieldODEME_MIKTARI,
			fieldDURUM,
            fieldICRA_BOLUM_ID,
			fieldDAVA_BOLUM_ID,
			};
            return dizi;
        }
    }
}