using ServerSideServices.Properties;
using System;

namespace ServerSideServices
{
    internal class ServicesControlAccessory
    {
        public ServicesControlAccessory()
        {
            TebligatServisiGun = Settings.Default.TebligatGun.ToString();
            MailServisiGun = Settings.Default.MailGun.ToString();
            SMSServisiGun = Settings.Default.SmsGun.ToString();
            FaxServisiGun = Settings.Default.FaxGun.ToString();
            UyapServisiGun = Settings.Default.UyapGun.ToString();
            TarafGelismeServisiGun = Settings.Default.TarafGelismeGun.ToString();
            AsamaServisiGun = Settings.Default.AsamaGun.ToString();

            TebligatServisiSaat = Convert.ToInt32(Settings.Default.TebligatRunTime.Hour.ToString());
            TebligatServisiDakika = Convert.ToInt32(Settings.Default.TebligatRunTime.Minute.ToString());
            MailServisiSaat = Convert.ToInt32(Settings.Default.MailRunTime.Hour.ToString());
            MailServisiDakika = Convert.ToInt32(Settings.Default.MailRunTime.Minute.ToString());
            SMSServisiSaat = Convert.ToInt32(Settings.Default.SmsRunTime.Hour.ToString());
            SMSServisiDakika = Convert.ToInt32(Settings.Default.SmsRunTime.Minute.ToString());
            UyapServisiSaat = Convert.ToInt32(Settings.Default.UyapRunTime.Hour.ToString());
            UyapServisiDakika = Convert.ToInt32(Settings.Default.UyapRunTime.Minute.ToString());
            AsamaServisiSaat = Convert.ToInt32(Settings.Default.AsamaRunTime.Hour.ToString());
            AsamaServisiDakika = Convert.ToInt32(Settings.Default.AsamaRunTime.Minute.ToString());
            TarafGelismeServisiSaat = Convert.ToInt32(Settings.Default.TarafGelismeRunTime.Hour.ToString());
            TarafGelismeServisiDakika = Convert.ToInt32(Settings.Default.TarafGelismeRunTime.Minute.ToString());

            TebligatIsRun = Settings.Default.TebligatRun;
            MailIsRun = Settings.Default.MailRun;
            SmsIsRun = Settings.Default.SmsRun;
            FaxIsRun = Settings.Default.FaxRun;
            UyapIsRun = Settings.Default.UyapRun;
            TarafGelismeIsRun = Settings.Default.TarafGelismeRun;
            AsamaIsRun = Settings.Default.AsamaRun;
            AsistanIsRun = Settings.Default.AsistanRun;

            TebligatCalismaAraligi = Settings.Default.TebligatCalismaAraligi;
            MailCalismaAraligi = Settings.Default.MailCalismaAraligi;
            SmsCalismaAraligi = Settings.Default.SmsCalismaAraligi;
            FaxCalismaAraligi = Settings.Default.FaxCalismaAraligi;
            UyapCalismaAraligi = Settings.Default.UyapCalismaAraligi;
            TarafGelismeCalismaAraligi = Settings.Default.TarafGelismeCalismaAraligi;
            AsamaCalismaAraligi = Settings.Default.AsamaCalismaAraligi;
        }

        private string _AsamaCalismaAraligi;
        private bool _AsamaIsRun;
        private int _AsamaServisiDakika;
        private string _AsamaServisiGun;
        private int _AsamaServisiSaat;
        private bool _AsistanIsRun;
        private string _FaxCalismaAraligi;
        private bool _FaxIsRun;
        private string _FaxServisiGun;
        private string _MailCalismaAraligi;
        private bool _MailIsRun;
        private int _MailServisiDakika;
        private string _MailServisiGun;
        private int _MailServisiSaat;
        private string _SmsCalismaAraligi;
        private bool _SmsIsRun;
        private int _SMSServisiDakika;
        private string _SMSServisiGun;
        private int _SMSServisiSaat;
        private string _TarafGelismeCalismaAraligi;
        private bool _TarafGelismeIsRun;
        private int _TarafGelismeServisiDakika;
        private string _TarafGelismeServisiGun;
        private int _TarafGelismeServisiSaat;
        private string _TebligatCalismaAraligi;
        private bool _TebligatIsRun;
        private int _TebligatServisiDakika;
        private string _TebligatServisiGun;

        private int _TebligatServisiSaat;

        private string _UyapCalismaAraligi;

        private bool _UyapIsRun;

        private int _UyapServisiDakika;

        private string _UyapServisiGun;

        private int _UyapServisiSaat;

        public string AsamaCalismaAraligi
        {
            get { return _AsamaCalismaAraligi; }
            set
            {
                _AsamaCalismaAraligi = value;
            }
        }

        public bool AsamaIsRun
        {
            get { return _AsamaIsRun; }
            set
            {
                _AsamaIsRun = value;
            }
        }

