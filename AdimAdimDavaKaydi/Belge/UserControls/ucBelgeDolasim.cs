using AvukatProLib2.Entities;
using System;
using System.ComponentModel;

namespace AdimAdimDavaKaydi.Belge.UserControls
{
    public partial class ucBelgeDolasim : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBelgeDolasim()
        {
            InitializeComponent();
        }

        private TList<AV001_TDIE_BIL_BELGE_DOLASIM> myDataSource;

        [Browsable(false)]
        public TList<AV001_TDIE_BIL_BELGE_DOLASIM> MyDataSource
        {
            get
            {
                if (this.DesignMode)
                    return null;

                return myDataSource;
            }
            set
            {
                if (value != null && !DesignMode)
                {
                    myDataSource = value;
                    exGrdBelgeDolasim.DataSource = MyDataSource;
                }
            }
        }

        private void ucBelgeDolasim_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
        }
    }
}