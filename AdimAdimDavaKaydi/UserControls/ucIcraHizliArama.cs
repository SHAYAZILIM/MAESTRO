using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Util;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucIcraHizliArama : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucIcraHizliArama()
        {
            InitializeComponent();
            gcIcraFoy.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
            gcIcraFoy.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            gcIcraFoy.DoubleClick += gcIcraFoy_DoubleClick;
            this.Load += ucIcraFoy_Load;
        }

        private AV001_TI_BIL_FOY gelenFoy;

        private void RightClickPopup_PopupButtonClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                #region Bu Kayda Ekle

                if (e.Item.Name == bBtnSorusturmaEkle.Name)
                {
                    AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris frmSorusturma =
                        new AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris();
                    frmSorusturma.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmSorusturma.Show();
                }
                else if (e.Item.Name == bBtnIcraEkle.Name)
                {
                    AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit frmicraDosyaKayit =
                        new AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit();
                    frmicraDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmicraDosyaKayit.Show();
                }
                else if (e.Item.Name == bBtnSozlesmeEkle.Name)
                {
                    AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit frmsozlesmeKayit =
                        new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit();
                    frmsozlesmeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmsozlesmeKayit.Show();
                }
                else if (e.Item.Name == bBSahis.Name)
                {
                    frmCariGenelGiris cGiris = new frmCariGenelGiris();
                    cGiris.YeniKayitMi = true;
                    cGiris.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    cGiris.Show();
                }
                else if (e.Item.Name == bBTemsilEkle.Name)
                {
                    frmTemsilKayit tKayit = new frmTemsilKayit();
                    tKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    tKayit.Show();
                }
                else if (e.Item.Name == bBtnDavaEkle.Name)
                {
                    AdimAdimDavaKaydi.frmDavaDosyaKayitForm frmdavaDosyaKayit = new frmDavaDosyaKayitForm();
                    frmdavaDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmdavaDosyaKayit.Show();
                }

                else if (e.Item.Name == bButonBelgeEkle.Name)
                {
                    if (e.Item.Tag is AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA)
                    {
                        AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA genel = e.Item.Tag as AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA;
                        AV001_TI_BIL_FOY takip = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(genel.ID);
                        AV001_TI_BIL_FOY_TARAF t = new AV001_TI_BIL_FOY_TARAF();

                        string tablob = "AV001_TI_BIL_FOY";
                        bool islemYap = true;
                        if (islemYap)
                        {
                            if (takip.ID != null)
                            {
                                frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();
                                belgeKayit.ucBelgeKayitUfak1.OpenedRecord = takip;
                                belgeKayit.SetByTableNameAndId(tablob, takip.ID);
                                //belgeKayit.MdiParent = null;
                                belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                belgeKayit.Show();
                            }
                        }
                    }
                }
                else if (e.Item.Name == bButonIsEkle.Name)
                {
                    if (e.Item.Tag is AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA)
                    {
                        AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA genel = e.Item.Tag as AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA;
                        AV001_TI_BIL_FOY takip = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(genel.ID);

                        AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit =
                            new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
                        frmisKayit.ucIsKayitUfak1.ModulID = 1;
                        frmisKayit.ucIsKayitUfak1.OpenedRecord = takip;
                        frmisKayit.ucIsKayitUfak1.formTipi = takip.FORM_TIP_ID.Value;
                        frmisKayit.ucIsKayitUfak1.Modul = 1;
                        // frmisKayit.MdiParent = null;
                        frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frmisKayit.Show();
                    }
                }
                else if (e.Item.Name == bButtonNotEkle.Name)
                {
                }
                else if (e.Item.Name == bButtonGorusmeEkle.Name)
                {
                    bool islemYap = true;
                    if (e.Item.Tag is AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA)
                    {
                        AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA genel = e.Item.Tag as AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA;
                        AV001_TI_BIL_FOY takip = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(genel.ID);
                        if (!islemYap)
                            return;

                        AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit gorsumeForms =
                            new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();

                        gorsumeForms.ShowDialog(AvukatProLib.Extras.ModulTip.Icra, takip.ID);
                    }
                }

                else if (e.Item.Name == "bButonKisayolEkle")
                {
                    if (e.Item.Tag is AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA)
                    {
                        AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA genel = e.Item.Tag as AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA;
                        AV001_TI_BIL_FOY takip = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(genel.ID);
                        string dosyaUzantisi = string.Empty;

                        if (takip.ID != null)
                        {
                            #region <KA-20090709>

                            //Kisayol oluşturma tek bir yere çekildi dağınıklık giderildi.
                            Kisayol.CreateShortCut(takip.ID, Kisayol.AcilisSekli.IcraTakip);

                            #endregion </KA-20090709>
                        }
                    }
                }
                else if (e.Item.Name == "bButtonSikKullanilan")
                {
                    if (e.Item.Tag is AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA)
                    {
                        AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA genel = e.Item.Tag as AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA;
                        AV001_TI_BIL_FOY takip = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(genel.ID);
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(takip, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<TDI_KOD_ADLI_BIRIM_ADLIYE>),
                                                                         typeof(TList<TDI_KOD_ADLI_BIRIM_GOREV>),
                                                                         typeof(TList<TDI_KOD_ADLI_BIRIM_NO>));

                        AvukatProLib.Extras.ModulTip tablo =
                            AvukatProLib.Extras.ModulTip.Icra;
                        string adliye = string.Empty;
                        string gorev = string.Empty;
                        string no = string.Empty;
                        if (takip.ADLI_BIRIM_ADLIYE_IDSource != null)
                            adliye = takip.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                        if (takip.ADLI_BIRIM_GOREV_IDSource != null)
                            gorev = takip.ADLI_BIRIM_GOREV_IDSource.GOREV;
                        if (takip.ADLI_BIRIM_NO_IDSource != null)
                            no = takip.ADLI_BIRIM_NO_IDSource.NO;
                        string AD = string.Format("{0} {1} {2} {3}E. nolu Dosyası", adliye, gorev, no, takip.ESAS_NO);

                        rfrmSikKullanilanEkle frm = new rfrmSikKullanilanEkle();
                        //frm.MdiParent = null;
                        frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm.Show(tablo, takip.ID, AD);
                    }
                }
                else if (e.Item.Name == "bButtonKlasorAc")
                {
                    if (e.Item.Tag is AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA)
                    {
                        AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA takip = e.Item.Tag as AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA;
                        TList<AV001_TDIE_BIL_PROJE_ICRA_FOY> icra =
                            DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.GetByICRA_FOY_ID(takip.ID);
                        if (icra.Count > 0)
                        {
                            AV001_TDIE_BIL_PROJE proj = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(icra[0].PROJE_ID);
                            TList<AV001_TDIE_BIL_PROJE> seciliKayitler = new TList<AV001_TDIE_BIL_PROJE>();
                            seciliKayitler.Add(proj);
                            frmKlasorYeni kg = new frmKlasorYeni();
                            //kg.MdiParent = null;
                            kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            kg.Show(seciliKayitler);
                        }
                        else
                        {
                            XtraMessageBox.Show("Bu Dosyaya Ait Klasör Kaydı Bulunmamaktadır", "Uyarı");
                        }
                    }
                }
                else if (e.Item.Name == "bButtonTakipGonder")
                {
                    if (e.Item.Tag is AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA)
                    {
                        AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA takip = e.Item.Tag as AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA;
                        AV001_TI_BIL_FOY icra = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(takip.ID);
                        TList<AV001_TI_BIL_FOY> seciliKayitler = new TList<AV001_TI_BIL_FOY>();
                        seciliKayitler.Add(icra);
                        _frmIcraTakip frmicraTakip = new _frmIcraTakip();
                        frmicraTakip.Show(seciliKayitler);
                    }
                }

                #endregion

                else
                {
                    if (e.Item.Tag is AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA)
                    {
                        AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA genel = e.Item.Tag as AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA;
                        gelenFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(genel.ID);
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(gelenFoy, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                         typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                        switch (e.Item.Caption)
                        {
                            case "Alacak Nedeni":
                                IcraTakipForms.frmAlacakNedenEkle alacakNedenEkle =
                                    new IcraTakipForms.frmAlacakNedenEkle();
                                alacakNedenEkle.Show(gelenFoy);

                                break;
                            case "Mal Beyanı":
                                AdimAdimDavaKaydi.Forms.frmMalBeyani frm = new AdimAdimDavaKaydi.Forms.frmMalBeyani();
                                //this.MyFoy = gelenFoy;
                                frm.Show(gelenFoy);

                                break;
                            case "Ödeme":
                                IcraTakipForms.rFrmTarafOdeme odemeEkle = new IcraTakipForms.rFrmTarafOdeme();
                                odemeEkle.MyGelisme =
                                    AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.
                                        myGelisme;

                                odemeEkle.Show(gelenFoy);
                                break;
                            case "Haciz":
                                Forms.Icra.frmHacizGirisi hacizEkle = new Forms.Icra.frmHacizGirisi();

                                hacizEkle.Show(gelenFoy, null);
                                break;
                            case "Satış":
                                Forms.Icra.frmSatisGirisi satisEkle = new AdimAdimDavaKaydi.Forms.Icra.frmSatisGirisi();
                                gelenFoy.AV001_TI_BIL_SATIS_MASTERCollection.AddingNew +=
                                    AV001_TI_BIL_SATIS_MASTERCollection_AddingNew;
                                satisEkle.MyFoy = gelenFoy;
                                satisEkle.Show(gelenFoy);
                                break;
                            case "Kıymet Taktiri":
                                Forms.Icra.frmKiymetTakdiri kiymetTaktiriEkle =
                                    new AdimAdimDavaKaydi.Forms.Icra.frmKiymetTakdiri();
                                kiymetTaktiriEkle.Show(gelenFoy);

                                break;
                            case "Feragat":
                                AdimAdimDavaKaydi.Forms.Icra.frmFeragatBilgileri frmFeragat =
                                    new AdimAdimDavaKaydi.Forms.Icra.frmFeragatBilgileri();
                                frmFeragat.MyFoy = gelenFoy;
                                frmFeragat.AddNewList = gelenFoy.AV001_TI_BIL_FERAGATCollection;
                                frmFeragat.Show();
                                break;
                            case "Kefil":
                                IcraTakipForms.frmKefaletBilgileri kefalet = new IcraTakipForms.frmKefaletBilgileri();
                                kefalet.Show(gelenFoy);
                                break;
                            case "Masraf Avans":
                                Muhasebe.rfrmMuhasebeGiris masrafGris = new Muhasebe.rfrmMuhasebeGiris();
                                masrafGris.Show(gelenFoy);
                                break;
                            case "İtiraz":
                                IcraTakipForms.rFrmItiraz itirazGiris = new IcraTakipForms.rFrmItiraz();
                                itirazGiris.MyFoy = gelenFoy;
                                itirazGiris.Show(gelenFoy);
                                break;
                            case "Ödeme Planı":
                                UserControls.frmOdemePlani odemePlaniEkle = new frmOdemePlani();
                                odemePlaniEkle.Show(gelenFoy.ID, gelenFoy.FOY_NO);
                                break;
                            case "Düşme Yenileme":
                                IcraTakipForms.frmDusmeYenileme dusmeYenileme = new IcraTakipForms.frmDusmeYenileme();
                                dusmeYenileme.Show(gelenFoy);
                                break;
                            case "Masraf Avans (Hızlı)":
                                AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli marForms =
                                    new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
                                
                                marForms.Show(gelenFoy);
                                break;
                            case "Taahhüt":
                                IcraTakipForms.rFrmTaahhut frmTaahhut = new IcraTakipForms.rFrmTaahhut();
                                frmTaahhut.MyFoy = gelenFoy;
                                frmTaahhut.Show(gelenFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection);
                                break;
                        }
                    }
                }
            }
            else if (e.Item.Tag == null)
            {
                List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> genel = GetSelectedFoy(gcIcraFoy.DataSource as List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA>);
                List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> foyList = new List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA>();
                foreach (AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA item in genel)
                {
                    foyList.Add(item);
                }

                switch (e.Item.Caption)
                {
                    case "Toplu Ödeme Planı Oluştur":
                        frmOdemePlani op = new frmOdemePlani();
                        op.Show(foyList);
                        break;
                    case "Toplu Dosya Hesapla":
                        frmTopluIcraHesapla ti = new frmTopluIcraHesapla();
                        ti.ShowDialog(foyList);
                        break;
                    default:
                        break;
                }
            }
        }

        public static int SiraNo(TList<AV001_TI_BIL_SATIS_MASTER> list)
        {
            if (list.Count == 0)
                return 1;
            else
            {
                list.Sort("SATIS_SIRA_NO DESC");
                return list[0].SATIS_SIRA_NO + 1;
            }
        }

        private void AV001_TI_BIL_SATIS_MASTERCollection_AddingNew(object sender,
                                                                   System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TI_BIL_SATIS_MASTER addNew = e.NewObject as AV001_TI_BIL_SATIS_MASTER;
            if (addNew == null)
                addNew = new AV001_TI_BIL_SATIS_MASTER();

            addNew.ICRA_FOY_ID = gelenFoy.ID;
            addNew.SATIS_SIRA_NO = SiraNo(gelenFoy.AV001_TI_BIL_SATIS_MASTERCollection);
            addNew.SATISIN_ISTENME_SEKLI_ID = 2;
            if (ucIcraTarafBilgileri.BorcluTaraflariGetir(gelenFoy).Count > 0)
                addNew.SATISI_ISTENEN_CARI_ID = ucIcraTarafBilgileri.BorcluTaraflariGetir(gelenFoy)[0].CARI_ID.Value;
            addNew.SATISI_ISTEYEN_CARI_ID = ucIcraTarafBilgileri.AlacakliTaraflariGetir(gelenFoy)[0].CARI_ID.Value;
            addNew.VAKTINDE_MI = false;
            addNew.ILAN_SEKLI = 0;
            addNew.SATIS_ISTEME_TARIHI = DateTime.Now;
            addNew.SATIS_TURU_ID = 1;
            addNew.SATIS_TATILI_VAR_MI = false;

            if (AvukatProLib.Kimlik.Bilgi != null)
                addNew.SATIS_SORUMLU_PERSONEL_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
            else
                addNew.SATIS_SORUMLU_PERSONEL_ID = 3; //AKT

            addNew.SEHIR_ICI_DISI = false;
            addNew.SATIS_TARIHI_1 = DateTime.Now;
            addNew.SATIS_TARIHI_2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 3);
            addNew.SATIS_TATILI_VAR_MI = false;
            addNew.SATIS_TURU_ID = 1;
            addNew.SATISIN_ISTENME_SEKLI_ID = 1;
            addNew.SEHIR_ICI_DISI = true;
            addNew.TALIMAT_MI = false;
            e.NewObject = addNew;
        }

        private void barBtnSecimiKaldir_ItemClick(object sender, ItemClickEventArgs e)
        {
            //BarButtonItem item = e.Item as BarButtonItem;

            if (e.Item.Tag != null)
            {
                int cariId = (int)e.Item.Tag;

                AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cariId);
                AdimAdimDavaKaydi.frmCariGenelGiris cariForms = new frmCariGenelGiris();
                cariForms.YeniKayitMi = false;
                cariForms.MyCariId = cariId;
                // cariForms.MdiParent = null;
                cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cariForms.Show();
            }
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            #region<CC-20090606>

            //Icra Giriş ekran viewe çevrildiğinden dolayı buraya girdiğinde hata veriyordu Gerekli düzenlemelr yapılıp viewden çekilir hale getirildi

            #region Adres Ve İletişim Bilgileri

            if (e.Column != null && e.Column.FieldName == "SORUMLU")
            {
                #region Sorumlu Avukat

                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kişinin");
                bus.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Client_2_22x22;
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve İletişim Bilgileri");
                BarButtonItem barBtnCariRapor = new BarButtonItem(e.Manager, "Bu Şahsın Raporuna Git");
                //barBtnSecimiKaldir.Tag = e.Column;
                barBtnCariRapor.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.rapor02_22;
                barBtnSecimiKaldir.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.personel_isleri;
                bus.ItemLinks.Add(barBtnSecimiKaldir);
                bus.ItemLinks.Add(barBtnCariRapor);
                AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA secim = e.Rows as AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA;

                //AV001_TI_BIL_FOY_SORUMLU_AVUKAT DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.GetByID(secim.SORUMLU_AVUKAT_CARI_ID.Value);

                int? id = secim.SORUMLU_AVUKAT_CARI_ID.Value;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                    barBtnCariRapor.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                barBtnCariRapor.ItemClick += barBtnCariRapor_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(0, bus);

                #endregion
            }
            if (e.Column != null && e.Column.FieldName == "IZLEYEN")
            {
                #region Sorumlu Avukat

                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kişinin");
                bus.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Client_2_22x22;
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve İletişim Bilgileri");
                BarButtonItem barBtnCariRapor = new BarButtonItem(e.Manager, "Bu Şahsın Raporuna Git");
                //barBtnSecimiKaldir.Tag = e.Column;
                barBtnCariRapor.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.rapor02_22;
                barBtnSecimiKaldir.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.personel_isleri;
                bus.ItemLinks.Add(barBtnSecimiKaldir);
                bus.ItemLinks.Add(barBtnCariRapor);
                AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA secim = e.Rows as AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA;

                //AV001_TI_BIL_FOY_SORUMLU_AVUKAT DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.GetByID(secim.SORUMLU_AVUKAT_CARI_ID.Value);
                if (secim != null)
                {
                    int? id = secim.SORUMLU_AVUKAT_CARI_ID;
                    if (id.HasValue)
                    {
                        barBtnSecimiKaldir.Tag = id.Value;
                        barBtnCariRapor.Tag = id.Value;
                    }
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                barBtnCariRapor.ItemClick += barBtnCariRapor_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(1, bus);

                #endregion
            }
            else if (e.Column != null && e.Column.FieldName == "TAKIP_EDEN" || e.Column.FieldName == "TAKIP_EDILEN")
            {
                #region Cari

                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kişinin");
                bus.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Client_2_22x22;
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve İletişim Bilgileri");
                BarButtonItem barBtnCariRapor = new BarButtonItem(e.Manager, "Bu Şahsın Raporuna Git");
                //barBtnSecimiKaldir.Tag = e.Column;
                barBtnCariRapor.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.rapor02_22;
                barBtnSecimiKaldir.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.personel_isleri;
                bus.ItemLinks.Add(barBtnSecimiKaldir);
                bus.ItemLinks.Add(barBtnCariRapor);
                int? id = 0;
                AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA secim = e.Rows as AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA;
                if (e.Column.FieldName == "TAKIP_EDEN")
                    id = secim.CARI_ID;
                else if (e.Column.FieldName == "TAKIP_EDILEN")
                    id = secim.CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                    barBtnCariRapor.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                barBtnCariRapor.ItemClick += barBtnCariRapor_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(2, bus);

                #endregion
            }

            #endregion

            #endregion </CC-20090606>

            #region Bu Kayda Gelişme Ekle

            if (e.Rows is AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA)
            {
                //TODO: Burtdaki Editöre Gönder(Hızlı ) ve Klasöre Gönder Butonları  ExtendedGridControl daki Gonder bölümüne taşınmıştır buradan silinmemiş Comment Edilmiştir.

                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kayda Gelişme Ekle");
                bus.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.application_up_22x22;
                BarButtonItem barAlacakNedeni = new BarButtonItem(e.Manager, "Alacak Nedeni");
                //barAlacakNedeni.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.tahsilat;
                BarButtonItem barMalBeyani = new BarButtonItem(e.Manager, "Mal Beyanı");
                //barMalBeyani.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.haciz1;
                BarButtonItem barOdeme = new BarButtonItem(e.Manager, "Ödeme");
                // barOdeme.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.para_formati;
                BarButtonItem barHaciz = new BarButtonItem(e.Manager, "Haciz");
                //barHaciz.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.haciz2;
                BarButtonItem barSatis = new BarButtonItem(e.Manager, "Satış");
                // barSatis.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.satis;
                BarButtonItem barKiymetTaktiri = new BarButtonItem(e.Manager, "Kıymet Taktiri");
                BarButtonItem barFeragat = new BarButtonItem(e.Manager, "Feragat");
                BarButtonItem barKefil = new BarButtonItem(e.Manager, "Kefil");
                BarButtonItem barMasrafAvans = new BarButtonItem(e.Manager, "Masraf Avans");
                BarButtonItem barItiraz = new BarButtonItem(e.Manager, "İtiraz");
                BarButtonItem barOdemePlani = new BarButtonItem(e.Manager, "Ödeme Planı");
                BarButtonItem barTaahhut = new BarButtonItem(e.Manager, "Taahhüt");
                BarButtonItem barDusmeYenileme = new BarButtonItem(e.Manager, "Düşme Yenileme");
                BarButtonItem barExMasrafAvans = new BarButtonItem(e.Manager, "Masraf Avans (Hızlı)");
                //BarButtonItem barEditorSihirbaz = new BarButtonItem(e.Manager, "Editöre Gönder (Hızlı)");
                //BarButtonItem barKlasorGotur = new BarButtonItem(e.Manager, "Klasöre Gönder");

                barAlacakNedeni.Tag = e.Rows;
                barMalBeyani.Tag = e.Rows;
                barOdeme.Tag = e.Rows;
                barHaciz.Tag = e.Rows;
                barSatis.Tag = e.Rows;
                barKiymetTaktiri.Tag = e.Rows;
                barFeragat.Tag = e.Rows;
                barKefil.Tag = e.Rows;
                barMasrafAvans.Tag = e.Rows;
                barItiraz.Tag = e.Rows;
                barOdemePlani.Tag = e.Rows;
                barDusmeYenileme.Tag = e.Rows;
                barExMasrafAvans.Tag = e.Rows;
                barTaahhut.Tag = e.Rows;
                //barEditorSihirbaz.Tag = e.Rows;
                //barKlasorGotur.Tag = e.Rows;

                bus.ItemLinks.AddRange(new BarItem[]
                                           {
                                               barAlacakNedeni,
                                               barMalBeyani,
                                               barOdeme,
                                               barHaciz,
                                               barSatis,
                                               barKiymetTaktiri,
                                               barFeragat,
                                               barKefil,
                                               barMasrafAvans,
                                               barExMasrafAvans,
                                               barItiraz,
                                               barOdemePlani,
                                               barTaahhut,
                                               barDusmeYenileme
                                               //barEditorSihirbaz,
                                               //barKlasorGotur
                                           });

                BarButtonItem bus2 = new BarButtonItem(e.Manager, "Masa Üstüne Kısayol");
                bus2.Tag = e.Rows;
                bus2.Name = "bButonKisayolEkle";
                bus2.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.masa_ustu16x16;
                BarButtonItem bus3 = new BarButtonItem(e.Manager, "Sık Kullanılanlar");
                bus3.Name = "bButtonSikKullanilan";
                bus3.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.favorite_add_22x221;
                bus3.Tag = e.Rows;
                BarButtonItem bus4 = new BarButtonItem(e.Manager, "Klasörünü Aç");
                bus4.Tag = e.Rows;
                bus4.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.dosya_ac_22x22;
                bus4.Name = "bButtonKlasorAc";
                BarButtonItem bus5 = new BarButtonItem(e.Manager, "Takip Ekranına Gönder");
                bus5.Tag = e.Rows;
                bus5.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.gonder16x16;
                bus5.Name = "bButtonTakipGonder";

                e.MyPopupMenu.ItemLinks.Insert(3, bus);
                e.MyPopupMenu.ItemLinks.Insert(4, bus2);
                e.MyPopupMenu.ItemLinks.Insert(5, bus3);
                e.MyPopupMenu.ItemLinks.Insert(6, bus4);
                e.MyPopupMenu.ItemLinks.Insert(7, bus5);
            }

            #endregion

            List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> genel =
                GetSelectedFoy(gcIcraFoy.DataSource as List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA>);
            TList<AV001_TI_BIL_FOY> foyList = new TList<AV001_TI_BIL_FOY>();
            foreach (AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA item in genel)
            {
                foyList.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(item.ID));
            }

            #region Seçilen Kayıtlarla İşlem Yap

            if (foyList.Count > 0)
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Seçilen Kayıtlara");

                BarButtonItem barAlacakNedeni = new BarButtonItem(e.Manager, "Toplu Ödeme Planı Oluştur");
                BarButtonItem barTopluHesap = new BarButtonItem(e.Manager, "Toplu Dosya Hesapla");

                bus.ItemLinks.Add(barAlacakNedeni);
                bus.ItemLinks.Add(barTopluHesap);

                e.MyPopupMenu.AddItem(bus);
            }

            #endregion
        }

        private void barBtnCariRapor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                int cariId = (int)e.Item.Tag;

                AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cariId);
                AdimAdimDavaKaydi.CariTakipForms.Forms.frmCariTakipForm cariForms =
                    new AdimAdimDavaKaydi.CariTakipForms.Forms.frmCariTakipForm();
                cariForms.Show(cari);
            }
        }

        //icra gridinde yeni satır ekleme butonu exdtendedNavBar dan kaldıurıldı kenay beyin isteği dahilinde ..

        public List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> MyDataSource
        {
            get { return (List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA>)gcIcraFoy.DataSource; }
            set
            {
                if (value != null) InitsGetir();
#if tmpTOTALOZEL
                if (value != null && AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI != "MERKEZ")
                {
                    value.Filter = "REFERANS_NO2 = '" + AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI + "'";
                }
#endif
                compGridDovizSummary1.AltToplamlarAktifMi = AltToplamlarAktif;
                gcIcraFoy.DataSource = value;
                gridView1.ExpandAllGroups();
                gcIcraFoy.barCheckHucreBirlestir.Checked = true;
            }
        }

        public void SagTusaEkle()
        {
            gcIcraFoy.RightClickPopup.LinkPersist = new DevExpress.XtraBars.LinksInfo();
            foreach (DevExpress.XtraBars.LinkPersistInfo var in popupMenu1.LinksPersistInfo)
            {
                gcIcraFoy.RightClickPopup.LinkPersist.Add(var);
            }
        }


        [Browsable(false), Description("GridView Üzerinde Yapılan Filter Sonucundaki String Değer")]
        public string FilterString
        {
            get { return gridView1.ActiveFilterString; }
        }

        public static List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> GetSelectedFoy(
            List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> foy)
        {
            List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> seciliKayitlar = new List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA>();

            foreach (AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA f in foy)
            {
                if (f.IsSelected)
                {
                    seciliKayitlar.Add(f);
                }
            }
            return seciliKayitlar;
        }

        private bool _altToplamlarAktif;

        public bool AltToplamlarAktif
        {
            get { return _altToplamlarAktif; }
            set
            {
                _altToplamlarAktif = value;
                if (value)
                    this.compGridDovizSummary1.MyGridView = gridView1;
            }
        }

        private void ucIcraFoy_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                gcIcraFoy.ShowOnlyPredefinedDetails = true;
                gcIcraFoy.ButtonCevirClick += gcIcraFoy_ButtonCevirClick;
                gcIcraFoy.GridlerDuzenlenebilir = false;
                gcIcraFoy.ButtonClick += gcIcraFoy_ButtonClick;

                BelgeUtil.Inits.ParaBicimiAyarla(spTutar);
                DovizBirimKolonlariniBul(gridView1);

                SagTusaEkle();

                #region Ozellestirme

                if (gridView1.Columns["ICRA_OZEL_KOD1_ID"] != null)
                    gridView1.Columns["ICRA_OZEL_KOD1_ID"].Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod1;

                if (gridView1.Columns["ICRA_OZEL_KOD2_ID"] != null)
                    gridView1.Columns["ICRA_OZEL_KOD2_ID"].Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod2;

                if (gridView1.Columns["ICRA_OZEL_KOD3_ID"] != null)
                    gridView1.Columns["ICRA_OZEL_KOD3_ID"].Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod3;

                if (gridView1.Columns["ICRA_OZEL_KOD4_ID"] != null)
                    gridView1.Columns["ICRA_OZEL_KOD4_ID"].Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod4;

                if (gridView1.Columns["REFERANS_NO"] != null)
                    gridView1.Columns["REFERANS_NO"].Caption = Kimlikci.Kimlik.IcraReferans.Referans1;
                if (gridView1.Columns["REFERANS_NO2"] != null)
                    gridView1.Columns["REFERANS_NO2"].Caption = Kimlikci.Kimlik.IcraReferans.Referans2;
                if (gridView1.Columns["REFERANS_NO3"] != null)
                    gridView1.Columns["REFERANS_NO3"].Caption = Kimlikci.Kimlik.IcraReferans.Referans3;

                //if (layoutView1.Columns["ICRA_OZEL_KOD1_ID"] != null)
                //    layoutView1.Columns["ICRA_OZEL_KOD1_ID"].Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod1;

                //if (layoutView1.Columns["ICRA_OZEL_KOD2_ID"] != null)
                //    layoutView1.Columns["ICRA_OZEL_KOD2_ID"].Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod2;

                //if (layoutView1.Columns["ICRA_OZEL_KOD3_ID"] != null)
                //    layoutView1.Columns["ICRA_OZEL_KOD3_ID"].Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod3;

                //if (layoutView1.Columns["ICRA_OZEL_KOD4_ID"] != null)
                //    layoutView1.Columns["ICRA_OZEL_KOD4_ID"].Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod4;

                #endregion
            }
        }

        private void InitsGetir()
        {
            #region inits

            //BelgeUtil.Inits.AsamaKodGetir(rLueAsama);
            BelgeUtil.Inits.DovizTipGetir(rLueDoviz);

            #endregion
        }

        private void gcIcraFoy_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                if (
                    MessageBox.Show("Seçili Kayıtlar Silinecektir. Eminmisiniz?", "Kayıt Silme", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    var dtSource =
                        (((sender as DevExpress.XtraGrid.GridControlNavigator).Parent as ExtendedGridControl).MainView
                         as DevExpress.XtraGrid.Views.Grid.GridView).DataSource as
                        List<AvukatProLib.Arama.AV001_TI_BIL_FOY>;
                    var selectedRows = dtSource;
                    foreach (var item in selectedRows)
                    {
                        var dltFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(item.ID);
                        dltFoy.STAMP = 34;

                        foreach (var itm in DataRepository.NN_BELGE_ICRAProvider.GetByICRA_FOY_ID(item.ID))
                            DataRepository.NN_BELGE_ICRAProvider.Delete(itm);

                        foreach (var itm in DataRepository.NN_GOREV_ICRA_FOYProvider.GetByICRA_FOY_ID(item.ID))
                            DataRepository.NN_GOREV_ICRA_FOYProvider.Delete(itm);

                        foreach (var itm in DataRepository.NN_GOREV_SONUC_ICRA_FOYProvider.GetByICRA_FOY_ID(item.ID))
                            DataRepository.NN_GOREV_SONUC_ICRA_FOYProvider.Delete(itm);

                        foreach (var itm in DataRepository.NN_GORUSME_ICRAProvider.GetByICRA_FOY_ID(item.ID))
                            DataRepository.NN_GORUSME_ICRAProvider.Delete(itm);

                        foreach (var itm in DataRepository.NN_HASAR_ICRA_FOYProvider.GetByICRA_FOY_ID(item.ID))
                            DataRepository.NN_HASAR_ICRA_FOYProvider.Delete(itm);

                        foreach (var itm in DataRepository.NN_ICRA_GAYRIMENKULProvider.GetByICRA_FOY_ID(item.ID))
                            DataRepository.NN_ICRA_GAYRIMENKULProvider.Delete(itm);

                        foreach (var itm in DataRepository.NN_ICRA_GEMI_UCAK_ARACProvider.GetByICRA_FOY_ID(item.ID))
                            DataRepository.NN_ICRA_GEMI_UCAK_ARACProvider.Delete(itm);

                        foreach (var itm in DataRepository.NN_ICRA_KIYMETLI_EVRAKProvider.GetByICRA_FOY_ID(item.ID))
                            DataRepository.NN_ICRA_KIYMETLI_EVRAKProvider.Delete(itm);

                        foreach (var itm in DataRepository.NN_ICRA_POLICEProvider.GetByICRA_FOY_ID(item.ID))
                            DataRepository.NN_ICRA_POLICEProvider.Delete(itm);

                        foreach (var itm in DataRepository.NN_ICRA_SOZLESMEProvider.GetByICRA_FOY_ID(item.ID))
                            DataRepository.NN_ICRA_SOZLESMEProvider.Delete(itm);

                        foreach (var itm in DataRepository.NN_IS_ICRA_FOYProvider.GetByICRA_FOY_ID(item.ID))
                            DataRepository.NN_IS_ICRA_FOYProvider.Delete(itm);

                        foreach (var itm in DataRepository.NN_MESAJ_ICRA_FOYProvider.GetByICRA_FOY_ID(item.ID))
                            DataRepository.NN_MESAJ_ICRA_FOYProvider.Delete(itm);

                        DataRepository.AV001_TI_BIL_FOYProvider.Save(dltFoy);
                        dtSource.Remove(item);
                    }
                }
            }
            e.Handled = true;
        }

        private void gcIcraFoy_ButtonCevirClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (gcIcraFoy.Visible)
            {
                gcIcraFoy.Visible = false;
            }
            else
            {
                gcIcraFoy.Visible = true;
            }
        }

        public void FilitreleriTemizle()
        {
            gridView1.ActiveFilter.Clear();
        }

        /// <summary>
        /// Doviz Birimi olan kolonların taşıma esnasında döviz birim kolonlarınıda yanlarında taşımaları için
        /// taglarına bu kolonlar hakkında bilgi yerleştirir
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

                    if (abiKolonAdi != null)
                    {
                        abiKolon.Tag = grid.Columns[i];
                        grid.Columns[i].Tag = abiKolon;
                    }
                }
            }
        }

        private Dictionary<int, GridColumn> indexler = new Dictionary<int, GridColumn>();


        private void gcIcraFoy_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA takip = gridView1.GetFocusedRow() as AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA;
                AV001_TI_BIL_FOY icra = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(takip.ID);
               
                TList<AV001_TI_BIL_FOY> seciliKayitler = new TList<AV001_TI_BIL_FOY>();
                seciliKayitler.Add(icra);
                _frmIcraTakip frmicraTakip = new _frmIcraTakip();
                frmicraTakip.Show(seciliKayitler);
            }
        }

        private int _DosyaSayisi;

        public int DosyaSayisi
        {
            get { return _DosyaSayisi; }
            set
            {
                if (value != null)
                {
                    _DosyaSayisi = value;
                    groupControl1.Text = "İcra Dosya Bilgileri (Dosya Sayısı = " + _DosyaSayisi.ToString() + ")";
                }
            }
        }
    }
}