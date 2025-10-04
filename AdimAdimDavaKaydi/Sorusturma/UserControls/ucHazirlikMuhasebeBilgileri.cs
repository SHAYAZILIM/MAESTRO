using System;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucHazirlikMuhasebeBilgileri : DevExpress.XtraEditors.XtraUserControl
    {
        public ucHazirlikMuhasebeBilgileri()
        {
            InitializeComponent();
        }

        public TList<AV001_TDI_BIL_FOY_MUHASEBE> MyDataSource
        {
            get
            {
                if (gridMuhasebeBilgileri.DataSource is TList<AV001_TDI_BIL_FOY_MUHASEBE>)
                    return (TList<AV001_TDI_BIL_FOY_MUHASEBE>)gridMuhasebeBilgileri.DataSource;

                return null;
            }
            set
            {
                gridMuhasebeBilgileri.DataSource = value;
                extendedGridControl1.DataSource = gridMuhasebeBilgileri.DataSource;
            }
        }

        private void gridMuhasebeBilgileri_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (extendedGridControl1.Visible)
            {
                extendedGridControl1.Visible = false;
                gridMuhasebeBilgileri.Visible = true;
            }
            else
            {
                extendedGridControl1.Visible = true;
                gridMuhasebeBilgileri.Visible = false;
            }
        }

        private void ucMuhasebeBilgileri_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                try
                {
                    gridMuhasebeBilgileri.ButtonCevirClick += gridMuhasebeBilgileri_ButtonCevirClick;
                    extendedGridControl1.ButtonCevirClick += gridMuhasebeBilgileri_ButtonCevirClick;

                    BelgeUtil.Inits.OzelTutarkonuGetir(rLueOzelTutar);
                    BelgeUtil.Inits.perCariGetir(rLueMuhasebeTaraf);
                    BelgeUtil.Inits.BelgeOzelKodGetir(rLueBelgeOzelKod);
                    BelgeUtil.Inits.CariOzelKodGetir(rLueCariOzelKod);
                    BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelFoyKod);
                    BelgeUtil.Inits.DovizTipGetir(rLueMuhasebeDoviz);
                    BelgeUtil.Inits.MuhasebeDurumGetir(rLueAcikKapaliID);
                    BelgeUtil.Inits.BorcAlacakGetir(rLueMuhBorcAlacak);
                    BelgeUtil.Inits.MuhasebeBelgeTurGetir(rLueBelgetur);
                    BelgeUtil.Inits.MuhasebeHareketAltKategori(rLueHareketAltKategori);
                    BelgeUtil.Inits.HareketAnaKategoriGetir(rLueHareketAnaKategori);
                    BelgeUtil.Inits.perCariGetir(rLueMuhasebeCari);
                    BelgeUtil.Inits.OrtaklikFoyGetir(rLueOrtaklik);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }
    }
}