using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmOtomatikDuzelt : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDIE_KOD_OTOMATIK_DUZELT> MyDataSource = new TList<TDIE_KOD_OTOMATIK_DUZELT>();

        public frmOtomatikDuzelt()
        {
            InitializeComponent();
        }

        public void OtomatikDuzeltDoldur()
        {
            MyDataSource = DataRepository.TDIE_KOD_OTOMATIK_DUZELTProvider.GetAll();
            gridOtomatikDuzelt.DataSource = MyDataSource;
        }

        private void OtomatikDuzeltKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDIE_KOD_OTOMATIK_DUZELTProvider.Save(tran, MyDataSource);
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
            OtomatikDuzeltKaydet();
        }
    }
}