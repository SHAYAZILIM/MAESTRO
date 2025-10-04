using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmFoyOzelDurumKodlari : AvpXtraForm
    {
        private TList<TDI_KOD_FOY_OZEL_DURUM> MyDataSourceFoyOzelDurum = new TList<TDI_KOD_FOY_OZEL_DURUM>();

        public frmFoyOzelDurumKodlari()
        {
            InitializeComponent();
        }

        public void foyOzelDurumGetir()
        {
            MyDataSourceFoyOzelDurum = AvukatProLib2.Data.DataRepository.TDI_KOD_FOY_OZEL_DURUMProvider.GetAll();
            gridDosyaOzelDurumKodlar.DataSource = MyDataSourceFoyOzelDurum;
            BelgeUtil.Inits.FoyBirimGetir(rLueFoyBirim);
        }

        public void foyOzelDurumKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_FOY_OZEL_DURUMProvider.Save(tran, MyDataSourceFoyOzelDurum);
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            foyOzelDurumKaydet();
        }
    }
}