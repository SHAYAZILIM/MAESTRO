using AVPSetLicence;
using AvukatProLib;
using AvukatProRaporlar.Raport.Util;
using DevExpress.XtraEditors.Controls;
using RaporDataSource.TableDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Windows.Forms;

namespace AvukatProRaporlar.Forms
{
    public partial class frmIntro : Form
    {
        public frmIntro()
        {
            InitializeComponent();
        }

        //TODO:Burayý ortak bir yol vereceðiz.
        private string _sirketNfo = Application.StartupPath + "\\cmpnfo3.gio";

        private Connection con = new Connection();


        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public DataTable SubeleriGetir()
        {
            SqlDataAdapter da = new SqlDataAdapter("select SUBE_ADI, ID from TDIE_BIL_KULLANICI_SUBELERI", Program.compList[0].ConStr);
            DataTable dr = new DataTable();
            da.Fill(dr);
            return dr;
        }

        private void bwYukleyici_DoWork(object sender, DoWorkEventArgs e)
        {
            //try
            //{
            //    CompInfo ci = (CompInfo)e.Argument;
            //    if (ci != null)
            //    {
            //        DBDataContext db = null;
            //        if (con.MyConnection == null)
            //        {
            //            List<CompInfo> sList = Program.compList;
            //            foreach (CompInfo info in sList)
            //            {
            //                con.MyConnection = info.ConStr;
            //            }
            //            db = new DBDataContext(con.MyConnection);
            //        }
            //        else
            //        {
            //            db = new DBDataContext(con.MyConnection);
            //        }
            //        e.Result = db.TDIE_BIL_KULLANICI_SUBELERIs;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void bwYukleyici_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DBDataContext db = Program.db;

            #region

            //lkSube.Properties.DataSource = db.TDIE_BIL_KULLANICI_SUBELERIs.Select(item => new { item.SUBE_ADI, item.ID });
            lkSube.Properties.DataSource = SubeleriGetir();
            lkSube.Properties.DisplayMember = "SUBE_ADI";
            lkSube.Properties.ValueMember = "ID";
            lkSube.Properties.NullText = "Þube Seç";
            lkSube.Properties.Columns.Clear();
            lkSube.Properties.Columns.Add(new LookUpColumnInfo("SUBE_ADI", 10, "Þube"));
            lkSube.EditValue = 2;

            #endregion

            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            txteKullaniciAdi.Enabled = true;
            txteSifreBilgi.Enabled = true;
            txteKullaniciAdi.Focus();
        }

        private void frmIntro_Click(object sender, EventArgs e)
        {
            //AvukatProLib2.Entities.EntityBase.KontrolluMu = true;
        }

