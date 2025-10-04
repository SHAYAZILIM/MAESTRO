using System;
using System.Windows.Forms;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucTeminatMektupBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucTeminatMektupBilgileri()
        {
            InitializeComponent();
            this.Load += ucTeminatMektupBilgileri_Load;
        }

        private void ucTeminatMektupBilgileri_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
                BelgeUtil.Inits.BankaGetir(rLueBanka);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueBirim);
                BelgeUtil.Inits.BankaSubeGetir(rLueBSube);
                BelgeUtil.Inits.perCariGetir(rLueCari);
                BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
                BelgeUtil.Inits.TeminatMektupKonuGetir(rLueMektupKonu);
                BelgeUtil.Inits.TeminatTuruGetir(rLueTeminatTuru);
                BelgeUtil.Inits.TeminatTipGetir(rLueTip);
                if (MyDataSource == null)
                    MyDataSource = BelgeUtil.Inits.R_BIRLESIK_TAKIPLER_TEMINAT_MEKTUPGetir();
            }
        }

        private VList<R_BIRLESIK_TAKIPLER_TEMINAT_MEKTUP> _MyDataSource;

        public VList<R_BIRLESIK_TAKIPLER_TEMINAT_MEKTUP> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                if (value == null)
                {
                    if (exgrdTwminatMaktup != null)
                        exgrdTwminatMaktup.DataSource = value;
                }

                _MyDataSource = value;
                if (MyDataSource != null)
                    exgrdTwminatMaktup.DataSource = _MyDataSource;
            }
        }
    }
}