using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmMinMaxDegerCetveli : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_MIN_MAX_DEGER> MyDataSourceMaxDeger = new TList<TDI_CET_MIN_MAX_DEGER>();

        public frmMinMaxDegerCetveli()
        {
            InitializeComponent();
        }

        public void minMaxDegerGetir()
        {
            MyDataSourceMaxDeger = AvukatProLib2.Data.DataRepository.TDI_CET_MIN_MAX_DEGERProvider.GetAll();
            gridMinMaxDeger.DataSource = MyDataSourceMaxDeger;
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
        }

        public void minMaxDEgerKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_MIN_MAX_DEGERProvider.Save(tran, MyDataSourceMaxDeger);
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
            minMaxDEgerKaydet();
        }

        //DataTable dtMinDegerDovizTip = null;
        //DataTable dtMaxDegerDovizTip = null;
        //DataTable dtAciklama = null;
        //int MinDovizID = 0;
        //int MaxDovID = 0;
        //int AciklamaID = 0;
        //int GuncelleSilID = 0;
        //bool Yeni = false;
        //internal void MinMaxDegerCetvel()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_CET_MIN_MAX_DEGER.MinMaxDeger();
        //    //gridMinMaxDeger.DataSource = ds.Tables[0];

        //    //dtMinDegerDovizTip = AvukatProLib.Facade.TDI_KOD_DOVIZ_TIP.DovizTipiGetir();
        //    foreach (DataRow dr in dtMaxDegerDovizTip.Rows)
        //    {
        //        rCb_MinDegDovizTipi.Items.Add(dr["DOVIZ_KODU"].ToString());
        //    }
        //    //dtMaxDegerDovizTip = AvukatProLib.Facade.TDI_KOD_DOVIZ_TIP.DovizTipiGetir();
        //    foreach (DataRow dr in dtMaxDegerDovizTip.Rows)
        //    {
        //        rCb_MaxDegerDovizTipi.Items.Add(dr["DOVIZ_KODU"].ToString());
        //    }
        //    //dtAciklama = AvukatProLib.Facade.TDI_CET_MIN_MAX_DEGER.MinMaxAciklamaGETIR();
        //    foreach (DataRow dr in dtMaxDegerDovizTip.Rows)
        //    {
        //        rCb_Aciklama.Items.Add(dr["ACIKLAMA"].ToString());
        //    }
        //}
        //int MinDoviztip_ID_AL(string DovizMinTipAD, DataTable dtMinDovizTipID)
        //{
        //    DataRow[] DovizTipleri = dtMinDovizTipID.Select("DOVIZ_KODU='" + DovizMinTipAD + "'");
        //    return Convert.ToInt32(DovizTipleri[0]["ID"]);
        //}
        //int MaxDovizTip_ID_AL(string DovizMaxTipID, DataTable dtMaxDovizTipiID)
        //{
        //    DataRow[] MaxDovizTipleri = dtMaxDovizTipiID.Select("DOVIZ_KODU='" + DovizMaxTipID + "'");
        //    return Convert.ToInt32(MaxDovizTipleri[0]["ID"]);
        //}
        //int Aciklama_ID_AL(string AciklamaAD, DataTable dtAciklamaID)
        //{
        //    DataRow[] Aciklamalar = dtAciklamaID.Select("ACIKLAMA='" + AciklamaAD + "'");
        //    return Convert.ToInt32(Aciklamalar[0]["ID"]);
        //}
        //private void rCb_Aciklama_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //AÇIKLAMA ID YÝ AL
        //    if (e.Value != null)
        //        AciklamaID = Aciklama_ID_AL(e.Value.ToString(), dtAciklama);
        //}

        //private void rCb_MaxDegerDovizTipi_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //MAX DEÐER DOVÝZ ID YÝ AL
        //    if (e.Value != null)
        //        MaxDovID = MaxDovizTip_ID_AL(e.Value.ToString(), dtMaxDegerDovizTip);
        //}

        //private void rCb_MinDegDovizTipi_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //MÝN DEÐER DOVÝZ ID YÝ AL
        //    if (e.Value != null)
        //        MinDovizID = MinDoviztip_ID_AL(e.Value.ToString(), dtMinDegerDovizTip);
        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TDI_CET_MIN_MAX_DEGER MinMaxDegerOBJ = new AvukatProLib.Entity.TDI_CET_MIN_MAX_DEGER();
        //        MinMaxDegerOBJ.ACIKLAMA = (e.Row as DataRowView)[2].ToString();
        //        MinMaxDegerOBJ.ACIKLAMA_ID = AciklamaID;
        //        MinMaxDegerOBJ.MAX_DEGER = Convert.ToDecimal((e.Row as DataRowView)[5]);
        //        MinMaxDegerOBJ.MAX_DEGER_DOVIZ = (e.Row as DataRowView)[6].ToString();
        //        MinMaxDegerOBJ.MAX_DEGER_DOVIZ_ID = MaxDovID;
        //        MinMaxDegerOBJ.MIN_DEGER = Convert.ToDecimal((e.Row as DataRowView)[3]);
        //        MinMaxDegerOBJ.MIN_DEGER_DOVIZ = (e.Row as DataRowView)[4].ToString();
        //        MinMaxDegerOBJ.MIN_DEGER_DOVIZ_ID = MinDovizID;
        //        MinMaxDegerOBJ.TARIH = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        MinMaxDegerOBJ.ADMIN_KAYIT_MI = 1;
        //        MinMaxDegerOBJ.KONTROL_KIM = "AVUKATPRO";
        //        MinMaxDegerOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        MinMaxDegerOBJ.KONTROL_VERSIYON = 1;
        //        MinMaxDegerOBJ.STAMP = 1;
        //        MinMaxDegerOBJ.SUBE_KODU = 1;

        //        AvukatProLib.Facade.TDI_CET_MIN_MAX_DEGER.TDI_CET_MIN_MAX_DEGEREkle(MinMaxDegerOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_CET_MIN_MAX_DEGER MinMaxDegerOBJ = new AvukatProLib.Entity.TDI_CET_MIN_MAX_DEGER();
        //        MinMaxDegerOBJ.ACIKLAMA = (e.Row as DataRowView)[2].ToString();
        //        MinMaxDegerOBJ.ACIKLAMA_ID = Convert.ToInt32((e.Row as DataRowView)[9]);
        //        MinMaxDegerOBJ.MAX_DEGER = Convert.ToDecimal((e.Row as DataRowView)[5]);
        //        MinMaxDegerOBJ.MAX_DEGER_DOVIZ = (e.Row as DataRowView)[6].ToString();
        //        MinMaxDegerOBJ.MAX_DEGER_DOVIZ_ID = Convert.ToInt32((e.Row as DataRowView)[8]);
        //        MinMaxDegerOBJ.MIN_DEGER = Convert.ToDecimal((e.Row as DataRowView)[3]);
        //        MinMaxDegerOBJ.MIN_DEGER_DOVIZ = (e.Row as DataRowView)[4].ToString();
        //        MinMaxDegerOBJ.MIN_DEGER_DOVIZ_ID = Convert.ToInt32((e.Row as DataRowView)[7]);
        //        MinMaxDegerOBJ.TARIH = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        MinMaxDegerOBJ.ADMIN_KAYIT_MI = 1;
        //        MinMaxDegerOBJ.KONTROL_KIM = "AVUKATPRO";
        //        MinMaxDegerOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        MinMaxDegerOBJ.KONTROL_VERSIYON = 1;
        //        MinMaxDegerOBJ.STAMP = 1;
        //        MinMaxDegerOBJ.SUBE_KODU = 1;
        //        MinMaxDegerOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);

        //        AvukatProLib.Facade.TDI_CET_MIN_MAX_DEGER.Guncelle(MinMaxDegerOBJ);
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

        //        AvukatProLib.Facade.TDI_CET_MIN_MAX_DEGER.TDI_CET_MIN_MAX_DEGERSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        //private void gridMinMaxDeger_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_CET_MIN_MAX_DEGER.TDI_CET_MIN_MAX_DEGERSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
    }
}