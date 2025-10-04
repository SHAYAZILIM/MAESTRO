using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AvukatProLib
{
    public class Kimlik
    {
        private static CompInfo cmpNfo = CompInfo.CmpNfoList[0];

        private static CompInfo _SirketBilgisi = new CompInfo("Default_Test", cmpNfo.ConStr);

        public Kimlik()
        {
        }

        public static List<String> BildirilenHatalar
        {
            get
            {
                return Kimlikci.Kimlik.BildirilenHatalar;
            }
            set
            {
                Kimlikci.Kimlik.BildirilenHatalar = value;
            }
        }

        public static AvukatProLib2.Entities.TDI_BIL_KULLANICI_LISTESI Bilgi
        {
            get
            {
                return Kimlikci.Kimlik.Bilgi;
            }
            set
            {
                if (value != null && !string.IsNullOrEmpty(value.STYLE))
                {
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(value.STYLE);
                }
                Kimlikci.Kimlik.Bilgi = value;
            }
        }

        public static TA_BIL_AKTIF_KULLANICI CurrentAKTIF_KULLANICI
        {
            get
            {
                return Kimlikci.Kimlik.CurrentAKTIF_KULLANICI;
            }
            set
            {
                Kimlikci.Kimlik.CurrentAKTIF_KULLANICI = value;
            }
        }

        /// <summary>
        /// Current cari Id sini verecektir...
        /// </summary>
        public static int CurrentCariId
        {
            get
            {
                return Kimlikci.Kimlik.CurrentCariId;
            }
        }

        public static string CurrentKlasorKodu
        {
            get { return Kimlikci.Kimlik.CurrentKlasorKodu; }
            set { Kimlikci.Kimlik.CurrentKlasorKodu = value; }
        }

        public static string CurrentLanguagePath
        {
            get
            {
                return Kimlikci.Kimlik.CurrentLanguagePath;
            }
            set
            {
                Kimlikci.Kimlik.CurrentLanguagePath = value;
            }
        }

        public static short DefaultKontrolVersiyon
        {
            get { return Kimlikci.Kimlik.DefaultKontrolVersiyon; }
            set { Kimlikci.Kimlik.DefaultKontrolVersiyon = value; }
        }

        public static short DefaultStamp
        {
            get { return Kimlikci.Kimlik.DefaultStamp; }
            set { Kimlikci.Kimlik.DefaultStamp = value; }
        }

        public static string KullaniciAdi
        {
            get
            {
                return Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            }
        }

        public static CompInfo SirketBilgisi
        {
            get
            {
                return Kimlikci.Kimlik.SirketBilgisi;
            }
            set
            {
                Kimlikci.Kimlik.SirketBilgisi = value;
            }
        }

        public static int SubeKodu
        {
            get
            {
                return Kimlikci.Kimlik.Bilgi.KULLANICI_SUBE_ID;
            }
        }

        #region <YY-20090618>

        //DesignMode propertysi eklendi

        /// <summary>
        /// Control üzerindeki DesignMode property si iþe yaramadýðý zamanlar yardýmýnýza yetiþen property.<br/>Bir nevi superman superprop.
        /// </summary>
        public static bool DesignMode
        {
            get
            {
                return !EntityBase.BagliSubeId.HasValue;
            }
        }

        #endregion <YY-20090618>
    }
}