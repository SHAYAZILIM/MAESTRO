using System;
using System.Data;
using System.Linq;

namespace AvukatProLib.Arama
{
    public partial class per_AV001_TDIE_BIL_PROJE
    {
        public static AvpDataContext data = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        public bool IsSelected { get; set; }

        //public static List<per_AV001_TDIE_BIL_PROJE> GetByFiltre(object klasorKodu, object klasorAdi, object baslangicT, object bitisT, object projeDurumID, object projeOzelKod1, object projeTipID, object durumID)
        //{
        //    var predicate = PredicateBuilder.True<per_AV001_TDIE_BIL_PROJE>();

        //    if (klasorKodu != null)
        //        predicate = predicate.And(vi => vi.KOD.Contains(klasorKodu.ToString()));
        //    if (klasorAdi != null)
        //        predicate = predicate.And(vi => vi.ADI.Contains(klasorAdi.ToString()));
        //    if (baslangicT != null)
        //        predicate = predicate.And(vi => vi.BASLANGIC_TARIHI >= ((DateTime?)baslangicT).Value && vi.BASLANGIC_TARIHI < ((DateTime?)baslangicT).Value.AddDays(1));
        //    if (bitisT != null)
        //        predicate = predicate.And(vi => vi.BASLANGIC_TARIHI >= ((DateTime?)bitisT).Value && vi.BASLANGIC_TARIHI < ((DateTime?)bitisT).Value.AddDays(1));
        //    if (projeDurumID != null)
        //        predicate = predicate.And(vi => vi.PROJE_DURUM_ID == (int)projeDurumID);
        //    if (projeOzelKod1 != null)
        //        predicate = predicate.And(vi => vi.OZEL_KOD1_ID == (int?)projeOzelKod1);
        //    if (projeTipID != null)
        //        predicate = predicate.And(vi => vi.PROJE_TIP_ID == (int?)projeTipID);
        //    if (durumID != null)
        //        predicate = predicate.And(vi => vi.DURUM_ID == (int?)durumID);

