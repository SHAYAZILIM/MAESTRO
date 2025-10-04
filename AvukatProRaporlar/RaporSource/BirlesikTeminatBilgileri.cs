using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class BirlesikTeminatBilgileri
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

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 0;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colHESAP_NO = new GridColumn();
            colHESAP_NO.VisibleIndex = 1;
            colHESAP_NO.FieldName = "HESAP_NO";
            colHESAP_NO.Name = "colHESAP_NO";
            colHESAP_NO.Visible = true;

            GridColumn colTARIHI = new GridColumn();
            colTARIHI.VisibleIndex = 2;
            colTARIHI.FieldName = "TARIHI";
            colTARIHI.Name = "colTARIHI";
            colTARIHI.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 3;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colSURE_TIP = new GridColumn();
            colSURE_TIP.VisibleIndex = 4;
            colSURE_TIP.FieldName = "SURE_TIP";
            colSURE_TIP.Name = "colSURE_TIP";
            colSURE_TIP.Visible = true;

            GridColumn colVADE_TARIHI = new GridColumn();
            colVADE_TARIHI.VisibleIndex = 5;
            colVADE_TARIHI.FieldName = "VADE_TARIHI";
            colVADE_TARIHI.Name = "colVADE_TARIHI";
            colVADE_TARIHI.Visible = true;

            GridColumn colTUTARI = new GridColumn();
            colTUTARI.VisibleIndex = 6;
            colTUTARI.FieldName = "TUTARI";
            colTUTARI.Name = "colTUTARI";
            colTUTARI.Visible = true;

            GridColumn colTUTARI_DOVIZ_ID = new GridColumn();
            colTUTARI_DOVIZ_ID.VisibleIndex = 7;
            colTUTARI_DOVIZ_ID.FieldName = "TUTARI_DOVIZ_ID";
            colTUTARI_DOVIZ_ID.Name = "colTUTARI_DOVIZ_ID";
            colTUTARI_DOVIZ_ID.Visible = true;

            GridColumn colTAZMIN_TALEP_BASLANGIC_TARIHI = new GridColumn();
            colTAZMIN_TALEP_BASLANGIC_TARIHI.VisibleIndex = 8;
            colTAZMIN_TALEP_BASLANGIC_TARIHI.FieldName = "TAZMIN_TALEP_BASLANGIC_TARIHI";
            colTAZMIN_TALEP_BASLANGIC_TARIHI.Name = "colTAZMIN_TALEP_BASLANGIC_TARIHI";
            colTAZMIN_TALEP_BASLANGIC_TARIHI.Visible = true;

            GridColumn colTAZMIN_TALEP_BITIS_TARIHI = new GridColumn();
            colTAZMIN_TALEP_BITIS_TARIHI.VisibleIndex = 9;
            colTAZMIN_TALEP_BITIS_TARIHI.FieldName = "TAZMIN_TALEP_BITIS_TARIHI";
            colTAZMIN_TALEP_BITIS_TARIHI.Name = "colTAZMIN_TALEP_BITIS_TARIHI";
            colTAZMIN_TALEP_BITIS_TARIHI.Visible = true;

            GridColumn colODEME_TARIHI = new GridColumn();
            colODEME_TARIHI.VisibleIndex = 10;
            colODEME_TARIHI.FieldName = "ODEME_TARIHI";
            colODEME_TARIHI.Name = "colODEME_TARIHI";
            colODEME_TARIHI.Visible = true;

            GridColumn colTAZMIN_TUTARI_DOVIZ_ID = new GridColumn();
            colTAZMIN_TUTARI_DOVIZ_ID.VisibleIndex = 11;
            colTAZMIN_TUTARI_DOVIZ_ID.FieldName = "TAZMIN_TUTARI_DOVIZ_ID";
            colTAZMIN_TUTARI_DOVIZ_ID.Name = "colTAZMIN_TUTARI_DOVIZ_ID";
            colTAZMIN_TUTARI_DOVIZ_ID.Visible = true;

            GridColumn colTAZMIN_TUTARI = new GridColumn();
            colTAZMIN_TUTARI.VisibleIndex = 12;
            colTAZMIN_TUTARI.FieldName = "TAZMIN_TUTARI";
            colTAZMIN_TUTARI.Name = "colTAZMIN_TUTARI";
            colTAZMIN_TUTARI.Visible = true;

            GridColumn colTEMINAT_TUTARI = new GridColumn();
            colTEMINAT_TUTARI.VisibleIndex = 13;
            colTEMINAT_TUTARI.FieldName = "TEMINAT_TUTARI";
            colTEMINAT_TUTARI.Name = "colTEMINAT_TUTARI";
            colTEMINAT_TUTARI.Visible = true;

            GridColumn colTEMINAT_TUTARI_DOVIZ_ID = new GridColumn();
            colTEMINAT_TUTARI_DOVIZ_ID.VisibleIndex = 14;
            colTEMINAT_TUTARI_DOVIZ_ID.FieldName = "TEMINAT_TUTARI_DOVIZ_ID";
            colTEMINAT_TUTARI_DOVIZ_ID.Name = "colTEMINAT_TUTARI_DOVIZ_ID";
            colTEMINAT_TUTARI_DOVIZ_ID.Visible = true;

            GridColumn colTEMINAT_IADE_TARIHI = new GridColumn();
            colTEMINAT_IADE_TARIHI.VisibleIndex = 15;
            colTEMINAT_IADE_TARIHI.FieldName = "TEMINAT_IADE_TARIHI";
            colTEMINAT_IADE_TARIHI.Name = "colTEMINAT_IADE_TARIHI";
            colTEMINAT_IADE_TARIHI.Visible = true;

            GridColumn colMUVEKKILE_TESLIM_TARIHI = new GridColumn();
            colMUVEKKILE_TESLIM_TARIHI.VisibleIndex = 16;
            colMUVEKKILE_TESLIM_TARIHI.FieldName = "MUVEKKILE_TESLIM_TARIHI";
            colMUVEKKILE_TESLIM_TARIHI.Name = "colMUVEKKILE_TESLIM_TARIHI";
            colMUVEKKILE_TESLIM_TARIHI.Visible = true;

            GridColumn colFOY_ID = new GridColumn();
            colFOY_ID.VisibleIndex = 17;
            colFOY_ID.FieldName = "FOY_ID";
            colFOY_ID.Name = "colFOY_ID";
            colFOY_ID.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 18;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colMODUL = new GridColumn();
            colMODUL.VisibleIndex = 19;
            colMODUL.FieldName = "MODUL";
            colMODUL.Name = "colMODUL";
            colMODUL.Visible = true;

            GridColumn colTIP = new GridColumn();
            colTIP.VisibleIndex = 20;
            colTIP.FieldName = "TIP";
            colTIP.Name = "colTIP";
            colTIP.Visible = true;

            GridColumn colMEKTUP_KONU = new GridColumn();
            colMEKTUP_KONU.VisibleIndex = 21;
            colMEKTUP_KONU.FieldName = "MEKTUP_KONU";
            colMEKTUP_KONU.Name = "colMEKTUP_KONU";
            colMEKTUP_KONU.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 22;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colBANKA_SUBE = new GridColumn();
            colBANKA_SUBE.VisibleIndex = 23;
            colBANKA_SUBE.FieldName = "BANKA_SUBE";
            colBANKA_SUBE.Name = "colBANKA_SUBE";
            colBANKA_SUBE.Visible = true;

            GridColumn colTEMINAT_TUR = new GridColumn();
            colTEMINAT_TUR.VisibleIndex = 24;
            colTEMINAT_TUR.FieldName = "TEMINAT_TUR";
            colTEMINAT_TUR.Name = "colTEMINAT_TUR";
            colTEMINAT_TUR.Visible = true;

            GridColumn colLEHTAR_ADI = new GridColumn();
            colLEHTAR_ADI.VisibleIndex = 25;
            colLEHTAR_ADI.FieldName = "LEHTAR_ADI";
            colLEHTAR_ADI.Name = "colLEHTAR_ADI";
            colLEHTAR_ADI.Visible = true;

            GridColumn colTESLIM_ALAN = new GridColumn();
            colTESLIM_ALAN.VisibleIndex = 26;
            colTESLIM_ALAN.FieldName = "TESLIM_ALAN";
            colTESLIM_ALAN.Name = "colTESLIM_ALAN";
            colTESLIM_ALAN.Visible = true;

            GridColumn colADLI_BIRIM_ADLIYE = new GridColumn();
            colADLI_BIRIM_ADLIYE.VisibleIndex = 27;
            colADLI_BIRIM_ADLIYE.FieldName = "ADLI_BIRIM_ADLIYE";
            colADLI_BIRIM_ADLIYE.Name = "colADLI_BIRIM_ADLIYE";
            colADLI_BIRIM_ADLIYE.Visible = true;

            GridColumn colADLI_BIRIM_GOREV = new GridColumn();
            colADLI_BIRIM_GOREV.VisibleIndex = 28;
            colADLI_BIRIM_GOREV.FieldName = "ADLI_BIRIM_GOREV";
            colADLI_BIRIM_GOREV.Name = "colADLI_BIRIM_GOREV";
            colADLI_BIRIM_GOREV.Visible = true;

            GridColumn colADLI_BIRIM_NO = new GridColumn();
            colADLI_BIRIM_NO.VisibleIndex = 29;
            colADLI_BIRIM_NO.FieldName = "ADLI_BIRIM_NO";
            colADLI_BIRIM_NO.Name = "colADLI_BIRIM_NO";
            colADLI_BIRIM_NO.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 30;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 31;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			//colID,
			colHESAP_NO,
			colTARIHI,
			colREFERANS_NO,
			colSURE_TIP,
			colVADE_TARIHI,
			colTUTARI,
			colTUTARI_DOVIZ_ID,
			colTAZMIN_TALEP_BASLANGIC_TARIHI,
			colTAZMIN_TALEP_BITIS_TARIHI,
			colODEME_TARIHI,
			colTAZMIN_TUTARI_DOVIZ_ID,
			colTAZMIN_TUTARI,
			colTEMINAT_TUTARI,
			colTEMINAT_TUTARI_DOVIZ_ID,
			colTEMINAT_IADE_TARIHI,
			colMUVEKKILE_TESLIM_TARIHI,
			colFOY_ID,
			colESAS_NO,
			colMODUL,
			colTIP,
			colMEKTUP_KONU,
			colBANKA,
			colBANKA_SUBE,
			colTEMINAT_TUR,
			colLEHTAR_ADI,
			colTESLIM_ALAN,
			colADLI_BIRIM_ADLIYE,
			colADLI_BIRIM_GOREV,
			colADLI_BIRIM_NO,
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
                {
                    dizi[i].Caption = caption;
                }
                else if (dizi[i].FieldName.ToLower().Contains("doviz_id"))
                {
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTip = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToLower().ToString();
                }

                if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
                {
                    dizi[i].ColumnEdit = editler["DovizId"];
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTip = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToLower().ToString();
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

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldHESAP_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHESAP_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHESAP_NO.AreaIndex = 1;
            fieldHESAP_NO.FieldName = "HESAP_NO";
            fieldHESAP_NO.Name = "fieldHESAP_NO";
            fieldHESAP_NO.Visible = false;

            PivotGridField fieldTARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIHI.AreaIndex = 2;
            fieldTARIHI.FieldName = "TARIHI";
            fieldTARIHI.Name = "fieldTARIHI";
            fieldTARIHI.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 3;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldSURE_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSURE_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSURE_TIP.AreaIndex = 4;
            fieldSURE_TIP.FieldName = "SURE_TIP";
            fieldSURE_TIP.Name = "fieldSURE_TIP";
            fieldSURE_TIP.Visible = false;

            PivotGridField fieldVADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVADE_TARIHI.AreaIndex = 5;
            fieldVADE_TARIHI.FieldName = "VADE_TARIHI";
            fieldVADE_TARIHI.Name = "fieldVADE_TARIHI";
            fieldVADE_TARIHI.Visible = false;

            PivotGridField fieldTUTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTARI.AreaIndex = 6;
            fieldTUTARI.FieldName = "TUTARI";
            fieldTUTARI.Name = "fieldTUTARI";
            fieldTUTARI.Visible = false;

            PivotGridField fieldTUTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTARI_DOVIZ_ID.AreaIndex = 7;
            fieldTUTARI_DOVIZ_ID.FieldName = "TUTARI_DOVIZ_ID";
            fieldTUTARI_DOVIZ_ID.Name = "fieldTUTARI_DOVIZ_ID";
            fieldTUTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAZMIN_TALEP_BASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAZMIN_TALEP_BASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAZMIN_TALEP_BASLANGIC_TARIHI.AreaIndex = 8;
            fieldTAZMIN_TALEP_BASLANGIC_TARIHI.FieldName = "TAZMIN_TALEP_BASLANGIC_TARIHI";
            fieldTAZMIN_TALEP_BASLANGIC_TARIHI.Name = "fieldTAZMIN_TALEP_BASLANGIC_TARIHI";
            fieldTAZMIN_TALEP_BASLANGIC_TARIHI.Visible = false;

            PivotGridField fieldTAZMIN_TALEP_BITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAZMIN_TALEP_BITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAZMIN_TALEP_BITIS_TARIHI.AreaIndex = 9;
            fieldTAZMIN_TALEP_BITIS_TARIHI.FieldName = "TAZMIN_TALEP_BITIS_TARIHI";
            fieldTAZMIN_TALEP_BITIS_TARIHI.Name = "fieldTAZMIN_TALEP_BITIS_TARIHI";
            fieldTAZMIN_TALEP_BITIS_TARIHI.Visible = false;

            PivotGridField fieldODEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TARIHI.AreaIndex = 10;
            fieldODEME_TARIHI.FieldName = "ODEME_TARIHI";
            fieldODEME_TARIHI.Name = "fieldODEME_TARIHI";
            fieldODEME_TARIHI.Visible = false;

            PivotGridField fieldTAZMIN_TUTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAZMIN_TUTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAZMIN_TUTARI_DOVIZ_ID.AreaIndex = 11;
            fieldTAZMIN_TUTARI_DOVIZ_ID.FieldName = "TAZMIN_TUTARI_DOVIZ_ID";
            fieldTAZMIN_TUTARI_DOVIZ_ID.Name = "fieldTAZMIN_TUTARI_DOVIZ_ID";
            fieldTAZMIN_TUTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAZMIN_TUTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAZMIN_TUTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAZMIN_TUTARI.AreaIndex = 12;
            fieldTAZMIN_TUTARI.FieldName = "TAZMIN_TUTARI";
            fieldTAZMIN_TUTARI.Name = "fieldTAZMIN_TUTARI";
            fieldTAZMIN_TUTARI.Visible = false;

            PivotGridField fieldTEMINAT_TUTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEMINAT_TUTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEMINAT_TUTARI.AreaIndex = 13;
            fieldTEMINAT_TUTARI.FieldName = "TEMINAT_TUTARI";
            fieldTEMINAT_TUTARI.Name = "fieldTEMINAT_TUTARI";
            fieldTEMINAT_TUTARI.Visible = false;

            PivotGridField fieldTEMINAT_TUTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEMINAT_TUTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEMINAT_TUTARI_DOVIZ_ID.AreaIndex = 14;
            fieldTEMINAT_TUTARI_DOVIZ_ID.FieldName = "TEMINAT_TUTARI_DOVIZ_ID";
            fieldTEMINAT_TUTARI_DOVIZ_ID.Name = "fieldTEMINAT_TUTARI_DOVIZ_ID";
            fieldTEMINAT_TUTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTEMINAT_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEMINAT_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEMINAT_IADE_TARIHI.AreaIndex = 15;
            fieldTEMINAT_IADE_TARIHI.FieldName = "TEMINAT_IADE_TARIHI";
            fieldTEMINAT_IADE_TARIHI.Name = "fieldTEMINAT_IADE_TARIHI";
            fieldTEMINAT_IADE_TARIHI.Visible = false;

            PivotGridField fieldMUVEKKILE_TESLIM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKILE_TESLIM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKILE_TESLIM_TARIHI.AreaIndex = 16;
            fieldMUVEKKILE_TESLIM_TARIHI.FieldName = "MUVEKKILE_TESLIM_TARIHI";
            fieldMUVEKKILE_TESLIM_TARIHI.Name = "fieldMUVEKKILE_TESLIM_TARIHI";
            fieldMUVEKKILE_TESLIM_TARIHI.Visible = false;

            PivotGridField fieldFOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ID.AreaIndex = 17;
            fieldFOY_ID.FieldName = "FOY_ID";
            fieldFOY_ID.Name = "fieldFOY_ID";
            fieldFOY_ID.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 18;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldMODUL = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMODUL.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMODUL.AreaIndex = 19;
            fieldMODUL.FieldName = "MODUL";
            fieldMODUL.Name = "fieldMODUL";
            fieldMODUL.Visible = false;

            PivotGridField fieldTIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTIP.AreaIndex = 20;
            fieldTIP.FieldName = "TIP";
            fieldTIP.Name = "fieldTIP";
            fieldTIP.Visible = false;

            PivotGridField fieldMEKTUP_KONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMEKTUP_KONU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMEKTUP_KONU.AreaIndex = 21;
            fieldMEKTUP_KONU.FieldName = "MEKTUP_KONU";
            fieldMEKTUP_KONU.Name = "fieldMEKTUP_KONU";
            fieldMEKTUP_KONU.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 22;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 23;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldTEMINAT_TUR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEMINAT_TUR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEMINAT_TUR.AreaIndex = 24;
            fieldTEMINAT_TUR.FieldName = "TEMINAT_TUR";
            fieldTEMINAT_TUR.Name = "fieldTEMINAT_TUR";
            fieldTEMINAT_TUR.Visible = false;

            PivotGridField fieldLEHTAR_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldLEHTAR_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldLEHTAR_ADI.AreaIndex = 25;
            fieldLEHTAR_ADI.FieldName = "LEHTAR_ADI";
            fieldLEHTAR_ADI.Name = "fieldLEHTAR_ADI";
            fieldLEHTAR_ADI.Visible = false;

            PivotGridField fieldTESLIM_ALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTESLIM_ALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTESLIM_ALAN.AreaIndex = 26;
            fieldTESLIM_ALAN.FieldName = "TESLIM_ALAN";
            fieldTESLIM_ALAN.Name = "fieldTESLIM_ALAN";
            fieldTESLIM_ALAN.Visible = false;

            PivotGridField fieldADLI_BIRIM_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_ADLIYE.AreaIndex = 27;
            fieldADLI_BIRIM_ADLIYE.FieldName = "ADLI_BIRIM_ADLIYE";
            fieldADLI_BIRIM_ADLIYE.Name = "fieldADLI_BIRIM_ADLIYE";
            fieldADLI_BIRIM_ADLIYE.Visible = false;

            PivotGridField fieldADLI_BIRIM_GOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_GOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_GOREV.AreaIndex = 28;
            fieldADLI_BIRIM_GOREV.FieldName = "ADLI_BIRIM_GOREV";
            fieldADLI_BIRIM_GOREV.Name = "fieldADLI_BIRIM_GOREV";
            fieldADLI_BIRIM_GOREV.Visible = false;

            PivotGridField fieldADLI_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_NO.AreaIndex = 29;
            fieldADLI_BIRIM_NO.FieldName = "ADLI_BIRIM_NO";
            fieldADLI_BIRIM_NO.Name = "fieldADLI_BIRIM_NO";
            fieldADLI_BIRIM_NO.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 30;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 31;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldHESAP_NO,
			fieldTARIHI,
			fieldREFERANS_NO,
			fieldSURE_TIP,
			fieldVADE_TARIHI,
			fieldTUTARI,
			fieldTUTARI_DOVIZ_ID,
			fieldTAZMIN_TALEP_BASLANGIC_TARIHI,
			fieldTAZMIN_TALEP_BITIS_TARIHI,
			fieldODEME_TARIHI,
			fieldTAZMIN_TUTARI_DOVIZ_ID,
			fieldTAZMIN_TUTARI,
			fieldTEMINAT_TUTARI,
			fieldTEMINAT_TUTARI_DOVIZ_ID,
			fieldTEMINAT_IADE_TARIHI,
			fieldMUVEKKILE_TESLIM_TARIHI,
			fieldFOY_ID,
			fieldESAS_NO,
			fieldMODUL,
			fieldTIP,
			fieldMEKTUP_KONU,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldTEMINAT_TUR,
			fieldLEHTAR_ADI,
			fieldTESLIM_ALAN,
			fieldADLI_BIRIM_ADLIYE,
			fieldADLI_BIRIM_GOREV,
			fieldADLI_BIRIM_NO,
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
                {
                    dizi[i].Caption = caption;
                }
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

            #region Caption Edit

            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("HESAP_NO", "Hesap No");
            dicFieldCaption.Add("TARIHI", "Tarihi");
            dicFieldCaption.Add("REFERANS_NO", "Ref No");
            dicFieldCaption.Add("SURE_TIP", "Süre Tip");
            dicFieldCaption.Add("VADE_TARIHI", "Vade T.");
            dicFieldCaption.Add("TUTARI", "Tutarı");
            dicFieldCaption.Add("TAZMIN_TALEP_BASLANGIC_TARIHI", "Tazmin Talep Baslangıç T.");
            dicFieldCaption.Add("TAZMIN_TALEP_BITIS_TARIHI", "Tazmin Talep Bitiş T.");
            dicFieldCaption.Add("ODEME_TARIHI", "Ödeme T.");
            dicFieldCaption.Add("TAZMIN_TUTARI", "Tazmin Tutarı");
            dicFieldCaption.Add("TEMINAT_TUTARI", "Teminat Tutarı");
            dicFieldCaption.Add("TEMINAT_IADE_TARIHI", "Teminat İade T.");
            dicFieldCaption.Add("MUVEKKILE_TESLIM_TARIHI", "Müvekkile Teslim T.");
            dicFieldCaption.Add("FOY_ID", "");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("MODUL", "Modul");
            dicFieldCaption.Add("TIP", "Tip");
            dicFieldCaption.Add("MEKTUP_KONU", "Mektup Konu");
            dicFieldCaption.Add("BANKA", "Banka");
            dicFieldCaption.Add("BANKA_SUBE", "Banka Şube");
            dicFieldCaption.Add("TEMINAT_TUR", "Teminat Tür");
            dicFieldCaption.Add("LEHTAR_ADI", "Lehtar");
            dicFieldCaption.Add("TESLIM_ALAN", "Teslim Alan");
            dicFieldCaption.Add("ADLI_BIRIM_ADLIYE", "Adliye");
            dicFieldCaption.Add("ADLI_BIRIM_GOREV", "Görev");
            dicFieldCaption.Add("ADLI_BIRIM_NO", "No");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            //RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

            //Inits.DovizTipGetir(InitsEx

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("DovizId", InitsEx.DovizTipGetir);

            sozluk.Add("TUTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TUTARI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TAZMIN_TUTARI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TAZMIN_TUTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TEMINAT_TUTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TEMINAT_TUTARI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.TarafKodu);
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);

            #endregion Add item

            return sozluk;
        }
    }
}