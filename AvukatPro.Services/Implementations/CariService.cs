using AvukatProLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AvukatPro.Services.Implementations
{
    public static class CariService //: BaseService, AvukatPro.Services.Interfaces.ICariService
    {
        private static string kolonlarMuv = "h.ID as Id, h.CARI_ID AS CariId, h.SEGMENT_ID AS SegmentId, h.CARI_HESAP_HEDEF_TIP AS CariHesapHedefTip, h.MASRAF_AVANS_ID AS MASRAF_AVANS_ID, h.TARIH AS Tarih, h.BORC_ALACAK_ID AS BorcAlacakId, h.ADET AS Adet, h.BIRIM_FIYAT AS BirimFiyat, h.BIRIM_FIYAT_DOVIZ_ID AS BirimFiyatDovizId, h.TOPLAM_TUTAR AS ToplamTutar, h.KDV_TUTAR AS KdvTutar, h.STOPAJ_SSDF_TUTAR AS StopajSsdfTutar, h.GENEL_TOPLAM AS GenelToplam, h.BANKA_DEKONT_NO AS BankaDekontNo, h.EFT_REFERANS_NO AS EftReferansNo, h.REFERANS_NO AS ReferansNo, h.ODEME_TIP_ID AS OdemeTipId, h.HAREKET_ALT_KAREGORI_ID AS HareketAltKaregoriId, h.FOY_NO AS FoyNo, h.ADLI_BIRIM_ADLIYE_ID AS AdliBirimAdliyeId, h.ADLI_BIRIM_NO_ID AS AdliBirimNoId, h.ADLI_BIRIM_GOREV_ID AS AdliBirimGorevId, h.ESAS_NO AS EsasNo, h.BURO_HESAP_SAHIBI_CARI_ID AS KasaHesapSahibiCariBankaId, h.MUHATAP_HESAP_SAHIBI_CARI_ID AS MuhatapHesapSahibiCariBankaId, h.KIYMETLI_EVRAK_ID AS KiymetliEvrakId, h.HAREKET_ANA_KATEGORI_ID AS HareketAnaKategoriId, h.KAYIT_TARIHI AS KayitTarihi, h.KONTROL_KIM_ID as KontrolKimId, h.FOY_ID AS FoyId, h.HESAP_DETAY_ID HesapDetayId, h.ACIKLAMA Aciklama";

        private static string kolonlarPer = "h.ID as Id, h.CARI_ID AS CariId, h.SEGMENT_ID AS SegmentId, h.CARI_HESAP_HEDEF_TIP AS CariHesapHedefTip, h.MASRAF_AVANS_ID AS MASRAF_AVANS_ID, h.TARIH AS Tarih, h.BORC_ALACAK_ID AS BorcAlacakId, h.ADET AS Adet, h.BIRIM_FIYAT AS BirimFiyat, h.BIRIM_FIYAT_DOVIZ_ID AS BirimFiyatDovizId, h.TOPLAM_TUTAR AS ToplamTutar, h.KDV_TUTAR AS KdvTutar, h.STOPAJ_SSDF_TUTAR AS StopajSsdfTutar, h.GENEL_TOPLAM AS GenelToplam, h.BANKA_DEKONT_NO AS BankaDekontNo, h.EFT_REFERANS_NO AS EftReferansNo, h.REFERANS_NO AS ReferansNo, h.ODEME_TIP_ID AS OdemeTipId, h.HAREKET_ALT_KAREGORI_ID AS HareketAltKaregoriId, h.FOY_NO AS FoyNo, h.ADLI_BIRIM_ADLIYE_ID AS AdliBirimAdliyeId, h.ADLI_BIRIM_NO_ID AS AdliBirimNoId, h.ADLI_BIRIM_GOREV_ID AS AdliBirimGorevId, h.ESAS_NO AS EsasNo, h.BURO_HESAP_SAHIBI_CARI_ID AS KasaHesapSahibiCariBankaId, h.MUHATAP_HESAP_SAHIBI_CARI_ID AS MuhatapHesapSahibiCariBankaId, h.KIYMETLI_EVRAK_ID AS KiymetliEvrakId, h.HAREKET_ANA_KATEGORI_ID AS HareketAnaKategoriId, h.KAYIT_TARIHI AS KayitTarihi, h.KONTROL_KIM_ID as KontrolKimId,h.INCELENDI as Incelendi, h.ONAY_TARIHI as OnayTarihi, h.ONAY_NO as OnayNo, h.ONAY_DURUM as OnayDurum, h.FOY_ID AS FoyId, h.HESAP_DETAY_ID HesapDetayId, convert(bit,0) as IsSelected, h.ACIKLAMA Aciklama";

        public static DataTable CariHesabiFiltreleMasrafOnay(AvukatPro.Services.Messaging.GetCariHesapDetayRequest request)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            string where = " where h.PERSONEL_MI <> -1";

            //if (request.)
            //    where += " where h.PERSONEL_MI=1";
            //else
            //    where += " where h.MUVEKKIL_MI=1";

            if (request.Modul.HasValue)
            {
                cn.AddParams("@CARI_HESAP_HEDEF_TIP", (int)request.Modul);
                where += " and h.CARI_HESAP_HEDEF_TIP=@CARI_HESAP_HEDEF_TIP";

                if (request.DosyaIDs.Count > 0)
                {
                    where += " and h.FOY_ID in (-1";
                    foreach (var id in request.DosyaIDs)
                    {
                        where += "," + id;
                    }
                    where += ")";
                }
            }

            if (request.Cari.HasValue)
            {
                cn.AddParams("@CARI_ID", request.Cari);
                where += " and h.CARI_ID=@CARI_ID";
            }

            if (request.BorcAlacak.HasValue)
            {
                cn.AddParams("@BORC_ALACAK_ID", request.BorcAlacak);
                where += " and h.BORC_ALACAK_ID=@BORC_ALACAK_ID";
            }

            if (request.AnaKategori.HasValue)
            {
                cn.AddParams("@HAREKET_ANA_KATEGORI_ID", request.AnaKategori);
                where += " and h.HAREKET_ANA_KATEGORI_ID=@HAREKET_ANA_KATEGORI_ID";
            }

            if (request.AltKategori.HasValue)
            {
                cn.AddParams("@HAREKET_ALT_KAREGORI_ID", request.AltKategori);
                where += " and h.HAREKET_ALT_KAREGORI_ID=@HAREKET_ALT_KAREGORI_ID";
            }

            if (request.Buro.HasValue)
            {
                cn.AddParams("@SUBE_KOD_ID", request.Buro);
                where += " and h.SUBE_KOD_ID=@SUBE_KOD_ID";
            }

            if (request.OdemeTip.HasValue)
            {
                cn.AddParams("@ODEME_TIP_ID", request.OdemeTip);
                where += " and h.ODEME_TIP_ID=@ODEME_TIP_ID";
            }

            if (request.OnayTarihi.HasValue)
            {
                cn.AddParams("@ONAY_TARIHI", request.OnayTarihi.Value.Date);
                where += " and h.ONAY_TARIHI=@ONAY_TARIHI";
            }

            if (request.Tarih.HasValue)
            {
                cn.AddParams("@TARIH", request.Tarih.Value.Date);
                where += " and h.TARIH=@TARIH";
            }

            if (!string.IsNullOrEmpty(request.KullaniciBelgeNo))
            {
                cn.AddParams("@KULLANICI_BELGE_NO", request.KullaniciBelgeNo);
                where += " and h.KULLANICI_BELGE_NO=@KULLANICI_BELGE_NO";
            }

            if (!string.IsNullOrEmpty(request.ReferansNo))
            {
                cn.AddParams("@REFERANS_NO", request.ReferansNo);
                where += " and h.REFERANS_NO=@REFERANS_NO";
            }

            if (request.OnayDurum.HasValue)
            {
                if (request.OnayDurum == 5)
                    where += " and h.ONAY_DURUM in (1,2,3)";
                else
                {
                    cn.AddParams("@ONAY_DURUM", request.OnayDurum);
                    where += " and h.ONAY_DURUM=@ONAY_DURUM";
                }
            }

            sonuc = cn.GetDataTable("select h.HESAP_DETAY_ID as HesapDetayId, CONVERT(bit,0) as IsSelected, a.KOD as Kod, a.AD as Ad, REFERANS_NO as ReferansNo, HAREKET_ANA_KATEGORI_ID as HareketAnaKategoriId, HAREKET_ALT_KAREGORI_ID as HareketAltKaregoriId, ADET as Adet, BIRIM_FIYAT as BirimFiyat, GENEL_TOPLAM as GenelToplam, INCELENDI as Incelendi, ONAY_DURUM as OnayDurum, ONAY_TARIHI as OnayTarihi, ONAY_NO as OnayNo, ACIKLAMA as Aciklama from R_CARI_HESAP_DETAYLI(nolock) h inner join dbo.AV001_TDI_BIL_CARI(nolock) a on a.ID=h.CARI_ID " + where);

            return sonuc;
        }

        public static void CreateCariHesapByMasrafAvans(int masrafAvansId)
        {
            AvukatProLib.Hesap.MuhasebeAraclari.SetCariHesapByMasrafAvans(masrafAvansId);
        }

        public static List<Model.EntityClasses.Av001TdiBilCariBankaEntity> GetAllCariBanka()
        {
            var sonuc = BaseService._db.Av001TdiBilCariBanka.ToList();

            return sonuc;
        }

        public static List<Model.EntityClasses.RCariHesapDetayliEntity> GetAllCariHesapDetayByCariId(int cariId)
        {
            var sonuc = BaseService._db.RCariHesapDetayli.Where(h => h.CariId == cariId).ToList();

            return sonuc;
        }

        public static DataTable GetAllCariHesapDetayByFiltre(Messaging.GetCariHesapDetayRequest request)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlarMuv + " from dbo.R_CARI_HESAP_DETAYLI(nolock) h");

            return CariHesabiFiltrele(request, false, "Tumu");
        }

        public static DataTable GetAllMuvekkilCariHesapDetay()
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlarMuv + " from dbo.R_CARI_HESAP_DETAYLI(nolock) h where MUVEKKIL_MI=1");

            return sonuc;
        }

        public static DataTable GetAllMuvekkilCariHesapDetayByDavaFoyId(int davaFoyId)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlarMuv + " from dbo.R_CARI_HESAP_DETAYLI(nolock) h where FOY_ID=" + davaFoyId + " and CARI_HESAP_HEDEF_TIP=2 and MUVEKKIL_MI=1");

            return sonuc;
        }

        public static DataTable GetAllMuvekkilCariHesapDetayByDavaTaraf(int davaFoyId)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlarMuv + " FROM dbo.R_CARI_HESAP_DETAYLI(nolock) h INNER JOIN dbo.AV001_TD_BIL_FOY(nolock) f on f.ID=" + davaFoyId + " INNER JOIN dbo.AV001_TD_BIL_FOY_TARAF(nolock) t on f.ID=t.DAVA_FOY_ID and t.CARI_ID=h.CARI_ID where MUVEKKIL_MI=1");

            return sonuc;
        }

        public static DataTable GetAllMuvekkilCariHesapDetayByIcraFoyId(int icraFoyId)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlarMuv + " from dbo.R_CARI_HESAP_DETAYLI(nolock) h where FOY_ID=" + icraFoyId + " and CARI_HESAP_HEDEF_TIP=1 and MUVEKKIL_MI=1");

            return sonuc;
        }

        public static DataTable GetAllMuvekkilCariHesapDetayByIcraTaraf(int icraFoyId)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlarMuv + " FROM dbo.R_CARI_HESAP_DETAYLI(nolock) h INNER JOIN dbo.AV001_TI_BIL_FOY(nolock) f on f.ID=" + icraFoyId + " INNER JOIN dbo.AV001_TI_BIL_FOY_TARAF(nolock) t on f.ID=t.ICRA_FOY_ID and t.CARI_ID=h.CARI_ID where MUVEKKIL_MI=1");

            return sonuc;
        }

        public static DataTable GetAllMuvekkilCariHesapDetayBySorusturmaFoyId(int sorusturmaFoyId)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlarMuv + " FROM dbo.R_CARI_HESAP_DETAYLI(nolock) h INNER JOIN dbo.AV001_TD_BIL_HAZIRLIK(nolock) f on f.ID=" + sorusturmaFoyId + " INNER JOIN dbo.AV001_TD_BIL_HAZIRLIK_TARAF(nolock) t on f.ID=t.HAZIRLIK_ID and t.CARI_ID=h.CARI_ID where h.FOY_ID=" + sorusturmaFoyId + " and h.CARI_HESAP_HEDEF_TIP=3 and MUVEKKIL_MI=1");

            return sonuc;
        }

        public static DataTable GetAllMuvekkilCariHesapDetayBySorusturmaTaraf(int sorusturmaFoyId)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlarMuv + " FROM dbo.R_CARI_HESAP_DETAYLI(nolock) h INNER JOIN dbo.AV001_TD_BIL_HAZIRLIK(nolock) f on f.ID=" + sorusturmaFoyId + " INNER JOIN dbo.AV001_TD_BIL_HAZIRLIK_TARAF(nolock) t on f.ID=t.HAZIRLIK_ID and t.CARI_ID=h.CARI_ID where MUVEKKIL_MI=1");

            return sonuc;
        }

        public static DataTable GetAllMuvekkilCariHesapDetayBySozlesmeFoyId(int sozlesmeFoyId)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlarMuv + " FROM dbo.R_CARI_HESAP_DETAYLI(nolock) h INNER JOIN dbo.AV001_TDI_BIL_SOZLESME(nolock) f on f.ID=" + sozlesmeFoyId + " INNER JOIN dbo.AV001_TDI_BIL_SOZLESME_TARAF(nolock) t on f.ID=t.SOZLESME_ID and t.CARI_ID=h.CARI_ID where MUVEKKIL_MI=1 and h.FOY_ID=" + sozlesmeFoyId + " and CARI_HESAP_HEDEF_TIP=5");

            return sonuc;
        }

        //    return CariHesabiFiltrele(sonuc, request);
        //}
        public static DataTable GetAllMuvekkilCariHesapDetayBySozlesmeTaraf(int sozlesmeFoyId)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlarMuv + " FROM dbo.R_CARI_HESAP_DETAYLI(nolock) h INNER JOIN dbo.AV001_TDI_BIL_SOZLESME(nolock) f on f.ID=" + sozlesmeFoyId + " INNER JOIN dbo.AV001_TDI_BIL_SOZLESME_TARAF(nolock) t on f.ID=t.SOZLESME_ID and t.CARI_ID=h.CARI_ID where MUVEKKIL_MI=1");

            return sonuc;
        }

        public static List<Model.EntityClasses.PerAv001TdBilFoyTarafEntity> GetAllMuvekkilFromDavaByFoyId(int foyId)
        {
            var sonuc = BaseService._db.PerAv001TdBilFoyTaraf.Where(t => t.DavaFoyId == foyId && t.TarafKodu == 1).ToList();

            return sonuc;
        }

        public static List<Model.EntityClasses.PerAv001TiBilFoyTarafEntity> GetAllMuvekkilFromIcraByFoyId(int foyId)
        {
            var sonuc = BaseService._db.PerAv001TiBilFoyTaraf.Where(t => t.IcraFoyId == foyId && t.TarafKodu == 1).ToList();

            return sonuc;
        }

        public static List<Model.EntityClasses.PerAv001TdBilHazirlikTarafEntity> GetAllMuvekkilFromSorusturmaByFoyId(int foyId)
        {
            var sonuc = BaseService._db.PerAv001TdBilHazirlikTaraf.Where(t => t.HazirlikId == foyId && t.TarafKodu == 1).ToList();

            return sonuc;
        }

        public static List<Model.EntityClasses.PerAv001TdiBilSozlesmeTarafEntity> GetAllMuvekkilFromSozlesmeByFoyId(int foyId)
        {
            var sonuc = BaseService._db.PerAv001TdiBilSozlesmeTaraf.Where(t => t.SozlesmeId == foyId && t.TarafKodu == 1).ToList();

            return sonuc;
        }

        //aykut hızlandırma 25.01.2013
        //public static List<Model.EntityClasses.RCariHesapDetayliEntity> GetAllPersonelCariHesapDetay()
        //{
        //    return BaseService._db.RCariHesapDetayli.Where(h => h.PersonelMi == true).ToList();
        //}
        public static DataTable GetAllPersonelCariHesapDetay()
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlarMuv + " from dbo.R_CARI_HESAP_DETAYLI(nolock) h where h.PERSONEL_MI=1");

            return sonuc;
        }

        public static List<Model.EntityClasses.Av001TdiBilCariBankaEntity> GetCariBankaById(int cariBankaId)
        {
            var sonuc = BaseService._db.Av001TdiBilCariBanka.Where(b => b.Id == cariBankaId).ToList();

            return sonuc;
        }

        public static Model.EntityClasses.Av001TdiBilCariEntity GetCariByAd(string Ad)
        {
            return BaseService._db.Av001TdiBilCari.Where(c => c.Ad == Ad).FirstOrDefault();
        }

        public static Model.EntityClasses.Av001TdiBilCariEntity GetCariById(int Id)
        {
            return BaseService._db.Av001TdiBilCari.Where(c => c.Id == Id).FirstOrDefault();
        }

        public static Model.EntityClasses.Av001TdiBilCariEntity GetCariByTcKimlikNo(string TcKimlikNo)
        {
            return (from c in BaseService._db.Av001TdiBilCari join k in BaseService._db.Av001TdiBilCariKimlik on c.Id equals k.CariId where k.TcKimlikNo == TcKimlikNo select c).FirstOrDefault();
        }

        public static Model.EntityClasses.Av001TdiBilCariEntity GetCariByVergiNo(string VergiNo)
        {
            return BaseService._db.Av001TdiBilCari.Where(c => c.VergiNo == VergiNo).FirstOrDefault();
        }

        public static Model.EntityClasses.Av001TdiBilCariHesapDetayEntity GetCariHesapById(int Id)
        {
            return BaseService._db.Av001TdiBilCariHesapDetay.Where(h => h.Id == Id).FirstOrDefault();
        }

        public static Model.EntityClasses.RCariHesapDetayliEntity GetCariHesapDetayById(int cariHesapDetayId)
        {
            var sonuc = BaseService._db.RCariHesapDetayli.Where(h => h.HesapDetayId == cariHesapDetayId).Single();

            return sonuc;
        }

        public static Model.EntityClasses.RCariHesapDetayliEntity GetCariHesapDetayliById(int Id)
        {
            var sonuc = BaseService._db.RCariHesapDetayli.Where(c => c.Id == Id).Single();

            return sonuc;
        }

        public static DataTable GetMuvekkilCariHesapDetayByFiltre(Messaging.GetCariHesapDetayRequest request, string ZamanDilimi)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            //sonuc = cn.GetDataTable("select " + kolonlarMuv + " from dbo.R_CARI_HESAP_DETAYLI h where MUVEKKIL_MI=1");

            return CariHesabiFiltrele(request, false, ZamanDilimi);
        }

        public static List<Model.EntityClasses.Av001TdiBilCariBankaEntity> GetPersonelCariBanka()
        {
            var sonuc = (from b in BaseService._db.Av001TdiBilCariBanka join c in BaseService._db.Av001TdiBilCari on b.CariId equals c.Id where c.PersonelMi == true select b).ToList();

            return sonuc;
        }

        //aykut hızlandırma 25.01.2013
        //public static List<Model.EntityClasses.RCariHesapDetayliEntity> GetAllMuvekkilCariHesapDetayByDavaTaraf(int davaFoyId)
        //{
        //    var sonuc = (from f in BaseService._db.Av001TdBilFoy where f.Id == davaFoyId join t in BaseService._db.Av001TdBilFoyTaraf on f.Id equals t.DavaFoyId join h in BaseService._db.RCariHesapDetayli on t.CariId equals h.CariId where h.MuvekkilMi == true select h).ToList();

        //    return sonuc;
        //}
        //public static List<Model.EntityClasses.RCariHesapDetayliEntity> GetAllMuvekkilCariHesapDetayBySozlesmeTaraf(int sozlesmeFoyId)
        //{
        //    var sonuc = (from f in BaseService._db.Av001TdiBilSozlesme where f.Id == sozlesmeFoyId join t in BaseService._db.Av001TdiBilSozlesmeTaraf on f.Id equals t.SozlesmeId join h in BaseService._db.RCariHesapDetayli on t.CariId equals h.CariId where h.MuvekkilMi == true select h).ToList();

        //    return sonuc;
        //}
        //public static List<Model.EntityClasses.RCariHesapDetayliEntity> GetAllMuvekkilCariHesapDetayBySozlesmeFoyId(int sozlesmeFoyId)
        //{
        //    var sonuc = (from f in BaseService._db.Av001TdiBilSozlesme where f.Id == sozlesmeFoyId join t in BaseService._db.Av001TdiBilSozlesmeTaraf on f.Id equals t.SozlesmeId join h in BaseService._db.RCariHesapDetayli on t.CariId equals h.CariId where h.MuvekkilMi == true && h.FoyId == sozlesmeFoyId && h.CariHesapHedefTip == 5 select h).ToList();

        //    return sonuc;
        //}
        //public static List<Model.EntityClasses.RCariHesapDetayliEntity> GetAllMuvekkilCariHesapDetayByIcraTaraf(int icraFoyId)
        //{
        //    var sonuc = (from f in BaseService._db.Av001TiBilFoy where f.Id == icraFoyId join t in BaseService._db.Av001TiBilFoyTaraf on f.Id equals t.IcraFoyId join h in BaseService._db.RCariHesapDetayli on t.CariId equals h.CariId where h.MuvekkilMi == true select h).ToList();

        //    return sonuc;
        //}
        //public static List<Model.EntityClasses.RCariHesapDetayliEntity> GetAllMuvekkilCariHesapDetayBySorusturmaTaraf(int sorusturmaFoyId)
        //{
        //    var sonuc = (from f in BaseService._db.Av001TdBilHazirlik where f.Id == sorusturmaFoyId join t in BaseService._db.Av001TdBilHazirlikTaraf on f.Id equals t.HazirlikId join h in BaseService._db.RCariHesapDetayli on t.CariId equals h.CariId where h.MuvekkilMi == true select h).ToList();

        //    return sonuc;
        //}
        //public static List<Model.EntityClasses.RCariHesapDetayliEntity> GetAllMuvekkilCariHesapDetay()
        //{
        //    var sonuc = BaseService._db.RCariHesapDetayli.Where(h => h.MuvekkilMi == true).ToList();

        //    return sonuc;
        //}
        //public static List<Model.EntityClasses.RCariHesapDetayliEntity> GetAllMuvekkilCariHesapDetayByDavaFoyId(int davaFoyId)
        //{
        //    var sonuc = BaseService._db.RCariHesapDetayli.Where(c => c.FoyId == davaFoyId && c.CariHesapHedefTip == 2 && c.MuvekkilMi == true).ToList();

        //    return sonuc;
        //}
        //public static List<Model.EntityClasses.RCariHesapDetayliEntity> GetAllMuvekkilCariHesapDetayBySorusturmaFoyId(int sorusturmaFoyId)
        //{
        //    var sonuc = (from f in BaseService._db.Av001TdBilHazirlik where f.Id == sorusturmaFoyId join t in BaseService._db.Av001TdBilHazirlikTaraf on f.Id equals t.HazirlikId join h in BaseService._db.RCariHesapDetayli on t.CariId equals h.CariId where h.MuvekkilMi == true && h.FoyId == sorusturmaFoyId && h.CariHesapHedefTip == 3 select h).ToList();

        //    return sonuc;
        //}
        //public static List<Model.EntityClasses.RCariHesapDetayliEntity> GetAllMuvekkilCariHesapDetayByIcraFoyId(int icraFoyId)
        //{
        //    var sonuc = BaseService._db.RCariHesapDetayli.Where(c => c.FoyId == icraFoyId && c.CariHesapHedefTip == 1 && c.MuvekkilMi == true).ToList();

        //    return sonuc;
        //}
        //public static List<Model.EntityClasses.RCariHesapDetayliEntity> GetPersonelCariHesapDetayByFiltre(Messaging.GetCariHesapDetayRequest request)
        //{
        //    var sonuc = BaseService._db.RCariHesapDetayli.Where(h => h.PersonelMi == true && h.OnayDurum.HasValue).ToList();

        //    return CariHesabiFiltrele(sonuc, request);
        //}

        //public static List<Model.EntityClasses.RCariHesapDetayliEntity> GetMuvekkilCariHesapDetayByFiltre(Messaging.GetCariHesapDetayRequest request)
        //{
        //    var sonuc = BaseService._db.RCariHesapDetayli.Where(h => h.MuvekkilMi == true).ToList();
        public static DataTable GetPersonelCariHesapDetayByFiltre(Messaging.GetCariHesapDetayRequest request, string ZamanDilimi)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            //sonuc = cn.GetDataTable("select " + kolonlarPer + " from dbo.R_CARI_HESAP_DETAYLI h where h.PERSONEL_MI=1");

            return CariHesabiFiltrele(request, true, ZamanDilimi);
        }

        //aykut hızlandırma 25.01.2013
        //public static List<Model.EntityClasses.RCariHesapDetayliEntity> GetAllCariHesapDetayByFiltre(Messaging.GetCariHesapDetayRequest request)
        //{
        //    var sonuc = BaseService._db.RCariHesapDetayli.ToList();

        //    return CariHesabiFiltrele(request);
        //}

        //static List<AvukatPro.Model.EntityClasses.RCariHesapDetayliEntity> CariHesabiFiltrele(List<AvukatPro.Model.EntityClasses.RCariHesapDetayliEntity> cariHesapList, AvukatPro.Services.Messaging.GetCariHesapDetayRequest request)
        //{
        //    if (request.Modul.HasValue)
        //    {
        //        cariHesapList = cariHesapList.Where(h => h.CariHesapHedefTip == (int)request.Modul).ToList();
        //        if (request.DosyaIDs != null && request.DosyaIDs.Count > 0)
        //            cariHesapList = cariHesapList.Where(h => request.DosyaIDs.Contains(h.FoyId)).ToList();
        //    }
        //    if (request.Cari.HasValue)
        //        cariHesapList = cariHesapList.Where(h => h.CariId == request.Cari).ToList();
        //    if (request.BorcAlacak.HasValue)
        //        cariHesapList = cariHesapList.Where(h => h.BorcAlacakId == request.BorcAlacak).ToList();
        //    if (request.AnaKategori.HasValue)
        //        cariHesapList = cariHesapList.Where(h => h.HareketAnaKategoriId == request.AnaKategori).ToList();
        //    if (request.AltKategori.HasValue)
        //        cariHesapList = cariHesapList.Where(h => h.HareketAltKaregoriId == request.AltKategori).ToList();
        //    if (request.Buro.HasValue)
        //        cariHesapList = cariHesapList.Where(h => h.SubeKodId == request.Buro).ToList();
        //    if (request.OdemeTip.HasValue)
        //        cariHesapList = cariHesapList.Where(h => h.OdemeTipId == request.OdemeTip).ToList();
        //    if (request.OnayTarihi.HasValue)
        //        cariHesapList = cariHesapList.Where(h => h.OnayTarihi == request.OnayTarihi.Value.Date).ToList();
        //    if (request.Tarih.HasValue)
        //        cariHesapList = cariHesapList.Where(h => h.Tarih == request.Tarih.Value.Date).ToList();
        //    if (!string.IsNullOrEmpty(request.KullaniciBelgeNo))
        //        cariHesapList = cariHesapList.Where(h => h.KullaniciBelgeNo == request.KullaniciBelgeNo).ToList();
        //    if (!string.IsNullOrEmpty(request.ReferansNo))
        //        cariHesapList = cariHesapList.Where(h => h.ReferansNo == request.ReferansNo).ToList();
        //    if (request.OnayDurum.HasValue)
        //    {
        //        if (request.OnayDurum == 5)
        //            cariHesapList = cariHesapList.Where(h => h.OnayDurum == 1 || h.OnayDurum == 2 || h.OnayDurum == 3).ToList();
        //        else
        //            cariHesapList = cariHesapList.Where(h => h.OnayDurum == request.OnayDurum).ToList();
        //    }
        //    //if (request.OnayDurum != null && request.OnayDurum != 1)
        //    //    cariHesapList = cariHesapList.Where(h => h.OnayDurum == request.OnayDurum).ToList();

        //    //else if (request.OnayDurum == 1)
        //    //    cariHesapList = cariHesapList.Where(h => h.OnayDurum == 1 || h.OnayDurum == 2 || h.OnayDurum == 3).ToList();

        public static List<Model.EntityClasses.ViBilIcraTarafGelismeleriEntity> GetTarafGelismeleriByFiltre(Messaging.GetTarafGelismeleriByFiltreRequest request)
        {
            List<Model.EntityClasses.ViBilIcraTarafGelismeleriEntity> sonuc = BaseService._db.ViBilIcraTarafGelismeleri.ToList();

            if (!string.IsNullOrEmpty(request.DosyaNo))
                sonuc = sonuc.Where(g => g.FoyNo == request.DosyaNo).ToList();
            if (!string.IsNullOrEmpty(request.EsasNo))
                sonuc = sonuc.Where(g => g.EsasNo == request.EsasNo).ToList();
            if (request.FormTipID.HasValue)
                sonuc = sonuc.Where(g => g.FormTipId == request.FormTipID).ToList();
            if (request.AdliyeId.HasValue)
                sonuc = sonuc.Where(g => g.AdliBirimAdliyeId == request.AdliyeId).ToList();
            if (request.NoId.HasValue)
                sonuc = sonuc.Where(g => g.AdliBirimNoId == request.NoId).ToList();
            if (request.DosyaDurum.HasValue)
                sonuc = sonuc.Where(g => g.FoyDurumId == request.DosyaDurum).ToList();
            if (!string.IsNullOrEmpty(request.TakipEdilen))
                sonuc = sonuc.Where(g => g.Ad == request.TakipEdilen).ToList();
            if (request.TakipTarihi.HasValue)
                sonuc = sonuc.Where(g => g.TaahhutTarihi == request.TakipTarihi).ToList();
            if (request.KontrolKimID.HasValue)
                sonuc = sonuc.Where(g => g.KontrolKimId == request.KontrolKimID).ToList();
            if (request.SubeKodID.HasValue)
                sonuc = sonuc.Where(g => g.SubeKodId == request.SubeKodID).ToList();

            return sonuc;
        }

        public static void MuvekkilHesabiAcKapat(int muvekkilHesabiId, DateTime? tarih)
        {
            var updateEdilecek = BaseService._db.Av001TiBilMuvekkilHesap.Where(h => h.Id == muvekkilHesabiId).Single();
            if (tarih == null)
                updateEdilecek.HesapKapamaTarihi = null;
            else if (tarih != null)
                updateEdilecek.HesapKapamaTarihi = tarih;
            updateEdilecek.Save();
        }

        public static AvukatProLib.Hesap.ParaVeDovizId SozlesmeVekaletUcretiBorcu(int IcrafoyId)
        {
            AvukatProLib.Hesap.ParaVeDovizId sonuc = new AvukatProLib.Hesap.ParaVeDovizId();

            decimal sozlesmeVekUcreti = BaseService._db.Av001TiBilMuvekkilHesap.Where(h => h.IcraFoyId == IcrafoyId).Select(h => h.ToplamSozlesmeVekaletUcreti).Sum() == null ? 0 : (decimal)BaseService._db.Av001TiBilMuvekkilHesap.Where(h => h.IcraFoyId == IcrafoyId).Select(h => h.ToplamSozlesmeVekaletUcreti).Sum();
            decimal odenen = BaseService._db.RMasrafAvansDetayli2.Where(m => m.KayitId == IcrafoyId && m.ModulId == 1 && m.HareketAltKategoriId == 40).Select(m => m.GenelToplam).Sum();
            var hesap = BaseService._db.Av001TiBilMuvekkilHesap.Where(h => h.IcraFoyId == IcrafoyId).FirstOrDefault();
            if (hesap == null)
                sonuc.DovizId = 1;
            else
                if (hesap.ToplamSozlesmeVekaletUcretiDovizId == null)
                    sonuc.DovizId = 1;
                else
                    sonuc.DovizId = (int)hesap.ToplamSozlesmeVekaletUcretiDovizId;
            sonuc.Para = sozlesmeVekUcreti - odenen;

            return sonuc;
        }

        public static AvukatProLib.Hesap.ParaVeDovizId TakipVekaletUcretiBorcu(int IcrafoyId)
        {
            AvukatProLib.Hesap.ParaVeDovizId sonuc = new AvukatProLib.Hesap.ParaVeDovizId();
            decimal takipVekUcreti = BaseService._db.Av001TiBilMuvekkilHesap.Where(h => h.IcraFoyId == IcrafoyId).Select(h => h.TakipVekaletUcreti).Sum() == null ? 0 : (decimal)BaseService._db.Av001TiBilMuvekkilHesap.Where(h => h.IcraFoyId == IcrafoyId).Select(h => h.TakipVekaletUcreti).Sum();
            decimal odenen = BaseService._db.RMasrafAvansDetayli2.Where(m => m.KayitId == IcrafoyId && m.ModulId == 1 && m.HareketAltKategoriId == 942).Select(m => m.GenelToplam).Sum();
            var hesap = BaseService._db.Av001TiBilMuvekkilHesap.Where(h => h.IcraFoyId == IcrafoyId).FirstOrDefault();
            if (hesap == null)
                sonuc.DovizId = 1;
            else
            {
                if (hesap.TakipVekaletUcretiDovizId == null)
                    sonuc.DovizId = 1;
                else
                    sonuc.DovizId = (int)hesap.TakipVekaletUcretiDovizId;
            }
            sonuc.Para = takipVekUcreti - odenen;

            return sonuc;
        }

        public static void UpdateCariHesapDetay(Model.EntityClasses.Av001TdiBilCariHesapDetayEntity entity)
        {
            entity.Save();
        }

        public static void UpdateCariHesapDetay(List<Model.EntityClasses.Av001TdiBilCariHesapDetayEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Save();
            }
        }

        //    return cariHesapList;
        //}
        private static DataTable CariHesabiFiltrele(AvukatPro.Services.Messaging.GetCariHesapDetayRequest request, bool PersonelMi, string ZamanDilimi)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            string where = "";

            if (PersonelMi)
                where += " where h.PERSONEL_MI=1";
            else
                where += " where h.MUVEKKIL_MI=1";

            if (request.Modul.HasValue)
            {
                cn.AddParams("@CARI_HESAP_HEDEF_TIP", (int)request.Modul);
                where += " and h.CARI_HESAP_HEDEF_TIP=@CARI_HESAP_HEDEF_TIP";

                if (request.DosyaIDs.Count > 0)
                {
                    where += " and h.FOY_ID in (-1";
                    foreach (var id in request.DosyaIDs)
                    {
                        where += "," + id;
                    }
                    where += ")";
                }
            }

            if (request.Cari.HasValue)
            {
                cn.AddParams("@CARI_ID", request.Cari);
                where += " and h.CARI_ID=@CARI_ID";
            }

            if (request.BorcAlacak.HasValue)
            {
                cn.AddParams("@BORC_ALACAK_ID", request.BorcAlacak);
                where += " and h.BORC_ALACAK_ID=@BORC_ALACAK_ID";
            }

            if (request.AnaKategori.HasValue)
            {
                cn.AddParams("@HAREKET_ANA_KATEGORI_ID", request.AnaKategori);
                where += " and h.HAREKET_ANA_KATEGORI_ID=@HAREKET_ANA_KATEGORI_ID";
            }

            if (request.AltKategori.HasValue)
            {
                cn.AddParams("@HAREKET_ALT_KAREGORI_ID", request.AltKategori);
                where += " and h.HAREKET_ALT_KAREGORI_ID=@HAREKET_ALT_KAREGORI_ID";
            }

            if (request.Buro.HasValue)
            {
                cn.AddParams("@SUBE_KOD_ID", request.Buro);
                where += " and h.SUBE_KOD_ID=@SUBE_KOD_ID";
            }

            if (request.OdemeTip.HasValue)
            {
                cn.AddParams("@ODEME_TIP_ID", request.OdemeTip);
                where += " and h.ODEME_TIP_ID=@ODEME_TIP_ID";
            }

            if (request.OnayTarihi.HasValue)
            {
                cn.AddParams("@ONAY_TARIHI", request.OnayTarihi.Value.Date);
                where += " and h.ONAY_TARIHI=@ONAY_TARIHI";
            }

            if (request.Tarih.HasValue)
            {
                cn.AddParams("@TARIH", request.Tarih.Value.Date);
                where += " and h.TARIH=@TARIH";
            }

            if (!string.IsNullOrEmpty(request.KullaniciBelgeNo))
            {
                cn.AddParams("@KULLANICI_BELGE_NO", request.KullaniciBelgeNo);
                where += " and h.KULLANICI_BELGE_NO=@KULLANICI_BELGE_NO";
            }

            if (!string.IsNullOrEmpty(request.ReferansNo))
            {
                cn.AddParams("@REFERANS_NO", request.ReferansNo);
                where += " and h.REFERANS_NO=@REFERANS_NO";
            }

            if (request.OnayDurum.HasValue)
            {
                if (request.OnayDurum == 5)
                    where += " and h.ONAY_DURUM in (1,2,3)";
                else
                {
                    cn.AddParams("@ONAY_DURUM", request.OnayDurum);
                    where += " and h.ONAY_DURUM=@ONAY_DURUM";
                }
            }

            if (ZamanDilimi != "Tumu")
            {
                if (!request.Tarih.HasValue)
                {
                    where += Metotlar.ZamanDilimiParametresiOlustur(cn, "TARIH", ZamanDilimi).Replace(" TARIH", " h.TARIH");
                }
            }

            sonuc = cn.GetDataTable("select " + (PersonelMi ? kolonlarPer : kolonlarMuv) + " from dbo.R_CARI_HESAP_DETAYLI(nolock) h" + where);

            return sonuc;
        }
    }
}