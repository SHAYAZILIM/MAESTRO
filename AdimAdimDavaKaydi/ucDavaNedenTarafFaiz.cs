using System;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi
{
    public partial class ucDavaNedenTarafFaiz : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDavaNedenTarafFaiz()
        {
            InitializeComponent();
        }

        public TList<AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZ> MyDataSource
        {
            get
            {
                if (gcDavaNedenFaiz.DataSource is TList<AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZ>)
                    return (TList<AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZ>)gcDavaNedenFaiz.DataSource;
                else
                    return null;
            }
            set
            {
                gcDavaNedenFaiz.DataSource = value;
                extendedGridControl1.DataSource = gcDavaNedenFaiz.DataSource;
            }
        }

        private void gcDavaNedenFaiz_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (extendedGridControl1.Visible)
            {
                extendedGridControl1.Visible = false;
                gcDavaNedenFaiz.Visible = true;
            }
            else
            {
                extendedGridControl1.Visible = true;
                gcDavaNedenFaiz.Visible = false;
            }
        }

        private void ucDavaNedenTarafFaiz_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                BelgeUtil.Inits.FaizTipiGetir(rlkFaizTip);
            }

            //LOAD
            gcDavaNedenFaiz.ButtonCevirClick += gcDavaNedenFaiz_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += gcDavaNedenFaiz_ButtonCevirClick;
        }
    }
}