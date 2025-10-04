using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucTeminatMektupBilgiler : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucTeminatMektupBilgiler()
        {
            InitializeComponent();
        }

        private TList<AV001_TDI_BIL_TEMINAT_MEKTUP> myDataSource;

        [Browsable(false)]
        public TList<AV001_TDI_BIL_TEMINAT_MEKTUP> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                if (value != null)
                {
                    myDataSource = value;
                    exGridTeminatMektup.DataSource = value;
                }
            }
        }

        //private ViewType myView;
        //[Description("Görünümü deðiþtirir.")]
        //public ViewType MyView
        //{
        //    get { return myView; }
        //    set
        //    {
        //        myView = value;
        //        if (value == ViewType.GridView)
        //        {
        //            panelControl1.Visible = false;
        //            exGridTeminatMektup.Visible = true;
        //            exGridTeminatMektup.BringToFront();
        //        }
        //        else if (value == ViewType.VGrid)
        //        {
        //            panelControl1.Visible = true;
        //            exGridTeminatMektup.Visible = false;
        //            panelControl1.BringToFront();
        //        }
        //    }
        //}

        private void ucTeminatMektupBilgiler_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            #region LookUps

            BelgeUtil.Inits.ParaBicimiAyarla(tutar);
            BelgeUtil.Inits.BankaGetir(rlueBanka);
            BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
            BelgeUtil.Inits.BankaSubeGetir(rlueSube);
            BelgeUtil.Inits.perCariGetir(rlueCari);
            BelgeUtil.Inits.TeminatTipGetir(rlueTip);
            BelgeUtil.Inits.TeminatMektupDurumGetir(rlueDrum);
            BelgeUtil.Inits.TeminatMektupKonuGetir(rlueMektpKonu);
            BelgeUtil.Inits.RehinCinsGetir(lueLimitCins);
            BelgeUtil.Inits.TeminatMektupTarafTipGetir(rlueTarafTip);

            #endregion
        }
    }
}