using System;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace AdimAdimDavaKaydi.Util.KullaniciAyar
{
    public partial class ucDavaNedenAyarlar : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        #region LOAD

        public ucDavaNedenAyarlar()
        {
            InitializeComponent();
        }

        private TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR davaAlacakNedenAyarim =
            new TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR();

        private TList<TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR> davaAlacakNedenAyarlar =
            new TList<TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR>();

        private void ucDavaNedenAyarlar_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                BindLookUps();

                #region <MB-20091224>

                //Formun açılışında eğer dava neden bilgileri önce girilip, kaydedilmişse, bu bilgilerin formda ilgili yerlere gelmesi sağlanıyor.
                TList<TD_BIL_DAVA_KULLANICI_AYAR> ayar =
                    DataRepository.TD_BIL_DAVA_KULLANICI_AYARProvider.GetByKULLANICI_ID(AvukatProLib.Kimlik.Bilgi.ID);
                TList<TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR> davaNeden =
                    DataRepository.TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYARProvider.GetByKULLANICI_ID(
                        AvukatProLib.Kimlik.Bilgi.ID);
                if (ayar != null && ayar.Count > 0)
                {
                    if (davaNeden.Count > 0)
                        davaAlacakNedenAyarim = davaNeden[0];
                }
                else
                    davaAlacakNedenAyarim = new TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR();
                bndDavaNedenAyarlariDuzenle.DataSource = davaAlacakNedenAyarim;

                #endregion

                KullaniciTanimliDavaNedenleri();
            }
        }

        #endregion

        #region EVENTS

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            if (lueDavaNedeni.EditValue != null)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                bndDavaNedenAyarlariDuzenle.EndEdit();

                #region Dava Neden Secenek Ayar Kaydet

                try
                {
                    var ayarlar = bndDavaNedenAyarlariDuzenle.Current as TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR;

                    if (ayarlar == null) return;

                    if (!bndDavaNedenAyarlari.List.Contains(ayarlar))
                    {
                        var sonuclar =
                            (bndDavaNedenAyarlari.List.OfType<TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR>().Where(
                                vi => vi.DAVA_TIP_ID == ayarlar.DAVA_TIP_ID && vi.KULLANICI_ID == ayarlar.KULLANICI_ID));

                        if (sonuclar.Count() > 0)
                        {
                            bndDavaNedenAyarlari.Position = bndDavaNedenAyarlari.List.IndexOf(sonuclar.First());
                            bndDavaNedenAyarlariDuzenle.DataSource = new TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR();

                            KullaniciTanimliDavaNedenleri();

                            DavaNedenleriKontrolleriKullanilabilirmi(false);
                            ucIcraSablonYazdirLayout.TamamEkleButonlariKullanimi(sbtnYeni, sbtnKaydet);
                            XtraMessageBox.Show("Seçtiğiniz dava tipi ile ilgili ayarlarınız zaten mevcut.", "BİLGİ",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            tran.BeginTransaction();

                            bndDavaNedenAyarlari.Add(ayarlar);

                            foreach (var item in bndDavaNedenAyarlari.List)
                            {
                                var ayar = item as TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR;
                                ayar.KAYIT_TARIHI = DateTime.Now;
                                ayar.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
                                ayar.DO_FAIZ_ORANI = (double)txtDOFaizOrani.EditValue;
                                ayar.DS_FAIZ_ORANI = (double)txtDSFaizOrani.EditValue;
                                DataRepository.TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYARProvider.Save(tran, ayar);
                            }
                            tran.Commit();
                            XtraMessageBox.Show("Dava Alacak Neden Seçenekleri Kayıt İşlemi Tamamlanmıştır...");
                            KullaniciTanimliDavaNedenleri();

                            DavaNedenleriKontrolleriKullanilabilirmi(false);
                            ucIcraSablonYazdirLayout.TamamEkleButonlariKullanimi(sbtnYeni, sbtnKaydet);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen)
                        tran.Rollback();
                    BelgeUtil.ErrorHandler.Catch(this, ex, false, BelgeUtil.Bilesen.Kayit);
                }

                #endregion Dava Neden Secenek Ayar Kaydet
            }
        }

        private TD_BIL_DAVA_KULLANICI_AYAR kullaniciAyar;

        private int? OlayYeriAdliyeID;

        private void chMahkemeAdiOlayYerin_CheckedChanged(object sender, EventArgs e)
        {
            kullaniciAyar =
                DataRepository.TD_BIL_DAVA_KULLANICI_AYARProvider.GetByKULLANICI_ID(AvukatProLib.Kimlik.Bilgi.ID).
                    FirstOrDefault();

            if (chMahkemeAdiOlayYerin.Checked)
            {
                lueOlayYeri.Enabled = false;
                OlayYeriAdliyeID = kullaniciAyar.ADLIYE_ID;
            }
            else
            {
                lueOlayYeri.Enabled = true;
            }
        }

        private void lueOlayYeri_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOlayYeri.EditValue != null)
                OlayYeriAdliyeID = (int)lueOlayYeri.EditValue;
        }

        private void lueDOFaizTip_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.Value.ToString() != "9")
                {
                    txtDOFaizOrani.Enabled = false;
                    txtDOFaizOrani.Text = string.Empty;
                    lueDSFaizTip.EditValue = e.Value;
                    txtDSFaizOrani.Enabled = false;
                    txtDSFaizOrani.Text = string.Empty;
                }
                else
                {
                    txtDOFaizOrani.Enabled = true;
                    lueDSFaizTip.EditValue = e.Value;
                    txtDSFaizOrani.Enabled = true;
                }
                txtDSFaizOrani.EditValue = txtDOFaizOrani.EditValue = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value, 1, DateTime.Today);
            }
        }

        private void lueDSFaizTip_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.Value.ToString() != "9")
                {
                    txtDSFaizOrani.Enabled = false;
                }
                else
                {
                    txtDSFaizOrani.Enabled = true;
                }
                txtDOFaizOrani.EditValue = txtDSFaizOrani.EditValue = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value, 1, DateTime.Today);
            }
        }

        private void sbtnYeni_Click(object sender, EventArgs e)
        {
            var ayar = new TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR();
            ayar.KAYIT_TARIHI = DateTime.Now;
            ayar.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
            ayar.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;

            bndDavaNedenAyarlariDuzenle.DataSource = ayar;

            DavaNedenleriKontrolleriKullanilabilirmi(true);
            ucIcraSablonYazdirLayout.TamamEkleButonlariKullanimi(sbtnKaydet, sbtnYeni);

            chMahkemeAdiOlayYerin.Checked = true;
            lueOlayYeri.Enabled = false;
        }

        private void lueDavaTipi_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                int davaTipi = (int)e.NewValue;

                BelgeUtil.Inits.DavaKonuGetirByAdliBirimBolumKod(lueDavaKonusu.Properties, davaTipi);
                AvukatPro.Services.Implementations.DevExpressService.DavaNedeniDoldur(lueDavaNedeni, davaTipi, false);
                //BelgeUtil.Inits.DavaAdiGetirByDavaTipi(lueDavaNedeni.Properties, davaTipi);

                #region Ceza ve İcra-Ceza dava tiplerinde Faiz bilgilieri invisible

                if (davaTipi == 1 || davaTipi == 13)
                    EnabledFaizControls(false);
                else
                    EnabledFaizControls(true);

                #endregion
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bndDavaNedenAyarlariDuzenle.DataSource = bndDavaNedenAyarlari.Current;

            DavaNedenleriKontrolleriKullanilabilirmi(true);
            ucIcraSablonYazdirLayout.TamamEkleButonlariKullanimi(sbtnKaydet, sbtnYeni);

            lueDavaTipi_EditValueChanging(lueDavaTipi, new ChangingEventArgs(0, lueDavaTipi.EditValue));

            if ((bndDavaNedenAyarlariDuzenle.Current as TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR).DAVA_TIP_ID == 1 ||
                (bndDavaNedenAyarlariDuzenle.Current as TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR).DAVA_TIP_ID == 13)
                EnabledFaizControls(false);
            else
                EnabledFaizControls(true);
        }

        #endregion

        #region METODS

        public void BindLookUps()
        {
            BelgeUtil.Inits.AdliBirimBolumGetirForDavaNedenAyarlar(lueDavaTipi.Properties);
            BelgeUtil.Inits.FaizTipiGetir(lueDOFaizTip);
            BelgeUtil.Inits.FaizTipiGetir(lueDSFaizTip);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(lueOlayYeri);

            BelgeUtil.Inits.AdliBirimBolumGetirForDavaNedenAyarlar(rlueDavaTipi);
            BelgeUtil.Inits.DavaTalepGetirForDavaNedenAyarlar(rlueDavaKonusu);
            AvukatPro.Services.Implementations.DevExpressService.DavaNedeniDoldur(rlueDavaNedeni, null, false);
            //BelgeUtil.Inits.DavaAdiGetirForDavaNedenAyarlar(rlueDavaNedeni);
            BelgeUtil.Inits.FaizTipiGetir(rlueDOFaizTip);
            BelgeUtil.Inits.FaizTipiGetir(rlueDSFaizTip);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueOlayYeri);

            lueDavaKonusu.Properties.NullText = "Önce Dava Tipini Seçiniz.";
            lueDavaNedeni.Properties.NullText = "Önce Dava Tipini Seçiniz.";
        }

        private TList<TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR> davaNedenAyarlarByKullanici;

        private void KullaniciTanimliDavaNedenleri()
        {
            davaNedenAyarlarByKullanici =
                DataRepository.TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYARProvider.GetByKULLANICI_ID(
                    AvukatProLib.Kimlik.Bilgi.ID);

            bndDavaNedenAyarlari.DataSource = davaNedenAyarlarByKullanici;
        }

        private void DavaNedenleriKontrolleriKullanilabilirmi(bool durum)
        {
            lueDavaTipi.Enabled = durum;
            lueDavaKonusu.Enabled = durum;
            lueDavaNedeni.Enabled = durum;
            lueDOFaizTip.Enabled = durum;
            lueDSFaizTip.Enabled = durum;
            txtDOFaizOrani.Enabled = durum;
            txtDSFaizOrani.Enabled = durum;
            lueOlayYeri.Enabled = durum;
            chMahkemeAdiOlayYerin.Enabled = durum;
        }

        public void EnabledFaizControls(bool durum)
        {
            lueDOFaizTip.Enabled = durum;
            lueDSFaizTip.Enabled = durum;
            txtDOFaizOrani.Enabled = durum;
            txtDSFaizOrani.Enabled = durum;
        }

        #endregion
    }
}