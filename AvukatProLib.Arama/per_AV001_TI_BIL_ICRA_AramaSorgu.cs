using System;
using System.Data;
using System.Linq;

namespace AvukatProLib.Arama
{
    public class per_AV001_TI_BIL_ICRA_AramaSorgu
    {
        public static AvpDataContext data = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        //aykut hızlandırma 29.01.2013 İcra
        //public static List<per_AV001_TI_BIL_ICRA_Arama> GetByFiltreView(string anDigerAlacakNedeni, int? anISlemeKonanTutarDovizID
        // , decimal? anIslemeKonanTutar, string anReferansNo2, string anReferansNo3
        // , DateTime? anVadeTarihi, int? tarafCariID, int? sorumluAvukatCariID
        // , int? ozelKodBankaID, int? ozelKodSubeID, int? ozelKodFoyBirimID, int? ozelKodFoyYeriID
        // , int? ozelKodDurumID, int? ozelKodKrediGrupID, int? ozelKodKrediGrupTipID
        // , int? ozelKodTahsilatDurumID, string ozelKodKlasor1, string ozelKodKlasor2
        // , string takipTalep, string foyNo, string referansNo1, string referansNo2, string referansNo3
        // , int? foyDurumID, int? adliBirimAdliyeID, int? adliBirimNoID, string esasNo, string dEsasNo
        // , int? icraOzelKod1, int? icraOzelKod2, int? icraOzelKod3, int? icraOzelKod4
        // , DateTime? takipTarihi, int? hmTalimatAdliBirimAdliyeID, int? hmAdliBirimNoID
        // , int? tarafVekilID, string hmTalimatEsasNo, bool? leyhmi, int? subeKodID, DateTime? kayitTarihi, int? formTipId, int? takipTalepId, string con)
        //{
        //    var predicate = PredicateBuilder.True<per_AV001_TI_BIL_ICRA_Arama>();

        //    if (sorumluAvukatCariID.HasValue)
        //    {
        //        predicate = predicate.And(vi => vi.SORUMLU_AVUKAT_CARI_ID == sorumluAvukatCariID);
        //    }
        //    if (ozelKodBankaID.HasValue)
        //    {
        //        predicate = predicate.And(vi => vi.BANKA_ID == ozelKodBankaID);
        //    }
        //    if (ozelKodSubeID.HasValue)
        //    {
        //        predicate = predicate.And(vi => vi.OZEL_KOD_SUBE_KOD_ID == ozelKodSubeID);
        //    }
        //    if (ozelKodFoyBirimID.HasValue)
        //    {
        //        predicate = predicate.And(vi => vi.FOY_BIRIM_ID == ozelKodFoyBirimID);
        //    }
        //    if (ozelKodFoyYeriID.HasValue)
        //    {
        //        predicate = predicate.And(vi => vi.FOY_YERI_ID == ozelKodFoyYeriID);
        //    }
        //    if (ozelKodDurumID.HasValue)
        //    {
        //        predicate = predicate.And(vi => vi.FOY_OZEL_DURUM_ID == ozelKodDurumID);
        //    }
        //    if (ozelKodKrediGrupID.HasValue)
        //    {
        //        predicate = predicate.And(vi => vi.KREDI_GRUP_ID == ozelKodKrediGrupID);
        //    }
        //    if (ozelKodKrediGrupTipID.HasValue)
        //    {
        //        predicate = predicate.And(vi => vi.KREDI_TIP_ID == ozelKodKrediGrupTipID);
        //    }
        //    if (ozelKodTahsilatDurumID.HasValue)
        //    {
        //        predicate = predicate.And(vi => vi.TAHSILAT_DURUM_ID == ozelKodTahsilatDurumID);
        //    }
        //    if (!string.IsNullOrEmpty(ozelKodKlasor1))
        //    {
        //        predicate = predicate.And(vi => vi.KLASOR_1.Contains(ozelKodKlasor1));
        //    }
        //    if (!string.IsNullOrEmpty(ozelKodKlasor2))
        //    {
        //        predicate = predicate.And(vi => vi.KLASOR_2.Contains(ozelKodKlasor2));
        //    }
        //    if (!string.IsNullOrEmpty(takipTalep))
        //    {
        //        predicate = predicate.And(vi => vi.GTAKIP_TALEP.Contains(takipTalep));
        //    }
        //    if (!string.IsNullOrEmpty(foyNo))
        //    {
        //        if (foyNo.Contains("~"))
        //        {
        //            var foy = foyNo.Split('~');
        //            foyNo = foy[1];
        //        }
        //        predicate = predicate.And(vi => vi.FOY_NO.Contains(foyNo));
        //    }

