using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmGrupBilgileri : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_KULLANICI_GRUP> MyDataSourceKullanici = new TList<TDI_KOD_KULLANICI_GRUP>();

        public frmGrupBilgileri()
        {
            InitializeComponent();
        }

        public void kullaniciGrupGetir()
        {
            MyDataSourceKullanici = AvukatProLib2.Data.DataRepository.TDI_KOD_KULLANICI_GRUPProvider.GetAll();
            gridKullaniciGrup.DataSource = MyDataSourceKullanici;
        }

        public void kullaniciGrupKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_KULLANICI_GRUPProvider.Save(tran, MyDataSourceKullanici);
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            kullaniciGrupKaydet();
        }
    }
}