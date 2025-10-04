using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace AdimAdimDavaKaydi.Util.Uyap
{


    [Serializable]
    public class data
    {
        [XmlElement("kodlubilgiGrubu")]
        public kodlubilgiGrubu kodluBilgiGrup
        { get { return _kodluBilgiGrup; } set { _kodluBilgiGrup = value; } }

        private kodlubilgiGrubu _kodluBilgiGrup;

    }
    [XmlType("kodlubilgiGrubu")]
    public class kodlubilgiGrubu
    {
        [XmlElement("sureBirimi")]
        public List<sureBirimi> SureBirim
        { get { return _SureBirim; } set { _SureBirim = value; } }

        private List<sureBirimi> _SureBirim;

        [XmlElement("adresTuru")]
        public List<adresTuru> AdresTur
        { get { return _AdresTur; } set { _AdresTur = value; } }

        private List<adresTuru> _AdresTur;

        [XmlElement("faizIsmi")]
        public List<faizIsmi> FaizIsmi
        { get { return _FaizIsmi; } set { _FaizIsmi = value; } }

        private List<faizIsmi> _FaizIsmi;

        [XmlElement("tutarTur")]
        public List<tutarTur> TutarTur
        { get { return _TutarTur; } set { _TutarTur = value; } }

        private List<tutarTur> _TutarTur;

        [XmlElement("verilisNedeni")]
        public List<verilisNedeni> VerilisNedeni
        { get { return _VerilisNedeni; } set { _VerilisNedeni = value; } }

        private List<verilisNedeni> _VerilisNedeni;

        [XmlElement("rolTur")]
        public List<rolTur> RolTur
        { get { return _RolTur; } set { _RolTur = value; } }

        private List<rolTur> _RolTur;

        [XmlElement("il")]
        public List<il> Il
        { get { return _Il; } set { _Il = value; } }

        private List<il> _Il;

        [XmlElement("alacakKalemKodlar")]
        public List<alacakKalemKodlar> AlacakKalemKodlar
        { get { return _AlacakKalemKodlar; } set { _AlacakKalemKodlar = value; } }

        private List<alacakKalemKodlar> _AlacakKalemKodlar;

        [XmlElement("icraKodluBilgi")]
        public List<icraKodluBilgi> iIcraKodluBilgi
        { get { return _iIcraKodluBilgi; } set { _iIcraKodluBilgi = value; } }

        private List<icraKodluBilgi> _iIcraKodluBilgi;

        [XmlElement("faizGenel")]
        public List<faizGenel> FaizGenel
        { get { return _FaizGenel; } set { _FaizGenel = value; } }

        private List<faizGenel> _FaizGenel;



    }

    [Serializable]
    [XmlType("sureBirimi")]
    public class sureBirimi
    {
        [XmlAttribute("kod")]
        public string kod
        { get { return _kod; } set { _kod = value; } }

        private string _kod;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        private string _aciklama;

    }

    [Serializable]
    [XmlType("adresTuru")]
    public class adresTuru
    {
        [XmlAttribute("kod")]
        public string kod
        { get { return _kod; } set { _kod = value; } }

        private string _kod;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        private string _aciklama;

    }

    [Serializable]
    [XmlType("faizIsmi")]
    public class faizIsmi
    {
        [XmlAttribute("kod")]
        public string kod
        { get { return _kod; } set { _kod = value; } }

        private string _kod;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        private string _aciklama;

    }

    [Serializable]
    [XmlType("tutarTur")]
    public class tutarTur
    {
        [XmlAttribute("kod")]
        public string kod
        { get { return _kod; } set { _kod = value; } }

        private string _kod;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        private string _aciklama;

    }

    [Serializable]
    [XmlType("verilisNedeni")]
    public class verilisNedeni
    {
        [XmlAttribute("kod")]
        public string kod
        { get { return _kod; } set { _kod = value; } }

        private string _kod;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        private string _aciklama;


    }

    [Serializable]
    [XmlType("rolTur")]
    public class rolTur
    {
        [XmlAttribute("rolID")]
        public string rolID
        { get { return _rolID; } set { _rolID = value; } }

        private string _rolID;

        [XmlAttribute("Rol")]
        public string Rol
        { get { return _Rol; } set { _Rol = value; } }

        private string _Rol;

    }

    [Serializable]
    [XmlType("ilce")]
    public class ilce
    {
        [XmlAttribute("kod")]
        public string kod
        { get { return _kod; } set { _kod = value; } }

        private string _kod;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        private string _aciklama;


    }

    [Serializable]
    [XmlType("il")]
    public class il
    {
        [XmlAttribute("kod")]
        public string kod
        { get { return _kod; } set { _kod = value; } }

        private string _kod;

        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        private string _aciklama;


        [XmlElement("ilce")]
        public List<ilce> Myilce
        { get { return _Myilce; } set { _Myilce = value; } }

        private List<ilce> _Myilce;

    }

    [Serializable]
    [XmlType("alacakKalemKodlar")]
    public class alacakKalemKodlar
    {
        [XmlAttribute("alacakKalemKod")]
        public string alacakKalemKod
        { get { return _alacakKalemKod; } set { _alacakKalemKod = value; } }

        private string _alacakKalemKod;

        [XmlAttribute("alacakKalemKodAciklama")]
        public string alacakKalemKodAciklama
        { get { return _alacakKalemKodAciklama; } set { _alacakKalemKodAciklama = value; } }

        private string _alacakKalemKodAciklama;

        ////Yeniden kaldýrýldý. MB ////Yeniden eklendi. MB Hukuk ailesinde olmadýðýndan aþaðýdaki property kaldýrýldý. MB
        //[XmlAttribute("alacakKalemKodTip")]
        //public string alacakKalemKodTip
        //{ get { return _alacakKalemKodTip; } set { _alacakKalemKodTip = value; } }


        [XmlAttribute("alacakKalemKodTuru")]
        public string alacakKalemKodTuru
        { get { return _alacakKalemKodTuru; } set { _alacakKalemKodTuru = value; } }

        private string _alacakKalemKodTuru;

        //Yeniden kapatýldý. MB ////Yeniden eklendi. MB //Hukuk ailesinde olmadðýndan aþaðýdaki property kaldýrýldý. MB
        //[XmlAttribute("ilamliIlamsiz")]
        //public string ilamliIlamsiz
        //{ get { return _ilamliIlamsiz; } set { _ilamliIlamsiz = value; } }


        [XmlAttribute("alacakKalemTutar")]
        public string Miktar
        { get { return _Miktar; } set { _Miktar = value; } }

        private string _Miktar;

        [XmlAttribute("alacakKalemIlkTutar")]
        public string alacakKalemIlkTutar
        { get { return _alacakKalemIlkTutar; } set { _alacakKalemIlkTutar = value; } }

        private string _alacakKalemIlkTutar;


        [XmlAttribute("tutarTur")]
        public string DovizTuru
        { get { return _DovizTuru; } set { _DovizTuru = value; } }

        private string _DovizTuru;

        [XmlAttribute("tutarAdi")]
        public string DovizAdi
        { get { return _DovizAdi; } set { _DovizAdi = value; } }

        private string _DovizAdi;

        private int _foyId;

        public int FoyID
        {
            get { return _foyId; }
            set { _foyId = value; }
        }

        private bool _foydenMi;
        public bool FoydenMi
        {
            get { return _foydenMi; }
            set { _foydenMi = value; }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int _alacakKalemId;
        public int AlacakKalemID
        {
            get { return _alacakKalemId; }
            set { _alacakKalemId = value; }
        }

        private int _ilamId;
        public int IlamID
        {
            get { return _ilamId; }
            set { _ilamId = value; }
        }



    }

    [Serializable]
    [XmlType("icraKodluBilgi")]
    public class icraKodluBilgi
    {
        [XmlAttribute("aciklama")]
        public string aciklama
        { get { return _aciklama; } set { _aciklama = value; } }

        private string _aciklama;

        [XmlAttribute("anaKod")]
        public string anaKod
        { get { return _anaKod; } set { _anaKod = value; } }

        private string _anaKod;

        [XmlAttribute("tutar")]
        public string tutar
        { get { return _tutar; } set { _tutar = value; } }

        private string _tutar;

        [XmlAttribute("baslangicTarihi")]
        public DateTime baslangicTarihi
        { get { return _baslangicTarihi; } set { _baslangicTarihi = value; } }

        private DateTime _baslangicTarihi;

        [XmlAttribute("bitisTarihi")]
        public DateTime bitisTarihi
        { get { return _bitisTarihi; } set { _bitisTarihi = value; } }

        private DateTime _bitisTarihi;

    }

    [Serializable]
    [XmlType("faizGenel")]
    public class faizGenel
    {
        [XmlAttribute("faizGenelKod")]
        public string faizGenelKod
        { get { return _faizGenelKod; } set { _faizGenelKod = value; } }

        private string _faizGenelKod;

        [XmlAttribute("faizOran")]
        public string faizOran
        { get { return _faizOran; } set { _faizOran = value; } }

        private string _faizOran;

        [XmlAttribute("faizTipKod")]
        public string faizTipKod
        { get { return _faizTipKod; } set { _faizTipKod = value; } }

        private string _faizTipKod;

        [XmlAttribute("tarih")]
        public DateTime tarih
        { get { return _tarih; } set { _tarih = value; } }

        private DateTime _tarih;

    }
}
