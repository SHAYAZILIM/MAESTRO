using AvukatProLib;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AvukatPro.Services.Implementations
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MuhasebeService" in both code and config file together.
    public static class MuhasebeService //: BaseService, AvukatPro.Services.Interfaces.IMuhasebeService
    {
        private static string kolonlar = "ID as Id, SEGMENT_ID as SegmentId, MUHASEBE_HEDEF_TIP as MuhasebeHedefTip, BORC_ALACAK_ID as BorcAlacakId, ADET as Adet, BIRIM_FIYAT as BirimFiyat, BIRIM_FIYAT_DOVIZ_ID as BirimFiyatDovizId, TOPLAM_TUTAR as ToplamTutar, KDV_TUTAR as KdvTutar, STOPAJ_SSDF_TUTAR as StopajSsdfTutar, GENEL_TOPLAM as GenelToplam, MUHASEBELESTIRILMEMIS_MIKTAR as MuhasebelestirilmemisMiktar, BANKA_DEKONT_NO as BankaDekontNo, EFT_REFERANS_NO as EftReferansNo, REFERANS_NO as ReferansNo, HAREKET_ALT_KATEGORI_ID as HareketAltKategoriId, FOY_NO as FoyNo, ADLI_BIRIM_ADLIYE_ID as AdliBirimAdliyeId, ADLI_BIRIM_NO_ID as AdliBirimNoId, ADLI_BIRIM_GOREV_ID as AdliBirimGorevId, ESAS_NO as EsasNo, HAREKET_ANA_KATEGORI_ID as HareketAnaKategoriId, BURO_HESAP_SAHIBI_CARI_BANKA_ID as KasaHesapSahibiCariBankaId, MUHATAP_HESAP_SAHIBI_CARI_BANKA_ID as MuhatapHesapSahibiCariBankaId, KIYMETLI_EVRAK_ID as KiymetliEvrakId, KAYIT_TARIHI as KayitTarihi, TARIH as Tarih, MUVEKKIL_CARI_ID as MuvekkilCariId, convert(bit,0) as IsSelected, DETAY_ID as DetayId";

        //aykut hızlandırma 28.01.2013
        //public static List<AvukatPro.Model.EntityClasses.RFoyMuhasebesiBirlesikDetayliEntity> GetMuhasebeBirlesikDetayliByFiltre(AvukatPro.Services.Messaging.GetMuhasebeBirlesikByFiltreRequest request)
        //{
        //    List<AvukatPro.Model.EntityClasses.RFoyMuhasebesiBirlesikDetayliEntity> sonuc = BaseService._db.RFoyMuhasebesiBirlesikDetayli.Where(m => m.Adet >= 0 && m.BirimFiyat > 0).ToList();

        //    if (request.Modul.HasValue)
        //    {
        //        if ((int)request.Modul != 7)
        //        {
        //            sonuc = sonuc.Where(m => m.KayitTip == (int)request.Modul).ToList();

        //            if (request.DosyaIds.Count > 0)
        //            {
        //                sonuc = GetMuhasebeDetayFromFoyId(request.DosyaIds);
        //            }
        //        }
        //        else
        //            sonuc = sonuc.Where(m => m.KayitTip == 0).ToList();
        //    }

        //    if (request.AnaKategori.HasValue)
        //        sonuc = sonuc.Where(m => m.HareketAnaKategoriId == request.AnaKategori).ToList();

        //    if (request.AltKategori.HasValue)
        //        sonuc = sonuc.Where(m => m.HareketAltKategoriId == request.AltKategori).ToList();

        //    if (request.MasrafTarihi.HasValue)
        //        sonuc = sonuc.Where(m => m.Tarih == request.MasrafTarihi).ToList();

        //    if (request.MuvekkilID.HasValue)
        //        sonuc = sonuc.Where(m => m.MuvekkilCariId == request.MuvekkilID).ToList();

        //    if (!string.IsNullOrEmpty(request.ReferansNo))
        //        sonuc = sonuc.Where(m => m.ReferansNo == request.ReferansNo).ToList();

        //    if (request.BorcAlacak.HasValue)
        //        sonuc = sonuc.Where(m => m.BorcAlacakId == request.BorcAlacak).ToList();

        //    return sonuc;
        //}
        //public static List<AvukatPro.Model.EntityClasses.RFoyMuhasebesiBirlesikDetayliEntity> GetAllMuhasebeBirlesikDetayli()
        //{
        //    var sonuc = BaseService._db.RFoyMuhasebesiBirlesikDetayli.ToList();

        //    return sonuc;
        //}

        public static void CreateFoyMuhasebeByMasrafAvans(AvukatPro.Services.Messaging.CreateFoyMuhasebeByMasrafAvansRequest request)
        {
            AvukatProLib.Hesap.MuhasebeAraclari.SetFoyMuhasebeByMasrafAvans(request.MasrafAvansId, request.ModulId);
        }

        public static void CreateFoyMuhasebeDetayByMasrafAvansDetay(AvukatPro.Services.Messaging.CreateFoyMuhasebeDetayByMasrafAvansDetayRequest request)
        {
            AvukatProLib.Hesap.MuhasebeAraclari.SetFoyMuhasebeDetayByMasrafAvansDetay(request.MasrafAvansDetayId, request.MuhasebeId, request.YenidenHesaplanabilir);
        }

        public static DataTable GetAllMuhasebeBirlesikDetayli()
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlar + " from dbo.R_FOY_MUHASEBESI_BIRLESIK_DETAYLI(nolock)");

            return sonuc;
        }

        public static List<AvukatPro.Model.EntityClasses.RFoyMuhasebesiDavaEntity> GetAllMuhasebeFromDavaFoy(int davaFoyId)
        {
            var sonuc = BaseService._db.RFoyMuhasebesiDava.Where(m => m.KayitId == davaFoyId).ToList();

            return sonuc;
        }

        public static List<AvukatPro.Model.EntityClasses.RFoyMuhasebesiIcraEntity> GetAllMuhasebeFromIcraFoy(int icraFoyId)
        {
            var sonuc = BaseService._db.RFoyMuhasebesiIcra.Where(m => m.KayitId == icraFoyId).ToList();

            return sonuc;
        }

        public static List<AvukatPro.Model.EntityClasses.RFoyMuhasebesiSorusturmaEntity> GetAllMuhasebeFromSorusturmaFoy(int sorusturmaFoyId)
        {
            var sonuc = BaseService._db.RFoyMuhasebesiSorusturma.Where(m => m.KayitId == sorusturmaFoyId).ToList();

            return sonuc;
        }

        public static List<AvukatPro.Model.EntityClasses.RFoyMuhasebesiSozlesmeEntity> GetAllMuhasebeFromSozlesmeFoy(int sozlesmeFoyId)
        {
            var sonuc = BaseService._db.RFoyMuhasebesiSozlesme.Where(m => m.KayitId == sozlesmeFoyId).ToList();

            return sonuc;
        }

        public static DataTable GetMuhasebeBirlesikDetayliByFiltre(AvukatPro.Services.Messaging.GetMuhasebeBirlesikByFiltreRequest request, string ZamanDilimi)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            string where = "";

            where += " where ADET>0";

            if (request.Modul.HasValue)
            {
                if ((int)request.Modul != 7)
                {
                    cn.AddParams("@KAYIT_TIP", (int)request.Modul);
                    where += " and KAYIT_TIP=@KAYIT_TIP";

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
                else
                    where += " and KAYIT_TIP=0";
            }

            if (request.AnaKategori.HasValue)
            {
                cn.AddParams("@HAREKET_ANA_KATEGORI_ID", request.AnaKategori);
                where += " and HAREKET_ANA_KATEGORI_ID=@HAREKET_ANA_KATEGORI_ID";
            }

            if (request.AltKategori.HasValue)
            {
                cn.AddParams("@HAREKET_ALT_KATEGORI_ID", request.AltKategori);
                where += " and HAREKET_ALT_KATEGORI_ID=@HAREKET_ALT_KATEGORI_ID";
            }

            if (request.MasrafTarihi.HasValue)
            {
                cn.AddParams("@TARIH", request.MasrafTarihi);
                where += " and TARIH=@TARIH";
            }

            if (request.MuvekkilID.HasValue)
            {
                cn.AddParams("@MUVEKKIL_CARI_ID", request.MuvekkilID);
                where += " and MUVEKKIL_CARI_ID=@MUVEKKIL_CARI_ID";
            }

            if (!string.IsNullOrEmpty(request.ReferansNo))
            {
                cn.AddParams("@REFERANS_NO", request.ReferansNo);
                where += " and REFERANS_NO=@REFERANS_NO";
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

            sonuc = cn.GetDataTable("select " + kolonlar + " from dbo.R_FOY_MUHASEBESI_BIRLESIK_DETAYLI(nolock) " + where);

            return sonuc;
        }

        public static List<AvukatPro.Model.EntityClasses.RFoyMuhasebesiBirlesikDetayliEntity> GetMuhasebeBirlesikDetayliByFoyId(int foyID, int modul)
        {
            var sonuc = BaseService._db.RFoyMuhasebesiBirlesikDetayli.Where(m => m.KayitTip == modul).Where(m => m.KayitId == foyID).ToList();

            return sonuc;
        }

        public static List<AvukatPro.Model.EntityClasses.Av001TdiBilFoyMuhasebeEntity> GetMuhasebeByMasrafAvansId(int masrafAvansId)
        {
            var sonuc = BaseService._db.Av001TdiBilFoyMuhasebe.Where(m => m.MasrafAvansId == masrafAvansId).ToList();

            return sonuc;
        }

        public static AvukatPro.Model.EntityClasses.Av001TdiBilFoyMuhasebeDetayEntity GetMuhasebeDetayById(int muhasebeDetayId)
        {
            var sonuc = BaseService._db.Av001TdiBilFoyMuhasebeDetay.Where(m => m.Id == muhasebeDetayId).Single();

            return sonuc;
        }

        public static void Save(AvukatPro.Model.EntityClasses.Av001TdiBilCariBankaEntity entity)
        {
            entity.Save();
        }

        public static void UpdateMuhasebeDetay(AvukatPro.Model.EntityClasses.Av001TdiBilFoyMuhasebeDetayEntity muhasebeDetay)
        {
            muhasebeDetay.Save();
        }
    }
}