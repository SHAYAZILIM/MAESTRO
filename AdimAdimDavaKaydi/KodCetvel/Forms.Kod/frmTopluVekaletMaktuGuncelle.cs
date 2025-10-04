using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmTopluVekaletMaktuGuncelle : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_MAKTU_VEKALET> MyDataSourceMaktuVekalet = new TList<TDI_CET_MAKTU_VEKALET>();

        int TLID = 1;

        public frmTopluVekaletMaktuGuncelle()
        {
            InitializeComponent();
            getVekaletMaktu(DateTime.Today);
        }

        public void vekaletMaktuGetir(DateTime dt, bool result)
        {
            TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> muhasebeAltKategori = new TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>();
            TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI muhasebeAnaKategori = new TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI();
            TDI_CET_MAKTU_VEKALET maktuVekalet;
            muhasebeAnaKategori = DataRepository.TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORIProvider.GetByANA_KATEGORI("TAKİP EDİLENİN ÖDEYECEĞİ VEKALET ÜCRETİ");
            muhasebeAltKategori = DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(muhasebeAnaKategori.ID);

            foreach (var item in muhasebeAltKategori)
            {
                maktuVekalet = new TDI_CET_MAKTU_VEKALET();

                //maktuVekalet= DataRepository.TDI_CET_MAKTU_VEKALETProvider.GetByMAKTU_KOD_IDBASLANGIC_TARIHI
                maktuVekalet.MAKTU_KOD_ACIKLAMA = item.ALT_KATEGORI;
                maktuVekalet.MAKTU_KOD_ID = item.ID;
                maktuVekalet.BASLANGIC_TARIHI = dt;
                maktuVekalet.MIKTAR1_DOVIZ_ID = TLID;
                maktuVekalet.MIKTAR2_DOVIZ_ID = TLID;
                maktuVekalet.OZEL_MIKTAR_DOVIZ_ID = TLID;

                MyDataSourceMaktuVekalet.Add(maktuVekalet);
            }

            //MyDataSourceMaktuVekalet = AvukatProLib2.Data.DataRepository.TDI_CET_MAKTU_VEKALETProvider.GetAll();
            gridVekaletMaktu.DataSource = MyDataSourceMaktuVekalet;
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.MuhasebeHareketAltKategoriAnakatGetir(lueMaktuKod);
        }

        public void vekaletMaktuKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_MAKTU_VEKALETProvider.DeepSave(tran, MyDataSourceMaktuVekalet);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }

        private void getVekaletMaktu(DateTime dt)
        {
            DialogResult dr = XtraMessageBox.Show("En yakın tarihe ait vekalet maktu oranlarının kopyalanmasını ister misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool result = dr == DialogResult.Yes ? true : false;
            vekaletMaktuGetir(dt, result);
        }

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
            vekaletMaktuKaydet();
        }

        private void frmTopluVekaletMaktuGuncelle_Load(object sender, EventArgs e)
        {
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            try
            {
                TLID = (int)cn.ExecuteScalar("SELECT isnull(ID,1) FROM dbo.TDI_KOD_DOVIZ_TIP(nolock) WHERE DOVIZ_KODU='TL'");
            }
            catch { ;}
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, "MIKTAR1_DOVIZ_ID", TLID);
            gridView1.SetRowCellValue(e.RowHandle, "MIKTAR2_DOVIZ_ID", TLID);
            gridView1.SetRowCellValue(e.RowHandle, "OZEL_MIKTAR_DOVIZ_ID", TLID);
        }
    }
}