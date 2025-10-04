using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmTakipTalepKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TI_KOD_TAKIP_TALEP> MyDataSource = new TList<TI_KOD_TAKIP_TALEP>();

        public frmTakipTalepKodlari()
        {
            InitializeComponent();
        }

        public void takipTalepKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("�lgili kay�tlarda yapt���n�z t�m de�i�iklikler kaydedilecektir" + Environment.NewLine + "Onayl�yormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TI_KOD_TAKIP_TALEPProvider.Save(tran, MyDataSource);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }

        public void takipTelepGetir()
        {
            MyDataSource = DataRepository.TI_KOD_TAKIP_TALEPProvider.GetAll();
            gridTakipTalepKodlari.DataSource = MyDataSource;
        }

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
            takipTalepKaydet();
        }
    }
}