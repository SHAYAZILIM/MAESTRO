using System;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Is.Util
{
    public class IsSozlesmeDetayGetir
    {
        private TList<AV001_TDI_BIL_IS_SOZLESME_DETAY> detay;

        private TList<AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU> detaySorumlu;

        private TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> hareketkat =
            DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(6);
        
        public TList<AV001_TDI_BIL_IS_SOZLESME_DETAY> DetayGetir()
        {
            detay = new TList<AV001_TDI_BIL_IS_SOZLESME_DETAY>();

            AV001_TDI_BIL_IS_SOZLESME_DETAY det;
            foreach (var item in hareketkat)
            {
                det = new AV001_TDI_BIL_IS_SOZLESME_DETAY();
                det.KAYIT_TARIHI = DateTime.Now;
                det.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                det.KONTROL_NE_ZAMAN = DateTime.Now;
                det.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                det.SURE = "Saat";
                det.SURE_BIRIM_TIP = (short)SureBirimTip.Saat;
                det.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;
                det.IS_MUHASEBE_ALT_KATEGORI_ID = item.ID;
                detay.Add(det);
            }
            return detay;
        }

        public TList<AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU> DetaySorumluGetir()
        {
            detaySorumlu = new TList<AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU>();
            AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU detS;
            foreach (var item in hareketkat)
            {
                detS = new AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU();
                detS.KAYIT_TARIHI = DateTime.Now;
                detS.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                detS.KONTROL_NE_ZAMAN = DateTime.Now;
                detS.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                detS.SURE = "Saat";
                detS.SURE_BIRIM_TIP = (short)SureBirimTip.Saat;
                detS.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;
                detS.IS_MUHASEBE_ALT_KATEGORI_ID = item.ID;
                detaySorumlu.Add(detS);
            }
            return detaySorumlu;
        }
    }
}