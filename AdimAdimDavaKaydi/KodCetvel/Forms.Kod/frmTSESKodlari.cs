using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmTSESKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_TEMSIL_SONA_ERME_SEBEP> MyDataSource = new TList<TDI_KOD_TEMSIL_SONA_ERME_SEBEP>();

        public frmTSESKodlari()
        {
            InitializeComponent();
        }

        public void temsilSonaErmeSebebGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_TEMSIL_SONA_ERME_SEBEPProvider.GetAll();
            gridTemsilSonaErmeSebeb.DataSource = MyDataSource;
        }

        public void temsilSonaErmeSebebKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("�lgili kay�tlarda yapt���n�z t�m de�i�iklikler kaydedilecektir" + Environment.NewLine + "Onayl�yormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_TEMSIL_SONA_ERME_SEBEPProvider.Save(tran, MyDataSource);
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
            temsilSonaErmeSebebKaydet();
        }
    }
}