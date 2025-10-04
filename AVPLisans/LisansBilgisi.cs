using System;
using System.Collections.Generic;

namespace AVPLisans
{
    [Serializable]
    public class LisansBilgisi
    {
        private string _AdSoyad;
        private int? _DavaKayitSayisi;
        private int? _DavaKullaniciSayisi;
        private int? _IcraKayitSayisi;
        private int? _IcraKullaniciSayisi;
        private DateTime? _LisansBitisTarihi;
        private string _PaketAdi;
        private List<PaketElemanlari> _PaketElemanlari;
        private string _ProductKey;
        private int? _SorusturmaKayitSayisi;
        private int? _SorusturmaKullaniciSayisi;

        public string AdSoyad
        {
            get { return _AdSoyad; }
            set { _AdSoyad = value; }
        }

        public int? DavaKayitSayisi
        {
            get { return _DavaKayitSayisi; }
            set { _DavaKayitSayisi = value; }
        }

        public int? DavaKullaniciSayisi
        {
            get { return _DavaKullaniciSayisi; }
            set { _DavaKullaniciSayisi = value; }
        }

        public int? IcraKayitSayisi
        {
            get { return _IcraKayitSayisi; }
            set { _IcraKayitSayisi = value; }
        }

        public int? IcraKullaniciSayisi
        {
            get { return _IcraKullaniciSayisi; }
            set { _IcraKullaniciSayisi = value; }
        }

        public DateTime? LisansBitisTarihi
        {
            get { return _LisansBitisTarihi; }
            set { _LisansBitisTarihi = value; }
        }

        public string PaketAdi
        {
            get { return _PaketAdi; }
            set { _PaketAdi = value; }
        }

        public List<PaketElemanlari> PaketElemanlari
        {
            get { return _PaketElemanlari; }
            set { _PaketElemanlari = value; }
        }

        public string ProductKey
        {
            get { return _ProductKey; }
            set { _ProductKey = value; }
        }

        public int? SorusturmaKayitSayisi
        {
            get { return _SorusturmaKayitSayisi; }
            set { _SorusturmaKayitSayisi = value; }
        }

        public int? SorusturmaKullaniciSayisi
        {
            get { return _SorusturmaKullaniciSayisi; }
            set { _SorusturmaKullaniciSayisi = value; }
        }
    }

    [Serializable]
    public class PaketElemanlari
    {
        private string _Aciklama;
        private string _FormAdi;
        private bool _Visible;

        public string Aciklama
        {
            get { return _Aciklama; }
            set { _Aciklama = value; }
        }

        public string FormAdi
        {
            get { return _FormAdi; }
            set { _FormAdi = value; }
        }

        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }
    }
}