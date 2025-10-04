//#define tmpTOTALOZEL
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.DavaTakip;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Data;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucDavaAramaFoy : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        public ucDavaAramaFoy()
        {
            InitializeComponent();
            gridDavaBIL_Foy.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            gridDavaBIL_Foy.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
        }

        public DataTable MyDataSource
        {
            get
            {
                //if (gridDavaBIL_Foy.DataSource is List<AvukatProLib.Arama.AV001_TD_BIL_FOY>)
                //    return (List<AvukatProLib.Arama.AV001_TD_BIL_FOY>)gridDavaBIL_Foy.DataSource;

                return gridDavaBIL_Foy.DataSource as DataTable;
            }
            set
            {
//#if tmpTOTALOZEL
//                if (value != null && AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI != "MERKEZ")
//                {
//                    value.Filter = "REFERANS_NO2 = '" + AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI + "'";
//                }
//#endif
                gridDavaBIL_Foy.Tag = "AV001_TD_BIL_FOY";
                gridDavaBIL_Foy.DataSource = value;


                gridView1.GroupSummary.Clear();
                foreach (GridColumn item in gridView1.Columns)
                {
                    try
                    {
                        if (item.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                            gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, item.FieldName, item, "{0:C2}");
                    }
                    catch { ;}
                }
            }
        }

        public void FilitreleriTemizle()
        {
            gridView1.ActiveFilter.Clear();
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            #region <CC-20090606>

            // dava giriş ekranı  viewe çekildiğinden  burası  dava viewinini üzerindek itaraf ve sorumluluklara göre ayarlandı..

            #region AdresVeİletişimBilgileri

            if (e.Column != null && e.Column.FieldName == "SORUMLU" || e.Column.FieldName == "IZLEYEN")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kişinin");
                bus.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Client_2_22x22;
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve İletişim Bilgileri");
                BarButtonItem barBtnCariRapor = new BarButtonItem(e.Manager, "Bu Şahsın Raporuna Git");
                //barBtnSecimiKaldir.Tag = e.Column;
                barBtnCariRapor.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.rapor02_22;
                barBtnSecimiKaldir.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.personel_isleri;
                bus.ItemLinks.Add(barBtnSecimiKaldir);
                bus.ItemLinks.Add(barBtnCariRapor);
                AvukatProLib.Arama.AV001_TD_BIL_FOY secim = e.Rows as AvukatProLib.Arama.AV001_TD_BIL_FOY;
                int? id = secim.SORUMLU_CARI_ID;

                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                    barBtnCariRapor.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                barBtnCariRapor.ItemClick += barBtnCariRapor_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(0, bus);
            }
            else if (e.Column != null && e.Column.FieldName == "DAVA_EDEN" || e.Column.FieldName == "DAVA_EDILEN")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kişinin");
                bus.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Client_2_22x22;
                int? id = 0;
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve İletişim Bilgileri");
                BarButtonItem barBtnCariRapor = new BarButtonItem(e.Manager, "Bu Şahsın Raporuna Git");
                //barBtnSecimiKaldir.Tag = e.Column;
                barBtnCariRapor.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.rapor02_22;
                barBtnSecimiKaldir.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.personel_isleri;
                bus.ItemLinks.Add(barBtnSecimiKaldir);
                bus.ItemLinks.Add(barBtnCariRapor);
                AvukatProLib.Arama.AV001_TD_BIL_FOY secim = e.Rows as AvukatProLib.Arama.AV001_TD_BIL_FOY;
                if (e.Column.FieldName == "DAVA_EDEN")
                    id = secim.DAVA_EDEN_CARI_ID;
                else if (e.Column.FieldName == "DAVA_EDILEN")
                    id = secim.DAVA_EDILEN_CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                    barBtnCariRapor.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                barBtnCariRapor.ItemClick += barBtnCariRapor_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(1, bus);
            }

            #endregion

            #endregion </CC-20090606>

            #region u Kayda Gelişme Ekle

            if (e.Rows is AvukatProLib.Arama.AV001_TD_BIL_FOY)
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kayda Gelişme Ekle");
                bus.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.application_up_22x22;
                BarButtonItem barDavaNedeni = new BarButtonItem(e.Manager, "Dava Nedeni");
                BarButtonItem barDurusma = new BarButtonItem(e.Manager, "Duruşma");
                BarButtonItem barAraKarar = new BarButtonItem(e.Manager, "Ara Karar");
                BarButtonItem barHukum = new BarButtonItem(e.Manager, "Hüküm");
                BarButtonItem barTemyiz = new BarButtonItem(e.Manager, "Temyiz");
                BarButtonItem barDusmeYenileme = new BarButtonItem(e.Manager, "Düşme Yenileme");
                BarButtonItem barIhtiyatiTedbir = new BarButtonItem(e.Manager, "Ihtiyati Tedbir");
                BarButtonItem barMasrafAvans = new BarButtonItem(e.Manager, "Masraf Avans");
                BarButtonItem barTutuklama = new BarButtonItem(e.Manager, "Tutuklama");
                BarButtonItem barKanit = new BarButtonItem(e.Manager, "Kanıt");
                BarButtonItem barExMasrafAvans = new BarButtonItem(e.Manager, "Masraf Avans (Hızlı)");
                //BarButtonItem barEditorSihirbaz = new BarButtonItem(e.Manager, "Editöre Gönder (Hızlı)");
                //BarButtonItem barKlasorGotur = new BarButtonItem(e.Manager, "Klasöre Gönder");

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
                //barEditorSihirbaz.Tag = e.Rows;
                //barKlasorGotur.Tag = e.Rows;

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
                                               //barEditorSihirbaz,
                                               //barKlasorGotur,
                                               barKanit,
                                               barTutuklama
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

                e.MyPopupMenu.ItemLinks.Insert(2, bus);
                e.MyPopupMenu.ItemLinks.Insert(3, bus2);
                e.MyPopupMenu.ItemLinks.Insert(4, bus3);
                e.MyPopupMenu.ItemLinks.Insert(5, bus4);
                e.MyPopupMenu.ItemLinks.Insert(6, bus5);
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
                    //.MdiParent = null;
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
                    // cGiris.MdiParent = null;
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
                    // frmdavaDosyaKayit.MdiParent = null;
                    frmdavaDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmdavaDosyaKayit.Show();
                }
                else if (e.Item.Name == bButonBelgeEkle.Name)
                {
                    //if (e.Item.Tag is AvukatProLib.Arama.AV001_TD_BIL_FOY)
                    //{
                        //AvukatProLib.Arama.AV001_TD_BIL_FOY genel = e.Item.Tag as AvukatProLib.Arama.AV001_TD_BIL_FOY;

                    AV001_TD_BIL_FOY takip = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)gridView1.GetFocusedRowCellValue("ID"));
                        string tablob = "AV001_TD_BIL_FOY";
                        bool islemYap = true;
                        if (islemYap)
                        {
                            if (takip.ID != null)
                            {
                                frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();
                                belgeKayit.ucBelgeKayitUfak1.OpenedRecord = takip;
                                belgeKayit.SetByTableNameAndId(tablob, takip.ID);
                                // belgeKayit.MdiParent = null;
                                belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                belgeKayit.Show();
                            }
                        }
                    //}
                }
                else if (e.Item.Name == bButonIsEkle.Name)
                {
                    //if (e.Item.Tag is AvukatProLib.Arama.AV001_TD_BIL_FOY)
                    //{
                    //    AvukatProLib.Arama.AV001_TD_BIL_FOY genel = e.Item.Tag as AvukatProLib.Arama.AV001_TD_BIL_FOY;
                    AV001_TD_BIL_FOY takip = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)gridView1.GetFocusedRowCellValue("ID"));
                        AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit =
                            new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
                        frmisKayit.ucIsKayitUfak1.ModulID = 2;
                        frmisKayit.ucIsKayitUfak1.OpenedRecord = takip;
                        frmisKayit.ucIsKayitUfak1.Modul = 2;
                        //frmisKayit.MdiParent = null;
                        frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frmisKayit.Show();
                    //}
                }
                else if (e.Item.Name == bButtonNotEkle.Name)
                {
                }
                else if (e.Item.Name == bButtonGorusmeEkle.Name)
                {
                    bool islemYap = true;
                    //if (e.Item.Tag is AvukatProLib.Arama.AV001_TD_BIL_FOY)
                    //{
                    //    AvukatProLib.Arama.AV001_TD_BIL_FOY genel = e.Item.Tag as AvukatProLib.Arama.AV001_TD_BIL_FOY;
                    AV001_TD_BIL_FOY takip = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)gridView1.GetFocusedRowCellValue("ID"));
                        if (!islemYap)
                            return;

                        AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit gorsumeForms =
                            new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();
                        gorsumeForms.ShowDialog(AvukatProLib.Extras.ModulTip.Dava, takip.ID);
                    //}
                }

                else if (e.Item.Name == bButonKisayolEkle.Name)
                {
                    //if (e.Item.Tag is AvukatProLib.Arama.AV001_TD_BIL_FOY)
                    //{
                    //    AvukatProLib.Arama.AV001_TD_BIL_FOY genel = e.Item.Tag as AvukatProLib.Arama.AV001_TD_BIL_FOY;
                    AV001_TD_BIL_FOY takip = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)gridView1.GetFocusedRowCellValue("ID"));
                        string dosyaUzantisi = string.Empty;

                        if (takip.ID != null)
                        {
                            #region <KA-20090709>

                            //Kisayol oluşturma tek bir yere çekildi dağınıklık giderildi.
                            Kisayol.CreateShortCut(takip.ID, Kisayol.AcilisSekli.DavaTakip);

                            #endregion </KA-20090709>
                        }
                    //}
                }
                else if (e.Item.Name == "bButtonKlasorAc")
                {
                    //if (e.Item.Tag is AvukatProLib.Arama.AV001_TD_BIL_FOY)
                    //{
                    //    AvukatProLib.Arama.AV001_TD_BIL_FOY takip = e.Item.Tag as AvukatProLib.Arama.AV001_TD_BIL_FOY;
                        TList<AV001_TDIE_BIL_PROJE_DAVA_FOY> icra =
                            DataRepository.AV001_TDIE_BIL_PROJE_DAVA_FOYProvider.GetByDAVA_FOY_ID((int)gridView1.GetFocusedRowCellValue("ID"));
                        if (icra.Count > 0)
                        {
                            AV001_TDIE_BIL_PROJE proj =
                                DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(icra[0].PROJE_ID);
                            TList<AV001_TDIE_BIL_PROJE> seciliKayitler = new TList<AV001_TDIE_BIL_PROJE>();
                            seciliKayitler.Add(proj);
                            frmKlasorYeni kg = new frmKlasorYeni();
                            //.MdiParent = null;
                            kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            kg.Show(seciliKayitler);
                        }
                        else
                        {
                            XtraMessageBox.Show("Bu Dosyaya Ait Klasör Kaydı Bulunmamaktadır", "Uyarı");
                        }
                    //}
                }
                else if (e.Item.Name == "bButtonTakipGonder")
                {
                    if (e.Item.Tag is AvukatProLib.Arama.AV001_TD_BIL_FOY)
                    {
                        AvukatProLib.Arama.AV001_TD_BIL_FOY takip = e.Item.Tag as AvukatProLib.Arama.AV001_TD_BIL_FOY;
                        AV001_TD_BIL_FOY icra = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(takip.ID);
                        TList<AV001_TD_BIL_FOY> seciliKayitler = new TList<AV001_TD_BIL_FOY>();
                        seciliKayitler.Add(icra);
                        frmDavaTakip frmdavaTakip = new frmDavaTakip();
                        frmdavaTakip.Show(seciliKayitler);
                    }
                }
                else if (e.Item.Name == bButtonSikKullanilan.Name)
                {
                    //if (e.Item.Tag is AvukatProLib.Arama.AV001_TD_BIL_FOY)
                    //{
                    //    AvukatProLib.Arama.AV001_TD_BIL_FOY genel = e.Item.Tag as AvukatProLib.Arama.AV001_TD_BIL_FOY;
                    AV001_TD_BIL_FOY takip = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)gridView1.GetFocusedRowCellValue("ID"));
                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(takip, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<TDI_KOD_ADLI_BIRIM_ADLIYE>),
                                                                         typeof(TList<TDI_KOD_ADLI_BIRIM_GOREV>),
                                                                         typeof(TList<TDI_KOD_ADLI_BIRIM_NO>));
                        AvukatProLib.Extras.ModulTip tablo =
                            AvukatProLib.Extras.ModulTip.Dava;
                        string adliye = string.Empty;
                        string gorev = string.Empty;
                        string no = string.Empty;
                        if (takip.ADLI_BIRIM_ADLIYE_ID != null)
                        {
                            takip.ADLI_BIRIM_ADLIYE_IDSource =
                                DataRepository.TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetByID(
                                    takip.ADLI_BIRIM_ADLIYE_ID.Value);
                            adliye = takip.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                        }
                        if (takip.ADLI_BIRIM_GOREV_ID != null)
                        {
                            takip.ADLI_BIRIM_GOREV_IDSource =
                                DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(takip.ADLI_BIRIM_GOREV_ID.Value);
                            gorev = takip.ADLI_BIRIM_GOREV_IDSource.GOREV;
                        }
                        if (takip.ADLI_BIRIM_NO_ID != null)
                        {
                            takip.ADLI_BIRIM_NO_IDSource =
                                DataRepository.TDI_KOD_ADLI_BIRIM_NOProvider.GetByID(takip.ADLI_BIRIM_NO_ID.Value);
                            no = takip.ADLI_BIRIM_NO_IDSource.NO;
                        }
                        string AD = string.Format("{0} {1} {2} {3} E. nolu Dosyası", adliye, gorev, no, takip.ESAS_NO);
                        rfrmSikKullanilanEkle frm = new rfrmSikKullanilanEkle();
                        //frm.MdiParent = null;
                        frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm.Show(tablo, takip.ID, AD);
                    //}
                }

                #endregion

                else
                {
                    if (e.Item.Tag is AvukatProLib.Arama.AV001_TD_BIL_FOY)
                    {
                        AvukatProLib.Arama.AV001_TD_BIL_FOY dFoy = e.Item.Tag as AvukatProLib.Arama.AV001_TD_BIL_FOY;
                        gelenFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(dFoy.ID);
                        // AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(gelenFoy, true);
                        switch (e.Item.Caption)
                        {
                            case "Dava Nedeni":
                                frmDavaNedenGirisi DavaNeden = new frmDavaNedenGirisi();
                                //DavaNeden.MdiParent = null;
                                DavaNeden.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                DavaNeden.Show(gelenFoy);
                                break;
                            case "Duruşma":
                                rFrmCelseKayit CelseKayit = new rFrmCelseKayit();
                                //CelseKayit.MdiParent = null;
                                CelseKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                CelseKayit.Show(gelenFoy);
                                break;
                            case "Ara Karar":
                                rfrmAraKararKayit AraKararKayit = new rfrmAraKararKayit();
                                //AraKararKayit.MdiParent = null;
                                AraKararKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                AraKararKayit.Show(gelenFoy);
                                break;
                            case "Hüküm":
                                frmHukumGirisi HukumGirisi = new frmHukumGirisi();
                                //HukumGirisi.MdiParent = null;
                                HukumGirisi.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                if (!HukumGirisi.Disposing)
                                    HukumGirisi.Show(gelenFoy);
                                break;
                            case "Temyiz":
                                frmTemyizEkle TemyizEkle = new frmTemyizEkle();
                                //TemyizEkle.MdiParent = null;
                                TemyizEkle.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                TemyizEkle.Show(gelenFoy);
                                break;
                            case "Düşme Yenileme":
                                MessageBox.Show("Bu Bölüm Yapım Aşamasında");
                                break;
                            case "Ihtiyati Tedbir":

                                FoyIhtiyatiTedbir(gelenFoy);
                                break;
                            case "Masraf Avans":
                                AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris frmMasrafKaydet =
                                    new AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris();
                                //frmMasrafKaydet.MdiParent = null;
                                frmMasrafKaydet.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                frmMasrafKaydet.Show(gelenFoy);
                                break;
                            case "Tutuklama":
                                rfrmTutuklanma Tutuklanma = new rfrmTutuklanma();
                                //Tutuklanma.MdiParent = null;
                                Tutuklanma.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                Tutuklanma.Show(gelenFoy);
                                break;
                            case "Kanıt":
                                frmKanitGirisi KanitGirisi = new frmKanitGirisi();
                                //KanitGirisi.MdiParent = null;
                                KanitGirisi.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                KanitGirisi.Show(gelenFoy);
                                break;
                            case "Masraf Avans (Hızlı)":
                                AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli marForms =
                                    new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
                                //marForms.MdiParent = null;
                                marForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                marForms.Show(gelenFoy);
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
            //.MdiParent = null;
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
                //cariForms.MdiParent = null;
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

        private void ucDavaBIL_Foy_Load(object sender, EventArgs e)
        {
            //Load
            if (!this.DesignMode)
            {
                gridDavaBIL_Foy.ShowOnlyPredefinedDetails = true;

                gridDavaBIL_Foy.ButtonCevirClick += gridDavaBIL_Foy_ButtonCevirClick;
                BelgeUtil.Inits.ParaBicimiAyarla(spPara);
                BelgeUtil.Inits.TarafKoduEnumGetir(rLueTarafKodu);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
                BelgeUtil.Inits.DosyaDurumGetir(rLueDurum);
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rlueCari, null);

                #region Ozellestirme

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
                gridDavaBIL_Foy.Visible = false;
            }
            else
            {
                gridDavaBIL_Foy.Visible = true;
            }
        }

        private List<AV001_TD_BIL_FOY> seciliDavaKayitlari;

        public List<AV001_TD_BIL_FOY> GetSelectedFoy(DataTable foy)
        {
            seciliDavaKayitlari = new List<AV001_TD_BIL_FOY>();
            foreach (DataRow f in foy.Rows)
            {
                if ((bool)f["IsSelected"])
                    seciliDavaKayitlari.Add(DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)f["ID"]));
            }
            return seciliDavaKayitlari;
        }

        #region Alt Toplamlarla İlgili Çalışmalar

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

                    if (abiKolon != null)
                    {
                        abiKolon.Tag = grid.Columns[i];
                        grid.Columns[i].Tag = abiKolon;
                    }
                }
            }
        }

        #endregion

        private GridHitInfo gridHitInfo;

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            gridHitInfo = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));
        }


        private void gridDavaBIL_Foy_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            //if (e.Button.Tag.ToString() == "KayitSil")
            //{
            //    AvukatProLib.Arama.AV001_TD_BIL_FOY dava =
            //        gridView1.GetFocusedRow() as AvukatProLib.Arama.AV001_TD_BIL_FOY;
            //    string Foy_no = dava.FOY_NO;
            //    frmKayitSil kayitSil = new frmKayitSil("AV001_TD_BIL_FOY", "ID = " + dava.ID);
            //    if (kayitSil.ShowDialog() == DialogResult.OK)
            //    {
            //        gridView1.GridControl.RefreshDataSource();
            //        //if (KayitSilindi != null)
            //        //    KayitSilindi(this, new EventArgs());

            //        XtraMessageBox.Show(Foy_no + " 'nolo Kayit Silinmiştir");
            //    }
            //}
        }

        private void gridDavaBIL_Foy_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                //AvukatProLib.Arama.AV001_TD_BIL_FOY takip = gridView1.GetFocusedRow() as AvukatProLib.Arama.AV001_TD_BIL_FOY;
                AV001_TD_BIL_FOY takip = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)gridView1.GetFocusedRowCellValue("ID"));
                frmDavaTakip frmdavaTakip = new frmDavaTakip();
                frmdavaTakip.Show(takip.ID);
            }
        }
    }
}