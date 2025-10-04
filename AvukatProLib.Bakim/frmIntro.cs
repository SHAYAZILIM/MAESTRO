using AVPSetLicence;
using AvukatProLib.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Data.SqlClient;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Management;
using System.Reflection;
using System.Windows.Forms;

namespace AvukatProLib.Bakim
{
    public partial class frmIntro : Form
    {
        public frmIntro()
        {
            InitializeComponent();
        }

        public static bool IsGenel = false;

        //TODO:Burayý ortak bir yol vereceðiz.
        private string _sirketNfo = Application.StartupPath + "\\cmpnfo3.gio";

        private CompInfo ci;

        //private static frmMain mainForm = new frmMain();

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private void bwYukleyici_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ci = (CompInfo)e.Argument;
                if (ci != null)
                {
                    //if (DataRepository.Providers[ci.CompanyName] == null)
                    //{
                    SqlNetTiersProvider prov = new SqlNetTiersProvider();
                    System.Collections.Specialized.NameValueCollection nameValueCollection =
                        new System.Collections.Specialized.NameValueCollection();
                    nameValueCollection.Add("UseStoredProcedure", "false");
                    nameValueCollection.Add("EnableEntityTracking", "true");
                    nameValueCollection.Add("EntityCreationalFactoryType", "AvukatProLib2.Entities.EntityFactory");
                    nameValueCollection.Add("EnableMethodAuthorization", "false");
                    nameValueCollection.Add("ConnectionString", ci.ConStr);
                    nameValueCollection.Add("ConnectionStringName", "conStr" + ci.LisansBilgisi.AdSoyad);
                    nameValueCollection.Add("ProviderInvariantName", "System.Data.SqlClient");
                    prov.Initialize(ci.LisansBilgisi.AdSoyad, nameValueCollection);
                    DataRepository.LoadProvider(prov, true);

                    //}
                    //else
                    //{
                    //    AvukatProLib2.Data.Bases.NetTiersProvider prov = DataRepository.Providers[ci.CompanyName];
                    //    DataRepository.LoadProvider(prov, true);

                    //}

                    e.Result = DataRepository.TDIE_BIL_KULLANICI_SUBELERIProvider.GetAll();
                }
            }
            catch (Exception ex)
            {
                //BelgeUtil.ErrorHandler.Catch(this, ex);
                MessageBox.Show(ex.ToString());
            }
        }

        private void bwYukleyici_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lkSube.Properties.DataSource = e.Result;
            if (((TList<TDIE_BIL_KULLANICI_SUBELERI>)e.Result).Count > 0)
                lkSube.EditValue = ((TList<TDIE_BIL_KULLANICI_SUBELERI>)e.Result)[0].ID;
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            txteKullaniciAdi.Enabled = true;
            txteSifreBilgi.Enabled = true;
            txteKullaniciAdi.Focus();
        }

        private void frmIntro_Click(object sender, EventArgs e)
        {
            AvukatProLib2.Entities.EntityBase.KontrolluMu = true;
        }

        private void frmIntro_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIntro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.F12)
            {
                IsGenel = true;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void frmIntro_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\updating.tmp"))
            {
                if (MessageBox.Show("Yeni Nesil 2013 Güncellemesi devam etmektedir.\nBu yüzden programý kullanmamanýzý tavsiye ederiz.\nYinede devam etmek istiyor musunuz ?", "Uyarý-Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
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

                #region Kapandý

                //List<CompInfo> sList = new List<CompInfo>();

                //Process prc = new Process();
                //prc.StartInfo = new ProcessStartInfo(Application.StartupPath + "\\rar.exe", "e -p1q2w3e4r " + Application.StartupPath + "\\cmpnfo3.giorar");
                //prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                //prc.Start();
                ////prc.WaitForExit();

                ////if (!File.Exists(_sirketNfo))
                ////{
                ////    sList = new List<CompInfo>();
                ////    CompInfo ci = new CompInfo("AvukatPro Server", "server=192.9.0.199;database=AVP_NHA_NG;uid=yilmaz;pwd=123");
                ////    CompInfo ci2 = new CompInfo("AvukatPro Boþ VT", "server=192.9.0.199;database=AVP_NHA_BOS;uid=yilmaz;pwd=123");

                ////    sList.Add(ci);

                ////    FileStream fs = new FileStream(_sirketNfo, FileMode.CreateNew);
                ////    BinaryFormatter bf = new BinaryFormatter();

                ////    bf.Serialize(fs, sList);
                ////    fs.Close();
                ////}

                //fss = File.OpenRead(_sirketNfo);
                //BinaryFormatter bff = new BinaryFormatter();

                //List<CompInfo> cinf = (List<CompInfo>)bff.Deserialize(fss);
                //foreach (CompInfo cmpinf in cinf)
                //{
                //    cmpinf.DecodeData();
                //    sList.Add(cmpinf);
                //}

                #endregion Kapandý

                List<CompInfo> sList = CompInfo.CompInfoListGetir();
                if (sList.Count == 0)
                {
                    IsGenel = true;
                    this.DialogResult = DialogResult.Yes;
                    return;
                }
                lkSirket.Properties.DataSource = sList;
                if (sList != null && sList.Count > 0)
                    lkSirket.EditValue = sList[0];
                lkSirket.Properties.DisplayMember = "CompanyName";
                foreach (CompInfo info in sList)
                {
                    DataRepository.AddConnection(info.LisansBilgisi.AdSoyad, info.ConStr);
                }
            }
            catch
            {
                //MessageBox.Show(ex.ToString());
                //simpleButton1_Click(simpleButton2, new EventArgs());
            }

            //finally
            //{
            //    fss.Close();
            //    File.Delete(_sirketNfo);
            //}
        }

        private void frmIntro_Shown(object sender, EventArgs e)
        {
        }

        private void lkSirket_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CompInfo ci = lkSirket.EditValue as CompInfo;
                CheckForIllegalCrossThreadCalls = false;
                if (!bwYukleyici.IsBusy)
                {
                    bwYukleyici.RunWorkerAsync(ci);
                }
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            }
            catch (Exception ex)
            {
                //BelgeUtil.ErrorHandler.Catch(this, ex);
                MessageBox.Show(ex.ToString());
            }
        }

        private void picCik_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit1_MouseClick(object sender, MouseEventArgs e)
        {
            simpleButton1_Click(null, new EventArgs());
        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lkSube.EditValue != null)
                {
                    TDI_BIL_KULLANICI_LISTESI kullanici =
                        DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.
                            GetByKULLANICI_ADIKULLANICI_SIFRESIKULLANICI_SUBE_ID(txteKullaniciAdi.Text, txteSifreBilgi.Text,
                                                                                 (int)lkSube.EditValue);
                    if (kullanici != null)
                    {
                        if (kullanici.KULLANICI_AKTIF)
                        {
                            Kimlikci.Kimlik.Bilgi = kullanici;
                            this.TopMost = false;
                            if (lkSube.EditValue is int)
                            {
                                kullanici.KULLANICI_SUBE_IDSource = AvukatProLib2.Data.DataRepository.TDIE_BIL_KULLANICI_SUBELERIProvider.GetByID(Convert.ToInt32(lkSube.EditValue));
                            }
                            else
                            {
                                kullanici.KULLANICI_SUBE_IDSource = (TDIE_BIL_KULLANICI_SUBELERI)lkSube.EditValue;
                            }
                            DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.DeepLoad(kullanici, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                            Kimlikci.Kimlik.SirketBilgisi = (CompInfo)lkSirket.EditValue;
                            //pictureEdit1.Image = ýmageList1.Images[3];
                            AuthHelperBase yetkicik = AuthHelperBase.GetAuthHelper(kullanici.ID, "AvukatProLib.Bakim.rfrmMain");
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
            }
            catch (Exception ex)
            {
                //BelgeUtil.ErrorHandler.Catch(this, ex);
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
                //
                //pictureEdit1.Focus();
                simpleButton1_Click(null, null);
            }
        }
    }
}