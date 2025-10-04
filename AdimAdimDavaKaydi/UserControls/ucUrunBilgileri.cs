using System;
using System.Windows.Forms;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucUrunBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucUrunBilgileri()
        {
            InitializeComponent();
            this.Load += ucUrunBilgileri_Load;
        }

        private void ucUrunBilgileri_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.perCariGetir(rLueCariId);
                BelgeUtil.Inits.ProjeOzelKodGetir(rLueUrunOzelKodId);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizTipleri);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
                BelgeUtil.Inits.MarkaTipGetir(rLueMarkaTipId);
                BelgeUtil.Inits.UrunKategoriGetir(rLueUrunKatId);
                BelgeUtil.Inits.UrunAltKategoriGetir(rLueUrunAltKatId);
                BelgeUtil.Inits.UrunSinifKodlariGetir(rLueSinifKodId);
                BelgeUtil.Inits.FirmaTurGetir(rLueFaaliyetAlanId);
            }
        }

        public TList<AV001_TS_BIL_SOZLESME_URUN_BILGILERI> MyDataSource
        {
            get
            {
                if (grdUrunBilgileri.DataSource is TList<AV001_TS_BIL_SOZLESME_URUN_BILGILERI>)
                    return (TList<AV001_TS_BIL_SOZLESME_URUN_BILGILERI>)grdUrunBilgileri.DataSource;
                else
                    return null;
            }
            set { grdUrunBilgileri.DataSource = value; }
        }
    }
}