using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmYazar : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_YAZAR> MyDataSource = new TList<TDI_KOD_YAZAR>();

        public frmYazar()
        {
            InitializeComponent();
        }

        public void yazarDoldur()
        {
            MyDataSource = DataRepository.TDI_KOD_YAZARProvider.GetAll();
            gridYazarlar.DataSource = MyDataSource;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            yazarKaydet();
        }

        private void yazarKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_YAZARProvider.Save(tran, MyDataSource);
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