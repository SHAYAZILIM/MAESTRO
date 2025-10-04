using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmTeminatTipleri : DevExpress.XtraEditors.XtraForm
    {
        private TList<TI_KOD_TEMINAT_TIP> MyDataSource = new TList<TI_KOD_TEMINAT_TIP>();

        public frmTeminatTipleri()
        {
            InitializeComponent();
        }

        public void teminatTipGetir()
        {
            MyDataSource = DataRepository.TI_KOD_TEMINAT_TIPProvider.GetAll();
            gridTeminatTipleri.DataSource = MyDataSource;
        }

    }
}