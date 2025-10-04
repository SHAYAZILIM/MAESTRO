using System;
using System.ComponentModel;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucHasarKayitvGrid : DevExpress.XtraEditors.XtraUserControl
    {
        public ucHasarKayitvGrid()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_POLICE_HASAR> MyDataSource
        {
            get
            {
                if (vGridHasarKaydet.DataSource is TList<AV001_TDI_BIL_POLICE_HASAR>)
                    return (TList<AV001_TDI_BIL_POLICE_HASAR>)vGridHasarKaydet.DataSource;
                return null;
            }
            set
            {
                if (value == null)
                {
                    vGridHasarKaydet.DataSource = value;
                    dataNavigatorExtended1.DataSource = value;
                }

                else if (value != null && !this.DesignMode)
                {
                    vGridHasarKaydet.DataSource = value;
                    dataNavigatorExtended1.DataSource = value;
                    value.AddingNew += value_AddingNew;
                }
            }
        }

        private void value_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_POLICE_HASAR addNew = new AV001_TDI_BIL_POLICE_HASAR();
            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            addNew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addNew.KONTROL_NE_ZAMAN = DateTime.Now;
            e.NewObject = addNew;
        }

        private void ucHasarKayitvGrid_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            #region <TIO - 20090616> Inits

            BelgeUtil.Inits.DovizTipGetir(rLueDOvizID);
            BelgeUtil.Inits.TeminatAltTipGetir(rLueTeminatAltTip);
            //TIO: Katman basýlacak ve sonrasýnda hasar durum  ve rucu durum için lookup yapýlacak . unutulmasýn .. 16062009
            //rLueHasarDosyaDurum
            //rLueRucuDurum

            #endregion </TIO - 20090616>
        }
    }
}