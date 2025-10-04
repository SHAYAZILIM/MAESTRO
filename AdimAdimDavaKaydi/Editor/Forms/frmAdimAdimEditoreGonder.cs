using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Editor.Util;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AdimAdimDavaKaydi.Generalclass.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AdimAdimDavaKaydi.Util.Uyap;
using AvukatProLib;
using AvukatProLib.Hesap;
using AvukatProLib.Mail;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Editor.Forms
{

    public partial class frmAdimAdimEditoreGonder : AvpXtraForm
    {
        #region Uyap

        public List<UyapHata> HataliDosyalar;
        private UyapGeriBildirim _uyapBildirim;
        private List<per_AV001_TI_BIL_ICRA_Arama> foyler;

        public UyapGeriBildirim UyapBildirim
        {
            get { return _uyapBildirim; }
            set { _uyapBildirim = value; }
        }

        public bool HataEkle(DevExpress.XtraNavBar.NavBarItem hata)
        {
            foreach (DevExpress.XtraNavBar.NavBarItemLink tmp in HatalarNB.ItemLinks)
            {
                if (tmp.Caption.Substring(8) == hata.Caption.Substring(8))
                    return false;
            }
            HatalarNB.ItemLinks.Add(hata);
            HatalarNB.Caption = "Hatalar (" + HatalarNB.ItemLinks.Count + ")";
            return true;
        }

        public void HatalariSil()
        {
            HataliDosyalar.Clear();
            HatalarNB.ItemLinks.Clear();
            HatalarNB.Caption = "Hatalar";
        }

        public void XMLBastir(string dosyaYolu)
        {
            UyapWB.Url = new Uri(dosyaYolu);
            wpSon.Text = "Uyap Çýktýsý Önizleme";
        }

        #endregion Uyap

        public frmAdimAdimEditoreGonder()
        {
            InitializeComponent();
            HataliDosyalar = new List<UyapHata>();
        }

        public AvukatProLib.Extras.UYAPIslemSecimi UyapSecimi = new AvukatProLib.Extras.UYAPIslemSecimi();

        private List<Ciktilar> AlinacakCiktilar = new List<Ciktilar>();

        private bool DisaridanCagirildi;
        private List<int> seciliFoyIDleri = new List<int>();

        public enum CiktiTipi
        {
            Otomatik_Alan,
            Kalip_Sablon,
            Uyap
        }

        public CiktiTipi SecilenCiktiTipi { get; set; }

        [Browsable(false)]
        public List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> SeciliRaporlar { get; set; }

        [Browsable(false)]
        public List<object> SelectedList { get; set; }

        public void ChangePage(string pageName)
        {
            foreach (var tmp in wizardControl1.Pages)
            {
                if (tmp is DevExpress.XtraWizard.WizardPage)
                    if (pageName == ((DevExpress.XtraWizard.WizardPage)tmp).Name)
                    {
                        wizardControl1.SelectedPage = (DevExpress.XtraWizard.WizardPage)tmp;
                    }
            }
        }

        public void Show(List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> foyler)
        {
            //aykut önemli 12.02.2013
            this.Show();
            //this.DisaridanCagirildi = true;
            //if (this.SelectedList == null)
            //{
            //    this.SelectedList = new List<object>();
            //}
            //for (int i = 0; i < foyler.Rows.Count; i++)
            //{
            //    this.SelectedList.Add(foyler[i]);
            //}

            //this.ucIcraFoy1.MyDataSource = foyler;

            //this.wizardControl1.SelectedPage = wpSablon;
        }

        public void Show(AV001_TI_BIL_FOY foyum)
        {
            this.Show();
            if (this.SelectedList == null)
                this.SelectedList = new List<object>();
            this.SelectedList.Add(foyum);
            this.wizardControl1.SelectedPage = wpSablon;
        }

        public void Show(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama foyum)
        {
            this.Show();
            if (this.SelectedList == null)
                this.SelectedList = new List<object>();
            this.SelectedList.Add(AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.GetByID(foyum.ID));
            this.wizardControl1.SelectedPage = wpSablon;
        }

        public void Show(List<AvukatProLib.Arama.VTD_DAVA_DOSYALAR> foyler)
        {
            this.Show();
            for (int i = 0; i < foyler.Count; i++)
            {
                this.SelectedList.Add(foyler[i]);
            }

            this.wizardControl1.SelectedPage = wpSablon;
        }

        public void UyapSonSayfaGetir()
        {
            wizardControl1.SelectedPage = wpSon;
        }

        private void AV001_TI_BIL_ILAM_MAHKEMESICollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_ILAM_MAHKEMESI mk = e.NewObject as AV001_TI_BIL_ILAM_MAHKEMESI;
            if (mk == null)
                mk = new AV001_TI_BIL_ILAM_MAHKEMESI();
            mk.INKAR_TAZMINAT_FAIZ_TIP_ID = 1;
            mk.INKAR_TAZMINAT_FAIZ_ORANI = FaizHelper.FaizOraniGetir(1, mk.INKAR_TAZMINATI_DOVIZ_ID.Value, DateTime.Today);
            mk.INKAR_TAZMINATI_DOVIZ_ID = 1;
            mk.YARGILAMA_GIDERI_DOVIZ_ID = 1;
            mk.YARGILAMA_GIDERI_FAIZ_TIP_ID = 1;
            mk.YARGILAMA_GIDERI_FAIZ_ORANI = FaizHelper.FaizOraniGetir(1, mk.YARGILAMA_GIDERI_DOVIZ_ID.Value, DateTime.Today);
            mk.ILAM_VEKALET_UCRETI_DOVIZ_ID = 1;
            mk.ILAM_VEKALET_UCRET_FAIZ_TIP_ID = 1;
            mk.ILAM_VEKALET_UCRET_FAIZ_ORANI = FaizHelper.FaizOraniGetir(1, mk.ILAM_VEKALET_UCRETI_DOVIZ_ID.Value, DateTime.Today);
            mk.ILAM_TEBLIG_GIDER_FAIZ_TIP_ID = 1;
            mk.ILAM_TEBLIG_GIDER_FAIZ_ORANI = FaizHelper.FaizOraniGetir(1, mk.ILAM_TEBLIG_GIDERI_DOVIZ_ID.Value, DateTime.Today);
            mk.ILAM_TEBLIG_GIDERI_DOVIZ_ID = 1;
            mk.BAKIYE_KARAR_HARCI_FAIZ_TIP_ID = 1;
            mk.BAKIYE_KARAR_HARCI_FAIZ_ORANI = FaizHelper.FaizOraniGetir(1, mk.BAKIYE_KARAR_HARCI_DOVIZ_ID.Value, DateTime.Today);
            mk.BAKIYE_KARAR_HARCI_DOVIZ_ID = 1;
            mk.YARGITAY_ONAMA_HARCI_DOVIZ_ID = 1;
            mk.YARGITAY_ONAMA_HARCI_FAIZ_TIP_ID = 1;
            mk.YARGITAY_ONAMA_HARCI_FAIZ_ORANI = FaizHelper.FaizOraniGetir(1, mk.YARGITAY_ONAMA_HARCI_DOVIZ_ID.Value, DateTime.Today);
            mk.KAYIT_TARIHI = DateTime.Now;
            mk.KONTROL_NE_ZAMAN = DateTime.Now;
            mk.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            mk.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            mk.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            mk.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            mk.ColumnChanged += mk_ColumnChanged;

            e.NewObject = mk;
        }

        private void c_btnTamam_Click(object sender, EventArgs e)
        {
        }

        private void frmAdimAdimEditoreGonder_Load(object sender, EventArgs e)
        {
            AVPLicenceControl.LisansKontrolu(Application.StartupPath);

            this.radioButton1.Checked = true;
            this.radioGroup1.EditValue = 2;
        }

        private void HataGuncelleBTN_Click(object sender, EventArgs e)
        {
            //Uyap Çýktýsýný XML'e göndermeden önce foylerde eksik bilgi olup olmadýðý kontrolü
            //yapýlýyor. Hata yoksa son ekrana gönderiliyor varsa "Ýleri tuþu disable ediliyor";

            if (AdimAdimDavaKaydi.Util.Uyap.Helper.CheckUyap(foyler, this))
            {
                wizardControl1.SelectedPage = wpSon;
            }
            else
            {
                wizardPage2.AllowNext = false;
            }
        }

        private void HataGuncellemeCE_CheckedChanged(object sender, EventArgs e)
        {
            HataGuncelleBTN.Visible = !((DevExpress.XtraEditors.CheckEdit)sender).Checked;
        }

        private void mk_ColumnChanged(object sender, AV001_TI_BIL_ILAM_MAHKEMESIEventArgs e)
        {
            AV001_TI_BIL_ILAM_MAHKEMESI gonderen = (AV001_TI_BIL_ILAM_MAHKEMESI)sender;
            switch (e.Column)
            {
                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.BAKIYE_KARAR_HARCI_FAIZ_TIP_ID:
                    gonderen.BAKIYE_KARAR_HARCI_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value, gonderen.BAKIYE_KARAR_HARCI_DOVIZ_ID, DateTime.Today);
                    break;

                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.ILAM_TEBLIG_GIDER_FAIZ_TIP_ID:
                    gonderen.ILAM_TEBLIG_GIDER_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value, gonderen.ILAM_TEBLIG_GIDERI_DOVIZ_ID, DateTime.Today);
                    break;

                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.ILAM_VEKALET_UCRET_FAIZ_TIP_ID:
                    gonderen.ILAM_VEKALET_UCRET_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value, gonderen.ILAM_VEKALET_UCRETI_DOVIZ_ID, DateTime.Today);
                    break;

                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.INKAR_TAZMINAT_FAIZ_TIP_ID:
                    gonderen.INKAR_TAZMINAT_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value, gonderen.INKAR_TAZMINATI_DOVIZ_ID, DateTime.Today);
                    break;

                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.YARGILAMA_GIDERI_FAIZ_TIP_ID:
                    gonderen.YARGILAMA_GIDERI_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value, gonderen.YARGILAMA_GIDERI_DOVIZ_ID, DateTime.Today);
                    break;

                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.YARGITAY_ONAMA_HARCI_FAIZ_TIP_ID:
                    gonderen.YARGITAY_ONAMA_HARCI_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value, gonderen.YARGITAY_ONAMA_HARCI_DOVIZ_ID, DateTime.Today);
                    break;
            }
        }

        private void navBarControl1_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (HatalarNB.ItemLinks.Count == 0)
            {
                wizardControl1.SelectedPage = wpSon;
            }
        }

        private void navBarControl1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UyapHata secilenHata = HataliDosyalar[Convert.ToInt32(e.Link.Item.Tag)];
            _frmIcraTakip frm;
            frmAlacakNedenEkle frmANE;
            frmCariGenelGiris frmCari;
            frmKiymetliEvrakKayit frmKE;
            frmIcraIlamMahkemesiGiris frmIM;
            TList<AV001_TI_BIL_ILAM_MAHKEMESI> hataliMahkeme;
            this.UyapBildirim.geriBildirimYapilsin = HataGuncellemeCE.Checked;

            if (!HataGuncellemeCE.Checked)
            {
                if (sender is DevExpress.XtraNavBar.NavBarControl)
                {
                    e.Link.Item.Appearance.ForeColor = System.Drawing.Color.Green;
                }
            }
            switch (secilenHata.HataNedeni)
            {
                case "icra":

                    frm = (_frmIcraTakip)AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm.GetForm(AvukatProLib.Extras.FormType.IcraTakip);
                    frm.UyapBildirim = this.UyapBildirim;
                    frm.Show(secilenHata.HataliFoyEski.ID); break;
                case "icraAlacak":

                    frm = (_frmIcraTakip)AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm.GetForm(AvukatProLib.Extras.FormType.IcraTakip);
                    frm.UyapBildirim = this.UyapBildirim;
                    frm.Show(secilenHata.HataliFoyEski.ID);
                    frm.UyapAlacaklaraYonlendir();
                    frmANE = (frmAlacakNedenEkle)AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm.GetForm(AvukatProLib.Extras.FormType.AlacakNedenEkle);
                    frmANE.UyapBildirim = this.UyapBildirim;
                    frmANE.Show(secilenHata.HataliAlacakNedeni, secilenHata.HataliFoyEski); break;

                case "taraf":
                    frmANE = (frmAlacakNedenEkle)AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm.GetForm(AvukatProLib.Extras.FormType.AlacakNedenEkle);
                    frmANE.UyapBildirim = this.UyapBildirim;
                    frmANE.Show(secilenHata.HataliAlacakNedeni, secilenHata.HataliFoyEski); break;
                case "cari":
                    frmCari = (frmCariGenelGiris)AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm.GetForm(AvukatProLib.Extras.FormType.CariGenelGiris);
                    frmCari.YeniKayitMi = false;
                    frmCari.MyCari = secilenHata.HataliCari.FirstOrDefault();
                    frmCari.UyapBildirim = this.UyapBildirim;
                    frmCari.Show(); break;
                case "cariKimlik":
                    frmCari = (frmCariGenelGiris)AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm.GetForm(AvukatProLib.Extras.FormType.CariGenelGiris);
                    frmCari.MyCari = secilenHata.HataliCari.FirstOrDefault();
                    frmCari.YeniKayitMi = false;
                    frmCari.UyapBildirim = this.UyapBildirim;
                    frmCari.UyapKimlikDuzenle();
                    frmCari.Show(secilenHata.HataliCari); break;
                case "kiymetliEvrak":
                    frmKE = (AdimAdimDavaKaydi.Forms.frmKiymetliEvrakKayit)AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm.GetForm(AvukatProLib.Extras.FormType.KiymetliEvrakKayit);
                    frmKE.UyapBildirim = this.UyapBildirim;
                    TList<AV001_TDI_BIL_KIYMETLI_EVRAK> hataliEvrak = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
                    hataliEvrak.Add(secilenHata.HataliKiymetliEvrak);
                    DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(hataliEvrak, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));
                    frmKE.MyDataSource = hataliEvrak;
                    frmKE.Show(); break;
                case "kiraSozlesme":
                    AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout frmSoz = new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout();
                    frmSoz.EditMode = true;
                    frmSoz.UyapBildirim = this.UyapBildirim;
                    frmSoz.Show(secilenHata.HataliSozlesme);
                    break;

                case "ilamMahkeme":
                    frmIM = (frmIcraIlamMahkemesiGiris)AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm.GetForm(AvukatProLib.Extras.FormType.IcraIlamMahkemeGiris);
                    frmIM.UyapBildirim = this.UyapBildirim;
                    hataliMahkeme = new TList<AV001_TI_BIL_ILAM_MAHKEMESI>();
                    hataliMahkeme.Add(secilenHata.HataliIlamMahkemesi);
                    frmIM.MyDataSource = hataliMahkeme;
                    frmIM.Show(); break;
                case "ilamMahkemeBos":
                    frmIM = (frmIcraIlamMahkemesiGiris)AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm.GetForm(AvukatProLib.Extras.FormType.IcraIlamMahkemeGiris);
                    frmIM.UyapBildirim = this.UyapBildirim;
                    secilenHata.HataliFoyEski.AV001_TI_BIL_ILAM_MAHKEMESICollection = new TList<AV001_TI_BIL_ILAM_MAHKEMESI>();
                    secilenHata.HataliFoyEski.AV001_TI_BIL_ILAM_MAHKEMESICollection.AddingNew += AV001_TI_BIL_ILAM_MAHKEMESICollection_AddingNew;
                    frmIM.MyDataSource = secilenHata.HataliFoyEski.AV001_TI_BIL_ILAM_MAHKEMESICollection;
                    frmIM.Foy = secilenHata.HataliFoyEski;
                    frmIM.Show(); break;

                default:
                    break;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                radioGroup1.Visible = true;
            else
                radioGroup1.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Visible)
                radioGroup1.Visible = false;
            else
                radioGroup1.Visible = true;
        }

        private void wizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            this.Close();
        }

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            if (this.SecilenCiktiTipi == CiktiTipi.Uyap)
            {
                string tmpFile;

                if (this.UyapSecimi == AvukatProLib.Extras.UYAPIslemSecimi.Kayit)
                {
                    SaveFileDialog saveUyapBelgeDialog = new SaveFileDialog();
                    saveUyapBelgeDialog.Filter = "Uyap Çýktýsý|*.xml";

                    DialogResult result = saveUyapBelgeDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        tmpFile = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Templates) + "\\tmpuyap.xml";

                        System.IO.File.Copy(tmpFile, saveUyapBelgeDialog.FileName, true);
                        XtraMessageBox.Show("Uyap çýktýsý baþarýyla hazýrlandý.", "Tebrikler");
                    }
                }
                else if (this.UyapSecimi == AvukatProLib.Extras.UYAPIslemSecimi.Mail)
                {
                    tmpFile = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Templates) + "\\tmpuyap.xml";

                    System.IO.File.Copy(tmpFile, "UYAP Çýktýsý.xml", true);

                    List<string> filepaths = new List<string>();
                    filepaths.Add("UYAP Çýktýsý.xml");
                    AV001_TDI_BIL_CARI cari = null;
                    if (Kimlikci.Kimlik != null && Kimlikci.Kimlik.Cari_ID != null)
                        cari = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(Kimlikci.Kimlik.Cari_ID);

                    frmMailSender mailSender;
                    if (cari != null)
                    {
                        if (!String.IsNullOrEmpty(cari.EMAIL_1))
                        {
                            mailSender = new frmMailSender(cari.EMAIL_1, filepaths);
                            mailSender.ShowDialog();
                        }
                        else
                        {
                            mailSender = new frmMailSender(filepaths);
                            mailSender.ShowDialog();
                        }
                    }
                    else
                    {
                        mailSender = new frmMailSender(filepaths);
                        mailSender.ShowDialog();
                    }
                }
                this.Close();
            }
            else if (this.SecilenCiktiTipi != CiktiTipi.Uyap)
            {
                if (cePaketleriYazdir.Checked)
                    SeciliRaporlar = new List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>();

                List<object> liste = new List<object>();

                List<int> eklenenler = new List<int>();

                foreach (Ciktilar item in AlinacakCiktilar)
                {
                    liste.Add(((System.Data.DataRow)(item.Kayit)));
                    if (cePaketleriYazdir.Checked)
                    {
                        ABSqlConnection cn = new ABSqlConnection();
                        cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                        cn.AddParams("@FORM_ID", ((System.Data.DataRow)(item.Kayit))["FORM_TIP_ID"]);
                        DataTable dt = cn.GetDataTable("SELECT SABLON_ID FROM dbo.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAY(nolock) WHERE YAZDIRMA_AYAR_ID in   (SELECT ID FROM dbo.AV001_TI_BIL_YAZDIRMA_AYARLARI(nolock) WHERE FORM_ID=@FORM_ID)");

                        foreach (DataRow row in dt.Rows)
                        {
                            AvukatProLib.Arama.AvpDataContext xx = new AvukatProLib.Arama.AvpDataContext(Kimlikci.Kimlik.SirketBilgisi.ConStr);
                            AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR aa = xx.VDIE_BIL_SABLON_RAPORs.Where(vi => vi.ID == (int)row["SABLON_ID"]).ToList()[0];
                            if (!eklenenler.Contains(aa.ID))
                            {
                                eklenenler.Add(aa.ID);
                                SeciliRaporlar.Add(aa);
                            }
                        }
                    }
                }

                frmEditor SelectedEditor = new frmEditor();
                frmIstek istek = new frmIstek();

                for (int i = 0; i < this.SelectedList.Count; i++)
                {
                    if (SelectedList[i] is DataRow)
                    {
                        VList<per_AV001_TI_BIL_ICRA_Arama> tmp = DataRepository.per_AV001_TI_BIL_ICRA_AramaProvider.Get("ID=" + ((DataRow)this.SelectedList[i])["ID"], "ID");
                        istek.Foyler.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(tmp[0].ID));
                        if (!seciliFoyIDleri.Contains(tmp[0].ID))
                            seciliFoyIDleri.Add(tmp[0].ID);
                    }
                    else
                    {
                        istek.Foyler.Add(((AV001_TI_BIL_FOY)SelectedList[i]));
                        if (!seciliFoyIDleri.Contains(((AV001_TI_BIL_FOY)SelectedList[i]).ID))
                            seciliFoyIDleri.Add(((AV001_TI_BIL_FOY)SelectedList[i]).ID);
                    }
                }

                string resultstring = istek.LoadFromList(SeciliRaporlar);
                string BarkodTip = resultstring.Split('-')[0].ToString();// barkod tipini kullanýcaz
                DialogResult dialogResult = resultstring.Split('-')[1].ToString() == "OK" ? DialogResult.OK : DialogResult.Cancel;
                if (dialogResult == DialogResult.Cancel)
                    return;

                if (istek.PostaListesiVarmi)
                {
                    frmPostaListesiYazdir frm = new frmPostaListesiYazdir(liste);
                    frm.Show();
                }

                if (istek.list is List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>)
                {
                    List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> dlstRaporlar = ((List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>)istek.list);

                    if (SelectedEditor == null || SelectedEditor.IsDisposed)
                    {
                        SelectedEditor = new frmEditor();
                        SelectedEditor.MdiParent = mdiAvukatPro.MainForm;
                    }

                    SelectedEditor.OpenAllSablonForThreadMulti(dlstRaporlar, liste, BarkodTip, liste, cePaketleriYazdir.Checked);
                }
            }
            this.Close();
        }

        private void wizardControl1_SelectedPageChanged(object sender, DevExpress.XtraWizard.WizardPageChangedEventArgs e)
        {
            if (radioButton3.Checked)
            {
                radioGroup1.EditValue = 2;
            }
            if (e.Page == wpSon)
            {
                if (this.SecilenCiktiTipi == CiktiTipi.Uyap)
                {
                    using (frmUyapIslemSecimi frm = new frmUyapIslemSecimi())
                    {
                        frm.ShowDialog();
                        this.UyapSecimi = frm.UYAPSecimi;
                    }

                    if (this.UyapSecimi == AvukatProLib.Extras.UYAPIslemSecimi.Kayit)
                        wizardControl1.FinishText = "&Kaydet";

                    if (e.PrevPage == wizardPage2)
                        AdimAdimDavaKaydi.Util.Uyap.Helper.SaveUyap(foyler, this);
                    return;
                }
            }
            if (e.Page.Name == "wpKayit")
            {
                object selVal = radioGroup1.EditValue;
                if (selVal is int)
                {
                    if ((int)selVal == 2)
                    {
                        this.ucIcraFoy1.Visible = true;
                        this.ucDavaAramaFoy1.Visible = false;
                        this.ucModulArama1.Modul = AvukatProLib.Extras.ModulTip.Icra;
                        if (this.ucIcraFoy1.MyDataSource != null && this.ucIcraFoy1.MyDataSource.Rows.Count > 0)
                        {
                            this.ucIcraFoy1.MyDataSource = (DataTable)this.ucModulArama1.Ara();
                        }
                        else
                        {
                            this.ucIcraFoy1.MyDataSource = (DataTable)this.ucModulArama1.Ara();
                        }
                    }
                    else if ((int)selVal == 1)
                    {
                        this.ucIcraFoy1.Visible = false;
                        this.ucDavaAramaFoy1.Visible = true;
                        this.ucModulArama1.Modul = AvukatProLib.Extras.ModulTip.Dava;
                        if (this.ucDavaAramaFoy1.MyDataSource != null && this.ucDavaAramaFoy1.MyDataSource.Rows.Count > 0)
                        {
                            this.ucDavaAramaFoy1.MyDataSource = (DataTable)this.ucModulArama1.Ara();
                        }
                        else
                        {
                            this.ucDavaAramaFoy1.MyDataSource = (DataTable)this.ucModulArama1.Ara();
                        }
                    }

                }
            }
            if (e.PrevPage != null && e.Page.Name == "wizardPage2")
            {
                if (e.PrevPage.Name == "wizardPage1")
                {
                    if (this.SecilenCiktiTipi == CiktiTipi.Uyap)
                    {
                        foyler = new List<per_AV001_TI_BIL_ICRA_Arama>();
                        for (int i = 0; i < this.SelectedList.Count; i++)
                        {
                            if (SelectedList[i] is DataRow)
                            {
                                VList<per_AV001_TI_BIL_ICRA_Arama> tmp = DataRepository.per_AV001_TI_BIL_ICRA_AramaProvider.Get("ID=" + ((DataRow)this.SelectedList[i])["ID"], "ID");
                                foyler.Add(tmp[0]);
                            }
                            else
                            {
                                VList<per_AV001_TI_BIL_ICRA_Arama> foyum = DataRepository.per_AV001_TI_BIL_ICRA_AramaProvider.Get("ID=" + ((AV001_TI_BIL_FOY)SelectedList[i]).ID, "ID");
                                foyler.Add(foyum[0]);
                            }
                        }

                        //Uyap Çýktýsýný XML'e göndermeden önce foylerde eksik bilgi olup olmadýðý kontrolü
                        //yapýlýyor. Hata yoksa son ekrana gönderiliyor varsa "Ýleri tuþu disable ediliyor";

                        if (AdimAdimDavaKaydi.Util.Uyap.Helper.CheckUyap(foyler, this))
                        {
                            wizardControl1.SelectedPage = wpSon;
                        }
                        else
                        {
                            wizardPage2.AllowNext = false;
                        }
                    }
                    else
                    {
                        wpSon.Text = "Son Adým. Ýþlemi tamamlamak için bitire basýnýz.";
                        wizardControl1.SelectedPage = wpSon;
                    }
                }
            }
            if (e.Page.Name == "wpSablon")
            {
                bool degiskeniVarmi = false;
                if (!DisaridanCagirildi)
                {
                    this.SelectedList = new List<object>();
                }

                if (this.ucIcraFoy1.MyDataSource != null && this.ucModulArama1.Modul == AvukatProLib.Extras.ModulTip.Icra)
                {
                    for (int i = 0; i < this.ucIcraFoy1.MyDataSource.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(this.ucIcraFoy1.MyDataSource.Rows[i]["IsSelected"]))
                        {
                            this.SelectedList.Add(ucIcraFoy1.MyDataSource.Rows[i]);
                        }
                    }
                    if (!cePaketleriYazdir.Checked && this.SelectedList.Count <= 0)
                    {
                        DialogResult dr =
                            XtraMessageBox.Show("Hiç bir seçim yapmadýnýz! Tüm kayýtlarý göndermek ister misiniz ?",
                                                "Hiç bir kaydý seçmediniz!", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            for (int i = 0; i < this.ucIcraFoy1.MyDataSource.Rows.Count; i++)
                            {
                                this.SelectedList.Add(ucIcraFoy1.MyDataSource.Rows[i]);
                            }
                        }
                        else
                        {
                            this.wizardControl1.SelectedPage = wpKayit;
                        }
                    }
                }

                if (this.ucDavaAramaFoy1.MyDataSource != null && this.ucModulArama1.Modul == AvukatProLib.Extras.ModulTip.Dava)
                {
                    for (int i = 0; i < this.ucDavaAramaFoy1.MyDataSource.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(this.ucDavaAramaFoy1.MyDataSource.Rows[i]["IsSelected"]))
                        {
                            this.SelectedList.Add(ucDavaAramaFoy1.MyDataSource.Rows[i]);
                        }
                    }
                    if (!cePaketleriYazdir.Checked && this.SelectedList.Count <= 0)
                    {
                        DialogResult dr =
                            XtraMessageBox.Show("Hiç bir seçim yapmadýnýz! Tüm kayýtlarý göndermek ister misiniz ?",
                                                "Hiç bir kaydý seçmediniz!", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            for (int i = 0; i < this.ucDavaAramaFoy1.MyDataSource.Rows.Count; i++)
                            {
                                this.SelectedList.Add(ucDavaAramaFoy1.MyDataSource.Rows[i]);
                            }
                        }
                        else
                        {
                            this.wizardControl1.SelectedPage = wpKayit;
                        }
                    }
                }

                if (e.PrevPage != null && e.PrevPage.Name == "wizardPage1")
                {
                    if (this.SecilenCiktiTipi == CiktiTipi.Uyap)
                    {
                        this.wizardControl1.SelectedPage = wpKayit;
                        return;
                    }
                }

                if (radioButton1.Checked)
                {
                    this.SecilenCiktiTipi = CiktiTipi.Otomatik_Alan;
                    degiskeniVarmi = true;
                }

                if (radioButton2.Checked)
                {
                    this.SecilenCiktiTipi = CiktiTipi.Kalip_Sablon;
                    degiskeniVarmi = false;
                }

                if (radioButton3.Checked)
                {
                    this.SecilenCiktiTipi = CiktiTipi.Uyap;
                    wizardControl1.SelectedPage = wizardPage1;
                }

                if (this.ucSablonRapor1.MyDataSource == null || this.ucSablonRapor1.MyDataSource.Count == 0)
                {
                    if (BelgeUtil.Inits._SablonRaporGetir != null)
                    {
                        this.ucSablonRapor1.MyDataSource = BelgeUtil.Inits._SablonRaporGetir.FindAll(item => item.MODUL_ID == (int)this.ucModulArama1.Modul && item.DEGISKENI_VARMI == degiskeniVarmi);
                    }
                    else
                        this.ucSablonRapor1.MyDataSource = BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.Where(item => item.MODUL_ID == (int)this.ucModulArama1.Modul && item.DEGISKENI_VARMI == degiskeniVarmi).ToList();
                }

                if (cePaketleriYazdir.Checked)
                {
                    //if (e.Direction == DevExpress.XtraWizard.Direction.Forward)
                    wizardControl1.Pages[wizardControl1.SelectedPageIndex].Hide();
                    //else
                    //    wizardControl1.SelectedPageIndex = wizardControl1.SelectedPageIndex - 1;
                }
            }

            if (e.Page.Name == "wpAyarlar")
            {
                this.SeciliRaporlar = this.ucSablonRapor1.MyDataSource.FindAll(vi => vi.IsSelected);

                if (this.SeciliRaporlar.Count <= 0)
                {
                    DialogResult dr =
                        XtraMessageBox.Show("Hiç bir seçim yapmadýnýz! Tüm kayýtlarý göndermek ister misiniz ?",
                                            "Hiç bir kaydý seçmediniz!", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        this.SeciliRaporlar.AddRange(this.ucSablonRapor1.MyDataSource);
                    }
                    else
                    {
                        this.wizardControl1.SelectedPage = wpSablon;
                    }
                }

                this.ucIcraSablonAyar1.DataSource = this.SeciliRaporlar;
            }

            if (e.Page.Name == "wizardPage1")
            {
                this.AlinacakCiktilar = new List<Ciktilar>();
                if (this.SecilenCiktiTipi == CiktiTipi.Uyap)
                {
                    for (int i = 0; i < this.SelectedList.Count; i++)
                    {
                        Ciktilar ckt = new Ciktilar();
                        ckt.UyapMi = true;
                        ckt.Kayit = this.SelectedList[i];

                        if (SelectedList[i] is DataRow)
                            ckt.No = ((DataRow)SelectedList[i])["FOY_NO"].ToString();
                        else if(SelectedList[i] is AV001_TI_BIL_FOY)
                            ckt.No = ((AV001_TI_BIL_FOY)SelectedList[i]).FOY_NO;
                        else if (SelectedList[i] is AV001_TD_BIL_FOY)
                            ckt.No = ((AV001_TD_BIL_FOY)SelectedList[i]).FOY_NO;

                        AlinacakCiktilar.Add(ckt);
                    }

                    this.listBox1.DataSource = AlinacakCiktilar;
                }
                else
                {
                    this.SeciliRaporlar = ucSablonRapor1.MyDataSource.FindAll(vi => vi.IsSelected);

                    if (!this.cePaketleriYazdir.Checked && this.SeciliRaporlar.Count <= 0)
                    {
                        DialogResult dr =
                            XtraMessageBox.Show("Hiç bir seçim yapmadýnýz! Tüm kayýtlarý göndermek ister misiniz ?",
                                                "Hiç bir kaydý seçmediniz!", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            this.SeciliRaporlar.AddRange(this.ucSablonRapor1.MyDataSource.ToArray());
                        }
                        else
                        {
                            this.wizardControl1.SelectedPage = wpSablon;
                        }
                    }

                    for (int i = 0; i < this.SelectedList.Count; i++)
                    {
                        //for (int y = 0; y < this.SeciliRaporlar.Count; y++)
                        //{
                        Ciktilar ckt = new Ciktilar();
                        ckt.Kayit = this.SelectedList[i];

                        if (SelectedList[i] is AV001_TDIE_BIL_SABLON_RAPOR)
                        {
                            TList<AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARI> ayarlar = (SelectedList[i] as AV001_TDIE_BIL_SABLON_RAPOR).AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARICollectionGetBySABLON_ID;
                            for (int z = 0; z < ayarlar.Count; z++)
                            {
                                List<Ciktilar> ciktilar = EditorHelper.GetirAyaraGoreSablonlari(ayarlar[z], (IEntity)this.SelectedList[i]);
                                if (ciktilar != null)
                                {
                                    AlinacakCiktilar.AddRange(ciktilar);
                                }
                            }
                        }
                        ckt.UyapMi = false;
                        //ckt.No = ((AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama)SelectedList[i]).FOY_NO;
                        ckt.No = ((DataRow)SelectedList[i])["FOY_NO"].ToString();
                        AlinacakCiktilar.Add(ckt);

                        //}
                    }
                    this.listBox1.DataSource = AlinacakCiktilar.OrderBy(vi => vi.No).ToList();
                }
            }
            this.listBox1.Refresh();
        }
    }

    public class Ciktilar
    {
        public AV001_TDIE_BIL_SABLON_RAPOR AnaRapor { get; set; }

        public object Kayit { get; set; }

        public string No { get; set; }

        public AV001_TDIE_BIL_SABLON_RAPOR Rapor { get; set; }

        public Taraf Tarafi { get; set; }

        public bool UyapMi { get; set; }

        public override string ToString()
        {
            if (UyapMi)
            {
                return No + " numarali dosya ile UYAP çýktýsý almak istiyorum" + Environment.NewLine;
            }
            else
            {
                //return this.Rapor.AD + " dosyasýný " + No + " numarali dosya ile yazdýracaðým";
                return " dosyasýný " + No + " numarali dosya ile yazdýracaðým";
            }

        }
    }
    public class Taraf
    {
        public AV001_TD_BIL_FOY_SORUMLU_AVUKAT DavaSorumluAvukat { get; set; }

        public AV001_TD_BIL_FOY_TARAF DavaTaraf { get; set; }

        public AV001_TD_BIL_FOY_TARAF_VEKIL DavaVekil { get; set; }

        public AV001_TI_BIL_FOY_SORUMLU_AVUKAT IcraSorumluAvukat { get; set; }

        public AV001_TI_BIL_FOY_TARAF IcraTaraf { get; set; }

        public AV001_TI_BIL_FOY_TARAF_VEKIL IcraVekil { get; set; }

        public AV001_TDI_BIL_TEBLIGAT_MUHATAP TebligatMuhatap { get; set; }
    }
}