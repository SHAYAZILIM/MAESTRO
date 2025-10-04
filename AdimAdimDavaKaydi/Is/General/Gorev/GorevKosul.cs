using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Is.General.Gorev
{
    public static class Degerler
    {
        public static List<Deger> TabloAlani()
        {
            List<Deger> returnValues = new List<Deger>();

            Deger deger = new Deger();
            deger.Ad = "Icra";
            deger.Tip = typeof(string);
            deger.Id = 1;
            deger.Degeri = "AV001_TI_BIL_FOY";
            deger.Aciklama = "Bir Tablosu ile iliþkili Koþullar";
            returnValues.Add(deger);

            Deger deger2 = new Deger();
            deger2.Ad = "Dava";
            deger2.Id = 2;
            deger2.Tip = typeof(string);
            deger2.Degeri = "AV001_TD_BIL_FOY";
            deger2.Aciklama = "Bir Tablosu ile iliþkili Koþullar";
            returnValues.Add(deger2);

            Deger deger3 = new Deger();
            deger3.Ad = "Rücu";
            deger3.Id = 3;
            deger3.Tip = typeof(string);
            deger3.Degeri = "AV001_TDI_BIL_RUCU";
            deger3.Aciklama = "Bir Tablosu ile iliþkili Koþullar";
            returnValues.Add(deger3);

            Deger deger4 = new Deger();
            deger4.Ad = "Hazýrlýk";
            deger4.Id = 4;
            deger4.Tip = typeof(string);
            deger4.Degeri = "AV001_TD_BIL_HAZIRLIK";
            deger4.Aciklama = "Bir Tablosu ile iliþkili Koþullar";
            returnValues.Add(deger4);

            Deger deger5 = new Deger();
            deger5.Ad = "Sözleþme";
            deger5.Id = 5;
            deger5.Tip = typeof(string);
            deger5.Degeri = "AV001_TDI_BIL_SOZLESME";
            deger5.Aciklama = "Bir Tablosu ile iliþkili Koþullar";
            returnValues.Add(deger5);

            Deger deger6 = new Deger();
            deger6.Ad = "Tebligat";
            deger6.Id = 6;
            deger6.Tip = typeof(string);
            deger6.Degeri = "AV001_TDI_BIL_TEBLIGAT";
            deger6.Aciklama = "Bir Tablosu ile iliþkili Koþullar";
            returnValues.Add(deger6);

            Deger deger7 = new Deger();
            deger7.Ad = "Muhasebe";
            deger7.Id = 7;
            deger7.Tip = typeof(string);
            deger7.Degeri = "AV001_TDI_BIL_MUHASEBE";
            deger7.Aciklama = "Bir Tablosu ile iliþkili Koþullar";
            returnValues.Add(deger7);

            Deger deger8 = new Deger();
            deger8.Ad = "Görev";
            deger8.Id = 8;
            deger8.Tip = typeof(string);
            deger8.Degeri = "AV001_TDI_BIL_IS_GOREV";
            deger8.Aciklama = "Bir Tablosu ile iliþkili Koþullar";
            returnValues.Add(deger8);

            Deger deger9 = new Deger();
            deger9.Ad = "Mesaj";
            deger9.Id = 9;
            deger9.Tip = typeof(string);
            deger9.Degeri = "AV001_TDIE_BIL_MESAJ";
            deger9.Aciklama = "Bir Tablosu ile iliþkili Koþullar";
            returnValues.Add(deger9);

            Deger deger10 = new Deger();
            deger10.Ad = "Ýþ";
            deger10.Id = 10;
            deger10.Tip = typeof(string);
            deger10.Degeri = "AV001_TDI_BIL_IS";
            deger10.Aciklama = "Bir Tablosu ile iliþkili Koþullar";
            returnValues.Add(deger10);

            Deger deger11 = new Deger();
            deger11.Ad = "Belge";
            deger11.Id = 11;
            deger11.Tip = typeof(string);
            deger11.Degeri = "AV001_TDIE_BIL_BELGE";
            deger11.Aciklama = "Bir Tablosu ile iliþkili Koþullar";
            returnValues.Add(deger11);

            Deger deger12 = new Deger();
            deger12.Ad = "Cari";
            deger12.Id = 12;
            deger12.Tip = typeof(string);
            deger12.Degeri = "AV001_TDI_BIL_CARI";
            deger12.Aciklama = "Bir Tablosu ile iliþkili Koþullar";
            returnValues.Add(deger12);

            Deger deger13 = new Deger();
            deger13.Ad = "Haciz";
            deger13.Id = 13;
            deger13.Tip = typeof(string);
            deger13.Degeri = "AV001_TI_BIL_HACIZ";
            deger13.Aciklama = "Bir Tablosu ile iliþkili Koþullar";
            returnValues.Add(deger13);

            Deger deger14 = new Deger();
            deger14.Ad = "Deðer";
            deger14.Id = 14;
            deger14.Degeri = "VALUE";
            deger14.Tip = typeof(object);
            deger14.Aciklama = "Bir Deðer ile iliþkili Koþullar";
            returnValues.Add(deger14);

            return returnValues;
        }
    }

    public class Deger
    {
        public string Aciklama { get; set; }

        public string Ad { get; set; }

        public string Degeri { get; set; }

        public int Id { get; set; }

        public Type Tip { get; set; }
    }
}