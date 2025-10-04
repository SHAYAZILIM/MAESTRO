using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AdimAdimDavaKaydi.Util;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Data;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucHazirlikArama : AvpXUserControl
    {
        public ucHazirlikArama()
        {
            this.Load += ucHazirlik_Load;
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "SORUMLU_AVUKAT")
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
                R_SORUSTURMA_GENEL_ARAMA secim = e.Rows as R_SORUSTURMA_GENEL_ARAMA;

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
            else if (e.Column != null && e.Column.FieldName == "IZLEYEN_AVUKAT")
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
                R_SORUSTURMA_GENEL_ARAMA secim = e.Rows as R_SORUSTURMA_GENEL_ARAMA;

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
                R_SORUSTURMA_GENEL_ARAMA secim = e.Rows as R_SORUSTURMA_GENEL_ARAMA;

                int? id = secim.TAKIP_EDEN_CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                    barBtnCariRapor.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                barBtnCariRapor.ItemClick += barBtnCariRapor_ItemClick;
                e.MyPopupMenu.ItemLinks.Add(bus);
            }
            else if (e.Column != null && e.Column.FieldName == "TAKIP_EDILEN")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kişinin");
                bus.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Client_2_22x22;
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve İletişim Bilgileri");
                BarButtonItem barBtnCariRapor = new BarButtonItem(e.Manager, "Bu Şahsın Raporuna Git");
                bus.ItemLinks.Add(barBtnSecimiKaldir);
                bus.ItemLinks.Add(barBtnCariRapor);
                R_SORUSTURMA_GENEL_ARAMA secim = e.Rows as R_SORUSTURMA_GENEL_ARAMA;
                barBtnCariRapor.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.rapor02_22;
                barBtnSecimiKaldir.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.personel_isleri;
                int? id = secim.TAKIP_EDILEN_CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                    barBtnCariRapor.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                barBtnCariRapor.ItemClick += barBtnCariRapor_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(2, bus);
            }
            BarButtonItem bus2 = new BarButtonItem(e.Manager, "Masa Üstüne Kısayol");
            bus2.Tag = e.Rows;
            bus2.Name = "bButonKisayolEkle";
            bus2.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.masa_ustu16x16;
            BarButtonItem bus3 = new BarButtonItem(e.Manager, "Sık Kullanılanlar");
            bus3.Name = "bButtonSikKullanilan";
            bus3.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.favorite_add_22x221;
            bus3.Tag = e.Rows;
            //BarButtonItem bus4 = new BarButtonItem(e.Manager, "Klasörünü Aç");
            //bus4.Tag = e.Rows;
            //bus4.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.dosya_ac_22x22;
            //bus4.Name = "bButtonKlasorAc";
            //BarButtonItem bus5 = new BarButtonItem(e.Manager, "Takip Ekranına Gönder");
            //bus5.Tag = e.Rows;
            //bus5.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.gonder16x16;
            //bus5.Name = "bButtonTakipGonder";

            e.MyPopupMenu.ItemLinks.Insert(3, bus2);
            e.MyPopupMenu.ItemLinks.Insert(4, bus3);
            //e.MyPopupMenu.ItemLinks.Insert(5, bus4);
            //e.MyPopupMenu.ItemLinks.Insert(6, bus5);
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
                    // frmicraDosyaKayit.MdiParent = null;
                    frmicraDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmicraDosyaKayit.Show();
                }
                else if (e.Item.Name == bBtnSozlesmeEkle.Name)
                {
                    AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit frmsozlesmeKayit =
                        new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit();
                    // frmsozlesmeKayit.MdiParent = null;
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
                    //.MdiParent = null;
                    frmdavaDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmdavaDosyaKayit.Show();
                }

                else if (e.Item.Name == bButonBelgeEkle.Name)
                {
                    //if (e.Item.Tag is R_SORUSTURMA_GENEL_ARAMA)
                    //{
                        //R_SORUSTURMA_GENEL_ARAMA genel = e.Item.Tag as R_SORUSTURMA_GENEL_ARAMA;
                    AV001_TD_BIL_HAZIRLIK takip = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID((int)gwHazirlik.GetFocusedRowCellValue("ID"));
                        string tablob = "AV001_TD_BIL_HAZIRLIK";
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
                else if (e.Item.Name == "bButtonKlasorAc")
                {
                    if (e.Item.Tag is R_SORUSTURMA_GENEL_ARAMA)
                    {
                        R_SORUSTURMA_GENEL_ARAMA takip = e.Item.Tag as R_SORUSTURMA_GENEL_ARAMA;
                        TList<AV001_TDIE_BIL_PROJE_HAZIRLIK> hazirlik =
                            DataRepository.AV001_TDIE_BIL_PROJE_HAZIRLIKProvider.GetByHAZIRLIK_ID(takip.ID);
                        if (hazirlik.Count > 0)
                        {
                            AV001_TDIE_BIL_PROJE proj =
                                DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(hazirlik[0].PROJE_ID);
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
                    }
                }
                else if (e.Item.Name == "bButtonTakipGonder")
                {
                    if (e.Item.Tag is R_SORUSTURMA_GENEL_ARAMA)
                    {
                        R_SORUSTURMA_GENEL_ARAMA takip = e.Item.Tag as R_SORUSTURMA_GENEL_ARAMA;
                        AV001_TD_BIL_HAZIRLIK hazirlik = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(takip.ID);
                        TList<AV001_TD_BIL_HAZIRLIK> foyList = new TList<AV001_TD_BIL_HAZIRLIK>();
                        foyList.Add(hazirlik);
                        rFrmSorusturmaTakip frmSorusTakip = new rFrmSorusturmaTakip();
                        frmSorusTakip.Show(foyList);
                    }
                }
                //
                else if (e.Item.Name == bButonIsEkle.Name)
                {
                    //if (e.Item.Tag is R_SORUSTURMA_GENEL_ARAMA)
                    //{
                        //R_SORUSTURMA_GENEL_ARAMA hazirlik = e.Item.Tag as R_SORUSTURMA_GENEL_ARAMA;
                    AV001_TD_BIL_HAZIRLIK takip = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID((int)gwHazirlik.GetFocusedRowCellValue("ID"));
                        AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit =
                            new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
                        frmisKayit.ucIsKayitUfak1.ModulID = 3;
                        frmisKayit.ucIsKayitUfak1.OpenedRecord = takip;
                        frmisKayit.ucIsKayitUfak1.Modul = 3;
                        // frmisKayit.MdiParent = null;
                        frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frmisKayit.Show();
                    //}
                }

                else if (e.Item.Name == bButtonNotEkle.Name)
                {
                    //if (e.Item.Tag is R_SORUSTURMA_GENEL_ARAMA)
                    //{
                    //    R_SORUSTURMA_GENEL_ARAMA takip = e.Item.Tag as R_SORUSTURMA_GENEL_ARAMA;
                    //    bool islemYap = true;
                    //    if (takip.ID != null && islemYap)
                    //    {
                    //        string tabloB = "AV001_TD_BIL_HAZIRLIK";
                    //        AdimAdimDavaKaydi.CustomControls.frmYeniNot d = new AdimAdimDavaKaydi.CustomControls.frmYeniNot();
                    //        d.ShowDialog(tabloB, takip.ID);

                    //    }
                    //}
                }
                else if (e.Item.Name == bButtonGorusmeEkle.Name)
                {
                    bool islemYap = true;
                    //if (e.Item.Tag is R_SORUSTURMA_GENEL_ARAMA)
                    //{
                        //R_SORUSTURMA_GENEL_ARAMA takip = e.Item.Tag as R_SORUSTURMA_GENEL_ARAMA;
                        if (!islemYap)
                            return;

                        AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit gorsumeForms =
                            new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();

                        gorsumeForms.ShowDialog(AvukatProLib.Extras.ModulTip.Sorusturma, (int)gwHazirlik.GetFocusedRowCellValue("ID"));
                    //}
                }

                else if (e.Item.Name == "bButonKisayolEkle")
                {
                    R_SORUSTURMA_GENEL_ARAMA takip = e.Item.Tag as R_SORUSTURMA_GENEL_ARAMA;

                    if (takip.ID != null)
                    {
                        #region <KA-20090709>

                        //Kisayol oluşturma tek bir yere çekildi dağınıklık giderildi.
                        Kisayol.CreateShortCut(takip.ID, Kisayol.AcilisSekli.SorusturmaTakip);

                        #endregion </KA-20090709>
                    }
                    //if (e.Item.Tag is AV001_TD_BIL_HAZIRLIK)
                    //{
                    //    AV001_TD_BIL_HAZIRLIK takip = e.Item.Tag as AV001_TD_BIL_HAZIRLIK;
                    //    string dosyaUzantisi = string.Empty;
                    //    if (takip.ID != null)
                    //    {
                    //        dosyaUzantisi = "Soruşturma Dosyası (*.avph)|*.AVPH";
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
                else if (e.Item.Name == "bButtonSikKullanilan")
                {
                    if (e.Item.Tag is R_SORUSTURMA_GENEL_ARAMA)
                    {
                        R_SORUSTURMA_GENEL_ARAMA takip = e.Item.Tag as R_SORUSTURMA_GENEL_ARAMA;
                        AvukatProLib.Extras.ModulTip tablo =
                            AvukatProLib.Extras.ModulTip.Sorusturma;
                        string adliye = string.Empty;
                        string gorev = string.Empty;
                        string no = string.Empty;
                        if (takip.ADLI_BIRIM_ADLIYE != null)
                            adliye = takip.ADLI_BIRIM_ADLIYE;
                        if (takip.ADLI_BIRIM_GOREV != null)
                            gorev = takip.ADLI_BIRIM_GOREV;
                        if (takip.ADLI_BIRIM_NO != null)
                            no = takip.ADLI_BIRIM_NO;
                        string AD = string.Format("{0} {1} {2} {3} E. nolu Dosyası", adliye, gorev, no,
                                                  takip.HAZIRLIK_ESAS_NO);
                        rfrmSikKullanilanEkle frm = new rfrmSikKullanilanEkle();
                        frm.ShowDialog(tablo, takip.ID, AD);
                    }
                }
            }
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
                //.MdiParent = null;
                cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cariForms.Show();
            }
        }

        public void SagTusaEkle()
        {
            //gcKurumsalGiris.RightClickPopup.BarItemCollections.Assign(popupMenu1.LinksPersistInfo);
            gridHazirlik.RightClickPopup.LinkPersist = new DevExpress.XtraBars.LinksInfo();
            foreach (DevExpress.XtraBars.LinkPersistInfo var in popupMenu1.LinksPersistInfo)
            {
                gridHazirlik.RightClickPopup.LinkPersist.Add(var);
            }
        }

        //Yeni satır ekleme butonu Append (extendedNavBar da ) pasif edildi kenan beyin isteği doğrultusunda ..
        private DataTable _MyDataSource;

        public DataTable MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        public void BindData()
        {
            gridHazirlik.DataSource = MyDataSource;
        }

        public void FilitreleriTemizle()
        {
            gwHazirlik.ActiveFilter.Clear();
        }

        public void SorusturmaHazirlikLoad()
        {
            if (!this.DesignMode)
            {
                gridHazirlik.ShowOnlyPredefinedDetails = true;
                BelgeUtil.Inits.TarafKoduEnumGetir(rLueTarafKoduID);
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rlueCari, null);
            }
        }

        public static VList<R_SORUSTURMA_GENEL_ARAMA> GetSelectedFoy(DataTable foy)
        {
            VList<R_SORUSTURMA_GENEL_ARAMA> seciliKayitlar = new VList<R_SORUSTURMA_GENEL_ARAMA>();

            foreach (DataRow f in foy.Rows)
            {
                if ((bool)f["IsSelected"])
                    seciliKayitlar.Add(DataRepository.R_SORUSTURMA_GENEL_ARAMAProvider.Get("Id=" + f["Id"].ToString(),"Id")[0]);
            }
            return seciliKayitlar;
        }

        private void ucHazirlik_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            IsLoaded = true;
            gridHazirlik.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            gridHazirlik.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
            BindData();
            SorusturmaHazirlikLoad();
            SagTusaEkle();
        }

        public event EventHandler<EventArgs> KayitSilindi;

        private void gridHazirlik_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == "KayitSil")
            {
                //R_SORUSTURMA_GENEL_ARAMA sorusturma = gwHazirlik.GetFocusedRow() as R_SORUSTURMA_GENEL_ARAMA;
                //string Foy_no = sorusturma.HAZIRLIK_NO;

                frmKayitSil kayitSil = new frmKayitSil("AV001_TD_BIL_HAZIRLIK", "ID = " + gwHazirlik.GetFocusedRowCellValue("ID"));
                if (kayitSil.ShowDialog() == DialogResult.OK)
                {
                    if (KayitSilindi != null)
                        KayitSilindi(this, new EventArgs());

                    XtraMessageBox.Show(gwHazirlik.GetFocusedRowCellValue("HAZIRLIK_NO") + " 'nolo Kayit Silinmiştir");
                }
            }
        }

        private void gridHazirlik_DoubleClick(object sender, EventArgs e)
        {
            if (gwHazirlik.FocusedRowHandle >= 0)
            {
                R_SORUSTURMA_GENEL_ARAMA takip = DataRepository.R_SORUSTURMA_GENEL_ARAMAProvider.Get("Id=" + gwHazirlik.GetFocusedRowCellValue("ID"), "Id")[0];
                AV001_TD_BIL_HAZIRLIK hazirlik = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(takip.ID);
                TList<AV001_TD_BIL_HAZIRLIK> foyList = new TList<AV001_TD_BIL_HAZIRLIK>();
                foyList.Add(hazirlik);
                rFrmSorusturmaTakip frmSorusTakip = new rFrmSorusturmaTakip();
                frmSorusTakip.Show(foyList);
            }
        }
    }
}