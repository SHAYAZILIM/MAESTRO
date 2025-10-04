using System;
using System.ComponentModel;
using AvukatProLib.Extras;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucTeminatKefaletKayitForDava : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTeminatKefaletKayitForDava()
        {
            InitializeComponent();
        }

        private TList<AV001_TDI_BIL_TEMINAT_MEKTUP> myDataSource;

        [Browsable(false)]
        public TList<AV001_TDI_BIL_TEMINAT_MEKTUP> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    extendedGridControl1.DataSource = value;
                    dataNavigatorExtended1.DataSource = value;
                    vGridControl1.DataSource = value;

                    value.ForEach(item =>
                        {
                            item.ColumnChanged += new AV001_TDI_BIL_TEMINAT_MEKTUPEventHandler(item_ColumnChanged);
                            if (item.BANKA_ID.HasValue) BelgeUtil.Inits.BankaSubeGetir(rlueSube, (int)item.BANKA_ID);
                        });
                }
            }
        }

        private void item_ColumnChanged(object sender, AV001_TDI_BIL_TEMINAT_MEKTUPEventArgs e)
        {
            if (e.Column == AV001_TDI_BIL_TEMINAT_MEKTUPColumn.BANKA_ID)
                BelgeUtil.Inits.BankaSubeGetir(rlueSube, (int)e.Value);
        }

        public AV001_TD_BIL_FOY MyFoy { get; set; }

        public AV001_TI_BIL_FOY MyIcraFoy { get; set; }

        private ViewType mView;

        [Description("Görünümü deðiþtirir.")]
        public ViewType MView
        {
            get { return mView; }
            set
            {
                mView = value;
                if (value == ViewType.GridView)
                {
                    panelControl1.Visible = false;
                    extendedGridControl1.Visible = true;
                }
                else if (value == ViewType.VGrid)
                {
                    panelControl1.Visible = true;
                    extendedGridControl1.Visible = false;
                }
            }
        }

        private void ucTeminatKefaletKayitForDava_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            #region LookUps

            BelgeUtil.Inits.TeminatTuruGetir(rLueTeminatTur);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
            BelgeUtil.Inits.BankaGetir(rlueBanka);
            BelgeUtil.Inits.perCariGetir(rlueSorumluAvukat);

            #endregion
        }
    }
}