using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class HatRehni
    {
        public string Aciklama { get; set; }

        public string AracBayi { get; set; }

        public string AracMarka { get; set; }

        public string AracSasi { get; set; }

        public string AracTipi { get; set; }

        public string Durum { get; set; }

        public string HatAdi { get; set; }

        public string HatTuru { get; set; }

        public string ReferanNo { get; set; }

        public DateTime RehinTarihi { get; set; }

        public string RehinTuru { get; set; }

        public List<Taraf> Taraflar { get; set; }

        public decimal Tutari { get; set; }

        public string TutariParaBirimi { get; set; }

        public string Yeddiemin { get; set; }
    }
}