using System;

namespace AvukatPro.Services.Messaging
{
    public class GetMuvekkilHesapByFiltreRequest
    {
        public int? BorcluCariID { get; set; }

        public int? DosyaDurumID { get; set; }

        public int? DosyaID { get; set; }

        public DateTime? HesaplanmaTarihi { get; set; }

        public DateTime? KapamaTarihi { get; set; }

        public int? KontrolKimID { get; set; }

        public int? MuvekkilCariID { get; set; }

        public int? OzelKod1ID { get; set; }

        public int? OzelKod2ID { get; set; }

        public int? OzelKod3ID { get; set; }

        public int? OzelKod4ID { get; set; }
    }
}