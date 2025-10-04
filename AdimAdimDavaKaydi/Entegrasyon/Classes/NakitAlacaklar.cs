using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class NakitAlacak
    {
        public double AkdiFaizOrani { get; set; }

        public string AlacakTipi { get; set; }

        public bool BSMVHesaplansin { get; set; }

        public double FaizOrani { get; set; }

        public string FaizTipi { get; set; }

        public bool IsSelected { get; set; }

        public string ReferansNo { get; set; }

        public string ReferansNo2 { get; set; }

        public List<AlacakTaraf> Taraflari { get; set; }

        public decimal Tutari { get; set; }

        public string TutariParaBirimi { get; set; }

        public DateTime VadeTarihi { get; set; }
    }
}