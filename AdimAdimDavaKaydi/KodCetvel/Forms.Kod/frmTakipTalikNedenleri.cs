using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmTakipTalikNedenleri : DevExpress.XtraEditors.XtraForm
    {
        private TList<TI_KOD_TALIK_NEDEN> MyDataSource = new TList<TI_KOD_TALIK_NEDEN>();

        public frmTakipTalikNedenleri()
        {
            InitializeComponent();
        }

        public void talikNedenGetir()
        {
            MyDataSource = DataRepository.TI_KOD_TALIK_NEDENProvider.GetAll();
            gridTakipTalikErteleme.DataSource = MyDataSource;
        }

    }
}