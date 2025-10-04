using AvukatProLib2.Entities;
using System;
using System.ComponentModel;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmTebligatKaydetVgrid : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmTebligatKaydetVgrid()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public bool Ihtarname;

        private TList<AV001_TDI_BIL_TEBLIGAT> _MyDataSource;

        private AV001_TI_BIL_FOY _myFoy;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_TEBLIGAT> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                if (!this.DesignMode && value != null)
                {
                    _MyDataSource = value;
                    ucTebligatKayitUfakDock1.Ihtarname = Ihtarname;
                    ucTebligatKayitVgrid1.MyDataSource = value;
                    ucTebligatKayitUfakDock1.MyFoy = MyFoy;
                    ucTebligatKayitUfakDock1.MyDataSource = value;
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return _myFoy; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    _myFoy = value;
                }
            }
        }
        
        public void Show(AV001_TI_BIL_FOY foy)
        {
            MyFoy = foy;
            if (MyDataSource == null)
                MyDataSource = foy.AV001_TDI_BIL_TEBLIGATCollection;
            this.Show();
        }
        
        public void TebligatDoldur()
        {
            if (MyDataSource == null)
            {
                MyDataSource = BelgeUtil.Inits.TebligatGetir();
            }
            ucTebligatKayitVgrid1.MyDataSource = MyDataSource;
            ucTebligatKayitUfakDock1.MyDataSource = MyDataSource;
        }

        private void frmTebligatKaydetVgrid_Load(object sender, EventArgs e)
        {
            //LOAD
            TebligatDoldur();
        }

        private void InitializeEvents()
        {
            EventlerKullanilacakMi = true;
        }
    }
}