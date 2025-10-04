using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucGorusmeler : AvpXUserControl
    {
        private TList<AV001_TDI_BIL_GORUSME> _MyDataSource;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private bool initsFilled;

        private AV001_TI_BIL_FOY myIcraFoy;

        public ucGorusmeler()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucGorusmeler_Load;
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_GORUSME> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy { get; set; }

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return myIcraFoy; }
            set
            {
                myIcraFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TDI_BIL_GORUSMECollection_From_NN_GORUSME_ICRA;
            }
        }

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesme { get; set; }

        public void BindData()
        {
            if (MyDataSource == null) return;
            MyDataSource.ListChanged += MyDataSource_ListChanged;
            MyDataSource.AddingNew += MyDataSource_AddingNew;
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

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource.Count == 0)
            {
                if (MyIcraFoy != null)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyIcraFoy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDI_BIL_GORUSME>));
                    _MyDataSource = MyIcraFoy.AV001_TDI_BIL_GORUSMECollection_From_NN_GORUSME_ICRA;
                }
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && IsLoaded)
            {
                LoadInitsData(false);
                grdGorusmeler.DataSource = MyDataSource;
                extendedGridControl1.DataSource = MyDataSource;
            }
        }

        private void gorusme_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DataRepository.AV001_TDI_BIL_GORUSMEProvider.Save(MyDataSource);
            //if (MyIcraFoy != null)
            //{
            //    foreach (var item in MyDataSource)
            //    {
            //        if (DataRepository.NN_GORUSME_ICRAProvider.GetByGORUSME_IDICRA_FOY_ID(item.ID, MyIcraFoy.ID) == null)
            //        {
            //            NN_GORUSME_ICRA nnIcra = new NN_GORUSME_ICRA();
            //            nnIcra.ICRA_FOY_ID = MyIcraFoy.ID;
            //            nnIcra.GORUSME_ID = item.ID;
            //            DataRepository.NN_GORUSME_ICRAProvider.Save(nnIcra);
            //        }
            //    }

            //    //nnIcra.GORUSME_ID=
            //}
            TList<AV001_TDI_BIL_GORUSME> gorusmeList = new TList<AV001_TDI_BIL_GORUSME>();
            if (MyIcraFoy != null)
                gorusmeList =
                    DataRepository.AV001_TDI_BIL_GORUSMEProvider.GetByICRA_FOY_IDFromNN_GORUSME_ICRA(MyIcraFoy.ID);
            else if (MySozlesme != null)
                gorusmeList =
                    DataRepository.AV001_TDI_BIL_GORUSMEProvider.GetBySOZLESME_IDFromNN_GORUSME_SOZLESME(MySozlesme.ID);
            grdGorusmeler.DataSource = gorusmeList;
        }

        private void grdGorusmeler_ButtonCevirClick(object sender,
                                                    DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (grdGorusmeler.Visible)
            {
                extendedGridControl1.Visible = true;
                grdGorusmeler.Visible = false;
            }
            else
            {
                extendedGridControl1.Visible = false;
                grdGorusmeler.Visible = true;
            }
        }

        private void grdGorusmeler_EmbeddedNavigator_ButtonClick(object sender,
                                                                 DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            else if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                //UNDONE: From açýlýrken hata veriyor.
                rFrmGorusmeKayit gorusme = new rFrmGorusmeKayit();
                //.MdiParent = null;
                gorusme.StartPosition = FormStartPosition.WindowsDefaultLocation;
                LoadInitsData(true);
                if (MySozlesme != null)
                {
                    gorusme.Show(MySozlesme);
                }
                if (MyIcraFoy != null)
                {
                    gorusme.Show(MyIcraFoy);
                }
                gorusme.FormClosed += gorusme_FormClosed;
            }
            else if (e.Button.Tag.ToString() == "Duzenle" && gwGorusmeler.GetFocusedRow() != null)
            {
                #region <AC - 20090614>

                //Sað tuþ menü kaydý düzenle
                //UNDONE: Kayýt ekleme fromu açýlýrken hata verdiði için test yapýlamadý.
                rFrmGorusmeKayit gorusme = new rFrmGorusmeKayit();
                if (MySozlesme != null)
                {
                    TList<AV001_TDI_BIL_GORUSME> gorusmeList = new TList<AV001_TDI_BIL_GORUSME>();
                    gorusmeList.Add(gwGorusmeler.GetFocusedRow() as AV001_TDI_BIL_GORUSME);
                    gorusme.AddNewList = gorusmeList;
                    gorusme.Show(MySozlesme);
                }
                if (MyIcraFoy != null)
                {
                    TList<AV001_TDI_BIL_GORUSME> gorusmeList = new TList<AV001_TDI_BIL_GORUSME>();
                    gorusmeList.Add(gwGorusmeler.GetFocusedRow() as AV001_TDI_BIL_GORUSME);
                    gorusme.AddNewList = gorusmeList;
                    gorusme.Show(MyIcraFoy);
                }

                #endregion <AC - 20090614>

                gorusme.FormClosed += gorusme_FormClosed;
            }
            else if (e.Button.Tag.ToString() == "Sil" && gwGorusmeler.GetFocusedRow() != null)
            {
                //UNDONE: "grdGorusmeler" silme iþlemi yapýlacak.
            }
        }

        private void LoadInitsData(bool newItem)
        {
            if (!this.DesignMode)
            {
                if ((!initsFilled && MyDataSource.Count > 0) || newItem)
                {
                    BelgeUtil.Inits.perCariGetir(rLueCariID);
                    BelgeUtil.Inits.CariPersonelGetir(rlueGorusenCari);
                    BelgeUtil.Inits.MuhasebeHareketAltKategoriForGorusme(rLueIsKategoriID);

                    initsFilled = true;
                }
            }
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            LoadInitsData(false);
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            LoadInitsData(false);
        }

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                #region <AC - 20090906>

                //Sað tuþ menü (Yeni Kayýt Ekle, Kaydý Düzenle, Kaydý Sil)
                grdGorusmeler_EmbeddedNavigator_ButtonClick(sender,
                                                            new NavigatorButtonClickEventArgs(
                                                                e.Item.Tag as NavigatorCustomButton));

                #endregion <AC - 20090906>

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

                                // belgeKayit.MdiParent = null;
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
                            // frmisKayit.MdiParent = null;
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
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kiþinin");

                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve Ýletiþim Bilgileri");

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
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kiþinin");

                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve Ýletiþim Bilgileri");

                //barBtnSecimiKaldir.Tag = e.Column;

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
        }

        private void ucGorusmeler_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            grdGorusmeler.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
            grdGorusmeler.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            IsLoaded = true;
            try
            {
                grdGorusmeler.ButtonCevirClick += grdGorusmeler_ButtonCevirClick;
                extendedGridControl1.ButtonCevirClick += grdGorusmeler_ButtonCevirClick;

                //LoadInitsData();
                grdGorusmeler.ShowOnlyPredefinedDetails = true;
                SagTusaEkle();
                BindData();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }
    }
}