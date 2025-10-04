using System;
using System.Windows.Forms;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucMarkaUrunHizmetBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucMarkaUrunHizmetBilgileri()
        {
            InitializeComponent();
            this.Load += ucMarkaUrunHizmetBilgileri_Load;
        }

        private void ucMarkaUrunHizmetBilgileri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            gridControl1.ButtonCevirClick += gridControl1_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += gridControl1_ButtonCevirClick;

            BelgeUtil.Inits.UrunKategoriGetir(rLueUrunKategori);
            //GetData.initSektor(rLueHizmetSektor);
        }

        private void gridControl1_ButtonCevirClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (extendedGridControl1.Visible)
            {
                extendedGridControl1.Visible = false;
                gridControl1.Visible = true;
            }
            else
            {
                extendedGridControl1.Visible = true;
                gridControl1.Visible = false;
            }
        }

        public TList<AV001_TS_BIL_MARKA_URUN_HIZMET_BILGILERI> MyDataSoruce
        {
            get
            {
                if (gridControl1.DataSource is TList<AV001_TS_BIL_MARKA_URUN_HIZMET_BILGILERI>)
                    return (TList<AV001_TS_BIL_MARKA_URUN_HIZMET_BILGILERI>)gridControl1.DataSource;
                else
                    return null;
            }
            set
            {
                gridControl1.DataSource = value;
                extendedGridControl1.DataSource = gridControl1.DataSource;
            }
        }
    }
}