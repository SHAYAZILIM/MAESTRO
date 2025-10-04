using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmUnvanKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_UNVAN> MyDataSource = new TList<TDI_KOD_UNVAN>();

        public frmUnvanKodlari()
        {
            InitializeComponent();
        }

        public void unvanKodGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_UNVANProvider.GetAll();
            gridUnvanKodlar.DataSource = MyDataSource;
        }

        public void unvanKodKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("�lgili kay�tlarda yapt���n�z t�m de�i�iklikler kaydedilecektir" + Environment.NewLine + "Onayl�yormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_UNVANProvider.Save(tran, MyDataSource);
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
            unvanKodKaydet();
        }
    }
}