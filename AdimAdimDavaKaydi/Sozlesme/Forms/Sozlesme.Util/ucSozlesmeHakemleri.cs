using System;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Sozlesme.Forms.Sozlesme.Util
{
    public partial class ucSozlesmeHakemleri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucSozlesmeHakemleri()
        {
            InitializeComponent();
            this.Load += ucSozlesmeHakemleri_Load;
            dataNavigator1.OnCevirClick += dataNavigator1_OnCevirClick;
        }

        public TList<AV001_TDI_BIL_SOZLESME_HAKEMLERI> MyDataSource
        {
            get
            {
                if (vGridControl1.DataSource is TList<AV001_TDI_BIL_SOZLESME_HAKEMLERI>)
                    return (TList<AV001_TDI_BIL_SOZLESME_HAKEMLERI>)vGridControl1.DataSource;
                else
                    return null;
            }
            set
            {
                vGridControl1.DataSource = value;
                gridControl1.DataSource = value;
                dataNavigator1.DataSource = value;
            }
        }

        private void dataNavigator1_OnCevirClick(object sender, EventArgs e)
        {
            if (gridControl1.Visible)
            {
                gridControl1.Visible = false;
                vGridControl1.Visible = true;
                vGridControl1.BringToFront();
            }

            else if (vGridControl1.Visible)
            {
                vGridControl1.Visible = false;
                gridControl1.Visible = true;
                gridControl1.BringToFront();
            }
        }

        private void ucSozlesmeHakemleri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            BelgeUtil.Inits.perCariGetir(rLueCari);
            BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
            BelgeUtil.Inits.OdemeTipiGetir(rLueOdemeTipi);
            BelgeUtil.Inits.CariHakemGetir(rLueCariHakem);

            //GetData.initDovizTip(persistentRepository1.Items[2] as RepositoryItemLookUpEdit);
            //GetData.initOdemeTip(persistentRepository1.Items[3] as RepositoryItemLookUpEdit);
        }
    }
}