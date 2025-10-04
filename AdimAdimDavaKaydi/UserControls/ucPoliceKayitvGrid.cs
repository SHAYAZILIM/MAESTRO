using System;
using System.ComponentModel;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucPoliceKayitvGrid : DevExpress.XtraEditors.XtraUserControl
    {
        public ucPoliceKayitvGrid()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_POLICE> MyDataSource
        {
            get
            {
                if (vGridPoliceBilgileri.DataSource is TList<AV001_TDI_BIL_POLICE>)
                    return (TList<AV001_TDI_BIL_POLICE>)vGridPoliceBilgileri.DataSource;
                return null;
            }
            set { vGridPoliceBilgileri.DataSource = value; }
        }

        private void ucPoliceKayitvGrid_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            #region <TIO - 20090615> Inits

            rLueCARI.NullText = "Seç";
            rLuePoliceBransID.NullText = "Seç";
            rLueCARI.Enter += delegate { BelgeUtil.Inits.perCariGetir(rLueCARI); };
            rLuePoliceBransID.Enter += delegate { BelgeUtil.Inits.PoliceBransGetir(rLuePoliceBransID); };
            BelgeUtil.Inits.DovizTipGetir(rLueDOVIZ);

            #endregion </TIO - 20090615>
        }
    }
}