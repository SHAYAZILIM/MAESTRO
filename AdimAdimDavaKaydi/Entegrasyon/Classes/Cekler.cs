using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class Cek
    {
        public string Banka { get; set; }

        public string CekNo { get; set; }

        public string Durum { get; set; }

        public string HesapNo { get; set; }

        public bool IsSelected { get; set; }

        public string KesideYeri { get; set; }

        public string OdemeYeri { get; set; }

        public string ReferanNo { get; set; }

        public DateTime SorulduguTarih { get; set; }

        public string Sube { get; set; }

        public List<Taraf> Taraflar { get; set; }

        public decimal Tutari { get; set; }

        public string TutariParaBirimi { get; set; }

        public DateTime VadeTarihi { get; set; }
    }
}