using System;

namespace AKT_TransferMasrafTahsilatDovizKurAuto
{
    public class Masraflar
    {
        public string Borclu { get; set; }

        public string HesapNo { get; set; }

        public string IBANNo { get; set; }

        public string KrediBorclusu { get; set; }

        public string KrediReferansNo { get; set; }

        public string MasrafKategori { get; set; }

        public DateTime MasrafTarihi { get; set; }

        public string MasrafYapan { get; set; }

        public string MusteriNo { get; set; }

        public string Onaylayan { get; set; }

        public string ReferansNo { get; set; }

        public string Sube { get; set; }

        public decimal ToplamTutar { get; set; }

        public string ToplamTutarParaBirimi { get; set; }
    }
}