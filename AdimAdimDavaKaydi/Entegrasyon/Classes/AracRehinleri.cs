using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class AracRehin
    {
        public string Aciklama { get; set; }

        public string AracModel { get; set; }

        public string AracMotorNo { get; set; }

        public string AracPlakaNo { get; set; }

        public string AracRenk { get; set; }

        public string AracSasiNo { get; set; }

        public string AracTip { get; set; }

        public string Durum { get; set; }

        public string ReferanNo { get; set; }

        public DateTime RehinTarihi { get; set; }

        public string RehinTuru { get; set; }

        public string RuhsatSicilNo { get; set; }

        public string SicilYevmiyeNo { get; set; }

        public List<Taraf> Taraflar { get; set; }

        public string TrafikSubesi { get; set; }

        public decimal Tutari { get; set; }

        public string TutariParaBirimi { get; set; }

        public string Yeddiemin { get; set; }
    }
}