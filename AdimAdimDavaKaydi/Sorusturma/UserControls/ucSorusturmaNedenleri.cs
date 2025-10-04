using System;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucSorusturmaNedenleri : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSorusturmaNedenleri()
        {
            InitializeComponent();
        }

        public TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN> MyDataSource
        {
            get
            {
                if (vgrdSorusturmaNedenleri.DataSource is TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN>)
                    return (TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN>)vgrdSorusturmaNedenleri.DataSource;
                else
                    return null;
            }
            set { vgrdSorusturmaNedenleri.DataSource = value; }
        }

        private void ucSorusturmaNedenleri_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
                AvukatPro.Services.Implementations.DevExpressService.DavaNedeniDoldur(rLueSikayetNedenKod, null, true);
            }
        }
    }
}