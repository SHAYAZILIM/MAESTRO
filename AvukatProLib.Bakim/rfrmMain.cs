using AvukatProLib.Bakim.Firma;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AvukatProLib.Bakim
{
    public partial class rfrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public rfrmMain()
        {
            Stringler.Culture = global::AvukatProLib.Bakim.Properties.Resources.Culture;
            InitializeComponent();
        }

        #region Tanýmlamalar

        private frmAsistanAyarlari AsistanAyarlari = new frmAsistanAyarlari();
        private frmDNSAyarlari DNSAyarlari = new frmDNSAyarlari();
        private frmFirmaTanimlari FirmaTanimlari = new frmFirmaTanimlari();
        private frmGrupTanimlama GrupTanim = new frmGrupTanimlama();
        private frmInternetKontrolAdresi InternetKontrolAdresi = new frmInternetKontrolAdresi();
        private frmIslemYetkileri IslemYetkileri = new frmIslemYetkileri();
        private frmKanunRaporSablonYukle KanunRaporSablonYukle = new frmKanunRaporSablonYukle();
        private frmKayitliKullaniciBilgileri KayitliKullaniciBilgileri = new frmKayitliKullaniciBilgileri();
        private frmKopyaKorumaCihazi KopyaKorumaCihazi = new frmKopyaKorumaCihazi();
        private frmKullaniciGruplari KullaniciGruplari = new frmKullaniciGruplari();
        private frmKullaniciTanimlari KullaniciTanimlari = new frmKullaniciTanimlari();
        private frmLisansSonucu LisansSonucu = new frmLisansSonucu();
        private frmOtomatikGiderAyari OtomatikGecisAyari = new frmOtomatikGiderAyari();
        private frmSMSAyarlari SMSAyar = new frmSMSAyarlari();
        private frmSunucuKurulumTopluAyarlar SunucuKurulumuTopluAyar = new frmSunucuKurulumTopluAyarlar();
        private frmTarihceAyarlari TarihceAyar = new frmTarihceAyarlari();
        private frmVeriTabaniKontrol VeriTabaniHataKontrol = new frmVeriTabaniKontrol();
        private frmVeriTabaniKullanicilari VeriTabaniKullanicilari = new frmVeriTabaniKullanicilari();
        private frmVeriTabaniOlustur VeriTabaniOlustur = new frmVeriTabaniOlustur();
        private frmVeriTabaniSunucuIslemleri VeriTabaniSunucuÝslemleri = new frmVeriTabaniSunucuIslemleri();
        private frmOzelKod OzelKodIslemleri = new frmOzelKod();
        private frmVeriTabaniTamiri VeriTabaniTamiri = new frmVeriTabaniTamiri();
        private frmVeriTabaniYazilimi VeriTabaniYazilimi = new frmVeriTabaniYazilimi();
        private frmYedegiSistemeGeriDon YedegiSistemeGeriDon = new frmYedegiSistemeGeriDon();
        private frmYedekAl YedekAl = new frmYedekAl();

        private void TabGecisKontrolu(Form frm, string deger)
        {
            if (frm.Text == deger)
            {
                frm.BringToFront();
            }
            else
            {
                frm.MdiParent = this;
                frm.Text = deger;
                frm.Show();
            }
        }

        #endregion Tanýmlamalar

        #region Veri Tabaný Kod

        private void btnHataKontrol_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(VeriTabaniHataKontrol, Stringler.VeriTabaniHataKontrol);
            VeriTabaniHataKontrol.FormClosed += new FormClosedEventHandler(hata_FormClosed);
        }

        private void btnKullanýcýlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(VeriTabaniKullanicilari, Stringler.VeriTabaniKullanicilari);
            VeriTabaniKullanicilari.FormClosed += new FormClosedEventHandler(kullanici_FormClosed);
        }

        private void btnSunucuÝþlemleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(VeriTabaniSunucuÝslemleri, "VeriTabaniSunucuÝslemleri");
            VeriTabaniSunucuÝslemleri.FormClosed += new FormClosedEventHandler(sunucu_FormClosed);
            btnKaydet.ItemClick += VeriTabaniSunucuÝslemleri.btnKaydet_ItemClick;
        }

        private void btnVeriTabaniOlustur_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(VeriTabaniOlustur, Stringler.VeriTabaniOlustur);
            VeriTabaniOlustur.FormClosed += new FormClosedEventHandler(VTOlustur_FormClosed);
        }

        private void btnVeriTabaniTamiri_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(VeriTabaniTamiri, Stringler.Tamir);
            VeriTabaniTamiri.FormClosed += new FormClosedEventHandler(tmr_FormClosed);
        }

        private void btnVeriTabaniYazilimi_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(VeriTabaniYazilimi, Stringler.VeriTabaniYazilim);
            VeriTabaniYazilimi.FormClosed += new FormClosedEventHandler(vri_FormClosed);
        }

        private void hata_FormClosed(object sender, FormClosedEventArgs e)
        {
            VeriTabaniHataKontrol.Name = Stringler.Bos;
            VeriTabaniHataKontrol = new frmVeriTabaniKontrol();
        }

        private void kullanici_FormClosed(object sender, FormClosedEventArgs e)
        {
            VeriTabaniKullanicilari.Name = Stringler.Bos;
            VeriTabaniKullanicilari = new frmVeriTabaniKullanicilari();
        }

        private void rfrmMain_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                frmIntro frm = new frmIntro();
                this.Visible = false;
                DialogResult dr = frm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    this.Visible = true;
                }
                else if (dr == DialogResult.Yes)
                {
                    //this.btnKullaniciGruplari.Visibility = BarItemVisibility.Never;
                    //this.btnKullaniciTanýmlari.Visibility = BarItemVisibility.Never;
                    //this.btnGrupYetkileri.Visibility = BarItemVisibility.Never;
                    //this.btnYedegiSistemiDon.Visibility = BarItemVisibility.Never;
                    //this.btnYedekAl.Visibility = BarItemVisibility.Never;
                    grbKullaniciTanimlari.Visible = false;
                    grbGrupYetkileri.Visible = false;
                    this.Visible = true;
                    XtraMessageBox.Show("Þirket ayarlarýnýz olmadýðý için þuanda sadece þirket ayarlarýný yapabilirsiniz", "Avukatpro Bakým", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabGecisKontrolu(VeriTabaniSunucuÝslemleri, Stringler.VeriTabaniSunucuÝslemleri);
                    VeriTabaniSunucuÝslemleri.FormClosed += new FormClosedEventHandler(sunucu_FormClosed);
                    btnKaydet.ItemClick += VeriTabaniSunucuÝslemleri.btnKaydet_ItemClick;
                }
                else
                {
                    this.Close();
                }
            }

            btnSistemTanimlari.Visibility = BarItemVisibility.Always;
            barBtnSurum.Visibility = BarItemVisibility.Always;
        }

        private void sunucu_FormClosed(object sender, FormClosedEventArgs e)
        {
            VeriTabaniSunucuÝslemleri.Name = Stringler.Bos;
            VeriTabaniSunucuÝslemleri = new frmVeriTabaniSunucuIslemleri();
        }

        private void tmr_FormClosed(object sender, FormClosedEventArgs e)
        {
            VeriTabaniTamiri.Name = Stringler.Bos;
            VeriTabaniTamiri = new frmVeriTabaniTamiri();
        }

        private void vri_FormClosed(object sender, FormClosedEventArgs e)
        {
            VeriTabaniYazilimi.Name = Stringler.Bos;
            VeriTabaniYazilimi = new frmVeriTabaniYazilimi();
        }

        private void VTOlustur_FormClosed(object sender, FormClosedEventArgs e)
        {
            VeriTabaniOlustur.Name = Stringler.Bos;
            VeriTabaniOlustur = new frmVeriTabaniOlustur();
        }

        #endregion Veri Tabaný Kod

        #region Lisans Sonuçlari Kod

        private void btnKayitliKullaniciBilgileri_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(KayitliKullaniciBilgileri, Stringler.KayýtliKullaniciBilgileri);
            KayitliKullaniciBilgileri.FormClosed += new FormClosedEventHandler(KKBilgileri_FormClosed);
        }

        private void btnKopyaKorumaCihazi_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(KopyaKorumaCihazi, Stringler.KopyaKorumaCihazi);
            KopyaKorumaCihazi.FormClosed += new FormClosedEventHandler(KKCihazi_FormClosed);
        }

        private void btnLisansSonucu_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(LisansSonucu, Stringler.LisansSonucu);
            LisansSonucu.FormClosed += new FormClosedEventHandler(LSonuc_FormClosed);
        }

        private void KKBilgileri_FormClosed(object sender, FormClosedEventArgs e)
        {
            KayitliKullaniciBilgileri.Name = Stringler.Bos;
            KayitliKullaniciBilgileri = new frmKayitliKullaniciBilgileri();
        }

        private void KKCihazi_FormClosed(object sender, FormClosedEventArgs e)
        {
            KopyaKorumaCihazi.Name = Stringler.Bos;
            KopyaKorumaCihazi = new frmKopyaKorumaCihazi();
        }

        private void LSonuc_FormClosed(object sender, FormClosedEventArgs e)
        {
            LisansSonucu.Name = Stringler.Bos;
            LisansSonucu = new frmLisansSonucu();
        }

        #endregion Lisans Sonuçlari Kod

        #region Diðer Ayar Kod

        private void AAyarlari_FormClosed(object sender, FormClosedEventArgs e)
        {
            AsistanAyarlari.Name = Stringler.Bos;
            AsistanAyarlari = new frmAsistanAyarlari();
        }

        private void bntInternetKontrolAdresi_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(InternetKontrolAdresi, Stringler.InternetKontrolAdresi);
            InternetKontrolAdresi.FormClosed += new FormClosedEventHandler(IKAdresi_FormClosed);
        }

        private void btnAsistanAyarlari_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(AsistanAyarlari, Stringler.AsistanAyarlari);
            AsistanAyarlari.FormClosed += new FormClosedEventHandler(AAyarlari_FormClosed);
        }

        private void btnDNSAyari_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(DNSAyarlari, Stringler.DNSAyarlari);
            DNSAyarlari.FormClosed += new FormClosedEventHandler(DNSAyarlari_FormClosed);
        }

        private void btnKanunRaporSablonYukle_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(KanunRaporSablonYukle, Stringler.KanunRaporSablonYukle);
            KanunRaporSablonYukle.FormClosed += new FormClosedEventHandler(KRSYukle_FormClosed);
        }

        private void btnOtomatikGiderAyari_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(OtomatikGecisAyari, Stringler.OtomatikGiderAyari);
            OtomatikGecisAyari.FormClosed += new FormClosedEventHandler(OGAyari_FormClosed);
        }

        private void btnSMSAyari_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(SMSAyar, Stringler.SMSAyarlari);
            SMSAyar.FormClosed += new FormClosedEventHandler(SMSAyar_FormClosed);
        }

        private void btnSunucuKururlumTopluAyarlari_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(SunucuKurulumuTopluAyar, Stringler.SunucuKurulumTopluAyarlari);

            SunucuKurulumuTopluAyar.FormClosed += new FormClosedEventHandler(SKTopluAyar_FormClosed);
        }

        private void btnTarihceAyarlari_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(TarihceAyar, Stringler.TarihceAyarlari);
            TarihceAyar.FormClosed += new FormClosedEventHandler(TrhAyar_FormClosed);
        }

        private void DNSAyarlari_FormClosed(object sender, FormClosedEventArgs e)
        {
            DNSAyarlari.Name = Stringler.Bos;
            DNSAyarlari = new frmDNSAyarlari();
        }

        private void IKAdresi_FormClosed(object sender, FormClosedEventArgs e)
        {
            InternetKontrolAdresi.Name = Stringler.Bos;
            InternetKontrolAdresi = new frmInternetKontrolAdresi();
        }

        private void KRSYukle_FormClosed(object sender, FormClosedEventArgs e)
        {
            KanunRaporSablonYukle.Name = Stringler.Bos;
            KanunRaporSablonYukle = new frmKanunRaporSablonYukle();
        }

        private void OGAyari_FormClosed(object sender, FormClosedEventArgs e)
        {
            OtomatikGecisAyari.Name = Stringler.Bos;
            OtomatikGecisAyari = new frmOtomatikGiderAyari();
        }

        private void SKTopluAyar_FormClosed(object sender, FormClosedEventArgs e)
        {
            SunucuKurulumuTopluAyar.Name = Stringler.Bos;
            SunucuKurulumuTopluAyar = new frmSunucuKurulumTopluAyarlar();
        }

        private void SMSAyar_FormClosed(object sender, FormClosedEventArgs e)
        {
            SMSAyar.Name = "";
            SMSAyar = new frmSMSAyarlari();
        }

        private void TrhAyar_FormClosed(object sender, FormClosedEventArgs e)
        {
            TarihceAyar.Name = Stringler.Bos;
            TarihceAyar = new frmTarihceAyarlari();
        }

        #endregion Diðer Ayar Kod

        #region Yedek Ýþlemleri Kod

        private void btnYedegiSistemiDon_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(YedegiSistemeGeriDon, Stringler.YedegiSistemeDon);
            YedegiSistemeGeriDon.FormClosed += new FormClosedEventHandler(YSGeriDon_FormClosed);
        }

        private void btnYedekAl_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(YedekAl, Stringler.YedekAl);
            YedekAl.FormClosed += new FormClosedEventHandler(YedekA_FormClosed);
        }

        private void YedekA_FormClosed(object sender, FormClosedEventArgs e)
        {
            YedekAl.Name = Stringler.Bos;
            YedekAl = new frmYedekAl();
        }

        private void YSGeriDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            YedegiSistemeGeriDon.Name = Stringler.Bos;
            YedegiSistemeGeriDon = new frmYedegiSistemeGeriDon();
        }

        #endregion Yedek Ýþlemleri Kod

        #region Firma ve Kullanici Gruplari

        private void btnFirmaTanimlama_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(FirmaTanimlari, Stringler.FirmaTanimlari);
            FirmaTanimlari.FormClosed += new FormClosedEventHandler(FirmaTanimlari_FormClosed);
        }

        private void btnGrupYetkileri_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(GrupTanim, Stringler.GrupTanimlari);
            GrupTanim.FormClosed += new FormClosedEventHandler(GrupTanim_FormClosed);
            btnKaydet.ItemClick += GrupTanim.btnKaydet_ItemClick;
        }

        private void btnIslemYetkileri_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(IslemYetkileri, Stringler.IslemYetkileri);
            IslemYetkileri.FormClosed += new FormClosedEventHandler(IslemYetkileri_FormClosed);
        }

        private void btnKullaniciGruplari_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(KullaniciGruplari, Stringler.KullaniciGruplari);
            KullaniciGruplari.FormClosed += new FormClosedEventHandler(KullaniciGruplari_FormClosed);
        }

        private void btnKullaniciTanýmlari_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(KullaniciTanimlari, Stringler.KullaniciTanimlari);
            KullaniciTanimlari.FormClosed += new FormClosedEventHandler(KullaniciTanimlari_FormClosed);
            btnKaydet.ItemClick += KullaniciTanimlari.btnKaydet_ItemClick;
        }

        private void FirmaTanimlari_FormClosed(object sender, FormClosedEventArgs e)
        {
            FirmaTanimlari.Name = Stringler.Bos;
            FirmaTanimlari = new frmFirmaTanimlari();
        }

        private void GrupTanim_FormClosed(object sender, FormClosedEventArgs e)
        {
            GrupTanim.Name = Stringler.Bos;
            GrupTanim = new frmGrupTanimlama();
        }

        private void IslemYetkileri_FormClosed(object sender, FormClosedEventArgs e)
        {
            IslemYetkileri.Name = Stringler.Bos;
            IslemYetkileri = new frmIslemYetkileri();
        }

        private void KullaniciGruplari_FormClosed(object sender, FormClosedEventArgs e)
        {
            KullaniciGruplari.Name = Stringler.Bos;
            KullaniciGruplari = new frmKullaniciGruplari();
        }

        private void KullaniciTanimlari_FormClosed(object sender, FormClosedEventArgs e)
        {
            KullaniciTanimlari.Name = Stringler.Bos;
            KullaniciTanimlari = new frmKullaniciTanimlari();
        }

        #endregion Firma ve Kullanici Gruplari

        private void barBtnSurum_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSurumGuncelleme frm = new frmSurumGuncelleme();
            frm.ShowDialog();
        }

        private void btnKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnSistemTanimlari_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSistemTanimlari frm = new frmSistemTanimlari() { MdiParent = this, WindowState = FormWindowState.Maximized };
            frm.Show();
        }

        private void btnYedekAlma_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void rfrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //string _sirketNfo = Application.StartupPath + "\\cmpnfo3.gio";
            //File.Delete(_sirketNfo);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabGecisKontrolu(OzelKodIslemleri, "OzelKodIslemleri");
            OzelKodIslemleri.FormClosed += OzelKodIslemleri_FormClosed;
            btnKaydet.ItemClick += OzelKodIslemleri.btnKaydet_ItemClick;
        }

        void OzelKodIslemleri_FormClosed(object sender, FormClosedEventArgs e)
        {
            OzelKodIslemleri.Name = Stringler.Bos;
            OzelKodIslemleri = new frmOzelKod();
        }
    }
}