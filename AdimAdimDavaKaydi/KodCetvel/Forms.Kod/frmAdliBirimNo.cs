using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmAdliBirimNo : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_ADLI_BIRIM_NO> MyDataSource = new TList<TDI_KOD_ADLI_BIRIM_NO>();

        public frmAdliBirimNo()
        {
            InitializeComponent();
        }

        //internal void AdliBirimNumaralari()
        //{
        //    TList<TDI_KOD_ADLI_BIRIM_NO> MyDataSourceAdliBirimNo = new TList<TDI_KOD_ADLI_BIRIM_NO>();
        //    MyDataSourceAdliBirimNo = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();
        //    gridAdliBirimNumaralari.DataSource = MyDataSourceAdliBirimNo;
        //    //DataSet ds = AvukatProLib.Facade.TDI_KOD_ADLI_BIRIM_NO.AdliBirimNumaralari();
        //    //gridAdliBirimNumaralari.DataSource = ds.Tables[0];
        //}
        //bool Yeni = false;
        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        //EKLE
        //        AvukatProLib.Entity.TDI_KOD_ADLI_BIRIM_NO AdliBirimOBJ = new AvukatProLib.Entity.TDI_KOD_ADLI_BIRIM_NO();
        //        AdliBirimOBJ.NO = (e.Row as DataRowView)[1].ToString();
        //        AdliBirimOBJ.ADMIN_KAYIT_MI = 1;
        //        AdliBirimOBJ.KONTROL_KIM = "AVUKATPRO";
        //        AdliBirimOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        AdliBirimOBJ.KONTROL_VERSIYON = 1;
        //        AdliBirimOBJ.STAMP = 1;
        //        AdliBirimOBJ.SUBE_KODU = 1;

        //        AvukatProLib.Facade.TDI_KOD_ADLI_BIRIM_NO.TDI_KOD_ADLI_BIRIM_NOEkle(AdliBirimOBJ);

        //        MessageBox.Show("EKLENDI " + (e.Row as DataRowView)[0].ToString());
        //    }
        //    else
        //    {
        //        //GUNCELLE
        //        AvukatProLib.Entity.TDI_KOD_ADLI_BIRIM_NO AdliBirimOBJ = new AvukatProLib.Entity.TDI_KOD_ADLI_BIRIM_NO();
        //        AdliBirimOBJ.NO = (e.Row as DataRowView)[1].ToString();
        //        AdliBirimOBJ.ADMIN_KAYIT_MI = 1;
        //        AdliBirimOBJ.KONTROL_KIM = "AVUKATPRO";
        //        AdliBirimOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        AdliBirimOBJ.KONTROL_VERSIYON = 1;
        //        AdliBirimOBJ.STAMP = 1;
        //        AdliBirimOBJ.SUBE_KODU = 1;
        //        AdliBirimOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);

        //        AvukatProLib.Facade.TDI_KOD_ADLI_BIRIM_NO.Guncelle(AdliBirimOBJ);

        //    }
        //    Yeni = false;

        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}
        //int GuncelSilID = 0;
        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelSilID = Convert.ToInt32((object) gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_ADLI_BIRIM_NO.TDI_KOD_ADLI_BIRIM_NOSil(GuncelSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //    //if (e.Button.ButtonType == NavigatorButtonType.Edit)
        //    //{
        //    //    GuncelSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //    //}
        //}

        //private void gridAdliBirimNumaralari_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelSilID = Convert.ToInt32((object) gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_ADLI_BIRIM_NO.TDI_KOD_ADLI_BIRIM_NOSil(GuncelSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}
        public void AdlBirimDoldur()
        {
            MyDataSource = DataRepository.TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();
            gridAdliBirimNumaralari.DataSource = MyDataSource;
        }

        public void AdliBirimKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_ADLI_BIRIM_NOProvider.Save(tran, MyDataSource);
                    tran.Commit();

                    //XtraMessageBox.Show("Adli Birim No lar Kaydedildi .. ");
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AdliBirimKaydet();
        }
    }
}