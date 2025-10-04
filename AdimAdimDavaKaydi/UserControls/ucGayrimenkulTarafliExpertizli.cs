using System.ComponentModel;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucGayrimenkulTarafliExpertizli : XtraUserControl
    {
        public ucGayrimenkulTarafliExpertizli()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(ucGayrimenkulTarafliExpertizli_Load);
        }

        private bool _HacizKayitEkranimi;

        public bool HacizKayitEkranimi
        {
            get
            {
                return _HacizKayitEkranimi;
            }
            set
            {
                _HacizKayitEkranimi = value;
                ucKiymetTakdiri1.HacizKayitEkraniMi = value;
            }
        }

        private void ucGayrimenkulTarafliExpertizli_Load(object sender, System.EventArgs e)
        {
            ucKiymetTakdiri1.EkspertizKaydiMi = true;
        }

        private TList<AV001_TI_BIL_GAYRIMENKUL> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TI_BIL_GAYRIMENKUL> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (_MyDataSource != null)
                {
                    if (this.DesignMode) return;
                    BindData();
                }
            }
        }

        private void BindData()
        {
            if (MyDataSource != null)
            {
                ucGayriMenkul1.MyDataSource = MyDataSource;
                if (MyDataSource[0].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection.Count == 0)
                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(MyDataSource[0], false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>));
                ucMenkulTaraf.MyDataSource = MyDataSource[0].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection;
                if (MyDataSource[0].AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDATCollection.Count == 0)
                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(MyDataSource, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT>));
                ucTakyidat.MyDataSource = MyDataSource[0].AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDATCollection;
                if (MyDataSource[0].AV001_TI_BIL_KIYMET_TAKDIRICollection.Count == 0)
                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(MyDataSource, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>));
                ucKiymetTakdiri1.MyDataSource = MyDataSource[0].AV001_TI_BIL_KIYMET_TAKDIRICollection;
                ucGayriMenkul1.dnExtented = false;
            }
        }
    }
}