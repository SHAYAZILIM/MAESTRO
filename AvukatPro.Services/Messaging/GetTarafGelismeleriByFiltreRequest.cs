using System;

namespace AvukatPro.Services.Messaging
{
    public class GetTarafGelismeleriByFiltreRequest
    {
        public int? AdliyeId { get; set; }

        public int? DosyaDurum { get; set; }

        public string DosyaNo { get; set; }

        public string EsasNo { get; set; }

        public int? FormTipID { get; set; }

        public int? KontrolKimID { get; set; }

        public int? NoId { get; set; }

        public int? SubeKodID { get; set; }

        public string TakipEdilen { get; set; }

        public DateTime? TakipTarihi { get; set; }
    }
}