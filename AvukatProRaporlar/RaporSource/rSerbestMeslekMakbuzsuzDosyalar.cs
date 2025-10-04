using System.Collections.Generic;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class rSerbestMeslekMakbuzsuzDosyalar
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

            GridColumn colTakip_T = new GridColumn();
            colTakip_T.VisibleIndex = 4;
            colTakip_T.FieldName = "Takip_T";
            colTakip_T.Name = "colTakip_T";
            colTakip_T.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 5;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colDurum = new GridColumn();
            colDurum.VisibleIndex = 6;
            colDurum.FieldName = "Durum";
            colDurum.Name = "colDurum";
            colDurum.Visible = true;

            GridColumn colTaraf_Adi = new GridColumn();
            colTaraf_Adi.VisibleIndex = 7;
            colTaraf_Adi.FieldName = "Taraf_Adi";
            colTaraf_Adi.Name = "colTaraf_Adi";
            colTaraf_Adi.Visible = true;

            GridColumn colK = new GridColumn();
            colK.VisibleIndex = 8;
            colK.FieldName = "K";
            colK.Name = "colK";
            colK.Visible = true;

            GridColumn colSorumlu_Adi = new GridColumn();
            colSorumlu_Adi.VisibleIndex = 9;
            colSorumlu_Adi.FieldName = "Sorumlu_Adi";
            colSorumlu_Adi.Name = "colSorumlu_Adi";
            colSorumlu_Adi.Visible = true;

            GridColumn colSEGMENT = new GridColumn();
            colSEGMENT.VisibleIndex = 10;
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
			colTakip_T,
			colESAS_NO,
			colDurum,
			colTaraf_Adi,
			colK,
			colSorumlu_Adi,
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

            PivotGridField fieldTakip_T = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTakip_T.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTakip_T.AreaIndex = 4;
            fieldTakip_T.FieldName = "Takip_T";
            fieldTakip_T.Name = "fieldTakip_T";
            fieldTakip_T.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 5;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldDurum = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDurum.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDurum.AreaIndex = 6;
            fieldDurum.FieldName = "Durum";
            fieldDurum.Name = "fieldDurum";
            fieldDurum.Visible = false;

            PivotGridField fieldTaraf_Adi = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTaraf_Adi.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTaraf_Adi.AreaIndex = 7;
            fieldTaraf_Adi.FieldName = "Taraf_Adi";
            fieldTaraf_Adi.Name = "fieldTaraf_Adi";
            fieldTaraf_Adi.Visible = false;

            PivotGridField fieldK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldK.AreaIndex = 8;
            fieldK.FieldName = "K";
            fieldK.Name = "fieldK";
            fieldK.Visible = false;

            PivotGridField fieldSorumlu_Adi = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSorumlu_Adi.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSorumlu_Adi.AreaIndex = 9;
            fieldSorumlu_Adi.FieldName = "Sorumlu_Adi";
            fieldSorumlu_Adi.Name = "fieldSorumlu_Adi";
            fieldSorumlu_Adi.Visible = false;

            PivotGridField fieldSEGMENT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSEGMENT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSEGMENT.AreaIndex = 10;
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
			fieldTakip_T,
			fieldESAS_NO,
			fieldDurum,
			fieldTaraf_Adi,
			fieldK,
			fieldSorumlu_Adi,
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
            dicFieldCaption.Add("Takip_T", "Takip T");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("Durum", "Durum");
            dicFieldCaption.Add("Taraf_Adi", "Taraf Adı");
            dicFieldCaption.Add("K", "Taraf Kodu");
            dicFieldCaption.Add("Sorumlu_Adi", " Sorumlu");
            dicFieldCaption.Add("SEGMENT", "Bölüm");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            //RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

            //Inits.DovizTipGetir(rlueDoviz);

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            //sozluk.Add("DovizId", rlueDoviz);

            #endregion Add item

            return sozluk;
        }
    }
}