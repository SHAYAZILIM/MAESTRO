using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmOtomatikMuhasebeKalemleri : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_BIL_FORM_MUHASEBE_KALEM> MyDataSource = new TList<TDI_BIL_FORM_MUHASEBE_KALEM>();

        public frmOtomatikMuhasebeKalemleri()
        {
            InitializeComponent();
        }

        public void muhasebeKalemGetir()
        {
            MyDataSource = DataRepository.TDI_BIL_FORM_MUHASEBE_KALEMProvider.GetAll();
            gridMuhasebeKalem.DataSource = MyDataSource;
        }

        public void muhasebeKalemKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_BIL_FORM_MUHASEBE_KALEMProvider.DeepSave(tran, MyDataSource);
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
            muhasebeKalemKaydet();
        }
    }
}