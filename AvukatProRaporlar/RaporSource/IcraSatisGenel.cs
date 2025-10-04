using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class IcraSatisGenel
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

            GridColumn colSATIS_SIRA_NO = new GridColumn();
            colSATIS_SIRA_NO.VisibleIndex = 1;
            colSATIS_SIRA_NO.FieldName = "SATIS_SIRA_NO";
            colSATIS_SIRA_NO.Name = "colSATIS_SIRA_NO";
            colSATIS_SIRA_NO.Visible = true;

            GridColumn colSATIS_SEKLI = new GridColumn();
            colSATIS_SEKLI.VisibleIndex = 2;
            colSATIS_SEKLI.FieldName = "SATIS_SEKLI";
            colSATIS_SEKLI.Name = "colSATIS_SEKLI";
            colSATIS_SEKLI.Visible = true;

            GridColumn colALACAKLI = new GridColumn();
            colALACAKLI.VisibleIndex = 3;
            colALACAKLI.FieldName = "ALACAKLI";
            colALACAKLI.Name = "colALACAKLI";
            colALACAKLI.Visible = true;

            GridColumn colBORCLU = new GridColumn();
            colBORCLU.VisibleIndex = 4;
            colBORCLU.FieldName = "BORCLU";
            colBORCLU.Name = "colBORCLU";
            colBORCLU.Visible = true;

            GridColumn colSATIS_MEMURU = new GridColumn();
            colSATIS_MEMURU.VisibleIndex = 5;
            colSATIS_MEMURU.FieldName = "SATIS_MEMURU";
            colSATIS_MEMURU.Name = "colSATIS_MEMURU";
            colSATIS_MEMURU.Visible = true;

            GridColumn colSATIS_SORUMLUSU = new GridColumn();
            colSATIS_SORUMLUSU.VisibleIndex = 6;
            colSATIS_SORUMLUSU.FieldName = "SATIS_SORUMLUSU";
            colSATIS_SORUMLUSU.Name = "colSATIS_SORUMLUSU";
            colSATIS_SORUMLUSU.Visible = true;

            GridColumn colSATIS_ISTEME_TARIHI = new GridColumn();
            colSATIS_ISTEME_TARIHI.VisibleIndex = 7;
            colSATIS_ISTEME_TARIHI.FieldName = "SATIS_ISTEME_TARIHI";
            colSATIS_ISTEME_TARIHI.Name = "colSATIS_ISTEME_TARIHI";
            colSATIS_ISTEME_TARIHI.Visible = true;

            GridColumn colSATIS_TURU = new GridColumn();
            colSATIS_TURU.VisibleIndex = 8;
            colSATIS_TURU.FieldName = "SATIS_TURU";
            colSATIS_TURU.Name = "colSATIS_TURU";
            colSATIS_TURU.Visible = true;

            GridColumn colILAN_SEKLI = new GridColumn();
            colILAN_SEKLI.VisibleIndex = 9;
            colILAN_SEKLI.FieldName = "ILAN_SEKLI";
            colILAN_SEKLI.Name = "colILAN_SEKLI";
            colILAN_SEKLI.Visible = true;

            GridColumn colILAN_TARIHI = new GridColumn();
            colILAN_TARIHI.VisibleIndex = 10;
            colILAN_TARIHI.FieldName = "ILAN_TARIHI";
            colILAN_TARIHI.Name = "colILAN_TARIHI";
            colILAN_TARIHI.Visible = true;

            GridColumn colSATIS_TARIHI_1 = new GridColumn();
            colSATIS_TARIHI_1.VisibleIndex = 11;
            colSATIS_TARIHI_1.FieldName = "SATIS_TARIHI_1";
            colSATIS_TARIHI_1.Name = "colSATIS_TARIHI_1";
            colSATIS_TARIHI_1.Visible = true;

            GridColumn colSATIS_TARIHI_2 = new GridColumn();
            colSATIS_TARIHI_2.VisibleIndex = 12;
            colSATIS_TARIHI_2.FieldName = "SATIS_TARIHI_2";
            colSATIS_TARIHI_2.Name = "colSATIS_TARIHI_2";
            colSATIS_TARIHI_2.Visible = true;

            GridColumn colSATIS_KESINLESME_TARIHI = new GridColumn();
            colSATIS_KESINLESME_TARIHI.VisibleIndex = 13;
            colSATIS_KESINLESME_TARIHI.FieldName = "SATIS_KESINLESME_TARIHI";
            colSATIS_KESINLESME_TARIHI.Name = "colSATIS_KESINLESME_TARIHI";
            colSATIS_KESINLESME_TARIHI.Visible = true;

            GridColumn colVAKTINDE_MI = new GridColumn();
            colVAKTINDE_MI.VisibleIndex = 14;
            colVAKTINDE_MI.FieldName = "VAKTINDE_MI";
            colVAKTINDE_MI.Name = "colVAKTINDE_MI";
            colVAKTINDE_MI.Visible = true;

            GridColumn colVAKTINDEN_ONCE_NEDENI = new GridColumn();
            colVAKTINDEN_ONCE_NEDENI.VisibleIndex = 15;
            colVAKTINDEN_ONCE_NEDENI.FieldName = "VAKTINDEN_ONCE_NEDENI";
            colVAKTINDEN_ONCE_NEDENI.Name = "colVAKTINDEN_ONCE_NEDENI";
            colVAKTINDEN_ONCE_NEDENI.Visible = true;

            GridColumn colSATIS_TATILI_VAR_MI = new GridColumn();
            colSATIS_TATILI_VAR_MI.VisibleIndex = 16;
            colSATIS_TATILI_VAR_MI.FieldName = "SATIS_TATILI_VAR_MI";
            colSATIS_TATILI_VAR_MI.Name = "colSATIS_TATILI_VAR_MI";
            colSATIS_TATILI_VAR_MI.Visible = true;

            GridColumn colSATIS_TATIL_NEDENI = new GridColumn();
            colSATIS_TATIL_NEDENI.VisibleIndex = 17;
            colSATIS_TATIL_NEDENI.FieldName = "SATIS_TATIL_NEDENI";
            colSATIS_TATIL_NEDENI.Name = "colSATIS_TATIL_NEDENI";
            colSATIS_TATIL_NEDENI.Visible = true;

            GridColumn colSEHIR_ICI_DISI = new GridColumn();
            colSEHIR_ICI_DISI.VisibleIndex = 18;
            colSEHIR_ICI_DISI.FieldName = "SEHIR_ICI_DISI";
            colSEHIR_ICI_DISI.Name = "colSEHIR_ICI_DISI";
            colSEHIR_ICI_DISI.Visible = true;

            GridColumn colSATIS_GERCEKLESME_TARIHI = new GridColumn();
            colSATIS_GERCEKLESME_TARIHI.VisibleIndex = 19;
            colSATIS_GERCEKLESME_TARIHI.FieldName = "SATIS_GERCEKLESME_TARIHI";
            colSATIS_GERCEKLESME_TARIHI.Name = "colSATIS_GERCEKLESME_TARIHI";
            colSATIS_GERCEKLESME_TARIHI.Visible = true;

            GridColumn colBOLGE = new GridColumn();
            colBOLGE.VisibleIndex = 20;
            colBOLGE.FieldName = "BOLGE";
            colBOLGE.Name = "colBOLGE";
            colBOLGE.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 21;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colFOY_BIRIM = new GridColumn();
            colFOY_BIRIM.VisibleIndex = 22;
            colFOY_BIRIM.FieldName = "FOY_BIRIM";
            colFOY_BIRIM.Name = "colFOY_BIRIM";
            colFOY_BIRIM.Visible = true;

            GridColumn colFOY_YERI = new GridColumn();
            colFOY_YERI.VisibleIndex = 23;
            colFOY_YERI.FieldName = "FOY_YERI";
            colFOY_YERI.Name = "colFOY_YERI";
            colFOY_YERI.Visible = true;

            GridColumn colTAHSILAT_DURUM = new GridColumn();
            colTAHSILAT_DURUM.VisibleIndex = 24;
            colTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            colTAHSILAT_DURUM.Name = "colTAHSILAT_DURUM";
            colTAHSILAT_DURUM.Visible = true;

            GridColumn colICRA_ADLIYE = new GridColumn();
            colICRA_ADLIYE.VisibleIndex = 25;
            colICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            colICRA_ADLIYE.Name = "colICRA_ADLIYE";
            colICRA_ADLIYE.Visible = true;

            GridColumn colICRA_BIRIM_NO = new GridColumn();
            colICRA_BIRIM_NO.VisibleIndex = 26;
            colICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Name = "colICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 27;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 28;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 29;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 30;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 31;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 32;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colID,
			colSATIS_SIRA_NO,
			colSATIS_SEKLI,
			colALACAKLI,
			colBORCLU,
			colSATIS_MEMURU,
			colSATIS_SORUMLUSU,
			colSATIS_ISTEME_TARIHI,
			colSATIS_TURU,
			colILAN_SEKLI,
			colILAN_TARIHI,
			colSATIS_TARIHI_1,
			colSATIS_TARIHI_2,
			colSATIS_KESINLESME_TARIHI,
			colVAKTINDE_MI,
			colVAKTINDEN_ONCE_NEDENI,
			colSATIS_TATILI_VAR_MI,
			colSATIS_TATIL_NEDENI,
			colSEHIR_ICI_DISI,
			colSATIS_GERCEKLESME_TARIHI,
			colBOLGE,
			colBANKA,
			colFOY_BIRIM,
			colFOY_YERI,
			colTAHSILAT_DURUM,
			colICRA_ADLIYE,
			colICRA_BIRIM_NO,
			colFOY_NO,
			colESAS_NO,
			colTAKIP_TARIHI,
			colKONTROL_KIM_ID,
			colBOLUM,
			colSUBE_KOD_ID,
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
            PivotGridField[] dizi = null;

            #region Field & Properties

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 21;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 23;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 24;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 25;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 26;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 27;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 28;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 29;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 30;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 5;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldSATIS_SIRA_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_SIRA_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_SIRA_NO.AreaIndex = 6;
            fieldSATIS_SIRA_NO.FieldName = "SATIS_SIRA_NO";
            fieldSATIS_SIRA_NO.Name = "fieldSATIS_SIRA_NO";
            fieldSATIS_SIRA_NO.Visible = false;

            PivotGridField fieldSATIS_SEKLI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_SEKLI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_SEKLI.AreaIndex = 7;
            fieldSATIS_SEKLI.FieldName = "SATIS_SEKLI";
            fieldSATIS_SEKLI.Name = "fieldSATIS_SEKLI";
            fieldSATIS_SEKLI.Visible = false;

            PivotGridField fieldALACAKLI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAKLI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAKLI.AreaIndex = 8;
            fieldALACAKLI.FieldName = "ALACAKLI";
            fieldALACAKLI.Name = "fieldALACAKLI";
            fieldALACAKLI.Visible = false;

            PivotGridField fieldBORCLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORCLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORCLU.AreaIndex = 9;
            fieldBORCLU.FieldName = "BORCLU";
            fieldBORCLU.Name = "fieldBORCLU";
            fieldBORCLU.Visible = false;

            PivotGridField fieldSATIS_MEMURU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_MEMURU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_MEMURU.AreaIndex = 10;
            fieldSATIS_MEMURU.FieldName = "SATIS_MEMURU";
            fieldSATIS_MEMURU.Name = "fieldSATIS_MEMURU";
            fieldSATIS_MEMURU.Visible = false;

            PivotGridField fieldSATIS_SORUMLUSU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_SORUMLUSU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_SORUMLUSU.AreaIndex = 11;
            fieldSATIS_SORUMLUSU.FieldName = "SATIS_SORUMLUSU";
            fieldSATIS_SORUMLUSU.Name = "fieldSATIS_SORUMLUSU";
            fieldSATIS_SORUMLUSU.Visible = false;

            PivotGridField fieldSATIS_ISTEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_ISTEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_ISTEME_TARIHI.AreaIndex = 12;
            fieldSATIS_ISTEME_TARIHI.FieldName = "SATIS_ISTEME_TARIHI";
            fieldSATIS_ISTEME_TARIHI.Name = "fieldSATIS_ISTEME_TARIHI";
            fieldSATIS_ISTEME_TARIHI.Visible = false;

            PivotGridField fieldSATIS_TURU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_TURU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_TURU.AreaIndex = 13;
            fieldSATIS_TURU.FieldName = "SATIS_TURU";
            fieldSATIS_TURU.Name = "fieldSATIS_TURU";
            fieldSATIS_TURU.Visible = false;

            PivotGridField fieldILAN_SEKLI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAN_SEKLI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAN_SEKLI.AreaIndex = 14;
            fieldILAN_SEKLI.FieldName = "ILAN_SEKLI";
            fieldILAN_SEKLI.Name = "fieldILAN_SEKLI";
            fieldILAN_SEKLI.Visible = false;

            PivotGridField fieldILAN_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAN_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAN_TARIHI.AreaIndex = 15;
            fieldILAN_TARIHI.FieldName = "ILAN_TARIHI";
            fieldILAN_TARIHI.Name = "fieldILAN_TARIHI";
            fieldILAN_TARIHI.Visible = false;

            PivotGridField fieldSATIS_TARIHI_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_TARIHI_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_TARIHI_1.AreaIndex = 16;
            fieldSATIS_TARIHI_1.FieldName = "SATIS_TARIHI_1";
            fieldSATIS_TARIHI_1.Name = "fieldSATIS_TARIHI_1";
            fieldSATIS_TARIHI_1.Visible = false;

            PivotGridField fieldSATIS_TARIHI_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_TARIHI_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_TARIHI_2.AreaIndex = 17;
            fieldSATIS_TARIHI_2.FieldName = "SATIS_TARIHI_2";
            fieldSATIS_TARIHI_2.Name = "fieldSATIS_TARIHI_2";
            fieldSATIS_TARIHI_2.Visible = false;

            PivotGridField fieldSATIS_KESINLESME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_KESINLESME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_KESINLESME_TARIHI.AreaIndex = 18;
            fieldSATIS_KESINLESME_TARIHI.FieldName = "SATIS_KESINLESME_TARIHI";
            fieldSATIS_KESINLESME_TARIHI.Name = "fieldSATIS_KESINLESME_TARIHI";
            fieldSATIS_KESINLESME_TARIHI.Visible = false;

            PivotGridField fieldVAKTINDE_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVAKTINDE_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVAKTINDE_MI.AreaIndex = 19;
            fieldVAKTINDE_MI.FieldName = "VAKTINDE_MI";
            fieldVAKTINDE_MI.Name = "fieldVAKTINDE_MI";
            fieldVAKTINDE_MI.Visible = false;

            PivotGridField fieldVAKTINDEN_ONCE_NEDENI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVAKTINDEN_ONCE_NEDENI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVAKTINDEN_ONCE_NEDENI.AreaIndex = 20;
            fieldVAKTINDEN_ONCE_NEDENI.FieldName = "VAKTINDEN_ONCE_NEDENI";
            fieldVAKTINDEN_ONCE_NEDENI.Name = "fieldVAKTINDEN_ONCE_NEDENI";
            fieldVAKTINDEN_ONCE_NEDENI.Visible = false;

            PivotGridField fieldSATIS_TATILI_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_TATILI_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_TATILI_VAR_MI.AreaIndex = 21;
            fieldSATIS_TATILI_VAR_MI.FieldName = "SATIS_TATILI_VAR_MI";
            fieldSATIS_TATILI_VAR_MI.Name = "fieldSATIS_TATILI_VAR_MI";
            fieldSATIS_TATILI_VAR_MI.Visible = false;

            PivotGridField fieldSATIS_TATIL_NEDENI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_TATIL_NEDENI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_TATIL_NEDENI.AreaIndex = 22;
            fieldSATIS_TATIL_NEDENI.FieldName = "SATIS_TATIL_NEDENI";
            fieldSATIS_TATIL_NEDENI.Name = "fieldSATIS_TATIL_NEDENI";
            fieldSATIS_TATIL_NEDENI.Visible = false;

            PivotGridField fieldSEHIR_ICI_DISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSEHIR_ICI_DISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSEHIR_ICI_DISI.AreaIndex = 23;
            fieldSEHIR_ICI_DISI.FieldName = "SEHIR_ICI_DISI";
            fieldSEHIR_ICI_DISI.Name = "fieldSEHIR_ICI_DISI";
            fieldSEHIR_ICI_DISI.Visible = false;

            PivotGridField fieldSATIS_GERCEKLESME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_GERCEKLESME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_GERCEKLESME_TARIHI.AreaIndex = 24;
            fieldSATIS_GERCEKLESME_TARIHI.FieldName = "SATIS_GERCEKLESME_TARIHI";
            fieldSATIS_GERCEKLESME_TARIHI.Name = "fieldSATIS_GERCEKLESME_TARIHI";
            fieldSATIS_GERCEKLESME_TARIHI.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 25;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 31;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSUBE_KOD_ID.AreaIndex = 26;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            #endregion Field & Properties

            switch (pencere)
            {
                case "Satış Sayısı (Bürolara Göre)":
                case "Satış Sayısı (Aylara, Yıllara Göre)":
                    dizi = SatisSayisiBurolaraGore();
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
			fieldID,
			fieldSATIS_SIRA_NO,
			fieldSATIS_SEKLI,
			fieldALACAKLI,
			fieldBORCLU,
			fieldSATIS_MEMURU,
			fieldSATIS_SORUMLUSU,
			fieldSATIS_ISTEME_TARIHI,
			fieldSATIS_TURU,
			fieldILAN_SEKLI,
			fieldILAN_TARIHI,
			fieldSATIS_TARIHI_1,
			fieldSATIS_TARIHI_2,
			fieldSATIS_KESINLESME_TARIHI,
			fieldVAKTINDE_MI,
			fieldVAKTINDEN_ONCE_NEDENI,
			fieldSATIS_TATILI_VAR_MI,
			fieldSATIS_TATIL_NEDENI,
			fieldSEHIR_ICI_DISI,
			fieldSATIS_GERCEKLESME_TARIHI,
            fieldBOLGE,
			fieldBANKA,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldTAHSILAT_DURUM,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldFOY_NO,
			fieldESAS_NO,
			fieldTAKIP_TARIHI,
            fieldKONTROL_KIM_ID,
            fieldBOLUM,
			fieldSUBE_KOD_ID,
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

            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("SATIS_SIRA_NO", "Satış Sıra No");
            dicFieldCaption.Add("SATIS_SEKLI", "Satış Şekli");
            dicFieldCaption.Add("ALACAKLI", "Alacaklı");
            dicFieldCaption.Add("BORCLU", "Borçlu");
            dicFieldCaption.Add("SATIS_MEMURU", "Satış Memuru");
            dicFieldCaption.Add("SATIS_SORUMLUSU", "Satış Sorumlusu");
            dicFieldCaption.Add("SATIS_ISTEME_TARIHI", "Satış İsteme T");
            dicFieldCaption.Add("SATIS_TURU", "SAtış Türü");
            dicFieldCaption.Add("ILAN_SEKLI", "İlan Şekli");
            dicFieldCaption.Add("ILAN_TARIHI", "İlan T");
            dicFieldCaption.Add("SATIS_TARIHI_1", "Satış T1");
            dicFieldCaption.Add("SATIS_TARIHI_2", "Satış T2");
            dicFieldCaption.Add("SATIS_KESINLESME_TARIHI", "Satış Kesinleşme T");
            dicFieldCaption.Add("VAKTINDE_MI", "Vaktinde");
            dicFieldCaption.Add("VAKTINDEN_ONCE_NEDENI", "Vaktinden Önce Neden");
            dicFieldCaption.Add("SATIS_TATILI_VAR_MI", "Satış Tatili Var");
            dicFieldCaption.Add("SATIS_TATIL_NEDENI", "Satış Tatil Nedeni");
            dicFieldCaption.Add("SEHIR_ICI_DISI", "Şehir İçi Dışı");
            dicFieldCaption.Add("SATIS_GERCEKLESME_TARIHI", "Satış Gerçkeleşme T");
            dicFieldCaption.Add("BOLGE", "Bölge");
            dicFieldCaption.Add("BANKA", "Banka");
            dicFieldCaption.Add("FOY_BIRIM", "Foy Birim");
            dicFieldCaption.Add("FOY_YERI", "Foy Yeri");
            dicFieldCaption.Add("TAHSILAT_DURUM", "Tahsilat Durum");
            dicFieldCaption.Add("ICRA_ADLIYE", "Adliye");
            dicFieldCaption.Add("ICRA_BIRIM_NO", "Birim No");
            dicFieldCaption.Add("FOY_NO", "Foy No");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("TAKIP_TARIHI", "Takip T.");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("BOLUM", "Bölüm");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");

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

            #endregion Add item

            return sozluk;
        }

        private PivotGridField[] SatisSayisiBurolaraGore()
        {
            #region Field & Properties

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 21;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 23;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 24;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 25;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 26;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 27;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 28;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 29;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 30;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Caption = "Kayıt Sayisi";
            fieldID.AreaIndex = 5;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldSATIS_SIRA_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_SIRA_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_SIRA_NO.AreaIndex = 6;
            fieldSATIS_SIRA_NO.FieldName = "SATIS_SIRA_NO";
            fieldSATIS_SIRA_NO.Name = "fieldSATIS_SIRA_NO";
            fieldSATIS_SIRA_NO.Visible = false;

            PivotGridField fieldSATIS_SEKLI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_SEKLI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_SEKLI.AreaIndex = 7;
            fieldSATIS_SEKLI.FieldName = "SATIS_SEKLI";
            fieldSATIS_SEKLI.Name = "fieldSATIS_SEKLI";
            fieldSATIS_SEKLI.Visible = false;

            PivotGridField fieldALACAKLI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAKLI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAKLI.AreaIndex = 8;
            fieldALACAKLI.FieldName = "ALACAKLI";
            fieldALACAKLI.Name = "fieldALACAKLI";
            fieldALACAKLI.Visible = false;

            PivotGridField fieldBORCLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORCLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORCLU.AreaIndex = 9;
            fieldBORCLU.FieldName = "BORCLU";
            fieldBORCLU.Name = "fieldBORCLU";
            fieldBORCLU.Visible = false;

            PivotGridField fieldSATIS_MEMURU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_MEMURU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_MEMURU.AreaIndex = 10;
            fieldSATIS_MEMURU.FieldName = "SATIS_MEMURU";
            fieldSATIS_MEMURU.Name = "fieldSATIS_MEMURU";
            fieldSATIS_MEMURU.Visible = false;

            PivotGridField fieldSATIS_SORUMLUSU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_SORUMLUSU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_SORUMLUSU.AreaIndex = 11;
            fieldSATIS_SORUMLUSU.FieldName = "SATIS_SORUMLUSU";
            fieldSATIS_SORUMLUSU.Name = "fieldSATIS_SORUMLUSU";
            fieldSATIS_SORUMLUSU.Visible = true;

            PivotGridField fieldSATIS_ISTEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_ISTEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_ISTEME_TARIHI.AreaIndex = 12;
            fieldSATIS_ISTEME_TARIHI.FieldName = "SATIS_ISTEME_TARIHI";
            fieldSATIS_ISTEME_TARIHI.Name = "fieldSATIS_ISTEME_TARIHI";
            fieldSATIS_ISTEME_TARIHI.Visible = false;

            PivotGridField fieldSATIS_TURU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_TURU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_TURU.AreaIndex = 13;
            fieldSATIS_TURU.FieldName = "SATIS_TURU";
            fieldSATIS_TURU.Name = "fieldSATIS_TURU";
            fieldSATIS_TURU.Visible = true;

            PivotGridField fieldILAN_SEKLI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAN_SEKLI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAN_SEKLI.AreaIndex = 14;
            fieldILAN_SEKLI.FieldName = "ILAN_SEKLI";
            fieldILAN_SEKLI.Name = "fieldILAN_SEKLI";
            fieldILAN_SEKLI.Visible = false;

            PivotGridField fieldILAN_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAN_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAN_TARIHI.AreaIndex = 15;
            fieldILAN_TARIHI.FieldName = "ILAN_TARIHI";
            fieldILAN_TARIHI.Name = "fieldILAN_TARIHI";
            fieldILAN_TARIHI.Visible = false;

            PivotGridField fieldSATIS_TARIHI_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_TARIHI_1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSATIS_TARIHI_1.GroupInterval = PivotGroupInterval.DateYear;
            fieldSATIS_TARIHI_1.AreaIndex = 16;
            fieldSATIS_TARIHI_1.FieldName = "SATIS_TARIHI_1";
            fieldSATIS_TARIHI_1.Name = "fieldSATIS_TARIHI_1";
            fieldSATIS_TARIHI_1.Visible = true;

            PivotGridField fieldSATIS_TARIHI_12 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_TARIHI_12.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSATIS_TARIHI_12.GroupInterval = PivotGroupInterval.DateMonth;
            fieldSATIS_TARIHI_12.AreaIndex = 16;
            fieldSATIS_TARIHI_12.FieldName = "SATIS_TARIHI_1";
            fieldSATIS_TARIHI_12.Name = "fieldSATIS_TARIHI_12";
            fieldSATIS_TARIHI_12.Visible = true;

            PivotGridField fieldSATIS_TARIHI_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_TARIHI_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_TARIHI_2.AreaIndex = 17;
            fieldSATIS_TARIHI_2.FieldName = "SATIS_TARIHI_2";
            fieldSATIS_TARIHI_2.Name = "fieldSATIS_TARIHI_2";
            fieldSATIS_TARIHI_2.Visible = false;

            PivotGridField fieldSATIS_KESINLESME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_KESINLESME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_KESINLESME_TARIHI.AreaIndex = 18;
            fieldSATIS_KESINLESME_TARIHI.FieldName = "SATIS_KESINLESME_TARIHI";
            fieldSATIS_KESINLESME_TARIHI.Name = "fieldSATIS_KESINLESME_TARIHI";
            fieldSATIS_KESINLESME_TARIHI.Visible = false;

            PivotGridField fieldVAKTINDE_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVAKTINDE_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVAKTINDE_MI.AreaIndex = 19;
            fieldVAKTINDE_MI.FieldName = "VAKTINDE_MI";
            fieldVAKTINDE_MI.Name = "fieldVAKTINDE_MI";
            fieldVAKTINDE_MI.Visible = false;

            PivotGridField fieldVAKTINDEN_ONCE_NEDENI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVAKTINDEN_ONCE_NEDENI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVAKTINDEN_ONCE_NEDENI.AreaIndex = 20;
            fieldVAKTINDEN_ONCE_NEDENI.FieldName = "VAKTINDEN_ONCE_NEDENI";
            fieldVAKTINDEN_ONCE_NEDENI.Name = "fieldVAKTINDEN_ONCE_NEDENI";
            fieldVAKTINDEN_ONCE_NEDENI.Visible = false;

            PivotGridField fieldSATIS_TATILI_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_TATILI_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_TATILI_VAR_MI.AreaIndex = 21;
            fieldSATIS_TATILI_VAR_MI.FieldName = "SATIS_TATILI_VAR_MI";
            fieldSATIS_TATILI_VAR_MI.Name = "fieldSATIS_TATILI_VAR_MI";
            fieldSATIS_TATILI_VAR_MI.Visible = false;

            PivotGridField fieldSATIS_TATIL_NEDENI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_TATIL_NEDENI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_TATIL_NEDENI.AreaIndex = 22;
            fieldSATIS_TATIL_NEDENI.FieldName = "SATIS_TATIL_NEDENI";
            fieldSATIS_TATIL_NEDENI.Name = "fieldSATIS_TATIL_NEDENI";
            fieldSATIS_TATIL_NEDENI.Visible = false;

            PivotGridField fieldSEHIR_ICI_DISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSEHIR_ICI_DISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSEHIR_ICI_DISI.AreaIndex = 23;
            fieldSEHIR_ICI_DISI.FieldName = "SEHIR_ICI_DISI";
            fieldSEHIR_ICI_DISI.Name = "fieldSEHIR_ICI_DISI";
            fieldSEHIR_ICI_DISI.Visible = false;

            PivotGridField fieldSATIS_GERCEKLESME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATIS_GERCEKLESME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATIS_GERCEKLESME_TARIHI.AreaIndex = 24;
            fieldSATIS_GERCEKLESME_TARIHI.FieldName = "SATIS_GERCEKLESME_TARIHI";
            fieldSATIS_GERCEKLESME_TARIHI.Name = "fieldSATIS_GERCEKLESME_TARIHI";
            fieldSATIS_GERCEKLESME_TARIHI.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 25;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 31;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSUBE_KOD_ID.AreaIndex = 26;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldSATIS_SIRA_NO,
			fieldSATIS_SEKLI,
			fieldALACAKLI,
			fieldBORCLU,
			fieldSATIS_MEMURU,
			fieldSATIS_SORUMLUSU,
			fieldSATIS_ISTEME_TARIHI,
			fieldSATIS_TURU,
			fieldILAN_SEKLI,
			fieldILAN_TARIHI,
			fieldSATIS_TARIHI_1,
            fieldSATIS_TARIHI_12,
			fieldSATIS_TARIHI_2,
			fieldSATIS_KESINLESME_TARIHI,
			fieldVAKTINDE_MI,
			fieldVAKTINDEN_ONCE_NEDENI,
			fieldSATIS_TATILI_VAR_MI,
			fieldSATIS_TATIL_NEDENI,
			fieldSEHIR_ICI_DISI,
			fieldSATIS_GERCEKLESME_TARIHI,
            fieldBOLGE,
			fieldBANKA,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldTAHSILAT_DURUM,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldFOY_NO,
			fieldESAS_NO,
			fieldTAKIP_TARIHI,
            fieldKONTROL_KIM_ID,
            fieldBOLUM,
			fieldSUBE_KOD_ID,
			};
            return dizi;
        }
    }
}