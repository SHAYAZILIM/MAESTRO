using System;

namespace AvukatProLib.Util.Etiket
{
    [Serializable]
    public class OzelDurumlar
    {
        private string _Banka = "BANKA";
        private string _FoyBirim = "FOY B�R�M";
        private string _FoyYeri = "FOY YER�";
        private string _Klasor1 = "KLAS�R 1";
        private string _Klasor2 = "KLAS�R 2";
        private string _KrediGrup = "KRED� GRUP";
        private string _KrediTip = "KRED� T�P";
        private string _Ozel = "�ZEL";
        private string _Sube = "�UBE";
        private string _Tahsilat = "TAHS�LAT";

        public string Banka
        {
            get { return _Banka; }
            set { _Banka = value; }
        }

        public string FoyBirim
        {
            get { return _FoyBirim; }
            set { _FoyBirim = value; }
        }

        public string FoyYeri
        {
            get { return _FoyYeri; }
            set { _FoyYeri = value; }
        }

        public string Klasor1
        {
            get { return _Klasor1; }
            set { _Klasor1 = value; }
        }

        public string Klasor2
        {
            get { return _Klasor2; }
            set { _Klasor2 = value; }
        }

        public string KrediGrup
        {
            get { return _KrediGrup; }
            set { _KrediGrup = value; }
        }

        public string KrediTip
        {
            get { return _KrediTip; }
            set { _KrediTip = value; }
        }

        public string Ozel
        {
            get { return _Ozel; }
            set { _Ozel = value; }
        }

        public string Sube
        {
            get { return _Sube; }
            set { _Sube = value; }
        }

        public string Tahsilat
        {
            get { return _Tahsilat; }
            set { _Tahsilat = value; }
        }
    }
}