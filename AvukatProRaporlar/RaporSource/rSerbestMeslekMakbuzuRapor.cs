using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class rSerbestMeslekMakbuzuRapor
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

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 0;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 1;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colFATURA_HEDEF_TIP = new GridColumn();
            colFATURA_HEDEF_TIP.VisibleIndex = 2;
            colFATURA_HEDEF_TIP.FieldName = "FATURA_HEDEF_TIP";
            colFATURA_HEDEF_TIP.Name = "colFATURA_HEDEF_TIP";
            colFATURA_HEDEF_TIP.Visible = true;

            GridColumn colFATURA_KAPSAM_TIP = new GridColumn();
            colFATURA_KAPSAM_TIP.VisibleIndex = 3;
            colFATURA_KAPSAM_TIP.FieldName = "FATURA_KAPSAM_TIP";
            colFATURA_KAPSAM_TIP.Name = "colFATURA_KAPSAM_TIP";
            colFATURA_KAPSAM_TIP.Visible = true;

            GridColumn colSAHIS = new GridColumn();
            colSAHIS.VisibleIndex = 4;
            colSAHIS.FieldName = "SAHIS";
            colSAHIS.Name = "colSAHIS";
            colSAHIS.Visible = true;

            GridColumn colMIKTAR = new GridColumn();
            colMIKTAR.VisibleIndex = 5;
            colMIKTAR.FieldName = "MIKTAR";
            colMIKTAR.Name = "colMIKTAR";
            colMIKTAR.Visible = true;

            GridColumn colMIKTAR_DOVIZ_ID = new GridColumn();
            colMIKTAR_DOVIZ_ID.VisibleIndex = 6;
            colMIKTAR_DOVIZ_ID.FieldName = "MIKTAR_DOVIZ_ID";
            colMIKTAR_DOVIZ_ID.Name = "colMIKTAR_DOVIZ_ID";
            colMIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colKDV = new GridColumn();
            colKDV.VisibleIndex = 7;
            colKDV.FieldName = "KDV";
            colKDV.Name = "colKDV";
            colKDV.Visible = true;

            GridColumn colKDV_DOVIZ_ID = new GridColumn();
            colKDV_DOVIZ_ID.VisibleIndex = 8;
            colKDV_DOVIZ_ID.FieldName = "KDV_DOVIZ_ID";
            colKDV_DOVIZ_ID.Name = "colKDV_DOVIZ_ID";
            colKDV_DOVIZ_ID.Visible = true;

            GridColumn colTOPLAM = new GridColumn();
            colTOPLAM.VisibleIndex = 9;
            colTOPLAM.FieldName = "TOPLAM";
            colTOPLAM.Name = "colTOPLAM";
            colTOPLAM.Visible = true;

            GridColumn colTOPLAM_DOVIZ_ID = new GridColumn();
            colTOPLAM_DOVIZ_ID.VisibleIndex = 10;
            colTOPLAM_DOVIZ_ID.FieldName = "TOPLAM_DOVIZ_ID";
            colTOPLAM_DOVIZ_ID.Name = "colTOPLAM_DOVIZ_ID";
            colTOPLAM_DOVIZ_ID.Visible = true;

            GridColumn colFATURA_TARIH = new GridColumn();
            colFATURA_TARIH.VisibleIndex = 11;
            colFATURA_TARIH.FieldName = "FATURA_TARIH";
            colFATURA_TARIH.Name = "colFATURA_TARIH";
            colFATURA_TARIH.Visible = true;

            GridColumn colSERI_NO = new GridColumn();
            colSERI_NO.VisibleIndex = 12;
            colSERI_NO.FieldName = "SERI_NO";
            colSERI_NO.Name = "colSERI_NO";
            colSERI_NO.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 13;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 14;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 15;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 16;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 17;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 18;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 19;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 20;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 21;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 22;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 23;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 24;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colREFERANS_NO,
			colID,
			colFATURA_HEDEF_TIP,
			colFATURA_KAPSAM_TIP,
			colSAHIS,
			colMIKTAR,
			colMIKTAR_DOVIZ_ID,
			colKDV,
			colKDV_DOVIZ_ID,
			colTOPLAM,
			colTOPLAM_DOVIZ_ID,
			colFATURA_TARIH,
			colSERI_NO,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
			colFOY_NO,
			colESAS_NO,
			colDURUM,
			colADLIYE,
			colNO,
			colGOREV,
			colTAKIP_EDEN,
			colTAKIP_EDILEN,
			colIZLEYEN,
			colSORUMLU,
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
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 1;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldFATURA_HEDEF_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFATURA_HEDEF_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFATURA_HEDEF_TIP.AreaIndex = 2;
            fieldFATURA_HEDEF_TIP.FieldName = "FATURA_HEDEF_TIP";
            fieldFATURA_HEDEF_TIP.Name = "fieldFATURA_HEDEF_TIP";
            fieldFATURA_HEDEF_TIP.Visible = false;

            PivotGridField fieldFATURA_KAPSAM_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFATURA_KAPSAM_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFATURA_KAPSAM_TIP.AreaIndex = 3;
            fieldFATURA_KAPSAM_TIP.FieldName = "FATURA_KAPSAM_TIP";
            fieldFATURA_KAPSAM_TIP.Name = "fieldFATURA_KAPSAM_TIP";
            fieldFATURA_KAPSAM_TIP.Visible = false;

            PivotGridField fieldSAHIS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSAHIS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSAHIS.AreaIndex = 4;
            fieldSAHIS.FieldName = "SAHIS";
            fieldSAHIS.Name = "fieldSAHIS";
            fieldSAHIS.Visible = false;

            PivotGridField fieldMIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMIKTAR.AreaIndex = 5;
            fieldMIKTAR.FieldName = "MIKTAR";
            fieldMIKTAR.Name = "fieldMIKTAR";
            fieldMIKTAR.Visible = false;

            PivotGridField fieldMIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMIKTAR_DOVIZ_ID.AreaIndex = 6;
            fieldMIKTAR_DOVIZ_ID.FieldName = "MIKTAR_DOVIZ_ID";
            fieldMIKTAR_DOVIZ_ID.Name = "fieldMIKTAR_DOVIZ_ID";
            fieldMIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldKDV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV.AreaIndex = 7;
            fieldKDV.FieldName = "KDV";
            fieldKDV.Name = "fieldKDV";
            fieldKDV.Visible = false;

            PivotGridField fieldKDV_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_DOVIZ_ID.AreaIndex = 8;
            fieldKDV_DOVIZ_ID.FieldName = "KDV_DOVIZ_ID";
            fieldKDV_DOVIZ_ID.Name = "fieldKDV_DOVIZ_ID";
            fieldKDV_DOVIZ_ID.Visible = false;

            PivotGridField fieldTOPLAM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM.AreaIndex = 9;
            fieldTOPLAM.FieldName = "TOPLAM";
            fieldTOPLAM.Name = "fieldTOPLAM";
            fieldTOPLAM.Visible = false;

            PivotGridField fieldTOPLAM_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_DOVIZ_ID.AreaIndex = 10;
            fieldTOPLAM_DOVIZ_ID.FieldName = "TOPLAM_DOVIZ_ID";
            fieldTOPLAM_DOVIZ_ID.Name = "fieldTOPLAM_DOVIZ_ID";
            fieldTOPLAM_DOVIZ_ID.Visible = false;

            PivotGridField fieldFATURA_TARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFATURA_TARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFATURA_TARIH.AreaIndex = 11;
            fieldFATURA_TARIH.FieldName = "FATURA_TARIH";
            fieldFATURA_TARIH.Name = "fieldFATURA_TARIH";
            fieldFATURA_TARIH.Visible = false;

            PivotGridField fieldSERI_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSERI_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSERI_NO.AreaIndex = 12;
            fieldSERI_NO.FieldName = "SERI_NO";
            fieldSERI_NO.Name = "fieldSERI_NO";
            fieldSERI_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 13;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 14;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 15;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 16;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 17;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 18;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 19;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 20;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldTAKIP_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN.AreaIndex = 21;
            fieldTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            fieldTAKIP_EDEN.Name = "fieldTAKIP_EDEN";
            fieldTAKIP_EDEN.Visible = false;

            PivotGridField fieldTAKIP_EDILEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN.AreaIndex = 22;
            fieldTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            fieldTAKIP_EDILEN.Name = "fieldTAKIP_EDILEN";
            fieldTAKIP_EDILEN.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 23;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 24;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = null;
            switch (pencere)
            {
                case "Serbest Meslek Makbuzu Listesi (Müvekkillere Göre)":
                    dizi = SerbestMeslekMakbuzuMuvekkillere();
                    break;

                case "Serbest Meslek Makbuzu Listesi (Yıllara Göre)":
                    dizi = SerbestMeslekMakbuzuYillaraGore();
                    break;

                case "Serbest Meslek Makbuzu Listesi (Yıllara ve Modüllere Göre)":
                    dizi = SerbestMeslekMakbuzuYıllaraModullereGore();
                    break;
                default:
                    break;
            }

            #region []

            if (dizi == null)
            {
                dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldID,
			fieldFATURA_HEDEF_TIP,
			fieldFATURA_KAPSAM_TIP,
			fieldSAHIS,
			fieldMIKTAR,
			fieldMIKTAR_DOVIZ_ID,
			fieldKDV,
			fieldKDV_DOVIZ_ID,
			fieldTOPLAM,
			fieldTOPLAM_DOVIZ_ID,
			fieldFATURA_TARIH,
			fieldSERI_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldFOY_NO,
			fieldESAS_NO,
			fieldDURUM,
			fieldADLIYE,
			fieldNO,
			fieldGOREV,
			fieldTAKIP_EDEN,
			fieldTAKIP_EDILEN,
			fieldIZLEYEN,
			fieldSORUMLU,
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

            dicFieldCaption.Add("REFERANS_NO", "Referans No");
            dicFieldCaption.Add("ID", "Dosya Sayısı");
            dicFieldCaption.Add("FATURA_HEDEF_TIP", "Hedef Tip");
            dicFieldCaption.Add("FATURA_KAPSAM_TIP", "Kapsam Tip");
            dicFieldCaption.Add("SAHIS", "Şahıs");
            dicFieldCaption.Add("MIKTAR", "Miktar");
            dicFieldCaption.Add("KDV", "Kdv");
            dicFieldCaption.Add("TOPLAM", "Toplam");
            dicFieldCaption.Add("FATURA_TARIH", "Fatura T");
            dicFieldCaption.Add("SERI_NO", "Seri No");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("DURUM", "Dosya Durum");
            dicFieldCaption.Add("ADLIYE", "Adliye");
            dicFieldCaption.Add("NO", "No");
            dicFieldCaption.Add("GOREV", "Görev");
            dicFieldCaption.Add("TAKIP_EDEN", "Müvekkil");
            dicFieldCaption.Add("TAKIP_EDILEN", "Karşı Taraf");
            dicFieldCaption.Add("IZLEYEN", "İzleyen");
            dicFieldCaption.Add("SORUMLU", "Sorumlu");

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
            sozluk.Add("FATURA_HEDEF_TIP", InitsEx.FaturaHedefTip);
            sozluk.Add("FATURA_KAPSAM_TIP", InitsEx.FaturaKapsamTip);

            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("MIKTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("MIKTAR_DOVIZ_ID", InitsEx.DovizTipGetir);

            #endregion Add item

            return sozluk;
        }

        private PivotGridField[] SerbestMeslekMakbuzuMuvekkillere()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 1;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldFATURA_HEDEF_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFATURA_HEDEF_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFATURA_HEDEF_TIP.AreaIndex = 2;
            fieldFATURA_HEDEF_TIP.FieldName = "FATURA_HEDEF_TIP";
            fieldFATURA_HEDEF_TIP.Name = "fieldFATURA_HEDEF_TIP";
            fieldFATURA_HEDEF_TIP.Visible = false;

            PivotGridField fieldFATURA_KAPSAM_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFATURA_KAPSAM_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFATURA_KAPSAM_TIP.AreaIndex = 3;
            fieldFATURA_KAPSAM_TIP.FieldName = "FATURA_KAPSAM_TIP";
            fieldFATURA_KAPSAM_TIP.Name = "fieldFATURA_KAPSAM_TIP";
            fieldFATURA_KAPSAM_TIP.Visible = false;

            PivotGridField fieldSAHIS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSAHIS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSAHIS.AreaIndex = 4;
            fieldSAHIS.FieldName = "SAHIS";
            fieldSAHIS.Name = "fieldSAHIS";
            fieldSAHIS.Visible = false;

            PivotGridField fieldMIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMIKTAR.AreaIndex = 5;
            fieldMIKTAR.FieldName = "MIKTAR";
            fieldMIKTAR.Name = "fieldMIKTAR";
            fieldMIKTAR.Visible = false;

            PivotGridField fieldMIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMIKTAR_DOVIZ_ID.AreaIndex = 6;
            fieldMIKTAR_DOVIZ_ID.FieldName = "MIKTAR_DOVIZ_ID";
            fieldMIKTAR_DOVIZ_ID.Name = "fieldMIKTAR_DOVIZ_ID";
            fieldMIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldKDV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV.AreaIndex = 7;
            fieldKDV.FieldName = "KDV";
            fieldKDV.Name = "fieldKDV";
            fieldKDV.Visible = false;

            PivotGridField fieldKDV_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_DOVIZ_ID.AreaIndex = 8;
            fieldKDV_DOVIZ_ID.FieldName = "KDV_DOVIZ_ID";
            fieldKDV_DOVIZ_ID.Name = "fieldKDV_DOVIZ_ID";
            fieldKDV_DOVIZ_ID.Visible = false;

            PivotGridField fieldTOPLAM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTOPLAM.AreaIndex = 9;
            fieldTOPLAM.FieldName = "TOPLAM";
            fieldTOPLAM.Name = "fieldTOPLAM";
            fieldTOPLAM.Visible = true;

            PivotGridField fieldTOPLAM_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_DOVIZ_ID.AreaIndex = 10;
            fieldTOPLAM_DOVIZ_ID.FieldName = "TOPLAM_DOVIZ_ID";
            fieldTOPLAM_DOVIZ_ID.Name = "fieldTOPLAM_DOVIZ_ID";
            fieldTOPLAM_DOVIZ_ID.Visible = false;

            PivotGridField fieldFATURA_TARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFATURA_TARIH.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldFATURA_TARIH.GroupInterval = PivotGroupInterval.DateYear;
            fieldFATURA_TARIH.AreaIndex = 11;
            fieldFATURA_TARIH.FieldName = "FATURA_TARIH";
            fieldFATURA_TARIH.Name = "fieldFATURA_TARIH";
            fieldFATURA_TARIH.Visible = true;

            PivotGridField fieldSERI_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSERI_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSERI_NO.AreaIndex = 12;
            fieldSERI_NO.FieldName = "SERI_NO";
            fieldSERI_NO.Name = "fieldSERI_NO";
            fieldSERI_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 13;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 14;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 15;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 16;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = true;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 17;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldADLIYE.AreaIndex = 18;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = true;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 19;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 20;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldTAKIP_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_EDEN.AreaIndex = 21;
            fieldTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            fieldTAKIP_EDEN.Name = "fieldTAKIP_EDEN";
            fieldTAKIP_EDEN.Visible = true;

            PivotGridField fieldTAKIP_EDILEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN.AreaIndex = 22;
            fieldTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            fieldTAKIP_EDILEN.Name = "fieldTAKIP_EDILEN";
            fieldTAKIP_EDILEN.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 23;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 24;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldID,
			fieldFATURA_HEDEF_TIP,
			fieldFATURA_KAPSAM_TIP,
			fieldSAHIS,
			fieldMIKTAR,
			fieldMIKTAR_DOVIZ_ID,
			fieldKDV,
			fieldKDV_DOVIZ_ID,
			fieldTOPLAM,
			fieldTOPLAM_DOVIZ_ID,
			fieldFATURA_TARIH,
			fieldSERI_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldFOY_NO,
			fieldESAS_NO,
			fieldDURUM,
			fieldADLIYE,
			fieldNO,
			fieldGOREV,
			fieldTAKIP_EDEN,
			fieldTAKIP_EDILEN,
			fieldIZLEYEN,
			fieldSORUMLU,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] SerbestMeslekMakbuzuYıllaraModullereGore()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 1;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldFATURA_HEDEF_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFATURA_HEDEF_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldFATURA_HEDEF_TIP.AreaIndex = 2;
            fieldFATURA_HEDEF_TIP.FieldName = "FATURA_HEDEF_TIP";
            fieldFATURA_HEDEF_TIP.Name = "fieldFATURA_HEDEF_TIP";
            fieldFATURA_HEDEF_TIP.Visible = true;

            PivotGridField fieldFATURA_KAPSAM_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFATURA_KAPSAM_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFATURA_KAPSAM_TIP.AreaIndex = 3;
            fieldFATURA_KAPSAM_TIP.FieldName = "FATURA_KAPSAM_TIP";
            fieldFATURA_KAPSAM_TIP.Name = "fieldFATURA_KAPSAM_TIP";
            fieldFATURA_KAPSAM_TIP.Visible = false;

            PivotGridField fieldSAHIS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSAHIS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSAHIS.AreaIndex = 4;
            fieldSAHIS.FieldName = "SAHIS";
            fieldSAHIS.Name = "fieldSAHIS";
            fieldSAHIS.Visible = false;

            PivotGridField fieldMIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMIKTAR.AreaIndex = 5;
            fieldMIKTAR.FieldName = "MIKTAR";
            fieldMIKTAR.Name = "fieldMIKTAR";
            fieldMIKTAR.Visible = false;

            PivotGridField fieldMIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMIKTAR_DOVIZ_ID.AreaIndex = 6;
            fieldMIKTAR_DOVIZ_ID.FieldName = "MIKTAR_DOVIZ_ID";
            fieldMIKTAR_DOVIZ_ID.Name = "fieldMIKTAR_DOVIZ_ID";
            fieldMIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldKDV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV.AreaIndex = 7;
            fieldKDV.FieldName = "KDV";
            fieldKDV.Name = "fieldKDV";
            fieldKDV.Visible = false;

            PivotGridField fieldKDV_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_DOVIZ_ID.AreaIndex = 8;
            fieldKDV_DOVIZ_ID.FieldName = "KDV_DOVIZ_ID";
            fieldKDV_DOVIZ_ID.Name = "fieldKDV_DOVIZ_ID";
            fieldKDV_DOVIZ_ID.Visible = false;

            PivotGridField fieldTOPLAM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTOPLAM.AreaIndex = 9;
            fieldTOPLAM.FieldName = "TOPLAM";
            fieldTOPLAM.Name = "fieldTOPLAM";
            fieldTOPLAM.Visible = true;

            PivotGridField fieldTOPLAM_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_DOVIZ_ID.AreaIndex = 10;
            fieldTOPLAM_DOVIZ_ID.FieldName = "TOPLAM_DOVIZ_ID";
            fieldTOPLAM_DOVIZ_ID.Name = "fieldTOPLAM_DOVIZ_ID";
            fieldTOPLAM_DOVIZ_ID.Visible = false;

            PivotGridField fieldFATURA_TARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFATURA_TARIH.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldFATURA_TARIH.GroupInterval = PivotGroupInterval.DateYear;
            fieldFATURA_TARIH.AreaIndex = 11;
            fieldFATURA_TARIH.FieldName = "FATURA_TARIH";
            fieldFATURA_TARIH.Name = "fieldFATURA_TARIH";
            fieldFATURA_TARIH.Visible = true;

            PivotGridField fieldSERI_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSERI_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSERI_NO.AreaIndex = 12;
            fieldSERI_NO.FieldName = "SERI_NO";
            fieldSERI_NO.Name = "fieldSERI_NO";
            fieldSERI_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 13;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 14;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 15;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 16;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = true;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 17;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldADLIYE.AreaIndex = 18;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = true;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 19;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 20;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldTAKIP_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_EDEN.AreaIndex = 21;
            fieldTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            fieldTAKIP_EDEN.Name = "fieldTAKIP_EDEN";
            fieldTAKIP_EDEN.Visible = false;

            PivotGridField fieldTAKIP_EDILEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN.AreaIndex = 22;
            fieldTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            fieldTAKIP_EDILEN.Name = "fieldTAKIP_EDILEN";
            fieldTAKIP_EDILEN.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 23;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 24;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldID,
			fieldFATURA_HEDEF_TIP,
			fieldFATURA_KAPSAM_TIP,
			fieldSAHIS,
			fieldMIKTAR,
			fieldMIKTAR_DOVIZ_ID,
			fieldKDV,
			fieldKDV_DOVIZ_ID,
			fieldTOPLAM,
			fieldTOPLAM_DOVIZ_ID,
			fieldFATURA_TARIH,
			fieldSERI_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldFOY_NO,
			fieldESAS_NO,
			fieldDURUM,
			fieldADLIYE,
			fieldNO,
			fieldGOREV,
			fieldTAKIP_EDEN,
			fieldTAKIP_EDILEN,
			fieldIZLEYEN,
			fieldSORUMLU,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] SerbestMeslekMakbuzuYillaraGore()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 1;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldFATURA_HEDEF_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFATURA_HEDEF_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFATURA_HEDEF_TIP.AreaIndex = 2;
            fieldFATURA_HEDEF_TIP.FieldName = "FATURA_HEDEF_TIP";
            fieldFATURA_HEDEF_TIP.Name = "fieldFATURA_HEDEF_TIP";
            fieldFATURA_HEDEF_TIP.Visible = false;

            PivotGridField fieldFATURA_KAPSAM_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFATURA_KAPSAM_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFATURA_KAPSAM_TIP.AreaIndex = 3;
            fieldFATURA_KAPSAM_TIP.FieldName = "FATURA_KAPSAM_TIP";
            fieldFATURA_KAPSAM_TIP.Name = "fieldFATURA_KAPSAM_TIP";
            fieldFATURA_KAPSAM_TIP.Visible = false;

            PivotGridField fieldSAHIS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSAHIS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSAHIS.AreaIndex = 4;
            fieldSAHIS.FieldName = "SAHIS";
            fieldSAHIS.Name = "fieldSAHIS";
            fieldSAHIS.Visible = false;

            PivotGridField fieldMIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMIKTAR.AreaIndex = 5;
            fieldMIKTAR.FieldName = "MIKTAR";
            fieldMIKTAR.Name = "fieldMIKTAR";
            fieldMIKTAR.Visible = false;

            PivotGridField fieldMIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMIKTAR_DOVIZ_ID.AreaIndex = 6;
            fieldMIKTAR_DOVIZ_ID.FieldName = "MIKTAR_DOVIZ_ID";
            fieldMIKTAR_DOVIZ_ID.Name = "fieldMIKTAR_DOVIZ_ID";
            fieldMIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldKDV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV.AreaIndex = 7;
            fieldKDV.FieldName = "KDV";
            fieldKDV.Name = "fieldKDV";
            fieldKDV.Visible = false;

            PivotGridField fieldKDV_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_DOVIZ_ID.AreaIndex = 8;
            fieldKDV_DOVIZ_ID.FieldName = "KDV_DOVIZ_ID";
            fieldKDV_DOVIZ_ID.Name = "fieldKDV_DOVIZ_ID";
            fieldKDV_DOVIZ_ID.Visible = false;

            PivotGridField fieldTOPLAM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTOPLAM.AreaIndex = 9;
            fieldTOPLAM.FieldName = "TOPLAM";
            fieldTOPLAM.Name = "fieldTOPLAM";
            fieldTOPLAM.Visible = true;

            PivotGridField fieldTOPLAM_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_DOVIZ_ID.AreaIndex = 10;
            fieldTOPLAM_DOVIZ_ID.FieldName = "TOPLAM_DOVIZ_ID";
            fieldTOPLAM_DOVIZ_ID.Name = "fieldTOPLAM_DOVIZ_ID";
            fieldTOPLAM_DOVIZ_ID.Visible = false;

            PivotGridField fieldFATURA_TARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFATURA_TARIH.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldFATURA_TARIH.GroupInterval = PivotGroupInterval.DateYear;
            fieldFATURA_TARIH.AreaIndex = 11;
            fieldFATURA_TARIH.FieldName = "FATURA_TARIH";
            fieldFATURA_TARIH.Name = "fieldFATURA_TARIH";
            fieldFATURA_TARIH.Visible = true;

            PivotGridField fieldSERI_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSERI_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSERI_NO.AreaIndex = 12;
            fieldSERI_NO.FieldName = "SERI_NO";
            fieldSERI_NO.Name = "fieldSERI_NO";
            fieldSERI_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 13;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 14;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 15;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 16;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = true;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 17;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldADLIYE.AreaIndex = 18;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = true;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 19;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 20;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldTAKIP_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_EDEN.AreaIndex = 21;
            fieldTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            fieldTAKIP_EDEN.Name = "fieldTAKIP_EDEN";
            fieldTAKIP_EDEN.Visible = false;

            PivotGridField fieldTAKIP_EDILEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN.AreaIndex = 22;
            fieldTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            fieldTAKIP_EDILEN.Name = "fieldTAKIP_EDILEN";
            fieldTAKIP_EDILEN.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 23;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 24;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldID,
			fieldFATURA_HEDEF_TIP,
			fieldFATURA_KAPSAM_TIP,
			fieldSAHIS,
			fieldMIKTAR,
			fieldMIKTAR_DOVIZ_ID,
			fieldKDV,
			fieldKDV_DOVIZ_ID,
			fieldTOPLAM,
			fieldTOPLAM_DOVIZ_ID,
			fieldFATURA_TARIH,
			fieldSERI_NO,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldFOY_NO,
			fieldESAS_NO,
			fieldDURUM,
			fieldADLIYE,
			fieldNO,
			fieldGOREV,
			fieldTAKIP_EDEN,
			fieldTAKIP_EDILEN,
			fieldIZLEYEN,
			fieldSORUMLU,
			};

            #endregion []

            return dizi;
        }
    }
}