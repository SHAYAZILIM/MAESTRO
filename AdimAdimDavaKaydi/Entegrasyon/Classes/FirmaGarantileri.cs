using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class FirmaGaranti
    {
        public string Durum { get; set; }

        public string GarantorMusteri { get; set; }

        public string GarantorMusteriAdresi { get; set; }

        public string ReferansNo { get; set; }

        public List<Taraf> Taraflar { get; set; }

        public decimal Tutar { get; set; }

        public string TutarParaBirimi { get; set; }
    }
}