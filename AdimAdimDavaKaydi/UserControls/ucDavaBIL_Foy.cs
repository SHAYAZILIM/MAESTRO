//#define tmpTOTALOZEL
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util;
using AvukatProLib;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucDavaBIL_Foy : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public List<AvukatProLib.Arama.VTD_DAVA_DOSYALAR> MyDataSource
        {
            get
            {
                if (gridDavaBIL_Foy.DataSource is List<AvukatProLib.Arama.VTD_DAVA_DOSYALAR>)
                    return (List<AvukatProLib.Arama.VTD_DAVA_DOSYALAR>)gridDavaBIL_Foy.DataSource;

                return null;
            }
            set
            {
#if tmpTOTALOZEL
                if (value != null && AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI != "MERKEZ")
                {
                    value.Filter = "REFERANS_NO2 = '" + AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI + "'";
                }
#endif
                gridDavaBIL_Foy.DataSource = value;
                extendedGridControl1.DataSource = gridDavaBIL_Foy.DataSource;
            }
        }

        public ucDavaBIL_Foy()
        {
            InitializeComponent();
            gridView1.CustomSummaryCalculate += gridView1_CustomSummaryCalculate;
            gridDavaBIL_Foy.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            gridDavaBIL_Foy.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
            gridView1.DoubleClick += gridView1_DoubleClick;
        }

        public void FilitreleriTemizle()
        {
            gridView1.ActiveFilter.Clear();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            AvukatProLib.Arama.VTD_DAVA_DOSYALAR foy = gridView1.GetFocusedRow() as AvukatProLib.Arama.VTD_DAVA_DOSYALAR;
            if (foy == null) return;

            DialogResult result =
                XtraMessageBox.Show(string.Format("{0} Numaralý Dosya Takip Ekranýna Gönderilsin mi?", foy.FOY_NO),
                                    "Takip Ekranýna Gönder", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DavaTakip.frmDavaTakip davaFormu = new AdimAdimDavaKaydi.DavaTakip.frmDavaTakip();
                davaFormu.Show(foy.ID);
            }
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            #region AdresVeÝletiþimBilgileri

            if (e.Column != null && e.Column.FieldName == "SORUMLU_AVUKAT_CARI_ID")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kiþinin");

                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve Ýletiþim Bilgileri");
                //barBtnSecimiKaldir.Tag = e.Column;

                bus.ItemLinks.Add(barBtnSecimiKaldir);

                AV001_TD_BIL_FOY_SORUMLU_AVUKAT secim = e.Rows as AV001_TD_BIL_FOY_SORUMLU_AVUKAT;

                int? id = secim.SORUMLU_AVUKAT_CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                e.MyPopupMenu.ItemLinks.Add(bus);
            }
            else if (e.Column != null && e.Column.FieldName == "CARI_ID")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kiþinin");

                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve Ýletiþim Bilgileri");
                //barBtnSecimiKaldir.Tag = e.Column;

                bus.ItemLinks.Add(barBtnSecimiKaldir);

                AV001_TD_BIL_FOY_TARAF secim = e.Rows as AV001_TD_BIL_FOY_TARAF;

                int? id = secim.CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                e.MyPopupMenu.ItemLinks.Add(bus);
            }

            #endregion

            #region u Kayda Geliþme Ekle

            if (e.Rows is AV001_TD_BIL_FOY)
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kayda Geliþme Ekle");

                BarButtonItem barDavaNedeni = new BarButtonItem(e.Manager, "Dava Nedeni");
                BarButtonItem barDurusma = new BarButtonItem(e.Manager, "Duruþma");
                BarButtonItem barAraKarar = new BarButtonItem(e.Manager, "Ara Karar");
                BarButtonItem barHukum = new BarButtonItem(e.Manager, "Hüküm");
                BarButtonItem barTemyiz = new BarButtonItem(e.Manager, "Temyiz");
                BarButtonItem barDusmeYenileme = new BarButtonItem(e.Manager, "Düþme Yenileme");
                BarButtonItem barIhtiyatiTedbir = new BarButtonItem(e.Manager, "Ihtiyati Tedbir");
                BarButtonItem barMasrafAvans = new BarButtonItem(e.Manager, "Masraf Avans");
                BarButtonItem barTutuklama = new BarButtonItem(e.Manager, "Tutuklama");
                BarButtonItem barKanit = new BarButtonItem(e.Manager, "Kanýt");
                BarButtonItem barExMasrafAvans = new BarButtonItem(e.Manager, "Masraf Avans (Hýzlý)");
                BarButtonItem barEditorSihirbaz = new BarButtonItem(e.Manager, "Editöre Gönder (Hýzlý)");
                BarButtonItem barKlasorGotur = new BarButtonItem(e.Manager, "Klasöre Gönder");

                barDavaNedeni.Tag = e.Rows;
                barDurusma.Tag = e.Rows;
                barAraKarar.Tag = e.Rows;
                barHukum.Tag = e.Rows;
                barTemyiz.Tag = e.Rows;
                barDusmeYenileme.Tag = e.Rows;
                barIhtiyatiTedbir.Tag = e.Rows;
                barMasrafAvans.Tag = e.Rows;
                barTutuklama.Tag = e.Rows;
                barKanit.Tag = e.Rows;
                barExMasrafAvans.Tag = e.Rows;
                barEditorSihirbaz.Tag = e.Rows;
                barKlasorGotur.Tag = e.Rows;

                bus.ItemLinks.AddRange(new BarItem[]
                                           {
                                               barDavaNedeni,
                                               barDurusma,
                                               barAraKarar,
                                               barHukum,
                                               barDusmeYenileme,
                                               barTemyiz,
                                               barIhtiyatiTedbir,
                                               barMasrafAvans,
                                               barExMasrafAvans,
                                               barEditorSihirbaz,
                                               barKlasorGotur,
                                               barKanit,
                                               barTutuklama
                                           });
                e.MyPopupMenu.AddItem(bus);
            }

            #endregion
        }

        private AV001_TD_BIL_FOY gelenFoy;

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                #region Bu Kayda Ekle

                if (e.Item.Name == bBtnSorusturmaEkle.Name)
                {
                    AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris frmSorusturma =
                        new AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris();
                    // frmSorusturma.MdiParent = null;
                    frmSorusturma.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmSorusturma.Show();
                }
                else if (e.Item.Name == bBtnIcraEkle.Name)
                {
                    AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit frmicraDosyaKayit =
                        new AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit();
                    //frmicraDosyaKayit.MdiParent = null;
                    frmicraDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmicraDosyaKayit.Show();
                }
                else if (e.Item.Name == bBtnSozlesmeEkle.Name)
                {
                    AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit frmsozlesmeKayit =
                        new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit();
                    //frmsozlesmeKayit.MdiParent = null;
                    frmsozlesmeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmsozlesmeKayit.Show();
                }
                else if (e.Item.Name == bBSahis.Name)
                {
                    frmCariGenelGiris cGiris = new frmCariGenelGiris();
                    cGiris.YeniKayitMi = true;
                    //cGiris.MdiParent = null;
                    cGiris.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    cGiris.Show();
                }
                else if (e.Item.Name == bBTemsilEkle.Name)
                {
                    frmTemsilKayit tKayit = new frmTemsilKayit();
                    // tKayit.MdiParent = null;
                    tKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    tKayit.Show();
                }
                else if (e.Item.Name == bBtnDavaEkle.Name)
                {
                    AdimAdimDavaKaydi.frmDavaDosyaKayitForm frmdavaDosyaKayit = new frmDavaDosyaKayitForm();
                    // frmdavaDosyaKayit.MdiParent = null;
                    frmdavaDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmdavaDosyaKayit.Show();
                }

                else if (e.Item.Name == bButonBelgeEkle.Name)
                {
                    if (e.Item.Tag is AV001_TD_BIL_FOY)
                    {
                        AV001_TD_BIL_FOY takip = e.Item.Tag as AV001_TD_BIL_FOY;

                        string tablob = "AV001_TD_BIL_FOY";
                        bool islemYap = true;
                        if (islemYap)
                        {
                            if (takip.ID != null)
                            {
                                frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();
                                belgeKayit.SetByTableNameAndId(tablob, takip.ID);
                                //.MdiParent = null;
                                belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                belgeKayit.Show();
                            }
                        }
                    }
                }

                else if (e.Item.Name == bButonIsEkle.Name)
                {
                    if (e.Item.Tag is AV001_TD_BIL_FOY)
                    {
                        AV001_TD_BIL_FOY takip = e.Item.Tag as AV001_TD_BIL_FOY;
                        string tabloI = "AV001_TD_BIL_FOY";
                        AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit =
                            new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();

                        frmisKayit.SetByTableNameAndId(tabloI, takip.ID);
                        //frmisKayit.MdiParent = null;
                        frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frmisKayit.Show();
                    }
                }

                else if (e.Item.Name == bButtonNotEkle.Name)
                {
                    //if (e.Item.Tag is AV001_TD_BIL_FOY)
                    //{
                    //    AV001_TD_BIL_FOY takip = e.Item.Tag as AV001_TD_BIL_FOY;
                    //    bool islemYap = true;
                    //    if (takip.ID != null && islemYap)
                    //    {
                    //        string tabloB = "AV001_TD_BIL_FOY";
                    //        AdimAdimDavaKaydi.CustomControls.frmYeniNot d = new AdimAdimDavaKaydi.CustomControls.frmYeniNot();
                    //        d.ShowDialog(tabloB, takip.ID);

                    //    }
                    //}
                }
                else if (e.Item.Name == bButtonGorusmeEkle.Name)
                {
                    bool islemYap = true;
                    if (e.Item.Tag is AV001_TD_BIL_FOY)
                    {
                        AV001_TD_BIL_FOY takip = e.Item.Tag as AV001_TD_BIL_FOY;
                        if (!islemYap)
                            return;

                        AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit gorsumeForms =
                            new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();

                        gorsumeForms.ShowDialog(AvukatProLib.Extras.ModulTip.Dava, takip.ID);
                    }
                }

                else if (e.Item.Name == bButonKisayolEkle.Name)
                {
                    AV001_TD_BIL_FOY takip = e.Item.Tag as AV001_TD_BIL_FOY;

                    if (takip.ID != null)
                    {
                        #region <KA-20090709>

                        //Kisayol oluþturma tek bir yere çekildi daðýnýklýk giderildi.
                        Kisayol.CreateShortCut(takip.ID, Kisayol.AcilisSekli.DavaTakip);

                        #endregion </KA-20090709>
                    }

                    //if (e.Item.Tag is AV001_TD_BIL_FOY)
                    //{
                    //    AV001_TD_BIL_FOY takip = e.Item.Tag as AV001_TD_BIL_FOY;
                    //    string dosyaUzantisi = string.Empty;
                    //    if (takip.ID != null)
                    //    {
                    //        dosyaUzantisi = "Dava Dosyasý (*.avpd)|*.AVPD";
                    //        string kaydedilecek = takip.ID.ToString();

                    //        SaveFileDialog sfd = new SaveFileDialog();
                    //        sfd.Filter = dosyaUzantisi;

                    //        DialogResult sonuc = sfd.ShowDialog();
                    //        if (sonuc == DialogResult.OK)
                    //        {
                    //            try
                    //            {
                    //                byte[] veri = System.Text.Encoding.UTF8.GetBytes(kaydedilecek);

                    //                Tools.SaveTofile(sfd.FileName, veri);
                    //            }
                    //            catch (Exception ex)
                    //            {
                    //                BelgeUtil.ErrorHandler.Catch(this, ex);
                    //            }
                    //        }
                    //    }
                    //}
                }
                else if (e.Item.Name == bButtonSikKullanilan.Name)
                {
                    if (e.Item.Tag is AV001_TD_BIL_FOY)
                    {
                        AV001_TD_BIL_FOY takip = e.Item.Tag as AV001_TD_BIL_FOY;
                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(takip, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<TDI_KOD_ADLI_BIRIM_ADLIYE>),
                                                                         typeof(TList<TDI_KOD_ADLI_BIRIM_GOREV>),
                                                                         typeof(TList<TDI_KOD_ADLI_BIRIM_NO>));
                        AvukatProLib.Extras.ModulTip tablo =
                            AvukatProLib.Extras.ModulTip.Dava;
                        string adliye = string.Empty;
                        string gorev = string.Empty;
                        string no = string.Empty;
                        if (takip.ADLI_BIRIM_ADLIYE_IDSource != null)
                            adliye = takip.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                        if (takip.ADLI_BIRIM_GOREV_IDSource != null)
                            gorev = takip.ADLI_BIRIM_GOREV_IDSource.GOREV;
                        if (takip.ADLI_BIRIM_NO_IDSource != null)
                            no = takip.ADLI_BIRIM_NO_IDSource.NO;
                        string AD = string.Format("{0} {1} {2} {3}E. nolu Dosyasý", adliye, gorev, no, takip.ESAS_NO);
                        rfrmSikKullanilanEkle frm = new rfrmSikKullanilanEkle();
                        //frm.MdiParent = null;
                        frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm.Show(tablo, takip.ID, AD);
                    }
                }

                #endregion

                else
                {
                    if (e.Item.Tag is AvukatProLib.Arama.VTD_DAVA_DOSYALAR)
                    {
                        gelenFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((e.Item.Tag as AvukatProLib.Arama.VTD_DAVA_DOSYALAR).ID);
                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(gelenFoy, true);
                        switch (e.Item.Caption)
                        {
                            case "Dava Nedeni":
                                frmDavaNedenGirisi DavaNeden = new frmDavaNedenGirisi();
                                DavaNeden.Show(gelenFoy);
                                break;
                            case "Duruþma":
                                rFrmCelseKayit CelseKayit = new rFrmCelseKayit();
                                CelseKayit.Show(gelenFoy);
                                break;
                            case "Ara Karar":
                                rfrmAraKararKayit AraKararKayit = new rfrmAraKararKayit();
                                AraKararKayit.Show(gelenFoy);
                                break;
                            case "Hüküm":
                                frmHukumGirisi HukumGirisi = new frmHukumGirisi();
                                HukumGirisi.Show(gelenFoy);
                                break;
                            case "Temyiz":
                                frmTemyizEkle TemyizEkle = new frmTemyizEkle();
                                TemyizEkle.Show(gelenFoy);
                                break;
                            case "Düþme Yenileme":
                                MessageBox.Show("Bu Bölüm Yapým Aþamasýnda");
                                break;
                            case "Ihtiyati Tedbir":
                                FoyIhtiyatiTedbir(gelenFoy);
                                break;
                            case "Masraf Avans":
                                AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris frmMasrafKaydet =
                                    new AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris();
                                frmMasrafKaydet.Show(gelenFoy);
                                break;
                            case "Tutuklama":
                                rfrmTutuklanma Tutuklanma = new rfrmTutuklanma();
                                Tutuklanma.Show(gelenFoy);
                                break;
                            case "Kanýt":
                                frmKanitGirisi KanitGirisi = new frmKanitGirisi();

                                KanitGirisi.Show(gelenFoy);
                                break;
                            case "Masraf Avans (Hýzlý)":
                                AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli marForms =
                                    new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
                                marForms.Show(gelenFoy);
                                break;
                            case "Editöre Gönder (Hýzlý)":
                                List<AvukatProLib.Arama.VTD_DAVA_DOSYALAR> foyList = GetSelectedFoy(MyDataSource);
                                Editor.Forms.frmAdimAdimEditoreGonder frmEditor =
                                    new AdimAdimDavaKaydi.Editor.Forms.frmAdimAdimEditoreGonder();
                                frmEditor.Show(foyList);
                                break;
                            case "Klasöre Gönder":
                                //AdimAdimDavaKaydi.Forms.KlasorHelper.KlasoreGonder(Modul.Dava, gelenFoy.ID);
                                break;
                        }
                    }
                }
            }
        }

        private frmDavaIcraIhtiyatiTedbir frmTedbir;

        private void FoyIhtiyatiTedbir(AV001_TD_BIL_FOY MyFoy)
        {
            if (MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection == null)
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();
            MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.AddingNew +=
                AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_AddingNew;

            frmTedbir = new frmDavaIcraIhtiyatiTedbir();
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                             typeof(TList<AV001_TD_BIL_FOY_TARAF>));
            frmTedbir.MyDavaFoy = MyFoy;
            frmTedbir.MyDataSource = MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;
            //frmTedbir.MdiParent = null;
            frmTedbir.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frmTedbir.Show();
        }

        private void AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_IHTIYATI_TEDBIR tdbr = new AV001_TDI_BIL_IHTIYATI_TEDBIR();
            tdbr.ADLI_BIRIM_GOREV_ID = DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.Find("GOREV = 'AHM'")[0].ID;
            tdbr.TALEP_TARIHI = DateTime.Now;
            tdbr.KARAR_TARIHI = tdbr.TALEP_TARIHI;
            tdbr.TEMINAT_TUR_ID = 1;
            tdbr.TEMINAT_TUTARI_DOVIZ_ID = 1;

            tdbr.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>();
            foreach (AV001_TD_BIL_FOY_TARAF taraf in gelenFoy.AV001_TD_BIL_FOY_TARAFCollection)
            {
                AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF trf = tdbr.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.AddNew();
                trf.ICRA_CARI_TARAF_ID = taraf.CARI_ID;
                trf.DAVA_TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
            }
            frmTedbir.MyTaraf = tdbr.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection;
            if (tdbr.DAVA_TARIHI != null)
                tdbr.DAVA_TARIHI = DateTime.Now;
            tdbr.KAYIT_TARIHI = DateTime.Now;
            tdbr.KONTROL_NE_ZAMAN = DateTime.Now;
            tdbr.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            tdbr.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            tdbr.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            tdbr.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = tdbr;
        }

        private void barBtnSecimiKaldir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                int cariId = (int)e.Item.Tag;

                AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cariId);
                AdimAdimDavaKaydi.frmCariGenelGiris cariForms = new frmCariGenelGiris();
                cariForms.YeniKayitMi = false;
                cariForms.MyCariId = cariId;
                //.MdiParent = null;
                cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cariForms.Show();
            }
        }

        public void SagTusaEkle()
        {
            gridDavaBIL_Foy.RightClickPopup.LinkPersist = new DevExpress.XtraBars.LinksInfo();
            foreach (DevExpress.XtraBars.LinkPersistInfo var in popupMenu1.LinksPersistInfo)
            {
                gridDavaBIL_Foy.RightClickPopup.LinkPersist.Add(var);
            }
        }

        //TList<AV001_TD_BIL_FOY> MyDataSourceDavaFoy = new TList<AV001_TD_BIL_FOY>();
        private void ucDavaBIL_Foy_Load(object sender, EventArgs e)
        {
            //Load
            if (!this.DesignMode)
            {
                gridDavaBIL_Foy.ShowOnlyPredefinedDetails = true;

                gridDavaBIL_Foy.ButtonCevirClick += gridDavaBIL_Foy_ButtonCevirClick;
                extendedGridControl1.ButtonCevirClick += gridDavaBIL_Foy_ButtonCevirClick;

                BelgeUtil.Inits.AsamaKodGetir(rLueDavaAsamalari);
                BelgeUtil.Inits.DavaTalepGetir(rLueDavaTalep);
                BelgeUtil.Inits.DavaTalepGetir(rLueDavaTalepGetir);
                BelgeUtil.Inits.perCariGetir(rLueCelseCariler);
                BelgeUtil.Inits.IncelemeTurGetir(rLueCelseIncelemeTur);
                BelgeUtil.Inits.CariSifatGetir(rLueDavaFoyTarafSifat);
                BelgeUtil.Inits.AsamaKodGetir(rLueDavaAsamalari2);
                BelgeUtil.Inits.AdliBirimBolumDoldur(rLueDavaTip);
                BelgeUtil.Inits.AdliBirimBolumDoldur(rLueDavaTipGetir);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliyeGetir);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorevGetir);
                BelgeUtil.Inits.FoyDurumGetir(rLueFoyDurum);
                BelgeUtil.Inits.FoyDurumGetir(rLueFoyDurumGetir);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueBirimNo);
                BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKodlar);
                BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKod);
                BelgeUtil.Inits.perCariGetir(rLueCelseCariler);
                BelgeUtil.Inits.SorumluTipGetir(rLueSorumluTipAvukatmi);
                BelgeUtil.Inits.TarafKoduEnumGetir(rLueTarafKodu);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
                BelgeUtil.Inits.DavaTipleriResimliGetir(rLueDavaTipResimli);

                #region Ozellestirme

                if (layoutView1.Columns["DAVA_OZEL_KOD1"] != null)
                    layoutView1.Columns["DAVA_OZEL_KOD1"].Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod1;
                if (layoutView1.Columns["DAVA_OZEL_KOD2"] != null)
                    layoutView1.Columns["DAVA_OZEL_KOD2"].Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod2;
                if (layoutView1.Columns["DAVA_OZEL_KOD3"] != null)
                    layoutView1.Columns["DAVA_OZEL_KOD3"].Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod3;
                if (layoutView1.Columns["DAVA_OZEL_KOD4"] != null)
                    layoutView1.Columns["DAVA_OZEL_KOD4"].Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod4;
                if (gridView1.Columns["DAVA_OZEL_KOD1"] != null)
                    gridView1.Columns["DAVA_OZEL_KOD1"].Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod1;
                if (gridView1.Columns["DAVA_OZEL_KOD2"] != null)
                    gridView1.Columns["DAVA_OZEL_KOD2"].Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod2;
                if (gridView1.Columns["DAVA_OZEL_KOD3"] != null)
                    gridView1.Columns["DAVA_OZEL_KOD3"].Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod3;
                if (gridView1.Columns["DAVA_OZEL_KOD4"] != null)
                    gridView1.Columns["DAVA_OZEL_KOD4"].Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod4;

                #endregion

                SagTusaEkle();
            }
            DovizBirimKolonlariniBul(gridView1);
        }

        private void gridDavaBIL_Foy_ButtonCevirClick(object sender,
                                                      DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (gridDavaBIL_Foy.Visible)
            {
                extendedGridControl1.Visible = true;
                gridDavaBIL_Foy.Visible = false;
            }
            else
            {
                extendedGridControl1.Visible = false;
                gridDavaBIL_Foy.Visible = true;
            }
        }

        private List<AvukatProLib.Arama.VTD_DAVA_DOSYALAR> seciliDavaKayitlari;

        public List<AvukatProLib.Arama.VTD_DAVA_DOSYALAR> GetSelectedFoy(List<AvukatProLib.Arama.VTD_DAVA_DOSYALAR> foy)
        {
            seciliDavaKayitlari = new List<AvukatProLib.Arama.VTD_DAVA_DOSYALAR>();
            foreach (AvukatProLib.Arama.VTD_DAVA_DOSYALAR f in foy)
            {
                if (f.IsSelected)
                    seciliDavaKayitlari.Add(f);
            }
            return seciliDavaKayitlari;
        }

        private void lookUpExtender1_OnClickOrProcessNewValue(object sender, LookUpExtenderEventArgs e)
        {
            if (e.SenderLookUp != null)
                if (e.SenderLookUp.Properties.Name.Contains("OzelKod") && e.IsTypedValue)
                {
                    try
                    {
                        AV001_TDI_KOD_FOY_OZEL ozel = new AV001_TDI_KOD_FOY_OZEL();

                        ozel.KOD = e.TypedValue;
                        AvukatProLib2.Data.DataRepository.AV001_TDI_KOD_FOY_OZELProvider.Save(ozel);
                        ((TList<AV001_TDI_KOD_FOY_OZEL>)e.SenderLookUp.Properties.DataSource).Add(ozel);
                        XtraMessageBox.Show("Özel Kod baþarýyla eklenmiþtir.");
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }

            if (e.SenderLookUp.Properties.Name.Contains("Cari") && e.IsTypedValue)
            {
                try
                {
                    frmCariGenelGiris frm = new frmCariGenelGiris();
                    if (e.IsTypedValue)
                        frm.tmpCariAd = e.TypedValue;

                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.Show();
                    frm.FormClosed += delegate
                                          {
                                              DialogResult dr = frm.KayitBasarili;
                                              if (dr == System.Windows.Forms.DialogResult.OK)
                                              {
                                                  BelgeUtil.Inits.perCariGetir(e.SenderLookUp.Properties);
                                              }
                                          };
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        #region Dava Giriþ Ýçin Arama Metodlar

        private TList<AV001_TD_BIL_FOY> foylist2 = new TList<AV001_TD_BIL_FOY>();
        private List<int> id = new List<int>();

        public void FiltrelemeGridFoy(string fieldName, string filtre)
        {
            TList<AV001_TD_BIL_FOY> foylist = new TList<AV001_TD_BIL_FOY>();
            TList<AV001_TD_BIL_FOY> temp = new TList<AV001_TD_BIL_FOY>();
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                AV001_TD_BIL_FOY foy = (AV001_TD_BIL_FOY)gridView1.GetRow(i);

                foylist.Add(foy);
            }
            if (fieldName != string.Empty)
            {
                foylist.Filter = string.Empty;
                temp = foylist.FindAll(AV001_TD_BIL_FOYColumn.ESAS_NO, filtre);
            }
            else
            {
                foylist.Filter = filtre;
                temp = foylist;
            }

            foylist2 = temp;
            gridDavaBIL_Foy.DataSource = foylist2;
        }

        public void FiltreleGridFoyDurum(string fieldName, string filtrele)
        {
            TList<AV001_TD_BIL_FOY> foylist = gridDavaBIL_Foy.DataSource as TList<AV001_TD_BIL_FOY>;
            TList<AV001_TD_BIL_FOY_OZEL_KOD> ozllist = new TList<AV001_TD_BIL_FOY_OZEL_KOD>();
            ozllist.Filter = filtrele;

            id.Clear();
            foreach (AV001_TD_BIL_FOY_OZEL_KOD ozlKod in ozllist)
            {
                if (ozlKod.DAVA_FOY_ID.HasValue)
                    id.Add((int)ozlKod.DAVA_FOY_ID);
            }
            for (int i = 0; i <= foylist.Count - 1; i++)
            {
                for (int j = 0; j <= id.Count - 1; j++)
                {
                    if (foylist[i].ID == id[j])
                    {
                        if (!foylist2.Contains(foylist[i]))
                            foylist2.Add(foylist[i]);
                    }
                }
            }
            gridDavaBIL_Foy.DataSource = foylist2;
        }

        #endregion

        #region Alt Toplamlarla Ýlgili Çalýþmalar

        private Dictionary<int, decimal> paralar = new Dictionary<int, decimal>();
        private List<int> DovizListesi = new List<int>();

        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.GridSummaryItem summaryItem = e.Item as DevExpress.XtraGrid.GridSummaryItem;

            if (true) //(summaryItem.Tag is int)
            {
                #region Para

                if (!summaryItem.FieldName.Contains("_DOVIZ_ID"))
                {
                    if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                    {
                        paralar.Clear();
                    }
                    else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                    {
                        int? dovizId =
                            (int?)
                            view.GetRowCellValue(e.RowHandle,
                                                 ((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName + "_DOVIZ_ID");
                        if (dovizId != null)
                        {
                            if (paralar.ContainsKey(dovizId.Value))
                            {
                                paralar[dovizId.Value] += (decimal)e.FieldValue;
                            }
                            else
                            {
                                paralar.Add(dovizId.Value, (decimal)e.FieldValue);
                            }
                        }
                        else if (dovizId == null)
                        {
                            if (paralar.ContainsKey(1))
                            {
                                paralar[1] += (decimal)e.FieldValue;
                            }
                            else
                            {
                                paralar.Add(1, (decimal)e.FieldValue);
                            }
                        }
                        else
                        {
                            //Bir Terslik Var
                        }
                    }
                    else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                    {
                        decimal toplam = 0;

                        string fieldName = string.Empty;
                        if (paralar.Count > 1)
                        {
                            foreach (KeyValuePair<int, decimal> para in paralar)
                            {
                                decimal kur = DovizHelper.CevirYTL(para.Value, para.Key, DateTime.Today);
                                ;
                                //double tlTutari = kur * para.Value;
                                toplam += kur;
                            }
                        }
                        else if (paralar.Count == 1)
                        {
                            foreach (KeyValuePair<int, decimal> item in paralar)
                            {
                                toplam = item.Value;
                            }
                        }
                        string yazdirilacakAlan = toplam.ToString();
                        e.TotalValue = toplam;
                    }
                }

                #endregion

                #region Birim

                else if (summaryItem.FieldName.Contains("_DOVIZ_ID"))
                {
                    if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                    {
                        DovizListesi.Clear();
                    }
                    else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                    {
                        if (e.FieldValue != null)
                        {
                            if (!DovizListesi.Contains(int.Parse(e.FieldValue.ToString())))
                            {
                                DovizListesi.Add(int.Parse(e.FieldValue.ToString()));
                            }
                        }
                        else
                        {
                            if (!DovizListesi.Contains(1))
                            {
                                DovizListesi.Add(1);
                            }
                        }
                    }
                    else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                    {
                        if (DovizListesi.Count > 1)
                        {
                            e.TotalValue = DovizHelper.CevirString(1);
                        }
                        else if (DovizListesi.Count == 1)
                        {
                            e.TotalValue = DovizHelper.CevirString(DovizListesi[0]);
                            // ParaBirimiVer(int.Parse(e.FieldValue.ToString()));
                        }
                        else
                        {
                            e.TotalValue = "Birim Seçilmemiþ";
                        }
                    }
                }

                #endregion
            }
        }

        /// <summary>
        /// Doviz Birimi olan kolonlarýn taþýma esnasýnda döviz birim kolonlarýnýda yanlarýnda taþýmalarý için
        /// taglarýna bu kolonlar hakkýnda bilgi yerleþtirir
        /// </summary>
        private void DovizBirimKolonlariniBul(GridView grid)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                string kolonAdi = grid.Columns[i].FieldName;
                if (kolonAdi.EndsWith("_DOVIZ_ID"))
                {
                    string abiKolonAdi = kolonAdi.Replace("_DOVIZ_ID", "");

                    GridColumn abiKolon = grid.Columns[abiKolonAdi];

                    if (abiKolon != null)
                    {
                        abiKolon.Tag = grid.Columns[i];
                        grid.Columns[i].Tag = abiKolon;
                    }
                }
            }
        }

        #endregion
    }
}