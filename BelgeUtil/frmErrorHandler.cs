using AvukatProLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Windows.Forms;

namespace BelgeUtil
{
    public partial class frmErrorHandler : Form
    {
        public frmErrorHandler()
        {
            InitializeComponent();
        }

        private Bilesen[] _Bilesenler;

        private ErrorHandlerSOAPAPI.ERRORHANDLER_SOAP_API_NENC errorHandler = new ErrorHandlerSOAPAPI.ERRORHANDLER_SOAP_API_NENC();

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public Bilesen[] Bilesenler
        {
            get { return _Bilesenler; }
            set { _Bilesenler = value; }
        }

        public void ShowDialog(string hataMesaji)
        {
            txtMessage.Text = hataMesaji;
            this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtOzet.Text))
            //{
            //    MessageBox.Show("Lütfen Hata ile ilgili bir özet giriniz.");
            //    return;
            //}
            //if (String.IsNullOrEmpty(txtNot.Text))
            //{
            //    MessageBox.Show("Lütfen Hata ile ilgili bir açýklama giriniz.");
            //    return;
            //}

            //SmtpClient cli = new SmtpClient();

            //cli.Host = "mail.avukatpro.com";
            //MailMessage msg = new MailMessage();
            //msg.From = new MailAddress(txtEmail.Text, Kimlikci.Kimlik.KullaniciAdi);
            //msg.BodyEncoding = Encoding.UTF8;
            //cli.EnableSsl = false;

            //msg.To.Add("info@avukatpro.com");
            //msg.Subject = "HataRaporu : " + DateTime.Now.ToString() + Kimlikci.Kimlik.CurrentAKTIF_KULLANICI.KULLANICI_ADI;

            ////new StreamReader(Application.StartupPath + "\\test.txt", Encoding.GetEncoding(1254));//
            //msg.Body = txtNot.Text + Environment.NewLine + Environment.NewLine + txtMessage.Text;
            //msg.IsBodyHtml = false;

            //try
            //{
            //    cli.Send(msg);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            MailAddress From = new MailAddress(txtEmail.Text, Kimlikci.Kimlik.KullaniciAdi);
            MailAddress To = new MailAddress("info@avukatpro.com", "Avukatpro Yazýlým Ltd. Þti.");
            MailMessage Email = new MailMessage(From, To);
            Email.IsBodyHtml = true;
            Email.Subject = "HataRaporu : " + DateTime.Now.ToString() + Kimlikci.Kimlik.CurrentAKTIF_KULLANICI.KULLANICI_ADI;
            Email.Body = txtNot.Text + Environment.NewLine + Environment.NewLine + txtMessage.Text;
            SmtpClient MailClient = new SmtpClient();
            MailClient.Port = 587;
            MailClient.Host = "mail.avukatpro.com";
            MailClient.EnableSsl = false;
            MailClient.UseDefaultCredentials = false;
            MailClient.Credentials = new NetworkCredential("info@avukatpro.com", "yeninesil2012");
            MailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailClient.Send(Email);

            errorHandler.ErrorReportAsync(txtEmail.Text, txtIsim.Text, txtNot.Text, txtMessage.Text, AssemblyVersion.ToString(), GetDbVersion(), 1);
            button1.Enabled = button2.Enabled = false;
            button1.Text = "Gönderiliyor..";
            List<string> components = new List<string>();

            foreach (BelgeUtil.Bilesen bil in Bilesenler)
            {
                components.Add(bil.ToString());
            }

            string oncekiHatalar = string.Empty;
            if (Kimlik.BildirilenHatalar.Count > 0)
            {
                oncekiHatalar = "Ayný oturumda alýnan diðer hatalar : ";
                for (int i = 0; i < Kimlik.BildirilenHatalar.Count; i++)
                {
                    string hata = Kimlik.BildirilenHatalar[i];
                    if (i < (Kimlik.BildirilenHatalar.Count - 1))
                        oncekiHatalar += hata + " , ";
                    else
                        oncekiHatalar += hata;
                }
            }

