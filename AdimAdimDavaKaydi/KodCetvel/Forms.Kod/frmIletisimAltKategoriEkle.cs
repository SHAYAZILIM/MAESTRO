using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmIletisimAltKategoriEkle : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_ILETISIM_ALT_KATEGORI> MyDataSourceIletAltKat = new TList<TDI_KOD_ILETISIM_ALT_KATEGORI>();

        public frmIletisimAltKategoriEkle()
        {
            InitializeComponent();
        }

        public void iletisimAltKodGetir()
        {
            MyDataSourceIletAltKat = DataRepository.TDI_KOD_ILETISIM_ALT_KATEGORIProvider.GetAll();
            gridIletisimAltKategori.DataSource = MyDataSourceIletAltKat;
            BelgeUtil.Inits.IletisimAnaKategoriGetir(rLueIletisimAnaKat);
        }

        private void iletisimAltKodKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_ILETISIM_ALT_KATEGORIProvider.Save(tran, MyDataSourceIletAltKat);
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
            iletisimAltKodKaydet();
        }
    }
}