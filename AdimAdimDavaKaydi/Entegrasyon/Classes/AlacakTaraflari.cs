using System;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class AlacakTaraf
    {
        public DateTime IhtarTarihi { get; set; }

        public DateTime IhtarTebligTarihi { get; set; }

        public bool IsSelected { get; set; }

        public string Musteri { get; set; }

        public int MusteriCariID { get; set; }//DetermineCustomerCariID metodundan 0 döndüğünde cari id 'si bulunup tarafa verilebilmesi için eklendi. Alacak tarafı ekleyen metod çağrılmadan aktarılan taraın bu property'sine bulunan id verilir.

        public string MusteriNo { get; set; }

        public decimal SorumluOlunanMiktar { get; set; }

        public string SorumluOlunanMiktarParaBirimi { get; set; }

        public string TarafSifat { get; set; }
    }
}