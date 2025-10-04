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
    public partial class ucIhtiyatiHacizBilgiGiris : DevExpress.XtraEditors.XtraUserControl
    {
        public ucIhtiyatiHacizBilgiGiris()
        {
            InitializeComponent();
            gridView1.MasterRowExpanding += gridView1_MasterRowExpanding;
            exGridIhtiyatiHaciz.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "Dosya_No" || e.Column.FieldName == "Adliye"
                || e.Column.FieldName == "No" || e.Column.FieldName == "Esas_No" || e.Column.FieldName == "Takip_T" ||
                e.Column.FieldName == "Gorev" || e.Column.FieldName == "Referans1")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kaydý");
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Takip Ekranýna Gönder");

                R_BIRLESIK_IHTIYATI_HACIZ secim = e.Rows as R_BIRLESIK_IHTIYATI_HACIZ;

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
            R_BIRLESIK_IHTIYATI_HACIZ tum = e.Item.Tag as R_BIRLESIK_IHTIYATI_HACIZ;
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
                // frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foyList);
            }
            if (tum.Dosya_No.Contains("S") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Sozlesme)
            {
                TList<AV001_TDI_BIL_SOZLESME> foyList = new TList<AV001_TDI_BIL_SOZLESME>();
                foyList.Add(DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(tum.KAYIT_ID.Value));
                frmSozlesmeTakip frm = new frmSozlesmeTakip();
                // frm.MdiParent = null;
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

        private void gridView1_MasterRowExpanding(object sender,
                                                  DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs e)
        {
            AV001_TI_BIL_IHTIYATI_HACIZ gelen = (AV001_TI_BIL_IHTIYATI_HACIZ)gridView1.GetRow(e.RowHandle);
            if (gelen.R_BIRLESIK_IHTIYATI_HACIZCollection != null) return;

            gelen.R_BIRLESIK_IHTIYATI_HACIZCollection =
                DataRepository.R_BIRLESIK_IHTIYATI_HACIZProvider.Get(string.Format("ID={0}", gelen.ID),
                                                                     "KAYIT_TARIHI ASC");
        }

        public TList<AV001_TI_BIL_IHTIYATI_HACIZ> MyDataSource
        {
            get
            {
                if (exGridIhtiyatiHaciz.DataSource is TList<AV001_TI_BIL_IHTIYATI_HACIZ>)
                    return (TList<AV001_TI_BIL_IHTIYATI_HACIZ>)exGridIhtiyatiHaciz.DataSource;
                return null;
            }
            set
            {
                if (value == null)
                {
                    if (exGridIhtiyatiHaciz != null)
                    {
                        exGridIhtiyatiHaciz.DataSource = value;
                        extendedGridControl1.DataSource = value;
                    }
                }

                exGridIhtiyatiHaciz.DataSource = value;
                extendedGridControl1.DataSource = value;
            }
        }

        private void ucIhtiyatiHacizBilgiGiris_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            BelgeUtil.Inits.TeminatTuruGetir(rLueTeminatTuru);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.perCariGetir(rLueCariID);
            BelgeUtil.Inits.TarafSifatGetir(rLueTarafSifat);
            BelgeUtil.Inits.ItirazSonucuGetir(rLueItirazSonuc);
            //Inits.TarihAlaniAyarla(repositoryItemDateEdit1);
            BelgeUtil.Inits.BankaGetir(rLueBanka);
            BelgeUtil.Inits.BankaSubeGetir(rLueBSube);
            BelgeUtil.Inits.FoyBirimGetir(rLueFoyBirim);
            BelgeUtil.Inits.FoyYeriGetir(rLueFoyYeri);
            BelgeUtil.Inits.FoyOzelDurumGetir(rLueFoyODurum);
            BelgeUtil.Inits.TahsilatdurumGetir(rLueTahsilatDurum);
            BelgeUtil.Inits.KrediGrubu(rLueKrediGrup);
            BelgeUtil.Inits.KrediTipiGetir(rLueKrediTip);
            BelgeUtil.Inits.ModulGetir(rLueModul);
            BelgeUtil.Inits.TarafKoduGetir(rLueTarafKodu);
            BelgeUtil.Inits.FoyDurumGetir(rLueFoyDurum);
            BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKod);
            //
            BelgeUtil.Inits.AdliBirimAdliyeGetir(repositoryItemLookUpEdit1);
            BelgeUtil.Inits.AdliBirimGorevGetir(repositoryItemLookUpEdit2);
            BelgeUtil.Inits.AdliBirimNoGetir(repositoryItemLookUpEdit3);
            BelgeUtil.Inits.TeminatTuruGetir(repositoryItemLookUpEdit4);
            BelgeUtil.Inits.DovizTipGetir(repositoryItemLookUpEdit5);
            BelgeUtil.Inits.perCariGetir(repositoryItemLookUpEdit6);

            exGridIhtiyatiHaciz.ButtonCevirClick += exGridIhtiyatiHaciz_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += exGridIhtiyatiHaciz_ButtonCevirClick;
        }

        private void exGridIhtiyatiHaciz_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (exGridIhtiyatiHaciz.Visible)
            {
                exGridIhtiyatiHaciz.Visible = false;
                extendedGridControl1.Visible = true;
            }
            else
            {
                exGridIhtiyatiHaciz.Visible = true;
                extendedGridControl1.Visible = false;
            }
        }

        private void exGridIhtiyatiHaciz_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                frmIcraIhtiyatiHaciz IhtiyatiHacizKayit = new frmIcraIhtiyatiHaciz();
                //IhtiyatiHacizKayit.MdiParent = null;
                IhtiyatiHacizKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                IhtiyatiHacizKayit.IsModul = true;
                IhtiyatiHacizKayit.Show();
            }
        }
    }
}