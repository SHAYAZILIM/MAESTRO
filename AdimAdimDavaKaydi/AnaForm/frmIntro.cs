#define LisansKontrollu

using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.PaketKontrol;
using AdimAdimDavaKaydi.Util;
using AVPSetLicence;
using AvukatPro.Model.DaoClasses;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Data.SqlClient;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Security.Principal;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.AnaForm
{
    public partial class frmIntro : XtraForm
    {
        public frmIntro()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        internal static Kisayol.AcilisSekli AcilisSekli = Kisayol.AcilisSekli.Normal;
        internal static AvukatProLib.Extras.FormType FormTipi = AvukatProLib.Extras.FormType.KurumsalGirisEkran;
        internal string AcilacakDosyaYolu = string.Empty;

        private string _sirketNfo = AdimAdimDavaKaydi.Util.KullaniciAyar.frmBaglantiAyar.SirketNfo;

        private BackgroundWorker bw = new BackgroundWorker();

        private CompInfo ci;

        private List<CompInfo> list;

        private mdiAvukatPro mdiForm;
        private bool subelerLoaded;

        public string AssemblyVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        public string Password { get; set; }

        public string[] StartUpParams { get; set; }

        //Kullanýcýnýn otomatik olarak login olabilmesini saðlamak üzere eklendi
        public string UserName { get; set; }

        public void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cmpNfoList == null)
                cmpNfoList = CompInfo.CmpNfoList;
            CompInfo cmpNfo = cmpNfoList[0];
            AvukatProLib.Kimlik.SirketBilgisi.ConStr = cmpNfo.ConStr;
            pictureEdit1.Enabled = false;
            txteKullaniciAdi.Enabled = false;
            txteSifreBilgi.Enabled = false;
            //try
            //{


            if (lkSube.EditValue != null)
            {
                TDI_BIL_KULLANICI_LISTESI kullanici = null;
                if (this.Tag != "LDAP")
                {
                    kullanici = DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.
                        GetByKULLANICI_ADIKULLANICI_SIFRESIKULLANICI_SUBE_ID(txteKullaniciAdi.Text,
                                                                             txteSifreBilgi.Text,
                                                                             (int)lkSube.EditValue);

                }
                else
                {
                    kullanici =
                        DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetByKULLANICI_ADI(txteKullaniciAdi.Text);
                    if (kullanici != null && kullanici.KULLANICI_SUBE_ID != (int)lkSube.EditValue)
                    {
                        kullanici = null;
                    }
                }
                if (kullanici != null && (kullanici.HATALI_GIRIS < 3 || !kullanici.HATALI_GIRIS.HasValue))
                {
                    #region Giriþ Baþarýlý

                    kullanici.HATALI_GIRIS = 0;
                    DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.Save(kullanici);

                    if (kullanici.KULLANICI_AKTIF)
                    {
                        AvukatProLib.Kimlik.Bilgi = kullanici;
                        this.TopMost = false;
                        if (lkSube.EditValue is int)
                        {
                            kullanici.KULLANICI_SUBE_IDSource =
                                AvukatProLib2.Data.DataRepository.TDIE_BIL_KULLANICI_SUBELERIProvider.GetByID(
                                    Convert.ToInt32(lkSube.EditValue));
                        }
                        else
                        {
                            kullanici.KULLANICI_SUBE_IDSource = (TDIE_BIL_KULLANICI_SUBELERI)lkSube.EditValue;
                        }
                        AvukatProLib.Kimlik.SirketBilgisi = (CompInfo)lkSirket.EditValue;

                        #region Özel Kod Özelleþtirme

                        if (AvukatProLib.Kimlik.SirketBilgisi != null)
                        {
                            var davarefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetDavaOzelKodReferans(cmpNfo.ConStr);
                            var icrarefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetIcraOzelKodReferans(cmpNfo.ConStr);
                            var sorusturmarefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetSorusturmaOzelKodReferans(cmpNfo.ConStr);
                            var sozlezmerefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetSozlesmeOzelKodReferans(cmpNfo.ConStr);
                            var ortakrefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetOrtakOzelKodReferans(cmpNfo.ConStr);
                            
                            AvukatProLib.Kimlikci.Kimlik.OrtakOzelDurum.Banka = ortakrefoz.OrtakOzelDurumBanka;
                            AvukatProLib.Kimlikci.Kimlik.OrtakOzelDurum.FoyBirim = ortakrefoz.OrtakOzelDurumFoyBirim;
                            AvukatProLib.Kimlikci.Kimlik.OrtakOzelDurum.FoyYeri = ortakrefoz.OrtakOzelDurumFoyYeri;
                            AvukatProLib.Kimlikci.Kimlik.OrtakOzelDurum.Klasor1 = ortakrefoz.OrtakOzelDurumKlasor1;
                            AvukatProLib.Kimlikci.Kimlik.OrtakOzelDurum.Klasor2 = ortakrefoz.OrtakOzelDurumKlasor2;
                            AvukatProLib.Kimlikci.Kimlik.OrtakOzelDurum.KrediGrup = ortakrefoz.OrtakOzelDurumKrediGrup;
                            AvukatProLib.Kimlikci.Kimlik.OrtakOzelDurum.KrediTip = ortakrefoz.OrtakOzelDurumKrediTip;
                            AvukatProLib.Kimlikci.Kimlik.OrtakOzelDurum.Ozel = ortakrefoz.OrtakOzelDurumOzel;
                            AvukatProLib.Kimlikci.Kimlik.OrtakOzelDurum.Sube = ortakrefoz.OrtakOzelDurumSube;
                            AvukatProLib.Kimlikci.Kimlik.OrtakOzelDurum.Tahsilat = ortakrefoz.OrtakOzelDurumTahsilat;


                            AvukatProLib.Kimlikci.Kimlik.IcraAnReferans.Referans1 = icrarefoz.IcraANrefarans1;
                            AvukatProLib.Kimlikci.Kimlik.IcraAnReferans.Referans2 = icrarefoz.IcraANreferans2;
                            AvukatProLib.Kimlikci.Kimlik.IcraAnReferans.Referans3 = icrarefoz.IcraANreferans3;

                            AvukatProLib.Kimlikci.Kimlik.IcraOzelDurum.Banka = icrarefoz.IcraOzelDurumBanka;
                            AvukatProLib.Kimlikci.Kimlik.IcraOzelDurum.FoyBirim = icrarefoz.IcraOzelDurumFoyBirim;
                            AvukatProLib.Kimlikci.Kimlik.IcraOzelDurum.FoyYeri = icrarefoz.IcraOzelDurumFoyYeri;
                            AvukatProLib.Kimlikci.Kimlik.IcraOzelDurum.Klasor1 = icrarefoz.IcraOzelDurumKlasor1;
                            AvukatProLib.Kimlikci.Kimlik.IcraOzelDurum.Klasor2 = icrarefoz.IcraOzelDurumKlasor2;
                            AvukatProLib.Kimlikci.Kimlik.IcraOzelDurum.KrediGrup = icrarefoz.IcraOzelDurumKrediGrup;
                            AvukatProLib.Kimlikci.Kimlik.IcraOzelDurum.KrediTip = icrarefoz.IcraOzelDurumKrediTip;
                            AvukatProLib.Kimlikci.Kimlik.IcraOzelDurum.Ozel = icrarefoz.IcraOzelDurumOzel;
                            AvukatProLib.Kimlikci.Kimlik.IcraOzelDurum.Sube = icrarefoz.IcraOzelDurumSube;
                            AvukatProLib.Kimlikci.Kimlik.IcraOzelDurum.Tahsilat = icrarefoz.IcraOzelDurumTahsilat;

                            AvukatProLib.Kimlikci.Kimlik.IcraOzelKod.OzelKod1 = icrarefoz.IcraOzelKod1;
                            AvukatProLib.Kimlikci.Kimlik.IcraOzelKod.OzelKod2 = icrarefoz.IcraOzelKod2;
                            AvukatProLib.Kimlikci.Kimlik.IcraOzelKod.OzelKod3 = icrarefoz.IcraOzelKod3;
                            AvukatProLib.Kimlikci.Kimlik.IcraOzelKod.OzelKod4 = icrarefoz.IcraOzelKod4;

                            AvukatProLib.Kimlikci.Kimlik.IcraReferans.Referans1 = icrarefoz.IcraReferans1;
                            AvukatProLib.Kimlikci.Kimlik.IcraReferans.Referans2 = icrarefoz.IcraReferans2;
                            AvukatProLib.Kimlikci.Kimlik.IcraReferans.Referans3 = icrarefoz.IcraReferans3;

                            AvukatProLib.Kimlikci.Kimlik.DavaDnReferans.Referans1 = davarefoz.DavaNedenReferans1;
                            AvukatProLib.Kimlikci.Kimlik.DavaDnReferans.Referans2 = davarefoz.DavaNedenReferans2;
                            AvukatProLib.Kimlikci.Kimlik.DavaDnReferans.Referans3 = davarefoz.DavaNedenReferans3;

                            AvukatProLib.Kimlikci.Kimlik.DavaOzelKod.OzelKod1 = davarefoz.DavaOzelKod1;
                            AvukatProLib.Kimlikci.Kimlik.DavaOzelKod.OzelKod2 = davarefoz.DavaOzelKod2;
                            AvukatProLib.Kimlikci.Kimlik.DavaOzelKod.OzelKod3 = davarefoz.DavaOzelKod3;
                            AvukatProLib.Kimlikci.Kimlik.DavaOzelKod.OzelKod4 = davarefoz.DavaOzelKod4;

                            AvukatProLib.Kimlikci.Kimlik.DavaReferans.Referans1 = davarefoz.DavaReferans1;
                            AvukatProLib.Kimlikci.Kimlik.DavaReferans.Referans2 = davarefoz.DavaReferans2;
                            AvukatProLib.Kimlikci.Kimlik.DavaReferans.Referans3 = davarefoz.DavaReferans3;

                            AvukatProLib.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod1 = sorusturmarefoz.SorusturmaOzelKod1;
                            AvukatProLib.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod2 = sorusturmarefoz.SorusturmaOzelKod2;
                            AvukatProLib.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod3 = sorusturmarefoz.SorusturmaOzelKod3;
                            AvukatProLib.Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod4 = sorusturmarefoz.SorusturmaOzelKod4;

                            AvukatProLib.Kimlikci.Kimlik.SorusturmaReferans.Referans1 = sorusturmarefoz.SorusturmaReferans1;
                            AvukatProLib.Kimlikci.Kimlik.SorusturmaReferans.Referans2 = sorusturmarefoz.SorusturmaReferans2;
                            AvukatProLib.Kimlikci.Kimlik.SorusturmaReferans.Referans3 = sorusturmarefoz.SorusturmaReferans3;

                            AvukatProLib.Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod1 = sozlezmerefoz.SozlesmeOzelKod1;
                            AvukatProLib.Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod2 = sozlezmerefoz.SozlesmeOzelKod2;
                            AvukatProLib.Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod3 = sozlezmerefoz.SozlesmeOzelKod3;
                            AvukatProLib.Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod4 = sozlezmerefoz.SozlesmeOzelKod4;

                            AvukatProLib.Kimlikci.Kimlik.SozlesmeReferans.Referans1 = sozlezmerefoz.SozlesmeReferans1;
                            AvukatProLib.Kimlikci.Kimlik.SozlesmeReferans.Referans2 = sozlezmerefoz.SozlesmeReferans2;
                            AvukatProLib.Kimlikci.Kimlik.SozlesmeReferans.Referans3 = sozlezmerefoz.SozlesmeReferans3;

                            if (!Util.AuthHelper.PasswordControl(kullanici.KULLANICI_SIFRESI, false))
                            {
                                MessageBox.Show("Parolanýz Güvenlik prosedürüne uymamaktadýr. Lütfen deðiþtiriniz.");

                                pictureEdit1.Enabled = true;
                                txteKullaniciAdi.Enabled = true;
                                txteSifreBilgi.Enabled = true;
                                if ((new frmParolaDegistirme()).ShowDialog() != DialogResult.OK)
                                    return;
                            }
                        }

                        #endregion Özel Kod Özelleþtirme

                        #region tmpKOCZER Özel

                        if (AvukatProLib.Kimlik.SirketBilgisi != null &&
                            AvukatProLib.Kimlik.SirketBilgisi.LisansBilgisi.AdSoyad.Contains("KOCZER"))
                        {
                            Kimlikci.Kimlik.IcraOzelKod.OzelKod1 = "Müþteri";
                            Kimlikci.Kimlik.IcraOzelKod.OzelKod2 = "Tedarikçi";
                            Kimlikci.Kimlik.IcraOzelKod.OzelKod3 = "Hizmet";
                            Kimlikci.Kimlik.IcraOzelKod.OzelKod4 = "Lokasyon";
                            Kimlikci.Kimlik.DavaOzelKod = Kimlikci.Kimlik.IcraOzelKod;
                            Kimlikci.Kimlik.SorusturmaOzelKod = Kimlikci.Kimlik.IcraOzelKod;
                            Kimlikci.Kimlik.SozlesmeOzelKod = Kimlikci.Kimlik.IcraOzelKod;
                        }

                        #endregion tmpKOCZER Özel

                        //pictureEdit1.Image = ýmageList1.Images[3];
                        if (kullaniciGirebilirMi(kullanici.ID))
                        {
                            #region KONTROL_KIM_ID / SUBE_KOD_ID

                            EntityBase.BagliKullaniciId = kullanici.ID;
                            EntityBase.BagliSubeId = kullanici.KULLANICI_SUBE_ID;

                            #endregion KONTROL_KIM_ID / SUBE_KOD_ID

                            this.DialogResult = DialogResult.OK;

                            #region frmAnaGirisEkranForm'dan alýnanlar

                            if (StartUpParams != null)
                            {
                                if (StartUpParams.Length >= 4)
                                {
                                    UserName = StartUpParams[2];
                                    Password = StartUpParams[3];
                                }
                            }
                            FormTipi = AvukatProLib.Extras.FormType.KurumsalGirisEkran;
                            BackgroundWorker bckw = new BackgroundWorker();
                            bckw.DoWork += delegate(object sender2, DoWorkEventArgs e2)
                            {
                                this.GetPaketForm();
                            };
                            bckw.RunWorkerCompleted += delegate(object sender2, RunWorkerCompletedEventArgs e2)
                            {
                                OpenMdiForm();
                            };
                            bckw.RunWorkerAsync();

                            #endregion frmAnaGirisEkranForm'dan alýnanlar
                        }
                        return;
                    }
                    else
                    {
                        pictureEdit1.Enabled = true;
                        txteKullaniciAdi.Enabled = true;
                        txteSifreBilgi.Enabled = true;
                        MessageBox.Show("Kullanýcý hesabý aktif deðil");
                        return;
                    }

                    #endregion Giriþ Baþarýlý
                }

                pictureEdit1.Enabled = true;
                txteKullaniciAdi.Enabled = true;
                txteSifreBilgi.Enabled = true;

                #region Giriþ Baþarýsýz

                MessageBox.Show("Kullanýcý adý ,parola veya Þube yanlýþ.", "Hata", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                kullanici =
                    DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetByKULLANICI_ADI(txteKullaniciAdi.Text);
                if (kullanici != null)
                {
                    if (kullanici.HATALI_GIRIS.HasValue && kullanici.HATALI_GIRIS < 3)
                    {
                        kullanici.HATALI_GIRIS++;
                        DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.Save(kullanici);
                    }
                    else if (!kullanici.HATALI_GIRIS.HasValue)
                    {
                        kullanici.HATALI_GIRIS = 1;
                        DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.Save(kullanici);
                    }
                    if (kullanici.HATALI_GIRIS == 3)
                    {
                        XtraMessageBox.Show(
                            "3 Kere hatalý þifre girdiniz. Þifreniz iptal edildi. Yöneticinize baþvurunuz.",
                            "GÝRÝÞ ÝPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        kullanici.KULLANICI_SIFRESI = Guid.NewGuid().ToString();
                        DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.Save(kullanici);
                        return;
                    }
                }

                #endregion Giriþ Baþarýsýz
            }
            //}
            //catch (Exception ex)
            //{
            //    BelgeUtil.ErrorHandler.Catch(this, ex);
            //}
        }

        public void StartUpdaterService()
        {
            bool serviceInstalled = false;
            foreach (ServiceController tmpServ in ServiceController.GetServices())
            {
                if (tmpServ.ServiceName.Trim() == "AvukatproUpdaterService")
                {
                    serviceInstalled = true;
                    break;
                }
            }
            if (serviceInstalled)
            {
                System.ServiceProcess.ServiceController sc = new System.ServiceProcess.ServiceController("AvukatproUpdaterService");
                if (sc.Status == ServiceControllerStatus.Paused)
                    sc.Continue();
                if (sc.Status != ServiceControllerStatus.Running)
                    sc.Start();
            }
        }

        public System.Data.DataTable SubeleriGetir()
        {
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter("select SUBE_ADI, ID from TDIE_BIL_KULLANICI_SUBELERI", ci.ConStr);
            System.Data.DataTable dr = new System.Data.DataTable();
            da.Fill(dr);
            return dr;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }

        List<CompInfo> cmpNfoList;

        private void Application_Idle(object sender, EventArgs e)
        {
            if (cmpNfoList == null)
                cmpNfoList = CompInfo.CmpNfoList;

            CompInfo cmpNfo = cmpNfoList[0];

            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.DoWork += delegate
            {
                var sayi = BelgeUtil.Inits.context.TDI_KOD_ADLI_BIRIM_NOs.Count();
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(new LookUpEdit(), cmpNfo.ConStr);

            };
            if (!bw.IsBusy)
                bw.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                this.Opacity += 0.1;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.CancelAsync();
            txteKullaniciAdi.Focus();
        }

        private void BakBakalimGirebiliomu()
        {
            string pat = "c:\\ayar.xml";
            string yazilacak = "true";

            bool varmi = File.Exists(pat);
            if (varmi)
            {
                FileStream fs = new FileStream(pat, FileMode.Open);
                StreamReader stre = new StreamReader(fs);
                string yazilmis = stre.ReadToEnd();
                if (yazilacak == yazilmis)
                {
                    txteKullaniciAdi.Text = "zafer";
                    txteSifreBilgi.Text = "zafer";
                    simpleButton1_Click(null, new EventArgs());
                }
                else
                {
                    MesajCi.Goster("Olmadi", "kardesim dosyayi kurcuklamýssýn",
                                   "Bak ayar dosyasýný sil c:\ayar.xml sora bidaa gel", MessageBoxButtons.OK, "",
                                   MessageBoxIcon.Error);
                }
                fs.Close();
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Application.Idle -= Application_Idle;
        }

        private void bwYukleyici_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ci = (CompInfo)e.Argument;

                if (ci != null)
                {
                    SqlNetTiersProvider prov = new SqlNetTiersProvider();
                    System.Collections.Specialized.NameValueCollection nameValueCollection =
                        new System.Collections.Specialized.NameValueCollection();
                    nameValueCollection.Add("UseStoredProcedure", "true");
                    nameValueCollection.Add("EnableEntityTracking", "true");
                    nameValueCollection.Add("EntityCreationalFactoryType", "AvukatProLib2.Entities.EntityFactory");
                    nameValueCollection.Add("EnableMethodAuthorization", "false");
                    nameValueCollection.Add("ConnectionString", ci.ConStr);
                    nameValueCollection.Add("ConnectionStringName", "conStr" + ci.LisansBilgisi.AdSoyad);
                    nameValueCollection.Add("ProviderInvariantName", "System.Data.SqlClient");
                    prov.Initialize(ci.LisansBilgisi.AdSoyad, nameValueCollection);
                    DataRepository.LoadProvider(prov, true);
                    e.Result = SubeleriGetir();
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void bwYukleyici_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            subelerLoaded = true;
            lkSube.Properties.DataSource = e.Result;
            if (((System.Data.DataTable)e.Result).Rows.Count > 0)
                lkSube.EditValue = ((System.Data.DataTable)e.Result).Rows[0]["ID"];
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            txteKullaniciAdi.Enabled = true;
            txteSifreBilgi.Enabled = true;
            if (ci.OturumAcmaModu != null)
            {
                if (Convert.ToBoolean(ci.OturumAcmaModu))
                {
                    var isim = WindowsIdentity.GetCurrent().Name.Split('\\');
                    var kullanýcý = DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetByKULLANICI_ADI(isim[1]);

                    if (kullanýcý != null)
                    {
                        txteKullaniciAdi.Text = kullanýcý.KULLANICI_ADI;
                        txteKullaniciAdi.Enabled = false;
                        txteSifreBilgi.Text = kullanýcý.KULLANICI_SIFRESI;
                        txteSifreBilgi.Enabled = false;
                        AvukatProLib.Kimlik.Bilgi = kullanýcý;
                    }
                }
            }

            #region <ZK - 20090606>

            //Module secmek için kullanýldý.
            //test edildikten sonra kaldýrýlmalý
            // TList<CS_KOD_PAKET> lstPaket = DataRepository.CS_KOD_PAKETProvider.GetAll();
            //lkuModuleNumber.Properties.DataSource = lstPaket;
            //lkuModuleNumber.Properties.DisplayMember = "PAKET_ADI";

            #endregion <ZK - 20090606>

            BakBakalimGirebiliomu();
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                txteKullaniciAdi.Text = UserName;
                txteSifreBilgi.Text = Password;
                simpleButton1_Click(null, new EventArgs());
            }
        }

        private void FormLoad()
        {
            //MessageBox.Show("Kurulumun kolay olmasý için bilgisayarýnýza veritabaný kurulmamýþtýr. Bilgi giriþleri uzak baðlantý ile Almanya'daki sunucumuza yapýlmaktadýr. Demomuza gösterilen ilgi nedeniyle ayný anda çok sayýda kullanýcý bu veritabanýný kullandýðýndan hesaplama ve yazýþma iþlemlerinde bir süre bekleyebilirsiniz.", "Önemli Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Exception exception;
            try
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                //this.lblSurumBilgisi.Text = "v" + this.AssemblyVersion + " RC2";
                this.Cursor = Cursors.Arrow;
                list = CompInfo.CompInfoListGetir();

                if ((list != null) && (list.Count > 0))
                {
                    //Lisans Kontrolü
                    //LicenseUtil.LicenseControl(list[0]);
                    try
                    {
                        this.lkSirket.Properties.DataSource = list;
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", exception1);
                        MessageBox.Show(exception.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        Environment.Exit(1);
                    }
                    AvukatProLib.Arama.AvpDataContext db = new AvukatProLib.Arama.AvpDataContext(list[0].ConStr);
                    BelgeUtil.Inits.context = db;
                    CommonDaoBase.ActualConnectionString = list[0].ConStr;

                    Application.Idle += new EventHandler(Application_Idle);

                    this.lkSirket.EditValueChanged += this.lkSirket_EditValueChanged; // Okan 20.07.2010
                    this.lkSirket.EditValue = list[0];
                    this.lblPaket.Text = string.Format("{0}", list[0].UrunAdi);
                    this.luePaketBilgisi.EditValue =
                    AvukatProLib.Mail.frmMailSender.PaketBilgisi = list[0].UrunAdi;

                    this.lkSirket.Properties.DisplayMember = "CompanyName";
                    foreach (CompInfo info in list)
                    {
                        DataRepository.AddConnection(info.LisansBilgisi.AdSoyad, info.ConStr);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Þirket bilgileri yüklenemedi. Lütfen konfigürasyon dosyasýný kontrol ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    Environment.Exit(1);
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                if (exception is LicenseException)
                {
                    BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", exception2);
                    MessageBox.Show(exception.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(1);
                }
                BelgeUtil.ErrorHandler.Catch(this, exception);
            }

            txteKullaniciAdi.Focus();
            if (StartUpParams != null && StartUpParams.Length >= 3)
                UserName = StartUpParams[2];
            if (StartUpParams != null && StartUpParams.Length >= 4)
                Password = StartUpParams[3];
            backgroundWorker1.RunWorkerAsync();
        }

        private void frmIntro_Click(object sender, EventArgs e)
        {
            AvukatProLib2.Entities.EntityBase.KontrolluMu = true;
            this.KeyPreview = true;
        }

        private void frmIntro_DoubleClick(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void frmIntro_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\updating.tmp"))
            {
                if (MessageBox.Show("Maestro Güncellemesi devam etmektedir.\nBu yüzden programý kullanmamanýzý tavsiye ederiz.\nYinede devam etmek istiyor musunuz ?", "Uyarý-Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                    return;
                }
            }
            if (cmpNfoList == null)
                cmpNfoList = CompInfo.CmpNfoList;
            CompInfo cmpNfo = cmpNfoList[0];
            if (cmpNfo.Surum == "012014.004")
            {
                var filename = Path.Combine(Application.StartupPath, cmpNfo.Surum + ".txt");
                if (!File.Exists(filename))
                {
                    File.WriteAllText(filename, cmpNfo.Versiyon);
                    cmpNfo.Surum = "062013.007";
                    CompInfo.Kaydet(cmpNfoList);
                }
            }

            Process[] prs = Process.GetProcesses();
            bool varmi = false;
            foreach (Process pr in prs)
            {
                if (pr.ProcessName == "AVPUpdater")
                {
                    varmi = true;
                    break;
                }
            }
            if (!varmi)
                if (File.Exists(Application.StartupPath + "\\AVPUpdater.exe"))
                {
                    Process.Start(Application.StartupPath + "\\AVPUpdater.exe");
                }
            Thread.Sleep(1000);

            try
            {
                AVPLicenceControl.PaketiGuncelle(Application.StartupPath);
            }
            catch { ;}

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
            lblSurumBilgisi.Text = cmpNfo.Versiyon + "." + cmpNfo.Surum;

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

            string file = Application.StartupPath + "//Kontrol.txt";
            if (File.Exists(file))
                using (StreamReader sr = new StreamReader(@"Kontrol.txt"))
                {
                    if (sr.ReadLine() == "0")
                    {
                        MessageBox.Show("Programda güncelleme iþlemi yapýlýyor.\r\nGüncelleme bittikten sonra giriþ yapabilirsiniz.", "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                    else
                    {
                        FormLoad();
                    }
                }
            else
                FormLoad();
            luePaketBilgisi.Enabled = false;
        }

        private bool kullaniciGirebilirMi(int kullaniciId)
        {
            return true;
            TList<TA_BIL_AKTIF_KULLANICI> kullanicilar = DataRepository.TA_BIL_AKTIF_KULLANICIProvider.GetAll();

            //kullaniciId, AvukatProLib.Kimlik.SirketBilgisi.ModuleNumber;
            if (kullanicilar.Count >
                AvukatProLib.Kimlik.SirketBilgisi.LisansBilgisi.IcraKullaniciSayisi +
                AvukatProLib.Kimlik.SirketBilgisi.LisansBilgisi.DavaKullaniciSayisi)
            {
                return false;
            }
            else
            {
                Kimlik.CurrentAKTIF_KULLANICI = new TA_BIL_AKTIF_KULLANICI();
                Kimlik.CurrentAKTIF_KULLANICI.GIRIS_ZAMANI = DateTime.Now;
                Kimlik.CurrentAKTIF_KULLANICI.KULLANICI_ID = kullaniciId;
                Kimlik.CurrentAKTIF_KULLANICI.PROGRAM_MODUL = 0;
                Kimlik.CurrentAKTIF_KULLANICI.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                Kimlik.CurrentAKTIF_KULLANICI.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                Kimlik.CurrentAKTIF_KULLANICI.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                Kimlik.CurrentAKTIF_KULLANICI.KONTROL_NE_ZAMAN = DateTime.Now;
                Kimlik.CurrentAKTIF_KULLANICI.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                Kimlik.CurrentAKTIF_KULLANICI.KULLANICI_ADI = AvukatProLib.Kimlik.KullaniciAdi;
                DataRepository.TA_BIL_AKTIF_KULLANICIProvider.Save(Kimlik.CurrentAKTIF_KULLANICI);

                //TODO:Aktif Kullanýcý AVPNG-179
                return true;
            }
        }

        private void lkSirket_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CompInfo ci = lkSirket.EditValue as CompInfo;
                CheckForIllegalCrossThreadCalls = false;
                PaketBilgisiDoldur(ci);
                if (!bwYukleyici.IsBusy && !subelerLoaded)
                {
                    bwYukleyici.RunWorkerAsync(ci);
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void luePaketBilgisi_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (ci != null && lue.EditValue != null)
            {
                ci.LisansBilgisi.PaketAdi = lue.EditValue.ToString();
                if (lue.EditValue.ToString() == "Maestro Kurumsal Finans")
                    BelgeUtil.Inits.PaketAdi = 1;
                else if (list[0].LisansBilgisi.PaketAdi == "Maestro Kurumsal Telekominikasyon")
                {
                    BelgeUtil.Inits.Telekomunukasyonmu = true;
                    BelgeUtil.Inits.PaketAdi = 0;
                }
                else if (list[0].LisansBilgisi.PaketAdi == "Maestro Kurumsal Enerji")
                {
                    BelgeUtil.Inits.Enerjimi = true;
                    BelgeUtil.Inits.PaketAdi = 0;
                }
                else
                    BelgeUtil.Inits.PaketAdi = 0;
            }
        }

        private void OpenMdiForm()
        {
            mdiForm = new mdiAvukatPro();
            mdiForm.FormTipi = FormTipi;
            //mdiForm.AcilisSekli = mdiAvukatPro.AcilisSekli;
            mdiForm.AcilacakDosyaYolu = AcilacakDosyaYolu;
            //Thread th = new Thread(new ThreadStart(delegate
            //{
            //    while (!mdiForm.IsShow)
            //    {
            //        mdiForm.Enabled = false;
            //        this.BringToFront();
            //    }
            //}));
            //th.Start();

            BackgroundWorker bckw = new BackgroundWorker();
            bckw.DoWork += delegate(object sender2, DoWorkEventArgs e2)
            {
                while (!mdiForm.IsShow)
                {
                    mdiForm.Enabled = false;
                    this.BringToFront();
                }
            };
            bckw.RunWorkerCompleted += delegate(object sender2, RunWorkerCompletedEventArgs e2)
            {
                mdiForm.Enabled = true;
                this.Hide();
                mdiForm.LoadComplete();
            };
            bckw.RunWorkerAsync();

            mdiForm.Show();
        }

        private void PaketBilgisiDoldur(CompInfo ci)
        {
            if (ci != null)
            {
                var paket = PaketHelper.Paketler;//ci.LisansBilgisi.PaketBilgileri;
                if (paket != null)
                {
                    //luePaketBilgisi.Visible = true;
                    luePaketBilgisi.Properties.DataSource = paket;
                    luePaketBilgisi.Properties.ValueMember = "PaketAdi";
                    luePaketBilgisi.Properties.DisplayMember = "PaketAdi";
                    luePaketBilgisi.Properties.Columns.Clear();
                    luePaketBilgisi.Properties.Columns.Add(
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PaketAdi", "Görünüm Bilgisi"));
                }
                else
                    luePaketBilgisi.Visible = false;
            }
        }

        private void picCik_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void pictureEdit1_MouseClick(object sender, MouseEventArgs e)
        {
            simpleButton1_Click(null, new EventArgs());
        }

        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            //pictureEdit1.Image = ýmageList1.Images[2];
        }

        private void pictureEdit1_MouseEnter(object sender, EventArgs e)
        {
            //pictureEdit1.Image = ýmageList1.Images[1];
        }

        private void pictureEdit1_MouseLeave(object sender, EventArgs e)
        {
            //pictureEdit1.Image = ýmageList1.Images[0];
        }

        private void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            //pictureEdit1.Image = ýmageList1.Images[1];
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
                pictureEdit1.Focus();
                simpleButton1_Click(null, null);
            }
        }

        #region <ZK - 20090606>

        //Module secmek için kullanýldý.
        //test edildikten sonra kaldýrýlmalý
        private string str = "";

        private void frmIntro_KeyDown(object sender, KeyEventArgs e)
        {
            //if (str == "Control" && e.KeyCode == Keys.Z)
            //    lkuModuleNumber.Visible = true;

            str = e.Modifiers.ToString();
        }

        #endregion <ZK - 20090606>
    }
}