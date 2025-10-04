using System;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class GayrinakitHareket
    {
        public int CekDepoSayisi { get; set; }

        public int CekIadeSayisi { get; set; }

        public int CekTazminSayisi { get; set; }

        public decimal DepoMikari { get; set; }

        public string DepoMiktariParaBirimi { get; set; }

        public DateTime DepoTarihi { get; set; }

        public decimal IadeMiktari { get; set; }

        public string IadeMiktariParaBirimi { get; set; }

        public DateTime IadeTarihi { get; set; }

        public decimal TazminMikari { get; set; }

        public string TazminMiktariParaBirimi { get; set; }

        public DateTime TazminTarihi { get; set; }
    }
}