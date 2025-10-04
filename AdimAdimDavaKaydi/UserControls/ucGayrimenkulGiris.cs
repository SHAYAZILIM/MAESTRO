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
using BelgeUtil;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucGayrimenkulGiris : DevExpress.XtraEditors.XtraUserControl
    {
        public ucGayrimenkulGiris()
        {
            InitializeComponent();
            exGridGayrimenkul.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "Dosya_No" || e.Column.FieldName == "Adliye"
                || e.Column.FieldName == "No" || e.Column.FieldName == "Esas_No" || e.Column.FieldName == "Takip_T" ||
                e.Column.FieldName == "Gorev" || e.Column.FieldName == "Referans1")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kaydý");
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Takip Ekranýna Gönder");

                R_BIRLESIK_TAKIPLER_TUMU_GAYRIMENKUL secim = e.Rows as R_BIRLESIK_TAKIPLER_TUMU_GAYRIMENKUL;

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
            R_BIRLESIK_TAKIPLER_TUMU_GAYRIMENKUL tum = e.Item.Tag as R_BIRLESIK_TAKIPLER_TUMU_GAYRIMENKUL;

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
                //.MdiParent = null;
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

        private void gridView1_MasterRowExpanding(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs e)
        {
            AV001_TI_BIL_GAYRIMENKUL gelen = (AV001_TI_BIL_GAYRIMENKUL)gridView1.GetRow(e.RowHandle);
            if (gelen.R_BIRLESIK_TAKIPLER_TUMU_GAYRIMENKULCollection != null) return;
            gelen.R_BIRLESIK_TAKIPLER_TUMU_GAYRIMENKULCollection =
                DataRepository.R_BIRLESIK_TAKIPLER_TUMU_GAYRIMENKULProvider.Get(
                    string.Format("GAYRIMENKUL_ID={0}", gelen.ID), "KAYIT_TARIHI ASC");
        }

        public TList<AV001_TI_BIL_GAYRIMENKUL> MyDataSource
        {
            get
            {
                if (exGridGayrimenkul.DataSource is TList<AV001_TI_BIL_GAYRIMENKUL>)
                    return (TList<AV001_TI_BIL_GAYRIMENKUL>)exGridGayrimenkul.DataSource;
                return null;
            }
            set
            {
                if (value == null)
                {
                    exGridGayrimenkul.DataSource = value;
                    dnGayriMenkul.DataSource = value;
                    vGGayrimenkul.DataSource = value;
                }

                if (value != null && !this.DesignMode)
                {
                    exGridGayrimenkul.DataSource = value;
                    dnGayriMenkul.DataSource = value;
                    vGGayrimenkul.DataSource = dnGayriMenkul.DataSource;
                    value.AddingNew += value_AddingNew;
                }
            }
        }

        private void value_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_GAYRIMENKUL addNew = new AV001_TI_BIL_GAYRIMENKUL();
            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            addNew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addNew.KONTROL_NE_ZAMAN = DateTime.Now;
            e.NewObject = addNew;
        }

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesme { get; set; }

        private void ucGayrimenkulGiris_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            BelgeUtil.Inits.IlGetir(rLueIlID);
            BelgeUtil.Inits.perCariGetir(rLueCariID);
            BelgeUtil.Inits.TarafSifatGetir(rLueTarafSifat);
            BelgeUtil.Inits.MalKategoriGetir(rLueMalKategori);
            BelgeUtil.Inits.MalTurGetir(rLueMalTur);
            BelgeUtil.Inits.MalcinsGetir(rLueMalCins);
            BelgeUtil.Inits.BirimKodGetir(rLueMalBirimID);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.UlkeGetir(rLueUlke);
            //BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKod);

            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            BelgeUtil.Inits.FoyDurumGetir(rLueDosyaDurum);
            BelgeUtil.Inits.perCariGetir(rLueTartafCari);
            BelgeUtil.Inits.BankaGetir(rLueBankaGetir);
            BelgeUtil.Inits.BankaSubeGetir(rLueBankaSube);
            BelgeUtil.Inits.FoyBirimGetir(rLueFoyBirim);
            BelgeUtil.Inits.FoyYeriGetir(rLueDosyaYeri);
            BelgeUtil.Inits.FoyOzelDurumGetir(rLueDosyaOzelDurum);
            BelgeUtil.Inits.TahsilatdurumGetir(rLueTahsilatDurum);
            BelgeUtil.Inits.KrediGrubu(rLueKrediGrup);
            BelgeUtil.Inits.KrediTipiGetir(rLueKrediTip);
            BelgeUtil.Inits.ModulGetir(rLueDosyaModul);

            BelgeUtil.Inits.IlGetir(rlueIl);
            BelgeUtil.Inits.IlceGetirTumu(rlueIlce);
            BelgeUtil.Inits.IlceGetirTumu(rLueIlceID);
            beMalTakipSureci.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(beMalTakipSureci_ButtonClick);

            exGridGayrimenkul.ButtonCevirClick += exGridGayrimenkul_ButtonCevirClick;
        }

        private void exGridGayrimenkul_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (exGridGayrimenkul.Visible)
            {
                exGridGayrimenkul.Visible = false;
                panelControl1.Visible = true;
                panelControl1.BringToFront();
            }
        }

        private void dnGayriMenkul_OnCevirClick(object sender, EventArgs e)
        {
            if (panelControl1.Visible)
            {
                exGridGayrimenkul.Visible = true;
                panelControl1.Visible = false;
                exGridGayrimenkul.BringToFront();
            }
        }

        private void gayri_GayrimenkulKaydedildi(object sender, GayrimenkulKaydedildiEventArgs e)
        {
            if (MySozlesme != null)
            {
                if (e.GayriFoy != null)
                {
                    foreach (var item in e.GayriFoy)
                    {
                        if (
                            MySozlesme.NN_SOZLESME_GAYRIMENKULCollection.FindAll(
                                NN_SOZLESME_GAYRIMENKULColumn.GAYRIMENKUL_ID, item.ID).Count == 0)
                        {
                            NN_SOZLESME_GAYRIMENKUL sGayri = new NN_SOZLESME_GAYRIMENKUL();
                            sGayri.SOZLESME_ID = MySozlesme.ID;
                            sGayri.GAYRIMENKUL_ID = item.ID;
                            DataRepository.NN_SOZLESME_GAYRIMENKULProvider.DeepSave(sGayri);
                        }
                    }
                }
            }
        }

        private void exGridGayrimenkul_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;

            else if (e.Button.Tag.ToString() == "MalTakipSureci")
            {
                frmMalTakipSureci malTakip;

                if (gridView1.GetFocusedRow() != null)
                {
                    AV001_TI_BIL_GAYRIMENKUL Row = (AV001_TI_BIL_GAYRIMENKUL)gridView1.GetFocusedRow();
                    DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(Row, false, DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TI_BIL_HACIZ_CHILD>));
                    if (Row != null && Row.AV001_TI_BIL_HACIZ_CHILDCollection != null &&
                        Row.AV001_TI_BIL_HACIZ_CHILDCollection.Count > 0)
                    {
                        malTakip = new frmMalTakipSureci();
                        malTakip.MyDataSource = Row.AV001_TI_BIL_HACIZ_CHILDCollection;
                        //.MdiParent = null;
                        malTakip.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        malTakip.Show();
                    }

                    else
                        XtraMessageBox.Show("Hacizli mal bulunamadý.");
                }
            }
            if (e.Button.Tag == "FormdanEkle")
            {
                frmGayrimenkulKayit gayri = new frmGayrimenkulKayit();
                //.MdiParent = null;
                gayri.StartPosition = FormStartPosition.WindowsDefaultLocation;
                gayri.GayrimenkulKaydedildi += gayri_GayrimenkulKaydedildi;
                TList<AV001_TI_BIL_GAYRIMENKUL> listE = new TList<AV001_TI_BIL_GAYRIMENKUL>();
                listE.Add(new AV001_TI_BIL_GAYRIMENKUL() { KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu });
                gayri.MyDataSource = listE;
                gayri.Show();
            }
            if (e.Button.Tag == "KaydiDuzenle")
            {
                frmGayrimenkulKayit gayri = new frmGayrimenkulKayit();
                //gayri.MdiParent = null;
                gayri.StartPosition = FormStartPosition.WindowsDefaultLocation;
                gayri.GayrimenkulKaydedildi += gayri_GayrimenkulKaydedildi;
                TList<AV001_TI_BIL_GAYRIMENKUL> gayrimen = new TList<AV001_TI_BIL_GAYRIMENKUL>();
                gayrimen.Add(MyDataSource[gridView1.FocusedRowHandle]); DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(gayrimen, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>));

                gayri.gayriList = gayrimen;
                gayri.MyDataSource = gayrimen;
                gayri.Show();
            }
        }

        private void gridView8_DoubleClick(object sender, EventArgs e)
        {
            int foyID = (int)((sender as GridView).GetFocusedRow() as R_BIRLESIK_TAKIPLER_TUMU_GAYRIMENKUL).ID;
            int modulID = (int)((sender as GridView).GetFocusedRow() as R_BIRLESIK_TAKIPLER_TUMU_GAYRIMENKUL).MODUL;
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

        void beMalTakipSureci_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit be = (sender as ButtonEdit);
            if (string.IsNullOrEmpty(be.Text))
                return;
            int gayrimenkulID = (gridView1.GetFocusedRow() as AV001_TI_BIL_GAYRIMENKUL).ID;
            int foyID = Convert.ToInt32(be.Text);

            AV001_TI_BIL_FOY foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(foyID);
            if (foy == null)
                return;
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_HACIZ_MASTER>), typeof(TList<AV001_TI_BIL_HACIZ_CHILD>));

            foreach (var master in foy.AV001_TI_BIL_HACIZ_MASTERCollection)
            {
                foreach (var child in master.AV001_TI_BIL_HACIZ_CHILDCollection)
                {
                    if (child.GAYRIMENKUL_BILGI_ID == gayrimenkulID)
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
    }
}