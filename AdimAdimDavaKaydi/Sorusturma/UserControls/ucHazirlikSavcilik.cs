using System;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucHazirlikSavcilik : DevExpress.XtraEditors.XtraUserControl
    {
        public ucHazirlikSavcilik()
        {
            InitializeComponent();
        }

        public TList<AV001_TD_BIL_HAZIRLIK_SUREC> MyDataSource
        {
            get
            {
                if (gridHazirlikSavcilik.DataSource is TList<AV001_TD_BIL_HAZIRLIK_SUREC>)
                    return (TList<AV001_TD_BIL_HAZIRLIK_SUREC>)gridHazirlikSavcilik.DataSource;

                return null;
            }
            set
            {
                gridHazirlikSavcilik.DataSource = value;
                gridControl2.DataSource = gridHazirlikSavcilik.DataSource;
            }
        }

        public AV001_TD_BIL_HAZIRLIK MySorusturma { get; set; }

        private void gridHazirlikSavcilik_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gridControl2.Visible)
            {
                gridControl2.Visible = false;
                gridHazirlikSavcilik.Visible = true;
            }
            else
            {
                gridControl2.Visible = true;
                gridHazirlikSavcilik.Visible = false;
            }
        }

        private void gridHazirlikSavcilik_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                frmSorusturmaKarakol Ssurec = new frmSorusturmaKarakol();
                Ssurec.Tip = 2;
                Ssurec.MySorusturma = MySorusturma;
                Ssurec.Text = "Soruþturma Karakol Bilgileri";
                Ssurec.Show();
                Ssurec.HazirlikSurecKaydedildi += Ssurec_HazirlikSurecKaydedildi;
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                frmSorusturmaKarakol Ssurec = new frmSorusturmaKarakol();
                TList<AV001_TD_BIL_HAZIRLIK_SUREC> vList = new TList<AV001_TD_BIL_HAZIRLIK_SUREC>();
                vList.Add(MyDataSource[gwHazirlikSavcilik.FocusedRowHandle]);
                Ssurec.Tip = 2;
                Ssurec.MyDataSource = vList;
                Ssurec.MySorusturma = MySorusturma;

                Ssurec.Text = "Soruþturma Karakol Bilgileri";
                Ssurec.Show();
            }
        }

        private void gridHazirlikSavcilik_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag == "FormAc")
            {
                frmSorusturmaKarakol Ssurec = new frmSorusturmaKarakol();
                Ssurec.MySorusturma = MySorusturma;
                Ssurec.Text = "Soruþturma Savcýlýk Bilgileri";
                Ssurec.Show(MyDataSource, 2);
            }
        }

        private void Ssurec_HazirlikSurecKaydedildi(object sender, HazirlikSurecKaydedildiEventArgs e)
        {
            if (e.Foy != null)
                MyDataSource.Add(e.Foy);
        }

        private void ucHazirlikSavcilik_Load(object sender, EventArgs e)
        {
            //LOAD
            if (!this.DesignMode)
            {
                try
                {
                    gridHazirlikSavcilik.ButtonCevirClick += gridHazirlikSavcilik_ButtonCevirClick;
                    gridControl2.ButtonCevirClick += gridHazirlikSavcilik_ButtonCevirClick;

                    BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
                    BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
                    BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
                    BelgeUtil.Inits.perCariGetir(rLueIfadeVeren);
                    BelgeUtil.Inits.IcraItirazSonucGetir(rLueItirazSonuc);
                    BelgeUtil.Inits.CariPersonelGetir(rLuePersonel);
                    BelgeUtil.Inits.SavcilikHukumGetir(rLueSavcilikHüküm);
                    BelgeUtil.Inits.HazirlikSikayetNedenGetir(rLueSikayetNeden);
                    BelgeUtil.Inits.SorumluAvukatGetir(rLueSorumlu);
                    BelgeUtil.Inits.HazirlikSurecSonucGetir(rLueSurecSonuc);
                    BelgeUtil.Inits.HazirlikSurecGetir(rLueSurecTip);
                    BelgeUtil.Inits.ParaBicimiAyarla(rSpTutar);
                    BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }
    }
}