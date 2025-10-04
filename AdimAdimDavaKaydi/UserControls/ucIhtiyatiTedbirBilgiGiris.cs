using System;
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
    public partial class ucIhtiyatiTedbirBilgiGiris : DevExpress.XtraEditors.XtraUserControl
    {
        public ucIhtiyatiTedbirBilgiGiris()
        {
            InitializeComponent();
            exGridIhtiyatiTedbir.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "Dosya_No" || e.Column.FieldName == "Adliye"
                || e.Column.FieldName == "No" || e.Column.FieldName == "Esas_No" || e.Column.FieldName == "Takip_T" ||
                e.Column.FieldName == "Gorev" || e.Column.FieldName == "Referans1")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kaydý");
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Takip Ekranýna Gönder");

                R_BIRLESIK_TAKIPLER_IHTIYATI_TEDBIR secim = e.Rows as R_BIRLESIK_TAKIPLER_IHTIYATI_TEDBIR;

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
            R_BIRLESIK_TAKIPLER_IHTIYATI_TEDBIR tum = e.Item.Tag as R_BIRLESIK_TAKIPLER_IHTIYATI_TEDBIR;
            if (tum.Dosya_No.Contains("I") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Icra)
            {
                TList<AV001_TI_BIL_FOY> foyList = new TList<AV001_TI_BIL_FOY>();
                foyList.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(tum.KAYIT_ID.Value));
                _frmIcraTakip IcraTk = new _frmIcraTakip();
                //IcraTk.MdiParent = null;
                IcraTk.StartPosition = FormStartPosition.WindowsDefaultLocation;
                IcraTk.Show(foyList);
            }
            if (tum.Dosya_No.Contains("D") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Dava)
            {
                TList<AV001_TD_BIL_FOY> foyList = new TList<AV001_TD_BIL_FOY>();
                foyList.Add(DataRepository.AV001_TD_BIL_FOYProvider.GetByID(tum.KAYIT_ID.Value));
                frmDavaTakip frm = new frmDavaTakip();
                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foyList);
            }
            if (tum.Dosya_No.Contains("S") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Sozlesme)
            {
                TList<AV001_TDI_BIL_SOZLESME> foyList = new TList<AV001_TDI_BIL_SOZLESME>();
                foyList.Add(DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(tum.KAYIT_ID.Value));
                frmSozlesmeTakip frm = new frmSozlesmeTakip();
                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foyList);
            }
            if (tum.Dosya_No.Contains("H") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Sorusturma)
            {
                TList<AV001_TD_BIL_HAZIRLIK> foyList = new TList<AV001_TD_BIL_HAZIRLIK>();
                foyList.Add(DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(tum.KAYIT_ID.Value));
                rFrmSorusturmaTakip frm = new rFrmSorusturmaTakip();
                // frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foyList);
            }
        }

        public TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> MyDataSource
        {
            get
            {
                if (exGridIhtiyatiTedbir.DataSource is TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>)
                    return (TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>)exGridIhtiyatiTedbir.DataSource;
                return null;
            }
            set
            {
                if (value == null)
                {
                    if (exGridIhtiyatiTedbir != null)
                    {
                        exGridIhtiyatiTedbir.DataSource = value;
                    }
                }
                exGridIhtiyatiTedbir.DataSource = value;
            }
        }

        private void ucIhtiyatiTedbirBilgiGiris_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            BelgeUtil.Inits.TeminatTuruGetir(rLueTeminatTuru);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.perCariGetir(rLueCariID);
            BelgeUtil.Inits.TarafSifatGetir(rLeuTarafSifat);
            BelgeUtil.Inits.ItirazSonucuGetir(rLueItirazSonuc);
            //Inits.TarihAlaniAyarla(repositoryItemDateEdit1);
            //
            BelgeUtil.Inits.AdliBirimAdliyeGetir(repositoryItemLookUpEdit1);
            BelgeUtil.Inits.AdliBirimGorevGetir(repositoryItemLookUpEdit2);
            BelgeUtil.Inits.AdliBirimNoGetir(repositoryItemLookUpEdit3);
            BelgeUtil.Inits.TeminatTuruGetir(repositoryItemLookUpEdit4);
            BelgeUtil.Inits.DovizTipGetir(repositoryItemLookUpEdit5);
            BelgeUtil.Inits.perCariGetir(repositoryItemLookUpEdit6);
            BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKod);
            BelgeUtil.Inits.FoyDurumGetir(rLueFoyDurum);
            BelgeUtil.Inits.TarafKoduGetir(rLueTarafKodu);
            BelgeUtil.Inits.BankaGetir(rLueBanka);
            BelgeUtil.Inits.BankaSubeGetir(rLueBSube);
            BelgeUtil.Inits.FoyBirimGetir(rLueFoyBirim);
            BelgeUtil.Inits.FoyYeriGetir(rLueFoyYeri);
            BelgeUtil.Inits.FoyOzelDurumGetir(rLueFoyOzelDurum);
            BelgeUtil.Inits.TahsilatdurumGetir(rLueTahsilatDurum);
            BelgeUtil.Inits.KrediGrubu(rLueKrediGrup);
            BelgeUtil.Inits.KrediTipiGetir(rLueKrediTip);
            BelgeUtil.Inits.ModulGetir(rLueModul);

            exGridIhtiyatiTedbir.ButtonCevirClick += exGridIhtiyatiTedbir_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += exGridIhtiyatiTedbir_ButtonCevirClick;
        }

        private void exGridIhtiyatiTedbir_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (exGridIhtiyatiTedbir.Visible)
            {
                exGridIhtiyatiTedbir.Visible = false;
                extendedGridControl1.Visible = true;
            }
            else
            {
                exGridIhtiyatiTedbir.Visible = true;
                extendedGridControl1.Visible = false;
            }
        }

        private void gridView1_MasterRowExpanding(object sender,
                                                  DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs e)
        {
            AV001_TDI_BIL_IHTIYATI_TEDBIR gelen = (AV001_TDI_BIL_IHTIYATI_TEDBIR)gridView1.GetRow(e.RowHandle);
            if (gelen.R_BIRLESIK_TAKIPLER_IHTIYATI_TEDBIRCollection != null) return;

            gelen.R_BIRLESIK_TAKIPLER_IHTIYATI_TEDBIRCollection =
                DataRepository.R_BIRLESIK_TAKIPLER_IHTIYATI_TEDBIRProvider.Get(string.Format("ID={0}", gelen.ID),
                                                                               "KAYIT_TARIHI ASC");
        }

        private void exGridIhtiyatiTedbir_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;
            if (e.Button.Tag.ToString() == "FormAc")
            {
                frmDavaIcraIhtiyatiTedbir IhtiyadiTedbirKayit = new frmDavaIcraIhtiyatiTedbir();

                IhtiyadiTedbirKayit.MyDataSource = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();
                //IhtiyadiTedbirKayit.MdiParent = null;
                IhtiyadiTedbirKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                IhtiyadiTedbirKayit.IsModul = true;
                IhtiyadiTedbirKayit.Show();
            }
        }
    }
}