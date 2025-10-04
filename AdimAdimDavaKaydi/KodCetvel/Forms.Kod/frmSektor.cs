using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmSektor : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDIE_KOD_SEKTOR> MyDataSource = new TList<TDIE_KOD_SEKTOR>();

        public frmSektor()
        {
            InitializeComponent();
        }

        public void sektorGetir()
        {
            MyDataSource = DataRepository.TDIE_KOD_SEKTORProvider.GetAll();
            gridSektor.DataSource = MyDataSource;
        }

        private void sektorKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDIE_KOD_SEKTORProvider.Save(tran, MyDataSource);
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
            sektorKaydet();
        }
    }
}