using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using AvukatProLib;

namespace AnaForm
{
    public partial class frmGunlukDovizKurlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_GUNLUK_DOVIZ_KUR> MyDataSourceDovizkur = new TList<TDI_CET_GUNLUK_DOVIZ_KUR>();

        public frmGunlukDovizKurlari()
        {
            InitializeComponent();
        }

        public void gunlukDovizGetir()
        {
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            try
            {
                cn.ExcuteQuery("UPDATE A SET DOVIZ=B.DOVIZ_KODU FROM dbo.TDI_CET_GUNLUK_DOVIZ_KUR A INNER JOIN dbo.TDI_KOD_DOVIZ_TIP B ON B.ID=A.DOVIZ_ID WHERE A.DOVIZ IS NULL OR LEN(A.DOVIZ)=0 OR A.DOVIZ=' '");
            }
            catch { ;}

            MyDataSourceDovizkur = AvukatProLib2.Data.DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.GetAll();
            gridDovizKurlari.DataSource = MyDataSourceDovizkur;
            BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
            BelgeUtil.Inits.ParaBicimiAyarla(spTutar);
        }

        public void gunlukDovizKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.Save(tran, MyDataSourceDovizkur);
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

        private void gridDovizKurlari_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                if (e.Button.Tag == "1")
                {
                    frmTopluKurGuncelle ftmTopluKod = new frmTopluKurGuncelle();
                    ftmTopluKod.ShowDialog();
                }
            }
        }

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
            gunlukDovizKaydet();
        }

        //DataTable dtParaBirimleri = null;

        //internal void GunlukDovizKurGetir()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_CET_GUNLUK_DOVIZ_KUR.TDI_CET_GUNLUK_DOVIZ_KURGetir();

        //    //dtParaBirimleri = AvukatProLib.Facade.TDI_KOD_DOVIZ_TIP.DovizTipiGetir();

        //    //ds.Tables[0].TableName = "Kurlar";
        //    //gridDovizKurlari.DataSource = ds.Tables["Kurlar"];

        //    foreach (DataRow dr in dtParaBirimleri.Rows)
        //    {
        //        cbBirim.Items.Add(dr["DOVIZ_KODU"].ToString());
        //    }
        //}

        //string IsimBul(string kod, DataTable dtKaynak, out int Id)
        //{
        //    DataRow[] satirlar = dtKaynak.Select("DOVIZ_KODU='" + kod + "'");
        //    Id = Convert.ToInt32(satirlar[0]["ID"]);
        //    return satirlar[0]["AD"].ToString();
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //        AvukatProLib.Entity.TDI_CET_GUNLUK_DOVIZ_KUR obj = new AvukatProLib.Entity.TDI_CET_GUNLUK_DOVIZ_KUR();
        //        obj.DOVIZ = (e.Row as DataRowView)[0].ToString();
        //        obj.TARIH = Convert.ToDateTime((e.Row as DataRowView)[2]);
        //        obj.TL_DEGERI = Convert.ToDecimal((e.Row as DataRowView)[4]);
        //        obj.KONTROL_KIM = "AVUKATPRO";
        //        obj.KONTROL_NE_ZAMAN = DateTime.Now;
        //        obj.SUBE_KODU = 1;
        //        obj.STAMP = 1;
        //        obj.KONTROL_VERSIYON = 1;
        //        obj.ADMIN_KAYIT_MI = 1;

        //        obj.DOVIZ_ID = doviz_Id;

        //        AvukatProLib.Facade.TDI_CET_GUNLUK_DOVIZ_KUR.TDI_CET_GUNLUK_DOVIZ_KUREkle(obj);

        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    ind = e.RowHandle;
        //    DegerAta(ind);

        //}

        //string hoyt = "";
        //int ind = 0;
        //int doviz_Id = 0;

        //private void cbBirim_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    if (e.Value != null)
        //        hoyt = e.Value.ToString();
        //}

        //void DegerAta(int sayi)
        //{
        //    DataRow row = gridView1.GetDataRow(sayi);

        //    row[1] = this.IsimBul(hoyt, dtParaBirimleri, out doviz_Id);
        //}

        //private void frmGunlukDovizKurlari_Load(object sender, EventArgs e)
        //{
        //}
        //int GuncelleSilID = 0;
        //private void gridDovizKurlari_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_CET_GUNLUK_DOVIZ_KUR.TDI_CET_GUNLUK_DOVIZ_KURSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}
    }
}