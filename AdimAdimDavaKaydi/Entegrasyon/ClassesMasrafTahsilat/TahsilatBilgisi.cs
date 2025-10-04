using System;

namespace AdimAdimDavaKaydi.Entegrasyon.ClassesMasrafTahsilat
{
    public class TahsilatBilgisi
    {
        //Aşağıdaki property'ler dosya bilgisinin yazılmasında kullanılıyor.
        public string Adliye { get; set; }

        public int DavaFoyID { get; set; }

        public string DisplayMember { get; set; }

        public int Durum { get; set; }

        public string EsasNo { get; set; }

        public string Gorev { get; set; }

        public int IcraFoyID { get; set; }

        public int ID { get; set; }

        public int KlasorID { get; set; }

        public string KrediBorclusu { get; set; }

        public int KrediBorclusuCariID { get; set; }

        public string Niteligi { get; set; }

        //Klasör mü, takip mi, dava mı, soruşturma mı bilgisini veriyor.
        public string No { get; set; }

        public int SorusturmaID { get; set; }

        public string TahsilatAciklama { get; set; }

        public DateTime TahsilatTarihi { get; set; }

        public decimal Tutar { get; set; }

        public string TutarParaBirimi { get; set; }

        //K ise Kredi Kartları, T ise Ticari ( Kurumsal )
    }
}