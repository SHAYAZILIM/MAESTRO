//#define tmpTOTALOZEL
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Util;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucHazirlik : AvpXUserControl
    {
        public ucHazirlik()
        {
            this.Load += ucHazirlik_Load;
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "CARI_ID" && e.Column.Caption == "Sorumlu")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kiþinin");

                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve Ýletiþim Bilgileri");
                BarButtonItem barBtnCariRapor = new BarButtonItem(e.Manager, "Bu Þahsýn Raporuna Git");
                //barBtnSecimiKaldir.Tag = e.Column;

                bus.ItemLinks.Add(barBtnSecimiKaldir);
                bus.ItemLinks.Add(barBtnCariRapor);
                AV001_TD_BIL_HAZIRLIK_SORUMLU secim = e.Rows as AV001_TD_BIL_HAZIRLIK_SORUMLU;

                int? id = secim.CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                    barBtnCariRapor.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                barBtnCariRapor.ItemClick += barBtnCariRapor_ItemClick;
                e.MyPopupMenu.ItemLinks.Add(bus);
            }
            else if (e.Column != null && e.Column.FieldName == "CARI_ID")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kiþinin");

                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve Ýletiþim Bilgileri");
                BarButtonItem barBtnCariRapor = new BarButtonItem(e.Manager, "Bu Þahsýn Raporuna Git");
                //barBtnSecimiKaldir.Tag = e.Column;

                bus.ItemLinks.Add(barBtnSecimiKaldir);
                bus.ItemLinks.Add(barBtnCariRapor);
                AV001_TD_BIL_HAZIRLIK_TARAF secim = e.Rows as AV001_TD_BIL_HAZIRLIK_TARAF;

                int? id = secim.CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                    barBtnCariRapor.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                barBtnCariRapor.ItemClick += barBtnCariRapor_ItemClick;
                e.MyPopupMenu.ItemLinks.Add(bus);
            }
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
                    // frmSorusturma.MdiParent = null;
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
                    //.MdiParent = null;
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
                    if (e.Item.Tag is AV001_TD_BIL_HAZIRLIK)
                    {
                        AV001_TD_BIL_HAZIRLIK takip = e.Item.Tag as AV001_TD_BIL_HAZIRLIK;

                        string tablob = "AV001_TD_BIL_HAZIRLIK";
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
                    if (e.Item.Tag is AV001_TD_BIL_HAZIRLIK)
                    {
                        AV001_TD_BIL_HAZIRLIK takip = e.Item.Tag as AV001_TD_BIL_HAZIRLIK;
                        string tabloI = "AV001_TD_BIL_HAZIRLIK";
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
                    //if (e.Item.Tag is AV001_TD_BIL_HAZIRLIK)
                    //{
                    //    AV001_TD_BIL_HAZIRLIK takip = e.Item.Tag as AV001_TD_BIL_HAZIRLIK;
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
                    if (e.Item.Tag is AV001_TD_BIL_HAZIRLIK)
                    {
                        AV001_TD_BIL_HAZIRLIK takip = e.Item.Tag as AV001_TD_BIL_HAZIRLIK;
                        if (!islemYap)
                            return;

                        AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit gorsumeForms =
                            new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();

                        gorsumeForms.ShowDialog(AvukatProLib.Extras.ModulTip.Sorusturma, takip.ID);
                    }
                }

                else if (e.Item.Name == bButonKisayolEkle.Name)
                {
                    AV001_TD_BIL_HAZIRLIK takip = e.Item.Tag as AV001_TD_BIL_HAZIRLIK;

                    if (takip.ID != null)
                    {
                        #region <KA-20090709>

                        //Kisayol oluþturma tek bir yere çekildi daðýnýklýk giderildi.
                        Kisayol.CreateShortCut(takip.ID, Kisayol.AcilisSekli.SorusturmaTakip);

                        #endregion </KA-20090709>
                    }
                    //if (e.Item.Tag is AV001_TD_BIL_HAZIRLIK)
                    //{
                    //    AV001_TD_BIL_HAZIRLIK takip = e.Item.Tag as AV001_TD_BIL_HAZIRLIK;
                    //    string dosyaUzantisi = string.Empty;
                    //    if (takip.ID != null)
                    //    {
                    //        dosyaUzantisi = "Soruþturma Dosyasý (*.avph)|*.AVPH";
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
                    if (e.Item.Tag is AV001_TD_BIL_HAZIRLIK)
                    {
                        AV001_TD_BIL_HAZIRLIK takip = e.Item.Tag as AV001_TD_BIL_HAZIRLIK;
                        DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(takip, false, DeepLoadType.IncludeChildren,
                                                                              typeof(TList<TDI_KOD_ADLI_BIRIM_ADLIYE>),
                                                                              typeof(TList<TDI_KOD_ADLI_BIRIM_GOREV>),
                                                                              typeof(TList<TDI_KOD_ADLI_BIRIM_NO>));
                        AvukatProLib.Extras.ModulTip tablo =
                            AvukatProLib.Extras.ModulTip.Sorusturma;
                        string adliye = string.Empty;
                        string gorev = string.Empty;
                        string no = string.Empty;
                        if (takip.ADLI_BIRIM_ADLIYE_IDSource != null)
                            adliye = takip.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                        if (takip.ADLI_BIRIM_GOREV_IDSource != null)
                            gorev = takip.ADLI_BIRIM_GOREV_IDSource.GOREV;
                        if (takip.ADLI_BIRIM_NO_IDSource != null)
                            no = takip.ADLI_BIRIM_NO_IDSource.NO;
                        string AD = string.Format("{0} {1} {2} {3}E. nolu Dosyasý", adliye, gorev, no,
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
                //cariForms.MdiParent = null;
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

        //Yeni satýr ekleme butonu Append (extendedNavBar da ) pasif edildi kenan beyin isteði doðrultusunda ..
        private List<AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_NEW> _MyDataSource;

        public List<AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_NEW> MyDataSource
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
            extendedGridControl1.DataSource = MyDataSource;
        }

        public void FilitreleriTemizle()
        {
            gridView1.ActiveFilter.Clear();
        }

        public void SorusturmaHazirlikLoad()
        {
            if (!this.DesignMode)
            {
                gridHazirlik.ShowOnlyPredefinedDetails = true;

                gridHazirlik.ButtonCevirClick += gridHazirlik_ButtonCevirClick;
                extendedGridControl1.ButtonCevirClick += gridHazirlik_ButtonCevirClick;

                BelgeUtil.Inits.CariSifatGetir(rLueCariSifatID);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimID);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorevID);
                BelgeUtil.Inits.HazirlikDurumGetir(rLueHazirlikDurumID);
                BelgeUtil.Inits.perCariGetir(rLueCari);
                BelgeUtil.Inits.perCariGetir(rLueCari2);
                BelgeUtil.Inits.perCariGetir(lueSorumlu);
                BelgeUtil.Inits.SikayetKonuDavaTalepCezaGetir(rLueSikayatKonuID, "c");
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeID);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimID);
                BelgeUtil.Inits.TarafKoduEnumGetir(rLueTarafKoduID);

                //GetData.initCari(new RepositoryItemLookUpEdit[] { rLueSavcý, rLueHazirlikCari, rLueHazirlikCari1 });

                //SikayetKonuGetir(new RepositoryItemLookUpEdit[] { rLueSikayetKon });

                //Inits.AdliBirimGorevGetir(repositoryItemLookUpEdit13);
                //                GorevGetir(new RepositoryItemLookUpEdit[] { repositoryItemLookUpEdit13 });
                //DurumGetir(new RepositoryItemLookUpEdit[] { repositoryItemLookUpEdit11 });
            }
        }

        public static TList<AV001_TD_BIL_HAZIRLIK> GetSelectedFoy(TList<AV001_TD_BIL_HAZIRLIK> foy)
        {
            TList<AV001_TD_BIL_HAZIRLIK> seciliKayitlar = new TList<AV001_TD_BIL_HAZIRLIK>();

            foreach (AV001_TD_BIL_HAZIRLIK f in foy)
            {
                if (f.IsSelected)
                    seciliKayitlar.Add(f);
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

        private void gridHazirlik_ButtonCevirClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            //GRDÝLERÝ DEÐÝÞTÝR
            if (gridHazirlik.Visible)
            {
                gridHazirlik.Visible = false;
                extendedGridControl1.Visible = true;
            }
            else
            {
                gridHazirlik.Visible = true;
                extendedGridControl1.Visible = false;
            }
        }

        private void lookUpExtender1_OnClickOrProcessNewValue(object sender, LookUpExtenderEventArgs e)
        {
            if (e.SenderLookUp.Properties.Name.Contains("Cari") || e.SenderLookUp.Properties.Name.Contains("Savc") ||
                (e.SenderLookUp.Properties.Name.Contains("rLueHazirlikCari")))
            {
                frmCariGenelGiris frm = new frmCariGenelGiris();
                if (e.IsTypedValue)
                    frm.tmpCariAd = e.TypedValue;

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                DialogResult dr = frm.KayitBasarili;

                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    ((TList<AV001_TDI_BIL_CARI>)(e.SenderLookUp.Properties.DataSource)).Add(frm.MyCari);
                }
            }
            if (e.SenderLookUp != null)
                if (e.SenderLookUp.Properties.Name.Contains("Durum") && e.IsTypedValue)
                {
                    try
                    {
                        TD_KOD_HAZIRLIK_DURUM ozel = new TD_KOD_HAZIRLIK_DURUM();

                        ozel.DURUM = e.TypedValue;
                        AvukatProLib2.Data.DataRepository.TD_KOD_HAZIRLIK_DURUMProvider.Save(ozel);
                        ((TList<TD_KOD_HAZIRLIK_DURUM>)e.SenderLookUp.Properties.DataSource).Add(ozel);
                        //Inits.FoyOzelKodGetir(e.SenderLookUp);
                        //OzelKodGetir(e.SenderLookUp);
                        XtraMessageBox.Show("Durum baþarýyla eklenmiþtir.");
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            if (e.SenderLookUp.Properties.Name.Contains("Sikayet") && e.IsTypedValue)
            {
                try
                {
                    TD_KOD_DAVA_TALEP ozel = new TD_KOD_DAVA_TALEP();

                    ozel.DAVA_TALEP = e.TypedValue;
                    ozel.ADLI_BIRIM_BOLUM_ID = 1; //CEZA
                    ozel.KONTROL_KIM = "AVUKATPRO";
                    ozel.ADLI_BIRIM_BOLUM_KOD = "C";

                    AvukatProLib2.Data.DataRepository.TD_KOD_DAVA_TALEPProvider.Save(ozel);
                    ((TList<TD_KOD_DAVA_TALEP>)e.SenderLookUp.Properties.DataSource).Add(ozel);

                    XtraMessageBox.Show("Þikayet konusu baþarýyla eklenmiþtir.");
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }
    }
}