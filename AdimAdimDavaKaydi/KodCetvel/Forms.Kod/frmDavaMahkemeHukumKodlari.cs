using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmDavaMahkemeHukumKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TD_KOD_MAHKEME_HUKUM> MyDataSourceMahkemeHukum = new TList<TD_KOD_MAHKEME_HUKUM>();

        public frmDavaMahkemeHukumKodlari()
        {
            InitializeComponent();
        }

        public void mahkemeHukukKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TD_KOD_MAHKEME_HUKUMProvider.Save(tran, MyDataSourceMahkemeHukum);
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

        public void mahkemeHukumGetir()
        {
            MyDataSourceMahkemeHukum = AvukatProLib2.Data.DataRepository.TD_KOD_MAHKEME_HUKUMProvider.GetAll();
            gridDavaMahkemeHukumleri.DataSource = MyDataSourceMahkemeHukum;
            BelgeUtil.Inits.AdliBirimBolumGetir(rLueAdliBirimBolum);
            BelgeUtil.Inits.MahkemeHukumTipGetir(rLueMahkemeTip);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            mahkemeHukukKaydet();
        }
    }
}