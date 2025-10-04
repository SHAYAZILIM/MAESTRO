using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using AvukatProLib.Extras;
using AvukatProLib.Hesap.Views;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Util
{
    public static class DosyaAvukatIliski
    {
        public static TList<AV001_TDIE_BIL_DOSYA_AVUKAT_ILISKILERI> DosyaList { get; set; }

        public static int SorumluAvukatCariID { get; set; }

        public static int DosyaID { get; set; }

        public static Modul Modul { get; set; }

        public static void SendMail(string mailAdresTo, string body)
        {
            BackgroundWorker bck = new BackgroundWorker();

            AvukatProLib.CompInfo MailCompInfo = AvukatProLib.CompInfo.CompInfoListGetir()[0];

            SmtpClient client = new SmtpClient(MailCompInfo.SMTPSunucuAdresi, Convert.ToInt32(MailCompInfo.SMTPPort));
            client.UseDefaultCredentials = false;
            client.EnableSsl = MailCompInfo.SMTPSSL;

            NetworkCredential user = new NetworkCredential(MailCompInfo.SMTPKullaniciAdi, MailCompInfo.SMTPSifre);
            client.Credentials = user;

            bck.DoWork += delegate
            {
                MailMessage msg = new MailMessage(user.UserName, mailAdresTo);

                msg.Subject = "Bilgi";
                msg.Body = body;
                try
                {
                    client.Send(msg);
                }
                catch
                {
                    MessageBox.Show("Lütfen mail ayarlarınızın yapılandırıldığından veya internet bağlantınız olduğundan emin olunuz!", "Mail Gönderme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            if (!bck.IsBusy)
                bck.RunWorkerAsync();
        }

    }
}