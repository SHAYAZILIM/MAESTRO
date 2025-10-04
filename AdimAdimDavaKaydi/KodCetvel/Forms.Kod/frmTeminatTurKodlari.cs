using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmTeminatTurKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TI_KOD_TEMINAT_TUR> MyDataSource = new TList<TI_KOD_TEMINAT_TUR>();

        public frmTeminatTurKodlari()
        {
            InitializeComponent();
        }

        public void teminatTurKodGetir()
        {
            MyDataSource = DataRepository.TI_KOD_TEMINAT_TURProvider.GetAll();
            gridTeminatTurKodlari.DataSource = MyDataSource;
        }

        public void teminatTurKodKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TI_KOD_TEMINAT_TURProvider.Save(tran, MyDataSource);
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
            teminatTurKodKaydet();
        }
    }
}