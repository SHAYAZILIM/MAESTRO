using Asistan.LinqDAL;
using Avukatpro.Reminder;
using AvukatPro.Net.Mail;
using AvukatProLib;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Asistan
{
    public partial class Ajanda : Form
    {
        public Ajanda()
        {
                InitializeComponent();
        }

        private System.Windows.Forms.Timer _Tmr;
        private List<int> bildirilenIdler;

        private SmtpClient client;

        private AVPReminderDataContext context;

        private bool PencereAcik = false;

        private string SMSGonderen;

        private string SMSKullaniciAdi;

        private string SMSSaglayici;

        private string SMSSifre;

        private string SMSVendorID;

        private string SMSZamanAsimi;

        private CompInfo smtpInfo;

        public System.Windows.Forms.Timer Tmr
        {
            get
            {
                if (_Tmr == null)
                {
                    _Tmr = new System.Windows.Forms.Timer();
                    _Tmr.Interval = 30000;
                    _Tmr.Tick += new EventHandler(_Tmr_Tick);
                }
                return _Tmr;
            }
            set { _Tmr = value; }
        }

        public void Yenile()
        {
            if (!PencereAcik)
            {
                Thread th = new Thread(new ThreadStart(delegate
                {
                    if (Security.User != null)
                        Isler.GetAll(Security.User);

                    schedulerControl1.Storage = Isler.SchedulerStorage;
                    if (schedulerControl1.Storage != null)
                        schedulerControl1.Storage.ReminderAlert += new ReminderEventHandler(Storage_ReminderAlert);
                    PencereAcik = false;
                }));
                PencereAcik = true;
                th.Start();
            }
        }

        private void _Tmr_Tick(object sender, EventArgs e)
        {
            if (Security.User != null)
                Yenile();
        }

        private void Ajanda_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Security.IsLogin)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void Ajanda_Load(object sender, EventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            schedulerControl1.Start = DateTime.Now;
            Security.OnLogOut += new EventHandler(Security_OnLogOut);
            Thread th = new Thread(new ThreadStart(delegate
            {

                schedulerControl1.RemindersFormDefaultAction += new RemindersFormDefaultActionEventHandler(schedulerControl1_RemindersFormDefaultAction);

                try
                {
                    //sms = new SMSMakinesi.Gateway();
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
                    bildirilenIdler = new List<int>();
                }
                catch
                {

                }
            }));
            th.Start();

        }

        private void Ajanda_Shown(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(delegate
            {
                schedulerControl1.Storage = Isler.SchedulerStorage;
                if (schedulerControl1.Storage != null)
                    schedulerControl1.Storage.ReminderAlert += new ReminderEventHandler(Storage_ReminderAlert);
                Tmr.Start();
                schedulerControl1.Storage = Isler.SchedulerStorage;
            }));
            th.Start();
        }

        private void Ajanda_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                schedulerControl1.Storage = Isler.SchedulerStorage;
                schedulerControl1.Dock = DockStyle.Fill;
                schedulerControl1.Refresh();
            }
        }

        private void btnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Yenile();
        }

        private void remindersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (PencereAcik)
            {
                PencereAcik = false;
                Yenile();
            }
        }

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);

        const int SW_RESTORE = 9;

        public static void bringToFront(Process proc)
        {
            IntPtr handle = proc.MainWindowHandle;
            if (IsIconic(handle))
            {
                ShowWindow(handle, SW_RESTORE);
            }

            SetForegroundWindow(handle);
        }

        private void schedulerControl1_DoubleClick(object sender, EventArgs e)
        {
            if (schedulerControl1.SelectedAppointments.Count > 0)
            {
                Process[] prs = Process.GetProcesses();
                bool varmi = false;
                foreach (Process pr in prs)
                {
                    if (pr.ProcessName.Contains("avpng"))
                    {
                        varmi = true;
                        bringToFront(pr);
                        break;
                    }
                }
                if (!varmi)
                {
                    System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "avpng.exe"), string.Format("-isKayit {0} {1} {2}", schedulerControl1.SelectedAppointments[0].CustomFields["ID"], Security.User.KULLANICI_ADI, Security.User.KULLANICI_SIFRESI));
                }
                else
                {
                    var file = File.CreateText(Path.Combine(Application.StartupPath, "iskayit.avpis"));
                    file.Write(schedulerControl1.SelectedAppointments[0].CustomFields["ID"]);
                    file.Close();

                    //MessageBox.Show("Avukatpro Maestro programı şuanda açık.\nLütfen bu düzenlemeyi ajanda veya iş listesi üzerinden yapınız.");
                }
            }
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            if (e.Appointment != null)
            {
                Process[] prs = Process.GetProcesses();
                bool varmi = false;
                foreach (Process pr in prs)
                {
                    if (pr.ProcessName.Contains("avpng"))
                    {
                        varmi = true;
                        break;
                    }
                }
                if (!varmi)
                {
                    System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "avpng.exe"), string.Format("-isKayit {0} {1} {2}", e.Appointment.CustomFields["ID"], Security.User.KULLANICI_ADI, Security.User.KULLANICI_SIFRESI));
                }

                e.Handled = true;
            }
            else
                e.Handled = false;
        }

        private void schedulerControl1_RemindersFormDefaultAction(object sender, RemindersFormDefaultActionEventArgs e)
        {
        }

        private void schedulerControl1_RemindersFormShowing(object sender, RemindersFormEventArgs e)
        {
            PencereAcik = true;

            RemindersForm remindersForm = new RemindersForm((SchedulerControl)sender);
            ReminderEventArgs args = new ReminderEventArgs(e.AlertNotifications);

            remindersForm.FormClosed += new FormClosedEventHandler(remindersForm_FormClosed);
            remindersForm.OnReminderAlert(args);
            e.Handled = true;

            //foreach (ReminderAlertNotification re in e.AlertNotifications)
            //{
            //    VList<AvukatProLib2.Entities.per_REMINDER> hatList = DataRepository.per_REMINDERProvider.Get("ID=" + re.ActualAppointment.CustomFields["ID"], "ID");
            //    foreach (AvukatProLib2.Entities.per_REMINDER hatirlatma in hatList)
            //    {
            //        #region İş bildirimi yap

            //        if (hatirlatma.HATIRLATMA_TIPI == "1" && !string.IsNullOrEmpty(hatirlatma.EMAIL_1))
            //        {
            //            #region mail
            //            MailMessage newmail = new MailMessage();

            //            newmail.From = client.UserName;
            //            newmail.To = hatirlatma.EMAIL_1;
            //            newmail.MailType = MailEncodingType.HTML;

            //            if (!String.IsNullOrEmpty(hatirlatma.DOSYA_ADI))
            //            {
            //                string[] DOSYA_ADI = hatirlatma.DOSYA_ADI.Split('\\');

            //                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + DOSYA_ADI[DOSYA_ADI.Length - 1];
            //                File.WriteAllBytes(filePath, hatirlatma.ICERIK);
            //                Attachment attach = new Attachment(filePath);

            //                newmail.Attachments.Add(attach);
            //            }

            //            newmail.Subject = TurkceKarakterleriDuzelt("Yeni iş: " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString() + " tarihi ve " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortTimeString() + " saatinde tamamlanmasi gereken yeni bir işiniz var");

            //            StringBuilder mail = new StringBuilder(193);
            //            mail.AppendLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            //            mail.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
            //            mail.AppendFormat(@"<head>");

            //            mail.AppendLine("<META http-equiv=\"Content-Type\" content=\"text/html\"; charset=\"UTF-8\">");
            //            mail.AppendFormat(@"<title></title>");

            //            mail.AppendFormat(@"</head>");
            //            mail.AppendFormat(@"<body><br>[ICERIKBURADAOLACAK]</body></html>");
            //            newmail.Message = mail.ToString();

            //            newmail.Message = newmail.Message.Replace("[ICERIKBURADAOLACAK]",
            //                "<br><b>Kimden :</b> " + newmail.From +
            //                "<br><b>Baslangıç Tarihi :</b> " + hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy H:mm") + "<br><b>Bitiş Tarihi :</b> " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToString("dd/MM/yyyy H:mm") +
            //                "<br><b>Bilgi :</b> " + hatirlatma.ADLIYE + "/" + hatirlatma.NO + "/" + hatirlatma.GOREV + " - " + hatirlatma.ESAS_NO +
            //                "<br><br><b>Görev :</b> " + hatirlatma.YAPILACAK_IS +
            //                "<br><br><b>Açıklama :</b> " + hatirlatma.ACIKLAMA +
            //                "<br><br><br><font color=blue>Not: Bu mail Avukatpro Yeni Nesil Asistanı tarafından otomatik olarak gönderilmiştir.</font>");
            //            newmail.Message = TurkceKarakterleriDuzelt(newmail.Message);

            //            try
            //            {
            //                client.SendMail(newmail);
            //                if (!bildirilenIdler.Contains((int)hatirlatma.HATIRLAT_ID))
            //                    bildirilenIdler.Add((int)hatirlatma.HATIRLAT_ID);
            //            }
            //            catch (Exception)
            //            {
            //                throw;
            //            }
            //            #endregion
            //        }

            //        else if (hatirlatma.HATIRLATMA_TIPI == "2" && !string.IsNullOrEmpty(hatirlatma.CEP_TEL))
            //        {
            //            #region sms
            //            try
            //            {
            //                //if (sms == null)
            //                //    sms = new SMSMakinesi.Gateway();

            //                //StringBuilder mesaj = new StringBuilder();
            //                //mesaj.Append("Yapılması gereken işiniz var. Detay: ");

            //                //if (!String.IsNullOrEmpty(hatirlatma.ADLIYE))
            //                //    mesaj.Append(hatirlatma.ADLIYE + "/");
            //                //if (!String.IsNullOrEmpty(hatirlatma.NO))
            //                //    mesaj.Append(hatirlatma.NO + "/");
            //                //if (!String.IsNullOrEmpty(hatirlatma.GOREV))
            //                //    mesaj.Append(hatirlatma.GOREV + "/");
            //                //if (!String.IsNullOrEmpty(hatirlatma.ESAS_NO))
            //                //    mesaj.Append(hatirlatma.ESAS_NO + "-");
            //                //if (hatirlatma.BASLANGIC_TARIHI.HasValue)
            //                //    mesaj.Append(hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy H:mm") + "-");
            //                //if (!String.IsNullOrEmpty(hatirlatma.YAPILACAK_IS))
            //                //    mesaj.Append(hatirlatma.YAPILACAK_IS);

            //                //sms.clearsmsbasket();

            //                //if (mesaj.ToString() != string.Empty)
            //                //    sms.addtosmsbasket(TKCeptDuzelt(mesaj.ToString()), CepTelFormatla(hatirlatma.CEP_TEL.Trim()));
            //                //string result;
            //                //if (mesaj.Length <= 160)
            //                //    result = sms.sendsms(SMSKullaniciAdi, SMSSifre, SMSGonderen, "", SMSVendorID);
            //                //else
            //                //    result = sms.sendsmsconcat(SMSKullaniciAdi, SMSSifre, SMSGonderen, "", SMSVendorID);

            //                //sms.clearsmsbasket();
            //                //if (result.Length > 2)
            //                //{
            //                //    if (!bildirilenIdler.Contains((int)hatirlatma.HATIRLAT_ID))
            //                //        bildirilenIdler.Add((int)hatirlatma.HATIRLAT_ID);
            //                //}
            //            }
            //            catch { ;}
            //            #endregion
            //        }

            //        #endregion İş bildirimi yap
            //    }

            //    #region Bildirilen hatırlatmaları güncelle

            //    //if (bildirilenIdler.Count > 0)
            //    //{
            //    //    SqlConnection con = new SqlConnection(smtpInfo.ConStr);
            //    //    foreach (var id in bildirilenIdler)
            //    //    {
            //    //        SqlCommand cmd = new SqlCommand(@"UPDATE AV001_TDI_BIL_HATIRLAT SET ENSON_EXTRA_1_GUN_ONCE=getdate() WHERE ID=@ID", con);
            //    //        cmd.Parameters.Add("@ID", id);
            //    //        if (con.State == System.Data.ConnectionState.Closed)
            //    //        {
            //    //            con.Open();
            //    //            cmd.ExecuteNonQuery();
            //    //        }
            //    //        if (con.State == System.Data.ConnectionState.Open)
            //    //            con.Close();
            //    //    }
            //    //    con.Dispose();
            //    //}

            //    #endregion Bildirilen hatırlatmaları güncelle
            //}
        }

        private void Security_OnLogOut(object sender, EventArgs e)
        {
            if (schedulerControl1.Storage != null)
            {
                foreach (var item in schedulerControl1.Storage.Appointments.Items)
                {
                    item.Reminders.Clear();
                }
                schedulerControl1.Storage.Appointments.Clear();
                schedulerControl1.Storage = null;
                schedulerControl1.Refresh();
                Isler.SchedulerStorage = null;
                Tmr.Stop();
                this.Close();
            }
        }

        private void Storage_ReminderAlert(object sender, ReminderEventArgs e)
        {
            for (int i = 0; i < e.AlertNotifications.Count; i++)
            {
                DateTime comp1 = e.AlertNotifications[i].Reminder.AlertTime + e.AlertNotifications[i].Reminder.TimeBeforeStart;
                comp1 = new DateTime(comp1.Year, comp1.Month, comp1.Day);
                DateTime comp2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                if ((bool)e.AlertNotifications[i].ActualAppointment.CustomFields["HATIRLATILSINMI"] == true)
                {
                    if (comp1 < e.AlertNotifications[i].Reminder.Appointment.End && e.AlertNotifications[i].Reminder.Appointment.End < DateTime.Now.Date)
                    {
                        e.AlertNotifications.RemoveAt(i--);
                    }
                }
                else
                {
                    e.AlertNotifications.RemoveAt(i--);
                }
            }
        }
    }
}