namespace AvukatProRaporlar.RaporSource
{
    public class KlasorDonemselRaporNakit
    {
        public int acizAdet { get; set; }

        public decimal acizMiktar { get; set; }

        public int devirAdet { get; set; }

        public int devirdenAdet { get; set; }

        public decimal devirdenMiktar { get; set; }

        public decimal devirMiktar { get; set; }

        public int gelenAdet { get; set; }

        public decimal gelenMiktar { get; set; }

        public string RaporTuru { get; set; }

        public int tahsilatAdet { get; set; }

        public decimal tahsilatDagAnapara { get; set; }

        public decimal tahsilatDagFaize { get; set; }

        public decimal tahsilatDagMasraflara { get; set; }

        public decimal tahsilatMiktar { get; set; }
    }
}