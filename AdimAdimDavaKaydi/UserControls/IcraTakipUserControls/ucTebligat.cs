using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using ImportExportWithSelection.Import;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    /// <summary>
    /// TODO: Bu form üzerinde yapýlan iþlemler kaydet olayýnda etkilenmeyecektir.
    /// </summary>
    public partial class ucTebligat : AvpXUserControl
    {
        public bool muzekkre, ihbarname;

        private bool _IhbarnamePanel;

        private TList<AV001_TDI_BIL_TEBLIGAT> _MyDataSource = new TList<AV001_TDI_BIL_TEBLIGAT>();

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private bool initsFilled;

        private TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> muhataplar;

        private AV001_TD_BIL_FOY myFoy;

        private AV001_TD_BIL_HAZIRLIK myHazirlikFoy;

        private AV001_TI_BIL_FOY myIcraFoy;

        private AV001_TDI_BIL_SOZLESME mySozlesmeFoy;

        private Tebligat.tebligatHelper tebHelper = new AdimAdimDavaKaydi.Tebligat.tebligatHelper();

        public ucTebligat()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucTebligat_Load;
        }

        public bool IhbarnamePanel
        {
            get { return _IhbarnamePanel; }
            set
            {
                _IhbarnamePanel = value;
                if (panelControl1 != null)
                    panelControl1.Visible = value;
            }
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_TEBLIGAT> MyDataSource
        {
            get { return _MyDataSource; }
            set { _MyDataSource = value; }
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    MyDataSource = value.AV001_TDI_BIL_TEBLIGATCollection;
                }
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MyHazirlikFoy
        {
            get { return myHazirlikFoy; }
            set
            {
                myHazirlikFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TDI_BIL_TEBLIGATCollection;
            }
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return myIcraFoy; }
            set
            {
                myIcraFoy = value;
                if (value != null)
                {
                    MyDataSource = value.AV001_TDI_BIL_TEBLIGATCollection;
                }
            }
        }

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesmeFoy
        {
            get { return mySozlesmeFoy; }
            set
            {
                mySozlesmeFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TDI_BIL_TEBLIGATCollection;
            }
        }

        public void BindData()
        {
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyFoy != null)
            {
                if (MyFoy.AV001_TDI_BIL_TEBLIGATCollection.Count == 0)
                {
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDI_BIL_TEBLIGAT>));
                }
                _MyDataSource = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByDAVA_FOY_ID(MyFoy.ID);
            }

            else if (MySozlesmeFoy != null)
            {
                if (MySozlesmeFoy.AV001_TDI_BIL_TEBLIGATCollection.Count == 0)
                {
                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(MySozlesmeFoy
                                                                           , false, DeepLoadType.IncludeChildren,
                                                                           typeof(TList<AV001_TDI_BIL_TEBLIGAT>));
                }
                _MyDataSource = MySozlesmeFoy.AV001_TDI_BIL_TEBLIGATCollection;
            }
            else if (MyHazirlikFoy != null)
            {
                if (MyHazirlikFoy.AV001_TDI_BIL_TEBLIGATCollection.Count == 0)
                {
                    DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyHazirlikFoy
                                                                          , false, DeepLoadType.IncludeChildren,
                                                                          typeof(TList<AV001_TDI_BIL_TEBLIGAT>));
                }
                _MyDataSource = MyHazirlikFoy.AV001_TDI_BIL_TEBLIGATCollection;
            }
            else if (MyIcraFoy != null)
            {
                if (MyIcraFoy.AV001_TDI_BIL_TEBLIGATCollection.Count == 0)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyIcraFoy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDI_BIL_TEBLIGAT>));

                    //foreach (AV001_TDI_BIL_TEBLIGAT tebligat in MyIcraFoy.AV001_TDI_BIL_TEBLIGATCollection)
                    //{
                    //    DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.DeepLoad(
                    //        tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection, false, DeepLoadType.IncludeChildren,
                    //        typeof(AV001_TDI_BIL_TEBLIGAT), typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>));
                    //}
                }
                if (muzekkre)
                {
                    TList<AV001_TDI_BIL_TEBLIGAT> Muzekere = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.Find("ALT_TUR_ID='94'");
                    Muzekere.Filter = "ICRA_FOY_ID = " + MyIcraFoy.ID;
                    _MyDataSource = Muzekere;
                }
                else if (ihbarname)
                {
                    TList<AV001_TDI_BIL_TEBLIGAT> Ihaberneme = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.HacizIhbarnameGetirIcraFoyID(MyIcraFoy.ID);
                    _MyDataSource = Ihaberneme;
                }
                else
                    _MyDataSource = MyIcraFoy.AV001_TDI_BIL_TEBLIGATCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource == null) return;
            MyDataSource.ListChanged += MyDataSource_ListChanged;
            MyDataSource.AddingNew += MyDataSource_AddingNew;
            if (MyFoy != null || MyIcraFoy != null || MySozlesmeFoy != null || MyHazirlikFoy != null && IsLoaded)
            {
                if (MyDataSource != null && IsLoaded)
                {
                    muhataplar = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
                    muhataplar.AddingNew += muhataplar_AddingNew;

                    foreach (AV001_TDI_BIL_TEBLIGAT tebligat in MyDataSource)
                    {
                        TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> gelenler =
                            DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.GetByTEBLIGAT_ID(tebligat.ID);
                        DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.DeepLoad(gelenler, false,
                                                                                       DeepLoadType.IncludeChildren,
                                                                                       typeof(AV001_TDI_BIL_TEBLIGAT));
                        muhataplar.AddRange(gelenler);
                    }
                    InitsDoldur();
                    BelgeUtil.Inits.perCariGetirRefresh(rLueCariID);
                    gridTebligat.DataSource = muhataplar;
                }
            }
        }

        private void btnIliskiEkle_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() == null) return;
            var selectedTebligat = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByID((gridView1.GetFocusedRow() as AV001_TDI_BIL_TEBLIGAT_MUHATAP).TEBLIGAT_ID.Value);
            Forms.frmTebligatIliskiEkle frm = new frmTebligatIliskiEkle();
            frm.Show(selectedTebligat);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //BelgeUtil.Inits.CariAltGetir(lueCariAlt);//Load'ta kapatýldýðýndan bu satýr da kapatýldý. MB
            BindData();
        }

        private void gridTebligat_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                Forms.LayForm.frmLayTabligatKayit frmLay = new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit();

                frmLay.FormClosed += frm_FormClosed;

                if (MyIcraFoy != null)
                    frmLay.Show(MyIcraFoy);
                else if (MyFoy != null)
                    frmLay.Show(MyFoy);
                else if (MyHazirlikFoy != null)
                    frmLay.Show(MyHazirlikFoy);
                else if (MySozlesmeFoy != null)
                    frmLay.Show(MySozlesmeFoy);
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                rFrmTebligat frm = new rFrmTebligat();

                if (gridView1.GetFocusedRow() == null) return;

                AV001_TDI_BIL_TEBLIGAT seciliTebligat =
                    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByID(
                        (gridView1.GetFocusedRow() as AV001_TDI_BIL_TEBLIGAT_MUHATAP).TEBLIGAT_ID.Value);

                if (seciliTebligat == null) return;

                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(seciliTebligat, false,
                                                                       DeepLoadType.IncludeChildren,
                                                                       typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>),
                                                                       typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>));
                if (MyIcraFoy != null)
                {
                    frm.MyFoy = this.MyIcraFoy;
                    frm.MyTebligatMuhatap = gridView1.GetFocusedRow() as AV001_TDI_BIL_TEBLIGAT_MUHATAP;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Show(seciliTebligat);
                }
                else if (MyFoy != null)
                {
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Show(seciliTebligat);
                }
                else if (MyHazirlikFoy != null)
                {
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Show(seciliTebligat);
                }
                else if (MySozlesmeFoy != null)
                {
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Show(seciliTebligat);
                }
                frm.FormClosed += frm_FormClosed;
            }
        }

        private void gridTebligat_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "frmCariAlt")
            {
                frmUcuncuSahisBilgileri ucuncuSahisBilgileri = new frmUcuncuSahisBilgileri();
                ucuncuSahisBilgileri.Show(MyDataSource, MyIcraFoy);
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "colPostalanmaT")
            {
                if (e.RowHandle > 0 && gridView1.GetFocusedRow() != null)
                    e.DisplayText = MyDataSource.Find(vi => vi.ID == (gridView1.GetFocusedRow() as AV001_TDI_BIL_TEBLIGAT_MUHATAP).TEBLIGAT_ID).POSTALANMA_TARIH.ToString();
            }
        }

        private void InitsDoldur()
        {
            if (!initsFilled && MyDataSource != null && MyDataSource.Count > 0)
            {
                //BelgeUtil.Inits.TebligatAnaTurGetir(rLueAnaTurID);
                //BelgeUtil.Inits.TebligatAltTurGetir(rLueAltTurID);
                BelgeUtil.Inits.perCariGetir(rLueCariID);

                //BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeID);
                //BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorevID);
                //BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNoID);
                //BelgeUtil.Inits.MuhasebeHareketAltKategori(rLueMuhasebeAltKategori);
                //BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
                //BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
                BelgeUtil.Inits.TebligatKonuGetir(rLueTebligatKonu);

                //BelgeUtil.Inits.BelgeOzelKodGetir(rLueBelgeOzelKodID);
                //BelgeUtil.Inits.FoyOzelKodGetir(rLueFoyOzelKodID);
                //BelgeUtil.Inits.CariOzelKodGetir(rLueCariOzelKodID);
                //BelgeUtil.Inits.TebligatAlanBaglantiGetir(rLueTebligatAlanBaglanti);
                //BelgeUtil.Inits.TebligatAlimSekli(rLueAlimSekli);
                //BelgeUtil.Inits.TebligatAlinmamaNedenGetir(rLueAlinmamaNeden);
                //BelgeUtil.Inits.TebligatTeslimYerGetir(rLueTeslimYer);
                //BelgeUtil.Inits.TebligatSekliGetir(rLueTebligatSekli);
                //BelgeUtil.Inits.TarafKoduEnumGetir(rLueTarafKodu);
                //BelgeUtil.Inits.TebligatKonuGetir(rLueTebligatKonu);
                //BelgeUtil.Inits.TebligatHedefTipGetir(rLueTebligatHedefTip);
                //BelgeUtil.Inits.CariAltGetir(lueCariAlt);
                BelgeUtil.Inits.TebligatSonucGetir(rlueTebligatSonuc);

                initsFilled = true;
            }
        }

        private void muhataplar_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT_MUHATAP tebMuhatap = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
            tebMuhatap.TEBLIGAT_IDSource = new AV001_TDI_BIL_TEBLIGAT();
            e.NewObject = tebMuhatap;
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            InitsDoldur();
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            InitsDoldur();
        }

        private void sBtn892Hazirla_Click(object sender, EventArgs e)
        {
            //89/2 Haciz Ýhbarnamesi Oluþtur

            //TODO: form açýlcak , açýlan formda 89/1 tebligatlar ve Muhatabýn üzerinde Kesinleþme Tarihi bugün ve  bugünden küçük olanlar .

            //Forms.frm891IhbarnameSec892Yap Ihbarname891Yap = new frm891IhbarnameSec892Yap();
            //Ihbarname891Yap.Show(MyIcraFoy);

            IcraTakipForms.frmHacizIhbarnameleri frm = new frmHacizIhbarnameleri();
            var tebligatList = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByICRA_FOY_ID(MyIcraFoy.ID).FindAll(vi => vi.KONU_ID == 162);
            frm.FormClosed += frm_FormClosed;
            frm.Show(MyIcraFoy, tebligatList, AvukatProLib.Extras.IhbarnameTip.IkinciHacizIhbarnamesi);
        }

        private void sBtn893Hazirla_Click(object sender, EventArgs e)
        {
            //89/3 Haciz Ýhbarnamesi Oluþtur
            //TODO: form açýlcak , açýlan formda 89/2 tebligatlar ve Muhatabýn üzerinde Kesinleþme Tarihi bugün ve  bugünden küçük olanlar .

            //Forms.frm892IhbarnameSec893Yap Ihbarname892Yap = new frm892IhbarnameSec893Yap();
            //Ihbarname892Yap.Show(MyIcraFoy);
            //Ihbarname892Yap.FormClosed += frm_FormClosed;

            IcraTakipForms.frmHacizIhbarnameleri frm = new frmHacizIhbarnameleri();
            var tebligatList = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByICRA_FOY_ID(MyIcraFoy.ID).FindAll(vi => vi.KONU_ID == 163);
            frm.FormClosed += frm_FormClosed;
            frm.Show(MyIcraFoy, tebligatList, AvukatProLib.Extras.IhbarnameTip.UcuncuHacizIhbarnamesi);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmUcuncuSahisBilgileri ucuncuSahisBilgileri = new frmUcuncuSahisBilgileri();
            ucuncuSahisBilgileri.Show(MyDataSource, MyIcraFoy);
            ucuncuSahisBilgileri.FormClosed += frm_FormClosed;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //Forms.frmBorcluOlustur893lerden borcluOlustur = new frmBorcluOlustur893lerden();
            //borcluOlustur.Show();

            IcraTakipForms.frmHacizIhbarnameleri frm = new frmHacizIhbarnameleri();
            var tebligatList = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByICRA_FOY_ID(MyIcraFoy.ID).FindAll(vi => vi.KONU_ID == 450);
            frm.FormClosed += frm_FormClosed;
            frm.Show(MyIcraFoy, tebligatList, AvukatProLib.Extras.IhbarnameTip.BorcluYap);
        }

        private void ucTebligat_Load(object sender, EventArgs e)
        {
            //LOAD
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;
            panelControl1.Visible = _IhbarnamePanel;
            gridTebligat.ShowOnlyPredefinedDetails = true;

            InitsDoldur();

            BindData();

            colIliskiEkle.Visible = !ihbarname;

            //Vertical grid in ButonCevirOlayý yok..
        }
    }
}