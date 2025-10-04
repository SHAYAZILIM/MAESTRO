#define LisansKontrollu

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Util.KullaniciAyar
{
    public partial class frmGenel : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmGenel()
        {
            InitializeComponent();
            genelAyarList = DataRepository.TDIE_BIL_KULLANICI_GENEL_AYARProvider.GetByKULLANICI_ID(Kimlik.Bilgi.ID);
            if (genelAyarList == null || genelAyarList.Count == 0)
                genelAyar = new TDIE_BIL_KULLANICI_GENEL_AYAR();
            else
                genelAyar = genelAyarList[0];

            spnEAramaEkranSayi.EditValue = genelAyar.ACILACAK_EKRAN_SAYISI;
            meGorevAciklama.EditValue = genelAyar.GOREV_ACIKLAMA;
            txeGorevAd.EditValue = genelAyar.GOREV_ADI;
            cbKategori.EditValue = genelAyar.GOREV_KATEGORI;
            txeKullaniciAd.EditValue = genelAyar.KULLANICI_ADI;
            txeRaporYolu.EditValue = genelAyar.RAPOR_KLASOR_YOLU;
            txeKullaniciSifre.EditValue = genelAyar.SIFRE;
            lkFirmaSecim.EditValue = genelAyar.SIRKET_ADI;
            txeUyapYolu.EditValue = genelAyar.UYAP_KLASOR_YOLU;
            txeYedekYolu.EditValue = genelAyar.YEDEK_KLASOR_YOLU;
            txtMailHost.EditValue = genelAyar.HOST;
            speMailHostPort.EditValue = genelAyar.PORT;
            txtMailKullaniciAdi.EditValue = genelAyar.MAIL_KULLANICI_ADI;
            txtMailSifre.EditValue = genelAyar.MAIL_KULLANICI_SIFRE;
            chkPop.EditValue = genelAyar.POP;
            chkVarsayilan.EditValue = genelAyar.VARSAYILAN_GUVENLIK;
            chkMailSSLKullan.EditValue = genelAyar.SSL_KULLAN;
            rgAcilisSayfasi.EditValue = genelAyar.PROGRAM_ACILIS_EKRAN.HasValue
                                            ? ((AvukatProLib.Extras.FormType)genelAyar.PROGRAM_ACILIS_EKRAN.Value).ToString()
                                            : AvukatProLib.Extras.FormType.KurumsalGirisEkran.ToString();
            subelerDoldur();
        }

        [Serializable]
        public class GenelAyarlar
        {
            private string sirketAd;

            public string SirketAd
            {
                get { return sirketAd; }
                set { sirketAd = value; }
            }

            private string kullaniciAdi;

            public string KullaniciAdi
            {
                get { return kullaniciAdi; }
                set { kullaniciAdi = value; }
            }

            private string sifre;

            public string Sifre
            {
                get { return sifre; }
                set { sifre = value; }
            }

            private int acilacakEkranSayi;

            public int AcilacakEkranSayi
            {
                get { return acilacakEkranSayi; }
                set { acilacakEkranSayi = value; }
            }

            private int? programDilSecenek;

            public int? ProgramDilSecenek
            {
                get { return programDilSecenek; }
                set { programDilSecenek = value; }
            }

            private int? raporDilSecenek;

            public int? RaporDilSecenek
            {
                get { return raporDilSecenek; }
                set { raporDilSecenek = value; }
            }

            private int? sozcukDenetimDili;

            public int? SozcukDenetimDili
            {
                get { return sozcukDenetimDili; }
                set { sozcukDenetimDili = value; }
            }

            private string programAcilisEkran;

            public string ProgramAcilisEkran
            {
                get { return programAcilisEkran; }
                set { programAcilisEkran = value; }
            }

            private string raporKlasorYolu;

            public string RaporKlasorYolu
            {
                get { return raporKlasorYolu; }
                set { raporKlasorYolu = value; }
            }

            private string uyapKlasorYolu;

            public string UyapKlasorYolu
            {
                get { return uyapKlasorYolu; }
                set { uyapKlasorYolu = value; }
            }

            private string yedekKlasorYolu;

            public string YedekKlasorYolu
            {
                get { return yedekKlasorYolu; }
                set { yedekKlasorYolu = value; }
            }

            private string gorevAdi;

            public string GorevAdi
            {
                get { return gorevAdi; }
                set { gorevAdi = value; }
            }

            private string gorevKategori;

            public string GorevKategori
            {
                get { return gorevKategori; }
                set { gorevKategori = value; }
            }

            private string gorevAciklama;

            public string GorevAciklama
            {
                get { return gorevAciklama; }
                set { gorevAciklama = value; }
            }
        }

        private List<GenelAyarlar> myGenelAyarlar;

        [Browsable(false)]
        public List<GenelAyarlar> MyGenelAyarlar
        {
            get { return myGenelAyarlar; }
            set
            {
                if (value != null)
                    myGenelAyarlar = value;
            }
        }

        //TDIE_BIL_KULLANICI_GENEL_AYAR
        private List<TDIE_BIL_KULLANICI_GENEL_AYAR> myAyarlar;

        [Browsable(false)]
        public List<TDIE_BIL_KULLANICI_GENEL_AYAR> MyAyarlar
        {
            get { return myAyarlar; }
            set
            {
                if (value != null)
                    myAyarlar = value;
            }
        }

        public void subelerDoldur()
        {
            try
            {
                this.Cursor = Cursors.Arrow;
                List<CompInfo> sList = CompInfo.CompInfoListGetir();
                lkFirmaSecim.Properties.DataSource = sList;
                if (sList != null && sList.Count > 0)
                {
#if LisansKontrollu
                    if (sList[0] != null && !String.IsNullOrEmpty(sList[0].MachineCode) &&
                        !String.IsNullOrEmpty(sList[0].LisansBilgisi.ProductKey))
                    {
                        if (
                            !AvukatProLib.Lisans.LicenseHelper.CompareMachineCode(sList[0].LisansBilgisi.ProductKey,
                                                                                  sList[0].MachineCode))
                        {
                            throw new LicenseException(typeof(frmIntro), this,
                                                       "Lisans dosyasýnda sorun bulundu lütfen Avukatpro Destek ekibiyle iletiþime geçiniz");
                        }
                        else if (sList[0].LisansBilgisi == null)
                        {
                            throw new LicenseException(typeof(frmIntro), this,
                                                       "Lisans dosyasýnda sorun bulundu lütfen Avukatpro Destek ekibiyle iletiþime geçiniz");
                        }
                        else if (sList[0].LisansBilgisi != null && sList[0].LisansBilgisi.LisansBitisTarihi != null &&
                                 sList[0].LisansBilgisi.LisansBitisTarihi < DateTime.Now)
                        {
                            throw new LicenseException(typeof(frmIntro), this,
                                                       "Lisans dosyasýnda sorun bulundu lütfen Avukatpro Destek ekibiyle iletiþime geçiniz");
                        }
                    }
#endif
                    lkFirmaSecim.EditValue = sList[0];
                }
                lkFirmaSecim.Properties.DisplayMember = "CompanyName";
                lkFirmaSecim.Properties.ValueMember = "ConStr";
                foreach (CompInfo info in sList)
                {
                    DataRepository.AddConnection(info.LisansBilgisi.AdSoyad, info.ConStr);
                }

                BelgeUtil.Inits.DilKodGetir(lkProgramDil);
                BelgeUtil.Inits.DilKodGetir(lkRapordil);
                BelgeUtil.Inits.DilKodGetir(lkSozcukDenetim);
            }
            catch (Exception ex)
            {
                if (ex is LicenseException)
                {
                    BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
                    XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void checkSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSifreGoster.Checked)
                txeKullaniciSifre.Properties.PasswordChar = '\0';
            else
                txeKullaniciSifre.Properties.PasswordChar = '*';
        }

        private TList<TDIE_BIL_KULLANICI_GENEL_AYAR> GenelAyarKaydilcek = new TList<TDIE_BIL_KULLANICI_GENEL_AYAR>();
        private TList<TDIE_BIL_KULLANICI_GENEL_AYAR> genelAyarList;
        private TDIE_BIL_KULLANICI_GENEL_AYAR genelAyar;

        private void sBtnYaz_Click(object sender, EventArgs e)
        {
            //YAZ
            //XML e yazdýrýcam clkasýmý
            MyAyarlar = new List<TDIE_BIL_KULLANICI_GENEL_AYAR>();
            genelAyar.ACILACAK_EKRAN_SAYISI = Convert.ToInt32(spnEAramaEkranSayi.EditValue);
            genelAyar.GOREV_ACIKLAMA = Convert.ToString(meGorevAciklama.EditValue);
            genelAyar.GOREV_ADI = Convert.ToString(txeGorevAd.EditValue);
            genelAyar.GOREV_KATEGORI = Convert.ToString(cbKategori.EditValue);
            genelAyar.KULLANICI_ADI = Convert.ToString(txeKullaniciAd.EditValue);
            genelAyar.PROGRAM_DIL_SECENEK_ID = 1; //Convert.ToInt32(lkProgramDil.EditValue);
            genelAyar.RAPOR_DIL_SECENEK_ID = 1; //Convert.ToInt32(lkRapordil.EditValue);
            genelAyar.RAPOR_KLASOR_YOLU = Convert.ToString(txeRaporYolu.EditValue);
            genelAyar.SIFRE = Convert.ToString(txeKullaniciSifre.EditValue);
            genelAyar.SIRKET_ADI = Convert.ToString(lkFirmaSecim.EditValue);
            genelAyar.SOZCUK_DENETIM_DILI_ID = 1; //Convert.ToInt32(lkSozcukDenetim.EditValue);
            genelAyar.UYAP_KLASOR_YOLU = Convert.ToString(txeUyapYolu.EditValue);
            genelAyar.YEDEK_KLASOR_YOLU = Convert.ToString(txeYedekYolu.EditValue);
            genelAyar.PROGRAM_ACILIS_EKRAN = (int)Enum.Parse(typeof(AvukatProLib.Extras.FormType), rgAcilisSayfasi.EditValue.ToString());
            genelAyar.HOST = Convert.ToString(txtMailHost.EditValue);
            genelAyar.PORT = Convert.ToInt32(speMailHostPort.EditValue);
            genelAyar.MAIL_KULLANICI_ADI = Convert.ToString(txtMailKullaniciAdi.EditValue);
            genelAyar.MAIL_KULLANICI_SIFRE = Convert.ToString(txtMailSifre.EditValue);
            genelAyar.POP = Convert.ToBoolean(chkPop.EditValue);
            genelAyar.VARSAYILAN_GUVENLIK = Convert.ToBoolean(chkVarsayilan.EditValue);
            genelAyar.SSL_KULLAN = Convert.ToBoolean(chkMailSSLKullan.EditValue);
            genelAyar.KULLANICI_ID = Kimlikci.Kimlik.Bilgi.ID;
            GenelAyarKaydilcek.Add(genelAyar);

            try
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                        "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                    try
                    {
                        tran.BeginTransaction();
                        DataRepository.TDIE_BIL_KULLANICI_GENEL_AYARProvider.Save(tran, genelAyar);
                        tran.Commit();
                        XtraMessageBox.Show("Kayýt Ýþlemi Tamamlanmýþtýr...");
                    }
                    catch (Exception ex)
                    {
                        if (tran.IsOpen)
                            tran.Rollback();
                        BelgeUtil.ErrorHandler.Catch(this, ex, false, BelgeUtil.Bilesen.Kayit);
                        XtraMessageBox.Show("Kayýt Sýrasýnda Bir Hata Oluþtu...Lütfen Yeniden Deneyin...");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Kayýt Ýþlemini Onaylamadýðýnýz için Ýþlem Tamamlanamadý ... ");
                }
            }
            catch
            {
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //FÝLE
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string RaporYol = fd.SelectedPath;
                txeRaporYolu.Text = RaporYol;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string UyapYol = fd.SelectedPath;
                txeUyapYolu.Text = UyapYol;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string YedekYol = fd.SelectedPath;
                txeYedekYolu.Text = YedekYol;
            }
        }
    }
}