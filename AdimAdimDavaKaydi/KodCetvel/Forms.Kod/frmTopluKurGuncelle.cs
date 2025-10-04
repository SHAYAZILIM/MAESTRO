using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmTopluKurGuncelle : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_GUNLUK_DOVIZ_KUR> mySource = new TList<TDI_CET_GUNLUK_DOVIZ_KUR>();

        public frmTopluKurGuncelle()
        {
            InitializeComponent();
            getDovizKurlari(DateTime.Today);
        }

        public void getDovizKurlari(DateTime dt)
        {
            DialogResult dr = XtraMessageBox.Show("En yakın tarihe ait kurların kopyalanmasını ister misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool result = dr == DialogResult.Yes ? true : false;
            gunlukDovizGetir(dt, result);
        }

        private void dtpicker_ValueChanged(object sender, EventArgs e)
        {
            gunlukDovizGetir(dtpicker.Value, false);
        }

        private TList<TDI_CET_GUNLUK_DOVIZ_KUR> getDovizTablosu()
        {
            TList<TDI_CET_GUNLUK_DOVIZ_KUR> Source = new TList<TDI_CET_GUNLUK_DOVIZ_KUR>();
            foreach (var item in mySource)
            {
                if (item.TL_DEGERI != 0)
                {
                    Source.Add(item);
                }
            }
            return Source;
        }

        private void gunlukDovizGetir(DateTime dt, bool result)
        {
            gridDovizKurlari.DataSource = null;
            gridDovizKurlari.DataBindings.Clear();
            mySource.Clear();
            TList<TDI_CET_GUNLUK_DOVIZ_KUR> gunlukDovizKur = new TList<TDI_CET_GUNLUK_DOVIZ_KUR>();
            TList<TDI_KOD_DOVIZ_TIP> DovizTipGetir = new TList<TDI_KOD_DOVIZ_TIP>();
            DovizTipGetir = DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetAll();
            if (result)
            {
                foreach (var item in DovizTipGetir)
                {
                    gunlukDovizKur = DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.GetByDOVIZ_ID(item.ID);
                    if (gunlukDovizKur.Count == 0)
                    {
                        gunlukDovizKur.AddNew();
                    }
                    gunlukDovizKur.AddNew();
                    gunlukDovizKur[0].TARIH = dt;
                    gunlukDovizKur[0].DOVIZ = item.DOVIZ_KODU;
                    gunlukDovizKur[0].DOVIZ_ID = item.ID;
                    mySource.Add(gunlukDovizKur[0]);
                }
            }
            else
            {
                int i = 0;
                foreach (var item in DovizTipGetir)
                {
                    gunlukDovizKur.AddNew();
                    gunlukDovizKur[i].TARIH = dt;
                    gunlukDovizKur[i].DOVIZ = item.DOVIZ_KODU;
                    gunlukDovizKur[i].DOVIZ_ID = item.ID;
                    mySource.Add(gunlukDovizKur[i]);
                    i = i + 1;
                }
            }
            gridDovizKurlari.DataSource = mySource;
            Inits.DovizTipGetir(rLueDoviz);
            Inits.ParaBicimiAyarla(spTutar);
        }

        private void gunlukDovizKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.Save(tran, getDovizTablosu());
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

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
            gunlukDovizKaydet();
        }
    }
}