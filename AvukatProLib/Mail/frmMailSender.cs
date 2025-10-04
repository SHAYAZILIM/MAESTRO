using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace AvukatProLib.Mail
{
    public partial class frmMailSender : DevExpress.XtraEditors.XtraForm
    {
        public frmMailSender()
        {
            InitializeComponent();
            MailCompInfo = CompInfo.CompInfoListGetir()[0];
        }

        public frmMailSender(string Kime)
        {
            InitializeComponent();
            MailCompInfo = CompInfo.CompInfoListGetir()[0];
            eklentiler = new List<Attachment>();
            KimeTB.Text = Kime;
        }

        public frmMailSender(string Kime, List<string> dosyaYollari)
        {
            InitializeComponent();
            dosyalar = dosyaYollari;
            MailCompInfo = CompInfo.CompInfoListGetir()[0];
            EklentilerLB.Text = String.Empty;
            eklentiler = new List<Attachment>();
            KimeTB.Text = Kime;
            if (PaketBilgisi == "Yeni Nesil Kurumsal Finans")
            {
                KimeTB.Enabled = false;//Bankada gönderilen adresin değiştirilmesi engellemek için eklendi. MB
                CCTB.Visible = false;
                BCCTB.Visible = false;
                labelControl2.Visible = false;
                labelControl3.Visible = false;
            }

            foreach (string attc in dosyaYollari)
            {
                eklentiler.Add(new Attachment(attc));
                string[] arr = attc.Split('\\');
                EklentilerLB.Items.Add(arr[arr.Length - 1]);
            }
        }

        public frmMailSender(List<string> dosyaYollari)
        {
            InitializeComponent();
            dosyalar = dosyaYollari;
            MailCompInfo = CompInfo.CompInfoListGetir()[0];
            EklentilerLB.Text = String.Empty;
            eklentiler = new List<Attachment>();

            foreach (string attc in dosyaYollari)
            {
                eklentiler.Add(new Attachment(attc));
                string[] arr = attc.Split('\\');

                EklentilerLB.Items.Add(arr[arr.Length - 1]);
            }
        }

        public string BCC;

        public string CC;

        public List<string> dosyalar;

        public List<Attachment> eklentiler;

        public string Kime;

        public string Konu;

        public CompInfo MailCompInfo;

        public string Mesaj;

        public MailMessage msg;

        private SmtpClient client;

        public delegate void MailDurumGuncelle(string text);

        public static string PaketBilgisi { get; set; }

        public void DurumYaziGuncelle(string text)
        {
            DurumLBL.Text = text;
        }

        private void EkleBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.Multiselect = false;
            opn.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DialogResult result = opn.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                eklentiler.Add(new Attachment(opn.FileName));
                EklentilerLB.Items.Add(opn.SafeFileName);
            }
        }

        private void frmMailSender_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (msg != null)
            {
                foreach (Attachment atc in msg.Attachments)
                {
                    atc.Dispose();
                }

                msg.Attachments.Clear();
            }
            if (eklentiler != null)
            {
                foreach (Attachment atc in eklentiler)
                {
                    atc.Dispose();
                }
            }
            if (dosyalar != null)
                foreach (string file in dosyalar)
                {
                    try
                    {
                        if (File.Exists(file))
                            File.Delete(file);
                    }
                    catch
                    {
                    }
                }
        }

        private void GonderBTN_Click(object sender, EventArgs e)
        {
            GonderBTN.Enabled = false;
            KimeTB.Enabled = false;
            CCTB.Enabled = false;
            BCCTB.Enabled = false;
            EklentilerLB.Enabled = false;
            KonuTB.Enabled = false;
            MesajRTB.Enabled = false;
            if (String.IsNullOrEmpty(MailCompInfo.SMTPSunucuAdresi) || String.IsNullOrEmpty(MailCompInfo.SMTPKullaniciAdi)
                || String.IsNullOrEmpty(MailCompInfo.SMTPPort) || String.IsNullOrEmpty(MailCompInfo.SMTPSifre))
            {
                MessageBox.Show("Lütfen mail ayarlarınızı yapılandırınız.");
                return;
            }
            DurumLBL.Text = "Mail gönderiliyor lüften bekleyiniz...";
            client = new SmtpClient(MailCompInfo.SMTPSunucuAdresi, Convert.ToInt32(MailCompInfo.SMTPPort));
            client.UseDefaultCredentials = false;
            client.EnableSsl = MailCompInfo.SMTPSSL;
            NetworkCredential user = new NetworkCredential(MailCompInfo.SMTPKullaniciAdi, MailCompInfo.SMTPSifre);
            client.Credentials = user;
            BackgroundWorker bg = new BackgroundWorker();

            bg.DoWork += delegate
            {
                msg = new MailMessage(user.UserName, KimeTB.Text.Trim());
                foreach (Attachment atc in eklentiler)
                    msg.Attachments.Add(atc);
                if (!string.IsNullOrEmpty(CCTB.Text.Trim()))
                    msg.CC.Add(CCTB.Text.Trim());

                if (!string.IsNullOrEmpty(BCCTB.Text.Trim()))
                    msg.Bcc.Add(BCCTB.Text.Trim());
                msg.Subject = KonuTB.Text;
                msg.Body = MesajRTB.Text;
                try
                {
                    client.Send(msg);
                    MessageBox.Show("Mail başarıyla gönderildi.");
                    DurumLBL.Invoke(new MailDurumGuncelle(DurumYaziGuncelle), new object[] { "Mail başarıyla gönderildi." });
                }
                catch
                {
                    MessageBox.Show("Lütfen mail ayarlarınızın yapılandırıldığından veya internet bağlantınız olduğundan emin olunuz!", "Mail Gönderme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DurumLBL.Invoke(new MailDurumGuncelle(DurumYaziGuncelle), new object[] { "Mail gönderilirken hata oluştu!" });
                }
                this.Close();
            };
            if (!bg.IsBusy)
                bg.RunWorkerAsync();
        }

        private void IptalBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (msg != null)
            {
                foreach (Attachment atc in msg.Attachments)
                {
                    atc.Dispose();
                }

                msg.Attachments.Clear();
            }
            if (eklentiler != null)
            {
                foreach (Attachment atc in eklentiler)
                {
                    atc.Dispose();
                }
                eklentiler.Clear();
            }

            EklentilerLB.Items.Clear();
        }
    }
}