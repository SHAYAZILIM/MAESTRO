using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmCinsiyetKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_CINSIYET> MyDataSourceCinsiyet = new TList<TDI_KOD_CINSIYET>();

        public frmCinsiyetKodlari()
        {
            InitializeComponent();
        }

        public void cinsiyetKodGetir()
        {
            MyDataSourceCinsiyet = AvukatProLib2.Data.DataRepository.TDI_KOD_CINSIYETProvider.GetAll();
            gridCinsiyetKodlar.DataSource = MyDataSourceCinsiyet;
        }

        public void cinsiyetKodKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_CINSIYETProvider.Save(tran, MyDataSourceCinsiyet);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if (ex is SqlException && ex.Message.ToLower().Contains("conflict"))
                    {
                        if (tran.IsOpen)
                            tran.Rollback();
                        MessageBox.Show("Kayýt'a baðlý bulunan kayýtlardan dolayý silme iþlemi gerçekleþtirilemiyor");

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
            cinsiyetKodKaydet();
        }

        //internal void CinsiyetKodlar()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_KOD_CINSIYET.CinsiyetKodlari();
        //    //gridCinsiyetKodlar.DataSource = ds.Tables[0];
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        //EKLE
        //        AvukatProLib.Entity.TDI_KOD_CINSIYET CinsiyetKodlarOBJ = new AvukatProLib.Entity.TDI_KOD_CINSIYET();
        //        CinsiyetKodlarOBJ.CINSIYET = (e.Row as DataRowView)[1].ToString();
        //        CinsiyetKodlarOBJ.ADMIN_KAYIT_MI = 1;
        //        CinsiyetKodlarOBJ.KONTROL_KIM = "AVUKATPRO";
        //        CinsiyetKodlarOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        CinsiyetKodlarOBJ.KONTROL_VERSIYON = 1;
        //        CinsiyetKodlarOBJ.STAMP = 1;
        //        CinsiyetKodlarOBJ.SUBE_KODU = 1;
        //        CinsiyetKodlarOBJ.KOD = (e.Row as DataRowView)[2].ToString();

        //        AvukatProLib.Facade.TDI_KOD_CINSIYET.TDI_KOD_CINSIYETEkle(CinsiyetKodlarOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM" + "  " + (e.Row as DataRowView)[2].ToString());
        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_KOD_CINSIYET CinsiyetKodlarOBJ = new AvukatProLib.Entity.TDI_KOD_CINSIYET();
        //        CinsiyetKodlarOBJ.CINSIYET = (e.Row as DataRowView)[1].ToString();
        //        CinsiyetKodlarOBJ.ADMIN_KAYIT_MI = 1;
        //        CinsiyetKodlarOBJ.KONTROL_KIM = "AVUKATPRO";
        //        CinsiyetKodlarOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        CinsiyetKodlarOBJ.KONTROL_VERSIYON = 1;
        //        CinsiyetKodlarOBJ.STAMP = 1;
        //        CinsiyetKodlarOBJ.SUBE_KODU = 1;
        //        CinsiyetKodlarOBJ.KOD = (e.Row as DataRowView)[2].ToString();
        //        CinsiyetKodlarOBJ.ID=Convert.ToInt32((e.Row as DataRowView)[0].ToString());

        //        AvukatProLib.Facade.TDI_KOD_CINSIYET.Guncelle(CinsiyetKodlarOBJ);
        //        MessageBox.Show("GÜNCELLEME ÝÞLEMÝ TAMAM");
        //    }
        //    Yeni = false;

        //}
        //bool Yeni = false;
        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;

        //}
        //int GuncelleSilID = 0;
        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    //SÝL
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_CINSIYET.TDI_KOD_CINSIYETSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}

        //private void gridCinsiyetKodlar_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_CINSIYET.TDI_KOD_CINSIYETSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
    }
}