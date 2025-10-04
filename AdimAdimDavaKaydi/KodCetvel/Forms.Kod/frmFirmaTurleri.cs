using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmFirmaTurleri : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_FIRMA_TUR> MyDataSorceFirmaTur = new TList<TDI_KOD_FIRMA_TUR>();

        public frmFirmaTurleri()
        {
            InitializeComponent();
        }

        public void firmaKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_FIRMA_TURProvider.Save(tran, MyDataSorceFirmaTur);
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

        public void firmaTurDoldur()
        {
            MyDataSorceFirmaTur = AvukatProLib2.Data.DataRepository.TDI_KOD_FIRMA_TURProvider.GetAll();
            gridFirmaTurleri.DataSource = MyDataSorceFirmaTur;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            firmaKaydet();
        }

        //internal void FirmaTurleri()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_KOD_FIRMA_TUR.FirmaTurleri();
        //    //gridFirmaTurleri.DataSource = ds.Tables[0];
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
        //        AvukatProLib.Entity.TDI_KOD_FIRMA_TUR FirmaTurleriOBJ = new AvukatProLib.Entity.TDI_KOD_FIRMA_TUR() ;
        //        FirmaTurleriOBJ.TUR = (e.Row as DataRowView)[1].ToString();
        //        FirmaTurleriOBJ.ADMIN_KAYIT_MI = 1;
        //        FirmaTurleriOBJ.KONTROL_KIM = "AVUKATPRO";
        //        FirmaTurleriOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        FirmaTurleriOBJ.KONTROL_VERSIYON = 1;
        //        FirmaTurleriOBJ.STAMP = 1;
        //        FirmaTurleriOBJ.SUBE_KODU = 1;

        //        AvukatProLib.Facade.TDI_KOD_FIRMA_TUR.TDI_KOD_FIRMA_TUREkle(FirmaTurleriOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_KOD_FIRMA_TUR FirmaTurleriOBJ = new AvukatProLib.Entity.TDI_KOD_FIRMA_TUR();
        //        FirmaTurleriOBJ.TUR = (e.Row as DataRowView)[1].ToString();
        //        FirmaTurleriOBJ.ADMIN_KAYIT_MI = 1;
        //        FirmaTurleriOBJ.KONTROL_KIM = "AVUKATPRO";
        //        FirmaTurleriOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        FirmaTurleriOBJ.KONTROL_VERSIYON = 1;
        //        FirmaTurleriOBJ.STAMP = 1;
        //        FirmaTurleriOBJ.SUBE_KODU = 1;
        //        FirmaTurleriOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);

        //        AvukatProLib.Facade.TDI_KOD_FIRMA_TUR.Guncelle(FirmaTurleriOBJ);
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

        //        AvukatProLib.Facade.TDI_KOD_FIRMA_TUR.TDI_KOD_FIRMA_TURSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        //private void gridFirmaTurleri_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_FIRMA_TUR.TDI_KOD_FIRMA_TURSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
    }
}