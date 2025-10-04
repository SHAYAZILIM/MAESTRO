using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace AdimAdimDavaKaydi.UyapClass
{
    [Serializable]
    [XmlType("adres")]
    public class Adres
    {
        private string _adres = string.Empty;

        private string _adresTuru = string.Empty;

        private string _adresTuruAciklama = string.Empty;

        private string _cepTelefon = string.Empty;

        private string _elektronikPostaAdresi = string.Empty;

        private string _fax = string.Empty;

        private string _id = string.Empty;

        private string _il = string.Empty;

        private string _ilce = string.Empty;

        private string _ilceKodu = string.Empty;

        private string _ilKodu = string.Empty;

        private string _postaKodu = string.Empty;

        private string _telefon = string.Empty;

        [XmlAttribute("adres")]
        public string adres
        { get { return _adres; } set { _adres = value; } }

        [XmlAttribute("adresTuru")]
        public string adresTuru { get; set; }

        [XmlAttribute("adresTuruAciklama")]
        public string adresTuruAciklama
        { get { return _adresTuruAciklama; } set { _adresTuruAciklama = value; } }

        [XmlAttribute("cepTelefon")]
        public string cepTelefon
        { get { return _cepTelefon; } set { _cepTelefon = value; } }

        [XmlAttribute("elektronikPostaAdresi")]
        public string elektronikPostaAdresi
        { get { return _elektronikPostaAdresi; } set { _elektronikPostaAdresi = value; } }

        //todo : eSKÝ ÇPROGRAM ÇIKTILARINDA ÇIKMIYOR.
        //[XmlAttribute("adresTuru")]
        //public string adresTuru
        //{ get { return _adresTuru; } set { _adresTuru = value; } }
        [XmlAttribute("fax")]
        public string fax
        { get { return _fax; } set { _fax = value; } }

        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        [XmlAttribute("il")]
        public string il
        { get { return _il; } set { _il = value; } }

        [XmlAttribute("ilce")]
        public string ilce
        { get { return _ilce; } set { _ilce = value; } }

        [XmlAttribute("ilceKodu")]
        public string ilceKodu
        { get { return _ilceKodu; } set { _ilceKodu = value; } }

        [XmlAttribute("ilKodu")]
        public string ilKodu
        { get { return _ilKodu; } set { _ilKodu = value; } }

        [XmlAttribute("postaKodu")]
        public string postaKodu
        { get { return _postaKodu; } set { _postaKodu = value; } }

        [XmlAttribute("telefon")]
        public string telefon
        { get { return _telefon; } set { _telefon = value; } }
    }

    [Serializable]
    [XmlType("alacakKalemi")]
    public class AlacakKalemi
    {
        private string _aciklama = string.Empty;

        private string _akdiFaiz = string.Empty;

        private string _alacakKalemAdi = string.Empty;

        private string _alacakKalemIlkTutar = string.Empty;

        private string _alacakKalemKod = string.Empty;

        private string _alacakKalemKodAciklama = string.Empty;

        private string _alacakKalemKodTuru = string.Empty;

        private string _alacakKalemTip = string.Empty;

        private string _alacakKalemTutar = string.Empty;

        private string _dovizKurCevrimi = string.Empty;

        private List<Faiz> _faizler;

        //[XmlAttribute("alacakKalemTip")]
        //public string alacakKalemTip
        //{ get { return _alacakKalemTip; } set { _alacakKalemTip = value; } }
        private string _Id = string.Empty;

        private List<Ref> _refler;

        private List<Taraf> _taraflar;

        private string _tutarAdi = string.Empty;

        private string _tutarTur = string.Empty;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        [XmlAttribute("alacakKalemAdi")]
        public string alacakKalemAdi
        { get { return _alacakKalemAdi; } set { _alacakKalemAdi = value; } }

        [XmlAttribute("alacakKalemKod")]
        public string alacakKalemKod
        { get { return _alacakKalemKod; } set { _alacakKalemKod = value; } }

        [XmlAttribute("alacakKalemKodTuru")]
        public string alacakKalemKodTuru
        { get { return _alacakKalemKodTuru; } set { _alacakKalemKodTuru = value; } }

        [XmlAttribute("alacakKalemTutar")]
        public string alacakKalemTutar
        { get { return _alacakKalemTutar; } set { _alacakKalemTutar = value; } }

        [XmlElement("faiz")]
        public List<Faiz> faizler
        { get { return _faizler; } set { _faizler = value; } }

        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }

        [XmlElement("ref")]
        public List<Ref> refler
        { get { return _refler; } set { _refler = value; } }

        //[XmlAttribute("alacakKalemKodAciklama")]
        //public string alacakKalemKodAciklama
        //{ get { return _alacakKalemKodAciklama; } set { _alacakKalemKodAciklama = value; } }
        [XmlElement("taraf")]
        public List<Taraf> taraflar
        { get { return _taraflar; } set { _taraflar = value; } }

        [XmlAttribute("tutarAdi")]
        public string tutarAdi
        { get { return _tutarAdi; } set { _tutarAdi = value; } }

        [XmlAttribute("tutarTur")]
        public string tutarTur
        { get { return _tutarTur; } set { _tutarTur = value; } }

        //TODO : Eski programda yok .

        //[XmlAttribute("alacakKalemIlkTutar")]
        //public string alacakKalemIlkTutar
        //{ get { return _alacakKalemIlkTutar; } set { _alacakKalemIlkTutar = value; } }

        //[XmlAttribute("dovizKurCevrimi")]
        //public string dovizKurCevrimi
        //{ get { return _dovizKurCevrimi; } set { _dovizKurCevrimi = value; } }

        //[XmlAttribute("akdiFaiz")]
        //public string akdiFaiz
        //{ get { return _akdiFaiz; } set { _akdiFaiz = value; } }
        //[XmlAttribute("sabitTaksitTarihi")]
        //  public DateTime sabitTaksitTarihi
        // { get { return _sabitTaksitTarihi; } set { _sabitTaksitTarihi = value; } }
    }

    [Serializable]
    [XmlType("cek")]
    public class Cek
    {
        private List<AlacakKalemi> _alacakKalemi;

        private string _bankaAdi = string.Empty;

        private string _bankaID = string.Empty;

        private string _bankaSubeAdi = string.Empty;

        private string _bankaSubeAdres = string.Empty;

        private string _bankaSubeIl = string.Empty;

        private string _bankaSubeIlce = string.Empty;

        private string _bankaSubeKod = string.Empty;

        private string _Id;

        private string _ibrazTarihi = string.Empty;

        private string _islemlerBasladimi = string.Empty;

        private string _kesideTarihi = string.Empty;

        private string _kesideYeri = string.Empty;

        private string _kocanNo = string.Empty;

        private string _odemeYeri = string.Empty;

        private List<Ref> _refler;

        private string _seriNo = string.Empty;

        private List<Taraf> _taraflar;

        private string _tutar = string.Empty;

        private string _tutarTur = string.Empty;

        private string _tutarTurAciklama = string.Empty;

        [XmlElement("alacakKalemi")]
        public List<AlacakKalemi> alacakKalemi
        { get { return _alacakKalemi; } set { _alacakKalemi = value; } }

        [XmlAttribute("bankaAdi")]
        public string bankaAdi
        { get { return _bankaAdi; } set { _bankaAdi = value; } }

        [XmlAttribute("bankaID")]
        public string bankaID
        { get { return _bankaID; } set { _bankaID = value; } }

        [XmlAttribute("bankaSubeAdi")]
        public string bankaSubeAdi
        { get { return _bankaSubeAdi; } set { _bankaSubeAdi = value; } }

        [XmlAttribute("bankaSubeAdres")]
        public string bankaSubeAdres
        { get { return _bankaSubeAdres; } set { _bankaSubeAdres = value; } }

        [XmlAttribute("bankaSubeIl")]
        public string bankaSubeIl
        { get { return _bankaSubeIl; } set { _bankaSubeIl = value; } }

        [XmlAttribute("bankaSubeIlce")]
        public string bankaSubeIlce
        { get { return _bankaSubeIlce; } set { _bankaSubeIlce = value; } }

        [XmlAttribute("bankaSubeKod")]
        public string bankaSubeKod
        { get { return _bankaSubeKod; } set { _bankaSubeKod = value; } }

        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }

        [XmlAttribute("ibrazTarihi")]
        public string ibrazTarihi
        { get { return _ibrazTarihi; } set { _ibrazTarihi = value; } }

        [XmlAttribute("islemlerBasladimi")]
        public string islemlerBasladimi
        { get { return _islemlerBasladimi; } set { _islemlerBasladimi = value; } }

        [XmlAttribute("kesideTarihi")]
        public string kesideTarihi
        { get { return _kesideTarihi; } set { _kesideTarihi = value; } }

        [XmlAttribute("kesideYeri")]
        public string kesideYeri
        { get { return _kesideYeri; } set { _kesideYeri = value; } }

        [XmlAttribute("kocanNo")]
        public string kocanNo
        { get { return _kocanNo; } set { _kocanNo = value; } }

        [XmlAttribute("odemeYeri")]
        public string odemeYeri
        { get { return _odemeYeri; } set { _odemeYeri = value; } }

        [XmlElement("ref")]
        public List<Ref> refler
        { get { return _refler; } set { _refler = value; } }

        [XmlAttribute("seriNo")]
        public string seriNo
        { get { return _seriNo; } set { _seriNo = value; } }

        [XmlElement("taraf")]
        public List<Taraf> taraflar
        { get { return _taraflar; } set { _taraflar = value; } }

        [XmlAttribute("tutar")]
        public string tutar
        { get { return _tutar; } set { _tutar = value; } }

        [XmlAttribute("tutarTur")]
        public string tutarTur
        { get { return _tutarTur; } set { _tutarTur = value; } }

        [XmlAttribute("tutarTurAciklama")]
        public string tutarTurAciklama
        { get { return _tutarTurAciklama; } set { _tutarTurAciklama = value; } }
    }

    [Serializable]
    [XmlType("digerAlacak")]
    public class DigerAlacak
    {
        private List<AlacakKalemi> _alacakKalemi;

        private string _alacakNo = string.Empty;

        private string _digerAlacakAciklama = string.Empty;

        private string _Id = string.Empty;

        private List<Ref> _refler;

        private List<Taraf> _taraflar;

        private string _tarih = string.Empty;

        private string _tutar = string.Empty;

        private string _tutarAdi = string.Empty;

        private string _tutarTur = string.Empty;

        [XmlElement("alacakKalemi")]
        public List<AlacakKalemi> alacakKalemi
        { get { return _alacakKalemi; } set { _alacakKalemi = value; } }

        [XmlAttribute("alacakNo")]
        public string alacakNo
        { get { return _alacakNo; } set { _alacakNo = value; } }

        [XmlAttribute("digerAlacakAciklama")]
        public string digerAlacakAciklama
        { get { return _digerAlacakAciklama; } set { _digerAlacakAciklama = value; } }

        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }

        [XmlElement("ref")]
        public List<Ref> refler
        { get { return _refler; } set { _refler = value; } }

        [XmlElement("taraf")]
        public List<Taraf> taraflar
        { get { return _taraflar; } set { _taraflar = value; } }

        [XmlAttribute("tarih")]
        public string tarih
        { get { return _tarih; } set { _tarih = value; } }

        [XmlAttribute("tutar")]
        public string tutar
        { get { return _tutar; } set { _tutar = value; } }

        [XmlAttribute("tutarAdi")]
        public string tutarAdi
        { get { return _tutarAdi; } set { _tutarAdi = value; } }

        [XmlAttribute("tutarTur")]
        public string tutarTur
        { get { return _tutarTur; } set { _tutarTur = value; } }
    }

    [Serializable()]
    [XmlType("evrak")]
    public class Evrak
    {
        private Evrak _evrak;

        private string _fileName = string.Empty;

        private string _mimeType = string.Empty;

        [XmlElement("evrak")]
        public Evrak evrak
        { get { return _evrak; } set { _evrak = value; } }

        [XmlAttribute("fileName")]
        public string fileName
        { get { return _fileName; } set { _fileName = value; } }

        [XmlAttribute("mimeType")]
        public string mimeType
        { get { return _mimeType; } set { _mimeType = value; } }

        /*
        public byte[] Data
        { get { return _Data; } set { _Data = value; } }

        private byte[] _Data;
        */
    }

    [Serializable]
    [XmlType("faiz")]
    public class Faiz
    {
        private string _baslangicTarihi;

        private string _bitisTarihi;

        private string _faizOran;

        private string _faizSureTip;

        private string _faizTipKod;

        private string _faizTipKodAciklama;

        private decimal _faizTutar;

        private string _faizTutarTur;

        private string _faizTutarTurAdi;

        private string _Id;

        [XmlAttribute("baslangicTarihi")]
        public string baslangicTarihi
        { get { return _baslangicTarihi; } set { _baslangicTarihi = value; } }

        [XmlAttribute("bitisTarihi")]
        public string bitisTarihi
        { get { return _bitisTarihi; } set { _bitisTarihi = value; } }

        [XmlAttribute("faizOran")]
        public string faizOran
        { get { return _faizOran; } set { _faizOran = value; } }

        [XmlAttribute("faizSureTip")]
        public string faizSureTip
        { get { return _faizSureTip; } set { _faizSureTip = value; } }

        [XmlAttribute("faizTipKod")]
        public string faizTipKod
        { get { return _faizTipKod; } set { _faizTipKod = value; } }

        [XmlAttribute("faizTipKodAciklama")]
        public string faizTipKodAciklama
        { get { return _faizTipKodAciklama; } set { _faizTipKodAciklama = value; } }

        [XmlAttribute("faizTutar")]
        public decimal faizTutar
        { get { return _faizTutar; } set { _faizTutar = value; } }

        [XmlAttribute("faizTutarTur")]
        public string faizTutarTur
        { get { return _faizTutarTur; } set { _faizTutarTur = value; } }

        [XmlAttribute("faizTutarTurAdi")]
        public string faizTutarTurAdi
        { get { return _faizTutarTurAdi; } set { _faizTutarTurAdi = value; } }

        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }
    }

    [Serializable]
    [XmlType("ilam")]
    public class Ilam
    {
        private List<AlacakKalemi> _alacakKalemi;
        private string _davaAcilisTarihi = string.Empty;
        private string _id = string.Empty;
        private string _ilamAciklama = string.Empty;
        private string _ilamDosyaNoYil = string.Empty;
        private string _ilamDosyaSira = string.Empty;
        private string _ilamiVerenMahkeme = string.Empty;
        private string _ilamKararNoYil = string.Empty;
        private string _ilamKararSira = "1";
        private string _ilamKurumAd = string.Empty;
        private string _ilamKurumTip = "0";
        private string _ilamTarihi = string.Empty;
        private string _kesifTarihi = string.Empty;
        private string _kesinlesmeTarih = string.Empty;
        private List<ParaylaOlculemeyenAlacak> _paraylaOlculemeyenAlacak;
        private string _tcKimlikNo = string.Empty;
        private Teminat _teminat;

        [XmlElement("alacakKalemi")]
        public List<AlacakKalemi> alacakKalemi
        { get { return _alacakKalemi; } set { _alacakKalemi = value; } }

        [XmlAttribute("davaAcilisTarih")]
        public string davaAcilisTarihi
        { get { return _davaAcilisTarihi; } set { _davaAcilisTarihi = value; } }

        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        [XmlAttribute("ilamAciklama")]
        public string ilamAciklama
        { get { return _ilamAciklama; } set { _ilamAciklama = value; } }

        [XmlAttribute("ilamDosyaNoYil")]
        public string ilamDosyaNoYil
        { get { return _ilamDosyaNoYil; } set { _ilamDosyaNoYil = value; } }

        [XmlAttribute("ilamDosyaSira")]
        public string ilamDosyaSira
        { get { return _ilamDosyaSira; } set { _ilamDosyaSira = value; } }

        [XmlAttribute("ilamiVerenMahkeme")]
        public string ilamiVerenMahkeme
        { get { return _ilamiVerenMahkeme; } set { _ilamiVerenMahkeme = value; } }

        [XmlAttribute("ilamKararNoYil")]
        public string ilamKararNoYil
        { get { return _ilamKararNoYil; } set { _ilamKararNoYil = value; } }

        [XmlAttribute("ilamKararSira")]
        public string ilamKararSira
        { get { return _ilamKararSira; } set { _ilamKararSira = value; } }

        [XmlAttribute("ilamKurumAd")]
        public string ilamKurumAd
        { get { return _ilamKurumAd; } set { _ilamKurumAd = value; } }

        [XmlAttribute("ilamKurumTip")]
        public string ilamKurumTip
        { get { return _ilamKurumTip; } set { _ilamKurumTip = value; } }

        [XmlAttribute("ilamTarihi")]
        public string ilamTarihi
        { get { return _ilamTarihi; } set { _ilamTarihi = value; } }

        [XmlAttribute("kesifTarih")]
        public string kesifTarihi
        { get { return _kesifTarihi; } set { _kesifTarihi = value; } }

        [XmlAttribute("kesinlesmeTarih")]
        public string kesinlesmeTarih
        { get { return _kesinlesmeTarih; } set { _kesinlesmeTarih = value; } }

        [XmlElement("paraylaOlculemeyenAlacak")]
        public List<ParaylaOlculemeyenAlacak> paraylaOlculemeyenAlacak
        { get { return _paraylaOlculemeyenAlacak; } set { _paraylaOlculemeyenAlacak = value; } }

        [XmlAttribute("tcKimlikNo")]
        public string tcKimlikNo
        { get { return _tcKimlikNo; } set { _tcKimlikNo = value; } }

        [XmlElement("teminat")]
        public Teminat teminat
        { get { return _teminat; } set { _teminat = value; } }
    }

    [Serializable]
    [XmlType("kisiKurumBilgileri")]
    public class KisiKurumBilgileri
    {
        private string _ad = string.Empty;

        private Adres _adres;

        private string _id = string.Empty;

        private KisiTumBilgileri _kisiTumBilgileri;

        private Kurum _kurum;

        private Ref _Ref;

        [XmlAttribute("ad")]
        public string ad
        { get { return _ad; } set { _ad = value; } }

        [XmlElement("adres")]
        public Adres adres
        { get { return _adres; } set { _adres = value; } }

        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        [XmlElement("kisiTumBilgileri")]
        public KisiTumBilgileri kisiTumBilgileri
        { get { return _kisiTumBilgileri; } set { _kisiTumBilgileri = value; } }

        [XmlElement("kurum")]
        public Kurum kurum
        { get { return _kurum; } set { _kurum = value; } }

        [XmlElement("Ref")]
        public Ref Ref
        { get { return _Ref; } set { _Ref = value; } }
    }

    [Serializable]
    [XmlType("kisiTumBilgileri")]
    public class KisiTumBilgileri
    {
        private string _adi = string.Empty;

        private string _aileSiraNo = string.Empty;

        private string _anaAdi = string.Empty;

        private string _babaAdi = string.Empty;

        private string _ciltNo = string.Empty;

        private string _cinsiyeti;

        private string _cuzdanNo = string.Empty;

        private string _cuzdanSeriNo = string.Empty;

        private string _dogumTarihi = string.Empty;

        private string _dogumYeri = string.Empty;

        private string _id = string.Empty;

        private string _kayitNo = string.Empty;

        private string _mahKoy = string.Empty;

        private string _nufusaKayitIlceKodu = string.Empty;

        private string _nufusaKayitIlKodu = string.Empty;

        private string _oncekiSoyadi = string.Empty;

        private string _siraNo = string.Empty;

        private string _soyadi = string.Empty;

        private string _tcKimlikNo = string.Empty;

        private string _vergiNo = string.Empty;

        private string _verildigiIlAdi = string.Empty;

        private string _verildigiIlceAdi = string.Empty;

        private string _verildigiIlceKodu = string.Empty;

        private string _verildigiIlKodu = string.Empty;

        private string _verildigiTarih = string.Empty;

        private string _verilisNedeni = string.Empty;

        private string _ybnNfsKayitliOldgYer = string.Empty;

        [XmlAttribute("adi")]
        public string adi
        { get { return _adi; } set { _adi = value; } }

        [XmlAttribute("aileSiraNo")]
        public string aileSiraNo
        { get { return _aileSiraNo; } set { _aileSiraNo = value; } }

        [XmlAttribute("anaAdi")]
        public string anaAdi
        { get { return _anaAdi; } set { _anaAdi = value; } }

        [XmlAttribute("babaAdi")]
        public string babaAdi
        { get { return _babaAdi; } set { _babaAdi = value; } }

        [XmlAttribute("ciltNo")]
        public string ciltNo
        { get { return _ciltNo; } set { _ciltNo = value; } }

        [XmlAttribute("cinsiyeti")]
        public string cinsiyeti
        {
            get
            {
                if (_cinsiyeti.Length == 0)
                    _cinsiyeti = "E";
                return _cinsiyeti;
            }
            set { _cinsiyeti = value; }
        }

        [XmlAttribute("cuzdanNo")]
        public string cuzdanNo
        { get { return _cuzdanNo; } set { _cuzdanNo = value; } }

        [XmlAttribute("cuzdanSeriNo")]
        public string cuzdanSeriNo
        { get { return _cuzdanSeriNo; } set { _cuzdanSeriNo = value; } }

        [XmlAttribute("dogumTarihi")]
        public string dogumTarihi
        { get { return _dogumTarihi; } set { _dogumTarihi = value; } }

        [XmlAttribute("dogumYeri")]
        public string dogumYeri
        { get { return _dogumYeri; } set { _dogumYeri = value; } }

        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        [XmlAttribute("kayitNo")]
        public string kayitNo
        { get { return _kayitNo; } set { _kayitNo = value; } }

        [XmlAttribute("mahKoy")]
        public string mahKoy
        { get { return _mahKoy; } set { _mahKoy = value; } }

        [XmlAttribute("nufusaKayitIlceKodu")]
        public string nufusaKayitIlceKodu
        { get { return _nufusaKayitIlceKodu; } set { _nufusaKayitIlceKodu = value; } }

        [XmlAttribute("nufusaKayitIlKodu")]
        public string nufusaKayitIlKodu
        { get { return _nufusaKayitIlKodu; } set { _nufusaKayitIlKodu = value; } }

        [XmlAttribute("oncekiSoyadi")]
        public string oncekiSoyadi
        { get { return _oncekiSoyadi; } set { _oncekiSoyadi = value; } }

        [XmlAttribute("siraNo")]
        public string siraNo
        { get { return _siraNo; } set { _siraNo = value; } }

        [XmlAttribute("soyadi")]
        public string soyadi
        { get { return _soyadi; } set { _soyadi = value; } }

        [XmlAttribute("tcKimlikNo")]
        public string tcKimlikNo
        { get { return _tcKimlikNo; } set { _tcKimlikNo = value; } }

        [XmlAttribute("vergiNo")]
        public string vergiNo
        { get { return _vergiNo; } set { _vergiNo = value; } }

        [XmlAttribute("verildigiIlAdi")]
        public string verildigiIlAdi
        { get { return _verildigiIlAdi; } set { _verildigiIlAdi = value; } }

        [XmlAttribute("verildigiIlceAdi")]
        public string verildigiIlceAdi
        { get { return _verildigiIlceAdi; } set { _verildigiIlceAdi = value; } }

        [XmlAttribute("verildigiIlceKodu")]
        public string verildigiIlceKodu
        { get { return _verildigiIlceKodu; } set { _verildigiIlceKodu = value; } }

        [XmlAttribute("verildigiIlKodu")]
        public string verildigiIlKodu
        { get { return _verildigiIlKodu; } set { _verildigiIlKodu = value; } }

        [XmlAttribute("verildigiTarih")]
        public string verildigiTarih
        { get { return _verildigiTarih; } set { _verildigiTarih = value; } }

        [XmlAttribute("verilisNedeni")]
        public string verilisNedeni
        { get { return _verilisNedeni; } set { _verilisNedeni = value; } }

        [XmlAttribute("ybnNfsKayitliOldgYer")]
        public string ybnNfsKayitliOldgYer
        { get { return _ybnNfsKayitliOldgYer; } set { _ybnNfsKayitliOldgYer = value; } }
    }

    [Serializable]
    [XmlType("kontrat")]
    public class Kontrat
    {
        private string _ = string.Empty;

        private string _aciklama = string.Empty;

        private string _adresAciklama = string.Empty;

        private List<AlacakKalemi> _alacakKalemi;

        private string _belgeIslemeleriBaslatiliyormu = string.Empty;

        private string _belgeninTutari = string.Empty;

        private string _gecerlilikSonlanmaTarihi = string.Empty;

        private string _gecerliOlduguSure = string.Empty;

        private string _hazirlanisTarihi = string.Empty;

        private string _Id = string.Empty;

        private string _olmasiGerekenPulDegeri = string.Empty;

        private List<Ref> _refler;

        private string _sozlesmeSozluBelgeli = string.Empty;

        private List<Taraf> _taraflar;

        private string _tutarTur = string.Empty;

        private string _tutarTurAciklama = string.Empty;

        private string _uzerindekiPulDegeri = string.Empty;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        [XmlAttribute("adresAciklama")]
        public string adresAciklama
        { get { return _adresAciklama; } set { _adresAciklama = value; } }

        [XmlElement("alacakKalemi")]
        public List<AlacakKalemi> alacakKalemi
        { get { return _alacakKalemi; } set { _alacakKalemi = value; } }

        [XmlAttribute("belgeIslemleriBaslatiliyormu")]
        public string belgeIslemeleriBaslatiliyormu
        { get { return _belgeIslemeleriBaslatiliyormu; } set { _belgeIslemeleriBaslatiliyormu = value; } }

        [XmlAttribute("belgeninTutari")]
        public string belgeninTutari
        { get { return _belgeninTutari; } set { _belgeninTutari = value; } }

        [XmlAttribute("gecerlilikBaslangicTarihi")]
        public string gecerlilikBaslangicTarihi
        { get { return _; } set { _ = value; } }

        [XmlAttribute("gecerlilikSonlanmaTarihi")]
        public string gecerlilikSonlanmaTarihi
        { get { return _gecerlilikSonlanmaTarihi; } set { _gecerlilikSonlanmaTarihi = value; } }

        [XmlAttribute("gecerliOlduguSure")]
        public string gecerliOlduguSure
        { get { return _gecerliOlduguSure; } set { _gecerliOlduguSure = value; } }

        [XmlAttribute("hazirlanisTarihi")]
        public string hazirlanisTarihi
        { get { return _hazirlanisTarihi; } set { _hazirlanisTarihi = value; } }

        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }

        [XmlAttribute("olmasiGerekenPulDegeri")]
        public string olmasiGerekenPulDegeri
        { get { return _olmasiGerekenPulDegeri; } set { _olmasiGerekenPulDegeri = value; } }

        [XmlElement("ref")]
        public List<Ref> refler
        { get { return _refler; } set { _refler = value; } }

        [XmlAttribute("sozlesmeSozluBelgeli")]
        public string sozlesmeSozluBelgeli
        { get { return _sozlesmeSozluBelgeli; } set { _sozlesmeSozluBelgeli = value; } }

        [XmlElement("taraf")]
        public List<Taraf> taraflar
        { get { return _taraflar; } set { _taraflar = value; } }

        [XmlAttribute("tutarTur")]
        public string tutarTur
        { get { return _tutarTur; } set { _tutarTur = value; } }

        [XmlAttribute("tutarTurAciklama")]
        public string tutarTurAciklama
        { get { return _tutarTurAciklama; } set { _tutarTurAciklama = value; } }

        [XmlAttribute("uzerindekiPulDegeri")]
        public string uzerindekiPulDegeri
        { get { return _uzerindekiPulDegeri; } set { _uzerindekiPulDegeri = value; } }
    }

    [Serializable]
    [XmlType("kontratKefil")]
    public class KontratKefil
    {
        private Adres _adres;

        private string _Id;

        private Kontrat _kontrat;

        private Ref _MyRef;

        [XmlElement("adres")]
        public Adres adres
        { get { return _adres; } set { _adres = value; } }

        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }

        [XmlElement("kontrat")]
        public Kontrat kontrat
        { get { return _kontrat; } set { _kontrat = value; } }

        [XmlElement("ref")]
        public Ref MyRef
        { get { return _MyRef; } set { _MyRef = value; } }
    }

    [Serializable]
    [XmlType("kurum")]
    public class Kurum
    {
        private string _harcDurumu = string.Empty;

        private string _id = string.Empty;

        private string _kamuOzel = string.Empty;

        private string _kurumAdi = string.Empty;

        private string _sskIsyeriSicilNo = string.Empty;

        private string _ticaretSicilNoVerildigiYer = string.Empty;

        private string _ticariSicilNo = string.Empty;

        private string _vergiDairesi = string.Empty;

        private string _vergiNo = string.Empty;

        [XmlAttribute("harcDurumu")]
        public string harcDurumu
        { get { return _harcDurumu; } set { _harcDurumu = value; } }

        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        [XmlAttribute("kamuOzel")]
        public string kamuOzel
        { get { return _kamuOzel; } set { _kamuOzel = value; } }

        [XmlAttribute("kurumAdi")]
        public string kurumAdi
        { get { return _kurumAdi; } set { _kurumAdi = value; } }

        [XmlAttribute("sskIsyeriSicilNo")]
        public string sskIsyeriSicilNo
        { get { return _sskIsyeriSicilNo; } set { _sskIsyeriSicilNo = value; } }

        [XmlAttribute("ticaretSicilNoVerildigiYer")]
        public string ticaretSicilNoVerildigiYer
        { get { return _ticaretSicilNoVerildigiYer; } set { _ticaretSicilNoVerildigiYer = value; } }

        [XmlAttribute("ticaretSicilNo")]
        public string ticariSicilNo
        { get { return _ticariSicilNo; } set { _ticariSicilNo = value; } }

        [XmlAttribute("vergiDairesi")]
        public string vergiDairesi
        { get { return _vergiDairesi; } set { _vergiDairesi = value; } }

        [XmlAttribute("vergiNo")]
        public string vergiNo
        { get { return _vergiNo; } set { _vergiNo = value; } }
    }

    [Serializable]
    [XmlType("paraylaOlculemeyenAlacak")]
    public class ParaylaOlculemeyenAlacak
    {
        private string _aciklama = string.Empty;

        private string _id = string.Empty;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }
    }

    [Serializable]
    [XmlType("police")]
    public class Police
    {
        private List<AlacakKalemi> _alacakKalemi;

        private string _belgeninTutari;

        private string _Id;

        private string _islemlerBasladimi;

        private string _kesideciAdSoyad;

        private string _kesideTarihi;

        private string _kesideYeri;

        private string _lehtarAdSoyad;

        private string _odemeYeri;

        private string _odeyecekKisiAdSoyad;

        private string _olmasiGrknPulDegeri;

        private List<Ref> _refler;

        private List<Taraf> _taraflar;

        private string _tutarAdi;

        private string _tutarTur;

        private string _uzerindekiPulunDegeri;

        private string _vadeTarihi;

        [XmlElement("alacakKalemi")]
        public List<AlacakKalemi> alacakKalemi
        { get { return _alacakKalemi; } set { _alacakKalemi = value; } }

        [XmlAttribute("belgeninTutari")]
        public string belgeninTutari
        { get { return _belgeninTutari; } set { _belgeninTutari = value; } }

        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }

        [XmlAttribute("islemlerBasladimi")]
        public string islemlerBasladimi
        { get { return _islemlerBasladimi; } set { _islemlerBasladimi = value; } }

        [XmlAttribute("kesideciAdSoyad")]
        public string kesideciAdSoyad
        { get { return _kesideciAdSoyad; } set { _kesideciAdSoyad = value; } }

        [XmlAttribute("kesideTarihi")]
        public string kesideTarihi
        { get { return _kesideTarihi; } set { _kesideTarihi = value; } }

        [XmlAttribute("kesideYeri")]
        public string kesideYeri
        { get { return _kesideYeri; } set { _kesideYeri = value; } }

        [XmlAttribute("lehtarAdSoyad")]
        public string lehtarAdSoyad
        { get { return _lehtarAdSoyad; } set { _lehtarAdSoyad = value; } }

        [XmlAttribute("odemeYeri")]
        public string odemeYeri
        { get { return _odemeYeri; } set { _odemeYeri = value; } }

        [XmlAttribute("odeyecekKisiAdSoyad")]
        public string odeyecekKisiAdSoyad
        { get { return _odeyecekKisiAdSoyad; } set { _odeyecekKisiAdSoyad = value; } }

        [XmlAttribute("olmasiGrknPulDegeri")]
        public string olmasiGrknPulDegeri
        { get { return _olmasiGrknPulDegeri; } set { _olmasiGrknPulDegeri = value; } }

        [XmlElement("ref")]
        public List<Ref> refler
        { get { return _refler; } set { _refler = value; } }

        [XmlElement("taraf")]
        public List<Taraf> taraflar
        { get { return _taraflar; } set { _taraflar = value; } }

        [XmlAttribute("tutarAdi")]
        public string tutarAdi
        { get { return _tutarAdi; } set { _tutarAdi = value; } }

        [XmlAttribute("tutarTur")]
        public string tutarTur
        { get { return _tutarTur; } set { _tutarTur = value; } }

        [XmlAttribute("uzerindekiPulunDegeri")]
        public string uzerindekiPulunDegeri
        { get { return _uzerindekiPulunDegeri; } set { _uzerindekiPulunDegeri = value; } }

        [XmlAttribute("vadeTarihi")]
        public string vadeTarihi
        { get { return _vadeTarihi; } set { _vadeTarihi = value; } }
    }

    [Serializable]
    [XmlType("ref")]
    public class Ref
    {
        private string _id;

        private string _to;

        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        [XmlAttribute("to")]
        public string to
        { get { return _to; } set { _to = value; } }
    }

    [Serializable]
    [XmlType("rolTur")]
    public class RolTur
    {
        private string _Rol = string.Empty;

        private string _rolID = string.Empty;

        [XmlAttribute("Rol")]
        public string Rol
        { get { return _Rol; } set { _Rol = value; } }

        [XmlAttribute("rolID")]
        public string rolID
        { get { return _rolID; } set { _rolID = value; } }
    }

    [Serializable]
    [XmlType("senet")]
    public class Senet
    {
        private List<AlacakKalemi> _alacakKalemi;

        private string _belgeninTutari;

        private string _Id;

        private string _islemlerBasladimi;

        private string _odemeYeri;

        private string _olmasiGrknPulDegeri;

        private List<Ref> _refler;

        private string _tanzimTarihi;

        private string _tanzimYeri;

        private List<Taraf> _taraflar;

        private string _tutarAdi;

        private string _tutarTur;

        private string _uzerindekiPulunDegeri;

        private string _vadeTarihi;

        [XmlElement("alacakKalemi")]
        public List<AlacakKalemi> alacakKalemi
        { get { return _alacakKalemi; } set { _alacakKalemi = value; } }

        [XmlAttribute("belgeninTutari")]
        public string belgeninTutari
        { get { return _belgeninTutari; } set { _belgeninTutari = value; } }

        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }

        [XmlAttribute("islemlerBasladimi")]
        public string islemlerBasladimi
        { get { return _islemlerBasladimi; } set { _islemlerBasladimi = value; } }

        [XmlAttribute("odemeYeri")]
        public string odemeYeri
        { get { return _odemeYeri; } set { _odemeYeri = value; } }

        [XmlAttribute("olmasiGrknPulDegeri")]
        public string olmasiGrknPulDegeri
        { get { return _olmasiGrknPulDegeri; } set { _olmasiGrknPulDegeri = value; } }

        [XmlElement("ref")]
        public List<Ref> refler
        { get { return _refler; } set { _refler = value; } }

        [XmlAttribute("tanzimTarihi")]
        public string tanzimTarihi
        { get { return _tanzimTarihi; } set { _tanzimTarihi = value; } }

        [XmlAttribute("tanzimYeri")]
        public string tanzimYeri
        { get { return _tanzimYeri; } set { _tanzimYeri = value; } }

        [XmlElement("taraf")]
        public List<Taraf> taraflar
        { get { return _taraflar; } set { _taraflar = value; } }

        [XmlAttribute("tutarAdi")]
        public string tutarAdi
        { get { return _tutarAdi; } set { _tutarAdi = value; } }

        [XmlAttribute("tutarTur")]
        public string tutarTur
        { get { return _tutarTur; } set { _tutarTur = value; } }

        [XmlAttribute("uzerindekiPulunDegeri")]
        public string uzerindekiPulunDegeri
        { get { return _uzerindekiPulunDegeri; } set { _uzerindekiPulunDegeri = value; } }

        [XmlAttribute("vadeTarihi")]
        public string vadeTarihi
        { get { return _vadeTarihi; } set { _vadeTarihi = value; } }
    }

    [Serializable]
    [XmlType("taraf")]
    public class Taraf
    {
        private string _id = string.Empty;
        private KisiKurumBilgileri _kisiKurumBilgileri;
        private Ref _myRef;
        private List<Ref> _refler;
        private RolTur _rolTur;

        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        [XmlElement("kisiKurumBilgileri")]
        public KisiKurumBilgileri kisiKurumBilgileri
        { get { return _kisiKurumBilgileri; } set { _kisiKurumBilgileri = value; } }

        [XmlElement("myRef")]
        public Ref myRef
        { get { return _myRef; } set { _myRef = value; } }

        [XmlElement("ref")]
        public List<Ref> refler
        { get { return _refler; } set { _refler = value; } }

        [XmlElement("rolTur")]
        public RolTur rolTur
        { get { return _rolTur; } set { _rolTur = value; } }
    }

    [Serializable]
    [XmlType("teminat")]
    public class Teminat
    {
        private string _id = string.Empty;

        private string _ilamAciklama = string.Empty;

        private string _tahsilatMakbuzNo = string.Empty;

        private DateTime _tahsilatMakbuzTarihi;

        private string _teminatiVerenKurum = string.Empty;

        private string _teminatNedeni = string.Empty;

        private string _teminatNo = string.Empty;

        private int _teminatTipi;

        private decimal _teminatTutar;

        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        [XmlAttribute("ilamAciklama")]
        public string ilamAciklama
        { get { return _ilamAciklama; } set { _ilamAciklama = value; } }

        [XmlAttribute("tahsilatMakbuzNo")]
        public string tahsilatMakbuzNo
        { get { return _tahsilatMakbuzNo; } set { _tahsilatMakbuzNo = value; } }

        [XmlAttribute("tahsilatMakbuzTarihi")]
        public DateTime tahsilatMakbuzTarihi
        { get { return _tahsilatMakbuzTarihi; } set { _tahsilatMakbuzTarihi = value; } }

        [XmlAttribute("teminatiVerenKurum")]
        public string teminatiVerenKurum
        { get { return _teminatiVerenKurum; } set { _teminatiVerenKurum = value; } }

        [XmlAttribute("teminatNedeni")]
        public string teminatNedeni
        { get { return _teminatNedeni; } set { _teminatNedeni = value; } }

        [XmlAttribute("teminatNo")]
        public string teminatNo
        { get { return _teminatNo; } set { _teminatNo = value; } }

        [XmlAttribute("teminatTipi")]
        public int teminatTipi
        { get { return _teminatTipi; } set { _teminatTipi = value; } }

        [XmlAttribute("teminatTutar")]
        public decimal teminatTutar
        { get { return _teminatTutar; } set { _teminatTutar = value; } }
    }

    [Serializable]
    [XmlType("vekil")]
    public class Vekil
    {
        private string _adi = string.Empty;

        private string _avukatlikBuroAdi = string.Empty;

        private string _bakanlikDosyaNo = string.Empty;

        private string _baroNo = string.Empty;

        private string _borcluVekilMi = string.Empty;

        private string _id = string.Empty;

        private string _kapanmaNedeni = "0";

        private string _kurumAvikatiMi = string.Empty;

        private string _sigortaliMi = string.Empty;

        private string _soyadi = string.Empty;

        private string _tbbNo = string.Empty;

        private string _tcKimlikNo = string.Empty;

        private string _vekilTipi = string.Empty;

        private string _vergiNo = string.Empty;

        [XmlAttribute("adi")]
        public string adi
        { get { return _adi; } set { _adi = value; } }

        [XmlAttribute("avukatlikBuroAdi")]
        public string avukatlikBuroAdi
        { get { return _avukatlikBuroAdi; } set { _avukatlikBuroAdi = value; } }

        [XmlAttribute("baroNo")]
        public string baroNo
        { get { return _baroNo; } set { _baroNo = value; } }

        [XmlAttribute("borcluVekiliMi")]
        public string borcluVekilMi
        { get { return _borcluVekilMi; } set { _borcluVekilMi = value; } }

        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        [XmlAttribute("kapanmaNedeni")]
        public string kapanmaNedeni
        { get { return _kapanmaNedeni; } set { _kapanmaNedeni = value; } }

        [XmlAttribute("kurumAvukatiMi")]
        public string kurumAvikatiMi
        { get { return _kurumAvikatiMi; } set { _kurumAvikatiMi = value; } }

        [XmlAttribute("sigortaliMi")]
        public string sigortaliMi
        { get { return _sigortaliMi; } set { _sigortaliMi = value; } }

        [XmlAttribute("soyadi")]
        public string soyadi
        { get { return _soyadi; } set { _soyadi = value; } }

        [XmlAttribute("tbbNo")]
        public string tbbNo
        { get { return _tbbNo; } set { _tbbNo = value; } }

        [XmlAttribute("tcKimlikNo")]
        public string tcKimlikNo
        { get { return _tcKimlikNo; } set { _tcKimlikNo = value; } }

        [XmlAttribute("vekilTipi")]
        public string vekilTipi
        { get { return _vekilTipi; } set { _vekilTipi = value; } }

        [XmlAttribute("vergiNo")]
        public string vergiNo
        { get { return _vergiNo; } set { _vergiNo = value; } }

        //TODO: ESKÝ PROGRAMDA YOK
        //[XmlAttribute("bakanlikDosyaNo")]
        //public string bakanlikDosyaNo
        //{ get { return _bakanlikDosyaNo; } set { _bakanlikDosyaNo = value; } }
    }

    [Serializable]
    [XmlType("VekilKisi")]
    public class VekilKisi
    {
        private Adres _adres;

        private string _id = string.Empty;

        private KisiTumBilgileri _kisiTumBilgileri;

        private Vekil _vekil;

        [XmlElement("adres")]
        public Adres adres
        { get { return _adres; } set { _adres = value; } }

        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        [XmlElement("kisiTumBilgileri")]
        public KisiTumBilgileri kisiTumBilgileri
        { get { return _kisiTumBilgileri; } set { _kisiTumBilgileri = value; } }

        [XmlElement("vekil")]
        public Vekil vekil
        { get { return _vekil; } set { _vekil = value; } }
    }
}