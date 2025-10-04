//using System.Windows.Forms;
using AvukatProLib.Hesap.DovizAPI;

//using AdimAdimDavaKaydi.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;

namespace AvukatProLib.Hesap
{
    public enum DovizTip
    {
        NULL = 0,
        TL = 1,
        USD = 2,
        AUD = 3,
        DKK = 4,
        GBP = 5,
        CHF = 6,
        SEK = 7,
        JPY = 8,
        CAD = 9,
        KWD = 10,
        NOK = 11,
        SAR = 12,
        EUR = 13,
        BGL = 14,
        ROL = 16,
        SYP = 17,
        JOD = 19,
        ILS = 20,
        FRF = 21,
        DEM = 22,
        NLG = 23,
        BEF = 24,
        ATS = 26,
        ESP = 27,
        FIM = 28,
        FYP = 29,
        GRD = 30,
        IEP = 31,
        IRR = 32,
        ITL = 33,
        LUF = 34,
        PTE = 35
    }

    public class DovizHelper
    {
        # region Static Members

        //Çek ve Senet Alacaklarý. Alacak Neden Kod ID'leri bu List üzerinden kontrol edilecek. MB
        public static int[] AlacakIDArray = new int[] { 1, 33, 34, 35, 129, 130, 131, 132, 137, 138, 139, 140, 2, 11, 36, 38 };

        public static int AlacakNedenKodID = 0;
        public static AvukatProLib.Arama.AvpDataContext dataCon = BelgeUtil.Inits.context;
        public static RaporDataSource.ViewDB.AvukatProViewDataContext dataCon2 = null;
        public static List<DovizIDGunTL> kurlar = new List<DovizIDGunTL>();

        //Çek ve Senet alacaklarýnda true deðer alacak. MB
        public static byte MerkezBankasindanmi = 0;

        //Default Banka Protokolleri Geliyor. Merkez Bankasý olmasý gerekenlere CevirYTL metodu çaðýrýlýrken deðer 1 deðeri verilecek.
        public static List<int> MerkezKuruAlacaklarList = new List<int>(AlacakIDArray);

        //Yeni kur bilgisi girildiðinden kurlarýn refresh olmasýný saðlamak için eklendi. MB
        public static bool YeniKurBilgisiGirildi = false;

        /// <summary>
        /// Verilen <paramref name="para"/> ve <paramref name="dovizId"/> deðerlerini <paramref name="gun"/> tarihindeki kurdan YTL ye çevirir
        /// </summary>
        /// <param name="para">çevirilecek tutar</param>
        /// <param name="dovizId"><paramref name="para"/> tutarýnýn doviz tip Id si</param>
        /// <param name="gun">Kur tarihi</param>
        /// <returns>Verilen parametrelere göre çevirilmiþ tutar </returns>
        ///

        /// <summary>
        ///
        /// </summary>
        /// <param name="neyi"></param>
        /// <param name="neyeDovizId"></param>
        /// <param name="gun"></param>
        /// <returns></returns>
        public static decimal CaprazCevir(ParaVeDovizId neyi, int neyeDovizId, DateTime gun)
        {
            if (neyi.Para == 0)
                return decimal.Zero;

            if (neyi.DovizId == neyeDovizId)
                return neyi.Para;
            if (neyeDovizId == 1)
                return neyi.YtlCevir(gun);

            decimal deci = neyi.YtlCevir(gun);

            TDI_CET_GUNLUK_DOVIZ_KUR kur = kurGetir(neyeDovizId, gun);
            decimal result = deci / (kur.TL_DEGERI == 0 ? 1 : kur.TL_DEGERI);
            return result;
        }

        public static string CevirString(int p)
        {
            DovizTip dTip = (DovizTip)p;
            return dTip.ToString();
        }

        public static decimal CevirYTL(decimal para, int dovizId, DateTime gun, int? alacakNedenKodID)
        {
            if (!alacakNedenKodID.HasValue) return 0;
            AlacakNedenKodID = alacakNedenKodID.Value;
            return CevirYTL(para, dovizId, gun);
        }

