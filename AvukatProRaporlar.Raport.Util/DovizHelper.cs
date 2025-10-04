using AvukatProLib;
using AvukatProRaporlar.Raport.Util;
using AvukatProRaporlar.Raport.Util.DovizAPI;
using AvukatProRaporlar.Raport.Util.Inits;
using RaporDataSource.TableDB;
using RaporDataSource.ViewDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace AvukatProRaporlar.Util
{
    public enum DovizTip
    {
        NULL = 0,
        YTL = 1,
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
        #region Static Members

        /// <summary>
        /// Verilen tarihteki(
        /// <paramref name="gun"/>) kurlarý internet üzerinden günceller
        /// </summary>
        /// <param name="gun">kurlarýn güncelleneceði tarih</param>
        private Connection conn = new Connection();

        /// <summary>
        ///
        /// </summary>
        /// <param name="neyi"></param>
        /// <param name="neyeDovizId"></param>
        /// <param name="gun"></param>
        /// <returns></returns>
        public static decimal CaprazCevir(ParaVeDovizId neyi, int neyeDovizId, DateTime gun)
        {
            if (neyi.DovizId == neyeDovizId)
                return neyi.Para;
            decimal deci = neyi.YtlCevir(gun);
            TDI_CET_GUNLUK_DOVIZ_KUR kur = kurGetir(neyeDovizId, gun);
            decimal result = deci * kur.TL_DEGERI;
            return result;
        }

        // //DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.Save(kurlar);
        //}
        public static string CevirString(int p)
        {
            DovizTip dTip = (DovizTip)p;
            return dTip.ToString();
        }

        /// <summary>
        /// Verilen
        /// <paramref name="para"/>ve
        /// <paramref name="dovizId"/>deðerlerini
        /// <paramref name="gun"/>tarihindeki kurdan YTL ye çevirir
        /// </summary>
        /// <param name="para">çevirilecek tutar</param>
        /// <param name="dovizId"><paramref name="para"/> tutarýnýn doviz tip Id si</param>
        /// <param name="gun">Kur tarihi</param>
        /// <returns>Verilen parametrelere göre çevirilmiþ tutar</returns>
        public static decimal CevirYTL(decimal para, int dovizId, DateTime gun)
        {
            if (dovizId < 1)
                return para;
            TDI_CET_GUNLUK_DOVIZ_KUR kur = null;
            if (dovizId == 1)
            {
                kur = new TDI_CET_GUNLUK_DOVIZ_KUR();
                kur.TL_DEGERI = 1;
            }
            else
            {
                kur = kurGetir(dovizId, gun);
            }

            // try { DovizleriGuncelleGuneGore(gun); } catch (Exception ex) {
            // //BelgeUtil.ErrorHandler.Catch(new DovizHelper(), ex); //throw new
            // Exception("Err:26001 Ýnternet baðlantý problemi"); }
            //}

            //while (kur == null)
            //{
            //    if (gun.Year <= 1900)
            //    {
            //        return para * 1;
            //    }

            // kur = DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.GetByDOVIZ_IDTARIH(dovizId,
            // gun); gun = gun.AddDays(-1); //return 1; //ToDo : Gökhan
            //}
            return para * 0;
        }

        /// <summary>
        /// Verilen
        /// <paramref name="para"/>ve
        /// <paramref name="dovizId"/>deðerlerini
        /// <paramref name="gun"/>tarihindeki kurdan YTL ye çevirir
        /// </summary>
        /// <param name="para">çevirilecek tutar</param>
        /// <param name="dovizId"><paramref name="para"/> tutarýnýn doviz tip Id si <c>null ise 0
        /// geri /c></param>
        /// <param name="gun">Kur tarihi</param>
        /// <returns>Verilen parametrelere göre çevirilmiþ tutar</returns>
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

        public static void DovizleriGuncelleGuneGore(DateTime gun)
        {
            //Connection conn = new Connection();
            //conn.MyConnection = CompInfo.CompInfoListGetir(Application.StartupPath)[0].ConStr;
            //DBDataContext db = new DBDataContext(conn.MyConnection);
            //AvukatProViewDataContext dbV = new AvukatProViewDataContext(conn.MyConnection);
            int k = 0;
            int i = InitsEx.db.TDI_CET_GUNLUK_DOVIZ_KURs.Where(vii => vii.TARIH == gun).Count();
            if (k > 0)
                return;
            System.Globalization.NumberFormatInfo formatProvider = new System.Globalization.NumberFormatInfo();
            formatProvider.NumberDecimalSeparator = ".";
            formatProvider.NumberGroupSeparator = ",";
            formatProvider.NumberGroupSizes = new int[] { 3 };

            AVP_NG_DOVIZ_SOAP_API_NENC m = new AVP_NG_DOVIZ_SOAP_API_NENC();
            m.Url = "http://www.avukatpro.com/AVPNG/AVP_NG_DOVIZ_SOAP_API_NENC.asmx";

            if (AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.GuncelProxyKullan && !String.IsNullOrEmpty(AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ProxySunucuAdresi) && !String.IsNullOrEmpty(AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ProxySunucuPortu))
            {
                int portNo = 0;
                Int32.TryParse(AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ProxySunucuPortu, out portNo);
                if (portNo == 0)
                    portNo = 8080;
                WebProxy proxyObject = new WebProxy(AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ProxySunucuAdresi, Convert.ToInt32(AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ProxySunucuPortu));
                if (!String.IsNullOrEmpty(AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ProxyKullaniciAdi))
                {
                    m.UseDefaultCredentials = false;
                    proxyObject.Credentials = new NetworkCredential(AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ProxyKullaniciAdi, AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ProxyParola);
                    proxyObject.BypassProxyOnLocal = true;
                }
                m.Proxy = proxyObject;
            }

            List<TDI_KOD_DOVIZ_TIP> tipler = InitsEx.db.TDI_KOD_DOVIZ_TIPs.ToList();
            List<TDI_CET_GUNLUK_DOVIZ_KUR> kurlar = new List<TDI_CET_GUNLUK_DOVIZ_KUR>();
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

                        //kur.DOVIZ_IDSource = tip;
                        kur.DOVIZ_ID = tip.ID;

                        // BUG: Kültüre göre farklýlýk gösterebilir (CultureInfo!?#)
                        // -- Sanýrým çözüldü ve kontrol edildi izlenmesi gerekiyor
                        var nobj = buldum[0]["BanknoteSelling"];

                        if (nobj.ToString() == string.Empty)
                            nobj = buldum[0][3];
                        kur.TL_DEGERI = Convert.ToDecimal(nobj, formatProvider);
                        kur.ADMIN_KAYIT_MI = 1;
                        kur.SUBE_KODU = 1;
                        kur.STAMP = 1;
                        kur.KONTROL_KIM = "AVUKATPRO";//AvukatProLib.Kimlik.KullaniciAdi;
                        kur.KONTROL_NE_ZAMAN = DateTime.Now;
                        kur.KONTROL_VERSIYON = 1;
                        kurlar.Add(kur);
                    }
                    catch 
                    { }
                }
            }
        }

        private static TDI_CET_GUNLUK_DOVIZ_KUR kurGetir(int dovizId, DateTime gun)
        {
            //Connection conn = new Connection();InitsEx
            //conn.MyConnection = CompInfo.CompInfoListGetir(Application.StartupPath)[0].ConStr;
            //DBDataContext db = new DBDataContext(conn.MyConnection);
            //

            //AvukatProViewDataContext dbV = new AvukatProViewDataContext(conn.MyConnection);
            //List<TDI_CET_GUNLUK_DOVIZ_KUR> kur = null;
            //DovizleriGuncelleGuneGore(gun);
            // var ds = db.TDI_CET_GUNLUK_DOVIZ_KURs.Where(vii => vii.DOVIZ_ID == dovizId && vii.TARIH == gun).OrderBy(vi => vi.TARIH).First();
            //dbV._TDI_CET_GUNLUK_DOVIZ_KUR_DovizGetirTarihDovizId(gun, dovizId);
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //if (ds !=null)
            //{
            //    kur = db.TDI_CET_GUNLUK_DOVIZ_KURs.Where(vii => vii.ID == ds.ID).ToList();

            //kur.ID = (int)ds.Tables[0].Rows[0]["ID"];
            //kur.DOVIZ_ID = (int)ds.Tables[0].Rows[0]["DOVIZ_ID"];
            //kur.DOVIZ = (string)ds.Tables[0].Rows[0]["DOVIZ"];
            //kur.TARIH = (DateTime)ds.Tables[0].Rows[0]["TARIH"];
            //kur.TL_DEGERI = (decimal)ds.Tables[0].Rows[0]["TL_DEGERI"];
            //kur.SUBE_KODU = (short)ds.Tables[0].Rows[0]["SUBE_KODU"];
            //kur.ADMIN_KAYIT_MI = (byte)ds.Tables[0].Rows[0]["ADMIN_KAYIT_MI"];
            //kur.KONTROL_NE_ZAMAN = (DateTime)ds.Tables[0].Rows[0]["KONTROL_NE_ZAMAN"];
            //kur.KONTROL_KIM = (string)ds.Tables[0].Rows[0]["KONTROL_KIM"];
            //kur.KONTROL_VERSIYON = (int)ds.Tables[0].Rows[0]["KONTROL_VERSIYON"];
            //kur.STAMP = (short)ds.Tables[0].Rows[0]["STAMP"];
            //kur.KONTROL_KIM_ID = ds.Tables[0].Rows[0]["KONTROL_KIM_ID"] != DBNull.Value ? (int?)ds.Tables[0].Rows[0]["KONTROL_KIM_ID"] : null;
            //kur.SUBE_KOD_ID = ds.Tables[0].Rows[0]["SUBE_KOD_ID"] != DBNull.Value ? (int?)ds.Tables[0].Rows[0]["SUBE_KOD_ID"] : null;

            // } if (kur[0] == null) { kur[0] = new TDI_CET_GUNLUK_DOVIZ_KUR(); ds.TL_DEGERI = 0;

            // }

            //    return kur[0];
            //}
            //else
            return null;
        }

        #endregion Static Members
    }

    public class ParaVeDovizId
    {
        public ParaVeDovizId()
        {
        }

        public ParaVeDovizId(decimal? para, int? dovizId)
        {
            _Para = 0;
            _DovizId = 1;
            if (para != null)
                _Para = para.Value;
            if (dovizId != null)
                _DovizId = dovizId.Value;
        }

        public ParaVeDovizId(decimal para, int dovizId)
        {
            _Para = para;
            _DovizId = dovizId;
        }

        public ParaVeDovizId(decimal para, int? dovizId)
        {
            _Para = para;
            if (dovizId.HasValue)
                _DovizId = dovizId.Value;
            else
            {
                _DovizId = 1;
            }
        }

        public ParaVeDovizId(decimal para, int dovizId, DateTime? pKurCevrimTarihi)
            : this(para, dovizId)
        {
            this.KurCevrimTarihi = pKurCevrimTarihi;
        }

        public ParaVeDovizId(decimal para, int dovizId, DateTime pKurCevrimTarihi)
            : this(para, dovizId)
        {
            this.KurCevrimTarihi = pKurCevrimTarihi;
        }

        public ParaVeDovizId(decimal para, int? dovizId, DateTime pKurCevrimTarihi)
            : this(para, dovizId)
        {
            this.KurCevrimTarihi = pKurCevrimTarihi;
        }

        public ParaVeDovizId(decimal para, int? dovizId, DateTime? pKurCevrimTarihi)
            : this(para, dovizId)
        {
            this.KurCevrimTarihi = pKurCevrimTarihi;
        }

        private int _DovizId;
        private TDI_KOD_DOVIZ_TIP _DovizIdSource;
        private DateTime? _KurCevrimTarihi;
        private decimal _Para;

        public int DovizId
        {
            get { return _DovizId; }
            set { _DovizId = value; }
        }

        public TDI_KOD_DOVIZ_TIP DovizIdSource
        {
            get
            {
                Connection conn = new Connection();
                DBDataContext db = new DBDataContext(CompInfo.CmpNfoList[0].ConStr);
                AvukatProViewDataContext dbV = new AvukatProViewDataContext(CompInfo.CmpNfoList[0].ConStr);
                if (_DovizId == 0)
                    return null;
                if (_DovizIdSource == null)
                    _DovizIdSource = db.TDI_KOD_DOVIZ_TIPs.Where(vii => vii.ID == _DovizId).ToList()[0];
                return _DovizIdSource;
            }
        }

        /// <summary>
        /// Sonradan eklenen bir özelliktir. Topla static fonksiyonunda kullanýlabilmesi
        /// amaçlanmýþtýr.
        /// </summary>
        public DateTime? KurCevrimTarihi
        {
            get { return _KurCevrimTarihi; }
            set { _KurCevrimTarihi = value; }
        }

        public decimal Para
        {
            get { return _Para; }
            set { _Para = value; }
        }

        /// <summary>
        /// Bugünkü kurdan ytl ye çevirilmiþ hali
        /// </summary>
        public decimal YtlHali
        {
            get
            {
                if (_DovizId == 1)
                    return _Para;
                else
                    return DovizHelper.CevirYTL(_Para, _DovizId, DateTime.Today);
            }
        }

        public static void BosOlanAlanlariSil(Dictionary<int, decimal> vl)
        {
            List<int> silinecekler = new List<int>();

            //Boþ alanlarýn tespit edilmesi
            foreach (KeyValuePair<int, decimal> pair in vl)
            {
                if (pair.Value == 0)
                    silinecekler.Add(pair.Key);
            }

            //Tespit edilen boþ alanlarýn silinmesi
            foreach (int i in silinecekler)
            {
                vl.Remove(i);
            }
        }

        public static ParaVeDovizId operator *(ParaVeDovizId p1, int p2)
        {
            return new ParaVeDovizId(p1.Para * p2, p1.DovizId, p1.KurCevrimTarihi);
        }

        public static ParaVeDovizId operator +(ParaVeDovizId p1, ParaVeDovizId p2)
        {
            List<ParaVeDovizId> liste = new List<ParaVeDovizId>();
            liste.Add(p1);
            liste.Add(p2);
            return Topla(liste);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Para, this.DovizIdSource.DOVIZ_KODU);
        }

        public decimal YtlCevir(DateTime dt)
        {
            if (_DovizId == 1)
                return _Para;
            else
                return DovizHelper.CevirYTL(_Para, _DovizId, dt);
        }

        #region Static Elemanlar

        public static ParaVeDovizId Cikart(ParaVeDovizId bundan, ParaVeDovizId bunu)
        {
            if (bundan == null)
            {
                bundan = new ParaVeDovizId(0, 1);
                if (bunu != null)
                    bundan.DovizId = bunu.DovizId;
            }
            if (bunu == null)
            {
                bunu = new ParaVeDovizId(0, 1);
                bunu.DovizId = bundan.DovizId;
            }
            if (bundan.DovizId == bunu.DovizId)
            {
                decimal sonuc = bundan.Para - bunu.Para;

                return new ParaVeDovizId(sonuc, bunu.DovizId);
            }
            else if (bundan.DovizId != bunu.DovizId)
            {
                return new ParaVeDovizId(bundan.YtlHali - bunu.YtlHali, 1);
            }
            return new ParaVeDovizId(0, 1);
        }

        /// <summary>
        /// Verien listedeki paralarý YTL ye çevirerek toplar.
        /// </summary>
        /// <param name="paralar">toplanýcak paralar</param>
        /// <returns></returns>
        public static ParaVeDovizId Topla(List<ParaVeDovizId> paralar, DateTime kurTarihi)
        {
            ParaVeDovizId result = new ParaVeDovizId(0, 1);//0 YTL
            foreach (ParaVeDovizId id in paralar)
            {
                result.Para += id.YtlCevir(kurTarihi);
            }
            return result;
        }

        public static ParaVeDovizId Topla(params ParaVeDovizId[] paralar)
        {
            List<ParaVeDovizId> paraListesi = new List<ParaVeDovizId>();
            paraListesi.AddRange(paralar);
            return Topla(paraListesi);
        }

        /// <summary>
        /// Verien listedeki paralarý farklý tiplerde ise YTL ye çevirerek tek tipte ise aritmetik
        /// toplar.
        /// </summary>
        /// <param name="paralar">toplanýcak paralar</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public static ParaVeDovizId Topla(List<ParaVeDovizId> paralar)
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            AvukatProViewDataContext dbV = new AvukatProViewDataContext(conn.MyConnection);

            ParaVeDovizId result = new ParaVeDovizId(0, 1);//0 YTL
            Dictionary<int, decimal> sonuclar = new Dictionary<int, decimal>();
            List<TDI_KOD_DOVIZ_TIP> paraTipleri = db.TDI_KOD_DOVIZ_TIPs.ToList();

            //foreach (TDI_KOD_DOVIZ_TIP dTip in paraTipleri)
            //{
            //    sonuclar.Add(dTip.ID, 0);
            //}

            foreach (ParaVeDovizId id in paralar)
            {
                if (id != null && id.Para != 0)
                {
                    if (id.DovizId == 0)
                        id.DovizId = 1;

                    if (sonuclar.ContainsKey(id.DovizId))
                        sonuclar[id.DovizId] += id.Para;
                    else
                        sonuclar.Add(id.DovizId, id.Para);
                }
            }
            ParaVeDovizId.BosOlanAlanlariSil(sonuclar);
            if (sonuclar.Count == 1)
            {
                //Connection conn = new Connection();
                //conn.MyConnection = CompInfo.CompInfoListGetir()[0].ConStr;
                //DBDataContext db = new DBDataContext(conn.MyConnection);
                Dictionary<int, decimal>.Enumerator tor = sonuclar.GetEnumerator();
                tor.MoveNext();
                result.DovizId = tor.Current.Key;
                result.Para = tor.Current.Value;
                result._DovizIdSource = db.TDI_KOD_DOVIZ_TIPs.Where(vii => vii.ID == tor.Current.Key).ToList()[0];//.ID, tor.Current.Key);
            }
            else if (sonuclar.Count > 1)
            {
                result.DovizId = 1; //YTL
                foreach (ParaVeDovizId id in paralar)
                {
                    //Bug : Burdaki tarih alanýn kontrolünün yapýlmasý gerekiyor, geçici çözüm yapýldý
                    result.Para += id.YtlCevir(id.KurCevrimTarihi.HasValue ? id.KurCevrimTarihi.Value : DateTime.Today);
                }
            }
            return result;
        }

        #endregion Static Elemanlar
    }
}