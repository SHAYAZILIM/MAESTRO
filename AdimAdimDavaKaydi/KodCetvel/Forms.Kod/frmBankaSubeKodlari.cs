using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmBankaSubeKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_BANKA_SUBE> MyDataSourceBankaSube = new TList<TDI_KOD_BANKA_SUBE>();

        private TList<TDI_KOD_BANKA_SUBE> MyDataSourceBankaSubeYeni = new TList<TDI_KOD_BANKA_SUBE>();

        public frmBankaSubeKodlari()
        {
            InitializeComponent();
        }

        public void bankaSubeGetir()
        {
            MyDataSourceBankaSube = AvukatProLib2.Data.DataRepository.TDI_KOD_BANKA_SUBEProvider.GetAll();
            MyDataSourceBankaSube.AddingNew += new AddingNewEventHandler(MyDataSourceBankaSube_AddingNew);
            gridBankaSubeKodlari.DataSource = MyDataSourceBankaSube;
            BelgeUtil.Inits.BankaBolgeGetir(rLueBolge);
            BelgeUtil.Inits.BankaGetir(rLueBanka);
        }

        public void bankaSubeKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_BANKA_SUBEProvider.DeepSave(tran, MyDataSourceBankaSubeYeni);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if (ex is SqlException && ex.Message.ToLower().Contains("conflict"))
                    {
                        if (tran.IsOpen)
                            tran.Rollback();
                        MessageBox.Show("Kayýt'a baðlý bulunan kayýtlardan dolayý silme iþlemi gerçekleþtirilemiyor");

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

        private void MyDataSourceBankaSube_AddingNew(object sender, AddingNewEventArgs e)
        {
            TDI_KOD_BANKA_SUBE sube = new TDI_KOD_BANKA_SUBE();
            sube.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            sube.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;
            e.NewObject = sube;
            MyDataSourceBankaSubeYeni.Add(sube);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bankaSubeKaydet();
        }
    }
}