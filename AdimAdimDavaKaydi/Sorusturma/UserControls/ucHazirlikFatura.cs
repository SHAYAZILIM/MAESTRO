using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms.Dava;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucHazirlikFatura : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucHazirlikFatura()
        {
            InitializeComponent();
        }

        //
        public TList<AV001_TDI_BIL_FATURA> MyDataSource
        {
            get
            {
                if (gridFatura.DataSource is TList<AV001_TDI_BIL_FATURA>)
                    return (TList<AV001_TDI_BIL_FATURA>)gridFatura.DataSource;

                return null;
            }
            set
            {
                gridFatura.DataSource = value;
                extendedGridControl1.DataSource = gridFatura.DataSource;
            }
        }

        public AV001_TD_BIL_HAZIRLIK MyHazirlik { get; set; }

        private void gridFatura_ButtonCevirClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (extendedGridControl1.Visible)
            {
                extendedGridControl1.Visible = false;
                gridFatura.Visible = true;
                gridFatura.BringToFront();
            }
            else
            {
                extendedGridControl1.Visible = true;
                gridFatura.Visible = false;
            }
        }

        private void gridFatura_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Button.Tag.ToString()))
            {
                if (e.Button.Tag.ToString() == "KayitEkle")
                {
                    rFrmMeslekMakbuzuKaydetForDava frmMeslekMakbuzu = new rFrmMeslekMakbuzuKaydetForDava();
                    //frmMeslekMakbuzu.MdiParent = null;
                    frmMeslekMakbuzu.StartPosition = FormStartPosition.WindowsDefaultLocation;

                    //frmMeslekMakbuzu.FormClosed += new FormClosedEventHandler(frmMeslekMakbuzu_FormClosed);
                    frmMeslekMakbuzu.Show(MyHazirlik);
                }
                if (e.Button.Tag.ToString() == "KayitDuzenle")
                {
                    rFrmMeslekMakbuzuKaydetForDava frmMeslekMakbuzu = new rFrmMeslekMakbuzuKaydetForDava();
                    //frmMeslekMakbuzu.MdiParent = null;
                    frmMeslekMakbuzu.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmMeslekMakbuzu.AddNewList = new TList<AV001_TDI_BIL_FATURA>();
                    frmMeslekMakbuzu.AddNewList.Add(gwFatura.GetFocusedRow() as AV001_TDI_BIL_FATURA);
                    frmMeslekMakbuzu.Show(MyHazirlik);
                }
            }
        }

        private void ucFatura_Load(object sender, EventArgs e)
        {
            //LOAd ı
            if (!this.DesignMode)
            {
                try
                {
                    gridFatura.ButtonCevirClick += gridFatura_ButtonCevirClick;
                    extendedGridControl1.ButtonCevirClick += gridFatura_ButtonCevirClick;

                    BelgeUtil.Inits.AlacakNEdenGetir(rLueAlacakNeden);
                    BelgeUtil.Inits.perCariGetir(rLueCari);
                    BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
                    BelgeUtil.Inits.FaturaHedefTipGetir(rLueFaturaHedefTip);
                    BelgeUtil.Inits.FaturaKapsamTipGetir(rLueFaturaKapsamTip);
                    BelgeUtil.Inits.ParaBicimiAyarla(rSpinTutar);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }
    }
}