using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmIcraNispiHarcCetveliGuncelleme : DevExpress.XtraEditors.XtraForm
    {
        private TList<TI_CET_NISPI_HARC> MyDataSourceNispiHarcIcra = new TList<TI_CET_NISPI_HARC>();

        public frmIcraNispiHarcCetveliGuncelleme()
        {
            InitializeComponent();
            getNispiHarc(DateTime.Today);
        }

        public void nispiHarcGetirIcra(DateTime dt, bool result)
        {
            MyDataSourceNispiHarcIcra = AvukatProLib2.Data.DataRepository.TI_CET_NISPI_HARCProvider.GetAll();
            gridDavaNizpiHarcCetveli.DataSource = MyDataSourceNispiHarcIcra;

            //Inits.YuzdeBicimiAyarla(spYuzdeOran);
            BelgeUtil.Inits.IcraHarcTipiGetir(lueHarcKod);
            BelgeUtil.Inits.BindeYuzdeGetir(lueBindeYuzde);
        }

        public void nispiHarcKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TI_CET_NISPI_HARCProvider.Save(tran, getNispiHarcTablosu());
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

        private void getNispiHarc(DateTime dt)
        {
            DialogResult dr = XtraMessageBox.Show("En yakın tarihe ait icra nispi harç oranlarının kopyalanmasını ister misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool result = dr == DialogResult.Yes ? true : false;
            nispiHarcGetirIcra(dt, result);
        }

        private TList<TI_CET_NISPI_HARC> getNispiHarcTablosu()
        {
            TList<TI_CET_NISPI_HARC> nispiHarcTablosu = new TList<TI_CET_NISPI_HARC>();
            foreach (var item in MyDataSourceNispiHarcIcra)
            {
                if (item.ORAN != 0)
                {
                    nispiHarcTablosu.Add(item);
                }
            }
            return nispiHarcTablosu;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            nispiHarcKaydet();
        }
    }
}