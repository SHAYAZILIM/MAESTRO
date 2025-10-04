using System;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucHazirlikSorguMahkemesi : DevExpress.XtraEditors.XtraUserControl
    {
        public ucHazirlikSorguMahkemesi()
        {
            InitializeComponent();
        }

        public TList<AV001_TD_BIL_HAZIRLIK_SUREC> MyDataSource
        {
            get
            {
                if (gridHazirlikSorguiMahkeme.DataSource is TList<AV001_TD_BIL_HAZIRLIK_SUREC>)
                    return (TList<AV001_TD_BIL_HAZIRLIK_SUREC>)gridHazirlikSorguiMahkeme.DataSource;

                return null;
            }
            set
            {
                gridHazirlikSorguiMahkeme.DataSource = value;
                gridControl1.DataSource = gridHazirlikSorguiMahkeme.DataSource;
            }
        }

        public AV001_TD_BIL_HAZIRLIK MySorusturma { get; set; }

        private void gridHazirlikSorguiMahkeme_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gridControl1.Visible)
            {
                gridControl1.Visible = false;
                gridHazirlikSorguiMahkeme.Visible = true;
            }
            else
            {
                gridControl1.Visible = true;
                gridHazirlikSorguiMahkeme.Visible = false;
            }
        }

        private void gridHazirlikSorguiMahkeme_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                frmSorusturmaKarakol Ssurec = new frmSorusturmaKarakol();
                Ssurec.Tip = 3;
                Ssurec.MySorusturma = MySorusturma;
                Ssurec.Text = "Soruþturma Karakol Bilgileri";
                Ssurec.Show();
                Ssurec.HazirlikSurecKaydedildi += Ssurec_HazirlikSurecKaydedildi;
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                frmSorusturmaKarakol Ssurec = new frmSorusturmaKarakol();
                TList<AV001_TD_BIL_HAZIRLIK_SUREC> vList = new TList<AV001_TD_BIL_HAZIRLIK_SUREC>();
                vList.Add(MyDataSource[gwHazirlikSorguiMahkeme.FocusedRowHandle]);
                Ssurec.Tip = 3;
                Ssurec.MyDataSource = vList;
                Ssurec.MySorusturma = MySorusturma;

                Ssurec.Text = "Soruþturma Karakol Bilgileri";
                Ssurec.Show();
            }
        }

        private void gridHazirlikSorguiMahkeme_Click(object sender, EventArgs e)
        {
        }

        private void gridHazirlikSorguiMahkeme_EmbeddedNavigator_ButtonClick(object sender,
                                                                             NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag == "FormAc")
            {
                frmSorusturmaKarakol Ssurec = new frmSorusturmaKarakol();
                int SurecTip = 3;
                Ssurec.MySorusturma = MySorusturma;
                Ssurec.Text = "Soruþturma Sorgu Mahkemesi Bilgileri";
                Ssurec.Show(MyDataSource, SurecTip);
            }
        }

        private void Ssurec_HazirlikSurecKaydedildi(object sender, HazirlikSurecKaydedildiEventArgs e)
        {
            if (e.Foy != null)
                MyDataSource.Add(e.Foy);
        }

        private void ucHazirlikSorguMahkemesi_Load(object sender, EventArgs e)
        {
            //LOAD
            if (!this.DesignMode)
            {
                try
                {
                    gridHazirlikSorguiMahkeme.ButtonCevirClick += gridHazirlikSorguiMahkeme_ButtonCevirClick;
                    gridControl1.ButtonCevirClick += gridHazirlikSorguiMahkeme_ButtonCevirClick;

                    BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
                    BelgeUtil.Inits.perCariGetir(rLueÝfadeVerenCari);
                    BelgeUtil.Inits.IcraItirazSonucGetir(rLueItirazSonucu);
                    BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueMahkeme);
                    BelgeUtil.Inits.AdliBirimNoGetir(rLueNo);
                    BelgeUtil.Inits.SorumluAvukatGetir(rLueSorumluAvk);
                    BelgeUtil.Inits.HazirlikSurecSonucGetir(rLueSurecSonuc);
                    BelgeUtil.Inits.HazirlikSurecGetir(rLueSurecTipId);
                    BelgeUtil.Inits.HazirlikSikayetNedenGetir(rLueTakipNedeni);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }
    }
}