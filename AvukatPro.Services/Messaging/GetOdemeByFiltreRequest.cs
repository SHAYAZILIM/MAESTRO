using System;

namespace AvukatPro.Services.Messaging
{
    public class GetOdemeByFiltreRequest
    {
        public string AdliNo { get; set; }

        public string Adliye { get; set; }

        public string EsasNo { get; set; }

        public DateTime? IcradanCekilmeTarihi { get; set; }

        public bool? IhtiyatiHacizdenmi { get; set; }

        public bool? MaasHaczindenmi { get; set; }

        public DateTime? OdemeTarihi { get; set; }

        public int? OdemeTipiID { get; set; }

        public int? OdemeYeriID { get; set; }

        public int? OdenenCariID { get; set; }

        public int? OdeyenCariID { get; set; }

        public int? OzelKod1ID { get; set; }

        public int? OzelKod2ID { get; set; }

        public int? OzelKod3ID { get; set; }

        public int? OzelKod4ID { get; set; }
    }
}