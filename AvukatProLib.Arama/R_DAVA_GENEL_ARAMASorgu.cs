using System;
using System.Data;

namespace AvukatProLib.Arama
{
    public class R_DAVA_GENEL_ARAMASorgu
    {
        //aykut hızlandırma 07.02.2013
        //public static List<AV001_TD_BIL_FOY> GetByFiltreView(int? tarafCariID, int? sorumluAvukatCariID
        //   , int? ozelKodBankaID, int? ozelKodSubeID, int? ozelKodFoyBirimID, int? ozelKodFoyYeriID
        //   , int? ozelKodDurumID, int? ozelKodKrediGrupID, int? ozelKodKrediGrupTipID
        //   , int? ozelKodTahsilatDurumID, string ozelKodKlasor1, string ozelKodKlasor2
        //   , string dnDigerDavaNeden, int? dnDavaEdilenTutarDovizID, decimal? dnDavaEdilenTutar
        //   , string dnReferansNo1, string dnReferansNo2, DateTime? dnOlaySucTarihi, int? davaTalepID
        //   , string foyNo, string referansNo1, string referansNo2, string referansNo3, int? foyDurumID
        //   , DateTime? davaTarihi, int? adliBirimAdliyeID, int? adliBirimNoID, int? adliBirimGorevID
        //   , string esasNo, int? davaOzelKod1, int? davaOzelKod2, int? davaOzelKod3, int? davaOzelKod4
        //   , int? temsilVekilID, bool? leyhmi, int? subeKodID, DateTime? celseTarihi, DateTime? kesifTarihi, string con)
        //{
        //    AvpDataContext data = new AvpDataContext(con);
        //    var predicate = PredicateBuilder.True<AvukatProLib.Arama.AV001_TD_BIL_FOY>();
        //    if (sorumluAvukatCariID.HasValue)
        //    {
        //        var sorumlu = data.AV001_TD_BIL_FOY_SORUMLU_AVUKATs.Where(vs => vs.SORUMLU_AVUKAT_CARI_ID == sorumluAvukatCariID.Value);
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (ozelKodBankaID.HasValue)
        //    {
        //        var sorumlu = data.AV001_TD_BIL_FOY_OZEL_KODs.Where(vs => vs.BANKA_ID == ozelKodBankaID.Value);
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (ozelKodSubeID.HasValue)
        //    {
        //        var sorumlu = data.AV001_TD_BIL_FOY_OZEL_KODs.Where(vs => vs.SUBE_KOD_ID == ozelKodSubeID.Value);
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (ozelKodFoyBirimID.HasValue)
        //    {
        //        var sorumlu = data.AV001_TD_BIL_FOY_OZEL_KODs.Where(vs => vs.FOY_BIRIM_ID == ozelKodFoyBirimID.Value);
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (ozelKodFoyYeriID.HasValue)
        //    {
        //        var sorumlu = data.AV001_TD_BIL_FOY_OZEL_KODs.Where(vs => vs.FOY_YERI_ID == ozelKodFoyYeriID.Value);
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (ozelKodKrediGrupID.HasValue)
        //    {
        //        var sorumlu = data.AV001_TD_BIL_FOY_OZEL_KODs.Where(vs => vs.KREDI_GRUP_ID == ozelKodKrediGrupID.Value);
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (ozelKodKrediGrupTipID.HasValue)
        //    {
        //        var sorumlu = data.AV001_TD_BIL_FOY_OZEL_KODs.Where(vs => vs.KREDI_TIP_ID == ozelKodKrediGrupTipID.Value);
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (ozelKodTahsilatDurumID.HasValue)
        //    {
        //        var sorumlu = data.AV001_TD_BIL_FOY_OZEL_KODs.Where(vs => vs.TAHSILAT_DURUM_ID == ozelKodTahsilatDurumID.Value);
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (!string.IsNullOrEmpty(ozelKodKlasor1))
        //    {
        //        var sorumlu = data.AV001_TD_BIL_FOY_OZEL_KODs.Where(vs => vs.KLASOR_1.Contains(ozelKodKlasor1));
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (!string.IsNullOrEmpty(ozelKodKlasor2))
        //    {
        //        var sorumlu = data.AV001_TD_BIL_FOY_OZEL_KODs.Where(vs => vs.KLASOR_2.Contains(ozelKodKlasor2));
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (!string.IsNullOrEmpty(dnDigerDavaNeden))
        //    {
        //        var sorumlu = data.AV001_TD_BIL_DAVA_NEDENs.Where(vs => vs.DIGER_DAVA_NEDEN.Contains(dnDigerDavaNeden));
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (dnDavaEdilenTutarDovizID.HasValue)
        //    {
        //        var sorumlu = data.AV001_TD_BIL_DAVA_NEDENs.Where(vs => vs.DAVA_EDILEN_TUTAR_DOVIZ_ID == dnDavaEdilenTutarDovizID.Value);
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (dnDavaEdilenTutar.HasValue)
        //    {
        //        var sorumlu = data.AV001_TD_BIL_DAVA_NEDENs.Where(vs => vs.DAVA_EDILEN_TUTAR == dnDavaEdilenTutar);
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (!string.IsNullOrEmpty(dnReferansNo1))
        //    {
        //        var sorumlu = data.AV001_TD_BIL_DAVA_NEDENs.Where(vs => vs.REFERANS_NO1.Contains(dnReferansNo1));
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (!string.IsNullOrEmpty(dnReferansNo2))
        //    {
        //        var sorumlu = data.AV001_TD_BIL_DAVA_NEDENs.Where(vs => vs.REFERANS_NO2.Contains(dnReferansNo2));
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (dnOlaySucTarihi.HasValue)
        //    {
        //        var sorumlu = data.AV001_TD_BIL_DAVA_NEDENs.Where(vs => vs.OLAY_SUC_TARIHI == dnOlaySucTarihi.Value);
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (davaTalepID.HasValue)
        //        predicate = predicate.And(vi => vi.DAVA_TALEP_ID == davaTalepID.Value);
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
        //    if (adliBirimGorevID.HasValue)
        //        predicate = predicate.And(vi => vi.ADLI_BIRIM_GOREV_ID == adliBirimGorevID);
        //    if (adliBirimNoID.HasValue)
        //        predicate = predicate.And(vi => vi.ADLI_BIRIM_NO_ID == adliBirimNoID.Value);
        //    if (!string.IsNullOrEmpty(esasNo))
        //    {
        //        predicate = predicate.And(vi => vi.ESAS_NO.Contains(esasNo));
        //        var sorumlu = data.AV001_TD_BIL_DUSME_YENILEMEs.Where(vs => vs.ESKI_DAVA_DOSYA_NO.Contains(esasNo));
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        if (Davalar.Count != 0)
        //        {
        //            predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //        }
        //    }
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
        //    if (davaOzelKod1.HasValue)
        //        predicate = predicate.And(vi => vi.DAVA_OZEL_KOD1_ID == davaOzelKod1);
        //    if (davaOzelKod2.HasValue)
        //        predicate = predicate.And(vi => vi.DAVA_OZEL_KOD2_ID == davaOzelKod2);
        //    if (davaOzelKod3.HasValue)
        //        predicate = predicate.And(vi => vi.DAVA_OZEL_KOD3_ID == davaOzelKod3);
        //    if (davaOzelKod4.HasValue)
        //        predicate = predicate.And(vi => vi.DAVA_OZEL_KOD4_ID == davaOzelKod4);
        //    if (tarafCariID.HasValue)
        //    {
        //        var sorumlu = data.AV001_TD_BIL_FOY_TARAFs.Where(vs => vs.CARI_ID == tarafCariID.Value);
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (temsilVekilID.HasValue)
        //    {
        //        var tvekil = data.AV001_TD_BIL_FOY_TARAF_VEKILs.Where(o => o.AVUKAT_CARI_ID == temsilVekilID.Value);
        //        var foytaraf = tvekil.Select(I => I.FOY_TARAF_ID).ToList();
        //        var OzelKod = data.AV001_TD_BIL_FOY_TARAFs.Where(o => foytaraf.Contains(o.ID));
        //        var list = OzelKod.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => list.Contains(vi.ID));
        //    }
        //    if (leyhmi.HasValue)
        //    {
        //        var sorumlu = data.AV001_TD_BIL_FOY_TARAFs.Where(vs => vs.DAVA_EDEN_MI == leyhmi.Value && vs.TARAF_KODU == 1);
        //        var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => Davalar.Contains(vi.ID));
        //    }
        //    if (davaTarihi.HasValue)
        //    {
        //        predicate = predicate.And(vi => vi.DAVA_TARIHI.Value >= davaTarihi.Value && vi.DAVA_TARIHI < davaTarihi.Value.AddDays(1));
        //    }
        //    if (subeKodID.HasValue)
        //        predicate = predicate.And(vi => vi.SUBE_KOD_ID == subeKodID.Value);
        //    if (celseTarihi.HasValue)
        //    {
        //        var celseT = data.AV001_TD_BIL_CELSEs.Where(cl => cl.TARIH >= celseTarihi && cl.TARIH < celseTarihi.Value.AddDays(1));
        //        var celse = celseT.Select(v => v.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => celse.Contains(vi.ID));
        //    }
        //    if (kesifTarihi.HasValue)
        //    {
        //        var celseT = data.AV001_TD_BIL_CELSEs.Where(cl => cl.TARIH >= kesifTarihi && cl.TARIH < kesifTarihi.Value.AddDays(1));
        //        var celse = celseT.Select(v => v.DAVA_FOY_ID).ToList();
        //        predicate = predicate.And(vi => celse.Contains(vi.ID));
        //    }
        //    List<AV001_TD_BIL_FOY> sonuc = new List<AV001_TD_BIL_FOY>();

