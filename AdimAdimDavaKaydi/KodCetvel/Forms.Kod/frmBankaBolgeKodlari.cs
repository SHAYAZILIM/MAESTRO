using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmBankaBolgeKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_BANKA_BOLGE> MyDataSourceBankaBolge = new TList<TDI_KOD_BANKA_BOLGE>();

        public frmBankaBolgeKodlari()
        {
            InitializeComponent();
        }

        public void bankaBolgeGetir()
        {
            MyDataSourceBankaBolge = AvukatProLib2.Data.DataRepository.TDI_KOD_BANKA_BOLGEProvider.GetAll();
            gridBankaBolgeKodlar.DataSource = MyDataSourceBankaBolge;
        }

        public void bankaBolgeKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_BANKA_BOLGEProvider.Save(tran, MyDataSourceBankaBolge);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bankaBolgeKaydet();
        }
    }
}