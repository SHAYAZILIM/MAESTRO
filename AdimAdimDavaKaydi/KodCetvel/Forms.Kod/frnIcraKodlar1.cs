using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frnIcraKodlar1 : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_SOZLESME_TARAF_SIFAT> MyDatasource = new TList<TDI_KOD_SOZLESME_TARAF_SIFAT>();

        public frnIcraKodlar1()
        {
            InitializeComponent();
        }

        public void sozlesmeTarafSifatGetir()
        {
            MyDatasource = DataRepository.TDI_KOD_SOZLESME_TARAF_SIFATProvider.GetAll();
            gridSozlesmeTarafKodlar.DataSource = MyDatasource;
        }

        public void sozlesmeTarafSifatKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_SOZLESME_TARAF_SIFATProvider.Save(tran, MyDatasource);
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
            sozlesmeTarafSifatKaydet();
        }
    }
}