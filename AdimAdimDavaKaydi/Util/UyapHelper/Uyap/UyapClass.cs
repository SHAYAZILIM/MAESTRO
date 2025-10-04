using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Util.Uyap
{



    [Serializable]
    [XmlType("alacakKalemi")]
    public class AlacakKalemi
    {
        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }


        [XmlAttribute("alacakKalemKod")]
        public string alacakKalemKod
        { get { return _alacakKalemKod; } set { _alacakKalemKod = value; } }


        [XmlAttribute("alacakKalemAdi")]
        public string alacakKalemAdi
        { get { return _alacakKalemAdi; } set { _alacakKalemAdi = value; } }

        [XmlAttribute("alacakKalemTutar")]
        public string alacakKalemTutar
        { get { return _alacakKalemTutar; } set { _alacakKalemTutar = value; } }
        
        [XmlAttribute("tutarTur")]
        public string tutarTur
        { get { return _tutarTur; } set { _tutarTur = value; } }
        
        [XmlAttribute("tutarAdi")]
        public string tutarAdi
        { get { return _tutarAdi; } set { _tutarAdi = value; } }

        [XmlAttribute("alacakKalemKodTuru")]
        public string alacakKalemKodTuru
        { get { return _alacakKalemKodTuru; } set { _alacakKalemKodTuru = value; } }

        ////Yeniden kaldýrýldý. MB //Yeniden eklendi. MB Hukuk ailesinde olmadýðýndan aþaðýdaki property kaldýrýldý. MB
        //[XmlAttribute("alacakKalemKodTip")]
        //public string alacakKalemKodTip
        //{ get { return _alacakKalemKodTip; } set { _alacakKalemKodTip = value; } }

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        ////Yeniden kaldýrýldý. MB //Yeniden eklendi. MB Hukuk ailesinde olmadýðýndan aþaðýdaki property kaldýrýldý. MB
        //[XmlAttribute("ilamliIlamsiz")]
        //public string ilamliIlamsiz
        //{ get { return _ilamliIlamsiz; } set { _ilamliIlamsiz = value; } }

       //Yeniden eklendi. MB //Hukuk ailesinde olmadýðýndan aþaðýdaki property kaldýrýldý. MB
        [XmlAttribute("alacakKalemKodAciklama")]
        public string alacakKalemKodAciklama
        { get { return _alacakKalemKodAciklama; } set { _alacakKalemKodAciklama = value; } }

        [XmlElement("ref")]
        public List<Ref> refler
        { get { return _refler; } set { _refler = value; } }

 
        //TODO : Eski programda yok . 

        //Hukuk ailesinde olmadýðýndan aþaðýdaki property kaldýrýldý. MB
        [XmlAttribute("alacakKalemIlkTutar")]
        public string alacakKalemIlkTutar
        { get { return _alacakKalemIlkTutar; } set { _alacakKalemIlkTutar = value; } }
       
        //[XmlAttribute("dovizKurCevrimi")]
        //public string dovizKurCevrimi
        //{ get { return _dovizKurCevrimi; } set { _dovizKurCevrimi = value; } }
        
        //[XmlAttribute("akdiFaiz")]
        //public string akdiFaiz
        //{ get { return _akdiFaiz; } set { _akdiFaiz = value; } }
       
        //[XmlAttribute("alacakKalemKodAciklama")]
        //public string alacakKalemKodAciklama
        //{ get { return _alacakKalemKodAciklama; } set { _alacakKalemKodAciklama = value; } }
        //*
        [XmlElement("faiz")]
        public List<Faiz> faizler
        { get { return _faizler; } set { _faizler = value; } }
        
        [XmlElement("taraf")]
        public List<Taraf> taraflar
        { get { return _taraflar; } set { _taraflar = value; } }

        //[XmlAttribute("alacakKalemTip")]
        //public string alacakKalemTip
        //{ get { return _alacakKalemTip; } set { _alacakKalemTip = value; } }

        private string _alacakKalemIlkTutar = string.Empty;
        private string _Id = string.Empty;
        private string _alacakKalemKod = string.Empty;
        private string _alacakKalemAdi = string.Empty;
        private string _alacakKalemTutar = string.Empty;
        private string _alacakKalemTip = string.Empty;
        private string _tutarTur = string.Empty;
        private string _tutarAdi = string.Empty;
        private string _dovizKurCevrimi = string.Empty;
        private string _akdiFaiz = string.Empty;
        private string _alacakKalemKodAciklama = string.Empty;
        private string _aciklama = string.Empty;
        private string _ilamliIlamsiz = string.Empty;
        private string _alacakKalemKodTuru = string.Empty;
        private string _alacakKalemKodTip = string.Empty; 
        private List<Taraf> _taraflar;  
        private List<Ref> _refler;  
        private List<Faiz> _faizler;

        //[XmlAttribute("sabitTaksitTarihi")]
      //  public DateTime sabitTaksitTarihi
       // { get { return _sabitTaksitTarihi; } set { _sabitTaksitTarihi = value; } }
  
    }

    [Serializable]
    [XmlType("faiz")]
    public class Faiz
    {
        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }
 
        [XmlAttribute("baslangicTarihi")]
        public string baslangicTarihi
        { get { return _baslangicTarihi; } set { _baslangicTarihi = value; } }
 
        [XmlAttribute("bitisTarihi")]
        public string bitisTarihi
        { get { return _bitisTarihi; } set { _bitisTarihi = value; } }
 
        [XmlAttribute("faizOran")]
        public decimal faizOran
        { get { return _faizOran; } set { _faizOran = value; } }
        
        [XmlAttribute("faizTutar")]
        public decimal faizTutar
        { get { return _faizTutar; } set { _faizTutar = value; } }
       
        [XmlAttribute("faizTutarTur")]
        public string faizTutarTur
        { get { return _faizTutarTur; } set { _faizTutarTur = value; } }
      
        [XmlAttribute("faizTutarTurAdi")]
        public string faizTutarTurAdi
        { get { return _faizTutarTurAdi; } set { _faizTutarTurAdi = value; } }

        [XmlAttribute("faizSureTip")]
        public string faizSureTip
        { get { return _faizSureTip; } set { _faizSureTip = value; } }
      
        [XmlAttribute("faizTipKod")]
        public string faizTipKod
        { get { return _faizTipKod; } set { _faizTipKod = value; } }
       
        [XmlAttribute("faizTipKodAciklama")]
        public string faizTipKodAciklama
        { get { return _faizTipKodAciklama; } set { _faizTipKodAciklama = value; } }

        private decimal _faizOran;
        private string _bitisTarihi;
        private string _baslangicTarihi;
        private string _Id; 
        private string _faizTipKod; 
        private string _faizTipKodAciklama;
        private decimal _faizTutar; 
        private string _faizTutarTur; 
        private string _faizTutarTurAdi; 
        private string _faizSureTip;

    }

    [Serializable]
    [XmlType("cek")]
    public class Cek
    {
        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }

        private string _Id;

        [XmlAttribute("islemlerBasladimi")]
        public string islemlerBasladimi 
        { get { return _islemlerBasladimi; } set { _islemlerBasladimi = value; } }

        private string _islemlerBasladimi = string.Empty; 

        [XmlAttribute("kocanNo")]
        public string kocanNo 
        { get { return _kocanNo; } set { _kocanNo = value; } }

        private string _kocanNo = string.Empty;

        [XmlAttribute("seriNo")]
        public string seriNo
        { get { return _seriNo; } set { _seriNo = value; } }

        private string _seriNo = string.Empty;

        [XmlAttribute("kesideTarihi")]
        public string kesideTarihi
        { get { return _kesideTarihi; } set { _kesideTarihi = value; } }

        private string _kesideTarihi = string.Empty;

        [XmlAttribute("kesideYeri")]
        public string kesideYeri
        { get { return _kesideYeri; } set { _kesideYeri = value; } }

        private string _kesideYeri = string.Empty;

        [XmlAttribute("tutar")]
        public string tutar
        { get { return _tutar; } set { _tutar = value; } }

        private string _tutar = string.Empty;

        [XmlAttribute("tutarTur")]
        public string tutarTur
        { get { return _tutarTur; } set { _tutarTur = value; } }

        private string _tutarTur = string.Empty;

        [XmlAttribute("tutarTurAciklama")]
        public string tutarTurAciklama
        { get { return _tutarTurAciklama; } set { _tutarTurAciklama = value; } }

        private string _tutarTurAciklama = string.Empty;

        [XmlAttribute("odemeYeri")]
        public string odemeYeri
        { get { return _odemeYeri; } set { _odemeYeri = value; } }

        private string _odemeYeri = string.Empty;

        [XmlAttribute("ibrazTarihi")]
        public string ibrazTarihi
        { get { return _ibrazTarihi; } set { _ibrazTarihi = value; } }

        private string _ibrazTarihi = string.Empty;

        [XmlAttribute("bankaID")]
        public string bankaID
        { get { return _bankaID; } set { _bankaID = value; } }

        private string _bankaID = string.Empty;

        [XmlAttribute("bankaSubeKod")]
        public string bankaSubeKod
        { get { return _bankaSubeKod; } set { _bankaSubeKod = value; } }

        private string _bankaSubeKod = string.Empty;

        [XmlAttribute("bankaAdi")]
        public string bankaAdi
        { get { return _bankaAdi; } set { _bankaAdi = value; } }

        private string _bankaAdi = string.Empty;

        [XmlAttribute("bankaSubeAdi")]
        public string bankaSubeAdi
        { get { return _bankaSubeAdi; } set { _bankaSubeAdi = value; } }

        private string _bankaSubeAdi = string.Empty;

        [XmlAttribute("bankaSubeIl")]
        public string bankaSubeIl
        { get { return _bankaSubeIl; } set { _bankaSubeIl = value; } }

        private string _bankaSubeIl = string.Empty;

        [XmlAttribute("bankaSubeIlce")]
        public string bankaSubeIlce
        { get { return _bankaSubeIlce; } set { _bankaSubeIlce = value; } }

        private string _bankaSubeIlce = string.Empty;

        [XmlAttribute("bankaSubeAdres")]
        public string bankaSubeAdres
        { get { return _bankaSubeAdres; } set { _bankaSubeAdres = value; } }

        private string _bankaSubeAdres = string.Empty;


        [XmlElement("alacakKalemi")]
        public List<AlacakKalemi> alacakKalemi
        { get { return _alacakKalemi; } set { _alacakKalemi = value; } }

        private List<AlacakKalemi> _alacakKalemi;

        [XmlElement("taraf")]
        public List<Taraf> taraflar
        { get { return _taraflar; } set { _taraflar = value; } }

        private List<Taraf> _taraflar;

        [XmlElement("ref")]
        public List<Ref> refler
        { get { return _refler; } set { _refler = value; } }

        private List<Ref> _refler;



    }

    [Serializable]
    [XmlType("senet")]
    public class Senet
    {
        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }

        private string _Id;

        [XmlAttribute("islemlerBasladimi")]
        public string islemlerBasladimi
        { get { return _islemlerBasladimi; } set { _islemlerBasladimi = value; } }

        private string _islemlerBasladimi;

        [XmlAttribute("tanzimTarihi")]
        public string tanzimTarihi
        { get { return _tanzimTarihi; } set { _tanzimTarihi = value; } }

        private string _tanzimTarihi;

        [XmlAttribute("belgeninTutari")]
        public string belgeninTutari
        { get { return _belgeninTutari; } set { _belgeninTutari = value; } }

        private string _belgeninTutari;

        [XmlAttribute("tutarTur")]
        public string tutarTur
        { get { return _tutarTur; } set { _tutarTur = value; } }

        private string _tutarTur;

        [XmlAttribute("tutarAdi")]
        public string tutarAdi
        { get { return _tutarAdi; } set { _tutarAdi = value; } }

        private string _tutarAdi;

        //Hukuk ailesinde olmadýðýndan kapatýldý. MB
        //[XmlAttribute("olmasiGrknPulDegeri")]
        //public string olmasiGrknPulDegeri
        //{ get { return _olmasiGrknPulDegeri; } set { _olmasiGrknPulDegeri = value; } }

        //private string _olmasiGrknPulDegeri;

        //Hukuk ailesinde olmadýðýndan kapatýldý. MB
        //[XmlAttribute("uzerindekiPulunDegeri")]
        //public string uzerindekiPulunDegeri
        //{ get { return _uzerindekiPulunDegeri; } set { _uzerindekiPulunDegeri = value; } }

        //private string _uzerindekiPulunDegeri;

        [XmlAttribute("odemeYeri")]
        public string odemeYeri
        { get { return _odemeYeri; } set { _odemeYeri = value; } }

        private string _odemeYeri;

        //Hukuk ailesinde olmadýðýndan kapatýldý. MB
        //[XmlAttribute("tanzimYeri")]
        //public string tanzimYeri
        //{ get { return _tanzimYeri; } set { _tanzimYeri = value; } }

        //private string _tanzimYeri;

        [XmlAttribute("vadeTarihi")]
        public string vadeTarihi
        { get { return _vadeTarihi; } set { _vadeTarihi = value; } }

        private string _vadeTarihi;

        [XmlElement("alacakKalemi")]
        public List<AlacakKalemi> alacakKalemi
        { get { return _alacakKalemi; } set { _alacakKalemi = value; } }

        private List<AlacakKalemi> _alacakKalemi;

        [XmlElement("taraf")]
        public List<Taraf> taraflar
        { get { return _taraflar; } set { _taraflar = value; } }

        private List<Taraf> _taraflar;

        [XmlElement("ref")]
        public List<Ref> refler
        { get { return _refler; } set { _refler = value; } }

        private List<Ref> _refler;


    }

    [Serializable]
    [XmlType("police")]
    public class Police
    {
        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }

        private string _Id;

        [XmlAttribute("islemlerBasladimi")]
        public string islemlerBasladimi
        { get { return _islemlerBasladimi; } set { _islemlerBasladimi = value; } }

        private string _islemlerBasladimi;

        [XmlAttribute("kesideTarihi")]
        public string kesideTarihi
        { get { return _kesideTarihi; } set { _kesideTarihi = value; } }

        private string _kesideTarihi;

        [XmlAttribute("belgeninTutari")]
        public string belgeninTutari
        { get { return _belgeninTutari; } set { _belgeninTutari = value; } }

        private string _belgeninTutari;

        [XmlAttribute("tutarTur")]
        public string tutarTur
        { get { return _tutarTur; } set { _tutarTur = value; } }

        private string _tutarTur;

        [XmlAttribute("tutarAdi")]
        public string tutarAdi
        { get { return _tutarAdi; } set { _tutarAdi = value; } }

        private string _tutarAdi;

        [XmlAttribute("vadeTarihi")]
        public string vadeTarihi
        { get { return _vadeTarihi; } set { _vadeTarihi = value; } }

        private string _vadeTarihi;

        //Hukuk ailesinde olmadýðýndan kapatýldý. MB
        //[XmlAttribute("odemeYeri")]
        //public string odemeYeri
        //{ get { return _odemeYeri; } set { _odemeYeri = value; } }

        //private string _odemeYeri;

        [XmlAttribute("kesideYeri")]
        public string kesideYeri
        { get { return _kesideYeri; } set { _kesideYeri = value; } }

        private string _kesideYeri;

        [XmlAttribute("olmasiGrknPulDegeri")]
        public string olmasiGrknPulDegeri
        { get { return _olmasiGrknPulDegeri; } set { _olmasiGrknPulDegeri = value; } }

        private string _olmasiGrknPulDegeri;

        [XmlAttribute("uzerindekiPulunDegeri")]
        public string uzerindekiPulunDegeri
        { get { return _uzerindekiPulunDegeri; } set { _uzerindekiPulunDegeri = value; } }

        private string _uzerindekiPulunDegeri;

        [XmlAttribute("lehtarAdSoyad")]
        public string lehtarAdSoyad
        { get { return _lehtarAdSoyad; } set { _lehtarAdSoyad = value; } }

        private string _lehtarAdSoyad;

        [XmlAttribute("kesideciAdSoyad")]
        public string kesideciAdSoyad
        { get { return _kesideciAdSoyad; } set { _kesideciAdSoyad = value; } }

        private string _kesideciAdSoyad;

        [XmlAttribute("odeyecekKisiAdSoyad")]
        public string odeyecekKisiAdSoyad
        { get { return _odeyecekKisiAdSoyad; } set { _odeyecekKisiAdSoyad = value; } }

        private string _odeyecekKisiAdSoyad;


        [XmlElement("alacakKalemi")]
        public List<AlacakKalemi> alacakKalemi
        { get { return _alacakKalemi; } set { _alacakKalemi = value; } }

        private List<AlacakKalemi> _alacakKalemi;

        [XmlElement("taraf")]
        public List<Taraf> taraflar
        { get { return _taraflar; } set { _taraflar = value; } }

        private List<Taraf> _taraflar;

        [XmlElement("ref")]
        public List<Ref> refler
        { get { return _refler; } set { _refler = value; } }

        private List<Ref> _refler;

    }

    [Serializable]
    [XmlType("kontrat")]
    public class Kontrat
    {
        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }

        private string _Id = string.Empty;

        [XmlAttribute("sozlesmeSozluBelgeli")]
        public string sozlesmeSozluBelgeli
        { get { return _sozlesmeSozluBelgeli; } set { _sozlesmeSozluBelgeli = value; } }

        private string _sozlesmeSozluBelgeli = string.Empty;

        [XmlAttribute("belgeninTutari")]
        public string belgeninTutari
        { get { return _belgeninTutari; } set { _belgeninTutari = value; } }

        private string _belgeninTutari = string.Empty;

        [XmlAttribute("tutarTur")]
        public string tutarTur
        { get { return _tutarTur; } set { _tutarTur = value; } }

        private string _tutarTur = string.Empty;

        [XmlAttribute("gecerlilikBaslangicTarihi")]
        public string gecerlilikBaslangicTarihi
        { get { return _; } set { _ = value; } }

        private string _ = string.Empty;

        [XmlAttribute("gecerlilikSonlanmaTarihi")]
        public string gecerlilikSonlanmaTarihi
        { get { return _gecerlilikSonlanmaTarihi; } set { _gecerlilikSonlanmaTarihi = value; } }

        private string _gecerlilikSonlanmaTarihi = string.Empty;

        [XmlAttribute("gecerliOlduguSure")]
        public string gecerliOlduguSure
        { get { return _gecerliOlduguSure; } set { _gecerliOlduguSure = value; } }

        private string _gecerliOlduguSure = string.Empty;

        [XmlAttribute("uzerindekiPulDegeri")]
        public string uzerindekiPulDegeri
        { get { return _uzerindekiPulDegeri; } set { _uzerindekiPulDegeri = value; } }

        private string _uzerindekiPulDegeri = string.Empty;

        [XmlAttribute("olmasiGerekenPulDegeri")]
        public string olmasiGerekenPulDegeri
        { get { return _olmasiGerekenPulDegeri; } set { _olmasiGerekenPulDegeri = value; } }

        private string _olmasiGerekenPulDegeri = string.Empty;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        private string _aciklama = string.Empty;

        [XmlAttribute("belgeIslemleriBaslatiliyormu")]
        public string belgeIslemeleriBaslatiliyormu
        { get { return _belgeIslemeleriBaslatiliyormu; } set { _belgeIslemeleriBaslatiliyormu = value; } }

        private string _belgeIslemeleriBaslatiliyormu = string.Empty;

        [XmlAttribute("hazirlanisTarihi")]
        public string hazirlanisTarihi
        { get { return _hazirlanisTarihi; } set { _hazirlanisTarihi = value; } }

        private string _hazirlanisTarihi = string.Empty;

        [XmlAttribute("tutarTurAciklama")]
        public string tutarTurAciklama
        { get { return _tutarTurAciklama; } set { _tutarTurAciklama = value; } }

        private string _tutarTurAciklama = string.Empty;

        [XmlAttribute("adresAciklama")]
        public string adresAciklama
        { get { return _adresAciklama; } set { _adresAciklama = value; } }

        private string _adresAciklama = string.Empty;


        [XmlElement("alacakKalemi")]
        public List<AlacakKalemi> alacakKalemi
        { get { return _alacakKalemi; } set { _alacakKalemi = value; } }

        private List<AlacakKalemi> _alacakKalemi;

        [XmlElement("taraf")]
        public List<Taraf> taraflar
        { get { return _taraflar; } set { _taraflar = value; } }

        private List<Taraf> _taraflar;

        [XmlElement("ref")]
        public List<Ref> refler
        { get { return _refler; } set { _refler = value; } }

        private List<Ref> _refler;

    }

    [Serializable]
    [XmlType("kontratKefil")]
    public class KontratKefil
    {
        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }

        private string _Id;


        [XmlElement("kontrat")]
        public Kontrat kontrat
        { get { return _kontrat; } set { _kontrat = value; } }

        private Kontrat _kontrat;

        [XmlElement("adres")]
        public KontratAlacakliAdres adres
        { get { return _adres; } set { _adres = value; } }

        private KontratAlacakliAdres _adres;

        [XmlElement("ref")]
        public Ref MyRef
        { get { return _MyRef; } set { _MyRef = value; } }

        private Ref _MyRef;

    }

    [Serializable]
    [XmlType("digerAlacak")]
    public class DigerAlacak
    {
        [XmlAttribute("id")]
        public string Id
        { get { return _Id; } set { _Id = value; } }

        private string _Id = string.Empty;

        [XmlAttribute("digerAlacakAciklama")]
        public string digerAlacakAciklama
        { get { return _digerAlacakAciklama; } set { _digerAlacakAciklama = value; } }

        private string _digerAlacakAciklama = string.Empty;

        [XmlAttribute("tarih")]
        public string tarih
        { get { return _tarih; } set { _tarih = value; } }

        private string _tarih = string.Empty;

        [XmlAttribute("tutar")]
        public string tutar
        { get { return _tutar; } set { _tutar = value; } }

        private string _tutar = string.Empty;

        //Hukuk ailesinde olmadýðýndan aþaðýdaki property kaldýrýldý. MB
        //[XmlAttribute("alacakNo")]
        //public string alacakNo
        //{ get { return _alacakNo; } set { _alacakNo = value; } }

        //private string _alacakNo = string.Empty;

        [XmlAttribute("tutarTur")]
        public string tutarTur
        { get { return _tutarTur; } set { _tutarTur = value; } }

        private string _tutarTur = string.Empty;

        [XmlAttribute("tutarAdi")]
        public string tutarAdi
        { get { return _tutarAdi; } set { _tutarAdi = value; } }

        private string _tutarAdi = string.Empty;


        [XmlElement("alacakKalemi")]
        public List<AlacakKalemi> alacakKalemi
        { get { return _alacakKalemi; } set { _alacakKalemi = value; } }

        private List<AlacakKalemi> _alacakKalemi;

        [XmlElement("taraf")]
        public List<Taraf> taraflar
        { get { return _taraflar; } set { _taraflar = value; } }

        private List<Taraf> _taraflar;

        [XmlElement("ref")]
        public List<Ref> refler
        { get { return _refler; } set { _refler = value; } }

        private List<Ref> _refler;

    }

    [Serializable]
    [XmlType("adres")]    
    public class Adres
    {
        
        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        [XmlAttribute("il")]
        public string il
        { get { return _il; } set { _il = value; } }

        [XmlAttribute("ilce")]
        public string ilce
        { get { return _ilce; } set { _ilce = value; } }

        [XmlAttribute("ilKodu")]
        public string ilKodu
        { get { return _ilKodu; } set { _ilKodu = value; } }

        [XmlAttribute("ilceKodu")]
        public string ilceKodu
        { get { return _ilceKodu; } set { _ilceKodu = value; } }

        [XmlAttribute("adresTuru")]
        public string adresTuru { get; set; }

        [XmlAttribute("adresTuruAciklama")]
        public string adresTuruAciklama
        { get { return _adresTuruAciklama; } set { _adresTuruAciklama = value; } }

        [XmlAttribute("postaKodu")]
        public string postaKodu
        { get { return _postaKodu; } set { _postaKodu = value; } }

        [XmlAttribute("adres")]
        public string adres
        { get { return _adres; } set { _adres = value; } }

        [XmlAttribute("telefon")]
        public string telefon
        { get { return _telefon; } set { _telefon = value; } }

        //todo : eSKÝ ÇPROGRAM ÇIKTILARINDA ÇIKMIYOR.
        //[XmlAttribute("adresTuru")]
        //public string adresTuru
        //{ get { return _adresTuru; } set { _adresTuru = value; } }

        [XmlAttribute("cepTelefon")]
        public string cepTelefon
        { get { return _cepTelefon; } set { _cepTelefon = value; } }

        [XmlAttribute("fax")]
        public string fax
        { get { return _fax; } set { _fax = value; } }

        [XmlAttribute("elektronikPostaAdresi")]
        public string elektronikPostaAdresi
        { get { return _elektronikPostaAdresi; } set { _elektronikPostaAdresi = value; } }

        private string _adresTuru = string.Empty;
        private string _id = string.Empty;
        private string _adresTuruAciklama = string.Empty;
        private string _ilKodu = string.Empty;
        private string _il = string.Empty;
        private string _ilce = string.Empty;
        private string _ilceKodu = string.Empty;
        private string _postaKodu = string.Empty;
        private string _adres = string.Empty;
        private string _telefon = string.Empty;
        private string _cepTelefon = string.Empty;
        private string _fax = string.Empty;
        private string _elektronikPostaAdresi = string.Empty;

    }

    [Serializable]
    [XmlType("KontratAlacakliAdres")]
    public class KontratAlacakliAdres
    {
        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        private string _id = string.Empty;
    }

    [Serializable]
    [XmlType("kisiTumBilgileri")]
    public class KisiTumBilgileri
    {
        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        private string _id = string.Empty;

        [XmlAttribute("adi")]
        public string adi
        { get { return _adi; } set { _adi = value; } }

        private string _adi = string.Empty;

        [XmlAttribute("soyadi")]
        public string soyadi
        { get { return _soyadi; } set { _soyadi = value; } }

        private string _soyadi = string.Empty;

        [XmlAttribute("oncekiSoyadi")]
        public string oncekiSoyadi
        { get { return _oncekiSoyadi; } set { _oncekiSoyadi = value; } }

        private string _oncekiSoyadi = string.Empty;

        [XmlAttribute("babaAdi")]
        public string babaAdi
        { get { return _babaAdi; } set { _babaAdi = value; } }

        private string _babaAdi = string.Empty;

        [XmlAttribute("anaAdi")]
        public string anaAdi
        { get { return _anaAdi; } set { _anaAdi = value; } }

        private string _anaAdi = string.Empty;

        [XmlAttribute("dogumTarihi")]
        public string dogumTarihi
        { get { return _dogumTarihi; } set { _dogumTarihi = value; } }

        private string _dogumTarihi = string.Empty;

        [XmlAttribute("tcKimlikNo")]
        public string tcKimlikNo
        { get { return _tcKimlikNo; } set { _tcKimlikNo = value; } }

        private string _tcKimlikNo = string.Empty;

        [XmlAttribute("cinsiyeti")]
        public string cinsiyeti
        { 
           get 
           {
               if (_cinsiyeti.Length == 0)
                   _cinsiyeti = "E"; 
               return _cinsiyeti;            
           } 
            set { _cinsiyeti = value; } }

        private string _cinsiyeti;

        [XmlAttribute("dogumYeri")]
        public string dogumYeri
        { get { return _dogumYeri; } set { _dogumYeri = value; } }

        private string _dogumYeri = string.Empty;

        [XmlAttribute("nufusaKayitIlKodu")]
        public string nufusaKayitIlKodu
        { get { return _nufusaKayitIlKodu; } set { _nufusaKayitIlKodu = value; } }

        private string _nufusaKayitIlKodu = string.Empty;

        [XmlAttribute("nufusaKayitIlceKodu")]
        public string nufusaKayitIlceKodu
        { get { return _nufusaKayitIlceKodu; } set { _nufusaKayitIlceKodu = value; } }

        private string _nufusaKayitIlceKodu = string.Empty;

        [XmlAttribute("mahKoy")]
        public string mahKoy
        { get { return _mahKoy; } set { _mahKoy = value; } }

        private string _mahKoy = string.Empty;

        [XmlAttribute("ciltNo")]
        public string ciltNo
        { get { return _ciltNo; } set { _ciltNo = value; } }

        private string _ciltNo = string.Empty;

        [XmlAttribute("aileSiraNo")]
        public string aileSiraNo
        { get { return _aileSiraNo; } set { _aileSiraNo = value; } }

        private string _aileSiraNo = string.Empty;

        [XmlAttribute("siraNo")]
        public string siraNo
        { get { return _siraNo; } set { _siraNo = value; } }

        private string _siraNo = string.Empty;

        [XmlAttribute("cuzdanSeriNo")]
        public string cuzdanSeriNo
        { get { return _cuzdanSeriNo; } set { _cuzdanSeriNo = value; } }

        private string _cuzdanSeriNo = string.Empty;

        [XmlAttribute("cuzdanNo")]
        public string cuzdanNo
        { get { return _cuzdanNo; } set { _cuzdanNo = value; } }

        private string _cuzdanNo = string.Empty;

        [XmlAttribute("kayitNo")]
        public string kayitNo
        { get { return _kayitNo; } set { _kayitNo = value; } }

        private string _kayitNo = string.Empty;

        [XmlAttribute("verildigiTarih")]
        public string verildigiTarih
        { get { return _verildigiTarih; } set { _verildigiTarih = value; } }

        private string _verildigiTarih = string.Empty;

        [XmlAttribute("verildigiIlKodu")]
        public string verildigiIlKodu
        { get { return _verildigiIlKodu; } set { _verildigiIlKodu = value; } }

        private string _verildigiIlKodu = string.Empty;

        [XmlAttribute("verildigiIlceKodu")]
        public string verildigiIlceKodu
        { get { return _verildigiIlceKodu; } set { _verildigiIlceKodu = value; } }

        private string _verildigiIlceKodu = string.Empty;

        [XmlAttribute("verilisNedeni")]
        public string verilisNedeni
        { get { return _verilisNedeni; } set { _verilisNedeni = value; } }

        private string _verilisNedeni = string.Empty;

        [XmlAttribute("ybnNfsKayitliOldgYer")]
        public string ybnNfsKayitliOldgYer
        { get { return _ybnNfsKayitliOldgYer; } set { _ybnNfsKayitliOldgYer = value; } }

        private string _ybnNfsKayitliOldgYer = string.Empty;

        [XmlAttribute("verildigiIlAdi")]
        public string verildigiIlAdi
        { get { return _verildigiIlAdi; } set { _verildigiIlAdi = value; } }

        private string _verildigiIlAdi = string.Empty;

        [XmlAttribute("verildigiIlceAdi")]
        public string verildigiIlceAdi
        { get { return _verildigiIlceAdi; } set { _verildigiIlceAdi = value; } }

        private string _verildigiIlceAdi = string.Empty;

        [XmlAttribute("vergiNo")]
        public string vergiNo
        { get { return _vergiNo; } set { _vergiNo = value; } }

        private string _vergiNo = string.Empty;

        

    }

    [Serializable]
    [XmlType("kurum")]
    public class Kurum
    {
        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        private string _id = string.Empty;

        [XmlAttribute("kurumAdi")]
        public string kurumAdi
        { get { return _kurumAdi; } set { _kurumAdi = value; } }

        private string _kurumAdi = string.Empty;

        [XmlAttribute("vergiNo")]
        public string vergiNo
        { get { return _vergiNo; } set { _vergiNo = value; } }

        private string _vergiNo = string.Empty;

        [XmlAttribute("vergiDairesi")]
        public string vergiDairesi
        { get { return _vergiDairesi; } set { _vergiDairesi = value; } }

        private string _vergiDairesi = string.Empty;

        [XmlAttribute("ticaretSicilNo")]
        public string ticariSicilNo
        { get { return _ticariSicilNo; } set { _ticariSicilNo = value; } }

        private string _ticariSicilNo = string.Empty;

        [XmlAttribute("ticaretSicilNoVerildigiYer")]
        public string ticaretSicilNoVerildigiYer
        { get { return _ticaretSicilNoVerildigiYer; } set { _ticaretSicilNoVerildigiYer = value; } }

        private string _ticaretSicilNoVerildigiYer = string.Empty;

        [XmlAttribute("kamuOzel")]
        public string kamuOzel
        { get { return _kamuOzel; } set { _kamuOzel = value; } }

        private string _kamuOzel = string.Empty;

        [XmlAttribute("sskIsyeriSicilNo")]
        public string sskIsyeriSicilNo
        { get { return _sskIsyeriSicilNo; } set { _sskIsyeriSicilNo = value; } }

        private string _sskIsyeriSicilNo = string.Empty;

        //Hukuk ailesinde olmadðýndan aþaðýdaki property kaldýrýldý. MB
        //[XmlAttribute("harcDurumu")]
        //public string harcDurumu
        //{ get { return _harcDurumu; } set { _harcDurumu = value; } }

        //private string _harcDurumu = string.Empty;

    }

    [Serializable]
    [XmlType("kisiKurumBilgileri")]
    public class KisiKurumBilgileri
    {
        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        private string _id = string.Empty;

        [XmlAttribute("ad")]
        public string ad
        { get { return _ad; } set { _ad = value; } }

        private string _ad = string.Empty;


        [XmlElement("kurum")]
        public Kurum kurum
        { get { return _kurum; } set { _kurum = value; } }

        private Kurum _kurum;

        [XmlElement("kisiTumBilgileri")]
        public KisiTumBilgileri kisiTumBilgileri
        { get { return _kisiTumBilgileri; } set { _kisiTumBilgileri = value; } }

        private KisiTumBilgileri _kisiTumBilgileri;

        [XmlElement("Ref")]
        public Ref Ref
        { get { return _Ref; } set { _Ref = value; } }

        private Ref _Ref;

        [XmlElement("adres")]
        public Adres adres
        { get { return _adres; } set { _adres = value; } }

        private Adres _adres;


    }

    [Serializable]
    [XmlType("rolTur")]
    public class RolTur
    {
        [XmlAttribute("rolID")]
        public string rolID
        { get { return _rolID; } set { _rolID = value; } }

        private string _rolID = string.Empty;

        [XmlAttribute("Rol")]
        public string Rol
        { get { return _Rol; } set { _Rol = value; } }

        private string _Rol = string.Empty;

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
    [XmlType("VekilKisi")]
    public class VekilKisi
    {
        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        private string _id = string.Empty;


        [XmlElement("vekil")]
        public Vekil vekil
        { get { return _vekil; } set { _vekil = value; } }

        private Vekil _vekil;

        [XmlElement("kisiTumBilgileri")]
        public KisiTumBilgileri kisiTumBilgileri
        { get { return _kisiTumBilgileri; } set { _kisiTumBilgileri = value; } }

        private KisiTumBilgileri _kisiTumBilgileri;

        [XmlElement("adres")]
        public Adres adres
        { get { return _adres; } set { _adres = value; } }

        private Adres _adres;


    }

    [Serializable]
    [XmlType("vekil")]
    public class Vekil
    {
        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        [XmlAttribute("baroNo")]
        public string baroNo
        { get { return _baroNo; } set { _baroNo = value; } }

        [XmlAttribute("tbbNo")]
        public string tbbNo
        { get { return _tbbNo; } set { _tbbNo = value; } }

        [XmlAttribute("avukatlikBuroAdi")]
        public string avukatlikBuroAdi
        { get { return _avukatlikBuroAdi; } set { _avukatlikBuroAdi = value; } }

        [XmlAttribute("tcKimlikNo")]
        public string tcKimlikNo
        { get { return _tcKimlikNo; } set { _tcKimlikNo = value; } }

        [XmlAttribute("adi")]
        public string adi
        { get { return _adi; } set { _adi = value; } }

        [XmlAttribute("soyadi")]
        public string soyadi
        { get { return _soyadi; } set { _soyadi = value; } }

        [XmlAttribute("vekilTipi")]
        public string vekilTipi
        { get { return _vekilTipi; } set { _vekilTipi = value; } }

        [XmlAttribute("kapanmaNedeni")]
        public string kapanmaNedeni
        { get { return _kapanmaNedeni; } set { _kapanmaNedeni = value; } }

        [XmlAttribute("kurumAvukatiMi")]
        public string kurumAvikatiMi
        { get { return _kurumAvikatiMi; } set { _kurumAvikatiMi = value; } }

        [XmlAttribute("vergiNo")]
        public string vergiNo
        { get { return _vergiNo; } set { _vergiNo = value; } }
 
        [XmlAttribute("sigortaliMi")]
        public string sigortaliMi
        { get { return _sigortaliMi; } set { _sigortaliMi = value; } }
        
        [XmlAttribute("borcluVekiliMi")]
        public string borcluVekilMi
        { get { return _borcluVekilMi; } set { _borcluVekilMi = value; } }

        private string _id = string.Empty;
        private string _baroNo = string.Empty;
        private string _vergiNo = string.Empty;
        private string _tbbNo = string.Empty;
        private string _avukatlikBuroAdi = string.Empty;
        private string _tcKimlikNo = string.Empty;
        private string _adi = string.Empty;
        private string _soyadi = string.Empty;
        private string _vekilTipi = string.Empty;
        private string _bakanlikDosyaNo = string.Empty;
        private string _kapanmaNedeni = "0";
        private string _kurumAvikatiMi = string.Empty;
        private string _sigortaliMi = string.Empty;
        private string _borcluVekilMi = string.Empty;

        //TODO: ESKÝ PROGRAMDA YOK
        //[XmlAttribute("bakanlikDosyaNo")]
        //public string bakanlikDosyaNo
        //{ get { return _bakanlikDosyaNo; } set { _bakanlikDosyaNo = value; } }
    }

    [Serializable]
    [XmlType("ilam")]
    public class Ilam
    {
        private string _ilamTarihi = string.Empty;
        private string _id = string.Empty;
        private string _ilamKararNoYil = string.Empty;
        private string _ilamKararSira="1";
        private string _tcKimlikNo = string.Empty;
        private string _ilamDosyaNoYil = string.Empty;
        private string _ilamDosyaSira = string.Empty;
        private string _ilamAciklama = string.Empty;
        private string _ilamiVerenMahkeme = string.Empty;
        private string _davaAcilisTarihi = string.Empty;
        private string _kesifTarihi = string.Empty;
        private string _kesinlesmeTarih = string.Empty;
        private string _ilamKurumTip="0";
        private string _ilamKurumAd = string.Empty;
        private List<ParaylaOlculemeyenAlacak> _paraylaOlculemeyenAlacak;
        private List<AlacakKalemi> _alacakKalemi;
        private Teminat _teminat;

        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        [XmlAttribute("ilamDosyaNoYil")]
        public string ilamDosyaNoYil
        { get { return _ilamDosyaNoYil; } set { _ilamDosyaNoYil = value; } }

        [XmlAttribute("ilamDosyaSira")]
        public string ilamDosyaSira
        { get { return _ilamDosyaSira; } set { _ilamDosyaSira = value; } }

        [XmlAttribute("ilamKurumAd")]
        public string ilamKurumAd
        { get { return _ilamKurumAd; } set { _ilamKurumAd = value; } }

        [XmlAttribute("ilamTarihi")]
        public string ilamTarihi
        { get { return _ilamTarihi; } set { _ilamTarihi = value; } }

        [XmlAttribute("ilamKurumTip")]
        public string ilamKurumTip
        { get { return _ilamKurumTip; } set { _ilamKurumTip = value; } }
       
        [XmlAttribute("kesinlesmeTarih")]
        public string kesinlesmeTarih
        { get { return _kesinlesmeTarih; } set { _kesinlesmeTarih = value; } }

        [XmlAttribute("davaAcilisTarih")]
        public string davaAcilisTarihi
        { get { return _davaAcilisTarihi; } set { _davaAcilisTarihi = value; } }

        [XmlAttribute("ilamKararNoYil")]
        public string ilamKararNoYil
        { get { return _ilamKararNoYil; } set { _ilamKararNoYil = value; } }

        [XmlAttribute("ilamKararSira")]
        public string ilamKararSira
        { get { return _ilamKararSira; } set { _ilamKararSira = value; } }
       
        [XmlAttribute("ilamAciklama")]
        public string ilamAciklama
        { get { return _ilamAciklama; } set { _ilamAciklama = value; } }

        [XmlAttribute("kesifTarih")]
        public string kesifTarihi
        { get { return _kesifTarihi; } set { _kesifTarihi = value; } }

        [XmlAttribute("ilamiVerenMahkeme")]
        public string ilamiVerenMahkeme
        { get { return _ilamiVerenMahkeme; } set { _ilamiVerenMahkeme = value; } }

        [XmlAttribute("tcKimlikNo")]
        public string tcKimlikNo
        { get { return _tcKimlikNo; } set { _tcKimlikNo = value; } }
  
        [XmlElement("paraylaOlculemeyenAlacak")]
        public List<ParaylaOlculemeyenAlacak> paraylaOlculemeyenAlacak
        { get { return _paraylaOlculemeyenAlacak; } set { _paraylaOlculemeyenAlacak = value; } }

        [XmlElement("alacakKalemi")]
        public List<AlacakKalemi> alacakKalemi
        { get { return _alacakKalemi; } set { _alacakKalemi = value; } }

        [XmlElement("teminat")]
        public Teminat teminat
        { get { return _teminat; } set { _teminat = value; } } 
    }

    [Serializable]
    [XmlType("teminat")]
    public class Teminat
    {
        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        private string _id = string.Empty;

        [XmlAttribute("teminatTutar")]
        public decimal teminatTutar
        { get { return _teminatTutar; } set { _teminatTutar = value; } }

        private decimal _teminatTutar;

        [XmlAttribute("ilamAciklama")]
        public string ilamAciklama
        { get { return _ilamAciklama; } set { _ilamAciklama = value; } }

        private string _ilamAciklama = string.Empty;

        [XmlAttribute("tahsilatMakbuzNo")]
        public string tahsilatMakbuzNo
        { get { return _tahsilatMakbuzNo; } set { _tahsilatMakbuzNo = value; } }

        private string _tahsilatMakbuzNo = string.Empty;

        [XmlAttribute("tahsilatMakbuzTarihi")]
        public DateTime tahsilatMakbuzTarihi
        { get { return _tahsilatMakbuzTarihi; } set { _tahsilatMakbuzTarihi = value; } }

        private DateTime _tahsilatMakbuzTarihi;

        [XmlAttribute("teminatNo")]
        public string teminatNo
        { get { return _teminatNo; } set { _teminatNo = value; } }

        private string _teminatNo = string.Empty;

        [XmlAttribute("teminatiVerenKurum")]
        public string teminatiVerenKurum
        { get { return _teminatiVerenKurum; } set { _teminatiVerenKurum = value; } }

        private string _teminatiVerenKurum = string.Empty;

        [XmlAttribute("teminatTipi")]
        public int teminatTipi
        { get { return _teminatTipi; } set { _teminatTipi = value; } }

        private int _teminatTipi;

        [XmlAttribute("teminatNedeni")]
        public string teminatNedeni
        { get { return _teminatNedeni; } set { _teminatNedeni = value; } }

        private string _teminatNedeni = string.Empty;

    }

    [Serializable]
    [XmlType("paraylaOlculemeyenAlacak")]
    public class ParaylaOlculemeyenAlacak
    {
        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        private string _id = string.Empty;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        private string _aciklama = string.Empty;

    }
    /*
    [Serializable()]
    [XmlType("evrak")]
    public class Evrak
    {
        [XmlAttribute("fileName")]
        public string fileName
        { get { return _fileName; } set { _fileName = value; } }

        private string _fileName = string.Empty;

        [XmlAttribute("mimeType")]
        public string mimeType
        { get { return _mimeType; } set { _mimeType = value; } }

        private string _mimeType = string.Empty;


        
        public byte[] Data
        { get { return _Data; } set { _Data = value; } }

        private byte[] _Data;
        

        [XmlElement("evrak")]
        public Evrak evrak
        { get { return _evrak; } set { _evrak = value; } }

        private Evrak _evrak;


    }
    */
    [Serializable]
    [XmlType("ref")]
    public class Ref
    {
        [XmlAttribute("to")]
        public string to
        { get { return _to; } set { _to = value; } }

        private string _to;

        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        private string _id;

    }

}
