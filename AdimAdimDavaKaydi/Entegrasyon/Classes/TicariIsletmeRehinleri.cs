using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class TicariIsletmeRehni
    {
        public string AdliBirimNo { get; set; }

        public string Adliye { get; set; }

        public decimal Bedeli { get; set; }

        public string BedeliParaBirimi { get; set; }

        public string Durum { get; set; }

        public DateTime NoterTarihi { get; set; }

        public string NoterYevmiyeNo { get; set; }

        public string ReferanNo { get; set; }

        public string RehinDerece { get; set; }

        public string RehinSira { get; set; }

        public string SozlesmeAltTip { get; set; }

        public List<Taraf> Taraflar { get; set; }

        public string TicariIsletmeAdi { get; set; }

        public string TicariIsletmeUnvani { get; set; }
    }
}