using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmSozlesmeTakyidatKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_SOZLESME_TAKYIDAT> MyDataSource = new TList<TDI_KOD_SOZLESME_TAKYIDAT>();

        public frmSozlesmeTakyidatKodlari()
        {
            InitializeComponent();
        }

        public void sozlesmeTakyidatGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_SOZLESME_TAKYIDATProvider.GetAll();
            gridTakyidatKodlar.DataSource = MyDataSource;
        }

        public void sozlesmeTakyidatKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_SOZLESME_TAKYIDATProvider.Save(tran, MyDataSource);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
            sozlesmeTakyidatKaydet();
        }
    }
}