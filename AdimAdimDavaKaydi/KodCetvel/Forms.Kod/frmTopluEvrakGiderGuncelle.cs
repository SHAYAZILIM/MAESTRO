using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmTopluEvrakGiderGuncelle : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_EVRAK_GIDER> MydataSourceEvrakGider = new TList<TDI_CET_EVRAK_GIDER>();

        public frmTopluEvrakGiderGuncelle()
        {
            InitializeComponent();
            getEvrakGider();
        }

        private void evrakGiderCetvelGetir(bool result)
        {
            DateTime maxDate = DateTime.Today;
            TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> muhasebeAltKategori = new TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>();
            TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI muhasebeAnaKategori = new TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI();
            TDI_CET_EVRAK_GIDER evrakGider;
            muhasebeAnaKategori = DataRepository.TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORIProvider.GetByANA_KATEGORI("EVRAK GİDERLERİ");
            muhasebeAltKategori = DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(muhasebeAnaKategori.ID);

            //MydataSourceEvrakGider = DataRepository.TDI_CET_EVRAK_GIDERProvider.GetAll();
            if (result)
            {
                foreach (var item in muhasebeAltKategori)
                {
                    evrakGider = DataRepository.TDI_CET_EVRAK_GIDERProvider.GetByALT_KATEGORI_IDBASLANGIC_TARIHI(item.ID, maxDate);
                    if (evrakGider == null)
                        evrakGider = new TDI_CET_EVRAK_GIDER();
                    evrakGider.BASLANGIC_TARIHI = DateTime.Today;
                    evrakGider.ALT_KATEGORI_ID = item.ID;
                    evrakGider.ALT_KATEGORI = item.ALT_KATEGORI;
                    MydataSourceEvrakGider.Add(evrakGider);
                }
            }
            else
            {
                foreach (var item in muhasebeAltKategori)
                {
                    evrakGider = new TDI_CET_EVRAK_GIDER();
                    evrakGider.BASLANGIC_TARIHI = DateTime.Today;
                    evrakGider.ALT_KATEGORI_ID = item.ID;
                    evrakGider.ALT_KATEGORI = item.ALT_KATEGORI;
                    MydataSourceEvrakGider.Add(evrakGider);
                }
            }
            gridEvrakGiderCetveli.DataSource = MydataSourceEvrakGider;
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.MuhasebeHareketAltKategoriAnakatGetir(rLueMuhasebeAltKategori);
        }

        private void evrakGiderCetvelKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_EVRAK_GIDERProvider.Save(tran, MydataSourceEvrakGider);
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

        private void getEvrakGider()
        {
            DialogResult dr = XtraMessageBox.Show("En yakın tarihe ait evrak giderlerinin kopyalanmasını ister misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool result = dr == DialogResult.Yes ? true : false;
            evrakGiderCetvelGetir(result);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            evrakGiderCetvelKaydet();
        }
    }
}