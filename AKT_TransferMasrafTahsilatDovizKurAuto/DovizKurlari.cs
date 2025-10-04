using System;

namespace AKT_TransferMasrafTahsilatDovizKurAuto
{
    public class DovizKur
    {
        public decimal CaprazDeger { get; set; }

        public decimal DovizAlis { get; set; }

        public decimal DovizSatis { get; set; }

        public string DovizTip { get; set; }

        public decimal EfektifAlis { get; set; }

        public decimal EfektifSatis { get; set; }

        public decimal GercekDeger { get; set; }

        public bool GiseKurmu { get; set; }

        public decimal KatSayi { get; set; }

        public DateTime Tarih { get; set; }
    }
}