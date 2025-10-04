using System;
using System.Collections.Generic;
using System.Linq;
using AvukatProLib.Arama;

namespace AdimAdimDavaKaydi.Util
{
    public static class ModulArama
    {
        public static List<AvukatProLib.Arama.per_AV001_TD_BIL_FOY> DavaFiltrele(AdimAdimDavaKaydi.Arama.UserControls.AramaProperties aramaList)
        {
            var predicate = AvukatProLib.Arama.PredicateBuilder.True<AvukatProLib.Arama.per_AV001_TD_BIL_FOY>();

            string AramaKriteri = "";

            if (!string.IsNullOrEmpty(aramaList.FoyNo))
            {
                AramaKriteri += string.Format("FOY_NO='%{0}%'", aramaList.FoyNo) + " AND ";
                predicate = predicate.And(item => item.FOY_NO == aramaList.FoyNo);
            }
            if (!string.IsNullOrEmpty(aramaList.EsasNo))
            {
                AramaKriteri += string.Format("ESAS_NO='%{0}%'", aramaList.EsasNo) + " AND ";
                predicate = predicate.And(item => item.ESAS_NO == aramaList.EsasNo);
            }
            if (aramaList.Adliye != null && aramaList.Adliye != 0)
            {
                AramaKriteri += string.Format("ADLI_BIRIM_ADLIYE_ID={0}", aramaList.Adliye) + " AND ";
                predicate = predicate.And(item => item.ADLI_BIRIM_ADLIYE_ID == aramaList.Adliye);
            }
            if (aramaList.AdliBirimGorev != null && aramaList.AdliBirimGorev != 0)
            {
                AramaKriteri += string.Format("ADLI_BIRIM_GOREV_ID={0}", aramaList.AdliBirimGorev) + " AND ";
                predicate = predicate.And(item => item.ADLI_BIRIM_GOREV_ID == aramaList.AdliBirimGorev);
            }
            if (aramaList.Adlibirimno != null && aramaList.Adlibirimno != 0)
            {
                AramaKriteri += string.Format("ADLI_BIRIM_NO_ID={0}", aramaList.Adlibirimno) + " AND ";
                predicate = predicate.And(item => item.ADLI_BIRIM_NO_ID == aramaList.Adlibirimno);
            }
            if (aramaList.Kayittarihi != null && aramaList.Kayittarihi != null)
            {
                AramaKriteri += string.Format("KAYIT_TARIHI BETWEEN {0} AND  {1}", aramaList.Kayittarihi.Value.AddDays(-1), aramaList.Kayittarihi.Value.AddDays(1)) + "AND";
                predicate = predicate.And(item => item.KAYIT_TARIHI > aramaList.Kayittarihi.Value.AddDays(-1) && item.KAYIT_TARIHI < aramaList.Kayittarihi.Value.AddDays(1));
            }
            //if (aramaList.Formtipi != null && aramaList.Formtipi != 0) // Okan Föyde FORM_TIP_ID alanı yok
            //{
            //    AramaKriteri += string.Format("FORM_TIP_ID={0}", aramaList.Formtipi) + " AND ";
            //    predicate = predicate.And(item => item.FORM_TIP_ID == aramaList.Formtipi);
            //}
            if (aramaList.Konu != null && aramaList.Konu != 0)
            {
                AramaKriteri += string.Format("DAVA_TALEP_ID={0}", aramaList.Konu) + " AND ";
                predicate = predicate.And(item => item.DAVA_TALEP_ID == aramaList.Konu);
            }
            if (aramaList.TakipSikayetTarihi != null && aramaList.TakipSikayetTarihi != null)
            {
                AramaKriteri += string.Format("DAVA_TARIHI={0}", aramaList.TakipSikayetTarihi) + "AND";
                predicate = predicate.And(item => item.DAVA_TARIHI == aramaList.TakipSikayetTarihi);
            }
               return BelgeUtil.Inits.context.per_AV001_TD_BIL_FOYs.Where(predicate).ToList();
            return null;
        }
    }
}