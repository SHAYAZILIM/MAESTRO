using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms.Icra;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucBorcluMalBilgileri : AvpXUserControl
    {
        public TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> Arac;

        public TList<AV001_TI_BIL_GAYRIMENKUL> gayrimenkul = new TList<AV001_TI_BIL_GAYRIMENKUL>();

        public TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> Gemi;

        public int MyTip;

        public bool OutSource;

        public bool Taraf;

        public TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> Ucak;

        private TList<TDI_BIL_BORCLU_MAL> _MyDataSource;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private bool initsFilled;

        private AV001_TI_BIL_FOY myFoy;

        private AV001_TDI_BIL_SOZLESME mySozlesme;

        private AV001_TI_BIL_FOY_TARAF TakipEdilen;

        public ucBorcluMalBilgileri()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucBorcluMalBilgileri_Load;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int FocusedIndex { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<TDI_BIL_BORCLU_MAL> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    if (!Taraf)
                    {
                        if (value.TDI_BIL_BORCLU_MALCollection.Count == 0)
                            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren, typeof(TList<TDI_BIL_BORCLU_MAL>));
                        MyDataSource = value.TDI_BIL_BORCLU_MALCollection;
                    }

                    else
                    {
                        List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF> foyTaraflar = BelgeUtil.Inits.FoyTarafGetir(MyFoy);
                        TList<TDI_BIL_BORCLU_MAL> tumMallar = new TList<TDI_BIL_BORCLU_MAL>();
                        foyTaraflar.ForEach(item =>
                            {
                                if (item.CARI_ID.HasValue)
                                {
                                    TList<TDI_BIL_BORCLU_MAL> mallar = DataRepository.TDI_BIL_BORCLU_MALProvider.GetByCARI_ID(item.CARI_ID.Value);
                                    if (mallar != null && mallar.Count > 0)
                                        tumMallar.AddRange(mallar);
                                }
                            });
                        MyDataSource = tumMallar;
                    }
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDI_BIL_SOZLESME MySozlesme
        {
            get { return mySozlesme; }
            set
            {
                mySozlesme = value;
                if (value != null && Taraf == false)
                    MyDataSource = value.TDI_BIL_BORCLU_MALCollection;
            }
        }

        [Description("Görünümü Deðiþtirir.")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ViewType MyType { get; set; }

        [Browsable(true), Category("BorcluMal")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowOnlyGridControl { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static int GetMalSiraNo(TList<TDI_BIL_BORCLU_MAL> list)
        {
            if (list.Count > 0)
            {
                list.Sort("MAL_SIRA_NO DESC");

                return list[0].MAL_SIRA_NO + 1;
            }
            else
                return 1;
        }

        public static int GetMalSiraNo(TList<TDI_BIL_BORCLU_MAL> list, AV001_TI_BIL_FOY foy)
        {
            int i = 1;
            if (foy.TDI_BIL_BORCLU_MALCollection.Count > 0)
            {
                foy.TDI_BIL_BORCLU_MALCollection.Sort("MAL_SIRA_NO DESC");

                i = foy.TDI_BIL_BORCLU_MALCollection[0].MAL_SIRA_NO;

                i++;
            }
            if (list.Count > 0)
            {
                list.Sort("MAL_SIRA_NO DESC");

                i = list[0].MAL_SIRA_NO + 1;
            }

            return i;
        }

        public void addNew_ColumnChanging(object sender, TDI_BIL_BORCLU_MALEventArgs e)
        {
            TDI_BIL_BORCLU_MAL malbilgi = sender as TDI_BIL_BORCLU_MAL;
            if (e.Column == TDI_BIL_BORCLU_MALColumn.HACIZLI_MAL_ADEDI)
            {
                malbilgi.HACIZLI_MAL_SATIR_TOPLAM_MIKTAR = malbilgi.HACIZLI_MAL_DEGERI.Value * Convert.ToDecimal(e.Value);
            }
        }

        public void AlacaklýGetir(AV001_TI_BIL_FOY foy)
        {
            if (foy != null)
            {
                TList<AV001_TI_BIL_FOY_TARAF> trf = foy.AV001_TI_BIL_FOY_TARAFCollection;
                foreach (AV001_TI_BIL_FOY_TARAF var in trf)
                {
                    if (!var.TAKIP_EDEN_MI)
                    {
                        TakipEdilen = new AV001_TI_BIL_FOY_TARAF();
                        TakipEdilen = var;
                    }
                }
            }
        }

        public void BindData()
        {
            if (MyDataSource == null) return;
            MyDataSource.AddingNew += BorcluMal_AddingNew;
            MyDataSource.ListChanged += MyDataSource_ListChanged;
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        internal static string Validate(TDI_BIL_BORCLU_MAL n)
        {
            StringBuilder sb = new StringBuilder();
            if (n.CARI_ID == 0)
                sb.AppendLine("* Þahýs Bilgisi boþ olamaz.");
            if (n.HACIZLI_MAL_KATEGORI_ID == 0)
                sb.AppendLine("* Kategorisi boþ olamaz.");
            if (n.HACIZLI_MAL_TUR_ID == 0)
                sb.AppendLine("* Tür Alaný boþ olamaz.");
            if (n.HACIZLI_MAL_CINS_ID == 0)
                sb.AppendLine("* Cins Alaný boþ olamaz.");
            if (n.HACIZLI_MAL_ADET_BIRIM_ID == 0)
                sb.AppendLine("* Adedi Birim boþ olamaz.");

            return sb.ToString();
        }

        private void Arac_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_GEMI_UCAK_ARAC arac = new AV001_TDI_BIL_GEMI_UCAK_ARAC();
            arac.KAYIT_TARIHI = DateTime.Now;
            arac.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            arac.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            arac.KONTROL_NE_ZAMAN = DateTime.Now;
            arac.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            e.NewObject = arac;
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyFoy != null)
            {
                if (MyDataSource.Count == 0 && !Taraf && !OutSource)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<TDI_BIL_BORCLU_MAL>));
                    MyDataSource = MyFoy.TDI_BIL_BORCLU_MALCollection;
                }
                else if (MyDataSource.Count == 0 && Taraf && !OutSource)
                {
                    MyDataSource = DataRepository.TDI_BIL_BORCLU_MALProvider.GetByCARI_ID(
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID.Value);
                }
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                LoadInitsData();
                extendedGridControl1.DataSource = MyDataSource;
                dataNavigatorExtended1.DataSource = MyDataSource;
                vGridControl1.DataSource = MyDataSource;
            }
        }

        private void BorcluMal_AddingNew(object sender, AddingNewEventArgs e)
        {
            LoadInitsData();

            // Todo: ForumPatlýyordu Tarafýmdan Düzeltildi..... Canan
            TDI_BIL_BORCLU_MAL addNew = e.NewObject as TDI_BIL_BORCLU_MAL;

            try
            {
                if (MyFoy != null)
                {
                    TList<AV001_TI_BIL_FOY_TARAF> foytrf = ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy);
                    if (addNew == null)
                        addNew = new TDI_BIL_BORCLU_MAL();

                    addNew.HACIZLI_MAL_ADET_BIRIM_ID = (int)HacizliMalAdetBirim.AD;
                    addNew.HACIZLI_MAL_ADEDI = 1;
                    if (frmIcraDosyaKayit.listTakipEden.Count != 0 || frmIcraDosyaKayit.listTakipEden.Count > 0)
                    {
                        addNew.CARI_ID = frmIcraDosyaKayit.listTakipEden[0].CARI_ID.Value;
                    }
                    else
                    {
                        AlacaklýGetir(MyFoy);
                        addNew.CARI_ID = foytrf[0].CARI_ID.Value;
                    }

                    addNew.MAL_SIRA_NO = GetMalSiraNo(MyFoy.TDI_BIL_BORCLU_MALCollection);
                    addNew.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                    addNew.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
                    addNew.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                    addNew.ESAS_NO = MyFoy.ESAS_NO;
                    if (MyTip == (int)HAZIZ_CHILD_TIP.Araþtýrma_Ýle_Tespit_Edilmiþ_Mal)
                        addNew.TIP = (byte)MyTip;
                    else if (MyTip == (int)HAZIZ_CHILD_TIP.Rehin_Edilmiþ_Mal)
                        addNew.TIP = (byte)MyTip;
                    else if (MyTip == (int)HAZIZ_CHILD_TIP.Borçlunun_Beyan_Ettiði_Mal)
                        addNew.TIP = (byte)MyTip;
                    else if (MyTip == (int)HAZIZ_CHILD_TIP.Haciz_Edilmiþ_Mal)
                        addNew.TIP = (byte)MyTip;

                    //switch ((FormTipleri)MyFoy.FORM_TIP_ID.Value)
                    //{
                    //    case FormTipleri.Form50:
                    //    case FormTipleri.Form151:
                    //    case FormTipleri.Form201:
                    //    case FormTipleri.Form152:
                    //        addNew.TIP = (int)HAZIZ_CHILD_TIP.Rehin_Edilmiþ_Mal;
                    //        break;
                    //}

                    addNew.ColumnChanging += addNew_ColumnChanging;
                    e.NewObject = addNew;
                }
            }

            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void extendedGridControl1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            else if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                //UNDONE: Form açýldýðýnda kayýt ekle butonuna týklamadan varsayýlan bilgileri getiriyor. Kayýt ekle butonuna týklandýðýnda getirmeli.
                //UNDONE: Araþtýrma ile tespit edilen mallar sekmesinden bir kayýt girildiðinde borçlunun beyan ettiði mallar sekmesinde görüntüleniyor.
                frmBorcluMalKaydetVGrid frm = new frmBorcluMalKaydetVGrid();
                if (MyFoy != null)
                {
                    frm.MyTip = MyTip;
                    frm.MyFoy = MyFoy;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;

                    frm.FormClosed += frm_FormClosed;
                }
                if (MySozlesme != null)
                {
                    frm.MySozlesme = MySozlesme;
                }
                frm.Show();
            }
            else if (e.Button.Tag.ToString() == "Duzenle" && gridView1.GetFocusedRow() != null)
            {
                #region <AC - 20090613>

                // Seçilen kaydý düzenle.
                //UNDONE: Kaydý düzenle formu açýldýðýnda boþ bir kayýt ekliyor. Boþ bir kayýt eklememeli.
                //UNDONE: Tüm kayýtlarý görüntülüyor. Sadece seçilen kaydý görüntülemeli.
                frmBorcluMalKaydetVGrid frm = new frmBorcluMalKaydetVGrid();
                frm.Text = "Borçlunun Mal Bilgileri Düzenleme Formu";
                if (MyFoy != null)
                {
                    frm.MyDataSource = MyDataSource;
                    frm.MyFoy = MyFoy;
                    frm.MySozlesme = MySozlesme;
                }
                frm.Show();

                #endregion <AC - 20090613>
            }
            else if (e.Button.Tag.ToString() == "Sil" && gridView1.GetFocusedRow() != null)
            {
                #region <AC - 20090613>

                // Seçilen kaydý sil.
                //UNDONE: TDI_BIL_BORCLU_MAL Database Delete Cascade kontrolü yapýlacak.
                if (
                    XtraMessageBox.Show(
                        string.Format("Seçilen kayýt silinsin mi?{0}Bu kayda baðlý kayýtlar varsa tamamý silinecek.",
                                      Environment.NewLine), "Kayýt Sil", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    if (MyDataSource.Remove((TDI_BIL_BORCLU_MAL)gridView1.GetFocusedRow()))
                        XtraMessageBox.Show("Kayýt baþarýyla silindi.", "Bilgi", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                    else
                        XtraMessageBox.Show("Kayýt silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                #endregion <AC - 20090613>
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindData();
        }

        private void gayrimenkul_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_GAYRIMENKUL gayri = new AV001_TI_BIL_GAYRIMENKUL();
            ucMenkulTaraf1.MyDataSource = gayri.AV001_TI_BIL_GAYRIMENKUL_TARAFCollection;
            e.NewObject = gayri;
        }

        private void LoadInitsData()
        {
            if (!initsFilled && MyDataSource.Count > 0)
            {
                BelgeUtil.Inits.ParaBicimiAyarla(tutar);
                BelgeUtil.Inits.MalcinsGetir(rLueMalCins);
                BelgeUtil.Inits.MalKategoriGetir(rLueHacizliMalKategori);
                BelgeUtil.Inits.MalTurGetir(rLueMalTur);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
                BelgeUtil.Inits.perCariGetir(rLueCari);
                BelgeUtil.Inits.HacizIslemDurumGetir(rLueIslemDurum);
                BelgeUtil.Inits.BirimKodGetir(rLueMalAdetBirim);
                BelgeUtil.Inits.HacizChildTipGetir(rLueTip);
                BelgeUtil.Inits.MalKategoriResimliGetir(rLueKategoriResimCombo);

                initsFilled = true;
            }
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            LoadInitsData();
        }

        private void rLueCari_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            frmCariGenelGiris cari;
            if (e.Button.Tag != null && e.Button.Tag == "CariEkle")
            {
                cari = new frmCariGenelGiris();
                cari.tmpCariAd = lue.Text;

                //cari.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               //Inits.perCariGetirRefresh();
                                               BelgeUtil.Inits.perCariGetir(rLueCari);
                                           }
                                       };
            }
        }

        private void rLueCari_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            frmCariGenelGiris cari;

            cari = new frmCariGenelGiris();
            cari.tmpCariAd = lue.Text;

            cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
            cari.Show();
            cari.FormClosed += delegate
                                   {
                                       DialogResult dr = cari.KayitBasarili;
                                       if (dr == System.Windows.Forms.DialogResult.OK)
                                       {
                                           BelgeUtil.Inits.perCariGetir(rLueCari);
                                       }
                                   };
        }

        private void rLueHacizliMalKategori_EditValueChanging(object sender,
                                                              DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((int)e.NewValue == (int)HACIZLI_MAL_KATEGORI.ARAÇ)
            {
                tabPArac.PageVisible = true;
                tabPArac.PageEnabled = true;
                panelControl2.Visible = true;
                panelControl2.Enabled = true;
                Arac.AddingNew += Arac_AddingNew;
                Arac.AddNew();
                MyDataSource[vGridControl1.FocusedRecord].ARAC_BILGI_IDSource = Arac[0];
                splitContainerControl1.Panel2.Enabled = true;
                splitContainerControl1.Panel2.Visible = true;
                xtraTabControl1.SelectedTabPage = tabPArac;
                ucUcakGemiArac1.KontrolTipi = AvukatProLib.Extras.GemiUcakAracTipi.Arac;
                ucUcakGemiArac1.MyDataSource = Arac;
                ucUcakGemiArac1.Dock = DockStyle.Fill;
                tabPGayrimenkul.PageVisible = false;
                tabPGayrimenkul.PageEnabled = false;
            }
            else if ((int)e.NewValue == (int)HACIZLI_MAL_KATEGORI.GEMÝ)
            {
                tabPArac.PageVisible = true;
                tabPArac.PageEnabled = true;
                panelControl2.Visible = true;
                panelControl2.Enabled = true;
                splitContainerControl1.Panel2.Enabled = true;
                splitContainerControl1.Panel2.Visible = true;
                xtraTabControl1.SelectedTabPage = tabPArac;
                Gemi.AddingNew += Arac_AddingNew;
                Gemi.AddNew();
                MyDataSource[vGridControl1.FocusedRecord].ARAC_BILGI_IDSource = Gemi[0];
                ucUcakGemiArac1.KontrolTipi = AvukatProLib.Extras.GemiUcakAracTipi.Gemi;
                ucUcakGemiArac1.MyDataSource = Gemi;
                ucUcakGemiArac1.Dock = DockStyle.Fill;

                tabPGayrimenkul.PageVisible = false;
                tabPGayrimenkul.PageEnabled = false;
            }
            else if ((int)e.NewValue == (int)HACIZLI_MAL_KATEGORI.UÇAK)
            {
                tabPArac.PageVisible = true;
                tabPArac.PageEnabled = true;
                panelControl2.Visible = true;
                panelControl2.Enabled = true;
                splitContainerControl1.Panel2.Enabled = true;
                splitContainerControl1.Panel2.Visible = true;
                xtraTabControl1.SelectedTabPage = tabPArac;
                Ucak.AddingNew += Arac_AddingNew;
                Ucak.AddNew();
                ucUcakGemiArac1.Dock = DockStyle.Fill;
                MyDataSource[vGridControl1.FocusedRecord].ARAC_BILGI_IDSource = Ucak[0];
                ucUcakGemiArac1.KontrolTipi = AvukatProLib.Extras.GemiUcakAracTipi.Ucak;
                ucUcakGemiArac1.MyDataSource = Ucak;

                tabPGayrimenkul.PageVisible = false;
                tabPGayrimenkul.PageEnabled = false;
            }
            else if ((int)e.NewValue == (int)HACIZLI_MAL_KATEGORI.GAYRÝMENKUL)
            {
                tabPGayrimenkul.PageVisible = true;
                tabPGayrimenkul.PageEnabled = true;
                panelControl2.Visible = true;
                panelControl2.Enabled = true;
                splitContainerControl1.Panel2.Enabled = true;
                splitContainerControl1.Panel2.Visible = true;
                gayrimenkul.AddingNew += gayrimenkul_AddingNew;
                gayrimenkul.AddNew();
                MyDataSource[vGridControl1.FocusedRecord].GAYRIMENKUL_BILGI_IDSource = gayrimenkul[0];
                ucGayriMenkul1.dataNavigatorExtended1.Enabled = false;
                ucGayriMenkul1.dataNavigatorExtended1.Visible = false;
                ucGayriMenkul1.MyDataSource = gayrimenkul;
                ucMenkulTaraf1.MyDataSource = gayrimenkul[0].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection;
                xtraTabControl1.SelectedTabPage = tabPGayrimenkul;
                tabPArac.PageVisible = false;
                tabPArac.PageEnabled = false;
            }
            else
            {
                splitContainerControl1.Panel2.Enabled = false;
                splitContainerControl1.Panel2.Visible = false;
                panelControl2.Visible = false;
                panelControl2.Enabled = false;
            }
        }

        private void ucBorcluMalBilgileri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            splitContainerControl1.Panel2.Enabled = false;
            splitContainerControl1.Panel2.Visible = false;
            panelControl2.Visible = false;
            panelControl2.Enabled = false;
            IsLoaded = true;

            //LOAD
            if (this.DesignMode)
                return;
            //LoadInitsData();
            BindData();
            vGridControl1.FocusedRecord = FocusedIndex;
            if (MyType == ViewType.GridView)
            {
                panelControl1.Visible = false;
                extendedGridControl1.Visible = true;
                extendedGridControl1.BringToFront();
            }
            if (MyType == ViewType.LayoutView)
            {
                panelControl1.Visible = false;
                extendedGridControl1.Visible = false;
            }
            if (MyType == ViewType.VGrid)
            {
                panelControl1.Visible = true;
                extendedGridControl1.Visible = false;
                panelControl1.BringToFront();
            }

            panelControl1.Visible = !ShowOnlyGridControl;
            if (ShowOnlyGridControl)
            {
                extendedGridControl1.BringToFront();
            }
            Ucak = new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();
            Gemi = new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();
            Arac = new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();
        }
    }
}