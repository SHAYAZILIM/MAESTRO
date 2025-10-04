namespace AvukatProLib.Util
{
    public class VeriTabaniKullanicilari
    {
        private string _Sifre;
        private string _SifreTekrar;
        private string _VarsayilanVeriTabani;
        private string _VeriTabaniKullaniciAdi;

        public string Sifre
        {
            get { return _Sifre; }
            set { _Sifre = value; }
        }

        public string SifreTekrar
        {
            get { return _SifreTekrar; }
            set { _SifreTekrar = value; }
        }

        public string VarsayilanVeriTabani
        {
            get { return _VarsayilanVeriTabani; }
            set { _VarsayilanVeriTabani = value; }
        }

        public string VeriTabaniKullaniciAdi
        {
            get { return _VeriTabaniKullaniciAdi; }
            set { _VeriTabaniKullaniciAdi = value; }
        }
    }
}