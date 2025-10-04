using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucHazirlikGorusme : DevExpress.XtraEditors.XtraUserControl
    {
        private AV001_TD_BIL_HAZIRLIK myHazirlik;

        public ucHazirlikGorusme()
        {
            InitializeComponent();
            this.Load += ucHazirlikGorusme_Load;
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_GORUSME> MyDataSource
        {
            get
            {
                if (gridHazirlikGorusme.DataSource is TList<AV001_TDI_BIL_GORUSME>)
                    return (TList<AV001_TDI_BIL_GORUSME>)gridHazirlikGorusme.DataSource;
                return null;
            }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    gridHazirlikGorusme.DataSource = value;
                    extendedGridControl1.DataSource = gridHazirlikGorusme.DataSource;
                }
            }
        }

        public AV001_TD_BIL_HAZIRLIK MyHazirlik
        {
            get { return myHazirlik; }
            set
            {
                myHazirlik = value;

                if (value != null)
                    MyDataSource = value.AV001_TDI_BIL_GORUSMECollection;
            }
        }

        private void gridHazirlikGorusme_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                rFrmGorusmeKayit frmKayit = new rFrmGorusmeKayit();
                frmKayit.Show(MyHazirlik);
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                rFrmGorusmeKayit gorusme = new rFrmGorusmeKayit();
                TList<AV001_TDI_BIL_GORUSME> vList = new TList<AV001_TDI_BIL_GORUSME>();
                vList.Add(MyDataSource[gwHazirlikGorusme.FocusedRowHandle]);
                gorusme.AddNewList = vList;
                gorusme.MyHazirlik = MyHazirlik;
                gorusme.Show();
            }
        }

        private void ucHazirlikGorusme_Load(object sender, EventArgs e)
        {
            //LOAD
            if (!this.DesignMode)
            {
                try
                {
                    gridHazirlikGorusme.ShowOnlyPredefinedDetails = true;
                    BelgeUtil.Inits.perCariGetir(rlueCari);
                    BelgeUtil.Inits.CariPersonelGetir(rluePersonelCari);
                    BelgeUtil.Inits.MuhasebeHareketAltKategoriForGorusme(rlueKategori);
                    BelgeUtil.Inits.GorusmeYonuGetir(rluegorusmeYonu);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }
    }
}