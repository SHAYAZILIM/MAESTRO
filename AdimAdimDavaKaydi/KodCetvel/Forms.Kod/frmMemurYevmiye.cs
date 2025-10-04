using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmMemurYevmiye : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_MEMUR_YEVMIYE> MyDataSourceMemurYev = new TList<TDI_CET_MEMUR_YEVMIYE>();

        public frmMemurYevmiye()
        {
            InitializeComponent();
        }

        public void memurYevmiyeGetir()
        {
            MyDataSourceMemurYev = AvukatProLib2.Data.DataRepository.TDI_CET_MEMUR_YEVMIYEProvider.GetAll();
            gridMemurYevmiye.DataSource = MyDataSourceMemurYev;
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.YevmiyeKodGetir(rLueYevmiyeKod);
        }

        public void memurYevmiyeKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_MEMUR_YEVMIYEProvider.Save(tran, MyDataSourceMemurYev);
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
            memurYevmiyeKaydet();
        }

        //DataTable dtYevmiye = null;
        //DataTable dtSehirIciDoviz = null;
        //DataTable dtSehirDisiDoviz = null;
        //int GuncelleSilID = 0;
        //int Yevmiye_ID = 0;
        //int SehirIciDoviz_ID = 0;
        //int SehirDisiDoviz_ID = 0;
        //bool Yeni = false;
        //internal void MemurYevmiyeGetir()
        //{
        //    //DataSet ds = AvukatProLib.Facade.TDI_CET_MEMUR_YEVMIYE.MemurYevmiyeCetveli();
        //    //gridMemurYevmiye.DataSource = ds.Tables[0];

        //    //TDI_KOD_DOVIZ_TIP
        //    //dtSehirDisiDoviz = AvukatProLib.Facade.TDI_KOD_DOVIZ_TIP.DovizTipiGetir();
        //    //dtSehirIciDoviz = dtSehirDisiDoviz.Copy();
        //    foreach (DataRow dr in dtSehirDisiDoviz.Rows)
        //    {
        //        rCb_SehirDisiDoviz.Items.Add(dr["DOVIZ_KODU"].ToString());
        //    }
        //    rCb_SehirIciDoviz.Items.Assign(rCb_SehirDisiDoviz.Items);

        //    //TDI_KOD_YEVMIYE
        //    //dtYevmiye = AvukatProLib.Facade.TDI_KOD_YEVMIYE.YevmiyeGETIR_SP();
        //    foreach (DataRow dr in dtYevmiye.Rows)
        //    {
        //        rCb_Yevmiye.Items.Add(dr["TIP"].ToString());
        //    }
        //}
        //int Yevmiye_ID_AL(string YevmiyeAD, DataTable dtYevmiyeID)
        //{
        //    DataRow[] Yevmiyeler = dtYevmiyeID.Select("TIP='" + YevmiyeAD + "'");
        //    return Convert.ToInt32(Yevmiyeler[0]["ID"]);
        //}

        //int DovizTip_ID_AL(string DovizTipAD, DataTable dtDovizTipID)
        //{
        //    DataRow[] DovizTipleri = dtDovizTipID.Select("DOVIZ_KODU='" + DovizTipAD + "'");
        //    return Convert.ToInt32(DovizTipleri[0]["ID"]);
        //}

        //private void gridAdliBirimNumaralari_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    //SÞÝL
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_CET_MEMUR_YEVMIYE.TDI_CET_MEMUR_YEVMIYESil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}
        //private void rCb_Yevmiye_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //YEVMÝYE ID YÝ AL
        //    if (e.Value != null)
        //        Yevmiye_ID = Yevmiye_ID_AL(e.Value.ToString(), dtYevmiye);
        //}

        //private void rCb_SehirIciDoviz_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //ÞEHÝR ÝÇÝ DOVÝZ ID YÝ AL
        //    if (e.Value != null)
        //        SehirIciDoviz_ID = DovizTip_ID_AL(e.Value.ToString(), dtSehirIciDoviz);
        //}

        //private void rCb_SehirDisiDoviz_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //ÞEHÝR DIÞI DOVÝZ ID YÝ AL
        //    if (e.Value != null)
        //        SehirDisiDoviz_ID = DovizTip_ID_AL(e.Value.ToString(), dtSehirDisiDoviz);
        //}
        //private void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.TDI_CET_MEMUR_YEVMIYE.TDI_CET_MEMUR_YEVMIYESil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }
        //}

        //private void gridView5_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void gridView5_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.TDI_CET_MEMUR_YEVMIYE MemurYevmiyeOBJ = new AvukatProLib.Entity.TDI_CET_MEMUR_YEVMIYE();

        //        MemurYevmiyeOBJ.SEHIR_DISI_DEGER = Convert.ToDecimal((e.Row as DataRowView)[5]);
        //        MemurYevmiyeOBJ.SEHIR_DISI_DOVIZ=(e.Row as DataRowView)[6].ToString();
        //        MemurYevmiyeOBJ.SEHIR_DISI_DOVIZ_ID = SehirDisiDoviz_ID;
        //        MemurYevmiyeOBJ.SEHIR_ICI_DEGER=Convert.ToDecimal((e.Row as DataRowView)[3]);
        //        MemurYevmiyeOBJ.SEHIR_ICI_DOVIZ=(e.Row as DataRowView)[4].ToString();
        //        MemurYevmiyeOBJ.SEHIR_ICI_DOVIZ_ID = SehirIciDoviz_ID;
        //        MemurYevmiyeOBJ.TARIH=Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        MemurYevmiyeOBJ.YEVMIYE=(e.Row as DataRowView)[2].ToString();
        //        MemurYevmiyeOBJ.YEVMIYE_ID = Yevmiye_ID;
        //        MemurYevmiyeOBJ.ADMIN_KAYIT_MI = 1;
        //        MemurYevmiyeOBJ.KONTROL_KIM = "AVUKATPRO";
        //        MemurYevmiyeOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        MemurYevmiyeOBJ.KONTROL_VERSIYON = 1;
        //        MemurYevmiyeOBJ.STAMP = 1;
        //        MemurYevmiyeOBJ.SUBE_KODU = 1;
        //        AvukatProLib.Facade.TDI_CET_MEMUR_YEVMIYE.TDI_CET_MEMUR_YEVMIYEEkle(MemurYevmiyeOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.TDI_CET_MEMUR_YEVMIYE MemurYevmiyeOBJ = new AvukatProLib.Entity.TDI_CET_MEMUR_YEVMIYE();

        //        MemurYevmiyeOBJ.SEHIR_DISI_DEGER = Convert.ToDecimal((e.Row as DataRowView)[5]);
        //        MemurYevmiyeOBJ.SEHIR_DISI_DOVIZ = (e.Row as DataRowView)[6].ToString();
        //        MemurYevmiyeOBJ.SEHIR_DISI_DOVIZ_ID =Convert.ToInt32((e.Row as DataRowView)[9]);
        //        MemurYevmiyeOBJ.SEHIR_ICI_DEGER = Convert.ToDecimal((e.Row as DataRowView)[3]);
        //        MemurYevmiyeOBJ.SEHIR_ICI_DOVIZ = (e.Row as DataRowView)[4].ToString();
        //        MemurYevmiyeOBJ.SEHIR_ICI_DOVIZ_ID = Convert.ToInt32((e.Row as DataRowView)[8]);
        //        MemurYevmiyeOBJ.TARIH = Convert.ToDateTime((e.Row as DataRowView)[1]);
        //        MemurYevmiyeOBJ.YEVMIYE = (e.Row as DataRowView)[2].ToString();
        //        MemurYevmiyeOBJ.YEVMIYE_ID = Convert.ToInt32((e.Row as DataRowView)[7]);
        //        MemurYevmiyeOBJ.ADMIN_KAYIT_MI = 1;
        //        MemurYevmiyeOBJ.KONTROL_KIM = "AVUKATPRO";
        //        MemurYevmiyeOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        MemurYevmiyeOBJ.KONTROL_VERSIYON = 1;
        //        MemurYevmiyeOBJ.STAMP = 1;
        //        MemurYevmiyeOBJ.SUBE_KODU = 1;
        //        MemurYevmiyeOBJ.ID=Convert.ToInt32((e.Row as DataRowView)[0]);

        //        AvukatProLib.Facade.TDI_CET_MEMUR_YEVMIYE.Guncelle(MemurYevmiyeOBJ);
        //        MessageBox.Show("GÜNCELLEME ÝÞLEMÝ TAMAM");
        //    }

        //    Yeni = false;
        //}
    }
}