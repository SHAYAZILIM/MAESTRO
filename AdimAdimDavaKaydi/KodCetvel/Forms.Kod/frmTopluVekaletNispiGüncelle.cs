using System;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmTopluVekaletNispiGüncelle : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_VEKALET_NISPI> MyDataSourceVekaletNispi = new TList<TDI_CET_VEKALET_NISPI>();

        public frmTopluVekaletNispiGüncelle()
        {
            InitializeComponent();
            getVekaletMaktu(DateTime.Today);
        }

        public void vekaletNispiGetir()
        {
            TDI_CET_VEKALET_NISPI vekaletNispi = new TDI_CET_VEKALET_NISPI();
            MyDataSourceVekaletNispi = AvukatProLib2.Data.DataRepository.TDI_CET_VEKALET_NISPIProvider.GetAll();
            gridVekaletNispiUcreti.DataSource = MyDataSourceVekaletNispi;
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.YuzdeBicimiAyarla(spOran);
        }

        private void getVekaletMaktu(DateTime dt)
        {
            DialogResult dr = XtraMessageBox.Show("En yakın tarihe ait vekalet maktu oranlarının kopyalanmasını ister misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool result = dr == DialogResult.Yes ? true : false;
            vekaletNispiGetir();
        }

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
        }
    }
}