using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Sozlesme.Forms;
using AdimAdimDavaKaydi.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucSozlesmeArama : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        public ucSozlesmeArama()
        {
            InitializeComponent();
            gwSozlesmeBilgi.MouseDown += gwSozlesmeBilgi_MouseDown;
            gwSozlesmeBilgi.DoubleClick += gwSozlesmeBilgi_DoubleClick;
            gwSozlesmeBilgi.FocusedRowChanged += gwSozlesmeBilgi_FocusedRowChanged;
            // gwSozlesmeBilgi.DoubleClick+=new EventHandler(gwSozlesmeBilgi_DoubleClick);
            gridSozlesmeBilgi.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            gridSozlesmeBilgi.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
        }

        private GridHitInfo gridHitInfo;
        private AV001_TDI_BIL_SOZLESME gelenFoy;

        private void gwSozlesmeBilgi_MouseDown(object sender, MouseEventArgs e)
        {
            gridHitInfo = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));
        }

        public delegate void OnFocusedRowChanged(
            R_SOZLESME_GENEL_ARAMA2 sozlesme, object ExSozlesme, int RowHandle, object sender);

        public event OnFocusedRowChanged FocusedRowChanged;

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
            gridSozlesmeBilgi.RightClickPopup.LinkPersist = new DevExpress.XtraBars.LinksInfo();
            foreach (DevExpress.XtraBars.LinkPersistInfo var in popupMenu1.LinksPersistInfo)
            {
                gridSozlesmeBilgi.RightClickPopup.LinkPersist.Add(var);
            }
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "SORUMLU")
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

                R_SOZLESME_GENEL_ARAMA2 secim = e.Rows as R_SOZLESME_GENEL_ARAMA2;

                int? id = secim.SORUMLU_AVUKAT_CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                    barBtnCariRapor.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                barBtnCariRapor.ItemClick += barBtnCariRapor_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(0, bus);
            }
            if (e.Column != null && e.Column.FieldName == "IZLEYEN")
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

                R_SOZLESME_GENEL_ARAMA2 secim = e.Rows as R_SOZLESME_GENEL_ARAMA2;

                int? id = secim.IZLEYEN_AVUKAT_CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                    barBtnCariRapor.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                barBtnCariRapor.ItemClick += barBtnCariRapor_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(1, bus);
            }
            else if (e.Column != null && e.Column.FieldName == "TAKIP_EDEN")
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
                R_SOZLESME_GENEL_ARAMA2 secim = e.Rows as R_SOZLESME_GENEL_ARAMA2;

                int? id = secim.TAKIP_EDEN_CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                    barBtnCariRapor.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                barBtnCariRapor.ItemClick += barBtnCariRapor_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(2, bus);
            }
            else if (e.Column != null && e.Column.FieldName == "TAKIP_EDILEN")
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
                R_SOZLESME_GENEL_ARAMA2 secim = e.Rows as R_SOZLESME_GENEL_ARAMA2;

                int? id = secim.TAKIP_EDILEN_CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                    barBtnCariRapor.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                barBtnCariRapor.ItemClick += barBtnCariRapor_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(3, bus);
            }
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

            e.MyPopupMenu.ItemLinks.Insert(4, bus2);
            e.MyPopupMenu.ItemLinks.Insert(5, bus3);
            e.MyPopupMenu.ItemLinks.Insert(6, bus4);
            e.MyPopupMenu.ItemLinks.Insert(7, bus5);
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

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
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
                else if (e.Item.Name == "bButtonKlasorAc")
                {
                    if (e.Item.Tag is R_SOZLESME_GENEL_ARAMA2)
                    {
                        R_SOZLESME_GENEL_ARAMA2 takip = e.Item.Tag as R_SOZLESME_GENEL_ARAMA2;
                        TList<AV001_TDIE_BIL_PROJE_SOZLESME> sozlesme =
                            DataRepository.AV001_TDIE_BIL_PROJE_SOZLESMEProvider.GetBySOZLESME_ID(takip.ID);
                        if (sozlesme.Count > 0)
                        {
                            AV001_TDIE_BIL_PROJE proj =
                                DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(sozlesme[0].PROJE_ID);
                            TList<AV001_TDIE_BIL_PROJE> seciliKayitler = new TList<AV001_TDIE_BIL_PROJE>();
                            seciliKayitler.Add(proj);
                            frmKlasorYeni kg = new frmKlasorYeni();
                            // kg.MdiParent = null;
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
                    if (e.Item.Tag is R_SOZLESME_GENEL_ARAMA2)
                    {
                        R_SOZLESME_GENEL_ARAMA2 takip = e.Item.Tag as R_SOZLESME_GENEL_ARAMA2;
                        AV001_TDI_BIL_SOZLESME hazirlik = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(takip.ID);
                        frmSozlesmeTakip frmSorusTakip = new frmSozlesmeTakip();
                        frmSorusTakip.Show(hazirlik.ID);
                    }
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
                    //frmdavaDosyaKayit.MdiParent = null;
                    frmdavaDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmdavaDosyaKayit.Show();
                }

                else if (e.Item.Name == bButonBelgeEkle.Name)
                {
                    if (e.Item.Tag is R_SOZLESME_GENEL_ARAMA2)
                    {
                        R_SOZLESME_GENEL_ARAMA2 takip = e.Item.Tag as R_SOZLESME_GENEL_ARAMA2;

                        gelenFoy = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(takip.ID);
                        string tablob = "AV001_TDI_BIL_SOZLESME";
                        bool islemYap = true;
                        if (islemYap)
                        {
                            if (gelenFoy != null)
                            {
                                frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();
                                belgeKayit.ucBelgeKayitUfak1.OpenedRecord = gelenFoy;
                                belgeKayit.SetByTableNameAndId(tablob, gelenFoy.ID);
                                belgeKayit.Child.Saved += Child_OnSave;
                                // belgeKayit.MdiParent = null;
                                belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                belgeKayit.Show();
                            }
                        }
                    }
                }

                else if (e.Item.Name == bButonIsEkle.Name)
                {
                    if (e.Item.Tag is R_SOZLESME_GENEL_ARAMA2)
                    {
                        R_SOZLESME_GENEL_ARAMA2 takip = e.Item.Tag as R_SOZLESME_GENEL_ARAMA2;
                        gelenFoy = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(takip.ID);
                        AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit =
                            new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
                        frmisKayit.ucIsKayitUfak1.ModulID = 5;
                        frmisKayit.ucIsKayitUfak1.OpenedRecord = gelenFoy;
                        frmisKayit.ucIsKayitUfak1.Modul = 5;
                        //frmisKayit.MdiParent = null;
                        frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frmisKayit.Show();
                    }
                }

                else if (e.Item.Name == bButtonNotEkle.Name)
                {
                    //if (e.Item.Tag is R_SOZLESME_GENEL_ARAMA2)
                    //{
                    //    R_SOZLESME_GENEL_ARAMA2 takip = e.Item.Tag as R_SOZLESME_GENEL_ARAMA2;
                    //    gelenFoy = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(takip.ID);
                    //    bool islemYap = true;
                    //    if (gelenFoy.ID != null && islemYap)
                    //    {
                    //        string tabloB = "AV001_TDI_BIL_SOZLESME";
                    //        AdimAdimDavaKaydi.CustomControls.frmYeniNot d = new AdimAdimDavaKaydi.CustomControls.frmYeniNot();
                    //        d.ShowDialog(tabloB, gelenFoy.ID);

                    //    }
                    //}
                }
                else if (e.Item.Name == bButtonGorusmeEkle.Name)
                {
                    bool islemYap = true;
                    if (e.Item.Tag is R_SOZLESME_GENEL_ARAMA2)
                    {
                        R_SOZLESME_GENEL_ARAMA2 takip = e.Item.Tag as R_SOZLESME_GENEL_ARAMA2;
                        gelenFoy = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(takip.ID);
                        if (!islemYap)
                            return;

                        AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit gorsumeForms =
                            new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();

                        gorsumeForms.ShowDialog(AvukatProLib.Extras.ModulTip.Sozlesme, gelenFoy.ID);
                    }
                }

                else if (e.Item.Name == bButonKisayolEkle.Name)
                {
                    if (e.Item.Tag is R_SOZLESME_GENEL_ARAMA2)
                    {
                        R_SOZLESME_GENEL_ARAMA2 takip = e.Item.Tag as R_SOZLESME_GENEL_ARAMA2;
                        gelenFoy = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(takip.ID);
                        if (gelenFoy.ID != null)
                        {
                            #region <KA-20090709>

                            //Kisayol oluşturma tek bir yere çekildi dağınıklık giderildi.
                            Kisayol.CreateShortCut(gelenFoy.ID, Kisayol.AcilisSekli.SozlesmeTakip);

                            #endregion </KA-20090709>
                        }
                    }
                }
                else if (e.Item.Name == bButtonSikKullanilan.Name)
                {
                    if (e.Item.Tag is R_SOZLESME_GENEL_ARAMA2)
                    {
                        R_SOZLESME_GENEL_ARAMA2 takip = e.Item.Tag as R_SOZLESME_GENEL_ARAMA2;
                        AvukatProLib.Extras.ModulTip tablo =
                            AvukatProLib.Extras.ModulTip.Sozlesme;

                        string AD = string.Format("{0} {1} E. nolu Dosyası", takip.BASLANGIC_TARIHI, takip.SOZLESME_ADI);
                        rfrmSikKullanilanEkle frm = new rfrmSikKullanilanEkle();
                        //frm.MdiParent = null;
                        frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm.Show(tablo, takip.ID, AD);
                    }
                }
            }
        }

        private void Child_OnSave(IList Records, IEntity Record)
        {
            if (this.Saved != null)
            {
                this.Saved(Records, Record);
            }
        }

        private void gwSozlesmeBilgi_DoubleClick(object sender, EventArgs e)
        {
            object rowData = gwSozlesmeBilgi.GetRow(gwSozlesmeBilgi.FocusedRowHandle);
            object exRowData = null;

            if (rowData is R_SOZLESME_GENEL_ARAMA2)
            {
                if (FocusedRowChanged != null)
                {
                    FocusedRowChanged((R_SOZLESME_GENEL_ARAMA2)rowData, exRowData, gwSozlesmeBilgi.FocusedRowHandle,
                                      this);
                }
            }
        }

        public void FilitreleriTemizle()
        {
            //gridView1.ActiveFilter.Clear();
        }

        public VList<R_SOZLESME_GENEL_ARAMA2> MyDataSource
        {
            get
            {
                if (gridSozlesmeBilgi.DataSource is VList<R_SOZLESME_GENEL_ARAMA2>)
                    return (VList<R_SOZLESME_GENEL_ARAMA2>)gridSozlesmeBilgi.DataSource;
                else
                    return null;
            }
            set
            {
                //if (value != null)
                //{
                gridSozlesmeBilgi.DataSource = value;
                //}
            }
        }


        [Browsable(false), Description("GridView Üzerinde Yapılan Filter Sonucundaki String Değer")]
        public string FilterString
        {
            get { return gwSozlesmeBilgi.ActiveFilterString; }
        }

        public static VList<R_SOZLESME_GENEL_ARAMA2> GetSelectedFoy(VList<R_SOZLESME_GENEL_ARAMA2> foy)
        {
            VList<R_SOZLESME_GENEL_ARAMA2> seciliKayitlar = new VList<R_SOZLESME_GENEL_ARAMA2>();

            foreach (R_SOZLESME_GENEL_ARAMA2 f in foy)
            {
                if (f.IsSelected)
                    seciliKayitlar.Add(f);
            }
            return seciliKayitlar;
        }

        /// <summary>
        /// Yorum satırı
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSozlesmeBilgi_Load(object sender, EventArgs e)
        {
            //LOAD
            if (!this.DesignMode)
            {
                gridSozlesmeBilgi.ShowOnlyPredefinedDetails = true;
                gridSozlesmeBilgi.ButtonCevirClick += gridSozlesmeBilgi_ButtonCevirClick;
                BelgeUtil.Inits.DovizTipGetir(rLueSozlesmeDovizTip);
                BelgeUtil.Inits.TarafKoduGetir(rLueTarafKod);
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rlueCari, null);

                SagTusaEkle();
            }
        }

        private void gridSozlesmeBilgi_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gridSozlesmeBilgi.Visible)
            {
                // gridSozlesmeBilgi.Visible = false;
                //extendedGridControl2.Visible = true;
            }
            else
            {
                //
                //  gridSozlesmeBilgi.Visible = true;
                //extendedGridControl2.Visible = false;
            }
        }

        public delegate void OnBelgeSaved(object belgeKayitSender, AV001_TDIE_BIL_BELGE savedBelge);


        public delegate void OnSaved(IList Records, IEntity Record);

        public event OnSaved Saved;

        private TList<TDI_KOD_SOZLESME_ALT_TIP> cloneAltTip;
        private TList<TDI_KOD_SOZLESME_TIP> cloneTip;

        private void gwSozlesmeBilgi_HiddenEditor(object sender, EventArgs e)
        {
            if (cloneAltTip != null)
            {
                cloneAltTip.Dispose();
                cloneAltTip = null;
            }
            if (cloneTip != null)
            {
                cloneTip.Dispose();
                cloneTip = null;
            }
        }

        private void gwSozlesmeBilgi_FocusedRowChanged(object sender,
                                                       DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        public event EventHandler<EventArgs> KayitSilindi;

        private void gridSozlesmeBilgi_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            //Mustafa
            Point point = ((GridControlNavigator)sender).Location;
            if (e.Button.Tag == null)
            {
                e.Handled = true;
                contextMenuStrip1.Show((GridControlNavigator)sender, point);
                return;
            }
            if (e.Button.Tag.ToString() == "KayitSil")
            {
                R_SOZLESME_GENEL_ARAMA2 sozlesme = gwSozlesmeBilgi.GetFocusedRow() as R_SOZLESME_GENEL_ARAMA2;
                if (sozlesme != null)
                {
                    string Foy_no = sozlesme.SOZLESME_NO;
                    frmKayitSil kayitSil = new frmKayitSil("AV001_TDI_BIL_SOZLESME", "ID = " + sozlesme.ID);
                    if (kayitSil.ShowDialog() == DialogResult.OK)
                    {
                        if (KayitSilindi != null)
                            KayitSilindi(this, new EventArgs());

                        XtraMessageBox.Show(Foy_no + " 'nolo Kayit Silinmiştir");
                    }
                }
            }
            else if ((e.Button.ButtonType == NavigatorButtonType.Append) && (e.Button.Tag.ToString().Contains("SOZLESME")))
            {
                contextMenuStrip1.Show((GridControlNavigator)sender, point);
                e.Handled = true;
            }
        }

        private void gridSozlesmeBilgi_DoubleClick(object sender, EventArgs e)
        {
            if (gwSozlesmeBilgi.FocusedRowHandle >= 0)
            {
                R_SOZLESME_GENEL_ARAMA2 takip = MyDataSource[gwSozlesmeBilgi.FocusedRowHandle];
                AV001_TDI_BIL_SOZLESME hazirlik = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(takip.ID);
                frmSozlesmeTakip frmSorusTakip = new frmSozlesmeTakip();
                frmSorusTakip.Show(hazirlik.ID);
            }
        }

        private void dosyaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSozlesmeKayitLayout loyut = new frmSozlesmeKayitLayout();
            loyut.Show(1);
        }

        private void genelSözleşmeSözleşmesiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSozlesmeKayitLayout loyut = new frmSozlesmeKayitLayout();
            loyut.Show();
        }

        private void markaPatentSözleşmesiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSozlesmeKayitLayout loyut = new frmSozlesmeKayitLayout();
            loyut.Show(6);
        }

        private void hakemSözleşmesiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSozlesmeKayitLayout loyut = new frmSozlesmeKayitLayout();
            loyut.Show(5);
        }

        private void krediKartıSözleşmesiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            frmSozlesmeKayitLayout loyut = new frmSozlesmeKayitLayout();
            loyut.Show(2, Convert.ToInt32(item.Tag));
        }

        private void garyimenkulİpoteğiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            frmSozlesmeKayitLayout loyut = new frmSozlesmeKayitLayout();
            loyut.Show(3, Convert.ToInt32(item.Tag));
        }

        private void diğerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSozlesmeKayitLayout loyut = new frmSozlesmeKayitLayout();
            loyut.Show();
        }
    }
}