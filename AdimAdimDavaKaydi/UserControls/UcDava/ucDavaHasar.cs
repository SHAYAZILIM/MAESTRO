using System;
using System.ComponentModel;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucDavaHasar : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDavaHasar()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_POLICE_HASAR> MyDataSource
        {
            get
            {
                if (gcHasar.DataSource is TList<AV001_TDI_BIL_POLICE_HASAR>)
                    return (TList<AV001_TDI_BIL_POLICE_HASAR>)gcHasar.DataSource;

                return null;
            }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    gcHasar.DataSource = value;
                    gridControl1.DataSource = gcHasar.DataSource;
                }
            }
        }

        [Browsable(false)]
        public POLICE_HASAR MyPolice { get; set; }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy { get; set; }

        private void ucDavaHasar_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                gcHasar.ButtonCevirClick
                    += gcHasar_ButtonCevirClick;

                gridControl1.ButtonCevirClick
                    += gcHasar_ButtonCevirClick;

                #region Eskiler

                //Inits.AlacakNedenKodGetir(rLueAlacakNeden);
                //AdimAdimDavaKaydi.Util.Inits.AlacakNEdenGetir(rLueAlacakNdn);
                //AdimAdimDavaKaydi.Util.Inits.DovizTipGetir(rLueDovizKodu);
                //AdimAdimDavaKaydi.Util.Inits.DovizTipGetir(rLueDovizTip);
                //AdimAdimDavaKaydi.Util.Inits.ParaBicimiAyarla(rudTutar);
                //AdimAdimDavaKaydi.Util.Inits.ParaBicimiAyarla(rudTutar2);
                //AdimAdimDavaKaydi.Util.Inits.DavaNedenGetir(rLueDavaNEden);
                //AdimAdimDavaKaydi.Util.Inits.AlacakNEdenGetir(rLueAlacakNdn);
                //AdimAdimDavaKaydi.Util.Inits.DovizTipGetir(rLueDovizTip);

                #endregion

                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.ParaBicimiAyarla(tutar);
                BelgeUtil.Inits.TeminatAltTipGetir(rlueTeminatAltTip);
                BelgeUtil.Inits.DosyaDurumGetir(rlueDosyaDurum);
                BelgeUtil.Inits.IbranameDurumGetir(rlueRucuDurum);
            }
        }

        private void gcHasar_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gcHasar.Visible)
            {
                gridControl1.Visible = true;
                gcHasar.Visible = false;
            }
            else
            {
                gridControl1.Visible = false;
                gcHasar.Visible = true;
            }
        }
    }
}