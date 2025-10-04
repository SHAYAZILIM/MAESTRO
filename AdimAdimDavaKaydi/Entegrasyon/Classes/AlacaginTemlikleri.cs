using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class AlacaginTemliki
    {
        public string Aciklama { get; set; }

        public string AlacakTur { get; set; }

        public string BaskaTemlikVarmi { get; set; }

        public string BorcunDayanagi { get; set; }

        public string Durum { get; set; }

        public int FaturaAdet { get; set; }

        public string ReferansNo { get; set; }

        public List<Taraf> Taraflar { get; set; }

        public string TemlikBorclusu { get; set; }

        public decimal Tutar { get; set; }

        public string TutarParaBirimi { get; set; }
    }
}