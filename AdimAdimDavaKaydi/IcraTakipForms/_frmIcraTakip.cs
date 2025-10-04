using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Editor.Forms;
using AdimAdimDavaKaydi.Forms.Icra;
using AdimAdimDavaKaydi.Util.Uyap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using AvukatProLib;
using System.Data;
using AdimAdimDavaKaydi.Util.BaseClasses.AvpFormClass.AvpFormUtil;
//using AvukatProRaporlar.Raport.Util;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class _frmIcraTakip : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public BackgroundWorker bg;

        private frmAdimAdimEditoreGonder adimAdimEdit;
        private OnKayit _Kaydedildi;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        public _frmIcraTakip()
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("Davatakip InitializeComponent start : " + dt);
            InitializeComponent();
            if (DesignMode)
            {
                CreateUcIcraCore();
            }
            InitializeEvents();
            Console.WriteLine("Davatakip InitializeComponent finish : " + DateTime.Now);
            Console.WriteLine("Davatakip InitializeComponent fark : " + DateTime.Now.Subtract(dt));
        }
        public _frmIcraTakip(OnKayit kaydedildi)
            : this()
        {
            this._Kaydedildi = kaydedildi;
        }

        public delegate void TarafBilgileriDoldur();

        public event EventHandler<FrmIcraDosyaKayitEventArgs> IcraDosyaKayitTiklandi;

        public AV001_TDIE_BIL_PROJE MyProje { get; set; }

        #region Uyap GeriBildirim

        private UyapGeriBildirim _uyapBildirim;

        public UyapGeriBildirim UyapBildirim
        {
            get { return _uyapBildirim; }
            set { _uyapBildirim = value; }
        }

        #endregion Uyap GeriBildirim

        public void IlgiliBolumeYonlendir(string bolumAdi)
        {
            //switch (bolumAdi)
            //{
            //    case "taraf":
            //        this.panelControl2.Visible = true; break;
            //}
        }

        public void UyapAlacaklaraYonlendir()
        {
            tabcIcraTakip.SelectedTabPage = tabGelismeler;
            ucIcraCore1.ucIcraGridlerTemp1.TabGridUyapAlacak();
        }

        private void _frmIcraTakip_Button_Ac_Click(object sender, EventArgs e)
        {
            FoyAc();
        }

        private void _frmIcraTakip_Button_AdimAdimEditore_Click(object sender, EventArgs e)
        {
            adimAdimEdit = new frmAdimAdimEditoreGonder();
            adimAdimEdit.Show(BelgeUtil.Inits.context.per_AV001_TI_BIL_ICRA_Aramas.Single(item => item.ID == MyFoy.ID));
        }

        private void _frmIcraTakip_Button_Hesapla_Click(object sender, EventArgs e)
        {
            if (MyFoy == null)
                return;
            UserControls.frmOdemePlani frm = new AdimAdimDavaKaydi.UserControls.frmOdemePlani();
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show(MyFoy.ID, MyFoy.FOY_NO);
        }

        private void _frmIcraTakip_Button_HesaplanmisKalemler_Click(object sender, EventArgs e)
        {
            //MyFoyOranAta(MyFoy);
            frmIcraHesaplanmisFaizGiris frm = new frmIcraHesaplanmisFaizGiris();
            frm.MyDataSource = this.MyFoy;
            MyFoy.ColumnChanged += foy_ColumnChanged;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();

            //if (MyFoy.OZEL_TAZMINAT_FAIZ_ISLESINMI || MyFoy.OZEL_TUTAR1_FAIZ_ISLESINMI ||
            //    MyFoy.OZEL_TUTAR2_FAIZ_ISLESINMI || MyFoy.OZEL_TUTAR3_FAIZ_ISLESINMI)
            //{
            //    MyFoy.AV001_TI_BIL_FAIZCollection.Clear();
            //}
            //if (MyFoy.OZEL_TAZMINAT_FAIZ_ISLESINMI)
            //{
            //    AV001_TI_BIL_FAIZ fz = AvukatProLib.Hesap.FaizHelper.IcraSabitFaizHesapla(MyFoy.OZEL_TAZMINAT_FAIZ_TIP_ID.Value,
            //                                                           MyFoy.OZEL_TAZMINAT_FAIZ_BASLANGIC_TARIHI.Value,
            //                                                           MyFoy.TAKIP_TARIHI.Value, MyFoy.OZEL_TAZMINAT,
            //                                                           MyFoy.OZEL_TAZMINAT_DOVIZ_ID.Value,
            //                                                           MyFoy.BIR_YIL_KAC_GUN,
            //                                                           MyFoy.OZEL_TAZMINAT_FAIZ_ORANI,
            //                                                           AvukatProLib.Extras.FaizKalem.ÖZEL_TAZMÝNAT);
            //    MyFoy.AV001_TI_BIL_FAIZCollection.Add(fz);
            //}
            //if (MyFoy.OZEL_TUTAR1_FAIZ_ISLESINMI)
            //{
            //    AV001_TI_BIL_FAIZ fz =
            //        AvukatProLib.Hesap.FaizHelper.IcraSabitFaizHesapla(MyFoy.OZEL_TUTAR1_FAIZ_TIP_ID.Value,
            //                                        MyFoy.OZEL_TUTAR1_FAIZ_BASLANGIC_TARIHI.Value,
            //                                        MyFoy.TAKIP_TARIHI.Value, MyFoy.OZEL_TUTAR1,
            //                                        MyFoy.OZEL_TUTAR1_DOVIZ_ID.Value, MyFoy.BIR_YIL_KAC_GUN,
            //                                        MyFoy.OZEL_TUTAR1_FAIZ_ORANI, AvukatProLib.Extras.FaizKalem.ÖZEL_TUTAR_1);
            //    MyFoy.AV001_TI_BIL_FAIZCollection.Add(fz);
            //}
            //if (MyFoy.OZEL_TUTAR2_FAIZ_ISLESINMI)
            //{
            //    AV001_TI_BIL_FAIZ fz =
            //        AvukatProLib.Hesap.FaizHelper.IcraSabitFaizHesapla(MyFoy.OZEL_TUTAR2_FAIZ_TIP_ID.Value,
            //                                        MyFoy.OZEL_TUTAR2_FAIZ_BASLANGIC_TARIHI.Value,
            //                                        MyFoy.TAKIP_TARIHI.Value, MyFoy.OZEL_TUTAR2,
            //                                        MyFoy.OZEL_TUTAR2_DOVIZ_ID.Value, MyFoy.BIR_YIL_KAC_GUN,
            //                                        MyFoy.OZEL_TUTAR2_FAIZ_ORANI, AvukatProLib.Extras.FaizKalem.ÖZEL_TUTAR_2);
            //    MyFoy.AV001_TI_BIL_FAIZCollection.Add(fz);
            //}
            //if (MyFoy.OZEL_TUTAR3_FAIZ_ISLESINMI)
            //{
            //    AV001_TI_BIL_FAIZ fz =
            //        AvukatProLib.Hesap.FaizHelper.IcraSabitFaizHesapla(MyFoy.OZEL_TUTAR3_FAIZ_TIP_ID.Value,
            //                                        MyFoy.OZEL_TUTAR3_FAIZ_BASLANGIC_TARIHI.Value,
            //                                        MyFoy.TAKIP_TARIHI.Value, MyFoy.OZEL_TUTAR3,
            //                                        MyFoy.OZEL_TUTAR3_DOVIZ_ID.Value, MyFoy.BIR_YIL_KAC_GUN,
            //                                        MyFoy.OZEL_TUTAR3_FAIZ_ORANI, AvukatProLib.Extras.FaizKalem.ÖZEL_TUTAR_3);
            //    MyFoy.AV001_TI_BIL_FAIZCollection.Add(fz);
            //}
        }

        private void _frmIcraTakip_Button_IhtiyatiHaciz_Click(object sender, EventArgs e)
        {
            FoyIhtiyatiHacizBilgileri();
        }

        private void _frmIcraTakip_Button_IhtiyatiTedbir_Click(object sender, EventArgs e)
        {
            FoyIhtiyatiTedbirBilgileri();
        }

        private void _frmIcraTakip_Button_IlamBilgileri_Click(object sender, EventArgs e)
        {
            FoyIlamBilgileri();
        }

        private void _frmIcraTakip_Button_Kaydet_Click(object sender, EventArgs e)
        {
            FoyKaydet();
        }

        private void _frmIcraTakip_Button_TakipOncesiOdemeleri_Click(object sender, EventArgs e)
        {
            FoyTakipOncesiOdemeler();
        }

        private void _frmIcraTakip_Button_Uyap_Click(object sender, EventArgs e)
        {
            frmAdimAdimEditoreGonder editorForm = new frmAdimAdimEditoreGonder();
            editorForm.SecilenCiktiTipi = frmAdimAdimEditoreGonder.CiktiTipi.Uyap;
            List<object> secilenFoy = new List<object>();
            secilenFoy.Add(this.MyFoy);
            editorForm.SelectedList = secilenFoy;
            editorForm.ChangePage("wizardPage1");
            editorForm.Show();

            //AvukatProUyap.Helper.GetUyap(BelgeUtil.Inits.context.VTI_ICRA_DOSYALARs.Single(item => item.ID == MyFoy.ID));
        }

        private void _frmIcraTakip_Button_Yeni_Click(object sender, EventArgs e)
        {
            FoyYeni();
        }

        private void _frmIcraTakip_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UyapBildirim != null)
                UyapBildirim.CagiranUyap.UyapGozdenGecir(UyapBildirim.IcraDosyalari, UyapBildirim.XmlDosyaYolu, UyapBildirim.geriBildirimYapilsin);
            dockManager2.SaveLayoutToRegistry("DockManager\\Layouts\\IcraLayout");
        }

        private void _frmIcraTakip_Load(object sender, EventArgs e)
        {
            CreateBindings();

            if (MyFoy != null)
            {
                var iliskiler = BelgeUtil.Inits.context.per_AV001_TDI_BIL_KAYIT_ILISKIs.Where(vi => vi.KAYNAK_KAYIT_ID == MyFoy.ID).ToList();
                var detay = DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_ICRA_FOY_ID(MyFoy.ID);

                if ((iliskiler != null && iliskiler.Count > 0) || detay.Count > 0)
                    c_titemIliskiliDosyalar.Image =
                        global::AdimAdimDavaKaydi.Properties.Resources.iliskili_dosyalar_red_16x16;
                else
                    c_titemIliskiliDosyalar.Image =
                        global::AdimAdimDavaKaydi.Properties.Resources.iliskili_dosyalar_mavi_16x16;
                bg = new BackgroundWorker();
                bg.DoWork += delegate
                {
                    //this.icraTarafBilgileri.BeginInvoke(new TarafBilgileriDoldur(TBD));
                };

                bg.RunWorkerAsync();
            }

            if (BelgeUtil.Inits.PaketAdi != 1)
                tabcBilgiler.Visible = true;

            //ucIcraHesapCetveli1.MyFoyDataSource = MyFoy;
            //ucIcraHesapCetveli1.MyTarafSource = MyFoy.AV001_TI_BIL_FOY_TARAFCollection;

            BindOzelKod();
            lueOzelKod1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod1_ButtonClick);
            lueOzelKod2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod1_ButtonClick);
            lueOzelKod3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod1_ButtonClick);
            lueOzelKod4.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod1_ButtonClick);

            CreateUcIcraCore();
            //tarafMenu();
            //dockManager2.RestoreLayoutFromRegistry("DockManager\\Layouts\\IcraLayout");

            //Takip herhangi bir klasöre baðlý deðil ise takibin istenilen klasöre baðlanmasý saðlanýyor. MB
            if (DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.GetByICRA_FOY_ID(MyFoy.ID).Count == 0)
            {
                btnKlasoreBagla.Tag = "BAÐLA";
                btnKlasoreBagla.Text = "ÝCRA DOSYASINI KLASÖRE BAÐLA";
                BelgeUtil.Inits.ProjeAdGetirYenile(lueKlasor);
            }
            else
            {
                btnKlasoreBagla.Tag = "ÇIKAR";
                btnKlasoreBagla.Text = "ÝCRA DOSYASINI KLASÖRDEN ÇIKAR";
                BelgeUtil.Inits.ProjeAdGetirYenile(lueKlasor);
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_ICRA_FOY>));
                if (MyFoy.AV001_TDIE_BIL_PROJE_ICRA_FOYCollection.Count > 0 && MyFoy.AV001_TDIE_BIL_PROJE_ICRA_FOYCollection[0].PROJE_ID > 0)
                    MyProje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(MyFoy.AV001_TDIE_BIL_PROJE_ICRA_FOYCollection[0].PROJE_ID);
                if (MyProje != null)
                {
                    if (MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Count == 0)
                        DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>));
                    bndProje.DataSource = MyProje;
                }
            }

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            cn.AddParams("@ID", MyFoy.ID);
            DataTable dt = cn.GetDataTable("select KAZANMA_ORANI, BEKLENEN_BITIS_TARIHI from dbo.AV001_TI_BIL_FOY where ID=@ID");
            spinKazanmaOrani.EditValue = null;
            dateBeklenenBitisTarihi.EditValue = null;
            if (dt.Rows.Count > 0)
            {
                spinKazanmaOrani.EditValue = dt.Rows[0]["KAZANMA_ORANI"];
                dateBeklenenBitisTarihi.EditValue = dt.Rows[0]["BEKLENEN_BITIS_TARIHI"];
            }
        }

        private void AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_IHTIYATI_TEDBIR tdbr = e.NewObject as AV001_TDI_BIL_IHTIYATI_TEDBIR;
            if (tdbr == null)
                tdbr = new AV001_TDI_BIL_IHTIYATI_TEDBIR();
            tdbr.ADLI_BIRIM_GOREV_ID = DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.Find("GOREV = 'AHM'")[0].ID;
            tdbr.TALEP_TARIHI = MyFoy.TAKIP_TARIHI.Value;
            tdbr.KARAR_TARIHI = tdbr.TALEP_TARIHI;
            tdbr.TEMINAT_TUR_ID = 1;
            tdbr.TEMINAT_TUTARI_DOVIZ_ID = 1;
            tdbr.TEMINAT_TUTARI = MyFoy.ASIL_ALACAK * (decimal)0.10; // TODO:Kullanýcý seçenekleri.. Oransal
            tdbr.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>();
            foreach (AV001_TI_BIL_FOY_TARAF taraf in AlacakliTaraflar)
            {
                AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF trf = tdbr.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.AddNew();
                trf.ICRA_CARI_TARAF_ID = taraf.CARI_ID;
                trf.ICRA_TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
            }
            tdbr.KAYIT_TARIHI = DateTime.Now;
            tdbr.KONTROL_NE_ZAMAN = DateTime.Now;
            tdbr.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            tdbr.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            tdbr.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            tdbr.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = tdbr;
        }

        private void AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatab = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
            muhatab.OKUNDU_MU = false;
            muhatab.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            muhatab.KONTROL_NE_ZAMAN = DateTime.Today;
            muhatab.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            muhatab.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            muhatab.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            muhatab.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            e.NewObject = muhatab;
        }

        private void AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT_YAPAN yapan = new AV001_TDI_BIL_TEBLIGAT_YAPAN();
            yapan.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            yapan.KONTROL_NE_ZAMAN = DateTime.Today;
            yapan.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            yapan.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            yapan.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            yapan.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            e.NewObject = yapan;
        }

        private void AV001_TDI_BIL_TEBLIGATCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            TList<AV001_TI_BIL_FOY_TARAF> listTakipEdilen = BorcluTaraflar;
            TList<AV001_TI_BIL_FOY_TARAF> listTakipEden = AlacakliTaraflar;
            AV001_TDI_BIL_TEBLIGAT addnew = new AV001_TDI_BIL_TEBLIGAT();
            addnew.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
            addnew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            addnew.KONTROL_NE_ZAMAN = DateTime.Today;
            addnew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addnew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            addnew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            addnew.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            addnew.TEBLIGAT_REFERANS_NO = AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit.TebligatReferansNoOlustur();
            addnew.TEBLIGAT_HEDEF_TIP = (short)AvukatProLib.Extras.TebligatHedefTip.Ýcra;
            addnew.KONU_ID = (int)AvukatProLib.Extras.TebligatKonu.HESAP_KAT_IHTARNAMESI;
            addnew.ADLI_BIRIM_GOREV_ID = (int)AvukatProLib.Extras.AdliBirimBolumGorev.NOT;
            TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> muhList = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
            TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> yapanList = new TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>();
            foreach (AV001_TI_BIL_FOY_TARAF item in listTakipEdilen)
            {
                addnew.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;
                AV001_TDI_BIL_TEBLIGAT_MUHATAP muh = addnew.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
                muh.TB_SUBEDEN_OLUMSUZ_CEVAP_TARIHI = DateTime.Now;
                muh.TB_SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH = DateTime.Now;
                muh.TB_SUBEDEN_YENI_ADRES_ISTEME_TARIHI = DateTime.Now;
                muh.TB_ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI = DateTime.Now;
                muh.MUHATAP_CARI_ID = (int)item.CARI_ID;
                muhList.Add(muh);
            }
            foreach (AV001_TI_BIL_FOY_TARAF item in listTakipEden)
            {
                addnew.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;
                AV001_TDI_BIL_TEBLIGAT_YAPAN yapan = addnew.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddNew();
                yapan.YAPAN_CARI_ID = (int)item.CARI_ID;
                yapanList.Add(yapan);
            }
            addnew.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection = muhList;
            addnew.AV001_TDI_BIL_TEBLIGAT_YAPANCollection = yapanList;

            e.NewObject = addnew;
        }

        private void AV001_TI_BIL_IHTIYATI_HACIZCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_IHTIYATI_HACIZ hcz = e.NewObject as AV001_TI_BIL_IHTIYATI_HACIZ;
            if (hcz == null)
                hcz = new AV001_TI_BIL_IHTIYATI_HACIZ();
            hcz.ADLI_BIRIM_GOREV_ID = DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.Find("GOREV = 'AHM'")[0].ID;
            hcz.TALEP_TARIHI = MyFoy.TAKIP_TARIHI;
            hcz.KARAR_TARIHI = hcz.TALEP_TARIHI;
            hcz.TEMINAT_TURU_ID = 1; //NAKÝT
            hcz.TEMINAT_TUTARI_DOVIZ_ID = 1;
            hcz.TEMINAT_TUTARI = MyFoy.ASIL_ALACAK * (decimal)0.10; // TODO:Kullanýcý seçenekleri.. Oransal
            hcz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection = new TList<AV001_TI_BIL_IHTIYATI_HACIZ_TARAF>();
            foreach (var taraf in AvukatProLib.Hesap.HesapAraclari.Icra.BorclulariGetir(MyFoy))
            {
                AV001_TI_BIL_IHTIYATI_HACIZ_TARAF trf = hcz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection.AddNew();
                trf.ICRA_CARI_TARAF_ID = taraf.CARI_ID;
                trf.TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
            }
            hcz.KAYIT_TARIHI = DateTime.Now;
            hcz.KONTROL_NE_ZAMAN = DateTime.Now;
            hcz.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            hcz.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            hcz.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            hcz.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = hcz;
        }

        private void AV001_TI_BIL_ILAM_MAHKEMESICollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_ILAM_MAHKEMESI mk = e.NewObject as AV001_TI_BIL_ILAM_MAHKEMESI;
            if (mk == null)
                mk = new AV001_TI_BIL_ILAM_MAHKEMESI();
            mk.INKAR_TAZMINAT_FAIZ_TIP_ID = 1;
            mk.INKAR_TAZMINAT_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir(1,
                                                                     mk.INKAR_TAZMINATI_DOVIZ_ID.Value,
                                                                     DateTime.Today);
            mk.INKAR_TAZMINATI_DOVIZ_ID = 1;
            mk.YARGILAMA_GIDERI_DOVIZ_ID = 1;
            mk.YARGILAMA_GIDERI_FAIZ_TIP_ID = 1;
            mk.YARGILAMA_GIDERI_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir(1,
                                                                       mk.YARGILAMA_GIDERI_DOVIZ_ID.Value,
                                                                       DateTime.Today);
            mk.ILAM_VEKALET_UCRETI_DOVIZ_ID = 1;
            mk.ILAM_VEKALET_UCRET_FAIZ_TIP_ID = 1;
            mk.ILAM_VEKALET_UCRET_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir(1,
                                                                         mk.ILAM_VEKALET_UCRETI_DOVIZ_ID.Value,
                                                                         DateTime.Today);
            mk.ILAM_TEBLIG_GIDER_FAIZ_TIP_ID = 1;
            mk.ILAM_TEBLIG_GIDER_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir(1,
                                                                        mk.ILAM_TEBLIG_GIDERI_DOVIZ_ID.Value,
                                                                        DateTime.Today);
            mk.ILAM_TEBLIG_GIDERI_DOVIZ_ID = 1;
            mk.BAKIYE_KARAR_HARCI_FAIZ_TIP_ID = 1;
            mk.BAKIYE_KARAR_HARCI_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir(1,
                                                                         mk.BAKIYE_KARAR_HARCI_DOVIZ_ID.Value,
                                                                         DateTime.Today);
            mk.BAKIYE_KARAR_HARCI_DOVIZ_ID = 1;
            mk.YARGITAY_ONAMA_HARCI_DOVIZ_ID = 1;
            mk.YARGITAY_ONAMA_HARCI_FAIZ_TIP_ID = 1;
            mk.YARGITAY_ONAMA_HARCI_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir(1,
                                                                           mk.YARGITAY_ONAMA_HARCI_DOVIZ_ID.Value,
                                                                           DateTime.Today);
            mk.KAYIT_TARIHI = DateTime.Now;
            mk.KONTROL_NE_ZAMAN = DateTime.Now;
            mk.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            mk.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            mk.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            mk.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            mk.ColumnChanged += mk_ColumnChanged;

            e.NewObject = mk;
        }

        private void btnCalistir_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Util.DavaCreated DC = new AdimAdimDavaKaydi.Util.DavaCreated();
            if (cmbIslem.SelectedIndex > -1)
            {
                if (AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme == null)
                    AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.GelismeBul(MyFoy);
                switch (cmbIslem.SelectedText)
                {
                    case "Ödeme Planý Hazýrla":
                        AdimAdimDavaKaydi.UserControls.frmOdemePlani tahutFormu = new AdimAdimDavaKaydi.UserControls.frmOdemePlani();
                        tahutFormu.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        tahutFormu.Show(MyFoy.ID, MyFoy.FOY_NO);
                        break;

                    case "Borçlu Taahhüdü Hazýrla":
                        if (bndIcraFoy.DataSource != null)
                        {
                            AV001_TI_BIL_FOY toplam = AvukatProLib.Hesap.KlasoreTaahhut.IcraFoyleriniTopla(this.foyList);
                            AdimAdimDavaKaydi.UserControls.frmOdemePlani tahutFormu2 = new AdimAdimDavaKaydi.UserControls.frmOdemePlani();
                            tahutFormu2.Show(toplam);
                        }
                        break;

                    case "UYAP Çýktýsý Hazýrla":
                        AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit frm = new AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit();
                        if (IcraDosyaKayitTiklandi != null)
                            IcraDosyaKayitTiklandi(this, new FrmIcraDosyaKayitEventArgs(frm));
                        frm.Show();
                        break;

                    case "Takip Seti Hazýrla":
                        frmAdimAdimEditoreGonder frmAdimEdit = new frmAdimAdimEditoreGonder();
                        frmAdimEdit.Show(MyFoy);
                        break;

                    case "Takip Talebi Hazýrla":
                        AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor editor = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();
                        editor.MdiParent = AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm;
                        AV001_TI_BIL_FOY fy = (AV001_TI_BIL_FOY)this.bndIcraFoy.Current;
                        TList<AV001_TI_BIL_FOY> lstfoys = new TList<AV001_TI_BIL_FOY>();
                        lstfoys.Add(fy);
                        editor.SelectedFoys = lstfoys;
                        editor.Show();
                        break;

                    case "Dosyayý Arþive At":
                        if (MyFoy.FOY_DURUM_ID == 7)
                            DevExpress.XtraEditors.XtraMessageBox.Show("Bu Dosya Daha Önce Arþive Atýlmýþ");
                        else
                            MyFoy.FOY_DURUM_ID = 7;
                        break;

                    case "Dosyayý Faal Yap":
                        if (MyFoy.FOY_DURUM_ID == 2)
                            DevExpress.XtraEditors.XtraMessageBox.Show("Bu Dosya Zaten FAAL ..");
                        else
                            MyFoy.FOY_DURUM_ID = 2;
                        break;

                    case "Dosyayý Ýade Et":
                        if (MyFoy.TAKIBIN_MUVEKKILE_IADE_TARIHI != null)
                            DevExpress.XtraEditors.XtraMessageBox.Show("Bu Dosya Daha Önce Müvekkile Ýade Edilmiþ..");
                        else
                        {
                            MyFoy.TAKIBIN_MUVEKKILE_IADE_TARIHI = DateTime.Now;
                            MyFoy.TAKIBIN_MUVEKKILE_IADE_NEDENI_ID = 8;
                        }
                        break;

                    case "Sýk Kullanýlanlara Ekle":
                        AV001_TI_BIL_FOY takip = MyFoy;
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(takip, false, DeepLoadType.IncludeChildren, typeof(TList<TDI_KOD_ADLI_BIRIM_ADLIYE>), typeof(TList<TDI_KOD_ADLI_BIRIM_GOREV>), typeof(TList<TDI_KOD_ADLI_BIRIM_NO>));
                        AvukatProLib.Extras.ModulTip tablo = AvukatProLib.Extras.ModulTip.Icra;
                        string adliye = string.Empty;
                        string gorev = string.Empty;
                        string no = string.Empty;
                        if (takip.ADLI_BIRIM_ADLIYE_IDSource != null)
                            adliye = takip.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                        if (takip.ADLI_BIRIM_GOREV_IDSource != null)
                            gorev = takip.ADLI_BIRIM_GOREV_IDSource.GOREV;
                        if (takip.ADLI_BIRIM_NO_IDSource != null)
                            no = takip.ADLI_BIRIM_NO_IDSource.NO;
                        string AD = string.Format("{0} {1} {2} {3} E. nolu Dosyasý", adliye, gorev, no, takip.ESAS_NO);
                        AdimAdimDavaKaydi.Forms.rfrmSikKullanilanEkle frmSikKullan = new AdimAdimDavaKaydi.Forms.rfrmSikKullanilanEkle();
                        frmSikKullan.ShowDialog(tablo, takip.ID, AD);
                        break;

                    case "Dava MBB":
                        DC.MalBeyaniDavasýAc(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava MBB Eksik Beyan":
                        DC.EksikMalBeyaniDavasýAc(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Taahhüdü Ýhlal":
                        DC.IhlalDavasýAc(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Ýtirazýn Kaldýrýlmasý":
                        DC.ItirazinKaldirilmasiDavasýAc(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Ýtirazýn Kaldýrýlmasý  ve Ýflas":
                        DC.ItirazinKaldirillmasiIflasDavasýAc(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Ýtirazýn Ýptali":
                        DC.ItirazinKaldirilmasiDavasýAc(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Olumsuz Tespit":
                        DC.OlumsuzTespitDavasýAc(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Ýstihkak":
                        DC.DavaIstishak(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Ýstirdat":
                        DC.DavaIstirdat(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Ýhalenin Feshi":
                        DC.DavaIhaleninFeshi(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Senet Üzerinde Tahrifat":
                        DC.DavaTahrifat(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Karþýlýksýz Çek":
                        DC.KarsiliksizCek(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Nafaka Þartýný  Ýhlal":
                        DC.NafakaSartiniIhlal(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Emniyeti Suistimal":
                        DC.EmniyetiSuistimal(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Memur Ýþlemini Þikayet":
                        DC.MemuruSikayet(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Hileli Ýflas":
                        DC.HileliIflas(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Ýflas":
                        DC.Iflas(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Ýhtiyati Haciz":
                        DC.IhtiyatiHaciz(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Ýhtiyati Tedbir":
                        DC.IhtiyatiTedbir(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Kýymet Takdirine Ýtiraz":
                        DC.KiymetTaktirineItiraz(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Ýmzaya Ýtiraz":
                        DC.ImzayaItiraz(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Tahliye Edilen Gayrimenkule Girmek":
                        DC.TahliyeEdilenGayrimenkul(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Takibin Ýptali":
                        DC.TakibinIptali(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Tahliye ":
                        DC.Tahliye(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Dava Tasarrufun Ýptali":
                        DC.DavaTasarrufunIptali(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy, _Kaydedildi);
                        break;

                    case "Suç Duyurusu Oluþtur":
                        DC.SucDuyurusuOlustur(MyFoy);
                        break;

                    case "Suç Duyurusu Oluþtur(Karþýlýksýz Çek)":
                        DC.SucDuyurusuOlusturKarsiliksizCek(MyFoy);
                        break;
                    default:
                        break;
                }
            }
            else if (cmbIslem.SelectedIndex == -1)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Tercih Yapýnýz");
            }
        }

        private void c_bbAjanda_ItemClick(object sender, EventArgs e)
        {
            #region <MB-20100427> Dosya Ajandasý Yeniden Düzenlendi.

            //Kullanýcýnýn o dosyada sorumlu avukat olup olmadýðý kontrolü yapýlýyor.
            TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT> dosyaSorumluAvukatlari =
                DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.GetByICRA_FOY_ID(MyFoy.ID);
            bool kullaniciDosyadaSorumluAvukat = false;

            foreach (var item in dosyaSorumluAvukatlari)
            {
                if (item.SORUMLU_AVUKAT_CARI_ID == AvukatProLib.Kimlik.Bilgi.CARI_ID.Value)
                {
                    kullaniciDosyadaSorumluAvukat = true;
                    break;
                }
                else
                    kullaniciDosyadaSorumluAvukat = false;
            }

            if (!kullaniciDosyadaSorumluAvukat)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Dosyada Sorumlu Avukat olmadýðýnýz için" + Environment.NewLine + "gösterilecek iþleriniz yok.",
                    "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Kullanýcýnýn Dosyadaki iþlerini buluyor.
            var isler = BelgeUtil.Inits.context.per_AV001_TDI_BIL_IS_Asistans.Where(item => BelgeUtil.Inits.context.NN_IS_ICRA_FOYs.Where(icra => icra.ICRA_FOY_ID == MyFoy.ID).Select(t => t.IS_ID).Contains(item.ID) && item.AJANDADA_GORUNSUN_MU && BelgeUtil.Inits.context.AV001_TDI_BIL_IS_TARAFs.Where(c => c.CARI_ID == AvukatProLib.Kimlik.Bilgi.CARI_ID && c.IS_TARAF_ID == 2).Select(vi => vi.IS_ID).Contains(item.ID)).ToList();

            //Dosyanýn iliþkili olduðu dosyalarýn iþlerini buluyor.
            AV001_TDI_BIL_KAYIT_ILISKI iliski =
                DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByILISKI_TUR_IDKAYNAK_KAYIT_ID(
                    (int?)AvukatProLib.Extras.KayitIliskiTur.ICRA_DOSYASI, MyFoy.ID);
            if (iliski != null)
            {
                TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> iliskiDetaylari =
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByKAYIT_ILISKI_ID(iliski.ID);
                KayitIliskiDetayIsleriGetir(iliskiDetaylari, isler);
            }
            else
            {
                TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> iliskiDetaylari =
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_KAYIT_ID(MyFoy.ID);
                DetaydanIliskiliIsleriGetir(iliskiDetaylari, isler);
            }

            //aykut önemli 27.02.2013
            //global::AdimAdimDavaKaydi.Ajanda.Forms.MainForms.frmAjanda ajanda =
            //    new global::AdimAdimDavaKaydi.Ajanda.Forms.MainForms.frmAjanda(isler, MyFoy, true);
            //ajanda.Show();

            #endregion <MB-20100427> Dosya Ajandasý Yeniden Düzenlendi.
        }

        private void CreateUcIcraCore()
        {
            if (ucIcraCore1 == null)
            {
                this.ucIcraCore1 = new AdimAdimDavaKaydi.IcraTakipForms.ucIcraCore();
                ucIcraCore1.SuspendLayout();
                this.ucIcraCore1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.ucIcraCore1.Location = new System.Drawing.Point(0, 0);
                this.ucIcraCore1.Name = "ucIcraCore1";
                this.ucIcraCore1.Size = new System.Drawing.Size(915, 580);
                this.ucIcraCore1.TabIndex = 0;
                this.tabGelismeler.Controls.Add(this.ucIcraCore1);
                ucIcraCore1.ResumeLayout(false);
            }
        }

        private void frmIcraDosyaKayit_Button_Ihtarname_Click(object sender, EventArgs e)
        {
            if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count > 0)
            {
                AdimAdimDavaKaydi.Forms.frmTebligatKaydetVgrid ihtarnamekayit = new AdimAdimDavaKaydi.Forms.frmTebligatKaydetVgrid();
                ihtarnamekayit.Ihtarname = true;
                MyFoy.AV001_TDI_BIL_TEBLIGATCollection.AddingNew += AV001_TDI_BIL_TEBLIGATCollection_AddingNew;
                TList<AV001_TDI_BIL_TEBLIGAT> tbList = new TList<AV001_TDI_BIL_TEBLIGAT>();
                tbList.Add(MyFoy.AV001_TDI_BIL_TEBLIGATCollection.AddNew());
                ihtarnamekayit.MyDataSource = tbList;
                ihtarnamekayit.Show(MyFoy);
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Dosyada Taraf Yok Taraf olmadan Ýhtarname Giremezsiniz...");
            }
        }

        private void frmIcraDosyaKayit_Button_Masraf_Click(object sender, EventArgs e)
        {
            frmMasrafAvansKayitHizli masrafmini = new frmMasrafAvansKayitHizli();
            masrafmini.Show(MyFoy);
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Ac_Click += _frmIcraTakip_Button_Ac_Click;
            this.Button_Kaydet_Click += _frmIcraTakip_Button_Kaydet_Click;
            this.Button_TakipOncesiOdemeleri_Click += _frmIcraTakip_Button_TakipOncesiOdemeleri_Click;
            this.Button_IlamBilgileri_Click += _frmIcraTakip_Button_IlamBilgileri_Click;
            this.Button_IhtiyatiTedbir_Click += _frmIcraTakip_Button_IhtiyatiTedbir_Click;
            this.Button_IhtiyatiHaciz_Click += _frmIcraTakip_Button_IhtiyatiHaciz_Click;
            this.Button_HesaplanmisKalemler_Click += _frmIcraTakip_Button_HesaplanmisKalemler_Click;
            this.Button_Yeni_Click += _frmIcraTakip_Button_Yeni_Click;
            this.Button_Word_Click += btnDoc_Click;
            this.Button_Outlook_Click += btnOutlook_Click;
            this.Button_PDF_Click += btnPDF_Click;
            this.Button_Excel_Click += btnXLS_Click;
            this.Button_Ajanda_Click += c_bbAjanda_ItemClick;
            this.Button_Editor_Click += c_bbTakipYazisma_ItemClick;
            this.Button_IliskiliDosyalar_Click += btnIliskiliDosya_ItemClick;
            this.Button_Ihtarname_Click += frmIcraDosyaKayit_Button_Ihtarname_Click;
            this.Button_Masraf_Click += frmIcraDosyaKayit_Button_Masraf_Click;
            this.Button_Uyap_Click += _frmIcraTakip_Button_Uyap_Click;
            this.Button_AdimAdimEditore_Click += _frmIcraTakip_Button_AdimAdimEditore_Click;
            this.tsBtn_Hesapla.ToolTipText = "Simülasyon (Taahhüt Sihirbazý)";
            this.Button_Hesapla_Click += new EventHandler<EventArgs>(_frmIcraTakip_Button_Hesapla_Click);//Simülasyon
        }

        private void icraTarafBilgileri_Load(object sender, EventArgs e)
        {
            if (ucIcraCore1 == null)
                CreateUcIcraCore();
            bckWorker.RunWorkerAsync();
        }

        private void lueTakibinDurumu_EditValueChanged(object sender, EventArgs e)
        {
            if (lueFormTip.EditValue == null)
                return;
            DevExpress.XtraEditors.LookUpEdit lue = (sender as DevExpress.XtraEditors.LookUpEdit);

            AvukatProLib.Extras.FoyDurum durum = (AvukatProLib.Extras.FoyDurum)lue.EditValue;

            switch (durum)
            {
                case AvukatProLib.Extras.FoyDurum.AÇILACAK:
                case AvukatProLib.Extras.FoyDurum.FAAL:
                case AvukatProLib.Extras.FoyDurum.ITIRAZLI:
                case AvukatProLib.Extras.FoyDurum.ÝDARÝ_ÝÞLER:
                case AvukatProLib.Extras.FoyDurum.ÝDARÝ_TAKÝP:
                case AvukatProLib.Extras.FoyDurum.EVRAK:
                    lue.BackColor = System.Drawing.Color.Green;
                    lue.ForeColor = System.Drawing.Color.White;
                    break;

                case AvukatProLib.Extras.FoyDurum.DÜÞME:
                case AvukatProLib.Extras.FoyDurum.KARAR:
                case AvukatProLib.Extras.FoyDurum.TEMYÝZ:
                case AvukatProLib.Extras.FoyDurum.KAPATILACAK:
                case AvukatProLib.Extras.FoyDurum.ÝÝDD:
                case AvukatProLib.Extras.FoyDurum.SULH:
                case AvukatProLib.Extras.FoyDurum.KISMEN_TAHSILAT:
                case AvukatProLib.Extras.FoyDurum.TERKÝN:
                case AvukatProLib.Extras.FoyDurum.BONIFIKASYON:
                case AvukatProLib.Extras.FoyDurum.KISMÝ_ÝNFAZ:
                case AvukatProLib.Extras.FoyDurum.MAHKEME_KARARI_ILE_IPTAL:
                case AvukatProLib.Extras.FoyDurum.TAKIPSIZ:
                case AvukatProLib.Extras.FoyDurum.KREDISI_KAPANDI:
                case AvukatProLib.Extras.FoyDurum.DERKENAR:
                case AvukatProLib.Extras.FoyDurum.KISMEN_ACIZ:
                    lue.BackColor = System.Drawing.Color.Gold;
                    lue.ForeColor = System.Drawing.Color.Black;
                    break;

                case AvukatProLib.Extras.FoyDurum.ÝADE:
                case AvukatProLib.Extras.FoyDurum.SEMERESÝZ:
                case AvukatProLib.Extras.FoyDurum.ACÝZ:
                case AvukatProLib.Extras.FoyDurum.FERAGAT:
                case AvukatProLib.Extras.FoyDurum.ÝNFAZ:
                case AvukatProLib.Extras.FoyDurum.ÝNFAZ_ZAMAN_AÞIMI:
                case AvukatProLib.Extras.FoyDurum.TAHSILAT:
                case AvukatProLib.Extras.FoyDurum.INDIRIMLI_TAHSILAT:
                case AvukatProLib.Extras.FoyDurum.ÝNFAZ_REHÝN_AÇIÐI:
                case AvukatProLib.Extras.FoyDurum.ARÞÝV:
                case AvukatProLib.Extras.FoyDurum.KKK:
                case AvukatProLib.Extras.FoyDurum.ACIZ_DERKENAR:
                case AvukatProLib.Extras.FoyDurum.KAPATILDI:
                    lue.BackColor = System.Drawing.Color.Red;
                    lue.ForeColor = System.Drawing.Color.White;
                    break;
                default:
                    break;
            }
        }

        private void mk_ColumnChanged(object sender, AV001_TI_BIL_ILAM_MAHKEMESIEventArgs e)
        {
            AV001_TI_BIL_ILAM_MAHKEMESI gonderen = (AV001_TI_BIL_ILAM_MAHKEMESI)sender;
            switch (e.Column)
            {
                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.BAKIYE_KARAR_HARCI_FAIZ_TIP_ID:
                    gonderen.BAKIYE_KARAR_HARCI_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value,
                                                                                       gonderen.
                                                                                           BAKIYE_KARAR_HARCI_DOVIZ_ID,
                                                                                       DateTime.Today);

                    break;

                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.ILAM_TEBLIG_GIDER_FAIZ_TIP_ID:
                    gonderen.ILAM_TEBLIG_GIDER_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value,
                                                                                      gonderen.
                                                                                          ILAM_TEBLIG_GIDERI_DOVIZ_ID,
                                                                                      DateTime.Today);
                    break;

                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.ILAM_VEKALET_UCRET_FAIZ_TIP_ID:
                    gonderen.ILAM_VEKALET_UCRET_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value,
                                                                                       gonderen.
                                                                                           ILAM_VEKALET_UCRETI_DOVIZ_ID,
                                                                                       DateTime.Today);
                    break;

                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.INKAR_TAZMINAT_FAIZ_TIP_ID:
                    gonderen.INKAR_TAZMINAT_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value,
                                                                                   gonderen.INKAR_TAZMINATI_DOVIZ_ID,
                                                                                   DateTime.Today);
                    break;

                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.YARGILAMA_GIDERI_FAIZ_TIP_ID:
                    gonderen.YARGILAMA_GIDERI_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value,
                                                                                     gonderen.YARGILAMA_GIDERI_DOVIZ_ID,
                                                                                     DateTime.Today);
                    break;

                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.YARGITAY_ONAMA_HARCI_FAIZ_TIP_ID:
                    gonderen.YARGITAY_ONAMA_HARCI_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value,
                                                                                         gonderen.
                                                                                             YARGITAY_ONAMA_HARCI_DOVIZ_ID,
                                                                                         DateTime.Today);
                    break;
            }
        }

        #region Editor,Word,Outlook,Excell,Pdf button click

        private void btnDoc_Click(object sender, EventArgs e)
        {
            WordAc();

            //if (!new Tools(MyFoy).OpenWord()) XtraMessageBox.Show("Word programý baþlatýlamadý.", "AvukatPro");
            ////Tools.OpenProgram(ExtensionToOpenProgram.doc, bndIcraFoy.DataSource); //Commented out by ARCH
        }

        private void btnOutlook_Click(object sender, EventArgs e)
        {
            OutlookAc();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf, bndIcraFoy.DataSource);
        }

        private void btnXLS_Click(object sender, EventArgs e)
        {
            ExcelAc();

            //if (!new Tools(MyFoy).OpenExcel()) XtraMessageBox.Show("Excel programý baþlatýlamadý.", "AvukatPro");
            ////Tools.OpenProgram(ExtensionToOpenProgram.xls, bndIcraFoy.DataSource); //Commented out by ARCH
        }

        private void c_bbTakipYazisma_ItemClick(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor editor = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();
            editor.MdiParent = AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm;
            AV001_TI_BIL_FOY fy = (AV001_TI_BIL_FOY)this.bndIcraFoy.Current;
            TList<AV001_TI_BIL_FOY> lstfoys = new TList<AV001_TI_BIL_FOY>();
            lstfoys.Add(fy);
            editor.SelectedFoys = lstfoys;
            editor.Show();
        }

        #endregion Editor,Word,Outlook,Excell,Pdf button click

        #region Open Outlook Message (ARCH)

        public bool Mode { get; set; }

        public string Subject { get; set; }

        public void ucBelgeKayitUfak1_BelgeKaydedildi(object sender, AdimAdimDavaKaydi.Belge.UserControls.ucBelgeKayitUfak.BelgeKaydedildiEventArgs e)
        {
            if (e.Belge != null)
            {
                if (BelgeUtil.Inits._BelgeGetir == null)
                    BelgeUtil.Inits._BelgeGetir = BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.ToList();
                else
                    BelgeUtil.Inits._BelgeGetir.Add(BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.Where(vi => vi.ID == e.Belge.ID).FirstOrDefault());

                //ucIcraCore1.icraGridler.ucbelgetakip1.RefreshGridDataSource(e.Belge);
            }
        }

        private void objOutlook_ItemSend(object item, ref bool cancel)
        {
            Subject = ((Microsoft.Office.Interop.Outlook.MailItem)item).Subject;
            ((Microsoft.Office.Interop.Outlook.MailItem)item).SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\temporary.msg", Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
            Mode = true;
        }

        private void OutlookAc()
        {
            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\temporary.msg";
            Microsoft.Office.Interop.Outlook.Application objOutlook = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mic = (Microsoft.Office.Interop.Outlook.MailItem)(objOutlook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem));

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (MyFoy.TAKIP_TALEP_ID.HasValue)
                sb.Append(AvukatPro.Services.Implementations.DosyaService.GetTakipTalepById((int)MyFoy.TAKIP_TALEP_ID));
            if (MyFoy.ADLI_BIRIM_ADLIYE_ID.HasValue)
                sb.Append(" - " + AvukatPro.Services.Implementations.DosyaService.GetAdliBirimAdliyeById((int)MyFoy.ADLI_BIRIM_ADLIYE_ID));
            if (MyFoy.ADLI_BIRIM_NO_ID.HasValue)
                sb.Append(" / " + AvukatPro.Services.Implementations.DosyaService.GetAdliBirimNoById((int)MyFoy.ADLI_BIRIM_NO_ID));
            if (MyFoy.ADLI_BIRIM_GOREV_ID.HasValue)
                sb.Append(" / " + AvukatPro.Services.Implementations.DosyaService.GetAdliBirimGorevById((int)MyFoy.ADLI_BIRIM_GOREV_ID));

            sb.Append(" - " + MyFoy.ESAS_NO);

            mic.Subject = sb.ToString();

            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));
            var u = MyFoy.AV001_TI_BIL_FOY_TARAFCollection;
            string emails = "";
            AV001_TDI_BIL_CARI ins = new AV001_TDI_BIL_CARI();
            for (int run = 0; run < u.Count; run++)
            {
                ins = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(u[run].CARI_ID.Value);
                if (!String.IsNullOrEmpty(ins.EMAIL_1))
                    emails += ins.EMAIL_1 + "; ";
                if (!String.IsNullOrEmpty(ins.EMAIL_2))
                    emails += ins.EMAIL_2 + "; ";
            }
            if (emails.Length > 2)
                mic.To = emails.Substring(0, emails.Length - 2);

            objOutlook.ItemSend += new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_ItemSendEventHandler(objOutlook_ItemSend);

            mic.Display(true);

            bool control = false;
            try
            { bool g = mic.Saved; control = g; }
            catch { control = false; }

            if (Mode || control)
            {
                if (!Mode && control)
                    try
                    {
                        mic.SaveAs(fileName, Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                Mode = control = false;
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Ýletiyi dosyayla iliþkilendirmek ister misiniz?", "AvukatPro", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    using (AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak belge = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak())
                    {
                        TList<AV001_TDIE_BIL_BELGE> lstbelge = new TList<AV001_TDIE_BIL_BELGE>();
                        AV001_TDIE_BIL_BELGE blg = new AV001_TDIE_BIL_BELGE();
                        blg.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                        blg.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
                        blg.BELGE_TUR_ID = 20;
                        blg.SUC_OLAY_VADE_TARIHI = DateTime.Now;
                        blg.YAZILMA_TARIHI = DateTime.Now;
                        blg.BELGE_NO = BelgeNoGetir();
                        blg.BELGE_ADI = Subject;
                        Subject = "";
                        blg.DOSYA_ADI = fileName;
                        blg.DOKUMAN_UZANTI = new System.IO.FileInfo(fileName).Extension.Substring(1);
                        blg.STAMP = 0;

                        if (System.IO.File.Exists(fileName))
                        {
                            System.IO.FileStream fss = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
                            byte[] veri = new byte[fss.Length];
                            fss.Read(veri, 0, veri.Length);
                            blg.ICERIK = veri;
                            fss.Close();
                            System.IO.File.Delete(fileName);
                        }

                        blg.ESAS_NO = MyFoy.ESAS_NO;
                        blg.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                        blg.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
                        blg.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                        lstbelge.Add(blg);

                        switch (MyFoy.TableName)
                        {
                            case "AV001_TI_BIL_FOY":
                                belge.ucBelgeKayitUfak1.ModulID = 1;
                                break;

                            case "AV001_TD_BIL_FOY":
                                belge.ucBelgeKayitUfak1.ModulID = 2;
                                break;

                            case "AV001_TD_BIL_HAZIRLIK":
                                belge.ucBelgeKayitUfak1.ModulID = 3;
                                break;

                            case "AV001_TDI_BIL_SOZLESME":
                                belge.ucBelgeKayitUfak1.ModulID = 5;
                                break;

                            case "AV001_TDIE_BIL_PROJE":
                                belge.ucBelgeKayitUfak1.ModulID = 11;
                                break;
                            default:
                                break;
                        }

                        belge.MyDataSource = lstbelge;
                        belge.OpenedRecord = MyFoy;
                        belge.Record = lstbelge[0];

                        //       belge.ucBelgeKayitUfak1.Saved += ucBelgeKayitUfak1_Saved;
                        belge.ucBelgeKayitUfak1.Duzenle = true;
                        belge.ucBelgeKayitUfak1.BelgeKaydedildi += new EventHandler<AdimAdimDavaKaydi.Belge.UserControls.ucBelgeKayitUfak.BelgeKaydedildiEventArgs>(ucBelgeKayitUfak1_BelgeKaydedildi);

                        belge.ucBelgeKayitUfak1.KayitIlistir(null, null);
                        belge.ucBelgeKayitUfak1.c_lueModul.Enabled = false;
                        belge.ucBelgeKayitUfak1.c_lueDosya.Enabled = false;
                        belge.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        belge.MdiParent = null;
                        belge.ShowDialog();
                    }
                }
            }
        }

        #endregion Open Outlook Message (ARCH)

        #region Open Word Document (ARCH)

        private Microsoft.Office.Interop.Word.Document adoc;
        private Microsoft.Office.Interop.Word.ApplicationClass WordApp;

        //protected void WordApp_DocumentBeforeSave(Microsoft.Office.Interop.Word.Document doc, ref bool I, ref bool II)
        //{
        //}

        protected void WordApp_DocumentBeforeClose(Microsoft.Office.Interop.Word.Document doc, ref bool I)
        {
            if (!doc.Saved)
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Döküman kaydedilmedi. Kaydetmek istiyormusunuz?", "Uyarý", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    doc.Save();

            if (doc.Saved)
            {
                string fileName = doc.FullName;

                object saveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdPromptToSaveChanges;
                object originalFormat = Microsoft.Office.Interop.Word.WdOriginalFormat.wdWordDocument;
                object routeDocument = true;

                doc.Close(ref saveChanges, ref originalFormat, ref routeDocument);

                if (DevExpress.XtraEditors.XtraMessageBox.Show("Ýletiyi dosyayla iliþkilendirmek ister misiniz?", "AvukatPro", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak belge = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();
                    TList<AV001_TDIE_BIL_BELGE> lstbelge = new TList<AV001_TDIE_BIL_BELGE>();
                    AV001_TDIE_BIL_BELGE blg = new AV001_TDIE_BIL_BELGE();
                    blg.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                    blg.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
                    blg.BELGE_TUR_ID = 7;
                    blg.SUC_OLAY_VADE_TARIHI = DateTime.Now;
                    blg.YAZILMA_TARIHI = DateTime.Now;
                    blg.BELGE_NO = BelgeNoGetir();
                    blg.BELGE_ADI = System.IO.Path.GetFileName(fileName);
                    blg.DOSYA_ADI = fileName;
                    blg.DOKUMAN_UZANTI = new System.IO.FileInfo(fileName).Extension.Substring(1);
                    blg.STAMP = 0;

                    if (System.IO.File.Exists(fileName))
                    {
                        System.IO.FileStream fss = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
                        byte[] veri = new byte[fss.Length];
                        fss.Read(veri, 0, veri.Length);
                        blg.ICERIK = veri;
                        fss.Close();

                        //System.IO.File.Delete(fileName);
                    }

                    blg.ESAS_NO = MyFoy.ESAS_NO;
                    blg.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                    blg.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
                    blg.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                    lstbelge.Add(blg);

                    switch (MyFoy.TableName)
                    {
                        case "AV001_TI_BIL_FOY":
                            belge.ucBelgeKayitUfak1.ModulID = 1;
                            break;

                        case "AV001_TD_BIL_FOY":
                            belge.ucBelgeKayitUfak1.ModulID = 2;
                            break;

                        case "AV001_TD_BIL_HAZIRLIK":
                            belge.ucBelgeKayitUfak1.ModulID = 3;
                            break;

                        case "AV001_TDI_BIL_SOZLESME":
                            belge.ucBelgeKayitUfak1.ModulID = 5;
                            break;

                        case "AV001_TDIE_BIL_PROJE":
                            belge.ucBelgeKayitUfak1.ModulID = 11;
                            break;
                        default:
                            break;
                    }

                    belge.MyDataSource = lstbelge;
                    belge.OpenedRecord = MyFoy;
                    belge.Record = lstbelge[0];

                    //       belge.ucBelgeKayitUfak1.Saved += ucBelgeKayitUfak1_Saved;
                    belge.ucBelgeKayitUfak1.Duzenle = true;
                    belge.ucBelgeKayitUfak1.BelgeKaydedildi += ucBelgeKayitUfak1_BelgeKaydedildi;

                    belge.ucBelgeKayitUfak1.KayitIlistir(null, null);
                    belge.ucBelgeKayitUfak1.c_lueModul.Enabled = false;
                    belge.ucBelgeKayitUfak1.c_lueDosya.Enabled = false;
                    belge.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    belge.MdiParent = null;
                    belge.ShowDialog();
                }
            }
        }

        private void WordAc()
        {
            object missing = System.Reflection.Missing.Value;

            //object Visible = true;
            object start1 = 0;

            //object end1 = 0;
            WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            adoc = WordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            Microsoft.Office.Interop.Word.Range rng = adoc.Range(ref start1, ref missing);

            //WordApp.DocumentBeforeSave += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeSaveEventHandler(WordApp_DocumentBeforeSave);
            WordApp.DocumentBeforeClose += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler(WordApp_DocumentBeforeClose);
            adoc.Save();
            WordApp.Visible = true;
        }

        #endregion Open Word Document (ARCH)

        #region Open Excel WorkBook (ARCH)

        private Microsoft.Office.Interop.Excel.Application app = null;
        private bool controller = false;
        private Microsoft.Office.Interop.Excel.Workbook workbook = null;
        private Microsoft.Office.Interop.Excel.Worksheet worksheet = null;

        protected void app_WorkbookBeforeClose(Microsoft.Office.Interop.Excel.Workbook wb, ref bool I)
        {
            if (controller)
            {
                controller = false;
                return;
            }

            controller = true;

            if (!wb.Saved)
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Döküman kaydedilmedi. Kaydetmek istiyormusunuz?", "Uyarý", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    wb.SaveAs();

            string filename = wb.FullName;
            if (wb.Saved && !string.IsNullOrEmpty(wb.FullName.Trim()))
            {
                wb.Close(false, "ddddd", false);

                if (DevExpress.XtraEditors.XtraMessageBox.Show("Ýletiyi dosyayla iliþkilendirmek ister misiniz?", "AvukatPro", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak belge = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();
                    TList<AV001_TDIE_BIL_BELGE> lstbelge = new TList<AV001_TDIE_BIL_BELGE>();
                    AV001_TDIE_BIL_BELGE blg = new AV001_TDIE_BIL_BELGE();
                    blg.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                    blg.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
                    blg.BELGE_TUR_ID = 7;
                    blg.SUC_OLAY_VADE_TARIHI = DateTime.Now;
                    blg.YAZILMA_TARIHI = DateTime.Now;
                    blg.BELGE_NO = BelgeNoGetir();
                    blg.BELGE_ADI = System.IO.Path.GetFileName(filename);
                    blg.DOSYA_ADI = filename;
                    blg.DOKUMAN_UZANTI = new System.IO.FileInfo(filename).Extension.Substring(1);
                    blg.STAMP = 0;

                    if (System.IO.File.Exists(filename))
                    {
                        try
                        {
                            System.IO.FileStream fss = new System.IO.FileStream(filename, System.IO.FileMode.Open);
                            byte[] veri = new byte[fss.Length];
                            fss.Read(veri, 0, veri.Length);
                            blg.ICERIK = veri;
                            fss.Close();

                            //System.IO.File.Delete(fileName);
                        }
                        catch { }
                    }

                    blg.ESAS_NO = MyFoy.ESAS_NO;
                    blg.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                    blg.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
                    blg.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                    lstbelge.Add(blg);

                    switch (MyFoy.TableName)
                    {
                        case "AV001_TI_BIL_FOY":
                            belge.ucBelgeKayitUfak1.ModulID = 1;
                            break;

                        case "AV001_TD_BIL_FOY":
                            belge.ucBelgeKayitUfak1.ModulID = 2;
                            break;

                        case "AV001_TD_BIL_HAZIRLIK":
                            belge.ucBelgeKayitUfak1.ModulID = 3;
                            break;

                        case "AV001_TDI_BIL_SOZLESME":
                            belge.ucBelgeKayitUfak1.ModulID = 5;
                            break;

                        case "AV001_TDIE_BIL_PROJE":
                            belge.ucBelgeKayitUfak1.ModulID = 11; //Klasör
                            break;
                        default:
                            break;
                    }

                    belge.MyDataSource = lstbelge;
                    belge.OpenedRecord = MyFoy;
                    belge.Record = lstbelge[0];

                    //belge.ucBelgeKayitUfak1.Saved += ucBelgeKayitUfak1_Saved;
                    belge.ucBelgeKayitUfak1.Duzenle = true;
                    belge.ucBelgeKayitUfak1.BelgeKaydedildi += ucBelgeKayitUfak1_BelgeKaydedildi;

                    belge.ucBelgeKayitUfak1.KayitIlistir(null, null);
                    belge.ucBelgeKayitUfak1.c_lueModul.Enabled = false;
                    belge.ucBelgeKayitUfak1.c_lueDosya.Enabled = false;
                    belge.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    belge.MdiParent = null;
                    belge.ShowDialog();
                }
            }
            else app.Quit();
        }

        private void ExcelAc()
        {
            try
            {
                object missing = System.Reflection.Missing.Value;
                app = new Microsoft.Office.Interop.Excel.Application();
                app.WorkbookBeforeClose += new Microsoft.Office.Interop.Excel.AppEvents_WorkbookBeforeCloseEventHandler(app_WorkbookBeforeClose);
                app.Visible = true;
                workbook = app.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                workbook.Save();
            }
            catch { }
        }

        #endregion Open Excel WorkBook (ARCH)

        #region Get New Belge No (ARCH)

        private string BelgeNoGetir()
        {
            string yeniBelgeNo = string.Empty;
            var enSonBelgeNo = DataRepository.Provider.ExecuteScalar(
                System.Data.CommandType.Text, "select top(1)BELGE_NO from AV001_TDIE_BIL_BELGE order by ID desc");
            if (enSonBelgeNo != null && enSonBelgeNo.ToString().Contains("B-20"))
            {
                string[] dizi = enSonBelgeNo.ToString().Split('~');
                int yeniBelgeNoSayi = Convert.ToInt32(dizi[1]) + 1;
                yeniBelgeNo = String.Format("B-{0}~{1}", DateTime.Today.Year, yeniBelgeNoSayi);
                return yeniBelgeNo;
            }
            else
            {
                yeniBelgeNo = String.Format("B-{0}~{1}", DateTime.Today.Year, "10000");
                return yeniBelgeNo;
            }
        }

        #endregion Get New Belge No (ARCH)

        #region <MB-20100427> KayitIliskiDetayIsleriGetir, DetaydanIliskiliIsleriGetir

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_IS_Asistan> DetaydanIliskiliIsleriGetir(
            TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> iliskiDetaylari, List<AvukatProLib.Arama.per_AV001_TDI_BIL_IS_Asistan> isler)
        {
            if (iliskiDetaylari != null)
            {
                foreach (var item in iliskiDetaylari)
                {
                    AV001_TDI_BIL_KAYIT_ILISKI rootKayit =
                        DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByID(item.KAYIT_ILISKI_ID);

                    if (rootKayit != null)
                    {
                        TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> detaylar =
                            DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByKAYIT_ILISKI_ID(rootKayit.ID);
                        KayitIliskiDetayIsleriGetir(detaylar, isler);
                    }
                }
            }
            return isler;
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_IS_Asistan> KayitIliskiDetayIsleriGetir(
            TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> iliskiDetaylari, List<AvukatProLib.Arama.per_AV001_TDI_BIL_IS_Asistan> isler)
        {
            if (iliskiDetaylari != null)
            {
                foreach (var item in iliskiDetaylari)
                {
                    List<AvukatProLib.Arama.per_AV001_TDI_BIL_IS_Asistan> iliskiliDosyaIs = null;

                    if (item.ILISKI_TUR_ID == (int)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.ÝCRA_DOSYASI)
                    {
                        iliskiliDosyaIs = BelgeUtil.Inits.context.per_AV001_TDI_BIL_IS_Asistans.Where(vi => BelgeUtil.Inits.context.NN_IS_ICRA_FOYs.Where(icra => icra.ICRA_FOY_ID == item.HEDEF_KAYIT_ID).Select(t => t.IS_ID).Contains(vi.ID) && vi.AJANDADA_GORUNSUN_MU && BelgeUtil.Inits.context.AV001_TDI_BIL_IS_TARAFs.Where(c => c.CARI_ID == AvukatProLib.Kimlik.Bilgi.CARI_ID && c.IS_TARAF_ID == 2).Select(s => s.IS_ID).Contains(vi.ID)).ToList();
                    }
                    else if (item.ILISKI_TUR_ID == (int)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.DAVA_DOSYASI)
                    {
                        iliskiliDosyaIs = BelgeUtil.Inits.context.per_AV001_TDI_BIL_IS_Asistans.Where(vi => BelgeUtil.Inits.context.NN_IS_DAVA_FOYs.Where(dava => dava.DAVA_FOY_ID == item.HEDEF_KAYIT_ID).Select(t => t.IS_ID).Contains(vi.ID) && vi.AJANDADA_GORUNSUN_MU && BelgeUtil.Inits.context.AV001_TDI_BIL_IS_TARAFs.Where(c => c.CARI_ID == AvukatProLib.Kimlik.Bilgi.CARI_ID && c.IS_TARAF_ID == 2).Select(s => s.IS_ID).Contains(vi.ID)).ToList();
                    }
                    else if (item.ILISKI_TUR_ID == (int)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.HAZIRLIK_DOSYASI)
                    {
                        iliskiliDosyaIs = BelgeUtil.Inits.context.per_AV001_TDI_BIL_IS_Asistans.Where(vi => BelgeUtil.Inits.context.NN_IS_HAZIRLIKs.Where(hazirlik => hazirlik.HAZIRLIK_ID == item.HEDEF_KAYIT_ID).Select(t => t.IS_ID).Contains(vi.ID) && vi.AJANDADA_GORUNSUN_MU && BelgeUtil.Inits.context.AV001_TDI_BIL_IS_TARAFs.Where(c => c.CARI_ID == AvukatProLib.Kimlik.Bilgi.CARI_ID && c.IS_TARAF_ID == 2).Select(s => s.IS_ID).Contains(vi.ID)).ToList();
                    }
                    else if (item.ILISKI_TUR_ID == (int)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.SOZLESME_DOSYASI)
                    {
                        iliskiliDosyaIs = BelgeUtil.Inits.context.per_AV001_TDI_BIL_IS_Asistans.Where(vi => BelgeUtil.Inits.context.NN_IS_SOZLESMEs.Where(sozlesme => sozlesme.SOZLESME_ID == item.HEDEF_KAYIT_ID).Select(t => t.IS_ID).Contains(vi.ID) && vi.AJANDADA_GORUNSUN_MU && BelgeUtil.Inits.context.AV001_TDI_BIL_IS_TARAFs.Where(c => c.CARI_ID == AvukatProLib.Kimlik.Bilgi.CARI_ID && c.IS_TARAF_ID == 2).Select(s => s.IS_ID).Contains(vi.ID)).ToList();
                    }
                    if (iliskiliDosyaIs != null)
                        foreach (var iliskiliIs in iliskiliDosyaIs)
                        {
                            if (!isler.Exists(vi => vi.ID == iliskiliIs.ID))
                                isler.Add(iliskiliIs);
                        }
                }
            }
            return isler;
        }

        #endregion <MB-20100427> KayitIliskiDetayIsleriGetir, DetaydanIliskiliIsleriGetir

        #region Properties // Okan

        private TList<AV001_TI_BIL_FOY_TARAF> _borcluTaraflar;
        private TList<AV001_TI_BIL_FOY_TARAF> alacakliTaraflar;
        private TList<AV001_TI_BIL_FOY_TARAF> mevcutAlacakliTaraflar;

        private TList<AV001_TI_BIL_FOY_TARAF> mevcutBorcluTaraflar;

        public TList<AV001_TI_BIL_FOY_TARAF> AlacakliTaraflar
        {
            get
            {
                if (icraTarafBilgileri == null)
                {
                    if (mevcutAlacakliTaraflar == null)
                    {
                        mevcutAlacakliTaraflar = ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy);
                    }
                    alacakliTaraflar = mevcutAlacakliTaraflar;
                }
                else alacakliTaraflar = icraTarafBilgileri.AlacakliTaraflar;
                return alacakliTaraflar;
            }
        }

        public TList<AV001_TI_BIL_FOY_TARAF> BorcluTaraflar
        {
            get
            {
                if (icraTarafBilgileri == null)
                {
                    if (mevcutBorcluTaraflar == null)
                    {
                        mevcutBorcluTaraflar = ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy);
                    }
                    _borcluTaraflar = mevcutBorcluTaraflar;
                }
                else _borcluTaraflar = icraTarafBilgileri.BorcluTaraflar;
                return _borcluTaraflar;
            }
        }

        #endregion Properties // Okan

        #region MenuMetodlari

        public static void SonHesapTarihiKontrolu(AV001_TI_BIL_FOY myFoy)
        {
            if (myFoy != null && myFoy.SON_HESAP_TARIHI != DateTime.Today)
            {
                var tercih =
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        string.Format("Hesaba Esas Tarih : {0}\nGünün Tarihi Ýle Deðiþtirilsin mi?",
                                      myFoy.SON_HESAP_TARIHI), "Hesaplama Parametresi", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (tercih == DialogResult.Yes)
                {
                    myFoy.SON_HESAP_TARIHI = DateTime.Today;
                }
            }
        }

        private void FoyAc()
        {
            GirisEkran.rFrmIcraGirisEkran frmIcraGiris = new AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran();
            frmIcraGiris.Show();
        }

        private void FoyIhtiyatiHacizBilgileri()
        {
            //ÝHTÝYATÝ HACÝZ BÝLGÝLERÝ
            if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 &&
                MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ýhtiyati Haciz girebilmek için taraflarýn ve sorumlu avukatlarýn eklenmiþ olmasý gerekmektedir",
                    "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmIcraIhtiyatiHaciz frm = new frmIcraIhtiyatiHaciz();
            MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection.AddingNew += AV001_TI_BIL_IHTIYATI_HACIZCollection_AddingNew;
            if (MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection == null)
                MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection = new TList<AV001_TI_BIL_IHTIYATI_HACIZ>();

            if (MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection.Count <= 0)
                MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection.AddNew();

            frm.MyFoy = MyFoy;
            frm.MyDataSource = MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection;

            //frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
        }

        private void FoyIhtiyatiTedbirBilgileri()
        {
            if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0
                && MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ýhtiyati Tedbir girebilmek için taraflarýn ve sorumlu avukatlarýn eklenmiþ olmasý gerekmektedir",
                    "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection == null)
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();
            MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.AddingNew += AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_AddingNew;
            if (MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.Count <= 0)
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.AddNew();
            frmDavaIcraIhtiyatiTedbir frm = new frmDavaIcraIhtiyatiTedbir();
            frm.MyFoy = MyFoy;
            frm.MyDataSource = MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;

            //frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
        }

        private void FoyIlamBilgileri()
        {
            //ÝLAM BÝLGÝLERÝ

            //Bu kontrole gerek olmadýðýndan kaldýrýldý. MB
            //if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 &&
            //    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
            //{
            //    XtraMessageBox.Show(
            //        "Ýlam Bilgisi girebilmek için taraflarýn ve sorumlu avukatlarýn eklenmiþ olmasý gerekmektedir",
            //        "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                             typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI>));
            if (MyFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection == null ||
                MyFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count <= 0)
            {
                MyFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection = new TList<AV001_TI_BIL_ILAM_MAHKEMESI>();
                MyFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection.AddingNew += AV001_TI_BIL_ILAM_MAHKEMESICollection_AddingNew;
                if (MyFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count <= 0)
                    MyFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection.AddNew();
            }
            frmIcraIlamMahkemesiGiris frm = new frmIcraIlamMahkemesiGiris();
            frm.MyDataSource = MyFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection;
            frm.Foy = MyFoy;

            //frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
        }

        private void FoyKaydet()
        {
            if (AlacakliTaraflar != null && AlacakliTaraflar.Count == 0) // Okan 18.06.2010
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Alacaklý Taraf Seçmelisiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (BorcluTaraflar != null && BorcluTaraflar.Count == 0) // Okan 18.06.2010
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Borçlu Taraf Seçmelisiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
            if (MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Sorumlu Avukat Seçmelisiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //Kayýttan önce hesap yapýlsýn mý kontrolünün yapýlmasý istenmediðinden kaldýrýldý. MB
            //Foyu ve Gorevleri Kaydet
            //DialogResult sonuc = XtraMessageBox.Show("Kaydetmeden Önce Hesap Yapýlsýn Mý?", "Dikkat!",
            //                                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            //bool kaydet = false;

            //switch (sonuc)
            //{
            //    case DialogResult.Cancel:
            //        break;
            //    case DialogResult.No:
            //        kaydet = true;
            //        break;
            //    case DialogResult.Yes:
            //        SonHesapTarihiKontrolu(MyFoy);
            //        Hesap.Icra hy = new Hesap.Icra(MyFoy);
            //        //if (ucIcraCore1 != null)
            //        //{
            //        //    if(ucIcraCore1.icraGridler==null)
            //        //        ucIcraCore1
            //        //    ucIcraCore1.icraGridler.ucIcraHesapCetveli1.MyTarafSource = MyFoy.AV001_TI_BIL_FOY_TARAFCollection;
            //        //}
            //        kaydet = true;
            //        break;
            //    default:
            //        break;
            //}

            //if (kaydet)
            //{

            if (this.ucIcraCore1 == null)
                CreateUcIcraCore();
            if (FoyKaydet(MyFoy) && (this.ucIcraCore1 != null))
            {
                if (this.ucIcraCore1.ucIcraGridlerTemp1 != null && ucIcraCore1.ucIcraGridlerTemp1.ucGorevler1 != null)
                    this.ucIcraCore1.ucIcraGridlerTemp1.ucGorevler1.SaveAll();
                AdimAdimDavaKaydi.Is.Util.IsPerformans.PerformansKaydet(MyFoy);

                DevExpress.XtraEditors.XtraMessageBox.Show("Kayýt iþlemi baþarýyla gerçekleþti.", "Kaydet",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("Sistem bir hatayla karþýlaþtý. Lütfen tekrar deneyiniz.", "Kaydet",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
        }

        private void FoyTakipOncesiOdemeler()
        {
            if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 &&
                MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Takip öncesi ödeme girebilmek için taraflarýn ve sorumlu avukatlarýn eklenmiþ olmasý gerekmektedir",
                    "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection == null)
                MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection = new TList<AV001_TI_BIL_BORCLU_ODEME>();

            frmIcraOdemeBilgileri frm = new frmIcraOdemeBilgileri();
            TList<AV001_TDI_BIL_CARI> taraflar = new TList<AV001_TDI_BIL_CARI>();
            foreach (AV001_TI_BIL_FOY_TARAF taraf in MyFoy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                if (taraf.CARI_IDSource != null)
                {
                    taraflar.Add(taraf.CARI_IDSource);
                }
                if (taraf.CARI_ID.HasValue)
                    taraflar.Add(DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(taraf.CARI_ID.Value));
            }
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show(MyFoy, taraflar);
        }

        private void FoyYeni()
        {
            AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit frm = new AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit();
            if (IcraDosyaKayitTiklandi != null)
                IcraDosyaKayitTiklandi(this, new FrmIcraDosyaKayitEventArgs(frm));
            frm.Show();
        }

        #endregion MenuMetodlari

        #region Veriables

        public TList<AV001_TI_BIL_FOY_TARAF> borcluTaraflar;
        private AV001_TDI_BIL_CARI cariEntity = new AV001_TDI_BIL_CARI();
        private TList<AV001_TI_BIL_FOY> foyList;

        #endregion Veriables

        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy { get; set; }

        #endregion Properties

        #region Load

        public void TBD()
        {
            this.icraTarafBilgileri.MyFoy = this.MyFoy;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            DateTime dt = DateTime.Now;
            Console.WriteLine("Load Start: " + dt);
            this.scAnaPanel.Visible = true;
            ucIcraBindingControl1.dataNavigator1.PositionChanged +=
                                            dataNavigator1_PositionChanged;
            bndIcraFoy_CurrentChanged(0, new EventArgs());
            bckWorker.DoWork += delegate
                                    {
                                        ucIcraBindingControl1.MyDataSource = foyList;
                                        ucIcraBindingControl1.dataNavigator1.PositionChanged +=
                                            dataNavigator1_PositionChanged;
                                        bndIcraFoy_CurrentChanged(0, new EventArgs());
                                    };

            LoadData();
            Console.WriteLine("Load Finish: " + DateTime.Now);
            Console.WriteLine("Load Time: " + DateTime.Now.Subtract(dt));
        }

        private void BindOzelKod()
        {
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod1, 1, AvukatProLib.Extras.Modul.Icra);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod2, 2, AvukatProLib.Extras.Modul.Icra);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod3, 3, AvukatProLib.Extras.Modul.Icra);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod4, 4, AvukatProLib.Extras.Modul.Icra);
        }

        private void CreateBindings()
        {
            this.txtEskiRafNo.DataBindings.Add(new Binding("EditValue", this.bndIcraFoy, "ESKI_RAF_NO", true));
            this.txtKlasor.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "ADI", true));
            this.txtKlasorKodu.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "KOD", true));
            this.lueSube.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "OZEL_KOD1_ID", true));

            this.txtIBANNo.DataBindings.Add(new Binding("EditValue", this.bndIcraFoy, "ALACAKLI_TARAF_STATU", true));

            //this.lueKalanDoviz.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "KALAN_DOVIZ_ID", true));
            //this.lueOdemelerDoviz.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "ODEME_TOPLAMI_DOVIZ_ID", true));
            //this.lueTakipCikisiDoviz.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "TAKIP_CIKISI_DOVIZ_ID", true));
            //this.lueAsilAlacakDoviz.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "ASIL_ALACAK_DOVIZ_ID", true));
            //this.spKalan.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "KALAN", true));
            //this.spOdemeler.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "ODEME_TOPLAMI", true));
            //this.spTakipCikisi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "TAKIP_CIKISI", true));
            //this.spAsilAlacak.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "ASIL_ALACAK", true));
            this.lueTakipKonusu.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "TAKIP_TALEP_ID", true));
            this.lueSegment.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "SEGMENT_ID", true));
            this.txtRef1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "REFERANS_NO", true));
            this.dtZmnAsm.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "ZAMANASIMI_ILE_INFAZ_TARIHI", true));
            this.txtRef2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "REFERANS_NO2", true));
            this.txtRef3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "REFERANS_NO3", true));
            this.dtKKKapamaT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "KURUL_KARARI_ILE_KAPAMA_TARIHI", true));
            this.dtTerkinTarihi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "ACIZ_TARIHI", true));
            this.txtEsasNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "ESAS_NO", true));
            this.dtAcizT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "ACIZ_TARIHI", true));
            this.dtSemeresizlikT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "SEMERESIZLIKLE_KAPAMA_TARIHI", true));
            this.dtTakipTarihi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "TAKIP_TARIHI", true));
            this.lkMuvekkileIadeNedeni.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "TAKIBIN_MUVEKKILE_IADE_NEDENI_ID", true));
            this.dtRaporT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "RAPOR_TARIHI", true));
            this.lueMudurluk.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "ADLI_BIRIM_ADLIYE_ID", true));
            this.lueFormTip.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "FORM_TIP_ID", true));
            this.dtSulhT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "SULH_TARIHI", true));
            this.dtMuvekkileIadeT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "TAKIBIN_MUVEKKILE_IADE_TARIHI", true));
            this.lueMudurlukNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "ADLI_BIRIM_NO_ID", true));
            this.lueTakibinDurumu.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "FOY_DURUM_ID", true));
            this.txtFoyKod.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "FOY_NO_Kod", true));
            this.txtFoyNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "FOY_NO_Sayi", true));
            this.dtAvukataInk.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "TAKIBIN_AVUKATA_INTIKAL_TARIHI", true));
            this.txtTedbirTarihi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "TEDBIR_TARIHI", true));
            this.dtArsivT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "FOY_ARSIV_TARIHI", true));
            this.dtInfazT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "FOY_INFAZ_TARIHI", true));
            this.dtFeragatT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "FOY_FERAGAT_TARIHI", true));
            this.txtAciklama.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bndIcraFoy, "ACIKLAMA", true));


            lciRefNo1.Text = Kimlikci.Kimlik.IcraReferans.Referans1;
            lciRefNo2.Text = Kimlikci.Kimlik.IcraReferans.Referans2;
            lciRefNo3.Text = Kimlikci.Kimlik.IcraReferans.Referans3;
            lciOzelKod1.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod1;
            lciOzelKod2.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod2;
            lciOzelKod3.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod3;
            lciOzelKod4.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod4;
        }

        private void frmOzelKod_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindOzelKod();
        }

        private void lueOzelKod1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == "ekle")
            {
                AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle frm = new AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frmOzelKod_FormClosed);
            }
        }

        #endregion Load

        #region Methods

        public event EventHandler<BelgeUtil.IcraFoyKaydedildiEventArgs> IcraFoyKaydedildi;

        public static TList<AV001_TI_BIL_FOY_TARAF> GetFoyBorcluTaraf(AV001_TI_BIL_FOY foy)
        {
            TList<AV001_TI_BIL_FOY_TARAF> borcluList = new TList<AV001_TI_BIL_FOY_TARAF>();

            foreach (AV001_TI_BIL_FOY_TARAF taraf in foy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                if (taraf.IsNew)
                {
                    if (taraf.TARAF_SIFAT_IDSource == null)
                        taraf.TARAF_SIFAT_IDSource =
                            DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(taraf.TARAF_SIFAT_ID);
                }
                else if (taraf.CARI_IDSource == null)
                {
                    DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(taraf, false, DeepLoadType.IncludeChildren,
                                                                           typeof(AV001_TDI_BIL_CARI),
                                                                           typeof(TDIE_KOD_TARAF_SIFAT));
                }
                if (taraf.CARI_ID.HasValue &&
                    taraf.TARAF_SIFAT_IDSource.HANGI_TARAF_NO == (int)AvukatProLib.Extras.IcraTarafKodu.TakipEdilen)
                    borcluList.Add(taraf);
            }
            return borcluList;
        }

        public bool FoyKaydet(AV001_TI_BIL_FOY foy)
        {
            TList<AV001_TDI_BIL_SOZLESME> sozlesmeTempList = new TList<AV001_TDI_BIL_SOZLESME>();
            try
            {
                #region Ödeme Planý

                AV001_TI_BIL_BORCLU_TAAHHUT_MASTER masterTaahhut =
                    foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection.Find(
                        AV001_TI_BIL_BORCLU_TAAHHUT_MASTERColumn.GECERLI_MI, true);

                AvukatProLib.Hesap.HesapYapar.TaahhutKontrol(foy, masterTaahhut);

                #endregion Ödeme Planý

                foy.Validate();
                if (!foy.IsValid)
                {
                    MessageBox.Show(foy.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(typeof(AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit), ex);
            }

            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                AdimAdimDavaKaydi.Util.AsamaHelper.AsamalaraModulAta(foy);
                foy.AV001_TDIE_BIL_ASAMACollection.Sort(new Comparison<AV001_TDIE_BIL_ASAMA>(AsamaKarsilastir));

                //if (foy.AV001_TDIE_BIL_ASAMACollection.Count > 0)
                //    foy.ASAMA_IDSource =
                //        foy.AV001_TDIE_BIL_ASAMACollection[foy.AV001_TDIE_BIL_ASAMACollection.Count - 1];

                #region <MB-20100628>

                //Veri girilen tarihlere göre icra durumunun belirlenmesini saðlamak için eklendi.

                icraTarihleri.Clear();
                if (MyFoy.FOY_ARSIV_TARIHI.HasValue)
                    icraTarihleri.Add(MyFoy.FOY_ARSIV_TARIHI.Value, (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.ArsivTarihi);
                if (MyFoy.ZAMANASIMI_ILE_INFAZ_TARIHI.HasValue)
                    icraTarihleri.Add(MyFoy.ZAMANASIMI_ILE_INFAZ_TARIHI.Value, (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.ZamanAsimiTarihi);
                if (MyFoy.TERKIN_TARIHI.HasValue)
                    icraTarihleri.Add(MyFoy.TERKIN_TARIHI.Value, (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.TerkinTarihi);
                if (MyFoy.SEMERESIZLIKLE_KAPAMA_TARIHI.HasValue)
                    icraTarihleri.Add(MyFoy.SEMERESIZLIKLE_KAPAMA_TARIHI.Value, (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.SemereTarihi);
                if (MyFoy.TAKIBIN_MUVEKKILE_IADE_TARIHI.HasValue)
                    icraTarihleri.Add(MyFoy.TAKIBIN_MUVEKKILE_IADE_TARIHI.Value, (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.IadeTarihi);
                if (MyFoy.FOY_FERAGAT_TARIHI.HasValue)
                    icraTarihleri.Add(MyFoy.FOY_FERAGAT_TARIHI.Value, (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.FeragatTarihi);
                if (MyFoy.SULH_TARIHI.HasValue)
                    icraTarihleri.Add(MyFoy.SULH_TARIHI.Value, (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.SulhTarihi);
                if (MyFoy.KURUL_KARARI_ILE_KAPAMA_TARIHI.HasValue)
                    icraTarihleri.Add(MyFoy.KURUL_KARARI_ILE_KAPAMA_TARIHI.Value, (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.KKKTarihi);
                if (MyFoy.FOY_INFAZ_TARIHI.HasValue)
                    icraTarihleri.Add(MyFoy.FOY_INFAZ_TARIHI.Value, (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.InfazTarihi);
                if (MyFoy.ACIZ_TARIHI.HasValue)
                    icraTarihleri.Add(MyFoy.ACIZ_TARIHI.Value, (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.AcizTarihi);

                switch (icraTarihleri.OrderByDescending(vi => vi.Key).FirstOrDefault().Value)
                {
                    case (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.ArsivTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.ARÞÝV;
                        break;

                    case (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.ZamanAsimiTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.ÝNFAZ_ZAMAN_AÞIMI;
                        break;

                    case (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.TerkinTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.TAKIPSIZ;
                        break;

                    case (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.SemereTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.SEMERESÝZ;
                        break;

                    case (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.IadeTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.ÝADE;
                        break;

                    case (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.FeragatTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.FERAGAT;
                        break;

                    case (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.SulhTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.SULH;
                        break;

                    case (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.KKKTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.KKK;
                        break;

                    case (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.InfazTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.ÝNFAZ;
                        break;

                    case (int)AdimAdimDavaKaydi.DavaTakip.Tarihler.AcizTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.ACÝZ;
                        break;
                    default:
                        break;
                }

                #endregion <MB-20100628>
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
            try
            {
                foreach (AV001_TI_BIL_SATIS_MASTER sm in foy.AV001_TI_BIL_SATIS_MASTERCollection)
                {
                    foreach (AV001_TI_BIL_SATIS_CHILD sChild in sm.AV001_TI_BIL_SATIS_CHILDCollection)
                    {
                        if (sChild.HACIZ_CHILD_IDSource != null && !sChild.HACIZ_CHILD_IDSource.IsNew)
                        {
                            sChild.HACIZ_CHILD_ID = sChild.HACIZ_CHILD_IDSource.ID;
                        }
                        if (sChild.HACIZ_CHILD_ID == 0 && sChild.HACIZ_CHILD_IDSource == null)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(
                                "Satýþ kalemlerinden  bir yada bir kaçýnda Haciz Kalemi seçilmemiþtir. Lütfen kontrol ederek tekrar kayýt yapmayý deneyiniz.",
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                //Dosyada en az bir tane sorumlu olmasý gerektiðinden, tek avukat olan dosyalarda kullanýcý izleyen mi alanýný iþaretlediðinde bu alanýn false olmasý saðlanýyor. MB
                if (foy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 1 && foy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.FindAll(vi => !vi.YETKILI_MI).Count == 0)
                    foy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[0].YETKILI_MI = false;

                foy.SUBE_KOD_ID = AdimAdimDavaKaydi.Forms.frmKlasorYeni.KullaniciSubeIDGetir(foy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Find(vi => !vi.YETKILI_MI).SORUMLU_AVUKAT_CARI_ID.Value);

                trans.BeginTransaction();

                #region <CC-20090622>

                #region <GKN-20090615>

                if (AlacakliTaraflar != null)
                {
                    foreach (var taraf in AlacakliTaraflar)
                    {
                        if (taraf.IsNew)
                        {
                            foy.AV001_TI_BIL_FOY_TARAFCollection.Add(taraf);
                            if (taraf.CARI_IDSource == null)
                            {
                                if (taraf.CARI_ID.HasValue)
                                    taraf.CARI_IDSource =
                                        DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(taraf.CARI_ID.Value);
                            }
                        }

                        #region <MB-20100514> Alacaklý Taraf Vekili Kayýt

                        foreach (var trfVekil in taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection)
                        {
                            if (trfVekil.FOY_TARAF_ID <= 0 && trfVekil.FOY_TARAF_CARI_ID <= 0 ||
                                trfVekil.FOY_TARAF_ID == null)
                            {
                                trfVekil.FOY_TARAF_CARI_ID = taraf.CARI_ID;
                                trfVekil.FOY_TARAF_ID = taraf.ID;
                            }
                        }
                        DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.Save(trans,
                                                                                 taraf.
                                                                                     AV001_TI_BIL_FOY_TARAF_VEKILCollection);

                        #endregion <MB-20100514> Alacaklý Taraf Vekili Kayýt
                    }
                }
                if (BorcluTaraflar != null)
                {
                    foreach (var taraf in BorcluTaraflar)
                    {
                        if (AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme == null)
                            AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.GelismeBul(foy);

                        if (taraf.IsNew)
                        {
                            foy.AV001_TI_BIL_FOY_TARAFCollection.Add(taraf);
                            if (taraf.CARI_IDSource == null)
                            {
                                if (taraf.CARI_ID.HasValue)
                                    taraf.CARI_IDSource =
                                        DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(taraf.CARI_ID.Value);
                            }

                            if (taraf.TARAF_SIFAT_IDSource == null)
                                taraf.TARAF_SIFAT_IDSource =
                                    DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(taraf.TARAF_SIFAT_ID);
                        }

                        #region <MB-20100104> Karþý Taraf Vekili Kayýt

                        foreach (var trfVekil in taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection)
                        {
                            if (trfVekil.FOY_TARAF_ID <= 0 && trfVekil.FOY_TARAF_CARI_ID <= 0 ||
                                trfVekil.FOY_TARAF_ID == null)
                            {
                                trfVekil.FOY_TARAF_CARI_ID = taraf.CARI_ID;
                                trfVekil.FOY_TARAF_ID = taraf.ID;
                            }
                        }
                        DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.Save(trans,
                                                                                 taraf.
                                                                                     AV001_TI_BIL_FOY_TARAF_VEKILCollection);

                        #endregion <MB-20100104> Karþý Taraf Vekili Kayýt
                    }
                }

                foreach (var item in foy.AV001_TI_BIL_FOY_TARAFCollection)
                {
                    DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepSave(trans, item);

                    if (item.CARI_IDSource == null && item.CARI_ID.HasValue)
                        item.CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.CARI_ID.Value);
                    DataRepository.AV001_TDI_BIL_CARIProvider.DeepSave(trans, item.CARI_IDSource, DeepSaveType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                }

                //ucIcraTarafGelismeleri.GelismleriKaydet(trans, ucIcraTarafGelismeleri.myGelisme, foy, false); Enver 12.10.2010

                #endregion <GKN-20090615>

                #endregion <CC-20090622>

                DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(trans, foy);
                DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(trans, foy, DeepSaveType.IncludeChildren, typeof(TList<NN_ICRA_POLICE>), typeof(TList<AV001_TDI_BIL_POLICE>), typeof(TList<AV001_TDI_BIL_POLICE_HASAR>), typeof(TList<AV001_TI_BIL_FOY_OZEL_KOD>), typeof(TList<AV001_TDI_BIL_CARI>), typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>), typeof(TList<AV001_TI_BIL_FOY_TARAF>), typeof(TList<AV001_TDI_BIL_TEBLIGAT>));

                foreach (AV001_TI_BIL_FOY_TARAF kimlik in MyFoy.AV001_TI_BIL_FOY_TARAFCollection)
                {
                    if (kimlik.CARI_IDSource != null)
                    {
                        DataRepository.AV001_TDI_BIL_CARIProvider.DeepSave(trans, kimlik.CARI_IDSource, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                    }
                }

                foreach (AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorm in MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                {
                    if (sorm.SORUMLU_AVUKAT_CARI_IDSource != null)
                        DataRepository.AV001_TDI_BIL_CARIProvider.DeepSave(trans, sorm.SORUMLU_AVUKAT_CARI_IDSource, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                }

                //TODO:Burasý kontrol edilecek.
                DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(trans, foy, DeepSaveType.ExcludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>), typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI>));
                DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(trans, foy, DeepSaveType.IncludeChildren, typeof(TList<TDI_BIL_BORCLU_MAL>));

                //}
                //Sorumlu Avukatlar
                foreach (AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumluAv in foy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                {
                    if (sorumluAv.SORUMLU_AVUKAT_CARI_IDSource != null)
                        sorumluAv.SORUMLU_AVUKAT_CARI_ID = sorumluAv.SORUMLU_AVUKAT_CARI_IDSource.ID;
                }

                DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.DeepSave(trans,
                                                                                foy.
                                                                                    AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection);

                DataRepository.AV001_TDIE_BIL_MUVEKKIL_TALIMATProvider.DeepSave(
                    foy.AV001_TDIE_BIL_MUVEKKIL_TALIMATCollection);

                //Foy Taraf

                DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepSave(trans, foy.AV001_TI_BIL_FOY_TARAFCollection,
                                                                       DeepSaveType.IncludeChildren,
                                                                       typeof(TList<AV001_TDI_BIL_GORUSME>));

                DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(trans, foy, DeepSaveType.IncludeChildren,
                                                                 typeof(TList<AV001_TDI_BIL_GORUSME>),
                                                                 typeof(TList<AV001_TI_BIL_FOY_TARAF>));

                //Odeme Dagilim
                foreach (AV001_TI_BIL_ODEME_DAGILIM dagilim in foy.AV001_TI_BIL_ODEME_DAGILIMCollection)
                {
                    if (dagilim.FOY_ID < 1)
                    {
                        dagilim.FOY_ID = foy.ID;
                    }
                }

                //Masraf Avans Aykut
                foreach (AV001_TDI_BIL_MASRAF_AVANS item in foy.AV001_TDI_BIL_MASRAF_AVANSCollection)
                {
                    if (item.ICRA_FOY_ID == null || item.ICRA_FOY_ID == 0)
                        item.ICRA_FOY_ID = foy.ID;
                }
                DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepSave(trans,
                                                                           foy.AV001_TDI_BIL_MASRAF_AVANSCollection);
                foreach (AV001_TDI_BIL_MASRAF_AVANS item in foy.AV001_TDI_BIL_MASRAF_AVANSCollection)
                {
                    foreach (var detay in item.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                    {
                        if (detay.MASRAF_AVANS_ID == 0)
                            detay.MASRAF_AVANS_ID = item.ID;
                    }
                }
                DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepSave(trans,
                                                                           foy.AV001_TDI_BIL_MASRAF_AVANSCollection,
                                                                           DeepSaveType.IncludeChildren,
                                                                           typeof(
                                                                               TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));

                //Tebligat
                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(trans, foy.AV001_TDI_BIL_TEBLIGATCollection);

                foreach (AV001_TI_BIL_ALACAK_NEDEN neden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepSave(trans,
                                                                                    neden.
                                                                                        AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection);
                    DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepSave(trans, foy.AV001_TI_BIL_FOY_TARAFCollection);
                    neden.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARAC.
                        ForEach(
                            delegate(AV001_TDI_BIL_GEMI_UCAK_ARAC obj)
                            {
                                if (
                                    neden.AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARACCollection.FindAll(
                                        AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARACColumn.GEMI_UCAK_ARAC_ID, obj.ID).
                                        Count == 0)
                                {
                                    AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARAC gua =
                                        neden.AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARACCollection.AddNew();
                                    gua.GEMI_UCAK_ARAC_IDSource = obj;
                                }
                            });

                    neden.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL.ForEach(
                        delegate(AV001_TI_BIL_GAYRIMENKUL obj)
                        {
                            if (
                                neden.AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKULCollection.FindAll(
                                    AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKULColumn.GAYRIMENKUL_ID, obj.ID).Count ==
                                0)
                            {
                                AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL gm =
                                    neden.AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKULCollection.AddNew();

                                gm.GAYRIMENKUL_IDSource = obj;
                            }
                        }
                        );

                    neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.ForEach(
                        delegate(AV001_TDI_BIL_SOZLESME obj)
                        {
                            if (
                                neden.AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWCollection.FindAll(
                                    AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWColumn.SOZLESME_ID, obj.ID).Count == 0)
                            {
                                AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW sn =
                                    neden.AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWCollection.AddNew();
                                sn.SOZLESME_IDSource = obj;
                            }
                        }
                        );

                    DataRepository.AV001_TDI_BIL_POLICEProvider.DeepSave(trans,
                                                                         neden.
                                                                             AV001_TDI_BIL_POLICECollection_From_NN_POLICE_ALACAK_NEDEN);
                    neden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK.
                        ForEach(
                            delegate(AV001_TDI_BIL_KIYMETLI_EVRAK obj)
                            {
                                if (
                                    neden.AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAKCollection.FindAll(
                                        AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAKColumn.KIYMETLI_EVRAK_ID, obj.ID).
                                        Count ==
                                    0)
                                {
                                    AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK ke =
                                        neden.AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAKCollection.AddNew();

                                    ke.KIYMETLI_EVRAK_IDSource = obj;
                                }
                            }
                        );
                    neden.AV001_TDI_BIL_POLICECollection_From_NN_POLICE_ALACAK_NEDEN.ForEach(
                        delegate(AV001_TDI_BIL_POLICE obj)
                        {
                            if (
                                neden.NN_POLICE_ALACAK_NEDENCollection.FindAll(
                                    NN_POLICE_ALACAK_NEDENColumn.POLICE_ID, obj.ID).Count == 0)
                            {
                                NN_POLICE_ALACAK_NEDEN pol = neden.NN_POLICE_ALACAK_NEDENCollection.AddNew();
                                pol.POLICE_IDSource = obj;
                            }
                        });
                }
                foreach (AV001_TDI_BIL_POLICE police in MyFoy.AV001_TDI_BIL_POLICECollection_From_NN_ICRA_POLICE)
                {
                    if (
                        foy.NN_ICRA_POLICECollection.Exists(
                            delegate(NN_ICRA_POLICE pol) { return pol.POLICE_ID == police.ID; })) continue;
                    NN_ICRA_POLICE poli = foy.NN_ICRA_POLICECollection.AddNew();
                    poli.POLICE_IDSource = police;
                    poli.ICRA_FOY_ID = foy.ID;
                    DataRepository.NN_ICRA_POLICEProvider.DeepSave(trans, poli);

                    //}
                }
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(trans, foy.AV001_TI_BIL_ALACAK_NEDENCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>), typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>), typeof(TList<AV001_TDI_BIL_SOZLESME>), typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>), typeof(TList<AV001_TI_BIL_FAIZ>), typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW>), typeof(TList<NN_POLICE_ALACAK_NEDEN>)
                    );

                //Odeme Dagilim
                DataRepository.AV001_TI_BIL_ODEME_DAGILIMProvider.Save(trans, foy.AV001_TI_BIL_ODEME_DAGILIMCollection);

                //BorcluOdeme
                DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepSave(trans, foy.AV001_TI_BIL_BORCLU_ODEMECollection);
                foreach (var item in foy.AV001_TI_BIL_BORCLU_ODEMECollection)
                {
                    DataRepository.AV001_TI_BIL_ODEME_DAGILIMProvider.DeepSave(trans,
                                                                               item.AV001_TI_BIL_ODEME_DAGILIMCollection);
                }

                //SatisMaster_SatisChild
                DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.DeepSave(trans, foy.AV001_TI_BIL_SATIS_MASTERCollection,
                                                                          DeepSaveType.IncludeChildren,
                                                                          typeof(TList<AV001_TI_BIL_SATIS_CHILD>));

                //HacizMaster_HacizChild
                DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepSave(trans, foy.AV001_TI_BIL_HACIZ_MASTERCollection,
                                                                          DeepSaveType.IncludeChildren,
                                                                          typeof(TList<AV001_TI_BIL_HACIZ_CHILD>));

                //---HacizIstirak - HacizIstihkak -- Kýymet Takdiri---//
                foreach (AV001_TI_BIL_HACIZ_MASTER master in foy.AV001_TI_BIL_HACIZ_MASTERCollection)
                {
                    foreach (AV001_TI_BIL_HACIZ_CHILD child in master.AV001_TI_BIL_HACIZ_CHILDCollection)
                    {
                        DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepSave(trans, child, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_HACIZ_ISTIRAK>), typeof(TList<AV001_TI_BIL_ISTIHKAK>), typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>));
                    }
                }

                //Feragat
                DataRepository.AV001_TI_BIL_FERAGATProvider.DeepSave(trans, foy.AV001_TI_BIL_FERAGATCollection);

                //BorcluTaahhut
                DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepSave(trans, foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection);

                //MalBeyani
                DataRepository.AV001_TI_BIL_MAL_BEYANIProvider.DeepSave(trans, foy.AV001_TI_BIL_MAL_BEYANICollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_MAL_BEYAN_DETAY>));

                //ItirazAlacakNeden
                DataRepository.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENProvider.DeepSave(trans, foy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection);

                //Asama_AsamaTaraf_AsamaSorumlu
                DataRepository.AV001_TDIE_BIL_ASAMAProvider.DeepSave(trans, foy.AV001_TDIE_BIL_ASAMACollection);


                //DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(trans, foy.AV001_TI_BIL_ALACAK_NEDENCollection);


                //tebligatlarýn esas no düzenlemeleri

                var tebligats = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByICRA_FOY_ID(MyFoy.ID);

                foreach (var item in tebligats)
                {
                    item.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                    item.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
                    item.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                    item.TEBLIGAT_ESAS_NO = MyFoy.ESAS_NO;
                }
                //Tebligat
                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(trans, tebligats);

                //---------------------------------//
                try
                {
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    if (trans.IsOpen)
                        trans.Rollback();

                    BelgeUtil.ErrorHandler.Catch(typeof(AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit), ex, true); //False Olucak..
                    return false;
                }

                #region <CC-20090808>

                if (MyProje != null)
                {
                    if (MyProje.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLICollection.Count == 0)
                        DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(
                                                                                 TList
                                                                                 <
                                                                                 AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI
                                                                                 >));
                    if (MyProje.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLICollection.Count == 0)
                        DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(
                                                                                 TList
                                                                                 <
                                                                                 AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI
                                                                                 >));
                    if (MyProje.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLICollection.Count == 0)
                        DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(
                                                                                 TList
                                                                                 <
                                                                                 AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI
                                                                                 >));
                    if (MyProje.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLICollection.Count == 0)
                        DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(
                                                                                 TList
                                                                                 <
                                                                                 AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI
                                                                                 >));

                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                    if (MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection.Count == 0)
                        DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TDIE_BIL_PROJE_TARAF>));

                    trans.BeginTransaction();

                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        if (
                            MyProje.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLICollection.Exists(
                                delegate(AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI alacakNeden) { return alacakNeden.ALACAK_NEDEN_ID == neden.ID; })) continue;

                        AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI takipli =
                            new AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI();

                        takipli.ALACAK_NEDEN_ID = neden.ID;
                        takipli.PROJE_ID = MyProje.ID;
                        DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLIProvider.DeepSave(trans, takipli);
                        MyProje.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLICollection.Add(takipli);
                    }

                    foreach (AV001_TDI_BIL_IHTIYATI_TEDBIR tedbir in foy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection)
                    {
                        if (
                            MyProje.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLICollection.Exists(
                                delegate(AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI ihtiyatiTedbir) { return ihtiyatiTedbir.IHTIYATI_TEDBIR_ID == tedbir.ID; })) continue;
                        AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI ptedbir =
                            new AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI();
                        ptedbir.PROJE_ID = MyProje.ID;
                        ptedbir.IHTIYATI_TEDBIR_ID = tedbir.ID;
                        DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLIProvider.DeepSave(trans, ptedbir);
                    }

                    foreach (AV001_TI_BIL_IHTIYATI_HACIZ bhaciz in foy.AV001_TI_BIL_IHTIYATI_HACIZCollection)
                    {
                        if (
                            MyProje.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLICollection.Exists(
                                delegate(AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI ihtiyatiHaciz) { return ihtiyatiHaciz.IHTIYATI_HACIZ_ID == bhaciz.ID; })) continue;
                        AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI haciz =
                            new AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI();
                        haciz.IHTIYATI_HACIZ_ID = bhaciz.ID;
                        haciz.PROJE_ID = MyProje.ID;
                        DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLIProvider.DeepSave(trans, haciz);
                    }

                    foreach (
                        AV001_TDI_BIL_KIYMETLI_EVRAK kiymetli in
                            foy.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_ICRA_KIYMETLI_EVRAK)
                    {
                        if (
                            MyProje.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLICollection.Exists(
                                delegate(AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI kiymetliEvrak) { return kiymetliEvrak.KIYMETLI_EVRAK_ID == kiymetli.ID; })) continue;
                        AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI prokiymetli =
                            new AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI();
                        prokiymetli.KIYMETLI_EVRAK_ID = kiymetli.ID;
                        prokiymetli.PROJE_ID = MyProje.ID;
                        DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLIProvider.DeepSave(trans, prokiymetli);
                    }

                    foreach (
                        AV001_TDI_BIL_SOZLESME sozlesme in foy.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME)
                    {
                        if (
                            MyProje.AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLICollection.Exists(
                                delegate(AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLI sozsls) { return sozsls.SOZLESME_ID == sozlesme.ID; })) continue;

                        AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLI proSoz = new AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLI();

                        proSoz.SOZLESME_ID = sozlesme.ID;
                        proSoz.PROJE_ID = MyProje.ID;
                        DataRepository.AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLIProvider.DeepSave(trans, proSoz);
                    }

                    foreach (AV001_TI_BIL_FOY_TARAF trf in foy.AV001_TI_BIL_FOY_TARAFCollection)
                    {
                        if (MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection.Exists(delegate(AV001_TDIE_BIL_PROJE_TARAF tarf)
                        {
                            return tarf.CARI_ID == trf.CARI_ID;
                        })) continue;

                        AV001_TDIE_BIL_PROJE_TARAF taraf = new AV001_TDIE_BIL_PROJE_TARAF();
                        taraf.CARI_ID = trf.CARI_ID.Value;
                        taraf.PROJE_ID = MyProje.ID;
                        DataRepository.AV001_TDIE_BIL_PROJE_TARAFProvider.DeepSave(trans, taraf);
                        MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection.Add(taraf);
                    }
                }

                #endregion <CC-20090808>

                #region Takip Aþamalarý Kaydediliyor

                //TakipAsamasiDoldur(foy);

                #endregion Takip Aþamalarý Kaydediliyor

                if (trans.IsOpen)
                    trans.Commit();

                if (foy.AV001_TI_BIL_FOY_TARAFCollection != null)
                    foreach (var item in foy.AV001_TI_BIL_FOY_TARAFCollection)
                    {
                        if (item.TAKIP_EDEN_MI && item.TARAF_KODU == (int)AvukatProLib.Extras.TarafKodu.Muvekkil)
                            AvukatProLib.Hesap.MuhasebeAraclari.SetCariHesapByFoy(foy);
                    }

                if (IcraFoyKaydedildi != null)
                    IcraFoyKaydedildi(this, new BelgeUtil.IcraFoyKaydedildiEventArgs(foy));

                #region Asama Refresh

                if (ucIcraCore1 != null && ucIcraCore1.ucIcraGridlerTemp1 != null &&
                    ucIcraCore1.ucIcraGridlerTemp1.gcTakipAsama != null)
                    ucIcraCore1.ucIcraGridlerTemp1.gcTakipAsama.RefreshAsama();

                #endregion Asama Refresh


                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                cn.AddParams("@KAZANMA_ORANI", spinKazanmaOrani.EditValue);
                cn.AddParams("@BEKLENEN_BITIS_TARIHI", dateBeklenenBitisTarihi.EditValue);
                cn.AddParams("@ID", MyFoy.ID);
                try
                {
                    cn.ExcuteQuery("UPDATE DBO.AV001_TI_BIL_FOY set KAZANMA_ORANI=@KAZANMA_ORANI, BEKLENEN_BITIS_TARIHI=@BEKLENEN_BITIS_TARIHI where ID=@ID");
                }
                catch { ;}

                return true;
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(typeof(frmIcraDosyaKayit), ex, true); //False Olucak..
                return false;
            }
        }

        public void Show(TList<AV001_TI_BIL_FOY> foys) // Okan 06.08.2010
        {
            //if (foys.Count > 0)
            //{
            //    TList<AV001_TDIE_BIL_PROJE> proje =
            //        DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByICRA_FOY_IDFromAV001_TDIE_BIL_PROJE_ICRA_FOY(
            //            foys[0].ID);
            //    if (proje.Count > 0)
            //        MyProje = proje[0];
            //}
            this.MyFoy = foys[0];
            ucIcraBindingControl1.MyDataSource = foys;
            bndIcraFoy.DataSource = foys;
            foyList = foys;

            #region <MB-20100525>

            //Dosyanýn Klasör Bilgilerinin gelmesi saðlandý.

            //if (MyProje == null)
            //{
            //    sccGenelBilgiler.Panel2.Controls.Remove(gcGrupKlasor);
            //    grbAciklama.Dock = DockStyle.Fill;
            //}
            //else if (MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection != null)
            //{
            //    if (MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Count == 0)
            //        DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren,
            //                                                             typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>));
            //    bndProje.DataSource = MyProje;
            //}
            if (MyProje != null)
            {
                if (MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>));
                bndProje.DataSource = MyProje;
            }
            #endregion <MB-20100525>
            sbtnKlasorEkraninaGonder.Visible = false;
            ucSablonEditoreGonder1.Foys = new TList<AV001_TI_BIL_FOY>();
            ucSablonEditoreGonder1.Foys.Add(MyFoy);
            ucSablonEditoreGonder1.ModuleGoreDoldur(1);
            this.Show();
        }

        public void Show(int foyId)
        {
            MyFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(foyId);
            TList<AV001_TDIE_BIL_PROJE> proje =
                DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByICRA_FOY_IDFromAV001_TDIE_BIL_PROJE_ICRA_FOY(foyId);
            if (proje.Count > 0)
                MyProje = proje[0];
            if (MyProje != null)
            {
                if (MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>));
                bndProje.DataSource = MyProje;
            }
            if (MyFoy == null)
            {
                MessageBox.Show("Açýlmak istenilen Ýcra dosyasý bulunamadý.");
                return;
            }
            TList<AV001_TI_BIL_FOY> liste = new TList<AV001_TI_BIL_FOY>();
            liste.Add(MyFoy);
            this.Show(liste);
        }

        private int AsamaKarsilastir(AV001_TDIE_BIL_ASAMA x, AV001_TDIE_BIL_ASAMA y)
        {
            if (x.ASAMA_ALT_KOD_IDSource == null)
                x.ASAMA_ALT_KOD_IDSource = DataRepository.TDIE_KOD_ASAMA_ALTProvider.GetByID(x.ASAMA_ALT_KOD_ID.Value);
            if (x.ASAMA_KOD_IDSource == null)
                x.ASAMA_KOD_IDSource = DataRepository.TDIE_KOD_ASAMAProvider.GetByID(x.ASAMA_KOD_ID);
            if (y.ASAMA_ALT_KOD_IDSource == null)
                y.ASAMA_ALT_KOD_IDSource = DataRepository.TDIE_KOD_ASAMA_ALTProvider.GetByID(y.ASAMA_ALT_KOD_ID.Value);
            if (y.ASAMA_KOD_IDSource == null)
                y.ASAMA_KOD_IDSource = DataRepository.TDIE_KOD_ASAMAProvider.GetByID(y.ASAMA_KOD_ID);
            int fark = x.ASAMA_KOD_IDSource.SIRA_NO - y.ASAMA_KOD_IDSource.SIRA_NO;
            if (fark == 0)
            {
                int altFark = x.ASAMA_ALT_KOD_IDSource.SIRA_NO - y.ASAMA_ALT_KOD_IDSource.SIRA_NO;
                return altFark;
            }
            return fark;
        }

        private void DataChange(AV001_TI_BIL_FOY foy)
        {
            //FoyDeepLoad(foy);
            txtFoyKod.DataBindings.Clear();
            txtFoyKod.DataBindings.Add("TEXT", foy, "FOY_NO_Kod", true);

            lueMudurlukNo.DataBindings.Clear();
            lueMudurlukNo.DataBindings.Add("EditValue", foy, "ADLI_BIRIM_NO_ID", true);

            txtFoyNo.DataBindings.Clear();
            txtFoyNo.DataBindings.Add("TEXT", foy, "FOY_NO_Sayi", true);

            lueMudurluk.DataBindings.Clear();
            lueMudurluk.DataBindings.Add("EditValue", foy, "ADLI_BIRIM_ADLIYE_ID", true);
            lueMudurluk.Refresh();

            txtEsasNo.DataBindings.Clear();
            txtEsasNo.DataBindings.Add("TEXT", foy, "ESAS_NO", true);

            dtTakipTarihi.DataBindings.Clear();
            dtTakipTarihi.DataBindings.Add("EditValue", foy, "TAKIP_TARIHI", true);

            lueTakibinDurumu.DataBindings.Clear();
            lueTakibinDurumu.DataBindings.Add("EditValue", foy, "FOY_DURUM_ID", true);

            dtAvukataInk.DataBindings.Clear();
            dtAvukataInk.DataBindings.Add("EditValue", foy, "TAKIBIN_AVUKATA_INTIKAL_TARIHI", true);

            txtTedbirTarihi.DataBindings.Clear();
            txtTedbirTarihi.DataBindings.Add("EditValue", foy, "TEDBIR_TARIHI", true);

            dtFeragatT.DataBindings.Clear();
            dtFeragatT.DataBindings.Add("EditValue", foy, "FOY_FERAGAT_TARIHI", true);

            dtSulhT.DataBindings.Clear();
            dtSulhT.DataBindings.Add("EditValue", foy, "SULH_TARIHI", true);

            dtInfazT.DataBindings.Clear();
            dtInfazT.DataBindings.Add("EditValue", foy, "FOY_INFAZ_TARIHI", true);

            dtArsivT.DataBindings.Clear();
            dtArsivT.DataBindings.Add("EditValue", foy, "FOY_ARSIV_TARIHI", true);

            dtMuvekkileIadeT.DataBindings.Clear();
            dtMuvekkileIadeT.DataBindings.Add("EditValue", foy, "TAKIBIN_MUVEKKILE_IADE_TARIHI", true);

            dtRaporT.DataBindings.Clear();
            dtRaporT.DataBindings.Add("EditValue", foy, "RAPOR_TARIHI", true);

            dtAcizT.DataBindings.Clear();
            dtAcizT.DataBindings.Add("EditValue", foy, "ACIZ_TARIHI", true);

            lkMuvekkileIadeNedeni.DataBindings.Clear();
            lkMuvekkileIadeNedeni.DataBindings.Add("EditValue", foy, "TAKIBIN_MUVEKKILE_IADE_NEDENI_ID", true);

            txtAciklama.DataBindings.Clear();
            txtAciklama.DataBindings.Add("TEXT", foy, "ACIKLAMA", true);

            #region ÝhtiyatiHaciz_ÝhtiyatiTedbir Kontrolü Yapýlýyor

            if (MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection.Count > 0)
            {
                if (!MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].K_H_CEVIRME_TARIHI.HasValue)
                {
                    MyFoy.TAKIP_TARIHI = null;
                    dtTakipTarihi.Properties.NullText = "ÝHTÝYATÝ HACÝZLÝDÝR";
                    dtTakipTarihi.BackColor = System.Drawing.Color.Red;
                    dtTakipTarihi.ForeColor = System.Drawing.Color.White;
                    dtTakipTarihi.Properties.Buttons[0].Visible = false;
                }
            }

            if (MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.Count > 0)
            {
                if (!MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection[0].K_D_CEVIRME_TARIHI.HasValue)
                {
                    MyFoy.TAKIP_TARIHI = null;
                    dtTakipTarihi.Properties.NullText = "ÝHTÝYATÝ TEDBÝRLÝDÝR";
                    dtTakipTarihi.BackColor = System.Drawing.Color.Red;
                    dtTakipTarihi.ForeColor = System.Drawing.Color.White;
                    dtTakipTarihi.Properties.Buttons[0].Visible = false;
                }
            }

            else
            {
                dtTakipTarihi.BackColor = System.Drawing.Color.White;
                dtTakipTarihi.ForeColor = System.Drawing.Color.Black;
                dtTakipTarihi.Properties.Buttons[0].Visible = true;
            }

            #endregion ÝhtiyatiHaciz_ÝhtiyatiTedbir Kontrolü Yapýlýyor

            DefaultValueEvents();

            ////Dosya Aþamalarýný Doldur.
            //TakipAsamasiDoldur(this.MyFoy); Enver 25.11.2010 - Kenan Bey'in isteðiyle kapatýldý

            //Ýcra Dosyasýný Degistir.
            bndIcraFoy.DataSource = this.MyFoy;

            //Gridlerdeki Kayýtlarý Degistir.
            ucIcraCore1.MyFoy = this.MyFoy;
            foy.ColumnChanged += foy_ColumnChanged;
        }

        private void foy_ColumnChanged(object sender, AV001_TI_BIL_FOYEventArgs e)
        {
            AV001_TI_BIL_FOY gonderen = sender as AV001_TI_BIL_FOY;
            if (e.Column == AV001_TI_BIL_FOYColumn.OZEL_TUTAR1_FAIZ_TIP_ID)
            {
                gonderen.OZEL_TUTAR1_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value,
                                                                            gonderen.OZEL_TUTAR1_DOVIZ_ID,
                                                                            gonderen.OZEL_TUTAR1_FAIZ_BASLANGIC_TARIHI);
            }

            if (e.Column == AV001_TI_BIL_FOYColumn.OZEL_TUTAR2_FAIZ_TIP_ID)
            {
                gonderen.OZEL_TUTAR2_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value,
                                                                            gonderen.OZEL_TUTAR2_DOVIZ_ID,
                                                                            gonderen.OZEL_TUTAR2_FAIZ_BASLANGIC_TARIHI);
            }
            if (e.Column == AV001_TI_BIL_FOYColumn.OZEL_TUTAR3_FAIZ_TIP_ID)
            {
                gonderen.OZEL_TUTAR3_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value,
                                                                            gonderen.OZEL_TUTAR3_DOVIZ_ID,
                                                                            gonderen.OZEL_TUTAR3_FAIZ_BASLANGIC_TARIHI);
            }
            if (e.Column == AV001_TI_BIL_FOYColumn.OZEL_TAZMINAT_FAIZ_TIP_ID)
            {
                gonderen.OZEL_TAZMINAT_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value,
                                                                              gonderen.OZEL_TAZMINAT_DOVIZ_ID,
                                                                              gonderen.
                                                                                  OZEL_TAZMINAT_FAIZ_BASLANGIC_TARIHI);
            }
        }

        private void LoadData()
        {
            AvukatPro.Services.Implementations.DevExpressService.FoyIadeNedenDoldur(lkMuvekkileIadeNedeni);
            AvukatPro.Services.Implementations.DevExpressService.FormTipiDoldur(lueFormTip);
            AvukatPro.Services.Implementations.DevExpressService.TakipYoluDoldur(lueTakipKonusu);

            //BelgeUtil.Inits.FoyIadeNedenGetir(lkMuvekkileIadeNedeni.Properties);
            //BelgeUtil.Inits.FormTipiGetir(lueFormTip.Properties);
            //BelgeUtil.Inits.TakipKonusuGetir(lueTakipKonusu.Properties);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(lueMudurluk);
            AvukatPro.Services.Implementations.DevExpressService.FoyDurumDoldur(lueTakibinDurumu);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(lueMudurlukNo);
            AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(lueSegment);

            #region <MB-20100524>

            //Klasör Grubunda Doldurulan Lookup'lar
            if (MyProje != null)
            {
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rlueYetkiliCari);
                AvukatPro.Services.Implementations.DevExpressService.ProjeOzelKodDoldur(lueSube);
                //lueSube.EditValue = MyProje.SUBE_KOD_ID;
                //txtKlasor.EditValue = MyProje.ADI;
                //txtKlasorKodu.EditValue = MyProje.KOD;
                //sbtnKlasorEkraninaGonder.Visible = false;
                //gcKlasorSorumlu.DataSource = MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection;
                //txtKlasorKodu.EditValue=MyProje.
                //BelgeUtil.Inits.ProjeOzelKodGetir(lueSube.Properties);
            }

            #endregion <MB-20100524>

            #region <MB-20100624>

            //Asýl alacak, Takip çýkýþý, Ödemeler, Kalan miktarlarýnýn gelmesi için eklendi.

            //Inits.ParaBicimiAyarla(spAsilAlacak);
            //Inits.ParaBicimiAyarla(spTakipCikisi);
            //Inits.ParaBicimiAyarla(spOdemeler);
            //Inits.ParaBicimiAyarla(spKalan);

            //Inits.DovizTipGetir(lueAsilAlacakDoviz);
            //Inits.DovizTipGetir(lueTakipCikisiDoviz);
            //Inits.DovizTipGetir(lueOdemelerDoviz);
            //Inits.DovizTipGetir(lueKalanDoviz);

            #endregion <MB-20100624>
        }

        //public void TakipAsamasiDoldur(AV001_TI_BIL_FOY foy)
        //{
        //   AdimAdimDavaKaydi.Util.AsamaHelper.AsamalariHallet(foy);

        //    TList<TDIE_KOD_ASAMA> kodAsamaList = new TList<TDIE_KOD_ASAMA>();
        //    if (foy.AV001_TDIE_BIL_ASAMACollection != null)
        //    {
        //        foreach (AV001_TDIE_BIL_ASAMA asm in foy.AV001_TDIE_BIL_ASAMACollection)
        //        {
        //            if (asm.ASAMA_KOD_IDSource == null)
        //            {
        //                DataRepository.AV001_TDIE_BIL_ASAMAProvider.DeepLoad(asm, true, DeepLoadType.IncludeChildren,
        //                                                                     typeof(TDIE_KOD_ASAMA));
        //            }
        //            try
        //            {
        //                kodAsamaList.Add(asm.ASAMA_KOD_IDSource);
        //            }
        //            catch
        //            {
        //            }
        //        }
        //    }

        //    txtTakipAsamasi.Properties.NullText = "Takip Aþamasý Yok";

        //    if (kodAsamaList.Count > 0)
        //    {
        //        kodAsamaList.Sort("SIRA_NO DESC");
        //        txtTakipAsamasi.Text = kodAsamaList[0].ASAMA_ADI;
        //    }
        //}

        #region <MB-20100628>

        //Veri girilen tarihlere göre icra durumunun belirlenmesini saðlamak için eklendi.
        private Dictionary<DateTime, int> icraTarihleri = new Dictionary<DateTime, int>();

        #endregion <MB-20100628>

        #endregion Methods

        #region DataNavigator_EventArgs

        private void bndIcraFoy_CurrentChanged(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(int)) return;

            MyFoy = ucIcraBindingControl1.MyDataSource[ucIcraBindingControl1.dataNavigator1.Position];

            try
            {
                DataChange(MyFoy);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        private void dataNavigator1_PositionChanged(object sender, EventArgs e)
        {
            //Okan.. Performans çalýþmasý için kapatýldý.
            bndIcraFoy_CurrentChanged(ucIcraBindingControl1.dataNavigator1.Position, e);
        }

        #endregion DataNavigator_EventArgs

        #region Yazdýrma Þablonlarý

        public class YazdirmaSablonlari
        {
            public AV001_TDIE_BIL_SABLON_RAPOR Rapor { get; set; }

            public string Text { get; set; }

            public override string ToString()
            {
                return this.Rapor.AD;
            }
        }

        #endregion Yazdýrma Þablonlarý

        #region Click_EventArgs

        private void btnIliskiliDosya_ItemClick(object sender, EventArgs e)
        {
            //Çalýþtý

            AdimAdimDavaKaydi.Forms.frmKayitIliski frm = new AdimAdimDavaKaydi.Forms.frmKayitIliski();
            frm.MyIcraFoy = MyFoy;
            frm.FormClosed += frm_FormClosed;
            frm.Show();

            //rFrmKayitIliski frmKayitIlis = new rFrmKayitIliski();
            //frmKayitIlis.Show();
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ucIcraCore1 != null && ucIcraCore1.ucIcraGridlerTemp1 != null && ucIcraCore1.ucIcraGridlerTemp1.ucIliskiDetay1 != null)
                ucIcraCore1.ucIcraGridlerTemp1.ucIliskiDetay1.GetList(MyFoy.ID, ucIliskiDetay.IliskiTur.ÝCRA_DOSYASI);

            var iliskiler = BelgeUtil.Inits.context.per_AV001_TDI_BIL_KAYIT_ILISKIs.Where(vi => vi.KAYNAK_KAYIT_ID == MyFoy.ID).ToList();
            var detay = DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_ICRA_FOY_ID(MyFoy.ID);

            if ((iliskiler != null && iliskiler.Count > 0) || detay.Count > 0)
                c_titemIliskiliDosyalar.Image =
                    global::AdimAdimDavaKaydi.Properties.Resources.iliskili_dosyalar_red_16x16;
            else
                c_titemIliskiliDosyalar.Image =
                    global::AdimAdimDavaKaydi.Properties.Resources.iliskili_dosyalar_mavi_16x16;
        }

        #endregion Click_EventArgs

        private void sbtnMudurlukEsasNoDegistir_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.frmDosyaKimlikBilgileri frm = new AdimAdimDavaKaydi.Forms.frmDosyaKimlikBilgileri();
            frm.Show(MyFoy);
        }

        private void sbtnTakipSetiYazdir_Click(object sender, EventArgs e)
        {
            //Avukatpro ayarlarý getirtilir.
            var ayarlar = BelgeUtil.Inits.context.AV001_TI_BIL_YAZDIRMA_AYARLARIs.Where(vi => vi.KULLANICI_ID == Kimlikci.Kimlik.Cari_ID && vi.FORM_ID == MyFoy.FORM_TIP_ID);
            if (ayarlar.Count() > 0)
            {
                List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> SecilenRaporlar = new List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>();

                var ayar = ayarlar.First();

                foreach (var aDetay in ayar.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAYs)
                {
                    var sablon = BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.Where(vi => vi.ID == aDetay.SABLON_ID).FirstOrDefault();
                    if (sablon != null)
                        SecilenRaporlar.Add(sablon);
                }

                AdimAdimDavaKaydi.Generalclass.Forms.frmIstek istek = new AdimAdimDavaKaydi.Generalclass.Forms.frmIstek();
                istek.Foyler.Add(MyFoy);

                string resultstring = istek.LoadFromList(SecilenRaporlar);
                string BarkodTip = resultstring.Split('-')[0].ToString();// barkod tipini kullanýcaz 
                DialogResult dialogResult = resultstring.Split('-')[1].ToString() == "OK" ? DialogResult.OK : DialogResult.Cancel;
                if (dialogResult == DialogResult.Cancel)
                    return;

                if (istek.PostaListesiVarmi)
                {
                    List<object> liste = new List<object>();
                    liste.Add(MyFoy);
                    frmPostaListesiYazdir frm = new frmPostaListesiYazdir(liste);
                    frm.Show();
                }

                if (istek.list is List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>)
                {
                    List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> dlstRaporlar = ((List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>)istek.list);
                    AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor SelectedEditor = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();

                    SelectedEditor = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();
                    SelectedEditor.MdiParent = AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm;

                    SelectedEditor.OpenAllSablonForThread(dlstRaporlar, MyFoy, BarkodTip);
                }
            }
            else
            {
                MessageBox.Show("Bu takip formu için takip seti tanýmý yapýlmamýþtýr.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmAdimAdimEditoreGonder editorForm = new frmAdimAdimEditoreGonder();
            editorForm.SecilenCiktiTipi = frmAdimAdimEditoreGonder.CiktiTipi.Uyap;
            List<object> secilenFoy = new List<object>();
            secilenFoy.Add(this.MyFoy);
            editorForm.SelectedList = secilenFoy;
            editorForm.ChangePage("wizardPage1");
            editorForm.Show();
            this.Close();

            //AvukatProUyap.Helper.GetUyap(BelgeUtil.Inits.context.VTI_ICRA_DOSYALARs.Single(item => item.ID == this.MyFoy.ID));
        }

        private void tabcIcraTakip_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page.Name == tabGelismeler.Name)
            {
                //if (!bgAlacakIntDone)
                //{
                //    bgAlacakInt = new BackgroundWorker();
                //    bgAlacakInt.DoWork += delegate
                //    {
                //        BelgeUtil.Inits.BankaKartTipiGetir(new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit());
                //        BelgeUtil.Inits.RehinCinsGetir(new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit());
                //        BelgeUtil.Inits.HarcIstisnaGetir(new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit());
                //        BelgeUtil.Inits.RehinSiciltipGetir(new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit());
                //        BelgeUtil.Inits.RehinDurumGetir(new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit());
                //        BelgeUtil.Inits.SozlesmeDurumGetir(new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit());
                //        BelgeUtil.Inits.IcraItirazSonucGetir(new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit());
                //        BelgeUtil.Inits.SozlesmeAltTipiHepsiGetir(new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit());
                //        BelgeUtil.Inits.ProjeOzelKodGetir(new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit());
                //    };
                //    bgAlacakInt.RunWorkerCompleted += delegate
                //    {
                //        bgAlacakIntDone = true;
                //    };
                //    bgAlacakInt.RunWorkerAsync();
                //}

                tabGelismeler.SuspendLayout();
                if (ucIcraCore1 == null)
                    CreateUcIcraCore();
                DataChange(bndIcraFoy.Current as AV001_TI_BIL_FOY);
                tabGelismeler.ResumeLayout(false);
            }
        }

        #region <MB-20100524>



        #endregion <MB-20100524>

        private void TarafKontrolOlustur()
        {
            #region taraf bilgilerinin yükleniþi

            if (icraTarafBilgileri == null)
            {
                CreateIcraTarafBilgileri();

                if (icraTarafBilgileri != null) // Okan 18.06.2010
                {
                    if (this.icraTarafBilgileri.BorcluTarafControls == null)
                        icraTarafBilgileri.BorcluTarafControls = new List<DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit>();
                    try
                    {
                        if (this.ucIcraCore1.ucIcraGridlerTemp1 != null)
                        {
                            if (this.ucIcraCore1.ucIcraGridlerTemp1.ucAlacaklar1 != null)
                                this.icraTarafBilgileri.BorcluTarafControls.Add(
                                    this.ucIcraCore1.ucIcraGridlerTemp1.ucAlacaklar1.rLueCariID);
                            if (this.ucIcraCore1.ucIcraGridlerTemp1.ucItiraz != null)
                                this.icraTarafBilgileri.BorcluTarafControls.Add(
                                    this.ucIcraCore1.ucIcraGridlerTemp1.ucItiraz.rLueCari);
                            if (this.ucIcraCore1.ucIcraGridlerTemp1.ucSatisMaster1 != null)
                                this.icraTarafBilgileri.BorcluTarafControls.Add(
                                    this.ucIcraCore1.ucIcraGridlerTemp1.ucSatisMaster1.rLueBorcluTaraf);
                        }

                        if (this.icraTarafBilgileri.AlacakliTarafControls == null)
                            icraTarafBilgileri.AlacakliTarafControls = new List<DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit>();

                        if (this.ucIcraCore1.ucIcraGridlerTemp1 != null)
                            if (this.ucIcraCore1.ucIcraGridlerTemp1.ucSatisMaster1 != null)
                                this.icraTarafBilgileri.AlacakliTarafControls.Add(
                                    this.ucIcraCore1.ucIcraGridlerTemp1.ucSatisMaster1.rLueAlacakliTaraf);
                    }
                    catch
                    {
                    }
                }
            }

            #endregion taraf bilgilerinin yükleniþi
        }

        private void tarafMenu()
        {
            TarafKontrolOlustur();
            if (this.icraTarafBilgileri.MyFoy == null)
                this.icraTarafBilgileri.MyFoy = this.MyFoy;

            //labelControl26.Visible = false;
            //splitContainerControl2.Collapsed = !splitContainerControl2.Collapsed;
            //labelControl26.Location = new System.Drawing.Point(btnTaraflar.Location.X + 3, labelControl26.Location.Y);
            //labelControl26.Visible = true;
            //if (splitContainerControl2.Collapsed)
            //    btnTaraflar.Text = ">";
            //else
            //    btnTaraflar.Text = "<";
        }

        #region Icra Hýzlý Eriþim Button Click

        private void btnAlacak_Click(object sender, EventArgs e)
        {
            frmAlacakNedenEkle frm = new frmAlacakNedenEkle();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnBorcluTaahhudu_Click(object sender, EventArgs e)
        {
            rFrmTaahhut frm = new rFrmTaahhut();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.MyFoy = MyFoy;
            frm.Show();
        }

        private void btnDokumanBelge_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak frm = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.OpenedRecord = MyFoy;
            frm.Show();
        }

        private void btnDusmeYenileme_Click(object sender, EventArgs e)
        {
            frmDusmeYenileme frm = new frmDusmeYenileme();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnEditorAc_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor editor = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();
            editor.MdiParent = AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm;
            AV001_TI_BIL_FOY fy = (AV001_TI_BIL_FOY)this.bndIcraFoy.Current;
            TList<AV001_TI_BIL_FOY> lstfoys = new TList<AV001_TI_BIL_FOY>();
            lstfoys.Add(fy);
            editor.SelectedFoys = lstfoys;
            editor.Show();
        }

        private void btnEvrakTebligat_Click(object sender, EventArgs e)
        {
            Forms.LayForm.frmLayTabligatKayit frm = new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnExcelAc_Click(object sender, EventArgs e)
        {
            ExcelAc();
        }

        private void btnFeragat_Click(object sender, EventArgs e)
        {
            frmFeragatBilgileri frm = new frmFeragatBilgileri();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnGorusme_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit frm = new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnHaciz_Click(object sender, EventArgs e)
        {
            frmHacizGirisi frm = new frmHacizGirisi();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.HacizEdilecekMalVar = true;
            frm.Show(MyFoy, null);
        }

        private void btnIcraKefili_Click(object sender, EventArgs e)
        {
            frmKefaletBilgileri frm = new frmKefaletBilgileri();
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show(MyFoy);
        }

        private void btnIcraTalimati_Click(object sender, EventArgs e)
        {
            frmIcraTalimatlari talimat = new frmIcraTalimatlari();
            talimat.MyFoy = MyFoy;
            talimat.StartPosition = FormStartPosition.CenterParent;
            talimat.Show();
        }

        private void btnIhtiyatiHaciz_Click(object sender, EventArgs e)
        {
            frmIcraIhtiyatiHaciz frm = new frmIcraIhtiyatiHaciz();
            frm.MyFoy = MyFoy;
            frm.MyDataSource = null;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void btnIhtiyatiTedbir_Click(object sender, EventArgs e)
        {
            frmDavaIcraIhtiyatiTedbir frm = new frmDavaIcraIhtiyatiTedbir();
            frm.MyFoy = MyFoy;
            frm.MyDataSource = null;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void btnIliskiliDosya_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.frmKayitIliski frm = new AdimAdimDavaKaydi.Forms.frmKayitIliski();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.MyIcraFoy = MyFoy;
            frm.Show();
        }

        private void btnIsEmri_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frm = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ucIsKayitUfak1.OpenedRecord = MyFoy;
            frm.ucIsKayitUfak1.ModulID = 1;
            frm.Show();
        }

        private void btnItiraz_Click(object sender, EventArgs e)
        {
            rFrmItiraz frm = new rFrmItiraz();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.MyGelisme = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme;
            frm.Show(MyFoy);
        }

        private void btnMahsup_Click(object sender, EventArgs e)
        {
            frmMahsupBilgileri frm = new frmMahsupBilgileri();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnMalBeyani_Click(object sender, EventArgs e)
        {
            frmMalBeyani frm = new frmMalBeyani();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.MyGelisme = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme;
            frm.Show(MyFoy);
        }

        private void btnMasrafAvans_Click(object sender, EventArgs e)
        {
            IcraTakipForms.frmMasrafAvansKayitHizli frm = new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
            frm.AcilisYeri = AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.TakipEkrani;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnMehil_Click(object sender, EventArgs e)
        {
            rFrmMehil frm = new rFrmMehil();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnMuvekkileOdeme_Click(object sender, EventArgs e)
        {
            frmMuvekkilOdemeleriLayout frm = new frmMuvekkilOdemeleriLayout(AvukatProLib.Extras.Modul.Icra, MyFoy.ID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void btnNot_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.rFrmDavaGenelNotlar frm = new AdimAdimDavaKaydi.Forms.Dava.rFrmDavaGenelNotlar();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            rFrmTarafOdeme frm = new rFrmTarafOdeme();
            frm.MyGelisme = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnOdemePlani_Click(object sender, EventArgs e)
        {
            //TList<AV001_TI_BIL_FOY> foys = new TList<AV001_TI_BIL_FOY>();
            //if (bndIcraFoy.DataSource != null)
            //{
            //    foys.Add(MyFoy);
            //    AV001_TI_BIL_FOY toplam = AvukatProLib.Hesap.KlasoreTaahhut.IcraFoyleriniTopla(foys);
            //    AdimAdimDavaKaydi.UserControls.frmOdemePlani frm = new AdimAdimDavaKaydi.UserControls.frmOdemePlani();
            //    frm.Show(toplam);
            //}

            //AdimAdimDavaKaydi.UserControls.frmOdemePlani frm = new AdimAdimDavaKaydi.UserControls.frmOdemePlani();
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.Show(MyFoy);
            AdimAdimDavaKaydi.UserControls.frmOdemePlani frm = new AdimAdimDavaKaydi.UserControls.frmOdemePlani();
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show(MyFoy.ID, MyFoy.FOY_NO);
        }

        private void btnOutlookAc_Click(object sender, EventArgs e)
        {
            OutlookAc();
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            frmSatisGirisi frm = new frmSatisGirisi();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.MyGelisme = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.GelismeBul(MyFoy);
            frm.Show(MyFoy);
        }

        private void btnWordAc_Click(object sender, EventArgs e)
        {
            WordAc();
        }

        #endregion Icra Hýzlý Eriþim Button Click

        private void dpDosyaHesabi_Click(object sender, EventArgs e)
        {

        }

        private void dpDosyaHesabi_VisibilityChanged(object sender, DevExpress.XtraBars.Docking.VisibilityChangedEventArgs e)
        {

        }

        private void dpTarafBilgileri_VisibilityChanged(object sender, DevExpress.XtraBars.Docking.VisibilityChangedEventArgs e)
        {
            //tarafMenu();
        }

        private void dpTarafBilgileri_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            dpTarafBilgileri.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            panelControl2.Visible = false;
            tarafMenu();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            dpDosyaHesabi.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            panelControl1.Visible = false;
            ucIcraHesapCetveli1.MyFoyDataSource = MyFoy;
            ucIcraHesapCetveli1.MyTarafSource = MyFoy.AV001_TI_BIL_FOY_TARAFCollection;
            //ucIcraHesapCetveli1.MyTarafSource = DataRepository.AV001_TI_BIL_FOY_TARAFProvider.GetByICRA_FOY_ID(MyFoy.ID);
        }

        private void btnKlasoreBagla_Click(object sender, EventArgs e)
        {
            if (btnKlasoreBagla.Tag.ToString() == "BAÐLA")
                popupKlasoreBagla.Visible = !popupKlasoreBagla.Visible;
            else
            {
                if (MessageBox.Show("Ýþleme devam etmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    AV001_TDIE_BIL_PROJE_ICRA_FOY aa = DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.GetByICRA_FOY_ID(MyFoy.ID)[0];
                    MyProje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(aa.PROJE_ID);

                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<NN_ICRA_KIYMETLI_EVRAK>), typeof(TList<NN_ICRA_SOZLESME>), typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ>), typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>));

                    foreach (var item in MyFoy.NN_ICRA_KIYMETLI_EVRAKCollection)
                    {
                        DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLIProvider.Delete(item.KIYMETLI_EVRAK_ID, MyProje.ID);
                    }

                    foreach (var item in MyFoy.NN_ICRA_SOZLESMECollection)
                    {
                        DataRepository.AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLIProvider.Delete(MyProje.ID, item.SOZLESME_ID);
                        DataRepository.AV001_TDIE_BIL_PROJE_SOZLESMEProvider.Delete(MyProje.ID, item.SOZLESME_ID);
                    }

                    foreach (var item in MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection)
                    {
                        DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLIProvider.Delete(MyProje.ID, item.ID);
                    }

                    foreach (var item in MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection)
                    {
                        DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLIProvider.Delete(MyProje.ID, item.ID);
                    }

                    try
                    {
                        ABSqlConnection cn = new ABSqlConnection();
                        cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                        cn.AddParams("@PROJE_ID", MyProje.ID);
                        cn.AddParams("@ICRA_FOY_ID", MyFoy.ID);

                        cn.ExcuteQuery("delete from dbo.AV001_TDIE_BIL_PROJE_ILAM_BILGILERI_TAKIPLI where PROJE_ID=@PROJE_ID and ILAM_ID in (SELECT ID FROM dbo.AV001_TI_BIL_ILAM_MAHKEMESI(nolock) WHERE ICRA_FOY_ID=@ICRA_FOY_ID)");
                    }
                    catch { ;}

                    DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.Delete(DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.GetByICRA_FOY_ID(MyFoy.ID));

                    MessageBox.Show("Ýþlem Tamamlandý.", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnKlasoreBagla.Tag = "BAÐLA";
                    btnKlasoreBagla.Text = "ÝCRA DOSYASINI KLASÖRE BAÐLA";
                }
            }
        }

        private void btnBagla_Click(object sender, EventArgs e)
        {
            //Bu butona dosya herhangi bir proje baðlý olduðunda ulaþýlamadýðýndan proje icra tablosunda bu takip var mý diye kontrol yapmaya gerek kalmadý. MB

            if (lueKlasor.EditValue == null)
            {
                MessageBox.Show("Takibi baðlamak istediðiniz klasörü seçmelisiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            AV001_TDIE_BIL_PROJE_ICRA_FOY nnProjeIcra = new AV001_TDIE_BIL_PROJE_ICRA_FOY();
            nnProjeIcra.PROJE_ID = (int)lueKlasor.EditValue;
            nnProjeIcra.ICRA_FOY_ID = MyFoy.ID;

            try
            {
                DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.Save(nnProjeIcra);

                btnKlasoreBagla.Tag = "ÇIKAR";
                btnKlasoreBagla.Text = "ÝCRA DOSYASINI KLASÖRDEN ÇIKAR";

                MyProje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID((int)lueKlasor.EditValue);
                if (MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>), typeof(TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI>), typeof(TList<AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLI>), typeof(TList<AV001_TDIE_BIL_PROJE_SOZLESME>), typeof(TList<AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI>), typeof(TList<AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI>));

                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<NN_ICRA_KIYMETLI_EVRAK>), typeof(TList<NN_ICRA_SOZLESME>), typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ>), typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>));

                foreach (var item in MyFoy.NN_ICRA_KIYMETLI_EVRAKCollection)
                {
                    AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI a = new AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI();
                    a.PROJE_ID = MyProje.ID;
                    a.KIYMETLI_EVRAK_ID = item.KIYMETLI_EVRAK_ID;
                    if (!MyProje.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLICollection.Contains(a))
                        MyProje.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLICollection.Add(a);
                }

                if (MyFoy.FORM_TIP_ID == 2 || MyFoy.FORM_TIP_ID == 13 || MyFoy.FORM_TIP_ID == 7 || MyFoy.FORM_TIP_ID == 8)
                {
                    foreach (var item in MyFoy.NN_ICRA_SOZLESMECollection)
                    {
                        AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLI a = new AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLI();
                        a.PROJE_ID = MyProje.ID;
                        a.SOZLESME_ID = item.SOZLESME_ID;
                        if (!MyProje.AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLICollection.Contains(a))
                            MyProje.AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLICollection.Add(a);
                    }
                }
                else
                {
                    foreach (var item in MyFoy.NN_ICRA_SOZLESMECollection)
                    {
                        AV001_TDIE_BIL_PROJE_SOZLESME a = new AV001_TDIE_BIL_PROJE_SOZLESME();
                        a.PROJE_ID = MyProje.ID;
                        a.SOZLESME_ID = item.SOZLESME_ID;
                        if (!MyProje.AV001_TDIE_BIL_PROJE_SOZLESMECollection.Contains(a))
                            MyProje.AV001_TDIE_BIL_PROJE_SOZLESMECollection.Add(a);
                    }
                }

                foreach (var item in MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection)
                {
                    AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI a = new AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI();
                    a.PROJE_ID = MyProje.ID;
                    a.IHTIYATI_HACIZ_ID = item.ID;
                    if (!MyProje.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLICollection.Contains(a))
                        MyProje.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLICollection.Add(a);
                }

                foreach (var item in MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection)
                {
                    AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI a = new AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI();
                    a.PROJE_ID = MyProje.ID;
                    a.IHTIYATI_TEDBIR_ID = item.ID;
                    if (!MyProje.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLICollection.Contains(a))
                        MyProje.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLICollection.Add(a);
                }

                try
                {
                    ABSqlConnection cn = new ABSqlConnection();
                    cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                    cn.AddParams("@PROJE_ID", MyProje.ID);
                    cn.AddParams("@ICRA_FOY_ID", MyFoy.ID);

                    cn.ExcuteQuery("INSERT INTO dbo.AV001_TDIE_BIL_PROJE_ILAM_BILGILERI_TAKIPLI (ILAM_ID, PROJE_ID, STAMP) SELECT ID, @PROJE_ID, 1 FROM dbo.AV001_TI_BIL_ILAM_MAHKEMESI(nolock) WHERE ICRA_FOY_ID=@ICRA_FOY_ID");
                }
                catch { ;}

                DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.Save(nnProjeIcra);
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(MyProje);
                MessageBox.Show("Ýþlem Tamamlandý.", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                bndProje.DataSource = MyProje;

                BelgeUtil.Inits.perCariGetir(rlueYetkiliCari);
                BelgeUtil.Inits.ProjeOzelKodGetir(lueSube.Properties);
            }
            catch
            {
                MessageBox.Show("Ýþlem Tamamlanamadý.", "ÝPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            popupKlasoreBagla.Visible = false;
        }

        private void sbtnKlasorEkraninaGonder_Click(object sender, EventArgs e)
        {
            if (MyProje == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Dosyada Klasör Bulunmamaktadýr.", "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            Forms.frmKlasorYeni klasor = new AdimAdimDavaKaydi.Forms.frmKlasorYeni();
            TList<AV001_TDIE_BIL_PROJE> projeler = new TList<AV001_TDIE_BIL_PROJE>();
            projeler.Add(MyProje);
            klasor.Show(projeler);
        }

        private void tabcIcraTakip_Click(object sender, EventArgs e)
        {

        }

        private void ucSablonEditoreGonder1_Load(object sender, EventArgs e)
        {

        }
    }

}