        //    try
        //    {
        //        List<per_AV001_TDIE_BIL_PROJE> sonuc = new List<per_AV001_TDIE_BIL_PROJE>();
        //        return sonuc = data.per_AV001_TDIE_BIL_PROJEs.Where(predicate).ToList();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        public static DataTable GetByFiltre(object klasorKodu, object klasorAdi, object baslangicT, object bitisT, object projeDurumID, object subeID, object projeTipID, object durumID, object AlacakliCariID, object BorcluCariID, object OzelKod1, object OzelKod2, object OzelKod3, object OzelKod4, object Ref1, object Ref2, object Ref3)
        {
            DataTable dt = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            string where = " where a.ID<>-1";

            if (klasorKodu != null)
            {
                if (!string.IsNullOrEmpty(klasorKodu.ToString()))
                {
                    where += " and KOD like '%' + @KOD + '%'";
                    cn.AddParams("@KOD", klasorKodu.ToString());
                }
            }

            if (klasorAdi != null)
            {
                if (!string.IsNullOrEmpty(klasorAdi.ToString()))
                {
                    where += " and ADI like '%' + @ADI + '%'";
                    cn.AddParams("@ADI", klasorAdi.ToString());
                }
            }

            if (baslangicT != null)
            {
                where += " and BASLANGIC_TARIHI >= @BASLANGIC_TARIHI and BASLANGIC_TARIHI < @BASLANGIC_TARIHI2";
                cn.AddParams("@BASLANGIC_TARIHI", ((DateTime?)baslangicT).Value);
                cn.AddParams("@BASLANGIC_TARIHI2", ((DateTime?)baslangicT).Value.AddDays(1));
            }

            if (bitisT != null)
            {
                where += " and BITIS_TARIHI >= @BITIS_TARIHI and BITIS_TARIHI < @BITIS_TARIHI2";
                cn.AddParams("@BITIS_TARIHI", ((DateTime?)bitisT).Value);
                cn.AddParams("@BITIS_TARIHI2", ((DateTime?)bitisT).Value.AddDays(1));
            }

            if (projeDurumID != null)
            {
                where += " and PROJE_DURUM_ID=@PROJE_DURUM_ID";
                cn.AddParams("@PROJE_DURUM_ID", (int)projeDurumID);
            }

            if (subeID != null)
            {
                where += " and SubeID=@SubeID";
                cn.AddParams("@SubeID", (int)subeID);
            }

            if (projeTipID != null)
            {
                where += " and PROJE_TIP_ID=@PROJE_TIP_ID";
                cn.AddParams("@PROJE_TIP_ID", (int)projeTipID);
            }

            if (durumID != null)
            {
                where += " and DURUM_ID=@DURUM_ID";
                cn.AddParams("@DURUM_ID", (int)durumID);
            }

            if (AlacakliCariID != null)
            {
                if (!string.IsNullOrEmpty(AlacakliCariID.ToString()))
                {
                    where += " and ID IN (select PROJE_ID from dbo.AV001_TI_BIL_ALACAK_NEDEN_TARAF(nolock) a inner join dbo.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN(nolock) x on x.ALACAK_NEDEN_ID=a.ICRA_ALACAK_NEDEN_ID where a.TARAF_SIFAT_ID=1 and a.TARAF_CARI_ID=@ALACAKLIID)";
                    cn.AddParams("@ALACAKLIID", (int)AlacakliCariID);
                }
            }

            if (BorcluCariID != null)
            {
                if (!string.IsNullOrEmpty(BorcluCariID.ToString()))
                {
                    where += " and ID IN (select PROJE_ID from dbo.AV001_TI_BIL_ALACAK_NEDEN_TARAF(nolock) a inner join dbo.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN(nolock) x on x.ALACAK_NEDEN_ID=a.ICRA_ALACAK_NEDEN_ID where a.TARAF_SIFAT_ID=2 and a.TARAF_CARI_ID=@BORCLUID)";
                    cn.AddParams("@BORCLUID", (int)BorcluCariID);
                }
            }

            if (OzelKod1 != null)
            {
                where += " and OZEL_KOD1_ID=@OZEL_KOD1_ID";
                cn.AddParams("@OZEL_KOD1_ID", (int)OzelKod1);
            }

            if (OzelKod2 != null)
            {
                where += " and OZEL_KOD2_ID=@OZEL_KOD2_ID";
                cn.AddParams("@OZEL_KOD2_ID", (int)OzelKod2);
            }

            if (OzelKod3 != null)
            {
                where += " and OZEL_KOD3_ID=@OZEL_KOD3_ID";
                cn.AddParams("@OZEL_KOD3_ID", (int)OzelKod3);
            }

            if (OzelKod4 != null)
            {
                where += " and OZEL_KOD4_ID=@OZEL_KOD4_ID";
                cn.AddParams("@OZEL_KOD4_ID", (int)OzelKod4);
            }

            if (Ref1 != null)
            {
                if (!string.IsNullOrEmpty(Ref1.ToString()))
                {
                    where += " and REFERANS_NO1 like '%' + @REFERANS_NO1 + '%'";
                    cn.AddParams("@REFERANS_NO1", Ref1.ToString());
                }
            }

            if (Ref2 != null)
            {
                if (!string.IsNullOrEmpty(Ref2.ToString()))
                {
                    where += " and REFERANS_NO2 like '%' + @REFERANS_NO2 + '%'";
                    cn.AddParams("@REFERANS_NO2", Ref2.ToString());
                }
            }

            if (Ref3 != null)
            {
                if (!string.IsNullOrEmpty(Ref3.ToString()))
                {
                    where += " and REFERANS_NO3 like '%' + @REFERANS_NO3 + '%'";
                    cn.AddParams("@REFERANS_NO3", Ref3.ToString());
                }
            }

            dt = cn.GetDataTable("select * from dbo.R_RAPOR_PROJE_GENEL(nolock) a " + where);

            //alacaklı ve borçluya göre arama yapılacak. arama ekranında lookupeditler doldurulacak.
            //aaaa

            return dt;
        }

        public static per_AV001_TDIE_BIL_PROJE GetByID(int ID)
        {
            var predicate = PredicateBuilder.True<per_AV001_TDIE_BIL_PROJE>();

            predicate = predicate.And(vi => vi.ID == ID);

            try
            {
                per_AV001_TDIE_BIL_PROJE sonuc = new per_AV001_TDIE_BIL_PROJE();
                return sonuc = data.per_AV001_TDIE_BIL_PROJEs.Where(predicate).ToList()[0];
            }
            catch
            {
                return null;
            }
        }
    }
}