using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmRehinDurum : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_REHIN_DURUM> MyDataSource = new TList<TDI_KOD_REHIN_DURUM>();

        public frmRehinDurum()
        {
            InitializeComponent();
        }

        public void rehinDurumGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_REHIN_DURUMProvider.GetAll();
            gridRehinDurum.DataSource = MyDataSource;
        }

        public void rehinDurumKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_REHIN_DURUMProvider.Save(tran, MyDataSource);
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
            rehinDurumKaydet();
        }
    }
}