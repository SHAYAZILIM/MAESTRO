using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmTakipYoluKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TI_KOD_TAKIP_YOLU> MyDataSource = new TList<TI_KOD_TAKIP_YOLU>();

        public frmTakipYoluKodlari()
        {
            InitializeComponent();
        }

        public void takipTalepKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TI_KOD_TAKIP_YOLUProvider.Save(tran, MyDataSource);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }

        public void takipYoluGetir()
        {
            MyDataSource = DataRepository.TI_KOD_TAKIP_YOLUProvider.GetAll();
            gridTakipYoluKodlari.DataSource = MyDataSource;
        }

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
            takipTalepKaydet();
        }
    }
}