using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmAraKararTip : DevExpress.XtraEditors.XtraForm
    {
        private TList<TD_KOD_ARA_KARAR_TIP> MyDataSource = new TList<TD_KOD_ARA_KARAR_TIP>();

        public frmAraKararTip()
        {
            InitializeComponent();
        }

        public void AraKararDoldur()
        {
            MyDataSource = DataRepository.TD_KOD_ARA_KARAR_TIPProvider.GetAll();
            gridAraKarar.DataSource = MyDataSource;
        }

        private void AraKararKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TD_KOD_ARA_KARAR_TIPProvider.Save(tran, MyDataSource);
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
            AraKararKaydet();
        }
    }
}