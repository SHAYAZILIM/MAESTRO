using System;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    [Serializable]
    public class Paket
    {
        public string Aciklama { get; set; }

        public string PaketAdi { get; set; }

        public int PaketId { get; set; }
    }
}