using System;
using System.Windows.Forms;

//using Microsoft.Win32;

namespace ServerSideServices
{
    public partial class TimerForm : Form
    {
        public TimerForm()
        {
            InitializeComponent();
        }

        public static System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        public int a;
        public int b;
        public int c;
        public int d;
        public int e;
        public int h;
        public int m;
        public int s1;
        public int s2;

        public void TimerControl()
        {
            t.Interval = 1000;
            t.Start();

            t.Tick += delegate(object _s, EventArgs _e)
            {
                DateTime dt = DateTime.Now;
                ServicesControlAccessory sca = new ServicesControlAccessory();

                bool islemYaptimi = false;

                if (sca.TebligatIsRun)
                {
                    #region tebligat

                    if (sca.TebligatServisiSaat == dt.Hour && sca.TebligatServisiDakika == dt.Minute && dt.Second == 0)
                    {
                        if (sca.TebligatCalismaAraligi == "Hergün")
                        {
                            e += 1;
                            islemYaptimi = true;
                            BLL.TebligatIslem();
                        }
                        else if (sca.TebligatCalismaAraligi == "Haftada Birgün")
                        {
                            if (sca.TebligatServisiGun == gunTranslate(dt.DayOfWeek.ToString()))
                            {
                                e += 1;
                                islemYaptimi = true;
                                BLL.TebligatIslem();
                            }
                        }
                    }

                    #endregion tebligat
                }
                if (sca.SmsIsRun)
                {
                    #region sms

                    if (sca.SMSServisiSaat == dt.Hour && sca.SMSServisiDakika == dt.Minute && dt.Second == 0)
                    {
                        if (sca.SmsCalismaAraligi == "Hergün")
                        {
                            e += 1;
                            islemYaptimi = true;
                            BLL.SmsIslem();
                        }
                        else if (sca.SmsCalismaAraligi == "Haftada Birgün")
                        {
                            if (sca.SMSServisiGun == gunTranslate(dt.DayOfWeek.ToString()))
                            {
                                e += 1;
                                islemYaptimi = true;
                                BLL.SmsIslem();
                            }
                        }
                    }

                    #endregion sms
                }

                if (sca.FaxIsRun)
                {
                    #region faks

                    if (ServerSideServices.Properties.Settings.Default.FaxRunTime.Hour == dt.Hour && ServerSideServices.Properties.Settings.Default.FaxRunTime.Minute == dt.Minute && dt.Second == 0)
                    {
                        if (sca.FaxCalismaAraligi == "Hergün")
                        {
                            e += 1;
                            islemYaptimi = true;
                            BLL.HesaplamaIslemi();
                        }
                        else if (sca.FaxCalismaAraligi == "Haftada Birgün")
                        {
                            if (sca.FaxServisiGun == gunTranslate(dt.DayOfWeek.ToString()))
                            {
                                e += 1;
                                islemYaptimi = true;
                                BLL.HesaplamaIslemi();
                            }
                        }
                    }

                    #endregion faks
                }

                if (sca.MailIsRun)
                {
                    #region mail

                    if (sca.MailServisiSaat == dt.Hour && sca.MailServisiDakika == dt.Minute && dt.Second == 0)
                    {
                        if (sca.MailCalismaAraligi == "Hergün")
                        {
                            e += 1;
                            islemYaptimi = true;
                            BLL.MailIslem();
                        }
                        else if (sca.MailCalismaAraligi == "Haftada Birgün")
                        {
                            if (sca.MailServisiGun == gunTranslate(dt.DayOfWeek.ToString()))
                            {
                                e += 1;
                                islemYaptimi = true;
                                BLL.MailIslem();
                            }
                        }
                    }

                    #endregion mail
                }

                if (sca.UyapIsRun)
                {
                    #region uyap

                    if (sca.UyapServisiSaat == dt.Hour && sca.UyapServisiDakika == dt.Minute && dt.Second == 0)
                    {
                        if (sca.UyapCalismaAraligi == "Hergün")
                        {
                            e += 1;
                            islemYaptimi = true;
                            BLL.UyapIslem();
                        }
                        else if (sca.UyapCalismaAraligi == "Haftada Birgün")
                        {
                            if (sca.UyapServisiGun == gunTranslate(dt.DayOfWeek.ToString()))
                            {
                                e += 1;
                                islemYaptimi = true;
                                BLL.UyapIslem();
                            }
                        }
                    }

                    #endregion uyap
                }

                if (sca.AsamaIsRun)
                {
                    #region aşama

                    if (sca.AsamaServisiSaat == dt.Hour && sca.AsamaServisiDakika == dt.Minute && dt.Second == 0)
                    {
                        if (sca.AsamaCalismaAraligi == "Hergün")
                        {
                            e += 1;
                            islemYaptimi = true;
                            //BLL.AsamaIslem();
                            BLL.YedekServisi();
                        }
                        else if (sca.AsamaCalismaAraligi == "Haftada Birgün")
                        {
                            if (sca.AsamaServisiGun == gunTranslate(dt.DayOfWeek.ToString()))
                            {
                                e += 1;
                                islemYaptimi = true;
                                //BLL.AsamaIslem();
                                BLL.YedekServisi();
                            }
                        }
                    }

                    #endregion aşama
                }

                if (sca.TarafGelismeIsRun)
                {
                    #region tarafgelişme

                    if (sca.TarafGelismeServisiSaat == dt.Hour && sca.TarafGelismeServisiDakika == dt.Minute && dt.Second == 0)
                    {
                        if (sca.TarafGelismeCalismaAraligi == "Hergün")
                        {
                            e += 1;
                            islemYaptimi = true;
                            BLL.TarafGelismeIslem();
                        }
                        else if (sca.TarafGelismeCalismaAraligi == "Haftada Birgün")
                        {
                            if (sca.TarafGelismeServisiGun == gunTranslate(dt.DayOfWeek.ToString()))
                            {
                                e += 1;
                                islemYaptimi = true;
                                BLL.TarafGelismeIslem();
                            }
                        }
                    }

                    #endregion tarafgelişme
                }

                if (sca.AsistanIsRun)
                {
                    #region aşama

                    if (dt.Second == 0)
                    {
                        BLL.AsistanIslemi();
                    }

                    #endregion aşama
                }

                if (islemYaptimi)
                {
                    //Thread.Sleep(60000);
                }
            };
        }

        private string gunTranslate(string gun)
        {
            string returnDayName = "";
            switch (gun)
            {
                case "Monday":
                    returnDayName = "Pazartesi";
                    break;

                case "Tuesday":
                    returnDayName = "Salı";
                    break;

                case "Wednesday":
                    returnDayName = "Çarşamba";
                    break;

                case "Thursday":
                    returnDayName = "Perşembe";
                    break;

                case "Friday":
                    returnDayName = "Cuma";
                    break;

                case "Saturday":
                    returnDayName = "Cumartesi";
                    break;

                case "Sunday":
                    returnDayName = "Pazar";
                    break;

                default:
                    break;
            }
            return returnDayName;
        }

        private void TimerForm_Load(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                this.Visible = false;

            TimerControl();

            //RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            //key.SetValue("ServerSideServices.exe", Application.StartupPath);
            //key.Close();
            Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "ServerSideServices.exe", Application.StartupPath + "\\ServerSideServices.exe", Microsoft.Win32.RegistryValueKind.String);
        }
    }
}