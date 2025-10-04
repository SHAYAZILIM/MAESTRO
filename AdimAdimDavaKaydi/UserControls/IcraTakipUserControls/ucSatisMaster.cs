using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.DavaTakip;
using AdimAdimDavaKaydi.Forms.Icra;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AdimAdimDavaKaydi.Sozlesme.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucSatisMaster : AvpXUserControl
    {
        private TList<AV001_TI_BIL_SATIS_MASTER> _MyDataSource;

        private AV001_TI_BIL_FOY _myFoy;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private AvukatProLib.Arama.AvpDataContext db =
            new AvukatProLib.Arama.AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        private bool initsFilled;

        public ucSatisMaster()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucSatisMaster_Load;
        }

        public event DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler ucSatisChildValidateRow;

        public event DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler ucSatisMasterValidateRow;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_SATIS_MASTER> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;

                if (MyDataSource != null)
                {
                    if (MyDataSource != null && MyDataSource.Count > 0)
                        IcraKayitGetir(value);

                    if (IsLoaded)
                        BindData();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return _myFoy; }
            set
            {
                _myFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TI_BIL_SATIS_MASTERCollection;
            }
        }

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

        private void barBtnSecimiKaldir_ItemClick(object sender, ItemClickEventArgs e)
        {
            R_BIRLESIK_TAKIPLER_SATIS tum = e.Item.Tag as R_BIRLESIK_TAKIPLER_SATIS;
            if (tum.Dosya_No.Contains("I") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Icra)
            {
                TList<AV001_TI_BIL_FOY> foyList = new TList<AV001_TI_BIL_FOY>();
                foyList.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(tum.KAYIT_ID.Value));
                _frmIcraTakip IcraTk = new _frmIcraTakip();

                //IcraTk.MdiParent = null;
                IcraTk.StartPosition = FormStartPosition.WindowsDefaultLocation;
                IcraTk.Show(foyList);
            }
            if (tum.Dosya_No.Contains("D") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Dava)
            {
                TList<AV001_TD_BIL_FOY> foyList = new TList<AV001_TD_BIL_FOY>();
                foyList.Add(DataRepository.AV001_TD_BIL_FOYProvider.GetByID(tum.KAYIT_ID.Value));
                frmDavaTakip frm = new frmDavaTakip();

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foyList);
            }
            if (tum.Dosya_No.Contains("S") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Sozlesme)
            {
                TList<AV001_TDI_BIL_SOZLESME> foyList = new TList<AV001_TDI_BIL_SOZLESME>();
                foyList.Add(DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(tum.KAYIT_ID.Value));
                frmSozlesmeTakip frm = new frmSozlesmeTakip();

                // frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foyList);
            }
            if (tum.Dosya_No.Contains("H") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Sorusturma)
            {
                TList<AV001_TD_BIL_HAZIRLIK> foyList = new TList<AV001_TD_BIL_HAZIRLIK>();
                foyList.Add(DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(tum.KAYIT_ID.Value));
                rFrmSorusturmaTakip frm = new rFrmSorusturmaTakip();
                // frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foyList);
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource.Count == 0)
            {
                if (MyFoy != null)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_SATIS_MASTER>));

                    foreach (var item in MyFoy.AV001_TI_BIL_SATIS_MASTERCollection)
                    {
                        DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.DeepLoad(item, false,
                                                                                  DeepLoadType.IncludeChildren,
                                                                                  typeof(
                                                                                      TList<AV001_TI_BIL_SATIS_CHILD>));
                    }
                    MyDataSource = MyFoy.AV001_TI_BIL_SATIS_MASTERCollection;
                }
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && IsLoaded)
            {
                InitsDoldur(false);

                //bndSatis.DataSource = MyDataSource;
                gcSatisMaster.DataSource = MyDataSource;
            }
        }

        private void btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((e.Item.Tag as AV001_TI_BIL_HACIZ_CHILD) != null)
            {
                frmMalTakipSureci malTakip = new frmMalTakipSureci();
                var liste = new TList<AV001_TI_BIL_HACIZ_CHILD>();
                var child = e.Item.Tag as AV001_TI_BIL_HACIZ_CHILD;
                liste.Add(child);
                malTakip.MyDataSource = liste;
                malTakip.MyFoy = MyFoy;

                //malTakip.HacizMasterSelectedRow = Row;
                //malTakip.MdiParent = null;
                malTakip.StartPosition = FormStartPosition.WindowsDefaultLocation;
                malTakip.Show();
            }

            else
                XtraMessageBox.Show("Hacizli mal bulunamadý.");
        }

        private void frm_satisYenile(object sender, EventArgs e)
        {
            if (MyDataSource.Count == 0)
                BindData();
        }

        private void gcSatisMaster_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag.ToString() == "frmSatisGirisi")
            {
                frmSatisGirisi frm = new frmSatisGirisi();
                InitsDoldur(true);

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.MyGelisme = ucIcraTarafGelismeleri.GelismeBul(MyFoy);
                if (MyFoy == null)
                {
                    frm.IsModul = true;
                    frm.Show();
                }
                frm.satisYenile += frm_satisYenile;
                frm.MyFoy = MyFoy;
                frm.Show(MyFoy);
            }
            else if (e.Button.Tag.ToString() == "Duzenle")
            {
                frmSatisGirisi frm = new frmSatisGirisi();

                //.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.AddNewList = new TList<AV001_TI_BIL_SATIS_MASTER>();
                frm.AddNewList.Add(MyDataSource[gwSatisMaster.FocusedRowHandle]);
                if (MyFoy == null && MyDataSource[gwSatisMaster.FocusedRowHandle].ICRA_FOY_ID != null)
                    MyFoy =
                        DataRepository.AV001_TI_BIL_FOYProvider.GetByID(
                            MyDataSource[gwSatisMaster.FocusedRowHandle].ICRA_FOY_ID);

                frm.MyFoy = MyFoy;
                frm.Show();
            }
        }

        private void gwSatisChild_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (ucSatisChildValidateRow != null)
                ucSatisChildValidateRow(sender, e);
        }

        private void gwSatisMaster_DoubleClick(object sender, EventArgs e)
        {
            navBarGroup1.Expanded = true;
            TList<AV001_TI_BIL_SATIS_MASTER> master = gwSatisMaster.DataSource as TList<AV001_TI_BIL_SATIS_MASTER>;
            AV001_TI_BIL_SATIS_MASTER SatisSelectedRow = master[gwSatisMaster.FocusedRowHandle];

            this.ucBelgeIzlemeDolasimDock1.MyDataSource = BelgeUtil.Inits.BelgeGetirBySatisId(SatisSelectedRow.ID);
        }

        private void gwSatisMaster_MasterRowExpanding(object sender,
                                                      DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs e)
        {
            AV001_TI_BIL_SATIS_MASTER gelen = (AV001_TI_BIL_SATIS_MASTER)gwSatisMaster.GetRow(e.RowHandle);
            if (gelen.R_BIRLESIK_TAKIPLER_SATISCollection != null) return;

            gelen.R_BIRLESIK_TAKIPLER_SATISCollection =
                DataRepository.R_BIRLESIK_TAKIPLER_SATISProvider.Get(string.Format("ID={0}", gelen.ID),
                                                                     "KAYIT_TARIHI ASC");
        }

        private void gwSatisMaster_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (ucSatisMasterValidateRow != null)
                ucSatisMasterValidateRow(sender, e);
        }

        private void IcraKayitGetir(TList<AV001_TI_BIL_SATIS_MASTER> value)
        {
            foreach (var item in value)
            {
                AV001_TI_BIL_FOY foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(item.ICRA_FOY_ID);
                item.ICRA_FOY_IDSource = foy;
            }
        }

        private void InitsDoldur(bool newItem)
        {
            if ((!initsFilled && MyDataSource.Count > 0) || newItem)
            {
                BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
                BelgeUtil.Inits.perCariGetir(rLueCari);
                BelgeUtil.Inits.perCariGetir(rLueBorcluTaraf);
                BelgeUtil.Inits.perCariGetir(rLueAlacakliTaraf);
                BelgeUtil.Inits.SatisIlanSekliGetir(rLueIlanSekli);
                BelgeUtil.Inits.SatisIstemeSekliGetir(rLueSatisIstenmeSekli);
                BelgeUtil.Inits.SatisTuruGetir(rLueSatisTuru);
                BelgeUtil.Inits.IcraItirazSonucGetir(rLueItirazSonucu);
                BelgeUtil.Inits.ParaBicimiAyarla(Toplam);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
                BelgeUtil.Inits.MalTurGetir(rLueHacizliMalTur);
                BelgeUtil.Inits.MalKategoriGetir(rlueHacizliMalKategori);
                BelgeUtil.Inits.MalcinsGetir(rlueHacizliMalCins);
                BelgeUtil.Inits.ParaBicimiAyarla(HacizliMalDegeri);
                BelgeUtil.Inits.DovizTipGetir(rLueHacizliMalDegeriDoviz);
                BelgeUtil.Inits.BankaSubeGetir(rLueBSube);
                BelgeUtil.Inits.BankaGetir(rLueBanka);
                //BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKod);
                BelgeUtil.Inits.FoyDurumGetir(rLueFoyDurum);
                BelgeUtil.Inits.TarafKoduGetir(rLueTarafKodu);
                BelgeUtil.Inits.FoyBirimGetir(rLueFoyBirim);
                BelgeUtil.Inits.FoyYeriGetir(rLueFoyYeri);
                BelgeUtil.Inits.FoyOzelDurumGetir(rLueFoyOzelDurum);
                BelgeUtil.Inits.TahsilatdurumGetir(rLueTahsilatDurum);
                BelgeUtil.Inits.KrediGrubu(rLueKrediGrup);
                BelgeUtil.Inits.KrediTipiGetir(rLueKrediTip);
                BelgeUtil.Inits.ModulGetir(rLueModul);

                if (MyFoy != null)
                    BelgeUtil.Inits.HacizChildGetir(MyFoy, rlueMalCinsID);

                BelgeUtil.Inits.MalcinsGetir(rlueHacizliMalCinsID);
                BelgeUtil.Inits.DovizTipGetir(rlueDovizID);
                BelgeUtil.Inits.BirimKodGetir(rlueMalAdetBirimKod);
                BelgeUtil.Inits.ParaBicimiAyarla(spinToplam);

                initsFilled = true;
            }
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            InitsDoldur(false);
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            InitsDoldur(false);
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "Dosya_No" || e.Column.FieldName == "Adliye"
                || e.Column.FieldName == "No" || e.Column.FieldName == "Esas_No" || e.Column.FieldName == "Takip_T" ||
                e.Column.FieldName == "Gorev" || e.Column.FieldName == "Referans1")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kaydý");
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Takip Ekranýna Gönder");

                R_BIRLESIK_TAKIPLER_SATIS secim = e.Rows as R_BIRLESIK_TAKIPLER_SATIS;

                bus.ItemLinks.Add(barBtnSecimiKaldir);
                if (secim != null)
                {
                    barBtnSecimiKaldir.Tag = secim;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(0, bus);
            }

            #region Mal Takip Süreci

            if (e.Rows is AV001_TI_BIL_SATIS_CHILD)
            {
                var btn = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Mal Takip Süreci");
                DataRepository.AV001_TI_BIL_SATIS_CHILDProvider.DeepLoad(e.Rows as AV001_TI_BIL_SATIS_CHILD, false,
                                                                         DeepLoadType.IncludeChildren,
                                                                         typeof(AV001_TI_BIL_HACIZ_CHILD));
                btn.Tag = (e.Rows as AV001_TI_BIL_SATIS_CHILD).HACIZ_CHILD_IDSource;
                btn.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.dnext_16x16_zoom;
                e.MyPopupMenu.ItemLinks.Insert(0, btn);
                btn.ItemClick += btn_ItemClick;
            }

            #endregion Mal Takip Süreci
        }

        private void ucSatisMaster_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();

            IsLoaded = true;
            gcSatisChild.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
            gcSatisMaster.ButtonClick += gcSatisMaster_ButtonClick;

            //InitsDoldur();

            gcSatisMaster.ShowOnlyPredefinedDetails = true;

            navBarGroup1.Expanded = false;
            BindData();
        }

        #region <MB-20100528>

        //Satýþ Master gridinde,týklanan master satýrýnýn child bilgilerinin alttaki gride getirilmesi için eklendi.

        private void gcSatisChild_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            else if (e.Button.Tag.ToString() == "FormAc")
            {
                frmSatisGirisi frm = new frmSatisGirisi();
                InitsDoldur(true);

                // frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.MyGelisme = ucIcraTarafGelismeleri.GelismeBul(MyFoy);
                if (MyFoy == null)
                {
                    frm.IsModul = true;
                    frm.Show();
                }
                frm.satisYenile += frm_satisYenile;
                frm.MyFoy = MyFoy;
                frm.Show(MyFoy);
            }

            else if (e.Button.Tag.ToString() == "KaydiDuzenle")
            {
                frmSatisGirisi frm = new frmSatisGirisi();

                //.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;

                //Düzenleme modunda ilgili child bilgisinin ekrana gelmesini saðlamak için eklendi.
                frm.ChildList.Add((gvSatisChild.GetFocusedRow() as AV001_TI_BIL_SATIS_CHILD));

                //
                frm.AddNewList = new TList<AV001_TI_BIL_SATIS_MASTER>();
                frm.AddNewList.Add(MyDataSource[gwSatisMaster.FocusedRowHandle]);
                if (MyFoy == null && MyDataSource[gwSatisMaster.FocusedRowHandle].ICRA_FOY_ID != null)
                    MyFoy =
                        DataRepository.AV001_TI_BIL_FOYProvider.GetByID(
                            MyDataSource[gwSatisMaster.FocusedRowHandle].ICRA_FOY_ID);

                frm.MyFoy = MyFoy;
                frm.Show();
            }
        }

        private void gwSatisMaster_FocusedRowChanged(object sender,
                                                     DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;

            if ((gcSatisMaster.DataSource as TList<AV001_TI_BIL_SATIS_MASTER>).Count > 0)
            {
                AV001_TI_BIL_SATIS_MASTER satisMaster =
                    (gcSatisMaster.DataSource as TList<AV001_TI_BIL_SATIS_MASTER>)[e.FocusedRowHandle];

                TList<AV001_TI_BIL_SATIS_CHILD> satisChildList = new TList<AV001_TI_BIL_SATIS_CHILD>();
                if (satisMaster != null)
                {
                    satisChildList = DataRepository.AV001_TI_BIL_SATIS_CHILDProvider.GetByMASTER_ID(satisMaster.ID);
                    gcSatisChild.DataSource = satisChildList;
                }
            }
        }

        #endregion <MB-20100528>
    }
}