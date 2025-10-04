using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class RapaoKrediOdemeDurumDetaylics
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

            GridColumn colAVUKATA_ODENEN_MIKTAR = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR.VisibleIndex = 0;
            colAVUKATA_ODENEN_MIKTAR.FieldName = "AVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Name = "colAVUKATA_ODENEN_MIKTAR";
            colAVUKATA_ODENEN_MIKTAR.Visible = true;

            GridColumn colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 1;
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "AVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR.VisibleIndex = 2;
            colALACAKLIYA_ODENEN_MIKTAR.FieldName = "ALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Name = "colALACAKLIYA_ODENEN_MIKTAR";
            colALACAKLIYA_ODENEN_MIKTAR.Visible = true;

            GridColumn colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.VisibleIndex = 3;
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "ALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Name = "colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR = new GridColumn();
            colSATISTAN_GELEN_MIKTAR.VisibleIndex = 4;
            colSATISTAN_GELEN_MIKTAR.FieldName = "SATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Name = "colSATISTAN_GELEN_MIKTAR";
            colSATISTAN_GELEN_MIKTAR.Visible = true;

            GridColumn colSATISTAN_GELEN_MIKTAR_DOVIZ_ID = new GridColumn();
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.VisibleIndex = 5;
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.FieldName = "SATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Name = "colSATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            colSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_NO = new GridColumn();
            colSUBE_NO.VisibleIndex = 6;
            colSUBE_NO.FieldName = "SUBE_NO";
            colSUBE_NO.Name = "colSUBE_NO";
            colSUBE_NO.Visible = true;

            GridColumn colSUBE = new GridColumn();
            colSUBE.VisibleIndex = 7;
            colSUBE.FieldName = "SUBE";
            colSUBE.Name = "colSUBE";
            colSUBE.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 8;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colIZLEYEN_AVUKAT = new GridColumn();
            colIZLEYEN_AVUKAT.VisibleIndex = 9;
            colIZLEYEN_AVUKAT.FieldName = "IZLEYEN_AVUKAT";
            colIZLEYEN_AVUKAT.Name = "colIZLEYEN_AVUKAT";
            colIZLEYEN_AVUKAT.Visible = true;

            GridColumn colSORUMLU_AVUKAT = new GridColumn();
            colSORUMLU_AVUKAT.VisibleIndex = 10;
            colSORUMLU_AVUKAT.FieldName = "SORUMLU_AVUKAT";
            colSORUMLU_AVUKAT.Name = "colSORUMLU_AVUKAT";
            colSORUMLU_AVUKAT.Visible = true;

            GridColumn colAN_REF_NO1 = new GridColumn();
            colAN_REF_NO1.VisibleIndex = 11;
            colAN_REF_NO1.FieldName = "AN_REF_NO1";
            colAN_REF_NO1.Name = "colAN_REF_NO1";
            colAN_REF_NO1.Visible = true;

            GridColumn colAN_REF_NO2 = new GridColumn();
            colAN_REF_NO2.VisibleIndex = 12;
            colAN_REF_NO2.FieldName = "AN_REF_NO2";
            colAN_REF_NO2.Name = "colAN_REF_NO2";
            colAN_REF_NO2.Visible = true;

            GridColumn colAN_REF_NO3 = new GridColumn();
            colAN_REF_NO3.VisibleIndex = 13;
            colAN_REF_NO3.FieldName = "AN_REF_NO3";
            colAN_REF_NO3.Name = "colAN_REF_NO3";
            colAN_REF_NO3.Visible = true;

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 14;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 15;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colTAKIBIN_AVUKATA_INTIKAL_TARIHI = new GridColumn();
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 16;
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "colTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colASIL_ALACAK = new GridColumn();
            colASIL_ALACAK.VisibleIndex = 17;
            colASIL_ALACAK.FieldName = "ASIL_ALACAK";
            colASIL_ALACAK.Name = "colASIL_ALACAK";
            colASIL_ALACAK.Visible = true;

            GridColumn colASIL_ALACAK_DOVIZ_ID = new GridColumn();
            colASIL_ALACAK_DOVIZ_ID.VisibleIndex = 18;
            colASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Name = "colASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Visible = true;

            GridColumn colGUNCEL_BAKİYE = new GridColumn();
            colGUNCEL_BAKİYE.VisibleIndex = 19;
            colGUNCEL_BAKİYE.FieldName = "GUNCEL_BAKİYE";
            colGUNCEL_BAKİYE.Name = "colGUNCEL_BAKİYE";
            colGUNCEL_BAKİYE.Visible = true;

            GridColumn colTOPLAM_TAHSILAT = new GridColumn();
            colTOPLAM_TAHSILAT.VisibleIndex = 20;
            colTOPLAM_TAHSILAT.FieldName = "TOPLAM_TAHSILAT";
            colTOPLAM_TAHSILAT.Name = "colTOPLAM_TAHSILAT";
            colTOPLAM_TAHSILAT.Visible = true;

            GridColumn colAYLIK_TOPLAM_TAHSILAT = new GridColumn();
            colAYLIK_TOPLAM_TAHSILAT.VisibleIndex = 21;
            colAYLIK_TOPLAM_TAHSILAT.FieldName = "AYLIK_TOPLAM_TAHSILAT";
            colAYLIK_TOPLAM_TAHSILAT.Name = "colAYLIK_TOPLAM_TAHSILAT";
            colAYLIK_TOPLAM_TAHSILAT.Visible = true;

            GridColumn colAYLIK_TOPLAM_TAHSILAT_DOVIZ_ID = new GridColumn();
            colAYLIK_TOPLAM_TAHSILAT_DOVIZ_ID.VisibleIndex = 22;
            colAYLIK_TOPLAM_TAHSILAT_DOVIZ_ID.FieldName = "AYLIK_TOPLAM_TAHSILAT_DOVIZ_ID";
            colAYLIK_TOPLAM_TAHSILAT_DOVIZ_ID.Name = "colAYLIK_TOPLAM_TAHSILAT_DOVIZ_ID";
            colAYLIK_TOPLAM_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colAYLIK_TOPLAM_MASRAF = new GridColumn();
            colAYLIK_TOPLAM_MASRAF.VisibleIndex = 23;
            colAYLIK_TOPLAM_MASRAF.FieldName = "AYLIK_TOPLAM_MASRAF";
            colAYLIK_TOPLAM_MASRAF.Name = "colAYLIK_TOPLAM_MASRAF";
            colAYLIK_TOPLAM_MASRAF.Visible = true;

            GridColumn colAYLIK_TOPLAM_MASRAF_DOVIZ_ID = new GridColumn();
            colAYLIK_TOPLAM_MASRAF_DOVIZ_ID.VisibleIndex = 24;
            colAYLIK_TOPLAM_MASRAF_DOVIZ_ID.FieldName = "AYLIK_TOPLAM_MASRAF_DOVIZ_ID";
            colAYLIK_TOPLAM_MASRAF_DOVIZ_ID.Name = "colAYLIK_TOPLAM_MASRAF_DOVIZ_ID";
            colAYLIK_TOPLAM_MASRAF_DOVIZ_ID.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT.VisibleIndex = 25;
            colFAIZE_YAPILAN_TAHSILAT.FieldName = "FAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Name = "colFAIZE_YAPILAN_TAHSILAT";
            colFAIZE_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 26;
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "FAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT.VisibleIndex = 27;
            colANA_PARAYA_YAPILAN_TAHSILAT.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Name = "colANA_PARAYA_YAPILAN_TAHSILAT";
            colANA_PARAYA_YAPILAN_TAHSILAT.Visible = true;

            GridColumn colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID = new GridColumn();
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.VisibleIndex = 28;
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 29;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 30;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 31;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 32;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 33;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colKAPAMA_TARIHI = new GridColumn();
            colKAPAMA_TARIHI.VisibleIndex = 34;
            colKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            colKAPAMA_TARIHI.Name = "colKAPAMA_TARIHI";
            colKAPAMA_TARIHI.Visible = true;

            GridColumn colRISK_MIKTARI = new GridColumn();
            colRISK_MIKTARI.VisibleIndex = 35;
            colRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            colRISK_MIKTARI.Name = "colRISK_MIKTARI";
            colRISK_MIKTARI.Visible = true;

            GridColumn colRISK_MIKTARI_DOVIZ_ID = new GridColumn();
            colRISK_MIKTARI_DOVIZ_ID.VisibleIndex = 36;
            colRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Name = "colRISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 37;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colRISKTEN_KALAN = new GridColumn();
            colRISKTEN_KALAN.VisibleIndex = 38;
            colRISKTEN_KALAN.FieldName = "RISKTEN_KALAN";
            colRISKTEN_KALAN.Name = "colRISKTEN_KALAN";
            colRISKTEN_KALAN.Visible = true;

            GridColumn colRISKTEN_KALAN_DOVIZ_ID = new GridColumn();
            colRISKTEN_KALAN_DOVIZ_ID.VisibleIndex = 39;
            colRISKTEN_KALAN_DOVIZ_ID.FieldName = "RISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Name = "colRISKTEN_KALAN_DOVIZ_ID";
            colRISKTEN_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colKALAN = new GridColumn();
            colKALAN.VisibleIndex = 40;
            colKALAN.FieldName = "KALAN";
            colKALAN.Name = "colKALAN";
            colKALAN.Visible = true;

            GridColumn colKALAN_DOVIZ_ID = new GridColumn();
            colKALAN_DOVIZ_ID.VisibleIndex = 41;
            colKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Name = "colKALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 42;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colSEGMENT_ID = new GridColumn();
            colSEGMENT_ID.VisibleIndex = 43;
            colSEGMENT_ID.FieldName = "SEGMENT_ID";
            colSEGMENT_ID.Name = "colSEGMENT_ID";
            colSEGMENT_ID.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 44;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colAVUKATA_ODENEN_MIKTAR,
			colAVUKATA_ODENEN_MIKTAR_DOVIZ_ID,
			colALACAKLIYA_ODENEN_MIKTAR,
			colALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID,
			colSATISTAN_GELEN_MIKTAR,
			colSATISTAN_GELEN_MIKTAR_DOVIZ_ID,
			colSUBE_NO,
			colSUBE,
			colKREDI_TIP,
			colIZLEYEN_AVUKAT,
			colSORUMLU_AVUKAT,
			colAN_REF_NO1,
			colAN_REF_NO2,
			colAN_REF_NO3,
			colTAKIP_EDEN,
			colTAKIP_EDILEN,
			colTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			colASIL_ALACAK,
			colASIL_ALACAK_DOVIZ_ID,
			colGUNCEL_BAKİYE,
			colTOPLAM_TAHSILAT,
			colAYLIK_TOPLAM_TAHSILAT,
			colAYLIK_TOPLAM_TAHSILAT_DOVIZ_ID,
			colAYLIK_TOPLAM_MASRAF,
			colAYLIK_TOPLAM_MASRAF_DOVIZ_ID,
			colFAIZE_YAPILAN_TAHSILAT,
			colFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID,
			colANA_PARAYA_YAPILAN_TAHSILAT,
			colANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID,
			colID,
			colFOY_NO,
			colADLIYE,
			colNO,
			colDURUM,
			colKAPAMA_TARIHI,
			colRISK_MIKTARI,
			colRISK_MIKTARI_DOVIZ_ID,
			colSUBE_KOD_ID,
			colRISKTEN_KALAN,
			colRISKTEN_KALAN_DOVIZ_ID,
			colKALAN,
			colKALAN_DOVIZ_ID,
			colKREDI_GRUP,
			colSEGMENT_ID,
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

            #endregion Column Caption
            }
            return dizi;
        }

        public PivotGridField[] GetPivotFields()
        {
            #region Field & Properties

            PivotGridField fieldAVUKATA_ODENEN_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAVUKATA_ODENEN_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAVUKATA_ODENEN_MIKTAR.AreaIndex = 0;
            fieldAVUKATA_ODENEN_MIKTAR.FieldName = "AVUKATA_ODENEN_MIKTAR";
            fieldAVUKATA_ODENEN_MIKTAR.Name = "fieldAVUKATA_ODENEN_MIKTAR";
            fieldAVUKATA_ODENEN_MIKTAR.Visible = false;

            PivotGridField fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.AreaIndex = 1;
            fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "AVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Name = "fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID";
            fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldALACAKLIYA_ODENEN_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAKLIYA_ODENEN_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAKLIYA_ODENEN_MIKTAR.AreaIndex = 2;
            fieldALACAKLIYA_ODENEN_MIKTAR.FieldName = "ALACAKLIYA_ODENEN_MIKTAR";
            fieldALACAKLIYA_ODENEN_MIKTAR.Name = "fieldALACAKLIYA_ODENEN_MIKTAR";
            fieldALACAKLIYA_ODENEN_MIKTAR.Visible = false;

            PivotGridField fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.AreaIndex = 3;
            fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.FieldName = "ALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Name = "fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID";
            fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldSATISTAN_GELEN_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATISTAN_GELEN_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATISTAN_GELEN_MIKTAR.AreaIndex = 4;
            fieldSATISTAN_GELEN_MIKTAR.FieldName = "SATISTAN_GELEN_MIKTAR";
            fieldSATISTAN_GELEN_MIKTAR.Name = "fieldSATISTAN_GELEN_MIKTAR";
            fieldSATISTAN_GELEN_MIKTAR.Visible = false;

            PivotGridField fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID.AreaIndex = 5;
            fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID.FieldName = "SATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Name = "fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID";
            fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_NO.AreaIndex = 6;
            fieldSUBE_NO.FieldName = "SUBE_NO";
            fieldSUBE_NO.Name = "fieldSUBE_NO";
            fieldSUBE_NO.Visible = false;

            PivotGridField fieldSUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE.AreaIndex = 7;
            fieldSUBE.FieldName = "SUBE";
            fieldSUBE.Name = "fieldSUBE";
            fieldSUBE.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 8;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldIZLEYEN_AVUKAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN_AVUKAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN_AVUKAT.AreaIndex = 9;
            fieldIZLEYEN_AVUKAT.FieldName = "IZLEYEN_AVUKAT";
            fieldIZLEYEN_AVUKAT.Name = "fieldIZLEYEN_AVUKAT";
            fieldIZLEYEN_AVUKAT.Visible = false;

            PivotGridField fieldSORUMLU_AVUKAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU_AVUKAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU_AVUKAT.AreaIndex = 10;
            fieldSORUMLU_AVUKAT.FieldName = "SORUMLU_AVUKAT";
            fieldSORUMLU_AVUKAT.Name = "fieldSORUMLU_AVUKAT";
            fieldSORUMLU_AVUKAT.Visible = false;

            PivotGridField fieldAN_REF_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAN_REF_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAN_REF_NO1.AreaIndex = 11;
            fieldAN_REF_NO1.FieldName = "AN_REF_NO1";
            fieldAN_REF_NO1.Name = "fieldAN_REF_NO1";
            fieldAN_REF_NO1.Visible = false;

            PivotGridField fieldAN_REF_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAN_REF_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAN_REF_NO2.AreaIndex = 12;
            fieldAN_REF_NO2.FieldName = "AN_REF_NO2";
            fieldAN_REF_NO2.Name = "fieldAN_REF_NO2";
            fieldAN_REF_NO2.Visible = false;

            PivotGridField fieldAN_REF_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAN_REF_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAN_REF_NO3.AreaIndex = 13;
            fieldAN_REF_NO3.FieldName = "AN_REF_NO3";
            fieldAN_REF_NO3.Name = "fieldAN_REF_NO3";
            fieldAN_REF_NO3.Visible = false;

            PivotGridField fieldTAKIP_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN.AreaIndex = 14;
            fieldTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            fieldTAKIP_EDEN.Name = "fieldTAKIP_EDEN";
            fieldTAKIP_EDEN.Visible = false;

            PivotGridField fieldTAKIP_EDILEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN.AreaIndex = 15;
            fieldTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            fieldTAKIP_EDILEN.Name = "fieldTAKIP_EDILEN";
            fieldTAKIP_EDILEN.Visible = false;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 16;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 17;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 18;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldGUNCEL_BAKİYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGUNCEL_BAKİYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGUNCEL_BAKİYE.AreaIndex = 19;
            fieldGUNCEL_BAKİYE.FieldName = "GUNCEL_BAKİYE";
            fieldGUNCEL_BAKİYE.Name = "fieldGUNCEL_BAKİYE";
            fieldGUNCEL_BAKİYE.Visible = false;

            PivotGridField fieldTOPLAM_TAHSILAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTOPLAM_TAHSILAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTOPLAM_TAHSILAT.AreaIndex = 20;
            fieldTOPLAM_TAHSILAT.FieldName = "TOPLAM_TAHSILAT";
            fieldTOPLAM_TAHSILAT.Name = "fieldTOPLAM_TAHSILAT";
            fieldTOPLAM_TAHSILAT.Visible = false;

            PivotGridField fieldAYLIK_TOPLAM_TAHSILAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAYLIK_TOPLAM_TAHSILAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAYLIK_TOPLAM_TAHSILAT.AreaIndex = 21;
            fieldAYLIK_TOPLAM_TAHSILAT.FieldName = "AYLIK_TOPLAM_TAHSILAT";
            fieldAYLIK_TOPLAM_TAHSILAT.Name = "fieldAYLIK_TOPLAM_TAHSILAT";
            fieldAYLIK_TOPLAM_TAHSILAT.Visible = false;

            PivotGridField fieldAYLIK_TOPLAM_TAHSILAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAYLIK_TOPLAM_TAHSILAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAYLIK_TOPLAM_TAHSILAT_DOVIZ_ID.AreaIndex = 22;
            fieldAYLIK_TOPLAM_TAHSILAT_DOVIZ_ID.FieldName = "AYLIK_TOPLAM_TAHSILAT_DOVIZ_ID";
            fieldAYLIK_TOPLAM_TAHSILAT_DOVIZ_ID.Name = "fieldAYLIK_TOPLAM_TAHSILAT_DOVIZ_ID";
            fieldAYLIK_TOPLAM_TAHSILAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldAYLIK_TOPLAM_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAYLIK_TOPLAM_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAYLIK_TOPLAM_MASRAF.AreaIndex = 23;
            fieldAYLIK_TOPLAM_MASRAF.FieldName = "AYLIK_TOPLAM_MASRAF";
            fieldAYLIK_TOPLAM_MASRAF.Name = "fieldAYLIK_TOPLAM_MASRAF";
            fieldAYLIK_TOPLAM_MASRAF.Visible = false;

            PivotGridField fieldAYLIK_TOPLAM_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAYLIK_TOPLAM_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAYLIK_TOPLAM_MASRAF_DOVIZ_ID.AreaIndex = 24;
            fieldAYLIK_TOPLAM_MASRAF_DOVIZ_ID.FieldName = "AYLIK_TOPLAM_MASRAF_DOVIZ_ID";
            fieldAYLIK_TOPLAM_MASRAF_DOVIZ_ID.Name = "fieldAYLIK_TOPLAM_MASRAF_DOVIZ_ID";
            fieldAYLIK_TOPLAM_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldFAIZE_YAPILAN_TAHSILAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFAIZE_YAPILAN_TAHSILAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFAIZE_YAPILAN_TAHSILAT.AreaIndex = 25;
            fieldFAIZE_YAPILAN_TAHSILAT.FieldName = "FAIZE_YAPILAN_TAHSILAT";
            fieldFAIZE_YAPILAN_TAHSILAT.Name = "fieldFAIZE_YAPILAN_TAHSILAT";
            fieldFAIZE_YAPILAN_TAHSILAT.Visible = false;

            PivotGridField fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.AreaIndex = 26;
            fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "FAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID";
            fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldANA_PARAYA_YAPILAN_TAHSILAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_PARAYA_YAPILAN_TAHSILAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldANA_PARAYA_YAPILAN_TAHSILAT.AreaIndex = 27;
            fieldANA_PARAYA_YAPILAN_TAHSILAT.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT";
            fieldANA_PARAYA_YAPILAN_TAHSILAT.Name = "fieldANA_PARAYA_YAPILAN_TAHSILAT";
            fieldANA_PARAYA_YAPILAN_TAHSILAT.Visible = false;

            PivotGridField fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.AreaIndex = 28;
            fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.FieldName = "ANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Name = "fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID";
            fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 29;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 30;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 31;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 32;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 33;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 34;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 35;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 36;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 37;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldRISKTEN_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISKTEN_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISKTEN_KALAN.AreaIndex = 38;
            fieldRISKTEN_KALAN.FieldName = "RISKTEN_KALAN";
            fieldRISKTEN_KALAN.Name = "fieldRISKTEN_KALAN";
            fieldRISKTEN_KALAN.Visible = false;

            PivotGridField fieldRISKTEN_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISKTEN_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISKTEN_KALAN_DOVIZ_ID.AreaIndex = 39;
            fieldRISKTEN_KALAN_DOVIZ_ID.FieldName = "RISKTEN_KALAN_DOVIZ_ID";
            fieldRISKTEN_KALAN_DOVIZ_ID.Name = "fieldRISKTEN_KALAN_DOVIZ_ID";
            fieldRISKTEN_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 40;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 41;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 42;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldSEGMENT_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSEGMENT_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSEGMENT_ID.AreaIndex = 43;
            fieldSEGMENT_ID.FieldName = "SEGMENT_ID";
            fieldSEGMENT_ID.Name = "fieldSEGMENT_ID";
            fieldSEGMENT_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 44;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldAVUKATA_ODENEN_MIKTAR,
			fieldAVUKATA_ODENEN_MIKTAR_DOVIZ_ID,
			fieldALACAKLIYA_ODENEN_MIKTAR,
			fieldALACAKLIYA_ODENEN_MIKTAR_DOVIZ_ID,
			fieldSATISTAN_GELEN_MIKTAR,
			fieldSATISTAN_GELEN_MIKTAR_DOVIZ_ID,
			fieldSUBE_NO,
			fieldSUBE,
			fieldKREDI_TIP,
			fieldIZLEYEN_AVUKAT,
			fieldSORUMLU_AVUKAT,
			fieldAN_REF_NO1,
			fieldAN_REF_NO2,
			fieldAN_REF_NO3,
			fieldTAKIP_EDEN,
			fieldTAKIP_EDILEN,
			fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			fieldASIL_ALACAK,
			fieldASIL_ALACAK_DOVIZ_ID,
			fieldGUNCEL_BAKİYE,
			fieldTOPLAM_TAHSILAT,
			fieldAYLIK_TOPLAM_TAHSILAT,
			fieldAYLIK_TOPLAM_TAHSILAT_DOVIZ_ID,
			fieldAYLIK_TOPLAM_MASRAF,
			fieldAYLIK_TOPLAM_MASRAF_DOVIZ_ID,
			fieldFAIZE_YAPILAN_TAHSILAT,
			fieldFAIZE_YAPILAN_TAHSILAT_DOVIZ_ID,
			fieldANA_PARAYA_YAPILAN_TAHSILAT,
			fieldANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID,
			fieldID,
			fieldFOY_NO,
			fieldADLIYE,
			fieldNO,
			fieldDURUM,
			fieldKAPAMA_TARIHI,
			fieldRISK_MIKTARI,
			fieldRISK_MIKTARI_DOVIZ_ID,
			fieldSUBE_KOD_ID,
			fieldRISKTEN_KALAN,
			fieldRISKTEN_KALAN_DOVIZ_ID,
			fieldKALAN,
			fieldKALAN_DOVIZ_ID,
			fieldKREDI_GRUP,
			fieldSEGMENT_ID,
			fieldKONTROL_KIM_ID,
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

            #region Özelleştirme

            string RefNo, RefNo2, refNo3, OzelKod1, OzelKod2, OzelKod3, OzelKod4, ANRefNo, ANRefNo2, ANRefNo3;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraReferans.Referans1))
                RefNo = "Ref No";
            else
                RefNo = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraReferans.Referans1;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraReferans.Referans2))
                RefNo2 = "Ref No2";
            else
                RefNo2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraReferans.Referans2;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraReferans.Referans3))
                refNo3 = "Ref No3";
            else
                refNo3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraReferans.Referans3;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod1))
                OzelKod1 = "Özel Kod1";
            else
                OzelKod1 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod1;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod2))
                OzelKod2 = "Özel Kod2";
            else
                OzelKod2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod2;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod3))
                OzelKod3 = "Özel Kod3";
            else
                OzelKod3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod3;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod4))
                OzelKod4 = "Özel Kod4";
            else
                OzelKod4 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod4;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans1))
                ANRefNo = "Kredi Kartı Numarası";
            else
                ANRefNo = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans1;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans2))
                ANRefNo2 = "Hesap No";
            else
                ANRefNo2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans2;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans3))
                ANRefNo3 = "Kebir";
            else
                ANRefNo3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans3;

            #endregion Özelleştirme

            #region Caption Edit

            dicFieldCaption.Add("AVUKATA_ODENEN_MIKTAR", "Avukata Ödenen");
            dicFieldCaption.Add("ALACAKLIYA_ODENEN_MIKTAR", "Alacaklıya Ödenen");
            dicFieldCaption.Add("SATISTAN_GELEN_MIKTAR", "Şatıştan Gelen");
            dicFieldCaption.Add("SUBE_NO", "Şube No");
            dicFieldCaption.Add("SUBE", "Şube");
            dicFieldCaption.Add("KREDI_TIP", "Kredi Tip");
            dicFieldCaption.Add("IZLEYEN_AVUKAT", "İzleyen");
            dicFieldCaption.Add("SORUMLU_AVUKAT", "Sorumlu");
            dicFieldCaption.Add("AN_REF_NO1", ANRefNo);
            dicFieldCaption.Add("AN_REF_NO2", ANRefNo2);
            dicFieldCaption.Add("AN_REF_NO3", ANRefNo3);
            dicFieldCaption.Add("TAKIP_EDEN", "Takip Eden");
            dicFieldCaption.Add("TAKIP_EDILEN", "Takip Edilen");
            dicFieldCaption.Add("TAKIBIN_AVUKATA_INTIKAL_TARIHI", "İntikal T");
            dicFieldCaption.Add("ASIL_ALACAK", "Asıl Alacak");
            dicFieldCaption.Add("GUNCEL_BAKİYE", "Güncel Bakiye");
            dicFieldCaption.Add("TOPLAM_TAHSILAT", "Toplam Tahsilat");
            dicFieldCaption.Add("AYLIK_TOPLAM_TAHSILAT", "Aylık Toplam Tahsilat");
            dicFieldCaption.Add("AYLIK_TOPLAM_MASRAF", "Aylık Toplam Masraf");
            dicFieldCaption.Add("FAIZE_YAPILAN_TAHSILAT", "Faize Yapılan Tahsilat");
            dicFieldCaption.Add("ANA_PARAYA_YAPILAN_TAHSILAT", "Ana Paraya Yapılan Tahsilat");
            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("ADLIYE", "Adliye");
            dicFieldCaption.Add("NO", "Birim No");
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("KAPAMA_TARIHI", "Kapama T");
            dicFieldCaption.Add("RISK_MIKTARI", "Risk Miktarı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("RISKTEN_KALAN", "Riskten Kalan");
            dicFieldCaption.Add("KALAN", "Kalan");
            dicFieldCaption.Add("KREDI_GRUP", "Kredi Grup");
            dicFieldCaption.Add("SEGMENT_ID", "Bölüm");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");

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
            sozluk.Add("SEGMENT_ID", InitsEx.SegmnetBolumGetir);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("AVUKATA_ODENEN_MIKTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("ALACAKLIYA_ODENEN_MIKTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("SATISTAN_GELEN_MIKTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TOPLAM_TAHSILAT", InitsEx.ParaBicimiAyarla);
            sozluk.Add("AYLIK_TOPLAM_TAHSILAT", InitsEx.ParaBicimiAyarla);
            sozluk.Add("FAIZE_YAPILAN_TAHSILAT", InitsEx.ParaBicimiAyarla);
            sozluk.Add("ANA_PARAYA_YAPILAN_TAHSILAT", InitsEx.ParaBicimiAyarla);
            sozluk.Add("RISK_MIKTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("RISKTEN_KALAN", InitsEx.ParaBicimiAyarla);
            sozluk.Add("KALAN", InitsEx.ParaBicimiAyarla);

            #endregion Add item

            return sozluk;
        }
    }
}