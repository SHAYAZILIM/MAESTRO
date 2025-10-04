using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ReportPro.Utils
{
    public static class Tools
    {
        private static string _temp = Application.StartupPath + "\\Temp\\";


        public static string Temp
        {
            get
            {
                if (KlasorKontrolu(_temp))
                    return _temp;
                else
                {
                    return Application.StartupPath + "\\";
                }
            }
        }

        public static bool DosyaKontrol(string path)
        {
            bool varmi = File.Exists(path);
            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                try
                {
                    fs.Write(new byte[] { 0 }, 0, 1);
                }
                catch (Exception ex)
                {
                    Logla(ex, typeof(Tools));
                    return false;
                }
                finally { fs.Close(); }
            }
            return true;
        }

        public static bool KlasorKontrolu(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logla(ex, typeof(Tools));
                return false;
            }

            return true;
        }

        public static void Logla(Exception ex, object sender)
        {
            Logla(ex, sender.GetType());
        }

        public static void Logla(Exception ex, Type sender)
        {
            Logla(ex, sender, null);
        }

        // Logs l = new Logs(); l.Name = mesaj; l.Sender = sender.GetType().FullName; l.Tarih =
        // DateTime.Now; ListLogs.Add(l); AvukatProRaporlar.Tools.SerializeXml(ListLogs, Temp +
        // "loglar.txt");
        //}
        public static void Logla(Exception ex, Type sender, object pCari)
        {
            if (!File.Exists(Temp + "Logs.txt"))
            {
                FileStream fs2 = null; //= new FileStream(Temp + "Logs.txt", FileMode.Create);

                try
                {
                    fs2 = new FileStream(Temp + "Logs.txt", FileMode.Create);
                    fs2.Write(new byte[] { 0 }, 0, 1);
                }
                catch (Exception ex2)
                {
                    //BelgeUtil.ErrorHandler.Catch(sender, ex2);
                    MessageBox.Show(ex2.Message);
                }
                finally
                {
                    if (fs2 != null) fs2.Close();
                }
            }
            FileStream fs = new FileStream(Temp + "Logs.txt", FileMode.OpenOrCreate);

            try
            {
                string hata = Environment.NewLine + Environment.NewLine + pCari + Environment.NewLine + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine;
                hata += "-------------------------------------------------" + Environment.NewLine;
                hata += ex.Message + Environment.NewLine + Environment.NewLine;
                hata += "Source ::  " + Environment.NewLine + ex.Source + Environment.NewLine + Environment.NewLine;
                hata += "Data : " + Environment.NewLine + ex.Data.ToString() + Environment.NewLine + Environment.NewLine;
                hata += "Detay : " + ex.ToString();
                hata += "------------------------------------------------------" + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                byte[] veri = System.Text.Encoding.UTF8.GetBytes(hata);
                fs.Write(veri, 0, veri.Length);

                //BelgeUtil.ErrorHandler.Catch(sender, ex);
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }
            finally
            { fs.Close(); }
        }
    }
}