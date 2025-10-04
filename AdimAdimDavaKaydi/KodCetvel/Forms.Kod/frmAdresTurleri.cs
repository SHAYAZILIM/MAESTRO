using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmAdresTurleri : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_ADRES_TUR> MyDataSource = new TList<TDI_KOD_ADRES_TUR>();

        public frmAdresTurleri()
        {
            InitializeComponent();
        }

        //internal void AdresTurleri()
        //{
        //    TList<TDI_KOD_ADRES_TUR> MyDataSourceAdresTur=new TList<TDI_KOD_ADRES_TUR>();
        //    MyDataSourceAdresTur = AvukatProLib2.Data.DataRepository.TDI_KOD_ADRES_TURProvider.GetAll();
        //    gridAdresTurleri.DataSource = MyDataSourceAdresTur;

        //    //DataSet ds = AvukatProLib.Facade.TDI_KOD_ADRES_TUR.AdresTurleri();
        //    //gridAdresTurleri.DataSource = ds.Tables[0];
        //}
        //bool Yeni = false;

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        //EKLE
        //        AvukatProLib.Entity.TDI_KOD_ADRES_TUR AdresTurleriOBJ = new AvukatProLib.Entity.TDI_KOD_ADRES_TUR();
        //        AdresTurleriOBJ.ADRES_TUR = (e.Row as DataRowView)[1].ToString();
        //        AdresTurleriOBJ.ADMIN_KAYIT_MI = 1;
        //        AdresTurleriOBJ.KONTROL_KIM = "AVUKATPRO";
        //        AdresTurleriOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        AdresTurleriOBJ.KONTROL_VERSIYON = 1;
        //        AdresTurleriOBJ.STAMP = 1;
        //        AdresTurleriOBJ.SUBE_KODU = 1;
        //        AdresTurleriOBJ.UYAP_ACIKLAMA = (e.Row as DataRowView)[3].ToString();
        //        AdresTurleriOBJ.UYAP_KOD = (e.Row as DataRowView)[2].ToString();

        //        AvukatProLib.Facade.TDI_KOD_ADRES_TUR.TDI_KOD_ADRES_TUREkle(AdresTurleriOBJ);
        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_KOD_ADRES_TUR AdresTurleriOBJ = new AvukatProLib.Entity.TDI_KOD_ADRES_TUR();
        //        AdresTurleriOBJ.ADRES_TUR = (e.Row as DataRowView)[1].ToString();
        //        AdresTurleriOBJ.ADMIN_KAYIT_MI = 1;
        //        AdresTurleriOBJ.KONTROL_KIM = "AVUKATPRO";
        //        AdresTurleriOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        AdresTurleriOBJ.KONTROL_VERSIYON = 1;
        //        AdresTurleriOBJ.STAMP = 1;
        //        AdresTurleriOBJ.SUBE_KODU = 1;
        //        AdresTurleriOBJ.UYAP_ACIKLAMA = (e.Row as DataRowView)[3].ToString();
        //        AdresTurleriOBJ.UYAP_KOD = (e.Row as DataRowView)[2].ToString();
        //        AdresTurleriOBJ.ID=Convert.ToInt32((e.Row as DataRowView)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_ADRES_TUR.Guncelle(AdresTurleriOBJ);
        //    }
        //    Yeni = false;

        //}
        //int GuncelSilID = 0;
        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    //SÝLME ÝÇÝN ID AL
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelSilID = Convert.ToInt32((object) gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_ADRES_TUR.TDI_KOD_ADRES_TURSil(GuncelSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    //
        //    Yeni = true;
        //}

        //private void gridAdresTurleri_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    //SÝLME ÝÇÝN ID AL
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelSilID = Convert.ToInt32((object) gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_ADRES_TUR.TDI_KOD_ADRES_TURSil(GuncelSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
        public void AdresTurleriDoldur()
        {
            MyDataSource = DataRepository.TDI_KOD_ADRES_TURProvider.GetAll();
            gridAdresTurleri.DataSource = MyDataSource;
        }

        public void AdresTurleriKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_ADRES_TURProvider.Save(tran, MyDataSource);
                    tran.Commit();

                    //XtraMessageBox.Show("Adres Türleri Kaydedilmiþtir...");
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AdresTurleriKaydet();
        }
    }
}