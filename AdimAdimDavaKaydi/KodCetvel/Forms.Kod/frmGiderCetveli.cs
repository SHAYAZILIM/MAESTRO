using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmGiderCetveli : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_POSTA_GIDER> MyDataSourcePostagider = new TList<TDI_CET_POSTA_GIDER>();

        public frmGiderCetveli()
        {
            InitializeComponent();
        }

        public void giderCetveliGetir()
        {
            MyDataSourcePostagider = AvukatProLib2.Data.DataRepository.TDI_CET_POSTA_GIDERProvider.GetAll();
            gridPostaGiderCetveli.DataSource = MyDataSourcePostagider;
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.MuhasebeHareketAltKategoriAnakatGetir(rLueMuhasebeAltKat);
        }

        public void giderCetveliKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_POSTA_GIDERProvider.Save(tran, MyDataSourcePostagider);
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
            giderCetveliKaydet();
        }

        //DataTable dtDovizTip = null;
        //DataTable dtAltKategori = null;
        //int AltKategoriID = 0;
        //int DovizTipID = 0;
        //bool Yeni = false;
        //int GuncelleSilID = 0;

        //internal void PostaGiderCetveli()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_CET_POSTA_GIDER.PostaGiderCetveliGetir();
        //    //gridPostaGiderCetveli.DataSource = ds.Tables[0];

        //    dtAltKategori = AvukatProLib.Facade.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI.AltKategoriGetir();
        //    foreach (DataRow dr in dtAltKategori.Rows)
        //    {
        //        rcb_AltKategori.Items.Add(dr["ALT_KATEGORI"].ToString());
        //    }

        //    dtDovizTip = AvukatProLib.Facade.TDI_KOD_DOVIZ_TIP.DovizTipiGetir();
        //    foreach (DataRow dr in dtDovizTip.Rows)
        //    {
        //        rCb_GiderDoviz.Items.Add(dr["DOVIZ_KODU"].ToString());
        //    }
        //}
        //int AltKategori_ID_AL(string AltKategoriAD, DataTable dtAltKategoriID)
        //{
        //    DataRow[] AltKategoriler = dtAltKategoriID.Select("ALT_KATEGORI='" + AltKategoriAD + "'");
        //    return Convert.ToInt32(AltKategoriler[0]["ID"]);
        //}

        //int DovizTip_ID_AL(string DovizTipAD, DataTable dtDovizTipID)
        //{
        //    DataRow[] DovizTipler = dtDovizTipID.Select("DOVIZ_KODU='" + DovizTipAD + "'");
        //    return Convert.ToInt32(DovizTipler[0]["ID"]);
        //}
        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TDI_CET_POSTA_GIDER PosteGiderOBJ = new AvukatProLib.Entity.TDI_CET_POSTA_GIDER();
        //        PosteGiderOBJ.ALT_KATEGORI = (e.Row as DataRowView)[2].ToString();
        //        PosteGiderOBJ.ALT_KATEGORI_ID = AltKategoriID;
        //        PosteGiderOBJ.BASLANGIC_TARIHI = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        PosteGiderOBJ.GIDER_DOVIZ = (e.Row as DataRowView)[4].ToString();
        //        PosteGiderOBJ.GIDER_DOVIZ_ID = DovizTipID;
        //        //PosteGiderOBJ.MIKTAR = Convert.ToDecimal((e.Row as DataRowView)[3]);
        //        //PosteGiderOBJ.ADMIN_KAYIT_MI = 1;
        //        PosteGiderOBJ.KONTROL_KIM = "AVUKATPRO";
        //        PosteGiderOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        PosteGiderOBJ.KONTROL_VERSIYON = 1;
        //        PosteGiderOBJ.STAMP = 1;
        //        PosteGiderOBJ.SUBE_KODU = 1;

        //        AvukatProLib.Facade.TDI_CET_POSTA_GIDER.TDI_CET_POSTA_GIDEREkle(PosteGiderOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_CET_POSTA_GIDER PosteGiderOBJ = new AvukatProLib.Entity.TDI_CET_POSTA_GIDER();
        //        PosteGiderOBJ.ALT_KATEGORI = (e.Row as DataRowView)[2].ToString();
        //        PosteGiderOBJ.ALT_KATEGORI_ID = Convert.ToInt32((e.Row as DataRowView)[5]);
        //        PosteGiderOBJ.BASLANGIC_TARIHI = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        PosteGiderOBJ.GIDER_DOVIZ = (e.Row as DataRowView)[4].ToString();
        //        PosteGiderOBJ.GIDER_DOVIZ_ID = Convert.ToInt32((e.Row as DataRowView)[6]);
        //        //PosteGiderOBJ.MIKTAR = Convert.ToDecimal((e.Row as DataRowView)[3]);
        //        PosteGiderOBJ.ADMIN_KAYIT_MI = 1;
        //        PosteGiderOBJ.KONTROL_KIM = "AVUKATPRO";
        //        PosteGiderOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        PosteGiderOBJ.KONTROL_VERSIYON = 1;
        //        PosteGiderOBJ.STAMP = 1;
        //        PosteGiderOBJ.SUBE_KODU = 1;
        //        PosteGiderOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);

        //        AvukatProLib.Facade.TDI_CET_POSTA_GIDER.Guncelle(PosteGiderOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");
        //    }
        //    Yeni = false;
        //}

        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    //SÝL
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_CET_POSTA_GIDER.TDI_CET_POSTA_GIDERSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        //private void rCb_GiderDoviz_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //DOVÝZ TÝP ID YÝ AL
        //    if (e.Value != null)
        //    {
        //        DovizTipID = DovizTip_ID_AL(e.Value.ToString(), dtDovizTip);
        //    }

        //}
        //private void rcb_AltKategori_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //ALT KATEGORÝ ID YÝ AL
        //    if (e.Value != null)
        //    {
        //        AltKategoriID = AltKategori_ID_AL(e.Value.ToString(), dtAltKategori);
        //    }

        //}

        //private void gridPostaGiderCetveli_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_CET_POSTA_GIDER.TDI_CET_POSTA_GIDERSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
    }
}