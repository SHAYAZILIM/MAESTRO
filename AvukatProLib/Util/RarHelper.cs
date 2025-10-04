using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AvukatProLib.Util
{
    public static class RarHelper
    {
        public static bool DosyayiAc(string dosyaTamYolu, string cikarilacakKlasorYolu, string rarParolasi)
        {
            string exeyol = Application.StartupPath + "\\AvukatProLib.Bakim2.exe";
            bool b;
            try
            {
                Process prc = new Process();
                string extractPath = string.Empty;
                if (!String.IsNullOrEmpty(cikarilacakKlasorYolu))
                    extractPath = " " + cikarilacakKlasorYolu;
                if (String.IsNullOrEmpty(rarParolasi))
                    prc.StartInfo = new ProcessStartInfo(exeyol, " x -y " + dosyaTamYolu + extractPath);
                else
                    prc.StartInfo = new ProcessStartInfo(exeyol, " x -y -p" + rarParolasi + " " + dosyaTamYolu + extractPath);

                //prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                prc.Start();
                prc.WaitForExit();
                b = true;
            }
            catch
            {
                b = false;
            }
            return b;
        }

        public static bool DosyayiAc(string dosyaTamYolu)
        {
            return DosyayiAc(dosyaTamYolu, string.Empty, string.Empty);
        }

        public static bool DosyayiRarla(string dosyaTamYolu, string rarTamYolu, string rarParolasi)
        {
            string exeyol = Application.StartupPath + "\\AvukatProLib.Bakim2.exe";
            return DosyayiRarla(exeyol, dosyaTamYolu, rarTamYolu, rarParolasi);
        }

        public static bool DosyayiRarla(string exeyol, string dosyaTamYolu, string rarTamYolu, string rarParolasi)
        {
            bool b;
            try
            {
                Process prc = new Process();
                string yol = exeyol + " a -p1q2w3e4r " + rarTamYolu + " " + dosyaTamYolu;
                if (String.IsNullOrEmpty(rarParolasi))
                    prc.StartInfo = new ProcessStartInfo(exeyol, " a -y" + rarTamYolu + " " + dosyaTamYolu);
                else
                    prc.StartInfo = new ProcessStartInfo(exeyol, " a -y -p" + rarParolasi + " " + rarTamYolu + " " + dosyaTamYolu);
                prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                prc.Start();
                prc.WaitForExit();

                b = true;
            }
            catch
            {
                b = false;
            }
            return b;
        }
    }
}