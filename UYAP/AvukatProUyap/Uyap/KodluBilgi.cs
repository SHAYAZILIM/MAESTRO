using System;
using System.Collections.Generic;

using System.Xml.Serialization;

namespace AdimAdimDavaKaydi.UyapClass
{
    [Serializable]
    [XmlType("adresTuru")]
    public class adresTuru
    {
        private string _aciklama;

        private string _kod;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        [XmlAttribute("kod")]
        public string kod
        { get { return _kod; } set { _kod = value; } }
    }

    [Serializable]
    [XmlType("alacakKalemKodlar")]
    public class alacakKalemKodlar
    {
        private int _alacakKalemId;

        private string _alacakKalemKod;

        private string _alacakKalemKodAciklama;

        private string _alacakKalemKodTip;

        private string _alacakKalemKodTuru;

        private string _DovizAdi;

        private string _DovizTuru;

        private bool _foydenMi;

        private int _foyId;

        private int _ilamId;

        private string _ilamliIlamsiz;

        private string _Miktar;

        private int id;

        public int AlacakKalemID
        {
            get { return _alacakKalemId; }
            set { _alacakKalemId = value; }
        }

        [XmlAttribute("alacakKalemKod")]
        public string alacakKalemKod
        { get { return _alacakKalemKod; } set { _alacakKalemKod = value; } }

        [XmlAttribute("alacakKalemKodAciklama")]
        public string alacakKalemKodAciklama
        { get { return _alacakKalemKodAciklama; } set { _alacakKalemKodAciklama = value; } }

        [XmlAttribute("alacakKalemKodTip")]
        public string alacakKalemKodTip
        { get { return _alacakKalemKodTip; } set { _alacakKalemKodTip = value; } }

        [XmlAttribute("alacakKalemKodTuru")]
        public string alacakKalemKodTuru
        { get { return _alacakKalemKodTuru; } set { _alacakKalemKodTuru = value; } }

        public string DovizAdi
        { get { return _DovizAdi; } set { _DovizAdi = value; } }

        public string DovizTuru
        { get { return _DovizTuru; } set { _DovizTuru = value; } }

        public bool FoydenMi
        {
            get { return _foydenMi; }
            set { _foydenMi = value; }
        }

