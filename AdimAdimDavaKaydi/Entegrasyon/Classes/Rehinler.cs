using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    //Takip oluştururken, herbir rehin türü için ayrı bir class tanımlandığından sorun yaratıyordu. Bu nedenle her bir rehin türü oluşturulurken Rehinler tipindeki bir property ile o dosyadaki bütün rehinlere ulaşılabilmiş alacağız ve takip oluşturma ekranında tek bir grid üzerinde rehinleri gösterebileceğiz.

    public class Rehin
    {
        public decimal Bedeli { get; set; }

        public string BedeliParaBirimi { get; set; }

        public DateTime ImzaTarihi { get; set; }

        public bool IsSelected { get; set; }

        public List<SozlesmeTaraf> Taraflar { get; set; }

        public string Tip { get; set; }//Bu alana farklı tipteki rehinler oluşturulurken manuel olarak değer verilecek.
    }
}