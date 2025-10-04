using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class HacizChildIstirak
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

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 0;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 1;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 2;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 3;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 4;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 5;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colICRA_ADLIYE = new GridColumn();
            colICRA_ADLIYE.VisibleIndex = 6;
            colICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            colICRA_ADLIYE.Name = "colICRA_ADLIYE";
            colICRA_ADLIYE.Visible = true;

            GridColumn colICRA_BIRIM_NO = new GridColumn();
            colICRA_BIRIM_NO.VisibleIndex = 7;
            colICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Name = "colICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 8;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colTALEP_ADI = new GridColumn();
            colTALEP_ADI.VisibleIndex = 9;
            colTALEP_ADI.FieldName = "TALEP_ADI";
            colTALEP_ADI.Name = "colTALEP_ADI";
            colTALEP_ADI.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 10;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 11;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 12;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            GridColumn colFORM_TIPI = new GridColumn();
            colFORM_TIPI.VisibleIndex = 13;
            colFORM_TIPI.FieldName = "FORM_TIPI";
            colFORM_TIPI.Name = "colFORM_TIPI";
            colFORM_TIPI.Visible = true;

            GridColumn colISTIRAK_HACIZ_TARIHI = new GridColumn();
            colISTIRAK_HACIZ_TARIHI.VisibleIndex = 14;
            colISTIRAK_HACIZ_TARIHI.FieldName = "ISTIRAK_HACIZ_TARIHI";
            colISTIRAK_HACIZ_TARIHI.Name = "colISTIRAK_HACIZ_TARIHI";
            colISTIRAK_HACIZ_TARIHI.Visible = true;

            GridColumn colISTIRAK_HACIZ_SAATI = new GridColumn();
            colISTIRAK_HACIZ_SAATI.VisibleIndex = 15;
            colISTIRAK_HACIZ_SAATI.FieldName = "ISTIRAK_HACIZ_SAATI";
            colISTIRAK_HACIZ_SAATI.Name = "colISTIRAK_HACIZ_SAATI";
            colISTIRAK_HACIZ_SAATI.Visible = true;

            GridColumn colSIRA_NO = new GridColumn();
            colSIRA_NO.VisibleIndex = 16;
            colSIRA_NO.FieldName = "SIRA_NO";
            colSIRA_NO.Name = "colSIRA_NO";
            colSIRA_NO.Visible = true;

            GridColumn colISTIRAK_ESAS_NO = new GridColumn();
            colISTIRAK_ESAS_NO.VisibleIndex = 17;
            colISTIRAK_ESAS_NO.FieldName = "ISTIRAK_ESAS_NO";
            colISTIRAK_ESAS_NO.Name = "colISTIRAK_ESAS_NO";
            colISTIRAK_ESAS_NO.Visible = true;

            GridColumn colISTIRAK_MIKTAR = new GridColumn();
            colISTIRAK_MIKTAR.VisibleIndex = 18;
            colISTIRAK_MIKTAR.FieldName = "ISTIRAK_MIKTAR";
            colISTIRAK_MIKTAR.Name = "colISTIRAK_MIKTAR";
            colISTIRAK_MIKTAR.Visible = true;

            GridColumn colISTIRAK_TUTARI_DOVIZ_ID = new GridColumn();
            colISTIRAK_TUTARI_DOVIZ_ID.VisibleIndex = 19;
            colISTIRAK_TUTARI_DOVIZ_ID.FieldName = "ISTIRAK_TUTARI_DOVIZ_ID";
            colISTIRAK_TUTARI_DOVIZ_ID.Name = "colISTIRAK_TUTARI_DOVIZ_ID";
            colISTIRAK_TUTARI_DOVIZ_ID.Visible = true;

            GridColumn colHACIZ_ISTIRAK_TALEP_TARIHI = new GridColumn();
            colHACIZ_ISTIRAK_TALEP_TARIHI.VisibleIndex = 20;
            colHACIZ_ISTIRAK_TALEP_TARIHI.FieldName = "HACIZ_ISTIRAK_TALEP_TARIHI";
            colHACIZ_ISTIRAK_TALEP_TARIHI.Name = "colHACIZ_ISTIRAK_TALEP_TARIHI";
            colHACIZ_ISTIRAK_TALEP_TARIHI.Visible = true;

            GridColumn colISTIRAK_ADLIYE = new GridColumn();
            colISTIRAK_ADLIYE.VisibleIndex = 21;
            colISTIRAK_ADLIYE.FieldName = "ISTIRAK_ADLIYE";
            colISTIRAK_ADLIYE.Name = "colISTIRAK_ADLIYE";
            colISTIRAK_ADLIYE.Visible = true;

            GridColumn colISTIRAK_ADLI_BIRIM_NO = new GridColumn();
            colISTIRAK_ADLI_BIRIM_NO.VisibleIndex = 22;
            colISTIRAK_ADLI_BIRIM_NO.FieldName = "ISTIRAK_ADLI_BIRIM_NO";
            colISTIRAK_ADLI_BIRIM_NO.Name = "colISTIRAK_ADLI_BIRIM_NO";
            colISTIRAK_ADLI_BIRIM_NO.Visible = true;

            GridColumn colISTIRAK_ISTEYEN = new GridColumn();
            colISTIRAK_ISTEYEN.VisibleIndex = 23;
            colISTIRAK_ISTEYEN.FieldName = "ISTIRAK_ISTEYEN";
            colISTIRAK_ISTEYEN.Name = "colISTIRAK_ISTEYEN";
            colISTIRAK_ISTEYEN.Visible = true;

            GridColumn colHACIZLI_MAL_KATEGORI = new GridColumn();
            colHACIZLI_MAL_KATEGORI.VisibleIndex = 24;
            colHACIZLI_MAL_KATEGORI.FieldName = "HACIZLI_MAL_KATEGORI";
            colHACIZLI_MAL_KATEGORI.Name = "colHACIZLI_MAL_KATEGORI";
            colHACIZLI_MAL_KATEGORI.Visible = true;

            GridColumn colHACIZLI_MAL_TUR = new GridColumn();
            colHACIZLI_MAL_TUR.VisibleIndex = 25;
            colHACIZLI_MAL_TUR.FieldName = "HACIZLI_MAL_TUR";
            colHACIZLI_MAL_TUR.Name = "colHACIZLI_MAL_TUR";
            colHACIZLI_MAL_TUR.Visible = true;

            GridColumn colHACIZLI_MAL_CINS = new GridColumn();
            colHACIZLI_MAL_CINS.VisibleIndex = 26;
            colHACIZLI_MAL_CINS.FieldName = "HACIZLI_MAL_CINS";
            colHACIZLI_MAL_CINS.Name = "colHACIZLI_MAL_CINS";
            colHACIZLI_MAL_CINS.Visible = true;

            GridColumn colMAL_ADET_BIRIM = new GridColumn();
            colMAL_ADET_BIRIM.VisibleIndex = 27;
            colMAL_ADET_BIRIM.FieldName = "MAL_ADET_BIRIM";
            colMAL_ADET_BIRIM.Name = "colMAL_ADET_BIRIM";
            colMAL_ADET_BIRIM.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 28;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colTAKIP_EDEN,
			colTAKIP_EDILEN,
			colIZLEYEN,
			colSORUMLU,
			colFOY_NO,
			colDURUM,
			colICRA_ADLIYE,
			colICRA_BIRIM_NO,
			colESAS_NO,
			colTALEP_ADI,
			colSUBE_KOD_ID,
			colKONTROL_KIM_ID,
			colBOLUM,
			colFORM_TIPI,
			colISTIRAK_HACIZ_TARIHI,
			colISTIRAK_HACIZ_SAATI,
			colSIRA_NO,
			colISTIRAK_ESAS_NO,
			colISTIRAK_MIKTAR,
			colISTIRAK_TUTARI_DOVIZ_ID,
			colHACIZ_ISTIRAK_TALEP_TARIHI,
			colISTIRAK_ADLIYE,
			colISTIRAK_ADLI_BIRIM_NO,
			colISTIRAK_ISTEYEN,
			colHACIZLI_MAL_KATEGORI,
			colHACIZLI_MAL_TUR,
			colHACIZLI_MAL_CINS,
			colMAL_ADET_BIRIM,
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

        public PivotGridField[] GetPivotFields()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN.AreaIndex = 0;
            fieldTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            fieldTAKIP_EDEN.Name = "fieldTAKIP_EDEN";
            fieldTAKIP_EDEN.Visible = false;

            PivotGridField fieldTAKIP_EDILEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN.AreaIndex = 1;
            fieldTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            fieldTAKIP_EDILEN.Name = "fieldTAKIP_EDILEN";
            fieldTAKIP_EDILEN.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 2;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 3;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 4;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 5;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 6;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 7;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 8;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 9;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 10;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 11;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 12;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 13;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldISTIRAK_HACIZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIRAK_HACIZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIRAK_HACIZ_TARIHI.AreaIndex = 14;
            fieldISTIRAK_HACIZ_TARIHI.FieldName = "ISTIRAK_HACIZ_TARIHI";
            fieldISTIRAK_HACIZ_TARIHI.Name = "fieldISTIRAK_HACIZ_TARIHI";
            fieldISTIRAK_HACIZ_TARIHI.Visible = false;

            PivotGridField fieldISTIRAK_HACIZ_SAATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIRAK_HACIZ_SAATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIRAK_HACIZ_SAATI.AreaIndex = 15;
            fieldISTIRAK_HACIZ_SAATI.FieldName = "ISTIRAK_HACIZ_SAATI";
            fieldISTIRAK_HACIZ_SAATI.Name = "fieldISTIRAK_HACIZ_SAATI";
            fieldISTIRAK_HACIZ_SAATI.Visible = false;

            PivotGridField fieldSIRA_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSIRA_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSIRA_NO.AreaIndex = 16;
            fieldSIRA_NO.FieldName = "SIRA_NO";
            fieldSIRA_NO.Name = "fieldSIRA_NO";
            fieldSIRA_NO.Visible = false;

            PivotGridField fieldISTIRAK_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIRAK_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIRAK_ESAS_NO.AreaIndex = 17;
            fieldISTIRAK_ESAS_NO.FieldName = "ISTIRAK_ESAS_NO";
            fieldISTIRAK_ESAS_NO.Name = "fieldISTIRAK_ESAS_NO";
            fieldISTIRAK_ESAS_NO.Visible = false;

            PivotGridField fieldISTIRAK_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIRAK_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIRAK_MIKTAR.AreaIndex = 18;
            fieldISTIRAK_MIKTAR.FieldName = "ISTIRAK_MIKTAR";
            fieldISTIRAK_MIKTAR.Name = "fieldISTIRAK_MIKTAR";
            fieldISTIRAK_MIKTAR.Visible = false;

            PivotGridField fieldISTIRAK_TUTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIRAK_TUTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIRAK_TUTARI_DOVIZ_ID.AreaIndex = 19;
            fieldISTIRAK_TUTARI_DOVIZ_ID.FieldName = "ISTIRAK_TUTARI_DOVIZ_ID";
            fieldISTIRAK_TUTARI_DOVIZ_ID.Name = "fieldISTIRAK_TUTARI_DOVIZ_ID";
            fieldISTIRAK_TUTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldHACIZ_ISTIRAK_TALEP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZ_ISTIRAK_TALEP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZ_ISTIRAK_TALEP_TARIHI.AreaIndex = 20;
            fieldHACIZ_ISTIRAK_TALEP_TARIHI.FieldName = "HACIZ_ISTIRAK_TALEP_TARIHI";
            fieldHACIZ_ISTIRAK_TALEP_TARIHI.Name = "fieldHACIZ_ISTIRAK_TALEP_TARIHI";
            fieldHACIZ_ISTIRAK_TALEP_TARIHI.Visible = false;

            PivotGridField fieldISTIRAK_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIRAK_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIRAK_ADLIYE.AreaIndex = 21;
            fieldISTIRAK_ADLIYE.FieldName = "ISTIRAK_ADLIYE";
            fieldISTIRAK_ADLIYE.Name = "fieldISTIRAK_ADLIYE";
            fieldISTIRAK_ADLIYE.Visible = false;

            PivotGridField fieldISTIRAK_ADLI_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIRAK_ADLI_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIRAK_ADLI_BIRIM_NO.AreaIndex = 22;
            fieldISTIRAK_ADLI_BIRIM_NO.FieldName = "ISTIRAK_ADLI_BIRIM_NO";
            fieldISTIRAK_ADLI_BIRIM_NO.Name = "fieldISTIRAK_ADLI_BIRIM_NO";
            fieldISTIRAK_ADLI_BIRIM_NO.Visible = false;

            PivotGridField fieldISTIRAK_ISTEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIRAK_ISTEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIRAK_ISTEYEN.AreaIndex = 23;
            fieldISTIRAK_ISTEYEN.FieldName = "ISTIRAK_ISTEYEN";
            fieldISTIRAK_ISTEYEN.Name = "fieldISTIRAK_ISTEYEN";
            fieldISTIRAK_ISTEYEN.Visible = false;

            PivotGridField fieldHACIZLI_MAL_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_KATEGORI.AreaIndex = 24;
            fieldHACIZLI_MAL_KATEGORI.FieldName = "HACIZLI_MAL_KATEGORI";
            fieldHACIZLI_MAL_KATEGORI.Name = "fieldHACIZLI_MAL_KATEGORI";
            fieldHACIZLI_MAL_KATEGORI.Visible = false;

            PivotGridField fieldHACIZLI_MAL_TUR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_TUR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_TUR.AreaIndex = 25;
            fieldHACIZLI_MAL_TUR.FieldName = "HACIZLI_MAL_TUR";
            fieldHACIZLI_MAL_TUR.Name = "fieldHACIZLI_MAL_TUR";
            fieldHACIZLI_MAL_TUR.Visible = false;

            PivotGridField fieldHACIZLI_MAL_CINS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHACIZLI_MAL_CINS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHACIZLI_MAL_CINS.AreaIndex = 26;
            fieldHACIZLI_MAL_CINS.FieldName = "HACIZLI_MAL_CINS";
            fieldHACIZLI_MAL_CINS.Name = "fieldHACIZLI_MAL_CINS";
            fieldHACIZLI_MAL_CINS.Visible = false;

            PivotGridField fieldMAL_ADET_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAL_ADET_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAL_ADET_BIRIM.AreaIndex = 27;
            fieldMAL_ADET_BIRIM.FieldName = "MAL_ADET_BIRIM";
            fieldMAL_ADET_BIRIM.Name = "fieldMAL_ADET_BIRIM";
            fieldMAL_ADET_BIRIM.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 28;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldTAKIP_EDEN,
			fieldTAKIP_EDILEN,
			fieldIZLEYEN,
			fieldSORUMLU,
			fieldFOY_NO,
			fieldDURUM,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldESAS_NO,
			fieldTALEP_ADI,
			fieldSUBE_KOD_ID,
			fieldKONTROL_KIM_ID,
			fieldBOLUM,
			fieldFORM_TIPI,
			fieldISTIRAK_HACIZ_TARIHI,
			fieldISTIRAK_HACIZ_SAATI,
			fieldSIRA_NO,
			fieldISTIRAK_ESAS_NO,
			fieldISTIRAK_MIKTAR,
			fieldISTIRAK_TUTARI_DOVIZ_ID,
			fieldHACIZ_ISTIRAK_TALEP_TARIHI,
			fieldISTIRAK_ADLIYE,
			fieldISTIRAK_ADLI_BIRIM_NO,
			fieldISTIRAK_ISTEYEN,
			fieldHACIZLI_MAL_KATEGORI,
			fieldHACIZLI_MAL_TUR,
			fieldHACIZLI_MAL_CINS,
			fieldMAL_ADET_BIRIM,
			fieldID,
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

            dicFieldCaption.Add("TAKIP_EDEN", " Takip Eden");
            dicFieldCaption.Add("TAKIP_EDILEN", "Takip Edilen");
            dicFieldCaption.Add("IZLEYEN", "İzleyen");
            dicFieldCaption.Add("SORUMLU", "Sorumlu");
            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("ICRA_ADLIYE", "Adliye");
            dicFieldCaption.Add("ICRA_BIRIM_NO", "No");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("TALEP_ADI", "Talep Adı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("BOLUM", "Bölüm");
            dicFieldCaption.Add("FORM_TIPI", "Forum Tipi");
            dicFieldCaption.Add("ISTIRAK_HACIZ_TARIHI", "İştirak Haciz T");
            dicFieldCaption.Add("ISTIRAK_HACIZ_SAATI", "İştirak Haciz Saati");
            dicFieldCaption.Add("SIRA_NO", "Sıra No");
            dicFieldCaption.Add("ISTIRAK_ESAS_NO", "İştirak Esas No");
            dicFieldCaption.Add("ISTIRAK_MIKTAR", "İİştirak Miktar");
            dicFieldCaption.Add("HACIZ_ISTIRAK_TALEP_TARIHI", "İştirak Talep T");
            dicFieldCaption.Add("ISTIRAK_ADLIYE", "İştirak Adliye");
            dicFieldCaption.Add("ISTIRAK_ADLI_BIRIM_NO", "İştirak Birim No");
            dicFieldCaption.Add("ISTIRAK_ISTEYEN", "İştirak İsteyen");
            dicFieldCaption.Add("HACIZLI_MAL_KATEGORI", "Mal Kategori");
            dicFieldCaption.Add("HACIZLI_MAL_TUR", "Mal Tür");
            dicFieldCaption.Add("HACIZLI_MAL_CINS", "Mal Cins");
            dicFieldCaption.Add("MAL_ADET_BIRIM", "Mal Adet Birim");
            dicFieldCaption.Add("ID", "");

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
            sozluk.Add("KONTROL_KIM_ID", InitsEx.TarafKodu);
            sozluk.Add("ISTIRAK_MIKTAR", InitsEx.SubeKod);
            sozluk.Add("ISTIRAK_TUTARI_DOVIZ_ID", InitsEx.DovizTipGetir);

            #endregion Add item

            return sozluk;
        }
    }
}