        public static decimal CevirYTL(decimal para, int? dovizId, DateTime gun, int? alacakNedenKodID)
        {
            if (!alacakNedenKodID.HasValue) return 0;
            AlacakNedenKodID = alacakNedenKodID.Value;
            return CevirYTL(para, dovizId, gun);
        }

        public static decimal CevirYTL(decimal para, int dovizId, DateTime gun)
        {
            if (YeniKurBilgisiGirildi) { kurlar.Clear(); YeniKurBilgisiGirildi = false; }

            //var kurLinq = from tbl in kurlar where tbl.DovizID == dovizId && tbl.Gun == gun.Date select tbl.TLKuru;

            if (dovizId == 2)
                gun = DateTime.Today;

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            cn.AddParams("@DOVIZ_ID", dovizId);
            DataTable dt = cn.GetDataTable("SELECT TOP(1)TL_DEGERI FROM dbo.TDI_CET_GUNLUK_DOVIZ_KUR WHERE TARIH<=CONVERT(datetime,'"+gun.ToShortDateString()+"', 103) AND DOVIZ_ID=@DOVIZ_ID ORDER BY TARIH DESC");

            //if (kurLinq.Count() == 0)
            if (dt.Rows.Count > 0)
            {
                if (dovizId < 1)
                    return para;

                //TDI_CET_GUNLUK_DOVIZ_KUR kur = null;
                //if (dovizId == 1)
                //{
                //    kur = new TDI_CET_GUNLUK_DOVIZ_KUR();
                //    kur.TL_DEGERI = 1;
                //}
                //else
                //{
                //    kur = kurGetir(dovizId, gun);
                //}
                DovizIDGunTL yeniKur = new DovizIDGunTL();
                yeniKur.DovizID = dovizId;
                yeniKur.Gun = gun;
                yeniKur.TLKuru = Convert.ToDecimal(dt.Rows[0][0].ToString());
                kurlar.Add(yeniKur);

                return para * Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                return para;
            }
        }

        /// <summary>
        /// Verilen <paramref name="para"/> ve <paramref name="dovizId"/> deðerlerini <paramref name="gun"/> tarihindeki kurdan YTL ye çevirir
        /// </summary>
        /// <param name="para">çevirilecek tutar</param>
        /// <param name="dovizId"><paramref name="para"/> tutarýnýn doviz tip Id si <c>null ise 0 geri döner</c></param>
        /// <param name="gun">Kur tarihi</param>
        /// <returns>Verilen parametrelere göre çevirilmiþ tutar </returns>
        public static decimal CevirYTL(decimal para, int? dovizId, DateTime gun)
        {
            if (dovizId.HasValue)
            {
                return CevirYTL(para, dovizId.Value, gun);
            }
            else
            {
                return 0;
            }
        }

