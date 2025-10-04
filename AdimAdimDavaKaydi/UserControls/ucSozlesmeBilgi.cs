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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucSozlesmeBilgi : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSozlesmeBilgi()
        {
            InitializeComponent();
            gwSozlesmeBilgi.MouseDown += gwSozlesmeBilgi_MouseDown;
            gwSozlesmeBilgi.DoubleClick += gwSozlesmeBilgi_DoubleClick;
            gridSozlesmeBilgi.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            gridSozlesmeBilgi.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
        }

        private GridHitInfo gridHitInfo;

        private void gwSozlesmeBilgi_MouseDown(object sender, MouseEventArgs e)
        {
            gridHitInfo = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));
        }

        public delegate void OnFocusedRowChanged(
            AV001_TDI_BIL_SOZLESME sozlesme, AV001_TDI_BIL_SOZLESME ExSozlesme, int RowHandle, object sender);

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
            if (e.Column != null && e.Column.FieldName == "SORUMLU_CARI_ID")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kiþinin");

                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve Ýletiþim Bilgileri");
                BarButtonItem barBtnCariRapor = new BarButtonItem(e.Manager, "Bu Þahsýn Raporuna Git");
                //barBtnSecimiKaldir.Tag = e.Column;

                bus.ItemLinks.Add(barBtnSecimiKaldir);
                bus.ItemLinks.Add(barBtnCariRapor);
                AV001_TDI_BIL_SOZLESME_SORUMLU secim = e.Rows as AV001_TDI_BIL_SOZLESME_SORUMLU;

                int? id = secim.SORUMLU_CARI_ID;
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
                AV001_TDI_BIL_SOZLESME_TARAF secim = e.Rows as AV001_TDI_BIL_SOZLESME_TARAF;

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
                    // tKayit.MdiParent = null;
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
                    if (e.Item.Tag is AV001_TDI_BIL_SOZLESME)
                    {
                        AV001_TDI_BIL_SOZLESME takip = e.Item.Tag as AV001_TDI_BIL_SOZLESME;

                        string tablob = "AV001_TDI_BIL_SOZLESME";
                        bool islemYap = true;
                        if (islemYap)
                        {
                            if (takip != null)
                            {
                                frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();
                                belgeKayit.SetByTableNameAndId(tablob, takip.ID);
                                belgeKayit.Child.Saved += Child_OnSave;
                                //belgeKayit.MdiParent = null;
                                belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                belgeKayit.Show();
                            }
                        }
                    }
                }

                else if (e.Item.Name == bButonIsEkle.Name)
                {
                    if (e.Item.Tag is AV001_TDI_BIL_SOZLESME)
                    {
                        AV001_TDI_BIL_SOZLESME takip = e.Item.Tag as AV001_TDI_BIL_SOZLESME;
                        string tabloI = "AV001_TDI_BIL_SOZLESME";
                        AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit =
                            new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();

                        frmisKayit.SetByTableNameAndId(tabloI, takip.ID);
                        // frmisKayit.MdiParent = null;
                        frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frmisKayit.Show();
                    }
                }

                else if (e.Item.Name == bButtonNotEkle.Name)
                {
                    //if (e.Item.Tag is AV001_TDI_BIL_SOZLESME)
                    //{
                    //    AV001_TDI_BIL_SOZLESME takip = e.Item.Tag as AV001_TDI_BIL_SOZLESME;
                    //    bool islemYap = true;
                    //    if (takip.ID != null && islemYap)
                    //    {
                    //        string tabloB = "AV001_TDI_BIL_SOZLESME";
                    //        AdimAdimDavaKaydi.CustomControls.frmYeniNot d = new AdimAdimDavaKaydi.CustomControls.frmYeniNot();
                    //        d.ShowDialog(tabloB, takip.ID);

                    //    }
                    //}
                }
                else if (e.Item.Name == bButtonGorusmeEkle.Name)
                {
                    bool islemYap = true;
                    if (e.Item.Tag is AV001_TDI_BIL_SOZLESME)
                    {
                        AV001_TDI_BIL_SOZLESME takip = e.Item.Tag as AV001_TDI_BIL_SOZLESME;
                        if (!islemYap)
                            return;

                        AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit gorsumeForms =
                            new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();

                        gorsumeForms.ShowDialog(AvukatProLib.Extras.ModulTip.Sozlesme, takip.ID);
                    }
                }

                else if (e.Item.Name == bButonKisayolEkle.Name)
                {
                    if (e.Item.Tag is AV001_TDI_BIL_SOZLESME)
                    {
                        AV001_TDI_BIL_SOZLESME takip = e.Item.Tag as AV001_TDI_BIL_SOZLESME;
                        if (takip.ID != null)
                        {
                            #region <KA-20090709>

                            //Kisayol oluþturma tek bir yere çekildi daðýnýklýk giderildi.
                            Kisayol.CreateShortCut(takip.ID, Kisayol.AcilisSekli.SozlesmeTakip);

                            #endregion </KA-20090709>
                        }
                        //string dosyaUzantisi = string.Empty;
                        //if (takip.ID != null)
                        //{
                        //    dosyaUzantisi = "Sözleþme Dosyasý (*.avps)|*.AVPS";
                        //    string kaydedilecek = takip.ID.ToString();

                        //    SaveFileDialog sfd = new SaveFileDialog();
                        //    sfd.Filter = dosyaUzantisi;

                        //    DialogResult sonuc = sfd.ShowDialog();
                        //    if (sonuc == DialogResult.OK)
                        //    {
                        //        try
                        //        {
                        //            byte[] veri = System.Text.Encoding.UTF8.GetBytes(kaydedilecek);

                        //            Tools.SaveTofile(sfd.FileName, veri);
                        //        }
                        //        catch (Exception ex)
                        //        {
                        //            BelgeUtil.ErrorHandler.Catch(this, ex);
                        //        }
                        //    }
                        //}
                    }
                }
                else if (e.Item.Name == bButtonSikKullanilan.Name)
                {
                    if (e.Item.Tag is AV001_TDI_BIL_SOZLESME)
                    {
                        AV001_TDI_BIL_SOZLESME takip = e.Item.Tag as AV001_TDI_BIL_SOZLESME;
                        AvukatProLib.Extras.ModulTip tablo =
                            AvukatProLib.Extras.ModulTip.Sorusturma;

                        string AD = string.Format("{0} {1} E. nolu Dosyasý", takip.BASLANGIC_TARIHI, takip.SOZLESME_ADI);
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
            if (gridHitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.Row
                || gridHitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell
                || gridHitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowIndicator)
            {
                AV001_TDI_BIL_SOZLESME obj = (AV001_TDI_BIL_SOZLESME)gwSozlesmeBilgi.GetFocusedRow();

                if (obj == null) return;

                TList<AV001_TDI_BIL_SOZLESME> foys = new TList<AV001_TDI_BIL_SOZLESME>();
                foys.Add(obj);

                frmSozlesmeTakip frm = new frmSozlesmeTakip();
                frm.Show(obj.ID);
            }
        }

        public void FilitreleriTemizle()
        {
            gridView1.ActiveFilter.Clear();
        }

        public TList<AV001_TDI_BIL_SOZLESME> MyDataSource
        {
            get
            {
                if (gridSozlesmeBilgi.DataSource is TList<AV001_TDI_BIL_SOZLESME>)
                    return (TList<AV001_TDI_BIL_SOZLESME>)gridSozlesmeBilgi.DataSource;
                else
                    return null;
            }
            set
            {
                if (value != null)
                {
                    gridSozlesmeBilgi.DataSource = value;
                    extendedGridControl1.DataSource = gridSozlesmeBilgi.DataSource;
                    extendedGridControl2.DataSource = gridSozlesmeBilgi.DataSource;
                }
            }
        }


        [Browsable(false), Description("GridView Üzerinde Yapýlan Filter Sonucundaki String Deðer")]
        public string FilterString
        {
            get { return gwSozlesmeBilgi.ActiveFilterString; }
        }

        public static TList<AV001_TDI_BIL_SOZLESME> GetSelectedFoy(TList<AV001_TDI_BIL_SOZLESME> foy)
        {
            TList<AV001_TDI_BIL_SOZLESME> seciliKayitlar = new TList<AV001_TDI_BIL_SOZLESME>();

            foreach (AV001_TDI_BIL_SOZLESME f in foy)
            {
                if (f.IsSelected)
                    seciliKayitlar.Add(f);
            }
            return seciliKayitlar;
        }

        /// <summary>
        /// Yorum satýrý
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
                extendedGridControl1.ButtonCevirClick += gridSozlesmeBilgi_ButtonCevirClick;
                extendedGridControl2.ButtonCevirClick += gridSozlesmeBilgi_ButtonCevirClick;
                BelgeUtil.Inits.SozlesmeTipiGetir(rLueSozlesmeTipi);
                BelgeUtil.Inits.SozlesmeAltTipiHepsiGetir(rLueSozlesmeAltTip);
                BelgeUtil.Inits.SozlesmeSekliGetir(rLueSozlesmeTur);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
                BelgeUtil.Inits.SozlesmeOzelKod(rLueOzelKod1);
                BelgeUtil.Inits.SozlesmeOzelKod(rLueOzelKod2);
                BelgeUtil.Inits.SozlesmeOzelKod(rLueOzelKod3);
                BelgeUtil.Inits.SozlesmeOzelKod(rLueOzelKod4);
                BelgeUtil.Inits.DovizTipGetir(rLueKur);
                BelgeUtil.Inits.perCariGetir(rLueYeddiEminCari);
                BelgeUtil.Inits.OdemeTipiGetir(rLueOdemePeriyodu);
                BelgeUtil.Inits.KrediTipiGetir(rLueKartTipi);
                BelgeUtil.Inits.DovizTipGetir(rLueSozlesmeDovizTip);
                BelgeUtil.Inits.CariSifatGetir(rLueSozlesmeTarafSifat);
                BelgeUtil.Inits.MalKategoriGetir(rLueSozMalKategori);
                BelgeUtil.Inits.MalTurGetir(rLueSozMalTur);
                BelgeUtil.Inits.MalcinsGetir(rLueSozMalCins);
                BelgeUtil.Inits.BirimKodGetir(rLueSozMalAdetBirim);
                BelgeUtil.Inits.AsamaKodGetir(rLueAsamaKod);
                BelgeUtil.Inits.AsamaAltKodGetir(rLueAsamaAltKod);
                BelgeUtil.Inits.AsamaOzelDurumGetir(rLueAsamaOzelDurumLar);
                BelgeUtil.Inits.ParaBicimiAyarla(rSePara);
                BelgeUtil.Inits.ParaBicimiAyarla(repositoryItemSpinEdit2);
                BelgeUtil.Inits.ParaBicimiAyarla(repositoryItemSpinEdit1);
                BelgeUtil.Inits.RehinCinsGetir(rLueRehinCinsi);
                BelgeUtil.Inits.SicilTipGetir(rLueSicilTipi);
                BelgeUtil.Inits.SozlesmeDurumGetir(rLueSozlesmeDurumu);
                //Inits.TarihAlaniAyarla(repositoryItemDateEdit1);
                SagTusaEkle();
                AV001_TDI_BIL_SOZLESME ada = new AV001_TDI_BIL_SOZLESME();
                //ada.
                //ada.AV001_TDI_BIL_SOZLESME_DETAYCollection
                //ada.AV001_TDI_BIL_SOZLESME_SORUMLUCollection
                //ada.AV001_TDI_BIL_SOZLESME_TARAFCollection
                //ada.AV001_TDIE_BIL_ASAMACollection
            }
        }

        private void gridSozlesmeBilgi_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gridSozlesmeBilgi.Visible)
            {
                extendedGridControl1.Visible = true;
                extendedGridControl2.Visible = false;
                gridSozlesmeBilgi.Visible = false;
                //extendedGridControl2.Visible = true;
            }
            else
            {
                extendedGridControl1.Visible = false;
                extendedGridControl2.Visible = false;
                gridSozlesmeBilgi.Visible = true;
                //extendedGridControl2.Visible = false;
            }
        }

        private void gridSozlesmeBilgi_Click(object sender, EventArgs e)
        {

        }

        private void gwSozlesmeBilgi_ShownEditor(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gonderen = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gonderen != null)
            {
                if (gonderen.FocusedRowHandle >= 0)
                {
                    if (gonderen.FocusedColumn.Tag != null && gonderen.FocusedColumn.Tag.ToString().Contains("TIP") &&
                        gonderen.ActiveEditor is LookUpEdit)
                    {
                        AV001_TDI_BIL_SOZLESME sozlesme = null;
                        LookUpEdit edit = (LookUpEdit)gonderen.ActiveEditor;
                        //if (gonderen.FocusedRowHandle > 0)
                        sozlesme = gonderen.GetFocusedRow() as AV001_TDI_BIL_SOZLESME;
                        //else
                        //    sozlesme = gonderen.GetRow(0) as AV001_TDI_BIL_SOZLESME;

                        if (edit.Properties.Tag == "ALTTIP")
                        {
                            TList<TDI_KOD_SOZLESME_ALT_TIP> atip =
                                edit.Properties.DataSource as TList<TDI_KOD_SOZLESME_ALT_TIP>;
                            cloneAltTip = new TList<TDI_KOD_SOZLESME_ALT_TIP>(atip);

                            if (sozlesme.TIP_ID.HasValue)
                            {
                                cloneAltTip.Filter = "ANA_TIP_ID = " + sozlesme.TIP_ID.Value;
                                edit.Properties.DataSource = cloneAltTip;
                            }
                        }
                    }
                }
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
            object rowData = gwSozlesmeBilgi.GetRow(e.FocusedRowHandle);
            object exRowData = gwSozlesmeBilgi.GetRow(e.PrevFocusedRowHandle);

            if (rowData is AV001_TDI_BIL_SOZLESME && exRowData is AV001_TDI_BIL_SOZLESME)
            {
                if (FocusedRowChanged != null)
                {
                    FocusedRowChanged((AV001_TDI_BIL_SOZLESME)rowData, (AV001_TDI_BIL_SOZLESME)exRowData,
                                      e.FocusedRowHandle, this);
                }
            }
        }
    }
}