namespace AvukatProLib.Util
{
    public class DNSBilgileri
    {
        private string hukukAilesiDNSAdi;

        private string mevzuatKararDNSAdi;

        public string HukukAilesiDnsAdi
        {
            get { return hukukAilesiDNSAdi; }
            set { hukukAilesiDNSAdi = value; }
        }

        public string MevzuatKararDnsAdi
        {
            get { return mevzuatKararDNSAdi; }
            set { mevzuatKararDNSAdi = value; }
        }
    }
}