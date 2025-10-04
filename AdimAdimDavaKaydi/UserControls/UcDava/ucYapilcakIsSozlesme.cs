using System;
using System.ComponentModel;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucYapilcakIsSozlesme : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        public ucYapilcakIsSozlesme()
        {
            if (DesignMode) InitializeComponent();
            this.Load += this.ucYapilcakIsSozlesme_Load;
        }

        private TList<AV001_TDI_BIL_IS_SOZLESME> _MyDataSource = new TList<AV001_TDI_BIL_IS_SOZLESME>();

        [Browsable(false)]
        public TList<AV001_TDI_BIL_IS_SOZLESME> MyDataSource
        {
            get
            {
                //if (gridYapilcakIsSozlesmesi.DataSource is TList<AV001_TDI_BIL_IS_SOZLESME>)
                //    return (TList<AV001_TDI_BIL_IS_SOZLESME>)gridYapilcakIsSozlesmesi.DataSource;

                //return null;
                return _MyDataSource;
            }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    _MyDataSource = value;
                }
            }
        }

        private void ucYapilcakIsSozlesme_Load(object sender, EventArgs e)
        {
            //LOAD
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            gridYapilcakIsSozlesmesi.ButtonCevirClick += gridYapilcakIsSozlesmesi_ButtonCevirClick;
            gridControl1.ButtonCevirClick += gridYapilcakIsSozlesmesi_ButtonCevirClick;

            //AV001_TDI_BIL_IS_SOZLESME ada = new AV001_TDI_BIL_IS_SOZLESME();
            //ada.AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLUCollection
            //ada.AV001_TDI_BIL_IS_SOZLESME_DETAYCollection
            if (MyDataSource == null) return;
            MyDataSource.ListChanged += MyDataSource_ListChanged;
            MyDataSource.AddingNew += MyDataSource_AddingNew;
            InitsDoldur();
            gridYapilcakIsSozlesmesi.DataSource = MyDataSource;
            gridControl1.DataSource = gridYapilcakIsSozlesmesi.DataSource;
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            InitsDoldur();
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            InitsDoldur();
        }

        private bool initsFilled;

        private void InitsDoldur()
        {
            if (!initsFilled && MyDataSource.Count > 0)
            {
                BelgeUtil.Inits.FaizTipiGetir(rLueFaizTip);
                BelgeUtil.Inits.FaizTipiGetir(repositoryItemLookUpEdit3);
                BelgeUtil.Inits.FaizIslemTipiGetir(rLueFaizIslemetipi);
                BelgeUtil.Inits.FaizIslemTipiGetir(repositoryItemLookUpEdit2);
                BelgeUtil.Inits.VekaletSozlesmeGetir(repositoryItemLookUpEdit1);
                BelgeUtil.Inits.VekaletSozlesmeGetir(rLueSozlesmeKategori);

                initsFilled = true;
            }
        }

        private void gridYapilcakIsSozlesmesi_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gridYapilcakIsSozlesmesi.Visible)
            {
                gridControl1.Visible = true;
                gridYapilcakIsSozlesmesi.Visible = false;
            }
            else
            {
                gridControl1.Visible = false;
                gridYapilcakIsSozlesmesi.Visible = true;
            }
        }
    }
}