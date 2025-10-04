using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Cetvel;
using AnaForm;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmCetvel : Util.BaseClasses.AvpXtraForm
    {
        public frmCetvel()
        {
            InitializeComponent();
        }

        public static void CatchKontrol(XtraForm frm, Exception ex, TransactionManager tran)
        {
            if (ex is SqlException && ex.Message.ToLower().Contains("conflict"))
            {
                if (tran.IsOpen)
                    tran.Rollback();
                MessageBox.Show("Kayýt'a baðlý bulunan kayýtlardan dolayý silme iþlemi gerçekleþtirilemiyor");

                BelgeUtil.ErrorHandler.Catch(frm, ex, false, BelgeUtil.Bilesen.Kayit);
            }
            else
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(frm, ex, true, BelgeUtil.Bilesen.Kayit);
            }
        }

        private void cetvel_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            barMenu.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Expanded;
            CetvelGetirGrid();
        }

        private void CetvelGetirGrid()
        {
            DataTable dt = new DataTable("YetkiKullanmaTipi");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.CETTABLOADI tipi in Enum.GetValues(typeof(AvukatProLib.Extras.CETTABLOADI)))
            {
                dt.Rows.Add(tipi.ToString().Replace('_', ' '));
            }
            gridMenu.DataSource = dt;
            gridView1.Tag = "CET";
            gridColumn1.FieldName = "ACIKLAMA";
        }

        private void FormCagir(string frmAdi)
        {
            switch (frmAdi)
            {
                case "frmGunlukDovizKurlari":
                    frmGunlukDovizKurlari frmDoviz = new frmGunlukDovizKurlari();
                    frmDoviz.gunlukDovizGetir();
                    KontrolEkle(frmDoviz, "panelDoviz");
                    frmDoviz.Dispose();
                    break;

                case "frmDavaMaktuHarcCetveli":
                    frmDavaMaktuHarcCetveli frmDavaMaktu = new frmDavaMaktuHarcCetveli();
                    frmDavaMaktu.maktuDavaHarcGetir();
                    KontrolEkle(frmDavaMaktu, "panelDavaMaktu");
                    frmDavaMaktu.Dispose();
                    break;

                case "frmFaizTarifeCetveli":
                    frmFaizTarifeCetveli frmFaizTarifeCetveli = new frmFaizTarifeCetveli();
                    frmFaizTarifeCetveli.faizTarifeGetir();
                    KontrolEkle(frmFaizTarifeCetveli, "panelFaizTarifeCetveli");
                    frmFaizTarifeCetveli.Dispose();
                    break;

                case "frmDavaNispiHarcCetveli":
                    frmDavaNispiHarcCetveli frmNispiHarc = new frmDavaNispiHarcCetveli();
                    frmNispiHarc.nispiHarcGetir();
                    KontrolEkle(frmNispiHarc, "panelDavaNispiHarcCetveli");
                    frmNispiHarc.Dispose();
                    break;

                //case "frmNispiHarcCetveli":
                //    frmDavaNispiHarcCetvel frmIcraNispiHarc = new frmIcraNispiHarcCetveli();
                //    frmIcraNispiHarc.IcraNispiHarcCetveli();
                //    KontrolEkle(frmIcraNispiHarc, "panelIcraNispiHarcCetveli");
                //    frmIcraNispiHarc.Dispose();
                //    break;
                case "frmEvrakGiderCetveli":
                    frmEvrakGiderCetveli frmEvrakGider = new frmEvrakGiderCetveli();
                    frmEvrakGider.evrakGiderCetvelGetir();
                    KontrolEkle(frmEvrakGider, "panelEvrakGiderCetvel");
                    frmEvrakGider.Dispose();
                    break;

                case "frmGorevliMahkemeBelirle":
                    frmGorevliMahkemeBelirle frmGorevliMahkeme = new frmGorevliMahkemeBelirle();
                    frmGorevliMahkeme.gorevliMahkemeBelirGetir();
                    KontrolEkle(frmGorevliMahkeme, "panelGorevliMahkemeBelirle");
                    frmGorevliMahkeme.Dispose();
                    break;

                case "frmKDVCetveli":
                    frmKDVCetveli frmKDV = new frmKDVCetveli();
                    frmKDV.kdvCetveliGetir();
                    KontrolEkle(frmKDV, "panelKDVCetvel");
                    frmKDV.Dispose();
                    break;

                case "frmMemurYevmiye":
                    frmMemurYevmiye frmMemur = new frmMemurYevmiye();
                    frmMemur.memurYevmiyeGetir();
                    KontrolEkle(frmMemur, "panelMemurYevmiye");
                    frmMemur.Dispose();
                    break;

                case "frmOtomatikMuhasebeKalemleri":
                    frmOtomatikMuhasebeKalemleri frmOtomatikMuhasebe = new frmOtomatikMuhasebeKalemleri();
                    frmOtomatikMuhasebe.muhasebeKalemGetir();
                    KontrolEkle(frmOtomatikMuhasebe, "panelOtomatikMuhasebe");
                    frmOtomatikMuhasebe.Dispose();
                    break;

                case "frmGiderCetveli":
                    frmGiderCetveli frmPostaGider = new frmGiderCetveli();
                    frmPostaGider.giderCetveliGetir();
                    KontrolEkle(frmPostaGider, "panelPostaGider");
                    frmPostaGider.Dispose();
                    break;

                case "frmMinMaxDegerCetveli":
                    frmMinMaxDegerCetveli frmMinMax = new frmMinMaxDegerCetveli();
                    frmMinMax.minMaxDegerGetir();
                    KontrolEkle(frmMinMax, "panelMinMaxDeger");
                    frmMinMax.Dispose();
                    break;

                case "frmTeminatTazminat":
                    frmTeminatTazminat frmTemTaz = new frmTeminatTazminat();
                    frmTemTaz.teminatTazminatGetir();
                    KontrolEkle(frmTemTaz, "panelTeminatTazminat");
                    frmTemTaz.Dispose();
                    break;

                case "frmVekaletMaktuCetveli":
                    frmVekaletMaktuCetveli frmVekaletMaktu = new frmVekaletMaktuCetveli();
                    frmVekaletMaktu.vekaletMaktuGetir();
                    KontrolEkle(frmVekaletMaktu, "panelVekaletMaktu");
                    frmVekaletMaktu.Dispose();
                    break;

                case "frmYuvarlamaCetveli":
                    frmYuvarlamaCetveli frmYuvarla = new frmYuvarlamaCetveli();
                    frmYuvarla.yuvarlamaCetvelGetir();
                    KontrolEkle(frmYuvarla, "panelYuvarlamaCetveli");
                    frmYuvarla.Dispose();
                    break;

                case "frmYediEminUcretiMaktu":
                    frmYediEminUcretiMaktu frmYeddiEmin = new frmYediEminUcretiMaktu();
                    frmYeddiEmin.yeddiMaktuUcretDoldur();
                    KontrolEkle(frmYeddiEmin, "panelYeddiEmin");
                    frmYeddiEmin.Dispose();
                    break;

                case "frmYediEminUcretiNispi":
                    frmYediEminUcretiNispi frmNispiYeddiEmin = new frmYediEminUcretiNispi();
                    frmNispiYeddiEmin.yeddiNispiDoldur();
                    KontrolEkle(frmNispiYeddiEmin, "panelNispiYeddiEmin");
                    frmNispiYeddiEmin.Dispose();
                    break;

                case "frmVekaletNispiCetveli":
                    frmVekaletNispiCetveli frmVekaletNispi = new frmVekaletNispiCetveli();
                    frmVekaletNispi.vekaletNispiGetir();
                    KontrolEkle(frmVekaletNispi, "panelVekaletNispiUcreti");
                    frmVekaletNispi.Dispose();
                    break;

                case "frmDigerVergiOranlari":
                    frmDigerVergiOranlari frmDigerVergi = new frmDigerVergiOranlari();
                    frmDigerVergi.digerVergiOranGetir();
                    KontrolEkle(frmDigerVergi, "panelDigerVergiOranlari");
                    frmDigerVergi.Dispose();
                    break;

                case "frmIcraResmiTatil":
                    frmIcraResmiTatil frmResmiTatilOzelGun = new frmIcraResmiTatil();
                    frmResmiTatilOzelGun.onemliGunGetir();
                    KontrolEkle(frmResmiTatilOzelGun, "panelResmiTatilOzelGunler");
                    frmResmiTatilOzelGun.Dispose();
                    break;

                case "frmBorclununTakibiniEngellemeYollari":
                    frmBorclununTakibiniEngellemeYollari frmIcraKod10 = new frmBorclununTakibiniEngellemeYollari();
                    frmIcraKod10.takipEngellemeYollariGetir();
                    KontrolEkle(frmIcraKod10, "panelBorcluTakipEngel");
                    frmIcraKod10.Dispose();
                    break;

                case "frmDavaVekaletSozlesme":
                    frmDavaVekaletSozlesme frmDavaVekaletSoz = new frmDavaVekaletSozlesme();
                    frmDavaVekaletSoz.vekaletSozlesmeGetir();
                    KontrolEkle(frmDavaVekaletSoz, "panelDavaVekaletUCretleri");
                    frmDavaVekaletSoz.Dispose();
                    break;

                case "frmIcraKodlar11":
                    frmIcraKodlar11 frmDavaTalepleri = new frmIcraKodlar11();
                    frmDavaTalepleri.davaTalepGetir();
                    KontrolEkle(frmDavaTalepleri, "panelDavaTalepleri");
                    frmDavaTalepleri.Dispose();
                    break;

                case "frmItirazSebebKodlari":
                    frmItirazSebebKodlari frmItirazSebeb = new frmItirazSebebKodlari();
                    frmItirazSebeb.itirazSebebGetir();
                    KontrolEkle(frmItirazSebeb, "panelItirazSebebKodlari");
                    frmItirazSebeb.Dispose();
                    break;

                case "frmMahsupTip":
                    frmMahsupTip frmMahsupT = new frmMahsupTip();
                    frmMahsupT.mahsupTipGetir();
                    KontrolEkle(frmMahsupT, "panelMahsupTip");
                    frmMahsupT.Dispose();
                    break;

                case "frmItirazSonuclari":
                    frmItirazSonuclari frmItirazSonuc = new frmItirazSonuclari();
                    frmItirazSonuc.itirazSonucGetir();
                    KontrolEkle(frmItirazSonuc, "panelItirazSonuclari");
                    frmItirazSonuc.Dispose();
                    break;

                case "frmHacizIslemDurumlari":
                    frmHacizIslemDurumlari frmHacizIslem = new frmHacizIslemDurumlari();
                    frmHacizIslem.hacizIslemDurumGetir();
                    KontrolEkle(frmHacizIslem, "panelHAcizIslemDUrum");
                    frmHacizIslem.Dispose();
                    break;

                case "frmOdemeYerKodlari":
                    frmOdemeYerKodlari frmOdemeYer = new frmOdemeYerKodlari();
                    frmOdemeYer.odemeYerGetir();
                    KontrolEkle(frmOdemeYer, "panelOdemeYerKodlari");
                    frmOdemeYer.Dispose();
                    break;

                case "frmAlacakNedenKodlari":
                    frmAlacakNedenKodlari frmALacakNeden = new frmAlacakNedenKodlari();
                    frmALacakNeden.alacakNEdenKodGetir();
                    KontrolEkle(frmALacakNeden, "panelAlacakNedenKodlari");
                    frmALacakNeden.Dispose();
                    break;

                case "frmItirazTipKodlari":
                    frmItirazTipKodlari frmItirazTipKOD = new frmItirazTipKodlari();
                    frmItirazTipKOD.itirazTipGetir();
                    KontrolEkle(frmItirazTipKOD, "panelItirazTipKodlar");
                    frmItirazTipKOD.Dispose();
                    break;

                case "frmSikayetNedenKodlari":
                    frmSikayetNedenKodlari frmSikayetNedenKod = new frmSikayetNedenKodlari();
                    frmSikayetNedenKod.sikayetNedenGetir();
                    KontrolEkle(frmSikayetNedenKod, "panelSikayetNEdenKodlarý");
                    frmSikayetNedenKod.Dispose();
                    break;

                case "frmTakipYoluKodlari":
                    frmTakipYoluKodlari frmTakipYolu = new frmTakipYoluKodlari();
                    frmTakipYolu.takipYoluGetir();
                    KontrolEkle(frmTakipYolu, "panelTakipYoluKodlari");
                    frmTakipYolu.Dispose();
                    break;

                case "frmTeminatTurKodlari":
                    frmTeminatTurKodlari frmTeminatTur = new frmTeminatTurKodlari();
                    frmTeminatTur.teminatTurKodGetir();
                    KontrolEkle(frmTeminatTur, "panelTeminatTurKodlari");
                    frmTeminatTur.Dispose();
                    break;

                case "frmTeminatTipleri":
                    frmTeminatTipleri frmTeminatTip = new frmTeminatTipleri();
                    frmTeminatTip.teminatTipGetir();
                    KontrolEkle(frmTeminatTip, "panelTeminatTipleri");
                    frmTeminatTip.Dispose();
                    break;

                case "frmTakipTalepKodlari":
                    frmTakipTalepKodlari frmTakipTalep = new frmTakipTalepKodlari();
                    frmTakipTalep.takipTelepGetir();
                    KontrolEkle(frmTakipTalep, "panelTakipTalepKodlari");
                    frmTakipTalep.Dispose();
                    break;

                case "frmTakipTalikNedenleri":
                    frmTakipTalikNedenleri frmTakipTalik = new frmTakipTalikNedenleri();
                    frmTakipTalik.talikNedenGetir();
                    KontrolEkle(frmTakipTalik, "panelTakipTalikErteleme");
                    frmTakipTalik.Dispose();
                    break;

                case "frmItirazinGiderilmeYolKodlari":
                    frmItirazinGiderilmeYolKodlari frmItirazGidermeYol = new frmItirazinGiderilmeYolKodlari();
                    frmItirazGidermeYol.itirazGiderilmeYolGetir();
                    KontrolEkle(frmItirazGidermeYol, "panelItirazinGiderilmeYollari");
                    frmItirazGidermeYol.Dispose();
                    break;

                case "frmTalimatIslemTurleri":
                    frmTalimatIslemTurleri frmTalimatIslem = new frmTalimatIslemTurleri();
                    frmTalimatIslem.talimatIslemTipGetir();
                    KontrolEkle(frmTalimatIslem, "panelTalimatIslemTuru");
                    frmTalimatIslem.Dispose();
                    break;

                case "frmIcraGelismeKodlari":
                    frmIcraGelismeKodlari frmIcraGelisme = new frmIcraGelismeKodlari();
                    frmIcraGelisme.foyGelismeAdimGetir();
                    KontrolEkle(frmIcraGelisme, "panelIcraGelismeKodlari");
                    frmIcraGelisme.Dispose();
                    break;

                case "frmTDFoyOzelKodlari":
                    frmTDFoyOzelKodlari frmFoyOzelKod = new frmTDFoyOzelKodlari();
                    frmFoyOzelKod.foyOzelKodGetir();
                    KontrolEkle(frmFoyOzelKod, "panelDosyaOzelKodlar");
                    frmFoyOzelKod.Dispose();
                    break;

                case "frmTespitKonulari":
                    frmTespitKonulari frmTespit = new frmTespitKonulari();
                    frmTespit.tespitKonuGetir();
                    KontrolEkle(frmTespit, "panelDosyaOzelKodlar");
                    frmTespit.Dispose();
                    break;

                case "frmDavaMahkemeHukumKodlari":
                    frmDavaMahkemeHukumKodlari frmDavaMahHukum = new frmDavaMahkemeHukumKodlari();
                    frmDavaMahHukum.mahkemeHukumGetir();
                    KontrolEkle(frmDavaMahHukum, "panelDavaMahkemeHukumleri");
                    frmDavaMahHukum.Dispose();
                    break;

                case "frmDavaGelismeKodlari":
                    frmDavaGelismeKodlari frmDavaGelisme = new frmDavaGelismeKodlari();
                    frmDavaGelisme.gelismeAdimGetir();
                    KontrolEkle(frmDavaGelisme, "panelDavaGelismeKadlar");
                    frmDavaGelisme.Dispose();
                    break;

                case "frmTespitOzelKodlari":
                    frmTespitOzelKodlari frmTespitOzel = new frmTespitOzelKodlari();
                    frmTespitOzel.tespitOzelKodGetir();
                    KontrolEkle(frmTespitOzel, "panelTespitOzelKodlar");
                    frmTespitOzel.Dispose();
                    break;

                case "frmDavaKanitTipKodlari":
                    frmDavaKanitTipKodlari frmDavaKanitTip = new frmDavaKanitTipKodlari();
                    frmDavaKanitTip.kanitTipGetir();
                    KontrolEkle(frmDavaKanitTip, "panelDavaKanitTipleri");
                    frmDavaKanitTip.Dispose();
                    break;

                case "frmRucuIbranameDurumKodlari":
                    frmRucuIbranameDurumKodlari frmRucuIbraname = new frmRucuIbranameDurumKodlari();
                    frmRucuIbraname.ibranameDurumGetir();
                    KontrolEkle(frmRucuIbraname, "panelRucuIbranameDurum");
                    frmRucuIbraname.Dispose();
                    break;

                case "frmRucuBelgeTurKodlari":
                    frmRucuBelgeTurKodlari frmRucuBelgeTur = new frmRucuBelgeTurKodlari();
                    frmRucuBelgeTur.belgeTurGetir();
                    KontrolEkle(frmRucuBelgeTur, "panelRucuBelgeTur");
                    frmRucuBelgeTur.Dispose();
                    break;

                case "frmRucuHikaye":
                    frmRucuHikaye frmRucuHik = new frmRucuHikaye();
                    frmRucuHik.rucuHikayeGetir();
                    KontrolEkle(frmRucuHik, "panelRucuHikayesi");
                    frmRucuHik.Dispose();
                    break;

                case "frmBankaAdlari":
                    frmBankaAdlari frmBanka = new frmBankaAdlari();
                    frmBanka.BankaGetir();
                    KontrolEkle(frmBanka, "panelBankaAdlari");
                    frmBanka.Dispose();
                    break;

                case "frmFaizTipleri":
                    frmFaizTipleri frmFaizTip = new frmFaizTipleri();
                    frmFaizTip.faizTipleriDoldur();
                    KontrolEkle(frmFaizTip, "panelFaizTipKodlar");
                    frmFaizTip.Dispose();
                    break;

                case "frmVekaletGecerlilikTip":
                    frmVekaletGecerlilikTip frmVekaletGecerlilik = new frmVekaletGecerlilikTip();
                    frmVekaletGecerlilik.vekaletGecerlilikTipGetir();
                    KontrolEkle(frmVekaletGecerlilik, "panelVekaletGecerlilikTipler");
                    frmVekaletGecerlilik.Dispose();
                    break;

                case "frmSozlesmeTip":
                    frmSozlesmeTip frmSozlesme = new frmSozlesmeTip();
                    frmSozlesme.sozlesmeTipGetir();
                    KontrolEkle(frmSozlesme, "panelSozlesmeTipleri");
                    frmSozlesme.Dispose();
                    break;

                case "frmOdemeTip":
                    frmOdemeTip frmOdemeT = new frmOdemeTip();
                    frmOdemeT.odemeTipGetir();
                    KontrolEkle(frmOdemeT, "panelOdemeTipleri");
                    frmOdemeT.Dispose();
                    break;

                case "frmMiktarBirimKodlari":
                    frmMiktarBirimKodlari frmMiktar = new frmMiktarBirimKodlari();
                    frmMiktar.miktarBirimKodGetir();
                    KontrolEkle(frmMiktar, "panelMiktarBirimKodlar");
                    frmMiktar.Dispose();
                    break;

                case "frmIletisimAnaKategoriEkle":
                    frmIletisimAnaKategoriEkle frmIletisimAnaKat = new frmIletisimAnaKategoriEkle();
                    frmIletisimAnaKat.iletisimAnaKodGetir();
                    KontrolEkle(frmIletisimAnaKat, "panelIletisimAnaKategori");
                    frmIletisimAnaKat.Dispose();
                    break;

                case "frmFoyDurumKodlari":
                    frmFoyDurumKodlari frmFoydurum = new frmFoyDurumKodlari();
                    frmFoydurum.foyDurumGetir();
                    KontrolEkle(frmFoydurum, "panelFoyDurumKodlari");
                    frmFoydurum.Dispose();
                    break;

                case "frmIsKonulari":
                    frmIsKonulari frmIsKonu = new frmIsKonulari();
                    frmIsKonu.isKohnuKodGetir();
                    KontrolEkle(frmIsKonu, "panelIsKonulari");
                    frmIsKonu.Dispose();
                    break;

                case "frmSureKategoriKodlari":
                    frmSureKategoriKodlari frmSureKategori = new frmSureKategoriKodlari();
                    frmSureKategori.sureKategoriGetir();
                    KontrolEkle(frmSureKategori, "panelSureKategoriKodlar");
                    frmSureKategori.Dispose();
                    break;

                case "frmKiymetliEvrakTurleri":
                    frmKiymetliEvrakTurleri frmKiymetliEvrak = new frmKiymetliEvrakTurleri();
                    frmKiymetliEvrak.evrakTurKodGetir();
                    KontrolEkle(frmKiymetliEvrak, "frmKiymetliEvrakTurleri");
                    frmKiymetliEvrak.Dispose();
                    break;

                case "frmIcraKodlar12":
                    frmIcraKodlar12 frmAdlibirimAdliye = new frmIcraKodlar12();
                    frmAdlibirimAdliye.adliBirimAdliyeGetir();
                    KontrolEkle(frmAdlibirimAdliye, "panelAdlibirimAdliye");
                    frmAdlibirimAdliye.Dispose();
                    break;

                case "frmAdliBirimNo":
                    frmAdliBirimNo frmAdliBirNo = new frmAdliBirimNo();
                    frmAdliBirNo.AdlBirimDoldur();
                    KontrolEkle(frmAdliBirNo, "panelAdliBirimNumara");
                    frmAdliBirNo.Dispose();
                    break;

                //case "frmTemsilTur":
                //    frmTemsilTur frmTemsilTurLeri = new frmTemsilTur();
                //    frmTemsilTurLeri.te();
                //    KontrolEkle(frmTemsilTurLeri, "panelTemsilTurleri");
                //    frmTemsilTurLeri.Dispose();
                //    break;
                case "frmIcraKodlar13":
                    frmIcraKodlar13 frmDavaAdlari = new frmIcraKodlar13();
                    frmDavaAdlari.davaAdiGetir();
                    KontrolEkle(frmDavaAdlari, "panelDavaAdlari");
                    frmDavaAdlari.Dispose();
                    break;

                case "frmBelgeOzelKodlari":
                    frmBelgeOzelKodlari frmBelgeOzel = new frmBelgeOzelKodlari();
                    frmBelgeOzel.belgeOzelKodGetir();
                    KontrolEkle(frmBelgeOzel, "panelBelgeOzelKodlar");
                    frmBelgeOzel.Dispose();
                    break;

                case "frmFaizKalem":
                    frmFaizKalem frmFaizKLMN = new frmFaizKalem();
                    frmFaizKLMN.faizKalemGetir();
                    KontrolEkle(frmFaizKLMN, "panelFaizKalemleri");
                    frmFaizKLMN.Dispose();
                    break;

                case "frmMalKategoriKodlari":
                    frmMalKategoriKodlari frmMalKategori = new frmMalKategoriKodlari();
                    frmMalKategori.malKatKodGetir();
                    KontrolEkle(frmMalKategori, "panelMalKategoriKodlar");
                    frmMalKategori.Dispose();
                    break;

                case "frmMalTurKodlari":
                    frmMalTurKodlari frmMalTurKodlar = new frmMalTurKodlari();
                    frmMalTurKodlar.malTurKodGetir();
                    KontrolEkle(frmMalTurKodlar, "panelMalTurKodlar");
                    frmMalTurKodlar.Dispose();
                    break;

                case "frmDovizTipKodlari":
                    frmDovizTipKodlari frmDovizTip = new frmDovizTipKodlari();
                    frmDovizTip.dovizTipDoldur();
                    KontrolEkle(frmDovizTip, "panelDoviztipKodlar");
                    frmDovizTip.Dispose();
                    break;

                case "frmMahkemeAdlari":
                    frmMahkemeAdlari frmMahkemeAD = new frmMahkemeAdlari();
                    frmMahkemeAD.mahkemeGetir();
                    KontrolEkle(frmMahkemeAD, "panelMahkemeAdlari");
                    frmMahkemeAD.Dispose();
                    break;

                case "frmIcraKodlar5":
                    frmIcraKodlar5 frmTeminatTazminatOranlari = new frmIcraKodlar5();
                    frmTeminatTazminatOranlari.teminatTazminatGetir();
                    KontrolEkle(frmTeminatTazminatOranlari, "panelTeminatTazminatOranlari");
                    frmTeminatTazminatOranlari.Dispose();
                    break;

                case "frmYazismaTurKodlari":
                    frmYazismaTurKodlari frmYazismaTurKod = new frmYazismaTurKodlari();
                    frmYazismaTurKod.yazismaTurGetir();
                    KontrolEkle(frmYazismaTurKod, "panelYazismaTurKodlar");
                    frmYazismaTurKod.Dispose();
                    break;

                case "frmHaczedilemeyenMalCinsleri":
                    frmHaczedilemeyenMalCinsleri frmHaczEdilemeyenMAl = new frmHaczedilemeyenMalCinsleri();
                    frmHaczEdilemeyenMAl.hacizEdilemelenMalGrupGetir();
                    KontrolEkle(frmHaczEdilemeyenMAl, "panelMalCinsleriHAcizEdilmeyen");
                    frmHaczEdilemeyenMAl.Dispose();
                    break;

                case "frmMuhasebeAnaKategoriEkle":
                    frmMuhasebeAnaKategoriEkle frmMuhasebeAnaKategori = new frmMuhasebeAnaKategoriEkle();
                    frmMuhasebeAnaKategori.muhAnaKatKodGetir();
                    KontrolEkle(frmMuhasebeAnaKategori, "panelMuhasebeanaKategorileri");
                    frmMuhasebeAnaKategori.Dispose();
                    break;

                case "frmOzelCariKodlari":
                    frmOzelCariKodlari frmCariOzel = new frmOzelCariKodlari();
                    frmCariOzel.cariOzelKodGetir();
                    KontrolEkle(frmCariOzel, "panelCariOzelKodlar");
                    frmCariOzel.Dispose();
                    break;

                case "frmCinsiyetKodlari":
                    frmCinsiyetKodlari frmCinsiyetKOD = new frmCinsiyetKodlari();
                    frmCinsiyetKOD.cinsiyetKodGetir();
                    KontrolEkle(frmCinsiyetKOD, "panelCinsiyetKodlar");
                    frmCinsiyetKOD.Dispose();
                    break;

                case "frmFoyIadeNedenKodlari":
                    frmFoyIadeNedenKodlari frmDosyaIadeNeden = new frmFoyIadeNedenKodlari();
                    frmDosyaIadeNeden.foyIadeNedenGetir();
                    KontrolEkle(frmDosyaIadeNeden, "panelDosyaIadeNedenKodlar");
                    frmDosyaIadeNeden.Dispose();
                    break;

                case "frmHesaplanmayacakKalemler":
                    frmHesaplanmayacakKalemler frmHesaplanmayacak = new frmHesaplanmayacakKalemler();
                    frmHesaplanmayacak.hesaplanmayacakKalemGetir();
                    KontrolEkle(frmHesaplanmayacak, "panelHesaplanmayacakKalemler");
                    frmHesaplanmayacak.Dispose();
                    break;

                case "frmFirmaTurleri":
                    frmFirmaTurleri frmFirmaTur = new frmFirmaTurleri();
                    frmFirmaTur.firmaTurDoldur();
                    KontrolEkle(frmFirmaTur, "panelFirmaTurleri");
                    frmFirmaTur.Dispose();
                    break;

                case "frmOzelTutarKonulari":
                    frmOzelTutarKonulari frmOzelTutar = new frmOzelTutarKonulari();
                    frmOzelTutar.ozelTutarKonuGetir();
                    KontrolEkle(frmOzelTutar, "panelOzelTutarKonular");
                    frmOzelTutar.Dispose();
                    break;

                case "frmIlKodlari":
                    frmIlKodlari frmIlKod = new frmIlKodlari();
                    frmIlKod.ilKodGetir();
                    KontrolEkle(frmIlKod, "panelIlKodlari");
                    frmIlKod.Dispose();
                    break;

                case "frmKanGruplari":
                    frmKanGruplari frmKanGrup = new frmKanGruplari();
                    frmKanGrup.kangrupGetir();
                    KontrolEkle(frmKanGrup, "panelKanGrupKodlar");
                    frmKanGrup.Dispose();
                    break;

                case "frmKimlikBelgeTurleri":
                    frmKimlikBelgeTurleri frmKimlikBelgeTur = new frmKimlikBelgeTurleri();
                    frmKimlikBelgeTur.kimlikKodGetir();
                    KontrolEkle(frmKimlikBelgeTur, "panelKimlikBelgeTurleri");
                    frmKimlikBelgeTur.Dispose();
                    break;

                case "frmMedeniHalKodlari":
                    frmMedeniHalKodlari frmMedeniHAL = new frmMedeniHalKodlari();
                    frmMedeniHAL.medeniHalKodGetir();
                    KontrolEkle(frmMedeniHAL, "panelMedeniHalKodlar");
                    frmMedeniHAL.Dispose();
                    break;

                case "frmMeslekKodlari":
                    frmMeslekKodlari frmMeslekKOD = new frmMeslekKodlari();
                    frmMeslekKOD.meslekKodGetir();
                    KontrolEkle(frmMeslekKOD, "panelMeslekKodlari");
                    frmMeslekKOD.Dispose();
                    break;

                case "frmTahsilDurumKodlari":
                    frmTahsilDurumKodlari frmTahsilDurumKOD = new frmTahsilDurumKodlari();
                    frmTahsilDurumKOD.tahsilatDurumGetir();
                    KontrolEkle(frmTahsilDurumKOD, "panelTahsilDurumKodlar");
                    frmTahsilDurumKOD.Dispose();
                    break;

                case "frmTemsilSekilKodlari":
                    frmTemsilSekilKodlari frmTemsilSekilKOD = new frmTemsilSekilKodlari();
                    frmTemsilSekilKOD.temsilSekilKodGetir();
                    KontrolEkle(frmTemsilSekilKOD, "TDI_KOD_TEMSIL_SEKIL");
                    frmTemsilSekilKOD.Dispose();
                    break;

                case "frmTSESKodlari":
                    frmTSESKodlari frmTemsilSonaErmeKOD = new frmTSESKodlari();
                    frmTemsilSonaErmeKOD.temsilSonaErmeSebebGetir();
                    KontrolEkle(frmTemsilSonaErmeKOD, "panelTemsilSonaErmeKodlar");
                    frmTemsilSonaErmeKOD.Dispose();
                    break;

                case "frmUlkeKodlari":
                    frmUlkeKodlari frmUlkeKOD = new frmUlkeKodlari();
                    frmUlkeKOD.ulkeKodlarGetir();
                    KontrolEkle(frmUlkeKOD, "panelUlkeKodlar");
                    frmUlkeKOD.Dispose();
                    break;

                case "frmUnvanKodlari":
                    frmUnvanKodlari frmUnvanKOD = new frmUnvanKodlari();
                    frmUnvanKOD.unvanKodGetir();
                    KontrolEkle(frmUnvanKOD, "panelUnvanKodlar");
                    frmUnvanKOD.Dispose();
                    break;

                case "frmSozlesmeAltTip":
                    frmSozlesmeAltTip frmSozlesmeALT = new frmSozlesmeAltTip();
                    frmSozlesmeALT.sozlesmeAltTipGetir();
                    KontrolEkle(frmSozlesmeALT, "panelSozlesmeAlttipleri");
                    frmSozlesmeALT.Dispose();
                    break;

                case "frmTebligatAlanBaglanti":
                    frmTebligatAlanBaglanti frmTebligatalanBAG = new frmTebligatAlanBaglanti();
                    frmTebligatalanBAG.tebligatAlanBagGetir();
                    KontrolEkle(frmTebligatalanBAG, "panelTebligatalanBaglanti");
                    frmTebligatalanBAG.Dispose();
                    break;

                case "frmTebligatAlinmamaNeden":
                    frmTebligatAlinmamaNeden frmTebligatAlinmamaNEDEN = new frmTebligatAlinmamaNeden();
                    frmTebligatAlinmamaNEDEN.tebligatAlNedenGetir();
                    KontrolEkle(frmTebligatAlinmamaNEDEN, "panelTebAlinmamaNeden");
                    frmTebligatAlinmamaNEDEN.Dispose();
                    break;

                case "frmTebligatAnaTur":
                    frmTebligatAnaTur frmTebliganaTUR = new frmTebligatAnaTur();
                    frmTebliganaTUR.tebligatAnaTurGetir();
                    KontrolEkle(frmTebliganaTUR, "panelTebligatAnaTur");
                    frmTebliganaTUR.Dispose();
                    break;

                case "frmTebligatPostaTipi":
                    frmTebligatPostaTipi frmTebligatPostaTip = new frmTebligatPostaTipi();
                    frmTebligatPostaTip.postaTipGetir();
                    KontrolEkle(frmTebligatPostaTip, "panelTebligatPostaTipleri");
                    frmTebligatPostaTip.Dispose();
                    break;

                case "frmTebligatTeslimYeri":
                    frmTebligatTeslimYeri frmTebligatTeslim = new frmTebligatTeslimYeri();
                    frmTebligatTeslim.tebligatTeslimYerGetir();
                    KontrolEkle(frmTebligatTeslim, "panelTebligatTeslimYeri");
                    frmTebligatTeslim.Dispose();
                    break;

                case "frmIletisimAltKategoriEkle":
                    frmIletisimAltKategoriEkle frmIletisimAltKategori = new frmIletisimAltKategoriEkle();
                    frmIletisimAltKategori.iletisimAltKodGetir();
                    KontrolEkle(frmIletisimAltKategori, "panelIletisimAltKategori");
                    frmIletisimAltKategori.Dispose();
                    break;

                case "frmSozlesmeKategoriEkle":
                    frmSozlesmeKategoriEkle frmSozKategori = new frmSozlesmeKategoriEkle();
                    frmSozKategori.sozlesmeKategoriGetir();
                    KontrolEkle(frmSozKategori, "panelSozlesmeKategoriEkle");
                    frmSozKategori.Dispose();
                    break;

                case "frmIlceKodlari":
                    frmIlceKodlari frmIlceKOD = new frmIlceKodlari();
                    frmIlceKOD.ilceKodGetir();
                    KontrolEkle(frmIlceKOD, "panelIlceKodlari");
                    frmIlceKOD.Dispose();
                    break;

                case "frmIsOncelikleri":
                    frmIsOncelikleri frmIsOncelik = new frmIsOncelikleri();
                    frmIsOncelik.isOncelikKodGetir();
                    KontrolEkle(frmIsOncelik, "panelIsOncelikleri");
                    frmIsOncelik.Dispose();
                    break;

                case "frmYayinTurleri":
                    frmYayinTurleri frmYayinTURU = new frmYayinTurleri();
                    frmYayinTURU.yayinTurlertiGetir();
                    KontrolEkle(frmYayinTURU, "panelYayinTurleri");
                    frmYayinTURU.Dispose();
                    break;

                case "frmMuhasebeBelgeTuruEkle":
                    frmMuhasebeBelgeTuruEkle frmBelgeTur = new frmMuhasebeBelgeTuruEkle();
                    frmBelgeTur.muhBelgeTurKodGetir();
                    KontrolEkle(frmBelgeTur, "panelBelgeTurleri");
                    frmBelgeTur.Dispose();
                    break;

                case "frmKlasorKodlari":
                    frmKlasorKodlari frmKlosorKOD = new frmKlasorKodlari();
                    frmKlosorKOD.klasorKodGetir();
                    KontrolEkle(frmKlosorKOD, "panelKlosorKodlar");
                    frmKlosorKOD.Dispose();
                    break;

                case "frmMuhasebeAltKategoriEkle":
                    frmMuhasebeAltKategoriEkle frmMuhasebeAltKategori = new frmMuhasebeAltKategoriEkle();
                    frmMuhasebeAltKategori.muhAltKatKodGetir();
                    KontrolEkle(frmMuhasebeAltKategori, "panelMuhasebeAltKategorileri");
                    frmMuhasebeAltKategori.Dispose();
                    break;

                case "frmTebligatAlimSekli":
                    frmTebligatAlimSekli frmTebligatAlim = new frmTebligatAlimSekli();
                    frmTebligatAlim.tebligatAlimSekliGetir();
                    KontrolEkle(frmTebligatAlim, "panelTebligatAlimSekli");
                    frmTebligatAlim.Dispose();
                    break;

                case "frmTebligatAltTur":
                    frmTebligatAltTur frmTebligAltTUR = new frmTebligatAltTur();
                    frmTebligAltTUR.tebligatAltTurGetir();
                    KontrolEkle(frmTebligAltTUR, "panelTebligatAltTur");
                    frmTebligAltTUR.Dispose();
                    break;

                case "frmTebligatKonulari":
                    frmTebligatKonulari frmTebligatKONU = new frmTebligatKonulari();
                    frmTebligatKONU.tebligatKonuGetir();
                    KontrolEkle(frmTebligatKONU, "panelTebligatKonulari");
                    frmTebligatKONU.Dispose();
                    break;

                case "frmTebligatSekil":
                    frmTebligatSekil frmTebligatSEKLI = new frmTebligatSekil();
                    frmTebligatSEKLI.tebligatSekliGetir();
                    KontrolEkle(frmTebligatSEKLI, "panelTebligatSekli");
                    frmTebligatSEKLI.Dispose();
                    break;

                case "frmSablonEkle":
                    frmSablonEkle frmSablonEKLE = new frmSablonEkle();
                    frmSablonEKLE.sablokGetir();
                    KontrolEkle(frmSablonEKLE, "panelSablonEkle");
                    frmSablonEKLE.Dispose();
                    break;

                case "frmIliskiNedenleri":
                    frmIliskiNedenleri frmIliskiNEDEN = new frmIliskiNedenleri();
                    frmIliskiNEDEN.kayitIliskiNedenKodGetir();
                    KontrolEkle(frmIliskiNEDEN, "panelIliskiNedenleri");
                    frmIliskiNEDEN.Dispose();
                    break;

                case "frmFoyBirimKodlari":
                    frmFoyBirimKodlari frmDosyaBirimKodlar = new frmFoyBirimKodlari();
                    frmDosyaBirimKodlar.foyBirimKodGetir();
                    KontrolEkle(frmDosyaBirimKodlar, "panelDosyabirimKodlar");
                    frmDosyaBirimKodlar.Dispose();
                    break;

                case "frmFoyOzelDurumKodlari":
                    frmFoyOzelDurumKodlari frmFoyOzelDurumKODLAR = new frmFoyOzelDurumKodlari();
                    frmFoyOzelDurumKODLAR.foyOzelDurumGetir();
                    KontrolEkle(frmFoyOzelDurumKODLAR, "panelDosyaOzelDurumKodlar");
                    frmFoyOzelDurumKODLAR.Dispose();
                    break;

                case "frmFoyTahsilatDurumKodlari":
                    frmFoyTahsilatDurumKodlari frmTahsilatDurumKODLAR = new frmFoyTahsilatDurumKodlari();
                    frmTahsilatDurumKODLAR.tahsilatDurumGetir();
                    KontrolEkle(frmTahsilatDurumKODLAR, "panelDosyaTahsilatDurumKodlar");
                    frmTahsilatDurumKODLAR.Dispose();
                    break;

                case "frmFoyKrediTipleri":
                    frmFoyKrediTipleri frmDosyaKrediTipleri = new frmFoyKrediTipleri();
                    frmDosyaKrediTipleri.krediTipGetir();
                    KontrolEkle(frmDosyaKrediTipleri, "panelDosyaKrediTipleri");
                    frmDosyaKrediTipleri.Dispose();
                    break;

                case "frmBankaBolgeKodlari":
                    frmBankaBolgeKodlari frmBankaBolgeKODLAR = new frmBankaBolgeKodlari();
                    frmBankaBolgeKODLAR.bankaBolgeGetir();
                    KontrolEkle(frmBankaBolgeKODLAR, "panelBankaBolgeKodlar");
                    frmBankaBolgeKODLAR.Dispose();
                    break;

                case "frmBankaKartTipKodlari":
                    frmBankaKartTipKodlari frmBankaKartTipKod = new frmBankaKartTipKodlari();
                    frmBankaKartTipKod.bankaKartTipGetir();
                    KontrolEkle(frmBankaKartTipKod, "panelBankaKarttipKodlar");
                    frmBankaKartTipKod.Dispose();
                    break;

                case "frmBankaHesapEkNoKodlari":
                    frmBankaHesapEkNoKodlari frmBankaEknoHEsap = new frmBankaHesapEkNoKodlari();
                    frmBankaEknoHEsap.bankaHesapEkNoGetir();
                    KontrolEkle(frmBankaEknoHEsap, "panelBankaHEsapEknoKodlar");
                    frmBankaEknoHEsap.Dispose();
                    break;

                case "frmBankaSubeKodlari":
                    frmBankaSubeKodlari frmBankaSubeKODLAR = new frmBankaSubeKodlari();
                    frmBankaSubeKODLAR.bankaSubeGetir();
                    KontrolEkle(frmBankaSubeKODLAR, "panelBankaSubeKodlari");
                    frmBankaSubeKODLAR.Dispose();
                    break;

                case "frmUyrukKodlari":
                    frmUyrukKodlari frmUyrukKOD = new frmUyrukKodlari();
                    frmUyrukKOD.uyrukKodGetir();
                    KontrolEkle(frmUyrukKOD, "panelUyrukKodlar");
                    frmUyrukKOD.Dispose();
                    break;

                case "frmFoyKrediGruplari":
                    frmFoyKrediGruplari frmFoyKrediGRUP = new frmFoyKrediGruplari();
                    frmFoyKrediGRUP.krediGrupGetir();
                    KontrolEkle(frmFoyKrediGRUP, "panelDosyaKrediGrup");
                    frmFoyKrediGRUP.Dispose();
                    break;

                case "frmDosyaYerleri":
                    frmDosyaYerleri frmDosyaYeri = new frmDosyaYerleri();
                    frmDosyaYeri.foyYeriDoldur();
                    KontrolEkle(frmDosyaYeri, "panelDosyaYerleri");
                    frmDosyaYeri.Dispose();
                    break;

                case "frmDavaCezaEtkenKodlari":
                    frmDavaCezaEtkenKodlari frmDavaCezaEtken = new frmDavaCezaEtkenKodlari();
                    frmDavaCezaEtken.cezaEtkenDavaKaydet();
                    KontrolEkle(frmDavaCezaEtken, "panelEtkenSebebKodlar");
                    frmDavaCezaEtken.Dispose();
                    break;

                case "frmDavaCezaEtkenDurumKodlari":
                    frmDavaCezaEtkenDurumKodlari frmEtkenDurumKodlar = new frmDavaCezaEtkenDurumKodlari();
                    frmEtkenDurumKodlar.cezaEtkenDurumGetir();
                    KontrolEkle(frmEtkenDurumKodlar, "panelEtkenSebebDurum");
                    frmEtkenDurumKodlar.Dispose();
                    break;

                case "frmDavaOzellikKodlari":
                    frmDavaOzellikKodlari frmDavaOzellikKODLAR = new frmDavaOzellikKodlari();
                    frmDavaOzellikKODLAR.davaOzellikGetir();
                    KontrolEkle(frmDavaOzellikKODLAR, "panelDavaOzellikKodlar");
                    frmDavaOzellikKODLAR.Dispose();
                    break;

                case "frmPoliceBransKodlari":
                    frmPoliceBransKodlari frmPolicebransKODLAR = new frmPoliceBransKodlari();
                    frmPolicebransKODLAR.policeBransGetir();
                    KontrolEkle(frmPolicebransKODLAR, "panelBransKodlar");
                    frmPolicebransKODLAR.Dispose();
                    break;

                case "frmBelgeBelgeTurleri":
                    frmBelgeBelgeTurleri frmBelgeTurleri = new frmBelgeBelgeTurleri();
                    frmBelgeTurleri.belgeTurleriGetir();
                    KontrolEkle(frmBelgeTurleri, "panelBelgeTurleri");
                    frmBelgeTurleri.Dispose();
                    break;

                //case "frmOzelSozlesmeKodlari":
                //    frmOzelSozlesmeKodlari frmOzelSozlesmKODLAR = new frmOzelSozlesmeKodlari();
                //    frmOzelSozlesmKODLAR.sozlesmeOzelKodGetir();
                //    KontrolEkle(frmOzelSozlesmKODLAR, "panelOzelSozlesmeKodlar");
                //    frmOzelSozlesmKODLAR.Dispose();
                //    break;
                case "frmSoslesmeGelisme":
                    frmSoslesmeGelisme frmSozlesmeGelismeKODLAR = new frmSoslesmeGelisme();
                    frmSozlesmeGelismeKODLAR.sozlesmeGelismeGetir();
                    KontrolEkle(frmSozlesmeGelismeKODLAR, "panelSozlesmeGelismeKodlar");
                    frmSozlesmeGelismeKODLAR.Dispose();
                    break;

                case "frmSozlesmeDurum":
                    frmSozlesmeDurum frmSozlesmeDurumKODLAR = new frmSozlesmeDurum();
                    frmSozlesmeDurumKODLAR.sozlesmeDurumGetir();
                    KontrolEkle(frmSozlesmeDurumKODLAR, "panelSozlesmDurumKodlar");
                    frmSozlesmeDurumKODLAR.Dispose();
                    break;

                case "frmSozlesmeTakyidatKodlari":
                    frmSozlesmeTakyidatKodlari frmTakyidatKODLAR = new frmSozlesmeTakyidatKodlari();
                    frmTakyidatKODLAR.sozlesmeTakyidatGetir();
                    KontrolEkle(frmTakyidatKODLAR, "panelTakyidatKodlar");
                    frmTakyidatKODLAR.Dispose();
                    break;

                case "frnIcraKodlar1":
                    frnIcraKodlar1 frmSozlesmeTarafKodlari = new frnIcraKodlar1();
                    frmSozlesmeTarafKodlari.sozlesmeTarafSifatGetir();
                    KontrolEkle(frmSozlesmeTarafKodlari, "panelSozlesmeTarafKodlar");
                    frmSozlesmeTarafKodlari.Dispose();
                    break;

                case "frmRehinDurum":
                    frmRehinDurum frmRehinDURUM = new frmRehinDurum();
                    frmRehinDURUM.rehinDurumGetir();
                    KontrolEkle(frmRehinDURUM, "panelRehinDurum");
                    frmRehinDURUM.Dispose();
                    break;

                case "frmRehinHarcIstisnaBelge":
                    frmRehinHarcIstisnaBelge frmRehinHarcIstisnaKODLAR = new frmRehinHarcIstisnaBelge();
                    frmRehinHarcIstisnaKODLAR.harcIstisnaGetir();
                    KontrolEkle(frmRehinHarcIstisnaKODLAR, "panelRehinHarcIstisna");
                    frmRehinHarcIstisnaKODLAR.Dispose();
                    break;

                case "frmTeminatMektupKonulari":
                    frmTeminatMektupKonulari frmTeminatMektupKONU = new frmTeminatMektupKonulari();
                    frmTeminatMektupKONU.teminatMektupKonuGetir();
                    KontrolEkle(frmTeminatMektupKONU, "panelTeminatMektupKonular");
                    frmTeminatMektupKONU.Dispose();
                    break;

                case "frmTeminatMektupDurum":
                    frmTeminatMektupDurum frmTeminatMektupDURUM = new frmTeminatMektupDurum();
                    frmTeminatMektupDURUM.teminatMektupDurumGetir();
                    KontrolEkle(frmTeminatMektupDURUM, "panelTeminatMektupDurumlar");
                    frmTeminatMektupDURUM.Dispose();
                    break;

                case "frmTeminatMektupTarafTip":
                    frmTeminatMektupTarafTip frmTeminatTarafTipleri = new frmTeminatMektupTarafTip();
                    frmTeminatTarafTipleri.teminatMektupTarafTipGetir();
                    KontrolEkle(frmTeminatTarafTipleri, "panelTeminatMektupTarafTipleri");
                    frmTeminatTarafTipleri.Dispose();
                    break;

                case "frmFirmaBolgeKodlari":
                    frmFirmaBolgeKodlari frmFirmaBolgeKOD = new frmFirmaBolgeKodlari();
                    frmFirmaBolgeKOD.firmaBolgeGetir();
                    KontrolEkle(frmFirmaBolgeKOD, "panelFirmaBolgeKodlar");
                    frmFirmaBolgeKOD.Dispose();
                    break;

                case "frmFirmaSubeKodlari":
                    frmFirmaSubeKodlari frmSubeKOD = new frmFirmaSubeKodlari();
                    frmSubeKOD.firmaSubeGetir();
                    KontrolEkle(frmSubeKOD, "panelFirmaSubeKodlar");
                    frmSubeKOD.Dispose();
                    break;

                case "frmSureOzelKodlari":
                    frmSureOzelKodlari frmSureOzelKOD = new frmSureOzelKodlari();
                    frmSureOzelKOD.sureKodGetir();
                    KontrolEkle(frmSureOzelKOD, "panelSureOzelKodlar");
                    frmSureOzelKOD.Dispose();
                    break;

                case "frmGrupBilgileri":
                    frmGrupBilgileri frmGrupBilgi = new frmGrupBilgileri();
                    frmGrupBilgi.kullaniciGrupGetir();
                    KontrolEkle(frmGrupBilgi, "panelKullaniciGrup");
                    frmGrupBilgi.Dispose();
                    break;

                case "frmAdresTurleri":
                    frmAdresTurleri frmAdresTUR = new frmAdresTurleri();
                    frmAdresTUR.AdresTurleriDoldur();
                    KontrolEkle(frmAdresTUR, "panelAdresTurleri");
                    frmAdresTUR.Dispose();
                    break;

                case "frmKimlikVerilisNedenleri":
                    frmKimlikVerilisNedenleri frmKimlikVerilisNEDEN = new frmKimlikVerilisNedenleri();
                    frmKimlikVerilisNEDEN.kimlikVerilisNedenGetir();
                    KontrolEkle(frmKimlikVerilisNEDEN, "panelKimlikVerilisNedenleri");
                    frmKimlikVerilisNEDEN.Dispose();
                    break;

                case "frmRehinSicilTipleri":
                    frmRehinSicilTipleri frmRehinSicilTIP = new frmRehinSicilTipleri();
                    frmRehinSicilTIP.sicilTipGetir();
                    KontrolEkle(frmRehinSicilTIP, "panelRehinSicilTip");
                    frmRehinSicilTIP.Dispose();
                    break;

                case "frmDavaAnaTurKodlari":
                    frmDavaAnaTurKodlari frmDavaAnaTurKOD = new frmDavaAnaTurKodlari();
                    frmDavaAnaTurKOD.davaAnaTurGetir();
                    KontrolEkle(frmDavaAnaTurKOD, "panelDavaAnaturKodlar");
                    frmDavaAnaTurKOD.Dispose();
                    break;

                case "frmDavaOzelKodlari":
                    frmDavaOzelKodlari frmDavaOzelKOD = new frmDavaOzelKodlari();
                    frmDavaOzelKOD.davaOzelGetir();
                    KontrolEkle(frmDavaOzelKOD, "panelDavaOzelKodlar");
                    frmDavaOzelKOD.Dispose();
                    break;

                case "frmDavaAltTurKodlari":
                    frmDavaAltTurKodlari frmDavaAltTurKOD = new frmDavaAltTurKodlari();
                    frmDavaAltTurKOD.davaAltTurGetir();
                    KontrolEkle(frmDavaAltTurKOD, "panelDavaAltTurKodlar");
                    frmDavaAltTurKOD.Dispose();
                    break;
                default:
                    this.ContainerPanel.Visible = true;
                    break;
            }
        }

        private void FormCagirGridCet(CETTABLOADI adi)
        {
            switch (adi)
            {
                case CETTABLOADI.Gunluk_Doviz_Kur:
                    frmGunlukDovizKurlari frmDoviz = new frmGunlukDovizKurlari();
                    frmDoviz.gunlukDovizGetir();
                    KontrolEkle(frmDoviz, "panelDoviz");
                    frmDoviz.Dispose();
                    break;

                case CETTABLOADI.Gorevli_Mahkeme:
                    frmGorevliMahkemeBelirle frmGorevliMahkeme = new frmGorevliMahkemeBelirle();
                    frmGorevliMahkeme.gorevliMahkemeBelirGetir();
                    KontrolEkle(frmGorevliMahkeme, "panelGorevliMahkemeBelirle");
                    frmGorevliMahkeme.Dispose();
                    break;

                case CETTABLOADI.Dava_Harc_Maktu:
                    frmDavaMaktuHarcCetveli frmDavaMaktu = new frmDavaMaktuHarcCetveli();
                    frmDavaMaktu.maktuDavaHarcGetir();
                    KontrolEkle(frmDavaMaktu, "panelDavaMaktu");
                    frmDavaMaktu.Dispose();
                    break;

                case CETTABLOADI.Icra_Harc_Maktu:
                    frmDavaMaktuHarcCetveli frmIcraMaktu = new frmDavaMaktuHarcCetveli();
                    frmIcraMaktu.maktuIcraHarcGetir();
                    KontrolEkle(frmIcraMaktu, "panelDavaMaktu");
                    frmIcraMaktu.Dispose();
                    break;

                case CETTABLOADI.CetFaiz_Tarife:

                    //frmTopluFaizTarifeCetveliGuncelle frmFaizTarifeCetveli = new frmTopluFaizTarifeCetveliGuncelle();
                    //frmFaizTarifeCetveli.getFaizTarife(DateTime.Today);
                    //KontrolEkle(frmFaizTarifeCetveli, "panelFaizTarifeCetveli");
                    //frmFaizTarifeCetveli.Dispose();
                    frmFaizTarifeCetveli frmFaizTarifeCetveli = new frmFaizTarifeCetveli();
                    frmFaizTarifeCetveli.faizTarifeGetir();
                    KontrolEkle(frmFaizTarifeCetveli, "panelFaizTarifeCetveli");
                    frmFaizTarifeCetveli.Dispose();
                    break;

                case CETTABLOADI.Dava_Nispi_Harc:
                    frmDavaNispiHarcCetveli frmNispiHarc = new frmDavaNispiHarcCetveli();
                    frmNispiHarc.nispiHarcGetir();
                    KontrolEkle(frmNispiHarc, "panelDavaNispiHarcCetveli");
                    frmNispiHarc.Dispose();
                    break;

                case CETTABLOADI.Icra_Nispi_Harc:
                    frmDavaNispiHarcCetveli frmNispiHarcIcra = new frmDavaNispiHarcCetveli();
                    frmNispiHarcIcra.nispiHarcGetirIcra();
                    KontrolEkle(frmNispiHarcIcra, "panelDavaNispiHarcCetveli");
                    frmNispiHarcIcra.Dispose();
                    break;

                case CETTABLOADI.Evrak_Gider:
                    frmEvrakGiderCetveli frmEvrakGider = new frmEvrakGiderCetveli();
                    frmEvrakGider.evrakGiderCetvelGetir();
                    KontrolEkle(frmEvrakGider, "panelEvrakGiderCetvel");
                    frmEvrakGider.Dispose();
                    break;

                case CETTABLOADI.Gelir_Vergisi:
                    frmGelirVergisi frmGelirVergisi = new frmGelirVergisi();
                    frmGelirVergisi.foyYeriDoldur();
                    KontrolEkle(frmGelirVergisi, "panelVergiOran");
                    frmGelirVergisi.Dispose();
                    break;

                case CETTABLOADI.Kdv:
                    frmKDVCetveli frmKDV = new frmKDVCetveli();
                    frmKDV.kdvCetveliGetir();
                    KontrolEkle(frmKDV, "panelKDVCetvel");
                    frmKDV.Dispose();
                    break;

                case CETTABLOADI.Memur_Yevmiye:
                    frmMemurYevmiye frmMemur = new frmMemurYevmiye();
                    frmMemur.memurYevmiyeGetir();
                    KontrolEkle(frmMemur, "panelAdliBirimNumara");
                    frmMemur.Dispose();
                    break;

                case CETTABLOADI.Posta_Gider:
                    frmGiderCetveli frmPostaGider = new frmGiderCetveli();
                    frmPostaGider.giderCetveliGetir();
                    KontrolEkle(frmPostaGider, "panelPostaGider");
                    frmPostaGider.Dispose();
                    break;

                case CETTABLOADI.MinMax_Degeri:
                    frmMinMaxDegerCetveli frmMinMax = new frmMinMaxDegerCetveli();
                    frmMinMax.minMaxDegerGetir();
                    KontrolEkle(frmMinMax, "panelMinMaxDeger");
                    frmMinMax.Dispose();
                    break;

                case CETTABLOADI.Teminat_Tazminat:
                    frmTeminatTazminat frmTemTaz = new frmTeminatTazminat();
                    frmTemTaz.teminatTazminatGetir();
                    KontrolEkle(frmTemTaz, "panelTeminatTazminat");
                    frmTemTaz.Dispose();
                    break;

                case CETTABLOADI.Maktu_Vekalet:
                    frmVekaletMaktuCetveli frmVekaletMaktu = new frmVekaletMaktuCetveli();
                    frmVekaletMaktu.vekaletMaktuGetir();
                    KontrolEkle(frmVekaletMaktu, "panelVekaletMaktu");
                    frmVekaletMaktu.Dispose();
                    break;

                case CETTABLOADI.Yuvarlama_Deger:
                    frmYuvarlamaCetveli frmYuvarla = new frmYuvarlamaCetveli();
                    frmYuvarla.yuvarlamaCetvelGetir();
                    KontrolEkle(frmYuvarla, "panelYuvarlamaCetveli");
                    frmYuvarla.Dispose();
                    break;

                case CETTABLOADI.Yediemin_Maktu_Ucret:
                    frmYediEminUcretiMaktu frmYeddiEmin = new frmYediEminUcretiMaktu();
                    frmYeddiEmin.yeddiMaktuUcretDoldur();
                    KontrolEkle(frmYeddiEmin, "panelYeddiEmin");
                    frmYeddiEmin.Dispose();
                    break;

                case CETTABLOADI.Yediemin_Nispi_Ucret:
                    frmYediEminUcretiNispi frmNispiYeddiEmin = new frmYediEminUcretiNispi();
                    frmNispiYeddiEmin.yeddiNispiDoldur();
                    KontrolEkle(frmNispiYeddiEmin, "panelNispiYeddiEmin");
                    frmNispiYeddiEmin.Dispose();
                    break;

                case CETTABLOADI.Vekalet_Nispi:
                    frmVekaletNispiCetveli frmVekaletNispi = new frmVekaletNispiCetveli();
                    frmVekaletNispi.vekaletNispiGetir();
                    KontrolEkle(frmVekaletNispi, "panelVekaletNispiUcreti");
                    frmVekaletNispi.Dispose();
                    break;

                case CETTABLOADI.Diger_Vergi:
                    frmDigerVergiOranlari frmDigerVergi = new frmDigerVergiOranlari();
                    frmDigerVergi.digerVergiOranGetir();
                    KontrolEkle(frmDigerVergi, "panelDigerVergiOranlari");
                    frmDigerVergi.Dispose();
                    break;

                case CETTABLOADI.Police_Teminat_Tutar:
                    frmTeminatTurKodlari frmTeminatTur = new frmTeminatTurKodlari();
                    frmTeminatTur.teminatTurKodGetir();
                    KontrolEkle(frmTeminatTur, "panelTeminatTurKodlari");
                    frmTeminatTur.Dispose();
                    break;

                case CETTABLOADI.Merkez_Dosya_Atama:
                    frmDosyaYerleri frmDosyaYeri = new frmDosyaYerleri();
                    frmDosyaYeri.foyYeriDoldur();
                    KontrolEkle(frmDosyaYeri, "panelDosyaYerleri");
                    frmDosyaYeri.Dispose();
                    break;

                case CETTABLOADI.Icra_Vergi_Oran:
                    frmVergiOran frmVergiOran = new frmVergiOran();
                    frmVergiOran.foyYeriDoldur();
                    KontrolEkle(frmVergiOran, "panelVergiOran");
                    frmVergiOran.Dispose();
                    break;
                default:
                    this.ContainerPanel.Visible = true;
                    break;
            }
        }

        private void FormCagirGridKod(KODTABLOADI adi)
        {
            switch (adi)
            {
                case KODTABLOADI.AdresDurum:
                    frmAdresDurum frmAdresDURUM = new frmAdresDurum();
                    frmAdresDURUM.AdresDurumlariDoldur();
                    KontrolEkle(frmAdresDURUM, "panelAdresDurumlari");
                    frmAdresDURUM.Dispose();
                    break;

                case KODTABLOADI.AdresTur:
                    frmAdresTurleri frmAdresTUR = new frmAdresTurleri();
                    frmAdresTUR.AdresTurleriDoldur();
                    KontrolEkle(frmAdresTUR, "panelAdresTurleri");
                    frmAdresTUR.Dispose();
                    break;

                case KODTABLOADI.Banka:
                    frmBankaAdlari frmBanka = new frmBankaAdlari();
                    frmBanka.BankaGetir();
                    KontrolEkle(frmBanka, "panelBankaAdlari");
                    frmBanka.Dispose();
                    break;

                case KODTABLOADI.BankaBolge:
                    frmBankaBolgeKodlari frmBankaBolgeKODLAR = new frmBankaBolgeKodlari();
                    frmBankaBolgeKODLAR.bankaBolgeGetir();
                    KontrolEkle(frmBankaBolgeKODLAR, "panelBankaBolgeKodlar");
                    frmBankaBolgeKODLAR.Dispose();
                    break;

                case KODTABLOADI.BankaSube:
                    frmBankaSubeKodlari frmBankaSubeKODLAR = new frmBankaSubeKodlari();
                    frmBankaSubeKODLAR.bankaSubeGetir();
                    KontrolEkle(frmBankaSubeKODLAR, "panelBankaSubeKodlari");
                    frmBankaSubeKODLAR.Dispose();
                    break;

                case KODTABLOADI.Belediye:
                    frmKodBelediyeBilgileri frmBelediye = new frmKodBelediyeBilgileri();
                    frmBelediye.bankaSubeGetir();
                    KontrolEkle(frmBelediye, "panelBelediye");
                    frmBelediye.Dispose();
                    break;

                case KODTABLOADI.BelgeOzelKod:
                    frmBelgeOzelKodlari frmBelgeOzel = new frmBelgeOzelKodlari();
                    frmBelgeOzel.belgeOzelKodGetir();
                    KontrolEkle(frmBelgeOzel, "panelBelgeOzelKodlar");
                    frmBelgeOzel.Dispose();
                    break;

                case KODTABLOADI.Bölge:
                    frmBankaBolgeKodlari frmBankaBolge = new frmBankaBolgeKodlari();
                    frmBankaBolge.bankaBolgeGetir();
                    KontrolEkle(frmBankaBolge, "panelBankaBolgeKodlar");
                    frmBankaBolge.Dispose();
                    break;

                case KODTABLOADI.CariOzel:
                    frmOzelCariKodlari frmCariOzel = new frmOzelCariKodlari();
                    frmCariOzel.cariOzelKodGetir();
                    KontrolEkle(frmCariOzel, "panelCariOzelKodlar");
                    frmCariOzel.Dispose();
                    break;

                case KODTABLOADI.DavaNispiHarc:
                    break;

                case KODTABLOADI.DavaOzelKod:
                    frmDavaOzelKodlari frmDavaOzelKOD = new frmDavaOzelKodlari();
                    frmDavaOzelKOD.davaOzelGetir();
                    KontrolEkle(frmDavaOzelKOD, "panelDavaOzelKodlar");
                    frmDavaOzelKOD.Dispose();
                    break;

                case KODTABLOADI.DavaOzellik:
                    frmDavaOzellikKodlari frmDavaOzellikKODLAR = new frmDavaOzellikKodlari();
                    frmDavaOzellikKODLAR.davaOzellikGetir();
                    KontrolEkle(frmDavaOzellikKODLAR, "panelDavaOzellikKodlar");
                    frmDavaOzellikKODLAR.Dispose();
                    break;

                case KODTABLOADI.DavaSonuc:
                    frmDavaSonucKodlari frmDavaSonucKODLAR = new frmDavaSonucKodlari();
                    frmDavaSonucKODLAR.DavaSonucDoldur();
                    KontrolEkle(frmDavaSonucKODLAR, "");
                    frmDavaSonucKODLAR.Dispose();
                    break;

                case KODTABLOADI.DusmeDegismeKodu:
                    frmDusmeDegismeKodlari frmDusmeDegismeKODLAR = new frmDusmeDegismeKodlari();
                    frmDusmeDegismeKODLAR.DusmeDegistirmeDoldur();
                    KontrolEkle(frmDusmeDegismeKODLAR, "panelDusmeDegistirme");
                    frmDusmeDegismeKODLAR.Dispose();
                    break;

                case KODTABLOADI.DavaGelismeAdim:
                    frmDavaGelismeKodlari frmDavaGelisme = new frmDavaGelismeKodlari();
                    frmDavaGelisme.gelismeAdimGetir();
                    KontrolEkle(frmDavaGelisme, "panelDavaGelismeKadlar");
                    frmDavaGelisme.Dispose();
                    break;

                case KODTABLOADI.HarcNispi:
                    break;

                case KODTABLOADI.IadeNeden:
                    frmFoyIadeNedenKodlari frmFoyIadeNeden = new frmFoyIadeNedenKodlari();
                    frmFoyIadeNeden.foyIadeNedenGetir();
                    KontrolEkle(frmFoyIadeNeden, "panelDosyaIadeNedenKodlar");
                    frmFoyIadeNeden.Dispose();
                    break;

                case KODTABLOADI.IcraGelismeAdim:
                    frmIcraGelismeKodlari frmIcraGelisme = new frmIcraGelismeKodlari();
                    frmIcraGelisme.foyGelismeAdimGetir();
                    KontrolEkle(frmIcraGelisme, "panelIcraGelismeKodlari");
                    frmIcraGelisme.Dispose();
                    break;

                case KODTABLOADI.IL:
                    frmIlKodlari frmIlKod = new frmIlKodlari();
                    frmIlKod.ilKodGetir();
                    KontrolEkle(frmIlKod, "panelIlKodlari");
                    frmIlKod.Dispose();
                    break;

                case KODTABLOADI.ILCE:
                    frmIlceKodlari frmIlceKOD = new frmIlceKodlari();
                    frmIlceKOD.ilceKodGetir();
                    KontrolEkle(frmIlceKOD, "panelIlceKodlari");
                    frmIlceKOD.Dispose();
                    break;

                case KODTABLOADI.IletisimAltKategori:
                    frmIletisimAltKategoriEkle frmIletýsimAlt = new frmIletisimAltKategoriEkle();
                    frmIletýsimAlt.iletisimAltKodGetir();
                    KontrolEkle(frmIletýsimAlt, "panelIletisimAltKategori");
                    frmIletýsimAlt.Dispose();
                    break;

                case KODTABLOADI.IletisimAnaKategori:
                    frmIletisimAnaKategoriEkle frmIletýsimAna = new frmIletisimAnaKategoriEkle();
                    frmIletýsimAna.iletisimAnaKodGetir();
                    KontrolEkle(frmIletýsimAna, "panelIletisimAnaKategori");
                    frmIletýsimAna.Dispose();
                    break;

                case KODTABLOADI.KlasorKod:
                    frmKlasorKodlari frmKlasorKOD = new frmKlasorKodlari();
                    frmKlasorKOD.klasorKodGetir();
                    KontrolEkle(frmKlasorKOD, "panelKlosorKodlar");
                    break;

                case KODTABLOADI.KlasorOzelKod:
                    break;

                case KODTABLOADI.KrediGrup:
                    frmFoyKrediGruplari frmKrediGrupKOD = new frmFoyKrediGruplari();
                    frmKrediGrupKOD.krediGrupGetir();
                    KontrolEkle(frmKrediGrupKOD, "panelDosyaKrediGrup");
                    frmKrediGrupKOD.Dispose();
                    break;

                case KODTABLOADI.KrediTip:
                    frmFoyKrediTipleri frmKrediTipKOD = new frmFoyKrediTipleri();
                    frmKrediTipKOD.krediTipGetir();
                    KontrolEkle(frmKrediTipKOD, "panelDosyaKrediTipleri");
                    frmKrediTipKOD.Dispose();
                    break;

                case KODTABLOADI.MalCins:
                    frmMalCinsKodlari frmMalCins = new frmMalCinsKodlari();
                    frmMalCins.malCinsGetir();
                    KontrolEkle(frmMalCins, "panelMalCinsKodlar");
                    frmMalCins.Dispose();
                    break;

                case KODTABLOADI.MalKategori:
                    frmMalKategoriKodlari frmMalKategori = new frmMalKategoriKodlari();
                    frmMalKategori.malKatKodGetir();
                    KontrolEkle(frmMalKategori, "panelMalKategoriKodlar");
                    frmMalKategori.Dispose();
                    break;

                case KODTABLOADI.MalTur:
                    frmMalTurKodlari frmMalTurKodlar = new frmMalTurKodlari();
                    frmMalTurKodlar.malTurKodGetir();
                    KontrolEkle(frmMalTurKodlar, "panelMalTurKodlar");
                    frmMalTurKodlar.Dispose();
                    break;

                case KODTABLOADI.MarkaTip:
                    frmMarkaTipKodlari frmMarkaTip = new frmMarkaTipKodlari();
                    frmMarkaTip.MarkaTipiDoldur();
                    KontrolEkle(frmMarkaTip, "panelMarkaTip");
                    frmMarkaTip.Dispose();
                    break;

                case KODTABLOADI.Meslek:
                    frmMeslekKodlari frmMeslekKOD = new frmMeslekKodlari();
                    frmMeslekKOD.meslekKodGetir();
                    KontrolEkle(frmMeslekKOD, "panelMeslekKodlari");
                    frmMeslekKOD.Dispose();
                    break;

                case KODTABLOADI.MuhasebeAltKategori:
                    frmMuhasebeAltKategoriEkle frmMuhasebeAltKategori = new frmMuhasebeAltKategoriEkle();
                    frmMuhasebeAltKategori.muhAltKatKodGetir();
                    KontrolEkle(frmMuhasebeAltKategori, "panelMuhasebeAltKategorileri");
                    frmMuhasebeAltKategori.Dispose();
                    break;

                case KODTABLOADI.MuhasebeAnaKategori:
                    frmMuhasebeAnaKategoriEkle frmMuhasebeAnaKategori = new frmMuhasebeAnaKategoriEkle();
                    frmMuhasebeAnaKategori.muhAnaKatKodGetir();
                    KontrolEkle(frmMuhasebeAnaKategori, "panelMuhasebeanaKategorileri");
                    frmMuhasebeAnaKategori.Dispose();
                    break;

                case KODTABLOADI.OtomatikDuzelt:
                    frmOtomatikDuzelt frmOtomatikDegýstýr = new frmOtomatikDuzelt();
                    frmOtomatikDegýstýr.OtomatikDuzeltDoldur();
                    KontrolEkle(frmOtomatikDegýstýr, "panelOtomatikDuzelt");
                    frmOtomatikDegýstýr.Dispose();
                    break;

                case KODTABLOADI.OzelKod:
                    frmOrtakOzelKodlar frm = new frmOrtakOzelKodlar();
                    frm.OzelKodGetir();
                    KontrolEkle(frm, "pnlOrtakOzelKodlar");
                    frm.Dispose();
                    break;

                case KODTABLOADI.OzelTutarKonu:
                    frmOzelTutarKonulari frmOzelTutar = new frmOzelTutarKonulari();
                    frmOzelTutar.ozelTutarKonuGetir();
                    KontrolEkle(frmOzelTutar, "panelOzelTutarKonular");
                    frmOzelTutar.Dispose();
                    break;

                case KODTABLOADI.SahisDurum:
                    break;

                case KODTABLOADI.Sektor:
                    frmSektor frmSektorler = new frmSektor();
                    frmSektorler.sektorGetir();
                    KontrolEkle(frmSektorler, "panelSektor");
                    frmSektorler.Dispose();
                    break;

                case KODTABLOADI.Semt:
                    frmSemtKodlari frmSemt = new frmSemtKodlari();
                    frmSemt.semtKodGetir();
                    KontrolEkle(frmSemt, "panelSemtKodlar");
                    frmSemt.Dispose();
                    break;

                case KODTABLOADI.SikayetNeden:
                    frmSikayetNedenKodlari frmSikayetNedenKod = new frmSikayetNedenKodlari();
                    frmSikayetNedenKod.sikayetNedenGetir();
                    KontrolEkle(frmSikayetNedenKod, "panelSikayetNEdenKodlarý");
                    frmSikayetNedenKod.Dispose();
                    break;

                case KODTABLOADI.SozlesmeAltTip:
                    frmSozlesmeAltTip frmSozlesmeAltTIP = new frmSozlesmeAltTip();
                    frmSozlesmeAltTIP.sozlesmeAltTipGetir();
                    KontrolEkle(frmSozlesmeAltTIP, "panelSozlesmeAlttipleri");
                    frmSozlesmeAltTIP.Dispose();
                    break;

                case KODTABLOADI.Sozluk:
                    frmSozluk frmSozlukler = new frmSozluk();
                    frmSozlukler.sozlukGetir();
                    KontrolEkle(frmSozlukler, "panelSozluk");
                    frmSozlukler.Dispose();
                    break;

                case KODTABLOADI.TahsilDurum:
                    frmTahsilDurumKodlari frmTahsilDurumKOD = new frmTahsilDurumKodlari();
                    frmTahsilDurumKOD.tahsilatDurumGetir();
                    KontrolEkle(frmTahsilDurumKOD, "panelTahsilDurumKodlar");
                    frmTahsilDurumKOD.Dispose();
                    break;

                case KODTABLOADI.TakipTalepMaktuHarc:
                    break;

                case KODTABLOADI.TakipTalepNispiHarc:
                    break;

                case KODTABLOADI.TapuMudurluk:
                    frmKodTapuMudurlukBilgileri frmTapu = new frmKodTapuMudurlukBilgileri();
                    frmTapu.bankaSubeGetir();
                    KontrolEkle(frmTapu, "panelBelediye");
                    frmTapu.Dispose();
                    break;

                case KODTABLOADI.TarafOzelDurum:
                    break;

                case KODTABLOADI.TespitHarc:
                    break;

                case KODTABLOADI.Ulke:
                    frmUlkeKodlari ulkem = new frmUlkeKodlari();
                    ulkem.ulkeKodlarGetir();
                    KontrolEkle(ulkem, "panelUlkeKodlar");
                    ulkem.Dispose();
                    break;

                case KODTABLOADI.Unvan:
                    frmUnvanKodlari unvanTur = new frmUnvanKodlari();
                    unvanTur.unvanKodGetir();
                    KontrolEkle(unvanTur, "panelUnvanKodlar");
                    unvanTur.Dispose();
                    break;

                case KODTABLOADI.UrunAltKategori:
                    break;

                case KODTABLOADI.UrunKategori:
                    break;

                case KODTABLOADI.UrunSýnýfKodlarý:
                    break;

                case KODTABLOADI.Vergi:
                    break;

                case KODTABLOADI.YayýnTur:
                    frmYayinTurleri yayinTur = new frmYayinTurleri();
                    yayinTur.yayinTurlertiGetir();
                    KontrolEkle(yayinTur, "panelYayinTurleri");
                    yayinTur.Dispose();
                    break;

                case KODTABLOADI.Yazar:
                    frmYazar frmYazarlar = new frmYazar();
                    frmYazarlar.yazarDoldur();
                    KontrolEkle(frmYazarlar, "panelYazarlar");
                    frmYazarlar.Dispose();
                    break;

                case KODTABLOADI.YazismaTip:
                    break;

                case KODTABLOADI.YazismaTur:
                    frmYazismaTurKodlari yazismaTur = new frmYazismaTurKodlari();
                    yazismaTur.yazismaTurGetir();
                    KontrolEkle(yazismaTur, "panelYazismaTurKodlar");
                    yazismaTur.Dispose();
                    break;

                case KODTABLOADI.AraKararTip:
                    frmAraKararTip araKararTIP = new frmAraKararTip();
                    araKararTIP.AraKararDoldur();
                    KontrolEkle(araKararTIP, "panelAraKarar");
                    araKararTIP.Dispose();
                    break;

                case KODTABLOADI.BasýmEvi:
                    frmBasimEvi basimEvi = new frmBasimEvi();
                    basimEvi.BasimEviDoldur();
                    KontrolEkle(basimEvi, "panelBasimEvi");
                    basimEvi.Dispose();
                    break;
                case KODTABLOADI.ProjeSubeKodlarý:
                    frmProjeSubeKodlari ProjeSu = new frmProjeSubeKodlari();
                    ProjeSu.Doldur();
                    KontrolEkle(ProjeSu, "panelProjeSube");
                    ProjeSu.Dispose();
                    break;
            }
        }

        private void frmCetvel_Load(object sender, EventArgs e)
        {
            barMenu.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Expanded;
            ContainerPanel.Visible = true;
            CetvelGetirGrid();
        }

        private void KontrolEkle(Form frm, string panelAdi)
        {
            try
            {
                foreach (Control c in frm.Controls)
                {
                    if (c.Name == panelAdi)
                    {
                        this.ContainerPanel.Panel2.Controls.Clear();
                        this.ContainerPanel.Panel2.Controls.Add(c);
                        c.Dock = DockStyle.Fill;
                        ContainerPanel.Visible = true;
                    }
                }
            }
            catch { }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string isim = gridView1.FocusedValue.ToString().Replace(' ', '_');
            if (gridView1.Tag == "CET")
            {
                CETTABLOADI tablo = (CETTABLOADI)Enum.Parse(typeof(CETTABLOADI), isim);
                FormCagirGridCet(tablo);
            }
            else if (gridView1.Tag == "KOD")
            {
                KODTABLOADI tabloKod = (KODTABLOADI)Enum.Parse(typeof(KODTABLOADI), isim);
                FormCagirGridKod(tabloKod);
            }
        }

        private void SabitGetirGrid()
        {
            DataTable dt = new DataTable("YetkiKullanmaTipi");
            dt.Columns.Add("ACIKLAMA");
            gridView1.Tag = "KOD";
            foreach (AvukatProLib.Extras.KODTABLOADI tipi in Enum.GetValues(typeof(AvukatProLib.Extras.KODTABLOADI)))
            {
                dt.Rows.Add(tipi.ToString());
            }
            gridMenu.DataSource = dt;
            gridColumn1.FieldName = "ACIKLAMA";
        }

        private void sabitler_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            barMenu.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Expanded;
            SabitGetirGrid();
        }

        private void treeListMenu_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                FormCagir(e.Node.GetValue(2).ToString());
            }
        }
    }
}