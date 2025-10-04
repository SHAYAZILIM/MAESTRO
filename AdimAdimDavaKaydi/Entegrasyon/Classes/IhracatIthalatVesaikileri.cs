using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class IhracatIthalatVesaiki
    {
        public string Durum { get; set; }

        public string MalSevkiyatSekli { get; set; }

        public DateTime OdemeVadesi { get; set; }

        public int PoliceNumarasi { get; set; }

        public string ReferansNiteligi { get; set; }

        public string ReferansNo { get; set; }

        public int ReferansSiraNo { get; set; }

        public string ReferansSube { get; set; }

        public string ReferansTuru { get; set; }

        public string SigortaSirketi { get; set; }

        public List<Taraf> Taraflar { get; set; }

        public string TasiyiciFirma { get; set; }

        public decimal Tutar { get; set; }

        public string TutarParaBirimi { get; set; }
    }
}