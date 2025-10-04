using AvukatProLib.Util.Etiket;
using AvukatProLib2.Entities;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AvukatProLib
{
    /// <summary>
    /// Yeni Kimlik Class'ý dinamiktir ancak kendi içinde Kimlik adýnda bir static deðiþken taþýr.
    /// </summary>
    public class Kimlikci
    {
        public Kimlikci()
        {
        }

        public static string GetDBConnString()
        {
            try
            {
                XDocument xDoc = XDocument.Load(HttpContext.Current.Server.MapPath("/Config.xml"));
                return string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                    xDoc.Root.Element("DBConnection").Element("Server").Value,
                    xDoc.Root.Element("DBConnection").Element("Database").Value,
                    xDoc.Root.Element("DBConnection").Element("UserName").Value,
                    xDoc.Root.Element("DBConnection").Element("Password").Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Kimlikci Kimlik = new Kimlikci();

        private static TA_BIL_AKTIF_KULLANICI _CurrentAKTIF_KULLANICI;

        private static string _CurrentKlasorKodu = "GENEL";

        private static short _DefaultKontrolVersiyon = 0;

        private static short _DefaultStamp = 1;

        private List<string> _BildirilenHatalar = new List<string>();

        private AvukatProLib2.Entities.TDI_BIL_KULLANICI_LISTESI _Bilgi;

        private string _CurrentLanguage = Application.StartupPath + "\\Localization\\Turkish";

        private ReferansAlanlari _DavaDnReferans = new ReferansAlanlari();

        private OzelKodAlanlari _DavaOzelKod = new OzelKodAlanlari();

        private ReferansAlanlari _DavaReferans = new ReferansAlanlari();

        private ReferansAlanlari _IcraAnReferans = new ReferansAlanlari();

        private OzelDurumlar _IcraOzelDurum = new OzelDurumlar();

        private OzelKodAlanlari _IcraOzelKod = new OzelKodAlanlari();

        private ReferansAlanlari _IcraReferans = new ReferansAlanlari();

        private int _ModulNumarasi;

        private OzelDurumlar _OrtakOzelDurum = new OzelDurumlar();

        private CompInfo _SirketBilgisi = new CompInfo("Default_Test", GetDBConnString()); //eski db bilgileri

        private OzelKodAlanlari _SorusturmaOzelKod = new OzelKodAlanlari();

        private ReferansAlanlari _SorusturmaReferans = new ReferansAlanlari();

        private OzelKodAlanlari _SozlesmeOzelKod = new OzelKodAlanlari();

        private ReferansAlanlari _SozlesmeReferans = new ReferansAlanlari();

        public List<string> BildirilenHatalar
        {
            get { return _BildirilenHatalar; }
            set { _BildirilenHatalar = value; }
        }

        public AvukatProLib2.Entities.TDI_BIL_KULLANICI_LISTESI Bilgi
        {
            get
            {
                return _Bilgi;
            }
            set
            {
                //if (value != null && !string.IsNullOrEmpty(value.STYLE))
                //{
                //    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(value.STYLE);
                //}
                _Bilgi = value;
            }
        }

        public int Cari_ID
        {
            get
            {
                return Bilgi.CARI_ID.Value;
            }
        }

        public TA_BIL_AKTIF_KULLANICI CurrentAKTIF_KULLANICI
        {
            get { return _CurrentAKTIF_KULLANICI; }
            set { _CurrentAKTIF_KULLANICI = value; }
        }

        /// <summary>
        /// Current cari Id sini verecektir...
        /// </summary>
        public int CurrentCariId
        {
            get
            {
                return 1;

                if (Bilgi != null && Bilgi.CARI_ID != null)
                {
                    return Bilgi.CARI_ID.Value;
                }
                else
                {
                    var ss = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetAll();
                    return AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetAll()[0].ID;
                }
            }
        }

        public string CurrentKlasorKodu
        {
            get { return _CurrentKlasorKodu; }
            set { _CurrentKlasorKodu = value; }
        }

        public string CurrentLanguagePath
        {
            get { return _CurrentLanguage; }
            set { _CurrentLanguage = value; }
        }

        public ReferansAlanlari DavaDnReferans
        {
            get { return _DavaDnReferans; }
            set { _DavaDnReferans = value; }
        }

        public OzelKodAlanlari DavaOzelKod
        {
            get { return _DavaOzelKod; }
            set { _DavaOzelKod = value; }
        }

        public ReferansAlanlari DavaReferans
        {
            get { return _DavaReferans; }
            set { _DavaReferans = value; }
        }

        public short DefaultKontrolVersiyon
        {
            get { return _DefaultKontrolVersiyon; }
            set { _DefaultKontrolVersiyon = value; }
        }

        public short DefaultStamp
        {
            get { return _DefaultStamp; }
            set { _DefaultStamp = value; }
        }

        public ReferansAlanlari IcraAnReferans
        {
            get { return _IcraAnReferans; }
            set { _IcraAnReferans = value; }
        }

        public OzelDurumlar IcraOzelDurum
        {
            get { return _IcraOzelDurum; }
            set { _IcraOzelDurum = value; }
        }

        public OzelKodAlanlari IcraOzelKod
        {
            get { return _IcraOzelKod; }
            set { _IcraOzelKod = value; }
        }

        public ReferansAlanlari IcraReferans
        {
            get { return _IcraReferans; }
            set { _IcraReferans = value; }
        }

        public string KullaniciAdi
        {
            get
            {
                return Bilgi.KULLANICI_ADI;
            }
        }

        public int ModulNumarasi
        {
            get { return _ModulNumarasi; }
            set { _ModulNumarasi = value; }
        }

        public OzelDurumlar OrtakOzelDurum
        {
            get { return _OrtakOzelDurum; }
            set { _OrtakOzelDurum = value; }
        }

        public CompInfo SirketBilgisi
        {
            get
            {
                return _SirketBilgisi;
            }
            set
            {
                _SirketBilgisi = value;
            }
        }

        public OzelKodAlanlari SorusturmaOzelKod
        {
            get { return _SorusturmaOzelKod; }
            set { _SorusturmaOzelKod = value; }
        }

        public ReferansAlanlari SorusturmaReferans
        {
            get { return _SorusturmaReferans; }
            set { _SorusturmaReferans = value; }
        }

        public OzelKodAlanlari SozlesmeOzelKod
        {
            get { return _SozlesmeOzelKod; }
            set { _SozlesmeOzelKod = value; }
        }

        public ReferansAlanlari SozlesmeReferans
        {
            get { return _SozlesmeReferans; }
            set { _SozlesmeReferans = value; }
        }

        public int SubeKodu
        {
            get
            {
                return Bilgi.KULLANICI_SUBE_ID;
            }
        }
    }
}