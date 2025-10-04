using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Editor.UserControls
{
    public partial class ucKaydedilecekBelgeler : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucKaydedilecekBelgeler()
        {
            InitializeComponent();
        }

        public TList<AV001_TDIE_BIL_BELGE> MyDataSource
        {
            get { return gridControl1.DataSource as TList<AV001_TDIE_BIL_BELGE>; }
            set { gridControl1.DataSource = value; }
        }
    }
}