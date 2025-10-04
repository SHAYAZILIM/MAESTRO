using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucHazirlikTutuklanma : DevExpress.XtraEditors.XtraUserControl
    {
        public ucHazirlikTutuklanma()
        {
            InitializeComponent();
        }

        public TList<AV001_TD_BIL_TUTUKLANMA> MyDataSource
        {
            get
            {
                if (gridHazirlikTutuklanma.DataSource is TList<AV001_TD_BIL_TUTUKLANMA>)
                    return (TList<AV001_TD_BIL_TUTUKLANMA>)gridHazirlikTutuklanma.DataSource;

                return null;
            }
            set
            {
                gridHazirlikTutuklanma.DataSource = value;
                gridControl1.DataSource = gridHazirlikTutuklanma.DataSource;
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MySorusturma { get; set; }

        private void gridHazirlikTutuklanma_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gridControl1.Visible)
            {
                gridControl1.Visible = false;
                gridHazirlikTutuklanma.Visible = true;
            }
            else
            {
                gridControl1.Visible = true;
                gridHazirlikTutuklanma.Visible = false;
            }
        }

        private void gridHazirlikTutuklanma_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                frmSorusturmaTutuklanma frm = new frmSorusturmaTutuklanma();
                frm.MySorusturma = MySorusturma;
                frm.Show(MyDataSource);
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                frmSorusturmaTutuklanma sikayet = new frmSorusturmaTutuklanma();
                TList<AV001_TD_BIL_TUTUKLANMA> vList = new TList<AV001_TD_BIL_TUTUKLANMA>();
                vList.Add(MyDataSource[gwgridHazirlikTutuklanma.FocusedRowHandle]);
                sikayet.MyDataSource = vList;
                sikayet.MySorusturma = MySorusturma;
                sikayet.Show();
            }
        }

        private void InitData()
        {
            BelgeUtil.Inits.TutuklanmaGelisTipGetir(rLueTutuklanmaGelisTip);
            BelgeUtil.Inits.TutuklanmaTipGetir(rlueTutuklamaTip);
            BelgeUtil.Inits.KararSonucuGetir(rlueKaraSonuc);
            BelgeUtil.Inits.DosyaHedefTipGetir(rlueDosyaHedefTip);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
            BelgeUtil.Inits.perCariGetir(rlueCari);
            BelgeUtil.Inits.SerbestBirakilmaNedenGetir(rlueSerBirNeden);
        }

        private void ucHazirlikTutuklanma_Load(object sender, EventArgs e)
        {
            //LOAD
            if (!this.DesignMode)
            {
                try
                {
                    gridHazirlikTutuklanma.ButtonCevirClick += gridHazirlikTutuklanma_ButtonCevirClick;
                    gridControl1.ButtonCevirClick += gridHazirlikTutuklanma_ButtonCevirClick;
                    InitData();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }

                //TODO: bu gridin tablosunda birçok alanýn iliþkileri atanmamýþ .. !!Bi zahmet .
            }
        }
    }
}