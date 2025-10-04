using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmSablonEkle : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDIE_KOD_SABLON> MyDataSource = new TList<TDIE_KOD_SABLON>();

        public frmSablonEkle()
        {
            InitializeComponent();
        }

        public void sablokGetir()
        {
            MyDataSource = DataRepository.TDIE_KOD_SABLONProvider.GetAll();
            gridSablonEkle.DataSource = MyDataSource;
        }

        public void sablonKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("�lgili kay�tlarda yapt���n�z t�m de�i�iklikler kaydedilecektir" + Environment.NewLine + "Onayl�yormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDIE_KOD_SABLONProvider.Save(tran, MyDataSource);
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
            sablonKaydet();
        }
    }
}