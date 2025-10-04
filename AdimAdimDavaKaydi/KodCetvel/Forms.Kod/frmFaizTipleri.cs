using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmFaizTipleri : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_FAIZ_TIP> MyDataSourceFaiztip = new TList<TDI_KOD_FAIZ_TIP>();

        public frmFaizTipleri()
        {
            InitializeComponent();
        }

        public void faizTipleriDoldur()
        {
            MyDataSourceFaiztip = AvukatProLib2.Data.DataRepository.TDI_KOD_FAIZ_TIPProvider.GetAll();
            gridFaizTipKodlar.DataSource = MyDataSourceFaiztip;
        }

        public void faizTipleriKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_FAIZ_TIPProvider.Save(tran, MyDataSourceFaiztip);
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
            faizTipleriKaydet();
        }

        //int GuncelleSilID = 0;
        //bool Yeni = false;
        //internal void FaizTipKodar()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_KOD_FAIZ_TIP.FaizTipKodlar();
        //    //gridFaizTipKodlar.DataSource = ds.Tables[0];
        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TDI_KOD_FAIZ_TIP FaizTipleriOBJ = new AvukatProLib.Entity.TDI_KOD_FAIZ_TIP();
        //        FaizTipleriOBJ.FAIZ_TIP = (e.Row as DataRowView)[1].ToString();
        //        FaizTipleriOBJ.UYAP_ACIKLAMA = (e.Row as DataRowView)[3].ToString();
        //        FaizTipleriOBJ.UYAP_KOD = (e.Row as DataRowView)[2].ToString();
        //        FaizTipleriOBJ.ADMIN_KAYIT_MI = 1;
        //        FaizTipleriOBJ.KONTROL_KIM = "AVUKATPRO";
        //        FaizTipleriOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        FaizTipleriOBJ.KONTROL_VERSIYON = 1;
        //        FaizTipleriOBJ.STAMP = 1;
        //        FaizTipleriOBJ.SUBE_KODU = 1;

        //        AvukatProLib.Facade.TDI_KOD_FAIZ_TIP.TDI_KOD_FAIZ_TIPEkle(FaizTipleriOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_KOD_FAIZ_TIP FaizTipleriOBJ = new AvukatProLib.Entity.TDI_KOD_FAIZ_TIP();
        //        FaizTipleriOBJ.FAIZ_TIP = (e.Row as DataRowView)[1].ToString();
        //        FaizTipleriOBJ.UYAP_ACIKLAMA = (e.Row as DataRowView)[3].ToString();
        //        FaizTipleriOBJ.UYAP_KOD = (e.Row as DataRowView)[2].ToString();
        //        FaizTipleriOBJ.ADMIN_KAYIT_MI = 1;
        //        FaizTipleriOBJ.KONTROL_KIM = "AVUKATPRO";
        //        FaizTipleriOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        FaizTipleriOBJ.KONTROL_VERSIYON = 1;
        //        FaizTipleriOBJ.STAMP = 1;
        //        FaizTipleriOBJ.SUBE_KODU = 1;
        //        FaizTipleriOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);

        //        AvukatProLib.Facade.TDI_KOD_FAIZ_TIP.Guncelle(FaizTipleriOBJ);
        //        MessageBox.Show("GÜNCELLEME ÝÞLEMÝ TAMAM");
        //    }
        //    Yeni = false;
        //}
        //int GuncellSilID = 0;
        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncellSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_FAIZ_TIP.TDI_KOD_FAIZ_TIPSil(GuncellSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        //private void gridFaizTipKodlar_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncellSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_FAIZ_TIP.TDI_KOD_FAIZ_TIPSil(GuncellSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
    }
}