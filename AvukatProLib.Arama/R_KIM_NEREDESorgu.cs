using System;
using System.Collections.Generic;
using System.Linq;

namespace AvukatProLib.Arama
{
    public class R_KIM_NEREDESorgu
    {
        public static List<AV001_TDIE_BIL_KIM_NEREDE> GetByFiltre(int? personelID, DateTime? gidisTarihi, DateTime? donusTarihi, bool? donduMu, int? adliyeID, string aciklama, string con)
        {
            AvpDataContext data = new AvpDataContext(con);
            var predicate = PredicateBuilder.True<AV001_TDIE_BIL_KIM_NEREDE>();

            if (personelID.HasValue)
                predicate = predicate.And(vi => vi.PERSONEL_ID == personelID);
            if (gidisTarihi.HasValue)
                predicate = predicate.And(vi => vi.BULUNMA_BASLANGIC_TARIHI_SAATI >= gidisTarihi && vi.BULUNMA_BASLANGIC_TARIHI_SAATI < gidisTarihi.Value.AddDays(1));
            if (donusTarihi.HasValue)
                predicate = predicate.And(vi => vi.DONUS_BASLANGIC_TARIHI_SAATI >= donusTarihi && vi.DONUS_BASLANGIC_TARIHI_SAATI < donusTarihi.Value.AddDays(1));
            if (donduMu.HasValue)
                predicate = predicate.And(vi => vi.DONULDU_MU == donduMu);
            if (adliyeID.HasValue)
                predicate = predicate.And(vi => vi.ADLI_BIRIM_ADLIYE_ID == adliyeID);
            if (!string.IsNullOrEmpty(aciklama))
                predicate = predicate.And(vi => vi.ISIN_ACIKLAMASI.Contains(aciklama));

            var KimNerede = data.AV001_TDIE_BIL_KIM_NEREDEs.Where(predicate).ToList();

            return KimNerede;
        }
    }
}