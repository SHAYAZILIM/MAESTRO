using AvukatProLib.AVPLicence;
using AvukatProLib.Extras;
using AvukatProLib.GlobalResource;
using AvukatProLib.Util;
using AvukatProLib.Util.Etiket;
using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.IO;
using System.Runtime.InteropServices; // DllImport
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Principal; // WindowsImpersonationContext
using System.Windows.Forms;
using System.Xml.Serialization;

// PermissionSetAttribute

namespace AvukatProLib
{
    [Serializable]
    public class CompInfo
    {
        public static string SirketNfo = Application.StartupPath + "\\cmpnfo3.gio";

        private int _BaglantiTipi;

        private string _CompanyName;

        private int _ConnectionTip;

        private string _DomainKullaniciAdi;

        private string _HashedLicence;
        private int _KurumsalMod = 0;
        public int KurumsalMod
        {
            get
            {
                return _KurumsalMod;
            }
            set
            {
                _KurumsalMod = value;
            }
        }
        [XmlIgnore]
        private LisansBilgisi _LisansBilgisi;

        private int _OturumAcmaModu;

        public CompInfo()
        {
        }

        public CompInfo(string companyName,
            string conStr)
        {
            _ConStr = conStr;
            _CompanyName = companyName;
            if (_LisansBilgisi == null) _LisansBilgisi = new LisansBilgisi();
            _LisansBilgisi.AdSoyad = companyName;
        }

        public int BaglantiTipi
        {
            get { return _BaglantiTipi; }
            set { _BaglantiTipi = value; }
        }

