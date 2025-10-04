using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmTebligatPostaTipi : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> MydataSource = new TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>();

        public frmTebligatPostaTipi()
        {
            InitializeComponent();
        }

        public void postaTipGetir()
        {
            MydataSource = DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetAll();
            gridTebligatPostaTipleri.DataSource = MydataSource;
        }

        public void postaTipKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.DeepSave(tran, MydataSource);
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
            postaTipKaydet();
        }
    }
}