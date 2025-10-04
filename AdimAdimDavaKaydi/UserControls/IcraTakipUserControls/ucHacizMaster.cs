using System;
using System.ComponentModel;
using System.Linq;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraVerticalGrid.Events;
using AdimAdimDavaKaydi.Belge.Forms;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucHacizMaster : DevExpress.XtraEditors.XtraUserControl
    {
        #region Fields

        private AV001_TI_BIL_FOY myFoy;

        #endregion Fields

        #region Constructors

        public ucHacizMaster()
        {
            InitializeComponent();
            this.Load += ucHacizMaster_Load;
        }

        #endregion Constructors

        #region Events

        [Category("Haciz Master Events")]
        public event IndexChangedEventHandler HacizMasterFocusedRecordChanged;

        [Category("Haciz Master Events")]
        public event ValidateRecordEventHandler HacizMasterValidateRecord;

        #endregion Events

        #region Properties

        [Browsable(false),
        Description("Haciz Master FocusedRecordIndex"),
        Category("Haciz Master Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HacizFocusedRecord
        {
            get
            {
                if (vgHacizMaster.FocusedRecord < 0)
                    return 0;

                return vgHacizMaster.FocusedRecord;
            }

            //set { hacizFocusedRecord = value; }
        }

        [Browsable(false),
        Description("DataSource"),
        Category("Haciz Master Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_HACIZ_MASTER> MyDataSource
        {
            get
            {
                if (vgHacizMaster.DataSource is TList<AV001_TI_BIL_HACIZ_MASTER>)
                    return (TList<AV001_TI_BIL_HACIZ_MASTER>)vgHacizMaster.DataSource;
                else
                    return null;
            }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    dataNavigatorExtended1.DataSource = value;
                    vgHacizMaster.DataSource = dataNavigatorExtended1.DataSource;
                }
            }
        }

        [Browsable(false),
        Description("AV001_TI_BIL_FOY"),
        Category("Haciz Master Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    BelgeUtil.Inits.BorcluTarafByFoy(MyFoy, new[] { rlueBorclu });
                    BelgeUtil.Inits.AlacakliTarafByFoy(MyFoy, new[] { rlueAlacakli });
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Otomatik haciz sýra numarasý
        /// </summary>
        /// <param name="list">AV001_TI_BIL_HACIZ_MASTER türündeki kayýtlarýn tutulduðu temp liste</param>
        /// <param name="foy">AV001_TI_BIL_FOY türündeki dosya üzerindeki aktif foy nesnesi</param>
        /// <returns>HACIZ_SIRA_NO</returns>
        public static int SiraNo(AV001_TI_BIL_FOY foy)
        {
            int i = 1;

            if (foy.AV001_TI_BIL_HACIZ_MASTERCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_HACIZ_MASTER>));

            if (foy.AV001_TI_BIL_HACIZ_MASTERCollection.Count > 0)
            {
                int hacizSiraNo = foy.AV001_TI_BIL_HACIZ_MASTERCollection.Last().HACIZ_SIRA_NO;

                i = ++hacizSiraNo;
            }

            return i;
        }

        private void ucHacizMaster_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
            BelgeUtil.Inits.BirimKodGetir(rlueAdetBirim);
            BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
            BelgeUtil.Inits.BorcluTarafByFoy(MyFoy, new[] { rlueBorclu });
            BelgeUtil.Inits.AlacakliTarafByFoy(MyFoy, new[] { rlueAlacakli });
            BelgeUtil.Inits.CariAdliPersonelGetir(rlueHacMemAdliPer);
            BelgeUtil.Inits.CariPersonelGetir(rlueSorumluPersonel);
            BelgeUtil.Inits.ParaBicimiAyarla(tutar);
            BelgeUtil.Inits.HAcizKaynakGetir(rLueHacizKaynagi);
            AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(rlueBelge);
        }

        private void vgHacizMaster_FocusedRecordChanged(object sender, IndexChangedEventArgs e)
        {
            if (HacizMasterFocusedRecordChanged != null)
            {
                HacizMasterFocusedRecordChanged(sender, e);
            }
        }

        private void vgHacizMaster_ValidateRecord(object sender, ValidateRecordEventArgs e)
        {
            if (HacizMasterValidateRecord != null)
            {
                HacizMasterValidateRecord(sender, e);
            }
        }

        #endregion Methods

        private void rlueBelge_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                frmBelgeKayitUfak frmblg = new frmBelgeKayitUfak();
                frmblg.ShowDialog();
                AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(rlueBelge);
            }
        }
    }
}