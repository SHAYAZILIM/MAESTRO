using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmDavaGelismeKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TD_KOD_FOY_GELISME_ADIM> MyDataSourceGelismeAdim = new TList<TD_KOD_FOY_GELISME_ADIM>();

        public frmDavaGelismeKodlari()
        {
            InitializeComponent();
        }

        public void gelismeAdimGetir()
        {
            MyDataSourceGelismeAdim = AvukatProLib2.Data.DataRepository.TD_KOD_FOY_GELISME_ADIMProvider.GetAll();
            gridDavaGelismeKodlar.DataSource = MyDataSourceGelismeAdim;
        }

        public void gelismeAdimKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TD_KOD_FOY_GELISME_ADIMProvider.Save(tran, MyDataSourceGelismeAdim);
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
            gelismeAdimKaydet();
        }
    }
}