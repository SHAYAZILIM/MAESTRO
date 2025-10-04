using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class ucBorcluMallarGiris : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBorcluMallarGiris()
        {
            InitializeComponent();
            ecGridBorcluOdemeMallar.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "Dosya_No" || e.Column.FieldName == "Adliye"
                || e.Column.FieldName == "No" || e.Column.FieldName == "Esas_No" || e.Column.FieldName == "Takip_T" ||
                e.Column.FieldName == "Gorev" || e.Column.FieldName == "Referans1")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kaydý");
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Takip Ekranýna Gönder");

                R_BIRLESIK_TAKIPLER_BORCLU_MAL secim = e.Rows as R_BIRLESIK_TAKIPLER_BORCLU_MAL;

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
            R_BIRLESIK_TAKIPLER_BORCLU_MAL tum = e.Item.Tag as R_BIRLESIK_TAKIPLER_BORCLU_MAL;
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
                // frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foyList);
            }
            if (tum.Dosya_No.Contains("H") || tum.MODUL == (int)AvukatProLib.Extras.Modul.Sorusturma)
            {
                TList<AV001_TD_BIL_HAZIRLIK> foyList = new TList<AV001_TD_BIL_HAZIRLIK>();
                foyList.Add(DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(tum.KAYIT_ID.Value));
                rFrmSorusturmaTakip frm = new rFrmSorusturmaTakip();
                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foyList);
            }
        }

        public List<AvukatProLib.Arama.per_TDI_BIL_BORCLU_MAL> MyDataSource
        {
            get
            {
                if (ecGridBorcluOdemeMallar.DataSource is List<AvukatProLib.Arama.per_TDI_BIL_BORCLU_MAL>)
                    return (List<AvukatProLib.Arama.per_TDI_BIL_BORCLU_MAL>)ecGridBorcluOdemeMallar.DataSource;
                return null;
            }
            set
            {
                if (value != null)
                {
                    if (ecGridBorcluOdemeMallar != null)
                    {
                        ecGridBorcluOdemeMallar.DataSource = value;
                        if (value.Count > 0)
                            IcraKayitGetir(value);
                    }
                }
                ecGridBorcluOdemeMallar.DataSource = value;
            }
        }

        private void IcraKayitGetir(List<AvukatProLib.Arama.per_TDI_BIL_BORCLU_MAL> value)
        {
            AV001_TI_BIL_FOY foy;
            foreach (var item in value)
            {
                if (item.ICRA_FOY_ID != null)
                {
                    foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(item.ICRA_FOY_ID.Value);
                    //item.ICRA_FOY_IDSource = foy; //gerek yok
                }
            }
        }

        //private TList<AV001_TI_BIL_FOY> _myFoy;
        //public TList<AV001_TI_BIL_FOY> MyFoy
        //{
        //    get
        //    {
        //        return null;
        //    }

        //    set
        //    {
        //    }
        //}

        public void FilitreleriTemizle()
        {
            gridView1.ActiveFilter.Clear();
        }

        private void ucBorcluMallarGiris_Load(object sender, EventArgs e)
        {
            //LAOD
            if (this.DesignMode)
                return;
            /*
            //AdimAdimDavaKaydi.Util.Inits.MalKategoriGetir(rLueMalKategori);
            BelgeUtil.Inits.MalTurGetir(rLueMAlTur);
            BelgeUtil.Inits.MalcinsGetir(rLueMalCins);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.BirimKodGetir(rLueMalAdetBirim);
            BelgeUtil.Inits.perCariGetir(rLueCariGetir);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            BelgeUtil.Inits.MalKategoriResimliGetir(rLueMalKategoriResimli);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueBirimNo);
            //Inits.TarihAlaniAyarla(repositoryItemDateEdit1);
            //
            //AdimAdimDavaKaydi.Util.Inits.MalKategoriGetir(repositoryItemLookUpEdit1);
            BelgeUtil.Inits.MalTurGetir(repositoryItemLookUpEdit2);
            BelgeUtil.Inits.MalcinsGetir(repositoryItemLookUpEdit3);
            BelgeUtil.Inits.DovizTipGetir(repositoryItemLookUpEdit4);
            BelgeUtil.Inits.BirimKodGetir(repositoryItemLookUpEdit5);
            BelgeUtil.Inits.perCariGetir(repositoryItemLookUpEdit6);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(repositoryItemLookUpEdit7);
            BelgeUtil.Inits.AdliBirimGorevGetir(repositoryItemLookUpEdit8);
            BelgeUtil.Inits.AdliBirimNoGetir(repositoryItemLookUpEdit9);
            BelgeUtil.Inits.MalKategoriResimliGetir(rLueMalKategoriResimli);
            BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKod);
            BelgeUtil.Inits.FoyDurumGetir(rLueFoyDurum);
            BelgeUtil.Inits.TarafKoduGetir(rLueTarafK);
            BelgeUtil.Inits.TarafSifatGetir(rLueTarafSifat);
            BelgeUtil.Inits.BankaGetir(rLueBanka);
            BelgeUtil.Inits.BankaSubeGetir(rLueBSube);
            BelgeUtil.Inits.FoyBirimGetir(rLueFoyBirim);
            BelgeUtil.Inits.FoyYeriGetir(rLueFoyYeri);
            BelgeUtil.Inits.FoyOzelDurumGetir(rLueFoyOzelDurum);
            BelgeUtil.Inits.TahsilatdurumGetir(rLueTahsilatDurum);
            BelgeUtil.Inits.KrediGrubu(rLueKrediGrup);
            BelgeUtil.Inits.KrediTipiGetir(rLueKrediTip);
            BelgeUtil.Inits.ModulGetir(rLueModul); */
            ecGridBorcluOdemeMallar.ButtonCevirClick += ecGridBorcluOdemeMallar_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += ecGridBorcluOdemeMallar_ButtonCevirClick;

            //AV001_TI_BIL_KIYMET_TAKDIRICollection
        }

        private void ecGridBorcluOdemeMallar_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (ecGridBorcluOdemeMallar.Visible)
            {
                ecGridBorcluOdemeMallar.Visible = false;
                extendedGridControl1.Visible = true;
            }
            else
            {
                ecGridBorcluOdemeMallar.Visible = true;
                extendedGridControl1.Visible = false;
            }
        }

        private void gridView1_MasterRowExpanding(object sender,
                                                  DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs e)
        {
            AvukatProLib.Arama.per_TDI_BIL_BORCLU_MAL gelen = (AvukatProLib.Arama.per_TDI_BIL_BORCLU_MAL)gridView1.GetRow(e.RowHandle);

            gelen.R_BIRLESIK_TAKIPLER_BORCLU_MAL_MINICollection = BelgeUtil.Inits.context.R_BIRLESIK_TAKIPLER_BORCLU_MAL_MINIs.Where(vi => vi.ID == gelen.ID).OrderBy(vi => vi.KAYIT_TARIHI).ToList();
        }

        private void ecGridBorcluOdemeMallar_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;
            else if (e.Button.Tag.ToString() == "FormAc")
            {
                Forms.Icra.frmBorcluMalKaydetVGrid MalKaydet =
                    new AdimAdimDavaKaydi.Forms.Icra.frmBorcluMalKaydetVGrid();
                //MalKaydet.MdiParent = null;
                MalKaydet.StartPosition = FormStartPosition.WindowsDefaultLocation;
                MalKaydet.MyDataSource = new TList<TDI_BIL_BORCLU_MAL>();
                MalKaydet.Show();
            }

            else if (e.Button.Tag.ToString() == "MalTakipSureci")
            {
                frmMalTakipSureci malTakip = new frmMalTakipSureci();

                if (gridView1.GetFocusedRow() != null)
                {
                    AvukatProLib.Arama.per_TDI_BIL_BORCLU_MAL Row = (AvukatProLib.Arama.per_TDI_BIL_BORCLU_MAL)gridView1.GetFocusedRow();
                    if (Row != null && Row.HACIZ_CHILD_ID != null)
                    {
                        AV001_TI_BIL_HACIZ_CHILD result =
                            DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.GetByID(Row.HACIZ_CHILD_ID.Value);
                        var liste = new TList<AV001_TI_BIL_HACIZ_CHILD>();
                        liste.Add(result);
                        malTakip.MyDataSource = liste;
                        //malTakip.MyFoy = MyFoy;
                        //malTakip.KiymetTakdiriMasterSelectedRow = Row;
                        //.MdiParent = null;
                        malTakip.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        malTakip.Show();
                    }

                    else
                        XtraMessageBox.Show("Hacizli mal bulunamadý.");
                }
            }
        }
    }
}