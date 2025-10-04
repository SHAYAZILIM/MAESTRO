using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmTopluKDVGuncelle : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_KDV> kdvTList = new TList<TDI_CET_KDV>();

        public frmTopluKDVGuncelle()
        {
            InitializeComponent();
            getKDV(DateTime.Today);
        }

        private void dtpicker_ValueChanged(object sender, EventArgs e)
        {
            kdvGetir(dtpicker.Value, false);
        }

        private void getKDV(DateTime dt)
        {
            DialogResult dr = XtraMessageBox.Show("En yakın tarihe ait KDV'lerin kopyalanmasını ister misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool result = dr == DialogResult.Yes ? true : false;
            kdvGetir(dt, result);
        }

        private void kdvGetir(DateTime dt, bool result)
        {
            gridKDVCetveli.DataSource = null;
            gridKDVCetveli.DataBindings.Clear();
            kdvTList.Clear();
            TList<TDI_CET_KDV> gunlukKdv = new TList<TDI_CET_KDV>();
            TList<TDI_KOD_KDV> kdvTip = new TList<TDI_KOD_KDV>();
            kdvTip = DataRepository.TDI_KOD_KDVProvider.GetAll();
            if (result)
            {
                foreach (var item in kdvTip)
                {
                    gunlukKdv = DataRepository.TDI_CET_KDVProvider.GetBY_KategoriID_TarihtenBuyuk(item.ID, dt);
                    if (gunlukKdv.Count == 0)
                    {
                        gunlukKdv.AddNew();
                    }
                    gunlukKdv.AddNew();
                    gunlukKdv[0].TARIH = dt;
                    gunlukKdv[0].KDV_AD = item.AD;
                    gunlukKdv[0].KATEGORI_ID = item.ID;
                    kdvTList.Add(gunlukKdv[0]);
                }
            }
            else
            {
                int i = 0;
                foreach (var item in kdvTip)
                {
                    gunlukKdv.AddNew();
                    gunlukKdv[i].TARIH = dt;
                    gunlukKdv[i].KDV_AD = item.AD;
                    gunlukKdv[i].KATEGORI_ID = item.ID;
                    kdvTList.Add(gunlukKdv[i]);
                    i = i + 1;
                }
            }
            gridKDVCetveli.DataSource = kdvTList;
            BelgeUtil.Inits.KdvKodGetir(rLueKategori);
            BelgeUtil.Inits.YuzdeBicimiAyarla(spOran);
        }

        private void KDVKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_KDVProvider.Save(tran, kdvTList);
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
            KDVKaydet();
        }
    }
}