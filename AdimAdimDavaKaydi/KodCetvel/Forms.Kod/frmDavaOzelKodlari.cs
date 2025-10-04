using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmDavaOzelKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_DAVA_OZEL_KOD> MyDataSourceDavaOzelKod = new TList<TDI_KOD_DAVA_OZEL_KOD>();

        public frmDavaOzelKodlari()
        {
            InitializeComponent();
        }

        public void davaOzelGetir()
        {
            MyDataSourceDavaOzelKod = AvukatProLib2.Data.DataRepository.TDI_KOD_DAVA_OZEL_KODProvider.GetAll();
            gridDavaOzelKodlar.DataSource = MyDataSourceDavaOzelKod;
        }

        public void davaOzelKodKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_DAVA_OZEL_KODProvider.Save(tran, MyDataSourceDavaOzelKod);
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
            davaOzelKodKaydet();
        }

        //internal void DavaOzelKodlar()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_KOD_DAVA_OZEL_KOD.DavaOzelKod();
        //    //gridDavaOzelKodlar.DataSource = ds.Tables[0];
        //}
        //bool Yeni = false;
        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    //ekle guncelle
        //    if (Yeni == true)
        //    {
        //        //MessageBox.Show("INSERT");
        //        OzelKodEkle(e);
        //    }
        //    else
        //    {
        //        //MessageBox.Show("UPDATE");
        //        OzelKodGuncelle(e);
        //    }
        //    Yeni = false;
        //}

        //private void OzelKodGuncelle(DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    AvukatProLib.Entity.TDI_KOD_DAVA_OZEL_KOD DavaOzelKOdOBJ = new AvukatProLib.Entity.TDI_KOD_DAVA_OZEL_KOD();

        //    DavaOzelKOdOBJ.OZEL_KOD = (e.Row as DataRowView)[1].ToString();
        //    DavaOzelKOdOBJ.EK_KOD = (e.Row as DataRowView)[2].ToString();
        //    DavaOzelKOdOBJ.ADMIN_KAYIT_MI = 1;
        //    DavaOzelKOdOBJ.KONTROL_KIM = "AVUKATPRO";
        //    DavaOzelKOdOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //    DavaOzelKOdOBJ.KONTROL_VERSIYON = 1;
        //    DavaOzelKOdOBJ.STAMP = 1;
        //    DavaOzelKOdOBJ.SUBE_KODU = 1;
        //    DavaOzelKOdOBJ.ID =Convert.ToInt32((e.Row as DataRowView)["ID"]);

        //    AvukatProLib.Facade.TDI_KOD_DAVA_OZEL_KOD.Guncelle(DavaOzelKOdOBJ);
        //    MessageBox.Show("GÜNCELLEME Ýþlemi TAMAM ");
        //}

        //private static void OzelKodEkle(DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    AvukatProLib.Entity.TDI_KOD_DAVA_OZEL_KOD DavaOzelKOdOBJ = new AvukatProLib.Entity.TDI_KOD_DAVA_OZEL_KOD();
        //    DavaOzelKOdOBJ.OZEL_KOD = (e.Row as DataRowView)[1].ToString();
        //    DavaOzelKOdOBJ.EK_KOD = (e.Row as DataRowView)[2].ToString();
        //    DavaOzelKOdOBJ.ADMIN_KAYIT_MI = 1;
        //    DavaOzelKOdOBJ.KONTROL_KIM = "AVUKATPRO";
        //    DavaOzelKOdOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //    DavaOzelKOdOBJ.KONTROL_VERSIYON = 1;
        //    DavaOzelKOdOBJ.STAMP = 1;
        //    DavaOzelKOdOBJ.SUBE_KODU = 1;

        //    AvukatProLib.Facade.TDI_KOD_DAVA_OZEL_KOD.TDI_KOD_DAVA_OZEL_KODEkle(DavaOzelKOdOBJ);
        //    MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");
        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //}

        //private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //}

        //int GuncellSilID = 0;
        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncellSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_DAVA_OZEL_KOD.TDI_KOD_DAVA_OZEL_KODSil(GuncellSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");

        //    }
        //    //if (e.Button.ButtonType == NavigatorButtonType.Edit)
        //    //{
        //    //    GuncellSilID=Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //    //}
        //}

        //private void gridDavaOzelKodlar_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncellSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_DAVA_OZEL_KOD.TDI_KOD_DAVA_OZEL_KODSil(GuncellSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");

        //    }

        //}
    }
}