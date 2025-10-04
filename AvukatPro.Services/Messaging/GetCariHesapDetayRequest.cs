using AvukatProLib.Extras;
using System;
using System.Collections.Generic;

namespace AvukatPro.Services.Messaging
{
    public class GetCariHesapDetayRequest
    {
        public int? AltKategori { get; set; }

        public int? AnaKategori { get; set; }

        public int? BorcAlacak { get; set; }

        public int? Buro { get; set; }

        public int? Cari { get; set; }

        public List<int?> DosyaIDs { get; set; }

        public string KullaniciBelgeNo { get; set; }

        public Modul? Modul { get; set; }

        public int? OdemeTip { get; set; }

        public int? OnayDurum { get; set; }

        public DateTime? OnayTarihi { get; set; }

        public string ReferansNo { get; set; }

        public DateTime? Tarih { get; set; }
    }
}