            //BelgeUtil.ErrorHandler.ErrorReportV2Async(AvukatProLib.Kimlik.SirketBilgisi.LisansBilgisi.ProductKey, txtIsim.Text, txtEmail.Text, txtOzet.Text,(!String.IsNullOrEmpty(oncekiHatalar)?String.Format("{2} {0} {1}",Environment.NewLine, txtNot.Text,oncekiHatalar):txtNot.Text), txtMessage.Text, AssemblyVersion, 1, checkBox1.Checked, components.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pnlIletisimBilgileri.Enabled = !checkBox1.Checked;
        }

        // }
        //}
        private void errorHandler_ErrorReportCompleted(object sender, ErrorHandlerSOAPAPI.ErrorReportCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                DialogResult dr = MessageBox.Show("Hata Raporlama sunucusuna eriþimde sorun çýktý" + Environment.NewLine + "Rapor gönderilemedi", "Baðlantý Hatasý", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                {
                    List<string> components = new List<string>();
                    foreach (BelgeUtil.Bilesen bil in Bilesenler)
                    {
                        components.Add(bil.ToString());
                    }

                    // BelgeUtil.ErrorHandler.ErrorReportV2Async(AvukatProLib.Kimlik.SirketBilgisi.LisansBilgisi.ProductKey,
                    // txtIsim.Text, txtEmail.Text, txtOzet.Text, txtNot.Text, txtMessage.Text,
                    // AssemblyVersion, 1, checkBox1.Checked, components.ToArray());
                }
                else
                {
                    button1.Enabled = button2.Enabled = true;
                    button1.Text = "Gönder";
                }
            }
            else
            {
                MessageBox.Show(e.Result, "Rapor Gönderildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void frmErrorHandler_Load(object sender, EventArgs e)
        {
            if (AvukatProLib.Kimlik.Bilgi != null)
            {
                if (AvukatProLib.Kimlik.Bilgi.CARI_IDSource == null)
                {
                    AvukatProLib2.Data.DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.DeepLoad(AvukatProLib.Kimlik.Bilgi, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AvukatProLib2.Entities.AV001_TDI_BIL_CARI));
                }
                if (AvukatProLib.Kimlik.Bilgi.CARI_IDSource != null)
                {
                    txtIsim.Text = AvukatProLib.Kimlik.Bilgi.CARI_IDSource.AD;
                }
                txtEmail.Text = AvukatProLib.Kimlik.Bilgi.EMAIL;// + "@avukatpro.com";
            }

            //TODO: AvukatProLib.Kimlik.Bilgi.EMAIL yapýlacak katmandan sonra.

            errorHandler.Url = (AvukatProLib.Kimlik.SirketBilgisi.GuncelSunucuAdresi ?? "http://update.avukatpro.com") + "//ERRORHANDLER_SOAP_API_NENC.asmx";
            if (AvukatProLib.Kimlik.SirketBilgisi.GuncelProxyKullan && !String.IsNullOrEmpty(AvukatProLib.Kimlik.SirketBilgisi.ProxySunucuAdresi) && !String.IsNullOrEmpty(AvukatProLib.Kimlik.SirketBilgisi.ProxySunucuPortu))
            {
                int portNo = 0;
                Int32.TryParse(AvukatProLib.Kimlik.SirketBilgisi.ProxySunucuPortu, out portNo);
                if (portNo == 0)
                    portNo = 8080;
                WebProxy proxyObject = new WebProxy(AvukatProLib.Kimlik.SirketBilgisi.ProxySunucuAdresi, portNo);
                if (!String.IsNullOrEmpty(AvukatProLib.Kimlik.SirketBilgisi.ProxyKullaniciAdi))
                {
                    errorHandler.UseDefaultCredentials = false;
                    proxyObject.Credentials = new NetworkCredential(AvukatProLib.Kimlik.SirketBilgisi.ProxyKullaniciAdi, AvukatProLib.Kimlik.SirketBilgisi.ProxyParola);
                    proxyObject.BypassProxyOnLocal = true;
                }
                errorHandler.Proxy = proxyObject;
            }
            errorHandler.ErrorReportCompleted += new ErrorHandlerSOAPAPI.ErrorReportCompletedEventHandler(errorHandler_ErrorReportCompleted);

            // BelgeUtil.ErrorHandler.ErrorReportV2Completed += new AdimAdimDavaKaydi.ErrorHandlerSOAPAPI.ErrorReportV2CompletedEventHandler(errorHandler_ErrorReportV2Completed);
        }

        //void errorHandler_ErrorReportV2Completed(object sender, AdimAdimDavaKaydi.ErrorHandlerSOAPAPI.ErrorReportCompletedEventArgs e)
        //{
        //    if (e.Error != null)
        //    {
        //        DialogResult dr = MessageBox.Show("Hata Raporlama sunucusuna eriþimde sorun çýktý" + Environment.NewLine + "Rapor gönderilemedi", "Baðlantý Hatasý", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        //        if (dr == DialogResult.Retry)
        //        {
        //            //errorHandler.ErrorReportAsync(txtEmail.Text, txtIsim.Text, txtNot.Text, txtMessage.Text, AssemblyVersion.ToString(), "1", 1);
        //            BelgeUtil.ErrorHandler.ErrorReportV2Async(AvukatProLib.Kimlik.SirketBilgisi.LisansBilgisi.ProductKey, txtIsim.Text, txtEmail.Text, txtOzet.Text, txtNot.Text, txtMessage.Text, AssemblyVersion, 1, checkBox1.Checked, new string[] { "" });

        // } else { button1.Enabled = button2.Enabled = true; button1.Text = "Gönder"; }

        // } else if (e.Result != null && e.Result.Contains("AVP")) {
        // MessageBox.Show(String.Format("Hatanýz {0} numarasýyla kayýt altýna alýnmýþtýr. Takip
        // edebilmeniz için Email adresinize gerekli bilgiler gönderilmiþtir.", e.Result), "Rapor
        // Gönderildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        // Kimlik.BildirilenHatalar.Add(e.Result); this.Close(); } else { MessageBox.Show("Hata
        // iletim sunucusunda bir problem oluþtu : " + Environment.NewLine + e.Result);
        private string GetDbVersion()
        {
            if (String.IsNullOrEmpty(AvukatProLib.Kimlik.SirketBilgisi.ConStr)) return "";
            try
            {
                using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(AvukatProLib.Kimlik.SirketBilgisi.ConStr))
                {
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        con.Open();
                        cmd.CommandText = "select top(1)DB_VERSIYON from TDIE_BIL_DB_VERSION order by KONTROL_NE_ZAMAN desc";
                        return cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}