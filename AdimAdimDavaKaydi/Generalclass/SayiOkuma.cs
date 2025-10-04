using System;

namespace AdimAdimDavaKaydi.Generalclass
{
    public class SayiOkuma
    {
        public SayiOkuma()
        {
            // içlerini dolduruyoruz

            yuzler.SetValue("dokuzyüz", 9);
            yuzler.SetValue("sekizyüz", 8);
            yuzler.SetValue("yediyüz", 7);
            yuzler.SetValue("altýyüz", 6);
            yuzler.SetValue("beþyüz", 5);
            yuzler.SetValue("dörtyüz", 4);
            yuzler.SetValue("üçyüz", 3);
            yuzler.SetValue("ikiyüz", 2);
            yuzler.SetValue("yüz", 1);
            yuzler.SetValue("", 0);

            onlar.SetValue("doksan", 9);
            onlar.SetValue("seksen", 8);
            onlar.SetValue("yetmiþ", 7);
            onlar.SetValue("altmýþ", 6);
            onlar.SetValue("elli", 5);
            onlar.SetValue("kýrk", 4);
            onlar.SetValue("otuz", 3);
            onlar.SetValue("yirmi", 2);
            onlar.SetValue("on", 1);
            onlar.SetValue("", 0);

            birler.SetValue("dokuz", 9);
            birler.SetValue("sekiz", 8);
            birler.SetValue("yedi", 7);
            birler.SetValue("altý", 6);
            birler.SetValue("beþ", 5);
            birler.SetValue("dört", 4);
            birler.SetValue("üç", 3);
            birler.SetValue("iki", 2);
            birler.SetValue("bir", 1);
            birler.SetValue("", 0);

            hane.SetValue("", 0);
            hane.SetValue("", 1);
            hane.SetValue("", 2);
            hane.SetValue("", 3);
            hane.SetValue("", 4);
            /*  ilk olarak bu arrayýn elemanlarýný boþ olarak ayarlýyoruz eðer küme elemanlarý
            000 deðilse trilyon,milyar,milyon bin deðerleri ile dolduruyoruz
            */
        }

        private string[] birler = new string[10];
        private string[] hane = new string[5];
        private string[] onlar = new string[10];
        private string[] rakam = new string[5];
        private string[] yuzler = new string[10];

        // arraylarý tanýmlýyoruz
        public string oku(string sayi)
        {
            int uzunluk = sayi.Length;
            if (uzunluk > 15)

                return "Hata girilen deðerin uzunluðu en fazla 15 olmalý";
            // uzunluk 15 karakterden fazla olmamalý. si

            try
            {
                long k = Convert.ToInt64(sayi);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            sayi = "000000000000000" + sayi;
            sayi = sayi.Substring(uzunluk, 15);

            rakam.SetValue(sayi.Substring(0, 3), 0);
            rakam.SetValue(sayi.Substring(3, 3), 1);
            rakam.SetValue(sayi.Substring(6, 3), 2);
            rakam.SetValue(sayi.Substring(9, 3), 3);
            rakam.SetValue(sayi.Substring(12, 3), 4);

            if (rakam[0] != "000")
                hane.SetValue("trilyon ", 0);
            if (rakam[1] != "000")
                hane.SetValue("milyar ", 1);
            if (rakam[2] != "000")
                hane.SetValue("milyon ", 2);
            if (rakam[3] != "000")
                hane.SetValue("bin ", 3);

            string sonuc = "";

            for (int i = 0; i < 5; i++)
            {
                sonuc = sonuc + yuzler[Convert.ToInt16(rakam[i][0].ToString())] +
                        birsorunu(onlar[Convert.ToInt16(rakam[i][1].ToString())] +
                                  birler[Convert.ToInt16(rakam[i][2].ToString())] + hane[i]);
            }

            return sonuc;
        }

        public string ParaFormatla(object deger)
        {
            decimal d = decimal.Parse(deger.ToString().Trim());
            return d.ToString("###,###,###,###,##0.00");
        }

        public string paraOku(string deger)
        {
            int ss = 1;
            int.TryParse(deger[0].ToString(), out ss);
            if (ss == 0)
            {
                return "Sýfýr";
            }

            string[] sayilar = new string[1];
            if (deger.Contains(","))
            {
                sayilar = deger.Split(',');
            }

            string s = "";
            for (int i = 0; i < sayilar.Length; i++)
            {
                if (Convert.ToInt32(sayilar[i]) != 0)
                {
                    s += oku(sayilar[i]) + ",";
                }
            }
            return s.Remove(s.Length - 1, 1);
        }
        
        private string birsorunu(string sorun)
        {
            string cozum = "";
            if (sorun == "birbin ")
                cozum = "bin ";

            else
                cozum = sorun;

            return cozum;
        }
    }
}