using AvukatPro.Net.Mail;
using AvukatProLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;

namespace Avukatpro.Reminder
{
    public partial class AvukatproReminderService : ServiceBase
    {
        public AvukatproReminderService()
        {
            InitializeComponent();
            TimerTaskChecker = new Timer();
        }

        private List<int> bildirilenIdler;
        private SmtpClient client;
        private DateTime comp1;
        private AVPReminderDataContext context;
        private SMSMakinesi.Gateway sms;
        private string SMSGonderen;
        private string SMSKullaniciAdi;
        private string SMSSaglayici;
        private string SMSSifre;
        private string SMSVendorID;
        private string SMSZamanAsimi;
        private CompInfo smtpInfo;
        private int taskCheckerInterval = 60000;
        private Timer TimerTaskChecker;

        public static bool isEmail(string inputEmail)
        {
            if (String.IsNullOrEmpty(inputEmail))
                return false;

            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        public static bool isMobile(string mobileNo)
        {
            char[] mobilePhChars = new char[] { '+', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            foreach (char tmp in mobileNo)
            {
                if (!mobilePhChars.Contains(tmp))
                    return false;
            }
            return true;
        }

        public List<DayOfWeek> OutlookToHaftaninGunleri(int deger)
        {
            List<DayOfWeek> gunler = new List<DayOfWeek>();
            string bits = Convert.ToString(deger, 2);
            int k = 0;
            for (int i = bits.Length - 1; i >= 0; i--)
            {
                if (bits[i] == '1')
                    gunler.Add((DayOfWeek)k);
                k++;
            }
            return gunler;
        }

        public string TurkceKarakterleriDuzelt(string str)
        {
            str = str.Replace("ç", "c");
            str = str.Replace("ı", "i");
            str = str.Replace("ğ", "g");
            str = str.Replace("ö", "o");
            str = str.Replace("ş", "s");
            str = str.Replace("ü", "u");
            str = str.Replace("İ", "I");
            str = str.Replace("Ğ", "G;");
            str = str.Replace("Ö", "O");
            str = str.Replace("Ş", "S");
            str = str.Replace("Ü", "U");
            str = str.Replace("Ç", "C");
            return str;
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                sms = new SMSMakinesi.Gateway();
                smtpInfo = CompInfo.CmpNfoList[0];
                SMSKullaniciAdi = smtpInfo.SMSKullaniciAdi;
                SMSSifre = smtpInfo.SMSSifre;
                SMSVendorID = smtpInfo.SMSServisSaglayiciID;
                SMSSaglayici = smtpInfo.SMSServisSaglayici;
                if (!String.IsNullOrEmpty(smtpInfo.SMSGonderen))
                    SMSGonderen = smtpInfo.SMSGonderen.Trim();
                SMSZamanAsimi = smtpInfo.SMSMaxGonderimSuresi;
                client = new SmtpClient();
                client.SmtpServer = smtpInfo.SMTPSunucuAdresi;
                if (!String.IsNullOrEmpty(smtpInfo.SMTPPort))
                    client.SmtpPort = Convert.ToInt32(smtpInfo.SMTPPort);
                client.UserName = smtpInfo.SMTPKullaniciAdi;
                client.Password = smtpInfo.SMTPSifre;
                context = new AVPReminderDataContext(smtpInfo.ConStr);
                TimerTaskChecker = new System.Timers.Timer();
                bildirilenIdler = new List<int>();
            }
            catch 
            {
                
            }

            if (args.Length > 0)
            {
                try
                {
                    taskCheckerInterval = Convert.ToInt32(args[0].ToString());
                }
                catch
                {
                    taskCheckerInterval = 60000;
                }
            }

            TimerTaskChecker.Interval = taskCheckerInterval;
            TimerTaskChecker.Elapsed += new ElapsedEventHandler(TimerTaskChecker_Elapsed);
            TimerTaskChecker.Start();
        }

        protected override void OnStop()
        {
        }

        private string CepTelFormatla(string tel)
        {
            if (tel.Length >= 10)
                return tel.Substring(tel.Length - 10, 10);
            return String.Empty;
        }

        private void TimerTaskChecker_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime date = DateTime.Now;
            comp1 = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0, 0);
            bildirilenIdler.Clear();
            var aktifHatirlatmalar = context.per_REMINDERs.Where(h => h.HATIRLATILSIN_MI == true && (h.HATIRLATMA_TIPI == "1" || h.HATIRLATMA_TIPI == "2"));

