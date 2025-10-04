using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmKlasorSubeOzelKod : Form
    {
        public frmKlasorSubeOzelKod()
        {
            InitializeComponent();
            this.Load += frmKlasorSubeOzelKod_Load;
        }

        public string OzelKod;

        public TDIE_KOD_PROJE_OZEL_KOD MyOzelKod { get; set; }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                MyOzelKod.OZEL_KOD = txtOzelKod.Text;
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                tran.BeginTransaction();
                DataRepository.TDIE_KOD_PROJE_OZEL_KODProvider.DeepSave(tran, MyOzelKod);
                tran.Commit();
                this.Close();
            }
            catch
            {
            }
        }

        private void frmKlasorSubeOzelKod_Load(object sender, EventArgs e)
        {
            MyOzelKod = new TDIE_KOD_PROJE_OZEL_KOD();

            txtOzelKod.Text = OzelKod;
        }
    }
}