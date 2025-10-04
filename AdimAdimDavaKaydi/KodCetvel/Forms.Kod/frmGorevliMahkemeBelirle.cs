using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmGorevliMahkemeBelirle : DevExpress.XtraEditors.XtraForm
    {
        private TList<TD_CET_GOREVLI_MAHKEME_BELIRLE> MyDataSourceGorevliMah = new TList<TD_CET_GOREVLI_MAHKEME_BELIRLE>();

        public frmGorevliMahkemeBelirle()
        {
            InitializeComponent();
        }

        public void gorevliMahkemeBelirGetir()
        {
            MyDataSourceGorevliMah = DataRepository.TD_CET_GOREVLI_MAHKEME_BELIRLEProvider.GetAll();
            gridGorevliMahkemeBelirle.DataSource = MyDataSourceGorevliMah;
            BelgeUtil.Inits.DavaAdi(rLueDavaAd);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
        }

        private void gorevliMahBelirKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TD_CET_GOREVLI_MAHKEME_BELIRLEProvider.Save(tran, MyDataSourceGorevliMah);
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
            gorevliMahBelirKaydet();
        }
    }
}