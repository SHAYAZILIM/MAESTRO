using System;
using System.Collections.Generic;
using System.Linq;

namespace AvukatProLib.Arama
{
    public partial class per_TDI_BIL_BORCLU_MALArama
    {
        public static AvpDataContext data = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        public static List<per_TDI_BIL_BORCLU_MAL> GetByFilterView(int? MAL_SIRA_NO, int? HACIZLI_MAL_KATEGORI_ID, int? HACIZLI_MAL_TUR_ID, int? HACIZLI_MAL_CINS_ID,
                                                                                       string ARAC_PLAKA_NO, decimal? HACIZLI_MAL_DEGERI, int? HACIZLI_MAL_DEGERI_DOVIZ_ID, int? YEDIEMIN_CARI_ID, string MAL_ADRES,
                                                                                       int? CARI_ID, int? ADLI_BIRIM_ADLIYE_ID, int? ADLI_BIRIM_GOREV_ID,
                                                                                       int? ADLI_BIRIM_NO_ID, string ESAS_NO)
        {
            var predicate = PredicateBuilder.True<per_TDI_BIL_BORCLU_MAL>();

            if (MAL_SIRA_NO.HasValue)
            {
                predicate = predicate.And(vi => vi.MAL_SIRA_NO == MAL_SIRA_NO);
            }
            if (HACIZLI_MAL_KATEGORI_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.HACIZLI_MAL_KATEGORI_ID == HACIZLI_MAL_KATEGORI_ID);
            }
            if (HACIZLI_MAL_TUR_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.HACIZLI_MAL_TUR_ID == HACIZLI_MAL_TUR_ID);
            }
            if (HACIZLI_MAL_CINS_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.HACIZLI_MAL_CINS_ID == HACIZLI_MAL_CINS_ID);
            }
            if (!String.IsNullOrEmpty(ARAC_PLAKA_NO))
            {
                predicate = predicate.And(vi => vi.ARAC_PLAKA_NO == ARAC_PLAKA_NO);
            }
            if (HACIZLI_MAL_DEGERI.HasValue)
            {
                predicate = predicate.And(vi => vi.HACIZLI_MAL_DEGERI == HACIZLI_MAL_DEGERI);
            }
            if (HACIZLI_MAL_DEGERI_DOVIZ_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.HACIZLI_MAL_DEGERI_DOVIZ_ID == HACIZLI_MAL_DEGERI_DOVIZ_ID);
            }
            if (YEDIEMIN_CARI_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.YEDIEMIN_CARI_ID == YEDIEMIN_CARI_ID);
            }
            if (!String.IsNullOrEmpty(MAL_ADRES))
            {
                predicate = predicate.And(vi => vi.MAL_ADRES == MAL_ADRES);
            }
            if (CARI_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.CARI_ID == CARI_ID);
            }
            if (ADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.ADLI_BIRIM_ADLIYE_ID == ADLI_BIRIM_ADLIYE_ID);
            }
            if (ADLI_BIRIM_GOREV_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.ADLI_BIRIM_GOREV_ID == ADLI_BIRIM_GOREV_ID);
            }
            if (ADLI_BIRIM_NO_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.ADLI_BIRIM_NO_ID == ADLI_BIRIM_NO_ID);
            }
            if (!String.IsNullOrEmpty(ESAS_NO))
            {
                predicate = predicate.And(vi => vi.ESAS_NO == ESAS_NO);
            }

            try
            {
                List<per_TDI_BIL_BORCLU_MAL> sonuc = new List<per_TDI_BIL_BORCLU_MAL>();
                return sonuc = data.per_TDI_BIL_BORCLU_MALs.Where(predicate).ToList();
            }
            catch
            {
                return null;
            }

        }
    }
}