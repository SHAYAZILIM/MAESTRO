using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Sozlesme.Forms.Sozlesme.Util
{
    public partial class ucSozlesmeDetaylari : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        private frmSozlesmeDetay frm;

        public ucSozlesmeDetaylari()
        {
            InitializeComponent();
            this.Load += ucSozlesmeDetaylari_Load;
            this.gSozlesmeDetay.EmbeddedNavigator.ButtonClick += gSozlesmeDetay_ButtonClick;
        }

        public TList<AV001_TDI_BIL_SOZLESME_DETAY> MyDataSource
        {
            get
            {
                if (gSozlesmeDetay.DataSource is TList<AV001_TDI_BIL_SOZLESME_DETAY>)
                    return (TList<AV001_TDI_BIL_SOZLESME_DETAY>)gSozlesmeDetay.DataSource;
                else
                    return null;
            }
            set
            {
                if (value != null && this.DesignMode == false)
                {
                    gSozlesmeDetay.DataSource = value;
                    vgSozlesmeDetay.DataSource = value;
                }
            }
        }

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesme { get; set; }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(MySozlesme, false, DeepLoadType.IncludeChildren
                                                                   , typeof(TList<AV001_TDI_BIL_SOZLESME_DETAY>));
            MyDataSource = MySozlesme.AV001_TDI_BIL_SOZLESME_DETAYCollection;
            frm = null;
        }

        private void gSozlesmeDetay_ButtonCevirClick(object sender,
                                                     DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (gSozlesmeDetay.Visible)
            {
                gSozlesmeDetay.Visible = false;
                vgSozlesmeDetay.Visible = true;
                gSozlesmeDetay.BringToFront();
            }
            else
            {
                gSozlesmeDetay.Visible = true;
                vgSozlesmeDetay.Visible = false;
                vgSozlesmeDetay.BringToFront();
            }
        }

        private void gSozlesmeDetay_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                if (frm == null)
                {
                    frm = new frmSozlesmeDetay();

                    //.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.Show(MySozlesme);
                    frm.FormClosed += frm_FormClosed;
                }
            }
            if (e.Button.Tag.ToString() == "KayitDuzenle")
            {
                frmSozlesmeDetay frmD = new frmSozlesmeDetay();

                // .MdiParent = null;
                frmD.StartPosition = FormStartPosition.WindowsDefaultLocation;
                TList<AV001_TDI_BIL_SOZLESME_DETAY> DETAY = new TList<AV001_TDI_BIL_SOZLESME_DETAY>();
                DETAY.Add(MyDataSource[gridView1.FocusedRowHandle]);
                frmD.MyDataSource = DETAY;
                frmD.MySozlesme = MySozlesme;
                frmD.Show();
            }
        }

        private void ucSozlesmeDetaylari_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            BelgeUtil.Inits.MalKategoriGetir(rlueMalKat);
            BelgeUtil.Inits.MalTurGetir(rlueMalTuru);
            BelgeUtil.Inits.MalcinsGetir(rlueMalCinsi);
            BelgeUtil.Inits.BirimKodGetir(rlueAdetBirim);
            BelgeUtil.Inits.DovizTipGetir(rluedoviz);
            BelgeUtil.Inits.ParaBicimiAyarla(tutar);
        }
    }
}