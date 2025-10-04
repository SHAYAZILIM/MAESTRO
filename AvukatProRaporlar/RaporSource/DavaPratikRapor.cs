using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    internal class DavaPratikRapor
    {

        public GridColumn[] GetGridColumns()
        {
            #region Field & Properties

            GridColumn colDAVACI = new GridColumn();
            colDAVACI.VisibleIndex = 0;
            colDAVACI.FieldName = "DAVACI";
            colDAVACI.Name = "colDAVACI";
            colDAVACI.Visible = true;

            GridColumn colTAKIP_EDEN_TARAF_KODU = new GridColumn();
            colTAKIP_EDEN_TARAF_KODU.VisibleIndex = 1;
            colTAKIP_EDEN_TARAF_KODU.FieldName = "TAKIP_EDEN_TARAF_KODU";
            colTAKIP_EDEN_TARAF_KODU.Name = "colTAKIP_EDEN_TARAF_KODU";
            colTAKIP_EDEN_TARAF_KODU.Visible = true;

            GridColumn colDAVALI = new GridColumn();
            colDAVALI.VisibleIndex = 2;
            colDAVALI.FieldName = "DAVALI";
            colDAVALI.Name = "colDAVALI";
            colDAVALI.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 3;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 4;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colTAKIP_EDILEN_TARAF_KODU = new GridColumn();
            colTAKIP_EDILEN_TARAF_KODU.VisibleIndex = 5;
            colTAKIP_EDILEN_TARAF_KODU.FieldName = "TAKIP_EDILEN_TARAF_KODU";
            colTAKIP_EDILEN_TARAF_KODU.Name = "colTAKIP_EDILEN_TARAF_KODU";
            colTAKIP_EDILEN_TARAF_KODU.Visible = true;

            GridColumn colDAVA_EDEN_SIFAT = new GridColumn();
            colDAVA_EDEN_SIFAT.VisibleIndex = 6;
            colDAVA_EDEN_SIFAT.FieldName = "DAVA_EDEN_SIFAT";
            colDAVA_EDEN_SIFAT.Name = "colDAVA_EDEN_SIFAT";
            colDAVA_EDEN_SIFAT.Visible = true;

            GridColumn colDAVA_EDILEN_SIFAT = new GridColumn();
            colDAVA_EDILEN_SIFAT.VisibleIndex = 7;
            colDAVA_EDILEN_SIFAT.FieldName = "DAVA_EDILEN_SIFAT";
            colDAVA_EDILEN_SIFAT.Name = "colDAVA_EDILEN_SIFAT";
            colDAVA_EDILEN_SIFAT.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 8;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colDAVA_TALEP = new GridColumn();
            colDAVA_TALEP.VisibleIndex = 9;
            colDAVA_TALEP.FieldName = "DAVA_TALEP";
            colDAVA_TALEP.Name = "colDAVA_TALEP";
            colDAVA_TALEP.Visible = true;

            GridColumn colBIRIM = new GridColumn();
            colBIRIM.VisibleIndex = 10;
            colBIRIM.FieldName = "BIRIM";
            colBIRIM.Name = "colBIRIM";
            colBIRIM.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 11;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 12;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colREFERANS_NO2 = new GridColumn();
            colREFERANS_NO2.VisibleIndex = 13;
            colREFERANS_NO2.FieldName = "REFERANS_NO2";
            colREFERANS_NO2.Name = "colREFERANS_NO2";
            colREFERANS_NO2.Visible = true;

            GridColumn colREFERANS_NO3 = new GridColumn();
            colREFERANS_NO3.VisibleIndex = 14;
            colREFERANS_NO3.FieldName = "REFERANS_NO3";
            colREFERANS_NO3.Name = "colREFERANS_NO3";
            colREFERANS_NO3.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 15;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colDAVA_TARIHI = new GridColumn();
            colDAVA_TARIHI.VisibleIndex = 16;
            colDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            colDAVA_TARIHI.Name = "colDAVA_TARIHI";
            colDAVA_TARIHI.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 17;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 18;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 19;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 20;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colAVUKATA_INTIKAL_TARIHI = new GridColumn();
            colAVUKATA_INTIKAL_TARIHI.VisibleIndex = 21;
            colAVUKATA_INTIKAL_TARIHI.FieldName = "AVUKATA_INTIKAL_TARIHI";
            colAVUKATA_INTIKAL_TARIHI.Name = "colAVUKATA_INTIKAL_TARIHI";
            colAVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colOzelKod1 = new GridColumn();
            colOzelKod1.VisibleIndex = 22;
            colOzelKod1.FieldName = "OzelKod1";
            colOzelKod1.Name = "colOzelKod1";
            colOzelKod1.Visible = true;

            GridColumn colOzelKod2 = new GridColumn();
            colOzelKod2.VisibleIndex = 23;
            colOzelKod2.FieldName = "OzelKod2";
            colOzelKod2.Name = "colOzelKod2";
            colOzelKod2.Visible = true;

            GridColumn colOzelKod3 = new GridColumn();
            colOzelKod3.VisibleIndex = 24;
            colOzelKod3.FieldName = "OzelKod3";
            colOzelKod3.Name = "colOzelKod3";
            colOzelKod3.Visible = true;

            GridColumn colOzelKod4 = new GridColumn();
            colOzelKod4.VisibleIndex = 25;
            colOzelKod4.FieldName = "OzelKod4";
            colOzelKod4.Name = "colOzelKod4";
            colOzelKod4.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 26;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colASAMA_ADI = new GridColumn();
            colASAMA_ADI.VisibleIndex = 27;
            colASAMA_ADI.FieldName = "ASAMA_ADI";
            colASAMA_ADI.Name = "colASAMA_ADI";
            colASAMA_ADI.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 28;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colSUBE = new GridColumn();
            colSUBE.VisibleIndex = 29;
            colSUBE.FieldName = "SUBE";
            colSUBE.Name = "colSUBE";
            colSUBE.Visible = true;

            GridColumn colFOY_BIRIM = new GridColumn();
            colFOY_BIRIM.VisibleIndex = 30;
            colFOY_BIRIM.FieldName = "FOY_BIRIM";
            colFOY_BIRIM.Name = "colFOY_BIRIM";
            colFOY_BIRIM.Visible = true;

            GridColumn colFOY_YERI = new GridColumn();
            colFOY_YERI.VisibleIndex = 31;
            colFOY_YERI.FieldName = "FOY_YERI";
            colFOY_YERI.Name = "colFOY_YERI";
            colFOY_YERI.Visible = true;

            GridColumn colFOY_OZEL_DURUM = new GridColumn();
            colFOY_OZEL_DURUM.VisibleIndex = 32;
            colFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Name = "colFOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Visible = true;

            GridColumn colTAHSILAT_DURUM = new GridColumn();
            colTAHSILAT_DURUM.VisibleIndex = 33;
            colTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            colTAHSILAT_DURUM.Name = "colTAHSILAT_DURUM";
            colTAHSILAT_DURUM.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 34;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 35;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colKLASOR_1 = new GridColumn();
            colKLASOR_1.VisibleIndex = 36;
            colKLASOR_1.FieldName = "KLASOR_1";
            colKLASOR_1.Name = "colKLASOR_1";
            colKLASOR_1.Visible = true;

            GridColumn colKLASOR_2 = new GridColumn();
            colKLASOR_2.VisibleIndex = 37;
            colKLASOR_2.FieldName = "KLASOR_2";
            colKLASOR_2.Name = "colKLASOR_2";
            colKLASOR_2.Visible = true;

            GridColumn colDIGER_DAVA_NEDEN = new GridColumn();
            colDIGER_DAVA_NEDEN.VisibleIndex = 38;
            colDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            colDIGER_DAVA_NEDEN.Name = "colDIGER_DAVA_NEDEN";
            colDIGER_DAVA_NEDEN.Visible = true;

            GridColumn colOLAY_SUC_TARIHI = new GridColumn();
            colOLAY_SUC_TARIHI.VisibleIndex = 39;
            colOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            colOLAY_SUC_TARIHI.Name = "colOLAY_SUC_TARIHI";
            colOLAY_SUC_TARIHI.Visible = true;

            GridColumn colNEDEN_REFERANS_NO1 = new GridColumn();
            colNEDEN_REFERANS_NO1.VisibleIndex = 40;
            colNEDEN_REFERANS_NO1.FieldName = "NEDEN_REFERANS_NO1";
            colNEDEN_REFERANS_NO1.Name = "colNEDEN_REFERANS_NO1";
            colNEDEN_REFERANS_NO1.Visible = true;

            GridColumn colNEDEN_REFERANS_NO2 = new GridColumn();
            colNEDEN_REFERANS_NO2.VisibleIndex = 41;
            colNEDEN_REFERANS_NO2.FieldName = "NEDEN_REFERANS_NO2";
            colNEDEN_REFERANS_NO2.Name = "colNEDEN_REFERANS_NO2";
            colNEDEN_REFERANS_NO2.Visible = true;

            GridColumn colDAVA_DEGERI = new GridColumn();
            colDAVA_DEGERI.VisibleIndex = 42;
            colDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            colDAVA_DEGERI.Name = "colDAVA_DEGERI";
            colDAVA_DEGERI.Visible = true;

            GridColumn colDAVA_DEGERI_DOVIZ_ID = new GridColumn();
            colDAVA_DEGERI_DOVIZ_ID.VisibleIndex = 43;
            colDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            colDAVA_DEGERI_DOVIZ_ID.Name = "colDAVA_DEGERI_DOVIZ_ID";
            colDAVA_DEGERI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 44;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 45;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 46;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            GridColumn colBOLGE = new GridColumn();
            colBOLGE.VisibleIndex = 47;
            colBOLGE.FieldName = "BOLGE";
            colBOLGE.Name = "colBOLGE";
            colBOLGE.Visible = true;

            GridColumn colKAPAMA_TARIHI = new GridColumn();
            colKAPAMA_TARIHI.VisibleIndex = 48;
            colKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            colKAPAMA_TARIHI.Name = "colKAPAMA_TARIHI";
            colKAPAMA_TARIHI.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colDAVACI,
			colTAKIP_EDEN_TARAF_KODU,
			colDAVALI,
			colIZLEYEN,
			colSORUMLU,
			colTAKIP_EDILEN_TARAF_KODU,
			colDAVA_EDEN_SIFAT,
			colDAVA_EDILEN_SIFAT,

			//colID,
			colDAVA_TALEP,
			colBIRIM,
			colFOY_NO,
			colREFERANS_NO,
			colREFERANS_NO2,
			colREFERANS_NO3,
			colDURUM,
			colDAVA_TARIHI,
			colADLIYE,
			colGOREV,
			colNO,
			colESAS_NO,
			colAVUKATA_INTIKAL_TARIHI,
			colOzelKod1,
			colOzelKod2,
			colOzelKod3,
			colOzelKod4,
			colACIKLAMA,
			colASAMA_ADI,
			colBANKA,
			colSUBE,
			colFOY_BIRIM,
			colFOY_YERI,
			colFOY_OZEL_DURUM,
			colTAHSILAT_DURUM,
			colKREDI_GRUP,
			colKREDI_TIP,
			colKLASOR_1,
			colKLASOR_2,
			colDIGER_DAVA_NEDEN,
			colOLAY_SUC_TARIHI,
			colNEDEN_REFERANS_NO1,
			colNEDEN_REFERANS_NO2,
			colDAVA_DEGERI,
			colDAVA_DEGERI_DOVIZ_ID,
			colSUBE_KOD_ID,
			colKONTROL_KIM_ID,
			colBOLUM,
			colBOLGE,
			colKAPAMA_TARIHI,
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

        public PivotGridField[] GetPivotFields(string pencere)
        {
            #region Field & Properties

            PivotGridField fieldDAVACI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVACI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVACI.AreaIndex = 0;
            fieldDAVACI.FieldName = "DAVACI";
            fieldDAVACI.Name = "fieldDAVACI";
            fieldDAVACI.Visible = false;

            PivotGridField fieldTAKIP_EDEN_TARAF_KODU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN_TARAF_KODU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN_TARAF_KODU.AreaIndex = 1;
            fieldTAKIP_EDEN_TARAF_KODU.FieldName = "TAKIP_EDEN_TARAF_KODU";
            fieldTAKIP_EDEN_TARAF_KODU.Name = "fieldTAKIP_EDEN_TARAF_KODU";
            fieldTAKIP_EDEN_TARAF_KODU.Visible = false;

            PivotGridField fieldDAVALI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVALI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVALI.AreaIndex = 2;
            fieldDAVALI.FieldName = "DAVALI";
            fieldDAVALI.Name = "fieldDAVALI";
            fieldDAVALI.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 3;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 4;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldTAKIP_EDILEN_TARAF_KODU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN_TARAF_KODU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN_TARAF_KODU.AreaIndex = 5;
            fieldTAKIP_EDILEN_TARAF_KODU.FieldName = "TAKIP_EDILEN_TARAF_KODU";
            fieldTAKIP_EDILEN_TARAF_KODU.Name = "fieldTAKIP_EDILEN_TARAF_KODU";
            fieldTAKIP_EDILEN_TARAF_KODU.Visible = false;

            PivotGridField fieldDAVA_EDEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_EDEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_EDEN_SIFAT.AreaIndex = 6;
            fieldDAVA_EDEN_SIFAT.FieldName = "DAVA_EDEN_SIFAT";
            fieldDAVA_EDEN_SIFAT.Name = "fieldDAVA_EDEN_SIFAT";
            fieldDAVA_EDEN_SIFAT.Visible = false;

            PivotGridField fieldDAVA_EDILEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_EDILEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_EDILEN_SIFAT.AreaIndex = 7;
            fieldDAVA_EDILEN_SIFAT.FieldName = "DAVA_EDILEN_SIFAT";
            fieldDAVA_EDILEN_SIFAT.Name = "fieldDAVA_EDILEN_SIFAT";
            fieldDAVA_EDILEN_SIFAT.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 8;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 9;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldBIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM.AreaIndex = 10;
            fieldBIRIM.FieldName = "BIRIM";
            fieldBIRIM.Name = "fieldBIRIM";
            fieldBIRIM.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 11;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 12;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldREFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO2.AreaIndex = 13;
            fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
            fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";
            fieldREFERANS_NO2.Visible = false;

            PivotGridField fieldREFERANS_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO3.AreaIndex = 14;
            fieldREFERANS_NO3.FieldName = "REFERANS_NO3";
            fieldREFERANS_NO3.Name = "fieldREFERANS_NO3";
            fieldREFERANS_NO3.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 15;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 16;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 17;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 18;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 19;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 20;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldAVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAVUKATA_INTIKAL_TARIHI.AreaIndex = 21;
            fieldAVUKATA_INTIKAL_TARIHI.FieldName = "AVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Name = "fieldAVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldOzelKod1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzelKod1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzelKod1.AreaIndex = 22;
            fieldOzelKod1.FieldName = "OzelKod1";
            fieldOzelKod1.Name = "fieldOzelKod1";
            fieldOzelKod1.Visible = false;

            PivotGridField fieldOzelKod2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzelKod2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzelKod2.AreaIndex = 23;
            fieldOzelKod2.FieldName = "OzelKod2";
            fieldOzelKod2.Name = "fieldOzelKod2";
            fieldOzelKod2.Visible = false;

            PivotGridField fieldOzelKod3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzelKod3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzelKod3.AreaIndex = 24;
            fieldOzelKod3.FieldName = "OzelKod3";
            fieldOzelKod3.Name = "fieldOzelKod3";
            fieldOzelKod3.Visible = false;

            PivotGridField fieldOzelKod4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOzelKod4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOzelKod4.AreaIndex = 25;
            fieldOzelKod4.FieldName = "OzelKod4";
            fieldOzelKod4.Name = "fieldOzelKod4";
            fieldOzelKod4.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 26;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldASAMA_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASAMA_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASAMA_ADI.AreaIndex = 27;
            fieldASAMA_ADI.FieldName = "ASAMA_ADI";
            fieldASAMA_ADI.Name = "fieldASAMA_ADI";
            fieldASAMA_ADI.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 28;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldSUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE.AreaIndex = 29;
            fieldSUBE.FieldName = "SUBE";
            fieldSUBE.Name = "fieldSUBE";
            fieldSUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 30;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 31;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 32;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 33;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 34;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 35;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 36;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 37;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 38;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOLAY_SUC_TARIHI.AreaIndex = 39;
            fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO1.AreaIndex = 40;
            fieldNEDEN_REFERANS_NO1.FieldName = "NEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Name = "fieldNEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO2.AreaIndex = 41;
            fieldNEDEN_REFERANS_NO2.FieldName = "NEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Name = "fieldNEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Visible = false;

            PivotGridField fieldDAVA_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI.AreaIndex = 42;
            fieldDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            fieldDAVA_DEGERI.Name = "fieldDAVA_DEGERI";
            fieldDAVA_DEGERI.Visible = false;

            PivotGridField fieldDAVA_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 43;
            fieldDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Name = "fieldDAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 44;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 45;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 46;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 47;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 48;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = null;
            switch (pencere)
            {
                case "Dosyalarının Durumlarına Göre Dağılımı":
                case "Dava Dosyalarının Dava Tarihine Göre Dağılımı":
                    dizi = DavaDosyalarınınDurumlarınaGore();
                    break;

                case "Dava Dosyalarının Bürolara Göre Dağılımı":
                    dizi = davaDosyalarininBurolaraGore();
                    break;

                case "Dava Dosyalarının Bürolara İntikal Tarihine Göre Dağılımı":
                    dizi = davaDosyalarininBurolaraIntikalTGore();
                    break;

                case "Dava Dosyalarının Bölümlere Göre Dağılımı":
                    dizi = DavaDosyalarininBolumlerineGoreDagilimi();
                    break;

                case "Dava Dosyalarının Dava Tipine Göre Dağılım":
                    dizi = DavaDosyalarininDavaTipineGoreDagilimi();
                    break;

                case "Dava Dosyalarının Dava Taleplerine Göre Dağılımı":
                    dizi = DavaDosyalarininDavaTaleplerineGoreDagilimi();
                    break;

                case "Dava Dosyalarının Sorumlu Avukatlara Göre Dağılımı":
                    dizi = DavaSorumluAvukatlaraGoreDagilimi();
                    break;

                case "Dava Dosyalarının İzleyen Avukatlara Göre Dağılımı":
                    dizi = DavaDosyalarininIzleyenAvukatlaraGoreDagilimi();
                    break;

                case "Dava Dosyalarının Bölgelere Göre Dağılımı":
                    dizi = DavaDosyalarininBolgelereGoreDagilimi();
                    break;

                case "Dava Dosyalarının Şubelere Göre Dağılımı":
                    dizi = DavaDosyalarininSubelereGoreDagilimi();
                    break;

                case "Dava Dosyası Kapama Ortalaması Hukuk Bürolarına Göre":
                    dizi = DavaDosylarininKapamaOrtBurolaraGore();
                    break;

                case "Açılan Dava Sayısı (Aylara, Yıllara Göre)":
                    dizi = AcilanDavaSayisiAylaraYillaraGore();
                    break;
                default:
                    dizi = null;
                    break;
            }
            if (dizi == null)
            {
                dizi = new PivotGridField[]
		{
			fieldDAVACI,
			fieldTAKIP_EDEN_TARAF_KODU,
			fieldDAVALI,
			fieldIZLEYEN,
			fieldSORUMLU,
			fieldTAKIP_EDILEN_TARAF_KODU,
			fieldDAVA_EDEN_SIFAT,
			fieldDAVA_EDILEN_SIFAT,
			fieldID,
			fieldDAVA_TALEP,
			fieldBIRIM,
			fieldFOY_NO,
			fieldREFERANS_NO,
			fieldREFERANS_NO2,
			fieldREFERANS_NO3,
			fieldDURUM,
			fieldDAVA_TARIHI,
			fieldADLIYE,
			fieldGOREV,
			fieldNO,
			fieldESAS_NO,
			fieldAVUKATA_INTIKAL_TARIHI,
			fieldOzelKod1,
			fieldOzelKod2,
			fieldOzelKod3,
			fieldOzelKod4,
			fieldACIKLAMA,
			fieldASAMA_ADI,
			fieldBANKA,
			fieldSUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldTAHSILAT_DURUM,
			fieldKREDI_GRUP,
			fieldKREDI_TIP,
			fieldKLASOR_1,
			fieldKLASOR_2,
			fieldDIGER_DAVA_NEDEN,
			fieldOLAY_SUC_TARIHI,
			fieldNEDEN_REFERANS_NO1,
			fieldNEDEN_REFERANS_NO2,
			fieldDAVA_DEGERI,
			fieldDAVA_DEGERI_DOVIZ_ID,
			fieldSUBE_KOD_ID,
			fieldKONTROL_KIM_ID,
			fieldBOLUM,
			fieldBOLGE,
			fieldKAPAMA_TARIHI,
			};
            }

            #region Field Caption

            //    fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
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

        private PivotGridField[] AcilanDavaSayisiAylaraYillaraGore()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 8;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDAVA_TARIHI.GroupInterval = PivotGroupInterval.DateYear;
            fieldDAVA_TARIHI.AreaIndex = 16;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = true;

            PivotGridField fieldDAVA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDAVA_TARIHI2.GroupInterval = PivotGroupInterval.DateMonth;
            fieldDAVA_TARIHI2.AreaIndex = 21;
            fieldDAVA_TARIHI2.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI2.Name = "fieldDAVA_TARIHI2";
            fieldDAVA_TARIHI2.Visible = true;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 9;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 15;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 30;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 31;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 32;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 33;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 34;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 35;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 36;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 37;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 38;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOLAY_SUC_TARIHI.AreaIndex = 39;
            fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO1.AreaIndex = 40;
            fieldNEDEN_REFERANS_NO1.FieldName = "NEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Name = "fieldNEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO2.AreaIndex = 41;
            fieldNEDEN_REFERANS_NO2.FieldName = "NEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Name = "fieldNEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Visible = false;

            PivotGridField fieldDAVA_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI.AreaIndex = 42;
            fieldDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            fieldDAVA_DEGERI.Name = "fieldDAVA_DEGERI";
            fieldDAVA_DEGERI.Visible = false;

            PivotGridField fieldDAVA_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 43;
            fieldDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Name = "fieldDAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 44;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 45;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldDAVA_TALEP,
			fieldDURUM,
            fieldSUBE_KOD_ID,
            fieldDAVA_TARIHI,
			fieldDAVA_TARIHI2,
			fieldDIGER_DAVA_NEDEN,
			fieldOLAY_SUC_TARIHI,
			fieldDAVA_DEGERI,

			fieldDAVA_DEGERI_DOVIZ_ID,
			};
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Visible = true;
            fieldSUBE_KOD_ID.Visible = true;
            fieldDAVA_DEGERI.Visible = true;
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;

            return dizi;
        }

        private PivotGridField[] DavaDosyalarınınDurumlarınaGore()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 8;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 9;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 15;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 16;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI2.AreaIndex = 16;
            fieldDAVA_TARIHI2.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI2.Name = "fieldDAVA_TARIHI2";
            fieldDAVA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldDAVA_TARIHI2.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 30;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 31;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 32;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 33;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 34;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 35;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 36;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 37;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 38;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOLAY_SUC_TARIHI.AreaIndex = 39;
            fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO1.AreaIndex = 40;
            fieldNEDEN_REFERANS_NO1.FieldName = "NEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Name = "fieldNEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO2.AreaIndex = 41;
            fieldNEDEN_REFERANS_NO2.FieldName = "NEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Name = "fieldNEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Visible = false;

            PivotGridField fieldDAVA_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI.AreaIndex = 42;
            fieldDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            fieldDAVA_DEGERI.Name = "fieldDAVA_DEGERI";
            fieldDAVA_DEGERI.Visible = false;

            PivotGridField fieldDAVA_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 43;
            fieldDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Name = "fieldDAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 44;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 45;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldDAVA_TALEP,
			fieldDURUM,
            fieldDAVA_TARIHI2,
			fieldDAVA_TARIHI,
			fieldDIGER_DAVA_NEDEN,
			fieldOLAY_SUC_TARIHI,
			fieldDAVA_DEGERI,
            fieldSUBE_KOD_ID,
			fieldDAVA_DEGERI_DOVIZ_ID,
			};
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Visible = true;
            fieldDURUM.Visible = true;
            fieldDAVA_DEGERI.Visible = true;
            fieldDAVA_TARIHI.Visible = true;
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDAVA_TARIHI2.Visible = true;
            fieldDAVA_TARIHI2.Area = PivotArea.RowArea;

            return dizi;
        }

        private PivotGridField[] DavaDosyalarininBolgelereGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 8;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 47;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM.AreaIndex = 10;
            fieldBIRIM.FieldName = "BIRIM";
            fieldBIRIM.Name = "fieldBIRIM";
            fieldBIRIM.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 9;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 15;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 16;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI2.AreaIndex = 16;
            fieldDAVA_TARIHI2.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI2.Name = "fieldDAVA_TARIHI2";
            fieldDAVA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldDAVA_TARIHI2.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 30;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 31;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 32;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 33;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 34;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 35;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 36;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 37;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 38;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOLAY_SUC_TARIHI.AreaIndex = 39;
            fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO1.AreaIndex = 40;
            fieldNEDEN_REFERANS_NO1.FieldName = "NEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Name = "fieldNEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO2.AreaIndex = 41;
            fieldNEDEN_REFERANS_NO2.FieldName = "NEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Name = "fieldNEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Visible = false;

            PivotGridField fieldDAVA_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI.AreaIndex = 42;
            fieldDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            fieldDAVA_DEGERI.Name = "fieldDAVA_DEGERI";
            fieldDAVA_DEGERI.Visible = false;

            PivotGridField fieldDAVA_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 43;
            fieldDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Name = "fieldDAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 44;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 45;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;
            PivotGridField fieldBÖLÜM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBÖLÜM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBÖLÜM.AreaIndex = 46;
            fieldBÖLÜM.FieldName = "BÖLÜM";
            fieldBÖLÜM.Name = "fieldBÖLÜM";
            fieldBÖLÜM.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 3;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 4;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldBOLGE,
			fieldBIRIM,
            fieldDAVA_TARIHI2,
			fieldDAVA_TARIHI,
			fieldDIGER_DAVA_NEDEN,
			fieldOLAY_SUC_TARIHI,
			fieldDAVA_DEGERI,
            fieldSUBE_KOD_ID,
			fieldDAVA_DEGERI_DOVIZ_ID,
			};
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Visible = true;
            fieldBOLGE.Visible = true;
            fieldDAVA_DEGERI.Visible = true;
            fieldDAVA_TARIHI.Visible = true;
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDAVA_TARIHI2.Visible = true;
            fieldDAVA_TARIHI2.Area = PivotArea.RowArea;

            return dizi;
        }

        private PivotGridField[] DavaDosyalarininBolumlerineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 8;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 9;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 15;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 16;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI2.AreaIndex = 16;
            fieldDAVA_TARIHI2.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI2.Name = "fieldDAVA_TARIHI2";
            fieldDAVA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldDAVA_TARIHI2.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 30;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 31;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 32;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 33;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 34;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 35;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 36;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 37;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 38;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOLAY_SUC_TARIHI.AreaIndex = 39;
            fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO1.AreaIndex = 40;
            fieldNEDEN_REFERANS_NO1.FieldName = "NEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Name = "fieldNEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO2.AreaIndex = 41;
            fieldNEDEN_REFERANS_NO2.FieldName = "NEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Name = "fieldNEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Visible = false;

            PivotGridField fieldDAVA_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI.AreaIndex = 42;
            fieldDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            fieldDAVA_DEGERI.Name = "fieldDAVA_DEGERI";
            fieldDAVA_DEGERI.Visible = false;

            PivotGridField fieldDAVA_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 43;
            fieldDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Name = "fieldDAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 44;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 45;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;
            PivotGridField fieldBÖLÜM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBÖLÜM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBÖLÜM.AreaIndex = 46;
            fieldBÖLÜM.FieldName = "BÖLÜM";
            fieldBÖLÜM.Name = "fieldBÖLÜM";
            fieldBÖLÜM.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldDAVA_TALEP,
			fieldBÖLÜM,
            fieldDAVA_TARIHI2,
			fieldDAVA_TARIHI,
			fieldDIGER_DAVA_NEDEN,
			fieldOLAY_SUC_TARIHI,
			fieldDAVA_DEGERI,
            fieldSUBE_KOD_ID,
			fieldDAVA_DEGERI_DOVIZ_ID,
			};
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Visible = true;
            fieldBÖLÜM.Visible = true;
            fieldDAVA_DEGERI.Visible = true;
            fieldDAVA_TARIHI.Visible = true;
            fieldBÖLÜM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDAVA_TARIHI2.Visible = true;
            fieldDAVA_TARIHI2.Area = PivotArea.RowArea;

            return dizi;
        }

        private PivotGridField[] davaDosyalarininBurolaraGore()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 8;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 9;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 15;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 16;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI2.AreaIndex = 16;
            fieldDAVA_TARIHI2.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI2.Name = "fieldDAVA_TARIHI2";
            fieldDAVA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldDAVA_TARIHI2.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 30;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 31;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 32;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 33;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 34;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 35;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 36;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 37;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 38;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOLAY_SUC_TARIHI.AreaIndex = 39;
            fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO1.AreaIndex = 40;
            fieldNEDEN_REFERANS_NO1.FieldName = "NEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Name = "fieldNEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO2.AreaIndex = 41;
            fieldNEDEN_REFERANS_NO2.FieldName = "NEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Name = "fieldNEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Visible = false;

            PivotGridField fieldDAVA_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI.AreaIndex = 42;
            fieldDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            fieldDAVA_DEGERI.Name = "fieldDAVA_DEGERI";
            fieldDAVA_DEGERI.Visible = false;

            PivotGridField fieldDAVA_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 43;
            fieldDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Name = "fieldDAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 44;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 45;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldDAVA_TALEP,
			fieldDURUM,
           fieldSUBE_KOD_ID,
            fieldDAVA_TARIHI2,
			fieldDAVA_TARIHI,
			fieldDIGER_DAVA_NEDEN,
			fieldOLAY_SUC_TARIHI,
			fieldDAVA_DEGERI,

			fieldDAVA_DEGERI_DOVIZ_ID,
			};
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Visible = true;
            fieldSUBE_KOD_ID.Visible = true;
            fieldDAVA_DEGERI.Visible = true;
            fieldDAVA_TARIHI.Visible = true;
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDAVA_TARIHI2.Visible = true;
            fieldDAVA_TARIHI2.Area = PivotArea.RowArea;

            return dizi;
        }

        private PivotGridField[] davaDosyalarininBurolaraIntikalTGore()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 8;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldAVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAVUKATA_INTIKAL_TARIHI.AreaIndex = 21;
            fieldAVUKATA_INTIKAL_TARIHI.FieldName = "AVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Name = "fieldAVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldAVUKATA_INTIKAL_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAVUKATA_INTIKAL_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAVUKATA_INTIKAL_TARIHI2.AreaIndex = 21;
            fieldAVUKATA_INTIKAL_TARIHI2.FieldName = "AVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI2.Name = "fieldAVUKATA_INTIKAL_TARIHI2";
            fieldAVUKATA_INTIKAL_TARIHI2.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 9;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 15;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 16;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI2.AreaIndex = 16;
            fieldDAVA_TARIHI2.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI2.Name = "fieldDAVA_TARIHI2";
            fieldDAVA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldDAVA_TARIHI2.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 30;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 31;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 32;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 33;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 34;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 35;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 36;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 37;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 38;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOLAY_SUC_TARIHI.AreaIndex = 39;
            fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO1.AreaIndex = 40;
            fieldNEDEN_REFERANS_NO1.FieldName = "NEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Name = "fieldNEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO2.AreaIndex = 41;
            fieldNEDEN_REFERANS_NO2.FieldName = "NEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Name = "fieldNEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Visible = false;

            PivotGridField fieldDAVA_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI.AreaIndex = 42;
            fieldDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            fieldDAVA_DEGERI.Name = "fieldDAVA_DEGERI";
            fieldDAVA_DEGERI.Visible = false;

            PivotGridField fieldDAVA_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 43;
            fieldDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Name = "fieldDAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 44;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 45;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldDAVA_TALEP,
			fieldDURUM,
            fieldSUBE_KOD_ID,
            fieldAVUKATA_INTIKAL_TARIHI2,
			fieldAVUKATA_INTIKAL_TARIHI,
			fieldDIGER_DAVA_NEDEN,
			fieldOLAY_SUC_TARIHI,
			fieldDAVA_DEGERI,

			fieldDAVA_DEGERI_DOVIZ_ID,
			};
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Visible = true;
            fieldSUBE_KOD_ID.Visible = true;
            fieldDAVA_DEGERI.Visible = true;
            fieldAVUKATA_INTIKAL_TARIHI.Visible = true;
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldAVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldAVUKATA_INTIKAL_TARIHI2.Visible = true;
            fieldAVUKATA_INTIKAL_TARIHI2.Area = PivotArea.RowArea;

            return dizi;
        }

        private PivotGridField[] DavaDosyalarininDavaTaleplerineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 8;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldBIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM.AreaIndex = 10;
            fieldBIRIM.FieldName = "BIRIM";
            fieldBIRIM.Name = "fieldBIRIM";
            fieldBIRIM.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 9;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 15;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 16;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI2.AreaIndex = 16;
            fieldDAVA_TARIHI2.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI2.Name = "fieldDAVA_TARIHI2";
            fieldDAVA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldDAVA_TARIHI2.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 30;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 31;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 32;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 33;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 34;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 35;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 36;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 37;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 38;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOLAY_SUC_TARIHI.AreaIndex = 39;
            fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO1.AreaIndex = 40;
            fieldNEDEN_REFERANS_NO1.FieldName = "NEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Name = "fieldNEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO2.AreaIndex = 41;
            fieldNEDEN_REFERANS_NO2.FieldName = "NEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Name = "fieldNEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Visible = false;

            PivotGridField fieldDAVA_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI.AreaIndex = 42;
            fieldDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            fieldDAVA_DEGERI.Name = "fieldDAVA_DEGERI";
            fieldDAVA_DEGERI.Visible = false;

            PivotGridField fieldDAVA_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 43;
            fieldDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Name = "fieldDAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 44;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 45;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;
            PivotGridField fieldBÖLÜM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBÖLÜM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBÖLÜM.AreaIndex = 46;
            fieldBÖLÜM.FieldName = "BÖLÜM";
            fieldBÖLÜM.Name = "fieldBÖLÜM";
            fieldBÖLÜM.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldDAVA_TALEP,
			fieldBIRIM,
            fieldDAVA_TARIHI2,
			fieldDAVA_TARIHI,
			fieldDIGER_DAVA_NEDEN,
			fieldOLAY_SUC_TARIHI,
			fieldDAVA_DEGERI,
            fieldSUBE_KOD_ID,
			fieldDAVA_DEGERI_DOVIZ_ID,
			};
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Visible = true;
            fieldDAVA_TALEP.Visible = true;
            fieldDAVA_DEGERI.Visible = true;
            fieldDAVA_TARIHI.Visible = true;
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDAVA_TARIHI2.Visible = true;
            fieldDAVA_TARIHI2.Area = PivotArea.RowArea;

            return dizi;
        }

        private PivotGridField[] DavaDosyalarininDavaTipineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 8;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldBIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM.AreaIndex = 10;
            fieldBIRIM.FieldName = "BIRIM";
            fieldBIRIM.Name = "fieldBIRIM";
            fieldBIRIM.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 9;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 15;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 16;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI2.AreaIndex = 16;
            fieldDAVA_TARIHI2.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI2.Name = "fieldDAVA_TARIHI2";
            fieldDAVA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldDAVA_TARIHI2.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 30;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 31;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 32;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 33;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 34;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 35;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 36;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 37;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 38;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOLAY_SUC_TARIHI.AreaIndex = 39;
            fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO1.AreaIndex = 40;
            fieldNEDEN_REFERANS_NO1.FieldName = "NEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Name = "fieldNEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO2.AreaIndex = 41;
            fieldNEDEN_REFERANS_NO2.FieldName = "NEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Name = "fieldNEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Visible = false;

            PivotGridField fieldDAVA_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI.AreaIndex = 42;
            fieldDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            fieldDAVA_DEGERI.Name = "fieldDAVA_DEGERI";
            fieldDAVA_DEGERI.Visible = false;

            PivotGridField fieldDAVA_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 43;
            fieldDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Name = "fieldDAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 44;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 45;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;
            PivotGridField fieldBÖLÜM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBÖLÜM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBÖLÜM.AreaIndex = 46;
            fieldBÖLÜM.FieldName = "BÖLÜM";
            fieldBÖLÜM.Name = "fieldBÖLÜM";
            fieldBÖLÜM.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldDAVA_TALEP,
			fieldBIRIM,
            fieldDAVA_TARIHI2,
			fieldDAVA_TARIHI,
			fieldDIGER_DAVA_NEDEN,
			fieldOLAY_SUC_TARIHI,
			fieldDAVA_DEGERI,
            fieldSUBE_KOD_ID,
			fieldDAVA_DEGERI_DOVIZ_ID,
			};
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Visible = true;
            fieldBIRIM.Visible = true;
            fieldDAVA_DEGERI.Visible = true;
            fieldDAVA_TARIHI.Visible = true;
            fieldBIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDAVA_TARIHI2.Visible = true;
            fieldDAVA_TARIHI2.Area = PivotArea.RowArea;

            return dizi;
        }

        private PivotGridField[] DavaDosyalarininIzleyenAvukatlaraGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 8;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldBIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM.AreaIndex = 10;
            fieldBIRIM.FieldName = "BIRIM";
            fieldBIRIM.Name = "fieldBIRIM";
            fieldBIRIM.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 9;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 15;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 16;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI2.AreaIndex = 16;
            fieldDAVA_TARIHI2.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI2.Name = "fieldDAVA_TARIHI2";
            fieldDAVA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldDAVA_TARIHI2.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 30;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 31;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 32;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 33;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 34;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 35;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 36;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 37;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 38;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOLAY_SUC_TARIHI.AreaIndex = 39;
            fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO1.AreaIndex = 40;
            fieldNEDEN_REFERANS_NO1.FieldName = "NEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Name = "fieldNEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO2.AreaIndex = 41;
            fieldNEDEN_REFERANS_NO2.FieldName = "NEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Name = "fieldNEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Visible = false;

            PivotGridField fieldDAVA_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI.AreaIndex = 42;
            fieldDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            fieldDAVA_DEGERI.Name = "fieldDAVA_DEGERI";
            fieldDAVA_DEGERI.Visible = false;

            PivotGridField fieldDAVA_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 43;
            fieldDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Name = "fieldDAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 44;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 45;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;
            PivotGridField fieldBÖLÜM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBÖLÜM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBÖLÜM.AreaIndex = 46;
            fieldBÖLÜM.FieldName = "BÖLÜM";
            fieldBÖLÜM.Name = "fieldBÖLÜM";
            fieldBÖLÜM.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 3;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 4;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldIZLEYEN,
			fieldBIRIM,
            fieldDAVA_TARIHI2,
			fieldDAVA_TARIHI,
			fieldDIGER_DAVA_NEDEN,
			fieldOLAY_SUC_TARIHI,
			fieldDAVA_DEGERI,
            fieldSUBE_KOD_ID,
			fieldDAVA_DEGERI_DOVIZ_ID,
			};
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Visible = true;
            fieldIZLEYEN.Visible = true;
            fieldDAVA_DEGERI.Visible = true;
            fieldDAVA_TARIHI.Visible = true;
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDAVA_TARIHI2.Visible = true;
            fieldDAVA_TARIHI2.Area = PivotArea.RowArea;

            return dizi;
        }

        private PivotGridField[] DavaDosyalarininSubelereGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 8;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldSUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE.AreaIndex = 29;
            fieldSUBE.FieldName = "SUBE";
            fieldSUBE.Name = "fieldSUBE";
            fieldSUBE.Visible = false;

            PivotGridField fieldBIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM.AreaIndex = 10;
            fieldBIRIM.FieldName = "BIRIM";
            fieldBIRIM.Name = "fieldBIRIM";
            fieldBIRIM.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 9;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 15;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 16;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI2.AreaIndex = 16;
            fieldDAVA_TARIHI2.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI2.Name = "fieldDAVA_TARIHI2";
            fieldDAVA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldDAVA_TARIHI2.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 30;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 31;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 32;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 33;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 34;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 35;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 36;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 37;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 38;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOLAY_SUC_TARIHI.AreaIndex = 39;
            fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO1.AreaIndex = 40;
            fieldNEDEN_REFERANS_NO1.FieldName = "NEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Name = "fieldNEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO2.AreaIndex = 41;
            fieldNEDEN_REFERANS_NO2.FieldName = "NEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Name = "fieldNEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Visible = false;

            PivotGridField fieldDAVA_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI.AreaIndex = 42;
            fieldDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            fieldDAVA_DEGERI.Name = "fieldDAVA_DEGERI";
            fieldDAVA_DEGERI.Visible = false;

            PivotGridField fieldDAVA_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 43;
            fieldDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Name = "fieldDAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 44;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 45;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;
            PivotGridField fieldBÖLÜM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBÖLÜM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBÖLÜM.AreaIndex = 46;
            fieldBÖLÜM.FieldName = "BÖLÜM";
            fieldBÖLÜM.Name = "fieldBÖLÜM";
            fieldBÖLÜM.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 3;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 4;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldSUBE,
			fieldBIRIM,
            fieldDAVA_TARIHI2,
			fieldDAVA_TARIHI,
			fieldDIGER_DAVA_NEDEN,
			fieldOLAY_SUC_TARIHI,
			fieldDAVA_DEGERI,
            fieldSUBE_KOD_ID,
			fieldDAVA_DEGERI_DOVIZ_ID,
			};
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Visible = true;
            fieldSUBE.Visible = true;
            fieldDAVA_DEGERI.Visible = true;
            fieldDAVA_TARIHI.Visible = true;
            fieldSUBE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDAVA_TARIHI2.Visible = true;
            fieldDAVA_TARIHI2.Area = PivotArea.RowArea;

            return dizi;
        }

        private PivotGridField[] DavaDosylarininKapamaOrtBurolaraGore()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 8;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldAVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAVUKATA_INTIKAL_TARIHI.AreaIndex = 21;
            fieldAVUKATA_INTIKAL_TARIHI.FieldName = "AVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Name = "fieldAVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldAVUKATA_INTIKAL_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAVUKATA_INTIKAL_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAVUKATA_INTIKAL_TARIHI2.AreaIndex = 21;
            fieldAVUKATA_INTIKAL_TARIHI2.FieldName = "AVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI2.Name = "fieldAVUKATA_INTIKAL_TARIHI2";
            fieldAVUKATA_INTIKAL_TARIHI2.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 9;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 15;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 16;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI2.AreaIndex = 16;
            fieldDAVA_TARIHI2.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI2.Name = "fieldDAVA_TARIHI2";
            fieldDAVA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldDAVA_TARIHI2.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 30;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 31;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 32;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 33;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 34;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 35;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 36;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 37;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 38;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOLAY_SUC_TARIHI.AreaIndex = 39;
            fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO1.AreaIndex = 40;
            fieldNEDEN_REFERANS_NO1.FieldName = "NEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Name = "fieldNEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO2.AreaIndex = 41;
            fieldNEDEN_REFERANS_NO2.FieldName = "NEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Name = "fieldNEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Visible = false;

            PivotGridField fieldDAVA_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI.AreaIndex = 42;
            fieldDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            fieldDAVA_DEGERI.Name = "fieldDAVA_DEGERI";
            fieldDAVA_DEGERI.Visible = false;

            PivotGridField fieldDAVA_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 43;
            fieldDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Name = "fieldDAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 44;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 45;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 48;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldDAVA_TALEP,
			fieldDURUM,
            fieldSUBE_KOD_ID,
            fieldKAPAMA_TARIHI,
			fieldDIGER_DAVA_NEDEN,
			fieldOLAY_SUC_TARIHI,
			fieldDAVA_DEGERI,

			fieldDAVA_DEGERI_DOVIZ_ID,
			};
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Visible = true;
            fieldSUBE_KOD_ID.Visible = true;
            fieldDAVA_DEGERI.Visible = true;
            fieldKAPAMA_TARIHI.Visible = true;
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldKAPAMA_TARIHI.Visible = true;
            fieldKAPAMA_TARIHI.Area = PivotArea.RowArea;

            return dizi;
        }

        private PivotGridField[] DavaSorumluAvukatlaraGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 8;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldBIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM.AreaIndex = 10;
            fieldBIRIM.FieldName = "BIRIM";
            fieldBIRIM.Name = "fieldBIRIM";
            fieldBIRIM.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 9;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 15;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 16;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI2.AreaIndex = 16;
            fieldDAVA_TARIHI2.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI2.Name = "fieldDAVA_TARIHI2";
            fieldDAVA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldDAVA_TARIHI2.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 30;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 31;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 32;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 33;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 34;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 35;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 36;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 37;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 38;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOLAY_SUC_TARIHI.AreaIndex = 39;
            fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
            fieldOLAY_SUC_TARIHI.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO1.AreaIndex = 40;
            fieldNEDEN_REFERANS_NO1.FieldName = "NEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Name = "fieldNEDEN_REFERANS_NO1";
            fieldNEDEN_REFERANS_NO1.Visible = false;

            PivotGridField fieldNEDEN_REFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNEDEN_REFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNEDEN_REFERANS_NO2.AreaIndex = 41;
            fieldNEDEN_REFERANS_NO2.FieldName = "NEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Name = "fieldNEDEN_REFERANS_NO2";
            fieldNEDEN_REFERANS_NO2.Visible = false;

            PivotGridField fieldDAVA_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI.AreaIndex = 42;
            fieldDAVA_DEGERI.FieldName = "DAVA_DEGERI";
            fieldDAVA_DEGERI.Name = "fieldDAVA_DEGERI";
            fieldDAVA_DEGERI.Visible = false;

            PivotGridField fieldDAVA_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 43;
            fieldDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Name = "fieldDAVA_DEGERI_DOVIZ_ID";
            fieldDAVA_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 44;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 45;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;
            PivotGridField fieldBÖLÜM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBÖLÜM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBÖLÜM.AreaIndex = 46;
            fieldBÖLÜM.FieldName = "BÖLÜM";
            fieldBÖLÜM.Name = "fieldBÖLÜM";
            fieldBÖLÜM.Visible = false;
            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 3;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 4;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldSORUMLU,
			fieldBIRIM,
            fieldDAVA_TARIHI2,
			fieldDAVA_TARIHI,
			fieldDIGER_DAVA_NEDEN,
			fieldOLAY_SUC_TARIHI,
			fieldDAVA_DEGERI,
            fieldSUBE_KOD_ID,
			fieldDAVA_DEGERI_DOVIZ_ID,
			};
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Visible = true;
            fieldSORUMLU.Visible = true;
            fieldDAVA_DEGERI.Visible = true;
            fieldDAVA_TARIHI.Visible = true;
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDAVA_TARIHI2.Visible = true;
            fieldDAVA_TARIHI2.Area = PivotArea.RowArea;

            return dizi;
        }

        private Dictionary<string, string> GetCaptionDictinory()
        {
            Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

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

            #region Caption Edit

            dicFieldCaption.Add("DAVACI", "Davacı");
            dicFieldCaption.Add("TAKIP_EDEN_TARAF_KODU", "Davacı T.K");
            dicFieldCaption.Add("DAVALI", "Davalı");
            dicFieldCaption.Add("IZLEYEN", "İzleyen");
            dicFieldCaption.Add("SORUMLU", "Sorumlu");
            dicFieldCaption.Add("TAKIP_EDILEN_TARAF_KODU", "Davalı T.K");
            dicFieldCaption.Add("DAVA_EDEN_SIFAT", "Davacı Sıfat");
            dicFieldCaption.Add("DAVA_EDILEN_SIFAT", "Davalı Sıfat");
            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("DAVA_TALEP", "Dava Talep");
            dicFieldCaption.Add("BIRIM", "Birim");
            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("REFERANS_NO", RefNo);
            dicFieldCaption.Add("REFERANS_NO2", RefNo2);
            dicFieldCaption.Add("REFERANS_NO3", refNo3);
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("DAVA_TARIHI", "Dava T.");
            dicFieldCaption.Add("ADLIYE", "Mahkeme");
            dicFieldCaption.Add("GOREV", "Grv");
            dicFieldCaption.Add("NO", "No");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("AVUKATA_INTIKAL_TARIHI", "İntikal T.");
            dicFieldCaption.Add("OzelKod1", OzelKod1);
            dicFieldCaption.Add("OzelKod2", OzelKod2);
            dicFieldCaption.Add("OzelKod3", OzelKod3);
            dicFieldCaption.Add("OzelKod4", OzelKod4);
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("ASAMA_ADI", "Aşama");
            dicFieldCaption.Add("BANKA", "Banka");
            dicFieldCaption.Add("SUBE", "Şube");
            dicFieldCaption.Add("FOY_BIRIM", "Foy Birim");
            dicFieldCaption.Add("FOY_YERI", "Foy Yeri");
            dicFieldCaption.Add("FOY_OZEL_DURUM", "Foy Özel Durum");
            dicFieldCaption.Add("TAHSILAT_DURUM", "Tahsilat Durum");
            dicFieldCaption.Add("KREDI_GRUP", "Kredi Grup");
            dicFieldCaption.Add("KREDI_TIP", "Kredi Tip");
            dicFieldCaption.Add("KLASOR_1", "Klasör 1");
            dicFieldCaption.Add("KLASOR_2", "Klasör 2");
            dicFieldCaption.Add("DIGER_DAVA_NEDEN", "Diğer Dava Nedeni");
            dicFieldCaption.Add("OLAY_SUC_TARIHI", "Olay Suç T.");
            dicFieldCaption.Add("NEDEN_REFERANS_NO1", DNRefNo);
            dicFieldCaption.Add("NEDEN_REFERANS_NO2", DNRefNo2);
            dicFieldCaption.Add("DAVA_DEGERI", "Dava Değeri");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("BOLUM", "Bölüm");
            dicFieldCaption.Add("BOLGE", "Bölge");
            dicFieldCaption.Add("KAPAMA_TARIHI", "Kapama T.");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            //RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

            // InitsEx.DovizTipGetir(rlueDoviz);

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("DovizId", InitsEx.DovizTipGetir);
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("DAVA_DEGERI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("DAVA_DEGERI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TAKIP_EDILEN_TARAF_KODU", InitsEx.TarafKodu);
            sozluk.Add("TAKIP_EDEN_TARAF_KODU", InitsEx.TarafKodu);

            #endregion Add item

            return sozluk;
        }
    }
}