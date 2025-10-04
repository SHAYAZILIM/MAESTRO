using System;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class Tahsilatlar
    {
        public string HesapNo { get; set; }

        public string IBANNo { get; set; }

        public string KrediBorclusu { get; set; }

        public string KrediReferansNo { get; set; }

        public string MusteriNo { get; set; }

        public string Niteligi { get; set; }

        public decimal OdemeMiktari { get; set; }

        public string OdemeMiktariParaBirimi { get; set; }

        public DateTime OdemeTarihi { get; set; }

        public string Odeyen { get; set; }

        public string Sube { get; set; }

        //K ise Kredi Kartları, T ise Ticari ( Kurumsal )
    }
}