        private void frmIntro_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIntro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.F12)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void frmIntro_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\updating.tmp"))
            {
                if (MessageBox.Show("Maestro 2013 Güncellemesi devam etmektedir.\nBu yüzden programý kullanmamanýzý tavsiye ederiz.\nYinede devam etmek istiyor musunuz ?", "Uyarý-Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                    return;
                }
            }

            List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
            CompInfo cmpNfo = cmpNfoList[0];

            if (File.Exists(Application.StartupPath + "\\temp.ab"))
            {
                FileStream fs = new FileStream(Application.StartupPath + "\\temp.ab", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                cmpNfo.BilgisayarID = sr.ReadLine();
                cmpNfo.LisansNo = sr.ReadLine();
                cmpNfo.BaslangicTarihi = Convert.ToDateTime(sr.ReadLine());
                cmpNfo.BitisTarihi = Convert.ToDateTime(sr.ReadLine());
                cmpNfo.ModulNo = sr.ReadLine();
                cmpNfo.UrunAdi = sr.ReadLine();
                cmpNfo.Versiyon = sr.ReadLine();
                cmpNfo.Surum = sr.ReadLine();

                cmpNfo.HAVeriTabani = sr.ReadLine();
                cmpNfo.VeriTabaniSunucu = sr.ReadLine();
                cmpNfo.VeriTabanýKullanicisi = sr.ReadLine();
                string sfr = sr.ReadLine();
                cmpNfo.VeriTabaniKullaniciSfr = sfr;
                cmpNfo.SaKullaniciSfr = sfr;
                cmpNfo.CompanyName = sr.ReadLine();
                cmpNfo.UygulamaTipi = sr.ReadLine() == "Server" ? 0 : 1;
                cmpNfo.YeniEski = sr.ReadLine();
                sr.Close();
                sr.Dispose();
                fs.Close();
                fs.Dispose();
                CompInfo.Kaydet(cmpNfoList, Application.StartupPath);
                File.Delete(Application.StartupPath + "\\temp.ab");
            }

            lblLisansNo.Text = cmpNfo.LisansNo;
            lblSurumBilgisi.Text = cmpNfo.Versiyon + " " + cmpNfo.Surum;
            //Degiskenler.CnString = cmpNfo.ConStr;
            AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr = cmpNfo.ConStr;

            string ComputerInfo = "";
            ManagementClass islemci;
            islemci = new ManagementClass("Win32_ComputerSystemProduct");
            foreach (ManagementObject cpu in islemci.GetInstances())
            {
                ComputerInfo = Convert.ToString(cpu["UUID"]);
            }

            if (string.IsNullOrEmpty(cmpNfo.LisansNo) || ComputerInfo != cmpNfo.BilgisayarID)
            {
                bool sonuc = false;
                frmSetLicence frmli = new frmSetLicence(cmpNfo, sonuc);
                frmli.ShowDialog();
                CompInfo.Kaydet(cmpNfoList, Application.StartupPath);
            }

            if (string.IsNullOrEmpty(cmpNfo.LisansNo) || ComputerInfo != cmpNfo.BilgisayarID)
            {
                Application.Exit();
                return;
            }

            AVPLicenceControl.LisansKontrolu(Application.StartupPath);

            //FileStream fss = null;

            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");

                //NumberFormat ile ilgili hata çýkabileceði söyleniyor çýkarsa burdan düzeltilecektir (iki introda da olmak üzere)
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                //lblSurumBilgisi.Text = "v" + AssemblyVersion + " RC";
                this.Cursor = Cursors.Arrow;
                List<CompInfo> sList = Program.compList;
                if (sList.Count == 0)
                {
                    this.DialogResult = DialogResult.Yes;
                    return;
                }
                lkSirket.Properties.DataSource = sList;
                if (sList != null && sList.Count > 0)
                    lkSirket.EditValue = sList[0];
                lkSirket.Properties.DisplayMember = "CompanyName";

                foreach (CompInfo info in sList)
                {
                    if (info.CompanyName == sList[0].CompanyName)
                        con.MyConnection = info.ConStr;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmIntro_Shown(object sender, EventArgs e)
        {
        }

        private void lblKullanici_Click(object sender, EventArgs e)
        {
        }

        private void lblLisansNo_Click(object sender, EventArgs e)
        {
        }

        private void lkSirket_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CompInfo ci = lkSirket.EditValue as CompInfo;

                var davarefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetDavaOzelKodReferans(ci.ConStr);
                var icrarefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetIcraOzelKodReferans(ci.ConStr);
                var sorusturmarefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetSorusturmaOzelKodReferans(ci.ConStr);
                var sozlezmerefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetSozlesmeOzelKodReferans(ci.ConStr);
                var ortakrefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetOrtakOzelKodReferans(ci.ConStr);

                #region Özel Kod Özelleþtirme

                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans1 = icrarefoz.IcraANrefarans1;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans2 = icrarefoz.IcraANreferans2;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraAnReferans.Referans3 = icrarefoz.IcraANreferans3;

                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelDurum.Banka = icrarefoz.IcraOzelDurumBanka;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelDurum.FoyBirim = icrarefoz.IcraOzelDurumFoyBirim;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelDurum.FoyYeri = icrarefoz.IcraOzelDurumFoyYeri;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelDurum.Klasor1 = icrarefoz.IcraOzelDurumKlasor1;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelDurum.Klasor2 = icrarefoz.IcraOzelDurumKlasor2;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelDurum.KrediGrup = icrarefoz.IcraOzelDurumKrediGrup;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelDurum.KrediTip = icrarefoz.IcraOzelDurumKrediTip;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelDurum.Ozel = icrarefoz.IcraOzelDurumOzel;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelDurum.Sube = icrarefoz.IcraOzelDurumSube;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelDurum.Tahsilat = icrarefoz.IcraOzelDurumTahsilat;

                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod1 = icrarefoz.IcraOzelKod1;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod2 = icrarefoz.IcraOzelKod2;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod3 = icrarefoz.IcraOzelKod3;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod4 = icrarefoz.IcraOzelKod4;

                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraReferans.Referans1 = icrarefoz.IcraReferans1;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraReferans.Referans2 = icrarefoz.IcraReferans2;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraReferans.Referans3 = icrarefoz.IcraReferans3;

                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaDnReferans.Referans1 = davarefoz.DavaNedenReferans1;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaDnReferans.Referans2 = davarefoz.DavaNedenReferans2;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaDnReferans.Referans3 = davarefoz.DavaNedenReferans3;

                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod1 = davarefoz.DavaOzelKod1;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod2 = davarefoz.DavaOzelKod2;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod3 = davarefoz.DavaOzelKod3;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod4 = davarefoz.DavaOzelKod4;

                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans1 = davarefoz.DavaReferans1;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans2 = davarefoz.DavaReferans2;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans3 = davarefoz.DavaReferans3;

                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod1 = sorusturmarefoz.SorusturmaOzelKod1;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod2 = sorusturmarefoz.SorusturmaOzelKod2;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod3 = sorusturmarefoz.SorusturmaOzelKod3;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod4 = sorusturmarefoz.SorusturmaOzelKod4;

                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaReferans.Referans1 = sorusturmarefoz.SorusturmaReferans1;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaReferans.Referans2 = sorusturmarefoz.SorusturmaReferans2;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaReferans.Referans3 = sorusturmarefoz.SorusturmaReferans3;

                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod1 = sozlezmerefoz.SozlesmeOzelKod1;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod2 = sozlezmerefoz.SozlesmeOzelKod2;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod3 = sozlezmerefoz.SozlesmeOzelKod3;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod4 = sozlezmerefoz.SozlesmeOzelKod4;

                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SozlesmeReferans.Referans1 = sozlezmerefoz.SozlesmeReferans1;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SozlesmeReferans.Referans2 = sozlezmerefoz.SozlesmeReferans2;
                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SozlesmeReferans.Referans3 = sozlezmerefoz.SozlesmeReferans3;


                #endregion

                #region tmpKOCZER Özel

                //if (ci != null && ci.LisansBilgisi.AdSoyad.Contains("KOCZER"))
                //{
                //    AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod1 = "Müþteri";
                //    AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod2 = "Tedarikçi";
                //    AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod3 = "Hizmet";
                //    AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod.OzelKod4 = "Lokasyon";
                //    AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod;
                //    AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SorusturmaOzelKod = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod;
                //    AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SozlesmeOzelKod = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.IcraOzelKod;
                //}

                #endregion

                CheckForIllegalCrossThreadCalls = false;
                if (!bwYukleyici.IsBusy)
                {
                    bwYukleyici.RunWorkerAsync(ci);
                }
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                con.MyConnection = ci.ConStr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void picCik_EditValueChanged(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void pictureEdit1_MouseClick(object sender, MouseEventArgs e)
        {
            simpleButton1_Click(null, new EventArgs());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DBDataContext db = Program.db;

            try
            {
                if (lkSube.EditValue != null)
                {
                    var kullanici = db.TDI_BIL_KULLANICI_LISTESIs.Where(vii => vii.KULLANICI_ADI == txteKullaniciAdi.Text && vii.KULLANICI_SIFRESI == txteSifreBilgi.Text && vii.SUBE_ID == (int)lkSube.EditValue);

                    if (kullanici != null && kullanici.Count() > 0)
                    {
                        AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi = (kullanici.First() as TDI_BIL_KULLANICI_LISTESI);

                        // TODO: þimdilik kaatýldý
                        //AuthHelperBase yetkicik = AuthHelperBase.GetAuthHelper(kullanici.First().ID, "AvukatProRaporlar.Forms.rfrmMain");
                        AuthHelperBase yetkicik = new AuthHelperBase();
                        AuthHelperBase.StartupPath = Application.StartupPath;
                        yetkicik.FormAcabilir = true;
                        if (yetkicik == null)
                        {
                            MessageBox.Show("Kullanýcý hesabý bakým modülü için yetkili deðil");
                            return;
                        }
                        if (yetkicik.FormAcabilir)
                        {
                            this.DialogResult = DialogResult.OK;
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Kullanýcý hesabý bakým modülü için yetkili deðil");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanýcý hesabý aktif deðil");
                        return;
                    }
                }
                MessageBox.Show("Kullanýcý adý ,parola veya Þube yanlýþ.", "Hata", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txteKullaniciAdi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txteSifreBilgi.Focus();
            }
        }

        private void txteSifreBilgi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //pictureEdit1.Focus();
                simpleButton1_Click(null, null);
            }
        }
    }
}