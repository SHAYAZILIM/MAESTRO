using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmFaizTarifeCetveli : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_FAIZ_TARIFE> MyDataSourceFaizTarife = new TList<TDI_CET_FAIZ_TARIFE>();

        public frmFaizTarifeCetveli()
        {
            InitializeComponent();
        }

        public void faizTarifeGetir()
        {
            MyDataSourceFaizTarife = AvukatProLib2.Data.DataRepository.TDI_CET_FAIZ_TARIFEProvider.GetAll();
            gridFaizTarifeCetveli.DataSource = MyDataSourceFaizTarife;
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.FaizTipiGetir(rLueFaizTip);
            BelgeUtil.Inits.ParaBicimiAyarla(spTutar);
            BelgeUtil.Inits.YuzdeBicimiAyarla(spYuzde);
            BelgeUtil.Inits.BindeYuzdeGetir(lueBindeYuzde);
        }

        public void faziTarifeKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_FAIZ_TARIFEProvider.Save(tran, MyDataSourceFaizTarife);
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

        private void frmFaizTarifeCetveli_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.ParaBicimiAyarla(spTutar);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.FaizTipiGetir(rLueFaizTip);
        }

        private void gridFaizTarifeCetveli_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            //if()
            //DevExpress.XtraEditors.ControlNavigatorButtons
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            faziTarifeKaydet();
        }

        //DataTable dtFaizTipi = null;
        //DataTable dtDovizTipi = null;
        //bool Yeni = false;
        //int DovizTipID = 0;
        //int FaizTipID = 0;
        //internal void FaizTarifeCetveliGetir()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_CET_FAIZ_TARIFE.TDI_CET_FAIZ_TARIFEGetir();
        //    //gridFaizTarifeCetveli.DataSource = ds.Tables[0];

        //    //dtFaizTipi = AvukatProLib.Facade.TDI_KOD_FAIZ_TIP.FaizTipKodGETIR();
        //    foreach (DataRow dr in dtFaizTipi.Rows)
        //    {
        //        rCb_FaizTipi.Items.Add(dr["FAIZ_TIP"].ToString());
        //    }

        //    dtDovizTipi = AvukatProLib.Facade.TDI_KOD_DOVIZ_TIP.DovizTipiGetir();
        //    foreach (DataRow dr in dtDovizTipi.Rows)
        //    {
        //        rCb_DovizTipi.Items.Add(dr["DOVIZ_KODU"].ToString());
        //    }
        //}
        //int DovizTip_ID_AL(string DovizTipAD, DataTable dtDovizTipID)
        //{
        //    DataRow[] DovizTipleri = dtDovizTipID.Select("DOVIZ_KODU='" + DovizTipAD + "'");
        //    return Convert.ToInt32(DovizTipleri[0]["ID"]);
        //}
        //int FaizTip_ID_AL(string FaizTipAD, DataTable dtFaizTipID)
        //{
        //    DataRow[] FaizTipleri = dtFaizTipID.Select("FAIZ_TIP='" + FaizTipAD + "'");
        //    return Convert.ToInt32(FaizTipleri[0]["ID"]);
        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TDI_CET_FAIZ_TARIFE FaizTarifeOBJ = new AvukatProLib.Entity.TDI_CET_FAIZ_TARIFE();
        //        FaizTarifeOBJ.DOVIZ_TIP = (e.Row as DataRowView)[2].ToString();
        //        FaizTarifeOBJ.DOVIZ_TIP_ID = DovizTipID;
        //        FaizTarifeOBJ.FAIZ_TIP = (e.Row as DataRowView)[3].ToString();
        //        FaizTarifeOBJ.FAIZ_TIP_ID = FaizTipID;
        //        FaizTarifeOBJ.TARIFE_BINDE_ORAN_MI = Convert.ToByte((e.Row as DataRowView)[4]);
        //        FaizTarifeOBJ.TARIFE_GECERLILIK_BASLANGIC_TARIHI = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //       // FaizTarifeOBJ.TARIFE_TUTARI = Convert.ToDecimal((e.Row as DataRowView)[5]);
        //        FaizTarifeOBJ.ADMIN_KAYIT_MI = 1;
        //        FaizTarifeOBJ.KONTROL_KIM = "AVUKATPRO";
        //        FaizTarifeOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        FaizTarifeOBJ.KONTROL_VERSIYON = 1;
        //        FaizTarifeOBJ.STAMP = 1;
        //        FaizTarifeOBJ.SUBE_KODU = 1;

        //        AvukatProLib.Facade.TDI_CET_FAIZ_TARIFE.TDI_CET_FAIZ_TARIFEEkle(FaizTarifeOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_CET_FAIZ_TARIFE FaizTarifeOBJ = new AvukatProLib.Entity.TDI_CET_FAIZ_TARIFE();
        //        FaizTarifeOBJ.DOVIZ_TIP = (e.Row as DataRowView)[2].ToString();
        //        FaizTarifeOBJ.DOVIZ_TIP_ID = Convert.ToInt32((e.Row as DataRowView)[7]);
        //        FaizTarifeOBJ.FAIZ_TIP = (e.Row as DataRowView)[3].ToString();
        //        FaizTarifeOBJ.FAIZ_TIP_ID = Convert.ToInt32((e.Row as DataRowView)[6]);
        //        FaizTarifeOBJ.TARIFE_BINDE_ORAN_MI = Convert.ToByte((e.Row as DataRowView)[4]);
        //        FaizTarifeOBJ.TARIFE_GECERLILIK_BASLANGIC_TARIHI = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        //FaizTarifeOBJ.TARIFE_TUTARI = Convert.ToDecimal((e.Row as DataRowView)[5]);
        //        FaizTarifeOBJ.ADMIN_KAYIT_MI = 1;
        //        FaizTarifeOBJ.KONTROL_KIM = "AVUKATPRO";
        //        FaizTarifeOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        FaizTarifeOBJ.KONTROL_VERSIYON = 1;
        //        FaizTarifeOBJ.STAMP = 1;
        //        FaizTarifeOBJ.SUBE_KODU = 1;
        //        FaizTarifeOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);

        //        AvukatProLib.Facade.TDI_CET_FAIZ_TARIFE.TDI_CET_FAIZ_TARIFEEkle(FaizTarifeOBJ);
        //        MessageBox.Show("GÜNCELLEME ÝÞLEMÝ TAMAM");
        //    }
        //    Yeni = false;
        //}

        //private void rCb_DovizTipi_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //DOVÝZ ID YÝ AL
        //    DovizTipID = DovizTip_ID_AL(e.Value.ToString(), dtDovizTipi);

        //}

        //private void rCb_FaizTipi_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //FAIZ TIP ID YÝ AL
        //    FaizTipID = FaizTip_ID_AL(e.Value.ToString(), dtFaizTipi);
        //}
        //int GuncelleSilID = 0;
        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_CET_FAIZ_TARIFE.TDI_CET_FAIZ_TARIFESil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        //private void gridFaizTarifeCetveli_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_CET_FAIZ_TARIFE.TDI_CET_FAIZ_TARIFESil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
    }
}