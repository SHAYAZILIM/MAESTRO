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
    public partial class ucHasarBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        public ucHasarBilgileri()
        {
            if (DesignMode) InitializeComponent();
            this.Load += this.ucHasarBilgileri_Load;
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "Dosya_No" || e.Column.FieldName == "Adliye"
                || e.Column.FieldName == "No" || e.Column.FieldName == "Esas_No" || e.Column.FieldName == "Takip_T" ||
                e.Column.FieldName == "Gorev" || e.Column.FieldName == "Referans1")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kaydý");
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Takip Ekranýna Gönder");

                R_BIRLESIK_TAKIPLER_POLICE_HASAR secim = e.Rows as R_BIRLESIK_TAKIPLER_POLICE_HASAR;

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
            R_BIRLESIK_TAKIPLER_POLICE_HASAR tum = e.Item.Tag as R_BIRLESIK_TAKIPLER_POLICE_HASAR;
            if (tum.Dosya_No.Contains("I") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Icra)
            {
                TList<AV001_TI_BIL_FOY> foyList = new TList<AV001_TI_BIL_FOY>();
                foyList.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(tum.ID.Value));
                _frmIcraTakip IcraTk = new _frmIcraTakip();
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
                //.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foyList);
            }
        }

        private TList<AV001_TDI_BIL_POLICE_HASAR> _MyDataSource = new TList<AV001_TDI_BIL_POLICE_HASAR>();

        [Browsable(false)]
        public TList<AV001_TDI_BIL_POLICE_HASAR> MyDataSource
        {
            get
            {
                return _MyDataSource;
            }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        private bool IsLoaded;

        private void ucHasarBilgileri_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;
            if (!IsLoaded) InitializeComponent();
            this.gridView1.MasterRowExpanding += gridView1_MasterRowExpanding;
            exGridHasarBilgileri.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
            IsLoaded = true;
            BindData();

            exGridHasarBilgileri.ShowOnlyPredefinedDetails = true;
        }

        private void BindData()
        {
            if (MyDataSource == null) return;
            LoadInitsData();
            MyDataSource.ListChanged += MyDataSource_ListChanged;
            MyDataSource.AddingNew += MyDataSource_AddingNew;
            exGridHasarBilgileri.DataSource = MyDataSource;
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            LoadInitsData();
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            LoadInitsData();
        }

        private bool initsFilled;

        private void LoadInitsData()
        {
            if (!initsFilled && MyDataSource.Count > 0)
            {
                BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
                BelgeUtil.Inits.TeminatAltTipGetir(rLueTeminatAltTip);
                BelgeUtil.Inits.TarafSifatGetir(rLueTarafSifat);
                BelgeUtil.Inits.perCariGetir(rLueCari);
                BelgeUtil.Inits.TarafKoduEnumGetir(rLueTarafKodu);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueBirimNo);
                BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKod);
                BelgeUtil.Inits.BankaGetir(rLueBanka);
                BelgeUtil.Inits.BankaSubeGetir(rLueBSube);
                BelgeUtil.Inits.FoyBirimGetir(rLueFoyBirim);
                BelgeUtil.Inits.FoyYeriGetir(rLueFoyYeri);
                BelgeUtil.Inits.FoyOzelDurumGetir(rLueFoyOzelDurum);
                BelgeUtil.Inits.TahsilatdurumGetir(rLueTahsilatDurum);
                BelgeUtil.Inits.KrediGrubu(rLueKrediGrup);
                BelgeUtil.Inits.KrediTipiGetir(rLueKrediTip);
                BelgeUtil.Inits.ModulGetir(rLueModul);

                initsFilled = true;
            }
        }

        private void gridView1_MasterRowExpanding(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs e)
        {
            AV001_TDI_BIL_POLICE_HASAR gelen = (AV001_TDI_BIL_POLICE_HASAR)gridView1.GetRow(e.RowHandle);
            if (gelen.R_BIRLESIK_TAKIPLER_POLICE_HASARCollection != null) return;

            gelen.R_BIRLESIK_TAKIPLER_POLICE_HASARCollection =
                DataRepository.R_BIRLESIK_TAKIPLER_POLICE_HASARProvider.Get(string.Format("HASAR_ID={0}", gelen.ID), "KAYIT_TARIHI ASC");
        }

        private void exGridHasarBilgileri_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;

            else if (e.Button.Tag.ToString() == "FormAc")
            {
                Forms.frmHasarKaydetVgrid HasarKayit = new AdimAdimDavaKaydi.Forms.frmHasarKaydetVgrid();
                // HasarKayit.MdiParent = null;
                HasarKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                HasarKayit.ucHasarKayitvGrid1.MyDataSource = MyDataSource;
                HasarKayit.IsModul = true;
                HasarKayit.Show();
            }
            else if (e.Button.Tag.ToString() == "KayitDuzenle")
            {
                Forms.frmHasarKaydetVgrid HasarKayit = new AdimAdimDavaKaydi.Forms.frmHasarKaydetVgrid();
                // HasarKayit.MdiParent = null;
                HasarKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                HasarKayit.ucHasarKayitvGrid1.MyDataSource = MyDataSource;
                HasarKayit.IsModul = true;
                HasarKayit.Show();
            }
        }
    }
}