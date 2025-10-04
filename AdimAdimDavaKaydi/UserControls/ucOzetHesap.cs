using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib.Hesap;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucOzetHesap : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucOzetHesap()
        {
            InitializeComponent();

            #region Events

            bwHesapla.DoWork += bwHesapla_DoWork;
            bwHesapla.RunWorkerCompleted += bwHesapla_RunWorkerCompleted;

            bwTakipliAlacaklar.DoWork += bwTakipliAlacaklar_DoWork;
            bwTakipliAlacaklar.RunWorkerCompleted += bwTakipliAlacaklar_RunWorkerCompleted;

            bwTakipsizAlacaklar.DoWork += bwTakipsizAlacaklar_DoWork;
            bwTakipsizAlacaklar.RunWorkerCompleted += bwTakipsizAlacaklar_RunWorkerCompleted;

            btnHEesapla.Click += btnHEesapla_Click;
            ceMusterek.CheckedChanged += ceMusterek_CheckedChanged;

            #endregion
        }

        public void Hesapla()
        {
            HesaplaClick();
        }

        #region Events

        private void gcSorumlular_MouseMove(object sender, MouseEventArgs e)
        {
            if (gridView1.State == DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                gridView1.CloseEditor();
        }

        private void btnHEesapla_Click(object sender, EventArgs e)
        {
            //Küçük ekranlarda hesaplama sırasında kapama butonu hesapla butonunun üstünde kaldığından form tam ekran yapıldı. MB
            if (this.ParentForm is Forms.frmKlasorYeni && (this.ParentForm as Forms.frmKlasorYeni).WindowState != FormWindowState.Maximized)
                (this.ParentForm as Forms.frmKlasorYeni).WindowState = FormWindowState.Maximized;
            //ProjeBul(this);
            AvukatProLib.Hesap.Hesap.Hesaplansinmi = true;
            HesaplaClick();
        }

        private void HesaplaClick()
        {
            // Kredi borçlusunun taraf olduğu dosyalarda vekalet ücretinin klasör hesabına gelmesini sağlamak için eklendi. MB
            try
            {
                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN[0], false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
            }
            catch
            {
                MessageBox.Show("Klasörde Tanımlanmış Alacak yada Alacak Tarafı bulunmadığından hesaplama yapılamamaktadır. Lütfen Alacak kaydı yada düzenlemesi yapınız.");
                return;
            }
            var krediBorclusu = MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Find("TARAF_SIFAT_ID", 2);
            if (krediBorclusu != null)
                BelgeUtil.Inits.KrediBorclusu = krediBorclusu.TARAF_CARI_ID;

            var item = rgTercihler.Properties.Items[rgTercihler.SelectedIndex];
            int secim = -1;
            if (item != null && item.Value != null)
                secim = int.Parse(item.Value.ToString());
            if (MyDataSource != null && HesabiGuncelle)
                MyDataSource.Tag = "Hesapla"; //Bu alanı kontrol edip hesap yapıp yapmayacağımıza karar vereceğiz.

            CreateUcAlacaklar();

            switch (secim)
            {
                case 1:
                    //Takip Hesabı
                    if (ceMusterek.Checked)
                        TakipHesabi();
                    else
                        BorcluHesabi(CurrentTaraf);
                    break;
                case 2:
                    if (ceMusterek.Checked)
                        TakipliAlacaklariHesapla();
                    break;
                case 3:
                    if (ceMusterek.Checked)
                        TakipsizAlacaklariHesapla();
                    break;
                case 5:
                    if (ceMusterek.Checked)
                        GayriNakitHesabi();
                    else
                        BorcluHesabiGayriNakti(CurrentTaraf);
                    break;
                case 6:
                    if (ceMusterek.Checked)
                        CekYapragi();
                    else
                        BorcluHesabiCekYapragi(CurrentTaraf);
                    break;
                default:
                    break;
            }
        }

        private bool IsLoaded;

        public void ucOzetHesapCetveli1_Load(object sender, EventArgs e)
        {
            if (!DesignMode && !IsLoaded)
            {
                InitsDoldur();

                FormuOzelestir();
                ProjeBul(this);
                IsLoaded = true;
            }
        }

        private void InitsDoldur()
        {
            BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
            BelgeUtil.Inits.AlacakNedenKodGetir(rLueAlacakNedeni);
            BelgeUtil.Inits.FaizTipiGetir(rlueAlacakFaizTipi);
            BelgeUtil.Inits.ParaBicimiAyarla(rSpinTutar);
            BelgeUtil.Inits.YuzdeBicimiAyarla(rSpinOran);
            BelgeUtil.Inits.perCariGetir(rlueCariAdi);
            BelgeUtil.Inits.TarafSifatGetir(rlueSifati);
        }

        private void ceMusterek_CheckedChanged(object sender, EventArgs e)
        {
            if (ceMusterek.Checked)
            {
                if (gcSorumlular.DataSource != null && gcSorumlular.DataSource is TList<AV001_TI_BIL_FOY_TARAF>)
                {
                    var borclular = gcSorumlular.DataSource as TList<AV001_TI_BIL_FOY_TARAF>;
                    foreach (var borclu in borclular)
                    {
                        borclu.IsSelected = false;
                    }
                }
                if (gcSorumlular.DataSource != null &&
                    gcSorumlular.DataSource is TList<AV001_TDIE_BIL_PROJE_TARAF_HESAP>)
                {
                    var borclular = gcSorumlular.DataSource as TList<AV001_TDIE_BIL_PROJE_TARAF_HESAP>;
                    foreach (var borclu in borclular)
                    {
                        borclu.IsSelected = false;
                    }
                }
            }
        }

        #endregion

        #region Properties

        private AV001_TDIE_BIL_PROJE _MyProje;

        public AV001_TDIE_BIL_PROJE MyProje
        {
            get
            {
                ProjeBul(this);
                return _MyProje;
            }
            set { _MyProje = value; }
        }

        [Browsable(false)]
        public BaslikGruplari SetBaslikGrubu
        {
            get { return _SetBaslikGrubu; }
            set { _SetBaslikGrubu = value; }
        }

        private BaslikGruplari _SetBaslikGrubu = BaslikGruplari.Dosya;

        private AV001_TI_BIL_FOY _myDataSource;

        /// <summary>
        /// Set edildiğinde Takip Hesabı Yapılır ve kaydın borçluları ve alacak nedenleri ilgili yerlerde
        /// * Alacak nedenlerine ve borçlularına ulaşmak için Count kontrolü yapılarak deepload çekilmektedir
        /// </summary>
        [Browsable(false)]
        public AV001_TI_BIL_FOY MyDataSource
        {
            get { return _myDataSource; }
            set
            {
                _myDataSource = value;
                if (value != null)
                {
                    if (SetBaslikGrubu != BaslikGruplari.Klasor)
                        TakipHesabi();
                    else
                    {
                        ucOzetHesapCetveli1.MyDataSource = new HesapAraclari.OzetHesap(value);

                        SayfaDegistir(HesaplamaTipleri.Takip_Hesabi);
                    }

                    FormlariDoldur(value);

                    //value.ColumnChanged += value_ColumnChanged;
                }
                else
                {
                    gcAlacakNedenleri.DataSource = null;
                    ucOzetHesapCetveli1.MyDataSource = null;
                }
            }
        }

        /// <summary>
        /// Föy Hesabının Her Seferinde Yeniden Yapılmasını Sağlar
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Ayarlar")]
        public bool HesabiGuncelle { get; set; }

        #endregion

        #region Form Doldur && Şekillendir

        /// <summary>
        /// Formlar üzerindeki Doldurma işlemleri için bu method kullanılmalı
        /// </summary>
        /// <param name="foy"></param>
        private void FormlariDoldur(AV001_TI_BIL_FOY foy)
        {
            if (foy == null) return;

            AlacakNedenleriniDoldur(foy);
            BorclulariDoldur(foy);

            if (ucAlacaklar != null)
            {
                ucAlacaklar.MyFoy = foy;
            }
        }

        private void AlacakNedenleriniDoldur(AV001_TI_BIL_FOY foy)
        {
            var nedenler = foy.AV001_TI_BIL_ALACAK_NEDENCollection;

            foreach (var item in nedenler)
            {
                item.Tag = string.Format("{0}- %{1}", item.ALACAK_FAIZ_TIP_ID, item.UYGULANACAK_FAIZ_ORANI);
            }
            gcAlacakNedenleri.DataSource = nedenler;
        }

        private void BorclulariDoldur(AV001_TI_BIL_FOY foy)
        {
            if (MyProje != null)
            {
                var borclular = KlasorHesapAraclari.GetProjeTaraflari(MyProje);
                foreach (var borclu in borclular)
                {
                    borclu.PropertyChanged += borclu_PropertyChanged;
                }
                gcSorumlular.DataSource = borclular;
            }
            else
            {
                var borclular = HesapAraclari.Icra.BorclulariGetir(foy);

                //Seçim
                foreach (var borclu in borclular)
                {
                    borclu.PropertyChanged += borclu_PropertyChanged;
                }
                gcSorumlular.DataSource = borclular;
            }
        }

        private void FormuOzelestir()
        {
            switch (SetBaslikGrubu)
            {
                case BaslikGruplari.Klasor:
                    rgTercihler.Properties.Items[0].Description = "Konsolide Klasör Hesabı";
                    rgTercihler.Properties.Items[1].Description = "Takipli Alacaklar";
                    rgTercihler.Properties.Items[2].Description = "Takipsiz Alacaklar";
                    lblKlasorNot.Visible = true;
                    rgTercihler.Properties.Items[1].Enabled = true;
                    rgTercihler.Properties.Items[2].Enabled = true;
                    break;
                case BaslikGruplari.Dosya:
                    rgTercihler.Properties.Items[0].Description = "Takip Hesabı";
                    lblKlasorNot.Visible = false;
                    break;
            }
        }

        private void FoyBul(Control con)
        {
            if (con is ucIcraHesapCetveli)
            {
                var ucIcra = con as ucIcraHesapCetveli;
                _myDataSource = ucIcra.MyFoyDataSource;
            }
            else if (con != null && con.Parent != null)
            {
                FoyBul(con.Parent);
            }
        }

        private void ProjeBul(Control con)
        {
            if (con is AdimAdimDavaKaydi.Forms.frmKlasorYeni)
            {
                var frm = con as AdimAdimDavaKaydi.Forms.frmKlasorYeni;
                _MyProje = frm.MyCurrentProje;
                if (_MyProje == null)
                    _MyProje = frm.AktifProjeyiGetir(false);
            }
            else if (con.Parent != null)
            {
                ProjeBul(con.Parent);
            }
            else if (con.Parent == null)
            {
                if (_MyProje == null)
                {
                    FoyBul(this);
                }
            }
        }

        private void SayfaDegistir(HesaplamaTipleri hesapTipi)
        {
            rgTercihler.SelectedIndex = (int)hesapTipi - 1;

            switch (hesapTipi)
            {
                case HesaplamaTipleri.Takip_Hesabi:
                case HesaplamaTipleri.TakipliAlacaklar:
                case HesaplamaTipleri.TakipsizAlacaklar:
                    ucOzetHesapCetveli1.BringToFront();
                    ucAlacaklar.Visible = false;
                    break;
                case HesaplamaTipleri.TeminatAlacaklari:
                    break;
                case HesaplamaTipleri.GayriNakitHesabi:

                    if (panel1.Controls.Count > 0 &&
                        panel1.Controls[0] is UserControls.IcraTakipUserControls.ucAlacaklar)
                    {
                        ucAlacaklar.GNakitTip = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.GayrinakitTip.DigerGayrinakit;
                        ucAlacaklar.MyProje = MyProje;
                        ucAlacaklar.MyFoy = MyDataSource;
                        ucAlacaklar.tabGayriNakitAlacak.TabControl.SelectedTabPage = ucAlacaklar.tabGayriNakitAlacak;
                        ucAlacaklar.tabGayriNakitAlacak.Show();
                        ucAlacaklar.tabCekYapragi.TabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
                    }
                    else
                    {
                        ucAlacaklar.GNakitTip = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.GayrinakitTip.DigerGayrinakit;
                        ucAlacaklar.KlasorHesabindan = true;
                        ucAlacaklar.MyProje = MyProje;
                        ucAlacaklar.MyFoy = MyDataSource;
                        ucAlacaklar.Visible = true;
                        ucAlacaklar.BringToFront();
                        ucAlacaklar.tabGayriNakitAlacak.Show();
                        ucAlacaklar.tabGayriNakitAlacak.TabControl.SelectedTabPage = ucAlacaklar.tabGayriNakitAlacak;
                        ucAlacaklar.tabCekYapragi.TabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
                        ucAlacaklar.Dock = DockStyle.Fill;
                    }

                    break;
                case HesaplamaTipleri.CekYapragi:

                    if (panel1.Controls.Count > 0 &&
                        panel1.Controls[0] is UserControls.IcraTakipUserControls.ucAlacaklar)
                    {
                        ucAlacaklar.GNakitTip = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.GayrinakitTip.CekYapragi;
                        ucAlacaklar.MyProje = MyProje;
                        ucAlacaklar.MyFoy = MyDataSource;
                        ucAlacaklar.tabCekYapragi.TabControl.SelectedTabPage = ucAlacaklar.tabCekYapragi;
                        ucAlacaklar.tabCekYapragi.Show();
                        ucAlacaklar.tabCekYapragi.TabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
                    }
                    else
                    {
                        ucAlacaklar.GNakitTip = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.GayrinakitTip.CekYapragi;
                        ucAlacaklar.KlasorHesabindan = true;
                        ucAlacaklar.MyProje = MyProje;
                        ucAlacaklar.MyFoy = MyDataSource;
                        ucAlacaklar.Visible = true;
                        ucAlacaklar.BringToFront();
                        ucAlacaklar.tabCekYapragi.Show();
                        ucAlacaklar.tabCekYapragi.TabControl.SelectedTabPage = ucAlacaklar.tabCekYapragi;
                        ucAlacaklar.tabCekYapragi.TabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void CreateUcAlacaklar()
        {
            if (this.ucAlacaklar == null)
            {
                this.ucAlacaklar = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucAlacaklar();

                this.ucAlacaklar.Dock = System.Windows.Forms.DockStyle.Fill;
                this.ucAlacaklar.Location = new System.Drawing.Point(0, 0);
                this.ucAlacaklar.MyDataSource = null;
                this.ucAlacaklar.MyFoy = null;
                this.ucAlacaklar.Name = "ucAlacaklar";
                this.ucAlacaklar.Size = new System.Drawing.Size(795, 232);
                this.ucAlacaklar.TabIndex = 0;
                this.ucAlacaklar.Visible = false;
                this.ucAlacaklar.SendToBack();
            }
            this.panel1.Controls.Add(this.ucAlacaklar);
        }

        #region Borclu Hesabı

        private void borclu_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                if (sender != null && sender is AV001_TI_BIL_FOY_TARAF)
                {
                    var foyTaraf = sender as AV001_TI_BIL_FOY_TARAF;

                    //BorcluHesabi(foyTaraf);
                    if (foyTaraf.IsSelected)
                    {
                        CurrentTaraf = foyTaraf;
                        ceMusterek.Checked = false;
                        if (gcSorumlular.DataSource != null && gcSorumlular.DataSource is TList<AV001_TI_BIL_FOY_TARAF>)
                        {
                            var borclular = gcSorumlular.DataSource as TList<AV001_TI_BIL_FOY_TARAF>;
                            foreach (var borclu in borclular)
                            {
                                if (borclu != foyTaraf)
                                    borclu.IsSelected = false;
                            }
                        }
                    }
                }
                else if (sender != null && sender is AV001_TDIE_BIL_PROJE_TARAF_HESAP)
                {
                    if (gcSorumlular.DataSource != null &&
                        gcSorumlular.DataSource is TList<AV001_TDIE_BIL_PROJE_TARAF_HESAP>)
                    {
                        var projeTaraf = sender as AV001_TDIE_BIL_PROJE_TARAF_HESAP;

                        if (projeTaraf.IsSelected)
                        {
                            ceMusterek.Checked = false;
                            CurrentTaraf = projeTaraf;
                            var borclular = gcSorumlular.DataSource as TList<AV001_TDIE_BIL_PROJE_TARAF_HESAP>;
                            foreach (var borclu in borclular)
                            {
                                if (borclu != projeTaraf)
                                    borclu.IsSelected = false;
                            }
                        }
                    }
                }
            }
        }

        private IEntity CurrentTaraf;

        private void BorcluHesabi(IEntity taraf)
        {
            if (taraf is AV001_TI_BIL_FOY_TARAF)
            {
                var foyTaraf = taraf as AV001_TI_BIL_FOY_TARAF;
                if (foyTaraf == null || !foyTaraf.IsSelected)
                {
                    MessageBox.Show("Borçlu veya Müşterek Hesap Seçiniz.", "Uyarı", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }

                switch (rgTercihler.SelectedIndex)
                {
                    case 0:
                        BorcluHesabiDosya(foyTaraf);
                        break;
                    case 3:
                        BorcluHesabiGayriNakti(foyTaraf);
                        break;
                    case 4:
                        BorcluHesabiCekYapragi(foyTaraf);
                        break;
                    default:
                        break;
                }
            }
            else if (taraf is AV001_TDIE_BIL_PROJE_TARAF_HESAP)
            {
                var projeTaraf = taraf as AV001_TDIE_BIL_PROJE_TARAF_HESAP;

                switch (rgTercihler.SelectedIndex)
                {
                    case 0:
                        BorcluHesabiDosya(projeTaraf);
                        break;
                    case 3:
                        //BorcluHesabiGayriNakti(foyTaraf);
                        break;
                    case 4:
                        //BorcluHesabiCekYapragi(foyTaraf);
                        break;
                    default:
                        break;
                }
            }
        }

        private void BorcluHesabiDosya(AV001_TI_BIL_FOY_TARAF foyTaraf)
        {
            if (panel1.Controls.Count > 0 && panel1.Controls[0] != ucOzetHesapCetveli1)
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(ucOzetHesapCetveli1);
            }
            else if (panel1.Controls.Count == 0)
            {
                panel1.Controls.Add(ucOzetHesapCetveli1);
            }

            ucOzetHesapCetveli1.MyDataSource = new HesapAraclari.OzetHesap(MyDataSource, foyTaraf);
            gcAlacakNedenleri.DataSource = HesapAraclari.Icra.AlacakNedenTarafGetFoyAndTaraf(MyDataSource, foyTaraf);
        }

        private void BorcluHesabiDosya(AV001_TDIE_BIL_PROJE_TARAF_HESAP foyTaraf)
        {
            if (panel1.Controls.Count > 0 && panel1.Controls[0] != ucOzetHesapCetveli1)
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(ucOzetHesapCetveli1);
            }
            else if (panel1.Controls.Count == 0)
            {
                panel1.Controls.Add(ucOzetHesapCetveli1);
            }

            ucOzetHesapCetveli1.MyDataSource = new HesapAraclari.OzetHesap(MyDataSource, foyTaraf, MyProje);
            //gcAlacakNedenleri.DataSource = HesapAraclari.Icra.AlacakNedenTarafGetFoyAndTaraf(MyDataSource, foyTaraf);
        }

        /// <summary>
        /// Belirtilen tipte nesneler alır
        /// (AV001_TI_BIL_FOY_TARAF)
        /// </summary>
        /// <param name="taraf"></param>
        private void BorcluHesabiGayriNakti(IEntity taraf)
        {
            if (taraf is AV001_TI_BIL_FOY_TARAF)
            {
                var foyTaraf = taraf as AV001_TI_BIL_FOY_TARAF;
                var nedenler = HesapAraclari.Icra.AlacakNedenDepoAlacaklariByFoyAndTarafPerf(MyDataSource, foyTaraf);
                GayriNakitHesabi();
                ucAlacaklar.DatayiDoldur();
                //ucAlacaklar.MyDataSource = nedenler;
            }
        }

        /// <summary>
        /// Belirtilen tipte nesneler alır
        /// (AV001_TI_BIL_FOY_TARAF)
        /// </summary>
        /// <param name="taraf"></param>
        private void BorcluHesabiCekYapragi(IEntity taraf)
        {
            if (taraf is AV001_TI_BIL_FOY_TARAF)
            {
                var foyTaraf = taraf as AV001_TI_BIL_FOY_TARAF;
                var nedenler = HesapAraclari.Icra.AlacakNedenCelYapraklariByFoyAndTaraf(MyDataSource, foyTaraf);
            }
        }

        #endregion

        #region Takip Hesapla

        /// <summary>
        /// bwHesapla ile hesap yapmak için bu method kullanılmalı
        /// </summary>
        /// <param name="o"></param>
        private void HesabiCalistir(object o)
        {
            if (o != null)
            {
                if (!bwHesapla.IsBusy)
                {
                    this.Enabled = false;
                    bwHesapla.RunWorkerAsync(o);
                }
            }
        }

        private void SetHesapCetveli(Control con, HesapAraclari.OzetHesap ozetHesap)
        {
            if (con is ucIcraHesapCetveli)
            {
                var cetvel = con as ucIcraHesapCetveli;

                cetvel.MyOzetHesap = ozetHesap;
            }
            else if (con != null && con.Parent != null)
            {
                SetHesapCetveli(con.Parent, ozetHesap);
            }
        }

        private void bwHesapla_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is HesapAraclari.OzetHesap)
                {
                    var ozetHesap = e.Result as HesapAraclari.OzetHesap;
                    ucOzetHesapCetveli1.MyDataSource = ozetHesap;

                    if (ozetHesap != null)
                        FormlariDoldur(ozetHesap.MyFoy);
                    if (SetBaslikGrubu == BaslikGruplari.Klasor)
                    {
                        SetHesapCetveli(this, ozetHesap);
                    }
                }
            }
            this.Enabled = true;
        }

        private void bwHesapla_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null)
            {
                if (e.Argument is AV001_TI_BIL_FOY)
                {
                    var foy = e.Argument as AV001_TI_BIL_FOY;
                    if (foy.Tag != null && foy.Tag.ToString() == "Hesapla")
                    {
                        Hesap.Icra hy = new Hesap.Icra(foy);
                    }

                    var ozetHesap = new HesapAraclari.OzetHesap(foy);

                    foy.Tag = string.Empty;
                    e.Result = ozetHesap;
                    return;
                }
                else if (e.Argument is AV001_TDIE_BIL_PROJE)
                {
                    var proje = e.Argument as AV001_TDIE_BIL_PROJE;

                    KlasorHesapAraclari kh = new KlasorHesapAraclari();
                    e.Result = kh.GetKonsolideAlacaklarHesabi2G(proje);
                }
            }
        }

        private BackgroundWorker bwHesapla = new BackgroundWorker();

        private void TakipHesabi()
        {
            if (rgTercihler.SelectedIndex != 0)
                rgTercihler.SelectedIndex = 0;
            if (!ceMusterek.Checked)
            {
                ceMusterek.Checked = true;
            }
            if (SetBaslikGrubu == BaslikGruplari.Klasor)
                ProjeBul(this);

            if (SetBaslikGrubu == BaslikGruplari.Dosya)
            {
                if (MyDataSource == null)
                    FoyBul(this);
            }

            SayfaDegistir(HesaplamaTipleri.Takip_Hesabi);
            if (MyProje != null)
                HesabiCalistir(MyProje);
            else
            {
                IcraTakipForms._frmIcraTakip.SonHesapTarihiKontrolu(MyDataSource);
                HesabiCalistir(MyDataSource);
            }
        }

        private void GayriNakitHesabi()
        {
            SayfaDegistir(HesaplamaTipleri.GayriNakitHesabi);
        }

        private void CekYapragi()
        {
            SayfaDegistir(HesaplamaTipleri.CekYapragi);
        }

        #region Takipsiz Alacaklar

        private BackgroundWorker bwTakipsizAlacaklar = new BackgroundWorker();

        private void bwTakipsizAlacaklar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is HesapAraclari.OzetHesap)
            {
                ucOzetHesapCetveli1.MyDataSource = e.Result as HesapAraclari.OzetHesap;
                FormlariDoldur(ucOzetHesapCetveli1.MyDataSource.MyFoy);
            }

            SayfaDegistir(HesaplamaTipleri.TakipsizAlacaklar);
            this.Enabled = true;
        }

        private void bwTakipsizAlacaklar_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is AV001_TDIE_BIL_PROJE)
            {
                var proje = e.Argument as AV001_TDIE_BIL_PROJE;

                KlasorHesapAraclari kh = new KlasorHesapAraclari();
                e.Result = kh.GetTakipsizAlacaklarHesabi(proje);
            }
        }

        private void TakipsizAlacaklariHesapla()
        {
            ProjeBul(this);
            if (MyProje != null)
            {
                this.Enabled = false;
                if (!bwTakipsizAlacaklar.IsBusy)
                    bwTakipsizAlacaklar.RunWorkerAsync(MyProje);
            }
        }

        #endregion

        #region Takipli alacaklar

        private BackgroundWorker bwTakipliAlacaklar = new BackgroundWorker();

        private void bwTakipliAlacaklar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is AvukatProLib.Hesap.HesapAraclari.OzetHesap)
            {
                ucOzetHesapCetveli1.MyDataSource = e.Result as HesapAraclari.OzetHesap;
                FormlariDoldur(ucOzetHesapCetveli1.MyDataSource.MyFoy);
            }
            SayfaDegistir(HesaplamaTipleri.TakipliAlacaklar);

            this.Enabled = true;
        }

        private void bwTakipliAlacaklar_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is AV001_TDIE_BIL_PROJE)
            {
                var proje = e.Argument as AV001_TDIE_BIL_PROJE;
                KlasorHesapAraclari kh = new KlasorHesapAraclari();
                var sonuc = kh.GetTakipliAlacaklarHesabi(proje);
                e.Result = sonuc;
            }
        }

        private void TakipliAlacaklariHesapla()
        {
            ProjeBul(this);
            if (MyProje != null)
            {
                this.Enabled = false;

                if (!bwTakipliAlacaklar.IsBusy)
                    bwTakipliAlacaklar.RunWorkerAsync(MyProje);
                else
                    MessageBox.Show("Hesaplama İşlemi Devam Ediyor");
            }
        }

        #endregion

        #endregion

        #region Enums

        public enum BaslikGruplari
        {
            Klasor,
            Dosya
        }

        public enum HesaplamaTipleri
        {
            Takip_Hesabi = 1,
            TakipliAlacaklar = 2,
            TakipsizAlacaklar = 3,
            TeminatAlacaklari = 4,
            GayriNakitHesabi = 5,
            CekYapragi = 6
        }

        #endregion

        private void sbtnKapat_Click(object sender, EventArgs e)
        {
            MyProje.DURUM_ID = 28;//İNDİRİMLİ TAHSİLAT (İndirimle Kapama)
            MyProje.BITIS_TARIHI = (DateTime)dtIndirimliKapama.EditValue;

            btnHEesapla.PerformClick();
        }
    }
}