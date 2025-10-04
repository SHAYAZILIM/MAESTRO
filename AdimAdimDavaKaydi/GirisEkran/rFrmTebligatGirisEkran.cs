using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatPro.Services.Implementations;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmTebligatGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        #region Global Properties

        private int? _altTur;
        private int? _konu;
        private AvukatProLib.Extras.Modul? _modul;
        private int? _muhatapCariID;
        private DataTable _MyDataSource;
        private DateTime? _postalamaTarihi;
        private BackgroundWorker bckWorker = new BackgroundWorker();

        [Browsable(false)]
        public DataTable MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                ucTebligatMuhatapForGiris1.MyDataSource = value;
            }
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_TEBLIGAT> MyTebligat { get; set; }

        #endregion Global Properties

        public rFrmTebligatGirisEkran()
        {
            this.Load += rFrmTebligatGirisEkran_Load;
        }

        public void AramalariTemizleGenel()
        {
            //FormlariTemizle(panelControl10.Controls);
            ucTebligatMuhatapForGiris1.MyDataSource = MyDataSource;
            ucTebligatMuhatapForGiris1.FilitreleriTemizle();
            rgZamanDilimi.SelectedIndex = 6;
            //this.ucBelgeIzlemeDolasimDock1.MyDataSource = null;
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Editor_Click += barButtonItem22_ItemClick;
            this.Button_Excel_Click += barButtonItem25_ItemClick;
            this.Button_Outlook_Click += barButtonItem24_ItemClick;
            this.Button_PDF_Click += barButtonItem26_ItemClick;
            this.Button_Word_Click += barButtonItem23_ItemClick;
            this.Button_Kaydet_Click += barButtonItem3_ItemClick;

        }

        #region Events

        private void Events()
        {
            lueHedefTip.EditValueChanged += lueHedefTip_EditValueChanged;
            lueMuhCari.EditValueChanged += lueMuhCari_EditValueChanged;
            lueTAltTur.EditValueChanged += lueTAltTur_EditValueChanged;
            lueTKonu.EditValueChanged += lueTKonu_EditValueChanged;
            dtPostalamaTarihi.EditValueChanged += dtPostalamaTarihi_EditValueChanged;
            //txtRefNo.TextChanged += txtRefNo_TextChanged;
        }

        private void InitData()
        {
            lueMuhCari.Properties.NullText = "Seç";
            lueTAltTur.Properties.NullText = "Seç";
            lueTKonu.Properties.NullText = "Seç";
            lueHedefTip.Properties.NullText = "Seç";
            DevExpressService.ModulDoldur(lueHedefTip, null);

            lueMuhCari.Enter += delegate { AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueMuhCari, null); };
            //BelgeUtil.Inits.TebligatHedefTipGetir(lueHedefTip);
            //lueMuhCari.Enter += BelgeUtil.Inits.perCariGetir_Enter;
            lueTAltTur.Enter += BelgeUtil.Inits.TebligatAltTurGetir_Enter;
            lueTKonu.Enter += BelgeUtil.Inits.TebligatkonuGetir_Enter;
            //BelgeUtil.Inits.FoyDurumGetir(lueDurum);
        }

        #endregion Events

        #region AramaEvent

        private void dtPostalamaTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtPostalamaTarihi.EditValue != null)
                _postalamaTarihi = (DateTime?)dtPostalamaTarihi.EditValue;
            else
                _postalamaTarihi = null;
        }

        private void lueHedefTip_EditValueChanged(object sender, EventArgs e)
        {
            if (lueHedefTip.EditValue != null)
                _modul = (AvukatProLib.Extras.Modul?)Convert.ToInt32(lueHedefTip.EditValue);
            else
                _modul = null;

            if (lueHedefTip.Text == "Icra")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Icra, false);

            else if (lueHedefTip.Text == "Dava")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Dava, false);

            else if (lueHedefTip.Text == "Soruþturma")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sorusturma, false);

            else if (lueHedefTip.Text == "Sözleþme")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sozlesme, false);
        }

        private void lueMuhCari_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMuhCari.EditValue != null)
                _muhatapCariID = (int?)lueMuhCari.EditValue;
            else
                _muhatapCariID = null;
        }

        private void lueTAltTur_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTAltTur.EditValue != null)
                _altTur = (int?)lueTAltTur.EditValue;
            else
                _altTur = null;
        }

        private void lueTKonu_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTKonu.EditValue != null)
                _konu = (int?)lueTKonu.EditValue;
            else
                _konu = null;
        }

        //private void txtRefNo_TextChanged(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtRefNo.Text))
        //        _refNo = txtRefNo.Text;
        //    else
        //        _refNo = null;
        //}

        #endregion AramaEvent

        public void TebligatKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine
                    + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    MyDataSource = ucTebligatMuhatapForGiris1.MyDataSource;
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen)
                        tran.Rollback();
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void barButtonItem22_ItemClick(object sender, EventArgs e)
        {
            frmEditor frmEdit = new frmEditor();
            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
        }

        private void barButtonItem23_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.doc);
        }

        private void barButtonItem24_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pst);
        }

        private void barButtonItem25_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.xls);
        }

        private void barButtonItem26_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf);
        }

        private void barButtonItem3_ItemClick(object sender, EventArgs e)
        {
            TebligatKaydet();
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = GelismisAramaSorgula();
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (e.Result is List<AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity>)
            //{
            InitData();
            ucTebligatMuhatapForGiris1.MyDataSource = e.Result as DataTable;
            btnSorgula.Enabled = true;
            //}
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            btnSorgula.Enabled = false;

            if (chkTebligatGüncelesinMi.Checked == true)
            {
                TebligatlariSorgula();
            }

            if (!bckWorker.IsBusy)
            {
                bckWorker.RunWorkerAsync();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            AramalariTemizleGenel();
            lueDurum.EditValue = null;
        }

        private DataTable GelismisAramaSorgula()
        {
            AvukatPro.Services.Messaging.GetTebligatByFiltreRequest request = new AvukatPro.Services.Messaging.GetTebligatByFiltreRequest();

            if (DataRepository.TDIE_BIL_KULLANICI_SUBELERIProvider.GetByID(AvukatProLib.Kimlik.SubeKodu).SUBE_ADI != "MERKEZ")
                request.KullaniciSubeID = AvukatProLib.Kimlik.SubeKodu;
            else
                request.KullaniciSubeID = null;

            request.Modul = _modul;
            if (lueDosya.EditValue != null)
                request.DosyaID = (int)lueDosya.EditValue;

            request.Barkod = txtBarkod.Text;

            if (lueTKonu.EditValue != null)
                request.KonuID = (int)lueTKonu.EditValue;

            if (lueMuhCari.EditValue != null)
                request.MuhatapID = (int)lueMuhCari.EditValue;

            if (dtPostalamaTarihi.DateTime != null)
                request.PostalamaTarihi = dtPostalamaTarihi.DateTime;
            //request.ReferansNo = ;
            if (lueTAltTur.EditValue != null)
                request.TebligatAltTur = (int)lueTAltTur.EditValue;

            //if (lueDosya.EditValue != null)
            //    request.du = (int)lueDosya.EditValue;

            return AvukatPro.Services.Implementations.DosyaService.GetAllTebligatByFiltre(request, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString());
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //if (e.RowHandle != null)
            //{
            //    if (MyDataSource != null && MyDataSource.Rows.Count > 0)
            //    {
            //        AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity RowDataView = MyDataSource[e.RowHandle];

            //        List<AvukatProLib.Arama.per_BELGE_ID_FROM_TEBLIGAT> belgeIdList = BelgeUtil.Inits.context.per_BELGE_ID_FROM_TEBLIGATs.Where(item => item.TEBLIGAT_ID == RowDataView.Id).ToList();
            //        List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> belgeList = new List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE>();
            //        belgeIdList.ForEach(item => belgeList.Add(BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.Single(v => v.ID == item.BELGE_ID)));

            //        //this.ucBelgeIzlemeDolasimDock1.aramadanmý = true;
            //        //this.ucBelgeIzlemeDolasimDock1.MyDataSource = belgeList;
            //    }
            //}
        }

        private void gvTebligat_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (ucTebligatMuhatapForGiris1.gvTebligat.SelectedRowsCount > 0)
            //{
            //    List<int> idler = AvukatPro.Services.Implementations.DosyaService.GetAllBelgeIDsByTebligatID((int)ucTebligatMuhatapForGiris1.gvTebligat.GetRowCellValue(e.FocusedRowHandle, "Id"));
            //    if (idler.Count > 0)
            //        ucBelgeIzleme1.BelgeIds = idler;
            //}
        }

        private void rFrmTebligatGirisEkran_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            InitializeComponent();
            InitializeEvents();
            Events();
            InitData();
            ucTebligatMuhatapForGiris1.gvTebligat.RowClick += gridView1_RowClick;

            //this.ucBelgeIzlemeDolasimDock1.MyDataSource = new List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE>();
            this.Enabled = true;
            bckWorker.DoWork += bckWorker_DoWork;
            bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
            ucTebligatMuhatapForGiris1.KayitSilindi += ucTebligatMuhatapForGiris1_KayitSilindi;
            ucTebligatMuhatapForGiris1.gvTebligat.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gvTebligat_FocusedRowChanged);
            ucTebligatMuhatapForGiris1.gvTebligat.DoubleClick += new EventHandler(gvTebligat_DoubleClick);

            BelgeUtil.Inits.FoyDurumGetir(lueDurum);
            //lueDurum.EditValue = 2;
        }

        private void TebligatlariSorgula()
        {
            #region DENEME
            //string _kullanici = "avukat";//"PttWs";
            //string _sifre = "avukat@123"; //"YazDes*1840";
            //CompInfo smtpInfo = (CompInfo.CompInfoListGetir(Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName))[0];
            //SqlConnection cnn = new SqlConnection(smtpInfo.ConStr);
            //cnn.Open();

            //List<AV001_TDI_BIL_TEBLIGAT_MUHATAP> myAV001_TDI_BIL_TEBLIGAT_MUHATAPs = new List<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
            //myAV001_TDI_BIL_TEBLIGAT_MUHATAPs = DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.GetAll().ToList();
            //foreach (AV001_TDI_BIL_TEBLIGAT_MUHATAP item in myAV001_TDI_BIL_TEBLIGAT_MUHATAPs)
            //{
            //    if (item.PTT_BARKOD_NO.ToString() != "" && item.PTT_BARKOD_NO.ToString() != null)
            //    {
            //        string _barkod = item.PTT_BARKOD_NO.ToString();
            //        tr.gov.ptt.pttws.SorguService srgSrvc = new tr.gov.ptt.pttws.SorguService();
            //        tr.gov.ptt.pttws.Input inpt = new tr.gov.ptt.pttws.Input();
            //        tr.gov.ptt.pttws.OutputTum opTum = new tr.gov.ptt.pttws.OutputTum();
            //        tr.gov.ptt.pttws.OutputDongu[] opDonArry;
            //        inpt.barkod = _barkod;
            //        inpt.kullanici = _kullanici;
            //        inpt.sifre = _sifre;
            //        srgSrvc.Url = "https://pttws.ptt.gov.tr/GonderiTakip/services/Sorgu?wsdl";
            //        opTum = srgSrvc.gonderiSorgu(inpt);
            //        if (opTum.BARNO != null && opTum.BARNO != "")
            //        {
            //            string _ALICI = opTum.ALICI;
            //            string _BARNO = opTum.BARNO;
            //            string _DEGKONUCR = opTum.DEGKONUCR;
            //            opDonArry = opTum.dongu;
            //            string _EKHIZ = opTum.EKHIZ;
            //            string _GONDEREN = opTum.GONDEREN;
            //            string _GONUCR = opTum.GONUCR;
            //            string _GR = opTum.GR;
            //            string _IMERK = opTum.IMERK;
            //            string _ITARIH = opTum.ITARIH;
            //            string _ODSARUCR = opTum.ODSARUCR;
            //            string _sonucAciklama = opTum.sonucAciklama;
            //            int _sonucKodu = (int)opTum.sonucKodu;
            //            string _TESALAN = opTum.TESALAN;
            //            string _VMERK = opTum.VMERK;

            //            AV001_TDI_BIL_TEBLIGAT_MUHATAP myAV001_TDI_BIL_TEBLIGAT_MUHATAP = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();

            //            myAV001_TDI_BIL_TEBLIGAT_MUHATAP = item;
            //            myAV001_TDI_BIL_TEBLIGAT_MUHATAP.ALAN_CARI_AD = _TESALAN;

            //            //  myAV001_TDI_BIL_TEBLIGAT_MUHATAP.ALIM_SEKIL;
            //            // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.ALIM_SEKIL_ID

            //            if (_sonucAciklama != "islem basarili")
            //            {
            //                //myAV001_TDI_BIL_TEBLIGAT_MUHATAP.BILA_TARIHI = _ITARIH;
            //                myAV001_TDI_BIL_TEBLIGAT_MUHATAP.BILA_TEBLIG_MI = true;
            //            }
            //            else if (_sonucAciklama == "islem basarili")
            //            {
            //                //myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TEBLIG_TARIH = _ITARIH;
            //            }
            //            int adet = 0;
            //            SqlCommand cmd1 = new SqlCommand("select * from dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP_PTT_GELISME where TEBLIGAT_MUHATAP_ID=" + myAV001_TDI_BIL_TEBLIGAT_MUHATAP.ID + " ", cnn);
            //            SqlDataReader dr = cmd1.ExecuteReader();
            //            while (dr.Read())
            //            {
            //                adet++;
            //            }
            //            cmd1.Dispose();
            //            dr.Close();
            //            dr.Dispose();

            //            for (int i = 0; i < opDonArry.Count(); i++)
            //            {
            //                if ((i + 1) > adet)
            //                {
            //                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[AV001_TDI_BIL_TEBLIGAT_MUHATAP_PTT_GELISME] ([TEBLIGAT_MUHATAP_ID],[SIRA_NO] ,[ISLEM],[YER],[BILGI_GIRIS_TARIH] ,[ACIKLAMA] ,[KAYIT_TARIH]) VALUES (" + myAV001_TDI_BIL_TEBLIGAT_MUHATAP.ID + "," + (int)opDonArry[i].siraNo + " ," + opDonArry[i].ISLEM + "," + opDonArry[i].IMERK + "," + opDonArry[i].ITARIH + "," + opDonArry[i].ISLEM + ",getdate)", cnn);
            //                    cmd.ExecuteNonQuery();
            //                    cmd.Dispose();
            //                }
            //                myAV001_TDI_BIL_TEBLIGAT_MUHATAP.POSTA_SON_ISLEM_SIRA_NO = (byte)opDonArry[i].siraNo;
            //                myAV001_TDI_BIL_TEBLIGAT_MUHATAP.POSTA_SON_ISLEM_ADIM = opDonArry[i].ISLEM;
            //                myAV001_TDI_BIL_TEBLIGAT_MUHATAP.POSTA_SON_ISLEM_TARIHI = PttGelenTarihFormatla(opDonArry[i].ITARIH.ToString());
            //                //    myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TB_ACIKLAMA = myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TB_ACIKLAMA + "sýra:" + myOutputDongu.siraNo + "Ýþlem Merkezi :" + myOutputDongu.IMERK + "Ýþlem: " + myOutputDongu.ISLEM + "Tarih:" + myOutputDongu.ITARIH;
            //                //   myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TB_ACIKLAMA = myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TB_ACIKLAMA + Environment.NewLine;    

            //            }
            //            myAV001_TDI_BIL_TEBLIGAT_MUHATAP.KONTROL_KIM_ID = Kimlikci.Kimlik.Bilgi.ID;
            //            myAV001_TDI_BIL_TEBLIGAT_MUHATAP.KONTROL_KIM = Kimlikci.Kimlik.Bilgi.KONTROL_KIM;
            //            myAV001_TDI_BIL_TEBLIGAT_MUHATAP.KONTROL_NE_ZAMAN = Kimlikci.Kimlik.Bilgi.KONTROL_NE_ZAMAN;
            //            myAV001_TDI_BIL_TEBLIGAT_MUHATAP.KONTROL_VERSIYON = Kimlikci.Kimlik.Bilgi.KONTROL_VERSIYON;
            //            myAV001_TDI_BIL_TEBLIGAT_MUHATAP.POSTA_DURUM = _sonucAciklama;

            //            myAV001_TDI_BIL_TEBLIGAT_MUHATAP.POSTA_SON_ISLEM_TARIHI = PttGelenTarihFormatla(_ITARIH.ToString());
            //            myAV001_TDI_BIL_TEBLIGAT_MUHATAP.POSTAHANE = _IMERK;
            //            myAV001_TDI_BIL_TEBLIGAT_MUHATAP.POSTALANDI_MI = true;
            //            myAV001_TDI_BIL_TEBLIGAT_MUHATAP.STAMP = Kimlikci.Kimlik.Bilgi.STAMP;
            //            myAV001_TDI_BIL_TEBLIGAT_MUHATAP.SUBE_KOD_ID = Kimlikci.Kimlik.Bilgi.SUBE_ID;

            //            //  myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TEBLIGAT_ADRESI
            //            //  myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TEBLIGAT_SEKLI_ID
            //            //  myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TEBLIGAT_SONUC_ID
            //            DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.Update(myAV001_TDI_BIL_TEBLIGAT_MUHATAP);
            //        }
            //    }
            //}
            //cnn.Close();
            //cnn.Dispose(); 
            #endregion

            CompInfo smtpInfo = CompInfo.CmpNfoList[0];
            //SqlConnection con = new SqlConnection(smtpInfo.smtpInfo.ConStr);
            //con.Open();

            //try
            //{
            #region MyRegion
            //        SqlCommand cmd1 = new SqlCommand(" select  PTT_BARKOD_NO,ID from BARKOD.dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP", con);
            //SqlDataReader dr = cmd1.ExecuteReader();
            //while (dr.Read())
            //{

            //    if (dr[0].ToString() != "" && dr[0].ToString() != null)
            //    {

            //        SqlConnection con2 = new SqlConnection(smtpInfo.smtpInfo.ConStr);
            //        con2.Open();

            //        #region pttTopluSorgulamaV1  özel barkodlarda çalýþmýyor
            //        //pttTopluSorgulama.GonderiTakipService srg = new pttTopluSorgulama.GonderiTakipService();
            //        //srg.Url = "https://pttws.ptt.gov.tr/TopluTakip/services/GonderiTakip?wsdl";
            //        //pttTopluSorgulama.KurumRumuzSorguInput krsi = new pttTopluSorgulama.KurumRumuzSorguInput();
            //        //krsi.ilk_Barkod = "4290000000803";
            //        //krsi.musteriId = 5373;
            //        //krsi.son_Barkod = "4290000000803";
            //        //krsi.rezerv1 ="0123456789";
            //        //krsi.rezerv2 = "0123456789";
            //        //krsi.rezerv3 = "0123456789";

            //        //pttTopluSorgulama.KurumRumuzSorgu krsrg;
            //        //krsrg= srg.gonderiSorgula(krsi);
            //        //foreach (pttTopluSorgulama.GonderiSafahat item in krsrg.safahatlar)
            //        //{
            //        //    item.ToString();
            //        //}

            //        #endregion


            //        #region pttTekliSorgulamaV2  çalýþýyor safaat veriyor fakat sonuç bilgisi gelmiyor

            //        pttGonderiTakipV2.Input inpt = new Input();
            //        inpt.barkod = "4290000000803";
            //        inpt.kullanici = _kullanici;
            //        inpt.sifre = _sifre;



            //        pttGonderiTakipV2.Sorgu srg = new Sorgu();
            //        pttGonderiTakipV2.OutputTum optum = new OutputTum();
            //        srg.Url = "https://pttws.ptt.gov.tr/GonderiTakipV2/services/Sorgu?wsdl";

            //        optum = srg.gonderiSorgu(inpt);

            //        #endregion

            //        #region pttTopluSorgulamaV2

            //        pttTopluSorgulamaV2.GonderiTakip gontakip = new pttTopluSorgulamaV2.GonderiTakip();

            //        pttTopluSorgulamaV2.KurumRumuzSorgu krmSorgu;
            //        pttTopluSorgulamaV2.GonderiSafahat[] safahatlar;
            //        pttTopluSorgulamaV2.KurumRumuzSorguInput kurumInput = new pttTopluSorgulamaV2.KurumRumuzSorguInput();
            //        //string tel = "2650150024548";

            //        kurumInput.ilk_Barkod = "4290000000803";
            //        kurumInput.son_Barkod = "4290000000803";
            //        kurumInput.rezerv1 = "0123456789";
            //        kurumInput.rezerv2 = "0123456789";
            //        kurumInput.rezerv3 = "0123456789";
            //        kurumInput.musteriId = 5373;
            //        kurumInput.musteriIdSpecified = true;
            //        gontakip.Url = "https://pttws.ptt.gov.tr/TopluTakipV2/services/GonderiTakip?wsdl";
            //        krmSorgu = gontakip.gonderiSorgula(kurumInput);


            //        string a = krmSorgu.SONUC;
            //        safahatlar = krmSorgu.safahatlar;
            //        foreach (var item in safahatlar)
            //        {
            //            string _barkod = item.BARKOD;
            //            string _imerk = item.IMERK;
            //            string _islem = item.ISLEM;
            //            string _iTarih = item.ITARIH;
            //            string _rezerv1 = item.REZERVE_SONUC1;
            //            string _rezerv2 = item.REZERVE_SONUC2;
            //            try
            //            {


            //                if (_barkod != null && _barkod != "")
            //                {

            //                    //string _ALICI = opTum.ALICI;
            //                    //string _BARNO = opTum.BARNO;
            //                    //string _DEGKONUCR = opTum.DEGKONUCR;
            //                    ////  opDonArry = opTum.dongu;

            //                    //opDonArry = opTum.dongu;
            //                    ////string dongustring = opTum2.dongu[0].ToString();
            //                    //string _AlanCariAd = "";
            //                    //foreach (OutputDongu item in opDonArry)
            //                    //{
            //                    //    if (item.ISLEM.ToString() == "21.MAD. GORE MUHTARA TESLiM")
            //                    //    {
            //                    //        _AlanCariAd = "MUHTARA";
            //                    //    }
            //                    //    else if (item.ISLEM.ToString() == "21.MAD. GORE MUHTARA TESLiM")
            //                    //    {

            //                    //    }
            //                    //    string aa = item.IMERK.ToString();
            //                    //    string b = item.ISLEM.ToString();
            //                    //}
            //                    //string _EKHIZ = opTum.EKHIZ;
            //                    //string _GONDEREN = opTum.GONDEREN;
            //                    //string _GONUCR = opTum.GONUCR;
            //                    //string _GR = opTum.GR;
            //                    //string _IMERK = opTum.IMERK;
            //                    //string _ITARIH = opTum.ITARIH;
            //                    //string _ODSARUCR = opTum.ODSARUCR;
            //                    //string _sonucAciklama = opTum.sonucAciklama;
            //                    //int _sonucKodu = (int)opTum.sonucKodu;
            //                    //string _TESALAN = opTum.TESALAN;
            //                    //string _VMERK = opTum.VMERK;


            //                    //    AV001_TDI_BIL_TEBLIGAT_MUHATAP myAV001_TDI_BIL_TEBLIGAT_MUHATAP = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();

            //                    //      myAV001_TDI_BIL_TEBLIGAT_MUHATAP = item;
            //                    string UpdateCommand = "update AV001_TDI_BIL_TEBLIGAT_MUHATAP set ALAN_CARI_AD='" + _rezerv2 + "',";
            //                    //SqlCommand cmd2 = new SqlCommand("AV001_TDI_BIL_TEBLIGAT_MUHATAP ALAN_CARI_AD", con);
            //                    //cmd2.ExecuteNonQuery();
            //                    //cmd2.Dispose();
            //                    //   myAV001_TDI_BIL_TEBLIGAT_MUHATAP.ALAN_CARI_AD = _TESALAN;
            //                    //  myAV001_TDI_BIL_TEBLIGAT_MUHATAP.ALIM_SEKIL;
            //                    // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.ALIM_SEKIL_ID
            //                    string yil = "";
            //                    string ay = "";
            //                    string gun = "";
            //                    for (int i = 0; i < _iTarih.Length; i++)
            //                    {
            //                        if (i < 4)
            //                        {
            //                            yil = yil + _iTarih[i].ToString();
            //                        }
            //                        else if (i < 6)
            //                        {
            //                            ay = ay + _iTarih[i].ToString();
            //                        }
            //                        else
            //                        {
            //                            gun = gun + _iTarih[i].ToString();
            //                        }
            //                    }
            //                    string tarih = gun + "." + ay + "." + yil;
            //                    if (_rezerv1 != "islem basarili")
            //                    {
            //                        //myAV001_TDI_BIL_TEBLIGAT_MUHATAP.BILA_TARIHI = _ITARIH;
            //                        //myAV001_TDI_BIL_TEBLIGAT_MUHATAP.BILA_TEBLIG_MI = true;
            //                        UpdateCommand = UpdateCommand + "BILA_TEBLIG_MI=1,";
            //                        UpdateCommand = UpdateCommand + "BILA_TARIHI='" + tarih + "',";
            //                    }
            //                    else if (_rezerv1 == "islem basarili")
            //                    {
            //                        UpdateCommand = UpdateCommand + "BILA_TEBLIG_MI=0,";
            //                        UpdateCommand = UpdateCommand + "TEBLIG_TARIH='" + tarih + "',";
            //                        //myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TEBLIG_TARIH = _ITARIH;
            //                    }

            //                    //foreach (tr.gov.ptt.pttws.OutputDongu myOutputDongu in opDonArry)
            //                    //{
            //                    //    myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TB_ACIKLAMA = myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TB_ACIKLAMA + "sýra:" + myOutputDongu.siraNo + "Ýþlem Merkezi :" + myOutputDongu.IMERK + "Ýþlem: " + myOutputDongu.ISLEM + "Tarih:" + myOutputDongu.ITARIH;
            //                    //    myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TB_ACIKLAMA = myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TB_ACIKLAMA + Environment.NewLine;

            //                    //}
            //                    //                   UpdateCommand = UpdateCommand + "KONTROL_KIM_ID=" + Kimlikci.Kimlik.Bilgi.ID + ",";
            //                    //   myAV001_TDI_BIL_TEBLIGAT_MUHATAP.KONTROL_KIM_ID = Kimlikci.Kimlik.Bilgi.ID;
            //                    //              UpdateCommand = UpdateCommand + "KONTROL_KIM='" + Kimlikci.Kimlik.Bilgi.KONTROL_KIM + "',";
            //                    //   myAV001_TDI_BIL_TEBLIGAT_MUHATAP.KONTROL_KIM = Kimlikci.Kimlik.Bilgi.KONTROL_KIM;
            //                    //             UpdateCommand = UpdateCommand + "KONTROL_NE_ZAMAN='" + Kimlikci.Kimlik.Bilgi.KONTROL_NE_ZAMAN + "',";
            //                    //  myAV001_TDI_BIL_TEBLIGAT_MUHATAP.KONTROL_NE_ZAMAN = Kimlikci.Kimlik.Bilgi.KONTROL_NE_ZAMAN;
            //                    //               UpdateCommand = UpdateCommand + "KONTROL_VERSIYON='" + Kimlikci.Kimlik.Bilgi.KONTROL_VERSIYON + "',";
            //                    //   myAV001_TDI_BIL_TEBLIGAT_MUHATAP.KONTROL_VERSIYON = Kimlikci.Kimlik.Bilgi.KONTROL_VERSIYON;
            //                    UpdateCommand = UpdateCommand + "POSTA_DURUM='" + _rezerv1 + "',";
            //                    //   myAV001_TDI_BIL_TEBLIGAT_MUHATAP.POSTA_DURUM = _sonucAciklama;

            //                    //  myAV001_TDI_BIL_TEBLIGAT_MUHATAP.POSTA_SON_ISLEM_TARIHI = _ITARIH;

            //                    UpdateCommand = UpdateCommand + "POSTA_SON_ISLEM_TARIHI='" + tarih + "',";
            //                    UpdateCommand = UpdateCommand + "POSTAHANE='" + _imerk + "',";
            //                    //    myAV001_TDI_BIL_TEBLIGAT_MUHATAP.POSTAHANE = _IMERK;
            //                    UpdateCommand = UpdateCommand + "POSTALANDI_MI=1 where ID=" + dr[1] + "";
            //                    //  myAV001_TDI_BIL_TEBLIGAT_MUHATAP.POSTALANDI_MI = true;
            //                    //                   UpdateCommand = UpdateCommand + "STAMP='" + Kimlikci.Kimlik.Bilgi.STAMP + "',";   
            //                    //   myAV001_TDI_BIL_TEBLIGAT_MUHATAP.STAMP = Kimlikci.Kimlik.Bilgi.STAMP;
            //                    //                    UpdateCommand = UpdateCommand + "SUBE_KOD_ID='" + Kimlikci.Kimlik.Bilgi.SUBE_ID + "' where ID="+dr[1]+"";  
            //                    //    myAV001_TDI_BIL_TEBLIGAT_MUHATAP.SUBE_KOD_ID = Kimlikci.Kimlik.Bilgi.SUBE_ID;
            //                    //  myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TEBLIGAT_ADRESI
            //                    //  myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TEBLIGAT_SEKLI_ID
            //                    //  myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TEBLIGAT_SONUC_ID
            //                    SqlCommand cmd2 = new SqlCommand(UpdateCommand, con2);
            //                    cmd2.ExecuteNonQuery();
            //                    cmd2.Dispose();
            //                    con2.Close();
            //                    con2.Dispose();
            //                    //    DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.Update(myAV001_TDI_BIL_TEBLIGAT_MUHATAP);
            //                }
            //            }
            //            catch (Exception)
            //            {


            //            }
            //        }
            //        #endregion

            //        //pttGonderiTakipV2.Sorgu srgSrvc = new pttGonderiTakipV2.Sorgu();

            //        //pttGonderiTakipV2.Input inpt = new pttGonderiTakipV2.Input();

            //        //pttGonderiTakipV2.OutputTum opTum = new pttGonderiTakipV2.OutputTum();

            //        //pttGonderiTakipV2.OutputDongu[] opDonArry;

            //        //inpt.barkod = "TB01653205279";//"4290000000780";

            //        //inpt.kullanici = "PttWs";

            //        //inpt.sifre = "YazDes*1840";


            //        //srgSrvc.Url = "https://pttws.ptt.gov.tr/GonderiTakipV2/services/Sorgu?wsdl";
            //        //srgSrvc.Timeout = Int32.MaxValue;
            //        //opTum = srgSrvc.gonderiSorgu(inpt);



            //        //string _sonucAciklama = opTum.sonucAciklama;

            //        //opDonArry = opTum.dongu;





            //    }
            //} 
            #endregion
            string _barkod = "";
            SqlConnection con1 = new SqlConnection(smtpInfo.ConStr);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select PTT_BARKOD_NO  from  AV001_TDI_BIL_TEBLIGAT_MUHATAP WHERE TEBLIGAT_SONUC_ID IS NULL AND LEN(PTT_BARKOD_NO)>12", con1);
            SqlDataReader dr = cmd1.ExecuteReader();

            while (dr.Read())
            {
                _barkod = dr[0].ToString();
                if (_barkod.Length > 12)
                {
                    barkodÝslemleri brkdislem = new barkodÝslemleri();
                    brkdislem.barkodSorgula(_barkod);
                }
            }
            dr.Close();
            dr.Dispose();
            cmd1.Dispose();
            con1.Close();
            con1.Dispose();

        }

        private void ucTebligatMuhatapForGiris1_KayitSilindi(object sender, EventArgs e)
        {
            bckWorker.RunWorkerAsync();
        }

        private void gvTebligat_DoubleClick(object sender, EventArgs e)
        {
            if (ucTebligatMuhatapForGiris1.gvTebligat.SelectedRowsCount > 0)
            {
                List<int> idler = AvukatPro.Services.Implementations.DosyaService.GetAllBelgeIDsByTebligatID((int)ucTebligatMuhatapForGiris1.gvTebligat.GetRowCellValue(ucTebligatMuhatapForGiris1.gvTebligat.FocusedRowHandle, "Id"));
                if (idler.Count > 0)
                    ucBelgeIzleme1.BelgeIds = idler;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Forms.LayForm.frmLayTabligatKayit_exp tebligat = new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit_exp();
            tebligat.Show();
        }
    }
    public class barkodÝslemleri
    {

        public void barkodSorgula(string _barkod)
        {

            #region pttTekliSorgulamaV2  çalýþýyor safaat veriyor fakat sonuç bilgisi gelmiyor

            try
            {
                string _kullanici = "PttWs";
                string _sifre = "YazDes*1840";
                pttGonderiTakipV2.Input inpt = new pttGonderiTakipV2.Input();
                inpt.barkod = _barkod;// "4290000000803";
                inpt.kullanici = _kullanici;
                inpt.sifre = _sifre;
                pttGonderiTakipV2.Sorgu srg = new pttGonderiTakipV2.Sorgu();
                pttGonderiTakipV2.OutputTum optum = new pttGonderiTakipV2.OutputTum();
                srg.Url = "https://pttws.ptt.gov.tr/GonderiTakipV2/services/Sorgu?wsdl";

                optum = srg.gonderiSorgu(inpt);
                foreach (var item in optum.dongu)
                {
                    string _imerk = item.IMERK;
                    string _islem = item.ISLEM;
                    string _iTarih = item.ITARIH;
                    string _siraNo = item.siraNo.ToString();
                    if (_islem.Contains("MUHTAR"))
                    {
                        //  listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "MUHTAR");
                    }
                    else if (_islem.Contains("KENDÝ"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "KENDÝ");
                    }
                    else if (_islem.Contains("BiZZAT"))  //MUHATABA BiZZAT TESLiM
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "KENDÝ");
                    }

                    else if (_islem.Contains("YAKIN"))
                    {
                        //   listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "BÝRLÝKTE SAKÝN");
                    }
                    else if (_islem.Contains("ÇALIÞAN"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "ÇALIÞAN");
                    }
                    else if (_islem.Contains("AÝLE"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "AÝLE");
                    }
                    else if (_islem.Contains("AMÝR"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "ÝDARE AMÝRÝNE");
                    }
                    else if (_islem.Contains("VELÝ"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "VELÝ");
                    }
                    else if (_islem.Contains("VEKÝL"))
                    {
                        //  listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "VEKÝL");
                    }
                    else if (_islem.Contains("VASÝ"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "VASÝ");
                    }
                    else if (_islem.Contains("EÞÝ"))
                    {
                        //  listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "TARAFIN EÞÝ");
                    }
                    else if (_islem.Contains("ÇOCUK"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "ÇOCUK");
                    }
                    else if (_islem.Contains("BÝRLÝKTE"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "BÝRLÝKTE");
                    }
                    else if (_islem.Contains("MEMUR"))
                    {
                        //  listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "MEMUR");
                    }
                    else if (_islem.Contains("HÝZMETÇÝ"))
                    {
                        //  listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "HÝZMETÇÝ");
                    }
                    else if (_islem.Contains("iADE EDiLDi"))
                    {
                        //  listBox1.Items.Add("Barkod No : " + inpt.barkod + ", Ýslem Merkezi : " + _imerk + ", Ýþlem :" + _islem + ", Ýþlem Tarihi  :" + _iTarih + ", Sýra No  : " + _siraNo);
                        sonucUpdate(_iTarih, "BÝLA TEBLÝÐ", "islem basarili", _imerk, inpt.barkod, "iADE EDiLDi");
                    }


                    // dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP_PTT_GELISME

                    gelismeAdimInsert(inpt.barkod, _imerk, _islem, _iTarih, _siraNo);

                }
            }
            catch (Exception)
            {


            }
            #endregion

        }
        public void sonucUpdate(string _iTarih, string _sonuc, string _durum, string _imerk, string _barkodNo, string _kime)
        {

            CompInfo smtpInfo = CompInfo.CmpNfoList[0];
            string UpdateCommand = "update AV001_TDI_BIL_TEBLIGAT_MUHATAP set ";
            if (_kime == "KENDÝ")
            {
                int _MUHATAP_CARI_ID = 0;
                SqlConnection con1 = new SqlConnection(smtpInfo.ConStr);
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("select MUHATAP_CARI_ID  from AV001_TDI_BIL_TEBLIGAT_MUHATAP where PTT_BARKOD_NO='" + _barkodNo + "' ", con1);
                SqlDataReader dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    _MUHATAP_CARI_ID = Convert.ToInt32(dr[0].ToString());
                    break;
                }
                dr.Close();
                dr.Dispose();
                cmd1.Dispose();
                con1.Close();
                con1.Dispose();

                UpdateCommand = UpdateCommand + " ALAN_CARI_ID=" + _MUHATAP_CARI_ID + ",";
            }
            else if (_kime == "MUHTAR")
            {
                UpdateCommand = UpdateCommand + " TEBLIGAT_SEKLI_ID=2,";
            }
            else if (_kime == "iADE EDiLDi")
            {
                //UpdateCommand = UpdateCommand + " TEBLIGAT_SEKLI_ID=2,";
            }
            else
            {
                int _ALAN_BAGLANTI_ID = 0;
                SqlConnection con1 = new SqlConnection(smtpInfo.ConStr);
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("select ID  from TDI_KOD_TEBLIGAT_ALAN_BAGLANTI where BAGLANTI like '%" + _kime + "%' ", con1);
                SqlDataReader dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    _ALAN_BAGLANTI_ID = Convert.ToInt32(dr[0].ToString());
                    break;
                }

                dr.Close();
                dr.Dispose();
                cmd1.Dispose();
                con1.Close();
                con1.Dispose();
                UpdateCommand = UpdateCommand + " ALAN_BAGLANTI_ID=" + _ALAN_BAGLANTI_ID + ",";
            }
            string[] mytarih = _iTarih.Split('/');
            string yil = mytarih[2];
            string ay = mytarih[1];
            string gun = mytarih[0];
            //for (int i = 0; i < _iTarih.Length; i++)
            //{
            //    if (i < 4)
            //    {
            //        yil = yil + _iTarih[i].ToString();
            //    }
            //    else if (i < 6)
            //    {
            //        ay = ay + _iTarih[i].ToString();
            //    }
            //    else
            //    {
            //        gun = gun + _iTarih[i].ToString();
            //    }
            //}//2012-02-10 14:37:22.680
            string tarih = yil + "-" + ay + "-" + gun + " 00:00:00.000";
            //string tarih = _iTarih.Replace('/', '.');
            if (_sonuc != "islem basarili")
            {
                UpdateCommand = UpdateCommand + "BILA_TEBLIG_MI=1,";
                UpdateCommand = UpdateCommand + "BILA_TARIHI='" + tarih + "',";
                UpdateCommand = UpdateCommand + "TEBLIGAT_SONUC_ID=3,";
            }
            else if (_sonuc == "islem basarili")
            {
                UpdateCommand = UpdateCommand + "BILA_TEBLIG_MI=0,";
                UpdateCommand = UpdateCommand + "TEBLIG_TARIH='" + tarih + "',";
                UpdateCommand = UpdateCommand + "TEBLIGAT_SONUC_ID=2,";
            }
            UpdateCommand = UpdateCommand + "POSTA_DURUM='" + _durum + "',";
            UpdateCommand = UpdateCommand + "POSTA_SON_ISLEM_TARIHI='" + tarih + "',";
            UpdateCommand = UpdateCommand + "POSTAHANE='" + _imerk + "',";
            UpdateCommand = UpdateCommand + "POSTALANDI_MI=1 where PTT_BARKOD_NO='" + _barkodNo + "'";


            SqlConnection con2 = new SqlConnection(smtpInfo.ConStr);
            con2.Open();
            SqlCommand cmd2 = new SqlCommand(UpdateCommand, con2);
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();
            con2.Close();
            con2.Dispose();
        }
        public void gelismeAdimInsert(string _barkodNo, string _imerk, string _islem, string _iTarih, string _siraNo)
        {

            CompInfo smtpInfo = CompInfo.CmpNfoList[0];
            int _TEBLIGAT_MUHATAP_ID = 0;
            bool insertYapsinmi = true;
            SqlConnection con1 = new SqlConnection(smtpInfo.ConStr);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select ID  from AV001_TDI_BIL_TEBLIGAT_MUHATAP where PTT_BARKOD_NO='" + _barkodNo + "' ", con1);
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                _TEBLIGAT_MUHATAP_ID = Convert.ToInt32(dr[0].ToString());

            }
            dr.Close();
            dr.Dispose();
            cmd1.Dispose();
            con1.Close();
            con1.Dispose();

            SqlConnection con3 = new SqlConnection(smtpInfo.ConStr);
            con3.Open();
            SqlCommand cmd3 = new SqlCommand("select ID  from [dbo].[AV001_TDI_BIL_TEBLIGAT_MUHATAP_PTT_GELISME]  where [TEBLIGAT_MUHATAP_ID]=" + _TEBLIGAT_MUHATAP_ID + " and [SIRA_NO]= " + Convert.ToInt32(_siraNo) + "", con3);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                insertYapsinmi = false;

            }
            dr3.Close();
            dr3.Dispose();
            cmd3.Dispose();
            con3.Close();
            con3.Dispose();
            if (insertYapsinmi)
            {

                string commandInsert = @"INSERT INTO [dbo].[AV001_TDI_BIL_TEBLIGAT_MUHATAP_PTT_GELISME] 
([TEBLIGAT_MUHATAP_ID],[SIRA_NO],[ISLEM],[YER],[BILGI_GIRIS_TARIH],[ACIKLAMA],[KAYIT_TARIH]) 
VALUES (" + _TEBLIGAT_MUHATAP_ID + "," + Convert.ToInt32(_siraNo) + ",'" + _islem + "','" + _imerk + "','" + _iTarih + "','',getdate())";

                SqlConnection con2 = new SqlConnection(smtpInfo.ConStr);
                con2.Open();
                SqlCommand cmd2 = new SqlCommand(commandInsert, con2);
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();
                con2.Close();
                con2.Dispose();

            }
        }


    }
}