using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmSozlesmeTip : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_SOZLESME_TIP> MyDataSource = new TList<TDI_KOD_SOZLESME_TIP>();

        public frmSozlesmeTip()
        {
            InitializeComponent();
        }

        public void sozlesmeTipGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_SOZLESME_TIPProvider.GetAll();
            gridSozlesmeTipleri.DataSource = MyDataSource;
        }

        public void sozlesmeTipKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_SOZLESME_TIPProvider.Save(tran, MyDataSource);
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
            sozlesmeTipKaydet();
        }
    }
}