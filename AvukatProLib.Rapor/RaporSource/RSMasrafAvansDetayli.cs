using AvukatProLib2.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;
using System;
using System.Collections.Generic;
using Inits = BelgeUtil.Inits;

namespace AvukatProLib.Rapor.RaporSource
{
    internal class RSMasrafAvansDetayli : Util.IRaporSource
    {
        #region Settings

        public bool EnableChart
        {
            get { return false; }
        }

        public bool EnableGrid
        {
            get { return true; }
        }

        public bool EnablePivot
        {
            get { return true; }
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

        public string Groups
        {
            get { return "Masraf Avans"; }
        }

        public string MenuName
        {
            get { return "Masraf Avans Detaylý"; }
        }

        public string Title
        {
            get { return "Title"; }
        }

        #endregion Settings

        public GridColumn[] GetGridColumns()
        {
            #region Field & Properties

            GridColumn colBIRIM_FIYAT = new GridColumn();
            colBIRIM_FIYAT.VisibleIndex = 0;
            colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
            colBIRIM_FIYAT.Visible = true;

            GridColumn colKDV_DAHIL = new GridColumn();
            colKDV_DAHIL.VisibleIndex = 1;
            colKDV_DAHIL.FieldName = "KDV_DAHIL";
            colKDV_DAHIL.Name = "colKDV_DAHIL";
            colKDV_DAHIL.Visible = true;

            GridColumn colKDV_TUTAR = new GridColumn();
            colKDV_TUTAR.VisibleIndex = 2;
            colKDV_TUTAR.FieldName = "KDV_TUTAR";
            colKDV_TUTAR.Name = "colKDV_TUTAR";
            colKDV_TUTAR.Visible = true;

            GridColumn colSTOPAJ_SSDF_DAHIL = new GridColumn();
            colSTOPAJ_SSDF_DAHIL.VisibleIndex = 3;
            colSTOPAJ_SSDF_DAHIL.FieldName = "STOPAJ_SSDF_DAHIL";
            colSTOPAJ_SSDF_DAHIL.Name = "colSTOPAJ_SSDF_DAHIL";
            colSTOPAJ_SSDF_DAHIL.Visible = true;

            GridColumn colSTOPAJ_ORAN = new GridColumn();
            colSTOPAJ_ORAN.VisibleIndex = 4;
            colSTOPAJ_ORAN.FieldName = "STOPAJ_ORAN";
            colSTOPAJ_ORAN.Name = "colSTOPAJ_ORAN";
            colSTOPAJ_ORAN.Visible = true;

            GridColumn colKDV_ORAN = new GridColumn();
            colKDV_ORAN.VisibleIndex = 5;
            colKDV_ORAN.FieldName = "KDV_ORAN";
            colKDV_ORAN.Name = "colKDV_ORAN";
            colKDV_ORAN.Visible = true;

            GridColumn colSTOPAJ_SSDF_TUTAR = new GridColumn();
            colSTOPAJ_SSDF_TUTAR.VisibleIndex = 6;
            colSTOPAJ_SSDF_TUTAR.FieldName = "STOPAJ_SSDF_TUTAR";
            colSTOPAJ_SSDF_TUTAR.Name = "colSTOPAJ_SSDF_TUTAR";
            colSTOPAJ_SSDF_TUTAR.Visible = true;

            GridColumn colSSDF_ORAN = new GridColumn();
            colSSDF_ORAN.VisibleIndex = 7;
            colSSDF_ORAN.FieldName = "SSDF_ORAN";
            colSSDF_ORAN.Name = "colSSDF_ORAN";
            colSSDF_ORAN.Visible = true;

            GridColumn colTOPLAM_TUTAR = new GridColumn();
            colTOPLAM_TUTAR.VisibleIndex = 8;
            colTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            colTOPLAM_TUTAR.Name = "colTOPLAM_TUTAR";
            colTOPLAM_TUTAR.Visible = true;

            GridColumn colTOPLAM_TUTAR_DOVIZ_ID = new GridColumn();
            colTOPLAM_TUTAR_DOVIZ_ID.VisibleIndex = 9;
            colTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            colTOPLAM_TUTAR_DOVIZ_ID.Name = "colTOPLAM_TUTAR_DOVIZ_ID";
            colTOPLAM_TUTAR_DOVIZ_ID.Visible = true;

            GridColumn colGENEL_TOPLAM = new GridColumn();
            colGENEL_TOPLAM.VisibleIndex = 10;
            colGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
            colGENEL_TOPLAM.Visible = true;

            GridColumn colGENEL_TOPLAM_DOVIZ_ID = new GridColumn();
            colGENEL_TOPLAM_DOVIZ_ID.VisibleIndex = 11;
            colGENEL_TOPLAM_DOVIZ_ID.FieldName = "GENEL_TOPLAM_DOVIZ_ID";
            colGENEL_TOPLAM_DOVIZ_ID.Name = "colGENEL_TOPLAM_DOVIZ_ID";
            colGENEL_TOPLAM_DOVIZ_ID.Visible = true;

            GridColumn colTUM_MUVEKKILLERE_PAYLASTIR = new GridColumn();
            colTUM_MUVEKKILLERE_PAYLASTIR.VisibleIndex = 12;
            colTUM_MUVEKKILLERE_PAYLASTIR.FieldName = "TUM_MUVEKKILLERE_PAYLASTIR";
            colTUM_MUVEKKILLERE_PAYLASTIR.Name = "colTUM_MUVEKKILLERE_PAYLASTIR";
            colTUM_MUVEKKILLERE_PAYLASTIR.Visible = true;

            GridColumn colMUVEKKIL_CARI_ID = new GridColumn();
            colMUVEKKIL_CARI_ID.VisibleIndex = 13;
            colMUVEKKIL_CARI_ID.FieldName = "MUVEKKIL_CARI_ID";
            colMUVEKKIL_CARI_ID.Name = "colMUVEKKIL_CARI_ID";
            colMUVEKKIL_CARI_ID.Visible = true;

            GridColumn colINCELENDI = new GridColumn();
            colINCELENDI.VisibleIndex = 14;
            colINCELENDI.FieldName = "INCELENDI";
            colINCELENDI.Name = "colINCELENDI";
            colINCELENDI.Visible = true;

            GridColumn colONAY_TARIHI = new GridColumn();
            colONAY_TARIHI.VisibleIndex = 15;
            colONAY_TARIHI.FieldName = "ONAY_TARIHI";
            colONAY_TARIHI.Name = "colONAY_TARIHI";
            colONAY_TARIHI.Visible = true;

            GridColumn colONAY_NO = new GridColumn();
            colONAY_NO.VisibleIndex = 16;
            colONAY_NO.FieldName = "ONAY_NO";
            colONAY_NO.Name = "colONAY_NO";
            colONAY_NO.Visible = true;

            GridColumn colONAY_DURUM = new GridColumn();
            colONAY_DURUM.VisibleIndex = 17;
            colONAY_DURUM.FieldName = "ONAY_DURUM";
            colONAY_DURUM.Name = "colONAY_DURUM";
            colONAY_DURUM.Visible = true;

            GridColumn colDETAY_ACIKLAMA = new GridColumn();
            colDETAY_ACIKLAMA.VisibleIndex = 18;
            colDETAY_ACIKLAMA.FieldName = "DETAY_ACIKLAMA";
            colDETAY_ACIKLAMA.Name = "colDETAY_ACIKLAMA";
            colDETAY_ACIKLAMA.Visible = true;

            GridColumn colCARI_ID = new GridColumn();
            colCARI_ID.VisibleIndex = 19;
            colCARI_ID.FieldName = "CARI_ID";
            colCARI_ID.Name = "colCARI_ID";
            colCARI_ID.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 20;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colMASRAF_AVANS_TIP = new GridColumn();
            colMASRAF_AVANS_TIP.VisibleIndex = 21;
            colMASRAF_AVANS_TIP.FieldName = "MASRAF_AVANS_TIP";
            colMASRAF_AVANS_TIP.Name = "colMASRAF_AVANS_TIP";
            colMASRAF_AVANS_TIP.Visible = true;

            GridColumn colKAYIT_ID = new GridColumn();
            colKAYIT_ID.VisibleIndex = 22;
            colKAYIT_ID.FieldName = "KAYIT_ID";
            colKAYIT_ID.Name = "colKAYIT_ID";
            colKAYIT_ID.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 23;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colBORCLU_CARI_ID = new GridColumn();
            colBORCLU_CARI_ID.VisibleIndex = 24;
            colBORCLU_CARI_ID.FieldName = "BORCLU_CARI_ID";
            colBORCLU_CARI_ID.Name = "colBORCLU_CARI_ID";
            colBORCLU_CARI_ID.Visible = true;

            GridColumn colALACAK_NEDEN_ID = new GridColumn();
            colALACAK_NEDEN_ID.VisibleIndex = 25;
            colALACAK_NEDEN_ID.FieldName = "ALACAK_NEDEN_ID";
            colALACAK_NEDEN_ID.Name = "colALACAK_NEDEN_ID";
            colALACAK_NEDEN_ID.Visible = true;

            GridColumn colMODUL_ID = new GridColumn();
            colMODUL_ID.VisibleIndex = 26;
            colMODUL_ID.FieldName = "MODUL_ID";
            colMODUL_ID.Name = "colMODUL_ID";
            colMODUL_ID.Visible = true;

            GridColumn colTARIH = new GridColumn();
            colTARIH.VisibleIndex = 27;
            colTARIH.FieldName = "TARIH";
            colTARIH.Name = "colTARIH";
            colTARIH.Visible = true;

            GridColumn colKULLANICI_BELGE_NO = new GridColumn();
            colKULLANICI_BELGE_NO.VisibleIndex = 28;
            colKULLANICI_BELGE_NO.FieldName = "KULLANICI_BELGE_NO";
            colKULLANICI_BELGE_NO.Name = "colKULLANICI_BELGE_NO";
            colKULLANICI_BELGE_NO.Visible = true;

            GridColumn colBORC_ALACAK_ID = new GridColumn();
            colBORC_ALACAK_ID.VisibleIndex = 29;
            colBORC_ALACAK_ID.FieldName = "BORC_ALACAK_ID";
            colBORC_ALACAK_ID.Name = "colBORC_ALACAK_ID";
            colBORC_ALACAK_ID.Visible = true;

            GridColumn colODEME_TIP_ID = new GridColumn();
            colODEME_TIP_ID.VisibleIndex = 30;
            colODEME_TIP_ID.FieldName = "ODEME_TIP_ID";
            colODEME_TIP_ID.Name = "colODEME_TIP_ID";
            colODEME_TIP_ID.Visible = true;

            GridColumn colHAREKET_ANA_KATEGORI_ID = new GridColumn();
            colHAREKET_ANA_KATEGORI_ID.VisibleIndex = 31;
            colHAREKET_ANA_KATEGORI_ID.FieldName = "HAREKET_ANA_KATEGORI_ID";
            colHAREKET_ANA_KATEGORI_ID.Name = "colHAREKET_ANA_KATEGORI_ID";
            colHAREKET_ANA_KATEGORI_ID.Visible = true;

            GridColumn colHAREKET_ALT_KATEGORI_ID = new GridColumn();
            colHAREKET_ALT_KATEGORI_ID.VisibleIndex = 32;
            colHAREKET_ALT_KATEGORI_ID.FieldName = "HAREKET_ALT_KATEGORI_ID";
            colHAREKET_ALT_KATEGORI_ID.Name = "colHAREKET_ALT_KATEGORI_ID";
            colHAREKET_ALT_KATEGORI_ID.Visible = true;

            GridColumn colADET = new GridColumn();
            colADET.VisibleIndex = 33;
            colADET.FieldName = "ADET";
            colADET.Name = "colADET";
            colADET.Visible = true;

            GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
            colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 34;
            colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Visible = true;

            GridColumn colTO_HESAP_CETVEL_YERI = new GridColumn();
            colTO_HESAP_CETVEL_YERI.VisibleIndex = 35;
            colTO_HESAP_CETVEL_YERI.FieldName = "TO_HESAP_CETVEL_YERI";
            colTO_HESAP_CETVEL_YERI.Name = "colTO_HESAP_CETVEL_YERI";
            colTO_HESAP_CETVEL_YERI.Visible = true;

            GridColumn colTS_HESAP_CETVEL_YERI = new GridColumn();
            colTS_HESAP_CETVEL_YERI.VisibleIndex = 36;
            colTS_HESAP_CETVEL_YERI.FieldName = "TS_HESAP_CETVEL_YERI";
            colTS_HESAP_CETVEL_YERI.Name = "colTS_HESAP_CETVEL_YERI";
            colTS_HESAP_CETVEL_YERI.Visible = true;

            GridColumn colDO_HESAP_CETVEL_YERI = new GridColumn();
            colDO_HESAP_CETVEL_YERI.VisibleIndex = 37;
            colDO_HESAP_CETVEL_YERI.FieldName = "DO_HESAP_CETVEL_YERI";
            colDO_HESAP_CETVEL_YERI.Name = "colDO_HESAP_CETVEL_YERI";
            colDO_HESAP_CETVEL_YERI.Visible = true;

            GridColumn colDS_HESAP_CETVEL_YERI = new GridColumn();
            colDS_HESAP_CETVEL_YERI.VisibleIndex = 38;
            colDS_HESAP_CETVEL_YERI.FieldName = "DS_HESAP_CETVEL_YERI";
            colDS_HESAP_CETVEL_YERI.Name = "colDS_HESAP_CETVEL_YERI";
            colDS_HESAP_CETVEL_YERI.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 39;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colADLI_BIRIM_ADLIYE_ID = new GridColumn();
            colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 40;
            colADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
            colADLI_BIRIM_ADLIYE_ID.Visible = true;

            GridColumn colADLI_BIRIM_NO_ID = new GridColumn();
            colADLI_BIRIM_NO_ID.VisibleIndex = 41;
            colADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            colADLI_BIRIM_NO_ID.Name = "colADLI_BIRIM_NO_ID";
            colADLI_BIRIM_NO_ID.Visible = true;

            GridColumn colADLI_BIRIM_GOREV_ID = new GridColumn();
            colADLI_BIRIM_GOREV_ID.VisibleIndex = 42;
            colADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            colADLI_BIRIM_GOREV_ID.Name = "colADLI_BIRIM_GOREV_ID";
            colADLI_BIRIM_GOREV_ID.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 43;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colBIRIM_FIYAT,
			colKDV_DAHIL,
			colKDV_TUTAR,
			colSTOPAJ_SSDF_DAHIL,
			colSTOPAJ_ORAN,
			colKDV_ORAN,
			colSTOPAJ_SSDF_TUTAR,
			colSSDF_ORAN,
			colTOPLAM_TUTAR,
			colTOPLAM_TUTAR_DOVIZ_ID,
			colGENEL_TOPLAM,
			colGENEL_TOPLAM_DOVIZ_ID,
			colTUM_MUVEKKILLERE_PAYLASTIR,
			colMUVEKKIL_CARI_ID,
			colINCELENDI,
			colONAY_TARIHI,
			colONAY_NO,
			colONAY_DURUM,
			colDETAY_ACIKLAMA,
			colCARI_ID,
			colREFERANS_NO,
			colMASRAF_AVANS_TIP,
			colKAYIT_ID,
			colACIKLAMA,
			colBORCLU_CARI_ID,
			colALACAK_NEDEN_ID,
			colMODUL_ID,
			colTARIH,
			colKULLANICI_BELGE_NO,
			colBORC_ALACAK_ID,
			colODEME_TIP_ID,
			colHAREKET_ANA_KATEGORI_ID,
			colHAREKET_ALT_KATEGORI_ID,
			colADET,
			colBIRIM_FIYAT_DOVIZ_ID,
			colTO_HESAP_CETVEL_YERI,
			colTS_HESAP_CETVEL_YERI,
			colDO_HESAP_CETVEL_YERI,
			colDS_HESAP_CETVEL_YERI,
			colFOY_NO,
			colADLI_BIRIM_ADLIYE_ID,
			colADLI_BIRIM_NO_ID,
			colADLI_BIRIM_GOREV_ID,
			colESAS_NO,
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

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 0;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldKDV_DAHIL = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_DAHIL.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_DAHIL.AreaIndex = 1;
            fieldKDV_DAHIL.FieldName = "KDV_DAHIL";
            fieldKDV_DAHIL.Name = "fieldKDV_DAHIL";
            fieldKDV_DAHIL.Visible = false;

            PivotGridField fieldKDV_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_TUTAR.AreaIndex = 2;
            fieldKDV_TUTAR.FieldName = "KDV_TUTAR";
            fieldKDV_TUTAR.Name = "fieldKDV_TUTAR";
            fieldKDV_TUTAR.Visible = false;

            PivotGridField fieldSTOPAJ_SSDF_DAHIL = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSTOPAJ_SSDF_DAHIL.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSTOPAJ_SSDF_DAHIL.AreaIndex = 3;
            fieldSTOPAJ_SSDF_DAHIL.FieldName = "STOPAJ_SSDF_DAHIL";
            fieldSTOPAJ_SSDF_DAHIL.Name = "fieldSTOPAJ_SSDF_DAHIL";
            fieldSTOPAJ_SSDF_DAHIL.Visible = false;

            PivotGridField fieldSTOPAJ_ORAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSTOPAJ_ORAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSTOPAJ_ORAN.AreaIndex = 4;
            fieldSTOPAJ_ORAN.FieldName = "STOPAJ_ORAN";
            fieldSTOPAJ_ORAN.Name = "fieldSTOPAJ_ORAN";
            fieldSTOPAJ_ORAN.Visible = false;

            PivotGridField fieldKDV_ORAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_ORAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_ORAN.AreaIndex = 5;
            fieldKDV_ORAN.FieldName = "KDV_ORAN";
            fieldKDV_ORAN.Name = "fieldKDV_ORAN";
            fieldKDV_ORAN.Visible = false;

            PivotGridField fieldSTOPAJ_SSDF_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSTOPAJ_SSDF_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSTOPAJ_SSDF_TUTAR.AreaIndex = 6;
            fieldSTOPAJ_SSDF_TUTAR.FieldName = "STOPAJ_SSDF_TUTAR";
            fieldSTOPAJ_SSDF_TUTAR.Name = "fieldSTOPAJ_SSDF_TUTAR";
            fieldSTOPAJ_SSDF_TUTAR.Visible = false;

            PivotGridField fieldSSDF_ORAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSSDF_ORAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSSDF_ORAN.AreaIndex = 7;
            fieldSSDF_ORAN.FieldName = "SSDF_ORAN";
            fieldSSDF_ORAN.Name = "fieldSSDF_ORAN";
            fieldSSDF_ORAN.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR.AreaIndex = 8;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 9;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldGENEL_TOPLAM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGENEL_TOPLAM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGENEL_TOPLAM.AreaIndex = 10;
            fieldGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            fieldGENEL_TOPLAM.Name = "fieldGENEL_TOPLAM";
            fieldGENEL_TOPLAM.Visible = false;

            PivotGridField fieldGENEL_TOPLAM_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGENEL_TOPLAM_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGENEL_TOPLAM_DOVIZ_ID.AreaIndex = 11;
            fieldGENEL_TOPLAM_DOVIZ_ID.FieldName = "GENEL_TOPLAM_DOVIZ_ID";
            fieldGENEL_TOPLAM_DOVIZ_ID.Name = "fieldGENEL_TOPLAM_DOVIZ_ID";
            fieldGENEL_TOPLAM_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MUVEKKILLERE_PAYLASTIR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MUVEKKILLERE_PAYLASTIR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MUVEKKILLERE_PAYLASTIR.AreaIndex = 12;
            fieldTUM_MUVEKKILLERE_PAYLASTIR.FieldName = "TUM_MUVEKKILLERE_PAYLASTIR";
            fieldTUM_MUVEKKILLERE_PAYLASTIR.Name = "fieldTUM_MUVEKKILLERE_PAYLASTIR";
            fieldTUM_MUVEKKILLERE_PAYLASTIR.Visible = false;

            PivotGridField fieldMUVEKKIL_CARI_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_CARI_ID.AreaIndex = 13;
            fieldMUVEKKIL_CARI_ID.FieldName = "MUVEKKIL_CARI_ID";
            fieldMUVEKKIL_CARI_ID.Name = "fieldMUVEKKIL_CARI_ID";
            fieldMUVEKKIL_CARI_ID.Visible = false;

            PivotGridField fieldINCELENDI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINCELENDI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINCELENDI.AreaIndex = 14;
            fieldINCELENDI.FieldName = "INCELENDI";
            fieldINCELENDI.Name = "fieldINCELENDI";
            fieldINCELENDI.Visible = false;

            PivotGridField fieldONAY_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONAY_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONAY_TARIHI.AreaIndex = 15;
            fieldONAY_TARIHI.FieldName = "ONAY_TARIHI";
            fieldONAY_TARIHI.Name = "fieldONAY_TARIHI";
            fieldONAY_TARIHI.Visible = false;

            PivotGridField fieldONAY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONAY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONAY_NO.AreaIndex = 16;
            fieldONAY_NO.FieldName = "ONAY_NO";
            fieldONAY_NO.Name = "fieldONAY_NO";
            fieldONAY_NO.Visible = false;

            PivotGridField fieldONAY_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldONAY_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldONAY_DURUM.AreaIndex = 17;
            fieldONAY_DURUM.FieldName = "ONAY_DURUM";
            fieldONAY_DURUM.Name = "fieldONAY_DURUM";
            fieldONAY_DURUM.Visible = false;

            PivotGridField fieldDETAY_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDETAY_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDETAY_ACIKLAMA.AreaIndex = 18;
            fieldDETAY_ACIKLAMA.FieldName = "DETAY_ACIKLAMA";
            fieldDETAY_ACIKLAMA.Name = "fieldDETAY_ACIKLAMA";
            fieldDETAY_ACIKLAMA.Visible = false;

            PivotGridField fieldCARI_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCARI_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCARI_ID.AreaIndex = 19;
            fieldCARI_ID.FieldName = "CARI_ID";
            fieldCARI_ID.Name = "fieldCARI_ID";
            fieldCARI_ID.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 20;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldMASRAF_AVANS_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_AVANS_TIP.AreaIndex = 21;
            fieldMASRAF_AVANS_TIP.FieldName = "MASRAF_AVANS_TIP";
            fieldMASRAF_AVANS_TIP.Name = "fieldMASRAF_AVANS_TIP";
            fieldMASRAF_AVANS_TIP.Visible = false;

            PivotGridField fieldKAYIT_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAYIT_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAYIT_ID.AreaIndex = 22;
            fieldKAYIT_ID.FieldName = "KAYIT_ID";
            fieldKAYIT_ID.Name = "fieldKAYIT_ID";
            fieldKAYIT_ID.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 23;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldBORCLU_CARI_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORCLU_CARI_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORCLU_CARI_ID.AreaIndex = 24;
            fieldBORCLU_CARI_ID.FieldName = "BORCLU_CARI_ID";
            fieldBORCLU_CARI_ID.Name = "fieldBORCLU_CARI_ID";
            fieldBORCLU_CARI_ID.Visible = false;

            PivotGridField fieldALACAK_NEDEN_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_NEDEN_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_NEDEN_ID.AreaIndex = 25;
            fieldALACAK_NEDEN_ID.FieldName = "ALACAK_NEDEN_ID";
            fieldALACAK_NEDEN_ID.Name = "fieldALACAK_NEDEN_ID";
            fieldALACAK_NEDEN_ID.Visible = false;

            PivotGridField fieldMODUL_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMODUL_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMODUL_ID.AreaIndex = 26;
            fieldMODUL_ID.FieldName = "MODUL_ID";
            fieldMODUL_ID.Name = "fieldMODUL_ID";
            fieldMODUL_ID.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 27;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldKULLANICI_BELGE_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKULLANICI_BELGE_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKULLANICI_BELGE_NO.AreaIndex = 28;
            fieldKULLANICI_BELGE_NO.FieldName = "KULLANICI_BELGE_NO";
            fieldKULLANICI_BELGE_NO.Name = "fieldKULLANICI_BELGE_NO";
            fieldKULLANICI_BELGE_NO.Visible = false;

            PivotGridField fieldBORC_ALACAK_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK_ID.AreaIndex = 29;
            fieldBORC_ALACAK_ID.FieldName = "BORC_ALACAK_ID";
            fieldBORC_ALACAK_ID.Name = "fieldBORC_ALACAK_ID";
            fieldBORC_ALACAK_ID.Visible = false;

            PivotGridField fieldODEME_TIP_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP_ID.AreaIndex = 30;
            fieldODEME_TIP_ID.FieldName = "ODEME_TIP_ID";
            fieldODEME_TIP_ID.Name = "fieldODEME_TIP_ID";
            fieldODEME_TIP_ID.Visible = false;

            PivotGridField fieldHAREKET_ANA_KATEGORI_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAREKET_ANA_KATEGORI_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAREKET_ANA_KATEGORI_ID.AreaIndex = 31;
            fieldHAREKET_ANA_KATEGORI_ID.FieldName = "HAREKET_ANA_KATEGORI_ID";
            fieldHAREKET_ANA_KATEGORI_ID.Name = "fieldHAREKET_ANA_KATEGORI_ID";
            fieldHAREKET_ANA_KATEGORI_ID.Visible = false;

            PivotGridField fieldHAREKET_ALT_KATEGORI_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAREKET_ALT_KATEGORI_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAREKET_ALT_KATEGORI_ID.AreaIndex = 32;
            fieldHAREKET_ALT_KATEGORI_ID.FieldName = "HAREKET_ALT_KATEGORI_ID";
            fieldHAREKET_ALT_KATEGORI_ID.Name = "fieldHAREKET_ALT_KATEGORI_ID";
            fieldHAREKET_ALT_KATEGORI_ID.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 33;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 34;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_HESAP_CETVEL_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_HESAP_CETVEL_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_HESAP_CETVEL_YERI.AreaIndex = 35;
            fieldTO_HESAP_CETVEL_YERI.FieldName = "TO_HESAP_CETVEL_YERI";
            fieldTO_HESAP_CETVEL_YERI.Name = "fieldTO_HESAP_CETVEL_YERI";
            fieldTO_HESAP_CETVEL_YERI.Visible = false;

            PivotGridField fieldTS_HESAP_CETVEL_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_HESAP_CETVEL_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_HESAP_CETVEL_YERI.AreaIndex = 36;
            fieldTS_HESAP_CETVEL_YERI.FieldName = "TS_HESAP_CETVEL_YERI";
            fieldTS_HESAP_CETVEL_YERI.Name = "fieldTS_HESAP_CETVEL_YERI";
            fieldTS_HESAP_CETVEL_YERI.Visible = false;

            PivotGridField fieldDO_HESAP_CETVEL_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDO_HESAP_CETVEL_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDO_HESAP_CETVEL_YERI.AreaIndex = 37;
            fieldDO_HESAP_CETVEL_YERI.FieldName = "DO_HESAP_CETVEL_YERI";
            fieldDO_HESAP_CETVEL_YERI.Name = "fieldDO_HESAP_CETVEL_YERI";
            fieldDO_HESAP_CETVEL_YERI.Visible = false;

            PivotGridField fieldDS_HESAP_CETVEL_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDS_HESAP_CETVEL_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDS_HESAP_CETVEL_YERI.AreaIndex = 38;
            fieldDS_HESAP_CETVEL_YERI.FieldName = "DS_HESAP_CETVEL_YERI";
            fieldDS_HESAP_CETVEL_YERI.Name = "fieldDS_HESAP_CETVEL_YERI";
            fieldDS_HESAP_CETVEL_YERI.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 39;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_ADLIYE_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_ADLIYE_ID.AreaIndex = 40;
            fieldADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            fieldADLI_BIRIM_ADLIYE_ID.Name = "fieldADLI_BIRIM_ADLIYE_ID";
            fieldADLI_BIRIM_ADLIYE_ID.Visible = false;

            PivotGridField fieldADLI_BIRIM_NO_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_NO_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_NO_ID.AreaIndex = 41;
            fieldADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            fieldADLI_BIRIM_NO_ID.Name = "fieldADLI_BIRIM_NO_ID";
            fieldADLI_BIRIM_NO_ID.Visible = false;

            PivotGridField fieldADLI_BIRIM_GOREV_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_GOREV_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_GOREV_ID.AreaIndex = 42;
            fieldADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            fieldADLI_BIRIM_GOREV_ID.Name = "fieldADLI_BIRIM_GOREV_ID";
            fieldADLI_BIRIM_GOREV_ID.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 43;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldBIRIM_FIYAT,
			fieldKDV_DAHIL,
			fieldKDV_TUTAR,
			fieldSTOPAJ_SSDF_DAHIL,
			fieldSTOPAJ_ORAN,
			fieldKDV_ORAN,
			fieldSTOPAJ_SSDF_TUTAR,
			fieldSSDF_ORAN,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldGENEL_TOPLAM,
			fieldGENEL_TOPLAM_DOVIZ_ID,
			fieldTUM_MUVEKKILLERE_PAYLASTIR,
			fieldMUVEKKIL_CARI_ID,
			fieldINCELENDI,
			fieldONAY_TARIHI,
			fieldONAY_NO,
			fieldONAY_DURUM,
			fieldDETAY_ACIKLAMA,
			fieldCARI_ID,
			fieldREFERANS_NO,
			fieldMASRAF_AVANS_TIP,

            //fieldKAYIT_ID,
			fieldACIKLAMA,
			fieldBORCLU_CARI_ID,
			fieldALACAK_NEDEN_ID,
			fieldMODUL_ID,
			fieldTARIH,
			fieldKULLANICI_BELGE_NO,
			fieldBORC_ALACAK_ID,
			fieldODEME_TIP_ID,
			fieldHAREKET_ANA_KATEGORI_ID,
			fieldHAREKET_ALT_KATEGORI_ID,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,

            //fieldTO_HESAP_CETVEL_YERI,
            //fieldTS_HESAP_CETVEL_YERI,
            //fieldDO_HESAP_CETVEL_YERI,
            //fieldDS_HESAP_CETVEL_YERI,
			fieldFOY_NO,
			fieldADLI_BIRIM_ADLIYE_ID,
			fieldADLI_BIRIM_NO_ID,
			fieldADLI_BIRIM_GOREV_ID,
			fieldESAS_NO,
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

            dicFieldCaption.Add("BIRIM_FIYAT", "Birim Fiyat");
            dicFieldCaption.Add("KDV_DAHIL", "KDV Dahil");
            dicFieldCaption.Add("KDV_TUTAR", "KDV Tutar");
            dicFieldCaption.Add("STOPAJ_SSDF_DAHIL", "SSDF");
            dicFieldCaption.Add("STOPAJ_ORAN", "Stop Oran");
            dicFieldCaption.Add("KDV_ORAN", "KDV Oran");
            dicFieldCaption.Add("STOPAJ_SSDF_TUTAR", "SSDF Tutar");
            dicFieldCaption.Add("SSDF_ORAN", "SSDF Oran");
            dicFieldCaption.Add("TOPLAM_TUTAR", "Toplam");
            dicFieldCaption.Add("GENEL_TOPLAM", "G Toplam");
            dicFieldCaption.Add("TUM_MUVEKKILLERE_PAYLASTIR", "Müvekkillere Paylaþtýr");
            dicFieldCaption.Add("MUVEKKIL_CARI_ID", "Müvekkil");
            dicFieldCaption.Add("INCELENDI", "Ýncelendi");
            dicFieldCaption.Add("ONAY_TARIHI", "Onay T");
            dicFieldCaption.Add("ONAY_NO", "Onay No");
            dicFieldCaption.Add("ONAY_DURUM", "Onay Durum");
            dicFieldCaption.Add("DETAY_ACIKLAMA", "Detay Açýklama");
            dicFieldCaption.Add("CARI_ID", "Þahýs");
            dicFieldCaption.Add("REFERANS_NO", "Ref No");
            dicFieldCaption.Add("MASRAF_AVANS_TIP", "Masraf Avans Tip");
            dicFieldCaption.Add("KAYIT_ID", "");
            dicFieldCaption.Add("ACIKLAMA", "Açýklama");
            dicFieldCaption.Add("BORCLU_CARI_ID", "Borçlu");
            dicFieldCaption.Add("ALACAK_NEDEN_ID", "Alacak Neden");
            dicFieldCaption.Add("MODUL_ID", "Modül");
            dicFieldCaption.Add("TARIH", "Tarih");
            dicFieldCaption.Add("KULLANICI_BELGE_NO", "Kullanýcý Belge No");
            dicFieldCaption.Add("BORC_ALACAK_ID", "B/A");
            dicFieldCaption.Add("ODEME_TIP_ID", "Ödeme Tip");
            dicFieldCaption.Add("HAREKET_ANA_KATEGORI_ID", "Har Ana Kat");
            dicFieldCaption.Add("HAREKET_ALT_KATEGORI_ID", "Har Alt Kat");
            dicFieldCaption.Add("ADET", "Adet");
            dicFieldCaption.Add("TO_HESAP_CETVEL_YERI", "");
            dicFieldCaption.Add("TS_HESAP_CETVEL_YERI", "");
            dicFieldCaption.Add("DO_HESAP_CETVEL_YERI", "");
            dicFieldCaption.Add("DS_HESAP_CETVEL_YERI", "");
            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("ADLI_BIRIM_ADLIYE_ID", "Adliye");
            dicFieldCaption.Add("ADLI_BIRIM_NO_ID", "No");
            dicFieldCaption.Add("ADLI_BIRIM_GOREV_ID", "Görev");
            dicFieldCaption.Add("ESAS_NO", "Esas No");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

            RepositoryItem Item = new RepositoryItem();

            RepositoryItemLookUpEdit rlueCari = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueAlacakNeden = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueModul = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueBorcAlacak = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueOdeme = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueHAnaKat = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueHAltKat = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueAdliye = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueAdliNo = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueAdliGorev = new RepositoryItemLookUpEdit();

            Inits.DovizTipGetir(rlueDoviz);
            Inits.CariGetir(rlueCari);
            Inits.AlacakNEdenGetir(rlueAlacakNeden);

            //   Inits.ModulGetir(rlueModul);
            Inits.BorcAlacakGetir(rlueBorcAlacak);
            Inits.OdemeTipiGetir(rlueOdeme);
            Inits.MuhasebeHareketAltKategori(rlueHAltKat);
            Inits.HareketAnaKategoriGetir(rlueHAnaKat);
            Inits.AdliBirimAdliyeGetir(rlueAdliye);
            Inits.AdliBirimNoGetir(rlueAdliNo);
            Inits.AdliBirimGorevGetir(rlueAdliGorev);

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("DovizId", rlueDoviz);

            sozluk.Add("MUVEKKIL_CARI_ID", rlueCari);
            sozluk.Add("CARI_ID", rlueCari);

            //sozluk.Add("KAYIT_ID", rlueKayit);
            sozluk.Add("BORCLU_CARI_ID", rlueCari);
            sozluk.Add("ALACAK_NEDEN_ID", rlueAlacakNeden);
            sozluk.Add("MODUL_ID", rlueOdeme);
            sozluk.Add("BORC_ALACAK_ID", rlueBorcAlacak);
            sozluk.Add("ODEME_TIP_ID", rlueOdeme);
            sozluk.Add("HAREKET_ANA_KATEGORI_ID", rlueOdeme);
            sozluk.Add("HAREKET_ALT_KATEGORI_ID", rlueHAnaKat);
            sozluk.Add("ADLI_BIRIM_ADLIYE_ID", rlueAdliye);
            sozluk.Add("ADLI_BIRIM_NO_ID", rlueAdliNo);
            sozluk.Add("ADLI_BIRIM_GOREV_ID", rlueAdliGorev);

            #endregion Add item

            return sozluk;
        }

        #region IRaporSource Members

        private object myDataSource;

        public object ChartDataSource
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public object ListDataSource
        {
            get
            {
                return MyDataSource;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public object MyDataSource
        {
            get
            {
                if (myDataSource != null)
                {
                    return myDataSource;
                }
                else
                {
                    myDataSource = DataRepository.R_MASRAF_AVANS_DETAYLIProvider.GetAll();
                    return myDataSource;
                }
            }
        }

        public object PivotDataSource
        {
            get
            {
                return MyDataSource;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public void PrintChart()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void PrintListe()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void PrintPivot()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SaveChart()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SaveListe()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SavePivot()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion IRaporSource Members

        #region IRaporSource Members

        #endregion IRaporSource Members
    }
}