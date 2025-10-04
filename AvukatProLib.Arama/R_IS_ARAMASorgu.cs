using System;
using System.Data;

namespace AvukatProLib.Arama
{
    public class R_IS_ARAMASorgu
    {
        //    public static List<AV001_TDI_BIL_I> GetByFiltreView(int? IsKATEGORI_ID, string IsYAPILACAK_IS, int? IsADLI_BIRIM_ADLIYE_ID, int? IsADLI_BIRIM_GOREV_ID, int? IsADLI_BIRIM_NO_ID,
        //int? IsMODUL_ID, bool? IsAJANDADA_GORUNSUN_MU, bool? IsHATIRLATILSIN_MI, int? IsTIP, bool? IsDURUM, DateTime? IsBITIS_TARIHI,
        //DateTime? IsBASLANGIC_TARIHI, DateTime? IsONGORULEN_BITIS_TARIHI, int? IsONGORULEN_BITIS_ZAMANI, string IsYER,
        //string IsKONU, string IsACIKLAMA, int? IsSTATU_ID, int? IsETIKET_ID, int? IsONCELIK_ID, string IsIS_NO, string IsESAS_NO,
        //string IsREFERANS_NO, int? IsKONTROL_KIM_ID, int? IsSUBE_KOD_ID, int? TrfIS_TARAF_CARI_ID, int? TrfIsTIS_TARAF_ID, string con)
        //    {
        //        AvpDataContext data = new AvpDataContext(con);
        //        var predicate = PredicateBuilder.True<AV001_TDI_BIL_I>();