            List<per_REMINDER> hatirlatmalar = aktifHatirlatmalar.Where(h => h.HATIRLATMA_BASLAMA_TARIHI.HasValue && h.GUNLUK_UYARI_SAAT == (comp1.Hour + ":" + comp1.Minute).ToString() && h.HATIRLATMA_BASLAMA_TARIHI.Value.DayOfYear >= comp1.AddDays((int)h.TEKRAR).DayOfYear && h.BITIS_TARIHI != null).ToList();

            List<per_REMINDER> bildirimler = aktifHatirlatmalar.Where(b => b.BIR_DEFA_PATLAMASI_OLDU_MU == true && b.ENSON_EXTRA_1_GUN_ONCE == null).ToList();

            List<per_REMINDER> tamamlananlar = aktifHatirlatmalar.Where(t => t.GOSTERSIN_MI_1_GUN_ONCE == true && DateTime.Compare((DateTime)t.BITIS_TARIHI, comp1) == 0).ToList();

            List<per_REMINDER> tamamlanmayanlar = aktifHatirlatmalar.Where(h => h.PERIYODUN_SON_PATLAMASI_OLDU_MU == true && DateTime.Compare((DateTime)h.ONGORULEN_BITIS_TARIHI, comp1) == 0 && h.BITIS_TARIHI != null).ToList();

            #region Hatırlatma Yap

