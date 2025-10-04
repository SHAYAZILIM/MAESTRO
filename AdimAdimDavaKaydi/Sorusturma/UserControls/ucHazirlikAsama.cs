using System;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucHazirlikAsama : DevExpress.XtraEditors.XtraUserControl
    {
        public ucHazirlikAsama()
        {
            InitializeComponent();
        }

        public TList<AV001_TDIE_BIL_ASAMA> MyDataSource
        {
            get
            {
                if (gridHazirlikAsama.DataSource is TList<AV001_TDI_BIL_FOY_MUHASEBE>)
                    return (TList<AV001_TDIE_BIL_ASAMA>)gridHazirlikAsama.DataSource;

                return null;
            }
            set
            {
                gridHazirlikAsama.DataSource = value;
                extendedGridControl1.DataSource = gridHazirlikAsama.DataSource;
            }
        }

        private void gridHazirlikAsama_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (extendedGridControl1.Visible)
            {
                extendedGridControl1.Visible = false;
                gridHazirlikAsama.Visible = true;
            }
            else
            {
                extendedGridControl1.Visible = true;
                gridHazirlikAsama.Visible = false;
            }
        }

        private void ucHazirlikAsama_Load(object sender, EventArgs e)
        {
            //LOAD
            //MessageBox.Show("DesignMode = " + DesignMode);
            if (DesignMode)
            {
                return;
            }
            if (!this.DesignMode)
            {
                try
                {
                    gridHazirlikAsama.ButtonCevirClick += gridHazirlikAsama_ButtonCevirClick;
                    extendedGridControl1.ButtonCevirClick += gridHazirlikAsama_ButtonCevirClick;

                    BelgeUtil.Inits.AdliBirimGorevGetir(rLueAsamaAdliBirimGorev);
                    BelgeUtil.Inits.AdliBirimNoGetir(rLueAsamaAdliBirimNo);
                    BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAsamaAdliBirimAdliye);
                    BelgeUtil.Inits.AdliBirimBolumGetir(rLueAsamaAdliBirimBolum);
                    BelgeUtil.Inits.FormTipiGetir(rLueAsamaIcraFormTip);
                    BelgeUtil.Inits.AsamaOzelDurumGetir(rLueAsamaOzelDurumlar);
                    BelgeUtil.Inits.AsamaKodGetir(rLusAsamaKod);
                    BelgeUtil.Inits.AsamaAltKodGetir(rLueAsamaAltKod);
                    BelgeUtil.Inits.DavaNedenGetir(rLueAsamaDavaNeden);
                    BelgeUtil.Inits.AlacakNEdenGetir(rLueAsamaAlacakNeden);
                    BelgeUtil.Inits.HazirlikSikayetNedenGetir(rLueAsamaHazirlikNeden);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }
    }
}