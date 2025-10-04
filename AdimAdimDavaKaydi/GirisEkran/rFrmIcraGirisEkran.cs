using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AdimAdimDavaKaydi.Forms.Icra;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.UserControls;
using AdimAdimDavaKaydi.Util;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using AdimAdimDavaKaydi.UserControls.ucRapor;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmIcraGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public bool ARamaKapatilcak;
        private BackgroundWorker bckWorker;
        private BackgroundWorker bwSorgula = new BackgroundWorker();
        private int? durum;
        private string EsasNo;
        private string filitre = string.Empty;
        //private int? IslemeKonanDoviz;
        private DateTime? icraKayitT;
        private string Klasor1;
        private string Klasor2;
        private string Konu;
        private int? KrediGrubu;
        private int? KrediTipi;

        //aykut hýzlandýrma 29.01.2013 Ýcra
        //private List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> liste;
        private DataTable liste;
        private int? OzelKod1;
        private int? OzelKod2;
        private int? OzelKod3;
        private int? OzelKod4;
        private string Ref1;
        private string Ref2;
        private string Ref3;
        private int? SorumluAvukat;

        //private int? TarafAdi;
        private int? TahsilatDurumu;

        //private int? TalimatAdliBirim;
        //private int? TalimatAdliye;
        //private string TalimatEsasNo;
        private int? tarafId;

        public rFrmIcraGirisEkran()
        {
            this.Load += rFrmIcraGirisEkran_Load;
        }

        public void AramalarýTemizleGenel()
        {
            //FormlariTemizle(panelControl5.Controls);
            //FormlariTemizle(panelControl7.Controls);
            //FormlariTemizle(grpAlacakNeden.Controls);
            //FormlariTemizle(grpTalimatBilgileri.Controls);
            rgLeyh.SelectedIndex = 2;
            rgDurum.SelectedIndex = 2;
            rgDosyalar.SelectedIndex = 0;
            ucIcraFoy1.MyDataSource = null;
            icraKayitT = null;
            //VadeTarihi = null;
            ucIcraFoy1.FilitreleriTemizle();
            lueDurum2.EditValue = null;
            lueSorumluAvukat2.EditValue = null;
            rgZamanDilimi.SelectedIndex = 6;

            lueDurum2.EditValue = null;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //this.Enabled = false;
            InitializeEvents();
            LookupDoldur();

            bwSorgula.DoWork += bwSorgula_DoWork;
            bwSorgula.RunWorkerCompleted += bwSorgula_RunWorkerCompleted;

            bckWorker = new BackgroundWorker();
            bckWorker.DoWork += delegate
                                    {
                                        #region Merkez Harici Görünmeyecekler (PRATÝK ARAMA - PÝVOT)

                                        if (AvukatProLib.Kimlik.Bilgi != null &&
                                            AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null &&
                                            AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI != "MERKEZ")
                                        {
                                            dockPanel1.Enabled = false;
                                        }

                                        #endregion Merkez Harici Görünmeyecekler (PRATÝK ARAMA - PÝVOT)

                                        //TODO: Burada  Menü Üzerinde bulunan Eventin Týklanýp týklanmadýðýdýný anlayan eventin Çaðrýlmasý ...
                                        //todo: Burada ýcra takip ekraný üzxerinden yeni bir foy kaydedilmiþse etkili olan metot

                                        tlIcraAsamalar.StateImageList = myImageList;

                                        #region Ozellestirme

                                        lblRef1.Text = Kimlikci.Kimlik.IcraReferans.Referans1;
                                        lblRef2.Text = Kimlikci.Kimlik.IcraReferans.Referans2;
                                        lblRef3.Text = Kimlikci.Kimlik.IcraReferans.Referans3;
                                        lblOzelKod1.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod1;
                                        lblOzelKod2.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod2;
                                        lblOzelKod3.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod3;
                                        lblOzelKod4.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod4;
                                        //lblAlacakNedenRef2.Text = Kimlikci.Kimlik.IcraAnReferans.Referans1;
                                        //lblAlacakNedenRef2.Text = Kimlikci.Kimlik.IcraAnReferans.Referans2;

                                        //TARIH         :  29 Eylül 2009 Çarþamba
                                        //KODU YAZAN    :  Mehmet Emin AYDOÐDU
                                        //NEDENI        :   Baþlýklarýn Veri Tabnýndan Alýnmasý
                                        //Mehmet Begin
                                        
                                        //Mehmet End

                                        #endregion Ozellestirme

                                        #region Captionlar

                                        //TARIH         :  08 Eylül 2009 Çarþamba
                                        //KODU YAZAN    :  Mehmet Emin AYDOÐDU
                                        //NEDENI        :  Özel Kodlar ve Referans Baþlýklarýnýn Veri Tabnýndan Alýnmasý
                                        //Mehmet Bas
                                        try
                                        {
                                            foreach (GridColumn item in ucIcraFoy1.gridView1.Columns)
                                            {
                                                if (item.Name.Contains("colREFERANS_NO"))
                                                    item.Caption = Kimlikci.Kimlik.IcraReferans.Referans1;
                                                if (item.Name.Contains("colREFERANS_NO2"))
                                                    item.Caption = Kimlikci.Kimlik.IcraReferans.Referans2;
                                                if (item.Name.Contains("colREFERANS_NO3"))
                                                    item.Caption = Kimlikci.Kimlik.IcraReferans.Referans3;
                                                if (item.Name.Contains("colGOZEL_KOD1"))
                                                    item.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod1;
                                                if (item.Name.Contains("colGOZEL_KOD2"))
                                                    item.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod2;
                                                if (item.Name.Contains("colGOZEL_KOD3"))
                                                    item.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod3;
                                                if (item.Name.Contains("colGOZEL_KOD4"))
                                                    item.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod4;
                                            }

                                            if (ucIcraFoy1.gridView1.Columns["AL_NED_REF1"] != null)
                                                ucIcraFoy1.gridView1.Columns["AL_NED_REF1"].Caption =
                                                    Kimlikci.Kimlik.IcraAnReferans.Referans1;
                                            if (ucIcraFoy1.gridView1.Columns["AL_NED_REF2"] != null)
                                                ucIcraFoy1.gridView1.Columns["AL_NED_REF2"].Caption =
                                                    Kimlikci.Kimlik.IcraAnReferans.Referans2;
                                        }
                                        catch
                                        {
                                        }

                                        if (SorumluAvukat == null)
                                            SorumluAvukat = AvukatProLib.Kimlik.CurrentCariId;
                                        if (durum == null)
                                            durum = (int?)FoyDurum.FAAL;

                                        //spIslemeKonanTutar2.EditValue = null;

                                        #endregion Captionlar

                                        InitsYukle();
                                    };
            bckWorker.RunWorkerCompleted += delegate { this.Enabled = true; };
            bckWorker.RunWorkerAsync();

            this.navGrupAramaSonuclari.Controls.Add(this.ucIcraFoy1);

            //
            // ucIcraFoy1
            //
            this.ucIcraFoy1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIcraFoy1.Location = new System.Drawing.Point(0, 0);

            this.ucIcraFoy1.Name = "ucIcraFoy1";
            this.ucIcraFoy1.Size = new System.Drawing.Size(1015, 210);
            this.ucIcraFoy1.TabIndex = 0;
        }

        private void btnAramaKriterleriniTemizle2_Click(object sender, EventArgs e)
        {
            AramalarýTemizleGenel();

            //xTabDetayArama
            foreach (Control item in xtraTabPage2.Controls)
            {
                if (item is LookUpEdit)
                    ((LookUpEdit)item).EditValue = null;
                else if (item is TextEdit)
                    ((TextEdit)item).Text = "";
                else if (item is DateEdit)
                    ((DateEdit)item).ResetText();
                else if (item is ComboBoxEdit)
                    ((ComboBoxEdit)item).SelectedIndex = -1;
                else if (item is CheckBox)
                    ((CheckBox)item).Checked = false;
                else if (item is CheckEdit)
                    ((CheckEdit)item).Checked = false;
            }

            foreach (Control item in xtraTabPage3.Controls)
            {
                if (item is LookUpEdit)
                    ((LookUpEdit)item).EditValue = null;
                else if (item is TextEdit)
                    ((TextEdit)item).Text = "";
                else if (item is DateEdit)
                    ((DateEdit)item).ResetText();
                else if (item is ComboBoxEdit)
                    ((ComboBoxEdit)item).SelectedIndex = -1;
                else if (item is CheckBox)
                    ((CheckBox)item).Checked = false;
                else if (item is CheckEdit)
                    ((CheckEdit)item).Checked = false;
            }

            lueDurum2.EditValue = null;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            TakipEkraninaGonder();
        }

        /// <summary>
        /// Kullanýlan Sorgulama Buttonu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSorgula_Click(object sender, EventArgs e)
        {
            rgDosyalar_SelectedIndexChanged(sender, e);
            btnSorgula.Enabled = false;
            //GelismisAramaSorgula();
            ucIcraFoy1.gcIcraFoy.Tag = "AV001_TI_BIL_FOY";
            if (!bwSorgula.IsBusy)
            {
                bwSorgula.RunWorkerAsync();
                btnSorgula.Text = "Aranýyor";
                btnSorgula.Enabled = false;
                btnAramaKriterleriniTemizle2.Enabled = false;
            }
            else
            {
                MessageBox.Show("Arama Devam Ediyor");
            }
        }

        private void bwSorgula_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = GelismisAramaSorgulaGetList();
        }

        private void bwSorgula_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tabPivotRapor.PageVisible = true;
            btnSorgula.Text = "Sorgula";
            btnSorgula.Enabled = true;
            btnAramaKriterleriniTemizle2.Enabled = true;
            if (e.Result is DataTable)
            {
                liste = e.Result as DataTable;
                ucIcraFoy1.MyDataSource = liste;
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Ac_Click += rFrmIcraGirisEkran_Button_Ac_Click;
            this.Button_Yeni_Click += rFrmIcraGirisEkran_Button_Yeni_Click;
            this.Button_Editor_Click += rFrmIcraGirisEkran_Button_Editor_Click;
            this.Button_PDF_Click += rFrmIcraGirisEkran_Button_PDF_Click;
            this.Button_Word_Click += rFrmIcraGirisEkran_Button_Word_Click;
            this.Button_Excel_Click += rFrmIcraGirisEkran_Button_Excel_Click;
            this.Button_Outlook_Click += rFrmIcraGirisEkran_Button_Outlook_Click;
        }

        private void InitsYukle()
        {
            BelgeUtil.Inits.perCariAvukatGetir(new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit());
            BelgeUtil.Inits.TemsilSekliGetir(new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit());
            BelgeUtil.Inits.AktifAvukatlariGetir(new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit());
            BelgeUtil.Inits.TarafKoduGetir(new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit());
            BelgeUtil.Inits.KontrolKimGetir(new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit());
        }

        private void LookupDoldur()
        {
            //if (lueIslemeKonanTutarDoviz2.EditValue != null)
            //    lueIslemeKonanTutarDoviz2.EditValue = null;
            //BelgeUtil.Inits.ParaBicimiAyarla(spIslemeKonanTutar2);
            
            //lueIslemeKonanTutarDoviz2.Properties.NullText = "Seç";
            //lueIslemeKonanTutarDoviz2.Enter += delegate { BelgeUtil.Inits.DovizTipGetir(lueIslemeKonanTutarDoviz2); };

            lueAdliye2.Properties.NullText = "Seç";
            lueAdliye2.Enter += delegate { BelgeUtil.Inits.AdliyeGetir(new LookUpEdit[] { lueAdliye2 }); };

            lueTarafAdi2.Enter += delegate { AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueTarafAdi2, null); };
            
            lueSorumluAvukat2.Properties.NullText = "Seç";
            lueSorumluAvukat2.Enter += delegate { BelgeUtil.Inits.SorumluAvukatGetir(lueSorumluAvukat2); };

            lueAdliBirimNo2.Properties.NullText = "Seç";
            lueAdliBirimNo2.Enter += delegate { BelgeUtil.Inits.AdliBirimNoGetir(new LookUpEdit[] { lueAdliBirimNo2 }); };

            lueKonu2.Properties.NullText = "Seç";
            lueKonu2.Enter += delegate { BelgeUtil.Inits.TakipKonusuGetir(lueKonu2); };

            //lueDurum2.Properties.NullText = "Seç";
            //lueDurum2.Enter += delegate { BelgeUtil.Inits.FoyDurumGetir(lueDurum2.Properties); };

            lueKarsiTarafVekili.Properties.NullText = "Seç";
            lueKarsiTarafVekili.Enter += delegate { BelgeUtil.Inits.CariAvukatGetir(lueKarsiTarafVekili.Properties); };

            //lueTalimatAdliye.Properties.NullText = "Seç";
            //lueTalimatAdliye.Enter += delegate
            //                              {
            //                                  BelgeUtil.Inits.AdliyeGetir(new LookUpEdit[] { lueTalimatAdliye });
            //                                  BelgeUtil.Inits.SorumluAvukatGetir(lueSorumluAvukat2);
            //                              };

            //lueTalimalAdliBirimNo2.Properties.NullText = "Seç";
            //lueTalimalAdliBirimNo2.Enter +=
            //    delegate { BelgeUtil.Inits.AdliBirimNoGetir(new LookUpEdit[] { lueTalimalAdliBirimNo2 }); };

            lueOzelKod1_2.Properties.NullText = "Seç";
            lueOzelKod1_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod1_2, 1, Modul.Icra); };

            lueOzelKod2_2.Properties.NullText = "Seç";
            lueOzelKod2_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod2_2, 2, Modul.Icra); };

            lueOzelKod3_2.Properties.NullText = "Seç";
            lueOzelKod3_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod3_2, 3, Modul.Icra); };

            lueOzelKod4_2.Properties.NullText = "Seç";
            lueOzelKod4_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod4_2, 4, Modul.Icra); };

            lueIl.Enter += delegate { AvukatPro.Services.Implementations.DevExpressService.IlDoldur(lueIl); };
        }
        
        private void lueTarafAdi2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTarafAdi2.EditValue != null)
            {
                if (string.IsNullOrEmpty(lueTarafAdi2.EditValue.ToString()))
                    tarafId = null;
                else
                    tarafId = (int?)lueTarafAdi2.EditValue;
            }
            else
                tarafId = null;
        }

        private void rFrmIcraGirisEkran_Button_Ac_Click(object sender, EventArgs e)
        {
            FoyuAc();
        }

        private void rFrmIcraGirisEkran_Button_Editor_Click(object sender, EventArgs e)
        {
            EditoreGonder();
        }

        private void rFrmIcraGirisEkran_Button_Excel_Click(object sender, EventArgs e)
        {
            xlsAc();
        }

        private void rFrmIcraGirisEkran_Button_Outlook_Click(object sender, EventArgs e)
        {
            pstAc();
        }

        private void rFrmIcraGirisEkran_Button_PDF_Click(object sender, EventArgs e)
        {
            PdfAc();
        }

        private void rFrmIcraGirisEkran_Button_Word_Click(object sender, EventArgs e)
        {
            DocAc();
        }

        private void rFrmIcraGirisEkran_Button_Yeni_Click(object sender, EventArgs e)
        {
            YeniFoy();
        }

        private void rFrmIcraGirisEkran_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            //this.BringToFront();
            tabPivotRapor.PageVisible = false;
            GridColumn col = new GridColumn ();
            col.Name = "colESKI_RAF_NO";
            col.FieldName = "ESKI_RAF_NO";
            col.Caption = "Eski Raf No";
            ucIcraFoy1.gridView1.Columns.Add(col);
            this.WindowState = FormWindowState.Maximized;

            lueDurum2.Properties.NullText = "Seç";
            BelgeUtil.Inits.FoyDurumGetir(lueDurum2.Properties);
            lueDurum2.Text = "DERDEST";
        }

        private void rgDosyalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)rgDosyalar.EditValue == 1)
            {
                SorumluAvukat = AvukatProLib.Kimlik.CurrentCariId;
                durum = (int?)FoyDurum.FAAL;
            }
            if ((int)rgDosyalar.EditValue == 2)
            {
                SorumluAvukat = AvukatProLib.Kimlik.CurrentCariId;
                durum = null;
            }
            if ((int)rgDosyalar.EditValue == 3)
            {
                SorumluAvukat = null;
                durum = null;
            }
        }

        //private void txtTalimatEsasNo_TextChanged(object sender, EventArgs e)
        //{
        //    TalimatEsasNo = "%" + txtTalimatEsasNo.Text + "%";
        //    if (txtTalimatEsasNo.Text == string.Empty)
        //        TalimatEsasNo = null;
        //}

        #region UcIcraArama

        //aykut hýzlandýrma 29.01.2013 Ýcra
        //private List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> foyList = null;
        private DataTable foyList = new DataTable ();

        public void GelismisAramaSorgula()
        {
           
        }

        public DataTable GelismisAramaSorgulaGetList()
        {
            try
            {
                int IL = -1;
                int ILCE = -1;
                if (lueIl.EditValue != null)
                    IL = (int)lueIl.EditValue;
                
                if (lueIlce.EditValue != null)
                    ILCE = (int)lueIlce.EditValue;

                durum = null;
                if (lueDurum2.EditValue != null)
                {
                    if (lueDurum2.EditValue != DBNull.Value)
                        durum = (int)lueDurum2.EditValue;
                }

                if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                    foyList = AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_AramaSorgu.GetByFiltreView(null, null, null, AnRef, null, null, tarafId, SorumluAvukat, Banka, Sube, DosyaBirim, DosyaninYeri, DosyDurumu, KrediGrubu, KrediTipi, TahsilatDurumu, Klasor1, Klasor2, Konu, DosyaNo, Ref1, Ref2, Ref3, durum, Adliye, AdliBirimNo, EsasNo, null, OzelKod1, OzelKod2, OzelKod3, OzelKod4, null, null, null, KarsiTarafVekili, null, secim, null, icraKayitT, null, null, AvukatProLib.Kimlik.SirketBilgisi.ConStr, rgLeyh.SelectedIndex, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString(), IL, ILCE, txtAdres.Text);

                else
                    foyList = AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_AramaSorgu.GetByFiltreView(null, null, null, AnRef, null, null, (int?)lueTarafAdi2.EditValue, SorumluAvukat, Banka, Sube, DosyaBirim, DosyaninYeri, DosyDurumu, KrediGrubu, KrediTipi, TahsilatDurumu, Klasor1, Klasor2, Konu, DosyaNo, Ref1, Ref2, Ref3, durum, Adliye, AdliBirimNo, EsasNo, null, OzelKod1, OzelKod2, OzelKod3, OzelKod4, null, null, null, KarsiTarafVekili, null, secim, AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID, icraKayitT, null, null, AvukatProLib.Kimlik.SirketBilgisi.ConStr, rgLeyh.SelectedIndex, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString(), IL, ILCE, txtAdres.Text);

                if (cbxDosyalariHesapla.Checked)
                {
                    if (XtraMessageBox.Show("Seçtiðiniz bu iþlem dosya sayýsýyla orantýlý olarak uzun sürebilir. Devam etmek istediðinize emin misiniz ?", "Uyarý", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        foreach (DataRow foy in foyList.Rows)
                        {
                            try
                            {
                                AV001_TI_BIL_FOY gelenFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)foy["ID"]);
                                AvukatProLib.Hesap.Hesap.Icra hsp = new AvukatProLib.Hesap.Hesap.Icra(gelenFoy, true);
                            }
                            catch 
                            {
                            }
                        }
                        cbxDosyalariHesapla.Checked = false;

                        if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                            foyList = AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_AramaSorgu.GetByFiltreView(null, null, null, AnRef, null, null, tarafId, SorumluAvukat, Banka, Sube, DosyaBirim, DosyaninYeri, DosyDurumu, KrediGrubu, KrediTipi, TahsilatDurumu, Klasor1, Klasor2, Konu, DosyaNo, Ref1, Ref2, Ref3, durum, Adliye, AdliBirimNo, EsasNo, null, OzelKod1, OzelKod2, OzelKod3, OzelKod4, null, null, null, KarsiTarafVekili, null, secim, null, icraKayitT, null, null, AvukatProLib.Kimlik.SirketBilgisi.ConStr, rgLeyh.SelectedIndex, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString(), IL, ILCE, txtAdres.Text);

                        else
                            foyList = AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_AramaSorgu.GetByFiltreView(null, null, null, AnRef, null, null, (int?)lueTarafAdi2.EditValue, SorumluAvukat, Banka, Sube, DosyaBirim, DosyaninYeri, DosyDurumu, KrediGrubu, KrediTipi, TahsilatDurumu, Klasor1, Klasor2, Konu, DosyaNo, Ref1, Ref2, Ref3, durum, Adliye, AdliBirimNo, EsasNo, null, OzelKod1, OzelKod2, OzelKod3, OzelKod4, null, null, null, KarsiTarafVekili, null, secim, AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID, icraKayitT, null, null, AvukatProLib.Kimlik.SirketBilgisi.ConStr, rgLeyh.SelectedIndex, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString(), IL, ILCE, txtAdres.Text);
                    }
                }

                if (foyList == null)
                    return null;

                return foyList;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
                return new DataTable();
            }
        }

        #region Kapandý geliþmiþ Arama
        private int? AdliBirimNo;
        private int? Adliye;
        private string AnRef;
        private int? Banka;
        private int? DosyaBirim;
        private int? DosyaninYeri;
        private string DosyaNo;
        private int? DosyDurumu;
        private int? KarsiTarafVekili;
        private int? Sube;

        private void btnAramaKriterleriniTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(navBarGroupControlContainer1.Controls);
        }
               
        private void dtTarih2_EditValueChanged(object sender, EventArgs e)
        {
            if (dtTarih2.EditValue != string.Empty)
            {
                if (dtTarih2.EditValue != null)
                {
                    icraKayitT = (DateTime)dtTarih2.EditValue;
                }
                else
                    icraKayitT = null;
            }
            else
                icraKayitT = null;
        }

        private void lueAdliBirimNo2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAdliBirimNo2.EditValue != null)
                AdliBirimNo = (int?)lueAdliBirimNo2.EditValue;
            else
                AdliBirimNo = null;
        }

        private void lueAdliye2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAdliye2.EditValue != null)
                Adliye = (int?)lueAdliye2.EditValue;
            else
                Adliye = null;
        }
        
        private void lueDurum2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDurum2.EditValue != null)
                durum = (int?)lueDurum2.EditValue;
            else
                durum = null;
        }

        //void txtSubeKodu2_TextChanged(object sender, EventArgs e)
        //{
        //    subekodu = "%" + txtSubeKodu.Text + "%";

        //}
              

        private void lueKarsiTarafVekili_EditValueChanged(object sender, EventArgs e)
        {
            if (lueKarsiTarafVekili.EditValue != null)
                KarsiTarafVekili = (int?)lueKarsiTarafVekili.EditValue;
            else
                KarsiTarafVekili = null;
        }

        private void lueKonu2_EditValueChanged(object sender, EventArgs e)
        {
            Konu = lueKonu2.Text;
            if (lueKonu2.Text == string.Empty || lueKonu2.Text == "Seç" || lueKonu2.EditValue == null)
                Konu = null;
        }
        
        private void lueOzelKod1_2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOzelKod1_2.EditValue != null)
                OzelKod1 = (int?)lueOzelKod1_2.EditValue;
            else
                OzelKod1 = null;
        }

        private void lueOzelKod2_2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOzelKod2_2.EditValue != null)
                OzelKod2 = (int?)lueOzelKod2_2.EditValue;
            else
                OzelKod2 = null;
        }

        private void lueOzelKod3_2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOzelKod3_2.EditValue != null)
                OzelKod3 = (int?)lueOzelKod3_2.EditValue;
            else
                OzelKod3 = null;
        }

        private void lueOzelKod4_2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOzelKod4_2.EditValue != null)
                OzelKod4 = (int?)lueOzelKod4_2.EditValue;
            else
                OzelKod4 = null;
        }

        private void lueSorumluAvukat2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSorumluAvukat2.EditValue != null)
                SorumluAvukat = (int?)lueSorumluAvukat2.EditValue;
            else
                SorumluAvukat = null;
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
        
        private void txtRef1_2_TextChanged(object sender, EventArgs e)
        {
            Ref1 = txtRef1_2.Text;
            if (txtRef1_2.Text == string.Empty)
                Ref1 = null;
        }

        private void txtRef2_2_TextChanged(object sender, EventArgs e)
        {
            Ref2 = txtRef2_2.Text;
            if (txtRef2_2.Text == string.Empty)
                Ref2 = null;
        }

        private void txtRef3_2_TextChanged(object sender, EventArgs e)
        {
            Ref3 = txtRef3_2.Text;
            if (txtRef3_2.Text == string.Empty)
                Ref3 = null;
        }

        #endregion Kapandý geliþmiþ Arama

        #endregion UcIcraArama

        #region Events

        private _frmIcraTakip icraTakip;

        private bool? secim;

        public void TakipEkraninaGonder()
        {
            try
            {                
                if (xtraTabControl2.SelectedTabPage == tabGelismisArama)
                {
                    List<int> secilenFoySayisi = new List<int>();
                    try
                    {//ucIcraFoy1.MyDataSource
                        //secilenFoyler = ucIcraAramaFoy.GetSelectedFoy();
                        //secilenFoyler = new DataTable();
                        //secilenFoyler = ucIcraFoy1.gridView1.DataSource as DataTable;
                        //secilenFoyler.Clear();
                        for (int i = 0; i < ucIcraFoy1.gridView1.RowCount; i++)
                        {
                            try
                            {
                                if (Convert.ToBoolean(ucIcraFoy1.gridView1.GetRowCellValue(i, "IsSelected")))
                                    secilenFoySayisi.Add(i);
                            }
                            catch 
                            { 
                                                          
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Lütfen takip ekranýna göndermek için dosya seçin.", "Dosya Seçilmedi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (secilenFoySayisi.Count > 0)
                    {
                        if (icraTakip == null || icraTakip.IsDisposed)
                        {
                            icraTakip = new _frmIcraTakip();
                        }
                        //aykut hýzlandýrma 29.01.2013 Ýcra
                        //List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> genel = secilenFoyler;
                        //TList<AV001_TI_BIL_FOY> foyList = new TList<AV001_TI_BIL_FOY>();
                        //foreach (AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama item in genel)
                        //{
                        //    foyList.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(item.ID));
                        //}
                        
                        TList<AV001_TI_BIL_FOY> foyList = new TList<AV001_TI_BIL_FOY>();


                        foreach (int item in secilenFoySayisi)
                        {
                            foyList.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)ucIcraFoy1.gridView1.GetRowCellValue(item, "ID")));
                        }

                        if (frmIntro.AcilisSekli == Kisayol.AcilisSekli.Normal) //(drb == DialogResult.Yes)
                        {
                            icraTakip.Show(foyList);
                            icraTakip.BringToFront();
                            ARamaKapatilcak = true;
                        }
                        else
                        {
                            icraTakip.Show(foyList);
                            icraTakip.BringToFront();
                        }
                    }
                    else
                    {
                        DialogResult dr =
                            XtraMessageBox.Show(
                                "Seçilen kayýt yok. Bütün kayýtlarý açmak istediðinizden emin misiniz?", "Foy Arama",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dr == DialogResult.Yes)
                        {
                            DialogResult drb = XtraMessageBox.Show("Ýcra Arama Ekraný Kapatýlacaktýr..",
                                                                   "Onaylýyor musunuz ? ", MessageBoxButtons.YesNo,
                                                                   MessageBoxIcon.Information);
                            if (drb == DialogResult.Yes)
                            {
                                //TODO: Çalýþýp çalýþmadýðý test edilecek. ( 12/03/2009 YY)
                                //aykut hýzlandýrma 29.01.2013 Ýcra
                                //List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> genel = ucIcraFoy1.MyDataSource;
                                DataTable genel = ucIcraFoy1.MyDataSource;

                                TList<AV001_TI_BIL_FOY> foyList = new TList<AV001_TI_BIL_FOY>();
                                //foreach (AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama item in genel)
                                //{
                                //    foyList.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(item.ID));
                                //}
                                foreach (DataRow item in genel.Rows)
                                {
                                    foyList.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)item["ID"]));
                                }


                                if (icraTakip == null || icraTakip.IsDisposed)
                                {
                                    icraTakip = new _frmIcraTakip();
                                }
                                icraTakip.Show(foyList);
                            }
                            else
                            {
                                //aykut hýzlandýrma 29.01.2013 Ýcra
                                //List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> genel = ucIcraFoy1.MyDataSource;
                                DataTable genel = ucIcraFoy1.MyDataSource;
                                
                                TList<AV001_TI_BIL_FOY> foyList = new TList<AV001_TI_BIL_FOY>();
                                //aykut hýzlandýrma 29.01.2013 Ýcra
                                //foreach (AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama item in genel)
                                //{
                                //    foyList.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(item.ID));
                                //}
                                foreach (DataRow item in genel.Rows)
                                {
                                    foyList.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)item["ID"]));
                                }

                                if (icraTakip == null || icraTakip.IsDisposed)
                                {
                                    icraTakip = new _frmIcraTakip();
                                }
                                icraTakip.Show(foyList);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            AsamaTaraf taraf = (AsamaTaraf)rgTaraf.Properties.Items.GetItemIndexByValue(rgTaraf.SelectedIndex);
            AsamaTur tur = (AsamaTur)rgTur.Properties.Items.GetItemIndexByValue(rgTur.SelectedIndex);
            AramaYap(taraf, tur);
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (!tumuSecili)
            {
                for (int i = 0; i < ucIcraFoy1.gridView1.DataRowCount; i++)
                {
                    var foy = (AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama)ucIcraFoy1.gridView1.GetRow(i);

                    if (foy != null)
                    {
                        foy.IsSelected = true;
                        btnSec.Text = "Seçimi Kaldýr";
                    }
                }

                tumuSecili = true;
            }

            else if (tumuSecili)
            {
                for (int i = 0; i < ucIcraFoy1.gridView1.DataRowCount; i++)
                {
                    AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama foy =
                        (AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama)ucIcraFoy1.gridView1.GetRow(i);

                    if (foy != null)
                    {
                        foy.IsSelected = false;
                        btnSec.Text = "Süzülen Kayýtlarý Seç";
                    }
                }

                tumuSecili = false;
            }
        }

        private void btnSorgula_Click_1(object sender, EventArgs e)
        {
            secilmisAsamalariGetir();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TLIcraSecimleriniDuzenle(chBoxAsamalarTumu.Checked);
        }

        /// <summary>
        /// Durum Seçiminde
        /// Value Deðer
        /// 0 = Tümü
        /// 1 = Bekleyen
        /// 2 = Takiptekiler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rgDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secim = int.Parse(rgDurum.Properties.Items[rgDurum.SelectedIndex].Value.ToString());

            switch (secim)
            {
                case 0:
                    ucIcraFoy1.gridView1.ActiveFilter.Add(ucIcraFoy1.colGDURUM,
                                                          new DevExpress.XtraGrid.Columns.ColumnFilterInfo(""));
                    break;

                case 1:
                    ucIcraFoy1.gridView1.ActiveFilter.Add(ucIcraFoy1.colGDURUM,
                                                          new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                                                              "[DURUM] == EVRAK"));
                    break;

                case 2:
                    ucIcraFoy1.gridView1.ActiveFilter.Add(ucIcraFoy1.colGDURUM,
                                                          new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                                                              "[DURUM] == DERDEST"));
                    break;
                default:
                    break;
            }
        }

        private void rgLeyh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgLeyh.Properties.Items[rgLeyh.SelectedIndex].Value != null)
            {
                if (rgLeyh.Properties.Items[rgLeyh.SelectedIndex].Value == "null")
                {
                    secim = null;
                }
                else
                {
                    secim = Convert.ToBoolean(rgLeyh.Properties.Items[rgLeyh.SelectedIndex].Value);
                }
            }
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            TLIcraSecimleriniDuzenle(false);
            rgDurum.SelectedIndex = 2;
            rgLeyh.SelectedIndex = 2;
            rgDurum_SelectedIndexChanged(rgDurum, new EventArgs());
            rgLeyh_SelectedIndexChanged(rgLeyh, new EventArgs());
            txtArama.Text = string.Empty;

            #region SUBEKONTROLLU VERI CEKME

            if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                    MyDataSourceDeep = null;
                else
                {
                    R_ICRA_GENEL_ARAMAQuery quary = new R_ICRA_GENEL_ARAMAQuery();
                    quary.Append(R_ICRA_GENEL_ARAMAColumn.SUBE_KOD_ID,
                                 AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID.ToString());

                    //MyDataSourceDeep = AvukatProLib2.Data.DataRepository.R_ICRA_GENEL_ARAMAProvider.Find(quary); //(AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);
                }

            #endregion SUBEKONTROLLU VERI CEKME
        }

        private void tlIcraAsamalar_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
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

        private void xtraTabControl2_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tabGelismisArama)
            {
                tabAsamalar.Hide();
            }
        }

        #endregion Events

        #region Properties

        private DataTable _MyDataSourceDeep;

        private TList<AV001_TI_BIL_FOY> foys = new TList<AV001_TI_BIL_FOY>();

        private ImageList myImageList = new ImageList();

        //aykut hýzlandýrma 29.01.2013 Ýcra
        //private List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> secilenFoyler = new List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>();
        private DataTable secilenFoyler = new DataTable();

        private bool tumuSecili;
        //aykut hýzlandýrma 29.01.2013 Ýcra
        public DataTable MyDataSourceDeep
        {
            get { return _MyDataSourceDeep; }
            set
            {
                _MyDataSourceDeep = value;
                ucIcraFoy1.MyDataSource = value;
            }
        }

        #endregion Properties

        #region Methots
        
        private static void FormlariTemizle(Control.ControlCollection coll)
        {
            try
            {
                foreach (Control con in coll)
                {
                    if (con is LookUpEdit)
                    {
                        (con as LookUpEdit).EditValue = null;
                    }
                    else if (con is DateEdit)
                    {
                        (con).ResetText();
                    }

                    else if (con is SpinEdit)
                    {
                        ((SpinEdit)con).EditValue = null;
                    }
                    else if (con is CheckEdit)
                    {
                        ((CheckEdit)con).Checked = false;
                    }
                    else if (con is TextEdit)
                    {
                        con.Text = string.Empty;
                    }
                    else if (con is SearchLookUpEdit)
                        ((SearchLookUpEdit)con).EditValue = null;
                }
            }
            catch 
            {
            }
        }

        private void AramaYap(AsamaTaraf secTaraf, AsamaTur secTur)
        {
            TList<TDIE_KOD_ASAMA> asamaList = new TList<TDIE_KOD_ASAMA>();
            TList<TDIE_KOD_ASAMA_ALT> altAsamaList = new TList<TDIE_KOD_ASAMA_ALT>();

            if (secTur == AsamaTur.AnaAsama)
            {
                if (secTaraf == AsamaTaraf.Karsi)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByTaraf(txtArama.Text, "K");
                }
                else if (secTaraf == AsamaTaraf.Muvekkil)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByTaraf(txtArama.Text, "M");
                }
                else if (secTaraf == AsamaTaraf.Mudurluk)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByMahkemeMi(txtArama.Text, true);
                }

                else if (secTaraf == AsamaTaraf.Tumu)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByTumu(txtArama.Text);
                }
            }

            else if (secTur == AsamaTur.AltAsama)
            {
                if (secTaraf == AsamaTaraf.Karsi)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByTaraf(txtArama.Text, "K");
                }
                else if (secTaraf == AsamaTaraf.Muvekkil)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByTaraf(txtArama.Text, "M");
                }
                else if (secTaraf == AsamaTaraf.Mudurluk)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByMahkemeMi(txtArama.Text, true);
                }
                else if (secTaraf == AsamaTaraf.Tumu)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByTumu(txtArama.Text);
                }
            }

            //AsamaDoldur(asamaList);

            if (asamaList.Count == 0)
            {
                XtraMessageBox.Show("Aradýðýnýz kriterlere uyan aþama bulunamadý.", "Arama Sonucu", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                ucIcraFoy1.MyDataSource = null;
                //ucIcraFoy1.MyDataSource = new List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>();
            }

            tlIcraAsamalar.Nodes.TreeList.ExpandAll();
        }

        /// <summary>
        /// tlIcraAsamalar dan seçilmiþ alanlarý kullanarak iþlem yapar
        /// </summary>
        private void secilmisAsamalariGetir()
        {
            string secilenUstler = string.Empty;
            string secilenlerAltlar = string.Empty;
            for (int i = 0; i < tlIcraAsamalar.Nodes.Count; i++)
            {
                if (tlIcraAsamalar.Nodes[i].Checked)
                {
                    TDIE_KOD_ASAMA ust = tlIcraAsamalar.Nodes[i].Tag as TDIE_KOD_ASAMA;

                    if (ust != null)
                    {
                        secilenUstler += ust.ID + ",";
                    }
                    for (int y = 0; y < tlIcraAsamalar.Nodes[i].Nodes.Count; y++)
                    {
                        if (tlIcraAsamalar.Nodes[i].Nodes[y].Checked)
                        {
                            TDIE_KOD_ASAMA_ALT asamaAlt = tlIcraAsamalar.Nodes[i].Nodes[y].Tag as TDIE_KOD_ASAMA_ALT;
                            if (asamaAlt != null)
                            {
                                secilenlerAltlar += asamaAlt.ID + ",";
                            }
                        }
                    }
                }
            }
            secilenUstler = secilenUstler.TrimEnd(',');
            secilenlerAltlar = secilenlerAltlar.TrimEnd(',');

            // burasý denenecek (gkn)
            int toplamAsamaSayisi = tlIcraAsamalar.Nodes.Count;

            for (int i = 0; i < tlIcraAsamalar.Nodes.Count; i++)
            {
                toplamAsamaSayisi += tlIcraAsamalar.Nodes[i].Nodes.Count;
            }
            int secilenlerToplami = secilenlerAltlar.Split(',').Length + secilenUstler.Split(',').Length;
            if (secilenlerToplami == toplamAsamaSayisi)
            {
                #region SUBEKONTROLLU VERI CEKME

                if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                    if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                        MyDataSourceDeep = null;

                    //AvukatProLib2.Data.DataRepository.R_ICRA_GENEL_ARAMAProvider.GetAll();
                    else
                    {
                        R_ICRA_GENEL_ARAMAQuery quary = new R_ICRA_GENEL_ARAMAQuery();
                        quary.Append(R_ICRA_GENEL_ARAMAColumn.SUBE_KOD_ID,
                                     AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID.ToString());

                        // MyDataSourceDeep = AvukatProLib2.Data.DataRepository.R_ICRA_GENEL_ARAMAProvider.Find(quary); //(AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);
                    }

                #endregion SUBEKONTROLLU VERI CEKME

                return;
            }

            //deneme end (gkn)
            if (secilenUstler.Length > 500 || secilenlerAltlar.Length > 500)
                XtraMessageBox.Show("Çok Fazla Tercih Yapýldý.. Tüm Sonuçlar Dönmeyecek");
            TList<AV001_TI_BIL_FOY> foys = DataRepository.AV001_TI_BIL_FOYProvider.FoyGetirByAsamalar(secilenUstler, secilenlerAltlar);

            //aykut hýzlandýrma 29.01.2013 Ýcra
            //List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> genel = new List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>();

            DataTable genel = new DataTable();
            foreach (AV001_TI_BIL_FOY item in foys)
            {
                R_ICRA_GENEL_ARAMAQuery quary = new R_ICRA_GENEL_ARAMAQuery();
                quary.Append(R_ICRA_GENEL_ARAMAColumn.ID, item.ID.ToString());
            }
            MyDataSourceDeep = genel;

            //DataRepository.AV001_TI_BIL_FOYProvider.FoyGetirByAsamalar(secilenUstler, secilenlerAltlar);
        }

        private void TLIcraSecimleriniDuzenle(bool chck)
        {
            for (int i = 0; i < tlIcraAsamalar.Nodes.Count; i++)
            {
                tlIcraAsamalar.Nodes[i].Checked = chck;
                for (int y = 0; y < tlIcraAsamalar.Nodes[i].Nodes.Count; y++)
                {
                    tlIcraAsamalar.Nodes[i].Nodes[y].Checked = chck;
                }
            }
        }

        #endregion Methots

        #region Enums

        public enum AsamaTaraf
        {
            Muvekkil = 0,
            Mudurluk = 1,
            Karsi = 2,
            Tumu = 3
        }

        public enum AsamaTip
        {
            IslenmisAsama = 0,
            SonrakiAsama = 1
        }

        public enum AsamaTur
        {
            AnaAsama = 0,
            AltAsama = 1
        }

        #endregion Enums

        #region IslemMethodlari

        public void DocAc()
        {
            Tools.OpenProgram(ExtensionToOpenProgram.doc);
        }

        public void EditoreGonder()
        {
            frmEditor frmEdit = new frmEditor();
            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
        }

        public void FoyCikis()
        {
            DialogResult dr = XtraMessageBox.Show("Ýcra ekraný kapatýlacak. Çýkmak istediðinizden emin misiniz?",
                                                  "Çýkýþ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
                this.Close();
            if (dr == DialogResult.No)
                return;
        }

        public void FoyuAc()
        {
            TakipEkraninaGonder();
        }

        public void FoyYenile()
        {
            this.ucIcraFoy1.gcIcraFoy.RefreshDataSource();
        }

        public void PdfAc()
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf);
        }

        public void pstAc()
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pst);
        }

        public void xlsAc()
        {
            Tools.OpenProgram(ExtensionToOpenProgram.xls);
        }

        public void YeniFoy()
        {
            frmIcraDosyaKayit frmIcraDosyaKaydet = new frmIcraDosyaKayit();
            frmIcraDosyaKaydet.Show();
        }

        #endregion IslemMethodlari

        private void xtraTabControl2_Click(object sender, EventArgs e)
        {
            if (xtraTabControl2.SelectedTabPageIndex == 1)
            {
                if (tabPivotRapor.Controls.Count == 0)
                {
                    ucPivotChart pGcIcraRapor = new ucPivotChart();
                    pGcIcraRapor.MyIcraFoy = ucIcraFoy1.MyDataSource;
                    pGcIcraRapor.Dock = DockStyle.Fill;
                    tabPivotRapor.Controls.Add(pGcIcraRapor);
                }
            }
        }

        private void lueIl_EditValueChanged(object sender, EventArgs e)
        {
            if (lueIl.EditValue == null)
                return;

            AvukatPro.Services.Implementations.DevExpressService.IlceDoldur(lueIlce, (int)lueIl.EditValue);
        }
    }
}