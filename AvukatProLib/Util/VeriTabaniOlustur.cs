namespace AvukatProLib.Util
{
    public class VeriTabaniOlustur
    {
        private bool _AVP_;
        private string _HAIcýnYaratilacakVeriTabaniAdi;

        private string _MKIcýnYaratilacakVeriTabaniAdi;

        public bool AVP_
        {
            get { return _AVP_; }
            set { _AVP_ = value; }
        }

        public string HAIcýnYaratilacakVeriTabaniAdi
        {
            get { return _HAIcýnYaratilacakVeriTabaniAdi; }
            set { _HAIcýnYaratilacakVeriTabaniAdi = value; }
        }

        public string MKIcýnYaratilacakVeriTabaniAdi
        {
            get { return _MKIcýnYaratilacakVeriTabaniAdi; }
            set { _MKIcýnYaratilacakVeriTabaniAdi = value; }
        }
    }
}