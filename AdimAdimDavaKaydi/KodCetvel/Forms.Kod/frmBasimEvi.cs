using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel
{
    public partial class frmBasimEvi : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_BASIM_EVI> Source = new TList<TDI_KOD_BASIM_EVI>();

        public frmBasimEvi()
        {
            InitializeComponent();
        }

        public void BasimEviDoldur()
        {
            Source = DataRepository.TDI_KOD_BASIM_EVIProvider.GetAll();
            gridBasimEvi.DataSource = Source;
        }

        private void BasimEviKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_BASIM_EVIProvider.Save(tran, Source);
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
            BasimEviKaydet();
        }
    }
}