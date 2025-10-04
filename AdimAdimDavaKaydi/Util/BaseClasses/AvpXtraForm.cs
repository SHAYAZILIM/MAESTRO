using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using AdimAdimDavaKaydi.PaketKontrol;
using AdimAdimDavaKaydi.Util.BaseClasses.AvpFormClass.AvpFormUtil;
using AdimAdimDavaKaydi.Util.BaseClasses.AvpFormData;
using AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement;
using AvukatProLib.Util;
using AvukatProLib2.Entities;
using Datas.TablesColumn;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Util.BaseClasses
{
    //TODO: EVENTLERÝ YAPILACAK KULLANAN ARKADAÞ için ...
    //c_titemUYAP
    //c_titemEditorSihirbaz

    /*Form Standartlari

     * CASING :
     *      Methods, Events and Properties : Pascal Casing
     *      Controls Names,Fields and Parameters : Camel Casing

        Form uzerindeki controllerin tumunun isimleri c_ + controlun tipinin kýsaltýlmýþ ufak harkli adý þeklinde baþlar. Örnek : c_titemKaydet => c_(control) + titem(Tool Tip Item) + Kaydet (Butonun iþlevi)
     * menudeki alt butonlar ustundeki butonun adýnýda kendisine on ek olarak almýstýr.
         ornek : c_titemDosyaYeniIcraKaydiStandartForm  þeklinde. burada Dosyaaltýndaki Yeni icra dosyasý altýnda standart form ile kayýtý ifade ediyoruz.
     * c_ ile ifade etmemizin sebebi de controlleri fieldlardan ayýrabilmek.
     * Form üzerinde tanýmlý FormunTipi ve FormunBolumu ozellikleri her formda ayyarlanacaktýr ve bu özellikler yardýmý ile form üzerindeki menu ve diðer araçlar þekillenir.
     * Form üzerinde þu an yapýmý devam eden butonlar visible=false olarak ayrlanmýþtýr.
     * metodlar arasýnda birer satýr boþluk býrakýlmýþtýr.
     * Propertyler Properties , Eventlar Events , Design ile ilgikodlar Design seklinde regionlarla bolunmuþtur.Ayrýca diðer metod ve özelliklerde Regionlarla ayrýlmýþtýr.
     * Form üzerindeki menu de bulunan nesnelere týklanýnca çalýþacak olan metodlarýn içerisine hemen altýnda yapýlacak iþin ifade edildiði bir isimle tanýmnlanmýþ virtual olarak tanýmlý metodlar çaðýrýlmýþtýr. Ayrýca her metod için öncesinde ve sonrasýnda çalýþacak eventlar yazýlmýþ ve çaðýrýlmadanönce null kontrolleride yapýlmýþtýr.
            Örnek :
                c_titemYeni_click(...)
                {
                     if(YeniKayitCalisacak!=null)
                     {
                        YeniKayitCalisacak();
                     }

                     Yeni();

                     if(YeniKayitCalisacak!=null)
                     {
                        YeniKayitCalisti();
                     }
                }
                public virtual void Yeni()
                {
                }
     * her iþlem için event ve delegatet ler tanýmlýdýr. Bu delegateler ayrý bir doyada tutulmaktadýr.
     */

    [Serializable]
    public class AvpXtraForm : XtraForm, IYetkilendirilebilir
    {
        #region Fields

        private bool _EventlerKullanilacakMi;
        public PanelControl c_pnlSag = new PanelControl();
        public PanelControl c_pnlSol = new PanelControl();
        public ToolStripButton c_titemIhtarname;
        public ToolStripButton c_titemMasraf;
        private ToolStripButton c_titemEditorSihirbaz;
        private ToolStripButton c_titemUYAP;
        public PanelControl c_pnlAltButtons;
        public PanelControl c_pnlFormSakla;
        public SimpleButton c_btnUstKose;
        public SimpleButton c_btnFormuYukle;
        public SimpleButton c_btnIptal;
        public SimpleButton c_btnTamam;
        private DateTime timespanBas;
        private bool _AnaFormMu;
        public object Current;
        public AvpDatas CurrentDatas;
        private AvpDataSource myDataSource;
        private FormTipi _formunTipi = FormTipi.Standart;
        private FormBolumu _formunBolumu = FormBolumu.Diger;
        private bool _useAutoDataOperations;
        private AvpDatas seciliKayitlar;
        private bool _FormuSakla;
        private string uniqueFormID;
        private int _AcilanFormSayisi;
        private ToolStrip c_tstMenuOzelIslemler;
        private ToolStripButton c_titemAjanda;
        private ToolStripButton c_titemTakipYazismalari;
        public ToolStripButton c_titemIliskiliDosyalar;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem contextModuleEkle;
        private ContextMenuStrip cmYetkilendirme;
        public PanelControl c_pnlContainer;
        private OpenFileDialog c_opfFormuKaydet;
        private ToolStrip c_tstmenuUstDigerMenu;
        private ToolStripMenuItem c_titemOfisIslemleriXml;
        private ToolStripMenuItem c_titemOfisIslemleriRtf;
        private ToolStripMenuItem c_titemOfisIslemleriHtml;
        internal ToolStripButton c_titemYenile;
        private ToolStrip c_tsmenuUst3;
        private ToolStripContainer toolStripContainer1;
        internal ToolStripButton c_titemHesaplanmisKalemler;
        private ToolStripButton c_titemIhtiyatiHaciz;
        private ToolStripButton c_titemIhtiyatiTedbir;
        private ToolStripButton c_titemIlamBilgileri;
        private ToolStripButton c_titemMahsupBilgileri;
        public ToolStripButton c_titemTakipOncesiOdemeleri;
        private ToolStripButton c_titemDavaOncesiOdeme;

        #endregion Fields

        #region properties

        /// <summary>
        /// Otomatik veri iþlemlerini kullanmak istermisiniz?
        /// </summary>
        public bool UseAutoDataOperations
        {
            get { return _useAutoDataOperations; }
            set { _useAutoDataOperations = value; }
        }

        /// <summary>
        /// Ust Menu gorunsun mu ?
        /// </summary>
        [Category("Extended Properties")]
        public bool UstMenu
        {
            get; //{ return this.c_pnlUst.Visible; }
            set; //{ this.c_pnlUst.Visible = value; }
        }

        /// <summary>
        /// AltKýsým Gorunsun mu?
        /// </summary>
        [Category("Extended Properties")]
        public bool AltMenu
        {
            get; // { return this.c_pnlAlt.Visible; }
            set; // { this.c_pnlAlt.Visible = value; }
        }

        [Browsable(false)]
        public bool Formusakla
        {
            get { return _FormuSakla; }
            set { _FormuSakla = value; }
        }

        /// <summary>
        /// Hareketli ToolBox menusu gorunsun mu ?
        /// </summary>
        public bool HareketliMenu
        {
            get { return this.c_tsUstMenu.Visible; }
            set { this.c_tsUstMenu.Visible = value; }
        }

        /// <summary>
        /// Form bir ana giriþ formu mu?
        /// </summary>
        [Browsable(false)]
        public bool AnaFormMu
        {
            get { return _AnaFormMu; }
            set
            {
                _AnaFormMu = value;
                this.UstMenu = value;
                this.AltMenu = value;
                this.HareketliMenu = false;
            }
        }

        [Category("Extended Properties")]
        public string UniqueFormID
        {
            get { return uniqueFormID; }
            set { uniqueFormID = value; }
        }

        /// <summary>
        /// Formumuzun Tipi, Bir kayit ekranýmý, izleme ekranýmý. Bu ozellige gore form uzerindeki gorunum degisir.Menuler ayarlanýr.
        /// </summary>
        [Category("Extended Properties")]
        public FormTipi FormunTipi
        {
            get { return _formunTipi; }
            set
            {
                _formunTipi = value;
                FormuSekillendir(value);
            }
        }

        /// <summary>
        /// Formumuzun hangi bolumde çalýþtýðý,Belge mi? iþ mi? , icra mý ?. Bu ozellige gore form uzerindeki gorunum degisir.Menuler ayarlanýr.
        /// </summary>
        [Category("Extended Properties")]
        public FormBolumu FormunBolumu
        {
            get { return _formunBolumu; }
            set
            {
                _formunBolumu = value;
                FormuSekillendir(value);
            }
        }

        /// <summary>
        /// form uzerinde kullanýlan datasourcelar.
        /// </summary>
        [Browsable(false)]
        public virtual AvpDataSource MyIEntityDataSource
        {
            get
            {
                if (DesignMode || this.myDataSource == null)
                {
                    return null;
                }
                return myDataSource;
            }
            set
            {
                if (value != null && !DesignMode)
                {
                    AvpFormAvpDataSourceEventArgs e = new AvpFormAvpDataSourceEventArgs();
                    e.DataSource = value;
                    if (VerilerYuklenecek != null)
                    {
                        VerilerYuklenecek(value, e);
                    }

                    myDataSource = value;
                    if (VerilerYuklendi != null)
                    {
                        VerilerYuklendi(value, e);
                    }
                }
            }
        }

        [Browsable(false)]
        public virtual AvpDatas SeciliKayitlar
        {
            get
            {
                if (DesignMode || this.myDataSource == null)
                {
                    return null;
                }
                return seciliKayitlar;
            }
            set
            {
                if (value != null && !DesignMode)
                {
                    AvpFormDataEventArgs e = new AvpFormDataEventArgs();
                    e.Data = value;
                    SeciliKayitlarYuklenecek(value, e);
                    seciliKayitlar = value;
                    SeciliKayitlarYuklendi(value, e);
                }
            }
        }

        [Category("Extended Properties")]
        public ToolStripItemCollection UstMenuler
        {
            get { return AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm.c_mnUstMenu.Items; }
            //    set { _UstMenuler = value; }
        }

        [Category("Extended Properties")]
        public ToolStripItemCollection UstHareketliMenu
        {
            get { return this.c_tsUstMenu.Items; }
            //    set { _UstHareketliMenu = value; }
        }

        [Category("Extended Properties")]
        public ToolStripItemCollection UstHareketliMenu2
        {
            get { return this.c_tstmenuUstDigerMenu.Items; }
        }

        [Category("Extended Properties")]
        public ToolStripItemCollection UstHareketliMenu3
        {
            get { return this.c_tsmenuUst3.Items; }
        }

        [Category("Extended Properties")]
        public ToolStripItemCollection DockPaneller
        {
            get { return AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm.c_titemYardimciAlanlar.DropDownItems; }
        }

        private AvpDataSource _newDataSource;

        [Browsable(false)]
        public AvpDataSource NewDataSource
        {
            get { return _newDataSource; }
            set
            {
                if (value != null && !DesignMode)
                {
                    _newDataSource = value;
                    value.VeriEklendi += value_VeriEklendi;
                }
            }
        }

        #endregion properties

        #region Events

        public event OnYeniKayit YeniKayit;

        public event OnYeniKayit YeniKaydedildi;

        public event OnAc DosyaAc;

        public event OnAc DosyaAcildi;

        public event OnFarkliKayit FarkliKaydet;

        public event OnFarkliKayit FarkliKaydedildi;

        public event OnKayit DosyaKaydet;

        public event OnKayit DosyaKaydedildi;

        public event OnYeniKayit YeniDosya;

        public event OnSil Sil;

        public event OnSil Silindi;

        public event OnKes Kes;

        public event OnKes Kesildi;

        public event OnKopyala Kopyala;

        public event OnKopyala Kopyalandi;

        public event OnYapistir Yapistir;

        public event OnYapistir Yapistirildi;

        public event OnGeriAl GeriAl;

        public event OnGeriAl GeriAlindi;

        public event OnYenidenAl Yeniden;

        public event OnYenidenAl YenidenAlindi;

        public event OnYazdir Yazdir;

        public event OnYazdir Yazdirildi;

        public event OnTarihce Tarihce;

        public event OnTarihce TarihceAcildi;

        public event OnGizle Gizle;

        public event OnGizle Gizlendi;

        public event OnHesapla Hesapla;

        public event OnHesapla Hesaplandi;

        public event OnVerilerYuklenecek VerilerYuklenecek;

        public event OnVerilerYuklenecek VerilerYuklendi;

        public event OnSeciliKayitlarDegistirme SeciliKayitlarYuklenecek;

        public event OnSeciliKayitlarDegistirme SeciliKayitlarYuklendi;

        public event OnGonder ExceleGonderildi;

        public event OnGonder PdfeGonderildi;

        public event OnGonder EditoreGonderildi;

        public event OnGonder WordeGonderildi;

        public event OnGonder OutlookaGonderildi;

        public event OnAddData AddingData;

        public event OnAddData AddedData;

        public event OnAddData CustomDefaultValues;

        public event OnDigerMenuItemClick DigerMenuButonClick;

        public event OnDigerMenuItemClick DigerMenuButonClicked;

        public event OnAjandayaGonder AjandayaGonderilcek;

        public event OnAjandayaGonder AjandayaGonderildi;

        public event OnTakipYazismalari TakipYazismlariGonderilcek;

        public event OnTakipYazismalari TakipYazismlariGonderildi;

        public event OnIliskiliDosyalar IliskiliDosyalaraGonderilcek;

        public event OnIliskiliDosyalar IliskiliDosyalaraGonderildi;

        #region Kaya'nýn ekledikleri

        public event EventHandler<EventArgs> Button_Uyap_Click;

        public event EventHandler<EventArgs> Button_AdimAdimEditore_Click;

        public event EventHandler<EventArgs> Button_HesaplanmisKalemler_Click;

        public event EventHandler<EventArgs> Button_IhtiyatiHaciz_Click;

        public event EventHandler<EventArgs> Button_IhtiyatiTedbir_Click;

        public event EventHandler<EventArgs> Button_IlamBilgileri_Click;

        public event EventHandler<EventArgs> Button_MahsupBilgileri_Click;

        public event EventHandler<EventArgs> Button_TakipOncesiOdemeleri_Click;

        public event EventHandler<EventArgs> Button_DavaOncesiOdeme_Click;

        public event EventHandler<EventArgs> Button_Ajanda_Click;

        public event EventHandler<EventArgs> Button_TakipYazismalari_Click;

        public event EventHandler<EventArgs> Button_Yeni_Click;

        public event EventHandler<EventArgs> Button_Ac_Click;

        public event EventHandler<EventArgs> Button_Kaydet_Click;

        public event EventHandler<EventArgs> Button_Tamam_Click;

        public event EventHandler<EventArgs> Button_Iptal_Click;

        public event EventHandler<EventArgs> Button_FarkliKaydet_Click;

        public event EventHandler<EventArgs> Button_Sil_Click;

        public event EventHandler<EventArgs> Button_Kes_Click;

        public event EventHandler<EventArgs> Button_Kopyala_Click;

        public event EventHandler<EventArgs> Button_Yapistir_Click;

        public event EventHandler<EventArgs> Button_GeriAl_Click;

        public event EventHandler<EventArgs> Button_Yeniden_Click;

        public event EventHandler<EventArgs> Button_Yazdir_Click;

        public event EventHandler<EventArgs> Button_Tarihce_Click;

        public event EventHandler<EventArgs> Button_Gizle_Click;

        public event EventHandler<EventArgs> Button_Hesapla_Click;

        public event EventHandler<EventArgs> Button_Editor_Click;

        public event EventHandler<EventArgs> Button_Word_Click;

        public event EventHandler<EventArgs> Button_Outlook_Click;

        public event EventHandler<EventArgs> Button_Excel_Click;

        public event EventHandler<EventArgs> Button_PDF_Click;

        public event EventHandler<EventArgs> Button_XML_Click;

        public event EventHandler<EventArgs> Button_RTF_Click;

        public event EventHandler<EventArgs> Button_HTML_Click;

        public event EventHandler<EventArgs> Button_Ihtarname_Click;

        public event EventHandler<EventArgs> Button_Masraf_Click;

        public event EventHandler<EventArgs> Button_IliskiliDosyalar_Click;

        #endregion Kaya'nýn ekledikleri

        #region Canan Events

        #region EventntArgs

        /// <summary>
        /// event Ýçin gerekli Properties ve Metotlarý yazýldý
        /// </summary>
        public class FrmIcraDosyaKayitEventArgs : EventArgs
        {
            public AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit MyForm { get; set; }

            public FrmIcraDosyaKayitEventArgs(AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit form)
            {
                MyForm = form;
            }
        }

        public class FrmVekaletDosyaKayitEventArgs : EventArgs
        {
            public frmTemsilKayit MyForm { get; set; }

            public FrmVekaletDosyaKayitEventArgs(frmTemsilKayit form)
            {
                MyForm = form;
            }
        }

        #endregion EventntArgs


        #endregion Canan Events

        #endregion Events

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            ObjectDisposing.DisposeDataSources(this);
            ObjectDisposing.DisposeAllChild(this);
            ObjectDisposing.DisposeObject(this);
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }
        #endregion

        public AvpXtraForm()
        {
            try
            {
                this.MdiParent = AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm;
                timespanBas = DateTime.Now;
                this.InitializeComponent();
                _EventlerKullanilacakMi = true;
                FormTutucu.Forms.Add(this);
                this.BackColor = System.Drawing.SystemColors.Control;
                this.Icon = new System.Drawing.Icon(this.Icon, new System.Drawing.Size(5, 5));
                this.StartPosition = FormStartPosition.CenterParent;
            }
            catch { ;}
        }

        public bool EventlerKullanilacakMi
        {
            get { return _EventlerKullanilacakMi; }
            set { _EventlerKullanilacakMi = value; }
        }
        public event EventHandler OnLoadPacket;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                this.GetPaketForm();
                if (this.OnLoadPacket != null)
                    this.OnLoadPacket(this, null);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        private void value_VeriEklendi(object sender, AvpFormDataEventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            if (e.Data.Datas is BindingList<object>)
            {
                (e.Data.Datas as BindingList<object>).AddingNew += AvpXtraForm_AddingNew;
            }
        }

        /// <summary>
        /// Form tipine gore formu ayarlar
        /// </summary>
        /// <param name="formunTipi"></param>
        private void FormuSekillendir(FormTipi formunTipi)
        {
            switch (formunTipi)
            {
                case FormTipi.Standart:
                    break;
                case FormTipi.GirisFormu:

                    this.c_tsmenuUst3.Visible = false;
                    this.c_tstMenuOzelIslemler.Visible = false;
                    this.c_tstmenuUstDigerMenu.Visible = false;
                    this.c_tsUstMenu.Visible = true;

                    break;
                case FormTipi.AramaFormu:
                    this.c_tsmenuUst3.Visible = false;
                    this.c_tstMenuOzelIslemler.Visible = false;
                    this.c_tstmenuUstDigerMenu.Visible = false;
                    this.c_tsUstMenu.Visible = true;
                    break;
                case FormTipi.TakipFormu:
                    break;
                case FormTipi.AnaKayitFormu:
                    break;
                case FormTipi.KayitFormu:
                    break;
                case FormTipi.UfakKayitFormu:
                    break;
                case FormTipi.IzlemeFormu:
                    break;
                case FormTipi.KodFormu:
                    break;
                case FormTipi.RaporFormu:
                    break;
                case FormTipi.Genel:
                    break;
                case FormTipi.Diger:
                    break;
                case FormTipi.Sihirbaz:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// formun ilgili oldugu tabloya gore formu ayarlar.
        /// </summary>
        /// <param name="formunBolumu"></param>
        private void FormuSekillendir(FormBolumu formunBolumu)
        {
            switch (formunBolumu)
            {
                case FormBolumu.Is:
                    break;
                case FormBolumu.Belge:
                    break;
                case FormBolumu.Ajanda:
                    break;
                case FormBolumu.Editor:
                    break;
                case FormBolumu.KodveCetvel:
                    break;
                case FormBolumu.Muhasebe:
                    break;
                case FormBolumu.Sorusturma:
                    break;
                case FormBolumu.Ilam:
                    break;
                case FormBolumu.Gorusme:
                    break;
                case FormBolumu.Celse:
                    break;
                case FormBolumu.Kanit:
                    break;
                case FormBolumu.DusmeYenileme:
                    break;
                case FormBolumu.Tazminat:
                    break;
                case FormBolumu.Temyiz:
                    break;
                case FormBolumu.Tutuklama:
                    break;
                case FormBolumu.Uzlasma:
                    break;
                case FormBolumu.Vekalet:
                    break;
                case FormBolumu.AraKarar:
                    break;
                case FormBolumu.Cari:
                    break;
                case FormBolumu.KayitIliski:
                    break;
                case FormBolumu.KiymetliEvrak:
                    break;
                case FormBolumu.Police:
                    break;
                case FormBolumu.Rucu:
                    break;
                case FormBolumu.Temsil:
                    break;
                case FormBolumu.Tespit:
                    break;
                case FormBolumu.Klasor:
                    break;
                case FormBolumu.Antet:
                    break;
                case FormBolumu.Asama:
                    break;
                case FormBolumu.Mesaj:
                    break;
                case FormBolumu.Notlar:
                    break;
                case FormBolumu.Sablon:
                    break;
                case FormBolumu.BorcluOdeme:
                    break;
                case FormBolumu.Haciz:
                    break;
                case FormBolumu.Harc:
                    break;
                case FormBolumu.IhtiyatiHaciz:
                    break;
                case FormBolumu.MalBeyani:
                    break;
                case FormBolumu.Mehil:
                    break;
                case FormBolumu.Saat:
                    break;
                case FormBolumu.Satis:
                    break;
                case FormBolumu.Taahut:
                    break;
                case FormBolumu.KýymetTakdiri:
                    break;
                case FormBolumu.Degisken:
                    break;
                case FormBolumu.Proje:
                    break;
                case FormBolumu.Yardim:
                    break;
                case FormBolumu.Gayrimenkul:
                    break;
                case FormBolumu.Hesap:
                    break;
                case FormBolumu.Faiz:
                    break;
                case FormBolumu.Icra:
                    break;
                case FormBolumu.Dava:
                    break;
                case FormBolumu.Tebligat:
                    break;
                case FormBolumu.Sozlesme:
                    break;
                case FormBolumu.Diger:
                    break;
                default:
                    break;
            }
        }

        public virtual void AvpXtraForm_Load(object sender, EventArgs e)
        {
            if (!EntityBase.BagliKullaniciId.HasValue || this.DesignMode)
                return;

            //AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm.mrqEnAlt.Hide();

            if (!DesignMode)
                this.Icon = global::AdimAdimDavaKaydi.Properties.Resources.avukatpro_masaustu64x64;

            c_tsmenuUst3.Location = new System.Drawing.Point(633, 0);
            c_tstMenuOzelIslemler.Location = new System.Drawing.Point(553, 0);
            c_tstmenuUstDigerMenu.Location = new System.Drawing.Point(409, 0);
            c_tsUstMenu.Location = new System.Drawing.Point(1, 0);

            if (this.DesignMode)
                return;

            _AcilanFormSayisi++;

            if (EventlerKullanilacakMi)
            {
                ToolStripContainerHepsiniInVisibleYap(ref c_tstmenuUstDigerMenu);
                ToolStripContainerHepsiniInVisibleYap(ref c_tstMenuOzelIslemler);
                ToolStripContainerHepsiniInVisibleYap(ref c_tsmenuUst3);
                ToolStripContainerHepsiniInVisibleYap(ref c_tsUstMenu);

                if (YeniDosya != null || Button_Yeni_Click != null)
                {
                    tsBtn_Yeni.Visible = true;
                    //  tsBtn_Yeni.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_Yeni.Name);
                }
                if (DosyaKaydet != null || Button_Kaydet_Click != null)
                {
                    tsBtn_Kaydet.Visible = true;
                    // tsBtn_Kaydet.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_Kaydet.Name);
                }

                if (Button_Tamam_Click != null)
                {
                    this.c_btnTamam.Visible = true;
                    this.c_pnlAltButtons.Visible = true;
                }

                if (Button_Tamam_Click == null && Button_Iptal_Click == null)
                {
                    this.c_pnlAltButtons.Visible = false;
                }
                if (Button_Uyap_Click != null)
                {
                    c_titemUYAP.Visible = true;
                    //c_titemUYAP.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.c_titemUYAP.Name);
                }
                if (Button_AdimAdimEditore_Click != null)
                {
                    c_titemEditorSihirbaz.Visible = true;
                    //c_titemEditorSihirbaz.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.c_titemEditorSihirbaz.Name);
                }

                if (Button_Iptal_Click != null)
                {
                    this.c_btnIptal.Visible = true;
                    this.c_pnlAltButtons.Visible = true;
                }
                if (DosyaAc != null || Button_Ac_Click != null)
                {
                    tsBtn_Ac.Visible = true;
                    // tsBtn_Ac.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_Ac.Name);
                }
                if (FarkliKaydet != null || Button_FarkliKaydet_Click != null)
                {
                    tsBtn_FarkliKaydet.Visible = true;
                    // tsBtn_FarkliKaydet.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_FarkliKaydet.Name);
                }
                if (Sil != null || Button_Sil_Click != null)
                {
                    tsBtn_Sil.Visible = true;
                    // tsBtn_Sil.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_Sil.Name);
                }
                if (Kes != null || Button_Kes_Click != null)
                {
                    tsBtn_Kes.Visible = true;
                    // tsBtn_Kes.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_Kes.Name);
                }
                if (Yapistir != null || Button_Yapistir_Click != null)
                {
                    tsBtn_Yapistir.Visible = true;
                    // tsBtn_Yapistir.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_Yapistir.Name);
                }
                if (Kopyala != null || Button_Kopyala_Click != null)
                {
                    tsBtn_Kopyala.Visible = true;
                    //tsBtn_Kopyala.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_Kopyala.Name);
                }
                if (Yeniden != null || Button_Yeniden_Click != null)
                {
                    tsBtn_Yeniden.Visible = true;
                    //tsBtn_Yeniden.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_Yeniden.Name);
                }
                if (GeriAl != null || Button_GeriAl_Click != null)
                {
                    tsBtn_GeriAl.Visible = true;
                    //tsBtn_GeriAl.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_GeriAl.Name);
                }
                if (Yazdir != null || Button_Yazdir_Click != null)
                {
                    tsBtn_Yazdir.Visible = true;
                    //tsBtn_Yazdir.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_Yazdir.Name);
                }
                if (Tarihce != null || Button_Tarihce_Click != null)
                {
                    tsBtn_Tarihce.Visible = true;
                    //tsBtn_Tarihce.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_Tarihce.Name);
                }
                if (Gizle != null || Button_Gizle_Click != null)
                {
                    tsBtn_Gizle.Visible = true;
                    //tsBtn_Gizle.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_Gizle.Name);
                }
                if (Hesapla != null || Button_Hesapla_Click != null)
                {
                    tsBtn_Hesapla.Visible = true;
                    // tsBtn_Hesapla.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_Hesapla.Name);
                }
                if (EditoreGonderildi != null || Button_Editor_Click != null)
                {
                    tsBtn_OfisIslemleri.Visible = true;
                    tsBtn_OfisIslemleriEditor.Visible = true;
                    // tsBtn_OfisIslemleri.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_OfisIslemleri.Name);
                    //  tsBtn_OfisIslemleriEditor.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_OfisIslemleriEditor.Name);
                }
                if (WordeGonderildi != null || Button_Word_Click != null)
                {
                    tsBtn_OfisIslemleri.Visible = true;
                    tsBtn_OfisIslemleriWord.Visible = true;
                    // tsBtn_OfisIslemleri.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_OfisIslemleri.Name);
                    // tsBtn_OfisIslemleriWord.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_OfisIslemleriWord.Name);
                }
                if (ExceleGonderildi != null || Button_Excel_Click != null)
                {
                    tsBtn_OfisIslemleri.Visible = true;
                    tsBtn_OfisIslemleriExel.Visible = true;
                    //tsBtn_OfisIslemleri.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_OfisIslemleri.Name);
                    // tsBtn_OfisIslemleriExel.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_OfisIslemleriExel.Name);
                }
                if (OutlookaGonderildi != null || Button_Outlook_Click != null)
                {
                    tsBtn_OfisIslemleri.Visible = true;
                    tsBtn_OfisIslemleriOutlook.Visible = true;
                    // tsBtn_OfisIslemleri.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_OfisIslemleri.Name);
                    // tsBtn_OfisIslemleriOutlook.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_OfisIslemleriOutlook.Name);
                }
                if (PdfeGonderildi != null || Button_PDF_Click != null)
                {
                    tsBtn_OfisIslemleri.Visible = true;
                    tsBtn_OfisIslemleriPDF.Visible = true;
                    // tsBtn_OfisIslemleri.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_OfisIslemleri.Name);
                    //tsBtn_OfisIslemleriPDF.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.tsBtn_OfisIslemleriPDF.Name);
                }
                if (Button_Ajanda_Click != null)
                {
                    c_titemAjanda.Visible = true;
                    //c_titemAjanda.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.c_titemAjanda.Name);
                }
                if (Button_DavaOncesiOdeme_Click != null)
                {
                    c_titemDavaOncesiOdeme.Visible = true;
                    // c_titemDavaOncesiOdeme.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.c_titemDavaOncesiOdeme.Name);
                }
                if (Button_HesaplanmisKalemler_Click != null)
                {
                    c_titemHesaplanmisKalemler.Visible = true;
                    // c_titemHesaplanmisKalemler.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.c_titemHesaplanmisKalemler.Name);
                }
                if (Button_IhtiyatiHaciz_Click != null)
                {
                    c_titemIhtiyatiHaciz.Visible = true;
                    //c_titemIhtiyatiHaciz.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.c_titemIhtiyatiHaciz.Name);
                }
                if (Button_IhtiyatiTedbir_Click != null)
                {
                    c_titemIhtiyatiTedbir.Visible = true;
                    // c_titemIhtiyatiTedbir.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.c_titemIhtiyatiTedbir.Name);
                }
                if (Button_IlamBilgileri_Click != null)
                {
                    c_titemIlamBilgileri.Visible = true;
                    // c_titemIlamBilgileri.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.c_titemIlamBilgileri.Name);
                }
                if (Button_IliskiliDosyalar_Click != null)
                {
                    c_titemIliskiliDosyalar.Visible = true;
                    // c_titemIliskiliDosyalar.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.c_titemIliskiliDosyalar.Name);
                }
                if (Button_MahsupBilgileri_Click != null)
                {
                    c_titemMahsupBilgileri.Visible = true;
                    // c_titemMahsupBilgileri.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.c_titemMahsupBilgileri.Name);
                }
                if (Button_TakipOncesiOdemeleri_Click != null)
                {
                    c_titemTakipOncesiOdemeleri.Visible = true;
                    // c_titemTakipOncesiOdemeleri.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.c_titemTakipOncesiOdemeleri.Name);
                }
                if (Button_TakipYazismalari_Click != null)
                {
                    c_titemTakipYazismalari.Visible = true;
                    // c_titemTakipYazismalari.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.c_titemTakipYazismalari.Name);
                }
                if (Button_Ihtarname_Click != null)
                {
                    c_titemIhtarname.Visible = true;
                    // c_titemIhtarname.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.c_titemIhtarname.Name);
                }
                if (Button_Masraf_Click != null)
                {
                    c_titemMasraf.Visible = true;
                    // c_titemMasraf.Visible = AuthHelper.PaketeDahilmi("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", this.c_titemMasraf.Name);
                }

                ToolStripContainerGez(ref c_tstmenuUstDigerMenu);
                ToolStripContainerGez(ref c_tstMenuOzelIslemler);
                ToolStripContainerGez(ref c_tsmenuUst3);
                ToolStripContainerGez(ref c_tsUstMenu);
            }
            try
            {
                //FormHelper helper = new FormHelper();
                //helper.SetForm(this);
                //myHelper = helper;
                //her zaman üstte çýksýn mý
                //AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm.c_titemFormHerZamanUstte.Checked = this.TopMost;
                //AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm.c_titemYaziTipi.Visible = false;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void ToolStripContainerGez(ref ToolStrip toolStrip)
        {
            foreach (ToolStripItem c in toolStrip.Items)
            {
                if (c.Visible)
                {
                    toolStrip.Visible = true;
                    return;
                }

                //TODO: [PAKET] Alt menu ekleme
                //if(c is ToolStripSeparator)
                //    return;

                //"AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm"
                //AuthHelper.ApplyAuthorization("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", c.Name, c.Text);

                AuthHelper hlp = AuthHelper.GetAuthHelper("AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", c.Name);

                if (hlp != null)
                {
                    c.Enabled = hlp.FormAcabilir;
                    c.Visible = hlp.MenuGorebilir;
                }
            }
            toolStrip.Visible = false;
        }

        private void ToolStripContainerHepsiniInVisibleYap(ref ToolStrip toolStrip)
        {
            toolStrip.Visible = true;
            foreach (ToolStripItem c in toolStrip.Items)
            {
                c.Visible = false;
            }
        }

        #region toolStrip menu DBye akarým
        
        /// <summary>
        /// Recursive olarak menuitemlarýný MenuItem class tipine aktarýr.
        /// </summary>
        /// <param name="dr">ToolStripMenuItem</param>
        /// <param name="menu">MenuItem</param>
        private void GetMenuItems(ToolStripMenuItem dr, AvukatProLib.Util.MenuItem menu)
        {
            AvukatProLib.Util.MenuItem altMenu = new AvukatProLib.Util.MenuItem();
            if (dr.HasDropDownItems)
            {
                ToolStripItemCollection itemCollection = dr.DropDownItems;

                foreach (ToolStripItem item in itemCollection)
                {
                    if (item.GetType() == typeof(ToolStripMenuItem))
                    {
                        ToolStripMenuItem it = (ToolStripMenuItem)item;

                        altMenu =
                            new AvukatProLib.Util.MenuItem(
                                String.Format("{0}#{1}", "AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm", it.Name),
                                it.Name, String.Format("{0} - {1}", GetOwnerName(it), it.Text));
                        menu.AddList(altMenu);
                        //Recursive olarak kendini cagýrýr.
                        GetMenuItems(it, altMenu);
                    }
                }
            }
        }

        /// <summary>
        /// ToolStripItem in ait oludug kontrolun adýný strin olarak doner
        /// </summary>
        /// <param name="mItem">ToolStripItem</param>
        /// <returns>string</returns>
        public string GetOwnerName(ToolStripItem mItem)
        {
            if (mItem.OwnerItem != null)
            {
                string gelen = GetOwnerName(mItem.OwnerItem);
                if (string.IsNullOrEmpty(gelen))
                    return mItem.OwnerItem.Text;
                else
                    return String.Format("{0} - {1}", gelen, mItem.OwnerItem.Text);
            }
            return String.Empty;
        }

        #endregion toolStrip menu DBye akarým

        #region Data Ýþlemleri

        private List<Panel> SelectPanels = new List<Panel>();
                
        private void pnl_MouseLeave(object sender, EventArgs e)
        {
            (sender as Panel).BackColor = System.Drawing.Color.Transparent;
        }

        private void pnl_MouseEnter(object sender, EventArgs e)
        {
            (sender as Panel).BackColor = System.Drawing.Color.Gray;
        }

        public virtual void DeepLoadDataSource()
        {
            if (DesignMode)
            {
                return;
            }

            for (int i = 0; i < this.myDataSource.Datas.Count; i++)
            {
                if (myDataSource.Datas[i].Table == "AV001_TD_BIL_FOY")
                {
                    //DeepLoader.DeepLoadDavaTumChildlar(myDataSource.Datas[i].Datas);
                }
            }
        }

        #endregion Data Ýþlemleri

        #region IYetkilendirilebilir Members

        private AuthHelper _MyAuthHelper;

        public AuthHelper MyAuthHelper
        {
            get { return _MyAuthHelper; }
            set { _MyAuthHelper = value; }
        }

        #endregion IYetkilendirilebilir Members

        #region Design

        private System.ComponentModel.IContainer components;
        private ContextMenuStrip c_comenUstKoseMenu;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStrip c_tsUstMenu;
        private ToolStripMenuItem toolStripMenuItem3;
        private OpenFileDialog c_opfArkaPlan;
        private ToolStripButton tsBtn_Yeni;
        private ToolStripButton tsBtn_Ac;
        internal ToolStripButton tsBtn_Kaydet;
        private ToolStripButton tsBtn_FarkliKaydet;
        private ToolStripButton tsBtn_Sil;
        private ToolStripButton tsBtn_Kes;
        internal ToolStripButton tsBtn_Kopyala;
        private ToolStripButton tsBtn_Yapistir;
        internal ToolStripButton tsBtn_GeriAl;
        private ToolStripButton tsBtn_Yeniden;
        private ToolStripButton tsBtn_Yazdir;
        private ToolStripButton tsBtn_Tarihce;
        internal ToolStripButton tsBtn_Gizle;
        internal ToolStripButton tsBtn_Hesapla;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripDropDownButton tsBtn_OfisIslemleri;
        private ToolStripMenuItem tsBtn_OfisIslemleriEditor;
        private ToolStripMenuItem tsBtn_OfisIslemleriWord;
        private ToolStripMenuItem tsBtn_OfisIslemleriOutlook;
        private ToolStripMenuItem tsBtn_OfisIslemleriExel;
        private ToolStripMenuItem tsBtn_OfisIslemleriPDF;
        private ToolStripPanel c_tspnlMenuPanel;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvpXtraForm));
            this.c_comenUstKoseMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.c_tsUstMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtn_Yeni = new System.Windows.Forms.ToolStripButton();
            this.tsBtn_Ac = new System.Windows.Forms.ToolStripButton();
            this.tsBtn_Kaydet = new System.Windows.Forms.ToolStripButton();
            this.tsBtn_FarkliKaydet = new System.Windows.Forms.ToolStripButton();
            this.tsBtn_Sil = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtn_Kes = new System.Windows.Forms.ToolStripButton();
            this.tsBtn_Kopyala = new System.Windows.Forms.ToolStripButton();
            this.tsBtn_Yapistir = new System.Windows.Forms.ToolStripButton();
            this.tsBtn_GeriAl = new System.Windows.Forms.ToolStripButton();
            this.tsBtn_Yeniden = new System.Windows.Forms.ToolStripButton();
            this.tsBtn_Yazdir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtn_Tarihce = new System.Windows.Forms.ToolStripButton();
            this.tsBtn_Gizle = new System.Windows.Forms.ToolStripButton();
            this.tsBtn_Hesapla = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtn_OfisIslemleri = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsBtn_OfisIslemleriEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtn_OfisIslemleriWord = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtn_OfisIslemleriOutlook = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtn_OfisIslemleriExel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtn_OfisIslemleriPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemOfisIslemleriXml = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemOfisIslemleriRtf = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemOfisIslemleriHtml = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYenile = new System.Windows.Forms.ToolStripButton();
            this.c_tspnlMenuPanel = new System.Windows.Forms.ToolStripPanel();
            this.c_opfArkaPlan = new System.Windows.Forms.OpenFileDialog();
            this.c_pnlContainer = new DevExpress.XtraEditors.PanelControl();
            this.c_pnlAltButtons = new DevExpress.XtraEditors.PanelControl();
            this.c_pnlFormSakla = new DevExpress.XtraEditors.PanelControl();
            this.c_btnUstKose = new DevExpress.XtraEditors.SimpleButton();
            this.c_btnFormuYukle = new DevExpress.XtraEditors.SimpleButton();
            this.c_btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.c_btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.c_opfFormuKaydet = new System.Windows.Forms.OpenFileDialog();
            this.c_tstmenuUstDigerMenu = new System.Windows.Forms.ToolStrip();
            this.c_titemIhtiyatiHaciz = new System.Windows.Forms.ToolStripButton();
            this.c_titemHesaplanmisKalemler = new System.Windows.Forms.ToolStripButton();
            this.c_titemIhtiyatiTedbir = new System.Windows.Forms.ToolStripButton();
            this.c_titemIlamBilgileri = new System.Windows.Forms.ToolStripButton();
            this.c_titemMahsupBilgileri = new System.Windows.Forms.ToolStripButton();
            this.c_titemTakipOncesiOdemeleri = new System.Windows.Forms.ToolStripButton();
            this.c_titemIhtarname = new System.Windows.Forms.ToolStripButton();
            this.c_titemMasraf = new System.Windows.Forms.ToolStripButton();
            this.c_titemEditorSihirbaz = new System.Windows.Forms.ToolStripButton();
            this.c_titemUYAP = new System.Windows.Forms.ToolStripButton();
            this.c_tsmenuUst3 = new System.Windows.Forms.ToolStrip();
            this.c_titemDavaOncesiOdeme = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.c_tstMenuOzelIslemler = new System.Windows.Forms.ToolStrip();
            this.c_titemAjanda = new System.Windows.Forms.ToolStripButton();
            this.c_titemTakipYazismalari = new System.Windows.Forms.ToolStripButton();
            this.c_titemIliskiliDosyalar = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextModuleEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.cmYetkilendirme = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.c_comenUstKoseMenu.SuspendLayout();
            this.c_tsUstMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            this.c_tstmenuUstDigerMenu.SuspendLayout();
            this.c_tsmenuUst3.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.c_tstMenuOzelIslemler.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_comenUstKoseMenu
            // 
            this.c_comenUstKoseMenu.BackColor = System.Drawing.Color.Transparent;
            this.c_comenUstKoseMenu.Font = new System.Drawing.Font("Verdana", 9F);
            this.c_comenUstKoseMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.c_comenUstKoseMenu.Name = "c_comenUstKoseMenu";
            this.c_comenUstKoseMenu.Size = new System.Drawing.Size(134, 70);
            this.c_comenUstKoseMenu.Text = "Hýzlý Eriþim";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem1.Text = "deneme2";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem2.Text = "deneme3";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem3.Text = "deneme4";
            // 
            // c_tsUstMenu
            // 
            this.c_tsUstMenu.AllowItemReorder = true;
            this.c_tsUstMenu.BackColor = System.Drawing.Color.Transparent;
            this.c_tsUstMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.c_tsUstMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtn_Yeni,
            this.tsBtn_Ac,
            this.tsBtn_Kaydet,
            this.tsBtn_FarkliKaydet,
            this.tsBtn_Sil,
            this.toolStripSeparator2,
            this.tsBtn_Kes,
            this.tsBtn_Kopyala,
            this.tsBtn_Yapistir,
            this.tsBtn_GeriAl,
            this.tsBtn_Yeniden,
            this.tsBtn_Yazdir,
            this.toolStripSeparator3,
            this.tsBtn_Tarihce,
            this.tsBtn_Gizle,
            this.tsBtn_Hesapla,
            this.toolStripSeparator4,
            this.tsBtn_OfisIslemleri,
            this.c_titemYenile});
            this.c_tsUstMenu.Location = new System.Drawing.Point(3, 75);
            this.c_tsUstMenu.Name = "c_tsUstMenu";
            this.c_tsUstMenu.Size = new System.Drawing.Size(404, 25);
            this.c_tsUstMenu.TabIndex = 2;
            this.c_tsUstMenu.Text = "toolStrip1";
            // 
            // tsBtn_Yeni
            // 
            this.tsBtn_Yeni.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Yeni.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Yeni.Image")));
            this.tsBtn_Yeni.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_Yeni.Name = "tsBtn_Yeni";
            this.tsBtn_Yeni.Size = new System.Drawing.Size(23, 22);
            this.tsBtn_Yeni.Text = "Yeni";
            this.tsBtn_Yeni.ToolTipText = "Yeni";
            this.tsBtn_Yeni.Click += new System.EventHandler(this.tsBtn_Yeni_Click);
            // 
            // tsBtn_Ac
            // 
            this.tsBtn_Ac.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Ac.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Ac.Image")));
            this.tsBtn_Ac.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_Ac.Name = "tsBtn_Ac";
            this.tsBtn_Ac.Size = new System.Drawing.Size(23, 22);
            this.tsBtn_Ac.Text = "Aç";
            this.tsBtn_Ac.ToolTipText = "Aç";
            this.tsBtn_Ac.Click += new System.EventHandler(this.tsBtn_Ac_Click);
            // 
            // tsBtn_Kaydet
            // 
            this.tsBtn_Kaydet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Kaydet.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Kaydet.Image")));
            this.tsBtn_Kaydet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_Kaydet.Name = "tsBtn_Kaydet";
            this.tsBtn_Kaydet.Size = new System.Drawing.Size(23, 22);
            this.tsBtn_Kaydet.Text = "Kaydet";
            this.tsBtn_Kaydet.ToolTipText = "Kaydet";
            this.tsBtn_Kaydet.Click += new System.EventHandler(this.tsBtn_Kaydet_Click);
            // 
            // tsBtn_FarkliKaydet
            // 
            this.tsBtn_FarkliKaydet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_FarkliKaydet.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_FarkliKaydet.Image")));
            this.tsBtn_FarkliKaydet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_FarkliKaydet.Name = "tsBtn_FarkliKaydet";
            this.tsBtn_FarkliKaydet.Size = new System.Drawing.Size(23, 22);
            this.tsBtn_FarkliKaydet.Text = "Farklý Kaydet";
            this.tsBtn_FarkliKaydet.Click += new System.EventHandler(this.tsBtn_FarkliKaydet_Click);
            // 
            // tsBtn_Sil
            // 
            this.tsBtn_Sil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Sil.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Sil.Image")));
            this.tsBtn_Sil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_Sil.Name = "tsBtn_Sil";
            this.tsBtn_Sil.Size = new System.Drawing.Size(23, 22);
            this.tsBtn_Sil.Text = "Sil";
            this.tsBtn_Sil.Click += new System.EventHandler(this.tsBtn_Sil_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtn_Kes
            // 
            this.tsBtn_Kes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Kes.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Kes.Image")));
            this.tsBtn_Kes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_Kes.Name = "tsBtn_Kes";
            this.tsBtn_Kes.Size = new System.Drawing.Size(23, 22);
            this.tsBtn_Kes.Text = "Kes";
            this.tsBtn_Kes.Click += new System.EventHandler(this.tsBtn_Kes_Click);
            // 
            // tsBtn_Kopyala
            // 
            this.tsBtn_Kopyala.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Kopyala.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Kopyala.Image")));
            this.tsBtn_Kopyala.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_Kopyala.Name = "tsBtn_Kopyala";
            this.tsBtn_Kopyala.Size = new System.Drawing.Size(23, 22);
            this.tsBtn_Kopyala.Text = "Kopyala";
            this.tsBtn_Kopyala.Click += new System.EventHandler(this.tsBtn_Kopyala_Click);
            // 
            // tsBtn_Yapistir
            // 
            this.tsBtn_Yapistir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Yapistir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Yapistir.Image")));
            this.tsBtn_Yapistir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_Yapistir.Name = "tsBtn_Yapistir";
            this.tsBtn_Yapistir.Size = new System.Drawing.Size(23, 22);
            this.tsBtn_Yapistir.Text = "Yapýþtýr";
            this.tsBtn_Yapistir.Click += new System.EventHandler(this.tsBtn_Yapistir_Click);
            // 
            // tsBtn_GeriAl
            // 
            this.tsBtn_GeriAl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_GeriAl.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_GeriAl.Image")));
            this.tsBtn_GeriAl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_GeriAl.Name = "tsBtn_GeriAl";
            this.tsBtn_GeriAl.Size = new System.Drawing.Size(23, 22);
            this.tsBtn_GeriAl.Text = "Geri Al";
            this.tsBtn_GeriAl.Click += new System.EventHandler(this.tsBtn_GeriAl_Click);
            // 
            // tsBtn_Yeniden
            // 
            this.tsBtn_Yeniden.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Yeniden.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Yeniden.Image")));
            this.tsBtn_Yeniden.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_Yeniden.Name = "tsBtn_Yeniden";
            this.tsBtn_Yeniden.Size = new System.Drawing.Size(23, 22);
            this.tsBtn_Yeniden.Text = "Yeniden";
            this.tsBtn_Yeniden.Click += new System.EventHandler(this.tsBtn_Yeniden_Click);
            // 
            // tsBtn_Yazdir
            // 
            this.tsBtn_Yazdir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Yazdir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Yazdir.Image")));
            this.tsBtn_Yazdir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_Yazdir.Name = "tsBtn_Yazdir";
            this.tsBtn_Yazdir.Size = new System.Drawing.Size(23, 22);
            this.tsBtn_Yazdir.Text = "Yazdýr";
            this.tsBtn_Yazdir.Click += new System.EventHandler(this.tsBtn_Yazdir_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtn_Tarihce
            // 
            this.tsBtn_Tarihce.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Tarihce.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Tarihce.Image")));
            this.tsBtn_Tarihce.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_Tarihce.Name = "tsBtn_Tarihce";
            this.tsBtn_Tarihce.Size = new System.Drawing.Size(23, 22);
            this.tsBtn_Tarihce.Text = "Tarihçe";
            this.tsBtn_Tarihce.Click += new System.EventHandler(this.tsBtn_Tarihce_Click);
            // 
            // tsBtn_Gizle
            // 
            this.tsBtn_Gizle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Gizle.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Gizle.Image")));
            this.tsBtn_Gizle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_Gizle.Name = "tsBtn_Gizle";
            this.tsBtn_Gizle.Size = new System.Drawing.Size(23, 22);
            this.tsBtn_Gizle.Text = "Gizle";
            this.tsBtn_Gizle.Click += new System.EventHandler(this.tsBtn_Gizle_Click);
            // 
            // tsBtn_Hesapla
            // 
            this.tsBtn_Hesapla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Hesapla.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Hesapla.Image")));
            this.tsBtn_Hesapla.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsBtn_Hesapla.Name = "tsBtn_Hesapla";
            this.tsBtn_Hesapla.Size = new System.Drawing.Size(23, 22);
            this.tsBtn_Hesapla.Text = "Hesapla";
            this.tsBtn_Hesapla.Click += new System.EventHandler(this.tsBtn_Hesapla_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtn_OfisIslemleri
            // 
            this.tsBtn_OfisIslemleri.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_OfisIslemleri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtn_OfisIslemleriEditor,
            this.tsBtn_OfisIslemleriWord,
            this.tsBtn_OfisIslemleriOutlook,
            this.tsBtn_OfisIslemleriExel,
            this.tsBtn_OfisIslemleriPDF,
            this.c_titemOfisIslemleriXml,
            this.c_titemOfisIslemleriRtf,
            this.c_titemOfisIslemleriHtml});
            this.tsBtn_OfisIslemleri.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_OfisIslemleri.Image")));
            this.tsBtn_OfisIslemleri.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsBtn_OfisIslemleri.Name = "tsBtn_OfisIslemleri";
            this.tsBtn_OfisIslemleri.Size = new System.Drawing.Size(29, 22);
            this.tsBtn_OfisIslemleri.Text = "Ofis Araçlarý";
            // 
            // tsBtn_OfisIslemleriEditor
            // 
            this.tsBtn_OfisIslemleriEditor.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_OfisIslemleriEditor.Image")));
            this.tsBtn_OfisIslemleriEditor.Name = "tsBtn_OfisIslemleriEditor";
            this.tsBtn_OfisIslemleriEditor.Size = new System.Drawing.Size(117, 22);
            this.tsBtn_OfisIslemleriEditor.Text = "Editör";
            this.tsBtn_OfisIslemleriEditor.Click += new System.EventHandler(this.tsBtn_OfisIslemleriEditor_Click);
            // 
            // tsBtn_OfisIslemleriWord
            // 
            this.tsBtn_OfisIslemleriWord.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_OfisIslemleriWord.Image")));
            this.tsBtn_OfisIslemleriWord.Name = "tsBtn_OfisIslemleriWord";
            this.tsBtn_OfisIslemleriWord.Size = new System.Drawing.Size(117, 22);
            this.tsBtn_OfisIslemleriWord.Text = "Word";
            this.tsBtn_OfisIslemleriWord.Click += new System.EventHandler(this.tsBtn_OfisIslemleriWord_Click);
            // 
            // tsBtn_OfisIslemleriOutlook
            // 
            this.tsBtn_OfisIslemleriOutlook.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_OfisIslemleriOutlook.Image")));
            this.tsBtn_OfisIslemleriOutlook.Name = "tsBtn_OfisIslemleriOutlook";
            this.tsBtn_OfisIslemleriOutlook.Size = new System.Drawing.Size(117, 22);
            this.tsBtn_OfisIslemleriOutlook.Text = "Outlook";
            this.tsBtn_OfisIslemleriOutlook.Click += new System.EventHandler(this.tsBtn_OfisIslemleriOutlook_Click);
            // 
            // tsBtn_OfisIslemleriExel
            // 
            this.tsBtn_OfisIslemleriExel.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_OfisIslemleriExel.Image")));
            this.tsBtn_OfisIslemleriExel.Name = "tsBtn_OfisIslemleriExel";
            this.tsBtn_OfisIslemleriExel.Size = new System.Drawing.Size(117, 22);
            this.tsBtn_OfisIslemleriExel.Text = "Excel";
            this.tsBtn_OfisIslemleriExel.Click += new System.EventHandler(this.tsBtn_OfisIslemleriExel_Click);
            // 
            // tsBtn_OfisIslemleriPDF
            // 
            this.tsBtn_OfisIslemleriPDF.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_OfisIslemleriPDF.Image")));
            this.tsBtn_OfisIslemleriPDF.Name = "tsBtn_OfisIslemleriPDF";
            this.tsBtn_OfisIslemleriPDF.Size = new System.Drawing.Size(117, 22);
            this.tsBtn_OfisIslemleriPDF.Text = "PDF";
            this.tsBtn_OfisIslemleriPDF.Visible = false;
            this.tsBtn_OfisIslemleriPDF.Click += new System.EventHandler(this.tsBtn_OfisIslemleriPDF_Click);
            // 
            // c_titemOfisIslemleriXml
            // 
            this.c_titemOfisIslemleriXml.Name = "c_titemOfisIslemleriXml";
            this.c_titemOfisIslemleriXml.Size = new System.Drawing.Size(117, 22);
            this.c_titemOfisIslemleriXml.Text = "Xml";
            this.c_titemOfisIslemleriXml.Visible = false;
            this.c_titemOfisIslemleriXml.Click += new System.EventHandler(this.c_titemOfisIslemleriXml_Click);
            // 
            // c_titemOfisIslemleriRtf
            // 
            this.c_titemOfisIslemleriRtf.Name = "c_titemOfisIslemleriRtf";
            this.c_titemOfisIslemleriRtf.Size = new System.Drawing.Size(117, 22);
            this.c_titemOfisIslemleriRtf.Text = "Rtf";
            this.c_titemOfisIslemleriRtf.Visible = false;
            this.c_titemOfisIslemleriRtf.Click += new System.EventHandler(this.c_titemOfisIslemleriRtf_Click);
            // 
            // c_titemOfisIslemleriHtml
            // 
            this.c_titemOfisIslemleriHtml.Name = "c_titemOfisIslemleriHtml";
            this.c_titemOfisIslemleriHtml.Size = new System.Drawing.Size(117, 22);
            this.c_titemOfisIslemleriHtml.Text = "Html";
            this.c_titemOfisIslemleriHtml.Visible = false;
            this.c_titemOfisIslemleriHtml.Click += new System.EventHandler(this.c_titemOfisIslemleriHtml_Click);
            // 
            // c_titemYenile
            // 
            this.c_titemYenile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.c_titemYenile.Image = ((System.Drawing.Image)(resources.GetObject("c_titemYenile.Image")));
            this.c_titemYenile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_titemYenile.Name = "c_titemYenile";
            this.c_titemYenile.Size = new System.Drawing.Size(23, 22);
            this.c_titemYenile.Text = "Yenile";
            this.c_titemYenile.Click += new System.EventHandler(this.c_titemYenile_Click);
            // 
            // c_tspnlMenuPanel
            // 
            this.c_tspnlMenuPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.c_tspnlMenuPanel.Location = new System.Drawing.Point(0, 658);
            this.c_tspnlMenuPanel.Name = "c_tspnlMenuPanel";
            this.c_tspnlMenuPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.c_tspnlMenuPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.c_tspnlMenuPanel.Size = new System.Drawing.Size(922, 0);
            // 
            // c_opfArkaPlan
            // 
            this.c_opfArkaPlan.Filter = "Resim Dosyalarý|*.jpg;*.jpeg;*.bmp;*.gif;*.png";
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.c_pnlContainer.Controls.Add(this.c_pnlAltButtons);
            this.c_pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.c_pnlContainer.Name = "c_pnlContainer";
            this.c_pnlContainer.Size = new System.Drawing.Size(922, 558);
            this.c_pnlContainer.TabIndex = 5;
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.c_pnlAltButtons.Controls.Add(this.c_pnlFormSakla);
            this.c_pnlAltButtons.Controls.Add(this.c_btnIptal);
            this.c_pnlAltButtons.Controls.Add(this.c_btnTamam);
            this.c_pnlAltButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 533);
            this.c_pnlAltButtons.Name = "c_pnlAltButtons";
            this.c_pnlAltButtons.Size = new System.Drawing.Size(922, 25);
            this.c_pnlAltButtons.TabIndex = 9;
            this.c_pnlAltButtons.Visible = false;
            // 
            // c_pnlFormSakla
            // 
            this.c_pnlFormSakla.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.c_pnlFormSakla.Controls.Add(this.c_btnUstKose);
            this.c_pnlFormSakla.Controls.Add(this.c_btnFormuYukle);
            this.c_pnlFormSakla.Dock = System.Windows.Forms.DockStyle.Left;
            this.c_pnlFormSakla.Location = new System.Drawing.Point(0, 0);
            this.c_pnlFormSakla.Name = "c_pnlFormSakla";
            this.c_pnlFormSakla.Size = new System.Drawing.Size(343, 25);
            this.c_pnlFormSakla.TabIndex = 4;
            this.c_pnlFormSakla.Visible = false;
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            this.c_btnUstKose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.c_btnUstKose.Image = ((System.Drawing.Image)(resources.GetObject("c_btnUstKose.Image")));
            this.c_btnUstKose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.c_btnUstKose.Location = new System.Drawing.Point(12, 3);
            this.c_btnUstKose.Name = "c_btnUstKose";
            this.c_btnUstKose.Size = new System.Drawing.Size(43, 17);
            this.c_btnUstKose.TabIndex = 5;
            this.c_btnUstKose.Visible = false;
            // 
            // c_btnFormuYukle
            // 
            this.c_btnFormuYukle.Location = new System.Drawing.Point(195, 1);
            this.c_btnFormuYukle.Name = "c_btnFormuYukle";
            this.c_btnFormuYukle.Size = new System.Drawing.Size(141, 23);
            this.c_btnFormuYukle.TabIndex = 3;
            this.c_btnFormuYukle.Text = "Ayar Dosyasýndan Yukle";
            this.c_btnFormuYukle.Visible = false;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Dock = System.Windows.Forms.DockStyle.Right;
            this.c_btnIptal.Location = new System.Drawing.Point(772, 0);
            this.c_btnIptal.Name = "c_btnIptal";
            this.c_btnIptal.Size = new System.Drawing.Size(75, 25);
            this.c_btnIptal.TabIndex = 1;
            this.c_btnIptal.Text = "Ýptal";
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Dock = System.Windows.Forms.DockStyle.Right;
            this.c_btnTamam.Location = new System.Drawing.Point(847, 0);
            this.c_btnTamam.Name = "c_btnTamam";
            this.c_btnTamam.Size = new System.Drawing.Size(75, 25);
            this.c_btnTamam.TabIndex = 0;
            this.c_btnTamam.Text = "Tamam";
            // 
            // c_opfFormuKaydet
            // 
            this.c_opfFormuKaydet.DefaultExt = "*.avpfrm";
            this.c_opfFormuKaydet.FileName = "openFileDialog1";
            // 
            // c_tstmenuUstDigerMenu
            // 
            this.c_tstmenuUstDigerMenu.AllowItemReorder = true;
            this.c_tstmenuUstDigerMenu.BackColor = System.Drawing.Color.Transparent;
            this.c_tstmenuUstDigerMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.c_tstmenuUstDigerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemIhtiyatiHaciz,
            this.c_titemHesaplanmisKalemler,
            this.c_titemIhtiyatiTedbir,
            this.c_titemIlamBilgileri,
            this.c_titemMahsupBilgileri,
            this.c_titemTakipOncesiOdemeleri,
            this.c_titemIhtarname,
            this.c_titemMasraf,
            this.c_titemEditorSihirbaz,
            this.c_titemUYAP});
            this.c_tstmenuUstDigerMenu.Location = new System.Drawing.Point(3, 50);
            this.c_tstmenuUstDigerMenu.Name = "c_tstmenuUstDigerMenu";
            this.c_tstmenuUstDigerMenu.Size = new System.Drawing.Size(242, 25);
            this.c_tstmenuUstDigerMenu.TabIndex = 8;
            this.c_tstmenuUstDigerMenu.Text = "toolStrip1";
            // 
            // c_titemIhtiyatiHaciz
            // 
            this.c_titemIhtiyatiHaciz.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.c_titemIhtiyatiHaciz.Image = ((System.Drawing.Image)(resources.GetObject("c_titemIhtiyatiHaciz.Image")));
            this.c_titemIhtiyatiHaciz.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_titemIhtiyatiHaciz.Name = "c_titemIhtiyatiHaciz";
            this.c_titemIhtiyatiHaciz.Size = new System.Drawing.Size(23, 22);
            this.c_titemIhtiyatiHaciz.Text = "Ýhtiyati Haciz";
            this.c_titemIhtiyatiHaciz.Click += new System.EventHandler(this.c_titemIhtiyatiHaciz_Click);
            // 
            // c_titemHesaplanmisKalemler
            // 
            this.c_titemHesaplanmisKalemler.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.c_titemHesaplanmisKalemler.Image = ((System.Drawing.Image)(resources.GetObject("c_titemHesaplanmisKalemler.Image")));
            this.c_titemHesaplanmisKalemler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_titemHesaplanmisKalemler.Name = "c_titemHesaplanmisKalemler";
            this.c_titemHesaplanmisKalemler.Size = new System.Drawing.Size(23, 22);
            this.c_titemHesaplanmisKalemler.Text = "Hesaplanmýþ Kalemler";
            this.c_titemHesaplanmisKalemler.Click += new System.EventHandler(this.c_titemHesaplanmisKalemler_Click);
            // 
            // c_titemIhtiyatiTedbir
            // 
            this.c_titemIhtiyatiTedbir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.c_titemIhtiyatiTedbir.Image = ((System.Drawing.Image)(resources.GetObject("c_titemIhtiyatiTedbir.Image")));
            this.c_titemIhtiyatiTedbir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_titemIhtiyatiTedbir.Name = "c_titemIhtiyatiTedbir";
            this.c_titemIhtiyatiTedbir.Size = new System.Drawing.Size(23, 22);
            this.c_titemIhtiyatiTedbir.Text = "Ýhtiyati Tedbir";
            this.c_titemIhtiyatiTedbir.Click += new System.EventHandler(this.c_titemIhtiyatiTedbir_Click);
            // 
            // c_titemIlamBilgileri
            // 
            this.c_titemIlamBilgileri.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.c_titemIlamBilgileri.Image = ((System.Drawing.Image)(resources.GetObject("c_titemIlamBilgileri.Image")));
            this.c_titemIlamBilgileri.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_titemIlamBilgileri.Name = "c_titemIlamBilgileri";
            this.c_titemIlamBilgileri.Size = new System.Drawing.Size(23, 22);
            this.c_titemIlamBilgileri.Text = "Ýlam Bilgileri";
            this.c_titemIlamBilgileri.Click += new System.EventHandler(this.c_titemIlamBilgileri_Click);
            // 
            // c_titemMahsupBilgileri
            // 
            this.c_titemMahsupBilgileri.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.c_titemMahsupBilgileri.Image = ((System.Drawing.Image)(resources.GetObject("c_titemMahsupBilgileri.Image")));
            this.c_titemMahsupBilgileri.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_titemMahsupBilgileri.Name = "c_titemMahsupBilgileri";
            this.c_titemMahsupBilgileri.Size = new System.Drawing.Size(23, 22);
            this.c_titemMahsupBilgileri.Text = "Mahsup Bilgileri";
            this.c_titemMahsupBilgileri.Click += new System.EventHandler(this.c_titemMahsupBilgileri_Click);
            // 
            // c_titemTakipOncesiOdemeleri
            // 
            this.c_titemTakipOncesiOdemeleri.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.c_titemTakipOncesiOdemeleri.Image = ((System.Drawing.Image)(resources.GetObject("c_titemTakipOncesiOdemeleri.Image")));
            this.c_titemTakipOncesiOdemeleri.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_titemTakipOncesiOdemeleri.Name = "c_titemTakipOncesiOdemeleri";
            this.c_titemTakipOncesiOdemeleri.Size = new System.Drawing.Size(23, 22);
            this.c_titemTakipOncesiOdemeleri.Text = "Takip Oncesi Odemeler";
            this.c_titemTakipOncesiOdemeleri.Click += new System.EventHandler(this.c_titemTakipOncesiOdemeleri_Click);
            // 
            // c_titemIhtarname
            // 
            this.c_titemIhtarname.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.c_titemIhtarname.Image = ((System.Drawing.Image)(resources.GetObject("c_titemIhtarname.Image")));
            this.c_titemIhtarname.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_titemIhtarname.Name = "c_titemIhtarname";
            this.c_titemIhtarname.Size = new System.Drawing.Size(23, 22);
            this.c_titemIhtarname.Text = "Ýhtarname Bilgileri";
            this.c_titemIhtarname.ToolTipText = "Ýhtarname Bilgileri";
            this.c_titemIhtarname.Click += new System.EventHandler(this.c_titemIhtarname_Click);
            // 
            // c_titemMasraf
            // 
            this.c_titemMasraf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.c_titemMasraf.Image = ((System.Drawing.Image)(resources.GetObject("c_titemMasraf.Image")));
            this.c_titemMasraf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_titemMasraf.Name = "c_titemMasraf";
            this.c_titemMasraf.Size = new System.Drawing.Size(23, 22);
            this.c_titemMasraf.Text = "Masraf Bilgileri";
            this.c_titemMasraf.ToolTipText = "Masraf Bilgileri";
            this.c_titemMasraf.Click += new System.EventHandler(this.c_titemMasraf_Click);
            // 
            // c_titemEditorSihirbaz
            // 
            this.c_titemEditorSihirbaz.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.c_titemEditorSihirbaz.Image = ((System.Drawing.Image)(resources.GetObject("c_titemEditorSihirbaz.Image")));
            this.c_titemEditorSihirbaz.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_titemEditorSihirbaz.Name = "c_titemEditorSihirbaz";
            this.c_titemEditorSihirbaz.Size = new System.Drawing.Size(23, 22);
            this.c_titemEditorSihirbaz.Text = "Dosyayý Sihirbazda Aç";
            this.c_titemEditorSihirbaz.ToolTipText = "Üzerinde Bulunduðumuz Dosyayý Sihirbazda Açar";
            this.c_titemEditorSihirbaz.Click += new System.EventHandler(this.c_titemEditorSihirbaz_Click);
            // 
            // c_titemUYAP
            // 
            this.c_titemUYAP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.c_titemUYAP.Image = ((System.Drawing.Image)(resources.GetObject("c_titemUYAP.Image")));
            this.c_titemUYAP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_titemUYAP.Name = "c_titemUYAP";
            this.c_titemUYAP.Size = new System.Drawing.Size(23, 22);
            this.c_titemUYAP.Text = "UYAP Çýktýsý";
            this.c_titemUYAP.ToolTipText = "Üzerinde Bulunduðumuz Dosyanýn UYAP Çýktýsýný Alýr";
            this.c_titemUYAP.Click += new System.EventHandler(this.c_titemUYAP_Click);
            // 
            // c_tsmenuUst3
            // 
            this.c_tsmenuUst3.AllowItemReorder = true;
            this.c_tsmenuUst3.BackColor = System.Drawing.Color.Transparent;
            this.c_tsmenuUst3.Dock = System.Windows.Forms.DockStyle.None;
            this.c_tsmenuUst3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDavaOncesiOdeme});
            this.c_tsmenuUst3.Location = new System.Drawing.Point(115, 0);
            this.c_tsmenuUst3.Name = "c_tsmenuUst3";
            this.c_tsmenuUst3.Size = new System.Drawing.Size(35, 25);
            this.c_tsmenuUst3.TabIndex = 12;
            this.c_tsmenuUst3.Text = "toolStrip1";
            // 
            // c_titemDavaOncesiOdeme
            // 
            this.c_titemDavaOncesiOdeme.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.c_titemDavaOncesiOdeme.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDavaOncesiOdeme.Image")));
            this.c_titemDavaOncesiOdeme.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_titemDavaOncesiOdeme.Name = "c_titemDavaOncesiOdeme";
            this.c_titemDavaOncesiOdeme.Size = new System.Drawing.Size(23, 22);
            this.c_titemDavaOncesiOdeme.Text = "Dava Öncesi Ödeme";
            this.c_titemDavaOncesiOdeme.Click += new System.EventHandler(this.c_titemDavaOncesiOdeme_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.c_pnlContainer);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(922, 558);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(922, 658);
            this.toolStripContainer1.TabIndex = 13;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.c_tsmenuUst3);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.c_tstMenuOzelIslemler);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.c_tstmenuUstDigerMenu);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.c_tsUstMenu);
            // 
            // c_tstMenuOzelIslemler
            // 
            this.c_tstMenuOzelIslemler.BackColor = System.Drawing.Color.Transparent;
            this.c_tstMenuOzelIslemler.Dock = System.Windows.Forms.DockStyle.None;
            this.c_tstMenuOzelIslemler.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemAjanda,
            this.c_titemTakipYazismalari,
            this.c_titemIliskiliDosyalar});
            this.c_tstMenuOzelIslemler.Location = new System.Drawing.Point(69, 25);
            this.c_tstMenuOzelIslemler.Name = "c_tstMenuOzelIslemler";
            this.c_tstMenuOzelIslemler.Size = new System.Drawing.Size(81, 25);
            this.c_tstMenuOzelIslemler.TabIndex = 13;
            // 
            // c_titemAjanda
            // 
            this.c_titemAjanda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.c_titemAjanda.Image = ((System.Drawing.Image)(resources.GetObject("c_titemAjanda.Image")));
            this.c_titemAjanda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_titemAjanda.Name = "c_titemAjanda";
            this.c_titemAjanda.Size = new System.Drawing.Size(23, 22);
            this.c_titemAjanda.Text = "Ajanda";
            this.c_titemAjanda.Click += new System.EventHandler(this.c_titemAjanda_Click);
            // 
            // c_titemTakipYazismalari
            // 
            this.c_titemTakipYazismalari.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.c_titemTakipYazismalari.Image = ((System.Drawing.Image)(resources.GetObject("c_titemTakipYazismalari.Image")));
            this.c_titemTakipYazismalari.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_titemTakipYazismalari.Name = "c_titemTakipYazismalari";
            this.c_titemTakipYazismalari.Size = new System.Drawing.Size(23, 22);
            this.c_titemTakipYazismalari.Text = "Takip Yazýþmalarý";
            this.c_titemTakipYazismalari.Click += new System.EventHandler(this.c_titemTakipYazismalari_Click);
            // 
            // c_titemIliskiliDosyalar
            // 
            this.c_titemIliskiliDosyalar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.c_titemIliskiliDosyalar.Image = ((System.Drawing.Image)(resources.GetObject("c_titemIliskiliDosyalar.Image")));
            this.c_titemIliskiliDosyalar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_titemIliskiliDosyalar.Name = "c_titemIliskiliDosyalar";
            this.c_titemIliskiliDosyalar.Size = new System.Drawing.Size(23, 22);
            this.c_titemIliskiliDosyalar.Text = "Ýliþkili Dosyalar";
            this.c_titemIliskiliDosyalar.Click += new System.EventHandler(this.c_titemIliskiliDosyalar_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextModuleEkle});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 26);
            // 
            // contextModuleEkle
            // 
            this.contextModuleEkle.Name = "contextModuleEkle";
            this.contextModuleEkle.Size = new System.Drawing.Size(139, 22);
            this.contextModuleEkle.Text = "Modüle Ekle";
            this.contextModuleEkle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmYetkilendirme
            // 
            this.cmYetkilendirme.Name = "cmYetkilendirme";
            this.cmYetkilendirme.Size = new System.Drawing.Size(61, 4);
            // 
            // AvpXtraForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(922, 658);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.c_tspnlMenuPanel);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(515, 295);
            this.Name = "AvpXtraForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AvpXtraForm_FormClosed);
            this.Load += new System.EventHandler(this.AvpXtraForm_Load);
            this.c_comenUstKoseMenu.ResumeLayout(false);
            this.c_tsUstMenu.ResumeLayout(false);
            this.c_tsUstMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            this.c_tstmenuUstDigerMenu.ResumeLayout(false);
            this.c_tstmenuUstDigerMenu.PerformLayout();
            this.c_tsmenuUst3.ResumeLayout(false);
            this.c_tsmenuUst3.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.c_tstMenuOzelIslemler.ResumeLayout(false);
            this.c_tstMenuOzelIslemler.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion Design

        #region BindingSourcesEndInit

        #region <KA-20090611>

        // Kaydetme sýrasýnda formdaki data baðlantýsý olan kontrolleri bulup bindingsource larýný
        // select yaparak en son seçilen fakat kaydedilemeyen deðerlerin kaydedilmesini saðlar

        #endregion <KA-20090611>

        private bool FormBindingSourcesEndInit()
        {
            // recursive metodu çaðýrarak formdaki bindingsourcelara baðlý olan ilk controlun tetikleyer kaydedilmesini saðlar.
            List<BindingSource> sources = FindBindingSources(this, new List<BindingSource>());

            foreach (BindingSource item in sources)
            {
                // if (!Warnings.WarningControl(this.Name, item))
                //  return false;
            }
            return true;
        }

        private List<BindingSource> FindBindingSources(Control control, List<BindingSource> resultList)
        {
            if (control.DataBindings != null)
                foreach (Binding b in control.DataBindings)
                    if (b.DataSource is BindingSource &&
                        !resultList.Exists(delegate(BindingSource bs) { return bs == b.DataSource; }))
                    {
                        this.SelectNextControl(control, true, true, true, true);
                        resultList.Add(b.DataSource as BindingSource);
                    }

            foreach (Control c in control.Controls)
                FindBindingSources(c, resultList);

            return resultList;
        }

        #endregion BindingSourcesEndInit

        #region Yeni KAyit

        private void tsBtn_Yeni_Click(object sender, EventArgs e)
        {
            AvpFormDataEventArgs ee = new AvpFormDataEventArgs();
            ee.Data = CurrentDatas;
            if (YeniKayit != null)
            {
                YeniKayit(this, ee);
            }

            try
            {
                Yeni();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }

            ee.Data = CurrentDatas;
            if (YeniKaydedildi != null)
            {
                this.YeniKaydedildi(this, ee);
            }

            if (Button_Yeni_Click != null)
            {
                Button_Yeni_Click(this, new EventArgs());
            }
        }

        public virtual void Yeni()
        {
            if (_useAutoDataOperations)
            {
                Current = CurrentDatas.Datas.AddNew();
            }
        }

        #endregion Yeni KAyit

        #region Ac

        public virtual void Ac()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void tsBtn_Ac_Click(object sender, EventArgs e)
        {
            AvpFormDataEventArgs ee = new AvpFormDataEventArgs();
            ee.Data = CurrentDatas;
            if (DosyaAc != null)
            {
                DosyaAc(this, ee);
            }
            try
            {
                Ac();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "Dosya Aç");
            }

            if (DosyaAcildi != null)
            {
                DosyaAcildi(this, ee);
            }
            ee.Data = CurrentDatas;

            if (Button_Ac_Click != null)
            {
                Button_Ac_Click(this, new EventArgs());
            }
        }

        #endregion Ac

        #region Kaydet

        public virtual void Kaydet()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void tsBtn_Kaydet_Click(object sender, EventArgs e)
        {
            #region <KA-20090611>

            //kaydetmeden önce form kontrolleri tetikleme
            if (!FormBindingSourcesEndInit()) return;

            #endregion <KA-20090611>

            AvpFormDataEventArgs ee = new AvpFormDataEventArgs();
            ee.Data = CurrentDatas;
            if (DosyaKaydet != null)
            {
                DosyaKaydet(this, ee);
            }
            try
            {
                Kaydet();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "Kaydet");
            }

            ee.Data = CurrentDatas;
            if (DosyaKaydedildi != null)
            {
                DosyaKaydedildi(this, ee);
            }

            if (Button_Kaydet_Click != null)
            {
                Button_Kaydet_Click(this, new EventArgs());
            }
        }

        #endregion Kaydet

        #region DosyaFarkliKaydet

        public virtual void DosyaFarkliKaydet()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void tsBtn_FarkliKaydet_Click(object sender, EventArgs e)
        {
            AvpFormDataEventArgs ee = new AvpFormDataEventArgs();
            ee.Data = CurrentDatas;
            if (FarkliKaydet != null)
            {
                FarkliKaydet(this, ee);
            }
            try
            {
                DosyaFarkliKaydet();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "Farklý Kaydet");
            }

            ee.Data = CurrentDatas;
            if (FarkliKaydedildi != null)
            {
                FarkliKaydedildi(this, ee);
            }

            if (Button_FarkliKaydet_Click != null)
            {
                Button_FarkliKaydet_Click(this, new EventArgs());
            }
        }

        #endregion DosyaFarkliKaydet

        #region DosyaSil

        public virtual void DosyaSil()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void tsBtn_Sil_Click(object sender, EventArgs e)
        {
            AvpFormDataEventArgs ee = new AvpFormDataEventArgs();
            ee.Data = CurrentDatas;
            if (Sil != null)
            {
                Sil(this, ee);
            }
            try
            {
                DosyaSil();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "Dosya Sil");
            }
            ee.Data = CurrentDatas;
            if (Silindi != null)
            {
                Silindi(this, ee);
            }

            if (Button_Sil_Click != null)
            {
                Button_Sil_Click(this, new EventArgs());
            }
        }

        #endregion DosyaSil

        #region Kes

        public virtual void DosyaKes()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void tsBtn_Kes_Click(object sender, EventArgs e)
        {
            AvpFormDataEventArgs ee = new AvpFormDataEventArgs();
            ee.Data = CurrentDatas;
            if (Kes != null)
            {
                Kes(this, ee);
                try
                {
                    DosyaKes();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "Kes");
                }
            }

            ee.Data = CurrentDatas;
            if (Kesildi != null)
            {
                Kesildi(this, ee);
            }

            if (Button_Kes_Click != null)
            {
                Button_Kes_Click(this, new EventArgs());
            }
        }

        #endregion Kes

        #region Dosya Kopyala

        public virtual void DosyaKopyala()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void tsBtn_Kopyala_Click(object sender, EventArgs e)
        {
            AvpFormDataEventArgs ee = new AvpFormDataEventArgs();
            ee.Data = CurrentDatas;
            if (Kopyala != null)
            {
                Kopyala(this, ee);
            }
            try
            {
                DosyaKopyala();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "Dosya Kopyala");
            }
            ee.Data = CurrentDatas;
            if (Kopyalandi != null)
            {
                Kopyalandi(this, ee);
            }

            if (Button_Kopyala_Click != null)
            {
                Button_Kopyala_Click(this, new EventArgs());
            }
        }

        #endregion Dosya Kopyala

        #region Dosya Yapistir

        public virtual void DosyaYapistir()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void tsBtn_Yapistir_Click(object sender, EventArgs e)
        {
            AvpFormDataEventArgs ee = new AvpFormDataEventArgs();
            ee.Data = CurrentDatas;
            if (Yapistir != null)
            {
                Yapistir(this, ee);
            }
            try
            {
                DosyaYapistir();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "Yapistir");
            }
            ee.Data = CurrentDatas;
            if (Yapistirildi != null)
            {
                Yapistirildi(this, ee);
            }

            if (Button_Yapistir_Click != null)
            {
                Button_Yapistir_Click(this, new EventArgs());
            }
        }

        #endregion Dosya Yapistir

        #region Kaydý Geri Al

        public virtual void KayitGeriAl()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void tsBtn_GeriAl_Click(object sender, EventArgs e)
        {
            AvpFormAvpDataSourceEventArgs ee = new AvpFormAvpDataSourceEventArgs();
            ee.DataSource = this.MyIEntityDataSource;
            if (GeriAl != null)
            {
                GeriAl(this, ee);
            }
            try
            {
                KayitGeriAl();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "Geri Al");
            }
            if (GeriAlindi != null)
            {
                GeriAlindi(this, ee);
            }

            if (Button_GeriAl_Click != null)
            {
                Button_GeriAl_Click(this, new EventArgs());
            }
        }

        #endregion Kaydý Geri Al

        #region Yeniden

        public virtual void KayitYeniden()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void tsBtn_Yeniden_Click(object sender, EventArgs e)
        {
            AvpFormAvpDataSourceEventArgs ee = new AvpFormAvpDataSourceEventArgs();
            ee.DataSource = this.MyIEntityDataSource;
            if (Yeniden != null)
            {
                Yeniden(this, ee);
            }
            try
            {
                KayitYeniden();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "Yeniden");
            }
            if (YenidenAlindi != null)
            {
                YenidenAlindi(this, ee);
            }

            if (Button_Yeniden_Click != null)
            {
                Button_Yeniden_Click(this, new EventArgs());
            }
        }

        #endregion Yeniden

        #region Dosya Yazdir

        public virtual void DosyaYazdir()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void tsBtn_Yazdir_Click(object sender, EventArgs e)
        {
            AvpFormAvpDataSourceEventArgs ee = new AvpFormAvpDataSourceEventArgs();
            ee.DataSource = this.MyIEntityDataSource;
            if (Yazdir != null)
            {
                Yazdir(this, ee);
            }
            try
            {
                DosyaYazdir();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "Dosya Yazdýr");
            }
            if (Yazdirildi != null)
            {
                Yazdirildi(this, ee);
            }

            if (Button_Yazdir_Click != null)
            {
                Button_Yazdir_Click(this, new EventArgs());
            }
        }

        #endregion Dosya Yazdir

        #region Dosya Tarihçe

        public virtual void DosyaTarihce()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void tsBtn_Tarihce_Click(object sender, EventArgs e)
        {
            AvpFormDataEventArgs ee = new AvpFormDataEventArgs();
            ee.Data = CurrentDatas;
            if (Tarihce != null)
            {
                Tarihce(this, ee);
            }
            try
            {
                DosyaTarihce();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "Tarihçe");
            }
            ee.Data = CurrentDatas;
            if (TarihceAcildi != null)
            {
                TarihceAcildi(this, ee);
            }

            if (Button_Tarihce_Click != null)
            {
                Button_Tarihce_Click(this, new EventArgs());
            }
        }

        #endregion Dosya Tarihçe

        #region Dosya Gizle

        public virtual void DosyaGizle()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void tsBtn_Gizle_Click(object sender, EventArgs e)
        {
            AvpFormDataEventArgs ee = new AvpFormDataEventArgs();
            ee.Data = CurrentDatas;
            if (Gizle != null)
            {
                Gizle(this, ee);
            }
            try
            {
                DosyaGizle();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "Dosya Gizle");
            }
            ee.Data = CurrentDatas;
            if (Gizlendi != null)
            {
                Gizlendi(this, ee);
            }

            if (Button_Gizle_Click != null)
            {
                Button_Gizle_Click(this, new EventArgs());
            }
        }

        #endregion Dosya Gizle

        #region Dosya Hesapla

        public virtual void DosyaHsapla()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void tsBtn_Hesapla_Click(object sender, EventArgs e)
        {
            AvpFormDataEventArgs ee = new AvpFormDataEventArgs();
            ee.Data = CurrentDatas;
            if (Hesapla != null)
            {
                Hesapla(this, ee);
            }
            try
            {
                DosyaHsapla();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "Hasapla");
            }
            ee.Data = CurrentDatas;
            if (Hesaplandi != null)
            {
                Hesaplandi(this, ee);
            }

            if (Button_Hesapla_Click != null)
            {
                Button_Hesapla_Click(this, new EventArgs());
            }
        }

        #endregion Dosya Hesapla

        #region Foyden Çikiþ

        public virtual void Cikis()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        #endregion Foyden Çikiþ

        #region AddnewData

        private void AvpXtraForm_AddingNew(object sender, AddingNewEventArgs e)
        {
            AvpFormAddNewEventArgs adNewArgs = new AvpFormAddNewEventArgs();
            adNewArgs.DataSource = this.MyIEntityDataSource;
            if (e.NewObject is IEntity)
            {
                adNewArgs.NewData = (e.NewObject as IEntity);
            }
            if (AddingData != null)
            {
                AddingData(this, adNewArgs);
            }

            if (CustomDefaultValues != null)
            {
                CustomDefaultValues(this, adNewArgs);
            }
            for (int i = 0; i < adNewArgs.DefaultValues.Count; i++)
            {
                if (e.NewObject is IEntity)
                {
                    TablesColumnData.SetColumnValueByNameFromRecord((e.NewObject as IEntity),
                                                                    adNewArgs.DefaultValues[i].ColumnName,
                                                                    adNewArgs.DefaultValues[i].Data);
                }
            }
            AddNewData(adNewArgs);

            if (AddedData != null)
            {
                AddedData(this, adNewArgs);
            }
        }

        public virtual void AddNewData(AvpFormAddNewEventArgs e)
        {
        }

        #endregion AddnewData

        #region Tamam

        public virtual void Tamam()
        {
            if (Formusakla)
            {
                this.c_opfFormuKaydet.ShowDialog();
                if (!string.IsNullOrEmpty(c_opfFormuKaydet.FileName))
                {
                    Tools.SerializeClass(this, c_opfFormuKaydet.FileName);
                }
            }
        }

        #endregion Tamam

        #region Vazgec

        public virtual void Iptal()
        {
            DialogResult dr = XtraMessageBox.Show("Formu Kapatmak istediðinize emin misiniz ? ", "Emin misiniz ? ",
                                                  MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        #endregion Vazgec

        #region Export Ýþlemleri

        #region Editor

        private void tsBtn_OfisIslemleriEditor_Click(object sender, EventArgs e)
        {
            if (Button_Editor_Click != null)
            {
                Button_Editor_Click(this, new EventArgs());
            }
        }

        #endregion Editor

        #region WordeGonder

        private void tsBtn_OfisIslemleriWord_Click(object sender, EventArgs e)
        {
            if (Button_Word_Click != null)
            {
                Button_Word_Click(this, new EventArgs());
            }
        }

        #endregion WordeGonder

        #region OutlookaGonder

        private void tsBtn_OfisIslemleriOutlook_Click(object sender, EventArgs e)
        {
            if (Button_Outlook_Click != null)
            {
                Button_Outlook_Click(this, new EventArgs());
            }
        }

        #endregion OutlookaGonder

        #region ExceleGonder

        private void tsBtn_OfisIslemleriExel_Click(object sender, EventArgs e)
        {
            if (Button_Excel_Click != null)
            {
                Button_Excel_Click(this, new EventArgs());
            }
        }

        #endregion ExceleGonder

        #region PdfeGonder

        private void tsBtn_OfisIslemleriPDF_Click(object sender, EventArgs e)
        {
            if (Button_PDF_Click != null)
            {
                Button_PDF_Click(this, new EventArgs());
            }
        }

        #endregion PdfeGonder

        #region Xml e Gonder

        private void c_titemOfisIslemleriXml_Click(object sender, EventArgs e)
        {
            if (Button_XML_Click != null)
            {
                Button_XML_Click(this, new EventArgs());
            }
        }

        #endregion Xml e Gonder

        #region html e Gonder

        private void c_titemOfisIslemleriHtml_Click(object sender, EventArgs e)
        {
            if (Button_HTML_Click != null)
            {
                Button_HTML_Click(this, new EventArgs());
            }
        }

        #endregion html e Gonder

        #region Rtf e Gonder

        private void c_titemOfisIslemleriRtf_Click(object sender, EventArgs e)
        {
            if (Button_RTF_Click != null)
            {
                Button_RTF_Click(this, new EventArgs());
            }
        }

        #endregion Rtf e Gonder

        #endregion Export Ýþlemleri

        #region Yenile

        private void c_titemYenile_Click(object sender, EventArgs e)
        {
            Yenile();
        }

        public void Yenile()
        {
        }

        #endregion Yenile

        #region Hesaplanmis kalemler

        private void c_titemHesaplanmisKalemler_Click(object sender, EventArgs e)
        {
            AvpFormChildOpenEventArgs ee = new AvpFormChildOpenEventArgs();
            ee.Button = DigerMenuButtonType.HesaplanmisKalemler;
            if (sender is DevExpress.Utils.ToolTipItem)
            {
                ee.ClickedMenuItem = (DevExpress.Utils.ToolTipItem)sender;
            }
            ee.DataSource = this.MyIEntityDataSource;
            if (this.CurrentDatas != null)
            {
                ee.ParentRecord = this.CurrentDatas.SelectedDatas;

                if (DigerMenuButonClick != null)
                {
                    DigerMenuButonClick(this, ee);
                }
                HesaplanmisKalemler();
                if (DigerMenuButonClicked != null)
                {
                    DigerMenuButonClicked(this, ee);
                }
            }

            if (Button_HesaplanmisKalemler_Click != null)
            {
                Button_HesaplanmisKalemler_Click(this, new EventArgs());
            }
        }

        public virtual void HesaplanmisKalemler()
        {
        }

        #endregion Hesaplanmis kalemler

        #region IhtiyatiHaciz

        private void c_titemIhtiyatiHaciz_Click(object sender, EventArgs e)
        {
            AvpFormChildOpenEventArgs ee = new AvpFormChildOpenEventArgs();
            ee.Button = DigerMenuButtonType.IhtiyatiHaciz;
            if (sender is DevExpress.Utils.ToolTipItem)
            {
                ee.ClickedMenuItem = (DevExpress.Utils.ToolTipItem)sender;
            }
            ee.DataSource = this.MyIEntityDataSource;
            if (this.CurrentDatas != null)
            {
                ee.ParentRecord = this.CurrentDatas.SelectedDatas;
            }

            if (DigerMenuButonClick != null)
            {
                DigerMenuButonClick(this, ee);
            }
            IhtiyatiHaciz();
            if (DigerMenuButonClicked != null)
            {
                DigerMenuButonClicked(this, ee);
            }

            if (Button_IhtiyatiHaciz_Click != null)
            {
                Button_IhtiyatiHaciz_Click(this, new EventArgs());
            }
        }

        public virtual void IhtiyatiHaciz()
        {
        }

        #endregion IhtiyatiHaciz

        #region IhtiyatiTedbir

        private void c_titemIhtiyatiTedbir_Click(object sender, EventArgs e)
        {
            AvpFormChildOpenEventArgs ee = new AvpFormChildOpenEventArgs();
            ee.Button = DigerMenuButtonType.IhtiyatiTedbir;
            if (sender is DevExpress.Utils.ToolTipItem)
            {
                ee.ClickedMenuItem = (DevExpress.Utils.ToolTipItem)sender;
            }
            ee.DataSource = this.MyIEntityDataSource;
            if (this.CurrentDatas != null && this.CurrentDatas.SelectedDatas != null)
            {
                ee.ParentRecord = this.CurrentDatas.SelectedDatas;
            }

            if (DigerMenuButonClick != null)
            {
                DigerMenuButonClick(this, ee);
            }
            IhtiyatiTedbir();
            if (DigerMenuButonClicked != null)
            {
                DigerMenuButonClicked(this, ee);
            }

            if (Button_IhtiyatiTedbir_Click != null)
            {
                Button_IhtiyatiTedbir_Click(this, new EventArgs());
            }
        }

        public virtual void IhtiyatiTedbir()
        {
        }

        #endregion IhtiyatiTedbir

        #region Ilambilgeleri

        private void c_titemIlamBilgileri_Click(object sender, EventArgs e)
        {
            AvpFormChildOpenEventArgs ee = new AvpFormChildOpenEventArgs();
            ee.Button = DigerMenuButtonType.Ilambilgileri;
            if (sender is DevExpress.Utils.ToolTipItem)
            {
                ee.ClickedMenuItem = (DevExpress.Utils.ToolTipItem)sender;
            }
            ee.DataSource = this.MyIEntityDataSource;
            if (this.CurrentDatas != null)
            {
                ee.ParentRecord = this.CurrentDatas.SelectedDatas;

                if (DigerMenuButonClick != null)
                {
                    DigerMenuButonClick(this, ee);
                }
                IlamBilgileri();
                if (DigerMenuButonClicked != null)
                {
                    DigerMenuButonClicked(this, ee);
                }
            }

            if (Button_IlamBilgileri_Click != null)
            {
                Button_IlamBilgileri_Click(this, new EventArgs());
            }
        }

        public virtual void IlamBilgileri()
        {
        }

        #endregion Ilambilgeleri

        #region MahsupBilgileri

        private void c_titemMahsupBilgileri_Click(object sender, EventArgs e)
        {
            AvpFormChildOpenEventArgs ee = new AvpFormChildOpenEventArgs();
            ee.Button = DigerMenuButtonType.MahsupBilgileri;
            if (sender is DevExpress.Utils.ToolTipItem)
            {
                ee.ClickedMenuItem = (DevExpress.Utils.ToolTipItem)sender;
            }
            ee.DataSource = this.MyIEntityDataSource;
            if (this.CurrentDatas != null)
            {
                ee.ParentRecord = this.CurrentDatas.SelectedDatas;

                if (DigerMenuButonClick != null)
                {
                    DigerMenuButonClick(this, ee);
                }
                MahsupBilgileri();
                if (DigerMenuButonClicked != null)
                {
                    DigerMenuButonClicked(this, ee);
                }
            }

            if (Button_MahsupBilgileri_Click != null)
            {
                Button_MahsupBilgileri_Click(this, new EventArgs());
            }
        }

        public virtual void MahsupBilgileri()
        {
        }

        #endregion MahsupBilgileri

        #region TakipOncesiOdemeler

        private void c_titemTakipOncesiOdemeleri_Click(object sender, EventArgs e)
        {
            AvpFormChildOpenEventArgs ee = new AvpFormChildOpenEventArgs();
            ee.Button = DigerMenuButtonType.TakipOncesiOdemeler;
            if (sender is DevExpress.Utils.ToolTipItem)
            {
                ee.ClickedMenuItem = (DevExpress.Utils.ToolTipItem)sender;
            }
            ee.DataSource = this.MyIEntityDataSource;
            if (this.CurrentDatas != null)
            {
                ee.ParentRecord = this.CurrentDatas.SelectedDatas;

                if (DigerMenuButonClick != null)
                {
                    DigerMenuButonClick(this, ee);
                }
                TakipOncesiOdeme();
                if (DigerMenuButonClicked != null)
                {
                    DigerMenuButonClicked(this, ee);
                }
            }

            if (Button_TakipOncesiOdemeleri_Click != null)
            {
                Button_TakipOncesiOdemeleri_Click(this, new EventArgs());
            }
        }

        public virtual void TakipOncesiOdeme()
        {
        }

        #endregion TakipOncesiOdemeler


        #region Ajandaya Gönder

        public virtual void AjandayaGonder()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void c_titemAjanda_Click(object sender, EventArgs e)
        {
            AvpFormChildRecordFormOpenEventArgs ee = new AvpFormChildRecordFormOpenEventArgs();
            ee.DataSource = this.MyIEntityDataSource;
            if (this.CurrentDatas != null)
            {
                ee.ParentRecord = this.CurrentDatas.SelectedDatas;
                ee.CurrentRecord = this.Current;

                if (AjandayaGonderildi != null)
                {
                    AjandayaGonderilcek(this, ee);
                }
                try
                {
                    AjandayaGonder();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "Ajandaya Gönderildi");
                }
                ee.DataSource = this.MyIEntityDataSource;
                ee.ParentRecord = this.CurrentDatas.SelectedDatas;
                ee.CurrentRecord = this.Current;
            }

            if (AjandayaGonderildi != null)
            {
                AjandayaGonderildi(this, ee);
            }

            if (Button_Ajanda_Click != null)
            {
                Button_Ajanda_Click(this, new EventArgs());
            }
        }

        #endregion Ajandaya Gönder

        #region Takip Yaziþmalrý

        public virtual void TakipYazismlarinaGonder()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void c_titemTakipYazismalari_Click(object sender, EventArgs e)
        {
            AvpFormChildRecordFormOpenEventArgs ee = new AvpFormChildRecordFormOpenEventArgs();
            ee.DataSource = this.MyIEntityDataSource;
            if (this.CurrentDatas != null)
            {
                ee.ParentRecord = this.CurrentDatas.SelectedDatas;
                ee.CurrentRecord = this.Current;

                if (TakipYazismlariGonderilcek != null)
                {
                    TakipYazismlariGonderilcek(this, ee);
                }
                try
                {
                    TakipYazismlarinaGonder();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "Takip Yazýþmalarýna Gönder");
                }
                ee.DataSource = this.MyIEntityDataSource;
                ee.ParentRecord = this.CurrentDatas.SelectedDatas;
                ee.CurrentRecord = this.Current;
            }
            if (TakipYazismlariGonderildi != null)
            {
                TakipYazismlariGonderildi(this, ee);
            }

            if (Button_TakipYazismalari_Click != null)
            {
                Button_TakipYazismalari_Click(this, new EventArgs());
            }
        }

        #endregion Takip Yaziþmalrý

        #region Iliþkili Dosyalar

        public virtual void IliskiliDosyalaraGonder()
        {
            if (_useAutoDataOperations)
            {
            }
        }

        private void c_titemIliskiliDosyalar_Click(object sender, EventArgs e)
        {
            AvpFormChildRecordFormOpenEventArgs ee = new AvpFormChildRecordFormOpenEventArgs();
            ee.DataSource = this.MyIEntityDataSource;
            if (this.CurrentDatas != null)
            {
                ee.ParentRecord = this.CurrentDatas.SelectedDatas;
                ee.CurrentRecord = this.Current;

                if (IliskiliDosyalaraGonderilcek != null)
                {
                    IliskiliDosyalaraGonderilcek(this, ee);
                }
                try
                {
                    IliskiliDosyalaraGonder();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this.GetType(), ex, true, "TÝliþkili Dosyalara Gonder");
                }
                ee.DataSource = this.MyIEntityDataSource;
                ee.ParentRecord = this.CurrentDatas.SelectedDatas;
                ee.CurrentRecord = this.Current;
            }
            if (IliskiliDosyalaraGonderildi != null)
            {
                IliskiliDosyalaraGonderildi(this, ee);
            }
            if (Button_IliskiliDosyalar_Click != null)
            {
                Button_IliskiliDosyalar_Click(this, new EventArgs());
            }
        }

        #endregion Iliþkili Dosyalar

        private void AvpXtraForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ModuleNumber

            //
            //try
            //{
            //    if (e.CloseReason == CloseReason.UserClosing)
            //    {
            //        if (FormTutucu.Forms.Contains(this))
            //        {
            //            FormTutucu.Forms.Remove(this);
            //        }
            //        ObjectDisposing.DisposeDataSources(this);
            //        ObjectDisposing.DisposeAllChild(this); //Okan ARDIÇ 28.12.2009
            //        ObjectDisposing.DisposeObject(this);
            //        this.Dispose();
            //        if (AuthHelperBase.loadedControlList.Contains(this.Name))
            //            AuthHelperBase.loadedControlList.Remove(this.Name);
            //        this.Close();

            //        MemoryManagement.ManageMemory.ReduceMemory();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //todo: burada log tuttalacak
            //}
        }

        private void c_titemDavaOncesiOdeme_Click(object sender, EventArgs e)
        {
            if (Button_DavaOncesiOdeme_Click != null)
            {
                Button_DavaOncesiOdeme_Click(this, new EventArgs());
            }
        }

        private void c_titemIhtarname_Click(object sender, EventArgs e)
        {
            Button_Ihtarname_Click(sender, e);
        }

        private void c_titemMasraf_Click(object sender, EventArgs e)
        {
            Button_Masraf_Click(sender, e);
        }

        private void c_titemEditorSihirbaz_Click(object sender, EventArgs e)
        {
            this.Button_AdimAdimEditore_Click(sender, e);
            //c_titemYazismalarYazismaSihirbazi_Click(sender, e);
        }

        private void c_titemUYAP_Click(object sender, EventArgs e)
        {
            this.Button_Uyap_Click(sender, e);
        }
    }

    public enum FormBolumu
    {
        Ajanda,
        Antet,
        AraKarar,
        Asama,
        Belge,
        BorcluOdeme,
        Cari,
        Celse,
        Dava,
        Degisken,
        Diger,
        DurusmaBilgileri,
        DusmeYenileme,
        Editor,
        Faiz,
        Gayrimenkul,
        GemiUcakArac,
        Gorusme,
        Haciz,
        Harc,
        Hesap,
        Icra,
        IcraOdemeBilgileri,
        IhtiyatiHaciz,
        Ilam,
        Is,
        Kanit,
        KayitIliski,
        KýymetTakdiri,
        KiymetliEvrak,
        Klasor,
        KodveCetvel,
        MalBeyani,
        Mehil,
        Mesaj,
        Muhasebe,
        Notlar,
        Police,
        Proje,
        Rucu,
        Saat,
        Sablon,
        Satis,
        Sorusturma,
        Sozlesme,
        Taahut,
        Tazminat,
        Tebligat,
        Temsil,
        Temyiz,
        Tespit,
        TumMallar,
        Tutuklama,
        Uzlasma,
        Vekalet,
        Yardim
    }

    public enum FormTipi
    {
        Standart,
        GirisFormu,
        AramaFormu,
        TakipFormu,
        AnaKayitFormu,
        KayitFormu,
        UfakKayitFormu,
        IzlemeFormu,
        KodFormu,
        RaporFormu,
        Genel,
        Diger,
        Sihirbaz,
    }
}