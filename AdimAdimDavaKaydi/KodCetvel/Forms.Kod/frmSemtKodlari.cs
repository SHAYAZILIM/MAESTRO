using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmSemtKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_SEMT> MyDataSource = new TList<TDI_KOD_SEMT>();

        public frmSemtKodlari()
        {
            InitializeComponent();
        }

        public void semtKodGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_SEMTProvider.GetAll();
            gridSemtKodlar.DataSource = MyDataSource;
            BelgeUtil.Inits.IlceGetirTumu(rLueIlce);
        }

        public void semtKodKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_SEMTProvider.Save(tran, MyDataSource);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if (ex is SqlException && ex.Message.ToLower().Contains("conflict"))
                    {
                        if (tran.IsOpen)
                            tran.Rollback();
                        MessageBox.Show("Kayıt'a bağlı bulunan kayıtlardan dolayı silme işlemi gerçekleştirilemiyor");

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
            semtKodKaydet();
        }
    }
}