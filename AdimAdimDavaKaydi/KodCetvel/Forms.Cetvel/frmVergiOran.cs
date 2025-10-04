using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Cetvel
{
    public partial class frmVergiOran : Form
    {
        private TList<TI_CET_VERGI_ORAN> MyDataSourceFoyBirim = new TList<TI_CET_VERGI_ORAN>();

        public frmVergiOran()
        {
            InitializeComponent();
        }

        public void foyYeriDoldur()
        {
            MyDataSourceFoyBirim = AvukatProLib2.Data.DataRepository.TI_CET_VERGI_ORANProvider.GetAll();
            gridDosyaYerleri.DataSource = MyDataSourceFoyBirim;
            BelgeUtil.Inits.DigerVergiVergiTuruGetir(rlueVergiKodu);
            BelgeUtil.Inits.YuzdeBicimiAyarla(spTarifeOran);
        }

        public void foyYeriKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TI_CET_VERGI_ORANProvider.Save(tran, MyDataSourceFoyBirim);
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
            foyYeriKaydet();
        }
    }
}