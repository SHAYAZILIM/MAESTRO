using AvukatProLib;
using ServerSideServices.Properties;
using System;
using System.Windows.Forms;

namespace ServerSideServices
{
    public partial class ServicesControl : Form
    {
        public ServicesControl()
        {
            InitializeComponent();
        }

        //public static int saat;
        //public static int dakika;
        //public static int x;
        //public static int y;
        //public static string gun = "";
        public static TimerForm timer;

        private ServicesControlAccessory sca = new ServicesControlAccessory();

        public static void timerFormRefresh()
        {
            if (timer != null)
                timer.Close();
            timer = new TimerForm();
            timer.Show();
            //timer.Visible = false;
        }

        private void AsamaCalistir()
        {
            pcBoxAsamaRun.Image = ServerSideServices.Properties.Resources.icon_stop;
            pcBoxAsamaRun.Tag = "icon_stop";
            lblAsamaDurum.Text = "Çalışıyor";
            Settings.Default.AsamaRun = true;
            ServerSideServices.Properties.Settings.Default.Save();

            string[] dizi = dtPAsama.Text.Split(':');
            int x = Convert.ToInt32(dizi[0].ToString());
            int y = Convert.ToInt32(dizi[1].ToString());

            ServerSideServices.Properties.Settings.Default.AsamaRunTime = new DateTime(1982, 03, 20, x, y, 00);
            ServerSideServices.Properties.Settings.Default.Save();

            switch (cBoxAralikAsama.Text)
            {
                case "Hergün":
                    Settings.Default.AsamaCalismaAraligi = "Hergün";
                    Settings.Default.AsamaGun = "";
                    ServerSideServices.Properties.Settings.Default.Save();
                    cBoxGunAsama.Text = "";
                    break;

                case "Haftada Birgün":
                    Settings.Default.AsamaCalismaAraligi = cBoxAralikAsama.Text;
                    Settings.Default.AsamaGun = cBoxGunAsama.Text;
                    ServerSideServices.Properties.Settings.Default.Save();
                    break;

                default:
                    break;
            }
        }

        private void AsistanCalistir()
        {
            pcBoxAsistanRun.Image = ServerSideServices.Properties.Resources.icon_stop;
            pcBoxAsistanRun.Tag = "icon_stop";
            lblAsistanDurum.Text = "Çalışıyor";
            Settings.Default.AsistanRun = true;
            ServerSideServices.Properties.Settings.Default.Save();

            //string[] dizi = dtPAsama.Text.Split(':');
            //int x = Convert.ToInt32(dizi[0].ToString());
            //int y = Convert.ToInt32(dizi[1].ToString());

            //ServerSideServices.Properties.Settings.Default.AsamaRunTime = new DateTime(1982, 03, 20, x, y, 00);
            //ServerSideServices.Properties.Settings.Default.Save();

            //switch (cBoxAralikAsama.Text)
            //{
            //    case "Hergün":
            //        Settings.Default.AsamaCalismaAraligi = "Hergün";
            //        Settings.Default.AsamaGun = "";
            //        ServerSideServices.Properties.Settings.Default.Save();
            //        cBoxGunAsama.Text = "";
            //        break;
            //    case "Haftada Birgün":
            //        Settings.Default.AsamaCalismaAraligi = cBoxAralikAsama.Text;
            //        Settings.Default.AsamaGun = cBoxGunAsama.Text;
            //        ServerSideServices.Properties.Settings.Default.Save();
            //        break;
            //    default:
            //        break;

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblTebligatDurum.Text == "Çalışıyor")
                TebligatCalistir();
            if (lblMailDurum.Text == "Çalışıyor")
                MailCalistir();
            if (lblSMSDurum.Text == "Çalışıyor")
                SmsCalistir();
            if (lblFaxDurum.Text == "Çalışıyor")
                FaxCalistir();
            if (lblUYAPDurum.Text == "Çalışıyor")
                UyapCalistir();
            if (lblTarafGelismeDurum.Text == "Çalışıyor")
                TarafGelismeCalistir();
            if (lblAsamaDurum.Text == "Çalışıyor")
                AsamaCalistir();

            timerFormRefresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bütün servisler durdurulacaktır...\nİşlemede devam etmek istiyor musunuz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;

            Application.Exit();
            return;
        }

        private void cBoxAralikAsama_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBoxAralikAsama.SelectedItem.ToString())
            {
                case "Hergün":
                    cBoxGunAsama.Text = "Hergün";
                    cBoxGunAsama.Enabled = false;
                    break;

                case "Haftada Birgün":
                    cBoxGunAsama.Enabled = true;
                    cBoxGunAsama.Text = "Pazartesi";
                    cBoxGunAsama.SelectedItem = "Pazartesi";
                    break;

                default:
                    break;
            }
        }

        private void cBoxAralikFax_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBoxAralikFax.SelectedItem.ToString())
            {
                case "Hergün":
                    cBoxGunFax.Text = "Hergün";
                    cBoxGunFax.Enabled = false;
                    break;

                case "Haftada Birgün":
                    cBoxGunFax.Enabled = true;
                    cBoxGunFax.Text = "Pazartesi";
                    cBoxGunFax.SelectedItem = "Pazartesi";
                    break;

                default:
                    break;
            }
        }

        private void cBoxAralikMail_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBoxAralikMail.SelectedItem.ToString())
            {
                case "Hergün":
                    cBoxGunMail.Text = "Hergün";
                    cBoxGunMail.Enabled = false;
                    break;

                case "Haftada Birgün":
                    cBoxGunMail.Enabled = true;
                    cBoxGunMail.Text = "Pazartesi";
                    cBoxGunMail.SelectedItem = "Pazartesi";
                    break;

                default:
                    break;
            }
        }

        private void cBoxAralikSMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBoxAralikSMS.SelectedItem.ToString())
            {
                case "Hergün":
                    cBoxGunSMS.Text = "Hergün";
                    cBoxGunSMS.Enabled = false;
                    break;

                case "Haftada Birgün":
                    cBoxGunSMS.Enabled = true;
                    cBoxGunSMS.Text = "Pazartesi";
                    cBoxGunSMS.SelectedItem = "Pazartesi";
                    break;

                default:
                    break;
            }
        }

        private void cBoxAralikTarafGelisme_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBoxAralikTarafGelisme.SelectedItem.ToString())
            {
                case "Hergün":
                    cBoxGunTarafGelisme.Text = "Hergün";
                    cBoxGunTarafGelisme.Enabled = false;
                    break;

                case "Haftada Birgün":
                    cBoxGunTarafGelisme.Enabled = true;
                    cBoxGunTarafGelisme.Text = "Pazartesi";
                    cBoxGunTarafGelisme.SelectedItem = "Pazartesi";
                    break;

                default:
                    break;
            }
        }

        private void cBoxAralikTebligat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBoxAralikTebligat.SelectedItem.ToString())
            {
                case "Hergün":
                    cBoxGunTebligat.Text = "Hergün";
                    cBoxGunTebligat.Enabled = false;
                    break;

                case "Haftada Birgün":
                    cBoxGunTebligat.Enabled = true;
                    //if (Settings.Default.TebligatGun.ToString() != "Hergün" && Settings.Default.TebligatGun.ToString() != "Yanlızca Bugün")
                    //{
                    cBoxGunTebligat.Text = Settings.Default.TebligatGun.ToString();
                    cBoxGunTebligat.SelectedItem = Settings.Default.TebligatGun.ToString();
                    //}

                    break;

                default:
                    break;
            }
        }

        private void cBoxAralikUYAP_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBoxAralikUYAP.SelectedItem.ToString())
            {
                case "Hergün":
                    cBoxGunUYAP.Text = "Hergün";
                    cBoxGunUYAP.Enabled = false;
                    break;

                case "Haftada Birgün":
                    cBoxGunUYAP.Enabled = true;
                    cBoxGunUYAP.Text = "Pazartesi";
                    cBoxGunUYAP.SelectedItem = "Pazartesi";
                    break;

                default:
                    break;
            }
        }

        private void Durdur_Click_1(object sender, EventArgs e)
        {
        }

        private void FaxCalistir()
        {
            pcBoxFaxRun.Image = ServerSideServices.Properties.Resources.icon_stop;
            pcBoxFaxRun.Tag = "icon_stop";
            lblFaxDurum.Text = "Çalışıyor";
            Settings.Default.FaxRun = true;
            ServerSideServices.Properties.Settings.Default.Save();

            string[] dizi = dtPFax.Text.Split(':');
            int x = Convert.ToInt32(dizi[0].ToString());
            int y = Convert.ToInt32(dizi[1].ToString());

            ServerSideServices.Properties.Settings.Default.FaxRunTime = new DateTime(1982, 03, 20, x, y, 00);
            ServerSideServices.Properties.Settings.Default.Save();

            switch (cBoxAralikFax.Text)
            {
                case "Hergün":
                    Settings.Default.FaxCalismaAraligi = "Hergün";
                    Settings.Default.FaxGun = "";
                    ServerSideServices.Properties.Settings.Default.Save();
                    cBoxGunSMS.Text = "";
                    break;

                case "Haftada Birgün":
                    Settings.Default.FaxCalismaAraligi = cBoxAralikFax.Text;
                    Settings.Default.FaxGun = cBoxGunFax.Text;
                    ServerSideServices.Properties.Settings.Default.Save();
                    break;

                default:
                    break;
            }
        }

        private void KontrolAyar_Click_1(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void MailCalistir()
        {
            pcBoxMailRun.Image = ServerSideServices.Properties.Resources.icon_stop;
            pcBoxMailRun.Tag = "icon_stop";
            lblMailDurum.Text = "Çalışıyor";
            Settings.Default.MailRun = true;
            ServerSideServices.Properties.Settings.Default.Save();

            string[] dizi = dtPMail.Text.Split(':');
            int x = Convert.ToInt32(dizi[0].ToString());
            int y = Convert.ToInt32(dizi[1].ToString());

            ServerSideServices.Properties.Settings.Default.MailRunTime = new DateTime(1982, 03, 20, x, y, 00);
            ServerSideServices.Properties.Settings.Default.Save();

            switch (cBoxAralikMail.Text)
            {
                case "Hergün":
                    Settings.Default.MailCalismaAraligi = "Hergün";
                    Settings.Default.MailGun = "";
                    ServerSideServices.Properties.Settings.Default.Save();
                    cBoxGunMail.Text = "";
                    break;

                case "Haftada Birgün":
                    Settings.Default.MailCalismaAraligi = cBoxAralikMail.Text;
                    Settings.Default.MailGun = cBoxGunMail.Text;
                    ServerSideServices.Properties.Settings.Default.Save();
                    break;

                default:
                    break;
            }
        }

        private void notifyIcon1_DoubleClick_1(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void pcBoxAsamaRun_Click(object sender, EventArgs e)
        {
            if (pcBoxAsamaRun.Tag == "icon_stop")
            {
                pcBoxAsamaRun.Image = ServerSideServices.Properties.Resources.Play;
                pcBoxAsamaRun.Tag = "Play";
                lblAsamaDurum.Text = "Durduruldu";
                Settings.Default.AsamaRun = false;
                ServerSideServices.Properties.Settings.Default.Save();
            }
            else
            {
                AsamaCalistir();
            }
            timerFormRefresh();
        }

        private void pcBoxAsistanRun_Click(object sender, EventArgs e)
        {
            if (pcBoxAsistanRun.Tag == "icon_stop")
            {
                pcBoxAsistanRun.Image = ServerSideServices.Properties.Resources.Play;
                pcBoxAsistanRun.Tag = "Play";
                lblAsistanDurum.Text = "Durduruldu";
                Settings.Default.AsistanRun = false;
                ServerSideServices.Properties.Settings.Default.Save();
            }
            else
            {
                AsistanCalistir();
            }
            timerFormRefresh();
        }

        private void pcBoxFaxRun_Click(object sender, EventArgs e)
        {
            if (pcBoxFaxRun.Tag == "icon_stop")
            {
                pcBoxFaxRun.Image = ServerSideServices.Properties.Resources.Play;
                pcBoxFaxRun.Tag = "Play";
                lblFaxDurum.Text = "Durduruldu";
                Settings.Default.FaxRun = false;
                ServerSideServices.Properties.Settings.Default.Save();
            }
            else
            {
                FaxCalistir();
            }
            timerFormRefresh();
        }

        private void pcBoxMailRun_Click(object sender, EventArgs e)
        {
            if (pcBoxMailRun.Tag == "icon_stop")
            {
                pcBoxMailRun.Image = ServerSideServices.Properties.Resources.Play;
                pcBoxMailRun.Tag = "Play";
                lblMailDurum.Text = "Durduruldu";
                Settings.Default.MailRun = false;
                ServerSideServices.Properties.Settings.Default.Save();
            }
            else
            {
                MailCalistir();
            }
            timerFormRefresh();
        }

        private void pcBoxSMSRun_Click(object sender, EventArgs e)
        {
            if (pcBoxSMSRun.Tag == "icon_stop")
            {
                pcBoxSMSRun.Image = ServerSideServices.Properties.Resources.Play;
                pcBoxSMSRun.Tag = "Play";
                lblSMSDurum.Text = "Durduruldu";
                Settings.Default.SmsRun = false;
                ServerSideServices.Properties.Settings.Default.Save();
            }
            else
            {
                SmsCalistir();
            }
            timerFormRefresh();
        }

        private void pcBoxTarafGelismeRun_Click(object sender, EventArgs e)
        {
            if (pcBoxTarafGelismeRun.Tag == "icon_stop")
            {
                pcBoxTarafGelismeRun.Image = ServerSideServices.Properties.Resources.Play;
                pcBoxTarafGelismeRun.Tag = "Play";
                lblTarafGelismeDurum.Text = "Durduruldu";
                Settings.Default.TarafGelismeRun = false;
                ServerSideServices.Properties.Settings.Default.Save();
            }
            else
            {
                TarafGelismeCalistir();
            }
            timerFormRefresh();
        }

        private void pcBoxTebligatRun_Click(object sender, EventArgs e)
        {
            if (pcBoxTebligatRun.Tag == "icon_stop")
            {
                pcBoxTebligatRun.Image = ServerSideServices.Properties.Resources.Play;
                this.pcBoxTebligatRun.Tag = "Play";
                lblTebligatDurum.Text = "Durduruldu";
                Settings.Default.TebligatRun = false;
                ServerSideServices.Properties.Settings.Default.Save();
            }
            else
            {
                TebligatCalistir();
            }

            timerFormRefresh();
        }

        private void pcBoxUYAPRun_Click(object sender, EventArgs e)
        {
            if (pcBoxUYAPRun.Tag == "icon_stop")
            {
                pcBoxUYAPRun.Image = ServerSideServices.Properties.Resources.Play;
                pcBoxUYAPRun.Tag = "Play";
                lblUYAPDurum.Text = "Durduruldu";
                Settings.Default.UyapRun = false;
                ServerSideServices.Properties.Settings.Default.Save();
            }
            else
            {
                UyapCalistir();
            }
            timerFormRefresh();
        }

        private void ServicesControl_Load(object sender, EventArgs e)
        {
            CompInfo smtpInfo = CompInfo.CmpNfoList[0];
            if (smtpInfo.UygulamaTipi != 0)
            {
                Application.Exit();
                return;
            }

            if (FormWindowState.Minimized == WindowState)
                Hide();

            //islem();

            #region Run?

            if (Settings.Default.TebligatRun)
            {
                pcBoxTebligatRun.Image = global::ServerSideServices.Properties.Resources.icon_stop;
                pcBoxTebligatRun.Tag = "icon_stop";
                lblTebligatDurum.Text = "Çalışıyor";
            }
            else
            {
                this.pcBoxTebligatRun.Image = global::ServerSideServices.Properties.Resources.Play;
                this.pcBoxTebligatRun.Tag = "Play";
                lblTebligatDurum.Text = "Durduruldu";
            }
            if (Settings.Default.AsamaRun)
            {
                this.pcBoxAsamaRun.Image = global::ServerSideServices.Properties.Resources.icon_stop;
                this.pcBoxAsamaRun.Tag = "icon_stop";
                lblAsamaDurum.Text = "Çalışıyor";
            }
            else
            {
                this.pcBoxAsamaRun.Image = global::ServerSideServices.Properties.Resources.Play;
                this.pcBoxAsamaRun.Tag = "Play";
                lblAsamaDurum.Text = "Durduruldu";
            }
            if (Settings.Default.FaxRun)
            {
                this.pcBoxFaxRun.Image = global::ServerSideServices.Properties.Resources.icon_stop;
                this.pcBoxFaxRun.Tag = "icon_stop";
                lblFaxDurum.Text = "Çalışıyor";
            }
            else
            {
                this.pcBoxFaxRun.Image = global::ServerSideServices.Properties.Resources.Play;
                this.pcBoxFaxRun.Tag = "Play";
                lblFaxDurum.Text = "Durduruldu";
            }
            if (Settings.Default.MailRun)
            {
                this.pcBoxMailRun.Image = global::ServerSideServices.Properties.Resources.icon_stop;
                this.pcBoxMailRun.Tag = "icon_stop";
                lblMailDurum.Text = "Çalışıyor";
            }
            else
            {
                this.pcBoxMailRun.Image = global::ServerSideServices.Properties.Resources.Play;
                this.pcBoxMailRun.Tag = "Play";
                lblMailDurum.Text = "Durduruldu";
            }
            if (Settings.Default.SmsRun)
            {
                this.pcBoxSMSRun.Image = global::ServerSideServices.Properties.Resources.icon_stop;
                this.pcBoxSMSRun.Tag = "icon_stop";
                lblSMSDurum.Text = "Çalışıyor";
            }
            else
            {
                this.pcBoxSMSRun.Image = global::ServerSideServices.Properties.Resources.Play;
                this.pcBoxSMSRun.Tag = "Play";
                lblSMSDurum.Text = "Durduruldu";
            }
            if (Settings.Default.TarafGelismeRun)
            {
                this.pcBoxTarafGelismeRun.Image = global::ServerSideServices.Properties.Resources.icon_stop;
                this.pcBoxTarafGelismeRun.Tag = "icon_stop";
                lblTarafGelismeDurum.Text = "Çalışıyor";
            }
            else
            {
                this.pcBoxTarafGelismeRun.Image = global::ServerSideServices.Properties.Resources.Play;
                this.pcBoxTarafGelismeRun.Tag = "Play";
                lblTarafGelismeDurum.Text = "Durduruldu";
            }
            if (Settings.Default.UyapRun)
            {
                this.pcBoxUYAPRun.Image = global::ServerSideServices.Properties.Resources.icon_stop;
                this.pcBoxUYAPRun.Tag = "icon_stop";
                lblUYAPDurum.Text = "Çalışıyor";
            }
            else
            {
                this.pcBoxUYAPRun.Image = global::ServerSideServices.Properties.Resources.Play;
                this.pcBoxUYAPRun.Tag = "Play";
                lblUYAPDurum.Text = "Durduruldu";
            }

            #endregion Run?

            #region verileri ayarla

            if (Settings.Default.TebligatCalismaAraligi != "Hergün")
            {
                cBoxAralikTebligat.Text = "Haftada Birgün";
                cBoxGunTebligat.Text = Settings.Default.TebligatGun;
            }
            else
            {
                cBoxAralikTebligat.Text = Settings.Default.TebligatCalismaAraligi;
            }
            if (Settings.Default.TebligatRun)
            {
                pcBoxTebligatRun.Image = ServerSideServices.Properties.Resources.icon_stop;
                lblTebligatDurum.Text = "Çalışıyor";
            }
            else
            {
                pcBoxTebligatRun.Image = ServerSideServices.Properties.Resources.Play;
                lblTebligatDurum.Text = "Durduruldu";
            }

            if (Settings.Default.AsamaCalismaAraligi != "Hergün")
            {
                cBoxAralikAsama.Text = "Haftada Birgün";
                cBoxGunAsama.Text = Settings.Default.AsamaGun;
            }
            else
            {
                cBoxAralikAsama.Text = Settings.Default.AsamaCalismaAraligi;
            }
            if (Settings.Default.AsamaRun)
            {
                pcBoxAsamaRun.Image = ServerSideServices.Properties.Resources.icon_stop;
                lblAsamaDurum.Text = "Çalışıyor";
            }
            else
            {
                pcBoxAsamaRun.Image = ServerSideServices.Properties.Resources.Play;
                lblAsamaDurum.Text = "Durduruldu";
            }

            if (Settings.Default.FaxCalismaAraligi != "Hergün")
            {
                cBoxAralikFax.Text = "Haftada Birgün";
                cBoxGunFax.Text = Settings.Default.FaxGun;
            }
            else
            {
                cBoxAralikFax.Text = Settings.Default.FaxCalismaAraligi;
            }
            if (Settings.Default.FaxRun)
            {
                pcBoxFaxRun.Image = ServerSideServices.Properties.Resources.icon_stop;
                lblFaxDurum.Text = "Çalışıyor";
            }
            else
            {
                pcBoxFaxRun.Image = ServerSideServices.Properties.Resources.Play;
                lblFaxDurum.Text = "Durduruldu";
            }

            if (Settings.Default.MailCalismaAraligi != "Hergün")
            {
                cBoxAralikMail.Text = "Haftada Birgün";
                cBoxGunMail.Text = Settings.Default.MailGun;
            }
            else
            {
                cBoxAralikMail.Text = Settings.Default.MailCalismaAraligi;
            }
            if (Settings.Default.MailRun)
            {
                pcBoxMailRun.Image = ServerSideServices.Properties.Resources.icon_stop;
                lblMailDurum.Text = "Çalışıyor";
            }
            else
            {
                pcBoxMailRun.Image = ServerSideServices.Properties.Resources.Play;
                lblMailDurum.Text = "Durduruldu";
            }

            if (Settings.Default.SmsCalismaAraligi != "Hergün")
            {
                cBoxAralikSMS.Text = "Haftada Birgün";
                cBoxGunSMS.Text = Settings.Default.SmsGun;
            }
            else
            {
                cBoxAralikSMS.Text = Settings.Default.SmsCalismaAraligi;
            }
            if (Settings.Default.SmsRun)
            {
                pcBoxSMSRun.Image = ServerSideServices.Properties.Resources.icon_stop;
                lblSMSDurum.Text = "Çalışıyor";
            }
            else
            {
                pcBoxSMSRun.Image = ServerSideServices.Properties.Resources.Play;
                lblSMSDurum.Text = "Durduruldu";
            }

            if (Settings.Default.TarafGelismeCalismaAraligi != "Hergün")
            {
                cBoxAralikTarafGelisme.Text = "Haftada Birgün";
                cBoxGunTarafGelisme.Text = Settings.Default.TarafGelismeGun;
            }
            else
            {
                cBoxAralikTarafGelisme.Text = Settings.Default.TarafGelismeCalismaAraligi;
            }
            if (Settings.Default.TarafGelismeRun)
            {
                pcBoxTarafGelismeRun.Image = ServerSideServices.Properties.Resources.icon_stop;
                lblTarafGelismeDurum.Text = "Çalışıyor";
            }
            else
            {
                pcBoxTarafGelismeRun.Image = ServerSideServices.Properties.Resources.Play;
                lblTarafGelismeDurum.Text = "Durduruldu";
            }

            if (Settings.Default.UyapCalismaAraligi != "Hergün")
            {
                cBoxAralikUYAP.Text = "Haftada Birgün";
                cBoxGunUYAP.Text = Settings.Default.UyapGun;
            }
            else
            {
                cBoxAralikUYAP.Text = Settings.Default.UyapCalismaAraligi;
            }
            if (Settings.Default.UyapRun)
            {
                pcBoxUYAPRun.Image = ServerSideServices.Properties.Resources.icon_stop;
                lblUYAPDurum.Text = "Çalışıyor";
            }
            else
            {
                pcBoxUYAPRun.Image = ServerSideServices.Properties.Resources.Play;
                lblUYAPDurum.Text = "Durduruldu";
            }

            #endregion verileri ayarla

            dtPTebligat.Text = Settings.Default.TebligatRunTime.ToString();
            dtPUyap.Text = Settings.Default.UyapRunTime.ToString();
            dtPTarafGelisme.Text = Settings.Default.TarafGelismeRunTime.ToString();
            dtPSMS.Text = Settings.Default.SmsRunTime.ToString();
            dtPMail.Text = Settings.Default.MailRunTime.ToString();
            dtPFax.Text = Settings.Default.FaxRunTime.ToString();
            dtPAsama.Text = Settings.Default.AsamaRunTime.ToString();

            button1_Click(sender, e); //bütün servisleri başlat (başlat işaretli olanları)
            //timer = new TimerForm();
            //timer.Show();
            //timer.Visible = true;
        }

        private void ServicesControl_MinimumSizeChanged(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void ServicesControl_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void SmsCalistir()
        {
            pcBoxSMSRun.Image = ServerSideServices.Properties.Resources.icon_stop;
            pcBoxSMSRun.Tag = "icon_stop";
            lblSMSDurum.Text = "Çalışıyor";
            Settings.Default.SmsRun = true;
            ServerSideServices.Properties.Settings.Default.Save();

            string[] dizi = dtPSMS.Text.Split(':');

            int x = Convert.ToInt32(dizi[0].ToString());
            int y = Convert.ToInt32(dizi[1].ToString());

            ServerSideServices.Properties.Settings.Default.SmsRunTime = new DateTime(1982, 03, 20, x, y, 00);
            ServerSideServices.Properties.Settings.Default.Save();

            switch (cBoxAralikSMS.Text)
            {
                case "Hergün":
                    Settings.Default.SmsCalismaAraligi = "Hergün";
                    Settings.Default.SmsGun = "";
                    ServerSideServices.Properties.Settings.Default.Save();
                    cBoxGunSMS.Text = "";
                    break;

                case "Haftada Birgün":
                    Settings.Default.SmsCalismaAraligi = cBoxAralikSMS.Text;
                    Settings.Default.SmsGun = cBoxGunSMS.Text;
                    ServerSideServices.Properties.Settings.Default.Save();
                    break;

                default:
                    break;
            }
        }

        private void TarafGelismeCalistir()
        {
            pcBoxTarafGelismeRun.Image = ServerSideServices.Properties.Resources.icon_stop;
            pcBoxTarafGelismeRun.Tag = "icon_stop";
            lblTarafGelismeDurum.Text = "Çalışıyor";
            Settings.Default.TarafGelismeRun = true;
            ServerSideServices.Properties.Settings.Default.Save();

            string[] dizi = dtPTarafGelisme.Text.Split(':');
            int x = Convert.ToInt32(dizi[0].ToString());
            int y = Convert.ToInt32(dizi[1].ToString());

            ServerSideServices.Properties.Settings.Default.TarafGelismeRunTime = new DateTime(1982, 03, 20, x, y, 00);
            ServerSideServices.Properties.Settings.Default.Save();

            switch (cBoxAralikTarafGelisme.Text)
            {
                case "Hergün":
                    Settings.Default.TarafGelismeCalismaAraligi = "Hergün";
                    Settings.Default.TarafGelismeGun = "";
                    ServerSideServices.Properties.Settings.Default.Save();
                    cBoxGunTarafGelisme.Text = "";
                    break;

                case "Haftada Birgün":
                    Settings.Default.TarafGelismeCalismaAraligi = cBoxAralikTarafGelisme.Text;
                    Settings.Default.TarafGelismeGun = cBoxGunTarafGelisme.Text;
                    ServerSideServices.Properties.Settings.Default.Save();
                    break;

                default:
                    break;
            }
        }

        private void TebligatCalistir()
        {
            pcBoxTebligatRun.Image = ServerSideServices.Properties.Resources.icon_stop;
            this.pcBoxTebligatRun.Tag = "icon_stop";
            lblTebligatDurum.Text = "Çalışıyor";
            Settings.Default.TebligatRun = true;
            ServerSideServices.Properties.Settings.Default.Save();
            string[] dizi = dtPTebligat.Text.Split(':');
            int x = Convert.ToInt32(dizi[0].ToString());
            int y = Convert.ToInt32(dizi[1].ToString());
            ServerSideServices.Properties.Settings.Default.TebligatRunTime = new DateTime(1982, 03, 20, x, y, 00);
            ServerSideServices.Properties.Settings.Default.Save();

            switch (cBoxAralikTebligat.Text)
            {
                case "Hergün":
                    Settings.Default.TebligatCalismaAraligi = "Hergün";
                    Settings.Default.TebligatGun = "";
                    ServerSideServices.Properties.Settings.Default.Save();
                    cBoxGunTebligat.Text = "";
                    break;

                case "Haftada Birgün":
                    Settings.Default.TebligatCalismaAraligi = cBoxAralikTebligat.Text;
                    Settings.Default.TebligatGun = cBoxGunTebligat.Text;
                    ServerSideServices.Properties.Settings.Default.Save();
                    break;

                default:
                    break;
            }
        }

        private void UyapCalistir()
        {
            pcBoxUYAPRun.Image = ServerSideServices.Properties.Resources.icon_stop;
            pcBoxUYAPRun.Tag = "icon_stop";
            lblUYAPDurum.Text = "Çalışıyor";
            Settings.Default.UyapRun = true;
            ServerSideServices.Properties.Settings.Default.Save();

            string[] dizi = dtPUyap.Text.Split(':');
            int x = Convert.ToInt32(dizi[0].ToString());
            int y = Convert.ToInt32(dizi[1].ToString());

            ServerSideServices.Properties.Settings.Default.UyapRunTime = new DateTime(1982, 03, 20, x, y, 00);
            ServerSideServices.Properties.Settings.Default.Save();

            switch (cBoxAralikUYAP.Text)
            {
                case "Hergün":
                    Settings.Default.UyapCalismaAraligi = "Hergün";
                    Settings.Default.UyapGun = "";
                    ServerSideServices.Properties.Settings.Default.Save();
                    cBoxGunUYAP.Text = "";
                    break;

                case "Haftada Birgün":
                    Settings.Default.UyapCalismaAraligi = cBoxAralikUYAP.Text;
                    Settings.Default.UyapGun = cBoxGunUYAP.Text;
                    ServerSideServices.Properties.Settings.Default.Save();
                    break;

                default:
                    break;
            }
        }
    }
}