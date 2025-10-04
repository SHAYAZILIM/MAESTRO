using System;
using System.ComponentModel;
using AvukatProLib2.Entities;
using DevExpress.XtraVerticalGrid.Events;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucTespitKaydet : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTespitKaydet()
        {
            InitializeComponent();
        }

        public event EventHandler MyDataSourceChanged;
        public event IndexChangedEventHandler FocusedHacizChanged;

        [Browsable(false)]
        public TList<AV001_TDI_BIL_TESPIT> MyDataSource
        {
            get
            {
                if (vGridTEspitKaydet.DataSource is TList<AV001_TDI_BIL_TESPIT>)
                    return (TList<AV001_TDI_BIL_TESPIT>)vGridTEspitKaydet.DataSource;
                return null;
            }
            set
            {
                if (value != null && !DesignMode)
                {
                    vGridTEspitKaydet.DataSource = value;
                    //value.AddNew();
                    // value.AddingNew += new AddingNewEventHandler(value_AddingNew);
                    if (MyDataSourceChanged != null)
                    {
                        MyDataSourceChanged(this, new EventArgs());
                    }
                }
            }
        }

        //void value_AddingNew(object sender, AddingNewEventArgs e)
        //{
        //    AV001_TDI_BIL_TESPIT_TARAF tespitTaraf=new AV001_TDI_BIL_TESPIT_TARAF();

        //    e.NewObject=tespitTaraf;

        //    MySource.AddNew();
        //    //MyDataSource[0].AV001_TDI_BIL_TESPIT_TARAFCollection.Add(tespitTaraf);
        //}
        [Browsable(false)]
        public AV001_TDI_BIL_TESPIT CurrentTespit
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                if (vGridTEspitKaydet.FocusedRecord > -1 && MyDataSource.Count > vGridTEspitKaydet.FocusedRecord)
                    return MyDataSource[vGridTEspitKaydet.FocusedRecord];
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != null)
                    MyDataSource[vGridTEspitKaydet.FocusedRecord] = value;
            }
        }


        [Browsable(false)]
        public TList<AV001_TDI_BIL_TESPIT_TARAF> MySource
        {
            get
            {
                if (exGridTEspitTaraf.DataSource is TList<AV001_TDI_BIL_TESPIT_TARAF>)
                    return (TList<AV001_TDI_BIL_TESPIT_TARAF>)exGridTEspitTaraf.DataSource;
                return null;
            }
            set
            {
                if (value != null && !DesignMode)
                {
                    exGridTEspitTaraf.DataSource = value;
                    //value.AddNew();
                }
            }
        }

        private void ucTespitKaydet_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            #region LookUps

            rLueADliye.NullText = "Seç";
            rLueGorev.NullText = "Seç";
            rLueBirimNo.NullText = "Seç";
            rLueCARI.NullText = "Seç";
            rLueItirazSonucu.NullText = "Seç";
            rLueYapilanCARI.NullText = "Seç";
            rLueTespitKonu.NullText = "Seç";
            rLueDovizID.NullText = "Seç";
            rLueADliye.Enter += delegate { BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueADliye); };
            rLueGorev.Enter += delegate { BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev); };
            rLueBirimNo.Enter += delegate { BelgeUtil.Inits.AdliBirimNoGetir(rLueBirimNo); };
            BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
            rLueCARI.Enter += delegate { BelgeUtil.Inits.perCariGetir(rLueCARI); };
            rLueItirazSonucu.Enter += delegate { BelgeUtil.Inits.ItirazSonucuGetir(rLueItirazSonucu); };
            rLueYapilanCARI.Enter += delegate { BelgeUtil.Inits.perCariGetir(rLueYapilanCARI); };
            rLueTespitKonu.Enter += delegate { BelgeUtil.Inits.TespitKonuGetir(rLueTespitKonu); };
            vGridTEspitKaydet.FocusedRecordChanged += vGridTEspitKaydet_FocusedRecordChanged;

            #endregion
        }

        private void vGridTEspitKaydet_FocusedRecordChanged(object sender, IndexChangedEventArgs e)
        {
            if (FocusedHacizChanged != null)
            {
                FocusedHacizChanged(sender, e);
            }
        }

        private void dataNavigatorExtended1_PositionChanged(object sender, EventArgs e)
        {
            if (FocusedHacizChanged != null)
            {
                FocusedHacizChanged(null, null);
            }
        }
    }
}