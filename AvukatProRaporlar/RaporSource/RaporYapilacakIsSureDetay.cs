using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class RaporYapilacakIsSureDetay
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

            GridColumn colBASLANGIC_ZAMANI = new GridColumn();
            colBASLANGIC_ZAMANI.VisibleIndex = 0;
            colBASLANGIC_ZAMANI.FieldName = "BASLANGIC_ZAMANI";
            colBASLANGIC_ZAMANI.Name = "colBASLANGIC_ZAMANI";
            colBASLANGIC_ZAMANI.Visible = true;

            GridColumn colALT_KATEGORI = new GridColumn();
            colALT_KATEGORI.VisibleIndex = 1;
            colALT_KATEGORI.FieldName = "ALT_KATEGORI";
            colALT_KATEGORI.Name = "colALT_KATEGORI";
            colALT_KATEGORI.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 2;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 3;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 4;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colAD = new GridColumn();
            colAD.VisibleIndex = 5;
            colAD.FieldName = "AD";
            colAD.Name = "colAD";
            colAD.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 6;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colKAPAMA_TARIHI = new GridColumn();
            colKAPAMA_TARIHI.VisibleIndex = 7;
            colKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            colKAPAMA_TARIHI.Name = "colKAPAMA_TARIHI";
            colKAPAMA_TARIHI.Visible = true;

            GridColumn colPLANLAMA_TARIHI = new GridColumn();
            colPLANLAMA_TARIHI.VisibleIndex = 8;
            colPLANLAMA_TARIHI.FieldName = "PLANLAMA_TARIHI";
            colPLANLAMA_TARIHI.Name = "colPLANLAMA_TARIHI";
            colPLANLAMA_TARIHI.Visible = true;

            GridColumn colONGORULEN_BITIS_TARIHI = new GridColumn();
            colONGORULEN_BITIS_TARIHI.VisibleIndex = 9;
            colONGORULEN_BITIS_TARIHI.FieldName = "ONGORULEN_BITIS_TARIHI";
            colONGORULEN_BITIS_TARIHI.Name = "colONGORULEN_BITIS_TARIHI";
            colONGORULEN_BITIS_TARIHI.Visible = true;

            GridColumn colONGORULEN_BITIS_ZAMANI = new GridColumn();
            colONGORULEN_BITIS_ZAMANI.VisibleIndex = 10;
            colONGORULEN_BITIS_ZAMANI.FieldName = "ONGORULEN_BITIS_ZAMANI";
            colONGORULEN_BITIS_ZAMANI.Name = "colONGORULEN_BITIS_ZAMANI";
            colONGORULEN_BITIS_ZAMANI.Visible = true;

            GridColumn colYER = new GridColumn();
            colYER.VisibleIndex = 11;
            colYER.FieldName = "YER";
            colYER.Name = "colYER";
            colYER.Visible = true;

            GridColumn colKONU = new GridColumn();
            colKONU.VisibleIndex = 12;
            colKONU.FieldName = "KONU";
            colKONU.Name = "colKONU";
            colKONU.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 13;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 14;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 15;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colIS_TARAF_ADI = new GridColumn();
            colIS_TARAF_ADI.VisibleIndex = 16;
            colIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            colIS_TARAF_ADI.Name = "colIS_TARAF_ADI";
            colIS_TARAF_ADI.Visible = true;

            GridColumn colIS_TARAF = new GridColumn();
            colIS_TARAF.VisibleIndex = 17;
            colIS_TARAF.FieldName = "IS_TARAF";
            colIS_TARAF.Name = "colIS_TARAF";
            colIS_TARAF.Visible = true;

            GridColumn colIS_ONCELIK = new GridColumn();
            colIS_ONCELIK.VisibleIndex = 18;
            colIS_ONCELIK.FieldName = "IS_ONCELIK";
            colIS_ONCELIK.Name = "colIS_ONCELIK";
            colIS_ONCELIK.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 19;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colIS_ID = new GridColumn();
            colIS_ID.VisibleIndex = 20;
            colIS_ID.FieldName = "IS_ID";
            colIS_ID.Name = "colIS_ID";
            colIS_ID.Visible = true;

            GridColumn colBITIS_ZAMANI = new GridColumn();
            colBITIS_ZAMANI.VisibleIndex = 21;
            colBITIS_ZAMANI.FieldName = "BITIS_ZAMANI";
            colBITIS_ZAMANI.Name = "colBITIS_ZAMANI";
            colBITIS_ZAMANI.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 22;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colIS_SUREC = new GridColumn();
            colIS_SUREC.VisibleIndex = 23;
            colIS_SUREC.FieldName = "IS_SUREC";
            colIS_SUREC.Name = "colIS_SUREC";
            colIS_SUREC.Visible = true;

            GridColumn colSUREC_ACIKLAMA = new GridColumn();
            colSUREC_ACIKLAMA.VisibleIndex = 24;
            colSUREC_ACIKLAMA.FieldName = "SUREC_ACIKLAMA";
            colSUREC_ACIKLAMA.Name = "colSUREC_ACIKLAMA";
            colSUREC_ACIKLAMA.Visible = true;

            GridColumn colMUHASEBELESTILMIS_MI = new GridColumn();
            colMUHASEBELESTILMIS_MI.VisibleIndex = 25;
            colMUHASEBELESTILMIS_MI.FieldName = "MUHASEBELESTILMIS_MI";
            colMUHASEBELESTILMIS_MI.Name = "colMUHASEBELESTILMIS_MI";
            colMUHASEBELESTILMIS_MI.Visible = true;

            GridColumn colSURE = new GridColumn();
            colSURE.VisibleIndex = 26;
            colSURE.FieldName = "SURE";
            colSURE.Name = "colSURE";
            colSURE.Visible = true;

            GridColumn colBIRIM_FIYAT = new GridColumn();
            colBIRIM_FIYAT.VisibleIndex = 27;
            colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
            colBIRIM_FIYAT.Visible = true;

            GridColumn colTOPLAM_FIYAT = new GridColumn();
            colTOPLAM_FIYAT.VisibleIndex = 28;
            colTOPLAM_FIYAT.FieldName = "TOPLAM_FIYAT";
            colTOPLAM_FIYAT.Name = "colTOPLAM_FIYAT";
            colTOPLAM_FIYAT.Visible = true;

            GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
            colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 29;
            colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Visible = true;

            GridColumn colTOPLAM_FIYAT_DOVIZ_ID = new GridColumn();
            colTOPLAM_FIYAT_DOVIZ_ID.VisibleIndex = 30;
            colTOPLAM_FIYAT_DOVIZ_ID.FieldName = "TOPLAM_FIYAT_DOVIZ_ID";
            colTOPLAM_FIYAT_DOVIZ_ID.Name = "colTOPLAM_FIYAT_DOVIZ_ID";
            colTOPLAM_FIYAT_DOVIZ_ID.Visible = true;

            GridColumn colSOZLESME_KATEGORI = new GridColumn();
            colSOZLESME_KATEGORI.VisibleIndex = 31;
            colSOZLESME_KATEGORI.FieldName = "SOZLESME_KATEGORI";
            colSOZLESME_KATEGORI.Name = "colSOZLESME_KATEGORI";
            colSOZLESME_KATEGORI.Visible = true;

            GridColumn colMADDE_KALEM = new GridColumn();
            colMADDE_KALEM.VisibleIndex = 32;
            colMADDE_KALEM.FieldName = "MADDE_KALEM";
            colMADDE_KALEM.Name = "colMADDE_KALEM";
            colMADDE_KALEM.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colBASLANGIC_ZAMANI,
			colALT_KATEGORI,
			colADLIYE,
			colGOREV,
			colNO,
			colAD,
			colDURUM,
			colKAPAMA_TARIHI,
			colPLANLAMA_TARIHI,
			colONGORULEN_BITIS_TARIHI,
			colONGORULEN_BITIS_ZAMANI,
			colYER,
			colKONU,
			colESAS_NO,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
			colIS_TARAF_ADI,
			colIS_TARAF,
			colIS_ONCELIK,
			colID,
			colIS_ID,
			colBITIS_ZAMANI,
			colSORUMLU,
			colIS_SUREC,
			colSUREC_ACIKLAMA,
			colMUHASEBELESTILMIS_MI,
			colSURE,
			colBIRIM_FIYAT,
			colTOPLAM_FIYAT,
			colBIRIM_FIYAT_DOVIZ_ID,
			colTOPLAM_FIYAT_DOVIZ_ID,
			colSOZLESME_KATEGORI,
			colMADDE_KALEM,
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
            #region Field & Properties

            PivotGridField fieldBASLANGIC_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASLANGIC_ZAMANI.AreaIndex = 0;
            fieldBASLANGIC_ZAMANI.FieldName = "BASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Name = "fieldBASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Visible = false;

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 2;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 3;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 4;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 5;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 6;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 7;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            PivotGridField fieldPLANLAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPLANLAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPLANLAMA_TARIHI.AreaIndex = 8;
            fieldPLANLAMA_TARIHI.FieldName = "PLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Name = "fieldPLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Visible = false;

            PivotGridField fieldONGORULEN_BITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_TARIHI.AreaIndex = 9;
            fieldONGORULEN_BITIS_TARIHI.FieldName = "ONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Name = "fieldONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Visible = false;

            PivotGridField fieldONGORULEN_BITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_ZAMANI.AreaIndex = 10;
            fieldONGORULEN_BITIS_ZAMANI.FieldName = "ONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Name = "fieldONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Visible = false;

            PivotGridField fieldYER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldYER.AreaIndex = 11;
            fieldYER.FieldName = "YER";
            fieldYER.Name = "fieldYER";
            fieldYER.Visible = false;

            PivotGridField fieldKONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONU.AreaIndex = 12;
            fieldKONU.FieldName = "KONU";
            fieldKONU.Name = "fieldKONU";
            fieldKONU.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 13;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 14;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 15;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_TARAF_ADI.AreaIndex = 16;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = false;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_TARAF.AreaIndex = 17;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 18;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldIS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ID.AreaIndex = 20;
            fieldIS_ID.FieldName = "IS_ID";
            fieldIS_ID.Name = "fieldIS_ID";
            fieldIS_ID.Visible = false;

            PivotGridField fieldBITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_ZAMANI.AreaIndex = 21;
            fieldBITIS_ZAMANI.FieldName = "BITIS_ZAMANI";
            fieldBITIS_ZAMANI.Name = "fieldBITIS_ZAMANI";
            fieldBITIS_ZAMANI.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 22;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldIS_SUREC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_SUREC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_SUREC.AreaIndex = 23;
            fieldIS_SUREC.FieldName = "IS_SUREC";
            fieldIS_SUREC.Name = "fieldIS_SUREC";
            fieldIS_SUREC.Visible = false;

            PivotGridField fieldSUREC_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUREC_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUREC_ACIKLAMA.AreaIndex = 24;
            fieldSUREC_ACIKLAMA.FieldName = "SUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Name = "fieldSUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Visible = false;

            PivotGridField fieldMUHASEBELESTILMIS_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUHASEBELESTILMIS_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUHASEBELESTILMIS_MI.AreaIndex = 25;
            fieldMUHASEBELESTILMIS_MI.FieldName = "MUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Name = "fieldMUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Visible = false;

            PivotGridField fieldSURE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSURE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSURE.AreaIndex = 26;
            fieldSURE.FieldName = "SURE";
            fieldSURE.Name = "fieldSURE";
            fieldSURE.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 27;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_FIYAT.AreaIndex = 28;
            fieldTOPLAM_FIYAT.FieldName = "TOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Name = "fieldTOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 29;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_FIYAT_DOVIZ_ID.AreaIndex = 30;
            fieldTOPLAM_FIYAT_DOVIZ_ID.FieldName = "TOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Name = "fieldTOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldSOZLESME_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_KATEGORI.AreaIndex = 31;
            fieldSOZLESME_KATEGORI.FieldName = "SOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Name = "fieldSOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Visible = false;

            PivotGridField fieldMADDE_KALEM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMADDE_KALEM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMADDE_KALEM.AreaIndex = 32;
            fieldMADDE_KALEM.FieldName = "MADDE_KALEM";
            fieldMADDE_KALEM.Name = "fieldMADDE_KALEM";
            fieldMADDE_KALEM.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = null;
            switch (pencere)
            {
                case "Ücretlendirilmiş Yerine Göre İşler":
                    dizi = UcretlendirilmisYerineGoreIsler();
                    break;

                case "Ücretlendirilmiş Kategorisine Göre İşler":
                    dizi = UcretlendirilmisKategorisineGoreIsler();
                    break;

                case "Ücretlendirilmiş Tarihine Göre İşler(Haftalık vs.)":
                    dizi = UcretlendirilmisTarihineGoreIsler();
                    break;

                case "Ücretlendirilmiş Gününe Göre İşler":
                    dizi = UcretlendirilmisGununeGoreIsler();
                    break;

                case "Ücretlendirilmiş Yılına Göre İşler":
                    dizi = UcretlendirilmisYilinaGoreIsler();
                    break;

                case "Ücretlendirilmiş Ayına Göre İşler":
                    dizi = UcretlendirilmisAyinaGoreIsler();
                    break;

                case "Ücretlendirilmiş Müvekkile Göre İşler":
                    dizi = UcretlendirilmisMuvekkilineGoreIsler();
                    break;
            }

            #region []

            if (dizi == null)
            {
                dizi = new PivotGridField[]
		{
			fieldBASLANGIC_ZAMANI,
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,
			fieldKAPAMA_TARIHI,
			fieldPLANLAMA_TARIHI,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldIS_ONCELIK,
			fieldID,
			fieldIS_ID,
			fieldBITIS_ZAMANI,
			fieldSORUMLU,
			fieldIS_SUREC,
			fieldSUREC_ACIKLAMA,
			fieldMUHASEBELESTILMIS_MI,
			fieldSURE,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_FIYAT,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldTOPLAM_FIYAT_DOVIZ_ID,
			fieldSOZLESME_KATEGORI,
			fieldMADDE_KALEM,
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

            dicFieldCaption.Add("BASLANGIC_ZAMANI", "Baslangı. Zmn");
            dicFieldCaption.Add("ALT_KATEGORI", "Kategori");
            dicFieldCaption.Add("ADLIYE", "Adliye");
            dicFieldCaption.Add("GOREV", "Görev");
            dicFieldCaption.Add("NO", "No");
            dicFieldCaption.Add("AD", "Modül");
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("KAPAMA_TARIHI", "Kapama T");
            dicFieldCaption.Add("PLANLAMA_TARIHI", "Planlama T");
            dicFieldCaption.Add("ONGORULEN_BITIS_TARIHI", "Öng Bitiş T");
            dicFieldCaption.Add("ONGORULEN_BITIS_ZAMANI", "Öng Bitiş Zmn");
            dicFieldCaption.Add("YER", "Yer");
            dicFieldCaption.Add("KONU", "Konu");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("IS_TARAF_ADI", "İş Taraf");
            dicFieldCaption.Add("IS_TARAF", "İş Taraf K");
            dicFieldCaption.Add("IS_ONCELIK", "İş Öncelik");
            dicFieldCaption.Add("ID", "Dosya Sayisi");
            dicFieldCaption.Add("IS_ID", "İş Dosya Sayisi");
            dicFieldCaption.Add("BITIS_ZAMANI", "Bitiş Zmn");
            dicFieldCaption.Add("SORUMLU", "Sorumlu");
            dicFieldCaption.Add("IS_SUREC", "İş Süreç");
            dicFieldCaption.Add("SUREC_ACIKLAMA", "Süreç Açıklama");
            dicFieldCaption.Add("MUHASEBELESTILMIS_MI", "Muhasebeleştirilmiş");
            dicFieldCaption.Add("SURE", "Süre");
            dicFieldCaption.Add("BIRIM_FIYAT", "Birim Fiyat");
            dicFieldCaption.Add("TOPLAM_FIYAT", "Toplam Fiyat");
            dicFieldCaption.Add("SOZLESME_KATEGORI", "İş Sözleşme");
            dicFieldCaption.Add("MADDE_KALEM", "Madde Kalem");

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

        private PivotGridField[] UcretlendirilmisAyinaGoreIsler()
        {
            #region Field & Properties

            PivotGridField fieldBASLANGIC_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASLANGIC_ZAMANI.AreaIndex = 0;
            fieldBASLANGIC_ZAMANI.FieldName = "BASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Name = "fieldBASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Visible = false;

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 2;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 3;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 4;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 5;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 6;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 7;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            PivotGridField fieldPLANLAMA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPLANLAMA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldPLANLAMA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldPLANLAMA_TARIHI2.AreaIndex = 7;
            fieldPLANLAMA_TARIHI2.FieldName = "PLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI2.Name = "fieldPLANLAMA_TARIHI2";
            fieldPLANLAMA_TARIHI2.Visible = true;

            PivotGridField fieldPLANLAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPLANLAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldPLANLAMA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldPLANLAMA_TARIHI.AreaIndex = 8;
            fieldPLANLAMA_TARIHI.FieldName = "PLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Name = "fieldPLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Visible = true;

            PivotGridField fieldONGORULEN_BITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_TARIHI.AreaIndex = 9;
            fieldONGORULEN_BITIS_TARIHI.FieldName = "ONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Name = "fieldONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Visible = false;

            PivotGridField fieldONGORULEN_BITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_ZAMANI.AreaIndex = 10;
            fieldONGORULEN_BITIS_ZAMANI.FieldName = "ONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Name = "fieldONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Visible = false;

            PivotGridField fieldYER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYER.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldYER.AreaIndex = 0;
            fieldYER.FieldName = "YER";
            fieldYER.Name = "fieldYER";
            fieldYER.Visible = false;

            PivotGridField fieldKONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldKONU.AreaIndex = 12;
            fieldKONU.FieldName = "KONU";
            fieldKONU.Name = "fieldKONU";
            fieldKONU.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 13;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 14;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 15;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF_ADI.AreaIndex = 16;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = true;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_TARAF.AreaIndex = 17;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 18;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ID.AreaIndex = 20;
            fieldIS_ID.FieldName = "IS_ID";
            fieldIS_ID.Name = "fieldIS_ID";
            fieldIS_ID.Visible = false;

            PivotGridField fieldBITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_ZAMANI.AreaIndex = 21;
            fieldBITIS_ZAMANI.FieldName = "BITIS_ZAMANI";
            fieldBITIS_ZAMANI.Name = "fieldBITIS_ZAMANI";
            fieldBITIS_ZAMANI.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSORUMLU.AreaIndex = 22;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = true;

            PivotGridField fieldIS_SUREC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_SUREC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_SUREC.AreaIndex = 23;
            fieldIS_SUREC.FieldName = "IS_SUREC";
            fieldIS_SUREC.Name = "fieldIS_SUREC";
            fieldIS_SUREC.Visible = false;

            PivotGridField fieldSUREC_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUREC_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUREC_ACIKLAMA.AreaIndex = 24;
            fieldSUREC_ACIKLAMA.FieldName = "SUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Name = "fieldSUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Visible = false;

            PivotGridField fieldMUHASEBELESTILMIS_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUHASEBELESTILMIS_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUHASEBELESTILMIS_MI.AreaIndex = 25;
            fieldMUHASEBELESTILMIS_MI.FieldName = "MUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Name = "fieldMUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Visible = false;

            PivotGridField fieldSURE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSURE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSURE.AreaIndex = 26;
            fieldSURE.FieldName = "SURE";
            fieldSURE.Name = "fieldSURE";
            fieldSURE.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 27;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTOPLAM_FIYAT.AreaIndex = 28;
            fieldTOPLAM_FIYAT.FieldName = "TOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Name = "fieldTOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Visible = true;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 29;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_FIYAT_DOVIZ_ID.AreaIndex = 30;
            fieldTOPLAM_FIYAT_DOVIZ_ID.FieldName = "TOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Name = "fieldTOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldSOZLESME_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_KATEGORI.AreaIndex = 31;
            fieldSOZLESME_KATEGORI.FieldName = "SOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Name = "fieldSOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Visible = false;

            PivotGridField fieldMADDE_KALEM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMADDE_KALEM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMADDE_KALEM.AreaIndex = 32;
            fieldMADDE_KALEM.FieldName = "MADDE_KALEM";
            fieldMADDE_KALEM.Name = "fieldMADDE_KALEM";
            fieldMADDE_KALEM.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldBASLANGIC_ZAMANI,
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,
			fieldKAPAMA_TARIHI,
			fieldPLANLAMA_TARIHI,
            fieldPLANLAMA_TARIHI2,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldIS_ONCELIK,
			fieldID,

			//fieldIS_ID,
			fieldBITIS_ZAMANI,
			fieldSORUMLU,
			fieldIS_SUREC,
			fieldSUREC_ACIKLAMA,
			fieldMUHASEBELESTILMIS_MI,
			fieldSURE,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_FIYAT,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldTOPLAM_FIYAT_DOVIZ_ID,
			fieldSOZLESME_KATEGORI,
			fieldMADDE_KALEM,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] UcretlendirilmisGununeGoreIsler()
        {
            #region Field & Properties

            PivotGridField fieldBASLANGIC_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASLANGIC_ZAMANI.AreaIndex = 0;
            fieldBASLANGIC_ZAMANI.FieldName = "BASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Name = "fieldBASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Visible = false;

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 2;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 3;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 4;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 5;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 6;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 7;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            PivotGridField fieldPLANLAMA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPLANLAMA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldPLANLAMA_TARIHI2.GroupInterval = PivotGroupInterval.DateMonth;
            fieldPLANLAMA_TARIHI2.AreaIndex = 7;
            fieldPLANLAMA_TARIHI2.FieldName = "PLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI2.Name = "fieldPLANLAMA_TARIHI2";
            fieldPLANLAMA_TARIHI2.Visible = true;

            PivotGridField fieldPLANLAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPLANLAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldPLANLAMA_TARIHI.GroupInterval = PivotGroupInterval.DateDayOfYear;
            fieldPLANLAMA_TARIHI.AreaIndex = 8;
            fieldPLANLAMA_TARIHI.FieldName = "PLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Name = "fieldPLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Visible = true;

            PivotGridField fieldONGORULEN_BITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_TARIHI.AreaIndex = 9;
            fieldONGORULEN_BITIS_TARIHI.FieldName = "ONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Name = "fieldONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Visible = false;

            PivotGridField fieldONGORULEN_BITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_ZAMANI.AreaIndex = 10;
            fieldONGORULEN_BITIS_ZAMANI.FieldName = "ONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Name = "fieldONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Visible = false;

            PivotGridField fieldYER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYER.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldYER.AreaIndex = 0;
            fieldYER.FieldName = "YER";
            fieldYER.Name = "fieldYER";
            fieldYER.Visible = false;

            PivotGridField fieldKONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldKONU.AreaIndex = 12;
            fieldKONU.FieldName = "KONU";
            fieldKONU.Name = "fieldKONU";
            fieldKONU.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 13;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 14;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 15;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF_ADI.AreaIndex = 16;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = true;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_TARAF.AreaIndex = 17;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 18;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ID.AreaIndex = 20;
            fieldIS_ID.FieldName = "IS_ID";
            fieldIS_ID.Name = "fieldIS_ID";
            fieldIS_ID.Visible = false;

            PivotGridField fieldBITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_ZAMANI.AreaIndex = 21;
            fieldBITIS_ZAMANI.FieldName = "BITIS_ZAMANI";
            fieldBITIS_ZAMANI.Name = "fieldBITIS_ZAMANI";
            fieldBITIS_ZAMANI.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSORUMLU.AreaIndex = 22;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = true;

            PivotGridField fieldIS_SUREC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_SUREC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_SUREC.AreaIndex = 23;
            fieldIS_SUREC.FieldName = "IS_SUREC";
            fieldIS_SUREC.Name = "fieldIS_SUREC";
            fieldIS_SUREC.Visible = false;

            PivotGridField fieldSUREC_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUREC_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUREC_ACIKLAMA.AreaIndex = 24;
            fieldSUREC_ACIKLAMA.FieldName = "SUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Name = "fieldSUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Visible = false;

            PivotGridField fieldMUHASEBELESTILMIS_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUHASEBELESTILMIS_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUHASEBELESTILMIS_MI.AreaIndex = 25;
            fieldMUHASEBELESTILMIS_MI.FieldName = "MUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Name = "fieldMUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Visible = false;

            PivotGridField fieldSURE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSURE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSURE.AreaIndex = 26;
            fieldSURE.FieldName = "SURE";
            fieldSURE.Name = "fieldSURE";
            fieldSURE.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 27;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTOPLAM_FIYAT.AreaIndex = 28;
            fieldTOPLAM_FIYAT.FieldName = "TOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Name = "fieldTOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Visible = true;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 29;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_FIYAT_DOVIZ_ID.AreaIndex = 30;
            fieldTOPLAM_FIYAT_DOVIZ_ID.FieldName = "TOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Name = "fieldTOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldSOZLESME_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_KATEGORI.AreaIndex = 31;
            fieldSOZLESME_KATEGORI.FieldName = "SOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Name = "fieldSOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Visible = false;

            PivotGridField fieldMADDE_KALEM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMADDE_KALEM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMADDE_KALEM.AreaIndex = 32;
            fieldMADDE_KALEM.FieldName = "MADDE_KALEM";
            fieldMADDE_KALEM.Name = "fieldMADDE_KALEM";
            fieldMADDE_KALEM.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldBASLANGIC_ZAMANI,
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,
			fieldKAPAMA_TARIHI,
            fieldPLANLAMA_TARIHI2,
			fieldPLANLAMA_TARIHI,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldIS_ONCELIK,
			fieldID,
			fieldIS_ID,
			fieldBITIS_ZAMANI,
			fieldSORUMLU,
			fieldIS_SUREC,
			fieldSUREC_ACIKLAMA,
			fieldMUHASEBELESTILMIS_MI,
			fieldSURE,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_FIYAT,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldTOPLAM_FIYAT_DOVIZ_ID,
			fieldSOZLESME_KATEGORI,
			fieldMADDE_KALEM,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] UcretlendirilmisKategorisineGoreIsler()
        {
            #region Field & Properties

            PivotGridField fieldBASLANGIC_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASLANGIC_ZAMANI.AreaIndex = 0;
            fieldBASLANGIC_ZAMANI.FieldName = "BASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Name = "fieldBASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Visible = false;

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 2;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 3;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 4;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 5;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 6;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 7;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            PivotGridField fieldPLANLAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPLANLAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldPLANLAMA_TARIHI.AreaIndex = 8;
            fieldPLANLAMA_TARIHI.FieldName = "PLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Name = "fieldPLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Visible = true;

            PivotGridField fieldONGORULEN_BITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_TARIHI.AreaIndex = 9;
            fieldONGORULEN_BITIS_TARIHI.FieldName = "ONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Name = "fieldONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Visible = false;

            PivotGridField fieldONGORULEN_BITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_ZAMANI.AreaIndex = 10;
            fieldONGORULEN_BITIS_ZAMANI.FieldName = "ONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Name = "fieldONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Visible = false;

            PivotGridField fieldYER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYER.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldYER.AreaIndex = 0;
            fieldYER.FieldName = "YER";
            fieldYER.Name = "fieldYER";
            fieldYER.Visible = false;

            PivotGridField fieldKONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldKONU.AreaIndex = 12;
            fieldKONU.FieldName = "KONU";
            fieldKONU.Name = "fieldKONU";
            fieldKONU.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 13;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 14;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 15;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF_ADI.AreaIndex = 16;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = true;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_TARAF.AreaIndex = 17;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 18;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ID.AreaIndex = 20;
            fieldIS_ID.FieldName = "IS_ID";
            fieldIS_ID.Name = "fieldIS_ID";
            fieldIS_ID.Visible = false;

            PivotGridField fieldBITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_ZAMANI.AreaIndex = 21;
            fieldBITIS_ZAMANI.FieldName = "BITIS_ZAMANI";
            fieldBITIS_ZAMANI.Name = "fieldBITIS_ZAMANI";
            fieldBITIS_ZAMANI.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSORUMLU.AreaIndex = 22;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = true;

            PivotGridField fieldIS_SUREC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_SUREC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_SUREC.AreaIndex = 23;
            fieldIS_SUREC.FieldName = "IS_SUREC";
            fieldIS_SUREC.Name = "fieldIS_SUREC";
            fieldIS_SUREC.Visible = false;

            PivotGridField fieldSUREC_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUREC_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUREC_ACIKLAMA.AreaIndex = 24;
            fieldSUREC_ACIKLAMA.FieldName = "SUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Name = "fieldSUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Visible = false;

            PivotGridField fieldMUHASEBELESTILMIS_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUHASEBELESTILMIS_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUHASEBELESTILMIS_MI.AreaIndex = 25;
            fieldMUHASEBELESTILMIS_MI.FieldName = "MUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Name = "fieldMUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Visible = false;

            PivotGridField fieldSURE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSURE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSURE.AreaIndex = 26;
            fieldSURE.FieldName = "SURE";
            fieldSURE.Name = "fieldSURE";
            fieldSURE.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 27;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTOPLAM_FIYAT.AreaIndex = 28;
            fieldTOPLAM_FIYAT.FieldName = "TOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Name = "fieldTOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Visible = true;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 29;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_FIYAT_DOVIZ_ID.AreaIndex = 30;
            fieldTOPLAM_FIYAT_DOVIZ_ID.FieldName = "TOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Name = "fieldTOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldSOZLESME_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_KATEGORI.AreaIndex = 31;
            fieldSOZLESME_KATEGORI.FieldName = "SOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Name = "fieldSOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Visible = false;

            PivotGridField fieldMADDE_KALEM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMADDE_KALEM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMADDE_KALEM.AreaIndex = 32;
            fieldMADDE_KALEM.FieldName = "MADDE_KALEM";
            fieldMADDE_KALEM.Name = "fieldMADDE_KALEM";
            fieldMADDE_KALEM.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldBASLANGIC_ZAMANI,
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,
			fieldKAPAMA_TARIHI,
			fieldPLANLAMA_TARIHI,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldIS_ONCELIK,
			fieldID,
			fieldIS_ID,
			fieldBITIS_ZAMANI,
			fieldSORUMLU,
			fieldIS_SUREC,
			fieldSUREC_ACIKLAMA,
			fieldMUHASEBELESTILMIS_MI,
			fieldSURE,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_FIYAT,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldTOPLAM_FIYAT_DOVIZ_ID,
			fieldSOZLESME_KATEGORI,
			fieldMADDE_KALEM,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] UcretlendirilmisMuvekkilineGoreIsler()
        {
            #region Field & Properties

            PivotGridField fieldBASLANGIC_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASLANGIC_ZAMANI.AreaIndex = 0;
            fieldBASLANGIC_ZAMANI.FieldName = "BASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Name = "fieldBASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Visible = false;

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 2;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 3;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 4;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 5;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 6;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 7;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            PivotGridField fieldPLANLAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPLANLAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldPLANLAMA_TARIHI.GroupInterval = PivotGroupInterval.DateYear;
            fieldPLANLAMA_TARIHI.AreaIndex = 8;
            fieldPLANLAMA_TARIHI.FieldName = "PLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Name = "fieldPLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Visible = true;

            PivotGridField fieldONGORULEN_BITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_TARIHI.AreaIndex = 9;
            fieldONGORULEN_BITIS_TARIHI.FieldName = "ONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Name = "fieldONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Visible = false;

            PivotGridField fieldONGORULEN_BITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_ZAMANI.AreaIndex = 10;
            fieldONGORULEN_BITIS_ZAMANI.FieldName = "ONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Name = "fieldONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Visible = false;

            PivotGridField fieldYER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYER.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldYER.AreaIndex = 0;
            fieldYER.FieldName = "YER";
            fieldYER.Name = "fieldYER";
            fieldYER.Visible = false;

            PivotGridField fieldKONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldKONU.AreaIndex = 12;
            fieldKONU.FieldName = "KONU";
            fieldKONU.Name = "fieldKONU";
            fieldKONU.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 13;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 14;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 15;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF_ADI.AreaIndex = 0;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = true;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_TARAF.AreaIndex = 17;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 18;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ID.AreaIndex = 20;
            fieldIS_ID.FieldName = "IS_ID";
            fieldIS_ID.Name = "fieldIS_ID";
            fieldIS_ID.Visible = false;

            PivotGridField fieldBITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_ZAMANI.AreaIndex = 21;
            fieldBITIS_ZAMANI.FieldName = "BITIS_ZAMANI";
            fieldBITIS_ZAMANI.Name = "fieldBITIS_ZAMANI";
            fieldBITIS_ZAMANI.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSORUMLU.AreaIndex = 22;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = true;

            PivotGridField fieldIS_SUREC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_SUREC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_SUREC.AreaIndex = 23;
            fieldIS_SUREC.FieldName = "IS_SUREC";
            fieldIS_SUREC.Name = "fieldIS_SUREC";
            fieldIS_SUREC.Visible = false;

            PivotGridField fieldSUREC_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUREC_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUREC_ACIKLAMA.AreaIndex = 24;
            fieldSUREC_ACIKLAMA.FieldName = "SUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Name = "fieldSUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Visible = false;

            PivotGridField fieldMUHASEBELESTILMIS_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUHASEBELESTILMIS_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUHASEBELESTILMIS_MI.AreaIndex = 25;
            fieldMUHASEBELESTILMIS_MI.FieldName = "MUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Name = "fieldMUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Visible = false;

            PivotGridField fieldSURE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSURE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSURE.AreaIndex = 26;
            fieldSURE.FieldName = "SURE";
            fieldSURE.Name = "fieldSURE";
            fieldSURE.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 27;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTOPLAM_FIYAT.AreaIndex = 28;
            fieldTOPLAM_FIYAT.FieldName = "TOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Name = "fieldTOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Visible = true;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 29;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_FIYAT_DOVIZ_ID.AreaIndex = 30;
            fieldTOPLAM_FIYAT_DOVIZ_ID.FieldName = "TOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Name = "fieldTOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldSOZLESME_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_KATEGORI.AreaIndex = 31;
            fieldSOZLESME_KATEGORI.FieldName = "SOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Name = "fieldSOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Visible = false;

            PivotGridField fieldMADDE_KALEM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMADDE_KALEM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMADDE_KALEM.AreaIndex = 32;
            fieldMADDE_KALEM.FieldName = "MADDE_KALEM";
            fieldMADDE_KALEM.Name = "fieldMADDE_KALEM";
            fieldMADDE_KALEM.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldBASLANGIC_ZAMANI,
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,
			fieldKAPAMA_TARIHI,
			fieldPLANLAMA_TARIHI,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldIS_ONCELIK,
			fieldID,
			fieldIS_ID,
			fieldBITIS_ZAMANI,
			fieldSORUMLU,
			fieldIS_SUREC,
			fieldSUREC_ACIKLAMA,
			fieldMUHASEBELESTILMIS_MI,
			fieldSURE,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_FIYAT,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldTOPLAM_FIYAT_DOVIZ_ID,
			fieldSOZLESME_KATEGORI,
			fieldMADDE_KALEM,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] UcretlendirilmisTarihineGoreIsler()
        {
            #region Field & Properties

            PivotGridField fieldBASLANGIC_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASLANGIC_ZAMANI.AreaIndex = 0;
            fieldBASLANGIC_ZAMANI.FieldName = "BASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Name = "fieldBASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Visible = false;

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 2;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 3;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 4;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 5;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 6;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 7;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            PivotGridField fieldPLANLAMA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPLANLAMA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldPLANLAMA_TARIHI2.GroupInterval = PivotGroupInterval.DateMonth;
            fieldPLANLAMA_TARIHI2.AreaIndex = 7;
            fieldPLANLAMA_TARIHI2.FieldName = "PLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI2.Name = "fieldPLANLAMA_TARIHI2";
            fieldPLANLAMA_TARIHI2.Visible = true;

            PivotGridField fieldPLANLAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPLANLAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldPLANLAMA_TARIHI.GroupInterval = PivotGroupInterval.DateWeekOfMonth;
            fieldPLANLAMA_TARIHI.AreaIndex = 8;
            fieldPLANLAMA_TARIHI.FieldName = "PLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Name = "fieldPLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Visible = true;

            PivotGridField fieldONGORULEN_BITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_TARIHI.AreaIndex = 9;
            fieldONGORULEN_BITIS_TARIHI.FieldName = "ONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Name = "fieldONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Visible = false;

            PivotGridField fieldONGORULEN_BITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_ZAMANI.AreaIndex = 10;
            fieldONGORULEN_BITIS_ZAMANI.FieldName = "ONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Name = "fieldONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Visible = false;

            PivotGridField fieldYER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYER.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldYER.AreaIndex = 0;
            fieldYER.FieldName = "YER";
            fieldYER.Name = "fieldYER";
            fieldYER.Visible = false;

            PivotGridField fieldKONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldKONU.AreaIndex = 12;
            fieldKONU.FieldName = "KONU";
            fieldKONU.Name = "fieldKONU";
            fieldKONU.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 13;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 14;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 15;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF_ADI.AreaIndex = 16;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = true;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_TARAF.AreaIndex = 17;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 18;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ID.AreaIndex = 20;
            fieldIS_ID.FieldName = "IS_ID";
            fieldIS_ID.Name = "fieldIS_ID";
            fieldIS_ID.Visible = false;

            PivotGridField fieldBITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_ZAMANI.AreaIndex = 21;
            fieldBITIS_ZAMANI.FieldName = "BITIS_ZAMANI";
            fieldBITIS_ZAMANI.Name = "fieldBITIS_ZAMANI";
            fieldBITIS_ZAMANI.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSORUMLU.AreaIndex = 22;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = true;

            PivotGridField fieldIS_SUREC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_SUREC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_SUREC.AreaIndex = 23;
            fieldIS_SUREC.FieldName = "IS_SUREC";
            fieldIS_SUREC.Name = "fieldIS_SUREC";
            fieldIS_SUREC.Visible = false;

            PivotGridField fieldSUREC_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUREC_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUREC_ACIKLAMA.AreaIndex = 24;
            fieldSUREC_ACIKLAMA.FieldName = "SUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Name = "fieldSUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Visible = false;

            PivotGridField fieldMUHASEBELESTILMIS_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUHASEBELESTILMIS_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUHASEBELESTILMIS_MI.AreaIndex = 25;
            fieldMUHASEBELESTILMIS_MI.FieldName = "MUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Name = "fieldMUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Visible = false;

            PivotGridField fieldSURE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSURE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSURE.AreaIndex = 26;
            fieldSURE.FieldName = "SURE";
            fieldSURE.Name = "fieldSURE";
            fieldSURE.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 27;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTOPLAM_FIYAT.AreaIndex = 28;
            fieldTOPLAM_FIYAT.FieldName = "TOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Name = "fieldTOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Visible = true;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 29;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_FIYAT_DOVIZ_ID.AreaIndex = 30;
            fieldTOPLAM_FIYAT_DOVIZ_ID.FieldName = "TOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Name = "fieldTOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldSOZLESME_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_KATEGORI.AreaIndex = 31;
            fieldSOZLESME_KATEGORI.FieldName = "SOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Name = "fieldSOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Visible = false;

            PivotGridField fieldMADDE_KALEM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMADDE_KALEM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMADDE_KALEM.AreaIndex = 32;
            fieldMADDE_KALEM.FieldName = "MADDE_KALEM";
            fieldMADDE_KALEM.Name = "fieldMADDE_KALEM";
            fieldMADDE_KALEM.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldBASLANGIC_ZAMANI,
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,
			fieldKAPAMA_TARIHI,
            fieldPLANLAMA_TARIHI2,
			fieldPLANLAMA_TARIHI,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldIS_ONCELIK,
			fieldID,
			fieldIS_ID,
			fieldBITIS_ZAMANI,
			fieldSORUMLU,
			fieldIS_SUREC,
			fieldSUREC_ACIKLAMA,
			fieldMUHASEBELESTILMIS_MI,
			fieldSURE,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_FIYAT,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldTOPLAM_FIYAT_DOVIZ_ID,
			fieldSOZLESME_KATEGORI,
			fieldMADDE_KALEM,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] UcretlendirilmisYerineGoreIsler()
        {
            #region Field & Properties

            PivotGridField fieldBASLANGIC_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASLANGIC_ZAMANI.AreaIndex = 0;
            fieldBASLANGIC_ZAMANI.FieldName = "BASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Name = "fieldBASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Visible = false;

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 2;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 3;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 4;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 5;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 6;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 7;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            PivotGridField fieldPLANLAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPLANLAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldPLANLAMA_TARIHI.AreaIndex = 8;
            fieldPLANLAMA_TARIHI.FieldName = "PLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Name = "fieldPLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Visible = true;

            PivotGridField fieldONGORULEN_BITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_TARIHI.AreaIndex = 9;
            fieldONGORULEN_BITIS_TARIHI.FieldName = "ONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Name = "fieldONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Visible = false;

            PivotGridField fieldONGORULEN_BITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_ZAMANI.AreaIndex = 10;
            fieldONGORULEN_BITIS_ZAMANI.FieldName = "ONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Name = "fieldONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Visible = false;

            PivotGridField fieldYER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYER.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldYER.AreaIndex = 0;
            fieldYER.FieldName = "YER";
            fieldYER.Name = "fieldYER";
            fieldYER.Visible = true;

            PivotGridField fieldKONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldKONU.AreaIndex = 12;
            fieldKONU.FieldName = "KONU";
            fieldKONU.Name = "fieldKONU";
            fieldKONU.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 13;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 14;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 15;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF_ADI.AreaIndex = 16;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = true;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_TARAF.AreaIndex = 17;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 18;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ID.AreaIndex = 20;
            fieldIS_ID.FieldName = "IS_ID";
            fieldIS_ID.Name = "fieldIS_ID";
            fieldIS_ID.Visible = false;

            PivotGridField fieldBITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_ZAMANI.AreaIndex = 21;
            fieldBITIS_ZAMANI.FieldName = "BITIS_ZAMANI";
            fieldBITIS_ZAMANI.Name = "fieldBITIS_ZAMANI";
            fieldBITIS_ZAMANI.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSORUMLU.AreaIndex = 22;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = true;

            PivotGridField fieldIS_SUREC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_SUREC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_SUREC.AreaIndex = 23;
            fieldIS_SUREC.FieldName = "IS_SUREC";
            fieldIS_SUREC.Name = "fieldIS_SUREC";
            fieldIS_SUREC.Visible = false;

            PivotGridField fieldSUREC_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUREC_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUREC_ACIKLAMA.AreaIndex = 24;
            fieldSUREC_ACIKLAMA.FieldName = "SUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Name = "fieldSUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Visible = false;

            PivotGridField fieldMUHASEBELESTILMIS_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUHASEBELESTILMIS_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUHASEBELESTILMIS_MI.AreaIndex = 25;
            fieldMUHASEBELESTILMIS_MI.FieldName = "MUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Name = "fieldMUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Visible = false;

            PivotGridField fieldSURE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSURE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSURE.AreaIndex = 26;
            fieldSURE.FieldName = "SURE";
            fieldSURE.Name = "fieldSURE";
            fieldSURE.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 27;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTOPLAM_FIYAT.AreaIndex = 28;
            fieldTOPLAM_FIYAT.FieldName = "TOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Name = "fieldTOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Visible = true;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 29;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_FIYAT_DOVIZ_ID.AreaIndex = 30;
            fieldTOPLAM_FIYAT_DOVIZ_ID.FieldName = "TOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Name = "fieldTOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldSOZLESME_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_KATEGORI.AreaIndex = 31;
            fieldSOZLESME_KATEGORI.FieldName = "SOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Name = "fieldSOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Visible = false;

            PivotGridField fieldMADDE_KALEM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMADDE_KALEM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMADDE_KALEM.AreaIndex = 32;
            fieldMADDE_KALEM.FieldName = "MADDE_KALEM";
            fieldMADDE_KALEM.Name = "fieldMADDE_KALEM";
            fieldMADDE_KALEM.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldBASLANGIC_ZAMANI,
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,
			fieldKAPAMA_TARIHI,
			fieldPLANLAMA_TARIHI,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldIS_ONCELIK,
			fieldID,

			//fieldIS_ID,
			fieldBITIS_ZAMANI,
			fieldSORUMLU,
			fieldIS_SUREC,
			fieldSUREC_ACIKLAMA,
			fieldMUHASEBELESTILMIS_MI,
			fieldSURE,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_FIYAT,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldTOPLAM_FIYAT_DOVIZ_ID,
			fieldSOZLESME_KATEGORI,
			fieldMADDE_KALEM,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] UcretlendirilmisYilinaGoreIsler()
        {
            #region Field & Properties

            PivotGridField fieldBASLANGIC_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASLANGIC_ZAMANI.AreaIndex = 0;
            fieldBASLANGIC_ZAMANI.FieldName = "BASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Name = "fieldBASLANGIC_ZAMANI";
            fieldBASLANGIC_ZAMANI.Visible = false;

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 2;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 3;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 4;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 5;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 6;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 7;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            PivotGridField fieldPLANLAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPLANLAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldPLANLAMA_TARIHI.GroupInterval = PivotGroupInterval.DateYear;
            fieldPLANLAMA_TARIHI.AreaIndex = 8;
            fieldPLANLAMA_TARIHI.FieldName = "PLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Name = "fieldPLANLAMA_TARIHI";
            fieldPLANLAMA_TARIHI.Visible = true;

            PivotGridField fieldONGORULEN_BITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_TARIHI.AreaIndex = 9;
            fieldONGORULEN_BITIS_TARIHI.FieldName = "ONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Name = "fieldONGORULEN_BITIS_TARIHI";
            fieldONGORULEN_BITIS_TARIHI.Visible = false;

            PivotGridField fieldONGORULEN_BITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONGORULEN_BITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONGORULEN_BITIS_ZAMANI.AreaIndex = 10;
            fieldONGORULEN_BITIS_ZAMANI.FieldName = "ONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Name = "fieldONGORULEN_BITIS_ZAMANI";
            fieldONGORULEN_BITIS_ZAMANI.Visible = false;

            PivotGridField fieldYER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYER.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldYER.AreaIndex = 0;
            fieldYER.FieldName = "YER";
            fieldYER.Name = "fieldYER";
            fieldYER.Visible = false;

            PivotGridField fieldKONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldKONU.AreaIndex = 12;
            fieldKONU.FieldName = "KONU";
            fieldKONU.Name = "fieldKONU";
            fieldKONU.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 13;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 14;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 15;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF_ADI.AreaIndex = 16;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = true;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_TARAF.AreaIndex = 17;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 18;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ID.AreaIndex = 20;
            fieldIS_ID.FieldName = "IS_ID";
            fieldIS_ID.Name = "fieldIS_ID";
            fieldIS_ID.Visible = false;

            PivotGridField fieldBITIS_ZAMANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_ZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_ZAMANI.AreaIndex = 21;
            fieldBITIS_ZAMANI.FieldName = "BITIS_ZAMANI";
            fieldBITIS_ZAMANI.Name = "fieldBITIS_ZAMANI";
            fieldBITIS_ZAMANI.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSORUMLU.AreaIndex = 22;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = true;

            PivotGridField fieldIS_SUREC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_SUREC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_SUREC.AreaIndex = 23;
            fieldIS_SUREC.FieldName = "IS_SUREC";
            fieldIS_SUREC.Name = "fieldIS_SUREC";
            fieldIS_SUREC.Visible = false;

            PivotGridField fieldSUREC_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUREC_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUREC_ACIKLAMA.AreaIndex = 24;
            fieldSUREC_ACIKLAMA.FieldName = "SUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Name = "fieldSUREC_ACIKLAMA";
            fieldSUREC_ACIKLAMA.Visible = false;

            PivotGridField fieldMUHASEBELESTILMIS_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUHASEBELESTILMIS_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUHASEBELESTILMIS_MI.AreaIndex = 25;
            fieldMUHASEBELESTILMIS_MI.FieldName = "MUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Name = "fieldMUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMIS_MI.Visible = false;

            PivotGridField fieldSURE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSURE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSURE.AreaIndex = 26;
            fieldSURE.FieldName = "SURE";
            fieldSURE.Name = "fieldSURE";
            fieldSURE.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 27;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTOPLAM_FIYAT.AreaIndex = 28;
            fieldTOPLAM_FIYAT.FieldName = "TOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Name = "fieldTOPLAM_FIYAT";
            fieldTOPLAM_FIYAT.Visible = true;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 29;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldTOPLAM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_FIYAT_DOVIZ_ID.AreaIndex = 30;
            fieldTOPLAM_FIYAT_DOVIZ_ID.FieldName = "TOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Name = "fieldTOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldSOZLESME_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_KATEGORI.AreaIndex = 31;
            fieldSOZLESME_KATEGORI.FieldName = "SOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Name = "fieldSOZLESME_KATEGORI";
            fieldSOZLESME_KATEGORI.Visible = false;

            PivotGridField fieldMADDE_KALEM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMADDE_KALEM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMADDE_KALEM.AreaIndex = 32;
            fieldMADDE_KALEM.FieldName = "MADDE_KALEM";
            fieldMADDE_KALEM.Name = "fieldMADDE_KALEM";
            fieldMADDE_KALEM.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldBASLANGIC_ZAMANI,
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,
			fieldKAPAMA_TARIHI,
			fieldPLANLAMA_TARIHI,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldIS_ONCELIK,
			fieldID,
			fieldIS_ID,
			fieldBITIS_ZAMANI,
			fieldSORUMLU,
			fieldIS_SUREC,
			fieldSUREC_ACIKLAMA,
			fieldMUHASEBELESTILMIS_MI,
			fieldSURE,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_FIYAT,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldTOPLAM_FIYAT_DOVIZ_ID,
			fieldSOZLESME_KATEGORI,
			fieldMADDE_KALEM,
			};

            #endregion []

            return dizi;
        }
    }
}