        public int FoyID
        {
            get { return _foyId; }
            set { _foyId = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int IlamID
        {
            get { return _ilamId; }
            set { _ilamId = value; }
        }

        [XmlAttribute("ilamliIlamsiz")]
        public string ilamliIlamsiz
        { get { return _ilamliIlamsiz; } set { _ilamliIlamsiz = value; } }

        public string Miktar
        { get { return _Miktar; } set { _Miktar = value; } }
    }

    [Serializable]
    public class data
    {
        private kodlubilgiGrubu _kodluBilgiGrup;

        [XmlElement("kodlubilgiGrubu")]
        public kodlubilgiGrubu kodluBilgiGrup
        { get { return _kodluBilgiGrup; } set { _kodluBilgiGrup = value; } }
    }

    [Serializable]
    [XmlType("faizGenel")]
    public class faizGenel
    {
        private string _faizGenelKod;

        private string _faizOran;

        private string _faizTipKod;

        private DateTime _tarih;

        [XmlAttribute("faizGenelKod")]
        public string faizGenelKod
        { get { return _faizGenelKod; } set { _faizGenelKod = value; } }

        [XmlAttribute("faizOran")]
        public string faizOran
        { get { return _faizOran; } set { _faizOran = value; } }

        [XmlAttribute("faizTipKod")]
        public string faizTipKod
        { get { return _faizTipKod; } set { _faizTipKod = value; } }

        [XmlAttribute("tarih")]
        public DateTime tarih
        { get { return _tarih; } set { _tarih = value; } }
    }

    [Serializable]
    [XmlType("faizIsmi")]
    public class faizIsmi
    {
        private string _aciklama;

        private string _kod;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        [XmlAttribute("kod")]
        public string kod
        { get { return _kod; } set { _kod = value; } }
    }

    [Serializable]
    [XmlType("icraKodluBilgi")]
    public class icraKodluBilgi
    {
        private string _aciklama;

        private string _anaKod;

        private DateTime _baslangicTarihi;

        private DateTime _bitisTarihi;

        private string _tutar;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        [XmlAttribute("anaKod")]
        public string anaKod
        { get { return _anaKod; } set { _anaKod = value; } }

        [XmlAttribute("baslangicTarihi")]
        public DateTime baslangicTarihi
        { get { return _baslangicTarihi; } set { _baslangicTarihi = value; } }

        [XmlAttribute("bitisTarihi")]
        public DateTime bitisTarihi
        { get { return _bitisTarihi; } set { _bitisTarihi = value; } }

        [XmlAttribute("tutar")]
        public string tutar
        { get { return _tutar; } set { _tutar = value; } }
    }

    [Serializable]
    [XmlType("il")]
    public class il
    {
        private string _aciklama;

        private string _kod;

        private List<ilce> _Myilce;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        [XmlAttribute("kod")]
        public string kod
        { get { return _kod; } set { _kod = value; } }

        [XmlElement("ilce")]
        public List<ilce> Myilce
        { get { return _Myilce; } set { _Myilce = value; } }
    }

    [Serializable]
    [XmlType("ilce")]
    public class ilce
    {
        private string _aciklama;

        private string _kod;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        [XmlAttribute("kod")]
        public string kod
        { get { return _kod; } set { _kod = value; } }
    }

    [XmlType("kodlubilgiGrubu")]
    public class kodlubilgiGrubu
    {
        private List<adresTuru> _AdresTur;

        private List<alacakKalemKodlar> _AlacakKalemKodlar;

        private List<faizGenel> _FaizGenel;

        private List<faizIsmi> _FaizIsmi;

        private List<il> _Il;

        private List<icraKodluBilgi> _iIcraKodluBilgi;

        private List<rolTur> _RolTur;

        private List<sureBirimi> _SureBirim;

        private List<tutarTur> _TutarTur;

        private List<verilisNedeni> _VerilisNedeni;

        [XmlElement("adresTuru")]
        public List<adresTuru> AdresTur
        { get { return _AdresTur; } set { _AdresTur = value; } }

        [XmlElement("alacakKalemKodlar")]
        public List<alacakKalemKodlar> AlacakKalemKodlar
        { get { return _AlacakKalemKodlar; } set { _AlacakKalemKodlar = value; } }

        [XmlElement("faizGenel")]
        public List<faizGenel> FaizGenel
        { get { return _FaizGenel; } set { _FaizGenel = value; } }

        [XmlElement("faizIsmi")]
        public List<faizIsmi> FaizIsmi
        { get { return _FaizIsmi; } set { _FaizIsmi = value; } }

        [XmlElement("il")]
        public List<il> Il
        { get { return _Il; } set { _Il = value; } }

        [XmlElement("icraKodluBilgi")]
        public List<icraKodluBilgi> iIcraKodluBilgi
        { get { return _iIcraKodluBilgi; } set { _iIcraKodluBilgi = value; } }

        [XmlElement("rolTur")]
        public List<rolTur> RolTur
        { get { return _RolTur; } set { _RolTur = value; } }

        [XmlElement("sureBirimi")]
        public List<sureBirimi> SureBirim
        { get { return _SureBirim; } set { _SureBirim = value; } }

        [XmlElement("tutarTur")]
        public List<tutarTur> TutarTur
        { get { return _TutarTur; } set { _TutarTur = value; } }

        [XmlElement("verilisNedeni")]
        public List<verilisNedeni> VerilisNedeni
        { get { return _VerilisNedeni; } set { _VerilisNedeni = value; } }
    }

    [Serializable]
    [XmlType("rolTur")]
    public class rolTur
    {
        private string _Rol;

        private string _rolID;

        [XmlAttribute("Rol")]
        public string Rol
        { get { return _Rol; } set { _Rol = value; } }

        [XmlAttribute("rolID")]
        public string rolID
        { get { return _rolID; } set { _rolID = value; } }
    }

    [Serializable]
    [XmlType("sureBirimi")]
    public class sureBirimi
    {
        private string _aciklama;

        private string _kod;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        [XmlAttribute("kod")]
        public string kod
        { get { return _kod; } set { _kod = value; } }
    }

    [Serializable]
    [XmlType("tutarTur")]
    public class tutarTur
    {
        private string _aciklama;

        private string _kod;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        [XmlAttribute("kod")]
        public string kod
        { get { return _kod; } set { _kod = value; } }
    }

    [Serializable]
    [XmlType("verilisNedeni")]
    public class verilisNedeni
    {
        private string _aciklama;

        private string _kod;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        [XmlAttribute("kod")]
        public string kod
        { get { return _kod; } set { _kod = value; } }
    }
}