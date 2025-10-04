using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class RaporProjeSorusturma
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

            GridColumn colBASLANGIC_TARIHI = new GridColumn();
            colBASLANGIC_TARIHI.VisibleIndex = 3;
            colBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            colBASLANGIC_TARIHI.Name = "colBASLANGIC_TARIHI";
            colBASLANGIC_TARIHI.Visible = true;

            GridColumn colBITIS_TARIHI = new GridColumn();
            colBITIS_TARIHI.VisibleIndex = 4;
            colBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            colBITIS_TARIHI.Name = "colBITIS_TARIHI";
            colBITIS_TARIHI.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 5;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 6;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 7;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 8;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 9;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.Visible = true;

            GridColumn colREFERANS_NO1 = new GridColumn();
            colREFERANS_NO1.VisibleIndex = 10;
            colREFERANS_NO1.FieldName = "REFERANS_NO1";
            colREFERANS_NO1.Name = "colREFERANS_NO1";
            colREFERANS_NO1.Visible = true;

            GridColumn colREFERANS_NO2 = new GridColumn();
            colREFERANS_NO2.VisibleIndex = 11;
            colREFERANS_NO2.FieldName = "REFERANS_NO2";
            colREFERANS_NO2.Name = "colREFERANS_NO2";
            colREFERANS_NO2.Visible = true;

            GridColumn colREFERANS_NO3 = new GridColumn();
            colREFERANS_NO3.VisibleIndex = 12;
            colREFERANS_NO3.FieldName = "REFERANS_NO3";
            colREFERANS_NO3.Name = "colREFERANS_NO3";
            colREFERANS_NO3.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 13;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 14;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 15;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 16;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKARAR = new GridColumn();
            colKARAR.VisibleIndex = 17;
            colKARAR.FieldName = "KARAR";
            colKARAR.Name = "colKARAR";
            colKARAR.Visible = true;

            GridColumn colTEKLIF = new GridColumn();
            colTEKLIF.VisibleIndex = 18;
            colTEKLIF.FieldName = "TEKLIF";
            colTEKLIF.Name = "colTEKLIF";
            colTEKLIF.Visible = true;

            GridColumn colPROJE_TARAFI = new GridColumn();
            colPROJE_TARAFI.VisibleIndex = 19;
            colPROJE_TARAFI.FieldName = "PROJE_TARAFI";
            colPROJE_TARAFI.Name = "colPROJE_TARAFI";
            colPROJE_TARAFI.Visible = true;

            GridColumn colPROJE_SORUMLU = new GridColumn();
            colPROJE_SORUMLU.VisibleIndex = 20;
            colPROJE_SORUMLU.FieldName = "PROJE_SORUMLU";
            colPROJE_SORUMLU.Name = "colPROJE_SORUMLU";
            colPROJE_SORUMLU.Visible = true;

            GridColumn colPROJE_YETKILI = new GridColumn();
            colPROJE_YETKILI.VisibleIndex = 21;
            colPROJE_YETKILI.FieldName = "PROJE_YETKILI";
            colPROJE_YETKILI.Name = "colPROJE_YETKILI";
            colPROJE_YETKILI.Visible = true;

            GridColumn colHAZIRLIK_ID = new GridColumn();
            colHAZIRLIK_ID.VisibleIndex = 22;
            colHAZIRLIK_ID.FieldName = "HAZIRLIK_ID";
            colHAZIRLIK_ID.Name = "colHAZIRLIK_ID";
            colHAZIRLIK_ID.Visible = true;

            GridColumn colHAZIRLIK_NO = new GridColumn();
            colHAZIRLIK_NO.VisibleIndex = 23;
            colHAZIRLIK_NO.FieldName = "HAZIRLIK_NO";
            colHAZIRLIK_NO.Name = "colHAZIRLIK_NO";
            colHAZIRLIK_NO.Visible = true;

            GridColumn colSIKAYET_TARIHI = new GridColumn();
            colSIKAYET_TARIHI.VisibleIndex = 24;
            colSIKAYET_TARIHI.FieldName = "SIKAYET_TARIHI";
            colSIKAYET_TARIHI.Name = "colSIKAYET_TARIHI";
            colSIKAYET_TARIHI.Visible = true;

            GridColumn colDAVA_TALEP = new GridColumn();
            colDAVA_TALEP.VisibleIndex = 25;
            colDAVA_TALEP.FieldName = "DAVA_TALEP";
            colDAVA_TALEP.Name = "colDAVA_TALEP";
            colDAVA_TALEP.Visible = true;

            GridColumn colHAZIRLIK_TARIH = new GridColumn();
            colHAZIRLIK_TARIH.VisibleIndex = 26;
            colHAZIRLIK_TARIH.FieldName = "HAZIRLIK_TARIH";
            colHAZIRLIK_TARIH.Name = "colHAZIRLIK_TARIH";
            colHAZIRLIK_TARIH.Visible = true;

            GridColumn colHAZIRLIK_ESAS_NO = new GridColumn();
            colHAZIRLIK_ESAS_NO.VisibleIndex = 27;
            colHAZIRLIK_ESAS_NO.FieldName = "HAZIRLIK_ESAS_NO";
            colHAZIRLIK_ESAS_NO.Name = "colHAZIRLIK_ESAS_NO";
            colHAZIRLIK_ESAS_NO.Visible = true;

            GridColumn colSORUSTURMA_DURUM = new GridColumn();
            colSORUSTURMA_DURUM.VisibleIndex = 28;
            colSORUSTURMA_DURUM.FieldName = "SORUSTURMA_DURUM";
            colSORUSTURMA_DURUM.Name = "colSORUSTURMA_DURUM";
            colSORUSTURMA_DURUM.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 29;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 30;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 31;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 32;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colINDIRIM_ANAPARA = new GridColumn();
            colINDIRIM_ANAPARA.VisibleIndex = 33;
            colINDIRIM_ANAPARA.FieldName = "INDIRIM_ANAPARA";
            colINDIRIM_ANAPARA.Name = "colINDIRIM_ANAPARA";
            colINDIRIM_ANAPARA.Visible = true;

            GridColumn colINDIRIM_ANAPARA_DOVIZ_ID = new GridColumn();
            colINDIRIM_ANAPARA_DOVIZ_ID.VisibleIndex = 34;
            colINDIRIM_ANAPARA_DOVIZ_ID.FieldName = "INDIRIM_ANAPARA_DOVIZ_ID";
            colINDIRIM_ANAPARA_DOVIZ_ID.Name = "colINDIRIM_ANAPARA_DOVIZ_ID";
            colINDIRIM_ANAPARA_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_BANKA_BAKIYESI = new GridColumn();
            colINDIRIM_BANKA_BAKIYESI.VisibleIndex = 35;
            colINDIRIM_BANKA_BAKIYESI.FieldName = "INDIRIM_BANKA_BAKIYESI";
            colINDIRIM_BANKA_BAKIYESI.Name = "colINDIRIM_BANKA_BAKIYESI";
            colINDIRIM_BANKA_BAKIYESI.Visible = true;

            GridColumn colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID = new GridColumn();
            colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.VisibleIndex = 36;
            colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "INDIRIM_BANKA_BAKIYESI_DOVIZ_ID";
            colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Name = "colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID";
            colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_FAIZ = new GridColumn();
            colINDIRIM_FAIZ.VisibleIndex = 37;
            colINDIRIM_FAIZ.FieldName = "INDIRIM_FAIZ";
            colINDIRIM_FAIZ.Name = "colINDIRIM_FAIZ";
            colINDIRIM_FAIZ.Visible = true;

            GridColumn colINDIRIM_FAIZ_DOVIZ_ID = new GridColumn();
            colINDIRIM_FAIZ_DOVIZ_ID.VisibleIndex = 38;
            colINDIRIM_FAIZ_DOVIZ_ID.FieldName = "INDIRIM_FAIZ_DOVIZ_ID";
            colINDIRIM_FAIZ_DOVIZ_ID.Name = "colINDIRIM_FAIZ_DOVIZ_ID";
            colINDIRIM_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_GIDER_VERGISI = new GridColumn();
            colINDIRIM_GIDER_VERGISI.VisibleIndex = 39;
            colINDIRIM_GIDER_VERGISI.FieldName = "INDIRIM_GIDER_VERGISI";
            colINDIRIM_GIDER_VERGISI.Name = "colINDIRIM_GIDER_VERGISI";
            colINDIRIM_GIDER_VERGISI.Visible = true;

            GridColumn colINDIRIM_GIDER_VERGISI_DOVIZ_ID = new GridColumn();
            colINDIRIM_GIDER_VERGISI_DOVIZ_ID.VisibleIndex = 40;
            colINDIRIM_GIDER_VERGISI_DOVIZ_ID.FieldName = "INDIRIM_GIDER_VERGISI_DOVIZ_ID";
            colINDIRIM_GIDER_VERGISI_DOVIZ_ID.Name = "colINDIRIM_GIDER_VERGISI_DOVIZ_ID";
            colINDIRIM_GIDER_VERGISI_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_KALAN = new GridColumn();
            colINDIRIM_KALAN.VisibleIndex = 41;
            colINDIRIM_KALAN.FieldName = "INDIRIM_KALAN";
            colINDIRIM_KALAN.Name = "colINDIRIM_KALAN";
            colINDIRIM_KALAN.Visible = true;

            GridColumn colINDIRIM_KALAN_DOVIZ_ID = new GridColumn();
            colINDIRIM_KALAN_DOVIZ_ID.VisibleIndex = 42;
            colINDIRIM_KALAN_DOVIZ_ID.FieldName = "INDIRIM_KALAN_DOVIZ_ID";
            colINDIRIM_KALAN_DOVIZ_ID.Name = "colINDIRIM_KALAN_DOVIZ_ID";
            colINDIRIM_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_KOM_TAZ = new GridColumn();
            colINDIRIM_KOM_TAZ.VisibleIndex = 43;
            colINDIRIM_KOM_TAZ.FieldName = "INDIRIM_KOM_TAZ";
            colINDIRIM_KOM_TAZ.Name = "colINDIRIM_KOM_TAZ";
            colINDIRIM_KOM_TAZ.Visible = true;

            GridColumn colINDIRIM_MASRAF = new GridColumn();
            colINDIRIM_MASRAF.VisibleIndex = 44;
            colINDIRIM_MASRAF.FieldName = "INDIRIM_MASRAF";
            colINDIRIM_MASRAF.Name = "colINDIRIM_MASRAF";
            colINDIRIM_MASRAF.Visible = true;

            GridColumn colINDIRIM_KOM_TAZ_DOVIZ_ID = new GridColumn();
            colINDIRIM_KOM_TAZ_DOVIZ_ID.VisibleIndex = 45;
            colINDIRIM_KOM_TAZ_DOVIZ_ID.FieldName = "INDIRIM_KOM_TAZ_DOVIZ_ID";
            colINDIRIM_KOM_TAZ_DOVIZ_ID.Name = "colINDIRIM_KOM_TAZ_DOVIZ_ID";
            colINDIRIM_KOM_TAZ_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_MASRAF_DOVIZ_ID = new GridColumn();
            colINDIRIM_MASRAF_DOVIZ_ID.VisibleIndex = 46;
            colINDIRIM_MASRAF_DOVIZ_ID.FieldName = "INDIRIM_MASRAF_DOVIZ_ID";
            colINDIRIM_MASRAF_DOVIZ_ID.Name = "colINDIRIM_MASRAF_DOVIZ_ID";
            colINDIRIM_MASRAF_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_VEKALET_UCRETI = new GridColumn();
            colINDIRIM_VEKALET_UCRETI.VisibleIndex = 47;
            colINDIRIM_VEKALET_UCRETI.FieldName = "INDIRIM_VEKALET_UCRETI";
            colINDIRIM_VEKALET_UCRETI.Name = "colINDIRIM_VEKALET_UCRETI";
            colINDIRIM_VEKALET_UCRETI.Visible = true;

            GridColumn colINDIRIM_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colINDIRIM_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 48;
            colINDIRIM_VEKALET_UCRETI_DOVIZ_ID.FieldName = "INDIRIM_VEKALET_UCRETI_DOVIZ_ID";
            colINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Name = "colINDIRIM_VEKALET_UCRETI_DOVIZ_ID";
            colINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_ANAPARA = new GridColumn();
            colKALAN_ANAPARA.VisibleIndex = 49;
            colKALAN_ANAPARA.FieldName = "KALAN_ANAPARA";
            colKALAN_ANAPARA.Name = "colKALAN_ANAPARA";
            colKALAN_ANAPARA.Visible = true;

            GridColumn colKALAN_ANAPARA_DOVIZ_ID = new GridColumn();
            colKALAN_ANAPARA_DOVIZ_ID.VisibleIndex = 50;
            colKALAN_ANAPARA_DOVIZ_ID.FieldName = "KALAN_ANAPARA_DOVIZ_ID";
            colKALAN_ANAPARA_DOVIZ_ID.Name = "colKALAN_ANAPARA_DOVIZ_ID";
            colKALAN_ANAPARA_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_BANKA_BAKIYESI = new GridColumn();
            colKALAN_BANKA_BAKIYESI.VisibleIndex = 51;
            colKALAN_BANKA_BAKIYESI.FieldName = "KALAN_BANKA_BAKIYESI";
            colKALAN_BANKA_BAKIYESI.Name = "colKALAN_BANKA_BAKIYESI";
            colKALAN_BANKA_BAKIYESI.Visible = true;

            GridColumn colKALAN_BANKA_BAKIYESI_DOVIZ_ID = new GridColumn();
            colKALAN_BANKA_BAKIYESI_DOVIZ_ID.VisibleIndex = 52;
            colKALAN_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "KALAN_BANKA_BAKIYESI_DOVIZ_ID";
            colKALAN_BANKA_BAKIYESI_DOVIZ_ID.Name = "colKALAN_BANKA_BAKIYESI_DOVIZ_ID";
            colKALAN_BANKA_BAKIYESI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_FAIZ = new GridColumn();
            colKALAN_FAIZ.VisibleIndex = 53;
            colKALAN_FAIZ.FieldName = "KALAN_FAIZ";
            colKALAN_FAIZ.Name = "colKALAN_FAIZ";
            colKALAN_FAIZ.Visible = true;

            GridColumn colKALAN_FAIZ_DOVIZ_ID = new GridColumn();
            colKALAN_FAIZ_DOVIZ_ID.VisibleIndex = 54;
            colKALAN_FAIZ_DOVIZ_ID.FieldName = "KALAN_FAIZ_DOVIZ_ID";
            colKALAN_FAIZ_DOVIZ_ID.Name = "colKALAN_FAIZ_DOVIZ_ID";
            colKALAN_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_GIDER_VERGISI = new GridColumn();
            colKALAN_GIDER_VERGISI.VisibleIndex = 55;
            colKALAN_GIDER_VERGISI.FieldName = "KALAN_GIDER_VERGISI";
            colKALAN_GIDER_VERGISI.Name = "colKALAN_GIDER_VERGISI";
            colKALAN_GIDER_VERGISI.Visible = true;

            GridColumn colKALAN_GIDER_VERGISI_DOVIZ_ID = new GridColumn();
            colKALAN_GIDER_VERGISI_DOVIZ_ID.VisibleIndex = 56;
            colKALAN_GIDER_VERGISI_DOVIZ_ID.FieldName = "KALAN_GIDER_VERGISI_DOVIZ_ID";
            colKALAN_GIDER_VERGISI_DOVIZ_ID.Name = "colKALAN_GIDER_VERGISI_DOVIZ_ID";
            colKALAN_GIDER_VERGISI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_KALAN = new GridColumn();
            colKALAN_KALAN.VisibleIndex = 57;
            colKALAN_KALAN.FieldName = "KALAN_KALAN";
            colKALAN_KALAN.Name = "colKALAN_KALAN";
            colKALAN_KALAN.Visible = true;

            GridColumn colKALAN_KALAN_DOVIZ_ID = new GridColumn();
            colKALAN_KALAN_DOVIZ_ID.VisibleIndex = 58;
            colKALAN_KALAN_DOVIZ_ID.FieldName = "KALAN_KALAN_DOVIZ_ID";
            colKALAN_KALAN_DOVIZ_ID.Name = "colKALAN_KALAN_DOVIZ_ID";
            colKALAN_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_KOM_TAZ = new GridColumn();
            colKALAN_KOM_TAZ.VisibleIndex = 59;
            colKALAN_KOM_TAZ.FieldName = "KALAN_KOM_TAZ";
            colKALAN_KOM_TAZ.Name = "colKALAN_KOM_TAZ";
            colKALAN_KOM_TAZ.Visible = true;

            GridColumn colKALAN_KOM_TAZ_DOVIZ_ID = new GridColumn();
            colKALAN_KOM_TAZ_DOVIZ_ID.VisibleIndex = 60;
            colKALAN_KOM_TAZ_DOVIZ_ID.FieldName = "KALAN_KOM_TAZ_DOVIZ_ID";
            colKALAN_KOM_TAZ_DOVIZ_ID.Name = "colKALAN_KOM_TAZ_DOVIZ_ID";
            colKALAN_KOM_TAZ_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_MASRAF = new GridColumn();
            colKALAN_MASRAF.VisibleIndex = 61;
            colKALAN_MASRAF.FieldName = "KALAN_MASRAF";
            colKALAN_MASRAF.Name = "colKALAN_MASRAF";
            colKALAN_MASRAF.Visible = true;

            GridColumn colKALAN_MASRAF_DOVIZ_ID = new GridColumn();
            colKALAN_MASRAF_DOVIZ_ID.VisibleIndex = 62;
            colKALAN_MASRAF_DOVIZ_ID.FieldName = "KALAN_MASRAF_DOVIZ_ID";
            colKALAN_MASRAF_DOVIZ_ID.Name = "colKALAN_MASRAF_DOVIZ_ID";
            colKALAN_MASRAF_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_VEKALET_UCRETI = new GridColumn();
            colKALAN_VEKALET_UCRETI.VisibleIndex = 63;
            colKALAN_VEKALET_UCRETI.FieldName = "KALAN_VEKALET_UCRETI";
            colKALAN_VEKALET_UCRETI.Name = "colKALAN_VEKALET_UCRETI";
            colKALAN_VEKALET_UCRETI.Visible = true;

            GridColumn colKALAN_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colKALAN_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 64;
            colKALAN_VEKALET_UCRETI_DOVIZ_ID.FieldName = "KALAN_VEKALET_UCRETI_DOVIZ_ID";
            colKALAN_VEKALET_UCRETI_DOVIZ_ID.Name = "colKALAN_VEKALET_UCRETI_DOVIZ_ID";
            colKALAN_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_ANAPARA = new GridColumn();
            colODEME_ANAPARA.VisibleIndex = 65;
            colODEME_ANAPARA.FieldName = "ODEME_ANAPARA";
            colODEME_ANAPARA.Name = "colODEME_ANAPARA";
            colODEME_ANAPARA.Visible = true;

            GridColumn colODEME_ANAPARA_DOVIZ_ID = new GridColumn();
            colODEME_ANAPARA_DOVIZ_ID.VisibleIndex = 66;
            colODEME_ANAPARA_DOVIZ_ID.FieldName = "ODEME_ANAPARA_DOVIZ_ID";
            colODEME_ANAPARA_DOVIZ_ID.Name = "colODEME_ANAPARA_DOVIZ_ID";
            colODEME_ANAPARA_DOVIZ_ID.Visible = true;

            GridColumn colODEME_BANKA_BAKIYESI = new GridColumn();
            colODEME_BANKA_BAKIYESI.VisibleIndex = 67;
            colODEME_BANKA_BAKIYESI.FieldName = "ODEME_BANKA_BAKIYESI";
            colODEME_BANKA_BAKIYESI.Name = "colODEME_BANKA_BAKIYESI";
            colODEME_BANKA_BAKIYESI.Visible = true;

            GridColumn colODEME_BANKA_BAKIYESI_DOVIZ_ID = new GridColumn();
            colODEME_BANKA_BAKIYESI_DOVIZ_ID.VisibleIndex = 68;
            colODEME_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "ODEME_BANKA_BAKIYESI_DOVIZ_ID";
            colODEME_BANKA_BAKIYESI_DOVIZ_ID.Name = "colODEME_BANKA_BAKIYESI_DOVIZ_ID";
            colODEME_BANKA_BAKIYESI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_FAIZ = new GridColumn();
            colODEME_FAIZ.VisibleIndex = 69;
            colODEME_FAIZ.FieldName = "ODEME_FAIZ";
            colODEME_FAIZ.Name = "colODEME_FAIZ";
            colODEME_FAIZ.Visible = true;

            GridColumn colODEME_FAIZ_DOVIZ_ID = new GridColumn();
            colODEME_FAIZ_DOVIZ_ID.VisibleIndex = 70;
            colODEME_FAIZ_DOVIZ_ID.FieldName = "ODEME_FAIZ_DOVIZ_ID";
            colODEME_FAIZ_DOVIZ_ID.Name = "colODEME_FAIZ_DOVIZ_ID";
            colODEME_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colODEME_GIDER_VERGISI = new GridColumn();
            colODEME_GIDER_VERGISI.VisibleIndex = 71;
            colODEME_GIDER_VERGISI.FieldName = "ODEME_GIDER_VERGISI";
            colODEME_GIDER_VERGISI.Name = "colODEME_GIDER_VERGISI";
            colODEME_GIDER_VERGISI.Visible = true;

            GridColumn colODEME_GIDER_VERGISI_DOVIZ_ID = new GridColumn();
            colODEME_GIDER_VERGISI_DOVIZ_ID.VisibleIndex = 72;
            colODEME_GIDER_VERGISI_DOVIZ_ID.FieldName = "ODEME_GIDER_VERGISI_DOVIZ_ID";
            colODEME_GIDER_VERGISI_DOVIZ_ID.Name = "colODEME_GIDER_VERGISI_DOVIZ_ID";
            colODEME_GIDER_VERGISI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_KALAN = new GridColumn();
            colODEME_KALAN.VisibleIndex = 73;
            colODEME_KALAN.FieldName = "ODEME_KALAN";
            colODEME_KALAN.Name = "colODEME_KALAN";
            colODEME_KALAN.Visible = true;

            GridColumn colODEME_KALAN_DOVIZ_ID = new GridColumn();
            colODEME_KALAN_DOVIZ_ID.VisibleIndex = 74;
            colODEME_KALAN_DOVIZ_ID.FieldName = "ODEME_KALAN_DOVIZ_ID";
            colODEME_KALAN_DOVIZ_ID.Name = "colODEME_KALAN_DOVIZ_ID";
            colODEME_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colODEME_KOM_TAZ = new GridColumn();
            colODEME_KOM_TAZ.VisibleIndex = 75;
            colODEME_KOM_TAZ.FieldName = "ODEME_KOM_TAZ";
            colODEME_KOM_TAZ.Name = "colODEME_KOM_TAZ";
            colODEME_KOM_TAZ.Visible = true;

            GridColumn colODEME_KOM_TAZ_DOVIZ_ID = new GridColumn();
            colODEME_KOM_TAZ_DOVIZ_ID.VisibleIndex = 76;
            colODEME_KOM_TAZ_DOVIZ_ID.FieldName = "ODEME_KOM_TAZ_DOVIZ_ID";
            colODEME_KOM_TAZ_DOVIZ_ID.Name = "colODEME_KOM_TAZ_DOVIZ_ID";
            colODEME_KOM_TAZ_DOVIZ_ID.Visible = true;

            GridColumn colODEME_MASRAF = new GridColumn();
            colODEME_MASRAF.VisibleIndex = 77;
            colODEME_MASRAF.FieldName = "ODEME_MASRAF";
            colODEME_MASRAF.Name = "colODEME_MASRAF";
            colODEME_MASRAF.Visible = true;

            GridColumn colODEME_MASRAF_DOVIZ_ID = new GridColumn();
            colODEME_MASRAF_DOVIZ_ID.VisibleIndex = 78;
            colODEME_MASRAF_DOVIZ_ID.FieldName = "ODEME_MASRAF_DOVIZ_ID";
            colODEME_MASRAF_DOVIZ_ID.Name = "colODEME_MASRAF_DOVIZ_ID";
            colODEME_MASRAF_DOVIZ_ID.Visible = true;

            GridColumn colODEME_VEKALET_UCRETI = new GridColumn();
            colODEME_VEKALET_UCRETI.VisibleIndex = 79;
            colODEME_VEKALET_UCRETI.FieldName = "ODEME_VEKALET_UCRETI";
            colODEME_VEKALET_UCRETI.Name = "colODEME_VEKALET_UCRETI";
            colODEME_VEKALET_UCRETI.Visible = true;

            GridColumn colODEME_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colODEME_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 80;
            colODEME_VEKALET_UCRETI_DOVIZ_ID.FieldName = "ODEME_VEKALET_UCRETI_DOVIZ_ID";
            colODEME_VEKALET_UCRETI_DOVIZ_ID.Name = "colODEME_VEKALET_UCRETI_DOVIZ_ID";
            colODEME_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_ANAPARA = new GridColumn();
            colTUTAR_ANAPARA.VisibleIndex = 81;
            colTUTAR_ANAPARA.FieldName = "TUTAR_ANAPARA";
            colTUTAR_ANAPARA.Name = "colTUTAR_ANAPARA";
            colTUTAR_ANAPARA.Visible = true;

            GridColumn colTUTAR_ANAPARA_DOVIZ_ID = new GridColumn();
            colTUTAR_ANAPARA_DOVIZ_ID.VisibleIndex = 82;
            colTUTAR_ANAPARA_DOVIZ_ID.FieldName = "TUTAR_ANAPARA_DOVIZ_ID";
            colTUTAR_ANAPARA_DOVIZ_ID.Name = "colTUTAR_ANAPARA_DOVIZ_ID";
            colTUTAR_ANAPARA_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_BANKA_BAKIYESI = new GridColumn();
            colTUTAR_BANKA_BAKIYESI.VisibleIndex = 83;
            colTUTAR_BANKA_BAKIYESI.FieldName = "TUTAR_BANKA_BAKIYESI";
            colTUTAR_BANKA_BAKIYESI.Name = "colTUTAR_BANKA_BAKIYESI";
            colTUTAR_BANKA_BAKIYESI.Visible = true;

            GridColumn colTUTAR_BANKA_BAKIYESI_DOVIZ_ID = new GridColumn();
            colTUTAR_BANKA_BAKIYESI_DOVIZ_ID.VisibleIndex = 84;
            colTUTAR_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "TUTAR_BANKA_BAKIYESI_DOVIZ_ID";
            colTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Name = "colTUTAR_BANKA_BAKIYESI_DOVIZ_ID";
            colTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_FAIZ = new GridColumn();
            colTUTAR_FAIZ.VisibleIndex = 85;
            colTUTAR_FAIZ.FieldName = "TUTAR_FAIZ";
            colTUTAR_FAIZ.Name = "colTUTAR_FAIZ";
            colTUTAR_FAIZ.Visible = true;

            GridColumn colTUTAR_FAIZ_DOVIZ_ID = new GridColumn();
            colTUTAR_FAIZ_DOVIZ_ID.VisibleIndex = 86;
            colTUTAR_FAIZ_DOVIZ_ID.FieldName = "TUTAR_FAIZ_DOVIZ_ID";
            colTUTAR_FAIZ_DOVIZ_ID.Name = "colTUTAR_FAIZ_DOVIZ_ID";
            colTUTAR_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_GIDER_VERGISI = new GridColumn();
            colTUTAR_GIDER_VERGISI.VisibleIndex = 87;
            colTUTAR_GIDER_VERGISI.FieldName = "TUTAR_GIDER_VERGISI";
            colTUTAR_GIDER_VERGISI.Name = "colTUTAR_GIDER_VERGISI";
            colTUTAR_GIDER_VERGISI.Visible = true;

            GridColumn colTUTAR_GIDER_VERGISI_DOVIZ_ID = new GridColumn();
            colTUTAR_GIDER_VERGISI_DOVIZ_ID.VisibleIndex = 88;
            colTUTAR_GIDER_VERGISI_DOVIZ_ID.FieldName = "TUTAR_GIDER_VERGISI_DOVIZ_ID";
            colTUTAR_GIDER_VERGISI_DOVIZ_ID.Name = "colTUTAR_GIDER_VERGISI_DOVIZ_ID";
            colTUTAR_GIDER_VERGISI_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_KALAN = new GridColumn();
            colTUTAR_KALAN.VisibleIndex = 89;
            colTUTAR_KALAN.FieldName = "TUTAR_KALAN";
            colTUTAR_KALAN.Name = "colTUTAR_KALAN";
            colTUTAR_KALAN.Visible = true;

            GridColumn colTUTAR_KALAN_DOVIZ_ID = new GridColumn();
            colTUTAR_KALAN_DOVIZ_ID.VisibleIndex = 90;
            colTUTAR_KALAN_DOVIZ_ID.FieldName = "TUTAR_KALAN_DOVIZ_ID";
            colTUTAR_KALAN_DOVIZ_ID.Name = "colTUTAR_KALAN_DOVIZ_ID";
            colTUTAR_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_KOM_TAZ = new GridColumn();
            colTUTAR_KOM_TAZ.VisibleIndex = 91;
            colTUTAR_KOM_TAZ.FieldName = "TUTAR_KOM_TAZ";
            colTUTAR_KOM_TAZ.Name = "colTUTAR_KOM_TAZ";
            colTUTAR_KOM_TAZ.Visible = true;

            GridColumn colTUTAR_KOM_TAZ_DOVIZ_ID = new GridColumn();
            colTUTAR_KOM_TAZ_DOVIZ_ID.VisibleIndex = 92;
            colTUTAR_KOM_TAZ_DOVIZ_ID.FieldName = "TUTAR_KOM_TAZ_DOVIZ_ID";
            colTUTAR_KOM_TAZ_DOVIZ_ID.Name = "colTUTAR_KOM_TAZ_DOVIZ_ID";
            colTUTAR_KOM_TAZ_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_MASRAF = new GridColumn();
            colTUTAR_MASRAF.VisibleIndex = 93;
            colTUTAR_MASRAF.FieldName = "TUTAR_MASRAF";
            colTUTAR_MASRAF.Name = "colTUTAR_MASRAF";
            colTUTAR_MASRAF.Visible = true;

            GridColumn colTUTAR_MASRAF_DOVIZ_ID = new GridColumn();
            colTUTAR_MASRAF_DOVIZ_ID.VisibleIndex = 94;
            colTUTAR_MASRAF_DOVIZ_ID.FieldName = "TUTAR_MASRAF_DOVIZ_ID";
            colTUTAR_MASRAF_DOVIZ_ID.Name = "colTUTAR_MASRAF_DOVIZ_ID";
            colTUTAR_MASRAF_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_VEKALET_UCRETI = new GridColumn();
            colTUTAR_VEKALET_UCRETI.VisibleIndex = 95;
            colTUTAR_VEKALET_UCRETI.FieldName = "TUTAR_VEKALET_UCRETI";
            colTUTAR_VEKALET_UCRETI.Name = "colTUTAR_VEKALET_UCRETI";
            colTUTAR_VEKALET_UCRETI.Visible = true;

            GridColumn colTUTAR_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colTUTAR_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 96;
            colTUTAR_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TUTAR_VEKALET_UCRETI_DOVIZ_ID";
            colTUTAR_VEKALET_UCRETI_DOVIZ_ID.Name = "colTUTAR_VEKALET_UCRETI_DOVIZ_ID";
            colTUTAR_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colSON_HESAP_TARIHI = new GridColumn();
            colSON_HESAP_TARIHI.VisibleIndex = 97;
            colSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Name = "colSON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Visible = true;

            GridColumn colHESAPLAMA_TIPI = new GridColumn();
            colHESAPLAMA_TIPI.VisibleIndex = 98;
            colHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Name = "colHESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Visible = true;

            GridColumn colRISK_TOPLAMI = new GridColumn();
            colRISK_TOPLAMI.VisibleIndex = 99;
            colRISK_TOPLAMI.FieldName = "RISK_TOPLAMI";
            colRISK_TOPLAMI.Name = "colRISK_TOPLAMI";
            colRISK_TOPLAMI.Visible = true;

            GridColumn colRISK_TOPLAMI_DOVIZ_ID = new GridColumn();
            colRISK_TOPLAMI_DOVIZ_ID.VisibleIndex = 100;
            colRISK_TOPLAMI_DOVIZ_ID.FieldName = "RISK_TOPLAMI_DOVIZ_ID";
            colRISK_TOPLAMI_DOVIZ_ID.Name = "colRISK_TOPLAMI_DOVIZ_ID";
            colRISK_TOPLAMI_DOVIZ_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			//colID,
			colKOD,
			colADI,
			colBASLANGIC_TARIHI,
			colBITIS_TARIHI,
			colDURUM,
			colOZEL_KOD2,
			colOZEL_KOD1,
			colOZEL_KOD4,
			colOZEL_KOD3,
			colREFERANS_NO1,
			colREFERANS_NO2,
			colREFERANS_NO3,
			colACIKLAMA,
			colBOLUM,
			colKONTROL_KIM_ID,
			colSUBE_KOD_ID,
			colKARAR,
			colTEKLIF,
			colPROJE_TARAFI,
			colPROJE_SORUMLU,
			colPROJE_YETKILI,

			//colHAZIRLIK_ID,
			colHAZIRLIK_NO,
			colSIKAYET_TARIHI,
			colDAVA_TALEP,
			colHAZIRLIK_TARIH,
			colHAZIRLIK_ESAS_NO,
			colSORUSTURMA_DURUM,
			colADLIYE,
			colNO,
			colGOREV,
			colREFERANS_NO,
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
			colKALAN_KALAN_DOVIZ_ID,
			colKALAN_KOM_TAZ,
			colKALAN_KOM_TAZ_DOVIZ_ID,
			colKALAN_MASRAF,
			colKALAN_MASRAF_DOVIZ_ID,
			colKALAN_VEKALET_UCRETI,
			colKALAN_VEKALET_UCRETI_DOVIZ_ID,
			colODEME_ANAPARA,
			colODEME_ANAPARA_DOVIZ_ID,
			colODEME_BANKA_BAKIYESI,
			colODEME_BANKA_BAKIYESI_DOVIZ_ID,
			colODEME_FAIZ,
			colODEME_FAIZ_DOVIZ_ID,
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

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

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

            PivotGridField fieldBASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASLANGIC_TARIHI.AreaIndex = 3;
            fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Visible = false;

            PivotGridField fieldBITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_TARIHI.AreaIndex = 4;
            fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
            fieldBITIS_TARIHI.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 5;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldOZEL_KOD2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD2.AreaIndex = 6;
            fieldOZEL_KOD2.FieldName = "OZEL_KOD2";
            fieldOZEL_KOD2.Name = "fieldOZEL_KOD2";
            fieldOZEL_KOD2.Visible = false;

            PivotGridField fieldOZEL_KOD1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD1.AreaIndex = 7;
            fieldOZEL_KOD1.FieldName = "OZEL_KOD1";
            fieldOZEL_KOD1.Name = "fieldOZEL_KOD1";
            fieldOZEL_KOD1.Visible = false;

            PivotGridField fieldOZEL_KOD4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD4.AreaIndex = 8;
            fieldOZEL_KOD4.FieldName = "OZEL_KOD4";
            fieldOZEL_KOD4.Name = "fieldOZEL_KOD4";
            fieldOZEL_KOD4.Visible = false;

            PivotGridField fieldOZEL_KOD3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD3.AreaIndex = 9;
            fieldOZEL_KOD3.FieldName = "OZEL_KOD3";
            fieldOZEL_KOD3.Name = "fieldOZEL_KOD3";
            fieldOZEL_KOD3.Visible = false;

            PivotGridField fieldREFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO1.AreaIndex = 10;
            fieldREFERANS_NO1.FieldName = "REFERANS_NO1";
            fieldREFERANS_NO1.Name = "fieldREFERANS_NO1";
            fieldREFERANS_NO1.Visible = false;

            PivotGridField fieldREFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO2.AreaIndex = 11;
            fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
            fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";
            fieldREFERANS_NO2.Visible = false;

            PivotGridField fieldREFERANS_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO3.AreaIndex = 12;
            fieldREFERANS_NO3.FieldName = "REFERANS_NO3";
            fieldREFERANS_NO3.Name = "fieldREFERANS_NO3";
            fieldREFERANS_NO3.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 13;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 14;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 15;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 16;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKARAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARAR.AreaIndex = 17;
            fieldKARAR.FieldName = "KARAR";
            fieldKARAR.Name = "fieldKARAR";
            fieldKARAR.Visible = false;

            PivotGridField fieldTEKLIF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEKLIF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEKLIF.AreaIndex = 18;
            fieldTEKLIF.FieldName = "TEKLIF";
            fieldTEKLIF.Name = "fieldTEKLIF";
            fieldTEKLIF.Visible = false;

            PivotGridField fieldPROJE_TARAFI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_TARAFI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_TARAFI.AreaIndex = 19;
            fieldPROJE_TARAFI.FieldName = "PROJE_TARAFI";
            fieldPROJE_TARAFI.Name = "fieldPROJE_TARAFI";
            fieldPROJE_TARAFI.Visible = false;

            PivotGridField fieldPROJE_SORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_SORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_SORUMLU.AreaIndex = 20;
            fieldPROJE_SORUMLU.FieldName = "PROJE_SORUMLU";
            fieldPROJE_SORUMLU.Name = "fieldPROJE_SORUMLU";
            fieldPROJE_SORUMLU.Visible = false;

            PivotGridField fieldPROJE_YETKILI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_YETKILI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_YETKILI.AreaIndex = 21;
            fieldPROJE_YETKILI.FieldName = "PROJE_YETKILI";
            fieldPROJE_YETKILI.Name = "fieldPROJE_YETKILI";
            fieldPROJE_YETKILI.Visible = false;

            PivotGridField fieldHAZIRLIK_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_ID.AreaIndex = 22;
            fieldHAZIRLIK_ID.FieldName = "HAZIRLIK_ID";
            fieldHAZIRLIK_ID.Name = "fieldHAZIRLIK_ID";
            fieldHAZIRLIK_ID.Visible = false;

            PivotGridField fieldHAZIRLIK_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_NO.AreaIndex = 23;
            fieldHAZIRLIK_NO.FieldName = "HAZIRLIK_NO";
            fieldHAZIRLIK_NO.Name = "fieldHAZIRLIK_NO";
            fieldHAZIRLIK_NO.Visible = false;

            PivotGridField fieldSIKAYET_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSIKAYET_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSIKAYET_TARIHI.AreaIndex = 24;
            fieldSIKAYET_TARIHI.FieldName = "SIKAYET_TARIHI";
            fieldSIKAYET_TARIHI.Name = "fieldSIKAYET_TARIHI";
            fieldSIKAYET_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 25;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldHAZIRLIK_TARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_TARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_TARIH.AreaIndex = 26;
            fieldHAZIRLIK_TARIH.FieldName = "HAZIRLIK_TARIH";
            fieldHAZIRLIK_TARIH.Name = "fieldHAZIRLIK_TARIH";
            fieldHAZIRLIK_TARIH.Visible = false;

            PivotGridField fieldHAZIRLIK_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_ESAS_NO.AreaIndex = 27;
            fieldHAZIRLIK_ESAS_NO.FieldName = "HAZIRLIK_ESAS_NO";
            fieldHAZIRLIK_ESAS_NO.Name = "fieldHAZIRLIK_ESAS_NO";
            fieldHAZIRLIK_ESAS_NO.Visible = false;

            PivotGridField fieldSORUSTURMA_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUSTURMA_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUSTURMA_DURUM.AreaIndex = 28;
            fieldSORUSTURMA_DURUM.FieldName = "SORUSTURMA_DURUM";
            fieldSORUSTURMA_DURUM.Name = "fieldSORUSTURMA_DURUM";
            fieldSORUSTURMA_DURUM.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 29;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 30;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 31;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 32;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldINDIRIM_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_ANAPARA.AreaIndex = 33;
            fieldINDIRIM_ANAPARA.FieldName = "INDIRIM_ANAPARA";
            fieldINDIRIM_ANAPARA.Name = "fieldINDIRIM_ANAPARA";
            fieldINDIRIM_ANAPARA.Visible = false;

            PivotGridField fieldINDIRIM_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_ANAPARA_DOVIZ_ID.AreaIndex = 34;
            fieldINDIRIM_ANAPARA_DOVIZ_ID.FieldName = "INDIRIM_ANAPARA_DOVIZ_ID";
            fieldINDIRIM_ANAPARA_DOVIZ_ID.Name = "fieldINDIRIM_ANAPARA_DOVIZ_ID";
            fieldINDIRIM_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_BANKA_BAKIYESI.AreaIndex = 35;
            fieldINDIRIM_BANKA_BAKIYESI.FieldName = "INDIRIM_BANKA_BAKIYESI";
            fieldINDIRIM_BANKA_BAKIYESI.Name = "fieldINDIRIM_BANKA_BAKIYESI";
            fieldINDIRIM_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 36;
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "INDIRIM_BANKA_BAKIYESI_DOVIZ_ID";
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID";
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_FAIZ.AreaIndex = 37;
            fieldINDIRIM_FAIZ.FieldName = "INDIRIM_FAIZ";
            fieldINDIRIM_FAIZ.Name = "fieldINDIRIM_FAIZ";
            fieldINDIRIM_FAIZ.Visible = false;

            PivotGridField fieldINDIRIM_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_FAIZ_DOVIZ_ID.AreaIndex = 38;
            fieldINDIRIM_FAIZ_DOVIZ_ID.FieldName = "INDIRIM_FAIZ_DOVIZ_ID";
            fieldINDIRIM_FAIZ_DOVIZ_ID.Name = "fieldINDIRIM_FAIZ_DOVIZ_ID";
            fieldINDIRIM_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_GIDER_VERGISI.AreaIndex = 39;
            fieldINDIRIM_GIDER_VERGISI.FieldName = "INDIRIM_GIDER_VERGISI";
            fieldINDIRIM_GIDER_VERGISI.Name = "fieldINDIRIM_GIDER_VERGISI";
            fieldINDIRIM_GIDER_VERGISI.Visible = false;

            PivotGridField fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 40;
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.FieldName = "INDIRIM_GIDER_VERGISI_DOVIZ_ID";
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.Name = "fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID";
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KALAN.AreaIndex = 41;
            fieldINDIRIM_KALAN.FieldName = "INDIRIM_KALAN";
            fieldINDIRIM_KALAN.Name = "fieldINDIRIM_KALAN";
            fieldINDIRIM_KALAN.Visible = false;

            PivotGridField fieldINDIRIM_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KALAN_DOVIZ_ID.AreaIndex = 42;
            fieldINDIRIM_KALAN_DOVIZ_ID.FieldName = "INDIRIM_KALAN_DOVIZ_ID";
            fieldINDIRIM_KALAN_DOVIZ_ID.Name = "fieldINDIRIM_KALAN_DOVIZ_ID";
            fieldINDIRIM_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KOM_TAZ.AreaIndex = 43;
            fieldINDIRIM_KOM_TAZ.FieldName = "INDIRIM_KOM_TAZ";
            fieldINDIRIM_KOM_TAZ.Name = "fieldINDIRIM_KOM_TAZ";
            fieldINDIRIM_KOM_TAZ.Visible = false;

            PivotGridField fieldINDIRIM_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_MASRAF.AreaIndex = 44;
            fieldINDIRIM_MASRAF.FieldName = "INDIRIM_MASRAF";
            fieldINDIRIM_MASRAF.Name = "fieldINDIRIM_MASRAF";
            fieldINDIRIM_MASRAF.Visible = false;

            PivotGridField fieldINDIRIM_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.AreaIndex = 45;
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.FieldName = "INDIRIM_KOM_TAZ_DOVIZ_ID";
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.Name = "fieldINDIRIM_KOM_TAZ_DOVIZ_ID";
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_MASRAF_DOVIZ_ID.AreaIndex = 46;
            fieldINDIRIM_MASRAF_DOVIZ_ID.FieldName = "INDIRIM_MASRAF_DOVIZ_ID";
            fieldINDIRIM_MASRAF_DOVIZ_ID.Name = "fieldINDIRIM_MASRAF_DOVIZ_ID";
            fieldINDIRIM_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_VEKALET_UCRETI.AreaIndex = 47;
            fieldINDIRIM_VEKALET_UCRETI.FieldName = "INDIRIM_VEKALET_UCRETI";
            fieldINDIRIM_VEKALET_UCRETI.Name = "fieldINDIRIM_VEKALET_UCRETI";
            fieldINDIRIM_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 48;
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.FieldName = "INDIRIM_VEKALET_UCRETI_DOVIZ_ID";
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID";
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_ANAPARA.AreaIndex = 49;
            fieldKALAN_ANAPARA.FieldName = "KALAN_ANAPARA";
            fieldKALAN_ANAPARA.Name = "fieldKALAN_ANAPARA";
            fieldKALAN_ANAPARA.Visible = false;

            PivotGridField fieldKALAN_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_ANAPARA_DOVIZ_ID.AreaIndex = 50;
            fieldKALAN_ANAPARA_DOVIZ_ID.FieldName = "KALAN_ANAPARA_DOVIZ_ID";
            fieldKALAN_ANAPARA_DOVIZ_ID.Name = "fieldKALAN_ANAPARA_DOVIZ_ID";
            fieldKALAN_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_BANKA_BAKIYESI.AreaIndex = 51;
            fieldKALAN_BANKA_BAKIYESI.FieldName = "KALAN_BANKA_BAKIYESI";
            fieldKALAN_BANKA_BAKIYESI.Name = "fieldKALAN_BANKA_BAKIYESI";
            fieldKALAN_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 52;
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "KALAN_BANKA_BAKIYESI_DOVIZ_ID";
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID";
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_FAIZ.AreaIndex = 53;
            fieldKALAN_FAIZ.FieldName = "KALAN_FAIZ";
            fieldKALAN_FAIZ.Name = "fieldKALAN_FAIZ";
            fieldKALAN_FAIZ.Visible = false;

            PivotGridField fieldKALAN_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_FAIZ_DOVIZ_ID.AreaIndex = 54;
            fieldKALAN_FAIZ_DOVIZ_ID.FieldName = "KALAN_FAIZ_DOVIZ_ID";
            fieldKALAN_FAIZ_DOVIZ_ID.Name = "fieldKALAN_FAIZ_DOVIZ_ID";
            fieldKALAN_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_GIDER_VERGISI.AreaIndex = 55;
            fieldKALAN_GIDER_VERGISI.FieldName = "KALAN_GIDER_VERGISI";
            fieldKALAN_GIDER_VERGISI.Name = "fieldKALAN_GIDER_VERGISI";
            fieldKALAN_GIDER_VERGISI.Visible = false;

            PivotGridField fieldKALAN_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 56;
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.FieldName = "KALAN_GIDER_VERGISI_DOVIZ_ID";
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.Name = "fieldKALAN_GIDER_VERGISI_DOVIZ_ID";
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KALAN.AreaIndex = 57;
            fieldKALAN_KALAN.FieldName = "KALAN_KALAN";
            fieldKALAN_KALAN.Name = "fieldKALAN_KALAN";
            fieldKALAN_KALAN.Visible = false;

            PivotGridField fieldKALAN_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KALAN_DOVIZ_ID.AreaIndex = 58;
            fieldKALAN_KALAN_DOVIZ_ID.FieldName = "KALAN_KALAN_DOVIZ_ID";
            fieldKALAN_KALAN_DOVIZ_ID.Name = "fieldKALAN_KALAN_DOVIZ_ID";
            fieldKALAN_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KOM_TAZ.AreaIndex = 59;
            fieldKALAN_KOM_TAZ.FieldName = "KALAN_KOM_TAZ";
            fieldKALAN_KOM_TAZ.Name = "fieldKALAN_KOM_TAZ";
            fieldKALAN_KOM_TAZ.Visible = false;

            PivotGridField fieldKALAN_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KOM_TAZ_DOVIZ_ID.AreaIndex = 60;
            fieldKALAN_KOM_TAZ_DOVIZ_ID.FieldName = "KALAN_KOM_TAZ_DOVIZ_ID";
            fieldKALAN_KOM_TAZ_DOVIZ_ID.Name = "fieldKALAN_KOM_TAZ_DOVIZ_ID";
            fieldKALAN_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_MASRAF.AreaIndex = 61;
            fieldKALAN_MASRAF.FieldName = "KALAN_MASRAF";
            fieldKALAN_MASRAF.Name = "fieldKALAN_MASRAF";
            fieldKALAN_MASRAF.Visible = false;

            PivotGridField fieldKALAN_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_MASRAF_DOVIZ_ID.AreaIndex = 62;
            fieldKALAN_MASRAF_DOVIZ_ID.FieldName = "KALAN_MASRAF_DOVIZ_ID";
            fieldKALAN_MASRAF_DOVIZ_ID.Name = "fieldKALAN_MASRAF_DOVIZ_ID";
            fieldKALAN_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_VEKALET_UCRETI.AreaIndex = 63;
            fieldKALAN_VEKALET_UCRETI.FieldName = "KALAN_VEKALET_UCRETI";
            fieldKALAN_VEKALET_UCRETI.Name = "fieldKALAN_VEKALET_UCRETI";
            fieldKALAN_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldKALAN_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 64;
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.FieldName = "KALAN_VEKALET_UCRETI_DOVIZ_ID";
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldKALAN_VEKALET_UCRETI_DOVIZ_ID";
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_ANAPARA.AreaIndex = 65;
            fieldODEME_ANAPARA.FieldName = "ODEME_ANAPARA";
            fieldODEME_ANAPARA.Name = "fieldODEME_ANAPARA";
            fieldODEME_ANAPARA.Visible = false;

            PivotGridField fieldODEME_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_ANAPARA_DOVIZ_ID.AreaIndex = 66;
            fieldODEME_ANAPARA_DOVIZ_ID.FieldName = "ODEME_ANAPARA_DOVIZ_ID";
            fieldODEME_ANAPARA_DOVIZ_ID.Name = "fieldODEME_ANAPARA_DOVIZ_ID";
            fieldODEME_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_BANKA_BAKIYESI.AreaIndex = 67;
            fieldODEME_BANKA_BAKIYESI.FieldName = "ODEME_BANKA_BAKIYESI";
            fieldODEME_BANKA_BAKIYESI.Name = "fieldODEME_BANKA_BAKIYESI";
            fieldODEME_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldODEME_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 68;
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "ODEME_BANKA_BAKIYESI_DOVIZ_ID";
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldODEME_BANKA_BAKIYESI_DOVIZ_ID";
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_FAIZ.AreaIndex = 69;
            fieldODEME_FAIZ.FieldName = "ODEME_FAIZ";
            fieldODEME_FAIZ.Name = "fieldODEME_FAIZ";
            fieldODEME_FAIZ.Visible = false;

            PivotGridField fieldODEME_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_FAIZ_DOVIZ_ID.AreaIndex = 70;
            fieldODEME_FAIZ_DOVIZ_ID.FieldName = "ODEME_FAIZ_DOVIZ_ID";
            fieldODEME_FAIZ_DOVIZ_ID.Name = "fieldODEME_FAIZ_DOVIZ_ID";
            fieldODEME_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_GIDER_VERGISI.AreaIndex = 71;
            fieldODEME_GIDER_VERGISI.FieldName = "ODEME_GIDER_VERGISI";
            fieldODEME_GIDER_VERGISI.Name = "fieldODEME_GIDER_VERGISI";
            fieldODEME_GIDER_VERGISI.Visible = false;

            PivotGridField fieldODEME_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 72;
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.FieldName = "ODEME_GIDER_VERGISI_DOVIZ_ID";
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.Name = "fieldODEME_GIDER_VERGISI_DOVIZ_ID";
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KALAN.AreaIndex = 73;
            fieldODEME_KALAN.FieldName = "ODEME_KALAN";
            fieldODEME_KALAN.Name = "fieldODEME_KALAN";
            fieldODEME_KALAN.Visible = false;

            PivotGridField fieldODEME_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KALAN_DOVIZ_ID.AreaIndex = 74;
            fieldODEME_KALAN_DOVIZ_ID.FieldName = "ODEME_KALAN_DOVIZ_ID";
            fieldODEME_KALAN_DOVIZ_ID.Name = "fieldODEME_KALAN_DOVIZ_ID";
            fieldODEME_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KOM_TAZ.AreaIndex = 75;
            fieldODEME_KOM_TAZ.FieldName = "ODEME_KOM_TAZ";
            fieldODEME_KOM_TAZ.Name = "fieldODEME_KOM_TAZ";
            fieldODEME_KOM_TAZ.Visible = false;

            PivotGridField fieldODEME_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KOM_TAZ_DOVIZ_ID.AreaIndex = 76;
            fieldODEME_KOM_TAZ_DOVIZ_ID.FieldName = "ODEME_KOM_TAZ_DOVIZ_ID";
            fieldODEME_KOM_TAZ_DOVIZ_ID.Name = "fieldODEME_KOM_TAZ_DOVIZ_ID";
            fieldODEME_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MASRAF.AreaIndex = 77;
            fieldODEME_MASRAF.FieldName = "ODEME_MASRAF";
            fieldODEME_MASRAF.Name = "fieldODEME_MASRAF";
            fieldODEME_MASRAF.Visible = false;

            PivotGridField fieldODEME_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MASRAF_DOVIZ_ID.AreaIndex = 78;
            fieldODEME_MASRAF_DOVIZ_ID.FieldName = "ODEME_MASRAF_DOVIZ_ID";
            fieldODEME_MASRAF_DOVIZ_ID.Name = "fieldODEME_MASRAF_DOVIZ_ID";
            fieldODEME_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_VEKALET_UCRETI.AreaIndex = 79;
            fieldODEME_VEKALET_UCRETI.FieldName = "ODEME_VEKALET_UCRETI";
            fieldODEME_VEKALET_UCRETI.Name = "fieldODEME_VEKALET_UCRETI";
            fieldODEME_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldODEME_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 80;
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.FieldName = "ODEME_VEKALET_UCRETI_DOVIZ_ID";
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldODEME_VEKALET_UCRETI_DOVIZ_ID";
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_ANAPARA.AreaIndex = 81;
            fieldTUTAR_ANAPARA.FieldName = "TUTAR_ANAPARA";
            fieldTUTAR_ANAPARA.Name = "fieldTUTAR_ANAPARA";
            fieldTUTAR_ANAPARA.Visible = false;

            PivotGridField fieldTUTAR_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_ANAPARA_DOVIZ_ID.AreaIndex = 82;
            fieldTUTAR_ANAPARA_DOVIZ_ID.FieldName = "TUTAR_ANAPARA_DOVIZ_ID";
            fieldTUTAR_ANAPARA_DOVIZ_ID.Name = "fieldTUTAR_ANAPARA_DOVIZ_ID";
            fieldTUTAR_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_BANKA_BAKIYESI.AreaIndex = 83;
            fieldTUTAR_BANKA_BAKIYESI.FieldName = "TUTAR_BANKA_BAKIYESI";
            fieldTUTAR_BANKA_BAKIYESI.Name = "fieldTUTAR_BANKA_BAKIYESI";
            fieldTUTAR_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 84;
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "TUTAR_BANKA_BAKIYESI_DOVIZ_ID";
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID";
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_FAIZ.AreaIndex = 85;
            fieldTUTAR_FAIZ.FieldName = "TUTAR_FAIZ";
            fieldTUTAR_FAIZ.Name = "fieldTUTAR_FAIZ";
            fieldTUTAR_FAIZ.Visible = false;

            PivotGridField fieldTUTAR_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_FAIZ_DOVIZ_ID.AreaIndex = 86;
            fieldTUTAR_FAIZ_DOVIZ_ID.FieldName = "TUTAR_FAIZ_DOVIZ_ID";
            fieldTUTAR_FAIZ_DOVIZ_ID.Name = "fieldTUTAR_FAIZ_DOVIZ_ID";
            fieldTUTAR_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_GIDER_VERGISI.AreaIndex = 87;
            fieldTUTAR_GIDER_VERGISI.FieldName = "TUTAR_GIDER_VERGISI";
            fieldTUTAR_GIDER_VERGISI.Name = "fieldTUTAR_GIDER_VERGISI";
            fieldTUTAR_GIDER_VERGISI.Visible = false;

            PivotGridField fieldTUTAR_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 88;
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.FieldName = "TUTAR_GIDER_VERGISI_DOVIZ_ID";
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.Name = "fieldTUTAR_GIDER_VERGISI_DOVIZ_ID";
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KALAN.AreaIndex = 89;
            fieldTUTAR_KALAN.FieldName = "TUTAR_KALAN";
            fieldTUTAR_KALAN.Name = "fieldTUTAR_KALAN";
            fieldTUTAR_KALAN.Visible = false;

            PivotGridField fieldTUTAR_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KALAN_DOVIZ_ID.AreaIndex = 90;
            fieldTUTAR_KALAN_DOVIZ_ID.FieldName = "TUTAR_KALAN_DOVIZ_ID";
            fieldTUTAR_KALAN_DOVIZ_ID.Name = "fieldTUTAR_KALAN_DOVIZ_ID";
            fieldTUTAR_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KOM_TAZ.AreaIndex = 91;
            fieldTUTAR_KOM_TAZ.FieldName = "TUTAR_KOM_TAZ";
            fieldTUTAR_KOM_TAZ.Name = "fieldTUTAR_KOM_TAZ";
            fieldTUTAR_KOM_TAZ.Visible = false;

            PivotGridField fieldTUTAR_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.AreaIndex = 92;
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.FieldName = "TUTAR_KOM_TAZ_DOVIZ_ID";
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.Name = "fieldTUTAR_KOM_TAZ_DOVIZ_ID";
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_MASRAF.AreaIndex = 93;
            fieldTUTAR_MASRAF.FieldName = "TUTAR_MASRAF";
            fieldTUTAR_MASRAF.Name = "fieldTUTAR_MASRAF";
            fieldTUTAR_MASRAF.Visible = false;

            PivotGridField fieldTUTAR_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_MASRAF_DOVIZ_ID.AreaIndex = 94;
            fieldTUTAR_MASRAF_DOVIZ_ID.FieldName = "TUTAR_MASRAF_DOVIZ_ID";
            fieldTUTAR_MASRAF_DOVIZ_ID.Name = "fieldTUTAR_MASRAF_DOVIZ_ID";
            fieldTUTAR_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_VEKALET_UCRETI.AreaIndex = 95;
            fieldTUTAR_VEKALET_UCRETI.FieldName = "TUTAR_VEKALET_UCRETI";
            fieldTUTAR_VEKALET_UCRETI.Name = "fieldTUTAR_VEKALET_UCRETI";
            fieldTUTAR_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 96;
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TUTAR_VEKALET_UCRETI_DOVIZ_ID";
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID";
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSON_HESAP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSON_HESAP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSON_HESAP_TARIHI.AreaIndex = 97;
            fieldSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Name = "fieldSON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Visible = false;

            PivotGridField fieldHESAPLAMA_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHESAPLAMA_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHESAPLAMA_TIPI.AreaIndex = 98;
            fieldHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            fieldHESAPLAMA_TIPI.Name = "fieldHESAPLAMA_TIPI";
            fieldHESAPLAMA_TIPI.Visible = false;

            PivotGridField fieldRISK_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_TOPLAMI.AreaIndex = 99;
            fieldRISK_TOPLAMI.FieldName = "RISK_TOPLAMI";
            fieldRISK_TOPLAMI.Name = "fieldRISK_TOPLAMI";
            fieldRISK_TOPLAMI.Visible = false;

            PivotGridField fieldRISK_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_TOPLAMI_DOVIZ_ID.AreaIndex = 100;
            fieldRISK_TOPLAMI_DOVIZ_ID.FieldName = "RISK_TOPLAMI_DOVIZ_ID";
            fieldRISK_TOPLAMI_DOVIZ_ID.Name = "fieldRISK_TOPLAMI_DOVIZ_ID";
            fieldRISK_TOPLAMI_DOVIZ_ID.Visible = false;

            #endregion Field & Properties

            switch (pencere)
            {
                case "Klasöre Bağlı Soruşturma Takipler":
                    dizi = KlasoreBagliSorusturmaTakipleri();
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
			fieldID,
			fieldKOD,
			fieldADI,
			fieldBASLANGIC_TARIHI,
			fieldBITIS_TARIHI,
			fieldDURUM,
			fieldOZEL_KOD2,
			fieldOZEL_KOD1,
			fieldOZEL_KOD4,
			fieldOZEL_KOD3,
			fieldREFERANS_NO1,
			fieldREFERANS_NO2,
			fieldREFERANS_NO3,
			fieldACIKLAMA,
			fieldBOLUM,
			fieldKONTROL_KIM_ID,
			fieldSUBE_KOD_ID,
			fieldKARAR,
			fieldTEKLIF,
			fieldPROJE_TARAFI,
			fieldPROJE_SORUMLU,
			fieldPROJE_YETKILI,
			fieldHAZIRLIK_ID,
			fieldHAZIRLIK_NO,
			fieldSIKAYET_TARIHI,
			fieldDAVA_TALEP,
			fieldHAZIRLIK_TARIH,
			fieldHAZIRLIK_ESAS_NO,
			fieldSORUSTURMA_DURUM,
			fieldADLIYE,
			fieldNO,
			fieldGOREV,
			fieldREFERANS_NO,
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
			fieldKALAN_KALAN_DOVIZ_ID,
			fieldKALAN_KOM_TAZ,
			fieldKALAN_KOM_TAZ_DOVIZ_ID,
			fieldKALAN_MASRAF,
			fieldKALAN_MASRAF_DOVIZ_ID,
			fieldKALAN_VEKALET_UCRETI,
			fieldKALAN_VEKALET_UCRETI_DOVIZ_ID,
			fieldODEME_ANAPARA,
			fieldODEME_ANAPARA_DOVIZ_ID,
			fieldODEME_BANKA_BAKIYESI,
			fieldODEME_BANKA_BAKIYESI_DOVIZ_ID,
			fieldODEME_FAIZ,
			fieldODEME_FAIZ_DOVIZ_ID,
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

            #region Özelleştirme

            string RefNo, RefNo2, refNo3, OzelKod1, OzelKod2, OzelKod3, OzelKod4;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaReferans.Referans1))
                RefNo = "Ref No";
            else
                RefNo = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaReferans.Referans1;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaReferans.Referans2))
                RefNo2 = "Ref No2";
            else
                RefNo2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaReferans.Referans2;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaReferans.Referans3))
                refNo3 = "Ref No3";
            else
                refNo3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaReferans.Referans3;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod1))
                OzelKod1 = "Özel Kod1";
            else
                OzelKod1 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod1;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod2))
                OzelKod2 = "Özel Kod2";
            else
                OzelKod2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod2;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod3))
                OzelKod3 = "Özel Kod3";
            else
                OzelKod3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod3;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod4))
                OzelKod4 = "Özel Kod4";
            else
                OzelKod4 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod4;

            #endregion Özelleştirme

            #region Caption Edit

            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("KOD", "Kod");
            dicFieldCaption.Add("ADI", "Adı");
            dicFieldCaption.Add("BASLANGIC_TARIHI", "Başlangıç T.");
            dicFieldCaption.Add("BITIS_TARIHI", "Bitiş T.");
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("OZEL_KOD2", OzelKod1);
            dicFieldCaption.Add("OZEL_KOD1", OzelKod2);
            dicFieldCaption.Add("OZEL_KOD4", OzelKod4);
            dicFieldCaption.Add("OZEL_KOD3", OzelKod3);
            dicFieldCaption.Add("REFERANS_NO1", RefNo);
            dicFieldCaption.Add("REFERANS_NO2", RefNo2);
            dicFieldCaption.Add("REFERANS_NO3", refNo3);
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("BOLUM", "Bölüm");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KARAR", "Karar");
            dicFieldCaption.Add("TEKLIF", "Teklif");
            dicFieldCaption.Add("PROJE_TARAFI", "Taraf");
            dicFieldCaption.Add("PROJE_SORUMLU", "Sorumlu");
            dicFieldCaption.Add("PROJE_YETKILI", "Yetkili");
            dicFieldCaption.Add("HAZIRLIK_ID", "Kayıt Sayısı");
            dicFieldCaption.Add("HAZIRLIK_NO", "Dosya No");
            dicFieldCaption.Add("SIKAYET_TARIHI", "Şikayet T.");
            dicFieldCaption.Add("DAVA_TALEP", "Şikayet Konu");
            dicFieldCaption.Add("HAZIRLIK_TARIH", "Soruşturma T.");
            dicFieldCaption.Add("HAZIRLIK_ESAS_NO", "Soruşturma Esas No");
            dicFieldCaption.Add("SORUSTURMA_DURUM", "Soruşturma Durum");
            dicFieldCaption.Add("ADLIYE", "Mahkeme");
            dicFieldCaption.Add("NO", "No");
            dicFieldCaption.Add("GOREV", "Görev");
            dicFieldCaption.Add("REFERANS_NO", "Referans No");
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

            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("INDIRIM_KALAN", InitsEx.ParaBicimiAyarla);
            sozluk.Add("KALAN_ANAPARA", InitsEx.ParaBicimiAyarla);
            sozluk.Add("KALAN_BANKA_BAKIYESI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("KALAN_FAIZ", InitsEx.ParaBicimiAyarla);
            sozluk.Add("KALAN_GIDER_VERGISI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("KALAN_KALAN", InitsEx.ParaBicimiAyarla);
            sozluk.Add("KALAN_KOM_TAZ", InitsEx.ParaBicimiAyarla);
            sozluk.Add("KALAN_MASRAF", InitsEx.ParaBicimiAyarla);
            sozluk.Add("KALAN_VEKALET_UCRETI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("ODEME_KALAN", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TUTAR_ANAPARA", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TUTAR_ANAPARA_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_BANKA_BAKIYESI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TUTAR_BANKA_BAKIYESI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_FAIZ", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TUTAR_FAIZ_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_GIDER_VERGISI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TUTAR_GIDER_VERGISI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_KALAN", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TUTAR_KALAN_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_KOM_TAZ", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TUTAR_KOM_TAZ_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_MASRAF", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TUTAR_MASRAF_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("TUTAR_VEKALET_UCRETI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TUTAR_VEKALET_UCRETI_DOVIZ_ID", InitsEx.DovizTipGetir);

            #endregion Add item

            return sozluk;
        }

        private PivotGridField[] KlasoreBagliSorusturmaTakipleri()
        {
            PivotGridField[] dizi = null;

            #region Field & Properties

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldBASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASLANGIC_TARIHI.AreaIndex = 3;
            fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Visible = true;

            PivotGridField fieldBITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_TARIHI.AreaIndex = 4;
            fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
            fieldBITIS_TARIHI.Visible = true;

            PivotGridField fieldKOD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKOD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKOD.AreaIndex = 1;
            fieldKOD.FieldName = "KOD";
            fieldKOD.Name = "fieldKOD";
            fieldKOD.Visible = false;

            PivotGridField fieldADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldADI.AreaIndex = 2;
            fieldADI.FieldName = "ADI";
            fieldADI.Name = "fieldADI";
            fieldADI.Visible = true;

            PivotGridField fieldOZEL_KOD1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD1.AreaIndex = 7;
            fieldOZEL_KOD1.FieldName = "OZEL_KOD1";
            fieldOZEL_KOD1.Name = "fieldOZEL_KOD1";
            fieldOZEL_KOD1.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 14;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 15;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 16;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldPROJE_SORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_SORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_SORUMLU.AreaIndex = 20;
            fieldPROJE_SORUMLU.FieldName = "PROJE_SORUMLU";
            fieldPROJE_SORUMLU.Name = "fieldPROJE_SORUMLU";
            fieldPROJE_SORUMLU.Visible = false;

            PivotGridField fieldPROJE_YETKILI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_YETKILI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_YETKILI.AreaIndex = 21;
            fieldPROJE_YETKILI.FieldName = "PROJE_YETKILI";
            fieldPROJE_YETKILI.Name = "fieldPROJE_YETKILI";
            fieldPROJE_YETKILI.Visible = false;

            PivotGridField fieldHAZIRLIK_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldHAZIRLIK_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldHAZIRLIK_ID.AreaIndex = 22;
            fieldHAZIRLIK_ID.FieldName = "HAZIRLIK_ID";
            fieldHAZIRLIK_ID.Name = "fieldHAZIRLIK_ID";
            fieldHAZIRLIK_ID.Visible = true;

            PivotGridField fieldHAZIRLIK_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_NO.AreaIndex = 23;
            fieldHAZIRLIK_NO.FieldName = "HAZIRLIK_NO";
            fieldHAZIRLIK_NO.Name = "fieldHAZIRLIK_NO";
            fieldHAZIRLIK_NO.Visible = false;

            PivotGridField fieldSIKAYET_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSIKAYET_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSIKAYET_TARIHI.AreaIndex = 24;
            fieldSIKAYET_TARIHI.FieldName = "SIKAYET_TARIHI";
            fieldSIKAYET_TARIHI.Name = "fieldSIKAYET_TARIHI";
            fieldSIKAYET_TARIHI.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDAVA_TALEP.AreaIndex = 25;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = true;

            PivotGridField fieldHAZIRLIK_TARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_TARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_TARIH.AreaIndex = 26;
            fieldHAZIRLIK_TARIH.FieldName = "HAZIRLIK_TARIH";
            fieldHAZIRLIK_TARIH.Name = "fieldHAZIRLIK_TARIH";
            fieldHAZIRLIK_TARIH.Visible = false;

            PivotGridField fieldHAZIRLIK_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_ESAS_NO.AreaIndex = 27;
            fieldHAZIRLIK_ESAS_NO.FieldName = "HAZIRLIK_ESAS_NO";
            fieldHAZIRLIK_ESAS_NO.Name = "fieldHAZIRLIK_ESAS_NO";
            fieldHAZIRLIK_ESAS_NO.Visible = false;

            PivotGridField fieldSORUSTURMA_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUSTURMA_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUSTURMA_DURUM.AreaIndex = 28;
            fieldSORUSTURMA_DURUM.FieldName = "SORUSTURMA_DURUM";
            fieldSORUSTURMA_DURUM.Name = "fieldSORUSTURMA_DURUM";
            fieldSORUSTURMA_DURUM.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 29;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 30;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 31;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            #endregion Field & Properties

            #region []

            dizi = new PivotGridField[]
		{
            fieldID,
            fieldBASLANGIC_TARIHI,
            fieldBITIS_TARIHI,
            fieldKOD,
            fieldADI,
			fieldOZEL_KOD1,
			fieldBOLUM,
            fieldKONTROL_KIM_ID,
            fieldSUBE_KOD_ID,
			fieldPROJE_SORUMLU,
			fieldHAZIRLIK_ID,
			fieldHAZIRLIK_NO,
			fieldSIKAYET_TARIHI,
			fieldDAVA_TALEP,
			fieldHAZIRLIK_TARIH,
			fieldHAZIRLIK_ESAS_NO,
			fieldSORUSTURMA_DURUM,
            fieldADLIYE,
            fieldNO,
            fieldGOREV,
			};
            return dizi;

            #endregion []
        }
    }
}