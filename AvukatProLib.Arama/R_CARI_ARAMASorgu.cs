using System.Data;

namespace AvukatProLib.Arama
{
    public static class R_CARI_ARAMASorgu
    {
        //aykut hızlandırma 01.02.2013
        //public static List<AV001_TDI_BIL_CARI> GetByFiltre(string KOD, string AD, string UNVAN,
        //int? REFERANS_CARI_ID, bool? MUVEKKIL_MI, bool? KARSI_TARAF_MI, bool? FIRMA_MI,
        //bool? PERSONEL_MI, bool? AVUKAT_MI, bool? KURUM_AVUKATI_MI, bool? BILIRKISI_MI, bool? AVUKAT_ORTAKLIGI_MI,
        //bool? ADLI_BIRIM_MI, bool? ADLI_PERSONEL_MI, bool? HARCDAN_MUAF_MI, bool? KAMU_CARI_MI,
        //bool? HASIMSIZ_CARISI_MI, bool? KARA_LISTEDE_MI, bool? BEYAZ_LISTEDE_MI,
        //string MUSTERI_NO, int? BAGLI_OLDUGU_GRUP_ID, string con)
        //{
        //    AvpDataContext data = new AvpDataContext(con);
        //    var predicate = PredicateBuilder.True<AvukatProLib.Arama.AV001_TDI_BIL_CARI>();
        //    if (!string.IsNullOrEmpty(KOD))
        //        predicate = predicate.And(vi => vi.KOD.Contains(KOD));
        //    if (!string.IsNullOrEmpty(AD))
        //        predicate = predicate.And(vi => vi.AD.Contains(AD));
        //    if (!string.IsNullOrEmpty(UNVAN))
        //        predicate = predicate.And(vi => vi.UNVAN.Contains(UNVAN));
        //    if (REFERANS_CARI_ID.HasValue)
        //        predicate = predicate.And(vi => vi.REFERANS_CARI_ID == REFERANS_CARI_ID);
        //    if (MUVEKKIL_MI.HasValue)
        //        predicate = predicate.And(vi => vi.MUVEKKIL_MI == MUVEKKIL_MI);
        //    if (KARSI_TARAF_MI.HasValue)
        //        predicate = predicate.And(vi => vi.KARSI_TARAF_MI == KARSI_TARAF_MI);
        //    if (FIRMA_MI.HasValue)
        //        predicate = predicate.And(vi => vi.FIRMA_MI == FIRMA_MI);
        //    if (PERSONEL_MI.HasValue)
        //        predicate = predicate.And(vi => vi.PERSONEL_MI == PERSONEL_MI);
        //    if (AVUKAT_MI.HasValue)
        //        predicate = predicate.And(vi => vi.AVUKAT_MI == AVUKAT_MI);
        //    if (KURUM_AVUKATI_MI.HasValue)
        //        predicate = predicate.And(vi => vi.KURUM_AVUKATI_MI == KURUM_AVUKATI_MI);
        //    if (BILIRKISI_MI.HasValue)
        //        predicate = predicate.And(vi => vi.BILIRKISI_MI == BILIRKISI_MI);
        //    if (AVUKAT_ORTAKLIGI_MI.HasValue)
        //        predicate = predicate.And(vi => vi.AVUKAT_ORTAKLIGI_MI == AVUKAT_ORTAKLIGI_MI);
        //    if (ADLI_BIRIM_MI.HasValue)
        //        predicate = predicate.And(vi => vi.ADLI_BIRIM_MI == ADLI_BIRIM_MI);
        //    if (ADLI_PERSONEL_MI.HasValue)
        //        predicate = predicate.And(vi => vi.ADLI_PERSONEL_MI == ADLI_PERSONEL_MI);
        //    if (HARCDAN_MUAF_MI.HasValue)
        //        predicate = predicate.And(vi => vi.HARCDAN_MUAF_MI == HARCDAN_MUAF_MI);
        //    if (KAMU_CARI_MI.HasValue)
        //        predicate = predicate.And(vi => vi.KAMU_CARI_MI == KAMU_CARI_MI);
        //    if (HASIMSIZ_CARISI_MI.HasValue)
        //        predicate = predicate.And(vi => vi.HASIMSIZ_CARISI_MI == HASIMSIZ_CARISI_MI);
        //    if (KARA_LISTEDE_MI.HasValue)
        //        predicate = predicate.And(vi => vi.KARA_LISTEDE_MI == KARA_LISTEDE_MI);
        //    if (BEYAZ_LISTEDE_MI.HasValue)
        //        predicate = predicate.And(vi => vi.BEYAZ_LISTEDE_MI == BEYAZ_LISTEDE_MI);

