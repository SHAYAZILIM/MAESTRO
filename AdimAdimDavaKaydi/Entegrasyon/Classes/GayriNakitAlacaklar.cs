using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class GayriNakitAlacak
    {
        public string Aciklama { get; set; }

        public string AlacakTipi { get; set; }

        public bool BSMVHesaplansin { get; set; }

        public int CekAdedi { get; set; }

        public decimal CekYapragiILKSorumlulukMiktari { get; set; }

        //Çek yapraklarının referans numaraları araya virgül eklenerek Açıklama alanına atılacak.
        public string CekYapragiILKSorumlulukMiktariParaBirimi { get; set; }

        public decimal CekYapragiSONSorumlulukMiktari { get; set; }

        public string CekYapragiSONSorumlulukMiktariParaBirimi { get; set; }

        public List<GayrinakitHareket> Hareketler { get; set; }

        public bool IsSelected { get; set; }

        public string Muhatabi { get; set; }

        public string ReferansNo2 { get; set; }

        public List<AlacakTaraf> Taraflari { get; set; }

        public decimal Tutari { get; set; }

        public string TutariParaBirimi { get; set; }

        public DateTime VeridildigiTarih { get; set; }

        public string VerilisNo { get; set; }
    }
}