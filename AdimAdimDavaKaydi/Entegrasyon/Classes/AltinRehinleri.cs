using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class AltinRehni
    {
        public string Aciklama { get; set; }

        public string BrutGramaj { get; set; }

        public string Durum { get; set; }

        public string ReferanNo { get; set; }

        public DateTime RehinTarihi { get; set; }

        public string RehinTuru { get; set; }

        public string SaflikDerecesi { get; set; }

        public List<Taraf> Taraflar { get; set; }

        public decimal Tutari { get; set; }

        public string TutariParaBirimi { get; set; }

        public string Yeddiemin { get; set; }
    }
}