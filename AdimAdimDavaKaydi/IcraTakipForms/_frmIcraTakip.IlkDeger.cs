using System;
using System.ComponentModel;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class _frmIcraTakip
    {
        public static int SiraNo(TList<AV001_TI_BIL_SATIS_CHILD> list)
        {
            if (list.Count == 0)
                return 1;
            else
            {
                list.Sort("MAL_SIRA_NO DESC");

                return list[0].MAL_SIRA_NO + 1;
            }
        }

        private void AV001_TDI_BIL_GORUSMECollection_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TDI_BIL_GORUSME gorusme = new AV001_TDI_BIL_GORUSME();
            int soldakiTaraf = ucIcraTarafBilgileri.CurrBorcluId;

            AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(soldakiTaraf);

            gorusme.GORUSULEN_CARI_ID = cari.ID;
            gorusme.IS_KATEGORI_ID = 493;
            gorusme.GORUSULEN_TEL = cari.TEL_1;
            if (AvukatProLib.Kimlik.Bilgi != null)
                gorusme.GORUSEN_CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
            gorusme.GORUSEN_CARI_ID = 1;
            if (AvukatProLib.Kimlik.Bilgi != null)
                gorusme.GORUSEN_TEL = AvukatProLib.Kimlik.Bilgi.CARI_IDSource.TEL_1;
            gorusme.GORUSME_YONU = 1;

            gorusme.SAAT = DateTime.Now.ToShortTimeString();
            e.NewObject = gorusme;
        }

        private void AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection_AddingNew(object sender,
                                                                          System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TDI_BIL_MASRAF_AVANS_DETAY masrafAvansDetay = new AV001_TDI_BIL_MASRAF_AVANS_DETAY();

            masrafAvansDetay.ODEME_TIP_ID = 1;
            e.NewObject = masrafAvansDetay;
        }

        private void AV001_TDI_BIL_MASRAF_AVANSCollection_AddingNew(object sender,
                                                                    System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TDI_BIL_MASRAF_AVANS masrafAvans = new AV001_TDI_BIL_MASRAF_AVANS();
            int soldakiTaraf = ucIcraTarafBilgileri.CurrBorcluId; //icraTarafBilgileri.CurrentBorcluId;

            //AV001_TI_BIL_FOY_TARAF obj = DataRepository.AV001_TI_BIL_FOY_TARAFProvider.GetByID(soldakiTaraf);

            AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(soldakiTaraf);
            if (cari != null)
                masrafAvans.BORCLU_CARI_ID = cari.ID;

            masrafAvans.ICRA_FOY_ID = MyFoy.ID;
            masrafAvans.MASRAF_AVANS_TIP = 1;
            masrafAvans.CARI_HESAP_HEDEF_TIP = 1;
            masrafAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.AddingNew +=
                AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection_AddingNew;
            e.NewObject = masrafAvans;
        }

        private void AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_ICRA_AddingNew(object sender,
                                                                                 System.ComponentModel.
                                                                                     AddingNewEventArgs e)
        {
            AV001_TDIE_BIL_BELGE belgeBilgi = new AV001_TDIE_BIL_BELGE();

            belgeBilgi.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID; //(int)lueMudurluk.EditValue;
            belgeBilgi.ADLI_BIRIM_GOREV_ID = 18;
            belgeBilgi.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID; //(int)txtBirimNo.EditValue;
            belgeBilgi.ESAS_NO = MyFoy.ESAS_NO; //txtEsasNo.Text;
            belgeBilgi.BELGEYI_YAZAN_ID = MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[0].SORUMLU_AVUKAT_CARI_ID;
            belgeBilgi.STAMP = 0;

            //(int)gLueSorumluAvukat.EditValue;
            belgeBilgi.BELGE_TUR_ID = 7;

            e.NewObject = belgeBilgi;
        }

        private void AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN_TARAF addNew = e.NewObject as AV001_TI_BIL_ALACAK_NEDEN_TARAF;
            if (addNew == null)
                addNew = new AV001_TI_BIL_ALACAK_NEDEN_TARAF();
            e.NewObject = addNew;
        }

        private void AV001_TI_BIL_BORCLU_ODEMECollection_AddingNew(object sender,
                                                                   System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TI_BIL_BORCLU_ODEME addNew = new AV001_TI_BIL_BORCLU_ODEME();

            if (icraTarafBilgileri.AlacakliTaraflar.Count > 0 && icraTarafBilgileri.AlacakliTaraflar[0].CARI_ID.HasValue)
            {
                addNew.BORCLU_ADINA_ODENEN_CARI_ID = icraTarafBilgileri.AlacakliTaraflar[0].CARI_ID.Value;

                addNew.ODENEN_CARI_ID = icraTarafBilgileri.AlacakliTaraflar[0].CARI_ID.Value;
            }

            addNew.BORCLU_ADINA_ODEYEN_CARI_ID = ucIcraTarafBilgileri.CurrBorcluId;
            addNew.ODEYEN_CARI_ID = ucIcraTarafBilgileri.CurrBorcluId;
            addNew.ODEME_YER_ID = 3;
            addNew.ODEME_TIP_ID = 1;
            addNew.ODEME_TARIHI = DateTime.Now;
            addNew.ODEME_MIKTAR_DOVIZ_ID = 1;
            addNew.MAAS_HACZINDEN_MI = false;
            addNew.IHTIYATI_HACIZDE_MI = false;
            e.NewObject = addNew;
        }

        private void AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection_AddingNew(object sender,
                                                                            System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TI_BIL_BORCLU_TAAHHUT_MASTER addNew = new AV001_TI_BIL_BORCLU_TAAHHUT_MASTER();

            addNew.TAAHHUT_SIRA_NO = SiraNo(MyFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection);
            addNew.TAAHHUT_TIP = 1;
            addNew.TAAHHUT_EDEN_ID = ucIcraTarafBilgileri.CurrBorcluId; //icraTarafBilgileri.CurrentBorcluId;
            addNew.TAAHHUT_TARIHI = DateTime.Now;
            addNew.DAVASI_VAR_MI = false;

            if (icraTarafBilgileri.AlacakliTaraflar != null)
            {
                if (icraTarafBilgileri.AlacakliTaraflar.Count > 0)
                    addNew.TAAHHUDU_KABUL_EDEN_ID = icraTarafBilgileri.AlacakliTaraflar[0].ID;
            }
            e.NewObject = addNew;
        }

        private void AV001_TI_BIL_FOY_GELISMECollection_AddingNew(object sender,
                                                                  System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TI_BIL_FOY_GELISME gelisme = new AV001_TI_BIL_FOY_GELISME();
            gelisme.GELISME_ADIM_ID = 10002; //Diger
            e.NewObject = gelisme;
        }

        private void AV001_TI_BIL_HACIZ_MASTERCollection_ListChanged(object sender,
                                                                     System.ComponentModel.ListChangedEventArgs e)
        {
            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemDeleted)
            {
                selectedMaster = ucIcraCore1.ucIcraGridlerTemp1.tabHacizGridler1.HacizMasterSelectedRow;

                if (selectedMaster != null)
                {
                    for (int i = 0; i < selectedMaster.AV001_TI_BIL_HACIZ_CHILDCollection.Count; i++)
                    {
                        if (
                            selectedMaster.AV001_TI_BIL_HACIZ_CHILDCollection[i].AV001_TI_BIL_SATIS_CHILDCollection.
                                Count > 0)
                            selectedMaster.AV001_TI_BIL_HACIZ_CHILDCollection[i].AV001_TI_BIL_SATIS_CHILDCollection.
                                RemoveAt(i);

                        selectedMaster.AV001_TI_BIL_HACIZ_CHILDCollection.RemoveAt(i);
                    }
                }
            }
        }

        private void AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection_AddingNew(object sender,
                                                                          System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN addNew = new AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN();

            addNew.ITIRAZ_EDEN_TARAF_ID = ucIcraTarafBilgileri.CurrBorcluId;

            if (MyFoy.ADLI_BIRIM_ADLIYE_ID.HasValue)
                addNew.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID.Value;

            if (MyFoy.ADLI_BIRIM_GOREV_ID.HasValue)
                addNew.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID.Value;

            if (MyFoy.ADLI_BIRIM_NO_ID.HasValue)
                addNew.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID.Value;

            addNew.BIRIM_NO = MyFoy.BIRIM_NO;
            addNew.BORCA_ITIRAZ_VARMI = false;
            addNew.GECIKMIS_ITIRAZ_MI = false;
            addNew.GOREVE_ITIRAZ_VARMI = false;
            addNew.ZAMAN_ASIMI = false;
            addNew.YETKIYE_ITIRAZ_VARMI = false;

            e.NewObject = addNew;
        }

        private void AV001_TI_BIL_KEFALET_BILGILERICollection_AddingNew(object sender,
                                                                        System.ComponentModel.AddingNewEventArgs e)
        {
            //TODO: BORÇLU KODU SIFATI BURDA ...!!!
            AV001_TI_BIL_KEFALET_BILGILERI kefaletBilgileri = new AV001_TI_BIL_KEFALET_BILGILERI();
            kefaletBilgileri.KEFALET_KAPSAM_ID = 1;
            e.NewObject = kefaletBilgileri;
        }

        private void AV001_TI_BIL_MAL_BEYANICollection_AddingNew(object sender,
                                                                 System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TI_BIL_MAL_BEYANI addNew = e.NewObject as AV001_TI_BIL_MAL_BEYANI;
            if (addNew == null)
                addNew = new AV001_TI_BIL_MAL_BEYANI();

            addNew.ICRA_TARAF = "2";
            addNew.ICRA_TARAF_ID = ucIcraTarafBilgileri.CurrBorcluId; //icraTarafBilgileri.CurrentBorcluId;
            addNew.ITIRAZDAN_ONCE_SONRA = true;
            addNew.MAL_BEYANI_GECERLI_MI = true;
            addNew.SONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI = false;
            addNew.GECIKMIS_MI = false;
            addNew.DAVASI_ACILDI_MI = false;
            e.NewObject = addNew;
        }

        private void AV001_TI_BIL_MEHILCollection_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TI_BIL_MEHIL addNew = e.NewObject as AV001_TI_BIL_MEHIL;
            if (addNew == null)
                addNew = new AV001_TI_BIL_MEHIL();

            addNew.ICRA_MEHIL_ILAM_TEMYIZ_TARIHI = DateTime.Now;
            addNew.EK_MEHIL_VAR_MI = false;
            addNew.ICRA_MEHIL_ISTEYEN_TARAF_ID = ucIcraTarafBilgileri.CurrBorcluId;
            e.NewObject = addNew;
        }

        private void AV001_TI_BIL_SATIS_MASTERCollection_AddingNew(object sender,
                                                                   System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TI_BIL_SATIS_MASTER addNew = e.NewObject as AV001_TI_BIL_SATIS_MASTER;
            if (addNew == null)
                addNew = new AV001_TI_BIL_SATIS_MASTER();

            addNew.ICRA_FOY_ID = MyFoy.ID;
            addNew.SATIS_SIRA_NO = SiraNo(MyFoy.AV001_TI_BIL_SATIS_MASTERCollection);
            addNew.SATISIN_ISTENME_SEKLI_ID = 2;

            addNew.SATISI_ISTENEN_CARI_ID = ucIcraTarafBilgileri.CurrBorcluId; //icraTarafBilgileri.CurrentBorcluId;

            if (icraTarafBilgileri.AlacakliTaraflar.Count > 0)
                addNew.SATISI_ISTEYEN_CARI_ID = icraTarafBilgileri.AlacakliTaraflar[0].CARI_IDSource.ID;

            addNew.VAKTINDE_MI = false;
            addNew.ILAN_SEKLI = 0;
            addNew.SATIS_ISTEME_TARIHI = DateTime.Now;
            addNew.SATIS_TURU_ID = 1;
            addNew.SATIS_TATILI_VAR_MI = false;

            if (AvukatProLib.Kimlik.Bilgi != null)
                addNew.SATIS_SORUMLU_PERSONEL_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
            else
                addNew.SATIS_SORUMLU_PERSONEL_ID = 3; //AKT

            addNew.SEHIR_ICI_DISI = false;
            addNew.SATIS_TARIHI_1 = DateTime.Now;
            addNew.SATIS_TARIHI_2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 3);
            addNew.SATIS_TATILI_VAR_MI = false;
            addNew.SATIS_TURU_ID = 1;
            addNew.SATISIN_ISTENME_SEKLI_ID = 1;
            addNew.SEHIR_ICI_DISI = true;
            addNew.TALIMAT_MI = false;

            e.NewObject = addNew;
        }

        private void DefaultValueEvents()
        {
            MyFoy.AV001_TDI_BIL_GORUSMECollection.AddingNew +=
                AV001_TDI_BIL_GORUSMECollection_AddingNew;

            MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection.AddingNew +=
                AV001_TI_BIL_BORCLU_ODEMECollection_AddingNew;

            MyFoy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection.AddingNew +=
                AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection_AddingNew;

            MyFoy.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_ICRA.AddingNew +=
                AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_ICRA_AddingNew;

            MyFoy.AV001_TI_BIL_FOY_GELISMECollection.AddingNew +=
                AV001_TI_BIL_FOY_GELISMECollection_AddingNew;

            MyFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.AddingNew +=
                AV001_TDI_BIL_MASRAF_AVANSCollection_AddingNew;

            MyFoy.AV001_TI_BIL_KEFALET_BILGILERICollection.AddingNew +=
                AV001_TI_BIL_KEFALET_BILGILERICollection_AddingNew;

            MyFoy.AV001_TI_BIL_MAL_BEYANICollection.AddingNew +=
                AV001_TI_BIL_MAL_BEYANICollection_AddingNew;

            MyFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection.AddingNew +=
                AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection_AddingNew;

            MyFoy.AV001_TI_BIL_MEHILCollection.AddingNew
                += AV001_TI_BIL_MEHILCollection_AddingNew;

            #region HacizMaster - HacizChild - KýymetTakdiri - Istihkak - Istirak

            foreach (AV001_TI_BIL_HACIZ_MASTER hacizMaster in MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection)
            {
                foreach (AV001_TI_BIL_HACIZ_CHILD child in hacizMaster.AV001_TI_BIL_HACIZ_CHILDCollection)
                {
                    child.AV001_TI_BIL_KIYMET_TAKDIRICollection.AddingNew +=
                        AV001_TI_BIL_KIYMET_TAKDIRICollection_AddingNew;
                    child.AV001_TI_BIL_ISTIHKAKCollection.AddingNew += AV001_TI_BIL_ISTIHKAKCollection_AddingNew;
                    child.AV001_TI_BIL_HACIZ_ISTIRAKCollection.AddingNew +=
                        AV001_TI_BIL_HACIZ_ISTIRAKCollection_AddingNew;
                }
            }

            MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.ListChanged
                += AV001_TI_BIL_HACIZ_MASTERCollection_ListChanged;

            #endregion HacizMaster - HacizChild - KýymetTakdiri - Istihkak - Istirak

            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.AddingNew +=
                    AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection_AddingNew;
            }

            #region SatisMaster - SatisChild

            MyFoy.AV001_TI_BIL_SATIS_MASTERCollection.AddingNew
                += AV001_TI_BIL_SATIS_MASTERCollection_AddingNew;

            #endregion SatisMaster - SatisChild
        }

        private int SiraNo(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> list)
        {
            if (list.Count == 0)
                return 1;
            else
            {
                list.Sort("TAAHHUT_SIRA_NO DESC");

                return list[0].TAAHHUT_SIRA_NO + 1;
            }
        }

        private int SiraNo(TList<AV001_TI_BIL_SATIS_MASTER> list)
        {
            if (list.Count == 0)
                return 1;
            else
            {
                list.Sort("SATIS_SIRA_NO DESC");

                return list[0].SATIS_SIRA_NO + 1;
            }
        }

        #region HacizMaster - HacizChild - KiymetTakdiri - HacizIstirak - HacizIstihkak

        private AV001_TI_BIL_HACIZ_CHILD selectedChild;
        private AV001_TI_BIL_HACIZ_MASTER selectedMaster;

        private void AV001_TI_BIL_HACIZ_ISTIRAKCollection_AddingNew(object sender,
                                                                    System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TI_BIL_HACIZ_ISTIRAK addNew = e.NewObject as AV001_TI_BIL_HACIZ_ISTIRAK;
            if (addNew == null)
                addNew = new AV001_TI_BIL_HACIZ_ISTIRAK();

            addNew.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
            addNew.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
            addNew.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
            addNew.BIRIM_NO = MyFoy.BIRIM_NO;

            selectedChild = ucIcraCore1.ucIcraGridlerTemp1.tabHacizGridler1.HacizChildSelectedRow;

            if (selectedChild != null)
            {
                addNew.HACIZLI_MAL_CINS_ID = selectedChild.HACIZLI_MAL_CINS_ID;
                addNew.HACIZLI_MAL_KATEGORI_ID = selectedChild.HACIZLI_MAL_KATEGORI_ID;
                addNew.HACIZLI_MAL_TUR_ID = selectedChild.HACIZLI_MAL_TUR_ID;
            }

            addNew.ISTIRAK_ISTENEN_CARI_ID = ucIcraTarafBilgileri.CurrBorcluId;

            //icraTarafBilgileri.CurrentBorcluId;
            if (icraTarafBilgileri.AlacakliTaraflar.Count > 0)
                addNew.ISTIRAK_ISTEYEN_CARI_ID = icraTarafBilgileri.AlacakliTaraflar[0].ID;

            addNew.ISTIRAK_MIKTAR_BIRIM_ID = 1;
            addNew.ISTIRAK_MIKTAR = 1;
            addNew.ISTIRAK_TALIMAT_MI = false;

            e.NewObject = addNew;
        }

        private void AV001_TI_BIL_ISTIHKAKCollection_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TI_BIL_ISTIHKAK addNew = e.NewObject as AV001_TI_BIL_ISTIHKAK;
            if (addNew == null)
                addNew = new AV001_TI_BIL_ISTIHKAK();

            selectedChild = ucIcraCore1.ucIcraGridlerTemp1.tabHacizGridler1.HacizChildSelectedRow;
            if (selectedChild != null)
            {
                addNew.HACIZLI_MAL_CINS_ID = selectedChild.HACIZLI_MAL_CINS_ID;
                addNew.HACIZLI_MAL_KATEGORI_ID = selectedChild.HACIZLI_MAL_KATEGORI_ID;
                addNew.HACIZLI_MAL_TUR_ID = selectedChild.HACIZLI_MAL_TUR_ID;
            }

            addNew.ISTIHKAK_ADET = 1;
            addNew.ISTIHKAK_BIRIMI_ID = 1;
            addNew.ISTIHKAK_IDDIA_EDEN_ID = ucIcraTarafBilgileri.CurrBorcluId;

            //icraTarafBilgileri.CurrentBorcluId;
            addNew.ISTIHKAK_IDDIA_TARIHI = DateTime.Now;

            e.NewObject = addNew;
        }

        private void AV001_TI_BIL_KIYMET_TAKDIRICollection_AddingNew(object sender,
                                                                     System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TI_BIL_KIYMET_TAKDIRI addNew = e.NewObject as AV001_TI_BIL_KIYMET_TAKDIRI;
            if (addNew == null)
                addNew = new AV001_TI_BIL_KIYMET_TAKDIRI();

            ucIcraCore1.ucIcraGridlerTemp1.tabHacizGridler1.gcHaciz.RefreshDataSource();

            selectedChild = ucIcraCore1.ucIcraGridlerTemp1.tabHacizGridler1.HacizChildSelectedRow;

            if (selectedChild != null)
            {
                addNew.HACIZLI_MAL_KATEGORI_ID = selectedChild.HACIZLI_MAL_KATEGORI_ID;

                addNew.HACIZLI_MAL_CINS_ID = selectedChild.HACIZLI_MAL_CINS_ID;

                addNew.HACIZLI_MAL_TUR_ID = selectedChild.HACIZLI_MAL_TUR_ID;

                addNew.HACIZ_CHILD_ID = selectedChild.ID;
            }

            addNew.HACIZLI_MAL_ADET_BIRIM_ID = 1;

            addNew.HACIZLI_MAL_MIKTARI = 1;

            addNew.ICRA_FOY_ID = MyFoy.ID;

            e.NewObject = addNew;
        }

        #endregion HacizMaster - HacizChild - KiymetTakdiri - HacizIstirak - HacizIstihkak
    }
}