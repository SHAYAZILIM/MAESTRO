using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmBankaAdlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_BANKA> MyDataSource = new TList<TDI_KOD_BANKA>();

        public frmBankaAdlari()
        {
            InitializeComponent();
        }

        public void BankaGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_BANKAProvider.GetAll();
            gridBankaAdlari.DataSource = MyDataSource;
        }

        public void BankaKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_BANKAProvider.Save(tran, MyDataSource);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }

        private void frmBankaAdlari_Load(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            BankaKaydet();
        }

        //TDI_KOD_BANKA
        //DataTable dtBankaAdlari = null;
        //internal void BankaAdlariSabitleri()
        //{
        //    TList<TDI_KOD_BANKA> MyataSourceBanka = new TList<TDI_KOD_BANKA>();
        //    MyataSourceBanka = AvukatProLib2.Data.DataRepository.TDI_KOD_BANKAProvider.GetAll();
        //    gridBankaAdlari.DataSource = MyataSourceBanka;

        //    //DataSet ds = AvukatProLib.Facade.TDI_KOD_BANKA.BankaAdlariSabitler();
        //    //gridBankaAdlari.DataSource = ds.Tables[0];

        //    //dtBankaAdlari = AvukatProLib.Facade.TDI_KOD_BANKA.TDI_KOD_BANKAGetir();

        //}
        //bool Yeni = false;
        ////int indDeger = 0;
        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        YeniBankaKodEkle(e);
        //    }
        //    else
        //    {
        //        //GUNCELLE
        //        AvukatProLib.Entity.TDI_KOD_BANKA BankaAdlariOBJ = new AvukatProLib.Entity.TDI_KOD_BANKA();
        //        BankaAdlariOBJ.BANKA = (e.Row as DataRowView)[1].ToString();
        //        BankaAdlariOBJ.ADMIN_KAYIT_MI = 1;
        //        BankaAdlariOBJ.KONTROL_KIM = "AVUKATPRO";
        //        BankaAdlariOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        BankaAdlariOBJ.KONTROL_VERSIYON = 1;
        //        BankaAdlariOBJ.STAMP = 1;
        //        BankaAdlariOBJ.SUBE_KODU = 1;
        //        BankaAdlariOBJ.ID=Convert.ToInt32((e.Row as DataRowView)[0].ToString());

        //        AvukatProLib.Facade.TDI_KOD_BANKA.Guncelle(BankaAdlariOBJ);

        //        MessageBox.Show("GÜNCELLEME ÝÞLEMÝ TAMAM");
        //    }

        //    Yeni = false;

        //}

        //private static void YeniBankaKodEkle(DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    BankaKaydet(e);
        //}

        //private static void BankaKaydet(DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    AvukatProLib.Entity.TDI_KOD_BANKA BankaAdlariOBJ = new AvukatProLib.Entity.TDI_KOD_BANKA();
        //    BankaAdlariOBJ.BANKA = (e.Row as DataRowView)[1].ToString();
        //    BankaAdlariOBJ.ADMIN_KAYIT_MI = 1;
        //    BankaAdlariOBJ.KONTROL_KIM = "AVUKATPRO";
        //    BankaAdlariOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //    BankaAdlariOBJ.KONTROL_VERSIYON = 1;
        //    BankaAdlariOBJ.STAMP = 1;
        //    BankaAdlariOBJ.SUBE_KODU = 1;

        //    AvukatProLib.Facade.TDI_KOD_BANKA.TDI_KOD_BANKAEkle(BankaAdlariOBJ);

        //    MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");
        //}
        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;

        //}
        //int GuncelleSilID = 0;
        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_BANKA.TDI_KOD_BANKASil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}

        //private void gridBankaAdlari_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_BANKA.TDI_KOD_BANKASil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}

        //string IsimBul(string kod, DataTable dtKaynak, out int Id)
        //{
        //    DataRow[] satirlar = dtKaynak.Select("DOVIZ_KODU='" + kod + "'");
        //    Id = Convert.ToInt32(satirlar[0]["ID"]);
        //    return satirlar[0]["AD"].ToString();
        //}
    }
}