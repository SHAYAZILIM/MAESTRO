//#define koczerOzel
#define AVPStandart

using System;

namespace AvukatProLib.Util.Etiket
{
    [Serializable]
    public class OzelKodAlanlari
    {
#if AVPStandart

        public OzelKodAlanlari()
        {
        }

        private string _OzelKod1 = "�zel Kod1";
        private string _OzelKod2 = "�zel Kod2";
        private string _OzelKod3 = "�zel Kod3";
        private string _OzelKod4 = "�zel Kod4";
#endif

#if koczerOzel
        private string _OzelKod1 = "M��teri";
        private string _OzelKod2 = "Tedarik�i";
        private string _OzelKod3 = "Hizmet";
        private string _OzelKod4 = "Lokasyon";
#endif

        public string OzelKod1
        {
            get { return _OzelKod1; }
            set { _OzelKod1 = value; }
        }

        public string OzelKod2
        {
            get { return _OzelKod2; }
            set { _OzelKod2 = value; }
        }

        public string OzelKod3
        {
            get { return _OzelKod3; }
            set { _OzelKod3 = value; }
        }

        public string OzelKod4
        {
            get { return _OzelKod4; }
            set { _OzelKod4 = value; }
        }
    }
}