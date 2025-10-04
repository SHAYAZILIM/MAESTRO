using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class RaporYapilacakIsler
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

            GridColumn colALT_KATEGORI = new GridColumn();
            colALT_KATEGORI.VisibleIndex = 0;
            colALT_KATEGORI.FieldName = "ALT_KATEGORI";
            colALT_KATEGORI.Name = "colALT_KATEGORI";
            colALT_KATEGORI.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 1;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 2;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 3;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colAD = new GridColumn();
            colAD.VisibleIndex = 4;
            colAD.FieldName = "AD";
            colAD.Name = "colAD";
            colAD.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 5;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colTIP = new GridColumn();
            colTIP.VisibleIndex = 6;
            colTIP.FieldName = "TIP";
            colTIP.Name = "colTIP";
            colTIP.Visible = true;

            GridColumn colBITIS_TARIHI = new GridColumn();
            colBITIS_TARIHI.VisibleIndex = 7;
            colBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            colBITIS_TARIHI.Name = "colBITIS_TARIHI";
            colBITIS_TARIHI.Visible = true;

            GridColumn colBASLANGIC_TARIHI = new GridColumn();
            colBASLANGIC_TARIHI.VisibleIndex = 8;
            colBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            colBASLANGIC_TARIHI.Name = "colBASLANGIC_TARIHI";
            colBASLANGIC_TARIHI.Visible = true;

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

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 13;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 14;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 15;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 16;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colIS_TARAF_ADI = new GridColumn();
            colIS_TARAF_ADI.VisibleIndex = 17;
            colIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            colIS_TARAF_ADI.Name = "colIS_TARAF_ADI";
            colIS_TARAF_ADI.Visible = true;

            GridColumn colIS_TARAF = new GridColumn();
            colIS_TARAF.VisibleIndex = 18;
            colIS_TARAF.FieldName = "IS_TARAF";
            colIS_TARAF.Name = "colIS_TARAF";
            colIS_TARAF.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 19;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colIS_ONCELIK = new GridColumn();
            colIS_ONCELIK.VisibleIndex = 20;
            colIS_ONCELIK.FieldName = "IS_ONCELIK";
            colIS_ONCELIK.Name = "colIS_ONCELIK";
            colIS_ONCELIK.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colALT_KATEGORI,
			colADLIYE,
			colGOREV,
			colNO,
			colAD,
			colDURUM,

			//colTIP,
			colBITIS_TARIHI,
			colBASLANGIC_TARIHI,
			colONGORULEN_BITIS_TARIHI,
			colONGORULEN_BITIS_ZAMANI,
			colYER,
			colKONU,
			colACIKLAMA,
			colESAS_NO,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
			colIS_TARAF_ADI,
			colIS_TARAF,

			//colID,
			colIS_ONCELIK,
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

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALT_KATEGORI.AreaIndex = 0;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 1;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 2;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 3;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 4;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 5;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldTIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTIP.AreaIndex = 6;
            fieldTIP.FieldName = "TIP";
            fieldTIP.Name = "fieldTIP";
            fieldTIP.Visible = false;

            PivotGridField fieldBITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_TARIHI.AreaIndex = 7;
            fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
            fieldBITIS_TARIHI.Visible = false;

            PivotGridField fieldBASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASLANGIC_TARIHI.AreaIndex = 8;
            fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Visible = false;

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

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 13;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 14;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 15;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 16;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_TARAF_ADI.AreaIndex = 17;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = false;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_TARAF.AreaIndex = 18;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 20;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = null;
            switch (pencere)
            {
                case "Adliyesine Göre İşler":
                    dizi = AdliyesineGoreIsler();
                    break;

                case "Yerine Göre İşler":
                    dizi = YerineeGoreIsler();
                    break;

                case "Kategorisine Göre İşler":
                    dizi = KategorisineGoreIsler();
                    break;

                case "Yılına Göre İşler":
                    dizi = YilineGoreIsler();
                    break;

                case "Ayına Göre İşler":
                    dizi = AyinaGoreIsler();
                    break;

                case "Tarihine Göre İşler(Haftalık vs.)":
                    dizi = TarihineGoreIsler();
                    break;

                case "Gününe Göre İşler":
                    dizi = GununeGoreISler();
                    break;

                case "Müvekkile Göre İşler":
                    dizi = MuvekkilineGoreIsler();
                    break;
            }

            #region []

            if (dizi == null)
            {
                dizi = new PivotGridField[]
		{
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,

			//fieldTIP,
			fieldBITIS_TARIHI,
			fieldBASLANGIC_TARIHI,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldACIKLAMA,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldID,
			fieldIS_ONCELIK,
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

        private PivotGridField[] AdliyesineGoreIsler()
        {
            #region Field & Properties

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldADLIYE.AreaIndex = 0;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = true;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 2;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 3;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 4;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 5;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldTIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTIP.AreaIndex = 6;
            fieldTIP.FieldName = "TIP";
            fieldTIP.Name = "fieldTIP";
            fieldTIP.Visible = false;

            PivotGridField fieldBITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_TARIHI.AreaIndex = 7;
            fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
            fieldBITIS_TARIHI.Visible = false;

            PivotGridField fieldBASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBASLANGIC_TARIHI.AreaIndex = 9;
            fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Visible = true;

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

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 13;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 14;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 15;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 16;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF_ADI.AreaIndex = 8;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = true;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF.AreaIndex = 18;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 20;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,

			//fieldTIP,
			fieldBITIS_TARIHI,
			fieldBASLANGIC_TARIHI,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldACIKLAMA,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldID,
			fieldIS_ONCELIK,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] AyinaGoreIsler()
        {
            #region Field & Properties

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldADLIYE.AreaIndex = 0;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 2;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 3;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 4;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 5;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldTIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTIP.AreaIndex = 6;
            fieldTIP.FieldName = "TIP";
            fieldTIP.Name = "fieldTIP";
            fieldTIP.Visible = false;

            PivotGridField fieldBITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_TARIHI.AreaIndex = 7;
            fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
            fieldBITIS_TARIHI.Visible = false;

            PivotGridField fieldBASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBASLANGIC_TARIHI.GroupInterval = PivotGroupInterval.DateYear;
            fieldBASLANGIC_TARIHI.AreaIndex = 9;
            fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Visible = true;

            PivotGridField fieldBASLANGIC_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBASLANGIC_TARIHI2.GroupInterval = PivotGroupInterval.DateMonth;
            fieldBASLANGIC_TARIHI2.AreaIndex = 10;
            fieldBASLANGIC_TARIHI2.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI2.Name = "fieldBASLANGIC_TARIHI2";
            fieldBASLANGIC_TARIHI2.Visible = true;

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
            fieldYER.AreaIndex = 0;
            fieldYER.FieldName = "YER";
            fieldYER.Name = "fieldYER";
            fieldYER.Visible = false;

            PivotGridField fieldKONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONU.AreaIndex = 12;
            fieldKONU.FieldName = "KONU";
            fieldKONU.Name = "fieldKONU";
            fieldKONU.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 13;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 14;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 15;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 16;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF_ADI.AreaIndex = 8;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = true;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF.AreaIndex = 18;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 20;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,

			//fieldTIP,
			fieldBITIS_TARIHI,
			fieldBASLANGIC_TARIHI,
            fieldBASLANGIC_TARIHI2,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldACIKLAMA,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldID,
			fieldIS_ONCELIK,
			};

            #endregion []

            return dizi;
        }

        private Dictionary<string, string> GetCaptionDictinory()
        {
            Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

            #region Caption Edit

            dicFieldCaption.Add("ALT_KATEGORI", "Kategori");
            dicFieldCaption.Add("ADLIYE", "Adliye");
            dicFieldCaption.Add("GOREV", "Görev");
            dicFieldCaption.Add("NO", "No");
            dicFieldCaption.Add("AD", "Modul");
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("TIP", "Tip");
            dicFieldCaption.Add("BITIS_TARIHI", "Kapama T");
            dicFieldCaption.Add("BASLANGIC_TARIHI", "Planlama T");
            dicFieldCaption.Add("ONGORULEN_BITIS_TARIHI", "Öngörülen Bitiş T");
            dicFieldCaption.Add("ONGORULEN_BITIS_ZAMANI", "Öngörülen Bitiş Zmn");
            dicFieldCaption.Add("YER", "Yer");
            dicFieldCaption.Add("KONU", "Konu");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("IS_TARAF_ADI", "İş Taraf");
            dicFieldCaption.Add("IS_TARAF", "T.K");
            dicFieldCaption.Add("ID", "Dosya Sayısı");
            dicFieldCaption.Add("IS_ONCELIK", "İş Öncelik");

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

        private PivotGridField[] GununeGoreISler()
        {
            #region Field & Properties

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldADLIYE.AreaIndex = 0;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 2;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 3;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 4;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 5;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldTIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTIP.AreaIndex = 6;
            fieldTIP.FieldName = "TIP";
            fieldTIP.Name = "fieldTIP";
            fieldTIP.Visible = false;

            PivotGridField fieldBITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_TARIHI.AreaIndex = 7;
            fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
            fieldBITIS_TARIHI.Visible = false;

            PivotGridField fieldBASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBASLANGIC_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldBASLANGIC_TARIHI.AreaIndex = 9;
            fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Visible = true;

            PivotGridField fieldBASLANGIC_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBASLANGIC_TARIHI2.GroupInterval = PivotGroupInterval.DateDay;
            fieldBASLANGIC_TARIHI2.AreaIndex = 10;
            fieldBASLANGIC_TARIHI2.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI2.Name = "fieldBASLANGIC_TARIHI2";
            fieldBASLANGIC_TARIHI2.Visible = true;

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
            fieldYER.AreaIndex = 0;
            fieldYER.FieldName = "YER";
            fieldYER.Name = "fieldYER";
            fieldYER.Visible = false;

            PivotGridField fieldKONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONU.AreaIndex = 12;
            fieldKONU.FieldName = "KONU";
            fieldKONU.Name = "fieldKONU";
            fieldKONU.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 13;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 14;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 15;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 16;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF_ADI.AreaIndex = 8;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = true;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF.AreaIndex = 18;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 20;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,

			//fieldTIP,
			fieldBITIS_TARIHI,
			fieldBASLANGIC_TARIHI,
            fieldBASLANGIC_TARIHI2,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldACIKLAMA,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldID,
			fieldIS_ONCELIK,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] KategorisineGoreIsler()
        {
            #region Field & Properties

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldADLIYE.AreaIndex = 0;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 2;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 3;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 4;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 5;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldTIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTIP.AreaIndex = 6;
            fieldTIP.FieldName = "TIP";
            fieldTIP.Name = "fieldTIP";
            fieldTIP.Visible = false;

            PivotGridField fieldBITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_TARIHI.AreaIndex = 7;
            fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
            fieldBITIS_TARIHI.Visible = false;

            PivotGridField fieldBASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBASLANGIC_TARIHI.AreaIndex = 9;
            fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Visible = true;

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
            fieldYER.AreaIndex = 0;
            fieldYER.FieldName = "YER";
            fieldYER.Name = "fieldYER";
            fieldYER.Visible = false;

            PivotGridField fieldKONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONU.AreaIndex = 12;
            fieldKONU.FieldName = "KONU";
            fieldKONU.Name = "fieldKONU";
            fieldKONU.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 13;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 14;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 15;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 16;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF_ADI.AreaIndex = 8;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = true;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF.AreaIndex = 18;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 20;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,

			//fieldTIP,
			fieldBITIS_TARIHI,
			fieldBASLANGIC_TARIHI,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldACIKLAMA,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldID,
			fieldIS_ONCELIK,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] MuvekkilineGoreIsler()
        {
            #region Field & Properties

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldADLIYE.AreaIndex = 0;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 2;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 3;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 4;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 5;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldTIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTIP.AreaIndex = 6;
            fieldTIP.FieldName = "TIP";
            fieldTIP.Name = "fieldTIP";
            fieldTIP.Visible = false;

            PivotGridField fieldBITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_TARIHI.AreaIndex = 7;
            fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
            fieldBITIS_TARIHI.Visible = false;

            PivotGridField fieldBASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBASLANGIC_TARIHI.GroupInterval = PivotGroupInterval.DateYear;
            fieldBASLANGIC_TARIHI.AreaIndex = 9;
            fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Visible = true;

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
            fieldYER.AreaIndex = 0;
            fieldYER.FieldName = "YER";
            fieldYER.Name = "fieldYER";
            fieldYER.Visible = false;

            PivotGridField fieldKONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONU.AreaIndex = 12;
            fieldKONU.FieldName = "KONU";
            fieldKONU.Name = "fieldKONU";
            fieldKONU.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 13;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 14;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 15;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 16;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF_ADI.AreaIndex = 8;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = true;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF.AreaIndex = 18;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 20;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,

			//fieldTIP,
			fieldBITIS_TARIHI,
			fieldBASLANGIC_TARIHI,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldACIKLAMA,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldID,
			fieldIS_ONCELIK,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] TarihineGoreIsler()
        {
            #region Field & Properties

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldADLIYE.AreaIndex = 0;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 2;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 3;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 4;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 5;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldTIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTIP.AreaIndex = 6;
            fieldTIP.FieldName = "TIP";
            fieldTIP.Name = "fieldTIP";
            fieldTIP.Visible = false;

            PivotGridField fieldBITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_TARIHI.AreaIndex = 7;
            fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
            fieldBITIS_TARIHI.Visible = false;

            PivotGridField fieldBASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBASLANGIC_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldBASLANGIC_TARIHI.AreaIndex = 9;
            fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Visible = true;

            PivotGridField fieldBASLANGIC_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBASLANGIC_TARIHI2.GroupInterval = PivotGroupInterval.DateWeekOfMonth;
            fieldBASLANGIC_TARIHI2.AreaIndex = 10;
            fieldBASLANGIC_TARIHI2.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI2.Name = "fieldBASLANGIC_TARIHI2";
            fieldBASLANGIC_TARIHI2.Visible = true;

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
            fieldYER.AreaIndex = 0;
            fieldYER.FieldName = "YER";
            fieldYER.Name = "fieldYER";
            fieldYER.Visible = false;

            PivotGridField fieldKONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONU.AreaIndex = 12;
            fieldKONU.FieldName = "KONU";
            fieldKONU.Name = "fieldKONU";
            fieldKONU.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 13;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 14;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 15;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 16;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF_ADI.AreaIndex = 8;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = true;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF.AreaIndex = 18;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 20;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,

			//fieldTIP,
			fieldBITIS_TARIHI,
			fieldBASLANGIC_TARIHI,
            fieldBASLANGIC_TARIHI2,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldACIKLAMA,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldID,
			fieldIS_ONCELIK,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] YerineeGoreIsler()
        {
            #region Field & Properties

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldADLIYE.AreaIndex = 0;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 2;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 3;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 4;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 5;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldTIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTIP.AreaIndex = 6;
            fieldTIP.FieldName = "TIP";
            fieldTIP.Name = "fieldTIP";
            fieldTIP.Visible = false;

            PivotGridField fieldBITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_TARIHI.AreaIndex = 7;
            fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
            fieldBITIS_TARIHI.Visible = false;

            PivotGridField fieldBASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBASLANGIC_TARIHI.AreaIndex = 9;
            fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Visible = true;

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
            fieldYER.AreaIndex = 0;
            fieldYER.FieldName = "YER";
            fieldYER.Name = "fieldYER";
            fieldYER.Visible = true;

            PivotGridField fieldKONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONU.AreaIndex = 12;
            fieldKONU.FieldName = "KONU";
            fieldKONU.Name = "fieldKONU";
            fieldKONU.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 13;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 14;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 15;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 16;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF_ADI.AreaIndex = 8;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = true;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF.AreaIndex = 18;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 20;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,

			//fieldTIP,
			fieldBITIS_TARIHI,
			fieldBASLANGIC_TARIHI,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldACIKLAMA,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldID,
			fieldIS_ONCELIK,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] YilineGoreIsler()
        {
            #region Field & Properties

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 1;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldADLIYE.AreaIndex = 0;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 2;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 3;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 4;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 5;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldTIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTIP.AreaIndex = 6;
            fieldTIP.FieldName = "TIP";
            fieldTIP.Name = "fieldTIP";
            fieldTIP.Visible = false;

            PivotGridField fieldBITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_TARIHI.AreaIndex = 7;
            fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
            fieldBITIS_TARIHI.Visible = false;

            PivotGridField fieldBASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBASLANGIC_TARIHI.GroupInterval = PivotGroupInterval.DateYear;
            fieldBASLANGIC_TARIHI.AreaIndex = 9;
            fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Visible = true;

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
            fieldYER.AreaIndex = 0;
            fieldYER.FieldName = "YER";
            fieldYER.Name = "fieldYER";
            fieldYER.Visible = false;

            PivotGridField fieldKONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONU.AreaIndex = 12;
            fieldKONU.FieldName = "KONU";
            fieldKONU.Name = "fieldKONU";
            fieldKONU.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 13;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 14;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 15;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 16;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldIS_TARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF_ADI.AreaIndex = 8;
            fieldIS_TARAF_ADI.FieldName = "IS_TARAF_ADI";
            fieldIS_TARAF_ADI.Name = "fieldIS_TARAF_ADI";
            fieldIS_TARAF_ADI.Visible = true;

            PivotGridField fieldIS_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldIS_TARAF.AreaIndex = 18;
            fieldIS_TARAF.FieldName = "IS_TARAF";
            fieldIS_TARAF.Name = "fieldIS_TARAF";
            fieldIS_TARAF.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIS_ONCELIK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIS_ONCELIK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIS_ONCELIK.AreaIndex = 20;
            fieldIS_ONCELIK.FieldName = "IS_ONCELIK";
            fieldIS_ONCELIK.Name = "fieldIS_ONCELIK";
            fieldIS_ONCELIK.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldALT_KATEGORI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldAD,
			fieldDURUM,

			//fieldTIP,
			fieldBITIS_TARIHI,
			fieldBASLANGIC_TARIHI,
			fieldONGORULEN_BITIS_TARIHI,
			fieldONGORULEN_BITIS_ZAMANI,
			fieldYER,
			fieldKONU,
			fieldACIKLAMA,
			fieldESAS_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldIS_TARAF_ADI,
			fieldIS_TARAF,
			fieldID,
			fieldIS_ONCELIK,
			};

            #endregion []

            return dizi;
        }
    }
}