using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucKiymetliEvrakGrid : AvpXUserControl
    {
        private TList<AV001_TDI_BIL_KIYMETLI_EVRAK> _MyDataSource;

        private bool initsFilled;

        public ucKiymetliEvrakGrid()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucKiymetliEvrakGrid_Load;
        }

        [Browsable(false)]
        public bool? AppenButtonEnabled { get; set; }

        [Browsable(false)]
        public AV001_TI_BIL_FOY Foy { get; set; }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_KIYMETLI_EVRAK> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        public AV001_TD_BIL_FOY MyDavaFoy { get; set; }

        public void BindData()
        {
            if (MyDataSource != null && !this.DesignMode)
            {
                MyDataSource.ListChanged += MyDataSource_ListChanged;
                MyDataSource.AddingNew += MyDataSource_AddingNew;
                LoadInitsData();
                bndKiymetliEvrak.DataSource = MyDataSource;
                dataNavigatorExtended1.DataSource = MyDataSource;
                vGridKiymetliEvrak.DataSource = bndKiymetliEvrak;
            }
        }

        private void dataNavigatorExtended1_OnListedenGetirClick(object sender, AdimAdimDavaKaydi.Util.ListedenGetirEventArgs e)
        {
            if (MyDavaFoy != null)
            {
                if (MyDataSource != null)
                {
                    frmEkleKiymetliEvrak frm = new frmEkleKiymetliEvrak();

                    //if (MyDavaFoy.AV001_TD_BIL_FOY_TARAFCollection.Count == 0)
                    //    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyDavaFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_TARAF>));
                    //var tarafIDList = MyDavaFoy.AV001_TD_BIL_FOY_TARAFCollection.FindAll(vi => !vi.DAVA_EDEN_MI).Select(vi => vi.CARI_ID.Value).ToList();
                    //frm.TarafIDList = tarafIDList;

                    //frm.Tip = seciliEvrak.EVRAK_TUR_ID.Value;
                    frm.alreadyAddedList = null; // MyDataSource;

                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                    frm.Show();
                }
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MyDataSource.Remove(MyDataSource[vGridKiymetliEvrak.FocusedRecord]);

            foreach (AV001_TDI_BIL_KIYMETLI_EVRAK evrak in (sender as frmEkleKiymetliEvrak).selectedList)
            {
                if (MyDataSource.Find("ID", evrak.ID) == null)
                {
                    MyDataSource.Add(evrak);

                    //if (OnListedenKiymetliEvrakGetirildi != null)
                    //{
                    //    OnListedenKiymetliEvrakGetirildi(this,
                    //                                     new ListedenKiymetliEvrakGetirEventArgs(evrak));
                    //}
                    var nnDavaKiymetliEvrak = MyDavaFoy.NN_DAVA_KIYMETLI_EVRAKCollection.AddNew();
                    nnDavaKiymetliEvrak.KIYMETLI_EVRAK_ID = evrak.ID;
                }
            }
        }

        private void gcKiymetliEvrak_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gcKiymetliEvrak.Visible)
            {
                gcKiymetliEvrak.Visible = false;
                vGridKiymetliEvrak.Visible = true;
                dataNavigatorExtended1.Visible = true;
            }
            else
            {
                gcKiymetliEvrak.Visible = true;
                vGridKiymetliEvrak.Visible = false;
                dataNavigatorExtended1.Visible = false;
            }
        }

        private void LoadInitsData()
        {
            if (!initsFilled && MyDataSource.Count > 0)
            {
                BelgeUtil.Inits.KiymetliEvrakTipiGetir(rLueEvrakTuru);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
                BelgeUtil.Inits.BankaGetir(rLueBanka);
                AvukatPro.Services.Implementations.DevExpressService.BankaSubeGetir(rLueBankaSube, null);

                //BelgeUtil.Inits.BankaSubeGetir(rLueBankaSube);
                BelgeUtil.Inits.perCariGetir(rLueSoranCariID);
                BelgeUtil.Inits.perCariGetir(rLueSoranID);
                BelgeUtil.Inits.ParaBicimiAyarla(rSEKarsilikTutar);
                BelgeUtil.Inits.KiymetliEvrakTipiGetir(rLueEvrakTurId);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizId);
                BelgeUtil.Inits.BankaGetir(rLueBankaId);
                AvukatPro.Services.Implementations.DevExpressService.BankaSubeGetir(rLueSubeId, null);

                //BelgeUtil.Inits.BankaSubeGetir(rLueSubeId);
                BelgeUtil.Inits.KEAhzolunmaSekliGetir(rLueAhzolunmaSekli);
                BelgeUtil.Inits.KESonucuGetir(rLueSorulmaSonucu);

                initsFilled = true;
            }
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            LoadInitsData();
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            LoadInitsData();
        }

        private void ucKiymetliEvrakGrid_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;

            gcKiymetliEvrak.ButtonCevirClick += gcKiymetliEvrak_ButtonCevirClick;
            BindData();
            if (AppenButtonEnabled != null)
                gcKiymetliEvrak.EmbeddedNavigator.Buttons.CustomButtons[0].Enabled = AppenButtonEnabled.Value;
        }
    }
}