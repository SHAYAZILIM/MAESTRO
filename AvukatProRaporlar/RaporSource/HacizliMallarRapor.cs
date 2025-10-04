using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class HacizliMallarRapor
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

            GridColumn colHACIZ_SIRA_NO = new GridColumn();
            colHACIZ_SIRA_NO.VisibleIndex = 0;
            colHACIZ_SIRA_NO.FieldName = "HACIZ_SIRA_NO";
            colHACIZ_SIRA_NO.Name = "colHACIZ_SIRA_NO";
            colHACIZ_SIRA_NO.Visible = true;

            GridColumn colHACIZ_TALEP_TARIHI = new GridColumn();
            colHACIZ_TALEP_TARIHI.VisibleIndex = 1;
            colHACIZ_TALEP_TARIHI.FieldName = "HACIZ_TALEP_TARIHI";
            colHACIZ_TALEP_TARIHI.Name = "colHACIZ_TALEP_TARIHI";
            colHACIZ_TALEP_TARIHI.Visible = true;

            GridColumn colHACIZ_TARIHI = new GridColumn();
            colHACIZ_TARIHI.VisibleIndex = 2;
            colHACIZ_TARIHI.FieldName = "HACIZ_TARIHI";
            colHACIZ_TARIHI.Name = "colHACIZ_TARIHI";
            colHACIZ_TARIHI.Visible = true;

            GridColumn colALACAKLI = new GridColumn();
            colALACAKLI.VisibleIndex = 3;
            colALACAKLI.FieldName = "ALACAKLI";
            colALACAKLI.Name = "colALACAKLI";
            colALACAKLI.Visible = true;

            GridColumn colBORCLU = new GridColumn();
            colBORCLU.VisibleIndex = 4;
            colBORCLU.FieldName = "BORCLU";
            colBORCLU.Name = "colBORCLU";
            colBORCLU.Visible = true;

            GridColumn colHACIZ_MEMURU_ADI = new GridColumn();
            colHACIZ_MEMURU_ADI.VisibleIndex = 5;
            colHACIZ_MEMURU_ADI.FieldName = "HACIZ_MEMURU_ADI";
            colHACIZ_MEMURU_ADI.Name = "colHACIZ_MEMURU_ADI";
            colHACIZ_MEMURU_ADI.Visible = true;

            GridColumn colHACIZ_ACIKLAMA = new GridColumn();
            colHACIZ_ACIKLAMA.VisibleIndex = 6;
            colHACIZ_ACIKLAMA.FieldName = "HACIZ_ACIKLAMA";
            colHACIZ_ACIKLAMA.Name = "colHACIZ_ACIKLAMA";
            colHACIZ_ACIKLAMA.Visible = true;

            GridColumn colICRA_TUTANAK_NO = new GridColumn();
            colICRA_TUTANAK_NO.VisibleIndex = 7;
            colICRA_TUTANAK_NO.FieldName = "ICRA_TUTANAK_NO";
            colICRA_TUTANAK_NO.Name = "colICRA_TUTANAK_NO";
            colICRA_TUTANAK_NO.Visible = true;

            GridColumn colBORCLU_HAZIR_MI = new GridColumn();
            colBORCLU_HAZIR_MI.VisibleIndex = 8;
            colBORCLU_HAZIR_MI.FieldName = "BORCLU_HAZIR_MI";
            colBORCLU_HAZIR_MI.Name = "colBORCLU_HAZIR_MI";
            colBORCLU_HAZIR_MI.Visible = true;

            GridColumn colYUZUC_UYGULANDI_MI = new GridColumn();
            colYUZUC_UYGULANDI_MI.VisibleIndex = 9;
            colYUZUC_UYGULANDI_MI.FieldName = "YUZUC_UYGULANDI_MI";
            colYUZUC_UYGULANDI_MI.Name = "colYUZUC_UYGULANDI_MI";
            colYUZUC_UYGULANDI_MI.Visible = true;

            GridColumn colSURET_BIRAKILDI_MI = new GridColumn();
            colSURET_BIRAKILDI_MI.VisibleIndex = 10;
            colSURET_BIRAKILDI_MI.FieldName = "SURET_BIRAKILDI_MI";
            colSURET_BIRAKILDI_MI.Name = "colSURET_BIRAKILDI_MI";
            colSURET_BIRAKILDI_MI.Visible = true;

            GridColumn colBAKIYE_HACIZI_MI = new GridColumn();
            colBAKIYE_HACIZI_MI.VisibleIndex = 11;
            colBAKIYE_HACIZI_MI.FieldName = "BAKIYE_HACIZI_MI";
            colBAKIYE_HACIZI_MI.Name = "colBAKIYE_HACIZI_MI";
            colBAKIYE_HACIZI_MI.Visible = true;

            GridColumn colGECICI_HACIZ_MI = new GridColumn();
            colGECICI_HACIZ_MI.VisibleIndex = 12;
            colGECICI_HACIZ_MI.FieldName = "GECICI_HACIZ_MI";
            colGECICI_HACIZ_MI.Name = "colGECICI_HACIZ_MI";
            colGECICI_HACIZ_MI.Visible = true;

            GridColumn colKOLLUK_VAR_MI = new GridColumn();
            colKOLLUK_VAR_MI.VisibleIndex = 13;
            colKOLLUK_VAR_MI.FieldName = "KOLLUK_VAR_MI";
            colKOLLUK_VAR_MI.Name = "colKOLLUK_VAR_MI";
            colKOLLUK_VAR_MI.Visible = true;

            GridColumn colCILINGIR_VAR_MI = new GridColumn();
            colCILINGIR_VAR_MI.VisibleIndex = 14;
            colCILINGIR_VAR_MI.FieldName = "CILINGIR_VAR_MI";
            colCILINGIR_VAR_MI.Name = "colCILINGIR_VAR_MI";
            colCILINGIR_VAR_MI.Visible = true;

            GridColumn colSEHIR_DISI_MI = new GridColumn();
            colSEHIR_DISI_MI.VisibleIndex = 15;
            colSEHIR_DISI_MI.FieldName = "SEHIR_DISI_MI";
            colSEHIR_DISI_MI.Name = "colSEHIR_DISI_MI";
            colSEHIR_DISI_MI.Visible = true;

            GridColumn colTALIMAT_MI = new GridColumn();
            colTALIMAT_MI.VisibleIndex = 16;
            colTALIMAT_MI.FieldName = "TALIMAT_MI";
            colTALIMAT_MI.Name = "colTALIMAT_MI";
            colTALIMAT_MI.Visible = true;

            GridColumn colTALIMAT_ESAS_NO = new GridColumn();
            colTALIMAT_ESAS_NO.VisibleIndex = 17;
            colTALIMAT_ESAS_NO.FieldName = "TALIMAT_ESAS_NO";
            colTALIMAT_ESAS_NO.Name = "colTALIMAT_ESAS_NO";
            colTALIMAT_ESAS_NO.Visible = true;

            GridColumn colTALIMAT_ADLIYE = new GridColumn();
            colTALIMAT_ADLIYE.VisibleIndex = 18;
            colTALIMAT_ADLIYE.FieldName = "TALIMAT_ADLIYE";
            colTALIMAT_ADLIYE.Name = "colTALIMAT_ADLIYE";
            colTALIMAT_ADLIYE.Visible = true;

            GridColumn colTALIMAT_BIRIM_NO = new GridColumn();
            colTALIMAT_BIRIM_NO.VisibleIndex = 19;
            colTALIMAT_BIRIM_NO.FieldName = "TALIMAT_BIRIM_NO";
            colTALIMAT_BIRIM_NO.Name = "colTALIMAT_BIRIM_NO";
            colTALIMAT_BIRIM_NO.Visible = true;

            GridColumn colMAL_SIRA_NO = new GridColumn();
            colMAL_SIRA_NO.VisibleIndex = 20;
            colMAL_SIRA_NO.FieldName = "MAL_SIRA_NO";
            colMAL_SIRA_NO.Name = "colMAL_SIRA_NO";
            colMAL_SIRA_NO.Visible = true;

            GridColumn colMAL_TUR = new GridColumn();
            colMAL_TUR.VisibleIndex = 21;
            colMAL_TUR.FieldName = "MAL_TUR";
            colMAL_TUR.Name = "colMAL_TUR";
            colMAL_TUR.Visible = true;

            GridColumn colMAL_KATAGORI = new GridColumn();
            colMAL_KATAGORI.VisibleIndex = 22;
            colMAL_KATAGORI.FieldName = "MAL_KATAGORI";
            colMAL_KATAGORI.Name = "colMAL_KATAGORI";
            colMAL_KATAGORI.Visible = true;

            GridColumn colMAL_CINS = new GridColumn();
            colMAL_CINS.VisibleIndex = 23;
            colMAL_CINS.FieldName = "MAL_CINS";
            colMAL_CINS.Name = "colMAL_CINS";
            colMAL_CINS.Visible = true;

            GridColumn colHACIZLI_MAL_NEVI = new GridColumn();
            colHACIZLI_MAL_NEVI.VisibleIndex = 24;
            colHACIZLI_MAL_NEVI.FieldName = "HACIZLI_MAL_NEVI";
            colHACIZLI_MAL_NEVI.Name = "colHACIZLI_MAL_NEVI";
            colHACIZLI_MAL_NEVI.Visible = true;

            GridColumn colHACIZLI_MAL_MARKASI = new GridColumn();
            colHACIZLI_MAL_MARKASI.VisibleIndex = 25;
            colHACIZLI_MAL_MARKASI.FieldName = "HACIZLI_MAL_MARKASI";
            colHACIZLI_MAL_MARKASI.Name = "colHACIZLI_MAL_MARKASI";
            colHACIZLI_MAL_MARKASI.Visible = true;

            GridColumn colHACIZLI_MAL_ADEDI = new GridColumn();
            colHACIZLI_MAL_ADEDI.VisibleIndex = 26;
            colHACIZLI_MAL_ADEDI.FieldName = "HACIZLI_MAL_ADEDI";
            colHACIZLI_MAL_ADEDI.Name = "colHACIZLI_MAL_ADEDI";
            colHACIZLI_MAL_ADEDI.Visible = true;

            GridColumn colHACIZLI_MAL_BIRIM = new GridColumn();
            colHACIZLI_MAL_BIRIM.VisibleIndex = 27;
            colHACIZLI_MAL_BIRIM.FieldName = "HACIZLI_MAL_BIRIM";
            colHACIZLI_MAL_BIRIM.Name = "colHACIZLI_MAL_BIRIM";
            colHACIZLI_MAL_BIRIM.Visible = true;

            GridColumn colHACIZLI_MAL_DEGERI = new GridColumn();
            colHACIZLI_MAL_DEGERI.VisibleIndex = 28;
            colHACIZLI_MAL_DEGERI.FieldName = "HACIZLI_MAL_DEGERI";
            colHACIZLI_MAL_DEGERI.Name = "colHACIZLI_MAL_DEGERI";
            colHACIZLI_MAL_DEGERI.Visible = true;

            GridColumn colHACIZLI_MAL_DEGERI_DOVIZ_ID = new GridColumn();
            colHACIZLI_MAL_DEGERI_DOVIZ_ID.VisibleIndex = 29;
            colHACIZLI_MAL_DEGERI_DOVIZ_ID.FieldName = "HACIZLI_MAL_DEGERI_DOVIZ_ID";
            colHACIZLI_MAL_DEGERI_DOVIZ_ID.Name = "colHACIZLI_MAL_DEGERI_DOVIZ_ID";
            colHACIZLI_MAL_DEGERI_DOVIZ_ID.Visible = true;

            GridColumn colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR = new GridColumn();
            colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.VisibleIndex = 30;
            colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.FieldName = "HACIZLI_MAL_SATIR_TOPLAM_MIKTAR";
            colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.Name = "colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR";
            colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.Visible = true;

            GridColumn colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID = new GridColumn();
            colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.VisibleIndex = 31;
            colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.FieldName = "HACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID";
            colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.Name = "colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID";
            colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.Visible = true;

            GridColumn colHACIZLI_MAL_OZELLIKLERI = new GridColumn();
            colHACIZLI_MAL_OZELLIKLERI.VisibleIndex = 32;
            colHACIZLI_MAL_OZELLIKLERI.FieldName = "HACIZLI_MAL_OZELLIKLERI";
            colHACIZLI_MAL_OZELLIKLERI.Name = "colHACIZLI_MAL_OZELLIKLERI";
            colHACIZLI_MAL_OZELLIKLERI.Visible = true;

            GridColumn colARAC_PLAKA_NO = new GridColumn();
            colARAC_PLAKA_NO.VisibleIndex = 33;
            colARAC_PLAKA_NO.FieldName = "ARAC_PLAKA_NO";
            colARAC_PLAKA_NO.Name = "colARAC_PLAKA_NO";
            colARAC_PLAKA_NO.Visible = true;

            GridColumn colHACIZLI_MAL_ACIKLAMASI = new GridColumn();
            colHACIZLI_MAL_ACIKLAMASI.VisibleIndex = 34;
            colHACIZLI_MAL_ACIKLAMASI.FieldName = "HACIZLI_MAL_ACIKLAMASI";
            colHACIZLI_MAL_ACIKLAMASI.Name = "colHACIZLI_MAL_ACIKLAMASI";
            colHACIZLI_MAL_ACIKLAMASI.Visible = true;

            GridColumn colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI = new GridColumn();
            colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.VisibleIndex = 35;
            colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.FieldName = "HACZEDILEMEZLIKTEN_FERAGAT_VAR_MI";
            colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.Name = "colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI";
            colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.Visible = true;

            GridColumn colUCUNCU_SAHISTA_MI = new GridColumn();
            colUCUNCU_SAHISTA_MI.VisibleIndex = 36;
            colUCUNCU_SAHISTA_MI.FieldName = "UCUNCU_SAHISTA_MI";
            colUCUNCU_SAHISTA_MI.Name = "colUCUNCU_SAHISTA_MI";
            colUCUNCU_SAHISTA_MI.Visible = true;

            GridColumn colUCUNCU_SAHIS_ADI = new GridColumn();
            colUCUNCU_SAHIS_ADI.VisibleIndex = 37;
            colUCUNCU_SAHIS_ADI.FieldName = "UCUNCU_SAHIS_ADI";
            colUCUNCU_SAHIS_ADI.Name = "colUCUNCU_SAHIS_ADI";
            colUCUNCU_SAHIS_ADI.Visible = true;

            GridColumn colHACIZ_ISLEM_DURUM = new GridColumn();
            colHACIZ_ISLEM_DURUM.VisibleIndex = 38;
            colHACIZ_ISLEM_DURUM.FieldName = "HACIZ_ISLEM_DURUM";
            colHACIZ_ISLEM_DURUM.Name = "colHACIZ_ISLEM_DURUM";
            colHACIZ_ISLEM_DURUM.Visible = true;

            GridColumn colISTIHKAK_IDDIASI_VAR_MI = new GridColumn();
            colISTIHKAK_IDDIASI_VAR_MI.VisibleIndex = 39;
            colISTIHKAK_IDDIASI_VAR_MI.FieldName = "ISTIHKAK_IDDIASI_VAR_MI";
            colISTIHKAK_IDDIASI_VAR_MI.Name = "colISTIHKAK_IDDIASI_VAR_MI";
            colISTIHKAK_IDDIASI_VAR_MI.Visible = true;

            GridColumn colPARAYA_CEVRILDI_MI = new GridColumn();
            colPARAYA_CEVRILDI_MI.VisibleIndex = 40;
            colPARAYA_CEVRILDI_MI.FieldName = "PARAYA_CEVRILDI_MI";
            colPARAYA_CEVRILDI_MI.Name = "colPARAYA_CEVRILDI_MI";
            colPARAYA_CEVRILDI_MI.Visible = true;

            GridColumn colALACAKLI_RIZASI_VAR_MI = new GridColumn();
            colALACAKLI_RIZASI_VAR_MI.VisibleIndex = 41;
            colALACAKLI_RIZASI_VAR_MI.FieldName = "ALACAKLI_RIZASI_VAR_MI";
            colALACAKLI_RIZASI_VAR_MI.Name = "colALACAKLI_RIZASI_VAR_MI";
            colALACAKLI_RIZASI_VAR_MI.Visible = true;

            GridColumn colYEDDIEMIN_CARI = new GridColumn();
            colYEDDIEMIN_CARI.VisibleIndex = 42;
            colYEDDIEMIN_CARI.FieldName = "YEDDIEMIN_CARI";
            colYEDDIEMIN_CARI.Name = "colYEDDIEMIN_CARI";
            colYEDDIEMIN_CARI.Visible = true;

            GridColumn colHACIZ_SORUMLUSU = new GridColumn();
            colHACIZ_SORUMLUSU.VisibleIndex = 43;
            colHACIZ_SORUMLUSU.FieldName = "HACIZ_SORUMLUSU";
            colHACIZ_SORUMLUSU.Name = "colHACIZ_SORUMLUSU";
            colHACIZ_SORUMLUSU.Visible = true;

            GridColumn colICRA_FOY_ID = new GridColumn();
            colICRA_FOY_ID.VisibleIndex = 44;
            colICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            colICRA_FOY_ID.Name = "colICRA_FOY_ID";
            colICRA_FOY_ID.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 45;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 46;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colBOLGE = new GridColumn();
            colBOLGE.VisibleIndex = 47;
            colBOLGE.FieldName = "BOLGE";
            colBOLGE.Name = "colBOLGE";
            colBOLGE.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 48;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 49;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 50;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 51;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colTAHSILAT_DURUM = new GridColumn();
            colTAHSILAT_DURUM.VisibleIndex = 52;
            colTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            colTAHSILAT_DURUM.Name = "colTAHSILAT_DURUM";
            colTAHSILAT_DURUM.Visible = true;

            GridColumn colFOY_YERI = new GridColumn();
            colFOY_YERI.VisibleIndex = 53;
            colFOY_YERI.FieldName = "FOY_YERI";
            colFOY_YERI.Name = "colFOY_YERI";
            colFOY_YERI.Visible = true;

            GridColumn colFOY_BIRIM = new GridColumn();
            colFOY_BIRIM.VisibleIndex = 54;
            colFOY_BIRIM.FieldName = "FOY_BIRIM";
            colFOY_BIRIM.Name = "colFOY_BIRIM";
            colFOY_BIRIM.Visible = true;

            GridColumn colBANKA_SUBE = new GridColumn();
            colBANKA_SUBE.VisibleIndex = 55;
            colBANKA_SUBE.FieldName = "BANKA_SUBE";
            colBANKA_SUBE.Name = "colBANKA_SUBE";
            colBANKA_SUBE.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 56;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colFOY_OZEL_DURUM = new GridColumn();
            colFOY_OZEL_DURUM.VisibleIndex = 57;
            colFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Name = "colFOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Visible = true;

            GridColumn colICRA_ADLIYE = new GridColumn();
            colICRA_ADLIYE.VisibleIndex = 58;
            colICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            colICRA_ADLIYE.Name = "colICRA_ADLIYE";
            colICRA_ADLIYE.Visible = true;

            GridColumn colICRA_BIRIM_NO = new GridColumn();
            colICRA_BIRIM_NO.VisibleIndex = 59;
            colICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Name = "colICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 60;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 61;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colHACIZ_SIRA_NO,
			colHACIZ_TALEP_TARIHI,
			colHACIZ_TARIHI,
			colALACAKLI,
			colBORCLU,
			colHACIZ_MEMURU_ADI,
			colHACIZ_ACIKLAMA,
			colICRA_TUTANAK_NO,
			colBORCLU_HAZIR_MI,
			colYUZUC_UYGULANDI_MI,
			colSURET_BIRAKILDI_MI,
			colBAKIYE_HACIZI_MI,
			colGECICI_HACIZ_MI,
			colKOLLUK_VAR_MI,
			colCILINGIR_VAR_MI,
			colSEHIR_DISI_MI,
			colTALIMAT_MI,
			colTALIMAT_ESAS_NO,
			colTALIMAT_ADLIYE,
			colTALIMAT_BIRIM_NO,
			colMAL_SIRA_NO,
			colMAL_TUR,
			colMAL_KATAGORI,
			colMAL_CINS,
			colHACIZLI_MAL_NEVI,
			colHACIZLI_MAL_MARKASI,
			colHACIZLI_MAL_ADEDI,
			colHACIZLI_MAL_BIRIM,
			colHACIZLI_MAL_DEGERI,
			colHACIZLI_MAL_DEGERI_DOVIZ_ID,
			colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR,
			colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID,
			colHACIZLI_MAL_OZELLIKLERI,
			colARAC_PLAKA_NO,
			colHACIZLI_MAL_ACIKLAMASI,
			colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI,
			colUCUNCU_SAHISTA_MI,
			colUCUNCU_SAHIS_ADI,
			colHACIZ_ISLEM_DURUM,
			colISTIHKAK_IDDIASI_VAR_MI,
			colPARAYA_CEVRILDI_MI,
			colALACAKLI_RIZASI_VAR_MI,
			colYEDDIEMIN_CARI,
			colHACIZ_SORUMLUSU,
			colICRA_FOY_ID,
			colESAS_NO,
			colTAKIP_TARIHI,
			colBOLGE,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
			colKREDI_TIP,
			colKREDI_GRUP,
			colTAHSILAT_DURUM,
			colFOY_YERI,
			colFOY_BIRIM,
			colBANKA_SUBE,
			colBANKA,
			colFOY_OZEL_DURUM,
			colICRA_ADLIYE,
			colICRA_BIRIM_NO,
			colBOLUM,
			colID,
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
            PivotGridField[] dizi = null;

            #region Field & Properties

            PivotGridField fieldHACIZ_SIRA_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_SIRA_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZ_SIRA_NO.AreaIndex = 0;
            fieldHACIZ_SIRA_NO.FieldName = "HACIZ_SIRA_NO";
            fieldHACIZ_SIRA_NO.Name = "fieldHACIZ_SIRA_NO";
            fieldHACIZ_SIRA_NO.Visible = false;

            PivotGridField fieldHACIZ_TALEP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_TALEP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZ_TALEP_TARIHI.AreaIndex = 1;
            fieldHACIZ_TALEP_TARIHI.FieldName = "HACIZ_TALEP_TARIHI";
            fieldHACIZ_TALEP_TARIHI.Name = "fieldHACIZ_TALEP_TARIHI";
            fieldHACIZ_TALEP_TARIHI.Visible = false;

            PivotGridField fieldHACIZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZ_TARIHI.AreaIndex = 2;
            fieldHACIZ_TARIHI.FieldName = "HACIZ_TARIHI";
            fieldHACIZ_TARIHI.Name = "fieldHACIZ_TARIHI";
            fieldHACIZ_TARIHI.Visible = false;

            PivotGridField fieldALACAKLI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAKLI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAKLI.AreaIndex = 3;
            fieldALACAKLI.FieldName = "ALACAKLI";
            fieldALACAKLI.Name = "fieldALACAKLI";
            fieldALACAKLI.Visible = false;

            PivotGridField fieldBORCLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORCLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORCLU.AreaIndex = 4;
            fieldBORCLU.FieldName = "BORCLU";
            fieldBORCLU.Name = "fieldBORCLU";
            fieldBORCLU.Visible = false;

            PivotGridField fieldHACIZ_MEMURU_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_MEMURU_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZ_MEMURU_ADI.AreaIndex = 5;
            fieldHACIZ_MEMURU_ADI.FieldName = "HACIZ_MEMURU_ADI";
            fieldHACIZ_MEMURU_ADI.Name = "fieldHACIZ_MEMURU_ADI";
            fieldHACIZ_MEMURU_ADI.Visible = false;

            PivotGridField fieldHACIZ_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZ_ACIKLAMA.AreaIndex = 6;
            fieldHACIZ_ACIKLAMA.FieldName = "HACIZ_ACIKLAMA";
            fieldHACIZ_ACIKLAMA.Name = "fieldHACIZ_ACIKLAMA";
            fieldHACIZ_ACIKLAMA.Visible = false;

            PivotGridField fieldICRA_TUTANAK_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_TUTANAK_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_TUTANAK_NO.AreaIndex = 7;
            fieldICRA_TUTANAK_NO.FieldName = "ICRA_TUTANAK_NO";
            fieldICRA_TUTANAK_NO.Name = "fieldICRA_TUTANAK_NO";
            fieldICRA_TUTANAK_NO.Visible = false;

            PivotGridField fieldBORCLU_HAZIR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORCLU_HAZIR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORCLU_HAZIR_MI.AreaIndex = 8;
            fieldBORCLU_HAZIR_MI.FieldName = "BORCLU_HAZIR_MI";
            fieldBORCLU_HAZIR_MI.Name = "fieldBORCLU_HAZIR_MI";
            fieldBORCLU_HAZIR_MI.Visible = false;

            PivotGridField fieldYUZUC_UYGULANDI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYUZUC_UYGULANDI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldYUZUC_UYGULANDI_MI.AreaIndex = 9;
            fieldYUZUC_UYGULANDI_MI.FieldName = "YUZUC_UYGULANDI_MI";
            fieldYUZUC_UYGULANDI_MI.Name = "fieldYUZUC_UYGULANDI_MI";
            fieldYUZUC_UYGULANDI_MI.Visible = false;

            PivotGridField fieldSURET_BIRAKILDI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSURET_BIRAKILDI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSURET_BIRAKILDI_MI.AreaIndex = 10;
            fieldSURET_BIRAKILDI_MI.FieldName = "SURET_BIRAKILDI_MI";
            fieldSURET_BIRAKILDI_MI.Name = "fieldSURET_BIRAKILDI_MI";
            fieldSURET_BIRAKILDI_MI.Visible = false;

            PivotGridField fieldBAKIYE_HACIZI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBAKIYE_HACIZI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBAKIYE_HACIZI_MI.AreaIndex = 11;
            fieldBAKIYE_HACIZI_MI.FieldName = "BAKIYE_HACIZI_MI";
            fieldBAKIYE_HACIZI_MI.Name = "fieldBAKIYE_HACIZI_MI";
            fieldBAKIYE_HACIZI_MI.Visible = false;

            PivotGridField fieldGECICI_HACIZ_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGECICI_HACIZ_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGECICI_HACIZ_MI.AreaIndex = 12;
            fieldGECICI_HACIZ_MI.FieldName = "GECICI_HACIZ_MI";
            fieldGECICI_HACIZ_MI.Name = "fieldGECICI_HACIZ_MI";
            fieldGECICI_HACIZ_MI.Visible = false;

            PivotGridField fieldKOLLUK_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKOLLUK_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKOLLUK_VAR_MI.AreaIndex = 13;
            fieldKOLLUK_VAR_MI.FieldName = "KOLLUK_VAR_MI";
            fieldKOLLUK_VAR_MI.Name = "fieldKOLLUK_VAR_MI";
            fieldKOLLUK_VAR_MI.Visible = false;

            PivotGridField fieldCILINGIR_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCILINGIR_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCILINGIR_VAR_MI.AreaIndex = 14;
            fieldCILINGIR_VAR_MI.FieldName = "CILINGIR_VAR_MI";
            fieldCILINGIR_VAR_MI.Name = "fieldCILINGIR_VAR_MI";
            fieldCILINGIR_VAR_MI.Visible = false;

            PivotGridField fieldSEHIR_DISI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSEHIR_DISI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSEHIR_DISI_MI.AreaIndex = 15;
            fieldSEHIR_DISI_MI.FieldName = "SEHIR_DISI_MI";
            fieldSEHIR_DISI_MI.Name = "fieldSEHIR_DISI_MI";
            fieldSEHIR_DISI_MI.Visible = false;

            PivotGridField fieldTALIMAT_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALIMAT_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALIMAT_MI.AreaIndex = 16;
            fieldTALIMAT_MI.FieldName = "TALIMAT_MI";
            fieldTALIMAT_MI.Name = "fieldTALIMAT_MI";
            fieldTALIMAT_MI.Visible = false;

            PivotGridField fieldTALIMAT_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALIMAT_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALIMAT_ESAS_NO.AreaIndex = 17;
            fieldTALIMAT_ESAS_NO.FieldName = "TALIMAT_ESAS_NO";
            fieldTALIMAT_ESAS_NO.Name = "fieldTALIMAT_ESAS_NO";
            fieldTALIMAT_ESAS_NO.Visible = false;

            PivotGridField fieldTALIMAT_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALIMAT_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALIMAT_ADLIYE.AreaIndex = 18;
            fieldTALIMAT_ADLIYE.FieldName = "TALIMAT_ADLIYE";
            fieldTALIMAT_ADLIYE.Name = "fieldTALIMAT_ADLIYE";
            fieldTALIMAT_ADLIYE.Visible = false;

            PivotGridField fieldTALIMAT_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALIMAT_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALIMAT_BIRIM_NO.AreaIndex = 19;
            fieldTALIMAT_BIRIM_NO.FieldName = "TALIMAT_BIRIM_NO";
            fieldTALIMAT_BIRIM_NO.Name = "fieldTALIMAT_BIRIM_NO";
            fieldTALIMAT_BIRIM_NO.Visible = false;

            PivotGridField fieldMAL_SIRA_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAL_SIRA_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAL_SIRA_NO.AreaIndex = 20;
            fieldMAL_SIRA_NO.FieldName = "MAL_SIRA_NO";
            fieldMAL_SIRA_NO.Name = "fieldMAL_SIRA_NO";
            fieldMAL_SIRA_NO.Visible = false;

            PivotGridField fieldMAL_TUR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAL_TUR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAL_TUR.AreaIndex = 21;
            fieldMAL_TUR.FieldName = "MAL_TUR";
            fieldMAL_TUR.Name = "fieldMAL_TUR";
            fieldMAL_TUR.Visible = false;

            PivotGridField fieldMAL_KATAGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAL_KATAGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAL_KATAGORI.AreaIndex = 22;
            fieldMAL_KATAGORI.FieldName = "MAL_KATAGORI";
            fieldMAL_KATAGORI.Name = "fieldMAL_KATAGORI";
            fieldMAL_KATAGORI.Visible = false;

            PivotGridField fieldMAL_CINS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAL_CINS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAL_CINS.AreaIndex = 23;
            fieldMAL_CINS.FieldName = "MAL_CINS";
            fieldMAL_CINS.Name = "fieldMAL_CINS";
            fieldMAL_CINS.Visible = false;

            PivotGridField fieldHACIZLI_MAL_NEVI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_NEVI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_NEVI.AreaIndex = 24;
            fieldHACIZLI_MAL_NEVI.FieldName = "HACIZLI_MAL_NEVI";
            fieldHACIZLI_MAL_NEVI.Name = "fieldHACIZLI_MAL_NEVI";
            fieldHACIZLI_MAL_NEVI.Visible = false;

            PivotGridField fieldHACIZLI_MAL_MARKASI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_MARKASI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_MARKASI.AreaIndex = 25;
            fieldHACIZLI_MAL_MARKASI.FieldName = "HACIZLI_MAL_MARKASI";
            fieldHACIZLI_MAL_MARKASI.Name = "fieldHACIZLI_MAL_MARKASI";
            fieldHACIZLI_MAL_MARKASI.Visible = false;

            PivotGridField fieldHACIZLI_MAL_ADEDI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_ADEDI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_ADEDI.AreaIndex = 26;
            fieldHACIZLI_MAL_ADEDI.FieldName = "HACIZLI_MAL_ADEDI";
            fieldHACIZLI_MAL_ADEDI.Name = "fieldHACIZLI_MAL_ADEDI";
            fieldHACIZLI_MAL_ADEDI.Visible = false;

            PivotGridField fieldHACIZLI_MAL_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_BIRIM.AreaIndex = 27;
            fieldHACIZLI_MAL_BIRIM.FieldName = "HACIZLI_MAL_BIRIM";
            fieldHACIZLI_MAL_BIRIM.Name = "fieldHACIZLI_MAL_BIRIM";
            fieldHACIZLI_MAL_BIRIM.Visible = false;

            PivotGridField fieldHACIZLI_MAL_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_DEGERI.AreaIndex = 28;
            fieldHACIZLI_MAL_DEGERI.FieldName = "HACIZLI_MAL_DEGERI";
            fieldHACIZLI_MAL_DEGERI.Name = "fieldHACIZLI_MAL_DEGERI";
            fieldHACIZLI_MAL_DEGERI.Visible = false;

            PivotGridField fieldHACIZLI_MAL_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_DEGERI_DOVIZ_ID.AreaIndex = 29;
            fieldHACIZLI_MAL_DEGERI_DOVIZ_ID.FieldName = "HACIZLI_MAL_DEGERI_DOVIZ_ID";
            fieldHACIZLI_MAL_DEGERI_DOVIZ_ID.Name = "fieldHACIZLI_MAL_DEGERI_DOVIZ_ID";
            fieldHACIZLI_MAL_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.AreaIndex = 30;
            fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.FieldName = "HACIZLI_MAL_SATIR_TOPLAM_MIKTAR";
            fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.Name = "fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR";
            fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.Visible = false;

            PivotGridField fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.AreaIndex = 31;
            fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.FieldName = "HACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID";
            fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.Name = "fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID";
            fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.Visible = false;

            PivotGridField fieldHACIZLI_MAL_OZELLIKLERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_OZELLIKLERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_OZELLIKLERI.AreaIndex = 32;
            fieldHACIZLI_MAL_OZELLIKLERI.FieldName = "HACIZLI_MAL_OZELLIKLERI";
            fieldHACIZLI_MAL_OZELLIKLERI.Name = "fieldHACIZLI_MAL_OZELLIKLERI";
            fieldHACIZLI_MAL_OZELLIKLERI.Visible = false;

            PivotGridField fieldARAC_PLAKA_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldARAC_PLAKA_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldARAC_PLAKA_NO.AreaIndex = 33;
            fieldARAC_PLAKA_NO.FieldName = "ARAC_PLAKA_NO";
            fieldARAC_PLAKA_NO.Name = "fieldARAC_PLAKA_NO";
            fieldARAC_PLAKA_NO.Visible = false;

            PivotGridField fieldHACIZLI_MAL_ACIKLAMASI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_ACIKLAMASI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_ACIKLAMASI.AreaIndex = 34;
            fieldHACIZLI_MAL_ACIKLAMASI.FieldName = "HACIZLI_MAL_ACIKLAMASI";
            fieldHACIZLI_MAL_ACIKLAMASI.Name = "fieldHACIZLI_MAL_ACIKLAMASI";
            fieldHACIZLI_MAL_ACIKLAMASI.Visible = false;

            PivotGridField fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.AreaIndex = 35;
            fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.FieldName = "HACZEDILEMEZLIKTEN_FERAGAT_VAR_MI";
            fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.Name = "fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI";
            fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.Visible = false;

            PivotGridField fieldUCUNCU_SAHISTA_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldUCUNCU_SAHISTA_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldUCUNCU_SAHISTA_MI.AreaIndex = 36;
            fieldUCUNCU_SAHISTA_MI.FieldName = "UCUNCU_SAHISTA_MI";
            fieldUCUNCU_SAHISTA_MI.Name = "fieldUCUNCU_SAHISTA_MI";
            fieldUCUNCU_SAHISTA_MI.Visible = false;

            PivotGridField fieldUCUNCU_SAHIS_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldUCUNCU_SAHIS_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldUCUNCU_SAHIS_ADI.AreaIndex = 37;
            fieldUCUNCU_SAHIS_ADI.FieldName = "UCUNCU_SAHIS_ADI";
            fieldUCUNCU_SAHIS_ADI.Name = "fieldUCUNCU_SAHIS_ADI";
            fieldUCUNCU_SAHIS_ADI.Visible = false;

            PivotGridField fieldHACIZ_ISLEM_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_ISLEM_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZ_ISLEM_DURUM.AreaIndex = 38;
            fieldHACIZ_ISLEM_DURUM.FieldName = "HACIZ_ISLEM_DURUM";
            fieldHACIZ_ISLEM_DURUM.Name = "fieldHACIZ_ISLEM_DURUM";
            fieldHACIZ_ISLEM_DURUM.Visible = false;

            PivotGridField fieldISTIHKAK_IDDIASI_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIHKAK_IDDIASI_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIHKAK_IDDIASI_VAR_MI.AreaIndex = 39;
            fieldISTIHKAK_IDDIASI_VAR_MI.FieldName = "ISTIHKAK_IDDIASI_VAR_MI";
            fieldISTIHKAK_IDDIASI_VAR_MI.Name = "fieldISTIHKAK_IDDIASI_VAR_MI";
            fieldISTIHKAK_IDDIASI_VAR_MI.Visible = false;

            PivotGridField fieldPARAYA_CEVRILDI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPARAYA_CEVRILDI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPARAYA_CEVRILDI_MI.AreaIndex = 40;
            fieldPARAYA_CEVRILDI_MI.FieldName = "PARAYA_CEVRILDI_MI";
            fieldPARAYA_CEVRILDI_MI.Name = "fieldPARAYA_CEVRILDI_MI";
            fieldPARAYA_CEVRILDI_MI.Visible = false;

            PivotGridField fieldALACAKLI_RIZASI_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAKLI_RIZASI_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAKLI_RIZASI_VAR_MI.AreaIndex = 41;
            fieldALACAKLI_RIZASI_VAR_MI.FieldName = "ALACAKLI_RIZASI_VAR_MI";
            fieldALACAKLI_RIZASI_VAR_MI.Name = "fieldALACAKLI_RIZASI_VAR_MI";
            fieldALACAKLI_RIZASI_VAR_MI.Visible = false;

            PivotGridField fieldYEDDIEMIN_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYEDDIEMIN_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldYEDDIEMIN_CARI.AreaIndex = 42;
            fieldYEDDIEMIN_CARI.FieldName = "YEDDIEMIN_CARI";
            fieldYEDDIEMIN_CARI.Name = "fieldYEDDIEMIN_CARI";
            fieldYEDDIEMIN_CARI.Visible = false;

            PivotGridField fieldHACIZ_SORUMLUSU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_SORUMLUSU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZ_SORUMLUSU.AreaIndex = 43;
            fieldHACIZ_SORUMLUSU.FieldName = "HACIZ_SORUMLUSU";
            fieldHACIZ_SORUMLUSU.Name = "fieldHACIZ_SORUMLUSU";
            fieldHACIZ_SORUMLUSU.Visible = false;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_FOY_ID.AreaIndex = 44;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 45;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 46;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 47;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 48;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 49;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 50;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 51;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 52;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 53;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 54;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 55;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 56;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 57;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 58;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 59;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 60;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 61;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            #endregion Field & Properties

            switch (pencere)
            {
                case "Haciz Sayısı (Bürolara Göre)":
                    dizi = HacizSayisiBurolaraGore();
                    break;
            }

            #region []

            if (dizi == null)
            {
                dizi = new PivotGridField[]
		{
			fieldHACIZ_SIRA_NO,
			fieldHACIZ_TALEP_TARIHI,
			fieldHACIZ_TARIHI,
			fieldALACAKLI,
			fieldBORCLU,
			fieldHACIZ_MEMURU_ADI,
			fieldHACIZ_ACIKLAMA,
			fieldICRA_TUTANAK_NO,
			fieldBORCLU_HAZIR_MI,
			fieldYUZUC_UYGULANDI_MI,
			fieldSURET_BIRAKILDI_MI,
			fieldBAKIYE_HACIZI_MI,
			fieldGECICI_HACIZ_MI,
			fieldKOLLUK_VAR_MI,
			fieldCILINGIR_VAR_MI,
			fieldSEHIR_DISI_MI,
			fieldTALIMAT_MI,
			fieldTALIMAT_ESAS_NO,
			fieldTALIMAT_ADLIYE,
			fieldTALIMAT_BIRIM_NO,
			fieldMAL_SIRA_NO,
			fieldMAL_TUR,
			fieldMAL_KATAGORI,
			fieldMAL_CINS,
			fieldHACIZLI_MAL_NEVI,
			fieldHACIZLI_MAL_MARKASI,
			fieldHACIZLI_MAL_ADEDI,
			fieldHACIZLI_MAL_BIRIM,
			fieldHACIZLI_MAL_DEGERI,
			fieldHACIZLI_MAL_DEGERI_DOVIZ_ID,
			fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR,
			fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID,
			fieldHACIZLI_MAL_OZELLIKLERI,
			fieldARAC_PLAKA_NO,
			fieldHACIZLI_MAL_ACIKLAMASI,
			fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI,
			fieldUCUNCU_SAHISTA_MI,
			fieldUCUNCU_SAHIS_ADI,
			fieldHACIZ_ISLEM_DURUM,
			fieldISTIHKAK_IDDIASI_VAR_MI,
			fieldPARAYA_CEVRILDI_MI,
			fieldALACAKLI_RIZASI_VAR_MI,
			fieldYEDDIEMIN_CARI,
			fieldHACIZ_SORUMLUSU,
			fieldICRA_FOY_ID,
			fieldESAS_NO,
			fieldTAKIP_TARIHI,
			fieldBOLGE,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldKREDI_TIP,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldFOY_YERI,
			fieldFOY_BIRIM,
			fieldBANKA_SUBE,
			fieldBANKA,
			fieldFOY_OZEL_DURUM,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
            fieldBOLUM,
			fieldID,
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

            dicFieldCaption.Add("HACIZ_SIRA_NO", "Haciz Sıra No");
            dicFieldCaption.Add("HACIZ_TALEP_TARIHI", "Haciz Talep T.");
            dicFieldCaption.Add("HACIZ_TARIHI", "Haciz T.");
            dicFieldCaption.Add("ALACAKLI", "Alacaklı");
            dicFieldCaption.Add("BORCLU", "Borclu");
            dicFieldCaption.Add("HACIZ_MEMURU_ADI", "Haciz Memuru");
            dicFieldCaption.Add("HACIZ_ACIKLAMA", "Haciz Açıklama");
            dicFieldCaption.Add("ICRA_TUTANAK_NO", "Tutanak No");
            dicFieldCaption.Add("BORCLU_HAZIR_MI", "Borçlu Hazır");
            dicFieldCaption.Add("YUZUC_UYGULANDI_MI", "Yüzüç Uygulandı");
            dicFieldCaption.Add("SURET_BIRAKILDI_MI", "Suret Bırakıldı");
            dicFieldCaption.Add("BAKIYE_HACIZI_MI", "Bakiye Haciz");
            dicFieldCaption.Add("GECICI_HACIZ_MI", "Geçici Haciz");
            dicFieldCaption.Add("KOLLUK_VAR_MI", "Kolluk Var");
            dicFieldCaption.Add("CILINGIR_VAR_MI", "Çilingir Var");
            dicFieldCaption.Add("SEHIR_DISI_MI", "Şehir Dışı");
            dicFieldCaption.Add("TALIMAT_MI", "Talimat");
            dicFieldCaption.Add("TALIMAT_ESAS_NO", "Talimat Esas No");
            dicFieldCaption.Add("TALIMAT_ADLIYE", "Talimat Adliye");
            dicFieldCaption.Add("TALIMAT_BIRIM_NO", "Talimat Birim No");
            dicFieldCaption.Add("MAL_SIRA_NO", "Mal Sıra No");
            dicFieldCaption.Add("MAL_TUR", "Mal Tür");
            dicFieldCaption.Add("MAL_KATAGORI", "Mal Katagori");
            dicFieldCaption.Add("MAL_CINS", "Mal Cins");
            dicFieldCaption.Add("HACIZLI_MAL_NEVI", "Mal Nevi");
            dicFieldCaption.Add("HACIZLI_MAL_MARKASI", "Mal Marka");
            dicFieldCaption.Add("HACIZLI_MAL_ADEDI", "Mal Adedi");
            dicFieldCaption.Add("HACIZLI_MAL_BIRIM", "Mal Birim");
            dicFieldCaption.Add("HACIZLI_MAL_DEGERI", "Mal Değeri");
            dicFieldCaption.Add("HACIZLI_MAL_SATIR_TOPLAM_MIKTAR", "Mal Satır Toplam Miktarı");
            dicFieldCaption.Add("HACIZLI_MAL_OZELLIKLERI", "Mal Özellikleri");
            dicFieldCaption.Add("ARAC_PLAKA_NO", "Araç Plaka No");
            dicFieldCaption.Add("HACIZLI_MAL_ACIKLAMASI", "Mal Açıklama");
            dicFieldCaption.Add("HACZEDILEMEZLIKTEN_FERAGAT_VAR_MI", "Haczadilemezlikten Feragat Var");
            dicFieldCaption.Add("UCUNCU_SAHISTA_MI", "Üçüncü Şahışta");
            dicFieldCaption.Add("UCUNCU_SAHIS_ADI", "Üçüncü Şahış");
            dicFieldCaption.Add("HACIZ_ISLEM_DURUM", "Haciz İşlem Durum");
            dicFieldCaption.Add("ISTIHKAK_IDDIASI_VAR_MI", "İstihkak İddiası Var");
            dicFieldCaption.Add("PARAYA_CEVRILDI_MI", "Paraya Çevrildi");
            dicFieldCaption.Add("ALACAKLI_RIZASI_VAR_MI", "Alacaklı Rızası Var");
            dicFieldCaption.Add("YEDDIEMIN_CARI", "Yeddiemin");
            dicFieldCaption.Add("HACIZ_SORUMLUSU", "Haciz Sorumlusu");
            dicFieldCaption.Add("ICRA_FOY_ID", "");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("TAKIP_TARIHI", "Takip T.");
            dicFieldCaption.Add("BOLGE", "Bölge");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KREDI_TIP", "Kredi Tip");
            dicFieldCaption.Add("KREDI_GRUP", "Kredi Grup");
            dicFieldCaption.Add("TAHSILAT_DURUM", "Tahsilat Durum");
            dicFieldCaption.Add("FOY_YERI", "Foy Yeri");
            dicFieldCaption.Add("FOY_BIRIM", "Foy ");
            dicFieldCaption.Add("BANKA_SUBE", "Şube");
            dicFieldCaption.Add("BANKA", "Banka");
            dicFieldCaption.Add("FOY_OZEL_DURUM", "Özel Durum");
            dicFieldCaption.Add("ICRA_ADLIYE", "Adliye");
            dicFieldCaption.Add("ICRA_BIRIM_NO", "Birim No");
            dicFieldCaption.Add("BOLUM", "Bölüm");
            dicFieldCaption.Add("ID", "Kayıt Sayısı");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            //    RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();
            RepositoryItemCheckEdit rcheck = new RepositoryItemCheckEdit();
            //    Inits.DovizTipGetir(rlueDoviz);

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("DovizId", InitsEx.DovizTipGetir);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("HACIZLI_MAL_DEGERI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("HACIZLI_MAL_DEGERI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("HACIZLI_MAL_SATIR_TOPLAM_MIKTAR", InitsEx.ParaBicimiAyarla);

            //sozluk.Add("TAHSILAT_DURUM", Item);

            #endregion Add item

            return sozluk;
        }

        private PivotGridField[] HacizSayisiBurolaraGore()
        {
            #region Field & Properties

            PivotGridField fieldHACIZ_SIRA_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_SIRA_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZ_SIRA_NO.AreaIndex = 0;
            fieldHACIZ_SIRA_NO.FieldName = "HACIZ_SIRA_NO";
            fieldHACIZ_SIRA_NO.Name = "fieldHACIZ_SIRA_NO";
            fieldHACIZ_SIRA_NO.Visible = false;

            PivotGridField fieldHACIZ_TALEP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_TALEP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZ_TALEP_TARIHI.AreaIndex = 1;
            fieldHACIZ_TALEP_TARIHI.FieldName = "HACIZ_TALEP_TARIHI";
            fieldHACIZ_TALEP_TARIHI.Name = "fieldHACIZ_TALEP_TARIHI";
            fieldHACIZ_TALEP_TARIHI.Visible = false;

            PivotGridField fieldHACIZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldHACIZ_TARIHI.GroupInterval = PivotGroupInterval.DateYear;
            fieldHACIZ_TARIHI.AreaIndex = 2;
            fieldHACIZ_TARIHI.FieldName = "HACIZ_TARIHI";
            fieldHACIZ_TARIHI.Name = "fieldHACIZ_TARIHI";
            fieldHACIZ_TARIHI.Visible = true;

            PivotGridField fieldHACIZ_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldHACIZ_TARIHI2.GroupInterval = PivotGroupInterval.DateMonth;
            fieldHACIZ_TARIHI2.AreaIndex = 2;
            fieldHACIZ_TARIHI2.FieldName = "HACIZ_TARIHI";
            fieldHACIZ_TARIHI2.Name = "fieldHACIZ_TARIHI2";
            fieldHACIZ_TARIHI2.Visible = true;

            PivotGridField fieldALACAKLI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAKLI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAKLI.AreaIndex = 3;
            fieldALACAKLI.FieldName = "ALACAKLI";
            fieldALACAKLI.Name = "fieldALACAKLI";
            fieldALACAKLI.Visible = false;

            PivotGridField fieldBORCLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORCLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORCLU.AreaIndex = 4;
            fieldBORCLU.FieldName = "BORCLU";
            fieldBORCLU.Name = "fieldBORCLU";
            fieldBORCLU.Visible = false;

            PivotGridField fieldHACIZ_MEMURU_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_MEMURU_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZ_MEMURU_ADI.AreaIndex = 5;
            fieldHACIZ_MEMURU_ADI.FieldName = "HACIZ_MEMURU_ADI";
            fieldHACIZ_MEMURU_ADI.Name = "fieldHACIZ_MEMURU_ADI";
            fieldHACIZ_MEMURU_ADI.Visible = false;

            PivotGridField fieldHACIZ_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZ_ACIKLAMA.AreaIndex = 6;
            fieldHACIZ_ACIKLAMA.FieldName = "HACIZ_ACIKLAMA";
            fieldHACIZ_ACIKLAMA.Name = "fieldHACIZ_ACIKLAMA";
            fieldHACIZ_ACIKLAMA.Visible = false;

            PivotGridField fieldICRA_TUTANAK_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_TUTANAK_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_TUTANAK_NO.AreaIndex = 7;
            fieldICRA_TUTANAK_NO.FieldName = "ICRA_TUTANAK_NO";
            fieldICRA_TUTANAK_NO.Name = "fieldICRA_TUTANAK_NO";
            fieldICRA_TUTANAK_NO.Visible = false;

            PivotGridField fieldBORCLU_HAZIR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORCLU_HAZIR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORCLU_HAZIR_MI.AreaIndex = 8;
            fieldBORCLU_HAZIR_MI.FieldName = "BORCLU_HAZIR_MI";
            fieldBORCLU_HAZIR_MI.Name = "fieldBORCLU_HAZIR_MI";
            fieldBORCLU_HAZIR_MI.Visible = false;

            PivotGridField fieldYUZUC_UYGULANDI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYUZUC_UYGULANDI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldYUZUC_UYGULANDI_MI.AreaIndex = 9;
            fieldYUZUC_UYGULANDI_MI.FieldName = "YUZUC_UYGULANDI_MI";
            fieldYUZUC_UYGULANDI_MI.Name = "fieldYUZUC_UYGULANDI_MI";
            fieldYUZUC_UYGULANDI_MI.Visible = false;

            PivotGridField fieldSURET_BIRAKILDI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSURET_BIRAKILDI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSURET_BIRAKILDI_MI.AreaIndex = 10;
            fieldSURET_BIRAKILDI_MI.FieldName = "SURET_BIRAKILDI_MI";
            fieldSURET_BIRAKILDI_MI.Name = "fieldSURET_BIRAKILDI_MI";
            fieldSURET_BIRAKILDI_MI.Visible = false;

            PivotGridField fieldBAKIYE_HACIZI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBAKIYE_HACIZI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBAKIYE_HACIZI_MI.AreaIndex = 11;
            fieldBAKIYE_HACIZI_MI.FieldName = "BAKIYE_HACIZI_MI";
            fieldBAKIYE_HACIZI_MI.Name = "fieldBAKIYE_HACIZI_MI";
            fieldBAKIYE_HACIZI_MI.Visible = false;

            PivotGridField fieldGECICI_HACIZ_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGECICI_HACIZ_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGECICI_HACIZ_MI.AreaIndex = 12;
            fieldGECICI_HACIZ_MI.FieldName = "GECICI_HACIZ_MI";
            fieldGECICI_HACIZ_MI.Name = "fieldGECICI_HACIZ_MI";
            fieldGECICI_HACIZ_MI.Visible = false;

            PivotGridField fieldKOLLUK_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKOLLUK_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKOLLUK_VAR_MI.AreaIndex = 13;
            fieldKOLLUK_VAR_MI.FieldName = "KOLLUK_VAR_MI";
            fieldKOLLUK_VAR_MI.Name = "fieldKOLLUK_VAR_MI";
            fieldKOLLUK_VAR_MI.Visible = false;

            PivotGridField fieldCILINGIR_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCILINGIR_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCILINGIR_VAR_MI.AreaIndex = 14;
            fieldCILINGIR_VAR_MI.FieldName = "CILINGIR_VAR_MI";
            fieldCILINGIR_VAR_MI.Name = "fieldCILINGIR_VAR_MI";
            fieldCILINGIR_VAR_MI.Visible = false;

            PivotGridField fieldSEHIR_DISI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSEHIR_DISI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSEHIR_DISI_MI.AreaIndex = 15;
            fieldSEHIR_DISI_MI.FieldName = "SEHIR_DISI_MI";
            fieldSEHIR_DISI_MI.Name = "fieldSEHIR_DISI_MI";
            fieldSEHIR_DISI_MI.Visible = false;

            PivotGridField fieldTALIMAT_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALIMAT_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALIMAT_MI.AreaIndex = 16;
            fieldTALIMAT_MI.FieldName = "TALIMAT_MI";
            fieldTALIMAT_MI.Name = "fieldTALIMAT_MI";
            fieldTALIMAT_MI.Visible = false;

            PivotGridField fieldTALIMAT_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALIMAT_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALIMAT_ESAS_NO.AreaIndex = 17;
            fieldTALIMAT_ESAS_NO.FieldName = "TALIMAT_ESAS_NO";
            fieldTALIMAT_ESAS_NO.Name = "fieldTALIMAT_ESAS_NO";
            fieldTALIMAT_ESAS_NO.Visible = false;

            PivotGridField fieldTALIMAT_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALIMAT_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALIMAT_ADLIYE.AreaIndex = 18;
            fieldTALIMAT_ADLIYE.FieldName = "TALIMAT_ADLIYE";
            fieldTALIMAT_ADLIYE.Name = "fieldTALIMAT_ADLIYE";
            fieldTALIMAT_ADLIYE.Visible = false;

            PivotGridField fieldTALIMAT_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALIMAT_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALIMAT_BIRIM_NO.AreaIndex = 19;
            fieldTALIMAT_BIRIM_NO.FieldName = "TALIMAT_BIRIM_NO";
            fieldTALIMAT_BIRIM_NO.Name = "fieldTALIMAT_BIRIM_NO";
            fieldTALIMAT_BIRIM_NO.Visible = false;

            PivotGridField fieldMAL_SIRA_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAL_SIRA_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAL_SIRA_NO.AreaIndex = 20;
            fieldMAL_SIRA_NO.FieldName = "MAL_SIRA_NO";
            fieldMAL_SIRA_NO.Name = "fieldMAL_SIRA_NO";
            fieldMAL_SIRA_NO.Visible = false;

            PivotGridField fieldMAL_TUR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAL_TUR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAL_TUR.AreaIndex = 21;
            fieldMAL_TUR.FieldName = "MAL_TUR";
            fieldMAL_TUR.Name = "fieldMAL_TUR";
            fieldMAL_TUR.Visible = false;

            PivotGridField fieldMAL_KATAGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAL_KATAGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAL_KATAGORI.AreaIndex = 22;
            fieldMAL_KATAGORI.FieldName = "MAL_KATAGORI";
            fieldMAL_KATAGORI.Name = "fieldMAL_KATAGORI";
            fieldMAL_KATAGORI.Visible = false;

            PivotGridField fieldMAL_CINS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAL_CINS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAL_CINS.AreaIndex = 23;
            fieldMAL_CINS.FieldName = "MAL_CINS";
            fieldMAL_CINS.Name = "fieldMAL_CINS";
            fieldMAL_CINS.Visible = false;

            PivotGridField fieldHACIZLI_MAL_NEVI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_NEVI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_NEVI.AreaIndex = 24;
            fieldHACIZLI_MAL_NEVI.FieldName = "HACIZLI_MAL_NEVI";
            fieldHACIZLI_MAL_NEVI.Name = "fieldHACIZLI_MAL_NEVI";
            fieldHACIZLI_MAL_NEVI.Visible = false;

            PivotGridField fieldHACIZLI_MAL_MARKASI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_MARKASI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_MARKASI.AreaIndex = 25;
            fieldHACIZLI_MAL_MARKASI.FieldName = "HACIZLI_MAL_MARKASI";
            fieldHACIZLI_MAL_MARKASI.Name = "fieldHACIZLI_MAL_MARKASI";
            fieldHACIZLI_MAL_MARKASI.Visible = false;

            PivotGridField fieldHACIZLI_MAL_ADEDI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_ADEDI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_ADEDI.AreaIndex = 26;
            fieldHACIZLI_MAL_ADEDI.FieldName = "HACIZLI_MAL_ADEDI";
            fieldHACIZLI_MAL_ADEDI.Name = "fieldHACIZLI_MAL_ADEDI";
            fieldHACIZLI_MAL_ADEDI.Visible = false;

            PivotGridField fieldHACIZLI_MAL_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_BIRIM.AreaIndex = 27;
            fieldHACIZLI_MAL_BIRIM.FieldName = "HACIZLI_MAL_BIRIM";
            fieldHACIZLI_MAL_BIRIM.Name = "fieldHACIZLI_MAL_BIRIM";
            fieldHACIZLI_MAL_BIRIM.Visible = false;

            PivotGridField fieldHACIZLI_MAL_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_DEGERI.AreaIndex = 28;
            fieldHACIZLI_MAL_DEGERI.FieldName = "HACIZLI_MAL_DEGERI";
            fieldHACIZLI_MAL_DEGERI.Name = "fieldHACIZLI_MAL_DEGERI";
            fieldHACIZLI_MAL_DEGERI.Visible = false;

            PivotGridField fieldHACIZLI_MAL_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_DEGERI_DOVIZ_ID.AreaIndex = 29;
            fieldHACIZLI_MAL_DEGERI_DOVIZ_ID.FieldName = "HACIZLI_MAL_DEGERI_DOVIZ_ID";
            fieldHACIZLI_MAL_DEGERI_DOVIZ_ID.Name = "fieldHACIZLI_MAL_DEGERI_DOVIZ_ID";
            fieldHACIZLI_MAL_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.AreaIndex = 30;
            fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.FieldName = "HACIZLI_MAL_SATIR_TOPLAM_MIKTAR";
            fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.Name = "fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR";
            fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.Visible = false;

            PivotGridField fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.AreaIndex = 31;
            fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.FieldName = "HACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID";
            fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.Name = "fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID";
            fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.Visible = false;

            PivotGridField fieldHACIZLI_MAL_OZELLIKLERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_OZELLIKLERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_OZELLIKLERI.AreaIndex = 32;
            fieldHACIZLI_MAL_OZELLIKLERI.FieldName = "HACIZLI_MAL_OZELLIKLERI";
            fieldHACIZLI_MAL_OZELLIKLERI.Name = "fieldHACIZLI_MAL_OZELLIKLERI";
            fieldHACIZLI_MAL_OZELLIKLERI.Visible = false;

            PivotGridField fieldARAC_PLAKA_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldARAC_PLAKA_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldARAC_PLAKA_NO.AreaIndex = 33;
            fieldARAC_PLAKA_NO.FieldName = "ARAC_PLAKA_NO";
            fieldARAC_PLAKA_NO.Name = "fieldARAC_PLAKA_NO";
            fieldARAC_PLAKA_NO.Visible = false;

            PivotGridField fieldHACIZLI_MAL_ACIKLAMASI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_ACIKLAMASI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_ACIKLAMASI.AreaIndex = 34;
            fieldHACIZLI_MAL_ACIKLAMASI.FieldName = "HACIZLI_MAL_ACIKLAMASI";
            fieldHACIZLI_MAL_ACIKLAMASI.Name = "fieldHACIZLI_MAL_ACIKLAMASI";
            fieldHACIZLI_MAL_ACIKLAMASI.Visible = false;

            PivotGridField fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.AreaIndex = 35;
            fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.FieldName = "HACZEDILEMEZLIKTEN_FERAGAT_VAR_MI";
            fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.Name = "fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI";
            fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.Visible = false;

            PivotGridField fieldUCUNCU_SAHISTA_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldUCUNCU_SAHISTA_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldUCUNCU_SAHISTA_MI.AreaIndex = 36;
            fieldUCUNCU_SAHISTA_MI.FieldName = "UCUNCU_SAHISTA_MI";
            fieldUCUNCU_SAHISTA_MI.Name = "fieldUCUNCU_SAHISTA_MI";
            fieldUCUNCU_SAHISTA_MI.Visible = false;

            PivotGridField fieldUCUNCU_SAHIS_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldUCUNCU_SAHIS_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldUCUNCU_SAHIS_ADI.AreaIndex = 37;
            fieldUCUNCU_SAHIS_ADI.FieldName = "UCUNCU_SAHIS_ADI";
            fieldUCUNCU_SAHIS_ADI.Name = "fieldUCUNCU_SAHIS_ADI";
            fieldUCUNCU_SAHIS_ADI.Visible = false;

            PivotGridField fieldHACIZ_ISLEM_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_ISLEM_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZ_ISLEM_DURUM.AreaIndex = 38;
            fieldHACIZ_ISLEM_DURUM.FieldName = "HACIZ_ISLEM_DURUM";
            fieldHACIZ_ISLEM_DURUM.Name = "fieldHACIZ_ISLEM_DURUM";
            fieldHACIZ_ISLEM_DURUM.Visible = true;

            PivotGridField fieldISTIHKAK_IDDIASI_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIHKAK_IDDIASI_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIHKAK_IDDIASI_VAR_MI.AreaIndex = 39;
            fieldISTIHKAK_IDDIASI_VAR_MI.FieldName = "ISTIHKAK_IDDIASI_VAR_MI";
            fieldISTIHKAK_IDDIASI_VAR_MI.Name = "fieldISTIHKAK_IDDIASI_VAR_MI";
            fieldISTIHKAK_IDDIASI_VAR_MI.Visible = false;

            PivotGridField fieldPARAYA_CEVRILDI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPARAYA_CEVRILDI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPARAYA_CEVRILDI_MI.AreaIndex = 40;
            fieldPARAYA_CEVRILDI_MI.FieldName = "PARAYA_CEVRILDI_MI";
            fieldPARAYA_CEVRILDI_MI.Name = "fieldPARAYA_CEVRILDI_MI";
            fieldPARAYA_CEVRILDI_MI.Visible = false;

            PivotGridField fieldALACAKLI_RIZASI_VAR_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAKLI_RIZASI_VAR_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAKLI_RIZASI_VAR_MI.AreaIndex = 41;
            fieldALACAKLI_RIZASI_VAR_MI.FieldName = "ALACAKLI_RIZASI_VAR_MI";
            fieldALACAKLI_RIZASI_VAR_MI.Name = "fieldALACAKLI_RIZASI_VAR_MI";
            fieldALACAKLI_RIZASI_VAR_MI.Visible = false;

            PivotGridField fieldYEDDIEMIN_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYEDDIEMIN_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldYEDDIEMIN_CARI.AreaIndex = 42;
            fieldYEDDIEMIN_CARI.FieldName = "YEDDIEMIN_CARI";
            fieldYEDDIEMIN_CARI.Name = "fieldYEDDIEMIN_CARI";
            fieldYEDDIEMIN_CARI.Visible = false;

            PivotGridField fieldHACIZ_SORUMLUSU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_SORUMLUSU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZ_SORUMLUSU.AreaIndex = 43;
            fieldHACIZ_SORUMLUSU.FieldName = "HACIZ_SORUMLUSU";
            fieldHACIZ_SORUMLUSU.Name = "fieldHACIZ_SORUMLUSU";
            fieldHACIZ_SORUMLUSU.Visible = true;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_FOY_ID.AreaIndex = 44;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 45;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 46;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 47;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 48;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 49;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 50;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 51;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 52;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 53;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 54;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 55;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 56;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 57;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 58;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 59;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 60;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Caption = "Kayıt Sayısı";
            fieldID.AreaIndex = 61;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldHACIZ_SIRA_NO,
			fieldHACIZ_TALEP_TARIHI,
			fieldHACIZ_TARIHI,
            fieldHACIZ_TARIHI2,
			fieldALACAKLI,
			fieldBORCLU,
			fieldHACIZ_MEMURU_ADI,
			fieldHACIZ_ACIKLAMA,
			fieldICRA_TUTANAK_NO,
			fieldBORCLU_HAZIR_MI,
			fieldYUZUC_UYGULANDI_MI,
			fieldSURET_BIRAKILDI_MI,
			fieldBAKIYE_HACIZI_MI,
			fieldGECICI_HACIZ_MI,
			fieldKOLLUK_VAR_MI,
			fieldCILINGIR_VAR_MI,
			fieldSEHIR_DISI_MI,
			fieldTALIMAT_MI,
			fieldTALIMAT_ESAS_NO,
			fieldTALIMAT_ADLIYE,
			fieldTALIMAT_BIRIM_NO,
			fieldMAL_SIRA_NO,
			fieldMAL_TUR,
			fieldMAL_KATAGORI,
			fieldMAL_CINS,
			fieldHACIZLI_MAL_NEVI,
			fieldHACIZLI_MAL_MARKASI,
			fieldHACIZLI_MAL_ADEDI,
			fieldHACIZLI_MAL_BIRIM,
			fieldHACIZLI_MAL_DEGERI,
			fieldHACIZLI_MAL_DEGERI_DOVIZ_ID,
			fieldHACIZLI_MAL_SATIR_TOPLAM_MIKTAR,
			fieldHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID,
			fieldHACIZLI_MAL_OZELLIKLERI,
			fieldARAC_PLAKA_NO,
			fieldHACIZLI_MAL_ACIKLAMASI,
			fieldHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI,
			fieldUCUNCU_SAHISTA_MI,
			fieldUCUNCU_SAHIS_ADI,
			fieldHACIZ_ISLEM_DURUM,
			fieldISTIHKAK_IDDIASI_VAR_MI,
			fieldPARAYA_CEVRILDI_MI,
			fieldALACAKLI_RIZASI_VAR_MI,
			fieldYEDDIEMIN_CARI,
			fieldHACIZ_SORUMLUSU,
			fieldICRA_FOY_ID,
			fieldESAS_NO,
			fieldTAKIP_TARIHI,
			fieldBOLGE,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldKREDI_TIP,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldFOY_YERI,
			fieldFOY_BIRIM,
			fieldBANKA_SUBE,
			fieldBANKA,
			fieldFOY_OZEL_DURUM,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
            fieldBOLUM,
			fieldID,
			};
            return dizi;
        }
    }
}