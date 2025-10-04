using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmTopluDavaNispiHarcGuncelleme : DevExpress.XtraEditors.XtraForm
    {
        private TList<TD_CET_NISPI_HARC> MyDataSourceNispiHArc = new TList<TD_CET_NISPI_HARC>();

        public frmTopluDavaNispiHarcGuncelleme()
        {
            InitializeComponent();
            getNispiHarc(DateTime.Today);
        }

        private void getNispiHarc(DateTime dt)
        {
            DialogResult dr = XtraMessageBox.Show("En yakın tarihe ait dava nispi harç oranlarının kopyalanmasını ister misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool result = dr == DialogResult.Yes ? true : false;
            nispiHarcGetir(dt, result);
        }

        private TList<TD_CET_NISPI_HARC> getNispiHarcTablosu()
        {
            TList<TD_CET_NISPI_HARC> nispiHarcTablosu = new TList<TD_CET_NISPI_HARC>();
            foreach (var item in MyDataSourceNispiHArc)
            {
                if (item.ORAN != 0)
                {
                    nispiHarcTablosu.Add(item);
                }
            }
            return nispiHarcTablosu;
        }

        private void nispiHarcGetir(DateTime dt, bool result)
        {
            MyDataSourceNispiHArc = AvukatProLib2.Data.DataRepository.TD_CET_NISPI_HARCProvider.GetAll();
            gridDavaNizpiHarcCetveli.DataSource = MyDataSourceNispiHArc;
            BelgeUtil.Inits.DavaHarcTipiGetir(lueHarcKod);

            //Inits.YuzdeBicimiAyarla(spYuzdeOran);
            BelgeUtil.Inits.BindeYuzdeGetir(lueBindeYuzde);
        }

        private void nispiHarcKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TD_CET_NISPI_HARCProvider.Save(tran, getNispiHarcTablosu());
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if (ex is SqlException && ex.Message.ToLower().Contains("conflict"))
                    {
                        if (tran.IsOpen)
                            tran.Rollback();
                        MessageBox.Show("Kayıt'a bağlı bulunan kayıtlardan dolayı silme işlemi gerçekleştirilemiyor");

                        BelgeUtil.ErrorHandler.Catch(this, ex, false, BelgeUtil.Bilesen.Kayit);
                    }
                    else
                    {
                        if (tran.IsOpen)
                            tran.Rollback();
                        BelgeUtil.ErrorHandler.Catch(this, ex, true, BelgeUtil.Bilesen.Kayit);
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            nispiHarcKaydet();
        }
    }
}