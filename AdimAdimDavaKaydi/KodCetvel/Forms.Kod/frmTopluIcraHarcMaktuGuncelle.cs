using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmTopluIcraHarcMaktuGuncelle : DevExpress.XtraEditors.XtraForm
    {
        private TList<TI_CET_HARC_MAKTU> MyDataSourceHarcMaktuIcra = new TList<TI_CET_HARC_MAKTU>();

        public frmTopluIcraHarcMaktuGuncelle()
        {
            InitializeComponent();
            getHarcMaktu(DateTime.Today);
        }

        public void getHarcMaktu(DateTime dt)
        {
            DialogResult dr = XtraMessageBox.Show("En yakın tarihe ait icra harç maktu değerlerinin kopyalanmasını ister misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool result = dr == DialogResult.Yes ? true : false;
            maktuIcraHarcGetir(dt, result);
        }

        public void maktuHarcKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TI_CET_HARC_MAKTUProvider.Save(tran, getIcraHarcMaktu());
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

        public void maktuIcraHarcGetir(DateTime dt, bool result)
        {
            TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> muhasebeAltKategori = new TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>();
            muhasebeAltKategori = DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetAll();
            TI_CET_HARC_MAKTU icraHarcMaktu;

            //MyDataSourceHarcMaktuIcra = AvukatProLib2.Data.DataRepository.TI_CET_HARC_MAKTUProvider.GetAll();
            foreach (var item in muhasebeAltKategori)
            {
                icraHarcMaktu = new TI_CET_HARC_MAKTU();
                icraHarcMaktu.HARC_KOD_ACIKLAMA = item.ALT_KATEGORI;
                icraHarcMaktu.HARC_KOD_ID = item.ID;
                icraHarcMaktu.TARIH = dt;

                //icraHarcMaktu.DOVIZ=;
                //icraHarcMaktu.DOVIZ_ID=;
                MyDataSourceHarcMaktuIcra.Add(icraHarcMaktu);
            }
            gridDavaMaktuHarc.DataSource = MyDataSourceHarcMaktuIcra;
            BelgeUtil.Inits.MuhasebeHareketAltKategoriAnakatGetir(lueHarcKod);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.ParaBicimiAyarla(repositoryItemSpinEdit1);
        }

        private TList<TI_CET_HARC_MAKTU> getIcraHarcMaktu()
        {
            TList<TI_CET_HARC_MAKTU> Source = new TList<TI_CET_HARC_MAKTU>();
            foreach (var item in MyDataSourceHarcMaktuIcra)
            {
                if (item.DEGER != 0)
                {
                    Source.Add(item);
                }
            }
            return Source;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            maktuHarcKaydet();
        }
    }
}