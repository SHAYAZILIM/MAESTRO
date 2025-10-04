using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class RaporKiymetTakdiri
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

            GridColumn colKIYMET_TAKDIRI_YAPAN1 = new GridColumn();
            colKIYMET_TAKDIRI_YAPAN1.VisibleIndex = 0;
            colKIYMET_TAKDIRI_YAPAN1.FieldName = "KIYMET_TAKDIRI_YAPAN1";
            colKIYMET_TAKDIRI_YAPAN1.Name = "colKIYMET_TAKDIRI_YAPAN1";
            colKIYMET_TAKDIRI_YAPAN1.Visible = true;

            GridColumn colKIYMET_TAKDIRI_YAPAN2 = new GridColumn();
            colKIYMET_TAKDIRI_YAPAN2.VisibleIndex = 1;
            colKIYMET_TAKDIRI_YAPAN2.FieldName = "KIYMET_TAKDIRI_YAPAN2";
            colKIYMET_TAKDIRI_YAPAN2.Name = "colKIYMET_TAKDIRI_YAPAN2";
            colKIYMET_TAKDIRI_YAPAN2.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 2;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colKIYMET_TAKDIRI_YAPAN3 = new GridColumn();
            colKIYMET_TAKDIRI_YAPAN3.VisibleIndex = 3;
            colKIYMET_TAKDIRI_YAPAN3.FieldName = "KIYMET_TAKDIRI_YAPAN3";
            colKIYMET_TAKDIRI_YAPAN3.Name = "colKIYMET_TAKDIRI_YAPAN3";
            colKIYMET_TAKDIRI_YAPAN3.Visible = true;

            GridColumn colKIYMET_TAKDIRI_YAPAN4 = new GridColumn();
            colKIYMET_TAKDIRI_YAPAN4.VisibleIndex = 4;
            colKIYMET_TAKDIRI_YAPAN4.FieldName = "KIYMET_TAKDIRI_YAPAN4";
            colKIYMET_TAKDIRI_YAPAN4.Name = "colKIYMET_TAKDIRI_YAPAN4";
            colKIYMET_TAKDIRI_YAPAN4.Visible = true;

            GridColumn colBIRIM = new GridColumn();
            colBIRIM.VisibleIndex = 5;
            colBIRIM.FieldName = "BIRIM";
            colBIRIM.Name = "colBIRIM";
            colBIRIM.Visible = true;

            GridColumn colDEGERIN_KESINLESME_TARIHI = new GridColumn();
            colDEGERIN_KESINLESME_TARIHI.VisibleIndex = 6;
            colDEGERIN_KESINLESME_TARIHI.FieldName = "DEGERIN_KESINLESME_TARIHI";
            colDEGERIN_KESINLESME_TARIHI.Name = "colDEGERIN_KESINLESME_TARIHI";
            colDEGERIN_KESINLESME_TARIHI.Visible = true;

            GridColumn colRAPOR_TARIHI1 = new GridColumn();
            colRAPOR_TARIHI1.VisibleIndex = 7;
            colRAPOR_TARIHI1.FieldName = "RAPOR_TARIHI1";
            colRAPOR_TARIHI1.Name = "colRAPOR_TARIHI1";
            colRAPOR_TARIHI1.Visible = true;

            GridColumn colRAPOR_TARIHI2 = new GridColumn();
            colRAPOR_TARIHI2.VisibleIndex = 8;
            colRAPOR_TARIHI2.FieldName = "RAPOR_TARIHI2";
            colRAPOR_TARIHI2.Name = "colRAPOR_TARIHI2";
            colRAPOR_TARIHI2.Visible = true;

            GridColumn colSIKAYET_VARMI = new GridColumn();
            colSIKAYET_VARMI.VisibleIndex = 9;
            colSIKAYET_VARMI.FieldName = "SIKAYET_VARMI";
            colSIKAYET_VARMI.Name = "colSIKAYET_VARMI";
            colSIKAYET_VARMI.Visible = true;

            GridColumn colKAYIT_TARIHI = new GridColumn();
            colKAYIT_TARIHI.VisibleIndex = 10;
            colKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
            colKAYIT_TARIHI.Visible = true;

            GridColumn colITIRAZ_VARMI = new GridColumn();
            colITIRAZ_VARMI.VisibleIndex = 11;
            colITIRAZ_VARMI.FieldName = "ITIRAZ_VARMI";
            colITIRAZ_VARMI.Name = "colITIRAZ_VARMI";
            colITIRAZ_VARMI.Visible = true;

            GridColumn colITIRAZ_SONUCU = new GridColumn();
            colITIRAZ_SONUCU.VisibleIndex = 12;
            colITIRAZ_SONUCU.FieldName = "ITIRAZ_SONUCU";
            colITIRAZ_SONUCU.Name = "colITIRAZ_SONUCU";
            colITIRAZ_SONUCU.Visible = true;

            GridColumn colKATEGORI = new GridColumn();
            colKATEGORI.VisibleIndex = 13;
            colKATEGORI.FieldName = "KATEGORI";
            colKATEGORI.Name = "colKATEGORI";
            colKATEGORI.Visible = true;

            GridColumn colTUR = new GridColumn();
            colTUR.VisibleIndex = 14;
            colTUR.FieldName = "TUR";
            colTUR.Name = "colTUR";
            colTUR.Visible = true;

            GridColumn colCINS = new GridColumn();
            colCINS.VisibleIndex = 15;
            colCINS.FieldName = "CINS";
            colCINS.Name = "colCINS";
            colCINS.Visible = true;

            GridColumn colKIYMET_TAKDIRI_TEBLIG_TARIHI = new GridColumn();
            colKIYMET_TAKDIRI_TEBLIG_TARIHI.VisibleIndex = 16;
            colKIYMET_TAKDIRI_TEBLIG_TARIHI.FieldName = "KIYMET_TAKDIRI_TEBLIG_TARIHI";
            colKIYMET_TAKDIRI_TEBLIG_TARIHI.Name = "colKIYMET_TAKDIRI_TEBLIG_TARIHI";
            colKIYMET_TAKDIRI_TEBLIG_TARIHI.Visible = true;

            GridColumn colKIYMET_TAKDIRI_AVANS_TARIHI = new GridColumn();
            colKIYMET_TAKDIRI_AVANS_TARIHI.VisibleIndex = 17;
            colKIYMET_TAKDIRI_AVANS_TARIHI.FieldName = "KIYMET_TAKDIRI_AVANS_TARIHI";
            colKIYMET_TAKDIRI_AVANS_TARIHI.Name = "colKIYMET_TAKDIRI_AVANS_TARIHI";
            colKIYMET_TAKDIRI_AVANS_TARIHI.Visible = true;

            GridColumn colKESINLESEN_KIYMET_TAKDIRININ_DEGERI = new GridColumn();
            colKESINLESEN_KIYMET_TAKDIRININ_DEGERI.VisibleIndex = 18;
            colKESINLESEN_KIYMET_TAKDIRININ_DEGERI.FieldName = "KESINLESEN_KIYMET_TAKDIRININ_DEGERI";
            colKESINLESEN_KIYMET_TAKDIRININ_DEGERI.Name = "colKESINLESEN_KIYMET_TAKDIRININ_DEGERI";
            colKESINLESEN_KIYMET_TAKDIRININ_DEGERI.Visible = true;

            GridColumn colKESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID = new GridColumn();
            colKESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID.VisibleIndex = 19;
            colKESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID.FieldName = "KESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID";
            colKESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID.Name = "colKESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID";
            colKESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 20;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 21;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colHACIZLI_MAL_ADET = new GridColumn();
            colHACIZLI_MAL_ADET.VisibleIndex = 22;
            colHACIZLI_MAL_ADET.FieldName = "HACIZLI_MAL_ADET";
            colHACIZLI_MAL_ADET.Name = "colHACIZLI_MAL_ADET";
            colHACIZLI_MAL_ADET.Visible = true;

            GridColumn colTIPI = new GridColumn();
            colTIPI.VisibleIndex = 23;
            colTIPI.FieldName = "TIPI";
            colTIPI.Name = "colTIPI";
            colTIPI.Visible = true;

            GridColumn colEKSPERTIZ_KAYDI_MI = new GridColumn();
            colEKSPERTIZ_KAYDI_MI.VisibleIndex = 24;
            colEKSPERTIZ_KAYDI_MI.FieldName = "EKSPERTIZ_KAYDI_MI";
            colEKSPERTIZ_KAYDI_MI.Name = "colEKSPERTIZ_KAYDI_MI";
            colEKSPERTIZ_KAYDI_MI.Visible = true;

            GridColumn colHACIZLI_MAL_MIKTARI_BIRIM_FIYATI = new GridColumn();
            colHACIZLI_MAL_MIKTARI_BIRIM_FIYATI.VisibleIndex = 25;
            colHACIZLI_MAL_MIKTARI_BIRIM_FIYATI.FieldName = "HACIZLI_MAL_MIKTARI_BIRIM_FIYATI";
            colHACIZLI_MAL_MIKTARI_BIRIM_FIYATI.Name = "colHACIZLI_MAL_MIKTARI_BIRIM_FIYATI";
            colHACIZLI_MAL_MIKTARI_BIRIM_FIYATI.Visible = true;

            GridColumn colHACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID = new GridColumn();
            colHACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID.VisibleIndex = 26;
            colHACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID.FieldName = "HACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID";
            colHACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID.Name = "colHACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID";
            colHACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID.Visible = true;

            GridColumn colHACIZLI_MAL_MIKTARI = new GridColumn();
            colHACIZLI_MAL_MIKTARI.VisibleIndex = 27;
            colHACIZLI_MAL_MIKTARI.FieldName = "HACIZLI_MAL_MIKTARI";
            colHACIZLI_MAL_MIKTARI.Name = "colHACIZLI_MAL_MIKTARI";
            colHACIZLI_MAL_MIKTARI.Visible = true;

            GridColumn colHACIZLI_MAL_MIKTARI_DOVIZ_ID = new GridColumn();
            colHACIZLI_MAL_MIKTARI_DOVIZ_ID.VisibleIndex = 28;
            colHACIZLI_MAL_MIKTARI_DOVIZ_ID.FieldName = "HACIZLI_MAL_MIKTARI_DOVIZ_ID";
            colHACIZLI_MAL_MIKTARI_DOVIZ_ID.Name = "colHACIZLI_MAL_MIKTARI_DOVIZ_ID";
            colHACIZLI_MAL_MIKTARI_DOVIZ_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colKIYMET_TAKDIRI_YAPAN1,
			colKIYMET_TAKDIRI_YAPAN2,
			colID,
			colKIYMET_TAKDIRI_YAPAN3,
			colKIYMET_TAKDIRI_YAPAN4,
			colBIRIM,
			colDEGERIN_KESINLESME_TARIHI,
			colRAPOR_TARIHI1,
			colRAPOR_TARIHI2,
			colSIKAYET_VARMI,
			colKAYIT_TARIHI,
			colITIRAZ_VARMI,
			colITIRAZ_SONUCU,
			colKATEGORI,
			colTUR,
			colCINS,
			colKIYMET_TAKDIRI_TEBLIG_TARIHI,
			colKIYMET_TAKDIRI_AVANS_TARIHI,
			colKESINLESEN_KIYMET_TAKDIRININ_DEGERI,
			colKESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
			colHACIZLI_MAL_ADET,
			colTIPI,
			colEKSPERTIZ_KAYDI_MI,
			colHACIZLI_MAL_MIKTARI_BIRIM_FIYATI,
			colHACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID,
			colHACIZLI_MAL_MIKTARI,
			colHACIZLI_MAL_MIKTARI_DOVIZ_ID,
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

            PivotGridField fieldKIYMET_TAKDIRI_YAPAN1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKIYMET_TAKDIRI_YAPAN1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKIYMET_TAKDIRI_YAPAN1.AreaIndex = 0;
            fieldKIYMET_TAKDIRI_YAPAN1.FieldName = "KIYMET_TAKDIRI_YAPAN1";
            fieldKIYMET_TAKDIRI_YAPAN1.Name = "fieldKIYMET_TAKDIRI_YAPAN1";
            fieldKIYMET_TAKDIRI_YAPAN1.Visible = false;

            PivotGridField fieldKIYMET_TAKDIRI_YAPAN2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKIYMET_TAKDIRI_YAPAN2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKIYMET_TAKDIRI_YAPAN2.AreaIndex = 1;
            fieldKIYMET_TAKDIRI_YAPAN2.FieldName = "KIYMET_TAKDIRI_YAPAN2";
            fieldKIYMET_TAKDIRI_YAPAN2.Name = "fieldKIYMET_TAKDIRI_YAPAN2";
            fieldKIYMET_TAKDIRI_YAPAN2.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 2;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldKIYMET_TAKDIRI_YAPAN3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKIYMET_TAKDIRI_YAPAN3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKIYMET_TAKDIRI_YAPAN3.AreaIndex = 3;
            fieldKIYMET_TAKDIRI_YAPAN3.FieldName = "KIYMET_TAKDIRI_YAPAN3";
            fieldKIYMET_TAKDIRI_YAPAN3.Name = "fieldKIYMET_TAKDIRI_YAPAN3";
            fieldKIYMET_TAKDIRI_YAPAN3.Visible = false;

            PivotGridField fieldKIYMET_TAKDIRI_YAPAN4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKIYMET_TAKDIRI_YAPAN4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKIYMET_TAKDIRI_YAPAN4.AreaIndex = 4;
            fieldKIYMET_TAKDIRI_YAPAN4.FieldName = "KIYMET_TAKDIRI_YAPAN4";
            fieldKIYMET_TAKDIRI_YAPAN4.Name = "fieldKIYMET_TAKDIRI_YAPAN4";
            fieldKIYMET_TAKDIRI_YAPAN4.Visible = false;

            PivotGridField fieldBIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM.AreaIndex = 5;
            fieldBIRIM.FieldName = "BIRIM";
            fieldBIRIM.Name = "fieldBIRIM";
            fieldBIRIM.Visible = false;

            PivotGridField fieldDEGERIN_KESINLESME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDEGERIN_KESINLESME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDEGERIN_KESINLESME_TARIHI.AreaIndex = 6;
            fieldDEGERIN_KESINLESME_TARIHI.FieldName = "DEGERIN_KESINLESME_TARIHI";
            fieldDEGERIN_KESINLESME_TARIHI.Name = "fieldDEGERIN_KESINLESME_TARIHI";
            fieldDEGERIN_KESINLESME_TARIHI.Visible = false;

            PivotGridField fieldRAPOR_TARIHI1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRAPOR_TARIHI1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRAPOR_TARIHI1.AreaIndex = 7;
            fieldRAPOR_TARIHI1.FieldName = "RAPOR_TARIHI1";
            fieldRAPOR_TARIHI1.Name = "fieldRAPOR_TARIHI1";
            fieldRAPOR_TARIHI1.Visible = false;

            PivotGridField fieldRAPOR_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRAPOR_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRAPOR_TARIHI2.AreaIndex = 8;
            fieldRAPOR_TARIHI2.FieldName = "RAPOR_TARIHI2";
            fieldRAPOR_TARIHI2.Name = "fieldRAPOR_TARIHI2";
            fieldRAPOR_TARIHI2.Visible = false;

            PivotGridField fieldSIKAYET_VARMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSIKAYET_VARMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSIKAYET_VARMI.AreaIndex = 9;
            fieldSIKAYET_VARMI.FieldName = "SIKAYET_VARMI";
            fieldSIKAYET_VARMI.Name = "fieldSIKAYET_VARMI";
            fieldSIKAYET_VARMI.Visible = false;

            PivotGridField fieldKAYIT_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAYIT_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAYIT_TARIHI.AreaIndex = 10;
            fieldKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            fieldKAYIT_TARIHI.Name = "fieldKAYIT_TARIHI";
            fieldKAYIT_TARIHI.Visible = false;

            PivotGridField fieldITIRAZ_VARMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldITIRAZ_VARMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldITIRAZ_VARMI.AreaIndex = 11;
            fieldITIRAZ_VARMI.FieldName = "ITIRAZ_VARMI";
            fieldITIRAZ_VARMI.Name = "fieldITIRAZ_VARMI";
            fieldITIRAZ_VARMI.Visible = false;

            PivotGridField fieldITIRAZ_SONUCU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldITIRAZ_SONUCU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldITIRAZ_SONUCU.AreaIndex = 12;
            fieldITIRAZ_SONUCU.FieldName = "ITIRAZ_SONUCU";
            fieldITIRAZ_SONUCU.Name = "fieldITIRAZ_SONUCU";
            fieldITIRAZ_SONUCU.Visible = false;

            PivotGridField fieldKATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKATEGORI.AreaIndex = 13;
            fieldKATEGORI.FieldName = "KATEGORI";
            fieldKATEGORI.Name = "fieldKATEGORI";
            fieldKATEGORI.Visible = false;

            PivotGridField fieldTUR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUR.AreaIndex = 14;
            fieldTUR.FieldName = "TUR";
            fieldTUR.Name = "fieldTUR";
            fieldTUR.Visible = false;

            PivotGridField fieldCINS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCINS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCINS.AreaIndex = 15;
            fieldCINS.FieldName = "CINS";
            fieldCINS.Name = "fieldCINS";
            fieldCINS.Visible = false;

            PivotGridField fieldKIYMET_TAKDIRI_TEBLIG_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKIYMET_TAKDIRI_TEBLIG_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKIYMET_TAKDIRI_TEBLIG_TARIHI.AreaIndex = 16;
            fieldKIYMET_TAKDIRI_TEBLIG_TARIHI.FieldName = "KIYMET_TAKDIRI_TEBLIG_TARIHI";
            fieldKIYMET_TAKDIRI_TEBLIG_TARIHI.Name = "fieldKIYMET_TAKDIRI_TEBLIG_TARIHI";
            fieldKIYMET_TAKDIRI_TEBLIG_TARIHI.Visible = false;

            PivotGridField fieldKIYMET_TAKDIRI_AVANS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKIYMET_TAKDIRI_AVANS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKIYMET_TAKDIRI_AVANS_TARIHI.AreaIndex = 17;
            fieldKIYMET_TAKDIRI_AVANS_TARIHI.FieldName = "KIYMET_TAKDIRI_AVANS_TARIHI";
            fieldKIYMET_TAKDIRI_AVANS_TARIHI.Name = "fieldKIYMET_TAKDIRI_AVANS_TARIHI";
            fieldKIYMET_TAKDIRI_AVANS_TARIHI.Visible = false;

            PivotGridField fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI.AreaIndex = 18;
            fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI.FieldName = "KESINLESEN_KIYMET_TAKDIRININ_DEGERI";
            fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI.Name = "fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI";
            fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI.Visible = false;

            PivotGridField fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID.AreaIndex = 19;
            fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID.FieldName = "KESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID";
            fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID.Name = "fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID";
            fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 20;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 21;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldHACIZLI_MAL_ADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_ADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_ADET.AreaIndex = 22;
            fieldHACIZLI_MAL_ADET.FieldName = "HACIZLI_MAL_ADET";
            fieldHACIZLI_MAL_ADET.Name = "fieldHACIZLI_MAL_ADET";
            fieldHACIZLI_MAL_ADET.Visible = false;

            PivotGridField fieldTIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTIPI.AreaIndex = 23;
            fieldTIPI.FieldName = "TIPI";
            fieldTIPI.Name = "fieldTIPI";
            fieldTIPI.Visible = false;

            PivotGridField fieldEKSPERTIZ_KAYDI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldEKSPERTIZ_KAYDI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldEKSPERTIZ_KAYDI_MI.AreaIndex = 24;
            fieldEKSPERTIZ_KAYDI_MI.FieldName = "EKSPERTIZ_KAYDI_MI";
            fieldEKSPERTIZ_KAYDI_MI.Name = "fieldEKSPERTIZ_KAYDI_MI";
            fieldEKSPERTIZ_KAYDI_MI.Visible = false;

            PivotGridField fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI.AreaIndex = 25;
            fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI.FieldName = "HACIZLI_MAL_MIKTARI_BIRIM_FIYATI";
            fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI.Name = "fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI";
            fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI.Visible = false;

            PivotGridField fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID.AreaIndex = 26;
            fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID.FieldName = "HACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID";
            fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID.Name = "fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID";
            fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldHACIZLI_MAL_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_MIKTARI.AreaIndex = 27;
            fieldHACIZLI_MAL_MIKTARI.FieldName = "HACIZLI_MAL_MIKTARI";
            fieldHACIZLI_MAL_MIKTARI.Name = "fieldHACIZLI_MAL_MIKTARI";
            fieldHACIZLI_MAL_MIKTARI.Visible = false;

            PivotGridField fieldHACIZLI_MAL_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_MIKTARI_DOVIZ_ID.AreaIndex = 28;
            fieldHACIZLI_MAL_MIKTARI_DOVIZ_ID.FieldName = "HACIZLI_MAL_MIKTARI_DOVIZ_ID";
            fieldHACIZLI_MAL_MIKTARI_DOVIZ_ID.Name = "fieldHACIZLI_MAL_MIKTARI_DOVIZ_ID";
            fieldHACIZLI_MAL_MIKTARI_DOVIZ_ID.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldKIYMET_TAKDIRI_YAPAN1,
			fieldKIYMET_TAKDIRI_YAPAN2,
			fieldID,
			fieldKIYMET_TAKDIRI_YAPAN3,
			fieldKIYMET_TAKDIRI_YAPAN4,
			fieldBIRIM,
			fieldDEGERIN_KESINLESME_TARIHI,
			fieldRAPOR_TARIHI1,
			fieldRAPOR_TARIHI2,
			fieldSIKAYET_VARMI,
			fieldKAYIT_TARIHI,
			fieldITIRAZ_VARMI,
			fieldITIRAZ_SONUCU,
			fieldKATEGORI,
			fieldTUR,
			fieldCINS,
			fieldKIYMET_TAKDIRI_TEBLIG_TARIHI,
			fieldKIYMET_TAKDIRI_AVANS_TARIHI,
			fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI,
			fieldKESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldHACIZLI_MAL_ADET,
			fieldTIPI,
			fieldEKSPERTIZ_KAYDI_MI,
			fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI,
			fieldHACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID,
			fieldHACIZLI_MAL_MIKTARI,
			fieldHACIZLI_MAL_MIKTARI_DOVIZ_ID,
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

            dicFieldCaption.Add("KIYMET_TAKDIRI_YAPAN1", "BilirKişi1");
            dicFieldCaption.Add("KIYMET_TAKDIRI_YAPAN2", "BilirKişi2");
            dicFieldCaption.Add("ID", "Dosya Sayısı");
            dicFieldCaption.Add("KIYMET_TAKDIRI_YAPAN3", "BilirKişi3");
            dicFieldCaption.Add("KIYMET_TAKDIRI_YAPAN4", "BilirKişi4");
            dicFieldCaption.Add("BIRIM", "Birim");
            dicFieldCaption.Add("DEGERIN_KESINLESME_TARIHI", "Değerin Kesinleşme T");
            dicFieldCaption.Add("RAPOR_TARIHI1", "Rapor T1");
            dicFieldCaption.Add("RAPOR_TARIHI2", "Rapor T2");
            dicFieldCaption.Add("SIKAYET_VARMI", "Şikayet Varmı");
            dicFieldCaption.Add("KAYIT_TARIHI", "Kayıt T");
            dicFieldCaption.Add("ITIRAZ_VARMI", "İtiraz Varmı");
            dicFieldCaption.Add("ITIRAZ_SONUCU", "İtiraz Sonucu");
            dicFieldCaption.Add("KATEGORI", "Kategori");
            dicFieldCaption.Add("TUR", "Tür");
            dicFieldCaption.Add("CINS", "Cins");
            dicFieldCaption.Add("KIYMET_TAKDIRI_TEBLIG_TARIHI", "Tebliğ T");
            dicFieldCaption.Add("KIYMET_TAKDIRI_AVANS_TARIHI", "Avans T");
            dicFieldCaption.Add("KESINLESEN_KIYMET_TAKDIRININ_DEGERI", "Kesinleşme Değeri");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("HACIZLI_MAL_ADET", "Mal Adet");
            dicFieldCaption.Add("TIPI", "Tipi");
            dicFieldCaption.Add("EKSPERTIZ_KAYDI_MI", "Expertiz");
            dicFieldCaption.Add("HACIZLI_MAL_MIKTARI_BIRIM_FIYATI", "Mal Miktarı Brm");
            dicFieldCaption.Add("HACIZLI_MAL_MIKTARI", "Mal Miktarı");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

            // Inits.DovizTipGetir(rlueDoviz);

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("DovizId", InitsEx.DovizTipGetir);

            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("KESINLESEN_KIYMET_TAKDIRININ_DEGERI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("KESINLESEN_KIYMET_TAKDIRININ_DEGERI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("HACIZLI_MAL_MIKTARI_BIRIM_FIYATI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("HACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("HACIZLI_MAL_MIKTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("HACIZLI_MAL_MIKTARI_DOVIZ_ID", InitsEx.DovizTipGetir);

            #endregion Add item

            return sozluk;
        }
    }
}