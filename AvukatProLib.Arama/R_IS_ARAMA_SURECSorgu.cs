using System;
using System.Collections.Generic;
using System.Linq;

namespace AvukatProLib.Arama
{
    public class R_IS_ARAMA_SURECSorgu
    {
        public static List<AV001_TDI_BIL_IS_TAMAMLANMA_SURE> GetByFiltreView(bool? IsDurum, DateTime? IsBaslangicT, DateTime? IsOnGorulenBitisT, DateTime? IsBitisT, int? IsKategori,
            int? SorumluCariID, DateTime? BitisZmn, DateTime? BaslangicZmn, int? IsSurec, int? IsSozlesme, bool? Muahsebelestirilsin, AvukatProLib.Extras.Modul? mod, int? DosyaID,
            int? Adliye, int? Gorev, int? No, string EsasNo, int? IsMuhatab, int? IsPlanlayan, string conn)
        {
            AvpDataContext data = new AvpDataContext(conn);
            var predicate = PredicateBuilder.True<AV001_TDI_BIL_IS_TAMAMLANMA_SURE>();
            if (IsDurum.HasValue)
            {
                var isim = data.AV001_TDI_BIL_Is.Where(v => v.DURUM == IsDurum.Value).Select(d => d.ID).ToList();
                predicate = predicate.And(vi => isim.Contains(vi.IS_ID));
            }
            if (IsBaslangicT.HasValue)
            {
                var isim = data.AV001_TDI_BIL_Is.Where(v => v.BASLANGIC_TARIHI == IsBaslangicT.Value).Select(d => d.ID).ToList();
                predicate = predicate.And(vi => isim.Contains(vi.IS_ID));
            }
            if (IsOnGorulenBitisT.HasValue)
            {
                var isim = data.AV001_TDI_BIL_Is.Where(v => v.ONGORULEN_BITIS_TARIHI == IsOnGorulenBitisT.Value).Select(d => d.ID).ToList();
                predicate = predicate.And(vi => isim.Contains(vi.IS_ID));
            }
            if (IsBitisT.HasValue)
            {
                var isim = data.AV001_TDI_BIL_Is.Where(v => v.BITIS_TARIHI == IsBitisT.Value).Select(d => d.ID).ToList();
                predicate = predicate.And(vi => isim.Contains(vi.IS_ID));
            }
            if (IsKategori.HasValue)
            {
                var isim = data.AV001_TDI_BIL_Is.Where(v => v.KATEGORI_ID == IsKategori.Value).Select(d => d.ID).ToList();
                predicate = predicate.And(vi => isim.Contains(vi.IS_ID));
            }
            if (SorumluCariID.HasValue)
            {
                predicate = predicate.And(vi => vi.SORUMLU_CARI_ID == SorumluCariID.Value);
            }
            if (BitisZmn.HasValue)
                predicate = predicate.And(vi => vi.BITIS_ZAMANI == BitisZmn.Value);
            if (BaslangicZmn.HasValue)
                predicate = predicate.And(vi => vi.BASLANGIC_ZAMANI == BaslangicZmn.Value);
            if (IsSurec.HasValue)
                predicate = predicate.And(vi => vi.IS_SUREC_ID == IsSurec);
            if (IsSozlesme.HasValue)
                predicate = predicate.And(vi => vi.IS_SOZLESME_ID == IsSozlesme);
            if (Muahsebelestirilsin.HasValue)
                predicate = predicate.And(vi => vi.MUHASEBELESTILMIS_MI == Muahsebelestirilsin);
            if (mod.HasValue && DosyaID.HasValue)
            {
                switch (mod.Value)
                {
                    case AvukatProLib.Extras.Modul.Icra:
                        var icra = data.NN_IS_ICRA_FOYs.Where(vi => vi.ICRA_FOY_ID == DosyaID).Select(v => v.IS_ID).ToList();
                        predicate = predicate.And(vi => icra.Contains(vi.IS_ID));
                        break;

                    case AvukatProLib.Extras.Modul.Dava:
                        var dava = data.NN_IS_DAVA_FOYs.Where(v => v.DAVA_FOY_ID == DosyaID).Select(v => v.IS_ID).ToList();
                        predicate = predicate.And(vi => dava.Contains(vi.IS_ID));
                        break;

                    case AvukatProLib.Extras.Modul.Sorusturma:
                        var hazirlik = data.NN_IS_HAZIRLIKs.Where(vi => vi.HAZIRLIK_ID == DosyaID).Select(v => v.IS_ID).ToList();
                        predicate = predicate.And(vi => hazirlik.Contains(vi.IS_ID));
                        break;

                    case AvukatProLib.Extras.Modul.Sozlesme:
                        var sozlesme = data.NN_IS_SOZLESMEs.Where(vi => vi.SOZLESME_ID == DosyaID).Select(vi => vi.IS_ID).ToList();
                        predicate = predicate.And(vi => sozlesme.Contains(vi.IS_ID));
                        break;

                    default:
                        break;
                }
            }
            if (Adliye.HasValue)
            {
                var Is = data.AV001_TDI_BIL_Is.Where(vi => vi.ADLI_BIRIM_ADLIYE_ID == Adliye).Select(v => v.ID).ToList();
                predicate = predicate.And(vi => Is.Contains(vi.IS_ID));
            }
            if (Gorev.HasValue)
            {
                var Is = data.AV001_TDI_BIL_Is.Where(vi => vi.ADLI_BIRIM_GOREV_ID == Gorev).Select(vi => vi.ID).ToList();
                predicate = predicate.And(vi => Is.Contains(vi.IS_ID));
            }
            if (No.HasValue)
            {
                var Is = data.AV001_TDI_BIL_Is.Where(vi => vi.ADLI_BIRIM_NO_ID == No).Select(vi => vi.ID).ToList();
                predicate = predicate.And(vi => Is.Contains(vi.IS_ID));
            }
            if (!string.IsNullOrEmpty(EsasNo))
            {
                var Is = data.AV001_TDI_BIL_Is.Where(vi => vi.ESAS_NO.Contains(EsasNo)).Select(vi => vi.ID).ToList();
                predicate = predicate.And(vi => Is.Contains(vi.IS_ID));
            }
            if (IsMuhatab.HasValue)
            {
                var Is = data.AV001_TDI_BIL_IS_TARAFs.Where(vi => vi.CARI_ID == IsMuhatab && vi.IS_TARAF_ID == 1).Select(vi => vi.IS_ID).ToList();
                predicate = predicate.And(vi => Is.Contains(vi.IS_ID));
            }
            if (IsPlanlayan.HasValue)
            {
                var Is = data.AV001_TDI_BIL_IS_TARAFs.Where(vi => vi.CARI_ID == IsPlanlayan && vi.IS_TARAF_ID == 3).Select(vi => vi.IS_ID).ToList();
                predicate = predicate.And(vi => Is.Contains(vi.IS_ID));
            }
            var sonuc = data.AV001_TDI_BIL_IS_TAMAMLANMA_SUREs.Where(predicate).ToList();
            return sonuc;
        }
    }
}