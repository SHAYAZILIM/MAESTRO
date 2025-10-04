using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmRucuHikaye : DevExpress.XtraEditors.XtraForm
    {
        private TList<AV001_TDI_BIL_RUCU_HIKAYE> MyDataSource = new TList<AV001_TDI_BIL_RUCU_HIKAYE>();

        public frmRucuHikaye()
        {
            InitializeComponent();
        }

        public void rucuHikayeGetir()
        {
            MyDataSource = DataRepository.AV001_TDI_BIL_RUCU_HIKAYEProvider.GetAll();
            gridRucuHikayesi.DataSource = MyDataSource;
        }

        public void rucuHikayeKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TDI_BIL_RUCU_HIKAYEProvider.Save(tran, MyDataSource);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
            rucuHikayeKaydet();
        }
    }
}