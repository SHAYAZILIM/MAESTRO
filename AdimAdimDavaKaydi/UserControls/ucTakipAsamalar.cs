using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucTakipAsamalar : AvpXUserControl
    {
        public ucTakipAsamalar()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucTakipAsamalar_Load;
        }

        private VList<T_ASAMA_TARAF_SORUMLU> _MyDataSource;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VList<T_ASAMA_TARAF_SORUMLU> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        private AV001_TI_BIL_FOY myFoy;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (IsLoaded)
                    BindData();
            }
        }

        public void BindData()
        {
            if (MyFoy != null)
            {
                try
                {
                    RefreshAsama();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
            else if (MyDataSource != null)
            {
                gridTakipAsamalari.DataSource = MyDataSource;
            }
        }

        public void RefreshAsama()
        {
            if (MyFoy == null) return;
            if (gridTakipAsamalari != null)
                gridTakipAsamalari.DataSource =
                    DataRepository.T_ASAMA_TARAF_SORUMLUProvider.Get(string.Format("ICRA_FOY_ID={0}", MyFoy.ID),
                                                                     string.Empty);
        }

        private void ucTakipAsamalar_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;
            try
            {
                gridTakipAsamalari.ShowOnlyPredefinedDetails = true;
                InitsDoldur();
                BindData();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private bool initsFilled;

        private void InitsDoldur()
        {
            if (!initsFilled)
            {
                BelgeUtil.Inits.AdliBirimBolumGetir(rLueAdliBirimBolumID);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeID);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimBolumNoID);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorevID);
                BelgeUtil.Inits.perCariGetir(rLueAsamaCariID);
                BelgeUtil.Inits.AsamaAltKodGetir(rLueAsamaAltKodID);
                BelgeUtil.Inits.AsamaKodGetir(rLueAsamaKodID);
                BelgeUtil.Inits.AsamaModulGetir(rLueAsamaModulID);
                BelgeUtil.Inits.AsamaOzelDurumGetir(rLueOzelDurumID);
                BelgeUtil.Inits.CariSifatGetir(rLueAsamaSifatID);
                BelgeUtil.Inits.AlacakNedenKodGetir(rLueAsamaAlacakNedenID);

                initsFilled = true;
            }
        }
    }
}