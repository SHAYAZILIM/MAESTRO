using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucIhtiyatiTedbir : AvpXUserControl
    {
        private BackgroundWorker bckWorker = new BackgroundWorker();

        private bool initsFilled;

        public ucIhtiyatiTedbir()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucIhtiyatiTedbir_Load;
        }

        #region Properties

        private TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> _MyDataSource;
        private AV001_TI_BIL_FOY myFoy;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                BindData();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;
            }
        }

        #endregion Properties

        #region Events

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource.Count == 0 && MyFoy != null)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>));
                _MyDataSource = MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && IsLoaded)
            {
                LoadInitsData();
                gridIhtiyatiTedbir.DataSource = MyDataSource;
            }
        }

        private void frm_Kaydedildi(object sender, EventArgs e)
        {
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>));
            MyDataSource = MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;
            gridIhtiyatiTedbir.DataSource = MyDataSource;
        }

        private void gridIhtiyatiTedbir_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            else if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                frmDavaIcraIhtiyatiTedbir frm = new frmDavaIcraIhtiyatiTedbir();
                frm.MyFoy = MyFoy;
                frm.MyDataSource = null;
                frm.Kaydedildi += new EventHandler<EventArgs>(frm_Kaydedildi);
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
            }
            else if (e.Button.Tag.ToString() == "Duzenle" && gwIhtiyatiTedbir.GetFocusedRow() != null)
            {
                #region <AC - 20090614>

                frmDavaIcraIhtiyatiTedbir frm = new frmDavaIcraIhtiyatiTedbir();
                frm.MyFoy = MyFoy;
                frm.Kaydedildi += frm_Kaydedildi;
                frm.MyDataSource = MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();

                #endregion <AC - 20090614>
            }
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            LoadInitsData();
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            LoadInitsData();
        }

        private void ucIhtiyatiTedbir_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        #endregion Events

        #region Methods

        public void BindData()
        {
            if (MyDataSource == null) return;
            MyDataSource.ListChanged += MyDataSource_ListChanged;
            MyDataSource.AddingNew += MyDataSource_AddingNew;
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        private void LoadInitsData()
        {
            if (!initsFilled && MyDataSource.Count > 0)
            {
                BelgeUtil.Inits.TeminatTuruGetir(rLueTeminatTurID);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeID);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorevID);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNoID);
                BelgeUtil.Inits.DovizTipGetir(rLueTeminatDovizID);
                BelgeUtil.Inits.perCariGetir(rLueCariID);
                BelgeUtil.Inits.IcraItirazSonucGetir(rLueSonucId);
                BelgeUtil.Inits.TarafKoduGetir(rLueTarafKodu);
                BelgeUtil.Inits.TarafSifatGetir(rLueTarafSifat);

                initsFilled = true;
            }
        }

        #endregion Methods
    }
}