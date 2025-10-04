using System;
using System.Collections.Generic;

namespace AvukatPro.Services.Messaging
{
    public class GetMuhasebeBirlesikByFiltreRequest
    {
        public int? AltKategori { get; set; }

        public int? AnaKategori { get; set; }

        public int? BorcAlacak { get; set; }

        public List<int?> DosyaIds { get; set; }

        public int? MasrafAvansTip { get; set; }

        public DateTime? MasrafTarihi { get; set; }

        public AvukatProLib.Extras.Modul? Modul { get; set; }

        public int? MuvekkilID { get; set; }

        public string ReferansNo { get; set; }
    }
}