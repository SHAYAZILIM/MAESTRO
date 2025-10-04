using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmKDVCetveli : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_KDV> MyDataSourceCetvelKod = new TList<TDI_CET_KDV>();

        public frmKDVCetveli()
        {
            InitializeComponent();
        }

        public void kdvCetveliGetir()
        {
            MyDataSourceCetvelKod = AvukatProLib2.Data.DataRepository.TDI_CET_KDVProvider.GetAll();
            gridKDVCetveli.DataSource = MyDataSourceCetvelKod;
            BelgeUtil.Inits.KdvKodGetir(rLueKategori);
            BelgeUtil.Inits.YuzdeBicimiAyarla(spOran);
        }

        private void gridKDVCetveli_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                if (e.Button.Tag == "1")
                {
                    frmTopluKDVGuncelle ftmTopluKDV = new frmTopluKDVGuncelle();
                    ftmTopluKDV.ShowDialog();
                }
            }
        }

        private void kdvCetveliKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_KDVProvider.Save(tran, MyDataSourceCetvelKod);
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
            kdvCetveliKaydet();
        }

        //DataTable dtKDVKategori = null;
        //int KategoriID = 0;
        //int GuncelleSilID = 0;
        //bool Yeni = false;
        //internal void KDVCetvelGetir()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_CET_KDV.KDVCetvelGetir();
        //    //gridKDVCetveli.DataSource = ds.Tables[0];

        //    //dtKDVKategori = AvukatProLib.Facade.TDI_KOD_KDV.TDI_KOD_KDVGetir();
        //    foreach (DataRow dr in dtKDVKategori.Rows)
        //    {
        //        rCb_Kategori.Items.Add(dr["AD"].ToString());
        //    }
        //}
        //int Kategori_ID_AL(string KategoriAD, DataTable dtKategoriID)
        //{
        //    DataRow[] Kategoriler = dtKategoriID.Select("AD='" + KategoriAD + "'");
        //    return Convert.ToInt32(Kategoriler[0]["ID"]);
        //}

        //private void rCb_Kategori_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    if (e.Value != null)
        //        KategoriID = Kategori_ID_AL(e.Value.ToString(), dtKDVKategori);
        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TDI_CET_KDV KADCetveliOBJ = new AvukatProLib.Entity.TDI_CET_KDV();
        //        KADCetveliOBJ.KATEGORI_ID = KategoriID;
        //        KADCetveliOBJ.KDV_AD = (e.Row as DataRowView)[2].ToString();
        //        //KADCetveliOBJ.KDV_ORAN =Convert.ToDecimal((e.Row as DataRowView)[3]);
        //        KADCetveliOBJ.TARIH = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        KADCetveliOBJ.ADMIN_KAYIT_MI = 1;
        //        KADCetveliOBJ.KONTROL_KIM = "AVUKATPRO";
        //        KADCetveliOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        KADCetveliOBJ.KONTROL_VERSIYON = 1;
        //        KADCetveliOBJ.STAMP = 1;
        //        KADCetveliOBJ.SUBE_KODU = 1;

        //        AvukatProLib.Facade.TDI_CET_KDV.TDI_CET_KDVEkle(KADCetveliOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_CET_KDV KADCetveliOBJ = new AvukatProLib.Entity.TDI_CET_KDV();
        //        KADCetveliOBJ.KATEGORI_ID = KategoriID;
        //        KADCetveliOBJ.KDV_AD = (e.Row as DataRowView)[2].ToString();
        //        //KADCetveliOBJ.KDV_ORAN = Convert.ToDecimal((e.Row as DataRowView)[3]);
        //        KADCetveliOBJ.TARIH = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        KADCetveliOBJ.ADMIN_KAYIT_MI = 1;
        //        KADCetveliOBJ.KONTROL_KIM = "AVUKATPRO";
        //        KADCetveliOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        KADCetveliOBJ.KONTROL_VERSIYON = 1;
        //        KADCetveliOBJ.STAMP = 1;
        //        KADCetveliOBJ.SUBE_KODU = 1;
        //        KADCetveliOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);

        //        AvukatProLib.Facade.TDI_CET_KDV.Guncelle(KADCetveliOBJ);
        //        MessageBox.Show("GÜNCELLEME ÝÞLEMÝ TAMAM");
        //    }

        //    Yeni = false;
        //}

        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    //SÝL
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_CET_KDV.TDI_CET_KDVSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        //private void gridKDVCetveli_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_CET_KDV.TDI_CET_KDVSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
    }
}