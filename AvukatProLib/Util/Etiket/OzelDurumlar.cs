using System;

namespace AvukatProLib.Util.Etiket
{
    [Serializable]
    public class OzelDurumlar
    {
        private string _Banka = "BANKA";
        private string _FoyBirim = "FOY BÝRÝM";
        private string _FoyYeri = "FOY YERÝ";
        private string _Klasor1 = "KLASÖR 1";
        private string _Klasor2 = "KLASÖR 2";
        private string _KrediGrup = "KREDÝ GRUP";
        private string _KrediTip = "KREDÝ TÝP";
        private string _Ozel = "ÖZEL";
        private string _Sube = "ÞUBE";
        private string _Tahsilat = "TAHSÝLAT";

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