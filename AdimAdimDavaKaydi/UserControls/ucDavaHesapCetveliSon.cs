using System;
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

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucDavaHesapCetveliSon : AvpXUserControl
    {
        public ucDavaHesapCetveliSon()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucHesapCetveli_Load;
        }

        // Klasor Hesabi olmayacak; sonradan cikaracagim .....
        private bool _KlasorHesabi;

        [Browsable(false)]
        public bool KlasorHesabi
        {
            get { return !_KlasorHesabi; }
            set { _KlasorHesabi = !value; }
        }

        public bool SadeceDosyaTabi { get; set; }

        public bool SadeceTarafTabi { get; set; }

        [Browsable(true)]
        public bool BarGorunsun { get; set; }

        private LayoutViewStyle _Gorunum = LayoutViewStyle.SingleRecordView;

        [Browsable(true)]
        public LayoutViewStyle Gorunum
        {
            get { return _Gorunum; }
            set { _Gorunum = value; }
        }

        //private HesapAraclari.OzetHesap _MyOzetHesap;

        //[Browsable(false)]
        //public HesapAraclari.OzetHesap MyOzetHesap
        //{
        //    get { return _MyOzetHesap; }
        //    set
        //    {
        //        _MyOzetHesap = value;
        //        if (value != null && IsLoaded)
        //        {
        //            BindData();
        //        }
        //    }
        //}

        public bool DavaDosyaKayitEkrani;

        private AV001_TD_BIL_FOY _MyFoyDataSource;

        public AV001_TD_BIL_FOY MyFoyDataSource
        {
            get { return _MyFoyDataSource; }
            set
            {
                _MyFoyDataSource = value;
                if (value != null)
                    MyTarafSource = value.AV001_TD_BIL_FOY_TARAFCollection;

                if (IsLoaded)
                    BindData();
            }
        }

        public TList<AV001_TD_BIL_FOY_TARAF> MyTarafSource
        {
            get
            {
                if (_MyTarafSource != null)
                    _MyTarafSource.Filter = "TAKIP_EDEN_MI = false";
                return _MyTarafSource;
            }
            set { _MyTarafSource = value; }
        }

        public enum TabSayfalari
        {
            OzetHesap,
            DosyaHesabi
        }

        //private ucOzetHesap.BaslikGruplari _OzetHesapBaslikGrubu = ucOzetHesap.BaslikGruplari.Dosya;

        //[Browsable(false)]
        //public ucOzetHesap.BaslikGruplari OzetHesapBaslikGrubu
        //{
        //    get { return _OzetHesapBaslikGrubu; }
        //    set { _OzetHesapBaslikGrubu = value; }
        //}

        [Browsable(false)]
        public TabSayfalari SecilenSayfa
        {
            get { return _SecilenSayfa; }
            set { _SecilenSayfa = value; }
        }

        private TabSayfalari _SecilenSayfa = TabSayfalari.DosyaHesabi;

        private void FormuOzellestir()
        {
            //ucOzetHesap1.SetBaslikGrubu = OzetHesapBaslikGrubu;

            switch (SecilenSayfa)
            {
                case TabSayfalari.OzetHesap:
                    xtraTabControl2.SelectedTabPage = xtraTabPage1; // ÖZET HESAP
                    //xtraTabPage6.Text = "Gayrinakitli Toplam";
                    xtraTabPage6.PageVisible = false;
                    break;
                case TabSayfalari.DosyaHesabi:
                    xtraTabControl2.SelectedTabPage = xtraTabPage6; //DOSYA HESABI
                    xtraTabPage6.PageVisible = true;
                    xtraTabPage6.Text = "Dosya Bazında";
                    break;
            }
        }

        private BackgroundWorker bckWorker = new BackgroundWorker();

        public void BindData()
        {
            //if (MyOzetHesap != null)
            //{
            //    ucOzetHesap1.MyProje = MyOzetHesap.MyProje;
            //    ucOzetHesap1.MyDataSource = MyOzetHesap.MyFoy;
            //    TList<AV001_TD_BIL_FOY> foyListesi = new TList<AV001_TD_BIL_FOY>();
            //    if (MyOzetHesap.MyFoy != null)
            //        foyListesi.Add(MyOzetHesap.MyFoy);
            //    return;
            //}

            if (MyFoyDataSource != null)
            {
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

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyFoyDataSource == null)
            {
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoyDataSource
                                                                 , false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TD_BIL_FOY_TARAF>)
                                                                 , typeof(TList<AV001_TD_BIL_FAIZ>),
                                                                 typeof(TList<AV001_TD_BIL_TAZMINAT>)
                                                                 , typeof(TList<AV001_TD_BIL_VEKALET_UCRET>),
                                                                 typeof(TList<AV001_TD_BIL_ODEME_DAGILIM>)
                                                                 , typeof(TList<AV001_TD_BIL_HARC>));
                foreach (var item in MyFoyDataSource.AV001_TD_BIL_FOY_TARAFCollection)
                {
                    DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TDIE_KOD_TARAF_SIFAT),
                                                                           typeof(AV001_TDI_BIL_CARI));
                }
            }
            if (_MyTarafSource == null)
            {
                _MyTarafSource = MyFoyDataSource.AV001_TD_BIL_FOY_TARAFCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyFoyDataSource != null)
            {
                TList<AV001_TD_BIL_FOY> foys = new TList<AV001_TD_BIL_FOY>();
                foys.Add(MyFoyDataSource);
                bndIcraFoy.DataSource = MyFoyDataSource;
                //bndHesapCetveli.DataSource =
                //    new AvukatProLib.Hesap.HesapAraclari.DavaHesapCetveli(foys.First()).HesapAlanList.Where(
                //        vi => vi.Value.Para != 0);
                //ucHesapDetaylari1.MyFoy = MyFoyDataSource;
                //if (!KlasorHesabi)
                //    ucOzetHesap1.MyDataSource = MyFoyDataSource;
            }
            if (MyTarafSource != null)
            {
                MyTarafSource.Filter = "DAVA_EDEN_MI = false";
                foreach (var item in MyTarafSource)
                    if (item.TARAF_SIFAT_IDSource == null)
                        DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren,
                                                                               typeof(TDIE_KOD_TARAF_SIFAT),
                                                                               typeof(AV001_TDI_BIL_CARI));
            }
            if (MyTarafSource != null)
            {
                dataNavigatorExtended1.Visible = BarGorunsun;
                ucOzetHesap1.HesabiGuncelle = KlasorHesabi;
            }
        }

        private TList<AV001_TD_BIL_FOY_TARAF> _MyTarafSource;

        private void ucHesapCetveli_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
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

            #region <MB-20100201> İcra Dosya Kayıt ekranındayken editöre yollama

            if (DavaDosyaKayitEkrani)
            {
                lcItemEditoreGonder.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                xtraTabControl2.SelectedTabPage = xtraTabPage6; //Dosya Bazında Tabı.
            }

            #endregion

            if (SecilenSayfa != TabSayfalari.OzetHesap)
            {
                AvukatProLib.Hesap.Hesap.Hesaplansinmi = true;
                ButtonClick();
            }
            //else
            //    ucOzetHesap1.Hesapla();
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

        private void DosyaTabiniKontrolEt()
        {
            for (int i = 0; i < xtraTabControl2.TabPages.Count; i++)
            {
                if (xtraTabControl2.TabPages[i] != xtraTabPage6)
                {
                    xtraTabControl2.TabPages[i].PageVisible = false;
                }
            }
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
                    "Excel Dosya Türü|*.xls|Word Dosya Türü|*.doc|PDF (E-Book) Dosya Türü|*.pdf|HTML Web Sayfası|*.html";
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

        public AV001_TDIE_BIL_PROJE MyProje { get; set; }
        
        private void ButtonClick()
        {
            var foy = this.bndIcraFoy.Current as AV001_TD_BIL_FOY;

            DavaTakip.frmDavaTakip.SonHesapTarihiKontrolu(foy);
            BackgroundWorker bw = new BackgroundWorker();
            btnHesapla.Enabled = false;
            bw.DoWork += delegate(object s1, DoWorkEventArgs e1)
            {
                picWait.Image = global::AdimAdimDavaKaydi.Properties.Resources._27;
                if (e1.Argument is AV001_TD_BIL_FOY)
                {
                    var davaFoy = e1.Argument as AV001_TD_BIL_FOY;
                    //Hesap.Dava hesap = new Hesap.Dava(davaFoy);
                    //e1.Result = hesap;
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
                MessageBox.Show("Hesap Tamamlandı");
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
        
        #region <MB-20100201>
        
        //Ağacın Tamamının açılması ve kapanması işlemi
        
        #endregion

    }
}