using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BelgeUtil
{
    public partial class Inits
    {
        public static List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN_ITIRAZ> GetAlacakNedenItirazViewItem(List<int> aNedenItirazIDList)
        {
            return BelgeUtil.Inits.context.per_TAKIP_ALACAK_NEDEN_ITIRAZs.Where(item => aNedenItirazIDList.Contains(item.ID)).ToList();
        }

        public static List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN> GetAlacakNedenViewItem(List<int> aNedenIDList)
        {
            return BelgeUtil.Inits.context.per_TAKIP_ALACAK_NEDENs.Where(item => aNedenIDList.Contains(item.ID)).ToList();
        }

        public static List<AvukatProLib.Arama.per_AV001_TI_BIL_ALACAK_NEDEN> GetAlacakNedenViewItem(TList<AV001_TI_BIL_ALACAK_NEDEN> aNedens)
        {
            List<AvukatProLib.Arama.per_AV001_TI_BIL_ALACAK_NEDEN> views = new List<AvukatProLib.Arama.per_AV001_TI_BIL_ALACAK_NEDEN>();
            aNedens.ForEach(item =>
                {
                    AvukatProLib.Arama.per_AV001_TI_BIL_ALACAK_NEDEN view = new AvukatProLib.Arama.per_AV001_TI_BIL_ALACAK_NEDEN();
                    view.ALACAK_NEDEN_ID = item.ID;
                    view.ALACAK_NEDEN_KOD_ID = item.ALACAK_NEDEN_KOD_ID;
                    view.ALACAK_NEDENI = item.DIGER_ALACAK_NEDENI;
                    view.AN_URETIP_TIP = item.AN_URETIP_TIP;
                    view.DAMGA_PULU = item.DAMGA_PULU;
                    view.DIGER_ALACAK_NEDENI = item.DIGER_ALACAK_NEDENI;
                    view.DUZENLENME_TARIHI = item.DUZENLENME_TARIHI;
                    view.ICRA_FOY_ID = item.ICRA_FOY_ID;
                    view.ISLEME_KONAN_TUTAR = item.ISLEME_KONAN_TUTAR;
                    view.ISLEME_KONAN_TUTAR_DOVIZ_ID = item.ISLEME_KONAN_TUTAR_DOVIZ_ID;
                    view.KDV_TIP_ID = item.KDV_TIP_ID;
                    view.REFERANS_NO = item.REFERANS_NO;
                    view.REFERANS_NO2 = item.REFERANS_NO2;
                    view.TO_ALACAK_FAIZ_TIP_ID = item.TO_ALACAK_FAIZ_TIP_ID;
                    view.TUTAR_DOVIZ_ID = item.TUTAR_DOVIZ_ID;
                    view.TUTARI = item.TUTARI;
                    view.VADE_TARIHI = item.VADE_TARIHI;

                    views.Add(view);
                });
            return views;
        }

        public static per_TD_KOD_ARA_KARAR_TIP GetAraKararViewItem(TD_KOD_ARA_KARAR_TIP tip)
        {
            per_TD_KOD_ARA_KARAR_TIP view = new per_TD_KOD_ARA_KARAR_TIP();
            view.ARA_KARAR_TIP = tip.ARA_KARAR_TIP;
            view.BOLUM = tip.BOLUM;
            view.ID = tip.ID;
            view.KONTROL_KIM_ID = tip.KONTROL_KIM_ID;
            view.SUBE_KOD_ID = tip.SUBE_KOD_ID;
            return view;
        }

        public static per_AV001_TDIE_KOD_OZEL_KOD GetBelgeOzelKodViewItem(AV001_TDIE_KOD_OZEL_KOD ozelKod)
        {
            per_AV001_TDIE_KOD_OZEL_KOD view = new per_AV001_TDIE_KOD_OZEL_KOD();

            view.ID = ozelKod.ID;
            view.KOD = ozelKod.KOD;
            view.KONTROL_KIM_ID = ozelKod.KONTROL_KIM_ID;
            view.MODUL_ID = ozelKod.MODUL_ID;
            view.SUBE_KOD_ID = ozelKod.SUBE_KOD_ID;

            return view;
        }

        public static AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE GetBelgeViewItem(AV001_TDIE_BIL_BELGE belge)
        {
            AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE view = new AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE();
            view.ACIKLAMA = belge.ACIKLAMA;
            view.ADLI_BIRIM_ADLIYE_ID = belge.ADLI_BIRIM_ADLIYE_ID;
            view.ADLI_BIRIM_GOREV_ID = belge.ADLI_BIRIM_GOREV_ID;
            view.ADLI_BIRIM_NO_ID = belge.ADLI_BIRIM_NO_ID;
            view.ASAMA_ID = belge.ASAMA_ID;
            view.BELGE_ADI = belge.BELGE_ADI;
            view.BELGE_NO = belge.BELGE_NO;
            view.BELGE_REFERANS_NO = belge.BELGE_REFERANS_NO;
            view.BELGE_TUR_ID = belge.BELGE_TUR_ID;
            view.BELGEYI_YAZAN_ID = belge.BELGEYI_YAZAN_ID;
            view.DAVA_TAKIP_KONU = belge.DAVA_TAKIP_KONU;
            view.DOKUMAN_UZANTI = belge.DOKUMAN_UZANTI;
            view.DOSYA_ADI = belge.DOSYA_ADI;
            view.ESAS_NO = belge.ESAS_NO;
            view.ID = belge.ID;
            view.IZLENSIN_MI = belge.IZLENSIN_MI;
            view.KAYIT_TARIHI = belge.KAYIT_TARIHI;
            view.KILITLI_MI = belge.KILITLI_MI;
            view.KLASOR_KODU = belge.KLASOR_KODU;
            view.ONEMLI_MI = belge.ONEMLI_MI;
            view.OZEL_KOD_1_ID = belge.OZEL_KOD_1_ID;
            view.OZEL_KOD_2_ID = belge.OZEL_KOD_2_ID;
            view.OZEL_KOD_3_ID = belge.OZEL_KOD_3_ID;
            view.OZEL_KOD_4_ID = belge.OZEL_KOD_4_ID;
            view.SUBE_KOD_ID = belge.SUBE_KOD_ID;
            view.SUC_OLAY_VADE_TARIHI = belge.SUC_OLAY_VADE_TARIHI;
            view.YAZILMA_TARIHI = belge.YAZILMA_TARIHI;
            return view;
        }

        public static AvukatProLib.Arama.per_AV001_TDI_BIL_CARI GetCariViewItem(AV001_TDI_BIL_CARI cari)
        {
            AvukatProLib.Arama.per_AV001_TDI_BIL_CARI view = new AvukatProLib.Arama.per_AV001_TDI_BIL_CARI();
            view.AD = cari.AD;
            view.ADLI_BIRIM_MI = cari.ADLI_BIRIM_MI;
            view.ADLI_PERSONEL_MI = cari.ADLI_PERSONEL_MI;
            view.AVUKAT_MI = cari.AVUKAT_MI;
            view.AVUKAT_ORTAKLIGI_MI = cari.AVUKAT_ORTAKLIGI_MI;
            view.BILIRKISI_MI = cari.BILIRKISI_MI;
            view.FIRMA_MI = cari.FIRMA_MI;
            view.HAKEM_MI = cari.HAKEM_MI;
            view.HARCDAN_MUAF_MI = cari.HARCDAN_MUAF_MI;
            view.HASIMSIZ_CARISI_MI = cari.HASIMSIZ_CARISI_MI;
            view.ID = cari.ID;
            view.KAMU_CARI_MI = cari.KAMU_CARI_MI;
            view.KARSI_TARAF_MI = cari.KARSI_TARAF_MI;
            view.KOD = cari.KOD;
            view.KONTROL_KIM_ID = cari.KONTROL_KIM_ID;
            view.MUSTERI_NO = cari.MUSTERI_NO;
            view.MUVEKKIL_MI = cari.MUVEKKIL_MI;
            view.PERSONEL_MI = cari.PERSONEL_MI;
            view.SUBE_KOD_ID = cari.SUBE_KOD_ID;
            view.YETKILI_MI = cari.YETKILI_MI;
            return view;
        }

        public static List<AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF> GetDavaFoyTarafViewItem(TList<AV001_TD_BIL_FOY_TARAF> taraflar)
        {
            List<AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF> views = new List<AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF>();
            taraflar.ForEach(taraf =>
            {
                AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF view = new AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF();
                if (BelgeUtil.Inits._per_CariGetir == null)
                    BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();
                var cari = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == taraf.CARI_ID);
                view.AD = cari.AD;
                view.CARI_ID = taraf.CARI_ID;
                view.DAVA_FOY_ID = taraf.DAVA_FOY_ID;
                view.ID = taraf.ID;
                view.KOD = cari.KOD;
                view.DAVA_EDEN_MI = taraf.DAVA_EDEN_MI;
                view.TARAF_KODU = taraf.TARAF_KODU;
                view.TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
                views.Add(view);
            });
            return views;
        }

        public static per_TD_KOD_DAVA_TALEP GetDavaTalepViewItem(TD_KOD_DAVA_TALEP davaTalep)
        {
            per_TD_KOD_DAVA_TALEP view = new per_TD_KOD_DAVA_TALEP();

            view.ADLI_BIRIM_BOLUM_ID = davaTalep.ADLI_BIRIM_BOLUM_ID;
            view.DAVA_TALEP = davaTalep.DAVA_TALEP;
            view.ID = davaTalep.ID;
            view.KONTROL_KIM_ID = davaTalep.KONTROL_KIM_ID;
            view.SUBE_KOD_ID = davaTalep.SUBE_KOD_ID;

            return view;
        }

        public static AvukatProLib.Arama.VTD_DAVA_DOSYALAR GetDavaViewItem(AV001_TD_BIL_FOY foy)
        {
            AvukatProLib.Arama.VTD_DAVA_DOSYALAR view = new AvukatProLib.Arama.VTD_DAVA_DOSYALAR();

            view.ID = foy.ID;

            view.ADLIYE_ID = foy.ADLI_BIRIM_ADLIYE_ID;
            if (view.ADLIYE_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimAdliyeGetir == null)
                    BelgeUtil.Inits._AdliBirimAdliyeGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();
                view.ADLIYE = BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == view.ADLIYE_ID.Value).ADLIYE;
            }

            view.BIRIM_ID = foy.ADLI_BIRIM_NO_ID;
            if (view.BIRIM_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimNoGetir == null)
                    BelgeUtil.Inits._AdliBirimNoGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();
                view.NO = BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == view.BIRIM_ID.Value).NO;
            }

            view.GOREV_ID = foy.ADLI_BIRIM_GOREV_ID;
            if (view.GOREV_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimGorevGetir_Enter == null)
                    BelgeUtil.Inits._AdliBirimGorevGetir_Enter = DataRepository.per_TDI_KOD_ADLI_BIRIM_GOREVProvider.GetAll();
                view.GOREV = BelgeUtil.Inits._AdliBirimGorevGetir_Enter.Find(vi => vi.ID == view.GOREV_ID.Value).GOREV;
            }

            view.DAVA_TALEP_ID = foy.DAVA_TALEP_ID;
            view.DAVA_TARIHI = foy.DAVA_TARIHI;
            view.ESAS_NO = foy.ESAS_NO;
            view.FOY_NO = foy.FOY_NO;
            view.SUBE_KOD_ID = foy.SUBE_KOD_ID;

            return view;
        }

        public static List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF> GetIcraFoyTarafViewItem(TList<AV001_TI_BIL_FOY_TARAF> taraflar)
        {
            List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF> views = new List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF>();
            taraflar.ForEach(taraf =>
                {
                    AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF view = new AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF();
                    if (BelgeUtil.Inits._per_CariGetir == null)
                        BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();
                    var cari = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == taraf.CARI_ID);
                    view.AD = cari.AD;
                    view.CARI_ID = taraf.CARI_ID;
                    view.ICRA_FOY_ID = taraf.ICRA_FOY_ID;
                    view.ID = taraf.ID;
                    view.KOD = cari.KOD;
                    view.TAKIP_CIKISI = taraf.TAKIP_CIKISI;
                    view.TAKIP_CIKISI_DOVIZ_ID = taraf.TAKIP_CIKISI_DOVIZ_ID;
                    view.TAKIP_EDEN_MI = taraf.TAKIP_EDEN_MI;
                    view.TARAF_KODU = taraf.TARAF_KODU;
                    view.TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
                    views.Add(view);
                });
            return views;
        }

        public static AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama GetIcraViewItem(AV001_TI_BIL_FOY foy)
        {
            AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama view = new AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama();

            view.ID = foy.ID;

            view.ADLI_BIRIM_ADLIYE_ID = foy.ADLI_BIRIM_ADLIYE_ID;
            if (view.ADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimAdliyeGetir == null)
                    BelgeUtil.Inits._AdliBirimAdliyeGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();
                view.ADLI_BIRIM_ADLIYE = BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == view.ADLI_BIRIM_ADLIYE_ID.Value).ADLIYE;
            }

            view.ADLI_BIRIM_NO_ID = foy.ADLI_BIRIM_NO_ID;
            if (view.ADLI_BIRIM_NO_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimNoGetir == null)
                    BelgeUtil.Inits._AdliBirimNoGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();
                view.ADLI_BIRIM_NO = BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == view.ADLI_BIRIM_NO_ID.Value).NO;
            }
            view.GOREV = "İCRM";

            view.ASIL_ALACAK = foy.ASIL_ALACAK;
            view.ASIL_ALACAK_DOVIZ_ID = foy.ASIL_ALACAK_DOVIZ_ID;
            view.BSMV_TO = foy.BSMV_TO;
            view.DEPARTMANA_INTIKAL_TARIHI = foy.DEPARTMANA_INTIKAL_TARIHI;
            view.ESAS_NO = foy.ESAS_NO;
            view.FORM_TIP_ID = foy.FORM_TIP_ID;
            view.FORM_ORNEK_NO = foy.FORM_ORNEK_NO;
            view.FOY_BIRIM_ID = foy.SEGMENT_ID;
            view.FOY_DURUM_ID = foy.FOY_DURUM_ID;
            view.FOY_NO = foy.FOY_NO;
            view.ISLEMIS_FAIZ = foy.ISLEMIS_FAIZ;
            view.ISLEMIS_FAIZ_DOVIZ_ID = foy.ISLEMIS_FAIZ_DOVIZ_ID;
            view.KALAN = foy.KALAN;
            view.KALAN_DOVIZ_ID = foy.KALAN_DOVIZ_ID;
            view.TAKIP_CIKISI = foy.TAKIP_CIKISI;
            view.TAKIP_CIKISI_DOVIZ_ID = foy.TAKIP_CIKISI_DOVIZ_ID;
            view.TAKIP_TALEP_ID = foy.TAKIP_TALEP_ID;
            view.TAKIP_TARIHI = foy.TAKIP_TARIHI;

            return view;
        }

        public static AvukatProLib.Arama.per_AV001_TDI_KOD_FOY_OZEL_KOD GetOzelKodViewItem(AV001_TDI_KOD_FOY_OZEL ozelKod)
        {
            AvukatProLib.Arama.per_AV001_TDI_KOD_FOY_OZEL_KOD view = new AvukatProLib.Arama.per_AV001_TDI_KOD_FOY_OZEL_KOD();

            view.ALAN1 = ozelKod.ALAN1;
            view.ALAN2 = ozelKod.ALAN2;
            view.ALAN3 = ozelKod.ALAN3;
            view.ALAN4 = ozelKod.ALAN4;
            view.DAVA = ozelKod.DAVA;
            view.HAZIRLIK = ozelKod.HAZIRLIK;
            view.ICRA = ozelKod.ICRA;
            view.ID = ozelKod.ID;
            view.KOD = ozelKod.KOD;
            view.SOZLESME = ozelKod.SOZLESME;

            return view;
        }

        public static AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE GetProjeViewItem(AV001_TDIE_BIL_PROJE proje)
        {
            AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE view = new AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE();
            view.ACIKLAMA = proje.ACIKLAMA;
            view.ADI = proje.ADI;
            view.BASLANGIC_TARIHI = proje.BASLANGIC_TARIHI;
            view.BITIS_TARIHI = proje.BITIS_TARIHI;
            view.DURUM_ID = proje.DURUM_ID;
            view.ID = proje.ID;
            view.IsSelected = proje.IsSelected;
            view.KOD = proje.KOD;
            view.OZEL_KOD1_ID = proje.OZEL_KOD1_ID;
            view.PROJE_DURUM_ID = proje.PROJE_DURUM_ID;
            view.PROJE_TIP_ID = proje.PROJE_TIP_ID;
            view.SUBE_KOD_ID = proje.SUBE_KOD_ID;
            return view;
        }

        public static AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR GetRaporViewItem(AV001_TDIE_BIL_SABLON_RAPOR rapor)
        {
            AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR view = new AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR();
            view.ACIKLAMA = rapor.ACIKLAMA;
            view.AD = rapor.AD;
            view.ADLI_BIRIM_BOLUM_ID = rapor.ADLI_BIRIM_BOLUM_ID;
            view.ADLI_BIRIM_GOREV_ID = rapor.ADLI_BIRIM_GOREV_ID;
            view.DAVA_NEDEN_ID = rapor.DAVA_NEDEN_ID;
            view.DAVA_TALEP_ID = rapor.DAVA_TALEP_ID;
            view.DEGISKENI_VARMI = rapor.DEGISKENI_VARMI;
            view.DIL_ID = rapor.DIL_ID;
            view.DOSYA_ADRES = rapor.DOSYA_ADRES;
            view.FORM_ORNEK_ID = rapor.FORM_ORNEK_ID;
            view.ID = rapor.ID;
            view.KATEGORI_ID = rapor.KATEGORI_ID;
            view.KONTROL_KIM_ID = rapor.KONTROL_KIM_ID;
            view.MODUL_ID = rapor.MODUL_ID;
            view.RAPOR_TIP_ID = rapor.RAPOR_TIP_ID;
            view.SEKTOR_ID = rapor.SEKTOR_ID;
            view.SOZLESME_TIP_ID = rapor.SOZLESME_TIP_ID;
            view.SUBE_KOD_ID = rapor.SUBE_KOD_ID;
            view.TAKIP_TALEP_KONU_ID = rapor.TAKIP_TALEP_KONU_ID;
            if (rapor.THUMBNAIL != null) view.THUMBNAIL = rapor.THUMBNAIL;//Null olduğunda atama hata verdiğinden bu kontrol eklendi. MB
            return view;
        }

        public static AvukatProLib.Arama.VTD_SORUSTURMA_DOSYALAR GetSorusturmaViewItem(AV001_TD_BIL_HAZIRLIK foy)
        {
            AvukatProLib.Arama.VTD_SORUSTURMA_DOSYALAR view = new AvukatProLib.Arama.VTD_SORUSTURMA_DOSYALAR();

            view.ID = foy.ID;

            view.ADLIYE_ID = foy.ADLI_BIRIM_ADLIYE_ID;
            if (view.ADLIYE_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimAdliyeGetir == null)
                    BelgeUtil.Inits._AdliBirimAdliyeGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();
                view.ADLIYE = BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == view.ADLIYE_ID.Value).ADLIYE;
            }

            view.BIRIM_ID = foy.ADLI_BIRIM_NO_ID;
            if (view.BIRIM_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimNoGetir == null)
                    BelgeUtil.Inits._AdliBirimNoGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();
                view.NO = BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == view.BIRIM_ID.Value).NO;
            }

            view.GOREV_ID = foy.ADLI_BIRIM_GOREV_ID;
            if (view.GOREV_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimGorevGetir_Enter == null)
                    BelgeUtil.Inits._AdliBirimGorevGetir_Enter = DataRepository.per_TDI_KOD_ADLI_BIRIM_GOREVProvider.GetAll();
                view.GOREV = BelgeUtil.Inits._AdliBirimGorevGetir_Enter.Find(vi => vi.ID == view.GOREV_ID.Value).GOREV;
            }

            view.HAZIRLIK_ESAS_NO = foy.HAZIRLIK_ESAS_NO;
            view.HAZIRLIK_NO = foy.HAZIRLIK_NO;
            view.HAZIRLIK_TARIH = foy.HAZIRLIK_TARIH;
            view.SUBE_KOD_ID = foy.SUBE_KOD_ID;

            return view;
        }
    }
}