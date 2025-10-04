using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    //Sistemde Sozlesme isimli namespace olduğundan class ismi çoğul yapıldı.
    public class Sozlesmeler
    {
        public decimal Bedeli { get; set; }

        public string BedeliParaBirimi { get; set; }

        public DateTime ImzaTarihi { get; set; }

        public bool IsSelected { get; set; }

        public List<SozlesmeTaraf> Taraflar { get; set; }

        public string Tip { get; set; }
    }
}