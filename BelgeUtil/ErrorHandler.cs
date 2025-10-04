//Sunum Modu oldu�unda Normal �al�� k�sm�n� comment ediniz.
#define PencereGoster

using NLog;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace BelgeUtil
{
    /// <summary>
    /// Jira taraf�ndaki Bile�enleri ifade eden enum
    /// </summary>
    public enum Bilesen
    {
        BilesenYok,
        Aktarim,
        Arama,
        Asama,
        Belge,
        Dava,
        Editor,
        Editor_Degisken,
        Giris_Ekran,
        Hesap,
        Icra,
        Kayit,
        Rapor,
        Sorusturma,
        Sozlesme,
        Takip_Ekrani,
        Tebligat
    }

    /// <summary>
    /// Hata Yakalamak ve raporlamak i�in kullan�lan mod�l
    /// </summary>
    public class ErrorHandler
    {
        private static Logger _Logger = LogManager.GetCurrentClassLogger();

        public static Logger Logger
        {
            get { return _Logger; }
            set { _Logger = value; }
        }

        #region Obsolete Methodlar

        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        ///<summary>
        ///Yakalanan hatalar�n g�nderildi�i method.
        ///</summary>
        ///<param name="sender">Hatan�n yakaland��� yerdeki instance (this)</param>
        ///<param name="ex">Yakalanan hata</param>
        ///<returns>Yazabildi�inde OK de�eri d�ner</returns>
        public static string Catch(object sender, Exception ex)
        {
            return Catch(sender, ex, true);
        }

        ///<summary>
        ///Yakalanan hatalar�n g�nderildi�i method.
        ///</summary>
        ///<param name="sender">Hatan�n yakaland��� yerdeki instance (this)</param>
        ///<param name="ex">Yakalanan hata</param>
        ///<param name="raporGondericiGoster">Hata rapor g�nderme penceresini a�ma durumu</param>
        ///<returns>Yazabildi�inde OK de�eri d�ner</returns>
        public static string Catch(object sender, Exception ex, bool raporGondericiGoster)
        {
            return Catch(sender, ex, raporGondericiGoster, Bilesen.BilesenYok);
        }

        /// <summary>
        /// Yakalanan hatalar�n g�nderildi�i method.
        /// </summary>
        /// <param name="typeofSender">Hatan�n yakaland��� yerdeki tip</param>
        /// <param name="ex">Yakalanan hata</param>
        /// <param name="raporGondericiGoster">Hata rapor g�nderme penceresini a�ma durumu</param>
        /// <param name="extraInformation">Hata ile ilgili yazmak istedi�ini di�er ek
        /// bilgiler.</param>
        /// <returns>Yazabildi�inde OK de�eri d�ner</returns>
        public static string Catch(Type typeofSender, Exception ex, bool raporGondericiGoster, string extraInformation)
        {
            return Catch(typeofSender, ex, raporGondericiGoster, extraInformation, Bilesen.BilesenYok);
        }

        #endregion Obsolete Methodlar

        #region JIRA Sonrasi Methodlar

        ///<summary>
        ///Yakalanan hatalar�n g�nderildi�i method.
        ///</summary>
        ///<param name="sender">Hatan�n yakaland��� yerdeki instance (this)</param>
        ///<param name="ex">Yakalanan hata</param>
        /// <param name="Bilesenler"> Hatan�n g�nderildi�i yerdeki bile�enler.</param>
        ///<returns>Yazabildi�inde OK de�eri d�ner</returns>
        public static string Catch(object sender, Exception ex, params Bilesen[] Bilesenler)
        {
            return Catch(sender, ex, true, Bilesenler);
        }

        /// <summary>
        /// Yakalanan hatalar�n g�nderildi�i method.
        /// </summary>
        /// <param name="typeofSender">Hatan�n yakaland��� yerdeki tip</param>
        /// <param name="ex">Yakalanan hata</param>
        /// <param name="raporGondericiGoster">Hata rapor g�nderme penceresini a�ma durumu</param>
        /// <param name="extraInformation">Hata ile ilgili yazmak istedi�ini di�er ek
        /// bilgiler.</param>
        /// <param name="Bilesenler">Hatan�n g�nderildi�i yerdeki bile�enler.</param>
        /// <returns>Yazabildi�inde OK de�eri d�ner</returns>
        public static string Catch(Type typeofSender, Exception ex, bool raporGondericiGoster, string extraInformation, params Bilesen[] Bilesenler)
        {
            BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
            string result = "OK";
            string dir;
            try
            {
                dir = System.Configuration.ConfigurationSettings.AppSettings["ErrorLogDir"];
            }
            catch (Exception)
            {
                dir = "C:\\AVP_ERR";
            }
            try
            {
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
            }
            catch (Exception exx)
            {
                if (exx is UnauthorizedAccessException)
                    result = "ErrorLogDir de�erine kay�tl� dizine yazma izni yok";
            }

            if (result == "OK")
            {
                FileStream fs = new FileStream(dir + "\\Err_" + DateTime.Now.ToString("yyyyMMdd_hh_mm") + ".log",
                                               FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                string str = "";
                str += ("[ERROR LOG V1]");
                str += Environment.NewLine;
                str += Environment.NewLine + (String.Format("Time = {0} ", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")));
                str += Environment.NewLine + (String.Format("Source = {0} ({1})", typeofSender.FullName, typeofSender.GetHashCode()));
                str += Environment.NewLine + (String.Format("Version = {0} ", AssemblyVersion));
                str += Environment.NewLine + (String.Format("Culture = {0} ", System.Globalization.CultureInfo.CurrentCulture.ToString()));
                str += Environment.NewLine;
                str += Environment.NewLine + ("Exception:");
                str += Environment.NewLine + (ex.ToString());
                str += Environment.NewLine + "Extra Information : " + extraInformation + Environment.NewLine;
                str += Environment.NewLine + ("[/ERROR LOG V1]") + Environment.NewLine;
                sw.WriteLine(str);
                sw.Close();
                if (raporGondericiGoster)
                {
#if PencereGoster
                    frmErrorHandler frm = new frmErrorHandler();
                    frm.Bilesenler = Bilesenler;
                    frm.ShowDialog(str);
#else
                    Program.myMainForm.myIcon.BalloonTipTitle="Avukatpro YeniNesil";
                    Program.myMainForm.myIcon.BalloonTipText= "Yap�lan i�lemde bir hata olu�tu. �al��man�za devam edebilirsiniz."+Environment.NewLine +
                        "Hata ayr�nt�lar�n� g�rmek i�in t�klay�n�z";
                    Program.myMainForm.myIcon.BalloonTipIcon = ToolTipIcon.Error;

                    //Program.myMainForm.myIcon.Tag = str;
                    //Program.myMainForm.myIcon.Text = "HATA";
                    Program.myMainForm.HataIcerigi = str;
                    Program.myMainForm.myIcon.ShowBalloonTip(10000);
#endif
                }
            }

            return result;
        }

        ///<summary>
        ///Yakalanan hatalar�n g�nderildi�i method.
        ///</summary>
        ///<param name="sender">Hatan�n yakaland��� yerdeki instance (this)</param>
        ///<param name="ex">Yakalanan hata</param>
        ///<param name="raporGondericiGoster">Hata rapor g�nderme penceresini a�ma durumu</param>
        ///<param name="Bilesenler">Hatan�n g�nderildi�i yerdeki bile�enler.</param>
        ///<returns>Yazabildi�inde OK de�eri d�ner</returns>
        public static string Catch(object sender, Exception ex, bool raporGondericiGoster, params Bilesen[] Bilesenler)
        {
            BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
            string result = "OK";
            string dir;
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings.Get("ErrorLogDir") == null)
                    System.Configuration.ConfigurationManager.AppSettings.Add("ErrorLogDir", Application.StartupPath + "\\AVP_ERR");
                else
                    System.Configuration.ConfigurationManager.AppSettings.Set("ErrorLogDir", Application.StartupPath + "\\AVP_ERR");

                dir = System.Configuration.ConfigurationManager.AppSettings["ErrorLogDir"];
            }
            catch (Exception)
            {
                dir = "C:\\AVP_ERR";
            }
            try
            {
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
            }
            catch (Exception exx)
            {
                if (exx is UnauthorizedAccessException)
                    result = "ErrorLogDir de�erine kay�tl� dizine yazma izni yok";
            }

            if (result == "OK")
            {
                FileStream fs = new FileStream(dir + "\\Err_" + DateTime.Now.ToString("yyyyMMdd_hh_mm") + ".log",
                                               FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                string str = "";
                str += ("[ERROR LOG V1]");
                str += Environment.NewLine;
                str += Environment.NewLine + (String.Format("Time = {0} ", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")));
                str += Environment.NewLine + (String.Format("Source = {0} ({1})", sender.GetType().FullName, sender.GetHashCode()));
                str += Environment.NewLine + (String.Format("Version = {0} ", AssemblyVersion));
                str += Environment.NewLine + (String.Format("Culture = {0} ", System.Globalization.CultureInfo.CurrentCulture.ToString()));
                str += Environment.NewLine;
                str += Environment.NewLine + ("Exception:");
                str += Environment.NewLine + (ex.ToString());
                str += Environment.NewLine + ("[/ERROR LOG V1]") + Environment.NewLine;
                sw.WriteLine(str);
                sw.Close();
                if (raporGondericiGoster)
                {
#if PencereGoster
                    frmErrorHandler frm = new frmErrorHandler();
                    frm.Bilesenler = Bilesenler;
                    frm.ShowDialog(str);
#else
                    if (Program.myMainForm != null)
                    {
                    Program.myMainForm.myIcon.BalloonTipTitle="Avukatpro YeniNesil";
                    Program.myMainForm.myIcon.BalloonTipText= "Yap�lan i�lemde bir hata olu�tu. �al��man�za devam edebilirsiniz. Hata ayr�nt�lar�n� g�rmek i�in t�klay�n�z";
                    Program.myMainForm.myIcon.BalloonTipIcon = ToolTipIcon.Error;

                    //Program.myMainForm.myIcon.Tag = str;
                    //Program.myMainForm.myIcon.Text = "HATA";
                    Program.myMainForm.HataIcerigi = str;
                    Program.myMainForm.myIcon.ShowBalloonTip(10000);
                    }
#endif
                }
            }

            return result;
        }

        #endregion JIRA Sonrasi Methodlar
    }
}