        //        if (IsKATEGORI_ID.HasValue)
        //        {
        //            predicate = predicate.And(vi => vi.KATEGORI_ID == IsKATEGORI_ID);
        //        }
        //        if (!string.IsNullOrEmpty(IsYAPILACAK_IS))
        //        {
        //            predicate = predicate.And(vi => vi.YAPILACAK_IS.Contains(IsYAPILACAK_IS));
        //        }
        //        if (IsADLI_BIRIM_ADLIYE_ID.HasValue)
        //        {
        //            predicate = predicate.And(vi => vi.ADLI_BIRIM_ADLIYE_ID == IsADLI_BIRIM_ADLIYE_ID);
        //        }
        //        if (IsADLI_BIRIM_GOREV_ID.HasValue)
        //        {
        //            predicate = predicate.And(vi => vi.ADLI_BIRIM_GOREV_ID == IsADLI_BIRIM_GOREV_ID);
        //        }
        //        if (IsADLI_BIRIM_NO_ID.HasValue)
        //        {
        //            predicate = predicate.And(vi => vi.ADLI_BIRIM_NO_ID == IsADLI_BIRIM_NO_ID);
        //        }
        //        if (IsMODUL_ID.HasValue)
        //        {
        //            predicate = predicate.And(vi => vi.MODUL_ID == IsMODUL_ID);
        //        }
        //        if (IsAJANDADA_GORUNSUN_MU.HasValue)
        //        {
        //            predicate = predicate.And(vi => vi.AJANDADA_GORUNSUN_MU == IsAJANDADA_GORUNSUN_MU);
        //        }
        //        if (IsHATIRLATILSIN_MI.HasValue)
        //        {
        //            predicate = predicate.And(vi => vi.HATIRLATILSIN_MI == IsHATIRLATILSIN_MI);
        //        }
        //        if (IsTIP.HasValue)
        //        {
        //            predicate = predicate.And(vi => vi.TIP == IsTIP);
        //        }
        //        if (IsDURUM.HasValue)
        //        {
        //            predicate = predicate.And(vi => vi.DURUM == IsDURUM);
        //        }
        //        if (IsBITIS_TARIHI.HasValue)
        //        {
        //            predicate = predicate.And(al => al.BITIS_TARIHI > IsBITIS_TARIHI && al.BITIS_TARIHI < IsBITIS_TARIHI.Value.AddDays(1));
        //        }
        //        if (IsBASLANGIC_TARIHI.HasValue)
        //        {
        //            predicate = predicate.And(al => al.BASLANGIC_TARIHI > IsBASLANGIC_TARIHI && al.BASLANGIC_TARIHI < IsBASLANGIC_TARIHI.Value.AddDays(1));
        //        }
        //        if (IsONGORULEN_BITIS_TARIHI.HasValue)
        //        {
        //            predicate = predicate.And(al => al.ONGORULEN_BITIS_TARIHI > IsONGORULEN_BITIS_TARIHI && al.ONGORULEN_BITIS_TARIHI < IsONGORULEN_BITIS_TARIHI.Value.AddDays(1));
        //        }
        //        if (IsONGORULEN_BITIS_ZAMANI.HasValue)
        //        {
        //            predicate = predicate.And(vi => vi.ONGORULEN_BITIS_ZAMANI == IsONGORULEN_BITIS_ZAMANI);
        //        }
        //        if (!string.IsNullOrEmpty(IsYER))
        //        {
        //            predicate = predicate.And(vi => vi.YER.Contains(IsYER));
        //        }
        //        if (!string.IsNullOrEmpty(IsKONU))
        //        {
        //            predicate = predicate.And(vi => vi.KONU.Contains(IsKONU));
        //        }
        //        if (!string.IsNullOrEmpty(IsACIKLAMA))
        //        {
        //            predicate = predicate.And(vi => vi.ACIKLAMA.Contains(IsACIKLAMA));
        //        }
        //        if (IsSTATU_ID.HasValue)
        //        {
        //            predicate = predicate.And(vi => vi.STATU_ID == IsSTATU_ID);
        //        }
        //        if (IsETIKET_ID.HasValue)
        //        {
        //            predicate = predicate.And(vi => vi.ETIKET_ID == IsETIKET_ID);
        //        }
        //        if (IsONCELIK_ID.HasValue)
        //        {
        //            predicate = predicate.And(vi => vi.ONCELIK_ID == IsONCELIK_ID);
        //        }
        //        if (!string.IsNullOrEmpty(IsIS_NO))
        //        {
        //            predicate = predicate.And(vi => vi.IS_NO.Contains(IsIS_NO));
        //        }
        //        if (!string.IsNullOrEmpty(IsESAS_NO))
        //        {
        //            predicate = predicate.And(vi => vi.ESAS_NO.Contains(IsESAS_NO));
        //        }
        //        if (!string.IsNullOrEmpty(IsREFERANS_NO))
        //        {
        //            predicate = predicate.And(vi => vi.REFERANS_NO.Contains(IsREFERANS_NO));
        //        }
        //        if (IsKONTROL_KIM_ID.HasValue)
        //        {
        //            #region <MB-20100706>

        //            //Kullanıcının, sorumlu olduğu işlerin gelmesi sağlamak için aşağıdaki gibi değiştirildi.
        //            var taraflar = data.AV001_TDI_BIL_IS_TARAFs.Where(vs => vs.CARI_ID == IsKONTROL_KIM_ID.Value && vs.IS_TARAF_ID == 2).Select(i => i.IS_ID).ToList();//İşi Yapacak.
        //            predicate = predicate.And(vi => taraflar.Contains(vi.ID));

        //            #endregion <MB-20100706>
        //        }
        //        if (IsSUBE_KOD_ID.HasValue)
        //        {
        //            predicate = predicate.And(vi => vi.SUBE_KOD_ID == IsSUBE_KOD_ID);
        //        }
        //        if (TrfIS_TARAF_CARI_ID.HasValue)
        //        {
        //            var taraflar = data.AV001_TDI_BIL_IS_TARAFs.Where(vs => vs.CARI_ID == TrfIS_TARAF_CARI_ID.Value);
        //            var Isler = taraflar.Select(I => I.IS_ID).ToList();
        //            predicate = predicate.And(vi => Isler.Contains(vi.ID));
        //        }
        //        if (TrfIsTIS_TARAF_ID.HasValue)
        //        {
        //            var taraflar = data.AV001_TDI_BIL_IS_TARAFs.Where(vs => vs.IS_TARAF_ID == TrfIsTIS_TARAF_ID.Value);
        //            var Isler = taraflar.Select(I => I.IS_ID).ToList();
        //            predicate = predicate.And(vi => Isler.Contains(vi.ID));
        //        }
        //        var sonuc = data.AV001_TDI_BIL_Is.Where(predicate).ToList();
        //        return sonuc;
        //    }

