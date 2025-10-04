using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatPro.Services.Implementations;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Data;

namespace AdimAdimDavaKaydi.UserControls.AramaUserKontrol
{
    public partial class ucGorusmeArama : AvpXUserControl
    {
        private BackgroundWorker bckWorker = new BackgroundWorker();

        public ucGorusmeArama()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public DataTable MyDataSource { get; set; }
        
        public void BindData()
        {
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        public void SagTusaEkle()
        {
            grdGorusmeler.RightClickPopup.LinkPersist = new DevExpress.XtraBars.LinksInfo();
            foreach (DevExpress.XtraBars.LinkPersistInfo var in popupMenu1.LinksPersistInfo)
            {
                grdGorusmeler.RightClickPopup.LinkPersist.Add(var);
            }
        }

        private static void FormlariTemizle(Control.ControlCollection coll)
        {
            try
            {
                foreach (Control con in coll)
                {
                    if (con is LookUpEdit)
                    {
                        (con as LookUpEdit).EditValue = null;
                    }
                    else if (con is DateEdit)
                    {
                        (con).ResetText();
                    }

                    else if (con is SpinEdit)
                    {
                        ((SpinEdit)con).EditValue = null;
                    }
                    else if (con is CheckEdit)
                    {
                        ((CheckEdit)con).Checked = false;
                    }
                    else if (con is TextEdit)
                    {
                        con.Text = string.Empty;
                    }
                }
            }
            catch 
            {
            }
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

                // cariForms.MdiParent = null;
                cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cariForms.Show();
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            AvukatPro.Services.Messaging.GetGorusmeByFiltreRequest request = new AvukatPro.Services.Messaging.GetGorusmeByFiltreRequest();
            request.Modul = Modul;
            request.DosyaID = DosyaID;
            request.GorusenKisi = GorusenKisi;
            request.GorusulenKisi = GorusulenKisi;
            request.IsinYapildigiKisi = IsinYapildigiKisi;
            request.IsKategoriID = IsKategoriID;
            request.GorusmeTarihi = GorusmeTarihi;
            request.YenidenGorusmeTarihi = YenidenGorusmeTarihi;

            e.Result = AvukatPro.Services.Implementations.DosyaService.GetAllGorusmeByFiltre(request, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString());
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                MyDataSource = (DataTable)e.Result;
                grdGorusmeler.DataSource = MyDataSource;
            }
        }

        private void btnArama_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(navBarGroupControlContainer1.Controls);
            rgZamanDilimi.SelectedIndex = 6;
            grdGorusmeler.DataSource = null;
        }

