using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.DavaTakip;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AdimAdimDavaKaydi.Sozlesme.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucPoliceBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        public ucPoliceBilgileri()
        {
            if (DesignMode) InitializeComponent();
            this.Load += this.ucPoliceBilgileri_Load;
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "Dosya_No" || e.Column.FieldName == "Adliye"
                || e.Column.FieldName == "No" || e.Column.FieldName == "Esas_No" || e.Column.FieldName == "Takip_T" ||
                e.Column.FieldName == "Gorev" || e.Column.FieldName == "Referans1")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kaydý");
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Takip Ekranýna Gönder");

                R_BIRLESIK_TAKIPLER_POLICE secim = e.Rows as R_BIRLESIK_TAKIPLER_POLICE;

                bus.ItemLinks.Add(barBtnSecimiKaldir);
                if (secim != null)
                {
                    barBtnSecimiKaldir.Tag = secim;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(0, bus);
            }
        }

        private void barBtnSecimiKaldir_ItemClick(object sender, ItemClickEventArgs e)
        {
            R_BIRLESIK_TAKIPLER_POLICE tum = e.Item.Tag as R_BIRLESIK_TAKIPLER_POLICE;
            if (tum.Dosya_No.Contains("I") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Icra)
            {
                TList<AV001_TI_BIL_FOY> foyList = new TList<AV001_TI_BIL_FOY>();
                foyList.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(tum.ID.Value));
                _frmIcraTakip IcraTk = new _frmIcraTakip();
                //IcraTk.MdiParent = null;
                IcraTk.StartPosition = FormStartPosition.WindowsDefaultLocation;
                IcraTk.Show(foyList);
            }
            if (tum.Dosya_No.Contains("D") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Dava)
            {
                TList<AV001_TD_BIL_FOY> foyList = new TList<AV001_TD_BIL_FOY>();
                foyList.Add(DataRepository.AV001_TD_BIL_FOYProvider.GetByID(tum.ID.Value));
                frmDavaTakip frm = new frmDavaTakip();
                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foyList);
            }
            if (tum.Dosya_No.Contains("S") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Sozlesme)
            {
                TList<AV001_TDI_BIL_SOZLESME> foyList = new TList<AV001_TDI_BIL_SOZLESME>();
                foyList.Add(DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(tum.ID.Value));
                frmSozlesmeTakip frm = new frmSozlesmeTakip();
                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foyList);
            }
            if (tum.Dosya_No.Contains("H") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Sorusturma)
            {
                TList<AV001_TD_BIL_HAZIRLIK> foyList = new TList<AV001_TD_BIL_HAZIRLIK>();
                foyList.Add(DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(tum.ID.Value));
                rFrmSorusturmaTakip frm = new rFrmSorusturmaTakip();
                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foyList);
            }
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_POLICE> MyDataSource
        {
            get
            {
                if (gridPoliceBilgileri != null)
                {
                    if (gridPoliceBilgileri.DataSource is TList<AV001_TDI_BIL_POLICE>)
                        return (TList<AV001_TDI_BIL_POLICE>)gridPoliceBilgileri.DataSource;
                }
                return null;
            }
            set
            {
                if (value == null)
                {
                    if (gridPoliceBilgileri != null)
                    {
                        if (IsLoaded)
                        {
                            gridPoliceBilgileri.DataSource = value;
                            extendedGridControl1.DataSource = value;
                        }
                    }
                }
            }
        }

        private void ucPoliceBilgileri_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            gridPoliceBilgileri.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
            gridPoliceBilgileri.ButtonCevirClick += gridPoliceBilgileri_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += gridPoliceBilgileri_ButtonCevirClick;

            gridPoliceBilgileri.ShowOnlyPredefinedDetails = true;

            InitsDoldur();
        }

        private void InitsDoldur()
        {
            BelgeUtil.Inits.PoliceBransGetir(rLuePoliceBrans);
            BelgeUtil.Inits.DovizTipGetir(rLuePoliceTeminatDoviztip);
            BelgeUtil.Inits.perCariGetir(rLuePoliceCari);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
            BelgeUtil.Inits.BankaGetir(rLueBanka);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueBirimNo);
            BelgeUtil.Inits.BankaSubeGetir(rLueBSube);
            BelgeUtil.Inits.FoyBirimGetir(rLueFoyBirim);
            BelgeUtil.Inits.FoyDurumGetir(rLueFoyDurum);
            BelgeUtil.Inits.FoyOzelDurumGetir(rLueFoyOzelDurum);
            BelgeUtil.Inits.FoyYeriGetir(rLueFoyYeri);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
            BelgeUtil.Inits.KrediGrubu(rLueKrediGrup);
            BelgeUtil.Inits.KrediTipiGetir(rLueKrediTip);
            BelgeUtil.Inits.ModulGetir(rLueModul);
            BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKod);
            BelgeUtil.Inits.TahsilatdurumGetir(rLueTahsilatDurum);
            BelgeUtil.Inits.TarafKoduGetir(rLueTarafKodu);
            BelgeUtil.Inits.TarafSifatGetir(rLueTarafSifat);
        }

        private void gridPoliceBilgileri_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gridPoliceBilgileri.Visible)
            {
                extendedGridControl1.Visible = true;
                gridPoliceBilgileri.Visible = false;
            }
            else
            {
                extendedGridControl1.Visible = false;
                gridPoliceBilgileri.Visible = true;
            }
        }

        private void gwPoliceBilgileri_MasterRowExpanding(object sender,
                                                          DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs e)
        {
            AV001_TDI_BIL_POLICE gelen = (AV001_TDI_BIL_POLICE)gwPoliceBilgileri.GetRow(e.RowHandle);
            if (gelen.R_BIRLESIK_TAKIPLER_POLICECollection != null) return;

            gelen.R_BIRLESIK_TAKIPLER_POLICECollection =
                DataRepository.R_BIRLESIK_TAKIPLER_POLICEProvider.Get(string.Format("POLICE_ID={0}", gelen.ID),
                                                                      "KAYIT_TARIHI ASC");
        }
    }
}