        //    if (!string.IsNullOrEmpty(referansNo1))
        //        predicate = predicate.And(vi => vi.REFERANS_NO.Contains(referansNo1));
        //    if (!string.IsNullOrEmpty(referansNo2))
        //        predicate = predicate.And(vi => vi.REFERANS_NO2.Contains(referansNo2));
        //    if (!string.IsNullOrEmpty(referansNo3))
        //        predicate = predicate.And(vi => vi.REFERANS_NO3.Contains(referansNo3));
        //    if (foyDurumID.HasValue)
        //        predicate = predicate.And(vi => vi.FOY_DURUM_ID == foyDurumID.Value);
        //    if (adliBirimAdliyeID.HasValue)
        //        predicate = predicate.And(vi => vi.ADLI_BIRIM_ADLIYE_ID == adliBirimAdliyeID.Value);
        //    if (adliBirimNoID.HasValue)
        //        predicate = predicate.And(vi => vi.ADLI_BIRIM_NO_ID == adliBirimNoID.Value);
        //    if (!string.IsNullOrEmpty(esasNo))
        //    {
        //        if (esasNo.Contains("/"))
        //        {
        //            var foy = esasNo.Split('/');
        //            if (!string.IsNullOrEmpty(foy[0]) && string.IsNullOrEmpty(foy[1]))
        //                esasNo = foy[0] + "/";
        //            if (!string.IsNullOrEmpty(foy[1]) && string.IsNullOrEmpty(foy[0]))
        //                esasNo = foy[1];
        //            if (!string.IsNullOrEmpty(foy[0]) && !string.IsNullOrEmpty(foy[1]))
        //                esasNo = esasNo;
        //        }
        //        predicate = predicate.And(vi => vi.ESAS_NO.Contains(esasNo));
        //    }
        //    if (icraOzelKod1.HasValue)
        //        predicate = predicate.And(vi => vi.ICRA_OZEL_KOD1_ID == icraOzelKod1.Value);
        //    if (icraOzelKod2.HasValue)
        //        predicate = predicate.And(vi => vi.ICRA_OZEL_KOD2_ID == icraOzelKod2.Value);
        //    if (icraOzelKod3.HasValue)
        //        predicate = predicate.And(vi => vi.ICRA_OZEL_KOD3_ID == icraOzelKod3.Value);
        //    if (icraOzelKod4.HasValue)
        //        predicate = predicate.And(vi => vi.ICRA_OZEL_KOD4_ID == icraOzelKod4.Value);
        //    if (tarafVekilID.HasValue)
        //    {
        //        var tvekil = data.AV001_TI_BIL_FOY_TARAF_VEKILs.Where(o => o.AVUKAT_CARI_ID == tarafVekilID.Value);
        //        var foytaraf = tvekil.Select(I => I.FOY_TARAF_ID).ToList();
        //        var OzelKod = data.AV001_TI_BIL_FOY_TARAFs.Where(o => foytaraf.Contains(o.ID));
        //        var list = OzelKod.Select(I => I.ICRA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => list.Contains(vi.ID));
        //    }
        //    if (takipTarihi.HasValue)
        //        predicate = predicate.And(vi => vi.TAKIP_TARIHI >= takipTarihi.Value && vi.TAKIP_TARIHI < takipTarihi.Value.AddDays(1));

