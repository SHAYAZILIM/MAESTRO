using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class masrafAvansdetay
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

            GridColumn colMASRAF_AVANS_TIP = new GridColumn();
            colMASRAF_AVANS_TIP.VisibleIndex = 1;
            colMASRAF_AVANS_TIP.FieldName = "MASRAF_AVANS_TIP";
            colMASRAF_AVANS_TIP.Name = "colMASRAF_AVANS_TIP";
            colMASRAF_AVANS_TIP.Visible = true;

            GridColumn colKAYIT_TARIHI = new GridColumn();
            colKAYIT_TARIHI.VisibleIndex = 2;
            colKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
            colKAYIT_TARIHI.Visible = true;

            GridColumn colKLASOR_KODU = new GridColumn();
            colKLASOR_KODU.VisibleIndex = 3;
            colKLASOR_KODU.FieldName = "KLASOR_KODU";
            colKLASOR_KODU.Name = "colKLASOR_KODU";
            colKLASOR_KODU.Visible = true;

            GridColumn colSUBE_ADI = new GridColumn();
            colSUBE_ADI.VisibleIndex = 4;
            colSUBE_ADI.FieldName = "SUBE_ADI";
            colSUBE_ADI.Name = "colSUBE_ADI";
            colSUBE_ADI.Visible = true;

            GridColumn colBORCLU = new GridColumn();
            colBORCLU.VisibleIndex = 5;
            colBORCLU.FieldName = "BORCLU";
            colBORCLU.Name = "colBORCLU";
            colBORCLU.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 6;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 7;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colSUBE = new GridColumn();
            colSUBE.VisibleIndex = 8;
            colSUBE.FieldName = "SUBE";
            colSUBE.Name = "colSUBE";
            colSUBE.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 9;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 10;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colKONTROL_KIM = new GridColumn();
            colKONTROL_KIM.VisibleIndex = 11;
            colKONTROL_KIM.FieldName = "KONTROL_KIM";
            colKONTROL_KIM.Name = "colKONTROL_KIM";
            colKONTROL_KIM.Visible = true;

            GridColumn colKONTROL_NE_ZAMAN = new GridColumn();
            colKONTROL_NE_ZAMAN.VisibleIndex = 12;
            colKONTROL_NE_ZAMAN.FieldName = "KONTROL_NE_ZAMAN";
            colKONTROL_NE_ZAMAN.Name = "colKONTROL_NE_ZAMAN";
            colKONTROL_NE_ZAMAN.Visible = true;

            GridColumn colKLASOR_1 = new GridColumn();
            colKLASOR_1.VisibleIndex = 13;
            colKLASOR_1.FieldName = "KLASOR_1";
            colKLASOR_1.Name = "colKLASOR_1";
            colKLASOR_1.Visible = true;

            GridColumn colKLASOR_2 = new GridColumn();
            colKLASOR_2.VisibleIndex = 14;
            colKLASOR_2.FieldName = "KLASOR_2";
            colKLASOR_2.Name = "colKLASOR_2";
            colKLASOR_2.Visible = true;

            GridColumn colMODUL_ID = new GridColumn();
            colMODUL_ID.VisibleIndex = 15;
            colMODUL_ID.FieldName = "MODUL_ID";
            colMODUL_ID.Name = "colMODUL_ID";
            colMODUL_ID.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 16;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colKAYIT_ID = new GridColumn();
            colKAYIT_ID.VisibleIndex = 17;
            colKAYIT_ID.FieldName = "KAYIT_ID";
            colKAYIT_ID.Name = "colKAYIT_ID";
            colKAYIT_ID.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 18;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 19;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 20;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 21;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colTARIH = new GridColumn();
            colTARIH.VisibleIndex = 22;
            colTARIH.FieldName = "TARIH";
            colTARIH.Name = "colTARIH";
            colTARIH.Visible = true;

            GridColumn colKULLANICI_BELGE_NO = new GridColumn();
            colKULLANICI_BELGE_NO.VisibleIndex = 23;
            colKULLANICI_BELGE_NO.FieldName = "KULLANICI_BELGE_NO";
            colKULLANICI_BELGE_NO.Name = "colKULLANICI_BELGE_NO";
            colKULLANICI_BELGE_NO.Visible = true;

            GridColumn colBORC_ALACAK = new GridColumn();
            colBORC_ALACAK.VisibleIndex = 24;
            colBORC_ALACAK.FieldName = "BORC_ALACAK";
            colBORC_ALACAK.Name = "colBORC_ALACAK";
            colBORC_ALACAK.Visible = true;

            GridColumn colODEME_TIP = new GridColumn();
            colODEME_TIP.VisibleIndex = 25;
            colODEME_TIP.FieldName = "ODEME_TIP";
            colODEME_TIP.Name = "colODEME_TIP";
            colODEME_TIP.Visible = true;

            GridColumn colANA_KATEGORI = new GridColumn();
            colANA_KATEGORI.VisibleIndex = 26;
            colANA_KATEGORI.FieldName = "ANA_KATEGORI";
            colANA_KATEGORI.Name = "colANA_KATEGORI";
            colANA_KATEGORI.Visible = true;

            GridColumn colALT_KATEGORI = new GridColumn();
            colALT_KATEGORI.VisibleIndex = 27;
            colALT_KATEGORI.FieldName = "ALT_KATEGORI";
            colALT_KATEGORI.Name = "colALT_KATEGORI";
            colALT_KATEGORI.Visible = true;

            GridColumn colADET = new GridColumn();
            colADET.VisibleIndex = 28;
            colADET.FieldName = "ADET";
            colADET.Name = "colADET";
            colADET.Visible = true;

            GridColumn colBIRIM_FIYAT = new GridColumn();
            colBIRIM_FIYAT.VisibleIndex = 29;
            colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
            colBIRIM_FIYAT.Visible = true;

            GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
            colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 30;
            colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Visible = true;

            GridColumn colKDV_DAHIL = new GridColumn();
            colKDV_DAHIL.VisibleIndex = 31;
            colKDV_DAHIL.FieldName = "KDV_DAHIL";
            colKDV_DAHIL.Name = "colKDV_DAHIL";
            colKDV_DAHIL.Visible = true;

            GridColumn colKDV_ORAN = new GridColumn();
            colKDV_ORAN.VisibleIndex = 32;
            colKDV_ORAN.FieldName = "KDV_ORAN";
            colKDV_ORAN.Name = "colKDV_ORAN";
            colKDV_ORAN.Visible = true;

            GridColumn colKDV_TUTAR = new GridColumn();
            colKDV_TUTAR.VisibleIndex = 33;
            colKDV_TUTAR.FieldName = "KDV_TUTAR";
            colKDV_TUTAR.Name = "colKDV_TUTAR";
            colKDV_TUTAR.Visible = true;

            GridColumn colSTOPAJ_SSDF_DAHIL = new GridColumn();
            colSTOPAJ_SSDF_DAHIL.VisibleIndex = 34;
            colSTOPAJ_SSDF_DAHIL.FieldName = "STOPAJ_SSDF_DAHIL";
            colSTOPAJ_SSDF_DAHIL.Name = "colSTOPAJ_SSDF_DAHIL";
            colSTOPAJ_SSDF_DAHIL.Visible = true;

            GridColumn colSTOPAJ_ORAN = new GridColumn();
            colSTOPAJ_ORAN.VisibleIndex = 35;
            colSTOPAJ_ORAN.FieldName = "STOPAJ_ORAN";
            colSTOPAJ_ORAN.Name = "colSTOPAJ_ORAN";
            colSTOPAJ_ORAN.Visible = true;

            GridColumn colSSDF_ORAN = new GridColumn();
            colSSDF_ORAN.VisibleIndex = 36;
            colSSDF_ORAN.FieldName = "SSDF_ORAN";
            colSSDF_ORAN.Name = "colSSDF_ORAN";
            colSSDF_ORAN.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 37;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colONAY_DURUM = new GridColumn();
            colONAY_DURUM.VisibleIndex = 38;
            colONAY_DURUM.FieldName = "ONAY_DURUM";
            colONAY_DURUM.Name = "colONAY_DURUM";
            colONAY_DURUM.Visible = true;

            GridColumn colONAY_NO = new GridColumn();
            colONAY_NO.VisibleIndex = 39;
            colONAY_NO.FieldName = "ONAY_NO";
            colONAY_NO.Name = "colONAY_NO";
            colONAY_NO.Visible = true;

            GridColumn colONAY_TARIHI = new GridColumn();
            colONAY_TARIHI.VisibleIndex = 40;
            colONAY_TARIHI.FieldName = "ONAY_TARIHI";
            colONAY_TARIHI.Name = "colONAY_TARIHI";
            colONAY_TARIHI.Visible = true;

            GridColumn colINCELENDI = new GridColumn();
            colINCELENDI.VisibleIndex = 41;
            colINCELENDI.FieldName = "INCELENDI";
            colINCELENDI.Name = "colINCELENDI";
            colINCELENDI.Visible = true;

            GridColumn colTUM_MUVEKKILLERE_PAYLASTIR = new GridColumn();
            colTUM_MUVEKKILLERE_PAYLASTIR.VisibleIndex = 42;
            colTUM_MUVEKKILLERE_PAYLASTIR.FieldName = "TUM_MUVEKKILLERE_PAYLASTIR";
            colTUM_MUVEKKILLERE_PAYLASTIR.Name = "colTUM_MUVEKKILLERE_PAYLASTIR";
            colTUM_MUVEKKILLERE_PAYLASTIR.Visible = true;

            GridColumn colGENEL_TOPLAM_DOVIZ_ID = new GridColumn();
            colGENEL_TOPLAM_DOVIZ_ID.VisibleIndex = 43;
            colGENEL_TOPLAM_DOVIZ_ID.FieldName = "GENEL_TOPLAM_DOVIZ_ID";
            colGENEL_TOPLAM_DOVIZ_ID.Name = "colGENEL_TOPLAM_DOVIZ_ID";
            colGENEL_TOPLAM_DOVIZ_ID.Visible = true;

            GridColumn colGENEL_TOPLAM = new GridColumn();
            colGENEL_TOPLAM.VisibleIndex = 44;
            colGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
            colGENEL_TOPLAM.Visible = true;

            GridColumn colTOPLAM_TUTAR_DOVIZ_ID = new GridColumn();
            colTOPLAM_TUTAR_DOVIZ_ID.VisibleIndex = 45;
            colTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            colTOPLAM_TUTAR_DOVIZ_ID.Name = "colTOPLAM_TUTAR_DOVIZ_ID";
            colTOPLAM_TUTAR_DOVIZ_ID.Visible = true;

            GridColumn colTOPLAM_TUTAR = new GridColumn();
            colTOPLAM_TUTAR.VisibleIndex = 46;
            colTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            colTOPLAM_TUTAR.Name = "colTOPLAM_TUTAR";
            colTOPLAM_TUTAR.Visible = true;

            GridColumn colSTOPAJ_SSDF_TUTAR = new GridColumn();
            colSTOPAJ_SSDF_TUTAR.VisibleIndex = 47;
            colSTOPAJ_SSDF_TUTAR.FieldName = "STOPAJ_SSDF_TUTAR";
            colSTOPAJ_SSDF_TUTAR.Name = "colSTOPAJ_SSDF_TUTAR";
            colSTOPAJ_SSDF_TUTAR.Visible = true;

            GridColumn colTO_HESAP_CETVEL_YERI = new GridColumn();
            colTO_HESAP_CETVEL_YERI.VisibleIndex = 48;
            colTO_HESAP_CETVEL_YERI.FieldName = "TO_HESAP_CETVEL_YERI";
            colTO_HESAP_CETVEL_YERI.Name = "colTO_HESAP_CETVEL_YERI";
            colTO_HESAP_CETVEL_YERI.Visible = true;

            GridColumn colTS_HESAP_CETVEL_YERI = new GridColumn();
            colTS_HESAP_CETVEL_YERI.VisibleIndex = 49;
            colTS_HESAP_CETVEL_YERI.FieldName = "TS_HESAP_CETVEL_YERI";
            colTS_HESAP_CETVEL_YERI.Name = "colTS_HESAP_CETVEL_YERI";
            colTS_HESAP_CETVEL_YERI.Visible = true;

            GridColumn colDO_HESAP_CETVEL_YERI = new GridColumn();
            colDO_HESAP_CETVEL_YERI.VisibleIndex = 50;
            colDO_HESAP_CETVEL_YERI.FieldName = "DO_HESAP_CETVEL_YERI";
            colDO_HESAP_CETVEL_YERI.Name = "colDO_HESAP_CETVEL_YERI";
            colDO_HESAP_CETVEL_YERI.Visible = true;

            GridColumn colDS_HESAP_CETVEL_YERI = new GridColumn();
            colDS_HESAP_CETVEL_YERI.VisibleIndex = 51;
            colDS_HESAP_CETVEL_YERI.FieldName = "DS_HESAP_CETVEL_YERI";
            colDS_HESAP_CETVEL_YERI.Name = "colDS_HESAP_CETVEL_YERI";
            colDS_HESAP_CETVEL_YERI.Visible = true;

            GridColumn colMUVEKKIL = new GridColumn();
            colMUVEKKIL.VisibleIndex = 52;
            colMUVEKKIL.FieldName = "MUVEKKIL";
            colMUVEKKIL.Name = "colMUVEKKIL";
            colMUVEKKIL.Visible = true;

            GridColumn colSEGMENT_ID = new GridColumn();
            colSEGMENT_ID.VisibleIndex = 53;
            colSEGMENT_ID.FieldName = "SEGMENT_ID";
            colSEGMENT_ID.Name = "colSEGMENT_ID";
            colSEGMENT_ID.Visible = true;
            GridColumn colBOLGE = new GridColumn();
            colBOLGE.VisibleIndex = 54;
            colBOLGE.FieldName = "BOLGE";
            colBOLGE.Name = "colBOLGE";
            colBOLGE.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colREFERANS_NO,
			colMASRAF_AVANS_TIP,
			colKAYIT_TARIHI,
			colKLASOR_KODU,
			colSUBE_ADI,
			colBORCLU,
			colSORUMLU,
			colBANKA,
			colSUBE,
			colKREDI_GRUP,
			colKREDI_TIP,
			colKONTROL_KIM,
			colKONTROL_NE_ZAMAN,
			colKLASOR_1,
			colKLASOR_2,
			colMODUL_ID,

			//colID,
			//colKAYIT_ID,
			colFOY_NO,
			colADLIYE,
			colNO,
			colGOREV,
			colTARIH,
			colKULLANICI_BELGE_NO,
			colBORC_ALACAK,
			colODEME_TIP,
			colANA_KATEGORI,
			colALT_KATEGORI,
			colADET,
			colBIRIM_FIYAT,
			colBIRIM_FIYAT_DOVIZ_ID,
			colKDV_DAHIL,
			colKDV_ORAN,
			colKDV_TUTAR,
			colSTOPAJ_SSDF_DAHIL,
			colSTOPAJ_ORAN,
			colSSDF_ORAN,
			colACIKLAMA,
			colONAY_DURUM,
			colONAY_NO,
			colONAY_TARIHI,
			colINCELENDI,
			colTUM_MUVEKKILLERE_PAYLASTIR,
			colGENEL_TOPLAM_DOVIZ_ID,
			colGENEL_TOPLAM,
			colTOPLAM_TUTAR_DOVIZ_ID,
			colTOPLAM_TUTAR,
			colSTOPAJ_SSDF_TUTAR,
			colTO_HESAP_CETVEL_YERI,
			colTS_HESAP_CETVEL_YERI,
			colDO_HESAP_CETVEL_YERI,
			colDS_HESAP_CETVEL_YERI,
			colMUVEKKIL,
			colSEGMENT_ID,
            colBOLGE,
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

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldMASRAF_AVANS_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_AVANS_TIP.AreaIndex = 1;
            fieldMASRAF_AVANS_TIP.FieldName = "MASRAF_AVANS_TIP";
            fieldMASRAF_AVANS_TIP.Name = "fieldMASRAF_AVANS_TIP";
            fieldMASRAF_AVANS_TIP.Visible = false;

            PivotGridField fieldKAYIT_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAYIT_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAYIT_TARIHI.AreaIndex = 2;
            fieldKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            fieldKAYIT_TARIHI.Name = "fieldKAYIT_TARIHI";
            fieldKAYIT_TARIHI.Visible = false;

            PivotGridField fieldKLASOR_KODU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_KODU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_KODU.AreaIndex = 3;
            fieldKLASOR_KODU.FieldName = "KLASOR_KODU";
            fieldKLASOR_KODU.Name = "fieldKLASOR_KODU";
            fieldKLASOR_KODU.Visible = false;

            PivotGridField fieldSUBE_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_ADI.AreaIndex = 4;
            fieldSUBE_ADI.FieldName = "SUBE_ADI";
            fieldSUBE_ADI.Name = "fieldSUBE_ADI";
            fieldSUBE_ADI.Visible = false;

            PivotGridField fieldBORCLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORCLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORCLU.AreaIndex = 5;
            fieldBORCLU.FieldName = "BORCLU";
            fieldBORCLU.Name = "fieldBORCLU";
            fieldBORCLU.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 6;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 7;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldSUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE.AreaIndex = 8;
            fieldSUBE.FieldName = "SUBE";
            fieldSUBE.Name = "fieldSUBE";
            fieldSUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 9;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 10;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKONTROL_KIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM.AreaIndex = 11;
            fieldKONTROL_KIM.FieldName = "KONTROL_KIM";
            fieldKONTROL_KIM.Name = "fieldKONTROL_KIM";
            fieldKONTROL_KIM.Visible = false;

            PivotGridField fieldKONTROL_NE_ZAMAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_NE_ZAMAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_NE_ZAMAN.AreaIndex = 12;
            fieldKONTROL_NE_ZAMAN.FieldName = "KONTROL_NE_ZAMAN";
            fieldKONTROL_NE_ZAMAN.Name = "fieldKONTROL_NE_ZAMAN";
            fieldKONTROL_NE_ZAMAN.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 13;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 14;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldMODUL_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMODUL_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMODUL_ID.AreaIndex = 15;
            fieldMODUL_ID.FieldName = "MODUL_ID";
            fieldMODUL_ID.Name = "fieldMODUL_ID";
            fieldMODUL_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 16;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldKAYIT_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAYIT_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAYIT_ID.AreaIndex = 17;
            fieldKAYIT_ID.FieldName = "KAYIT_ID";
            fieldKAYIT_ID.Name = "fieldKAYIT_ID";
            fieldKAYIT_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 18;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 19;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 20;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 21;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 22;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldKULLANICI_BELGE_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKULLANICI_BELGE_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKULLANICI_BELGE_NO.AreaIndex = 23;
            fieldKULLANICI_BELGE_NO.FieldName = "KULLANICI_BELGE_NO";
            fieldKULLANICI_BELGE_NO.Name = "fieldKULLANICI_BELGE_NO";
            fieldKULLANICI_BELGE_NO.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 24;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 25;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldANA_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldANA_KATEGORI.AreaIndex = 26;
            fieldANA_KATEGORI.FieldName = "ANA_KATEGORI";
            fieldANA_KATEGORI.Name = "fieldANA_KATEGORI";
            fieldANA_KATEGORI.Visible = false;

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALT_KATEGORI.AreaIndex = 27;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 28;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 29;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 30;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldKDV_DAHIL = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_DAHIL.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_DAHIL.AreaIndex = 31;
            fieldKDV_DAHIL.FieldName = "KDV_DAHIL";
            fieldKDV_DAHIL.Name = "fieldKDV_DAHIL";
            fieldKDV_DAHIL.Visible = false;

            PivotGridField fieldKDV_ORAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_ORAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_ORAN.AreaIndex = 32;
            fieldKDV_ORAN.FieldName = "KDV_ORAN";
            fieldKDV_ORAN.Name = "fieldKDV_ORAN";
            fieldKDV_ORAN.Visible = false;

            PivotGridField fieldKDV_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_TUTAR.AreaIndex = 33;
            fieldKDV_TUTAR.FieldName = "KDV_TUTAR";
            fieldKDV_TUTAR.Name = "fieldKDV_TUTAR";
            fieldKDV_TUTAR.Visible = false;

            PivotGridField fieldSTOPAJ_SSDF_DAHIL = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSTOPAJ_SSDF_DAHIL.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSTOPAJ_SSDF_DAHIL.AreaIndex = 34;
            fieldSTOPAJ_SSDF_DAHIL.FieldName = "STOPAJ_SSDF_DAHIL";
            fieldSTOPAJ_SSDF_DAHIL.Name = "fieldSTOPAJ_SSDF_DAHIL";
            fieldSTOPAJ_SSDF_DAHIL.Visible = false;

            PivotGridField fieldSTOPAJ_ORAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSTOPAJ_ORAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSTOPAJ_ORAN.AreaIndex = 35;
            fieldSTOPAJ_ORAN.FieldName = "STOPAJ_ORAN";
            fieldSTOPAJ_ORAN.Name = "fieldSTOPAJ_ORAN";
            fieldSTOPAJ_ORAN.Visible = false;

            PivotGridField fieldSSDF_ORAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSSDF_ORAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSSDF_ORAN.AreaIndex = 36;
            fieldSSDF_ORAN.FieldName = "SSDF_ORAN";
            fieldSSDF_ORAN.Name = "fieldSSDF_ORAN";
            fieldSSDF_ORAN.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 37;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldONAY_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONAY_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONAY_DURUM.AreaIndex = 38;
            fieldONAY_DURUM.FieldName = "ONAY_DURUM";
            fieldONAY_DURUM.Name = "fieldONAY_DURUM";
            fieldONAY_DURUM.Visible = false;

            PivotGridField fieldONAY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONAY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONAY_NO.AreaIndex = 39;
            fieldONAY_NO.FieldName = "ONAY_NO";
            fieldONAY_NO.Name = "fieldONAY_NO";
            fieldONAY_NO.Visible = false;

            PivotGridField fieldONAY_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONAY_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONAY_TARIHI.AreaIndex = 40;
            fieldONAY_TARIHI.FieldName = "ONAY_TARIHI";
            fieldONAY_TARIHI.Name = "fieldONAY_TARIHI";
            fieldONAY_TARIHI.Visible = false;

            PivotGridField fieldINCELENDI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINCELENDI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINCELENDI.AreaIndex = 41;
            fieldINCELENDI.FieldName = "INCELENDI";
            fieldINCELENDI.Name = "fieldINCELENDI";
            fieldINCELENDI.Visible = false;

            PivotGridField fieldTUM_MUVEKKILLERE_PAYLASTIR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MUVEKKILLERE_PAYLASTIR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MUVEKKILLERE_PAYLASTIR.AreaIndex = 42;
            fieldTUM_MUVEKKILLERE_PAYLASTIR.FieldName = "TUM_MUVEKKILLERE_PAYLASTIR";
            fieldTUM_MUVEKKILLERE_PAYLASTIR.Name = "fieldTUM_MUVEKKILLERE_PAYLASTIR";
            fieldTUM_MUVEKKILLERE_PAYLASTIR.Visible = false;

            PivotGridField fieldGENEL_TOPLAM_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGENEL_TOPLAM_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGENEL_TOPLAM_DOVIZ_ID.AreaIndex = 43;
            fieldGENEL_TOPLAM_DOVIZ_ID.FieldName = "GENEL_TOPLAM_DOVIZ_ID";
            fieldGENEL_TOPLAM_DOVIZ_ID.Name = "fieldGENEL_TOPLAM_DOVIZ_ID";
            fieldGENEL_TOPLAM_DOVIZ_ID.Visible = false;

            PivotGridField fieldGENEL_TOPLAM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGENEL_TOPLAM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGENEL_TOPLAM.AreaIndex = 44;
            fieldGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            fieldGENEL_TOPLAM.Name = "fieldGENEL_TOPLAM";
            fieldGENEL_TOPLAM.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 45;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR.AreaIndex = 46;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = false;

            PivotGridField fieldSTOPAJ_SSDF_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSTOPAJ_SSDF_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSTOPAJ_SSDF_TUTAR.AreaIndex = 47;
            fieldSTOPAJ_SSDF_TUTAR.FieldName = "STOPAJ_SSDF_TUTAR";
            fieldSTOPAJ_SSDF_TUTAR.Name = "fieldSTOPAJ_SSDF_TUTAR";
            fieldSTOPAJ_SSDF_TUTAR.Visible = false;

            PivotGridField fieldTO_HESAP_CETVEL_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_HESAP_CETVEL_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_HESAP_CETVEL_YERI.AreaIndex = 48;
            fieldTO_HESAP_CETVEL_YERI.FieldName = "TO_HESAP_CETVEL_YERI";
            fieldTO_HESAP_CETVEL_YERI.Name = "fieldTO_HESAP_CETVEL_YERI";
            fieldTO_HESAP_CETVEL_YERI.Visible = false;

            PivotGridField fieldTS_HESAP_CETVEL_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_HESAP_CETVEL_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_HESAP_CETVEL_YERI.AreaIndex = 49;
            fieldTS_HESAP_CETVEL_YERI.FieldName = "TS_HESAP_CETVEL_YERI";
            fieldTS_HESAP_CETVEL_YERI.Name = "fieldTS_HESAP_CETVEL_YERI";
            fieldTS_HESAP_CETVEL_YERI.Visible = false;

            PivotGridField fieldDO_HESAP_CETVEL_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDO_HESAP_CETVEL_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDO_HESAP_CETVEL_YERI.AreaIndex = 50;
            fieldDO_HESAP_CETVEL_YERI.FieldName = "DO_HESAP_CETVEL_YERI";
            fieldDO_HESAP_CETVEL_YERI.Name = "fieldDO_HESAP_CETVEL_YERI";
            fieldDO_HESAP_CETVEL_YERI.Visible = false;

            PivotGridField fieldDS_HESAP_CETVEL_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDS_HESAP_CETVEL_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDS_HESAP_CETVEL_YERI.AreaIndex = 51;
            fieldDS_HESAP_CETVEL_YERI.FieldName = "DS_HESAP_CETVEL_YERI";
            fieldDS_HESAP_CETVEL_YERI.Name = "fieldDS_HESAP_CETVEL_YERI";
            fieldDS_HESAP_CETVEL_YERI.Visible = false;

            PivotGridField fieldMUVEKKIL = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL.AreaIndex = 52;
            fieldMUVEKKIL.FieldName = "MUVEKKIL";
            fieldMUVEKKIL.Name = "fieldMUVEKKIL";
            fieldMUVEKKIL.Visible = false;

            PivotGridField fieldSEGMENT_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSEGMENT_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSEGMENT_ID.AreaIndex = 53;
            fieldSEGMENT_ID.FieldName = "SEGMENT_ID";
            fieldSEGMENT_ID.Name = "fieldSEGMENT_ID";
            fieldSEGMENT_ID.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 54;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldMASRAF_AVANS_TIP,
			fieldKAYIT_TARIHI,
			fieldKLASOR_KODU,
			fieldSUBE_ADI,
			fieldBORCLU,
			fieldSORUMLU,
			fieldBANKA,
			fieldSUBE,
			fieldKREDI_GRUP,
			fieldKREDI_TIP,
			fieldKONTROL_KIM,
			fieldKONTROL_NE_ZAMAN,
			fieldKLASOR_1,
			fieldKLASOR_2,
			fieldMODUL_ID,
			fieldID,
			fieldKAYIT_ID,
			fieldFOY_NO,
			fieldADLIYE,
			fieldNO,
			fieldGOREV,
			fieldTARIH,
			fieldKULLANICI_BELGE_NO,
			fieldBORC_ALACAK,
			fieldODEME_TIP,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldADET,
			fieldBIRIM_FIYAT,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldKDV_DAHIL,
			fieldKDV_ORAN,
			fieldKDV_TUTAR,
			fieldSTOPAJ_SSDF_DAHIL,
			fieldSTOPAJ_ORAN,
			fieldSSDF_ORAN,
			fieldACIKLAMA,
			fieldONAY_DURUM,
			fieldONAY_NO,
			fieldONAY_TARIHI,
			fieldINCELENDI,
			fieldTUM_MUVEKKILLERE_PAYLASTIR,
			fieldGENEL_TOPLAM_DOVIZ_ID,
			fieldGENEL_TOPLAM,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldTOPLAM_TUTAR,
			fieldSTOPAJ_SSDF_TUTAR,
			fieldTO_HESAP_CETVEL_YERI,
			fieldTS_HESAP_CETVEL_YERI,
			fieldDO_HESAP_CETVEL_YERI,
			fieldDS_HESAP_CETVEL_YERI,
			fieldMUVEKKIL,
			fieldSEGMENT_ID,
            fieldBOLGE,
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

            #region Caption Edit

            dicFieldCaption.Add("REFERANS_NO", "Ref No");
            dicFieldCaption.Add("MASRAF_AVANS_TIP", "Masraf Avans Tip");
            dicFieldCaption.Add("KAYIT_TARIHI", "Kayıt T");
            dicFieldCaption.Add("KLASOR_KODU", "Klasör Kod");
            dicFieldCaption.Add("SUBE_ADI", "Büro");
            dicFieldCaption.Add("BORCLU", "Borçlu");
            dicFieldCaption.Add("SORUMLU", "Sorumlu");
            dicFieldCaption.Add("BANKA", "Banka");
            dicFieldCaption.Add("SUBE", "Şube");
            dicFieldCaption.Add("KREDI_GRUP", "Kredi Grup");
            dicFieldCaption.Add("KREDI_TIP", "Kredi Tip");
            dicFieldCaption.Add("KONTROL_KIM", "Kullanıcı");
            dicFieldCaption.Add("KONTROL_NE_ZAMAN", "Kontrol Ne Zaman");
            dicFieldCaption.Add("KLASOR_1", "Klasör1");
            dicFieldCaption.Add("KLASOR_2", "Klasör2");
            dicFieldCaption.Add("MODUL_ID", "Modul");
            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("KAYIT_ID", "");
            dicFieldCaption.Add("FOY_NO", "Foy No");
            dicFieldCaption.Add("ADLIYE", "Adliye");
            dicFieldCaption.Add("NO", "Birim No");
            dicFieldCaption.Add("GOREV", "Görev");
            dicFieldCaption.Add("TARIH", "T");
            dicFieldCaption.Add("KULLANICI_BELGE_NO", "Kullanıcı Belge No");
            dicFieldCaption.Add("BORC_ALACAK", "Borç Alacak");
            dicFieldCaption.Add("ODEME_TIP", "Ödeme Tipi");
            dicFieldCaption.Add("ANA_KATEGORI", "Ana Kat.");
            dicFieldCaption.Add("ALT_KATEGORI", "Alt Kat");
            dicFieldCaption.Add("ADET", "Adet");
            dicFieldCaption.Add("BIRIM_FIYAT", "Birim Fiyat");
            dicFieldCaption.Add("KDV_DAHIL", "KDV Dahil");
            dicFieldCaption.Add("KDV_ORAN", "KDV Oran");
            dicFieldCaption.Add("KDV_TUTAR", "KDV Tutar");
            dicFieldCaption.Add("STOPAJ_SSDF_DAHIL", "Stopaj SSDF Dahil");
            dicFieldCaption.Add("STOPAJ_ORAN", "Stopaj Oran");
            dicFieldCaption.Add("SSDF_ORAN", "SSDF Oran");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("ONAY_DURUM", "Onay Durum");
            dicFieldCaption.Add("ONAY_NO", "Onay No");
            dicFieldCaption.Add("ONAY_TARIHI", "Onay T");
            dicFieldCaption.Add("INCELENDI", "İncelendi");
            dicFieldCaption.Add("TUM_MUVEKKILLERE_PAYLASTIR", "Tüm Müvekkillere Paylaştır");
            dicFieldCaption.Add("GENEL_TOPLAM", "Genel Toplam");
            dicFieldCaption.Add("TOPLAM_TUTAR", "Toplam Tutar");
            dicFieldCaption.Add("STOPAJ_SSDF_TUTAR", "Stopaj SSDV Tutar");
            dicFieldCaption.Add("TO_HESAP_CETVEL_YERI", "T.Ö. Hesap Cetvel Yeri");
            dicFieldCaption.Add("TS_HESAP_CETVEL_YERI", "T.S Hesap Cetvel Yeri");
            dicFieldCaption.Add("DO_HESAP_CETVEL_YERI", "D.Ö Hesap Cetvel Yeri");
            dicFieldCaption.Add("DS_HESAP_CETVEL_YERI", "D.S. Hesap Cetvel Yeri");
            dicFieldCaption.Add("MUVEKKIL", "Müvekkil");
            dicFieldCaption.Add("SEGMENT_ID", "Bölüm");
            dicFieldCaption.Add("BOLGE", "Bölge");

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
            sozluk.Add("SEGMENT_ID", InitsEx.SegmnetBolumGetir);
            sozluk.Add("KDV_TUTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TOPLAM_TUTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("STOPAJ_SSDF_TUTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("MASRAF_AVANS_TIP", InitsEx.MasrafAvansTip);

            #endregion Add item

            return sozluk;
        }
    }
}