using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.DavaTakip;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AdimAdimDavaKaydi.Util;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;

namespace AdimAdimDavaKaydi.GirisEkran
{
    //TODO : DAVA EDÝLEN TUTAR  ViEW E EKLENECEK SONRA O BÖLÜMDEN ARAMA YAPILACAK ...

    public partial class rFrmDavaGirisHizliEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public static List<AvukatProLib.Arama.per_DAVA_HIZLI_ARAMA> tempDava;
        private List<AvukatProLib.Arama.per_DAVA_HIZLI_ARAMA> _MyDataSourceDeep;
        private BackgroundWorker bckWorker;
        private BackgroundWorker bwLoad = new BackgroundWorker();

        private frmDavaTakip frmDavaTakipEkran;

        private VList<DAVA_PRATIK_ARAMA> MyDataSourcePratik = new VList<DAVA_PRATIK_ARAMA>();

        private ImageList myImageList = new ImageList();


        public rFrmDavaGirisHizliEkran()
        {
            this.Load += rFrmDavaGirisEkran_Load;
        }

        public List<AvukatProLib.Arama.per_DAVA_HIZLI_ARAMA> MyDataSourceDeep
        {
            get { return _MyDataSourceDeep; }
            set
            {
                if (value != null)
                {
                    _MyDataSourceDeep = value;
                    ucDavaBIL_Foy1.MyDataSource = value;
                }
            }
        }

        public void AramalarýTemizleGenel()
        {
            FormTools.FormlariTemizle(panelControl5.Controls);
            FormTools.FormlariTemizle(panelControl4.Controls);

            FormTools.FormlariTemizle(panelControl8.Controls);

            ucDavaBIL_Foy1.MyDataSource = MyDataSourceDeep;
            ucDavaBIL_Foy1.FilitreleriTemizle();
            lueSorumluAvukat2.EditValue = null;
            lueDurum2.EditValue = null;
        }

        public List<AvukatProLib.Arama.per_DAVA_HIZLI_ARAMA> GelismisAramaSorgula()
        {
            try
            {
                //List<AvukatProLib.Arama.AV001_TD_BIL_FOY> foyList = null;
                List<AvukatProLib.Arama.per_DAVA_HIZLI_ARAMA> foyler = null;
                if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                {
                    foyler = AvukatProLib.Arama.per_DAVA_HIZLI_ARAMA_Sorgu.GetByFiltreView(null, DosyaNo, EsasNo, Tarih, null, null, Adliye, Gorev, AdliBirimNo, DavaKonusu, Durum, Cari, Sorumlu, null, null);

                    //foyList = AvukatProLib.Arama.R_DAVA_GENEL_ARAMASorgu.GetByFiltreView(Cari, Sorumlu, Banka, Sube,
                    //                                                                     FoyBirim, FoyYeri, OzelDurum,
                    //                                                                     KrediGrubu, KrediTipi,
                    //                                                                     TahsilatDurumu, Klasor1,
                    //                                                                     Klasor2, DavaNedeni, DovizId,
                    //                                                                     Tutar, DnRef1, DnRef2,
                    //                                                                     VadeTarihi, DavaKonusu, DosyaNo,
                    //                                                                     Ref1, Ref2, Ref3, Durum, Tarih,
                    //                                                                     Adliye, AdliBirimNo, Gorev,
                    //                                                                     EsasNo, OzelKod1, OzelKod2,
                    //                                                                     OzelKod3, OzelKod4,
                    //                                                                     KarsiTarafVekil, secim, null,
                    //                                                                     DurusmaTarih, KesifTarih,
                    //                                                                     AvukatProLib.Kimlik.
                    //                                                                         SirketBilgisi.ConStr);
                }
                else
                {
                    foyler = AvukatProLib.Arama.per_DAVA_HIZLI_ARAMA_Sorgu.GetByFiltreView(null, DosyaNo, EsasNo, Tarih, null, null, Adliye, Gorev, AdliBirimNo, DavaKonusu, Durum, Cari, Sorumlu, null, AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);

                    //    foyList = AvukatProLib.Arama.R_DAVA_GENEL_ARAMASorgu.GetByFiltreView(Cari, Sorumlu, Banka, Sube,
                    //                                                                         FoyBirim, FoyYeri, OzelDurum,
                    //                                                                         KrediGrubu, KrediTipi,
                    //                                                                         TahsilatDurumu, Klasor1,
                    //                                                                         Klasor2, DavaNedeni, DovizId,
                    //                                                                         Tutar, DnRef1, DnRef2,
                    //                                                                         VadeTarihi, DavaKonusu, DosyaNo,
                    //                                                                         Ref1, Ref2, Ref3, Durum, Tarih,
                    //                                                                         Adliye, AdliBirimNo, Gorev,
                    //                                                                         EsasNo, OzelKod1, OzelKod2,
                    //                                                                         OzelKod3, OzelKod4,
                    //                                                                         KarsiTarafVekil, secim,
                    //                                                                         AvukatProLib.Kimlik.Bilgi.
                    //                                                                             KULLANICI_SUBE_ID,
                    //                                                                         DurusmaTarih, KesifTarih,
                    //                                                                         AvukatProLib.Kimlik.
                    //                                                                             SirketBilgisi.ConStr);
                    //
                }

                return foyler;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
                return null;
            }
        }

