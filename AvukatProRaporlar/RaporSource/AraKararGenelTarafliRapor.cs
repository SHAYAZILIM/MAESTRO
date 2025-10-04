using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class AraKararGenelTarafliRapor
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

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 0;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 1;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colDAVA_TARIHI = new GridColumn();
            colDAVA_TARIHI.VisibleIndex = 2;
            colDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            colDAVA_TARIHI.Name = "colDAVA_TARIHI";
            colDAVA_TARIHI.Visible = true;

            GridColumn colDAVA_TIP = new GridColumn();
            colDAVA_TIP.VisibleIndex = 3;
            colDAVA_TIP.FieldName = "DAVA_TIP";
            colDAVA_TIP.Name = "colDAVA_TIP";
            colDAVA_TIP.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 4;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

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

            GridColumn colMAHKEME = new GridColumn();
            colMAHKEME.VisibleIndex = 7;
            colMAHKEME.FieldName = "MAHKEME";
            colMAHKEME.Name = "colMAHKEME";
            colMAHKEME.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 8;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 9;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 10;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colEVRAK_NO = new GridColumn();
            colEVRAK_NO.VisibleIndex = 11;
            colEVRAK_NO.FieldName = "EVRAK_NO";
            colEVRAK_NO.Name = "colEVRAK_NO";
            colEVRAK_NO.Visible = true;

            GridColumn colSULH_TARIHI = new GridColumn();
            colSULH_TARIHI.VisibleIndex = 12;
            colSULH_TARIHI.FieldName = "SULH_TARIHI";
            colSULH_TARIHI.Name = "colSULH_TARIHI";
            colSULH_TARIHI.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 13;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colAVUKATA_INTIKAL_TARIHI = new GridColumn();
            colAVUKATA_INTIKAL_TARIHI.VisibleIndex = 14;
            colAVUKATA_INTIKAL_TARIHI.FieldName = "AVUKATA_INTIKAL_TARIHI";
            colAVUKATA_INTIKAL_TARIHI.Name = "colAVUKATA_INTIKAL_TARIHI";
            colAVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colARA_KARAR = new GridColumn();
            colARA_KARAR.VisibleIndex = 15;
            colARA_KARAR.FieldName = "ARA_KARAR";
            colARA_KARAR.Name = "colARA_KARAR";
            colARA_KARAR.Visible = true;

            GridColumn colAD = new GridColumn();
            colAD.VisibleIndex = 16;
            colAD.FieldName = "AD";
            colAD.Name = "colAD";
            colAD.Visible = true;

            GridColumn colSIFAT = new GridColumn();
            colSIFAT.VisibleIndex = 17;
            colSIFAT.FieldName = "SIFAT";
            colSIFAT.Name = "colSIFAT";
            colSIFAT.Visible = true;

            GridColumn colDAVA_TALEP = new GridColumn();
            colDAVA_TALEP.VisibleIndex = 18;
            colDAVA_TALEP.FieldName = "DAVA_TALEP";
            colDAVA_TALEP.Name = "colDAVA_TALEP";
            colDAVA_TALEP.Visible = true;

            GridColumn colDAVA_OZEL_KOD1 = new GridColumn();
            colDAVA_OZEL_KOD1.VisibleIndex = 19;
            colDAVA_OZEL_KOD1.FieldName = "DAVA_OZEL_KOD1";
            colDAVA_OZEL_KOD1.Name = "colDAVA_OZEL_KOD1";
            colDAVA_OZEL_KOD1.Visible = true;

            GridColumn colDAVA_OZEL_KOD2 = new GridColumn();
            colDAVA_OZEL_KOD2.VisibleIndex = 20;
            colDAVA_OZEL_KOD2.FieldName = "DAVA_OZEL_KOD2";
            colDAVA_OZEL_KOD2.Name = "colDAVA_OZEL_KOD2";
            colDAVA_OZEL_KOD2.Visible = true;

            GridColumn colDAVA_OZEL_KOD3 = new GridColumn();
            colDAVA_OZEL_KOD3.VisibleIndex = 21;
            colDAVA_OZEL_KOD3.FieldName = "DAVA_OZEL_KOD3";
            colDAVA_OZEL_KOD3.Name = "colDAVA_OZEL_KOD3";
            colDAVA_OZEL_KOD3.Visible = true;

            GridColumn colDAVA_OZEL_KOD4 = new GridColumn();
            colDAVA_OZEL_KOD4.VisibleIndex = 22;
            colDAVA_OZEL_KOD4.FieldName = "DAVA_OZEL_KOD4";
            colDAVA_OZEL_KOD4.Name = "colDAVA_OZEL_KOD4";
            colDAVA_OZEL_KOD4.Visible = true;

            GridColumn colKARAR_ACIKLAMA = new GridColumn();
            colKARAR_ACIKLAMA.VisibleIndex = 23;
            colKARAR_ACIKLAMA.FieldName = "KARAR_ACIKLAMA";
            colKARAR_ACIKLAMA.Name = "colKARAR_ACIKLAMA";
            colKARAR_ACIKLAMA.Visible = true;

            GridColumn colYERINE_GETIRME_TARIH = new GridColumn();
            colYERINE_GETIRME_TARIH.VisibleIndex = 24;
            colYERINE_GETIRME_TARIH.FieldName = "YERINE_GETIRME_TARIH";
            colYERINE_GETIRME_TARIH.Name = "colYERINE_GETIRME_TARIH";
            colYERINE_GETIRME_TARIH.Visible = true;

            GridColumn colTARIH = new GridColumn();
            colTARIH.VisibleIndex = 25;
            colTARIH.FieldName = "TARIH";
            colTARIH.Name = "colTARIH";
            colTARIH.Visible = true;

            GridColumn colYERINE_GETIRME_GUN = new GridColumn();
            colYERINE_GETIRME_GUN.VisibleIndex = 26;
            colYERINE_GETIRME_GUN.FieldName = "YERINE_GETIRME_GUN";
            colYERINE_GETIRME_GUN.Name = "colYERINE_GETIRME_GUN";
            colYERINE_GETIRME_GUN.Visible = true;

            GridColumn colTIP_ID = new GridColumn();
            colTIP_ID.VisibleIndex = 27;
            colTIP_ID.FieldName = "TIP_ID";
            colTIP_ID.Name = "colTIP_ID";
            colTIP_ID.Visible = true;

            GridColumn colTARAF_KODU = new GridColumn();
            colTARAF_KODU.VisibleIndex = 28;
            colTARAF_KODU.FieldName = "TARAF_KODU";
            colTARAF_KODU.Name = "colTARAF_KODU";
            colTARAF_KODU.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 29;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

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

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colFOY_NO,
			colDURUM,
			colDAVA_TARIHI,
			colDAVA_TIP,
			colREFERANS_NO,
			colREFERANS_NO2,
			colREFERANS_NO3,
			colMAHKEME,
			colNO,
			colGOREV,
			colACIKLAMA,
			colEVRAK_NO,
			colSULH_TARIHI,
			colESAS_NO,
			colAVUKATA_INTIKAL_TARIHI,
			colARA_KARAR,
			colAD,
			colSIFAT,
			colDAVA_TALEP,
			colDAVA_OZEL_KOD1,
			colDAVA_OZEL_KOD2,
			colDAVA_OZEL_KOD3,
			colDAVA_OZEL_KOD4,
			colKARAR_ACIKLAMA,
			colYERINE_GETIRME_TARIH,
			colTARIH,
			colYERINE_GETIRME_GUN,
			colTIP_ID,
			colTARAF_KODU,
			colSUBE_KOD_ID,
			colKONTROL_KIM_ID,
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

        public PivotGridField[] GetPivotFields()
        {
            #region Field & Properties

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 0;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 1;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 2;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TIP.AreaIndex = 3;
            fieldDAVA_TIP.FieldName = "DAVA_TIP";
            fieldDAVA_TIP.Name = "fieldDAVA_TIP";
            fieldDAVA_TIP.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 4;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

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

            PivotGridField fieldMAHKEME = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHKEME.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHKEME.AreaIndex = 7;
            fieldMAHKEME.FieldName = "MAHKEME";
            fieldMAHKEME.Name = "fieldMAHKEME";
            fieldMAHKEME.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 8;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 9;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 10;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldEVRAK_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldEVRAK_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldEVRAK_NO.AreaIndex = 11;
            fieldEVRAK_NO.FieldName = "EVRAK_NO";
            fieldEVRAK_NO.Name = "fieldEVRAK_NO";
            fieldEVRAK_NO.Visible = false;

            PivotGridField fieldSULH_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSULH_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSULH_TARIHI.AreaIndex = 12;
            fieldSULH_TARIHI.FieldName = "SULH_TARIHI";
            fieldSULH_TARIHI.Name = "fieldSULH_TARIHI";
            fieldSULH_TARIHI.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 13;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldAVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAVUKATA_INTIKAL_TARIHI.AreaIndex = 14;
            fieldAVUKATA_INTIKAL_TARIHI.FieldName = "AVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Name = "fieldAVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldARA_KARAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldARA_KARAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldARA_KARAR.AreaIndex = 15;
            fieldARA_KARAR.FieldName = "ARA_KARAR";
            fieldARA_KARAR.Name = "fieldARA_KARAR";
            fieldARA_KARAR.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 16;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldSIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSIFAT.AreaIndex = 17;
            fieldSIFAT.FieldName = "SIFAT";
            fieldSIFAT.Name = "fieldSIFAT";
            fieldSIFAT.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 18;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldDAVA_OZEL_KOD1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_OZEL_KOD1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_OZEL_KOD1.AreaIndex = 19;
            fieldDAVA_OZEL_KOD1.FieldName = "DAVA_OZEL_KOD1";
            fieldDAVA_OZEL_KOD1.Name = "fieldDAVA_OZEL_KOD1";
            fieldDAVA_OZEL_KOD1.Visible = false;

            PivotGridField fieldDAVA_OZEL_KOD2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_OZEL_KOD2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_OZEL_KOD2.AreaIndex = 20;
            fieldDAVA_OZEL_KOD2.FieldName = "DAVA_OZEL_KOD2";
            fieldDAVA_OZEL_KOD2.Name = "fieldDAVA_OZEL_KOD2";
            fieldDAVA_OZEL_KOD2.Visible = false;

            PivotGridField fieldDAVA_OZEL_KOD3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_OZEL_KOD3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_OZEL_KOD3.AreaIndex = 21;
            fieldDAVA_OZEL_KOD3.FieldName = "DAVA_OZEL_KOD3";
            fieldDAVA_OZEL_KOD3.Name = "fieldDAVA_OZEL_KOD3";
            fieldDAVA_OZEL_KOD3.Visible = false;

            PivotGridField fieldDAVA_OZEL_KOD4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_OZEL_KOD4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_OZEL_KOD4.AreaIndex = 22;
            fieldDAVA_OZEL_KOD4.FieldName = "DAVA_OZEL_KOD4";
            fieldDAVA_OZEL_KOD4.Name = "fieldDAVA_OZEL_KOD4";
            fieldDAVA_OZEL_KOD4.Visible = false;

            PivotGridField fieldKARAR_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARAR_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARAR_ACIKLAMA.AreaIndex = 23;
            fieldKARAR_ACIKLAMA.FieldName = "KARAR_ACIKLAMA";
            fieldKARAR_ACIKLAMA.Name = "fieldKARAR_ACIKLAMA";
            fieldKARAR_ACIKLAMA.Visible = false;

            PivotGridField fieldYERINE_GETIRME_TARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYERINE_GETIRME_TARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldYERINE_GETIRME_TARIH.AreaIndex = 24;
            fieldYERINE_GETIRME_TARIH.FieldName = "YERINE_GETIRME_TARIH";
            fieldYERINE_GETIRME_TARIH.Name = "fieldYERINE_GETIRME_TARIH";
            fieldYERINE_GETIRME_TARIH.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 25;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldYERINE_GETIRME_GUN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYERINE_GETIRME_GUN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldYERINE_GETIRME_GUN.AreaIndex = 26;
            fieldYERINE_GETIRME_GUN.FieldName = "YERINE_GETIRME_GUN";
            fieldYERINE_GETIRME_GUN.Name = "fieldYERINE_GETIRME_GUN";
            fieldYERINE_GETIRME_GUN.Visible = false;

            PivotGridField fieldTIP_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTIP_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTIP_ID.AreaIndex = 27;
            fieldTIP_ID.FieldName = "TIP_ID";
            fieldTIP_ID.Name = "fieldTIP_ID";
            fieldTIP_ID.Visible = false;

            PivotGridField fieldTARAF_KODU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARAF_KODU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARAF_KODU.AreaIndex = 28;
            fieldTARAF_KODU.FieldName = "TARAF_KODU";
            fieldTARAF_KODU.Name = "fieldTARAF_KODU";
            fieldTARAF_KODU.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 30;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 31;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldFOY_NO,
			fieldDURUM,
			fieldDAVA_TARIHI,
			fieldDAVA_TIP,
			fieldREFERANS_NO,
			fieldREFERANS_NO2,
			fieldREFERANS_NO3,
			fieldMAHKEME,
			fieldNO,
			fieldGOREV,
			fieldACIKLAMA,
			fieldEVRAK_NO,
			fieldSULH_TARIHI,
			fieldESAS_NO,
			fieldAVUKATA_INTIKAL_TARIHI,
			fieldARA_KARAR,
			fieldAD,
			fieldSIFAT,
			fieldDAVA_TALEP,
			fieldDAVA_OZEL_KOD1,
			fieldDAVA_OZEL_KOD2,
			fieldDAVA_OZEL_KOD3,
			fieldDAVA_OZEL_KOD4,
			fieldKARAR_ACIKLAMA,
			fieldYERINE_GETIRME_TARIH,
			fieldTARIH,
			fieldYERINE_GETIRME_GUN,
			fieldTIP_ID,
			fieldTARAF_KODU,
			fieldSUBE_KOD_ID,
			fieldKONTROL_KIM_ID,
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
            #region Özelleştirme

            string RefNo, RefNo2, refNo3, OzelKod1, OzelKod2, OzelKod3, OzelKod4, DNRefNo, DNRefNo2;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans1))
                RefNo = "Ref No";
            else
                RefNo = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans1;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans2))
                RefNo2 = "Ref No2";
            else
                RefNo2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans2;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans3))
                refNo3 = "Ref No3";
            else
                refNo3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans3;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod1))
                OzelKod1 = "Özel Kod1";
            else
                OzelKod1 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod1;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod2))
                OzelKod2 = "Özel Kod2";
            else
                OzelKod2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod2;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod3))
                OzelKod3 = "Özel Kod3";
            else
                OzelKod3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod3;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod4))
                OzelKod4 = "Özel Kod4";
            else
                OzelKod4 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod4;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaDnReferans.Referans1))
                DNRefNo = "Dava Neden Ref No1";
            else
                DNRefNo = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaDnReferans.Referans1;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaDnReferans.Referans2))
                DNRefNo2 = "Dava Neden Ref No2";
            else
                DNRefNo2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaDnReferans.Referans2;

            #endregion Özelleştirme

            Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

            #region Caption Edit

            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("DAVA_TARIHI", "Dava T");
            dicFieldCaption.Add("DAVA_TIP", "Dava Tip");
            dicFieldCaption.Add("REFERANS_NO", RefNo);
            dicFieldCaption.Add("REFERANS_NO2", RefNo2);
            dicFieldCaption.Add("REFERANS_NO3", refNo3);
            dicFieldCaption.Add("MAHKEME", "Mahkeme");
            dicFieldCaption.Add("NO", "No");
            dicFieldCaption.Add("GOREV", "Görev");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("EVRAK_NO", "Evrak No");
            dicFieldCaption.Add("SULH_TARIHI", "Sulh T");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("AVUKATA_INTIKAL_TARIHI", "Avukata İntikal T");
            dicFieldCaption.Add("ARA_KARAR", "Ara Karar");
            dicFieldCaption.Add("AD", "Taraf");
            dicFieldCaption.Add("SIFAT", "Sıfat");
            dicFieldCaption.Add("DAVA_TALEP", "Dava Talep");
            dicFieldCaption.Add("DAVA_OZEL_KOD1", OzelKod1);
            dicFieldCaption.Add("DAVA_OZEL_KOD2", OzelKod2);
            dicFieldCaption.Add("DAVA_OZEL_KOD3", OzelKod3);
            dicFieldCaption.Add("DAVA_OZEL_KOD4", OzelKod4);
            dicFieldCaption.Add("KARAR_ACIKLAMA", "Karar Açıklama");
            dicFieldCaption.Add("YERINE_GETIRME_TARIH", "Yerine Getirme T");
            dicFieldCaption.Add("TARIH", "Tarih");
            dicFieldCaption.Add("YERINE_GETIRME_GUN", "Yerine Getirme Gün");
            dicFieldCaption.Add("TIP_ID", "Ara Karar Tip");
            dicFieldCaption.Add("TARAF_KODU", "T.K");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("BOLUM", "Bölüm");

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
            sozluk.Add("TIP_ID", InitsEx.AraKararTip);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);

            #endregion Add item

            return sozluk;
        }
    }
}