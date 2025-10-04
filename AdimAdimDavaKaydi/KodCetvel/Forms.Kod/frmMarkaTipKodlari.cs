using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmMarkaTipKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TS_KOD_MARKA_TIP> MyDataSource = new TList<TS_KOD_MARKA_TIP>();

        public frmMarkaTipKodlari()
        {
            InitializeComponent();
        }

        public void MarkaTipiDoldur()
        {
            MyDataSource = DataRepository.TS_KOD_MARKA_TIPProvider.GetAll();
            gridMarkaTip.DataSource = MyDataSource;
        }

        private void MarkaTipiKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TS_KOD_MARKA_TIPProvider.Save(tran, MyDataSource);
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
            MarkaTipiKaydet();
        }
    }
}