using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class rSerbestMeslekMakbuzsuzHazirlikDosyalari
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

            GridColumn colDosya_No = new GridColumn();
            colDosya_No.VisibleIndex = 0;
            colDosya_No.FieldName = "Dosya_No";
            colDosya_No.Name = "colDosya_No";
            colDosya_No.Visible = true;

            GridColumn colAdliye = new GridColumn();
            colAdliye.VisibleIndex = 1;
            colAdliye.FieldName = "Adliye";
            colAdliye.Name = "colAdliye";
            colAdliye.Visible = true;

            GridColumn colGorev = new GridColumn();
            colGorev.VisibleIndex = 2;
            colGorev.FieldName = "Gorev";
            colGorev.Name = "colGorev";
            colGorev.Visible = true;

            GridColumn colNo = new GridColumn();
            colNo.VisibleIndex = 3;
            colNo.FieldName = "No";
            colNo.Name = "colNo";
            colNo.Visible = true;

            GridColumn colEsas_No = new GridColumn();
            colEsas_No.VisibleIndex = 4;
            colEsas_No.FieldName = "Esas_No";
            colEsas_No.Name = "colEsas_No";
            colEsas_No.Visible = true;

            GridColumn colTakip_T = new GridColumn();
            colTakip_T.VisibleIndex = 5;
            colTakip_T.FieldName = "Takip_T";
            colTakip_T.Name = "colTakip_T";
            colTakip_T.Visible = true;

            GridColumn colReferans1 = new GridColumn();
            colReferans1.VisibleIndex = 6;
            colReferans1.FieldName = "Referans1";
            colReferans1.Name = "colReferans1";
            colReferans1.Visible = true;

            GridColumn colReferans2 = new GridColumn();
            colReferans2.VisibleIndex = 7;
            colReferans2.FieldName = "Referans2";
            colReferans2.Name = "colReferans2";
            colReferans2.Visible = true;

            GridColumn colReferans3 = new GridColumn();
            colReferans3.VisibleIndex = 8;
            colReferans3.FieldName = "Referans3";
            colReferans3.Name = "colReferans3";
            colReferans3.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 9;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = false;

            GridColumn colTakip_Konusu = new GridColumn();
            colTakip_Konusu.VisibleIndex = 10;
            colTakip_Konusu.FieldName = "Takip_Konusu";
            colTakip_Konusu.Name = "colTakip_Konusu";
            colTakip_Konusu.Visible = true;

            GridColumn colDurum = new GridColumn();
            colDurum.VisibleIndex = 11;
            colDurum.FieldName = "Durum";
            colDurum.Name = "colDurum";
            colDurum.Visible = true;

            GridColumn colK = new GridColumn();
            colK.VisibleIndex = 12;
            colK.FieldName = "K";
            colK.Name = "colK";
            colK.Visible = true;

            GridColumn colTaraf_Adi = new GridColumn();
            colTaraf_Adi.VisibleIndex = 13;
            colTaraf_Adi.FieldName = "Taraf_Adi";
            colTaraf_Adi.Name = "colTaraf_Adi";
            colTaraf_Adi.Visible = true;

            GridColumn colSIFAT = new GridColumn();
            colSIFAT.VisibleIndex = 14;
            colSIFAT.FieldName = "SIFAT";
            colSIFAT.Name = "colSIFAT";
            colSIFAT.Visible = true;

            GridColumn colSorumlu_Adi = new GridColumn();
            colSorumlu_Adi.VisibleIndex = 15;
            colSorumlu_Adi.FieldName = "Sorumlu_Adi";
            colSorumlu_Adi.Name = "colSorumlu_Adi";
            colSorumlu_Adi.Visible = true;

            GridColumn colTipi = new GridColumn();
            colTipi.VisibleIndex = 16;
            colTipi.FieldName = "Tipi";
            colTipi.Name = "colTipi";
            colTipi.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 17;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colOzel_Kod1 = new GridColumn();
            colOzel_Kod1.VisibleIndex = 18;
            colOzel_Kod1.FieldName = "Ozel_Kod1";
            colOzel_Kod1.Name = "colOzel_Kod1";
            colOzel_Kod1.Visible = true;

            GridColumn colOzel_Kod2 = new GridColumn();
            colOzel_Kod2.VisibleIndex = 19;
            colOzel_Kod2.FieldName = "Ozel_Kod2";
            colOzel_Kod2.Name = "colOzel_Kod2";
            colOzel_Kod2.Visible = true;

            GridColumn colOzel_Kod3 = new GridColumn();
            colOzel_Kod3.VisibleIndex = 20;
            colOzel_Kod3.FieldName = "Ozel_Kod3";
            colOzel_Kod3.Name = "colOzel_Kod3";
            colOzel_Kod3.Visible = true;

            GridColumn colOzel_Kod4 = new GridColumn();
            colOzel_Kod4.VisibleIndex = 21;
            colOzel_Kod4.FieldName = "Ozel_Kod4";
            colOzel_Kod4.Name = "colOzel_Kod4";
            colOzel_Kod4.Visible = true;

            GridColumn colBANKA_ID = new GridColumn();
            colBANKA_ID.VisibleIndex = 22;
            colBANKA_ID.FieldName = "BANKA_ID";
            colBANKA_ID.Name = "colBANKA_ID";
            colBANKA_ID.Visible = true;

            GridColumn colSUBE_ID = new GridColumn();
            colSUBE_ID.VisibleIndex = 23;
            colSUBE_ID.FieldName = "SUBE_ID";
            colSUBE_ID.Name = "colSUBE_ID";
            colSUBE_ID.Visible = true;

            GridColumn colFOY_BIRIM_ID = new GridColumn();
            colFOY_BIRIM_ID.VisibleIndex = 24;
            colFOY_BIRIM_ID.FieldName = "FOY_BIRIM_ID";
            colFOY_BIRIM_ID.Name = "colFOY_BIRIM_ID";
            colFOY_BIRIM_ID.Visible = true;

            GridColumn colFOY_YERI_ID = new GridColumn();
            colFOY_YERI_ID.VisibleIndex = 25;
            colFOY_YERI_ID.FieldName = "FOY_YERI_ID";
            colFOY_YERI_ID.Name = "colFOY_YERI_ID";
            colFOY_YERI_ID.Visible = true;

            GridColumn colFOY_OZEL_DURUM_ID = new GridColumn();
            colFOY_OZEL_DURUM_ID.VisibleIndex = 26;
            colFOY_OZEL_DURUM_ID.FieldName = "FOY_OZEL_DURUM_ID";
            colFOY_OZEL_DURUM_ID.Name = "colFOY_OZEL_DURUM_ID";
            colFOY_OZEL_DURUM_ID.Visible = true;

            GridColumn colTAHSILAT_DURUM_ID = new GridColumn();
            colTAHSILAT_DURUM_ID.VisibleIndex = 27;
            colTAHSILAT_DURUM_ID.FieldName = "TAHSILAT_DURUM_ID";
            colTAHSILAT_DURUM_ID.Name = "colTAHSILAT_DURUM_ID";
            colTAHSILAT_DURUM_ID.Visible = true;

            GridColumn colKREDI_GRUP_ID = new GridColumn();
            colKREDI_GRUP_ID.VisibleIndex = 28;
            colKREDI_GRUP_ID.FieldName = "KREDI_GRUP_ID";
            colKREDI_GRUP_ID.Name = "colKREDI_GRUP_ID";
            colKREDI_GRUP_ID.Visible = true;

            GridColumn colKREDI_TIP_ID = new GridColumn();
            colKREDI_TIP_ID.VisibleIndex = 29;
            colKREDI_TIP_ID.FieldName = "KREDI_TIP_ID";
            colKREDI_TIP_ID.Name = "colKREDI_TIP_ID";
            colKREDI_TIP_ID.Visible = true;

            GridColumn colKLASOR_1 = new GridColumn();
            colKLASOR_1.VisibleIndex = 30;
            colKLASOR_1.FieldName = "KLASOR_1";
            colKLASOR_1.Name = "colKLASOR_1";
            colKLASOR_1.Visible = true;

            GridColumn colKLASOR_2 = new GridColumn();
            colKLASOR_2.VisibleIndex = 31;
            colKLASOR_2.FieldName = "KLASOR_2";
            colKLASOR_2.Name = "colKLASOR_2";
            colKLASOR_2.Visible = true;

            GridColumn colSUBE_KODU = new GridColumn();
            colSUBE_KODU.VisibleIndex = 32;
            colSUBE_KODU.FieldName = "SUBE_KODU";
            colSUBE_KODU.Name = "colSUBE_KODU";
            colSUBE_KODU.Visible = true;

            GridColumn colKAYIT_TARIHI = new GridColumn();
            colKAYIT_TARIHI.VisibleIndex = 33;
            colKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
            colKAYIT_TARIHI.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 34;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 35;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colPROJE_ID = new GridColumn();
            colPROJE_ID.VisibleIndex = 36;
            colPROJE_ID.FieldName = "PROJE_ID";
            colPROJE_ID.Name = "colPROJE_ID";
            colPROJE_ID.Visible = true;

            GridColumn colPROJE_ADI = new GridColumn();
            colPROJE_ADI.VisibleIndex = 37;
            colPROJE_ADI.FieldName = "PROJE_ADI";
            colPROJE_ADI.Name = "colPROJE_ADI";
            colPROJE_ADI.Visible = true;

            GridColumn colPROJE_KOD = new GridColumn();
            colPROJE_KOD.VisibleIndex = 38;
            colPROJE_KOD.FieldName = "PROJE_KOD";
            colPROJE_KOD.Name = "colPROJE_KOD";
            colPROJE_KOD.Visible = true;

            GridColumn colSEGMENT = new GridColumn();
            colSEGMENT.VisibleIndex = 39;
            colSEGMENT.FieldName = "SEGMENT";
            colSEGMENT.Name = "colSEGMENT";
            colSEGMENT.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colDosya_No,
			colAdliye,
			colGorev,
			colNo,
			colEsas_No,
			colTakip_T,
			colReferans1,
			colReferans2,
			colReferans3,
			colACIKLAMA,
			colTakip_Konusu,
			colDurum,
			colK,
			colTaraf_Adi,
			colSIFAT,
			colSorumlu_Adi,
			colTipi,
			colID,
			colOzel_Kod1,
			colOzel_Kod2,
			colOzel_Kod3,
			colOzel_Kod4,

            //colBANKA_ID,
            //colSUBE_ID,
            //colFOY_BIRIM_ID,
            //colFOY_YERI_ID,
            //colFOY_OZEL_DURUM_ID,
            //colTAHSILAT_DURUM_ID,
            //colKREDI_GRUP_ID,
            //colKREDI_TIP_ID,
            //colKLASOR_1,
            //colKLASOR_2,
            //colSUBE_KODU,
            //colKAYIT_TARIHI,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,

			//colPROJE_ID,
			colPROJE_ADI,
			colPROJE_KOD,
			colSEGMENT,
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

        public PivotGridField[] GetPivotFields()
        {
            #region Field & Properties

            PivotGridField fieldDosya_No = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDosya_No.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDosya_No.AreaIndex = 0;
            fieldDosya_No.FieldName = "Dosya_No";
            fieldDosya_No.Name = "fieldDosya_No";
            fieldDosya_No.Visible = false;

            PivotGridField fieldAdliye = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAdliye.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAdliye.AreaIndex = 1;
            fieldAdliye.FieldName = "Adliye";
            fieldAdliye.Name = "fieldAdliye";
            fieldAdliye.Visible = false;

            PivotGridField fieldGorev = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGorev.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGorev.AreaIndex = 2;
            fieldGorev.FieldName = "Gorev";
            fieldGorev.Name = "fieldGorev";
            fieldGorev.Visible = false;

            PivotGridField fieldNo = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNo.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNo.AreaIndex = 3;
            fieldNo.FieldName = "No";
            fieldNo.Name = "fieldNo";
            fieldNo.Visible = false;

            PivotGridField fieldEsas_No = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldEsas_No.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldEsas_No.AreaIndex = 4;
            fieldEsas_No.FieldName = "Esas_No";
            fieldEsas_No.Name = "fieldEsas_No";
            fieldEsas_No.Visible = false;

            PivotGridField fieldTakip_T = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTakip_T.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTakip_T.AreaIndex = 5;
            fieldTakip_T.FieldName = "Takip_T";
            fieldTakip_T.Name = "fieldTakip_T";
            fieldTakip_T.Visible = false;

            PivotGridField fieldReferans1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldReferans1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldReferans1.AreaIndex = 6;
            fieldReferans1.FieldName = "Referans1";
            fieldReferans1.Name = "fieldReferans1";
            fieldReferans1.Visible = false;

            PivotGridField fieldReferans2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldReferans2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldReferans2.AreaIndex = 7;
            fieldReferans2.FieldName = "Referans2";
            fieldReferans2.Name = "fieldReferans2";
            fieldReferans2.Visible = false;

            PivotGridField fieldReferans3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldReferans3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldReferans3.AreaIndex = 8;
            fieldReferans3.FieldName = "Referans3";
            fieldReferans3.Name = "fieldReferans3";
            fieldReferans3.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 9;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldTakip_Konusu = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTakip_Konusu.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTakip_Konusu.AreaIndex = 10;
            fieldTakip_Konusu.FieldName = "Takip_Konusu";
            fieldTakip_Konusu.Name = "fieldTakip_Konusu";
            fieldTakip_Konusu.Visible = false;

            PivotGridField fieldDurum = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDurum.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDurum.AreaIndex = 11;
            fieldDurum.FieldName = "Durum";
            fieldDurum.Name = "fieldDurum";
            fieldDurum.Visible = false;

            PivotGridField fieldK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldK.AreaIndex = 12;
            fieldK.FieldName = "K";
            fieldK.Name = "fieldK";
            fieldK.Visible = false;

            PivotGridField fieldTaraf_Adi = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTaraf_Adi.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTaraf_Adi.AreaIndex = 13;
            fieldTaraf_Adi.FieldName = "Taraf_Adi";
            fieldTaraf_Adi.Name = "fieldTaraf_Adi";
            fieldTaraf_Adi.Visible = false;

            PivotGridField fieldSIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSIFAT.AreaIndex = 14;
            fieldSIFAT.FieldName = "SIFAT";
            fieldSIFAT.Name = "fieldSIFAT";
            fieldSIFAT.Visible = false;

            PivotGridField fieldSorumlu_Adi = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSorumlu_Adi.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSorumlu_Adi.AreaIndex = 15;
            fieldSorumlu_Adi.FieldName = "Sorumlu_Adi";
            fieldSorumlu_Adi.Name = "fieldSorumlu_Adi";
            fieldSorumlu_Adi.Visible = false;

            PivotGridField fieldTipi = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTipi.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTipi.AreaIndex = 16;
            fieldTipi.FieldName = "Tipi";
            fieldTipi.Name = "fieldTipi";
            fieldTipi.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 17;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldOzel_Kod1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzel_Kod1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzel_Kod1.AreaIndex = 18;
            fieldOzel_Kod1.FieldName = "Ozel_Kod1";
            fieldOzel_Kod1.Name = "fieldOzel_Kod1";
            fieldOzel_Kod1.Visible = false;

            PivotGridField fieldOzel_Kod2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzel_Kod2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzel_Kod2.AreaIndex = 19;
            fieldOzel_Kod2.FieldName = "Ozel_Kod2";
            fieldOzel_Kod2.Name = "fieldOzel_Kod2";
            fieldOzel_Kod2.Visible = false;

            PivotGridField fieldOzel_Kod3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzel_Kod3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzel_Kod3.AreaIndex = 20;
            fieldOzel_Kod3.FieldName = "Ozel_Kod3";
            fieldOzel_Kod3.Name = "fieldOzel_Kod3";
            fieldOzel_Kod3.Visible = false;

            PivotGridField fieldOzel_Kod4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzel_Kod4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzel_Kod4.AreaIndex = 21;
            fieldOzel_Kod4.FieldName = "Ozel_Kod4";
            fieldOzel_Kod4.Name = "fieldOzel_Kod4";
            fieldOzel_Kod4.Visible = false;

            PivotGridField fieldBANKA_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_ID.AreaIndex = 22;
            fieldBANKA_ID.FieldName = "BANKA_ID";
            fieldBANKA_ID.Name = "fieldBANKA_ID";
            fieldBANKA_ID.Visible = false;

            PivotGridField fieldSUBE_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_ID.AreaIndex = 23;
            fieldSUBE_ID.FieldName = "SUBE_ID";
            fieldSUBE_ID.Name = "fieldSUBE_ID";
            fieldSUBE_ID.Visible = false;

            PivotGridField fieldFOY_BIRIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM_ID.AreaIndex = 24;
            fieldFOY_BIRIM_ID.FieldName = "FOY_BIRIM_ID";
            fieldFOY_BIRIM_ID.Name = "fieldFOY_BIRIM_ID";
            fieldFOY_BIRIM_ID.Visible = false;

            PivotGridField fieldFOY_YERI_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI_ID.AreaIndex = 25;
            fieldFOY_YERI_ID.FieldName = "FOY_YERI_ID";
            fieldFOY_YERI_ID.Name = "fieldFOY_YERI_ID";
            fieldFOY_YERI_ID.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM_ID.AreaIndex = 26;
            fieldFOY_OZEL_DURUM_ID.FieldName = "FOY_OZEL_DURUM_ID";
            fieldFOY_OZEL_DURUM_ID.Name = "fieldFOY_OZEL_DURUM_ID";
            fieldFOY_OZEL_DURUM_ID.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM_ID.AreaIndex = 27;
            fieldTAHSILAT_DURUM_ID.FieldName = "TAHSILAT_DURUM_ID";
            fieldTAHSILAT_DURUM_ID.Name = "fieldTAHSILAT_DURUM_ID";
            fieldTAHSILAT_DURUM_ID.Visible = false;

            PivotGridField fieldKREDI_GRUP_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP_ID.AreaIndex = 28;
            fieldKREDI_GRUP_ID.FieldName = "KREDI_GRUP_ID";
            fieldKREDI_GRUP_ID.Name = "fieldKREDI_GRUP_ID";
            fieldKREDI_GRUP_ID.Visible = false;

            PivotGridField fieldKREDI_TIP_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP_ID.AreaIndex = 29;
            fieldKREDI_TIP_ID.FieldName = "KREDI_TIP_ID";
            fieldKREDI_TIP_ID.Name = "fieldKREDI_TIP_ID";
            fieldKREDI_TIP_ID.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 30;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 31;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldSUBE_KODU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KODU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KODU.AreaIndex = 32;
            fieldSUBE_KODU.FieldName = "SUBE_KODU";
            fieldSUBE_KODU.Name = "fieldSUBE_KODU";
            fieldSUBE_KODU.Visible = false;

            PivotGridField fieldKAYIT_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAYIT_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAYIT_TARIHI.AreaIndex = 33;
            fieldKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            fieldKAYIT_TARIHI.Name = "fieldKAYIT_TARIHI";
            fieldKAYIT_TARIHI.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 34;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 35;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldPROJE_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_ID.AreaIndex = 36;
            fieldPROJE_ID.FieldName = "PROJE_ID";
            fieldPROJE_ID.Name = "fieldPROJE_ID";
            fieldPROJE_ID.Visible = false;

            PivotGridField fieldPROJE_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_ADI.AreaIndex = 37;
            fieldPROJE_ADI.FieldName = "PROJE_ADI";
            fieldPROJE_ADI.Name = "fieldPROJE_ADI";
            fieldPROJE_ADI.Visible = false;

            PivotGridField fieldPROJE_KOD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_KOD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_KOD.AreaIndex = 38;
            fieldPROJE_KOD.FieldName = "PROJE_KOD";
            fieldPROJE_KOD.Name = "fieldPROJE_KOD";
            fieldPROJE_KOD.Visible = false;

            PivotGridField fieldSEGMENT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSEGMENT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSEGMENT.AreaIndex = 39;
            fieldSEGMENT.FieldName = "SEGMENT";
            fieldSEGMENT.Name = "fieldSEGMENT";
            fieldSEGMENT.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldDosya_No,
			fieldAdliye,
			fieldGorev,
			fieldNo,
			fieldEsas_No,
			fieldTakip_T,
			fieldReferans1,
			fieldReferans2,
			fieldReferans3,
			fieldACIKLAMA,
			fieldTakip_Konusu,
			fieldDurum,
			fieldK,
			fieldTaraf_Adi,
			fieldSIFAT,
			fieldSorumlu_Adi,
			fieldTipi,
			fieldID,
			fieldOzel_Kod1,
			fieldOzel_Kod2,
			fieldOzel_Kod3,
			fieldOzel_Kod4,

            //fieldBANKA_ID,
            //fieldSUBE_ID,
            //fieldFOY_BIRIM_ID,
            //fieldFOY_YERI_ID,
            //fieldFOY_OZEL_DURUM_ID,
            //fieldTAHSILAT_DURUM_ID,
            //fieldKREDI_GRUP_ID,
            //fieldKREDI_TIP_ID,
            //fieldKLASOR_1,
            //fieldKLASOR_2,
            //fieldSUBE_KODU,
            //fieldKAYIT_TARIHI,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,

			//fieldPROJE_ID,
			fieldPROJE_ADI,
			fieldPROJE_KOD,
			fieldSEGMENT,
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
                    dizi[i].Caption = "Brm";

                if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
                {
                    dizi[i].FieldEdit = editler["DovizId"];
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

            dicFieldCaption.Add("Dosya_No", "Dosya No");
            dicFieldCaption.Add("Adliye", "Adliye");
            dicFieldCaption.Add("Gorev", "Görev");
            dicFieldCaption.Add("No", "No");
            dicFieldCaption.Add("Esas_No", "Esas No");
            dicFieldCaption.Add("Takip_T", "Takip T");
            dicFieldCaption.Add("Referans1", "Ref 1");
            dicFieldCaption.Add("Referans2", "Ref 2");
            dicFieldCaption.Add("Referans3", "Ref 3");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("Takip_Konusu", "Takip Konusu");
            dicFieldCaption.Add("Durum", "Durum");
            dicFieldCaption.Add("K", "Taraf Kodu");
            dicFieldCaption.Add("Taraf_Adi", "Taraf Adı");
            dicFieldCaption.Add("SIFAT", "Sıfat");
            dicFieldCaption.Add("Sorumlu_Adi", "Sorumlu");
            dicFieldCaption.Add("Tipi", "Tipi");
            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("Ozel_Kod1", "Özel Kod 1");
            dicFieldCaption.Add("Ozel_Kod2", "Özel Kod 2");
            dicFieldCaption.Add("Ozel_Kod3", "Özel Kod 3");
            dicFieldCaption.Add("Ozel_Kod4", "Özel Kod 4");
            dicFieldCaption.Add("BANKA_ID", "");
            dicFieldCaption.Add("SUBE_ID", "");
            dicFieldCaption.Add("FOY_BIRIM_ID", "");
            dicFieldCaption.Add("FOY_YERI_ID", "");
            dicFieldCaption.Add("FOY_OZEL_DURUM_ID", "");
            dicFieldCaption.Add("TAHSILAT_DURUM_ID", "");
            dicFieldCaption.Add("KREDI_GRUP_ID", "");
            dicFieldCaption.Add("KREDI_TIP_ID", "");
            dicFieldCaption.Add("KLASOR_1", "");
            dicFieldCaption.Add("KLASOR_2", "");
            dicFieldCaption.Add("SUBE_KODU", "");
            dicFieldCaption.Add("KAYIT_TARIHI", "");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("PROJE_ID", "");
            dicFieldCaption.Add("PROJE_ADI", "Klasör Adı");
            dicFieldCaption.Add("PROJE_KOD", "Klasör  Kodu");
            dicFieldCaption.Add("SEGMENT", "Bölüm");

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

            //sozluk.Add("BANKA_ID", Item);
            //sozluk.Add("SUBE_ID", Item);
            //sozluk.Add("FOY_BIRIM_ID", Item);
            //sozluk.Add("FOY_YERI_ID", Item);
            //sozluk.Add("FOY_OZEL_DURUM_ID", Item);
            //sozluk.Add("TAHSILAT_DURUM_ID", Item);
            //sozluk.Add("KREDI_GRUP_ID", Item);
            //sozluk.Add("KREDI_TIP_ID", Item);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);

            // sozluk.Add("PROJE_ID", Item);
            // sozluk.Add("TAHSILAT_DURUM_ID", InitsEx.);

            #endregion Add item

            return sozluk;
        }
    }
}