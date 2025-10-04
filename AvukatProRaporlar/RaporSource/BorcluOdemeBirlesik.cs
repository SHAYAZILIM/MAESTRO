using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.Data.PivotGrid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class BorcluOdemeBirlesik
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

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 1;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colICRA_ADLIYE = new GridColumn();
            colICRA_ADLIYE.VisibleIndex = 2;
            colICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            colICRA_ADLIYE.Name = "colICRA_ADLIYE";
            colICRA_ADLIYE.Visible = true;

            GridColumn colICRA_BIRIM_NO = new GridColumn();
            colICRA_BIRIM_NO.VisibleIndex = 3;
            colICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Name = "colICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 4;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 5;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colBOLGE = new GridColumn();
            colBOLGE.VisibleIndex = 6;
            colBOLGE.FieldName = "BOLGE";
            colBOLGE.Name = "colBOLGE";
            colBOLGE.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 7;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 8;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 9;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 10;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colFOY_OZEL_DURUM = new GridColumn();
            colFOY_OZEL_DURUM.VisibleIndex = 11;
            colFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Name = "colFOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Visible = true;

            GridColumn colFOY_YERI = new GridColumn();
            colFOY_YERI.VisibleIndex = 12;
            colFOY_YERI.FieldName = "FOY_YERI";
            colFOY_YERI.Name = "colFOY_YERI";
            colFOY_YERI.Visible = true;

            GridColumn colTAHSILAT_DURUM = new GridColumn();
            colTAHSILAT_DURUM.VisibleIndex = 13;
            colTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            colTAHSILAT_DURUM.Name = "colTAHSILAT_DURUM";
            colTAHSILAT_DURUM.Visible = true;

            GridColumn colFOY_BIRIM = new GridColumn();
            colFOY_BIRIM.VisibleIndex = 14;
            colFOY_BIRIM.FieldName = "FOY_BIRIM";
            colFOY_BIRIM.Name = "colFOY_BIRIM";
            colFOY_BIRIM.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 15;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colODEME_MIKTAR = new GridColumn();
            colODEME_MIKTAR.VisibleIndex = 16;
            colODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            colODEME_MIKTAR.Name = "colODEME_MIKTAR";
            colODEME_MIKTAR.Visible = true;

            GridColumn colODEME_MIKTAR_DOVIZ_ID = new GridColumn();
            colODEME_MIKTAR_DOVIZ_ID.VisibleIndex = 17;
            colODEME_MIKTAR_DOVIZ_ID.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            colODEME_MIKTAR_DOVIZ_ID.Name = "colODEME_MIKTAR_DOVIZ_ID";
            colODEME_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colODEME_TARIHI = new GridColumn();
            colODEME_TARIHI.VisibleIndex = 18;
            colODEME_TARIHI.FieldName = "ODEME_TARIHI";
            colODEME_TARIHI.Name = "colODEME_TARIHI";
            colODEME_TARIHI.Visible = true;

            GridColumn colODEME_YERI = new GridColumn();
            colODEME_YERI.VisibleIndex = 19;
            colODEME_YERI.FieldName = "ODEME_YERI";
            colODEME_YERI.Name = "colODEME_YERI";
            colODEME_YERI.Visible = true;

            GridColumn colODEME_TIP = new GridColumn();
            colODEME_TIP.VisibleIndex = 20;
            colODEME_TIP.FieldName = "ODEME_TIP";
            colODEME_TIP.Name = "colODEME_TIP";
            colODEME_TIP.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 21;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            GridColumn colDAGILIM_TIPI = new GridColumn();
            colDAGILIM_TIPI.VisibleIndex = 22;
            colDAGILIM_TIPI.FieldName = "DAGILIM_TIPI";
            colDAGILIM_TIPI.Name = "colDAGILIM_TIPI";
            colDAGILIM_TIPI.Visible = true;

            GridColumn colTUTAR = new GridColumn();
            colTUTAR.VisibleIndex = 23;
            colTUTAR.FieldName = "TUTAR";
            colTUTAR.Name = "colTUTAR";
            colTUTAR.Visible = true;

            GridColumn colTUTAR_DOVIZ_ID = new GridColumn();
            colTUTAR_DOVIZ_ID.VisibleIndex = 24;
            colTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            colTUTAR_DOVIZ_ID.Name = "colTUTAR_DOVIZ_ID";
            colTUTAR_DOVIZ_ID.Visible = true;

            GridColumn colICRA_FOY_ID = new GridColumn();
            colICRA_FOY_ID.VisibleIndex = 25;
            colICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            colICRA_FOY_ID.Name = "colICRA_FOY_ID";
            colICRA_FOY_ID.Visible = true;

            GridColumn colMAHSUP_KATEGORI = new GridColumn();
            colMAHSUP_KATEGORI.VisibleIndex = 26;
            colMAHSUP_KATEGORI.FieldName = "MAHSUP_KATEGORI";
            colMAHSUP_KATEGORI.Name = "colMAHSUP_KATEGORI";
            colMAHSUP_KATEGORI.Visible = true;

            GridColumn colMAHSUP_ALT_KATEGORI = new GridColumn();
            colMAHSUP_ALT_KATEGORI.VisibleIndex = 27;
            colMAHSUP_ALT_KATEGORI.FieldName = "MAHSUP_ALT_KATEGORI";
            colMAHSUP_ALT_KATEGORI.Name = "colMAHSUP_ALT_KATEGORI";
            colMAHSUP_ALT_KATEGORI.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			//colID,
			colFOY_NO,
			colICRA_ADLIYE,
			colICRA_BIRIM_NO,
			colESAS_NO,
			colTAKIP_TARIHI,
			colBOLGE,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
			colKREDI_TIP,
			colKREDI_GRUP,
			colFOY_OZEL_DURUM,
			colFOY_YERI,
			colTAHSILAT_DURUM,
			colFOY_BIRIM,
			colBANKA,
			colODEME_MIKTAR,
			colODEME_MIKTAR_DOVIZ_ID,
			colODEME_TARIHI,
			colODEME_YERI,
			colODEME_TIP,
			colBOLUM,
			colDAGILIM_TIPI,
			colTUTAR,
			colTUTAR_DOVIZ_ID,
			colICRA_FOY_ID,
			colMAHSUP_KATEGORI,
			colMAHSUP_ALT_KATEGORI,
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

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 1;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 2;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 3;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 4;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 5;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 6;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 7;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 8;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 9;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 10;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 11;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 12;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 13;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 15;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldODEME_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR.AreaIndex = 16;
            fieldODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            fieldODEME_MIKTAR.Name = "fieldODEME_MIKTAR";
            fieldODEME_MIKTAR.Visible = false;

            PivotGridField fieldODEME_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR_DOVIZ_ID.AreaIndex = 17;
            fieldODEME_MIKTAR_DOVIZ_ID.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Name = "fieldODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TARIHI.AreaIndex = 18;
            fieldODEME_TARIHI.FieldName = "ODEME_TARIHI";
            fieldODEME_TARIHI.Name = "fieldODEME_TARIHI";
            fieldODEME_TARIHI.Visible = false;

            PivotGridField fieldODEME_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_YERI.AreaIndex = 19;
            fieldODEME_YERI.FieldName = "ODEME_YERI";
            fieldODEME_YERI.Name = "fieldODEME_YERI";
            fieldODEME_YERI.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 20;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldDAGILIM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAGILIM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAGILIM_TIPI.AreaIndex = 22;
            fieldDAGILIM_TIPI.FieldName = "DAGILIM_TIPI";
            fieldDAGILIM_TIPI.Name = "fieldDAGILIM_TIPI";
            fieldDAGILIM_TIPI.Visible = false;

            PivotGridField fieldTUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR.AreaIndex = 23;
            fieldTUTAR.FieldName = "TUTAR";
            fieldTUTAR.Name = "fieldTUTAR";
            fieldTUTAR.Visible = false;

            PivotGridField fieldTUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_DOVIZ_ID.AreaIndex = 24;
            fieldTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            fieldTUTAR_DOVIZ_ID.Name = "fieldTUTAR_DOVIZ_ID";
            fieldTUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_FOY_ID.AreaIndex = 25;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.Visible = false;

            PivotGridField fieldMAHSUP_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHSUP_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHSUP_KATEGORI.AreaIndex = 26;
            fieldMAHSUP_KATEGORI.FieldName = "MAHSUP_KATEGORI";
            fieldMAHSUP_KATEGORI.Name = "fieldMAHSUP_KATEGORI";
            fieldMAHSUP_KATEGORI.Visible = false;

            PivotGridField fieldMAHSUP_ALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHSUP_ALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHSUP_ALT_KATEGORI.AreaIndex = 27;
            fieldMAHSUP_ALT_KATEGORI.FieldName = "MAHSUP_ALT_KATEGORI";
            fieldMAHSUP_ALT_KATEGORI.Name = "fieldMAHSUP_ALT_KATEGORI";
            fieldMAHSUP_ALT_KATEGORI.Visible = false;

            #endregion Field & Properties

            switch (pencere)
            {
                case "Tahsilatların Hukuk Bölümlerine Göre Dağılımı":
                    dizi = TahsilatlarinHukukBolumlerineGoreDagilimi();
                    break;

                case "Tahsilatların Yılın Çeyreklerine Göre Dağılımı":
                    dizi = TahsilatlarinYilinCeyreklerineGoreDagilimi();
                    break;

                case "Tahsilatların Ödeme Yerine Göre Dağılımı":
                    dizi = TahsilatlarinOdemeYerineGoreDagilimi();
                    break;

                case "Tahsilatların Ödeme Tipine Göre Dağılımı":
                    dizi = TahsilatlarinOdemeTipineGoreDagilimi();
                    break;

                case "Tahsilatların Mahsup Kalemine Göre Dağılımı":
                    dizi = TahsilatlarinMahsupKlaemineGoreDagilimi();
                    break;

                case "Tahsilatların Yıllara Göre Dağılımı":
                    dizi = TahsilatlarinYillaraGoreDagilimi();
                    break;

                case "Tahsilatların Aylara Göre Dağılımı":
                    dizi = TahsilatlarinAylaraGoreDagilimi();
                    break;

                case "Tahsilatların Bürolara Göre Dağılımı":
                case "Tahsilat Sayısı (Bürolara Göre)":

                    dizi = TahsilatlarinBurolaraGoreDagilimi();

                    break;

                case "Tahsilatarın Bölgelere Göre Dağılımı":
                    dizi = TahsilatlarinBolgelereGoreDagilimi();
                    break;

                case "Tahsilatarın Şubelere Göre Dağılımı":
                    dizi = TahsilatlarinSubelereGoreDagilimi();
                    break;

                case "Tahsilat Sayısı (Aylara, Yıllara Göre)":
                    dizi = TahsilatlarinAylaraYillaraGoreDagilimi();
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
			fieldFOY_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldESAS_NO,
			fieldTAKIP_TARIHI,
			fieldBOLGE,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldKREDI_TIP,
			fieldKREDI_GRUP,
			fieldFOY_OZEL_DURUM,
			fieldFOY_YERI,
			fieldTAHSILAT_DURUM,
			fieldFOY_BIRIM,
			fieldBANKA,
			fieldODEME_MIKTAR,
			fieldODEME_MIKTAR_DOVIZ_ID,
			fieldODEME_TARIHI,
			fieldODEME_YERI,
			fieldODEME_TIP,
			fieldBOLUM,
			fieldDAGILIM_TIPI,
			fieldTUTAR,
			fieldTUTAR_DOVIZ_ID,
			fieldICRA_FOY_ID,
			fieldMAHSUP_KATEGORI,
			fieldMAHSUP_ALT_KATEGORI,
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

            dicFieldCaption.Add("ID", "Kayıt Sayısı");
            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("ICRA_ADLIYE", "Adliye");
            dicFieldCaption.Add("ICRA_BIRIM_NO", "Birim No");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("TAKIP_TARIHI", "Takip T.");
            dicFieldCaption.Add("BOLGE", "Bölge");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KREDI_TIP", "Kredi Tip");
            dicFieldCaption.Add("KREDI_GRUP", "Kredi Grup");
            dicFieldCaption.Add("FOY_OZEL_DURUM", "Özel Durum");
            dicFieldCaption.Add("FOY_YERI", "Foy Yeri");
            dicFieldCaption.Add("TAHSILAT_DURUM", "Tahsilat Durum");
            dicFieldCaption.Add("FOY_BIRIM", "Dosya Birim");
            dicFieldCaption.Add("BANKA", "Banka");
            dicFieldCaption.Add("ODEME_MIKTAR", "Ödeme Miktar");
            dicFieldCaption.Add("ODEME_TARIHI", "Ödeme T.");
            dicFieldCaption.Add("ODEME_YERI", "Ödeme Yeri");
            dicFieldCaption.Add("ODEME_TIP", "Ödeme Tip");
            dicFieldCaption.Add("BOLUM", "Bölüm");
            dicFieldCaption.Add("DAGILIM_TIPI", "Dağılım Tip");
            dicFieldCaption.Add("TUTAR", "Tutar");
            dicFieldCaption.Add("ICRA_FOY_ID", "Dosya Sayısı");
            dicFieldCaption.Add("MAHSUP_KATEGORI", "Mahsup Kategori");
            dicFieldCaption.Add("MAHSUP_ALT_KATEGORI", "Mahsup Alt Kategori");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

            //Inits.DovizTipGetir(rlueDoviz);

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("DovizId", InitsEx.DovizTipGetir);

            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);

            //sozluk.Add("TAHSILAT_DURUM",Item);
            sozluk.Add("ODEME_MIKTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("ODEME_MIKTAR_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TUTAR_DOVIZ_ID", InitsEx.DovizTipGetir);

            #endregion Add item

            return sozluk;
        }

        private PivotGridField[] TahsilatlarinAylaraGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Caption = "Dosya Sayisi";
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldICRA_FOY_ID.AreaIndex = 1;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.SummaryType = PivotSummaryType.Count;
            fieldICRA_FOY_ID.Visible = true;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 2;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 3;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 4;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 5;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.AreaIndex = 6;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 7;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 8;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 9;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 10;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 11;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 12;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 13;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 14;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 15;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 16;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldODEME_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR.AreaIndex = 17;
            fieldODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            fieldODEME_MIKTAR.Name = "fieldODEME_MIKTAR";
            fieldODEME_MIKTAR.Visible = false;

            PivotGridField fieldODEME_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR_DOVIZ_ID.AreaIndex = 18;
            fieldODEME_MIKTAR_DOVIZ_ID.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Name = "fieldODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TARIHI.AreaIndex = 19;
            fieldODEME_TARIHI.FieldName = "ODEME_TARIHI";
            fieldODEME_TARIHI.Name = "fieldODEME_TARIHI";
            fieldODEME_TARIHI.Visible = false;

            PivotGridField fieldODEME_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_YERI.AreaIndex = 20;
            fieldODEME_YERI.FieldName = "ODEME_YERI";
            fieldODEME_YERI.Name = "fieldODEME_YERI";
            fieldODEME_YERI.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 21;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldICRA_FOY_ID,
			fieldFOY_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldESAS_NO,
			fieldTAKIP_TARIHI,
			fieldBOLGE,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldKREDI_TIP,
			fieldKREDI_GRUP,
			fieldFOY_OZEL_DURUM,
			fieldFOY_YERI,
			fieldTAHSILAT_DURUM,
			fieldFOY_BIRIM,
			fieldBANKA,
			fieldODEME_MIKTAR,
			fieldODEME_MIKTAR_DOVIZ_ID,
			fieldODEME_TARIHI,
			fieldODEME_YERI,
			fieldODEME_TIP,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] TahsilatlarinAylaraYillaraGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Caption = "Dosya Sayisi";
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldICRA_FOY_ID.AreaIndex = 1;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.SummaryType = PivotSummaryType.Count;
            fieldICRA_FOY_ID.Visible = true;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 2;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 3;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 4;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 5;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.AreaIndex = 6;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.AreaIndex = 6;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 7;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 8;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 9;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 10;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 11;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 12;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 13;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 14;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 15;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 16;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldODEME_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR.AreaIndex = 17;
            fieldODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            fieldODEME_MIKTAR.Name = "fieldODEME_MIKTAR";
            fieldODEME_MIKTAR.Visible = false;

            PivotGridField fieldODEME_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR_DOVIZ_ID.AreaIndex = 18;
            fieldODEME_MIKTAR_DOVIZ_ID.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Name = "fieldODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TARIHI.AreaIndex = 19;
            fieldODEME_TARIHI.FieldName = "ODEME_TARIHI";
            fieldODEME_TARIHI.Name = "fieldODEME_TARIHI";
            fieldODEME_TARIHI.Visible = false;

            PivotGridField fieldODEME_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_YERI.AreaIndex = 20;
            fieldODEME_YERI.FieldName = "ODEME_YERI";
            fieldODEME_YERI.Name = "fieldODEME_YERI";
            fieldODEME_YERI.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 21;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldICRA_FOY_ID,
			fieldFOY_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldESAS_NO,
            fieldTAKIP_TARIHI2,
			fieldTAKIP_TARIHI,
			fieldBOLGE,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldKREDI_TIP,
			fieldKREDI_GRUP,
			fieldFOY_OZEL_DURUM,
			fieldFOY_YERI,
			fieldTAHSILAT_DURUM,
			fieldFOY_BIRIM,
			fieldBANKA,
			fieldODEME_MIKTAR,
			fieldODEME_MIKTAR_DOVIZ_ID,
			fieldODEME_TARIHI,
			fieldODEME_YERI,
			fieldODEME_TIP,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] TahsilatlarinBolgelereGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldICRA_FOY_ID.AreaIndex = 1;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.SummaryType = PivotSummaryType.Count;
            fieldICRA_FOY_ID.Visible = true;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 2;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 3;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 4;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 5;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 6;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBOLGE.AreaIndex = 7;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = true;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 8;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 9;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 10;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 11;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 12;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 13;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 14;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 15;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 16;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldODEME_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR.AreaIndex = 17;
            fieldODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            fieldODEME_MIKTAR.Name = "fieldODEME_MIKTAR";
            fieldODEME_MIKTAR.Visible = false;

            PivotGridField fieldODEME_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR_DOVIZ_ID.AreaIndex = 18;
            fieldODEME_MIKTAR_DOVIZ_ID.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Name = "fieldODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TARIHI.AreaIndex = 19;
            fieldODEME_TARIHI.FieldName = "ODEME_TARIHI";
            fieldODEME_TARIHI.Name = "fieldODEME_TARIHI";
            fieldODEME_TARIHI.Visible = false;

            PivotGridField fieldODEME_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_YERI.AreaIndex = 20;
            fieldODEME_YERI.FieldName = "ODEME_YERI";
            fieldODEME_YERI.Name = "fieldODEME_YERI";
            fieldODEME_YERI.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 21;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldICRA_FOY_ID,
			fieldFOY_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldESAS_NO,
			fieldTAKIP_TARIHI,
			fieldBOLGE,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldKREDI_TIP,
			fieldKREDI_GRUP,
			fieldFOY_OZEL_DURUM,
			fieldFOY_YERI,
			fieldTAHSILAT_DURUM,
			fieldFOY_BIRIM,
			fieldBANKA,
			fieldODEME_MIKTAR,
			fieldODEME_MIKTAR_DOVIZ_ID,
			fieldODEME_TARIHI,
			fieldODEME_YERI,
			fieldODEME_TIP,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] TahsilatlarinBurolaraGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldICRA_FOY_ID.AreaIndex = 1;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.SummaryType = PivotSummaryType.Count;
            fieldICRA_FOY_ID.Visible = true;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 2;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 3;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 4;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 5;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 6;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 7;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 8;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSUBE_KOD_ID.AreaIndex = 9;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 10;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 11;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 12;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 13;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 14;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 15;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 16;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldODEME_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR.AreaIndex = 17;
            fieldODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            fieldODEME_MIKTAR.Name = "fieldODEME_MIKTAR";
            fieldODEME_MIKTAR.Visible = false;

            PivotGridField fieldODEME_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR_DOVIZ_ID.AreaIndex = 18;
            fieldODEME_MIKTAR_DOVIZ_ID.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Name = "fieldODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TARIHI.AreaIndex = 19;
            fieldODEME_TARIHI.FieldName = "ODEME_TARIHI";
            fieldODEME_TARIHI.Name = "fieldODEME_TARIHI";
            fieldODEME_TARIHI.Visible = false;

            PivotGridField fieldODEME_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_YERI.AreaIndex = 20;
            fieldODEME_YERI.FieldName = "ODEME_YERI";
            fieldODEME_YERI.Name = "fieldODEME_YERI";
            fieldODEME_YERI.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 21;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldICRA_FOY_ID,
			fieldFOY_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldESAS_NO,
			fieldTAKIP_TARIHI,
			fieldBOLGE,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldKREDI_TIP,
			fieldKREDI_GRUP,
			fieldFOY_OZEL_DURUM,
			fieldFOY_YERI,
			fieldTAHSILAT_DURUM,
			fieldFOY_BIRIM,
			fieldBANKA,
			fieldODEME_MIKTAR,
			fieldODEME_MIKTAR_DOVIZ_ID,
			fieldODEME_TARIHI,
			fieldODEME_YERI,
			fieldODEME_TIP,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] TahsilatlarinHukukBolumlerineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldICRA_FOY_ID.AreaIndex = 1;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.SummaryType = PivotSummaryType.Count;
            fieldICRA_FOY_ID.Visible = true;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 2;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 3;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 4;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 5;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 6;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 7;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 8;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 9;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 10;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 11;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 12;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 13;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 14;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 15;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 16;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldODEME_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR.AreaIndex = 17;
            fieldODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            fieldODEME_MIKTAR.Name = "fieldODEME_MIKTAR";
            fieldODEME_MIKTAR.Visible = false;

            PivotGridField fieldODEME_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR_DOVIZ_ID.AreaIndex = 18;
            fieldODEME_MIKTAR_DOVIZ_ID.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Name = "fieldODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TARIHI.AreaIndex = 19;
            fieldODEME_TARIHI.FieldName = "ODEME_TARIHI";
            fieldODEME_TARIHI.Name = "fieldODEME_TARIHI";
            fieldODEME_TARIHI.Visible = false;

            PivotGridField fieldODEME_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_YERI.AreaIndex = 20;
            fieldODEME_YERI.FieldName = "ODEME_YERI";
            fieldODEME_YERI.Name = "fieldODEME_YERI";
            fieldODEME_YERI.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 21;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = true;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldICRA_FOY_ID,
			fieldFOY_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldESAS_NO,
			fieldTAKIP_TARIHI,
			fieldBOLGE,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldKREDI_TIP,
			fieldKREDI_GRUP,
			fieldFOY_OZEL_DURUM,
			fieldFOY_YERI,
			fieldTAHSILAT_DURUM,
			fieldFOY_BIRIM,
			fieldBANKA,
			fieldODEME_MIKTAR,
			fieldODEME_MIKTAR_DOVIZ_ID,
			fieldODEME_TARIHI,
			fieldODEME_YERI,
			fieldODEME_TIP,
            fieldBOLUM,
			};

            return dizi;

            #endregion []
        }

        private PivotGridField[] TahsilatlarinMahsupKlaemineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldICRA_FOY_ID.AreaIndex = 1;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.SummaryType = PivotSummaryType.Count;
            fieldICRA_FOY_ID.Visible = true;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 2;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 3;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 4;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 5;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 6;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 7;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 8;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 9;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 10;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 11;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 12;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 13;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 14;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 15;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 16;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldODEME_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR.AreaIndex = 17;
            fieldODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            fieldODEME_MIKTAR.Name = "fieldODEME_MIKTAR";
            fieldODEME_MIKTAR.Visible = false;

            PivotGridField fieldODEME_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR_DOVIZ_ID.AreaIndex = 18;
            fieldODEME_MIKTAR_DOVIZ_ID.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Name = "fieldODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TARIHI.AreaIndex = 19;
            fieldODEME_TARIHI.FieldName = "ODEME_TARIHI";
            fieldODEME_TARIHI.Name = "fieldODEME_TARIHI";
            fieldODEME_TARIHI.Visible = false;

            PivotGridField fieldODEME_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_YERI.AreaIndex = 20;
            fieldODEME_YERI.FieldName = "ODEME_YERI";
            fieldODEME_YERI.Name = "fieldODEME_YERI";
            fieldODEME_YERI.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 21;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldMAHSUP_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHSUP_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldMAHSUP_KATEGORI.AreaIndex = 26;
            fieldMAHSUP_KATEGORI.FieldName = "MAHSUP_KATEGORI";
            fieldMAHSUP_KATEGORI.Name = "fieldMAHSUP_KATEGORI";
            fieldMAHSUP_KATEGORI.Visible = true;

            PivotGridField fieldMAHSUP_ALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHSUP_ALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldMAHSUP_ALT_KATEGORI.AreaIndex = 27;
            fieldMAHSUP_ALT_KATEGORI.FieldName = "MAHSUP_ALT_KATEGORI";
            fieldMAHSUP_ALT_KATEGORI.Name = "fieldMAHSUP_ALT_KATEGORI";
            fieldMAHSUP_ALT_KATEGORI.Visible = true;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldICRA_FOY_ID,
			fieldFOY_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldESAS_NO,
			fieldTAKIP_TARIHI,
			fieldBOLGE,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldKREDI_TIP,
			fieldKREDI_GRUP,
			fieldFOY_OZEL_DURUM,
			fieldFOY_YERI,
			fieldTAHSILAT_DURUM,
			fieldFOY_BIRIM,
			fieldBANKA,
			fieldODEME_MIKTAR,
			fieldODEME_MIKTAR_DOVIZ_ID,
			fieldODEME_TARIHI,
			fieldODEME_YERI,
			fieldODEME_TIP,
            fieldMAHSUP_KATEGORI,
            fieldMAHSUP_ALT_KATEGORI,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] TahsilatlarinOdemeTipineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Caption = "Dosya Sayisi";
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldICRA_FOY_ID.AreaIndex = 1;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.SummaryType = PivotSummaryType.Count;
            fieldICRA_FOY_ID.Visible = true;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 2;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 3;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 4;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 5;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 6;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 7;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 8;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 9;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 10;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 11;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 12;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 13;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 14;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 15;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 16;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldODEME_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR.AreaIndex = 17;
            fieldODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            fieldODEME_MIKTAR.Name = "fieldODEME_MIKTAR";
            fieldODEME_MIKTAR.Visible = false;

            PivotGridField fieldODEME_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR_DOVIZ_ID.AreaIndex = 18;
            fieldODEME_MIKTAR_DOVIZ_ID.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Name = "fieldODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TARIHI.AreaIndex = 19;
            fieldODEME_TARIHI.FieldName = "ODEME_TARIHI";
            fieldODEME_TARIHI.Name = "fieldODEME_TARIHI";
            fieldODEME_TARIHI.Visible = false;

            PivotGridField fieldODEME_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_YERI.AreaIndex = 20;
            fieldODEME_YERI.FieldName = "ODEME_YERI";
            fieldODEME_YERI.Name = "fieldODEME_YERI";
            fieldODEME_YERI.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldODEME_TIP.AreaIndex = 21;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = true;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldICRA_FOY_ID,
			fieldFOY_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldESAS_NO,
			fieldTAKIP_TARIHI,
			fieldBOLGE,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldKREDI_TIP,
			fieldKREDI_GRUP,
			fieldFOY_OZEL_DURUM,
			fieldFOY_YERI,
			fieldTAHSILAT_DURUM,
			fieldFOY_BIRIM,
			fieldBANKA,
			fieldODEME_MIKTAR,
			fieldODEME_MIKTAR_DOVIZ_ID,
			fieldODEME_TARIHI,
			fieldODEME_YERI,
			fieldODEME_TIP,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] TahsilatlarinOdemeYerineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;
            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldICRA_FOY_ID.AreaIndex = 1;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.SummaryType = PivotSummaryType.Count;
            fieldICRA_FOY_ID.Visible = true;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 2;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 3;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 4;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 5;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 6;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 7;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 8;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 9;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 10;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 11;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 12;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 13;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 14;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 15;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 16;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldODEME_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR.AreaIndex = 17;
            fieldODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            fieldODEME_MIKTAR.Name = "fieldODEME_MIKTAR";
            fieldODEME_MIKTAR.Visible = false;

            PivotGridField fieldODEME_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR_DOVIZ_ID.AreaIndex = 18;
            fieldODEME_MIKTAR_DOVIZ_ID.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Name = "fieldODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TARIHI.AreaIndex = 19;
            fieldODEME_TARIHI.FieldName = "ODEME_TARIHI";
            fieldODEME_TARIHI.Name = "fieldODEME_TARIHI";
            fieldODEME_TARIHI.Visible = false;

            PivotGridField fieldODEME_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldODEME_YERI.AreaIndex = 20;
            fieldODEME_YERI.FieldName = "ODEME_YERI";
            fieldODEME_YERI.Name = "fieldODEME_YERI";
            fieldODEME_YERI.Visible = true;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 21;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldICRA_FOY_ID,
			fieldFOY_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldESAS_NO,
			fieldTAKIP_TARIHI,
			fieldBOLGE,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldKREDI_TIP,
			fieldKREDI_GRUP,
			fieldFOY_OZEL_DURUM,
			fieldFOY_YERI,
			fieldTAHSILAT_DURUM,
			fieldFOY_BIRIM,
			fieldBANKA,
			fieldODEME_MIKTAR,
			fieldODEME_MIKTAR_DOVIZ_ID,
			fieldODEME_TARIHI,
			fieldODEME_YERI,
			fieldODEME_TIP,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] TahsilatlarinSubelereGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Caption = "Dosya Sayisi";
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldICRA_FOY_ID.AreaIndex = 1;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.SummaryType = PivotSummaryType.Count;
            fieldICRA_FOY_ID.Visible = true;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 2;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 3;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 4;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 5;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 6;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 7;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 8;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSUBE_KOD_ID.AreaIndex = 9;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 10;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 11;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 12;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 13;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 14;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 15;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 16;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldODEME_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR.AreaIndex = 17;
            fieldODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            fieldODEME_MIKTAR.Name = "fieldODEME_MIKTAR";
            fieldODEME_MIKTAR.Visible = false;

            PivotGridField fieldODEME_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR_DOVIZ_ID.AreaIndex = 18;
            fieldODEME_MIKTAR_DOVIZ_ID.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Name = "fieldODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TARIHI.AreaIndex = 19;
            fieldODEME_TARIHI.FieldName = "ODEME_TARIHI";
            fieldODEME_TARIHI.Name = "fieldODEME_TARIHI";
            fieldODEME_TARIHI.Visible = false;

            PivotGridField fieldODEME_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_YERI.AreaIndex = 20;
            fieldODEME_YERI.FieldName = "ODEME_YERI";
            fieldODEME_YERI.Name = "fieldODEME_YERI";
            fieldODEME_YERI.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 21;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldICRA_FOY_ID,
			fieldFOY_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldESAS_NO,
			fieldTAKIP_TARIHI,
			fieldBOLGE,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldKREDI_TIP,
			fieldKREDI_GRUP,
			fieldFOY_OZEL_DURUM,
			fieldFOY_YERI,
			fieldTAHSILAT_DURUM,
			fieldFOY_BIRIM,
			fieldBANKA,
			fieldODEME_MIKTAR,
			fieldODEME_MIKTAR_DOVIZ_ID,
			fieldODEME_TARIHI,
			fieldODEME_YERI,
			fieldODEME_TIP,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] TahsilatlarinYilinCeyreklerineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldICRA_FOY_ID.AreaIndex = 1;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.SummaryType = PivotSummaryType.Count;
            fieldICRA_FOY_ID.Visible = true;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 2;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 3;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 4;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 5;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_TARIHI.AreaIndex = 6;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateQuarter;
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 7;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 8;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 9;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 10;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 11;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 12;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 13;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 14;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 15;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 16;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldODEME_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR.AreaIndex = 17;
            fieldODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            fieldODEME_MIKTAR.Name = "fieldODEME_MIKTAR";
            fieldODEME_MIKTAR.Visible = false;

            PivotGridField fieldODEME_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR_DOVIZ_ID.AreaIndex = 18;
            fieldODEME_MIKTAR_DOVIZ_ID.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Name = "fieldODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TARIHI.AreaIndex = 19;
            fieldODEME_TARIHI.FieldName = "ODEME_TARIHI";
            fieldODEME_TARIHI.Name = "fieldODEME_TARIHI";
            fieldODEME_TARIHI.Visible = false;

            PivotGridField fieldODEME_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_YERI.AreaIndex = 20;
            fieldODEME_YERI.FieldName = "ODEME_YERI";
            fieldODEME_YERI.Name = "fieldODEME_YERI";
            fieldODEME_YERI.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 21;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldICRA_FOY_ID,
			fieldFOY_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldESAS_NO,
			fieldTAKIP_TARIHI,
			fieldBOLGE,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldKREDI_TIP,
			fieldKREDI_GRUP,
			fieldFOY_OZEL_DURUM,
			fieldFOY_YERI,
			fieldTAHSILAT_DURUM,
			fieldFOY_BIRIM,
			fieldBANKA,
			fieldODEME_MIKTAR,
			fieldODEME_MIKTAR_DOVIZ_ID,
			fieldODEME_TARIHI,
			fieldODEME_YERI,
			fieldODEME_TIP,
			};

            return dizi;

            #endregion []
        }

        private PivotGridField[] TahsilatlarinYillaraGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldICRA_FOY_ID.AreaIndex = 1;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.SummaryType = PivotSummaryType.Count;
            fieldICRA_FOY_ID.Visible = true;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 2;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 3;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 4;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 5;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI.AreaIndex = 6;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 7;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 8;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 9;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 10;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 11;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 12;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 13;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 14;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 15;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 16;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldODEME_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR.AreaIndex = 17;
            fieldODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            fieldODEME_MIKTAR.Name = "fieldODEME_MIKTAR";
            fieldODEME_MIKTAR.Visible = false;

            PivotGridField fieldODEME_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MIKTAR_DOVIZ_ID.AreaIndex = 18;
            fieldODEME_MIKTAR_DOVIZ_ID.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Name = "fieldODEME_MIKTAR_DOVIZ_ID";
            fieldODEME_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TARIHI.AreaIndex = 19;
            fieldODEME_TARIHI.FieldName = "ODEME_TARIHI";
            fieldODEME_TARIHI.Name = "fieldODEME_TARIHI";
            fieldODEME_TARIHI.Visible = false;

            PivotGridField fieldODEME_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_YERI.AreaIndex = 20;
            fieldODEME_YERI.FieldName = "ODEME_YERI";
            fieldODEME_YERI.Name = "fieldODEME_YERI";
            fieldODEME_YERI.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 21;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldICRA_FOY_ID,
			fieldFOY_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldESAS_NO,
			fieldTAKIP_TARIHI,
			fieldBOLGE,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldKREDI_TIP,
			fieldKREDI_GRUP,
			fieldFOY_OZEL_DURUM,
			fieldFOY_YERI,
			fieldTAHSILAT_DURUM,
			fieldFOY_BIRIM,
			fieldBANKA,
			fieldODEME_MIKTAR,
			fieldODEME_MIKTAR_DOVIZ_ID,
			fieldODEME_TARIHI,
			fieldODEME_YERI,
			fieldODEME_TIP,
			};

            #endregion []

            return dizi;
        }
    }
}