using System;
using System.Collections.Generic;
using System.Linq;

namespace AvukatProLib.Arama
{
    public partial class per_TI_BIL_HACIZ_MASTER_MINIArama
    {
        public static AvpDataContext data = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        public static List<per_TI_BIL_HACIZ_MASTER_MINI> GetByFilterView(DateTime? HACIZ_TARIHI, int? HACIZ_SIRA_NO, bool? BAKIYE_HACIZI_MI, bool? TALIMAT_MI, int? HACIZ_ISTEYEN_CARI_ID, int? HACIZ_ISTENEN_CARI_ID, int? TALIMAT_ADLI_BIRIM_ADLIYE_ID, int? TALIMAT_ADLI_BIRIM_GOREV_ID, int? TALIMAT_ADLI_BIRIM_NO_ID, string TALIMAT_ESAS_NO, DateTime? HACIZ_TALEP_TARIHI, bool? GECICI_HACIZ_MI, byte? HACIZ_KAYNAGI, string ICRA_TUTANAK_NO, int? HACIZ_MEMURU_CARI_ID, int? HACIZ_SORUMLU_PERSONEL_ID, bool? SEHIR_DISI_MI, string HACIZ_ADRESI, decimal? HACIZ_TOPLAM_DEGERI, int? HACIZ_TOPLAM_DEGERI_DOVIZ_ID, bool? HACIZ_EDILECEK_MAL_VAR)
        {
            var predicate = PredicateBuilder.True<per_TI_BIL_HACIZ_MASTER_MINI>();

            if (HACIZ_TARIHI.HasValue)
            {
                predicate = predicate.And(vi => vi.HACIZ_TARIHI == HACIZ_TARIHI.Value);
            }
            if (HACIZ_SIRA_NO.HasValue)
            {
                predicate = predicate.And(vi => vi.HACIZ_SIRA_NO == HACIZ_SIRA_NO.Value);
            }
            if (BAKIYE_HACIZI_MI.HasValue)
            {
                predicate = predicate.And(vi => vi.BAKIYE_HACIZI_MI == BAKIYE_HACIZI_MI.Value);
            }
            if (TALIMAT_MI.HasValue)
            {
                predicate = predicate.And(vi => vi.TALIMAT_MI == TALIMAT_MI.Value);
            }
            if (HACIZ_ISTEYEN_CARI_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.HACIZ_ISTENEN_CARI_ID == HACIZ_ISTEYEN_CARI_ID);
            }
            if (HACIZ_ISTENEN_CARI_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.HACIZ_ISTENEN_CARI_ID == HACIZ_ISTENEN_CARI_ID);
            }
            if (TALIMAT_ADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.TALIMAT_ADLI_BIRIM_ADLIYE_ID == TALIMAT_ADLI_BIRIM_ADLIYE_ID);
            }
            if (TALIMAT_ADLI_BIRIM_GOREV_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.TALIMAT_ADLI_BIRIM_GOREV_ID == TALIMAT_ADLI_BIRIM_GOREV_ID);
            }
            if (TALIMAT_ADLI_BIRIM_NO_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.TALIMAT_ADLI_BIRIM_NO_ID == TALIMAT_ADLI_BIRIM_NO_ID);
            }

            if (!String.IsNullOrEmpty(TALIMAT_ESAS_NO))
            {
                predicate = predicate.And(vi => vi.TALIMAT_ESAS_NO == TALIMAT_ESAS_NO);
            }
            if (HACIZ_TALEP_TARIHI.HasValue)
            {
                predicate = predicate.And(vi => vi.HACIZ_TALEP_TARIHI == HACIZ_TALEP_TARIHI.Value);
            }
            if (GECICI_HACIZ_MI.HasValue)
            {
                predicate = predicate.And(vi => vi.GECICI_HACIZ_MI == GECICI_HACIZ_MI.Value);
            }
            if (HACIZ_KAYNAGI.HasValue)
            {
                predicate = predicate.And(vi => vi.HACIZ_KAYNAGI_ID == HACIZ_KAYNAGI.Value);
            }
            if (!String.IsNullOrEmpty(ICRA_TUTANAK_NO))
            {
                predicate = predicate.And(vi => vi.ICRA_TUTANAK_NO == ICRA_TUTANAK_NO);
            }
            if (HACIZ_MEMURU_CARI_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.HACIZ_MEMURU_CARI_ID == HACIZ_MEMURU_CARI_ID.Value);
            }
            if (SEHIR_DISI_MI.HasValue)
            {
                predicate = predicate.And(vi => vi.SEHIR_DISI_MI == SEHIR_DISI_MI.Value);
            }
            if (!String.IsNullOrEmpty(HACIZ_ADRESI))
            {
                predicate = predicate.And(vi => vi.HACIZ_ADRESI == HACIZ_ADRESI);
            }
            if (HACIZ_TOPLAM_DEGERI.HasValue)
            {
                predicate = predicate.And(vi => vi.HACIZ_TOPLAM_DEGERI == HACIZ_TOPLAM_DEGERI.Value);
            }
            if (HACIZ_TOPLAM_DEGERI_DOVIZ_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.HACIZ_TOPLAM_DEGERI_DOVIZ_ID == HACIZ_TOPLAM_DEGERI_DOVIZ_ID.Value);
            }
            if (HACIZ_EDILECEK_MAL_VAR.HasValue)
            {
                predicate = predicate.And(vi => vi.HACIZ_EDILECEK_MAL_VAR == HACIZ_EDILECEK_MAL_VAR.Value);
            }

            try
            {
                List<per_TI_BIL_HACIZ_MASTER_MINI> sonuc = new List<per_TI_BIL_HACIZ_MASTER_MINI>();
                return sonuc = data.per_TI_BIL_HACIZ_MASTER_MINIs.Where(predicate).ToList();
            }
            catch
            {
                return null;
            }

        }
    }
}