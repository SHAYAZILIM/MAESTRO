using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmSureOzelKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_SURE> MyDataSource = new TList<TDI_KOD_SURE>();

        public frmSureOzelKodlari()
        {
            InitializeComponent();
        }

        public void sureKodGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_SUREProvider.GetAll();
            gridSureOzelKodlar.DataSource = MyDataSource;
        }

    }
}