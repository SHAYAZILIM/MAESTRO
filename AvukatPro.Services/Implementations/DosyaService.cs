using AvukatProLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AvukatPro.Services.Implementations
{
    public class DosyaService : IDisposable //: BaseService, AvukatPro.Services.Interfaces.IDosyaService
    {
        private static string kolonlar = "ID as Id, HAREKET_CARI_ID as HareketCariId, SEGMENT_ID as SegmentId, BORC_ALACAK_ID as BorcAlacakId, ADET as Adet, BIRIM_FIYAT as BirimFiyat, BIRIM_FIYAT_DOVIZ_ID as BirimFiyatDovizId, 0 as KdvTutar, 0 as StopajSsdfTutar, GENEL_TOPLAM as GenelToplam,BANKA_DEKONT_NO as BankaDekontNo, EFT_REFERANS_NO as EftReferansNo, REFERANS_NO as ReferansNo, ODEME_TIP_ID as OdemeTipId, HAREKET_ALT_KATEGORI_ID as HareketAltKategoriId, HAREKET_ANA_KATEGORI_ID as HareketAnaKategoriId, BURO_HESAP_SAHIBI_CARI_BANKA_ID as KasaHesapSahibiCariBankaId, MUHATAP_HESAP_SAHIBI_CARI_BANKA_ID as MuhatapHesapSahibiCariBankaId, KIYMETLI_EVRAK_ID as KiymetliEvrakId, KAYIT_TARIHI as KayitTarihi, TARIH as Tarih,MASRAF_AVANS_DETAY_ID as MasrafAvansDetayId, ACIKLAMA as Aciklama";

        private static string kolonlarBLG = "select * from (SELECT convert(bit,0) as IsSelected, a.ADLI_BIRIM_ADLIYE_ID as Adliye, a.ADLI_BIRIM_GOREV_ID as Gorev, a.ADLI_BIRIM_NO_ID as [No], a.ESAS_NO as EsasNo, a.ACIKLAMA, a.ID, a.OZEL_KOD_1_ID as OzelKod1, a.OZEL_KOD_2_ID as OzelKod2, a.OZEL_KOD_3_ID as OzelKod3, a.OZEL_KOD_4_ID as OzelKod4, a.KAYIT_TARIHI as KayitTarihi, a.KONTROL_KIM_ID as KontrolKimId, a.SUBE_KOD_ID as SubeKodu, a.DOSYA_ADI, a.DOKUMAN_UZANTI as DokumanUzanti, a.BELGEYI_YAZAN_ID as BELGEYI_YAZAN, a.SUC_OLAY_VADE_TARIHI, a.DAVA_TAKIP_KONU, a.ASAMA_ID, a.YIL as Yil, a.SAYI as Sayi, a.BARKOD_NO as BarkodNo, a.ILAM_ID,a.SEGMENT_ID as SegmentId, a.BELGE_TUR_ID as BelgeTurId, a.BELGE_ADI as BelgeAdi, case when i.ICRA_FOY_ID is not null then i.ICRA_FOY_ID when d.DAVA_FOY_ID is not null then d.DAVA_FOY_ID when h.HAZIRLIK_ID is not null then h.HAZIRLIK_ID when s.SOZLESME_ID is not null then s.SOZLESME_ID else NULL end as FOY_ID, case when i.ICRA_FOY_ID is not null then 1 when d.DAVA_FOY_ID is not null then 2 when h.HAZIRLIK_ID is not null then 3 when s.SOZLESME_ID is not null then 4 else -1 end as ModulId, BELGE_REFERANS_NO,a.STAMP FROM dbo.AV001_TDIE_BIL_BELGE(nolock) a left join dbo.NN_BELGE_ICRA(nolock) i on i.BELGE_ID=a.ID left join dbo.NN_BELGE_DAVA(nolock) d on d.BELGE_ID=a.ID left join dbo.NN_BELGE_HAZIRLIK(nolock) h on h.BELGE_ID=a.ID left join dbo.NN_BELGE_SOZLESME(nolock) s on s.BELGE_ID=a.ID) aa";

        private static string kolonlarFAT = "ID as Id, CARI_ID as CariId, SEGMENT_ID as SegmentId, FATURA_HEDEF_TIP as FaturaHedefTip, FATURA_TARIH as FaturaTarih, ADET as Adet, BIRIM_TUTAR as BirimTutar, TOPLAM as Toplam, KDV_TUTAR as KdvTutar, STOPAJ_TUTAR as StopajTutar, SSDF_TUTAR as SsdfTutar, GENEL_TOPLAM as GenelToplam, GENEL_TOPLAM_DOVIZ_ID as GenelToplamDovizId, REFERANS_NO as ReferansNo, FOY_NO as FoyNo, ADLI_BIRIM_ADLIYE_ID as AdliBirimAdliyeId, ADLI_BIRIM_NO_ID as AdliBirimNoId, ADLI_BIRIM_GOREV_ID as AdliBirimGorevId, ESAS_NO as EsasNo,FOY_ID AS FoyId";

        private static string kolonlarTEB = "R.SEGMENT_ID as SegmentId, R.Tipi, R.PTT_BARKOD_NO as PttBarkodNo, R.Durum, R.DOSYA_NO as DosyaNo, R.Adliye, R.[No], R.Gorev, R.Esas_No as EsasNo, R.TAKIP_T as TakipT, R.MUHATAP_TARAF_KOD as MuhatapTarafKod, R.MUHATAP_CARI_ID as MuhatapCariId, R.TEBLIG_TARIH as TebligTarih, R.ALAN_CARI_ID as AlanCariId, R.ALAN_BAGLANTI_ID as AlanBaglantiId, R.ALT_TUR_ID as AltTurId, R.ALIM_SEKIL_ID as AlimSekilId, R.Referans1, R.Referans2, R.Referans3, R.Referans4, R.Referans5, R.BILA_TARIHI as BilaTarihi, R.TEBLIGAT_SONUC_ID as TebligatSonucId, R.CARI_ALT_ID as CariAltId, R.Takip_Konusu as TakipKonusu, R.Ozel_Kod1 as OzelKod1, R.Ozel_Kod2 as OzelKod2, R.Ozel_Kod3 as OzelKod3, R.Ozel_Kod4 as OzelKod4, R.POSTALANMA_TARIH as PostalanmaTarih, R.GELEN_BELGE_MI as GelenBelgeMi, R.RESMI_MI as ResmiMi, R.SUBE_KOD_ID as SubeKodId, R.TEBLIG_SAAT as TebligSaat, R.EVRAK_TARIHI as EvrakTarihi, R.EVRAK_NO as EvrakNo, R.OKUNDU_MU as OkunduMu, R.EVRAK_SONUC_ID as EvrakSonucId, R.ANA_TUR_ID as AnaTurId, R.ID as Id, R.TEBLIGAT_ADRESI as TebligatAdresi,T.STAMP,R.SUBEDEN_YENI_ADRES_ISTEME_TARIHI,M.EVRAK_DURUM,T.KONTROL_KIM,Y.YAPAN_CARI_ID";

        public static string DovizTipiById(int dovizId)
        {
            string sonuc = BaseService._db.TdiKodDovizTip.Where(d => d.Id == dovizId).Select(d => d.Ad).Single();

            return sonuc;
        }

        public static string GetAdliBirimAdliyeById(int adliBirimAdliyeId)
        {
            return BaseService._db.PerTdiKodAdliBirimAdliye.Where(a => a.Id == adliBirimAdliyeId).Select(a => a.Adliye).FirstOrDefault();
        }

        public static string GetAdliBirimGorevById(int adliBirimGorevId)
        {
            return BaseService._db.PerTdiKodAdliBirimGorev.Where(a => a.Id == adliBirimGorevId).Select(a => a.Gorev).FirstOrDefault();
        }

        public static string GetAdliBirimNoById(int adliBirimNoId)
        {
            return BaseService._db.PerTdiKodAdliBirimNo.Where(a => a.Id == adliBirimNoId).Select(a => a.No).FirstOrDefault();
        }

        public static List<Model.EntityClasses.RBelgelerTarafliEntity> GetAllBelge()
        {
            var sonuc = BaseService._db.RBelgelerTarafli.ToList();

            return sonuc;
        }

        public static DataTable GetAllBelgeByFiltre(Messaging.GetBelgeByFiltreRequest request, string ZamanDilimi)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            string where = "";

            if (request.KullaniciSubeID.HasValue)
            {
                cn.AddParams("@SubeKodu", request.KullaniciSubeID);
                where += " where SubeKodu=@SubeKodu";
            }
            else
                where += " where ID<>-1";

            if (request.Modul.HasValue)
            {
                cn.AddParams("@ModulId", (int)request.Modul);
                where += " and ModulId=@ModulId";

                if (request.DosyaID.HasValue)
                {
                    cn.AddParams("@FOY_ID", request.DosyaID);
                    where += " and FOY_ID=@FOY_ID";
                }
            }

            if (!string.IsNullOrEmpty(request.BarkodNo))
            {
                cn.AddParams("@BarkodNo", request.BarkodNo);
                where += " and BarkodNo=@BarkodNo";
            }

            if (!string.IsNullOrEmpty(request.BelgeAdi))
            {
                cn.AddParams("@BelgeAdi", request.BelgeAdi);
                where += " and BelgeAdi=@BelgeAdi";
            }

            if (!string.IsNullOrEmpty(request.BelgeNo))
            {
                cn.AddParams("@No", request.BelgeNo);
                where += " and [No]=@No";
            }

            //if (request.DurumID.HasValue)
            //{
            //    cn.AddParams("@Durum", request.DurumID);
            //    where += " and Durum=@Durum";
            //}

            if (!string.IsNullOrEmpty(request.RefNo))
            {
                cn.AddParams("@BELGE_REFERANS_NO", request.RefNo);
                where += " and BELGE_REFERANS_NO=@BELGE_REFERANS_NO";
            }

            if (request.TurID.HasValue)
            {
                cn.AddParams("@BelgeTurId", request.TurID);
                where += " and BelgeTurId=@BelgeTurId";
            }

            if (ZamanDilimi != "Tumu")
                where += Metotlar.ZamanDilimiParametresiOlustur(cn, "KayitTarihi", ZamanDilimi);

            sonuc = cn.GetDataTable(kolonlarBLG + " " + where);
            return sonuc;
        }

        public static List<int> GetAllBelgeIDsByCariHesapDetayId(int cariHesapDetayId)
        {
            return new List<int>();
        }

        public static List<int> GetAllBelgeIDsByFaturaId(int faturaId)
        {
            return new List<int>();
        }

        public static List<int> GetAllBelgeIDsByKasaDetayDetayId(int kasaDetayId)
        {
            return new List<int>();
        }

        public static List<int> GetAllBelgeIDsByMayrafAvansDetayId(int masrafAvansDetayId)
        {
            var sonuc = BaseService._db.NnBelgeMasrafAvansDetay.Where(b => b.MasrafAvansDetayId == masrafAvansDetayId).Select(b => b.BelgeId).ToList();

            return sonuc;
        }

        public static List<int> GetAllBelgeIDsByMuhasebeDetayId(int muhasebeDetayId)
        {
            return new List<int>();
        }

        public static List<int> GetAllBelgeIDsByTebligatID(int tebligatID)
        {
            return BaseService._db.NnBelgeTebligat.Where(b => b.TebligatId == tebligatID).Select(b => b.BelgeId).ToList();
        }

        public static List<Model.EntityClasses.KiymetliEvrakTarafliEntity> GetAllCek()
        {
            var sonuc = BaseService._db.KiymetliEvrakTarafli.Where(k => k.EvrakTurId == 1).ToList();

            return sonuc;
        }

        public static object GetAllDosyaByModul(string modul)
        {
            object dtSrc = new object();
            if (!string.IsNullOrEmpty(modul))
            {
                switch (modul)
                {
                    case "Icra":
                        dtSrc = BaseService._db.PerAv001TiBilIcraArama.ToList();
                        break;

                    case "Dava":
                        dtSrc = BaseService._db.VtdDavaDosyalar.ToList();
                        break;

                    case "Soruşturma":
                        dtSrc = BaseService._db.VtdSorusturmaDosyalar.ToList();
                        break;

                    case "Sözleşme":
                        dtSrc = BaseService._db.VtdSozlesmeDosyalar.ToList();
                        break;

                    case "Vekalet":
                        dtSrc = BaseService._db.PerTemsilTarafSorumluBirlesik.ToList();
                        break;

                    case "Haciz":
                        dtSrc = BaseService._db.PerHacizliMallarMasterChild.ToList();
                        break;

                    case "Satis":
                        dtSrc = BaseService._db.PerRBirlesikTakiplerSati.ToList();
                        break;

                    case "Duruşma/Celse":
                        dtSrc = BaseService._db.Av001TdBilCelse.ToList();
                        break;

                    case "Fatura":
                        dtSrc = BaseService._db.PerAv001TdiBilFatura.ToList();
                        break;

                    case "Kiymetli Evrak":
                        dtSrc = BaseService._db.PerAv001TdiBilKiymetliEvrak.ToList();
                        break;

                    default:
                        break;
                }
            }
            return dtSrc;
        }

        public static List<Model.EntityClasses.RBirlesikTakiplerTebligatEntity> GetAllEvrak()
        {
            return BaseService._db.RBirlesikTakiplerTebligat.ToList();
        }

        public static DataTable GetAllFatura()
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlarFAT + " from dbo.R_BIL_FATURA_MODUL(nolock) ");

            return sonuc;
        }

        //    return sonuc;
        //}
        public static DataTable GetAllFaturaByFiltre(Messaging.GetFaturaByFiltreRequest request, string ZamanDilimi)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            string where = " where ID<>-1";

            if (request.Modul.HasValue)
            {
                cn.AddParams("@FATURA_HEDEF_TIP", (int)request.Modul);
                where += " and FATURA_HEDEF_TIP=@FATURA_HEDEF_TIP";

                if (request.DosyaIds.Count > 0)
                {
                    where += " and FOY_ID in (-1";
                    foreach (var id in request.DosyaIds)
                    {
                        where += "," + id;
                    }
                    where += ")";
                }
            }

            if (!string.IsNullOrEmpty(request.ReferansNo))
            {
                cn.AddParams("@REFERANS_NO", request.ReferansNo);
                where += " and REFERANS_NO=@REFERANS_NO";
            }

            if (request.FaturaKapsamTipi.HasValue)
            {
                cn.AddParams("@FATURA_KAPSAM_TIP", request.FaturaKapsamTipi);
                where += " and FATURA_KAPSAM_TIP=@FATURA_KAPSAM_TIP";
            }

            if (request.CariId.HasValue)
            {
                cn.AddParams("@CARI_ID", request.CariId);
                where += " and CARI_ID=@CARI_ID";
            }

            if (request.FaturaTarihi.HasValue)
            {
                cn.AddParams("@FATURA_TARIH", request.FaturaTarihi);
                where += " and FATURA_TARIH=@FATURA_TARIH";
            }

            if (!string.IsNullOrEmpty(request.SeriNo))
            {
                cn.AddParams("@SERI_NO", request.SeriNo);
                where += " and SERI_NO=@SERI_NO";
            }

            if (ZamanDilimi != "Tumu")
            {
                if (!request.FaturaTarihi.HasValue)
                {
                    where += Metotlar.ZamanDilimiParametresiOlustur(cn, "FATURA_TARIH", ZamanDilimi);
                }
            }

            sonuc = cn.GetDataTable("select " + kolonlarFAT + " from dbo.R_BIL_FATURA_MODUL(nolock) " + where);

            return sonuc;
        }

        public static List<Model.EntityClasses.RBilFaturaModulEntity> GetAllFaturaByFoy(int foyId, AvukatProLib.Extras.Modul modul)
        {
            var sonuc = BaseService._db.RBilFaturaModul.Where(f => f.FoyId == foyId && f.FaturaHedefTip == (int)modul).ToList();
            return sonuc;
        }

        public static DataTable GetAllGorusmeByFiltre(Messaging.GetGorusmeByFiltreRequest request, string ZamanDilimi)
        {
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            string where = " where ID<>-1";

            if (request.Modul != null)
            {
                cn.AddParams("@Tipi", request.Modul.ToString().Replace("Icra", "İcra"));
                where += " and Tipi=@Tipi";

                if (request.DosyaID != null)
                {
                    cn.AddParams("@FOY_ID", request.DosyaID);
                    where += " and FOY_ID=@FOY_ID";
                }
            }

            if (request.GorusenKisi != null)
            {
                cn.AddParams("@GORUSEN_CARI_ID", request.GorusenKisi);
                where += " and GORUSEN_CARI_ID=@GORUSEN_CARI_ID";
            }

            if (request.GorusulenKisi != null)
            {
                cn.AddParams("@GORUSULEN_CARI_ID", request.GorusulenKisi);
                where += " and GORUSULEN_CARI_ID=@GORUSULEN_CARI_ID";
            }

            if (request.IsinYapildigiKisi != null)
            {
                cn.AddParams("@ISIN_YAPILDIGI_CARI_ID", request.IsinYapildigiKisi);
                where += " and ISIN_YAPILDIGI_CARI_ID=@ISIN_YAPILDIGI_CARI_ID";
            }

            if (request.IsKategoriID != null)
            {
                cn.AddParams("@IS_KATEGORI_ID", request.IsKategoriID);
                where += " and IS_KATEGORI_ID=@IS_KATEGORI_ID";
            }

            if (request.GorusmeTarihi != null)
            {
                cn.AddParams("@TARIH", request.GorusmeTarihi);
                where += " and TARIH=@TARIH";
            }

            if (request.YenidenGorusmeTarihi != null)
            {
                cn.AddParams("@YENIDEN_GORUSME_TARIHI", request.YenidenGorusmeTarihi);
                where += " and YENIDEN_GORUSME_TARIHI=@YENIDEN_GORUSME_TARIHI";
            }

            if (!request.GorusmeTarihi.HasValue)
            {
                if (ZamanDilimi != "Tumu")
                    where += Metotlar.ZamanDilimiParametresiOlustur(cn, "TARIH", ZamanDilimi);
            }

            return cn.GetDataTable("SELECT CONVERT(BIT,0) AS IsSelected, SEGMENT_ID AS SegmentId, IS_KATEGORI_ID AS IsKategoriId, GORUSME_YONU AS GorusmeYonu, GORUSULEN_CARI_ID AS GorusulenCariId, GORUSULEN_TEL AS GorusulenTel, DAHILI AS Dahili, YENIDEN_GORUSME_TARIHI AS YenidenGorusmeTarihi, YENIDEN_GORUSME_SAATI AS YenidenGorusmeSaati, YERINE_GORUSULEN_KISI AS YerineGorusulenKisi, YERINE_GORUSULEN_KISI_YAKINLIGI AS YerineGorusulenKisiYakinligi, OZEL_KOD_ID AS OzelKodId, OZEL_KOD2_ID AS OzelKod2Id, OZEL_KOD3_ID AS OzelKod3Id, OZEL_KOD4_ID AS OzelKod4Id, FOY_NO AS FoyNo, ADLI_BIRIM_ADLIYE_ID AS AdliBirimAdliyeId, ADLI_BIRIM_NO_ID AS AdliBirimNoId, ADLI_BIRIM_GOREV_ID AS AdliBirimGorevId, ESAS_NO AS EsasNo, TARIH AS Tarih, SAAT AS Saat, BITIS_TARIH AS BitisTarih, BITIS_SAATI AS BitisSaati, GORUSENIN_NOTU AS GoruseninNotu, GORUSME_SURE AS GorusmeSure, GORUSEN_CARI_ID AS GorusenCariId, GORUSEN_TEL AS GorusenTel, ISIN_YAPILDIGI_CARI_ID AS IsinYapildigiCariId, CASE SesKaydi WHEN 'Var' THEN 'Dinle' ELSE 'Kayıt Yok' END AS SesKaydi, ID, FOY_ID, Tipi FROM dbo.R_GORUSMELER_BIRLESIK_YENI(nolock)" + where);
        }

        //    if (request.HareketCariId.HasValue)
        //        sonuc = sonuc.Where(k => k.HareketCariId == request.HareketCariId).ToList();
        //    if (request.BorcAlacakId.HasValue)
        //        sonuc = sonuc.Where(k => k.BorcAlacakId == request.BorcAlacakId).ToList();
        //    if (request.AnaKategori.HasValue)
        //        sonuc = sonuc.Where(k => k.HareketAnaKategoriId == request.AnaKategori).ToList();
        //    if (request.OdemeTipId.HasValue)
        //        sonuc = sonuc.Where(k => k.OdemeTipId == request.OdemeTipId).ToList();
        //    if (!string.IsNullOrEmpty(request.ReferansNo))
        //        sonuc = sonuc.Where(k => k.ReferansNo == request.ReferansNo).ToList();
        //    if (!string.IsNullOrEmpty(request.BelgeNo))
        //        sonuc = sonuc.Where(k => k.BelgeNo == request.BelgeNo).ToList();
        //    if (request.Tarih.HasValue)
        //        sonuc = sonuc.Where(k => k.Tarih == request.Tarih).ToList();
        public static DataTable GetAllKasa()
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlar + " from dbo.AV001_TDI_BIL_KASA(nolock) ");
            return sonuc;
        }

        //    return sonuc;
        //}
        //public static List<Model.EntityClasses.Av001TdiBilKasaEntity> GetAllKasaByFiltre(Messaging.GetKasaByFiltreRequest request)
        //{
        //    List<AvukatPro.Model.EntityClasses.Av001TdiBilKasaEntity> sonuc = BaseService._db.Av001TdiBilKasa.ToList();
        public static DataTable GetAllKasaByFiltre(Messaging.GetKasaByFiltreRequest request, string ZamanDilimi)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            string where = " where ID<>-1";

            if (request.HareketCariId.HasValue)
            {
                cn.AddParams("@HAREKET_CARI_ID", request.HareketCariId);
                where += " and HAREKET_CARI_ID=@HAREKET_CARI_ID";
            }

            if (request.BorcAlacakId.HasValue)
            {
                cn.AddParams("@BORC_ALACAK_ID", request.BorcAlacakId);
                where += " and BORC_ALACAK_ID=@BORC_ALACAK_ID";
            }

            if (request.AnaKategori.HasValue)
            {
                cn.AddParams("@HAREKET_ANA_KATEGORI_ID", request.AnaKategori);
                where += " and HAREKET_ANA_KATEGORI_ID=@HAREKET_ANA_KATEGORI_ID";
            }

            if (request.OdemeTipId.HasValue)
            {
                cn.AddParams("@ODEME_TIP_ID", request.OdemeTipId);
                where += " and ODEME_TIP_ID=@ODEME_TIP_ID";
            }

            if (!string.IsNullOrEmpty(request.ReferansNo))
            {
                cn.AddParams("@REFERANS_NO", request.ReferansNo);
                where += " and REFERANS_NO=@REFERANS_NO";
            }

            if (!string.IsNullOrEmpty(request.BelgeNo))
            {
                cn.AddParams("@BELGE_NO", request.BelgeNo);
                where += " and BELGE_NO=@BELGE_NO";
            }

            if (request.Tarih.HasValue)
            {
                cn.AddParams("@TARIH", request.Tarih);
                where += " and TARIH=@TARIH";
            }

            if (ZamanDilimi != "Tumu")
            {
                if (!request.Tarih.HasValue)
                {
                    where += Metotlar.ZamanDilimiParametresiOlustur(cn, "TARIH", ZamanDilimi);
                }
            }

            sonuc = cn.GetDataTable("select " + kolonlar + " from dbo.AV001_TDI_BIL_KASA(nolock) " + where);

            return sonuc;
        }

        //    return sonuc;
        //}
        //public static List<Model.EntityClasses.Av001TdiBilKasaEntity> GetAllKasa()
        //{
        //    var sonuc = BaseService._db.Av001TdiBilKasa.ToList();
        public static List<Model.EntityClasses.KiymetliEvrakTarafliEntity> GetAllKiymetliEvrak()
        {
            var sonuc = BaseService._db.KiymetliEvrakTarafli.ToList();

            return sonuc;
        }

        public static List<Model.EntityClasses.RMuvekkilHesapFoyTarafliEntity> GetAllMuvekkilHesap()
        {
            var sonuc = BaseService._db.RMuvekkilHesapFoyTarafli.ToList();

            return sonuc;
        }

        public static List<Model.EntityClasses.Av001TdiKodFoyOzelEntity> GetAllOzelKod()
        {
            return BaseService._db.Av001TdiKodFoyOzel.ToList();
        }

        public static List<Model.EntityClasses.KiymetliEvrakTarafliEntity> GetAllSenet()
        {
            var sonuc = BaseService._db.KiymetliEvrakTarafli.Where(k => k.EvrakTurId == 2).ToList();

            return sonuc;
        }

        public static DataTable GetAllTebligatByFiltre(Messaging.GetTebligatByFiltreRequest request, string ZamanDilimi)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            string where = " where R.ID<>-1";
            //List<Model.EntityClasses.RBirlesikTakiplerTebligatEntity> sonuc;

            if (request.KullaniciSubeID.HasValue)
            {
                cn.AddParams("@SUBE_KOD_ID", request.KullaniciSubeID);
                where += " and R.SUBE_KOD_ID=@SUBE_KOD_ID";
            }

            if (request.Modul.HasValue)
            {
                if (request.Modul.ToString() == "Icra")
                    cn.AddParams("@Tipi", "İcra");
                else
                    cn.AddParams("@Tipi", request.Modul.ToString());

                where += " and R.Tipi=@Tipi";

                if (request.DosyaID.HasValue)
                {
                    cn.AddParams("@FOY_ID", request.DosyaID);
                    where += " and R.FOY_ID=@FOY_ID";
                }
            }

            if (!string.IsNullOrEmpty(request.Barkod))
            {
                cn.AddParams("@PTT_BARKOD_NO", request.Barkod);
                where += " and R.PTT_BARKOD_NO=@PTT_BARKOD_NO";
            }

            if (request.KonuID.HasValue)
            {
                cn.AddParams("@Takip_Konusu", request.KonuID);
                where += " and R.Takip_Konusu=@Takip_Konusu";
            }

            if (request.MuhatapID.HasValue)
            {
                cn.AddParams("@MUHATAP_CARI_ID", request.MuhatapID);
                where += " and (R.MUHATAP_CARI_ID=@MUHATAP_CARI_ID OR Y.YAPAN_CARI_ID=@MUHATAP_CARI_ID";
            }

            if (request.PostalamaTarihi.HasValue)
            {
                if (request.PostalamaTarihi.ToString() != "01.01.0001 00:00:00")
                {
                    cn.AddParams("@POSTALANMA_TARIH", request.PostalamaTarihi);
                    where += " and R.POSTALANMA_TARIH=@POSTALANMA_TARIH";
                }
            }

            //if (!string.IsNullOrEmpty(request.ReferansNo))
            //    sonuc = sonuc.Where(t => t.Referans1 == request.ReferansNo || t.Referans2 == request.ReferansNo || t.Referans3 == request.ReferansNo || t.Referans4 == request.ReferansNo || t.Referans5 == request.ReferansNo).ToList();

            if (request.TebligatAltTur.HasValue)
            {
                cn.AddParams("@ALT_TUR_ID", request.TebligatAltTur);
                where += " and R.ALT_TUR_ID=@ALT_TUR_ID";
            }

            if (ZamanDilimi != "Tumu")
                where += Metotlar.ZamanDilimiParametresiOlustur(cn, "R.KAYIT_TARIHI", ZamanDilimi);

            sonuc = cn.GetDataTable("select " + kolonlarTEB + " from dbo.R_BIRLESIK_TAKIPLER_TEBLIGAT(nolock) R INNER JOIN AV001_TDI_BIL_TEBLIGAT T ON T.ID=R.ID LEFT JOIN AV001_TDI_BIL_TEBLIGAT_MUHATAP M ON T.ID=M.TEBLIGAT_ID LEFT JOIN AV001_TDI_BIL_TEBLIGAT_YAPAN Y ON Y.TEBLIGAT_ID = R.ID" + where);

            return sonuc;
        }

        public static Model.EntityClasses.Av001TdieBilBelgeEntity GetBelgeById(int belgeId)
        {
            var sonuc = BaseService._db.Av001TdieBilBelge.Where(b => b.Id == belgeId).Single();

            return sonuc;
        }

        public static DataTable GetEvrakByDavaFoyID(int davaFoyID)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlarTEB + " from dbo.R_BIRLESIK_TAKIPLER_TEBLIGAT  R INNER JOIN AV001_TDI_BIL_TEBLIGAT T ON T.ID=R.ID INNER JOIN AV001_TDI_BIL_TEBLIGAT_MUHATAP M ON T.ID=M.TEBLIGAT_ID LEFT JOIN AV001_TDI_BIL_TEBLIGAT_YAPAN Y ON Y.TEBLIGAT_ID = R.ID where R.ANA_TUR_ID=3 and R.FOY_ID=" + davaFoyID);

            return sonuc;
        }

        public static DataTable GetEvrakByIcraFoyID(int icraFoyID)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select " + kolonlarTEB + " from dbo.R_BIRLESIK_TAKIPLER_TEBLIGAT R INNER JOIN AV001_TDI_BIL_TEBLIGAT T ON T.ID=R.ID INNER JOIN AV001_TDI_BIL_TEBLIGAT_MUHATAP M ON T.ID=M.TEBLIGAT_ID  LEFT JOIN AV001_TDI_BIL_TEBLIGAT_YAPAN Y ON Y.TEBLIGAT_ID = R.ID where R.ANA_TUR_ID=4 and R.FOY_ID=" + icraFoyID);

            return sonuc;
        }

        //static string kolonlarBLG = "convert(bit,0) as IsSelected, ACIKLAMA as Aciklama, Adliye, ASAMA_ID as AsamaId, BANKA_ID as BankaId, BARKOD_NO as BarkodNo, BELGE_ADI as BelgeAdi, BELGE_TUR_ID as BelgeTurId, BELGEYI_YAZAN_ID as BelgeyiYazanId, DAVA_TAKIP_KONU as DavaTakipKonu, DOKUMAN_UZANTI as DokumanUzanti, DOSYA_ADI as DosyaAdi, Dosya_No as DosyaNo, Durum, ESAS_NO as EsasNo, FOY_BIRIM_ID as FoyBirimId, FOY_ID as FoyId, FOY_OZEL_DURUM_ID as FoyOzelDurumId, FOY_YERI_ID as FoyYeriId, Gorev, ID as Id, ILAM_ID as IlamId, IZLENSIN_MI as IzlensinMi, K, KAYIT_TARIHI as KayitTarihi, KILITLI_MI as KilitliMi, KLASOR_1 as Klasor1, KLASOR_2 as Klasor2, KONTROL_KIM_ID as KontrolKimId, KREDI_GRUP_ID as KrediGrupId, KREDI_TIP_ID as KrediTipIdi, MODUL_ID as ModulId, [No], ONEMLI_MI as OnemliMi, Ozel_Kod1 as OzelKod1, Ozel_Kod2 as OzelKod2, Ozel_Kod2 as OzelKod3, Ozel_Kod4 as OzelKod4, PROJE_ADI as ProjeAdi, PROJE_ID as ProjeId, PROJE_KOD as ProjeKod, Referans1, Referans2, Referans3, SAYI as Sayi, SEGMENT_ID as SegmentId, SIFAT as Sifat, Sorumlu_Adi as SorumluAdi, SUBE_ID as SubeId, SUBE_KOD_ID as SubeKodId, SUBE_KODU as SubeKodu, SUC_OLAY_VADE_TARIHI as SucOlayVadeTarihi, TAHSILAT_DURUM_ID as TahsilatDurumId, Takip_konusu as TakipKonusu, Takip_T as TakipT, Taraf_Adi as TarafAdi, Tipi, YIL as Yil";
        public static Model.EntityClasses.Av001TiBilFoyEntity GetIcraFoyById(int icraFoyId)
        {
            var sonuc = BaseService._db.Av001TiBilFoy.Where(f => f.Id == icraFoyId).Single();

            return sonuc;
        }

        public static List<Model.EntityClasses.Av001TiBilFoyEntity> GetIcraFoys()
        {
            var sonuc = BaseService._db.Av001TiBilFoy.ToList();

            return sonuc;
        }

        public static List<Model.EntityClasses.Av001TdiBilKiymetliEvrakEntity> GetKiymetliEvrakById(int kiymetliEvrakId)
        {
            var sonuc = BaseService._db.Av001TdiBilKiymetliEvrak.Where(k => k.Id == kiymetliEvrakId).ToList();

            return sonuc;
        }

        public static List<Model.EntityClasses.Av001TdiBilKiymetliEvrakTarafEntity> GetKiymetliEvrakTarafByKiymetliEvrakId(int kiymetliEvrakId)
        {
            var sonuc = BaseService._db.Av001TdiBilKiymetliEvrakTaraf.Where(k => k.Id == kiymetliEvrakId).ToList();

            return sonuc;
        }

        public static List<Model.EntityClasses.RMuvekkilHesapFoyTarafliEntity> GetMuvekkilHesapByFiltre(Messaging.GetMuvekkilHesapByFiltreRequest request)
        {
            List<Model.EntityClasses.RMuvekkilHesapFoyTarafliEntity> sonuc = BaseService._db.RMuvekkilHesapFoyTarafli.ToList();

            if (request.BorcluCariID.HasValue)
                sonuc = sonuc.Where(h => h.TakipEdilenCariId == request.BorcluCariID).ToList();
            if (request.DosyaDurumID.HasValue)
                sonuc = sonuc.Where(h => h.FoyDurumId == request.DosyaDurumID).ToList();
            if (request.DosyaID.HasValue)
                sonuc = sonuc.Where(h => h.IcraFoyId == request.DosyaID).ToList();
            if (request.HesaplanmaTarihi.HasValue)
                sonuc = sonuc.Where(h => h.SonHesapTarihi == request.HesaplanmaTarihi).ToList();
            if (request.KapamaTarihi.HasValue)
                sonuc = sonuc.Where(h => h.HesapKapamaTarihi == request.KapamaTarihi).ToList();
            //if (request.KontrolKimID.HasValue)
            //    sonuc = sonuc.Where(h => h. == request.KontrolKimID).ToList();
            if (request.MuvekkilCariID.HasValue)
                sonuc = sonuc.Where(h => h.TakipEdenCariId == request.MuvekkilCariID).ToList();
            if (request.OzelKod1ID.HasValue)
                sonuc = sonuc.Where(h => h.IcraOzelKod1Id == request.OzelKod1ID).ToList();
            if (request.OzelKod2ID.HasValue)
                sonuc = sonuc.Where(h => h.IcraOzelKod2Id == request.OzelKod2ID).ToList();
            if (request.OzelKod3ID.HasValue)
                sonuc = sonuc.Where(h => h.IcraOzelKod3Id == request.OzelKod3ID).ToList();
            if (request.OzelKod4ID.HasValue)
                sonuc = sonuc.Where(h => h.IcraOzelKod4Id == request.OzelKod4ID).ToList();

            return sonuc;
        }

        public static Model.EntityClasses.Av001TiBilMuvekkilHesapEntity GetMuvekkilHesapByFoyId(int foyId)
        {
            var sonuc = BaseService._db.Av001TiBilMuvekkilHesap.Where(h => h.IcraFoyId == foyId).Single();

            return sonuc;
        }

        public static DataTable GetOdemeByFiltre(Messaging.GetOdemeByFiltreRequest request, string ZamanDilimi)
        {
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            string where = " where ID<>-1";

            //List<Model.EntityClasses.RExpressBorcluOdemeProjeEntity> sonuc = BaseService._db.RExpressBorcluOdemeProje.ToList();
            if (!string.IsNullOrEmpty(request.Adliye))
            {
                cn.AddParams("@ADLI_BIRIM_ADLIYE", request.Adliye);
                where += " and ADLI_BIRIM_ADLIYE=@ADLI_BIRIM_ADLIYE";
            }

            if (!string.IsNullOrEmpty(request.AdliNo))
            {
                cn.AddParams("@ADLI_BIRIM_NO", request.AdliNo);
                where += " and ADLI_BIRIM_NO=@ADLI_BIRIM_NO";
            }

            if (!string.IsNullOrEmpty(request.EsasNo))
            {
                cn.AddParams("@ESAS_NO", request.EsasNo);
                where += " and ESAS_NO=@ESAS_NO";
            }

            if (request.IcradanCekilmeTarihi.HasValue)
            {
                cn.AddParams("@ICRADAN_CEKILME_TARIHI", request.IcradanCekilmeTarihi);
                where += " and ICRADAN_CEKILME_TARIHI=@ICRADAN_CEKILME_TARIHI";
            }

            if (request.IhtiyatiHacizdenmi.HasValue)
            {
                cn.AddParams("@IHTIYATI_HACIZDE_MI", request.IhtiyatiHacizdenmi);
                where += " and IHTIYATI_HACIZDE_MI=@IHTIYATI_HACIZDE_MI";
            }

            if (request.MaasHaczindenmi.HasValue)
            {
                cn.AddParams("@MAAS_HACZINDEN_MI", request.MaasHaczindenmi);
                where += " and MAAS_HACZINDEN_MI=@MAAS_HACZINDEN_MI";
            }

            if (request.OdemeTarihi.HasValue)
            {
                cn.AddParams("@ODEME_TARIHI", request.OdemeTarihi);
                where += " and ODEME_TARIHI=@ODEME_TARIHI";
            }

            if (request.OdemeTipiID.HasValue)
            {
                cn.AddParams("@ODEME_TIP_ID", request.OdemeTipiID);
                where += " and ODEME_TIP_ID=@ODEME_TIP_ID";
            }

            if (request.OdemeYeriID.HasValue)
            {
                cn.AddParams("@ODEME_YER_ID", request.OdemeYeriID);
                where += " and ODEME_YER_ID=@ODEME_YER_ID";
            }

            if (request.OdenenCariID.HasValue)
            {
                cn.AddParams("@ODENEN_CARI_ID", request.OdenenCariID);
                where += " and ODENEN_CARI_ID=@ODENEN_CARI_ID";
            }

            if (request.OdeyenCariID.HasValue)
            {
                cn.AddParams("@ODEYEN_CARI_ID", request.OdeyenCariID);
                where += " and ODEYEN_CARI_ID=@ODEYEN_CARI_ID";
            }

            if (request.OzelKod1ID.HasValue)
            {
                cn.AddParams("@ICRA_OZEL_KOD1_ID", request.OzelKod1ID);
                where += " and ICRA_OZEL_KOD1_ID=@ICRA_OZEL_KOD1_ID";
            }

            if (request.OzelKod2ID.HasValue)
            {
                cn.AddParams("@ICRA_OZEL_KOD2_ID", request.OzelKod2ID);
                where += " and ICRA_OZEL_KOD2_ID=@ICRA_OZEL_KOD2_ID";
            }
            if (request.OzelKod3ID.HasValue)
            {
                cn.AddParams("@ICRA_OZEL_KOD3_ID", request.OzelKod3ID);
                where += " and ICRA_OZEL_KOD3_ID=@ICRA_OZEL_KOD3_ID";
            }
            if (request.OzelKod4ID.HasValue)
            {
                cn.AddParams("@ICRA_OZEL_KOD4_ID", request.OzelKod4ID);
                where += " and ICRA_OZEL_KOD4_ID=@ICRA_OZEL_KOD4_ID";
            }

            if (!request.OdemeTarihi.HasValue)
            {
                if (ZamanDilimi != "Tumu")
                    where += Metotlar.ZamanDilimiParametresiOlustur(cn, "ODEME_TARIHI", ZamanDilimi);
            }

            return cn.GetDataTable("select SEGMENT_ID as SegmentId, ODEYEN_CARI as OdeyenCari, ODENEN_CARI as OdenenCari, ADLI_BIRIM_ADLIYE as AdliBirimAdliye, ADLI_BIRIM_NO as AdliBirimNo, ESAS_NO as EsasNo, TAKIBIN_AVUKATA_INTIKAL_TARIHI as TakibinAvukataIntikalTarihi, TAKIP_TARIHI as TakipTarihi, ODEME_YERI as OdemeYeri, ODEME_TARIHI as OdemeTarihi, ICRADAN_CEKILME_TARIHI as IcradanCekilmeTarihi, ODEME_TIP as OdemeTip, ODEME_MIKTAR as OdemeMiktar, ODEME_MIKTAR_DOVIZ_ID as OdemeMiktarDovizId, SUBE_KOD_ID as SubeKodId, IZLEYEN as Izleyen, SORUMLU as Sorumlu, DURUM as Durum, ICRA_OZEL_KOD1_ID as IcraOzelKod1Id, ICRA_OZEL_KOD2_ID as IcraOzelKod2Id, ICRA_OZEL_KOD3_ID as IcraOzelKod3Id, ICRA_OZEL_KOD4_ID as IcraOzelKod4Id, ODEME_KIM_ADINA as OdemeKimAdina, ADLI_BIRIM_GOREV as AdliBirimGorev, KALAN as Kalan, KALAN_DOVIZ_ID as KalanDovizId, RISK_MIKTARI as RiskMiktari, RISK_MIKTARI_DOVIZ_ID as RiskMiktariDovizId, FORM_TIP_ID as FormTipId, TAKIP_EDEN as TakipEden, TAKIP_EDILEN as TakipEdilen, KIYMETLI_EVRAKI_BILGILERI_ID as KiymetliEvrakBilgileriId, KIYMETLI_EVRAK_VADE_TARIHI as KiymetliEvrakVadeTarihi, KIYMETLI_EVRAK_ODENDI_MI as KiymetliEvrakOdendiMi, MAAS_HACZINDEN_MI as MaasHaczindenMi, IHTIYATI_HACIZDE_MI as IhtiyatiHacizdenMi, BORCLU_ADINA_ODEYEN as BorcluAdinaOdeyen, BORCLU_ADINA_ODENEN as BorcluAdinaOdenen, ALACAK_NEDEN_ID as AlacakNedenId, ID as Id from dbo.R_EXPRESS_BORCLU_ODEME_PROJE(nolock)" + where);
        }

        //    if (!string.IsNullOrEmpty(request.SeriNo))
        //        sonuc = sonuc.Where(f => f.SeriNo == request.SeriNo).ToList();
        public static Model.EntityClasses.Av001TiBilVekaletSozlesmeEntity GetSozlesmeById(int vekaletSozlesmeId)
        {
            var sonuc = BaseService._db.Av001TiBilVekaletSozlesme.Where(s => s.Id == vekaletSozlesmeId).Single();

            return sonuc;
        }

        //    return sonuc;
        //}
        public static string GetTakipTalepById(int takipTalepId)
        {
            return BaseService._db.PerTiKodTakipTalep.Where(t => t.Id == takipTalepId).Select(t => t.TalepAdi).FirstOrDefault();
        }

        //    if (request.FaturaTarihi.HasValue)
        //        sonuc = sonuc.Where(f => f.FaturaTarih == request.FaturaTarihi).ToList();
        public static void OzelKodKaydet(List<Model.EntityClasses.Av001TdiKodFoyOzelEntity> ozelKodlar)
        {
            try
            {
                foreach (var ozelKod in ozelKodlar)
                    ozelKod.Save();
            }
            catch (System.Exception)
            {
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        //aykut hızlandırma 28.01.2013
        //public static List<Model.EntityClasses.RBilFaturaModulEntity> GetAllFatura()
        //{
        //    var sonuc = BaseService._db.RBilFaturaModul.ToList();

        //    return sonuc;
        //}

        //public static List<Model.EntityClasses.RBilFaturaModulEntity> GetAllFaturaByFiltre(Messaging.GetFaturaByFiltreRequest request)
        //{
        //    List<AvukatPro.Model.EntityClasses.RBilFaturaModulEntity> sonuc = BaseService._db.RBilFaturaModul.ToList();

        //    if (request.Modul.HasValue)
        //    {
        //        sonuc = sonuc.Where(f => f.FaturaHedefTip == (int)request.Modul).ToList();
        //        if (request.DosyaIds.Count > 0)
        //        {
        //            List<AvukatPro.Model.EntityClasses.RBilFaturaModulEntity> yeniSonuc = new List<AvukatPro.Model.EntityClasses.RBilFaturaModulEntity>();
        //            foreach (var id in request.DosyaIds)
        //            {
        //                yeniSonuc.AddRange(BaseService._db.RBilFaturaModul.Where(m => m.FoyId == id).ToList());
        //            }
        //            sonuc = yeniSonuc;
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(request.ReferansNo))
        //        sonuc = sonuc.Where(f => f.ReferansNo == request.ReferansNo).ToList();

        //    if (request.FaturaKapsamTipi.HasValue)
        //        sonuc = sonuc.Where(f => f.FaturaKapsamTip == request.FaturaKapsamTipi).ToList();

        //    if (request.CariId.HasValue)
        //        sonuc = sonuc.Where(f => f.CariId == request.CariId).ToList();
        //aykut hızlandırma 08.02.2013
        //public static List<Model.EntityClasses.RBirlesikTakiplerTebligatEntity> GetAllTebligatByFiltre(Messaging.GetTebligatByFiltreRequest request)
        //{
        //    List<Model.EntityClasses.RBirlesikTakiplerTebligatEntity> sonuc;

        //    if (request.KullaniciSubeID.HasValue)
        //        sonuc = BaseService._db.RBirlesikTakiplerTebligat.Where(t => t.SubeKodId == request.KullaniciSubeID).ToList();
        //    else
        //        sonuc = BaseService._db.RBirlesikTakiplerTebligat.ToList();

        //    if (request.Modul.HasValue)
        //    {
        //        sonuc = sonuc.Where(t => t.Tipi == request.Modul.ToString()).ToList();
        //        if (request.DosyaID.HasValue)
        //            sonuc = sonuc.Where(t => t.FoyId == request.DosyaID).ToList();
        //    }

        //    if (!string.IsNullOrEmpty(request.Barkod))
        //        sonuc = sonuc.Where(t => t.PttBarkodNo == request.Barkod).ToList();
        //    if (request.KonuID.HasValue)
        //        sonuc = sonuc.Where(t => t.TakipKonusu == request.KonuID).ToList();
        //    if (request.MuhatapID.HasValue)
        //        sonuc = sonuc.Where(t => t.MuhatapCariId == request.MuhatapID).ToList();
        //    if (request.PostalamaTarihi.HasValue)
        //        sonuc = sonuc.Where(t => t.PostalanmaTarih == request.PostalamaTarihi).ToList();
        //    if (!string.IsNullOrEmpty(request.ReferansNo))
        //        sonuc = sonuc.Where(t => t.Referans1 == request.ReferansNo || t.Referans2 == request.ReferansNo || t.Referans3 == request.ReferansNo || t.Referans4 == request.ReferansNo || t.Referans5 == request.ReferansNo).ToList();
        //    if (request.TebligatAltTur.HasValue)
        //        sonuc = sonuc.Where(t => t.AltTurId == request.TebligatAltTur).ToList();

        //    return sonuc;
        //}
        //aykut hızlandırma 14.02.2013
        //public static List<Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity> GetAllBelgeByFiltre(Messaging.GetBelgeByFiltreRequest request)
        //{
        //    List<Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity> sonuc;

        //    if (request.KullaniciSubeID.HasValue)
        //        sonuc = BaseService._db.RBirlesikTakiplerTumuBelge.Where(t => t.SubeKodId == request.KullaniciSubeID).ToList();
        //    else
        //        sonuc = BaseService._db.RBirlesikTakiplerTumuBelge.ToList();

        //    if (request.Modul.HasValue)
        //    {
        //        sonuc = sonuc.Where(t => t.ModulId == (int)request.Modul).ToList();
        //        if (request.DosyaID.HasValue)
        //            sonuc = sonuc.Where(t => t.FoyId == request.DosyaID).ToList();
        //    }

        //    if (!string.IsNullOrEmpty(request.BarkodNo))
        //        sonuc = sonuc.Where(t => t.BarkodNo == request.BarkodNo).ToList();
        //    if (!string.IsNullOrEmpty(request.BelgeAdi))
        //        sonuc = sonuc.Where(t => t.BelgeAdi == request.BelgeAdi).ToList();
        //    if (!string.IsNullOrEmpty(request.BelgeNo))
        //        sonuc = sonuc.Where(t => t.DosyaNo == request.BelgeNo).ToList();
        //    if (request.DurumID.HasValue)
        //        sonuc = sonuc.Where(t => t.Durum == request.DurumID).ToList();
        //    if (!string.IsNullOrEmpty(request.RefNo))
        //        sonuc = sonuc.Where(t => t.Referans1 == request.RefNo || t.Referans2 == request.RefNo || t.Referans3 == request.RefNo).ToList();
        //    if (request.TurID.HasValue)
        //        sonuc = sonuc.Where(t => t.BelgeTurId == request.TurID).ToList();
    }
}