using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmDusmeDegismeKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_DUSME_DEGISME_KODU> Source = new TList<TDI_KOD_DUSME_DEGISME_KODU>();

        public frmDusmeDegismeKodlari()
        {
            InitializeComponent();
        }

        public void DusmeDegistirmeDoldur()
        {
            Source = DataRepository.TDI_KOD_DUSME_DEGISME_KODUProvider.GetAll();
            gridDusmeDegistirme.DataSource = Source;
        }

        private void DusmeDegistirmeKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_DUSME_DEGISME_KODUProvider.Save(tran, Source);
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
            DusmeDegistirmeKaydet();
        }
    }
}