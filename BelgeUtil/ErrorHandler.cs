//Sunum Modu olduðunda Normal Çalýþ kýsmýný comment ediniz.
#define PencereGoster

using NLog;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace BelgeUtil
{
    /// <summary>
    /// Jira tarafýndaki Bileþenleri ifade eden enum
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
    /// Hata Yakalamak ve raporlamak için kullanýlan modül
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
        ///Yakalanan hatalarýn gönderildiði method.
        ///</summary>
        ///<param name="sender">Hatanýn yakalandýðý yerdeki instance (this)</param>
        ///<param name="ex">Yakalanan hata</param>
        ///<returns>Yazabildiðinde OK deðeri döner</returns>
        public static string Catch(object sender, Exception ex)
        {
            return Catch(sender, ex, true);
        }

        ///<summary>
        ///Yakalanan hatalarýn gönderildiði method.
        ///</summary>
        ///<param name="sender">Hatanýn yakalandýðý yerdeki instance (this)</param>
        ///<param name="ex">Yakalanan hata</param>
        ///<param name="raporGondericiGoster">Hata rapor gönderme penceresini açma durumu</param>
        ///<returns>Yazabildiðinde OK deðeri döner</returns>
        public static string Catch(object sender, Exception ex, bool raporGondericiGoster)
        {
            return Catch(sender, ex, raporGondericiGoster, Bilesen.BilesenYok);
        }

        /// <summary>
        /// Yakalanan hatalarýn gönderildiði method.
        /// </summary>
        /// <param name="typeofSender">Hatanýn yakalandýðý yerdeki tip</param>
        /// <param name="ex">Yakalanan hata</param>
        /// <param name="raporGondericiGoster">Hata rapor gönderme penceresini açma durumu</param>
        /// <param name="extraInformation">Hata ile ilgili yazmak istediðini diðer ek
        /// bilgiler.</param>
        /// <returns>Yazabildiðinde OK deðeri döner</returns>
        public static string Catch(Type typeofSender, Exception ex, bool raporGondericiGoster, string extraInformation)
        {
            return Catch(typeofSender, ex, raporGondericiGoster, extraInformation, Bilesen.BilesenYok);
        }

        #endregion Obsolete Methodlar

        #region JIRA Sonrasi Methodlar

        ///<summary>
        ///Yakalanan hatalarýn gönderildiði method.
        ///</summary>
        ///<param name="sender">Hatanýn yakalandýðý yerdeki instance (this)</param>
        ///<param name="ex">Yakalanan hata</param>
        /// <param name="Bilesenler"> Hatanýn gönderildiði yerdeki bileþenler.</param>
        ///<returns>Yazabildiðinde OK deðeri döner</returns>
        public static string Catch(object sender, Exception ex, params Bilesen[] Bilesenler)
        {
            return Catch(sender, ex, true, Bilesenler);
        }

        /// <summary>
        /// Yakalanan hatalarýn gönderildiði method.
        /// </summary>
        /// <param name="typeofSender">Hatanýn yakalandýðý yerdeki tip</param>
        /// <param name="ex">Yakalanan hata</param>
        /// <param name="raporGondericiGoster">Hata rapor gönderme penceresini açma durumu</param>
        /// <param name="extraInformation">Hata ile ilgili yazmak istediðini diðer ek
        /// bilgiler.</param>
        /// <param name="Bilesenler">Hatanýn gönderildiði yerdeki bileþenler.</param>
        /// <returns>Yazabildiðinde OK deðeri döner</returns>
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
                    result = "ErrorLogDir deðerine kayýtlý dizine yazma izni yok";
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
                    Program.myMainForm.myIcon.BalloonTipText= "Yapýlan iþlemde bir hata oluþtu. Çalýþmanýza devam edebilirsiniz."+Environment.NewLine +
                        "Hata ayrýntýlarýný görmek için týklayýnýz";
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
        ///Yakalanan hatalarýn gönderildiði method.
        ///</summary>
        ///<param name="sender">Hatanýn yakalandýðý yerdeki instance (this)</param>
        ///<param name="ex">Yakalanan hata</param>
        ///<param name="raporGondericiGoster">Hata rapor gönderme penceresini açma durumu</param>
        ///<param name="Bilesenler">Hatanýn gönderildiði yerdeki bileþenler.</param>
        ///<returns>Yazabildiðinde OK deðeri döner</returns>
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
                    result = "ErrorLogDir deðerine kayýtlý dizine yazma izni yok";
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
                    Program.myMainForm.myIcon.BalloonTipText= "Yapýlan iþlemde bir hata oluþtu. Çalýþmanýza devam edebilirsiniz. Hata ayrýntýlarýný görmek için týklayýnýz";
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