using AvukatProLib.Bakim.Claslar;
using AvukatProLib.Bakim.Resources;
using AvukatProLib.Extras;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security.Principal;
using System.Windows.Forms;

namespace AvukatProLib.Bakim
{
    public partial class frmVeriTabaniSunucuIslemleri : DevExpress.XtraEditors.XtraForm
    {
        public frmVeriTabaniSunucuIslemleri()
        {
            InitializeComponent(); ;
        }

        private List<CompInfo> clist = null;

        private string domainname;

        private bool sifreAcik = false;

        OzelKodReferans.DavaOzelKodReferans davarefoz;
        OzelKodReferans.IcraOzelKodReferans icrarefoz;
        OzelKodReferans.SorusturmaOzelKodReferans sorusturmarefoz;
        OzelKodReferans.SozlesmeOzelKodReferans sozlezmerefoz;
        OzelKodReferans.OrtakOzelKodReferans ortakrefoz;

        public void btnKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmIntro.IsGenel)
            {
                foreach (var item in clist)
                {
                    if (item.LisansBilgisi == null)
                    {
                        item.LisansBilgisi = new AvukatProLib.AVPLicence.LisansBilgisi();
                        item.LisansBilgisi.AdSoyad = "Bakým Genel";
                        item.LisansBilgisi.PaketAdi = "*";
                        item.LisansBilgisi.ProductKey = "7C831EDD-96AA-48F4-8231-5D44C98E1577";
                    }
                }
            }
            bool b = CompInfo.Kaydet(clist);
            OzelKodReferans.OzelKodReferans.Kaydet(clist[0].ConStr);
            if (b)
            {
                XtraMessageBox.Show("Kaydetme Ýþleminiz baþarýyla Gerçekleþmiþtir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Kayýt Ýþlmenide Bir Hata Oluþmuþtur", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public string getDomain()
        {
            return WindowsIdentity.GetCurrent().Name;
        }

        private void btnFolder_Click(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog() { ShowNewFolderButton = true, Description = "Uygulama güncellemeleri için yedekleme klasörü seçin." })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    (sender as DevExpress.XtraEditors.ButtonEdit).EditValue = dialog.SelectedPath;
                }
            }
        }

        private void dtNSunucuIslemleri_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "Sifre")
            {
                if (!sifreAcik)
                {
                    txtVeriTabaniSfr.PasswordChar = new char();
                    sifreAcik = true;
                }
                else
                {
                    txtVeriTabaniSfr.PasswordChar = '*';
                    sifreAcik = false;
                }
            }
        }

        private void frmVeriTabaniSunucuIslemleri_Load(object sender, EventArgs e)
        {
            clist = CompInfo.CompInfoListGetir();

            sunucuIslemleriBindingSource.DataSource = clist;

            //clist = CompInfo.CompInfoListGetir();
            sunucuIslemleriBindingSource.AddingNew += sunucuIslemleriBindingSource_AddingNew;
            rlkKurumsalMod.DataSource = KurumsalMod.KurumsalModGetir();
            Inits.BaglantiTipiGetir(lueBaglantiTipi);
            Inits.OturumAcmaTipiGetir(rLueOturumAcmaModu);

            List<UygulamaTipleri> uTipler = new List<UygulamaTipleri>();
            uTipler.Add(new UygulamaTipleri("Server", 0));
            uTipler.Add(new UygulamaTipleri("Client", 1));
            rLueUygulamaTipi.DataSource = uTipler;

            List<HatirlatmaBilgileri> hTipler = new List<HatirlatmaBilgileri>();
            hTipler.Add(new HatirlatmaBilgileri());
            hTipler.Add(new HatirlatmaBilgileri("Ekran", 1));
            hTipler.Add(new HatirlatmaBilgileri("E-Mail", 2));
            hTipler.Add(new HatirlatmaBilgileri("SMS", 3));
            hTipler.Add(new HatirlatmaBilgileri("Ekran, E-Mail", 4));
            hTipler.Add(new HatirlatmaBilgileri("Ekran, SMS", 5));
            hTipler.Add(new HatirlatmaBilgileri("E-Mail, SMS", 6));
            hTipler.Add(new HatirlatmaBilgileri("Ekran, E-Mail, SMS", 7));
            rLueHatirlatmaBilgisi.DataSource = hTipler;

            Inits.ConnectionTipGetir(rlueConnectionTip);
            dtNSunucuIslemleri.DataSource = sunucuIslemleriBindingSource;

            CompInfo cmp = sunucuIslemleriBindingSource.Current as CompInfo;
            davarefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetDavaOzelKodReferans(cmp.ConStr);
            icrarefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetIcraOzelKodReferans(cmp.ConStr);
            sorusturmarefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetSorusturmaOzelKodReferans(cmp.ConStr);
            sozlezmerefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetSozlesmeOzelKodReferans(cmp.ConStr);
            ortakrefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetOrtakOzelKodReferans(cmp.ConStr);
            //aV001TDIBILCARIBindingSource.DataSource = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetAll();
            lueBaglantiTipi.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(lueBaglantiTipi_EditValueChanging);
        }

        private void grdControlSunucuIslemleri_CustomUnboundData(object sender, CustomDataEventArgs e)
        {
            if (e.IsSetData && e.Row == rowKurumsalMod)
            {
                CompInfo cmp = sunucuIslemleriBindingSource.Current as CompInfo;
                if (cmp != null)
                {
                    KurumsalMod km = e.Value as KurumsalMod;

                    //// cmp.IcraAnReferans_Referans1 = km.IcraAnReferans;
                    //cmp.IcraOzelDurum = km.IcraOzelDurum;

                    ////cmp.DavaDnReferans_Referans1 = km.DavaDnReferans;
                    ////cmp.DavaOzelKod_OzelKod1 = km.DavaOzelKod;
                    ////cmp.IcraOzelKod_OzelKod1 = km.IcraOzelKod;
                    ////cmp.IcraReferans_Referans1 = km.IcraReferans;
                    ////cmp.DavaReferans_Referans1 = km.DavaReferans;
                    //cmp.OrtakOzelDurum = km.OrtakOzelDurum;

                    ////cmp.SorusturmaOzelKod_OzelKod1 = km.SorusturmaOzelKod;
                    ////cmp.SozlesmeReferans_Referans1 = km.SorusturmaReferans;
                    ////cmp.SozlesmeOzelKod_OzelKod1 = km.SozlesmeOzelKod;
                    ////cmp.SozlesmeReferans_Referans1 = km.SozlesmeReferans;
                    cmp.KurumsalMod = km.ModNo;
                }
            }
            else if (e.IsGetData && e.Row == rowKurumsalMod)
            {
                CompInfo cmp = sunucuIslemleriBindingSource.Current as CompInfo;
                //if (cmp != null)
                //{
                //    e.Value = cmp.KurumsalMod;
                //}
            }

            if (e.IsSetData && e.Row == rowPaket)
            {
                CompInfo cmp = sunucuIslemleriBindingSource.Current as CompInfo;
                if (cmp != null)
                {
                    try
                    {
                       
                    }
                    catch { }
                }
            }
            else if (e.IsGetData && e.Row == rowPaket)
            {
                CompInfo cmp = sunucuIslemleriBindingSource.Current as CompInfo;
                if (cmp != null)
                {
                    e.Value = cmp.LisansBilgisi == null || string.IsNullOrEmpty(cmp.LisansBilgisi.PaketAdi) ? "*" : cmp.LisansBilgisi.PaketAdi;
                }
            }
        }

        private void lueBaglantiTipi_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            int i = Convert.ToInt32(e.NewValue);

            if (i == (int)BaglantiTipi.VeriTabani)
            {
                crowUygulamaSunucusu.Visible = false;
                crowVeriTabani.Visible = true;
            }
            else if (i == (int)BaglantiTipi.WebServices)
            {
                crowVeriTabani.Visible = false;
                crowUygulamaSunucusu.Visible = true;
            }
        }

        private void rcbUygulamaProxyKullan_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit chk = sender as CheckEdit;

            if ((bool)chk.Properties.ValueChecked)
            {
                crowProxyBilgileri.Expanded = true;
            }
            else
            {
                crowProxyBilgileri.Expanded = false;
            }
        }

        private void rlkKurumsalMod_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            CompInfo cmp = sunucuIslemleriBindingSource.Current as CompInfo;
            KurumsalMod kurumsal = (KurumsalMod)e.NewValue;
            OzellestirmeBelediye belediye = new OzellestirmeBelediye();
            OzellestirmeSigorta sigorta = new OzellestirmeSigorta();
            OzellestirmeBanka bankacilik = new OzellestirmeBanka();


            //banka
            if (((KurumsalMod)e.NewValue).ModNo == 1501)
            {
                kurumsal.DavaDnReferans_Referans1 = bankacilik.Referans1DavaDn;
                kurumsal.DavaDnReferans_Referans2 = bankacilik.Referans2DavaDn;
                kurumsal.DavaDnReferans_Referans3 = bankacilik.Referans3DavaDn;

                kurumsal.DavaReferans_Referans1 = bankacilik.Referans1Dava;
                kurumsal.DavaReferans_Referans2 = bankacilik.Referans2Dava;
                kurumsal.DavaReferans_Referans3 = bankacilik.Referans3Dava;

                kurumsal.DavaOzelKod_OzelKod1 = bankacilik.OzelKod1Dava;
                kurumsal.DavaOzelKod_OzelKod2 = bankacilik.OzelKod2Dava;
                kurumsal.DavaOzelKod_OzelKod3 = bankacilik.OzelKod3Dava;
                kurumsal.DavaOzelKod_OzelKod4 = bankacilik.OzelKod4Dava;

                kurumsal.IcraAnReferans_Referans1 = bankacilik.Referans1IcraAn;
                kurumsal.IcraAnReferans_Referans2 = bankacilik.Referans2IcraAn;
                kurumsal.IcraAnReferans_Referans3 = bankacilik.Referans3IcraAn;

                kurumsal.IcraOzelDurum_Banka = bankacilik.BankaIcra;
                kurumsal.IcraOzelDurum_FoyBirim = bankacilik.FoyBirimIcra;
                kurumsal.IcraOzelDurum_FoyYeri = bankacilik.FoyYeriIcra;
                kurumsal.IcraOzelDurum_Klasor1 = bankacilik.Klasor1Icra;
                kurumsal.IcraOzelDurum_Klasor2 = bankacilik.Klasor2Icra;
                kurumsal.IcraOzelDurum_KrediGrup = bankacilik.KrediGrupIcra;
                kurumsal.IcraOzelDurum_KrediTip = bankacilik.KrediTipIcra;
                kurumsal.IcraOzelDurum_Ozel = bankacilik.OzelIcra;
                kurumsal.IcraOzelDurum_Sube = bankacilik.SubeIcra;
                kurumsal.IcraOzelDurum_Tahsilat = bankacilik.TahsilatIcra;

                kurumsal.IcraOzelKod_OzelKod1 = bankacilik.OzelKod1Icra;
                kurumsal.IcraOzelKod_OzelKod2 = bankacilik.OzelKod2Icra;
                kurumsal.IcraOzelKod_OzelKod3 = bankacilik.OzelKod3Icra;
                kurumsal.IcraOzelKod_OzelKod4 = bankacilik.OzelKod4Icra;

                kurumsal.IcraReferans_Referans1 = bankacilik.Referans1Icra;
                kurumsal.IcraReferans_Referans2 = bankacilik.Referans2Icra;
                kurumsal.IcraReferans_Referans3 = bankacilik.Referans3Icra;

                kurumsal.OrtakOzelDurum_Banka = bankacilik.BankaOrtak;
                kurumsal.OrtakOzelDurum_FoyBirim = bankacilik.FoyBirimIcra;
                kurumsal.OrtakOzelDurum_FoyYeri = bankacilik.FoyYeriIcra;
                kurumsal.OrtakOzelDurum_Klasor1 = bankacilik.Klasor1Icra;
                kurumsal.OrtakOzelDurum_Klasor2 = bankacilik.Klasor2Icra;
                kurumsal.OrtakOzelDurum_KrediGrup = bankacilik.KrediGrupIcra;
                kurumsal.OrtakOzelDurum_KrediTip = bankacilik.KrediTipIcra;
                kurumsal.OrtakOzelDurum_Ozel = bankacilik.OzelIcra;
                kurumsal.OrtakOzelDurum_Sube = bankacilik.SubeIcra;
                kurumsal.OrtakOzelDurum_Tahsilat = bankacilik.TahsilatIcra;

                kurumsal.SorusturmaOzelKod_OzelKod1 = bankacilik.OzelKod1Sorusturma;
                kurumsal.SorusturmaOzelKod_OzelKod2 = bankacilik.OzelKod2Sorusturma;
                kurumsal.SorusturmaOzelKod_OzelKod3 = bankacilik.OzelKod3Sorusturma;
                kurumsal.SorusturmaOzelKod_OzelKod4 = bankacilik.OzelKod4Sorusturma;

                kurumsal.SorusturmaReferans_Referans1 = bankacilik.Referans1Sorusturma;
                kurumsal.SorusturmaReferans_Referans2 = bankacilik.Referans2Sorusturma;
                kurumsal.SorusturmaReferans_Referans3 = bankacilik.Referans3Sorusturma;

                kurumsal.SozlesmeOzelKod_OzelKod1 = bankacilik.OzelKod1Sozlesme;
                kurumsal.SozlesmeOzelKod_OzelKod2 = bankacilik.OzelKod2Sozlesme;
                kurumsal.SozlesmeOzelKod_OzelKod3 = bankacilik.OzelKod3Sozlesme;
                kurumsal.SozlesmeOzelKod_OzelKod4 = bankacilik.OzelKod4Sozlesme;

                kurumsal.SozlesmeReferans_Referans1 = bankacilik.Referans1Sozlesme;
                kurumsal.SozlesmeReferans_Referans2 = bankacilik.Referans2Sozlesme;
                kurumsal.SozlesmeReferans_Referans3 = bankacilik.Referans3Sozlesme;

                //------------------------
                davarefoz.DavaNedenReferans1 = bankacilik.Referans1DavaDn;
                davarefoz.DavaNedenReferans2 = bankacilik.Referans2DavaDn;
                davarefoz.DavaNedenReferans3 = bankacilik.Referans3DavaDn;

                davarefoz.DavaReferans1 = bankacilik.Referans1Dava;
                davarefoz.DavaReferans2 = bankacilik.Referans2Dava;
                davarefoz.DavaReferans3 = bankacilik.Referans3Dava;

                davarefoz.DavaOzelKod1 = bankacilik.OzelKod1Dava;
                davarefoz.DavaOzelKod2 = bankacilik.OzelKod2Dava;
                davarefoz.DavaOzelKod3 = bankacilik.OzelKod3Dava;
                davarefoz.DavaOzelKod4 = bankacilik.OzelKod4Dava;

                icrarefoz.IcraANrefarans1 = bankacilik.Referans1IcraAn;
                icrarefoz.IcraANreferans2 = bankacilik.Referans2IcraAn;
                icrarefoz.IcraANreferans3 = bankacilik.Referans3IcraAn;

                icrarefoz.IcraOzelDurumBanka = bankacilik.BankaIcra;
                icrarefoz.IcraOzelDurumFoyBirim = bankacilik.FoyBirimIcra;
                icrarefoz.IcraOzelDurumFoyYeri = bankacilik.FoyYeriIcra;
                icrarefoz.IcraOzelDurumKlasor1 = bankacilik.Klasor1Icra;
                icrarefoz.IcraOzelDurumKlasor2 = bankacilik.Klasor2Icra;
                icrarefoz.IcraOzelDurumKrediGrup = bankacilik.KrediGrupIcra;
                icrarefoz.IcraOzelDurumKrediTip = bankacilik.KrediTipIcra;
                icrarefoz.IcraOzelDurumOzel = bankacilik.OzelIcra;
                icrarefoz.IcraOzelDurumSube = bankacilik.SubeIcra;
                icrarefoz.IcraOzelDurumTahsilat = bankacilik.TahsilatIcra;

                icrarefoz.IcraOzelKod1 = bankacilik.OzelKod1Icra;
                icrarefoz.IcraOzelKod2 = bankacilik.OzelKod2Icra;
                icrarefoz.IcraOzelKod3 = bankacilik.OzelKod3Icra;
                icrarefoz.IcraOzelKod4 = bankacilik.OzelKod4Icra;

                icrarefoz.IcraReferans1 = bankacilik.Referans1Icra;
                icrarefoz.IcraReferans2 = bankacilik.Referans2Icra;
                icrarefoz.IcraReferans3 = bankacilik.Referans3Icra;


                ortakrefoz.OrtakOzelDurumBanka = bankacilik.BankaOrtak;
                ortakrefoz.OrtakOzelDurumFoyBirim = bankacilik.FoyBirimIcra;
                ortakrefoz.OrtakOzelDurumFoyYeri = bankacilik.FoyYeriIcra;
                ortakrefoz.OrtakOzelDurumKlasor1 = bankacilik.Klasor1Icra;
                ortakrefoz.OrtakOzelDurumKlasor2 = bankacilik.Klasor2Icra;
                ortakrefoz.OrtakOzelDurumKrediGrup = bankacilik.KrediGrupIcra;
                ortakrefoz.OrtakOzelDurumKrediTip = bankacilik.KrediTipIcra;
                ortakrefoz.OrtakOzelDurumOzel = bankacilik.OzelIcra;
                ortakrefoz.OrtakOzelDurumSube = bankacilik.SubeIcra;
                ortakrefoz.OrtakOzelDurumTahsilat = bankacilik.TahsilatIcra;


                sorusturmarefoz.SorusturmaOzelKod1 = bankacilik.OzelKod1Sorusturma;
                sorusturmarefoz.SorusturmaOzelKod2 = bankacilik.OzelKod2Sorusturma;
                sorusturmarefoz.SorusturmaOzelKod3 = bankacilik.OzelKod3Sorusturma;
                sorusturmarefoz.SorusturmaOzelKod4 = bankacilik.OzelKod4Sorusturma;

                sorusturmarefoz.SorusturmaReferans1 = bankacilik.Referans1Sorusturma;
                sorusturmarefoz.SorusturmaReferans2 = bankacilik.Referans2Sorusturma;
                sorusturmarefoz.SorusturmaReferans3 = bankacilik.Referans3Sorusturma;


                sozlezmerefoz.SozlesmeOzelKod1 = bankacilik.OzelKod1Sozlesme;
                sozlezmerefoz.SozlesmeOzelKod2 = bankacilik.OzelKod2Sozlesme;
                sozlezmerefoz.SozlesmeOzelKod3 = bankacilik.OzelKod3Sozlesme;
                sozlezmerefoz.SozlesmeOzelKod4 = bankacilik.OzelKod4Sozlesme;

                sozlezmerefoz.SozlesmeReferans1 = bankacilik.Referans1Sozlesme;
                sozlezmerefoz.SozlesmeReferans2 = bankacilik.Referans2Sozlesme;
                sozlezmerefoz.SozlesmeReferans3 = bankacilik.Referans3Sozlesme;
            }

            //sigorta
            else if (((KurumsalMod)e.NewValue).ModNo == 1001)
            {
                kurumsal.DavaDnReferans_Referans1 = sigorta.Referans1DavaDn;
                kurumsal.DavaDnReferans_Referans2 = sigorta.Referans2DavaDn;
                kurumsal.DavaDnReferans_Referans3 = sigorta.Referans3DavaDn;

                kurumsal.DavaReferans_Referans1 = sigorta.Referans1Dava;
                kurumsal.DavaReferans_Referans2 = sigorta.Referans2Dava;
                kurumsal.DavaReferans_Referans3 = sigorta.Referans3Dava;

                kurumsal.DavaOzelKod_OzelKod1 = sigorta.OzelKod1Dava;
                kurumsal.DavaOzelKod_OzelKod2 = sigorta.OzelKod2Dava;
                kurumsal.DavaOzelKod_OzelKod3 = sigorta.OzelKod3Dava;
                kurumsal.DavaOzelKod_OzelKod4 = sigorta.OzelKod4Dava;

                kurumsal.IcraAnReferans_Referans1 = sigorta.Referans1IcraAn;
                kurumsal.IcraAnReferans_Referans2 = sigorta.Referans2IcraAn;
                kurumsal.IcraAnReferans_Referans3 = sigorta.Referans3IcraAn;

                kurumsal.IcraOzelDurum_Banka = sigorta.BankaIcra;
                kurumsal.IcraOzelDurum_FoyBirim = sigorta.FoyBirimIcra;
                kurumsal.IcraOzelDurum_FoyYeri = sigorta.FoyYeriIcra;
                kurumsal.IcraOzelDurum_Klasor1 = sigorta.Klasor1Icra;
                kurumsal.IcraOzelDurum_Klasor2 = sigorta.Klasor2Icra;
                kurumsal.IcraOzelDurum_KrediGrup = sigorta.KrediGrupIcra;
                kurumsal.IcraOzelDurum_KrediTip = sigorta.KrediTipIcra;
                kurumsal.IcraOzelDurum_Ozel = sigorta.OzelIcra;
                kurumsal.IcraOzelDurum_Sube = sigorta.SubeIcra;
                kurumsal.IcraOzelDurum_Tahsilat = sigorta.TahsilatIcra;

                kurumsal.IcraOzelKod_OzelKod1 = sigorta.OzelKod1Icra;
                kurumsal.IcraOzelKod_OzelKod2 = sigorta.OzelKod2Icra;
                kurumsal.IcraOzelKod_OzelKod3 = sigorta.OzelKod3Icra;
                kurumsal.IcraOzelKod_OzelKod4 = sigorta.OzelKod4Icra;

                kurumsal.IcraReferans_Referans1 = sigorta.Referans1Icra;
                kurumsal.IcraReferans_Referans2 = sigorta.Referans2Icra;
                kurumsal.IcraReferans_Referans3 = sigorta.Referans3Icra;

                kurumsal.OrtakOzelDurum_Banka = sigorta.BankaOrtak;
                kurumsal.OrtakOzelDurum_FoyBirim = sigorta.FoyBirimIcra;
                kurumsal.OrtakOzelDurum_FoyYeri = sigorta.FoyYeriIcra;
                kurumsal.OrtakOzelDurum_Klasor1 = sigorta.Klasor1Icra;
                kurumsal.OrtakOzelDurum_Klasor2 = sigorta.Klasor2Icra;
                kurumsal.OrtakOzelDurum_KrediGrup = sigorta.KrediGrupIcra;
                kurumsal.OrtakOzelDurum_KrediTip = sigorta.KrediTipIcra;
                kurumsal.OrtakOzelDurum_Ozel = sigorta.OzelIcra;
                kurumsal.OrtakOzelDurum_Sube = sigorta.SubeIcra;
                kurumsal.OrtakOzelDurum_Tahsilat = sigorta.TahsilatIcra;

                kurumsal.SorusturmaOzelKod_OzelKod1 = sigorta.OzelKod1Sorusturma;
                kurumsal.SorusturmaOzelKod_OzelKod2 = sigorta.OzelKod2Sorusturma;
                kurumsal.SorusturmaOzelKod_OzelKod3 = sigorta.OzelKod3Sorusturma;
                kurumsal.SorusturmaOzelKod_OzelKod4 = sigorta.OzelKod4Sorusturma;

                kurumsal.SorusturmaReferans_Referans1 = sigorta.Referans1Sorusturma;
                kurumsal.SorusturmaReferans_Referans2 = sigorta.Referans2Sorusturma;
                kurumsal.SorusturmaReferans_Referans3 = sigorta.Referans3Sorusturma;

                kurumsal.SozlesmeOzelKod_OzelKod1 = sigorta.OzelKod1Sozlesme;
                kurumsal.SozlesmeOzelKod_OzelKod2 = sigorta.OzelKod2Sozlesme;
                kurumsal.SozlesmeOzelKod_OzelKod3 = sigorta.OzelKod3Sozlesme;
                kurumsal.SozlesmeOzelKod_OzelKod4 = sigorta.OzelKod4Sozlesme;

                kurumsal.SozlesmeReferans_Referans1 = sigorta.Referans1Sozlesme;
                kurumsal.SozlesmeReferans_Referans2 = sigorta.Referans2Sozlesme;
                kurumsal.SozlesmeReferans_Referans3 = sigorta.Referans3Sozlesme;
                //------------------------
                davarefoz.DavaNedenReferans1 = sigorta.Referans1DavaDn;
                davarefoz.DavaNedenReferans2 = sigorta.Referans2DavaDn;
                davarefoz.DavaNedenReferans3 = sigorta.Referans3DavaDn;

                davarefoz.DavaReferans1 = sigorta.Referans1Dava;
                davarefoz.DavaReferans2 = sigorta.Referans2Dava;
                davarefoz.DavaReferans3 = sigorta.Referans3Dava;

                davarefoz.DavaOzelKod1 = sigorta.OzelKod1Dava;
                davarefoz.DavaOzelKod2 = sigorta.OzelKod2Dava;
                davarefoz.DavaOzelKod3 = sigorta.OzelKod3Dava;
                davarefoz.DavaOzelKod4 = sigorta.OzelKod4Dava;

                icrarefoz.IcraANrefarans1 = sigorta.Referans1IcraAn;
                icrarefoz.IcraANreferans2 = sigorta.Referans2IcraAn;
                icrarefoz.IcraANreferans3 = sigorta.Referans3IcraAn;

                icrarefoz.IcraOzelDurumBanka = sigorta.BankaIcra;
                icrarefoz.IcraOzelDurumFoyBirim = sigorta.FoyBirimIcra;
                icrarefoz.IcraOzelDurumFoyYeri = sigorta.FoyYeriIcra;
                icrarefoz.IcraOzelDurumKlasor1 = sigorta.Klasor1Icra;
                icrarefoz.IcraOzelDurumKlasor2 = sigorta.Klasor2Icra;
                icrarefoz.IcraOzelDurumKrediGrup = sigorta.KrediGrupIcra;
                icrarefoz.IcraOzelDurumKrediTip = sigorta.KrediTipIcra;
                icrarefoz.IcraOzelDurumOzel = sigorta.OzelIcra;
                icrarefoz.IcraOzelDurumSube = sigorta.SubeIcra;
                icrarefoz.IcraOzelDurumTahsilat = sigorta.TahsilatIcra;

                icrarefoz.IcraOzelKod1 = sigorta.OzelKod1Icra;
                icrarefoz.IcraOzelKod2 = sigorta.OzelKod2Icra;
                icrarefoz.IcraOzelKod3 = sigorta.OzelKod3Icra;
                icrarefoz.IcraOzelKod4 = sigorta.OzelKod4Icra;

                icrarefoz.IcraReferans1 = sigorta.Referans1Icra;
                icrarefoz.IcraReferans2 = sigorta.Referans2Icra;
                icrarefoz.IcraReferans3 = sigorta.Referans3Icra;


                ortakrefoz.OrtakOzelDurumBanka = sigorta.BankaOrtak;
                ortakrefoz.OrtakOzelDurumFoyBirim = sigorta.FoyBirimIcra;
                ortakrefoz.OrtakOzelDurumFoyYeri = sigorta.FoyYeriIcra;
                ortakrefoz.OrtakOzelDurumKlasor1 = sigorta.Klasor1Icra;
                ortakrefoz.OrtakOzelDurumKlasor2 = sigorta.Klasor2Icra;
                ortakrefoz.OrtakOzelDurumKrediGrup = sigorta.KrediGrupIcra;
                ortakrefoz.OrtakOzelDurumKrediTip = sigorta.KrediTipIcra;
                ortakrefoz.OrtakOzelDurumOzel = sigorta.OzelIcra;
                ortakrefoz.OrtakOzelDurumSube = sigorta.SubeIcra;
                ortakrefoz.OrtakOzelDurumTahsilat = sigorta.TahsilatIcra;


                sorusturmarefoz.SorusturmaOzelKod1 = sigorta.OzelKod1Sorusturma;
                sorusturmarefoz.SorusturmaOzelKod2 = sigorta.OzelKod2Sorusturma;
                sorusturmarefoz.SorusturmaOzelKod3 = sigorta.OzelKod3Sorusturma;
                sorusturmarefoz.SorusturmaOzelKod4 = sigorta.OzelKod4Sorusturma;

                sorusturmarefoz.SorusturmaReferans1 = sigorta.Referans1Sorusturma;
                sorusturmarefoz.SorusturmaReferans2 = sigorta.Referans2Sorusturma;
                sorusturmarefoz.SorusturmaReferans3 = sigorta.Referans3Sorusturma;


                sozlezmerefoz.SozlesmeOzelKod1 = sigorta.OzelKod1Sozlesme;
                sozlezmerefoz.SozlesmeOzelKod2 = sigorta.OzelKod2Sozlesme;
                sozlezmerefoz.SozlesmeOzelKod3 = sigorta.OzelKod3Sozlesme;
                sozlezmerefoz.SozlesmeOzelKod4 = sigorta.OzelKod4Sozlesme;

                sozlezmerefoz.SozlesmeReferans1 = sigorta.Referans1Sozlesme;
                sozlezmerefoz.SozlesmeReferans2 = sigorta.Referans2Sozlesme;
                sozlezmerefoz.SozlesmeReferans3 = sigorta.Referans3Sozlesme;
            }

            //belediye
            else if (((KurumsalMod)e.NewValue).ModNo == 3001)
            {
                kurumsal.DavaDnReferans_Referans1 = belediye.Referans1DavaDn;
                kurumsal.DavaDnReferans_Referans2 = belediye.Referans2DavaDn;
                kurumsal.DavaDnReferans_Referans3 = belediye.Referans3DavaDn;

                kurumsal.DavaReferans_Referans1 = belediye.Referans1Dava;
                kurumsal.DavaReferans_Referans2 = belediye.Referans2Dava;
                kurumsal.DavaReferans_Referans3 = belediye.Referans3Dava;

                kurumsal.DavaOzelKod_OzelKod1 = belediye.OzelKod1Dava;
                kurumsal.DavaOzelKod_OzelKod2 = belediye.OzelKod2Dava;
                kurumsal.DavaOzelKod_OzelKod3 = belediye.OzelKod3Dava;
                kurumsal.DavaOzelKod_OzelKod4 = belediye.OzelKod4Dava;

                kurumsal.IcraAnReferans_Referans1 = belediye.Referans1IcraAn;
                kurumsal.IcraAnReferans_Referans2 = belediye.Referans2IcraAn;
                kurumsal.IcraAnReferans_Referans3 = belediye.Referans3IcraAn;

                kurumsal.IcraOzelDurum_Banka = belediye.BankaIcra;
                kurumsal.IcraOzelDurum_FoyBirim = belediye.FoyBirimIcra;
                kurumsal.IcraOzelDurum_FoyYeri = belediye.FoyYeriIcra;
                kurumsal.IcraOzelDurum_Klasor1 = belediye.Klasor1Icra;
                kurumsal.IcraOzelDurum_Klasor2 = belediye.Klasor2Icra;
                kurumsal.IcraOzelDurum_KrediGrup = belediye.KrediGrupIcra;
                kurumsal.IcraOzelDurum_KrediTip = belediye.KrediTipIcra;
                kurumsal.IcraOzelDurum_Ozel = belediye.OzelIcra;
                kurumsal.IcraOzelDurum_Sube = belediye.SubeIcra;
                kurumsal.IcraOzelDurum_Tahsilat = belediye.TahsilatIcra;

                kurumsal.IcraOzelKod_OzelKod1 = belediye.OzelKod1Icra;
                kurumsal.IcraOzelKod_OzelKod2 = belediye.OzelKod2Icra;
                kurumsal.IcraOzelKod_OzelKod3 = belediye.OzelKod3Icra;
                kurumsal.IcraOzelKod_OzelKod4 = belediye.OzelKod4Icra;

                kurumsal.IcraReferans_Referans1 = belediye.Referans1Icra;
                kurumsal.IcraReferans_Referans2 = belediye.Referans2Icra;
                kurumsal.IcraReferans_Referans3 = belediye.Referans3Icra;

                kurumsal.OrtakOzelDurum_Banka = belediye.BankaOrtak;
                kurumsal.OrtakOzelDurum_FoyBirim = belediye.FoyBirimIcra;
                kurumsal.OrtakOzelDurum_FoyYeri = belediye.FoyYeriIcra;
                kurumsal.OrtakOzelDurum_Klasor1 = belediye.Klasor1Icra;
                kurumsal.OrtakOzelDurum_Klasor2 = belediye.Klasor2Icra;
                kurumsal.OrtakOzelDurum_KrediGrup = belediye.KrediGrupIcra;
                kurumsal.OrtakOzelDurum_KrediTip = belediye.KrediTipIcra;
                kurumsal.OrtakOzelDurum_Ozel = belediye.OzelIcra;
                kurumsal.OrtakOzelDurum_Sube = belediye.SubeIcra;
                kurumsal.OrtakOzelDurum_Tahsilat = belediye.TahsilatIcra;

                kurumsal.SorusturmaOzelKod_OzelKod1 = belediye.OzelKod1Sorusturma;
                kurumsal.SorusturmaOzelKod_OzelKod2 = belediye.OzelKod2Sorusturma;
                kurumsal.SorusturmaOzelKod_OzelKod3 = belediye.OzelKod3Sorusturma;
                kurumsal.SorusturmaOzelKod_OzelKod4 = belediye.OzelKod4Sorusturma;

                kurumsal.SorusturmaReferans_Referans1 = belediye.Referans1Sorusturma;
                kurumsal.SorusturmaReferans_Referans2 = belediye.Referans2Sorusturma;
                kurumsal.SorusturmaReferans_Referans3 = belediye.Referans3Sorusturma;

                kurumsal.SozlesmeOzelKod_OzelKod1 = belediye.OzelKod1Sozlesme;
                kurumsal.SozlesmeOzelKod_OzelKod2 = belediye.OzelKod2Sozlesme;
                kurumsal.SozlesmeOzelKod_OzelKod3 = belediye.OzelKod3Sozlesme;
                kurumsal.SozlesmeOzelKod_OzelKod4 = belediye.OzelKod4Sozlesme;

                kurumsal.SozlesmeReferans_Referans1 = belediye.Referans1Sozlesme;
                kurumsal.SozlesmeReferans_Referans2 = belediye.Referans2Sozlesme;
                kurumsal.SozlesmeReferans_Referans3 = belediye.Referans3Sozlesme;

                //------------------------
                //------------------------
                davarefoz.DavaNedenReferans1 = belediye.Referans1DavaDn;
                davarefoz.DavaNedenReferans2 = belediye.Referans2DavaDn;
                davarefoz.DavaNedenReferans3 = belediye.Referans3DavaDn;

                davarefoz.DavaReferans1 = belediye.Referans1Dava;
                davarefoz.DavaReferans2 = belediye.Referans2Dava;
                davarefoz.DavaReferans3 = belediye.Referans3Dava;

                davarefoz.DavaOzelKod1 = belediye.OzelKod1Dava;
                davarefoz.DavaOzelKod2 = belediye.OzelKod2Dava;
                davarefoz.DavaOzelKod3 = belediye.OzelKod3Dava;
                davarefoz.DavaOzelKod4 = belediye.OzelKod4Dava;

                icrarefoz.IcraANrefarans1 = belediye.Referans1IcraAn;
                icrarefoz.IcraANreferans2 = belediye.Referans2IcraAn;
                icrarefoz.IcraANreferans3 = belediye.Referans3IcraAn;

                icrarefoz.IcraOzelDurumBanka = belediye.BankaIcra;
                icrarefoz.IcraOzelDurumFoyBirim = belediye.FoyBirimIcra;
                icrarefoz.IcraOzelDurumFoyYeri = belediye.FoyYeriIcra;
                icrarefoz.IcraOzelDurumKlasor1 = belediye.Klasor1Icra;
                icrarefoz.IcraOzelDurumKlasor2 = belediye.Klasor2Icra;
                icrarefoz.IcraOzelDurumKrediGrup = belediye.KrediGrupIcra;
                icrarefoz.IcraOzelDurumKrediTip = belediye.KrediTipIcra;
                icrarefoz.IcraOzelDurumOzel = belediye.OzelIcra;
                icrarefoz.IcraOzelDurumSube = belediye.SubeIcra;
                icrarefoz.IcraOzelDurumTahsilat = belediye.TahsilatIcra;

                icrarefoz.IcraOzelKod1 = belediye.OzelKod1Icra;
                icrarefoz.IcraOzelKod2 = belediye.OzelKod2Icra;
                icrarefoz.IcraOzelKod3 = belediye.OzelKod3Icra;
                icrarefoz.IcraOzelKod4 = belediye.OzelKod4Icra;

                icrarefoz.IcraReferans1 = belediye.Referans1Icra;
                icrarefoz.IcraReferans2 = belediye.Referans2Icra;
                icrarefoz.IcraReferans3 = belediye.Referans3Icra;


                ortakrefoz.OrtakOzelDurumBanka = belediye.BankaOrtak;
                ortakrefoz.OrtakOzelDurumFoyBirim = belediye.FoyBirimIcra;
                ortakrefoz.OrtakOzelDurumFoyYeri = belediye.FoyYeriIcra;
                ortakrefoz.OrtakOzelDurumKlasor1 = belediye.Klasor1Icra;
                ortakrefoz.OrtakOzelDurumKlasor2 = belediye.Klasor2Icra;
                ortakrefoz.OrtakOzelDurumKrediGrup = belediye.KrediGrupIcra;
                ortakrefoz.OrtakOzelDurumKrediTip = belediye.KrediTipIcra;
                ortakrefoz.OrtakOzelDurumOzel = belediye.OzelIcra;
                ortakrefoz.OrtakOzelDurumSube = belediye.SubeIcra;
                ortakrefoz.OrtakOzelDurumTahsilat = belediye.TahsilatIcra;


                sorusturmarefoz.SorusturmaOzelKod1 = belediye.OzelKod1Sorusturma;
                sorusturmarefoz.SorusturmaOzelKod2 = belediye.OzelKod2Sorusturma;
                sorusturmarefoz.SorusturmaOzelKod3 = belediye.OzelKod3Sorusturma;
                sorusturmarefoz.SorusturmaOzelKod4 = belediye.OzelKod4Sorusturma;

                sorusturmarefoz.SorusturmaReferans1 = belediye.Referans1Sorusturma;
                sorusturmarefoz.SorusturmaReferans2 = belediye.Referans2Sorusturma;
                sorusturmarefoz.SorusturmaReferans3 = belediye.Referans3Sorusturma;


                sozlezmerefoz.SozlesmeOzelKod1 = belediye.OzelKod1Sozlesme;
                sozlezmerefoz.SozlesmeOzelKod2 = belediye.OzelKod2Sozlesme;
                sozlezmerefoz.SozlesmeOzelKod3 = belediye.OzelKod3Sozlesme;
                sozlezmerefoz.SozlesmeOzelKod4 = belediye.OzelKod4Sozlesme;

                sozlezmerefoz.SozlesmeReferans1 = belediye.Referans1Sozlesme;
                sozlezmerefoz.SozlesmeReferans2 = belediye.Referans2Sozlesme;
                sozlezmerefoz.SozlesmeReferans3 = belediye.Referans3Sozlesme;
            }
        }

        private void rlueConnectionTip_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            int i = Convert.ToInt32(e.NewValue);

            if (i == (int)ConnectionTip.Application_Server)
            {
                rowDomainAdi.Visible = false;
            }
            else if (i == (int)ConnectionTip.Domain_Server)
            {
                rowDomainAdi.Visible = true;
            }
            CompInfo cmp = sunucuIslemleriBindingSource.Current as CompInfo;
            cmp.ConnectionTip = Convert.ToInt32(e.NewValue);
        }

        private void rLueOturumAcmaModu_EditValueChanged(object sender, EventArgs e)
        {
            //LookUpEdit lue= sender as LookUpEdit;
            //foreach (var item in clist)
            //{
            //    if (item.OturumAcmaModu == false)
            //    {
            //        domainname = getDomain();
            //    }
            //}
        }

        private void rLueOturumAcmaModu_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Convert.ToBoolean(Convert.ToInt32(e.NewValue)) == true)
            {
                domainname = getDomain();
                foreach (var item in clist)
                {
                    item.DomainKullaniciAdi = domainname;
                }
            }
        }

        private void sunucuIslemleriBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            //clist = new List<CompInfo>();
            CompInfo cInfo = new CompInfo();
            cInfo.GuncelSunucuAdresi = "http://update.avukatpro.com";
            cInfo.UygulamaSunucuAdresi = "http://";
            cInfo.VeriTabanýKullanicisi = "AVP_NG";
            cInfo.HAVeriTabani = "AVP_NHA_NG";
            cInfo.MKVeriTabani = "AVP_NHA_MK";
            clist.Add(cInfo);
            e.NewObject = cInfo;
        }
    }

    public class HatirlatmaBilgileri
    {
        public HatirlatmaBilgileri()
        {
            HatirlatmaBilgisi = "TANIMLANMAMIÞ";
            HatirlatmaTipi = 0;
        }

        public HatirlatmaBilgileri(string h, int t)
        {
            HatirlatmaBilgisi = h;
            HatirlatmaTipi = t;
        }

        public string HatirlatmaBilgisi { set; get; }

        public int HatirlatmaTipi { set; get; }
    }

    public class UygulamaTipleri
    {
        public UygulamaTipleri()
        {
            Uygulama = "Server";
            UygulamaTipi = 0;
        }

        public UygulamaTipleri(string u, int t)
        {
            Uygulama = u;
            UygulamaTipi = t;
        }

        public string Uygulama { set; get; }

        public int UygulamaTipi { set; get; }
    }
}