        //    if (!string.IsNullOrEmpty(MUSTERI_NO))
        //        predicate = predicate.And(vi => vi.MUSTERI_NO.Contains(MUSTERI_NO));
        //    if (BAGLI_OLDUGU_GRUP_ID.HasValue)
        //        predicate = predicate.And(vi => vi.BAGLI_OLDUGU_GRUP_ID == BAGLI_OLDUGU_GRUP_ID);

        //    var sonuc = data.AV001_TDI_BIL_CARIs.Where(predicate).ToList();

        //    return sonuc;
        //}

        public static DataTable GetByFiltre(string KOD, string AD, string UNVAN,
        int? REFERANS_CARI_ID, bool? MUVEKKIL_MI, bool? KARSI_TARAF_MI, bool? FIRMA_MI,
        bool? PERSONEL_MI, bool? AVUKAT_MI, bool? KURUM_AVUKATI_MI, bool? BILIRKISI_MI, bool? AVUKAT_ORTAKLIGI_MI,
        bool? ADLI_BIRIM_MI, bool? ADLI_PERSONEL_MI, bool? HARCDAN_MUAF_MI, bool? KAMU_CARI_MI,
        bool? HASIMSIZ_CARISI_MI, bool? KARA_LISTEDE_MI, bool? BEYAZ_LISTEDE_MI,
        string MUSTERI_NO, int? BAGLI_OLDUGU_GRUP_ID, string con)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            string where = " where a.ID<>-1";

            if (!string.IsNullOrEmpty(KOD))
            {
                cn.AddParams("@KOD", KOD);
                where += " and a.KOD like '%' + @KOD + '%'";
            }

            if (!string.IsNullOrEmpty(AD))
            {
                cn.AddParams("@AD", AD);
                where += " and a.AD like '%' + @AD + '%'";
            }

            if (!string.IsNullOrEmpty(UNVAN))
            {
                cn.AddParams("@UNVAN", UNVAN);
                where += " and a.UNVAN like '%' + @UNVAN + '%'";
            }

            if (REFERANS_CARI_ID.HasValue)
            {
                cn.AddParams("@REFERANS_CARI_ID", REFERANS_CARI_ID);
                where += " and a.REFERANS_CARI_ID=@REFERANS_CARI_ID";
            }

            if (MUVEKKIL_MI.HasValue)
            {
                cn.AddParams("@MUVEKKIL_MI", MUVEKKIL_MI);
                where += " and a.MUVEKKIL_MI=@MUVEKKIL_MI";
            }

            if (KARSI_TARAF_MI.HasValue)
            {
                cn.AddParams("@KARSI_TARAF_MI", KARSI_TARAF_MI);
                where += " and a.KARSI_TARAF_MI=@KARSI_TARAF_MI";
            }

            if (FIRMA_MI.HasValue)
            {
                cn.AddParams("@FIRMA_MI", FIRMA_MI);
                where += " and a.FIRMA_MI=@FIRMA_MI";
            }

            if (PERSONEL_MI.HasValue)
            {
                cn.AddParams("@PERSONEL_MI", PERSONEL_MI);
                where += " and a.PERSONEL_MI=@PERSONEL_MI";
            }

            if (AVUKAT_MI.HasValue)
            {
                cn.AddParams("@AVUKAT_MI", AVUKAT_MI);
                where += " and a.AVUKAT_MI=@AVUKAT_MI";
            }

            if (KURUM_AVUKATI_MI.HasValue)
            {
                cn.AddParams("@KURUM_AVUKATI_MI", KURUM_AVUKATI_MI);
                where += " and a.KURUM_AVUKATI_MI=@KURUM_AVUKATI_MI";
            }

            if (BILIRKISI_MI.HasValue)
            {
                cn.AddParams("@BILIRKISI_MI", BILIRKISI_MI);
                where += " and a.BILIRKISI_MI=@BILIRKISI_MI";
            }