        //    sonuc = data.AV001_TD_BIL_FOYs.Where(predicate).ToList();

        //    return sonuc;
        //}

        public static DataTable GetByFiltreView(int? tarafCariID, int? sorumluAvukatCariID
                   , int? ozelKodBankaID, int? ozelKodSubeID, int? ozelKodFoyBirimID, int? ozelKodFoyYeriID
                   , int? ozelKodDurumID, int? ozelKodKrediGrupID, int? ozelKodKrediGrupTipID
                   , int? ozelKodTahsilatDurumID, string ozelKodKlasor1, string ozelKodKlasor2
                   , string dnDigerDavaNeden, int? dnDavaEdilenTutarDovizID, decimal? dnDavaEdilenTutar
                   , string dnReferansNo1, string dnReferansNo2, DateTime? dnOlaySucTarihi, int? davaTalepID
                   , string foyNo, string referansNo1, string referansNo2, string referansNo3, int? foyDurumID
                   , DateTime? davaTarihi, int? adliBirimAdliyeID, int? adliBirimNoID, int? adliBirimGorevID
                   , string esasNo, int? davaOzelKod1, int? davaOzelKod2, int? davaOzelKod3, int? davaOzelKod4
                   , int? temsilVekilID, bool? leyhmi, int? subeKodID, DateTime? celseTarihi, DateTime? kesifTarihi, string con, int Leyh, string ZamanDilimi, string KararNo, object KararTarihi)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            string where = " where a.ID<>-1";

