using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using AvukatProLib;
using AdimAdimDavaKaydi.Editor.Forms;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucIcraHesapCetveli : AvpXUserControl
    {
        private LayoutViewStyle _Gorunum = LayoutViewStyle.SingleRecordView;
        private bool _KlasorHesabi;
        private AV001_TI_BIL_FOY _MyFoyDataSource;
        private HesapAraclari.OzetHesap _MyOzetHesap;
        private TList<AV001_TI_BIL_FOY_TARAF> _MyTarafSource;
        private ucOzetHesap.BaslikGruplari _OzetHesapBaslikGrubu = ucOzetHesap.BaslikGruplari.Dosya;
        private TabSayfalari _SecilenSayfa = TabSayfalari.DosyaHesabi;
        private BackgroundWorker bckWorker = new BackgroundWorker();

        public ucIcraHesapCetveli()
        {
            if (DesignMode)
                InitializeComponent();
            this.Load += ucHesapCetveli_Load;
        }

        public enum TabSayfalari
        {
            OzetHesap,
            DosyaHesabi
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool BarGorunsun { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LayoutViewStyle Gorunum
        {
            get { return _Gorunum; }
            set { _Gorunum = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool KlasorHesabi
        {
            get { return !_KlasorHesabi; }
            set { _KlasorHesabi = !value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoyDataSource
        {
            get { return _MyFoyDataSource; }
            set
            {
                _MyFoyDataSource = value;
                if (value != null)
                    MyTarafSource = value.AV001_TI_BIL_FOY_TARAFCollection;

                if (IsLoaded)
                    BindData();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HesapAraclari.OzetHesap MyOzetHesap
        {
            get { return _MyOzetHesap; }
            set
            {
                _MyOzetHesap = value;
                if (value != null && IsLoaded)
                {
                    BindData();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDIE_BIL_PROJE MyProje { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_FOY_TARAF> MyTarafSource
        {
            get
            {
                if (_MyTarafSource != null)
                    _MyTarafSource.Filter = "TAKIP_EDEN_MI = false";
                return _MyTarafSource;
            }
            set { _MyTarafSource = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ucOzetHesap.BaslikGruplari OzetHesapBaslikGrubu
        {
            get { return _OzetHesapBaslikGrubu; }
            set { _OzetHesapBaslikGrubu = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SadeceDosyaTabi { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SadeceTarafTabi { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TabSayfalari SecilenSayfa
        {
            get { return _SecilenSayfa; }
            set { _SecilenSayfa = value; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index">0 Excel - 1 Word -2 Pdf -3 html</param>
        public static void ExportIt(int index, DevExpress.XtraVerticalGrid.VGridControl mGrid)
        {
            try
            {
                DevExpress.XtraVerticalGrid.VGridControl vg = mGrid;
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter =
                    "Excel Dosya Türü|*.xls|Word Dosya Türü|*.doc|PDF (E-Book) Dosya Türü|*.pdf|HTML Web Sayfasý|*.html";
                sv.FilterIndex = index;
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    if (sv.FileName.EndsWith("xls"))
                    {
                        vg.ExportToXls(sv.FileName);
                    }
                    else if (sv.FileName.EndsWith("doc"))
                    {
                        vg.ExportToRtf(sv.FileName);
                    }
                    else if (sv.FileName.EndsWith("pdf"))
                    {
                        vg.ExportToPdf(sv.FileName);
                    }
                    else if (sv.FileName.EndsWith("html"))
                    {
                        vg.ExportToHtml(sv.FileName);
                    }
                    System.Diagnostics.Process.Start(sv.FileName);
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(typeof(ucIcraHesapCetveli), ex);
            }
        }

        public void BindData()
        {
            if (MyOzetHesap != null)
            {
                ucOzetHesap1.MyProje = MyOzetHesap.MyProje;
                ucOzetHesap1.MyDataSource = MyOzetHesap.MyFoy;
                TList<AV001_TI_BIL_FOY> foyListesi = new TList<AV001_TI_BIL_FOY>();
                if (MyOzetHesap.MyFoy != null)
                    foyListesi.Add(MyOzetHesap.MyFoy);
                return;
            }

            if (MyFoyDataSource != null)
            {
                if (this.bndIcraFoy == null)
                    this.bndIcraFoy = new BindingSource();
                this.bndIcraFoy.DataSource = MyFoyDataSource;
            }
            else
            {
                this.treeHesap.ClearNodes();
                this.treeHesap.Refresh();
                this.ucOzetHesap1.MyDataSource = null;
                this.ucHesapDetaylari1.MyFoy = null;
                return;
            }

            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        public void GridiDuzenle(VGridRows rows)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i] is MultiEditorRow)
                {
                    MultiEditorRow row = rows[i] as MultiEditorRow;
                    row.SeparatorKind = SeparatorKind.VertLine;
                    if (row.PropertiesCollection.Count == 2)
                    {
                        row.PropertiesCollection[0].Width = 100;
                        row.PropertiesCollection[1].Width = 15;
                    }
                    if (row.ChildRows.Count > 0)
                    {
                        GridiDuzenle(row.ChildRows);
                    }
                }
                else if (rows[i] is CategoryRow)
                {
                    GridiDuzenle((rows[i] as CategoryRow).ChildRows);
                }
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyFoyDataSource == null)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoyDataSource, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>), typeof(TList<AV001_TI_BIL_FAIZ>), typeof(TList<AV001_TI_BIL_TAZMINAT>), typeof(TList<AV001_TI_BIL_VEKALET_UCRET>), typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>), typeof(TList<AV001_TI_BIL_HARC>));
                foreach (var item in MyFoyDataSource.AV001_TI_BIL_FOY_TARAFCollection)
                {
                    DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TDIE_KOD_TARAF_SIFAT), typeof(AV001_TDI_BIL_CARI));
                }
            }
            if (_MyTarafSource == null)
            {
                _MyTarafSource = MyFoyDataSource.AV001_TI_BIL_FOY_TARAFCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyFoyDataSource != null)
            {
                TList<AV001_TI_BIL_FOY> foys = new TList<AV001_TI_BIL_FOY>();
                foys.Add(MyFoyDataSource);
                bndIcraFoy.DataSource = MyFoyDataSource;

                AvukatProLib.Hesap.HesapAraclari.IcraHesapCetveli.Foy = bndIcraFoy.Current as AV001_TI_BIL_FOY;

                bndHesapCetveli.DataSource =
                    new AvukatProLib.Hesap.HesapAraclari.IcraHesapCetveli(foys.First()).HesapAlanList.Where(
                        vi => vi.Value.Para != 0);
                ucHesapDetaylari1.MyFoy = MyFoyDataSource;
                if (!KlasorHesabi)
                    ucOzetHesap1.MyDataSource = MyFoyDataSource;
            }
            if (MyTarafSource != null)
            {
                MyTarafSource.Filter = "TAKIP_EDEN_MI = false";
                foreach (var item in MyTarafSource)
                    if (item.TARAF_SIFAT_IDSource == null)
                        DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TDIE_KOD_TARAF_SIFAT), typeof(AV001_TDI_BIL_CARI));
            }
            if (MyTarafSource != null)
            {
                dataNavigatorExtended1.Visible = BarGorunsun;
                ucOzetHesap1.HesabiGuncelle = KlasorHesabi;
            }
        }

        private void btnDosyaKapakHesabi_Click(object sender, EventArgs e)
        {
            //1-2-3-8-9-10-11-12-14
            //3223
            //else 3224

            AvukatProLib.Arama.AvpDataContext db = BelgeUtil.Inits.context;

            if (MyFoyDataSource.FORM_TIP_ID == 1 || MyFoyDataSource.FORM_TIP_ID == 2 || MyFoyDataSource.FORM_TIP_ID == 3 || MyFoyDataSource.FORM_TIP_ID == 8 || MyFoyDataSource.FORM_TIP_ID == 9 || MyFoyDataSource.FORM_TIP_ID == 10 || MyFoyDataSource.FORM_TIP_ID == 11 || MyFoyDataSource.FORM_TIP_ID == 12 || MyFoyDataSource.FORM_TIP_ID == 14)
            {
                AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor frm = new Forms.Ajanda_Sablon_Belge.frmEditor();
                List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> raporlar = db.VDIE_BIL_SABLON_RAPORs.Where(r => r.ID == 3224).ToList();
                frm.OpenAllSablonForThread(raporlar, MyFoyDataSource, "");
            }
            else
            {
                AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor frm = new Forms.Ajanda_Sablon_Belge.frmEditor();
                List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> raporlar = db.VDIE_BIL_SABLON_RAPORs.Where(r => r.ID == 3223).ToList();
                frm.OpenAllSablonForThread(raporlar, MyFoyDataSource, "");
            }
        }

        private void btnMasrafAvans_Click(object sender, EventArgs e)
        {
            IcraTakipForms.frmMasrafAvansKayitHizli frm = new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
            frm.AcilisYeri = AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.TakipEkrani;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoyDataSource);
        }

        private void btnTakipSetiCikart_Click(object sender, EventArgs e)
        {
            var ayarlar = BelgeUtil.Inits.context.AV001_TI_BIL_YAZDIRMA_AYARLARIs.Where(vi => vi.KULLANICI_ID == Kimlikci.Kimlik.Cari_ID && vi.FORM_ID == MyFoyDataSource.FORM_TIP_ID);
            if (ayarlar.Count() > 0)
            {
                List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> SecilenRaporlar = new List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>();

                var ayar = ayarlar.First();

                foreach (var aDetay in ayar.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAYs)
                {
                    var sablon = BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.Where(vi => vi.ID == aDetay.SABLON_ID).FirstOrDefault();
                    if (sablon != null) SecilenRaporlar.Add(sablon);
                }

                AdimAdimDavaKaydi.Generalclass.Forms.frmIstek istek = new AdimAdimDavaKaydi.Generalclass.Forms.frmIstek();
                
                istek.Foyler.Add(MyFoyDataSource);

                string resultstring = istek.LoadFromList(SecilenRaporlar);
                string BarkodTip = resultstring.Split('-')[0].ToString();// barkod tipini kullanýcaz 
                DialogResult dialogResult = resultstring.Split('-')[1].ToString() == "OK" ? DialogResult.OK : DialogResult.Cancel;
                if (dialogResult == DialogResult.Cancel)
                    return;

                if (istek.PostaListesiVarmi)
                {
                    List<object> liste = new List<object>();
                    liste.Add(MyFoyDataSource);
                    frmPostaListesiYazdir frm = new frmPostaListesiYazdir(liste);
                    frm.Show();
                }
                
                if (istek.list is List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>)
                {
                    List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> dlstRaporlar = ((List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>)istek.list);
                    AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor SelectedEditor = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();

                    SelectedEditor = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();
                    SelectedEditor.MdiParent = AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm;

                    //SelectedEditor.OpenAllSablon(dlstRaporlar, MyFoyDataSource, "");
                    SelectedEditor.OpenAllSablonForThread(dlstRaporlar, MyFoyDataSource, BarkodTip);
                }
            }
            else
            {
                MessageBox.Show("Bu takip formu için takip seti tanýmý yapýlmamýþtýr.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ButtonClick()
        {
            var foy = this.bndIcraFoy.Current as AV001_TI_BIL_FOY;
            if (foy == null && this.MyOzetHesap != null)
                foy = this.MyOzetHesap.MyFoy;

            

            IcraTakipForms._frmIcraTakip.SonHesapTarihiKontrolu(foy);
            BackgroundWorker bw = new BackgroundWorker();
            btnHesapla.Enabled = false;
            bw.DoWork += delegate(object s1, DoWorkEventArgs e1)
            {
                picWait.Image = global::AdimAdimDavaKaydi.Properties.Resources._27;
                if (e1.Argument is AV001_TI_BIL_FOY)
                {
                    var icraFoy = e1.Argument as AV001_TI_BIL_FOY;
                    Hesap.Icra hesap = new Hesap.Icra(icraFoy);
                    e1.Result = hesap;
                }
                else if (e1.Argument is AV001_TDIE_BIL_PROJE)
                {
                    var proje = e1.Argument as AV001_TDIE_BIL_PROJE;

                    KlasorHesapAraclari kHesap = new KlasorHesapAraclari();
                    var ozet = kHesap.GetKonsolideAlacaklarHesabi2G(proje);
                    e1.Result = kHesap.HesapAraci;
                }
            };
            bw.RunWorkerCompleted += delegate(object s1, RunWorkerCompletedEventArgs e1)
            {
                if (e1.Result != null)
                {
                    var hesap = e1.Result as Hesap.Icra;
                    this.bndHesapCetveli.DataSource =
                        new HesapAraclari.IcraHesapCetveli(hesap.Foy).HesapAlanList.Where(
                            vi => vi.Value.Para != 0);
                    this.ucHesapDetaylari1.MyFoy = hesap.Foy;
                    this.bndIcraFoy.DataSource = hesap.Foy;
                }
                picWait.Image = null;
                btnHesapla.Enabled = true;
                MessageBox.Show("Hesap Tamamlandý");
            };

            if (MyProje != null)
            {
                bw.RunWorkerAsync(MyProje);
            }
            else if (foy != null)
            {
                bw.RunWorkerAsync(foy);
            }
        }

        private void DosyaTabiniKontrolEt()
        {
            for (int i = 0; i < xtraTabControl2.TabPages.Count; i++)
            {
                if (xtraTabControl2.TabPages[i] != tabDosyaHesabi)
                {
                    xtraTabControl2.TabPages[i].PageVisible = false;
                }
            }
        }

        private void FormuOzellestir()
        {
            ucOzetHesap1.SetBaslikGrubu = OzetHesapBaslikGrubu;

            switch (SecilenSayfa)
            {
                case TabSayfalari.OzetHesap:
                    xtraTabControl2.SelectedTabPage = tabHesapOzeti; // ÖZET HESAP
                    //xtraTabPage6.Text = "Gayrinakitli Toplam";
                    tabDosyaHesabi.PageVisible = false;
                    break;
                case TabSayfalari.DosyaHesabi:
                    xtraTabControl2.SelectedTabPage = tabDosyaHesabi; //DOSYA HESABI
                    tabDosyaHesabi.PageVisible = true;
                    tabDosyaHesabi.Text = "Dosya Hesabý";
                    break;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            AvukatProLib.Hesap.Hesap.Hesaplansinmi = true;//icrahesap

            AvukatProLib.Hesap.Hesap.Avanslar.AvansListesi.Clear();
            _MyFoyDataSource.AV001_TDI_BIL_MASRAF_AVANSCollection = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByICRA_FOY_ID(_MyFoyDataSource.ID);
            int aa = -1;
            foreach (AV001_TDI_BIL_MASRAF_AVANS item in _MyFoyDataSource.AV001_TDI_BIL_MASRAF_AVANSCollection)
            {
                aa++;         
                if (item.REFERANS_NO.Contains("Ö"))
                {
                    _MyFoyDataSource.AV001_TDI_BIL_MASRAF_AVANSCollection[aa].AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByMASRAF_AVANS_ID(item.ID);
                    AvukatProLib.Hesap.Hesap.Avanslar.AvansListesi.Add(_MyFoyDataSource.AV001_TDI_BIL_MASRAF_AVANSCollection[aa]);
                }
            }
            ButtonClick();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog opd = new SaveFileDialog();
            opd.Filter = "Zengin Metin Belgesi (*.rtf)|*.rtf";

            if (opd.ShowDialog() == DialogResult.OK)
            {
                treeHesap.ExportToRtf(opd.FileName);
                System.Diagnostics.Process.Start(opd.FileName);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            SaveFileDialog opd = new SaveFileDialog();
            opd.Filter = "Excel Belgesi (*.xls)|*.xls";

            if (opd.ShowDialog() == DialogResult.OK)
            {
                treeHesap.ExportToXls(opd.FileName);
                System.Diagnostics.Process.Start(opd.FileName);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            SaveFileDialog opd = new SaveFileDialog();
            opd.Filter = "PDF Belgesi (*.pdf)|*.pdf";

            if (opd.ShowDialog() == DialogResult.OK)
            {
                treeHesap.ExportToPdf(opd.FileName);

                System.Diagnostics.Process.Start(opd.FileName);
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            treeHesap.ExpandAll();
            ExtendedGridControl.YazdirmaOnizleme(treeHesap);
        }

        private void ucHesapCetveli_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            if (!IsLoaded)
                InitializeComponent();
            //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, this);
            IsLoaded = true;

            //gkn Ekledi
            if (SadeceDosyaTabi)
                DosyaTabiniKontrolEt();

            FormuOzellestir();

            BelgeUtil.Inits.DovizTipGetir(rlkDoviz);
            BelgeUtil.Inits.HesapTipiGetir(lueHesapTipiTO);
            BelgeUtil.Inits.HesapTipiGetir(lueHesapTipiTS);
            BelgeUtil.Inits.BirYilKacGGetir(lueBirYilKacGun);
            BindData();

            #region <MB-20100201> Ýcra Dosya Kayýt ekranýndayken editöre yollama

            if (IcraDosyaKayitEkrani)
            {
                SecilenSayfa = TabSayfalari.DosyaHesabi;
                tabDosyaHesabi.PageVisible = true;
                lciEditoreGonder.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciTakipSetiOlustur.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                xtraTabControl2.SelectedTabPage = tabDosyaHesabi; //Dosya Bazýnda Tabý.
            }

            #endregion <MB-20100201> Ýcra Dosya Kayýt ekranýndayken editöre yollama

            if (SecilenSayfa != TabSayfalari.OzetHesap)
            {
                tabHesapOzeti.PageVisible = false;
                btnHesapla.Enabled = true;
                //AvukatProLib.Hesap.Hesap.Hesaplansinmi = true;
                //ButtonClick();
            }
            else
                ucOzetHesap1.Hesapla();
        }

        private void xtraTabControl2_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page.Name == tabHesapOzeti.Name)
            {
                ucOzetHesap1.Visible = false;
                ucOzetHesap1.Hide();
                ucOzetHesap1.ucOzetHesapCetveli1_Load(sender, EventArgs.Empty);
                ucOzetHesap1.Show();
                ucOzetHesap1.Visible = true;
            }
        }

        #region <MB-20100201>

        //Ýcra Dosya Kayýt ekranýndan Editöre gönder butonu görünümü için eklendi.

        public bool IcraDosyaKayitEkrani;

        #endregion <MB-20100201>

        #region <MB-20100201>

        //Aðacýn Tamamýnýn açýlmasý ve kapanmasý iþlemi
        private bool TreeNodeOpened;

        private void sbtnAgaciAcKapat_Click(object sender, EventArgs e)
        {
            if (TreeNodeOpened)
            {
                treeHesap.CollapseAll();
                sbtnAgaciAcKapat.Text = "Aðacý Aç";
            }
            else
            {
                treeHesap.ExpandAll();
                sbtnAgaciAcKapat.Text = "Aðacý Kapat";
            }
        }

        //Ýcra Dosya Kayýt ekranýndayken editöre yollama
        private void sbtnEditoreGonder_Click(object sender, EventArgs e)
        {
            Editor.Forms.frmEditoreGonder editoreGonder = new AdimAdimDavaKaydi.Editor.Forms.frmEditoreGonder();
            editoreGonder.MyFoy = MyFoyDataSource;
            editoreGonder.Show();
        }

        private void treeHesap_AfterCollapse(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            TreeNodeOpened = false;
        }

        private void treeHesap_AfterExpand(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            TreeNodeOpened = true;
        }

        #endregion <MB-20100201>

        private void lueHesapTipiTO_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "duzenle")
            {
                AdimAdimDavaKaydi.Forms.Icra.frmHesapTipSira frm =
                    new AdimAdimDavaKaydi.Forms.Icra.frmHesapTipSira(((LookUpEdit)sender).EditValue as int?);
                frm.StartPosition = FormStartPosition.CenterScreen;
                //  frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                if (frm.ShowDialog() == DialogResult.OK)
                    BelgeUtil.Inits.HesapTipiGetirYenile();
            }
        }
    }
}