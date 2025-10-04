using System;

namespace AvukatPro.Services.Messaging
{
    public class GetGorusmeByFiltreRequest
    {
        public int? DosyaID { get; set; }

        public int? GorusenKisi { get; set; }

        public DateTime? GorusmeTarihi { get; set; }

        public int? GorusulenKisi { get; set; }

        public int? IsinYapildigiKisi { get; set; }

        public int? IsKategoriID { get; set; }

        public AvukatProLib.Extras.Modul? Modul { get; set; }

        public DateTime? YenidenGorusmeTarihi { get; set; }
    }
}