        //    if (tarafCariID.HasValue)
        //    {
        //        predicate = predicate.And(vi => vi.TAKIP_EDEN_CARI_ID == tarafCariID || vi.TAKIP_EDILEN_CARI_ID == tarafCariID);
        //    }
        //    if (leyhmi.HasValue)
        //    {
        //        var OzelKod = data.AV001_TI_BIL_FOY_TARAFs.Where(o => o.TAKIP_EDEN_MI == leyhmi.Value && o.TARAF_KODU == Convert.ToByte(1));
        //        var list = OzelKod.Select(I => I.ICRA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => list.Contains(vi.ID));
        //    }
        //    if (subeKodID.HasValue)
        //        predicate = predicate.And(vi => vi.SUBE_KOD_ID == subeKodID.Value);

        //    if (kayitTarihi.HasValue)
        //        predicate = predicate.And(vi => vi.TAKIP_TARIHI.HasValue && vi.TAKIP_TARIHI.Value.Date == kayitTarihi.Value.Date);

        //    if (formTipId.HasValue)
        //        predicate = predicate.And(vi => vi.FORM_TIP_ID == formTipId.Value);

        //    if (takipTalepId.HasValue)
        //        predicate = predicate.And(vi => vi.TAKIP_TALEP_ID == takipTalepId.Value);
        //    try
        //    {
        //        List<per_AV001_TI_BIL_ICRA_Arama> sonuc = new List<per_AV001_TI_BIL_ICRA_Arama>();
        //        return sonuc = data.per_AV001_TI_BIL_ICRA_Aramas.Where(predicate).ToList();
        //    }
        //    catch
        //    {
        //        return null;
        //    }

        //    return null;
        //}

        //public static per_AV001_TI_BIL_ICRA_Arama GetByID(int Id)
        //{
        //    return data.per_AV001_TI_BIL_ICRA_Aramas.Where(f => f.ID == Id).FirstOrDefault();
        //}

