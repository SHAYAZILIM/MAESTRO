using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmDavaMaktuHarcCetveli : DevExpress.XtraEditors.XtraForm
    {
        private TList<TD_CET_HARC_MAKTU> MyDataSourceHarcMaktu = new TList<TD_CET_HARC_MAKTU>();

        private TList<TI_CET_HARC_MAKTU> MyDataSourceHarcMaktuIcra = new TList<TI_CET_HARC_MAKTU>();

        public frmDavaMaktuHarcCetveli()
        {
            InitializeComponent();
        }

        public void maktuDavaHarcGetir()
        {
            MyDataSourceHarcMaktuIcra = null;
            MyDataSourceHarcMaktu = AvukatProLib2.Data.DataRepository.TD_CET_HARC_MAKTUProvider.GetAll();
            gridDavaMaktuHarc.DataSource = MyDataSourceHarcMaktu;

            //TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI
            BelgeUtil.Inits.MuhasebeHareketAltKategori(lueHarcKod);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.ParaBicimiAyarla(repositoryItemSpinEdit1);
        }

        public void maktuHarcKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    if (MyDataSourceHarcMaktu != null)
                        DataRepository.TD_CET_HARC_MAKTUProvider.Save(tran, MyDataSourceHarcMaktu);
                    else if (MyDataSourceHarcMaktuIcra != null)
                        DataRepository.TI_CET_HARC_MAKTUProvider.Save(tran, MyDataSourceHarcMaktuIcra);
                    tran.Commit();
                    MessageBox.Show("Kayýtlar baþarýyla kaydedildi.");
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

        public void maktuIcraHarcGetir()
        {
            MyDataSourceHarcMaktu = null;
            MyDataSourceHarcMaktuIcra = AvukatProLib2.Data.DataRepository.TI_CET_HARC_MAKTUProvider.GetAll();
            gridDavaMaktuHarc.DataSource = MyDataSourceHarcMaktuIcra;
            BelgeUtil.Inits.MuhasebeHareketAltKategoriAnakatGetir(lueHarcKod);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.ParaBicimiAyarla(repositoryItemSpinEdit1);
        }

        private void gridDavaMaktuHarc_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                if (e.Button.Tag == "1")
                {
                    if (MyDataSourceHarcMaktuIcra == null)
                    {
                        frmTopluDavaMaktuHarcGuncelle frmDavaMaktuHarc = new frmTopluDavaMaktuHarcGuncelle();
                        frmDavaMaktuHarc.ShowDialog();
                    }
                    else if (MyDataSourceHarcMaktu == null)
                    {
                        frmTopluIcraHarcMaktuGuncelle frmIcraMaktuHarc = new frmTopluIcraHarcMaktuGuncelle();
                        frmIcraMaktuHarc.ShowDialog();
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            maktuHarcKaydet();
        }

        //DataTable dtDovizTipleri = null;
        //DataTable dtHarcKodlari = null;
        //internal void HarcMaktuGetir()
        //{
        //    //TI facade sinde ama TD den çektiriyorum KARIÞMASIN ..
        //    //DataSet ds = AvukatProLib.Facade.TD_CET_HARC_MAKTU.TD_CET_HARC_MAKTUGetir();
        //    //gridDavaMaktuHarc.DataSource = ds.Tables[0];

        //    //Dovizleri Comboya
        //    dtDovizTipleri = AvukatProLib.Facade.TDI_KOD_DOVIZ_TIP.DovizTipiGetir();
        //    foreach (DataRow dr in dtDovizTipleri.Rows)
        //    {
        //        rCb_DovizTipi.Items.Add(dr["DOVIZ_KODU"].ToString());
        //    }
        //    ////Harc Kodlarý Comboya
        //    //dtHarcKodlari = AvukatProLib.Facade.TD_CET_HARC_MAKTU.HarcKodAciklama();
        //    foreach (DataRow dr in dtHarcKodlari.Rows)
        //    {
        //        rCb_Harc_Kod.Items.Add(dr["HARC_KOD_ACIKLAMA"].ToString());
        //    }
        //}
        //int DovizID = 0;
        //int HarcKodID = 0;

        ////Doviz Tipinin ID sini ALDIK
        //int DovizTipID_AL(string DovizTip, DataTable dtDovizTipID)
        //{
        //    DataRow[] DovizTipleri = dtDovizTipID.Select("DOVIZ_KODU='" + DovizTip + "'");
        //    return Convert.ToInt32(DovizTipleri[0]["ID"]);
        //}
        //int HarcKoduID_AL(string HarcKodu, DataTable dtHArcKodID)
        //{
        //    DataRow[] HarcKodlari = dtHArcKodID.Select("HARC_KOD_ACIKLAMA='" + HarcKodu + "'");
        //    return Convert.ToInt32(HarcKodlari[0]["HARC_KOD_ID"]);
        //}
        ////
        ////

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        //EKLE
        //        AvukatProLib.Entity.TD_CET_HARC_MAKTU MaktuHarcOBJ = new AvukatProLib.Entity.TD_CET_HARC_MAKTU();
        //        MaktuHarcOBJ.DEGER = Convert.ToDecimal((e.Row as DataRowView)[3]);
        //        MaktuHarcOBJ.DOVIZ = (e.Row as DataRowView)[2].ToString();
        //        MaktuHarcOBJ.DOVIZ_ID = DovizID;
        //        MaktuHarcOBJ.HARC_KOD_ACIKLAMA = (e.Row as DataRowView)[1].ToString();
        //        MaktuHarcOBJ.HARC_KOD_ID = HarcKodID;
        //        MaktuHarcOBJ.TARIH = Convert.ToDateTime((e.Row as DataRowView)[4]);
        //        MaktuHarcOBJ.ADMIN_KAYIT_MI = 1;
        //        MaktuHarcOBJ.KONTROL_KIM = "AVUKATPRO";
        //        MaktuHarcOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        MaktuHarcOBJ.KONTROL_VERSIYON = 1;
        //        MaktuHarcOBJ.STAMP = 1;
        //        MaktuHarcOBJ.SUBE_KODU = 1;

        //        AvukatProLib.Facade.TD_CET_HARC_MAKTU.TD_CET_HARC_MAKTUEkle(MaktuHarcOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");
        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TD_CET_HARC_MAKTU MaktuHarcOBJ = new AvukatProLib.Entity.TD_CET_HARC_MAKTU();
        //        MaktuHarcOBJ.DEGER = Convert.ToDecimal((e.Row as DataRowView)[3]);
        //        MaktuHarcOBJ.DOVIZ = (e.Row as DataRowView)[2].ToString();
        //        MaktuHarcOBJ.DOVIZ_ID = DovizID;
        //        MaktuHarcOBJ.HARC_KOD_ACIKLAMA = (e.Row as DataRowView)[1].ToString();
        //        MaktuHarcOBJ.HARC_KOD_ID = HarcKodID;
        //        MaktuHarcOBJ.TARIH = Convert.ToDateTime((e.Row as DataRowView)[4]);
        //        MaktuHarcOBJ.ADMIN_KAYIT_MI = 1;
        //        MaktuHarcOBJ.KONTROL_KIM = "AVUKATPRO";
        //        MaktuHarcOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        MaktuHarcOBJ.KONTROL_VERSIYON = 1;
        //        MaktuHarcOBJ.STAMP = 1;
        //        MaktuHarcOBJ.SUBE_KODU = 1;
        //        MaktuHarcOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);

        //        AvukatProLib.Facade.TD_CET_HARC_MAKTU.Guncelle(MaktuHarcOBJ);
        //        MessageBox.Show("GÜNCELLEME ÝÞLEMÝ TAMAM");
        //    }

        //    Yeni = false;
        //}

        //private void rCb_DovizTipi_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //DOVIZ TIPI YAKALA
        //    DovizID = DovizTipID_AL(e.Value.ToString(), dtDovizTipleri);
        //    //MessageBox.Show("Doviz Tip ID " + "    " + DovizID);

        //}
        //private void rCb_Harc_Kod_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //HARC KODU YAKALA
        //    HarcKodID= HarcKoduID_AL(e.Value.ToString(), dtHarcKodlari);
        //    //MessageBox.Show("HArc Kod Açýklama ID " + "    " + HarcKodID);
        //}
        //bool Yeni = false;
        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    //SÝL
        //    MessageBox.Show("Bu Kayýda ait Belge/Kayýt Bulunmakta\nBu Kayýt Silinemez..");
        //}

        //private void gridDavaMaktuHarc_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    MessageBox.Show("Bu Kayýda ait Belge/Kayýt Bulunmakta\nBu Kayýt Silinemez..");
        //}
    }
}