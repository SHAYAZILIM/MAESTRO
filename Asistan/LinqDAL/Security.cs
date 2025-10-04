using Asistan.Util;
using AvukatPro.Net.Mail;
using AvukatProLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Asistan.LinqDAL
{
    public static class Security
    {
        private static bool _IsLogin = false;

        private static TDI_BIL_KULLANICI_LISTESI _User;

        public static event EventHandler OnLogon;

        public static event EventHandler OnLogOut;

        public static Email Email { get; set; }

        public static bool IsLogin
        {
            get { return _IsLogin; }
            set { _IsLogin = value; }
        }

        public static TDI_BIL_KULLANICI_LISTESI User
        {
            get { return Security._User; }
            set { Security._User = value; }
        }

        public static bool Logon(string username, string password)
        {
            try
            {
                List<CompInfo> sList = CompInfo.CompInfoListGetir();
                Isler.dbAsistan = new DbAsistanDataContext(sList[0].ConStr);
                _User = Isler.dbAsistan.TDI_BIL_KULLANICI_LISTESIs.Where(vi => vi.KULLANICI_ADI == username
                    && vi.KULLANICI_SIFRESI == password).First();
            }
            catch (Exception ex)
            {
                AsistanLogger.Logger.ErrorException("Hata", ex);
            }
            IsLogin = _User != null ? true : false;
            if (IsLogin)
            {
                if (_User.TDIE_BIL_KULLANICI_GENEL_AYARs.Count > 0)
                {
                    Email = new Email();
                    Email.SmtpServer = _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].HOST;
                    Email.SmtpPort = _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].PORT.ToString();
                    Email.UserName = _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].MAIL_KULLANICI_ADI;
                    Email.Password = _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].MAIL_KULLANICI_SIFRE;
                    Email.From = Email.UserName;
                    Email.UseSSL = _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].SSL_KULLAN.HasValue ? _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].SSL_KULLAN.Value : false;
                    Email.DefaultCredentials = _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].VARSAYILAN_GUVENLIK.HasValue ? _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].VARSAYILAN_GUVENLIK.Value : false;
                    Email.OnMailSended += new EventHandler(Email_OnMailSended);
                }
            }
            if (OnLogon != null)
                OnLogon(Security.User, new EventArgs());
            return IsLogin;
        }

        public static bool Logon()
        {
            try
            {
                List<CompInfo> sList = CompInfo.CompInfoListGetir();
                Isler.dbAsistan = new DbAsistanDataContext(sList[0].ConStr);
                _User = Isler.dbAsistan.TDI_BIL_KULLANICI_LISTESIs.Where(vi => vi.KULLANICI_ADI == Program.KullaniciAdi).First();
            }
            catch (Exception ex)
            {
                AsistanLogger.Logger.ErrorException("Hata", ex);
            }
            IsLogin = _User != null ? true : false;
            if (IsLogin)
            {
                if (_User.TDIE_BIL_KULLANICI_GENEL_AYARs.Count > 0)
                {
                    Email = new Email();
                    Email.SmtpServer = _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].HOST;
                    Email.SmtpPort = _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].PORT.ToString();
                    Email.UserName = _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].MAIL_KULLANICI_ADI;
                    Email.Password = _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].MAIL_KULLANICI_SIFRE;
                    Email.From = Email.UserName;
                    Email.UseSSL = _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].SSL_KULLAN.HasValue ? _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].SSL_KULLAN.Value : false;
                    Email.DefaultCredentials = _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].VARSAYILAN_GUVENLIK.HasValue ? _User.TDIE_BIL_KULLANICI_GENEL_AYARs[0].VARSAYILAN_GUVENLIK.Value : false;
                    Email.OnMailSended += new EventHandler(Email_OnMailSended);
                }
            }
            if (OnLogon != null)
                OnLogon(Security.User, new EventArgs());
            return IsLogin;
        }

        public static void LogOut()
        {
            IsLogin = false;
            if (User != null)
                User = null;
            if (OnLogOut != null)
                OnLogOut(null, new EventArgs());
        }

        private static void Email_OnMailSended(object sender, EventArgs e)
        {
            Email email = (Email)sender;

            foreach (string item in email.Attachments)
            {
                try
                {
                    if (File.Exists(item))
                        File.Delete(item);
                }
                catch (Exception ex)
                {
                    EmailLogger.Logger.ErrorException("Hata", ex);
                }
            }
        }
    }
}