        public static DataTable GetByFiltreView(string anDigerAlacakNedeni, int? anISlemeKonanTutarDovizID
         , decimal? anIslemeKonanTutar, string anReferansNo2, string anReferansNo3
         , DateTime? anVadeTarihi, int? tarafCariID, int? sorumluAvukatCariID
         , int? ozelKodBankaID, int? ozelKodSubeID, int? ozelKodFoyBirimID, int? ozelKodFoyYeriID
         , int? ozelKodDurumID, int? ozelKodKrediGrupID, int? ozelKodKrediGrupTipID
         , int? ozelKodTahsilatDurumID, string ozelKodKlasor1, string ozelKodKlasor2
         , string takipTalep, string foyNo, string referansNo1, string referansNo2, string referansNo3
         , int? foyDurumID, int? adliBirimAdliyeID, int? adliBirimNoID, string esasNo, string dEsasNo
         , int? icraOzelKod1, int? icraOzelKod2, int? icraOzelKod3, int? icraOzelKod4
         , DateTime? takipTarihi, int? hmTalimatAdliBirimAdliyeID, int? hmAdliBirimNoID
         , int? tarafVekilID, string hmTalimatEsasNo, bool? leyhmi, int? subeKodID, DateTime? kayitTarihi, int? formTipId, int? takipTalepId, string con, int Leyh, string ZamanDilimi, int IL, int ILCE, string Adres)
        {
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            string where = " where a.ID<>-1";

            if (sorumluAvukatCariID.HasValue)
            {
                cn.AddParams("@SORUMLU_AVUKAT_CARI_ID", sorumluAvukatCariID);
                where += " and a.SORUMLU_AVUKAT_CARI_ID=@SORUMLU_AVUKAT_CARI_ID";
            }
            if (ozelKodBankaID.HasValue)
            {
                cn.AddParams("@BANKA_ID", ozelKodBankaID);
                where += " and a.BANKA_ID=@BANKA_ID";
            }
            if (ozelKodSubeID.HasValue)
            {
                cn.AddParams("@OZEL_KOD_SUBE_KOD_ID", ozelKodSubeID);
                where += " and a.OZEL_KOD_SUBE_KOD_ID=@OZEL_KOD_SUBE_KOD_ID";
            }
            if (ozelKodFoyBirimID.HasValue)
            {
                cn.AddParams("@FOY_BIRIM_ID", ozelKodFoyBirimID);
                where += " and a.FOY_BIRIM_ID=@FOY_BIRIM_ID";
            }
            if (ozelKodFoyYeriID.HasValue)
            {
                cn.AddParams("@FOY_YERI_ID", ozelKodFoyYeriID);
                where += " and a.FOY_YERI_ID=@FOY_YERI_ID";
            }
            if (ozelKodDurumID.HasValue)
            {
                cn.AddParams("@FOY_OZEL_DURUM_ID", ozelKodDurumID);
                where += " and a.FOY_OZEL_DURUM_ID=@FOY_OZEL_DURUM_ID";
            }
            if (ozelKodKrediGrupID.HasValue)
            {
                cn.AddParams("@KREDI_GRUP_ID", ozelKodKrediGrupID);
                where += " and a.KREDI_GRUP_ID=@KREDI_GRUP_ID";
            }
            if (ozelKodKrediGrupTipID.HasValue)
            {
                cn.AddParams("@KREDI_TIP_ID", ozelKodKrediGrupTipID);
                where += " and a.KREDI_TIP_ID=@KREDI_TIP_ID";
            }
            if (ozelKodTahsilatDurumID.HasValue)
            {
                cn.AddParams("@TAHSILAT_DURUM_ID", ozelKodTahsilatDurumID);
                where += " and a.TAHSILAT_DURUM_ID=@TAHSILAT_DURUM_ID";
            }
            if (!string.IsNullOrEmpty(ozelKodKlasor1))
            {
                cn.AddParams("@KLASOR_1", ozelKodKlasor1);
                where += " and a.KLASOR_1 like '%' + @KLASOR_1 + '%'";
            }
            if (!string.IsNullOrEmpty(ozelKodKlasor2))
            {
                cn.AddParams("@KLASOR_2", ozelKodKlasor2);
                where += " and a.KLASOR_2 like '%' + @KLASOR_2 + '%'";
            }
            if (!string.IsNullOrEmpty(takipTalep))
            {
                cn.AddParams("@GTAKIP_TALEP", takipTalep);
                where += " and a.GTAKIP_TALEP like '%' + @GTAKIP_TALEP + '%'";
            }
            if (!string.IsNullOrEmpty(foyNo))
            {
                if (foyNo.Contains("~"))
                {
                    var foy = foyNo.Split('~');
                    foyNo = foy[1];
                }
                cn.AddParams("@FOY_NO", foyNo);
                where += " and a.FOY_NO like '%' + @FOY_NO + '%'";
            }

            if (!string.IsNullOrEmpty(referansNo1))
            {
                cn.AddParams("@REFERANS_NO", referansNo1);
                where += " and a.REFERANS_NO like '%' + @REFERANS_NO + '%'";
            }

            if (!string.IsNullOrEmpty(referansNo2))
            {
                cn.AddParams("@REFERANS_NO2", referansNo2);
                where += " and a.REFERANS_NO2 like '%' + @REFERANS_NO2 + '%'";
            }

            if (!string.IsNullOrEmpty(referansNo3))
            {
                cn.AddParams("@REFERANS_NO3", referansNo3);
                where += " and a.REFERANS_NO3 like '%' + @REFERANS_NO3 + '%'";
            }

            if (foyDurumID.HasValue)
            {
                cn.AddParams("@FOY_DURUM_ID", foyDurumID.Value);
                where += " and a.FOY_DURUM_ID=@FOY_DURUM_ID";
            }

            if (adliBirimAdliyeID.HasValue)
            {
                cn.AddParams("@ADLI_BIRIM_ADLIYE_ID", adliBirimAdliyeID.Value);
                where += " and a.ADLI_BIRIM_ADLIYE_ID=@ADLI_BIRIM_ADLIYE_ID";
            }

            if (adliBirimNoID.HasValue)
            {
                cn.AddParams("@ADLI_BIRIM_NO_ID", adliBirimNoID.Value);
                where += " and a.ADLI_BIRIM_NO_ID=@ADLI_BIRIM_NO_ID";
            }

            if (!string.IsNullOrEmpty(esasNo))
            {
                if (esasNo.Contains("/"))
                {
                    var foy = esasNo.Split('/');
                    if (!string.IsNullOrEmpty(foy[0]) && string.IsNullOrEmpty(foy[1]))
                        esasNo = foy[0] + "/";
                    if (!string.IsNullOrEmpty(foy[1]) && string.IsNullOrEmpty(foy[0]))
                        esasNo = foy[1];
                }
                cn.AddParams("@ESAS_NO", esasNo);
                where += " and a.ESAS_NO like '%' + @ESAS_NO + '%'";
            }

            if (icraOzelKod1.HasValue)
            {
                cn.AddParams("@ICRA_OZEL_KOD1_ID", icraOzelKod1.Value);
                where += " and a.ICRA_OZEL_KOD1_ID=@ICRA_OZEL_KOD1_ID";
            }

            if (icraOzelKod2.HasValue)
            {
                cn.AddParams("@ICRA_OZEL_KOD2_ID", icraOzelKod2.Value);
                where += " and a.ICRA_OZEL_KOD2_ID=@ICRA_OZEL_KOD2_ID";
            }

            if (icraOzelKod3.HasValue)
            {
                cn.AddParams("@ICRA_OZEL_KOD3_ID", icraOzelKod3.Value);
                where += " and a.ICRA_OZEL_KOD3_ID=@ICRA_OZEL_KOD3_ID";
            }

            if (icraOzelKod4.HasValue)
            {
                cn.AddParams("@ICRA_OZEL_KOD4_ID", icraOzelKod4.Value);
                where += " and a.ICRA_OZEL_KOD4_ID=@ICRA_OZEL_KOD4_ID";
            }

            if (tarafVekilID.HasValue)
            {
                cn.AddParams("@tarafVekilID", tarafVekilID.Value);
                where += " and a.ID in (select ICRA_FOY_ID from dbo.AV001_TI_BIL_FOY_TARAF(nolock) where ID in (select FOY_TARAF_ID from dbo.AV001_TI_BIL_FOY_TARAF_VEKIL(nolock) where AVUKAT_CARI_ID=@tarafVekilID))";

                //var tvekil = data.AV001_TI_BIL_FOY_TARAF_VEKILs.Where(o => o.AVUKAT_CARI_ID == tarafVekilID.Value);
                //var foytaraf = tvekil.Select(I => I.FOY_TARAF_ID).ToList();
                //var OzelKod = data.AV001_TI_BIL_FOY_TARAFs.Where(o => foytaraf.Contains(o.ID));
                //var list = OzelKod.Select(I => I.ICRA_FOY_ID).ToList();
                //predicate = predicate.And(vi => list.Contains(vi.ID));
            }
            if (takipTarihi.HasValue)
            {
                cn.AddParams("@TAKIP_TARIHI", takipTarihi.Value);
                cn.AddParams("@TAKIP_TARIHI2", takipTarihi.Value.AddDays(1));
                where += " and a.TAKIP_TARIHI >= @TAKIP_TARIHI and a.TAKIP_TARIHI < @TAKIP_TARIHI2";
            }

            if (tarafCariID.HasValue)
            {
                cn.AddParams("@TAKIP_EDEN_CARI_ID", tarafCariID);
                where += " and (a.TAKIP_EDEN_CARI_ID=@TAKIP_EDEN_CARI_ID or a.TAKIP_EDILEN_CARI_ID=@TAKIP_EDEN_CARI_ID)";
            }
            //if (leyhmi.HasValue)
            //{
            //    da.SelectCommand.Parameters.AddWithValue("@TAKIP_EDEN_MI", leyhmi.Value);
            //    da.SelectCommand.Parameters.AddWithValue("@TARAF_KODU", Convert.ToByte(1));
            //    where += " and ID in (select ICRA_FOY_ID from TAKIP_EDEN_MI=@TAKIP_EDEN_MI and TARAF_KODU=@TARAF_KODU)";
            //    //var OzelKod = data.AV001_TI_BIL_FOY_TARAFs.Where(o => o.TAKIP_EDEN_MI == leyhmi.Value && o.TARAF_KODU == Convert.ToByte(1));
            //    //var list = OzelKod.Select(I => I.ICRA_FOY_ID).ToList();
            //    //predicate = predicate.And(vi => list.Contains(vi.ID));
            //}
            if (subeKodID.HasValue)
            {
                cn.AddParams("@SUBE_KOD_ID", subeKodID.Value);
                where += " and a.SUBE_KOD_ID=@SUBE_KOD_ID";
            }

            if (kayitTarihi.HasValue)
            {
                cn.AddParams("@TAKIP_TARIHI", kayitTarihi.Value.Date);
                where += " and a.TAKIP_TARIHI=@TAKIP_TARIHI";
            }

            if (formTipId.HasValue)
            {
                cn.AddParams("@FORM_TIP_ID", formTipId.Value);
                where += " and a.FORM_TIP_ID=@FORM_TIP_ID";
            }

            if (takipTalepId.HasValue)
            {
                cn.AddParams("@TAKIP_TALEP_ID", takipTalepId.Value);
                where += " and a.TAKIP_TALEP_ID=@TAKIP_TALEP_ID";
            }

            if (Leyh > -1)
            {
                if (Leyh == 0)
                    where += " and (SELECT HANGI_TARAFI FROM dbo.TDIE_KOD_TARAF_SIFAT WHERE ID = (SELECT top(1)TARAF_SIFAT_ID FROM dbo.AV001_TI_BIL_FOY_TARAF WHERE ICRA_FOY_ID=A.ID AND TARAF_KODU=1))='TAKİP EDEN'";
                else if (Leyh == 1)
                    where += " and (SELECT HANGI_TARAFI FROM dbo.TDIE_KOD_TARAF_SIFAT WHERE ID = (SELECT top(1)TARAF_SIFAT_ID FROM dbo.AV001_TI_BIL_FOY_TARAF WHERE ICRA_FOY_ID=A.ID AND TARAF_KODU=1))='TAKİP EDİLEN'";
            }

            if (ZamanDilimi != "Tumu")
            {
                if (!kayitTarihi.HasValue)
                {
                    where += Metotlar.ZamanDilimiParametresiOlustur(cn, "TAKIP_TARIHI", ZamanDilimi).Replace(" TAKIP_TARIHI", " a.TAKIP_TARIHI");
                }
            }

            if (IL != -1)
            {
                cn.AddParams("@IL_ID", IL);
                where += " AND TAKIP_EDILEN_CARI_ID in (SELECT ID FROM dbo.AV001_TDI_BIL_CARI(NOLOCK) WHERE IL_ID=@IL_ID)";
            }

            if (ILCE != -1)
            {
                cn.AddParams("@ILCE_ID", ILCE);
                where += " AND TAKIP_EDILEN_CARI_ID in (SELECT ID FROM dbo.AV001_TDI_BIL_CARI(NOLOCK) WHERE ILCE_ID=@ILCE_ID)";
            }

            if (!string.IsNullOrEmpty(Adres))
            {
                cn.AddParams("@Adres", Adres);
                where += " AND TAKIP_EDILEN_CARI_ID in (SELECT ID FROM dbo.AV001_TDI_BIL_CARI(NOLOCK) WHERE ADRES_1 LIKE '%' + @Adres + '%' or ADRES_2 LIKE '%' + @Adres + '%' or ADRES_3 LIKE '%' + @Adres + '%')";
            }

            try
            {
                string where2 = "";
                if (adliBirimAdliyeID.HasValue || adliBirimNoID.HasValue || !string.IsNullOrEmpty(esasNo))
                {
                    where2 = " or a.ID IN (SELECT dus.ICRA_FOY_ID FROM dbo.AV001_TI_BIL_DUSME_YENILEME(nolock) dus WHERE dus.ICRA_FOY_ID<>-1";
                    if (adliBirimAdliyeID.HasValue)
                        where2 += " and dus.ADLI_BIRIM_ADLIYE_ID=@ADLI_BIRIM_ADLIYE_ID";

                    if (adliBirimNoID.HasValue)
                        where2 += " and dus.ADLI_BIRIM_NO_ID=@ADLI_BIRIM_NO_ID";

                    if (!string.IsNullOrEmpty(esasNo))
                        where2 += " and dus.ESKI_ICRA_DOSYA_NO like '%' + @ESAS_NO + '%'";

                    where2 += ")";
                }
                return cn.GetDataTable("select convert(bit, 0) as IsSelected, a.FOY_NO, a.DURUM, a.GOREV, a.TAKIP_YOLU, a.KKDV_TO, a.BSMV_TO, a.TO_HESAPLAMA_TIPI, a.KAYIT_TARIHI, a.FORM_TIP_ID, a.TAKIP_TALEP_ID, a.REFERANS_NO, a.ACIKLAMA, a.REFERANS_NO2, a.REFERANS_NO3, a.TAKIP_TARIHI, a.ADLI_BIRIM_ADLIYE_ID, a.ADLI_BIRIM_NO_ID, a.ESAS_NO, a.ICRA_OZEL_KOD1_ID, a.ICRA_OZEL_KOD2_ID, a.ICRA_OZEL_KOD3_ID, a.ICRA_OZEL_KOD4_ID, a.TAKIBIN_AVUKATA_INTIKAL_TARIHI, a.ASIL_ALACAK, a.ASIL_ALACAK_DOVIZ_ID, a.ISLEMIS_FAIZ, a.ISLEMIS_FAIZ_DOVIZ_ID, a.TAKIP_CIKISI, a.TAKIP_CIKISI_DOVIZ_ID, a.SON_HESAP_TARIHI, a.SONRAKI_FAIZ, a.SONRAKI_FAIZ_DOVIZ_ID, a.ODEME_TOPLAMI, a.ODEME_TOPLAMI_DOVIZ_ID, a.KALAN, a.KALAN_DOVIZ_ID, a.KAPAMA_TARIHI, a.TAKIP_TALEP, a.FORM_ORNEK_NO, a.RISK_MIKTARI, a.RISK_MIKTARI_DOVIZ_ID, a.DEPARTMANA_INTIKAL_TARIHI, a.ID, a.FOY_DURUM_ID, a.SUBE_KOD_ID,  a.BOLUM, a.BURO, a.KULLANICI, a.GTAKIP_TALEP, a.GOZEL_KOD1, a.GOZEL_KOD2, a.GOZEL_KOD3, a.GOZEL_KOD4, a.ADLI_BIRIM_NO, a.ADLI_BIRIM_ADLIYE, a.TAKIP_EDILEN_TK, a.TAKIP_EDILEN_SIFAT, a.TAKIP_EDILEN_CARI_ID, a.GDURUM, a.TAKIP_EDILEN, a.TAKIP_EDEN_TK, a.TAKIP_EDEN_SIFAT, a.TAKIP_EDEN, a.TAKIP_EDEN_CARI_ID, a.SORUMLU, a.SORUMLU_AVUKAT_CARI_ID, a.IZLEYEN, a.IZLEYEN_CARI_ID,(SELECT SUM(MIKTAR) FROM dbo.AV001_TI_BIL_MUVEKKILE_ODEME(nolock) WHERE ICRA_FOY_ID=a.ID) AS TOPLAM_MUV_ODEME, (SELECT DOVIZ_KODU FROM DBO.TDI_KOD_DOVIZ_TIP(NOLOCK) WHERE ID=(SELECT TOP(1)MIKTAR_DOVIZ_ID FROM dbo.AV001_TI_BIL_MUVEKKILE_ODEME(nolock) WHERE ICRA_FOY_ID=a.ID)) AS TOPLAM_MUV_ODEME_DOVIZ_ID, ESKI_RAF_NO, c.YENI_FORM_ORNEK_NO, b.TS_MASRAF_TOPLAMI, b.TS_MASRAF_TOPLAMI_DOVIZ_ID from dbo.per_AV001_TI_BIL_ICRA_Arama(nolock) a INNER JOIN dbo.AV001_TI_BIL_FOY(nolock) b ON b.ID=a.ID INNER JOIN dbo.TI_KOD_FORM_TIP(nolock) c ON c.ID=a.FORM_TIP_ID" + where + where2);
            }
            catch
            {
                return null;
            }

        }

        public static per_AV001_TI_BIL_ICRA_Arama GetByID(int Id)
        {
            return data.per_AV001_TI_BIL_ICRA_Aramas.Where(f => f.ID == Id).FirstOrDefault();
        }
    }
}