using System;
using AvukatProLib.Extras;
using AvukatProLib.Util;
using AvukatProLib2.Entities;
using AvukatProLib2.Data;
using AdimAdimDavaKaydi.Util.BaseClasses.AvpFormClass.AvpFormUtil;

namespace AdimAdimDavaKaydi.Util
{
    public static class DavaCreator
    {
        public static void DavaOlustur(AV001_TI_BIL_FOY mFoy, AV001_TI_BIL_FOY_TARAF_GELISME mGelisme, DavaTalep mDavaTalep, AdliBirimBolumGorev mAdliGorev, DavaTipi mDavaTipi, DavaAdi mDavaAdi, DateTime mOlayTarihi, int? mDavaEdenCariId, TarafSifat mDavaEdenSifat, TarafKodu? mDavaEdenTarafKodu, int? mDavaEdilenCariId, TarafSifat mDavaEdilenSifat, TarafKodu? mDavaEdilenTarafKodu, OnKayit kaydedildi = null)
        {
            frmDavaDosyaKayitForm frm = new frmDavaDosyaKayitForm();
            frm.OtomatikKayit = true;
            frm.RelatedIcraFoy = mFoy;
            frm.MyGelisme = mGelisme;
            frm.DavaDosyasiKayitIceriden = true;

            if (kaydedildi != null)
                frm.DavaFoyKaydedildi += new EventHandler<BelgeUtil.DavaFoyKaydedildiEventArgs>(delegate
                {
                    kaydedildi.Invoke(null, null);
                });
            //DavaHelper.DavaUret(frm.MyFoy, mFoy, mDavaTalep, mAdliGorev, mDavaTipi, mDavaAdi, mOlayTarihi, mDavaEdenCariId, mDavaEdenSifat, mDavaEdenTarafKodu, mDavaEdilenCariId, mDavaEdilenSifat, mDavaEdilenTarafKodu);
            AV001_TD_BIL_FOY mDavaFoy = new AV001_TD_BIL_FOY();
            mDavaFoy.Tag = "[OTO]";
            mDavaFoy.ADLI_BIRIM_ADLIYE_ID = mFoy.ADLI_BIRIM_ADLIYE_ID;
            mDavaFoy.ADLI_BIRIM_GOREV_ID = (int)mAdliGorev;
            mDavaFoy.DAVA_TALEP_ID = (int)mDavaTalep;
            mDavaFoy.DAVA_TARIHI = DateTime.Today;
            mDavaFoy.DAVA_TIP_ID = (int)mDavaTipi;
            mDavaFoy.SON_HESAP_TARIHI = DateTime.Today;
            AV001_TD_BIL_DAVA_NEDEN ndn = new AV001_TD_BIL_DAVA_NEDEN();
            ndn.DAVA_NEDEN_KOD_ID = (int)mDavaAdi;
            ndn.OLAY_SUC_TARIHI = mOlayTarihi;
            if (mFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(mFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            foreach (AV001_TI_BIL_ALACAK_NEDEN item in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK>), typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>));
                foreach (var kiymet in item.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK)
                {
                    if (kiymet.EVRAK_TUR_ID == 1)
                        ndn.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK.Add(kiymet);
                }
            }
            mDavaFoy.AV001_TD_BIL_DAVA_NEDENCollection.Add(ndn);