        public string CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
            }
        }

        public int ConnectionTip
        {
            get { return _ConnectionTip; }
            set { _ConnectionTip = value; }
        }

        public string DomainKullaniciAdi
        {
            get { return _DomainKullaniciAdi; }
            set { _DomainKullaniciAdi = value; }
        }

        public string HashedLicence
        {
            get { return _HashedLicence; }
            set { _HashedLicence = value; }
        }

        [XmlIgnore]
        public LisansBilgisi LisansBilgisi
        {
            get
            {
                return _LisansBilgisi;
            }
            set { _LisansBilgisi = value; }
        }

        public int OturumAcmaModu
        {
            get { return _OturumAcmaModu; }
            set { _OturumAcmaModu = value; }
        }
        private string _PaketAdi = "*";

        public string PaketAdi
        {
            get
            {
                return _PaketAdi;
            }
            set
            {
                _PaketAdi = value;
            }
        }
        private int _TebligatVarsayilanCariId;

        public int TebligatVarsayilanCariId
        {
            get
            {
                return _TebligatVarsayilanCariId;
            }
            set
            {
                _TebligatVarsayilanCariId = value;
            }
        }
        private int _TebligatIsCariId;

        public int TebligatIsCariId
        {
            get
            {
                return _TebligatIsCariId;
            }
            set
            {
                _TebligatIsCariId = value;
            }
        }
        private int _TebligatIsCariId2;

        public int TebligatIsCariId2
        {
            get
            {
                return _TebligatIsCariId2;
            }
            set
            {
                _TebligatIsCariId2 = value;
            }
        }

        #region Guncelleme

        private bool _GuncelProxyKullan;

        private string _GuncelSunucuAdresi;

        private string _GuncelSunucuAdresiHashed;

        public string DownloadsFolder { get; set; }

        public bool GuncelProxyKullan
        {
            get { return _GuncelProxyKullan; }
            set { _GuncelProxyKullan = value; }
        }

        public string GuncelSunucuAdresi
        {
            get { return _GuncelSunucuAdresi; }
            set { _GuncelSunucuAdresi = value; }
        }

        public string GuncelSunucuAdresiHashed
        {
            get { return _GuncelSunucuAdresiHashed; }
            set { _GuncelSunucuAdresiHashed = value; }
        }

        public string LogsFolder { get; set; }

        public DateTime TimeSchedule { get; set; }

        public string UpdaterBackupFolder { get; set; }

        #endregion Guncelleme

        #region Uygulama

        private bool _UProxyKullan;

        private string _UygulamaSunucuAdresi;

        private string _UygulamaSunucuAdresiHashed;

        public bool UProxyKullan
        {
            get { return _UProxyKullan; }
            set { _UProxyKullan = value; }
        }

        public string UygulamaSunucuAdresi
        {
            get { return _UygulamaSunucuAdresi; }
            set { _UygulamaSunucuAdresi = value; }
        }

        public string UygulamaSunucuAdresiHashed
        {
            get { return _UygulamaSunucuAdresiHashed; }
            set { _UygulamaSunucuAdresiHashed = value; }
        }

        public int UygulamaTipi { set; get; }

        #endregion Uygulama

        #region VeriTabaný

        private int _BaglantiZamanAsimi;
        private string _DomainAdi;
        private string _HAVeriTabani;
        private string _HAVeriTabaniHashed;
        private int _KomutZamanAsimi;
        private string _MKVeriTabani;
        private string _MKVeriTabaniHashed;
        private string _SaKullaniciSfr;
        private string _SaKullaniciSfrHashed;
        private string _VeriTabaniKullaniciHashed;
        private string _VeriTabaniKullaniciSfr;
        private string _VeriTabaniKullaniciSfrHashed;
        private string _VeriTabaniKullanicisi;

        private string _VeriTabaniSunucu;

        private string _VeriTabaniSunucuHashed;

        public int BaglantiZamanAsimi
        {
            get { return _BaglantiZamanAsimi; }
            set { _BaglantiZamanAsimi = value; }
        }

        public string DomainAdi
        {
            get { return _DomainAdi; }
            set { _DomainAdi = value; }
        }

        public string HAVeriTabani
        {
            get { return _HAVeriTabani; }
            set { _HAVeriTabani = value; }
        }

        public string HAVeriTabaniHashed
        {
            get { return _HAVeriTabaniHashed; }
            set { _HAVeriTabaniHashed = value; }
        }

        public int KomutZamanAsimi
        {
            get { return _KomutZamanAsimi; }
            set { _KomutZamanAsimi = value; }
        }

        public string MKVeriTabani
        {
            get { return _MKVeriTabani; }
            set { _MKVeriTabani = value; }
        }

        public string MKVeriTabaniHashed
        {
            get { return _MKVeriTabaniHashed; }
            set { _MKVeriTabaniHashed = value; }
        }

        public string SaKullaniciSfr
        {
            get { return _SaKullaniciSfr; }
            set { _SaKullaniciSfr = value; }
        }

        public string SaKullaniciSfrHashed
        {
            get { return _SaKullaniciSfrHashed; }
            set { _SaKullaniciSfrHashed = value; }
        }

        public string VeriTabanýKullanicisi
        {
            get
            {
                return _VeriTabaniKullanicisi;
            }
            set
            {
                _VeriTabaniKullanicisi = value;
            }
        }

        public string VeriTabaniKullanciSfrHashed
        {
            get { return _VeriTabaniKullaniciSfrHashed; }
            set { _VeriTabaniKullaniciSfrHashed = value; }
        }

        public string VeriTabaniKullaniciHashed
        {
            get { return _VeriTabaniKullaniciHashed; }
            set { _VeriTabaniKullaniciHashed = value; }
        }

        public string VeriTabaniKullaniciSfr
        {
            get { return _VeriTabaniKullaniciSfr; }
            set { _VeriTabaniKullaniciSfr = value; }
        }

        public string VeriTabaniSunucu
        {
            get { return _VeriTabaniSunucu; }
            set { _VeriTabaniSunucu = value; }
        }

        public string VeriTabaniSunucuHashed
        {
            get { return _VeriTabaniSunucuHashed; }
            set { _VeriTabaniSunucuHashed = value; }
        }

        #endregion VeriTabaný

        #region Proxy

        private string _ProxyKullaniciAdi;
        private string _ProxyKullaniciAdiHashed;
        private string _ProxyParola;
        private string _ProxyParolaHashed;
        private string _ProxySunucuAdresi;

        private string _ProxySunucuAdresiHashed;

        private string _ProxySunucuPortu;

        private string _ProxySunucuPortuHashed;

        public string ProxyKullaniciAdi
        {
            get { return _ProxyKullaniciAdi; }
            set { _ProxyKullaniciAdi = value; }
        }

        public string ProxyKullaniciAdiHashed
        {
            get { return _ProxyKullaniciAdiHashed; }
            set { _ProxyKullaniciAdiHashed = value; }
        }

        public string ProxyParola
        {
            get { return _ProxyParola; }
            set { _ProxyParola = value; }
        }

        public string ProxyParolaHashed
        {
            get { return _ProxyParolaHashed; }
            set { _ProxyParolaHashed = value; }
        }

        public string ProxySunucuAdresi
        {
            get { return _ProxySunucuAdresi; }
            set { _ProxySunucuAdresi = value; }
        }

        public string ProxySunucuAdresiHashed
        {
            get { return _ProxySunucuAdresiHashed; }
            set { _ProxySunucuAdresiHashed = value; }
        }

        public string ProxySunucuPortu
        {
            get { return _ProxySunucuPortu; }
            set { _ProxySunucuPortu = value; }
        }

        public string ProxySunucuPortuHashed
        {
            get { return _ProxySunucuPortuHashed; }
            set { _ProxySunucuPortuHashed = value; }
        }

        #endregion Proxy

        #region Baglantý

        private string _ConStr;

        private string _ConStrHashed;

        private string _ConStrMK;

        private string _ConStrMKHashed;

        public string ConStr
        {
            get
            {
                return _ConStr;
            }
            set
            {
                _ConStr = value;
            }
        }

        public string ConStrHashed
        {
            get { return _ConStrHashed; }
            set { _ConStrHashed = value; }
        }

        public string ConStrMK
        {
            get { return _ConStrMK; }
            set { _ConStrMK = value; }
        }

        public string ConStrMKHashed
        {
            get { return _ConStrMKHashed; }
            set { _ConStrMKHashed = value; }
        }

        #endregion Baglantý

        #region SMTP

        private bool _SMTPSSL;

        public string SMTPKullaniciAdi { set; get; }

        public string SMTPPort { set; get; }

        public string SMTPSifre { set; get; }

        public bool SMTPSSL
        {
            get { return _SMTPSSL; }
            set { _SMTPSSL = value; }
        }

        public string SMTPSunucuAdresi { set; get; }

        #endregion SMTP

        #region SMS

        public string SMSApiKey { set; get; }

        public string SMSBayiKodu { set; get; }

        public string SMSExtra1 { set; get; }

        public string SMSExtra2 { set; get; }

        public string SMSExtra3 { set; get; }

        public string SMSGonderen { set; get; }

        public string SMSIletisimTel { set; get; }

        public string SMSKullaniciAdi { set; get; }

        public string SMSMaxGonderimSuresi { set; get; }

        public string SMSMusteriKodu { set; get; }

        public string SMSServisSaglayici { set; get; }

        public string SMSServisSaglayiciID { set; get; }

        public string SMSSifre { set; get; }

        #endregion SMS

        #region YeniNesilLisans

        public string LisansNo { set; get; }

        public string BilgisayarID { set; get; }

        public string ModulNo { set; get; }

        public string UrunAdi { set; get; }

        public DateTime BaslangicTarihi { set; get; }

        public DateTime BitisTarihi { set; get; }

        public string Versiyon { set; get; }

        public string Surum { set; get; }

        public string YedekServisiDosyaYolu { set; get; }

        //public bool OtoMasrafUretilmesin { set { _OtoMasrafUretilmesin = value; } get { return _OtoMasrafUretilmesin; } }

        //public bool OtoKasaHareketiUretilmesin { set { _OtoKasaHareketiUretilmesin = value; } get { return _OtoKasaHareketiUretilmesin; } }

        //public string OnaySifresi1 { set { _OnaySifresi1 = value; } get { return _OnaySifresi1; } }

        //public string OnaySifresi2 { set { _OnaySifresi2 = value; } get { return _OnaySifresi2; } }

        //public string OnaySifresi3 { set { _OnaySifresi3 = value; } get { return _OnaySifresi3; } }

        //public string DegistirmeSilmeSifresi { set { _DegistirmeSilmeSifresi = value; } get { return _DegistirmeSilmeSifresi; } }

        public bool OtoMasrafUretilmesin { set; get; }

        public bool OtoKasaHareketiUretilmesin { set; get; }

        public string OnaySifresi1 { set; get; }

        public string OnaySifresi2 { set; get; }

        public string OnaySifresi3 { set; get; }

        public string DegistirmeSilmeSifresi { set; get; }

        public bool DegistirmeSilmeSifresiAktif { set; get; }

        public bool OnaylamaSifresiAktif { set; get; }

        public string OnayKullanicisi1 { set; get; }

        public string OnayKullanicisi2 { set; get; }

        public string OnayKullanicisi3 { set; get; }

        public string DegSilmeKullanicisi { set; get; }

        public string YeniEski { set; get; }

        public string OtomatikIsUretme { set; get; }

        #endregion YeniNesilLisans

        #region Hatirlatma Bilgileri

        public int HatirlatmaAcil { set; get; }

        public int HatirlatmaBekleyebilir { set; get; }

        public int HatirlatmaCokAcil { set; get; }

        #endregion Hatirlatma Bilgileri


        // closes open handes returned by LogonUser
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        // creates duplicate token handle
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static bool DuplicateToken(IntPtr ExistingTokenHandle,
            int SECURITY_IMPERSONATION_LEVEL, ref IntPtr DuplicateTokenHandle);

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(string pszUsername, string pszDomain, string pszPassword,
            int dwLogonType, int dwLogonProvider, ref IntPtr phToken);


        public enum SECURITY_IMPERSONATION_LEVEL : int
        {
            SecurityAnonymous = 0,
            SecurityIdentification = 1,
            SecurityImpersonation = 2,
            SecurityDelegation = 3
        }

        public static List<CompInfo> CompInfoListGetir()
        {
            string path = Application.StartupPath;
            string _sirketNfo = path + @"\cmpnfo3.gio";
            List<CompInfo> sList = new List<CompInfo>();
            FileStream fss = null;
            try
            {
                //bool nedondu = RarHelper.DosyayiAc(path+"\\cmpnfo3.giobca",path,"1q2w3e4r");

                #region

                //DateTime time = prc.ExitTime;
                //if (!File.Exists(_sirketNfo))
                //{
                //    CompInfo ci = new CompInfo("AvukatPro Server", "server=192.9.0.199;database=AVP_NHA_NG;uid=yilmaz;pwd=123");
                //    CompInfo ci2 = new CompInfo("AvukatPro Boþ VT", "server=192.9.0.199;database=AVP_NHA_BOS;uid=yilmaz;pwd=123");

                //    sList.Add(ci);

                //    FileStream fs = new FileStream(_sirketNfo, FileMode.CreateNew);
                //    BinaryFormatter bf = new BinaryFormatter();

                //    bf.Serialize(fs, sList);
                //    fs.Close();
                //}
                //prc.OnExited();

                #endregion Static Elemanlar

                if (File.Exists(_sirketNfo))
                {
                    fss = File.OpenRead(_sirketNfo);

                    BinaryFormatter bff = new BinaryFormatter();

                    List<CompInfo> cinf = (List<CompInfo>)bff.Deserialize(fss);
                    fss.Close();
                    foreach (CompInfo cmpinf in cinf)
                    {
                        cmpinf.DecodeData();
                        try
                        {
                            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                            XmlSerializer xs = new XmlSerializer(typeof(LisansBilgisi));

                            if (!string.IsNullOrEmpty(cmpinf.HashedLicence))
                            {
                                string lisans = Lisans.LicenseHelper.DecryptLicence(cmpinf.HashedLicence);
                                cmpinf.LisansBilgisi = (LisansBilgisi)xs.Deserialize(new StringReader(lisans));
                            }
                        }
                        catch { }
                        sList.Add(cmpinf);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //finally
            //{
            //    File.Delete(_sirketNfo);
            //}
            return sList;
        }

        private static List<CompInfo> _cmpNfoList;

        public static List<CompInfo> CmpNfoList
        {
            get
            {
                if (CompInfo._cmpNfoList == null)
                    CompInfo._cmpNfoList = CompInfo.CompInfoListGetir(Application.StartupPath);

                return CompInfo._cmpNfoList;
            }            
        }

        private static List<CompInfo> CompInfoListGetir(string StartupPath)
        {
            string path = StartupPath;

            string _sirketNfo = path + @"\cmpnfo3.gio";
            List<CompInfo> sList = new List<CompInfo>();
            FileStream fss = null;
            try
            {
                //bool nedondu = RarHelper.DosyayiAc(path+"\\cmpnfo3.giobca",path,"1q2w3e4r");

                #region

                //DateTime time = prc.ExitTime;
                //if (!File.Exists(_sirketNfo))
                //{
                //    CompInfo ci = new CompInfo("AvukatPro Server", "server=192.9.0.199;database=AVP_NHA_NG;uid=yilmaz;pwd=123");
                //    CompInfo ci2 = new CompInfo("AvukatPro Boþ VT", "server=192.9.0.199;database=AVP_NHA_BOS;uid=yilmaz;pwd=123");

                //    sList.Add(ci);

                //    FileStream fs = new FileStream(_sirketNfo, FileMode.CreateNew);
                //    BinaryFormatter bf = new BinaryFormatter();

                //    bf.Serialize(fs, sList);
                //    fs.Close();
                //}
                //prc.OnExited();

                #endregion

                if (File.Exists(_sirketNfo))
                {
                    fss = File.OpenRead(_sirketNfo);
                    BinaryFormatter bff = new BinaryFormatter();

                    List<CompInfo> cinf = (List<CompInfo>)bff.Deserialize(fss);
                    fss.Close();
                    foreach (CompInfo cmpinf in cinf)
                    {
                        cmpinf.DecodeData();
                        try
                        {
                            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                            XmlSerializer xs = new XmlSerializer(typeof(LisansBilgisi));

                            if (!string.IsNullOrEmpty(cmpinf.HashedLicence))
                            {
                                string lisans = Lisans.LicenseHelper.DecryptLicence(cmpinf.HashedLicence);
                                cmpinf.LisansBilgisi = (LisansBilgisi)xs.Deserialize(new StringReader(lisans));
                            }
                        }
                        catch { }
                        sList.Add(cmpinf);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InstallException(ex.ToString());
            }

            //finally
            //{
            //    File.Delete(_sirketNfo);
            //}
            return sList;
        }

        public static bool Kaydet(List<CompInfo> cmpList)
        {
            foreach (CompInfo ci in cmpList)
            {
                ci.EncodeData();
            }
            bool b = false;
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");

                //if (File.Exists(Application.StartupPath + "\\cmpnfo3.giobca"))
                //    File.Delete(Application.StartupPath + "\\cmpnfo3.giobca");
                if (File.Exists(Application.StartupPath + "\\cmpnfo3.gio"))
                    File.Delete(Application.StartupPath + "\\cmpnfo3.gio");
                if (!File.Exists(SirketNfo))//Dosya yoksa
                {
                    FileStream fs = new FileStream(SirketNfo, FileMode.CreateNew);
                    BinaryFormatter bf = new BinaryFormatter();

                    bf.Serialize(fs, cmpList);
                    fs.Close();

                    //RarHelper.DosyayiRarla(Application.StartupPath + @"\cmpnfo3.gio", Application.StartupPath + @"\cmpnfo3.giobca", "1q2w3e4r");
                    //File.Delete(SirketNfo);
                    b = true;
                    foreach (CompInfo ci in cmpList)
                    {
                        ci.DecodeData();
                        try
                        {
                            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                            XmlSerializer xs = new XmlSerializer(typeof(LisansBilgisi));
                            string lisans = Lisans.LicenseHelper.DecryptLicence(ci.HashedLicence);

                            ci.LisansBilgisi = (LisansBilgisi)xs.Deserialize(new StringReader(lisans));
                        }
                        catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                b = false;
            }
            return b;
        }

        public static bool Kaydet(List<CompInfo> cmpList, string StartupPath)
        {
            string SirketNfo__ = StartupPath + "\\cmpnfo3.gio";
            foreach (CompInfo ci in cmpList)
            {
                ci.EncodeData();
            }
            bool b = false;
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");

                //if (File.Exists(Application.StartupPath + "\\cmpnfo3.giobca"))
                //    File.Delete(Application.StartupPath + "\\cmpnfo3.giobca");
                if (File.Exists(StartupPath + "\\cmpnfo3.gio"))
                    File.Delete(StartupPath + "\\cmpnfo3.gio");
                if (!File.Exists(SirketNfo__))//Dosya yoksa
                {
                    FileStream fs = new FileStream(SirketNfo__, FileMode.CreateNew);
                    BinaryFormatter bf = new BinaryFormatter();

                    bf.Serialize(fs, cmpList);
                    fs.Close();

                    //RarHelper.DosyayiRarla(Application.StartupPath + @"\cmpnfo3.gio", Application.StartupPath + @"\cmpnfo3.giobca", "1q2w3e4r");
                    //File.Delete(SirketNfo);
                    b = true;
                    foreach (CompInfo ci in cmpList)
                    {
                        ci.DecodeData();
                        try
                        {
                            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                            XmlSerializer xs = new XmlSerializer(typeof(LisansBilgisi));
                            string lisans = Lisans.LicenseHelper.DecryptLicence(ci.HashedLicence);

                            ci.LisansBilgisi = (LisansBilgisi)xs.Deserialize(new StringReader(lisans));
                        }
                        catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                b = false;
            }
            return b;
        }

        /// <summary>
        /// Verilen degerlere göre bir constr oluþturan metot
        /// </summary>
        /// <param name="veritabaniAdi"> Kullanýcýnýn Girdiði VeriTabaný(database) adý</param>
        /// <param name="veritabaniKullaniciAdi">Kullanýcýnýn Girdiði VeriTabanýKullanýcýsi Adi</param>
        /// <param name="veritabanikullaniciSfr">Kullanýcýnýn Girdiði VeriTabanýKulanýcý Þifresi </param>
        /// <param name="sunucuAdresi">Kullanýcýnýn Girdiði VeriTabanýnýn bulunduðu sunucu adresi</param>
        /// <returns>
        /// Geriye Bir connection String Oluþtururak dönmesi saðlanýyor..
        /// </returns>
        public string ConstrOlustur(string veritabaniAdi, string veritabaniKullaniciAdi, string veritabanikullaniciSfr, string sunucuAdresi, AvukatProLib.Extras.ConnectionTip ConnTip, string domainAdi, int baglantizmn)
        {
            switch (ConnTip)
            {
                case AvukatProLib.Extras.ConnectionTip.Application_Server:
                    return Stringler.server + sunucuAdresi + ";" + Stringler.database + veritabaniAdi + ";" + Stringler.uid + veritabaniKullaniciAdi + ";" + Stringler.pwd + VeriTabaniKullaniciSfr + ";Connection Timeout =" + baglantizmn.ToString() + ";";
                case AvukatProLib.Extras.ConnectionTip.Domain_Server:
                    if (!string.IsNullOrEmpty(veritabaniKullaniciAdi))
                    {
                        return Stringler.server + sunucuAdresi + ";" + Stringler.database + veritabaniAdi + ";" + "Integrated Security=SSPI;" + "Connection Timeout =" + baglantizmn.ToString() + ";";
                    }
                    else
                    {
                        return Stringler.server + sunucuAdresi + ";" + Stringler.database + veritabaniAdi + ";" + "Integrated Security=SSPI;" + "Connection Timeout =" + baglantizmn.ToString() + ";";
                    }
                default:
                    return "";
            }
        }

        /// <summary>
        /// Hashli tutulan veriyi normal cleartext veriye çevirir
        /// </summary>
        /// <remarks>
        /// Þifreleri ve güvenli tutulmasý gereken verileri:
        /// ConStr
        /// ConStrMK
        /// UygulamaSunucuAdresi
        /// vb.
        /// </remarks>
        public void DecodeData()
        {
            if (!String.IsNullOrEmpty(_ConStrHashed))
                _ConStr = YazmaOkuma.Okuma(_ConStrHashed);

            if (!String.IsNullOrEmpty(_ConStrMKHashed))
                _ConStrMK = YazmaOkuma.Okuma(_ConStrMKHashed);

            if (!String.IsNullOrEmpty(_UygulamaSunucuAdresiHashed))
                _UygulamaSunucuAdresi = YazmaOkuma.Okuma(_UygulamaSunucuAdresiHashed);

            if (!String.IsNullOrEmpty(_DomainAdiHashed))
                _DomainAdi = YazmaOkuma.Okuma(_DomainAdiHashed);

            if (!String.IsNullOrEmpty(_GuncelSunucuAdresiHashed))
                _GuncelSunucuAdresi = YazmaOkuma.Okuma(_GuncelSunucuAdresiHashed);

            if (!String.IsNullOrEmpty(_VeriTabaniSunucuHashed))
                _VeriTabaniSunucu = YazmaOkuma.Okuma(_VeriTabaniSunucuHashed);

            if (!String.IsNullOrEmpty(_HAVeriTabaniHashed))
                _HAVeriTabani = YazmaOkuma.Okuma(_HAVeriTabaniHashed);

            if (!String.IsNullOrEmpty(_SaKullaniciSfrHashed))
                _SaKullaniciSfr = YazmaOkuma.Okuma(_SaKullaniciSfrHashed);

            if (!String.IsNullOrEmpty(_MKVeriTabaniHashed))
                _MKVeriTabani = YazmaOkuma.Okuma(_MKVeriTabaniHashed);

            if (!String.IsNullOrEmpty(_VeriTabaniKullaniciSfrHashed))
                _VeriTabaniKullaniciSfr = YazmaOkuma.Okuma(_VeriTabaniKullaniciSfrHashed);

            if (!String.IsNullOrEmpty(_VeriTabaniKullaniciHashed))
                _VeriTabaniKullanicisi = YazmaOkuma.Okuma(_VeriTabaniKullaniciHashed);

            if (!String.IsNullOrEmpty(_ProxySunucuAdresiHashed))
                _ProxySunucuAdresi = YazmaOkuma.Okuma(_ProxySunucuAdresiHashed);

            if (!String.IsNullOrEmpty(_ProxyParolaHashed))
                _ProxyParola = YazmaOkuma.Okuma(_ProxyParolaHashed);

            if (!String.IsNullOrEmpty(_ProxyKullaniciAdiHashed))
                _ProxyKullaniciAdi = YazmaOkuma.Okuma(_ProxyKullaniciAdiHashed);

            if (!String.IsNullOrEmpty(_ProxySunucuPortuHashed))
                _ProxySunucuPortu = YazmaOkuma.Okuma(_ProxySunucuPortuHashed);

            if (!String.IsNullOrEmpty(_MachineCodeHashed))
                _MachineCode = YazmaOkuma.Okuma(_MachineCodeHashed);

            if (this.ConnectionTip == (int)AvukatProLib.Extras.ConnectionTip.Domain_Server)
                ImpersonateUser(_VeriTabaniKullanicisi, _DomainKullaniciAdi, _VeriTabaniKullaniciSfr);
        }

        public void EncodeData()
        {
            #region BaðlantýHashed

            if (!String.IsNullOrEmpty(_UygulamaSunucuAdresi) && _UygulamaSunucuAdresi.Length > 10)
                _UygulamaSunucuAdresiHashed = YazmaOkuma.Yazma(_UygulamaSunucuAdresi);
            _UygulamaSunucuAdresi = string.Empty;

            _ConStr = ConstrOlustur(_HAVeriTabani, _VeriTabaniKullanicisi, _VeriTabaniKullaniciSfr, _VeriTabaniSunucu, (ConnectionTip)_ConnectionTip, _DomainAdi, _BaglantiZamanAsimi);
            _ConStrMK = ConstrOlustur(_MKVeriTabani, _VeriTabaniKullanicisi, _VeriTabaniKullaniciSfr, _VeriTabaniSunucu, (ConnectionTip)_ConnectionTip, _DomainAdi, _BaglantiZamanAsimi);
            if (_ConStr != null)
                _ConStrHashed = YazmaOkuma.Yazma(_ConStr);
            if (_ConStrMK != null)
                _ConStrMKHashed = YazmaOkuma.Yazma(_ConStrMK);

            _ConStr = string.Empty;
            _ConStrMK = string.Empty;

            #endregion BaðlantýHashed

            if (!String.IsNullOrEmpty(_GuncelSunucuAdresi) && _GuncelSunucuAdresi.Length > 10)
                _GuncelSunucuAdresiHashed = YazmaOkuma.Yazma(_GuncelSunucuAdresi);
            if (_VeriTabaniSunucu != null)
                _VeriTabaniSunucuHashed = YazmaOkuma.Yazma(_VeriTabaniSunucu);
            if (_HAVeriTabani != null)
                _HAVeriTabaniHashed = YazmaOkuma.Yazma(_HAVeriTabani);
            if (_SaKullaniciSfr != null)
            {
                _SaKullaniciSfrHashed = YazmaOkuma.Yazma(_SaKullaniciSfr);
                _SaKullaniciSfr = string.Empty;
            }
            if (_MKVeriTabani != null)
                _MKVeriTabaniHashed = YazmaOkuma.Yazma(_MKVeriTabani);

            if (_VeriTabaniSunucu != null)
                _VeriTabaniSunucuHashed = YazmaOkuma.Yazma(_VeriTabaniSunucu);

            if (_VeriTabaniKullaniciSfr != null)
            {
                _VeriTabaniKullaniciSfrHashed = YazmaOkuma.Yazma(_VeriTabaniKullaniciSfr);
                _VeriTabaniKullaniciSfr = string.Empty;
            }
            if (_VeriTabaniKullanicisi != null)
            {
                _VeriTabaniKullaniciHashed = YazmaOkuma.Yazma(_VeriTabaniKullanicisi);
                _VeriTabaniKullanicisi = string.Empty;
            }
            if (_ProxySunucuAdresi != null)
                _ProxySunucuAdresiHashed = YazmaOkuma.Yazma(_ProxySunucuAdresi);
            if (_ProxyParola != null)
            {
                _ProxyParolaHashed = YazmaOkuma.Yazma(_ProxyParola);
                _ProxyParola = string.Empty;
            }
            if (_ProxyKullaniciAdi != null)
            {
                _ProxyKullaniciAdiHashed = YazmaOkuma.Yazma(_ProxyKullaniciAdi);
                _ProxyKullaniciAdi = string.Empty;
            }
            if (_ProxySunucuPortu != null)
                _ProxySunucuPortuHashed = YazmaOkuma.Yazma(_ProxySunucuPortu);

            if (!String.IsNullOrEmpty(_MachineCode))
                _MachineCodeHashed = YazmaOkuma.Yazma(_MachineCode);

            if (_DomainAdi != null)
                _DomainAdiHashed = YazmaOkuma.Yazma(_DomainAdi);
        }

        /// <summary>
        /// Normal veriyi Hashli veriye Çevirir
        /// </summary>
        /// <remarks>
        /// Þifreleri ve güvenli tutulmasý gereken verileri:
        /// ConStr
        /// ConStrMK
        /// UygulamaSunucuAdresi
        /// vb.
        /// </remarks>
        ///
        public WindowsImpersonationContext ImpersonateUser(string sUsername, string sDomain, string sPassword)
        {
            // initialize tokens
            IntPtr pExistingTokenHandle = new IntPtr(0);
            IntPtr pDuplicateTokenHandle = new IntPtr(0);
            pExistingTokenHandle = IntPtr.Zero;
            pDuplicateTokenHandle = IntPtr.Zero;

            // if domain name was blank, assume local machine
            if (sDomain == "")
                sDomain = System.Environment.MachineName;

            try
            {
                string sResult = null;

                const int LOGON32_PROVIDER_DEFAULT = 0;

                // create token
                const int LOGON32_LOGON_INTERACTIVE = 9;

                //const int SecurityImpersonation = 2;

                // get handle to token
                bool bImpersonated = LogonUser(sUsername, sDomain, sPassword,
                    LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref pExistingTokenHandle);

                // did impersonation fail?
                if (false == bImpersonated)
                {
                    int nErrorCode = Marshal.GetLastWin32Error();
                    sResult = "LogonUser() failed with error code: " + nErrorCode + "\r\n";

                    // show the reason why LogonUser failed
                    //MessageBox.Show(this, sResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Get identity before impersonation
                sResult += "Before impersonation: " + WindowsIdentity.GetCurrent().Name + "\r\n";

                bool bRetVal = DuplicateToken(pExistingTokenHandle, (int)SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, ref pDuplicateTokenHandle);

                // did DuplicateToken fail?
                if (false == bRetVal)
                {
                    int nErrorCode = Marshal.GetLastWin32Error();
                    CloseHandle(pExistingTokenHandle); // close existing handle
                    sResult += "DuplicateToken() failed with error code: " + nErrorCode + "\r\n";

                    // show the reason why DuplicateToken failed
                    // MessageBox.Show(this, sResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                else
                {
                    // create new identity using new primary token
                    WindowsIdentity newId = new WindowsIdentity(pDuplicateTokenHandle);
                    WindowsImpersonationContext impersonatedUser = newId.Impersonate();

                    // check the identity after impersonation
                    sResult += "After impersonation: " + WindowsIdentity.GetCurrent().Name + "\r\n";

                    // MessageBox.Show(this, sResult, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return impersonatedUser;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // close handle(s)
                if (pExistingTokenHandle != IntPtr.Zero)
                    CloseHandle(pExistingTokenHandle);
                if (pDuplicateTokenHandle != IntPtr.Zero)
                    CloseHandle(pDuplicateTokenHandle);
            }
        }

        #region Lisans Bilgileri

        private string _DomainAdiHashed;
        private string _MachineCode;
        private string _MachineCodeHashed;

        public string DomainAdiHashed
        {
            get { return _DomainAdiHashed; }
            set { _DomainAdiHashed = value; }
        }

        public string MachineCode
        {
            get { return _MachineCode; }
            set { _MachineCode = value; }
        }

        public string MachineCodeHashed
        {
            get { return _MachineCodeHashed; }
            set { _MachineCodeHashed = value; }
        }

        #endregion Lisans Bilgileri

        #region Static Elemanlar

        #endregion
    }
}