using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmYuvarlamaCetveli : DevExpress.XtraEditors.XtraForm
    {
        //        AvukatProLib.Facade.TDI_CET_YUVARLAMA_DEGER.TDI_CET_YUVARLAMA_DEGERSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
        private TList<TDI_CET_YUVARLAMA_DEGER> MyDataSource = new TList<TDI_CET_YUVARLAMA_DEGER>();

        public frmYuvarlamaCetveli()
        {
            InitializeComponent();
        }

        //int GuncelleSilID = 0;
        //bool Yeni = false;

        //internal void YuvarlamaCetveli()
        //{
        //    TList<TDI_CET_YUVARLAMA_DEGER> MyDatasourceYuvarlamaDeger = new TList<TDI_CET_YUVARLAMA_DEGER>();
        //    MyDatasourceYuvarlamaDeger = AvukatProLib2.Data.DataRepository.TDI_CET_YUVARLAMA_DEGERProvider.GetAll();
        //    gridYuvarlamaCetveli.DataSource = MyDatasourceYuvarlamaDeger;
        //    //DataSet ds = AvukatProLib.Facade.TDI_CET_YUVARLAMA_DEGER.YuvarlamaCetveli();
        //    //gridYuvarlamaCetveli.DataSource = ds.Tables[0];
        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TDI_CET_YUVARLAMA_DEGER YuvarlamaDegerOBJ = new AvukatProLib.Entity.TDI_CET_YUVARLAMA_DEGER();
        //        YuvarlamaDegerOBJ.HANE_ADEDI =Convert.ToSingle((e.Row as DataRowView)[2]);
        //        YuvarlamaDegerOBJ.TARIH = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        YuvarlamaDegerOBJ.ADMIN_KAYIT_MI = 1;
        //        YuvarlamaDegerOBJ.KONTROL_KIM = "AVUKATPRO";
        //        YuvarlamaDegerOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        YuvarlamaDegerOBJ.KONTROL_VERSIYON = 1;
        //        YuvarlamaDegerOBJ.STAMP = 1;
        //        YuvarlamaDegerOBJ.SUBE_KODU = 1;
        //        AvukatProLib.Facade.TDI_CET_YUVARLAMA_DEGER.TDI_CET_YUVARLAMA_DEGEREkle(YuvarlamaDegerOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_CET_YUVARLAMA_DEGER YuvarlamaDegerOBJ = new AvukatProLib.Entity.TDI_CET_YUVARLAMA_DEGER();
        //        YuvarlamaDegerOBJ.HANE_ADEDI = Convert.ToSingle((e.Row as DataRowView)[2]);
        //        YuvarlamaDegerOBJ.TARIH = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        YuvarlamaDegerOBJ.ADMIN_KAYIT_MI = 1;
        //        YuvarlamaDegerOBJ.KONTROL_KIM = "AVUKATPRO";
        //        YuvarlamaDegerOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        YuvarlamaDegerOBJ.KONTROL_VERSIYON = 1;
        //        YuvarlamaDegerOBJ.STAMP = 1;
        //        YuvarlamaDegerOBJ.SUBE_KODU = 1;
        //        YuvarlamaDegerOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);
        //        AvukatProLib.Facade.TDI_CET_YUVARLAMA_DEGER.Guncelle(YuvarlamaDegerOBJ);
        //        MessageBox.Show("GÜNCELLEME ÝÞLEMÝ TAMAM");
        //    }

        //    Yeni = false;

        //}

        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    //ÝSL
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_CET_YUVARLAMA_DEGER.TDI_CET_YUVARLAMA_DEGERSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        //private void gridYuvarlamaCetveli_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);
        public void yuvarlamaCetvelGetir()
        {
            MyDataSource = DataRepository.TDI_CET_YUVARLAMA_DEGERProvider.GetAll();
            gridYuvarlamaCetveli.DataSource = MyDataSource;
        }

        public void yuvarlamaCetvelKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_YUVARLAMA_DEGERProvider.Save(tran, MyDataSource);
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
            yuvarlamaCetvelKaydet();
        }
    }
}