        public void TakibeGonder()
        {
            tempDava = ucDavaBIL_Foy1.GetSelectedFoy(ucDavaBIL_Foy1.MyDataSource);
            if (tempDava.Count > 0)
            {
                frmDavaTakipEkran = new frmDavaTakip();
                TList<AV001_TD_BIL_FOY> foyList = new TList<AV001_TD_BIL_FOY>();
                foreach (var item in tempDava)
                {
                    foyList.Add(DataRepository.AV001_TD_BIL_FOYProvider.GetByID(item.ID));
                }
                frmDavaTakipEkran.Show(foyList);
            }
            else
            {
                DialogResult dr =
                    XtraMessageBox.Show("Seçilen kayýt yok. Bütün kayýtlarý açmak istediðinizden emin misiniz?",
                                        "Foy Arama", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    frmDavaTakipEkran = new frmDavaTakip();

                    tempDava = ucDavaBIL_Foy1.MyDataSource;
                    TList<AV001_TD_BIL_FOY> foyList = new TList<AV001_TD_BIL_FOY>();
                    foreach (var item in tempDava)
                    {
                        foyList.Add(DataRepository.AV001_TD_BIL_FOYProvider.GetByID(item.ID));
                    }
                    frmDavaTakipEkran.Show(foyList);
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //this.Enabled = false;
            InitsData();
            rgDosyalar.EditValue = 1;
            this.ucDavaBIL_Foy1 = new AdimAdimDavaKaydi.UserControls.ucDavaHizliAramaFoy();

            this.navBarGroupControlContainer4.Controls.Add(this.ucDavaBIL_Foy1);

            //
            // ucDavaBIL_Foy1
            //
            this.ucDavaBIL_Foy1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDavaBIL_Foy1.Location = new System.Drawing.Point(0, 0);

            this.ucDavaBIL_Foy1.Name = "ucDavaBIL_Foy1";
            this.ucDavaBIL_Foy1.Size = new System.Drawing.Size(820, 364);
            this.ucDavaBIL_Foy1.TabIndex = 0;
            bckWorker = new BackgroundWorker();
            bckWorker.DoWork += delegate
                                    {
                                        InitializeEvents();

                                        #region Merkez Harici Görünmeyecekler (PRATÝK ARAMA - PÝVOT)

                                        if (AvukatProLib.Kimlik.Bilgi != null &&
                                            AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null &&
                                            AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI != "MERKEZ")
                                        {
                                            dockPanel1.Enabled = false;
                                        }

                                        #endregion Merkez Harici Görünmeyecekler (PRATÝK ARAMA - PÝVOT)

                                        //LOAD
                                        tlDavaAsamalar.StateImageList = myImageList;

                                        #region Ozellestirme

                                        //TARIH         :  29 Eylül 2009 Salý
                                        //KODU YAZAN    :  Mehmet Emin AYDOÐDU
                                        //NEDENI        :   Baþlýklarýn Veri Tabnýndan Alýnmasý
                                        //Mehmet Begin

                                        try
                                        {
                                            foreach (GridColumn item in ucDavaBIL_Foy1.gridView1.Columns)
                                            {
                                                if (item.Name.Contains("colREFERANS_NO1"))
                                                    item.Caption = Kimlikci.Kimlik.DavaReferans.Referans1;
                                                if (item.Name.Contains("colREFERANS_NO21"))
                                                    item.Caption = Kimlikci.Kimlik.DavaReferans.Referans2;
                                                if (item.Name.Contains("colREFERANS_NO31"))
                                                    item.Caption = Kimlikci.Kimlik.DavaReferans.Referans3;
                                                if (item.Name.Contains("OZEL_KOD1"))
                                                    item.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod1;
                                                if (item.Name.Contains("OZEL_KOD2"))
                                                    item.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod2;
                                                if (item.Name.Contains("OZEL_KOD3"))
                                                    item.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod3;
                                                if (item.Name.Contains("OZEL_KOD4"))
                                                    item.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod4;
                                            }
                                        }
                                        catch
                                        {
                                        }

                                        //Mehmet End

                                        #endregion Ozellestirme

                                        if (Sorumlu == null)
                                            Sorumlu = AvukatProLib.Kimlik.CurrentCariId;
                                        if (Durum == null)
                                            Durum = (int?)FoyDurum.FAAL;
                                    };
            bckWorker.RunWorkerCompleted += delegate
                                                {
                                                    this.Enabled = true;

                                                    #region Captionlar

                                                    //TARIH         :  08 Eylül 2009 Çarþamba
                                                    //KODU YAZAN    :  Mehmet Emin AYDOÐDU
                                                    //NEDENI        :  Özel Kodlar ve Referans Baþlýklarýnýn Veri Tabnýndan Alýnmasý
                                                    //Mehmet Bas
                                                    try
                                                    {
                                                        foreach (GridColumn item in ucDavaBIL_Foy1.gridView1.Columns)
                                                        {
                                                            if (item.Name.Contains("colREFERANS_NO"))
                                                                item.Caption = Kimlikci.Kimlik.DavaReferans.Referans1;
                                                            if (item.Name.Contains("colREFERANS_NO2"))
                                                                item.Caption = Kimlikci.Kimlik.DavaReferans.Referans2;
                                                            if (item.Name.Contains("colREFERANS_NO3"))
                                                                item.Caption = Kimlikci.Kimlik.DavaReferans.Referans3;
                                                            if (item.Name.Contains("colOZEL_KOD1"))
                                                                item.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod1;
                                                            if (item.Name.Contains("colOZEL_KOD2"))
                                                                item.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod2;
                                                            if (item.Name.Contains("colOZEL_KOD3"))
                                                                item.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod3;
                                                            if (item.Name.Contains("colOZEL_KOD4"))
                                                                item.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod4;
                                                        }
                                                    }
                                                    catch 
                                                    {
                                                    }

                                                    //Mehmet Bit

                                                    #endregion Captionlar
                                                };
            bckWorker.RunWorkerAsync();
        }

        private void AramaYap(AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf secTaraf,
                              AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur secTur)
        {
            TList<TDIE_KOD_ASAMA> asamaList = new TList<TDIE_KOD_ASAMA>();
            TList<TDIE_KOD_ASAMA_ALT> altAsamaList = new TList<TDIE_KOD_ASAMA_ALT>();

            if (secTur == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur.AnaAsama)
            {
                if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Karsi)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByTaraf(txtArama.Text, "K");
                }
                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Muvekkil)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByTaraf(txtArama.Text, "M");
                }
                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Mudurluk)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByMahkemeMi(txtArama.Text, true);
                }

                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Tumu)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByTumu(txtArama.Text);
                }
            }

            else if (secTur == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur.AltAsama)
            {
                if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Karsi)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByTaraf(txtArama.Text, "K");
                }
                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Muvekkil)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByTaraf(txtArama.Text, "M");
                }
                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Mudurluk)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByMahkemeMi(txtArama.Text, true);
                }
                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Tumu)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByTumu(txtArama.Text);
                }
            }

            if (asamaList.Count == 0)
            {
                XtraMessageBox.Show("Aradýðýnýz kriterlere uyan aþama bulunamadý.", "Arama Sonucu", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }

            tlDavaAsamalar.Nodes.TreeList.ExpandAll();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf taraf =
                (AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf)
                rgTaraf.Properties.Items.GetItemIndexByValue(rgTaraf.SelectedIndex);
            AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur tur =
                (AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur)
                rgTur.Properties.Items.GetItemIndexByValue(rgTur.SelectedIndex);
            AramaYap(taraf, tur);
        }

        private void btnAramaKriterleriniTemizle2_Click(object sender, EventArgs e)
        {
            AramalarýTemizleGenel();
        }

        private void btnAsamaSorgula_Click(object sender, EventArgs e)
        {
            string secilenUstler = string.Empty;
            string secilenlerAltlar = string.Empty;
            for (int i = 0; i < tlDavaAsamalar.Nodes.Count; i++)
            {
                if (tlDavaAsamalar.Nodes[i].Checked)
                {
                    TDIE_KOD_ASAMA ust = tlDavaAsamalar.Nodes[i].Tag as TDIE_KOD_ASAMA;

                    if (ust != null)
                    {
                        secilenUstler += ust.ID + ",";
                    }
                    for (int y = 0; y < tlDavaAsamalar.Nodes[i].Nodes.Count; y++)
                    {
                        if (tlDavaAsamalar.Nodes[i].Nodes[y].Checked)
                        {
                            TDIE_KOD_ASAMA_ALT asamaAlt = tlDavaAsamalar.Nodes[i].Nodes[y].Tag as TDIE_KOD_ASAMA_ALT;
                            if (asamaAlt != null)
                            {
                                secilenlerAltlar += asamaAlt.ID + ",";
                            }
                        }
                    }
                }
            }
        }

        private void btnSorgu_Click(object sender, EventArgs e)
        {
            if (!bwSorgula.IsBusy)
            {
                bwSorgula.RunWorkerAsync();
            }
        }

        private void btnSorgula_Click_1(object sender, EventArgs e)
        {
            btnSorgula.Enabled = false;
            btnAramaKriterleriniTemizle2.Enabled = false;

            btnSorgula.Text = "Aranýyor";
            if (!bwSorgula.IsBusy)
                bwSorgula.RunWorkerAsync();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            DosyaTrfSrmlSecimleriniTemizle();
            ucDavaBIL_Foy1.FilitreleriTemizle();
        }

        private void btnTumKosullariTemizle_Click(object sender, EventArgs e)
        {
            TLDavaSecimleriniDuzenle(false);
            DosyaTrfSrmlSecimleriniTemizle();
            txtArama.Text = string.Empty;
        }

        private void chBoxAsamalarTumu_CheckedChanged(object sender, EventArgs e)
        {
            TLDavaSecimleriniDuzenle(chBoxAsamalarTumu.Checked);
        }

        private void DosyaTrfSrmlSecimleriniTemizle()
        {
            DataTable dtSorumlular = gcSorumlular.DataSource as DataTable;

            DataRow[] dtSeciliSorumlular = dtSorumlular.Select("SECILIMI = 'True'");

            foreach (DataRow row in dtSeciliSorumlular)
            {
                row["SECILIMI"] = false;
            }

            DataTable dtTaraflar = grdcTaraflar.DataSource as DataTable;
            DataRow[] dtSeciliTaraflar = dtTaraflar.Select("SECILIMI = 'True'");

            foreach (DataRow row in dtSeciliTaraflar)
            {
                row["SECILIMI"] = false;
            }

            grdcTaraflar.Refresh();
            gcSorumlular.Refresh();
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Excel_Click += rFrmDavaGirisEkran_Button_Excel_Click;
            this.Button_Word_Click += rFrmDavaGirisEkran_Button_Word_Click;
            this.Button_PDF_Click += rFrmDavaGirisEkran_Button_PDF_Click;
            this.Button_Ac_Click += rFrmDavaGirisEkran_Button_Ac_Click;
            this.Button_Yeniden_Click += rFrmDavaGirisEkran_Button_Yeniden_Click;
            this.Button_Editor_Click += rFrmDavaGirisEkran_Button_Editor_Click;
            this.Button_Yeni_Click += rFrmDavaGirisEkran_Button_Yeni_Click;

            btnSorgu.Click += btnSorgu_Click;
            btnAsamaSorgula.Click += btnAsamaSorgula_Click;
            chBoxAsamalarTumu.CheckedChanged += chBoxAsamalarTumu_CheckedChanged;
            btnTemizle.Click += btnTemizle_Click;
            btnAra.Click += btnAra_Click;
            grdcTaraflar.ButtonTumunuKaldir += grdcTaraflar_ButtonTumunuKaldir;
            grdcTaraflar.ButtonTumunuSec += grdcTaraflar_ButtonTumunuSec;
            gcSorumlular.ButtonTumunuKaldir += gcSorumlular_ButtonTumunuKaldir;
            gcSorumlular.ButtonTumunuSec += gcSorumlular_ButtonTumunuSec;
            btnTumKosullariTemizle.Click += btnTumKosullariTemizle_Click;
            tlDavaAsamalar.AfterCheckNode += tlDavaAsamalar_AfterCheckNode;

            bwSorgula.DoWork += bwSorgula_DoWork;
            bwSorgula.RunWorkerCompleted += bwSorgula_RunWorkerCompleted;

            #region AramaEvents

            #endregion AramaEvents
        }

        private void InitsData()
        {
            lueGorev2.Properties.NullText = "Seç";
            lueGorev2.Enter += delegate { BelgeUtil.Inits.AdliBirimGorevGetir(lueGorev2); };

            lueSorumluAvukat2.Properties.NullText = "Seç";
            lueSorumluAvukat2.Enter += delegate { BelgeUtil.Inits.SorumluAvukatGetir(lueSorumluAvukat2); };
            lueAdliye2.Properties.NullText = "Seç";
            lueAdliye2.Enter += delegate { BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliye2); };

            lueTarafAdi2.Properties.NullText = "Seç";
            lueTarafAdi2.Enter += delegate { BelgeUtil.Inits.perCariGetir(lueTarafAdi2); };

            lueNo2.Properties.NullText = "Seç";
            lueNo2.Enter += delegate { BelgeUtil.Inits.AdliBirimNoGetir(new LookUpEdit[] { lueNo2 }); };

            lueKonu2.Properties.NullText = "Seç";
            lueKonu2.Enter += delegate { BelgeUtil.Inits.DavaTalepGetir(lueKonu2); };

            lueDurum2.Properties.NullText = "Seç";
            lueDurum2.Enter += delegate { BelgeUtil.Inits.FoyDurumGetir(lueDurum2.Properties); };
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)rgDosyalar.EditValue == 1)
            {
                Sorumlu = AvukatProLib.Kimlik.CurrentCariId;
                Durum = (int?)FoyDurum.FAAL;
            }
            if ((int)rgDosyalar.EditValue == 2)
            {
                Sorumlu = AvukatProLib.Kimlik.CurrentCariId;
                Durum = null;
            }
            if ((int)rgDosyalar.EditValue == 3)
            {
                Sorumlu = null;
                Durum = null;
            }
        }

        private void rFrmDavaGirisEkran_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TakibeGonder();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (this.ParentForm as mdiAvukatPro).OpenForm(AvukatProLib.Extras.FormType.DavaGirisEkran);
            this.Close();
        }

        private void tlDavaAsamalar_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            for (int i = 0; i < e.Node.Nodes.Count; i++)
            {
                e.Node.Nodes[i].Checked = e.Node.Checked;
            }

            if (e.Node.ParentNode != null)
            {
                if (e.Node.Checked)
                {
                    e.Node.ParentNode.Checked = true;
                }
                else
                {
                    bool checkKaldir = false;
                    for (int i = 0; i < e.Node.ParentNode.Nodes.Count; i++)
                    {
                        if (e.Node.ParentNode.Nodes[i].Checked)
                        {
                            checkKaldir = true;
                        }
                    }
                    e.Node.ParentNode.Checked = checkKaldir;
                }
            }
        }

        private void TLDavaSecimleriniDuzenle(bool chck)
        {
            for (int i = 0; i < tlDavaAsamalar.Nodes.Count; i++)
            {
                tlDavaAsamalar.Nodes[i].Checked = chck;
                for (int y = 0; y < tlDavaAsamalar.Nodes[i].Nodes.Count; y++)
                {
                    tlDavaAsamalar.Nodes[i].Nodes[y].Checked = chck;
                }
            }
        }

        #region Form Buttonlarý

        private void rFrmDavaGirisEkran_Button_Ac_Click(object sender, EventArgs e)
        {
            FoyTakipAc();
        }

        private void rFrmDavaGirisEkran_Button_Editor_Click(object sender, EventArgs e)
        {
            FoyEditorAc();
        }

        private void rFrmDavaGirisEkran_Button_Excel_Click(object sender, EventArgs e)
        {
            XlsAc();
        }

        private void rFrmDavaGirisEkran_Button_PDF_Click(object sender, EventArgs e)
        {
            PdfAc();
        }

        private void rFrmDavaGirisEkran_Button_Word_Click(object sender, EventArgs e)
        {
            WordAc();
        }

        private void rFrmDavaGirisEkran_Button_Yeni_Click(object sender, EventArgs e)
        {
            YeniFoy();
        }

        private void rFrmDavaGirisEkran_Button_Yeniden_Click(object sender, EventArgs e)
        {
            FoyYenile();
        }

        #endregion Form Buttonlarý

        #region Gelis Arama Methotlari

        private int? AdliBirimNo;
        private int? Adliye;
        private int? Cari;
        private int? DavaKonusu;
        private string DosyaNo;
        private int? Durum;
        private string EsasNo;
        private int? Gorev;
        private int? Sorumlu;
        private DateTime? Tarih;

        private void dtTarih2_EditValueChanged(object sender, EventArgs e)
        {
            if (dtTarih2.Text != string.Empty)
            {
                if (dtTarih2.EditValue != null)
                    Tarih = (DateTime?)dtTarih2.EditValue;
            }
            else
                Tarih = null;
        }

        private void lueAdliye2_EditValueChanged(object sender, EventArgs e)
        {
            Adliye = (int?)lueAdliye2.EditValue;
        }

        private void lueDurum2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDurum2.EditValue == null) Durum = null;
            Durum = (int?)lueDurum2.EditValue;
        }

        private void lueGorev2_EditValueChanged(object sender, EventArgs e)
        {
            Gorev = (int?)lueGorev2.EditValue;
        }

        private void lueKonu2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueKonu2.EditValue != null)
                DavaKonusu = (int?)lueKonu2.EditValue;
            else
                DavaKonusu = null;
        }

        private void lueNo2_EditValueChanged(object sender, EventArgs e)
        {
            AdliBirimNo = (int?)lueNo2.EditValue;
        }

        private void lueSorumluAvukat2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSorumluAvukat2.EditValue != null)
                Sorumlu = (int?)lueSorumluAvukat2.EditValue;
            else
                Sorumlu = null;
        }

        private void lueTarafAdi2_EditValueChanged(object sender, EventArgs e)
        {
            Cari = (int?)lueTarafAdi2.EditValue;
        }

        private void txtDosyaNo2_TextChanged(object sender, EventArgs e)
        {
            DosyaNo = txtDosyaNo2.Text;
            if (txtDosyaNo2.Text == string.Empty)
                DosyaNo = null;
        }

        private void txtEsasNo2_TextChanged(object sender, EventArgs e)
        {
            EsasNo = txtEsasNo2.Text;
            if (txtEsasNo2.Text == string.Empty)
                EsasNo = null;
        }

        #endregion Gelis Arama Methotlari

        #region Taraf Sorumlu Seçim Buttonlarý

        private void gcSorumlular_ButtonTumunuKaldir(object sender, NavigatorButtonClickEventArgs e)
        {
            DataTable dt = gcSorumlular.DataSource as DataTable;

            // DataRow[] dRows = dt.Select("SECILIMI = True");

            foreach (DataRow row in dt.Rows)
            {
                row["SECILIMI"] = false;
            }

            gcSorumlular.Refresh();
        }

        private void gcSorumlular_ButtonTumunuSec(object sender, NavigatorButtonClickEventArgs e)
        {
            DataTable dt = gcSorumlular.DataSource as DataTable;

            //DataRow[] dRows = dt.Select("SECILIMI = False");

            foreach (DataRow row in dt.Rows)
            {
                row["SECILIMI"] = true;
            }

            gcSorumlular.Refresh();
        }

        private void grdcTaraflar_ButtonTumunuKaldir(object sender, NavigatorButtonClickEventArgs e)
        {
            DataTable dt = grdcTaraflar.DataSource as DataTable;

            //DataRow[] dRows = dt.Select("SECILIMI = True");

            foreach (DataRow row in dt.Rows)
            {
                row["SECILIMI"] = false;
            }

            grdcTaraflar.Refresh();
        }

        private void grdcTaraflar_ButtonTumunuSec(object sender, NavigatorButtonClickEventArgs e)
        {
            DataTable dt = grdcTaraflar.DataSource as DataTable;

            //DataRow[] dRows =  dt.Select("SECILIMI = False");

            foreach (DataRow row in dt.Rows)
            {
                row["SECILIMI"] = true;
            }

            grdcTaraflar.Refresh();
        }

        #endregion Taraf Sorumlu Seçim Buttonlarý

        #region bwSorgula

        private BackgroundWorker bwSorgula = new BackgroundWorker();

        private void bwSorgula_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = GelismisAramaSorgula(); //Sorgula();
        }

        private void bwSorgula_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is List<AvukatProLib.Arama.per_DAVA_HIZLI_ARAMA>)
            {
                List<AvukatProLib.Arama.per_DAVA_HIZLI_ARAMA> liste = e.Result as List<AvukatProLib.Arama.per_DAVA_HIZLI_ARAMA>;

                if (liste.Count == 0)
                {
                    var eskiDosya = DataRepository.AV001_TD_BIL_DUSME_YENILEMEProvider.Find(string.Format("ESKI_DAVA_DOSYA_NO = {0}", EsasNo)).FirstOrDefault();
                    if (eskiDosya != null)
                        liste.Add(BelgeUtil.Inits.context.per_DAVA_HIZLI_ARAMAs.Where(vi => vi.ID == eskiDosya.DAVA_FOY_ID).FirstOrDefault());
                }

                ucDavaBIL_Foy1.MyDataSource = liste;
                if (liste != null)
                    ucDavaBIL_Foy1.DosyaSayisi = liste.GroupBy(vi => vi.ID).Count();
                else
                    ucDavaBIL_Foy1.DosyaSayisi = 0;
            }
            btnSorgula.Text = "Sorgula";
            btnSorgula.Enabled = true;
            btnAramaKriterleriniTemizle2.Enabled = true;
        }

        #endregion bwSorgula

        #region Filtre Metods

        private Dictionary<GridColumn, string> FilitreSozlugu = new Dictionary<GridColumn, string>();
        
        #endregion Filtre Metods

        #region Overriden methods

        #endregion Overriden methods

        #region IslemMethodlari

        public void FoyCikis()
        {
            DialogResult dr = XtraMessageBox.Show("Dava ekraný kapatýlacak. Çýkmak istediðinizden emin misiniz?",
                                                  "Çýkýþ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        public void FoyEditorAc()
        {
            frmEditor editor = new frmEditor();
            editor.MdiParent = mdiAvukatPro.MainForm;
            editor.Show();
        }

        public void FoyTakipAc()
        {
            TakibeGonder();
        }

        public void FoyYenile()
        {
            this.ucDavaBIL_Foy1.gridDavaBIL_Foy.RefreshDataSource();
        }

        public void PdfAc()
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf);
        }

        public void PstAc()
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pst);
        }

        public void WordAc()
        {
            Tools.OpenProgram(ExtensionToOpenProgram.doc);
        }

        public void XlsAc()
        {
            Tools.OpenProgram(ExtensionToOpenProgram.xls);
        }

        public void YeniFoy()
        {
            AdimAdimDavaKaydi.frmDavaDosyaKayitForm frmDavaKaydet = new frmDavaDosyaKayitForm();
            frmDavaKaydet.Show();
        }

        #endregion IslemMethodlari

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tabArama)
            {
                splitContainerControl1.Panel2.Controls.Add(pnTreeList);
            }
            else if (e.Page == tabAsamalar)
            {
                tabAsamalar.Controls.Add(pnTreeList);
            }
        }
    }
}