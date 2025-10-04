using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class MasrafAvansBirlesik
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

            GridColumn colTARIH = new GridColumn();
            colTARIH.VisibleIndex = 1;
            colTARIH.FieldName = "TARIH";
            colTARIH.Name = "colTARIH";
            colTARIH.Visible = true;

            GridColumn colADET = new GridColumn();
            colADET.VisibleIndex = 2;
            colADET.FieldName = "ADET";
            colADET.Name = "colADET";
            colADET.Visible = true;

            GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
            colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 3;
            colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Visible = true;

            GridColumn colBIRIM_FIYAT = new GridColumn();
            colBIRIM_FIYAT.VisibleIndex = 4;
            colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
            colBIRIM_FIYAT.Visible = true;

            GridColumn colTOPLAM_TUTAR = new GridColumn();
            colTOPLAM_TUTAR.VisibleIndex = 5;
            colTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            colTOPLAM_TUTAR.Name = "colTOPLAM_TUTAR";
            colTOPLAM_TUTAR.Visible = true;

            GridColumn colTOPLAM_TUTAR_DOVIZ_ID = new GridColumn();
            colTOPLAM_TUTAR_DOVIZ_ID.VisibleIndex = 6;
            colTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            colTOPLAM_TUTAR_DOVIZ_ID.Name = "colTOPLAM_TUTAR_DOVIZ_ID";
            colTOPLAM_TUTAR_DOVIZ_ID.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 7;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 8;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 9;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colICRA_ADLIYE = new GridColumn();
            colICRA_ADLIYE.VisibleIndex = 10;
            colICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            colICRA_ADLIYE.Name = "colICRA_ADLIYE";
            colICRA_ADLIYE.Visible = true;

            GridColumn colICRA_BIRIM_NO = new GridColumn();
            colICRA_BIRIM_NO.VisibleIndex = 11;
            colICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Name = "colICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 12;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colBANKA_SUBE = new GridColumn();
            colBANKA_SUBE.VisibleIndex = 13;
            colBANKA_SUBE.FieldName = "BANKA_SUBE";
            colBANKA_SUBE.Name = "colBANKA_SUBE";
            colBANKA_SUBE.Visible = true;

            GridColumn colFOY_BIRIM = new GridColumn();
            colFOY_BIRIM.VisibleIndex = 14;
            colFOY_BIRIM.FieldName = "FOY_BIRIM";
            colFOY_BIRIM.Name = "colFOY_BIRIM";
            colFOY_BIRIM.Visible = true;

            GridColumn colFOY_YERI = new GridColumn();
            colFOY_YERI.VisibleIndex = 15;
            colFOY_YERI.FieldName = "FOY_YERI";
            colFOY_YERI.Name = "colFOY_YERI";
            colFOY_YERI.Visible = true;

            GridColumn colFOY_OZEL_DURUM = new GridColumn();
            colFOY_OZEL_DURUM.VisibleIndex = 16;
            colFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Name = "colFOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 17;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colTAHSILAT_DURUM = new GridColumn();
            colTAHSILAT_DURUM.VisibleIndex = 18;
            colTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            colTAHSILAT_DURUM.Name = "colTAHSILAT_DURUM";
            colTAHSILAT_DURUM.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 19;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colBOLGE = new GridColumn();
            colBOLGE.VisibleIndex = 20;
            colBOLGE.FieldName = "BOLGE";
            colBOLGE.Name = "colBOLGE";
            colBOLGE.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 21;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 22;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colMASRAF_TARAF = new GridColumn();
            colMASRAF_TARAF.VisibleIndex = 23;
            colMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            colMASRAF_TARAF.Name = "colMASRAF_TARAF";
            colMASRAF_TARAF.Visible = true;

            GridColumn colODEME_TIP = new GridColumn();
            colODEME_TIP.VisibleIndex = 24;
            colODEME_TIP.FieldName = "ODEME_TIP";
            colODEME_TIP.Name = "colODEME_TIP";
            colODEME_TIP.Visible = true;

            GridColumn colBORC_ALACAK = new GridColumn();
            colBORC_ALACAK.VisibleIndex = 25;
            colBORC_ALACAK.FieldName = "BORC_ALACAK";
            colBORC_ALACAK.Name = "colBORC_ALACAK";
            colBORC_ALACAK.Visible = true;

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

            GridColumn colMUVEKKIL_CARI = new GridColumn();
            colMUVEKKIL_CARI.VisibleIndex = 28;
            colMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            colMUVEKKIL_CARI.Name = "colMUVEKKIL_CARI";
            colMUVEKKIL_CARI.Visible = true;

            GridColumn colMASRAF_AVANS_ID = new GridColumn();
            colMASRAF_AVANS_ID.VisibleIndex = 29;
            colMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            colMASRAF_AVANS_ID.Name = "colMASRAF_AVANS_ID";
            colMASRAF_AVANS_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 30;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 31;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colREFERANS_NO,
			colTARIH,
			colADET,
			colBIRIM_FIYAT_DOVIZ_ID,
			colBIRIM_FIYAT,
			colTOPLAM_TUTAR,
			colTOPLAM_TUTAR_DOVIZ_ID,
			colFOY_NO,
			colTAKIP_TARIHI,
			colESAS_NO,
			colICRA_ADLIYE,
			colICRA_BIRIM_NO,
			colBANKA,
			colBANKA_SUBE,
			colFOY_BIRIM,
			colFOY_YERI,
			colFOY_OZEL_DURUM,
			colKREDI_GRUP,
			colTAHSILAT_DURUM,
			colKREDI_TIP,
			colBOLGE,
			colBOLUM,

			//colID,
			colMASRAF_TARAF,
			colODEME_TIP,
			colBORC_ALACAK,
			colANA_KATEGORI,
			colALT_KATEGORI,
			colMUVEKKIL_CARI,
			colMASRAF_AVANS_ID,
			colSUBE_KOD_ID,
			colKONTROL_KIM_ID,
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

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

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

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = false;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_AVANS_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 30;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 31;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            #endregion Field & Properties

            switch (pencere)
            {
                case "Masrafların Hukuk Bölümlerine göre dağılımı":
                    dizi = MasraflarinBolumlereGoreDagilimi();
                    break;

                case "Masrafların Yılın Çeyreklerine Göre Dağılımı":
                    dizi = MasraflarinYilinCeyreklerineGoreDagilimi();
                    break;

                case "Masrafların Ödeme Yerine Göre Dağılımı":
                    dizi = MasraflarinOdemeYerineGoreDagilimi();
                    break;

                case "Masrafların Ödeme Tipine Göre Dağılımı":
                    dizi = MasraflarinOdemeTipineGoreDagilimi();
                    break;

                case "Masrafların Mahsup Kalemine Göre Dağılımı":
                    dizi = MasraflarinMahsupKalemineGoreDagilimi();
                    break;

                case "Masrafların Yıllara Göre Dağılımı":
                    dizi = MasraflarinYıllaraGoreDagilimi();
                    break;

                case "Masrafların Ana Kategorisine Göre Dağılımı":
                    dizi = MasraflarinAnaKatGoreDagilimi();
                    break;

                case "Masrafların Alt Kategorilerine Göre Dağılımı":
                    dizi = MasraflarinAltKatGoreDagilimi();
                    break;

                case "Masrafların Hukuk Bürolarına Göre Dağılımı":
                    dizi = MasraflarinBurolarinaGoreDagilimi();
                    break;

                case "Avansların Hukuk Bölümlerine Göre Dağılımı":
                    dizi = AvanslarinBolumlereGoreDagilimi();
                    break;

                case "Avansların Hukuk Bürolarına Göre Dağılımı":
                    dizi = AvanslarinBurolaraGoreDagilimi();
                    break;

                case "Masrafların Aylara Göre Dağılımı":
                    dizi = MasraflarinAylaraGoreDagilimi();
                    break;

                case "En Çok Masraf Yapılan 50 Dosya":
                    dizi = EnCokMasrafYapilanElliDosya();
                    break;

                case "En Çok Masraf Yapan 10 Büro":
                    dizi = EnCokMasrafYapilanOnBuro();
                    break;

                case "En Çok Masraf Yapan 10 Sorumlu":
                    dizi = EnCokMasrafYapilanOnSorumlu();
                    break;
                default:
                    dizi = null;
                    break;
            }

            #region []

            if (dizi == null)
            {
                dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
			fieldSUBE_KOD_ID,
			fieldKONTROL_KIM_ID,
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

        private PivotGridField[] AvanslarinBolumlereGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = true;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

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

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = false;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldMASRAF_AVANS_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = true;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] AvanslarinBurolaraGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

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

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = false;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldMASRAF_AVANS_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = true;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 30;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] EnCokMasrafYapilanElliDosya()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = true;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

            PivotGridField fieldANA_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldANA_KATEGORI.AreaIndex = 26;
            fieldANA_KATEGORI.FieldName = "ANA_KATEGORI";
            fieldANA_KATEGORI.Name = "fieldANA_KATEGORI";
            fieldANA_KATEGORI.Visible = true;

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 27;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = false;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldMASRAF_AVANS_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = true;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] EnCokMasrafYapilanOnBuro()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = true;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

            PivotGridField fieldANA_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldANA_KATEGORI.AreaIndex = 26;
            fieldANA_KATEGORI.FieldName = "ANA_KATEGORI";
            fieldANA_KATEGORI.Name = "fieldANA_KATEGORI";
            fieldANA_KATEGORI.Visible = true;

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 27;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = false;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldMASRAF_AVANS_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = true;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSUBE_KOD_ID.AreaIndex = 30;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
            fieldSUBE_KOD_ID,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] EnCokMasrafYapilanOnSorumlu()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = true;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

            PivotGridField fieldANA_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldANA_KATEGORI.AreaIndex = 26;
            fieldANA_KATEGORI.FieldName = "ANA_KATEGORI";
            fieldANA_KATEGORI.Name = "fieldANA_KATEGORI";
            fieldANA_KATEGORI.Visible = true;

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 27;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = true;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldMASRAF_AVANS_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = true;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldSUBE_KOD_ID.AreaIndex = 30;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
            fieldSUBE_KOD_ID,
			};

            #endregion []

            return dizi;
        }

        private Dictionary<string, string> GetCaptionDictinory()
        {
            Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

            #region Caption Edit

            dicFieldCaption.Add("REFERANS_NO", "Ref No");
            dicFieldCaption.Add("TARIH", "Tarih");
            dicFieldCaption.Add("ADET", "Adet");
            dicFieldCaption.Add("BIRIM_FIYAT", "Birim Fiyat");
            dicFieldCaption.Add("TOPLAM_TUTAR", "Toplam Tutar");
            dicFieldCaption.Add("FOY_NO", "Foy No");
            dicFieldCaption.Add("TAKIP_TARIHI", "Takip T.");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("ICRA_ADLIYE", "Adliye");
            dicFieldCaption.Add("ICRA_BIRIM_NO", "No");
            dicFieldCaption.Add("BANKA", "Banka");
            dicFieldCaption.Add("BANKA_SUBE", "Şube");
            dicFieldCaption.Add("FOY_BIRIM", "Foy Birim");
            dicFieldCaption.Add("FOY_YERI", "Foy Yeri");
            dicFieldCaption.Add("FOY_OZEL_DURUM", "Özel Durum");
            dicFieldCaption.Add("KREDI_GRUP", "Kredi Grup");
            dicFieldCaption.Add("TAHSILAT_DURUM", "Tahsilat Durum");
            dicFieldCaption.Add("KREDI_TIP", "Kredi Tip");
            dicFieldCaption.Add("BOLGE", "Bölge");
            dicFieldCaption.Add("BOLUM", "Bölüm");
            dicFieldCaption.Add("ID", "Kayıt Sayısı");
            dicFieldCaption.Add("MASRAF_TARAF", "Masraf Taraf");
            dicFieldCaption.Add("ODEME_TIP", "Ödeme Tip");
            dicFieldCaption.Add("BORC_ALACAK", "Borç Alacak");
            dicFieldCaption.Add("ANA_KATEGORI", "Ana Kategori");
            dicFieldCaption.Add("ALT_KATEGORI", "Alt Kategori");
            dicFieldCaption.Add("MUVEKKIL_CARI", "Müvekkil");
            dicFieldCaption.Add("MASRAF_AVANS_ID", "Dosya Sayısı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");

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
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("TOPLAM_TUTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TOPLAM_TUTAR_DOVIZ_ID", InitsEx.DovizTipGetir);

            //sozluk.Add("TAHSILAT_DURUM", Item);

            #endregion Add item

            return sozluk;
        }

        private PivotGridField[] MasraflarinAltKatGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

            PivotGridField fieldANA_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldANA_KATEGORI.AreaIndex = 26;
            fieldANA_KATEGORI.FieldName = "ANA_KATEGORI";
            fieldANA_KATEGORI.Name = "fieldANA_KATEGORI";
            fieldANA_KATEGORI.Visible = false;

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldALT_KATEGORI.AreaIndex = 27;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = true;

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = false;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldMASRAF_AVANS_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = true;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] MasraflarinAnaKatGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

            PivotGridField fieldANA_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldANA_KATEGORI.AreaIndex = 26;
            fieldANA_KATEGORI.FieldName = "ANA_KATEGORI";
            fieldANA_KATEGORI.Name = "fieldANA_KATEGORI";
            fieldANA_KATEGORI.Visible = true;

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALT_KATEGORI.AreaIndex = 27;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = false;

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = false;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldMASRAF_AVANS_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = true;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] MasraflarinAylaraGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

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

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = false;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldMASRAF_AVANS_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = true;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
			};

            #endregion []

            return dizi;
        }

        private PivotGridField[] MasraflarinBolumlereGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = true;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

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

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = true;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldMASRAF_AVANS_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = true;

            #endregion Field & Properties

            #region

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
			};

            #endregion

            return dizi;
        }

        private PivotGridField[] MasraflarinBurolarinaGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

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

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = false;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = false;

            #endregion

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
			};

            #endregion

            return dizi;
        }

        private PivotGridField[] MasraflarinMahsupKalemineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

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

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = false;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = false;

            #endregion

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
			};

            #endregion

            return dizi;
        }

        private PivotGridField[] MasraflarinOdemeTipineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = true;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

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

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = false;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldMASRAF_AVANS_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = true;

            #endregion

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
			};

            #endregion

            return dizi;
        }

        private PivotGridField[] MasraflarinOdemeYerineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldFOY_YERI.Caption = "Ödeme Yeri";
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = true;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

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

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = false;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldMASRAF_AVANS_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = true;

            #endregion

            #region

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
			};

            #endregion

            return dizi;
        }

        private PivotGridField[] MasraflarinYıllaraGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

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

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = false;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldMASRAF_AVANS_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = true;

            #endregion

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
			};

            #endregion

            return dizi;
        }

        private PivotGridField[] MasraflarinYilinCeyreklerineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 0;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARIH.AreaIndex = 1;
            fieldTARIH.FieldName = "TARIH";
            fieldTARIH.Name = "fieldTARIH";
            fieldTARIH.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 2;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 3;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 4;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR.AreaIndex = 5;
            fieldTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Name = "fieldTOPLAM_TUTAR";
            fieldTOPLAM_TUTAR.Visible = false;

            PivotGridField fieldTOPLAM_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TUTAR_DOVIZ_ID.AreaIndex = 6;
            fieldTOPLAM_TUTAR_DOVIZ_ID.FieldName = "TOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Name = "fieldTOPLAM_TUTAR_DOVIZ_ID";
            fieldTOPLAM_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 7;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateQuarter;
            fieldTAKIP_TARIHI.AreaIndex = 8;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 9;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 10;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 11;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 12;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 13;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 14;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 15;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 16;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 17;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 18;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 19;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 20;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 21;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 22;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldMASRAF_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASRAF_TARAF.AreaIndex = 23;
            fieldMASRAF_TARAF.FieldName = "MASRAF_TARAF";
            fieldMASRAF_TARAF.Name = "fieldMASRAF_TARAF";
            fieldMASRAF_TARAF.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 24;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 25;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

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

            PivotGridField fieldMUVEKKIL_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_CARI.AreaIndex = 28;
            fieldMUVEKKIL_CARI.FieldName = "MUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Name = "fieldMUVEKKIL_CARI";
            fieldMUVEKKIL_CARI.Visible = false;

            PivotGridField fieldMASRAF_AVANS_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASRAF_AVANS_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldMASRAF_AVANS_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMASRAF_AVANS_ID.AreaIndex = 29;
            fieldMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Name = "fieldMASRAF_AVANS_ID";
            fieldMASRAF_AVANS_ID.Visible = true;

            #endregion

            #region

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldREFERANS_NO,
			fieldTARIH,
			fieldADET,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldBIRIM_FIYAT,
			fieldTOPLAM_TUTAR,
			fieldTOPLAM_TUTAR_DOVIZ_ID,
			fieldFOY_NO,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldTAHSILAT_DURUM,
			fieldKREDI_TIP,
			fieldBOLGE,
			fieldBOLUM,
			fieldID,
			fieldMASRAF_TARAF,
			fieldODEME_TIP,
			fieldBORC_ALACAK,
			fieldANA_KATEGORI,
			fieldALT_KATEGORI,
			fieldMUVEKKIL_CARI,
			fieldMASRAF_AVANS_ID,
			};

            #endregion

            return dizi;
        }
    }
}