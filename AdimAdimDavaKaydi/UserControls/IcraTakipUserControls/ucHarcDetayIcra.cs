using System;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucHarcDetayIcra : DevExpress.XtraEditors.XtraUserControl
    {
        public ucHarcDetayIcra()
        {
            InitializeComponent();
        }

        public TList<AV001_TI_BIL_HARC> MyDataSource
        {
            get
            {
                if (exGridHarcDetay.DataSource is TList<AV001_TI_BIL_HARC>)
                    return (TList<AV001_TI_BIL_HARC>)exGridHarcDetay.DataSource;
                return null;
            }
            set
            {
                exGridHarcDetay.DataSource = value;
                extendedGridControl1.DataSource = exGridHarcDetay.DataSource;
            }
        }

        private void exGridHarcDetay_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (exGridHarcDetay.Visible)
            {
                exGridHarcDetay.Visible = false;
                extendedGridControl1.Visible = true;
            }
            else
            {
                extendedGridControl1.Visible = false;
                exGridHarcDetay.Visible = true;
            }
        }

        private void ucHarcDetayIcra_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
            BelgeUtil.Inits.OdemeYeriGetir(rLueOdemeYeri);
            BelgeUtil.Inits.IcraHarcTipiGetir(rLueNispiHarcKalem);
            BelgeUtil.Inits.MuhasebeHareketAltKategori(rLueMaktuHarcKalem);

            //
            BelgeUtil.Inits.DovizTipGetir(repositoryItemLookUpEdit1);
            BelgeUtil.Inits.MuhasebeHareketAltKategori(repositoryItemLookUpEdit2);
            BelgeUtil.Inits.IcraNispiHarcKodGetir(repositoryItemLookUpEdit3);
            BelgeUtil.Inits.OdemeYeriGetir(repositoryItemLookUpEdit4);

            exGridHarcDetay.ButtonCevirClick += exGridHarcDetay_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += exGridHarcDetay_ButtonCevirClick;
        }
    }
}