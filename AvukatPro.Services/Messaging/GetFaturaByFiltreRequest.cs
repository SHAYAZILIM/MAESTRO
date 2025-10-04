using System;
using System.Collections.Generic;

namespace AvukatPro.Services.Messaging
{
    public class GetFaturaByFiltreRequest
    {
        public int? CariId { get; set; }

        public List<int?> DosyaIds { get; set; }

        public int? FaturaKapsamTipi { get; set; }

        public DateTime? FaturaTarihi { get; set; }

        public AvukatProLib.Extras.Modul? Modul { get; set; }

        public string ReferansNo { get; set; }

        public string SeriNo { get; set; }
    }
}