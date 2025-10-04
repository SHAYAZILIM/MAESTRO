using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AdimAdimDavaKaydi.DavaTakip;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AdimAdimDavaKaydi.Sozlesme.Forms;
using AdimAdimDavaKaydi.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTab;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucHaciz : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        private TList<TI_KOD_MAL_CINS> cloneMalCins;

        private TList<TI_KOD_MAL_TUR> cloneMalTur;

        private GridHitInfo hitInfo;

        private TList<TI_KOD_MAL_CINS> MalCins = new TList<TI_KOD_MAL_CINS>();

        private TList<TI_KOD_MAL_TUR> MalTur = new TList<TI_KOD_MAL_TUR>();

        private ExtendedGridControl mySatisGrid;

        private GridView mySatisGridView;

        private XtraTabControl myTabControl;

        private XtraTabPage myTabPage;

        public ucHaciz()
        {
            InitializeComponent();
            gvHaciz.MasterRowExpanding += gvHaciz_MasterRowExpanding;
            gcHaciz.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
        }

        public List<AvukatProLib.Arama.per_TI_BIL_HACIZ_MASTER_MINI> MyDataSource
        {
            get { return (List<AvukatProLib.Arama.per_TI_BIL_HACIZ_MASTER_MINI>)gcHaciz.DataSource; }
            set
            {
                if (value != null)
                {
                    if (gcHaciz != null)
                    {
                        gcHaciz.DataSource = value;

                        //if (value.Count > 0)
                        //  IcraKayitGetir(value);
                        //extendedGridControl1.DataSource = value;
                    }
                }
                gcHaciz.DataSource = value;

                //extendedGridControl1.DataSource = value;
            }
        }

        [Browsable(true)]
        [Description("Sürükleme iþleminin yapilacagi satis Grid'i")]
        public ExtendedGridControl MySatisGrid
        {
            get { return mySatisGrid; }
            set
            {
                if (mySatisGrid != null)
                {
                    mySatisGrid = value;

                    mySatisGrid.DragEnter += mySatisGrid_DragEnter;
                    mySatisGrid.DragDrop += mySatisGrid_DragDrop;
                }
            }
        }

        public GridView MySatisGridView
        {
            get { return mySatisGridView; }
            set { mySatisGridView = value; }
        }

        /// <summary>
        /// Base TabControl
        /// </summary>
        [Browsable(true)]
        [Description("Sürükle-Býrak iþleminin gerçekleþeceði tabControl")]
        public XtraTabControl MyTabControl
        {
            get { return myTabControl; }
            set
            {
                if (myTabControl != null)
                {
                    myTabControl = value;
                    myTabControl.DragEnter += myTabControl_DragEnter;
                }
            }
        }

        /// <summary>
        /// Satis gridini taþýyan tabControl
        /// </summary>
        [Browsable(true)]
        [Description("Sürükleme iþleminin yapýlacaðý tabPage")]
        public XtraTabPage MyTabPage
        {
            get { return myTabPage; }
            set { myTabPage = value; }
        }

        private void barBtnSecimiKaldir_ItemClick(object sender, ItemClickEventArgs e)
        {
            R_BIRLESIK_TAKIPLER_HACIZ_MASTER tum = e.Item.Tag as R_BIRLESIK_TAKIPLER_HACIZ_MASTER;
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
                frm.ShowDialog(foyList);
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

        private void gcHaciz_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gcHaciz.Visible)
            {
                extendedGridControl1.Visible = true;
                gcHaciz.Visible = false;

                //extendedGridControl2.Visible = false;
            }
            else
            {
                extendedGridControl1.Visible = false;
                gcHaciz.Visible = true;

                //extendedGridControl2.Visible = false;
            }
        }

        private void gcHaciz_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;
            if (e.Button.Tag.ToString() == "FormAc")
            {
                Forms.Icra.frmHacizGirisi hacizEkle = new AdimAdimDavaKaydi.Forms.Icra.frmHacizGirisi();

                //hacizEkle.MdiParent = null;
                hacizEkle.StartPosition = FormStartPosition.WindowsDefaultLocation;
                hacizEkle.IsModul = true;
                hacizEkle.Show();
            }
        }

        private void gcHaciz_DoubleClick(object sender, EventArgs e)
        {
            if (gvHaciz.GetFocusedRow() != null)
            {
                int? icraFoyId = (gvHaciz.GetFocusedRow() as AvukatProLib.Arama.per_TI_BIL_HACIZ_MASTER_MINI).ICRA_FOY_ID;
                if (icraFoyId.HasValue)
                {
                    AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama takip = gvHaciz.GetFocusedRow() as AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama;
                    AV001_TI_BIL_FOY icra = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.GetByID(icraFoyId.Value);
                    TList<AV001_TI_BIL_FOY> seciliKayitler = new TList<AV001_TI_BIL_FOY>();
                    seciliKayitler.Add(icra);
                    _frmIcraTakip frmicraTakip = new _frmIcraTakip();
                    frmicraTakip.Show(seciliKayitler);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Seçilen ilam için kayýtlý bir föy bulunumadý.", "Föy Bulunamadý");
                }
            }
        }

        private void gcHaciz_MouseDown(object sender, MouseEventArgs e)
        {
            hitInfo = gvHaciz.CalcHitInfo(new Point(e.X, e.Y));
        }

        private void gcHaciz_MouseMove(object sender, MouseEventArgs e)
        {
            List<AvukatProLib.Arama.per_TI_BIL_HACIZ_MASTER_MINI> tasinacak = new List<AvukatProLib.Arama.per_TI_BIL_HACIZ_MASTER_MINI>();

            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && hitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(hitInfo.HitPoint.X - dragSize.Width / 2,
                                                             hitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    try
                    {
                        if (gvHaciz.GetRow(gvHaciz.FocusedRowHandle) is AvukatProLib.Arama.per_TI_BIL_HACIZ_MASTER_MINI)
                        {
                            tasinacak.Add((AvukatProLib.Arama.per_TI_BIL_HACIZ_MASTER_MINI)gvHaciz.GetRow(gvHaciz.FocusedRowHandle));
                        }
                        else
                        {
                            tasinacak = ((List<AvukatProLib.Arama.per_TI_BIL_HACIZ_MASTER_MINI>)gvHaciz.GetRow(gvHaciz.FocusedRowHandle));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (tasinacak != null)
                        gcHaciz.DoDragDrop(tasinacak, DragDropEffects.Copy);
                    hitInfo = null;
                }
            }
        }

        private void gvHaciz_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            AV001_TI_BIL_HACIZ_MASTER gelen = (AV001_TI_BIL_HACIZ_MASTER)gvHaciz.GetRow(e.RowHandle);
            if (gelen.R_BIRLESIK_TAKIPLER_HACIZ_MASTERCollection != null) return;

            gelen.R_BIRLESIK_TAKIPLER_HACIZ_MASTERCollection =
                DataRepository.R_BIRLESIK_TAKIPLER_HACIZ_MASTERProvider.Get(
                    string.Format("HACIZ_MASTER_ID={0}", gelen.ID), "KAYIT_TARIHI ASC");
        }

        /// <summary>
        /// Gelen parametreye gore kodtablolarýndan datalari doldur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvHacizChild_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            LookUpEdit edit;
            AV001_TI_BIL_HACIZ_CHILD hc = view.GetFocusedRow() as AV001_TI_BIL_HACIZ_CHILD;

            int i = view.GetDataSourceRowIndex(view.FocusedRowHandle);

            if (view.FocusedColumn.FieldName == "HACIZLI_MAL_TUR_ID" && view.ActiveEditor is LookUpEdit)
            {
                edit = (LookUpEdit)view.ActiveEditor;

                MalTur = edit.Properties.DataSource as TList<TI_KOD_MAL_TUR>;

                cloneMalTur = new AvukatProLib2.Entities.TList<TI_KOD_MAL_TUR>(MalTur);

                if (MalTur != null && hc != null)
                    cloneMalTur.Filter = "KATEGORI_ID = " + hc.HACIZLI_MAL_KATEGORI_ID;

                edit.Properties.DataSource = cloneMalTur;
            }

            if (view.FocusedColumn.FieldName == "HACIZLI_MAL_CINS_ID" && view.ActiveEditor is LookUpEdit)
            {
                try
                {
                    edit = (LookUpEdit)view.ActiveEditor;

                    MalCins = edit.Properties.DataSource as TList<AvukatProLib2.Entities.TI_KOD_MAL_CINS>;

                    cloneMalCins = new TList<TI_KOD_MAL_CINS>(MalCins);

                    if (MalCins != null && hc != null)
                        cloneMalCins.Filter = "TUR_ID=" + hc.HACIZLI_MAL_TUR_ID;

                    edit.Properties.DataSource = cloneMalCins;
                }

#warning Burada Patlama var Kontrol edilecek.
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException, "Beklenmeyen bir hata oluþtu",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mySatisGrid_DragDrop(object sender, DragEventArgs e)
        {
            TList<AV001_TI_BIL_HACIZ_MASTER> gelenObj =
                (TList<AV001_TI_BIL_HACIZ_MASTER>)e.Data.GetData(typeof(TList<AV001_TI_BIL_HACIZ_MASTER>));

            AV001_TI_BIL_SATIS_MASTER yeniSatis = new AV001_TI_BIL_SATIS_MASTER();

            yeniSatis.SATISIN_ISTENME_SEKLI_ID = 1;

            yeniSatis.SATISI_ISTEYEN_CARI_ID = gelenObj[0].HACIZ_ISTEYEN_CARI_ID;
            yeniSatis.SATISI_ISTENEN_CARI_ID = gelenObj[0].HACIZ_ISTENEN_CARI_ID;
            yeniSatis.SATIS_ISTEME_TARIHI = DateTime.Now.Date;
            yeniSatis.SEHIR_ICI_DISI = true;
            yeniSatis.VAKTINDE_MI = true;
            yeniSatis.SATIS_TARIHI_2 = DateTime.Now.Date.AddDays(3);
            yeniSatis.SATIS_SORUMLU_PERSONEL_ID = gelenObj[0].HACIZ_SORUMLU_PERSONEL_ID;
            yeniSatis.SATIS_SAATI_1 = DateTime.Now.ToShortTimeString();
            yeniSatis.SATIS_SAATI_2 = DateTime.Now.ToShortTimeString();
            yeniSatis.SATIS_MEMURU_ID = gelenObj[0].HACIZ_MEMURU_CARI_ID;

            //yeniSatis.HACIZ_ID = gelenObj[0].ID;

            yeniSatis.STAMP = 1;
            yeniSatis.SUBE_KODU = null;

            AV001_TI_BIL_SATIS_CHILD yeniSatisChild = new AV001_TI_BIL_SATIS_CHILD();

            yeniSatisChild.HACIZLI_MAL_KAT_ID =
                gelenObj[0].AV001_TI_BIL_HACIZ_CHILDCollection[0].HACIZLI_MAL_KATEGORI_ID;

            yeniSatisChild.HACIZLI_MAL_TUR_ID = gelenObj[0].AV001_TI_BIL_HACIZ_CHILDCollection[0].HACIZLI_MAL_TUR_ID;

            //TODO: lan kimyaptý bunu allah belanýzý
            yeniSatisChild.HACIZLI_MAL_CINS_ID = gelenObj[0].AV001_TI_BIL_HACIZ_CHILDCollection[0].HACIZLI_MAL_CINS_ID;

            //yeniSatisChild.HACIZLI_MAL_ADEDI = Convert.ToInt32(gelenObj[0].AV001_TI_BIL_HACIZ_CHILDCollection[0].HACIZLI_MAL_AD

            //yeniSatisChild.HACIZLI_MAL_DEGERI =Convert.ToDouble(gelenObj[0].AV001_TI_BIL_HACIZ_CHILDCollection[0].HACIZLI_MAL_DEGERI);

            //yeniSatisChild.HACIZLI_MAL_TOPLAM_MIKTAR=gelenObj[0].AV001_TI_BIL_HACIZ_CHILDCollection[0].HACIZLI_MAL_

            if (mySatisGrid.DataSource == null)
            {
                mySatisGrid.DataSource = new TList<AV001_TI_BIL_SATIS_MASTER>();
            }

            ((TList<AV001_TI_BIL_SATIS_MASTER>)mySatisGridView.DataSource).Add(yeniSatis);
            ((TList<AV001_TI_BIL_SATIS_MASTER>)mySatisGridView.DataSource)[0].AV001_TI_BIL_SATIS_CHILDCollection.Add(
                yeniSatisChild);
        }

        private void mySatisGrid_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void myTabControl_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            myTabControl.SelectedTabPage = myTabPage;
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "Dosya_No" || e.Column.FieldName == "Adliye"
                || e.Column.FieldName == "No" || e.Column.FieldName == "Esas_No" || e.Column.FieldName == "Takip_T" ||
                e.Column.FieldName == "Gorev" || e.Column.FieldName == "Referans1")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kaydý");
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Takip Ekranýna Gönder");

                R_BIRLESIK_TAKIPLER_HACIZ_MASTER secim = e.Rows as R_BIRLESIK_TAKIPLER_HACIZ_MASTER;

                bus.ItemLinks.Add(barBtnSecimiKaldir);
                if (secim != null)
                {
                    barBtnSecimiKaldir.Tag = secim;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(0, bus);
            }
        }

        private void ucHaciz_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                gcHaciz.ButtonCevirClick += gcHaciz_ButtonCevirClick;
                extendedGridControl1.ButtonCevirClick += gcHaciz_ButtonCevirClick;
                /*
                BelgeUtil.Inits.HAcizKaynakGetir(rLueHacizKaynagi);
                BelgeUtil.Inits.perCariGetir(rLueCariId);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizId);
                BelgeUtil.Inits.MalKategoriGetir(rLueMalKatId);
                BelgeUtil.Inits.MalTurGetir(rLueMalTurId);
                BelgeUtil.Inits.MalcinsGetir(rLueMalCinsId);
                BelgeUtil.Inits.HacizIslemDurumGetir(rLueHacizIslemDurumId);
                BelgeUtil.Inits.GemiUcakAraclariGetir(rLueAracBilgiId);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeId);
                BelgeUtil.Inits.ParaBicimiAyarla(rudTutar);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNoId);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
                BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKod);
                BelgeUtil.Inits.FoyDurumGetir(rLueFoyDurum);
                BelgeUtil.Inits.TarafKoduGetir(rLueTarafKodu);
                BelgeUtil.Inits.TarafSifatGetir(rLueTarafSifat);
                BelgeUtil.Inits.BankaGetir(rLueBanka);
                BelgeUtil.Inits.BankaSubeGetir(rLueBSube);
                BelgeUtil.Inits.FoyBirimGetir(rLueFoyBirim);
                BelgeUtil.Inits.FoyYeriGetir(rLueFoyYeri);
                BelgeUtil.Inits.FoyOzelDurumGetir(rLueFoyOzelDurum);
                BelgeUtil.Inits.TahsilatdurumGetir(rLueTahsilatDurum);
                BelgeUtil.Inits.KrediGrubu(rLueKrediGrup);
                BelgeUtil.Inits.KrediTipiGetir(rLueKrediTip);
                BelgeUtil.Inits.ModulGetir(rLueModul);
                */

                //Inits.TarihAlaniAyarla(repositoryItemDateEdit1);

                gcHaciz.MouseDown += gcHaciz_MouseDown;
                gcHaciz.MouseMove += gcHaciz_MouseMove;
            }
        }
    }
}