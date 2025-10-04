using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Util
{
    public class ÝstatistikiDegerler
    {
        public string Caption { get; set; }

        public object Deger { get; set; }

        public int Toplam { get; set; }

        public DegerKarsilastirmaTipi KarsilastirmaTipi { get; set; }
    }

    public enum DegerKarsilastirmaTipi
    {
        BudegerdenBuyuk,
        BuDegerDenKucuk,
        Esit,
        IcerisindeBuDegerGecen,
        BuDegeriIcermeyen,
        BuDegereEsitOlmayan,
        BudegerdenKucukVeyaEsit,
        BuDegerdenBuyukVeyaEsit,
        BudegerdenBuyukVeyaEsitOlmayan,
        BudegerdenKucukVeyaEsitOlmayan,
        BudegerdenKucukVeEsit,
        BuDegerdenBuyukVeEsit,
        BudegerdenBuyukVeEsitOlmayan,
        BudegerdenKucukVeEsitOlmayan,
    }

}