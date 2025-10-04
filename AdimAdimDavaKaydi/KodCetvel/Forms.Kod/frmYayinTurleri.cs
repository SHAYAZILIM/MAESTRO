using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmYayinTurleri : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_YAYIN_TURLERI> MyDataSource = new TList<TDI_KOD_YAYIN_TURLERI>();

        public frmYayinTurleri()
        {
            InitializeComponent();
        }

        //int GuncelleSilID = 0;
        //bool Yeni = false;

        //internal void YayinTurleri()
        //{
        //    TList<TDI_KOD_YAYIN_TURLERI> MyDatraSourceYayinTurleri = new TList<TDI_KOD_YAYIN_TURLERI>();
        //    MyDatraSourceYayinTurleri = AvukatProLib2.Data.DataRepository.TDI_KOD_YAYIN_TURLERIProvider.GetAll();
        //    gridYayinTurleri.DataSource = MyDatraSourceYayinTurleri;
        //    //DataSet ds = AvukatProLib.Facade.TDI_KOD_YAYIN_TURLERI.YayinTurleri();
        //    //gridYayinTurleri.DataSource = ds.Tables[0];
        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TDI_KOD_YAYIN_TURLERI YayinTurleriOBJ = new AvukatProLib.Entity.TDI_KOD_YAYIN_TURLERI();
        //        YayinTurleriOBJ.YAYIN_TURU = (e.Row as DataRowView)[1].ToString();
        //        YayinTurleriOBJ.ADMIN_KAYIT_MI = 1;
        //        YayinTurleriOBJ.KONTROL_KIM = "AVUKATPRO";
        //        YayinTurleriOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        YayinTurleriOBJ.KONTROL_VERSIYON = 1;
        //        YayinTurleriOBJ.STAMP = 1;
        //        YayinTurleriOBJ.SUBE_KODU = 1;
        //        AvukatProLib.Facade.TDI_KOD_YAYIN_TURLERI.TDI_KOD_YAYIN_TURLERIEkle(YayinTurleriOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_KOD_YAYIN_TURLERI YayinTurleriOBJ = new AvukatProLib.Entity.TDI_KOD_YAYIN_TURLERI();
        //        YayinTurleriOBJ.YAYIN_TURU = (e.Row as DataRowView)[1].ToString();
        //        YayinTurleriOBJ.ADMIN_KAYIT_MI = 1;
        //        YayinTurleriOBJ.KONTROL_KIM = "AVUKATPRO";
        //        YayinTurleriOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        YayinTurleriOBJ.KONTROL_VERSIYON = 1;
        //        YayinTurleriOBJ.STAMP = 1;
        //        YayinTurleriOBJ.SUBE_KODU = 1;
        //        YayinTurleriOBJ.ID=Convert.ToInt32((e.Row as DataRowView)[0]);
        //        AvukatProLib.Facade.TDI_KOD_YAYIN_TURLERI.Guncelle(YayinTurleriOBJ);
        //        MessageBox.Show("GÜNCELLEME ÝÞLEMÝ TAMAM");
        //    }

        //    Yeni = false;
        //}

        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    //SÝL
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_YAYIN_TURLERI.TDI_KOD_YAYIN_TURLERISil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        //private void gridYayinTurleri_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_YAYIN_TURLERI.TDI_KOD_YAYIN_TURLERISil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
        public void yayinTurlertiGetir()
        {
            MyDataSource = DataRepository.TDI_KOD_YAYIN_TURLERIProvider.GetAll();
            gridYayinTurleri.DataSource = MyDataSource;
        }

        public void yayuinTurleriKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_YAYIN_TURLERIProvider.Save(tran, MyDataSource);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
            yayuinTurleriKaydet();
        }
    }
}