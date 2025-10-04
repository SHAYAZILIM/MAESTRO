using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmSozluk : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDIE_KOD_SOZLUK> MyDataSource = new TList<TDIE_KOD_SOZLUK>();

        public frmSozluk()
        {
            InitializeComponent();
        }

        public void sozlukGetir()
        {
            MyDataSource = DataRepository.TDIE_KOD_SOZLUKProvider.GetAll();
            gridSozluk.DataSource = MyDataSource;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            sozlukKaydet();
        }

        private void sozlukKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDIE_KOD_SOZLUKProvider.Save(tran, MyDataSource);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }
    }
}