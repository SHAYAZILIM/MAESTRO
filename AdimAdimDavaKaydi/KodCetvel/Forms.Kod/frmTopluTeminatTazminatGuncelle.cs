using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmTopluTeminatTazminatGuncelle : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_TEMINAT_TAZMINAT> MyDataSource = new TList<TDI_CET_TEMINAT_TAZMINAT>();

        public frmTopluTeminatTazminatGuncelle()
        {
            InitializeComponent();
            getTeminatTazminat(DateTime.Today);
        }

        private void getTeminatTazminat(DateTime dt)
        {
            DialogResult dr = XtraMessageBox.Show("En yakın tarihe ait teminat ve tazminat oranlarının kopyalanmasını ister misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool result = dr == DialogResult.Yes ? true : false;
            teminatTazminatGetir(dt, result);
        }

        private TList<TDI_CET_TEMINAT_TAZMINAT> getTeminatTazminatOran()
        {
            TList<TDI_CET_TEMINAT_TAZMINAT> Source = new TList<TDI_CET_TEMINAT_TAZMINAT>();
            foreach (var item in MyDataSource)
            {
                if (item.ORAN != 0)
                {
                    Source.Add(item);
                }
            }
            return Source;
        }

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
            teminatTazminatKaydet();
        }

        private void teminatTazminatGetir(DateTime dt, bool result)
        {
            TList<TDI_KOD_TEMINAT_TAZMINAT> listTeminatTazminat = new TList<TDI_KOD_TEMINAT_TAZMINAT>();
            TDI_CET_TEMINAT_TAZMINAT teminatTazminat = new TDI_CET_TEMINAT_TAZMINAT();
            listTeminatTazminat = DataRepository.TDI_KOD_TEMINAT_TAZMINATProvider.GetAll();
            if (result)
            {
                foreach (var item in listTeminatTazminat)
                {
                    teminatTazminat.KATEGORI_ID = item.ID;
                    teminatTazminat.TARIH = dt;
                    MyDataSource.Add(teminatTazminat);
                }
            }

            else
            {
                foreach (var item in listTeminatTazminat)
                {
                    teminatTazminat.TEMINAT_TAZMINAT_ADI = item.TEMINAT_TAZMINAT_ADI;
                    teminatTazminat.KATEGORI_ID = item.ID;
                    teminatTazminat.TARIH = dt;
                    MyDataSource.Add(teminatTazminat);
                }
            }

            gridTeminatTazminat.DataSource = MyDataSource;
            BelgeUtil.Inits.YuzdeBicimiAyarla(spOran);
            BelgeUtil.Inits.TemiznatTazminatKodGetir(lueKategori);
        }

        private void teminatTazminatKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_TEMINAT_TAZMINATProvider.DeepSave(tran, getTeminatTazminatOran());
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }
    }
}