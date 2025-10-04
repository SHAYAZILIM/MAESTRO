using AvukatProLib.AVPLicence;
using AvukatProLib.Extras;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AvukatProLib.Lisans
{
    public partial class frmLisansAktiveEtme : Form
    {
        public frmLisansAktiveEtme(string ssPath)
        {
            startupPath = ssPath;
            InitializeComponent();
        }

        public frmLisansAktiveEtme()
        {
            startupPath = Application.StartupPath;
            InitializeComponent();
        }

        private bool BaglantiTamamMi = false;
        private bool keyDogru = false;
        private LisansBilgisi lisans = null;
        private string startupPath;

        private void btnDene_Click_1(object sender, EventArgs e)
        {
            if (txtMusteri.Text.Length == 0)
            {
                MessageBox.Show("Önce lisans bilgilerini giriniz.", "Lisans Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
                csb.DataSource = txtSunucuAdresi.Text;
                csb.InitialCatalog = "master";
                csb.UserID = "sa";
                csb.Password = txtSaParola.Text;

                SqlConnection con = new SqlConnection(csb.ConnectionString);

                //con.Open();
                //con.Close();

                csb.UserID = txtKullaniciAdi.Text;
                csb.Password = txtParola.Text;
                con = new SqlConnection(csb.ConnectionString);
                con.Open();
                con.Close();
                BaglantiTamamMi = true;
                MessageBox.Show("Bağlantı başarıyla oluşturuldu.", "Bağlantı Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Bağlantı oluşturulamadı. Lütfen bilgileri kontrol edin.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //LcControl.UPDATE_SOAP_API_NENC lcControl = new AvukatProLib.LcControl.UPDATE_SOAP_API_NENC();
            //lcControl.Url = "http://update.avukatpro.com/UPDATE_SOAP_API_NENC.asmx";
            //lcControl.CheckProductKeyCompleted += new AvukatProLib.LcControl.CheckProductKeyCompletedEventHandler(lcControl_CheckProductKeyCompleted);
            //lcControl.CheckProductKeyAsync(txtLisansAnahtari.Text, string.Empty);
            AVPLicence.LicenceControl lisansKontrol = new LicenceControl();
            lisansKontrol.CheckProductKeyCompleted += new CheckProductKeyCompletedEventHandler(lisansKontrol_CheckProductKeyCompleted);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (BaglantiTamamMi == false)
            {
                MessageBox.Show("Sunucu bilgilerini kontrol ediniz.", "Sunucu Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(txtVTAdi.Text) || String.IsNullOrEmpty(txtKullaniciAdi.Text) || String.IsNullOrEmpty(txtParola.Text))
            {
                MessageBox.Show("Lütfen bağlantı bilgilerini giriniz");
                tabLisanslama.SelectedTab = tabPage1;
                return;
            }
            if (keyDogru && lisans != null)
            {
                CompInfo cmpNfo = new CompInfo();
                cmpNfo.BaglantiTipi = (int)BaglantiTipi.VeriTabani;
                cmpNfo.BaglantiZamanAsimi = 5000;
                cmpNfo.KomutZamanAsimi = 5000;
                cmpNfo.SaKullaniciSfr = txtSaParola.Text;
                cmpNfo.VeriTabaniKullaniciSfr = txtParola.Text;
                cmpNfo.VeriTabanıKullanicisi = txtKullaniciAdi.Text;
                cmpNfo.VeriTabaniSunucu = txtSunucuAdresi.Text;
                cmpNfo.HAVeriTabani = txtVTAdi.Text;
                cmpNfo.MKVeriTabani = "AVP_NMK";
                if (chkUygulamaSunucusuKullan.Checked == true)
                {
                    cmpNfo.BaglantiTipi = 1;
                }
                else
                {
                    cmpNfo.BaglantiTipi = 0;
                }
                cmpNfo.GuncelProxyKullan = chkProxyGuncelleme.Checked;
                cmpNfo.UProxyKullan = chkProxyUygulama.Checked;
                cmpNfo.ProxyKullaniciAdi = txtProxyKullaniciAdi.Text;
                cmpNfo.ProxyParola = txtProxyParolasi.Text;
                cmpNfo.ProxySunucuAdresi = txtProxySunucusu.Text;
                cmpNfo.ProxySunucuPortu = nmricProxyPortu.Value.ToString();
                cmpNfo.GuncelSunucuAdresi = txtGuncellemeSunucusu.Text;
                cmpNfo.UygulamaSunucuAdresi = txtUygulamaSunucusu.Text;
                cmpNfo.MachineCode = LicenseHelper.GetMachineCode(lisans.ProductKey);
                cmpNfo.LisansBilgisi = lisans;
                try
                {
                    DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                    StringWriter str = new StringWriter();
                    XmlSerializer xs = new XmlSerializer(lisans.GetType());
                    xs.Serialize(str, lisans);
                    str.Flush();
                    cmpNfo.HashedLicence = Lisans.LicenseHelper.EncyptLicence(str.ToString());
                }
                catch { }
                List<CompInfo> listem = new List<CompInfo>();
                listem.Add(cmpNfo);
                if (!CompInfo.Kaydet(listem, startupPath))
                {
                    MessageBox.Show("Programın kurulduğu klasor'de yazma izni olmadığı için lisans bilgileri kaydedilemedi");
                    listem = null;
                }
                else
                {
                    listem = null;
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void button2_EnabledChanged(object sender, EventArgs e)
        {
            if (button2.Enabled == true)
            {
                lblKontrolEt.Visible = false;
            }
            else
            {
                lblKontrolEt.Visible = true;
            }
        }

        private void chkProxyGuncelleme_CheckedChanged(object sender, EventArgs e)
        {
            ProxySeciliMi();
        }

        //}
        private void chkProxyUygulama_CheckedChanged(object sender, EventArgs e)
        {
            ProxySeciliMi();
        }

        private void chkUygulamaSunucusuKullan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUygulamaSunucusuKullan.Checked == true)
            {
                txtSaParola.Enabled = false;
                txtKullaniciAdi.Enabled = false;
                txtSunucuAdresi.Enabled = false;
                txtParola.Enabled = false;
                txtVTAdi.Enabled = false;
                btnDene.Enabled = false;
                txtUygulamaSunucusu.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
                txtSaParola.Enabled = true;
                txtKullaniciAdi.Enabled = true;
                txtSunucuAdresi.Enabled = true;
                txtParola.Enabled = true;
                txtVTAdi.Enabled = true;
                btnDene.Enabled = true;
                txtUygulamaSunucusu.Enabled = false;
            }
        }

        private void frmLisansAktiveEtme_Load(object sender, EventArgs e)
        {
            ProxySeciliMi();
            button2_EnabledChanged(sender, e);
            chkUygulamaSunucusuKullan_CheckedChanged(sender, e);
        }

        private void lisansKontrol_CheckProductKeyCompleted(object sender, CheckProductKeyCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                LisansBilgisi dizi = e.Result;
                if (dizi != null)
                {
                    lisans = dizi;
                    keyDogru = true;

                    MessageBox.Show("Lisans başarılı bir şekilde alındı", "Lisanslama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                keyDogru = false;
                txtKullaniciSayisi.Text = string.Empty;
                txtLisansTipi.Text = string.Empty;
                txtMusteri.Text = string.Empty;
                MessageBox.Show("Lisans kodu bulunamadı !", "Lisanslama", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Ürün aktifleştirme sunucusuna bağlanırken hatayla karşılaşıldı");
            }
        }

        //void lcControl_CheckProductKeyCompleted(object sender, AvukatProLib.LcControl.CheckProductKeyCompletedEventArgs e)
        //{
        //    if (e.Error == null)
        //    {
        //        string[] dizi = e.Result.Split('|');
        //        if (dizi.Length > 5)
        //        {
        //            lisans = new LisansBilgi();
        //            lisans.LisansAnahtari = txtLisansAnahtari.Text;
        //            lisans.MusteriAdi = dizi[0];
        //            lisans.ModulNo = Convert.ToInt32(dizi[2]);
        //            lisans.IcraKullanici = Convert.ToInt32(dizi[3]);
        //            lisans.DavaKullanici = Convert.ToInt32(dizi[4]);
        //            lisans.SorusturmaKullanici = Convert.ToInt32(dizi[5]);
        //            txtMusteri.Text = dizi[0];
        //            txtLisansTipi.Text = dizi[1];
        //            //txtKullaniciSayisi.Text = dizi[2];
        //            keyDogru = true;

        //            MessageBox.Show("Lisans başarılı bir şekilde alındı", "Lisanslama", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }

        //        keyDogru = false;
        //        txtKullaniciSayisi.Text = string.Empty;
        //        txtLisansTipi.Text = string.Empty;
        //        txtMusteri.Text = string.Empty;
        //        MessageBox.Show("Lisans kodu bulunamadı !", "Lisanslama", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;

        //    }
        //    else
        //    {
        //        MessageBox.Show("Ürün aktifleştirme sunucusuna bağlanırken hatayla karşılaşıldı");
        //    }
        //}

        private void ProxySeciliMi()
        {
            if (chkProxyGuncelleme.Checked | chkProxyUygulama.Checked)
            {
                txtProxySunucusu.Enabled = true;
                nmricProxyPortu.Enabled = true;
                txtProxyParolasi.Enabled = true;
                txtProxyKullaniciAdi.Enabled = true;
            }
            else
            {
                txtProxyKullaniciAdi.Enabled = false;
                txtProxyParolasi.Enabled = false;
                nmricProxyPortu.Enabled = false;
                txtProxySunucusu.Enabled = false;
            }
        }

        //private class LisansBilgi
        //{
        //    private int _IcraKullanici;
        //    private int _DavaKullanici;
        //    private int _SorusturmaKullanici;
        //    private int _ModulNo;
        //    private string _LisansAnahtari;
        //    private string _MusteriAdi;

        //    public string MusteriAdi
        //    {
        //        get { return _MusteriAdi; }
        //        set { _MusteriAdi = value; }
        //    }

        //    public string LisansAnahtari
        //    {
        //        get { return _LisansAnahtari; }
        //        set { _LisansAnahtari = value; }
        //    }

        //    public int ModulNo
        //    {
        //        get { return _ModulNo; }
        //        set { _ModulNo = value; }
        //    }

        //    public int SorusturmaKullanici
        //    {
        //        get { return _SorusturmaKullanici; }
        //        set { _SorusturmaKullanici = value; }
        //    }

        //    public int DavaKullanici
        //    {
        //        get { return _DavaKullanici; }
        //        set { _DavaKullanici = value; }
        //    }
    }
}