        public static DataTable GetByFiltreView(int? IsKATEGORI_ID, string IsYAPILACAK_IS, int? IsADLI_BIRIM_ADLIYE_ID, int? IsADLI_BIRIM_GOREV_ID, int? IsADLI_BIRIM_NO_ID, int? IsMODUL_ID, bool? IsAJANDADA_GORUNSUN_MU, bool? IsHATIRLATILSIN_MI, int? IsTIP, int? IsDURUM, DateTime? IsBITIS_TARIHI, DateTime? IsBASLANGIC_TARIHI, DateTime? IsONGORULEN_BITIS_TARIHI, int? IsONGORULEN_BITIS_ZAMANI, string IsYER, string IsKONU, string IsACIKLAMA, int? IsSTATU_ID, int? IsETIKET_ID, int? IsONCELIK_ID, string IsIS_NO, string IsESAS_NO, string IsREFERANS_NO, int? IsKONTROL_KIM_ID, int? IsSUBE_KOD_ID, int? TrfIS_TARAF_CARI_ID, int? TrfIsTIS_TARAF_ID, string con, string ZamanDilimi)
        {
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            DataTable sonuc = new DataTable();
            string where = " where a.ID<>-1";

            //AvpDataContext data = new AvpDataContext(con);
            //var predicate = PredicateBuilder.True<AV001_TDI_BIL_I>();

            if (IsKATEGORI_ID.HasValue)
            {
                cn.AddParams("@KATEGORI_ID", IsKATEGORI_ID);
                where += " and a.KATEGORI_ID=@KATEGORI_ID";
            }
            if (!string.IsNullOrEmpty(IsYAPILACAK_IS))
            {
                cn.AddParams("@YAPILACAK_IS", IsYAPILACAK_IS);
                where += " and a.YAPILACAK_IS like '%' + @YAPILACAK_IS + '%'";
            }
            if (IsADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                cn.AddParams("@ADLI_BIRIM_ADLIYE_ID", IsADLI_BIRIM_ADLIYE_ID);
                where += " and a.ADLI_BIRIM_ADLIYE_ID=@ADLI_BIRIM_ADLIYE_ID";
            }
            if (IsADLI_BIRIM_GOREV_ID.HasValue)
            {
                cn.AddParams("@ADLI_BIRIM_GOREV_ID", IsADLI_BIRIM_GOREV_ID);
                where += " and a.ADLI_BIRIM_GOREV_ID=@ADLI_BIRIM_GOREV_ID";
            }
            if (IsADLI_BIRIM_NO_ID.HasValue)
            {
                cn.AddParams("@ADLI_BIRIM_NO_ID", IsADLI_BIRIM_NO_ID);
                where += " and a.ADLI_BIRIM_NO_ID=@ADLI_BIRIM_NO_ID";
            }
            if (IsMODUL_ID.HasValue)
            {
                cn.AddParams("@MODUL_ID", IsMODUL_ID);
                where += " and a.MODUL_ID=@MODUL_ID";
            }
            if (IsAJANDADA_GORUNSUN_MU.HasValue)
            {
                cn.AddParams("@AJANDADA_GORUNSUN_MU", IsAJANDADA_GORUNSUN_MU);
                where += " and a.AJANDADA_GORUNSUN_MU=@AJANDADA_GORUNSUN_MU";
            }
            if (IsHATIRLATILSIN_MI.HasValue)
            {
                cn.AddParams("@HATIRLATILSIN_MI", IsHATIRLATILSIN_MI);
                where += " and a.HATIRLATILSIN_MI=@HATIRLATILSIN_MI";
            }
            if (IsTIP.HasValue)
            {
                cn.AddParams("@TIP", IsTIP);
                where += " and a.TIP=@TIP";
            }
            if (IsDURUM.Value != 2)
            {
                cn.AddParams("@DURUM", IsDURUM);
                where += " and a.DURUM=@DURUM";
            }
            if (IsBITIS_TARIHI.HasValue)
            {
                cn.AddParams("@BITIS_TARIHI", IsBITIS_TARIHI);
                cn.AddParams("@BITIS_TARIHI2", IsBITIS_TARIHI.Value.AddDays(1));
                where += " and a.BITIS_TARIHI>@BITIS_TARIHI and a.BITIS_TARIHI<@BITIS_TARIHI2";
            }
            if (IsBASLANGIC_TARIHI.HasValue)
            {
                cn.AddParams("@BASLANGIC_TARIHI", IsBASLANGIC_TARIHI);
                cn.AddParams("@BASLANGIC_TARIHI2", IsBASLANGIC_TARIHI.Value.AddDays(1));
                where += " and a.BASLANGIC_TARIHI>@BASLANGIC_TARIHI and a.BASLANGIC_TARIHI<@BASLANGIC_TARIHI2";
            }
            if (IsONGORULEN_BITIS_TARIHI.HasValue)
            {
                cn.AddParams("@ONGORULEN_BITIS_TARIHI", IsONGORULEN_BITIS_TARIHI);
                cn.AddParams("@ONGORULEN_BITIS_TARIHI2", IsONGORULEN_BITIS_TARIHI.Value.AddDays(1));
                where += " and a.ONGORULEN_BITIS_TARIHI>@ONGORULEN_BITIS_TARIHI and a.ONGORULEN_BITIS_TARIHI<@ONGORULEN_BITIS_TARIHI2";
            }
            if (IsONGORULEN_BITIS_ZAMANI.HasValue)
            {
                cn.AddParams("@ONGORULEN_BITIS_ZAMANI", IsONGORULEN_BITIS_ZAMANI);
                where += " and a.ONGORULEN_BITIS_ZAMANI=@ONGORULEN_BITIS_ZAMANI";
            }
            if (!string.IsNullOrEmpty(IsYER))
            {
                cn.AddParams("@YER", IsYER);
                where += " and a.YER like '%' + @YER + '%'";
            }
            if (!string.IsNullOrEmpty(IsKONU))
            {
                cn.AddParams("@KONU", IsKONU);
                where += " and a.KONU like '%' + @KONU + '%'";
            }
            if (!string.IsNullOrEmpty(IsACIKLAMA))
            {
                cn.AddParams("@ACIKLAMA", IsACIKLAMA);
                where += " and a.ACIKLAMA like '%' + @ACIKLAMA + '%'";
            }
            if (IsSTATU_ID.HasValue)
            {
                cn.AddParams("@STATU_ID", IsSTATU_ID);
                where += " and a.STATU_ID=@STATU_ID";
            }
            if (IsETIKET_ID.HasValue)
            {
                cn.AddParams("@ETIKET_ID", IsETIKET_ID);
                where += " and a.ETIKET_ID=@ETIKET_ID";
            }
            if (IsONCELIK_ID.HasValue)
            {
                cn.AddParams("@ONCELIK_ID", IsONCELIK_ID);
                where += " and a.ONCELIK_ID=@ONCELIK_ID";
            }
            if (!string.IsNullOrEmpty(IsIS_NO))
            {
                cn.AddParams("@IS_NO", IsIS_NO);
                where += " and a.IS_NO like '%' + @IS_NO + '%'";
            }
            if (!string.IsNullOrEmpty(IsESAS_NO))
            {
                cn.AddParams("@ESAS_NO", IsESAS_NO);
                where += " and a.ESAS_NO like '%' + @ESAS_NO + '%'";
            }
            if (!string.IsNullOrEmpty(IsREFERANS_NO))
            {
                cn.AddParams("@REFERANS_NO", IsREFERANS_NO);
                where += " and a.REFERANS_NO like '%' + @REFERANS_NO + '%'";
            }
            if (IsKONTROL_KIM_ID.HasValue)
            {
                cn.AddParams("@KONTROL_KIM_ID", IsKONTROL_KIM_ID.Value);
                where += " and a.ID IN (SELECT IS_ID FROM dbo.AV001_TDI_BIL_IS_TARAF(nolock) t WHERE t.CARI_ID=@KONTROL_KIM_ID and t.IS_TARAF_ID=2)";
            }

            if (TrfIS_TARAF_CARI_ID.HasValue)
            {
                cn.AddParams("@CARI_ID", TrfIS_TARAF_CARI_ID.Value);
                where += " and a.ID IN (SELECT IS_ID FROM dbo.AV001_TDI_BIL_IS_TARAF(nolock) t WHERE t.CARI_ID=@CARI_ID)";
            }

            if (!IsBASLANGIC_TARIHI.HasValue)
            {
                if (ZamanDilimi != "Tumu")
                    where += Metotlar.ZamanDilimiParametresiOlustur(cn, "BASLANGIC_TARIHI", ZamanDilimi).Replace(" BASLANGIC_TARIHI", " a.BASLANGIC_TARIHI");
            }

            sonuc = cn.GetDataTable("SELECT a.ID, a.DURUM, b.IS_ONCELIK, c.ALT_KATEGORI AS KATEGORI, d.ADLIYE AS ADLI_BIRIM_ADLIYE, f.[NO] AS BIRIM_NO, e.ACIKLAMA AS ADLI_BIRIM_GOREV, a.ESAS_NO, a.KONU, a.YER, a.ACIKLAMA, a.REFERANS_NO, (SELECT top(1)y.AD FROM dbo.AV001_TDI_BIL_IS_TARAF(nolock) x INNER JOIN dbo.AV001_TDI_BIL_CARI(nolock) y ON y.ID=x.CARI_ID WHERE x.IS_ID=a.ID AND x.IS_TARAF_ID=1) AS ISI_VEREN, (SELECT top(1)y.AD FROM dbo.AV001_TDI_BIL_IS_TARAF(nolock) x INNER JOIN dbo.AV001_TDI_BIL_CARI(nolock) y ON y.ID=x.CARI_ID WHERE x.IS_ID=a.ID AND x.IS_TARAF_ID=1) AS IS_MUHATABI, (SELECT top(1)y.AD FROM dbo.AV001_TDI_BIL_IS_TARAF(nolock) x INNER JOIN dbo.AV001_TDI_BIL_CARI(nolock) y ON y.ID=x.CARI_ID WHERE x.IS_ID=a.ID AND x.IS_TARAF_ID=2) AS ISI_YAPACAK, a.YAPILACAK_IS, a.BITIS_TARIHI, a.BASLANGIC_TARIHI, a.ONGORULEN_BITIS_TARIHI,CASE WHEN a.BITIS_TARIHI IS NULL THEN 0 else 1 END AS TAMAMLANDI, CASE WHEN a.SUBE_KOD_ID IS NULL THEN 'MERKEZ' else g.SUBE_ADI END AS SUBE_ADI, h.KULLANICI_ADI, a.HATIRLATMA_BILGISI, a.STAMP FROM dbo.AV001_TDI_BIL_IS(nolock) a left JOIN dbo.TDI_KOD_IS_ONCELIK(nolock) b ON b.ID=a.ONCELIK_ID LEFT JOIN dbo.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI(nolock) c ON c.ID=a.KATEGORI_ID LEFT JOIN dbo.TDI_KOD_ADLI_BIRIM_ADLIYE(NOLOCK) d ON d.ID=a.ADLI_BIRIM_ADLIYE_ID LEFT JOIN dbo.TDI_KOD_ADLI_BIRIM_GOREV(nolock) e ON e.ID=a.ADLI_BIRIM_GOREV_ID LEFT JOIN dbo.TDI_KOD_ADLI_BIRIM_NO(nolock) f ON f.ID=a.ADLI_BIRIM_NO_ID LEFT JOIN dbo.TDIE_BIL_KULLANICI_SUBELERI(NOLOCK) g ON g.ID=a.SUBE_KOD_ID LEFT JOIN dbo.TDI_BIL_KULLANICI_LISTESI(nolock) h ON h.ID=a.KONTROL_KIM_ID" + where);
            return sonuc;
        }
    }
}