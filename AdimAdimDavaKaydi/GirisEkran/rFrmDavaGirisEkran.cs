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

    public partial class rFrmDavaGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public static List<AV001_TD_BIL_FOY> tempDava;
        private DataTable _MyDataSourceDeep;
        private BackgroundWorker bckWorker;
        private BackgroundWorker bwLoad = new BackgroundWorker();

        private frmDavaTakip frmDavaTakipEkran;

        private VList<DAVA_PRATIK_ARAMA> MyDataSourcePratik = new VList<DAVA_PRATIK_ARAMA>();

        private ImageList myImageList = new ImageList();

        private bool? secim;

        private decimal? Tutar;

        public rFrmDavaGirisEkran()
        {
            this.Load += rFrmDavaGirisEkran_Load;
        }

        public DataTable MyDataSourceDeep
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
            //FormTools.FormlariTemizle(panelControl5.Controls);
            //FormTools.FormlariTemizle(panelControl4.Controls);
            //FormTools.FormlariTemizle(grpAlacakNeden.Controls);
            //FormTools.FormlariTemizle(panelControl9.Controls);
            //FormTools.FormlariTemizle(panelControl8.Controls);
            rgLeyh.SelectedIndex = 3;
            rgDurum.SelectedIndex = 3;
            secim = null;
            ucDavaBIL_Foy1.MyDataSource = MyDataSourceDeep;
            ucDavaBIL_Foy1.FilitreleriTemizle();
            lueSorumluAvukat2.EditValue = null;
            lueDurum2.EditValue = null;
            rgZamanDilimi.SelectedIndex = 6;
        }

        public DataTable GelismisAramaSorgula()
        {
            //if (Sorumlu == null && Durum == null)
            //    XtraMessageBox.Show("Tüm Kullanýcýlara Göre Aramayý Seçtiniz Bu Ýþlem Biraz Uzun Sürebilir", "Uyarý",
            //                        MessageBoxButtons.OK);

            if (lueDurum2.EditValue != null)
                Durum = (int)lueDurum2.EditValue;

            try
            {
                DataTable foyList = null;
                if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                {
                    foyList = AvukatProLib.Arama.R_DAVA_GENEL_ARAMASorgu.GetByFiltreView(Cari, Sorumlu, Banka, Sube, FoyBirim, FoyYeri, OzelDurum, KrediGrubu, KrediTipi, TahsilatDurumu, Klasor1, Klasor2, DavaNedeni, DovizId, Tutar, DnRef1, DnRef2, VadeTarihi, DavaKonusu, DosyaNo, Ref1, Ref2, Ref3, Durum, Tarih, Adliye, AdliBirimNo, Gorev, EsasNo, OzelKod1, OzelKod2, OzelKod3, OzelKod4, KarsiTarafVekil, secim, null, DurusmaTarih, KesifTarih, AvukatProLib.Kimlik.SirketBilgisi.ConStr, rgLeyh.SelectedIndex, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString(), txtKararNo.Text, dateKararTarihi.EditValue);
                }
                else
                {
                    foyList = AvukatProLib.Arama.R_DAVA_GENEL_ARAMASorgu.GetByFiltreView(Cari, Sorumlu, Banka, Sube, FoyBirim, FoyYeri, OzelDurum, KrediGrubu, KrediTipi, TahsilatDurumu, Klasor1, Klasor2, DavaNedeni, DovizId, Tutar, DnRef1, DnRef2, VadeTarihi, DavaKonusu, DosyaNo, Ref1, Ref2, Ref3, Durum, Tarih, Adliye, AdliBirimNo, Gorev, EsasNo, OzelKod1, OzelKod2, OzelKod3, OzelKod4, KarsiTarafVekil, secim, AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID, DurusmaTarih, KesifTarih, AvukatProLib.Kimlik.SirketBilgisi.ConStr, rgLeyh.SelectedIndex, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString(), txtKararNo.Text, dateKararTarihi.EditValue);
                }

                if (foyList == null)
                    return null;
                return foyList;
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

                    //tempDava = ucDavaBIL_Foy1.MyDataSource;
                    TList<AV001_TD_BIL_FOY> foyList = new TList<AV001_TD_BIL_FOY>();
                    foreach (DataRow item in ucDavaBIL_Foy1.MyDataSource.Rows)
                    {
                        foyList.Add(DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)item["ID"]));
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
            this.ucDavaBIL_Foy1 = new AdimAdimDavaKaydi.UserControls.ucDavaAramaFoy();

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

                                        if (Kimlikci.Kimlik.DavaReferans.Referans1 != null)
                                            lblRef1.Text = Kimlikci.Kimlik.DavaReferans.Referans1;

                                        if (Kimlikci.Kimlik.DavaReferans.Referans2 != null)
                                            lblRef2.Text = Kimlikci.Kimlik.DavaReferans.Referans2;

                                        if (Kimlikci.Kimlik.DavaReferans.Referans3 != null)
                                            lblRef3.Text = Kimlikci.Kimlik.DavaReferans.Referans3;

                                        if (Kimlikci.Kimlik.DavaOzelKod.OzelKod1 != null)
                                            lblOzelKod1.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod1;

                                        if (Kimlikci.Kimlik.DavaOzelKod.OzelKod2 != null)
                                            lblOzelKod2.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod2;

                                        if (Kimlikci.Kimlik.DavaOzelKod.OzelKod3 != null)
                                            lblOzelKod3.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod3;

                                        if (Kimlikci.Kimlik.DavaOzelKod.OzelKod4 != null)
                                            lblOzelKod4.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod4;

                                        //if (Kimlikci.Kimlik.DavaDnReferans.Referans1 != null)
                                        //    lblDavaNdnRef1.Text = Kimlikci.Kimlik.DavaDnReferans.Referans1;

                                        //if (Kimlikci.Kimlik.DavaDnReferans.Referans2 != null)
                                        //    lblDavaNedenRef2.Text = Kimlikci.Kimlik.DavaDnReferans.Referans2;

                                        //TARIH         :  29 Eylül 2009 Salý
                                        //KODU YAZAN    :  Mehmet Emin AYDOÐDU
                                        //NEDENI        :   Baþlýklarýn Veri Tabnýndan Alýnmasý
                                        //Mehmet Begin
                                        //lblBanka.Text = Kimlikci.Kimlik.OrtakOzelDurum.Banka;
                                        //lblDosyaOzelDurum.Text = Kimlikci.Kimlik.OrtakOzelDurum.Ozel;
                                        //lblSube.Text = Kimlikci.Kimlik.OrtakOzelDurum.Sube;
                                        //lblDosyaYeri.Text = Kimlikci.Kimlik.OrtakOzelDurum.FoyYeri;
                                        //lblDosyaBirim.Text = Kimlikci.Kimlik.OrtakOzelDurum.FoyBirim;
                                        //lblTahsilatDurum.Text = Kimlikci.Kimlik.OrtakOzelDurum.Tahsilat;
                                        //lblKrediGrubu.Text = Kimlikci.Kimlik.OrtakOzelDurum.KrediGrup;
                                        //lblKrediTipi.Text = Kimlikci.Kimlik.OrtakOzelDurum.KrediTip;
                                        //lblKlasor1.Text = Kimlikci.Kimlik.OrtakOzelDurum.Klasor1;
                                        //lblKlasor2.Text = Kimlikci.Kimlik.OrtakOzelDurum.Klasor2;
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

                                        //spDavaEdilenTutar.EditValue = null;
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

            //xTabDetayArama
            foreach (Control item in xTabGenelArama.Controls)
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

            foreach (Control item in xTabDetayArama.Controls)
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
            rgDurum.SelectedIndex = 2;
            rgLeyh.SelectedIndex = 2;
            rgDurum_SelectedIndexChanged(rgDurum, new EventArgs());
            rgLeyh_SelectedIndexChanged(rgLeyh, new EventArgs());
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
            rgDurum.SelectedIndexChanged += rgDurum_SelectedIndexChanged;
            rgLeyh.SelectedIndexChanged += rgLeyh_SelectedIndexChanged;
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

            //lueSube2.EditValueChanged += lueSube2_EditValueChanged;
            //lueDosyaBirim2.EditValueChanged += lueDosyaBirim2_EditValueChanged;
            //lueDosyaninYeri2.EditValueChanged += lueDosyaninYeri2_EditValueChanged;
            //lueDosyDurumu2.EditValueChanged += lueDosyDurumu2_EditValueChanged;
            //lueKrediGrubu2.EditValueChanged += lueKrediGrubu2_EditValueChanged;
            //lueKrediTipi2.EditValueChanged += lueKrediTipi2_EditValueChanged;
            //lueTahsilatDurumu2.EditValueChanged += lueTahsilatDurumu2_EditValueChanged;
            //txtKlasor1_2.TextChanged += txtKlasor1_2_TextChanged;
            //txtKlasor2_2.TextChanged += txtKlasor2_2_TextChanged;
            //txtDigerDavaNedeni2.TextChanged += txtDigerDavaNedeni2_TextChanged;
            //lueDavaEdilenTYutarDOVIZID.EditValueChanged += lueDavaEdilenTYutarDOVIZID_EditValueChanged;
            //txtDavaNedenRef2_1.TextChanged += txtDavaNedenRef2_1_TextChanged;
            //txtDavaNedenRef2_2.TextChanged += txtDavaNedenRef2_2_TextChanged;
            //dateVadeTarih2.EditValueChanged += dateVadeTarih2_EditValueChanged;

            #endregion AramaEvents
        }

        private void InitsData()
        {
            //lueDosyaBirim2.EditValue = null;
            lueGorev2.Properties.NullText = "Seç";
            lueGorev2.Enter += delegate { BelgeUtil.Inits.AdliBirimGorevGetir(lueGorev2); };

            //lueSube2.Properties.NullText = "Seç";
            //lueSube2.Enter += delegate { BelgeUtil.Inits.BankaSubeGetir(new LookUpEdit[] { lueSube2 }); };

            //lueDosyaninYeri2.Properties.NullText = "Seç";
            //lueDosyaninYeri2.Enter += delegate { BelgeUtil.Inits.FoyYeriGetir(lueDosyaninYeri2); };

            //lueDosyDurumu2.Properties.NullText = "Seç";
            //lueDosyDurumu2.Enter += delegate { BelgeUtil.Inits.FoyOzelDurumGetir(new LookUpEdit[] { lueDosyDurumu2 }); };

            //lueDosyaBirim2.Properties.NullText = "Seç";
            //lueDosyaBirim2.Enter += delegate { BelgeUtil.Inits.FoyBirimGetirEdit(lueDosyaBirim2); };

            //lueTahsilatDurumu2.Properties.NullText = "Seç";
            //lueTahsilatDurumu2.Enter += delegate { BelgeUtil.Inits.TahsilatdurumGetir(lueTahsilatDurumu2); };

            //lueKrediGrubu2.Properties.NullText = "Seç";
            //lueKrediGrubu2.Enter += delegate { BelgeUtil.Inits.KrediGrubuGetir(new LookUpEdit[] { lueKrediGrubu2 }); };

            //lueKrediTipi2.Properties.NullText = "Seç";
            //lueKrediTipi2.Enter += delegate { BelgeUtil.Inits.KrediTipiGetir(new LookUpEdit[] { lueKrediTipi2 }); };

            //lueDavaEdilenTYutarDOVIZID.Properties.NullText = "Seç";
            //lueDavaEdilenTYutarDOVIZID.Enter += delegate { BelgeUtil.Inits.DovizTipGetir(lueDavaEdilenTYutarDOVIZID); };

            lueAdliye2.Properties.NullText = "Seç";
            lueAdliye2.Enter += delegate { BelgeUtil.Inits.AdliyeGetir(new LookUpEdit[] { lueAdliye2 }); };

            lueTarafAdi2.Enter += delegate { AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueTarafAdi2, null); };

            //lueBanka2.Properties.NullText = "Seç";
            //lueBanka2.Enter += delegate { BelgeUtil.Inits.BankaGetir(new LookUpEdit[] { lueBanka2 }); };

            lueSorumluAvukat2.Properties.NullText = "Seç";
            lueSorumluAvukat2.Enter += delegate { BelgeUtil.Inits.SorumluAvukatGetir(lueSorumluAvukat2); };

            lueNo2.Properties.NullText = "Seç";
            lueNo2.Enter += delegate { BelgeUtil.Inits.AdliBirimNoGetir(new LookUpEdit[] { lueNo2 }); };

            lueKonu2.Properties.NullText = "Seç";
            lueKonu2.Enter += delegate { BelgeUtil.Inits.DavaTalepGetir(lueKonu2); };

            //lueDurum2.Properties.NullText = "Seç";
            //lueDurum2.Enter += delegate { BelgeUtil.Inits.FoyDurumGetir(lueDurum2.Properties); };

            lueKarsiTarafVekil.Properties.NullText = "Seç";
            lueKarsiTarafVekil.Enter += delegate { BelgeUtil.Inits.CariAvukatGetir(lueKarsiTarafVekil.Properties); };

            lueOzelKod1_2.Properties.NullText = "Seç";
            lueOzelKod1_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod1_2, 1, AvukatProLib.Extras.Modul.Dava); };

            lueOzelKod2_2.Properties.NullText = "Seç";
            lueOzelKod2_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod2_2, 2, AvukatProLib.Extras.Modul.Dava); };

            lueOzelKod3_2.Properties.NullText = "Seç";
            lueOzelKod3_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod3_2, 3, AvukatProLib.Extras.Modul.Dava); };

            lueOzelKod4_2.Properties.NullText = "Seç";
            lueOzelKod4_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod4_2, 4, AvukatProLib.Extras.Modul.Dava); };
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

            lueDurum2.Properties.NullText = "Seç";

            BelgeUtil.Inits.FoyDurumGetir(lueDurum2.Properties);
            lueDurum2.EditValue = 2;
            Durum = 2;
        }

        private void rgDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secim = int.Parse(rgDurum.Properties.Items[rgDurum.SelectedIndex].Value.ToString());

            switch (secim)
            {
                case 0:
                    ucDavaBIL_Foy1.gridView1.ActiveFilter.Add(ucDavaBIL_Foy1.colDURUM1,
                                                              new DevExpress.XtraGrid.Columns.ColumnFilterInfo(""));
                    break;

                case 1:
                    ucDavaBIL_Foy1.gridView1.ActiveFilter.Add(ucDavaBIL_Foy1.colDURUM1,
                                                              new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                                                                  "[DURUM] == EVRAK"));
                    break;

                case 2:
                    ucDavaBIL_Foy1.gridView1.ActiveFilter.Add(ucDavaBIL_Foy1.colDURUM1,
                                                              new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                                                                  "[DURUM] == DERDEST"));
                    break;
                default:
                    break;
            }
        }

        private void rgLeyh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TakibeGonder();
        }


        private void tabcDava_Click(object sender, EventArgs e)
        {
            //pGcDava.MyDavaFoy = ucDavaBIL_Foy1.MyDataSource;
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
        private int? Banka;
        private int? Cari;
        private int? DavaKonusu;
        private string DavaNedeni;
        private string DnRef1;
        private string DnRef2;
        private string DosyaNo;
        private int? DovizId;
        private int? Durum;
        private DateTime? DurusmaTarih;
        private string EsasNo;
        private int? FoyBirim;
        private int? FoyYeri;
        private int? Gorev;
        private int? KarsiTarafVekil;
        private DateTime? KesifTarih;
        private string Klasor1;
        private string Klasor2;
        private int? KrediGrubu;
        private int? KrediTipi;
        private int? OzelDurum;
        private int? OzelKod1;
        private int? OzelKod2;
        private int? OzelKod3;
        private int? OzelKod4;
        private string Ref1;
        private string Ref2;
        private string Ref3;
        private int? Sorumlu;
        private int? Sube;
        private int? TahsilatDurumu;
        private DateTime? Tarih;
        private DateTime? VadeTarihi;


        private void dtDurusmaTrh_EditValueChanged(object sender, EventArgs e)
        {
            if (dtDurusmaTrh.Text != string.Empty)
            {
                if (dtDurusmaTrh.EditValue.ToString().Length > 0)
                    DurusmaTarih = (DateTime?)dtDurusmaTrh.EditValue;
            }
            else
                DurusmaTarih = null;
        }

        private void dtKesifTrh_EditValueChanged(object sender, EventArgs e)
        {
            if (dtKesifTrh.Text != string.Empty)
            {
                if (dtKesifTrh.EditValue.ToString().Length > 0)
                    KesifTarih = (DateTime?)dtKesifTrh.EditValue;
            }
            else
                KesifTarih = null;
        }

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

        private void lueKarsiTarafVekil_EditValueChanged(object sender, EventArgs e)
        {
            KarsiTarafVekil = (int?)lueKarsiTarafVekil.EditValue;
        }

        private void lueKonu2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueKonu2.EditValue != null)
                DavaKonusu = (int?)lueKonu2.EditValue;
            else
                DavaKonusu = null;
        }

        //private void lueKrediGrubu2_EditValueChanged(object sender, EventArgs e)
        //{
        //    KrediGrubu = (int?)lueKrediGrubu2.EditValue;
        //}

        //private void lueKrediTipi2_EditValueChanged(object sender, EventArgs e)
        //{
        //    KrediTipi = (int?)lueKrediTipi2.EditValue;
        //}

        private void lueNo2_EditValueChanged(object sender, EventArgs e)
        {
            AdliBirimNo = (int?)lueNo2.EditValue;
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
                Sorumlu = (int?)lueSorumluAvukat2.EditValue;
            else
                Sorumlu = null;
        }

        //private void lueSube2_EditValueChanged(object sender, EventArgs e)
        //{
        //    Sube = (int?)lueSube2.EditValue;
        //}

        //private void lueTahsilatDurumu2_EditValueChanged(object sender, EventArgs e)
        //{
        //    TahsilatDurumu = (int?)lueTahsilatDurumu2.EditValue;
        //}

        private void lueTarafAdi2_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lueTarafAdi2.EditValue.ToString()))
                Cari = null;
            else
                Cari = (int?)lueTarafAdi2.EditValue;
        }

        //private void txtDavaNedenRef2_1_TextChanged(object sender, EventArgs e)
        //{
        //    DnRef1 = txtDavaNedenRef2_1.Text;
        //    if (txtDavaNedenRef2_1.Text == string.Empty)
        //        DnRef1 = null;
        //}

        //private void txtDavaNedenRef2_2_TextChanged(object sender, EventArgs e)
        //{
        //    DnRef2 = txtDavaNedenRef2_2.Text;
        //    if (txtDavaNedenRef2_2.Text == string.Empty)
        //        DnRef2 = null;
        //}

        //private void txtDigerDavaNedeni2_TextChanged(object sender, EventArgs e)
        //{
        //    DavaNedeni = txtDigerDavaNedeni2.Text;
        //    if (txtDigerDavaNedeni2.Text == string.Empty)
        //        DavaNedeni = null;
        //}

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

        //private void txtKlasor1_2_TextChanged(object sender, EventArgs e)
        //{
        //    Klasor1 = txtKlasor1_2.Text;
        //    if (txtKlasor1_2.Text == string.Empty)
        //        Klasor1 = null;
        //}

        //private void txtKlasor2_2_TextChanged(object sender, EventArgs e)
        //{
        //    Klasor2 = txtKlasor2_2.Text;
        //    if (txtKlasor2_2.Text == string.Empty)
        //        Klasor2 = null;
        //}

        private void txtRef1_2_TextChanged(object sender, EventArgs e)
        {
            Ref1 = txtRef2_2.Text;
            if (txtRef2_2.Text == string.Empty)
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
            ucDavaBIL_Foy1.MyDataSource = e.Result as DataTable;
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

        private void tabcDava_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabcDava.SelectedTabPageIndex == 1)
            {
                AdimAdimDavaKaydi.UserControls.ucRapor.ucPivotChart pGcDava = new UserControls.ucRapor.ucPivotChart();
                pGcDava.Dock = DockStyle.Fill;
                pGcDava.MyDavaFoy = ucDavaBIL_Foy1.MyDataSource;
                tabPivotRapor.Controls.Add(pGcDava); 
            }
        }
    }
}