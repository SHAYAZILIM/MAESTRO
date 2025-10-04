using System;
using System.Collections.Generic;
using System.Linq;

namespace AvukatProLib.Arama
{
    public class R_TEMSIL_ARAMASorgu
    {
        public static List<AV001_TDI_BIL_TEMSIL> GetByFiltreView(int? Taraf, int? Avukat, int? EvrakSorumlu,
            string Yevmiye, DateTime? Tarh, string BelgeSayi, string DosyaNo,
            int? BirimGorev, int? BirimNo, int? Adliye, int? TemsilTur, int? TemsilSekli, string p)
        {
            AvpDataContext data = new AvpDataContext(p);
            var predicate = PredicateBuilder.True<AV001_TDI_BIL_TEMSIL>();
            if (Taraf.HasValue)
            {
                var trf = data.AV001_TDI_BIL_TEMSIL_TARAFs.Where(vi => vi.TARAF_CARI_ID == Taraf).Select(vi => vi.TEMSIL_ID).ToList();
                predicate = predicate.And(vi => trf.Contains(vi.ID));
            }
            if (Avukat.HasValue)
            {
                var trf = data.AV001_TDI_BIL_TEMSIL_AVUKATs.Where(vi => vi.AVUKAT_CARI_ID == Avukat).Select(vi => vi.TEMSIL_ID).ToList();
                predicate = predicate.And(vi => trf.Contains(vi.ID));
            }
            if (EvrakSorumlu.HasValue)
                predicate = predicate.And(vi => vi.EVRAK_SORUMLU_ID == EvrakSorumlu);
            if (!string.IsNullOrEmpty(Yevmiye))
                predicate = predicate.And(vi => vi.YEVMIYE.Contains(Yevmiye));
            if (Tarh.HasValue)
                predicate = predicate.And(vi => vi.TARIHI > Tarh && vi.TARIHI < Tarh.Value.AddDays(1));
            if (!string.IsNullOrEmpty(BelgeSayi))
                predicate = predicate.And(vi => vi.BELGE_SAYI_BILGISI.Contains(BelgeSayi));
            if (!string.IsNullOrEmpty(DosyaNo))
                predicate = predicate.And(vi => vi.DOSYA_NO.Contains(DosyaNo));
            if (BirimGorev.HasValue)
                predicate = predicate.And(vi => vi.ADLI_BIRIM_GOREV_ID == BirimGorev);
            if (BirimNo.HasValue)
                predicate = predicate.And(vi => vi.ADLI_BIRIM_NO_ID == BirimNo);
            if (Adliye.HasValue)
                predicate = predicate.And(vi => vi.ADLI_BIRIM_ADLIYE_ID == Adliye);
            if (TemsilTur.HasValue)
                predicate = predicate.And(vi => vi.TEMSIL_TUR_ID == TemsilTur);
            if (TemsilSekli.HasValue)
                predicate = predicate.And(vi => vi.TEMSIL_SEKIL_ID == TemsilSekli);

            var sonuc = data.AV001_TDI_BIL_TEMSILs.Where(predicate).ToList();
            return sonuc;
        }
    }
}