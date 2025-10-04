using AvukatProLib;
using AvukatProRaporlar.Lib;
using AvukatProRaporlar.RaporSource;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using RaporDataSource.TableDB;
using RaporDataSource.ViewDB;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AvukatProRaporlar.Forms
{
    public partial class frmListeRapor : DevExpress.XtraEditors.XtraForm, iAVPForms
    {
        public frmListeRapor()
        {
            InitializeComponent();
            this.Load += frmListeRapor_Load;
            this.FormClosed += frmListeRapor_FormClosed;
            kasa = new RaporYapilacakIsler();
        }

        private BackgroundWorker bw = new BackgroundWorker();
        private GridColumn[] gList;
        private RaporYapilacakIsler kasa;

        public void ArsivDavalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            gridListeControl.DataSource = cn.GetDataTable("select * from dbo.R_TEMYIZ_TAKIP_RAPOR_YENI where [Yer Anlam] not in ('RED','AÇILMAMIŞ SAYILMA','DÜŞME','KABUL')");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();

            gridListeView.Columns["CARI_ID"].Visible = false;
        }

        public void AvukataIntikalTarihi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "SORUMLU").SingleOrDefault().Group();
            gList.Where(vi => vi.FieldName == "TAKIBIN_AVUKATA_INTIKAL_TARIHI").SingleOrDefault().Group();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void DagitimiYapilmamisDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor dp = new DavaPratikRapor();
            gList = dp.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(vi => vi.DURUM == "EVRAK");
            if (dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(vi => vi.DURUM == "EVRAK").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        public void DavaEdenAleyheDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            gridListeControl.DataSource = cn.GetDataTable("SELECT * FROM R_HUKUM_TAKIP_RAPOR_YENI WHERE DAVAPOZISYONU='DAVA EDEN' AND Anlam in ('RED','AÇILMAMIŞ SAYILMA','DÜŞME')");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gridListeView.Columns["TARAF_CARI_ID"].Visible = false;
            gridListeView.Columns["DAVAPOZISYONU"].Visible = false;
        }

        public void DavaEdenLeyheDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            //mahkemeHukum tt = new mahkemeHukum();
            //gList = tt.GetGridColumns();
            //gridListeView.Columns.AddRange(gList);

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            gridListeControl.DataSource = cn.GetDataTable("SELECT * FROM R_HUKUM_TAKIP_RAPOR_YENI WHERE DAVAPOZISYONU='DAVA EDEN' and Anlam='KABUL'");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeView.Columns["TARAF_CARI_ID"].Visible = false;
            gridListeView.Columns["DAVAPOZISYONU"].Visible = false;
            gridListeControl.initOncekiAyarlar();
            //if (dbV.R_HUKUM_TAKIP_RAPORs.Where(vi => vi.DAVA_EDEN_SIFAT == "DAVACI").Where(vi => vi.HUKUM_ANLAM == "KABUL" || vi.HUKUM_ANLAM == "KABUL/RED").Count() <= 0)
            //    XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void DavaEdilenAleyheDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            //mahkemeHukum tt = new mahkemeHukum();
            //gList = tt.GetGridColumns();
            //gridListeView.Columns.AddRange(gList);

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            gridListeControl.DataSource = cn.GetDataTable("SELECT * FROM R_HUKUM_TAKIP_RAPOR_YENI WHERE DAVAPOZISYONU='DAVA EDİLEN' AND Anlam='KABUL'");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gridListeView.Columns["TARAF_CARI_ID"].Visible = false;
            gridListeView.Columns["DAVAPOZISYONU"].Visible = false;
            //if (dbV.R_HUKUM_TAKIP_RAPORs.Where(vi => vi.DAVA_EDILEN_SIFAT == "DAVALI").Where(vi => vi.HUKUM_ANLAM == "KABUL" || vi.HUKUM_ANLAM == "KABUL/RED").Count() <= 0)
            //    XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void DavaEdilenLeyheDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            //mahkemeHukum tt = new mahkemeHukum();
            //gList = tt.GetGridColumns();
            //gridListeView.Columns.AddRange(gList);

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            gridListeControl.DataSource = cn.GetDataTable("SELECT * FROM R_HUKUM_TAKIP_RAPOR_YENI WHERE DAVAPOZISYONU='DAVA EDİLEN' AND Anlam in ('RED','AÇILMAMIŞ SAYILMA','DÜŞME')");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gridListeView.Columns["TARAF_CARI_ID"].Visible = false;
            gridListeView.Columns["DAVAPOZISYONU"].Visible = false;
            //if (dbV.R_HUKUM_TAKIP_RAPORs.Where(vi => vi.DAVA_EDILEN_SIFAT == "DAVALI").Where(vi => vi.HUKUM_ANLAM == "RED" || vi.HUKUM_ANLAM == "KABUL/RED").Count() <= 0)
            //    XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void DigerKararlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            //mahkemeHukum tt = new mahkemeHukum();
            //gList = tt.GetGridColumns();
            //gridListeView.Columns.AddRange(gList);

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            gridListeControl.DataSource = cn.GetDataTable("SELECT * FROM R_HUKUM_TAKIP_RAPOR_YENI where Anlam not in ('RED','AÇILMAMIŞ SAYILMA','DÜŞME','KABUL/RED','KABUL')");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gridListeView.Columns["TARAF_CARI_ID"].Visible = false;
            gridListeView.Columns["DAVAPOZISYONU"].Visible = false;
            //gList.Where(vi => vi.FieldName == "HUKUM_ANLAM").SingleOrDefault().Group();
            //if (dbV.R_HUKUM_TAKIP_RAPORs.Where(vi => vi.HUKUM_ANLAM != "RED" || vi.HUKUM_ANLAM != "KABUL/RED" || vi.HUKUM_ANLAM != "KABUL").Count() <= 0)
            //    XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void DosyaKapama(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor dp = new DavaPratikRapor();
            gList = dp.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(vi => vi.DURUM == "ACİZ" || vi.DURUM == "FERAGAT" || vi.DURUM == "İNFAZ" || vi.DURUM == "TERKİN" || vi.DURUM == "KISMİ İNFAZ" || vi.DURUM == "İNFAZ ZAMAN AŞIMI" || vi.DURUM == "İNFAZ REHİN AÇIĞI" || vi.DURUM == "SULH" || vi.DURUM == "SEMERESİZ" || vi.DURUM == "KKK");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "DURUM").SingleOrDefault().Group();
            if (dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(vi => vi.DURUM == "ACİZ" || vi.DURUM == "FERAGAT" || vi.DURUM == "İNFAZ" || vi.DURUM == "TERKİN" || vi.DURUM == "KISMİ İNFAZ" || vi.DURUM == "İNFAZ ZAMAN AŞIMI" || vi.DURUM == "İNFAZ REHİN AÇIĞI" || vi.DURUM == "SULH" || vi.DURUM == "SEMERESİZ" || vi.DURUM == "KKK").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        public void DurusmaListesi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            DurusmaDavaGenelRapor durusma = new DurusmaDavaGenelRapor();
            gList = durusma.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_DURUSMA_DAVA_GENEL_TARAFLI_RAPORs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_DURUSMA_DAVA_GENEL_TARAFLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void FaalDavalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            //DavaPratikArama dp = new DavaPratikArama();
            DavaPratikRapor dp = new DavaPratikRapor();
            gList = dp.GetGridColumns();
            gridListeView.Columns.AddRange(gList);

            gridListeControl.DataSource = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(vi => vi.DURUM == "DERDEST");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(vi => vi.DURUM == "DERDEST").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void FaalSorusturmalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            SorusturmaGenelHesapsiz sorusturma = new SorusturmaGenelHesapsiz();
            gList = sorusturma.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_SORUSTURMA_GENEL_HESAPSIZ_RAPORs.Where(vi => vi.DURUM == "Şoruşturma Sürüyor");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_SORUSTURMA_GENEL_HESAPSIZ_RAPORs.Where(vi => vi.DURUM == "Şoruşturma Sürüyor").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void IcraTakibineBagliCezaDavalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor dp = new DavaPratikRapor();
            gList = dp.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(vi => vi.GOREV == "İCM" || vi.GOREV == "İHUM").Where(vii => vii.BIRIM == "İCRA-CEZA" || vii.BIRIM == "CEZA");
            if (dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(vi => vi.GOREV == "İCM" || vi.GOREV == "İHUM").Where(vii => vii.BIRIM == "İCRA-CEZA" || vii.BIRIM == "CEZA").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        public void IcraTakibineBagliDavalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            DavaPratikRapor dp = new DavaPratikRapor();
            gList = dp.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(vi => vi.GOREV == "İCM" || vi.GOREV == "İHUM");
            if (dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(vi => vi.GOREV == "İCM" || vi.GOREV == "İHUM").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        public void IcraTakibineBagliHukukDavalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor dp = new DavaPratikRapor();
            gList = dp.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(vi => vi.GOREV == "İHUM").Where(vii => vii.BIRIM == "HUKUK" || vii.BIRIM == "İCRA-HUKUK");
            if (dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(vi => vi.GOREV == "İHUM").Where(vii => vii.BIRIM == "HUKUK" || vii.BIRIM == "İCRA-HUKUK").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        public void IflasliTakipler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.FORM_TIPI.Contains("FORM 12 (52)") || vi.FORM_TIPI.Contains("153"));
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.FORM_TIPI.Contains("FORM 12 (52)") || vi.FORM_TIPI.Contains("153")).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void IpotekliTakipler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.FORM_TIPI.Contains("151") || vi.FORM_TIPI.Contains("152"));
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.FORM_TIPI.Contains("151") || vi.FORM_TIPI.Contains("152")).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void KesifListesi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            DurusmaDavaGenelRapor durusma = new DurusmaDavaGenelRapor();
            gList = durusma.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_DURUSMA_DAVA_GENEL_TARAFLI_RAPORs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_DURUSMA_DAVA_GENEL_TARAFLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void KesinMehilliAraKararlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            AraKararGenelTarafliRapor araKarar = new AraKararGenelTarafliRapor();
            gList = araKarar.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_ARA_KARAR_DAVA_GENEL_TARAFLI_RAPORs.Where(vi => vi.TIP_ID == 2 && vi.DURUM == "DERDEST");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "YERINE_GETIRME_TARIH").SingleOrDefault().Group();
            if (dbV.R_ARA_KARAR_DAVA_GENEL_TARAFLI_RAPORs.Where(vi => vi.TIP_ID == 2 && vi.DURUM == "DERDEST").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void KısmenAleyheLeheKararaCikanlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            //mahkemeHukum tt = new mahkemeHukum();
            //gList = tt.GetGridColumns();
            //gridListeView.Columns.AddRange(gList);

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            gridListeControl.DataSource = cn.GetDataTable("SELECT * FROM R_HUKUM_TAKIP_RAPOR_YENI where Anlam='KABUL/RED'");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gridListeView.Columns["TARAF_CARI_ID"].Visible = false;
            gridListeView.Columns["DAVAPOZISYONU"].Visible = false;
            //gList.Where(vi => vi.FieldName == "HUKUM_ANLAM").SingleOrDefault().Group();
            //if (dbV.R_HUKUM_TAKIP_RAPORs.Where(vi => vi.HUKUM_ANLAM == "RED" || vi.HUKUM_ANLAM == "KABUL").Count() <= 0)
            //    XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void MehilliAraKararlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            AraKararGenelTarafliRapor araKarar = new AraKararGenelTarafliRapor();
            gList = araKarar.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_ARA_KARAR_DAVA_GENEL_TARAFLI_RAPORs.Where(vi => vi.TIP_ID == 1 && vi.DURUM == "DERDEST");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "YERINE_GETIRME_TARIH").SingleOrDefault().Group();
            if (dbV.R_ARA_KARAR_DAVA_GENEL_TARAFLI_RAPORs.Where(vi => vi.TIP_ID == 1 && vi.DURUM == "DERDEST").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void MehilsizAraKararlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            AraKararGenelTarafliRapor araKarar = new AraKararGenelTarafliRapor();
            gList = araKarar.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_ARA_KARAR_DAVA_GENEL_TARAFLI_RAPORs.Where(vi => vi.TIP_ID == 0 && vi.DURUM == "DERDEST");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "YERINE_GETIRME_TARIH").SingleOrDefault().Group();
            if (dbV.R_ARA_KARAR_DAVA_GENEL_TARAFLI_RAPORs.Where(vi => vi.TIP_ID == 0 && vi.DURUM == "DERDEST").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void RaporCagir(string acilacakPencere, string uniqueID)
        {
            RaporCagirir(acilacakPencere, uniqueID);
            //kasa = new RaporYapilacakIsler();    Enver - Bu ikisi incelenecek
            //gList = kasa.GetGridColumns();
        }

        public void RehinliTakipler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.FORM_TIPI.Contains("50") || vi.FORM_TIPI.Contains("201"));
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.FORM_TIPI.Contains("50") || vi.FORM_TIPI.Contains("201")).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void TumAraKararlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            AraKararGenelTarafliRapor araKarar = new AraKararGenelTarafliRapor();
            gList = araKarar.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_ARA_KARAR_DAVA_GENEL_TARAFLI_RAPORs.Where(vi => vi.DURUM == "DERDEST");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "YERINE_GETIRME_TARIH").SingleOrDefault().Group();
            gList.Where(vi => vi.FieldName == "TIP_ID").SingleOrDefault().Group();
            if (dbV.R_ARA_KARAR_DAVA_GENEL_TARAFLI_RAPORs.Where(vi => vi.DURUM == "DERDEST").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void TumKararliDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            //mahkemeHukum tt = new mahkemeHukum();
            //gList = tt.GetGridColumns();
            //gridListeView.Columns.AddRange(gList);

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            gridListeControl.DataSource = cn.GetDataTable("SELECT * FROM R_HUKUM_TAKIP_RAPOR_YENI");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gridListeView.Columns["TARAF_CARI_ID"].Visible = false;
            gridListeView.Columns["DAVAPOZISYONU"].Visible = false;
            //if (dbV.R_HUKUM_TAKIP_RAPORs.Count() <= 0)
            //    XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void TumRehinliTakipler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.FORM_TIPI.Contains("151") || vi.FORM_TIPI.Contains("152") || vi.FORM_TIPI.Contains("50") || vi.FORM_TIPI.Contains("201"));
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.FORM_TIPI.Contains("151") || vi.FORM_TIPI.Contains("152") || vi.FORM_TIPI.Contains("50") || vi.FORM_TIPI.Contains("201")).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void TumTakipler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void TumTaksitlendirmeler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masterIcraBorcluTaahutGenelRapor icraborclu = new masterIcraBorcluTaahutGenelRapor();
            gList = icraborclu.GetGridColumns();

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_Master_IcraBorcluTaahhutGenel_Rapors;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_Master_IcraBorcluTaahhutGenel_Rapors.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void TumTaraflar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            //DavaPratikArama dp=new DavaPratikArama();
            DavaPratikRapor dp = new DavaPratikRapor();
            gList = dp.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_DAVA_PRATIK_ARAMA_RAPORs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        public void TumTemyizliDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            gridListeControl.DataSource = cn.GetDataTable("SELECT * FROM R_TEMYIZ_TAKIP_RAPOR_YENI");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();

            gridListeView.Columns["CARI_ID"].Visible = false;
        }

        private void AdliyesineGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_ISLERs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "ADLIYE").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_ISLERs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void AlacakUstündenAlinanVergiMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "ALACAK ÜSTÜNDEN ALINAN VERGİLER");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "ALACAK ÜSTÜNDEN ALINAN VERGİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void AleheBozulanlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            gridListeControl.DataSource = cn.GetDataTable("select * from dbo.R_TEMYIZ_TAKIP_RAPOR_YENI where DAVAPOZISYONU='DAVA EDEN' AND [Yer Anlam] in ('RED','AÇILMAMIŞ SAYILMA','DÜŞME') union all select * from dbo.R_TEMYIZ_TAKIP_RAPOR_YENI where DAVAPOZISYONU='DAVA EDİLEN' AND [Yer Anlam]='KABUL' and [Yük Anlam]='BOZMA'");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();

            gridListeView.Columns["CARI_ID"].Visible = false;
        }

        private void AleyheOnanlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            gridListeControl.DataSource = cn.GetDataTable("select * from dbo.R_TEMYIZ_TAKIP_RAPOR_YENI where DAVAPOZISYONU='DAVA EDEN' AND [Yer Anlam] in ('RED','AÇILMAMIŞ SAYILMA','DÜŞME') union all select * from dbo.R_TEMYIZ_TAKIP_RAPOR_YENI where DAVAPOZISYONU='DAVA EDİLEN' AND [Yer Anlam]='KABUL' and [Yük Anlam]='ONAMA'");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();

            gridListeView.Columns["CARI_ID"].Visible = false;
        }

        private void AltKategoriyeGoreMasraflar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "ALT_KATEGORI").SingleOrDefault().Group();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void AnaKategoriyeGoreMasraflar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "ANA_KATEGORI").SingleOrDefault().Group();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void ArasındakiTakiplersifiryirmibes(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();

            #region Hesap yapar

            //var tablom=dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.ToList();
            //frmHesapYapar hesapla = new frmHesapYapar();
            //hesapla.Show(tablom);

            #endregion Hesap yapar

            gList = bankali.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            decimal? d = Convert.ToDecimal(25);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.RISK_MIKTARI > 0 && vi.RISK_MIKTARI <= d);
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.RISK_MIKTARI > 0 && vi.RISK_MIKTARI <= d).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void ArasindakiTakiplerElliYuz(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            decimal? d = Convert.ToDecimal(50.000);
            decimal? s = Convert.ToDecimal(100.000);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.RISK_MIKTARI > d && vi.RISK_MIKTARI <= s);
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.RISK_MIKTARI > d && vi.RISK_MIKTARI <= s).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void ArasindakiTakipleryirmibeselli(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            decimal? d = Convert.ToDecimal(25.000);
            decimal? s = Convert.ToDecimal(50.000);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.RISK_MIKTARI > d && vi.RISK_MIKTARI <= s);
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.RISK_MIKTARI > d && vi.RISK_MIKTARI <= s).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void ArasindakiTakipleryuzucyuz(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            decimal? d = Convert.ToDecimal(100.000);
            decimal? s = Convert.ToDecimal(300.000);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.RISK_MIKTARI > d && vi.RISK_MIKTARI <= s);
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.RISK_MIKTARI > d && vi.RISK_MIKTARI <= s).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void AtanmamisIcraDosyalri(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor dp = new rBankalaiTaraflisorumluRapor();
            gList = dp.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.initOncekiAyarlar();
            gridListeControl.UniqueId = Guid.NewGuid().ToString();
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.DURUM == "EVRAK");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.DURUM == "EVRAK").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void AvansLarinBurolaraGoreDagilimi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 2);

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "SUBE_ADI").SingleOrDefault().Group();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 2).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void AvanslarinSorumluyaGoreDagilimi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 2);

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "SORUMLU").SingleOrDefault().Group();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 2).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void AvukatTahsilatları(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs;
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void AyinaGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_ISLERs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "BASLANGIC_TARIHI").SingleOrDefault().Group();
            gridListeView.Columns["BASLANGIC_TARIHI"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateMonth;
            if (dbV.R_RAPOR_YAPILACAK_ISLERs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void BankaTahsilatlari(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs;
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void BireyselKredilerAylik(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            DateTime Ayinbas = StartMonthDate();
            DateTime Ayinsonu = EndMonthDate();
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER");
            compGridDovizSummary1.Refresh();

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void BireyselKredilerAylikBakiyeli(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            DateTime Ayinbas = StartMonthDate();
            DateTime Ayinsonu = EndMonthDate();
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void BireyselKredilerHaftalik(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            DateTime BaslangicTrh = StartDate();
            DateTime BitisTrh = EndDate(BaslangicTrh);
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void BireyselKredilerHaftalikBakiyeli(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            DateTime BaslangicTrh = StartDate();
            DateTime BitisTrh = EndDate(BaslangicTrh);
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void BitenDosyalarınAnaparayaYapılanTahsilatları(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.DURUM != "DERDEST" || vii.DURUM != "EVRAK");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void BolgelereGore(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "BOLGE").SingleOrDefault().Group();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void BorcluOdemeMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "BORÇLU ÖDEME");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "BORÇLU ÖDEME").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void BuAyIcindekiDosyaSayisi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            DateTime dtilk = StartMonthDatePre();
            DateTime dtson = EndMonthDatePre();
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= dtilk && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= dtson);

            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "ID").SingleOrDefault().Group();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= dtilk && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= dtson).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void BuAyIcindekTahsilatVeDerkenarIleBitenDosyaSayisi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            DateTime dtilk = StartMonthDatePre();
            DateTime dtson = EndMonthDatePre();
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(t => t.DURUM.Contains("DERKENAR") || t.DURUM.Contains("ACİZ/DERKENAR") || t.DURUM.Contains("İNFAZ")).Where(vii => vii.KAPAMA_TARIHI <= dtilk && vii.KAPAMA_TARIHI >= dtson);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "DURUM").SingleOrDefault().Group();
            compGridDovizSummary1.Refresh();

            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(t => t.DURUM.Contains("DERKENAR") || t.DURUM.Contains("ACİZ/DERKENAR") || t.DURUM.Contains("İNFAZ")).Where(vii => vii.KAPAMA_TARIHI <= dtilk && vii.KAPAMA_TARIHI >= dtson).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunanmamıştır");
        }

        private void BuAyIcinideGelenDosyalarınAnaParaTop(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            DateTime dtilk = StartMonthDate();
            DateTime dtson = EndMonthDate();
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= dtilk && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= dtson);
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= dtilk && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= dtson).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void BuroGiderMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "BÜRO GİDERLERİ");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "BÜRO GİDERLERİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void CekDavalari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            IcraBirlesikDava birlesik = new IcraBirlesikDava();
            gList = birlesik.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_ICRA_BIRLESIK_DAVA_TAAHHUTs;
            if (dbV.R_RAPOR_ICRA_BIRLESIK_DAVA_TAAHHUTs.Count() <= 0)
                XtraMessageBox.Show("Kriterlere Uygun Veri Bulunamadı");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void CMUKVekaletUcretMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "CMUK VEKALET ÜCRETİ");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "CMUK VEKALET ÜCRETİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void DavaAlacakMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "DAVA ALACAKLARI");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "DAVA ALACAKLARI").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void DavaEdeninOdeyecegiVekaletUcretMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "DAVA EDENİN ÖDEYECEĞİ VEKALET ÜCRETİ");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "DAVA EDENİN ÖDEYECEĞİ VEKALET ÜCRETİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void DavaEdenLehineInkarTazminatMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "DAVA EDEN LEHİNE İNKAR TAZMİNATI");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "DAVA EDEN LEHİNE İNKAR TAZMİNATI").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void DavaEdileninOdeyecegiVekaletUcretMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "DAVA EDİLENİN ÖDEYECEĞİ VEKALET ÜCRETİ");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "DAVA EDİLENİN ÖDEYECEĞİ VEKALET ÜCRETİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void DavaEdilenLehineInkarTazminatMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "DAVA EDİLEN LEHİNE İNKAR TAZMİNATI");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "DAVA EDİLEN LEHİNE İNKAR TAZMİNATI").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void DegerlendirilmesiYapilanTumMallar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            //DavaPratikArama dp=new DavaPratikArama();
            RaporKiymetTakdiri dp = new RaporKiymetTakdiri();
            gList = dp.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_KIYMET_TAKDIRIs;
            if (dbV.R_RAPOR_KIYMET_TAKDIRIs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void DerdestTemyizKararListesi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            DurusmaDavaGenelRapor durusma = new DurusmaDavaGenelRapor();
            gList = durusma.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_DURUSMA_DAVA_GENEL_TARAFLI_RAPORs.Where(vi => vi.DURUM == "DERDEST" || vi.DURUM == "KARAR" || vi.DURUM == "TEMYİZ");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "DURUM").SingleOrDefault().Group();
            if (dbV.R_DURUSMA_DAVA_GENEL_TARAFLI_RAPORs.Where(vi => vi.DURUM == "DERDEST" || vi.DURUM == "KARAR" || vi.DURUM == "TEMYİZ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void DevamEdenDosylardanAnaFaizTahsilat(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.DURUM == "DERDEST");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.DURUM == "DERDEST").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void DevreTahsilatlari(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;

            //var trh = DateTime.(DateTime.Now.Year,DateTime.Now.Month);
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs;
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void DevreTahsilatlariIcmal(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;

            //var trh = DateTime.Now.DayOfWeek;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs;
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void DiğerMasraflar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "DİĞER");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "DİĞER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void DuzeltilerekAleyheOnananlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            gridListeControl.DataSource = cn.GetDataTable("select * from dbo.R_TEMYIZ_TAKIP_RAPOR_YENI where DAVAPOZISYONU='DAVA EDEN' AND [Yer Anlam] in ('RED','AÇILMAMIŞ SAYILMA','DÜŞME') union all select * from dbo.R_TEMYIZ_TAKIP_RAPOR_YENI where DAVAPOZISYONU='DAVA EDİLEN' AND [Yer Anlam]='KABUL' and [Temyiz Hüküm]='Düzelterek Onama'");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();

            gridListeView.Columns["CARI_ID"].Visible = false;
        }

        private void DuzeltilerekLeheOnananlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            TemyizTakipRapor temyiz = new TemyizTakipRapor();
            gList = temyiz.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TEMYIZ_TAKIP_RAPORs.Where(vi => vi.HUKUM_ANLAM == "ONAMA").Where(vii => vii.DAVA_EDEN_SIFAT == "DAVACI").Where(viii => viii.KARAR_TIP == "Düzelterek Onama");
            compGridDovizSummary1.Refresh();
            if (dbV.R_TEMYIZ_TAKIP_RAPORs.Where(vi => vi.HUKUM_ANLAM == "ONAMA").Where(vii => vii.DAVA_EDEN_SIFAT == "DAVACI").Where(viii => viii.KARAR_TIP == "Düzelterek Onama").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void EkSatisIstenecekDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            IcraSatisGenel satis = new IcraSatisGenel();
            gList = satis.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_Master_IcraSatisGenel_Rapors.Where(vii => vii.SATIS_KESINLESME_TARIHI != null);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_Master_IcraSatisGenel_Rapors.Where(vii => vii.SATIS_KESINLESME_TARIHI != null).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void ElektirikFaturasıMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "ELEKTRİK FATURASI");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "ELEKTRİK FATURASI").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void EvrakGiderleriMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "EVRAK GİDERLERİ");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "EVRAK GİDERLERİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void ExpertizRaporu(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RaporKiymetTakdiri dp = new RaporKiymetTakdiri();
            gList = dp.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_KIYMET_TAKDIRIs.Where(e => e.EKSPERTIZ_KAYDI_MI == true).ToList();
            if (dbV.R_RAPOR_KIYMET_TAKDIRIs.Where(e => e.EKSPERTIZ_KAYDI_MI == true).ToList().Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void FaizIndirimiIleKapatilanDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.PROTOKOL_FAIZ_ORANI > 0);
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.PROTOKOL_FAIZ_ORANI > 0).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void frmListeRapor_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridListeControl.GorunumuKaydet();
            this.Dispose();
        }

        private void frmListeRapor_Load(object sender, EventArgs e)
        {
        }

        private void GenelMudurlukMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vii => vii.SUBE_ADI == "MERKEZ");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "SUBE_ADI").SingleOrDefault().Group();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vii => vii.SUBE_ADI == "MERKEZ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void GununeGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_ISLERs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gridListeView.Columns["BASLANGIC_TARIHI"].DisplayFormat.FormatType = FormatType.DateTime;
            gridListeView.Columns["BASLANGIC_TARIHI"].DisplayFormat.FormatString = "dd:mm";
            gList.Where(vi => vi.FieldName == "BASLANGIC_TARIHI").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_ISLERs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void HaczedilenMallar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            HacizliMallarRapor haciz = new HacizliMallarRapor();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gList = haciz.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_HACIZLI_MALLAR_MASTER_CHILD_RAPORs;
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_HACIZLI_MALLAR_MASTER_CHILD_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void HarclarBakiyeMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR BAKİYE");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR BAKİYE").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void HarclarDavaMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR DAVA");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR DAVA").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void HarclarDavaNispiMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR DAVA (NİSPİ)");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR DAVA (NİSPİ)").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void HarclarGenelMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR GENEL");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR GENEL").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void HarclarGenelNispiMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR GENEL (NİSPİ)");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR GENEL (NİSPİ)").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void HarclarIcraMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR İCRA");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR İCRA").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void HarclarIcraNispiMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR İCRA (NİSPİ)");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR İCRA (NİSPİ)").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void HarclarIflasMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR İFLAS");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR İFLAS").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void HarclarIflasNispiMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR İFLAS (NİSPİ)");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR İFLAS (NİSPİ)").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void HarclarİadeMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR İADE");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "HARÇLAR İADE").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void IadeAlınanIcraDosyaları(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            DateTime dtilk = StartMonthDatePre();
            DateTime dtson = EndMonthDatePre();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.TAKIBIN_MUVEKKILE_IADE_TARIHI != null);

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "DURUM").SingleOrDefault().Group();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.TAKIBIN_MUVEKKILE_IADE_TARIHI != null).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void IcraTakipMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.MODUL_ID == 1);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.MODUL_ID == 1).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void IhlalEdilenOdemePlanlari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masterIcraBorcluTaahutGenelRapor icraborclu = new masterIcraBorcluTaahutGenelRapor();
            gList = icraborclu.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_Master_IcraBorcluTaahhutGenel_Rapors.Where(vii => vii.DURUM == "ZAMANINDA EKSİK" || vii.DURUM == "ZAMANINDAN SONRA EKSİK" || vii.DURUM == "ZAMANINDAN SONRA TAM" || vii.DURUM == "ZAMANINDA ÖDEME YOK").Where(vi => vi.RESMI_MI == Convert.ToByte(false));
            if (dbV.R_Master_IcraBorcluTaahhutGenel_Rapors.Where(vii => vii.DURUM == "ZAMANINDA EKSİK" || vii.DURUM == "ZAMANINDAN SONRA EKSİK" || vii.DURUM == "ZAMANINDAN SONRA TAM" || vii.DURUM == "ZAMANINDA ÖDEME YOK").Where(vi => vi.RESMI_MI == Convert.ToByte(false)).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void IhlalEdilenResmiTaahutler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masterIcraBorcluTaahutGenelRapor icraborclu = new masterIcraBorcluTaahutGenelRapor();
            gList = icraborclu.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_Master_IcraBorcluTaahhutGenel_Rapors.Where(vii => vii.DURUM == "ZAMANINDA EKSİK" || vii.DURUM == "ZAMANINDAN SONRA EKSİK" || vii.DURUM == "ZAMANINDAN SONRA TAM" || vii.DURUM == "ZAMANINDA ÖDEME YOK").Where(vi => vi.RESMI_MI == Convert.ToByte(true));
            if (dbV.R_Master_IcraBorcluTaahhutGenel_Rapors.Where(vii => vii.DURUM == "ZAMANINDA EKSİK" || vii.DURUM == "ZAMANINDAN SONRA EKSİK" || vii.DURUM == "ZAMANINDAN SONRA TAM" || vii.DURUM == "ZAMANINDA ÖDEME YOK").Where(vi => vi.RESMI_MI == Convert.ToByte(true)).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void IlamliTakipler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            DateTime dtilk = StartMonthDatePre();
            DateTime dtson = EndMonthDatePre();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        //2
        private void IstihkakDavalari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            HacizChildIstihkak hacizIstirak = new HacizChildIstihkak();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gList = hacizIstirak.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_HACIZ_CHILD_ISTIHKAKs;
            compGridDovizSummary1.Refresh();
            if (dbV.R_RAPOR_HACIZ_CHILD_ISTIHKAKs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void IstirakHacizleri(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            HacizChildIstirak hacizIstirak = new HacizChildIstirak();
            gList = hacizIstirak.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;

            gridListeControl.DataSource = dbV.R_RAPOR_HACIZ_CHILD_ISTIRAKs;
            if (dbV.R_RAPOR_HACIZ_CHILD_ISTIRAKs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void ItirazıDavalı(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            MasterIcraAlacakNedenAyrintili taahut = new MasterIcraAlacakNedenAyrintili();
            gList = taahut.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_Master_IcraAlacakNedenItirazDavaAyrintili_RAPORs;
            if (dbV.R_Master_IcraAlacakNedenItirazDavaAyrintili_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void ItirazınKaldırılmasıDavalari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            MasterIcraAlacakNedenAyrintili malBeyani = new MasterIcraAlacakNedenAyrintili();
            gList = malBeyani.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_Master_IcraAlacakNedenItirazDavaAyrintili_RAPORs.Where(vii => vii.ITIRAZ_SONUC == "REDDEDİLDİ");
            if (dbV.R_Master_IcraAlacakNedenItirazDavaAyrintili_RAPORs.Where(vii => vii.ITIRAZ_SONUC == "REDDEDİLDİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız KriterlereUygun Kayıt Bulunamamıştır.");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void ItirazinIptaliDavalari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            MasterIcraAlacakNedenAyrintili taahut = new MasterIcraAlacakNedenAyrintili();
            gList = taahut.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_Master_IcraAlacakNedenItirazDavaAyrintili_RAPORs;
            if (dbV.R_Master_IcraAlacakNedenItirazDavaAyrintili_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void ItirazKaldirilanDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            MasterIcraAlacakNedenAyrintili malBeyani = new MasterIcraAlacakNedenAyrintili();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gList = malBeyani.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_Master_IcraAlacakNedenItirazDavaAyrintili_RAPORs.Where(vii => vii.ITIRAZ_SONUC == "REDDEDİLDİ"); compGridDovizSummary1.Refresh();
            if (dbV.R_Master_IcraAlacakNedenItirazDavaAyrintili_RAPORs.Where(vii => vii.ITIRAZ_SONUC == "REDDEDİLDİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void KapamaTipineGoreBireyselAylik(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RapaoKrediOdemeDurumDetaylics OdemeDurum = new RapaoKrediOdemeDurumDetaylics();
            gList = OdemeDurum.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            DateTime Ayinbas = StartMonthDate();
            DateTime Ayinsonu = EndMonthDate();
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinsonu).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER");

            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "DURUM").SingleOrDefault().Group();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinsonu).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KapamaTipineGoreBireyselHaftalik(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RapaoKrediOdemeDurumDetaylics OdemeDurum = new RapaoKrediOdemeDurumDetaylics();
            gList = OdemeDurum.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            DateTime BaslangicTrh = StartDate();
            DateTime BitisTrh = EndDate(BaslangicTrh);
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BitisTrh).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER");

            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "DURUM").SingleOrDefault().Group();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BitisTrh).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KapamaTipineGoreKrediKartiAylik(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RapaoKrediOdemeDurumDetaylics OdemeDurum = new RapaoKrediOdemeDurumDetaylics();
            gList = OdemeDurum.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            DateTime Ayinbas = StartMonthDate();
            DateTime Ayinsonu = EndMonthDate();
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs;//.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinsonu);

            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "DURUM").SingleOrDefault().Group();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KapamaTipineGoreKrediKartiHaftalik(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RapaoKrediOdemeDurumDetaylics OdemeDurum = new RapaoKrediOdemeDurumDetaylics();
            gList = OdemeDurum.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            DateTime BaslangicTrh = StartDate();
            DateTime BitisTrh = EndDate(BaslangicTrh);
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BitisTrh);

            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "DURUM").SingleOrDefault().Group();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BitisTrh).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KapamaTipineGoreTicariAylik(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RapaoKrediOdemeDurumDetaylics OdemeDurum = new RapaoKrediOdemeDurumDetaylics();
            gList = OdemeDurum.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            DateTime Ayinbas = StartMonthDate();
            DateTime Ayinsonu = EndMonthDate();
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinsonu).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER");

            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "DURUM").SingleOrDefault().Group();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinsonu).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KapamaTipineGoreTicariHaftalik(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RapaoKrediOdemeDurumDetaylics OdemeDurum = new RapaoKrediOdemeDurumDetaylics();
            gList = OdemeDurum.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            DateTime BaslangicTrh = StartDate();
            DateTime BitisTrh = EndDate(BaslangicTrh);
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER");

            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "DURUM").SingleOrDefault().Group();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KapanmamisAvanslar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.INCELENDI == false);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.INCELENDI == false).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KasaHareketleriAylikKategorilereGore(string acilacakPencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_KASA_HAREKETLERIs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "TARIH").SingleOrDefault().Group();
            gList.Where(vi => vi.FieldName == "ANA_KATEGORI").SingleOrDefault().Group();
            gridListeView.Columns["TARIH"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateMonth;
            if (dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KasaHareketleriGunlukKategorilereGore(string acilacakPencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RaporKasaHareketleri kasa = new RaporKasaHareketleri();
            gList = kasa.GetGridColumns(acilacakPencere);
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_KASA_HAREKETLERIs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gridListeView.Columns["TARIH"].DisplayFormat.FormatType = FormatType.DateTime;
            gridListeView.Columns["TARIH"].DisplayFormat.FormatString = "dd:mm";

            // gridListeView.Columns["TARIH"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DisplayText;

            gList.Where(vi => vi.FieldName == "ANA_KATEGORI").SingleOrDefault().Group();
            gList.Where(vi => vi.FieldName == "TARIH").SingleOrDefault().Group();

            //if (dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs.Count() <= 0)
            //    XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KasaHareketleriHaftalikKategorilereGore(string acilacakPencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RaporKasaHareketleri kasa = new RaporKasaHareketleri();
            gList = kasa.GetGridColumns(acilacakPencere);
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_KASA_HAREKETLERIs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();

            //gridListeView.Columns["TARIH"].DisplayFormat.FormatType = FormatType.DateTime;
            //gridListeView.Columns["TARIH"].DisplayFormat.FormatString = "dddd";
            gridListeView.Columns["TARIH"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateRange;

            gList.Where(vi => vi.FieldName == "ANA_KATEGORI").SingleOrDefault().Group();
            gList.Where(vi => vi.FieldName == "TARIH").SingleOrDefault().Group();
            if (dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KasaHareketleriKategorilereGore(string acilacakPencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RaporKasaHareketleri kasa = new RaporKasaHareketleri();
            gList = kasa.GetGridColumns(acilacakPencere);
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_KASA_HAREKETLERIs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "ANA_KATEGORI").SingleOrDefault().Group();
            if (dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KasaHareketleriYillikKategorilereGore(string acilacakPencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RaporKasaHareketleri kasa = new RaporKasaHareketleri();
            gList = kasa.GetGridColumns(acilacakPencere);
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_KASA_HAREKETLERIs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "TARIH").SingleOrDefault().Group();
            gList.Where(vi => vi.FieldName == "ANA_KATEGORI").SingleOrDefault().Group();
            gridListeView.Columns["TARIH"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateYear;
            if (dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KategorisineGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_ISLERs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "ALT_KATEGORI").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_ISLERs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KiymetliEvrakTakibeKonulanlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            KiymetliEvrakTarafRapor kiymetli = new KiymetliEvrakTarafRapor();
            gList = kiymetli.GetGridColumns();

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_KIYMETLI_EVRAK_TARAFLI_RAPORs.Where(vii => vii.TAKIBE_KONULDU_MU == true);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_KIYMETLI_EVRAK_TARAFLI_RAPORs.Where(vii => vii.TAKIBE_KONULDU_MU == true).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KiymetliEvrakTakibeKonulmamis(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            KiymetliEvrakTarafRapor kiymetli = new KiymetliEvrakTarafRapor();
            gList = kiymetli.GetGridColumns();

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_KIYMETLI_EVRAK_TARAFLI_RAPORs.Where(vii => vii.TAKIBE_KONULDU_MU == false);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_KIYMETLI_EVRAK_TARAFLI_RAPORs.Where(vii => vii.EVRAK_VADE_TARIHI < DateTime.Now).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KiymetTakdiriRaporu(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            //DavaPratikArama dp=new DavaPratikArama();
            RaporKiymetTakdiri dp = new RaporKiymetTakdiri();
            gList = dp.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_KIYMET_TAKDIRIs.Where(e => e.EKSPERTIZ_KAYDI_MI == false);
            if (dbV.R_RAPOR_KIYMET_TAKDIRIs.Where(e => e.EKSPERTIZ_KAYDI_MI == false).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void KlasoreBagliDavaTakipleri(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RaporProjeDava kalsor = new RaporProjeDava();
            gList = kalsor.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);

            // compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_PROJE_DAVAs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "ADI").SingleOrDefault().Group();
            if (dbV.R_RAPOR_PROJE_DAVAs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KlasoreBagliIcraTakipleri(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RaporProjeIcra kalsor = new RaporProjeIcra();
            gList = kalsor.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);

            //compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_PROJE_ICRAs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "ADI").SingleOrDefault().Group();
            if (dbV.R_RAPOR_PROJE_ICRAs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KlasoreBagliSorusturmaTakipleri(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RaporProjeDava kalsor = new RaporProjeDava();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gList = kalsor.GetGridColumns();
            gridListeView.Columns.AddRange(gList);

            //compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_PROJE_SORUSTURMAs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "ADI").SingleOrDefault().Group();
            if (dbV.R_RAPOR_PROJE_SORUSTURMAs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");

            //compGridDovizSummary1.Refresh();
        }

        private void KlasorTakipleri(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RaporProjeGenel kalsor = new RaporProjeGenel();
            gList = kalsor.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);

            // compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_PROJE_GENELs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();

            gList.Where(vi => vi.FieldName == "ADI").SingleOrDefault().Group();
            if (dbV.R_RAPOR_PROJE_GENELs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KrediGrubunaGore(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "KREDI_GRUP").SingleOrDefault().Group();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void KrediKartiTakipleri(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void KrediKartlariAylik(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            DateTime Ayinbas = StartMonthDate();
            DateTime Ayinsonu = EndMonthDate();
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu);
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void KrediKartlariAylikBakiyeli(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            DateTime Ayinbas = StartMonthDate();
            DateTime Ayinsonu = EndMonthDate();
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu);
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void KrediKartlariHaftalik(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            DateTime BaslangicTrh = StartDate();
            DateTime BitisTrh = EndDate(BaslangicTrh);
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh);
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        //1
        private void KrediKartlariHaftalikBakiyeli(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            DateTime BaslangicTrh = StartDate();
            DateTime BitisTrh = EndDate(BaslangicTrh);
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh);
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void KrediTipineGore(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "KREDI_TIP").SingleOrDefault().Group();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void LeheBozulanlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            gridListeControl.DataSource = cn.GetDataTable("select * from dbo.R_TEMYIZ_TAKIP_RAPOR_YENI where DAVAPOZISYONU='DAVA EDEN' AND [Yer Anlam]='KABUL' union all select * from dbo.R_TEMYIZ_TAKIP_RAPOR_YENI where DAVAPOZISYONU='DAVA EDİLEN' AND [Yer Anlam]in ('RED','AÇILMAMIŞ SAYILMA','DÜŞME')  and [Yük Anlam]='BOZMA'");

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();

            gridListeView.Columns["CARI_ID"].Visible = false;
        }

        private void LeheOnanlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            gridListeControl.DataSource = cn.GetDataTable("select * from dbo.R_TEMYIZ_TAKIP_RAPOR_YENI where DAVAPOZISYONU='DAVA EDEN' AND [Yer Anlam]='KABUL' union all select * from dbo.R_TEMYIZ_TAKIP_RAPOR_YENI where DAVAPOZISYONU='DAVA EDİLEN' AND [Yer Anlam]in ('RED','AÇILMAMIŞ SAYILMA','DÜŞME')  and [Yük Anlam]='ONAMA'");

            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();

            gridListeView.Columns["CARI_ID"].Visible = false;
        }

        private void MahkemeMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "MAHKEME MASRAFLARI");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "MAHKEME MASRAFLARI").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void MalBeyanRaporu(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masterIcraBorcluMalBeyanAyrıintili malBeyan = new masterIcraBorcluMalBeyanAyrıintili();
            gList = malBeyan.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_Master_BorcluMalBeyanDavaAyrintili_Rapors;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_Master_BorcluMalBeyanDavaAyrintili_Rapors.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void MasraflarinBolgelereGoreDagilimi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "BOLGE").SingleOrDefault().Group();

            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void MasraflarinBurolaraGoreDagilimi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "SUBE_ADI").SingleOrDefault().Group();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void MasraflarinSorumlularinaGoreDagilimi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "SUBE_ADI").SingleOrDefault().Group();
            gList.Where(vi => vi.FieldName == "SORUMLU").SingleOrDefault().Group();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        //4
        private void MasraflarinSubelereGoreDagilimi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "SUBE").SingleOrDefault().Group();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void MemurYevmiyeMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "MEMUR YEVMİYE");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "MEMUR YEVMİYE").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void MiktarAraliginaGoreTakipler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            DateTime dtilk = StartMonthDatePre();
            DateTime dtson = EndMonthDatePre();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "DURUM").SingleOrDefault().Group();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void MunzamSenedOlarakAlinanlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            KiymetliEvrakTarafRapor kiymetli = new KiymetliEvrakTarafRapor();
            gList = kiymetli.GetGridColumns();

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_KIYMETLI_EVRAK_TARAFLI_RAPORs.Where(vii => vii.EVRAK_VADE_TARIHI < DateTime.Now && vii.MUNZAM_SENET_MI == true);
            if (dbV.R_KIYMETLI_EVRAK_TARAFLI_RAPORs.Where(vii => vii.EVRAK_VADE_TARIHI < DateTime.Now && vii.MUNZAM_SENET_MI == true).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void MuvekkileIadeAvanslari(string uniqueID)
        {
            //

            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rPersonelRaporu masraf = new rPersonelRaporu();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_PERSONEL_HESAP_DETAYLIs.Where(vi => vi.MUVEKKIL_MI == true && vi.ALT_KATEGORI == "AVANS İADESİ");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_PERSONEL_HESAP_DETAYLIs.Where(vi => vi.MUVEKKIL_MI == true && vi.ALT_KATEGORI == "AVANS İADESİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void MuvekkileOdenenMasraflar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "MÜVEKKİLE ÖDENEN");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "MÜVEKKİLE ÖDENEN").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void MuvekkilineGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_ISLERs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "IS_TARAF").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_ISLERs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void MuvekkilMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rPersonelRaporu masraf = new rPersonelRaporu();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_PERSONEL_HESAP_DETAYLIs.Where(vi => vi.MUVEKKIL_MI == true);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_PERSONEL_HESAP_DETAYLIs.Where(vi => vi.MUVEKKIL_MI == true).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void NakitTeminatlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            BirlesikTeminatBilgileri temyiz = new BirlesikTeminatBilgileri();
            gList = temyiz.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_BIRLESIK_TEMINAT_BILGILERIs.Where(vii => vii.TEMINAT_TUR == "NAKİT");
            if (dbV.R_RAPOR_BIRLESIK_TEMINAT_BILGILERIs.Where(vii => vii.TEMINAT_TUR == "NAKİT").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void OdemeDagilimliBireyselAylik(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RapaoKrediOdemeDurumDetaylics OdemeDurum = new RapaoKrediOdemeDurumDetaylics();
            gList = OdemeDurum.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            DateTime Ayinbas = StartMonthDate();
            DateTime Ayinsonu = EndMonthDate();
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        //3
        private void OdemeDagilimlibireyselHaftalik(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RapaoKrediOdemeDurumDetaylics OdemeDurum = new RapaoKrediOdemeDurumDetaylics();
            gList = OdemeDurum.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            DateTime BaslangicTrh = StartDate();
            DateTime BitisTrh = EndDate(BaslangicTrh);
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Where(vi => vi.KREDI_GRUP == "BİREYSEL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void OdemeDagilimliKrediKartiAylik(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RapaoKrediOdemeDurumDetaylics OdemeDurum = new RapaoKrediOdemeDurumDetaylics();
            gList = OdemeDurum.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            DateTime Ayinbas = StartMonthDate();
            DateTime Ayinsonu = EndMonthDate();
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu);

            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void OdemeDagilimliKrediKartiHaftalik(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RapaoKrediOdemeDurumDetaylics OdemeDurum = new RapaoKrediOdemeDurumDetaylics();
            gList = OdemeDurum.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            DateTime BaslangicTrh = StartDate();
            DateTime BitisTrh = EndDate(BaslangicTrh);
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh);
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void OdemeDagilimliTicariAylik(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RapaoKrediOdemeDurumDetaylics OdemeDurum = new RapaoKrediOdemeDurumDetaylics();
            gList = OdemeDurum.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            DateTime Ayinbas = StartMonthDate();
            DateTime Ayinsonu = EndMonthDate();
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER");

            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "DURUM").SingleOrDefault().Group();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void OdemeDagilimliTicariHaftalik(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RapaoKrediOdemeDurumDetaylics OdemeDurum = new RapaoKrediOdemeDurumDetaylics();
            gList = OdemeDurum.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            DateTime BaslangicTrh = StartDate();
            DateTime BitisTrh = EndDate(BaslangicTrh);
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUM_DETAYLIs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void OdemeMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "ÖDEME");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "ÖDEME").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void odemePlaninaBaglı(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masterIcraBorcluTaahutGenelRapor taahut = new masterIcraBorcluTaahutGenelRapor();
            gList = taahut.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_Master_IcraBorcluTaahhutGenel_Rapors.Where(vii => vii.RESMI_MI == 0);
            if (dbV.R_Master_IcraBorcluTaahhutGenel_Rapors.Where(vii => vii.RESMI_MI == 0).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterle Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void OncekiAydanDevredenAnaPara(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            DateTime dtilk = StartMonthDatePre();
            DateTime dtson = EndMonthDatePre();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= dtilk && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= dtson);

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "TAKIBIN_AVUKATA_INTIKAL_TARIHI").SingleOrDefault().Group();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= dtilk && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= dtson).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void OncekiAydanDevredenDosyaSayisi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            DateTime dtilk = StartMonthDatePre();
            DateTime dtson = EndMonthDatePre();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= dtilk && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= dtson);

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "ID").SingleOrDefault().Group();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= dtilk && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= dtson).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void OnOdemeCikanlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            BorcluOdemeBirlesik masraf = new BorcluOdemeBirlesik();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs.Where(vii => vii.ODEME_TARIHI != null);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs.Where(vii => vii.ODEME_TARIHI != null).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void PersonelAvanslari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rPersonelRaporu masraf = new rPersonelRaporu();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_PERSONEL_HESAP_DETAYLIs.Where(vi => vi.PERSONEL_MI == true);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_PERSONEL_HESAP_DETAYLIs.Where(vi => vi.PERSONEL_MI == true).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void PersonelIadeAvanslari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rPersonelRaporu masraf = new rPersonelRaporu();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_PERSONEL_HESAP_DETAYLIs.Where(vi => vi.PERSONEL_MI == true && vi.ALT_KATEGORI == "AVANS İADESİ");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_PERSONEL_HESAP_DETAYLIs.Where(vi => vi.PERSONEL_MI == true && vi.ALT_KATEGORI == "AVANS İADESİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void PersonelKasaHareketMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "PERSONEL KASA HAREKETİ");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "PERSONEL KASA HAREKETİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void PostaGiderMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "POSTA GİDERLERİ");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "POSTA GİDERLERİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void RaporCagirir(string acilacakPencere, string uniqueID)
        {
            switch (acilacakPencere)
            {
                #region gökhanın yaptıkları

                case "Liste_Dava_TaraGore":
                    Dava_TarafaGore();
                    break;

                case "Liste_Dava_SorumluyaGore":
                    Dava_SorumluyaGore();
                    break;

                case "Liste_Icra_SorumluyaGore":
                    Icra_SorumluyaGore();
                    break;

                case "Liste_Icra_TarafaGore":
                    Icra_TarafaGore();
                    break;

                #endregion gökhanın yaptıkları

                #region tamamlananlar

                case "Tüm Davalar":
                    TumTaraflar(uniqueID);

                    //AsamalarDava();
                    break;

                case "Tüm Dosyalar":
                    TumDosyalar(uniqueID);
                    break;

                case "Faal Davalar":
                    FaalDavalar(uniqueID);
                    break;

                case "Arşiv Davalar":
                case "Arşiv Dosyalar":
                    ArsivDavalar(uniqueID);
                    break;

                case "Dosya Kapama":
                case "Dosya Kapamalar":
                    DosyaKapama(uniqueID);
                    break;

                case "Tüm Arakararlar":
                    TumAraKararlar(uniqueID);
                    break;

                case "Tüm Tahsilatlar":
                    TumTahsilatlar(uniqueID);
                    break;

                case "Mehilli Arakararlar":
                    MehilliAraKararlar(uniqueID);
                    break;

                case "Kesin Mehilli Arakararlar":
                    KesinMehilliAraKararlar(uniqueID);
                    break;

                case "Mehilsiz Arakararlar":
                    MehilsizAraKararlar(uniqueID);
                    break;

                case "Dağıtımı Yapılmamış Dosyalar":
                    DagitimiYapilmamisDosyalar(uniqueID);
                    break;

                case "Tüm Kararlı Dosyalar":
                    TumKararliDosyalar(uniqueID);
                    break;

                case "Duruşma Listesi":
                    DurusmaListesi(uniqueID);
                    break;

                case "Derdest-Temyiz-Karar Listesi":
                    DerdestTemyizKararListesi(uniqueID);
                    break;

                case "Dava Eden Olup Aleyhe Karara Çıkanlar":
                    DavaEdenAleyheDosyalar(uniqueID);
                    break;

                case "Dava Edilen Olup Aleyhe Karara Çıkanlar":
                    DavaEdilenAleyheDosyalar(uniqueID);
                    break;

                case "Dava Eden Olup Lehe Karara Çıkanlar":
                    DavaEdenLeyheDosyalar(uniqueID);
                    break;

                case "Dava Edilen Olup Lehe Karara Çıkanlar":
                    DavaEdilenLeyheDosyalar(uniqueID);
                    break;

                case "Diğer Kararlar":
                    DigerKararlar(uniqueID);
                    break;

                case "Tüm Temyizli Dosyalar":
                    TumTemyizliDosyalar(uniqueID);
                    break;

                case "Keşif Listesi":
                    KesifListesi(uniqueID);
                    break;

                case "Faal Soruşturmalar":
                    FaalSorusturmalar(uniqueID);
                    break;

                case "Tüm Takipler":
                    TumTakipler(uniqueID);
                    break;

                case "Rehinli Takipler":
                    RehinliTakipler(uniqueID);
                    break;

                case "Tüm Rehinli Takipler":
                    TumRehinliTakipler(uniqueID);
                    break;

                case "İpotekli Takipler":
                    IpotekliTakipler(uniqueID);
                    break;

                case "İflaslı Takipler":
                    IflasliTakipler(uniqueID);
                    break;

                case "Atanmamış İcra Dosyaları":
                    AtanmamisIcraDosyalri(uniqueID);
                    break;

                case "İntikal Tarihine Göre İcra Dosyaları":
                    AvukataIntikalTarihi(uniqueID);
                    break;

                case "Icra Takiplerine Bağlı Tüm Davalar":
                    IcraTakibineBagliDavalar(uniqueID);
                    break;

                case "Icra Takiplerine Bağlı Ceza Davaları":
                    IcraTakibineBagliCezaDavalar(uniqueID);
                    break;

                case "Icra Takiplerine Bağlı Hukuk Davaları":
                    IcraTakibineBagliHukukDavalar(uniqueID);
                    break;

                case "Tüm Taksitlendirmeler":
                    TumTaksitlendirmeler(uniqueID);
                    break;

                case "Tüm İtirazlı Dosyalar":
                    TumItirazliDosyalar(uniqueID);
                    break;

                case "Haczedilen Mallar":
                    HaczedilenMallar(uniqueID);
                    break;

                case "Satış İstenen Dosyalar":
                    SatisiIstenenDosyalar(uniqueID);
                    break;

                case "Tüm Kıymeti Evraklar":
                    TumKiymetliEvraklar(uniqueID);
                    break;

                case "Tüm Masraflar":
                    TumMasraflar(uniqueID);
                    break;

                case "Önceki Aydan Devreden Ana Para Alacak":
                    OncekiAydanDevredenAnaPara(uniqueID);
                    break;

                case "İtirazı Kaldırılan Dosyalar":
                    ItirazKaldirilanDosyalar(uniqueID);
                    break;

                case "Bu Ay İçinde Gelen Dosyaların Anapara Toplamı":
                    BuAyIcinideGelenDosyalarınAnaParaTop(acilacakPencere, uniqueID);
                    break;

                case "Devam Eden Dosyalardan Anaparaya Yapılan Tahsilatlar":
                    DevamEdenDosylardanAnaFaizTahsilat(acilacakPencere, uniqueID);
                    break;

                case "Devam Eden Dosyalardan Faize Yapılan Tahsilatlar":
                    DevamEdenDosylardanAnaFaizTahsilat(acilacakPencere, uniqueID);
                    break;

                case "Biten Dosyalardan Anaparaya Yapılan Tahsilatlar":
                    BitenDosyalarınAnaparayaYapılanTahsilatları(acilacakPencere, uniqueID);
                    break;

                case "Biten Dosyalardan Faize Yapılan Tahsilatlar":
                    BitenDosyalarınAnaparayaYapılanTahsilatları(acilacakPencere, uniqueID);
                    break;

                case "Tüm Dosyalardan Anaparaya Yapılan Tahsilatlar":
                    TumDosyalardanAnapParaFaizTahsilat(acilacakPencere, uniqueID);
                    break;

                case "Tüm Dosyalardan Faize Yapılan Tahsilatlar":
                    TumDosyalardanAnapParaFaizTahsilat(acilacakPencere, uniqueID);
                    break;

                case "Toplam Tahsilat (Anapara ve Faize Yapılan Biten ve Devam Eden Dosyalardan)":
                    TumTahsilatlar(acilacakPencere, uniqueID);
                    break;

                case "Resmi Taahhütler Alınmış Dosyalar":
                    ResmiTaahhut(uniqueID);
                    break;

                case "Ödeme Planına Bağlı Dosyalar":
                    odemePlaninaBaglı(uniqueID);
                    break;

                case "Ticari Krediler Tüm Alacaklar İçin Dönemsel Rapor":
                    AvukatProRaporlar.Forms.frmDonemselRaporSihirbaz.ShowWizard(1);
                    break;

                case "Ticari Krediler Takipli Alacaklar İçin Dönemsel Rapor":
                    AvukatProRaporlar.Forms.frmDonemselRaporSihirbaz.ShowWizard(2);
                    break;

                case "Bireysel Krediler Takipli Alacaklar İçin Dönemsel Rapor":
                    AvukatProRaporlar.Forms.frmDonemselRaporSihirbaz.ShowWizard(3);
                    break;

                case "Bölgelere Göre":
                    BolgelereGore(uniqueID);
                    break;

                case "Şubelere Göre":
                    SubelereGore(uniqueID);
                    break;

                case "Kredi Grubuna Göre":
                    KrediGrubunaGore(uniqueID);
                    break;

                case "Alt Kredi Tipine Göre":
                    KrediTipineGore(uniqueID);
                    break;

                case "Kanuni Takibe İntikal Eden Ticari ve Kurumsal Krediler/Haftalık Rapor":
                    TicariVeKurumsalKredilerHaftalik(acilacakPencere, uniqueID);
                    break;

                case "Kanuni Takibe İntikal Eden Ticari ve Kurumsal Krediler/Aylık Rapor":
                    TicariVeKurumsalKredilerAylik(acilacakPencere, uniqueID);
                    break;

                case "Kanuni Takibe İntikal Eden Ticari ve Kurumsal Krediler/Bakiyeli Haftalık Rapor":
                    TicariVeKurumsalKredilerHaftalikBakiyeli(acilacakPencere, uniqueID);
                    break;

                case "Kanuni Takibe İntikal Eden Ticari ve Kurumsal Krediler/Bakiyeli Aylık Rapor":
                    TicariVeKurumsalKredilerAylikBakiyeli(acilacakPencere, uniqueID);
                    break;

                case "Kanuni Takibe İntikal Eden Bireysel Krediler/Haftalık Rapor":
                    BireyselKredilerHaftalik(acilacakPencere, uniqueID);
                    break;

                case "Kanuni Takibe İntikal Eden Bireysel Krediler/Aylık Rapor":
                    BireyselKredilerAylik(acilacakPencere, uniqueID);
                    break;

                case "Kanuni Takibe İntikal Eden Bireysel Krediler/Bakiyeli Haftalık Rapor":
                    BireyselKredilerHaftalikBakiyeli(acilacakPencere, uniqueID);
                    break;

                case "Kanuni Takibe İntikal Eden Bireysel Krediler/Bakiyeli Aylık Rapor":
                    BireyselKredilerAylikBakiyeli(acilacakPencere, uniqueID);
                    break;

                case "Kanuni Takibe İntikal Eden Kredi Kartları/Haftalık Rapor":
                    KrediKartlariHaftalik(acilacakPencere, uniqueID);
                    break;

                case "Kanuni Takibe İntikal Eden Kredi Kartları/Aylık Rapor":
                    KrediKartlariAylik(acilacakPencere, uniqueID);
                    break;

                case "Kanuni Takibe İntikal Eden Kredi Kartları/Bakiyeli Haftalık Rapor":
                    KrediKartlariHaftalikBakiyeli(acilacakPencere, uniqueID);
                    break;

                case "Kanuni Takibe İntikal Eden Kredi Kartları/Bakiyeli Aylık Rapor":
                    KrediKartlariAylikBakiyeli(acilacakPencere, uniqueID);
                    break;

                case "Ödeme Dağılımlı Takip Dosyaları Ticari ve Kurumsal Krediler Haftalık Rapor":
                    OdemeDagilimliTicariHaftalik(uniqueID);
                    break;

                case "Ödeme Dağılımlı Takip Dosyaları Ticari ve Kurumsal Krediler Aylık Rapor":
                    OdemeDagilimliTicariAylik(uniqueID);
                    break;

                case "Ödeme Dağılımlı Takip Dosyaları Bireysel Krediler İçin Haftalık Rapor":
                    OdemeDagilimlibireyselHaftalik(uniqueID);
                    break;

                case "Ödeme Dağılımlı Takip Dosyaları Bireysel Krediler İçin Aylık Rapor":
                    OdemeDagilimliBireyselAylik(uniqueID);
                    break;

                case "Ödeme Dağılımlı Takip Dosyaları Kredi Kartları İçin Haftalık Rapor":
                    OdemeDagilimliKrediKartiHaftalik(uniqueID);
                    break;

                case "Ödeme Dağılımlı Takip Dosyaları Kredi Kartları İçin Aylık Rapor":
                    OdemeDagilimliKrediKartiAylik(uniqueID);
                    break;

                case "Kapama Tipine Göre Ödeme Dağılımlı Takip Dosyaları Ticari ve Kurumsal Krediler Haftalık Rapor":
                    KapamaTipineGoreTicariHaftalik(uniqueID);
                    break;

                case "Kapama Tipine Göre Ödeme Dağılımlı Takip Dosyaları Ticari ve Kurumsal Krediler Aylık Rapor":
                    KapamaTipineGoreTicariAylik(uniqueID);
                    break;

                case "Kapama Tipine Göre Ödeme Dağılımlı Takip Dosyaları Bireysel Krediler İçin Haftalık Rapor":
                    KapamaTipineGoreBireyselHaftalik(uniqueID);
                    break;

                case "Kapama Tipine Göre Ödeme Dağılımlı Takip Dosyaları Bireysel Krediler İçin Aylık Rapor":
                    KapamaTipineGoreBireyselAylik(uniqueID);
                    break;

                case "Kapama Tipine Göre Ödeme Dağılımlı Takip Dosyaları Kredi Kartları İçin Haftalık Rapor":
                    KapamaTipineGoreKrediKartiHaftalik(uniqueID);
                    break;

                case "Kapama Tipine Göre Ödeme Dağılımlı Takip Dosyaları Kredi Kartları İçin Aylık Rapor":
                    KapamaTipineGoreKrediKartiAylik(uniqueID);
                    break;

                case "Takip Dökümü":
                    TakipDokumu(uniqueID);
                    break;

                case "0-25.000 Arasındaki Takipler":
                    ArasındakiTakiplersifiryirmibes(uniqueID);
                    break;

                case "25.000-50.000 Arasındaki Takipler":
                    ArasindakiTakipleryirmibeselli(uniqueID);
                    break;

                case "50.000-100.000 Arasındaki Takipler":
                    ArasindakiTakiplerElliYuz(uniqueID);
                    break;

                case "100.000-300.000 Arasındaki Takipler":
                    ArasindakiTakipleryuzucyuz(uniqueID);
                    break;

                case "300.000 ve Üzerindeki Takipler":
                    UzerindeucYuz(uniqueID);
                    break;

                case "İlamlı Takipler":
                    IlamliTakipler(uniqueID);
                    break;

                case "Avukat Tahsilatları":
                    AvukatTahsilatları(acilacakPencere, uniqueID);
                    break;

                case "Bankaca Yapılan Tahsilatlar":
                    BankaTahsilatlari(acilacakPencere, uniqueID);
                    break;

                case "Tüm İhlaller":
                    TumIhlaler(uniqueID);
                    break;

                case "İtirazı Davalı Dosyalar":
                    ItirazıDavalı(uniqueID);
                    break;

                case "İtirazın İptali Davaları":
                    ItirazinIptaliDavalari(uniqueID);
                    break;

                case "Devre Tahsilatları":
                    DevreTahsilatlari(acilacakPencere, uniqueID);
                    break;

                case "Devre Tahsilatları (icmal)":
                    DevreTahsilatlariIcmal(acilacakPencere, uniqueID);
                    break;

                case "İtirazın Kaldırılması Davaları":
                    ItirazınKaldırılmasıDavalari(uniqueID);
                    break;

                case "Faiz İndirimi İle Kapatılan Dosyalar":
                    FaizIndirimiIleKapatilanDosyalar(uniqueID);
                    break;

                case "Lehe Onananlar":
                    LeheOnanlar(uniqueID);
                    break;

                case "Miktar Aralığına Göre Takipler":
                    MiktarAraliginaGoreTakipler(uniqueID);
                    break;

                case "Kredi Kartı Takipleri":
                    KrediKartiTakipleri(uniqueID);
                    break;

                case "Tahsilatla Biten Dosya Sayısı":
                    TahsilatlaBitenDosyaSayisi(uniqueID);
                    break;

                case "Önceki Aydan Devraden Dosya Sayısı":
                    OncekiAydanDevredenDosyaSayisi(uniqueID);
                    break;

                case "Bu ay içinde gelen dosya sayısı":
                    BuAyIcindekiDosyaSayisi(uniqueID);
                    break;

                case "Bu ay İçinde Tahsilat ve Derkenar İle Biten Dosya Sayısı":
                    BuAyIcindekTahsilatVeDerkenarIleBitenDosyaSayisi(uniqueID);
                    break;

                case "Mal Beyanı Raporu":
                    MalBeyanRaporu(uniqueID);
                    break;

                case "Satışı Tamamlanan Dosyalar":
                    SatisiTamamLanmisDosyalar(uniqueID);
                    break;

                case "Satışı Kesinleşen Dosyalar":
                    SatisiKesinlesenDosyalar(uniqueID);
                    break;

                case "Ek Satış İstenecek Dosyalar":
                    EkSatisIstenecekDosyalar(uniqueID);
                    break;

                case "Masrafların Sözleşmeli Avukatlara Göre Dağılımı":
                    MasraflarinSorumlularinaGoreDagilimi(uniqueID);
                    break;

                case "Masrafların Sorumlulara Göre Dağılımı":
                    MasraflarinSorumlularinaGoreDagilimi(uniqueID);
                    break;

                case "Aleyhe Onananlar":
                    AleyheOnanlar(uniqueID);
                    break;

                case "İade Alınan İcra Dosyaları":
                    IadeAlınanIcraDosyaları(uniqueID);
                    break;

                case "Ön Ödeme Çıkanlar":
                    OnOdemeCikanlar(uniqueID);
                    break;

                case "Takibe Konulanlar":
                    KiymetliEvrakTakibeKonulanlar(uniqueID);
                    break;

                case "Takibe Konulmamış Evraklar":
                    KiymetliEvrakTakibeKonulmamis(uniqueID);
                    break;

                case "Vadesi Gelmemiş Evraklar":
                    VadesiGelmemisEvraklar(uniqueID);
                    break;

                case "Teminat Olarak Verilenler":
                    TeminatOlarakVerilenler(uniqueID);
                    break;

                case "Ana Kategoriye Göre Masraflar":
                    AnaKategoriyeGoreMasraflar(uniqueID);
                    break;

                case "Alt Kategorisine Göre Masraflar":
                    AltKategoriyeGoreMasraflar(uniqueID);
                    break;

                case "Masrafların Şubelere Göre Dağılımı":
                    MasraflarinSubelereGoreDagilimi(uniqueID);
                    break;

                case "Masrafların Bürolara Dağılımı":
                    MasraflarinBurolaraGoreDagilimi(uniqueID);
                    break;

                case "Genel Müdürlük Masrafları":
                    GenelMudurlukMasraflari(uniqueID);
                    break;

                case "Avansların Bürolara Göre Dağılımı":
                    AvansLarinBurolaraGoreDagilimi(uniqueID);
                    break;

                case "Avansların Sorumlulara Göre Dağılımı":
                    AvanslarinSorumluyaGoreDagilimi(uniqueID);
                    break;

                case "Kapanmamış Avanslar":
                    KapanmamisAvanslar(uniqueID);
                    break;

                case "Munzam(Fiktif,Finasman) Senedi Olarak Alınanlar":
                    MunzamSenedOlarakAlinanlar(uniqueID);
                    break;

                case "Lehe Bozulanlar":
                    LeheBozulanlar(uniqueID);
                    break;

                case "Aleyhe Bozulanlar":
                    AleheBozulanlar(uniqueID);
                    break;

                case "Düzeltilerek Aleyhe Onananlar":
                    DuzeltilerekAleyheOnananlar(uniqueID);
                    break;

                case "Düzeltilere Lehe Onananlar":
                    DuzeltilerekLeheOnananlar(uniqueID);
                    break;

                case "Tüm Teminatlar":
                    TumTeminatlar(uniqueID);
                    break;

                case "Nakit Teminatlar":
                    NakitTeminatlar(uniqueID);
                    break;

                case "Teminat Mektupları Listesi":
                    TeminatMektuplariListesi(uniqueID);
                    break;

                case "Tutuklama ve Gözaltı Listesi":
                    TutuklamaVeGozlati(uniqueID);
                    break;

                case "İhlal Edilen Resmi Taahhütler":
                    IhlalEdilenResmiTaahutler(uniqueID);
                    break;

                case "İhlal Edilen Ödeme Planları":
                    IhlalEdilenOdemePlanlari(uniqueID);
                    break;

                case "Çek Davaları":
                    CekDavalari(uniqueID);
                    break;

                case "İştirak Hacizleri	":
                    IstirakHacizleri(uniqueID);
                    break;

                case "İstihkak İddiaları":
                    IstihkakDavalari(uniqueID);
                    break;

                case "Klasör Takipleri":
                    KlasorTakipleri(uniqueID);
                    break;

                case "Klasöre Bağlı İcra Takipleri":
                    KlasoreBagliIcraTakipleri(uniqueID);
                    break;

                case "Klasöre Bağlı Dava Takipleri":
                    KlasoreBagliDavaTakipleri(uniqueID);
                    break;

                case "Klasöre Bağlı Soruşturma Takipler":
                    KlasoreBagliSorusturmaTakipleri(uniqueID);
                    break;

                case "Kısmen Aleyhe/Lehe Karara Çıkanlar":
                    KısmenAleyheLeheKararaCikanlar(uniqueID);
                    break;

                case "Satıştan Doğan Davalar":
                    SatistanDoganDavalar(uniqueID);
                    break;

                case "İstihkak Davaları":
                    IstihkakDavalari(uniqueID);
                    break;

                //kıymet takdiri
                case "Değerlendirilmesi Yapılan Tüm Mallar":
                    DegerlendirilmesiYapilanTumMallar(uniqueID);
                    break;

                //kıymet takdiri
                case "Ekspertiz Raporu":
                    ExpertizRaporu(uniqueID);
                    break;

                //kıymet takdiri
                case "Kıymet Takdiri Raporu":
                    KiymetTakdiriRaporu(uniqueID);
                    break;

                #endregion tamamlananlar

                #region Viewwi Sonra Yapılacaklar

                case "Süre Detay Sorumlusuna Göre":
                    SureDetaySorumlusunaGore(uniqueID);
                    break;

                case "Süre Detay Müvekkile Göre":
                    SureDetayMuvekklileGore(uniqueID);
                    break;

                case "Süre Detay Adliyesine Göre":
                    SureDetayAdliyesineGore(uniqueID);
                    break;

                case "Süre Detay Yerine Göre":
                    SureDetayYerineGore(uniqueID);
                    break;

                case "Süre Detay Kategorisine Göre":
                    SureDetayKategorisineGore(uniqueID);
                    break;

                case "Süre Detay Yılına Göre":
                    SureDetayYilinaGore(uniqueID);
                    break;

                case "Süre Detay Ayına Göre":
                    SureDetayAyinaGore(uniqueID);
                    break;

                case "Süre Detay Tarihine Göre(Özel)":
                    SureDetayTarihineGore(uniqueID);
                    break;

                case "Süre Detay Gününe Göre":
                    SureDetayGununeGore(uniqueID);
                    break;

                case "Ücretlendirilmiş Tamamlanmış İşler":
                    UcretlendirilmisTamalanmisIsler(uniqueID);
                    break;

                case "Ücretlendirilmiş Tamamlanmamış İşler":
                    UcretlendirilmisTamamlanmamisIsler(uniqueID);
                    break;

                case "Ücretlendirilmiş Adliyesine Göre İşler":
                    UcretlendirilmisAdliyesineGoreIsler(uniqueID);
                    break;

                case "Ücretlendirilmiş Yerine Göre İşler":
                    UcretlendirilmisYerineGoreIsler(uniqueID);
                    break;

                case "Ücretlendirilmiş Kategorisine Göre İşler":
                    UcretlendirilmisKategorineGoreIsler(uniqueID);
                    break;

                case "Ücretlendirilmiş Tarihine Göre İşler(Haftalık vs.)":
                    UcretlendirilmisTarihineGoreIsler(uniqueID);
                    break;

                case "Ücretlendirilmiş Gününe Göre İşler":
                    UcretlendirilmisGununeGoreIsler(uniqueID);
                    break;

                case "Ücretlendirilmiş Yılına Göre İşler":
                    UcretlendirilmisYilinaGoreIsler(uniqueID);
                    break;

                case "Ücretlendirilmiş Ayına Göre İşler":
                    UcretlendirilmisAyinaGoreIsler(uniqueID);
                    break;

                case "Ücretlendirilmiş Müvekkile Göre İşler":
                    UcretlendirilmisMuvekkileGoreIsler(uniqueID);
                    break;

                case "Tüm İşler":
                    TumIsler(uniqueID);
                    break;

                case "Tamamlanmış İşler":
                    TamamlanmisIsler(uniqueID);
                    break;

                case "Tamamlanmamış İşler":
                    TamamlanmamisIsler(uniqueID);
                    break;

                case "Adliyesine Göre İşler":
                    AdliyesineGoreIsler(uniqueID);
                    break;

                case "Yerine Göre İşler":
                    YerineGoreIsler(uniqueID);
                    break;

                case "Kategorisine Göre İşler":
                    KategorisineGoreIsler(uniqueID);
                    break;

                case "Yılına Göre İşler":
                    YilinaGoreIsler(uniqueID);
                    break;

                case "Ayına Göre İşler":
                    AyinaGoreIsler(uniqueID);
                    break;

                case "Tarihine Göre İşler(Haftalık vs.)":
                    TarihineGoreIsler(uniqueID);
                    break;

                case "Gününe Göre İşler":
                    GununeGoreIsler(uniqueID);
                    break;

                case "Müvekkile Göre İşler":
                    MuvekkilineGoreIsler(uniqueID);
                    break;

                case "Kasa Hareketleri (Kategorilere Göre)":
                    KasaHareketleriKategorilereGore(acilacakPencere, uniqueID);
                    break;

                case "Kasa (Günlük-Kategorilere Göre)":
                    KasaHareketleriGunlukKategorilereGore(acilacakPencere, uniqueID);
                    break;

                case "Kasa (Haftalık-Kategorilere Göre)":
                    KasaHareketleriHaftalikKategorilereGore(acilacakPencere, uniqueID);
                    break;

                case "Kasa (Aylık-Kategorilere)":
                    KasaHareketleriAylikKategorilereGore(acilacakPencere, uniqueID);
                    break;

                case "Kasa (Yıllık-Kategorilere Göre":
                    KasaHareketleriYillikKategorilereGore(acilacakPencere, uniqueID);
                    break;

                case "Serbest Meslek Makbuzu Kesilmemiş Dosyalar":
                    SerbestMeslekMakbuzKesilmemsiDosyalar(uniqueID);
                    break;

                case "Serbest Meslek Makbuzu Kesilmemiş İcra Takipleri":
                    SerbestMeslekMakbuzKesilmemsiIcraDosyalar(uniqueID);
                    break;

                case "Serbest Meslek Makbuzu Kesilmemiş Dava Dosyaları":
                    SerbestMeslekMakbuzKesilmemsiDavaDosyalar(uniqueID);
                    break;

                case "Serbest Meslek Makbuzu Kesilmemiş Soruşturma Dosyaları":
                    SerbestMeslekMakbuzKesilmemsiHazirlikDosyalar(uniqueID);
                    break;

                case "Tüm Avanslar":
                    TumAvanslar(uniqueID);
                    break;

                case "Müvekkil Avansları":
                    MuvekkilMasraflari(uniqueID);
                    break;

                case "Müvekkil İade Avansları":
                    MuvekkileIadeAvanslari(uniqueID);
                    break;

                case "Personel Masraf Avansları":
                    PersonelAvanslari(uniqueID);
                    break;

                case "Personel Maaş Avansları":
                    break;

                case "Personel İade Avansları":
                    PersonelIadeAvanslari(uniqueID);
                    break;

                case "Vekalet Ücret Avansları":
                    VekaletUcretAvanslari(uniqueID);
                    break;

                case "Teminat Avansları":
                    TeminatAvansLari(uniqueID);
                    break;

                case "İcra Takip Masrafları":
                    IcraTakipMasraflari(uniqueID);
                    break;

                case "Mahkeme Masrafları":
                    MahkemeMasraflari(uniqueID);
                    break;

                case "Borçlu Ödeme Masrafları":
                    BorcluOdemeMasraflari(uniqueID);
                    break;

                case "Büro Giderleri Masrafları":
                    BuroGiderMasraflari(uniqueID);
                    break;

                case "CMUK Vekalet Ücreti Masrafları":
                    CMUKVekaletUcretMasraflari(uniqueID);
                    break;

                case "Dava Alacak Masrafları":
                    DavaAlacakMasraflari(uniqueID);
                    break;

                case "Dava Eden Lehine İnkar Tazminat Masrafları":
                    DavaEdenLehineInkarTazminatMasraflari(uniqueID);
                    break;

                case "Dava Edenin Ödeyeceği Vekalet Ücret Masrafları":
                    DavaEdeninOdeyecegiVekaletUcretMasraflari(uniqueID);
                    break;

                case "Dava Edilen Lehine İnkar Tazminat Masrafları":
                    DavaEdilenLehineInkarTazminatMasraflari(uniqueID);
                    break;

                case "Dava Edilenin Ödeyeceği Vekalet Ücret Masrafları":
                    DavaEdileninOdeyecegiVekaletUcretMasraflari(uniqueID);
                    break;

                case "Diğer Masraflar":
                    DiğerMasraflar(uniqueID);
                    break;

                case "Elektirik Faturası Masrafları":
                    ElektirikFaturasıMasraflari(uniqueID);
                    break;

                case "Evrak Giderleri Masrafları":
                    EvrakGiderleriMasraflari(uniqueID);
                    break;

                case "Harçlar Bakiye Masraflar":
                    HarclarBakiyeMasraflari(uniqueID);
                    break;

                case "Harçlar Dava Masraflar":
                    HarclarDavaMasraflari(uniqueID);
                    break;

                case "Harçlar Dava(Nispi) Masraflar":
                    HarclarDavaNispiMasraflari(uniqueID);
                    break;

                case "Harçlar Genel Masraflar":
                    HarclarGenelMasraflari(uniqueID);
                    break;

                case "Harçlar Genel(Nispi) Masraflar":
                    HarclarGenelNispiMasraflari(uniqueID);
                    break;

                case "Harçlar İcra Masraflar":
                    HarclarIcraMasraflari(uniqueID);
                    break;

                case "Harçlar İcra(Nispi) Masraflar":
                    HarclarIcraNispiMasraflari(uniqueID);
                    break;

                case "Harçlar İflas Masraflar":
                    HarclarIflasMasraflari(uniqueID);
                    break;

                case "Harçlar İade Masraflar":
                    HarclarİadeMasraflari(uniqueID);
                    break;

                case "Harçlar İflas(Nispi) Masraflar":
                    HarclarIflasNispiMasraflari(uniqueID);
                    break;

                case "Memur Yevmiye Masraflar":
                    MemurYevmiyeMasraflari(uniqueID);
                    break;

                case "Müvekkile Ödenen Masraflar":
                    MuvekkileOdenenMasraflar(uniqueID);
                    break;

                case "Ödeme Masraflar":
                    OdemeMasraflari(uniqueID);
                    break;

                case "Personel Kasa Hareketi Masraflar":
                    PersonelKasaHareketMasraflari(uniqueID);
                    break;

                case "Posta Giderleri Masraflar":
                    PostaGiderMasraflari(uniqueID);
                    break;

                case "Sözleşme Vekalet Ücreti Masraflar":
                    SozlesmeVekaletUcretMasraflari(uniqueID);
                    break;

                case "Takip Alacaklari Masraflar":
                    TakipAlacakMasraflari(uniqueID);
                    break;

                case "Takip Edenin Ödeyeceği Vekalet Ücreti Masraflar":
                    TakipEdeninOdeyecegiVekaletUcretiMasraflari(uniqueID);
                    break;

                case "Tazminat Masrafları":
                    TazminatMasraflari(uniqueID);
                    break;

                case "Alacak Üstünden Alınan Vergi Masrafları":
                    AlacakUstündenAlinanVergiMasraflari(uniqueID);
                    break;

                case "Ücretlendirilmiş İş Masrafları":
                    UcretlendirilmisIsMasraflari(uniqueID);
                    break;

                case "Yeddiemin Maktu Ücreti Masrafları":
                    YeddieminMaktuUcretMasraflari(uniqueID);
                    break;

                case "Yeddiemin Nispi Ücreti Masrafları":
                    YeddieminNispiUcretMasraflari(uniqueID);
                    break;

                //soruşturma
                case "Kıymet Takdirine İtiraz Edilen Dosyalar":
                    XtraMessageBox.Show("Rapor Yapım Aşamasında");
                    break;

                //bak

                //cariden oluşturulacak
                case "Personel Raporu":
                    XtraMessageBox.Show("Rapor Yapım Aşamasında");
                    break;

                //silinecek
                case "Ön Kayıt İzleme Raporu":
                    XtraMessageBox.Show("Rapor Yapım Aşamasında");
                    break;

                //bak
                case "Devre Raporları (İcmal)":
                    XtraMessageBox.Show("Rapor Yapım Aşamasında");
                    break;

                //soruşturma
                case "Ceza Kararnamesi Çıkanlar":
                    XtraMessageBox.Show("Rapor Yapım Aşamasında");
                    break;

                //soruşturma
                case "Uzlaşılan Dosyalar":
                    XtraMessageBox.Show("Rapor Yapım Aşamasında");
                    break;

                //soruşturma
                case "Takipsizlik Kararı Verilenler":
                    XtraMessageBox.Show("Rapor Yapım Aşamasında");

                    //soruşturma
                    break;

                case "Takipsizliğe İtiraz Edilen Dosyalar":
                    XtraMessageBox.Show("Rapor Yapım Aşamasında");
                    break;

                //soruşturma
                case "Kamu Davası Açılan Dosyalar":
                    XtraMessageBox.Show("Rapor Yapım Aşamasında");
                    break;

                case "Masrafların Bölgelere Dağılımı":
                    MasraflarinBolgelereGoreDagilimi(uniqueID);
                    break;

                //bak yapılacak
                case "Serbest Meslek Makbuzu Listesi":
                    SerbestMeslekMakbuzListesi(uniqueID);
                    break;

                case "Serbest Meslek Makbuzu Listesi (Müvekkillere Göre)":
                    SerbestMeslekMakbuzListesiMuvekkilere(uniqueID);
                    break;

                case "Serbest Meslek Makbuzu Listesi (Yıllara Göre)":
                    SerbestMeslekMakbuzListesiYıllara(uniqueID);
                    break;

                case "Serbest Meslek Makbuzu Listesi (Yıllara ve Modüllere Göre)":
                    SerbestMeslekMakbuzListesiYıllaraModullere(uniqueID);
                    break;

                //aşamadan sonra
                case "Hacze Aşamasındaki Dosyalar":
                    XtraMessageBox.Show("Rapor Yapım Aşamasında");
                    break;

                default:
                    XtraMessageBox.Show("Rapor Yapım Aşamasında");
                    break;

                #endregion Viewwi Sonra Yapılacaklar
            }
        }

        private void ResmiTaahhut(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masterIcraBorcluTaahutGenelRapor taahut = new masterIcraBorcluTaahutGenelRapor();
            gList = taahut.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_Master_IcraBorcluTaahhutGenel_Rapors.Where(vii => vii.RESMI_MI == 1);
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_Master_IcraBorcluTaahhutGenel_Rapors.Where(vii => vii.RESMI_MI == 1).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void SatisiIstenenDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            IcraSatisGenel satis = new IcraSatisGenel();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gList = satis.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_Master_IcraSatisGenel_Rapors;
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_Master_IcraSatisGenel_Rapors.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void SatisiKesinlesenDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            IcraSatisGenel satis = new IcraSatisGenel();
            gList = satis.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_Master_IcraSatisGenel_Rapors.Where(vii => vii.SATIS_KESINLESME_TARIHI != null);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_Master_IcraSatisGenel_Rapors.Where(vii => vii.SATIS_KESINLESME_TARIHI != null).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SatisiTamamLanmisDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            IcraSatisGenel satis = new IcraSatisGenel();
            gList = satis.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_Master_IcraSatisGenel_Rapors.Where(vii => vii.SATIS_GERCEKLESME_TARIHI != null);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_Master_IcraSatisGenel_Rapors.Where(vii => vii.SATIS_GERCEKLESME_TARIHI != null).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SatistanDoganDavalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            //DavaPratikArama dp=new DavaPratikArama();
            DavaPratikRapor dp = new DavaPratikRapor();
            gList = dp.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(d => d.DAVA_TALEP == "SATIŞIN İPTAL" || d.DAVA_TALEP == "İHALENİN FESHİ TALEBİ");
            if (dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(d => d.DAVA_TALEP == "SATIŞIN İPTAL" || d.DAVA_TALEP == "İHALENİN FESHİ TALEBİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void SerbestMeslekMakbuzKesilmemsiDavaDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rSerbestMeslekMakbuzsuzDavaDosyalari masraf = new rSerbestMeslekMakbuzsuzDavaDosyalari();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_SMMSIZ_DAVA_DOSYALARI_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SerbestMeslekMakbuzKesilmemsiDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rSerbestMeslekMakbuzsuzDosyalar masraf = new rSerbestMeslekMakbuzsuzDosyalar();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_SMMSIZ_TUM_DOSYALAR_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SerbestMeslekMakbuzKesilmemsiHazirlikDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rSerbestMeslekMakbuzsuzHazirlikDosyalari masraf = new rSerbestMeslekMakbuzsuzHazirlikDosyalari();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_SMMSIZ_SORUSTURMA_DOSYALARI_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SerbestMeslekMakbuzKesilmemsiIcraDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rSerbestMeslekMakbuzsuzIcraDosyalari masraf = new rSerbestMeslekMakbuzsuzIcraDosyalari();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_SMMSIZ_ICRA_DOSYALARI_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SerbestMeslekMakbuzListesi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rSerbestMeslekMakbuzuRapor masraf = new rSerbestMeslekMakbuzuRapor();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SerbestMeslekMakbuzListesiMuvekkilere(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rSerbestMeslekMakbuzuRapor masraf = new rSerbestMeslekMakbuzuRapor();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "TAKIP_EDEN").SingleOrDefault().Group();
            if (dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SerbestMeslekMakbuzListesiYıllara(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rSerbestMeslekMakbuzuRapor masraf = new rSerbestMeslekMakbuzuRapor();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "FATURA_TARIH").SingleOrDefault().Group();
            if (dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SerbestMeslekMakbuzListesiYıllaraModullere(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rSerbestMeslekMakbuzuRapor masraf = new rSerbestMeslekMakbuzuRapor();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "FATURA_TARIH").SingleOrDefault().Group();
            gList.Where(vi => vi.FieldName == "FATURA_HEDEF_TIP").SingleOrDefault().Group();
            if (dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SozlesmeVekaletUcretMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "SÖZLEŞME VEKALET ÜCRETİ");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "SÖZLEŞME VEKALET ÜCRETİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SubelereGore(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "BANKA_SUBE").SingleOrDefault().Group();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void SureDetayAdliyesineGore(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.Clear();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "ADLIYE").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SureDetayAyinaGore(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.Clear();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "PLANLAMA_TARIHI").SingleOrDefault().Group();
            gridListeView.Columns["PLANLAMA_TARIHI"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateMonth;
            if (dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SureDetayGununeGore(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gList = kasa.GetGridColumns();
            gridListeView.Columns.Clear();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gridListeView.Columns["PLANLAMA_TARIHI"].DisplayFormat.FormatType = FormatType.DateTime;
            gridListeView.Columns["PLANLAMA_TARIHI"].DisplayFormat.FormatString = "dd:mm";
            gList.Where(vi => vi.FieldName == "PLANLAMA_TARIHI").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SureDetayKategorisineGore(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.Clear();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "KATEGORI").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SureDetayMuvekklileGore(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.Clear();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "IS_TARAF_ADI").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SureDetaySorumlusunaGore(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.Clear();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "SORUMLU").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SureDetayTarihineGore(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.Clear();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "PLANLAMA_TARIHI").SingleOrDefault().Group();
            gridListeView.Columns["PLANLAMA_TARIHI"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateRange;
            if (dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SureDetayYerineGore(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.Clear();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "YER").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void SureDetayYilinaGore(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.Clear();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "PLANLAMA_TARIHI").SingleOrDefault().Group();
            gridListeView.Columns["PLANLAMA_TARIHI"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateYear;
            if (dbV.R_RAPOR_YAPILACAK_IS_TAMAMLANMA_SURE_DETAYLIs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void TahsilatlaBitenDosyaSayisi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            DateTime dtilk = StartMonthDatePre();
            DateTime dtson = EndMonthDatePre();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "FOY_NO").FirstOrDefault().Group();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void TakipAlacakMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "TAKİP ALACAKLARI");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "TAKİP ALACAKLARI").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void TakipDokumu(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;

            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "FORM_TIPI").SingleOrDefault().Group();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void TakipEdeninOdeyecegiVekaletUcretiMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "TAKİP EDENİN ÖDEYECEĞİ VEKALET ÜCRETİ");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "TAKİP EDENİN ÖDEYECEĞİ VEKALET ÜCRETİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void TamamlanmamisIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_ISLERs.Where(vi => vi.IS_TARAF == "İşi Yapacak" && vi.BITIS_TARIHI == null);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "IS_TARAF").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_ISLERs.Where(vi => vi.IS_TARAF == "İşi Yapacak" && vi.BITIS_TARIHI == null).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void TamamlanmisIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_ISLERs.Where(vi => vi.IS_TARAF == "İşi Yapacak" && vi.BITIS_TARIHI != null);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "IS_TARAF").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_ISLERs.Where(vi => vi.IS_TARAF == "İşi Yapacak" && vi.BITIS_TARIHI != null).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void TarihineGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_ISLERs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "BASLANGIC_TARIHI").SingleOrDefault().Group();
            gridListeView.Columns["BASLANGIC_TARIHI"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateRange;
            if (dbV.R_RAPOR_YAPILACAK_ISLERs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void TazminatMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "TAZMİNATLAR");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "TAZMİNATLAR").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void TeminatAvansLari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 2 && vi.ALT_KATEGORI == "TEMİNAT AVANSI");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 2 && vi.ALT_KATEGORI == "TEMİNAT AVANSI").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void TeminatMektuplariListesi(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            BirlesikTeminatBilgileri temyiz = new BirlesikTeminatBilgileri();
            gList = temyiz.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_BIRLESIK_TEMINAT_BILGILERIs.Where(vii => vii.TEMINAT_TUR == "TEMİNAT MEKTUBU");
            if (dbV.R_RAPOR_BIRLESIK_TEMINAT_BILGILERIs.Where(vii => vii.TEMINAT_TUR == "TEMİNAT MEKTUBU").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void TeminatOlarakVerilenler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            KiymetliEvrakTarafRapor kiymetli = new KiymetliEvrakTarafRapor();
            gList = kiymetli.GetGridColumns();

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_KIYMETLI_EVRAK_TARAFLI_RAPORs.Where(vii => vii.EVRAK_VADE_TARIHI < DateTime.Now && vii.TEMINAT_MI == true);
            if (dbV.R_KIYMETLI_EVRAK_TARAFLI_RAPORs.Where(vii => vii.EVRAK_VADE_TARIHI < DateTime.Now && vii.TEMINAT_MI == true).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void TicariVeKurumsalKredilerAylik(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            DateTime Ayinbas = StartMonthDate();
            DateTime Ayinsonu = EndMonthDate();
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void TicariVeKurumsalKredilerAylikBakiyeli(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            DateTime Ayinbas = StartMonthDate();
            DateTime Ayinsonu = EndMonthDate();
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= Ayinbas && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= Ayinsonu).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void TicariVeKurumsalKredilerHaftalik(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            DateTime BaslangicTrh = StartDate();
            DateTime BitisTrh = EndDate(BaslangicTrh);
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void TicariVeKurumsalKredilerHaftalikBakiyeli(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            DateTime BaslangicTrh = StartDate();
            DateTime BitisTrh = EndDate(BaslangicTrh);
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Where(vii => vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI >= BaslangicTrh && vii.TAKIBIN_AVUKATA_INTIKAL_TARIHI <= BitisTrh).Where(vi => vi.KREDI_GRUP == "KURUMSAL KREDİLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void TumAvanslar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 2);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 2).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void TumDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            RaporIcraDavaBirlesik birlesik = new RaporIcraDavaBirlesik();
            gList = birlesik.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_TUM_TAKIPLER_ICRA_DAVAs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "DURUM").SingleOrDefault().Group();
            if (dbV.R_RAPOR_TUM_TAKIPLER_ICRA_DAVAs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void TumDosyalardanAnapParaFaizTahsilat(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs;
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void TumIhlaler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masterIcraBorcluTaahutGenelRapor icraborclu = new masterIcraBorcluTaahutGenelRapor();
            gList = icraborclu.GetGridColumns();

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_Master_IcraBorcluTaahhutGenel_Rapors.Where(vii => vii.DURUM == "ZAMANINDA EKSİK" || vii.DURUM == "ZAMANINDAN SONRA EKSİK" || vii.DURUM == "ZAMANINDAN SONRA TAM" || vii.DURUM == "ZAMANINDA ÖDEME YOK");
            if (dbV.R_Master_IcraBorcluTaahhutGenel_Rapors.Where(vii => vii.DURUM == "ZAMANINDA EKSİK" || vii.DURUM == "ZAMANINDAN SONRA EKSİK" || vii.DURUM == "ZAMANINDAN SONRA TAM" || vii.DURUM == "ZAMANINDA ÖDEME YOK").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void TumIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_ISLERs.Where(vi => vi.IS_TARAF == "İşi Yapacak");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "IS_TARAF").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_ISLERs.Where(vi => vi.IS_TARAF == "İşi Yapacak").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void TumItirazliDosyalar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            MasterIcraAlacakNedenAyrintili malBeyani = new MasterIcraAlacakNedenAyrintili();
            gList = malBeyani.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_Master_IcraAlacakNedenItirazDavaAyrintili_RAPORs;
            if (dbV.R_Master_IcraAlacakNedenItirazDavaAyrintili_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void TumKiymetliEvraklar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            KiymetliEvrakTarafRapor kiymetli = new KiymetliEvrakTarafRapor();
            gList = kiymetli.GetGridColumns();

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_KIYMETLI_EVRAK_TARAFLI_RAPORs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_KIYMETLI_EVRAK_TARAFLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void TumMasraflar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs;
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void TumTahsilatlar(string pencere, string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            ODEMEDURUMRAPOR OdemeDurum = new ODEMEDURUMRAPOR();
            gList = OdemeDurum.GetGridColumns(pencere);
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_KREDI_ODEME_DURUMs;
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_RAPOR_KREDI_ODEME_DURUMs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void TumTahsilatlar(string uniqueID)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor rapor = new rBankalaiTaraflisorumluRapor();
            gList = rapor.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
        }

        private void TumTeminatlar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            BirlesikTeminatBilgileri temyiz = new BirlesikTeminatBilgileri();
            gList = temyiz.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_BIRLESIK_TEMINAT_BILGILERIs;
            if (dbV.R_RAPOR_BIRLESIK_TEMINAT_BILGILERIs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void TutuklamaVeGozlati(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            TutuklanmaVeGozAlti tutuklama = new TutuklanmaVeGozAlti();
            gList = tutuklama.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            gridListeControl.DataSource = dbV.R_RAPOR_TUTUKLANMA_VE_GOZALTIs.Where(vii => vii.TUTUKLANMA_TARIHI != null);
            if (dbV.R_RAPOR_TUTUKLANMA_VE_GOZALTIs.Where(vii => vii.TUTUKLANMA_TARIHI != null).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
        }

        private void UcretlendirilmisAdliyesineGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "ADLIYE").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void UcretlendirilmisAyinaGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "PLANLAMA_TARIHI").SingleOrDefault().Group();
            gridListeView.Columns["PLANLAMA_TARIHI"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateMonth;
            if (dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void UcretlendirilmisGununeGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gridListeView.Columns["PLANLAMA_TARIHI"].DisplayFormat.FormatType = FormatType.DateTime;
            gridListeView.Columns["PLANLAMA_TARIHI"].DisplayFormat.FormatString = "dd:mm";
            gList.Where(vi => vi.FieldName == "PLANLAMA_TARIHI").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void UcretlendirilmisIsMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "ÜCRETLENDİRİLMİŞ İŞLER");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "ÜCRETLENDİRİLMİŞ İŞLER").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void UcretlendirilmisKategorineGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "ALT_KATEGORI").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void UcretlendirilmisMuvekkileGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "IS_TARAF").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void UcretlendirilmisTamalanmisIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)" && vi.PLANLAMA_TARIHI != null);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "IS_TARAF").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)" && vi.PLANLAMA_TARIHI != null).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void UcretlendirilmisTamamlanmamisIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)" && vi.PLANLAMA_TARIHI == null);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "IS_TARAF").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)" && vi.PLANLAMA_TARIHI == null).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void UcretlendirilmisTarihineGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "PLANLAMA_TARIHI").SingleOrDefault().Group();
            gridListeView.Columns["PLANLAMA_TARIHI"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateRange;
            if (dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void UcretlendirilmisYerineGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "YER").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void UcretlendirilmisYilinaGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "PLANLAMA_TARIHI").SingleOrDefault().Group();
            gridListeView.Columns["PLANLAMA_TARIHI"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateYear;
            if (dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void UzerindeucYuz(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            gList = bankali.GetGridColumns();
            compGridDovizSummary1.AltToplamlarAktifMi = false;
            gridListeView.Columns.AddRange(gList);
            compGridDovizSummary1.AltToplamlarAktifMi = true;
            decimal? d = Convert.ToDecimal(300.000);
            gridListeControl.DataSource = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.RISK_MIKTARI > d);
            compGridDovizSummary1.Refresh();
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vi => vi.RISK_MIKTARI > d).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void VadesiGelmemisEvraklar(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            KiymetliEvrakTarafRapor kiymetli = new KiymetliEvrakTarafRapor();
            gList = kiymetli.GetGridColumns();

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_KIYMETLI_EVRAK_TARAFLI_RAPORs.Where(vii => vii.EVRAK_VADE_TARIHI < DateTime.Now);
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_KIYMETLI_EVRAK_TARAFLI_RAPORs.Where(vii => vii.EVRAK_VADE_TARIHI < DateTime.Now).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void VekaletUcretAvanslari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 2 && vi.ALT_KATEGORI == "VEKALET ÜCRETİ AVANSI");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 2 && vi.ALT_KATEGORI == "VEKALET ÜCRETİ AVANSI").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void YeddieminMaktuUcretMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "YEDİEMİN MAKTU ÜCRETİ");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "YEDİEMİN MAKTU ÜCRETİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void YeddieminNispiUcretMasraflari(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            masrafAvansdetay masraf = new masrafAvansdetay();
            gList = masraf.GetGridColumns();
            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "YEDİEMİN NİSPİ  ÜCRETİ");
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            if (dbV.R_MASRAF_AVANS_DETAYLI_RAPORs.Where(vi => vi.MASRAF_AVANS_TIP == 1 && vi.ANA_KATEGORI == "YEDİEMİN NİSPİ  ÜCRETİ").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void YerineGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_ISLERs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "YER").SingleOrDefault().Group();
            if (dbV.R_RAPOR_YAPILACAK_ISLERs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void YilinaGoreIsler(string uniqueID)
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;

            gridListeView.Columns.AddRange(gList);
            gridListeControl.DataSource = dbV.R_RAPOR_YAPILACAK_ISLERs;
            gridListeControl.KullaniciAdi = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            gridListeControl.UniqueId = uniqueID;
            gridListeControl.initOncekiAyarlar();
            gList.Where(vi => vi.FieldName == "BASLANGIC_TARIHI").SingleOrDefault().Group();
            gridListeView.Columns["BASLANGIC_TARIHI"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateYear;
            if (dbV.R_RAPOR_YAPILACAK_ISLERs.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        #region ayhaftahesabı

        private DateTime EndDate(DateTime startDate)
        {
            startDate = startDate.AddDays(6);
            return new DateTime(startDate.Year, startDate.Month, startDate.Day, 23, 59, 59);
        }

        private DateTime EndMonthDate()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            //return new DateTime(DateTime.Now.Year, DateTime.Now.Month+1,1 ).AddDays(-1);
        }

        private DateTime EndMonthDatePre()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
        }

        private DateTime StartDate()
        {
            DayOfWeek day = DateTime.Now.DayOfWeek;
            DateTime startdate = DateTime.Now;
            if (day == DayOfWeek.Sunday)
                startdate = startdate.AddDays(-6);
            else
                startdate = startdate.AddDays((-1 * (int)day) + 1);
            return new DateTime(startdate.Year, startdate.Month, startdate.Day, 0, 0, 0);
        }

        private DateTime StartMonthDate()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private DateTime StartMonthDatePre()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
        }

        #endregion ayhaftahesabı

        #region Gökhanın Yaptıkları

        public void Dava_SorumluyaGore()
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            var lupBirimAdliye = lookUpVer("Adliye", "ID", "ADLIYE", db.TDI_KOD_ADLI_BIRIM_ADLIYEs);//
            var lupBirimBolum = lookUpVer("Bölüm", "ID", "BIRIM", db.TDI_KOD_ADLI_BIRIM_BOLUMs);//
            var lupBirimNo = lookUpVer("Birim No", "ID", "NO", db.TDI_KOD_ADLI_BIRIM_NOs);//
            var lupBirimGorev = lookUpVer("Görev", "ID", "GOREV", db.TDI_KOD_ADLI_BIRIM_GOREVs);//
            var lupDavaTalep = lookUpVer("Dava Talep", "ID", "DAVA_TALEP", db.TD_KOD_DAVA_TALEPs);//
            var lupFoyDurum = lookUpVer("Föy Durumu", "ID", "DURUM", db.TDI_KOD_FOY_DURUMs);//
            var lupSorumluAdi = lookUpVer("Sorumlu Adı", "ID", "AD", db.AV001_TDI_BIL_CARIs);// db.AV001_TDI_BIL_CARIs.Where(vi=>vi.PERSONEL_MI == true && vi.FIRMA_MI == false ).Select(vi=>new {vi.AD,vi.ID}));

            var colmFoyDurum = colmnVer("Durum", "ID_Foy_Durum", true, 1, lupFoyDurum);
            var colmDavaKonusu = colmnVer("Dava Konusu", "ID_Dava_Talep", true, 2, lupDavaTalep);
            var colmDavaT = colmnVer("Dava Tarihi", "Dava_T", true, 3, null);
            var colmBirimNo = colmnVer("No", "ID_Birim_No", true, 4, lupBirimNo);
            var colmBirimGorev = colmnVer("Görev", "ID_Birim_Gorev", true, 5, lupBirimGorev);
            var colmBirimDavaTipi = colmnVer("Dava Tipi", "ID_Birim_Bolum", true, 6, lupBirimBolum);
            var colmEsasNo = colmnVer("Esas No", "ESAS_NO", true, 7, null);
            var colmMahkemesi = colmnVer("Adliye", "ID_Birim_Adliye", true, 8, lupBirimAdliye);
            var colmDavaCevT = colmnVer("Davaya Çevirme Tarihi", "Davaya_Cev_T", true, 9, null);
            var colmDavaDosyaNo = colmnVer("Dosya No", "Dava_Dosya_No", true, 10, null);
            var colmReferans = colmnVer("Referans", "Referans", true, 11, null);
            var colmReferans2 = colmnVer("Referans 2", "Referans_2", true, 12, null);
            var colmReferans3 = colmnVer("Referans 3", "Referans_3", true, 13, null);
            var colmAvukataGelisT = colmnVer("Avukata Geliş Tarihi", "Avukata_Gelis_t", true, 14, null);
            var colmArsivT = colmnVer("Arsiv Tarihi", "Arsiv_T", true, 15, null);
            var colmFeragatT = colmnVer("Feragat Tarihi", "Feragat_T", true, 16, null);
            var colmIadeT = colmnVer("İade Tarihi", "Iade_T", true, 17, null);
            var colmMakbuzNo = colmnVer("Makbuz No", "MAKBUZ_NO", true, 18, null);
            var colmAciklama = colmnVer("Açıklama", "Aciklama", true, 19, null);
            var colmEvrakNo = colmnVer("Evrak No", "EVRAK_NO", true, 20, null);
            var colmSulhT = colmnVer("Sulh Tarihi", "Sulh_T", true, 21, null);
            var colmSorumluAdi = colmnVer("Sorumlu Adı", "Sorumlu_ID", true, 22, lupSorumluAdi);

            gridListeView.Columns.AddRange(new[] { colmFoyDurum,
                                                   colmDavaKonusu,colmDavaT,colmBirimNo,colmBirimGorev,colmEsasNo,colmMahkemesi ,colmDavaCevT,
                                                   colmDavaDosyaNo,colmReferans,colmReferans2,colmReferans3,colmAvukataGelisT,
                                                   colmArsivT,colmFeragatT,colmIadeT,colmMakbuzNo,colmAciklama,colmEvrakNo,
                                                   colmSulhT,colmSorumluAdi,colmBirimDavaTipi});

            gridListeControl.DataSource = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_SRMLULUs;
        }

        public void Dava_TarafaGore()
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            var lupBirimAdliye = lookUpVer("Adliye", "ID", "ADLIYE", db.TDI_KOD_ADLI_BIRIM_ADLIYEs);//
            var lupBirimBolum = lookUpVer("Bölüm", "ID", "BIRIM", db.TDI_KOD_ADLI_BIRIM_BOLUMs);//
            var lupBirimNo = lookUpVer("Birim No", "ID", "NO", db.TDI_KOD_ADLI_BIRIM_NOs);//
            var lupBirimGorev = lookUpVer("Görev", "ID", "GOREV", db.TDI_KOD_ADLI_BIRIM_GOREVs);//
            var lupDavaTalep = lookUpVer("Dava Talep", "ID", "DAVA_TALEP", db.TD_KOD_DAVA_TALEPs);//
            var lupFoyDurum = lookUpVer("Föy Durumu", "ID", "DURUM", db.TDI_KOD_FOY_DURUMs);//
            var lupFoyTarafAdi = lookUpVer("Tarafın Adı", "ID", "AD", db.AV001_TDI_BIL_CARIs);//
            var colmFoyDurum = colmnVer("Durum", "ID_Foy_Durum", true, 1, lupFoyDurum);
            var colmDavaKonusu = colmnVer("Dava Konusu", "ID_Dava_Talep", true, 2, lupDavaTalep);
            var colmDavaT = colmnVer("Dava Tarihi", "Dava_T", true, 3, null);
            var colmBirimNo = colmnVer("No", "ID_Birim_No", true, 4, lupBirimNo);
            var colmBirimGorev = colmnVer("Görev", "ID_Birim_Gorev", true, 5, lupBirimGorev);
            var colmBirimDavaTipi = colmnVer("Dava Tipi", "ID_Birim_Bolum", true, 6, lupBirimBolum);
            var colmEsasNo = colmnVer("Esas No", "ESAS_NO", true, 7, null);
            var colmMahkemesi = colmnVer("Adliye", "ID_Birim_Adliye", true, 8, lupBirimAdliye);
            var colmDavaCevT = colmnVer("Davaya Çevirme Tarihi", "Davaya_Cev_T", true, 9, null);
            var colmDavaDosyaNo = colmnVer("Dosya No", "Dava_Dosya_No", true, 10, null);
            var colmReferans = colmnVer("Referans", "Referans", true, 11, null);
            var colmReferans2 = colmnVer("Referans 2", "Referans_2", true, 12, null);
            var colmReferans3 = colmnVer("Referans 3", "Referans_3", true, 13, null);
            var colmAvukataGelisT = colmnVer("Avukata Geliş Tarihi", "Avukata_Gelis_t", true, 14, null);
            var colmArsivT = colmnVer("Arsiv Tarihi", "Arsiv_T", true, 15, null);
            var colmFeragatT = colmnVer("Feragat Tarihi", "Feragat_T", true, 16, null);
            var colmIadeT = colmnVer("İade Tarihi", "Iade_T", true, 17, null);
            var colmMakbuzNo = colmnVer("Makbuz No", "MAKBUZ_NO", true, 18, null);
            var colmAciklama = colmnVer("Açıklama", "Aciklama", true, 19, null);
            var colmEvrakNo = colmnVer("Evrak No", "EVRAK_NO", true, 20, null);
            var colmSulhT = colmnVer("Sulh Tarihi", "Sulh_T", true, 21, null);
            var colmTarafAdi = colmnVer("Taraf Adı", "CARI_ID", true, 22, lupFoyTarafAdi);

            gridListeView.Columns.AddRange(new[] { colmFoyDurum, colmDavaKonusu, colmDavaT, colmBirimNo, colmBirimGorev, colmEsasNo, colmMahkemesi, colmDavaCevT, colmDavaDosyaNo, colmReferans, colmReferans2, colmReferans3, colmAvukataGelisT, colmArsivT, colmFeragatT, colmIadeT, colmMakbuzNo, colmAciklama, colmEvrakNo, colmSulhT, colmTarafAdi, colmBirimDavaTipi });

            gridListeControl.DataSource = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_TARAFLIs;
        }

        public void Icra_SorumluyaGore()
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            var colmSorumlu_Adi = colmnVer("Sorumlu Adı", "Sorumlu_Adi", true, 1, null);
            var colmForm = colmnVer("Form", "Form", true, 2, null);
            var colmYeni = colmnVer("Yeni", "Yeni", true, 3, null);
            var colmDURUM = colmnVer("Durum", "DURUM", true, 4, null);
            var colmTakip_Konusu = colmnVer("Takip Konusu", "Takip_Konusu", true, 5, null);
            var colmTakip_T = colmnVer("Takip Tarihi", "Takip_T", true, 6, null);
            var colmMudurluk = colmnVer("Müdürlük", "Mudurluk", true, 7, null);
            var colmNO = colmnVer("No", "NO", true, 8, null);
            var colmGOREV = colmnVer("Görev", "GOREV", true, 9, null);
            var colmESAS_NO = colmnVer("Esas No", "ESAS_NO", true, 10, null);
            var colmIcra_Dosya_No = colmnVer("İcra Dosya No", "Icra_Dosya_No", true, 11, null);
            var colmACIKLAMA = colmnVer("Açıklama", "ACIKLAMA", true, 12, null);
            var colmReferans = colmnVer("Referans", "Referans", true, 13, null);
            var colmReferans_2 = colmnVer("Referans 2", "Referans_2", true, 14, null);
            var colmReferans_3 = colmnVer("Referans 3", "Referans_3", true, 15, null);
            var colmAvukata_Gelis_T = colmnVer("Avukata Gelis Tarihi", "Avukata_Gelis_T", true, 16, null);
            var colmArsiv_T = colmnVer("Arsiv Tarihi", "Arsiv_T", true, 17, null);
            var colmFeragat_T = colmnVer("Feragat Tarihi", "Feragat_T", true, 18, null);
            var colmTahliye_T = colmnVer("Tahliye Tarihi", "Tahliye_T", true, 19, null);
            var colmTeslim_T = colmnVer("Teslim Tarihi", "Teslim_T", true, 20, null);
            var colmAciz_T = colmnVer("Aciz Tarihi", "Aciz_T", true, 21, null);
            var colmInfaz_T = colmnVer("Infaz Tarihi", "Infaz_T", true, 22, null);
            var colmSulh_T = colmnVer("Sulh Tarihi", "Sulh_T", true, 23, null);

            gridListeView.Columns.AddRange(new[] { colmSorumlu_Adi, colmForm, colmYeni, colmDURUM ,
                                                   colmTakip_Konusu,colmTakip_T,colmMudurluk,colmNO,colmGOREV,colmESAS_NO,colmIcra_Dosya_No,
                                                   colmACIKLAMA,colmReferans,colmReferans_2,colmReferans_3,colmAvukata_Gelis_T,
                                                   colmArsiv_T,colmFeragat_T,colmTahliye_T,colmTeslim_T,colmAciz_T,colmInfaz_T,colmSulh_T
                                                 });

            gridListeControl.DataSource = db.R_AV001_ICRA_GNL_BLGLRI_HSPSIZ_SRMLULUs;
        }

        public void Icra_TarafaGore()
        {
            DBDataContext db = Program.db;
            AvukatProViewDataContext dbV = Program.dbV;
            var colmForm = colmnVer("Form", "Form", true, 23, null);
            var colmYeni = colmnVer("Yeni", "Yeni", true, 2, null);
            var colmDURUM = colmnVer("Durum", "DURUM", true, 3, null);
            var colmTakip_Konusu = colmnVer("Takip Konusu", "Takip_Konusu", true, 4, null);
            var colmTakip_T = colmnVer("Takip Tarihi", "Takip_T", true, 5, null);
            var colmMudurluk = colmnVer("Müdürlük", "Mudurluk", true, 6, null);
            var colmNO = colmnVer("No", "NO", true, 7, null);
            var colmGOREV = colmnVer("Görev", "GOREV", true, 8, null);
            var colmESAS_NO = colmnVer("Esas No", "ESAS_NO", true, 9, null);
            var colmIcra_Dosya_No = colmnVer("İcra Dosya No", "Icra_Dosya_No", true, 10, null);
            var colmACIKLAMA = colmnVer("Açıklama", "ACIKLAMA", true, 11, null);
            var colmReferans = colmnVer("Referans", "Referans", true, 12, null);
            var colmReferans_2 = colmnVer("Referans 2", "Referans_2", true, 13, null);
            var colmReferans_3 = colmnVer("Referans 3", "Referans_3", true, 14, null);
            var colmAvukata_Gelis_T = colmnVer("İntikal T", "Avukata_Gelis_T", true, 15, null);
            var colmArsiv_T = colmnVer("Arsiv T", "Arsiv_T", true, 16, null);
            var colmFeragat_T = colmnVer("Feragat T", "Feragat_T", true, 17, null);
            var colmTahliye_T = colmnVer("Tahliye T", "Tahliye_T", true, 18, null);
            var colmTeslim_T = colmnVer("Teslim T", "Teslim_T", true, 19, null);
            var colmAciz_T = colmnVer("Aciz T", "Aciz_T", true, 20, null);
            var colmInfaz_T = colmnVer("İnfaz T", "Infaz_T", true, 21, null);
            var colmSulh_T = colmnVer("Sulh T", "Sulh_T", true, 22, null);
            var colmTarafinAdi = colmnVer("Tarafın Adı", "TarafinAdi", true, 1, null);

            gridListeView.Columns.AddRange(new[] { colmForm, colmYeni, colmDURUM, colmTakip_Konusu,
                                                   colmTakip_T, colmMudurluk, colmNO, colmGOREV, colmESAS_NO, colmIcra_Dosya_No,
                                                   colmACIKLAMA, colmReferans, colmReferans_2, colmReferans_3, colmAvukata_Gelis_T,
                                                   colmArsiv_T, colmFeragat_T, colmTahliye_T, colmTeslim_T, colmAciz_T, colmInfaz_T,
                                                   colmSulh_T, colmTarafinAdi});

            gridListeControl.DataSource = db.R_AV001_ICRA_GNL_BLGLRI_HSPSIZ_TARAFLIs;
        }

        #endregion Gökhanın Yaptıkları

        #region Methodlarim

        private static DevExpress.XtraGrid.Columns.GridColumn colmnVer(string columnCaption, string columnFieldName, bool colmnVisible, int visibleIndex, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueLookUpEdit)
        {
            DevExpress.XtraGrid.Columns.GridColumn colFORM_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            colFORM_TIP_ID.Caption = columnCaption;
            colFORM_TIP_ID.ColumnEdit = rlueLookUpEdit;
            colFORM_TIP_ID.FieldName = columnFieldName;

            //colFORM_TIP_ID.Name = "colFORM_TIP_ID";
            colFORM_TIP_ID.Visible = colmnVisible;
            colFORM_TIP_ID.VisibleIndex = visibleIndex;
            return colFORM_TIP_ID;
        }

        private static DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUpVer(string lookDisplayCaption, string lookDisplayValue, string lookDisplayMamber, object dataSource)
        {
            var rlueTakipTalep = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

            rlueTakipTalep.AutoHeight = false;
            rlueTakipTalep.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(lookDisplayMamber, lookDisplayCaption, 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near));
            rlueTakipTalep.DataSource = dataSource;
            rlueTakipTalep.DisplayMember = lookDisplayMamber;
            //rlueTakipTalep.Name = "rlueTakipTalep";
            rlueTakipTalep.ValueMember = lookDisplayValue;

            return rlueTakipTalep;
        }

        #endregion Methodlarim

        #region iAVPForms Members

        public void ExportMail()
        {
            SaveFileTools.Exporter(gridListeControl, Enums.KayitTipi.Html);
        }

        public void ExportPrint()
        {
            SaveFileTools.Exporter(gridListeControl, Enums.KayitTipi.Print);
        }

        public void ExportXls()
        {
            SaveFileTools.Exporter(gridListeControl, Enums.KayitTipi.Excel);
        }

        void iAVPForms.ExportPDF()
        {
            SaveFileTools.Exporter(gridListeControl, Enums.KayitTipi.Pdf);
        }

        #endregion iAVPForms Members
    }
}