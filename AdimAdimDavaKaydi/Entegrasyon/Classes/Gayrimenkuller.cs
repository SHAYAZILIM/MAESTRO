using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class Gayrimenkul
    {
        public string Aciklama { get; set; }

        public string AdaNo { get; set; }

        public string ArsaPayi { get; set; }

        public string BagimsizBolumNo { get; set; }

        public string Bucak { get; set; }

        public string CiltNo { get; set; }

        public DateTime EksertizTarihi { get; set; }

        public string EkspertizFirma { get; set; }

        public decimal EkspertizTutari { get; set; }

        public string EkspertizTutariParaBirimi { get; set; }

        public string Il { get; set; }

        public string Ilce { get; set; }

        public string KatNo { get; set; }

        public string Koy { get; set; }

        public string Mahalle { get; set; }

        public string Mevki { get; set; }

        public string Niteligi { get; set; }

        public string PaftaNo { get; set; }

        public string ParselNo { get; set; }

        public string SahifeNo { get; set; }

        public string SerhAciklamasi { get; set; }

        public string Sokak { get; set; }

        public List<GayrimenkulTaraf> Taraflar { get; set; }

        public string YevmiyeNo { get; set; }

        public string YuzOlcumDM2 { get; set; }
    }
}