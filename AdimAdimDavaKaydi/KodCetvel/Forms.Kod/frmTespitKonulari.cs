using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmTespitKonulari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TI_KOD_TESPIT_KONUSU> MyDataSourceTespitKonusu = new TList<TI_KOD_TESPIT_KONUSU>();

        public frmTespitKonulari()
        {
            InitializeComponent();
        }

        //int GuncelleSilID = 0;
        //bool Yeni = false;

        //internal void TespitKonulari()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TI_KOD_TESPIT_KONUSU.TespitKonulari();
        //    //gridTespitKonular.DataSource = ds.Tables[0];
        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;

        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TI_KOD_TESPIT_KONUSU TespitkonusuOBJ = new AvukatProLib.Entity.TI_KOD_TESPIT_KONUSU();

        //        TespitkonusuOBJ.KONU = (e.Row as DataRowView)[1].ToString();
        //        TespitkonusuOBJ.ADMIN_KAYIT_MI = 1;
        //        TespitkonusuOBJ.KONTROL_KIM = "AVUKATPRO";
        //        TespitkonusuOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        TespitkonusuOBJ.KONTROL_VERSIYON = 1;
        //        TespitkonusuOBJ.STAMP = 1;
        //        TespitkonusuOBJ.SUBE_KODU = 1;
        //        AvukatProLib.Facade.TI_KOD_TESPIT_KONUSU.TI_KOD_TESPIT_KONUSUEkle(TespitkonusuOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TI_KOD_TESPIT_KONUSU TespitkonusuOBJ = new AvukatProLib.Entity.TI_KOD_TESPIT_KONUSU();

        //        TespitkonusuOBJ.KONU = (e.Row as DataRowView)[1].ToString();
        //        TespitkonusuOBJ.ADMIN_KAYIT_MI = 1;
        //        TespitkonusuOBJ.KONTROL_KIM = "AVUKATPRO";
        //        TespitkonusuOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        TespitkonusuOBJ.KONTROL_VERSIYON = 1;
        //        TespitkonusuOBJ.STAMP = 1;
        //        TespitkonusuOBJ.SUBE_KODU = 1;
        //        TespitkonusuOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);
        //        AvukatProLib.Facade.TI_KOD_TESPIT_KONUSU.Guncelle(TespitkonusuOBJ);
        //        MessageBox.Show("GÜNCELLEME ÝÞLEMÝ TAMAM");
        //    }

        //    Yeni = false;
        //}

        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    //SÝl

        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TI_KOD_TESPIT_KONUSU.TI_KOD_TESPIT_KONUSUSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}

        //private void gridTespitKonular_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TI_KOD_TESPIT_KONUSU.TI_KOD_TESPIT_KONUSUSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        public void tespitKonuGetir()
        {
            MyDataSourceTespitKonusu = AvukatProLib2.Data.DataRepository.TI_KOD_TESPIT_KONUSUProvider.GetAll();
            gridTespitKonular.DataSource = MyDataSourceTespitKonusu;
        }

        public void tespitKonuKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TI_KOD_TESPIT_KONUSUProvider.Save(tran, MyDataSourceTespitKonusu);
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
            tespitKonuKaydet();
        }
    }
}