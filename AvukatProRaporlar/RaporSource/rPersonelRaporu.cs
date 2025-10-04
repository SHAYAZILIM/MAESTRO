using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class rPersonelRaporu
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

            GridColumn colAD = new GridColumn();
            colAD.VisibleIndex = 1;
            colAD.FieldName = "AD";
            colAD.Name = "colAD";
            colAD.Visible = true;

            GridColumn colKOD = new GridColumn();
            colKOD.VisibleIndex = 2;
            colKOD.FieldName = "KOD";
            colKOD.Name = "colKOD";
            colKOD.Visible = true;

            GridColumn colKAYIT_TARIHI = new GridColumn();
            colKAYIT_TARIHI.VisibleIndex = 3;
            colKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
            colKAYIT_TARIHI.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 4;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colICRA_BORCLU_ODEME_ID = new GridColumn();
            colICRA_BORCLU_ODEME_ID.VisibleIndex = 5;
            colICRA_BORCLU_ODEME_ID.FieldName = "ICRA_BORCLU_ODEME_ID";
            colICRA_BORCLU_ODEME_ID.Name = "colICRA_BORCLU_ODEME_ID";
            colICRA_BORCLU_ODEME_ID.Visible = true;

            GridColumn colMUVEKKILE_ODEME_ID = new GridColumn();
            colMUVEKKILE_ODEME_ID.VisibleIndex = 6;
            colMUVEKKILE_ODEME_ID.FieldName = "MUVEKKILE_ODEME_ID";
            colMUVEKKILE_ODEME_ID.Name = "colMUVEKKILE_ODEME_ID";
            colMUVEKKILE_ODEME_ID.Visible = true;

            GridColumn colCARI_HESAP_HEDEF_TIP = new GridColumn();
            colCARI_HESAP_HEDEF_TIP.VisibleIndex = 7;
            colCARI_HESAP_HEDEF_TIP.FieldName = "CARI_HESAP_HEDEF_TIP";
            colCARI_HESAP_HEDEF_TIP.Name = "colCARI_HESAP_HEDEF_TIP";
            colCARI_HESAP_HEDEF_TIP.Visible = true;

            GridColumn colHAZIRLIK_ID = new GridColumn();
            colHAZIRLIK_ID.VisibleIndex = 8;
            colHAZIRLIK_ID.FieldName = "HAZIRLIK_ID";
            colHAZIRLIK_ID.Name = "colHAZIRLIK_ID";
            colHAZIRLIK_ID.Visible = true;

            GridColumn colADET = new GridColumn();
            colADET.VisibleIndex = 9;
            colADET.FieldName = "ADET";
            colADET.Name = "colADET";
            colADET.Visible = true;

            GridColumn colBIRIM_FIYAT = new GridColumn();
            colBIRIM_FIYAT.VisibleIndex = 10;
            colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
            colBIRIM_FIYAT.Visible = true;

            GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
            colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 11;
            colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
            colBIRIM_FIYAT_DOVIZ_ID.Visible = true;

            GridColumn colGENEL_TOPLAM = new GridColumn();
            colGENEL_TOPLAM.VisibleIndex = 12;
            colGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
            colGENEL_TOPLAM.Visible = true;

            GridColumn colDETAY_ACIKLAMA = new GridColumn();
            colDETAY_ACIKLAMA.VisibleIndex = 13;
            colDETAY_ACIKLAMA.FieldName = "DETAY_ACIKLAMA";
            colDETAY_ACIKLAMA.Name = "colDETAY_ACIKLAMA";
            colDETAY_ACIKLAMA.Visible = true;

            GridColumn colSOZLESME_ID = new GridColumn();
            colSOZLESME_ID.VisibleIndex = 14;
            colSOZLESME_ID.FieldName = "SOZLESME_ID";
            colSOZLESME_ID.Name = "colSOZLESME_ID";
            colSOZLESME_ID.Visible = true;

            GridColumn colPROJE_ID = new GridColumn();
            colPROJE_ID.VisibleIndex = 15;
            colPROJE_ID.FieldName = "PROJE_ID";
            colPROJE_ID.Name = "colPROJE_ID";
            colPROJE_ID.Visible = true;

            GridColumn colMUVEKKIL_MI = new GridColumn();
            colMUVEKKIL_MI.VisibleIndex = 16;
            colMUVEKKIL_MI.FieldName = "MUVEKKIL_MI";
            colMUVEKKIL_MI.Name = "colMUVEKKIL_MI";
            colMUVEKKIL_MI.Visible = true;

            GridColumn colPERSONEL_MI = new GridColumn();
            colPERSONEL_MI.VisibleIndex = 17;
            colPERSONEL_MI.FieldName = "PERSONEL_MI";
            colPERSONEL_MI.Name = "colPERSONEL_MI";
            colPERSONEL_MI.Visible = true;

            GridColumn colAVUKAT_MI = new GridColumn();
            colAVUKAT_MI.VisibleIndex = 18;
            colAVUKAT_MI.FieldName = "AVUKAT_MI";
            colAVUKAT_MI.Name = "colAVUKAT_MI";
            colAVUKAT_MI.Visible = true;

            GridColumn colKURUM_AVUKATI_MI = new GridColumn();
            colKURUM_AVUKATI_MI.VisibleIndex = 19;
            colKURUM_AVUKATI_MI.FieldName = "KURUM_AVUKATI_MI";
            colKURUM_AVUKATI_MI.Name = "colKURUM_AVUKATI_MI";
            colKURUM_AVUKATI_MI.Visible = true;

            GridColumn colBORC_ALACAK = new GridColumn();
            colBORC_ALACAK.VisibleIndex = 20;
            colBORC_ALACAK.FieldName = "BORC_ALACAK";
            colBORC_ALACAK.Name = "colBORC_ALACAK";
            colBORC_ALACAK.Visible = true;

            GridColumn colODEME_TIP = new GridColumn();
            colODEME_TIP.VisibleIndex = 21;
            colODEME_TIP.FieldName = "ODEME_TIP";
            colODEME_TIP.Name = "colODEME_TIP";
            colODEME_TIP.Visible = true;

            GridColumn colICRA_FOY_NO = new GridColumn();
            colICRA_FOY_NO.VisibleIndex = 22;
            colICRA_FOY_NO.FieldName = "ICRA_FOY_NO";
            colICRA_FOY_NO.Name = "colICRA_FOY_NO";
            colICRA_FOY_NO.Visible = true;

            GridColumn colICRA_ESAS_NO = new GridColumn();
            colICRA_ESAS_NO.VisibleIndex = 23;
            colICRA_ESAS_NO.FieldName = "ICRA_ESAS_NO";
            colICRA_ESAS_NO.Name = "colICRA_ESAS_NO";
            colICRA_ESAS_NO.Visible = true;

            GridColumn colICRA_TAKIP_TARIHI = new GridColumn();
            colICRA_TAKIP_TARIHI.VisibleIndex = 24;
            colICRA_TAKIP_TARIHI.FieldName = "ICRA_TAKIP_TARIHI";
            colICRA_TAKIP_TARIHI.Name = "colICRA_TAKIP_TARIHI";
            colICRA_TAKIP_TARIHI.Visible = true;

            GridColumn colICRA_DURUM = new GridColumn();
            colICRA_DURUM.VisibleIndex = 25;
            colICRA_DURUM.FieldName = "ICRA_DURUM";
            colICRA_DURUM.Name = "colICRA_DURUM";
            colICRA_DURUM.Visible = true;

            GridColumn colICRA_ADLIYE = new GridColumn();
            colICRA_ADLIYE.VisibleIndex = 26;
            colICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            colICRA_ADLIYE.Name = "colICRA_ADLIYE";
            colICRA_ADLIYE.Visible = true;

            GridColumn colICRA_BIRIM_NO = new GridColumn();
            colICRA_BIRIM_NO.VisibleIndex = 27;
            colICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Name = "colICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Visible = true;

            GridColumn colDAVA_FOY_NO = new GridColumn();
            colDAVA_FOY_NO.VisibleIndex = 28;
            colDAVA_FOY_NO.FieldName = "DAVA_FOY_NO";
            colDAVA_FOY_NO.Name = "colDAVA_FOY_NO";
            colDAVA_FOY_NO.Visible = true;

            GridColumn colDAVA_DURUM = new GridColumn();
            colDAVA_DURUM.VisibleIndex = 29;
            colDAVA_DURUM.FieldName = "DAVA_DURUM";
            colDAVA_DURUM.Name = "colDAVA_DURUM";
            colDAVA_DURUM.Visible = true;

            GridColumn colDAVA_TARIHI = new GridColumn();
            colDAVA_TARIHI.VisibleIndex = 30;
            colDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            colDAVA_TARIHI.Name = "colDAVA_TARIHI";
            colDAVA_TARIHI.Visible = true;

            GridColumn colDAVA_ADLIYE = new GridColumn();
            colDAVA_ADLIYE.VisibleIndex = 31;
            colDAVA_ADLIYE.FieldName = "DAVA_ADLIYE";
            colDAVA_ADLIYE.Name = "colDAVA_ADLIYE";
            colDAVA_ADLIYE.Visible = true;

            GridColumn colDAVA_BIRIM_GOREV = new GridColumn();
            colDAVA_BIRIM_GOREV.VisibleIndex = 32;
            colDAVA_BIRIM_GOREV.FieldName = "DAVA_BIRIM_GOREV";
            colDAVA_BIRIM_GOREV.Name = "colDAVA_BIRIM_GOREV";
            colDAVA_BIRIM_GOREV.Visible = true;

            GridColumn colDAVA_NO = new GridColumn();
            colDAVA_NO.VisibleIndex = 33;
            colDAVA_NO.FieldName = "DAVA_NO";
            colDAVA_NO.Name = "colDAVA_NO";
            colDAVA_NO.Visible = true;

            GridColumn colDAVA_ESAS_NO = new GridColumn();
            colDAVA_ESAS_NO.VisibleIndex = 34;
            colDAVA_ESAS_NO.FieldName = "DAVA_ESAS_NO";
            colDAVA_ESAS_NO.Name = "colDAVA_ESAS_NO";
            colDAVA_ESAS_NO.Visible = true;

            GridColumn colTAKIBIN_AVUKATA_INTIKAL_TARIHI = new GridColumn();
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 35;
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "colTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colICRA_TAKIP_EDEN = new GridColumn();
            colICRA_TAKIP_EDEN.VisibleIndex = 36;
            colICRA_TAKIP_EDEN.FieldName = "ICRA_TAKIP_EDEN";
            colICRA_TAKIP_EDEN.Name = "colICRA_TAKIP_EDEN";
            colICRA_TAKIP_EDEN.Visible = true;

            GridColumn colICRA_TAKIP_EDILEN = new GridColumn();
            colICRA_TAKIP_EDILEN.VisibleIndex = 37;
            colICRA_TAKIP_EDILEN.FieldName = "ICRA_TAKIP_EDILEN";
            colICRA_TAKIP_EDILEN.Name = "colICRA_TAKIP_EDILEN";
            colICRA_TAKIP_EDILEN.Visible = true;

            GridColumn colICRA_IZLEYEN = new GridColumn();
            colICRA_IZLEYEN.VisibleIndex = 38;
            colICRA_IZLEYEN.FieldName = "ICRA_IZLEYEN";
            colICRA_IZLEYEN.Name = "colICRA_IZLEYEN";
            colICRA_IZLEYEN.Visible = true;

            GridColumn colICRA_SORUMLU = new GridColumn();
            colICRA_SORUMLU.VisibleIndex = 39;
            colICRA_SORUMLU.FieldName = "ICRA_SORUMLU";
            colICRA_SORUMLU.Name = "colICRA_SORUMLU";
            colICRA_SORUMLU.Visible = true;

            GridColumn colAVUKATA_INTIKAL_TARIHI = new GridColumn();
            colAVUKATA_INTIKAL_TARIHI.VisibleIndex = 40;
            colAVUKATA_INTIKAL_TARIHI.FieldName = "AVUKATA_INTIKAL_TARIHI";
            colAVUKATA_INTIKAL_TARIHI.Name = "colAVUKATA_INTIKAL_TARIHI";
            colAVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colDAVACI = new GridColumn();
            colDAVACI.VisibleIndex = 41;
            colDAVACI.FieldName = "DAVACI";
            colDAVACI.Name = "colDAVACI";
            colDAVACI.Visible = true;

            GridColumn colDAVALI = new GridColumn();
            colDAVALI.VisibleIndex = 42;
            colDAVALI.FieldName = "DAVALI";
            colDAVALI.Name = "colDAVALI";
            colDAVALI.Visible = true;

            GridColumn colDAVA_IZLEYEN = new GridColumn();
            colDAVA_IZLEYEN.VisibleIndex = 43;
            colDAVA_IZLEYEN.FieldName = "DAVA_IZLEYEN";
            colDAVA_IZLEYEN.Name = "colDAVA_IZLEYEN";
            colDAVA_IZLEYEN.Visible = true;

            GridColumn colDAVA_SORUMLU = new GridColumn();
            colDAVA_SORUMLU.VisibleIndex = 44;
            colDAVA_SORUMLU.FieldName = "DAVA_SORUMLU";
            colDAVA_SORUMLU.Name = "colDAVA_SORUMLU";
            colDAVA_SORUMLU.Visible = true;

            GridColumn colDAVA_TALEP = new GridColumn();
            colDAVA_TALEP.VisibleIndex = 45;
            colDAVA_TALEP.FieldName = "DAVA_TALEP";
            colDAVA_TALEP.Name = "colDAVA_TALEP";
            colDAVA_TALEP.Visible = true;

            GridColumn colDAVA_FOY_ID = new GridColumn();
            colDAVA_FOY_ID.VisibleIndex = 46;
            colDAVA_FOY_ID.FieldName = "DAVA_FOY_ID";
            colDAVA_FOY_ID.Name = "colDAVA_FOY_ID";
            colDAVA_FOY_ID.Visible = true;

            GridColumn colICRA_FOY_ID = new GridColumn();
            colICRA_FOY_ID.VisibleIndex = 47;
            colICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            colICRA_FOY_ID.Name = "colICRA_FOY_ID";
            colICRA_FOY_ID.Visible = true;

            GridColumn colHAZIRLIK_NO = new GridColumn();
            colHAZIRLIK_NO.VisibleIndex = 48;
            colHAZIRLIK_NO.FieldName = "HAZIRLIK_NO";
            colHAZIRLIK_NO.Name = "colHAZIRLIK_NO";
            colHAZIRLIK_NO.Visible = true;

            GridColumn colSIKAYET_TARIHI = new GridColumn();
            colSIKAYET_TARIHI.VisibleIndex = 49;
            colSIKAYET_TARIHI.FieldName = "SIKAYET_TARIHI";
            colSIKAYET_TARIHI.Name = "colSIKAYET_TARIHI";
            colSIKAYET_TARIHI.Visible = true;

            GridColumn colSORUSTURMA_KONU = new GridColumn();
            colSORUSTURMA_KONU.VisibleIndex = 50;
            colSORUSTURMA_KONU.FieldName = "SORUSTURMA_KONU";
            colSORUSTURMA_KONU.Name = "colSORUSTURMA_KONU";
            colSORUSTURMA_KONU.Visible = true;

            GridColumn colHAZIRLIK_TARIH = new GridColumn();
            colHAZIRLIK_TARIH.VisibleIndex = 51;
            colHAZIRLIK_TARIH.FieldName = "HAZIRLIK_TARIH";
            colHAZIRLIK_TARIH.Name = "colHAZIRLIK_TARIH";
            colHAZIRLIK_TARIH.Visible = true;

            GridColumn colHAZIRLIK_ESAS_NO = new GridColumn();
            colHAZIRLIK_ESAS_NO.VisibleIndex = 52;
            colHAZIRLIK_ESAS_NO.FieldName = "HAZIRLIK_ESAS_NO";
            colHAZIRLIK_ESAS_NO.Name = "colHAZIRLIK_ESAS_NO";
            colHAZIRLIK_ESAS_NO.Visible = true;

            GridColumn colHAZIRLIK_DURUM = new GridColumn();
            colHAZIRLIK_DURUM.VisibleIndex = 53;
            colHAZIRLIK_DURUM.FieldName = "HAZIRLIK_DURUM";
            colHAZIRLIK_DURUM.Name = "colHAZIRLIK_DURUM";
            colHAZIRLIK_DURUM.Visible = true;

            GridColumn colHAZIRLIK_ADLIYE = new GridColumn();
            colHAZIRLIK_ADLIYE.VisibleIndex = 54;
            colHAZIRLIK_ADLIYE.FieldName = "HAZIRLIK_ADLIYE";
            colHAZIRLIK_ADLIYE.Name = "colHAZIRLIK_ADLIYE";
            colHAZIRLIK_ADLIYE.Visible = true;

            GridColumn colHAZIRLIK_BIRIM_NO = new GridColumn();
            colHAZIRLIK_BIRIM_NO.VisibleIndex = 55;
            colHAZIRLIK_BIRIM_NO.FieldName = "HAZIRLIK_BIRIM_NO";
            colHAZIRLIK_BIRIM_NO.Name = "colHAZIRLIK_BIRIM_NO";
            colHAZIRLIK_BIRIM_NO.Visible = true;

            GridColumn colHAZIRLIK_BIRIM_GOREV = new GridColumn();
            colHAZIRLIK_BIRIM_GOREV.VisibleIndex = 56;
            colHAZIRLIK_BIRIM_GOREV.FieldName = "HAZIRLIK_BIRIM_GOREV";
            colHAZIRLIK_BIRIM_GOREV.Name = "colHAZIRLIK_BIRIM_GOREV";
            colHAZIRLIK_BIRIM_GOREV.Visible = true;

            GridColumn colSOZLESME_NO = new GridColumn();
            colSOZLESME_NO.VisibleIndex = 57;
            colSOZLESME_NO.FieldName = "SOZLESME_NO";
            colSOZLESME_NO.Name = "colSOZLESME_NO";
            colSOZLESME_NO.Visible = true;

            GridColumn colSOZLESME_TUR = new GridColumn();
            colSOZLESME_TUR.VisibleIndex = 58;
            colSOZLESME_TUR.FieldName = "SOZLESME_TUR";
            colSOZLESME_TUR.Name = "colSOZLESME_TUR";
            colSOZLESME_TUR.Visible = true;

            GridColumn colSOZLESME_ADI = new GridColumn();
            colSOZLESME_ADI.VisibleIndex = 59;
            colSOZLESME_ADI.FieldName = "SOZLESME_ADI";
            colSOZLESME_ADI.Name = "colSOZLESME_ADI";
            colSOZLESME_ADI.Visible = true;

            GridColumn colSOZLESME_IMZA_T = new GridColumn();
            colSOZLESME_IMZA_T.VisibleIndex = 60;
            colSOZLESME_IMZA_T.FieldName = "SOZLESME_IMZA_T";
            colSOZLESME_IMZA_T.Name = "colSOZLESME_IMZA_T";
            colSOZLESME_IMZA_T.Visible = true;

            GridColumn colSOZLESME_TIP = new GridColumn();
            colSOZLESME_TIP.VisibleIndex = 61;
            colSOZLESME_TIP.FieldName = "SOZLESME_TIP";
            colSOZLESME_TIP.Name = "colSOZLESME_TIP";
            colSOZLESME_TIP.Visible = true;

            GridColumn colSOZLESME_ALT_TIP = new GridColumn();
            colSOZLESME_ALT_TIP.VisibleIndex = 62;
            colSOZLESME_ALT_TIP.FieldName = "SOZLESME_ALT_TIP";
            colSOZLESME_ALT_TIP.Name = "colSOZLESME_ALT_TIP";
            colSOZLESME_ALT_TIP.Visible = true;

            GridColumn colSOZLESME_ADLIYE = new GridColumn();
            colSOZLESME_ADLIYE.VisibleIndex = 63;
            colSOZLESME_ADLIYE.FieldName = "SOZLESME_ADLIYE";
            colSOZLESME_ADLIYE.Name = "colSOZLESME_ADLIYE";
            colSOZLESME_ADLIYE.Visible = true;

            GridColumn colSOZLESME_GOREV = new GridColumn();
            colSOZLESME_GOREV.VisibleIndex = 64;
            colSOZLESME_GOREV.FieldName = "SOZLESME_GOREV";
            colSOZLESME_GOREV.Name = "colSOZLESME_GOREV";
            colSOZLESME_GOREV.Visible = true;

            GridColumn colSOZLESME_BIRIM_NO = new GridColumn();
            colSOZLESME_BIRIM_NO.VisibleIndex = 65;
            colSOZLESME_BIRIM_NO.FieldName = "SOZLESME_BIRIM_NO";
            colSOZLESME_BIRIM_NO.Name = "colSOZLESME_BIRIM_NO";
            colSOZLESME_BIRIM_NO.Visible = true;

            GridColumn colSOZLESME_TAKIP_EDEN = new GridColumn();
            colSOZLESME_TAKIP_EDEN.VisibleIndex = 66;
            colSOZLESME_TAKIP_EDEN.FieldName = "SOZLESME_TAKIP_EDEN";
            colSOZLESME_TAKIP_EDEN.Name = "colSOZLESME_TAKIP_EDEN";
            colSOZLESME_TAKIP_EDEN.Visible = true;

            GridColumn colSOZLESME_TAKIP_EDILEN = new GridColumn();
            colSOZLESME_TAKIP_EDILEN.VisibleIndex = 67;
            colSOZLESME_TAKIP_EDILEN.FieldName = "SOZLESME_TAKIP_EDILEN";
            colSOZLESME_TAKIP_EDILEN.Name = "colSOZLESME_TAKIP_EDILEN";
            colSOZLESME_TAKIP_EDILEN.Visible = true;

            GridColumn colSOZLESME_IZLEYEN = new GridColumn();
            colSOZLESME_IZLEYEN.VisibleIndex = 68;
            colSOZLESME_IZLEYEN.FieldName = "SOZLESME_IZLEYEN";
            colSOZLESME_IZLEYEN.Name = "colSOZLESME_IZLEYEN";
            colSOZLESME_IZLEYEN.Visible = true;

            GridColumn colSOZLESME_SORUMLU = new GridColumn();
            colSOZLESME_SORUMLU.VisibleIndex = 69;
            colSOZLESME_SORUMLU.FieldName = "SOZLESME_SORUMLU";
            colSOZLESME_SORUMLU.Name = "colSOZLESME_SORUMLU";
            colSOZLESME_SORUMLU.Visible = true;

            GridColumn colPROJE_KOD = new GridColumn();
            colPROJE_KOD.VisibleIndex = 70;
            colPROJE_KOD.FieldName = "PROJE_KOD";
            colPROJE_KOD.Name = "colPROJE_KOD";
            colPROJE_KOD.Visible = true;

            GridColumn colADI = new GridColumn();
            colADI.VisibleIndex = 71;
            colADI.FieldName = "ADI";
            colADI.Name = "colADI";
            colADI.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 72;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 73;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            GridColumn colPROJE_TARAFI = new GridColumn();
            colPROJE_TARAFI.VisibleIndex = 74;
            colPROJE_TARAFI.FieldName = "PROJE_TARAFI";
            colPROJE_TARAFI.Name = "colPROJE_TARAFI";
            colPROJE_TARAFI.Visible = true;

            GridColumn colPROJE_SORUMLU = new GridColumn();
            colPROJE_SORUMLU.VisibleIndex = 75;
            colPROJE_SORUMLU.FieldName = "PROJE_SORUMLU";
            colPROJE_SORUMLU.Name = "colPROJE_SORUMLU";
            colPROJE_SORUMLU.Visible = true;

            GridColumn colPROJE_YETKILI = new GridColumn();
            colPROJE_YETKILI.VisibleIndex = 76;
            colPROJE_YETKILI.FieldName = "PROJE_YETKILI";
            colPROJE_YETKILI.Name = "colPROJE_YETKILI";
            colPROJE_YETKILI.Visible = true;

            GridColumn colALT_KATEGORI = new GridColumn();
            colALT_KATEGORI.VisibleIndex = 77;
            colALT_KATEGORI.FieldName = "ALT_KATEGORI";
            colALT_KATEGORI.Name = "colALT_KATEGORI";
            colALT_KATEGORI.Visible = true;

            GridColumn colANA_KATEGORI = new GridColumn();
            colANA_KATEGORI.VisibleIndex = 78;
            colANA_KATEGORI.FieldName = "ANA_KATEGORI";
            colANA_KATEGORI.Name = "colANA_KATEGORI";
            colANA_KATEGORI.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			//colID,
			colAD,
			colKOD,
			colKAYIT_TARIHI,
			colACIKLAMA,
			colICRA_BORCLU_ODEME_ID,
			colMUVEKKILE_ODEME_ID,
			colCARI_HESAP_HEDEF_TIP,

			//colHAZIRLIK_ID,
			colADET,
			colBIRIM_FIYAT,
			colBIRIM_FIYAT_DOVIZ_ID,
			colGENEL_TOPLAM,
			colDETAY_ACIKLAMA,

            //colSOZLESME_ID,
            //colPROJE_ID,
			colMUVEKKIL_MI,
			colPERSONEL_MI,
			colAVUKAT_MI,
			colKURUM_AVUKATI_MI,
			colBORC_ALACAK,
			colODEME_TIP,
			colICRA_FOY_NO,
			colICRA_ESAS_NO,
			colICRA_TAKIP_TARIHI,
			colICRA_DURUM,
			colICRA_ADLIYE,
			colICRA_BIRIM_NO,
			colDAVA_FOY_NO,
			colDAVA_DURUM,
			colDAVA_TARIHI,
			colDAVA_ADLIYE,
			colDAVA_BIRIM_GOREV,
			colDAVA_NO,
			colDAVA_ESAS_NO,
			colTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			colICRA_TAKIP_EDEN,
			colICRA_TAKIP_EDILEN,
			colICRA_IZLEYEN,
			colICRA_SORUMLU,
			colAVUKATA_INTIKAL_TARIHI,
			colDAVACI,
			colDAVALI,
			colDAVA_IZLEYEN,
			colDAVA_SORUMLU,
			colDAVA_TALEP,

            //colDAVA_FOY_ID,
            //colICRA_FOY_ID,
			colHAZIRLIK_NO,
			colSIKAYET_TARIHI,
			colSORUSTURMA_KONU,
			colHAZIRLIK_TARIH,
			colHAZIRLIK_ESAS_NO,
			colHAZIRLIK_DURUM,
			colHAZIRLIK_ADLIYE,
			colHAZIRLIK_BIRIM_NO,
			colHAZIRLIK_BIRIM_GOREV,
			colSOZLESME_NO,
			colSOZLESME_TUR,
			colSOZLESME_ADI,
			colSOZLESME_IMZA_T,
			colSOZLESME_TIP,
			colSOZLESME_ALT_TIP,
			colSOZLESME_ADLIYE,
			colSOZLESME_GOREV,
			colSOZLESME_BIRIM_NO,
			colSOZLESME_TAKIP_EDEN,
			colSOZLESME_TAKIP_EDILEN,
			colSOZLESME_IZLEYEN,
			colSOZLESME_SORUMLU,
			colPROJE_KOD,
			colADI,
			colDURUM,
			colBOLUM,
			colPROJE_TARAFI,
			colPROJE_SORUMLU,
			colPROJE_YETKILI,
			colALT_KATEGORI,
			colANA_KATEGORI,
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

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 0;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAD.AreaIndex = 1;
            fieldAD.FieldName = "AD";
            fieldAD.Name = "fieldAD";
            fieldAD.Visible = false;

            PivotGridField fieldKOD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKOD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKOD.AreaIndex = 2;
            fieldKOD.FieldName = "KOD";
            fieldKOD.Name = "fieldKOD";
            fieldKOD.Visible = false;

            PivotGridField fieldKAYIT_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAYIT_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAYIT_TARIHI.AreaIndex = 3;
            fieldKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            fieldKAYIT_TARIHI.Name = "fieldKAYIT_TARIHI";
            fieldKAYIT_TARIHI.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 4;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldICRA_BORCLU_ODEME_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BORCLU_ODEME_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BORCLU_ODEME_ID.AreaIndex = 5;
            fieldICRA_BORCLU_ODEME_ID.FieldName = "ICRA_BORCLU_ODEME_ID";
            fieldICRA_BORCLU_ODEME_ID.Name = "fieldICRA_BORCLU_ODEME_ID";
            fieldICRA_BORCLU_ODEME_ID.Visible = false;

            PivotGridField fieldMUVEKKILE_ODEME_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKILE_ODEME_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKILE_ODEME_ID.AreaIndex = 6;
            fieldMUVEKKILE_ODEME_ID.FieldName = "MUVEKKILE_ODEME_ID";
            fieldMUVEKKILE_ODEME_ID.Name = "fieldMUVEKKILE_ODEME_ID";
            fieldMUVEKKILE_ODEME_ID.Visible = false;

            PivotGridField fieldCARI_HESAP_HEDEF_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCARI_HESAP_HEDEF_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCARI_HESAP_HEDEF_TIP.AreaIndex = 7;
            fieldCARI_HESAP_HEDEF_TIP.FieldName = "CARI_HESAP_HEDEF_TIP";
            fieldCARI_HESAP_HEDEF_TIP.Name = "fieldCARI_HESAP_HEDEF_TIP";
            fieldCARI_HESAP_HEDEF_TIP.Visible = false;

            PivotGridField fieldHAZIRLIK_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_ID.AreaIndex = 8;
            fieldHAZIRLIK_ID.FieldName = "HAZIRLIK_ID";
            fieldHAZIRLIK_ID.Name = "fieldHAZIRLIK_ID";
            fieldHAZIRLIK_ID.Visible = false;

            PivotGridField fieldADET = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADET.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADET.AreaIndex = 9;
            fieldADET.FieldName = "ADET";
            fieldADET.Name = "fieldADET";
            fieldADET.Visible = false;

            PivotGridField fieldBIRIM_FIYAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT.AreaIndex = 10;
            fieldBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIM_FIYAT.Name = "fieldBIRIM_FIYAT";
            fieldBIRIM_FIYAT.Visible = false;

            PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIM_FIYAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 11;
            fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIM_FIYAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldGENEL_TOPLAM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGENEL_TOPLAM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGENEL_TOPLAM.AreaIndex = 12;
            fieldGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            fieldGENEL_TOPLAM.Name = "fieldGENEL_TOPLAM";
            fieldGENEL_TOPLAM.Visible = false;

            PivotGridField fieldDETAY_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDETAY_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDETAY_ACIKLAMA.AreaIndex = 13;
            fieldDETAY_ACIKLAMA.FieldName = "DETAY_ACIKLAMA";
            fieldDETAY_ACIKLAMA.Name = "fieldDETAY_ACIKLAMA";
            fieldDETAY_ACIKLAMA.Visible = false;

            PivotGridField fieldSOZLESME_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_ID.AreaIndex = 14;
            fieldSOZLESME_ID.FieldName = "SOZLESME_ID";
            fieldSOZLESME_ID.Name = "fieldSOZLESME_ID";
            fieldSOZLESME_ID.Visible = false;

            PivotGridField fieldPROJE_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_ID.AreaIndex = 15;
            fieldPROJE_ID.FieldName = "PROJE_ID";
            fieldPROJE_ID.Name = "fieldPROJE_ID";
            fieldPROJE_ID.Visible = false;

            PivotGridField fieldMUVEKKIL_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMUVEKKIL_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMUVEKKIL_MI.AreaIndex = 16;
            fieldMUVEKKIL_MI.FieldName = "MUVEKKIL_MI";
            fieldMUVEKKIL_MI.Name = "fieldMUVEKKIL_MI";
            fieldMUVEKKIL_MI.Visible = false;

            PivotGridField fieldPERSONEL_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPERSONEL_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPERSONEL_MI.AreaIndex = 17;
            fieldPERSONEL_MI.FieldName = "PERSONEL_MI";
            fieldPERSONEL_MI.Name = "fieldPERSONEL_MI";
            fieldPERSONEL_MI.Visible = false;

            PivotGridField fieldAVUKAT_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAVUKAT_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAVUKAT_MI.AreaIndex = 18;
            fieldAVUKAT_MI.FieldName = "AVUKAT_MI";
            fieldAVUKAT_MI.Name = "fieldAVUKAT_MI";
            fieldAVUKAT_MI.Visible = false;

            PivotGridField fieldKURUM_AVUKATI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKURUM_AVUKATI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKURUM_AVUKATI_MI.AreaIndex = 19;
            fieldKURUM_AVUKATI_MI.FieldName = "KURUM_AVUKATI_MI";
            fieldKURUM_AVUKATI_MI.Name = "fieldKURUM_AVUKATI_MI";
            fieldKURUM_AVUKATI_MI.Visible = false;

            PivotGridField fieldBORC_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBORC_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBORC_ALACAK.AreaIndex = 20;
            fieldBORC_ALACAK.FieldName = "BORC_ALACAK";
            fieldBORC_ALACAK.Name = "fieldBORC_ALACAK";
            fieldBORC_ALACAK.Visible = false;

            PivotGridField fieldODEME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TIP.AreaIndex = 21;
            fieldODEME_TIP.FieldName = "ODEME_TIP";
            fieldODEME_TIP.Name = "fieldODEME_TIP";
            fieldODEME_TIP.Visible = false;

            PivotGridField fieldICRA_FOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_FOY_NO.AreaIndex = 22;
            fieldICRA_FOY_NO.FieldName = "ICRA_FOY_NO";
            fieldICRA_FOY_NO.Name = "fieldICRA_FOY_NO";
            fieldICRA_FOY_NO.Visible = false;

            PivotGridField fieldICRA_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ESAS_NO.AreaIndex = 23;
            fieldICRA_ESAS_NO.FieldName = "ICRA_ESAS_NO";
            fieldICRA_ESAS_NO.Name = "fieldICRA_ESAS_NO";
            fieldICRA_ESAS_NO.Visible = false;

            PivotGridField fieldICRA_TAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_TAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_TAKIP_TARIHI.AreaIndex = 24;
            fieldICRA_TAKIP_TARIHI.FieldName = "ICRA_TAKIP_TARIHI";
            fieldICRA_TAKIP_TARIHI.Name = "fieldICRA_TAKIP_TARIHI";
            fieldICRA_TAKIP_TARIHI.Visible = false;

            PivotGridField fieldICRA_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_DURUM.AreaIndex = 25;
            fieldICRA_DURUM.FieldName = "ICRA_DURUM";
            fieldICRA_DURUM.Name = "fieldICRA_DURUM";
            fieldICRA_DURUM.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 26;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 27;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldDAVA_FOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_FOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_FOY_NO.AreaIndex = 28;
            fieldDAVA_FOY_NO.FieldName = "DAVA_FOY_NO";
            fieldDAVA_FOY_NO.Name = "fieldDAVA_FOY_NO";
            fieldDAVA_FOY_NO.Visible = false;

            PivotGridField fieldDAVA_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_DURUM.AreaIndex = 29;
            fieldDAVA_DURUM.FieldName = "DAVA_DURUM";
            fieldDAVA_DURUM.Name = "fieldDAVA_DURUM";
            fieldDAVA_DURUM.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 30;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldDAVA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_ADLIYE.AreaIndex = 31;
            fieldDAVA_ADLIYE.FieldName = "DAVA_ADLIYE";
            fieldDAVA_ADLIYE.Name = "fieldDAVA_ADLIYE";
            fieldDAVA_ADLIYE.Visible = false;

            PivotGridField fieldDAVA_BIRIM_GOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_BIRIM_GOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_BIRIM_GOREV.AreaIndex = 32;
            fieldDAVA_BIRIM_GOREV.FieldName = "DAVA_BIRIM_GOREV";
            fieldDAVA_BIRIM_GOREV.Name = "fieldDAVA_BIRIM_GOREV";
            fieldDAVA_BIRIM_GOREV.Visible = false;

            PivotGridField fieldDAVA_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_NO.AreaIndex = 33;
            fieldDAVA_NO.FieldName = "DAVA_NO";
            fieldDAVA_NO.Name = "fieldDAVA_NO";
            fieldDAVA_NO.Visible = false;

            PivotGridField fieldDAVA_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_ESAS_NO.AreaIndex = 34;
            fieldDAVA_ESAS_NO.FieldName = "DAVA_ESAS_NO";
            fieldDAVA_ESAS_NO.Name = "fieldDAVA_ESAS_NO";
            fieldDAVA_ESAS_NO.Visible = false;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 35;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldICRA_TAKIP_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_TAKIP_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_TAKIP_EDEN.AreaIndex = 36;
            fieldICRA_TAKIP_EDEN.FieldName = "ICRA_TAKIP_EDEN";
            fieldICRA_TAKIP_EDEN.Name = "fieldICRA_TAKIP_EDEN";
            fieldICRA_TAKIP_EDEN.Visible = false;

            PivotGridField fieldICRA_TAKIP_EDILEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_TAKIP_EDILEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_TAKIP_EDILEN.AreaIndex = 37;
            fieldICRA_TAKIP_EDILEN.FieldName = "ICRA_TAKIP_EDILEN";
            fieldICRA_TAKIP_EDILEN.Name = "fieldICRA_TAKIP_EDILEN";
            fieldICRA_TAKIP_EDILEN.Visible = false;

            PivotGridField fieldICRA_IZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_IZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_IZLEYEN.AreaIndex = 38;
            fieldICRA_IZLEYEN.FieldName = "ICRA_IZLEYEN";
            fieldICRA_IZLEYEN.Name = "fieldICRA_IZLEYEN";
            fieldICRA_IZLEYEN.Visible = false;

            PivotGridField fieldICRA_SORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_SORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_SORUMLU.AreaIndex = 39;
            fieldICRA_SORUMLU.FieldName = "ICRA_SORUMLU";
            fieldICRA_SORUMLU.Name = "fieldICRA_SORUMLU";
            fieldICRA_SORUMLU.Visible = false;

            PivotGridField fieldAVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldAVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldAVUKATA_INTIKAL_TARIHI.AreaIndex = 40;
            fieldAVUKATA_INTIKAL_TARIHI.FieldName = "AVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Name = "fieldAVUKATA_INTIKAL_TARIHI";
            fieldAVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldDAVACI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVACI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVACI.AreaIndex = 41;
            fieldDAVACI.FieldName = "DAVACI";
            fieldDAVACI.Name = "fieldDAVACI";
            fieldDAVACI.Visible = false;

            PivotGridField fieldDAVALI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVALI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVALI.AreaIndex = 42;
            fieldDAVALI.FieldName = "DAVALI";
            fieldDAVALI.Name = "fieldDAVALI";
            fieldDAVALI.Visible = false;

            PivotGridField fieldDAVA_IZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_IZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_IZLEYEN.AreaIndex = 43;
            fieldDAVA_IZLEYEN.FieldName = "DAVA_IZLEYEN";
            fieldDAVA_IZLEYEN.Name = "fieldDAVA_IZLEYEN";
            fieldDAVA_IZLEYEN.Visible = false;

            PivotGridField fieldDAVA_SORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_SORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_SORUMLU.AreaIndex = 44;
            fieldDAVA_SORUMLU.FieldName = "DAVA_SORUMLU";
            fieldDAVA_SORUMLU.Name = "fieldDAVA_SORUMLU";
            fieldDAVA_SORUMLU.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 45;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldDAVA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_FOY_ID.AreaIndex = 46;
            fieldDAVA_FOY_ID.FieldName = "DAVA_FOY_ID";
            fieldDAVA_FOY_ID.Name = "fieldDAVA_FOY_ID";
            fieldDAVA_FOY_ID.Visible = false;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_FOY_ID.AreaIndex = 47;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.Visible = false;

            PivotGridField fieldHAZIRLIK_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_NO.AreaIndex = 48;
            fieldHAZIRLIK_NO.FieldName = "HAZIRLIK_NO";
            fieldHAZIRLIK_NO.Name = "fieldHAZIRLIK_NO";
            fieldHAZIRLIK_NO.Visible = false;

            PivotGridField fieldSIKAYET_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSIKAYET_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSIKAYET_TARIHI.AreaIndex = 49;
            fieldSIKAYET_TARIHI.FieldName = "SIKAYET_TARIHI";
            fieldSIKAYET_TARIHI.Name = "fieldSIKAYET_TARIHI";
            fieldSIKAYET_TARIHI.Visible = false;

            PivotGridField fieldSORUSTURMA_KONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUSTURMA_KONU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUSTURMA_KONU.AreaIndex = 50;
            fieldSORUSTURMA_KONU.FieldName = "SORUSTURMA_KONU";
            fieldSORUSTURMA_KONU.Name = "fieldSORUSTURMA_KONU";
            fieldSORUSTURMA_KONU.Visible = false;

            PivotGridField fieldHAZIRLIK_TARIH = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_TARIH.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_TARIH.AreaIndex = 51;
            fieldHAZIRLIK_TARIH.FieldName = "HAZIRLIK_TARIH";
            fieldHAZIRLIK_TARIH.Name = "fieldHAZIRLIK_TARIH";
            fieldHAZIRLIK_TARIH.Visible = false;

            PivotGridField fieldHAZIRLIK_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_ESAS_NO.AreaIndex = 52;
            fieldHAZIRLIK_ESAS_NO.FieldName = "HAZIRLIK_ESAS_NO";
            fieldHAZIRLIK_ESAS_NO.Name = "fieldHAZIRLIK_ESAS_NO";
            fieldHAZIRLIK_ESAS_NO.Visible = false;

            PivotGridField fieldHAZIRLIK_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_DURUM.AreaIndex = 53;
            fieldHAZIRLIK_DURUM.FieldName = "HAZIRLIK_DURUM";
            fieldHAZIRLIK_DURUM.Name = "fieldHAZIRLIK_DURUM";
            fieldHAZIRLIK_DURUM.Visible = false;

            PivotGridField fieldHAZIRLIK_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_ADLIYE.AreaIndex = 54;
            fieldHAZIRLIK_ADLIYE.FieldName = "HAZIRLIK_ADLIYE";
            fieldHAZIRLIK_ADLIYE.Name = "fieldHAZIRLIK_ADLIYE";
            fieldHAZIRLIK_ADLIYE.Visible = false;

            PivotGridField fieldHAZIRLIK_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_BIRIM_NO.AreaIndex = 55;
            fieldHAZIRLIK_BIRIM_NO.FieldName = "HAZIRLIK_BIRIM_NO";
            fieldHAZIRLIK_BIRIM_NO.Name = "fieldHAZIRLIK_BIRIM_NO";
            fieldHAZIRLIK_BIRIM_NO.Visible = false;

            PivotGridField fieldHAZIRLIK_BIRIM_GOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHAZIRLIK_BIRIM_GOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHAZIRLIK_BIRIM_GOREV.AreaIndex = 56;
            fieldHAZIRLIK_BIRIM_GOREV.FieldName = "HAZIRLIK_BIRIM_GOREV";
            fieldHAZIRLIK_BIRIM_GOREV.Name = "fieldHAZIRLIK_BIRIM_GOREV";
            fieldHAZIRLIK_BIRIM_GOREV.Visible = false;

            PivotGridField fieldSOZLESME_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_NO.AreaIndex = 57;
            fieldSOZLESME_NO.FieldName = "SOZLESME_NO";
            fieldSOZLESME_NO.Name = "fieldSOZLESME_NO";
            fieldSOZLESME_NO.Visible = false;

            PivotGridField fieldSOZLESME_TUR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_TUR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_TUR.AreaIndex = 58;
            fieldSOZLESME_TUR.FieldName = "SOZLESME_TUR";
            fieldSOZLESME_TUR.Name = "fieldSOZLESME_TUR";
            fieldSOZLESME_TUR.Visible = false;

            PivotGridField fieldSOZLESME_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_ADI.AreaIndex = 59;
            fieldSOZLESME_ADI.FieldName = "SOZLESME_ADI";
            fieldSOZLESME_ADI.Name = "fieldSOZLESME_ADI";
            fieldSOZLESME_ADI.Visible = false;

            PivotGridField fieldSOZLESME_IMZA_T = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_IMZA_T.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_IMZA_T.AreaIndex = 60;
            fieldSOZLESME_IMZA_T.FieldName = "SOZLESME_IMZA_T";
            fieldSOZLESME_IMZA_T.Name = "fieldSOZLESME_IMZA_T";
            fieldSOZLESME_IMZA_T.Visible = false;

            PivotGridField fieldSOZLESME_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_TIP.AreaIndex = 61;
            fieldSOZLESME_TIP.FieldName = "SOZLESME_TIP";
            fieldSOZLESME_TIP.Name = "fieldSOZLESME_TIP";
            fieldSOZLESME_TIP.Visible = false;

            PivotGridField fieldSOZLESME_ALT_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_ALT_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_ALT_TIP.AreaIndex = 62;
            fieldSOZLESME_ALT_TIP.FieldName = "SOZLESME_ALT_TIP";
            fieldSOZLESME_ALT_TIP.Name = "fieldSOZLESME_ALT_TIP";
            fieldSOZLESME_ALT_TIP.Visible = false;

            PivotGridField fieldSOZLESME_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_ADLIYE.AreaIndex = 63;
            fieldSOZLESME_ADLIYE.FieldName = "SOZLESME_ADLIYE";
            fieldSOZLESME_ADLIYE.Name = "fieldSOZLESME_ADLIYE";
            fieldSOZLESME_ADLIYE.Visible = false;

            PivotGridField fieldSOZLESME_GOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_GOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_GOREV.AreaIndex = 64;
            fieldSOZLESME_GOREV.FieldName = "SOZLESME_GOREV";
            fieldSOZLESME_GOREV.Name = "fieldSOZLESME_GOREV";
            fieldSOZLESME_GOREV.Visible = false;

            PivotGridField fieldSOZLESME_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_BIRIM_NO.AreaIndex = 65;
            fieldSOZLESME_BIRIM_NO.FieldName = "SOZLESME_BIRIM_NO";
            fieldSOZLESME_BIRIM_NO.Name = "fieldSOZLESME_BIRIM_NO";
            fieldSOZLESME_BIRIM_NO.Visible = false;

            PivotGridField fieldSOZLESME_TAKIP_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_TAKIP_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_TAKIP_EDEN.AreaIndex = 66;
            fieldSOZLESME_TAKIP_EDEN.FieldName = "SOZLESME_TAKIP_EDEN";
            fieldSOZLESME_TAKIP_EDEN.Name = "fieldSOZLESME_TAKIP_EDEN";
            fieldSOZLESME_TAKIP_EDEN.Visible = false;

            PivotGridField fieldSOZLESME_TAKIP_EDILEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_TAKIP_EDILEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_TAKIP_EDILEN.AreaIndex = 67;
            fieldSOZLESME_TAKIP_EDILEN.FieldName = "SOZLESME_TAKIP_EDILEN";
            fieldSOZLESME_TAKIP_EDILEN.Name = "fieldSOZLESME_TAKIP_EDILEN";
            fieldSOZLESME_TAKIP_EDILEN.Visible = false;

            PivotGridField fieldSOZLESME_IZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_IZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_IZLEYEN.AreaIndex = 68;
            fieldSOZLESME_IZLEYEN.FieldName = "SOZLESME_IZLEYEN";
            fieldSOZLESME_IZLEYEN.Name = "fieldSOZLESME_IZLEYEN";
            fieldSOZLESME_IZLEYEN.Visible = false;

            PivotGridField fieldSOZLESME_SORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSOZLESME_SORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSOZLESME_SORUMLU.AreaIndex = 69;
            fieldSOZLESME_SORUMLU.FieldName = "SOZLESME_SORUMLU";
            fieldSOZLESME_SORUMLU.Name = "fieldSOZLESME_SORUMLU";
            fieldSOZLESME_SORUMLU.Visible = false;

            PivotGridField fieldPROJE_KOD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_KOD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_KOD.AreaIndex = 70;
            fieldPROJE_KOD.FieldName = "PROJE_KOD";
            fieldPROJE_KOD.Name = "fieldPROJE_KOD";
            fieldPROJE_KOD.Visible = false;

            PivotGridField fieldADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADI.AreaIndex = 71;
            fieldADI.FieldName = "ADI";
            fieldADI.Name = "fieldADI";
            fieldADI.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 72;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 73;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldPROJE_TARAFI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_TARAFI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_TARAFI.AreaIndex = 74;
            fieldPROJE_TARAFI.FieldName = "PROJE_TARAFI";
            fieldPROJE_TARAFI.Name = "fieldPROJE_TARAFI";
            fieldPROJE_TARAFI.Visible = false;

            PivotGridField fieldPROJE_SORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_SORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_SORUMLU.AreaIndex = 75;
            fieldPROJE_SORUMLU.FieldName = "PROJE_SORUMLU";
            fieldPROJE_SORUMLU.Name = "fieldPROJE_SORUMLU";
            fieldPROJE_SORUMLU.Visible = false;

            PivotGridField fieldPROJE_YETKILI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROJE_YETKILI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROJE_YETKILI.AreaIndex = 76;
            fieldPROJE_YETKILI.FieldName = "PROJE_YETKILI";
            fieldPROJE_YETKILI.Name = "fieldPROJE_YETKILI";
            fieldPROJE_YETKILI.Visible = false;

            PivotGridField fieldALT_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALT_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALT_KATEGORI.AreaIndex = 77;
            fieldALT_KATEGORI.FieldName = "ALT_KATEGORI";
            fieldALT_KATEGORI.Name = "fieldALT_KATEGORI";
            fieldALT_KATEGORI.Visible = false;

            PivotGridField fieldANA_KATEGORI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldANA_KATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldANA_KATEGORI.AreaIndex = 78;
            fieldANA_KATEGORI.FieldName = "ANA_KATEGORI";
            fieldANA_KATEGORI.Name = "fieldANA_KATEGORI";
            fieldANA_KATEGORI.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldID,
			fieldAD,
			fieldKOD,
			fieldKAYIT_TARIHI,
			fieldACIKLAMA,
			fieldICRA_BORCLU_ODEME_ID,
			fieldMUVEKKILE_ODEME_ID,
			fieldCARI_HESAP_HEDEF_TIP,
			fieldHAZIRLIK_ID,
			fieldADET,
			fieldBIRIM_FIYAT,
			fieldBIRIM_FIYAT_DOVIZ_ID,
			fieldGENEL_TOPLAM,
			fieldDETAY_ACIKLAMA,
			fieldSOZLESME_ID,
			fieldPROJE_ID,
			fieldMUVEKKIL_MI,
			fieldPERSONEL_MI,
			fieldAVUKAT_MI,
			fieldKURUM_AVUKATI_MI,
			fieldBORC_ALACAK,
			fieldODEME_TIP,
			fieldICRA_FOY_NO,
			fieldICRA_ESAS_NO,
			fieldICRA_TAKIP_TARIHI,
			fieldICRA_DURUM,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldDAVA_FOY_NO,
			fieldDAVA_DURUM,
			fieldDAVA_TARIHI,
			fieldDAVA_ADLIYE,
			fieldDAVA_BIRIM_GOREV,
			fieldDAVA_NO,
			fieldDAVA_ESAS_NO,
			fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			fieldICRA_TAKIP_EDEN,
			fieldICRA_TAKIP_EDILEN,
			fieldICRA_IZLEYEN,
			fieldICRA_SORUMLU,
			fieldAVUKATA_INTIKAL_TARIHI,
			fieldDAVACI,
			fieldDAVALI,
			fieldDAVA_IZLEYEN,
			fieldDAVA_SORUMLU,
			fieldDAVA_TALEP,
			fieldDAVA_FOY_ID,
			fieldICRA_FOY_ID,
			fieldHAZIRLIK_NO,
			fieldSIKAYET_TARIHI,
			fieldSORUSTURMA_KONU,
			fieldHAZIRLIK_TARIH,
			fieldHAZIRLIK_ESAS_NO,
			fieldHAZIRLIK_DURUM,
			fieldHAZIRLIK_ADLIYE,
			fieldHAZIRLIK_BIRIM_NO,
			fieldHAZIRLIK_BIRIM_GOREV,
			fieldSOZLESME_NO,
			fieldSOZLESME_TUR,
			fieldSOZLESME_ADI,
			fieldSOZLESME_IMZA_T,
			fieldSOZLESME_TIP,
			fieldSOZLESME_ALT_TIP,
			fieldSOZLESME_ADLIYE,
			fieldSOZLESME_GOREV,
			fieldSOZLESME_BIRIM_NO,
			fieldSOZLESME_TAKIP_EDEN,
			fieldSOZLESME_TAKIP_EDILEN,
			fieldSOZLESME_IZLEYEN,
			fieldSOZLESME_SORUMLU,
			fieldPROJE_KOD,
			fieldADI,
			fieldDURUM,
			fieldBOLUM,
			fieldPROJE_TARAFI,
			fieldPROJE_SORUMLU,
			fieldPROJE_YETKILI,
			fieldALT_KATEGORI,
			fieldANA_KATEGORI,
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

            dicFieldCaption.Add("ID", "Dosya Sayısı");
            dicFieldCaption.Add("AD", "Ad");
            dicFieldCaption.Add("KOD", "Kod");
            dicFieldCaption.Add("KAYIT_TARIHI", "Kayıt T");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("ICRA_BORCLU_ODEME_ID", "Borçlu Ödeme Sayısı");
            dicFieldCaption.Add("MUVEKKILE_ODEME_ID", "Müvekkile Ödeme Sayısı");
            dicFieldCaption.Add("CARI_HESAP_HEDEF_TIP", "Hesap Hedef Tip");
            dicFieldCaption.Add("HAZIRLIK_ID", "Soruşturma Sayısı");
            dicFieldCaption.Add("ADET", "Adet");
            dicFieldCaption.Add("BIRIM_FIYAT", "Birim Fiyat");
            dicFieldCaption.Add("GENEL_TOPLAM", "Genel Toplam");
            dicFieldCaption.Add("DETAY_ACIKLAMA", "Detay Açıklama");
            dicFieldCaption.Add("SOZLESME_ID", "");
            dicFieldCaption.Add("PROJE_ID", "");
            dicFieldCaption.Add("MUVEKKIL_MI", "Müvekil");
            dicFieldCaption.Add("PERSONEL_MI", "Personel");
            dicFieldCaption.Add("AVUKAT_MI", "Avukat");
            dicFieldCaption.Add("KURUM_AVUKATI_MI", "Kurum Avukatı");
            dicFieldCaption.Add("BORC_ALACAK", "B/A");
            dicFieldCaption.Add("ODEME_TIP", "Ödeme Tip");
            dicFieldCaption.Add("ICRA_FOY_NO", "İcra Dosya No");
            dicFieldCaption.Add("ICRA_ESAS_NO", "İcra Esas No");
            dicFieldCaption.Add("ICRA_TAKIP_TARIHI", "Takip T");
            dicFieldCaption.Add("ICRA_DURUM", "İcra Durum");
            dicFieldCaption.Add("ICRA_ADLIYE", "İcra Adliye");
            dicFieldCaption.Add("ICRA_BIRIM_NO", "İcra No");
            dicFieldCaption.Add("DAVA_FOY_NO", "Dava Dosya No");
            dicFieldCaption.Add("DAVA_DURUM", "DDava urum");
            dicFieldCaption.Add("DAVA_TARIHI", "Dava T");
            dicFieldCaption.Add("DAVA_ADLIYE", "Dava Mahkeme");
            dicFieldCaption.Add("DAVA_BIRIM_GOREV", "Dava Görev");
            dicFieldCaption.Add("DAVA_NO", "Dava No");
            dicFieldCaption.Add("DAVA_ESAS_NO", "Dava Esas No");
            dicFieldCaption.Add("TAKIBIN_AVUKATA_INTIKAL_TARIHI", "İcra İntikal T");
            dicFieldCaption.Add("ICRA_TAKIP_EDEN", "Takip Eden");
            dicFieldCaption.Add("ICRA_TAKIP_EDILEN", "Takip Edilen");
            dicFieldCaption.Add("ICRA_IZLEYEN", "İcra İzleyen");
            dicFieldCaption.Add("ICRA_SORUMLU", "İcra Sorumlu");
            dicFieldCaption.Add("AVUKATA_INTIKAL_TARIHI", "Dava İntikal T");
            dicFieldCaption.Add("DAVACI", "Davacı");
            dicFieldCaption.Add("DAVALI", "Davalı");
            dicFieldCaption.Add("DAVA_IZLEYEN", "Dava İzleyen");
            dicFieldCaption.Add("DAVA_SORUMLU", "Dava Sorumlu");
            dicFieldCaption.Add("DAVA_TALEP", "Dava Konu");
            dicFieldCaption.Add("DAVA_FOY_ID", "");
            dicFieldCaption.Add("ICRA_FOY_ID", "");
            dicFieldCaption.Add("HAZIRLIK_NO", "Soruşturma Dosya No");
            dicFieldCaption.Add("SIKAYET_TARIHI", "Şikayet T");
            dicFieldCaption.Add("SORUSTURMA_KONU", "Soruşturma Konu");
            dicFieldCaption.Add("HAZIRLIK_TARIH", "Soruşturma T");
            dicFieldCaption.Add("HAZIRLIK_ESAS_NO", "Soruşturma Esas No");
            dicFieldCaption.Add("HAZIRLIK_DURUM", "Soruşturma Durum");
            dicFieldCaption.Add("HAZIRLIK_ADLIYE", "Soruşturma Adliye");
            dicFieldCaption.Add("HAZIRLIK_BIRIM_NO", "Soruşturma No");
            dicFieldCaption.Add("HAZIRLIK_BIRIM_GOREV", "Soruşturma Görev");
            dicFieldCaption.Add("SOZLESME_NO", "Sözleşme Dosya No");
            dicFieldCaption.Add("SOZLESME_TUR", "Sözleşme Tür");
            dicFieldCaption.Add("SOZLESME_ADI", "Sözleşme Adı");
            dicFieldCaption.Add("SOZLESME_IMZA_T", "Sözleşme İmza T");
            dicFieldCaption.Add("SOZLESME_TIP", "Sözleşme Tipi");
            dicFieldCaption.Add("SOZLESME_ALT_TIP", "Sözleşme Alt Tip");
            dicFieldCaption.Add("SOZLESME_ADLIYE", "Sözleşme Adliye");
            dicFieldCaption.Add("SOZLESME_GOREV", "Sözleşme Görev");
            dicFieldCaption.Add("SOZLESME_BIRIM_NO", "Sözleşme No");
            dicFieldCaption.Add("SOZLESME_TAKIP_EDEN", "Sözleşme Takip Eden");
            dicFieldCaption.Add("SOZLESME_TAKIP_EDILEN", "Sözleşme Takip Edilen");
            dicFieldCaption.Add("SOZLESME_IZLEYEN", "Sözleşme İzleyen");
            dicFieldCaption.Add("SOZLESME_SORUMLU", "Sözleşme Sorumlu");
            dicFieldCaption.Add("PROJE_KOD", "Klasör Kod");
            dicFieldCaption.Add("ADI", "Klasör Adı");
            dicFieldCaption.Add("DURUM", "Klasör Durum");
            dicFieldCaption.Add("BOLUM", "Klasör Bölüm");
            dicFieldCaption.Add("PROJE_TARAFI", "Klasör Tarafı");
            dicFieldCaption.Add("PROJE_SORUMLU", "Klasör Sorumlu");
            dicFieldCaption.Add("PROJE_YETKILI", "Klasör Yetkili");
            dicFieldCaption.Add("ALT_KATEGORI", "Hareket Alt Kategori");
            dicFieldCaption.Add("ANA_KATEGORI", "Hareket Ana Kategori");

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

            // sozluk.Add("ICRA_BORCLU_ODEME_ID", Item);
            //sozluk.Add("MUVEKKILE_ODEME_ID", Item);
            //sozluk.Add("HAZIRLIK_ID", Item);
            //sozluk.Add("HAREKET_ANA_KATEGORI_ID", Item);
            //sozluk.Add("HAREKET_ALT_KAREGORI_ID", Item);
            //sozluk.Add("SOZLESME_ID", Item);
            //sozluk.Add("PROJE_ID", Item);
            //sozluk.Add("DAVA_FOY_ID", Item);
            //sozluk.Add("ICRA_FOY_ID", Item);

            #endregion Add item

            return sozluk;
        }
    }
}