using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class RaporIcraDavaBirlesik
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

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 0;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 1;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 2;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 3;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colTALEP_ADI = new GridColumn();
            colTALEP_ADI.VisibleIndex = 4;
            colTALEP_ADI.FieldName = "TALEP_ADI";
            colTALEP_ADI.Name = "colTALEP_ADI";
            colTALEP_ADI.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 5;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 6;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 7;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 8;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colAdliye = new GridColumn();
            colAdliye.VisibleIndex = 9;
            colAdliye.FieldName = "Adliye";
            colAdliye.Name = "colAdliye";
            colAdliye.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 10;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colNo = new GridColumn();
            colNo.VisibleIndex = 11;
            colNo.FieldName = "No";
            colNo.Name = "colNo";
            colNo.Visible = true;

            GridColumn colTAKIBIN_AVUKATA_INTIKAL_TARIHI = new GridColumn();
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 12;
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "colTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 13;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 14;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 15;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 16;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 17;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colREFERANS_NO2 = new GridColumn();
            colREFERANS_NO2.VisibleIndex = 18;
            colREFERANS_NO2.FieldName = "REFERANS_NO2";
            colREFERANS_NO2.Name = "colREFERANS_NO2";
            colREFERANS_NO2.Visible = true;

            GridColumn colREFERANS_NO3 = new GridColumn();
            colREFERANS_NO3.VisibleIndex = 19;
            colREFERANS_NO3.FieldName = "REFERANS_NO3";
            colREFERANS_NO3.Name = "colREFERANS_NO3";
            colREFERANS_NO3.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 20;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colTAKIP_EDILEN,
			colTAKIP_EDEN,
			colIZLEYEN,
			colSORUMLU,
			colTALEP_ADI,
			colFOY_NO,
			colESAS_NO,
			colDURUM,
			colTAKIP_TARIHI,
			colAdliye,
			colGOREV,
			colNo,
			colTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			colOZEL_KOD1,
			colOZEL_KOD2,
			colOZEL_KOD3,
			colOZEL_KOD4,
			colREFERANS_NO,
			colREFERANS_NO2,
			colREFERANS_NO3,
			colBOLUM,
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

            PivotGridField fieldTAKIP_EDILEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN.AreaIndex = 0;
            fieldTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            fieldTAKIP_EDILEN.Name = "fieldTAKIP_EDILEN";
            fieldTAKIP_EDILEN.Visible = false;

            PivotGridField fieldTAKIP_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN.AreaIndex = 1;
            fieldTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            fieldTAKIP_EDEN.Name = "fieldTAKIP_EDEN";
            fieldTAKIP_EDEN.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 2;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 3;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 4;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 5;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 6;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 7;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldAdliye = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAdliye.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAdliye.AreaIndex = 9;
            fieldAdliye.FieldName = "Adliye";
            fieldAdliye.Name = "fieldAdliye";
            fieldAdliye.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 10;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNo = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNo.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNo.AreaIndex = 11;
            fieldNo.FieldName = "No";
            fieldNo.Name = "fieldNo";
            fieldNo.Visible = false;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 12;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldOZEL_KOD1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD1.AreaIndex = 13;
            fieldOZEL_KOD1.FieldName = "OZEL_KOD1";
            fieldOZEL_KOD1.Name = "fieldOZEL_KOD1";
            fieldOZEL_KOD1.Visible = false;

            PivotGridField fieldOZEL_KOD2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD2.AreaIndex = 14;
            fieldOZEL_KOD2.FieldName = "OZEL_KOD2";
            fieldOZEL_KOD2.Name = "fieldOZEL_KOD2";
            fieldOZEL_KOD2.Visible = false;

            PivotGridField fieldOZEL_KOD3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD3.AreaIndex = 15;
            fieldOZEL_KOD3.FieldName = "OZEL_KOD3";
            fieldOZEL_KOD3.Name = "fieldOZEL_KOD3";
            fieldOZEL_KOD3.Visible = false;

            PivotGridField fieldOZEL_KOD4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD4.AreaIndex = 16;
            fieldOZEL_KOD4.FieldName = "OZEL_KOD4";
            fieldOZEL_KOD4.Name = "fieldOZEL_KOD4";
            fieldOZEL_KOD4.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 17;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldREFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO2.AreaIndex = 18;
            fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
            fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";
            fieldREFERANS_NO2.Visible = false;

            PivotGridField fieldREFERANS_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO3.AreaIndex = 19;
            fieldREFERANS_NO3.FieldName = "REFERANS_NO3";
            fieldREFERANS_NO3.Name = "fieldREFERANS_NO3";
            fieldREFERANS_NO3.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 20;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldTAKIP_EDILEN,
			fieldTAKIP_EDEN,
			fieldIZLEYEN,
			fieldSORUMLU,
			fieldTALEP_ADI,
			fieldFOY_NO,
			fieldESAS_NO,
			fieldDURUM,
			fieldTAKIP_TARIHI,
			fieldAdliye,
			fieldGOREV,
			fieldNo,
			fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			fieldOZEL_KOD1,
			fieldOZEL_KOD2,
			fieldOZEL_KOD3,
			fieldOZEL_KOD4,
			fieldREFERANS_NO,
			fieldREFERANS_NO2,
			fieldREFERANS_NO3,
			fieldBOLUM,
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

            dicFieldCaption.Add("TAKIP_EDILEN", "Karşı Taraf");
            dicFieldCaption.Add("TAKIP_EDEN", "Taraf");
            dicFieldCaption.Add("IZLEYEN", "İzleyen");
            dicFieldCaption.Add("SORUMLU", "Sorumlu");
            dicFieldCaption.Add("TALEP_ADI", "Talep");
            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("TAKIP_TARIHI", "Takip T");
            dicFieldCaption.Add("Adliye", "Adliye");
            dicFieldCaption.Add("GOREV", "Gorev");
            dicFieldCaption.Add("No", "No");
            dicFieldCaption.Add("TAKIBIN_AVUKATA_INTIKAL_TARIHI", "İntikal T");
            dicFieldCaption.Add("OZEL_KOD1", "Özel Kod1");
            dicFieldCaption.Add("OZEL_KOD2", "Özel Kod2");
            dicFieldCaption.Add("OZEL_KOD3", "Özel Kod3");
            dicFieldCaption.Add("OZEL_KOD4", "Özel Kod4");
            dicFieldCaption.Add("REFERANS_NO", "Referans No1");
            dicFieldCaption.Add("REFERANS_NO2", "Referans No2");
            dicFieldCaption.Add("REFERANS_NO3", "Referans No3");
            dicFieldCaption.Add("BOLUM", "Bölüm");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            //  RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

            //Inits.DovizTipGetir(rlueDoviz);

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("DovizId", InitsEx.DovizTipGetir);

            #endregion Add item

            return sozluk;
        }
    }
}