using System;
using System.ComponentModel;
using AvukatProLib2.Entities;
using DevExpress.XtraGrid.Views.Grid;

namespace AdimAdimDavaKaydi.Util.Yardim
{
    public partial class ucPratikYardim : DevExpress.XtraEditors.XtraUserControl
    {
        public ucPratikYardim()
        {
            InitializeComponent();
        }

        private TList<TDIE_KOD_PRATIK_YARDIM> myDataSource;

        [Browsable(false)]
        public TList<TDIE_KOD_PRATIK_YARDIM> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                if (value != null)
                    myDataSource = value;
            }
        }

        public TDIE_KOD_PRATIK_YARDIM AlSeciliYardim()
        {
            GridView gview = (GridView)exGridYardim.MainView;
            object secili = gview.GetFocusedRow();
            if (secili is TDIE_KOD_PRATIK_YARDIM)
            {
                TDIE_KOD_PRATIK_YARDIM yardim = (TDIE_KOD_PRATIK_YARDIM)secili;
                return yardim;
            }

            return null;
        }

        private void ucPratikYardim_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            BelgeUtil.Inits.ModulGetir(rLueModul);
            BelgeUtil.Inits.UyariTipDoldur(rLueUyariTip);
        }
    }
}