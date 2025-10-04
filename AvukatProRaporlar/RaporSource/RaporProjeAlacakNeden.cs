using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class RaporProjeAlacakNeden
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

            GridColumn colPROJE_ID = new GridColumn();
            colPROJE_ID.VisibleIndex = 0;
            colPROJE_ID.FieldName = "PROJE_ID";
            colPROJE_ID.Name = "colPROJE_ID";
            colPROJE_ID.Visible = true;

            GridColumn colKOD = new GridColumn();
            colKOD.VisibleIndex = 1;
            colKOD.FieldName = "KOD";
            colKOD.Name = "colKOD";
            colKOD.Visible = true;

            GridColumn colADI = new GridColumn();
            colADI.VisibleIndex = 2;
            colADI.FieldName = "ADI";
            colADI.Name = "colADI";
            colADI.Visible = true;

            GridColumn colBITIS_TARIHI = new GridColumn();
            colBITIS_TARIHI.VisibleIndex = 3;
            colBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            colBITIS_TARIHI.Name = "colBITIS_TARIHI";
            colBITIS_TARIHI.Visible = true;

            GridColumn colBASLANGIC_TARIHI = new GridColumn();
            colBASLANGIC_TARIHI.VisibleIndex = 4;
            colBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            colBASLANGIC_TARIHI.Name = "colBASLANGIC_TARIHI";
            colBASLANGIC_TARIHI.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 5;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 6;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colPROJE_TARAFI = new GridColumn();
            colPROJE_TARAFI.VisibleIndex = 7;
            colPROJE_TARAFI.FieldName = "PROJE_TARAFI";
            colPROJE_TARAFI.Name = "colPROJE_TARAFI";
            colPROJE_TARAFI.Visible = true;

            GridColumn colPROJE_SORUMLU = new GridColumn();
            colPROJE_SORUMLU.VisibleIndex = 8;
            colPROJE_SORUMLU.FieldName = "PROJE_SORUMLU";
            colPROJE_SORUMLU.Name = "colPROJE_SORUMLU";
            colPROJE_SORUMLU.Visible = true;

            GridColumn colPROJE_YETKILI = new GridColumn();
            colPROJE_YETKILI.VisibleIndex = 9;
            colPROJE_YETKILI.FieldName = "PROJE_YETKILI";
            colPROJE_YETKILI.Name = "colPROJE_YETKILI";
            colPROJE_YETKILI.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 10;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 11;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 12;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 13;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colALACAK_NEDENI = new GridColumn();
            colALACAK_NEDENI.VisibleIndex = 14;
            colALACAK_NEDENI.FieldName = "ALACAK_NEDENI";
            colALACAK_NEDENI.Name = "colALACAK_NEDENI";
            colALACAK_NEDENI.Visible = true;

            GridColumn colVADE_TARIHI = new GridColumn();
            colVADE_TARIHI.VisibleIndex = 15;
            colVADE_TARIHI.FieldName = "VADE_TARIHI";
            colVADE_TARIHI.Name = "colVADE_TARIHI";
            colVADE_TARIHI.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 16;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colDUZENLENME_TARIHI = new GridColumn();
            colDUZENLENME_TARIHI.VisibleIndex = 17;
            colDUZENLENME_TARIHI.FieldName = "DUZENLENME_TARIHI";
            colDUZENLENME_TARIHI.Name = "colDUZENLENME_TARIHI";
            colDUZENLENME_TARIHI.Visible = true;

            GridColumn colTUTARI = new GridColumn();
            colTUTARI.VisibleIndex = 18;
            colTUTARI.FieldName = "TUTARI";
            colTUTARI.Name = "colTUTARI";
            colTUTARI.Visible = true;

            GridColumn colTUTAR_DOVIZ_ID = new GridColumn();
            colTUTAR_DOVIZ_ID.VisibleIndex = 19;
            colTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            colTUTAR_DOVIZ_ID.Name = "colTUTAR_DOVIZ_ID";
            colTUTAR_DOVIZ_ID.Visible = true;

            GridColumn colISLEME_KONAN_TUTAR = new GridColumn();
            colISLEME_KONAN_TUTAR.VisibleIndex = 20;
            colISLEME_KONAN_TUTAR.FieldName = "ISLEME_KONAN_TUTAR";
            colISLEME_KONAN_TUTAR.Name = "colISLEME_KONAN_TUTAR";
            colISLEME_KONAN_TUTAR.Visible = true;

            GridColumn colISLEME_KONAN_TUTAR_DOVIZ_ID = new GridColumn();
            colISLEME_KONAN_TUTAR_DOVIZ_ID.VisibleIndex = 21;
            colISLEME_KONAN_TUTAR_DOVIZ_ID.FieldName = "ISLEME_KONAN_TUTAR_DOVIZ_ID";
            colISLEME_KONAN_TUTAR_DOVIZ_ID.Name = "colISLEME_KONAN_TUTAR_DOVIZ_ID";
            colISLEME_KONAN_TUTAR_DOVIZ_ID.Visible = true;

            GridColumn colTO_UYGULANACAK_FAIZ_ORANI = new GridColumn();
            colTO_UYGULANACAK_FAIZ_ORANI.VisibleIndex = 22;
            colTO_UYGULANACAK_FAIZ_ORANI.FieldName = "TO_UYGULANACAK_FAIZ_ORANI";
            colTO_UYGULANACAK_FAIZ_ORANI.Name = "colTO_UYGULANACAK_FAIZ_ORANI";
            colTO_UYGULANACAK_FAIZ_ORANI.Visible = true;

            GridColumn colFAIZ_TIP = new GridColumn();
            colFAIZ_TIP.VisibleIndex = 23;
            colFAIZ_TIP.FieldName = "FAIZ_TIP";
            colFAIZ_TIP.Name = "colFAIZ_TIP";
            colFAIZ_TIP.Visible = true;

            GridColumn colTAKIP_DURUMU = new GridColumn();
            colTAKIP_DURUMU.VisibleIndex = 24;
            colTAKIP_DURUMU.FieldName = "TAKIP_DURUMU";
            colTAKIP_DURUMU.Name = "colTAKIP_DURUMU";
            colTAKIP_DURUMU.Visible = true;

            GridColumn colPROJE_ALACAK_NEDEN_ID = new GridColumn();
            colPROJE_ALACAK_NEDEN_ID.VisibleIndex = 25;
            colPROJE_ALACAK_NEDEN_ID.FieldName = "PROJE_ALACAK_NEDEN_ID";
            colPROJE_ALACAK_NEDEN_ID.Name = "colPROJE_ALACAK_NEDEN_ID";
            colPROJE_ALACAK_NEDEN_ID.Visible = true;

            GridColumn colINDIRIM_ANAPARA = new GridColumn();
            colINDIRIM_ANAPARA.VisibleIndex = 26;
            colINDIRIM_ANAPARA.FieldName = "INDIRIM_ANAPARA";
            colINDIRIM_ANAPARA.Name = "colINDIRIM_ANAPARA";
            colINDIRIM_ANAPARA.Visible = true;

            GridColumn colINDIRIM_ANAPARA_DOVIZ_ID = new GridColumn();
            colINDIRIM_ANAPARA_DOVIZ_ID.VisibleIndex = 27;
            colINDIRIM_ANAPARA_DOVIZ_ID.FieldName = "INDIRIM_ANAPARA_DOVIZ_ID";
            colINDIRIM_ANAPARA_DOVIZ_ID.Name = "colINDIRIM_ANAPARA_DOVIZ_ID";
            colINDIRIM_ANAPARA_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_BANKA_BAKIYESI = new GridColumn();
            colINDIRIM_BANKA_BAKIYESI.VisibleIndex = 28;
            colINDIRIM_BANKA_BAKIYESI.FieldName = "INDIRIM_BANKA_BAKIYESI";
            colINDIRIM_BANKA_BAKIYESI.Name = "colINDIRIM_BANKA_BAKIYESI";
            colINDIRIM_BANKA_BAKIYESI.Visible = true;

            GridColumn colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID = new GridColumn();
            colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.VisibleIndex = 29;
            colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "INDIRIM_BANKA_BAKIYESI_DOVIZ_ID";
            colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Name = "colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID";
            colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_FAIZ = new GridColumn();
            colINDIRIM_FAIZ.VisibleIndex = 30;
            colINDIRIM_FAIZ.FieldName = "INDIRIM_FAIZ";
            colINDIRIM_FAIZ.Name = "colINDIRIM_FAIZ";
            colINDIRIM_FAIZ.Visible = true;

            GridColumn colINDIRIM_FAIZ_DOVIZ_ID = new GridColumn();
            colINDIRIM_FAIZ_DOVIZ_ID.VisibleIndex = 31;
            colINDIRIM_FAIZ_DOVIZ_ID.FieldName = "INDIRIM_FAIZ_DOVIZ_ID";
            colINDIRIM_FAIZ_DOVIZ_ID.Name = "colINDIRIM_FAIZ_DOVIZ_ID";
            colINDIRIM_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_GIDER_VERGISI = new GridColumn();
            colINDIRIM_GIDER_VERGISI.VisibleIndex = 32;
            colINDIRIM_GIDER_VERGISI.FieldName = "INDIRIM_GIDER_VERGISI";
            colINDIRIM_GIDER_VERGISI.Name = "colINDIRIM_GIDER_VERGISI";
            colINDIRIM_GIDER_VERGISI.Visible = true;

            GridColumn colINDIRIM_GIDER_VERGISI_DOVIZ_ID = new GridColumn();
            colINDIRIM_GIDER_VERGISI_DOVIZ_ID.VisibleIndex = 33;
            colINDIRIM_GIDER_VERGISI_DOVIZ_ID.FieldName = "INDIRIM_GIDER_VERGISI_DOVIZ_ID";
            colINDIRIM_GIDER_VERGISI_DOVIZ_ID.Name = "colINDIRIM_GIDER_VERGISI_DOVIZ_ID";
            colINDIRIM_GIDER_VERGISI_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_KALAN = new GridColumn();
            colINDIRIM_KALAN.VisibleIndex = 34;
            colINDIRIM_KALAN.FieldName = "INDIRIM_KALAN";
            colINDIRIM_KALAN.Name = "colINDIRIM_KALAN";
            colINDIRIM_KALAN.Visible = true;

            GridColumn colINDIRIM_KALAN_DOVIZ_ID = new GridColumn();
            colINDIRIM_KALAN_DOVIZ_ID.VisibleIndex = 35;
            colINDIRIM_KALAN_DOVIZ_ID.FieldName = "INDIRIM_KALAN_DOVIZ_ID";
            colINDIRIM_KALAN_DOVIZ_ID.Name = "colINDIRIM_KALAN_DOVIZ_ID";
            colINDIRIM_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_KOM_TAZ = new GridColumn();
            colINDIRIM_KOM_TAZ.VisibleIndex = 36;
            colINDIRIM_KOM_TAZ.FieldName = "INDIRIM_KOM_TAZ";
            colINDIRIM_KOM_TAZ.Name = "colINDIRIM_KOM_TAZ";
            colINDIRIM_KOM_TAZ.Visible = true;

            GridColumn colINDIRIM_MASRAF = new GridColumn();
            colINDIRIM_MASRAF.VisibleIndex = 37;
            colINDIRIM_MASRAF.FieldName = "INDIRIM_MASRAF";
            colINDIRIM_MASRAF.Name = "colINDIRIM_MASRAF";
            colINDIRIM_MASRAF.Visible = true;

            GridColumn colINDIRIM_KOM_TAZ_DOVIZ_ID = new GridColumn();
            colINDIRIM_KOM_TAZ_DOVIZ_ID.VisibleIndex = 38;
            colINDIRIM_KOM_TAZ_DOVIZ_ID.FieldName = "INDIRIM_KOM_TAZ_DOVIZ_ID";
            colINDIRIM_KOM_TAZ_DOVIZ_ID.Name = "colINDIRIM_KOM_TAZ_DOVIZ_ID";
            colINDIRIM_KOM_TAZ_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_MASRAF_DOVIZ_ID = new GridColumn();
            colINDIRIM_MASRAF_DOVIZ_ID.VisibleIndex = 39;
            colINDIRIM_MASRAF_DOVIZ_ID.FieldName = "INDIRIM_MASRAF_DOVIZ_ID";
            colINDIRIM_MASRAF_DOVIZ_ID.Name = "colINDIRIM_MASRAF_DOVIZ_ID";
            colINDIRIM_MASRAF_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_VEKALET_UCRETI = new GridColumn();
            colINDIRIM_VEKALET_UCRETI.VisibleIndex = 40;
            colINDIRIM_VEKALET_UCRETI.FieldName = "INDIRIM_VEKALET_UCRETI";
            colINDIRIM_VEKALET_UCRETI.Name = "colINDIRIM_VEKALET_UCRETI";
            colINDIRIM_VEKALET_UCRETI.Visible = true;

            GridColumn colINDIRIM_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colINDIRIM_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 41;
            colINDIRIM_VEKALET_UCRETI_DOVIZ_ID.FieldName = "INDIRIM_VEKALET_UCRETI_DOVIZ_ID";
            colINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Name = "colINDIRIM_VEKALET_UCRETI_DOVIZ_ID";
            colINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_ANAPARA = new GridColumn();
            colKALAN_ANAPARA.VisibleIndex = 42;
            colKALAN_ANAPARA.FieldName = "KALAN_ANAPARA";
            colKALAN_ANAPARA.Name = "colKALAN_ANAPARA";
            colKALAN_ANAPARA.Visible = true;

            GridColumn colKALAN_ANAPARA_DOVIZ_ID = new GridColumn();
            colKALAN_ANAPARA_DOVIZ_ID.VisibleIndex = 43;
            colKALAN_ANAPARA_DOVIZ_ID.FieldName = "KALAN_ANAPARA_DOVIZ_ID";
            colKALAN_ANAPARA_DOVIZ_ID.Name = "colKALAN_ANAPARA_DOVIZ_ID";
            colKALAN_ANAPARA_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_BANKA_BAKIYESI = new GridColumn();
            colKALAN_BANKA_BAKIYESI.VisibleIndex = 44;
            colKALAN_BANKA_BAKIYESI.FieldName = "KALAN_BANKA_BAKIYESI";
            colKALAN_BANKA_BAKIYESI.Name = "colKALAN_BANKA_BAKIYESI";
            colKALAN_BANKA_BAKIYESI.Visible = true;

            GridColumn colKALAN_BANKA_BAKIYESI_DOVIZ_ID = new GridColumn();
            colKALAN_BANKA_BAKIYESI_DOVIZ_ID.VisibleIndex = 45;
            colKALAN_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "KALAN_BANKA_BAKIYESI_DOVIZ_ID";
            colKALAN_BANKA_BAKIYESI_DOVIZ_ID.Name = "colKALAN_BANKA_BAKIYESI_DOVIZ_ID";
            colKALAN_BANKA_BAKIYESI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_FAIZ = new GridColumn();
            colKALAN_FAIZ.VisibleIndex = 46;
            colKALAN_FAIZ.FieldName = "KALAN_FAIZ";
            colKALAN_FAIZ.Name = "colKALAN_FAIZ";
            colKALAN_FAIZ.Visible = true;

            GridColumn colKALAN_FAIZ_DOVIZ_ID = new GridColumn();
            colKALAN_FAIZ_DOVIZ_ID.VisibleIndex = 47;
            colKALAN_FAIZ_DOVIZ_ID.FieldName = "KALAN_FAIZ_DOVIZ_ID";
            colKALAN_FAIZ_DOVIZ_ID.Name = "colKALAN_FAIZ_DOVIZ_ID";
            colKALAN_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_GIDER_VERGISI = new GridColumn();
            colKALAN_GIDER_VERGISI.VisibleIndex = 48;
            colKALAN_GIDER_VERGISI.FieldName = "KALAN_GIDER_VERGISI";
            colKALAN_GIDER_VERGISI.Name = "colKALAN_GIDER_VERGISI";
            colKALAN_GIDER_VERGISI.Visible = true;

            GridColumn colKALAN_GIDER_VERGISI_DOVIZ_ID = new GridColumn();
            colKALAN_GIDER_VERGISI_DOVIZ_ID.VisibleIndex = 49;
            colKALAN_GIDER_VERGISI_DOVIZ_ID.FieldName = "KALAN_GIDER_VERGISI_DOVIZ_ID";
            colKALAN_GIDER_VERGISI_DOVIZ_ID.Name = "colKALAN_GIDER_VERGISI_DOVIZ_ID";
            colKALAN_GIDER_VERGISI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_KALAN = new GridColumn();
            colKALAN_KALAN.VisibleIndex = 50;
            colKALAN_KALAN.FieldName = "KALAN_KALAN";
            colKALAN_KALAN.Name = "colKALAN_KALAN";
            colKALAN_KALAN.Visible = true;

            GridColumn colKALAN_KOM_TAZ = new GridColumn();
            colKALAN_KOM_TAZ.VisibleIndex = 51;
            colKALAN_KOM_TAZ.FieldName = "KALAN_KOM_TAZ";
            colKALAN_KOM_TAZ.Name = "colKALAN_KOM_TAZ";
            colKALAN_KOM_TAZ.Visible = true;

            GridColumn colKALAN_KALAN_DOVIZ_ID = new GridColumn();
            colKALAN_KALAN_DOVIZ_ID.VisibleIndex = 52;
            colKALAN_KALAN_DOVIZ_ID.FieldName = "KALAN_KALAN_DOVIZ_ID";
            colKALAN_KALAN_DOVIZ_ID.Name = "colKALAN_KALAN_DOVIZ_ID";
            colKALAN_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_KOM_TAZ_DOVIZ_ID = new GridColumn();
            colKALAN_KOM_TAZ_DOVIZ_ID.VisibleIndex = 53;
            colKALAN_KOM_TAZ_DOVIZ_ID.FieldName = "KALAN_KOM_TAZ_DOVIZ_ID";
            colKALAN_KOM_TAZ_DOVIZ_ID.Name = "colKALAN_KOM_TAZ_DOVIZ_ID";
            colKALAN_KOM_TAZ_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_MASRAF = new GridColumn();
            colKALAN_MASRAF.VisibleIndex = 54;
            colKALAN_MASRAF.FieldName = "KALAN_MASRAF";
            colKALAN_MASRAF.Name = "colKALAN_MASRAF";
            colKALAN_MASRAF.Visible = true;

            GridColumn colKALAN_MASRAF_DOVIZ_ID = new GridColumn();
            colKALAN_MASRAF_DOVIZ_ID.VisibleIndex = 55;
            colKALAN_MASRAF_DOVIZ_ID.FieldName = "KALAN_MASRAF_DOVIZ_ID";
            colKALAN_MASRAF_DOVIZ_ID.Name = "colKALAN_MASRAF_DOVIZ_ID";
            colKALAN_MASRAF_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_VEKALET_UCRETI = new GridColumn();
            colKALAN_VEKALET_UCRETI.VisibleIndex = 56;
            colKALAN_VEKALET_UCRETI.FieldName = "KALAN_VEKALET_UCRETI";
            colKALAN_VEKALET_UCRETI.Name = "colKALAN_VEKALET_UCRETI";
            colKALAN_VEKALET_UCRETI.Visible = true;

            GridColumn colKALAN_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colKALAN_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 57;
            colKALAN_VEKALET_UCRETI_DOVIZ_ID.FieldName = "KALAN_VEKALET_UCRETI_DOVIZ_ID";
            colKALAN_VEKALET_UCRETI_DOVIZ_ID.Name = "colKALAN_VEKALET_UCRETI_DOVIZ_ID";
            colKALAN_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_ANAPARA = new GridColumn();
            colODEME_ANAPARA.VisibleIndex = 58;
            colODEME_ANAPARA.FieldName = "ODEME_ANAPARA";
            colODEME_ANAPARA.Name = "colODEME_ANAPARA";
            colODEME_ANAPARA.Visible = true;

            GridColumn colODEME_ANAPARA_DOVIZ_ID = new GridColumn();
            colODEME_ANAPARA_DOVIZ_ID.VisibleIndex = 59;
            colODEME_ANAPARA_DOVIZ_ID.FieldName = "ODEME_ANAPARA_DOVIZ_ID";
            colODEME_ANAPARA_DOVIZ_ID.Name = "colODEME_ANAPARA_DOVIZ_ID";
            colODEME_ANAPARA_DOVIZ_ID.Visible = true;

            GridColumn colODEME_BANKA_BAKIYESI = new GridColumn();
            colODEME_BANKA_BAKIYESI.VisibleIndex = 60;
            colODEME_BANKA_BAKIYESI.FieldName = "ODEME_BANKA_BAKIYESI";
            colODEME_BANKA_BAKIYESI.Name = "colODEME_BANKA_BAKIYESI";
            colODEME_BANKA_BAKIYESI.Visible = true;

            GridColumn colODEME_BANKA_BAKIYESI_DOVIZ_ID = new GridColumn();
            colODEME_BANKA_BAKIYESI_DOVIZ_ID.VisibleIndex = 61;
            colODEME_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "ODEME_BANKA_BAKIYESI_DOVIZ_ID";
            colODEME_BANKA_BAKIYESI_DOVIZ_ID.Name = "colODEME_BANKA_BAKIYESI_DOVIZ_ID";
            colODEME_BANKA_BAKIYESI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_FAIZ_DOVIZ_ID = new GridColumn();
            colODEME_FAIZ_DOVIZ_ID.VisibleIndex = 62;
            colODEME_FAIZ_DOVIZ_ID.FieldName = "ODEME_FAIZ_DOVIZ_ID";
            colODEME_FAIZ_DOVIZ_ID.Name = "colODEME_FAIZ_DOVIZ_ID";
            colODEME_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colODEME_FAIZ = new GridColumn();
            colODEME_FAIZ.VisibleIndex = 63;
            colODEME_FAIZ.FieldName = "ODEME_FAIZ";
            colODEME_FAIZ.Name = "colODEME_FAIZ";
            colODEME_FAIZ.Visible = true;

            GridColumn colODEME_GIDER_VERGISI = new GridColumn();
            colODEME_GIDER_VERGISI.VisibleIndex = 64;
            colODEME_GIDER_VERGISI.FieldName = "ODEME_GIDER_VERGISI";
            colODEME_GIDER_VERGISI.Name = "colODEME_GIDER_VERGISI";
            colODEME_GIDER_VERGISI.Visible = true;

            GridColumn colODEME_GIDER_VERGISI_DOVIZ_ID = new GridColumn();
            colODEME_GIDER_VERGISI_DOVIZ_ID.VisibleIndex = 65;
            colODEME_GIDER_VERGISI_DOVIZ_ID.FieldName = "ODEME_GIDER_VERGISI_DOVIZ_ID";
            colODEME_GIDER_VERGISI_DOVIZ_ID.Name = "colODEME_GIDER_VERGISI_DOVIZ_ID";
            colODEME_GIDER_VERGISI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_KALAN = new GridColumn();
            colODEME_KALAN.VisibleIndex = 66;
            colODEME_KALAN.FieldName = "ODEME_KALAN";
            colODEME_KALAN.Name = "colODEME_KALAN";
            colODEME_KALAN.Visible = true;

            GridColumn colODEME_KALAN_DOVIZ_ID = new GridColumn();
            colODEME_KALAN_DOVIZ_ID.VisibleIndex = 67;
            colODEME_KALAN_DOVIZ_ID.FieldName = "ODEME_KALAN_DOVIZ_ID";
            colODEME_KALAN_DOVIZ_ID.Name = "colODEME_KALAN_DOVIZ_ID";
            colODEME_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colODEME_KOM_TAZ = new GridColumn();
            colODEME_KOM_TAZ.VisibleIndex = 68;
            colODEME_KOM_TAZ.FieldName = "ODEME_KOM_TAZ";
            colODEME_KOM_TAZ.Name = "colODEME_KOM_TAZ";
            colODEME_KOM_TAZ.Visible = true;

            GridColumn colODEME_KOM_TAZ_DOVIZ_ID = new GridColumn();
            colODEME_KOM_TAZ_DOVIZ_ID.VisibleIndex = 69;
            colODEME_KOM_TAZ_DOVIZ_ID.FieldName = "ODEME_KOM_TAZ_DOVIZ_ID";
            colODEME_KOM_TAZ_DOVIZ_ID.Name = "colODEME_KOM_TAZ_DOVIZ_ID";
            colODEME_KOM_TAZ_DOVIZ_ID.Visible = true;

            GridColumn colODEME_MASRAF = new GridColumn();
            colODEME_MASRAF.VisibleIndex = 70;
            colODEME_MASRAF.FieldName = "ODEME_MASRAF";
            colODEME_MASRAF.Name = "colODEME_MASRAF";
            colODEME_MASRAF.Visible = true;

            GridColumn colODEME_MASRAF_DOVIZ_ID = new GridColumn();
            colODEME_MASRAF_DOVIZ_ID.VisibleIndex = 71;
            colODEME_MASRAF_DOVIZ_ID.FieldName = "ODEME_MASRAF_DOVIZ_ID";
            colODEME_MASRAF_DOVIZ_ID.Name = "colODEME_MASRAF_DOVIZ_ID";
            colODEME_MASRAF_DOVIZ_ID.Visible = true;

            GridColumn colODEME_VEKALET_UCRETI = new GridColumn();
            colODEME_VEKALET_UCRETI.VisibleIndex = 72;
            colODEME_VEKALET_UCRETI.FieldName = "ODEME_VEKALET_UCRETI";
            colODEME_VEKALET_UCRETI.Name = "colODEME_VEKALET_UCRETI";
            colODEME_VEKALET_UCRETI.Visible = true;

            GridColumn colODEME_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colODEME_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 73;
            colODEME_VEKALET_UCRETI_DOVIZ_ID.FieldName = "ODEME_VEKALET_UCRETI_DOVIZ_ID";
            colODEME_VEKALET_UCRETI_DOVIZ_ID.Name = "colODEME_VEKALET_UCRETI_DOVIZ_ID";
            colODEME_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_ANAPARA = new GridColumn();
            colTUTAR_ANAPARA.VisibleIndex = 74;
            colTUTAR_ANAPARA.FieldName = "TUTAR_ANAPARA";
            colTUTAR_ANAPARA.Name = "colTUTAR_ANAPARA";
            colTUTAR_ANAPARA.Visible = true;

            GridColumn colTUTAR_ANAPARA_DOVIZ_ID = new GridColumn();
            colTUTAR_ANAPARA_DOVIZ_ID.VisibleIndex = 75;
            colTUTAR_ANAPARA_DOVIZ_ID.FieldName = "TUTAR_ANAPARA_DOVIZ_ID";
            colTUTAR_ANAPARA_DOVIZ_ID.Name = "colTUTAR_ANAPARA_DOVIZ_ID";
            colTUTAR_ANAPARA_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_BANKA_BAKIYESI = new GridColumn();
            colTUTAR_BANKA_BAKIYESI.VisibleIndex = 76;
            colTUTAR_BANKA_BAKIYESI.FieldName = "TUTAR_BANKA_BAKIYESI";
            colTUTAR_BANKA_BAKIYESI.Name = "colTUTAR_BANKA_BAKIYESI";
            colTUTAR_BANKA_BAKIYESI.Visible = true;

            GridColumn colTUTAR_BANKA_BAKIYESI_DOVIZ_ID = new GridColumn();
            colTUTAR_BANKA_BAKIYESI_DOVIZ_ID.VisibleIndex = 77;
            colTUTAR_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "TUTAR_BANKA_BAKIYESI_DOVIZ_ID";
            colTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Name = "colTUTAR_BANKA_BAKIYESI_DOVIZ_ID";
            colTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_FAIZ = new GridColumn();
            colTUTAR_FAIZ.VisibleIndex = 78;
            colTUTAR_FAIZ.FieldName = "TUTAR_FAIZ";
            colTUTAR_FAIZ.Name = "colTUTAR_FAIZ";
            colTUTAR_FAIZ.Visible = true;

            GridColumn colTUTAR_FAIZ_DOVIZ_ID = new GridColumn();
            colTUTAR_FAIZ_DOVIZ_ID.VisibleIndex = 79;
            colTUTAR_FAIZ_DOVIZ_ID.FieldName = "TUTAR_FAIZ_DOVIZ_ID";
            colTUTAR_FAIZ_DOVIZ_ID.Name = "colTUTAR_FAIZ_DOVIZ_ID";
            colTUTAR_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_GIDER_VERGISI = new GridColumn();
            colTUTAR_GIDER_VERGISI.VisibleIndex = 80;
            colTUTAR_GIDER_VERGISI.FieldName = "TUTAR_GIDER_VERGISI";
            colTUTAR_GIDER_VERGISI.Name = "colTUTAR_GIDER_VERGISI";
            colTUTAR_GIDER_VERGISI.Visible = true;

            GridColumn colTUTAR_GIDER_VERGISI_DOVIZ_ID = new GridColumn();
            colTUTAR_GIDER_VERGISI_DOVIZ_ID.VisibleIndex = 81;
            colTUTAR_GIDER_VERGISI_DOVIZ_ID.FieldName = "TUTAR_GIDER_VERGISI_DOVIZ_ID";
            colTUTAR_GIDER_VERGISI_DOVIZ_ID.Name = "colTUTAR_GIDER_VERGISI_DOVIZ_ID";
            colTUTAR_GIDER_VERGISI_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_KALAN = new GridColumn();
            colTUTAR_KALAN.VisibleIndex = 82;
            colTUTAR_KALAN.FieldName = "TUTAR_KALAN";
            colTUTAR_KALAN.Name = "colTUTAR_KALAN";
            colTUTAR_KALAN.Visible = true;

            GridColumn colTUTAR_KALAN_DOVIZ_ID = new GridColumn();
            colTUTAR_KALAN_DOVIZ_ID.VisibleIndex = 83;
            colTUTAR_KALAN_DOVIZ_ID.FieldName = "TUTAR_KALAN_DOVIZ_ID";
            colTUTAR_KALAN_DOVIZ_ID.Name = "colTUTAR_KALAN_DOVIZ_ID";
            colTUTAR_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_KOM_TAZ = new GridColumn();
            colTUTAR_KOM_TAZ.VisibleIndex = 84;
            colTUTAR_KOM_TAZ.FieldName = "TUTAR_KOM_TAZ";
            colTUTAR_KOM_TAZ.Name = "colTUTAR_KOM_TAZ";
            colTUTAR_KOM_TAZ.Visible = true;

            GridColumn colTUTAR_KOM_TAZ_DOVIZ_ID = new GridColumn();
            colTUTAR_KOM_TAZ_DOVIZ_ID.VisibleIndex = 85;
            colTUTAR_KOM_TAZ_DOVIZ_ID.FieldName = "TUTAR_KOM_TAZ_DOVIZ_ID";
            colTUTAR_KOM_TAZ_DOVIZ_ID.Name = "colTUTAR_KOM_TAZ_DOVIZ_ID";
            colTUTAR_KOM_TAZ_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_MASRAF = new GridColumn();
            colTUTAR_MASRAF.VisibleIndex = 86;
            colTUTAR_MASRAF.FieldName = "TUTAR_MASRAF";
            colTUTAR_MASRAF.Name = "colTUTAR_MASRAF";
            colTUTAR_MASRAF.Visible = true;

            GridColumn colTUTAR_MASRAF_DOVIZ_ID = new GridColumn();
            colTUTAR_MASRAF_DOVIZ_ID.VisibleIndex = 87;
            colTUTAR_MASRAF_DOVIZ_ID.FieldName = "TUTAR_MASRAF_DOVIZ_ID";
            colTUTAR_MASRAF_DOVIZ_ID.Name = "colTUTAR_MASRAF_DOVIZ_ID";
            colTUTAR_MASRAF_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_VEKALET_UCRETI = new GridColumn();
            colTUTAR_VEKALET_UCRETI.VisibleIndex = 88;
            colTUTAR_VEKALET_UCRETI.FieldName = "TUTAR_VEKALET_UCRETI";
            colTUTAR_VEKALET_UCRETI.Name = "colTUTAR_VEKALET_UCRETI";
            colTUTAR_VEKALET_UCRETI.Visible = true;

            GridColumn colTUTAR_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colTUTAR_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 89;
            colTUTAR_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TUTAR_VEKALET_UCRETI_DOVIZ_ID";
            colTUTAR_VEKALET_UCRETI_DOVIZ_ID.Name = "colTUTAR_VEKALET_UCRETI_DOVIZ_ID";
            colTUTAR_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colSON_HESAP_TARIHI = new GridColumn();
            colSON_HESAP_TARIHI.VisibleIndex = 90;
            colSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Name = "colSON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Visible = true;

            GridColumn colHESAPLAMA_TIPI = new GridColumn();
            colHESAPLAMA_TIPI.VisibleIndex = 91;
            colHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Name = "colHESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Visible = true;

            GridColumn colRISK_TOPLAMI = new GridColumn();
            colRISK_TOPLAMI.VisibleIndex = 92;
            colRISK_TOPLAMI.FieldName = "RISK_TOPLAMI";
            colRISK_TOPLAMI.Name = "colRISK_TOPLAMI";
            colRISK_TOPLAMI.Visible = true;

            GridColumn colRISK_TOPLAMI_DOVIZ_ID = new GridColumn();
            colRISK_TOPLAMI_DOVIZ_ID.VisibleIndex = 93;
            colRISK_TOPLAMI_DOVIZ_ID.FieldName = "RISK_TOPLAMI_DOVIZ_ID";
            colRISK_TOPLAMI_DOVIZ_ID.Name = "colRISK_TOPLAMI_DOVIZ_ID";
            colRISK_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 94;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colPROJE_ID,
			colKOD,
			colADI,
			colBITIS_TARIHI,
			colBASLANGIC_TARIHI,
			colSUBE_KOD_ID,
			colKONTROL_KIM_ID,
			colPROJE_TARAFI,
			colPROJE_SORUMLU,
			colPROJE_YETKILI,
			colFOY_NO,
			colADLIYE,
			colNO,
			colESAS_NO,
			colALACAK_NEDENI,
			colVADE_TARIHI,
			colTAKIP_TARIHI,
			colDUZENLENME_TARIHI,
			colTUTARI,
			colTUTAR_DOVIZ_ID,
			colISLEME_KONAN_TUTAR,
			colISLEME_KONAN_TUTAR_DOVIZ_ID,
			colTO_UYGULANACAK_FAIZ_ORANI,
			colFAIZ_TIP,
			colTAKIP_DURUMU,
			colPROJE_ALACAK_NEDEN_ID,
			colINDIRIM_ANAPARA,
			colINDIRIM_ANAPARA_DOVIZ_ID,
			colINDIRIM_BANKA_BAKIYESI,
			colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID,
			colINDIRIM_FAIZ,
			colINDIRIM_FAIZ_DOVIZ_ID,
			colINDIRIM_GIDER_VERGISI,
			colINDIRIM_GIDER_VERGISI_DOVIZ_ID,
			colINDIRIM_KALAN,
			colINDIRIM_KALAN_DOVIZ_ID,
			colINDIRIM_KOM_TAZ,
			colINDIRIM_MASRAF,
			colINDIRIM_KOM_TAZ_DOVIZ_ID,
			colINDIRIM_MASRAF_DOVIZ_ID,
			colINDIRIM_VEKALET_UCRETI,
			colINDIRIM_VEKALET_UCRETI_DOVIZ_ID,
			colKALAN_ANAPARA,
			colKALAN_ANAPARA_DOVIZ_ID,
			colKALAN_BANKA_BAKIYESI,
			colKALAN_BANKA_BAKIYESI_DOVIZ_ID,
			colKALAN_FAIZ,
			colKALAN_FAIZ_DOVIZ_ID,
			colKALAN_GIDER_VERGISI,
			colKALAN_GIDER_VERGISI_DOVIZ_ID,
			colKALAN_KALAN,
			colKALAN_KOM_TAZ,
			colKALAN_KALAN_DOVIZ_ID,
			colKALAN_KOM_TAZ_DOVIZ_ID,
			colKALAN_MASRAF,
			colKALAN_MASRAF_DOVIZ_ID,
			colKALAN_VEKALET_UCRETI,
			colKALAN_VEKALET_UCRETI_DOVIZ_ID,
			colODEME_ANAPARA,
			colODEME_ANAPARA_DOVIZ_ID,
			colODEME_BANKA_BAKIYESI,
			colODEME_BANKA_BAKIYESI_DOVIZ_ID,
			colODEME_FAIZ_DOVIZ_ID,
			colODEME_FAIZ,
			colODEME_GIDER_VERGISI,
			colODEME_GIDER_VERGISI_DOVIZ_ID,
			colODEME_KALAN,
			colODEME_KALAN_DOVIZ_ID,
			colODEME_KOM_TAZ,
			colODEME_KOM_TAZ_DOVIZ_ID,
			colODEME_MASRAF,
			colODEME_MASRAF_DOVIZ_ID,
			colODEME_VEKALET_UCRETI,
			colODEME_VEKALET_UCRETI_DOVIZ_ID,
			colTUTAR_ANAPARA,
			colTUTAR_ANAPARA_DOVIZ_ID,
			colTUTAR_BANKA_BAKIYESI,
			colTUTAR_BANKA_BAKIYESI_DOVIZ_ID,
			colTUTAR_FAIZ,
			colTUTAR_FAIZ_DOVIZ_ID,
			colTUTAR_GIDER_VERGISI,
			colTUTAR_GIDER_VERGISI_DOVIZ_ID,
			colTUTAR_KALAN,
			colTUTAR_KALAN_DOVIZ_ID,
			colTUTAR_KOM_TAZ,
			colTUTAR_KOM_TAZ_DOVIZ_ID,
			colTUTAR_MASRAF,
			colTUTAR_MASRAF_DOVIZ_ID,
			colTUTAR_VEKALET_UCRETI,
			colTUTAR_VEKALET_UCRETI_DOVIZ_ID,
			colSON_HESAP_TARIHI,
			colHESAPLAMA_TIPI,
			colRISK_TOPLAMI,
			colRISK_TOPLAMI_DOVIZ_ID,
			colBOLUM,
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
            #region Field & Properties

            PivotGridField fieldPROJE_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_ID.AreaIndex = 0;
            fieldPROJE_ID.FieldName = "PROJE_ID";
            fieldPROJE_ID.Name = "fieldPROJE_ID";
            fieldPROJE_ID.Visible = false;

            PivotGridField fieldKOD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKOD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKOD.AreaIndex = 1;
            fieldKOD.FieldName = "KOD";
            fieldKOD.Name = "fieldKOD";
            fieldKOD.Visible = false;

            PivotGridField fieldADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADI.AreaIndex = 2;
            fieldADI.FieldName = "ADI";
            fieldADI.Name = "fieldADI";
            fieldADI.Visible = false;

            PivotGridField fieldBITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_TARIHI.AreaIndex = 3;
            fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
            fieldBITIS_TARIHI.Visible = false;

            PivotGridField fieldBASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASLANGIC_TARIHI.AreaIndex = 4;
            fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 5;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 6;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldPROJE_TARAFI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_TARAFI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_TARAFI.AreaIndex = 7;
            fieldPROJE_TARAFI.FieldName = "PROJE_TARAFI";
            fieldPROJE_TARAFI.Name = "fieldPROJE_TARAFI";
            fieldPROJE_TARAFI.Visible = false;

            PivotGridField fieldPROJE_SORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_SORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_SORUMLU.AreaIndex = 8;
            fieldPROJE_SORUMLU.FieldName = "PROJE_SORUMLU";
            fieldPROJE_SORUMLU.Name = "fieldPROJE_SORUMLU";
            fieldPROJE_SORUMLU.Visible = false;

            PivotGridField fieldPROJE_YETKILI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_YETKILI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_YETKILI.AreaIndex = 9;
            fieldPROJE_YETKILI.FieldName = "PROJE_YETKILI";
            fieldPROJE_YETKILI.Name = "fieldPROJE_YETKILI";
            fieldPROJE_YETKILI.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 10;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 11;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 12;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 13;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldALACAK_NEDENI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_NEDENI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_NEDENI.AreaIndex = 14;
            fieldALACAK_NEDENI.FieldName = "ALACAK_NEDENI";
            fieldALACAK_NEDENI.Name = "fieldALACAK_NEDENI";
            fieldALACAK_NEDENI.Visible = false;

            PivotGridField fieldVADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVADE_TARIHI.AreaIndex = 15;
            fieldVADE_TARIHI.FieldName = "VADE_TARIHI";
            fieldVADE_TARIHI.Name = "fieldVADE_TARIHI";
            fieldVADE_TARIHI.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 16;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldDUZENLENME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDUZENLENME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDUZENLENME_TARIHI.AreaIndex = 17;
            fieldDUZENLENME_TARIHI.FieldName = "DUZENLENME_TARIHI";
            fieldDUZENLENME_TARIHI.Name = "fieldDUZENLENME_TARIHI";
            fieldDUZENLENME_TARIHI.Visible = false;

            PivotGridField fieldTUTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTARI.AreaIndex = 18;
            fieldTUTARI.FieldName = "TUTARI";
            fieldTUTARI.Name = "fieldTUTARI";
            fieldTUTARI.Visible = false;

            PivotGridField fieldTUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_DOVIZ_ID.AreaIndex = 19;
            fieldTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            fieldTUTAR_DOVIZ_ID.Name = "fieldTUTAR_DOVIZ_ID";
            fieldTUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldISLEME_KONAN_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEME_KONAN_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEME_KONAN_TUTAR.AreaIndex = 20;
            fieldISLEME_KONAN_TUTAR.FieldName = "ISLEME_KONAN_TUTAR";
            fieldISLEME_KONAN_TUTAR.Name = "fieldISLEME_KONAN_TUTAR";
            fieldISLEME_KONAN_TUTAR.Visible = false;

            PivotGridField fieldISLEME_KONAN_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEME_KONAN_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEME_KONAN_TUTAR_DOVIZ_ID.AreaIndex = 21;
            fieldISLEME_KONAN_TUTAR_DOVIZ_ID.FieldName = "ISLEME_KONAN_TUTAR_DOVIZ_ID";
            fieldISLEME_KONAN_TUTAR_DOVIZ_ID.Name = "fieldISLEME_KONAN_TUTAR_DOVIZ_ID";
            fieldISLEME_KONAN_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_UYGULANACAK_FAIZ_ORANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_UYGULANACAK_FAIZ_ORANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_UYGULANACAK_FAIZ_ORANI.AreaIndex = 22;
            fieldTO_UYGULANACAK_FAIZ_ORANI.FieldName = "TO_UYGULANACAK_FAIZ_ORANI";
            fieldTO_UYGULANACAK_FAIZ_ORANI.Name = "fieldTO_UYGULANACAK_FAIZ_ORANI";
            fieldTO_UYGULANACAK_FAIZ_ORANI.Visible = false;

            PivotGridField fieldFAIZ_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFAIZ_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFAIZ_TIP.AreaIndex = 23;
            fieldFAIZ_TIP.FieldName = "FAIZ_TIP";
            fieldFAIZ_TIP.Name = "fieldFAIZ_TIP";
            fieldFAIZ_TIP.Visible = false;

            PivotGridField fieldTAKIP_DURUMU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_DURUMU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_DURUMU.AreaIndex = 24;
            fieldTAKIP_DURUMU.FieldName = "TAKIP_DURUMU";
            fieldTAKIP_DURUMU.Name = "fieldTAKIP_DURUMU";
            fieldTAKIP_DURUMU.Visible = false;

            PivotGridField fieldPROJE_ALACAK_NEDEN_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_ALACAK_NEDEN_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_ALACAK_NEDEN_ID.AreaIndex = 25;
            fieldPROJE_ALACAK_NEDEN_ID.FieldName = "PROJE_ALACAK_NEDEN_ID";
            fieldPROJE_ALACAK_NEDEN_ID.Name = "fieldPROJE_ALACAK_NEDEN_ID";
            fieldPROJE_ALACAK_NEDEN_ID.Visible = false;

            PivotGridField fieldINDIRIM_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_ANAPARA.AreaIndex = 26;
            fieldINDIRIM_ANAPARA.FieldName = "INDIRIM_ANAPARA";
            fieldINDIRIM_ANAPARA.Name = "fieldINDIRIM_ANAPARA";
            fieldINDIRIM_ANAPARA.Visible = false;

            PivotGridField fieldINDIRIM_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_ANAPARA_DOVIZ_ID.AreaIndex = 27;
            fieldINDIRIM_ANAPARA_DOVIZ_ID.FieldName = "INDIRIM_ANAPARA_DOVIZ_ID";
            fieldINDIRIM_ANAPARA_DOVIZ_ID.Name = "fieldINDIRIM_ANAPARA_DOVIZ_ID";
            fieldINDIRIM_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_BANKA_BAKIYESI.AreaIndex = 28;
            fieldINDIRIM_BANKA_BAKIYESI.FieldName = "INDIRIM_BANKA_BAKIYESI";
            fieldINDIRIM_BANKA_BAKIYESI.Name = "fieldINDIRIM_BANKA_BAKIYESI";
            fieldINDIRIM_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 29;
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "INDIRIM_BANKA_BAKIYESI_DOVIZ_ID";
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID";
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_FAIZ.AreaIndex = 30;
            fieldINDIRIM_FAIZ.FieldName = "INDIRIM_FAIZ";
            fieldINDIRIM_FAIZ.Name = "fieldINDIRIM_FAIZ";
            fieldINDIRIM_FAIZ.Visible = false;

            PivotGridField fieldINDIRIM_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_FAIZ_DOVIZ_ID.AreaIndex = 31;
            fieldINDIRIM_FAIZ_DOVIZ_ID.FieldName = "INDIRIM_FAIZ_DOVIZ_ID";
            fieldINDIRIM_FAIZ_DOVIZ_ID.Name = "fieldINDIRIM_FAIZ_DOVIZ_ID";
            fieldINDIRIM_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_GIDER_VERGISI.AreaIndex = 32;
            fieldINDIRIM_GIDER_VERGISI.FieldName = "INDIRIM_GIDER_VERGISI";
            fieldINDIRIM_GIDER_VERGISI.Name = "fieldINDIRIM_GIDER_VERGISI";
            fieldINDIRIM_GIDER_VERGISI.Visible = false;

            PivotGridField fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 33;
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.FieldName = "INDIRIM_GIDER_VERGISI_DOVIZ_ID";
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.Name = "fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID";
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KALAN.AreaIndex = 34;
            fieldINDIRIM_KALAN.FieldName = "INDIRIM_KALAN";
            fieldINDIRIM_KALAN.Name = "fieldINDIRIM_KALAN";
            fieldINDIRIM_KALAN.Visible = false;

            PivotGridField fieldINDIRIM_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KALAN_DOVIZ_ID.AreaIndex = 35;
            fieldINDIRIM_KALAN_DOVIZ_ID.FieldName = "INDIRIM_KALAN_DOVIZ_ID";
            fieldINDIRIM_KALAN_DOVIZ_ID.Name = "fieldINDIRIM_KALAN_DOVIZ_ID";
            fieldINDIRIM_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KOM_TAZ.AreaIndex = 36;
            fieldINDIRIM_KOM_TAZ.FieldName = "INDIRIM_KOM_TAZ";
            fieldINDIRIM_KOM_TAZ.Name = "fieldINDIRIM_KOM_TAZ";
            fieldINDIRIM_KOM_TAZ.Visible = false;

            PivotGridField fieldINDIRIM_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_MASRAF.AreaIndex = 37;
            fieldINDIRIM_MASRAF.FieldName = "INDIRIM_MASRAF";
            fieldINDIRIM_MASRAF.Name = "fieldINDIRIM_MASRAF";
            fieldINDIRIM_MASRAF.Visible = false;

            PivotGridField fieldINDIRIM_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.AreaIndex = 38;
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.FieldName = "INDIRIM_KOM_TAZ_DOVIZ_ID";
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.Name = "fieldINDIRIM_KOM_TAZ_DOVIZ_ID";
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_MASRAF_DOVIZ_ID.AreaIndex = 39;
            fieldINDIRIM_MASRAF_DOVIZ_ID.FieldName = "INDIRIM_MASRAF_DOVIZ_ID";
            fieldINDIRIM_MASRAF_DOVIZ_ID.Name = "fieldINDIRIM_MASRAF_DOVIZ_ID";
            fieldINDIRIM_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_VEKALET_UCRETI.AreaIndex = 40;
            fieldINDIRIM_VEKALET_UCRETI.FieldName = "INDIRIM_VEKALET_UCRETI";
            fieldINDIRIM_VEKALET_UCRETI.Name = "fieldINDIRIM_VEKALET_UCRETI";
            fieldINDIRIM_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 41;
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.FieldName = "INDIRIM_VEKALET_UCRETI_DOVIZ_ID";
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID";
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_ANAPARA.AreaIndex = 42;
            fieldKALAN_ANAPARA.FieldName = "KALAN_ANAPARA";
            fieldKALAN_ANAPARA.Name = "fieldKALAN_ANAPARA";
            fieldKALAN_ANAPARA.Visible = false;

            PivotGridField fieldKALAN_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_ANAPARA_DOVIZ_ID.AreaIndex = 43;
            fieldKALAN_ANAPARA_DOVIZ_ID.FieldName = "KALAN_ANAPARA_DOVIZ_ID";
            fieldKALAN_ANAPARA_DOVIZ_ID.Name = "fieldKALAN_ANAPARA_DOVIZ_ID";
            fieldKALAN_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_BANKA_BAKIYESI.AreaIndex = 44;
            fieldKALAN_BANKA_BAKIYESI.FieldName = "KALAN_BANKA_BAKIYESI";
            fieldKALAN_BANKA_BAKIYESI.Name = "fieldKALAN_BANKA_BAKIYESI";
            fieldKALAN_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 45;
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "KALAN_BANKA_BAKIYESI_DOVIZ_ID";
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID";
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_FAIZ.AreaIndex = 46;
            fieldKALAN_FAIZ.FieldName = "KALAN_FAIZ";
            fieldKALAN_FAIZ.Name = "fieldKALAN_FAIZ";
            fieldKALAN_FAIZ.Visible = false;

            PivotGridField fieldKALAN_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_FAIZ_DOVIZ_ID.AreaIndex = 47;
            fieldKALAN_FAIZ_DOVIZ_ID.FieldName = "KALAN_FAIZ_DOVIZ_ID";
            fieldKALAN_FAIZ_DOVIZ_ID.Name = "fieldKALAN_FAIZ_DOVIZ_ID";
            fieldKALAN_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_GIDER_VERGISI.AreaIndex = 48;
            fieldKALAN_GIDER_VERGISI.FieldName = "KALAN_GIDER_VERGISI";
            fieldKALAN_GIDER_VERGISI.Name = "fieldKALAN_GIDER_VERGISI";
            fieldKALAN_GIDER_VERGISI.Visible = false;

            PivotGridField fieldKALAN_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 49;
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.FieldName = "KALAN_GIDER_VERGISI_DOVIZ_ID";
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.Name = "fieldKALAN_GIDER_VERGISI_DOVIZ_ID";
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KALAN.AreaIndex = 50;
            fieldKALAN_KALAN.FieldName = "KALAN_KALAN";
            fieldKALAN_KALAN.Name = "fieldKALAN_KALAN";
            fieldKALAN_KALAN.Visible = false;

            PivotGridField fieldKALAN_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KOM_TAZ.AreaIndex = 51;
            fieldKALAN_KOM_TAZ.FieldName = "KALAN_KOM_TAZ";
            fieldKALAN_KOM_TAZ.Name = "fieldKALAN_KOM_TAZ";
            fieldKALAN_KOM_TAZ.Visible = false;

            PivotGridField fieldKALAN_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KALAN_DOVIZ_ID.AreaIndex = 52;
            fieldKALAN_KALAN_DOVIZ_ID.FieldName = "KALAN_KALAN_DOVIZ_ID";
            fieldKALAN_KALAN_DOVIZ_ID.Name = "fieldKALAN_KALAN_DOVIZ_ID";
            fieldKALAN_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KOM_TAZ_DOVIZ_ID.AreaIndex = 53;
            fieldKALAN_KOM_TAZ_DOVIZ_ID.FieldName = "KALAN_KOM_TAZ_DOVIZ_ID";
            fieldKALAN_KOM_TAZ_DOVIZ_ID.Name = "fieldKALAN_KOM_TAZ_DOVIZ_ID";
            fieldKALAN_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_MASRAF.AreaIndex = 54;
            fieldKALAN_MASRAF.FieldName = "KALAN_MASRAF";
            fieldKALAN_MASRAF.Name = "fieldKALAN_MASRAF";
            fieldKALAN_MASRAF.Visible = false;

            PivotGridField fieldKALAN_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_MASRAF_DOVIZ_ID.AreaIndex = 55;
            fieldKALAN_MASRAF_DOVIZ_ID.FieldName = "KALAN_MASRAF_DOVIZ_ID";
            fieldKALAN_MASRAF_DOVIZ_ID.Name = "fieldKALAN_MASRAF_DOVIZ_ID";
            fieldKALAN_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_VEKALET_UCRETI.AreaIndex = 56;
            fieldKALAN_VEKALET_UCRETI.FieldName = "KALAN_VEKALET_UCRETI";
            fieldKALAN_VEKALET_UCRETI.Name = "fieldKALAN_VEKALET_UCRETI";
            fieldKALAN_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldKALAN_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 57;
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.FieldName = "KALAN_VEKALET_UCRETI_DOVIZ_ID";
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldKALAN_VEKALET_UCRETI_DOVIZ_ID";
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_ANAPARA.AreaIndex = 58;
            fieldODEME_ANAPARA.FieldName = "ODEME_ANAPARA";
            fieldODEME_ANAPARA.Name = "fieldODEME_ANAPARA";
            fieldODEME_ANAPARA.Visible = false;

            PivotGridField fieldODEME_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_ANAPARA_DOVIZ_ID.AreaIndex = 59;
            fieldODEME_ANAPARA_DOVIZ_ID.FieldName = "ODEME_ANAPARA_DOVIZ_ID";
            fieldODEME_ANAPARA_DOVIZ_ID.Name = "fieldODEME_ANAPARA_DOVIZ_ID";
            fieldODEME_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_BANKA_BAKIYESI.AreaIndex = 60;
            fieldODEME_BANKA_BAKIYESI.FieldName = "ODEME_BANKA_BAKIYESI";
            fieldODEME_BANKA_BAKIYESI.Name = "fieldODEME_BANKA_BAKIYESI";
            fieldODEME_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldODEME_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 61;
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "ODEME_BANKA_BAKIYESI_DOVIZ_ID";
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldODEME_BANKA_BAKIYESI_DOVIZ_ID";
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_FAIZ_DOVIZ_ID.AreaIndex = 62;
            fieldODEME_FAIZ_DOVIZ_ID.FieldName = "ODEME_FAIZ_DOVIZ_ID";
            fieldODEME_FAIZ_DOVIZ_ID.Name = "fieldODEME_FAIZ_DOVIZ_ID";
            fieldODEME_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_FAIZ.AreaIndex = 63;
            fieldODEME_FAIZ.FieldName = "ODEME_FAIZ";
            fieldODEME_FAIZ.Name = "fieldODEME_FAIZ";
            fieldODEME_FAIZ.Visible = false;

            PivotGridField fieldODEME_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_GIDER_VERGISI.AreaIndex = 64;
            fieldODEME_GIDER_VERGISI.FieldName = "ODEME_GIDER_VERGISI";
            fieldODEME_GIDER_VERGISI.Name = "fieldODEME_GIDER_VERGISI";
            fieldODEME_GIDER_VERGISI.Visible = false;

            PivotGridField fieldODEME_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 65;
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.FieldName = "ODEME_GIDER_VERGISI_DOVIZ_ID";
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.Name = "fieldODEME_GIDER_VERGISI_DOVIZ_ID";
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KALAN.AreaIndex = 66;
            fieldODEME_KALAN.FieldName = "ODEME_KALAN";
            fieldODEME_KALAN.Name = "fieldODEME_KALAN";
            fieldODEME_KALAN.Visible = false;

            PivotGridField fieldODEME_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KALAN_DOVIZ_ID.AreaIndex = 67;
            fieldODEME_KALAN_DOVIZ_ID.FieldName = "ODEME_KALAN_DOVIZ_ID";
            fieldODEME_KALAN_DOVIZ_ID.Name = "fieldODEME_KALAN_DOVIZ_ID";
            fieldODEME_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KOM_TAZ.AreaIndex = 68;
            fieldODEME_KOM_TAZ.FieldName = "ODEME_KOM_TAZ";
            fieldODEME_KOM_TAZ.Name = "fieldODEME_KOM_TAZ";
            fieldODEME_KOM_TAZ.Visible = false;

            PivotGridField fieldODEME_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KOM_TAZ_DOVIZ_ID.AreaIndex = 69;
            fieldODEME_KOM_TAZ_DOVIZ_ID.FieldName = "ODEME_KOM_TAZ_DOVIZ_ID";
            fieldODEME_KOM_TAZ_DOVIZ_ID.Name = "fieldODEME_KOM_TAZ_DOVIZ_ID";
            fieldODEME_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MASRAF.AreaIndex = 70;
            fieldODEME_MASRAF.FieldName = "ODEME_MASRAF";
            fieldODEME_MASRAF.Name = "fieldODEME_MASRAF";
            fieldODEME_MASRAF.Visible = false;

            PivotGridField fieldODEME_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MASRAF_DOVIZ_ID.AreaIndex = 71;
            fieldODEME_MASRAF_DOVIZ_ID.FieldName = "ODEME_MASRAF_DOVIZ_ID";
            fieldODEME_MASRAF_DOVIZ_ID.Name = "fieldODEME_MASRAF_DOVIZ_ID";
            fieldODEME_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_VEKALET_UCRETI.AreaIndex = 72;
            fieldODEME_VEKALET_UCRETI.FieldName = "ODEME_VEKALET_UCRETI";
            fieldODEME_VEKALET_UCRETI.Name = "fieldODEME_VEKALET_UCRETI";
            fieldODEME_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldODEME_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 73;
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.FieldName = "ODEME_VEKALET_UCRETI_DOVIZ_ID";
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldODEME_VEKALET_UCRETI_DOVIZ_ID";
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_ANAPARA.AreaIndex = 74;
            fieldTUTAR_ANAPARA.FieldName = "TUTAR_ANAPARA";
            fieldTUTAR_ANAPARA.Name = "fieldTUTAR_ANAPARA";
            fieldTUTAR_ANAPARA.Visible = false;

            PivotGridField fieldTUTAR_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_ANAPARA_DOVIZ_ID.AreaIndex = 75;
            fieldTUTAR_ANAPARA_DOVIZ_ID.FieldName = "TUTAR_ANAPARA_DOVIZ_ID";
            fieldTUTAR_ANAPARA_DOVIZ_ID.Name = "fieldTUTAR_ANAPARA_DOVIZ_ID";
            fieldTUTAR_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_BANKA_BAKIYESI.AreaIndex = 76;
            fieldTUTAR_BANKA_BAKIYESI.FieldName = "TUTAR_BANKA_BAKIYESI";
            fieldTUTAR_BANKA_BAKIYESI.Name = "fieldTUTAR_BANKA_BAKIYESI";
            fieldTUTAR_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 77;
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "TUTAR_BANKA_BAKIYESI_DOVIZ_ID";
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID";
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_FAIZ.AreaIndex = 78;
            fieldTUTAR_FAIZ.FieldName = "TUTAR_FAIZ";
            fieldTUTAR_FAIZ.Name = "fieldTUTAR_FAIZ";
            fieldTUTAR_FAIZ.Visible = false;

            PivotGridField fieldTUTAR_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_FAIZ_DOVIZ_ID.AreaIndex = 79;
            fieldTUTAR_FAIZ_DOVIZ_ID.FieldName = "TUTAR_FAIZ_DOVIZ_ID";
            fieldTUTAR_FAIZ_DOVIZ_ID.Name = "fieldTUTAR_FAIZ_DOVIZ_ID";
            fieldTUTAR_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_GIDER_VERGISI.AreaIndex = 80;
            fieldTUTAR_GIDER_VERGISI.FieldName = "TUTAR_GIDER_VERGISI";
            fieldTUTAR_GIDER_VERGISI.Name = "fieldTUTAR_GIDER_VERGISI";
            fieldTUTAR_GIDER_VERGISI.Visible = false;

            PivotGridField fieldTUTAR_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 81;
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.FieldName = "TUTAR_GIDER_VERGISI_DOVIZ_ID";
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.Name = "fieldTUTAR_GIDER_VERGISI_DOVIZ_ID";
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KALAN.AreaIndex = 82;
            fieldTUTAR_KALAN.FieldName = "TUTAR_KALAN";
            fieldTUTAR_KALAN.Name = "fieldTUTAR_KALAN";
            fieldTUTAR_KALAN.Visible = false;

            PivotGridField fieldTUTAR_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KALAN_DOVIZ_ID.AreaIndex = 83;
            fieldTUTAR_KALAN_DOVIZ_ID.FieldName = "TUTAR_KALAN_DOVIZ_ID";
            fieldTUTAR_KALAN_DOVIZ_ID.Name = "fieldTUTAR_KALAN_DOVIZ_ID";
            fieldTUTAR_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KOM_TAZ.AreaIndex = 84;
            fieldTUTAR_KOM_TAZ.FieldName = "TUTAR_KOM_TAZ";
            fieldTUTAR_KOM_TAZ.Name = "fieldTUTAR_KOM_TAZ";
            fieldTUTAR_KOM_TAZ.Visible = false;

            PivotGridField fieldTUTAR_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.AreaIndex = 85;
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.FieldName = "TUTAR_KOM_TAZ_DOVIZ_ID";
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.Name = "fieldTUTAR_KOM_TAZ_DOVIZ_ID";
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_MASRAF.AreaIndex = 86;
            fieldTUTAR_MASRAF.FieldName = "TUTAR_MASRAF";
            fieldTUTAR_MASRAF.Name = "fieldTUTAR_MASRAF";
            fieldTUTAR_MASRAF.Visible = false;

            PivotGridField fieldTUTAR_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_MASRAF_DOVIZ_ID.AreaIndex = 87;
            fieldTUTAR_MASRAF_DOVIZ_ID.FieldName = "TUTAR_MASRAF_DOVIZ_ID";
            fieldTUTAR_MASRAF_DOVIZ_ID.Name = "fieldTUTAR_MASRAF_DOVIZ_ID";
            fieldTUTAR_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_VEKALET_UCRETI.AreaIndex = 88;
            fieldTUTAR_VEKALET_UCRETI.FieldName = "TUTAR_VEKALET_UCRETI";
            fieldTUTAR_VEKALET_UCRETI.Name = "fieldTUTAR_VEKALET_UCRETI";
            fieldTUTAR_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 89;
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TUTAR_VEKALET_UCRETI_DOVIZ_ID";
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID";
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSON_HESAP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSON_HESAP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSON_HESAP_TARIHI.AreaIndex = 90;
            fieldSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Name = "fieldSON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Visible = false;

            PivotGridField fieldHESAPLAMA_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHESAPLAMA_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHESAPLAMA_TIPI.AreaIndex = 91;
            fieldHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            fieldHESAPLAMA_TIPI.Name = "fieldHESAPLAMA_TIPI";
            fieldHESAPLAMA_TIPI.Visible = false;

            PivotGridField fieldRISK_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_TOPLAMI.AreaIndex = 92;
            fieldRISK_TOPLAMI.FieldName = "RISK_TOPLAMI";
            fieldRISK_TOPLAMI.Name = "fieldRISK_TOPLAMI";
            fieldRISK_TOPLAMI.Visible = false;

            PivotGridField fieldRISK_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_TOPLAMI_DOVIZ_ID.AreaIndex = 93;
            fieldRISK_TOPLAMI_DOVIZ_ID.FieldName = "RISK_TOPLAMI_DOVIZ_ID";
            fieldRISK_TOPLAMI_DOVIZ_ID.Name = "fieldRISK_TOPLAMI_DOVIZ_ID";
            fieldRISK_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 94;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = null;
            switch (pencere)
            {
                case "Krediler Bazında Klasörlerin Dağılımı":
                    dizi = KredilerBazindaKlasorlerinDagilimi();
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
			fieldPROJE_ID,
			fieldKOD,
			fieldADI,
			fieldBITIS_TARIHI,
			fieldBASLANGIC_TARIHI,
			fieldSUBE_KOD_ID,
			fieldKONTROL_KIM_ID,
			fieldPROJE_TARAFI,
			fieldPROJE_SORUMLU,
			fieldPROJE_YETKILI,
			fieldFOY_NO,
			fieldADLIYE,
			fieldNO,
			fieldESAS_NO,
			fieldALACAK_NEDENI,
			fieldVADE_TARIHI,
			fieldTAKIP_TARIHI,
			fieldDUZENLENME_TARIHI,
			fieldTUTARI,
			fieldTUTAR_DOVIZ_ID,
			fieldISLEME_KONAN_TUTAR,
			fieldISLEME_KONAN_TUTAR_DOVIZ_ID,
			fieldTO_UYGULANACAK_FAIZ_ORANI,
			fieldFAIZ_TIP,
			fieldTAKIP_DURUMU,
			fieldPROJE_ALACAK_NEDEN_ID,
			fieldINDIRIM_ANAPARA,
			fieldINDIRIM_ANAPARA_DOVIZ_ID,
			fieldINDIRIM_BANKA_BAKIYESI,
			fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID,
			fieldINDIRIM_FAIZ,
			fieldINDIRIM_FAIZ_DOVIZ_ID,
			fieldINDIRIM_GIDER_VERGISI,
			fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID,
			fieldINDIRIM_KALAN,
			fieldINDIRIM_KALAN_DOVIZ_ID,
			fieldINDIRIM_KOM_TAZ,
			fieldINDIRIM_MASRAF,
			fieldINDIRIM_KOM_TAZ_DOVIZ_ID,
			fieldINDIRIM_MASRAF_DOVIZ_ID,
			fieldINDIRIM_VEKALET_UCRETI,
			fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID,
			fieldKALAN_ANAPARA,
			fieldKALAN_ANAPARA_DOVIZ_ID,
			fieldKALAN_BANKA_BAKIYESI,
			fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID,
			fieldKALAN_FAIZ,
			fieldKALAN_FAIZ_DOVIZ_ID,
			fieldKALAN_GIDER_VERGISI,
			fieldKALAN_GIDER_VERGISI_DOVIZ_ID,
			fieldKALAN_KALAN,
			fieldKALAN_KOM_TAZ,
			fieldKALAN_KALAN_DOVIZ_ID,
			fieldKALAN_KOM_TAZ_DOVIZ_ID,
			fieldKALAN_MASRAF,
			fieldKALAN_MASRAF_DOVIZ_ID,
			fieldKALAN_VEKALET_UCRETI,
			fieldKALAN_VEKALET_UCRETI_DOVIZ_ID,
			fieldODEME_ANAPARA,
			fieldODEME_ANAPARA_DOVIZ_ID,
			fieldODEME_BANKA_BAKIYESI,
			fieldODEME_BANKA_BAKIYESI_DOVIZ_ID,
			fieldODEME_FAIZ_DOVIZ_ID,
			fieldODEME_FAIZ,
			fieldODEME_GIDER_VERGISI,
			fieldODEME_GIDER_VERGISI_DOVIZ_ID,
			fieldODEME_KALAN,
			fieldODEME_KALAN_DOVIZ_ID,
			fieldODEME_KOM_TAZ,
			fieldODEME_KOM_TAZ_DOVIZ_ID,
			fieldODEME_MASRAF,
			fieldODEME_MASRAF_DOVIZ_ID,
			fieldODEME_VEKALET_UCRETI,
			fieldODEME_VEKALET_UCRETI_DOVIZ_ID,
			fieldTUTAR_ANAPARA,
			fieldTUTAR_ANAPARA_DOVIZ_ID,
			fieldTUTAR_BANKA_BAKIYESI,
			fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID,
			fieldTUTAR_FAIZ,
			fieldTUTAR_FAIZ_DOVIZ_ID,
			fieldTUTAR_GIDER_VERGISI,
			fieldTUTAR_GIDER_VERGISI_DOVIZ_ID,
			fieldTUTAR_KALAN,
			fieldTUTAR_KALAN_DOVIZ_ID,
			fieldTUTAR_KOM_TAZ,
			fieldTUTAR_KOM_TAZ_DOVIZ_ID,
			fieldTUTAR_MASRAF,
			fieldTUTAR_MASRAF_DOVIZ_ID,
			fieldTUTAR_VEKALET_UCRETI,
			fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID,
			fieldSON_HESAP_TARIHI,
			fieldHESAPLAMA_TIPI,
			fieldRISK_TOPLAMI,
			fieldRISK_TOPLAMI_DOVIZ_ID,
            fieldBOLUM,
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

            dicFieldCaption.Add("PROJE_ID", "Proje ID");
            dicFieldCaption.Add("KOD", "Kod");
            dicFieldCaption.Add("ADI", "Adı");
            dicFieldCaption.Add("BITIS_TARIHI", "Bitiş T.");
            dicFieldCaption.Add("BASLANGIC_TARIHI", "Başlangıç T.");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("PROJE_TARAFI", "Taraf");
            dicFieldCaption.Add("PROJE_SORUMLU", "Sorumlu");
            dicFieldCaption.Add("PROJE_YETKILI", "Yetkili");
            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("ADLIYE", "Adliye");
            dicFieldCaption.Add("NO", "No");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("ALACAK_NEDENI", "Alacak Nedeni");
            dicFieldCaption.Add("VADE_TARIHI", "Vade T.");
            dicFieldCaption.Add("TAKIP_TARIHI", "Takip T.");
            dicFieldCaption.Add("DUZENLENME_TARIHI", "Düzenleme T.");
            dicFieldCaption.Add("TUTARI", "Tutarı");
            dicFieldCaption.Add("ISLEME_KONAN_TUTAR", "İşleme Konan Tutar");
            dicFieldCaption.Add("TO_UYGULANACAK_FAIZ_ORANI", "T.Ö Uygulanacak Faiz Oranı");
            dicFieldCaption.Add("FAIZ_TIP", "Faiz Tip");
            dicFieldCaption.Add("TAKIP_DURUMU", "Takip Durumu");
            dicFieldCaption.Add("PROJE_ALACAK_NEDEN_ID", "Dosya Sayısı");
            dicFieldCaption.Add("INDIRIM_ANAPARA", "İndirim Ana Para");
            dicFieldCaption.Add("INDIRIM_BANKA_BAKIYESI", "İndirim Banka Bakiyesi");
            dicFieldCaption.Add("INDIRIM_FAIZ", "İndirim Faiz");
            dicFieldCaption.Add("INDIRIM_GIDER_VERGISI", "İndirim Gider Vergisi");
            dicFieldCaption.Add("INDIRIM_KALAN", "İndirim Kalan");
            dicFieldCaption.Add("INDIRIM_KOM_TAZ", "İndirim Kom. Taz.");
            dicFieldCaption.Add("INDIRIM_MASRAF", "İndirim Masraf");
            dicFieldCaption.Add("INDIRIM_VEKALET_UCRETI", "İndirim Vekalet Ücreti");
            dicFieldCaption.Add("KALAN_ANAPARA", "Kalan AnaPara");
            dicFieldCaption.Add("KALAN_BANKA_BAKIYESI", "Kalan Banka Bakiyesi");
            dicFieldCaption.Add("KALAN_FAIZ", "Kalan Faiz");
            dicFieldCaption.Add("KALAN_GIDER_VERGISI", "Kalan Gider Vergisi");
            dicFieldCaption.Add("KALAN_KALAN", "Kalan");
            dicFieldCaption.Add("KALAN_KOM_TAZ", "Kalan Kom. Taz.");
            dicFieldCaption.Add("KALAN_MASRAF", "Kalan Masraf");
            dicFieldCaption.Add("KALAN_VEKALET_UCRETI", "Kalan Vekalet Ücreti");
            dicFieldCaption.Add("ODEME_ANAPARA", "Ödeme AnaPara");
            dicFieldCaption.Add("ODEME_BANKA_BAKIYESI", "Ödeme Banka Bakiyesi");
            dicFieldCaption.Add("ODEME_FAIZ", "Ödeme Faiz");
            dicFieldCaption.Add("ODEME_GIDER_VERGISI", "Ödeme Gider Vergisi");
            dicFieldCaption.Add("ODEME_KALAN", "Ödeme Kalan");
            dicFieldCaption.Add("ODEME_KOM_TAZ", "Ödeme Kom. Taz.");
            dicFieldCaption.Add("ODEME_MASRAF", "Ödeme Masraf");
            dicFieldCaption.Add("ODEME_VEKALET_UCRETI", "Ödeme Vekalet Ücreti");
            dicFieldCaption.Add("TUTAR_ANAPARA", "Tutar Anapara");
            dicFieldCaption.Add("TUTAR_BANKA_BAKIYESI", "Tutar Banka Bakiyesi");
            dicFieldCaption.Add("TUTAR_FAIZ", "Tutar Faiz");
            dicFieldCaption.Add("TUTAR_GIDER_VERGISI", "Tutar Gider Vergisi");
            dicFieldCaption.Add("TUTAR_KALAN", "Tutar Kalan");
            dicFieldCaption.Add("TUTAR_KOM_TAZ", "Tutar Kom. Taz.");
            dicFieldCaption.Add("TUTAR_MASRAF", "Tutar Masraf");
            dicFieldCaption.Add("TUTAR_VEKALET_UCRETI", "Tutar Vekalet Ücreti");
            dicFieldCaption.Add("SON_HESAP_TARIHI", "Son Hesap T.");
            dicFieldCaption.Add("HESAPLAMA_TIPI", "Hesaplama Tipi");
            dicFieldCaption.Add("RISK_TOPLAMI", "Risk Toplamı");
            dicFieldCaption.Add("BOLUM", "Bölüm");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();
            //Inits.DovizTipGetir(rlueDoviz);
            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("DovizId", InitsEx.DovizTipGetir);

            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("TUTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TUTAR_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("ISLEME_KONAN_TUTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("ISLEME_KONAN_TUTAR_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("INDIRIM_KALAN", InitsEx.DovizTipGetir);
            sozluk.Add("KALAN_ANAPARA", InitsEx.DovizTipGetir);
            sozluk.Add("KALAN_BANKA_BAKIYESI", InitsEx.DovizTipGetir);
            sozluk.Add("KALAN_FAIZ", InitsEx.DovizTipGetir);
            sozluk.Add("KALAN_GIDER_VERGISI", InitsEx.DovizTipGetir);
            sozluk.Add("KALAN_KALAN", InitsEx.DovizTipGetir);
            sozluk.Add("KALAN_KOM_TAZ", InitsEx.DovizTipGetir);
            sozluk.Add("KALAN_MASRAF", InitsEx.DovizTipGetir);
            sozluk.Add("KALAN_VEKALET_UCRETI", InitsEx.DovizTipGetir);
            sozluk.Add("ODEME_KALAN", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_ANAPARA", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_ANAPARA_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_BANKA_BAKIYESI", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_BANKA_BAKIYESI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_FAIZ", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_FAIZ_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_GIDER_VERGISI", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_GIDER_VERGISI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_KALAN", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_KALAN_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_KOM_TAZ", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_KOM_TAZ_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_MASRAF", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_MASRAF_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_VEKALET_UCRETI", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_VEKALET_UCRETI_DOVIZ_ID", InitsEx.DovizTipGetir);

            #endregion Add item

            return sozluk;
        }

        private PivotGridField[] KredilerBazindaKlasorlerinDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldPROJE_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_ID.AreaIndex = 0;
            fieldPROJE_ID.FieldName = "PROJE_ID";
            fieldPROJE_ID.Name = "fieldPROJE_ID";
            fieldPROJE_ID.Visible = false;

            PivotGridField fieldKOD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKOD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKOD.AreaIndex = 1;
            fieldKOD.FieldName = "KOD";
            fieldKOD.Name = "fieldKOD";
            fieldKOD.Visible = false;

            PivotGridField fieldADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADI.AreaIndex = 2;
            fieldADI.FieldName = "ADI";
            fieldADI.Name = "fieldADI";
            fieldADI.Visible = false;

            PivotGridField fieldBITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_TARIHI.AreaIndex = 3;
            fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
            fieldBITIS_TARIHI.Visible = false;

            PivotGridField fieldBASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASLANGIC_TARIHI.AreaIndex = 4;
            fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 5;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 6;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldPROJE_TARAFI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_TARAFI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_TARAFI.AreaIndex = 7;
            fieldPROJE_TARAFI.FieldName = "PROJE_TARAFI";
            fieldPROJE_TARAFI.Name = "fieldPROJE_TARAFI";
            fieldPROJE_TARAFI.Visible = false;

            PivotGridField fieldPROJE_SORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_SORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_SORUMLU.AreaIndex = 8;
            fieldPROJE_SORUMLU.FieldName = "PROJE_SORUMLU";
            fieldPROJE_SORUMLU.Name = "fieldPROJE_SORUMLU";
            fieldPROJE_SORUMLU.Visible = false;

            PivotGridField fieldPROJE_YETKILI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_YETKILI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_YETKILI.AreaIndex = 9;
            fieldPROJE_YETKILI.FieldName = "PROJE_YETKILI";
            fieldPROJE_YETKILI.Name = "fieldPROJE_YETKILI";
            fieldPROJE_YETKILI.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 10;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 11;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 12;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 13;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldALACAK_NEDENI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_NEDENI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_NEDENI.AreaIndex = 14;
            fieldALACAK_NEDENI.FieldName = "ALACAK_NEDENI";
            fieldALACAK_NEDENI.Name = "fieldALACAK_NEDENI";
            fieldALACAK_NEDENI.Visible = false;

            PivotGridField fieldVADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVADE_TARIHI.AreaIndex = 15;
            fieldVADE_TARIHI.FieldName = "VADE_TARIHI";
            fieldVADE_TARIHI.Name = "fieldVADE_TARIHI";
            fieldVADE_TARIHI.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 16;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldDUZENLENME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDUZENLENME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDUZENLENME_TARIHI.AreaIndex = 17;
            fieldDUZENLENME_TARIHI.FieldName = "DUZENLENME_TARIHI";
            fieldDUZENLENME_TARIHI.Name = "fieldDUZENLENME_TARIHI";
            fieldDUZENLENME_TARIHI.Visible = false;

            PivotGridField fieldTUTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTARI.AreaIndex = 18;
            fieldTUTARI.FieldName = "TUTARI";
            fieldTUTARI.Name = "fieldTUTARI";
            fieldTUTARI.Visible = false;

            PivotGridField fieldTUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_DOVIZ_ID.AreaIndex = 19;
            fieldTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            fieldTUTAR_DOVIZ_ID.Name = "fieldTUTAR_DOVIZ_ID";
            fieldTUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldISLEME_KONAN_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEME_KONAN_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEME_KONAN_TUTAR.AreaIndex = 20;
            fieldISLEME_KONAN_TUTAR.FieldName = "ISLEME_KONAN_TUTAR";
            fieldISLEME_KONAN_TUTAR.Name = "fieldISLEME_KONAN_TUTAR";
            fieldISLEME_KONAN_TUTAR.Visible = false;

            PivotGridField fieldISLEME_KONAN_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEME_KONAN_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEME_KONAN_TUTAR_DOVIZ_ID.AreaIndex = 21;
            fieldISLEME_KONAN_TUTAR_DOVIZ_ID.FieldName = "ISLEME_KONAN_TUTAR_DOVIZ_ID";
            fieldISLEME_KONAN_TUTAR_DOVIZ_ID.Name = "fieldISLEME_KONAN_TUTAR_DOVIZ_ID";
            fieldISLEME_KONAN_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_UYGULANACAK_FAIZ_ORANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_UYGULANACAK_FAIZ_ORANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_UYGULANACAK_FAIZ_ORANI.AreaIndex = 22;
            fieldTO_UYGULANACAK_FAIZ_ORANI.FieldName = "TO_UYGULANACAK_FAIZ_ORANI";
            fieldTO_UYGULANACAK_FAIZ_ORANI.Name = "fieldTO_UYGULANACAK_FAIZ_ORANI";
            fieldTO_UYGULANACAK_FAIZ_ORANI.Visible = false;

            PivotGridField fieldFAIZ_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFAIZ_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFAIZ_TIP.AreaIndex = 23;
            fieldFAIZ_TIP.FieldName = "FAIZ_TIP";
            fieldFAIZ_TIP.Name = "fieldFAIZ_TIP";
            fieldFAIZ_TIP.Visible = false;

            PivotGridField fieldTAKIP_DURUMU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_DURUMU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_DURUMU.AreaIndex = 24;
            fieldTAKIP_DURUMU.FieldName = "TAKIP_DURUMU";
            fieldTAKIP_DURUMU.Name = "fieldTAKIP_DURUMU";
            fieldTAKIP_DURUMU.Visible = false;

            PivotGridField fieldPROJE_ALACAK_NEDEN_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_ALACAK_NEDEN_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_ALACAK_NEDEN_ID.AreaIndex = 25;
            fieldPROJE_ALACAK_NEDEN_ID.FieldName = "PROJE_ALACAK_NEDEN_ID";
            fieldPROJE_ALACAK_NEDEN_ID.Name = "fieldPROJE_ALACAK_NEDEN_ID";
            fieldPROJE_ALACAK_NEDEN_ID.Visible = false;

            PivotGridField fieldINDIRIM_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_ANAPARA.AreaIndex = 26;
            fieldINDIRIM_ANAPARA.FieldName = "INDIRIM_ANAPARA";
            fieldINDIRIM_ANAPARA.Name = "fieldINDIRIM_ANAPARA";
            fieldINDIRIM_ANAPARA.Visible = false;

            PivotGridField fieldINDIRIM_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_ANAPARA_DOVIZ_ID.AreaIndex = 27;
            fieldINDIRIM_ANAPARA_DOVIZ_ID.FieldName = "INDIRIM_ANAPARA_DOVIZ_ID";
            fieldINDIRIM_ANAPARA_DOVIZ_ID.Name = "fieldINDIRIM_ANAPARA_DOVIZ_ID";
            fieldINDIRIM_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_BANKA_BAKIYESI.AreaIndex = 28;
            fieldINDIRIM_BANKA_BAKIYESI.FieldName = "INDIRIM_BANKA_BAKIYESI";
            fieldINDIRIM_BANKA_BAKIYESI.Name = "fieldINDIRIM_BANKA_BAKIYESI";
            fieldINDIRIM_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 29;
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "INDIRIM_BANKA_BAKIYESI_DOVIZ_ID";
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID";
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_FAIZ.AreaIndex = 30;
            fieldINDIRIM_FAIZ.FieldName = "INDIRIM_FAIZ";
            fieldINDIRIM_FAIZ.Name = "fieldINDIRIM_FAIZ";
            fieldINDIRIM_FAIZ.Visible = false;

            PivotGridField fieldINDIRIM_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_FAIZ_DOVIZ_ID.AreaIndex = 31;
            fieldINDIRIM_FAIZ_DOVIZ_ID.FieldName = "INDIRIM_FAIZ_DOVIZ_ID";
            fieldINDIRIM_FAIZ_DOVIZ_ID.Name = "fieldINDIRIM_FAIZ_DOVIZ_ID";
            fieldINDIRIM_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_GIDER_VERGISI.AreaIndex = 32;
            fieldINDIRIM_GIDER_VERGISI.FieldName = "INDIRIM_GIDER_VERGISI";
            fieldINDIRIM_GIDER_VERGISI.Name = "fieldINDIRIM_GIDER_VERGISI";
            fieldINDIRIM_GIDER_VERGISI.Visible = false;

            PivotGridField fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 33;
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.FieldName = "INDIRIM_GIDER_VERGISI_DOVIZ_ID";
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.Name = "fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID";
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KALAN.AreaIndex = 34;
            fieldINDIRIM_KALAN.FieldName = "INDIRIM_KALAN";
            fieldINDIRIM_KALAN.Name = "fieldINDIRIM_KALAN";
            fieldINDIRIM_KALAN.Visible = false;

            PivotGridField fieldINDIRIM_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KALAN_DOVIZ_ID.AreaIndex = 35;
            fieldINDIRIM_KALAN_DOVIZ_ID.FieldName = "INDIRIM_KALAN_DOVIZ_ID";
            fieldINDIRIM_KALAN_DOVIZ_ID.Name = "fieldINDIRIM_KALAN_DOVIZ_ID";
            fieldINDIRIM_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KOM_TAZ.AreaIndex = 36;
            fieldINDIRIM_KOM_TAZ.FieldName = "INDIRIM_KOM_TAZ";
            fieldINDIRIM_KOM_TAZ.Name = "fieldINDIRIM_KOM_TAZ";
            fieldINDIRIM_KOM_TAZ.Visible = false;

            PivotGridField fieldINDIRIM_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_MASRAF.AreaIndex = 37;
            fieldINDIRIM_MASRAF.FieldName = "INDIRIM_MASRAF";
            fieldINDIRIM_MASRAF.Name = "fieldINDIRIM_MASRAF";
            fieldINDIRIM_MASRAF.Visible = false;

            PivotGridField fieldINDIRIM_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.AreaIndex = 38;
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.FieldName = "INDIRIM_KOM_TAZ_DOVIZ_ID";
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.Name = "fieldINDIRIM_KOM_TAZ_DOVIZ_ID";
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_MASRAF_DOVIZ_ID.AreaIndex = 39;
            fieldINDIRIM_MASRAF_DOVIZ_ID.FieldName = "INDIRIM_MASRAF_DOVIZ_ID";
            fieldINDIRIM_MASRAF_DOVIZ_ID.Name = "fieldINDIRIM_MASRAF_DOVIZ_ID";
            fieldINDIRIM_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_VEKALET_UCRETI.AreaIndex = 40;
            fieldINDIRIM_VEKALET_UCRETI.FieldName = "INDIRIM_VEKALET_UCRETI";
            fieldINDIRIM_VEKALET_UCRETI.Name = "fieldINDIRIM_VEKALET_UCRETI";
            fieldINDIRIM_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 41;
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.FieldName = "INDIRIM_VEKALET_UCRETI_DOVIZ_ID";
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID";
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_ANAPARA.AreaIndex = 42;
            fieldKALAN_ANAPARA.FieldName = "KALAN_ANAPARA";
            fieldKALAN_ANAPARA.Name = "fieldKALAN_ANAPARA";
            fieldKALAN_ANAPARA.Visible = false;

            PivotGridField fieldKALAN_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_ANAPARA_DOVIZ_ID.AreaIndex = 43;
            fieldKALAN_ANAPARA_DOVIZ_ID.FieldName = "KALAN_ANAPARA_DOVIZ_ID";
            fieldKALAN_ANAPARA_DOVIZ_ID.Name = "fieldKALAN_ANAPARA_DOVIZ_ID";
            fieldKALAN_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_BANKA_BAKIYESI.AreaIndex = 44;
            fieldKALAN_BANKA_BAKIYESI.FieldName = "KALAN_BANKA_BAKIYESI";
            fieldKALAN_BANKA_BAKIYESI.Name = "fieldKALAN_BANKA_BAKIYESI";
            fieldKALAN_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 45;
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "KALAN_BANKA_BAKIYESI_DOVIZ_ID";
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID";
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_FAIZ.AreaIndex = 46;
            fieldKALAN_FAIZ.FieldName = "KALAN_FAIZ";
            fieldKALAN_FAIZ.Name = "fieldKALAN_FAIZ";
            fieldKALAN_FAIZ.Visible = false;

            PivotGridField fieldKALAN_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_FAIZ_DOVIZ_ID.AreaIndex = 47;
            fieldKALAN_FAIZ_DOVIZ_ID.FieldName = "KALAN_FAIZ_DOVIZ_ID";
            fieldKALAN_FAIZ_DOVIZ_ID.Name = "fieldKALAN_FAIZ_DOVIZ_ID";
            fieldKALAN_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_GIDER_VERGISI.AreaIndex = 48;
            fieldKALAN_GIDER_VERGISI.FieldName = "KALAN_GIDER_VERGISI";
            fieldKALAN_GIDER_VERGISI.Name = "fieldKALAN_GIDER_VERGISI";
            fieldKALAN_GIDER_VERGISI.Visible = false;

            PivotGridField fieldKALAN_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 49;
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.FieldName = "KALAN_GIDER_VERGISI_DOVIZ_ID";
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.Name = "fieldKALAN_GIDER_VERGISI_DOVIZ_ID";
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KALAN.AreaIndex = 50;
            fieldKALAN_KALAN.FieldName = "KALAN_KALAN";
            fieldKALAN_KALAN.Name = "fieldKALAN_KALAN";
            fieldKALAN_KALAN.Visible = false;

            PivotGridField fieldKALAN_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KOM_TAZ.AreaIndex = 51;
            fieldKALAN_KOM_TAZ.FieldName = "KALAN_KOM_TAZ";
            fieldKALAN_KOM_TAZ.Name = "fieldKALAN_KOM_TAZ";
            fieldKALAN_KOM_TAZ.Visible = false;

            PivotGridField fieldKALAN_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KALAN_DOVIZ_ID.AreaIndex = 52;
            fieldKALAN_KALAN_DOVIZ_ID.FieldName = "KALAN_KALAN_DOVIZ_ID";
            fieldKALAN_KALAN_DOVIZ_ID.Name = "fieldKALAN_KALAN_DOVIZ_ID";
            fieldKALAN_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KOM_TAZ_DOVIZ_ID.AreaIndex = 53;
            fieldKALAN_KOM_TAZ_DOVIZ_ID.FieldName = "KALAN_KOM_TAZ_DOVIZ_ID";
            fieldKALAN_KOM_TAZ_DOVIZ_ID.Name = "fieldKALAN_KOM_TAZ_DOVIZ_ID";
            fieldKALAN_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_MASRAF.AreaIndex = 54;
            fieldKALAN_MASRAF.FieldName = "KALAN_MASRAF";
            fieldKALAN_MASRAF.Name = "fieldKALAN_MASRAF";
            fieldKALAN_MASRAF.Visible = false;

            PivotGridField fieldKALAN_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_MASRAF_DOVIZ_ID.AreaIndex = 55;
            fieldKALAN_MASRAF_DOVIZ_ID.FieldName = "KALAN_MASRAF_DOVIZ_ID";
            fieldKALAN_MASRAF_DOVIZ_ID.Name = "fieldKALAN_MASRAF_DOVIZ_ID";
            fieldKALAN_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_VEKALET_UCRETI.AreaIndex = 56;
            fieldKALAN_VEKALET_UCRETI.FieldName = "KALAN_VEKALET_UCRETI";
            fieldKALAN_VEKALET_UCRETI.Name = "fieldKALAN_VEKALET_UCRETI";
            fieldKALAN_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldKALAN_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 57;
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.FieldName = "KALAN_VEKALET_UCRETI_DOVIZ_ID";
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldKALAN_VEKALET_UCRETI_DOVIZ_ID";
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_ANAPARA.AreaIndex = 58;
            fieldODEME_ANAPARA.FieldName = "ODEME_ANAPARA";
            fieldODEME_ANAPARA.Name = "fieldODEME_ANAPARA";
            fieldODEME_ANAPARA.Visible = false;

            PivotGridField fieldODEME_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_ANAPARA_DOVIZ_ID.AreaIndex = 59;
            fieldODEME_ANAPARA_DOVIZ_ID.FieldName = "ODEME_ANAPARA_DOVIZ_ID";
            fieldODEME_ANAPARA_DOVIZ_ID.Name = "fieldODEME_ANAPARA_DOVIZ_ID";
            fieldODEME_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_BANKA_BAKIYESI.AreaIndex = 60;
            fieldODEME_BANKA_BAKIYESI.FieldName = "ODEME_BANKA_BAKIYESI";
            fieldODEME_BANKA_BAKIYESI.Name = "fieldODEME_BANKA_BAKIYESI";
            fieldODEME_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldODEME_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 61;
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "ODEME_BANKA_BAKIYESI_DOVIZ_ID";
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldODEME_BANKA_BAKIYESI_DOVIZ_ID";
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_FAIZ_DOVIZ_ID.AreaIndex = 62;
            fieldODEME_FAIZ_DOVIZ_ID.FieldName = "ODEME_FAIZ_DOVIZ_ID";
            fieldODEME_FAIZ_DOVIZ_ID.Name = "fieldODEME_FAIZ_DOVIZ_ID";
            fieldODEME_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_FAIZ.AreaIndex = 63;
            fieldODEME_FAIZ.FieldName = "ODEME_FAIZ";
            fieldODEME_FAIZ.Name = "fieldODEME_FAIZ";
            fieldODEME_FAIZ.Visible = false;

            PivotGridField fieldODEME_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_GIDER_VERGISI.AreaIndex = 64;
            fieldODEME_GIDER_VERGISI.FieldName = "ODEME_GIDER_VERGISI";
            fieldODEME_GIDER_VERGISI.Name = "fieldODEME_GIDER_VERGISI";
            fieldODEME_GIDER_VERGISI.Visible = false;

            PivotGridField fieldODEME_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 65;
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.FieldName = "ODEME_GIDER_VERGISI_DOVIZ_ID";
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.Name = "fieldODEME_GIDER_VERGISI_DOVIZ_ID";
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KALAN.AreaIndex = 66;
            fieldODEME_KALAN.FieldName = "ODEME_KALAN";
            fieldODEME_KALAN.Name = "fieldODEME_KALAN";
            fieldODEME_KALAN.Visible = false;

            PivotGridField fieldODEME_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KALAN_DOVIZ_ID.AreaIndex = 67;
            fieldODEME_KALAN_DOVIZ_ID.FieldName = "ODEME_KALAN_DOVIZ_ID";
            fieldODEME_KALAN_DOVIZ_ID.Name = "fieldODEME_KALAN_DOVIZ_ID";
            fieldODEME_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KOM_TAZ.AreaIndex = 68;
            fieldODEME_KOM_TAZ.FieldName = "ODEME_KOM_TAZ";
            fieldODEME_KOM_TAZ.Name = "fieldODEME_KOM_TAZ";
            fieldODEME_KOM_TAZ.Visible = false;

            PivotGridField fieldODEME_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KOM_TAZ_DOVIZ_ID.AreaIndex = 69;
            fieldODEME_KOM_TAZ_DOVIZ_ID.FieldName = "ODEME_KOM_TAZ_DOVIZ_ID";
            fieldODEME_KOM_TAZ_DOVIZ_ID.Name = "fieldODEME_KOM_TAZ_DOVIZ_ID";
            fieldODEME_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MASRAF.AreaIndex = 70;
            fieldODEME_MASRAF.FieldName = "ODEME_MASRAF";
            fieldODEME_MASRAF.Name = "fieldODEME_MASRAF";
            fieldODEME_MASRAF.Visible = false;

            PivotGridField fieldODEME_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MASRAF_DOVIZ_ID.AreaIndex = 71;
            fieldODEME_MASRAF_DOVIZ_ID.FieldName = "ODEME_MASRAF_DOVIZ_ID";
            fieldODEME_MASRAF_DOVIZ_ID.Name = "fieldODEME_MASRAF_DOVIZ_ID";
            fieldODEME_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_VEKALET_UCRETI.AreaIndex = 72;
            fieldODEME_VEKALET_UCRETI.FieldName = "ODEME_VEKALET_UCRETI";
            fieldODEME_VEKALET_UCRETI.Name = "fieldODEME_VEKALET_UCRETI";
            fieldODEME_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldODEME_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 73;
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.FieldName = "ODEME_VEKALET_UCRETI_DOVIZ_ID";
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldODEME_VEKALET_UCRETI_DOVIZ_ID";
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_ANAPARA.AreaIndex = 74;
            fieldTUTAR_ANAPARA.FieldName = "TUTAR_ANAPARA";
            fieldTUTAR_ANAPARA.Name = "fieldTUTAR_ANAPARA";
            fieldTUTAR_ANAPARA.Visible = false;

            PivotGridField fieldTUTAR_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_ANAPARA_DOVIZ_ID.AreaIndex = 75;
            fieldTUTAR_ANAPARA_DOVIZ_ID.FieldName = "TUTAR_ANAPARA_DOVIZ_ID";
            fieldTUTAR_ANAPARA_DOVIZ_ID.Name = "fieldTUTAR_ANAPARA_DOVIZ_ID";
            fieldTUTAR_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_BANKA_BAKIYESI.AreaIndex = 76;
            fieldTUTAR_BANKA_BAKIYESI.FieldName = "TUTAR_BANKA_BAKIYESI";
            fieldTUTAR_BANKA_BAKIYESI.Name = "fieldTUTAR_BANKA_BAKIYESI";
            fieldTUTAR_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 77;
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "TUTAR_BANKA_BAKIYESI_DOVIZ_ID";
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID";
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_FAIZ.AreaIndex = 78;
            fieldTUTAR_FAIZ.FieldName = "TUTAR_FAIZ";
            fieldTUTAR_FAIZ.Name = "fieldTUTAR_FAIZ";
            fieldTUTAR_FAIZ.Visible = false;

            PivotGridField fieldTUTAR_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_FAIZ_DOVIZ_ID.AreaIndex = 79;
            fieldTUTAR_FAIZ_DOVIZ_ID.FieldName = "TUTAR_FAIZ_DOVIZ_ID";
            fieldTUTAR_FAIZ_DOVIZ_ID.Name = "fieldTUTAR_FAIZ_DOVIZ_ID";
            fieldTUTAR_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_GIDER_VERGISI.AreaIndex = 80;
            fieldTUTAR_GIDER_VERGISI.FieldName = "TUTAR_GIDER_VERGISI";
            fieldTUTAR_GIDER_VERGISI.Name = "fieldTUTAR_GIDER_VERGISI";
            fieldTUTAR_GIDER_VERGISI.Visible = false;

            PivotGridField fieldTUTAR_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 81;
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.FieldName = "TUTAR_GIDER_VERGISI_DOVIZ_ID";
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.Name = "fieldTUTAR_GIDER_VERGISI_DOVIZ_ID";
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KALAN.AreaIndex = 82;
            fieldTUTAR_KALAN.FieldName = "TUTAR_KALAN";
            fieldTUTAR_KALAN.Name = "fieldTUTAR_KALAN";
            fieldTUTAR_KALAN.Visible = false;

            PivotGridField fieldTUTAR_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KALAN_DOVIZ_ID.AreaIndex = 83;
            fieldTUTAR_KALAN_DOVIZ_ID.FieldName = "TUTAR_KALAN_DOVIZ_ID";
            fieldTUTAR_KALAN_DOVIZ_ID.Name = "fieldTUTAR_KALAN_DOVIZ_ID";
            fieldTUTAR_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KOM_TAZ.AreaIndex = 84;
            fieldTUTAR_KOM_TAZ.FieldName = "TUTAR_KOM_TAZ";
            fieldTUTAR_KOM_TAZ.Name = "fieldTUTAR_KOM_TAZ";
            fieldTUTAR_KOM_TAZ.Visible = false;

            PivotGridField fieldTUTAR_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.AreaIndex = 85;
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.FieldName = "TUTAR_KOM_TAZ_DOVIZ_ID";
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.Name = "fieldTUTAR_KOM_TAZ_DOVIZ_ID";
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_MASRAF.AreaIndex = 86;
            fieldTUTAR_MASRAF.FieldName = "TUTAR_MASRAF";
            fieldTUTAR_MASRAF.Name = "fieldTUTAR_MASRAF";
            fieldTUTAR_MASRAF.Visible = false;

            PivotGridField fieldTUTAR_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_MASRAF_DOVIZ_ID.AreaIndex = 87;
            fieldTUTAR_MASRAF_DOVIZ_ID.FieldName = "TUTAR_MASRAF_DOVIZ_ID";
            fieldTUTAR_MASRAF_DOVIZ_ID.Name = "fieldTUTAR_MASRAF_DOVIZ_ID";
            fieldTUTAR_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_VEKALET_UCRETI.AreaIndex = 88;
            fieldTUTAR_VEKALET_UCRETI.FieldName = "TUTAR_VEKALET_UCRETI";
            fieldTUTAR_VEKALET_UCRETI.Name = "fieldTUTAR_VEKALET_UCRETI";
            fieldTUTAR_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 89;
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TUTAR_VEKALET_UCRETI_DOVIZ_ID";
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID";
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSON_HESAP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSON_HESAP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSON_HESAP_TARIHI.AreaIndex = 90;
            fieldSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Name = "fieldSON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Visible = false;

            PivotGridField fieldHESAPLAMA_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHESAPLAMA_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHESAPLAMA_TIPI.AreaIndex = 91;
            fieldHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            fieldHESAPLAMA_TIPI.Name = "fieldHESAPLAMA_TIPI";
            fieldHESAPLAMA_TIPI.Visible = false;

            PivotGridField fieldRISK_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_TOPLAMI.AreaIndex = 92;
            fieldRISK_TOPLAMI.FieldName = "RISK_TOPLAMI";
            fieldRISK_TOPLAMI.Name = "fieldRISK_TOPLAMI";
            fieldRISK_TOPLAMI.Visible = false;

            PivotGridField fieldRISK_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_TOPLAMI_DOVIZ_ID.AreaIndex = 93;
            fieldRISK_TOPLAMI_DOVIZ_ID.FieldName = "RISK_TOPLAMI_DOVIZ_ID";
            fieldRISK_TOPLAMI_DOVIZ_ID.Name = "fieldRISK_TOPLAMI_DOVIZ_ID";
            fieldRISK_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 94;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldADI,
			fieldBITIS_TARIHI,
            fieldPROJE_ALACAK_NEDEN_ID,
			fieldBASLANGIC_TARIHI,
			fieldSUBE_KOD_ID,
			fieldKONTROL_KIM_ID,
			fieldPROJE_SORUMLU,
			fieldPROJE_YETKILI,
			fieldFOY_NO,
			fieldADLIYE,
			fieldNO,
			fieldESAS_NO,
			fieldALACAK_NEDENI,
			fieldVADE_TARIHI,
			fieldTAKIP_TARIHI,
			fieldDUZENLENME_TARIHI,
			fieldTUTARI,
			fieldTUTAR_DOVIZ_ID,
			fieldISLEME_KONAN_TUTAR,
			fieldISLEME_KONAN_TUTAR_DOVIZ_ID,
            fieldBOLUM,
			};
            return dizi;
        }
    }
}