using System;

namespace AvukatProLib.Util.Etiket
{
    [Serializable]
    public class ReferansAlanlari
    {
        public ReferansAlanlari()
        {
        }

        private string _Referans1 = "Referans1";
        private string _Referans2 = "Referans2";
        private string _Referans3 = "Referans3";

        public string Referans1
        {
            get { return _Referans1; }
            set { _Referans1 = value; }
        }

        public string Referans2
        {
            get { return _Referans2; }
            set { _Referans2 = value; }
        }

        public string Referans3
        {
            get { return _Referans3; }
            set { _Referans3 = value; }
        }
    }
}