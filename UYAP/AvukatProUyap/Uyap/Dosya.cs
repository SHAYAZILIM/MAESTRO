using System;
using System.Collections.Generic;

using System.Xml;
using System.Xml.Serialization;

namespace AdimAdimDavaKaydi.UyapClass
{
    [Serializable]
    [XmlType("dosya")]
    public class Dosya
    {
        private string _aciklama48e9;
        private string _alacaklininTalepEttigiHak;
        private string _BK84MaddeUygulansin;
        private string _BSMVUygulansin;
        private List<Cek> _cekler;
        private List<DigerAlacak> _digerAlacaklar;
        private string _dosyaBelirleyicisi;
        private string _dosyaTipi;
        private int _dosyaTuru;
        private List<Evrak> _evraklar;
        private List<Ilam> _Ilamlar;
        private string _id;
        private string _KKDFUygulansin;
        private List<KontratKefil> _kontratKefiller;
        private List<Police> _policeler;
        private List<Ref> _Refler;
        private List<Senet> _senetler;
        private int _takipSekli;
        private int _takipTuru;
        private int _takipYolu;
        private List<Taraf> _taraflar;

        private List<VekilKisi> _VekilKisi;

        [XmlAttribute("aciklama48e9")]
        public string aciklama48e9
        { get { return _aciklama48e9; } set { _aciklama48e9 = value; } }

        [XmlAttribute("alacaklininTalepEttigiHak")]
        public string alacaklininTalepEttigiHak
        { get { return _alacaklininTalepEttigiHak; } set { _alacaklininTalepEttigiHak = value; } }

        [XmlAttribute("BK84MaddeUygulansin")]
        public string BK84MaddeUygulansin
        { get { return _BK84MaddeUygulansin; } set { _BK84MaddeUygulansin = value; } }

        [XmlAttribute("BSMVUygulansin")]
        public string BSMVUygulansin
        { get { return _BSMVUygulansin; } set { _BSMVUygulansin = value; } }

        [XmlElement("cek")]
        public List<Cek> cekler
        {
            get { return _cekler; }
            set { _cekler = value; }
        }

        [XmlElement("digerAlacak")]
        public List<DigerAlacak> digerAlacaklar
        { get { return _digerAlacaklar; } set { _digerAlacaklar = value; } }

        [XmlAttribute("dosyaBelirleyicisi")]
        public string dosyaBelirleyicisi
        { get { return _dosyaBelirleyicisi; } set { _dosyaBelirleyicisi = value; } }

        [XmlAttribute("dosyaTipi")]
        public string dosyaTipi
        { get { return _dosyaTipi; } set { _dosyaTipi = value; } }

        [XmlAttribute("dosyaTuru")]
        public int dosyaTuru
        { get { return _dosyaTuru; } set { _dosyaTuru = value; } }

        [XmlElement("evrak")]
        public List<Evrak> evraklar
        { get { return _evraklar; } set { _evraklar = value; } }

        [XmlElement("ilam")]
        public List<Ilam> Ilamlar
        { get { return _Ilamlar; } set { _Ilamlar = value; } }

        [XmlAttribute("id")]
        public string id
        { get { return _id; } set { _id = value; } }

        [XmlAttribute("KKDFUygulansin")]
        public string KKDFUygulansin
        { get { return _KKDFUygulansin; } set { _KKDFUygulansin = value; } }

        [XmlElement("kontratKefil")]
        public List<KontratKefil> kontratKefiller
        { get { return _kontratKefiller; } set { _kontratKefiller = value; } }

        [XmlElement("police")]
        public List<Police> policeler
        { get { return _policeler; } set { _policeler = value; } }

        [XmlElement("ref")]
        public List<Ref> Refler
        { get { return _Refler; } set { _Refler = value; } }

        [XmlElement("senet")]
        public List<Senet> senetler
        { get { return _senetler; } set { _senetler = value; } }

        [XmlAttribute("takipSekli")]
        public int takipSekli
        { get { return _takipSekli; } set { _takipSekli = value; } }

        [XmlAttribute("takipTuru")]
        public int takipTuru
        { get { return _takipTuru; } set { _takipTuru = value; } }

        [XmlAttribute("takipYolu")]
        public int takipYolu
        { get { return _takipYolu; } set { _takipYolu = value; } }

        [XmlElement("taraf")]
        public List<Taraf> taraflar
        { get { return _taraflar; } set { _taraflar = value; } }

        [XmlElement("VekilKisi")]
        public List<VekilKisi> VekilKisi
        { get { return _VekilKisi; } set { _VekilKisi = value; } }
    }

    [Serializable]
    [XmlType("dosyalar")]
    public class Dosyalar
    {
        private List<Dosya> _dosyalar;

        [XmlElement("dosya")]
        public List<Dosya> Dosyalari
        {
            get { return _dosyalar; }
            set { _dosyalar = value; }
        }

        public void Add(Dosya d)
        {
            if (this._dosyalar == null)
            {
                this._dosyalar = new List<Dosya>();
            }
            this._dosyalar.Add(d);
        }
    }
}