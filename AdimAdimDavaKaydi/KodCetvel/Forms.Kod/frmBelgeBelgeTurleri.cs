using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmBelgeBelgeTurleri : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDIE_KOD_BELGE_TUR> MyDatasourceBelgeTur = new TList<TDIE_KOD_BELGE_TUR>();

        public frmBelgeBelgeTurleri()
        {
            InitializeComponent();
        }

        public void belgeTurleriGetir()
        {
            MyDatasourceBelgeTur = AvukatProLib2.Data.DataRepository.TDIE_KOD_BELGE_TURProvider.GetAll();
            gridBelgeTurleri.DataSource = MyDatasourceBelgeTur;
        }

        public void belgeTurleriKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDIE_KOD_BELGE_TURProvider.Save(tran, MyDatasourceBelgeTur);
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
            belgeTurleriKaydet();
        }
    }
}