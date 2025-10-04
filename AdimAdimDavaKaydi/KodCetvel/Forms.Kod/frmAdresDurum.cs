using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmAdresDurum : DevExpress.XtraEditors.XtraForm
    {
        private TList<AV001_TDI_KOD_ADRES_DURUM> MyDataSource = new TList<AV001_TDI_KOD_ADRES_DURUM>();

        public frmAdresDurum()
        {
            InitializeComponent();
        }

        public void AdresDurumlariDoldur()
        {
            MyDataSource = DataRepository.AV001_TDI_KOD_ADRES_DURUMProvider.GetAll();
            gridAdresDurumlari.DataSource = MyDataSource;
        }

        private void AdresDurumlariKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TDI_KOD_ADRES_DURUMProvider.Save(tran, MyDataSource);
                    tran.Commit();

                    //XtraMessageBox.Show("Adres Türleri Kaydedilmiştir...");
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AdresDurumlariKaydet();
        }
    }
}