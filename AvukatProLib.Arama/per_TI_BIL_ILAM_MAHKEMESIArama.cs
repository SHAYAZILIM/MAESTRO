using System;
using System.Collections.Generic;
using System.Linq;

namespace AvukatProLib.Arama
{
    public class per_TI_BIL_ILAM_MAHKEMESIArama
    {
        public static AvpDataContext data = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        public static List<per_TI_BIL_ILAM_MAHKEMESI> GetByFilterView(int? ADLI_BIRIM_ADLIYE_ID, int? ADLI_BIRIM_GOREV_ID, int? ADLI_BIRIM_NO_ID, string ESAS_NO, DateTime? KARAR_TARIHI, DateTime? KARAR_KESINLESME_TARIHI, DateTime? KARAR_BOZULMA_TARIHI, int? ILAM_TIP_ID, DateTime? ILAM_DAVA_TARIHI)
        {
            var predicate = PredicateBuilder.True<per_TI_BIL_ILAM_MAHKEMESI>();

            if (ADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.ILAM_ADLI_BIRIM_ADLIYE_ID == ADLI_BIRIM_ADLIYE_ID);
            }
            if (ADLI_BIRIM_GOREV_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.ILAM_ADLI_BIRIM_GOREV_ID == ADLI_BIRIM_GOREV_ID);
            }
            if (ADLI_BIRIM_NO_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.ILAM_ADLI_BIRIM_NO_ID == ADLI_BIRIM_NO_ID);
            }

            if (!String.IsNullOrEmpty(ESAS_NO))
            {
                predicate = predicate.And(vi => vi.ILAM_ESAS_NO == ESAS_NO);
            }
            if (KARAR_TARIHI.HasValue)
            {
                predicate = predicate.And(vi => vi.KARAR_TARIHI == KARAR_TARIHI);
            }
            if (KARAR_KESINLESME_TARIHI.HasValue)
            {
                predicate = predicate.And(vi => vi.KARAR_KESINLESME_TARIHI == KARAR_KESINLESME_TARIHI);
            }
            if (KARAR_BOZULMA_TARIHI.HasValue)
            {
                predicate = predicate.And(vi => vi.KARAR_BOZULMA_TARIHI == KARAR_BOZULMA_TARIHI);
            }
            if (ILAM_TIP_ID.HasValue)
            {
                predicate = predicate.And(vi => vi.ILAM_TIP_ID == ILAM_TIP_ID);
            }
            if (ILAM_DAVA_TARIHI.HasValue)
            {
                predicate = predicate.And(vi => vi.ILAM_DAVA_TARIHI == ILAM_DAVA_TARIHI);
            }

            try
            {
                List<per_TI_BIL_ILAM_MAHKEMESI> sonuc = new List<per_TI_BIL_ILAM_MAHKEMESI>();
                return sonuc = data.per_TI_BIL_ILAM_MAHKEMESIs.Where(predicate).ToList();
            }
            catch
            {
                return null;
            }

        }
    }
}