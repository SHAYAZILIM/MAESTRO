using System;
using System.Windows.Forms;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucSozlesmeUrunIlgilileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucSozlesmeUrunIlgilileri()
        {
            InitializeComponent();
            this.Load += ucSozlesmeUrunIlgilileri_Load;
        }

        private void ucSozlesmeUrunIlgilileri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            gridControl1.ButtonCevirClick += gridControl1_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += gridControl1_ButtonCevirClick;

            gridControl1.ShowOnlyPredefinedDetails = true;

            BelgeUtil.Inits.perCariGetir(rLueCariId);
            BelgeUtil.Inits.TarafSifatGetir(rLueTarafSifatId);
            BelgeUtil.Inits.TarafKoduGetir(rLueTarafKoduId);
        }

        private void gridControl1_ButtonCevirClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (extendedGridControl1.Visible)
            {
                extendedGridControl1.Visible = false;
                gridControl1.Visible = true;
            }
            else
            {
                extendedGridControl1.Visible = true;
                gridControl1.Visible = false;
            }
        }

        public TList<AV001_TS_BIL_SOZLESME_URUN_ILGILILERI> MyDataSource
        {
            get
            {
                if (this.gridControl1.DataSource is TList<AV001_TS_BIL_SOZLESME_URUN_ILGILILERI>)
                    return (TList<AV001_TS_BIL_SOZLESME_URUN_ILGILILERI>)gridControl1.DataSource;
                else
                    return null;
            }
            set
            {
                gridControl1.DataSource = value;
                extendedGridControl1.DataSource = gridControl1.DataSource;
            }
        }
    }
}