        public static decimal CevirYTL(decimal? para, int? dovizId, DateTime gun)
        {
            if (dovizId.HasValue && para.HasValue)
            {
                return CevirYTL(para.Value, dovizId.Value, gun);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Verilen tarihteki(<paramref name="gun"/>) kurlarý internet üzerinden günceller
        /// </summary>
        /// <param name="gun">kurlarýn güncelleneceði tarih</param>
        public static void DovizleriGuncelleGuneGore(DateTime gun)
        {
            int k = 0;
            int i = DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.GetTotalItems("TARIH = '" + gun.ToString("MM/dd/yyyy 00:00:00") + "'", out k);
            if (k > 0)
                return;
            System.Globalization.NumberFormatInfo formatProvider = new System.Globalization.NumberFormatInfo();
            formatProvider.NumberDecimalSeparator = ".";
            formatProvider.NumberGroupSeparator = ",";
            formatProvider.NumberGroupSizes = new int[] { 3 };
            AVP_NG_DOVIZ_SOAP_API_NENC m = new AVP_NG_DOVIZ_SOAP_API_NENC();
            m.Url = "http://www.avukatpro.com/AVPNG/AVP_NG_DOVIZ_SOAP_API_NENC.asmx";
            if (Kimlikci.Kimlik.SirketBilgisi.GuncelProxyKullan && !String.IsNullOrEmpty(Kimlikci.Kimlik.SirketBilgisi.ProxySunucuAdresi) && !String.IsNullOrEmpty(Kimlikci.Kimlik.SirketBilgisi.ProxySunucuPortu))
            {
                int portNo = 0;
                Int32.TryParse(Kimlikci.Kimlik.SirketBilgisi.ProxySunucuPortu, out portNo);
                if (portNo == 0)
                    portNo = 8080;
                WebProxy proxyObject = new WebProxy(Kimlikci.Kimlik.SirketBilgisi.ProxySunucuAdresi, Convert.ToInt32(Kimlikci.Kimlik.SirketBilgisi.ProxySunucuPortu));
                if (!String.IsNullOrEmpty(Kimlikci.Kimlik.SirketBilgisi.ProxyKullaniciAdi))
                {
                    m.UseDefaultCredentials = false;
                    proxyObject.Credentials = new NetworkCredential(Kimlikci.Kimlik.SirketBilgisi.ProxyKullaniciAdi, Kimlikci.Kimlik.SirketBilgisi.ProxyParola);
                    proxyObject.BypassProxyOnLocal = true;
                }
                m.Proxy = proxyObject;
            }

            //m.Proxy = new System.Net.WebProxy("192.9.0.145", 108);
            //m.Proxy.Credentials = new System.Net.NetworkCredential("proUsr1", "123");

            TList<TDI_KOD_DOVIZ_TIP> tipler = DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetAll();
            TList<TDI_CET_GUNLUK_DOVIZ_KUR> kurlar = new TList<TDI_CET_GUNLUK_DOVIZ_KUR>();
            DataSet onlineKur = m.GunlukKurGetir(DateTime.Today.ToString("ddMMyyyy 7652626"), gun.Date);
            foreach (TDI_KOD_DOVIZ_TIP tip in tipler)
            {
                DataRow[] buldum = onlineKur.Tables[1].Select(String.Format("KOD = '{0}'", tip.DOVIZ_KODU));
                if (buldum.Length > 0)
                {
                    try
                    {
                        TDI_CET_GUNLUK_DOVIZ_KUR kur = new TDI_CET_GUNLUK_DOVIZ_KUR();
                        kur.TARIH = gun.Date;
                        kur.DOVIZ_IDSource = tip;
                        kur.DOVIZ_ID = tip.ID;
                        // BUG: Kültüre göre farklýlýk gösterebilir (CultureInfo!?#)
                        // -- Sanýrým çözüldü ve kontrol edildi izlenmesi gerekiyor

                        kur.TL_DEGERI = Convert.ToDecimal(buldum[0]["BanknoteSelling"], formatProvider);
                        kur.ADMIN_KAYIT_MI = 1;
                        kur.SUBE_KODU = 1;
                        kur.STAMP = 1;
                        kur.KONTROL_KIM = "AVUKATPRO";//AvukatProLib.Kimlik.KullaniciAdi;
                        kur.KONTROL_NE_ZAMAN = DateTime.Now;
                        kur.KONTROL_VERSIYON = 1;
                        kurlar.Add(kur);
                    }
                    catch (Exception ex)
                    { }
                }
            }

            DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.Save(kurlar);
        }

        public static void GetMerkezBankasiBilgisi(AV001_TI_BIL_ALACAK_NEDEN_TARAF aNedenTaraf)
        {
            if (BelgeUtil.Inits._AlacakNEdenGetir == null)
                BelgeUtil.Inits._AlacakNEdenGetir = BelgeUtil.Inits.context.per_AV001_TI_BIL_ALACAK_NEDENs.ToList();
            var alacak = BelgeUtil.Inits._AlacakNEdenGetir.Find(vi => vi.ALACAK_NEDEN_ID == aNedenTaraf.ICRA_ALACAK_NEDEN_ID.Value && vi.AN_URETIP_TIP != (int)AvukatProLib.Extras.AN_URETIP_TIP.MunzamSenet);

            if (alacak == null) return;
            if (!alacak.ALACAK_NEDEN_KOD_ID.HasValue) return;

            GetMerkezBankasiBilgisi(alacak.ALACAK_NEDEN_KOD_ID.Value);
        }

        public static void GetMerkezBankasiBilgisi(int? aNedenKodID)
        {
            if (!aNedenKodID.HasValue) return;
            GetMerkezBankasiBilgisi(aNedenKodID.Value);
        }

        public static void GetMerkezBankasiBilgisi(int aNedenKodID)
        {
            if (MerkezKuruAlacaklarList.Contains(aNedenKodID))
                MerkezBankasindanmi = 1;
            else
                MerkezBankasindanmi = 0;
        }

        public static TDI_CET_GUNLUK_DOVIZ_KUR kurGetir(int dovizId, DateTime gun)
        {
            gun = gun.Date;

            if (gun.DayOfWeek == DayOfWeek.Sunday) //Pazar Günleri Güncelleme Olmadýðý Ýçin Cumartesi Günü Kuru Kullanýlacak
                gun = gun.AddDays(-1);

            TDI_CET_GUNLUK_DOVIZ_KUR kur = null;
            int updated;
            try
            {
                if (dataCon != null)
                {
                    if (BelgeUtil.Inits.PaketAdi == 1)
                        updated = (from tbl in dataCon.per_TDI_CET_GUNLUK_DOVIZ_KURs where tbl.TARIH.Value.Date == gun.Date && tbl.DOVIZ_ID == dovizId && tbl.ADMIN_KAYIT_MI.Value == MerkezBankasindanmi select tbl.DOVIZ_ID).Count();
                    else
                        updated = (from tbl in dataCon.per_TDI_CET_GUNLUK_DOVIZ_KURs where tbl.TARIH.Value.Date == gun.Date && tbl.DOVIZ_ID == dovizId select tbl.DOVIZ_ID).Count();
                }
                else
                {
                    if (BelgeUtil.Inits.PaketAdi == 1)
                        updated = (from tbl in dataCon2.per_TDI_CET_GUNLUK_DOVIZ_KURs where tbl.TARIH.Value.Date == gun.Date && tbl.DOVIZ_ID == dovizId && tbl.ADMIN_KAYIT_MI.Value == MerkezBankasindanmi select tbl.DOVIZ_ID).Count();
                    else
                        updated = (from tbl in dataCon2.per_TDI_CET_GUNLUK_DOVIZ_KURs where tbl.TARIH.Value.Date == gun.Date && tbl.DOVIZ_ID == dovizId select tbl.DOVIZ_ID).Count();
                }

                //Ýþlem tarihinde kur bilgisi yok, internetten merkez bankasý kur çekilecek. Banka kullanýcýsý deðil. MB
                if (updated == 0 && BelgeUtil.Inits.PaketAdi != 1)
                {
                    DovizleriGuncelleGuneGore(gun);

                    if (dataCon != null)
                        updated = (from tbl in dataCon.per_TDI_CET_GUNLUK_DOVIZ_KURs where tbl.TARIH.Value.Date == gun.Date && tbl.DOVIZ_ID == dovizId select tbl.DOVIZ_ID).Count();
                    else
                        updated = (from tbl in dataCon2.per_TDI_CET_GUNLUK_DOVIZ_KURs where tbl.TARIH.Value.Date == gun.Date && tbl.DOVIZ_ID == dovizId select tbl.DOVIZ_ID).Count();
                }
            }
            catch
            {
                if (kur == null)
                {
                    kur = new TDI_CET_GUNLUK_DOVIZ_KUR();
                    kur.TL_DEGERI = 1;
                }
                return kur;
            }
            DovizKur updatedDoviz;
            bool yakinTarihli = false;
            if (dataCon != null)
            {
                if (updated == 0)
                {
                    //bu bloða paket kontrolü yapmaya gerek yok. çünkü banka dýþýndaki kullanýcýlarda internet baðlantýsý olduðundan merkez bankasý kurlarý çekildiðinde updated == 0 olma olasýlýðý yok. MB
                    updatedDoviz = (from tbl in dataCon.per_TDI_CET_GUNLUK_DOVIZ_KURs where tbl.TARIH.Value.Date <= gun && tbl.DOVIZ_ID == dovizId && tbl.ADMIN_KAYIT_MI.Value == MerkezBankasindanmi orderby tbl.TARIH descending select new DovizKur { ID = tbl.ID, DOVIZ = tbl.DOVIZ, DOVIZ_ID = tbl.DOVIZ_ID.Value, KONTROL_TARIH = tbl.KONTROL_NE_ZAMAN.Value, TARIH = tbl.TARIH.Value, TL_DEGERI = tbl.TL_DEGERI.Value, MERKEZ_BANKASI_KURU = MerkezBankasindanmi }).FirstOrDefault();
                    yakinTarihli = true;
                }
                else
                {
                    if (BelgeUtil.Inits.PaketAdi == 1)
                        updatedDoviz = (from tbl in dataCon.per_TDI_CET_GUNLUK_DOVIZ_KURs where tbl.TARIH.Value.Date == gun && tbl.DOVIZ_ID == dovizId && tbl.ADMIN_KAYIT_MI.Value == MerkezBankasindanmi select new DovizKur { ID = tbl.ID, DOVIZ = tbl.DOVIZ, DOVIZ_ID = tbl.DOVIZ_ID.Value, KONTROL_TARIH = tbl.KONTROL_NE_ZAMAN.Value, TARIH = tbl.TARIH.Value, TL_DEGERI = tbl.TL_DEGERI.Value, MERKEZ_BANKASI_KURU = MerkezBankasindanmi }).FirstOrDefault();
                    else
                        updatedDoviz = (from tbl in dataCon.per_TDI_CET_GUNLUK_DOVIZ_KURs where tbl.TARIH.Value.Date == gun && tbl.DOVIZ_ID == dovizId /*&& tbl.ADMIN_KAYIT_MI.Value == MerkezBankasindanmi*/ select new DovizKur { ID = tbl.ID, DOVIZ = tbl.DOVIZ, DOVIZ_ID = tbl.DOVIZ_ID.Value, KONTROL_TARIH = tbl.KONTROL_NE_ZAMAN.Value, TARIH = tbl.TARIH.Value, TL_DEGERI = tbl.TL_DEGERI.Value }).FirstOrDefault();
                    yakinTarihli = false;
                }
            }
            else
            {
                if (updated == 0)
                {
                    //bu bloða paket kontrolü yapmaya gerek yok. çünkü banka dýþýndaki kullanýcýlarda internet baðlantýsý olduðundan merkez bankasý kurlarý çekildiðinde updated == 0 olma olasýlýðý yok. MB
                    updatedDoviz = (from tbl in dataCon2.per_TDI_CET_GUNLUK_DOVIZ_KURs where tbl.TARIH.Value.Date <= gun && tbl.DOVIZ_ID == dovizId && tbl.ADMIN_KAYIT_MI.Value == MerkezBankasindanmi orderby tbl.TARIH descending select new DovizKur { ID = tbl.ID, DOVIZ = tbl.DOVIZ, DOVIZ_ID = tbl.DOVIZ_ID.Value, KONTROL_TARIH = tbl.KONTROL_NE_ZAMAN.Value, TARIH = tbl.TARIH.Value, TL_DEGERI = tbl.TL_DEGERI.Value, MERKEZ_BANKASI_KURU = MerkezBankasindanmi }).FirstOrDefault();
                    yakinTarihli = true;
                }
                else
                {
                    if (BelgeUtil.Inits.PaketAdi == 1)
                        updatedDoviz = (from tbl in dataCon2.per_TDI_CET_GUNLUK_DOVIZ_KURs where tbl.TARIH.Value.Date == gun && tbl.DOVIZ_ID == dovizId && tbl.ADMIN_KAYIT_MI.Value == MerkezBankasindanmi select new DovizKur { ID = tbl.ID, DOVIZ = tbl.DOVIZ, DOVIZ_ID = tbl.DOVIZ_ID.Value, KONTROL_TARIH = tbl.KONTROL_NE_ZAMAN.Value, TARIH = tbl.TARIH.Value, TL_DEGERI = tbl.TL_DEGERI.Value, MERKEZ_BANKASI_KURU = MerkezBankasindanmi }).FirstOrDefault();
                    else
                        updatedDoviz = (from tbl in dataCon2.per_TDI_CET_GUNLUK_DOVIZ_KURs where tbl.TARIH.Value.Date == gun && tbl.DOVIZ_ID == dovizId /*&& tbl.ADMIN_KAYIT_MI.Value == MerkezBankasindanmi*/ select new DovizKur { ID = tbl.ID, DOVIZ = tbl.DOVIZ, DOVIZ_ID = tbl.DOVIZ_ID.Value, KONTROL_TARIH = tbl.KONTROL_NE_ZAMAN.Value, TARIH = tbl.TARIH.Value, TL_DEGERI = tbl.TL_DEGERI.Value }).FirstOrDefault();
                    yakinTarihli = false;
                }
            }

            if (updatedDoviz != null)
            {
                kur = new TDI_CET_GUNLUK_DOVIZ_KUR();
                kur.ID = updatedDoviz.ID;
                kur.DOVIZ = updatedDoviz.DOVIZ;
                kur.DOVIZ_ID = updatedDoviz.DOVIZ_ID;
                kur.TL_DEGERI = updatedDoviz.TL_DEGERI;
                kur.TARIH = updatedDoviz.TARIH;
                kur.KONTROL_NE_ZAMAN = updatedDoviz.KONTROL_TARIH;
                if (BelgeUtil.Inits.PaketAdi == 1)
                    kur.ADMIN_KAYIT_MI = updatedDoviz.MERKEZ_BANKASI_KURU;
            }
            if (kur == null)
            {
                kur = new TDI_CET_GUNLUK_DOVIZ_KUR();
                kur.TL_DEGERI = 1;
            }
            if (yakinTarihli)
            {
                if (BelgeUtil.Inits.PaketAdi != 1)
                    System.Windows.Forms.MessageBox.Show(string.Format("{0} tarihinde {1} döviz tipi için 'Merkez Bankasý' kur bilgisi olmadýðýndan \r\nhesap iþlemi {2} tarihine göre yapýldý.\r\nHesabý tam olarak alabilmek için {0} tarihine {1} döviz tipi için \r\nkur giriþi yapmalýsýnýz.", gun.Date.ToShortDateString(), kur.DOVIZ, kur.TARIH.Date.ToShortDateString()));
                else if (MerkezBankasindanmi == 1) System.Windows.Forms.MessageBox.Show(string.Format("{0} tarihinde {1} döviz tipi için 'Merkez Bankasý' kur bilgisi olmadýðýndan \r\nhesap iþlemi {2} tarihine göre yapýldý.\r\nHesabý tam olarak alabilmek için {0} tarihine {1} döviz tipi için \r\nkur giriþi yapmalýsýnýz.", gun.Date.ToShortDateString(), kur.DOVIZ, kur.TARIH.Date.ToShortDateString()));
                else
                    System.Windows.Forms.MessageBox.Show(string.Format("{0} tarihinde {1} döviz tipi için 'Banka' kur bilgisi olmadýðýndan \r\nhesap iþlemi {2} tarihine göre yapýldý.\r\nHesabý tam olarak alabilmek için {0} tarihine {1} döviz tipi için \r\nkur giriþi yapmalýsýnýz.", gun.Date.ToShortDateString(), kur.DOVIZ, kur.TARIH.Date.ToShortDateString()));
            }
            return kur;
        }

        private class DovizKur
        {
            public string DOVIZ { set; get; }

            public int DOVIZ_ID { set; get; }

            public int ID { set; get; }

            public DateTime KONTROL_TARIH { set; get; }

            public byte MERKEZ_BANKASI_KURU { get; set; }

            public DateTime TARIH { set; get; }

            public decimal TL_DEGERI { set; get; }
        }

        #endregion
    }

    public class DovizIDGunTL
    {
        public int DovizID { set; get; }

        public DateTime Gun { set; get; }

        public decimal TLKuru { set; get; }
    }
}