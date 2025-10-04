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
using AdimAdimDavaKaydi.Util;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class frmIcraGirisHizliEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmIcraGirisHizliEkran()
        {
            this.Load += rFrmIcraGirisEkran_Load;
        }

        public bool ARamaKapatilcak;
        private BackgroundWorker bckWorker;
        private BackgroundWorker bwSorgula = new BackgroundWorker();

        private int? TalimatAdliBirim;

        private int? TalimatAdliye;

        private string TalimatEsasNo;
        public void AramalarıTemizleGenel()
        {
            FormlariTemizle(panelControl5.Controls);
            FormlariTemizle(panelControl2.Controls);
            FormlariTemizle(panelControl7.Controls);
            FormlariTemizle(grpAlacakNeden.Controls);
            FormlariTemizle(grpTalimatBilgileri.Controls);
            rgLeyh.SelectedIndex = 3;
            rgDurum.SelectedIndex = 3;
            ucIcraFoy1.MyDataSource = MyDataSourceDeep;
            icraKayitT = null;
            VadeTarihi = null;
            ucIcraFoy1.FilitreleriTemizle();
            lueDurum2.EditValue = 2;
            lueSorumluAvukat2.EditValue = null;
        }

        public List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> GelismisAramaSorgula()
        {
            try
            {
                //List<int> tarafIDs = new List<int>();
                //for (int rowHandle = 0; rowHandle < lueTarafAdi2.Properties.View.RowCount; rowHandle++)
                //{
                //    if ((bool)lueTarafAdi2.Properties.View.GetRowCellValue(rowHandle, "IsSelected"))
                //        tarafIDs.Add((int)lueTarafAdi2.Properties.View.GetRowCellValue(rowHandle, "Id"));
                //}

                List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> foyler = null;
                if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                {
                    foyler = AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA_Sorgu.GetByFiltreView(null, DosyaNo, EsasNo, icraKayitT, null, null, Adliye, AdliBirimNo, DosyDurumu, (int?)lueTarafAdi2.EditValue, SorumluAvukat, null, null);
                }
                else
                {
                    foyler = AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA_Sorgu.GetByFiltreView(null, DosyaNo, EsasNo, icraKayitT, null, null, Adliye, AdliBirimNo, DosyDurumu, (int?)lueTarafAdi2.EditValue, SorumluAvukat, null, AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);
                }

                return foyler;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
                return null;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //this.Enabled = false;
            InitializeEvents();
            ucIcraFoy1 = new AdimAdimDavaKaydi.UserControls.ucIcraHizliArama();
            LookupDoldur();

            lueDurum2.EditValue = 2;//Derdest Dosyalar
            rgDosyalar.EditValue = 1;

            bwSorgula.DoWork += bwSorgula_DoWork;
            bwSorgula.RunWorkerCompleted += bwSorgula_RunWorkerCompleted;

            bckWorker = new BackgroundWorker();
            bckWorker.DoWork += delegate
                                    {
                                        #region Merkez Harici Görünmeyecekler (PRATİK ARAMA - PİVOT)

                                        if (AvukatProLib.Kimlik.Bilgi != null &&
                                            AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null &&
                                            AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI != "MERKEZ")
                                        {
                                            dockPanel1.Enabled = false;
                                        }

                                        #endregion Merkez Harici Görünmeyecekler (PRATİK ARAMA - PİVOT)

                                        //TODO: Burada  Menü Üzerinde bulunan Eventin Tıklanıp tıklanmadığıdını anlayan eventin Çağrılması ...
                                        //todo: Burada ıcra takip ekranı üzxerinden yeni bir foy kaydedilmişse etkili olan metot

                                        tlIcraAsamalar.StateImageList = myImageList;

                                        #region Ozellestirme

                                        lblRef1.Text = Kimlikci.Kimlik.IcraReferans.Referans1;
                                        lblRef2.Text = Kimlikci.Kimlik.IcraReferans.Referans2;
                                        lblRef3.Text = Kimlikci.Kimlik.IcraReferans.Referans3;
                                        lblOzelKod1.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod1;
                                        lblOzelKod2.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod2;
                                        lblOzelKod3.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod3;
                                        lblOzelKod4.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod4;
                                        lblAlacakNedenRef2.Text = Kimlikci.Kimlik.IcraAnReferans.Referans1;
                                        lblAlacakNedenRef2.Text = Kimlikci.Kimlik.IcraAnReferans.Referans2;

                                        //TARIH         :  29 Eylül 2009 Çarşamba
                                        //KODU YAZAN    :  Mehmet Emin AYDOĞDU
                                        //NEDENI        :   Başlıkların Veri Tabnından Alınması
                                        //Mehmet Begin
                                        lblBanka.Text = Kimlikci.Kimlik.IcraOzelDurum.Banka;
                                        lblSube.Text = Kimlikci.Kimlik.IcraOzelDurum.Sube;
                                        lblDosyaYeri.Text = Kimlikci.Kimlik.IcraOzelDurum.FoyYeri;
                                        lblDosyaOzelDurum.Text = Kimlikci.Kimlik.IcraOzelDurum.Ozel;
                                        lblDosyaBirim.Text = Kimlikci.Kimlik.IcraOzelDurum.FoyBirim;
                                        lblTahsilatDurum.Text = Kimlikci.Kimlik.IcraOzelDurum.Tahsilat;
                                        lblKrediGrubu.Text = Kimlikci.Kimlik.IcraOzelDurum.KrediGrup;
                                        lblKrediTip.Text = Kimlikci.Kimlik.IcraOzelDurum.KrediTip;
                                        lblKlasor1.Text = Kimlikci.Kimlik.IcraOzelDurum.Klasor1;
                                        lblKlasor2.Text = Kimlikci.Kimlik.IcraOzelDurum.Klasor2;

                                        //Mehmet End

                                        #endregion Ozellestirme

                                        #region Captionlar

                                        //TARIH         :  08 Eylül 2009 Çarşamba
                                        //KODU YAZAN    :  Mehmet Emin AYDOĞDU
                                        //NEDENI        :  Özel Kodlar ve Referans Başlıklarının Veri Tabnından Alınması
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

                                        spIslemeKonanTutar2.EditValue = null;

                                        #endregion Captionlar

                                        InitsYukle();
                                    };
            bckWorker.RunWorkerCompleted += delegate { this.Enabled = true; };
            bckWorker.RunWorkerAsync();

            this.navGrupAramaSonuclari.Controls.Add(this.ucIcraFoy1);

            //
            // ucIcraFoy1
            //
            this.ucIcraFoy1.AltToplamlarAktif = false;
            this.ucIcraFoy1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIcraFoy1.Location = new System.Drawing.Point(0, 0);

            this.ucIcraFoy1.Name = "ucIcraFoy1";
            this.ucIcraFoy1.Size = new System.Drawing.Size(1015, 210);
            this.ucIcraFoy1.TabIndex = 0;
        }

        private void btnAramaKriterleriniTemizle2_Click(object sender, EventArgs e)
        {
            AramalarıTemizleGenel();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            TakipEkraninaGonder();
        }

        /// <summary>
        /// Kullanılan Sorgulama Buttonu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSorgula_Click(object sender, EventArgs e)
        {
            //GelismisAramaSorgula();
            if (!bwSorgula.IsBusy)
            {
                ucIcraFoy1.AltToplamlarAktif = cBoxAltToplam.Checked;

                bwSorgula.RunWorkerAsync();
                btnSorgula.Text = "Aranıyor";
                btnSorgula.Enabled = false;
                btnAramaKriterleriniTemizle2.Enabled = false;
                cBoxAltToplam.Enabled = false;
            }
            else
            {
                MessageBox.Show("Arama Devam Ediyor");
            }
        }

        private void bwSorgula_DoWork(object sender, DoWorkEventArgs e)
        {
            //e.Result = GelismisAramaSorgulaGetList();
            e.Result = GelismisAramaSorgula();
        }

        private void bwSorgula_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA>)
            {
                List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> liste = e.Result as List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA>;

                if (liste.Count == 0)
                {
                    var eskiDosya = DataRepository.AV001_TI_BIL_DUSME_YENILEMEProvider.Find(string.Format("ESKI_ICRA_DOSYA_NO = {0}", EsasNo)).FirstOrDefault();

                    if (eskiDosya != null)
                        liste.Add(BelgeUtil.Inits.context.per_ICRA_HIZLI_ARAMAs.Where(vi => vi.ID == eskiDosya.ICRA_FOY_ID.Value).FirstOrDefault());
                }

                ucIcraFoy1.MyDataSource = liste;
                if (liste != null)
                    ucIcraFoy1.DosyaSayisi = liste.GroupBy(vi => vi.ID).Count();
                else
                    ucIcraFoy1.DosyaSayisi = 0;
            }

            btnSorgula.Text = "Sorgula";
            btnSorgula.Enabled = true;
            btnAramaKriterleriniTemizle2.Enabled = true;
            cBoxAltToplam.Enabled = true;

            //TaraflariDoldur();
            //SorumlulariDoldur();
        }

        private void cBoxAltToplam_CheckedChanged(object sender, EventArgs e)
        {
            ucIcraFoy1.AltToplamlarAktif = cBoxAltToplam.Checked;
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
            if (lueIslemeKonanTutarDoviz2.EditValue != null)
                lueIslemeKonanTutarDoviz2.EditValue = null;
            BelgeUtil.Inits.ParaBicimiAyarla(spIslemeKonanTutar2);

            lueSube2.Properties.NullText = "Seç";
            lueSube2.Enter += delegate { BelgeUtil.Inits.BankaSubeGetir(new LookUpEdit[] { lueSube2 }); };

            lueDosyaninYeri2.Properties.NullText = "Seç";
            lueDosyaninYeri2.Enter += delegate { BelgeUtil.Inits.FoyYeriGetir(lueDosyaninYeri2); };

            lueDosyDurumu2.Properties.NullText = "Seç";
            lueDosyDurumu2.Enter += delegate { BelgeUtil.Inits.FoyOzelDurumGetir(new LookUpEdit[] { lueDosyDurumu2 }); };

            lueDosyaBirim2.Properties.NullText = "Seç";
            lueDosyaBirim2.Enter += delegate { BelgeUtil.Inits.FoyBirimGetirEdit(lueDosyaBirim2); };

            lueTahsilatDurumu2.Properties.NullText = "Seç";
            lueTahsilatDurumu2.Enter += delegate { BelgeUtil.Inits.TahsilatdurumGetir(lueTahsilatDurumu2); };

            lueKrediGrubu2.Properties.NullText = "Seç";
            lueKrediGrubu2.Enter += delegate { BelgeUtil.Inits.KrediGrubuGetir(new LookUpEdit[] { lueKrediGrubu2 }); };

            lueKrediTipi2.Properties.NullText = "Seç";
            lueKrediTipi2.Enter += delegate { BelgeUtil.Inits.KrediTipiGetir(new LookUpEdit[] { lueKrediTipi2 }); };

            lueIslemeKonanTutarDoviz2.Properties.NullText = "Seç";
            lueIslemeKonanTutarDoviz2.Enter += delegate { BelgeUtil.Inits.DovizTipGetir(lueIslemeKonanTutarDoviz2); };

            lueAdliye2.Properties.NullText = "Seç";
            lueAdliye2.Enter += delegate { BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliye2); };

            lueTarafAdi2.Enter += delegate { AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueTarafAdi2, null); };

            lueBanka2.Properties.NullText = "Seç";
            lueBanka2.Enter += delegate { BelgeUtil.Inits.BankaGetir(new LookUpEdit[] { lueBanka2 }); };

            lueSorumluAvukat2.Properties.NullText = "Seç";
            lueSorumluAvukat2.Enter += delegate { BelgeUtil.Inits.SorumluAvukatGetir(lueSorumluAvukat2); };

            lueAdliBirimNo2.Properties.NullText = "Seç";
            lueAdliBirimNo2.Enter += delegate { BelgeUtil.Inits.AdliBirimNoGetir(new LookUpEdit[] { lueAdliBirimNo2 }); };

            lueKonu2.Properties.NullText = "Seç";
            lueKonu2.Enter += delegate { BelgeUtil.Inits.TakipKonusuGetir(lueKonu2); };

            lueDurum2.Properties.NullText = "Seç";
            /*lueDurum2.Enter += delegate {*/
            BelgeUtil.Inits.FoyDurumGetir(lueDurum2.Properties);/* };*/

            lueKarsiTarafVekili.Properties.NullText = "Seç";
            lueKarsiTarafVekili.Enter += delegate { BelgeUtil.Inits.CariAvukatGetir(lueKarsiTarafVekili.Properties); };

            lueTalimatAdliye.Properties.NullText = "Seç";
            lueTalimatAdliye.Enter += delegate
                                          {
                                              BelgeUtil.Inits.AdliyeGetir(new LookUpEdit[] { lueTalimatAdliye });
                                              BelgeUtil.Inits.SorumluAvukatGetir(lueSorumluAvukat2);
                                          };

            lueTalimalAdliBirimNo2.Properties.NullText = "Seç";
            lueTalimalAdliBirimNo2.Enter +=
                delegate { BelgeUtil.Inits.AdliBirimNoGetir(new LookUpEdit[] { lueTalimalAdliBirimNo2 }); };

            lueOzelKod1_2.Properties.NullText = "Seç";
            lueOzelKod1_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod1_2, 1, Modul.Icra); };

            lueOzelKod2_2.Properties.NullText = "Seç";
            lueOzelKod2_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod2_2, 2, Modul.Icra); };

            lueOzelKod3_2.Properties.NullText = "Seç";
            lueOzelKod3_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod3_2, 3, Modul.Icra); };

            lueOzelKod4_2.Properties.NullText = "Seç";
            lueOzelKod4_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod4_2, 4, Modul.Icra); };
        }

        private void lueTalimalAdliBirimNo2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTalimalAdliBirimNo2.EditValue != null)
                TalimatAdliBirim = (int?)lueTalimalAdliBirimNo2.EditValue;
            else
                TalimatAdliBirim = null;
        }

        private void lueTalimatAdliye_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTalimatAdliye.EditValue != null)
                TalimatAdliye = (int?)lueTalimatAdliye.EditValue;
            else
                TalimatAdliye = null;
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            btnSorgula.Enabled = false;
            btnAramaKriterleriniTemizle2.Enabled = false;

            btnSorgula.Text = "Aranıyor";
            if (!bwSorgula.IsBusy)
                bwSorgula.RunWorkerAsync();
        }

        private void txtTalimatEsasNo_TextChanged(object sender, EventArgs e)
        {
            TalimatEsasNo = "%" + txtTalimatEsasNo.Text + "%";
            if (txtTalimatEsasNo.Text == string.Empty)
                TalimatEsasNo = null;
        }
        
        #region UcIcraArama

        private string filitre = string.Empty;

        public DataTable GelismisAramaSorgulaGetList()
        {
            try
            {
#if tmpTOTALOZEL
                if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI != "MERKEZ")
                {
                    Ref2 = AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI;
                }
#endif

                //aykut hızlandırma 29.01.2013 İcra
                //List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> foyList = null;
                DataTable foyList = new DataTable();
                if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                    foyList = AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_AramaSorgu.GetByFiltreView(DigerAlacakNedeni, IslemeKonanDoviz, Tutar, AnRef, AnRef2, VadeTarihi, (int?)lueTarafAdi2.EditValue, SorumluAvukat, Banka, Sube, DosyaBirim, DosyaninYeri, DosyDurumu, KrediGrubu, KrediTipi, TahsilatDurumu, Klasor1, Klasor2, Konu, DosyaNo, Ref1, Ref2, Ref3, durum, Adliye, AdliBirimNo, EsasNo, null, OzelKod1, OzelKod2, OzelKod3, OzelKod4, null, TalimatAdliye, TalimatAdliBirim, KarsiTarafVekili, TalimatEsasNo, secim, null, icraKayitT, null, null, AvukatProLib.Kimlik.SirketBilgisi.ConStr, rgLeyh.SelectedIndex, "Tumu", -1, -1, "");

                else
                    foyList = AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_AramaSorgu.GetByFiltreView(DigerAlacakNedeni, IslemeKonanDoviz, Tutar, AnRef, AnRef2, VadeTarihi, (int?)lueTarafAdi2.EditValue, SorumluAvukat, Banka, Sube, DosyaBirim, DosyaninYeri, DosyDurumu, KrediGrubu, KrediTipi, TahsilatDurumu, Klasor1, Klasor2, Konu, DosyaNo, Ref1, Ref2, Ref3, durum, Adliye, AdliBirimNo, EsasNo, null, OzelKod1, OzelKod2, OzelKod3, OzelKod4, null, TalimatAdliye, TalimatAdliBirim, KarsiTarafVekili, TalimatEsasNo, secim, AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID, icraKayitT, null, null, AvukatProLib.Kimlik.SirketBilgisi.ConStr, rgLeyh.SelectedIndex, "Tumu", -1, -1 , "");

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

        #region Kapandı gelişmiş Arama

        private int? AdliBirimNo;
        private int? Adliye;
        private string AnRef;
        private string AnRef2;
        private int? Banka;
        private string DigerAlacakNedeni;
        private int? DosyaBirim;
        private int? DosyaninYeri;
        private string DosyaNo;
        private int? DosyDurumu;
        private int? durum;

        private string EsasNo;

        //}
        private int? IslemeKonanDoviz;

        private DateTime? icraKayitT;

        private int? KarsiTarafVekili;

        private string Klasor1;

        private string Klasor2;

        //int? Konu;
        //void lueKonu2_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueKonu2.EditValue != null)
        //        Konu = (int?)lueKonu2.EditValue;
        //    else
        //        Konu = null;
        //}
        private string Konu;

        private int? KrediGrubu;

        private int? KrediTipi;

        private int? OzelKod1;

        private int? OzelKod2;

        private int? OzelKod3;

        private int? OzelKod4;

        private string Ref1;

        private string Ref2;

        private string Ref3;

        private int? SorumluAvukat;

        private int? Sube;

        private int? TahsilatDurumu;

        private decimal? Tutar;

        private DateTime? VadeTarihi;

        private void btnAramaKriterleriniTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(navBarGroupControlContainer1.Controls);
        }

        private void dateVadeTarih2_EditValueChanged(object sender, EventArgs e)
        {
            if (dateVadeTarih2.EditValue != string.Empty)
            {
                if (dateVadeTarih2.EditValue != null)
                    VadeTarihi = (DateTime?)dateVadeTarih2.EditValue;
                else
                    VadeTarihi = null;
            }
            else
                VadeTarihi = null;
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

        private void lueBanka2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBanka2.EditValue != null)
                Banka = (int?)lueBanka2.EditValue;
            else
                Banka = null;
        }

        private void lueDosyaBirim2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDosyaBirim2.EditValue != null)
                DosyaBirim = (int?)lueDosyaBirim2.EditValue;
            else
                DosyaBirim = null;
        }

        private void lueDosyaninYeri2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDosyaninYeri2.EditValue != null)
                DosyaninYeri = (int?)lueDosyaninYeri2.EditValue;
            else
                DosyaninYeri = null;
        }

        private void lueDosyDurumu2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDosyDurumu2.EditValue != null)
                DosyDurumu = (int?)lueDosyDurumu2.EditValue;
            else
                DosyDurumu = null;
        }

        private void lueDurum2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDurum2.EditValue != null)
                DosyDurumu = (int?)lueDurum2.EditValue;
            else
                DosyDurumu = null;
        }

        //void txtSubeKodu2_TextChanged(object sender, EventArgs e)
        //{
        //    subekodu = "%" + txtSubeKodu.Text + "%";
        private void lueIslemeKonanTutarDoviz2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueIslemeKonanTutarDoviz2.EditValue != null)
                IslemeKonanDoviz = (int?)lueIslemeKonanTutarDoviz2.EditValue;
            else
                IslemeKonanDoviz = null;
        }

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

        private void lueKrediGrubu2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueKrediGrubu2.EditValue != null)
                KrediGrubu = (int?)lueKrediGrubu2.EditValue;
            else
                KrediGrubu = null;
        }

        private void lueKrediTipi2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueKrediTipi2.EditValue != null)
                KrediTipi = (int?)lueKrediTipi2.EditValue;
            else
                KrediTipi = null;
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

        private void lueSube2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSube2.EditValue != null)
                Sube = (int?)lueSube2.EditValue;
            else
                Sube = null;
        }

        //private void lueTarafAdi2_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueTarafAdi2.EditValue != null)
        //        TarafAdi = (int?)lueTarafAdi2.EditValue;
        //    else
        //        TarafAdi = null;
        //}
        private void lueTahsilatDurumu2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTahsilatDurumu2.EditValue != null)
                TahsilatDurumu = (int?)lueTahsilatDurumu2.EditValue;
            else
                TahsilatDurumu = null;
        }

        private void spIslemeKonanTutar2_EditValueChanged(object sender, EventArgs e)
        {
            Tutar = (decimal?)spIslemeKonanTutar2.EditValue;
        }

        private void txtAnRef1_2_TextChanged(object sender, EventArgs e)
        {
            AnRef = txtAnRef1_2.Text;
            if (txtAnRef1_2.Text == string.Empty)
                AnRef = null;
        }

        private void txtAnRef2_2_TextChanged(object sender, EventArgs e)
        {
            AnRef2 = txtAnRef2_2.Text;
            if (txtAnRef2_2.Text == string.Empty)
                AnRef2 = null;
        }

        //private int? TarafAdi;
        private void txtDigerAlacakNedeni2_TextChanged(object sender, EventArgs e)
        {
            DigerAlacakNedeni = txtDigerAlacakNedeni2.Text;
            if (txtDigerAlacakNedeni2.Text == string.Empty)
                DigerAlacakNedeni = null;
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

        private void txtKlasor1_2_TextChanged(object sender, EventArgs e)
        {
            Klasor1 = txtKlasor1_2.Text;
            if (txtKlasor1_2.Text == string.Empty)
                Klasor1 = null;
        }

        private void txtKlasor2_2_TextChanged(object sender, EventArgs e)
        {
            Klasor2 = txtKlasor2_2.Text;
            if (txtKlasor2_2.Text == string.Empty)
                Klasor2 = null;
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

        #endregion Kapandı gelişmiş Arama

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
                    try
                    {
                        //secilenFoyler = ucIcraFoy1.GetSelectedFoy(ucIcraFoy1.MyDataSource);
                    }
                    catch
                    {
                        MessageBox.Show("Lütfen takip ekranına göndermek için dosya seçin.", "Dosya Seçilmedi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (secilenFoyler.Count > 0)
                    {
                        if (icraTakip == null || icraTakip.IsDisposed)
                        {
                            icraTakip = new _frmIcraTakip();
                        }
                        List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> genel = secilenFoyler;
                        TList<AV001_TI_BIL_FOY> foyList = new TList<AV001_TI_BIL_FOY>();
                        foreach (AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama item in genel)
                        {
                            foyList.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(item.ID));
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
                                "Seçilen kayıt yok. Bütün kayıtları açmak istediğinizden emin misiniz?", "Foy Arama",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dr == DialogResult.Yes)
                        {
                            DialogResult drb = XtraMessageBox.Show("İcra Arama Ekranı Kapatılacaktır..",
                                                                   "Onaylıyor musunuz ? ", MessageBoxButtons.YesNo,
                                                                   MessageBoxIcon.Information);
                            if (drb == DialogResult.Yes)
                            {
                                //TODO: Çalışıp çalışmadığı test edilecek. ( 12/03/2009 YY)
                                List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> genel = ucIcraFoy1.MyDataSource;

                                TList<AV001_TI_BIL_FOY> foyList = new TList<AV001_TI_BIL_FOY>();
                                foreach (AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA item in genel)
                                {
                                    foyList.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(item.ID));
                                }
                                if (icraTakip == null || icraTakip.IsDisposed)
                                {
                                    icraTakip = new _frmIcraTakip();
                                }
                                icraTakip.Show(foyList);
                            }
                            else
                            {
                                List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> genel = ucIcraFoy1.MyDataSource;
                                ;
                                TList<AV001_TI_BIL_FOY> foyList = new TList<AV001_TI_BIL_FOY>();
                                foreach (AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA item in genel)
                                {
                                    foyList.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(item.ID));
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
                        btnSec.Text = "Seçimi Kaldır";
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
                        btnSec.Text = "Süzülen Kayıtları Seç";
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
        /// Value Değer
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
                    ucIcraFoy1.gridView1.ActiveFilter.Add(ucIcraFoy1.gridColumn3,
                                                          new DevExpress.XtraGrid.Columns.ColumnFilterInfo(""));
                    break;

                case 1:
                    ucIcraFoy1.gridView1.ActiveFilter.Add(ucIcraFoy1.gridColumn3,
                                                          new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                                                              "[DURUM] == EVRAK"));
                    break;

                case 2:
                    ucIcraFoy1.gridView1.ActiveFilter.Add(ucIcraFoy1.gridColumn3,
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

        private List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> _MyDataSourceDeep;

        private TList<AV001_TI_BIL_FOY> foys = new TList<AV001_TI_BIL_FOY>();

        private ImageList myImageList = new ImageList();

        private List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> secilenFoyler =
            new List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>();

        private bool tumuSecili;

        public List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> MyDataSourceDeep
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
                XtraMessageBox.Show("Aradığınız kriterlere uyan aşama bulunamadı.", "Arama Sonucu", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                ucIcraFoy1.MyDataSource = null;
                ucIcraFoy1.MyDataSource = new List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA>();
            }

            tlIcraAsamalar.Nodes.TreeList.ExpandAll();
        }

        /// <summary>
        /// tlIcraAsamalar dan seçilmiş alanları kullanarak işlem yapar
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

            // burası denenecek (gkn)
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
                XtraMessageBox.Show("Çok Fazla Tercih Yapıldı.. Tüm Sonuçlar Dönmeyecek");
            TList<AV001_TI_BIL_FOY> foys = DataRepository.AV001_TI_BIL_FOYProvider.FoyGetirByAsamalar(secilenUstler,
                                                                                                      secilenlerAltlar);
            List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> genel = new List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA>();
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
            DialogResult dr = XtraMessageBox.Show("İcra ekranı kapatılacak. Çıkmak istediğinizden emin misiniz?",
                                                  "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
    }
}