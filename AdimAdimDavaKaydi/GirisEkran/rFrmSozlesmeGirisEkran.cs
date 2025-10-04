using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AdimAdimDavaKaydi.Sozlesme.Forms;
using AdimAdimDavaKaydi.UserControls;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmSozlesmeGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private VList<R_SOZLESME_GENEL_ARAMA2> _MyDataSourceDeep;

        private int? AdliBirimGorev;

        private int? AdliBirimNo;

        private frmSozlesmeTakip frmSozlesmeTak;

        private ImageList myImageList = new ImageList();

        private VList<R_SOZLESME_GENEL_ARAMA2> secilenFoyler = new VList<R_SOZLESME_GENEL_ARAMA2>();

        private bool tumuSecili;

        public rFrmSozlesmeGirisEkran()
        {
            InitializeComponent();
            InitializeEvents();
            ucSozlesmeBilgi1.FocusedRowChanged += ucSozlesmeBilgi1_FocusedRowChanged;
            ucSozlesmeBilgi1.KayitSilindi += ucSozlesmeBilgi1_KayitSilindi;
        }

        public VList<R_SOZLESME_GENEL_ARAMA2> MyDataSourceDeep
        {
            get { return _MyDataSourceDeep; }
            set
            {
                _MyDataSourceDeep = value;
                ucSozlesmeBilgi1.MyDataSource = value;
            }
        }

        private DataTable _ProjeTable
        {
            get
            {
                DataTable result = new DataTable("Asama");
                result.Columns.Add("ADI");
                return result;
            }
        }

        public void InitsData()
        {
            lueAdliBirimNo.Properties.NullText = "Seç";
            lueAdliBirimNo.Enter += delegate { BelgeUtil.Inits.AdliBirimNoGetir(lueAdliBirimNo.Properties); };

            lueAdliBirimGorev.Properties.NullText = "Seç";
            lueAdliBirimGorev.Enter += delegate { BelgeUtil.Inits.AdliBirimGorevGetir(lueAdliBirimGorev.Properties); };

            lueAdlye.Properties.NullText = "Seç";
            lueAdlye.Enter += delegate { BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdlye.Properties); };

            lueSozlesmeAltTip.Properties.NullText = "Seç";
            lueSozlesmeAltTip.Enter +=
                delegate { BelgeUtil.Inits.SozlesmeAltTipiHepsiGetir(lueSozlesmeAltTip.Properties); };

            lueOzelKod1.Properties.NullText = "Seç";
            lueOzelKod1.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod1, 1, AvukatProLib.Extras.Modul.Sozlesme); };

            lueOzelKod2.Properties.NullText = "Seç";
            lueOzelKod2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod2, 2, AvukatProLib.Extras.Modul.Sozlesme); };

            lueOzelKod3.Properties.NullText = "Seç";
            lueOzelKod3.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod3, 3, AvukatProLib.Extras.Modul.Sozlesme); };

            lueOzelKod4.Properties.NullText = "Seç";
            lueOzelKod4.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod4, 4, AvukatProLib.Extras.Modul.Sozlesme); };
        }

        public void TakibeGonder()
        {
            secilenFoyler = ucSozlesmeArama.GetSelectedFoy(ucSozlesmeBilgi1.MyDataSource);

            TList<AV001_TDI_BIL_SOZLESME> foyList = new TList<AV001_TDI_BIL_SOZLESME>();
            foreach (var item in secilenFoyler)
            {
                foyList.Add(DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(item.ID));
            }
            if (foyList.Count > 0)
            {
                if (frmSozlesmeTak == null || frmSozlesmeTak.IsDisposed)
                {
                    frmSozlesmeTak = new frmSozlesmeTakip();

                    // frmSozlesmeTak.SozlesmeKaydedildi += new EventHandler<FrmSozlesmeDosyaKayit>(frmSozlesmeTak_SozlesmeKaydedildi);
                }

                frmSozlesmeTak.MdiParent = this.MdiParent;
                frmSozlesmeTak.ShowDialog(foyList);
            }
            else
            {
                DialogResult dr =
                    XtraMessageBox.Show("Seçilen kayýt yok. Bütün kayýtlarý açmak istediðinizden emin misiniz?",
                                        "Foy Arama", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    secilenFoyler = ucSozlesmeBilgi1.MyDataSource;
                    foreach (var item in secilenFoyler)
                    {
                        foyList.Add(DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(item.ID));
                    }
                    if (frmSozlesmeTak == null || frmSozlesmeTak.IsDisposed)
                    {
                        frmSozlesmeTak = new frmSozlesmeTakip();

                        //frmSozlesmeTak.SozlesmeKaydedildi += new EventHandler<FrmSozlesmeDosyaKayit>(frmSozlesmeTak_SozlesmeKaydedildi);
                    }
                    frmSozlesmeTak.ShowDialog(foyList);
                    frmSozlesmeTak.BringToFront();
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            //LOAD
            base.OnShown(e);

            xtraTabControl1.SelectedPageChanged += xtraTabControl1_SelectedPageChanged;
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
            tlSozlesmeAsamalar.AfterCheckNode += tlSozlesmeAsamalar_AfterCheckNode;

            tlSozlesmeAsamalar.StateImageList = myImageList;
            BackgroundWorker bWorker = new BackgroundWorker();
            bWorker.DoWork += delegate
                                  {
                                      AsamaDoldur();
                                      SorumlulariDoldur();
                                      TaraflariDoldur();
                                  };
            InitsData();
            if (SozlesmeDurumu == null)
                SozlesmeDurumu = (int?)FoyDurum.FAAL;
            if (Sorumlu == null)
                Sorumlu = AvukatProLib.Kimlik.CurrentCariId;
            rgDosyalar.EditValue = 1;
            bWorker.RunWorkerAsync();

            #region SUBEKONTROLLU VERI CEKME

            //if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
            //if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
            //    //MyDataSourceDeep = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetAll();
            //else
            //    MyDataSourceDeep = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetBySUBE_KOD_ID(AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);

            #endregion SUBEKONTROLLU VERI CEKME

            //TARIH         :  10 Eylül 2009 Perþembe
            //KODU YAZAN    :  Mehmet Emin AYDOÐDU
            //NEDENI        :  Özel Kodlar ve Referans Baþlýklarýnýn Veri Tabnýndan Alýnmasý
            //Mehmet Begin

            #region Ozellestirme

            lblOzelKod1.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod1;
            lblOzelKod2.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod2;
            lblOzelKod3.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod3;
            lblOzelKod4.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod4;

            #endregion Ozellestirme

            #region Captionlar

            try
            {
                foreach (GridColumn item in ucSozlesmeBilgi1.gwSozlesmeBilgi.Columns)
                {
                    if (item.Name.Contains("colOZEL_KOD1"))
                        item.Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod1;
                    if (item.Name.Contains("colOZEL_KOD2"))
                        item.Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod2;
                    if (item.Name.Contains("colOZEL_KOD3"))
                        item.Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod3;
                    if (item.Name.Contains("colOZEL_KOD4"))
                        item.Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod4;
                }
            }
            catch 
            {
            }

            #endregion Captionlar

            //Mehmet End

            ucSozlesmeBilgi1.MyDataSource = MyDataSourceDeep;
            this.ucBelgeIzlemeDolasimDock1.MyDataSource = new System.Collections.Generic.List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE>();

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

            AsamaDoldur(asamaList);

            if (asamaList.Count == 0)
            {
                XtraMessageBox.Show("Aradýðýnýz kriterlere uyan aþama bulunamadý.", "Arama Sonucu", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                MyDataSourceDeep = null;
            }
            tlSozlesmeAsamalar.Nodes.TreeList.ExpandAll();
        }

        private void AsamaDoldur()
        {
            TList<TDIE_KOD_ASAMA> asamalar = DataRepository.TDIE_KOD_ASAMAProvider.GetByASAMA_MODUL_ID(5);
            DataRepository.TDIE_KOD_ASAMAProvider.DeepLoad(asamalar, true, DeepLoadType.IncludeChildren, typeof(TList<TDIE_KOD_ASAMA_ALT>));

            foreach (TDIE_KOD_ASAMA asama in asamalar)
            {
                TreeListNode tn = tlSozlesmeAsamalar.AppendNode(dataRowYap(asama.ASAMA_ADI), null);
                tn.Tag = asama;
                if (asama.SIMGE != null)
                {
                    Image img = Image.FromStream(new System.IO.MemoryStream(asama.SIMGE));
                    int imgYeri = myImageList.Images.Add(img, Color.Transparent);

                    tn.StateImageIndex = imgYeri;
                }

                foreach (TDIE_KOD_ASAMA_ALT altAsama in asama.TDIE_KOD_ASAMA_ALTCollection)
                {
                    TreeListNode tn2 = tlSozlesmeAsamalar.AppendNode(dataRowYap(altAsama.ALT_ASAMA_ADI), tn, altAsama);
                    if (altAsama.SIMGE != null)
                    {
                        Image img2 = Image.FromStream(new System.IO.MemoryStream(altAsama.SIMGE));
                        int imgYeri2 = myImageList.Images.Add(img2, Color.Transparent);
                        tn2.StateImageIndex = imgYeri2;
                    }
                }
            }
        }

        private void AsamaDoldur(TList<TDIE_KOD_ASAMA> asamaList)
        {
            if (asamaList == null)
                asamaList = DataRepository.TDIE_KOD_ASAMAProvider.GetByASAMA_MODUL_ID(1);

            //TList<TDIE_KOD_ASAMA> asamalar = DataRepository.TDIE_KOD_ASAMAProvider.GetByASAMA_MODUL_ID(1);
            DataRepository.TDIE_KOD_ASAMAProvider.DeepLoad(asamaList, true, DeepLoadType.IncludeChildren,
                                                           typeof(TList<TDIE_KOD_ASAMA_ALT>));

            asamaList.Sort("SIRA_NO ASC");

            tlSozlesmeAsamalar.Nodes.Clear();
            foreach (TDIE_KOD_ASAMA asama in asamaList)
            {
                TreeListNode tn = tlSozlesmeAsamalar.AppendNode(dataRowYap(asama.ASAMA_ADI), null);
                tn.Tag = asama;
                if (asama.SIMGE != null)
                {
                    Image img = Image.FromStream(new System.IO.MemoryStream(asama.SIMGE));
                    int imgYeri = myImageList.Images.Add(img, Color.Transparent);

                    tn.StateImageIndex = imgYeri;
                }

                asama.TDIE_KOD_ASAMA_ALTCollection.Sort("SIRA_NO ASC");

                foreach (TDIE_KOD_ASAMA_ALT altAsama in asama.TDIE_KOD_ASAMA_ALTCollection)
                {
                    TreeListNode tn2 = tlSozlesmeAsamalar.AppendNode(dataRowYap(altAsama.ALT_ASAMA_ADI), tn, altAsama);
                    tn2.Tag = altAsama;

                    if (altAsama.SIMGE != null)
                    {
                        Image img2 = Image.FromStream(new System.IO.MemoryStream(altAsama.SIMGE));
                        int imgYeri2 = myImageList.Images.Add(img2, Color.Transparent);
                        tn2.StateImageIndex = imgYeri2;
                    }
                }
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (txtArama.Text == string.Empty) AsamaDoldur(null);
            AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf taraf =
                (AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf)
                rgTaraf.Properties.Items.GetItemIndexByValue(rgTaraf.SelectedIndex);
            AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur tur =
                (AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur)
                rgTur.Properties.Items.GetItemIndexByValue(rgTur.SelectedIndex);
            AramaYap(taraf, tur);
        }

        private void btnAsamaSorgula_Click(object sender, EventArgs e)
        {
            string secilenUstler = string.Empty;
            string secilenlerAltlar = string.Empty;
            for (int i = 0; i < tlSozlesmeAsamalar.Nodes.Count; i++)
            {
                if (tlSozlesmeAsamalar.Nodes[i].Checked)
                {
                    TDIE_KOD_ASAMA ust = tlSozlesmeAsamalar.Nodes[i].Tag as TDIE_KOD_ASAMA;

                    if (ust != null)
                    {
                        secilenUstler += ust.ID + ",";
                    }
                    for (int y = 0; y < tlSozlesmeAsamalar.Nodes[i].Nodes.Count; y++)
                    {
                        if (tlSozlesmeAsamalar.Nodes[i].Nodes[y].Checked)
                        {
                            TDIE_KOD_ASAMA_ALT asamaAlt = tlSozlesmeAsamalar.Nodes[i].Nodes[y].Tag as TDIE_KOD_ASAMA_ALT;
                            if (asamaAlt != null)
                            {
                                secilenlerAltlar += asamaAlt.ID + ",";
                            }
                        }
                    }
                }
            }
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (!tumuSecili)
            {
                for (int i = 0; i < ucSozlesmeBilgi1.gwSozlesmeBilgi.DataRowCount; i++)
                {
                    AV001_TDI_BIL_SOZLESME foy = (AV001_TDI_BIL_SOZLESME)ucSozlesmeBilgi1.gwSozlesmeBilgi.GetRow(i);

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
                for (int i = 0; i < ucSozlesmeBilgi1.gwSozlesmeBilgi.DataRowCount; i++)
                {
                    AV001_TDI_BIL_SOZLESME foy = (AV001_TDI_BIL_SOZLESME)ucSozlesmeBilgi1.gwSozlesmeBilgi.GetRow(i);

                    if (foy != null)
                    {
                        foy.IsSelected = false;
                        btnSec.Text = "Tümünü Seç";
                    }
                }

                tumuSecili = false;
            }
        }

        private void btnSorgu_Click(object sender, EventArgs e)
        {
            splitContainerControl1.Enabled = false;
            BackgroundWorker bckWorker = new BackgroundWorker();
            bckWorker.DoWork += delegate
                                    {
                                        string secilenTaraflar = GetSecilenTaraf();
                                        string secilenSorumlular = GetSecilenSorumlular();
                                    };
            bckWorker.RunWorkerCompleted += delegate { splitContainerControl1.Enabled = true; };
            bckWorker.RunWorkerAsync();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            SozlesmeTrfSrmlSecimleriniTemizle();
        }

        private void btnTumKosullariTemizle_Click(object sender, EventArgs e)
        {
            TLSozlesmeSecimleriniDuzenle(false);
            SozlesmeTrfSrmlSecimleriniTemizle();
            rgDurum.SelectedIndex = 2;
            rgLeyh.SelectedIndex = 2;
            rgDurum_SelectedIndexChanged(rgDurum, new EventArgs());
            rgLeyh_SelectedIndexChanged(rgLeyh, new EventArgs());
            txtArama.Text = string.Empty;
            ucSozlesmeBilgi1.FilitreleriTemizle();
        }

        private void chBoxAsamalarTumu_CheckedChanged(object sender, EventArgs e)
        {
            TLSozlesmeSecimleriniDuzenle(chBoxAsamalarTumu.Checked);
        }

        private DataRow dataRowYap(string adi)
        {
            DataRow dr = _ProjeTable.NewRow();
            dr["ADI"] = adi;
            return dr;
        }

        private void gcSorumlular_ButtonTumunuKaldir(object sender, NavigatorButtonClickEventArgs e)
        {
            DataTable dt = gcSorumlular.DataSource as DataTable;

            foreach (DataRow row in dt.Rows)
            {
                row["SECILIMI"] = false;
            }
            gcSorumlular.Refresh();
        }

        private void gcSorumlular_ButtonTumunuSec(object sender, NavigatorButtonClickEventArgs e)
        {
            DataTable dt = gcSorumlular.DataSource as DataTable;
            foreach (DataRow row in dt.Rows)
            {
                row["SECILIMI"] = true;
            }
            gcSorumlular.Refresh();
        }

        private string GetSecilenSorumlular()
        {
            string secilenSorumlular = string.Empty;

            DataTable dtSorumlular = gcSorumlular.DataSource as DataTable;
            DataRow[] listeSorumlular = dtSorumlular.Select("SECILIMI = 'True'");
            foreach (DataRow row in listeSorumlular)
            {
                secilenSorumlular += row["SORUMLU_CARI_ID"] + ",";
            }

            secilenSorumlular = secilenSorumlular.TrimEnd(',');
            return secilenSorumlular;
        }

        private string GetSecilenTaraf()
        {
            string secilenTaraflar = string.Empty;
            DataTable dtTaraflar = grdcTaraflar.DataSource as DataTable;
            DataRow[] listeTaraf = dtTaraflar.Select("SECILIMI = 'True'");
            foreach (DataRow row in listeTaraf)
            {
                secilenTaraflar += row["CARI_ID"] + ",";
            }
            secilenTaraflar = secilenTaraflar.TrimEnd(',');
            return secilenTaraflar;
        }

        private void grdcTaraflar_ButtonTumunuKaldir(object sender, NavigatorButtonClickEventArgs e)
        {
            DataTable dt = grdcTaraflar.DataSource as DataTable;

            foreach (DataRow row in dt.Rows)
            {
                row["SECILIMI"] = false;
            }
            grdcTaraflar.Refresh();
        }

        private void grdcTaraflar_ButtonTumunuSec(object sender, NavigatorButtonClickEventArgs e)
        {
            DataTable dt = grdcTaraflar.DataSource as DataTable;

            foreach (DataRow row in dt.Rows)
            {
                row["SECILIMI"] = true;
            }
            grdcTaraflar.Refresh();
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Editor_Click += rFrmSozlesmeGirisEkran_Button_Editor_Click;
            this.Button_Ac_Click += rFrmSozlesmeGirisEkran_Button_Ac_Click;
            this.Button_Yeni_Click += rFrmSozlesmeGirisEkran_Button_Yeni_Click;
            this.Button_Yeniden_Click += rFrmSozlesmeGirisEkran_Button_Yeniden_Click;
        }

        private void lueAdliBirimGorev_EditValueChanged(object sender, EventArgs e)
        {
            AdliBirimGorev = (int?)lueAdliBirimGorev.EditValue;
        }

        private void lueAdliBirimNo_EditValueChanged(object sender, EventArgs e)
        {
            AdliBirimNo = (int?)lueAdliBirimNo.EditValue;
        }

        private void rFrmSozlesmeGirisEkran_Button_Ac_Click(object sender, EventArgs e)
        {
            FoyuAc();
        }

        private void rFrmSozlesmeGirisEkran_Button_Editor_Click(object sender, EventArgs e)
        {
            EditorAc();
        }

        private void rFrmSozlesmeGirisEkran_Button_Yeni_Click(object sender, EventArgs e)
        {
            YeniFoy();
        }

        private void rFrmSozlesmeGirisEkran_Button_Yeniden_Click(object sender, EventArgs e)
        {
            FoyuYenile();
        }

        private void rgDosyalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)rgDosyalar.EditValue == 1)
            {
                SozlesmeDurumu = (int?)FoyDurum.FAAL;
                Sorumlu = AvukatProLib.Kimlik.CurrentCariId;
            }
            if ((int)rgDosyalar.EditValue == 2)
            {
                SozlesmeDurumu = null;
                Sorumlu = AvukatProLib.Kimlik.CurrentCariId;
            }
            if ((int)rgDosyalar.EditValue == 3)
            {
                SozlesmeDurumu = null;
                Sorumlu = null;
            }
        }

        private void rgDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secim = int.Parse(rgDurum.Properties.Items[rgDurum.SelectedIndex].Value.ToString());

            switch (secim)
            {
                case 0:
                    ucSozlesmeBilgi1.gwSozlesmeBilgi.ActiveFilter.Add(ucSozlesmeBilgi1.colSOZLESME_DURUM,
                                                                      new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                                                                          ""));
                    break;

                case 1:
                    ucSozlesmeBilgi1.gwSozlesmeBilgi.ActiveFilter.Add(ucSozlesmeBilgi1.colSOZLESME_DURUM,
                                                                      new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                                                                          "[SOZLESME_DURUM] == Faal"));
                    break;

                case 2:
                    ucSozlesmeBilgi1.gwSozlesmeBilgi.ActiveFilter.Add(ucSozlesmeBilgi1.colSOZLESME_DURUM,
                                                                      new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                                                                          "[SOZLESME_DURUM] == Arþiv"));
                    break;
                default:
                    break;
            }
        }

        private void rgLeyh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bool? secim = null;

                if (rgLeyh.Properties.Items[rgLeyh.SelectedIndex].Value != null)
                {
                    secim = Convert.ToBoolean(rgLeyh.Properties.Items[rgLeyh.SelectedIndex].Value);
                }
                switch (secim)
                {
                    case true:
                        gwTaraflar.ActiveFilter.Add(gridColumnTakipEdenmi,
                                                    new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                                                        "[SIKAYET_EDEN_MI] == 1"));
                        gwTaraflar.ActiveFilter.Add(gridColumnKod,
                                                    new DevExpress.XtraGrid.Columns.ColumnFilterInfo("[KOD] == 'M'"));

                        break;

                    case false:
                        gwTaraflar.ActiveFilter.Add(gridColumnTakipEdenmi,
                                                    new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                                                        "[SIKAYET_EDEN_MI] == 0"));
                        gwTaraflar.ActiveFilter.Add(gridColumnKod,
                                                    new DevExpress.XtraGrid.Columns.ColumnFilterInfo("[KOD] == 'M'"));

                        break;
                    default:
                        gwTaraflar.ActiveFilter.Add(gridColumnTakipEdenmi,
                                                    new DevExpress.XtraGrid.Columns.ColumnFilterInfo(""));
                        gwTaraflar.ActiveFilter.Add(gridColumnKod, new DevExpress.XtraGrid.Columns.ColumnFilterInfo(""));
                        break;
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

        private void SorumlulariDoldur()
        {
            DataTable dt = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.SORUMLU_TumAvukatGetir().Tables[0];

            //.AV001_TD_BIL_FOYProvider.SORUMLU_AVUKAT_TumAvukatGetir().Tables[0];
            gcSorumlular.DataSource = dt;
        }

        private void SozlesmeTrfSrmlSecimleriniTemizle()
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

        private void TaraflariDoldur()
        {
            DataTable dt = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.TARAF_TumTarafGetir().Tables[0];

            // AV001_TD_BIL_FOYProvider.TARAF_TumTarafGetir().Tables[0];
            grdcTaraflar.DataSource = dt;
        }

        private void tlSozlesmeAsamalar_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
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

        private void TLSozlesmeSecimleriniDuzenle(bool chck)
        {
            for (int i = 0; i < tlSozlesmeAsamalar.Nodes.Count; i++)
            {
                tlSozlesmeAsamalar.Nodes[i].Checked = chck;
                for (int y = 0; y < tlSozlesmeAsamalar.Nodes[i].Nodes.Count; y++)
                {
                    tlSozlesmeAsamalar.Nodes[i].Nodes[y].Checked = chck;
                }
            }
        }

        private void ucSozlesmeBilgi1_FocusedRowChanged(R_SOZLESME_GENEL_ARAMA2 sozles, object ExSozlesme, int RowHandle,
                                                        object sender)
        {
            dockPanel3.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            TList<NN_BELGE_SOZLESME> nnList = DataRepository.NN_BELGE_SOZLESMEProvider.GetBySOZLESME_ID(sozles.ID);
            List<int> idList = new List<int>();
            nnList.ForEach(item => idList.Add(item.BELGE_ID));
            this.ucBelgeIzlemeDolasimDock1.MyDataSource = BelgeUtil.Inits.BelgeGetirByIdList(idList);
        }

        private void ucSozlesmeBilgi1_KayitSilindi(object sender, EventArgs e)
        {
            GelismisAramaSorgula();
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

        #region IslemMethodlari

        public void EditorAc()
        {
            frmEditor frmEdit = new frmEditor();
            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
        }

        public void FoyCikis()
        {
            DialogResult dr = XtraMessageBox.Show("Ýcra takip ekraný kapatýlacak. Çýkmak istediðinizden emin misiniz?",
                                                  "Çýkýþ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
                this.Close();
        }

        public void FoyuAc()
        {
            TakibeGonder();
        }

        public void FoyuYenile()
        {
            this.ucSozlesmeBilgi1.gridSozlesmeBilgi.RefreshDataSource();
        }

        public void YeniFoy()
        {
            AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit frmSozlesme =
                new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit();
            frmSozlesme.Show();
        }

        #endregion IslemMethodlari

        #region ButtonClick

        public void AramalarýTemizleGenel()
        {
            FormlariTemizle(pnlArama.Controls);
            FormlariTemizle(grbSozlesmeBilgileri.Controls);
            ucSozlesmeBilgi1.MyDataSource = null;

            //chcBenimDerdestIslerim.Checked = false;
            //chcTumKullanicilariDosyalari.Checked = false;
            //chcBenimTumDosylarim.Checked = false;
        }

        public void GelismisAramaSorgula()
        {
            try
            {
                VList<R_SOZLESME_GENEL_ARAMA2> AramaSonuc = null;
                if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                    AramaSonuc = DataRepository.R_SOZLESME_GENEL_ARAMA2Provider.GetByFiltre(SozlesmeNo, null, null, SozlesmeAltTip, SozlesmeAdi, OzelKod1, OzelKod2, OzelKod3, OzelKod4, Adliye, NoterTarihi, YevmiyeNo, AdliBirimGorev, AdliBirimNo, null, null, SozlesmeDurumu, null, null, null, null, null, Sorumlu, null, NoterTarihi);
                else
                    AramaSonuc = DataRepository.R_SOZLESME_GENEL_ARAMA2Provider.GetByFiltre(SozlesmeNo, null, null, SozlesmeAltTip, SozlesmeAdi, OzelKod1, OzelKod2, OzelKod3, OzelKod4, Adliye, NoterTarihi, YevmiyeNo, AdliBirimGorev, AdliBirimNo, null, null, SozlesmeDurumu, null, null, null, AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID, null, Sorumlu, null, NoterTarihi);
                if (AramaSonuc == null)
                    return;
                ucSozlesmeBilgi1.MyDataSource = AramaSonuc;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

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
                        ((DateEdit)con).EditValue = null;
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

        private void btnAramaTemizle_Click(object sender, EventArgs e)
        {
            AramalarýTemizleGenel();
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            //if (SozlesmeDurumu == null && Sorumlu == null)
            //    XtraMessageBox.Show("Tüm Kullanýcýlar için Aramayý Seçtiniz Arama Ýþleminiz Biraz Uzun Sürebilir",
            //                        "Uyarý", MessageBoxButtons.OK);
            GelismisAramaSorgula();
        }

        #endregion ButtonClick

        #region EditValueChanged

        private int? Adliye;
        private DateTime? NoterTarihi;
        private int? OzelKod1;
        private int? OzelKod2;
        private int? OzelKod3;
        private int? OzelKod4;

        private int? Sorumlu;

        private string SozlesmeAdi;

        private int? SozlesmeAltTip;

        private int? SozlesmeDurumu;

        private string SozlesmeNo;

        private string YevmiyeNo;

        private void dateNoterTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dateNoterTarihi.EditValue != null)
            {
                NoterTarihi = (DateTime?)dateNoterTarihi.EditValue;
            }
            else
                NoterTarihi = null;
        }

        private void lueAdlye_EditValueChanged(object sender, EventArgs e)
        {
            Adliye = (int?)lueAdlye.EditValue;
        }

        private void lueOzelKod1_EditValueChanged(object sender, EventArgs e)
        {
            OzelKod1 = (int?)lueOzelKod1.EditValue;
        }

        private void lueOzelKod2_EditValueChanged(object sender, EventArgs e)
        {
            OzelKod2 = (int?)lueOzelKod2.EditValue;
        }

        private void lueOzelKod3_EditValueChanged(object sender, EventArgs e)
        {
            OzelKod3 = (int?)lueOzelKod3.EditValue;
        }

        private void lueOzelKod4_EditValueChanged(object sender, EventArgs e)
        {
            OzelKod4 = (int?)lueOzelKod4.EditValue;
        }

        private void lueSozlesmeAltTip_EditValueChanged(object sender, EventArgs e)
        {
            SozlesmeAltTip = (int?)lueSozlesmeAltTip.EditValue;
        }

        private void txtSozlesmeAdi_TextChanged(object sender, EventArgs e)
        {
            if (txtSozlesmeAdi.Text == string.Empty)
                SozlesmeAdi = null;
            else
                SozlesmeAdi = "%" + txtSozlesmeAdi.Text + "%";
        }

        private void txtSözleþmeNo_TextChanged(object sender, EventArgs e)
        {
            if (txtSozlesmeNo.Text == string.Empty)
                SozlesmeNo = null;
            else
                SozlesmeNo = "%" + txtSozlesmeNo.Text + "%";
        }

        private void txtYevmiyeNo_TextChanged(object sender, EventArgs e)
        {
            YevmiyeNo = "%" + txtYevmiyeNo.Text + "%";
            if (txtYevmiyeNo.Text == string.Empty)
                YevmiyeNo = null;
        }

        #endregion EditValueChanged
    }
}