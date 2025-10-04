using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmRehinHarcIstisnaBelge : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_REHIN_HARC_ISTISNA_BELGE> MyDataSource = new TList<TDI_KOD_REHIN_HARC_ISTISNA_BELGE>();

        public frmRehinHarcIstisnaBelge()
        {
            InitializeComponent();
        }

        public void harcIstisnaGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_REHIN_HARC_ISTISNA_BELGEProvider.GetAll();
            gridRehinHarcIstisna.DataSource = MyDataSource;
        }

        public void harcIstisnaKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_REHIN_HARC_ISTISNA_BELGEProvider.DeepSave(tran, MyDataSource);
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
            harcIstisnaKaydet();
        }
    }
}