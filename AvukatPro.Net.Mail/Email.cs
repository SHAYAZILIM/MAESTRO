using System;
using System.Collections;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace AvukatPro.Net.Mail
{
    public class Email
    {
        public Email()
        {
            //this._Password
        }

        private ArrayList _Attachments;

        private string _Bcc;

        private string _Cc;

        private bool _DefaultCredentials;

        private string _From;

        private string _MailMessage;

        private string _Password;

        private string _SmtpPort;

        private string _SmtpServer;

        private string _Subject;

        private string _To;

        private string _UserName;

        private bool _UseSSL;

        public event EventHandler OnMailSended;

        public ArrayList Attachments
        {
            get { return _Attachments; }
            set { _Attachments = value; }
        }

        public string Bcc
        {
            get { return _Bcc; }
            set { _Bcc = value; }
        }

        public string Cc
        {
            get { return _Cc; }
            set { _Cc = value; }
        }

        public bool DefaultCredentials
        {
            get { return _DefaultCredentials; }
            set { _DefaultCredentials = value; }
        }

        public string From
        {
            get { return _From; }
            set { _From = value; }
        }

        public string MailMessage
        {
            get { return _MailMessage; }
            set { _MailMessage = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string SmtpPort
        {
            get { return _SmtpPort; }
            set { _SmtpPort = value; }
        }

        public string SmtpServer
        {
            get { return _SmtpServer; }
            set { _SmtpServer = value; }
        }

        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        public string To
        {
            get { return _To; }
            set { _To = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public bool UseSSL
        {
            get { return _UseSSL; }
            set { _UseSSL = value; }
        }

        public void Send()
        {
            if (this.CheckInputValidation(SmtpServer, SmtpPort, UserName
                , Password, From, To, Cc, Bcc))
            {
                if (this.EmailValidation(this.From))
                {
                    bool isRecipient = false;

                    if (this.To.Length > 0)
                    {
                        if (this.RecipientsEmailValidation(this.To))
                        {
                            isRecipient = true;
                        }
                        else
                        {
                            EmailLogger.Logger.Error("Alýcý Adresi Yanlýþ");
                            return;
                        }
                    }

                    if (this.Cc != null && this.Cc.Length > 0)
                    {
                        if (!(this.RecipientsEmailValidation(this.Cc)))
                        {
                            EmailLogger.Logger.Error("Alýcý Adresi Yanlýþ Formatta.");
                            return;
                        }
                        else
                        {
                            isRecipient = true;
                        }
                    }

                    if (this.Bcc != null && this.Bcc.Length > 0)
                    {
                        if (!(this.RecipientsEmailValidation(this.Bcc)))
                        {
                            EmailLogger.Logger.Error("Alýcý Adresi Yanlýþ Formatta.");
                            return;
                        }
                        else
                        {
                            isRecipient = true;
                        }
                    }
                    if (Internet.IsConnectedToInternet())
                    {
                        if (isRecipient == true)
                        {
                            MailMessage mail_message = new MailMessage();
                            mail_message.From = this.From;
                            mail_message.To = this.To;
                            mail_message.CC = this.Cc;
                            mail_message.BCC = this.Bcc;
                            mail_message.Subject = this.Subject;
                            mail_message.MailType = MailEncodingType.HTML;
                            mail_message.MailPriority = MailSendPriority.NORMAL;
                            mail_message.Message = this.MailMessage;
                            mail_message.Attachments = this.Attachments;

                            Thread thread = new Thread(new ParameterizedThreadStart(this.SendEmail));
                            thread.Start(mail_message);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        EmailLogger.Logger.Error("Ýnternet Baðlantýnýzý Kontrol ediniz.");
                    }
                }
                else
                {
                    EmailLogger.Logger.Error("Gönderi Adresi yanlýþ formatta.");
                }
            }
        }

        public void Send(bool pop3)
        {
            if (pop3)
            {
                try
                {
                    if (this.CheckInputValidation(SmtpServer, SmtpPort, UserName
                , Password, From, To, Cc, Bcc))
                    {
                        if (this.EmailValidation(this.From))
                        {
                            bool isRecipient = false;

                            if (this.To.Length > 0)
                            {
                                if (this.RecipientsEmailValidation(this.To))
                                {
                                    isRecipient = true;
                                }
                                else
                                {
                                    EmailLogger.Logger.Error("Alýcý Adresi Yanlýþ");
                                    return;
                                }
                            }

                            if (this.Cc != null && this.Cc.Length > 0)
                            {
                                if (!(this.RecipientsEmailValidation(this.Cc)))
                                {
                                    EmailLogger.Logger.Error("Alýcý Adresi Yanlýþ Formatta.");
                                    return;
                                }
                                else
                                {
                                    isRecipient = true;
                                }
                            }

                            if (this.Bcc != null && this.Bcc.Length > 0)
                            {
                                if (!(this.RecipientsEmailValidation(this.Bcc)))
                                {
                                    EmailLogger.Logger.Error("Alýcý Adresi Yanlýþ Formatta.");
                                    return;
                                }
                                else
                                {
                                    isRecipient = true;
                                }
                            }
                            if (Internet.IsConnectedToInternet())
                            {
                                if (isRecipient == true)
                                {
                                    System.Net.Mail.MailMessage item = new System.Net.Mail.MailMessage();
                                    item.From = new MailAddress(this.From);
                                    item.To.Add(new MailAddress(this.To));
                                    item.Subject = this.Subject;
                                    item.Body = this.MailMessage;
                                    foreach (var itm in this.Attachments)
                                    {
                                        item.Attachments.Add(new System.Net.Mail.Attachment(itm.ToString()));
                                    }
                                    if (this.Cc != null && this.Cc != "")
                                        item.CC.Add(this.Cc);
                                    if (this.Bcc != null && this.Bcc != "")
                                        item.Bcc.Add(this.Bcc);
                                    item.BodyEncoding = Encoding.GetEncoding("Windows-1254");
                                    item.IsBodyHtml = true;
                                    if (this.Cc != null && this.Cc != "")
                                        item.ReplyTo = new MailAddress(this.Cc);
                                    item.SubjectEncoding = Encoding.GetEncoding("Windows-1254");
                                    System.Net.Mail.SmtpClient Smtp = new System.Net.Mail.SmtpClient();
                                    Smtp.Host = SmtpServer;
                                    Smtp.EnableSsl = UseSSL;
                                    Smtp.UseDefaultCredentials = DefaultCredentials;
                                    if (SmtpPort != "0")
                                        Smtp.Port = int.Parse(SmtpPort);

                                    if (!DefaultCredentials)
                                    {
                                        Smtp.Credentials = new System.Net.NetworkCredential(UserName, Password);
                                    }
                                    Smtp.Send(item);
                                    Smtp.SendCompleted += new SendCompletedEventHandler(Smtp_SendCompleted);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                EmailLogger.Logger.Error("Ýnternet Baðlantýnýzý Kontrol ediniz.");
                            }
                        }
                        else
                        {
                            EmailLogger.Logger.Error("Gönderi Adresi yanlýþ formatta.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    EmailLogger.Logger.ErrorException("Hata", ex);
                }
                if (OnMailSended != null)
                    OnMailSended(this, new EventArgs());
            }
            else
            {
                Send();
            }
        }

        //
        private bool CheckInputValidation(string smtp_server, string smtp_port
            , string user_name, string password, string from, string to
            , string cc, string bcc)
        {
            if (smtp_server.Equals(""))
            {
                EmailLogger.Logger.Error("Smtp Server adresi girilmeli");
                return false;
            }
            else if (smtp_port.Equals(""))
            {
                EmailLogger.Logger.Error("Smtp Server portu girilmeli");
                return false;
            }
            else if (user_name.Equals(""))
            {
                EmailLogger.Logger.Error("Smtp Server için kullanýcý adý girilmeli");
                return false;
            }
            else if (password.Equals(""))
            {
                EmailLogger.Logger.Error("Smtp Server için þifre girilmeli");
                return false;
            }
            else if (from.Equals(""))
            {
                EmailLogger.Logger.Error("Gönderen adresi girilmeli");
                return false;
            }
            else if ((!(to.Equals(""))) || (!(cc.Equals(""))) || (!(bcc.Equals(""))))
            {
                return true;
            }
            else if (to.Equals("") && cc.Equals("") && bcc.Equals(""))
            {
                EmailLogger.Logger.Error("Alýcý adresi girilmeli");
                return false;
            }

            return true;
        }

        //
        private bool EmailValidation(string email)
        {
            Regex regx = new Regex(@"([a-zA-Z_0-9.-]+\@[a-zA-Z_0-9.-]+\.\w+)", RegexOptions.IgnoreCase);
            if (regx.IsMatch(email))
            {
                return true;
            }
            return false;
        }

        //
        private bool RecipientsEmailValidation(string recipient)
        {
            string[] splits = recipient.Split(new char[] { ',', ';' });

            for (int i = 0; i < splits.Length; i++)
            {
                if (this.EmailValidation(splits[i]))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        //
        private void SendEmail(object mail_msg)
        {
            try
            {
                MailMessage mail_message = (MailMessage)mail_msg;
                SmtpClient smtp = new SmtpClient(this.SmtpServer, Convert.ToInt32(this.SmtpPort));
                smtp.UserName = this.UserName;
                smtp.Password = this.Password;
                smtp.SendMail(mail_message);
            }
            catch (SmtpClientException obj)
            {
                EmailLogger.Logger.ErrorException("Hata", obj);
            }
            if (OnMailSended != null)
                OnMailSended(this, new EventArgs());
        }

        private void Smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (OnMailSended != null)
                OnMailSended(this, new EventArgs());
        }
    }

    public class EmailLogger
    {
        private static NLog.Logger _Logger = NLog.LogManager.GetCurrentClassLogger();

        public static NLog.Logger Logger
        {
            get { return EmailLogger._Logger; }
            set { EmailLogger._Logger = value; }
        }
    }
}