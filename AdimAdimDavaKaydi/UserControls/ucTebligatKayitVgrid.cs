using System;
using System.ComponentModel;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucTebligatKayitVgrid : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTebligatKayitVgrid()
        {
            InitializeComponent();
        }

        private TList<AV001_TDI_BIL_TEBLIGAT> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TDI_BIL_TEBLIGAT> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (_MyDataSource != null && !this.DesignMode)
                {
                    TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> muhataplar = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
                    foreach (AV001_TDI_BIL_TEBLIGAT tebligat in _MyDataSource)
                    {
                        muhataplar.AddRange(tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection);
                    }

                    vGridTebligat.DataSource = muhataplar;
                }
            }
        }

        private void ucTebligatKayitVgrid_Load(object sender, EventArgs e)
        {
            //LOAD
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueBirimNo);
                BelgeUtil.Inits.perCariGetir(rLueCariID);
                BelgeUtil.Inits.TebligatAlanBaglantiGetir(rLueAlanBaglanti);
                BelgeUtil.Inits.TebligatAlimSekli(rLueAlimSekli);
                BelgeUtil.Inits.TebligatAlinmamaNedenGetir(rLueAlinmamaNeden);
                BelgeUtil.Inits.TebligatTeslimYerGetir(rLueTeslimYer);
                BelgeUtil.Inits.TebligatSekliGetir(rLueTebligatSekli);
                BelgeUtil.Inits.MuhasebeHareketAltKategori(rLueMuhasebeHareketAltKategori);
            }
        }
    }
}