            if (AVUKAT_ORTAKLIGI_MI.HasValue)
            {
                cn.AddParams("@AVUKAT_ORTAKLIGI_MI", AVUKAT_ORTAKLIGI_MI);
                where += " and a.AVUKAT_ORTAKLIGI_MI=@AVUKAT_ORTAKLIGI_MI";
            }

            if (ADLI_BIRIM_MI.HasValue)
            {
                cn.AddParams("@ADLI_BIRIM_MI", ADLI_BIRIM_MI);
                where += " and a.ADLI_BIRIM_MI=@ADLI_BIRIM_MI";
            }

            if (ADLI_PERSONEL_MI.HasValue)
            {
                cn.AddParams("@ADLI_PERSONEL_MI", ADLI_PERSONEL_MI);
                where += " and a.ADLI_PERSONEL_MI=@ADLI_PERSONEL_MI";
            }

            if (HARCDAN_MUAF_MI.HasValue)
            {
                cn.AddParams("@HARCDAN_MUAF_MI", HARCDAN_MUAF_MI);
                where += " and a.HARCDAN_MUAF_MI=@HARCDAN_MUAF_MI";
            }

            if (KAMU_CARI_MI.HasValue)
            {
                cn.AddParams("@KAMU_CARI_MI", KAMU_CARI_MI);
                where += " and a.KAMU_CARI_MI=@KAMU_CARI_MI";
            }

            if (HASIMSIZ_CARISI_MI.HasValue)
            {
                cn.AddParams("@HASIMSIZ_CARISI_MI", HASIMSIZ_CARISI_MI);
                where += " and a.HASIMSIZ_CARISI_MI=@HASIMSIZ_CARISI_MI";
            }

            if (KARA_LISTEDE_MI.HasValue)
            {
                cn.AddParams("@KARA_LISTEDE_MI", KARA_LISTEDE_MI);
                where += " and a.KARA_LISTEDE_MI=@KARA_LISTEDE_MI";
            }

            if (BEYAZ_LISTEDE_MI.HasValue)
            {
                cn.AddParams("@BEYAZ_LISTEDE_MI", BEYAZ_LISTEDE_MI);
                where += " and a.BEYAZ_LISTEDE_MI=@BEYAZ_LISTEDE_MI";
            }

            if (!string.IsNullOrEmpty(MUSTERI_NO))
            {
                cn.AddParams("@MUSTERI_NO", MUSTERI_NO);
                where += " and a.MUSTERI_NO like '%' + @MUSTERI_NO + '%'";
            }

            if (BAGLI_OLDUGU_GRUP_ID.HasValue)
            {
                cn.AddParams("@BAGLI_OLDUGU_GRUP_ID", BAGLI_OLDUGU_GRUP_ID);
                where += " and a.BAGLI_OLDUGU_GRUP_ID=@BAGLI_OLDUGU_GRUP_ID";
            }

            sonuc = cn.GetDataTable("select convert(bit,0) as IsSelected, a.KOD, a.AD, a.MUSTERI_NO, a.IBAN_NO, a.UNVAN, a.TEL_1, a.TEL_1_DAHILI, a.TEL_2, a.TEL_2_DAHILI, a.FAX, a.CEP_TEL, a.CEP_TEL2, a.EV_TEL, a.EMAIL_1, a.VERGI_NO, a.ADRES_1 + ' ' + a.ADRES_2 + ' ' + a.ADRES_3  as ADRES, c.ILCE, b.IL, d.ULKE, e.TUR AS FIRMA_TURU, f.MESLEK, a.ID from dbo.AV001_TDI_BIL_CARI(nolock) a left JOIN dbo.TDI_KOD_IL(NOLOCK) b ON b.ID=a.IL_ID left JOIN dbo.TDI_KOD_ILCE(NOLOCK) c ON c.ID=a.ILCE_ID left JOIN dbo.TDI_KOD_ULKE(NOLOCK) d ON d.ID=a.ULKE_ID left JOIN dbo.TDI_KOD_FIRMA_TUR(NOLOCK) e ON e.ID=a.FIRMA_TUR_ID left JOIN dbo.TDI_KOD_MESLEK(NOLOCK) f ON f.ID=a.MESLEK_ID" + where);

            return sonuc;
        }
    }
}