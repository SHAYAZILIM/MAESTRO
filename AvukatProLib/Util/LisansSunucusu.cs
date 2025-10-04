namespace AvukatProLib.Util
{
    public class LisansSunucusu
    {
        private int iletisimPortu;
        private string sunucuAdresi;

        private int zamanAsimi;

        public int IletisimPortu
        {
            get { return iletisimPortu; }
            set { iletisimPortu = value; }
        }

        public string SunucuAdresi
        {
            get { return sunucuAdresi; }
            set { sunucuAdresi = value; }
        }

        public int ZamanAsimi
        {
            get { return zamanAsimi; }
            set { zamanAsimi = value; }
        }
    }
}