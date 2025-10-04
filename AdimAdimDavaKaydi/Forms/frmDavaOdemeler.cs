using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmDavaOdemeler : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmDavaOdemeler()
        {
            InitializeComponent();
        }


        public TList<AV001_TD_BIL_BORCLU_ODEME> MyDataSource
        {
            get
            {
                if (grdControlDavaOdeme.DataSource is TList<AV001_TD_BIL_BORCLU_ODEME>)
                {
                    return (TList<AV001_TD_BIL_BORCLU_ODEME>)grdControlDavaOdeme.DataSource;
                }
                else
                {
                    return null;
                }
            }
            set { grdControlDavaOdeme.DataSource = value; }
        }
    }
}