            if (hatirlatmalar.Count > 0)
            {
                foreach (var hatirlatma in hatirlatmalar)
                {
                    if (hatirlatma.HATIRLATMA_TIPI == "1" && !string.IsNullOrEmpty(hatirlatma.EMAIL_1))
                    {
                        MailMessage newmail = new MailMessage();

                        newmail.From = client.UserName;
                        newmail.To = hatirlatma.EMAIL_1;
                        newmail.MailType = MailEncodingType.HTML;

                        if (!String.IsNullOrEmpty(hatirlatma.DOSYA_ADI))
                        {
                            string[] DOSYA_ADI = hatirlatma.DOSYA_ADI.Split('\\');

                            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + DOSYA_ADI[DOSYA_ADI.Length - 1];
                            File.WriteAllBytes(filePath, hatirlatma.ICERIK.ToArray());
                            Attachment attach = new Attachment(filePath);

                            newmail.Attachments.Add(attach);
                        }

                        newmail.Subject = TurkceKarakterleriDuzelt("Hatırlatma: " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString() + " tarihi ve " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortTimeString() + " saatinde tamamlanmasi gereken işiniz var");

                        StringBuilder mail = new StringBuilder(193);
                        mail.AppendLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                        mail.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
                        mail.AppendFormat(@"<head>");

                        mail.AppendLine("<META http-equiv=\"Content-Type\" content=\"text/html\"; charset=\"UTF-8\">");
                        mail.AppendFormat(@"<title></title>");

                        mail.AppendFormat(@"</head>");
                        mail.AppendFormat(@"<body><br>[ICERIKBURADAOLACAK]</body></html>");
                        newmail.Message = mail.ToString();

                        newmail.Message = newmail.Message.Replace("[ICERIKBURADAOLACAK]",
                            "<br><b>Kimden :</b> " + newmail.From +
                            "<br><b>Baslangıç Tarihi :</b> " + hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy H:mm") + "<br><b>Bitiş Tarihi :</b> " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToString("dd/MM/yyyy H:mm") +
                            "<br><b>Bilgi :</b> " + hatirlatma.ADLIYE + "/" + hatirlatma.NO + "/" + hatirlatma.GOREV + " - " + hatirlatma.ESAS_NO +
                            "<br><br><b>Görev :</b> " + hatirlatma.YAPILACAK_IS +
                            "<br><br><b>Açıklama :</b> " + hatirlatma.ACIKLAMA +
                            "<br><br><br><font color=blue>Not: Bu mail Avukatpro Yeni Nesil Asistanı tarafından otomatik olarak gönderilmiştir.</font>");
                        newmail.Message = TurkceKarakterleriDuzelt(newmail.Message);

                        try
                        {
                            client.SendMail(newmail);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    else if (hatirlatma.HATIRLATMA_TIPI == "2" && !string.IsNullOrEmpty(hatirlatma.CEP_TEL))
                    {
                        if (sms == null)
                            sms = new SMSMakinesi.Gateway();

                        StringBuilder mesaj = new StringBuilder();
                        mesaj.Append("Yeni bir iş aldınız. Detay: ");

                        if (!String.IsNullOrEmpty(hatirlatma.ADLIYE))
                            mesaj.Append(hatirlatma.ADLIYE + "/");
                        if (!String.IsNullOrEmpty(hatirlatma.NO))
                            mesaj.Append(hatirlatma.NO + "/");
                        if (!String.IsNullOrEmpty(hatirlatma.GOREV))
                            mesaj.Append(hatirlatma.GOREV + "/");
                        if (!String.IsNullOrEmpty(hatirlatma.ESAS_NO))
                            mesaj.Append(hatirlatma.ESAS_NO + "-");
                        if (hatirlatma.BASLANGIC_TARIHI.HasValue)
                            mesaj.Append(hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy H:mm") + "-");
                        if (!String.IsNullOrEmpty(hatirlatma.YAPILACAK_IS))
                            mesaj.Append(hatirlatma.YAPILACAK_IS);

                        sms.clearsmsbasket();

                        if (mesaj.ToString() != string.Empty)
                            sms.addtosmsbasket(TKCeptDuzelt(mesaj.ToString()), CepTelFormatla(hatirlatma.CEP_TEL.Trim()));
                        string result;
                        if (mesaj.Length <= 160)
                            result = sms.sendsms(SMSKullaniciAdi, SMSSifre, SMSGonderen, "", SMSVendorID);
                        else
                            result = sms.sendsmsconcat(SMSKullaniciAdi, SMSSifre, SMSGonderen, "", SMSVendorID);

                        sms.clearsmsbasket();
                    }
                }
            }

            #endregion Hatırlatma Yap

            #region İş bildirimi yap

            if (bildirimler.Count > 0)
            {
                foreach (var hatirlatma in bildirimler)
                {
                    if (hatirlatma.HATIRLATMA_TIPI == "1" && !string.IsNullOrEmpty(hatirlatma.EMAIL_1))
                    {
                        #region mail

                        MailMessage newmail = new MailMessage();

                        newmail.From = client.UserName;
                        newmail.To = hatirlatma.EMAIL_1;
                        newmail.MailType = MailEncodingType.HTML;

                        if (!String.IsNullOrEmpty(hatirlatma.DOSYA_ADI))
                        {
                            string[] DOSYA_ADI = hatirlatma.DOSYA_ADI.Split('\\');

                            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + DOSYA_ADI[DOSYA_ADI.Length - 1];
                            File.WriteAllBytes(filePath, hatirlatma.ICERIK.ToArray());
                            Attachment attach = new Attachment(filePath);

                            newmail.Attachments.Add(attach);
                        }

                        newmail.Subject = TurkceKarakterleriDuzelt("Yeni iş: " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString() + " tarihi ve " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortTimeString() + " saatinde tamamlanmasi gereken yeni bir işiniz var");

                        StringBuilder mail = new StringBuilder(193);
                        mail.AppendLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                        mail.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
                        mail.AppendFormat(@"<head>");

                        mail.AppendLine("<META http-equiv=\"Content-Type\" content=\"text/html\"; charset=\"UTF-8\">");
                        mail.AppendFormat(@"<title></title>");

                        mail.AppendFormat(@"</head>");
                        mail.AppendFormat(@"<body><br>[ICERIKBURADAOLACAK]</body></html>");
                        newmail.Message = mail.ToString();

                        newmail.Message = newmail.Message.Replace("[ICERIKBURADAOLACAK]",
                            "<br><b>Kimden :</b> " + newmail.From +
                            "<br><b>Baslangıç Tarihi :</b> " + hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy H:mm") + "<br><b>Bitiş Tarihi :</b> " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToString("dd/MM/yyyy H:mm") +
                            "<br><b>Bilgi :</b> " + hatirlatma.ADLIYE + "/" + hatirlatma.NO + "/" + hatirlatma.GOREV + " - " + hatirlatma.ESAS_NO +
                            "<br><br><b>Görev :</b> " + hatirlatma.YAPILACAK_IS +
                            "<br><br><b>Açıklama :</b> " + hatirlatma.ACIKLAMA +
                            "<br><br><br><font color=blue>Not: Bu mail Avukatpro Yeni Nesil Asistanı tarafından otomatik olarak gönderilmiştir.</font>");
                        newmail.Message = TurkceKarakterleriDuzelt(newmail.Message);

                        try
                        {
                            client.SendMail(newmail);
                            if (!bildirilenIdler.Contains((int)hatirlatma.HATIRLAT_ID))
                                bildirilenIdler.Add((int)hatirlatma.HATIRLAT_ID);
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                        #endregion mail
                    }
                    else if (hatirlatma.HATIRLATMA_TIPI == "2" && !string.IsNullOrEmpty(hatirlatma.CEP_TEL))
                    {
                        #region sms

                        try
                        {
                            if (sms == null)
                                sms = new SMSMakinesi.Gateway();

                            StringBuilder mesaj = new StringBuilder();
                            mesaj.Append("Yapılması gereken işiniz var. Detay: ");

                            if (!String.IsNullOrEmpty(hatirlatma.ADLIYE))
                                mesaj.Append(hatirlatma.ADLIYE + "/");
                            if (!String.IsNullOrEmpty(hatirlatma.NO))
                                mesaj.Append(hatirlatma.NO + "/");
                            if (!String.IsNullOrEmpty(hatirlatma.GOREV))
                                mesaj.Append(hatirlatma.GOREV + "/");
                            if (!String.IsNullOrEmpty(hatirlatma.ESAS_NO))
                                mesaj.Append(hatirlatma.ESAS_NO + "-");
                            if (hatirlatma.BASLANGIC_TARIHI.HasValue)
                                mesaj.Append(hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy H:mm") + "-");
                            if (!String.IsNullOrEmpty(hatirlatma.YAPILACAK_IS))
                                mesaj.Append(hatirlatma.YAPILACAK_IS);

                            sms.clearsmsbasket();

                            if (mesaj.ToString() != string.Empty)
                                sms.addtosmsbasket(TKCeptDuzelt(mesaj.ToString()), CepTelFormatla(hatirlatma.CEP_TEL.Trim()));
                            string result;
                            if (mesaj.Length <= 160)
                                result = sms.sendsms(SMSKullaniciAdi, SMSSifre, SMSGonderen, "", SMSVendorID);
                            else
                                result = sms.sendsmsconcat(SMSKullaniciAdi, SMSSifre, SMSGonderen, "", SMSVendorID);

                            sms.clearsmsbasket();
                            if (result.Length > 2)
                            {
                                if (!bildirilenIdler.Contains((int)hatirlatma.HATIRLAT_ID))
                                    bildirilenIdler.Add((int)hatirlatma.HATIRLAT_ID);
                            }
                        }
                        catch { ;}

                        #endregion sms
                    }
                }
            }

            #endregion İş bildirimi yap

            #region Tamamlananlari Bildir

            if (tamamlananlar.Count > 0)
            {
                foreach (var hatirlatma in tamamlananlar)
                {
                    if (hatirlatma.HATIRLATMA_TIPI == "1" && !string.IsNullOrEmpty(hatirlatma.EMAIL_1))
                    {
                        MailMessage newmail = new MailMessage();

                        newmail.From = client.UserName;
                        newmail.To = hatirlatma.EMAIL_1;
                        newmail.MailType = MailEncodingType.HTML;

                        if (!String.IsNullOrEmpty(hatirlatma.DOSYA_ADI))
                        {
                            string[] DOSYA_ADI = hatirlatma.DOSYA_ADI.Split('\\');

                            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + DOSYA_ADI[DOSYA_ADI.Length - 1];
                            File.WriteAllBytes(filePath, hatirlatma.ICERIK.ToArray());
                            Attachment attach = new Attachment(filePath);

                            newmail.Attachments.Add(attach);
                        }

                        newmail.Subject = TurkceKarakterleriDuzelt("İş Tamamlandı: " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString() + " tarihi ve " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortTimeString() + " saatinde tamamlanmasi iş " + hatirlatma.BITIS_TARIHI.Value.ToShortDateString() + " tarihinde tamamlandı.");

                        StringBuilder mail = new StringBuilder(193);
                        mail.AppendLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                        mail.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
                        mail.AppendFormat(@"<head>");

                        mail.AppendLine("<META http-equiv=\"Content-Type\" content=\"text/html\"; charset=\"UTF-8\">");
                        mail.AppendFormat(@"<title></title>");

                        mail.AppendFormat(@"</head>");
                        mail.AppendFormat(@"<body><br>[ICERIKBURADAOLACAK]</body></html>");
                        newmail.Message = mail.ToString();

                        newmail.Message = newmail.Message.Replace("[ICERIKBURADAOLACAK]",
                            "<br><b>Kimden :</b> " + newmail.From +
                            "<br><b>Baslangıç Tarihi :</b> " + hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy H:mm") + "<br><b>Bitiş Tarihi :</b> " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToString("dd/MM/yyyy H:mm") +
                            "<br><b>Bilgi :</b> " + hatirlatma.ADLIYE + "/" + hatirlatma.NO + "/" + hatirlatma.GOREV + " - " + hatirlatma.ESAS_NO +
                            "<br><br><b>Görev :</b> " + hatirlatma.YAPILACAK_IS +
                            "<br><br><b>Açıklama :</b> " + hatirlatma.ACIKLAMA +
                            "<br><br><br><font color=blue>Not: Bu mail Avukatpro Yeni Nesil Asistanı tarafından otomatik olarak gönderilmiştir.</font>");
                        newmail.Message = TurkceKarakterleriDuzelt(newmail.Message);

                        try
                        {
                            client.SendMail(newmail);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }

                    else if (hatirlatma.HATIRLATMA_TIPI == "2" && !string.IsNullOrEmpty(hatirlatma.CEP_TEL))
                    {
                        if (sms == null)
                            sms = new SMSMakinesi.Gateway();

                        StringBuilder mesaj = new StringBuilder();
                        mesaj.Append("Tamamlanan iş. Detay: ");

                        if (!String.IsNullOrEmpty(hatirlatma.ADLIYE))
                            mesaj.Append(hatirlatma.ADLIYE + "/");
                        if (!String.IsNullOrEmpty(hatirlatma.NO))
                            mesaj.Append(hatirlatma.NO + "/");
                        if (!String.IsNullOrEmpty(hatirlatma.GOREV))
                            mesaj.Append(hatirlatma.GOREV + "/");
                        if (!String.IsNullOrEmpty(hatirlatma.ESAS_NO))
                            mesaj.Append(hatirlatma.ESAS_NO + "-");
                        if (hatirlatma.BASLANGIC_TARIHI.HasValue)
                            mesaj.Append(hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy H:mm") + "-");
                        if (!String.IsNullOrEmpty(hatirlatma.YAPILACAK_IS))
                            mesaj.Append(hatirlatma.YAPILACAK_IS);

                        sms.clearsmsbasket();

                        if (mesaj.ToString() != string.Empty)
                            sms.addtosmsbasket(TKCeptDuzelt(mesaj.ToString()), CepTelFormatla(hatirlatma.CEP_TEL.Trim()));
                        string result;
                        if (mesaj.Length <= 160)
                            result = sms.sendsms(SMSKullaniciAdi, SMSSifre, SMSGonderen, "", SMSVendorID);
                        else
                            result = sms.sendsmsconcat(SMSKullaniciAdi, SMSSifre, SMSGonderen, "", SMSVendorID);

                        sms.clearsmsbasket();
                    }
                }
            }

            #endregion Tamamlananlari Bildir

            #region Tamamlanmayanları Bildir

            if (tamamlanmayanlar.Count > 0)
            {
                foreach (var hatirlatma in tamamlanmayanlar)
                {
                    if (hatirlatma.HATIRLATMA_TIPI == "1" && !string.IsNullOrEmpty(hatirlatma.EMAIL_1))
                    {
                        MailMessage newmail = new MailMessage();

                        newmail.From = client.UserName;
                        newmail.To = hatirlatma.EMAIL_1;
                        newmail.MailType = MailEncodingType.HTML;

                        if (!String.IsNullOrEmpty(hatirlatma.DOSYA_ADI))
                        {
                            string[] DOSYA_ADI = hatirlatma.DOSYA_ADI.Split('\\');

                            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + DOSYA_ADI[DOSYA_ADI.Length - 1];
                            File.WriteAllBytes(filePath, hatirlatma.ICERIK.ToArray());
                            Attachment attach = new Attachment(filePath);

                            newmail.Attachments.Add(attach);
                        }

                        newmail.Subject = TurkceKarakterleriDuzelt("İş zamanında bitirilmedi: " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString() + " tarihi ve " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortTimeString() + " saatinde tamamlanmasi gereken yeni iş zamanında bitirilmedi.");

                        StringBuilder mail = new StringBuilder(193);
                        mail.AppendLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                        mail.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
                        mail.AppendFormat(@"<head>");

                        mail.AppendLine("<META http-equiv=\"Content-Type\" content=\"text/html\"; charset=\"UTF-8\">");
                        mail.AppendFormat(@"<title></title>");

                        mail.AppendFormat(@"</head>");
                        mail.AppendFormat(@"<body><br>[ICERIKBURADAOLACAK]</body></html>");
                        newmail.Message = mail.ToString();

                        newmail.Message = newmail.Message.Replace("[ICERIKBURADAOLACAK]",
                            "<br><b>Kimden :</b> " + newmail.From +
                            "<br><b>Baslangıç Tarihi :</b> " + hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy H:mm") + "<br><b>Bitiş Tarihi :</b> " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToString("dd/MM/yyyy H:mm") +
                            "<br><b>Bilgi :</b> " + hatirlatma.ADLIYE + "/" + hatirlatma.NO + "/" + hatirlatma.GOREV + " - " + hatirlatma.ESAS_NO +
                            "<br><br><b>Görev :</b> " + hatirlatma.YAPILACAK_IS +
                            "<br><br><b>Açıklama :</b> " + hatirlatma.ACIKLAMA +
                            "<br><br><br><font color=blue>Not: Bu mail Avukatpro Yeni Nesil Asistanı tarafından otomatik olarak gönderilmiştir.</font>");
                        newmail.Message = TurkceKarakterleriDuzelt(newmail.Message);

                        try
                        {
                            client.SendMail(newmail);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }

                    else if (hatirlatma.HATIRLATMA_TIPI == "2" && !string.IsNullOrEmpty(hatirlatma.CEP_TEL))
                    {
                        if (sms == null)
                            sms = new SMSMakinesi.Gateway();

                        StringBuilder mesaj = new StringBuilder();
                        mesaj.Append("İş zamanında bitirilmedi. Detay: ");

                        if (!String.IsNullOrEmpty(hatirlatma.ADLIYE))
                            mesaj.Append(hatirlatma.ADLIYE + "/");
                        if (!String.IsNullOrEmpty(hatirlatma.NO))
                            mesaj.Append(hatirlatma.NO + "/");
                        if (!String.IsNullOrEmpty(hatirlatma.GOREV))
                            mesaj.Append(hatirlatma.GOREV + "/");
                        if (!String.IsNullOrEmpty(hatirlatma.ESAS_NO))
                            mesaj.Append(hatirlatma.ESAS_NO + "-");
                        if (hatirlatma.BASLANGIC_TARIHI.HasValue)
                            mesaj.Append(hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy H:mm") + "-");
                        if (!String.IsNullOrEmpty(hatirlatma.YAPILACAK_IS))
                            mesaj.Append(hatirlatma.YAPILACAK_IS);

                        sms.clearsmsbasket();

                        if (mesaj.ToString() != string.Empty)
                            sms.addtosmsbasket(TKCeptDuzelt(mesaj.ToString()), CepTelFormatla(hatirlatma.CEP_TEL.Trim()));
                        string result;
                        if (mesaj.Length <= 160)
                            result = sms.sendsms(SMSKullaniciAdi, SMSSifre, SMSGonderen, "", SMSVendorID);
                        else
                            result = sms.sendsmsconcat(SMSKullaniciAdi, SMSSifre, SMSGonderen, "", SMSVendorID);

                        sms.clearsmsbasket();
                    }
                }
            }

            #endregion Tamamlanmayanları Bildir

            #region Bildirilen hatırlatmaları güncelle

            if (bildirilenIdler.Count > 0)
            {
                SqlConnection con = new SqlConnection(smtpInfo.ConStr);
                foreach (var id in bildirilenIdler)
                {
                    SqlCommand cmd = new SqlCommand(@"UPDATE AV001_TDI_BIL_HATIRLAT
                                                                      SET
                                                                      ENSON_EXTRA_1_GUN_ONCE=getdate()
                                                                      WHERE ID=@ID", con);
                    cmd.Parameters.Add("@ID", id);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    if (con.State == System.Data.ConnectionState.Open)
                        con.Close();
                }
                con.Dispose();
            }

            #endregion Bildirilen hatırlatmaları güncelle
        }

        private string TKCeptDuzelt(string str)
        {
            str = str.Replace("ç", "c");
            str = str.Replace("ı", "i");
            str = str.Replace("ğ", "g");
            str = str.Replace("ö", "o");
            str = str.Replace("ş", "s");
            str = str.Replace("ü", "u");
            str = str.Replace("İ", "I");
            str = str.Replace("Ğ", "G");
            str = str.Replace("Ö", "O");
            str = str.Replace("Ş", "S");
            str = str.Replace("Ü", "U");
            str = str.Replace("Ç", "C");
            return str;
        }
    }
}