using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class rSerbestMeslekMakbuzsuzIcraDosyalari
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

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 4;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

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

            GridColumn colOzel_Kod1 = new GridColumn();
            colOzel_Kod1.VisibleIndex = 9;
            colOzel_Kod1.FieldName = "Ozel_Kod1";
            colOzel_Kod1.Name = "colOzel_Kod1";
            colOzel_Kod1.Visible = true;

            GridColumn colOzel_Kod2 = new GridColumn();
            colOzel_Kod2.VisibleIndex = 10;
            colOzel_Kod2.FieldName = "Ozel_Kod2";
            colOzel_Kod2.Name = "colOzel_Kod2";
            colOzel_Kod2.Visible = true;

            GridColumn colOzel_Kod3 = new GridColumn();
            colOzel_Kod3.VisibleIndex = 11;
            colOzel_Kod3.FieldName = "Ozel_Kod3";
            colOzel_Kod3.Name = "colOzel_Kod3";
            colOzel_Kod3.Visible = true;

            GridColumn colOzel_Kod4 = new GridColumn();
            colOzel_Kod4.VisibleIndex = 12;
            colOzel_Kod4.FieldName = "Ozel_Kod4";
            colOzel_Kod4.Name = "colOzel_Kod4";
            colOzel_Kod4.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 13;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = false;

            GridColumn colTakip_Konusu = new GridColumn();
            colTakip_Konusu.VisibleIndex = 14;
            colTakip_Konusu.FieldName = "Takip_Konusu";
            colTakip_Konusu.Name = "colTakip_Konusu";
            colTakip_Konusu.Visible = true;

            GridColumn colDurum = new GridColumn();
            colDurum.VisibleIndex = 15;
            colDurum.FieldName = "Durum";
            colDurum.Name = "colDurum";
            colDurum.Visible = true;

            GridColumn colK = new GridColumn();
            colK.VisibleIndex = 16;
            colK.FieldName = "K";
            colK.Name = "colK";
            colK.Visible = true;

            GridColumn colTaraf_Adi = new GridColumn();
            colTaraf_Adi.VisibleIndex = 17;
            colTaraf_Adi.FieldName = "Taraf_Adi";
            colTaraf_Adi.Name = "colTaraf_Adi";
            colTaraf_Adi.Visible = true;

            GridColumn colSifat = new GridColumn();
            colSifat.VisibleIndex = 18;
            colSifat.FieldName = "Sifat";
            colSifat.Name = "colSifat";
            colSifat.Visible = true;

            GridColumn colSorumlu_Adi = new GridColumn();
            colSorumlu_Adi.VisibleIndex = 19;
            colSorumlu_Adi.FieldName = "Sorumlu_Adi";
            colSorumlu_Adi.Name = "colSorumlu_Adi";
            colSorumlu_Adi.Visible = true;

            GridColumn colTipi = new GridColumn();
            colTipi.VisibleIndex = 20;
            colTipi.FieldName = "Tipi";
            colTipi.Name = "colTipi";
            colTipi.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 21;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colKAYIT_TARIHI = new GridColumn();
            colKAYIT_TARIHI.VisibleIndex = 22;
            colKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
            colKAYIT_TARIHI.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 23;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 24;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colSEGMENT = new GridColumn();
            colSEGMENT.VisibleIndex = 25;
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
			colESAS_NO,
			colTakip_T,
			colReferans1,
			colReferans2,
			colReferans3,
			colOzel_Kod1,
			colOzel_Kod2,
			colOzel_Kod3,
			colOzel_Kod4,
			colACIKLAMA,
			colTakip_Konusu,
			colDurum,
			colK,
			colTaraf_Adi,
			colSifat,
			colSorumlu_Adi,
			colTipi,
			colID,

            //colKAYIT_TARIHI,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
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

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 4;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

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

            PivotGridField fieldOzel_Kod1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzel_Kod1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzel_Kod1.AreaIndex = 9;
            fieldOzel_Kod1.FieldName = "Ozel_Kod1";
            fieldOzel_Kod1.Name = "fieldOzel_Kod1";
            fieldOzel_Kod1.Visible = false;

            PivotGridField fieldOzel_Kod2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzel_Kod2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzel_Kod2.AreaIndex = 10;
            fieldOzel_Kod2.FieldName = "Ozel_Kod2";
            fieldOzel_Kod2.Name = "fieldOzel_Kod2";
            fieldOzel_Kod2.Visible = false;

            PivotGridField fieldOzel_Kod3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzel_Kod3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzel_Kod3.AreaIndex = 11;
            fieldOzel_Kod3.FieldName = "Ozel_Kod3";
            fieldOzel_Kod3.Name = "fieldOzel_Kod3";
            fieldOzel_Kod3.Visible = false;

            PivotGridField fieldOzel_Kod4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzel_Kod4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzel_Kod4.AreaIndex = 12;
            fieldOzel_Kod4.FieldName = "Ozel_Kod4";
            fieldOzel_Kod4.Name = "fieldOzel_Kod4";
            fieldOzel_Kod4.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 13;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldTakip_Konusu = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTakip_Konusu.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTakip_Konusu.AreaIndex = 14;
            fieldTakip_Konusu.FieldName = "Takip_Konusu";
            fieldTakip_Konusu.Name = "fieldTakip_Konusu";
            fieldTakip_Konusu.Visible = false;

            PivotGridField fieldDurum = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDurum.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDurum.AreaIndex = 15;
            fieldDurum.FieldName = "Durum";
            fieldDurum.Name = "fieldDurum";
            fieldDurum.Visible = false;

            PivotGridField fieldK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldK.AreaIndex = 16;
            fieldK.FieldName = "K";
            fieldK.Name = "fieldK";
            fieldK.Visible = false;

            PivotGridField fieldTaraf_Adi = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTaraf_Adi.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTaraf_Adi.AreaIndex = 17;
            fieldTaraf_Adi.FieldName = "Taraf_Adi";
            fieldTaraf_Adi.Name = "fieldTaraf_Adi";
            fieldTaraf_Adi.Visible = false;

            PivotGridField fieldSifat = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSifat.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSifat.AreaIndex = 18;
            fieldSifat.FieldName = "Sifat";
            fieldSifat.Name = "fieldSifat";
            fieldSifat.Visible = false;

            PivotGridField fieldSorumlu_Adi = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSorumlu_Adi.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSorumlu_Adi.AreaIndex = 19;
            fieldSorumlu_Adi.FieldName = "Sorumlu_Adi";
            fieldSorumlu_Adi.Name = "fieldSorumlu_Adi";
            fieldSorumlu_Adi.Visible = false;

            PivotGridField fieldTipi = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTipi.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTipi.AreaIndex = 20;
            fieldTipi.FieldName = "Tipi";
            fieldTipi.Name = "fieldTipi";
            fieldTipi.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 21;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldKAYIT_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAYIT_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAYIT_TARIHI.AreaIndex = 22;
            fieldKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            fieldKAYIT_TARIHI.Name = "fieldKAYIT_TARIHI";
            fieldKAYIT_TARIHI.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 23;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 24;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldSEGMENT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSEGMENT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSEGMENT.AreaIndex = 25;
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
			fieldESAS_NO,
			fieldTakip_T,
			fieldReferans1,
			fieldReferans2,
			fieldReferans3,
			fieldOzel_Kod1,
			fieldOzel_Kod2,
			fieldOzel_Kod3,
			fieldOzel_Kod4,
			fieldACIKLAMA,
			fieldTakip_Konusu,
			fieldDurum,
			fieldK,
			fieldTaraf_Adi,
			fieldSifat,
			fieldSorumlu_Adi,
			fieldTipi,
			fieldID,

			//fieldKAYIT_TARIHI,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
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
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("Takip_T", "Takip T");
            dicFieldCaption.Add("Referans1", "Ref 1");
            dicFieldCaption.Add("Referans2", "Ref 2");
            dicFieldCaption.Add("Referans3", "Ref 3");
            dicFieldCaption.Add("Ozel_Kod1", "Özel Kod1");
            dicFieldCaption.Add("Ozel_Kod2", "Özel Kod2");
            dicFieldCaption.Add("Ozel_Kod3", "Özel Kod3");
            dicFieldCaption.Add("Ozel_Kod4", "Özel Kod4");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("Takip_Konusu", "Takip Konusu");
            dicFieldCaption.Add("Durum", "Durum");
            dicFieldCaption.Add("K", "Taraf Kodu");
            dicFieldCaption.Add("Taraf_Adi", "Taraf Adı");
            dicFieldCaption.Add("Sifat", "Sıfat");
            dicFieldCaption.Add("Sorumlu_Adi", "Sorumlu");
            dicFieldCaption.Add("Tipi", "Tipi");
            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("KAYIT_TARIHI", "");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
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

            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);

            #endregion Add item

            return sozluk;
        }
    }
}