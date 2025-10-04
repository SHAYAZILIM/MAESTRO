using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmEvrakGiderCetveli : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_EVRAK_GIDER> MydataSourceEvrakGider = new TList<TDI_CET_EVRAK_GIDER>();

        public frmEvrakGiderCetveli()
        {
            InitializeComponent();
        }

        public void evrakGiderCetvelGetir()
        {
            MydataSourceEvrakGider = AvukatProLib2.Data.DataRepository.TDI_CET_EVRAK_GIDERProvider.GetAll();
            gridEvrakGiderCetveli.DataSource = MydataSourceEvrakGider;
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.MuhasebeHareketAltKategoriAnakatGetir(rLueMuhasebeAltKategori);
        }

        public void evrakGiderCetvelKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_EVRAK_GIDERProvider.Save(tran, MydataSourceEvrakGider);
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

        private void gridEvrakGiderCetveli_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                if (e.Button.Tag == "1")
                {
                    frmTopluEvrakGiderGuncelle frmTopluEvrakGider = new frmTopluEvrakGiderGuncelle();
                    frmTopluEvrakGider.ShowDialog();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            evrakGiderCetvelKaydet();
        }

        //DataTable dtAltKategori = null;
        //DataTable dtDovizTip = null;
        //internal void EvrakGiderCetvel()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_CET_EVRAK_GIDER.EvrakGiderCetvel();
        //    //gridEvrakGiderCetveli.DataSource = ds.Tables[0];

        //    //dtAltKategori = AvukatProLib.Facade.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI.AltKategoriGetir();
        //    foreach (DataRow dr in dtAltKategori.Rows)
        //    {
        //        rCb_AltKategori.Items.Add(dr["ALT_KATEGORI"].ToString());
        //    }

        //    dtDovizTip = AvukatProLib.Facade.TDI_KOD_DOVIZ_TIP.DovizTipiGetir();
        //    foreach (DataRow dr in dtDovizTip.Rows)
        //    {
        //        rCb_GiderDovizTip.Items.Add(dr["DOVIZ_KODU"].ToString());
        //    }
        //}
        //int AltKategori_ID_AL(string AltKategoriAD, DataTable dtAltKategoriID)
        //{
        //    DataRow[] AltKategoriler = dtAltKategoriID.Select("ALT_KATEGORI='" + AltKategoriAD + "'");
        //    return Convert.ToInt32(AltKategoriler[0]["ID"]);
        //}
        //int DovizTipKod_ID_AL(string DovizTipKod, DataTable dtDovizTipKodID)
        //{
        //    DataRow[] DovizKodlari = dtDovizTipKodID.Select("DOVIZ_KODU='" + DovizTipKod + "'");
        //    return Convert.ToInt32(DovizKodlari[0]["ID"]);
        //}
        //int DovizTipID = 0;
        //int AltKategoriID = 0;
        //int GuncelleSilID = 0;
        //bool Yeni = false;

        //private void rCb_GiderDovizTip_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //DÖVÝZ TÝP ID AL
        //    if(e.Value!=null)
        //    {
        //        DovizTipID = DovizTipKod_ID_AL(e.Value.ToString(), dtDovizTip);
        //    }
        //}

        //private void rCb_AltKategori_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //ALT KATEGORÝ ID AL
        //    if (e.Value != null)
        //    {
        //        AltKategoriID = AltKategori_ID_AL(e.Value.ToString(), dtAltKategori);
        //    }

        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TDI_CET_EVRAK_GIDER EvrakGiderOBJ = new AvukatProLib.Entity.TDI_CET_EVRAK_GIDER();
        //        EvrakGiderOBJ.ALT_KATEGORI = (e.Row as DataRowView)[2].ToString();
        //        EvrakGiderOBJ.ALT_KATEGORI_ID = AltKategoriID;
        //        EvrakGiderOBJ.BASLANGIC_TARIHI = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        EvrakGiderOBJ.GIDER_DOVIZ = (e.Row as DataRowView)[4].ToString();
        //        EvrakGiderOBJ.GIDER_DOVIZ_ID = DovizTipID;
        //        EvrakGiderOBJ.MIKTAR = Convert.ToSingle((e.Row as DataRowView)[3]);
        //        EvrakGiderOBJ.ADMIN_KAYIT_MI = 1;
        //        EvrakGiderOBJ.KONTROL_KIM = "AVUKATPRO";
        //        EvrakGiderOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        EvrakGiderOBJ.KONTROL_VERSIYON = 1;
        //        EvrakGiderOBJ.STAMP = 1;
        //        EvrakGiderOBJ.SUBE_KODU = 1;

        //        AvukatProLib.Facade.TDI_CET_EVRAK_GIDER.TDI_CET_EVRAK_GIDEREkle(EvrakGiderOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");
        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_CET_EVRAK_GIDER EvrakGiderOBJ = new AvukatProLib.Entity.TDI_CET_EVRAK_GIDER();
        //        EvrakGiderOBJ.ALT_KATEGORI = (e.Row as DataRowView)[2].ToString();
        //        EvrakGiderOBJ.ALT_KATEGORI_ID = Convert.ToInt32((e.Row as DataRowView)[5]);
        //        EvrakGiderOBJ.BASLANGIC_TARIHI = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        EvrakGiderOBJ.GIDER_DOVIZ = (e.Row as DataRowView)[4].ToString();
        //        EvrakGiderOBJ.GIDER_DOVIZ_ID = Convert.ToInt32((e.Row as DataRowView)[6]);
        //        EvrakGiderOBJ.MIKTAR = Convert.ToSingle((e.Row as DataRowView)[3]);
        //        EvrakGiderOBJ.ADMIN_KAYIT_MI = 1;
        //        EvrakGiderOBJ.KONTROL_KIM = "AVUKATPRO";
        //        EvrakGiderOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        EvrakGiderOBJ.KONTROL_VERSIYON = 1;
        //        EvrakGiderOBJ.STAMP = 1;
        //        EvrakGiderOBJ.SUBE_KODU = 1;
        //        EvrakGiderOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);

        //        AvukatProLib.Facade.TDI_CET_EVRAK_GIDER.Guncelle(EvrakGiderOBJ);
        //        MessageBox.Show("GÜNCELLEME ÝÞLEMÝ TAMAM");
        //    }
        //    Yeni = false;
        //}

        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_DAVA_OZEL_KOD.TDI_KOD_DAVA_OZEL_KODSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        //private void gridEvrakGiderCetveli_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_KOD_DAVA_OZEL_KOD.TDI_KOD_DAVA_OZEL_KODSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
    }
}