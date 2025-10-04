using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AvukatPro.Model.EntityClasses;
using AvukatProLib;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    public static class PaketHelper
    {
        private static TdiKodKullaniciGrupEntity _AktifGroup;
        private static Paket _AktifPaket;
        private static AvukatPro.Model.Linq.LinqMetaData _DataContext;
        private static bool _IsEdit = false;

        private static TdiBilKullaniciListesiEntity _Kullanici;

        private static List<Paket> _Paketler;

        private static List<TdiKodKullaniciGrupEntity> _UserGroups;

        public static TdiKodKullaniciGrupEntity AktifGroup
        {
            get
            {
                _AktifGroup = Kullanici.TdiKodKullaniciGrups.FirstOrDefault();
                if (_AktifGroup == null)
                    _AktifGroup = new TdiKodKullaniciGrupEntity();
                return _AktifGroup;
            }
        }

        public static Paket AktifPaket
        {
            get
            {
                _AktifPaket = Paketler.Where(q => q.PaketAdi == Kimlikci.Kimlik.SirketBilgisi.UrunAdi).FirstOrDefault();
                if (_AktifPaket == null)
                    _AktifPaket = new Paket();
                return _AktifPaket;
            }
            set
            {
                _AktifPaket = value;
                Kimlikci.Kimlik.SirketBilgisi.UrunAdi = _AktifPaket.PaketAdi;
            }
        }

        public static AvukatPro.Model.Linq.LinqMetaData DataContext
        {
            get
            {
                if (_DataContext == null)
                    _DataContext = AvukatPro.Services.Implementations.BaseService._db;
                return _DataContext;
            }
        }

        public static bool IsEdit
        {
            get { return PaketHelper._IsEdit; }
            set { PaketHelper._IsEdit = value; }
        }

        public static TdiBilKullaniciListesiEntity Kullanici
        {
            get
            {
                if (_Kullanici == null)
                    _Kullanici = DataContext.TdiBilKullaniciListesi.Where(q => q.Id == Kimlikci.Kimlik.Bilgi.ID).FirstOrDefault();
                return _Kullanici;
            }
        }

        public static string PaketFileName
        {
            get
            {
                return Path.Combine(Application.StartupPath, "datap.bin");
            }
        }

        public static List<Paket> Paketler
        {
            get
            {
                if (_Paketler == null)
                {
                    if (File.Exists(PaketFileName))
                    {
                        FileStream stream = File.Open(PaketFileName, FileMode.Open);
                        AES aes = new AES();
                        byte[] b = new byte[stream.Length];
                        stream.Read(b, 0, b.Length);
                        var arry = aes.Decrypt(b);
                        Stream streamm = new MemoryStream(arry);
                        BinaryFormatter bFormatter = new BinaryFormatter();
                        _Paketler = (List<Paket>)bFormatter.Deserialize(streamm);
                        stream.Close();
                        b = null;
                        arry = null;
                        aes = null;
                    }
                    else
                        _Paketler = new List<Paket>();
                }
                return _Paketler;
            }
        }

        public static List<TdiKodKullaniciGrupEntity> UserGroups
        {
            get
            {
                if (_UserGroups == null)
                {
                    _UserGroups = DataContext.TdiKodKullaniciGrup.ToList();
                }
                return _UserGroups;
            }
        }

        public static void Save(this List<Paket> objectToSerialize)
        {
            SavePackets(objectToSerialize);
        }

        public static void SavePackets(List<Paket> objectToSerialize)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(ms, objectToSerialize);

            AES aes = new AES();
            var arry = aes.Encrypt(ms.ToArray());

            FileStream stream = File.Open(PaketFileName, FileMode.Create);
            stream.Write(arry, 0, arry.Length);
            stream.Close();
            ms.Close();
            aes = null;
            arry = null;
        }
    }
}