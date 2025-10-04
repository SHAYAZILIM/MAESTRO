using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmIcraResmiTatil : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_BIL_ONEMLI_GUN> MyDataSourceOnemliGun = new TList<TDI_BIL_ONEMLI_GUN>();

        public frmIcraResmiTatil()
        {
            InitializeComponent();
        }

        public void onemliGunGetir()
        {
            MyDataSourceOnemliGun = AvukatProLib2.Data.DataRepository.TDI_BIL_ONEMLI_GUNProvider.GetAll();
            gridResmiTatilOzelGunler.DataSource = MyDataSourceOnemliGun;
            BelgeUtil.Inits.TarihKategoriGetir(rLueTarihKategori);
        }

        public void onemliGunKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_BIL_ONEMLI_GUNProvider.Save(tran, MyDataSourceOnemliGun);
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
            onemliGunKaydet();
        }

        //DataTable dtTarihKategorileri = null;
        //int GuncelleSilID = 0;
        //int TarihKategoriID = 0;
        //bool Yeni = false;
        //internal void ResmiTatilOneliGunler()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_BIL_ONEMLI_GUN.OnemliGunGetirForCetvel();
        //    //gridResmiTatilOzelGunler.DataSource = ds.Tables[0];

        //    //dtTarihKategorileri = AvukatProLib.Facade.TDI_KOD_TARIH_KATEGORI.TarihKategoriGetir();
        //    foreach (DataRow dr in dtTarihKategorileri.Rows)
        //    {
        //        rCb_TarihKategorileri.Items.Add(dr["ACIKLAMA"].ToString());
        //    }
        //}
        //int TarihKategori_ID_AL(string TarihKategoriAD, DataTable dtTarihKategoriID)
        //{
        //    DataRow[] TarihKategorileri = dtTarihKategoriID.Select("ACIKLAMA='" + TarihKategoriAD + "'");
        //    return Convert.ToInt32(TarihKategorileri[0]["ID"]);
        //}

        //private void rCb_TarihKategorileri_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    if (e.Value != null)
        //        TarihKategoriID = TarihKategori_ID_AL(e.Value.ToString(), dtTarihKategorileri);
        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TDI_BIL_ONEMLI_GUN OneliGunler = new AvukatProLib.Entity.TDI_BIL_ONEMLI_GUN();
        //        OneliGunler.ACIKLAMA = (e.Row as DataRowView)[6].ToString();
        //        OneliGunler.BASLAMA_SAAT=(e.Row as DataRowView)[3].ToString();
        //        OneliGunler.BASLAMA_TARIHI = Convert.ToDateTime((e.Row as DataRowView)[2]);
        //        OneliGunler.BITIS_SAAT = (e.Row as DataRowView)[5].ToString();
        //        OneliGunler.BITIS_TARIHI = Convert.ToDateTime((e.Row as DataRowView)[4]);
        //        OneliGunler.TARIH_KATEGORI = (e.Row as DataRowView)[1].ToString();
        //        OneliGunler.TARIH_KATEGORI_ID = TarihKategoriID;
        //        OneliGunler.ADMIN_KAYIT_MI = 1;
        //        OneliGunler.KONTROL_KIM = "AVUKATPRO";
        //        OneliGunler.KONTROL_NE_ZAMAN = DateTime.Now;
        //        OneliGunler.KONTROL_VERSIYON = 1;
        //        OneliGunler.STAMP = 1;
        //        OneliGunler.SUBE_KODU = 1;

        //        AvukatProLib.Facade.TDI_BIL_ONEMLI_GUN.TDI_BIL_ONEMLI_GUNEkle(OneliGunler);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");
        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_BIL_ONEMLI_GUN OneliGunler = new AvukatProLib.Entity.TDI_BIL_ONEMLI_GUN();
        //        OneliGunler.ACIKLAMA = (e.Row as DataRowView)[6].ToString();
        //        OneliGunler.BASLAMA_SAAT = (e.Row as DataRowView)[3].ToString();
        //        OneliGunler.BASLAMA_TARIHI = Convert.ToDateTime((e.Row as DataRowView)[2]);
        //        OneliGunler.BITIS_SAAT = (e.Row as DataRowView)[5].ToString();
        //        OneliGunler.BITIS_TARIHI = Convert.ToDateTime((e.Row as DataRowView)[4]);
        //        OneliGunler.TARIH_KATEGORI = (e.Row as DataRowView)[1].ToString();
        //        OneliGunler.TARIH_KATEGORI_ID =Convert.ToInt32((e.Row as DataRowView)[7]);
        //        OneliGunler.KONTROL_KIM = "AVUKATPRO";
        //        OneliGunler.KONTROL_NE_ZAMAN = DateTime.Now;
        //        OneliGunler.KONTROL_VERSIYON = 1;
        //        OneliGunler.STAMP = 1;
        //        OneliGunler.SUBE_KODU = 1;
        //        OneliGunler.ID = Convert.ToInt32((e.Row as DataRowView)[0]);

        //        AvukatProLib.Facade.TDI_BIL_ONEMLI_GUN.Guncelle(OneliGunler);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");
        //    }

        //    Yeni = false;
        //}

        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    //SÝl
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_BIL_ONEMLI_GUN.TDI_BIL_ONEMLI_GUNSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}
    }
}