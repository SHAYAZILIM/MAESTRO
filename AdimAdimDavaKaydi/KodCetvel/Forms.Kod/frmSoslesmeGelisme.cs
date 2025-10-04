using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmSoslesmeGelisme : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_SOZLESME_GELISME_ADIM> MyDataSourceSozlesmeGel = new TList<TDI_KOD_SOZLESME_GELISME_ADIM>();

        public frmSoslesmeGelisme()
        {
            InitializeComponent();
        }

        public void sozlesmeGelismeGetir()
        {
            MyDataSourceSozlesmeGel = AvukatProLib2.Data.DataRepository.TDI_KOD_SOZLESME_GELISME_ADIMProvider.GetAll();
            gridSozlesmeGelismeKodlar.DataSource = MyDataSourceSozlesmeGel;
        }

        public void sozlesmeGelismeKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_SOZLESME_GELISME_ADIMProvider.Save(tran, MyDataSourceSozlesmeGel);
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
            sozlesmeGelismeKaydet();
        }

        //int GuncelleSilID = 0;
        //bool Yeni = false;

        //internal void SozlesmeGelismeKodlar()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_KOD_SOZLESME_GELISME_ADIM.SozlesmeGelismeKodlar();
        //    //gridSozlesmeGelismeKodlar.DataSource = ds.Tables[0];
        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;

        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TDI_KOD_SOZLESME_GELISME_ADIM SozlesmeAdimOBJ = new AvukatProLib.Entity.TDI_KOD_SOZLESME_GELISME_ADIM();
        //        SozlesmeAdimOBJ.GELISME_ADIM = (e.Row as DataRowView)[1].ToString();
        //        SozlesmeAdimOBJ.ADMIN_KAYIT_MI = 1;
        //        SozlesmeAdimOBJ.KONTROL_KIM = "AVUKATPRO";
        //        SozlesmeAdimOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        SozlesmeAdimOBJ.KONTROL_VERSIYON = 1;
        //        SozlesmeAdimOBJ.STAMP = 1;
        //        SozlesmeAdimOBJ.SUBE_KODU = 1;
        //        AvukatProLib.Facade.TDI_KOD_SOZLESME_GELISME_ADIM.TDI_KOD_SOZLESME_GELISME_ADIMEkle(SozlesmeAdimOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_KOD_SOZLESME_GELISME_ADIM SozlesmeAdimOBJ = new AvukatProLib.Entity.TDI_KOD_SOZLESME_GELISME_ADIM();
        //        SozlesmeAdimOBJ.GELISME_ADIM = (e.Row as DataRowView)[1].ToString();
        //        SozlesmeAdimOBJ.ADMIN_KAYIT_MI = 1;
        //        SozlesmeAdimOBJ.KONTROL_KIM = "AVUKATPRO";
        //        SozlesmeAdimOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        SozlesmeAdimOBJ.KONTROL_VERSIYON = 1;
        //        SozlesmeAdimOBJ.STAMP = 1;
        //        SozlesmeAdimOBJ.SUBE_KODU = 1;
        //        SozlesmeAdimOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);

        //        AvukatProLib.Facade.TDI_KOD_SOZLESME_GELISME_ADIM.Guncelle(SozlesmeAdimOBJ);
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

        //        AvukatProLib.Facade.TDI_KOD_SOZLESME_GELISME_ADIM.TDI_KOD_SOZLESME_GELISME_ADIMSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        //private void gridSozlesmeGelismeKodlar_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_SOZLESME_GELISME_ADIM.TDI_KOD_SOZLESME_GELISME_ADIMSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
    }
}