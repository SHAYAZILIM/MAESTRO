using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmTebligatAlimSekli : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_TEBLIGAT_ALIM_SEKIL> MyDataSourceTebAlimSekil = new TList<TDI_KOD_TEBLIGAT_ALIM_SEKIL>();

        public frmTebligatAlimSekli()
        {
            InitializeComponent();
        }

        public void tebligatAlimSekliGetir()
        {
            MyDataSourceTebAlimSekil = AvukatProLib2.Data.DataRepository.TDI_KOD_TEBLIGAT_ALIM_SEKILProvider.GetAll();
            gridTebligatAlimSekli.DataSource = MyDataSourceTebAlimSekil;
        }

        public void tebligatAlimSekliKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_TEBLIGAT_ALIM_SEKILProvider.Save(tran, MyDataSourceTebAlimSekil);
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
            tebligatAlimSekliKaydet();
        }

        //int GuncelleSilID = 0;
        //bool Yeni = false;

        //internal void TebligatAlimSekli()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_KOD_TEBLIGAT_ALIM_SEKIL.TebligatAlimSekli();
        //    //gridTebligatAlimSekli.DataSource = ds.Tables[0];
        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;

        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TDI_KOD_TEBLIGAT_ALIM_SEKIL TebligatAlimSekliOBJ = new AvukatProLib.Entity.TDI_KOD_TEBLIGAT_ALIM_SEKIL();
        //        TebligatAlimSekliOBJ.SEKIL = (e.Row as DataRowView)[1].ToString();
        //        TebligatAlimSekliOBJ.ADMIN_KAYIT_MI = 1;
        //        TebligatAlimSekliOBJ.KONTROL_KIM = "AVUKATPRO";
        //        TebligatAlimSekliOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        TebligatAlimSekliOBJ.KONTROL_VERSIYON = 1;
        //        TebligatAlimSekliOBJ.STAMP = 1;
        //        TebligatAlimSekliOBJ.SUBE_KODU = 1;
        //        AvukatProLib.Facade.TDI_KOD_TEBLIGAT_ALIM_SEKIL.TDI_KOD_TEBLIGAT_ALIM_SEKILEkle(TebligatAlimSekliOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_KOD_TEBLIGAT_ALIM_SEKIL TebligatAlimSekliOBJ = new AvukatProLib.Entity.TDI_KOD_TEBLIGAT_ALIM_SEKIL();
        //        TebligatAlimSekliOBJ.SEKIL = (e.Row as DataRowView)[1].ToString();
        //        TebligatAlimSekliOBJ.ADMIN_KAYIT_MI = 1;
        //        TebligatAlimSekliOBJ.KONTROL_KIM = "AVUKATPRO";
        //        TebligatAlimSekliOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        TebligatAlimSekliOBJ.KONTROL_VERSIYON = 1;
        //        TebligatAlimSekliOBJ.STAMP = 1;
        //        TebligatAlimSekliOBJ.SUBE_KODU = 1;
        //        TebligatAlimSekliOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);

        //        AvukatProLib.Facade.TDI_KOD_TEBLIGAT_ALIM_SEKIL.Guncelle(TebligatAlimSekliOBJ);
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

        //        AvukatProLib.Facade.TDI_KOD_TEBLIGAT_ALIM_SEKIL.TDI_KOD_TEBLIGAT_ALIM_SEKILSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        //private void gridTebligatAlimSekli_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_TEBLIGAT_ALIM_SEKIL.TDI_KOD_TEBLIGAT_ALIM_SEKILSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
    }
}