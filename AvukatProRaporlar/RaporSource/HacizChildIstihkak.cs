using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class HacizChildIstihkak
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

            GridColumn colISTIHKAK_IDDIA_TARIHI = new GridColumn();
            colISTIHKAK_IDDIA_TARIHI.VisibleIndex = 0;
            colISTIHKAK_IDDIA_TARIHI.FieldName = "ISTIHKAK_IDDIA_TARIHI";
            colISTIHKAK_IDDIA_TARIHI.Name = "colISTIHKAK_IDDIA_TARIHI";
            colISTIHKAK_IDDIA_TARIHI.Visible = true;

            GridColumn colISTIHKAK_ADET = new GridColumn();
            colISTIHKAK_ADET.VisibleIndex = 1;
            colISTIHKAK_ADET.FieldName = "ISTIHKAK_ADET";
            colISTIHKAK_ADET.Name = "colISTIHKAK_ADET";
            colISTIHKAK_ADET.Visible = true;

            GridColumn colISTIHKAK_MIKTARI = new GridColumn();
            colISTIHKAK_MIKTARI.VisibleIndex = 2;
            colISTIHKAK_MIKTARI.FieldName = "ISTIHKAK_MIKTARI";
            colISTIHKAK_MIKTARI.Name = "colISTIHKAK_MIKTARI";
            colISTIHKAK_MIKTARI.Visible = true;

            GridColumn colISTIHKAK_MIKTARI_DOVIZ_ID = new GridColumn();
            colISTIHKAK_MIKTARI_DOVIZ_ID.VisibleIndex = 3;
            colISTIHKAK_MIKTARI_DOVIZ_ID.FieldName = "ISTIHKAK_MIKTARI_DOVIZ_ID";
            colISTIHKAK_MIKTARI_DOVIZ_ID.Name = "colISTIHKAK_MIKTARI_DOVIZ_ID";
            colISTIHKAK_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colISTIHKAK_SONUCU = new GridColumn();
            colISTIHKAK_SONUCU.VisibleIndex = 4;
            colISTIHKAK_SONUCU.FieldName = "ISTIHKAK_SONUCU";
            colISTIHKAK_SONUCU.Name = "colISTIHKAK_SONUCU";
            colISTIHKAK_SONUCU.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 5;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 6;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colISTIHKAK_IDDIASINA_ITIRAZ_TARIHI = new GridColumn();
            colISTIHKAK_IDDIASINA_ITIRAZ_TARIHI.VisibleIndex = 7;
            colISTIHKAK_IDDIASINA_ITIRAZ_TARIHI.FieldName = "ISTIHKAK_IDDIASINA_ITIRAZ_TARIHI";
            colISTIHKAK_IDDIASINA_ITIRAZ_TARIHI.Name = "colISTIHKAK_IDDIASINA_ITIRAZ_TARIHI";
            colISTIHKAK_IDDIASINA_ITIRAZ_TARIHI.Visible = true;

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 8;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 9;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 10;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 11;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 12;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 13;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 14;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colICRA_ADLIYE = new GridColumn();
            colICRA_ADLIYE.VisibleIndex = 15;
            colICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            colICRA_ADLIYE.Name = "colICRA_ADLIYE";
            colICRA_ADLIYE.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 16;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colICRA_BIRIM_NO = new GridColumn();
            colICRA_BIRIM_NO.VisibleIndex = 17;
            colICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Name = "colICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 18;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 19;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            GridColumn colISTIHKAK_IDDIA_EDEN = new GridColumn();
            colISTIHKAK_IDDIA_EDEN.VisibleIndex = 20;
            colISTIHKAK_IDDIA_EDEN.FieldName = "ISTIHKAK_IDDIA_EDEN";
            colISTIHKAK_IDDIA_EDEN.Name = "colISTIHKAK_IDDIA_EDEN";
            colISTIHKAK_IDDIA_EDEN.Visible = true;

            GridColumn colBIRIM = new GridColumn();
            colBIRIM.VisibleIndex = 21;
            colBIRIM.FieldName = "BIRIM";
            colBIRIM.Name = "colBIRIM";
            colBIRIM.Visible = true;

            GridColumn colKATEGORI = new GridColumn();
            colKATEGORI.VisibleIndex = 22;
            colKATEGORI.FieldName = "KATEGORI";
            colKATEGORI.Name = "colKATEGORI";
            colKATEGORI.Visible = true;

            GridColumn colTUR = new GridColumn();
            colTUR.VisibleIndex = 23;
            colTUR.FieldName = "TUR";
            colTUR.Name = "colTUR";
            colTUR.Visible = true;

            GridColumn colCINS = new GridColumn();
            colCINS.VisibleIndex = 24;
            colCINS.FieldName = "CINS";
            colCINS.Name = "colCINS";
            colCINS.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colISTIHKAK_IDDIA_TARIHI,
			colISTIHKAK_ADET,
			colISTIHKAK_MIKTARI,
			colISTIHKAK_MIKTARI_DOVIZ_ID,
			colISTIHKAK_SONUCU,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
			colISTIHKAK_IDDIASINA_ITIRAZ_TARIHI,
			colTAKIP_EDEN,
			colTAKIP_EDILEN,
			colIZLEYEN,
			colSORUMLU,
			colFOY_NO,
			colDURUM,
			colTAKIP_TARIHI,
			colICRA_ADLIYE,
			colGOREV,
			colICRA_BIRIM_NO,
			colESAS_NO,
			colBOLUM,
			colISTIHKAK_IDDIA_EDEN,
			colBIRIM,
			colKATEGORI,
			colTUR,
			colCINS,
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

            PivotGridField fieldISTIHKAK_IDDIA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIHKAK_IDDIA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIHKAK_IDDIA_TARIHI.AreaIndex = 0;
            fieldISTIHKAK_IDDIA_TARIHI.FieldName = "ISTIHKAK_IDDIA_TARIHI";
            fieldISTIHKAK_IDDIA_TARIHI.Name = "fieldISTIHKAK_IDDIA_TARIHI";
            fieldISTIHKAK_IDDIA_TARIHI.Visible = false;

            PivotGridField fieldISTIHKAK_ADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIHKAK_ADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIHKAK_ADET.AreaIndex = 1;
            fieldISTIHKAK_ADET.FieldName = "ISTIHKAK_ADET";
            fieldISTIHKAK_ADET.Name = "fieldISTIHKAK_ADET";
            fieldISTIHKAK_ADET.Visible = false;

            PivotGridField fieldISTIHKAK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIHKAK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIHKAK_MIKTARI.AreaIndex = 2;
            fieldISTIHKAK_MIKTARI.FieldName = "ISTIHKAK_MIKTARI";
            fieldISTIHKAK_MIKTARI.Name = "fieldISTIHKAK_MIKTARI";
            fieldISTIHKAK_MIKTARI.Visible = false;

            PivotGridField fieldISTIHKAK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIHKAK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIHKAK_MIKTARI_DOVIZ_ID.AreaIndex = 3;
            fieldISTIHKAK_MIKTARI_DOVIZ_ID.FieldName = "ISTIHKAK_MIKTARI_DOVIZ_ID";
            fieldISTIHKAK_MIKTARI_DOVIZ_ID.Name = "fieldISTIHKAK_MIKTARI_DOVIZ_ID";
            fieldISTIHKAK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldISTIHKAK_SONUCU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIHKAK_SONUCU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIHKAK_SONUCU.AreaIndex = 4;
            fieldISTIHKAK_SONUCU.FieldName = "ISTIHKAK_SONUCU";
            fieldISTIHKAK_SONUCU.Name = "fieldISTIHKAK_SONUCU";
            fieldISTIHKAK_SONUCU.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 5;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 6;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldISTIHKAK_IDDIASINA_ITIRAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIHKAK_IDDIASINA_ITIRAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIHKAK_IDDIASINA_ITIRAZ_TARIHI.AreaIndex = 7;
            fieldISTIHKAK_IDDIASINA_ITIRAZ_TARIHI.FieldName = "ISTIHKAK_IDDIASINA_ITIRAZ_TARIHI";
            fieldISTIHKAK_IDDIASINA_ITIRAZ_TARIHI.Name = "fieldISTIHKAK_IDDIASINA_ITIRAZ_TARIHI";
            fieldISTIHKAK_IDDIASINA_ITIRAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIP_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN.AreaIndex = 8;
            fieldTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            fieldTAKIP_EDEN.Name = "fieldTAKIP_EDEN";
            fieldTAKIP_EDEN.Visible = false;

            PivotGridField fieldTAKIP_EDILEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN.AreaIndex = 9;
            fieldTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            fieldTAKIP_EDILEN.Name = "fieldTAKIP_EDILEN";
            fieldTAKIP_EDILEN.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 10;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 11;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 12;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 13;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 14;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 15;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 16;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 17;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 18;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 19;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldISTIHKAK_IDDIA_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISTIHKAK_IDDIA_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISTIHKAK_IDDIA_EDEN.AreaIndex = 20;
            fieldISTIHKAK_IDDIA_EDEN.FieldName = "ISTIHKAK_IDDIA_EDEN";
            fieldISTIHKAK_IDDIA_EDEN.Name = "fieldISTIHKAK_IDDIA_EDEN";
            fieldISTIHKAK_IDDIA_EDEN.Visible = false;

            PivotGridField fieldBIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM.AreaIndex = 21;
            fieldBIRIM.FieldName = "BIRIM";
            fieldBIRIM.Name = "fieldBIRIM";
            fieldBIRIM.Visible = false;

            PivotGridField fieldKATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKATEGORI.AreaIndex = 22;
            fieldKATEGORI.FieldName = "KATEGORI";
            fieldKATEGORI.Name = "fieldKATEGORI";
            fieldKATEGORI.Visible = false;

            PivotGridField fieldTUR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUR.AreaIndex = 23;
            fieldTUR.FieldName = "TUR";
            fieldTUR.Name = "fieldTUR";
            fieldTUR.Visible = false;

            PivotGridField fieldCINS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCINS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCINS.AreaIndex = 24;
            fieldCINS.FieldName = "CINS";
            fieldCINS.Name = "fieldCINS";
            fieldCINS.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldISTIHKAK_IDDIA_TARIHI,
			fieldISTIHKAK_ADET,
			fieldISTIHKAK_MIKTARI,
			fieldISTIHKAK_MIKTARI_DOVIZ_ID,
			fieldISTIHKAK_SONUCU,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldISTIHKAK_IDDIASINA_ITIRAZ_TARIHI,
			fieldTAKIP_EDEN,
			fieldTAKIP_EDILEN,
			fieldIZLEYEN,
			fieldSORUMLU,
			fieldFOY_NO,
			fieldDURUM,
			fieldTAKIP_TARIHI,
			fieldICRA_ADLIYE,
			fieldGOREV,
			fieldICRA_BIRIM_NO,
			fieldESAS_NO,
			fieldBOLUM,
			fieldISTIHKAK_IDDIA_EDEN,
			fieldBIRIM,
			fieldKATEGORI,
			fieldTUR,
			fieldCINS,
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

            dicFieldCaption.Add("ISTIHKAK_IDDIA_TARIHI", "İstihkak İddia T");
            dicFieldCaption.Add("ISTIHKAK_ADET", "İstihkak Adet");
            dicFieldCaption.Add("ISTIHKAK_MIKTARI", "İstihkak Miktarı");
            dicFieldCaption.Add("ISTIHKAK_SONUCU", "İstihkak Sonucu");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("ISTIHKAK_IDDIASINA_ITIRAZ_TARIHI", "İstihkak İddiasına İtiraz T");
            dicFieldCaption.Add("TAKIP_EDEN", "Takip Eden");
            dicFieldCaption.Add("TAKIP_EDILEN", "Takip Edilen");
            dicFieldCaption.Add("IZLEYEN", "İzleyen");
            dicFieldCaption.Add("SORUMLU", "Sorumlu");
            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("TAKIP_TARIHI", "Takip T");
            dicFieldCaption.Add("ICRA_ADLIYE", "Adliye");
            dicFieldCaption.Add("GOREV", "Görev");
            dicFieldCaption.Add("ICRA_BIRIM_NO", "No");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("BOLUM", "Bölüm");
            dicFieldCaption.Add("ISTIHKAK_IDDIA_EDEN", "İstihkak İddia Eden");
            dicFieldCaption.Add("BIRIM", "Birim");
            dicFieldCaption.Add("KATEGORI", "Kategori");
            dicFieldCaption.Add("TUR", "Tür");
            dicFieldCaption.Add("CINS", "Cins");

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
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("ISTIHKAK_MIKTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("ISTIHKAK_MIKTARI_DOVIZ_ID", InitsEx.DovizTipGetir);

            #endregion Add item

            return sozluk;
        }
    }
}