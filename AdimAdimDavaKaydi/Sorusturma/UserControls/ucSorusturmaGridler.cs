using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Muhasebe;
using AvukatPro.Model.EntityClasses;
using AvukatPro.Services.Messaging;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System.Data;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucSorusturmaGridler : DevExpress.XtraEditors.XtraUserControl
    {
        private AV001_TD_BIL_HAZIRLIK _myHazirlikFoy;

        private AvukatProLib.Arama.AvpDataContext context =
            new AvukatProLib.Arama.AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        public ucSorusturmaGridler()
        {
            if (!this.DesignMode)
                InitializeComponent();

            var pages = tabGridler.TabPages.OrderBy(vi => vi.Text).ToList();

            tabGridler.TabPages.Clear();

            for (int i = 0; i < pages.Count(); i++)
            {
                tabGridler.TabPages.Add(pages[i]);
            }
            tabGridler.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(tabGridler_SelectedPageChanging);//arch
        }

        public AV001_TD_BIL_HAZIRLIK MyHazirlikFoy
        {
            get { return _myHazirlikFoy; }
            set
            {
                _myHazirlikFoy = value;
                if (!this.DesignMode && value != null)
                {
                    this.DataDegistir(value);
                }
            }
        }

        private void DataDegistir(AV001_TD_BIL_HAZIRLIK Hazirlik)
        {
            #region eskiler

            //ucHazirlikAsama1.MyDataSource = Hazirlik.AV001_TDIE_BIL_ASAMACollection;

            //ucHazirlikFatura1.MyDataSource = Hazirlik.AV001_TDI_BIL_FATURACollection;

            //ucHazirlikGorusme1.MyDataSource = Hazirlik.AV001_TDI_BIL_GORUSMECollection;

            //ucHazirlikHikaye1.MyDataSource = Hazirlik.AV001_TD_BIL_HAZIRLIK_HIKAYECollection;

            //ucHazirlikMasraflar1.MyDataSource = Hazirlik.AV001_TDI_BIL_MASRAF_AVANSCollection;

            //ucHazirlikMuhasebeBilgileri1.MyDataSource = Hazirlik.AV001_TDI_BIL_FOY_MUHASEBECollection;

            //ucHazirlikSikayetNeden1.MyDataSource = Hazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection;

            //ucHazirlikSorguMahkemesi1.MyDataSource = Hazirlik.AV001_TD_BIL_HAZIRLIK_SURECCollection;

            //ucHazirlikSavcilik1.MyDataSource = Hazirlik.AV001_TD_BIL_HAZIRLIK_SURECCollection;

            //ucHazirlikKarakol1.MyDataSource = Hazirlik.AV001_TD_BIL_HAZIRLIK_SURECCollection;

            #endregion eskiler

            #region Nedenden Dolanlar

            //ucHasarBilgileri1.MyDataSource=sNeden.NN_SIKAYET_NEDEN_POLICE_HASARCollection;
            //ucPoliceBilgileri1.MyDataSource = sNeden.NN_SIKAYET_NEDEN_POLICECollection;

            #endregion Nedenden Dolanlar

            ucHazirlikFatura1.MyDataSource = Hazirlik.AV001_TDI_BIL_FATURACollection;
            ucHazirlikFatura1.MyHazirlik = Hazirlik;

            ucHazirlikMasraflar1.MyHazirlikFoy = Hazirlik;

            //ucHazirlikMasraflar1.MyDataSource = Hazirlik.AV001_TDI_BIL_MASRAF_AVANSCollection;

            ucHazirlikMuhasebeBilgileri1.MyDataSource = Hazirlik.AV001_TDI_BIL_FOY_MUHASEBECollection;

            ucHazirlikSikayetNeden1.MySorusturma = Hazirlik;

            ucHazirlikSikayetNeden1.GridFocusedRowChanged += ucHazirlikSikayetNeden1_GridFocusedRowChanged;
            ucHazirlikSikayetNeden1.MyDataSource = Hazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection;
            ucIliskiDetay4.GetList(Hazirlik.ID,
                                   AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.HAZIRLIK_DOSYASI);

            //ucYapilcakIsSozlesme1.MyDataSource = Hazirlik.IS_SOZLESME_IDSource;
            gcMuvekkilOdemeleri.MyDataSource = Hazirlik.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByHAZIRLIK_FOY_ID;

            //ucVekaletSozlesmesi1.MyDataSource=Hazirlik.Av001_TD_BIL_V

            //ucMeslekMakbuzu1.MyDataSource = Hazirlik.AV001_TDI_BIL_FATURACollection;
            ucMeslekMakbuzu1.MyDataSource = AvukatPro.Services.Implementations.DosyaService.GetAllFaturaByFoy(MyHazirlikFoy.ID, Modul.Sorusturma);
            ucMeslekMakbuzu1.MyHazirlik = Hazirlik;

            //ucMeslekMakbuzu1.MyDataSource = Hazirlik.AV001_TDI_BIL_FATURACollection;

            //ucMuhasebeBilgileri1.MyDataSource = Hazirlik.AV001_TDI_BIL_FOY_MUHASEBECollection;
            //TODO: yeni tab eklendi içerisinede aþaðýdaki UC eklendiðinden DataSource si burada verildi --THSN--
            ucTebligat1.MyHazirlikFoy = Hazirlik;
            ucTebligat1.MyDataSource = Hazirlik.AV001_TDI_BIL_TEBLIGATCollection;

            //ÝliþkiliDosyalar
            ucDavaKayitIliskiDetay1.MyHazirlik = Hazirlik;
            ucDavaKayitIliskiDetay1.MyDataSource = Hazirlik.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection;

            ucbelgetakip1.TableName = "AV001_TD_BIL_HAZIRLIK";
            ucbelgetakip1.IdValue = Hazirlik.ID;
            ucbelgetakip1.CurrentRecord = this.MyHazirlikFoy;
            ucbelgetakip1.MyDataSource = BelgeUtil.Inits.BelgeGetirBySorusturmaId(Hazirlik.ID);

            //Görüþme
            ucHazirlikGorusme1.MyHazirlik = Hazirlik;
            ucHazirlikGorusme1.MyDataSource = Hazirlik.AV001_TDI_BIL_GORUSMECollection;

            //ucDavaSMS1.MyDataSource=Hazirlik.TSMS_BIL_MESAJ
            ucEPosta1.MyDataSource = Hazirlik.AV001_TDIE_BIL_MESAJCollection_From_NN_MESAJ_HAZIRLIK;
            ucHazirlikTutuklanma1.MySorusturma = Hazirlik;
            ucHazirlikTutuklanma1.MyDataSource = Hazirlik.AV001_TD_BIL_TUTUKLANMACollection;

            //Genel notlar
            ucDavaGenelNotlar1.MyHazirlikFoy = Hazirlik;
            ucDavaGenelNotlar1.MyDataSource = Hazirlik.AV001_TD_BIL_FOY_GENEL_NOTCollection;

            TList<AV001_TD_BIL_HAZIRLIK_SUREC> karakol = new TList<AV001_TD_BIL_HAZIRLIK_SUREC>();
            TList<AV001_TD_BIL_HAZIRLIK_SUREC> SMahkeme = new TList<AV001_TD_BIL_HAZIRLIK_SUREC>();
            TList<AV001_TD_BIL_HAZIRLIK_SUREC> Savcilik = new TList<AV001_TD_BIL_HAZIRLIK_SUREC>();
            foreach (AV001_TD_BIL_HAZIRLIK_SUREC var in Hazirlik.AV001_TD_BIL_HAZIRLIK_SURECCollection)
            {
                if (var.SUREC_TIP_ID.Value == 1)
                {
                    karakol.Add(var);
                }
                else if (var.SUREC_TIP_ID.Value == 2)
                {
                    Savcilik.Add(var);
                }
                else if (var.SUREC_TIP_ID.Value == 3)
                {
                    SMahkeme.Add(var);
                }
            }
            ucHazirlikKarakol1.MyDataSource = karakol;
            ucHazirlikKarakol1.MySorusturma = Hazirlik;
            ucHazirlikSavcilik1.MyDataSource = Savcilik;
            ucHazirlikSavcilik1.MySorusturma = Hazirlik;
            ucHazirlikSorguMahkemesi1.MyDataSource = SMahkeme;
            ucHazirlikSorguMahkemesi1.MySorusturma = Hazirlik;

            ucHazirlikHikaye1.MyFoy = Hazirlik;
            ucHazirlikHikaye1.MyDataSource = Hazirlik.AV001_TD_BIL_HAZIRLIK_HIKAYECollection;

            ucHazirlikAsama1.MyDataSource = Hazirlik.AV001_TDIE_BIL_ASAMACollection;

            //Görevler
            this.ucGorevGrid1.Saved += ucGorevGrid1_Saved;
            ucGorevGrid1.MyDataSource = MyHazirlikFoy.AV001_TDI_BIL_ISCollection_From_NN_IS_HAZIRLIK;

            ucGorevGrid1.SelectedRecord = MyHazirlikFoy;
            ucGorevGrid1.SelectedRecordId = MyHazirlikFoy.ID;

            //Müvekkil Muhasebesi
            if (AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue)
            {
                bool muvekkil =
                    AvukatProLib.Arama.R_CARI_HESAP_MUVEKKIL.KullaniciMuvekkilMi(
                        AvukatProLib.Kimlik.SirketBilgisi.ConStr, AvukatProLib.Kimlik.Bilgi.CARI_ID.Value);
                if (!muvekkil) return;

                if (MyHazirlikFoy.AV001_TDI_BIL_CARI_HESAP_DETAYCollection.Count == 0)
                    DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyHazirlikFoy, false,
                                                                          DeepLoadType.IncludeChildren,
                                                                          typeof(TList<AV001_TDI_BIL_CARI_HESAP_DETAY>));

                TList<AV001_TDI_BIL_CARI_HESAP_DETAY> cariHesapDetaylari =
                    MyHazirlikFoy.AV001_TDI_BIL_CARI_HESAP_DETAYCollection;
                List<AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY> kullaniciHesaplar =
                    context.AV001_TDI_BIL_CARI_HESAP_DETAYs.Where(
                        vi => vi.KONTROL_KIM_ID == AvukatProLib.Kimlik.Bilgi.ID && vi.HAZIRLIK_ID == MyHazirlikFoy.ID).
                        ToList();

                //aykut hýzlandýrma 25.01.2013 önemli
                //List<RCariHesapDetayliEntity> hesaplar =
                //    new List<RCariHesapDetayliEntity>();
                //foreach (var item in cariHesapDetaylari)
                //{
                //    RCariHesapDetayliEntity tmp = AvukatPro.Services.Implementations.CariService.GetCariHesapDetayById(item.ID);
                //    if (tmp != null)
                //        hesaplar.Add(tmp);
                //}

                //if (hesaplar != null)
                //{
                //    ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = hesaplar;
                //    ucMuhasebeGenel2.MyMuvekkilCariHesapDetayli = hesaplar.Where(h => h.KontrolKimId == AvukatProLib.Kimlik.Bilgi.ID).ToList();
                //}
            }
        }

        private void frmMuhasebe_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayBySorusturmaFoyId(MyHazirlikFoy.ID);
        }

        private void NedeneBagliDetayGetir(AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN sNeden)
        {
            tabPKýymetliEvrak.PageVisible = false;
            tabPGayrimenkulBilgileri.PageVisible = false;
            abPAracBilgileri.PageVisible = false;
            DataRepository.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENProvider.DeepLoad(sNeden, false,
                                                                                DeepLoadType.IncludeChildren,
                                                                                typeof(
                                                                                    TList<NN_SIKAYET_NEDEN_GAYRIMENKUL>),
                                                                                typeof(
                                                                                    TList
                                                                                    <NN_SIKAYET_NEDEN_GEMI_UCAK_ARAC>),
                                                                                typeof(
                                                                                    TList
                                                                                    <NN_SIKAYET_NEDEN_KIYMETLI_EVRAK>));
            if (sNeden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_SIKAYET_NEDEN_KIYMETLI_EVRAK.Count > 0)
            {
                tabPKýymetliEvrak.PageVisible = true;
                ucKiymetliEvrakGrid1.MyDataSource =
                    sNeden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_SIKAYET_NEDEN_KIYMETLI_EVRAK;
            }
            if (sNeden.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SIKAYET_NEDEN_GAYRIMENKUL.Count > 0)
            {
                tabPGayrimenkulBilgileri.PageVisible = true;
                ucGayriMenkul1.MyDataSource =
                    sNeden.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SIKAYET_NEDEN_GAYRIMENKUL;
                ucGayriMenkulTaraf1.MyDataSource =
                    sNeden.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SIKAYET_NEDEN_GAYRIMENKUL[0].
                        AV001_TI_BIL_GAYRIMENKUL_TARAFCollection;
            }
            if (sNeden.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SIKAYET_NEDEN_GEMI_UCAK_ARAC.Count > 0)
            {
                abPAracBilgileri.PageVisible = true;
                ucUcakGemiArac1.MyDataSource = BelgeUtil.Inits.GemiUcakAracGetirBySikayetNedenId(sNeden.ID);
            }
        }

        private void tabControlSorusturma_SystemColorsChanged(object sender, EventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN sNeden =
                (AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN)ucHazirlikSikayetNeden1.grdSikayetNeden.GetFocusedRow();
            NedeneBagliDetayGetir(sNeden);
        }

        private void tabGridler_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)//arch
        {
            if (e.Page.Name == this.tabSorusturmaMasraflar.Name)
            {
                this.tabSorusturmaMasraflar.Controls.Clear();

                AdimAdimDavaKaydi.UserControls.ucMuhasebeGenel ucMuhasebeGenel3 = new AdimAdimDavaKaydi.UserControls.ucMuhasebeGenel("Soruþturma", "Masraf", MyHazirlikFoy);
                ucMuhasebeGenel3.Dock = System.Windows.Forms.DockStyle.Fill;
                ucMuhasebeGenel3.Location = new System.Drawing.Point(0, 0);
                ucMuhasebeGenel3.Name = "ucMuhasebeGenel3";
                ucMuhasebeGenel3.SaveStatus = false;
                ucMuhasebeGenel3.Size = new System.Drawing.Size(918, 276);
                ucMuhasebeGenel3.TabIndex = 9;

                //System.Collections.Generic.List<AdimAdimDavaKaydi.UserControls.AddSelection> ads = new System.Collections.Generic.List<AdimAdimDavaKaydi.UserControls.AddSelection>();
                //System.Collections.Generic.List<AvukatProLib.Arama.R_MASRAF_AVANS_DETAYLI2> sorgu = AvukatProLib.Arama.R_MASRAF_AVANS_DETAYLISorgu.GetByFiltreView(
                //        null, null, null, null, null, null, null, null, null, null, MyHazirlikFoy.ID, null,
                //            (AvukatProLib.Extras.Modul?)3, null, null, null, AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                //foreach (AvukatProLib.Arama.R_MASRAF_AVANS_DETAYLI2 item in sorgu)
                //{
                //    AdimAdimDavaKaydi.UserControls.AddSelection selection = new AdimAdimDavaKaydi.UserControls.AddSelection(item);
                //    ads.Add(selection);
                //}
                //ucMuhasebeGenel3.MyMasrafAvansDetayliSonuc2 = ads;
                //this.tabSorusturmaMasraflar.Controls.Add(ucMuhasebeGenel3);

                ucMuhasebeGenel3.MyMasrafAvansDetayli = AvukatPro.Services.Implementations.MasrafAvansService.GetAllMasrafBySorusturmaFoyId(MyHazirlikFoy.ID);
                tabSorusturmaMasraflar.Controls.Add(ucMuhasebeGenel3);
            }

            else if (e.Page.Name == this.tabSorusturmaMuhasebe.Name)
            {
                #region Masraf Avansdan Dosya Muhasebe ve detay oluþtur

                bool olustur = false;
                if (MyHazirlikFoy != null)
                {
                    int foyID = MyHazirlikFoy.ID;
                    TList<AV001_TDI_BIL_MASRAF_AVANS> gelenMasrafAvans = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByHAZIRLIK_ID(foyID);

                    try
                    {
                        foreach (var masrafAvans in gelenMasrafAvans)
                        {
                            AV001_TDI_BIL_FOY_MUHASEBE gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();

                            if (gelenMuhasebe == null)
                            {
                                olustur = true;
                            }

                            if (gelenMuhasebe != null)
                            {
                                TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> mevcutMasrafDetay = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID);
                                TList<AV001_TDI_BIL_FOY_MUHASEBE_DETAY> gelenMuhasebeDetay = DataRepository.AV001_TDI_BIL_FOY_MUHASEBE_DETAYProvider.GetByFOY_MUHASEBE_ID(gelenMuhasebe.ID);

                                if (mevcutMasrafDetay.Count > gelenMuhasebeDetay.Count)
                                {
                                    olustur = true;
                                }
                            }
                        }

                        if (olustur)
                        {
                            if (XtraMessageBox.Show(
                           "Bu dosyada dosya muhasebesine aktarýlmamýþ masraf ve / veya avans kayýtlarý var.\nMüvekkil muhasebesine aktarýlabilmesi için öncelikle bu kayýtlarýn oluþturulmasý gerekiyor.\nÞimdi oluþturulmasýný ister misiniz?",
                           "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                            {
                                foreach (var masrafAvans in gelenMasrafAvans)
                                {
                                    AV001_TDI_BIL_FOY_MUHASEBE gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();
                                    if (gelenMuhasebe == null)
                                    {
                                        CreateFoyMuhasebeByMasrafAvansRequest request = new CreateFoyMuhasebeByMasrafAvansRequest();
                                        request.MasrafAvansId = masrafAvans.ID;
                                        request.ModulId = masrafAvans.CARI_HESAP_HEDEF_TIP;
                                        AvukatPro.Services.Implementations.MuhasebeService.CreateFoyMuhasebeByMasrafAvans(request);

                                        gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();
                                    }

                                    if (gelenMuhasebe != null)
                                    {
                                        TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> mevcutMasrafDetay = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID);
                                        TList<AV001_TDI_BIL_FOY_MUHASEBE_DETAY> gelenMuhasebeDetay = DataRepository.AV001_TDI_BIL_FOY_MUHASEBE_DETAYProvider.GetByFOY_MUHASEBE_ID(gelenMuhasebe.ID);

                                        if (mevcutMasrafDetay.Count > gelenMuhasebeDetay.Count)
                                        {
                                            foreach (var item in mevcutMasrafDetay)
                                            {
                                                //kontrol versiyon alanýnda masraf avans detay id tutulmaktadýr
                                                if (!gelenMuhasebeDetay.Any(m => m.KONTROL_VERSIYON == item.ID))
                                                {
                                                    CreateFoyMuhasebeDetayByMasrafAvansDetayRequest request = new CreateFoyMuhasebeDetayByMasrafAvansDetayRequest();
                                                    request.MasrafAvansDetayId = item.ID;
                                                    request.MuhasebeId = gelenMuhasebe.ID;
                                                    request.YenidenHesaplanabilir = !item.MA_MANUAL_KAYIT_MI;
                                                    AvukatPro.Services.Implementations.MuhasebeService.CreateFoyMuhasebeDetayByMasrafAvansDetay(request);

                                                    // son parametre yeniden hesaplanabilir olmasý için verildi
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            XtraMessageBox.Show("Masraf avans kayýtlarýnýn dosya muhasebesine aktarýlmasý tamamlandý.", "Ýþlem Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    catch (Exception)
                    {
                        XtraMessageBox.Show("Aktarým tamamlanamadý!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                #endregion Masraf Avansdan Dosya Muhasebe ve detay oluþtur

                this.tabSorusturmaMuhasebe.Controls.Clear();

                AdimAdimDavaKaydi.UserControls.ucMuhasebeGenel ucMuhasebeSorusturma = new AdimAdimDavaKaydi.UserControls.ucMuhasebeGenel("Soruþturma", "Dosya", null);
                ucMuhasebeSorusturma.Dock = System.Windows.Forms.DockStyle.Fill;
                ucMuhasebeSorusturma.Location = new System.Drawing.Point(0, 0);
                ucMuhasebeSorusturma.Name = "ucMuhasebeSorusturma";
                ucMuhasebeSorusturma.SaveStatus = false;
                ucMuhasebeSorusturma.Size = new System.Drawing.Size(918, 276);
                ucMuhasebeSorusturma.TabIndex = 9;

                //int[] idler = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByHAZIRLIK_ID(MyHazirlikFoy.ID).Select(i => i.ID).Distinct().ToArray();
                //VList<R_FOY_MUHASEBESI_SORUSTURMA> sorusturmaMuhasebe = new VList<R_FOY_MUHASEBESI_SORUSTURMA>();

                //foreach (var id in idler)
                //{
                //    sorusturmaMuhasebe.AddRange((VList<R_FOY_MUHASEBESI_SORUSTURMA>)DataRepository.R_FOY_MUHASEBESI_SORUSTURMAProvider.Get("ID = " + id, "TARIH"));
                //}

                ucMuhasebeSorusturma.MySorusturmaFoyMuhasebe = AvukatPro.Services.Implementations.MuhasebeService.GetAllMuhasebeFromSorusturmaFoy(MyHazirlikFoy.ID);
                ucMuhasebeSorusturma.mainView.FocusedRowChanged += ucMuhasebeSorusturma.gridView2_FocusedRowChanged;
                this.tabSorusturmaMuhasebe.Controls.Add(ucMuhasebeSorusturma);
            }

            if (e.Page.Name == this.tabMuvekkilHesabý.Name)
            {
                #region DosyaMuhasebesi kontrol ve muyasebeleþtirme ekranýna gönderme

                decimal? carilestirilebilirToplam = AvukatPro.Services.Implementations.MuhasebeService.GetMuhasebeBirlesikDetayliByFoyId(MyHazirlikFoy.ID, 3).Select(m => m.MuhasebelestirilmemisMiktar).Sum();

                if (carilestirilebilirToplam > 0)
                {
                    if (XtraMessageBox.Show(
                   "Bu dosyada dosya muhasebesine aktarýlmýþ ancak müvekkiller adýna muhasebeleþtirilmemiþ kayýtlar bulunmaktadýr.\nÞimdi muhasebeleþtirmek istiyormusunuz?",
                   "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        frmDosyaMuhasebelestirme frm = new frmDosyaMuhasebelestirme(3, MyHazirlikFoy.ID);
                        frm.MdiParent = AnaForm.mdiAvukatPro.MainForm;
                        frm.FormClosed += new FormClosedEventHandler(frmMuhasebe_FormClosed);
                        frm.Show();
                    }
                }

                ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayBySorusturmaFoyId(MyHazirlikFoy.ID);

                #endregion DosyaMuhasebesi kontrol ve muyasebeleþtirme ekranýna gönderme
            }
        }

        private void ucGorevGrid1_Saved(System.Collections.IList Records, IEntity Record)
        {
            DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyHazirlikFoy, false, DeepLoadType.IncludeChildren,
                                                                  typeof(TList<AV001_TDI_BIL_IS>));
            ucGorevGrid1.MyDataSource = MyHazirlikFoy.AV001_TDI_BIL_ISCollection_From_NN_IS_HAZIRLIK;

            ucGorevGrid1.SelectedRecord = MyHazirlikFoy;
            ucGorevGrid1.SelectedRecordId = MyHazirlikFoy.ID;
        }

        private void ucHazirlikSikayetNeden1_GridFocusedRowChanged(object sender, EventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN sNeden =
                (AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN)ucHazirlikSikayetNeden1.grdSikayetNeden.GetFocusedRow();
            if (sNeden != null)
                NedeneBagliDetayGetir(sNeden);
        }

        private void ucSorusturmaGridler_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            //LOAD
            CheckForIllegalCrossThreadCalls = false;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Name == "xtabpMuvekkilDosyaHesabi")
            {
                if (!AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue) return;

                DataTable hesaplar = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayBySorusturmaFoyId(MyHazirlikFoy.ID);

                ucMuhasebeGenel2.MyMuvekkilCariHesapDetayli = hesaplar;
                if (ucMuhasebeGenel2.ucPivotChart1 != null)
                    ucMuhasebeGenel2.ucPivotChart1.MyCarHesapDetayliArama = hesaplar;
            }
            else if (e.Page.Name == "xtabPMuvekkilinTumHesabi")
            {
                if (!AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue) return;

                DataTable hesaplar = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayBySorusturmaTaraf(MyHazirlikFoy.ID);
                ucMuhasebeGenel2.MyMuvekkilCariHesapDetayli = hesaplar;

                if (ucMuhasebeGenel2.ucPivotChart1 != null)
                    ucMuhasebeGenel2.ucPivotChart1.MyCarHesapDetayliArama = hesaplar;
            }
        }

        private void xtraTabControl3_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.xTabMuvekkMuh.Name)
            {
                #region DosyaMuhasebesi kontrol ve muyasebeleþtirme ekranýna gönderme

                decimal? carilestirilebilirToplam = AvukatPro.Services.Implementations.MuhasebeService.GetMuhasebeBirlesikDetayliByFoyId(MyHazirlikFoy.ID, 2).Select(m => m.MuhasebelestirilmemisMiktar).Sum();

                if (carilestirilebilirToplam > 0)
                {
                    if (XtraMessageBox.Show(
                   "Bu dosyada dosya muhasebesine aktarýlmýþ ancak müvekkiller adýna muhasebeleþtirilmemiþ kayýtlar bulunmaktadýr.\nÞimdi muhasebeleþtirmek istiyormusunuz?",
                   "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        frmDosyaMuhasebelestirme frm = new frmDosyaMuhasebelestirme(3, MyHazirlikFoy.ID);
                        frm.MdiParent = AnaForm.mdiAvukatPro.MainForm;
                        frm.Show();
                    }
                }

                #endregion DosyaMuhasebesi kontrol ve muyasebeleþtirme ekranýna gönderme
            }
        }
    }
}