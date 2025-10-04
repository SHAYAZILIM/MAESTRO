using AdimAdimDavaKaydi.UserControls.UcDava;
using AvukatProLib2.Entities;
using System;
using System.ComponentModel;

namespace AdimAdimDavaKaydi.DavaTakip
{
    public partial class frmDavaTakip
    {
        private void AV001_TD_BIL_ARA_KARARCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_ARA_KARAR addnew = e.NewObject as AV001_TD_BIL_ARA_KARAR;
            if (addnew == null)
                addnew = new AV001_TD_BIL_ARA_KARAR();

            addnew.KAYIT_TARIHI = DateTime.Today;
            addnew.KLASOR_KODU = "GENEL";
            addnew.KONTROL_KIM = "AVUKATPRO";
            addnew.KONTROL_NE_ZAMAN = DateTime.Today;
            addnew.KONTROL_VERSIYON = 1;
            addnew.STAMP = 1;
            addnew.SUBE_KODU = 1;
            addnew.TARIH = DateTime.Today;
            addnew.YERINE_GETIRME_GUN = 1;
            e.NewObject = addnew;
        }

        private void AV001_TD_BIL_BORCLU_ODEMECollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_BORCLU_ODEME addnew = e.NewObject as AV001_TD_BIL_BORCLU_ODEME;
            if (addnew == null)
                addnew = new AV001_TD_BIL_BORCLU_ODEME();
            addnew.KLASOR_KODU = "GENEL";
            addnew.KONTROL_KIM = "AVUKATPRO";
            addnew.KONTROL_NE_ZAMAN = DateTime.Today;
            addnew.KONTROL_VERSIYON = 1;
            addnew.STAMP = 1;
            addnew.SUBE_KODU = 1;
            addnew.KAYIT_TARIHI = DateTime.Today;
            addnew.ODEME_MIKTAR_DOVIZ_ID = 1;
            addnew.ODEME_MIKTAR = 0;
            addnew.ODEME_TARIHI = DateTime.Now;
            e.NewObject = addnew;
        }

        //}
        private void AV001_TD_BIL_CELSECollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_CELSE addNew = e.NewObject as AV001_TD_BIL_CELSE;
            if (addNew == null)
                addNew = new AV001_TD_BIL_CELSE();

            addNew.CELSE_REFERANS_NO = ucCelseBilgileri.ReferansNo();
            addNew.TARIH = DateTime.Today;
            addNew.SAAT = DateTime.Today.ToShortTimeString();
            addNew.INCELEME_TUR_ID = 2;
            addNew.KAYIT_TARIHI = DateTime.Today;
            addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            addNew.KONTROL_KIM = "AVUKATPRO";
            addNew.KONTROL_NE_ZAMAN = DateTime.Today;
            addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addNew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            addNew.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            e.NewObject = addNew;
        }

        private void AV001_TD_BIL_DAVA_NEDENCollection_AddingNew(object sender,
                                                                 System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TD_BIL_DAVA_NEDEN davaNeden = new AV001_TD_BIL_DAVA_NEDEN();
            davaNeden.TEMADI_VAR = false;
            davaNeden.TERDITLI_MI = false;
            davaNeden.SABIT_FAIZ_UYGULA = false;
            davaNeden.BIR_GUNE_AYLIK_FAIZ = false;
            davaNeden.DO_FAIZ_TIP_ID = 1;
            davaNeden.FAIZ_TIP_ID = 1;
            davaNeden.PROTESTO_GIDERI_FAIZ_ISLESIN = false;
            davaNeden.IHTAR_GIDERI_FAIZ_ISLESIN = false;
            davaNeden.DIGER_GIDER_FAIZ_ISLESIN = true;
            davaNeden.TAZMINAT_HESAP_TIP = 1;
            davaNeden.HER_AY_TAZMINAT_EKLE = false;
            davaNeden.DAVA_EDEN_TARAF_STATU_ID = 3;
            davaNeden.DAVA_EDILEN_TARAF_STATU_ID = 3;
            davaNeden.ISLAH_EDILMIS = false;
            e.NewObject = davaNeden;
        }

        //void AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection_AddingNew(object sender, AddingNewEventArgs e)
        //{
        //    AV001_TDI_BIL_KAYIT_ILISKI_DETAY addnew = e.NewObject as AV001_TDI_BIL_KAYIT_ILISKI_DETAY;
        //    if(addnew==null)
        //        addnew=new AV001_TDI_BIL_KAYIT_ILISKI_DETAY();
        //        addnew.
        private void AV001_TD_BIL_DUSME_YENILEMECollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_DUSME_YENILEME dusmeYenileme = new AV001_TD_BIL_DUSME_YENILEME();
            dusmeYenileme.DUSME_TARIHI = DateTime.Now;
            dusmeYenileme.YENILEME_TARIHI = DateTime.Now;
            e.NewObject = dusmeYenileme;
        }

        private void AV001_TD_BIL_KANITCollection_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TD_BIL_KANIT davaKanit = new AV001_TD_BIL_KANIT();
            davaKanit.KANIT_TARIHI = DateTime.Now;
            davaKanit.IBRAZ_TARIHI = DateTime.Now;
            davaKanit.YEMINLI_MI = false;
            e.NewObject = davaKanit;
        }

        private void AV001_TD_BIL_MAHKEME_HUKUM_TARAFCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_MAHKEME_HUKUM_TARAF addnew = e.NewObject as AV001_TD_BIL_MAHKEME_HUKUM_TARAF;
            if (addnew == null)
                addnew = new AV001_TD_BIL_MAHKEME_HUKUM_TARAF();

            //addnew.TARAF_CARI_ID = AdimAdimDavaKaydi.IcraTakipForms.ucIcraTarafBilgileri.CurrBorcluId;

            addnew.KLASOR_KODU = "GENEL";
            addnew.KONTROL_KIM = "AVUKATPRO";
            addnew.KONTROL_NE_ZAMAN = DateTime.Today;
            addnew.KONTROL_VERSIYON = 1;
            addnew.STAMP = 1;
            addnew.SUBE_KODU = 1;
            addnew.SORUMLULUK_MIKTARI_DOVIZ_ID = 1;
            addnew.SORUMLULUK_MIKTARI = 0;
            e.NewObject = addnew;
        }

        private void AV001_TD_BIL_MAHKEME_HUKUMCollection_AddingNew(object sender,
                                                                    System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TD_BIL_MAHKEME_HUKUM mahkemeHukum = new AV001_TD_BIL_MAHKEME_HUKUM();

            //mahkemeHukum.DAVA_NEDEN_ID=
            mahkemeHukum.HUKUM_TARIHI = DateTime.Now;
            mahkemeHukum.CELSE_VARMI = false;
            mahkemeHukum.PARAYA_CEVRILDI = false;
            mahkemeHukum.CEZA_ERTELENDI = false;
            e.NewObject = mahkemeHukum;
        }

        private void AV001_TD_BIL_TEMINAT_KEFALETCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_TEMINAT_KEFALET addnew = e.NewObject as AV001_TD_BIL_TEMINAT_KEFALET;
            if (addnew == null)
                addnew = new AV001_TD_BIL_TEMINAT_KEFALET();
            addnew.TEMINAT_TUR_ID = 1;
            addnew.TEMINAT_TUTARI = 0;
            addnew.TEMINAT_TUTARI_DOVIZ_ID = 1;
            addnew.KLASOR_KODU = "GENEL";
            addnew.KONTROL_KIM = "AVUKATPRO";
            addnew.KONTROL_NE_ZAMAN = DateTime.Today;
            addnew.KONTROL_VERSIYON = 1;
            addnew.STAMP = 1;
            addnew.SUBE_KODU = 1;
            e.NewObject = addnew;
        }

        private void AV001_TD_BIL_TEMYIZCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_TEMYIZ addnew = e.NewObject as AV001_TD_BIL_TEMYIZ;
            if (addnew == null)
                addnew = new AV001_TD_BIL_TEMYIZ();
            addnew.KLASOR_KODU = "GENEL";
            addnew.KONTROL_KIM = "AVUKATPRO";
            addnew.KONTROL_NE_ZAMAN = DateTime.Today;
            addnew.KONTROL_VERSIYON = 1;
            addnew.STAMP = 1;
            addnew.SUBE_KODU = 1;
            e.NewObject = addnew;
        }

        private void AV001_TD_BIL_TUTUKLANMACollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_TUTUKLANMA addnew = e.NewObject as AV001_TD_BIL_TUTUKLANMA;
            if (addnew == null)
                addnew = new AV001_TD_BIL_TUTUKLANMA();
            addnew.KLASOR_KODU = "GENEL";
            addnew.KONTROL_KIM = "AVUKATPRO";
            addnew.KONTROL_NE_ZAMAN = DateTime.Today;
            addnew.KONTROL_VERSIYON = 1;
            addnew.STAMP = 1;
            addnew.SUBE_KODU = 1;
            addnew.KAYIT_TARIHI = DateTime.Now;
            e.NewObject = addnew;
        }

        private void AV001_TDI_BIL_GORUSMECollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_GORUSME addnew = e.NewObject as AV001_TDI_BIL_GORUSME;
            if (addnew == null)
                addnew = new AV001_TDI_BIL_GORUSME();
            addnew.KLASOR_KODU = "GENEL";
            addnew.KONTROL_KIM = "AVUKATPRO";
            addnew.KONTROL_NE_ZAMAN = DateTime.Today;
            addnew.KONTROL_VERSIYON = 1;
            addnew.STAMP = 1;
            addnew.SUBE_KODU = 1;

            //if (MyFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count > 0)
            addnew.GORUSEN_CARI_ID = (int)MyFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection[0].SORUMLU_AVUKAT_CARI_ID;
            addnew.BITIS_SAATI = DateTime.Now.Hour.ToString();
            addnew.TARIH = DateTime.Now;
            addnew.KAYIT_TARIHI = DateTime.Now;
            e.NewObject = addnew;
        }

        private void DavaDefaultGetir()
        {
            MyFoy.AV001_TD_BIL_DAVA_NEDENCollection.AddingNew += AV001_TD_BIL_DAVA_NEDENCollection_AddingNew;

            MyFoy.AV001_TD_BIL_MAHKEME_HUKUMCollection.AddingNew += AV001_TD_BIL_MAHKEME_HUKUMCollection_AddingNew;

            MyFoy.AV001_TD_BIL_KANITCollection.AddingNew += AV001_TD_BIL_KANITCollection_AddingNew;

            MyFoy.AV001_TD_BIL_DUSME_YENILEMECollection.AddingNew += AV001_TD_BIL_DUSME_YENILEMECollection_AddingNew;

            MyFoy.AV001_TD_BIL_CELSECollection.AddingNew += AV001_TD_BIL_CELSECollection_AddingNew;

            MyFoy.AV001_TD_BIL_ARA_KARARCollection.AddingNew += AV001_TD_BIL_ARA_KARARCollection_AddingNew;

            MyFoy.AV001_TD_BIL_TEMINAT_KEFALETCollection.AddingNew += AV001_TD_BIL_TEMINAT_KEFALETCollection_AddingNew;

            //MyFoy.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.AddingNew += new AddingNewEventHandler(AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection_AddingNew);

            MyFoy.AV001_TD_BIL_TEMYIZCollection.AddingNew += AV001_TD_BIL_TEMYIZCollection_AddingNew;

            MyFoy.AV001_TD_BIL_BORCLU_ODEMECollection.AddingNew += AV001_TD_BIL_BORCLU_ODEMECollection_AddingNew;

            MyFoy.AV001_TD_BIL_MAHKEME_HUKUM_TARAFCollection.AddingNew +=
                AV001_TD_BIL_MAHKEME_HUKUM_TARAFCollection_AddingNew;

            MyFoy.AV001_TD_BIL_TUTUKLANMACollection.AddingNew += AV001_TD_BIL_TUTUKLANMACollection_AddingNew;

            MyFoy.AV001_TDI_BIL_GORUSMECollection.AddingNew += AV001_TDI_BIL_GORUSMECollection_AddingNew;
        }
    }
}