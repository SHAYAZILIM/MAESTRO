using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmFaizKalem : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_FAIZ_KALEM> MyDataSourceFaizKalem = new TList<TDI_KOD_FAIZ_KALEM>();

        public frmFaizKalem()
        {
            InitializeComponent();
        }

        public void faizKalemGetir()
        {
            MyDataSourceFaizKalem = AvukatProLib2.Data.DataRepository.TDI_KOD_FAIZ_KALEMProvider.GetAll();
            gridFaziKalemleri.DataSource = MyDataSourceFaizKalem;
        }

        public void faizKalemKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_FAIZ_KALEMProvider.Save(tran, MyDataSourceFaizKalem);
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
            faizKalemKaydet();
        }

        //TDI_KOD_FAIZ_KALEM
        //internal void FaizKalemleri()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_KOD_FAIZ_KALEM.FaizKalemleri();
        //    //gridFaziKalemleri.DataSource = ds.Tables[0];
        //}
        //bool Yeni = false;
        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TDI_KOD_FAIZ_KALEM FaizKalemOBJ = new AvukatProLib.Entity.TDI_KOD_FAIZ_KALEM();
        //        FaizKalemOBJ.FAIZ_KALEMI = (e.Row as DataRowView)[1].ToString();
        //        FaizKalemOBJ.ADMIN_KAYIT_MI = 1;
        //        FaizKalemOBJ.KONTROL_KIM = "AVUKATPRO";
        //        FaizKalemOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        FaizKalemOBJ.KONTROL_VERSIYON = 1;
        //        FaizKalemOBJ.STAMP = 1;
        //        FaizKalemOBJ.SUBE_KODU = 1;

        //        AvukatProLib.Facade.TDI_KOD_FAIZ_KALEM.TDI_KOD_FAIZ_KALEMEkle(FaizKalemOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_KOD_FAIZ_KALEM FaizKalemOBJ = new AvukatProLib.Entity.TDI_KOD_FAIZ_KALEM();
        //        FaizKalemOBJ.FAIZ_KALEMI = (e.Row as DataRowView)[1].ToString();
        //        FaizKalemOBJ.ADMIN_KAYIT_MI = 1;
        //        FaizKalemOBJ.KONTROL_KIM = "AVUKATPRO";
        //        FaizKalemOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        FaizKalemOBJ.KONTROL_VERSIYON = 1;
        //        FaizKalemOBJ.STAMP = 1;
        //        FaizKalemOBJ.SUBE_KODU = 1;
        //        FaizKalemOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);

        //        AvukatProLib.Facade.TDI_KOD_FAIZ_KALEM.Guncelle(FaizKalemOBJ);
        //        MessageBox.Show("GÜNCELLEME ÝÞLEMÝ TAMAM");
        //    }
        //    Yeni = false;
        //}
        //int GuncelleSilID = 0;
        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    //SÝL
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_FAIZ_KALEM.TDI_KOD_FAIZ_KALEMSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        //private void gridFaziKalemleri_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_FAIZ_KALEM.TDI_KOD_FAIZ_KALEMSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
    }
}