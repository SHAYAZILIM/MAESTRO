using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmAracBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmAracBilgileri()
        {
            Secilenler = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC>();
            InitializeComponent();
            InitializeEvents();
            this.Load += frmAracBilgileri_Load;
            gcAracBilgileri.ButtonClick += gcAracBilgileri_ButtonClick;
        }

        public int? borcluTarafCariId;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy { get; set; }

        [Browsable(false), Description("Seçilen araç kayýtlarýný döndürür.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC> Secilenler { get; set; }

        private void btnGonder_ItemClick(object sender, EventArgs e)
        {
            foreach (AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC arac in gcAracBilgileri.DataSource as List<AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC>)
            {
                if (arac.IsSelected)
                    Secilenler.Add(arac);
            }

            if (Secilenler.Count == 0)
                XtraMessageBox.Show("Seçilen kayýt yok.Lütfen gemi, uçark ya da araç kaydý seçiniz", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                this.Close();
        }

        private void frmAracBilgileri_Load(object sender, EventArgs e)
        {
            initData();

            BelgeUtil.Inits.MalKategoriGetir(rLueMalKategori);
            BelgeUtil.Inits.MalTurGetir(rLueMalTur);
            BelgeUtil.Inits.MalcinsGetir(rLueMalCins);
            BelgeUtil.Inits.BirimKodGetir(rLueMalBirim);
            BelgeUtil.Inits.DovizTipGetir(rLueDoviztip);
            BelgeUtil.Inits.IlceGetirOzetli(rLueIlce);
            BelgeUtil.Inits.IlGetir(rLueIl);
            BelgeUtil.Inits.UlkeGetir(rLueUlke);
            BelgeUtil.Inits.perCariGetir(rLueYapanCariID);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AracTipGetir(rlueTipi);
        }

        private void gcAracBilgileri_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null)
                return;
            if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                frmGemiUcakAracKayit gm = new frmGemiUcakAracKayit();
                gm.MyDataSource = gcAracBilgileri.DataSource as TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>;

                //gm.MdiParent = null;
                gm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                gm.Show();
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnGonder_ItemClick;
        }

        private void initData()
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC> result = null;
            if (borcluTarafCariId.HasValue)
            {
                if (BelgeUtil.Inits._per_AV001_TDI_BIL_GEMI_UCAK_ARAC != null)
                    result = BelgeUtil.Inits._per_AV001_TDI_BIL_GEMI_UCAK_ARAC.FindAll(item => item.ARAC_SAHIBI_CARI_ID == borcluTarafCariId.Value);
                else result = BelgeUtil.Inits.context.per_AV001_TDI_BIL_GEMI_UCAK_ARACs.Where(item => item.ARAC_SAHIBI_CARI_ID == borcluTarafCariId.Value).ToList();
            }
            if (result.Count == 0)
            {
                if (BelgeUtil.Inits._per_AV001_TDI_BIL_GEMI_UCAK_ARAC == null)
                    BelgeUtil.Inits._per_AV001_TDI_BIL_GEMI_UCAK_ARAC = BelgeUtil.Inits.context.per_AV001_TDI_BIL_GEMI_UCAK_ARACs.ToList();
                result = BelgeUtil.Inits._per_AV001_TDI_BIL_GEMI_UCAK_ARAC;
            }

            gcAracBilgileri.DataSource = result;
        }
    }
}