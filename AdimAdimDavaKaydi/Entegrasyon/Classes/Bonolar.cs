using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class Bono
    {
        public string Durum { get; set; }

        public DateTime EvrakTazminTarihi { get; set; }

        public DateTime EvrakVadeTarihi { get; set; }

        public bool IsSelected { get; set; }

        public bool MunzamSenetMi { get; set; }

        public string ReferansNo { get; set; }

        public List<Taraf> Taraflar { get; set; }

        public decimal Tutari { get; set; }

        public string TutariParaBirimi { get; set; }
    }
}