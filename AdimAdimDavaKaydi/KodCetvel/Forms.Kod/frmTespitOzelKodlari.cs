using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmTespitOzelKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TD_KOD_TESPIT_OZEL> MyDataSource = new TList<TD_KOD_TESPIT_OZEL>();

        public frmTespitOzelKodlari()
        {
            InitializeComponent();
        }

        public void tespitOzelKodGetir()
        {
            MyDataSource = DataRepository.TD_KOD_TESPIT_OZELProvider.GetAll();
            gridTespitOzelKodlar.DataSource = MyDataSource;
        }

        public void tespitOzelKodKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TD_KOD_TESPIT_OZELProvider.Save(tran, MyDataSource);
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
            tespitOzelKodKaydet();
        }
    }
}