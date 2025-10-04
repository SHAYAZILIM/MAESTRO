using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmPoliceBransKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_POLICE_BRANS> MyDataSource = new TList<TDI_KOD_POLICE_BRANS>();

        public frmPoliceBransKodlari()
        {
            InitializeComponent();
        }

        public void policeBransGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_POLICE_BRANSProvider.GetAll();
            gridPoliceBransKodlar.DataSource = MyDataSource;
        }

        public void policeBransKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("�lgili kay�tlarda yapt���n�z t�m de�i�iklikler kaydedilecektir" + Environment.NewLine + "Onayl�yormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_POLICE_BRANSProvider.Save(tran, MyDataSource);
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
            policeBransKaydet();
        }
    }
}