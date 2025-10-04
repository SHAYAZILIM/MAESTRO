//#define tmpTOTALOZEL
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Util;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucIcraFoy : AvpXUserControl
    {
        public ucIcraFoy()
        {
            InitializeComponent();

            gridView1.DoubleClick += gridView1_DoubleClick;
            gcIcraFoy.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
            gcIcraFoy.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;

            foreach (GridColumn col in gridView1.Columns)
            {
                if (col.FieldName.Contains("DOVIZ_ID"))
                {
                    col.CustomizationCaption = col.Caption;
                    col.ToolTip = col.Caption;
                    col.Caption = string.Empty;
                }
            }
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
                    //frmSorusturma.MdiParent = null;
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
                    //tKayit.MdiParent = null;
                    tKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    tKayit.Show();
                }
                else if (e.Item.Name == bBtnDavaEkle.Name)
                {
                    AdimAdimDavaKaydi.frmDavaDosyaKayitForm frmdavaDosyaKayit = new frmDavaDosyaKayitForm();
                    //frmdavaDosyaKayit.MdiParent = null;
                    frmdavaDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmdavaDosyaKayit.Show();
                }
                else if (e.Item.Name == bButonBelgeEkle.Name)
                {
                    if (e.Item.Tag is AV001_TI_BIL_FOY)
                    {
                        AV001_TI_BIL_FOY takip = e.Item.Tag as AV001_TI_BIL_FOY;
                        AV001_TI_BIL_FOY_TARAF t = new AV001_TI_BIL_FOY_TARAF();

                        string tablob = "AV001_TI_BIL_FOY";
                        bool islemYap = true;
                        if (islemYap)
                        {
                            if (takip.ID != null)
                            {
                                frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();
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
                    if (e.Item.Tag is AV001_TI_BIL_FOY)
                    {
                        AV001_TI_BIL_FOY takip = e.Item.Tag as AV001_TI_BIL_FOY;
                        string tabloI = "AV001_TI_BIL_FOY";
                        AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit =
                            new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
                        frmisKayit.ucIsKayitUfak1.Record = takip;
                        frmisKayit.ucIsKayitUfak1.OpenedRecord = takip;
                        frmisKayit.SetByTableNameAndId(tabloI, takip.ID);
                    }
                }
                else if (e.Item.Name == bButtonNotEkle.Name)
                {
                }
                else if (e.Item.Name == bButtonGorusmeEkle.Name)
                {
                    bool islemYap = true;
                    if (e.Item.Tag is AV001_TI_BIL_FOY)
                    {
                        AV001_TI_BIL_FOY takip = e.Item.Tag as AV001_TI_BIL_FOY;
                        if (!islemYap)
                            return;

                        AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit gorsumeForms =
                            new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();

                        gorsumeForms.ShowDialog(AvukatProLib.Extras.ModulTip.Icra, takip.ID);
                    }
                }

                else if (e.Item.Name == bButonKisayolEkle.Name)
                {
                    AV001_TI_BIL_FOY takip = e.Item.Tag as AV001_TI_BIL_FOY;

                    if (takip.ID != null)
                    {
                        #region <KA-20090709>

                        //Kisayol oluþturma tek bir yere çekildi daðýnýklýk giderildi.
                        Kisayol.CreateShortCut(takip.ID, Kisayol.AcilisSekli.IcraTakip);

                        #endregion </KA-20090709>
                    }
                }
                else if (e.Item.Name == bButtonSikKullanilan.Name)
                {
                    if (e.Item.Tag is AV001_TI_BIL_FOY)
                    {
                        AV001_TI_BIL_FOY takip = e.Item.Tag as AV001_TI_BIL_FOY;
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
                    if (e.Item.Tag is AV001_TI_BIL_FOY)
                    {
                        gelenFoy = e.Item.Tag as AV001_TI_BIL_FOY;

                        switch (e.Item.Caption)
                        {
                            case "Alacak Nedeni":
                                IcraTakipForms.frmAlacakNedenEkle alacakNedenEkle = new frmAlacakNedenEkle();
                                alacakNedenEkle.ShowDialog(gelenFoy);

                                break;
                            case "Mal Beyaný":
                                AdimAdimDavaKaydi.Forms.frmMalBeyani frm = new AdimAdimDavaKaydi.Forms.frmMalBeyani();
                                //this.MyFoy = gelenFoy;
                                frm.Show(gelenFoy);

                                break;
                            case "Ödeme":
                                IcraTakipForms.rFrmTarafOdeme odemeEkle = new rFrmTarafOdeme();
                                odemeEkle.MyGelisme =
                                    AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.
                                        myGelisme;

                                odemeEkle.Show(gelenFoy);
                                break;
                            case "Haciz":
                                Forms.Icra.frmHacizGirisi hacizEkle = new Forms.Icra.frmHacizGirisi();

                                hacizEkle.Show(gelenFoy, null);
                                break;
                            case "Satýþ":
                                Forms.Icra.frmSatisGirisi satisEkle = new AdimAdimDavaKaydi.Forms.Icra.frmSatisGirisi();
                                gelenFoy.AV001_TI_BIL_SATIS_MASTERCollection.AddingNew +=
                                    AV001_TI_BIL_SATIS_MASTERCollection_AddingNew;
                                satisEkle.MyFoy = gelenFoy;
                                satisEkle.Show(gelenFoy);
                                break;
                            case "Kýymet Taktiri":
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
                                IcraTakipForms.frmKefaletBilgileri kefalet = new frmKefaletBilgileri();
                                kefalet.Show(gelenFoy);
                                break;
                            case "Masraf Avans":
                                Muhasebe.rfrmMuhasebeGiris masrafGris = new Muhasebe.rfrmMuhasebeGiris();
                                masrafGris.Show(gelenFoy);
                                break;
                            case "Ýtiraz":
                                rFrmItiraz itirazGiris = new rFrmItiraz();
                                itirazGiris.Show(gelenFoy);
                                break;
                            case "Ödeme Planý":
                                UserControls.frmOdemePlani odemePlaniEkle = new frmOdemePlani();
                                odemePlaniEkle.Show(gelenFoy.ID, gelenFoy.FOY_NO);
                                break;
                            case "Düþme Yenileme":
                                frmDusmeYenileme dusmeYenileme = new frmDusmeYenileme();
                                dusmeYenileme.Show(gelenFoy);
                                break;
                            case "Masraf Avans (Hýzlý)":
                                AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli marForms =
                                    new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
                                marForms.Show(gelenFoy);
                                break;
                            case "Taahhüt":
                                rFrmTaahhut frmTaahhut = new rFrmTaahhut();
                                frmTaahhut.MyFoy = gelenFoy;
                                frmTaahhut.Show(gelenFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection);
                                break;
                        }
                    }
                }
            }
            else if (e.Item.Tag == null)
            {
                switch (e.Item.Caption)
                {
                    case "Toplu Ödeme Planý Oluþtur":
                        frmOdemePlani op = new frmOdemePlani();
                        op.Show(GetSelectedFoy(gcIcraFoy.DataSource as List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>));
                        break;
                    case "Toplu Dosya Hesapla":
                        frmTopluIcraHesapla ti = new frmTopluIcraHesapla();
                        ti.ShowDialog(GetSelectedFoy(gcIcraFoy.DataSource as List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>));
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
            if (e.Item.Tag != null)
            {
                int cariId = (int)e.Item.Tag;

                AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cariId);
                AdimAdimDavaKaydi.frmCariGenelGiris cariForms = new frmCariGenelGiris();
                cariForms.YeniKayitMi = false;
                cariForms.MyCariId = cariId;
                //cariForms.MdiParent = null;
                cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cariForms.Show();
            }
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {           
            #region Adres Ve Ýletiþim Bilgileri

            if (e.Column != null && e.Column.FieldName == "SORUMLU_AVUKAT_CARI_ID")
            {
                #region Sorumlu Avukat

                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kiþinin");

                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve Ýletiþim Bilgileri");
                //barBtnSecimiKaldir.Tag = e.Column;

                bus.ItemLinks.Add(barBtnSecimiKaldir);

                AV001_TI_BIL_FOY_SORUMLU_AVUKAT secim = e.Rows as AV001_TI_BIL_FOY_SORUMLU_AVUKAT;

                int? id = secim.SORUMLU_AVUKAT_CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                e.MyPopupMenu.ItemLinks.Add(bus);

                #endregion
            }
            else if (e.Column != null && e.Column.FieldName == "CARI_ID")
            {
                #region Cari

                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kiþinin");

                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve Ýletiþim Bilgileri");
                //barBtnSecimiKaldir.Tag = e.Column;

                bus.ItemLinks.Add(barBtnSecimiKaldir);

                AV001_TI_BIL_FOY_TARAF secim = e.Rows as AV001_TI_BIL_FOY_TARAF;

                int? id = secim.CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                e.MyPopupMenu.ItemLinks.Add(bus);

                #endregion
            }

            #endregion

            #region Bu Kayda Geliþme Ekle

            if (e.Rows is AV001_TI_BIL_FOY)
            {
                //TODO: Burtdaki Editöre Gönder(Hýzlý ) ve Klasöre Gönder Butonlarý  ExtendedGridControl daki Gonder bölümüne taþýnmýþtýr buradan silinmemiþ Comment Edilmiþtir.

                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kayda Geliþme Ekle");

                BarButtonItem barAlacakNedeni = new BarButtonItem(e.Manager, "Alacak Nedeni");
                BarButtonItem barMalBeyani = new BarButtonItem(e.Manager, "Mal Beyaný");
                BarButtonItem barOdeme = new BarButtonItem(e.Manager, "Ödeme");
                BarButtonItem barHaciz = new BarButtonItem(e.Manager, "Haciz");
                BarButtonItem barSatis = new BarButtonItem(e.Manager, "Satýþ");
                BarButtonItem barKiymetTaktiri = new BarButtonItem(e.Manager, "Kýymet Taktiri");
                BarButtonItem barFeragat = new BarButtonItem(e.Manager, "Feragat");
                BarButtonItem barKefil = new BarButtonItem(e.Manager, "Kefil");
                BarButtonItem barMasrafAvans = new BarButtonItem(e.Manager, "Masraf Avans");
                BarButtonItem barItiraz = new BarButtonItem(e.Manager, "Ýtiraz");
                BarButtonItem barOdemePlani = new BarButtonItem(e.Manager, "Ödeme Planý");
                BarButtonItem barTaahhut = new BarButtonItem(e.Manager, "Taahhüt");
                BarButtonItem barDusmeYenileme = new BarButtonItem(e.Manager, "Düþme Yenileme");
                BarButtonItem barExMasrafAvans = new BarButtonItem(e.Manager, "Masraf Avans (Hýzlý)");

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
                                           });
                e.MyPopupMenu.AddItem(bus);
            }

            #endregion

            #region Seçilen Kayýtlarla Ýþlem Yap

            if (GetSelectedFoy(gcIcraFoy.DataSource as List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>).Count > 0)
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Seçilen Kayýtlara");

                BarButtonItem barAlacakNedeni = new BarButtonItem(e.Manager, "Toplu Ödeme Planý Oluþtur");
                BarButtonItem barTopluHesap = new BarButtonItem(e.Manager, "Toplu Dosya Hesapla");

                bus.ItemLinks.Add(barAlacakNedeni);
                bus.ItemLinks.Add(barTopluHesap);

                e.MyPopupMenu.AddItem(bus);
            }

            #endregion
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama obj = (AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama)gridView1.GetFocusedRow();
            if (obj == null) return;

            List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> foys = new List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>();
            foys.Add(obj);

            DialogResult ds =
                XtraMessageBox.Show(obj.FOY_NO + " " + "numaralý dosyayý takip ekranýna göndermek istiyor musunuz?",
                                    "Dosya Aç", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ds == DialogResult.Yes)
            {
                _frmIcraTakip frm = new _frmIcraTakip();
                var girisEkran = FormTutucu.GetFormByName("rFrmIcraGirisEkran");
                if (girisEkran != null)
                    girisEkran.Close();
                frm.Show(obj.ID); //frm.ShowDialog(foys);
            }
        }

        //icra gridinde yeni satýr ekleme butonu exdtendedNavBar dan kaldýurýldý kenay beyin isteði dahilinde ..

        public DataTable MyDataSource
        {
            get { return (DataTable)gcIcraFoy.DataSource; }
            set
            {
//#if tmpTOTALOZEL
//                if (value != null && AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI != "MERKEZ")
//                {
//                    value.Filter = "REFERANS_NO2 = '" + AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI + "'";
//                }
//#endif

                gcIcraFoy.DataSource = value;
                extendedGridControl1.DataSource = gcIcraFoy.DataSource;
            }
        }

        public void SagTusaEkle()
        {
            //gcKurumsalGiris.RightClickPopup.BarItemCollections.Assign(popupMenu1.LinksPersistInfo);
            gcIcraFoy.RightClickPopup.LinkPersist = new DevExpress.XtraBars.LinksInfo();
            foreach (DevExpress.XtraBars.LinkPersistInfo var in popupMenu1.LinksPersistInfo)
            {
                gcIcraFoy.RightClickPopup.LinkPersist.Add(var);
            }
        }


        [Browsable(false), Description("GridView Üzerinde Yapýlan Filter Sonucundaki String Deðer")]
        public string FilterString
        {
            get { return gridView1.ActiveFilterString; }
        }

        public static List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> GetSelectedFoy(List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> foy)
        {
            List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> seciliKayitlar = foy.FindAll(item => item.IsSelected);
            return seciliKayitlar;
        }

        private bool _altToplamlarAktif;

        public bool AltToplamlarAktif
        {
            get { return _altToplamlarAktif; }
            set
            {
                _altToplamlarAktif = value;
            }
        }

        private void ucIcraFoy_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                gcIcraFoy.ShowOnlyPredefinedDetails = true;

                gcIcraFoy.ButtonCevirClick += gcIcraFoy_ButtonCevirClick;
                extendedGridControl1.ButtonCevirClick += gcIcraFoy_ButtonCevirClick;
                //extendedGridControl2.ButtonCevirClick += new EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(gcIcraFoy_ButtonCevirClick);
                extendedGridControl1.GridlerDuzenlenebilir = false;
                gcIcraFoy.GridlerDuzenlenebilir = false;
                BelgeUtil.Inits.FoyDurumGetir(rLueFoyDurumId);
                BelgeUtil.Inits.FoyDurumGetir(rLueFoyDurum);
                try
                {
                    BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKodId);
                }
                catch { ;}
                try
                {
                    BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKodlar);
                }
                catch { ;}

                #region inits

                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeId);

                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorevID);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);

                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNoFoy);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);

                BelgeUtil.Inits.CariSifatGetir(rLueTarafSifat);
                BelgeUtil.Inits.perCariGetir(rLueSorumluAvukatCari);

                BelgeUtil.Inits.CariSifatGetir(rLueTarafSifat);

                BelgeUtil.Inits.AsamaKodGetir(rLueTakipAsama);
                BelgeUtil.Inits.AsamaKodGetir(rLueTakipAsamasi);

                BelgeUtil.Inits.FormTipiGetir(rLueFormTip);
                BelgeUtil.Inits.FormTipiGetir(rLueFormTipID);

                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
                BelgeUtil.Inits.TarafKoduEnumGetir(rLueTarafKodu);
                BelgeUtil.Inits.SorumluTipGetir(rLueSorumluTipAvukat);

                BelgeUtil.Inits.DovizTipGetir(rLueDoviz);

                DovizBirimKolonlariniBul(gridView1);

                BelgeUtil.Inits.TakipTalepleriResimliGetir(rLueTakipKonusuResimli);
                //Layout için biri
                BelgeUtil.Inits.TakipTalepleriResimliGetir(repositoryItemImageComboBox1);
                //
                BelgeUtil.Inits.TakipYontemGetir(rLueTakipYontem);

                #endregion

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

                if (layoutView1.Columns["ICRA_OZEL_KOD1_ID"] != null)
                    layoutView1.Columns["ICRA_OZEL_KOD1_ID"].Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod1;

                if (layoutView1.Columns["ICRA_OZEL_KOD2_ID"] != null)
                    layoutView1.Columns["ICRA_OZEL_KOD2_ID"].Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod2;

                if (layoutView1.Columns["ICRA_OZEL_KOD3_ID"] != null)
                    layoutView1.Columns["ICRA_OZEL_KOD3_ID"].Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod3;

                if (layoutView1.Columns["ICRA_OZEL_KOD4_ID"] != null)
                    layoutView1.Columns["ICRA_OZEL_KOD4_ID"].Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod4;

                #endregion
            }
        }

        private void gcIcraFoy_ButtonCevirClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (gcIcraFoy.Visible)
            {
                extendedGridControl1.Visible = true;
                gcIcraFoy.Visible = false;
                //extendedGridControl2.Visible = true;
            }
            else
            {
                extendedGridControl1.Visible = false;
                gcIcraFoy.Visible = true;
                //extendedGridControl2.Visible = false;
            }
        }

        public void FilitreleriTemizle()
        {
            gridView1.ActiveFilter.Clear();
        }

        private Dictionary<int, decimal> paralar = new Dictionary<int, decimal>();
        private List<int> DovizListesi = new List<int>();

        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (!AltToplamlarAktif)
                return;

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
                            e.TotalValue = "Bir Terslik Var";
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

                    if (abiKolonAdi != null)
                    {
                        abiKolon.Tag = grid.Columns[i];
                        grid.Columns[i].Tag = abiKolon;
                    }
                }
            }
        }

        private Dictionary<int, GridColumn> indexler = new Dictionary<int, GridColumn>();

    }
}