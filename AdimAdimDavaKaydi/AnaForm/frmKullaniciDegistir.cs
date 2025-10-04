using AdimAdimDavaKaydi.Forms;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.AnaForm
{
    public partial class frmKullaniciDegistir : Form
    {
        public frmKullaniciDegistir()
        {
            InitializeComponent();
        }

        private void btnDevam_Click(object sender, EventArgs e)
        {
            try
            {
                if (Kimlikci.Kimlik.SubeKodu != null)
                {
                    TDI_BIL_KULLANICI_LISTESI kullanici = null;
                    if (this.Tag != "LDAP")
                    {
                        kullanici = DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.
                            GetByKULLANICI_ADIKULLANICI_SIFRESIKULLANICI_SUBE_ID(txtKullaniciAdi.Text,
                                                                                 txteSifreBilgi.Text,
                                                                                 Kimlikci.Kimlik.SubeKodu);
                    }
                    else
                    {
                        kullanici =
                            DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetByKULLANICI_ADI(txtKullaniciAdi.Text);
                        if (kullanici != null && kullanici.KULLANICI_SUBE_ID != Kimlikci.Kimlik.SubeKodu)
                        {
                            kullanici = null;
                        }
                    }
                    if (kullanici != null && (kullanici.HATALI_GIRIS < 3 || !kullanici.HATALI_GIRIS.HasValue))
                    {
                        #region Giriş Başarılı

                        kullanici.HATALI_GIRIS = 0;
                        DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.Save(kullanici);

                        if (kullanici.KULLANICI_AKTIF)
                        {
                            AvukatProLib.Kimlik.Bilgi = kullanici;
                            //this.TopMost = false;
                            //if (lkSube.EditValue is int)
                            //{
                            kullanici.KULLANICI_SUBE_IDSource =
                                AvukatProLib2.Data.DataRepository.TDIE_BIL_KULLANICI_SUBELERIProvider.GetByID(
                                    Kimlikci.Kimlik.SubeKodu);
                            //}
                            //else
                            //{
                            //    kullanici.KULLANICI_SUBE_IDSource = (TDIE_BIL_KULLANICI_SUBELERI)lkSube.EditValue;
                            //}
                            AvukatProLib.Kimlik.SirketBilgisi = (CompInfo)Kimlikci.Kimlik.SirketBilgisi;

                            #region Özel Kod Özelleştirme

                            if (AvukatProLib.Kimlik.SirketBilgisi != null)
                            {
                                var davarefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetDavaOzelKodReferans(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                                var icrarefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetIcraOzelKodReferans(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                                var sorusturmarefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetSorusturmaOzelKodReferans(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                                var sozlezmerefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetSozlesmeOzelKodReferans(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                                var ortakrefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetOrtakOzelKodReferans(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.OrtakOzelDurum.Banka = ortakrefoz.OrtakOzelDurumBanka;
                                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.OrtakOzelDurum.FoyBirim = ortakrefoz.OrtakOzelDurumFoyBirim;
                                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.OrtakOzelDurum.FoyYeri = ortakrefoz.OrtakOzelDurumFoyYeri;
                                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.OrtakOzelDurum.Klasor1 = ortakrefoz.OrtakOzelDurumKlasor1;
                                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.OrtakOzelDurum.Klasor2 = ortakrefoz.OrtakOzelDurumKlasor2;
                                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.OrtakOzelDurum.KrediGrup = ortakrefoz.OrtakOzelDurumKrediGrup;
                                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.OrtakOzelDurum.KrediTip = ortakrefoz.OrtakOzelDurumKrediTip;
                                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.OrtakOzelDurum.Ozel = ortakrefoz.OrtakOzelDurumOzel;
                                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.OrtakOzelDurum.Sube = ortakrefoz.OrtakOzelDurumSube;
                                AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.OrtakOzelDurum.Tahsilat = ortakrefoz.OrtakOzelDurumTahsilat;


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

                                if (!Util.AuthHelper.PasswordControl(kullanici.KULLANICI_SIFRESI, false))
                                {
                                    MessageBox.Show("Parolanız Güvenlik prosedürüne uymamaktadır. Lütfen değiştiriniz.");
                                    if ((new frmParolaDegistirme()).ShowDialog() != DialogResult.OK)
                                        return;
                                }
                            }

                            #endregion Özel Kod Özelleştirme

                            #region tmpKOCZER Özel

                            if (AvukatProLib.Kimlik.SirketBilgisi != null &&
                                AvukatProLib.Kimlik.SirketBilgisi.LisansBilgisi.AdSoyad.Contains("KOCZER"))
                            {
                                Kimlikci.Kimlik.IcraOzelKod.OzelKod1 = "Müşteri";
                                Kimlikci.Kimlik.IcraOzelKod.OzelKod2 = "Tedarikçi";
                                Kimlikci.Kimlik.IcraOzelKod.OzelKod3 = "Hizmet";
                                Kimlikci.Kimlik.IcraOzelKod.OzelKod4 = "Lokasyon";
                                Kimlikci.Kimlik.DavaOzelKod = Kimlikci.Kimlik.IcraOzelKod;
                                Kimlikci.Kimlik.SorusturmaOzelKod = Kimlikci.Kimlik.IcraOzelKod;
                                Kimlikci.Kimlik.SozlesmeOzelKod = Kimlikci.Kimlik.IcraOzelKod;
                            }

                            #endregion tmpKOCZER Özel

                            //pictureEdit1.Image = ımageList1.Images[3];
                            if (kullaniciGirebilirMi(kullanici.ID))
                            {
                                #region KONTROL_KIM_ID / SUBE_KOD_ID

                                EntityBase.BagliKullaniciId = kullanici.ID;
                                EntityBase.BagliSubeId = kullanici.KULLANICI_SUBE_ID;

                                #endregion KONTROL_KIM_ID / SUBE_KOD_ID

                                this.DialogResult = DialogResult.OK;

                                //#region frmAnaGirisEkranForm'dan alınanlar

                                //if (StartUpParams != null)
                                //{
                                //    if (StartUpParams.Length >= 4)
                                //    {
                                //        UserName = StartUpParams[2];
                                //        Password = StartUpParams[3];
                                //    }
                                //}
                                //FormTipi = AvukatProLib.Extras.FormType.KurumsalGirisEkran;
                                //OpenMdiForm();

                                //#endregion frmAnaGirisEkranForm'dan alınanlar
                            }
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı hesabı aktif değil");
                            return;
                        }

                        #endregion Giriş Başarılı
                    }

                    #region Giriş Başarısız

                    MessageBox.Show("Kullanıcı adı ,parola veya Şube yanlış.", "Hata", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    kullanici =
                        DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetByKULLANICI_ADI(txtKullaniciAdi.Text);
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
                                "3 Kere hatalı şifre girdiniz. Şifreniz iptal edildi. Yöneticinize başvurunuz.",
                                "GİRİŞ İPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            kullanici.KULLANICI_SIFRESI = Guid.NewGuid().ToString();
                            DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.Save(kullanici);
                            return;
                        }
                    }

                    #endregion Giriş Başarısız
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKullaniciDegistir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnVazgec_Click(sender, e);
            else if (e.KeyCode == Keys.Enter)
                btnDevam_Click(sender, e);
        }

        private void frmKullaniciDegistir_Load(object sender, EventArgs e)
        {
            txtKullaniciAdi.Focus();
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

                //TODO:Aktif Kullanıcı AVPNG-179
                return true;
            }
        }
    }
}