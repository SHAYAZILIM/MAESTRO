using System;
using System.Windows.Forms;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi
{
    public partial class ucTemsilTaraf : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucTemsilTaraf()
        {
            InitializeComponent();
        }

        #region MyRegion

        //DataTable dtTarafCari = null;
        //DataTable dtTemsilTipi = null;
        //DataTable dtYetliciCari_1 = null;
        //DataTable dtYetliciCari_2 = null;
        //DataTable dtYetliciCari_3 = null;
        //DataTable dtVSES = null;

        //int TarafCariID = 0;
        //int TemsilTipiID = 0;
        //int YetkiliCari_1_ID = 0;
        //int YetkiliCari_2_ID = 0;
        //int YetkiliCari_3_ID = 0;
        //int VSES_ID = 0;

        //int GuncelleSilID = 0;
        //bool Yeni = false;

        #endregion MyRegion

        public TList<AV001_TDI_BIL_TEMSIL_TARAF> MyDataSource
        {
            get { return gridTemsilTaraf.DataSource as TList<AV001_TDI_BIL_TEMSIL_TARAF>; }
            set
            {
                gridTemsilTaraf.DataSource = value;
                vgTemsilTaraf.DataSource = gridTemsilTaraf.DataSource;
            }
        }

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (vgTemsilTaraf.Visible)
            {
                vgTemsilTaraf.Visible = false;
                gridTemsilTaraf.Visible = true;
                vgTemsilTaraf.BringToFront();
            }
            else
            {
                vgTemsilTaraf.Visible = true;
                gridTemsilTaraf.Visible = false;
                gridTemsilTaraf.BringToFront();
            }
        }

        private void dataNavigatorExtended1_OnListedenGetirClick(object sender,
                                                                 AdimAdimDavaKaydi.Util.ListedenGetirEventArgs e)
        {
        }

        private void rlueCari_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit lue = (DevExpress.XtraEditors.LookUpEdit)sender;

            if ((e.Button.Tag as string) == "Yeni")
            {
                frmCariGenelGiris frm = new frmCariGenelGiris();
                frm.tmpCariAd = lue.Text;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += delegate
                {
                    DialogResult dr = frm.KayitBasarili;
                    if (dr == System.Windows.Forms.DialogResult.OK)
                        BelgeUtil.Inits.perCariGetir(rlueCari);
                };
            }
        }

        private void ucTemsilTaraf_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            try
            {
                #region MyRegion

                //gridTemsilTaraf.ButtonCevirClick += new EventHandler<NavigatorButtonClickEventArgs>(gridTemsilTaraf_ButtonCevirClick);
                //vgTemsilTaraf.ButtonCevirClick += new EventHandler<NavigatorButtonClickEventArgs>(gridTemsilTaraf_ButtonCevirClick);

                #endregion MyRegion

                BelgeUtil.Inits.perCariGetir(rlueCari);
                BelgeUtil.Inits.TemsilTipiGetir(rlueTemsilTip);
                BelgeUtil.Inits.TemsilSonaErmeSebepGetir(rlueVsesTip);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }

            #region TODO:AvukatProLib2 ye geçir

            ////LOAD DADOLDUR
            ////TODO:AvukatProLib2 ye geçir
            ////DataSet ds = AvukatProLib.Facade.AV001_TDI_BIL_TEMSIL_TARAF.TemsilTarafGETIR();
            ////gridTemsilTaraf.DataSource = ds.Tables[0];

            //dtTarafCari = AvukatProLib.Facade.AV001_TDI_BIL_CARI.AV001_TDI_BIL_CARIGetir();
            //dtYetliciCari_1 = dtTarafCari.Copy();
            //dtYetliciCari_2 = dtTarafCari.Copy();
            //dtYetliciCari_3 = dtTarafCari.Copy();
            //foreach (DataRow dr in dtTarafCari.Rows)
            //{
            //    rCb_CariAd.Items.Add(dr["AD"].ToString());
            //}
            //rCb_YetkiliCariAd.Items.Assign(rCb_CariAd.Items);
            //rCb_YetkiliCariAd2.Items.Assign(rCb_CariAd.Items);
            //rCb_YetkiliCariAd_3.Items.Assign(rCb_CariAd.Items);

            ////TDI_KOD_TEMSIL_TIP
            ////TODO:AvukatProLib2 ye geçir
            ////dtTemsilTipi = AvukatProLib.Facade.TDI_KOD_TEMSIL_TIP.TemsilTipleriGETIR();
            //foreach (DataRow dr in dtTemsilTipi.Rows)
            //{
            //    rCb_TemsilTipi.Items.Add(dr["TIP"].ToString());
            //}
            ////TDI_KOD_TEMSIL_SONA_ERME_SEBEP
            ////TODO:AvukatProLib2 ye geçir
            ////dtVSES = AvukatProLib.Facade.TDI_KOD_TEMSIL_SONA_ERME_SEBEP.TemsilSonaErmeSebelerGETIR();
            //foreach (DataRow dr in dtVSES.Rows)
            //{
            //    rCb_VSES.Items.Add(dr["SEBEP"].ToString());
            //}

            #endregion TODO:AvukatProLib2 ye geçir
        }

        #region MyRegion

        //void gridTemsilTaraf_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (vgTemsilTaraf.Visible)
        //    {
        //        vgTemsilTaraf.Visible = false;
        //        gridTemsilTaraf.Visible = true;
        //    }
        //    else
        //    {
        //        vgTemsilTaraf.Visible = true;
        //        gridTemsilTaraf.Visible = false;
        //    }
        //}

        #endregion MyRegion

        #region MyRegion

        //int TarafCari_ID_AL(string TarafCariAD, DataTable dtTarafCariID)
        //{
        //    DataRow[] TarafCarileri = dtTarafCariID.Select("AD='" + TarafCariAD + "'");
        //    return Convert.ToInt32(TarafCarileri[0]["ID"]);
        //}
        //int YetkiliCari_ID_AL_1(string YetkiliCariAD, DataTable dtYetkiliCAriID)
        //{
        //    DataRow[] YetkiliCAriler = dtYetkiliCAriID.Select("AD='" + YetkiliCariAD + "'");
        //    return Convert.ToInt32(YetkiliCAriler[0]["ID"]);
        //}
        //int YetkiliCari_ID_AL2(string YetkiliCariAD2, DataTable dtYetkiliCAriID2)
        //{
        //    DataRow[] YetkiliCAriler2 = dtYetkiliCAriID2.Select("AD='" + YetkiliCariAD2 + "'");
        //    return Convert.ToInt32(YetkiliCAriler2[0]["ID"]);
        //}
        //int YetkiliCari_ID_AL_3(string YetkiliCariAD3, DataTable dtYetkiliCAriID3)
        //{
        //    DataRow[] YetkiliCAriler3 = dtYetkiliCAriID3.Select("AD='" + YetkiliCariAD3 + "'");
        //    return Convert.ToInt32(YetkiliCAriler3[0]["ID"]);
        //}
        //int TemsilTipi_ID_AL(string TemsilTipiAd, DataTable dtTemsilTipiID)
        //{
        //    DataRow[] TemsilTipleri = dtTemsilTipiID.Select("TIP='" + TemsilTipiAd + "'");
        //    return Convert.ToInt32(TemsilTipleri[0]["ID"]);
        //}
        //int VSES_ID_AL(string VSESad, DataTable dtVSESID)
        //{
        //    DataRow[] VSESler = dtVSESID.Select("SEBEP='" + VSESad + "'");
        //    return Convert.ToInt32(VSESler[0]["ID"]);
        //}
        //private void rCb_CariAd_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //CARÝ AD ID YÝ AL
        //    if (e.Value != null)
        //        TarafCariID = TarafCari_ID_AL(e.Value.ToString(), dtTarafCari);
        //}

        //private void rCb_TemsilTipi_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //TEMSÝL TÝPÝ ID YÝ AL
        //    if (e.Value != null)
        //        TemsilTipiID = TemsilTipi_ID_AL(e.Value.ToString(), dtTemsilTipi);
        //}

        //private void rCb_YetkiliCariAd_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //YETKÝLÝ 1 ID YÝ AL
        //    if (e.Value != null)
        //        YetkiliCari_1_ID = YetkiliCari_ID_AL_1(e.Value.ToString(), dtYetliciCari_1);

        //}

        //private void rCb_YetkiliCariAd2_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //YETKÝLÝ 2 ID YÝ AL
        //    if (e.Value != null)
        //        YetkiliCari_2_ID = YetkiliCari_ID_AL2(e.Value.ToString(), dtYetliciCari_2);
        //}

        //private void rCb_YetkiliCariAd_3_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //YETKÝLÝ 3 ID YÝ AL
        //    if (e.Value != null)
        //        YetkiliCari_3_ID = YetkiliCari_ID_AL_3(e.Value.ToString(), dtYetliciCari_3);
        //}

        //private void rCb_VSES_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        //{
        //    //VSES ID YÝ AL
        //    if (e.Value != null)
        //        VSES_ID = VSES_ID_AL(e.Value.ToString(), dtVSES);
        //}

        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    Yeni = true;
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    if (Yeni == true)
        //    {
        //        AvukatProLib.Entity.AV001_TDI_BIL_TEMSIL_TARAF TemsilTarafOBJ = new AvukatProLib.Entity.AV001_TDI_BIL_TEMSIL_TARAF();
        //        TemsilTarafOBJ.CARI_ADI = (e.Row as DataRowView)[1].ToString();
        //        TemsilTarafOBJ.KAYIT_TARIHI = DateTime.Now;
        //        TemsilTarafOBJ.KLASOR_KODU = "GENEL";
        //        TemsilTarafOBJ.TARAF_CARI_ID = TarafCariID;
        //        TemsilTarafOBJ.TEMSIL_ID = 1;
        //        TemsilTarafOBJ.TEMSIL_SONA_ERME_TARIHI = Convert.ToDateTime((e.Row as DataRowView)[7]);
        //        TemsilTarafOBJ.TEMSIL_TIP = (e.Row as DataRowView)[3].ToString();
        //        TemsilTarafOBJ.TEMSIL_TIP_ID = TemsilTipiID;
        //        TemsilTarafOBJ.TEMSIL_YETKISI_VAR_MI = Convert.ToBoolean((e.Row as DataRowView)[2]);
        //        TemsilTarafOBJ.TEMSILE_YETKILI_CARI1_ADI = (e.Row as DataRowView)[4].ToString();
        //        TemsilTarafOBJ.TEMSILE_YETKILI_CARI1_ID = YetkiliCari_1_ID;
        //        TemsilTarafOBJ.TEMSILE_YETKILI_CARI2_ADI = (e.Row as DataRowView)[5].ToString();
        //        TemsilTarafOBJ.TEMSILE_YETKILI_CARI2_ID = YetkiliCari_2_ID;
        //        TemsilTarafOBJ.TEMSILE_YETKILI_CARI3_ADI = (e.Row as DataRowView)[6].ToString();
        //        TemsilTarafOBJ.TEMSILE_YETKILI_CARI3_ID = YetkiliCari_3_ID;
        //        TemsilTarafOBJ.VSES_ID = VSES_ID;
        //        TemsilTarafOBJ.VSES_TIP = (e.Row as DataRowView)[8].ToString();
        //        //TemsilTarafOBJ.ADMIN_KAYIT_MI = 1;
        //        TemsilTarafOBJ.KONTROL_KIM = "AVUKATPRO";
        //        TemsilTarafOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        TemsilTarafOBJ.KONTROL_VERSIYON = 1;
        //        TemsilTarafOBJ.STAMP = 1;
        //        TemsilTarafOBJ.SUBE_KODU = 1;
        //        AvukatProLib.Facade.AV001_TDI_BIL_TEMSIL_TARAF.AV001_TDI_BIL_TEMSIL_TARAFEkle(TemsilTarafOBJ);
        //        MessageBox.Show("KAYIT ÝÞLEMÝ TAMAM");

        //    }
        //    else
        //    {
        //        AvukatProLib.Entity.AV001_TDI_BIL_TEMSIL_TARAF TemsilTarafOBJ = new AvukatProLib.Entity.AV001_TDI_BIL_TEMSIL_TARAF();
        //        TemsilTarafOBJ.CARI_ADI = (e.Row as DataRowView)[1].ToString();
        //        TemsilTarafOBJ.KAYIT_TARIHI = DateTime.Now;
        //        TemsilTarafOBJ.KLASOR_KODU = "GENEL";
        //        TemsilTarafOBJ.TARAF_CARI_ID = Convert.ToInt32((e.Row as DataRowView)[10]);
        //        TemsilTarafOBJ.TEMSIL_ID = 1;
        //        TemsilTarafOBJ.TEMSIL_SONA_ERME_TARIHI = Convert.ToDateTime((e.Row as DataRowView)[7]);
        //        TemsilTarafOBJ.TEMSIL_TIP = (e.Row as DataRowView)[3].ToString();
        //        TemsilTarafOBJ.TEMSIL_TIP_ID = Convert.ToInt32((e.Row as DataRowView)[11]);
        //        TemsilTarafOBJ.TEMSIL_YETKISI_VAR_MI = Convert.ToBoolean((e.Row as DataRowView)[2]);
        //        TemsilTarafOBJ.TEMSILE_YETKILI_CARI1_ADI = (e.Row as DataRowView)[4].ToString();
        //        TemsilTarafOBJ.TEMSILE_YETKILI_CARI1_ID = Convert.ToInt32((e.Row as DataRowView)[12]);
        //        TemsilTarafOBJ.TEMSILE_YETKILI_CARI2_ADI = (e.Row as DataRowView)[5].ToString();
        //        TemsilTarafOBJ.TEMSILE_YETKILI_CARI2_ID = Convert.ToInt32((e.Row as DataRowView)[13]);
        //        TemsilTarafOBJ.TEMSILE_YETKILI_CARI3_ADI = (e.Row as DataRowView)[6].ToString();
        //        TemsilTarafOBJ.TEMSILE_YETKILI_CARI3_ID = Convert.ToInt32((e.Row as DataRowView)[14]);
        //        TemsilTarafOBJ.VSES_ID = Convert.ToInt32((e.Row as DataRowView)[15]);
        //        TemsilTarafOBJ.VSES_TIP = (e.Row as DataRowView)[8].ToString();
        //        //TemsilTarafOBJ.ADMIN_KAYIT_MI = 1;
        //        TemsilTarafOBJ.KONTROL_KIM = "AVUKATPRO";
        //        TemsilTarafOBJ.KONTROL_NE_ZAMAN = DateTime.Now;
        //        TemsilTarafOBJ.KONTROL_VERSIYON = 1;
        //        TemsilTarafOBJ.STAMP = 1;
        //        TemsilTarafOBJ.SUBE_KODU = 1;
        //        TemsilTarafOBJ.ID = Convert.ToInt32((e.Row as DataRowView)[0]);
        //        AvukatProLib.Facade.AV001_TDI_BIL_TEMSIL_TARAF.Guncelle(TemsilTarafOBJ);

        //        MessageBox.Show("GÜNCELLEME ÝÞLEMÝ TAMAM");

        //    }

        //    Yeni = false;

        //}

        //private void controlNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        //{
        //    //SÝl
        //    if (e.Button.ButtonType == NavigatorButtonType.Remove)
        //    {
        //        GuncelleSilID = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["ID"]);

        //        AvukatProLib.Facade.AV001_TDI_BIL_TEMSIL_TARAF.AV001_TDI_BIL_TEMSIL_TARAFSil(GuncelleSilID);
        //        MessageBox.Show("SÝLME Ýþlemi TAMAM");
        //    }

        //}

        #endregion MyRegion
    }
}