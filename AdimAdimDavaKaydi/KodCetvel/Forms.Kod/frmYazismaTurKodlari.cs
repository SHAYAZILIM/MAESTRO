using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmYazismaTurKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_YAZISMA_TUR> MyDataSource = new TList<TDI_KOD_YAZISMA_TUR>();

        public frmYazismaTurKodlari()
        {
            InitializeComponent();
        }

        public void yazismaTurGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_YAZISMA_TURProvider.GetAll();
            gridYazismaTurkodlar.DataSource = MyDataSource;
        }

        public void yazismaTurKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_YAZISMA_TURProvider.Save(tran, MyDataSource);
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
            yazismaTurKaydet();
        }
    }
}