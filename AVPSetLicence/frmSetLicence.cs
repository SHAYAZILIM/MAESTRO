using AvukatProLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Management;
using System.Windows.Forms;

namespace AVPSetLicence
{
    public partial class frmSetLicence : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmSetLicence(CompInfo cmpNfo, bool Sonuc)
        {
            InitializeComponent();
            this.cmpNfo = cmpNfo;
            this.Sonuc = Sonuc;
        }

        private CompInfo cmpNfo;
        private bool Sonuc;

        private void btnActivateLicense_Click(object sender, EventArgs e)
        {
            ABSqlConnection cn = new ABSqlConnection();

            cn.CnString = "data source=" + Properties.Settings.Default.LicenceServer + "\\SQLEXPRESS;database=AVPYONETIM;uid=avp;pwd=PASSWRD1;";

            string ComputerInfo = "";
            ManagementClass islemci;
            islemci = new ManagementClass("Win32_ComputerSystemProduct");
            foreach (ManagementObject cpu in islemci.GetInstances())
            {
                ComputerInfo = Convert.ToString(cpu["UUID"]);
            }

            cn.Clear();
            cn.AddParams("@KullaniciAdi", txtEmail.Text);
            cn.AddParams("@BilgisayarBilgisi", ComputerInfo);
            cn.AddParams("@LisansNo", txtLisansNo.Text);
            //cn.AddParams("@UrunID", cmpNfo.ModulNo == null ? "350" : cmpNfo.ModulNo);
            //DataTable dt = cn.GetDataTable("select a.*,c.UrunAdi from dbo.Lisanslar(nolock) a inner join dbo.Kullanicilar(nolock) b on b.MusteriID=a.MusteriID inner join dbo.Urunler(nolock) c on c.ModulNo=a.UrunID where b.KullaniciAdi=@KullaniciAdi and a.UrunID=@UrunID and a.Durumu=1 and (BilgisayarBilgisi='' or BilgisayarBilgisi=@BilgisayarBilgisi OR BilgisayarBilgisi is null) and a.LisansNo=@LisansNo and a.BitisTarihi>GETDATE()");
            DataTable dt = cn.GetDataTable("select a.*,c.UrunAdi from dbo.Lisanslar(nolock) a inner join dbo.Kullanicilar(nolock) b on b.MusteriID=a.MusteriID inner join dbo.Urunler(nolock) c on c.ModulNo=a.UrunID where b.KullaniciAdi=@KullaniciAdi and a.Durumu=1 and (BilgisayarBilgisi='' or BilgisayarBilgisi=@BilgisayarBilgisi OR BilgisayarBilgisi is null) and a.LisansNo=@LisansNo and a.BitisTarihi>GETDATE()");

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Lisans bilgileri doğrulanamadı.\nLütfen bilgilerinizi kontrol edin.\n\n* Mail adresi hatalı olabilir.\n* Lisans anahtarı hatalı olabilir.\n* Lisans bitiş tarihiniz geçmiş olabilir.\n\nEğer bilgilerinizde eksiklik yoksa lütfen Avukat Market'deki müşteri temsilcinizle iletişime geçin.");
                Sonuc = false;
            }
            else
            {
                Sonuc = true;
                cn.Clear();
                cn.AddParams("@BilgisayarBilgisi", ComputerInfo);
                cn.AddParams("@LisansNo", txtLisansNo.Text);
                cn.AddParams("@UrunID", dt.Rows[0]["UrunID"].ToString());
                cn.ExcuteQuery("update dbo.Lisanslar set BilgisayarBilgisi=@BilgisayarBilgisi where LisansNo=@LisansNo and UrunID=@UrunID");

                cmpNfo.BilgisayarID = ComputerInfo;
                cmpNfo.LisansNo = txtLisansNo.Text;
                cmpNfo.BaslangicTarihi = Convert.ToDateTime(dt.Rows[0]["BaslangicTarihi"].ToString());
                cmpNfo.BitisTarihi = Convert.ToDateTime(dt.Rows[0]["BitisTarihi"].ToString());
                cmpNfo.ModulNo = dt.Rows[0]["UrunID"].ToString();
                cmpNfo.UrunAdi = dt.Rows[0]["UrunAdi"].ToString();

                lblBaslangicTarihi.Text = cmpNfo.BaslangicTarihi.ToShortDateString();
                lblBitisTarihi.Text = cmpNfo.BitisTarihi.ToShortDateString();
                lblSozlesmeTarihi.Text = Convert.ToDateTime(dt.Rows[0]["SozlesmeTarihi"].ToString()).ToShortDateString();
                lblUrunAdi.Text = cmpNfo.UrunAdi;

                lblVersiyon.Text = cmpNfo.Versiyon;
                lblSurum.Text = cmpNfo.Surum;
                List<CompInfo> ci = new List<CompInfo>();
                ci.Add(cmpNfo);
                CompInfo.Kaydet(ci, Application.StartupPath);
                MessageBox.Show("Lisans aktivasyonu başarılı bir şekilde tamamlandı.\nLisans bilgilerinizi kontrol edip işleminize devam edebilirsiniz.");
            }
        }

        private void frmSetLicence_Load(object sender, EventArgs e)
        {
            string ComputerInfo = "";
            ManagementClass islemci;
            islemci = new ManagementClass("Win32_ComputerSystemProduct");
            foreach (ManagementObject cpu in islemci.GetInstances())
            {
                ComputerInfo = Convert.ToString(cpu["UUID"]);
            }

            bool licenceVar = true;
            if (string.IsNullOrEmpty(cmpNfo.LisansNo) || ComputerInfo != cmpNfo.BilgisayarID)
            {
                licenceVar = false;
            }

            if (string.IsNullOrEmpty(cmpNfo.LisansNo) || ComputerInfo != cmpNfo.BilgisayarID)
            {
                licenceVar = false;
            }

            if (licenceVar)
            {
                //groupControl1.Enabled = false;
                lblBaslangicTarihi.Text = cmpNfo.BaslangicTarihi.ToShortDateString();
                lblBitisTarihi.Text = cmpNfo.BitisTarihi.ToShortDateString();
                //lblSozlesmeTarihi.Text = cmpNfo .ToShortDateString();,
                lblSozlesmeTarihi.Visible = false;
                //labelControl4.Visible = false;
                lblUrunAdi.Text = cmpNfo.UrunAdi;

                lblVersiyon.Text = cmpNfo.Versiyon;
                lblSurum.Text = cmpNfo.Surum;
            }
        }
    }
}