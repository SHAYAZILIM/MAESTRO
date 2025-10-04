using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmVekaletMaktuCetveli : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_MAKTU_VEKALET> MyDataSourceMaktuVekalet = new TList<TDI_CET_MAKTU_VEKALET>();

        public frmVekaletMaktuCetveli()
        {
            InitializeComponent();
        }

        int TLID = 1;

        public void vekaletMaktuGetir()
        {
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            try
            {
                TLID = (int)cn.ExecuteScalar("SELECT isnull(ID,1) FROM dbo.TDI_KOD_DOVIZ_TIP(nolock) WHERE DOVIZ_KODU='TL'");
            }
            catch { ;}

            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.MuhasebeHareketAltKategoriAnakatGetir(lueMaktuKod);

            MyDataSourceMaktuVekalet = AvukatProLib2.Data.DataRepository.TDI_CET_MAKTU_VEKALETProvider.GetAll();
            gridVekaletMaktu.DataSource = MyDataSourceMaktuVekalet;            
        }

        private void gridVekaletMaktu_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                if (e.Button.Tag == "1")
                {
                    frmTopluVekaletMaktuGuncelle frmTopluVekaletMaktu = new frmTopluVekaletMaktuGuncelle();
                    frmTopluVekaletMaktu.ShowDialog();
                }
            }
        }

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
            vekaletMaktuKaydet();
        }

        private void vekaletMaktuKaydet()
        {
            
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_MAKTU_VEKALETProvider.DeepSave(tran, MyDataSourceMaktuVekalet);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, "MIKTAR1_DOVIZ_ID", TLID);
            gridView1.SetRowCellValue(e.RowHandle, "MIKTAR2_DOVIZ_ID", TLID);
            gridView1.SetRowCellValue(e.RowHandle, "OZEL_MIKTAR_DOVIZ_ID", TLID);
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {

        }

        //DataTable dtMaktuKod = null;
        //DataTable dtMiktarDoviz_1 = null;
        //DataTable dtMaktuDoviz_2 = null;
        //DataTable dtOzelMiktarDoviz = null;

        //int MaktuKodID = 0;
        //int MiktarDoviz_1_ID = 0;
        //int MiktarDovi_2_ID = 0;
        //int OzelMiktarID = 0;

        //int GuncelleSilID = 0;
        //bool Yeni = false;

        //internal void VekaletMaktuCetveli()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_CET_MAKTU_VEKALET.VekaletMaktuCetveli();
        //    //gridVekaletMaktu.DataSource = ds.Tables[0];

        //    //TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI
        //    //dtMaktuKod = AvukatProLib.Facade.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI.MaktuKodGETIR();
        //    foreach (DataRow dr in dtMaktuKod.Rows)
        //    {
        //        rCb_MaktuKodAciklama.Items.Add(dr["MAKTU_VEKALET_KOD_NO"].ToString());
        //    }
        //    //TDI_KOD_DOVIZ_TIP
        //    //dtMaktuDoviz_2 = AvukatProLib.Facade.TDI_KOD_DOVIZ_TIP.DovizTipiGetir();
        //    foreach (DataRow dr in dtMaktuDoviz_2.Rows)
        //    {
        //        rCb_Miktar_2_Doviz.Items.Add(dr["DOVIZ_KODU"].ToString());
        //    }
        //    dtMiktarDoviz_1 = dtMaktuDoviz_2.Copy();
        //    dtOzelMiktarDoviz = dtMaktuDoviz_2.Copy();
        //    rCb_Miktar_1_Doviz.Items.Assign(rCb_Miktar_2_Doviz.Items);
        //    rCb_OzelMiktarDoviz.Items.Assign(rCb_Miktar_2_Doviz.Items);

        //}
        //int MaktuKod_ID_AL(string MaktuKodAD, DataTable dtMaktuKodID)
        //{
        //    DataRow[] MaktuKodlar = dtMaktuKodID.Select("MAKTU_VEKALET_KOD_NO='" + MaktuKodAD + "'");
        //    return Convert.ToInt32(MaktuKodlar[0]["ID"]);
        //}
        //int MiktarDoviz_1_ID_AL(string MiktarDovizAD, DataTable dtMiktarDovizID1)
        //{
        //    DataRow[] MiktarDovizler = dtMiktarDovizID1.Select("DOVIZ_KODU='" + MiktarDovizAD + "'");
        //    return Convert.ToInt32(MiktarDovizler[0]["ID"]);
        //}

        //private void rCb_Miktar_1_Doviz_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //MÝKTAR 1 DOVÝZ ID YÝ AL
        //    if(e.Value!=null)
        //        MiktarDoviz_1_ID=MiktarDoviz_1_ID_AL(e.Value.ToString(),dtMiktarDoviz_1);

        //}

        //private void rCb_Miktar_2_Doviz_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //MÝKTAR 2 DOVÝZ ID YÝ AL
        //    if(e.Value!=null)
        //        MiktarDovi_2_ID=MiktarDoviz_1_ID_AL(e.Value.ToString(),dtMaktuDoviz_2);
        //}

        //private void rCb_OzelMiktarDoviz_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //ÖZEL MÝKTAR DOVÝZ ID YÝ AL
        //    if(e.Value!=null)
        //        OzelMiktarID=MiktarDoviz_1_ID_AL(e.Value.ToString(),dtOzelMiktarDoviz);
        //}

        //private void rCb_MaktuKodAciklama_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //MAKTU_KOD_ACIKLAMA KOD AÇIKLAMA ID yi AL
        //    if(e.Value!=null)
        //        MaktuKodID=MaktuKod_ID_AL(e.Value.ToString(),dtMaktuKod);
        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TDI_CET_MAKTU_VEKALET MaktuVekaletOBJ = new AvukatProLib.Entity.TDI_CET_MAKTU_VEKALET();
        //        MaktuVekaletOBJ.BASLANGIC_TARIHI = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        MaktuVekaletOBJ.MAKTU_KOD_ACIKLAMA = (e.Row as DataRowView)[2].ToString();
        //        MaktuVekaletOBJ.MAKTU_KOD_ID = MaktuKodID;
        //        MaktuVekaletOBJ.MIKTAR1 = Convert.ToDecimal((e.Row as DataRowView)[3]);
        //        MaktuVekaletOBJ.MIKTAR1_DOVIZ = (e.Row as DataRowView)[4].ToString();
        //        MaktuVekaletOBJ.MIKTAR1_DOVIZ_ID = MiktarDoviz_1_ID;
        //        MaktuVekaletOBJ.MIKTAR2 = Convert.ToDecimal((e.Row as DataRowView)[5]);
        //        MaktuVekaletOBJ.MIKTAR2_DOVIZ = (e.Row as DataRowView)[6].ToString();
        //        MaktuVekaletOBJ.MIKTAR2_DOVIZ_ID = MiktarDovi_2_ID;
        //        MaktuVekaletOBJ.OZEL_MIKTAR = Convert.ToDecimal((e.Row as DataRowView)[7]);
        //        MaktuVekaletOBJ.OZEL_MIKTAR_DOVIZ = (e.Row as DataRowView)[8].ToString();
        //        MaktuVekaletOBJ.OZEL_MIKTAR_DOVIZ_ID = OzelMiktarID;
        //        MaktuVekaletOBJ.ADMIN_KAYIT_MI = 1;
        //        MaktuVekaletOBJ.KONTROL_KIM = "AVUKATPRO";
        //        MaktuVekaletOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        MaktuVekaletOBJ.KONTROL_VERSIYON = 1;
        //        MaktuVekaletOBJ.STAMP = 1;
        //        MaktuVekaletOBJ.SUBE_KODU = 1;
        //        AvukatProLib.Facade.TDI_CET_MAKTU_VEKALET.TDI_CET_MAKTU_VEKALETEkle(MaktuVekaletOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_CET_MAKTU_VEKALET MaktuVekaletOBJ = new AvukatProLib.Entity.TDI_CET_MAKTU_VEKALET();
        //        MaktuVekaletOBJ.BASLANGIC_TARIHI = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        MaktuVekaletOBJ.MAKTU_KOD_ACIKLAMA = (e.Row as DataRowView)[2].ToString();
        //        MaktuVekaletOBJ.MAKTU_KOD_ID = Convert.ToInt32((e.Row as DataRowView)[9]);
        //        MaktuVekaletOBJ.MIKTAR1 = Convert.ToDecimal((e.Row as DataRowView)[3]);
        //        MaktuVekaletOBJ.MIKTAR1_DOVIZ = (e.Row as DataRowView)[4].ToString();
        //        MaktuVekaletOBJ.MIKTAR1_DOVIZ_ID =Convert.ToInt32((e.Row as DataRowView)[10]);
        //        MaktuVekaletOBJ.MIKTAR2 = Convert.ToDecimal((e.Row as DataRowView)[5]);
        //        MaktuVekaletOBJ.MIKTAR2_DOVIZ = (e.Row as DataRowView)[6].ToString();
        //        MaktuVekaletOBJ.MIKTAR2_DOVIZ_ID = Convert.ToInt32((e.Row as DataRowView)[11]);
        //        MaktuVekaletOBJ.OZEL_MIKTAR = Convert.ToDecimal((e.Row as DataRowView)[7]);
        //        MaktuVekaletOBJ.OZEL_MIKTAR_DOVIZ = (e.Row as DataRowView)[8].ToString();
        //        MaktuVekaletOBJ.OZEL_MIKTAR_DOVIZ_ID = Convert.ToInt32((e.Row as DataRowView)[12]);
        //        MaktuVekaletOBJ.ADMIN_KAYIT_MI = 1;
        //        MaktuVekaletOBJ.KONTROL_KIM = "AVUKATPRO";
        //        MaktuVekaletOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        MaktuVekaletOBJ.KONTROL_VERSIYON = 1;
        //        MaktuVekaletOBJ.STAMP = 1;
        //        MaktuVekaletOBJ.SUBE_KODU = 1;
        //        MaktuVekaletOBJ.ID=Convert.ToInt32((e.Row as DataRowView)[0]);
        //        AvukatProLib.Facade.TDI_CET_MAKTU_VEKALET.Guncelle(MaktuVekaletOBJ);
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

        //        AvukatProLib.Facade.TDI_CET_MAKTU_VEKALET.TDI_CET_MAKTU_VEKALETSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        //private void gridVekaletMaktu_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_CET_MAKTU_VEKALET.TDI_CET_MAKTU_VEKALETSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
    }
}