        private void grdGorusmeler_EmbeddedNavigator_ButtonClick(object sender,
                                                                 DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            else if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                Forms.rFrmGorusmeKayit gorusme = new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();
                gorusme.StartPosition = FormStartPosition.WindowsDefaultLocation;
                gorusme.IsModul = true;
                gorusme.Show();
            }
            else if (e.Button.Tag.ToString() == "Duzenle" && gwGorusmeler.GetFocusedRow() != null)
            {
                MessageBox.Show("düzenle");
            }
        }

        private void LoadInitsData()
        {
            //Tıklayınca gelecekler için
            lueGorusen.Properties.NullText = "Seç";
            lueModul.Properties.NullText = "Seç";
            lueGorusulen.Properties.NullText = "Seç";
            lueIsinYapildigi.Properties.NullText = "Seç";

            //dolu gelecekler için
            rLueKontrolKim.NullText = "Seç";
            rLueBuro.NullText = "Seç";
            rLueGorusumeYonu.NullText = "Seç";
            BelgeUtil.Inits.KontrolKimGetir(rLueKontrolKim);
            BelgeUtil.Inits.SubeKodGetir(rLueBuro);
            //lueModul.Enter += delegate { BelgeUtil.Inits.ModulGetir(lueModul.Properties); };
            //lueModul.Enter += delegate { DevExpressService.ModulDoldur(lueModul, null); };

            DevExpressService.ModulDoldur(lueModul, null);
            DevExpressService.CariDoldur(lueGorusen, null);
            DevExpressService.CariDoldur(lueGorusulen, null);
            lueIsinYapildigi.Enter += BelgeUtil.Inits.perCariGetir_Enter;

            #region Grid Lookups Bind

            BelgeUtil.Inits.GorusmeYonuGetir(rLueGorusumeYonu);
            AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(rlueSegment);
            BelgeUtil.Inits.perCariGetir(rlueCari);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueNo);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueGorev);
            BelgeUtil.Inits.MuhasebeHareketAltKategori(rlueIsKategori);

            #endregion Grid Lookups Bind
        }

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                #region <AC - 20090906>

                //Sağ tuş menü (Yeni Kayıt Ekle, Kaydı Düzenle, Kaydı Sil)
                grdGorusmeler_EmbeddedNavigator_ButtonClick(sender,
                                                            new NavigatorButtonClickEventArgs(
                                                                e.Item.Tag as NavigatorCustomButton));

                #endregion <AC - 20090906>

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

                    //.MdiParent = null;
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
                    if (e.Item.Tag is AV001_TDI_BIL_GORUSME)
                    {
                        AV001_TDI_BIL_GORUSME takip = e.Item.Tag as AV001_TDI_BIL_GORUSME;

                        string tablob = "AV001_TDI_BIL_GORUSME";
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
                    if (e.Item.Tag is AV001_TDI_BIL_GORUSME)
                    {
                        AV001_TDI_BIL_GORUSME takip = e.Item.Tag as AV001_TDI_BIL_GORUSME;
                        string tabloI = "AV001_TDI_BIL_GORUSME";
                        AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit =
                            new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();

                        frmisKayit.SetByTableNameAndId(tabloI, takip.ID);
                        try
                        {
                            //frmisKayit.MdiParent = null;
                            frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            frmisKayit.Show();
                        }
                        catch
                        {
                        }
                    }
                }

                else if (e.Item.Name == bButtonNotEkle.Name)
                {
                    //if (e.Item.Tag is AV001_TDI_BIL_GORUSME)
                    //{
                    //    AV001_TDI_BIL_GORUSME takip = e.Item.Tag as AV001_TDI_BIL_GORUSME;
                    //    bool islemYap = true;
                    //    if (takip.ID != null && islemYap)
                    //    {
                    //        string tabloB = "AV001_TDI_BIL_GORUSME";
                    //        AdimAdimDavaKaydi.CustomControls.frmYeniNot d = new AdimAdimDavaKaydi.CustomControls.frmYeniNot();
                    //        //d.MdiParent = null;
                    //        d.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    //        d.ShowDialog(tabloB, takip.ID);

                    //    }
                    //}
                }
            }
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "GORUSEN_CARI_ID")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kişinin");

                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve İletişim Bilgileri");

                //barBtnSecimiKaldir.Tag = e.Column;

                bus.ItemLinks.Add(barBtnSecimiKaldir);

                AV001_TDI_BIL_GORUSME secim = e.Rows as AV001_TDI_BIL_GORUSME;

                int? id = secim.GORUSEN_CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(0, bus);
            }
            else if (e.Column != null && e.Column.FieldName == "GORUSULEN_CARI_ID")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kişinin");
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve İletişim Bilgileri");
                bus.ItemLinks.Add(barBtnSecimiKaldir);
                AV001_TDI_BIL_GORUSME secim = e.Rows as AV001_TDI_BIL_GORUSME;
                int? id = secim.GORUSULEN_CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                e.MyPopupMenu.ItemLinks.Add(bus);
            }
            //DevExpress.XtraBars.BarButtonItem SendSms = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Düzenle");
            //Bitmap imageSMS = (Bitmap)AdimAdimDavaKaydi.Properties.Resources.acilis_edit_22;
            //imageSMS.MakeTransparent(Color.Fuchsia);
            //SendSms.Glyph = imageSMS;
            //SendSms.Tag = "Duzenle";
            //e.MyPopupMenu.AddItem(SendSms);
        }


        private void ucGorusmeler_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            LoadInitsData();
            grdGorusmeler.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
            grdGorusmeler.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            IsLoaded = true;
            try
            {
                grdGorusmeler.ShowOnlyPredefinedDetails = true;
                SagTusaEkle();

                //BindData();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        #region Arama Kriter

        private int? DosyaID;
        private int? GorusenKisi;
        private DateTime? GorusmeTarihi;
        private int? GorusulenKisi;
        private int? IsinYapildigiKisi;
        private int? IsKategoriID;
        private AvukatProLib.Extras.Modul? Modul;

        private DateTime? YenidenGorusmeTarihi;

        private void lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDosya.EditValue != null)
                DosyaID = (int?)lueDosya.EditValue;
            else
                DosyaID = null;
        }

        private void lueGorusen_EditValueChanged(object sender, EventArgs e)
        {
            if (lueGorusen.EditValue != null)
                GorusenKisi = (int?)lueGorusen.EditValue;
            else
                GorusenKisi = null;
        }

        private void lueGorusmeT_EditValueChanged(object sender, EventArgs e)
        {
            if (lueGorusmeT.EditValue != null)
                GorusmeTarihi = (DateTime?)lueGorusmeT.EditValue;
            else
                GorusmeTarihi = null;
        }

        private void lueGorusulen_EditValueChanged(object sender, EventArgs e)
        {
            if (lueGorusulen.EditValue != null)
                GorusulenKisi = (int?)lueGorusulen.EditValue;
            else
                GorusulenKisi = null;
        }

        private void lueIsinYapildigi_EditValueChanged(object sender, EventArgs e)
        {
            if (lueIsinYapildigi.EditValue != null)
                IsinYapildigiKisi = (int?)lueIsinYapildigi.EditValue;
            else
                IsinYapildigiKisi = null;
        }

        private void lueIsKategori_EditValueChanged(object sender, EventArgs e)
        {
            if (lueIsKategori.EditValue != null)
                IsKategoriID = (int?)lueIsKategori.EditValue;
            else
                IsKategoriID = null;
        }

        private void lueModul_EditValueChanged(object sender, EventArgs e)
        {
            if (lueModul.EditValue != null)
                Modul = (AvukatProLib.Extras.Modul?)Convert.ToInt32(lueModul.EditValue);
            else
                Modul = null;

            if (lueModul.Text == "Icra")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Icra, false);

            else if (lueModul.Text == "Dava")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Dava, false);

            else if (lueModul.Text == "Soruşturma")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sorusturma, false);

            else if (lueModul.Text == "Sözleşme")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sozlesme, false);
        }

        private void lueSonrakiAramaT_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSonrakiAramaT.EditValue != null)
                YenidenGorusmeTarihi = (DateTime?)lueSonrakiAramaT.EditValue;
            else
                YenidenGorusmeTarihi = null;
        }

        #endregion Arama Kriter

        private void grdGorusmeler_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            //örnek ekran burada aykut görüşme \Belge\UserControls\ucBelgeAramaView.cs

            if (e.Button.Tag == null) return;

            else if (e.Button.Tag.ToString() == "KaydiDuzenle")
            {
                Forms.rFrmGorusmeKayit gorusme = new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();
                gorusme.IsModul = true;
                AV001_TDI_BIL_GORUSME seciliGorusme = DataRepository.AV001_TDI_BIL_GORUSMEProvider.GetByID((int)gwGorusmeler.GetFocusedRowCellValue("ID"));
                TList<AV001_TDI_BIL_GORUSME> lis = new TList<AV001_TDI_BIL_GORUSME>();
                lis.Add(seciliGorusme);

                //gorusme.ucGorusmeKayit1.MyDataSource.Add(seciliGorusme);
                //gorusme.AddNewList.Add(seciliGorusme);

                if (gwGorusmeler.GetFocusedRowCellValue("Tipi").ToString() == "İcra" || gwGorusmeler.GetFocusedRowCellValue("Tipi").ToString() == "Tipi")
                {
                    AV001_TI_BIL_FOY foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)gwGorusmeler.GetFocusedRowCellValue("FOY_ID"));
                    gorusme.Show(foy);
                    gorusme.c_lueModul.EditValue = 1;
                    gorusme.c_lueDosya.EditValue = gwGorusmeler.GetFocusedRowCellValue("FOY_ID");
                    gorusme.ucGorusmeKayit1.MyDataSource = lis;
                }
                else if (gwGorusmeler.GetFocusedRowCellValue("Tipi").ToString() == "Dava")
                {
                    AV001_TD_BIL_FOY foy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)gwGorusmeler.GetFocusedRowCellValue("FOY_ID"));
                    gorusme.Show(foy);
                    gorusme.c_lueModul.EditValue = 2;
                    gorusme.c_lueDosya.EditValue = gwGorusmeler.GetFocusedRowCellValue("FOY_ID");
                    gorusme.ucGorusmeKayit1.MyDataSource = lis;
                }
                else if (gwGorusmeler.GetFocusedRowCellValue("Tipi").ToString() == "Soruşturma")
                {
                    AV001_TD_BIL_HAZIRLIK foy = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID((int)gwGorusmeler.GetFocusedRowCellValue("FOY_ID"));
                    gorusme.Show(foy);
                    gorusme.c_lueModul.EditValue = 3;
                    gorusme.c_lueDosya.EditValue = gwGorusmeler.GetFocusedRowCellValue("FOY_ID");
                    gorusme.ucGorusmeKayit1.MyDataSource = lis;
                }
                else if (gwGorusmeler.GetFocusedRowCellValue("Tipi").ToString() == "Sözleşme")
                {
                    AV001_TDI_BIL_SOZLESME foy = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID((int)gwGorusmeler.GetFocusedRowCellValue("FOY_ID"));
                    gorusme.Show(foy);
                    gorusme.c_lueModul.EditValue = 5;
                    gorusme.c_lueDosya.EditValue = gwGorusmeler.GetFocusedRowCellValue("FOY_ID");
                    gorusme.ucGorusmeKayit1.MyDataSource = lis;
                }
                else
                {
                    gorusme.IsModul = false;
                    gorusme.Show();
                    gorusme.ucGorusmeKayit1.MyDataSource = lis;
                }
            }
            else if (e.Button.Tag.ToString() == "Sil")
            {
                AV001_TDI_BIL_GORUSME seciliGorusme = DataRepository.AV001_TDI_BIL_GORUSMEProvider.GetByID((int)gwGorusmeler.GetFocusedRowCellValue("ID"));

                if (seciliGorusme != null)
                {
                    AdimAdimDavaKaydi.Util.frmKayitSil kayitSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TDI_BIL_GORUSME", "ID = " + seciliGorusme.ID);
                    if (kayitSil.ShowDialog() == DialogResult.OK)
                        gwGorusmeler.DeleteRow(gwGorusmeler.FocusedRowHandle);
                }
            }
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, System.EventArgs e)
        {
            
        }

        private void gwGorusmeler_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            //if (e.Column.FieldName == "SesKaydi")
            //{
            //    if (e.CellValue != null)
            //    {
            //        if (e.CellValue.ToString() == "Dinle")
            //        {
            //            ((DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit)e.Column.ColumnEdit).Image = AdimAdimDavaKaydi.Properties.Resources.sesVar;
            //            e.Column.OptionsColumn.AllowEdit = true;
            //        }
            //        else
            //        {
            //            ((DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit)e.Column.ColumnEdit).Image = AdimAdimDavaKaydi.Properties.Resources.sesYok;
            //            e.Column.OptionsColumn.AllowEdit = false;
            //        }
            //    }
            //}
        }
    }
}