using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmDavaSonucKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_DAVA_SONUC> Source = new TList<TDI_KOD_DAVA_SONUC>();

        public frmDavaSonucKodlari()
        {
            InitializeComponent();
        }

        public void DavaSonucDoldur()
        {
            Source = DataRepository.TDI_KOD_DAVA_SONUCProvider.GetAll();
            gridDavaSonuc.DataSource = Source;
        }

        private void DavaSonucKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_DAVA_SONUCProvider.Save(tran, Source);
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
            DavaSonucKaydet();
        }
    }
}