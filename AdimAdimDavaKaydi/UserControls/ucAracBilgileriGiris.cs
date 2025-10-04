using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.DavaTakip;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AdimAdimDavaKaydi.Sozlesme.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucAracBilgileriGiris : DevExpress.XtraEditors.XtraUserControl
    {
        public ucAracBilgileriGiris()
        {
            InitializeComponent();
            this.gridView1.MasterRowExpanding += gridView1_MasterRowExpanding;
            exGridAracBilgiGiris.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "Dosya_No" || e.Column.FieldName == "Adliye"
                || e.Column.FieldName == "No" || e.Column.FieldName == "Esas_No" || e.Column.FieldName == "Takip_T" ||
                e.Column.FieldName == "Gorev" || e.Column.FieldName == "Referans1")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kaydý");
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Takip Ekranýna Gönder");

                R_BIRLESIK_TAKIPLER_TUMU_GEMI_UCAK_ARAC secim = e.Rows as R_BIRLESIK_TAKIPLER_TUMU_GEMI_UCAK_ARAC;

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
            R_BIRLESIK_TAKIPLER_TUMU_GEMI_UCAK_ARAC tum = e.Item.Tag as R_BIRLESIK_TAKIPLER_TUMU_GEMI_UCAK_ARAC;
            if (tum.Dosya_No.Contains("I") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Icra)
            {
                TList<AV001_TI_BIL_FOY> foyList = new TList<AV001_TI_BIL_FOY>();
                foyList.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(tum.ID.Value));
                _frmIcraTakip IcraTk = new _frmIcraTakip();
                //.MdiParent = null;
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
                // frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foyList);
            }
            if (tum.Dosya_No.Contains("H") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Sorusturma)
            {
                TList<AV001_TD_BIL_HAZIRLIK> foyList = new TList<AV001_TD_BIL_HAZIRLIK>();
                foyList.Add(DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(tum.ID.Value));
                rFrmSorusturmaTakip frm = new rFrmSorusturmaTakip();
                // .MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foyList);
            }
        }

        private void gridView1_MasterRowExpanding(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs e)
        {
            //R_BIRLESIK_TAKIPLER_TUMU_GEMI_UCAK_ARAC
            AV001_TDI_BIL_GEMI_UCAK_ARAC gelen = (AV001_TDI_BIL_GEMI_UCAK_ARAC)gridView1.GetRow(e.RowHandle);
            if (gelen.R_BIRLESIK_TAKIPLER_TUMU_GEMI_UCAK_ARACCollectionCollection != null) return;

            gelen.R_BIRLESIK_TAKIPLER_TUMU_GEMI_UCAK_ARACCollectionCollection =
                DataRepository.R_BIRLESIK_TAKIPLER_TUMU_GEMI_UCAK_ARACProvider.Get(
                    string.Format("GEMI_UCAK_ARAC_ID={0}", gelen.ID), "KAYIT_TARIHI ASC");
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> MyDataSource
        {
            get
            {
                if (exGridAracBilgiGiris.DataSource is TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>)
                    return (TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>)exGridAracBilgiGiris.DataSource;
                return null;
            }
            set
            {
                if (value == null)
                {
                    exGridAracBilgiGiris.DataSource = value;
                }

                else
                {
                    exGridAracBilgiGiris.DataSource = value;
                    value.AddingNew += value_AddingNew;
                    extendedGridControl1.DataSource = exGridAracBilgiGiris.DataSource;
                }
            }
        }

        private void value_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_GEMI_UCAK_ARAC addNew = new AV001_TDI_BIL_GEMI_UCAK_ARAC();
            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            addNew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addNew.KONTROL_NE_ZAMAN = DateTime.Now;
            e.NewObject = addNew;
        }

        private void ucAracBilgileriGiris_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            //R_BIRLESIK_TAKIPLER_TUMU_GEMI_UCAK_ARAC

            BelgeUtil.Inits.MalKategoriGetir(rLueMalKategori);
            BelgeUtil.Inits.MalTurGetir(rLueMalTur);
            BelgeUtil.Inits.MalcinsGetir(rLueMalCins);
            BelgeUtil.Inits.BirimKodGetir(rLueMalBirim);
            BelgeUtil.Inits.DovizTipGetir(rLueDoviztip);
            BelgeUtil.Inits.IlceGetirOzetli(rLueIlce);
            BelgeUtil.Inits.IlGetir(rLueIl);
            BelgeUtil.Inits.UlkeGetir(rLueUlke);
            BelgeUtil.Inits.perCariGetir(rLueYapanCariID);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.DosyaDurumGetir(rLueDosyaDurum);
            BelgeUtil.Inits.BankaGetir(rLueBanka);
            BelgeUtil.Inits.BankaSubeGetir(rLueSube);
            BelgeUtil.Inits.FoyBirimGetir(rLueDosyaBirim);
            BelgeUtil.Inits.FoyYeriGetir(rLueDosyaYeri);
            BelgeUtil.Inits.FoyOzelDurumGetir(rLueDosyaOzelDurum);
            BelgeUtil.Inits.TahsilatdurumGetir(rLueTahsilatDurum);
            BelgeUtil.Inits.KrediGrubu(rLueKrediGrup);
            BelgeUtil.Inits.KrediTipiGetir(rLueKrediTip);
            BelgeUtil.Inits.ModulGetir(rLueModul);
            BelgeUtil.Inits.TarafKoduGetir(rlueTarafKodu);
            BelgeUtil.Inits.GemiUcakAraclariGetir(rlueGemiUcakAracTip);
            BelgeUtil.Inits.SozlesmeTakyidatKodGetir(rlueTakyidatKod);
            BelgeUtil.Inits.AracTipGetir(rlueTipi);

            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(rLueAdliBirimNo);
            beTakipSureciniAc.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(beTakipSureciniAc_ButtonClick);
            exGridAracBilgiGiris.ButtonCevirClick += exGridAracBilgiGiris_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += exGridAracBilgiGiris_ButtonCevirClick;

        }

        void beTakipSureciniAc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit be = (sender as ButtonEdit);
            if (string.IsNullOrEmpty(be.Text))
                return;
            int aracID = (gridView1.GetFocusedRow() as AV001_TDI_BIL_GEMI_UCAK_ARAC).ID;
            int foyID = Convert.ToInt32(be.Text);

            AV001_TI_BIL_FOY foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(foyID);

            if (foy == null)
                return;

            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_HACIZ_MASTER>), typeof(TList<AV001_TI_BIL_HACIZ_CHILD>));

            foreach (var master in foy.AV001_TI_BIL_HACIZ_MASTERCollection)
            {
                foreach (var child in master.AV001_TI_BIL_HACIZ_CHILDCollection)
                {
                    if (child.ARAC_BILGI_ID == aracID)
                    {
                        frmMalTakipSureci malTakip = new frmMalTakipSureci();
                        var liste = new TList<AV001_TI_BIL_HACIZ_CHILD>();
                        //var child = e.Item.Tag as AV001_TI_BIL_HACIZ_CHILD;
                        liste.Add(child);
                        malTakip.MyDataSource = liste;
                        malTakip.MyFoy = foy;
                        //malTakip.FormClosing += malTakip_FormClosing;
                        malTakip.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        malTakip.Show();
                    }
                }
            }
        }

        private void exGridAracBilgiGiris_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (exGridAracBilgiGiris.Visible)
            {
                exGridAracBilgiGiris.Visible = false;
                extendedGridControl1.Visible = true;
            }
            else
            {
                exGridAracBilgiGiris.Visible = true;
                extendedGridControl1.Visible = false;
            }
        }

        private void exGridAracBilgiGiris_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                frmGemiUcakAracKayit uga = new frmGemiUcakAracKayit();
                // uga.MdiParent = null;
                uga.StartPosition = FormStartPosition.WindowsDefaultLocation;
                TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> listE = new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();
                listE.Add(new AV001_TDI_BIL_GEMI_UCAK_ARAC() { KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu });
                uga.MyDataSource = listE;
                uga.Show();
            }
            else if (e.Button.Tag.ToString() == "KayitDuzenle")
            {
                TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> listE = new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();
                listE.Add(gridView1.GetFocusedRow() as AV001_TDI_BIL_GEMI_UCAK_ARAC);

                if (listE.Count > 0)
                {
                    frmGemiUcakAracKayit frm = new frmGemiUcakAracKayit();
                    // uga.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.MyDataSource = listE;
                    frm.Show();
                }
            }
        }
        //private void exGridAracBilgiGiris_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        //{
        //    if (e.Button.Tag.ToString() == null) 
        //        return;

        //    else if (e.Button.Tag.ToString() == "MalTakipSureci")
        //    {
        //        frmMalTakipSureci malTakip = new frmMalTakipSureci();

        //        if (gridView1.GetFocusedRow() != null)
        //        {
        //            AV001_TDI_BIL_GEMI_UCAK_ARAC Row = (AV001_TDI_BIL_GEMI_UCAK_ARAC)gridView1.GetFocusedRow();
        //            if (Row != null && Row.AV001_TI_BIL_HACIZ_CHILDCollection != null &&
        //                Row.AV001_TI_BIL_HACIZ_CHILDCollection.Count > 0)
        //            {
        //                malTakip.MyDataSource = Row.AV001_TI_BIL_HACIZ_CHILDCollection;
        //                //malTakip.MdiParent = null;
        //                malTakip.StartPosition = FormStartPosition.WindowsDefaultLocation;
        //                malTakip.Show();
        //            }
        //        }

        //        else
        //            XtraMessageBox.Show("Hacizli mal bulunamadý.");
        //    }
        //}

        private void gridView6_DoubleClick(object sender, EventArgs e)
        {
            int foyID = (int)((sender as GridView).GetFocusedRow() as R_BIRLESIK_TAKIPLER_TUMU_GEMI_UCAK_ARAC).ID;
            int modulID = (int)((sender as GridView).GetFocusedRow() as R_BIRLESIK_TAKIPLER_TUMU_GEMI_UCAK_ARAC).MODUL;
            if (foyID > 0)
            {
                switch (modulID)
                {
                    case 1:
                        _frmIcraTakip frmIcra = new _frmIcraTakip();
                        frmIcra.Show(foyID);
                        break;
                    case 2:
                        frmDavaTakip frmDava = new frmDavaTakip();
                        frmDava.Show(foyID);
                        break;
                    case 3:
                        rFrmSorusturmaTakip frmSorusturma = new rFrmSorusturmaTakip();
                        frmSorusturma.Show(foyID);
                        break;
                    case 5:
                        frmSozlesmeTakip frmSozlesme = new frmSozlesmeTakip();
                        frmSozlesme.Show(foyID);
                        break;
                    default:
                        break;
                }
            }
        }

    }
}