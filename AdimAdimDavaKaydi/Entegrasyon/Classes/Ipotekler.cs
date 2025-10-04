using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class Ipotek
    {
        public string AltTip { get; set; }

        public decimal Bedeli { get; set; }

        public string BedeliParaBirimi { get; set; }

        public string Durum { get; set; }

        public List<Gayrimenkul> Gayrimenkuller { get; set; }

        public bool IsSelected { get; set; }

        public string ReferanNo { get; set; }

        public string RehinDerece { get; set; }

        public string RehinSira { get; set; }

        public string SicilBolgeNo { get; set; }

        public string SicilIl { get; set; }

        public string SicilIlce { get; set; }

        public string SicilTescilNo { get; set; }

        public string SicilYevmiyeNo { get; set; }

        public string Tip { get; set; }
    }
}