            if (sorumluAvukatCariID.HasValue)
            {
                cn.AddParams("@SORUMLU_AVUKAT_CARI_ID", sorumluAvukatCariID.Value);
                where += " and a.SORUMLU_AVUKAT_CARI_ID=@SORUMLU_AVUKAT_CARI_ID";
            }

            if (!string.IsNullOrEmpty(dnReferansNo1))
            {
                cn.AddParams("@REFERANS_NO", dnReferansNo1);
                where += " and a.REFERANS_NO like '%' + @REFERANS_NO + '%'";
            }
            if (!string.IsNullOrEmpty(dnReferansNo2))
            {
                cn.AddParams("@REFERANS_NO2", dnReferansNo2);
                where += " and a.REFERANS_NO2 like '%' + @REFERANS_NO2 + '%'";
            }
            if (!string.IsNullOrEmpty(referansNo3))
            {
                cn.AddParams("@REFERANS_NO3", referansNo3);
                where += " and a.REFERANS_NO3 like '%' + @REFERANS_NO3 + '%'";
            }

            if (davaTalepID.HasValue)
            {
                cn.AddParams("@DAVA_TALEP_ID", davaTalepID.Value);
                where += " and b.DAVA_TALEP_ID=@DAVA_TALEP_ID";
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
            if (foyDurumID.HasValue)
            {
                cn.AddParams("@FOY_DURUM_ID", foyDurumID.Value);
                where += " and b.FOY_DURUM_ID=@FOY_DURUM_ID";
            }

            if (adliBirimAdliyeID.HasValue)
            {
                cn.AddParams("@ADLI_BIRIM_ADLIYE_ID", adliBirimAdliyeID.Value);
                where += " and b.ADLI_BIRIM_ADLIYE_ID=@ADLI_BIRIM_ADLIYE_ID";
            }

            if (adliBirimGorevID.HasValue)
            {
                cn.AddParams("@ADLI_BIRIM_GOREV_ID", adliBirimGorevID);
                where += " and b.ADLI_BIRIM_GOREV_ID=@ADLI_BIRIM_GOREV_ID";
            }

            if (adliBirimNoID.HasValue)
            {
                cn.AddParams("@ADLI_BIRIM_NO_ID", adliBirimNoID.Value);
                where += " and b.ADLI_BIRIM_NO_ID=@ADLI_BIRIM_NO_ID";
            }

            if (!string.IsNullOrEmpty(esasNo))
            {
                cn.AddParams("@ESAS_NO", esasNo);
                where += " and a.ESAS_NO like '%' + @ESAS_NO + '%'";
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

                cn.AddParams("@ESAS_NO2", esasNo);
                where += " and a.ESAS_NO like '%' + @ESAS_NO2 + '%'";
            }
            if (davaOzelKod1.HasValue)
            {
                cn.AddParams("@DAVA_OZEL_KOD1_ID", davaOzelKod1);
                where += " and b.DAVA_OZEL_KOD1_ID=@DAVA_OZEL_KOD1_ID";
            }

            if (davaOzelKod2.HasValue)
            {
                cn.AddParams("@DAVA_OZEL_KOD2_ID", davaOzelKod2);
                where += " and b.DAVA_OZEL_KOD2_ID=@DAVA_OZEL_KOD2_ID";
            }

            if (davaOzelKod3.HasValue)
            {
                cn.AddParams("@DAVA_OZEL_KOD3_ID", davaOzelKod3);
                where += " and b.DAVA_OZEL_KOD3_ID=@DAVA_OZEL_KOD3_ID";
            }

            if (davaOzelKod4.HasValue)
            {
                cn.AddParams("@DAVA_OZEL_KOD4_ID", davaOzelKod4);
                where += " and b.DAVA_OZEL_KOD4_ID=@DAVA_OZEL_KOD4_ID";
            }

            if (tarafCariID.HasValue)
            {
                cn.AddParams("@tarafCariID", tarafCariID.Value);
                where += " and a.ID in (select DAVA_FOY_ID from dbo.AV001_TD_BIL_FOY_TARAF where CARI_ID=@tarafCariID)";
            }

            if (temsilVekilID.HasValue)
            {
                //cn.AddParams("@temsilVekilID", temsilVekilID.Value);
                //where += " and a.ID in (select DAVA_FOY_ID from dbo.AV001_TD_BIL_FOY_TARAF_VEKIL where AVUKAT_CARI_ID=@temsilVekilID)";

                cn.AddParams("@tarafVekilID", temsilVekilID.Value);
                where += " and a.ID in (select DAVA_FOY_ID from dbo.AV001_TD_BIL_FOY_TARAF(nolock) where ID in (select FOY_TARAF_ID from dbo.AV001_TD_BIL_FOY_TARAF_VEKIL(nolock) where AVUKAT_CARI_ID=@tarafVekilID))";
            }

            if (Leyh == 0)
                where += " and (SELECT HANGI_TARAFI FROM dbo.TDIE_KOD_TARAF_SIFAT WHERE ID = (SELECT top(1)TARAF_SIFAT_ID FROM dbo.AV001_TD_BIL_FOY_TARAF WHERE DAVA_FOY_ID=A.ID AND TARAF_KODU=1))='DAVA EDEN'";
            else if (Leyh == 1)
                where += " and (SELECT HANGI_TARAFI FROM dbo.TDIE_KOD_TARAF_SIFAT WHERE ID = (SELECT top(1)TARAF_SIFAT_ID FROM dbo.AV001_TD_BIL_FOY_TARAF WHERE DAVA_FOY_ID=A.ID AND TARAF_KODU=1))='DAVA EDİLEN'";

            if (davaTarihi.HasValue)
            {
                cn.AddParams("@DAVA_TARIHI", davaTarihi.Value);
                cn.AddParams("@DAVA_TARIHI2", davaTarihi.Value.AddDays(1));
                where += " and a.DAVA_TARIHI>=@DAVA_TARIHI and a.DAVA_TARIHI<@DAVA_TARIHI2";
            }
            if (subeKodID.HasValue)
            {
                cn.AddParams("@SUBE_KOD_ID", subeKodID.Value);
                where += " and a.SUBE_KOD_ID=@SUBE_KOD_ID";
            }

            if (celseTarihi.HasValue)
            {
                cn.AddParams("@TARIH", celseTarihi);
                cn.AddParams("@TARIH2", celseTarihi.Value.AddDays(1));
                where += " and a.ID in (select DAVA_FOY_ID from dbo.AV001_TD_BIL_CELSE where TARIH>=@TARIH and TARIH<@TARIH2)";
            }
            if (kesifTarihi.HasValue)
            {
                cn.AddParams("@kesifTarihi", kesifTarihi);
                cn.AddParams("@kesifTarihi2", kesifTarihi.Value.AddDays(1));
                where += " and a.ID in (select DAVA_FOY_ID from dbo.AV001_TD_BIL_CELSE where TARIH>=@kesifTarihi and TARIH<@kesifTarihi2)";
            }

            if (!davaTarihi.HasValue)
            {
                if (ZamanDilimi != "Tumu")
                    where += Metotlar.ZamanDilimiParametresiOlustur(cn, "DAVA_TARIHI", ZamanDilimi).Replace(" DAVA_TARIHI", " a.DAVA_TARIHI");
            }

            string where2 = "";
            string where3 = "";
            if (adliBirimAdliyeID.HasValue || adliBirimNoID.HasValue || !string.IsNullOrEmpty(esasNo) || adliBirimGorevID.HasValue)
            {
                where2 = " or a.ID IN (SELECT dus.DAVA_FOY_ID FROM dbo.AV001_TD_BIL_DUSME_YENILEME(nolock) dus WHERE dus.DAVA_FOY_ID<>-1";
                where3 = " or a.ID IN (SELECT tem.DAVA_FOY_ID FROM dbo.AV001_TD_BIL_TEMYIZ(nolock) tem WHERE tem.DAVA_FOY_ID<>-1";

                if (adliBirimAdliyeID.HasValue)
                {
                    where2 += " and dus.ADLI_BIRIM_ADLIYE_ID=@ADLI_BIRIM_ADLIYE_ID";
                    where3 += " and tem.ADLI_BIRIM_ADLIYE_ID=@ADLI_BIRIM_ADLIYE_ID";
                }

                if (adliBirimGorevID.HasValue)
                {
                    where2 += " and dus.ADLI_BIRIM_GOREV_ID=@ADLI_BIRIM_GOREV_ID";
                    where3 += " and tem.ADLI_BIRIM_GOREV_ID=@ADLI_BIRIM_GOREV_ID";
                }

                if (adliBirimNoID.HasValue)
                {
                    where2 += " and dus.ADLI_BIRIM_NO_ID=@ADLI_BIRIM_NO_ID";
                    where3 += " and tem.ADLI_BIRIM_NO_ID=@ADLI_BIRIM_NO_ID";
                }

                if (!string.IsNullOrEmpty(esasNo))
                {
                    where2 += " and dus.ESKI_DAVA_DOSYA_NO like '%' + @ESAS_NO + '%'";
                    where3 += " and tem.ESAS_NO like '%' + @ESAS_NO + '%'";
                }

                where2 += ")";
                where3 += ")";
            }

            if (!string.IsNullOrEmpty(KararNo) || KararTarihi != null)
            {
                where += " and (a.ID IN (SELECT huk.DAVA_FOY_ID FROM dbo.AV001_TD_BIL_MAHKEME_HUKUM(NOLOCK) huk WHERE huk.ID<>-1";

                if (!string.IsNullOrEmpty(KararNo))
                {
                    cn.AddParams("@KARAR_NO", KararNo);
                    where += " and huk.KARAR_NO=@KARAR_NO";
                }

                if (KararTarihi != null)
                {
                    cn.AddParams("@HUKUM_TARIHI", KararTarihi);
                    cn.AddParams("@HUKUM_TARIHI2", Convert.ToDateTime(KararTarihi).AddDays(1));
                    where += " and huk.HUKUM_TARIHI>=@HUKUM_TARIHI and huk.HUKUM_TARIHI<@HUKUM_TARIHI2";
                }

                where += ")";

                where += " or a.ID IN (SELECT tem.DAVA_FOY_ID FROM dbo.AV001_TD_BIL_TEMYIZ(NOLOCK) tem WHERE tem.ID<>-1";

                if (!string.IsNullOrEmpty(KararNo))
                    where += " and tem.KARAR_NO=@KARAR_NO";

                if (KararTarihi != null)
                    where += " and tem.KARAR_TARIHI>=@HUKUM_TARIHI and tem.KARAR_TARIHI<@HUKUM_TARIHI2";

                where += "))";
            }

            return cn.GetDataTable("select convert(bit,0) as IsSelected, a.FOY_NO, b.FOY_DURUM_ID, a.DAVA_TARIHI, a.ESAS_NO, a.AVUKATA_INTIKAL_TARIHI, a.ACIKLAMA, a.KAYIT_TARIHI, a.DAVA_DEGERI, a.DAVA_DEGERI_DOVIZ_ID, a.ISLEMIS_FAIZ, a.ISLEMIS_FAIZ_DOVIZ_ID, a.DAVA_ONCESI_TOPLAM_DOVIZ_ID, a.SONRAKI_FAIZ, a.SONRAKI_FAIZ_DOVIZ_ID, a.TOPLAM_ALACAK, a.TOPLAM_ALACAK_DOVIZ_ID, a.KALAN_ALACAK, a.KALAN_ALACAK_DOVIZ_ID, b.DEPARTMANA_INTIKAL_TARIHI, a.SORUMLU, a.IZLEYEN, DAVA_EDEN_SIFAT, a.DAVA_EDEN_TARAF_KODU as DAVA_EDEN_TK, a.DAVA_EDEN_CARI_ID, a.DAVA_EDILEN_SIFAT, a.DAVA_EDILEN_TARAF_KODU as DAVA_EDILEN_TK, a.DAVA_EDILEN_CARI_ID, a.REFERANS_NO, a.REFERANS_NO2, a.REFERANS_NO3, a.DURUSMA_TARIHI, a.KESIF_TARIHI, a.ADLI_BIRIM_ADLIYE, a.ADLI_BIRIM_GOREV, a.ADLI_BIRIM_NO, e1.KOD as GOZEL_KOD1, e2.KOD as GOZEL_KOD2, e3.KOD as GOZEL_KOD3, e4.KOD as GOZEL_KOD4, a.DAVA_TALEP as GDAVA_TALEP, a.DAVA_TIP as GDAVA_TIP, c.SUBE_ADI as BURO, d.SEGMENT as BOLUM, b.FOY_ARSIV_TARIHI, b.FOY_FERAGAT_TARIHI, b.SULH_TARIHI, b.ZAMAN_ASIMI_ILE_INFAZ_TARIHI, b.KURUL_KARARI_ILE_KAPAMA_TARIHI, b.KAPAMA_TARIHI, b.ESKI_RAF_NO, a.ID, b.CEZAI_SART_TOPLAMI from R_DAVA_GENEL_ARAMA(nolock) a inner join dbo.AV001_TD_BIL_FOY(nolock) b on b.ID=a.ID left join dbo.TDIE_BIL_KULLANICI_SUBELERI (nolock) c on c.ID=a.SUBE_KOD_ID left join dbo.TDI_KOD_SEGMENT(nolock) d on d.ID=b.SEGMENT_ID left join dbo.AV001_TDI_KOD_FOY_OZEL(nolock) e1 on e1.ID=b.DAVA_OZEL_KOD1_ID left join dbo.AV001_TDI_KOD_FOY_OZEL(nolock) e2 on e2.ID=b.DAVA_OZEL_KOD2_ID left join dbo.AV001_TDI_KOD_FOY_OZEL(nolock) e3 on e3.ID=b.DAVA_OZEL_KOD3_ID left join dbo.AV001_TDI_KOD_FOY_OZEL(nolock) e4 on e4.ID=b.DAVA_OZEL_KOD4_ID" + where + where2 + where3);
        }
    }
}