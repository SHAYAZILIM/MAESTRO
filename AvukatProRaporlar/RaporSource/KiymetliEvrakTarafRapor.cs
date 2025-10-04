using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class KiymetliEvrakTarafRapor
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

            GridColumn colTUR = new GridColumn();
            colTUR.VisibleIndex = 1;
            colTUR.FieldName = "TUR";
            colTUR.Name = "colTUR";
            colTUR.Visible = true;

            GridColumn colSORAN_CARI = new GridColumn();
            colSORAN_CARI.VisibleIndex = 2;
            colSORAN_CARI.FieldName = "SORAN_CARI";
            colSORAN_CARI.Name = "colSORAN_CARI";
            colSORAN_CARI.Visible = true;

            GridColumn colKIYMETLI_EVRAK_TARAF_CARI = new GridColumn();
            colKIYMETLI_EVRAK_TARAF_CARI.VisibleIndex = 3;
            colKIYMETLI_EVRAK_TARAF_CARI.FieldName = "KIYMETLI_EVRAK_TARAF_CARI";
            colKIYMETLI_EVRAK_TARAF_CARI.Name = "colKIYMETLI_EVRAK_TARAF_CARI";
            colKIYMETLI_EVRAK_TARAF_CARI.Visible = true;

            GridColumn colTARAF_TIP = new GridColumn();
            colTARAF_TIP.VisibleIndex = 4;
            colTARAF_TIP.FieldName = "TARAF_TIP";
            colTARAF_TIP.Name = "colTARAF_TIP";
            colTARAF_TIP.Visible = true;

            GridColumn colEVRAK_KAYIT_TARIHI = new GridColumn();
            colEVRAK_KAYIT_TARIHI.VisibleIndex = 5;
            colEVRAK_KAYIT_TARIHI.FieldName = "EVRAK_KAYIT_TARIHI";
            colEVRAK_KAYIT_TARIHI.Name = "colEVRAK_KAYIT_TARIHI";
            colEVRAK_KAYIT_TARIHI.Visible = true;

            GridColumn colEVRAK_VADE_TARIHI = new GridColumn();
            colEVRAK_VADE_TARIHI.VisibleIndex = 6;
            colEVRAK_VADE_TARIHI.FieldName = "EVRAK_VADE_TARIHI";
            colEVRAK_VADE_TARIHI.Name = "colEVRAK_VADE_TARIHI";
            colEVRAK_VADE_TARIHI.Visible = true;

            GridColumn colTUTAR = new GridColumn();
            colTUTAR.VisibleIndex = 7;
            colTUTAR.FieldName = "TUTAR";
            colTUTAR.Name = "colTUTAR";
            colTUTAR.Visible = true;

            GridColumn colTUTAR_DOVIZ_ID = new GridColumn();
            colTUTAR_DOVIZ_ID.VisibleIndex = 8;
            colTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            colTUTAR_DOVIZ_ID.Name = "colTUTAR_DOVIZ_ID";
            colTUTAR_DOVIZ_ID.Visible = true;

            GridColumn colEVRAK_TANZIM_TARIHI = new GridColumn();
            colEVRAK_TANZIM_TARIHI.VisibleIndex = 9;
            colEVRAK_TANZIM_TARIHI.FieldName = "EVRAK_TANZIM_TARIHI";
            colEVRAK_TANZIM_TARIHI.Name = "colEVRAK_TANZIM_TARIHI";
            colEVRAK_TANZIM_TARIHI.Visible = true;

            GridColumn colNE_SEKILDE_AHZOLUNDUGU = new GridColumn();
            colNE_SEKILDE_AHZOLUNDUGU.VisibleIndex = 10;
            colNE_SEKILDE_AHZOLUNDUGU.FieldName = "NE_SEKILDE_AHZOLUNDUGU";
            colNE_SEKILDE_AHZOLUNDUGU.Name = "colNE_SEKILDE_AHZOLUNDUGU";
            colNE_SEKILDE_AHZOLUNDUGU.Visible = true;

            GridColumn colBANKA_SUBE_KODU = new GridColumn();
            colBANKA_SUBE_KODU.VisibleIndex = 11;
            colBANKA_SUBE_KODU.FieldName = "BANKA_SUBE_KODU";
            colBANKA_SUBE_KODU.Name = "colBANKA_SUBE_KODU";
            colBANKA_SUBE_KODU.Visible = true;

            GridColumn colHESAP_NO = new GridColumn();
            colHESAP_NO.VisibleIndex = 12;
            colHESAP_NO.FieldName = "HESAP_NO";
            colHESAP_NO.Name = "colHESAP_NO";
            colHESAP_NO.Visible = true;

            GridColumn colCEK_NO = new GridColumn();
            colCEK_NO.VisibleIndex = 13;
            colCEK_NO.FieldName = "CEK_NO";
            colCEK_NO.Name = "colCEK_NO";
            colCEK_NO.Visible = true;

            GridColumn colSORULDUGU_TARIH = new GridColumn();
            colSORULDUGU_TARIH.VisibleIndex = 14;
            colSORULDUGU_TARIH.FieldName = "SORULDUGU_TARIH";
            colSORULDUGU_TARIH.Name = "colSORULDUGU_TARIH";
            colSORULDUGU_TARIH.Visible = true;

            GridColumn colSORULMA_SONUCU = new GridColumn();
            colSORULMA_SONUCU.VisibleIndex = 15;
            colSORULMA_SONUCU.FieldName = "SORULMA_SONUCU";
            colSORULMA_SONUCU.Name = "colSORULMA_SONUCU";
            colSORULMA_SONUCU.Visible = true;

            GridColumn colKARSILIK_TUTAR = new GridColumn();
            colKARSILIK_TUTAR.VisibleIndex = 16;
            colKARSILIK_TUTAR.FieldName = "KARSILIK_TUTAR";
            colKARSILIK_TUTAR.Name = "colKARSILIK_TUTAR";
            colKARSILIK_TUTAR.Visible = true;

            GridColumn colKARSILIK_TUTAR_DOVIZ_ID = new GridColumn();
            colKARSILIK_TUTAR_DOVIZ_ID.VisibleIndex = 17;
            colKARSILIK_TUTAR_DOVIZ_ID.FieldName = "KARSILIK_TUTAR_DOVIZ_ID";
            colKARSILIK_TUTAR_DOVIZ_ID.Name = "colKARSILIK_TUTAR_DOVIZ_ID";
            colKARSILIK_TUTAR_DOVIZ_ID.Visible = true;

            GridColumn colARKASI_YAZILDI_MI = new GridColumn();
            colARKASI_YAZILDI_MI.VisibleIndex = 18;
            colARKASI_YAZILDI_MI.FieldName = "ARKASI_YAZILDI_MI";
            colARKASI_YAZILDI_MI.Name = "colARKASI_YAZILDI_MI";
            colARKASI_YAZILDI_MI.Visible = true;

            GridColumn colSERH_ACIKLAMASI = new GridColumn();
            colSERH_ACIKLAMASI.VisibleIndex = 19;
            colSERH_ACIKLAMASI.FieldName = "SERH_ACIKLAMASI";
            colSERH_ACIKLAMASI.Name = "colSERH_ACIKLAMASI";
            colSERH_ACIKLAMASI.Visible = true;

            GridColumn colSIKAYET_EDILDI_MI = new GridColumn();
            colSIKAYET_EDILDI_MI.VisibleIndex = 20;
            colSIKAYET_EDILDI_MI.FieldName = "SIKAYET_EDILDI_MI";
            colSIKAYET_EDILDI_MI.Name = "colSIKAYET_EDILDI_MI";
            colSIKAYET_EDILDI_MI.Visible = true;

            GridColumn colKESIDE_YERI = new GridColumn();
            colKESIDE_YERI.VisibleIndex = 21;
            colKESIDE_YERI.FieldName = "KESIDE_YERI";
            colKESIDE_YERI.Name = "colKESIDE_YERI";
            colKESIDE_YERI.Visible = true;

            GridColumn colODEME_YERI = new GridColumn();
            colODEME_YERI.VisibleIndex = 22;
            colODEME_YERI.FieldName = "ODEME_YERI";
            colODEME_YERI.Name = "colODEME_YERI";
            colODEME_YERI.Visible = true;

            GridColumn colMUNZAM_SENET_MI = new GridColumn();
            colMUNZAM_SENET_MI.VisibleIndex = 23;
            colMUNZAM_SENET_MI.FieldName = "MUNZAM_SENET_MI";
            colMUNZAM_SENET_MI.Name = "colMUNZAM_SENET_MI";
            colMUNZAM_SENET_MI.Visible = true;

            GridColumn colTEMINAT_MI = new GridColumn();
            colTEMINAT_MI.VisibleIndex = 24;
            colTEMINAT_MI.FieldName = "TEMINAT_MI";
            colTEMINAT_MI.Name = "colTEMINAT_MI";
            colTEMINAT_MI.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 25;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 26;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colISLEMLER_BASLADIMI = new GridColumn();
            colISLEMLER_BASLADIMI.VisibleIndex = 27;
            colISLEMLER_BASLADIMI.FieldName = "ISLEMLER_BASLADIMI";
            colISLEMLER_BASLADIMI.Name = "colISLEMLER_BASLADIMI";
            colISLEMLER_BASLADIMI.Visible = true;

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

            GridColumn colTAKIBE_KONULDU_MU = new GridColumn();
            colTAKIBE_KONULDU_MU.VisibleIndex = 30;
            colTAKIBE_KONULDU_MU.FieldName = "TAKIBE_KONULDU_MU";
            colTAKIBE_KONULDU_MU.Name = "colTAKIBE_KONULDU_MU";
            colTAKIBE_KONULDU_MU.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			//colID,
			colTUR,
			colSORAN_CARI,
			colKIYMETLI_EVRAK_TARAF_CARI,
			colTARAF_TIP,
			colEVRAK_KAYIT_TARIHI,
			colEVRAK_VADE_TARIHI,
			colTUTAR,
			colTUTAR_DOVIZ_ID,
			colEVRAK_TANZIM_TARIHI,
			colNE_SEKILDE_AHZOLUNDUGU,
			colBANKA_SUBE_KODU,
			colHESAP_NO,
			colCEK_NO,
			colSORULDUGU_TARIH,
			colSORULMA_SONUCU,
			colKARSILIK_TUTAR,
			colKARSILIK_TUTAR_DOVIZ_ID,
			colARKASI_YAZILDI_MI,
			colSERH_ACIKLAMASI,
			colSIKAYET_EDILDI_MI,
			colKESIDE_YERI,
			colODEME_YERI,
			colMUNZAM_SENET_MI,
			colTEMINAT_MI,
			colSUBE_KOD_ID,
			colKONTROL_KIM_ID,
			colISLEMLER_BASLADIMI,
			colBANKA,
			colSUBE,
            colTAKIBE_KONULDU_MU,
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

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldTUR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUR.AreaIndex = 1;
            fieldTUR.FieldName = "TUR";
            fieldTUR.Name = "fieldTUR";
            fieldTUR.Visible = false;

            PivotGridField fieldSORAN_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORAN_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORAN_CARI.AreaIndex = 2;
            fieldSORAN_CARI.FieldName = "SORAN_CARI";
            fieldSORAN_CARI.Name = "fieldSORAN_CARI";
            fieldSORAN_CARI.Visible = false;

            PivotGridField fieldKIYMETLI_EVRAK_TARAF_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKIYMETLI_EVRAK_TARAF_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKIYMETLI_EVRAK_TARAF_CARI.AreaIndex = 3;
            fieldKIYMETLI_EVRAK_TARAF_CARI.FieldName = "KIYMETLI_EVRAK_TARAF_CARI";
            fieldKIYMETLI_EVRAK_TARAF_CARI.Name = "fieldKIYMETLI_EVRAK_TARAF_CARI";
            fieldKIYMETLI_EVRAK_TARAF_CARI.Visible = false;

            PivotGridField fieldTARAF_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARAF_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARAF_TIP.AreaIndex = 4;
            fieldTARAF_TIP.FieldName = "TARAF_TIP";
            fieldTARAF_TIP.Name = "fieldTARAF_TIP";
            fieldTARAF_TIP.Visible = false;

            PivotGridField fieldEVRAK_KAYIT_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldEVRAK_KAYIT_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldEVRAK_KAYIT_TARIHI.AreaIndex = 5;
            fieldEVRAK_KAYIT_TARIHI.FieldName = "EVRAK_KAYIT_TARIHI";
            fieldEVRAK_KAYIT_TARIHI.Name = "fieldEVRAK_KAYIT_TARIHI";
            fieldEVRAK_KAYIT_TARIHI.Visible = false;

            PivotGridField fieldEVRAK_VADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldEVRAK_VADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldEVRAK_VADE_TARIHI.AreaIndex = 6;
            fieldEVRAK_VADE_TARIHI.FieldName = "EVRAK_VADE_TARIHI";
            fieldEVRAK_VADE_TARIHI.Name = "fieldEVRAK_VADE_TARIHI";
            fieldEVRAK_VADE_TARIHI.Visible = false;

            PivotGridField fieldTUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR.AreaIndex = 7;
            fieldTUTAR.FieldName = "TUTAR";
            fieldTUTAR.Name = "fieldTUTAR";
            fieldTUTAR.Visible = false;

            PivotGridField fieldTUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_DOVIZ_ID.AreaIndex = 8;
            fieldTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            fieldTUTAR_DOVIZ_ID.Name = "fieldTUTAR_DOVIZ_ID";
            fieldTUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldEVRAK_TANZIM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldEVRAK_TANZIM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldEVRAK_TANZIM_TARIHI.AreaIndex = 9;
            fieldEVRAK_TANZIM_TARIHI.FieldName = "EVRAK_TANZIM_TARIHI";
            fieldEVRAK_TANZIM_TARIHI.Name = "fieldEVRAK_TANZIM_TARIHI";
            fieldEVRAK_TANZIM_TARIHI.Visible = false;

            PivotGridField fieldNE_SEKILDE_AHZOLUNDUGU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNE_SEKILDE_AHZOLUNDUGU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNE_SEKILDE_AHZOLUNDUGU.AreaIndex = 10;
            fieldNE_SEKILDE_AHZOLUNDUGU.FieldName = "NE_SEKILDE_AHZOLUNDUGU";
            fieldNE_SEKILDE_AHZOLUNDUGU.Name = "fieldNE_SEKILDE_AHZOLUNDUGU";
            fieldNE_SEKILDE_AHZOLUNDUGU.Visible = false;

            PivotGridField fieldBANKA_SUBE_KODU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE_KODU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE_KODU.AreaIndex = 11;
            fieldBANKA_SUBE_KODU.FieldName = "BANKA_SUBE_KODU";
            fieldBANKA_SUBE_KODU.Name = "fieldBANKA_SUBE_KODU";
            fieldBANKA_SUBE_KODU.Visible = false;

            PivotGridField fieldHESAP_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHESAP_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHESAP_NO.AreaIndex = 12;
            fieldHESAP_NO.FieldName = "HESAP_NO";
            fieldHESAP_NO.Name = "fieldHESAP_NO";
            fieldHESAP_NO.Visible = false;

            PivotGridField fieldCEK_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCEK_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCEK_NO.AreaIndex = 13;
            fieldCEK_NO.FieldName = "CEK_NO";
            fieldCEK_NO.Name = "fieldCEK_NO";
            fieldCEK_NO.Visible = false;

            PivotGridField fieldSORULDUGU_TARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORULDUGU_TARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORULDUGU_TARIH.AreaIndex = 14;
            fieldSORULDUGU_TARIH.FieldName = "SORULDUGU_TARIH";
            fieldSORULDUGU_TARIH.Name = "fieldSORULDUGU_TARIH";
            fieldSORULDUGU_TARIH.Visible = false;

            PivotGridField fieldSORULMA_SONUCU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORULMA_SONUCU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORULMA_SONUCU.AreaIndex = 15;
            fieldSORULMA_SONUCU.FieldName = "SORULMA_SONUCU";
            fieldSORULMA_SONUCU.Name = "fieldSORULMA_SONUCU";
            fieldSORULMA_SONUCU.Visible = false;

            PivotGridField fieldKARSILIK_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIK_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIK_TUTAR.AreaIndex = 16;
            fieldKARSILIK_TUTAR.FieldName = "KARSILIK_TUTAR";
            fieldKARSILIK_TUTAR.Name = "fieldKARSILIK_TUTAR";
            fieldKARSILIK_TUTAR.Visible = false;

            PivotGridField fieldKARSILIK_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIK_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIK_TUTAR_DOVIZ_ID.AreaIndex = 17;
            fieldKARSILIK_TUTAR_DOVIZ_ID.FieldName = "KARSILIK_TUTAR_DOVIZ_ID";
            fieldKARSILIK_TUTAR_DOVIZ_ID.Name = "fieldKARSILIK_TUTAR_DOVIZ_ID";
            fieldKARSILIK_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldARKASI_YAZILDI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldARKASI_YAZILDI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldARKASI_YAZILDI_MI.AreaIndex = 18;
            fieldARKASI_YAZILDI_MI.FieldName = "ARKASI_YAZILDI_MI";
            fieldARKASI_YAZILDI_MI.Name = "fieldARKASI_YAZILDI_MI";
            fieldARKASI_YAZILDI_MI.Visible = false;

            PivotGridField fieldSERH_ACIKLAMASI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSERH_ACIKLAMASI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSERH_ACIKLAMASI.AreaIndex = 19;
            fieldSERH_ACIKLAMASI.FieldName = "SERH_ACIKLAMASI";
            fieldSERH_ACIKLAMASI.Name = "fieldSERH_ACIKLAMASI";
            fieldSERH_ACIKLAMASI.Visible = false;

            PivotGridField fieldSIKAYET_EDILDI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSIKAYET_EDILDI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSIKAYET_EDILDI_MI.AreaIndex = 20;
            fieldSIKAYET_EDILDI_MI.FieldName = "SIKAYET_EDILDI_MI";
            fieldSIKAYET_EDILDI_MI.Name = "fieldSIKAYET_EDILDI_MI";
            fieldSIKAYET_EDILDI_MI.Visible = false;

            PivotGridField fieldKESIDE_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKESIDE_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKESIDE_YERI.AreaIndex = 21;
            fieldKESIDE_YERI.FieldName = "KESIDE_YERI";
            fieldKESIDE_YERI.Name = "fieldKESIDE_YERI";
            fieldKESIDE_YERI.Visible = false;

            PivotGridField fieldODEME_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_YERI.AreaIndex = 22;
            fieldODEME_YERI.FieldName = "ODEME_YERI";
            fieldODEME_YERI.Name = "fieldODEME_YERI";
            fieldODEME_YERI.Visible = false;

            PivotGridField fieldMUNZAM_SENET_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUNZAM_SENET_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUNZAM_SENET_MI.AreaIndex = 23;
            fieldMUNZAM_SENET_MI.FieldName = "MUNZAM_SENET_MI";
            fieldMUNZAM_SENET_MI.Name = "fieldMUNZAM_SENET_MI";
            fieldMUNZAM_SENET_MI.Visible = false;

            PivotGridField fieldTEMINAT_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEMINAT_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEMINAT_MI.AreaIndex = 24;
            fieldTEMINAT_MI.FieldName = "TEMINAT_MI";
            fieldTEMINAT_MI.Name = "fieldTEMINAT_MI";
            fieldTEMINAT_MI.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 25;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 26;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldISLEMLER_BASLADIMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEMLER_BASLADIMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEMLER_BASLADIMI.AreaIndex = 27;
            fieldISLEMLER_BASLADIMI.FieldName = "ISLEMLER_BASLADIMI";
            fieldISLEMLER_BASLADIMI.Name = "fieldISLEMLER_BASLADIMI";
            fieldISLEMLER_BASLADIMI.Visible = false;

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

            PivotGridField fieldTAKIBE_KONULDU_MU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBE_KONULDU_MU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBE_KONULDU_MU.AreaIndex = 30;
            fieldTAKIBE_KONULDU_MU.FieldName = "TAKIBE_KONULDU_MU";
            fieldTAKIBE_KONULDU_MU.Name = "fieldTAKIBE_KONULDU_MU";
            fieldTAKIBE_KONULDU_MU.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldTUR,
			fieldSORAN_CARI,
			fieldKIYMETLI_EVRAK_TARAF_CARI,
			fieldTARAF_TIP,
			fieldEVRAK_KAYIT_TARIHI,
			fieldEVRAK_VADE_TARIHI,
			fieldTUTAR,
			fieldTUTAR_DOVIZ_ID,
			fieldEVRAK_TANZIM_TARIHI,
			fieldNE_SEKILDE_AHZOLUNDUGU,
			fieldBANKA_SUBE_KODU,
			fieldHESAP_NO,
			fieldCEK_NO,
			fieldSORULDUGU_TARIH,
			fieldSORULMA_SONUCU,
			fieldKARSILIK_TUTAR,
			fieldKARSILIK_TUTAR_DOVIZ_ID,
			fieldARKASI_YAZILDI_MI,
			fieldSERH_ACIKLAMASI,
			fieldSIKAYET_EDILDI_MI,
			fieldKESIDE_YERI,
			fieldODEME_YERI,
			fieldMUNZAM_SENET_MI,
			fieldTEMINAT_MI,
			fieldSUBE_KOD_ID,
			fieldKONTROL_KIM_ID,
			fieldISLEMLER_BASLADIMI,
			fieldBANKA,
			fieldSUBE,
            fieldTAKIBE_KONULDU_MU,
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

            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("TUR", "Tür");
            dicFieldCaption.Add("SORAN_CARI", "Soran");
            dicFieldCaption.Add("KIYMETLI_EVRAK_TARAF_CARI", " Taraf");
            dicFieldCaption.Add("TARAF_TIP", "Taraf Tip");
            dicFieldCaption.Add("EVRAK_KAYIT_TARIHI", "Evrak Kayıt T.");
            dicFieldCaption.Add("EVRAK_VADE_TARIHI", "Evrak Vade T.");
            dicFieldCaption.Add("TUTAR", "Tutar");
            dicFieldCaption.Add("EVRAK_TANZIM_TARIHI", "Evrak Tanzim T.");
            dicFieldCaption.Add("NE_SEKILDE_AHZOLUNDUGU", "");
            dicFieldCaption.Add("BANKA_SUBE_KODU", "Şube Kodu");
            dicFieldCaption.Add("HESAP_NO", "Hesap No");
            dicFieldCaption.Add("CEK_NO", "Çek No");
            dicFieldCaption.Add("SORULDUGU_TARIH", "Sorulduğu T.");
            dicFieldCaption.Add("SORULMA_SONUCU", "Sorulma Sonucu");
            dicFieldCaption.Add("KARSILIK_TUTAR", "Karşılık Tutar");
            dicFieldCaption.Add("ARKASI_YAZILDI_MI", "Arkası Yazıldımı");
            dicFieldCaption.Add("SERH_ACIKLAMASI", "Şerh Açıklaması");
            dicFieldCaption.Add("SIKAYET_EDILDI_MI", "Şikayet Edildi");
            dicFieldCaption.Add("KESIDE_YERI", "Keşide Yeri");
            dicFieldCaption.Add("ODEME_YERI", "Ödeme Yeri");
            dicFieldCaption.Add("MUNZAM_SENET_MI", "Munzam Senet");
            dicFieldCaption.Add("TEMINAT_MI", "Teminat");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("ISLEMLER_BASLADIMI", "İşlemler Başladı");
            dicFieldCaption.Add("BANKA", "Banka");
            dicFieldCaption.Add("SUBE", "Şube");
            dicFieldCaption.Add("TAKIBE_KONULDU_MU", "Takibe Konuldu");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            //Inits.DovizTipGetir(rlueDoviz);

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("DovizId", InitsEx.DovizTipGetir);

            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("EVRAK_TUTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("KARSILIK_TUTAR", InitsEx.ParaBicimiAyarla);

            #endregion Add item

            return sozluk;
        }
    }
}