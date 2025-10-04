using System;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucSozlesmeDetayTakyidat : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSozlesmeDetayTakyidat()
        {
            InitializeComponent();
        }

        public TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT> MyDataSource
        {
            get
            {
                if (exGridSozlesmeDetayTakyidat.DataSource is TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT>)
                    return (TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT>)exGridSozlesmeDetayTakyidat.DataSource;
                return null;
            }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    exGridSozlesmeDetayTakyidat.DataSource = value;
                    InitsData();
                }
            }
        }

        private void ucSozlesmeDetayTakyidat_Load(object sender, EventArgs e)
        {
            //LOAD
            if (!this.DesignMode)
            {
                exGridSozlesmeDetayTakyidat.ButtonCevirClick += exGridSozlesmeDetayTakyidat_ButtonCevirClick;
                extendedGridControl1.ButtonCevirClick += exGridSozlesmeDetayTakyidat_ButtonCevirClick;
            }
        }

        private void InitsData()
        {
            BelgeUtil.Inits.perCariGetir(rlueIlgiliCari);
            BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
            BelgeUtil.Inits.SozlesmeTakyidatKodGetir(rlueTakdiyat);
        }

        private void exGridSozlesmeDetayTakyidat_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (exGridSozlesmeDetayTakyidat.Visible)
            {
                exGridSozlesmeDetayTakyidat.Visible = false;
                extendedGridControl1.Visible = true;
            }
            else
            {
                extendedGridControl1.Visible = false;
                exGridSozlesmeDetayTakyidat.Visible = true;
            }
        }
    }
}