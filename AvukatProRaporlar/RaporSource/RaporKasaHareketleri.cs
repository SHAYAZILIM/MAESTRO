using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class RaporKasaHareketleri
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

        public GridColumn[] GetGridColumns(string pencere)
        {
            #region Field & Properties

            GridColumn colHARAKET_CARI = new GridColumn();
            colHARAKET_CARI.VisibleIndex = 0;
            colHARAKET_CARI.FieldName = "HARAKET_CARI";
            colHARAKET_CARI.Name = "colHARAKET_CARI";
            colHARAKET_CARI.Visible = true;

            GridColumn colBORC_ALACAK = new GridColumn();
            colBORC_ALACAK.VisibleIndex = 1;
            colBORC_ALACAK.FieldName = "BORC_ALACAK";
            colBORC_ALACAK.Name = "colBORC_ALACAK";
            colBORC_ALACAK.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 2;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colBELGE_NO = new GridColumn();
            colBELGE_NO.VisibleIndex = 3;
            colBELGE_NO.FieldName = "BELGE_NO";
            colBELGE_NO.Name = "colBELGE_NO";
            colBELGE_NO.Visible = true;

            GridColumn colODEME_TIP = new GridColumn();
            colODEME_TIP.VisibleIndex = 4;
            colODEME_TIP.FieldName = "ODEME_TIP";
            colODEME_TIP.Name = "colODEME_TIP";
            colODEME_TIP.Visible = true;

            GridColumn colTARIH = new GridColumn();
            colTARIH.VisibleIndex = 5;
            colTARIH.FieldName = "TARIH";
            colTARIH.Name = "colTARIH";
            colTARIH.Visible = true;

            GridColumn colANA_KATEGORI = new GridColumn();
            colANA_KATEGORI.VisibleIndex = 6;
            colANA_KATEGORI.FieldName = "ANA_KATEGORI";
            colANA_KATEGORI.Name = "colANA_KATEGORI";
            colANA_KATEGORI.Visible = true;

            GridColumn colADET = new GridColumn();
            colADET.VisibleIndex = 7;
            colADET.FieldName = "ADET";
            colADET.Name = "colADET";
            colADET.Visible = true;

            GridColumn colBIRIM_FIYAT = new GridColumn();
            colBIRIM_FIYAT.VisibleIndex = 8;
            colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
            colBIRIM_FIYAT.Visible = true;

            GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
            colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 9;
            colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Visible = true;

            GridColumn colGENEL_TOPLAM = new GridColumn();
            colGENEL_TOPLAM.VisibleIndex = 10;
            colGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
            colGENEL_TOPLAM.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 11;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 12;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 13;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            #endregion Field & Properties

            GridColumn[] dizi = null;
            switch (pencere)
            {
                case "Kasa Hareketleri (Kategorilere Göre)":
                    dizi = null;
                    break;

                case "Kasa (Günlük-Kategorilere Göre)":
                    dizi = KasaHareketleriGunlukKategorilereGore();
                    break;

                case "Kasa (Haftalık-Kategorilere Göre)":
                    dizi = KasaHareketleriHaftalikKategorilereGore();
                    break;

                case "Kasa (Aylık-Kategorilere)":
                    dizi = KasaHareketleriAylikKategorilereGore();
                    break;

                case "Kasa (Yıllık-Kategorilere Göre":
                    dizi = KasaHareketleriYillikKategorilereGore();
                    break;
            }

            #region []

            if (dizi == null)
            {
                dizi = new GridColumn[]
		{
			colHARAKET_CARI,
			colBORC_ALACAK,
			colREFERANS_NO,
			colBELGE_NO,
			colODEME_TIP,
			colTARIH,
			colANA_KATEGORI,
			colADET,
			colBIRIM_FIYAT,
			colBIRIM_FIYAT_DOVIZ_ID,
			colGENEL_TOPLAM,
			colACIKLAMA,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
			};
            }

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

            PivotGridField fieldHARAKET_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHARAKET_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHARAKET_CARI.AreaIndex = 0;
            fieldHARAKET_CARI.FieldName = "HARAKET_CARI";
            fieldHARAKET_CARI.Name = "fieldHARAKET_CARI";
            fieldHARAKET_CARI.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 1;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 2;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldBELGE_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBELGE_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBELGE_NO.AreaIndex = 3;
            fieldBELGE_NO.FieldName = "BELGE_NO";
            fieldBELGE_NO.Name = "fieldBELGE_NO";
            fieldBELGE_NO.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 13;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;
            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 4;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 5;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldANA_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldANA_KATEGORI.AreaIndex = 6;
            fieldANA_KATEGORI.FieldName = "ANA_KATEGORI";
            fieldANA_KATEGORI.Name = "fieldANA_KATEGORI";
            fieldANA_KATEGORI.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 7;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 8;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 9;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldGENEL_TOPLAM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGENEL_TOPLAM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGENEL_TOPLAM.AreaIndex = 10;
            fieldGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            fieldGENEL_TOPLAM.Name = "fieldGENEL_TOPLAM";
            fieldGENEL_TOPLAM.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 11;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 12;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 13;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = null;
            switch (pencere)
            {
                case "Kasa (Günlük-Kategorilere Göre)":
                    dizi = KasaGunlukKategorilereGore();
                    break;

                case "Kasa (Haftalık-Kategorilere Göre)":
                    dizi = KasaGunlukHaftalikKategorilereGore();
                    break;

                case "Kasa (Aylık-Kategorilere)":
                    dizi = KasaGunlukAylikKategorilereGore();
                    break;

                case "Kasa (Yıllık-Kategorilere Göre":
                    dizi = KasaGunlukYillikKategorilereGore();
                    break;
            }

            #region []

            if (dizi == null)
            {
                dizi = new PivotGridField[]
		{
            fieldID,
			fieldHARAKET_CARI,
			fieldBORC_ALACAK,
			fieldREFERANS_NO,
			fieldBELGE_NO,
			fieldODEME_TIP,
			fieldTARIH,
			fieldANA_KATEGORI,
			fieldADET,
			fieldBIRIM_FIYAT,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldGENEL_TOPLAM,
			fieldACIKLAMA,
			fieldKONTROL_KIM_ID,
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

            dicFieldCaption.Add("HARAKET_CARI", "Şahış");
            dicFieldCaption.Add("BORC_ALACAK", "B/A");
            dicFieldCaption.Add("REFERANS_NO", "Referans No");
            dicFieldCaption.Add("BELGE_NO", "Belge No");
            dicFieldCaption.Add("ODEME_TIP", "Ödeme Tip");
            dicFieldCaption.Add("TARIH", "Tarih");
            dicFieldCaption.Add("ANA_KATEGORI", "Kategori");
            dicFieldCaption.Add("ADET", "Adet");
            dicFieldCaption.Add("BIRIM_FIYAT", "Birim Fiyat");
            dicFieldCaption.Add("GENEL_TOPLAM", "Genel Toplam");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("ID", "Dosya Sayısı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");

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

        private PivotGridField[] KasaGunlukAylikKategorilereGore()
        {
            #region Field & Properties

            PivotGridField fieldHARAKET_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHARAKET_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldHARAKET_CARI.AreaIndex = 0;
            fieldHARAKET_CARI.FieldName = "HARAKET_CARI";
            fieldHARAKET_CARI.Name = "fieldHARAKET_CARI";
            fieldHARAKET_CARI.Visible = true;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 1;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 2;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldBELGE_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBELGE_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBELGE_NO.AreaIndex = 3;
            fieldBELGE_NO.FieldName = "BELGE_NO";
            fieldBELGE_NO.Name = "fieldBELGE_NO";
            fieldBELGE_NO.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 13;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;
            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 4;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTARIH.AreaIndex = 5;
            fieldTARIH.GroupInterval = PivotGroupInterval.DateYear;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = true;

            PivotGridField fieldTARIH2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTARIH2.AreaIndex = 5;
            fieldTARIH2.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTARIH2.FieldName = "TARIH";
            fieldTARIH2.Name = "fieldTARIH2";
            fieldTARIH2.Visible = true;

            PivotGridField fieldANA_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldANA_KATEGORI.AreaIndex = 6;
            fieldANA_KATEGORI.FieldName = "ANA_KATEGORI";
            fieldANA_KATEGORI.Name = "fieldANA_KATEGORI";
            fieldANA_KATEGORI.Visible = true;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 7;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldBIRIM_FIYAT.AreaIndex = 8;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = true;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 9;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldGENEL_TOPLAM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGENEL_TOPLAM.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldGENEL_TOPLAM.AreaIndex = 10;
            fieldGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            fieldGENEL_TOPLAM.Name = "fieldGENEL_TOPLAM";
            fieldGENEL_TOPLAM.Visible = true;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 11;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 12;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 13;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
            fieldID,
			fieldHARAKET_CARI,
			fieldBORC_ALACAK,
			fieldREFERANS_NO,
			fieldBELGE_NO,
			fieldODEME_TIP,
			fieldTARIH,
            fieldTARIH2,
			fieldANA_KATEGORI,
			fieldADET,
			fieldBIRIM_FIYAT,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldGENEL_TOPLAM,
			fieldACIKLAMA,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			};
            return dizi;
        }

        private PivotGridField[] KasaGunlukHaftalikKategorilereGore()
        {
            #region Field & Properties

            PivotGridField fieldHARAKET_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHARAKET_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldHARAKET_CARI.AreaIndex = 0;
            fieldHARAKET_CARI.FieldName = "HARAKET_CARI";
            fieldHARAKET_CARI.Name = "fieldHARAKET_CARI";
            fieldHARAKET_CARI.Visible = true;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 1;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 2;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldBELGE_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBELGE_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBELGE_NO.AreaIndex = 3;
            fieldBELGE_NO.FieldName = "BELGE_NO";
            fieldBELGE_NO.Name = "fieldBELGE_NO";
            fieldBELGE_NO.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 13;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;
            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 4;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTARIH.AreaIndex = 5;
            fieldTARIH.GroupInterval = PivotGroupInterval.DateWeekOfMonth;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = true;

            PivotGridField fieldTARIH2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTARIH2.AreaIndex = 5;
            fieldTARIH2.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTARIH2.FieldName = "TARIH";
            fieldTARIH2.Name = "fieldTARIH2";
            fieldTARIH2.Visible = true;

            PivotGridField fieldANA_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldANA_KATEGORI.AreaIndex = 6;
            fieldANA_KATEGORI.FieldName = "ANA_KATEGORI";
            fieldANA_KATEGORI.Name = "fieldANA_KATEGORI";
            fieldANA_KATEGORI.Visible = true;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 7;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldBIRIM_FIYAT.AreaIndex = 8;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = true;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 9;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldGENEL_TOPLAM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGENEL_TOPLAM.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldGENEL_TOPLAM.AreaIndex = 10;
            fieldGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            fieldGENEL_TOPLAM.Name = "fieldGENEL_TOPLAM";
            fieldGENEL_TOPLAM.Visible = true;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 11;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 12;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 13;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
            fieldID,
			fieldHARAKET_CARI,
			fieldBORC_ALACAK,
			fieldREFERANS_NO,
			fieldBELGE_NO,
			fieldODEME_TIP,
			fieldTARIH,
            fieldTARIH2,
			fieldANA_KATEGORI,
			fieldADET,
			fieldBIRIM_FIYAT,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldGENEL_TOPLAM,
			fieldACIKLAMA,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			};
            return dizi;
        }

        private PivotGridField[] KasaGunlukKategorilereGore()
        {
            #region Field & Properties

            PivotGridField fieldHARAKET_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHARAKET_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldHARAKET_CARI.AreaIndex = 0;
            fieldHARAKET_CARI.FieldName = "HARAKET_CARI";
            fieldHARAKET_CARI.Name = "fieldHARAKET_CARI";
            fieldHARAKET_CARI.Visible = true;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 1;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 2;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldBELGE_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBELGE_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBELGE_NO.AreaIndex = 3;
            fieldBELGE_NO.FieldName = "BELGE_NO";
            fieldBELGE_NO.Name = "fieldBELGE_NO";
            fieldBELGE_NO.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 13;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;
            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 4;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTARIH.AreaIndex = 5;
            fieldTARIH.GroupInterval = PivotGroupInterval.DateDay;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = true;

            PivotGridField fieldTARIH2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTARIH2.AreaIndex = 5;
            fieldTARIH2.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTARIH2.FieldName = "TARIH";
            fieldTARIH2.Name = "fieldTARIH2";
            fieldTARIH2.Visible = true;

            PivotGridField fieldANA_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldANA_KATEGORI.AreaIndex = 6;
            fieldANA_KATEGORI.FieldName = "ANA_KATEGORI";
            fieldANA_KATEGORI.Name = "fieldANA_KATEGORI";
            fieldANA_KATEGORI.Visible = true;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 7;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldBIRIM_FIYAT.AreaIndex = 8;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = true;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 9;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldGENEL_TOPLAM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGENEL_TOPLAM.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldGENEL_TOPLAM.AreaIndex = 10;
            fieldGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            fieldGENEL_TOPLAM.Name = "fieldGENEL_TOPLAM";
            fieldGENEL_TOPLAM.Visible = true;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 11;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 12;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 13;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
            fieldID,
			fieldHARAKET_CARI,
			fieldBORC_ALACAK,
			fieldREFERANS_NO,
			fieldBELGE_NO,
			fieldODEME_TIP,
			fieldTARIH,
            fieldTARIH2,
			fieldANA_KATEGORI,
			fieldADET,
			fieldBIRIM_FIYAT,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldGENEL_TOPLAM,
			fieldACIKLAMA,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			};
            return dizi;
        }

        private PivotGridField[] KasaGunlukYillikKategorilereGore()
        {
            #region Field & Properties

            PivotGridField fieldHARAKET_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHARAKET_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldHARAKET_CARI.AreaIndex = 0;
            fieldHARAKET_CARI.FieldName = "HARAKET_CARI";
            fieldHARAKET_CARI.Name = "fieldHARAKET_CARI";
            fieldHARAKET_CARI.Visible = true;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 1;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 2;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldBELGE_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBELGE_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBELGE_NO.AreaIndex = 3;
            fieldBELGE_NO.FieldName = "BELGE_NO";
            fieldBELGE_NO.Name = "fieldBELGE_NO";
            fieldBELGE_NO.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 13;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;
            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 4;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTARIH.AreaIndex = 5;
            fieldTARIH.GroupInterval = PivotGroupInterval.DateYear;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = true;

            PivotGridField fieldTARIH2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTARIH2.AreaIndex = 5;
            fieldTARIH2.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTARIH2.FieldName = "TARIH";
            fieldTARIH2.Name = "fieldTARIH2";
            fieldTARIH2.Visible = false;

            PivotGridField fieldANA_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldANA_KATEGORI.AreaIndex = 6;
            fieldANA_KATEGORI.FieldName = "ANA_KATEGORI";
            fieldANA_KATEGORI.Name = "fieldANA_KATEGORI";
            fieldANA_KATEGORI.Visible = true;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 7;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldBIRIM_FIYAT.AreaIndex = 8;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = true;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 9;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldGENEL_TOPLAM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGENEL_TOPLAM.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldGENEL_TOPLAM.AreaIndex = 10;
            fieldGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            fieldGENEL_TOPLAM.Name = "fieldGENEL_TOPLAM";
            fieldGENEL_TOPLAM.Visible = true;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 11;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 12;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 13;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
            fieldID,
			fieldHARAKET_CARI,
			fieldBORC_ALACAK,
			fieldREFERANS_NO,
			fieldBELGE_NO,
			fieldODEME_TIP,
			fieldTARIH,
			fieldANA_KATEGORI,
			fieldADET,
			fieldBIRIM_FIYAT,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldGENEL_TOPLAM,
			fieldACIKLAMA,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			};
            return dizi;
        }

        private GridColumn[] KasaHareketleriAylikKategorilereGore()
        {
            #region Field & Properties

            GridColumn colHARAKET_CARI = new GridColumn();
            colHARAKET_CARI.VisibleIndex = 0;
            colHARAKET_CARI.FieldName = "HARAKET_CARI";
            colHARAKET_CARI.Name = "colHARAKET_CARI";
            colHARAKET_CARI.Visible = true;

            GridColumn colBORC_ALACAK = new GridColumn();
            colBORC_ALACAK.VisibleIndex = 1;
            colBORC_ALACAK.FieldName = "BORC_ALACAK";
            colBORC_ALACAK.Name = "colBORC_ALACAK";
            colBORC_ALACAK.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 2;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colBELGE_NO = new GridColumn();
            colBELGE_NO.VisibleIndex = 3;
            colBELGE_NO.FieldName = "BELGE_NO";
            colBELGE_NO.Name = "colBELGE_NO";
            colBELGE_NO.Visible = true;

            GridColumn colODEME_TIP = new GridColumn();
            colODEME_TIP.VisibleIndex = 4;
            colODEME_TIP.FieldName = "ODEME_TIP";
            colODEME_TIP.Name = "colODEME_TIP";
            colODEME_TIP.Visible = true;

            GridColumn colTARIH = new GridColumn();
            colTARIH.VisibleIndex = 5;
            colTARIH.FieldName = "TARIH";
            colTARIH.Name = "colTARIH";
            colTARIH.Visible = true;

            GridColumn colANA_KATEGORI = new GridColumn();
            colANA_KATEGORI.VisibleIndex = 6;
            colANA_KATEGORI.FieldName = "ANA_KATEGORI";
            colANA_KATEGORI.Name = "colANA_KATEGORI";
            colANA_KATEGORI.Visible = true;

            GridColumn colADET = new GridColumn();
            colADET.VisibleIndex = 7;
            colADET.FieldName = "ADET";
            colADET.Name = "colADET";
            colADET.Visible = true;

            GridColumn colBIRIM_FIYAT = new GridColumn();
            colBIRIM_FIYAT.VisibleIndex = 8;
            colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
            colBIRIM_FIYAT.Visible = true;

            GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
            colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 9;
            colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Visible = true;

            GridColumn colGENEL_TOPLAM = new GridColumn();
            colGENEL_TOPLAM.VisibleIndex = 10;
            colGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
            colGENEL_TOPLAM.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 11;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 12;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 13;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colHARAKET_CARI,
			colBORC_ALACAK,
			colREFERANS_NO,
			colBELGE_NO,
			colODEME_TIP,
			colTARIH,
			colANA_KATEGORI,
			colADET,
			colBIRIM_FIYAT,
			colBIRIM_FIYAT_DOVIZ_ID,
			colGENEL_TOPLAM,
			colACIKLAMA,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
			};

            #endregion []

            return dizi;
        }

        private GridColumn[] KasaHareketleriGunlukKategorilereGore()
        {
            #region Field & Properties

            GridColumn colHARAKET_CARI = new GridColumn();
            colHARAKET_CARI.VisibleIndex = 0;
            colHARAKET_CARI.FieldName = "HARAKET_CARI";
            colHARAKET_CARI.Name = "colHARAKET_CARI";
            colHARAKET_CARI.Visible = true;

            GridColumn colBORC_ALACAK = new GridColumn();
            colBORC_ALACAK.VisibleIndex = 1;
            colBORC_ALACAK.FieldName = "BORC_ALACAK";
            colBORC_ALACAK.Name = "colBORC_ALACAK";
            colBORC_ALACAK.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 2;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colBELGE_NO = new GridColumn();
            colBELGE_NO.VisibleIndex = 3;
            colBELGE_NO.FieldName = "BELGE_NO";
            colBELGE_NO.Name = "colBELGE_NO";
            colBELGE_NO.Visible = true;

            GridColumn colODEME_TIP = new GridColumn();
            colODEME_TIP.VisibleIndex = 4;
            colODEME_TIP.FieldName = "ODEME_TIP";
            colODEME_TIP.Name = "colODEME_TIP";
            colODEME_TIP.Visible = true;

            GridColumn colTARIH = new GridColumn();
            colTARIH.DisplayFormat.FormatString = "dd";

            //colTARIH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colTARIH.VisibleIndex = 5;
            colTARIH.FieldName = "TARIH";
            colTARIH.Name = "colTARIH";
            colTARIH.Visible = true;

            GridColumn colANA_KATEGORI = new GridColumn();
            colANA_KATEGORI.VisibleIndex = 6;
            colANA_KATEGORI.FieldName = "ANA_KATEGORI";
            colANA_KATEGORI.Name = "colANA_KATEGORI";
            colANA_KATEGORI.Visible = true;

            GridColumn colADET = new GridColumn();
            colADET.VisibleIndex = 7;
            colADET.FieldName = "ADET";
            colADET.Name = "colADET";
            colADET.Visible = true;

            GridColumn colBIRIM_FIYAT = new GridColumn();
            colBIRIM_FIYAT.VisibleIndex = 8;
            colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
            colBIRIM_FIYAT.Visible = true;

            GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
            colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 9;
            colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Visible = true;

            GridColumn colGENEL_TOPLAM = new GridColumn();
            colGENEL_TOPLAM.VisibleIndex = 10;
            colGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
            colGENEL_TOPLAM.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 11;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 12;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 13;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colHARAKET_CARI,
			colBORC_ALACAK,
			colREFERANS_NO,
			colBELGE_NO,
			colODEME_TIP,
			colTARIH,
			colANA_KATEGORI,
			colADET,
			colBIRIM_FIYAT,
			colBIRIM_FIYAT_DOVIZ_ID,
			colGENEL_TOPLAM,
			colACIKLAMA,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
			};

            #endregion []

            return dizi;
        }

        private GridColumn[] KasaHareketleriHaftalikKategorilereGore()
        {
            #region Field & Properties

            GridColumn colHARAKET_CARI = new GridColumn();
            colHARAKET_CARI.VisibleIndex = 0;
            colHARAKET_CARI.FieldName = "HARAKET_CARI";
            colHARAKET_CARI.Name = "colHARAKET_CARI";
            colHARAKET_CARI.Visible = true;

            GridColumn colBORC_ALACAK = new GridColumn();
            colBORC_ALACAK.VisibleIndex = 1;
            colBORC_ALACAK.FieldName = "BORC_ALACAK";
            colBORC_ALACAK.Name = "colBORC_ALACAK";
            colBORC_ALACAK.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 2;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colBELGE_NO = new GridColumn();
            colBELGE_NO.VisibleIndex = 3;
            colBELGE_NO.FieldName = "BELGE_NO";
            colBELGE_NO.Name = "colBELGE_NO";
            colBELGE_NO.Visible = true;

            GridColumn colODEME_TIP = new GridColumn();
            colODEME_TIP.VisibleIndex = 4;
            colODEME_TIP.FieldName = "ODEME_TIP";
            colODEME_TIP.Name = "colODEME_TIP";
            colODEME_TIP.Visible = true;

            GridColumn colTARIH = new GridColumn();
            colTARIH.VisibleIndex = 5;
            colTARIH.FieldName = "TARIH";
            colTARIH.Name = "colTARIH";
            colTARIH.Visible = true;

            GridColumn colANA_KATEGORI = new GridColumn();
            colANA_KATEGORI.VisibleIndex = 6;
            colANA_KATEGORI.FieldName = "ANA_KATEGORI";
            colANA_KATEGORI.Name = "colANA_KATEGORI";
            colANA_KATEGORI.Visible = true;

            GridColumn colADET = new GridColumn();
            colADET.VisibleIndex = 7;
            colADET.FieldName = "ADET";
            colADET.Name = "colADET";
            colADET.Visible = true;

            GridColumn colBIRIM_FIYAT = new GridColumn();
            colBIRIM_FIYAT.VisibleIndex = 8;
            colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
            colBIRIM_FIYAT.Visible = true;

            GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
            colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 9;
            colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Visible = true;

            GridColumn colGENEL_TOPLAM = new GridColumn();
            colGENEL_TOPLAM.VisibleIndex = 10;
            colGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
            colGENEL_TOPLAM.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 11;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 12;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 13;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colHARAKET_CARI,
			colBORC_ALACAK,
			colREFERANS_NO,
			colBELGE_NO,
			colODEME_TIP,
			colTARIH,
			colANA_KATEGORI,
			colADET,
			colBIRIM_FIYAT,
			colBIRIM_FIYAT_DOVIZ_ID,
			colGENEL_TOPLAM,
			colACIKLAMA,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
			};

            #endregion []

            return dizi;
        }

        private GridColumn[] KasaHareketleriYillikKategorilereGore()
        {
            #region Field & Properties

            GridColumn colHARAKET_CARI = new GridColumn();
            colHARAKET_CARI.VisibleIndex = 0;
            colHARAKET_CARI.FieldName = "HARAKET_CARI";
            colHARAKET_CARI.Name = "colHARAKET_CARI";
            colHARAKET_CARI.Visible = true;

            GridColumn colBORC_ALACAK = new GridColumn();
            colBORC_ALACAK.VisibleIndex = 1;
            colBORC_ALACAK.FieldName = "BORC_ALACAK";
            colBORC_ALACAK.Name = "colBORC_ALACAK";
            colBORC_ALACAK.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 2;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colBELGE_NO = new GridColumn();
            colBELGE_NO.VisibleIndex = 3;
            colBELGE_NO.FieldName = "BELGE_NO";
            colBELGE_NO.Name = "colBELGE_NO";
            colBELGE_NO.Visible = true;

            GridColumn colODEME_TIP = new GridColumn();
            colODEME_TIP.VisibleIndex = 4;
            colODEME_TIP.FieldName = "ODEME_TIP";
            colODEME_TIP.Name = "colODEME_TIP";
            colODEME_TIP.Visible = true;

            GridColumn colTARIH = new GridColumn();
            colTARIH.VisibleIndex = 5;
            colTARIH.FieldName = "TARIH";
            colTARIH.Name = "colTARIH";
            colTARIH.Visible = true;

            GridColumn colANA_KATEGORI = new GridColumn();
            colANA_KATEGORI.VisibleIndex = 6;
            colANA_KATEGORI.FieldName = "ANA_KATEGORI";
            colANA_KATEGORI.Name = "colANA_KATEGORI";
            colANA_KATEGORI.Visible = true;

            GridColumn colADET = new GridColumn();
            colADET.VisibleIndex = 7;
            colADET.FieldName = "ADET";
            colADET.Name = "colADET";
            colADET.Visible = true;

            GridColumn colBIRIM_FIYAT = new GridColumn();
            colBIRIM_FIYAT.VisibleIndex = 8;
            colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
            colBIRIM_FIYAT.Visible = true;

            GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
            colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 9;
            colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Visible = true;

            GridColumn colGENEL_TOPLAM = new GridColumn();
            colGENEL_TOPLAM.VisibleIndex = 10;
            colGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
            colGENEL_TOPLAM.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 11;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 12;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 13;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colHARAKET_CARI,
			colBORC_ALACAK,
			colREFERANS_NO,
			colBELGE_NO,
			colODEME_TIP,
			colTARIH,
			colANA_KATEGORI,
			colADET,
			colBIRIM_FIYAT,
			colBIRIM_FIYAT_DOVIZ_ID,
			colGENEL_TOPLAM,
			colACIKLAMA,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
			};

            #endregion []

            return dizi;
        }
    }
}