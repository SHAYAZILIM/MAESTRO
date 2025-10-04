using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmYediEminUcretiMaktu : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_YEDIEMIN_MAKTU_UCRET> myDataSource = new TList<TDI_CET_YEDIEMIN_MAKTU_UCRET>();

        public frmYediEminUcretiMaktu()
        {
            InitializeComponent();
        }

        public void yeddiMaktuUcretDoldur()
        {
            myDataSource = DataRepository.TDI_CET_YEDIEMIN_MAKTU_UCRETProvider.GetAll();
            gridYeddiEminCetveli.DataSource = myDataSource;
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.AracTipGetir(rLueAracTip);
        }

        private void gridYeddiEminCetveli_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                if (e.Button.Tag == "1")
                {
                    frmTopluYeddiEminMaktuGuncelle frmYeddiEminMaktu = new frmTopluYeddiEminMaktuGuncelle();
                    frmYeddiEminMaktu.ShowDialog();
                }
            }
        }

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
            yeddiMaktuUcretKaydet();
        }

        private void yeddiMaktuUcretKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_YEDIEMIN_MAKTU_UCRETProvider.Save(tran, myDataSource);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }

        //DataTable dtAracTip = null;
        //DataTable dtOzelDoviz = null;
        //DataTable dtBakanlikDoviz = null;

        //int AracTipID = 0;
        ////int OzelDovizID = 0;
        //int BakanlikOzelID = 0;
        //int GuncelleSilID = 0;
        //bool Yeni = false;
        //internal void YeddiEminUcretleri()
        //{
        //    TList<TDI_CET_YEDIEMIN_MAKTU_UCRET> MyDataSourceYeddiEminMaktu = new TList<TDI_CET_YEDIEMIN_MAKTU_UCRET>();
        //    MyDataSourceYeddiEminMaktu = AvukatProLib2.Data.DataRepository.TDI_CET_YEDIEMIN_MAKTU_UCRETProvider.GetAll();
        //    gridYeddiEminCetveli.DataSource = MyDataSourceYeddiEminMaktu;
        //    //DataSet ds = AvukatProLib.Facade.TDI_CET_YEDIEMIN_MAKTU_UCRET.YeddiEminMaktu();
        //    //gridYeddiEminCetveli.DataSource = ds.Tables[0];

        //    //TDI_KOD_ARAC_TIP
        //    //TDI_KOD_DOVIZ_TIP
        //    //dtAracTip = AvukatProLib.Facade.TDI_KOD_ARAC_TIP.AracTipGETIR();
        //    foreach (DataRow dr in dtAracTip.Rows)
        //    {
        //        rCb_AracTip.Items.Add(dr["TIP"].ToString());
        //    }
        //    dtBakanlikDoviz = AvukatProLib.Facade.TDI_KOD_DOVIZ_TIP.DovizTipiGetir();
        //    dtOzelDoviz = dtBakanlikDoviz.Copy();
        //    foreach (DataRow dr in dtBakanlikDoviz.Rows)
        //    {
        //        rCb_BakanlikDoviz.Items.Add(dr["DOVIZ_KODU"].ToString());
        //    }
        //    rCb_OzelDovizTip.Items.Assign(rCb_BakanlikDoviz.Items);

        //}

        //int AracTip_ID_AL(string AracTipAD, DataTable DTaRACtiPid)
        //{
        //    DataRow[] AracTipler = DTaRACtiPid.Select("TIP='" + AracTipAD + "'");
        //    return Convert.ToInt32(AracTipler[0]["ID"]);
        //}
        //int DovizTip_ID_AL(string DovizTipAD, DataTable dtDoviztipID)
        //{
        //    DataRow[] DovizTipleri = dtDoviztipID.Select("DOVIZ_KODU='" + DovizTipAD + "'");
        //    return Convert.ToInt32(DovizTipleri[0]["ID"]);
        //}

        //private void rCb_AracTip_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //ARAÇ TÝP ID YÝ AL
        //}

        //private void rCb_OzelDovizTip_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //ÖZEL DOVÝZ TÝP ID YÝ AL
        //}

        //private void rCb_BakanlikDoviz_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //BAKANLIK DOVÝZ TÝP ID YÝ AL
        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TDI_CET_YEDIEMIN_MAKTU_UCRET YeddiEminUcretOBJ = new AvukatProLib.Entity.TDI_CET_YEDIEMIN_MAKTU_UCRET();
        //        YeddiEminUcretOBJ.BAKANLIK_BEDEL =Convert.ToDecimal((e.Row as DataRowView)[5]);
        //        YeddiEminUcretOBJ.BAKANLIK_DOVIZ = (e.Row as DataRowView)[6].ToString();
        //        YeddiEminUcretOBJ.BAKANLIK_DOVIZ_ID = BakanlikOzelID;
        //        YeddiEminUcretOBJ.OZEL_BEDEL = Convert.ToDecimal((e.Row as DataRowView)[4]);
        //        YeddiEminUcretOBJ.OZEL_DOVIZ = (e.Row as DataRowView)[4].ToString();
        //        YeddiEminUcretOBJ.OZEL_DOVIZ_ID = Convert.ToInt32((e.Row as DataRowView)[9]);
        //        YeddiEminUcretOBJ.TARIH = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        YeddiEminUcretOBJ.TIP = (e.Row as DataRowView)[2].ToString();
        //        YeddiEminUcretOBJ.TIP_ID = AracTipID;
        //        YeddiEminUcretOBJ.ADMIN_KAYIT_MI = 1;
        //        YeddiEminUcretOBJ.KONTROL_KIM = "AVUKATPRO";
        //        YeddiEminUcretOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        YeddiEminUcretOBJ.KONTROL_VERSIYON = 1;
        //        YeddiEminUcretOBJ.STAMP = 1;
        //        YeddiEminUcretOBJ.SUBE_KODU = 1;
        //        AvukatProLib.Facade.TDI_CET_YEDIEMIN_MAKTU_UCRET.TDI_CET_YEDIEMIN_MAKTU_UCRETEkle(YeddiEminUcretOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_CET_YEDIEMIN_MAKTU_UCRET YeddiEminUcretOBJ = new AvukatProLib.Entity.TDI_CET_YEDIEMIN_MAKTU_UCRET();
        //        YeddiEminUcretOBJ.BAKANLIK_BEDEL = Convert.ToDecimal((e.Row as DataRowView)[5]);
        //        YeddiEminUcretOBJ.BAKANLIK_DOVIZ = (e.Row as DataRowView)[6].ToString();
        //        YeddiEminUcretOBJ.BAKANLIK_DOVIZ_ID = Convert.ToInt32((e.Row as DataRowView)[8]);
        //        YeddiEminUcretOBJ.OZEL_BEDEL = Convert.ToDecimal((e.Row as DataRowView)[4]);
        //        YeddiEminUcretOBJ.OZEL_DOVIZ = (e.Row as DataRowView)[4].ToString();
        //        YeddiEminUcretOBJ.OZEL_DOVIZ_ID = Convert.ToInt32((e.Row as DataRowView)[9]);
        //        YeddiEminUcretOBJ.TARIH = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        YeddiEminUcretOBJ.TIP = (e.Row as DataRowView)[2].ToString();
        //        YeddiEminUcretOBJ.TIP_ID = Convert.ToInt32((e.Row as DataRowView)[7]);
        //        YeddiEminUcretOBJ.ADMIN_KAYIT_MI = 1;
        //        YeddiEminUcretOBJ.KONTROL_KIM = "AVUKATPRO";
        //        YeddiEminUcretOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        YeddiEminUcretOBJ.KONTROL_VERSIYON = 1;
        //        YeddiEminUcretOBJ.STAMP = 1;
        //        YeddiEminUcretOBJ.SUBE_KODU = 1;
        //        YeddiEminUcretOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);
        //        AvukatProLib.Facade.TDI_CET_YEDIEMIN_MAKTU_UCRET.Guncelle(YeddiEminUcretOBJ);
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

        //        AvukatProLib.Facade.TDI_CET_YEDIEMIN_MAKTU_UCRET.TDI_CET_YEDIEMIN_MAKTU_UCRETSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        //private void gridYeddiEminCetveli_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_CET_YEDIEMIN_MAKTU_UCRET.TDI_CET_YEDIEMIN_MAKTU_UCRETSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
    }
}