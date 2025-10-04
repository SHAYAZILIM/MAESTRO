using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmMuhasebeAltKategoriEkle : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> MyDataSource = new TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>();

        public frmMuhasebeAltKategoriEkle()
        {
            InitializeComponent();
        }

        public void muhAltKatKodGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetAll();
            gridMuhasebeAltKategorileri.DataSource = MyDataSource;
        }

        public void muhAltKodKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.Save(tran, MyDataSource);
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
            muhAltKodKaydet();
        }
    }
}