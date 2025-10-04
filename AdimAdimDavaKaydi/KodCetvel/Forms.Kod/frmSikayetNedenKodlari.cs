using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmSikayetNedenKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TI_KOD_SIKAYET_NEDEN> MyDataSource = new TList<TI_KOD_SIKAYET_NEDEN>();

        public frmSikayetNedenKodlari()
        {
            InitializeComponent();
        }

        public void sikayetNedenGetir()
        {
            MyDataSource = DataRepository.TI_KOD_SIKAYET_NEDENProvider.GetAll();
            gridSikayetNedenKodlari.DataSource = MyDataSource;
        }

        public void sikayetNEdenKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TI_KOD_SIKAYET_NEDENProvider.Save(tran, MyDataSource);
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
            sikayetNEdenKaydet();
        }
    }
}