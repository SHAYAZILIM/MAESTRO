using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucGelismeler : AvpXUserControl
    {
        private TList<AV001_TI_BIL_FOY_GELISME> _MyDataSource;

        private bool initsLoaded;

        public ucGelismeler()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucGelismeler_Load;
        }

        [Browsable(false)]
        public TList<AV001_TI_BIL_FOY_GELISME> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        private int _FoyID;
        public int FoyID
        {
            get { return _FoyID; }
            set { _FoyID = value; }
        }

        public void BindData()
        {
            if (MyDataSource != null && IsLoaded)
            {
                MyDataSource.ListChanged += MyDataSource_ListChanged;
                MyDataSource.AddingNew += MyDataSource_AddingNew;
                LoadInitsData();
                grdGelismeler.DataSource = MyDataSource;
            }
        }

        private void LoadInitsData()
        {
            if (!initsLoaded) // Okan ARDIÇ // 06.01.2010 // Performans Çalýþmasý
            {
                BelgeUtil.Inits.perCariGetir(rLueCariID);
                BelgeUtil.Inits.GelismeAdimGetirIcra(rLueGelismeAdimID);
                BelgeUtil.Inits.GelismeKaynakTipGetirForIcra(rLueKaynakTip);

                initsLoaded = true;
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

        private void rLueGelismeAdimID_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
                return;
            try
            {
                LookUpEdit lue = sender as LookUpEdit;
                TI_KOD_FOY_GELISME_ADIM Gelisme = new TI_KOD_FOY_GELISME_ADIM();
                if (!string.IsNullOrEmpty(lue.Text))
                {
                    Gelisme.GELISME_ADIM = lue.Text;

                    AvukatProLib2.Data.DataRepository.TI_KOD_FOY_GELISME_ADIMProvider.Save(Gelisme);
                    ((TList<TI_KOD_FOY_GELISME_ADIM>)(rLueGelismeAdimID.DataSource)).Add(Gelisme);
                }
                else
                {
                    XtraMessageBox.Show("Yeni Bir Geliþme Adým Kaydetmek Ýçin Bir Geliþme adým yazmalýsýnýz");
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void rLueGelismeAdimID_ProcessNewValue(object sender,
                                                       DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            try
            {
                LookUpEdit lue = sender as LookUpEdit;
                if (!string.IsNullOrEmpty(lue.Text))
                {
                    TI_KOD_FOY_GELISME_ADIM Gelisme = new TI_KOD_FOY_GELISME_ADIM();

                    Gelisme.GELISME_ADIM = lue.Text;
                    AvukatProLib2.Data.DataRepository.TI_KOD_FOY_GELISME_ADIMProvider.Save(Gelisme);
                    ((TList<TI_KOD_FOY_GELISME_ADIM>)(rLueGelismeAdimID.DataSource)).Add(Gelisme);
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void ucGelismeler_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            if (!IsLoaded)
                InitializeComponent();
            IsLoaded = true;
            BindData();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            int a = -1;
            foreach (AV001_TI_BIL_FOY_GELISME item in MyDataSource)
            {
                a++;
                MyDataSource[a].ICRA_FOY_ID = FoyID;
            }
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_GELISMEProvider.DeepSave(MyDataSource);
        }
    }
}