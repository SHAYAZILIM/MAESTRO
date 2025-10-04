using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.HazirlikUserControls
{
    public partial class ucHazirlikSikayetNeden : DevExpress.XtraEditors.XtraUserControl
    {
        public ucHazirlikSikayetNeden()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> GridFocusedRowChanged;

        //AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN
        public TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN> MyDataSource
        {
            get
            {
                if (gridHazirlikSikayetNeden.DataSource is TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN>)
                    return (TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN>)gridHazirlikSikayetNeden.DataSource;

                return null;
            }
            set
            {
                gridHazirlikSikayetNeden.DataSource = value;
                gridControl1.DataSource = gridHazirlikSikayetNeden.DataSource;
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MySorusturma { get; set; }

        private void grdSikayetNeden_FocusedRowChanged(object sender,
                                                       DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (GridFocusedRowChanged != null)
                GridFocusedRowChanged(this, new EventArgs());
        }

        private void gridHazirlikSikayetNeden_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gridControl1.Visible)
            {
                gridControl1.Visible = false;
                gridHazirlikSikayetNeden.Visible = false;
            }
            else
            {
                gridControl1.Visible = false;
                gridHazirlikSikayetNeden.Visible = false;
            }
        }

        private void gridHazirlikSikayetNeden_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;

            if (e.Button.Tag == "FormAc")
            {
                frmSikayetNeden sikayet = new frmSikayetNeden();

                sikayet.MySorusturma = MySorusturma;
                sikayet.Show();
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                frmSikayetNeden sikayet = new frmSikayetNeden();
                TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN> vList = new TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN>();
                vList.Add(MyDataSource[grdSikayetNeden.FocusedRowHandle]);
                sikayet.MyDataSource = vList;
                sikayet.MySorusturma = MySorusturma;
                sikayet.Show();
            }
        }

        private void ucHazirlikSikayetNeden_Load(object sender, EventArgs e)
        {
            //LOAD
            if (!this.DesignMode)
            {
                try
                {
                    gridHazirlikSikayetNeden.ButtonCevirClick += gridHazirlikSikayetNeden_ButtonCevirClick;
                    gridControl1.ButtonCevirClick += gridHazirlikSikayetNeden_ButtonCevirClick;

                    BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);

                    BelgeUtil.Inits.DavaAdNedenKodGetir(rLueSikayetNedenKod);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }
    }
}