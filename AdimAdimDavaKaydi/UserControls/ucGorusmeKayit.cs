using System;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using AvukatPro.Services.Implementations;
using AvukatPro.Services.Interfaces;
using AvukatProLib.Extras;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucGorusmeKayit : DevExpress.XtraEditors.XtraUserControl
    {

        public ucGorusmeKayit()
        {
            InitializeComponent();
        }

        private TList<AV001_TDI_BIL_GORUSME> _myDataSource = new TList<AV001_TDI_BIL_GORUSME>();

        public TList<AV001_TDI_BIL_GORUSME> MyDataSource
        {
            get
            {
                if (vGridGorusmeKayit.DataSource is TList<AV001_TDI_BIL_GORUSME>)
                    return (TList<AV001_TDI_BIL_GORUSME>)vGridGorusmeKayit.DataSource;
                if (dataNavigatorExtended1.DataSource is TList<AV001_TDI_BIL_GORUSME>)
                    return (TList<AV001_TDI_BIL_GORUSME>)dataNavigatorExtended1.DataSource;
                return null;
            }
            set
            {
                vGridGorusmeKayit.DataSource = value;
                dataNavigatorExtended1.DataSource = value;
            }
        }

        public AvukatProLib.Extras.ModulTip ModulTipi { get; set; }

        private void ucGorusmeKayit_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            BelgeUtil.Inits.perCariGetir(rLueGorusulenCari);

            if (MyDataSource != null && MyDataSource.Count > 0 && MyDataSource[0].ID == 0)
                rLueCari.Enter += delegate { BelgeUtil.Inits.CariPersonelGetir(rLueCari); };
            else
                BelgeUtil.Inits.CariPersonelGetir(rLueCari);

            BelgeUtil.Inits.GorusmeYonuGetir(rLueGorusmeYonu);

            AvukatPro.Services.Implementations.DevExpressService.AltKategoriDoldur(rLueIsKategori, true);

            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod1, 1, Modul.Gorusme);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod2, 2, Modul.Gorusme);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod3, 3, Modul.Gorusme);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod4, 4, Modul.Gorusme);

            rlueOzelKod1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            rlueOzelKod2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            rlueOzelKod3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            rlueOzelKod4.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
        }

        void lueOzelKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == "ekle")
            {
                AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle frm = new AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod1, 1, Modul.Gorusme);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod2, 2, Modul.Gorusme);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod3, 3, Modul.Gorusme);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod4, 4, Modul.Gorusme);
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            if (MyDataSource == null)
            {
                MessageBox.Show("Öncelikle Gorusmeyi Kaydediniz.");
                return;
            }
            AV001_TDI_BIL_GORUSME gorusme = MyDataSource[vGridGorusmeKayit.FocusedRecord];
            if (gorusme.ID == 0)
            {
                MessageBox.Show("Öncelikle Gorusmeyi Kaydediniz.");
                return;
            }
            AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
            frmisKayit.ucIsKayitUfak1.OpenedRecord = gorusme;
            frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frmisKayit.Show();
        }

        private void rLueGorusulenCari_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frmCariGenelGiris frm = new frmCariGenelGiris();
                if (!frm.IsDisposed)
                    frm.Show();
                BelgeUtil.Inits.perCariGetir(rLueGorusulenCari);
            }
        }
    }
}