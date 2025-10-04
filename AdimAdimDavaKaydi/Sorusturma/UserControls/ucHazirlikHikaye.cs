using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucHazirlikHikaye : DevExpress.XtraEditors.XtraUserControl
    {
        private AV001_TD_BIL_HAZIRLIK myFoy;

        public ucHazirlikHikaye()
        {
            InitializeComponent();
        }

        public TList<AV001_TD_BIL_HAZIRLIK_HIKAYE> MyDataSource
        {
            get
            {
                if (gridHazirlikHikaye.DataSource is TList<AV001_TD_BIL_HAZIRLIK_HIKAYE>)
                    return (TList<AV001_TD_BIL_HAZIRLIK_HIKAYE>)gridHazirlikHikaye.DataSource;

                return null;
            }
            set
            {
                gridHazirlikHikaye.DataSource = value;
                gridControl1.DataSource = gridHazirlikHikaye.DataSource;
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    if (value.AV001_TD_BIL_HAZIRLIK_HIKAYECollection.Count == 0)
                        MyDataSource = value.AV001_TD_BIL_HAZIRLIK_HIKAYECollection;
                    DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                          typeof(TList<AV001_TD_BIL_HAZIRLIK_HIKAYE>));
                    MyDataSource = value.AV001_TD_BIL_HAZIRLIK_HIKAYECollection;
                }
            }
        }

        private void gridHazirlikHikaye_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gridControl1.Visible)
            {
                gridControl1.Visible = false;
                gridHazirlikHikaye.Visible = true;
            }
            else
            {
                gridControl1.Visible = true;
                gridHazirlikHikaye.Visible = false;
            }
        }

        private void gridHazirlikHikaye_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == "YeniKayit")
            {
                frmSorusturmaHikaye hikaye = new frmSorusturmaHikaye();
                hikaye.MyFoy = MyFoy;

                //hikaye.MdiParent = null;
                hikaye.StartPosition = FormStartPosition.WindowsDefaultLocation;
                hikaye.Show();
            }
            if (e.Button.Tag.ToString() == "KaydiDuzenle")
            {
                frmSorusturmaHikaye hikaye = new frmSorusturmaHikaye();
                TList<AV001_TD_BIL_HAZIRLIK_HIKAYE> HikayeList = new TList<AV001_TD_BIL_HAZIRLIK_HIKAYE>();
                HikayeList.Add(MyDataSource[gwHazirlikHikaye.FocusedRowHandle]);
                hikaye.MyDataSource = HikayeList;
                hikaye.MyFoy = MyFoy;

                //hikaye.MdiParent = null;
                hikaye.StartPosition = FormStartPosition.WindowsDefaultLocation;
                hikaye.Show();
            }
        }

        private void ucHazirlikHikaye_Load(object sender, EventArgs e)
        {
            //LOAD
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.HikayeSurecGetirSorusturma(rLueHikayeSurec);

                //
                try
                {
                    gridHazirlikHikaye.ButtonCevirClick += gridHazirlikHikaye_ButtonCevirClick;
                    gridControl1.ButtonCevirClick += gridHazirlikHikaye_ButtonCevirClick;

                    BelgeUtil.Inits.HazirlikSurecGetir(rLueHikayeSurec);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }
    }
}