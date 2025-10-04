using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucDavaAsama : AvpXUserControl
    {
        public ucDavaAsama()
        {
            this.Load += ucDavaAsama_Load;
        }

        private VList<T_ASAMA_TARAF_SORUMLU> _MyDataSource;

        public VList<T_ASAMA_TARAF_SORUMLU> MyDataSource
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
            if (MyDataSource != null)
            {
                gridDavaAsamaBilgiler.DataSource = MyDataSource;
            }
        }

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                    MyDataSource = DataRepository.T_ASAMA_TARAF_SORUMLUProvider.Get("DAVA_FOY_ID = " + value.ID, string.Empty);
            }
        }

        public void RefreshAsama()
        {
            if (gridDavaAsamaBilgiler == null) return;
            gridDavaAsamaBilgiler.DataSource =
                DataRepository.T_ASAMA_TARAF_SORUMLUProvider.Get(string.Format("DAVA_FOY_ID={0}", MyFoy.ID),
                                                                 string.Empty);
            gridDavaAsamaBilgiler.RefreshDataSource();
            gridDavaAsamaBilgiler.Refresh();
        }

        private void ucDavaAsama_Load(object sender, EventArgs e)
        {
            //LOAD
            InitializeComponent();
            IsLoaded = true;
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.AsamaAltKodGetir(rLueAsamaAltKod);
                BelgeUtil.Inits.AsamaKodGetir(rLueAsamaKod);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
                BelgeUtil.Inits.AdliBirimBolumGetir(rLueAdliBirimBolum);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdlibirimNo);
                BelgeUtil.Inits.AlacakNEdenGetir(rLueAlacakNeden);
                BelgeUtil.Inits.AsamaModulGetir(rLueAsamaModul);
                BelgeUtil.Inits.AsamaOzelDurumGetir(rLueOzelDurumLar);
                BelgeUtil.Inits.DavaNedenGetir(rLueDavaNeden);
                BindData();
            }
        }
    }
}