            if (mFoy.AV001_TI_BIL_FOY_TARAFCollection.Count < 1)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(mFoy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

            if (mFoy.AV001_TI_BIL_FOY_TARAFCollection.Count > 0)
            {
                foreach (var taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                {
                    if (taraf.TAKIP_EDEN_MI)
                    {
                        AV001_TD_BIL_FOY_TARAF trf = new AV001_TD_BIL_FOY_TARAF();
                        trf.DAVA_EDEN_MI = true;
                        trf.CARI_ID = taraf.CARI_ID;
                        trf.TARAF_KODU = taraf.TARAF_KODU;
                        trf.TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
                        mDavaFoy.AV001_TD_BIL_FOY_TARAFCollection.Add(trf);
                    }
                }
            }

            if (mDavaEdilenCariId.HasValue)
            {
                AV001_TD_BIL_FOY_TARAF trf = mDavaFoy.AV001_TD_BIL_FOY_TARAFCollection.AddNew();
                trf.DAVA_EDEN_MI = false;//DavaEdilen
                trf.CARI_ID = mDavaEdilenCariId.Value;
                if (mDavaEdilenTarafKodu.HasValue)
                    trf.TARAF_KODU = (int)mDavaEdilenTarafKodu.Value;
                trf.TARAF_SIFAT_ID = (int)mDavaEdilenSifat;
            }
            else
            {
                foreach (AV001_TI_BIL_FOY_TARAF icrTaraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                {
                    if (icrTaraf.TAKIP_EDEN_MI)
                    {
                        AV001_TD_BIL_FOY_TARAF trf = mDavaFoy.AV001_TD_BIL_FOY_TARAFCollection.AddNew();
                        trf.DAVA_EDEN_MI = false;
                        trf.CARI_ID = icrTaraf.CARI_ID;
                        trf.TARAF_KODU = icrTaraf.TARAF_KODU;
                        trf.TARAF_SIFAT_ID = (int)mDavaEdilenSifat;
                    }
                }
            }
            if (mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count < 1)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(mFoy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));

            if (mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count > 0)
            {
                foreach (AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumluAvk in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                {
                    AV001_TD_BIL_FOY_SORUMLU_AVUKAT sorumlu = new AV001_TD_BIL_FOY_SORUMLU_AVUKAT();
                    sorumlu.SORUMLU_AVUKAT_CARI_ID = sorumluAvk.SORUMLU_AVUKAT_CARI_ID;
                    sorumlu.YETKILI_MI = sorumluAvk.YETKILI_MI;
                    mDavaFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Add(sorumlu);
                }
            }

            frm.Show();
            frm.MyFoy = mDavaFoy;
        }

        public static void DavaOlustur(AV001_TD_BIL_HAZIRLIK mFoy, AdliBirimBolumGorev mAdliGorev, DavaTipi mDavaTipi, DateTime mOlayTarihi, bool YerdegistirsinMi, OnKayit kaydedildi = null)
        {
            frmDavaDosyaKayitForm frm = new frmDavaDosyaKayitForm();
            frm.OtomatikKayit = true;
            frm.RelatedSorusturma = mFoy;
            //frm.MyGelisme = mGelisme;
            frm.DavaDosyasiKayitIceriden = true;

            if (kaydedildi != null)
                frm.DosyaKaydedildi += kaydedildi;

            //DavaHelper.DavaUret(frm.MyFoy, mFoy, mDavaTalep, mAdliGorev, mDavaTipi, mDavaAdi, mOlayTarihi, mDavaEdenCariId, mDavaEdenSifat, mDavaEdenTarafKodu, mDavaEdilenCariId, mDavaEdilenSifat, mDavaEdilenTarafKodu);
            AV001_TD_BIL_FOY mDavaFoy = new AV001_TD_BIL_FOY();
            mDavaFoy.Tag = "[OTO]";
            mDavaFoy.ADLI_BIRIM_ADLIYE_ID = mFoy.ADLI_BIRIM_ADLIYE_ID;
            mDavaFoy.ADLI_BIRIM_GOREV_ID = (int)mAdliGorev;
            mDavaFoy.DAVA_TALEP_ID = mFoy.SIKAYET_KONU_ID;
            mDavaFoy.DAVA_TARIHI = DateTime.Today;
            mDavaFoy.DAVA_TIP_ID = (int)mDavaTipi;
            mDavaFoy.SON_HESAP_TARIHI = DateTime.Today;
            mDavaFoy.FOY_DURUM_ID = mFoy.DURUM_ID;

            mDavaFoy.REFERANS_NO = mFoy.REFERANS_NO == null ? "" : mFoy.REFERANS_NO;
            mDavaFoy.REFERANS_NO2 = mFoy.REFERANS_NO2 == null ? "" : mFoy.REFERANS_NO2;
            mDavaFoy.REFERANS_NO3 = mFoy.REFERANS_NO3 == null ? "" : mFoy.REFERANS_NO3;
            mDavaFoy.REFERANS_NO4 = mFoy.REFERANS_NO4;
            mDavaFoy.REFERANS_NO5 = mFoy.REFERANS_NO5;
            mDavaFoy.DAVA_OZEL_KOD1_ID = mFoy.OZEL_KOD_1_ID;
            mDavaFoy.DAVA_OZEL_KOD2_ID = mFoy.OZEL_KOD_2_ID;
            mDavaFoy.DAVA_OZEL_KOD3_ID = mFoy.OZEL_KOD_3_ID;
            mDavaFoy.DAVA_OZEL_KOD4_ID = mFoy.OZEL_KOD_4_ID;

            foreach (var itmNeden in mFoy.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection)
            {
                AV001_TD_BIL_DAVA_NEDEN ndn = new AV001_TD_BIL_DAVA_NEDEN();
                ndn.DAVA_NEDEN_KOD_ID = itmNeden.SIKAYET_NEDEN_KOD_ID;
                ndn.OLAY_SUC_TARIHI = mOlayTarihi;
                ndn.OLAY_ADLI_BIRIM_ADLIYE_ID = itmNeden.OLAY_ADLI_BIRIM_ADLIYE_ID;
                ndn.ACIKLAMA = itmNeden.ACIKLAMA;

                if (mFoy.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection.Count == 0)
                    DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(mFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN>));
                mDavaFoy.AV001_TD_BIL_DAVA_NEDENCollection.Add(ndn);
            }


            if (mFoy.AV001_TD_BIL_HAZIRLIK_TARAFCollection.Count < 1)
                DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(mFoy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK_TARAF>));

            if (mFoy.AV001_TD_BIL_HAZIRLIK_TARAFCollection.Count > 0)
            {
                foreach (var taraf in mFoy.AV001_TD_BIL_HAZIRLIK_TARAFCollection)
                {
                    AV001_TD_BIL_FOY_TARAF trf = new AV001_TD_BIL_FOY_TARAF();
                    if (!YerdegistirsinMi)
                    {
                        trf.DAVA_EDEN_MI = taraf.SIKAYET_EDEN_MI;
                        trf.CARI_ID = taraf.CARI_ID;
                        trf.TARAF_KODU = taraf.TARAF_KODU;
                        trf.TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
                    }
                    else
                    {
                        if (taraf.SIKAYET_EDEN_MI)
                        {
                            trf.DAVA_EDEN_MI = false;
                            trf.CARI_ID = taraf.CARI_ID;
                            trf.TARAF_KODU = taraf.TARAF_KODU;
                            trf.TARAF_SIFAT_ID = 10;
                        }
                        else
                        {
                            trf.DAVA_EDEN_MI = true;
                            trf.CARI_ID = taraf.CARI_ID;
                            trf.TARAF_KODU = taraf.TARAF_KODU;
                            trf.TARAF_SIFAT_ID = 11;
                        }
                    }
                    mDavaFoy.AV001_TD_BIL_FOY_TARAFCollection.Add(trf);
                }
            }
            if (mFoy.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection.Count < 1)
                DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(mFoy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>));

            if (mFoy.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.Count > 0)
            {
                foreach (AV001_TD_BIL_HAZIRLIK_SORUMLU sorumluAvk in mFoy.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection)
                {
                    AV001_TD_BIL_FOY_SORUMLU_AVUKAT sorumlu = new AV001_TD_BIL_FOY_SORUMLU_AVUKAT();
                    sorumlu.SORUMLU_AVUKAT_CARI_ID = sorumluAvk.CARI_ID;
                    sorumlu.YETKILI_MI = sorumluAvk.YETKILI_MI;
                    mDavaFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Add(sorumlu);
                }
            }

            frm.Show();
            frm.MyFoy = mDavaFoy;
        }

    }
}