using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmTeminatMektupKonulari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_TEMINAT_MEKTUP_KONU> MyDataSource = new TList<TDI_KOD_TEMINAT_MEKTUP_KONU>();

        public frmTeminatMektupKonulari()
        {
            InitializeComponent();
        }

        public void teminatMektupKonuGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_TEMINAT_MEKTUP_KONUProvider.GetAll();
            gridTeminatMektupKonulari.DataSource = MyDataSource;
        }

        public void teminatMektupKonuKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_TEMINAT_MEKTUP_KONUProvider.DeepSave(tran, MyDataSource);
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
            teminatMektupKonuKaydet();
        }
    }
}