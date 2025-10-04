using System;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucHazirlikKarakol : DevExpress.XtraEditors.XtraUserControl
    {
        public ucHazirlikKarakol()
        {
            InitializeComponent();
        }

        public TList<AV001_TD_BIL_HAZIRLIK_SUREC> MyDataSource
        {
            get
            {
                if (gridHazirlikKarakol.DataSource is TList<AV001_TD_BIL_HAZIRLIK_SUREC>)
                    return (TList<AV001_TD_BIL_HAZIRLIK_SUREC>)gridHazirlikKarakol.DataSource;

                return null;
            }
            set
            {
                gridHazirlikKarakol.DataSource = value;
                gridControl1.DataSource = gridHazirlikKarakol.DataSource;
            }
        }

        public AV001_TD_BIL_HAZIRLIK MySorusturma { get; set; }

        private void gridHazirlikKarakol_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gridControl1.Visible)
            {
                gridControl1.Visible = false;
                gridHazirlikKarakol.Visible = true;
            }
            else
            {
                gridControl1.Visible = true;
                gridHazirlikKarakol.Visible = false;
            }
        }

        private void gridHazirlikKarakol_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;

            if (e.Button.Tag == "FormAc")
            {
                frmSorusturmaKarakol Ssurec = new frmSorusturmaKarakol();
                Ssurec.Tip = 1;
                Ssurec.MySorusturma = MySorusturma;
                Ssurec.Text = "Soruþturma Karakol Bilgileri";
                Ssurec.Show();
                Ssurec.HazirlikSurecKaydedildi += Ssurec_HazirlikSurecKaydedildi;
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                frmSorusturmaKarakol Ssurec = new frmSorusturmaKarakol();
                TList<AV001_TD_BIL_HAZIRLIK_SUREC> vList = new TList<AV001_TD_BIL_HAZIRLIK_SUREC>();
                vList.Add(MyDataSource[gwHazirlikKarakol.FocusedRowHandle]);
                Ssurec.Tip = 1;
                Ssurec.MyDataSource = vList;
                Ssurec.MySorusturma = MySorusturma;
                Ssurec.Text = "Soruþturma Karakol Bilgileri";
                Ssurec.Show();
            }
        }

        private void gridHazirlikKarakol_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;

            if (e.Button.Tag == "FormAc")
            {
                frmSorusturmaKarakol Ssurec = new frmSorusturmaKarakol();
                int SurecTip = 1;
                Ssurec.MySorusturma = MySorusturma;
                Ssurec.Text = "Soruþturma Karakol Bilgileri";
                Ssurec.Show(MyDataSource, SurecTip);
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                frmSorusturmaKarakol Ssurec = new frmSorusturmaKarakol();
                TList<AV001_TD_BIL_HAZIRLIK_SUREC> vList = new TList<AV001_TD_BIL_HAZIRLIK_SUREC>();
                vList.Add(MyDataSource[gwHazirlikKarakol.FocusedRowHandle]);
                Ssurec.MyDataSource = vList;
                Ssurec.MySorusturma = MySorusturma;
                Ssurec.Text = "Soruþturma Karakol Bilgileri";
                Ssurec.Show();
            }
        }

        private void Ssurec_HazirlikSurecKaydedildi(object sender, HazirlikSurecKaydedildiEventArgs e)
        {
            if (e.Foy != null)
                MyDataSource.Add(e.Foy);
        }

        private void ucHazirlikKarakol_Load(object sender, EventArgs e)
        {
            //LOAD

            if (!this.DesignMode)
            {
                gridHazirlikKarakol.ButtonCevirClick += gridHazirlikKarakol_ButtonCevirClick;
                BelgeUtil.Inits.HazirlikSurecGetir(rLueSurecTipId);
                BelgeUtil.Inits.HazirlikSurecSonucGetir(rLueSurecSonucu);
                BelgeUtil.Inits.SorumluAvukatGetir(rLueSorumluAvukat);
                BelgeUtil.Inits.perCariGetir(rLueIfadeVeren);
            }
        }
    }
}