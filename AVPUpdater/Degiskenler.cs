using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AVPUpdater
{
    public class Degiskenler
    {
        public string cnStringYerel;

        public string GuncelSurum;

        public string GuncelVersiyon;

        public string LisansNo;

        public string ModulNo;

        public string PaketAdi;

        public UygulamaTipi uygulamaTipi;

        public string Veritabani;

        public int YeniVersiyonID;

        private string _cnString = "data source=94.138.206.50\\SQLEXPRESS;database=AVPYONETIM;uid=avp;pwd=PASSWRD1;";

        private bool _DosyaGuncellemeYapildi = false;

        private bool _DosyaIndirmeYapildi = false;

        private string _ftpPwd = "PASSWRD1";

        private string _ftpUid = "aykutbastug";

        private Gunler _KontrolGunu = Gunler.HerPazartesi;

        private DateTime _KontrolSaati = new DateTime(2012, 1, 1, 17, 0, 0);

        private KontrolTipleri _KontrolTipi = KontrolTipleri.BanaSor;

        private bool _ProgramiGuncelle = true;

        private bool _ProgramYedekAlindi = false;

        private string _ProgramYedekKlasoru = "ProjeYedek";

        private bool _SqlYedekAlindi = false;

        private string _SQLYedekKlasoru = "SQLYedek";

        private string _SunucuAdresi = "ftp://94.138.206.50";

        private bool _VeritabaniYedegiAlinsin = false;

        public enum Gunler { HerGun, HerPazartesi, HerSali, HerCarsamba, HerPersembe, HerCuma, HerCumartesi, HerPazar }

        public enum KontrolTipleri { KontrolEtme, OtomatikGuncelle, BanaSor }

        public enum UygulamaTipi : int { Server, Client }

        public string cnString
        {
            get { return _cnString; }
            set { _cnString = value; }
        }

        public bool DosyaGuncellemeYapildi
        {
            get { return _DosyaGuncellemeYapildi; }
            set { _DosyaGuncellemeYapildi = value; }
        }

        public bool DosyaIndirmeYapildi
        {
            get { return _DosyaIndirmeYapildi; }
            set { _DosyaIndirmeYapildi = value; }
        }

        public string ftpPwd
        {
            get { return _ftpPwd; }
            set { _ftpPwd = value; }
        }

        public string ftpUid
        {
            get { return _ftpUid; }
            set { _ftpUid = value; }
        }

        public Gunler KontrolGunu
        {
            get { return (Gunler)_KontrolGunu; }
            set { _KontrolGunu = value; }
        }

        public DateTime KontrolSaati
        {
            get { return _KontrolSaati; }
            set { _KontrolSaati = value; }
        }

        public KontrolTipleri KontrolTipi
        {
            get { return _KontrolTipi; }
            set { _KontrolTipi = value; }
        }

        public bool ProgramiGuncelle
        {
            get { return _ProgramiGuncelle; }
            set { _ProgramiGuncelle = value; }
        }

        public bool ProgramYedekAlindi
        {
            get { return _ProgramYedekAlindi; }
            set { _ProgramYedekAlindi = value; }
        }

        public string ProgramYedekKlasoru
        {
            get { return _ProgramYedekKlasoru; }
            set { _ProgramYedekKlasoru = value; }
        }

        public bool SqlYedekAlindi
        {
            get { return _SqlYedekAlindi; }
            set { _SqlYedekAlindi = value; }
        }

        public string SQLYedekKlasoru
        {
            get { return _SQLYedekKlasoru; }
            set { _SQLYedekKlasoru = value; }
        }

        public string SunucuAdresi
        {
            get { return _SunucuAdresi; }
            set { _SunucuAdresi = value; }
        }

        public bool VeritabaniYedegiAlinsin
        {
            get { return _VeritabaniYedegiAlinsin; }
            set { _VeritabaniYedegiAlinsin = value; }
        }

        public static Degiskenler Load()
        {
            string file = Application.StartupPath + "/AVPUpdate.xml";
            if (File.Exists(file))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Degiskenler));

                StreamReader reader = new StreamReader(file);
                Degiskenler tables = (Degiskenler)serializer.Deserialize(reader);
                reader.Close();
                return tables;
            }
            else
            {
                var degisken = new Degiskenler();
                var sunucu = ConfigurationManager.AppSettings["SunucuAdresi"];
                var ftpuid = ConfigurationManager.AppSettings["ftpUid"];
                var ftppwd = ConfigurationManager.AppSettings["ftpPwd"];
                var cnstring = ConfigurationManager.AppSettings["cnString"];

                if (!string.IsNullOrEmpty(sunucu))
                    degisken.SunucuAdresi = sunucu;
                if (!string.IsNullOrEmpty(ftpuid))
                    degisken.ftpUid = ftpuid;
                if (!string.IsNullOrEmpty(ftppwd))
                    degisken.ftpPwd = ftppwd;
                if (!string.IsNullOrEmpty(cnstring))
                    degisken.cnString = cnstring;

                degisken.Kaydet();
                return degisken;
            }
            //_Save();
        }

        public void Kaydet()
        {
            string filepath = Application.StartupPath + "/AVPUpdate.xml";
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Degiskenler));

            System.IO.StreamWriter file = new System.IO.StreamWriter(filepath);
            writer.Serialize(file, this);
            file.Close();
            //_Save();
        }
    }
}