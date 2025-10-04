using AvukatProLib.GlobalResource;
using System;
using System.Text;

namespace AvukatProLib.Util
{
    public static class YazmaOkuma
    {
        /// <summary>
        /// Okuma Hashlenmiþ olarak gelen deðerin çözülüp bize gýcýr gýcýr bir baðlantý veren metot
        /// </summary>
        /// <param name="sifreliVeri">Hashed veri </param>
        /// <returns> Açýlmýþ Veri </returns>
        public static string Okuma(string sifreliVeri)
        {
            //TODO:Burda bir patlama olmuþtur neden se Stringler.Bos içinde okuyamýyor
            //YILMAZ- TURHAL - 19:26 -07.03.2009
            string sonuc = "";// Stringler.Bos;
            string sifresiz = "";// Stringler.Bos;
            byte[] encoding = Encoding.ASCII.GetBytes(sifresiz);
            string[] gercek = sifreliVeri.Split('/');

            string a = gercek[4];
            a = a.Replace('"', ' ');
            byte[] decoding = Convert.FromBase64String(a);
            sonuc = Encoding.ASCII.GetString(decoding);
            return sonuc;
        }

        /// <summary>
        /// Yazma Ýþlemi
        /// </summary>
        /// <param name="constring"> Þifreleme Ýþlemi Ýçin Gelen ConStr </param>
        /// <returns> HashingVeri</returns>
        public static string Yazma(string conString)
        {
            string value1 = Stringler.Value1;
            string value2 = Stringler.Value2;
            byte[] encoding = Encoding.ASCII.GetBytes(conString);
            byte[] encoding2 = Encoding.ASCII.GetBytes(value2);
            byte[] encoding1 = Encoding.ASCII.GetBytes(value1);
            byte[] ayrac = Encoding.ASCII.GetBytes(Stringler.Ayrac1);
            string value = Convert.ToBase64String(encoding2) + Stringler.Ayrac2 + Convert.ToBase64String(encoding2) + Stringler.Ayrac2 + Convert.ToBase64String(ayrac) + Stringler.Ayrac2 + Convert.ToBase64String(encoding2) + Stringler.Ayrac2 + Convert.ToBase64String(encoding) + Stringler.Ayrac2 + Convert.ToBase64String(encoding2) + Stringler.Ayrac2 + Convert.ToBase64String(ayrac) + Stringler.Ayrac2 + Convert.ToBase64String(encoding2) + Stringler.Ayrac2 + Convert.ToBase64String(encoding1);
            return value;
        }
    }

    #region RARHelpera Taþýndý

    //public class RarlamaIslemi
    //{
    //    public static bool DosyayiRarla(string dosyayol, string raryol)
    //    {
    //        string exeyol = @"E:\Proje\AdimAdimDavaKaydi\AvukatProLib.Bakim\bin\Debug\AvukatProLib.Bakim2.exe";
    //        bool b;
    //        try
    //        {
    //            Process prc = new Process();
    //            string yol =exeyol+ " a -p1q2w3e4r " + raryol + dosyayol;
    //            prc.StartInfo = new ProcessStartInfo(exeyol, "  a -p1q2w3e4r  " + raryol + dosyayol);
    //            prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    //            prc.Start();
    //            prc.WaitForExit();

    //            b = true;
    //        }
    //        catch
    //        {
    //            b = false;
    //        }
    //        return b;

    //    }
    //    public  static bool DosyayiAc(string dosyaName)
    //    {
    //        string exeyol = @"E:\Proje\AdimAdimDavaKaydi\AvukatProLib.Bakim\bin\Debug\AvukatProLib.Bakim2.exe";
    //        bool b;
    //        try
    //        {
    //            Process prc = new Process();

    //            prc.StartInfo = new ProcessStartInfo(exeyol, " e -p1q2w3e4r " + dosyaName);
    //            prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    //            prc.Start();
    //            prc.WaitForExit();
    //            b = true;
    //        }
    //        catch
    //        {
    //            b = false;
    //        }
    //        return b;

    //    }

    //}

    #endregion RARHelpera Taþýndý
}