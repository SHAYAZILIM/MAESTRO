using System;

namespace AvukatPro.Services.Messaging
{
    public class GetTebligatByFiltreRequest
    {
        public string Barkod { get; set; }

        public int? DosyaID { get; set; }

        public int? KonuID { get; set; }

        public int? KullaniciSubeID { get; set; }

        public AvukatProLib.Extras.Modul? Modul { get; set; }

        public int? MuhatapID { get; set; }

        public DateTime? PostalamaTarihi { get; set; }

        public string ReferansNo { get; set; }

        public int? TebligatAltTur { get; set; }
    }
}