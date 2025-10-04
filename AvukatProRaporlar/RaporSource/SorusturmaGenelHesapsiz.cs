using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class SorusturmaGenelHesapsiz
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

            GridColumn colHAZIRLIK_NO = new GridColumn();
            colHAZIRLIK_NO.VisibleIndex = 0;
            colHAZIRLIK_NO.FieldName = "HAZIRLIK_NO";
            colHAZIRLIK_NO.Name = "colHAZIRLIK_NO";
            colHAZIRLIK_NO.Visible = true;

            GridColumn colSIKAYET_TARIHI = new GridColumn();
            colSIKAYET_TARIHI.VisibleIndex = 1;
            colSIKAYET_TARIHI.FieldName = "SIKAYET_TARIHI";
            colSIKAYET_TARIHI.Name = "colSIKAYET_TARIHI";
            colSIKAYET_TARIHI.Visible = true;

            GridColumn colDAVA_TALEP = new GridColumn();
            colDAVA_TALEP.VisibleIndex = 2;
            colDAVA_TALEP.FieldName = "DAVA_TALEP";
            colDAVA_TALEP.Name = "colDAVA_TALEP";
            colDAVA_TALEP.Visible = true;

            GridColumn colHAZIRLIK_TARIH = new GridColumn();
            colHAZIRLIK_TARIH.VisibleIndex = 3;
            colHAZIRLIK_TARIH.FieldName = "HAZIRLIK_TARIH";
            colHAZIRLIK_TARIH.Name = "colHAZIRLIK_TARIH";
            colHAZIRLIK_TARIH.Visible = true;

            GridColumn colHAZIRLIK_ESAS_NO = new GridColumn();
            colHAZIRLIK_ESAS_NO.VisibleIndex = 4;
            colHAZIRLIK_ESAS_NO.FieldName = "HAZIRLIK_ESAS_NO";
            colHAZIRLIK_ESAS_NO.Name = "colHAZIRLIK_ESAS_NO";
            colHAZIRLIK_ESAS_NO.Visible = true;

            GridColumn colREFERANS_NO2 = new GridColumn();
            colREFERANS_NO2.VisibleIndex = 5;
            colREFERANS_NO2.FieldName = "REFERANS_NO2";
            colREFERANS_NO2.Name = "colREFERANS_NO2";
            colREFERANS_NO2.Visible = true;

            GridColumn colREFERANS_NO3 = new GridColumn();
            colREFERANS_NO3.VisibleIndex = 6;
            colREFERANS_NO3.FieldName = "REFERANS_NO3";
            colREFERANS_NO3.Name = "colREFERANS_NO3";
            colREFERANS_NO3.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 7;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 8;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 9;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 10;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 11;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 12;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 13;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 14;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 15;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 16;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;
            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 17;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 18;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 19;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colHAZIRLIK_NO,
			colSIKAYET_TARIHI,
			colDAVA_TALEP,
			colHAZIRLIK_TARIH,
			colHAZIRLIK_ESAS_NO,
			colREFERANS_NO2,
			colREFERANS_NO3,
			colDURUM,
			colACIKLAMA,
			colOZEL_KOD1,
			colOZEL_KOD3,
			colOZEL_KOD4,
			colOZEL_KOD2,
			colADLIYE,
			colNO,
			colGOREV,
			colREFERANS_NO,
            colKONTROL_KIM_ID,
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
                    dizi[i].Caption = "Brm";

                if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
                {
                    dizi[i].ColumnEdit = editler["DovizId"];
                    dizi[i].Caption = "Brm";
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

            PivotGridField fieldHAZIRLIK_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_NO.AreaIndex = 0;
            fieldHAZIRLIK_NO.FieldName = "HAZIRLIK_NO";
            fieldHAZIRLIK_NO.Name = "fieldHAZIRLIK_NO";
            fieldHAZIRLIK_NO.Visible = false;

            PivotGridField fieldSIKAYET_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSIKAYET_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSIKAYET_TARIHI.AreaIndex = 1;
            fieldSIKAYET_TARIHI.FieldName = "SIKAYET_TARIHI";
            fieldSIKAYET_TARIHI.Name = "fieldSIKAYET_TARIHI";
            fieldSIKAYET_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 2;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldHAZIRLIK_TARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_TARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_TARIH.AreaIndex = 3;
            fieldHAZIRLIK_TARIH.FieldName = "HAZIRLIK_TARIH";
            fieldHAZIRLIK_TARIH.Name = "fieldHAZIRLIK_TARIH";
            fieldHAZIRLIK_TARIH.Visible = false;

            PivotGridField fieldHAZIRLIK_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_ESAS_NO.AreaIndex = 4;
            fieldHAZIRLIK_ESAS_NO.FieldName = "HAZIRLIK_ESAS_NO";
            fieldHAZIRLIK_ESAS_NO.Name = "fieldHAZIRLIK_ESAS_NO";
            fieldHAZIRLIK_ESAS_NO.Visible = false;

            PivotGridField fieldREFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO2.AreaIndex = 5;
            fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
            fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";
            fieldREFERANS_NO2.Visible = false;

            PivotGridField fieldREFERANS_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO3.AreaIndex = 6;
            fieldREFERANS_NO3.FieldName = "REFERANS_NO3";
            fieldREFERANS_NO3.Name = "fieldREFERANS_NO3";
            fieldREFERANS_NO3.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 7;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 8;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldOZEL_KOD1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD1.AreaIndex = 9;
            fieldOZEL_KOD1.FieldName = "OZEL_KOD1";
            fieldOZEL_KOD1.Name = "fieldOZEL_KOD1";
            fieldOZEL_KOD1.Visible = false;

            PivotGridField fieldOZEL_KOD3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD3.AreaIndex = 10;
            fieldOZEL_KOD3.FieldName = "OZEL_KOD3";
            fieldOZEL_KOD3.Name = "fieldOZEL_KOD3";
            fieldOZEL_KOD3.Visible = false;

            PivotGridField fieldOZEL_KOD4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD4.AreaIndex = 11;
            fieldOZEL_KOD4.FieldName = "OZEL_KOD4";
            fieldOZEL_KOD4.Name = "fieldOZEL_KOD4";
            fieldOZEL_KOD4.Visible = false;

            PivotGridField fieldOZEL_KOD2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD2.AreaIndex = 12;
            fieldOZEL_KOD2.FieldName = "OZEL_KOD2";
            fieldOZEL_KOD2.Name = "fieldOZEL_KOD2";
            fieldOZEL_KOD2.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 13;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 14;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 15;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 16;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 17;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 18;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 19;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldHAZIRLIK_NO,
			fieldSIKAYET_TARIHI,
			fieldDAVA_TALEP,
			fieldHAZIRLIK_TARIH,
			fieldHAZIRLIK_ESAS_NO,
			fieldREFERANS_NO2,
			fieldREFERANS_NO3,
			fieldDURUM,
			fieldACIKLAMA,
			fieldOZEL_KOD1,
			fieldOZEL_KOD3,
			fieldOZEL_KOD4,
			fieldOZEL_KOD2,
			fieldADLIYE,
			fieldNO,
			fieldGOREV,
			fieldREFERANS_NO,
            fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
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

            #region Özelleştirme

            string RefNo, RefNo2, refNo3, OzelKod1, OzelKod2, OzelKod3, OzelKod4;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaReferans.Referans1))
                RefNo = "Ref No";
            else
                RefNo = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaReferans.Referans1;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaReferans.Referans2))
                RefNo2 = "Ref No2";
            else
                RefNo2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaReferans.Referans2;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaReferans.Referans3))
                refNo3 = "Ref No3";
            else
                refNo3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaReferans.Referans3;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod1))
                OzelKod1 = "Özel Kod1";
            else
                OzelKod1 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod1;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod2))
                OzelKod2 = "Özel Kod2";
            else
                OzelKod2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod2;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod3))
                OzelKod3 = "Özel Kod3";
            else
                OzelKod3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod3;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod4))
                OzelKod4 = "Özel Kod4";
            else
                OzelKod4 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod4;

            #endregion Özelleştirme

            #region Caption Edit

            dicFieldCaption.Add("HAZIRLIK_NO", "Soruşturma No");
            dicFieldCaption.Add("SIKAYET_TARIHI", "Şikayet T");
            dicFieldCaption.Add("DAVA_TALEP", "Dava Talep");
            dicFieldCaption.Add("HAZIRLIK_TARIH", "Soruşturma T");
            dicFieldCaption.Add("HAZIRLIK_ESAS_NO", "Soruşturma Esas No");
            dicFieldCaption.Add("REFERANS_NO2", RefNo2);
            dicFieldCaption.Add("REFERANS_NO3", refNo3);
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("OZEL_KOD1", OzelKod1);
            dicFieldCaption.Add("OZEL_KOD3", OzelKod2);
            dicFieldCaption.Add("OZEL_KOD4", OzelKod3);
            dicFieldCaption.Add("OZEL_KOD2", OzelKod4);
            dicFieldCaption.Add("ADLIYE", "Savcılık");
            dicFieldCaption.Add("NO", "No");
            dicFieldCaption.Add("GOREV", "Görev");
            dicFieldCaption.Add("REFERANS_NO", RefNo);
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("ID", "");

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
    }
}