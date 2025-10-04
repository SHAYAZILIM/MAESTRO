using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmYediEminUcretiNispi : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_YEDIEMIN_NISPI_UCRET> MyDataSourceYeddiNispiUcret = new TList<TDI_CET_YEDIEMIN_NISPI_UCRET>();

        public frmYediEminUcretiNispi()
        {
            InitializeComponent();
        }

        public void yeddiNispiDoldur()
        {
            MyDataSourceYeddiNispiUcret = AvukatProLib2.Data.DataRepository.TDI_CET_YEDIEMIN_NISPI_UCRETProvider.GetAll();
            gridNispiYeddiEmin.DataSource = MyDataSourceYeddiNispiUcret;
            BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
            BelgeUtil.Inits.ParaBicimiAyarla(spTutar);
            BelgeUtil.Inits.YuzdeBicimiAyarla(spOran);
        }

        public void yeddiNispiKaydet()
        {
            //TDI_CET_YEDIEMIN_NISPI_UCRET
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_YEDIEMIN_NISPI_UCRETProvider.Save(tran, MyDataSourceYeddiNispiUcret);
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
            yeddiNispiKaydet();
        }
    }
}