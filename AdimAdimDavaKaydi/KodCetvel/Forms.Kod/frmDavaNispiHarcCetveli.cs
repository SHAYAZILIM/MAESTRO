using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmDavaNispiHarcCetveli : DevExpress.XtraEditors.XtraForm
    {
        private TList<TD_CET_NISPI_HARC> MyDataSourceNispiHArc = new TList<TD_CET_NISPI_HARC>();

        private TList<TI_CET_NISPI_HARC> MyDataSourceNispiHArcIcra = new TList<TI_CET_NISPI_HARC>();

        public frmDavaNispiHarcCetveli()
        {
            InitializeComponent();
        }

        public void nispiHarcGetir()
        {
            MyDataSourceNispiHArcIcra = null;
            MyDataSourceNispiHArc = AvukatProLib2.Data.DataRepository.TD_CET_NISPI_HARCProvider.GetAll();
            gridDavaNizpiHarcCetveli.DataSource = MyDataSourceNispiHArc;
            BelgeUtil.Inits.DavaHarcTipiGetir(lueHarcKod);

            //Inits.YuzdeBicimiAyarla(spYuzdeOran);
            BelgeUtil.Inits.BindeYuzdeGetir(lueBindeYuzde);
        }

        public void nispiHarcGetirIcra()
        {
            MyDataSourceNispiHArc = null;
            MyDataSourceNispiHArcIcra = AvukatProLib2.Data.DataRepository.TI_CET_NISPI_HARCProvider.GetAll();
            gridDavaNizpiHarcCetveli.DataSource = MyDataSourceNispiHArcIcra;

            //Inits.YuzdeBicimiAyarla(spYuzdeOran);
            BelgeUtil.Inits.IcraHarcTipiGetir(lueHarcKod);
            BelgeUtil.Inits.BindeYuzdeGetir(lueBindeYuzde);
        }

        public void nispiHarcKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    if (MyDataSourceNispiHArc != null)
                        DataRepository.TD_CET_NISPI_HARCProvider.Save(tran, MyDataSourceNispiHArc);
                    else if (MyDataSourceNispiHArcIcra != null)
                        DataRepository.TI_CET_NISPI_HARCProvider.Save(tran, MyDataSourceNispiHArcIcra);
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

        private void gridDavaNizpiHarcCetveli_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == "1")
            {
                if (MyDataSourceNispiHArc == null)
                {
                    frmIcraNispiHarcCetveliGuncelleme frmDavaNispiHarc = new frmIcraNispiHarcCetveliGuncelleme();
                    frmDavaNispiHarc.ShowDialog();
                }
                else if (MyDataSourceNispiHArcIcra == null)
                {
                    frmTopluDavaNispiHarcGuncelleme frmIcraNispiHarc = new frmTopluDavaNispiHarcGuncelleme();
                    frmIcraNispiHarc.ShowDialog();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            nispiHarcKaydet();
        }

        //DataTable dtNispiHarc = null;
        //internal void DavaNispiHarcGetir()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TD_CET_NISPI_HARC.DavaNisbiHarcCetvelGetir();
        //    //gridDavaNizpiHarcCetveli.DataSource = ds.Tables[0];

        //    //DAVA Nispi Harc Kodlarýný Comboya
        //    //TD_CET_NISPI_HARC
        //    //dtNispiHarc = AvukatProLib.Facade.TD_CET_NISPI_HARC.HarcAdKodGETIR();
        //    foreach (DataRow dr in dtNispiHarc.Rows)
        //    {
        //        rCb_HarcAd.Items.Add(dr["HARC_ADI"].ToString());
        //    }
        //}
        //int HarcKodID = 0;
        //int HArcKodu_AL(string HarcKodu, DataTable dtHarcKodID)
        //{
        //    DataRow[] HarcKodlari = dtHarcKodID.Select("HARC_ADI='" + HarcKodu + "'");
        //    return Convert.ToInt32(HarcKodlari[0]["HARC_KOD_ID"]);
        //}
        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        //EKLE
        //        AvukatProLib.Entity.TD_CET_NISPI_HARC DavaNispiHarcOBJ = new AvukatProLib.Entity.TD_CET_NISPI_HARC();
        //        DavaNispiHarcOBJ.HARC_ADI = (e.Row as DataRowView)[2].ToString();
        //        DavaNispiHarcOBJ.HARC_KOD_ID = HarcKodID;
        //        DavaNispiHarcOBJ.ORAN = Convert.ToSingle((e.Row as DataRowView)[4]);
        //        DavaNispiHarcOBJ.TARIH = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        DavaNispiHarcOBJ.YUZDE_BINDE = Convert.ToByte((e.Row as DataRowView)[3]);
        //        DavaNispiHarcOBJ.ADMIN_KAYIT_MI = 1;
        //        DavaNispiHarcOBJ.KONTROL_KIM = "AVUKATPRO";
        //        DavaNispiHarcOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        DavaNispiHarcOBJ.KONTROL_VERSIYON = 1;
        //        DavaNispiHarcOBJ.STAMP = 1;
        //        DavaNispiHarcOBJ.SUBE_KODU = 1;

        //        AvukatProLib.Facade.TD_CET_NISPI_HARC.TD_CET_NISPI_HARCEkle(DavaNispiHarcOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");
        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TD_CET_NISPI_HARC DavaNispiHarcOBJ = new AvukatProLib.Entity.TD_CET_NISPI_HARC();
        //        DavaNispiHarcOBJ.HARC_ADI = (e.Row as DataRowView)[2].ToString();
        //        DavaNispiHarcOBJ.HARC_KOD_ID = HarcKodID;
        //        DavaNispiHarcOBJ.ORAN = Convert.ToSingle((e.Row as DataRowView)[4]);
        //        DavaNispiHarcOBJ.TARIH = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        DavaNispiHarcOBJ.YUZDE_BINDE = Convert.ToByte((e.Row as DataRowView)[3]);
        //        DavaNispiHarcOBJ.ADMIN_KAYIT_MI = 1;
        //        DavaNispiHarcOBJ.KONTROL_KIM = "AVUKATPRO";
        //        DavaNispiHarcOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        DavaNispiHarcOBJ.KONTROL_VERSIYON = 1;
        //        DavaNispiHarcOBJ.STAMP = 1;
        //        DavaNispiHarcOBJ.SUBE_KODU = 1;
        //        DavaNispiHarcOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);

        //        AvukatProLib.Facade.TD_CET_NISPI_HARC.Guncelle(DavaNispiHarcOBJ);
        //        MessageBox.Show("GÜNCELLEME ÝÞLEMÝ TAMAM");
        //    }
        //    Yeni = true;

        //}

        //private void rCb_HarcAd_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //HARC IDYÝ AL
        //    HarcKodID = HArcKodu_AL(e.Value.ToString(), dtNispiHarc);
        //}
        //bool Yeni = false;
        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    //SÝL
        //    MessageBox.Show("Bu Kayýda Ait Belgeler/Kayýtlar Var..\nBu Kayýt Silinemez..");
        //}

        //private void gridDavaNizpiHarcCetveli_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    MessageBox.Show("Bu Kayýda Ait Belgeler/Kayýtlar Var..\nBu Kayýt Silinemez..");
        //}
    }
}