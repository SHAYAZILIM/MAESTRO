using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmTeminatMektupDurum : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_TEMINAT_MEKTUP_DURUM> MyDataSource = new TList<TDI_KOD_TEMINAT_MEKTUP_DURUM>();

        public frmTeminatMektupDurum()
        {
            InitializeComponent();
        }

        public void teminatMektupDurumGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_TEMINAT_MEKTUP_DURUMProvider.GetAll();
            gridTeminatMektupDurumlari.DataSource = MyDataSource;
        }

        public void teminatMektupDurumKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("�lgili kay�tlarda yapt���n�z t�m de�i�iklikler kaydedilecektir" + Environment.NewLine + "Onayl�yormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_TEMINAT_MEKTUP_DURUMProvider.DeepSave(tran, MyDataSource);
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
            teminatMektupDurumKaydet();
        }
    }
}