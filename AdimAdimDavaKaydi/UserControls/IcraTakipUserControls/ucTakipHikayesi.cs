using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms.Icra;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucTakipHikayesi : AvpXUserControl
    {
        private TList<AV001_TI_BIL_FOY_HIKAYE> _MyDataSource;

        private bool initsFilled;

        private AV001_TI_BIL_FOY myFoy;

        public ucTakipHikayesi()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucTakipHikayesi_Load;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_FOY_HIKAYE> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (gcTakipHikayesi != null)
                    gcTakipHikayesi.DataSource = value;
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
                {
                    if (value.AV001_TI_BIL_FOY_HIKAYECollection.Count == 0)
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TI_BIL_FOY_HIKAYE>));
                    MyDataSource = value.AV001_TI_BIL_FOY_HIKAYECollection;
                }
            }
        }

        public void BindLookUps(bool newItem)
        {
            if ((!initsFilled && (MyDataSource.Count > 0)) || newItem)
            {
                BelgeUtil.Inits.HikayeSurecGetir(rlueHikayeSurec);
            }
        }

        private void gcTakipHikayesi_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == "YeniKayit")
            {
                frmTakibinHikayesi hikaye = new frmTakibinHikayesi();
                hikaye.MyFoy = MyFoy;

                //hikaye.MdiParent = null;
                hikaye.StartPosition = FormStartPosition.WindowsDefaultLocation;
                hikaye.Show();
            }
            if (e.Button.Tag.ToString() == "KaydiDuzenle")
            {
                frmTakibinHikayesi hikaye = new frmTakibinHikayesi();
                TList<AV001_TI_BIL_FOY_HIKAYE> HikayeList = new TList<AV001_TI_BIL_FOY_HIKAYE>();
                HikayeList.Add(MyDataSource[gwTakipHikayesi.FocusedRowHandle]);
                hikaye.MyDataSource = HikayeList;
                hikaye.MyFoy = MyFoy;

                //.MdiParent = null;
                hikaye.StartPosition = FormStartPosition.WindowsDefaultLocation;
                hikaye.Show();
            }
        }

        private void ucTakipHikayesi_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            if (_MyDataSource != null)
                gcTakipHikayesi.DataSource = _MyDataSource;
            IsLoaded = true;
            BelgeUtil.Inits.HikayeSurecGetirIcra(rlueHikayeSurec);
        }
    }
}