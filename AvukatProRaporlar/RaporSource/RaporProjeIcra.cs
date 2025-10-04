using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class RaporProjeIcra
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

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 1;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colICRA_FOY_ID = new GridColumn();
            colICRA_FOY_ID.VisibleIndex = 2;
            colICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            colICRA_FOY_ID.Name = "colICRA_FOY_ID";
            colICRA_FOY_ID.Visible = true;

            GridColumn colTAKIP_EDEN_SIFAT = new GridColumn();
            colTAKIP_EDEN_SIFAT.VisibleIndex = 3;
            colTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Name = "colTAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 4;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colTAKIP_EDILEN_SIFAT = new GridColumn();
            colTAKIP_EDILEN_SIFAT.VisibleIndex = 5;
            colTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Name = "colTAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Visible = true;

            GridColumn colKOD = new GridColumn();
            colKOD.VisibleIndex = 6;
            colKOD.FieldName = "KOD";
            colKOD.Name = "colKOD";
            colKOD.Visible = true;

            GridColumn colADI = new GridColumn();
            colADI.VisibleIndex = 7;
            colADI.FieldName = "ADI";
            colADI.Name = "colADI";
            colADI.Visible = true;

            GridColumn colBASLANGIC_TARIHI = new GridColumn();
            colBASLANGIC_TARIHI.VisibleIndex = 8;
            colBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            colBASLANGIC_TARIHI.Name = "colBASLANGIC_TARIHI";
            colBASLANGIC_TARIHI.Visible = true;

            GridColumn colBITIS_TARIHI = new GridColumn();
            colBITIS_TARIHI.VisibleIndex = 9;
            colBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            colBITIS_TARIHI.Name = "colBITIS_TARIHI";
            colBITIS_TARIHI.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 10;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 11;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 12;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 13;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 14;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.Visible = true;

            GridColumn colREFERANS_NO1 = new GridColumn();
            colREFERANS_NO1.VisibleIndex = 15;
            colREFERANS_NO1.FieldName = "REFERANS_NO1";
            colREFERANS_NO1.Name = "colREFERANS_NO1";
            colREFERANS_NO1.Visible = true;

            GridColumn colREFERANS_NO2 = new GridColumn();
            colREFERANS_NO2.VisibleIndex = 16;
            colREFERANS_NO2.FieldName = "REFERANS_NO2";
            colREFERANS_NO2.Name = "colREFERANS_NO2";
            colREFERANS_NO2.Visible = true;

            GridColumn colREFERANS_NO3 = new GridColumn();
            colREFERANS_NO3.VisibleIndex = 17;
            colREFERANS_NO3.FieldName = "REFERANS_NO3";
            colREFERANS_NO3.Name = "colREFERANS_NO3";
            colREFERANS_NO3.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 18;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 19;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

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

            GridColumn colKARAR = new GridColumn();
            colKARAR.VisibleIndex = 22;
            colKARAR.FieldName = "KARAR";
            colKARAR.Name = "colKARAR";
            colKARAR.Visible = true;

            GridColumn colTEKLIF = new GridColumn();
            colTEKLIF.VisibleIndex = 23;
            colTEKLIF.FieldName = "TEKLIF";
            colTEKLIF.Name = "colTEKLIF";
            colTEKLIF.Visible = true;

            GridColumn colPROJE_TARAFI = new GridColumn();
            colPROJE_TARAFI.VisibleIndex = 24;
            colPROJE_TARAFI.FieldName = "PROJE_TARAFI";
            colPROJE_TARAFI.Name = "colPROJE_TARAFI";
            colPROJE_TARAFI.Visible = true;

            GridColumn colPROJE_SORUMLU = new GridColumn();
            colPROJE_SORUMLU.VisibleIndex = 25;
            colPROJE_SORUMLU.FieldName = "PROJE_SORUMLU";
            colPROJE_SORUMLU.Name = "colPROJE_SORUMLU";
            colPROJE_SORUMLU.Visible = true;

            GridColumn colPROJE_YETKILI = new GridColumn();
            colPROJE_YETKILI.VisibleIndex = 26;
            colPROJE_YETKILI.FieldName = "PROJE_YETKILI";
            colPROJE_YETKILI.Name = "colPROJE_YETKILI";
            colPROJE_YETKILI.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 27;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colICRA_DURUM = new GridColumn();
            colICRA_DURUM.VisibleIndex = 28;
            colICRA_DURUM.FieldName = "ICRA_DURUM";
            colICRA_DURUM.Name = "colICRA_DURUM";
            colICRA_DURUM.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 29;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colADLI_BIRIM_ADLIYE = new GridColumn();
            colADLI_BIRIM_ADLIYE.VisibleIndex = 30;
            colADLI_BIRIM_ADLIYE.FieldName = "ADLI_BIRIM_ADLIYE";
            colADLI_BIRIM_ADLIYE.Name = "colADLI_BIRIM_ADLIYE";
            colADLI_BIRIM_ADLIYE.Visible = true;

            GridColumn colADLI_BIRIM_GOREV = new GridColumn();
            colADLI_BIRIM_GOREV.VisibleIndex = 31;
            colADLI_BIRIM_GOREV.FieldName = "ADLI_BIRIM_GOREV";
            colADLI_BIRIM_GOREV.Name = "colADLI_BIRIM_GOREV";
            colADLI_BIRIM_GOREV.Visible = true;

            GridColumn colADLI_BIRIM_NO = new GridColumn();
            colADLI_BIRIM_NO.VisibleIndex = 32;
            colADLI_BIRIM_NO.FieldName = "ADLI_BIRIM_NO";
            colADLI_BIRIM_NO.Name = "colADLI_BIRIM_NO";
            colADLI_BIRIM_NO.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 33;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colICRA_OZEL_KOD1 = new GridColumn();
            colICRA_OZEL_KOD1.VisibleIndex = 34;
            colICRA_OZEL_KOD1.FieldName = "ICRA_OZEL_KOD1";
            colICRA_OZEL_KOD1.Name = "colICRA_OZEL_KOD1";
            colICRA_OZEL_KOD1.Visible = true;

            GridColumn colICRA_OZEL_KOD2 = new GridColumn();
            colICRA_OZEL_KOD2.VisibleIndex = 35;
            colICRA_OZEL_KOD2.FieldName = "ICRA_OZEL_KOD2";
            colICRA_OZEL_KOD2.Name = "colICRA_OZEL_KOD2";
            colICRA_OZEL_KOD2.Visible = true;

            GridColumn colICRA_OZEL_KOD3 = new GridColumn();
            colICRA_OZEL_KOD3.VisibleIndex = 36;
            colICRA_OZEL_KOD3.FieldName = "ICRA_OZEL_KOD3";
            colICRA_OZEL_KOD3.Name = "colICRA_OZEL_KOD3";
            colICRA_OZEL_KOD3.Visible = true;

            GridColumn colICRA_OZEL_KOD4 = new GridColumn();
            colICRA_OZEL_KOD4.VisibleIndex = 37;
            colICRA_OZEL_KOD4.FieldName = "ICRA_OZEL_KOD4";
            colICRA_OZEL_KOD4.Name = "colICRA_OZEL_KOD4";
            colICRA_OZEL_KOD4.Visible = true;

            GridColumn colTAKIBIN_AVUKATA_INTIKAL_TARIHI = new GridColumn();
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 38;
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "colTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colASIL_ALACAK = new GridColumn();
            colASIL_ALACAK.VisibleIndex = 39;
            colASIL_ALACAK.FieldName = "ASIL_ALACAK";
            colASIL_ALACAK.Name = "colASIL_ALACAK";
            colASIL_ALACAK.Visible = true;

            GridColumn colASIL_ALACAK_DOVIZ_ID = new GridColumn();
            colASIL_ALACAK_DOVIZ_ID.VisibleIndex = 40;
            colASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Name = "colASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Visible = true;

            GridColumn colISLEMIS_FAIZ = new GridColumn();
            colISLEMIS_FAIZ.VisibleIndex = 41;
            colISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Name = "colISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Visible = true;

            GridColumn colISLEMIS_FAIZ_DOVIZ_ID = new GridColumn();
            colISLEMIS_FAIZ_DOVIZ_ID.VisibleIndex = 42;
            colISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Name = "colISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colSON_HESAP_TARIHI = new GridColumn();
            colSON_HESAP_TARIHI.VisibleIndex = 43;
            colSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Name = "colSON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Visible = true;

            GridColumn colTAKIP_CIKISI = new GridColumn();
            colTAKIP_CIKISI.VisibleIndex = 44;
            colTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            colTAKIP_CIKISI.Name = "colTAKIP_CIKISI";
            colTAKIP_CIKISI.Visible = true;

            GridColumn colTAKIP_CIKISI_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKISI_DOVIZ_ID.VisibleIndex = 45;
            colTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Name = "colTAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Visible = true;

            GridColumn colSONRAKI_FAIZ = new GridColumn();
            colSONRAKI_FAIZ.VisibleIndex = 46;
            colSONRAKI_FAIZ.FieldName = "SONRAKI_FAIZ";
            colSONRAKI_FAIZ.Name = "colSONRAKI_FAIZ";
            colSONRAKI_FAIZ.Visible = true;

            GridColumn colSONRAKI_FAIZ_DOVIZ_ID = new GridColumn();
            colSONRAKI_FAIZ_DOVIZ_ID.VisibleIndex = 47;
            colSONRAKI_FAIZ_DOVIZ_ID.FieldName = "SONRAKI_FAIZ_DOVIZ_ID";
            colSONRAKI_FAIZ_DOVIZ_ID.Name = "colSONRAKI_FAIZ_DOVIZ_ID";
            colSONRAKI_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colODEME_TOPLAMI = new GridColumn();
            colODEME_TOPLAMI.VisibleIndex = 48;
            colODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            colODEME_TOPLAMI.Name = "colODEME_TOPLAMI";
            colODEME_TOPLAMI.Visible = true;

            GridColumn colODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 49;
            colODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Name = "colODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN = new GridColumn();
            colKALAN.VisibleIndex = 50;
            colKALAN.FieldName = "KALAN";
            colKALAN.Name = "colKALAN";
            colKALAN.Visible = true;

            GridColumn colKALAN_DOVIZ_ID = new GridColumn();
            colKALAN_DOVIZ_ID.VisibleIndex = 51;
            colKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Name = "colKALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Visible = true;

            GridColumn colKAPAMA_TARIHI = new GridColumn();
            colKAPAMA_TARIHI.VisibleIndex = 52;
            colKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            colKAPAMA_TARIHI.Name = "colKAPAMA_TARIHI";
            colKAPAMA_TARIHI.Visible = true;

            GridColumn colRISK_MIKTARI = new GridColumn();
            colRISK_MIKTARI.VisibleIndex = 53;
            colRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            colRISK_MIKTARI.Name = "colRISK_MIKTARI";
            colRISK_MIKTARI.Visible = true;

            GridColumn colRISK_MIKTARI_DOVIZ_ID = new GridColumn();
            colRISK_MIKTARI_DOVIZ_ID.VisibleIndex = 54;
            colRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Name = "colRISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_ANAPARA = new GridColumn();
            colINDIRIM_ANAPARA.VisibleIndex = 55;
            colINDIRIM_ANAPARA.FieldName = "INDIRIM_ANAPARA";
            colINDIRIM_ANAPARA.Name = "colINDIRIM_ANAPARA";
            colINDIRIM_ANAPARA.Visible = true;

            GridColumn colINDIRIM_ANAPARA_DOVIZ_ID = new GridColumn();
            colINDIRIM_ANAPARA_DOVIZ_ID.VisibleIndex = 56;
            colINDIRIM_ANAPARA_DOVIZ_ID.FieldName = "INDIRIM_ANAPARA_DOVIZ_ID";
            colINDIRIM_ANAPARA_DOVIZ_ID.Name = "colINDIRIM_ANAPARA_DOVIZ_ID";
            colINDIRIM_ANAPARA_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_BANKA_BAKIYESI = new GridColumn();
            colINDIRIM_BANKA_BAKIYESI.VisibleIndex = 57;
            colINDIRIM_BANKA_BAKIYESI.FieldName = "INDIRIM_BANKA_BAKIYESI";
            colINDIRIM_BANKA_BAKIYESI.Name = "colINDIRIM_BANKA_BAKIYESI";
            colINDIRIM_BANKA_BAKIYESI.Visible = true;

            GridColumn colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID = new GridColumn();
            colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.VisibleIndex = 58;
            colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "INDIRIM_BANKA_BAKIYESI_DOVIZ_ID";
            colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Name = "colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID";
            colINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_FAIZ = new GridColumn();
            colINDIRIM_FAIZ.VisibleIndex = 59;
            colINDIRIM_FAIZ.FieldName = "INDIRIM_FAIZ";
            colINDIRIM_FAIZ.Name = "colINDIRIM_FAIZ";
            colINDIRIM_FAIZ.Visible = true;

            GridColumn colINDIRIM_FAIZ_DOVIZ_ID = new GridColumn();
            colINDIRIM_FAIZ_DOVIZ_ID.VisibleIndex = 60;
            colINDIRIM_FAIZ_DOVIZ_ID.FieldName = "INDIRIM_FAIZ_DOVIZ_ID";
            colINDIRIM_FAIZ_DOVIZ_ID.Name = "colINDIRIM_FAIZ_DOVIZ_ID";
            colINDIRIM_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_GIDER_VERGISI = new GridColumn();
            colINDIRIM_GIDER_VERGISI.VisibleIndex = 61;
            colINDIRIM_GIDER_VERGISI.FieldName = "INDIRIM_GIDER_VERGISI";
            colINDIRIM_GIDER_VERGISI.Name = "colINDIRIM_GIDER_VERGISI";
            colINDIRIM_GIDER_VERGISI.Visible = true;

            GridColumn colINDIRIM_GIDER_VERGISI_DOVIZ_ID = new GridColumn();
            colINDIRIM_GIDER_VERGISI_DOVIZ_ID.VisibleIndex = 62;
            colINDIRIM_GIDER_VERGISI_DOVIZ_ID.FieldName = "INDIRIM_GIDER_VERGISI_DOVIZ_ID";
            colINDIRIM_GIDER_VERGISI_DOVIZ_ID.Name = "colINDIRIM_GIDER_VERGISI_DOVIZ_ID";
            colINDIRIM_GIDER_VERGISI_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_KALAN = new GridColumn();
            colINDIRIM_KALAN.VisibleIndex = 63;
            colINDIRIM_KALAN.FieldName = "INDIRIM_KALAN";
            colINDIRIM_KALAN.Name = "colINDIRIM_KALAN";
            colINDIRIM_KALAN.Visible = true;

            GridColumn colINDIRIM_KALAN_DOVIZ_ID = new GridColumn();
            colINDIRIM_KALAN_DOVIZ_ID.VisibleIndex = 64;
            colINDIRIM_KALAN_DOVIZ_ID.FieldName = "INDIRIM_KALAN_DOVIZ_ID";
            colINDIRIM_KALAN_DOVIZ_ID.Name = "colINDIRIM_KALAN_DOVIZ_ID";
            colINDIRIM_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_KOM_TAZ = new GridColumn();
            colINDIRIM_KOM_TAZ.VisibleIndex = 65;
            colINDIRIM_KOM_TAZ.FieldName = "INDIRIM_KOM_TAZ";
            colINDIRIM_KOM_TAZ.Name = "colINDIRIM_KOM_TAZ";
            colINDIRIM_KOM_TAZ.Visible = true;

            GridColumn colINDIRIM_MASRAF = new GridColumn();
            colINDIRIM_MASRAF.VisibleIndex = 66;
            colINDIRIM_MASRAF.FieldName = "INDIRIM_MASRAF";
            colINDIRIM_MASRAF.Name = "colINDIRIM_MASRAF";
            colINDIRIM_MASRAF.Visible = true;

            GridColumn colINDIRIM_KOM_TAZ_DOVIZ_ID = new GridColumn();
            colINDIRIM_KOM_TAZ_DOVIZ_ID.VisibleIndex = 67;
            colINDIRIM_KOM_TAZ_DOVIZ_ID.FieldName = "INDIRIM_KOM_TAZ_DOVIZ_ID";
            colINDIRIM_KOM_TAZ_DOVIZ_ID.Name = "colINDIRIM_KOM_TAZ_DOVIZ_ID";
            colINDIRIM_KOM_TAZ_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_MASRAF_DOVIZ_ID = new GridColumn();
            colINDIRIM_MASRAF_DOVIZ_ID.VisibleIndex = 68;
            colINDIRIM_MASRAF_DOVIZ_ID.FieldName = "INDIRIM_MASRAF_DOVIZ_ID";
            colINDIRIM_MASRAF_DOVIZ_ID.Name = "colINDIRIM_MASRAF_DOVIZ_ID";
            colINDIRIM_MASRAF_DOVIZ_ID.Visible = true;

            GridColumn colINDIRIM_VEKALET_UCRETI = new GridColumn();
            colINDIRIM_VEKALET_UCRETI.VisibleIndex = 69;
            colINDIRIM_VEKALET_UCRETI.FieldName = "INDIRIM_VEKALET_UCRETI";
            colINDIRIM_VEKALET_UCRETI.Name = "colINDIRIM_VEKALET_UCRETI";
            colINDIRIM_VEKALET_UCRETI.Visible = true;

            GridColumn colINDIRIM_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colINDIRIM_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 70;
            colINDIRIM_VEKALET_UCRETI_DOVIZ_ID.FieldName = "INDIRIM_VEKALET_UCRETI_DOVIZ_ID";
            colINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Name = "colINDIRIM_VEKALET_UCRETI_DOVIZ_ID";
            colINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_ANAPARA = new GridColumn();
            colKALAN_ANAPARA.VisibleIndex = 71;
            colKALAN_ANAPARA.FieldName = "KALAN_ANAPARA";
            colKALAN_ANAPARA.Name = "colKALAN_ANAPARA";
            colKALAN_ANAPARA.Visible = true;

            GridColumn colKALAN_ANAPARA_DOVIZ_ID = new GridColumn();
            colKALAN_ANAPARA_DOVIZ_ID.VisibleIndex = 72;
            colKALAN_ANAPARA_DOVIZ_ID.FieldName = "KALAN_ANAPARA_DOVIZ_ID";
            colKALAN_ANAPARA_DOVIZ_ID.Name = "colKALAN_ANAPARA_DOVIZ_ID";
            colKALAN_ANAPARA_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_BANKA_BAKIYESI = new GridColumn();
            colKALAN_BANKA_BAKIYESI.VisibleIndex = 73;
            colKALAN_BANKA_BAKIYESI.FieldName = "KALAN_BANKA_BAKIYESI";
            colKALAN_BANKA_BAKIYESI.Name = "colKALAN_BANKA_BAKIYESI";
            colKALAN_BANKA_BAKIYESI.Visible = true;

            GridColumn colKALAN_BANKA_BAKIYESI_DOVIZ_ID = new GridColumn();
            colKALAN_BANKA_BAKIYESI_DOVIZ_ID.VisibleIndex = 74;
            colKALAN_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "KALAN_BANKA_BAKIYESI_DOVIZ_ID";
            colKALAN_BANKA_BAKIYESI_DOVIZ_ID.Name = "colKALAN_BANKA_BAKIYESI_DOVIZ_ID";
            colKALAN_BANKA_BAKIYESI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_FAIZ = new GridColumn();
            colKALAN_FAIZ.VisibleIndex = 75;
            colKALAN_FAIZ.FieldName = "KALAN_FAIZ";
            colKALAN_FAIZ.Name = "colKALAN_FAIZ";
            colKALAN_FAIZ.Visible = true;

            GridColumn colKALAN_FAIZ_DOVIZ_ID = new GridColumn();
            colKALAN_FAIZ_DOVIZ_ID.VisibleIndex = 76;
            colKALAN_FAIZ_DOVIZ_ID.FieldName = "KALAN_FAIZ_DOVIZ_ID";
            colKALAN_FAIZ_DOVIZ_ID.Name = "colKALAN_FAIZ_DOVIZ_ID";
            colKALAN_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_GIDER_VERGISI = new GridColumn();
            colKALAN_GIDER_VERGISI.VisibleIndex = 77;
            colKALAN_GIDER_VERGISI.FieldName = "KALAN_GIDER_VERGISI";
            colKALAN_GIDER_VERGISI.Name = "colKALAN_GIDER_VERGISI";
            colKALAN_GIDER_VERGISI.Visible = true;

            GridColumn colKALAN_GIDER_VERGISI_DOVIZ_ID = new GridColumn();
            colKALAN_GIDER_VERGISI_DOVIZ_ID.VisibleIndex = 78;
            colKALAN_GIDER_VERGISI_DOVIZ_ID.FieldName = "KALAN_GIDER_VERGISI_DOVIZ_ID";
            colKALAN_GIDER_VERGISI_DOVIZ_ID.Name = "colKALAN_GIDER_VERGISI_DOVIZ_ID";
            colKALAN_GIDER_VERGISI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_KALAN = new GridColumn();
            colKALAN_KALAN.VisibleIndex = 79;
            colKALAN_KALAN.FieldName = "KALAN_KALAN";
            colKALAN_KALAN.Name = "colKALAN_KALAN";
            colKALAN_KALAN.Visible = true;

            GridColumn colKALAN_KALAN_DOVIZ_ID = new GridColumn();
            colKALAN_KALAN_DOVIZ_ID.VisibleIndex = 80;
            colKALAN_KALAN_DOVIZ_ID.FieldName = "KALAN_KALAN_DOVIZ_ID";
            colKALAN_KALAN_DOVIZ_ID.Name = "colKALAN_KALAN_DOVIZ_ID";
            colKALAN_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_KOM_TAZ = new GridColumn();
            colKALAN_KOM_TAZ.VisibleIndex = 81;
            colKALAN_KOM_TAZ.FieldName = "KALAN_KOM_TAZ";
            colKALAN_KOM_TAZ.Name = "colKALAN_KOM_TAZ";
            colKALAN_KOM_TAZ.Visible = true;

            GridColumn colKALAN_KOM_TAZ_DOVIZ_ID = new GridColumn();
            colKALAN_KOM_TAZ_DOVIZ_ID.VisibleIndex = 82;
            colKALAN_KOM_TAZ_DOVIZ_ID.FieldName = "KALAN_KOM_TAZ_DOVIZ_ID";
            colKALAN_KOM_TAZ_DOVIZ_ID.Name = "colKALAN_KOM_TAZ_DOVIZ_ID";
            colKALAN_KOM_TAZ_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_MASRAF = new GridColumn();
            colKALAN_MASRAF.VisibleIndex = 83;
            colKALAN_MASRAF.FieldName = "KALAN_MASRAF";
            colKALAN_MASRAF.Name = "colKALAN_MASRAF";
            colKALAN_MASRAF.Visible = true;

            GridColumn colKALAN_MASRAF_DOVIZ_ID = new GridColumn();
            colKALAN_MASRAF_DOVIZ_ID.VisibleIndex = 84;
            colKALAN_MASRAF_DOVIZ_ID.FieldName = "KALAN_MASRAF_DOVIZ_ID";
            colKALAN_MASRAF_DOVIZ_ID.Name = "colKALAN_MASRAF_DOVIZ_ID";
            colKALAN_MASRAF_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_VEKALET_UCRETI = new GridColumn();
            colKALAN_VEKALET_UCRETI.VisibleIndex = 85;
            colKALAN_VEKALET_UCRETI.FieldName = "KALAN_VEKALET_UCRETI";
            colKALAN_VEKALET_UCRETI.Name = "colKALAN_VEKALET_UCRETI";
            colKALAN_VEKALET_UCRETI.Visible = true;

            GridColumn colKALAN_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colKALAN_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 86;
            colKALAN_VEKALET_UCRETI_DOVIZ_ID.FieldName = "KALAN_VEKALET_UCRETI_DOVIZ_ID";
            colKALAN_VEKALET_UCRETI_DOVIZ_ID.Name = "colKALAN_VEKALET_UCRETI_DOVIZ_ID";
            colKALAN_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_ANAPARA = new GridColumn();
            colODEME_ANAPARA.VisibleIndex = 87;
            colODEME_ANAPARA.FieldName = "ODEME_ANAPARA";
            colODEME_ANAPARA.Name = "colODEME_ANAPARA";
            colODEME_ANAPARA.Visible = true;

            GridColumn colODEME_ANAPARA_DOVIZ_ID = new GridColumn();
            colODEME_ANAPARA_DOVIZ_ID.VisibleIndex = 88;
            colODEME_ANAPARA_DOVIZ_ID.FieldName = "ODEME_ANAPARA_DOVIZ_ID";
            colODEME_ANAPARA_DOVIZ_ID.Name = "colODEME_ANAPARA_DOVIZ_ID";
            colODEME_ANAPARA_DOVIZ_ID.Visible = true;

            GridColumn colODEME_BANKA_BAKIYESI = new GridColumn();
            colODEME_BANKA_BAKIYESI.VisibleIndex = 89;
            colODEME_BANKA_BAKIYESI.FieldName = "ODEME_BANKA_BAKIYESI";
            colODEME_BANKA_BAKIYESI.Name = "colODEME_BANKA_BAKIYESI";
            colODEME_BANKA_BAKIYESI.Visible = true;

            GridColumn colODEME_BANKA_BAKIYESI_DOVIZ_ID = new GridColumn();
            colODEME_BANKA_BAKIYESI_DOVIZ_ID.VisibleIndex = 90;
            colODEME_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "ODEME_BANKA_BAKIYESI_DOVIZ_ID";
            colODEME_BANKA_BAKIYESI_DOVIZ_ID.Name = "colODEME_BANKA_BAKIYESI_DOVIZ_ID";
            colODEME_BANKA_BAKIYESI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_FAIZ = new GridColumn();
            colODEME_FAIZ.VisibleIndex = 91;
            colODEME_FAIZ.FieldName = "ODEME_FAIZ";
            colODEME_FAIZ.Name = "colODEME_FAIZ";
            colODEME_FAIZ.Visible = true;

            GridColumn colODEME_FAIZ_DOVIZ_ID = new GridColumn();
            colODEME_FAIZ_DOVIZ_ID.VisibleIndex = 92;
            colODEME_FAIZ_DOVIZ_ID.FieldName = "ODEME_FAIZ_DOVIZ_ID";
            colODEME_FAIZ_DOVIZ_ID.Name = "colODEME_FAIZ_DOVIZ_ID";
            colODEME_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colODEME_GIDER_VERGISI = new GridColumn();
            colODEME_GIDER_VERGISI.VisibleIndex = 93;
            colODEME_GIDER_VERGISI.FieldName = "ODEME_GIDER_VERGISI";
            colODEME_GIDER_VERGISI.Name = "colODEME_GIDER_VERGISI";
            colODEME_GIDER_VERGISI.Visible = true;

            GridColumn colODEME_GIDER_VERGISI_DOVIZ_ID = new GridColumn();
            colODEME_GIDER_VERGISI_DOVIZ_ID.VisibleIndex = 94;
            colODEME_GIDER_VERGISI_DOVIZ_ID.FieldName = "ODEME_GIDER_VERGISI_DOVIZ_ID";
            colODEME_GIDER_VERGISI_DOVIZ_ID.Name = "colODEME_GIDER_VERGISI_DOVIZ_ID";
            colODEME_GIDER_VERGISI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_KALAN = new GridColumn();
            colODEME_KALAN.VisibleIndex = 95;
            colODEME_KALAN.FieldName = "ODEME_KALAN";
            colODEME_KALAN.Name = "colODEME_KALAN";
            colODEME_KALAN.Visible = true;

            GridColumn colODEME_KALAN_DOVIZ_ID = new GridColumn();
            colODEME_KALAN_DOVIZ_ID.VisibleIndex = 96;
            colODEME_KALAN_DOVIZ_ID.FieldName = "ODEME_KALAN_DOVIZ_ID";
            colODEME_KALAN_DOVIZ_ID.Name = "colODEME_KALAN_DOVIZ_ID";
            colODEME_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colODEME_KOM_TAZ = new GridColumn();
            colODEME_KOM_TAZ.VisibleIndex = 97;
            colODEME_KOM_TAZ.FieldName = "ODEME_KOM_TAZ";
            colODEME_KOM_TAZ.Name = "colODEME_KOM_TAZ";
            colODEME_KOM_TAZ.Visible = true;

            GridColumn colODEME_KOM_TAZ_DOVIZ_ID = new GridColumn();
            colODEME_KOM_TAZ_DOVIZ_ID.VisibleIndex = 98;
            colODEME_KOM_TAZ_DOVIZ_ID.FieldName = "ODEME_KOM_TAZ_DOVIZ_ID";
            colODEME_KOM_TAZ_DOVIZ_ID.Name = "colODEME_KOM_TAZ_DOVIZ_ID";
            colODEME_KOM_TAZ_DOVIZ_ID.Visible = true;

            GridColumn colODEME_MASRAF = new GridColumn();
            colODEME_MASRAF.VisibleIndex = 99;
            colODEME_MASRAF.FieldName = "ODEME_MASRAF";
            colODEME_MASRAF.Name = "colODEME_MASRAF";
            colODEME_MASRAF.Visible = true;

            GridColumn colODEME_MASRAF_DOVIZ_ID = new GridColumn();
            colODEME_MASRAF_DOVIZ_ID.VisibleIndex = 100;
            colODEME_MASRAF_DOVIZ_ID.FieldName = "ODEME_MASRAF_DOVIZ_ID";
            colODEME_MASRAF_DOVIZ_ID.Name = "colODEME_MASRAF_DOVIZ_ID";
            colODEME_MASRAF_DOVIZ_ID.Visible = true;

            GridColumn colODEME_VEKALET_UCRETI = new GridColumn();
            colODEME_VEKALET_UCRETI.VisibleIndex = 101;
            colODEME_VEKALET_UCRETI.FieldName = "ODEME_VEKALET_UCRETI";
            colODEME_VEKALET_UCRETI.Name = "colODEME_VEKALET_UCRETI";
            colODEME_VEKALET_UCRETI.Visible = true;

            GridColumn colODEME_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colODEME_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 102;
            colODEME_VEKALET_UCRETI_DOVIZ_ID.FieldName = "ODEME_VEKALET_UCRETI_DOVIZ_ID";
            colODEME_VEKALET_UCRETI_DOVIZ_ID.Name = "colODEME_VEKALET_UCRETI_DOVIZ_ID";
            colODEME_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_ANAPARA = new GridColumn();
            colTUTAR_ANAPARA.VisibleIndex = 103;
            colTUTAR_ANAPARA.FieldName = "TUTAR_ANAPARA";
            colTUTAR_ANAPARA.Name = "colTUTAR_ANAPARA";
            colTUTAR_ANAPARA.Visible = true;

            GridColumn colTUTAR_ANAPARA_DOVIZ_ID = new GridColumn();
            colTUTAR_ANAPARA_DOVIZ_ID.VisibleIndex = 104;
            colTUTAR_ANAPARA_DOVIZ_ID.FieldName = "TUTAR_ANAPARA_DOVIZ_ID";
            colTUTAR_ANAPARA_DOVIZ_ID.Name = "colTUTAR_ANAPARA_DOVIZ_ID";
            colTUTAR_ANAPARA_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_BANKA_BAKIYESI = new GridColumn();
            colTUTAR_BANKA_BAKIYESI.VisibleIndex = 105;
            colTUTAR_BANKA_BAKIYESI.FieldName = "TUTAR_BANKA_BAKIYESI";
            colTUTAR_BANKA_BAKIYESI.Name = "colTUTAR_BANKA_BAKIYESI";
            colTUTAR_BANKA_BAKIYESI.Visible = true;

            GridColumn colTUTAR_BANKA_BAKIYESI_DOVIZ_ID = new GridColumn();
            colTUTAR_BANKA_BAKIYESI_DOVIZ_ID.VisibleIndex = 106;
            colTUTAR_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "TUTAR_BANKA_BAKIYESI_DOVIZ_ID";
            colTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Name = "colTUTAR_BANKA_BAKIYESI_DOVIZ_ID";
            colTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_FAIZ = new GridColumn();
            colTUTAR_FAIZ.VisibleIndex = 107;
            colTUTAR_FAIZ.FieldName = "TUTAR_FAIZ";
            colTUTAR_FAIZ.Name = "colTUTAR_FAIZ";
            colTUTAR_FAIZ.Visible = true;

            GridColumn colTUTAR_FAIZ_DOVIZ_ID = new GridColumn();
            colTUTAR_FAIZ_DOVIZ_ID.VisibleIndex = 108;
            colTUTAR_FAIZ_DOVIZ_ID.FieldName = "TUTAR_FAIZ_DOVIZ_ID";
            colTUTAR_FAIZ_DOVIZ_ID.Name = "colTUTAR_FAIZ_DOVIZ_ID";
            colTUTAR_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_GIDER_VERGISI = new GridColumn();
            colTUTAR_GIDER_VERGISI.VisibleIndex = 109;
            colTUTAR_GIDER_VERGISI.FieldName = "TUTAR_GIDER_VERGISI";
            colTUTAR_GIDER_VERGISI.Name = "colTUTAR_GIDER_VERGISI";
            colTUTAR_GIDER_VERGISI.Visible = true;

            GridColumn colTUTAR_GIDER_VERGISI_DOVIZ_ID = new GridColumn();
            colTUTAR_GIDER_VERGISI_DOVIZ_ID.VisibleIndex = 110;
            colTUTAR_GIDER_VERGISI_DOVIZ_ID.FieldName = "TUTAR_GIDER_VERGISI_DOVIZ_ID";
            colTUTAR_GIDER_VERGISI_DOVIZ_ID.Name = "colTUTAR_GIDER_VERGISI_DOVIZ_ID";
            colTUTAR_GIDER_VERGISI_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_KALAN = new GridColumn();
            colTUTAR_KALAN.VisibleIndex = 111;
            colTUTAR_KALAN.FieldName = "TUTAR_KALAN";
            colTUTAR_KALAN.Name = "colTUTAR_KALAN";
            colTUTAR_KALAN.Visible = true;

            GridColumn colTUTAR_KALAN_DOVIZ_ID = new GridColumn();
            colTUTAR_KALAN_DOVIZ_ID.VisibleIndex = 112;
            colTUTAR_KALAN_DOVIZ_ID.FieldName = "TUTAR_KALAN_DOVIZ_ID";
            colTUTAR_KALAN_DOVIZ_ID.Name = "colTUTAR_KALAN_DOVIZ_ID";
            colTUTAR_KALAN_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_KOM_TAZ = new GridColumn();
            colTUTAR_KOM_TAZ.VisibleIndex = 113;
            colTUTAR_KOM_TAZ.FieldName = "TUTAR_KOM_TAZ";
            colTUTAR_KOM_TAZ.Name = "colTUTAR_KOM_TAZ";
            colTUTAR_KOM_TAZ.Visible = true;

            GridColumn colTUTAR_KOM_TAZ_DOVIZ_ID = new GridColumn();
            colTUTAR_KOM_TAZ_DOVIZ_ID.VisibleIndex = 114;
            colTUTAR_KOM_TAZ_DOVIZ_ID.FieldName = "TUTAR_KOM_TAZ_DOVIZ_ID";
            colTUTAR_KOM_TAZ_DOVIZ_ID.Name = "colTUTAR_KOM_TAZ_DOVIZ_ID";
            colTUTAR_KOM_TAZ_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_MASRAF = new GridColumn();
            colTUTAR_MASRAF.VisibleIndex = 115;
            colTUTAR_MASRAF.FieldName = "TUTAR_MASRAF";
            colTUTAR_MASRAF.Name = "colTUTAR_MASRAF";
            colTUTAR_MASRAF.Visible = true;

            GridColumn colTUTAR_MASRAF_DOVIZ_ID = new GridColumn();
            colTUTAR_MASRAF_DOVIZ_ID.VisibleIndex = 116;
            colTUTAR_MASRAF_DOVIZ_ID.FieldName = "TUTAR_MASRAF_DOVIZ_ID";
            colTUTAR_MASRAF_DOVIZ_ID.Name = "colTUTAR_MASRAF_DOVIZ_ID";
            colTUTAR_MASRAF_DOVIZ_ID.Visible = true;

            GridColumn colTUTAR_VEKALET_UCRETI = new GridColumn();
            colTUTAR_VEKALET_UCRETI.VisibleIndex = 117;
            colTUTAR_VEKALET_UCRETI.FieldName = "TUTAR_VEKALET_UCRETI";
            colTUTAR_VEKALET_UCRETI.Name = "colTUTAR_VEKALET_UCRETI";
            colTUTAR_VEKALET_UCRETI.Visible = true;

            GridColumn colTUTAR_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colTUTAR_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 118;
            colTUTAR_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TUTAR_VEKALET_UCRETI_DOVIZ_ID";
            colTUTAR_VEKALET_UCRETI_DOVIZ_ID.Name = "colTUTAR_VEKALET_UCRETI_DOVIZ_ID";
            colTUTAR_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colPROJE_SON_HESAP_TARIHI = new GridColumn();
            colPROJE_SON_HESAP_TARIHI.VisibleIndex = 119;
            colPROJE_SON_HESAP_TARIHI.FieldName = "PROJE_SON_HESAP_TARIHI";
            colPROJE_SON_HESAP_TARIHI.Name = "colPROJE_SON_HESAP_TARIHI";
            colPROJE_SON_HESAP_TARIHI.Visible = true;

            GridColumn colHESAPLAMA_TIPI = new GridColumn();
            colHESAPLAMA_TIPI.VisibleIndex = 120;
            colHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Name = "colHESAPLAMA_TIPI";
            colHESAPLAMA_TIPI.Visible = true;

            GridColumn colRISK_TOPLAMI = new GridColumn();
            colRISK_TOPLAMI.VisibleIndex = 121;
            colRISK_TOPLAMI.FieldName = "RISK_TOPLAMI";
            colRISK_TOPLAMI.Name = "colRISK_TOPLAMI";
            colRISK_TOPLAMI.Visible = true;

            GridColumn colRISK_TOPLAMI_DOVIZ_ID = new GridColumn();
            colRISK_TOPLAMI_DOVIZ_ID.VisibleIndex = 122;
            colRISK_TOPLAMI_DOVIZ_ID.FieldName = "RISK_TOPLAMI_DOVIZ_ID";
            colRISK_TOPLAMI_DOVIZ_ID.Name = "colRISK_TOPLAMI_DOVIZ_ID";
            colRISK_TOPLAMI_DOVIZ_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			//colID,
			colTAKIP_EDEN,

			//colICRA_FOY_ID,
			colTAKIP_EDEN_SIFAT,
			colTAKIP_EDILEN,
			colTAKIP_EDILEN_SIFAT,
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
			colFOY_NO,
			colICRA_DURUM,
			colTAKIP_TARIHI,
			colADLI_BIRIM_ADLIYE,
			colADLI_BIRIM_GOREV,
			colADLI_BIRIM_NO,
			colESAS_NO,
			colICRA_OZEL_KOD1,
			colICRA_OZEL_KOD2,
			colICRA_OZEL_KOD3,
			colICRA_OZEL_KOD4,
			colTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			colASIL_ALACAK,
			colASIL_ALACAK_DOVIZ_ID,
			colISLEMIS_FAIZ,
			colISLEMIS_FAIZ_DOVIZ_ID,
			colSON_HESAP_TARIHI,
			colTAKIP_CIKISI,
			colTAKIP_CIKISI_DOVIZ_ID,
			colSONRAKI_FAIZ,
			colSONRAKI_FAIZ_DOVIZ_ID,
			colODEME_TOPLAMI,
			colODEME_TOPLAMI_DOVIZ_ID,
			colKALAN,
			colKALAN_DOVIZ_ID,
			colKAPAMA_TARIHI,
			colRISK_MIKTARI,
			colRISK_MIKTARI_DOVIZ_ID,
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
			colPROJE_SON_HESAP_TARIHI,
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

            PivotGridField fieldTAKIP_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN.AreaIndex = 1;
            fieldTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            fieldTAKIP_EDEN.Name = "fieldTAKIP_EDEN";
            fieldTAKIP_EDEN.Visible = false;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_FOY_ID.AreaIndex = 2;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.Visible = false;

            PivotGridField fieldTAKIP_EDEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN_SIFAT.AreaIndex = 3;
            fieldTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            fieldTAKIP_EDEN_SIFAT.Name = "fieldTAKIP_EDEN_SIFAT";
            fieldTAKIP_EDEN_SIFAT.Visible = false;

            PivotGridField fieldTAKIP_EDILEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN.AreaIndex = 4;
            fieldTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            fieldTAKIP_EDILEN.Name = "fieldTAKIP_EDILEN";
            fieldTAKIP_EDILEN.Visible = false;

            PivotGridField fieldTAKIP_EDILEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN_SIFAT.AreaIndex = 5;
            fieldTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            fieldTAKIP_EDILEN_SIFAT.Name = "fieldTAKIP_EDILEN_SIFAT";
            fieldTAKIP_EDILEN_SIFAT.Visible = false;

            PivotGridField fieldKOD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKOD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKOD.AreaIndex = 6;
            fieldKOD.FieldName = "KOD";
            fieldKOD.Name = "fieldKOD";
            fieldKOD.Visible = false;

            PivotGridField fieldADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADI.AreaIndex = 7;
            fieldADI.FieldName = "ADI";
            fieldADI.Name = "fieldADI";
            fieldADI.Visible = false;

            PivotGridField fieldBASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASLANGIC_TARIHI.AreaIndex = 8;
            fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Visible = false;

            PivotGridField fieldBITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_TARIHI.AreaIndex = 9;
            fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
            fieldBITIS_TARIHI.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 10;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldOZEL_KOD2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD2.AreaIndex = 11;
            fieldOZEL_KOD2.FieldName = "OZEL_KOD2";
            fieldOZEL_KOD2.Name = "fieldOZEL_KOD2";
            fieldOZEL_KOD2.Visible = false;

            PivotGridField fieldOZEL_KOD1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD1.AreaIndex = 12;
            fieldOZEL_KOD1.FieldName = "OZEL_KOD1";
            fieldOZEL_KOD1.Name = "fieldOZEL_KOD1";
            fieldOZEL_KOD1.Visible = false;

            PivotGridField fieldOZEL_KOD4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD4.AreaIndex = 13;
            fieldOZEL_KOD4.FieldName = "OZEL_KOD4";
            fieldOZEL_KOD4.Name = "fieldOZEL_KOD4";
            fieldOZEL_KOD4.Visible = false;

            PivotGridField fieldOZEL_KOD3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD3.AreaIndex = 14;
            fieldOZEL_KOD3.FieldName = "OZEL_KOD3";
            fieldOZEL_KOD3.Name = "fieldOZEL_KOD3";
            fieldOZEL_KOD3.Visible = false;

            PivotGridField fieldREFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO1.AreaIndex = 15;
            fieldREFERANS_NO1.FieldName = "REFERANS_NO1";
            fieldREFERANS_NO1.Name = "fieldREFERANS_NO1";
            fieldREFERANS_NO1.Visible = false;

            PivotGridField fieldREFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO2.AreaIndex = 16;
            fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
            fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";
            fieldREFERANS_NO2.Visible = false;

            PivotGridField fieldREFERANS_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO3.AreaIndex = 17;
            fieldREFERANS_NO3.FieldName = "REFERANS_NO3";
            fieldREFERANS_NO3.Name = "fieldREFERANS_NO3";
            fieldREFERANS_NO3.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 18;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 19;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

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

            PivotGridField fieldKARAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARAR.AreaIndex = 22;
            fieldKARAR.FieldName = "KARAR";
            fieldKARAR.Name = "fieldKARAR";
            fieldKARAR.Visible = false;

            PivotGridField fieldTEKLIF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEKLIF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEKLIF.AreaIndex = 23;
            fieldTEKLIF.FieldName = "TEKLIF";
            fieldTEKLIF.Name = "fieldTEKLIF";
            fieldTEKLIF.Visible = false;

            PivotGridField fieldPROJE_TARAFI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_TARAFI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_TARAFI.AreaIndex = 24;
            fieldPROJE_TARAFI.FieldName = "PROJE_TARAFI";
            fieldPROJE_TARAFI.Name = "fieldPROJE_TARAFI";
            fieldPROJE_TARAFI.Visible = false;

            PivotGridField fieldPROJE_SORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_SORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_SORUMLU.AreaIndex = 25;
            fieldPROJE_SORUMLU.FieldName = "PROJE_SORUMLU";
            fieldPROJE_SORUMLU.Name = "fieldPROJE_SORUMLU";
            fieldPROJE_SORUMLU.Visible = false;

            PivotGridField fieldPROJE_YETKILI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_YETKILI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_YETKILI.AreaIndex = 26;
            fieldPROJE_YETKILI.FieldName = "PROJE_YETKILI";
            fieldPROJE_YETKILI.Name = "fieldPROJE_YETKILI";
            fieldPROJE_YETKILI.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 27;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldICRA_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_DURUM.AreaIndex = 28;
            fieldICRA_DURUM.FieldName = "ICRA_DURUM";
            fieldICRA_DURUM.Name = "fieldICRA_DURUM";
            fieldICRA_DURUM.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 29;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldADLI_BIRIM_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_ADLIYE.AreaIndex = 30;
            fieldADLI_BIRIM_ADLIYE.FieldName = "ADLI_BIRIM_ADLIYE";
            fieldADLI_BIRIM_ADLIYE.Name = "fieldADLI_BIRIM_ADLIYE";
            fieldADLI_BIRIM_ADLIYE.Visible = false;

            PivotGridField fieldADLI_BIRIM_GOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_GOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_GOREV.AreaIndex = 31;
            fieldADLI_BIRIM_GOREV.FieldName = "ADLI_BIRIM_GOREV";
            fieldADLI_BIRIM_GOREV.Name = "fieldADLI_BIRIM_GOREV";
            fieldADLI_BIRIM_GOREV.Visible = false;

            PivotGridField fieldADLI_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_NO.AreaIndex = 32;
            fieldADLI_BIRIM_NO.FieldName = "ADLI_BIRIM_NO";
            fieldADLI_BIRIM_NO.Name = "fieldADLI_BIRIM_NO";
            fieldADLI_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 33;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_OZEL_KOD1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_OZEL_KOD1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_OZEL_KOD1.AreaIndex = 34;
            fieldICRA_OZEL_KOD1.FieldName = "ICRA_OZEL_KOD1";
            fieldICRA_OZEL_KOD1.Name = "fieldICRA_OZEL_KOD1";
            fieldICRA_OZEL_KOD1.Visible = false;

            PivotGridField fieldICRA_OZEL_KOD2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_OZEL_KOD2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_OZEL_KOD2.AreaIndex = 35;
            fieldICRA_OZEL_KOD2.FieldName = "ICRA_OZEL_KOD2";
            fieldICRA_OZEL_KOD2.Name = "fieldICRA_OZEL_KOD2";
            fieldICRA_OZEL_KOD2.Visible = false;

            PivotGridField fieldICRA_OZEL_KOD3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_OZEL_KOD3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_OZEL_KOD3.AreaIndex = 36;
            fieldICRA_OZEL_KOD3.FieldName = "ICRA_OZEL_KOD3";
            fieldICRA_OZEL_KOD3.Name = "fieldICRA_OZEL_KOD3";
            fieldICRA_OZEL_KOD3.Visible = false;

            PivotGridField fieldICRA_OZEL_KOD4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_OZEL_KOD4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_OZEL_KOD4.AreaIndex = 37;
            fieldICRA_OZEL_KOD4.FieldName = "ICRA_OZEL_KOD4";
            fieldICRA_OZEL_KOD4.Name = "fieldICRA_OZEL_KOD4";
            fieldICRA_OZEL_KOD4.Visible = false;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 38;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 39;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 40;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldISLEMIS_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEMIS_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEMIS_FAIZ.AreaIndex = 41;
            fieldISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            fieldISLEMIS_FAIZ.Name = "fieldISLEMIS_FAIZ";
            fieldISLEMIS_FAIZ.Visible = false;

            PivotGridField fieldISLEMIS_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEMIS_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEMIS_FAIZ_DOVIZ_ID.AreaIndex = 42;
            fieldISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            fieldISLEMIS_FAIZ_DOVIZ_ID.Name = "fieldISLEMIS_FAIZ_DOVIZ_ID";
            fieldISLEMIS_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldSON_HESAP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSON_HESAP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSON_HESAP_TARIHI.AreaIndex = 43;
            fieldSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Name = "fieldSON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI.AreaIndex = 44;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 45;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSONRAKI_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_FAIZ.AreaIndex = 46;
            fieldSONRAKI_FAIZ.FieldName = "SONRAKI_FAIZ";
            fieldSONRAKI_FAIZ.Name = "fieldSONRAKI_FAIZ";
            fieldSONRAKI_FAIZ.Visible = false;

            PivotGridField fieldSONRAKI_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_FAIZ_DOVIZ_ID.AreaIndex = 47;
            fieldSONRAKI_FAIZ_DOVIZ_ID.FieldName = "SONRAKI_FAIZ_DOVIZ_ID";
            fieldSONRAKI_FAIZ_DOVIZ_ID.Name = "fieldSONRAKI_FAIZ_DOVIZ_ID";
            fieldSONRAKI_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI.AreaIndex = 48;
            fieldODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Name = "fieldODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Visible = false;

            PivotGridField fieldODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 49;
            fieldODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Name = "fieldODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 50;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 51;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 52;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 53;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 54;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_ANAPARA.AreaIndex = 55;
            fieldINDIRIM_ANAPARA.FieldName = "INDIRIM_ANAPARA";
            fieldINDIRIM_ANAPARA.Name = "fieldINDIRIM_ANAPARA";
            fieldINDIRIM_ANAPARA.Visible = false;

            PivotGridField fieldINDIRIM_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_ANAPARA_DOVIZ_ID.AreaIndex = 56;
            fieldINDIRIM_ANAPARA_DOVIZ_ID.FieldName = "INDIRIM_ANAPARA_DOVIZ_ID";
            fieldINDIRIM_ANAPARA_DOVIZ_ID.Name = "fieldINDIRIM_ANAPARA_DOVIZ_ID";
            fieldINDIRIM_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_BANKA_BAKIYESI.AreaIndex = 57;
            fieldINDIRIM_BANKA_BAKIYESI.FieldName = "INDIRIM_BANKA_BAKIYESI";
            fieldINDIRIM_BANKA_BAKIYESI.Name = "fieldINDIRIM_BANKA_BAKIYESI";
            fieldINDIRIM_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 58;
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "INDIRIM_BANKA_BAKIYESI_DOVIZ_ID";
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID";
            fieldINDIRIM_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_FAIZ.AreaIndex = 59;
            fieldINDIRIM_FAIZ.FieldName = "INDIRIM_FAIZ";
            fieldINDIRIM_FAIZ.Name = "fieldINDIRIM_FAIZ";
            fieldINDIRIM_FAIZ.Visible = false;

            PivotGridField fieldINDIRIM_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_FAIZ_DOVIZ_ID.AreaIndex = 60;
            fieldINDIRIM_FAIZ_DOVIZ_ID.FieldName = "INDIRIM_FAIZ_DOVIZ_ID";
            fieldINDIRIM_FAIZ_DOVIZ_ID.Name = "fieldINDIRIM_FAIZ_DOVIZ_ID";
            fieldINDIRIM_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_GIDER_VERGISI.AreaIndex = 61;
            fieldINDIRIM_GIDER_VERGISI.FieldName = "INDIRIM_GIDER_VERGISI";
            fieldINDIRIM_GIDER_VERGISI.Name = "fieldINDIRIM_GIDER_VERGISI";
            fieldINDIRIM_GIDER_VERGISI.Visible = false;

            PivotGridField fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 62;
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.FieldName = "INDIRIM_GIDER_VERGISI_DOVIZ_ID";
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.Name = "fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID";
            fieldINDIRIM_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KALAN.AreaIndex = 63;
            fieldINDIRIM_KALAN.FieldName = "INDIRIM_KALAN";
            fieldINDIRIM_KALAN.Name = "fieldINDIRIM_KALAN";
            fieldINDIRIM_KALAN.Visible = false;

            PivotGridField fieldINDIRIM_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KALAN_DOVIZ_ID.AreaIndex = 64;
            fieldINDIRIM_KALAN_DOVIZ_ID.FieldName = "INDIRIM_KALAN_DOVIZ_ID";
            fieldINDIRIM_KALAN_DOVIZ_ID.Name = "fieldINDIRIM_KALAN_DOVIZ_ID";
            fieldINDIRIM_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KOM_TAZ.AreaIndex = 65;
            fieldINDIRIM_KOM_TAZ.FieldName = "INDIRIM_KOM_TAZ";
            fieldINDIRIM_KOM_TAZ.Name = "fieldINDIRIM_KOM_TAZ";
            fieldINDIRIM_KOM_TAZ.Visible = false;

            PivotGridField fieldINDIRIM_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_MASRAF.AreaIndex = 66;
            fieldINDIRIM_MASRAF.FieldName = "INDIRIM_MASRAF";
            fieldINDIRIM_MASRAF.Name = "fieldINDIRIM_MASRAF";
            fieldINDIRIM_MASRAF.Visible = false;

            PivotGridField fieldINDIRIM_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.AreaIndex = 67;
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.FieldName = "INDIRIM_KOM_TAZ_DOVIZ_ID";
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.Name = "fieldINDIRIM_KOM_TAZ_DOVIZ_ID";
            fieldINDIRIM_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_MASRAF_DOVIZ_ID.AreaIndex = 68;
            fieldINDIRIM_MASRAF_DOVIZ_ID.FieldName = "INDIRIM_MASRAF_DOVIZ_ID";
            fieldINDIRIM_MASRAF_DOVIZ_ID.Name = "fieldINDIRIM_MASRAF_DOVIZ_ID";
            fieldINDIRIM_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldINDIRIM_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_VEKALET_UCRETI.AreaIndex = 69;
            fieldINDIRIM_VEKALET_UCRETI.FieldName = "INDIRIM_VEKALET_UCRETI";
            fieldINDIRIM_VEKALET_UCRETI.Name = "fieldINDIRIM_VEKALET_UCRETI";
            fieldINDIRIM_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 70;
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.FieldName = "INDIRIM_VEKALET_UCRETI_DOVIZ_ID";
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID";
            fieldINDIRIM_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_ANAPARA.AreaIndex = 71;
            fieldKALAN_ANAPARA.FieldName = "KALAN_ANAPARA";
            fieldKALAN_ANAPARA.Name = "fieldKALAN_ANAPARA";
            fieldKALAN_ANAPARA.Visible = false;

            PivotGridField fieldKALAN_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_ANAPARA_DOVIZ_ID.AreaIndex = 72;
            fieldKALAN_ANAPARA_DOVIZ_ID.FieldName = "KALAN_ANAPARA_DOVIZ_ID";
            fieldKALAN_ANAPARA_DOVIZ_ID.Name = "fieldKALAN_ANAPARA_DOVIZ_ID";
            fieldKALAN_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_BANKA_BAKIYESI.AreaIndex = 73;
            fieldKALAN_BANKA_BAKIYESI.FieldName = "KALAN_BANKA_BAKIYESI";
            fieldKALAN_BANKA_BAKIYESI.Name = "fieldKALAN_BANKA_BAKIYESI";
            fieldKALAN_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 74;
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "KALAN_BANKA_BAKIYESI_DOVIZ_ID";
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID";
            fieldKALAN_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_FAIZ.AreaIndex = 75;
            fieldKALAN_FAIZ.FieldName = "KALAN_FAIZ";
            fieldKALAN_FAIZ.Name = "fieldKALAN_FAIZ";
            fieldKALAN_FAIZ.Visible = false;

            PivotGridField fieldKALAN_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_FAIZ_DOVIZ_ID.AreaIndex = 76;
            fieldKALAN_FAIZ_DOVIZ_ID.FieldName = "KALAN_FAIZ_DOVIZ_ID";
            fieldKALAN_FAIZ_DOVIZ_ID.Name = "fieldKALAN_FAIZ_DOVIZ_ID";
            fieldKALAN_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_GIDER_VERGISI.AreaIndex = 77;
            fieldKALAN_GIDER_VERGISI.FieldName = "KALAN_GIDER_VERGISI";
            fieldKALAN_GIDER_VERGISI.Name = "fieldKALAN_GIDER_VERGISI";
            fieldKALAN_GIDER_VERGISI.Visible = false;

            PivotGridField fieldKALAN_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 78;
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.FieldName = "KALAN_GIDER_VERGISI_DOVIZ_ID";
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.Name = "fieldKALAN_GIDER_VERGISI_DOVIZ_ID";
            fieldKALAN_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KALAN.AreaIndex = 79;
            fieldKALAN_KALAN.FieldName = "KALAN_KALAN";
            fieldKALAN_KALAN.Name = "fieldKALAN_KALAN";
            fieldKALAN_KALAN.Visible = false;

            PivotGridField fieldKALAN_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KALAN_DOVIZ_ID.AreaIndex = 80;
            fieldKALAN_KALAN_DOVIZ_ID.FieldName = "KALAN_KALAN_DOVIZ_ID";
            fieldKALAN_KALAN_DOVIZ_ID.Name = "fieldKALAN_KALAN_DOVIZ_ID";
            fieldKALAN_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KOM_TAZ.AreaIndex = 81;
            fieldKALAN_KOM_TAZ.FieldName = "KALAN_KOM_TAZ";
            fieldKALAN_KOM_TAZ.Name = "fieldKALAN_KOM_TAZ";
            fieldKALAN_KOM_TAZ.Visible = false;

            PivotGridField fieldKALAN_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_KOM_TAZ_DOVIZ_ID.AreaIndex = 82;
            fieldKALAN_KOM_TAZ_DOVIZ_ID.FieldName = "KALAN_KOM_TAZ_DOVIZ_ID";
            fieldKALAN_KOM_TAZ_DOVIZ_ID.Name = "fieldKALAN_KOM_TAZ_DOVIZ_ID";
            fieldKALAN_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_MASRAF.AreaIndex = 83;
            fieldKALAN_MASRAF.FieldName = "KALAN_MASRAF";
            fieldKALAN_MASRAF.Name = "fieldKALAN_MASRAF";
            fieldKALAN_MASRAF.Visible = false;

            PivotGridField fieldKALAN_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_MASRAF_DOVIZ_ID.AreaIndex = 84;
            fieldKALAN_MASRAF_DOVIZ_ID.FieldName = "KALAN_MASRAF_DOVIZ_ID";
            fieldKALAN_MASRAF_DOVIZ_ID.Name = "fieldKALAN_MASRAF_DOVIZ_ID";
            fieldKALAN_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_VEKALET_UCRETI.AreaIndex = 85;
            fieldKALAN_VEKALET_UCRETI.FieldName = "KALAN_VEKALET_UCRETI";
            fieldKALAN_VEKALET_UCRETI.Name = "fieldKALAN_VEKALET_UCRETI";
            fieldKALAN_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldKALAN_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 86;
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.FieldName = "KALAN_VEKALET_UCRETI_DOVIZ_ID";
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldKALAN_VEKALET_UCRETI_DOVIZ_ID";
            fieldKALAN_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_ANAPARA.AreaIndex = 87;
            fieldODEME_ANAPARA.FieldName = "ODEME_ANAPARA";
            fieldODEME_ANAPARA.Name = "fieldODEME_ANAPARA";
            fieldODEME_ANAPARA.Visible = false;

            PivotGridField fieldODEME_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_ANAPARA_DOVIZ_ID.AreaIndex = 88;
            fieldODEME_ANAPARA_DOVIZ_ID.FieldName = "ODEME_ANAPARA_DOVIZ_ID";
            fieldODEME_ANAPARA_DOVIZ_ID.Name = "fieldODEME_ANAPARA_DOVIZ_ID";
            fieldODEME_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_BANKA_BAKIYESI.AreaIndex = 89;
            fieldODEME_BANKA_BAKIYESI.FieldName = "ODEME_BANKA_BAKIYESI";
            fieldODEME_BANKA_BAKIYESI.Name = "fieldODEME_BANKA_BAKIYESI";
            fieldODEME_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldODEME_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 90;
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "ODEME_BANKA_BAKIYESI_DOVIZ_ID";
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldODEME_BANKA_BAKIYESI_DOVIZ_ID";
            fieldODEME_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_FAIZ.AreaIndex = 91;
            fieldODEME_FAIZ.FieldName = "ODEME_FAIZ";
            fieldODEME_FAIZ.Name = "fieldODEME_FAIZ";
            fieldODEME_FAIZ.Visible = false;

            PivotGridField fieldODEME_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_FAIZ_DOVIZ_ID.AreaIndex = 92;
            fieldODEME_FAIZ_DOVIZ_ID.FieldName = "ODEME_FAIZ_DOVIZ_ID";
            fieldODEME_FAIZ_DOVIZ_ID.Name = "fieldODEME_FAIZ_DOVIZ_ID";
            fieldODEME_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_GIDER_VERGISI.AreaIndex = 93;
            fieldODEME_GIDER_VERGISI.FieldName = "ODEME_GIDER_VERGISI";
            fieldODEME_GIDER_VERGISI.Name = "fieldODEME_GIDER_VERGISI";
            fieldODEME_GIDER_VERGISI.Visible = false;

            PivotGridField fieldODEME_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 94;
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.FieldName = "ODEME_GIDER_VERGISI_DOVIZ_ID";
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.Name = "fieldODEME_GIDER_VERGISI_DOVIZ_ID";
            fieldODEME_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KALAN.AreaIndex = 95;
            fieldODEME_KALAN.FieldName = "ODEME_KALAN";
            fieldODEME_KALAN.Name = "fieldODEME_KALAN";
            fieldODEME_KALAN.Visible = false;

            PivotGridField fieldODEME_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KALAN_DOVIZ_ID.AreaIndex = 96;
            fieldODEME_KALAN_DOVIZ_ID.FieldName = "ODEME_KALAN_DOVIZ_ID";
            fieldODEME_KALAN_DOVIZ_ID.Name = "fieldODEME_KALAN_DOVIZ_ID";
            fieldODEME_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KOM_TAZ.AreaIndex = 97;
            fieldODEME_KOM_TAZ.FieldName = "ODEME_KOM_TAZ";
            fieldODEME_KOM_TAZ.Name = "fieldODEME_KOM_TAZ";
            fieldODEME_KOM_TAZ.Visible = false;

            PivotGridField fieldODEME_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_KOM_TAZ_DOVIZ_ID.AreaIndex = 98;
            fieldODEME_KOM_TAZ_DOVIZ_ID.FieldName = "ODEME_KOM_TAZ_DOVIZ_ID";
            fieldODEME_KOM_TAZ_DOVIZ_ID.Name = "fieldODEME_KOM_TAZ_DOVIZ_ID";
            fieldODEME_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MASRAF.AreaIndex = 99;
            fieldODEME_MASRAF.FieldName = "ODEME_MASRAF";
            fieldODEME_MASRAF.Name = "fieldODEME_MASRAF";
            fieldODEME_MASRAF.Visible = false;

            PivotGridField fieldODEME_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_MASRAF_DOVIZ_ID.AreaIndex = 100;
            fieldODEME_MASRAF_DOVIZ_ID.FieldName = "ODEME_MASRAF_DOVIZ_ID";
            fieldODEME_MASRAF_DOVIZ_ID.Name = "fieldODEME_MASRAF_DOVIZ_ID";
            fieldODEME_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_VEKALET_UCRETI.AreaIndex = 101;
            fieldODEME_VEKALET_UCRETI.FieldName = "ODEME_VEKALET_UCRETI";
            fieldODEME_VEKALET_UCRETI.Name = "fieldODEME_VEKALET_UCRETI";
            fieldODEME_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldODEME_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 102;
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.FieldName = "ODEME_VEKALET_UCRETI_DOVIZ_ID";
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldODEME_VEKALET_UCRETI_DOVIZ_ID";
            fieldODEME_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_ANAPARA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_ANAPARA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_ANAPARA.AreaIndex = 103;
            fieldTUTAR_ANAPARA.FieldName = "TUTAR_ANAPARA";
            fieldTUTAR_ANAPARA.Name = "fieldTUTAR_ANAPARA";
            fieldTUTAR_ANAPARA.Visible = false;

            PivotGridField fieldTUTAR_ANAPARA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_ANAPARA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_ANAPARA_DOVIZ_ID.AreaIndex = 104;
            fieldTUTAR_ANAPARA_DOVIZ_ID.FieldName = "TUTAR_ANAPARA_DOVIZ_ID";
            fieldTUTAR_ANAPARA_DOVIZ_ID.Name = "fieldTUTAR_ANAPARA_DOVIZ_ID";
            fieldTUTAR_ANAPARA_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_BANKA_BAKIYESI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_BANKA_BAKIYESI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_BANKA_BAKIYESI.AreaIndex = 105;
            fieldTUTAR_BANKA_BAKIYESI.FieldName = "TUTAR_BANKA_BAKIYESI";
            fieldTUTAR_BANKA_BAKIYESI.Name = "fieldTUTAR_BANKA_BAKIYESI";
            fieldTUTAR_BANKA_BAKIYESI.Visible = false;

            PivotGridField fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.AreaIndex = 106;
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.FieldName = "TUTAR_BANKA_BAKIYESI_DOVIZ_ID";
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Name = "fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID";
            fieldTUTAR_BANKA_BAKIYESI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_FAIZ.AreaIndex = 107;
            fieldTUTAR_FAIZ.FieldName = "TUTAR_FAIZ";
            fieldTUTAR_FAIZ.Name = "fieldTUTAR_FAIZ";
            fieldTUTAR_FAIZ.Visible = false;

            PivotGridField fieldTUTAR_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_FAIZ_DOVIZ_ID.AreaIndex = 108;
            fieldTUTAR_FAIZ_DOVIZ_ID.FieldName = "TUTAR_FAIZ_DOVIZ_ID";
            fieldTUTAR_FAIZ_DOVIZ_ID.Name = "fieldTUTAR_FAIZ_DOVIZ_ID";
            fieldTUTAR_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_GIDER_VERGISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_GIDER_VERGISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_GIDER_VERGISI.AreaIndex = 109;
            fieldTUTAR_GIDER_VERGISI.FieldName = "TUTAR_GIDER_VERGISI";
            fieldTUTAR_GIDER_VERGISI.Name = "fieldTUTAR_GIDER_VERGISI";
            fieldTUTAR_GIDER_VERGISI.Visible = false;

            PivotGridField fieldTUTAR_GIDER_VERGISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.AreaIndex = 110;
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.FieldName = "TUTAR_GIDER_VERGISI_DOVIZ_ID";
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.Name = "fieldTUTAR_GIDER_VERGISI_DOVIZ_ID";
            fieldTUTAR_GIDER_VERGISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_KALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KALAN.AreaIndex = 111;
            fieldTUTAR_KALAN.FieldName = "TUTAR_KALAN";
            fieldTUTAR_KALAN.Name = "fieldTUTAR_KALAN";
            fieldTUTAR_KALAN.Visible = false;

            PivotGridField fieldTUTAR_KALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KALAN_DOVIZ_ID.AreaIndex = 112;
            fieldTUTAR_KALAN_DOVIZ_ID.FieldName = "TUTAR_KALAN_DOVIZ_ID";
            fieldTUTAR_KALAN_DOVIZ_ID.Name = "fieldTUTAR_KALAN_DOVIZ_ID";
            fieldTUTAR_KALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_KOM_TAZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KOM_TAZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KOM_TAZ.AreaIndex = 113;
            fieldTUTAR_KOM_TAZ.FieldName = "TUTAR_KOM_TAZ";
            fieldTUTAR_KOM_TAZ.Name = "fieldTUTAR_KOM_TAZ";
            fieldTUTAR_KOM_TAZ.Visible = false;

            PivotGridField fieldTUTAR_KOM_TAZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.AreaIndex = 114;
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.FieldName = "TUTAR_KOM_TAZ_DOVIZ_ID";
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.Name = "fieldTUTAR_KOM_TAZ_DOVIZ_ID";
            fieldTUTAR_KOM_TAZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_MASRAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_MASRAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_MASRAF.AreaIndex = 115;
            fieldTUTAR_MASRAF.FieldName = "TUTAR_MASRAF";
            fieldTUTAR_MASRAF.Name = "fieldTUTAR_MASRAF";
            fieldTUTAR_MASRAF.Visible = false;

            PivotGridField fieldTUTAR_MASRAF_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_MASRAF_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_MASRAF_DOVIZ_ID.AreaIndex = 116;
            fieldTUTAR_MASRAF_DOVIZ_ID.FieldName = "TUTAR_MASRAF_DOVIZ_ID";
            fieldTUTAR_MASRAF_DOVIZ_ID.Name = "fieldTUTAR_MASRAF_DOVIZ_ID";
            fieldTUTAR_MASRAF_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUTAR_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_VEKALET_UCRETI.AreaIndex = 117;
            fieldTUTAR_VEKALET_UCRETI.FieldName = "TUTAR_VEKALET_UCRETI";
            fieldTUTAR_VEKALET_UCRETI.Name = "fieldTUTAR_VEKALET_UCRETI";
            fieldTUTAR_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 118;
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TUTAR_VEKALET_UCRETI_DOVIZ_ID";
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID";
            fieldTUTAR_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldPROJE_SON_HESAP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_SON_HESAP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_SON_HESAP_TARIHI.AreaIndex = 119;
            fieldPROJE_SON_HESAP_TARIHI.FieldName = "PROJE_SON_HESAP_TARIHI";
            fieldPROJE_SON_HESAP_TARIHI.Name = "fieldPROJE_SON_HESAP_TARIHI";
            fieldPROJE_SON_HESAP_TARIHI.Visible = false;

            PivotGridField fieldHESAPLAMA_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHESAPLAMA_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHESAPLAMA_TIPI.AreaIndex = 120;
            fieldHESAPLAMA_TIPI.FieldName = "HESAPLAMA_TIPI";
            fieldHESAPLAMA_TIPI.Name = "fieldHESAPLAMA_TIPI";
            fieldHESAPLAMA_TIPI.Visible = false;

            PivotGridField fieldRISK_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_TOPLAMI.AreaIndex = 121;
            fieldRISK_TOPLAMI.FieldName = "RISK_TOPLAMI";
            fieldRISK_TOPLAMI.Name = "fieldRISK_TOPLAMI";
            fieldRISK_TOPLAMI.Visible = false;

            PivotGridField fieldRISK_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_TOPLAMI_DOVIZ_ID.AreaIndex = 122;
            fieldRISK_TOPLAMI_DOVIZ_ID.FieldName = "RISK_TOPLAMI_DOVIZ_ID";
            fieldRISK_TOPLAMI_DOVIZ_ID.Name = "fieldRISK_TOPLAMI_DOVIZ_ID";
            fieldRISK_TOPLAMI_DOVIZ_ID.Visible = false;

            #endregion Field & Properties

            switch (pencere)
            {
                case "Klasöre Bağlı İcra Takipleri":
                    dizi = KlasoreBagliIcraTakipleri();
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
			fieldTAKIP_EDEN,
			fieldICRA_FOY_ID,
			fieldTAKIP_EDEN_SIFAT,
			fieldTAKIP_EDILEN,
			fieldTAKIP_EDILEN_SIFAT,
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
			fieldFOY_NO,
			fieldICRA_DURUM,
			fieldTAKIP_TARIHI,
			fieldADLI_BIRIM_ADLIYE,
			fieldADLI_BIRIM_GOREV,
			fieldADLI_BIRIM_NO,
			fieldESAS_NO,
			fieldICRA_OZEL_KOD1,
			fieldICRA_OZEL_KOD2,
			fieldICRA_OZEL_KOD3,
			fieldICRA_OZEL_KOD4,
			fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			fieldASIL_ALACAK,
			fieldASIL_ALACAK_DOVIZ_ID,
			fieldISLEMIS_FAIZ,
			fieldISLEMIS_FAIZ_DOVIZ_ID,
			fieldSON_HESAP_TARIHI,
			fieldTAKIP_CIKISI,
			fieldTAKIP_CIKISI_DOVIZ_ID,
			fieldSONRAKI_FAIZ,
			fieldSONRAKI_FAIZ_DOVIZ_ID,
			fieldODEME_TOPLAMI,
			fieldODEME_TOPLAMI_DOVIZ_ID,
			fieldKALAN,
			fieldKALAN_DOVIZ_ID,
			fieldKAPAMA_TARIHI,
			fieldRISK_MIKTARI,
			fieldRISK_MIKTARI_DOVIZ_ID,
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
			fieldPROJE_SON_HESAP_TARIHI,
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

            string RefNo, RefNo2, refNo3, OzelKod1, OzelKod2, OzelKod3, OzelKod4, NRefNo, NRefNo2;
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
                NRefNo = "Dava Neden Ref No1";
            else
                NRefNo = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans1;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans2))
                NRefNo2 = "Dava Neden Ref No2";
            else
                NRefNo2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans2;

            #endregion Özelleştirme

            #region Caption Edit

            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("TAKIP_EDEN", "Takip Eden");
            dicFieldCaption.Add("ICRA_FOY_ID", "Kayıt Sayısı");
            dicFieldCaption.Add("TAKIP_EDEN_SIFAT", "Takip Eden Sıfat");
            dicFieldCaption.Add("TAKIP_EDILEN", "Takip Edilen");
            dicFieldCaption.Add("TAKIP_EDILEN_SIFAT", "Takip Edilen Sıfat");
            dicFieldCaption.Add("KOD", "Kod");
            dicFieldCaption.Add("ADI", "Adı");
            dicFieldCaption.Add("BASLANGIC_TARIHI", "Başlangıç T.");
            dicFieldCaption.Add("BITIS_TARIHI", "Bitiş T.");
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("OZEL_KOD2", OzelKod2);
            dicFieldCaption.Add("OZEL_KOD1", OzelKod1);
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
            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("ICRA_DURUM", "İcra Durum");
            dicFieldCaption.Add("TAKIP_TARIHI", "Takip T.");
            dicFieldCaption.Add("ADLI_BIRIM_ADLIYE", "Adliye");
            dicFieldCaption.Add("ADLI_BIRIM_GOREV", "Görev");
            dicFieldCaption.Add("ADLI_BIRIM_NO", "No");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("ICRA_OZEL_KOD1", OzelKod1);
            dicFieldCaption.Add("ICRA_OZEL_KOD2", OzelKod2);
            dicFieldCaption.Add("ICRA_OZEL_KOD3", OzelKod3);
            dicFieldCaption.Add("ICRA_OZEL_KOD4", OzelKod4);
            dicFieldCaption.Add("TAKIBIN_AVUKATA_INTIKAL_TARIHI", "İntikal T.");
            dicFieldCaption.Add("ASIL_ALACAK", "Asıl Alacak");
            dicFieldCaption.Add("ISLEMIS_FAIZ", "İşlenmiş Faiz");
            dicFieldCaption.Add("SON_HESAP_TARIHI", "Son Hesap T.");
            dicFieldCaption.Add("TAKIP_CIKISI", "Takip Çıkışı");
            dicFieldCaption.Add("SONRAKI_FAIZ", "Sonraki Faiz");
            dicFieldCaption.Add("ODEME_TOPLAMI", "Ödeme Toplamı");
            dicFieldCaption.Add("KALAN", "Kalan");
            dicFieldCaption.Add("KAPAMA_TARIHI", "Kapama T.");
            dicFieldCaption.Add("RISK_MIKTARI", "Risk Miktarı");
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

            //dicFieldCaption.Add("SON_HESAP_TARIHI", "Son Hesap T.");
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
            sozluk.Add("KALAN", InitsEx.ParaBicimiAyarla);
            sozluk.Add("RISK_MIKTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("RISK_MIKTARI_DOVIZ_ID", InitsEx.DovizTipGetir);
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

        private PivotGridField[] KlasoreBagliIcraTakipleri()
        {
            #region Field & Properties

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldICRA_FOY_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldICRA_FOY_ID.AreaIndex = 2;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.Visible = true;

            PivotGridField fieldADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldADI.AreaIndex = 7;
            fieldADI.FieldName = "ADI";
            fieldADI.Name = "fieldADI";
            fieldADI.Visible = true;

            PivotGridField fieldBASLANGIC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASLANGIC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASLANGIC_TARIHI.AreaIndex = 8;
            fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
            fieldBASLANGIC_TARIHI.Visible = true;

            PivotGridField fieldBITIS_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBITIS_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBITIS_TARIHI.AreaIndex = 9;
            fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
            fieldBITIS_TARIHI.Visible = true;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 10;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldOZEL_KOD1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD1.AreaIndex = 12;
            fieldOZEL_KOD1.FieldName = "OZEL_KOD1";
            fieldOZEL_KOD1.Name = "fieldOZEL_KOD1";
            fieldOZEL_KOD1.Visible = false;

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

            PivotGridField fieldPROJE_SORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_SORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_SORUMLU.AreaIndex = 25;
            fieldPROJE_SORUMLU.FieldName = "PROJE_SORUMLU";
            fieldPROJE_SORUMLU.Name = "fieldPROJE_SORUMLU";
            fieldPROJE_SORUMLU.Visible = false;

            PivotGridField fieldPROJE_YETKILI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_YETKILI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_YETKILI.AreaIndex = 26;
            fieldPROJE_YETKILI.FieldName = "PROJE_YETKILI";
            fieldPROJE_YETKILI.Name = "fieldPROJE_YETKILI";
            fieldPROJE_YETKILI.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldFOY_NO.AreaIndex = 27;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = true;

            PivotGridField fieldICRA_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_DURUM.AreaIndex = 28;
            fieldICRA_DURUM.FieldName = "ICRA_DURUM";
            fieldICRA_DURUM.Name = "fieldICRA_DURUM";
            fieldICRA_DURUM.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 29;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldADLI_BIRIM_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_ADLIYE.AreaIndex = 30;
            fieldADLI_BIRIM_ADLIYE.FieldName = "ADLI_BIRIM_ADLIYE";
            fieldADLI_BIRIM_ADLIYE.Name = "fieldADLI_BIRIM_ADLIYE";
            fieldADLI_BIRIM_ADLIYE.Visible = false;

            PivotGridField fieldADLI_BIRIM_GOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_GOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_GOREV.AreaIndex = 31;
            fieldADLI_BIRIM_GOREV.FieldName = "ADLI_BIRIM_GOREV";
            fieldADLI_BIRIM_GOREV.Name = "fieldADLI_BIRIM_GOREV";
            fieldADLI_BIRIM_GOREV.Visible = false;

            PivotGridField fieldADLI_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_NO.AreaIndex = 32;
            fieldADLI_BIRIM_NO.FieldName = "ADLI_BIRIM_NO";
            fieldADLI_BIRIM_NO.Name = "fieldADLI_BIRIM_NO";
            fieldADLI_BIRIM_NO.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 33;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 39;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 40;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldISLEMIS_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEMIS_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEMIS_FAIZ.AreaIndex = 41;
            fieldISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            fieldISLEMIS_FAIZ.Name = "fieldISLEMIS_FAIZ";
            fieldISLEMIS_FAIZ.Visible = false;

            PivotGridField fieldISLEMIS_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEMIS_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEMIS_FAIZ_DOVIZ_ID.AreaIndex = 42;
            fieldISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            fieldISLEMIS_FAIZ_DOVIZ_ID.Name = "fieldISLEMIS_FAIZ_DOVIZ_ID";
            fieldISLEMIS_FAIZ_DOVIZ_ID.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldICRA_FOY_ID,
			fieldADI,
            fieldBASLANGIC_TARIHI,
            fieldBITIS_TARIHI,
			fieldDURUM,
			fieldOZEL_KOD1,
            fieldKONTROL_KIM_ID,
            fieldSUBE_KOD_ID,
			fieldPROJE_SORUMLU,
			fieldPROJE_YETKILI,
            fieldFOY_NO,
            fieldICRA_DURUM,
            fieldTAKIP_TARIHI,
            fieldADLI_BIRIM_ADLIYE,
            fieldADLI_BIRIM_GOREV,
            fieldADLI_BIRIM_NO,
            fieldESAS_NO,
            fieldASIL_ALACAK,
            fieldASIL_ALACAK_DOVIZ_ID,
            fieldISLEMIS_FAIZ,
            fieldISLEMIS_FAIZ_DOVIZ_ID,
			};
            return dizi;
        }
    }
}