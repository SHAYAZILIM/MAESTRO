using System;
using System.Collections.Generic;
using System.Linq;

namespace AvukatProLib.Arama
{
    public class per_DAVA_HIZLI_ARAMA_Sorgu
    {
        public static AvpDataContext data = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        public static List<per_DAVA_HIZLI_ARAMA> GetByFiltreView(int? ID, string FOY_NO, string ESAS_NO, DateTime? DAVA_TARIHI, string ACIKLAMA, DateTime? KAYIT_TARIHI, int? ADLIYE_ID, int? GOREV_ID, int? BIRIM_NO_ID, int? DAVA_TALEP_ID, int? FOY_DURUM_ID, int? TARAF_ID, int? SORUMLU_ID, int? DAVA_TIPI_ID, int? SUBE_KOD_ID)
        {
            var predicate = PredicateBuilder.True<per_DAVA_HIZLI_ARAMA>();

            if (ID.HasValue)
            {
                predicate = predicate.And(vi => vi.ID == ID.Value);
            }
            if (!String.IsNullOrEmpty(FOY_NO))
            {
                predicate = predicate.And(vi => vi.FOY_NO.Contains(FOY_NO));
            }
            if (!String.IsNullOrEmpty(ESAS_NO))
            {
                predicate = predicate.And(vi => vi.ESAS_NO.Contains(ESAS_NO));
            }
            if (DAVA_TARIHI.HasValue)
            {
                predicate = predicate.And(vi => vi.DAVA_TARIHI.Value.Date == DAVA_TARIHI.Value.Date);
            }
            if (!String.IsNullOrEmpty(ACIKLAMA))
            {
                predicate = predicate.And(vi => vi.ACIKLAMA == ACIKLAMA);
            }
            if (KAYIT_TARIHI.HasValue)
            {
                predicate = predicate.And(vi => vi.KAYIT_TARIHI.Date == KAYIT_TARIHI.Value.Date);
            }
            if (ADLIYE_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.ADLI_BIRIM_ADLIYE_ID == ADLIYE_ID.Value);
            }
            if (GOREV_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.ADLI_BIRIM_GOREV_ID == GOREV_ID.Value);
            }
            if (BIRIM_NO_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.ADLI_BIRIM_NO_ID == BIRIM_NO_ID.Value);
            }
            if (DAVA_TALEP_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.DAVA_TALEP_ID == DAVA_TALEP_ID.Value);
            }
            if (FOY_DURUM_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.FOY_DURUM_ID == FOY_DURUM_ID.Value);
            }
            if (TARAF_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.CARI_ID == TARAF_ID.Value);
            }
            if (SORUMLU_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.SORUMLU_AVUKAT_CARI_ID == SORUMLU_ID.Value);
            }
            if (DAVA_TIPI_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.DAVA_TIP_ID == DAVA_TIPI_ID.Value);
            }
            if (SUBE_KOD_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.SUBE_KOD_ID == SUBE_KOD_ID.Value);
            }
            return data.per_DAVA_HIZLI_ARAMAs.Where(predicate).ToList();
        }
    }
}