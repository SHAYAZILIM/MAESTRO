using AvukatProLib;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AvukatPro.Services.Implementations
{
    public static class MasrafAvansService //: BaseService, AvukatPro.Services.Interfaces.IMasrafAvansService
    {
        private static string kolonlar = "ID as Id, SEGMENT_ID as SegmentId, MODUL_ID as ModulId, MASRAF_AVANS_TIP as MasrafAvansTip, BORC_ALACAK_ID as BorcAlacakId, ADET as Adet, BIRIM_FIYAT as BirimFiyat, BIRIM_FIYAT_DOVIZ_ID as BirimFiyatDovizId, TOPLAM_TUTAR as ToplamTutar, KDV_TUTAR as KdvTutar, STOPAJ_SSDF_TUTAR as StopajSsdfTutar, GENEL_TOPLAM as GenelToplam, BANKA_DEKONT_NO as BankaDekontNo, EFT_REFERANS_NO as EftReferansNo, REFERANS_NO as ReferansNo, HAREKET_ALT_KATEGORI_ID as HareketAltKategoriId, FOY_NO as FoyNo, ADLI_BIRIM_ADLIYE_ID as AdliBirimAdliyeId, ADLI_BIRIM_NO_ID as AdliBirimNoId, ADLI_BIRIM_GOREV_ID as AdliBirimGorevId, ESAS_NO as EsasNo, HAREKET_ANA_KATEGORI_ID as HareketAnaKategoriId, MUHATAP_HESAP_SAHIBI_CARI_BANKA_ID as MuhatapHesapSahibiCariBankaId, BURO_HESAP_SAHIBI_CARI_BANKA_ID as KasaHesapSahibiCariBankaId,  KIYMETLI_EVRAK_ID as KiymetliEvrakId, TARIH as Tarih, MUVEKKIL_CARI_ID as MuvekkilCariId, DETAY_ACIKLAMA as DetayAciklama, CARI_ID as CariId, ODEME_TIP_ID as OdemeTipId,MASRAF_AVANS_DETAY_ID as MasrafAvansDetayId, KAYIT_ID as KayitId,INCELENDI as Incelendi";

        //    return sonuc;
        //}
        public static DataTable GetAllMasraf()
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlar + " from dbo.R_MASRAF_AVANS_DETAYLI2");

            return sonuc;
        }

        public static DataTable GetAllMasrafByDavaFoyId(int davaFoyId)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlar + " from dbo.R_MASRAF_AVANS_DETAYLI2 where MODUL_ID=2 and KAYIT_ID=" + davaFoyId);

            return sonuc;
        }

        public static DataTable GetAllMasrafByFiltre(Messaging.GetMasrafAvansByFiltreRequest request, string ZamanDilimi)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            string where = " where MODUL_ID<>-1";

            if (request.Modul.HasValue)
            {
                cn.AddParams("@MODUL_ID", (int)request.Modul);
                where += " and MODUL_ID=@MODUL_ID";

                if (request.DosyaIds.Count > 0)
                {
                    where += " and KAYIT_ID in (-1";
                    foreach (var id in request.DosyaIds)
                    {
                        where += "," + id;
                    }
                    where += ")";
                }
            }
            if (request.MasrafAvansTip.HasValue)
            {
                cn.AddParams("@MASRAF_AVANS_TIP", request.MasrafAvansTip);
                where += " and MASRAF_AVANS_TIP=@MASRAF_AVANS_TIP";
            }
            if (request.CariID.HasValue)
            {
                cn.AddParams("@CARI_ID", request.CariID);
                where += " and CARI_ID=@CARI_ID";
            }

            if (!string.IsNullOrEmpty(request.ReferansNo))
            {
                cn.AddParams("@REFERANS_NO", request.ReferansNo);
                where += " and REFERANS_NO=@REFERANS_NO";
            }

            if (!string.IsNullOrEmpty(request.BelgeNo))
            {
                cn.AddParams("@KULLANICI_BELGE_NO", request.BelgeNo);
                where += " and KULLANICI_BELGE_NO=@KULLANICI_BELGE_NO";
            }

            if (request.MasrafTarihi.HasValue)
            {
                cn.AddParams("@TARIH", request.MasrafTarihi);
                where += " and TARIH=@TARIH";
            }

            if (request.Muvekkil.HasValue)
            {
                cn.AddParams("@MUVEKKIL_CARI_ID", request.Muvekkil);
                where += " and MUVEKKIL_CARI_ID=@MUVEKKIL_CARI_ID";
            }

            if (request.AltKategori.HasValue)
            {
                cn.AddParams("@HAREKET_ALT_KATEGORI_ID", request.AltKategori);
                where += " and HAREKET_ALT_KATEGORI_ID=@HAREKET_ALT_KATEGORI_ID";
            }

            if (request.AnaKategori.HasValue)
            {
                cn.AddParams("@HAREKET_ANA_KATEGORI_ID", request.AnaKategori);
                where += " and HAREKET_ANA_KATEGORI_ID=@HAREKET_ANA_KATEGORI_ID";
            }

            if (request.BorcAlacak.HasValue)
            {
                cn.AddParams("@BORC_ALACAK_ID", request.BorcAlacak);
                where += " and BORC_ALACAK_ID=@BORC_ALACAK_ID";
            }

            if (ZamanDilimi != "Tumu")
            {
                if (!request.MasrafTarihi.HasValue)
                {
                    where += Metotlar.ZamanDilimiParametresiOlustur(cn, "TARIH", ZamanDilimi);
                }
            }

            sonuc = cn.GetDataTable("select " + kolonlar + " from dbo.R_MASRAF_AVANS_DETAYLI2" + where);

            return sonuc;
        }

        //    if (request.BorcAlacak.HasValue)
        //        sonuc = sonuc.Where(m => m.BorcAlacakId == request.BorcAlacak).ToList();
        public static DataTable GetAllMasrafByIcraFoyId(int icraFoyId)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlar + " from dbo.R_MASRAF_AVANS_DETAYLI2 where MODUL_ID=1 and KAYIT_ID=" + icraFoyId);

            return sonuc;
        }

        //    if (request.AnaKategori.HasValue)
        //        sonuc = sonuc.Where(m => m.HareketAnaKategoriId == request.AnaKategori).ToList();
        public static DataTable GetAllMasrafBySorusturmaFoyId(int sorusturmaFoyId)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlar + " from dbo.R_MASRAF_AVANS_DETAYLI2 where MODUL_ID=3 and KAYIT_ID=" + sorusturmaFoyId);

            return sonuc;
        }

        //    if (request.AltKategori.HasValue)
        //        sonuc = sonuc.Where(m => m.HareketAltKategoriId == request.AltKategori).ToList();
        public static DataTable GetAllMasrafBySozlesmeFoyId(int sozlesmeFoyId)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlar + " from dbo.R_MASRAF_AVANS_DETAYLI2 where MODUL_ID=5 and KAYIT_ID=" + sozlesmeFoyId);

            return sonuc;
        }

        //    if (request.Muvekkil.HasValue)
        //        sonuc = sonuc.Where(m => m.MuvekkilCariId == request.Muvekkil).ToList();
        public static List<Model.EntityClasses.PerTdiKodSegmentEntity> GetAllSegment()
        {
            var sonuc = BaseService._db.PerTdiKodSegment.ToList();

            return sonuc;
        }

        //    if (request.MasrafTarihi.HasValue)
        //        sonuc = sonuc.Where(m => m.Tarih == request.MasrafTarihi).ToList();
        public static List<Model.EntityClasses.RMasrafAvansDetayli2Entity> GetMasrafAvansViewByDetayId(int masrafAvansDetayId)
        {
            return BaseService._db.RMasrafAvansDetayli2.Where(m => m.Id == masrafAvansDetayId).ToList();
        }

        public static Model.EntityClasses.Av001TdiBilMasrafAvanEntity GetMasrafById(int masrafAvansId)
        {
            var sonuc = BaseService._db.Av001TdiBilMasrafAvan.Where(m => m.Id == masrafAvansId).FirstOrDefault();

            return sonuc;
        }

        public static void Save(Model.EntityClasses.Av001TdiBilMasrafAvanEntity entity)
        {
            entity.Save();
        }

        public static void SaveDetay(Model.EntityClasses.Av001TdiBilMasrafAvansDetayEntity entity)
        {
            entity.Save();
        }

        public static void SaveProjeMasraf(Model.EntityClasses.Av001TdieBilProjeMasrafAvanEntity entity)
        {
            entity.Save();
        }

        public static void Update(Model.EntityClasses.Av001TdiBilMasrafAvansDetayEntity entity)
        {
            entity.Save();
        }

        //aykut hızlandırma 25.01.2013
        //public static List<Model.EntityClasses.RMasrafAvansDetayli2Entity> GetAllMasraf()
        //{
        //    var sonuc = BaseService._db.RMasrafAvansDetayli2.ToList();

        //    return sonuc;
        //}

        //public static List<Model.EntityClasses.RMasrafAvansDetayli2Entity> GetAllMasrafByIcraFoyId(int icraFoyId)
        //{
        //    var sonuc = BaseService._db.RMasrafAvansDetayli2.Where(m => m.KayitId == icraFoyId && m.ModulId == 1).ToList();

        //    return sonuc;
        //}

        //public static List<Model.EntityClasses.RMasrafAvansDetayli2Entity> GetAllMasrafByDavaFoyId(int davaFoyId)
        //{
        //    var sonuc = BaseService._db.RMasrafAvansDetayli2.Where(m => m.KayitId == davaFoyId && m.ModulId == 2).ToList();

        //    return sonuc;
        //}

        //public static List<Model.EntityClasses.RMasrafAvansDetayli2Entity> GetAllMasrafBySorusturmaFoyId(int sorusturmaFoyId)
        //{
        //    var sonuc = BaseService._db.RMasrafAvansDetayli2.Where(m => m.KayitId == sorusturmaFoyId && m.ModulId == 3).ToList();

        //    return sonuc;
        //}

        //public static List<Model.EntityClasses.RMasrafAvansDetayli2Entity> GetAllMasrafBySozlesmeFoyId(int sozlesmeFoyId)
        //{
        //    var sonuc = BaseService._db.RMasrafAvansDetayli2.Where(m => m.KayitId == sozlesmeFoyId && m.ModulId == 5).ToList();

        //    return sonuc;
        //}

        //public static DataTable GetAllMasrafByFiltre(Messaging.GetMasrafAvansByFiltreRequest request)
        //{
        //    List<AvukatPro.Model.EntityClasses.RMasrafAvansDetayli2Entity> sonuc = BaseService._db.RMasrafAvansDetayli2.ToList();

        //    if (request.Modul.HasValue)
        //    {
        //        sonuc = sonuc.Where(m => m.ModulId == (int)request.Modul).ToList();

        //        if (request.DosyaIds.Count > 0)
        //        {
        //            List<AvukatPro.Model.EntityClasses.RMasrafAvansDetayli2Entity> yeniSonuc = new List<AvukatPro.Model.EntityClasses.RMasrafAvansDetayli2Entity>();
        //            foreach (var id in request.DosyaIds)
        //            {
        //                yeniSonuc.AddRange(BaseService._db.RMasrafAvansDetayli2.Where(m => m.KayitId == id).ToList());
        //            }
        //            sonuc = yeniSonuc;
        //        }
        //    }
        //    if (request.MasrafAvansTip.HasValue)
        //        sonuc = sonuc.Where(m => m.MasrafAvansTip == request.MasrafAvansTip).ToList();

        //    if (request.CariID.HasValue)
        //        sonuc = sonuc.Where(m => m.CariId == request.CariID).ToList();

        //    if (!string.IsNullOrEmpty(request.ReferansNo))
        //        sonuc = sonuc.Where(m => m.ReferansNo == request.ReferansNo).ToList();

        //    if (!string.IsNullOrEmpty(request.BelgeNo))
        //        sonuc = sonuc.Where(m => m.KullaniciBelgeNo == request.BelgeNo).ToList();
    }
}