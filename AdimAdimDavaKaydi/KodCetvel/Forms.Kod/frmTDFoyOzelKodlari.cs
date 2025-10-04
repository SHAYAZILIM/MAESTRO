using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmTDFoyOzelKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<AV001_TDI_KOD_FOY_OZEL> MyDataSource = new TList<AV001_TDI_KOD_FOY_OZEL>();

        public frmTDFoyOzelKodlari()
        {
            InitializeComponent();
        }

        public void foyOzelKodGetir()
        {
            MyDataSource = DataRepository.AV001_TDI_KOD_FOY_OZELProvider.GetAll();
            gridDosyaOzelKodlar.DataSource = MyDataSource;
        }

        public void foyOzelKodKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("�lgili kay�tlarda yapt���n�z t�m de�i�iklikler kaydedilecektir" + Environment.NewLine + "Onayl�yormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TDI_KOD_FOY_OZELProvider.Save(tran, MyDataSource);
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
            foyOzelKodKaydet();
        }
    }
}