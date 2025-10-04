using System;

namespace AvukatPro.Services.Messaging
{
    public class GetKasaByFiltreRequest
    {
        public int? AnaKategori { get; set; }

        public string BelgeNo { get; set; }

        public int? BorcAlacakId { get; set; }

        public int? HareketCariId { get; set; }

        public int? OdemeTipId { get; set; }

        public string ReferansNo { get; set; }

        public DateTime? Tarih { get; set; }
    }
}