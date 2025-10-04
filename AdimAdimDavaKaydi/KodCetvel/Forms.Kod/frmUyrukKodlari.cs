using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmUyrukKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_UYRUK> MyDataSource = new TList<TDI_KOD_UYRUK>();

        public frmUyrukKodlari()
        {
            InitializeComponent();
        }

        public void uyrukKodGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_UYRUKProvider.GetAll();
            gridUyrukKodlar.DataSource = MyDataSource;
        }

        public void uyrukKodKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_UYRUKProvider.Save(tran, MyDataSource);
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
            uyrukKodKaydet();
        }
    }
}