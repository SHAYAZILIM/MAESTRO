using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace AdimAdimDavaKaydi.Util.KullaniciAyar
{
    public partial class ucIcraSablonYazdirLayout : DevExpress.XtraEditors.XtraUserControl
    {
        #region LOAD

        public ucIcraSablonYazdirLayout()
        {
            InitializeComponent();
        }

        private AvukatProLib.Arama.AvpDataContext db =
            new AvukatProLib.Arama.AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        private void ucIcraSablonYazdirLayout_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                BindLookUpEdits();

                if (AvukatProLib.Kimlik.Bilgi.ID == 1)
                    lcItemDefaultDegerler.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                lueSozlesme.Properties.NullText = "Seç";
                lueSozlesmeAnaTip.EditValue = (int) SozlesmeAnaTip.Resmi_Senet;

                bndIcraYazdirmaAyar.DataSource =
                    db.AV001_TI_BIL_YAZDIRMA_AYARLARIs.Where(vi => vi.KULLANICI_ID == AvukatProLib.Kimlik.Bilgi.ID);
            }
        }

        private void BindLookUpEdits()
        {
            BelgeUtil.Inits.FormTipiGetir(lueFormTipi.Properties);
            BelgeUtil.Inits.KullaniciListesiGetir(lueKullanici);
            BelgeUtil.Inits.SablonRaporGetirOtomatik(lueSablon.Properties);
            BelgeUtil.Inits.SozlesmeTipiGetir(lueSozlesmeAnaTip);
            BelgeUtil.Inits.SozlesmeAltTipiHepsiGetir(lueSozlesme);
            BelgeUtil.Inits.AlacakNedenKodGetir(lueAlacakNedeni);
        }

        #region Form Tipine Göre Sözleşme ve Alacak Nedeni Bilgilerinin Gelmesi.

        //Seçilen form tipine göre alacak nedeni ve sözleşme bilgilerinin doldurulması sağlandı.
        private int formTipi;

        private void lueFormTipi_EditValueChanged(object sender, EventArgs e)
        {
            if (lueFormTipi.EditValue != null)
            {
                formTipi = (int) lueFormTipi.EditValue;

                //Seçilen form tipine göre alacak nedenleri dolduruluyor.
                (lueAlacakNedeni.Properties.DataSource as TList<TI_KOD_ALACAK_NEDEN>).Filter = "FORM_TIP_ID = " +
                                                                                               formTipi;

                //Seçilen form tipine göre sözleşme bilgisi dolduruluyor.
                if ((int) lueFormTipi.EditValue != (int) FormTipleri.Form49 ||
                    (int) lueFormTipi.EditValue != (int) FormTipleri.Form51)
                    ForumTipineGoreSozlesmeYapilenadir((FormTipleri) lueFormTipi.EditValue);
                else
                    XtraMessageBox.Show(
                        "FormTipi 49 ve 51 olduğundan Sözleşme otamatik atanamıyor. Lütfen bir Alacak Nedeni Seçiniz",
                        "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //Seçilen form tipine göre sözleşme bilgisinin doldurulmasını sağlayan metod.
        private void ForumTipineGoreSozlesmeYapilenadir(FormTipleri t)
        {
            switch (t)
            {
                case FormTipleri.Form50:
                case FormTipleri.Form201:
                    lueSozlesmeAnaTip.EditValue = (int) SozlesmeAnaTip.Resmi_Senet;
                    (lueSozlesme.Properties.DataSource as TList<TDI_KOD_SOZLESME_ALT_TIP>).Filter = "ANA_TIP_ID = " +
                                                                                                    ((int)
                                                                                                     SozlesmeAnaTip.
                                                                                                         Resmi_Senet);
                    break;
                case FormTipleri.Form151:
                case FormTipleri.Form152:
                    lueSozlesmeAnaTip.EditValue = (int) SozlesmeAnaTip.Resmi_Senet;
                    (lueSozlesme.Properties.DataSource as TList<TDI_KOD_SOZLESME_ALT_TIP>).Filter = "ANA_TIP_ID = " +
                                                                                                    ((int)
                                                                                                     SozlesmeAnaTip.
                                                                                                         Resmi_Senet);
                    break;
                case FormTipleri.Form49:
                case FormTipleri.Form51:
                    switch ((AlacakNeden) lueAlacakNedeni.EditValue)
                    {
                        case AlacakNeden.Kira_43:
                        case AlacakNeden.Kira:
                        case AlacakNeden.Kira_5:
                        case AlacakNeden.KiraFarkı_45:
                        case AlacakNeden.KiraFarkı_46:
                        case AlacakNeden.KiraFarkı_6:
                            lueSozlesmeAnaTip.EditValue = (int) SozlesmeAnaTip.Kira_Sozlemesi;
                            (lueSozlesme.Properties.DataSource as TList<TDI_KOD_SOZLESME_ALT_TIP>).Filter =
                                "ANA_TIP_ID = " + ((int) SozlesmeAnaTip.Kira_Sozlemesi);
                            break;
                        case AlacakNeden.BankaKrediKarti:
                        case AlacakNeden.BankaKrediKarti_9:
                        case AlacakNeden.BankaKrediAlacagi:
                        case AlacakNeden.BankaKrediAlacagi_10:
                            lueSozlesmeAnaTip.EditValue = (int) SozlesmeAnaTip.Kredi_Sozlemesi;
                            (lueSozlesme.Properties.DataSource as TList<TDI_KOD_SOZLESME_ALT_TIP>).Filter =
                                "ANA_TIP_ID = " + ((int) SozlesmeAnaTip.Kira_Sozlemesi);
                            break;
                        case AlacakNeden.MenkulRehni_14:
                        case AlacakNeden.MenkulRehni_53:
                        case AlacakNeden.Ipotek_32:
                        case AlacakNeden.Ipotek_52:
                            lueSozlesmeAnaTip.EditValue = (int) SozlesmeAnaTip.Resmi_Senet;
                            (lueSozlesme.Properties.DataSource as TList<TDI_KOD_SOZLESME_ALT_TIP>).Filter =
                                "ANA_TIP_ID = " + ((int) SozlesmeAnaTip.Resmi_Senet);
                            break;
                        case AlacakNeden.ROTATIF_KREDI_151:
                        case AlacakNeden.ROTATIF_KREDI_152:
                        case AlacakNeden.ROTATIF_KREDI_201:
                        case AlacakNeden.ROTATIF_KREDI_50:
                        case AlacakNeden.ROTATIF_KREDI:
                            lueSozlesmeAnaTip.EditValue = (int) SozlesmeAnaTip.Resmi_Senet;
                            (lueSozlesme.Properties.DataSource as TList<TDI_KOD_SOZLESME_ALT_TIP>).Filter =
                                "ANA_TIP_ID = " + ((int) SozlesmeAnaTip.Resmi_Senet);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        //Alacak nedeni 49 ya da 51 ise alacak nedenine göre sözleşme bilgisi dolduruluyor.
        private void lueAlacakNedeni_EditValueChanged(object sender, EventArgs e)
        {
            int formTipi = (bndIcraYazdirmaAyar.Current as AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI).FORM_ID;
            if (formTipi == (int) FormTipleri.Form49 || formTipi == (int) FormTipleri.Form51)
            {
                if (lueFormTipi.EditValue != null)
                    ForumTipineGoreSozlesmeYapilenadir((FormTipleri) lueFormTipi.EditValue);
            }
        }

        #endregion

        #region Düzenleme sırasında ID yerine Source üzerinden işlem yapılabilmesi.

        private void lueSablon_EditValueChanging(object sender, ChangingEventArgs e)
        {
            var detay =
                bndIcraYazdirmaAyarDetayDuzenle.Current as AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAY;

            detay.AV001_TDIE_BIL_SABLON_RAPOR =
                db.AV001_TDIE_BIL_SABLON_RAPORs.Where(vi => vi.ID == (int) e.NewValue).First();
        }

        private void lueFormTipi_EditValueChanging(object sender, ChangingEventArgs e)
        {
            var ayar = bndIcraYazdirmaAyarDuzenle.Current as AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI;

            ayar.TI_KOD_FORM_TIP = db.TI_KOD_FORM_TIPs.Where(vi => vi.ID == (int) e.NewValue).First();
        }

        #endregion

        #endregion

        #region BUTTON CLICK EVENT

        private void sbtnSeciliSablonEkle_Click(object sender, EventArgs e)
        {
            if (!dxValidationProviderSablon.Validate())
                return;

            bndIcraYazdirmaAyarDetayDuzenle.EndEdit();

            var ayarlar =
                bndIcraYazdirmaAyarDetayDuzenle.Current as AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAY;
            if (ayarlar == null) return;
            if (!bndIcraYazdirmaAyarDetay.List.Contains(ayarlar))
                bndIcraYazdirmaAyarDetay.Add(ayarlar);

            DetayKontrolleriKullanilabilir(false);

            db.SubmitChanges();

            TamamEkleButonlariKullanimi(sbtnYeniKayit, sbtnSeciliSablonEkle);

            FormTipiveKullaniciKullanilabilir(false);

            TamamEkleButonlariKullanimi(sbtnFormTipiEkle, sbtnTamam);
        }

        private void sbtnYeniKayit_Click(object sender, EventArgs e)
        {
            FormTipiveKullaniciKullanilabilir(true);
            bndIcraYazdirmaAyarDuzenle.DataSource = bndIcraYazdirmaAyar.Current;

            var ayar = new AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAY();
            ayar.KAYIT_TARIHI = DateTime.Now;
            ayar.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            ayar.KONTROL_NE_ZAMAN = DateTime.Now;
            ayar.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            ayar.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;

            bndIcraYazdirmaAyarDetayDuzenle.DataSource = ayar;

            DetayKontrolleriKullanilabilir(true);

            TamamEkleButonlariKullanimi(sbtnSeciliSablonEkle, sbtnYeniKayit);
        }

        private void sbtnFormTipiEkle_Click(object sender, EventArgs e)
        {
            var ayar = new AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI();
            ayar.KAYIT_TARIHI = DateTime.Now;
            ayar.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            ayar.KONTROL_NE_ZAMAN = DateTime.Now;
            ayar.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            ayar.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;
            ayar.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
            bndIcraYazdirmaAyarDuzenle.DataSource = ayar;

            FormTipiveKullaniciKullanilabilir(true);

            TamamEkleButonlariKullanimi(sbtnTamam, sbtnFormTipiEkle);
        }

        private void sbtnTamam_Click(object sender, EventArgs e)
        {
            if (!dxValidationProviderFormTipi.Validate())
                return;

            bndIcraYazdirmaAyarDuzenle.EndEdit();
            var ayarlar = bndIcraYazdirmaAyarDuzenle.Current as AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI;
            if (!bndIcraYazdirmaAyar.List.Contains(ayarlar))
            {
                var sonuclar =
                    (bndIcraYazdirmaAyar.List.OfType<AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI>().Where(
                        vi => vi.FORM_ID == ayarlar.FORM_ID && vi.KULLANICI_ID == ayarlar.KULLANICI_ID));

                if (sonuclar.Count() > 0)
                {
                    bndIcraYazdirmaAyar.Position = bndIcraYazdirmaAyar.List.IndexOf(sonuclar.First());
                    bndIcraYazdirmaAyarDuzenle.DataSource = new AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI();
                }
                else
                {
                    bndIcraYazdirmaAyar.Add(ayarlar);
                    db.SubmitChanges();

                    lbKullaniciFormlar.SelectedItem = ayarlar;
                }
            }

            FormTipiveKullaniciKullanilabilir(false);

            TamamEkleButonlariKullanimi(sbtnFormTipiEkle, sbtnTamam);
        }

        private void sbtnVazgecFormTipi_Click(object sender, EventArgs e)
        {
            bndIcraYazdirmaAyarDuzenle.DataSource = new AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI();

            FormTipiveKullaniciKullanilabilir(false);
            TamamEkleButonlariKullanimi(sbtnFormTipiEkle, sbtnTamam);
        }

        private void sbtnVazgecSablon_Click(object sender, EventArgs e)
        {
            bndIcraYazdirmaAyarDetayDuzenle.DataSource = new AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAY();

            DetayKontrolleriKullanilabilir(false);
            TamamEkleButonlariKullanimi(sbtnYeniKayit, sbtnSeciliSablonEkle);
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTipiveKullaniciKullanilabilir(true);

            bndIcraYazdirmaAyarDuzenle.DataSource = bndIcraYazdirmaAyar.Current;

            TamamEkleButonlariKullanimi(sbtnTamam, sbtnFormTipiEkle);
        }

        private void düzenleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DetayKontrolleriKullanilabilir(true);
            bndIcraYazdirmaAyarDetayDuzenle.DataSource = bndIcraYazdirmaAyarDetay.Current;

            TamamEkleButonlariKullanimi(sbtnSeciliSablonEkle, sbtnYeniKayit);
        }

        #region Avukatpro kullanıcısının yazdırma ayarlarının, default ayar yapılıyor.

        private void sbtnDefaultDegerler_Click(object sender, EventArgs e)
        {
            var avukatpro = db.AV001_TI_BIL_YAZDIRMA_AYARLARIs.Where(vi => vi.KONTROL_KIM_ID == 1);
            var kullanici =
                db.AV001_TI_BIL_YAZDIRMA_AYARLARIs.Where(vi => vi.KULLANICI_ID == AvukatProLib.Kimlik.Bilgi.ID);
            List<AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI> yeniListe =
                new List<AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI>();
            DialogResult dr =
                XtraMessageBox.Show(
                    "Yazdırma ayarlarınız silinip yerine yeni default değerler girilecek. Onaylıyor musunuz?", "SORU",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                foreach (var item in kullanici)
                {
                    db.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAYs.DeleteAllOnSubmit(
                        item.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAYs);
                }
                db.AV001_TI_BIL_YAZDIRMA_AYARLARIs.DeleteAllOnSubmit(kullanici);

                foreach (var item in avukatpro)
                {
                    var ayar = new AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI();
                    ayar.TI_KOD_FORM_TIP = item.TI_KOD_FORM_TIP;
                    ayar.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
                    ayar.TDI_BIL_KULLANICI_LISTESI =
                        db.TDI_BIL_KULLANICI_LISTESIs.Where(vi => vi.ID == AvukatProLib.Kimlik.Bilgi.ID).First();
                    ayar.TDI_BIL_KULLANICI_LISTESI1 = ayar.TDI_BIL_KULLANICI_LISTESI;
                    ayar.KAYIT_TARIHI = DateTime.Now;
                    ayar.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                    ayar.KONTROL_NE_ZAMAN = DateTime.Now;
                    ayar.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    ayar.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;

                    foreach (var mDetay in item.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAYs)
                    {
                        var cDetay = new AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAY();

                        cDetay.AV001_TDIE_BIL_SABLON_RAPOR = mDetay.AV001_TDIE_BIL_SABLON_RAPOR;
                        cDetay.ALACAK_NEDENI_ID = mDetay.ALACAK_NEDENI_ID;
                        cDetay.SOZLESME_ALT_TIP_ID = mDetay.SOZLESME_ALT_TIP_ID;
                        cDetay.HACIZDE_CIKSIN_MI = mDetay.HACIZDE_CIKSIN_MI;
                        cDetay.TEDBIRDE_CIKSIN_MI = mDetay.TEDBIRDE_CIKSIN_MI;
                        cDetay.CIKTI_SAYISI = mDetay.CIKTI_SAYISI;
                        cDetay.YAZDIRILSIN_MI = mDetay.YAZDIRILSIN_MI;
                        cDetay.KONTROL_KIM_ID = mDetay.KONTROL_KIM_ID;
                        cDetay.KONTROL_NE_ZAMAN = mDetay.KONTROL_NE_ZAMAN;
                        cDetay.KAYIT_TARIHI = mDetay.KAYIT_TARIHI;
                        cDetay.KONTROL_VERSIYON = mDetay.KONTROL_VERSIYON;
                        cDetay.SUBE_KOD_ID = mDetay.SUBE_KOD_ID;
                        cDetay.STAMP = mDetay.STAMP;

                        cDetay.TDI_BIL_KULLANICI_LISTESI = ayar.TDI_BIL_KULLANICI_LISTESI;
                        ayar.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAYs.Add(cDetay);
                    }

                    yeniListe.Add(ayar);
                }

                db.AV001_TI_BIL_YAZDIRMA_AYARLARIs.InsertAllOnSubmit(yeniListe);
                db.SubmitChanges();

                bndIcraYazdirmaAyar.DataSource = yeniListe;
            }

            else
                XtraMessageBox.Show("Default ayarların kaydedilmesi işlemini iptal ettiniz.", "BİLGİ",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Kontrollerin Enable/Disable yapılmasını sağlayan metodlar

        private void FormTipiveKullaniciKullanilabilir(bool durum)
        {
            lueFormTipi.Enabled = durum;
            lueKullanici.Enabled = durum;
        }

        private void DetayKontrolleriKullanilabilir(bool durum)
        {
            lueAlacakNedeni.Enabled = durum;
            lueSozlesme.Enabled = durum;
            lueSablon.Enabled = durum;
            chIhtiyatiHacizdeCiksin.Enabled = durum;
            chIhtiyatiTedbirdeCiksin.Enabled = durum;
            chYazdirilsin.Enabled = durum;
        }

        public static void TamamEkleButonlariKullanimi(SimpleButton sbtnTrue, SimpleButton sbtnFalse)
        {
            sbtnTrue.Enabled = true;
            sbtnFalse.Enabled = false;
        }

        #endregion

        #endregion

        #region <MB-20101501> Şablon Silme İşlemi

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var current = bndIcraYazdirmaAyarDetay.Current as AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAY;

            if (current != null)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                try
                {
                    tran.BeginTransaction();

                    db.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAYs.DeleteOnSubmit(current);
                    bndIcraYazdirmaAyarDetay.Remove(current);
                    db.SubmitChanges();

                    tran.Commit();

                    XtraMessageBox.Show("Silme işlemi gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen)
                        tran.Rollback();
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void tümünüSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = bndIcraYazdirmaAyarDetay.List.Cast<AvukatProLib.Arama.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAY>();

            if (list != null)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                try
                {
                    tran.BeginTransaction();

                    db.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAYs.DeleteAllOnSubmit(list);
                    db.SubmitChanges();

                    tran.Commit();

                    XtraMessageBox.Show("Silme işlemi gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen)
                        tran.Rollback();
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        #endregion
    }
}