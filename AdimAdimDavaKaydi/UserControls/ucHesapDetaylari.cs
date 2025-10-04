using System;
using AvukatProLib2.Entities;
using System.ComponentModel;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucHesapDetaylari : DevExpress.XtraEditors.XtraUserControl
    {
        public ucHesapDetaylari()
        {
            InitializeComponent();
        }

        private AV001_TI_BIL_FOY _Myfoy;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return _Myfoy; }
            set
            {
                if (value != null)
                {
                    _Myfoy = value;

                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(value, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,
                                                                                        typeof(TList<AV001_TI_BIL_FAIZ>),
                                                                                        typeof(TList<AV001_TI_BIL_TAZMINAT>),
                                                                                        typeof(TList<AV001_TI_BIL_VEKALET_UCRET>),
                                                                                        typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>),
                                                                                        typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>),
                                                                                        typeof(TList<AV001_TI_BIL_HARC>));

                    xgcFaizler.DataSource = value.AV001_TI_BIL_FAIZCollection;
                    egridTazminatDetaylar.DataSource = value.AV001_TI_BIL_TAZMINATCollection;
                    eGridVekaletUcretDetay.DataSource = value.AV001_TI_BIL_VEKALET_UCRETCollection;
                    eGridOdemeDagilim.DataSource = value.AV001_TI_BIL_ODEME_DAGILIMCollection;
                    ucHarcDetayIcra1.MyDataSource = value.AV001_TI_BIL_HARCCollection;
                }
                else
                {
                    xgcFaizler.DataSource = null;
                    egridTazminatDetaylar.DataSource = null;
                    eGridVekaletUcretDetay.DataSource = null;
                    eGridOdemeDagilim.DataSource = null;
                    ucHarcDetayIcra1.MyDataSource = null;
                }
            }
        }

        private bool ekleKaldirButonuGizle;

        public bool EkleKaldirButonuGizle
        {
            get { return ekleKaldirButonuGizle; }
            set
            {
                ekleKaldirButonuGizle = value;

                if (value)
                {
                    xgcFaizler.EmbeddedNavigator.Buttons.Append.Enabled = false;
                    xgcFaizler.EmbeddedNavigator.Buttons.Remove.Enabled = false;
                }
            }
        }

        private void ucHesapDetaylari_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
                BelgeUtil.Inits.FaizTipiGetir(rLueFaizTipID);
                BelgeUtil.Inits.perCariGetir(rLueCariID);
                BelgeUtil.Inits.FaizKalemGetir(rLueFaizKalemID);
                BelgeUtil.Inits.MahsupAltKategoriGetir(rLueMahsupAltKategoriID);
                BelgeUtil.Inits.MahsupKategoriGetir(rLueMahsupKategoriID);
                BelgeUtil.Inits.ParaBicimiAyarla(rudTutar);
                BelgeUtil.Inits.FaizdenOnce(rLueTakipdenOnce);
                BelgeUtil.Inits.AlacakNedenByFoy(MyFoy, gLueMahsupAlacakNedenId);
                BelgeUtil.Inits.OdemeTakipSonrasimiGetir(rLueFaizTakiptenOncemi);
            }
        }
    }
}