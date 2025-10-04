using AvukatProLib.Hesap.Views;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Genel
{
    public partial class frmTumDosyalardaArama : Form
    {
        #region <MB-20091219> LOAD

        public frmTumDosyalardaArama()
        {
            InitializeComponent();
            gcAramaSonuclari.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
        }

        private string dosya = string.Empty;

        private string esas = string.Empty;

        private int? kullanici;

        private List<AvukatProLib.Hesap.Views.ProjeBirlesikTakiplerTumu> MyDataSource =
            new List<AvukatProLib.Hesap.Views.ProjeBirlesikTakiplerTumu>();

        private void frmTumDosyalardaArama_Load(object sender, EventArgs e)
        {
            Inits.perCariGetir(lueTarafAdi.Properties);

            #region <MB-20091219>

            //GridControldeki Lookupların doldurulması.
            Inits.AdliBirimAdliyeGetir(rlueAdliye);
            Inits.AdliBirimGorevGetir(rlueGorev);
            Inits.AdliBirimNoGetir(rlueBirim);

            #endregion <MB-20091219>

            if (kullanici != null)
                lueTarafAdi.EditValue = kullanici.Value;
            if (!string.IsNullOrEmpty(dosya))
                txtDosyaNo.Text = dosya;
            if (!string.IsNullOrEmpty(esas))
                txtEsasNo.EditValue = esas;
            sbtnAra.PerformClick();
        }

        #endregion <MB-20091219> LOAD

        #region <MB-20091219> TAKİP EKRANLARINA GÖNDERME İŞLEMLERİ

        private void RightClickPopup_PopupOpening(object sender, AdimAdimDavaKaydi.UserControls.PopupOpeningEventArgs e)
        {
        }

        #endregion <MB-20091219> TAKİP EKRANLARINA GÖNDERME İŞLEMLERİ

        #region <MB-20091219> ARAMA İŞLEMİ

        public void Show(int? kullaniciID, string dosyaNo, string esasNo)
        {
            if (kullaniciID.HasValue || !string.IsNullOrEmpty(dosyaNo) || !string.IsNullOrEmpty(esasNo))
            {
                if (kullaniciID != null)
                    kullanici = kullaniciID.Value;
                if (!string.IsNullOrEmpty(dosyaNo))
                    dosya = dosyaNo;
                if (!string.IsNullOrEmpty(esasNo))
                    esas = esasNo;
            }
            this.Show();
        }

        private void lueTarafAdi_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTarafAdi.EditValue != null)
            {
                if ((int)lueTarafAdi.EditValue > 0)
                    kullanici = (int?)lueTarafAdi.EditValue;
                txtDosyaNo.Enabled = false;
                txtEsasNo.Enabled = false;
            }
            else
            {
                kullanici = null;
                txtDosyaNo.Enabled = true;
                txtEsasNo.Enabled = true;
            }
        }

        private void sbtnAra_Click(object sender, EventArgs e)
        {
            List<HizliArama> aramaSonuclari = new List<HizliArama>();

            if (kullanici.HasValue && kullanici > 0)
            {
                try
                {
                    aramaSonuclari = AvukatProLib.Hesap.Views.HizliArama.GetByCariId(kullanici.Value,
                                                                                     AvukatProLib.Kimlik.SubeKodu);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }

            if (!string.IsNullOrEmpty(dosya))
            {
                try
                {
                    aramaSonuclari = AvukatProLib.Hesap.Views.HizliArama.GetByFoyNo(dosya, AvukatProLib.Kimlik.SubeKodu);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }

            if (!string.IsNullOrEmpty(esas))
            {
                try
                {
                    aramaSonuclari = AvukatProLib.Hesap.Views.HizliArama.GetByEsasNo(esas, AvukatProLib.Kimlik.SubeKodu);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }

            gcAramaSonuclari.DataSource = aramaSonuclari;
        }

        private void sbtnGelismis_Click(object sender, EventArgs e)
        {
            this.Close();
            rFrmTumDosyalar tumDosyalarGelismis = new rFrmTumDosyalar();
            tumDosyalarGelismis.Show();
        }

        private void txtDosyaNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDosyaNo.Text))
            {
                dosya = txtDosyaNo.Text;
                lueTarafAdi.Enabled = false;
                txtEsasNo.Enabled = false;
            }
            else
            {
                dosya = null;
                lueTarafAdi.Enabled = true;
                txtEsasNo.Enabled = true;
            }
        }

        private void txtEsasNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEsasNo.Text))
            {
                esas = txtEsasNo.Text;
                lueTarafAdi.Enabled = false;
                txtDosyaNo.Enabled = false;
            }
            else
            {
                esas = null;
                lueTarafAdi.Enabled = true;
                txtDosyaNo.Enabled = true;
            }
        }

        #endregion <MB-20091219> ARAMA İŞLEMİ

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var arama = gridView1.GetFocusedRow() as HizliArama;

            switch (arama.TIPI)
            {
                case "DAVA":
                    AV001_TD_BIL_FOY foyd = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(arama.ID);
                    AdimAdimDavaKaydi.DavaTakip.frmDavaTakip frmdavaTakip = new AdimAdimDavaKaydi.DavaTakip.frmDavaTakip();
                    frmdavaTakip.Show(arama.ID);
                    this.Close();
                    break;

                case "İCRA":
                    AV001_TI_BIL_FOY foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(arama.ID);
                    TList<AV001_TI_BIL_FOY> seciliIKayitler = new TList<AV001_TI_BIL_FOY>();
                    seciliIKayitler.Add(foy);
                    AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip frmicraTakip =
                        new AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip();
                    frmicraTakip.Show(seciliIKayitler);
                    this.Close();
                    break;

                case "SORUŞTURMA":
                    AV001_TD_BIL_HAZIRLIK foyh = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(arama.ID);
                    TList<AV001_TD_BIL_HAZIRLIK> seciliHKayitler = new TList<AV001_TD_BIL_HAZIRLIK>();
                    seciliHKayitler.Add(foyh);
                    AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip frmhazirlikTakip =
                        new AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip();
                    frmhazirlikTakip.Show(seciliHKayitler);
                    this.Close();
                    break;

                case "SÖZLEŞME":
                    AV001_TDI_BIL_SOZLESME foyS = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(arama.ID);
                    AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeTakip frmhsozlesmeTakip =
                        new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeTakip();
                    frmhsozlesmeTakip.Show(foyS.ID);
                    this.Close();
                    break;

                case "TEBLİGAT":
                    AV001_TDI_BIL_TEBLIGAT foyt = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByID(arama.ID);

                    //TList<AV001_TDI_BIL_TEBLIGAT> seciliTKayitlar = new TList<AV001_TDI_BIL_TEBLIGAT>();
                    //seciliTKayitlar.Add(foyt);
                    AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit frmTebligatKayit =
                        new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit();
                    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(foyt, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TList<AV001_TDIE_BIL_BELGE>),
                                                                           typeof(TList<NN_BELGE_TEBLIGAT>),
                                                                           typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>),
                                                                           typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>
                                                                               ));
                    frmTebligatKayit.bndTebligat.DataSource = foyt;
                    frmTebligatKayit.Show();
                    this.Close();
                    break;

                case "BELGE":
                    AV001_TDIE_BIL_BELGE foyb = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(arama.ID);
                    TList<AV001_TDIE_BIL_BELGE> seciliBKayitlar = new TList<AV001_TDIE_BIL_BELGE>();
                    seciliBKayitlar.Add(foyb);
                    AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak frmBelgeKayit =
                        new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();
                    DataRepository.AV001_TDIE_BIL_BELGEProvider.DeepLoad(foyb, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDIE_BIL_BELGE_TARAF>));
                    frmBelgeKayit.ucBelgeKayitUfak1.Duzenle = true;

                    //frmBelgeKayit.MdiParent = null;
                    frmBelgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmBelgeKayit.MyDataSource = seciliBKayitlar;
                    frmBelgeKayit.Show();
                    this.Close();
                    break;

                case "KLASÖR":
                    AV001_TDIE_BIL_PROJE proje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(arama.ID);
                    TList<AV001_TDIE_BIL_PROJE> seciliKayitler = new TList<AV001_TDIE_BIL_PROJE>();
                    seciliKayitler.Add(proje);
                    frmKlasorYeni klasor = new frmKlasorYeni();
                    klasor.Show(seciliKayitler);
                    this.Close();
                    break;

                default:
                    break;
            }
        }
    }
}