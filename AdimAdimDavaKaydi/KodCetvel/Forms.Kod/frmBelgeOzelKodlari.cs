using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmBelgeOzelKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<AV001_TDI_KOD_BELGE_OZEL_KOD> MyDataSourceBelgeOzelKod = new TList<AV001_TDI_KOD_BELGE_OZEL_KOD>();

        public frmBelgeOzelKodlari()
        {
            InitializeComponent();
        }

        public void belgeOzelKodGetir()
        {
            MyDataSourceBelgeOzelKod = AvukatProLib2.Data.DataRepository.AV001_TDI_KOD_BELGE_OZEL_KODProvider.GetAll();
            gridBelgeOzelKodlari.DataSource = MyDataSourceBelgeOzelKod;
        }

        public void belgeOzelKodKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TDI_KOD_BELGE_OZEL_KODProvider.Save(tran, MyDataSourceBelgeOzelKod);
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
            belgeOzelKodKaydet();
        }
    }
}