        public int AsamaServisiDakika
        {
            get { return _AsamaServisiDakika; }
            set
            {
                _AsamaServisiDakika = value;
            }
        }

        public string AsamaServisiGun
        {
            get { return _AsamaServisiGun; }
            set
            {
                _AsamaServisiGun = value;
            }
        }

        public int AsamaServisiSaat
        {
            get { return _AsamaServisiSaat; }
            set
            {
                _AsamaServisiSaat = value;
            }
        }

        public bool AsistanIsRun
        {
            get { return _AsistanIsRun; }
            set
            {
                _AsistanIsRun = value;
            }
        }

        public string FaxCalismaAraligi
        {
            get { return _FaxCalismaAraligi; }
            set
            {
                _FaxCalismaAraligi = value;
            }
        }

        public bool FaxIsRun
        {
            get { return _FaxIsRun; }
            set
            {
                _FaxIsRun = value;
            }
        }

        public string FaxServisiGun
        {
            get { return _FaxServisiGun; }
            set
            {
                _FaxServisiGun = value;
            }
        }

        public string MailCalismaAraligi
        {
            get { return _MailCalismaAraligi; }
            set
            {
                _MailCalismaAraligi = value;
            }
        }

        public bool MailIsRun
        {
            get { return _MailIsRun; }
            set
            {
                _MailIsRun = value;
            }
        }

        public int MailServisiDakika
        {
            get { return _MailServisiDakika; }
            set
            {
                _MailServisiDakika = value;
            }
        }

        public string MailServisiGun
        {
            get { return _MailServisiGun; }
            set
            {
                _MailServisiGun = value;
            }
        }

        public int MailServisiSaat
        {
            get { return _MailServisiSaat; }
            set
            {
                _MailServisiSaat = value;
            }
        }

        public string SmsCalismaAraligi
        {
            get { return _SmsCalismaAraligi; }
            set
            {
                _SmsCalismaAraligi = value;
            }
        }

        public bool SmsIsRun
        {
            get { return _SmsIsRun; }
            set
            {
                _SmsIsRun = value;
            }
        }

        public int SMSServisiDakika
        {
            get { return _SMSServisiDakika; }
            set
            {
                _SMSServisiDakika = value;
            }
        }

        public string SMSServisiGun
        {
            get { return _SMSServisiGun; }
            set
            {
                _SMSServisiGun = value;
            }
        }

        public int SMSServisiSaat
        {
            get { return _SMSServisiSaat; }
            set
            {
                _SMSServisiSaat = value;
            }
        }

        public string TarafGelismeCalismaAraligi
        {
            get { return _TarafGelismeCalismaAraligi; }
            set
            {
                _TarafGelismeCalismaAraligi = value;
            }
        }

        public bool TarafGelismeIsRun
        {
            get { return _TarafGelismeIsRun; }
            set
            {
                _TarafGelismeIsRun = value;
            }
        }

        public int TarafGelismeServisiDakika
        {
            get { return _TarafGelismeServisiDakika; }
            set
            {
                _TarafGelismeServisiDakika = value;
            }
        }

        public string TarafGelismeServisiGun
        {
            get { return _TarafGelismeServisiGun; }
            set
            {
                _TarafGelismeServisiGun = value;
            }
        }

        public int TarafGelismeServisiSaat
        {
            get { return _TarafGelismeServisiSaat; }
            set
            {
                _TarafGelismeServisiSaat = value;
            }
        }

        public string TebligatCalismaAraligi
        {
            get { return _TebligatCalismaAraligi; }
            set
            {
                _TebligatCalismaAraligi = value;
            }
        }

        public bool TebligatIsRun
        {
            get { return _TebligatIsRun; }
            set
            {
                _TebligatIsRun = value;
            }
        }

        public int TebligatServisiDakika
        {
            get { return _TebligatServisiDakika; }
            set
            {
                _TebligatServisiDakika = value;
            }
        }

        public string TebligatServisiGun
        {
            get { return _TebligatServisiGun; }
            set
            {
                _TebligatServisiGun = value;
            }
        }

        public int TebligatServisiSaat
        {
            get { return _TebligatServisiSaat; }
            set
            {
                _TebligatServisiSaat = value;
            }
        }

        public string UyapCalismaAraligi
        {
            get { return _UyapCalismaAraligi; }
            set
            {
                _UyapCalismaAraligi = value;
            }
        }

        public bool UyapIsRun
        {
            get { return _UyapIsRun; }
            set
            {
                _UyapIsRun = value;
            }
        }

        public int UyapServisiDakika
        {
            get { return _UyapServisiDakika; }
            set
            {
                _UyapServisiDakika = value;
            }
        }

        public string UyapServisiGun
        {
            get { return _UyapServisiGun; }
            set
            {
                _UyapServisiGun = value;
            }
        }

        public int UyapServisiSaat
        {
            get { return _UyapServisiSaat; }
            set
            {
                _UyapServisiSaat = value;
            }
        }
    }
}