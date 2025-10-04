using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Data;
using AvukatProLib.Extras;
using AvukatProLib;
using AdimAdimDavaKaydi.UserControls.ucRapor;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucProjeBilgileriAramaEkran : DevExpress.XtraEditors.XtraUserControl
    {
        public ucProjeBilgileriAramaEkran()
        {
            InitializeComponent();
            this.Load += ucProjeBilgileriAramaEkran_Load;
            exGridKlasorArama.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            exGridKlasorArama.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            BarButtonItem bus5 = new BarButtonItem(e.Manager, "Klasör Ekranýna Gönder");
            bus5.Tag = e.Rows;
          bus5.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.gonder16x16;
            bus5.Name = "bButtonTakipGonder";
            e.MyPopupMenu.ItemLinks.Insert(1, bus5);
        }

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Name == "bButtonTakipGonder")
            {
                if (e.Item.Tag is AV001_TDIE_BIL_PROJE)
                {
                    AV001_TDIE_BIL_PROJE takip = e.Item.Tag as AV001_TDIE_BIL_PROJE;
                    Forms.frmKlasorYeni klasor = new frmKlasorYeni();
                    TList<AV001_TDIE_BIL_PROJE> seciliProjeler = new TList<AV001_TDIE_BIL_PROJE>();
                    seciliProjeler.Add(takip);
                    klasor.Show(seciliProjeler);
                }
            }
        }

        //[Browsable(false)]
        //public List<AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE> MyDataSource
        //{
        //    get
        //    {
        //        if (exGridKlasorArama.DataSource is List<AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE>)
        //            return (List<AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE>)exGridKlasorArama.DataSource;
        //        return null;
        //    }
        //    set { exGridKlasorArama.DataSource = value; }
        //}

        [Browsable(false)]
        public DataTable MyDataSource
        {
            get
            {
                return (DataTable)exGridKlasorArama.DataSource;
            }
            set { exGridKlasorArama.DataSource = value; }
        }

        public void LookUpsDoldur()
        {
            BelgeUtil.Inits.ProjeDurumGetir(rLueProjeDurumID);
            BelgeUtil.Inits.ProjeOzelKodGetir(rLueOzelKodID);
            BelgeUtil.Inits.ProjeTipGetir(rLueProjeTipID);
            BelgeUtil.Inits.DosyaDurumGetir(rLueDosyaDurumID);
            //BelgeUtil.Inits.ProjeDurumGetir(rLueKlasorDurumID);
            //BelgeUtil.Inits.ProjeOzelKodGetir(rLueProjeOzelKodlarID);
            //BelgeUtil.Inits.ProjeTipGetir(rLueProjeTipiID);
            //BelgeUtil.Inits.DosyaDurumGetir(rLueFoyDurumID);
            BelgeUtil.Inits.ProjeDurumGetir(lkProjeDurum.Properties);

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;

            lkSube.Properties.DataSource = cn.GetDataTable("SELECT a.ID,b.AD, OZEL_KOD, CARI_ID FROM dbo.TDIE_KOD_PROJE_OZEL_KOD(nolock) a LEFT JOIN dbo.AV001_TDI_BIL_CARI(nolock) b ON b.ID = a.CARI_ID ORDER BY b.AD, OZEL_KOD");

            BelgeUtil.Inits.ProjeTipGetir(lkKlasorTipID.Properties);
            BelgeUtil.Inits.DosyaDurumGetir(lkDosyaDurum);
            BelgeUtil.Inits.DovizTipGetir(rlueDovizCinsi);

            //lueOzelKod1.Properties.NullText = "Seç";
            //lueOzelKod1.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod1, 1, Modul.Klasor); };

            //lueOzelKod2.Properties.NullText = "Seç";
            //lueOzelKod2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod2, 2, Modul.Klasor); };

            //lueOzelKod3.Properties.NullText = "Seç";
            //lueOzelKod3.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod3, 3, Modul.Klasor); };

            //lueOzelKod4.Properties.NullText = "Seç";
            //lueOzelKod4.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod4, 4, Modul.Klasor); };

            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod1, 1, Modul.Klasor);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod2, 2, Modul.Klasor);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod3, 3, Modul.Klasor);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod4, 4, Modul.Klasor);

            slueAlacakli.Enter += delegate { AvukatPro.Services.Implementations.DevExpressService.CariDoldur(slueAlacakli, null); };
            slueBorclu.Enter += delegate { AvukatPro.Services.Implementations.DevExpressService.CariDoldur(slueBorclu, null); };

        }

        private void FormlariTemizle()
        {
            try
            {
                foreach (Control con in xTabProjedenAramaKriter.Controls)
                {
                    if (con is LookUpEdit)
                    {
                        (con as LookUpEdit).EditValue = null;
                    }
                    else if (con is SearchLookUpEdit)
                    {
                        (con as SearchLookUpEdit).EditValue = null;
                    }
                    else if (con is DateEdit)
                    {
                        (con).ResetText();
                        ((DateEdit)con).EditValue = null;
                    }
                    else if (con is TextEdit)
                    {
                        ((TextEdit)con).EditValue = null;
                    }
                }
            }
            catch 
            {
                XtraMessageBox.Show(
                    "Arama Kriterleri Temizlenirken (Silinirken) Bir Hata Oluþtu..\nLütfen Yeniden Deneyiniz...");
            }
        }

        private void ucProjeBilgileriAramaEkran_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            LookUpsDoldur();
            //sBtnSorgula.Enabled = false;
        }

        private void sBtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle();
            //sBtnSorgula.Enabled = true;
        }

        private void sBtnSorgula_Click(object sender, EventArgs e)
        {
            //SORGULa
            //if (txteKlasorAd.EditValue != null || txteKlasorKodu.EditValue != null ||
            //    deBaslangicTarihi.EditValue != null || deBitisTarihi.EditValue != null || lkProjeDurum.EditValue != null ||
            //    lkOzelKod1.EditValue != null || lkKlasorTipID.EditValue != null || lkDosyaDurum.EditValue != null)
            //{
                MyDataSource = AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE.GetByFiltre(txteKlasorKodu.EditValue, txteKlasorAd.EditValue, deBaslangicTarihi.EditValue, deBitisTarihi.EditValue, lkProjeDurum.EditValue, lkSube.EditValue, lkKlasorTipID.EditValue, lkDosyaDurum.EditValue, slueAlacakli.EditValue, slueBorclu.EditValue, lueOzelKod1.EditValue, lueOzelKod2.EditValue, lueOzelKod3.EditValue, lueOzelKod4.EditValue, txtRef1.Text, txtRef2.Text, txtRef3.Text);
            
            //DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByFiltre(
                //(string)txteKlasorKodu.EditValue, (string)txteKlasorAd.EditValue,
                //(DateTime?)deBaslangicTarihi.EditValue, (DateTime?)deBitisTarihi.EditValue,
                //(int?)lkProjeDurum.EditValue, (int?)lkOzelKod1.EditValue, (int?)lkKlasorTipID.EditValue,
                //(int?)lkDosyaDurum.EditValue);
            //}
            //else
            //{
            //    DialogResult dr =
            //        XtraMessageBox.Show(
            //            "Hiç Arama Kriteri Seçmediniz , Bu durumda Sorgulama Zaman Alabilir\nBütün Kayýtlarý Sorgulamak Ýstediðinizden Emin misiniz  ?" +
            //            Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo,
            //            MessageBoxIcon.Question);
            //    if (dr == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            if (BelgeUtil.Inits._ProjeAdGetir == null) BelgeUtil.Inits._ProjeAdGetir = BelgeUtil.Inits.context.per_AV001_TDIE_BIL_PROJEs.ToList();
            //            MyDataSource = BelgeUtil.Inits._ProjeAdGetir;
            //        }
            //        catch (Exception ex)
            //        {
            //            BelgeUtil.ErrorHandler.Catch(this, ex, false, BelgeUtil.Bilesen.Arama);
            //        }
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("Ýþlem Tarafýnýzdan Onaylanmadýðý için Sorgulama Yapýlamamýþtýr...");
            //    }
            //}
            if (MyDataSource != null && MyDataSource.Rows.Count == 0)
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        txteKlasorAd.Text + "Ýsimli Klasör Bulunamamýþtýr Yeni Klasör Oluþturmak Ýstiyormusunuz?",
                        "Uyarý", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    frmYeniKlasor frm = new frmYeniKlasor();
                    AV001_TDIE_BIL_PROJE prj = frm.YeniKlasorGetir();
                    if (prj != null)
                    {
                        DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(prj);
                    }
                }
            }
        }

        private void exGridKlasorArama_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE takip = AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE.GetByID(Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID")));
                Forms.frmKlasorYeni klasor = new frmKlasorYeni();
                List<AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE> seciliProjeler = new List<AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE>();
                seciliProjeler.Add(takip);
                klasor.Show(seciliProjeler);
            }
        }

        private TList<AV001_TDIE_BIL_PROJE> seciliKayitler = new TList<AV001_TDIE_BIL_PROJE>();

        public static List<AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE> GetSelectedFoy(List<AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE> foy)
        {
            List<AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE> seciliKayitlar = foy.FindAll(vi => vi.IsSelected);
            return seciliKayitlar;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            #region <MB-20100524>

            //Yeni Klasör Ekranýnýn Açýlmasý Saðlandý.

            //Forms.frmKlasorYeni klasor = new frmKlasorYeni();
            //List<AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE> seciliProjeler = GetSelectedFoy(MyDataSource);
            //klasor.Show(seciliProjeler);

            #endregion
        }

        private void gridView1_FocusedRowChanged(object sender,
                                                 DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ////XtraMessageBox.Show("DoubleClick" + e.ToString());
            //AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE secilenKlasor = new AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE();
            //secilenKlasor = (AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE)gridView1.GetFocusedRow();
            //if (secilenKlasor != null)
            //{
            //    MyDataSourceLayOut = secilenKlasor;
            //}
        }

        private void exGridKlasorArama_Click(object sender, EventArgs e)
        {
            ////XtraMessageBox.Show("DoubleClick" + e.ToString());
            //AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE secilenKlasor = new AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE();
            //secilenKlasor = (AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE)gridView1.GetFocusedRow();
            //if (secilenKlasor != null)
            //{
            //    MyDataSourceLayOut = secilenKlasor;
            //}
        }

        private void lkSube_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                if (xtraTabPage1.Controls.Count == 0)
                {
                    ABSqlConnection cn = new ABSqlConnection();
                    cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                    ucPivotChart pGcIcraRapor = new ucPivotChart();
                    pGcIcraRapor.MyProje = cn.GetDataTable("select * from R_RAPOR_PROJE_GENEL(nolock)");

                    pGcIcraRapor.Dock = DockStyle.Fill;
                    xtraTabPage1.Controls.Add(pGcIcraRapor);
                }
            }
        }
    }
}