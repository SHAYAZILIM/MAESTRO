using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucRucuBilgileri : DevExpress.XtraEditors.XtraUserControl
    {
        public ucRucuBilgileri()
        {
            InitializeComponent();
        }

        //AV001_TDI_BIL_RUCU

        public List<AvukatProLib.Arama.per_AV001_TDI_BIL_RUCU> MyDataSource
        {
            get
            {
                if (gridRucuBilgileri.DataSource is List<AvukatProLib.Arama.per_AV001_TDI_BIL_RUCU>)
                    return (List<AvukatProLib.Arama.per_AV001_TDI_BIL_RUCU>)gridRucuBilgileri.DataSource;
                return null;
            }
            set
            {
                gridRucuBilgileri.DataSource = value;
                extendedGridControl1.DataSource = gridRucuBilgileri.DataSource;
                //extendedGridControl2.DataSource = gridRucuBilgileri.DataSource;
            }
        }

        private void ucRucuBilgileri_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                gridRucuBilgileri.ButtonCevirClick += gridRucuBilgileri_ButtonCevirClick;
                extendedGridControl1.ButtonCevirClick += gridRucuBilgileri_ButtonCevirClick;

                BelgeUtil.Inits.IbranameDurumGetir(rLueIbranameDurum);
                BelgeUtil.Inits.CariSifatGetir(rLueTarafSifat);
                BelgeUtil.Inits.perCariGetir(rLueRucuCari);
                BelgeUtil.Inits.DovizTipGetir(rLueOdenenTazminatDovizID);
                //Inits.TarihAlaniAyarla(repositoryItemDateEdit1);
            }
        }

        private void gridRucuBilgileri_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gridRucuBilgileri.Visible)
            {
                extendedGridControl1.Visible = true;
                gridRucuBilgileri.Visible = false;
            }
            else
            {
                extendedGridControl1.Visible = false;
                gridRucuBilgileri.Visible = true;
            }
        }
    }
}